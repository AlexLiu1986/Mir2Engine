using GameFramework;

namespace M2Server
{
    public class TEvent
    {
        public int nVisibleFlag = 0;
        /// <summary>
        /// ���ڵ�ͼ����
        /// </summary>
        public TEnvirnoment m_Envir = null;
        /// <summary>
        ///  X����
        /// </summary>
        public int m_nX = 0;
        /// <summary>
        /// Y����
        /// </summary>
        public int m_nY = 0;
        /// <summary>
        /// ����
        /// </summary>
        public int m_nEventType = 0;
        public int m_nEventParam = 0;
        public uint m_dwOpenStartTick = 0;
        /// <summary>
        /// ��ʾʱ�䳤��
        /// </summary>
        public uint m_dwContinueTime = 0;
        /// <summary>
        /// �رռ��
        /// </summary>
        public uint m_dwCloseTick = 0;
        /// <summary>
        /// �Ƿ�ر�
        /// </summary>
        public bool m_boClosed = false;
        /// <summary>
        /// ��ǽ����
        /// </summary>
        public int m_nDamage = 0;
        public TBaseObject m_OwnBaseObject = null;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public uint m_dwRunStart = 0;
        /// <summary>
        /// ���м��
        /// </summary>
        public uint m_dwRunTick = 0;
        /// <summary>
        /// �Ƿ�ɼ�
        /// </summary>
        public bool m_boVisible = false;
        /// <summary>
        /// �Ƿ񼤻�
        /// </summary>
        public bool m_boActive = false;

        public TEvent(TEnvirnoment tEnvir, int nTX, int nTY, int nType, uint dwETime, bool boVisible)
        {
            m_dwOpenStartTick = HUtil32.GetTickCount();
            m_nEventType = nType;
            m_nEventParam = 0;
            m_dwContinueTime = dwETime;
            m_boVisible = boVisible;
            m_boClosed = false;
            m_Envir = tEnvir;
            m_nX = nTX;
            m_nY = nTY;
            m_boActive = true;
            m_nDamage = 0;
            m_OwnBaseObject = null;
            m_dwRunStart = HUtil32.GetTickCount();
            m_dwRunTick = 500;
            if ((m_Envir != null) && m_boVisible)
            {
                m_Envir.AddToMap(m_nX, m_nY, Grobal2.OS_EVENTOBJECT, this);
            }
            else
            {
                m_boVisible = false;
            }
        }

        ~TEvent()
        {
            m_boClosed = true;
        }

        public virtual void Run()
        {
            if ((HUtil32.GetTickCount() - m_dwOpenStartTick) > m_dwContinueTime)
            {
                m_boClosed = true;
                Close();
            }
            if (!m_boClosed && (m_OwnBaseObject != null) && (m_OwnBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_nEventType == Grobal2.ET_FIRE) && M2Share.g_Config.boChangeMapFireExtinguish && !m_OwnBaseObject.m_boSuperMan)
            {
                if ((m_OwnBaseObject.m_PEnvir != m_Envir) || (m_OwnBaseObject.m_PEnvir.sMapName != m_Envir.sMapName))//��ǽ����ͼ��ʧ
                {
                    m_OwnBaseObject = null;
                    m_boClosed = true;
                    Close();
                    return;
                }
            }
            if ((m_OwnBaseObject != null) && (m_OwnBaseObject.m_boGhost || (m_OwnBaseObject.m_boDeath)))
            {
                m_OwnBaseObject = null;
            }
        }

        public void Close()
        {
            m_dwCloseTick = HUtil32.GetTickCount();
            if (m_boVisible)
            {
                m_boVisible = false;
                if (m_Envir != null)
                {
                    m_Envir.DeleteFromMap(m_nX, m_nY, Grobal2.OS_EVENTOBJECT, this);
                }
                m_Envir = null;
            }
        }
    }




}
