using GameFramework;
using M2Server.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public class TDefenseUnit
    {
        public int nMainDoorX;
        public int nMainDoorY;
        public string sMainDoorName;
        public bool boXXX;
        public ushort wMainDoorHP;
        public TBaseObject MainDoor;
        public TBaseObject LeftWall;
        public TBaseObject CenterWall;
        public TBaseObject RightWall;
        public TBaseObject Archer;
    }

    public class TObjUnit
    {
        public int nX;
        public int nY;
        public string sName;
        public bool nStatus;
        public int nHP;
        public TBaseObject BaseObject;
    }

    public class TAttackerInfo
    {
        public DateTime AttackDate;
        public string sGuildName;
        public TGUild Guild;
    }

    public class Castle
    {
        public const int MAXCASTLEARCHER = 12;
        public const int MAXCALSTEGUARD = 4;
    }

    public class TUserCastle : GameBase
    {
        public int nTechLevel
        {
            get
            {
                return m_nTechLevel;
            }
            set
            {
                SetTechLevel(value);
            }
        }
        public int nPower
        {
            get
            {
                return m_nPower;
            }
            set
            {
                SetPower(value);
            }
        }
        /// <summary>
        /// �Ǳ����ڵ�ͼ
        /// </summary>
        public TEnvirnoment m_MapCastle = null;
        /// <summary>
        /// �ʹ����ڵ�ͼ
        /// </summary>
        public TEnvirnoment m_MapPalace = null;
        /// <summary>
        /// �ܵ����ڵ�ͼ
        /// </summary>
        public TEnvirnoment m_MapSecret = null;
        /// <summary>
        /// �ʹ���״̬
        /// </summary>
        public TDoorStatus m_DoorStatus = null;
        /// <summary>
        /// �Ǳ����ڵ�ͼ��
        /// </summary>
        public string m_sMapName = String.Empty;
        /// <summary>
        /// �Ǳ�����
        /// </summary>
        public string m_sName = String.Empty;
        /// <summary>
        /// �����л�����
        /// </summary>
        public string m_sOwnGuild = String.Empty;
        /// <summary>
        /// �����л�
        /// </summary>
        public TGUild m_MasterGuild = null;
        /// <summary>
        /// �л�سǵ��ͼ
        /// </summary>
        public string m_sHomeMap = String.Empty;
        /// <summary>
        /// �л�سǵ�X
        /// </summary>
        public int m_nHomeX = 0;
        /// <summary>
        /// �л�سǵ�Y
        /// </summary>
        public int m_nHomeY = 0;
        /// <summary>
        /// �ı�����
        /// </summary>
        public DateTime m_ChangeDate;
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime m_WarDate;
        /// <summary>
        /// �Ƿ�ʼ����
        /// </summary>
        public bool m_boStartWar = false;
        /// <summary>
        /// �Ƿ����ڹ���
        /// </summary>
        public bool m_boUnderWar = false;
        /// <summary>
        /// �Ƿ�����ʾ���ǽ�����Ϣ
        /// </summary>
        public bool m_boShowOverMsg = false;
        // 
        public uint m_dwStartCastleWarTick = 0;
        /// <summary>
        /// ������
        /// </summary>
        public uint m_dwSaveTick = 0;
        /// <summary>
        /// �����б�
        /// </summary>
        public IList<TAttackerInfo> m_AttackWarList = null;
        /// <summary>
        /// �����л��б�
        /// </summary>
        public List<TGUild> m_AttackGuildList = null;
        /// <summary>
        /// ����
        /// </summary>
        public TObjUnit m_MainDoor = new TObjUnit();
        /// <summary>
        /// �ʹ���
        /// </summary>
        public TObjUnit m_LeftWall = new TObjUnit();
        /// <summary>
        /// �ʹ���
        /// </summary>
        public TObjUnit m_CenterWall = new TObjUnit();
        /// <summary>
        /// �ʹ���
        /// </summary>
        public TObjUnit m_RightWall = new TObjUnit();
        // 
        public TObjUnit[] m_Guard = new TObjUnit[4];
        // 0xB4
        public TObjUnit[] m_Archer = new TObjUnit[4];
        // 0x114 0x264
        public DateTime m_IncomeToday;
        // 0x238
        public int m_nTotalGold = 0;
        // 0x240
        public int m_nTodayIncome = 0;
        // 0x244
        public int m_nWarRangeX = 0;
        // ��������ΧX
        public int m_nWarRangeY = 0;
        // ��������ΧY
        public string m_sPalaceMap = String.Empty;
        // �ʹ����ڵ�ͼ
        public string m_sSecretMap = String.Empty;
        // �ܵ����ڵ�ͼ
        public int m_nPalaceDoorX = 0;
        // �ʹ�����X
        public int m_nPalaceDoorY = 0;
        // �ʹ�����Y
        public string m_sConfigDir = String.Empty;
        public List<string> m_EnvirList = null;
        public int m_nTechLevel = 0;// �Ƽ��ȼ�
        public int m_nPower = 0;

        public TUserCastle(string sCastleDir)
        {
            m_MasterGuild = null;// '3'
            m_sHomeMap = M2Share.g_Config.sCastleHomeMap;// 644
            m_nHomeX = M2Share.g_Config.nCastleHomeX;// 290
            m_nHomeY = M2Share.g_Config.nCastleHomeY;// 'ɳ�Ϳ�'
            m_sName = M2Share.g_Config.sCASTLENAME;
            m_sConfigDir = sCastleDir;
            m_sPalaceMap = "0150";
            m_sSecretMap = "D701";
            m_MapCastle = null;
            m_DoorStatus = null;
            m_boStartWar = false;
            m_boUnderWar = false;
            m_boShowOverMsg = false;
            m_AttackWarList = new List<TAttackerInfo>();
            m_AttackGuildList = new List<TGUild>();
            m_dwSaveTick = 0;
            m_nWarRangeX = M2Share.g_Config.nCastleWarRangeX;
            m_nWarRangeY = M2Share.g_Config.nCastleWarRangeY;
            m_EnvirList = new List<string>();
        }

        ~TUserCastle()
        {
            if (m_AttackWarList.Count > 0)
            {
                for (int I = 0; I < m_AttackWarList.Count; I++)
                {
                    if (m_AttackWarList[I] != null)
                    {
                        Dispose(m_AttackWarList[I]);
                    }
                }
            }
        }

        public void Initialize()
        {
            TObjUnit ObjUnit;
            TDoorInfo Door;
            LoadConfig(false);
            LoadAttackSabukWall();
            if (M2Share.g_MapManager.GetMapOfServerIndex(m_sMapName) == M2Share.nServerIndex)
            {
                m_MapPalace = M2Share.g_MapManager.FindMap(m_sPalaceMap);
                if (m_MapPalace == null)
                {
                    M2Share.MainOutMessage(string.Format("�ʹ���ͼ{0}û�ҵ�������", m_sPalaceMap));
                }
                m_MapSecret = M2Share.g_MapManager.FindMap(m_sSecretMap);
                if (m_MapSecret == null)
                {
                    M2Share.MainOutMessage(string.Format("�ܵ���ͼ{0}û�ҵ�������", m_sSecretMap));
                }
                m_MapCastle = M2Share.g_MapManager.FindMap(m_sMapName);
                if (m_MapCastle != null)
                {
                    m_MainDoor.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_MainDoor.nX, m_MainDoor.nY, m_MainDoor.sName);
                    if (m_MainDoor.BaseObject != null)
                    {
                        m_MainDoor.BaseObject.m_WAbil.HP = m_MainDoor.nHP;
                        m_MainDoor.BaseObject.m_Castle = this;
                        if (m_MainDoor.nStatus)
                        {
                            ((TCastleDoor)(m_MainDoor.BaseObject)).Open();
                        }
                    }
                    else
                    {
                        M2Share.MainOutMessage("[������Ϣ] �Ǳ���ʼ������ʧ�ܣ����������ݿ�����û���ŵ�����: " + m_MainDoor.sName);
                    }
                    m_LeftWall.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_LeftWall.nX, m_LeftWall.nY, m_LeftWall.sName);
                    if (m_LeftWall.BaseObject != null)
                    {
                        m_LeftWall.BaseObject.m_WAbil.HP = m_LeftWall.nHP;
                        m_LeftWall.BaseObject.m_Castle = this;
                    }
                    else
                    {
                        M2Share.MainOutMessage("[������Ϣ] �Ǳ���ʼ�����ǽʧ�ܣ����������ݿ�����û���ǽ������: " + m_LeftWall.sName);
                    }
                    m_CenterWall.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_CenterWall.nX, m_CenterWall.nY, m_CenterWall.sName);
                    if (m_CenterWall.BaseObject != null)
                    {
                        m_CenterWall.BaseObject.m_WAbil.HP = m_CenterWall.nHP;
                        m_CenterWall.BaseObject.m_Castle = this;
                    }
                    else
                    {
                        M2Share.MainOutMessage("[������Ϣ] �Ǳ���ʼ���г�ǽʧ�ܣ����������ݿ�����û�г�ǽ������: " + m_CenterWall.sName);
                    }
                    m_RightWall.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_RightWall.nX, m_RightWall.nY, m_RightWall.sName);
                    if (m_RightWall.BaseObject != null)
                    {
                        m_RightWall.BaseObject.m_WAbil.HP = m_RightWall.nHP;
                        m_RightWall.BaseObject.m_Castle = this;
                    }
                    else
                    {
                        M2Share.MainOutMessage("[������Ϣ] �Ǳ���ʼ���ҳ�ǽʧ�ܣ����������ݿ�����û�ҳ�ǽ������: " + m_RightWall.sName);
                    }
                    for (int I = m_Archer.GetLowerBound(0); I <= m_Archer.GetUpperBound(0); I++)
                    {
                        ObjUnit = m_Archer[I];
                        if (ObjUnit != null)
                        {
                            if (ObjUnit.nHP <= 0)
                            {
                                continue;
                            }
                            ObjUnit.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, ObjUnit.nX, ObjUnit.nY, ObjUnit.sName);
                            if (ObjUnit.BaseObject != null)
                            {
                                ObjUnit.BaseObject.m_WAbil.HP = m_Archer[I].nHP;
                                ObjUnit.BaseObject.m_Castle = this;
                                ((TGuardUnit)(ObjUnit.BaseObject)).m_nX550 = ObjUnit.nX;
                                ((TGuardUnit)(ObjUnit.BaseObject)).m_nY554 = ObjUnit.nY;
                                ((TGuardUnit)(ObjUnit.BaseObject)).m_nDirection = 3;
                            }
                            else
                            {
                                M2Share.MainOutMessage("[������Ϣ] �Ǳ���ʼ��������ʧ�ܣ����������ݿ�����û�����ֵ�����: " + ObjUnit.sName);
                            }
                        }
                    }
                    for (int I = m_Guard.GetLowerBound(0); I <= m_Guard.GetUpperBound(0); I++)
                    {
                        ObjUnit = m_Guard[I];
                        if (ObjUnit != null)
                        {
                            if (ObjUnit.nHP <= 0)
                            {
                                continue;
                            }
                            ObjUnit.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, ObjUnit.nX, ObjUnit.nY, ObjUnit.sName);
                            if (ObjUnit.BaseObject != null)
                            {
                                ObjUnit.BaseObject.m_WAbil.HP = m_Guard[I].nHP;
                            }
                            else
                            {
                                M2Share.MainOutMessage("[������Ϣ] �Ǳ���ʼ������ʧ��(���������ݿ�����û��������)");
                            }
                        }
                    }
                    if (m_MapCastle.m_DoorList.Count > 0)
                    {
                        for (int I = 0; I < m_MapCastle.m_DoorList.Count; I++)
                        {
                            Door = m_MapCastle.m_DoorList[I];
                            if ((Math.Abs(Door.nX - m_nPalaceDoorX) <= 3) && (Math.Abs(Door.nY - m_nPalaceDoorY) <= 3))
                            {
                                m_DoorStatus = Door.Status;
                            }
                        }
                    }
                }
                else
                {
                    M2Share.MainOutMessage(string.Format("[������Ϣ] �Ǳ����ڵ�ͼ������(����ͼ�����ļ����Ƿ��е�ͼ%s������)", m_sMapName));
                }
            }
        }

        /// <summary>
        /// ��ȡɳ�Ϳ������ļ�
        /// </summary>
        /// <param name="IsReLoad"></param>
        public void LoadConfig(bool IsReLoad)
        {
            string sFileName;
            string sConfigFile;
            IniFile CastleConf;
            TObjUnit ObjUnit;
            string sMapList;
            string sMAP = string.Empty;
            if (!Directory.Exists(M2Share.g_Config.sCastleDir + m_sConfigDir))
            {
                Directory.CreateDirectory(M2Share.g_Config.sCastleDir + m_sConfigDir);
            }
            sConfigFile = "SabukW.txt";
            sFileName = M2Share.g_Config.sCastleDir + m_sConfigDir + "\\" + sConfigFile;
            CastleConf = new IniFile(sFileName);
            if (CastleConf != null)
            {
                m_sName = CastleConf.ReadString("Setup", "CastleName", m_sName);
                m_sOwnGuild = CastleConf.ReadString("Setup", "OwnGuild", "");
                m_ChangeDate = CastleConf.ReadDateTime("Setup", "ChangeDate", DateTime.Now);
                m_WarDate = CastleConf.ReadDateTime("Setup", "WarDate", DateTime.Now);
                m_IncomeToday = CastleConf.ReadDateTime("Setup", "IncomeToday", DateTime.Now);
                m_nTotalGold = CastleConf.ReadInteger("Setup", "TotalGold", 0);
                m_nTodayIncome = CastleConf.ReadInteger("Setup", "TodayIncome", 0);
                sMapList = CastleConf.ReadString("Defense", "CastleMapList", "");
                if (sMapList != "")
                {
                    if (IsReLoad)
                    {
                        m_EnvirList.Clear(); // ��������أ�������б����ݣ��Է�ֹ�ظ�
                    }
                    while ((sMapList != ""))
                    {
                        sMapList = HUtil32.GetValidStr3(sMapList, ref sMAP, new string[] { "," });
                        if (sMAP == "")
                        {
                            break;
                        }
                        m_EnvirList.Add(sMAP);
                    }
                }
                if (m_EnvirList.Count > 0)
                {
                    for (int I = 0; I < m_EnvirList.Count; I++)
                    {
                        m_EnvirList[I] = M2Share.g_MapManager.FindMap(m_EnvirList[I]) == null ? ""
                            : M2Share.g_MapManager.FindMap(m_EnvirList[I]).sMapName;
                    }
                }
                m_sMapName = CastleConf.ReadString("Defense", "CastleMap", "3");
                m_sHomeMap = CastleConf.ReadString("Defense", "CastleHomeMap", m_sHomeMap);
                m_nHomeX = CastleConf.ReadInteger("Defense", "CastleHomeX", m_nHomeX);
                m_nHomeY = CastleConf.ReadInteger("Defense", "CastleHomeY", m_nHomeY);
                m_nWarRangeX = CastleConf.ReadInteger("Defense", "CastleWarRangeX", m_nWarRangeX);
                m_nWarRangeY = CastleConf.ReadInteger("Defense", "CastleWarRangeY", m_nWarRangeY);
                m_sPalaceMap = CastleConf.ReadString("Defense", "CastlePlaceMap", m_sPalaceMap);
                m_sSecretMap = CastleConf.ReadString("Defense", "CastleSecretMap", m_sSecretMap);
                m_nPalaceDoorX = CastleConf.ReadInteger("Defense", "CastlePalaceDoorX", 631);
                m_nPalaceDoorY = CastleConf.ReadInteger("Defense", "CastlePalaceDoorY", 274);
                m_MainDoor.nX = CastleConf.ReadInteger("Defense", "MainDoorX", 672);
                m_MainDoor.nY = CastleConf.ReadInteger("Defense", "MainDoorY", 330);
                m_MainDoor.sName = CastleConf.ReadString("Defense", "MainDoorName", "����");
                m_MainDoor.nStatus = CastleConf.ReadBool("Defense", "MainDoorOpen", true);
                m_MainDoor.nHP = CastleConf.ReadInteger("Defense", "MainDoorHP", 2000);
                if (m_MainDoor.nHP <= 0)
                {
                    if (m_MainDoor.BaseObject != null)
                    {
                        m_MainDoor.BaseObject.m_boGhost = true;
                        m_MainDoor.BaseObject.DisappearA();
                    }
                    m_MainDoor.nHP = 2000;
                }
                if (!IsReLoad)
                {
                    m_MainDoor.BaseObject = null;
                }
                m_LeftWall.nX = CastleConf.ReadInteger("Defense", "LeftWallX", 624);
                m_LeftWall.nY = CastleConf.ReadInteger("Defense", "LeftWallY", 278);
                m_LeftWall.sName = CastleConf.ReadString("Defense", "LeftWallName", "���ǽ");
                m_LeftWall.nHP = CastleConf.ReadInteger("Defense", "LeftWallHP", 2000);
                if (m_LeftWall.nHP <= 0)
                {
                    if (m_LeftWall.BaseObject != null)
                    {
                        m_LeftWall.BaseObject.m_boGhost = true;
                        m_LeftWall.BaseObject.DisappearA();
                    }
                    m_LeftWall.nHP = 2000;
                }
                if (!IsReLoad)
                {
                    m_LeftWall.BaseObject = null;
                }
                m_CenterWall.nX = CastleConf.ReadInteger("Defense", "CenterWallX", 627);
                m_CenterWall.nY = CastleConf.ReadInteger("Defense", "CenterWallY", 278);
                m_CenterWall.sName = CastleConf.ReadString("Defense", "CenterWallName", "�г�ǽ");
                m_CenterWall.nHP = CastleConf.ReadInteger("Defense", "CenterWallHP", 2000);
                if (m_LeftWall.nHP <= 0)
                {
                    if (m_CenterWall.BaseObject != null)
                    {
                        m_CenterWall.BaseObject.m_boGhost = true;
                        m_CenterWall.BaseObject.DisappearA();
                    }
                    m_CenterWall.nHP = 2000;
                }
                if (!IsReLoad)
                {
                    m_CenterWall.BaseObject = null;
                }
                m_RightWall.nX = CastleConf.ReadInteger("Defense", "RightWallX", 634);
                m_RightWall.nY = CastleConf.ReadInteger("Defense", "RightWallY", 271);
                m_RightWall.sName = CastleConf.ReadString("Defense", "RightWallName", "�ҳ�ǽ");
                m_RightWall.nHP = CastleConf.ReadInteger("Defense", "RightWallHP", 2000);
                if (m_RightWall.nHP <= 0)
                {
                    if (m_RightWall.BaseObject != null)
                    {
                        m_RightWall.BaseObject.m_boGhost = true;
                        m_RightWall.BaseObject.DisappearA();
                    }
                    m_RightWall.nHP = 2000;
                }
                if (!IsReLoad)
                {
                    m_RightWall.BaseObject = null;
                }
                for (int I = m_Archer.GetLowerBound(0); I <= m_Archer.GetUpperBound(0); I++)
                {
                    ObjUnit = m_Archer[I];
                    if (ObjUnit != null)
                    {
                        ObjUnit.nX = CastleConf.ReadInteger("Defense", "Archer_" + (I + 1).ToString() + "_X", 0);
                        ObjUnit.nY = CastleConf.ReadInteger("Defense", "Archer_" + (I + 1).ToString() + "_Y", 0);
                        ObjUnit.sName = CastleConf.ReadString("Defense", "Archer_" + (I + 1).ToString() + "_Name", "������");
                        ObjUnit.nHP = CastleConf.ReadInteger("Defense", "Archer_" + (I + 1).ToString() + "_HP", 2000);
                        if (!IsReLoad)
                        {
                            ObjUnit.BaseObject = null;
                        }
                    }
                }
                for (int I = m_Guard.GetLowerBound(0); I <= m_Guard.GetUpperBound(0); I++)
                {
                    ObjUnit = m_Guard[I];
                    if (ObjUnit != null)
                    {
                        ObjUnit.nX = CastleConf.ReadInteger("Defense", "Guard_" + (I + 1).ToString() + "_X", 0);
                        ObjUnit.nY = CastleConf.ReadInteger("Defense", "Guard_" + (I + 1).ToString() + "_Y", 0);
                        ObjUnit.sName = CastleConf.ReadString("Defense", "Guard_" + (I + 1).ToString() + "_Name", "����");
                        ObjUnit.nHP = CastleConf.ReadInteger("Defense", "Guard_" + (I + 1).ToString() + "_HP", 2000);
                        if (!IsReLoad)
                        {
                            ObjUnit.BaseObject = null;
                        }
                    }
                }
            }
            m_MasterGuild = GuildManager.FindGuild(m_sOwnGuild);
        }


        /// <summary>
        /// ����ɳ�Ϳ������ļ�
        /// </summary>
        private void SaveConfigFile()
        {
            IniFile CastleConf;
            TObjUnit ObjUnit;
            string sFileName;
            string sConfigFile;
            string sMapList = string.Empty;
            byte nCode;
            nCode = 0;
            try
            {
                if (!Directory.Exists(M2Share.g_Config.sCastleDir + m_sConfigDir))
                {
                    Directory.CreateDirectory(M2Share.g_Config.sCastleDir + m_sConfigDir);
                }
                nCode = 1;
                if (M2Share.g_MapManager.GetMapOfServerIndex(m_sMapName) != M2Share.nServerIndex)
                {
                    return;
                }
                sConfigFile = "SabukW.txt";
                sFileName = M2Share.g_Config.sCastleDir + m_sConfigDir + "\\" + sConfigFile;
                CastleConf = new IniFile(sFileName);
                nCode = 2;
                if (CastleConf != null)
                {
                    if (m_sName != "")
                    {
                        CastleConf.WriteString("Setup", "CastleName", m_sName);
                    }
                    if (m_sOwnGuild != "")
                    {
                        CastleConf.WriteString("Setup", "OwnGuild", m_sOwnGuild);
                    }
                    nCode = 3;
                    CastleConf.WriteDateTime("Setup", "ChangeDate", m_ChangeDate);
                    CastleConf.WriteDateTime("Setup", "WarDate", m_WarDate);
                    CastleConf.WriteDateTime("Setup", "IncomeToday", m_IncomeToday);
                    if (m_nTotalGold != 0)
                    {
                        CastleConf.WriteInteger("Setup", "TotalGold", m_nTotalGold);
                    }
                    if (m_nTodayIncome != 0)
                    {
                        CastleConf.WriteInteger("Setup", "TodayIncome", m_nTodayIncome);
                    }
                    if (m_EnvirList.Count > 0)
                    {
                        nCode = 4;
                        for (int I = 0; I < m_EnvirList.Count; I++)
                        {
                            sMapList = sMapList + m_EnvirList[I] + ",";
                        }
                    }
                    if (sMapList != "")
                    {
                        CastleConf.WriteString("Defense", "CastleMapList", sMapList);
                    }
                    if (m_sMapName != "")
                    {
                        CastleConf.WriteString("Defense", "CastleMap", m_sMapName);
                    }
                    if (m_sHomeMap != "")
                    {
                        CastleConf.WriteString("Defense", "CastleHomeMap", m_sHomeMap);
                    }
                    if (m_nHomeX != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CastleHomeX", m_nHomeX);
                    }
                    if (m_nHomeY != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CastleHomeY", m_nHomeY);
                    }
                    if (m_nWarRangeX != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CastleWarRangeX", m_nWarRangeX);
                    }
                    if (m_nWarRangeY != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CastleWarRangeY", m_nWarRangeY);
                    }
                    if (m_sPalaceMap != "")
                    {
                        CastleConf.WriteString("Defense", "CastlePlaceMap", m_sPalaceMap);
                    }
                    if (m_sSecretMap != "")
                    {
                        CastleConf.WriteString("Defense", "CastleSecretMap", m_sSecretMap);
                    }
                    if (m_nPalaceDoorX != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CastlePalaceDoorX", m_nPalaceDoorX);
                    }
                    if (m_nPalaceDoorY != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CastlePalaceDoorY", m_nPalaceDoorY);
                    }
                    if (m_MainDoor.nX != 0)
                    {
                        CastleConf.WriteInteger("Defense", "MainDoorX", m_MainDoor.nX);
                    }
                    if (m_MainDoor.nY != 0)
                    {
                        CastleConf.WriteInteger("Defense", "MainDoorY", m_MainDoor.nY);
                    }
                    if (m_MainDoor.sName != "")
                    {
                        CastleConf.WriteString("Defense", "MainDoorName", m_MainDoor.sName);
                    }
                    nCode = 5;
                    if (m_MainDoor.BaseObject != null)
                    {
                        nCode = 6;
                        CastleConf.WriteBool("Defense", "MainDoorOpen", m_MainDoor.nStatus);
                        CastleConf.WriteInteger("Defense", "MainDoorHP", m_MainDoor.BaseObject.m_WAbil.HP);
                    }
                    if (m_LeftWall.nX != 0)
                    {
                        CastleConf.WriteInteger("Defense", "LeftWallX", m_LeftWall.nX);
                    }
                    if (m_LeftWall.nY != 0)
                    {
                        CastleConf.WriteInteger("Defense", "LeftWallY", m_LeftWall.nY);
                    }
                    if (m_LeftWall.sName != "")
                    {
                        CastleConf.WriteString("Defense", "LeftWallName", m_LeftWall.sName);
                    }
                    nCode = 7;
                    if (m_LeftWall.BaseObject != null)
                    {
                        CastleConf.WriteInteger("Defense", "LeftWallHP", m_LeftWall.BaseObject.m_WAbil.HP);
                    }
                    nCode = 8;
                    if (m_CenterWall.nX != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CenterWallX", m_CenterWall.nX);
                    }
                    if (m_CenterWall.nY != 0)
                    {
                        CastleConf.WriteInteger("Defense", "CenterWallY", m_CenterWall.nY);
                    }
                    if (m_CenterWall.sName != "")
                    {
                        CastleConf.WriteString("Defense", "CenterWallName", m_CenterWall.sName);
                    }
                    nCode = 9;
                    if (m_CenterWall.BaseObject != null)
                    {
                        CastleConf.WriteInteger("Defense", "CenterWallHP", m_CenterWall.BaseObject.m_WAbil.HP);
                    }
                    nCode = 10;
                    if (m_RightWall.nX != 0)
                    {
                        CastleConf.WriteInteger("Defense", "RightWallX", m_RightWall.nX);
                    }
                    if (m_RightWall.nY != 0)
                    {
                        CastleConf.WriteInteger("Defense", "RightWallY", m_RightWall.nY);
                    }
                    if (m_RightWall.sName != "")
                    {
                        CastleConf.WriteString("Defense", "RightWallName", m_RightWall.sName);
                    }
                    nCode = 11;
                    if (m_RightWall.BaseObject != null)
                    {
                        CastleConf.WriteInteger("Defense", "RightWallHP", m_RightWall.BaseObject.m_WAbil.HP);
                    }
                    nCode = 12;
                    for (int I = m_Archer.GetLowerBound(0); I <= m_Archer.GetUpperBound(0); I++)
                    {
                        ObjUnit = m_Archer[I];
                        if (ObjUnit != null)
                        {
                            nCode = 13;
                            if (ObjUnit.nX != 0)
                            {
                                CastleConf.WriteInteger("Defense", "Archer_" + I + 1 + "_X", ObjUnit.nX);
                            }
                            if (ObjUnit.nY != 0)
                            {
                                CastleConf.WriteInteger("Defense", "Archer_" + I + 1 + "_Y", ObjUnit.nY);
                            }
                            if (ObjUnit.sName != "")
                            {
                                CastleConf.WriteString("Defense", "Archer_" + I + 1 + "_Name", ObjUnit.sName);
                            }
                            nCode = 14;
                            if (ObjUnit.BaseObject != null)
                            {
                                CastleConf.WriteInteger("Defense", "Archer_" + I + 1 + "_HP", ObjUnit.BaseObject.m_WAbil.HP);
                            }
                            else
                            {
                                CastleConf.WriteInteger("Defense", "Archer_" + I + 1 + "_HP", 0);
                            }
                        }
                    }
                    nCode = 15;
                    for (int I = m_Guard.GetLowerBound(0); I <= m_Guard.GetUpperBound(0); I++)
                    {
                        ObjUnit = m_Guard[I];
                        nCode = 16;
                        if (ObjUnit != null)
                        {
                            if (ObjUnit.nX != 0)
                            {
                                CastleConf.WriteInteger("Defense", "Guard_" + I + 1 + "_X", ObjUnit.nX);
                            }
                            if (ObjUnit.nY != 0)
                            {
                                CastleConf.WriteInteger("Defense", "Guard_" + I + 1 + "_Y", ObjUnit.nY);
                            }
                            if (ObjUnit.sName != "")
                            {
                                CastleConf.WriteString("Defense", "Guard_" + I + 1 + "_Name", ObjUnit.sName);
                            }
                            nCode = 17;
                            if (ObjUnit.BaseObject != null)
                            {
                                CastleConf.WriteInteger("Defense", "Guard_" + I + 1 + "_HP", ObjUnit.BaseObject.m_WAbil.HP);
                            }
                            else
                            {
                                CastleConf.WriteInteger("Defense", "Guard_" + I + 1 + "_HP", 0);
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TUserCastle.SaveConfigFile Code:" + nCode);
            }
        }

        /// <summary>
        /// ���ع����б�
        /// </summary>
        public void LoadAttackSabukWall()
        {
            string sFileName;
            string sConfigFile;
            TStringList LoadList;
            string sData;
            string s20;
            string sGuildName = string.Empty;
            TGUild Guild;
            TAttackerInfo AttackerInfo;
            if (!Directory.Exists(M2Share.g_Config.sCastleDir + m_sConfigDir))
            {
                Directory.CreateDirectory(M2Share.g_Config.sCastleDir + m_sConfigDir);
            }
            sConfigFile = "AttackSabukWall.txt";
            sFileName = M2Share.g_Config.sCastleDir + m_sConfigDir + "\\" + sConfigFile;
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                try
                {
                    LoadList.LoadFromFile(sFileName);
                    if (m_AttackWarList.Count > 0)
                    {
                        for (int I = 0; I < m_AttackWarList.Count; I++)
                        {
                            if (m_AttackWarList[I] != null)
                            {
                                Dispose(m_AttackWarList[I]);
                            }
                        }
                    }
                    m_AttackWarList.Clear();
                    if (LoadList.Count > 0)
                    {
                        for (int I = 0; I < LoadList.Count; I++)
                        {
                            sData = LoadList[I];
                            s20 = HUtil32.GetValidStr3(sData, ref sGuildName, new string[] { " ", "\09" });
                            Guild = GuildManager.FindGuild(sGuildName);
                            if (Guild != null)
                            {
                                AttackerInfo = new TAttackerInfo();
                                HUtil32.ArrestStringEx(s20, "\"", "\"", ref s20);
                                try
                                {
                                    AttackerInfo.AttackDate = Convert.ToDateTime(s20);
                                }
                                catch
                                {
                                    AttackerInfo.AttackDate = DateTime.Now;
                                }
                                AttackerInfo.sGuildName = sGuildName;
                                AttackerInfo.Guild = Guild;
                                m_AttackWarList.Add(AttackerInfo);
                            }
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("��ȡ�����ļ�ʧ��:" + sFileName);
                }
                Dispose(LoadList);
            }
        }

        /// <summary>
        /// ���湥���б�
        /// </summary>
        private void SaveAttackSabukWall()
        {
            string sFileName;
            string sConfigFile;
            TStringList LoadLis;
            TAttackerInfo AttackerInfo;
            if (!Directory.Exists(M2Share.g_Config.sCastleDir + m_sConfigDir))
            {
                Directory.CreateDirectory(M2Share.g_Config.sCastleDir + m_sConfigDir);
            }
            sConfigFile = "AttackSabukWall.txt";
            sFileName = M2Share.g_Config.sCastleDir + m_sConfigDir + "\\" + sConfigFile;
            LoadLis = new TStringList();
            if (m_AttackWarList.Count > 0)
            {
                for (int I = 0; I < m_AttackWarList.Count; I++)
                {
                    AttackerInfo = m_AttackWarList[I];
                    LoadLis.Add(AttackerInfo.sGuildName + "       \"" + (AttackerInfo.AttackDate).ToString() + "\"");
                }
            }
            try
            {
                LoadLis.SaveToFile(sFileName);
            }
            catch
            {
                M2Share.MainOutMessage("���湥����Ϣʧ��: " + sFileName);
            }
            LoadLis.Dispose();
        }

        public void Run()
        {
            int Year;
            int Month;
            int Day;
            int Hour;
            int Min;
            int Sec;
            int MSec;
            int wYear;
            int wMonth;
            int wDay;
            TAttackerInfo AttackerInfo;
            string s20;
            const string sWarStartMsg = "[{0} ����ս�Ѿ���ʼ]";
            const string sWarStopTimeMsg = "[{0} ����ս���������{1}����]";
            const string sExceptionMsg = "{�쳣} TUserCastle::Run";
            try
            {
                if (M2Share.nServerIndex != M2Share.g_MapManager.GetMapOfServerIndex(m_sMapName))
                {
                    return;
                }
                Year = DateTime.Now.Year;
                Month = DateTime.Now.Month;
                Day = DateTime.Now.Day;
                wYear = m_IncomeToday.Year;
                wMonth = m_IncomeToday.Month;
                wDay = m_IncomeToday.Day;
                if ((Year != wYear) || (Month != wMonth) || (Day != wDay))
                {
                    m_nTodayIncome = 0;
                    m_IncomeToday = DateTime.Now;
                    m_boStartWar = false;
                }
                if (!m_boStartWar && !m_boUnderWar)
                {
                    Hour = DateTime.Now.Hour;
                    Min = DateTime.Now.Minute;
                    Sec = DateTime.Now.Second;
                    MSec = DateTime.Now.Millisecond;
                    if (Hour == M2Share.g_Config.nStartCastlewarTime)
                    {
                        m_boStartWar = true;
                        m_AttackGuildList.Clear();
                        for (int I = m_AttackWarList.Count - 1; I >= 0; I--)
                        {
                            if (m_AttackWarList.Count <= 0)
                            {
                                break;
                            }
                            AttackerInfo = m_AttackWarList[I];
                            wYear = AttackerInfo.AttackDate.Year;
                            wMonth = AttackerInfo.AttackDate.Month;
                            wDay = AttackerInfo.AttackDate.Day;
                            if ((Year == wYear) && (Month == wMonth) && (Day == wDay))
                            {
                                m_boUnderWar = true;
                                m_boShowOverMsg = false;
                                m_WarDate = DateTime.Now;
                                m_dwStartCastleWarTick = HUtil32.GetTickCount();
                                m_AttackGuildList.Add(AttackerInfo.Guild);
                                Dispose(AttackerInfo);
                                m_AttackWarList.RemoveAt(I);
                            }
                        }
                        if (m_boUnderWar) // ��ʼ����
                        {
                            m_AttackGuildList.Add(m_MasterGuild);
                            StartWallconquestWar();
                            SaveAttackSabukWall();
                            UserEngine.SendServerGroupMsg(Grobal2.SS_212, M2Share.nServerIndex, "");
                            s20 = string.Format(sWarStartMsg, new string[] { m_sName });
                            UserEngine.SendBroadCastMsgExt(s20, TMsgType.t_System);
                            UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.nServerIndex, s20);
                            M2Share.MainOutMessage(s20);
                            MainDoorControl(true);
                        }
                    }
                }
                for (int I = m_Guard.GetLowerBound(0); I <= m_Guard.GetUpperBound(0); I++)
                {
                    if (m_Guard[I] != null)
                    {
                        if ((m_Guard[I].BaseObject != null) && (m_Guard[I].BaseObject.m_boGhost))
                        {
                            m_Guard[I].BaseObject = null;
                        }
                    }
                }
                for (int I = m_Archer.GetLowerBound(0); I <= m_Archer.GetUpperBound(0); I++)
                {
                    if (m_Guard[I] != null)
                    {
                        if ((m_Archer[I].BaseObject != null) && (m_Archer[I].BaseObject.m_boGhost))
                        {
                            m_Archer[I].BaseObject = null;
                        }
                    }
                }
                if (m_boUnderWar)// ���ڹ���
                {
                    if ((m_MainDoor.BaseObject != null))
                    {
                        if (((m_MainDoor.BaseObject.m_sCharName).ToLower().CompareTo((m_MainDoor.sName).ToLower()) != 0)) //  ����ֵ��������ò���Ӧ�����ؽ�
                        {
                            m_MainDoor.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_MainDoor.nX, m_MainDoor.nY, m_MainDoor.sName);
                            if (m_MainDoor.BaseObject != null)
                            {
                                m_MainDoor.BaseObject.m_WAbil.HP = m_MainDoor.nHP;
                                m_MainDoor.BaseObject.m_Castle = this;
                                m_MainDoor.BaseObject.m_nCurrX = m_MainDoor.nX;
                                m_MainDoor.BaseObject.m_nCurrY = m_MainDoor.nY;
                                MainDoorControl(true);
                            }
                        }
                        else
                        {
                            m_MainDoor.BaseObject.m_Castle = this;
                        }
                    }
                    if (m_LeftWall.BaseObject != null)
                    {
                        if (((m_LeftWall.BaseObject.m_sCharName).ToLower().CompareTo((m_LeftWall.sName).ToLower()) != 0))  // ����ֵ��������ò���Ӧ�����ؽ�
                        {
                            m_LeftWall.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_LeftWall.nX, m_LeftWall.nY, m_LeftWall.sName);
                            if (m_LeftWall.BaseObject != null)
                            {
                                m_LeftWall.BaseObject.m_WAbil.HP = m_LeftWall.nHP;
                                m_LeftWall.BaseObject.m_Castle = this;
                                m_LeftWall.BaseObject.m_nCurrX = m_LeftWall.nX;
                                m_LeftWall.BaseObject.m_nCurrY = m_LeftWall.nY;
                            }
                        }
                        else
                        {
                            m_LeftWall.BaseObject.m_Castle = this;
                        }
                        m_LeftWall.BaseObject.m_boStoneMode = false;
                    }
                    if (m_CenterWall.BaseObject != null)
                    {
                        if (((m_CenterWall.BaseObject.m_sCharName).ToLower().CompareTo((m_CenterWall.sName).ToLower()) != 0))// ����ֵ��������ò���Ӧ�����ؽ�
                        {
                            m_CenterWall.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_CenterWall.nX, m_CenterWall.nY, m_CenterWall.sName);
                            if (m_CenterWall.BaseObject != null)
                            {
                                m_CenterWall.BaseObject.m_WAbil.HP = m_CenterWall.nHP;
                                m_CenterWall.BaseObject.m_Castle = this;
                                m_CenterWall.BaseObject.m_nCurrX = m_CenterWall.nX;
                                m_CenterWall.BaseObject.m_nCurrY = m_CenterWall.nY;
                            }
                        }
                        else
                        {
                            m_CenterWall.BaseObject.m_Castle = this;
                        }
                        m_CenterWall.BaseObject.m_boStoneMode = false;
                    }
                    if (m_RightWall.BaseObject != null)
                    {
                        if (((m_RightWall.BaseObject.m_sCharName).ToLower().CompareTo((m_RightWall.sName).ToLower()) != 0))   // ����ֵ��������ò���Ӧ�����ؽ�
                        {
                            m_RightWall.BaseObject = UserEngine.RegenMonsterByName(m_sMapName, m_RightWall.nX, m_RightWall.nY, m_RightWall.sName);
                            if (m_CenterWall.BaseObject != null)
                            {
                                m_RightWall.BaseObject.m_WAbil.HP = m_RightWall.nHP;
                                m_RightWall.BaseObject.m_Castle = this;
                                m_RightWall.BaseObject.m_nCurrX = m_RightWall.nX;
                                m_RightWall.BaseObject.m_nCurrY = m_RightWall.nY;
                            }
                        }
                        else
                        {
                            m_RightWall.BaseObject.m_Castle = this;
                        }
                        m_RightWall.BaseObject.m_boStoneMode = false;
                    }
                    if (!m_boShowOverMsg)
                    {
                        // 3 * 60 * 60 * 1000 - 10 * 60 * 1000
                        if ((HUtil32.GetTickCount() - m_dwStartCastleWarTick) > (M2Share.g_Config.dwCastleWarTime - M2Share.g_Config.dwShowCastleWarEndMsgTime))
                        {
                            m_boShowOverMsg = true;
                            s20 = string.Format(sWarStopTimeMsg, m_sName, M2Share.g_Config.dwShowCastleWarEndMsgTime / 60000);
                            UserEngine.SendBroadCastMsgExt(s20, TMsgType.t_System);
                            UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.nServerIndex, s20);
                            M2Share.MainOutMessage(s20);
                        }
                    }
                    // 3 * 60 * 60 * 1000
                    if ((HUtil32.GetTickCount() - m_dwStartCastleWarTick) > M2Share.g_Config.dwCastleWarTime)
                    {
                        StopWallconquestWar();// ֹͣ����
                    }
                }
                else
                {
                    if (m_LeftWall.BaseObject != null)
                    {
                        m_LeftWall.BaseObject.m_boStoneMode = true;
                    }
                    if (m_CenterWall.BaseObject != null)
                    {
                        m_CenterWall.BaseObject.m_boStoneMode = true;
                    }
                    if (m_RightWall.BaseObject != null)
                    {
                        m_RightWall.BaseObject.m_boStoneMode = true;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        public void Save()
        {
            SaveConfigFile();
            SaveAttackSabukWall();
        }

        /// <summary>
        /// �Ƿ��ڹ���ս����Χ
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public bool InCastleWarArea(TEnvirnoment Envir, int nX, int nY)
        {
            bool result = false;
            if ((Envir == m_MapCastle) && (Math.Abs(m_nHomeX - nX) < m_nWarRangeX) && (Math.Abs(m_nHomeY - nY) < m_nWarRangeY))
            {
                result = true;
                return result;
            }
            if ((Envir == m_MapPalace) || (Envir == m_MapSecret))
            {
                result = true;
                return result;
            }
            if (m_EnvirList.Count > 0)// ����ȡ�óǱ����е�ͼ�б�
            {
                for (int I = 0; I < m_EnvirList.Count; I++)
                {
                    if (m_EnvirList[I] != Envir.sMapName)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        // �ǵĻ�Ա
        public bool IsMember(TBaseObject Cert)
        {
            return IsMasterGuild(Cert.m_MyGuild);
        }

        // ����Ƿ�Ϊ���Ƿ��л�������л�
        public bool IsAttackAllyGuild(TGUild Guild)
        {
            bool result = false;
            TGUild AttackGuild;
            if (m_AttackGuildList.Count > 0)
            {
                for (int I = 0; I < m_AttackGuildList.Count; I++)
                {
                    AttackGuild = m_AttackGuildList[I];
                    if ((AttackGuild != m_MasterGuild) && AttackGuild.IsAllyGuild(Guild))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        // ����Ƿ�Ϊ���Ƿ��л�
        public bool IsAttackGuild(TGUild Guild)
        {
            bool result = false;
            TGUild AttackGuild;
            if (m_AttackGuildList.Count > 0)
            {
                for (int I = 0; I < m_AttackGuildList.Count; I++)
                {
                    AttackGuild = m_AttackGuildList[I];
                    if ((AttackGuild != m_MasterGuild) && (AttackGuild == Guild))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public bool CanGetCastle(TGUild Guild)
        {
            bool result = false;
            List<TPlayObject> List14;
            TPlayObject PlayObject;
            // 10 * 60 * 1000
            if ((HUtil32.GetTickCount() - m_dwStartCastleWarTick) > M2Share.g_Config.dwGetCastleTime)
            {
                List14 = new List<TPlayObject>();
                UserEngine.GetMapRageHuman(m_MapPalace, 0, 0, 1000, List14);
                result = true;
                if (List14.Count > 0)
                {
                    for (int I = 0; I < List14.Count; I++)
                    {
                        PlayObject = ((TPlayObject)(List14[I]));
                        if (!PlayObject.m_boDeath && (PlayObject.m_MyGuild != Guild))
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // ɳ�Ǳ�ռ��
        public void GetCastle(TGUild Guild)
        {
            TGUild OldGuild;
            string s10;
            byte nCode;
            const string sGetCastleMsg = "[{0} �ѱ� {1} ռ��]";
            nCode = 0;
            try
            {
                OldGuild = m_MasterGuild;
                nCode = 1;
                m_MasterGuild = Guild;
                nCode = 2;
                m_sOwnGuild = Guild.sGuildName;
                nCode = 3;
                m_ChangeDate = DateTime.Now;
                nCode = 4;
                SaveConfigFile();
                nCode = 5;
                if (OldGuild != null)
                {
                    OldGuild.RefMemberName();
                }
                nCode = 6;
                if (m_MasterGuild != null)
                {
                    m_MasterGuild.RefMemberName();
                }
                nCode = 7;
                s10 = string.Format(sGetCastleMsg, m_sName, m_sOwnGuild);
                nCode = 8;
                UserEngine.SendBroadCastMsgExt(s10, TMsgType.t_System);
                nCode = 9;
                UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.nServerIndex, s10);
                nCode = 10;
                M2Share.MainOutMessage(s10);
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TUserCastle.GetCastle Code:" + nCode);
            }
        }

        public void StartWallconquestWar()
        {
            List<TPlayObject> ListC = new List<TPlayObject>();
            TPlayObject PlayObject;
            UserEngine.GetMapRageHuman(m_MapPalace, m_nHomeX, m_nHomeY, 100, ListC);
            if (ListC.Count > 0)
            {
                for (int I = 0; I < ListC.Count; I++)
                {
                    PlayObject = ((TPlayObject)(ListC[I]));
                    PlayObject.RefShowName();
                }
            }
        }

        public void StopWallconquestWar()
        {
            string s14;
            const string sWallWarStop = "[{0} ����ս�Ѿ�����]";
            m_boUnderWar = false;
            m_AttackGuildList.Clear();
            s14 = string.Format(sWallWarStop, m_sName);
            UserEngine.SendBroadCastMsgExt(s14, TMsgType.t_System);
            UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.nServerIndex, s14);
            M2Share.MainOutMessage(s14);
        }

        public int InPalaceGuildCount()
        {
            return m_AttackGuildList.Count;
        }

        /// <summary>
        /// ����Ƿ�Ϊ�سǷ��л�
        /// </summary>
        /// <param name="Guild"></param>
        /// <returns></returns>
        public bool IsDefenseAllyGuild(TGUild Guild)
        {
            bool result = false;
            if (!m_boUnderWar)
            {
                return result;
            }
            // ���δ��ʼ���ǣ�����Ч
            if (m_MasterGuild != null)
            {
                result = m_MasterGuild.IsAllyGuild(Guild);
            }
            return result;
        }

        /// <summary>
        /// ����Ƿ�Ϊ�سǷ��л�
        /// </summary>
        /// <param name="Guild"></param>
        /// <returns></returns>
        public bool IsDefenseGuild(TGUild Guild)
        {
            bool result = false;
            if (!m_boUnderWar)// ���δ��ʼ���ǣ�����Ч
            {
                return result;
            }
            if (Guild == m_MasterGuild)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// ����Ƿ�Ϊɳ�������л�
        /// </summary>
        /// <param name="Guild"></param>
        /// <returns></returns>
        public bool IsMasterGuild(TGUild Guild)
        {
            bool result = false;
            if ((m_MasterGuild != null))
            {
                if ((m_MasterGuild == Guild))
                {
                    result = true;
                }
            }
            return result;
        }

        public int GetHomeX()
        {
            return (m_nHomeX - 4) + HUtil32.Random(9);
        }

        public int GetHomeY()
        {
            return (m_nHomeY - 4) + HUtil32.Random(9);
        }

        public string GetMapName()
        {
            return m_sMapName;
        }

        public bool CheckInPalace(int nX, int nY, TBaseObject Cert)
        {
            TObjUnit ObjUnit;
            bool result = IsMasterGuild(Cert.m_MyGuild);
            if (result)
            {
                return result;
            }
            ObjUnit = m_LeftWall;
            if ((ObjUnit.BaseObject != null) && (ObjUnit.BaseObject.m_boDeath) && (ObjUnit.BaseObject.m_nCurrX == nX) && (ObjUnit.BaseObject.m_nCurrY == nY))
            {
                result = true;
            }
            ObjUnit = m_CenterWall;
            if ((ObjUnit.BaseObject != null) && (ObjUnit.BaseObject.m_boDeath) && (ObjUnit.BaseObject.m_nCurrX == nX) && (ObjUnit.BaseObject.m_nCurrY == nY))
            {
                result = true;
            }
            ObjUnit = m_RightWall;
            if ((ObjUnit.BaseObject != null) && (ObjUnit.BaseObject.m_boDeath) && (ObjUnit.BaseObject.m_nCurrX == nX) && (ObjUnit.BaseObject.m_nCurrY == nY))
            {
                result = true;
            }
            return result;
        }

        // ȡ��������
        public string GetWarDate()
        {
            string result;
            TAttackerInfo AttackerInfo;
            int Year;
            int Month;
            int Day;
            const string sMsg = "{0}��{1}��{2}��";
            result = "";
            if (m_AttackWarList.Count <= 0)
            {
                return result;
            }
            AttackerInfo = m_AttackWarList[0];
            Year = AttackerInfo.AttackDate.Year;
            Month = AttackerInfo.AttackDate.Month;
            Day = AttackerInfo.AttackDate.Day;

            result = string.Format(sMsg, Year, Month, Day);
            return result;
        }

        public string GetAttackWarList()
        {
            string result;
            int I;
            int n10;
            TAttackerInfo AttackerInfo;
            int Year;
            int Month;
            int Day;
            int wYear;
            int wMonth;
            int wDay;
            string s20;
            result = "";
            wYear = 0;
            wMonth = 0;
            wDay = 0;
            n10 = 0;
            if (m_AttackWarList.Count > 0)
            {
                // 20080630
                for (I = 0; I < m_AttackWarList.Count; I++)
                {
                    AttackerInfo = m_AttackWarList[I];
                    Year = AttackerInfo.AttackDate.Year;
                    Month = AttackerInfo.AttackDate.Month;
                    Day = AttackerInfo.AttackDate.Day;
                    if ((Year != wYear) || (Month != wMonth) || (Day != wDay))
                    {
                        wYear = Year;
                        wMonth = Month;
                        wDay = Day;
                        if (result != "")
                        {
                            result = result + "\\";
                        }
                        result = result + (wYear).ToString() + "��" + (wMonth).ToString() + "��" + (wDay).ToString() + "��\\";
                        n10 = 0;
                    }
                    if (n10 > 40)
                    {
                        result = result + "\\";
                        n10 = 0;
                    }
                    s20 = "\"" + AttackerInfo.sGuildName + "\"";
                    n10 += s20.Length;
                    result = result + s20;
                }
                // for
            }
            return result;
        }

        public void IncRateGold(int nGold)
        {
            int nInGold;
            // 0.05
            nInGold = (int)HUtil32.Round((double)nGold * (M2Share.g_Config.nCastleTaxRate / 100));
            if ((m_nTodayIncome + nInGold) <= M2Share.g_Config.nCastleOneDayGold)
            {
                m_nTodayIncome += nInGold;
            }
            else
            {
                if (m_nTodayIncome >= M2Share.g_Config.nCastleOneDayGold)
                {
                    nInGold = 0;
                }
                else
                {
                    nInGold = M2Share.g_Config.nCastleOneDayGold - m_nTodayIncome;
                    m_nTodayIncome = M2Share.g_Config.nCastleOneDayGold;
                }
            }
            if (nInGold > 0)
            {
                if ((m_nTotalGold + nInGold) < M2Share.g_Config.nCastleGoldMax)
                {
                    m_nTotalGold += nInGold;
                }
                else
                {
                    m_nTotalGold = M2Share.g_Config.nCastleGoldMax;
                }
            }
            // 10 * 60 * 1000
            if ((HUtil32.GetTickCount() - m_dwSaveTick) > 600000)
            {
                m_dwSaveTick = HUtil32.GetTickCount();
                if (M2Share.g_boGameLogGold)
                {
                    M2Share.AddGameDataLog("23" + "\09" + "0" + "\09" + "0" + "\09" + "0" + "\09" + "autosave" + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (m_nTotalGold).ToString() + "\09" + "1" + "\09" + "0");
                }
            }
        }

        // ȡ�ؽ��
        public int WithDrawalGolds(TPlayObject PlayObject, int nGold)
        {
            int result;
            // 0049066C
            result = -1;
            if (nGold <= 0)
            {
                result = -4;
                return result;
            }
            if ((m_MasterGuild == PlayObject.m_MyGuild) && (PlayObject.m_nGuildRankNo == 1) && (nGold > 0))
            {
                if ((nGold > 0) && (nGold <= m_nTotalGold))
                {
                    if ((PlayObject.m_nGold + nGold) <= PlayObject.m_nGoldMax)
                    {
                        m_nTotalGold -= nGold;
                        PlayObject.IncGold(nGold);
                        if (M2Share.g_boGameLogGold)
                        {
                            M2Share.AddGameDataLog("22" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString() + "\09" + PlayObject.m_sCharName + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (nGold).ToString() + "\09" + "1" + "\09" + "0");
                        }
                        PlayObject.GoldChanged();
                        result = 1;
                    }
                    else
                    {
                        result = -3;
                    }
                }
                else
                {
                    result = -2;
                }
            }
            return result;
        }

        // ɳ�Ϳ˴��ʽ�
        public int ReceiptGolds(TPlayObject PlayObject, int nGold)
        {
            int result;
            // 00490864
            result = -1;
            if (nGold <= 0)
            {
                result = -4;
                return result;
            }
            if ((m_MasterGuild == PlayObject.m_MyGuild) && (PlayObject.m_nGuildRankNo == 1) && (nGold > 0))
            {
                if ((nGold <= PlayObject.m_nGold))
                {
                    if ((m_nTotalGold + nGold) <= M2Share.g_Config.nCastleGoldMax)
                    {
                        PlayObject.m_nGold -= nGold;
                        m_nTotalGold += nGold;
                        if (M2Share.g_boGameLogGold)
                        {
                            M2Share.AddGameDataLog("23" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString() + "\09" + PlayObject.m_sCharName + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (nGold).ToString() + "\09" + "1" + "\09" + "0");
                        }
                        PlayObject.GoldChanged();
                        result = 1;
                    }
                    else
                    {
                        result = -3;
                    }
                }
                else
                {
                    result = -2;
                }
            }
            return result;
        }

        public void MainDoorControl(bool boClose)
        {
            // 00490460
            if ((m_MainDoor.BaseObject != null) && !m_MainDoor.BaseObject.m_boGhost)
            {
                if (boClose)
                {
                    if (((TCastleDoor)(m_MainDoor.BaseObject)).m_boOpened)
                    {
                        ((TCastleDoor)(m_MainDoor.BaseObject)).Close();
                    }
                }
                else
                {
                    if (!((TCastleDoor)(m_MainDoor.BaseObject)).m_boOpened)
                    {
                        ((TCastleDoor)(m_MainDoor.BaseObject)).Open();
                    }
                }
            }
        }

        // �޸�����
        public bool RepairDoor()
        {
            bool result;
            TObjUnit CastleDoor;
            result = false;
            CastleDoor = m_MainDoor;
            if ((CastleDoor.BaseObject == null) || m_boUnderWar || (CastleDoor.BaseObject.m_WAbil.HP >= CastleDoor.BaseObject.m_WAbil.MaxHP))
            {
                return result;
            }
            if (!CastleDoor.BaseObject.m_boDeath)
            {
                // 60 * 1000
                if ((HUtil32.GetTickCount() - CastleDoor.BaseObject.m_dwStruckTick) > 60000)
                {
                    CastleDoor.BaseObject.m_WAbil.HP = CastleDoor.BaseObject.m_WAbil.MaxHP;
                    ((TCastleDoor)(CastleDoor.BaseObject)).RefStatus();
                    result = true;
                }
            }
            else
            {
                // 60 * 1000
                if ((HUtil32.GetTickCount() - CastleDoor.BaseObject.m_dwStruckTick) > 60000)
                {
                    CastleDoor.BaseObject.m_WAbil.HP = CastleDoor.BaseObject.m_WAbil.MaxHP;
                    CastleDoor.BaseObject.m_boDeath = false;
                    ((TCastleDoor)(CastleDoor.BaseObject)).m_boOpened = false;
                    ((TCastleDoor)(CastleDoor.BaseObject)).RefStatus();
                    result = true;
                }
            }
            return result;
        }

        // �޸���ǽ
        public bool RepairWall(int nWallIndex)
        {
            bool result;
            TBaseObject Wall;
            result = false;
            Wall = null;
            switch (nWallIndex)
            {
                case 1:
                    Wall = m_LeftWall.BaseObject;
                    break;
                case 2:
                    // ��
                    Wall = m_CenterWall.BaseObject;
                    break;
                case 3:
                    // ��
                    Wall = m_RightWall.BaseObject;
                    break;
                // ��
            }
            if ((Wall == null) || m_boUnderWar || (Wall.m_WAbil.HP >= Wall.m_WAbil.MaxHP))
            {
                return result;
            }
            if (!Wall.m_boDeath)
            {
                // 60 * 1000
                if ((HUtil32.GetTickCount() - Wall.m_dwStruckTick) > 60000)
                {
                    Wall.m_WAbil.HP = Wall.m_WAbil.MaxHP;
                    ((TWallStructure)(Wall)).RefStatus();
                    result = true;
                }
            }
            else
            {
                // 60 * 1000
                if ((HUtil32.GetTickCount() - Wall.m_dwStruckTick) > 60000)
                {
                    Wall.m_WAbil.HP = Wall.m_WAbil.MaxHP;
                    Wall.m_boDeath = false;
                    ((TWallStructure)(Wall)).RefStatus();
                    result = true;
                }
            }
            return result;
        }

        // ���ӹ����л���Ϣ
        public bool AddAttackerInfo(TGUild Guild, byte nCode)
        {
            bool result;
            // 00490CD8
            TAttackerInfo AttackerInfo;
            result = false;
            if (InAttackerList(Guild))
            {
                return result;
            }
            AttackerInfo = new TAttackerInfo();
            if (nCode == 0)
            {
                AttackerInfo.AttackDate = M2Share.AddDateTimeOfDay(DateTime.Now, M2Share.g_Config.nStartCastleWarDays);
            }
            else
            {
                AttackerInfo.AttackDate = DateTime.Now;
            }
            // ��ǰ
            AttackerInfo.sGuildName = Guild.sGuildName;
            AttackerInfo.Guild = Guild;
            m_AttackWarList.Add(AttackerInfo);
            SaveAttackSabukWall();
            UserEngine.SendServerGroupMsg(Grobal2.SS_212, M2Share.nServerIndex, "");
            result = true;
            return result;
        }

        // �ڹ����б���
        private bool InAttackerList(TGUild Guild)
        {
            bool result;
            int I;
            result = false;
            if (m_AttackWarList.Count > 0)
            {
                for (I = 0; I < m_AttackWarList.Count; I++)
                {
                    if (m_AttackWarList[I].Guild == Guild)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        private void SetPower(int nPower)
        {
            m_nPower = nPower;
        }

        private void SetTechLevel(int nLevel)
        {
            m_nTechLevel = nLevel;
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}