using GameFramework;
using M2Server.Base;
/*
 * ���ƣ�TGuildManager
 * �����ˣ�John
 * ����ʱ�䣺2012-3-6 9:30:56
 * ����:����л�
 *********************************************
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public class TGuildRank
    {
        public int nRankNo;// ����
        public string sRankName;// ְ��
        public List<TPlayObject> MemberList;
    }

    public class TWarGuild
    {
        public Object Guild;
        public uint dwWarTick;
        public uint dwWarTime;
    }

    public class TGUild : GameBase
    {
        public int Count
        {
            get
            {
                return GetMemberCount();
            }
        }
        public bool IsFull
        {
            get
            {
                return GetMemgerIsFull();
            }
        }
        public int nBuildPoint
        {
            get
            {
                return m_nBuildPoint;
            }
            set
            {
                SetBuildPoint(value);
            }
        }
        public int nAurae
        {
            get
            {
                return m_nAurae;
            }
            set
            {
                SetAuraePoint(value);
            }
        }
        public int nStability
        {
            get
            {
                return m_nStability;
            }
            set
            {
                SetStabilityPoint(value);
            }
        }
        public int nFlourishing
        {
            get
            {
                return m_nFlourishing;
            }
            set
            {
                SetFlourishPoint(value);
            }
        }
        public int nChiefItemCount
        {
            get
            {
                return m_nChiefItemCount;
            }
            set
            {
                SetChiefItemCount(value);
            }
        }

        /// <summary>
        /// �л�����
        /// </summary>
        public string sGuildName = String.Empty;
        public TStringList NoticeList = null;// �лṫ��
        public IList<TWarGuild> GuildWarList = null;
        public IList<TGUild> GuildAllList = null;
        public IList<TGuildRank> m_RankList = null;// ְλ�б�
        public int nContestPoint = 0;
        public bool boTeamFight = false;
        public TStringList TeamFightDeadList = null;
        public bool m_boEnableAuthAlly = false;// �Ƿ������л�����
        public uint dwSaveTick = 0;// ���ݱ�����
        public bool boChanged = false;// �Ƿ�ı�
        public IList<TDynamicVar> m_DynamicVarList = null;
        public int m_nGuildFountain = 0;// �л�Ȫˮ�ֿ�
        public bool boGuildFountainOpen = false;// �л�ֿ��Ƿ���
        public ushort m_nGuildMemberCount = 0;
        private IniFile m_Config = null;
        private int m_nBuildPoint = 0;// ������
        private int m_nAurae = 0;// ������
        private int m_nStability = 0;// ������
        private int m_nFlourishing = 0;// ���ٶ�
        private int m_nChiefItemCount = 0;

        // ����л�
        private void ClearRank()
        {
            int I;
            TGuildRank GuildRank;
            if (m_RankList.Count > 0)
            {
                for (I = 0; I < m_RankList.Count; I++)
                {
                    GuildRank = m_RankList[I];
                    Dispose(GuildRank.MemberList);
                    Dispose(GuildRank);
                }
            }
            m_RankList.Clear();
        }

        public TGUild(string sName)
        {
            string sFileName;
            sGuildName = sName;
            NoticeList = new TStringList();
            GuildWarList = new List<TWarGuild>();
            GuildAllList = new List<TGUild>();
            m_RankList = new List<TGuildRank>();
            TeamFightDeadList = new TStringList();
            dwSaveTick = 0;
            boChanged = false;
            nContestPoint = 0;
            boTeamFight = false;
            m_boEnableAuthAlly = false;
            sFileName = M2Share.g_Config.sGuildDir + sName + ".ini";
            m_Config = new IniFile(sFileName);
            if (!File.Exists(sFileName))
            {
                m_Config.WriteString("Guild", "GuildName", sName);
            }
            m_nBuildPoint = 0;
            m_nAurae = 0;
            m_nStability = 0;
            m_nFlourishing = 0;
            m_nChiefItemCount = 0;
            m_nGuildFountain = 0;// �л�Ȫˮ�ֿ�
            boGuildFountainOpen = false;// �л�ֿ��Ƿ���
            m_nGuildMemberCount = M2Share.g_Config.nGuildMemberCount;// �л��Ա����
            m_DynamicVarList = new List<TDynamicVar>();
        }

        public bool DelAllyGuild(TGUild Guild)
        {
            bool result;
            int I;
            TGUild AllyGuild;
            result = false;
            for (I = 0; I < GuildAllList.Count; I++)
            {
                if (GuildAllList.Count <= 0)
                {
                    break;
                }
                AllyGuild = GuildAllList[I];
                if (AllyGuild == Guild)
                {
                    GuildAllList.RemoveAt(I);
                    result = true;
                    break;
                }
            }
            SaveGuildInfoFile();
            return result;
        }


        ~TGUild()
        {
            int I;
            Dispose(NoticeList);
            Dispose(GuildWarList);
            Dispose(GuildAllList);
            Dispose(m_RankList);
            Dispose(TeamFightDeadList);
            Dispose(m_Config);
            Dispose(m_DynamicVarList);
            ClearRank();
            if (m_DynamicVarList.Count > 0)
            {
                for (I = 0; I < m_DynamicVarList.Count; I++)
                {
                    if (m_DynamicVarList[I] != null)
                    {
                        Dispose(m_DynamicVarList[I]);
                    }
                }
            }
        }

        public bool IsAllyGuild(TGUild Guild)
        {
            bool result;
            int I;
            TGUild AllyGuild;
            result = false;
            for (I = 0; I < GuildAllList.Count; I++)
            {
                AllyGuild = GuildAllList[I];
                if (AllyGuild == Guild)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// �Ƿ����л��Ա
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public bool IsMember(string sName)
        {
            bool result;
            int I;
            int II;
            TGuildRank GuildRank;
            result = false;
            for (I = 0; I < m_RankList.Count; I++)
            {
                GuildRank = m_RankList[I];
                for (II = 0; II < GuildRank.MemberList.Count; II++)
                {
                    if (GuildRank.MemberList[II].m_sCharName == sName)
                    {
                        result = true;
                        return result;
                    }
                }
            }
            return result;
        }

        public bool IsWarGuild(TGUild Guild)
        {
            bool result;
            int I;
            result = false;
            if (GuildWarList.Count > 0)
            {
                for (I = 0; I < GuildWarList.Count; I++)
                {
                    if (GuildWarList[I].Guild == Guild)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public bool LoadGuild()
        {
            bool result;
            string sFileName;
            sFileName = sGuildName + ".txt";
            result = LoadGuildFile(sFileName);
            LoadGuildConfig(sGuildName + ".ini");
            return result;
        }

        public bool LoadGuildConfig(string sGuildFileName)
        {
            bool result;
            m_nBuildPoint = m_Config.ReadInteger("Guild", "BuildPoint", m_nBuildPoint);
            m_nAurae = m_Config.ReadInteger("Guild", "Aurae", m_nAurae);
            m_nStability = m_Config.ReadInteger("Guild", "Stability", m_nStability);
            m_nFlourishing = m_Config.ReadInteger("Guild", "Flourishing", m_nFlourishing);
            m_nChiefItemCount = m_Config.ReadInteger("Guild", "ChiefItemCount", m_nChiefItemCount);
            m_nGuildFountain = m_Config.ReadInteger("Guild", "GuildFountain", m_nGuildFountain);// �л�Ȫˮ�ֿ�
            boGuildFountainOpen = m_Config.ReadBool("Guild", "GuildFountainOpen", boGuildFountainOpen);// �л�ֿ��Ƿ���
            m_nGuildMemberCount = m_Config.ReadInteger("Guild", "GuildMemberCount", m_nGuildMemberCount);// �л��Ա����
            result = true;
            return result;
        }

        /// <summary>
        /// ��ȡ�л��ļ�
        /// </summary>
        /// <param name="sGuildFileName"></param>
        /// <returns></returns>
        public bool LoadGuildFile(string sGuildFileName)
        {
            bool result;
            TStringList LoadList;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string sFileName;
            int n28;
            int n2C;
            TWarGuild GuildWar;
            TGuildRank GuildRank;
            TGUild Guild;
            TPlayObject PlayObject;
            result = false;
            GuildRank = null;
            sFileName = M2Share.g_Config.sGuildDir + sGuildFileName;
            if (!File.Exists(sFileName))
            {
                return result;
            }
            ClearRank();
            NoticeList.Clear();
            if (GuildWarList.Count > 0)
            {
                for (int I = 0; I < GuildWarList.Count; I++)
                {
                    if (GuildWarList[I] != null)
                    {
                        Dispose(GuildWarList[I]);
                    }
                }
            }
            GuildWarList.Clear();
            GuildAllList.Clear();
            n28 = 0;
            n2C = 0;
            s24 = "";
            LoadList = new TStringList();
            LoadList.LoadFromFile(sFileName);
            for (int I = 0; I < LoadList.Count; I++)
            {
                s18 = LoadList[I];
                if ((s18 == "") || (s18[0] == ';'))
                {
                    continue;
                }
                if (s18[0] != '+')
                {
                    if (s18 == M2Share.g_Config.sGuildNotice)
                    {
                        n28 = 1;
                    }
                    if (s18 == M2Share.g_Config.sGuildWar)
                    {
                        n28 = 2;
                    }
                    if (s18 == M2Share.g_Config.sGuildAll)
                    {
                        n28 = 3;
                    }
                    if (s18 == M2Share.g_Config.sGuildMember)
                    {
                        n28 = 4;
                    }
                    if (s18[0] == '#')
                    {
                        s18 = s18.Substring(2 - 1, s18.Length - 1);
                        s18 = HUtil32.GetValidStr3(s18, ref s1C, new string[] { " ", "," });
                        n2C = HUtil32.Str_ToInt(s1C, 0);// ����
                        s24 = s18.Trim();// ְ��
                        GuildRank = null;
                    }
                    continue;
                }
                s18 = s18.Substring(2 - 1, s18.Length - 1);
                switch (n28)
                {
                    case 1:
                        NoticeList.Add(s18);
                        break;
                    case 2:
                        while ((s18 != ""))
                        {
                            s18 = HUtil32.GetValidStr3(s18, ref s1C, new string[] { " ", "," });
                            if (s1C == "")
                            {
                                break;
                            }
                            GuildWar = new TWarGuild();
                            GuildWar.Guild = GuildManager.FindGuild(s1C);
                            if (GuildWar.Guild != null)
                            {
                                GuildWar.dwWarTick = HUtil32.GetTickCount();
                                GuildWar.dwWarTime = Convert.ToUInt32(HUtil32.Str_ToInt(s20.Trim(), 0));
                                GuildWarList.Add(GuildWar);
                                //GuildWarList.Add(((GuildWar.Guild) as TGUild).sGuildName, ((GuildWar) as Object));
                            }
                            else
                            {

                                Dispose(GuildWar);
                            }
                        }
                        break;
                    case 3:
                        while ((s18 != ""))
                        {
                            s18 = HUtil32.GetValidStr3(s18, ref s1C, new string[] { " ", "," });
                            s18 = HUtil32.GetValidStr3(s18, ref s20, new string[] { " ", "," });
                            if (s1C == "")
                            {
                                break;
                            }
                            Guild = GuildManager.FindGuild(s1C);
                            if (Guild != null)
                            {
                                //GuildAllList.Insert(s1C, Guild);
                            }
                        }
                        break;
                    case 4:
                        if ((n2C > 0) && (s24 != ""))
                        {
                            if (s24.Length > 30)// ����ְ��ĳ���
                            {
                                s24 = s24.Substring(1 - 1, M2Share.g_Config.nGuildRankNameLen);
                            }
                            if (GuildRank == null)
                            {
                                GuildRank = new TGuildRank();
                                GuildRank.nRankNo = n2C;
                                GuildRank.sRankName = s24;
                                GuildRank.MemberList = new List<TPlayObject>();
                                m_RankList.Add(GuildRank);
                            }
                            while ((s18 != ""))
                            {
                                s18 = HUtil32.GetValidStr3(s18, ref s1C, new string[] { " ", "," });
                                if (s1C == "")
                                {
                                    break;
                                }
                                PlayObject = UserEngine.GetPlayObject(s1C);
                                GuildRank.MemberList.Add(PlayObject);
                                //GuildRank.MemberList.Add(s1C);
                            }
                        }
                        break;
                }
            }
            Dispose(LoadList);
            result = true;
            return result;
        }

        // �л�����2 (��NPC����-SendMsgʹ��)
        public void RefMemberName()
        {
            int I;
            int II;
            TGuildRank GuildRank;
            TBaseObject BaseObject;
            byte nCode;
            nCode = 0;
            try
            {
                if (m_RankList.Count > 0)
                {
                    nCode = 1;
                    for (I = 0; I < m_RankList.Count; I++)
                    {
                        nCode = 2;
                        GuildRank = m_RankList[I];
                        nCode = 3;
                        if (GuildRank != null)
                        {
                            nCode = 4;
                            if (GuildRank.MemberList.Count > 0)
                            {
                                nCode = 5;
                                for (II = 0; II < GuildRank.MemberList.Count; II++)
                                {
                                    nCode = 6;
                                    //BaseObject = ((TBaseObject)(GuildRank.MemberList[II]));
                                    BaseObject = null;
                                    nCode = 7;
                                    if (BaseObject != null)
                                    {
                                        BaseObject.RefShowName();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TGUild.RefMemberName Code:" + (nCode).ToString());
            }
        }

        public void SaveGuildInfoFile()
        {
            if (M2Share.nServerIndex == 0)
            {
                SaveGuildFile(M2Share.g_Config.sGuildDir + sGuildName + ".txt");
                SaveGuildConfig(M2Share.g_Config.sGuildDir + sGuildName + ".ini");
            }
            else
            {
                SaveGuildFile(M2Share.g_Config.sGuildDir + sGuildName + "." + (M2Share.nServerIndex).ToString());
            }
        }

        private void SaveGuildConfig(string sFileName)
        {
            m_Config.WriteString("Guild", "GuildName", sGuildName);
            m_Config.WriteInteger("Guild", "BuildPoint", m_nBuildPoint);
            m_Config.WriteInteger("Guild", "Aurae", m_nAurae);
            m_Config.WriteInteger("Guild", "Stability", m_nStability);
            m_Config.WriteInteger("Guild", "Flourishing", m_nFlourishing);
            m_Config.WriteInteger("Guild", "ChiefItemCount", m_nChiefItemCount);// �л�Ȫˮ�ֿ�
            m_Config.WriteInteger("Guild", "GuildFountain", m_nGuildFountain);// �л�ֿ��Ƿ���
            m_Config.WriteBool("Guild", "GuildFountainOpen", boGuildFountainOpen);// �л��Ա���� 
            m_Config.WriteInteger("Guild", "GuildMemberCount", m_nGuildMemberCount);
        }

        private void SaveGuildFile(string sFileName)
        {
            TStringList SaveList;
            int I;
            int II;
            TWarGuild WarGuild;
            TGuildRank GuildRank;
            int n14;
            SaveList = new TStringList();
            try
            {
                SaveList.Add(M2Share.g_Config.sGuildNotice);
                for (I = 0; I < NoticeList.Count; I++)
                {
                    SaveList.Add("+" + NoticeList[I]);
                }
                SaveList.Add(" ");
                SaveList.Add(M2Share.g_Config.sGuildWar);
                for (I = 0; I < GuildWarList.Count; I++)
                {
                    WarGuild = ((GuildWarList[I]) as TWarGuild);
                    n14 = Convert.ToInt32(WarGuild.dwWarTime - (HUtil32.GetTickCount() - WarGuild.dwWarTick));
                    if (n14 <= 0)
                    {
                        continue;
                    }
                    SaveList.Add("+" + GuildWarList[I] + " " + (n14).ToString());
                }
                SaveList.Add(" ");
                SaveList.Add(M2Share.g_Config.sGuildAll);
                for (I = 0; I < GuildAllList.Count; I++)
                {
                    SaveList.Add("+" + GuildAllList[I]);
                }
                SaveList.Add(" ");
                SaveList.Add(M2Share.g_Config.sGuildMember);
                for (I = 0; I < m_RankList.Count; I++)
                {
                    GuildRank = m_RankList[I];
                    SaveList.Add("#" + (GuildRank.nRankNo).ToString() + " " + GuildRank.sRankName);
                    for (II = 0; II < GuildRank.MemberList.Count; II++)
                    {
                        SaveList.Add("+" + GuildRank.MemberList[II]);
                    }
                }
                try
                {
                    SaveList.SaveToFile(sFileName);
                }
                catch
                {
                    M2Share.MainOutMessage("�����л���Ϣʧ�ܣ����� " + sFileName);
                }
            }
            finally
            {
                Dispose(SaveList);
            }
        }

        // �л�����
        public void SendGuildMsg(string sMsg)
        {
            int I;
            int II;
            TGuildRank GuildRank;
            TPlayObject PlayObject;
            int nCheckCode;
            nCheckCode = 0;
            try
            {
                if (M2Share.g_Config.boShowPreFixMsg)
                {
                    sMsg = M2Share.g_Config.sGuildMsgPreFix + sMsg;
                }
                nCheckCode = 1;
                if (m_RankList.Count > 0)
                {
                    for (I = 0; I < m_RankList.Count; I++)
                    {
                        GuildRank = m_RankList[I];
                        nCheckCode = 2;
                        if (GuildRank.MemberList == null)
                        {
                            continue;
                        }
                        if (GuildRank.MemberList.Count > 0)
                        {
                            for (II = 0; II < GuildRank.MemberList.Count; II++)
                            {
                                nCheckCode = 3;
                                // PlayObject = ((TPlayObject)(GuildRank.MemberList[II]));
                                PlayObject = null;// �һ��������л���Ϣ
                                if ((PlayObject == null) || (UserEngine.GetPlayObject(PlayObject) == null) || (PlayObject.m_boNotOnlineAddExp))
                                {
                                    continue;
                                }
                                nCheckCode = 4;
                                if (PlayObject.m_boBanGuildChat)
                                {
                                    nCheckCode = 5;
                                    PlayObject.SendMsg(PlayObject, Grobal2.RM_GUILDMESSAGE, 0, M2Share.g_Config.btGuildMsgFColor, M2Share.g_Config.btGuildMsgBColor, 0, sMsg);
                                    nCheckCode = 6;
                                    if (M2Share.g_Config.boRecordClientMsg && (sMsg != ""))
                                    {
                                        // ��¼�л�������Ϣ
                                        M2Share.MainOutMessage("[�л�����] " + sGuildName + ":" + sMsg);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TGuild.SendGuildMsg CheckCode: " + (nCheckCode).ToString() + " GuildName:" + sGuildName + " Msg:" + sMsg);
            }
        }

        // �л�����
        // �л�����2 (��NPC����-SendMsgʹ��)
        public void SendGuildMsg1(string sMsg, byte FColor, byte BColor)
        {
            int I;
            int II;
            TGuildRank GuildRank;
            TPlayObject PlayObject;
            int nCheckCode;
            nCheckCode = 0;
            try
            {
                if (M2Share.g_Config.boShowPreFixMsg)
                {
                    sMsg = M2Share.g_Config.sGuildMsgPreFix + sMsg;
                }
                nCheckCode = 1;
                if (m_RankList.Count > 0)
                {
                    for (I = 0; I < m_RankList.Count; I++)
                    {
                        GuildRank = m_RankList[I];
                        nCheckCode = 2;
                        if (GuildRank.MemberList == null)
                        {
                            continue;
                        }
                        if (GuildRank.MemberList.Count > 0)
                        {
                            for (II = 0; II < GuildRank.MemberList.Count; II++)
                            {
                                nCheckCode = 3;
                                // PlayObject = ((TPlayObject)(GuildRank.MemberList[II]));
                                PlayObject = null;
                                if ((PlayObject == null) || (UserEngine.GetPlayObject(PlayObject) == null) || (PlayObject.m_boNotOnlineAddExp))// �һ��������л���Ϣ
                                {
                                    continue;
                                }
                                nCheckCode = 4;
                                if (PlayObject.m_boBanGuildChat)
                                {
                                    nCheckCode = 5;
                                    PlayObject.SendMsg(PlayObject, Grobal2.RM_GUILDMESSAGE, 0, FColor, BColor, 0, sMsg);
                                    nCheckCode = 6;
                                    if (M2Share.g_Config.boRecordClientMsg && (sMsg != "")) // ��¼�л�������Ϣ
                                    {
                                        M2Share.MainOutMessage("[�л�����] " + sGuildName + ":" + sMsg);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage("{�쳣} TGuild.SendGuildMsg1 CheckCode: " + (nCheckCode).ToString() + " GuildName:" + sGuildName + " Msg:" + sMsg);
            }
        }

        // �л���ȡװ������
        // ���óǱ���Ϣ
        public bool SetGuildInfo(string sChief)
        {
            bool result;
            TGuildRank GuildRank;
            if (m_RankList.Count == 0)
            {
                GuildRank = new TGuildRank();
                GuildRank.nRankNo = 1;// �ϴ�
                GuildRank.sRankName = M2Share.g_Config.sGuildChief;// ������
                GuildRank.MemberList = new List<TPlayObject>(); ;
                //GuildRank.MemberList.Add(sChief);
                m_RankList.Add(GuildRank);
                SaveGuildInfoFile();
            }
            result = true;
            return result;
        }

        // ȡ�л���
        public string GetRankName(TPlayObject PlayObject, ref int nRankNo)
        {
            string result;
            int I;
            int II;
            TGuildRank GuildRank;
            result = "";
            if (m_RankList.Count > 0)
            {
                for (I = 0; I < m_RankList.Count; I++)
                {
                    GuildRank = m_RankList[I];
                    if (GuildRank.MemberList.Count > 0)
                    {
                        for (II = 0; II < GuildRank.MemberList.Count; II++)
                        {
                            if (GuildRank.MemberList[II].m_sCharName == PlayObject.m_sCharName)
                            {
                                // GuildRank.MemberList[II] = PlayObject;
                                nRankNo = GuildRank.nRankNo;
                                result = GuildRank.sRankName;
                                PlayObject.RefShowName();
                                PlayObject.SendMsg(PlayObject, Grobal2.RM_CHANGEGUILDNAME, 0, 0, 0, 0, "");
                                return result;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public string GetChiefName()
        {
            string result;
            TGuildRank GuildRank;
            result = "";
            if (m_RankList.Count <= 0)
            {
                return result;
            }
            GuildRank = m_RankList[0];
            if (GuildRank.MemberList.Count <= 0)
            {
                return result;
            }
            result = GuildRank.MemberList[0].m_sCharName;
            return result;
        }

        public void CheckSaveGuildFile()
        {
            if (boChanged && ((HUtil32.GetTickCount() - dwSaveTick) > 30000))// 30 * 1000
            {
                boChanged = false;
                SaveGuildInfoFile();
            }
        }

        public void DelHumanObj(TPlayObject PlayObject)
        {
            int I;
            int II;
            TGuildRank GuildRank;
            CheckSaveGuildFile();
            if (m_RankList.Count > 0)
            {
                for (I = 0; I < m_RankList.Count; I++)
                {
                    GuildRank = m_RankList[I];
                    if (GuildRank.MemberList.Count > 0)
                    {
                        for (II = 0; II < GuildRank.MemberList.Count; II++)
                        {
                            //if (((TPlayObject)(GuildRank.MemberList[II])) == PlayObject)
                            //{
                            //    GuildRank.MemberList[II] = null;
                            //    return;
                            //}
                        }
                    }
                }
            }
        }

        public void TeamFightWhoDead(string sName)
        {
            int I;
            int n10;
            if (!boTeamFight)
            {
                return;
            }
            if (TeamFightDeadList.Count > 0)
            {
                for (I = 0; I < TeamFightDeadList.Count; I++)
                {
                    if (TeamFightDeadList[I] == sName)
                    {
                        //n10 = ((int)TeamFightDeadList[I]);
                        //TeamFightDeadList[I] = ((MakeLong(LoWord(n10) + 1, HiWord(n10))) as Object);
                    }
                }
            }
        }

        public void TeamFightWhoWinPoint(string sName, int nPoint)
        {
            int I;
            int n14;
            if (!boTeamFight)
            {
                return;
            }
            nContestPoint += nPoint;
            if (TeamFightDeadList.Count > 0)
            {
                for (I = 0; I < TeamFightDeadList.Count; I++)
                {
                    if (TeamFightDeadList[I] == sName)
                    {
                        //n14 = ((int)TeamFightDeadList.Values[I]);
                        //TeamFightDeadList.Values[I] = ((MakeLong(LoWord(n14), HiWord(n14) + nPoint)) as Object);
                    }
                }
            }
        }

        public void UpdateGuildFile()
        {
            boChanged = true;

            dwSaveTick = HUtil32.GetTickCount();
            SaveGuildInfoFile();
        }

        public void BackupGuildFile()
        {
            int I;
            int II;
            TPlayObject PlayObject;
            TGuildRank GuildRank;
            if (M2Share.nServerIndex == 0)
            {
                SaveGuildFile(M2Share.g_Config.sGuildDir + sGuildName + "." + (HUtil32.GetTickCount()).ToString() + ".bak");
            }
            if (m_RankList.Count > 0)
            {
                for (I = 0; I < m_RankList.Count; I++)
                {
                    GuildRank = m_RankList[I];
                    if (GuildRank.MemberList.Count > 0)
                    {
                        for (II = 0; II < GuildRank.MemberList.Count; II++)
                        {
                            //PlayObject = ((TPlayObject)(GuildRank.MemberList[II]));
                            PlayObject = null;
                            if (PlayObject != null)
                            {
                                PlayObject.m_MyGuild = null;
                                PlayObject.RefRankInfo(0, "");
                                PlayObject.RefShowName();
                            }
                        }
                    }
                    Dispose(GuildRank.MemberList);
                    Dispose(GuildRank);
                }
            }
            m_RankList.Clear();
            NoticeList.Clear();
            if (GuildWarList.Count > 0)
            {
                for (I = 0; I < GuildWarList.Count; I++)
                {
                    if (((GuildWarList[I]) as TWarGuild) != null)
                    {
                        //Dispose(((GuildWarList.Values[I]) as TWarGuild));
                    }
                }
            }
            GuildWarList.Clear();
            GuildAllList.Clear();
            SaveGuildInfoFile();
        }

        // �л����ӳ�Ա
        public bool AddMember(TPlayObject PlayObject)
        {
            bool result;
            int I;
            TGuildRank GuildRank;
            TGuildRank GuildRank18;
            result = false;
            GuildRank18 = null;
            if (m_RankList.Count > 0)
            {
                for (I = 0; I < m_RankList.Count; I++)
                {
                    GuildRank = m_RankList[I];
                    if (GuildRank.nRankNo == 99)
                    {
                        GuildRank18 = GuildRank;
                        break;
                    }
                }
            }
            if (GuildRank18 == null)
            {
                GuildRank18 = new TGuildRank();
                GuildRank18.nRankNo = 99;
                GuildRank18.sRankName = M2Share.g_Config.sGuildMemberRank;
                GuildRank18.MemberList = new List<TPlayObject>();
                m_RankList.Add(GuildRank18);
            }
            //GuildRank18.MemberList.Add(PlayObject.m_sCharName, ((PlayObject) as Object));
            UpdateGuildFile();// �����л��ļ�
            result = true;
            return result;
        }

        // �л�ɾ����Ա
        public bool DelMember(string sHumName)
        {
            bool result;
            int I;
            int II;
            TGuildRank GuildRank;
            result = false;
            for (I = 0; I < m_RankList.Count; I++)
            {
                GuildRank = m_RankList[I];
                for (II = GuildRank.MemberList.Count - 1; II >= 0; II--)
                {
                    if (GuildRank.MemberList.Count <= 0)
                    {
                        break;
                    }
                    if (GuildRank.MemberList[II].m_sCharName == sHumName)
                    {
                        GuildRank.MemberList.RemoveAt(II);
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    break;
                }
            }
            if (result)
            {
                UpdateGuildFile();
            }
            return result;
        }

        public bool CancelGuld(string sHumName)
        {
            bool result;
            TGuildRank GuildRank;
            result = false;
            if (m_RankList.Count != 1)
            {
                return result;
            }
            GuildRank = m_RankList[0];
            if (GuildRank.MemberList.Count != 1)
            {
                return result;
            }
            if (GuildRank.MemberList[0].m_sCharName == sHumName)
            {
                BackupGuildFile();
                result = true;
            }
            return result;
        }

        public void UpdateRank_ClearRankList(ref IList<TGuildRank> RankList)
        {
            int I;
            TGuildRank GuildRank;
            if (RankList.Count > 0)
            {
                for (I = 0; I < RankList.Count; I++)
                {
                    GuildRank = RankList[I];
                    Dispose(GuildRank.MemberList);
                    Dispose(GuildRank);
                }
            }
            Dispose(RankList);
        }

        public int UpdateRank(string sRankData)
        {
            int result;
            int I;
            int II;
            int III;
            IList<TGuildRank> GuildRankList;
            TGuildRank GuildRank;
            TGuildRank NewGuildRank;
            string sRankInfo = string.Empty;
            string sRankNo = string.Empty;
            string sRankName = string.Empty;
            string sMemberName = string.Empty;
            int n28;
            int n2C;
            int n30;
            bool boCheckChange;
            TPlayObject PlayObject;
            result = -1;
            try
            {
                GuildRankList = new List<TGuildRank>();
                GuildRank = null;
                while (true)
                {
                    if (sRankData == "")
                    {
                        break;
                    }
                    sRankData = HUtil32.GetValidStr3(sRankData, ref sRankInfo, new string[] { "\r" });
                    sRankInfo = sRankInfo.Trim();
                    if (sRankInfo == "")
                    {
                        continue;
                    }
                    if (sRankInfo[0] == '#') // ȡ��ְ�Ƶ�����
                    {
                        sRankInfo = sRankInfo.Substring(2 - 1, sRankInfo.Length - 1);
                        sRankInfo = HUtil32.GetValidStr3(sRankInfo, ref sRankNo, new string[] { " ", "<" });
                        sRankInfo = HUtil32.GetValidStr3(sRankInfo, ref sRankName, new string[] { "<", ">" });
                        if (sRankName.Length > 30)//����ְ�Ƶĳ���
                        {
                            sRankName = sRankName.Substring(1 - 1, 30);
                        }
                        if (GuildRank != null)
                        {
                            GuildRankList.Add(GuildRank);
                        }
                        GuildRank = new TGuildRank();
                        GuildRank.nRankNo = HUtil32.Str_ToInt(sRankNo, 99);
                        GuildRank.sRankName = sRankName.Trim();
                        GuildRank.MemberList = new List<TPlayObject>();
                        continue;
                    }
                    if (GuildRank == null)
                    {
                        continue;
                    }
                    I = 0;
                    while (true)
                    {
                        // ����Ա���Ƽ���ְ�Ʊ���
                        if (sRankInfo == "")
                        {
                            break;
                        }
                        sRankInfo = HUtil32.GetValidStr3(sRankInfo, ref sMemberName, new string[] { " ", "," });
                        if (sMemberName != "")
                        {
                            //GuildRank.MemberList.Add(sMemberName);
                        }
                        I++;
                        if (I > M2Share.g_Config.nGuildMemberMaxLimit) // ���Ƴ�Ա����
                        {
                            break;
                        }
                    }
                }
                if (GuildRank != null)
                {
                    GuildRankList.Add(GuildRank); // У���Ա�б��Ƿ��иı䣬���δ�޸����˳�
                }
                boCheckChange = false;
                if (m_RankList.Count == GuildRankList.Count)
                {
                    boCheckChange = true;
                    for (I = 0; I < m_RankList.Count; I++)
                    {
                        GuildRank = m_RankList[I];
                        NewGuildRank = GuildRankList[I];
                        if ((GuildRank.nRankNo == NewGuildRank.nRankNo) && (GuildRank.sRankName == NewGuildRank.sRankName) && (GuildRank.MemberList.Count == NewGuildRank.MemberList.Count))
                        {
                            for (II = 0; II < GuildRank.MemberList.Count; II++)
                            {
                                if (GuildRank.MemberList[II] != NewGuildRank.MemberList[II])
                                {
                                    boCheckChange = false;// ����иı�������ΪFALSE
                                    break;
                                }
                            }
                        }
                        else
                        {
                            boCheckChange = false;
                            break;
                        }
                    }
                    // for
                    if (boCheckChange)
                    {
                        result = -1;
                        UpdateRank_ClearRankList(ref GuildRankList);
                        return result;
                    }
                }
                // ����л�����ְҵ�Ƿ�Ϊ��
                result = -2;
                if ((GuildRankList.Count > 0))
                {
                    GuildRank = GuildRankList[0];
                    if (GuildRank.nRankNo == 1)
                    {
                        if (GuildRank.sRankName != "")
                        {
                            result = 0;
                        }
                        else
                        {
                            result = -3;
                        }
                    }
                }
                // ����л��������Ƿ�����(������)
                if (result == 0)
                {
                    GuildRank = GuildRankList[0];
                    if (GuildRank.MemberList.Count <= 2)
                    {
                        n28 = GuildRank.MemberList.Count;
                        for (I = 0; I < GuildRank.MemberList.Count; I++)
                        {
                            if (UserEngine.GetPlayObject(GuildRank.MemberList[I]) == null)
                            {
                                n28 -= 1;
                                break;
                            }
                        }
                        if (n28 <= 0)
                        {
                            result = -5;
                        }
                    }
                    else
                    {
                        result = -4;
                    }
                }
                if (result == 0)
                {
                    n2C = 0;
                    n30 = 0;
                    for (I = 0; I < m_RankList.Count; I++)
                    {
                        GuildRank = m_RankList[I];
                        boCheckChange = true;
                        for (II = 0; II < GuildRank.MemberList.Count; II++)
                        {
                            boCheckChange = false;
                            sMemberName = GuildRank.MemberList[II].m_sCharName;
                            n2C++;
                            for (III = 0; III < GuildRankList.Count; III++)
                            {
                                // �������б�
                                NewGuildRank = GuildRankList[III];
                                for (n28 = 0; n28 < NewGuildRank.MemberList.Count; n28++)
                                {
                                    if (NewGuildRank.MemberList[n28].m_sCharName == sMemberName)
                                    {
                                        boCheckChange = true;
                                        break;
                                    }
                                }
                                if (boCheckChange)
                                {
                                    break;
                                }
                            }
                            // for
                            if (!boCheckChange)
                            {
                                // ԭ�б��е����������Ƿ����µ��б���
                                result = -6;
                                break;
                            }
                        }
                        // for
                        if (!boCheckChange)
                        {
                            break;
                        }
                    }
                    // for
                    for (I = 0; I < GuildRankList.Count; I++)
                    {
                        GuildRank = GuildRankList[I];
                        boCheckChange = true;
                        for (II = 0; II < GuildRank.MemberList.Count; II++)
                        {
                            boCheckChange = false;
                            sMemberName = GuildRank.MemberList[II].m_sCharName;
                            n30++;
                            for (III = 0; III < GuildRankList.Count; III++)
                            {
                                NewGuildRank = GuildRankList[III];
                                for (n28 = 0; n28 < NewGuildRank.MemberList.Count; n28++)
                                {
                                    if (NewGuildRank.MemberList[n28].m_sCharName == sMemberName)
                                    {
                                        boCheckChange = true;
                                        break;
                                    }
                                }
                                if (boCheckChange)
                                {
                                    break;
                                }
                            }
                            // for
                            if (!boCheckChange)
                            {
                                result = -6;
                                break;
                            }
                        }
                        // for
                        if (!boCheckChange)
                        {
                            break;
                        }
                    }
                    // for
                    if ((result == 0) && (n2C != n30))
                    {
                        // n2c n30 ���ڱȽ��޸Ĺ��������
                        result = -6;
                    }
                }
                if (result == 0)
                {
                    // �����������
                    n2C = 0;
                    for (I = 0; I < GuildRankList.Count; I++)
                    {
                        n28 = ((GuildRankList[I]) as TGuildRank).nRankNo;
                        if (n28 == 1)
                        {
                            n2C++;
                            if (n2C > 1)
                            {
                                result = -4;
                                break;
                            }
                        }
                    }
                }
                if (result == 0)
                {
                    // ���ְλ���Ƿ��ظ����Ƿ�
                    for (I = 0; I < GuildRankList.Count; I++)
                    {
                        n28 = ((GuildRankList[I]) as TGuildRank).nRankNo;
                        for (III = I + 1; III < GuildRankList.Count; III++)
                        {
                            if ((((GuildRankList[III]) as TGuildRank).nRankNo == n28) || (n28 <= 0) || (n28 > 99))
                            {
                                result = -7;
                                break;
                            }
                        }
                        if (result != 0)
                        {
                            break;
                        }
                    }
                    // for
                }
                if (result == 0)
                {
                    UpdateRank_ClearRankList(ref m_RankList);
                    m_RankList = GuildRankList;// ������������ְλ��
                    for (I = 0; I < m_RankList.Count; I++)
                    {
                        GuildRank = m_RankList[I];
                        for (III = 0; III < GuildRank.MemberList.Count; III++)
                        {
                            PlayObject = UserEngine.GetPlayObject(GuildRank.MemberList[III]);
                            if (PlayObject != null)
                            {
                                //GuildRank.MemberList[III] = PlayObject;
                                PlayObject.RefRankInfo(GuildRank.nRankNo, GuildRank.sRankName);
                                PlayObject.RefShowName();
                            }
                        }
                    }
                    UpdateGuildFile();
                }
                else
                {
                    UpdateRank_ClearRankList(ref GuildRankList);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TGUild.UpdateRank");
            }
            return result;
        }

        public bool IsNotWarGuild(TGUild Guild)
        {
            bool result;
            int I;
            result = false;
            if (GuildWarList.Count > 0)
            {
                for (I = 0; I < GuildWarList.Count; I++)
                {
                    if (GuildWarList[I].Guild == Guild)
                    {
                        return result;
                    }
                }
            }
            result = true;
            return result;
        }

        public bool AllyGuild(TGUild Guild)
        {
            bool result;
            int I;
            result = false;
            if (GuildAllList.Count > 0)
            {
                for (I = 0; I < GuildAllList.Count; I++)
                {
                    if (GuildAllList[I] == Guild)
                    {
                        return result;
                    }
                }
            }
            GuildAllList.Add(Guild);
            SaveGuildInfoFile();
            result = true;
            return result;
        }

        // �����л�ս
        public TWarGuild AddWarGuild(TGUild Guild)
        {
            TWarGuild result;
            int I;
            TWarGuild WarGuild;
            result = null;
            if (Guild != null)
            {
                if (!IsAllyGuild(Guild))
                {
                    WarGuild = null;
                    if (GuildWarList.Count > 0)
                    {
                        // 20080630
                        for (I = 0; I < GuildWarList.Count; I++)
                        {
                            if (GuildWarList[I].Guild == Guild)
                            {
                                WarGuild = GuildWarList[I];
                                WarGuild.dwWarTick = HUtil32.GetTickCount();
                                // 10800000
                                WarGuild.dwWarTime = M2Share.g_Config.dwGuildWarTime;
                                SendGuildMsg("***" + Guild.sGuildName + "�л�ս������������Сʱ��");
                                break;
                            }
                        }
                    }
                    if (WarGuild == null)
                    {
                        WarGuild = new TWarGuild();
                        WarGuild.Guild = Guild;

                        WarGuild.dwWarTick = HUtil32.GetTickCount();
                        // 10800000
                        WarGuild.dwWarTime = M2Share.g_Config.dwGuildWarTime;
                        GuildWarList.Add(WarGuild);
                        SendGuildMsg("***" + Guild.sGuildName + "�л�ս����ʼ(����Сʱ)");
                    }
                    result = WarGuild;
                }
            }
            RefMemberName();
            UpdateGuildFile();
            return result;
        }

        public void sub_499B4C(TGUild Guild)
        {
            SendGuildMsg("***" + Guild.sGuildName + "�л�ս������");
        }

        private int GetMemberCount()
        {
            int result;
            int I;
            TGuildRank GuildRank;
            result = 0;
            if (m_RankList.Count > 0)
            {
                // 20080630
                for (I = 0; I < m_RankList.Count; I++)
                {
                    GuildRank = m_RankList[I];
                    result += GuildRank.MemberList.Count;
                }
            }
            return result;
        }

        // �л�����
        private bool GetMemgerIsFull()
        {
            bool result;
            result = false;
            if (Count >= M2Share.g_Config.nGuildMemberMaxLimit)
            {
                result = true;
            }
            return result;
        }

        public void StartTeamFight()
        {
            nContestPoint = 0;
            boTeamFight = true;
            TeamFightDeadList.Clear();
        }

        public void EndTeamFight()
        {
            boTeamFight = false;
        }

        public void AddTeamFightMember(string sHumanName)
        {
            //TeamFightDeadList.Add(sHumanName);
        }

        // �л��Ƿ���Ա
        private void SetAuraePoint(int nPoint)
        {
            m_nAurae = nPoint;
            boChanged = true;
        }

        private void SetBuildPoint(int nPoint)
        {
            m_nBuildPoint = nPoint;
            boChanged = true;
        }

        private void SetFlourishPoint(int nPoint)
        {
            m_nFlourishing = nPoint;
            boChanged = true;
        }

        private void SetStabilityPoint(int nPoint)
        {
            m_nStability = nPoint;
            boChanged = true;
        }

        private void SetChiefItemCount(int nPoint)
        {
            m_nChiefItemCount = nPoint;
            boChanged = true;
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}