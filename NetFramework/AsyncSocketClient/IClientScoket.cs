using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace NetFramework.AsyncSocketClient
{
    public class IClientScoket
    {
        private int buffersize = 0x10000;//��������С
        private Socket cli = null;//�ͻ���Socket
        private byte[] databuffer;//������
        public bool IsConnected;//�����Ƿ�ɹ�
        public string Address = string.Empty;
        public int Port = 0;

        public event DSCClientOnConnectedHandler OnConnected;//���ӳɹ��¼�

        public event DSCClientOnErrorHandler OnError;//�����¼�

        public event DSCClientOnDataInHandler ReceivedDatagram;//���յ������¼�

        public event DSCClientOnDisconnectedHandler OnDisconnected;//�Ͽ������¼�

        public IClientScoket()
        {
            this.databuffer = new byte[this.buffersize];//����������
        }

        public void Connect(string ip, int port)//���ӵ��ս��
        {
            this.cli = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
            try
            {
                this.cli.BeginConnect(remoteEP, new AsyncCallback(this.HandleConnect), this.cli);//��ʼ�첽����
            }
            catch (ObjectDisposedException)
            {
                RaiseDisconnectedEvent();
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    this.RaiseDisconnectedEvent();//�����Ͽ������¼�
                }
                this.RaiseErrorEvent(exception);//���������¼�
            }
        }

        private void HandleConnect(IAsyncResult iar)
        {
            Socket asyncState = (Socket)iar.AsyncState;
            try
            {
                asyncState.EndConnect(iar);//�����첽����
                if (null != this.OnConnected)
                {
                    this.OnConnected(this, new DSCClientConnectedEventArgs(this.cli));//�������ӳɹ��¼�
                    IsConnected = true;
                }
                this.StartWaitingForData(asyncState);//��ʼ��������
            }
            catch (ObjectDisposedException)
            {
                RaiseDisconnectedEvent();
                IsConnected = false;
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    this.RaiseDisconnectedEvent();//�����Ͽ������¼�
                }
                this.RaiseErrorEvent(exception);//���������¼�
            }
        }

        private void StartWaitingForData(Socket soc)
        {
            try
            {
                //��ʼ�첽��������
                soc.BeginReceive(this.databuffer, 0, this.buffersize, SocketFlags.None, new AsyncCallback(this.HandleIncomingData), soc);
            }
            catch (ObjectDisposedException)
            {
                RaiseDisconnectedEvent();
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    this.RaiseDisconnectedEvent();//�����Ͽ������¼�
                }
                this.RaiseErrorEvent(exception);//���������¼�
            }
        }

        private void HandleIncomingData(IAsyncResult parameter)
        {
            Socket asyncState = (Socket)parameter.AsyncState;
            try
            {
                int length = asyncState.EndReceive(parameter);//�����첽��������
                if (0 == length)
                {
                    this.RaiseDisconnectedEvent();//�����Ͽ������¼�
                }
                else
                {
                    byte[] destinationArray = new byte[length];//Ŀ���ֽ�����
                    Array.Copy(this.databuffer, 0, destinationArray, 0, length);
                    if (null != this.ReceivedDatagram)
                    {
                        //�������������¼�
                        this.ReceivedDatagram(this, new DSCClientDataInEventArgs(this.cli, destinationArray));
                    }
                    this.StartWaitingForData(asyncState);//������������
                }
            }
            catch (ObjectDisposedException)
            {
                this.RaiseDisconnectedEvent();//�����Ͽ������¼�
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    this.RaiseDisconnectedEvent();//�����Ͽ������¼�
                }
                this.RaiseErrorEvent(exception);//���������¼�
            }
        }

        public void Send(byte[] buffer)
        {
            try
            {
                //��ʼ�첽��������
                this.cli.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.HandleSendFinished), this.cli);
            }
            catch (ObjectDisposedException)
            {
                this.RaiseDisconnectedEvent();//�����Ͽ������¼�
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    this.RaiseDisconnectedEvent();//�����Ͽ������¼�
                }
                this.RaiseErrorEvent(exception);//���������¼�
            }
        }

        private void HandleSendFinished(IAsyncResult parameter)
        {
            try
            {
                ((Socket)parameter.AsyncState).EndSend(parameter);//�����첽��������
            }
            catch (ObjectDisposedException)
            {
                this.RaiseDisconnectedEvent();
            }
            catch (SocketException exception)
            {
                if (exception.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    this.RaiseDisconnectedEvent();//�����Ͽ������¼�
                }
                this.RaiseErrorEvent(exception);
            }
            catch (Exception exception_debug)
            {
                Debug.WriteLine("���ԣ�" + exception_debug.Message);
            }
        }

        private void RaiseDisconnectedEvent()
        {
            if (null != this.OnDisconnected)
            {
                this.OnDisconnected(this, new DSCClientConnectedEventArgs(this.cli));
            }
        }

        private void RaiseErrorEvent(SocketException error)
        {
            if (null != this.OnError)
            {
                this.OnError(this.cli.RemoteEndPoint, new DSCClientErrorEventArgs(error));
            }
        }

        public void Disconnect()
        {
            try
            {
                this.cli.Shutdown(SocketShutdown.Both);
                this.cli.Close();
            }
            catch (Exception) { }
        }
    }
}