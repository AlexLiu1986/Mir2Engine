using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetFramework.AsyncSocketServer
{
    /// <summary>
    /// �첽SocketͨѶ��������
    /// </summary>
    public class IServerSocket
    {
        // ������ͬ������
        private Object m_bufferLock = new Object();

        // �������ͬ������
        private Object m_readPoolLock = new Object();

        // д�����ͬ������
        private Object m_writePoolLock = new Object();

        // ���������¼����󼯺�
        private Dictionary<string, AsyncUserToken> m_tokens;

        // ��ӹ���
        private int m_numConnections;           // ���ͬʱ��������������

        private int m_BufferSize;               // ����ÿһ��Socket I/O����ʹ�õĻ�������С
        private BufferManager m_bufferManager;  // Ϊ����Socket����׼����һ����Ŀ����õĻ���������
        private const int opsToPreAlloc = 2;    // ��Ҫ����ռ�Ĳ�����Ŀ:Ϊ ����д�����յ� ����Ԥ����ռ�(���ܲ������Բ�����)
        private Socket listenSocket;            // ����������������������Socket

        // ��Socket������SocketAsyncEventArgs�����ö����
        private SocketAsyncEventArgsPool m_readPool;

        // дSocket������SocketAsyncEventArgs�����ö����
        private SocketAsyncEventArgsPool m_writePool;

        // ������
        private long m_totalBytesRead;          // ���������յ������ֽ���������

        private long m_totalBytesWrite;         // ���������͵��ֽ�����

        private long m_numConnectedSockets;      // ���ӵ���������Socket����
        private Semaphore m_maxNumberAcceptedClients;//�������������ź���

        /// <summary>
        /// ��ȡ�Ѿ����ӵ�Socket����
        /// </summary>
        public long NumConnectedSockets
        {
            get { return m_numConnectedSockets; }
        }

        /// <summary>
        /// ��ȡ���յ����ֽ�����
        /// </summary>
        public long TotalBytesRead
        {
            get { return m_totalBytesRead; }
        }

        /// <summary>
        /// ��ȡ���͵��ֽ�����
        /// </summary>
        public long TotalBytesWrite
        {
            get { return m_totalBytesWrite; }
        }

        /// <summary>
        /// �ͻ����Ѿ������¼�
        /// </summary>
        public event EventHandler<AsyncUserToken> OnClientConnect;        // �ͻ����Ѿ������¼�

        /// <summary>
        /// �ͻ��˴����¼�
        /// </summary>
        public event EventHandler<AsyncSocketErrorEventArgs> OnClientError;     // �ͻ��˴����¼�

        /// <summary>
        /// ���յ������¼�
        /// </summary>
        public event EventHandler<AsyncUserToken> OnClientRead;           // ���յ������¼�

        /// <summary>
        /// ���ݷ������
        /// </summary>
        public event EventHandler<AsyncUserToken> OnDataSendCompleted;// ���ݷ������

        /// <summary>
        /// �ͻ��˶Ͽ������¼�
        /// </summary>
        public event EventHandler<AsyncUserToken> OnClientDisconnect;     // �ͻ��˶Ͽ������¼�

        /// <summary>
        /// �ͻ����Ƿ�����
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns>���߷���true�����򷵻�false</returns>
        public bool IsOnline(string connectionId)
        {
            lock (((ICollection)this.m_tokens).SyncRoot)
            {
                if (!this.m_tokens.ContainsKey(connectionId))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="numConnections">�������������ӵĿͻ�������</param>
        /// <param name="receiveBufferSize">���ջ�������С</param>
        public IServerSocket(int numConnections, int BufferSize)//���캯��
        {
            // ���ý��պͷ����ֽ�����
            m_totalBytesRead = 0;
            m_totalBytesWrite = 0;

            // �Ѿ����ӵĿͻ�������
            m_numConnectedSockets = 0;

            // ���ݿ������������
            m_numConnections = numConnections;

            // ���ջ�������С
            m_BufferSize = BufferSize;

            // Ϊ�����ĿSocket ͬʱ��ӵ�и����ܵĶ���дͨѶ���ֶ����仺�����ռ�

            m_bufferManager = new BufferManager(BufferSize * numConnections * opsToPreAlloc,
                BufferSize);

            // ��д��
            m_readPool = new SocketAsyncEventArgsPool(numConnections);
            m_writePool = new SocketAsyncEventArgsPool(numConnections);

            // ���������¼��������󼯺�
            m_tokens = new Dictionary<string, AsyncUserToken>();

            // ��ʼ�ź���
            m_maxNumberAcceptedClients = new Semaphore(numConnections, numConnections);
        }

        /// <summary>
        /// ��Ԥ����Ŀ����û������������Ķ����ʼ��������.
        /// </summary>
        public void Init()
        {
            // Ϊ���е�I/O��������һ������ֽڻ�����.Ŀ���Ƿ�ֹ�ڴ���Ƭ�Ĳ���
            m_bufferManager.InitBuffer();

            // �����õ�SocketAsyncEventArgs,�����ظ����ܿͻ���ʹ��
            SocketAsyncEventArgs readWriteEventArg;
            AsyncUserToken token;

            // Ԥ����һ�� SocketAsyncEventArgs �����

            // Ԥ����SocketAsyncEventArgs�������
            for (int i = 0; i < m_numConnections; i++)
            {
                // Ԥ����һ�� �����õ�SocketAsyncEventArgs ����
                //readWriteEventArg = new SocketAsyncEventArgs();
                // ����tokenʱͬʱ������һ����token���������ڶ����ݵ�SocketAsyncEventArgs����,
                // ���Ҵ�����SocketAsyncEventArgs�����UserToken����ֵΪ��token
                token = new AsyncUserToken();

                //token.ReadEventArgs = readWriteEventArg;
                //readWriteEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                // ע��һ��SocketAsyncEventArgs����¼�
                token.ReadEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);

                //readWriteEventArg.UserToken = new AsyncUserToken();

                // �ӻ��������з���һ���ֽڻ������� SocketAsyncEventArg ����
                //m_bufferManager.SetBuffer(readWriteEventArg);
                m_bufferManager.SetBuffer(token.ReadEventArgs);

                //((AsyncUserToken)readWriteEventArg.UserToken).SetReceivedBytes(readWriteEventArg.Buffer, readWriteEventArg.Offset, 0);
                //�趨���ջ�������ƫ����
                token.SetBuffer(token.ReadEventArgs.Buffer, token.ReadEventArgs.Offset, token.ReadEventArgs.Count);

                // ���һ�� SocketAsyncEventArg ������
                //m_readPool.Push(readWriteEventArg);
                m_readPool.Push(token.ReadEventArgs);
            }

            // Ԥ����SocketAsyncEventArgsд�����
            for (int i = 0; i < m_numConnections; i++)
            {
                // Ԥ����һ�� �����õ�SocketAsyncEventArgs ����
                readWriteEventArg = new SocketAsyncEventArgs();
                readWriteEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                readWriteEventArg.UserToken = null;

                // �ӻ��������з���һ���ֽڻ������� SocketAsyncEventArg ����
                m_bufferManager.SetBuffer(readWriteEventArg);

                //readWriteEventArg.SetBuffer(null, 0, 0);

                // ���һ�� SocketAsyncEventArg ������
                m_writePool.Push(readWriteEventArg);
            }
        }

        /// <summary>
        /// �����첽Socket������
        /// </summary>
        public void Start(string listenIp,int listenPort)
        {
            Start(new IPEndPoint(IPAddress.Parse(listenIp), listenPort));
        }

        /// <summary>
        /// �����첽Socket������
        /// </summary>
        /// <param name="localEndPoint">Ҫ�󶨵ı����ս��</param>
        internal void Start(IPEndPoint localEndPoint)// ����
        {
            try
            {
                // ����һ�������������ӵ�Socket
                if (null != listenSocket)
                {
                    listenSocket.Close();
                }
                else
                {
                    listenSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    listenSocket.Bind(localEndPoint);
                }

                // ��һ������100�����ӵĶ�������������
                listenSocket.Listen(100);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (SocketException)
            {
                //RaiseErrorEvent(null, exception);
                // ����ʧ���׳�����ʧ���쳣
                throw new AsyncSocketException("����������ʧ��", AsyncSocketErrorCode.ServerStartFailure);
            }
            catch (Exception exception_debug)
            {
                Debug.WriteLine("���ԣ�" + exception_debug.Message);
                throw exception_debug;
            }

            // ������Socket���׳�����ί��.

            StartAccept(null); // (��һ�β����ÿ����õ�SocketAsyncEventArgs���������������Socket��Accept��ʽ)

            Debug.WriteLine("�����������ɹ�....");
        }

        /// <summary>
        /// ��ʼ������������
        /// </summary>
        /// <param name="acceptEventArg"></param>
        private void StartAccept(SocketAsyncEventArgs acceptEventArg)
        {
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
            }
            else
            {
                // ���������Ķ������ڱ�ʹ��Socket���뱻����
                acceptEventArg.AcceptSocket = null;
            }
            try
            {
                m_maxNumberAcceptedClients.WaitOne();// ���ź�������һ��P����

                bool willRaiseEvent = listenSocket.AcceptAsync(acceptEventArg);
                if (!willRaiseEvent)
                {
                    ProcessAccept(acceptEventArg);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (SocketException socketException)
            {
                RaiseErrorEvent(null, new AsyncSocketException("���������ܿͻ���������һ���쳣", socketException));

                // ���ܿͻ��˷����쳣
                //throw new AsyncSocketException("���������ܿͻ���������һ���쳣", AsyncSocketErrorCode.ServerAcceptFailure);
            }
            catch (Exception exception_debug)
            {
                Debug.WriteLine("���ԣ�" + exception_debug.Message);
                throw exception_debug;
            }
        }

        /// <summary>
        /// ��������ǹ����첽���ܲ����Ļص��������ҵ����ղ������ʱ������
        /// </summary>
        private void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }

        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            AsyncUserToken token;
            Interlocked.Increment(ref m_numConnectedSockets);
            Debug.WriteLine(string.Format("�ͻ����������󱻽���. �� {0} ���ͻ������ӵ�������",
                m_numConnectedSockets.ToString()));
            SocketAsyncEventArgs readEventArg;

            // ����Ѿ����ܵĿͻ�������Socket�������ŵ�ReadEventArg�����user token��
            lock (m_readPool)
            {
                readEventArg = m_readPool.Pop();
            }

            token = (AsyncUserToken)readEventArg.UserToken;

            // �����ŵ�ReadEventArg�����user token��
            token.Socket = e.AcceptSocket;

            // ���һ���µ�Guid 32λ "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
            token.ConnectionId = Guid.NewGuid().ToString("N");

            lock (((ICollection)this.m_tokens).SyncRoot)
            {
                this.m_tokens.Add(token.ConnectionId, token);// ��ӵ�������
            }

            EventHandler<AsyncUserToken> handler = OnClientConnect;

            // ��������¼���Ϊ��(null)
            if (handler != null)
            {
                handler(this, token);// �׳��ͻ��������¼�
            }

            try
            {
                // �ͻ���һ�����Ͼ��׳�һ������ί�и����ӵ�Socket��ʼ��������
                bool willRaiseEvent = token.Socket.ReceiveAsync(readEventArg);
                if (!willRaiseEvent)
                {
                    ProcessReceive(readEventArg);
                }
            }
            catch (ObjectDisposedException)
            {
                RaiseDisconnectedEvent(token);
            }
            catch (SocketException socketException)
            {
                if (socketException.ErrorCode == (int)SocketError.ConnectionReset)// 10054һ�����������ӱ�Զ������ǿ�йر�
                {
                    RaiseDisconnectedEvent(token);// �����Ͽ������¼�
                }
                else
                {
                    RaiseErrorEvent(token, new AsyncSocketException("��SocketAsyncEventArgs������ִ���첽�������ݲ���ʱ����SocketException�쳣", socketException));
                }
            }
            catch (Exception exception_debug)
            {
                Debug.WriteLine("���ԣ�" + exception_debug.Message);
                throw exception_debug;
            }
            finally
            {
                // ������һ����������
                StartAccept(e);
            }
        }

        /// <summary>
        /// ���������һ��Socket�����߷��Ͳ������ʱ������
        /// </summary>
        /// <param name="e">����ɵĽ��ܲ���������SocketAsyncEventArg����</param>
        private void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            // ȷ���ո���ɵĲ������Ͳ����ù����ľ��
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;

                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;

                default:
                    throw new ArgumentException("���һ����Socket�ϵĲ������ǽ��ջ��߷��Ͳ���");
            }
        }

        /// <summary>
        /// ����������첽���ղ������ʱ����.
        /// ���Զ�������ر�����Socket���ر�
        /// </summary>
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            AsyncUserToken token = (AsyncUserToken)e.UserToken;

            // ���Զ�������Ƿ�ر�����

            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                // ���ӽ��յ����ֽ�����
                Interlocked.Add(ref m_totalBytesRead, e.BytesTransferred);
                Debug.WriteLine(string.Format("��������ȡ�ֽ�����:{0}", m_totalBytesRead.ToString()));

                //byte[] destinationArray = new byte[e.BytesTransferred];// Ŀ���ֽ�����
                //Array.Copy(e.Buffer, 0, destinationArray, 0, e.BytesTransferred);
                token.SetBytesReceived(e.BytesTransferred);

                EventHandler<AsyncUserToken> handler = OnClientRead;

                // ��������¼���Ϊ��(null)
                if (handler != null)
                {
                    handler(this, token);// �׳����յ������¼�
                }

                try
                {
                    // ������������
                    bool willRaiseEvent = token.Socket.ReceiveAsync(e);
                    if (!willRaiseEvent)
                    {
                        ProcessReceive(e);
                    }
                }
                catch (ObjectDisposedException)
                {
                    RaiseDisconnectedEvent(token);
                }
                catch (SocketException socketException)
                {
                    if (socketException.ErrorCode == (int)SocketError.ConnectionReset)//10054һ�����������ӱ�Զ������ǿ�йر�
                    {
                        RaiseDisconnectedEvent(token);//�����Ͽ������¼�
                    }
                    else
                    {
                        RaiseErrorEvent(token, new AsyncSocketException("��SocketAsyncEventArgs������ִ���첽�������ݲ���ʱ����SocketException�쳣", socketException));
                    }
                }
                catch (Exception exception_debug)
                {
                    Debug.WriteLine("���ԣ�" + exception_debug.Message);
                    throw exception_debug;
                }
            }
            else
            {
                RaiseDisconnectedEvent(token);
            }
        }

        public void Send(string connectionId, byte[] buffer)
        {
            AsyncUserToken token;

            //SocketAsyncEventArgs token;

            //if (buffer.Length <= m_receiveSendBufferSize)
            //{
            //    throw new ArgumentException("���ݰ����ȳ�����������С", "buffer");
            //}

            lock (((ICollection)this.m_tokens).SyncRoot)
            {
                if (!this.m_tokens.TryGetValue(connectionId, out token))
                {
                    throw new AsyncSocketException(string.Format("�ͻ���:{0}�Ѿ��رջ���δ����", connectionId), AsyncSocketErrorCode.ClientSocketNoExist);

                    //return;
                }
            }
            SocketAsyncEventArgs writeEventArgs;
            lock (m_writePool)
            {
                writeEventArgs = m_writePool.Pop();// ����һ��дSocketAsyncEventArgs����
            }
            writeEventArgs.UserToken = token;
            if (buffer.Length <= m_BufferSize)
            {
                Array.Copy(buffer, 0, writeEventArgs.Buffer, writeEventArgs.Offset, buffer.Length);
                writeEventArgs.SetBuffer(writeEventArgs.Buffer, writeEventArgs.Offset, buffer.Length);
            }
            else
            {
                lock (m_bufferLock)
                {
                    m_bufferManager.FreeBuffer(writeEventArgs);
                }
                writeEventArgs.SetBuffer(buffer, 0, buffer.Length);
            }

            //writeEventArgs.SetBuffer(buffer, 0, buffer.Length);
            try
            {
                // �첽��������
                bool willRaiseEvent = token.Socket.SendAsync(writeEventArgs);
                if (!willRaiseEvent)
                {
                    ProcessSend(writeEventArgs);
                }
            }
            catch (ObjectDisposedException)
            {
                RaiseDisconnectedEvent(token);
            }
            catch (SocketException socketException)
            {
                if (socketException.ErrorCode == (int)SocketError.ConnectionReset)//10054һ�����������ӱ�Զ������ǿ�йر�
                {
                    RaiseDisconnectedEvent(token);//�����Ͽ������¼�
                }
                else
                {
                    RaiseErrorEvent(token, new AsyncSocketException("��SocketAsyncEventArgs������ִ���첽�������ݲ���ʱ����SocketException�쳣", socketException)); ;
                }
            }
            catch (Exception exception_debug)
            {
                Debug.WriteLine("���ԣ�" + exception_debug.Message);
                throw exception_debug;
            }
        }

        /// <summary>
        /// ��������,����Я����������(ʹ���Զ���ö������ʾ)
        /// </summary>
        /// <param name="connectionId">���ӵ�ID��</param>
        /// <param name="buffer">��������С</param>
        /// <param name="operation">�����Զ���ö��</param>
        public void Send(string connectionId, byte[] buffer, object operation)
        {
            AsyncUserToken token;

            //SocketAsyncEventArgs token;

            //if (buffer.Length <= m_receiveSendBufferSize)
            //{
            //    throw new ArgumentException("���ݰ����ȳ�����������С", "buffer");
            //}

            lock (((ICollection)this.m_tokens).SyncRoot)
            {
                if (!this.m_tokens.TryGetValue(connectionId, out token))
                {
                    throw new AsyncSocketException(string.Format("�ͻ���:{0}�Ѿ��رջ���δ����", connectionId), AsyncSocketErrorCode.ClientSocketNoExist);

                    //return;
                }
            }
            SocketAsyncEventArgs writeEventArgs;
            lock (m_writePool)
            {
                writeEventArgs = m_writePool.Pop();// ����һ��дSocketAsyncEventArgs����
            }
            writeEventArgs.UserToken = token;
            token.Operation = operation;// ���ò�����־
            if (buffer.Length <= m_BufferSize)
            {
                Array.Copy(buffer, 0, writeEventArgs.Buffer, writeEventArgs.Offset, buffer.Length);
            }
            else
            {
                lock (m_bufferLock)
                {
                    m_bufferManager.FreeBuffer(writeEventArgs);
                }
                writeEventArgs.SetBuffer(buffer, 0, buffer.Length);
            }

            //writeEventArgs.SetBuffer(buffer, 0, buffer.Length);
            try
            {
                // �첽��������
                bool willRaiseEvent = token.Socket.SendAsync(writeEventArgs);
                if (!willRaiseEvent)
                {
                    ProcessSend(writeEventArgs);
                }
            }
            catch (ObjectDisposedException)
            {
                RaiseDisconnectedEvent(token);
            }
            catch (SocketException socketException)
            {
                if (socketException.ErrorCode == (int)SocketError.ConnectionReset)//10054һ�����������ӱ�Զ������ǿ�йر�
                {
                    RaiseDisconnectedEvent(token);//�����Ͽ������¼�
                }
                else
                {
                    RaiseErrorEvent(token, new AsyncSocketException("��SocketAsyncEventArgs������ִ���첽�������ݲ���ʱ����SocketException�쳣", socketException)); ;
                }
            }
            catch (Exception exception_debug)
            {
                Debug.WriteLine("���ԣ�" + exception_debug.Message);
                throw exception_debug;
            }
        }

        /// <summary>
        /// ���������һ���첽���Ͳ������ʱ������.
        /// </summary>
        /// <param name="e"></param>
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            //SocketAsyncEventArgs token;
            AsyncUserToken token = (AsyncUserToken)e.UserToken;

            // ���ӷ��ͼ�����
            Interlocked.Add(ref m_totalBytesWrite, e.BytesTransferred);

            if (e.Count > m_BufferSize)
            {
                lock (m_bufferLock)
                {
                    m_bufferManager.SetBuffer(e);// �ָ�Ĭ�ϴ�С������
                }

                //e.SetBuffer(null, 0, 0);// ������ͻ�����
            }
            lock (m_writePool)
            {
                // ����SocketAsyncEventArgs�Ա��ٴα�����
                m_writePool.Push(e);
            }

            // ���UserToken��������
            e.UserToken = null;

            if (e.SocketError == SocketError.Success)
            {
                Debug.WriteLine(string.Format("���� �ֽ���:{0}", e.BytesTransferred.ToString()));

                //lock (((ICollection)this.m_tokens).SyncRoot)
                //{
                //    if (!this.m_tokens.TryGetValue(token.ConnectionId, out token))
                //    {
                //        RaiseErrorEvent(token,new AsyncSocketException(string.Format("�ͻ���:{0}�����Ѿ��رջ���δ����", token.ConnectionId), AsyncSocketErrorCode.ClientSocketNoExist));
                //        //throw new AsyncSocketException(string.Format("�ͻ���:{0}�����Ѿ��رջ���δ����", token.ConnectionId), AsyncSocketErrorCode.ClientSocketNoExist);
                //        //return;
                //    }
                //}

                EventHandler<AsyncUserToken> handler = OnDataSendCompleted;

                // ��������¼���Ϊ��(null)
                if (handler != null)
                {
                    handler(this, token);//�׳��ͻ��˷�������¼�
                }

                //try
                //{
                //    // ��ȡ��һ��ӿͻ��˷�����������
                //    bool willRaiseEvent = ((AsyncUserToken)connection.UserToken).Socket.ReceiveAsync(connection);
                //    if (!willRaiseEvent)
                //    {
                //        ProcessReceive(connection);
                //    }
                //}
                //catch (ObjectDisposedException)
                //{
                //    RaiseDisconnectedEvent(connection);
                //}
                //catch (SocketException exception)
                //{
                //    if (exception.ErrorCode == (int)SocketError.ConnectionReset)//10054һ�����������ӱ�Զ������ǿ�йر�
                //    {
                //        RaiseDisconnectedEvent(connection);//�����Ͽ������¼�
                //    }
                //    else
                //    {
                //        RaiseErrorEvent(connection, exception);//�����Ͽ������¼�
                //    }
                //}
                //catch (Exception exception_debug)
                //{
                //    Debug.WriteLine("���ԣ�" + exception_debug.Message);
                //    throw exception_debug;
                //}
            }
            else
            {
                //lock (((ICollection)this.m_tokens).SyncRoot)
                //{
                //    if (!this.m_tokens.TryGetValue(token.ConnectionId, out token))
                //    {
                //        throw new AsyncSocketException(string.Format("�ͻ���:{0}�����Ѿ��رջ���δ����", token.ConnectionId), AsyncSocketErrorCode.ClientSocketNoExist);
                //        //return;
                //    }
                //}

                RaiseDisconnectedEvent(token);//�����Ͽ������¼�
            }
        }

        public void Disconnect(string connectionId)//�Ͽ�����(�β� ����ID)
        {
            AsyncUserToken token;

            lock (((ICollection)this.m_tokens).SyncRoot)
            {
                if (!this.m_tokens.TryGetValue(connectionId, out token))
                {
                    throw new AsyncSocketException(string.Format("�ͻ���:{0}�Ѿ��رջ���δ����", connectionId), AsyncSocketErrorCode.ClientSocketNoExist);

                    //return;//�����ڸ�ID�ͻ���
                }
            }

            RaiseDisconnectedEvent(token);//�׳��Ͽ������¼�
        }

        private void RaiseDisconnectedEvent(AsyncUserToken token)//�����Ͽ������¼�
        {
            if (null != token)
            {
                lock (((ICollection)this.m_tokens).SyncRoot)
                {
                    if (this.m_tokens.ContainsValue(token))
                    {
                        this.m_tokens.Remove(token.ConnectionId);
                        CloseClientSocket(token);
                        EventHandler<AsyncUserToken> handler = OnClientDisconnect;

                        // ��������¼���Ϊ��(null)
                        if ((handler != null) && (null != token))
                        {
                            handler(this, token);//�׳����ӶϿ��¼�
                        }
                    }
                }
            }
        }

        private void CloseClientSocket(AsyncUserToken token)
        {
            //AsyncUserToken token = e.UserToken as AsyncUserToken;

            // �ر�������Ŀͻ���
            try
            {
                token.Socket.Shutdown(SocketShutdown.Both);
                token.Socket.Close();
            }

            // �׳��ͻ������Ѿ����ر�
            catch (ObjectDisposedException)
            {
            }
            catch (SocketException)
            {
                token.Socket.Close();
            }
            catch (Exception exception_debug)
            {
                token.Socket.Close();
                Debug.WriteLine("����:" + exception_debug.Message);
                throw exception_debug;
            }
            finally
            {
                // �������ӵ��������ͻ��������ļ�������ֵ
                Interlocked.Decrement(ref m_numConnectedSockets);
                m_maxNumberAcceptedClients.Release();

                Debug.WriteLine(string.Format("һ���ͻ��˱��ӷ������Ͽ�. �� {0} ���ͻ������ӵ�������", m_numConnectedSockets.ToString()));
                lock (m_readPool)
                {
                    // �ͷ���ʹ���ǿ��Ա������ͻ�����������
                    m_readPool.Push(token.ReadEventArgs);
                }
            }
        }

        private void RaiseErrorEvent(AsyncUserToken token, AsyncSocketException exception)
        {
            EventHandler<AsyncSocketErrorEventArgs> handler = OnClientError;

            // ��������¼���Ϊ��(null)
            if (handler != null)
            {
                if (null != token)
                {
                    handler(token, new AsyncSocketErrorEventArgs(exception));//�׳��ͻ��˴����¼�
                }
                else
                {
                    handler(null, new AsyncSocketErrorEventArgs(exception));//�׳������������¼�
                }
            }
        }

        public void Shutdown()
        {
            this.listenSocket.Close();//ֹͣ����
            lock (((ICollection)this.m_tokens).SyncRoot)
            {
                foreach (AsyncUserToken token in this.m_tokens.Values)
                {
                    try
                    {
                        CloseClientSocket(token);

                        EventHandler<AsyncUserToken> handler = OnClientDisconnect;

                        // ��������¼���Ϊ��(null)
                        if ((handler != null) && (null != token))
                        {
                            handler(this, token);//�׳����ӶϿ��¼�
                        }
                    }

                    // ����ʱ��ע�͵���ʱ�ر�
                    //catch(Exception){ }

                    // ����ʱ�رյ���ʱ��
                    catch (Exception exception_debug)
                    {
                        Debug.WriteLine("����:" + exception_debug.Message);
                        throw exception_debug;
                    }
                }
                this.m_tokens.Clear();
            }
        }
    }
}