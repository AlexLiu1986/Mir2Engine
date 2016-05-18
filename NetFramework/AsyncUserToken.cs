using System;
using System.Net;
using System.Net.Sockets;

namespace NetFramework
{
    /// <summary>
    /// ����౻���������Ϊ�������SocketAsyncEventArgs.UserToken���Ե���.
    /// </summary>
    public class AsyncUserToken : EventArgs
    {
        private Socket m_socket;//Socket
        private string m_connectionId;//�ڲ�����ID
        private IPEndPoint m_endPoint;//�ս��
        private byte[] m_receiveBuffer;//������
        private int m_count;
        private int m_offset;//ƫ����
        private int m_bytesReceived;//�Ѿ����յ����ֽ���
        private SocketAsyncEventArgs m_readEventArgs;// SocketAsyncEventArgs������
        private object m_operation;

        public AsyncUserToken()
            : this(null)
        {
        }

        /// <summary>
        /// Ԥ���Ĳ�����־ ���ڷ���ĳЩ�������ݺ�ĳɹ�����(�����÷� ʹ���Զ���ö������ʾ����)
        /// </summary>
        public object Operation
        {
            set { m_operation = value; }
            get { return m_operation; }
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        public byte[] ReceiveBuffer
        {
            get { return m_receiveBuffer; }
        }

        /// <summary>
        /// ��ȡ��Ի�����ƫ����
        /// </summary>
        public int Offset
        {
            get { return m_offset; }
        }

        /// <summary>
        /// ��ȡ���������ֽ���
        /// </summary>
        public int BytesReceived
        {
            get { return m_bytesReceived; }
        }

        /// <summary>
        /// ��ȡ������SocketAsyncEventArgs������
        /// </summary>
        public SocketAsyncEventArgs ReadEventArgs
        {
            set { m_readEventArgs = value; }
            get { return m_readEventArgs; }
        }

        /// <summary>
        /// Я����Scoket������
        /// </summary>
        /// <param name="socket">Socket������</param>
        public AsyncUserToken(Socket socket)
        {
            m_readEventArgs = new SocketAsyncEventArgs();
            m_readEventArgs.UserToken = this;
            if (null != socket)
            {
                m_socket = socket;
                this.m_endPoint = (IPEndPoint)socket.RemoteEndPoint;
            }
        }

        /// <summary>
        /// ��ȡ������Я����Socket������
        /// </summary>
        public Socket Socket
        {
            get { return m_socket; }
            set
            {
                if (value != null)
                {
                    m_socket = value;
                    m_endPoint = (IPEndPoint)m_socket.RemoteEndPoint;
                }
            }
        }

        /// <summary>
        /// ��ȡ������ͨѶ��ʹ�õ�����ID��
        /// </summary>
        public string ConnectionId//�ڲ�����ID
        {
            get { return this.m_connectionId; }
            set { this.m_connectionId = value; }
        }

        /// <summary>
        /// ��ȡ�������ӵĶԶ˿ͻ����ս��
        /// </summary>
        public IPEndPoint EndPoint//�Զ��ս��
        {
            get { return this.m_endPoint; }
        }

        /// <summary>
        /// ������Ҫ֪ͨ�ⲿ����յ������ݻ�����λ��
        /// </summary>
        /// <param name="bytesReceived">���յ����ֽ���</param>
        public void SetBytesReceived(int bytesReceived)
        {
            m_bytesReceived = bytesReceived;
        }

        /// <summary>
        /// ������Ҫ֪ͨ�ⲿ����յ������ݻ�����λ��
        /// </summary>
        /// <param name="buffer">���յ������ݻ�����λ��</param>
        /// <param name="offset">����ڻ�������ƫ����</param>
        /// <param name="bytesReceived">���յ����ֽ���</param>
        public void SetBuffer(byte[] buffer, int offset, int count)
        {
            m_receiveBuffer = buffer;
            m_offset = offset;
            m_count = count;
            m_bytesReceived = 0;
        }
    }
}