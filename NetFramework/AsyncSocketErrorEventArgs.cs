using System;

namespace NetFramework
{
    /// <summary>
    /// �첽Socket�����¼�������
    /// </summary>
    public class AsyncSocketErrorEventArgs : EventArgs
    {
        public AsyncSocketException exception;

        /// <summary>
        /// ʹ��SocketException�������й���
        /// </summary>
        /// <param name="e">SocketException</param>
        public AsyncSocketErrorEventArgs(AsyncSocketException exception)
        {
            this.exception = exception;
        }
    }
}