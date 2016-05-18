using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace NetFramework
{
    /// <summary>
    /// ����һ�������õ�SocketAsyncEventArgs���󼯺�.
    /// </summary>
    internal class SocketAsyncEventArgsPool
    {
        private Stack<SocketAsyncEventArgs> m_pool;

        /// <summary>
        /// ��ָ���Ĵ�С��ʼ�������
        /// </summary>
        /// <param name="capacity">����ؿ��Թ�������SocketAsyncEventArgs��������</param>
        public SocketAsyncEventArgsPool(int capacity)
        {
            m_pool = new Stack<SocketAsyncEventArgs>(capacity);
        }

        /// <summary>
        /// ���һ��SocketAsyncEventArgs����ʵ��������
        /// </summary>
        /// <param name="item">Ҫ��ӵ������SocketAsyncEventArgs����ʵ��</param>
        public void Push(SocketAsyncEventArgs item)
        {
            if (item == null) { throw new ArgumentNullException("Ҫ����ӵ�SocketAsyncEventArgs�ص���Ŀ����Ϊ��(null)"); }
            lock (m_pool)
            {
                m_pool.Push(item);
            }
        }

        /// <summary>
        /// �ӳ���ɾ��һ��SocketAsyncEventArgs����ʵ��
        /// </summary>
        /// <returns>Ҫ���ӳ���ɾ���Ķ���</returns>
        public SocketAsyncEventArgs Pop()
        {
            lock (m_pool)
            {
                return m_pool.Pop();
            }
        }

        /// <summary>
        /// ����SocketAsyncEventArgs����ʵ��������
        /// </summary>
        public int Count
        {
            get { return m_pool.Count; }
        }
    }
}