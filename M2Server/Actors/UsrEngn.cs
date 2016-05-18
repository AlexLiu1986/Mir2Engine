using System.Collections.Generic;

namespace M2Server
{
    /// <summary>
    /// ˢ����
    /// </summary>
    public class TMonGenInfo
    {
        public string sMapName;// ��ͼ��
        public int nRace;
        public int nRange;// ��Χ
        public int nMissionGenRate;// ��������ˢ�»��� 1 -100
        public uint dwStartTick;// ˢ�ּ��
        public int nX;// X����
        public int nY;// Y����
        public string sMonName;// ������
        public int nAreaX;
        public int nAreaY;
        public int nCount;// ��������
        public uint dwZenTime;// ˢ��ʱ��
        public uint dwStartTime;// ����ʱ��
        public bool boIsNGMon;// �ڹ���,����������������ֵ
        public byte nNameColor;// �Զ������ֵ���ɫ
        public int nChangeColorType;// 0�Զ���ɫ >0�ı���ɫ -1���ı�
        public List<TBaseObject> CertList;
        public TEnvirnoment Envir;
        /// <summary>
        /// ��ǰˢ������
        /// </summary>
        public int nCurrMonGen;
    }

    public class TMapMonGenCount
    {
        public string sMapName;// ��ͼ����
        public int nMonGenCount;// ˢ������
        public uint dwNotHumTimeTick;// û��ҵļ��
        public int nClearCount;// �������
        public bool boNotHum;// �Ƿ������
        public uint dwMakeMonGenTimeTick;// ˢ�ֵļ��
        public int nMonGenRate;// ˢ�ֱ���  10
        public uint dwRegenMonstersTime;
    }

  
}