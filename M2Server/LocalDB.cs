using GameFramework;
using GameFramework.DataBase;
using GameFramework.Repository;
using M2Server.Base;
using M2Server.Mon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

namespace M2Server
{
    public class TDefineInfo
    {
        public string sName;
        public string sText;
    }

    public class TQDDinfo
    {
        public int n00;
        public string s04;
        public TStringList sList;
    }

    public class TGoodFileHeader
    {
        public int nItemCount;
        public int[] Resv;
    }

    internal class LocalDB : GameBase
    {
        public static bool isother = false;
        /// <summary>
        /// 数据库会话管理
        /// </summary>
        private DbSession DBsession;
        private static readonly object syncObject = new object();

        private static LocalDB singleton;

        public static LocalDB GetInstance()
        {
            if (singleton == null)
            {
                lock (syncObject)
                {
                    if (singleton == null)
                    {
                        singleton = new LocalDB();
                    }
                }

            }
            return singleton;
        }

        public LocalDB()
        {
            try
            {
                var obj = (SqlServer2005Repository)Activator.CreateInstance(typeof(SqlServer2005Repository), "Mir2");
                DBsession = obj.GetDbSession();
            }
            catch
            {
                MainOutMessage("初始化数据库失败...");
            }
        }

        /// <summary>
        /// 加载管理员列表
        /// </summary>
        /// <returns></returns>
        public bool LoadAdminList()
        {
            bool result = false;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sIPaddr = string.Empty;
            string sCharName = string.Empty;
            string sData = string.Empty;
            TStringList LoadList;
            TAdminInfo AdminInfo;
            int nLv;
            sFileName = M2Share.g_Config.sEnvirDir + "AdminList.txt";
            if (!File.Exists(sFileName))
            {
                return result;
            }
            // UserEngine.m_AdminList.__Lock();
            try
            {
                UserEngine.m_AdminList.Clear();
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    nLv = -1;
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        if (sLineText[0] == '*')
                        {
                            nLv = 10;
                        }
                        else if (sLineText[0] == '1')
                        {
                            nLv = 9;
                        }
                        else if (sLineText[0] == '2')
                        {
                            nLv = 8;
                        }
                        else if (sLineText[0] == '3')
                        {
                            nLv = 7;
                        }
                        else if (sLineText[0] == '4')
                        {
                            nLv = 6;
                        }
                        else if (sLineText[0] == '5')
                        {
                            nLv = 5;
                        }
                        else if (sLineText[0] == '6')
                        {
                            nLv = 4;
                        }
                        else if (sLineText[0] == '7')
                        {
                            nLv = 3;
                        }
                        else if (sLineText[0] == '8')
                        {
                            nLv = 2;
                        }
                        else if (sLineText[0] == '9')
                        {
                            nLv = 1;
                        }
                        if (nLv > 0)
                        {
                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] { "/", "\\", " ", "\t" });
                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sCharName, new string[] { "/", "\\", " ", "\t" });
                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sIPaddr, new string[] { "/", "\\", " ", "\t" });
                            if ((sCharName == "") || (sIPaddr == ""))
                            {
                                continue;
                            }
                            AdminInfo = new TAdminInfo();
                            AdminInfo.nLv = nLv;
                            AdminInfo.sChrName = sCharName;
                            AdminInfo.sIPaddr = sIPaddr;
                            UserEngine.m_AdminList.Add(AdminInfo);
                        }
                    }
                }
            }
            finally
            {
                //  UserEngine.m_AdminList.UnLock();
            }
            result = true;
            return result;
        }

        /// <summary>
        /// 加载守卫列表
        /// </summary>
        /// <returns></returns>
        public int LoadGuardList()
        {
            int result = -1;
            string s14 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            TStringList tGuardList;
            TBaseObject tGuard;
            string sFileName = M2Share.g_Config.sEnvirDir + "GuardList.txt";
            if (File.Exists(sFileName))
            {
                tGuardList = new TStringList();
                tGuardList.LoadFromFile(sFileName);
                if (tGuardList.Count > 0)
                {
                    for (int I = 0; I < tGuardList.Count; I++)
                    {
                        s14 = tGuardList[I];
                        if ((s14 != "") && (s14[0] != ';'))
                        {
                            s14 = HUtil32.GetValidStrCap(s14, ref s1C, new string[] { " " });
                            if ((s1C != "") && (s1C[0] == '\''))
                            {
                                HUtil32.ArrestStringEx(s1C, "\"", "\"", ref s1C);
                            }
                            s14 = HUtil32.GetValidStr3(s14, ref s20, new string[] { " " });
                            s14 = HUtil32.GetValidStr3(s14, ref s24, new string[] { " ", "," });
                            s14 = HUtil32.GetValidStr3(s14, ref s28, new string[] { " ", ",", ":" });
                            s14 = HUtil32.GetValidStr3(s14, ref s2C, new string[] { " ", ":" });
                            if ((s1C != "") && (s20 != "") && (s2C != ""))
                            {
                                tGuard = UserEngine.RegenMonsterByName(s20, HUtil32.Str_ToInt(s24, 0), HUtil32.Str_ToInt(s28, 0), s1C);
                                if (tGuard != null)
                                {
                                    tGuard.m_btDirection = (byte)HUtil32.Str_ToInt(s2C, 0);
                                }
                            }
                        }
                    }
                }
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// 加载物品数据
        /// </summary>
        /// <returns></returns>
        public unsafe int LoadItemsDB()
        {
            int result = -1;
            int Idx;
            TStdItem* StdItem;
            IDataReader dr = null;
            const string sSQLString = "SELECT IDX,NAME,STDMODE,SHAPE,WEIGHT,ANICOUNT,SOURCE,RESERVED,LOOKS,DURAMAX,AC,AC2,MAC,MAC2,DC,DC2,MC,MC2,SC,SC2,NEED,NEEDLEVEL,PRICE,STOCK FROM TBL_STDITEMS";
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                try
                {
                    foreach (var item in UserEngine.StdItemList)
                    {
                        if (item != null)
                        {
                            Dispose(item);
                        }
                    }
                    UserEngine.StdItemList.Clear();
                    try
                    {
                        dr = DBsession.ExecuteReader(sSQLString);
                    }
                    catch
                    {
                        MainOutMessage("[Exception] 连接数据库发生异常...");
                    }
                    finally
                    {
                        result = -2;
                    }
                    if (dr == null) //2013.04.16 Fixed dr为空时Read报错
                    {
                        return result;
                    }
                    while (dr.Read())
                    {
                        Idx = dr.GetInt32("Idx");// 序号
                        StdItem = (TStdItem*)Marshal.AllocHGlobal(sizeof(TStdItem));
                        HUtil32.ZeroMemory((IntPtr)StdItem, (IntPtr)sizeof(TStdItem));
                        HUtil32.StrToSByteArry(dr.GetString("Name"), StdItem->Name, 14, ref StdItem->NameLen);
                        StdItem->StdMode = dr.GetByte("StdMode");// 分类号
                        StdItem->Shape = dr.GetByte("Shape");// 装备外观
                        StdItem->Weight = dr.GetByte("Weight");// 重量
                        StdItem->AniCount = HUtil32.IntToByte(dr.GetInt32("AniCount"));// 保留
                        StdItem->Source = dr.GetSByte("Source");
                        StdItem->Reserved = HUtil32.IntToByte(dr.GetInt32("Reserved"));// 保留
                        StdItem->Looks = dr.GetUInt16("Looks");// 物品外观
                        StdItem->DuraMax = dr.GetUInt16("DuraMax");// 持久力
                        StdItem->Reserved1 = 0;
                        StdItem->AC = TStdItem.MakeAC(dr.GetInt32("Ac"), dr.GetInt32("Ac2"), GameConfig.nItemsACPowerRate);//物理攻击
                        StdItem->MAC = TStdItem.MakeMAC(dr.GetInt32("Mac"), dr.GetInt32("Mac2"), GameConfig.nItemsACPowerRate);//魔法防御
                        StdItem->DC = TStdItem.MakeDC(dr.GetInt32("Dc"), dr.GetInt32("Dc2"), GameConfig.nItemsPowerRate);//物理防御
                        StdItem->MC = TStdItem.MakeMC(dr.GetInt32("Mc"), dr.GetInt32("Mc2"), GameConfig.nItemsPowerRate);//魔法攻击
                        StdItem->SC = TStdItem.MakeSC(dr.GetInt32("Sc"), dr.GetInt32("Sc2"), GameConfig.nItemsPowerRate);//道术
                        StdItem->Need = dr.GetInt32("Need");// 附加条件
                        StdItem->NeedLevel = dr.GetInt32("NeedLevel");// 需要等级
                        StdItem->Price = dr.GetInt32("Price");// 价格
                        StdItem->Stock = dr.GetInt32("Stock");// 库存
                        StdItem->NeedIdentify = M2Share.GetGameLogItemNameList(dr.GetString("Name"));
                        if (UserEngine.StdItemList.Count == Idx)
                        {
                            UserEngine.StdItemList.Add((IntPtr)StdItem);
                            result = 1;
                        }
                        else
                        {
                            MainOutMessage(string.Format("加载物品[Idx:{0} Name:{1}]数据失败！！！", Idx, dr.GetString("Name")));
                            result = -100;
                            return result;
                        }
                    }
                    M2Share.g_boGameLogGold = M2Share.GetGameLogItemNameList(M2Share.sSTRING_GOLDNAME) == 1;
                    M2Share.g_boGameLogHumanDie = M2Share.GetGameLogItemNameList(GameMsgDef.g_sHumanDieEvent) == 1;
                    M2Share.g_boGameLogGameGold = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameGoldName) == 1;
                    M2Share.g_boGameLogGameDiaMond = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameDiaMond) == 1;// 是否写入日志(调整金刚石)
                    M2Share.g_boGameLogGameGird = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameGird) == 1;// 是否写入日志(调整灵符)
                    M2Share.g_boGameLogGameGlory = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGameGlory) == 1;// 是否写入日志(调整荣誉值)
                    M2Share.g_boGameLogGamePoint = M2Share.GetGameLogItemNameList(M2Share.g_Config.sGamePointName) == 1;
                }
                finally
                {
                    if (dr != null)
                    {
                        dr.Close();
                        dr.Dispose();
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 加载魔法数据
        /// </summary>
        /// <returns></returns>
        public unsafe int LoadMagicDB()
        {
            int result = -1;
            TMagic* Magic = null;
            TMagic* OldMagic = null;
            IList<IntPtr> OldMagicList;
            IDataReader dr = null;
            const string sSQLString = "SELECT MAGID,MAGNAME,EFFECTTYPE,EFFECT,SPELL,POWER,MAXPOWER,JOB,NEEDL1,NEEDL2,NEEDL3,L1TRAIN,L2TRAIN,L3TRAIN,DELAY,DEFSPELL,DEFPOWER,DEFMAXPOWER,DESCR FROM TBL_MAGIC";
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                UserEngine.SwitchMagicList();
                foreach (var item in UserEngine.m_MagicList)
                {
                    if (item != null)
                    {
                        Marshal.FreeHGlobal(item);
                    }
                }
                UserEngine.m_MagicList.Clear();
                try
                {
                    dr = DBsession.ExecuteReader(sSQLString);
                }
                catch
                {
                    MainOutMessage("[Exception] 连接数据库发生异常...");
                }
                finally
                {
                    result = -2;
                }
                if (dr == null) //2013.04.16 Fixed dr为空时Read报错
                {
                    return result;
                }
                while (dr.Read())
                {
                    try
                    {
                        Magic = (TMagic*)Marshal.AllocHGlobal(sizeof(TMagic));
                        HUtil32.ZeroMemory((IntPtr)Magic, (IntPtr)sizeof(TMagic));
                        Magic->wMagicId = dr.GetUInt16("MagId");
                        HUtil32.StrToSByteArry(dr.GetString("MagName"), Magic->sMagicName, 12, ref Magic->MagicNameLen);
                        Magic->btEffectType = dr.GetByte("EffectType");
                        Magic->btEffect = dr.GetByte("Effect");
                        Magic->wSpell = dr.GetUInt16("Spell");
                        Magic->wPower = dr.GetUInt16("Power");
                        Magic->wMaxPower = dr.GetUInt16("MaxPower");
                        Magic->btJob = dr.GetByte("Job");
                        Magic->TrainLevel[0] = dr.GetByte("NeedL1");
                        Magic->TrainLevel[1] = dr.GetByte("NeedL2");
                        Magic->TrainLevel[2] = dr.GetByte("NeedL3");
                        Magic->TrainLevel[3] = dr.GetByte("NeedL3");
                        Magic->MaxTrain[0] = dr.GetByte("L1Train");
                        Magic->MaxTrain[1] = dr.GetInt32("L2Train");
                        Magic->MaxTrain[2] = dr.GetInt32("L3Train");
                        Magic->MaxTrain[3] = dr.GetInt32("L2Train");
                        Magic->btTrainLv = 3;
                        Magic->dwDelayTime = dr.GetUInt32("Delay");
                        Magic->btDefSpell = dr.GetByte("DefSpell");
                        Magic->btDefPower = dr.GetByte("DefPower");
                        Magic->btDefMaxPower = dr.GetByte("DefMaxPower");
                        HUtil32.StrToSByteArry(dr.GetString("Descr"), Magic->sDescr, 18, ref Magic->DescrLen);
                        if (Magic->wMagicId > 0)
                        {
                            UserEngine.m_MagicList.Add((IntPtr)Magic);
                        }
                        else
                        {
                            Marshal.FreeHGlobal((IntPtr)Magic);
                        }
                    }
                    catch
                    {
                        result = -100;
                    }
                    result = 1;
                }

                if (UserEngine.OldMagicList.Count > 0)
                {
                    OldMagicList = UserEngine.OldMagicList;
                    if (OldMagicList.Count > 0)
                    {
                        for (int I = 0; I < OldMagicList.Count; I++)
                        {
                            OldMagic = (TMagic*)OldMagicList[I];
                            if (OldMagic->wMagicId >= 100)
                            {
                                Magic->wMagicId = OldMagic->wMagicId;
                                HUtil32.StrToSByteArry(HUtil32.SBytePtrToString(OldMagic->sMagicName, 0, OldMagic->MagicNameLen),
                                    Magic->sMagicName, 12, ref Magic->MagicNameLen);
                                Magic->btEffectType = OldMagic->btEffectType;
                                Magic->btEffect = OldMagic->btEffect;
                                Magic->wSpell = OldMagic->wSpell;
                                Magic->wPower = OldMagic->wPower;
                                Magic->TrainLevel[0] = OldMagic->TrainLevel[0];
                                Magic->TrainLevel[1] = OldMagic->TrainLevel[1];
                                Magic->TrainLevel[2] = OldMagic->TrainLevel[2];
                                Magic->TrainLevel[3] = OldMagic->TrainLevel[3];
                                Magic->MaxTrain[0] = OldMagic->MaxTrain[0];
                                Magic->MaxTrain[1] = OldMagic->MaxTrain[1];
                                Magic->MaxTrain[2] = OldMagic->MaxTrain[2];
                                Magic->MaxTrain[3] = OldMagic->MaxTrain[3];
                                Magic->btTrainLv = OldMagic->btTrainLv;
                                Magic->btJob = OldMagic->btJob;
                                Magic->dwDelayTime = OldMagic->dwDelayTime;
                                Magic->btDefSpell = OldMagic->btDefSpell;
                                Magic->btDefPower = OldMagic->btDefPower;
                                Magic->wMaxPower = OldMagic->wMaxPower;
                                Magic->btDefMaxPower = OldMagic->btDefMaxPower;
                                HUtil32.StrToSByteArry(HUtil32.SBytePtrToString(OldMagic->sDescr, 0, Magic->DescrLen), Magic->sDescr, 18, ref Magic->DescrLen);
                                UserEngine.m_MagicList.Add((IntPtr)Magic);
                            }
                        }
                    }
                    UserEngine.m_boStartLoadMagic = false;
                }
                UserEngine.m_boStartLoadMagic = false;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 加载炼药列表
        /// </summary>
        /// <returns></returns>
        public int LoadMakeItem()
        {
            int result = -1;
            int n14;
            string s18;
            string s20 = string.Empty;
            string s24 = string.Empty;
            TStringList LoadList;
            TStringList List28;
            string sFileName = M2Share.g_Config.sEnvirDir + "MakeItem.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                List28 = null;
                s24 = "";
                for (int I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        if (s18[0] == '[')
                        {
                            if (List28 != null)
                            {
                                //  M2Share.g_MakeItemList.Add(s24, List28);
                            }
                            List28 = new TStringList();
                            HUtil32.ArrestStringEx(s18, "[", "]", ref s24);
                        }
                        else
                        {
                            if (List28 != null)
                            {
                                s18 = HUtil32.GetValidStr3(s18, ref s20, new string[] { " ", "\t" });
                                n14 = HUtil32.Str_ToInt(s18.Trim(), 1);
                                // List28.Add(s20, ((n14) as Object));
                            }
                        }
                    }
                }
                if (List28 != null)
                {
                    // M2Share.g_MakeItemList.Add(s24, List28);
                }
                result = 1;
            }
            return result;
        }

        public TMerchant LoadMapInfo_LoadMapQuest(string sName)
        {
            TMerchant result;
            TMerchant QuestNPC;
            QuestNPC = new TMerchant();
            QuestNPC.m_sMapName = "0";
            QuestNPC.m_nCurrX = 0;
            QuestNPC.m_nCurrY = 0;
            QuestNPC.m_sCharName = sName;
            QuestNPC.m_nFlag = 0;
            QuestNPC.m_wAppr = 0;
            QuestNPC.m_sFilePath = "MapQuest_def\\";
            QuestNPC.m_boIsHide = true;
            QuestNPC.m_boIsQuest = false;
            UserEngine.QuestNPCList.Add(QuestNPC);
            result = QuestNPC;
            return result;
        }

        public void LoadMapInfo_LoadSubMapInfo(TStringList LoadList, string sFileName)
        {
            string sFilePatchName;
            string sFileDir;
            TStringList LoadMapList;
            sFileDir = M2Share.g_Config.sEnvirDir + "MapInfo\\";
            if (!Directory.Exists(sFileDir))
            {
                Directory.CreateDirectory(sFileDir);
            }
            sFilePatchName = sFileDir + sFileName;
            if (File.Exists(sFilePatchName))
            {
                LoadMapList = new TStringList();
                LoadMapList.LoadFromFile(sFilePatchName);
                for (int I = 0; I < LoadMapList.Count; I++)
                {
                    // LoadList.Add(LoadMapList[I]);
                }
                LoadMapList.Dispose();
                Dispose(LoadMapList);
                //LoadMapList.Free;
            }
        }

        /// <summary>
        /// // 判断有几个')'号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int LoadMapInfo_IsStrCount(string str)
        {
            int result = 0;
            if (str.Length <= 0)
            {
                return result;
            }
            for (int i = 0; i <= str.Length - 1; i++)
            {
                if ((new ArrayList(new string[] { ")" }).Contains(str[i])))
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// 加载地图配置
        /// </summary>
        /// <returns></returns>
        public int LoadMapInfo()
        {
            int result;
            string sFileName;
            TStringList LoadList;
            int I;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            string sMapName;
            string sMainMapName = string.Empty;
            string s44;
            string sMapDesc = string.Empty;
            string s4C;
            string sReConnectMap = string.Empty;
            int n14;
            int n18;
            int n1C;
            int n20;
            int nServerIndex;
            TMapFlag MapFlag = null;
            TMerchant QuestNPC;
            string sMapInfoFile;
            result = -1;
            sFileName = M2Share.g_Config.sEnvirDir + "MapInfo.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count < 0)
                {
                    return result;
                }
                I = 0;
                while (true)
                {
                    if (I >= LoadList.Count)
                    {
                        break;
                    }
                    if ((s34 != "") && (s34[0] != '[') && (s34[0] != ';'))
                    {
                        if (HUtil32.CompareLStr("loadmapinfo", LoadList[I], "loadmapinfo".Length))
                        {
                            sMapInfoFile = HUtil32.GetValidStr3(LoadList[I], ref s30, new string[] { " ", "\t" });
                            LoadList.RemoveAt(I);
                            if (sMapInfoFile != "")
                            {
                                LoadMapInfo_LoadSubMapInfo(LoadList, sMapInfoFile);
                            }
                        }
                    }
                    I++;
                }
                result = 1;
                //加载地图设置
                for (I = 0; I < LoadList.Count; I++)
                {
                    s30 = LoadList[I];
                    if ((s30 != "") && (s30[0] == '['))
                    {
                        sMapName = "";
                        s30 = HUtil32.ArrestStringEx(s30, "[", "]", ref sMapName);
                        sMapDesc = HUtil32.GetValidStrCap(sMapName, ref sMapName, new string[] { " ", ",", "\t" });
                        if (sMapName.IndexOf("<") > 0)//加入对<>地图的识别
                        {
                            sMapName = HUtil32.ArrestStringEx(sMapName, "<", ">", ref sMainMapName);
                        }
                        else
                        {
                            sMainMapName = HUtil32.GetValidStr3(sMapName, ref sMapName, new string[] { "|", "/", "\\", "\t" }).Trim();//获取重复利用地图
                        }
                        if ((sMapDesc != "") && (sMapDesc[0] == '\'')) // 获取重复利用地图
                        {
                            HUtil32.ArrestStringEx(sMapDesc, "\"", "\"", ref sMapDesc);
                        }
                        s4C = HUtil32.GetValidStr3(sMapDesc, ref sMapDesc, new string[] { " ", ",", "\t" }).Trim();
                        nServerIndex = HUtil32.Str_ToInt(s4C, 0);
                        if (sMapName == "")
                        {
                            continue;
                        }
                        QuestNPC = null;
                        MapFlag = new TMapFlag();
                        MapFlag.boSAFE = false;
                        MapFlag.nNEEDSETONFlag = -1;
                        MapFlag.nNeedONOFF = -1;
                        MapFlag.sUnAllowStdItemsText = "";
                        MapFlag.sUnAllowMagicText = "";
                        MapFlag.boAutoMakeMonster = false;
                        MapFlag.boNOTALLOWUSEMAGIC = false;
                        MapFlag.boFIGHTPK = false;
                        while (true)
                        {
                            if (s30 == "")
                            {
                                break;
                            }
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            if (s34 == "")
                            {
                                break;
                            }
                            MapFlag.nMUSICID = -1;
                            MapFlag.sMUSICName = "";
                            if ((s34).ToLower().CompareTo(("SAFE").ToLower()) == 0)
                            {
                                MapFlag.boSAFE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("DARK").ToLower()) == 0)
                            {
                                MapFlag.boDARK = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT").ToLower()) == 0)
                            {
                                MapFlag.boFIGHT = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT2").ToLower()) == 0)  // PK掉装备地图
                            {
                                MapFlag.boFIGHT2 = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT3").ToLower()) == 0)
                            {
                                MapFlag.boFIGHT3 = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHT4").ToLower()) == 0)// 挑战地图
                            {
                                MapFlag.boFIGHT4 = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("DAY").ToLower()) == 0)
                            {
                                MapFlag.boDAY = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("QUIZ").ToLower()) == 0)
                            {
                                MapFlag.boQUIZ = true;
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NORECONNECT", 11))
                            {
                                MapFlag.boNORECONNECT = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref sReConnectMap);
                                MapFlag.sReConnectMap = sReConnectMap;
                                if (MapFlag.sReConnectMap == "")
                                {
                                    result = -11;
                                }
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "CHECKQUEST", 10))
                            {
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                QuestNPC = LoadMapInfo_LoadMapQuest(s38);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NEEDSET_ON", 10))
                            {
                                MapFlag.nNeedONOFF = 1;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nNEEDSETONFlag = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NEEDSET_OFF", 11))
                            {
                                MapFlag.nNeedONOFF = 0;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nNEEDSETONFlag = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "MUSIC", 5))
                            {
                                MapFlag.boMUSIC = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nMUSICID = HUtil32.Str_ToInt(s38, -1);
                                MapFlag.sMUSICName = s38;
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "EXPRATE", 7))
                            {
                                MapFlag.boEXPRATE = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nEXPRATE = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKWINLEVEL", 10))
                            {
                                MapFlag.boPKWINLEVEL = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKWINLEVEL = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKWINEXP", 8))
                            {
                                MapFlag.boPKWINEXP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKWINEXP = (uint)HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKLOSTLEVEL", 11))
                            {
                                MapFlag.boPKLOSTLEVEL = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKLOSTLEVEL = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "PKLOSTEXP", 9))
                            {
                                MapFlag.boPKLOSTEXP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nPKLOSTEXP = (uint)HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "DECHP", 5))
                            {
                                MapFlag.boDECHP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nDECHPPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nDECHPTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "INCHP", 5))
                            {
                                MapFlag.boINCHP = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nINCHPPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nINCHPTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "DECGAMEGOLD", 11))
                            {
                                MapFlag.boDECGAMEGOLD = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nDECGAMEGOLD = (uint)HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nDECGAMEGOLDTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "DECGAMEPOINT", 12))
                            {
                                MapFlag.boDECGAMEPOINT = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nDECGAMEPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nDECGAMEPOINTTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "KILLFUNC", 8))// 地图杀人触发
                            {
                                MapFlag.boKILLFUNC = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nKILLFUNC = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "INCGAMEGOLD", 11))
                            {
                                MapFlag.boINCGAMEGOLD = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nINCGAMEGOLD = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nINCGAMEGOLDTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "INCGAMEPOINT", 12))
                            {
                                MapFlag.boINCGAMEPOINT = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nINCGAMEPOINT = HUtil32.Str_ToInt(HUtil32.GetValidStr3(s38, ref s38, new string[] { "/" }), -1);
                                MapFlag.nINCGAMEPOINTTIME = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            // ------------------------------------------------------------------------------
                            if (HUtil32.CompareLStr(s34, "NEEDLEVELTIME", 13))// 雪域地图传送,判断等级,地图时间
                            {
                                MapFlag.boNEEDLEVELTIME = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nNEEDLEVELPOINT = HUtil32.Str_ToInt(s38, 0);// 进地图最低等级
                                continue;
                            }
                            // 地图参数 NOCALLHERO (禁止召唤英雄，已召唤英雄将自动消失) 
                            if ((s34).ToLower().CompareTo(("NOCALLHERO").ToLower()) == 0)
                            {
                                MapFlag.boNoCALLHERO = true;
                                continue;
                            }
                            // 禁止英雄守护
                            if ((s34).ToLower().CompareTo(("NOHEROPROTECT").ToLower()) == 0)
                            {
                                MapFlag.boNOHEROPROTECT = true;
                                continue;
                            }
                            // 地图参数 NODROPITEM 禁止死亡掉物品
                            if ((s34).ToLower().CompareTo(("NODROPITEM").ToLower()) == 0)
                            {
                                MapFlag.boNODROPITEM = true;
                                continue;
                            }
                            // 地图参数 MISSION (不允许使用任何物品和技能，并且宝宝在该地图会自动消失，不能攻击) 
                            if ((s34).ToLower().CompareTo(("MISSION").ToLower()) == 0)
                            {
                                MapFlag.boMISSION = true;
                                continue;
                            }
                            // ------------------------------------------------------------------------------
                            if ((s34).ToLower().CompareTo(("RUNHUMAN").ToLower()) == 0)
                            {
                                MapFlag.boRUNHUMAN = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("RUNMON").ToLower()) == 0)
                            {
                                MapFlag.boRUNMON = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NEEDHOLE").ToLower()) == 0)
                            {
                                MapFlag.boNEEDHOLE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NORECALL").ToLower()) == 0)
                            {
                                MapFlag.boNORECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOGUILDRECALL").ToLower()) == 0)
                            {
                                MapFlag.boNOGUILDRECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NODEARRECALL").ToLower()) == 0)
                            {
                                MapFlag.boNODEARRECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOMASTERRECALL").ToLower()) == 0)
                            {
                                MapFlag.boNOMASTERRECALL = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NORANDOMMOVE").ToLower()) == 0)
                            {
                                MapFlag.boNORANDOMMOVE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NODRUG").ToLower()) == 0)
                            {
                                MapFlag.boNODRUG = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOMANNOMON").ToLower()) == 0)
                            {
                                MapFlag.boNoManNoMon = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("MINE").ToLower()) == 0)
                            {
                                MapFlag.boMINE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("NOPOSITIONMOVE").ToLower()) == 0)
                            {
                                MapFlag.boNOPOSITIONMOVE = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("AUTOMAKEMONSTER").ToLower()) == 0)
                            {
                                MapFlag.boAutoMakeMonster = true;
                                continue;
                            }
                            if ((s34).ToLower().CompareTo(("FIGHTPK").ToLower()) == 0)
                            {
                                MapFlag.boFIGHTPK = true;
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "THUNDER", 7))
                            {
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nThunder = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "LAVA", 4))// 地上冒岩浆
                            {
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.nLava = HUtil32.Str_ToInt(s38, -1);
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NOTALLOWUSEMAGIC", 16))// 增加不允许使用魔法
                            {
                                MapFlag.boNOTALLOWUSEMAGIC = true;
                                HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                MapFlag.sUnAllowMagicText = s38.Trim();
                                continue;
                            }
                            if (HUtil32.CompareLStr(s34, "NOTALLOWUSEITEMS", 16)) // 增加不允许使用物品
                            {
                                MapFlag.boUnAllowStdItems = true;
                                if (LoadMapInfo_IsStrCount(s34) > 1)
                                {
                                    // 判断有几个')'
                                    s38 = s34.Substring(s34.IndexOf("(") + 1 - 1, s34.Length - (s34.IndexOf("(") + 1));
                                }
                                else
                                {
                                    HUtil32.ArrestStringEx(s34, "(", ")", ref s38);
                                }
                                MapFlag.sUnAllowStdItemsText = s38.Trim();
                                continue;
                            }
                        }
                        if (M2Share.g_MapManager.AddMapInfo(sMapName, sMainMapName, sMapDesc, nServerIndex, MapFlag, QuestNPC) == null)//添加到游戏地图列表
                        {
                            result = -10;
                        }
                    }
                    else
                    {
                        // 加载地图连接点
                        if ((s30 != "") && (s30[0] != '[') && (s30[0] != ';'))
                        {
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            sMapName = s34;
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            n14 = HUtil32.Str_ToInt(s34, 0);
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            n18 = HUtil32.Str_ToInt(s34, 0);
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "-", ">", "\t" });
                            s44 = s34;
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", "\t" });
                            n1C = HUtil32.Str_ToInt(s34, 0);
                            s30 = HUtil32.GetValidStr3(s30, ref s34, new string[] { " ", ",", ";", "\t" });
                            n20 = HUtil32.Str_ToInt(s34, 0);
                            M2Share.g_MapManager.AddMapRoute(sMapName, n14, n18, s44, n1C, n20);
                        }
                    }
                }
            }
            return result;
        }

        public void QFunctionNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList SaveList;
            string sShowFile;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def + "QFunction-0.txt";
                sShowFile = HUtil32.ReplaceChar(sScriptFile, '\\', '/');
                sScritpDir = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def;
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    SaveList = new TStringList();
                    SaveList.Add(";此脚为功能脚本，用于实现各种与脚本有关的功能");
                    SaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_FunctionNPC = new TMerchant();
                    M2Share.g_FunctionNPC.m_sMapName = "0";
                    M2Share.g_FunctionNPC.m_nCurrX = 0;
                    M2Share.g_FunctionNPC.m_nCurrY = 0;
                    M2Share.g_FunctionNPC.m_sCharName = "QFunction";
                    M2Share.g_FunctionNPC.m_nFlag = 0;
                    M2Share.g_FunctionNPC.m_wAppr = 0;
                    M2Share.g_FunctionNPC.m_sFilePath = M2Share.sMarket_Def;
                    M2Share.g_FunctionNPC.m_sScript = "QFunction";
                    M2Share.g_FunctionNPC.m_boIsHide = true;
                    M2Share.g_FunctionNPC.m_boIsQuest = false;
                    UserEngine.AddMerchant(M2Share.g_FunctionNPC);
                }
                else
                {
                    M2Share.g_FunctionNPC = null;
                }
            }
            catch
            {
                M2Share.g_FunctionNPC = null;
            }
        }

        public void QBatterNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList SaveList;
            string sShowFile;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def + "QBatter-0.txt";
                sShowFile = HUtil32.ReplaceChar(sScriptFile, '\\', '/');
                sScritpDir = M2Share.g_Config.sEnvirDir + M2Share.sMarket_Def;
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    SaveList = new TStringList();
                    SaveList.Add(";此脚本为连击功能脚本");
                    SaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_BatterNPC = new TMerchant();
                    M2Share.g_BatterNPC.m_sMapName = "0";
                    M2Share.g_BatterNPC.m_nCurrX = 0;
                    M2Share.g_BatterNPC.m_nCurrY = 0;
                    M2Share.g_BatterNPC.m_sCharName = "QBatter";
                    M2Share.g_BatterNPC.m_nFlag = 0;
                    M2Share.g_BatterNPC.m_wAppr = 0;
                    M2Share.g_BatterNPC.m_sFilePath = M2Share.sMarket_Def;
                    M2Share.g_BatterNPC.m_sScript = "QBatter";
                    M2Share.g_BatterNPC.m_boIsHide = true;
                    M2Share.g_BatterNPC.m_boIsQuest = false;
                    UserEngine.AddMerchant(M2Share.g_BatterNPC);
                }
                else
                {
                    M2Share.g_BatterNPC = null;
                }
            }
            catch
            {
                M2Share.g_BatterNPC = null;
            }
        }

        public void QMangeNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList SaveList;
            string sShowFile;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + "MapQuest_def\\" + "QManage.txt";
                sShowFile = HUtil32.ReplaceChar(sScriptFile, '\\', '/');
                sScritpDir = M2Share.g_Config.sEnvirDir + "MapQuest_def\\";
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    SaveList = new TStringList();
                    SaveList.Add(";此脚为登录脚本，人物每次登录时都会执行此脚本，所有人物初始设置都可以放在此脚本中。");
                    SaveList.Add(";修改脚本内容，可用@ReloadManage命令重新加载该脚本，不须重启程序。");
                    SaveList.Add("[@Login]");
                    SaveList.Add("#if");
                    SaveList.Add("#act");
                    SaveList.Add(";设置10倍杀怪经验");
                    SaveList.Add(";CANGETEXP 1 10");
                    SaveList.Add("#say");
                    SaveList.Add("服务端自动创建的脚本文件，欢迎进入本游戏！！！\\ \\");
                    SaveList.Add("<关闭/@exit> \\ \\");
                    SaveList.Add("登录脚本文件位于: \\");
                    SaveList.Add(sShowFile + "\\");
                    SaveList.Add("脚本内容请自行按自己的要求修改。");
                    SaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_ManageNPC = new TMerchant();
                    M2Share.g_ManageNPC.m_sMapName = "0";
                    M2Share.g_ManageNPC.m_nCurrX = 0;
                    M2Share.g_ManageNPC.m_nCurrY = 0;
                    M2Share.g_ManageNPC.m_sCharName = "QManage";
                    M2Share.g_ManageNPC.m_nFlag = 0;
                    M2Share.g_ManageNPC.m_wAppr = 0;
                    M2Share.g_ManageNPC.m_sFilePath = "MapQuest_def\\";
                    M2Share.g_ManageNPC.m_boIsHide = true;
                    M2Share.g_ManageNPC.m_boIsQuest = false;
                    UserEngine.QuestNPCList.Add(M2Share.g_ManageNPC);
                }
                else
                {
                    M2Share.g_ManageNPC = null;
                }
            }
            catch
            {
                M2Share.g_ManageNPC = null;
            }
        }

        public void RobotNPC()
        {
            string sScriptFile;
            string sScritpDir;
            TStringList tSaveList;
            try
            {
                sScriptFile = M2Share.g_Config.sEnvirDir + "Robot_def\\RobotManage.txt";
                sScritpDir = M2Share.g_Config.sEnvirDir + "Robot_def\\";
                if (!Directory.Exists(sScritpDir))
                {
                    Directory.CreateDirectory((sScritpDir as string));
                }
                if (!File.Exists(sScriptFile))
                {
                    tSaveList = new TStringList();
                    tSaveList.Add(";此脚为机器人专用脚本，用于机器人处理功能用的脚本。");
                    tSaveList.SaveToFile(sScriptFile);
                }
                if (File.Exists(sScriptFile))
                {
                    M2Share.g_RobotNPC = new TMerchant();
                    M2Share.g_RobotNPC.m_sMapName = "0";
                    M2Share.g_RobotNPC.m_nCurrX = 0;
                    M2Share.g_RobotNPC.m_nCurrY = 0;
                    M2Share.g_RobotNPC.m_sCharName = "RobotManage";
                    M2Share.g_RobotNPC.m_nFlag = 0;
                    M2Share.g_RobotNPC.m_wAppr = 0;
                    M2Share.g_RobotNPC.m_sFilePath = "Robot_def\\";
                    M2Share.g_RobotNPC.m_boIsHide = true;
                    M2Share.g_RobotNPC.m_boIsQuest = false;
                    UserEngine.QuestNPCList.Add(M2Share.g_RobotNPC);
                }
                else
                {
                    M2Share.g_RobotNPC = null;
                }
            }
            catch
            {
                M2Share.g_RobotNPC = null;
            }
        }

        /// <summary>
        /// 加载地图事件
        /// </summary>
        /// <returns></returns>
        public int LoadMapEvent()
        {
            int result;
            string sFileName;
            string tStr;
            TStringList tMapEventList;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s36 = string.Empty;
            string s38 = string.Empty;
            string s40 = string.Empty;
            string s42 = string.Empty;
            string s44 = string.Empty;
            string s46 = string.Empty;
            string sRange = string.Empty;
            TMapEvent MapEvent;
            TEnvirnoment Map;
            result = 1;
            sFileName = M2Share.g_Config.sEnvirDir + "MapEvent.txt";
            if (File.Exists(sFileName))
            {
                tMapEventList = new TStringList();
                tMapEventList.LoadFromFile(sFileName);
                if (tMapEventList.Count > 0)
                {
                    for (int I = 0; I < tMapEventList.Count; I++)
                    {
                        tStr = tMapEventList[I];
                        if ((tStr != "") && (tStr[0] != ';'))
                        {
                            tStr = HUtil32.GetValidStr3(tStr, ref s18, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s1C, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s20, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref sRange, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s24, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s28, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s2C, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s30, new string[] { " ", "\t" });
                            if ((s18 != "") && (s1C != "") && (s20 != "") && (s30 != ""))
                            {
                                Map = M2Share.g_MapManager.FindMap(s18);
                                if (Map != null)
                                {
                                    MapEvent = new TMapEvent();
                                    MapEvent.m_MapFlag = new TQuestUnitStatus();
                                    MapEvent.m_Condition = new TMapCondition();
                                    MapEvent.m_StartScript = new TStartScript();
                                    MapEvent.m_sMapName = s18.Trim();
                                    MapEvent.m_nCurrX = HUtil32.Str_ToInt(s1C, 0);
                                    MapEvent.m_nCurrY = HUtil32.Str_ToInt(s20, 0);
                                    MapEvent.m_nRange = HUtil32.Str_ToInt(sRange, 0);
                                    s24 = HUtil32.GetValidStr3(s24, ref s34, new string[] { ":", "\t" });
                                    s24 = HUtil32.GetValidStr3(s24, ref s36, new string[] { ":", "\t" });
                                    MapEvent.m_MapFlag.nQuestUnit = HUtil32.Str_ToInt(s34, 0);
                                    if (HUtil32.Str_ToInt(s36, 0) != 0)
                                    {
                                        MapEvent.m_MapFlag.boOpen = true;
                                    }
                                    else
                                    {
                                        MapEvent.m_MapFlag.boOpen = false;
                                    }
                                    s28 = HUtil32.GetValidStr3(s28, ref s38, new string[] { ":", "\t" });
                                    s28 = HUtil32.GetValidStr3(s28, ref s40, new string[] { ":", "\t" });
                                    s28 = HUtil32.GetValidStr3(s28, ref s42, new string[] { ":", "\t" });
                                    MapEvent.m_Condition.nHumStatus = HUtil32.Str_ToInt(s38, 0);
                                    MapEvent.m_Condition.sItemName = s40.Trim();
                                    if (HUtil32.Str_ToInt(s42, 0) != 0)
                                    {
                                        MapEvent.m_Condition.boNeedGroup = true;
                                    }
                                    else
                                    {
                                        MapEvent.m_Condition.boNeedGroup = false;
                                    }
                                    MapEvent.m_nRandomCount = HUtil32.Str_ToInt(s2C, 999999);
                                    s30 = HUtil32.GetValidStr3(s30, ref s44, new string[] { ":", "\t" });
                                    s30 = HUtil32.GetValidStr3(s30, ref s46, new string[] { ":", "\t" });
                                    MapEvent.m_StartScript.nLable = HUtil32.Str_ToInt(s44, 0);
                                    MapEvent.m_StartScript.sLable = s46.Trim();
                                    switch (MapEvent.m_Condition.nHumStatus)
                                    {
                                        case 1:
                                            M2Share.g_MapEventListOfDropItem.Add(MapEvent);
                                            break;
                                        case 2:
                                            M2Share.g_MapEventListOfPickUpItem.Add(MapEvent);
                                            break;
                                        case 3:
                                            M2Share.g_MapEventListOfMine.Add(MapEvent);
                                            break;
                                        case 4:
                                            M2Share.g_MapEventListOfWalk.Add(MapEvent);
                                            break;
                                        case 5:
                                            M2Share.g_MapEventListOfRun.Add(MapEvent);
                                            break;
                                        default:
                                            Dispose(MapEvent);
                                            break;
                                    }
                                }
                                else
                                {
                                    result = -I;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public int LoadMapQuest()
        {
            int result;
            string sFileName;
            string tStr;
            TStringList tMapQuestList;
            int I;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            int n38;
            int n3C;
            bool boGrouped;
            TEnvirnoment Map;
            result = 1;
            sFileName = M2Share.g_Config.sEnvirDir + "MapQuest.txt";
            if (File.Exists(sFileName))
            {
                tMapQuestList = new TStringList();
                try
                {

                    tMapQuestList.LoadFromFile(sFileName);
                    if (tMapQuestList.Count > 0)
                    {
                        for (I = 0; I < tMapQuestList.Count; I++)
                        {
                            tStr = tMapQuestList[I];
                            if ((tStr != "") && (tStr[0] != ';'))
                            {
                                tStr = HUtil32.GetValidStr3(tStr, ref s18, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s1C, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s20, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s24, new string[] { " ", "\t" });
                                if ((s24 != "") && (s24[0] == '\''))
                                {
                                    HUtil32.ArrestStringEx(s24, "\"", "\"", ref s24);
                                }
                                tStr = HUtil32.GetValidStr3(tStr, ref s28, new string[] { " ", "\t" });
                                if ((s28 != "") && (s28[0] == '\''))
                                {
                                    HUtil32.ArrestStringEx(s28, "\"", "\"", ref s28);
                                }
                                tStr = HUtil32.GetValidStr3(tStr, ref s2C, new string[] { " ", "\t" });
                                tStr = HUtil32.GetValidStr3(tStr, ref s30, new string[] { " ", "\t" });
                                if ((s18 != "") && (s24 != "") && (s2C != ""))
                                {
                                    Map = M2Share.g_MapManager.FindMap(s18);
                                    if (Map != null)
                                    {
                                        HUtil32.ArrestStringEx(s1C, "[", "]", ref s34);
                                        n38 = HUtil32.Str_ToInt(s34, 0);
                                        n3C = HUtil32.Str_ToInt(s20, 0);
                                        if (HUtil32.CompareLStr(s30, "GROUP", 5))
                                        {
                                            boGrouped = true;
                                        }
                                        else
                                        {
                                            boGrouped = false;
                                        }
                                        if (!Map.CreateQuest(n38, n3C, s24, s28, s2C, boGrouped))
                                        {
                                            result = -I;
                                        }
                                    }
                                    else
                                    {
                                        result = -I;
                                    }
                                }
                                else
                                {
                                    result = -I;
                                }
                            }
                        }
                    }
                }
                finally
                {

                }
            }
            QMangeNPC();
            QFunctionNPC();
            RobotNPC();
            QBatterNPC();
            return result;
        }

        /// <summary>
        /// 加载交易NPC配置文件
        /// 脚本   地图     坐标X   坐标Y   NPC显示名   标识   种类  是否城堡  能否移动 是否变色 变色时间
        /// </summary>
        /// <returns></returns>
        public int LoadMerchant()
        {
            int result;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sScript = string.Empty;
            string sMapName = string.Empty;
            string sX = string.Empty;
            string sY = string.Empty;
            string sName = string.Empty;
            string sFlag = string.Empty;
            string sAppr = string.Empty;
            string sIsCalste = string.Empty;
            string sCanMove = string.Empty;
            string sMoveTime = string.Empty;
            string sAutoChangeColor = string.Empty;
            string sAutoChangeColorTime = string.Empty;
            TStringList tMerchantList;
            TMerchant tMerchantNPC;
            sFileName = M2Share.g_Config.sEnvirDir + "Merchant.txt";
            if (File.Exists(sFileName))
            {
                tMerchantList = new TStringList();
                tMerchantList.LoadFromFile(sFileName);
                if (tMerchantList.Count > 0)
                {
                    for (int I = 0; I < tMerchantList.Count; I++)
                    {
                        sLineText = tMerchantList[I].Trim();
                        if ((sLineText != "") && (sLineText[0] != ';'))
                        {
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sScript, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sMapName, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sX, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sY, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sName, new string[] { " ", "\t" });
                            if ((sName != "") && (sName[0] == '\''))
                            {
                                HUtil32.ArrestStringEx(sName, "\'", "\'", ref sName);
                            }
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sFlag, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sAppr, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sIsCalste, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sCanMove, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sMoveTime, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sAutoChangeColor, new string[] { " ", "\t" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sAutoChangeColorTime, new string[] { " ", "\t" });
                            if ((sScript != "") && (sMapName != "") && (sAppr != ""))
                            {
                                tMerchantNPC = new TMerchant();
                                tMerchantNPC.m_sScript = sScript;
                                tMerchantNPC.m_sMapName = sMapName;
                                tMerchantNPC.m_nCurrX = HUtil32.Str_ToInt(sX, 0);
                                tMerchantNPC.m_nCurrY = HUtil32.Str_ToInt(sY, 0);
                                tMerchantNPC.m_sCharName = sName;// NPC名字
                                tMerchantNPC.m_nFlag = (sbyte)HUtil32.Str_ToInt(sFlag, 0);
                                tMerchantNPC.m_wAppr = (ushort)HUtil32.Str_ToInt(sAppr, 0);
                                tMerchantNPC.m_dwMoveTime = (uint)HUtil32.Str_ToInt(sMoveTime, 0);
                                tMerchantNPC.m_dwNpcAutoChangeColorTime = (uint)HUtil32.Str_ToInt(sAutoChangeColorTime, 0) * 1000;
                                if (HUtil32.Str_ToInt(sIsCalste, 0) != 0)
                                {
                                    tMerchantNPC.m_boCastle = true;
                                }
                                if ((HUtil32.Str_ToInt(sCanMove, 0) != 0) && (tMerchantNPC.m_dwMoveTime > 0))
                                {
                                    tMerchantNPC.m_boCanMove = true;
                                }
                                if (HUtil32.Str_ToInt(sAutoChangeColor, 0) != 0)
                                {
                                    tMerchantNPC.m_boNpcAutoChangeColor = true;
                                }
                                UserEngine.AddMerchant(tMerchantNPC);
                            }
                        }
                    }
                }
            }
            result = 1;
            return result;
        }

        /// <summary>
        /// 加载小地图配置
        /// </summary>
        /// <returns></returns>
        public int LoadMinMap()
        {
            int result;
            string sFileName;
            string tStr = string.Empty;
            string sMapNO = string.Empty;
            string sMapIdx = string.Empty;
            TStringList tMapList = null;
            int nIdx;
            result = 0;
            sFileName = M2Share.g_Config.sEnvirDir + "MiniMap.txt";
            if (File.Exists(sFileName))
            {
                if (M2Share.MiniMapList.Count > 0)
                {
                    M2Share.MiniMapList.Clear();
                }
                tMapList = new TStringList();
                tMapList.LoadFromFile(sFileName);
                for (int I = 0; I < tMapList.Count; I++)
                {
                    tStr = tMapList[I];
                    if ((tStr != "") && (tStr[0] != ';'))
                    {
                        tStr = HUtil32.GetValidStr3(tStr, ref sMapNO, new string[] { " ", "\t" });
                        tStr = HUtil32.GetValidStr3(tStr, ref sMapIdx, new string[] { " ", "\t" });
                        nIdx = HUtil32.Str_ToInt(sMapIdx, 0);
                        if (nIdx > 0)
                        {
                            M2Share.MiniMapList.Add(new TMinMapInfo() { nIdx = nIdx, sMapNO = sMapNO });
                        }
                    }
                }
            }
            if (tMapList != null)
            {
                tMapList.Dispose();
            }
            Dispose(tMapList);
            return result;
        }

        public void LoadMonGen_LoadMapGen(TStringList MonGenList, string sFileName)
        {
            string sFilePatchName;
            string sFileDir;
            TStringList LoadList;
            sFileDir = M2Share.g_Config.sEnvirDir + "MonGen\\";
            if (!Directory.Exists(sFileDir))
            {
                Directory.CreateDirectory(sFileDir);
            }
            sFilePatchName = sFileDir + sFileName;
            if (File.Exists(sFilePatchName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFilePatchName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    MonGenList.Add(LoadList[I]);
                }
            }
        }

        /// <summary>
        /// 加载怪物刷新配置
        /// </summary>
        /// <returns></returns>
        public int LoadMonGen()
        {
            int result = 0;
            string sLineText = string.Empty;
            string sData = string.Empty;
            TMonGenInfo MonGenInfo;
            TStringList LoadList;
            string sMapGenFile;
            int I;
            string sFileName = M2Share.g_Config.sEnvirDir + "MonGen.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                I = 0;
                while (true)
                {
                    if (I >= LoadList.Count)
                    {
                        break;
                    }
                    if (HUtil32.CompareLStr("loadgen", LoadList[I], 7))
                    {
                        sMapGenFile = HUtil32.GetValidStr3(LoadList[I], ref sLineText, new string[] { " ", "\t" });
                        LoadList.RemoveAt(I);
                        if (sMapGenFile != "")
                        {
                            LoadMonGen_LoadMapGen(LoadList, sMapGenFile);
                        }
                    }
                    I++;
                }
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        MonGenInfo = new TMonGenInfo();
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// 地图代码
                        MonGenInfo.sMapName = sData;
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// X
                        MonGenInfo.nX = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// Y
                        MonGenInfo.nY = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] { " ", "\t" });// 怪物名
                        if ((sData != "") && (sData[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(sData, "\"", "\"", ref sData);
                        }
                        MonGenInfo.sMonName = sData;
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// 范围
                        MonGenInfo.nRange = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// 数量
                        MonGenInfo.nCount = HUtil32.Str_ToInt(sData, 0);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// 时间
                        MonGenInfo.dwZenTime = (uint)HUtil32.Str_ToInt(sData, 1) * 60000;//
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// 内功怪,打死可以增加内力值 
                        MonGenInfo.boIsNGMon = HUtil32.Str_ToInt(sData, 0) != 0;
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });// 自定义名字的颜色
                        MonGenInfo.nNameColor = (byte)HUtil32.Str_ToInt(sData, 255);
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });
                        MonGenInfo.nMissionGenRate = HUtil32.Str_ToInt(sData, 0);// 集中座标刷新机率 1 -100
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sData, new string[] { " ", "\t" });
                        MonGenInfo.nChangeColorType = HUtil32.Str_ToInt(sData, -1);// 变色
                        if ((MonGenInfo.sMapName != "") && (MonGenInfo.sMonName != "") && (MonGenInfo.dwZenTime != 0) &&
                            (M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, MonGenInfo.sMapName) != null))
                        {
                            MonGenInfo.CertList = new List<TBaseObject>();
                            MonGenInfo.Envir = M2Share.g_MapManager.FindMap(MonGenInfo.sMapName);
                            if (MonGenInfo.Envir != null)
                            {
                                UserEngine.m_MonGenList.Add(MonGenInfo);
                                UserEngine.AddMapMonGenCount(MonGenInfo.sMapName, MonGenInfo.nCount);
                            }
                            else
                            {
                                Dispose(MonGenInfo);
                            }
                        }
                    }
                }
                MonGenInfo = new TMonGenInfo();
                MonGenInfo.sMapName = "";
                MonGenInfo.sMonName = "";
                MonGenInfo.CertList = new List<TBaseObject>();
                MonGenInfo.Envir = null;
                UserEngine.m_MonGenList.Add(MonGenInfo);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// 加载怪物数据
        /// </summary>
        /// <returns></returns>
        public int LoadMonsterDB()
        {
            int result = 0;
            TMonInfo Monster;
            IDataReader dr = null;
            const string sSQLString = "SELECT NAME,RACE,RACEIMG,APPR,LVL,UNDEAD,COOLEYE,EXP,HP,MP,AC,MAC,DC,DCMAX,MC,SC,SPEED,HIT,WALK_SPD,WALKSTEP,WALKWAIT,ATTACK_SPD FROM TBL_MONSTER";
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                if (UserEngine.MonsterList.Count > 0)
                {
                    for (int I = 0; I < UserEngine.MonsterList.Count; I++)
                    {
                        if (UserEngine.MonsterList[I] != null)
                        {
                            Dispose(UserEngine.MonsterList[I]);
                        }
                    }
                    UserEngine.MonsterList.Clear();
                }
                try
                {
                    dr = DBsession.ExecuteReader(sSQLString);
                }
                catch
                {
                    MainOutMessage("[Exception] 打开数据库连接失败...");
                }
                finally
                {
                    result = -1;
                }
                if (dr == null) //2013.04.16 Fixed dr为空时Read报错
                {
                    return result;
                }
                while (dr.Read())
                {
                    Monster = new TMonInfo();
                    Monster.ItemList = new List<TMonItem>();
                    Monster.sName = dr.GetString("NAME");
                    Monster.btRace = dr.GetByte("Race");
                    Monster.btRaceImg = dr.GetByte("RaceImg");
                    Monster.wAppr = dr.GetUInt16("Appr");
                    Monster.wLevel = dr.GetUInt16("Lvl");
                    Monster.btLifeAttrib = dr.GetByte("Undead");// 不死系 1-不死系
                    Monster.wCoolEye = dr.GetUInt16("CoolEye");
                    Monster.dwExp = dr.GetUInt32("Exp");// 城门或城墙的状态跟HP值有关，如果HP异常，将导致城墙显示不了
                    if ((Monster.btRace == 110) || (Monster.btRace == 111))// 如果为城墙或城门由HP不加倍
                    {
                        Monster.wHP = dr.GetUInt16("HP");
                    }
                    else
                    {
                        Monster.wHP = (ushort)HUtil32.Round((double)dr.GetInt32("HP") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    }
                    Monster.wMP = (ushort)HUtil32.Round((double)dr.GetUInt16("MP") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wAC = (ushort)HUtil32.Round((double)dr.GetUInt16("AC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wMAC = (ushort)HUtil32.Round((double)dr.GetUInt16("MAC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wDC = (ushort)HUtil32.Round((double)dr.GetUInt16("DC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wMaxDC = (ushort)HUtil32.Round((double)dr.GetUInt16("DCMAX") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wMC = (ushort)HUtil32.Round((double)dr.GetUInt16("MC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wSC = (ushort)HUtil32.Round((double)dr.GetUInt16("SC") * (M2Share.g_Config.nMonsterPowerRate / 10));
                    Monster.wSpeed = dr.GetUInt16("SPEED");
                    Monster.wHitPoint =dr.GetUInt16("HIT");
                    Monster.wWalkSpeed = (ushort)HUtil32._MAX(200, dr.GetUInt16("WALK_SPD"));
                    Monster.wWalkStep = (ushort)HUtil32._MAX(1, dr.GetUInt16("WalkStep"));
                    Monster.wWalkWait = dr.GetUInt16("WalkWait");
                    Monster.wAttackSpeed = dr.GetUInt16("ATTACK_SPD");
                    if (Monster.wWalkSpeed < 200)
                    {
                        Monster.wWalkSpeed = 200;
                    }
                    if (Monster.wAttackSpeed < 200)
                    {
                        Monster.wAttackSpeed = 200;
                    }
                    Monster.ItemList = null;
                    LoadMonitems(Monster.sName, ref Monster.ItemList);
                    UserEngine.MonsterList.Add(Monster);
                    result = 1;
                }
            }
            finally
            {
                dr.Close();
                dr.Dispose();
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// 读取怪物爆率文件
        /// </summary>
        /// <param name="MonName">怪物名称</param>
        /// <param name="ItemList">物品列表</param>
        /// <returns></returns>
        public int LoadMonitems(string MonName, ref IList<TMonItem> ItemList)
        {
            int result = 0;
            TStringList LoadList;
            TMonItem MonItem;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            int n18;
            int n1C;
            int n20;
            string sFileName = M2Share.g_Config.sEnvirDir + "MonItems\\" + MonName + ".txt";
            if (File.Exists(sFileName))
            {
                if (ItemList != null)
                {
                    if (ItemList.Count > 0)
                    {
                        for (int I = 0; I < ItemList.Count; I++)
                        {
                            if (ItemList[I] != null)
                            {
                                Dispose(ItemList[I]);
                            }
                        }
                    }
                    ItemList.Clear();
                }
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    s28 = LoadList[I];
                    if ((s28 != "") && (s28[0] != ';'))
                    {
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\t" });
                        n18 = HUtil32.Str_ToInt(s30, -1);
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\t" });
                        n1C = HUtil32.Str_ToInt(s30, -1);
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\t" });
                        if (s30 != "")
                        {
                            if (s30[0] == '\'')
                            {
                                HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                            }
                        }
                        s2C = s30;
                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\t" });
                        n20 = HUtil32.Str_ToInt(s30, 1);
                        if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                        {
                            if (ItemList == null)
                            {
                                ItemList = new List<TMonItem>();
                            }
                            MonItem = new TMonItem();
                            MonItem.n00 = n18 - 1;
                            MonItem.n04 = n1C;
                            MonItem.sMonName = s2C;
                            MonItem.n18 = n20;
                            ItemList.Add(MonItem);
                            result++;
                        }
                    }
                }
            }
            return result;
        }

        // ;名称  代码  地图   x   y  范围  图标 是否变色 变色时间
        public int LoadNpcs()
        {
            int result;
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            string s40 = string.Empty;
            string s42 = string.Empty;
            TStringList LoadList;
            TNormNpc NPC;
            string sFileName = M2Share.g_Config.sEnvirDir + "Npcs.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        s18 = HUtil32.GetValidStrCap(s18, ref s20, new string[] { " ", "\t" });// 名字
                        if ((s20 != "") && (s20[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(s20, "\"", "\"", ref s20);
                        }
                        s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });// NPC类型
                        s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });// 地图
                        s18 = HUtil32.GetValidStr3(s18, ref s2C, new string[] { " ", "\t" });// X
                        s18 = HUtil32.GetValidStr3(s18, ref s30, new string[] { " ", "\t" });// Y
                        s18 = HUtil32.GetValidStr3(s18, ref s34, new string[] { " ", "\t" });// 范围
                        s18 = HUtil32.GetValidStr3(s18, ref s38, new string[] { " ", "\t" });// 图标
                        s18 = HUtil32.GetValidStr3(s18, ref s40, new string[] { " ", "\t" });// 是否变色
                        s18 = HUtil32.GetValidStr3(s18, ref s42, new string[] { " ", "\t" });// 变色时间
                        if ((s20 != "") && (s28 != "") && (s38 != ""))
                        {
                            NPC = null;
                            switch (HUtil32.Str_ToInt(s24, 0))
                            {
                                case 0://普通NPC
                                    NPC = new TMerchant();
                                    break;
                                case 1://行会NPC
                                    NPC = new TGuildOfficial();
                                    break;
                                case 2://城堡NPC
                                    NPC = new TCastleOfficial();
                                    break;
                            }
                            if (NPC != null)
                            {
                                NPC.m_sMapName = s28;
                                NPC.m_nCurrX = HUtil32.Str_ToInt(s2C, 0);
                                NPC.m_nCurrY = HUtil32.Str_ToInt(s30, 0);
                                NPC.m_sCharName = s20;
                                NPC.m_nFlag = (sbyte)HUtil32.Str_ToInt(s34, 0);
                                NPC.m_wAppr = (ushort)HUtil32.Str_ToInt(s38, 0);
                                NPC.m_NpcType = TNpcType.n_Norm;//by John Add 增加NPC类型
                                if (HUtil32.Str_ToInt(s40, 0) != 0)
                                {
                                    NPC.m_boNpcAutoChangeColor = true;
                                }
                                NPC.m_dwNpcAutoChangeColorTime = Convert.ToUInt32(HUtil32.Str_ToInt(s42, 0) * 1000);
                                UserEngine.QuestNPCList.Add(NPC);
                            }
                        }
                    }
                }
            }
            result = 1;
            return result;
        }

        public string LoadQuestDiary_sub_48978C(int nIndex)
        {
            string result;
            if (nIndex >= 1000)
            {
                result = (nIndex).ToString();
                return result;
            }
            if (nIndex >= 100)
            {
                result = (nIndex).ToString() + "0";
                return result;
            }
            result = (nIndex).ToString() + "00";
            return result;
        }

        public int LoadQuestDiary()
        {
            int result;
            int I;
            int II;
            IList<TQDDinfo> QDDinfoList;
            TQDDinfo QDDinfo;
            string s14;
            string s18;
            string s1C;
            string s20 = string.Empty;
            bool bo2D;
            int nC;
            TStringList LoadList;
            result = 1;
            if (M2Share.QuestDiaryList.Count > 0)
            {
                for (I = 0; I < M2Share.QuestDiaryList.Count; I++)
                {
                    QDDinfoList = M2Share.QuestDiaryList;
                    if (QDDinfoList.Count > 0)
                    {
                        for (II = 0; II < QDDinfoList.Count; II++)
                        {
                            QDDinfo = QDDinfoList[II];
                            Dispose(QDDinfo);
                        }
                    }
                }
                M2Share.QuestDiaryList.Clear();
            }
            bo2D = false;
            nC = 1;
            while (true)
            {
                QDDinfoList = null;
                s14 = "QuestDiary\\" + LoadQuestDiary_sub_48978C(nC) + ".txt";
                if (File.Exists(s14))
                {
                    s18 = "";
                    QDDinfo = null;
                    LoadList = new TStringList();
                    LoadList.LoadFromFile(s14);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        s1C = LoadList[I];
                        if ((s1C != "") && (s1C[0] != ';'))
                        {
                            if ((s1C[0] == '[') && (s1C.Length > 2))
                            {
                                if (s18 == "")
                                {
                                    HUtil32.ArrestStringEx(s1C, "[", "]", ref s18);
                                    QDDinfoList = new List<TQDDinfo>();
                                    QDDinfo = new TQDDinfo();
                                    QDDinfo.n00 = nC;
                                    QDDinfo.s04 = s18;
                                    QDDinfo.sList = new TStringList();
                                    QDDinfoList.Add(QDDinfo);
                                    bo2D = true;
                                }
                                else
                                {
                                    if (s1C[0] != '@')
                                    {
                                        s1C = HUtil32.GetValidStr3(s1C, ref s20, new string[] { " ", "\t" });
                                        HUtil32.ArrestStringEx(s20, "[", "]", ref s20);
                                        QDDinfo = new TQDDinfo();
                                        QDDinfo.n00 = HUtil32.Str_ToInt(s20, 0);
                                        QDDinfo.s04 = s1C;
                                        QDDinfo.sList = new TStringList();
                                        QDDinfoList.Add(QDDinfo);
                                        bo2D = true;
                                    }
                                    else
                                    {
                                        bo2D = false;
                                    }
                                }
                            }
                            else
                            {
                                if (bo2D)
                                {
                                    //QDDinfo.sList.Add(s1C);
                                }
                            }
                        }
                    }
                }
                if (QDDinfoList != null)
                {
                    //M2Share.QuestDiaryList.Add(QDDinfoList);
                }
                else
                {
                    M2Share.QuestDiaryList.Add(null);
                }
                nC++;
                if (nC >= 105)
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 加载安全区配置
        /// </summary>
        /// <returns></returns>
        public int LoadStartPoint()
        {
            int result = 0;
            string tStr;
            string s18 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s22 = string.Empty;
            string s24 = string.Empty;
            string s26 = string.Empty;
            string s28 = string.Empty;
            string s30 = string.Empty;
            TStringList LoadList;
            TStartPoint StartPoint;
            string sFileName = M2Share.g_Config.sEnvirDir + "StartPoint.txt";
            if (File.Exists(sFileName))
            {
                try
                {
                    M2Share.g_StartPointList.Clear();
                    LoadList = new TStringList();
                    LoadList.LoadFromFile(sFileName);
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        tStr = LoadList[I].Trim();
                        if ((tStr != "") && (tStr[0] != ';'))
                        {
                            tStr = HUtil32.GetValidStr3(tStr, ref s18, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s1C, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s20, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s22, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s24, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s26, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s28, new string[] { " ", "\t" });
                            tStr = HUtil32.GetValidStr3(tStr, ref s30, new string[] { " ", "\t" });
                            if ((s18 != "") && (s1C != "") && (s20 != ""))
                            {
                                StartPoint = new TStartPoint();
                                StartPoint.m_sMapName = s18;
                                StartPoint.m_nCurrX = HUtil32.Str_ToInt(s1C, 0);
                                StartPoint.m_nCurrY = HUtil32.Str_ToInt(s20, 0);
                                StartPoint.m_boNotAllowSay = Convert.ToBoolean(HUtil32.Str_ToInt(s22, 0));
                                StartPoint.m_nRange = HUtil32.Str_ToInt(s24, 0);
                                StartPoint.m_nType = HUtil32.Str_ToInt(s26, 0);
                                StartPoint.m_nPkZone = HUtil32.Str_ToInt(s28, 0);
                                StartPoint.m_nPkFire = HUtil32.Str_ToInt(s30, 0);
                                M2Share.g_StartPointList.Add(StartPoint);
                                //M2Share.g_StartPointList.Add(s18, ((StartPoint) as Object));
                                // g_StartPointList.AddObject(s18, TObject(MakeLong(Str_ToInt(s1C, 0), Str_ToInt(s20, 0))));
                                result = 1;
                            }
                        }
                    }
                }
                finally
                {
                    // M2Share.g_StartPointList.UnLock();
                }
            }
            return result;
        }

        /// <summary>
        /// 读取解包物品文件
        /// </summary>
        /// <returns></returns>
        public unsafe int LoadUnbindList(out string ItemName)
        {
            ItemName = string.Empty;
            int result = 0;
            string tStr;
            string sData = string.Empty;
            int nItemIndex;
            string sItemName = string.Empty;
            TStringList LoadList;
            TUnbindInfo* UnbindInfo;
            string sFileName = M2Share.g_Config.sEnvirDir + "UnbindList.txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    tStr = LoadList[I];
                    if ((tStr != "") && (tStr[0] != ';'))
                    {
                        tStr = HUtil32.GetValidStr3(tStr, ref sData, new string[] { " ", "\t" });
                        tStr = HUtil32.GetValidStrCap(tStr, ref sItemName, new string[] { " ", "\t" });
                        if ((sItemName != "") && (sItemName[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(sItemName, "\"", "\"", ref sItemName);
                        }
                        nItemIndex = HUtil32.Str_ToInt(sData, 0);
                        if (nItemIndex > 0 && UserEngine.GetStdItem(sItemName) != null)
                        {
                            UnbindInfo = (TUnbindInfo*)Marshal.AllocHGlobal(sizeof(TUnbindInfo));
                            HUtil32.StrToSByteArry(sItemName, UnbindInfo->sItemName, 14, ref UnbindInfo->sItemNameLen);
                            UnbindInfo->nUnbindCode = nItemIndex;
                            M2Share.g_UnbindList.Add((IntPtr)UnbindInfo);
                        }
                        else
                        {
                            MainOutMessage("加载捆装物品信息失败.数据库不存在:" + sItemName);
                            result = -I;// 需要取负数
                            ItemName = sItemName;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public int LoadNpcScript(TNormNpc NPC, string sPatch, string sScritpName)
        {
            int result;
            if (sPatch == "")
            {
                sPatch = M2Share.sNpc_def;
            }
            result = LoadScriptFile(NPC, sPatch, sScritpName, false);
            return result;
        }

        public bool LoadScriptFile_LoadCallScript(string sFileName, string sLabel, ref TStringList List)
        {
            bool result = false;
            TStringList LoadStrList;
            bool bo1D;
            string s18;
            if (File.Exists(sFileName))
            {
                LoadStrList = new TStringList();
                LoadStrList.LoadFromFile(sFileName);
                sLabel = "[" + sLabel + "]";
                bo1D = false;
                if (LoadStrList.Count > 0)
                {
                    for (int I = 0; I < LoadStrList.Count; I++)
                    {
                        s18 = LoadStrList[I].Trim();
                        if (s18 != "")
                        {
                            if (!bo1D)
                            {
                                if ((s18[0] == '[') && string.Compare(s18, sLabel, true) == 0)
                                {
                                    bo1D = true;
                                    List.Add(s18);
                                }
                            }
                            else
                            {
                                if (s18[0] != '{')
                                {
                                    if (s18[0] == '}')
                                    {
                                        result = true;
                                        break;
                                    }
                                    else
                                    {
                                        List.Add(s18);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void LoadScriptFile_LoadScriptcall(ref TStringList LoadList)
        {
            string s14;
            string s18;
            string s1C = string.Empty;
            string s20;
            string s34;
            for (int I = 0; I < LoadList.Count; I++)
            {
                s14 = LoadList[I].Trim();
                if ((s14 != "") && (s14[0] == '#'))
                {
                    if (HUtil32.CompareLStr(s14, "#CALL", 5))
                    {
                        s14 = HUtil32.ArrestStringEx(s14, "[", "]", ref s1C);
                        s20 = s1C.Trim();
                        s18 = s14.Trim();
                        if (s20[0] == '\\')
                        {
                            s20 = s20.Substring(1, s20.Length - 1);
                        }
                        if (s20[1] == '\\')
                        {
                            s20 = s20.Substring(2, s20.Length - 2);
                        }
                        s34 = M2Share.g_Config.sEnvirDir + "QuestDiary\\" + s20;
                        if (LoadScriptFile_LoadCallScript(s34, s18, ref LoadList))
                        {
                            LoadList[I] = "#ACT";
                            LoadList.InsertText(I + 1, "goto " + s18);
                        }
                        else
                        {
                            MainOutMessage("脚本错误, 加载失败: " + s20 + "  " + s18);
                        }
                    }
                }
            }
        }

        public string LoadScriptFile_LoadDefineInfo(ref TStringList LoadList, ref IList<TDefineInfo> List)
        {
            string result = string.Empty;
            string s14 = string.Empty;
            string s28 = string.Empty;
            string s1C = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            TDefineInfo DefineInfo;
            TStringList LoadStrList;
            for (int I = 0; I < LoadList.Count; I++)
            {
                s14 = LoadList[I].Trim();
                if ((s14 != "") && (s14[0] == '#'))
                {
                    if (HUtil32.CompareLStr(s14, "#SETHOME", 8))
                    {
                        result = HUtil32.GetValidStr3(s14, ref s1C, new string[] { " ", "\t" }).Trim();
                        LoadList[I] = "";
                    }
                    if (HUtil32.CompareLStr(s14, "#DEFINE", 7))
                    {
                        s14 = HUtil32.GetValidStr3(s14, ref s1C, new string[] { " ", "\t" });
                        s14 = HUtil32.GetValidStr3(s14, ref s20, new string[] { " ", "\t" });
                        s14 = HUtil32.GetValidStr3(s14, ref s24, new string[] { " ", "\t" });
                        DefineInfo = new TDefineInfo();
                        DefineInfo.sName = s20.ToUpper();
                        DefineInfo.sText = s24;
                        List.Add(DefineInfo);
                        LoadList[I] = "";
                    }
                    if (HUtil32.CompareLStr(s14, "#INCLUDE", 8))
                    {
                        s28 = HUtil32.GetValidStr3(s14, ref s1C, new string[] { " ", "\t" }).Trim();
                        s28 = M2Share.g_Config.sEnvirDir + "Defines\\" + s28;
                        if (File.Exists(s28))
                        {
                            LoadStrList = new TStringList();
                            LoadStrList.LoadFromFile(s28);
                            result = LoadScriptFile_LoadDefineInfo(ref LoadStrList, ref List);
                        }
                        else
                        {
                            MainOutMessage("脚本错误, 加载失败: " + s28);
                        }
                        LoadList[I] = "";
                    }
                }
            }
            return result;
        }

        public TScript LoadScriptFile_MakeNewScript(ref int nQuestIdx, ref TNormNpc NPC)
        {
            TScript result;
            TScript ScriptInfo;
            ScriptInfo = new TScript();
            ScriptInfo.boQuest = false;
            ScriptInfo.QuestInfo = new TQuestInfo[10];
            //FillChar(ScriptInfo.QuestInfo, sizeof(TQuestInfo) * 10, '\0');
            nQuestIdx = 0;
            ScriptInfo.RecordList = new List<TSayingRecord>();
            NPC.m_ScriptList.Add(ScriptInfo);
            result = ScriptInfo;
            return result;
        }

        /// <summary>
        /// 加载NPC条件检查脚本
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="QuestConditionInfo"></param>
        /// <returns></returns>
        public bool LoadScriptFile_QuestCondition(string sText, ref TQuestConditionInfo QuestConditionInfo)
        {
            bool result = false;
            string sCmd = string.Empty;
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            string sParam4 = string.Empty;
            string sParam5 = string.Empty;
            string sParam6 = string.Empty;
            string sParam7 = string.Empty;
            int nCMDCode;
            int aaaa;
            sText = HUtil32.GetValidStrCap(sText, ref sCmd, new string[] { " ", "\t" });
            aaaa = sCmd.IndexOf(".");
            if (aaaa >= 0)
            {
                sParam7 = sCmd.Substring(0, aaaa - 1);
                sParam6 = "88";
                sCmd = sCmd.Substring(aaaa + 1, sCmd.Length - aaaa - 1);
            }
            sText = HUtil32.GetValidStrCap(sText, ref sParam1, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam2, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam3, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam4, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam5, new string[] { " ", "\t" });
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam6, new string[] { " ", "\t" });
            }
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam7, new string[] { " ", "\t" });
            }
            sCmd = sCmd.ToUpper();
            nCMDCode = 0;
            if (sCmd == M2Share.sCHECK)
            {
                nCMDCode = M2Share.nCHECK;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
                goto L001;
            }
            if (sCmd == M2Share.sCHECKOPEN)
            {
                nCMDCode = M2Share.nCHECKOPEN;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
                goto L001;
            }
            if (sCmd == M2Share.sCHECKUNIT)
            {
                nCMDCode = M2Share.nCHECKUNIT;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
                goto L001;
            }
            if (sCmd == M2Share.sCHECKPKPOINT)
            {
                nCMDCode = M2Share.nCHECKPKPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKGOLD)
            {
                nCMDCode = M2Share.nCHECKGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKLEVEL)
            {
                nCMDCode = M2Share.nCHECKLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKJOB)
            {
                nCMDCode = M2Share.nCHECKJOB;
                goto L001;
            }
            if (sCmd == M2Share.sRANDOM)
            {
                nCMDCode = M2Share.nRANDOM;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKITEM)
            {
                nCMDCode = M2Share.nCHECKITEM;
                goto L001;
            }
            if (sCmd == M2Share.sGENDER)
            {
                nCMDCode = M2Share.nGENDER;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKBAGGAGE)
            {
                nCMDCode = M2Share.nCHECKBAGGAGE;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKNAMELIST)
            {
                nCMDCode = M2Share.nCHECKNAMELIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_HASGUILD)
            {
                nCMDCode = M2Share.nSC_HASGUILD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISGUILDMASTER)
            {
                nCMDCode = M2Share.nSC_ISGUILDMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCASTLEMASTER)
            {
                nCMDCode = M2Share.nSC_CHECKCASTLEMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISNEWHUMAN)
            {
                nCMDCode = M2Share.nSC_ISNEWHUMAN;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMEMBERTYPE)
            {
                nCMDCode = M2Share.nSC_CHECKMEMBERTYPE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMEMBERLEVEL)
            {
                nCMDCode = M2Share.nSC_CHECKMEMBERLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKGAMEGOLD)
            {
                nCMDCode = M2Share.nSC_CHECKGAMEGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSTRINGLENGTH)// 检查字符串长度 
            {
                nCMDCode = M2Share.nSC_CHECKSTRINGLENGTH;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKGAMEDIAMOND)// 检查金刚石数量 
            {
                nCMDCode = M2Share.nSC_CHECKGAMEDIAMOND;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKGAMEGIRD)// 检查灵符数量 
            {
                nCMDCode = M2Share.nSC_CHECKGAMEGIRD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKGAMEGLORY) // 检查荣誉值 
            {
                nCMDCode = M2Share.nSC_CHECKGAMEGLORY;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKSKILLLEVEL) // 检查技能等级 
            {
                nCMDCode = M2Share.nSC_CHECKSKILLLEVEL;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKMAPMOBCOUNT) // 检查地图指定坐标指定名称怪物数量
            {
                nCMDCode = M2Share.nSC_CHECKMAPMOBCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKRANGEMONCOUNTEX)  // 检查地图指定坐标指定名称怪物数量 
            {
                nCMDCode = M2Share.nSC_CHECKMAPMOBCOUNT;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKSIDESLAVENAME) // 检查人物周围自己宝宝数量 
            {
                nCMDCode = M2Share.nSC_CHECKSIDESLAVENAME;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKLISTTEXT)// 检查文件是否包含指定文本 
            {
                nCMDCode = M2Share.nSC_CHECKLISTTEXT;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKCURRENTDATE)// 检测当前日期是否小于大于等于指定的日期 
            {
                nCMDCode = M2Share.nSC_CHECKCURRENTDATE;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKMASTERONLINE) // 检测师傅（或徒弟）是否在线 
            {
                nCMDCode = M2Share.nSC_CHECKMASTERONLINE;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKDEARONLINE)// 检测夫妻一方是否在线 
            {
                nCMDCode = M2Share.nSC_CHECKDEARONLINE;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKMASTERONMAP)// 检测师傅(或徒弟)是否在指定的地图上
            {
                nCMDCode = M2Share.nSC_CHECKMASTERONMAP;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKDEARONMAP)// 检测夫妻一方是否在指定的地图上
            {
                nCMDCode = M2Share.nSC_CHECKDEARONMAP;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKPOSEISPRENTICE)// 检测对面是否为自己的徒弟
            {
                nCMDCode = M2Share.nSC_CHECKPOSEISPRENTICE;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKCASTLEWAR)// 检查是否在攻城期间
            {
                nCMDCode = M2Share.nSC_CHECKCASTLEWAR;
                goto L001;
            }
            // -------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_FINDMAPPATH)// 设置地图的起终XY值
            {
                nCMDCode = M2Share.nSC_FINDMAPPATH;
                goto L001;
            }
            // --------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKHEROLOYAL) // 检测英雄的忠诚度
            {
                nCMDCode = M2Share.nSC_CHECKHEROLOYAL;
                goto L001;
            }
            // --------------------------------------------------------------------------
            if (sCmd == M2Share.sISONMAKEWINE) // 判断是否在酿哪种酒
            {
                nCMDCode = M2Share.nISONMAKEWINE;
                goto L001;
            }
            // --------------------------------------------------------------------------
            if (sCmd == M2Share.sCHECKGUILDFOUNTAIN)// 判断是否开启行会泉水仓库
            {
                nCMDCode = M2Share.nCHECKGUILDFOUNTAIN;
                goto L001;
            }
            // --------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKGAMEPOINT)
            {
                nCMDCode = M2Share.nSC_CHECKGAMEPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKNAMELISTPOSITION)
            {
                nCMDCode = M2Share.nSC_CHECKNAMELISTPOSITION;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKGUILDLIST)
            {
                nCMDCode = M2Share.nSC_CHECKGUILDLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKRENEWLEVEL)
            {
                nCMDCode = M2Share.nSC_CHECKRENEWLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSLAVELEVEL)
            {
                nCMDCode = M2Share.nSC_CHECKSLAVELEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSLAVENAME)
            {
                nCMDCode = M2Share.nSC_CHECKSLAVENAME;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCREDITPOINT)
            {
                nCMDCode = M2Share.nSC_CHECKCREDITPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKOFGUILD)
            {
                nCMDCode = M2Share.nSC_CHECKOFGUILD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPAYMENT)
            {
                nCMDCode = M2Share.nSC_CHECKPAYMENT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKUSEITEM)
            {
                nCMDCode = M2Share.nSC_CHECKUSEITEM;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKBAGSIZE)
            {
                nCMDCode = M2Share.nSC_CHECKBAGSIZE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKDC)
            {
                nCMDCode = M2Share.nSC_CHECKDC;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMC)
            {
                nCMDCode = M2Share.nSC_CHECKMC;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSC)
            {
                nCMDCode = M2Share.nSC_CHECKSC;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHP)
            {
                nCMDCode = M2Share.nSC_CHECKHP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMP)
            {
                nCMDCode = M2Share.nSC_CHECKMP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKITEMTYPE)
            {
                nCMDCode = M2Share.nSC_CHECKITEMTYPE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKEXP)
            {
                nCMDCode = M2Share.nSC_CHECKEXP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCASTLEGOLD)
            {
                nCMDCode = M2Share.nSC_CHECKCASTLEGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PASSWORDERRORCOUNT)
            {
                nCMDCode = M2Share.nSC_PASSWORDERRORCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISLOCKPASSWORD)
            {
                nCMDCode = M2Share.nSC_ISLOCKPASSWORD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISLOCKSTORAGE)
            {
                nCMDCode = M2Share.nSC_ISLOCKSTORAGE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKBUILDPOINT)
            {
                nCMDCode = M2Share.nSC_CHECKBUILDPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKAURAEPOINT)
            {
                nCMDCode = M2Share.nSC_CHECKAURAEPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSTABILITYPOINT)
            {
                nCMDCode = M2Share.nSC_CHECKSTABILITYPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKFLOURISHPOINT)
            {
                nCMDCode = M2Share.nSC_CHECKFLOURISHPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCONTRIBUTION)
            {
                nCMDCode = M2Share.nSC_CHECKCONTRIBUTION;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKRANGEMONCOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKRANGEMONCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISONMAP)// 检测地图命令
            {
                nCMDCode = M2Share.nSC_ISONMAP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKITEMADDVALUE)
            {
                nCMDCode = M2Share.nSC_CHECKITEMADDVALUE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKINMAPRANGE)
            {
                nCMDCode = M2Share.nSC_CHECKINMAPRANGE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHUMINRANGE)
            {
                // 无忧加
                nCMDCode = M2Share.nSC_CHECKHUMINRANGE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CASTLECHANGEDAY)
            {
                nCMDCode = M2Share.nSC_CASTLECHANGEDAY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CASTLEWARDAY)
            {
                nCMDCode = M2Share.nSC_CASTLEWARDAY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ONLINELONGMIN)
            {
                nCMDCode = M2Share.nSC_ONLINELONGMIN;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKGUILDCHIEFITEMCOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKGUILDCHIEFITEMCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKNAMEDATELIST)
            {
                nCMDCode = M2Share.nSC_CHECKNAMEDATELIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMAPHUMANCOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKMAPHUMANCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMAPMONCOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKMAPMONCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKVAR)
            {
                nCMDCode = M2Share.nSC_CHECKVAR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSERVERNAME)
            {
                nCMDCode = M2Share.nSC_CHECKSERVERNAME;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISATTACKGUILD)
            {
                nCMDCode = M2Share.nSC_ISATTACKGUILD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISDEFENSEGUILD)
            {
                nCMDCode = M2Share.nSC_ISDEFENSEGUILD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISATTACKALLYGUILD)
            {
                nCMDCode = M2Share.nSC_ISATTACKALLYGUILD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISDEFENSEALLYGUILD)
            {
                nCMDCode = M2Share.nSC_ISDEFENSEALLYGUILD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISCASTLEGUILD)
            {
                nCMDCode = M2Share.nSC_ISCASTLEGUILD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCASTLEDOOR)
            {
                nCMDCode = M2Share.nSC_CHECKCASTLEDOOR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISSYSOP)
            {
                nCMDCode = M2Share.nSC_ISSYSOP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISADMIN)
            {
                nCMDCode = M2Share.nSC_ISADMIN;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKGROUPCOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKGROUPCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKACCOUNTLIST)
            {
                nCMDCode = M2Share.nCHECKACCOUNTLIST;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKIPLIST)
            {
                nCMDCode = M2Share.nCHECKIPLIST;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKBBCOUNT)
            {
                nCMDCode = M2Share.nCHECKBBCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sDAYTIME)
            {
                nCMDCode = M2Share.nDAYTIME;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKITEMW)
            {
                nCMDCode = M2Share.nCHECKITEMW;
                goto L001;
            }
            if (sCmd == M2Share.sISTAKEITEM)
            {
                nCMDCode = M2Share.nISTAKEITEM;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKDURA)
            {
                nCMDCode = M2Share.nCHECKDURA;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKDURAEVA)
            {
                nCMDCode = M2Share.nCHECKDURAEVA;
                goto L001;
            }
            if (sCmd == M2Share.sDAYOFWEEK)
            {
                nCMDCode = M2Share.nDAYOFWEEK;
                goto L001;
            }
            if (sCmd == M2Share.sHOUR)
            {
                nCMDCode = M2Share.nHOUR;
                goto L001;
            }
            if (sCmd == M2Share.sMIN)
            {
                nCMDCode = M2Share.nMIN;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKLUCKYPOINT)
            {
                nCMDCode = M2Share.nCHECKLUCKYPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKMONMAP)
            {
                nCMDCode = M2Share.nCHECKMONMAP;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKHUM)
            {
                nCMDCode = M2Share.nCHECKHUM;
                goto L001;
            }
            if (sCmd == M2Share.sEQUAL)
            {
                nCMDCode = M2Share.nEQUAL;
                goto L001;
            }
            if (sCmd == M2Share.sLARGE)
            {
                nCMDCode = M2Share.nLARGE;
                goto L001;
            }
            if (sCmd == M2Share.sSMALL)
            {
                nCMDCode = M2Share.nSMALL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPOSEDIR)
            {
                nCMDCode = M2Share.nSC_CHECKPOSEDIR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPOSELEVEL)
            {
                nCMDCode = M2Share.nSC_CHECKPOSELEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPOSEGENDER)
            {
                nCMDCode = M2Share.nSC_CHECKPOSEGENDER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKLEVELEX)
            {
                nCMDCode = M2Share.nSC_CHECKLEVELEX;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKBONUSPOINT)
            {
                nCMDCode = M2Share.nSC_CHECKBONUSPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMARRY)
            {
                nCMDCode = M2Share.nSC_CHECKMARRY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPOSEMARRY)
            {
                nCMDCode = M2Share.nSC_CHECKPOSEMARRY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMARRYCOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKMARRYCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMASTER)
            {
                nCMDCode = M2Share.nSC_CHECKMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_HAVEMASTER)
            {
                nCMDCode = M2Share.nSC_HAVEMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPOSEMASTER)
            {
                nCMDCode = M2Share.nSC_CHECKPOSEMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_POSEHAVEMASTER)
            {
                nCMDCode = M2Share.nSC_POSEHAVEMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKISMASTER)
            {
                nCMDCode = M2Share.nSC_CHECKISMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPOSEISMASTER)
            {
                nCMDCode = M2Share.nSC_CHECKPOSEISMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKNAMEIPLIST)
            {
                nCMDCode = M2Share.nSC_CHECKNAMEIPLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKACCOUNTIPLIST)
            {
                nCMDCode = M2Share.nSC_CHECKACCOUNTIPLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSLAVECOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKSLAVECOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKMAPNAME)
            {
                nCMDCode = M2Share.nCHECKMAPNAME;
                goto L001;
            }
            if (sCmd == M2Share.sINSAFEZONE)
            {
                nCMDCode = M2Share.nINSAFEZONE;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKSKILL)
            {
                nCMDCode = M2Share.nCHECKSKILL;
                goto L001;
            }
            if (sCmd == M2Share.sHEROCHECKSKILL)// 检查英雄技能
            {
                nCMDCode = M2Share.nHEROCHECKSKILL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKUSERDATE)
            {
                nCMDCode = M2Share.nSC_CHECKUSERDATE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCONTAINSTEXT)
            {
                nCMDCode = M2Share.nSC_CHECKCONTAINSTEXT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_COMPARETEXT)
            {
                nCMDCode = M2Share.nSC_COMPARETEXT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKTEXTLIST)
            {
                nCMDCode = M2Share.nSC_CHECKTEXTLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCONTAINSTEXTLIST)
            {
                nCMDCode = M2Share.nSC_CHECKCONTAINSTEXTLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISGROUPMASTER)
            {
                nCMDCode = M2Share.nSC_ISGROUPMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKONLINE)
            {
                nCMDCode = M2Share.nSC_CHECKONLINE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISDUPMODE)
            {
                nCMDCode = M2Share.nSC_ISDUPMODE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ISOFFLINEMODE)
            {
                nCMDCode = M2Share.nSC_ISOFFLINEMODE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSTATIONTIME)
            {
                nCMDCode = M2Share.nSC_CHECKSTATIONTIME;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKSIGNMAP)
            {
                nCMDCode = M2Share.nSC_CHECKSIGNMAP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_HAVEHERO)
            {
                nCMDCode = M2Share.nSC_HAVEHERO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHEROONLINE)
            {
                nCMDCode = M2Share.nSC_CHECKHEROONLINE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHEROLEVEL)
            {
                nCMDCode = M2Share.nSC_CHECKHEROLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMINE)// 检测矿纯度  
            {
                nCMDCode = M2Share.nSC_CHECKMINE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKMAKEWINE) // 检测酒的品质 
            {
                nCMDCode = M2Share.nSC_CHECKMAKEWINE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKITEMLEVEL)// 检查装备升级次数 
            {
                nCMDCode = M2Share.nSC_CHECKITEMLEVEL;
                goto L001;
            }
            // ------------------------插件命令-----------------------------------
            if (sCmd == M2Share.sSC_CHECKONLINEPLAYCOUNT)
            {
                nCMDCode = M2Share.nSC_CHECKONLINEPLAYCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPLAYDIELVL)
            {
                nCMDCode = M2Share.nSC_CHECKPLAYDIELVL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPLAYDIEJOB)
            {
                nCMDCode = M2Share.nSC_CHECKPLAYDIEJOB;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPLAYDIESEX)
            {
                nCMDCode = M2Share.nSC_CHECKPLAYDIESEX;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKKILLPLAYLVL)
            {
                nCMDCode = M2Share.nSC_CHECKKILLPLAYLVL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKKILLPLAYJOB)
            {
                nCMDCode = M2Share.nSC_CHECKKILLPLAYJOB;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKKILLPLAYSEX)
            {
                nCMDCode = M2Share.nSC_CHECKKILLPLAYSEX;
                goto L001;
            }
            // ------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CHECKHEROPKPOINT) // 检测英雄PK值 
            {
                nCMDCode = M2Share.nSC_CHECKHEROPKPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKCODELIST)// 检测文件里的编码 
            {
                nCMDCode = M2Share.nSC_CHECKCODELIST;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKITEMSTATE)// 检查装备绑定状态
            {
                nCMDCode = M2Share.nCHECKITEMSTATE;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKITEMSNAME) // 检查指定装备位置物品名称
            {
                nCMDCode = M2Share.nCHECKITEMSNAME;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKGUILDMEMBERCOUNT)// 检测行会成员上限
            {
                nCMDCode = M2Share.nCHECKGUILDMEMBERCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKGUILDFOUNTAINVALUE)// 检测行会酒泉数
            {
                nCMDCode = M2Share.nCHECKGUILDFOUNTAINVALUE;
                goto L001;
            }
            if (sCmd == M2Share.sCHECKNGLEVEL)// 检查角色内功等级
            {
                nCMDCode = M2Share.nCHECKNGLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sKILLBYHUM) // 检测是否被人物所杀
            {
                nCMDCode = M2Share.nKILLBYHUM;
                goto L001;
            }
            if (sCmd == M2Share.sISHIGH)// 检测服务器最高属性人物命令
            {
                nCMDCode = M2Share.nISHIGH;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHEROJOB)
            {
                nCMDCode = M2Share.nSC_CHECKHEROJOB;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGREADNG)// 检查角色是否学过内功
            {
                nCMDCode = M2Share.nSC_CHANGREADNG;
                goto L001;
            }
            // ---------------------连击相关  20091211 邱高奇------------------------//
            if (sCmd == M2Share.sSC_CHECKKIMNEEDLE)
            {
                nCMDCode = M2Share.nSC_CHECKKIMNEEDLE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHUMANPULSE)
            {
                nCMDCode = M2Share.nSC_CHECKHUMANPULSE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKOPENPULSELEVEL)
            {
                nCMDCode = M2Share.nSC_CHECKOPENPULSELEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKPULSELEVEL)
            {
                nCMDCode = M2Share.nSC_CHECKPULSELEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHEARMSGCOLOR)
            {
                nCMDCode = M2Share.nSC_CHECKHEARMSGCOLOR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHEROOPENOPULS)
            {
                nCMDCode = M2Share.nSC_CHECKHEROOPENOPULS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKHEROPULSEXP)
            {
                nCMDCode = M2Share.nSC_CHECKHEROPULSEXP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHECKITMECOUNTDURA)
            {
                nCMDCode = M2Share.nSC_CHECKITMECOUNTDURA;
                goto L001;
            }
            // -------双英雄相关--------------------//
            if (sCmd == M2Share.sSC_CheckAssessMentHero)
            {
                nCMDCode = M2Share.nSC_CheckAssessMentHero;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CheckDeputyHero)
            {
                nCMDCode = M2Share.nSC_CheckDeputyHero;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CheckHeroAutoPractice)
            {
                nCMDCode = M2Share.nSC_CheckHeroAutoPractice;
                goto L001;
            }
            // -----------------------------------------
            if (sCmd == M2Share.sSC_CHECKSKILL75)// 检查是否学习过护体神盾
            {
                nCMDCode = M2Share.nSC_CHECKSKILL75;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MAPHUMISSAMEGUILD) // 检测当前地图中的人物是否属于同一个行会(所有人是同一行会才为真)
            {
                nCMDCode = M2Share.nSC_MAPHUMISSAMEGUILD;
                goto L001;
            }
        L001:
            if (nCMDCode > 0)
            {
                QuestConditionInfo.nCMDCode = nCMDCode;
                if ((sParam1 != "") && (sParam1[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam1, "\"", "\"", ref sParam1);
                }
                if ((sParam2 != "") && (sParam2[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam2, "\"", "\"", ref sParam2);
                }
                if ((sParam3 != "") && (sParam3[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam3, "\"", "\"", ref sParam3);
                }
                if ((sParam4 != "") && (sParam4[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam4, "\"", "\"", ref sParam4);
                }
                if ((sParam5 != "") && (sParam5[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam5, "\"", "\"", ref sParam5);
                }
                if ((sParam6 != "") && (sParam6[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam6, "\"", "\"", ref sParam6);
                }
                if ((sParam7 != "") && (sParam7[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam7, "\"", "\"", ref sParam7);
                }
                QuestConditionInfo.sParam1 = sParam1;
                QuestConditionInfo.sParam2 = sParam2;
                QuestConditionInfo.sParam3 = sParam3;
                QuestConditionInfo.sParam4 = sParam4;
                QuestConditionInfo.sParam5 = sParam5;
                QuestConditionInfo.sParam6 = sParam6;
                QuestConditionInfo.sParam7 = sParam7;
                if (HUtil32.IsStringNumber(sParam1))
                {
                    QuestConditionInfo.nParam1 = HUtil32.Str_ToInt(sParam1, 0);
                }
                if (HUtil32.IsStringNumber(sParam2))
                {
                    QuestConditionInfo.nParam2 = HUtil32.Str_ToInt(sParam2, 0);
                }
                if (HUtil32.IsStringNumber(sParam3))
                {
                    QuestConditionInfo.nParam3 = HUtil32.Str_ToInt(sParam3, 0);
                }
                if (HUtil32.IsStringNumber(sParam4))
                {
                    QuestConditionInfo.nParam4 = HUtil32.Str_ToInt(sParam4, 0);
                }
                if (HUtil32.IsStringNumber(sParam5))
                {
                    QuestConditionInfo.nParam5 = HUtil32.Str_ToInt(sParam5, 0);
                }
                if (HUtil32.IsStringNumber(sParam6))
                {
                    QuestConditionInfo.nParam6 = HUtil32.Str_ToInt(sParam6, 0);
                }
                if (HUtil32.IsStringNumber(sParam7))
                {
                    QuestConditionInfo.nParam7 = HUtil32.Str_ToInt(sParam7, 0);
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 加载NPC条件处理脚本
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="QuestActionInfo"></param>
        /// <returns></returns>
        public bool LoadScriptFile_QuestAction(string sText, ref TQuestActionInfo QuestActionInfo)
        {
            bool result;
            string sCmd = string.Empty;
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            string sParam4 = string.Empty;
            string sParam5 = string.Empty;
            string sParam6 = string.Empty;
            string sParam7 = string.Empty;
            int nCMDCode;
            int bbbb;
            result = false;
            sText = HUtil32.GetValidStrCap(sText, ref sCmd, new string[] { " ", "\t" });
            bbbb = sCmd.IndexOf(".");
            if (bbbb > 0)
            {
                sParam7 = sCmd.Substring(0, bbbb - 1);
                sParam6 = "88";
                sCmd = sCmd.Substring(bbbb + 1, sCmd.Length - bbbb - 1);
            }
            sText = HUtil32.GetValidStrCap(sText, ref sParam1, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam2, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam3, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam4, new string[] { " ", "\t" });
            sText = HUtil32.GetValidStrCap(sText, ref sParam5, new string[] { " ", "\t" });
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam6, new string[] { " ", "\t" });
            }
            if (!(sParam6 == "88"))
            {
                sText = HUtil32.GetValidStrCap(sText, ref sParam7, new string[] { " ", "\t" });
            }
            sCmd = sCmd.ToUpper();
            nCMDCode = 0;
            if (sCmd == M2Share.sSET)
            {
                nCMDCode = M2Share.nSET;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == M2Share.sRESET)
            {
                nCMDCode = M2Share.nRESET;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == M2Share.sSETOPEN)
            {
                nCMDCode = M2Share.nSETOPEN;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == M2Share.sSETUNIT)
            {
                nCMDCode = M2Share.nSETUNIT;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == M2Share.sRESETUNIT)
            {
                nCMDCode = M2Share.nRESETUNIT;
                HUtil32.ArrestStringEx(sParam1, "[", "]", ref sParam1);
                if (!HUtil32.IsStringNumber(sParam1))
                {
                    nCMDCode = 0;
                }
                if (!HUtil32.IsStringNumber(sParam2))
                {
                    nCMDCode = 0;
                }
            }
            if (sCmd == M2Share.sTAKE)
            {
                nCMDCode = M2Share.nTAKE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GIVE)
            {
                nCMDCode = M2Share.nSC_GIVE;
                goto L001;
            }
            if (sCmd == M2Share.sCLOSE)
            {
                nCMDCode = M2Share.nCLOSE;
                goto L001;
            }
            if (sCmd == M2Share.sBREAK)
            {
                nCMDCode = M2Share.nBREAK;
                goto L001;
            }
            if (sCmd == M2Share.sGOTO)
            {
                nCMDCode = M2Share.nGOTO;
                goto L001;
            }
            if (sCmd == M2Share.sADDNAMELIST)
            {
                nCMDCode = M2Share.nADDNAMELIST;
                goto L001;
            }
            if (sCmd == M2Share.sDELNAMELIST)
            {
                nCMDCode = M2Share.nDELNAMELIST;
                goto L001;
            }
            if (sCmd == M2Share.sADDGUILDLIST)
            {
                nCMDCode = M2Share.nADDGUILDLIST;
                goto L001;
            }
            if (sCmd == M2Share.sDELGUILDLIST)
            {
                nCMDCode = M2Share.nDELGUILDLIST;
                goto L001;
            }
            if (sCmd == M2Share.sADDACCOUNTLIST)
            {
                nCMDCode = M2Share.nADDACCOUNTLIST;
                goto L001;
            }
            if (sCmd == M2Share.sDELACCOUNTLIST)
            {
                nCMDCode = M2Share.nDELACCOUNTLIST;
                goto L001;
            }
            if (sCmd == M2Share.sADDIPLIST)
            {
                nCMDCode = M2Share.nADDIPLIST;
                goto L001;
            }
            if (sCmd == M2Share.sDELIPLIST)
            {
                nCMDCode = M2Share.nDELIPLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSENDMSG)
            {
                nCMDCode = M2Share.nSENDMSG;
                goto L001;
            }
            if (sCmd == M2Share.sCREATEFILE)// 创建文本文件
            {
                nCMDCode = M2Share.nCREATEFILE;
                goto L001;
            }
            if (sCmd == M2Share.sSENDTOPMSG) // 顶端滚动公告
            {
                nCMDCode = M2Share.nSENDTOPMSG;
                goto L001;
            }
            if (sCmd == M2Share.sSENDCENTERMSG)  // 屏幕居中显示公告
            {
                nCMDCode = M2Share.nSENDCENTERMSG;
                goto L001;
            }
            if (sCmd == M2Share.sSENDEDITTOPMSG)// 聊天框顶端公告
            {
                nCMDCode = M2Share.nSENDEDITTOPMSG;
                goto L001;
            }
            if (sCmd == M2Share.sOPENBOOKS)// 卧龙命令
            {
                nCMDCode = M2Share.nOPENBOOKS;
                goto L001;
            }
            if (sCmd == M2Share.sOPENBOOK)// 卧龙命令
            {
                nCMDCode = M2Share.nOPENBOOKS;
                goto L001;
            }
            if (sCmd == M2Share.sOPENYBDEAL) // 开通元宝交易
            {
                nCMDCode = M2Share.nOPENYBDEAL;
                goto L001;
            }
            if (sCmd == M2Share.sQUERYYBSELL) // 查询正在元宝寄售出售的物品
            {
                nCMDCode = M2Share.nQUERYYBSELL;
                goto L001;
            }
            if (sCmd == M2Share.sQUERYYBDEAL)// 查询可以的购买物品
            {
                nCMDCode = M2Share.nQUERYYBDEAL;
                goto L001;
            }
            if (sCmd == M2Share.sTHROUGHHUM)// 改变穿人模式
            {
                nCMDCode = M2Share.nTHROUGHHUM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sSetOnTimer)  // 个人定时器(启动)
            {
                nCMDCode = M2Share.nSetOnTimer;
                goto L001;
            }
            if (sCmd == M2Share.sSetScTimer)// 个人定时器(启动)
            {
                nCMDCode = M2Share.nSetOnTimer;
                goto L001;
            }
            if (sCmd == M2Share.sSETOFFTIMER)// 停止定时器
            {
                nCMDCode = M2Share.nSETOFFTIMER;
                goto L001;
            }
            if (sCmd == M2Share.sKILLSCTIMER) // 停止定时器
            {
                nCMDCode = M2Share.nSETOFFTIMER;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sGETSORTNAME) // 取指定排行榜指定排名的玩家名字
            {

                nCMDCode = M2Share.nGETSORTNAME;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sWEBBROWSER) // 连接指定网站网址
            {
                nCMDCode = M2Share.nWEBBROWSER;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sADDATTACKSABUKALL)// 设置所有行会攻城
            {
                nCMDCode = M2Share.nADDATTACKSABUKALL;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sKICKALLPLAY)// 踢除服务器所有人物
            {
                nCMDCode = M2Share.nKICKALLPLAY;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sREPAIRALL)// 修理全身装备
            {
                nCMDCode = M2Share.nREPAIRALL;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sAUTOGOTOXY)// 自动寻路
            {
                nCMDCode = M2Share.nAUTOGOTOXY;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sCHANGESKILL)// 修改魔法ID
            {
                nCMDCode = M2Share.nCHANGESKILL;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sOPENMAKEWINE)  // 打开酿酒窗口 
            {
                nCMDCode = M2Share.nOPENMAKEWINE;
                goto L001;
            }
            if (sCmd == M2Share.sGETGOODMAKEWINE) // 取回酿好的酒 
            {
                nCMDCode = M2Share.nGETGOODMAKEWINE;
                goto L001;
            }
            if (sCmd == M2Share.sDECMAKEWINETIME)// 减少酿酒的时间 
            {
                nCMDCode = M2Share.nDECMAKEWINETIME;
                goto L001;
            }
            if (sCmd == M2Share.sREADSKILLNG)  // 学习内功
            {
                nCMDCode = M2Share.nREADSKILLNG;
                goto L001;
            }
            if (sCmd == M2Share.sMAKEWINENPCMOVE) // 酿酒NPC的走动
            {
                nCMDCode = M2Share.nMAKEWINENPCMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sFOUNTAIN) // 设置泉水喷发
            {
                nCMDCode = M2Share.nFOUNTAIN;
                goto L001;
            }
            if (sCmd == M2Share.sSETGUILDFOUNTAIN) // 开启/关闭行会泉水仓库
            {
                nCMDCode = M2Share.nSETGUILDFOUNTAIN;
                goto L001;
            }
            if (sCmd == M2Share.sGIVEGUILDFOUNTAIN)  // 领取行会酒水
            {
                nCMDCode = M2Share.nGIVEGUILDFOUNTAIN;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sCHALLENGMAPMOVE) // 挑战地图移动
            {
                nCMDCode = M2Share.nCHALLENGMAPMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sGETCHALLENGEBAKITEM) // 没有挑战地图可移动,则退回抵押的物品
            {
                nCMDCode = M2Share.nGETCHALLENGEBAKITEM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sHEROLOGOUT)// 英雄下线
            {
                nCMDCode = M2Share.nHEROLOGOUT;
                goto L001;
            }
            if (sCmd == M2Share.sSETITEMSLIGHT) // 装备发光设置
            {
                nCMDCode = M2Share.nSETITEMSLIGHT;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sQUERYREFINEITEM)// 打开粹练窗口
            {
                nCMDCode = M2Share.nQUERYREFINEITEM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sGOHOME) // 移动到回城点 
            {
                nCMDCode = M2Share.nGOHOME;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sTHROWITEM)  // 将指定物品刷新到指定地图坐标范围内 
            {
                nCMDCode = M2Share.nTHROWITEM;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sOPENDRAGONBOX)// 打开粹练窗口 
            {
                nCMDCode = M2Share.nOPENDRAGONBOX;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sCLEARCODELIST) // 删除指定文本里的编码 
            {
                nCMDCode = M2Share.nCLEARCODELIST;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sGETRANDOMNAME) // 随机取文件名称
            {
                nCMDCode = M2Share.nGETRANDOMNAME;
                goto L001;
            }
            if (sCmd == M2Share.sREADRANDOMSTR) // 随机取文件名称 
            {
                nCMDCode = M2Share.nGETRANDOMNAME;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sHCall) // 通过脚本命令让别人执行QManage.txt中的脚本 
            {
                nCMDCode = M2Share.nHCall;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sINCASTLEWARAY)  // 检测人物是否在攻城期间的范围内，在则BB叛变 
            {
                nCMDCode = M2Share.nINCASTLEWARAY;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sGIVESTATEITEM) // 给予带绑定状态装备 
            {
                nCMDCode = M2Share.nGIVESTATEITEM;
                goto L001;
            }
            if (sCmd == M2Share.sSETITEMSTATE) // 设置装备绑定状态
            {
                nCMDCode = M2Share.nSETITEMSTATE;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sPKPOINT)
            {
                nCMDCode = M2Share.nPKPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_RECALLMOB)
            {
                nCMDCode = M2Share.nSC_RECALLMOB;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_RECALLMOBEX)// 新增召出的宝宝命令
            {
                nCMDCode = M2Share.nSC_RECALLMOBEX;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_MOVEMOBTO)  // 将指定坐标的怪物移动到新坐标 
            {
                nCMDCode = M2Share.nSC_MOVEMOBTO;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_CLEARITEMMAP) // 清除地图物品 
            {

                nCMDCode = M2Share.nSC_CLEARITEMMAP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARMAPITEM)// 清除地图物品 
            {
                nCMDCode = M2Share.nSC_CLEARITEMMAP;
                goto L001;
            }
            // -----------------------------------------------------------------------------
            if (sCmd == M2Share.sKICK)
            {
                nCMDCode = M2Share.nKICK;
                goto L001;
            }
            if (sCmd == M2Share.sTAKEW)
            {
                nCMDCode = M2Share.nTAKEW;
                goto L001;
            }
            if (sCmd == M2Share.sTIMERECALL)
            {
                nCMDCode = M2Share.nTIMERECALL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PARAM1)
            {
                nCMDCode = M2Share.nSC_PARAM1;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PARAM2)
            {
                nCMDCode = M2Share.nSC_PARAM2;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PARAM3)
            {
                nCMDCode = M2Share.nSC_PARAM3;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PARAM4)
            {
                nCMDCode = M2Share.nSC_PARAM4;
                goto L001;
            }
            if (sCmd == M2Share.sSC_EXEACTION)
            {
                nCMDCode = M2Share.nSC_EXEACTION;
                goto L001;
            }
            if (sCmd == M2Share.sMAPMOVE)
            {
                nCMDCode = M2Share.nMAPMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sMAP)
            {
                nCMDCode = M2Share.nMAP;
                goto L001;
            }
            if (sCmd == M2Share.sTAKECHECKITEM)
            {
                nCMDCode = M2Share.nTAKECHECKITEM;
                goto L001;
            }
            if (sCmd == M2Share.sMONGEN)
            {
                nCMDCode = M2Share.nMONGEN;
                goto L001;
            }
            if (sCmd == M2Share.sMONCLEAR)
            {
                nCMDCode = M2Share.nMONCLEAR;
                goto L001;
            }
            if (sCmd == M2Share.sMOV)
            {
                nCMDCode = M2Share.nMOV;
                goto L001;
            }
            if (sCmd == M2Share.sINC)
            {
                nCMDCode = M2Share.nINC;
                goto L001;
            }
            if (sCmd == M2Share.sDEC)
            {
                nCMDCode = M2Share.nDEC;
                goto L001;
            }
            if (sCmd == M2Share.sSUM)
            {
                nCMDCode = M2Share.nSUM;
                goto L001;
            }
            // -------------------------------------------------------
            // 变量运算
            if (sCmd == M2Share.sSC_DIV) // 除法
            {
                nCMDCode = M2Share.nSC_DIV;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MUL)  // 乘法
            {
                nCMDCode = M2Share.nSC_MUL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PERCENT) // 百分比
            {
                nCMDCode = M2Share.nSC_PERCENT;
                goto L001;
            }
            // --------------------------------------------------------
            if (sCmd == M2Share.sBREAKTIMERECALL)
            {
                nCMDCode = M2Share.nBREAKTIMERECALL;
                goto L001;
            }
            if (sCmd == M2Share.sMOVR)
            {
                nCMDCode = M2Share.nMOVR;
                goto L001;
            }
            if (sCmd == M2Share.sEXCHANGEMAP)
            {
                nCMDCode = M2Share.nEXCHANGEMAP;
                goto L001;
            }
            if (sCmd == M2Share.sRECALLMAP)
            {
                nCMDCode = M2Share.nRECALLMAP;
                goto L001;
            }
            if (sCmd == M2Share.sADDBATCH)
            {
                nCMDCode = M2Share.nADDBATCH;
                goto L001;
            }
            if (sCmd == M2Share.sBATCHDELAY)
            {
                nCMDCode = M2Share.nBATCHDELAY;
                goto L001;
            }
            if (sCmd == M2Share.sBATCHMOVE)
            {
                nCMDCode = M2Share.nBATCHMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sPLAYDICE)
            {
                nCMDCode = M2Share.nPLAYDICE;
                goto L001;
            }
            if (sCmd == M2Share.sGOQUEST)
            {
                nCMDCode = M2Share.nGOQUEST;
                goto L001;
            }
            if (sCmd == M2Share.sENDQUEST)
            {
                nCMDCode = M2Share.nENDQUEST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_HAIRSTYLE)
            {
                nCMDCode = M2Share.nSC_HAIRSTYLE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGELEVEL)
            {
                nCMDCode = M2Share.nSC_CHANGELEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MARRY)
            {
                nCMDCode = M2Share.nSC_MARRY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_UNMARRY)
            {
                nCMDCode = M2Share.nSC_UNMARRY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GETMARRY)
            {
                nCMDCode = M2Share.nSC_GETMARRY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GETMASTER)
            {
                nCMDCode = M2Share.nSC_GETMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARSKILL)
            {
                nCMDCode = M2Share.nSC_CLEARSKILL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELNOJOBSKILL)
            {
                nCMDCode = M2Share.nSC_DELNOJOBSKILL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELSKILL)
            {
                nCMDCode = M2Share.nSC_DELSKILL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ADDSKILL)
            {
                nCMDCode = M2Share.nSC_ADDSKILL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ADDGUILDMEMBER)// 添加行会成员
            {
                nCMDCode = M2Share.nSC_ADDGUILDMEMBER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELGUILDMEMBER)// 删除行会成员（删除掌门无效）
            {
                nCMDCode = M2Share.nSC_DELGUILDMEMBER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SKILLLEVEL)
            {
                nCMDCode = M2Share.nSC_SKILLLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_HEROSKILLLEVEL)// 调整英雄技能等级
            {
                nCMDCode = M2Share.nSC_HEROSKILLLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEPKPOINT)
            {
                nCMDCode = M2Share.nSC_CHANGEPKPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEEXP) // 调整角色经验
            {
                nCMDCode = M2Share.nSC_CHANGEEXP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGENGEXP) // 调整角色内功经验
            {
                nCMDCode = M2Share.nSC_CHANGENGEXP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGENGLEVEL) // 调整角色内功等级
            {
                nCMDCode = M2Share.nSC_CHANGENGLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SENDTIMEMSG)// 时间到触发QF段(客户端显示信息) 
            {
                nCMDCode = M2Share.nSC_SENDTIMEMSG;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SENDMSGWINDOWS)// 时间到触发QF段 
            {
                nCMDCode = M2Share.nSC_SENDMSGWINDOWS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLOSEMSGWINDOWS)// 关闭客户端'!'图标的显示 
            {
                nCMDCode = M2Share.nSC_CLOSEMSGWINDOWS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GETGROUPCOUNT)// 取组队成员数 
            {
                nCMDCode = M2Share.nSC_GETGROUPCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_OPENEXPCRYSTAL)// 客户端显示天地结晶
            {
                nCMDCode = M2Share.nSC_OPENEXPCRYSTAL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLOSEEXPCRYSTAL)// 客户端关闭天地结晶图标
            {
                nCMDCode = M2Share.nSC_CLOSEEXPCRYSTAL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GETEXPTOCRYSTAL)// 取提天地结晶中的经验(只提取可提取的经验) 
            {
                nCMDCode = M2Share.nSC_GETEXPTOCRYSTAL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEJOB)
            {
                nCMDCode = M2Share.nSC_CHANGEJOB;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MISSION)
            {
                nCMDCode = M2Share.nSC_MISSION;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MOBPLACE)
            {
                nCMDCode = M2Share.nSC_MOBPLACE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SETMEMBERTYPE)
            {
                nCMDCode = M2Share.nSC_SETMEMBERTYPE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SETMEMBERLEVEL)
            {
                nCMDCode = M2Share.nSC_SETMEMBERLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GAMEGOLD)// 调整游戏币的命令
            {
                nCMDCode = M2Share.nSC_GAMEGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GAMEDIAMOND)// 调整金刚石数量 
            {
                nCMDCode = M2Share.nSC_GAMEDIAMOND;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GAMEGIRD)// 调整灵符数量 
            {
                nCMDCode = M2Share.nSC_GAMEGIRD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GAMEGLORY)// 调整荣誉值 
            {
                nCMDCode = M2Share.nSC_GAMEGLORY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHEROLOYAL)// 调整英雄的忠诚度 
            {
                nCMDCode = M2Share.nSC_CHANGEHEROLOYAL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHUMABILITY) // 调整人物属性 
            {
                nCMDCode = M2Share.nSC_CHANGEHUMABILITY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHEROTRANPOINT)// 调整英雄技能升级点数 
            {
                nCMDCode = M2Share.nSC_CHANGEHEROTRANPOINT;
                goto L001;
            }
            // --------------------酒馆系统------------------------------------------------
            if (sCmd == M2Share.sSC_SAVEHERO) // 寄放英雄 
            {
                nCMDCode = M2Share.nSC_SAVEHERO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GETHERO) // 取回英雄 
            {
                nCMDCode = M2Share.nSC_GETHERO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLOSEDRINK)// 关闭斗酒窗口 
            {
                nCMDCode = M2Share.nSC_CLOSEDRINK;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PLAYDRINKMSG)// 斗酒窗口说话信息 
            {
                nCMDCode = M2Share.nSC_PLAYDRINKMSG;
                goto L001;
            }
            if (sCmd == M2Share.sSC_OPENPLAYDRINK)// 指定人物喝酒
            {
                nCMDCode = M2Share.nSC_OPENPLAYDRINK;
                goto L001;
            }
            // ----------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_GAMEPOINT)
            {
                nCMDCode = M2Share.nSC_GAMEPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_PKZONE)
            {
                nCMDCode = M2Share.nSC_PKZONE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_RESTBONUSPOINT)
            {
                nCMDCode = M2Share.nSC_RESTBONUSPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_TAKECASTLEGOLD)
            {
                nCMDCode = M2Share.nSC_TAKECASTLEGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_HUMANHP)
            {
                nCMDCode = M2Share.nSC_HUMANHP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_HUMANMP)
            {
                nCMDCode = M2Share.nSC_HUMANMP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_BUILDPOINT)
            {
                nCMDCode = M2Share.nSC_BUILDPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_AURAEPOINT)
            {
                nCMDCode = M2Share.nSC_AURAEPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_STABILITYPOINT)
            {
                nCMDCode = M2Share.nSC_STABILITYPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_FLOURISHPOINT)
            {
                nCMDCode = M2Share.nSC_FLOURISHPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_OPENMAGICBOX)
            {
                nCMDCode = M2Share.nSC_OPENMAGICBOX;
                goto L001;
            }
            if (sCmd == M2Share.sSC_OPENBOX)  //开宝箱
            {
                nCMDCode = M2Share.nSC_OPENMAGICBOX;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SETRANKLEVELNAME)
            {
                nCMDCode = M2Share.nSC_SETRANKLEVELNAME;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GMEXECUTE)
            {
                nCMDCode = M2Share.nSC_GMEXECUTE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GUILDCHIEFITEMCOUNT)
            {
                nCMDCode = M2Share.nSC_GUILDCHIEFITEMCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MOBFIREBURN)
            {
                nCMDCode = M2Share.nSC_MOBFIREBURN;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MESSAGEBOX)
            {
                nCMDCode = M2Share.nSC_MESSAGEBOX;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SETSCRIPTFLAG)
            {
                nCMDCode = M2Share.nSC_SETSCRIPTFLAG;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SETAUTOGETEXP)
            {
                nCMDCode = M2Share.nSC_SETAUTOGETEXP;
                goto L001;
            }
            if (sCmd == M2Share.sSC_VAR)
            {
                nCMDCode = M2Share.nSC_VAR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_LOADVAR)
            {
                nCMDCode = M2Share.nSC_LOADVAR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SAVEVAR)
            {
                nCMDCode = M2Share.nSC_SAVEVAR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CALCVAR)
            {
                nCMDCode = M2Share.nSC_CALCVAR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_AUTOADDGAMEGOLD)
            {
                nCMDCode = M2Share.nSC_AUTOADDGAMEGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_AUTOSUBGAMEGOLD)
            {
                nCMDCode = M2Share.nSC_AUTOSUBGAMEGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARNAMELIST)
            {
                nCMDCode = M2Share.nSC_CLEARNAMELIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGENAMECOLOR)
            {
                nCMDCode = M2Share.nSC_CHANGENAMECOLOR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARPASSWORD)
            {
                nCMDCode = M2Share.nSC_CLEARPASSWORD;
                goto L001;
            }
            if (sCmd == M2Share.sSC_RENEWLEVEL)
            {
                nCMDCode = M2Share.nSC_RENEWLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_KILLMONEXPRATE)
            {
                nCMDCode = M2Share.nSC_KILLMONEXPRATE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_POWERRATE)
            {
                nCMDCode = M2Share.nSC_POWERRATE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEMODE)
            {
                nCMDCode = M2Share.nSC_CHANGEMODE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEPERMISSION)
            {
                nCMDCode = M2Share.nSC_CHANGEPERMISSION;
                goto L001;
            }
            if (sCmd == M2Share.sSC_KILL)
            {
                nCMDCode = M2Share.nSC_KILL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_KICK)
            {
                nCMDCode = M2Share.nSC_KICK;
                goto L001;
            }
            if (sCmd == M2Share.sSC_BONUSPOINT)
            {
                nCMDCode = M2Share.nSC_BONUSPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_RESTRENEWLEVEL)
            {
                nCMDCode = M2Share.nSC_RESTRENEWLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELMARRY)
            {
                nCMDCode = M2Share.nSC_DELMARRY;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELMASTER)
            {
                nCMDCode = M2Share.nSC_DELMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MASTER)
            {
                nCMDCode = M2Share.nSC_MASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_UNMASTER)
            {
                nCMDCode = M2Share.nSC_UNMASTER;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CREDITPOINT)
            {
                nCMDCode = M2Share.nSC_CREDITPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEGUILDMEMBERCOUNT)// 调整行会成员上限
            {
                nCMDCode = M2Share.nSC_CHANGEGUILDMEMBERCOUNT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEGUILDFOUNTAIN)// 调整行会酒泉
            {
                nCMDCode = M2Share.nSC_CHANGEGUILDFOUNTAIN;
                goto L001;
            }
            if (sCmd == M2Share.sSC_TAGMAPINFO) // 记路标石
            {
                nCMDCode = M2Share.nSC_TAGMAPINFO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_TAGMAPMOVE) // 移动到记路标石记录的XY
            {
                nCMDCode = M2Share.nSC_TAGMAPMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARNEEDITEMS)
            {
                nCMDCode = M2Share.nSC_CLEARNEEDITEMS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARMAKEITEMS)
            {
                nCMDCode = M2Share.nSC_CLEARMAEKITEMS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SETSENDMSGFLAG)
            {
                nCMDCode = M2Share.nSC_SETSENDMSGFLAG;
                goto L001;
            }
            if (sCmd == M2Share.sSC_UPGRADEITEMS)
            {
                nCMDCode = M2Share.nSC_UPGRADEITEMS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_UPGRADEITEMSEX)
            {
                nCMDCode = M2Share.nSC_UPGRADEITEMSEX;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GIVEMINE) // 给矿石 
            {
                nCMDCode = M2Share.nSC_GIVEMINE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_MONGENEX)
            {
                nCMDCode = M2Share.nSC_MONGENEX;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARMAPMON)
            {
                nCMDCode = M2Share.nSC_CLEARMAPMON;
                goto L001;
            }
            if (sCmd == M2Share.sSC_SETMAPMODE)
            {
                nCMDCode = M2Share.nSC_SETMAPMODE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_KILLSLAVE)
            {
                nCMDCode = M2Share.nSC_KILLSLAVE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEGENDER)
            {
                nCMDCode = M2Share.nSC_CHANGEGENDER;
                goto L001;
            }
            if (sCmd == M2Share.sOFFLINEPLAY)
            {
                nCMDCode = M2Share.nOFFLINEPLAY;
                goto L001;
            }
            if (sCmd == M2Share.sKICKOFFLINE)
            {
                nCMDCode = M2Share.nKICKOFFLINE;
                goto L001;
            }
            if (sCmd == M2Share.sSTARTTAKEGOLD)
            {
                nCMDCode = M2Share.nSTARTTAKEGOLD;
                goto L001;
            }
            if (sCmd == M2Share.sDELAYGOTO)
            {
                nCMDCode = M2Share.nDELAYGOTO;
                goto L001;
            }
            if (sCmd == M2Share.sDELAYCALL)
            {
                nCMDCode = M2Share.nDELAYGOTO;//加对blue延时脚本支持
                goto L001;
            }
            if (sCmd == M2Share.sCLEARDELAYGOTO)
            {
                nCMDCode = M2Share.nCLEARDELAYGOTO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ADDUSERDATE)
            {
                nCMDCode = M2Share.nSC_ADDUSERDATE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELUSERDATE)
            {
                nCMDCode = M2Share.nSC_DELUSERDATE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ANSIREPLACETEXT)
            {
                nCMDCode = M2Share.nSC_ANSIREPLACETEXT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ENCODETEXT)
            {
                nCMDCode = M2Share.nSC_ENCODETEXT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_ADDTEXTLIST)
            {
                nCMDCode = M2Share.nSC_ADDTEXTLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELTEXTLIST)
            {
                nCMDCode = M2Share.nSC_DELTEXTLIST;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GROUPMOVE)
            {
                nCMDCode = M2Share.nSC_GROUPMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GROUPMAPMOVE)
            {
                nCMDCode = M2Share.nSC_GROUPMAPMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_RECALLHUMAN)
            {
                nCMDCode = M2Share.nSC_RECALLHUMAN;
                goto L001;
            }
            if (sCmd == M2Share.sSC_REGOTO)
            {
                nCMDCode = M2Share.nSC_REGOTO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_INTTOSTR)
            {
                nCMDCode = M2Share.nSC_INTTOSTR;
                goto L001;
            }
            if (sCmd == M2Share.sSC_STRTOINT)
            {
                nCMDCode = M2Share.nSC_STRTOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GUILDMOVE)
            {
                nCMDCode = M2Share.nSC_GUILDMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GUILDMAPMOVE)
            {
                nCMDCode = M2Share.nSC_GUILDMAPMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_RANDOMMOVE)
            {
                nCMDCode = M2Share.nSC_RANDOMMOVE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_USEBONUSPOINT)
            {
                nCMDCode = M2Share.nSC_USEBONUSPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_BONUSABIL)
            {
                nCMDCode = M2Share.nSC_USEBONUSPOINT;//增加变量支持
                goto L001;
            }
            if (sCmd == M2Share.sSC_REPAIRITEM)
            {
                nCMDCode = M2Share.nSC_REPAIRITEM;
                goto L001;
            }
            if (sCmd == M2Share.sSC_TAKEONITEM)
            {
                nCMDCode = M2Share.nSC_TAKEONITEM;
                goto L001;
            }
            if (sCmd == M2Share.sSC_TAKEOFFITEM)
            {
                nCMDCode = M2Share.nSC_TAKEOFFITEM;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CREATEHERO)
            {
                nCMDCode = M2Share.nSC_CREATEHERO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_DELETEHERO)
            {
                nCMDCode = M2Share.nSC_DELETEHERO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHEROLEVEL)
            {
                nCMDCode = M2Share.nSC_CHANGEHEROLEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHEROJOB)
            {
                nCMDCode = M2Share.nSC_CHANGEHEROJOB;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLEARHEROSKILL)
            {
                nCMDCode = M2Share.nSC_CLEARHEROSKILL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHEROPKPOINT)
            {
                nCMDCode = M2Share.nSC_CHANGEHEROPKPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHEROEXP)
            {
                nCMDCode = M2Share.nSC_CHANGEHEROEXP;
                goto L001;
            }
            // --------------------连击相关--------------------------------//
            if (sCmd == M2Share.sSC_OPENMAKEKIMNEEDLE)
            {
                nCMDCode = M2Share.nSC_OPENMAKEKIMNEEDLE; // 客户端显示锻练金针窗口
                goto L001;
            }
            if (sCmd == M2Share.sSC_TAKEKIMNEEDLE)
            {
                nCMDCode = M2Share.nSC_TAKEKIMNEEDLE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_GIVEKIMNEEDLE)
            {
                nCMDCode = M2Share.nSC_GIVEKIMNEEDLE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_OPENPULSE)
            {
                nCMDCode = M2Share.nSC_OPENPULSE;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEPULSELEVEL)
            {
                nCMDCode = M2Share.nSC_CHANGEPULSELEVEL;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGHEARMSGCOLOR)
            {
                nCMDCode = M2Share.nSC_CHANGHEARMSGCOLOR;// 未实现
                goto L001;
            }
            if (sCmd == M2Share.sSC_OPENCATTLEGAS)
            {
                nCMDCode = M2Share.nSC_OPENCATTLEGAS;// 未实现
                goto L001;
            }
            if (sCmd == M2Share.sSC_OPENHEROPULS)
            {
                nCMDCode = M2Share.nSC_OPENHEROPULS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGEHEROPULSEXP)
            {
                nCMDCode = M2Share.nSC_CHANGEHEROPULSEXP;
                goto L001;
            }
            // --------------------富贵兽相关------------------------------------------------
            if (sCmd == M2Share.sSC_OPENCATTLEGAS)
            {
                nCMDCode = M2Share.nSC_OPENCATTLEGAS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CLOSECATTLEGAS)
            {
                nCMDCode = M2Share.nSC_CLOSECATTLEGAS;
                goto L001;
            }
            if (sCmd == M2Share.sSC_CHANGECATTLEGASEXP)
            {
                nCMDCode = M2Share.nSC_CHANGECATTLEGASEXP;
                goto L001;
            }
            // ------------------------------------------------------------------------------
            if (sCmd == M2Share.sSC_TAKEITMECOUNTDURA)
            {
                nCMDCode = M2Share.nSC_TAKEITMECOUNTDURA;
                goto L001;
            }
            // -------双英雄相关--------------------//
            if (sCmd == M2Share.sSC_ASSESSMENTHERO)
            {
                nCMDCode = M2Share.nSC_ASSESSMENTHERO;
                goto L001;
            }
            if (sCmd == M2Share.sSC_OpenHeroAutoPractice)
            {
                nCMDCode = M2Share.nSC_OpenHeroAutoPractice;
                goto L001;
            }
            if (sCmd == M2Share.sSC_StopHeroAutoPractice)
            {
                nCMDCode = M2Share.nSC_StopHeroAutoPractice;
                goto L001;
            }
            // -----------------------------------------------
            if (sCmd == M2Share.sSC_CHANGETRANPOINT)
            {
                // 技能名 操作符(+ - =) 数值
                nCMDCode = M2Share.nSC_CHANGETRANPOINT;
                goto L001;
            }
            if (sCmd == M2Share.sSC_NPCGIVEITEM)
            {
                nCMDCode = M2Share.nSC_NPCGIVEITEM;
                goto L001;
            }
        L001:
            if (nCMDCode > 0)
            {
                QuestActionInfo.nCMDCode = nCMDCode;
                if ((sParam1 != "") && (sParam1[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam1, "\"", "\"", ref sParam1);
                }
                if ((sParam2 != "") && (sParam2[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam2, "\"", "\"", ref sParam2);
                }
                if ((sParam3 != "") && (sParam3[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam3, "\"", "\"", ref sParam3);
                }
                if ((sParam4 != "") && (sParam4[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam4, "\"", "\"", ref sParam4);
                }
                if ((sParam5 != "") && (sParam5[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam5, "\"", "\"", ref sParam5);
                }
                if ((sParam6 != "") && (sParam6[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam6, "\"", "\"", ref sParam6);
                }
                if ((sParam7 != "") && (sParam7[0] == '\''))
                {
                    HUtil32.ArrestStringEx(sParam7, "\"", "\"", ref sParam7);
                }
                QuestActionInfo.sParam1 = sParam1;
                QuestActionInfo.sParam2 = sParam2;
                QuestActionInfo.sParam3 = sParam3;
                QuestActionInfo.sParam4 = sParam4;
                QuestActionInfo.sParam5 = sParam5;
                QuestActionInfo.sParam6 = sParam6;
                QuestActionInfo.sParam7 = sParam7;
                if (HUtil32.IsStringNumber(sParam1))
                {
                    QuestActionInfo.nParam1 = HUtil32.Str_ToInt(sParam1, 0);
                }
                if (HUtil32.IsStringNumber(sParam2))
                {
                    QuestActionInfo.nParam2 = HUtil32.Str_ToInt(sParam2, 1);
                }
                if (HUtil32.IsStringNumber(sParam3))
                {
                    QuestActionInfo.nParam3 = HUtil32.Str_ToInt(sParam3, 1);
                }
                if (HUtil32.IsStringNumber(sParam4))
                {
                    QuestActionInfo.nParam4 = HUtil32.Str_ToInt(sParam4, 0);
                }
                if (HUtil32.IsStringNumber(sParam5))
                {
                    QuestActionInfo.nParam5 = HUtil32.Str_ToInt(sParam5, 0);
                }
                if (HUtil32.IsStringNumber(sParam6))
                {
                    QuestActionInfo.nParam6 = HUtil32.Str_ToInt(sParam6, 0);
                }
                if (HUtil32.IsStringNumber(sParam7))
                {
                    QuestActionInfo.nParam7 = HUtil32.Str_ToInt(sParam7, 0);
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 读取脚本文件
        /// </summary>
        /// <param name="NPC"></param>
        /// <param name="sPatch"></param>
        /// <param name="sScritpName"></param>
        /// <param name="boFlag"></param>
        /// <returns></returns>
        public int LoadScriptFile(TNormNpc NPC, string sPatch, string sScritpName, bool boFlag)
        {
            int result;
            int nQuestIdx;
            int I; int n1C; int n20; int n24; int nItemType;
            int nPriceRate; int n6C; int n70;
            string s30 = string.Empty; string s34 = string.Empty; string s38 = string.Empty;
            string s3C = string.Empty; string s40 = string.Empty; string s44 = string.Empty;
            string s48 = string.Empty; string s4C = string.Empty; string s50 = string.Empty;
            TStringList LoadList;
            IList<TDefineInfo> DefineList;
            string s54 = string.Empty; string s58 = string.Empty; string s5C = string.Empty; string s74 = string.Empty;
            TDefineInfo DefineInfo;
            bool bo8D;
            TScript Script;
            TSayingRecord SayingRecord;
            TSayingProcedure SayingProcedure = null;
            TQuestConditionInfo QuestConditionInfo;
            TQuestActionInfo QuestActionInfo;
            TGoods Goods;
            result = -1;
            n6C = 0;
            n70 = 0;
            bo8D = false;
            string sScritpFileName = M2Share.g_Config.sEnvirDir + sPatch + sScritpName + ".txt";
            if (File.Exists(sScritpFileName))
            {
                LoadList = new TStringList();
                try
                {
                    LoadList.LoadFromFile(sScritpFileName);
                }
                catch
                {
                    return result;
                }
                I = 0;
                while (true)
                {
                    LoadScriptFile_LoadScriptcall(ref LoadList);
                    I++;
                    if (I >= 10)
                    {
                        break;
                    }
                }
                DefineList = new List<TDefineInfo>();
                s54 = LoadScriptFile_LoadDefineInfo(ref LoadList, ref DefineList);
                DefineInfo = new TDefineInfo();
                DefineInfo.sName = "@HOME";
                if (s54 == "")
                {
                    s54 = "@main";
                }
                DefineInfo.sText = s54;
                DefineList.Add(DefineInfo);
                // 常量处理
                for (I = 0; I < LoadList.Count; I++)
                {
                    s34 = LoadList[I].Trim();
                    if ((s34 != ""))
                    {
                        if ((s34[0] == '['))
                        {
                            bo8D = false;
                        }
                        else
                        {
                            if ((s34[0] == '#') && (HUtil32.CompareLStr(s34, "#IF", 3) || HUtil32.CompareLStr(s34, "#ACT", 4) || HUtil32.CompareLStr(s34, "#ELSEACT", 8)))
                            {
                                bo8D = true;
                            }
                            else
                            {
                                if (bo8D)
                                {
                                    // 将Define 好的常量换成指定值
                                    for (n20 = 0; n20 < DefineList.Count; n20++)
                                    {
                                        DefineInfo = DefineList[n20];
                                        n1C = 0;
                                        while (true)
                                        {
                                            n24 = s34.ToUpper().IndexOf(DefineInfo.sName);
                                            if (n24 <= 0)
                                            {
                                                break;
                                            }
                                            s58 = s34.Substring(1 - 1, n24 - 1);
                                            s5C = s34.Substring(DefineInfo.sName.Length + n24 - 1, 256);
                                            s34 = s58 + DefineInfo.sText + s5C;
                                            LoadList[I] = s34;
                                            n1C++;
                                            if (n1C >= 10)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // 常量处理
                // 释放常量定义内容
                if (DefineList.Count > 0)
                {
                    for (I = 0; I < DefineList.Count; I++)
                    {
                        if ((DefineList[I]) != null)
                        {
                            Dispose(DefineList[I]);
                        }
                    }
                }
                Dispose(DefineList);// 释放常量定义内容
                Script = null;
                SayingRecord = null;
                nQuestIdx = 0;
                for (I = 0; I < LoadList.Count; I++)
                {
                    s34 = LoadList[I].Trim();
                    if ((s34 == "") || (s34[0] == ';') || (s34[0] == '/'))
                    {
                        continue;
                    }
                    if ((n6C == 0) && boFlag)
                    {
                        if (s34[0] == '%')   // 物品价格倍率
                        {
                            s34 = s34.Substring(2 - 1, s34.Length - 1);
                            nPriceRate = HUtil32.Str_ToInt(s34, -1);
                            if (nPriceRate >= 55)
                            {
                                ((TMerchant)(NPC)).m_nPriceRate = nPriceRate;
                            }
                            continue;
                        }
                        // 物品交易类型
                        if (s34[0] == '+')
                        {
                            s34 = s34.Substring(2 - 1, s34.Length - 1);
                            nItemType = HUtil32.Str_ToInt(s34, -1);
                            if (nItemType >= 0)
                            {
                                ((TMerchant)(NPC)).m_ItemTypeList.Add(nItemType);
                            }
                            continue;
                        }
                        // 增加处理NPC可执行命令设置
                        if (s34[0] == '(')
                        {
                            HUtil32.ArrestStringEx(s34, "(", ")", ref s34);
                            if (s34 != "")
                            {
                                while ((s34 != ""))
                                {
                                    s34 = HUtil32.GetValidStr3(s34, ref s30, new string[] { " ", ",", "\t" });
                                    if (string.Compare(s30, M2Share.sBUY, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBuy = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sSELL, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boSell = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sMAKEDURG, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boMakeDrug = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sPRICES, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boPrices = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sSTORAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boStorage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sGETBACK, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetback = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sUPGRADENOW, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boUpgradenow = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sGETBACKUPGNOW, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetBackupgnow = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sREPAIR, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boRepair = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sSUPERREPAIR, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boS_repair = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sSL_SENDMSG, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boSendmsg = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sUSEITEMNAME, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boUseItemName = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sofflinemsg, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boofflinemsg = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sdealgold, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boDealGold = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sBIGSTORAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBigStorage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sBIGGETBACK, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBigGetBack = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sGETPREVIOUSPAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetPreviousPage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sGETNEXTPAGE, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boGetNextPage = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sUserLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boUserLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sWarrorLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boWarrorLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sWizardLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boWizardLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sTaoistLevelOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boTaoistLevelOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sMasterCountOrder, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boMasterCountOrder = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sLyCreateHero, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boHero = true;
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sBuHero, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boBuHero = true; // 酒馆英雄NPC
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sPlayMakeWine, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boPlayMakeWine = true;// 酿酒NPC
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sPlayDrink, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boPlayDrink = true;// 请酒,斗酒NPC
                                        continue;
                                    }
                                    if (string.Compare(s30, M2Share.sybdeal, true) == 0)
                                    {
                                        ((TMerchant)(NPC)).m_boYBDeal = true;// 元宝寄售NPC属性
                                        continue;
                                    }
                                }
                            }
                            continue;
                        }
                    }
                    if (s34[0] == '{')
                    {
                        if (HUtil32.CompareLStr(s34, "{Quest", 6))
                        {
                            s38 = HUtil32.GetValidStr3(s34, ref s3C, new string[] { " ", "}", "\t" });
                            HUtil32.GetValidStr3(s38, ref s3C, new string[] { " ", "}", "\t" });
                            n70 = HUtil32.Str_ToInt(s3C, 0);
                            Script = LoadScriptFile_MakeNewScript(ref nQuestIdx, ref NPC);
                            Script.nQuest = n70;
                            n70++;
                        }
                        if (HUtil32.CompareLStr(s34, "{~Quest", 7))
                        {
                            continue;
                        }
                    }
                    if ((n6C == 1) && (Script != null) && (s34[0] == '#'))
                    {
                        s38 = HUtil32.GetValidStr3(s34, ref s3C, new string[] { "=", " ", "\t" });
                        Script.boQuest = true;
                        if (HUtil32.CompareLStr(s34, "#IF", 3))
                        {
                            HUtil32.ArrestStringEx(s34, "[", "]", ref s40);
                            Script.QuestInfo[nQuestIdx].wFlag = (ushort)HUtil32.Str_ToInt(s40, 0);
                            HUtil32.GetValidStr3(s38, ref s44, new string[] { "=", " ", "\t" });
                            n24 = HUtil32.Str_ToInt(s44, 0);
                            if (n24 != 0)
                            {
                                n24 = 1;
                            }
                            Script.QuestInfo[nQuestIdx].btValue = (byte)n24;
                        }
                        if (HUtil32.CompareLStr(s34, "#RAND", 5))
                        {
                            Script.QuestInfo[nQuestIdx].nRandRage = HUtil32.Str_ToInt(s44, 0);
                        }
                        continue;
                    }
                    if (s34[0] == '[')
                    {
                        n6C = 10;
                        if (Script == null)
                        {
                            Script = LoadScriptFile_MakeNewScript(ref nQuestIdx, ref NPC);
                            Script.nQuest = n70;
                        }
                        if (string.Compare(s34, "[goods]", true) == 0)
                        {
                            n6C = 20;
                            continue;
                        }
                        s34 = HUtil32.ArrestStringEx(s34, "[", "]", ref s74);
                        SayingRecord = new TSayingRecord();
                        SayingRecord.ProcedureList = new List<TSayingProcedure>();
                        SayingRecord.sLabel = s74;
                        s34 = HUtil32.GetValidStrCap(s34, ref s74, new string[] { " ", "\t" });
                        if (string.Compare(s74, "TRUE", true) == 0)
                        {
                            SayingRecord.boExtJmp = true;
                        }
                        else
                        {
                            SayingRecord.boExtJmp = false;
                        }
                        SayingProcedure = new TSayingProcedure();
                        SayingRecord.ProcedureList.Add(SayingProcedure);
                        SayingProcedure.ConditionList = new List<TQuestConditionInfo>();
                        SayingProcedure.ActionList = new List<TQuestActionInfo>();
                        SayingProcedure.sSayMsg = "";
                        SayingProcedure.ElseActionList = new List<TQuestActionInfo>();
                        SayingProcedure.sElseSayMsg = "";
                        Script.RecordList.Add(SayingRecord);
                        continue;
                    }
                    if ((Script != null) && (SayingRecord != null))
                    {
                        if ((n6C >= 10) && (n6C < 20) && (s34[0] == '#'))
                        {
                            if (string.Compare(s34, "#IF", true) == 0)
                            {
                                if ((SayingProcedure.ConditionList.Count > 0) || (SayingProcedure.sSayMsg != ""))
                                {
                                    SayingProcedure = new TSayingProcedure();
                                    SayingRecord.ProcedureList.Add(SayingProcedure);
                                    SayingProcedure.ConditionList = new List<TQuestConditionInfo>();
                                    SayingProcedure.ActionList = new List<TQuestActionInfo>();
                                    SayingProcedure.sSayMsg = "";
                                    SayingProcedure.ElseActionList = new List<TQuestActionInfo>();
                                    SayingProcedure.sElseSayMsg = "";
                                }
                                n6C = 11;
                            }
                            if (string.Compare(s34, "#ACT", true) == 0)
                            {
                                n6C = 12;
                            }
                            if (string.Compare(s34, "#SAY", true) == 0)
                            {
                                n6C = 10;
                            }
                            if (string.Compare(s34, "#ELSEACT", true) == 0)
                            {
                                n6C = 13;
                            }
                            if (string.Compare(s34, "#ELSESAY", true) == 0)
                            {
                                n6C = 14;
                            }
                            continue;
                        }
                        if ((n6C == 10) && (SayingProcedure != null))
                        {
                            SayingProcedure.sSayMsg = SayingProcedure.sSayMsg + s34;
                        }
                        if ((n6C == 11))
                        {
                            QuestConditionInfo = new TQuestConditionInfo();
                            if (LoadScriptFile_QuestCondition(s34.Trim(), ref QuestConditionInfo))
                            {
                                SayingProcedure.ConditionList.Add(QuestConditionInfo);
                            }
                            else
                            {
                                Dispose(QuestConditionInfo);
                                MainOutMessage("脚本错误1: " + s34 + " 第:" + (I).ToString() + " 行: " + sScritpFileName);
                            }
                        }
                        if ((n6C == 12))
                        {
                            QuestActionInfo = new TQuestActionInfo();
                            if (LoadScriptFile_QuestAction(s34.Trim(), ref QuestActionInfo))
                            {
                                SayingProcedure.ActionList.Add(QuestActionInfo);
                            }
                            else
                            {
                                Dispose(QuestActionInfo);
                                MainOutMessage("脚本错误2: " + s34 + " 第:" + (I).ToString() + " 行: " + sScritpFileName);
                            }
                        }
                        if ((n6C == 13))
                        {
                            QuestActionInfo = new TQuestActionInfo();
                            if (LoadScriptFile_QuestAction(s34.Trim(), ref QuestActionInfo))
                            {
                                SayingProcedure.ElseActionList.Add(QuestActionInfo);
                            }
                            else
                            {
                                Dispose(QuestActionInfo);
                                MainOutMessage("脚本错误3: " + s34 + " 第:" + (I).ToString() + " 行: " + sScritpFileName);
                            }
                        }
                        if ((n6C == 14))
                        {
                            SayingProcedure.sElseSayMsg = SayingProcedure.sElseSayMsg + s34;
                        }
                    }
                    if ((n6C == 20) && boFlag)
                    {
                        s34 = HUtil32.GetValidStrCap(s34, ref s48, new string[] { " ", "\t" });
                        s34 = HUtil32.GetValidStrCap(s34, ref s4C, new string[] { " ", "\t" });
                        s34 = HUtil32.GetValidStrCap(s34, ref s50, new string[] { " ", "\t" });
                        if ((s48 != "") && (s50 != ""))
                        {
                            Goods = new TGoods();
                            if ((s48 != "") && (s48[0] == '\''))
                            {
                                HUtil32.ArrestStringEx(s48, "\"", "\"", ref s48);
                            }
                            Goods.sItemName = s48;
                            Goods.nCount = HUtil32.Str_ToInt(s4C, 0);
                            Goods.dwRefillTime = (uint)HUtil32.Str_ToInt(s50, 0);
                            Goods.dwRefillTick = 0;
                            ((TMerchant)(NPC)).m_RefillGoodsList.Add(Goods);
                        }
                    }
                }
            }
            else
            {
                MainOutMessage("脚本文件未找到: " + sScritpFileName);
            }

            result = 1;
            return result;
        }

        public int SaveGoodRecord(TMerchant NPC, string sFile)
        {
            int result = 0;
            //int I;
            //int II;
            //string sFileName;
            //int FileHandle;
            //TUserItem* UserItem;
            //ArrayList List;
            //TGoodFileHeader Header420;
            //result =  -1;
            //sFileName = ".\\Envir\\Market_Saved\\" + sFile + ".sav";
            //if (File.Exists(sFileName))
            //{
            //    FileHandle = File.Open(sFileName, (FileMode) FileAccess.Write | FileShare.ReadWrite);
            //}
            //else
            //{
            //    FileHandle = File.Create(sFileName);
            //}
            //if (FileHandle > 0)
            //{
            //    FillChar(Header420, sizeof(TGoodFileHeader), '\0');
            //    if (NPC.m_GoodsList.Count > 0)
            //    {
            //        for (I = 0; I < NPC.m_GoodsList.Count; I ++ )
            //        {
            //            List = ((NPC.m_GoodsList[I]) as ArrayList);
            //            Header420.nItemCount += List.Count;
            //        }
            //    }
            //    FileWrite(FileHandle, Header420, sizeof(TGoodFileHeader));
            //    if (NPC.m_GoodsList.Count > 0)
            //    {
            //        for (I = 0; I < NPC.m_GoodsList.Count; I ++ )
            //        {
            //            List = ((NPC.m_GoodsList[I]) as ArrayList);
            //            if (List.Count > 0)
            //            {
            //                for (II = 0; II < List.Count; II ++ )
            //                {
            //                    UserItem = List[II];
            //                    FileWrite(FileHandle, UserItem, sizeof(TUserItem));
            //                }
            //            }
            //        }
            //    }
            //    FileHandle.Close();
            //    result = 1;
            //}
            return result;
        }

        public int SaveGoodPriceRecord(TMerchant NPC, string sFile)
        {
            int result = 0;
            //int I;
            //string sFileName;
            //int FileHandle;
            //TItemPrice ItemPrice;
            //TGoodFileHeader Header420;
            //result =  -1;
            //sFileName = ".\\Envir\\Market_Prices\\" + sFile + ".prc";
            //if (File.Exists(sFileName))
            //{
            //    FileHandle = File.Open(sFileName, (FileMode) FileAccess.Write | FileShare.ReadWrite);
            //}
            //else
            //{
            //    FileHandle = File.Create(sFileName);
            //}
            //if (FileHandle > 0)
            //{

            //    FillChar(Header420, sizeof(TGoodFileHeader), '\0');
            //    Header420.nItemCount = NPC.m_ItemPriceList.Count;

            //    FileWrite(FileHandle, Header420, sizeof(TGoodFileHeader));
            //    if (NPC.m_ItemPriceList.Count > 0)
            //    {
            //        // 20080629
            //        for (I = 0; I < NPC.m_ItemPriceList.Count; I ++ )
            //        {
            //            ItemPrice = NPC.m_ItemPriceList[I];

            //            FileWrite(FileHandle, ItemPrice, sizeof(TItemPrice));
            //        }
            //    }
            //    FileHandle.Close();
            //    result = 1;
            //}
            return result;
        }

        // 重新读取管理NPC
        public void ReLoadNpc()
        {
            string sFileName;
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            string s40 = string.Empty;
            string s42 = string.Empty;
            TStringList LoadList;
            TNormNpc NPC;
            int I;
            int II;
            int nX;
            int nY;
            bool boNewNpc;
            try
            {
                sFileName = M2Share.g_Config.sEnvirDir + "Npcs.txt";
                if (!File.Exists(sFileName))
                {
                    return;
                }
                if (UserEngine.QuestNPCList.Count > 0)
                {
                    for (I = 0; I < UserEngine.QuestNPCList.Count; I++)
                    {
                        NPC = UserEngine.QuestNPCList[I];
                        if ((NPC != M2Share.g_ManageNPC) && (NPC != M2Share.g_BatterNPC) && (NPC != M2Share.g_RobotNPC) && (NPC != M2Share.g_FunctionNPC) && (NPC.m_boIsQuest))
                        {
                            NPC.m_nFlag = -1;
                        }
                    }
                }
                LoadList = new TStringList();

                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        s18 = HUtil32.GetValidStrCap(s18, ref s20, new string[] { " ", "\t" });
                        if ((s20 != "") && (s20[0] == '\''))
                        {
                            HUtil32.ArrestStringEx(s20, "\"", "\"", ref s20);
                        }
                        s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s2C, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s30, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s34, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s38, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s40, new string[] { " ", "\t" });
                        s18 = HUtil32.GetValidStr3(s18, ref s42, new string[] { " ", "\t" });
                        if ((s20 != "") && (s28 != "") && (s38 != ""))
                        {
                            nX = HUtil32.Str_ToInt(s2C, 0);
                            nY = HUtil32.Str_ToInt(s30, 0);
                            boNewNpc = true;
                            if (UserEngine.QuestNPCList.Count > 0)
                            {
                                for (II = 0; II < UserEngine.QuestNPCList.Count; II++)
                                {
                                    NPC = UserEngine.QuestNPCList[II];
                                    if ((NPC.m_sMapName == s28) && (NPC.m_nCurrX == nX) && (NPC.m_nCurrY == nY))
                                    {
                                        boNewNpc = false;
                                        NPC.m_sCharName = s20;
                                        NPC.m_nFlag = Convert.ToSByte(HUtil32.Str_ToInt(s34, 0));
                                        NPC.m_wAppr = Convert.ToUInt16(HUtil32.Str_ToInt(s38, 0));
                                        if (HUtil32.Str_ToInt(s40, 0) != 0)
                                        {
                                            NPC.m_boNpcAutoChangeColor = true;
                                        }
                                        NPC.m_dwNpcAutoChangeColorTime = Convert.ToUInt32(HUtil32.Str_ToInt(s42, 0) * 1000);
                                        break;
                                    }
                                }
                            }
                            if (boNewNpc)
                            {
                                NPC = null;
                                switch (HUtil32.Str_ToInt(s24, 0))
                                {
                                    case 0:
                                        NPC = new TMerchant();
                                        break;
                                    case 1:
                                        NPC = new TGuildOfficial();
                                        break;
                                    case 2:
                                        NPC = new TCastleOfficial();
                                        break;
                                }
                                if (NPC != null)
                                {
                                    NPC.m_sMapName = s28;
                                    NPC.m_nCurrX = nX;
                                    NPC.m_nCurrY = nY;
                                    NPC.m_sCharName = s20;
                                    NPC.m_nFlag = Convert.ToSByte(HUtil32.Str_ToInt(s34, 0));
                                    NPC.m_wAppr = Convert.ToUInt16(HUtil32.Str_ToInt(s38, 0));
                                    if (HUtil32.Str_ToInt(s40, 0) != 0)
                                    {
                                        NPC.m_boNpcAutoChangeColor = true;
                                    }
                                    NPC.m_dwNpcAutoChangeColorTime = Convert.ToUInt32(HUtil32.Str_ToInt(s42, 0) * 1000);
                                    UserEngine.QuestNPCList.Add(NPC);
                                }
                            }
                        }
                    }
                }

                if (UserEngine.QuestNPCList.Count > 0)
                {
                    for (I = UserEngine.QuestNPCList.Count - 1; I >= 0; I--)
                    {
                        NPC = UserEngine.QuestNPCList[I];
                        if (NPC.m_nFlag == -1)
                        {
                            NPC.m_boGhost = true;
                            NPC.m_dwGhostTick = HUtil32.GetTickCount();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        // 重新读取交易NPC
        public void ReLoadMerchants()
        {
            int I;
            int II;
            int nX;
            int nY;
            string sLineText = string.Empty;
            string sFileName = string.Empty;
            string sScript = string.Empty;
            string sMapName = string.Empty;
            string sX = string.Empty;
            string sY = string.Empty;
            string sCharName = string.Empty;
            string sFlag = string.Empty;
            string sAppr = string.Empty;
            string sCastle = string.Empty;
            string sCanMove = string.Empty;
            string sMoveTime = string.Empty;
            TMerchant Merchant;
            TStringList LoadList;
            bool boNewNpc;
            sFileName = M2Share.g_Config.sEnvirDir + "Merchant.txt";
            if (!File.Exists(sFileName))
            {
                return;
            }
            lock (UserEngine.m_MerchantList)
                try
                {
                    if (UserEngine.m_MerchantList.Count > 0)
                    {
                        for (I = 0; I < UserEngine.m_MerchantList.Count; I++)
                        {
                            Merchant = UserEngine.m_MerchantList[I];
                            if (Merchant != null)
                            {
                                if ((Merchant != M2Share.g_FunctionNPC) && (Merchant != M2Share.g_BatterNPC) && (Merchant.m_boIsQuest)) // 增加 m_boIsQuest 条件
                                {
                                    Merchant.m_nFlag = -1;
                                }
                            }
                        }
                    }
                    LoadList = new TStringList();
                    try
                    {

                        LoadList.LoadFromFile(sFileName);
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I].Trim();
                            if ((sLineText != "") && (sLineText[0] != ';'))
                            {
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sScript, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sMapName, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sX, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sY, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sCharName, new string[] { " ", "\t" });
                                if ((sCharName != "") && (sCharName[0] != '\''))
                                {
                                    HUtil32.ArrestStringEx(sCharName, "\"", "\"", ref sCharName);
                                }
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sFlag, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sAppr, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sCastle, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sCanMove, new string[] { " ", "\t" });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sMoveTime, new string[] { " ", "\t" });
                                nX = HUtil32.Str_ToInt(sX, 0);
                                nY = HUtil32.Str_ToInt(sY, 0);
                                boNewNpc = true;
                                if (UserEngine.m_MerchantList.Count > 0)
                                {
                                    for (II = 0; II < UserEngine.m_MerchantList.Count; II++)
                                    {
                                        Merchant = UserEngine.m_MerchantList[II];
                                        if ((Merchant.m_sMapName == sMapName) && (Merchant.m_nCurrX == nX) && (Merchant.m_nCurrY == nY))
                                        {
                                            boNewNpc = false;
                                            Merchant.m_sScript = sScript;
                                            Merchant.m_sCharName = sCharName;
                                            Merchant.m_nFlag = (sbyte)HUtil32.Str_ToInt(sFlag, 0);
                                            Merchant.m_wAppr = (ushort)HUtil32.Str_ToInt(sAppr, 0);
                                            Merchant.m_dwMoveTime = (uint)HUtil32.Str_ToInt(sMoveTime, 0);
                                            if (HUtil32.Str_ToInt(sCastle, 0) != 0)
                                            {
                                                Merchant.m_boCastle = true;
                                            }
                                            else
                                            {
                                                Merchant.m_boCastle = false;
                                            }
                                            if ((HUtil32.Str_ToInt(sCanMove, 0) != 0) && (Merchant.m_dwMoveTime > 0))
                                            {
                                                Merchant.m_boCanMove = true;
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (boNewNpc)
                                {
                                    Merchant = new TMerchant();
                                    Merchant.m_sMapName = sMapName;
                                    Merchant.m_PEnvir = M2Share.g_MapManager.FindMap(Merchant.m_sMapName);
                                    if (Merchant.m_PEnvir != null)
                                    {
                                        Merchant.m_sScript = sScript;
                                        Merchant.m_nCurrX = nX;
                                        Merchant.m_nCurrY = nY;
                                        Merchant.m_sCharName = sCharName;
                                        Merchant.m_nFlag = (sbyte)HUtil32.Str_ToInt(sFlag, 0);
                                        Merchant.m_wAppr = (ushort)HUtil32.Str_ToInt(sAppr, 0);
                                        Merchant.m_dwMoveTime = (uint)HUtil32.Str_ToInt(sMoveTime, 0);
                                        if (HUtil32.Str_ToInt(sCastle, 0) != 0)
                                        {
                                            Merchant.m_boCastle = true;
                                        }
                                        else
                                        {
                                            Merchant.m_boCastle = false;
                                        }
                                        if ((HUtil32.Str_ToInt(sCanMove, 0) != 0) && (Merchant.m_dwMoveTime > 0))
                                        {
                                            Merchant.m_boCanMove = true;
                                        }
                                        UserEngine.m_MerchantList.Add(Merchant);
                                        Merchant.Initialize();
                                    }
                                    else
                                    {
                                        //Merchant.Free;
                                    }
                                }
                            }
                        }
                        // for
                    }
                    finally
                    {

                        //Dispose(LoadList);
                    }
                    if (UserEngine.m_MerchantList.Count > 0)
                    {
                        for (I = UserEngine.m_MerchantList.Count - 1; I >= 0; I--)
                        {
                            Merchant = ((TMerchant)(UserEngine.m_MerchantList[I]));
                            if (Merchant.m_nFlag == -1)
                            {
                                Merchant.m_boGhost = true;
                                Merchant.m_dwGhostTick = HUtil32.GetTickCount();
                                // UserEngine.MerchantList.Delete(I);
                            }
                        }
                    }
                }
                finally
                {
                    //UserEngine.m_MerchantList.UnLock();
                }
        }

        public int LoadUpgradeWeaponRecord(string sNPCName, ArrayList DataList)
        {
            int result;
            int I;
            int FileHandle;
            string sFileName;
            string Str = string.Empty;
            TUpgradeInfo UpgradeInfo;
            TUpgradeInfo UpgradeRecord;
            int nRecordCount;
            result = -1;
            if (sNPCName.IndexOf("/") > 0)
            {
                // 检查文件名是否包含'/',有则替换为'_'
                sNPCName = HUtil32.GetValidStr3(sNPCName, ref Str, new string[] { "/" });
                sNPCName = Str + "_" + sNPCName;
            }
            sFileName = ".\\Envir\\Market_Upg\\" + sNPCName + ".upg";
            if (File.Exists(sFileName))
            {
                //FileHandle = File.Open(sFileName, (FileMode) FileAccess.Read | FileShare.ReadWrite);
                //if (FileHandle > 0)
                //{
                //    FileRead(FileHandle, nRecordCount, sizeof(int));
                //    if (nRecordCount > 0)
                //    {
                //        for (I = 0; I < nRecordCount; I ++ )
                //        {
                //            if (FileRead(FileHandle, UpgradeRecord, sizeof(TUpgradeInfo)) == sizeof(TUpgradeInfo))
                //            {
                //                UpgradeInfo = new TUpgradeInfo();
                //                UpgradeInfo = UpgradeRecord;
                //                UpgradeInfo.dwGetBackTick = 0;
                //                DataList.Add(UpgradeInfo);
                //            }
                //        }
                //    }
                //    FileHandle.Close();
                //    result = 1;
                //}
            }
            return result;
        }

        public int SaveUpgradeWeaponRecord(string sNPCName, ArrayList DataList)
        {
            int result;
            int I;
            int FileHandle;
            string sFileName;
            string Str;
            TUpgradeInfo UpgradeInfo;
            result = -1;
            //if (sNPCName.IndexOf("/") > 0)
            //{
            //    // 检查文件名是否包含'/',有则替换为'_'
            //    sNPCName = HUtil32.GetValidStr3(sNPCName, ref Str, new string[] {"/"});
            //    sNPCName = Str + "_" + sNPCName;
            //}
            //sFileName = ".\\Envir\\Market_Upg\\" + sNPCName + ".upg";
            //if (File.Exists(sFileName))
            //{
            //    FileHandle = File.Open(sFileName, (FileMode) FileAccess.Write | FileShare.ReadWrite);
            //}
            //else
            //{
            //    FileHandle = File.Create(sFileName);
            //}
            //if (FileHandle > 0)
            //{

            //    FileWrite(FileHandle, DataList.Count, sizeof(int));
            //    if (DataList.Count > 0)
            //    {
            //        for (I = 0; I < DataList.Count; I ++ )
            //        {
            //            UpgradeInfo = DataList[I];

            //            FileWrite(FileHandle, UpgradeInfo, sizeof(TUpgradeInfo));
            //        }
            //    }
            //    FileHandle.Close();
            //}
            result = 1;
            return result;
        }

        public int LoadGoodRecord(TMerchant NPC, string sFile)
        {
            int result;
            int I;
            string sFileName;
            //int FileHandle;
            //TUserItem* UserItem;
            //ArrayList List;
            //TGoodFileHeader Header420;
            result = -1;
            sFileName = ".\\Envir\\Market_Saved\\" + sFile + ".sav";
            //if (File.Exists(sFileName))
            //{
            //    FileHandle = File.Open(sFileName, (FileMode) FileAccess.Read | FileShare.ReadWrite);
            //    List = null;
            //    if (FileHandle > 0)
            //    {

            //        if (FileRead(FileHandle, Header420, sizeof(TGoodFileHeader)) == sizeof(TGoodFileHeader))
            //        {
            //            if (Header420.nItemCount > 0)
            //            {
            //                for (I = 0; I < Header420.nItemCount; I ++ )
            //                {
            //                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
            //                    FillChar(UserItem, sizeof(TUserItem), '\0');
            //                    if (FileRead(FileHandle, UserItem, sizeof(TUserItem)) == sizeof(TUserItem))
            //                    {
            //                        // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);//20080820 增加
            //                        if (List == null)
            //                        {
            //                            List = new ArrayList();
            //                            List.Add(UserItem);
            //                        }
            //                        else
            //                        {
            //                            if (((TUserItem)(List[0])).wIndex == UserItem->wIndex)
            //                            {
            //                                List.Add(UserItem);
            //                            }
            //                            else
            //                            {
            //                                NPC.m_GoodsList.Add(List);
            //                                List = new ArrayList();
            //                                List.Add(UserItem);
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        HUtil32.DisPoseAndNil(ref UserItem);
            //                    }
            //                }
            //            // for
            //            }
            //            if (List != null)
            //            {
            //                NPC.m_GoodsList.Add(List);
            //            }
            //            FileHandle.Close();
            //            result = 1;
            //        }
            //    }
            //}
            return result;
        }

        public int LoadGoodPriceRecord(TMerchant NPC, string sFile)
        {
            int result;
            int I;
            string sFileName;
            int FileHandle;
            TItemPrice ItemPrice;
            TGoodFileHeader Header420;
            result = -1;
            sFileName = ".\\Envir\\Market_Prices\\" + sFile + ".prc";
            //if (File.Exists(sFileName))
            //{
            //    FileHandle = File.Open(sFileName, (FileMode) FileAccess.Read | FileShare.ReadWrite);
            //    if (FileHandle > 0)
            //    {
            //        if (FileRead(FileHandle, Header420, sizeof(TGoodFileHeader)) == sizeof(TGoodFileHeader))
            //        {
            //            if (Header420.nItemCount > 0)
            //            {
            //                for (I = 0; I < Header420.nItemCount; I ++ )
            //                {
            //                    ItemPrice = new TItemPrice();
            //                    if (FileRead(FileHandle, ItemPrice, sizeof(TItemPrice)) == sizeof(TItemPrice))
            //                    {
            //                        NPC.m_ItemPriceList.Add(ItemPrice);
            //                    }
            //                    else
            //                    {
            //                        Dispose(ItemPrice);
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //        FileHandle.Close();
            //        result = 1;
            //    }
            //}
            return result;
        }

        public bool LoadBoxsList_IsNum(string str)
        {
            bool result;
            // 判断一个字符串是否为数字
            int i;
            for (i = 1; i <= str.Length; i++)
            {
                if (!(str[i] >= '0' && str[i] <= '9'))
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

        public int LoadBoxsList_IsNum1(string str)
        {
            int result;
            // 判断有几个'('号
            int i;
            result = 0;
            if (str.Length <= 0)
            {
                return result;
            }
            for (i = 0; i <= str.Length - 1; i++)
            {
                if ((new ArrayList(new string[] { "(" }).Contains(str[i])))
                {
                    result++;
                }
            }
            return result;
        }

        // ------------------------------------------------------------------------------
        /// <summary>
        /// 读取宝箱
        /// </summary>
        public unsafe void LoadBoxsList()
        {
            TStringList LoadList;
            TStringList tSaveList;
            int j;
            string sBoxsDir;
            string BoxsFile;
            string SBoxsID = string.Empty;
            string sItemName = string.Empty;
            string nItemNum = string.Empty;
            string nItemType = string.Empty;
            string OpenBox = string.Empty;
            string nGold = string.Empty;
            string nGameGold = string.Empty;
            string nIncGold = string.Empty;
            string nIncGameGold = string.Empty;
            string nEffectiveGold = string.Empty;
            string nEffectiveGameGold = string.Empty;
            string nUses = string.Empty;
            TBoxsInfo* BoxsInfo;
            TStdItem* StdItem;
            string sTemp;
            if (!Directory.Exists(M2Share.g_Config.sBoxsDir))  // 目录不存在,则创建
            {
                Directory.CreateDirectory(M2Share.g_Config.sBoxsDir);
            }
            if (!File.Exists(M2Share.g_Config.sBoxsFile))   // BoxsList.txt文件不存在,则创建文件
            {
                tSaveList = new TStringList();
                tSaveList.Add(";此为宝箱序列号文件");
                tSaveList.Add(";如何设置请查看帮助文档");
                tSaveList.Add(";理论上是可以增加无限个宝箱，不再局限于只能设置五个宝箱的内容");
                tSaveList.SaveToFile(M2Share.g_Config.sBoxsFile);
                tSaveList.Dispose();
            }
            if (File.Exists(M2Share.g_Config.sBoxsFile))
            {
                M2Share.BoxsList.Clear();
                LoadList = new TStringList();
                LoadList.LoadFromFile(M2Share.g_Config.sBoxsFile);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sBoxsDir = LoadList[I].Trim();
                    if ((sBoxsDir != "") && (sBoxsDir[0] != ';'))
                    {
                        if (File.Exists(M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt"))
                        {
                            tSaveList = new TStringList();
                            tSaveList.LoadFromFile(M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt");
                            if (tSaveList.Text == "")
                            {
                                continue;
                            }
                            // 继续 如果文件内容为空则跳至下一文件
                            for (int K = 0; K < tSaveList.Count; K++)
                            {
                                try
                                {
                                    BoxsFile = tSaveList[K].Trim();
                                    if ((BoxsFile != "") && (BoxsFile[0] != ';'))
                                    {
                                        j = LoadBoxsList_IsNum1(BoxsFile);
                                        switch (j)
                                        {
                                            case 0:
                                                HUtil32.ArrestStringEx(BoxsFile, "(", ")", ref nItemNum);// 物品数量
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref sItemName, new string[] { "	", " ", "\t" });
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref nItemType, new string[] { "	", " ", "\t" });
                                                break;
                                            case 1:// 物品类型
                                                HUtil32.ArrestStringEx(BoxsFile, "(", ")", ref nItemNum);// 物品数量
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref sItemName, new string[] { "	", " ", "\t" });
                                                if (LoadBoxsList_IsNum(nItemNum) && (nItemNum != ""))
                                                {
                                                    // 物品名字
                                                    HUtil32.GetValidStr3(sItemName, ref sItemName, new string[] { "(" });
                                                }
                                                else
                                                {
                                                    nItemNum = "";
                                                }
                                                BoxsFile = HUtil32.GetValidStr3(BoxsFile, ref nItemType, new string[] { "	", " ", "\t" });
                                                break;
                                            case 2:// 物品类型
                                                HUtil32.ArrestStringEx(BoxsFile, "(", ")", ref nItemNum);// 物品数量
                                                if (nItemNum != "")
                                                {
                                                    if (!LoadBoxsList_IsNum(nItemNum))
                                                    {
                                                        sTemp = HUtil32.GetValidStr3(BoxsFile, ref sItemName, new string[] { ")" });
                                                        if (sItemName != "")
                                                        {
                                                            sItemName = sItemName + ")";
                                                        }
                                                        HUtil32.ArrestStringEx(sTemp, "(", ")", ref nItemNum);
                                                        nItemType = HUtil32.GetValidStr3(sTemp, ref nItemType, new string[] { "	", " ", "\t" });// 物品类型
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    if ((sItemName == "") && (nItemType == ""))
                                    {
                                        continue;
                                    }
                                    if ((sItemName != "") && (nItemType != ""))
                                    {
                                        StdItem = UserEngine.GetStdItem(sItemName);
                                        if (StdItem != null) // 判断是否是数据库里的物品
                                        {
                                            BoxsInfo = (TBoxsInfo*)Marshal.AllocHGlobal(sizeof(TBoxsInfo));
                                            BoxsInfo->SBoxsID = Convert.ToInt32(SBoxsID);
                                            if (nItemNum != "")
                                            {
                                                BoxsInfo->nItemNum = Convert.ToInt32(nItemNum);
                                            }
                                            else
                                            {
                                                BoxsInfo->nItemNum = 1;
                                            }
                                            BoxsInfo->nItemType = Convert.ToInt32(nItemType);
                                            BoxsInfo->StdItem->MakeIndex = (int)BoxsInfo;
                                            BoxsInfo->nGold = Convert.ToInt32(nGold);
                                            BoxsInfo->nGameGold = Convert.ToUInt32(nGameGold);
                                            BoxsInfo->nIncGold = Convert.ToInt32(nIncGold);
                                            BoxsInfo->nIncGameGold = Convert.ToInt32(nIncGameGold);
                                            BoxsInfo->nEffectiveGold = Convert.ToInt32(nEffectiveGold);
                                            BoxsInfo->nEffectiveGameGold = Convert.ToUInt32(nEffectiveGameGold);
                                            BoxsInfo->nUses = Convert.ToInt32(nUses);
                                            BoxsInfo->StdItem->Dura = (ushort)HUtil32.Round((double)(StdItem->DuraMax / 100) * (20 + HUtil32.Random(80)));// 当前持久
                                            BoxsInfo->StdItem->DuraMax = (ushort)StdItem->DuraMax;// 最大持久
                                            BoxsInfo->StdItem->s = *StdItem;
                                            M2Share.BoxsList.Add((IntPtr)BoxsInfo);
                                        }
                                        else
                                        {
                                            // 如果是经验 声望 金刚石
                                            // '金刚石'
                                            if ((sItemName.Trim() == "经验") || (sItemName.Trim() == "声望") || (sItemName.Trim() == M2Share.g_Config.sGameDiaMond))
                                            {
                                                if (SBoxsID != "")
                                                {
                                                    BoxsInfo = (TBoxsInfo*)Marshal.AllocHGlobal(sizeof(TBoxsInfo));
                                                    BoxsInfo->SBoxsID = Convert.ToInt32(SBoxsID);
                                                    HUtil32.StrToSByteArry(sItemName, BoxsInfo->StdItem->s.Name, 14, ref BoxsInfo->StdItem->s.NameLen);
                                                    BoxsInfo->StdItem->s.StdMode = 0;
                                                    BoxsInfo->StdItem->s.Shape = 0;
                                                    BoxsInfo->StdItem->MakeIndex = HUtil32.ObjectToInt(*BoxsInfo);
                                                    if (nItemNum != "")
                                                    {
                                                        BoxsInfo->nItemNum = Convert.ToInt32(nItemNum);
                                                    }
                                                    else
                                                    {
                                                        BoxsInfo->nItemNum = 1;
                                                    }
                                                    BoxsInfo->nItemType = Convert.ToInt32(nItemType);
                                                    BoxsInfo->nGold = Convert.ToInt32(nGold);
                                                    BoxsInfo->nGameGold = Convert.ToUInt32(nGameGold);
                                                    BoxsInfo->nIncGold = Convert.ToInt32(nIncGold);
                                                    BoxsInfo->nIncGameGold = Convert.ToInt32(nIncGameGold);
                                                    BoxsInfo->nEffectiveGold = Convert.ToInt32(nEffectiveGold);
                                                    BoxsInfo->nEffectiveGameGold = Convert.ToUInt32(nEffectiveGameGold);
                                                    BoxsInfo->nUses = Convert.ToInt32(nUses);
                                                    M2Share.BoxsList.Add((IntPtr)BoxsInfo);
                                                }
                                            }
                                            else
                                            {
                                                MainOutMessage("提示:" + M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt 文件中物品(" + sItemName + ")数据库中不存在...");
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                            tSaveList.Dispose();
                            Dispose(tSaveList);
                        }
                        else
                        {
                            MainOutMessage("宝箱配置文件:" + M2Share.g_Config.sBoxsDir + sBoxsDir + ".txt 文件不存在...");
                        }
                    }
                }
                Dispose(LoadList);
            }
        }

        // ------------------------------------------------------------------------------
        // 读取元宝寄售列表
        public void LoadSellOffItemList()
        {
            //string sFileName;
            //int FileHandle;
            //TDealOffInfo DealOffInfo;
            //TDealOffInfo sDealOffInfo;
            //sFileName = M2Share.g_Config.sEnvirDir + "UserData";
            //if (!Directory.Exists(sFileName))
            //{
            //    Directory.CreateDirectory(sFileName);
            //}
            //// 目录不存在,则创建
            //sFileName = sFileName + "\\UserData.dat";
            //if (File.Exists(sFileName))
            //{
            //    FileHandle = File.Open(sFileName, (FileMode) FileAccess.Read | FileShare.ReadWrite);
            //    if (FileHandle > 0)
            //    {
            //        try {

            //            while (FileRead(FileHandle, sDealOffInfo, sizeof(TDealOffInfo)) == sizeof(TDealOffInfo))
            //            {
            //                // 循环读出人物数据
            //                if ((sDealOffInfo.sDealCharName != "") && (sDealOffInfo.sBuyCharName != "") && (sDealOffInfo.N < 4))
            //                {
            //                    // 判断数据的有效性 20081021
            //                    DealOffInfo = new TDealOffInfo();
            //                    DealOffInfo.sDealCharName = sDealOffInfo.sDealCharName;
            //                    DealOffInfo.sBuyCharName = sDealOffInfo.sBuyCharName;
            //                    DealOffInfo.dSellDateTime = sDealOffInfo.dSellDateTime;
            //                    DealOffInfo.nSellGold = sDealOffInfo.nSellGold;
            //                    DealOffInfo.UseItems = sDealOffInfo.UseItems;
            //                    DealOffInfo.N = sDealOffInfo.N;
            //                    M2Share.sSellOffItemList.Add(DealOffInfo);
            //                }
            //            }
            //        }
            //        catch {
            //        }
            //        FileHandle.Close();
            //    }
            //}
            //else
            //{
            //    FileHandle = File.Create(sFileName);
            //    FileHandle.Close();
            //}
        }

        // 保存元宝寄售列表
        public void SaveSellOffItemList()
        {
            //string sFileName;
            //int FileHandle;
            //TDealOffInfo DealOffInfo;
            //int I;
            //sFileName = M2Share.g_Config.sEnvirDir + "UserData\\UserData.dat";
            //if (File.Exists(sFileName))
            //{
            //    File.Delete(sFileName);
            //}
            //FileHandle = File.Create(sFileName);
            //if (FileHandle > 0)
            //{
            //    FileSeek(FileHandle, 0, 0);
            //    try {
            //        if (M2Share.sSellOffItemList.Count > 0)
            //        {
            //            for (I = 0; I < M2Share.sSellOffItemList.Count; I ++ )
            //            {
            //                DealOffInfo = ((TDealOffInfo)(M2Share.sSellOffItemList[I]));
            //                if (DealOffInfo != null)
            //                {
            //                    FileWrite(FileHandle, DealOffInfo, sizeof(TDealOffInfo));
            //                }
            //            }
            //        }
            //    }
            //    catch {
            //    }
            //    FileHandle.Close();
            //}
        }

        /// <summary>
        /// 读取套装装备数据
        /// </summary>
        public void LoadSuitItemList()
        {
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string ItemCount = string.Empty;
            string Note = string.Empty;
            string Name = string.Empty;
            string MaxHP = string.Empty;
            string MaxMP = string.Empty;
            string DC = string.Empty;
            string MaxDC = string.Empty;
            string MC = string.Empty;
            string MaxMC = string.Empty;
            string SC = string.Empty;
            string MaxSC = string.Empty;
            string AC = string.Empty;
            string MaxAC = string.Empty;
            string MAC = string.Empty;
            string MaxMAC = string.Empty;
            string HitPoint = string.Empty;
            string SpeedPoint = string.Empty;
            string HealthRecover = string.Empty;
            string SpellRecover = string.Empty;
            string RiskRate = string.Empty;
            string btReserved = string.Empty;
            string btReserved1 = string.Empty;
            string btReserved2 = string.Empty;
            string btReserved3 = string.Empty;
            string nEXPRATE = string.Empty;
            string nPowerRate = string.Empty;
            string nMagicRate = string.Empty;
            string nSCRate = string.Empty;
            string nACRate = string.Empty;
            string nMACRate = string.Empty;
            string nAntiMagic = string.Empty;
            string nAntiPoison = string.Empty;
            string nPoisonRecover = string.Empty;
            string sboTeleport = string.Empty;
            string sboParalysis = string.Empty;
            string sboRevival = string.Empty;
            string sboMagicShield = string.Empty;
            string sboUnParalysis = string.Empty;
            TStringList LoadList;
            TSuitItem SuitItem;
            sFileName = M2Share.g_Config.sEnvirDir + "SuitItemList.txt";
            LoadList = new TStringList();
            try
            {
                if (File.Exists(sFileName))
                {
                    M2Share.SuitItemList.Clear();
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (int I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I];
                            if ((sLineText != "") && (sLineText[0] != ';'))
                            {
                                sLineText = HUtil32.GetValidStr3(sLineText, ref ItemCount, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref Note, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref Name, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxHP, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxMP, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref DC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxDC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxMC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref SC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxSC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref AC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxAC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MAC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref MaxMAC, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref HitPoint, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref SpeedPoint, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref HealthRecover, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref SpellRecover, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref RiskRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved1, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved2, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref btReserved3, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nEXPRATE, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nPowerRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nMagicRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nSCRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nACRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nMACRate, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nAntiMagic, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nAntiPoison, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref nPoisonRecover, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboTeleport, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboParalysis, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboRevival, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboMagicShield, new string[] { " " });
                                sLineText = HUtil32.GetValidStr3(sLineText, ref sboUnParalysis, new string[] { " " });
                                if ((ItemCount == "") || (Name == "")) { continue; }
                                SuitItem = new TSuitItem();
                                SuitItem.ItemCount = Convert.ToByte(ItemCount);
                                SuitItem.Note = Note;
                                SuitItem.Name = Name;
                                SuitItem.MaxHP = HUtil32._MIN(100, HUtil32.Str_ToInt(MaxHP, 0));
                                SuitItem.MaxMP = HUtil32._MIN(100, HUtil32.Str_ToInt(MaxMP, 0));
                                SuitItem.DC = (ushort)HUtil32.Str_ToInt(DC, 0);// 攻击力
                                SuitItem.MaxDC = (ushort)HUtil32.Str_ToInt(MaxDC, 0);
                                SuitItem.MC = (ushort)HUtil32.Str_ToInt(MC, 0);// 魔法
                                SuitItem.MaxMC = (ushort)HUtil32.Str_ToInt(MaxMC, 0);
                                SuitItem.SC = (ushort)HUtil32.Str_ToInt(SC, 0);// 道术
                                SuitItem.MaxSC = (ushort)HUtil32.Str_ToInt(MaxSC, 0);
                                SuitItem.AC = HUtil32.Str_ToInt(AC, 0);// 防御
                                SuitItem.MaxAC = HUtil32.Str_ToInt(MaxAC, 0);
                                SuitItem.MAC = (ushort)HUtil32.Str_ToInt(MAC, 0);// 魔防
                                SuitItem.MaxMAC = (ushort)HUtil32.Str_ToInt(MaxMAC, 0);
                                SuitItem.HitPoint = (byte)HUtil32.Str_ToInt(HitPoint, 0);// 精确度
                                SuitItem.SpeedPoint = (byte)HUtil32.Str_ToInt(SpeedPoint, 0);// 敏捷度
                                SuitItem.HealthRecover = (sbyte)HUtil32.Str_ToInt(HealthRecover, 0);// 体力恢复
                                SuitItem.SpellRecover = (sbyte)HUtil32.Str_ToInt(SpellRecover, 0);// 魔法恢复
                                SuitItem.RiskRate = HUtil32.Str_ToInt(RiskRate, 0);// 爆率机率
                                SuitItem.btReserved = (byte)HUtil32.Str_ToInt(btReserved, 0);// 吸血(虹吸)
                                SuitItem.btReserved1 = (byte)HUtil32.Str_ToInt(btReserved1, 0);// 保留
                                SuitItem.btReserved2 = (byte)HUtil32.Str_ToInt(btReserved2, 0);// 保留
                                SuitItem.btReserved3 = (byte)HUtil32.Str_ToInt(btReserved3, 0);// 保留
                                SuitItem.nEXPRATE = HUtil32.Str_ToInt(nEXPRATE, 1);// 经验倍数
                                SuitItem.nPowerRate = (byte)HUtil32.Str_ToInt(nPowerRate, 1);// 攻击倍数
                                SuitItem.nMagicRate = (byte)HUtil32.Str_ToInt(nMagicRate, 1);// 魔法倍数
                                SuitItem.nSCRate = (byte)HUtil32.Str_ToInt(nSCRate, 1);// 道术倍数
                                SuitItem.nACRate = (byte)HUtil32.Str_ToInt(nACRate, 1);// 防御倍数
                                SuitItem.nMACRate = (byte)HUtil32.Str_ToInt(nMACRate, 1);// 魔御倍数
                                SuitItem.nAntiMagic = (sbyte)HUtil32.Str_ToInt(nAntiMagic, 0);// 魔法躲避
                                SuitItem.nAntiPoison = (byte)HUtil32.Str_ToInt(nAntiPoison, 0);// 毒物躲避
                                SuitItem.nPoisonRecover = (sbyte)HUtil32.Str_ToInt(nPoisonRecover, 0);// 中毒恢复
                                SuitItem.boTeleport = sboTeleport != "0";// 传送 
                                SuitItem.boParalysis = sboParalysis != "0";// 麻痹
                                SuitItem.boRevival = sboRevival != "0";// 复活
                                SuitItem.boMagicShield = sboMagicShield != "0";// 护身
                                SuitItem.boUnParalysis = sboUnParalysis != "0";// 防麻痹
                                M2Share.SuitItemList.Add(SuitItem);
                            }
                        }
                    }
                }
                else
                {
                    LoadList.SaveToFile(sFileName);
                }
            }
            finally
            {
                Dispose(LoadList);
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>
        /// 读取淬炼配置数据
        /// </summary>
        public void LoadRefineItem()
        {
            int I;
            string n1 = string.Empty;
            string n11 = string.Empty;
            string n2 = string.Empty;
            string n22 = string.Empty;
            string n3 = string.Empty;
            string n33 = string.Empty;
            string n4 = string.Empty;
            string n44 = string.Empty;
            string n5 = string.Empty;
            string n55 = string.Empty;
            string n6 = string.Empty;
            string n66 = string.Empty;
            string n7 = string.Empty;
            string n77 = string.Empty;
            string n8 = string.Empty;
            string n88 = string.Empty;
            string n9 = string.Empty;
            string n99 = string.Empty;
            string nA = string.Empty;
            string nAA = string.Empty;
            string nB = string.Empty;
            string nBB = string.Empty;
            string nC = string.Empty;
            string nCC = string.Empty;
            string nD = string.Empty;
            string nDD = string.Empty;
            string nE = string.Empty;
            string nEE = string.Empty;
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s25 = string.Empty;
            string s26 = string.Empty;
            string s27 = string.Empty;
            string s28 = string.Empty;
            TStringList LoadList;
            string sFileName = string.Empty;
            IList<TRefineItemInfo> List28;
            TRefineItemInfo TRefineItemInfo;
            sFileName = M2Share.g_Config.sEnvirDir + "RefineItem.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                M2Share.g_RefineItemList.Clear();
                LoadList.LoadFromFile(sFileName);
                List28 = null;
                s24 = "";
                for (I = 0; I < LoadList.Count; I++)
                {
                    s18 = LoadList[I].Trim();
                    if ((s18 != "") && (s18[0] != ';'))
                    {
                        if (s18[0] == '[')
                        {
                            if (List28 != null)
                            {
                                //M2Share.g_RefineItemList.Add(s24, List28);
                            }
                            List28 = new List<TRefineItemInfo>();
                            HUtil32.ArrestStringEx(s18, "[", "]", ref s24);// S24-[]里的内容
                        }
                        else
                        {
                            if (List28 != null)
                            {
                                s18 = HUtil32.GetValidStr3(s18, ref s20, new string[] { " ", "\t" });// S20-物品名称 N14-数量
                                s18 = HUtil32.GetValidStr3(s18, ref s25, new string[] { " ", "\t" });// 淬炼成功率
                                s18 = HUtil32.GetValidStr3(s18, ref s26, new string[] { " ", "\t" });// 失败还原率
                                s18 = HUtil32.GetValidStr3(s18, ref s27, new string[] { " ", "\t" });// 火云石是否消失 0-减少1持久,1-消失
                                s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });// 极品机率
                                s18 = HUtil32.GetValidStr3(s18, ref n1, new string[] { "-", ",", "\t" });// 各属性值及难度
                                s18 = HUtil32.GetValidStr3(s18, ref n11, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n2, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n22, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n3, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n33, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n4, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n44, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n5, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n55, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n6, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n66, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n7, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n77, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n8, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n88, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n9, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref n99, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nA, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nAA, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nB, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nBB, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nC, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nCC, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nD, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nDD, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nE, new string[] { "-", ",", "\t" });
                                s18 = HUtil32.GetValidStr3(s18, ref nEE, new string[] { "-", ",", "\t" });
                                if (s20 != "")
                                {
                                    TRefineItemInfo = new TRefineItemInfo();
                                    TRefineItemInfo.sItemName = s20;
                                    TRefineItemInfo.nRefineRate = HUtil32.Str_ToByte(s25.Trim(), 0);
                                    TRefineItemInfo.nReductionRate = HUtil32.Str_ToByte(s26.Trim(), 0);
                                    TRefineItemInfo.boDisappear = HUtil32.Str_ToInt(s27.Trim(), 0) == 0;// 0-减持久 1-消失
                                    TRefineItemInfo.nNeedRate = HUtil32.Str_ToByte(s28.Trim(), 0);
                                    unsafe
                                    {
                                        TAttribute* nAttribute = (TAttribute*)TRefineItemInfo.TAttributeBuff;
                                        nAttribute[0].nPoints = HUtil32.Str_ToByte(n1.Trim(), 0);
                                        nAttribute[0].nDifficult = HUtil32.Str_ToByte(n11.Trim(), 0);
                                        nAttribute[0].nPoints = HUtil32.Str_ToByte(n2.Trim(), 0);
                                        nAttribute[0].nDifficult = HUtil32.Str_ToByte(n22.Trim(), 0);
                                        nAttribute[2].nPoints = HUtil32.Str_ToByte(n3.Trim(), 0);
                                        nAttribute[2].nDifficult = HUtil32.Str_ToByte(n33.Trim(), 0);
                                        nAttribute[3].nPoints = HUtil32.Str_ToByte(n4.Trim(), 0);
                                        nAttribute[3].nDifficult = HUtil32.Str_ToByte(n44.Trim(), 0);
                                        nAttribute[4].nPoints = HUtil32.Str_ToByte(n5.Trim(), 0);
                                        nAttribute[4].nDifficult = HUtil32.Str_ToByte(n55.Trim(), 0);
                                        nAttribute[5].nPoints = HUtil32.Str_ToByte(n6.Trim(), 0);
                                        nAttribute[5].nDifficult = HUtil32.Str_ToByte(n66.Trim(), 0);
                                        nAttribute[6].nPoints = HUtil32.Str_ToByte(n7.Trim(), 0);
                                        nAttribute[6].nDifficult = HUtil32.Str_ToByte(n77.Trim(), 0);
                                        nAttribute[7].nPoints = HUtil32.Str_ToByte(n8.Trim(), 0);
                                        nAttribute[7].nDifficult = HUtil32.Str_ToByte(n88.Trim(), 0);
                                        nAttribute[8].nPoints = HUtil32.Str_ToByte(n9.Trim(), 0);
                                        nAttribute[8].nDifficult = HUtil32.Str_ToByte(n99.Trim(), 0);
                                        nAttribute[9].nPoints = HUtil32.Str_ToByte(nA.Trim(), 0);
                                        nAttribute[9].nDifficult = HUtil32.Str_ToByte(nAA.Trim(), 0);
                                        nAttribute[10].nPoints = HUtil32.Str_ToByte(nB.Trim(), 0);
                                        nAttribute[10].nDifficult = HUtil32.Str_ToByte(nBB.Trim(), 0);
                                        nAttribute[11].nPoints = HUtil32.Str_ToByte(nC.Trim(), 0);
                                        nAttribute[11].nDifficult = HUtil32.Str_ToByte(nCC.Trim(), 0);
                                        nAttribute[12].nPoints = HUtil32.Str_ToByte(nD.Trim(), 0);
                                        nAttribute[12].nDifficult = HUtil32.Str_ToByte(nDD.Trim(), 0);
                                        nAttribute[13].nPoints = HUtil32.Str_ToByte(nE.Trim(), 0);
                                        nAttribute[13].nDifficult = HUtil32.Str_ToByte(nEE.Trim(), 0);
                                    }
                                    List28.Add(TRefineItemInfo);
                                }
                            }
                        }
                    }
                }
                if (List28 != null)
                {
                    //M2Share.g_RefineItemList.Add(s24, List28);
                }
            }
            else
            {
                LoadList.Add(";此为淬炼配置文件");
                LoadList.Add(";如何设置请查看帮助文档");
                LoadList.Add(";淬炼后的物品 淬炼成功几率 失败还原几率 火云石是否消失 淬炼极品属性几率 淬炼极品属性设置");
                LoadList.Add(";[火云石+黑铁头盔+雷霆战戒]");
                LoadList.Add(";星王魔戒 30 30 0 1 0-5,0-5,0-5,4-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,0-5,");
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
        }

        /// <summary>
        /// 创建守护兽并写入列表
        /// </summary>
        public void LoadMonFireDragonGuard()
        {
            string s18 = string.Empty;
            string s20 = string.Empty;
            string s24 = string.Empty;
            string s28 = string.Empty;
            string s2C = string.Empty;
            string s30 = string.Empty;
            string s34 = string.Empty;
            string s38 = string.Empty;
            TStringList LoadList;
            TBaseObject Monster;
            string sFileName = M2Share.g_Config.sEnvirDir + "FireDragonGuard.txt";
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                try
                {
                    LoadList.Add(";名称        地图    x    y  dir(0-1)  攻击坐标x  攻击坐标Y(可以为多个以|分隔) ");
                    LoadList.Add("火龙守护兽  D2083    51,67  1  77,50|74,50|83,50|80,53|86,53|74,41|71,41|71,44|71,47");
                    LoadList.Add("火龙守护兽  D2083    48,70  1  81,44|81,47|78,44|75,44|84,47|78,41|75,41|81,50|84,50");
                    LoadList.Add("火龙守护兽  D2083    45,73  1  81,44|84,47|78,41|85,50|75,41|76,51|79,54|73,48");
                    LoadList.Add("火龙守护兽  D2083    61,78  0  79,48|79,51|76,48|78,53|75,50|76,45|82,51|81,44|84,47|78,41");
                    LoadList.Add("火龙守护兽  D2083    58,81  0  79,48|82,51|85,54|76,45|71,40|82,48|79,45|76,42|85,51|73,42");
                    LoadList.Add("火龙守护兽  D2083    55,84  0  80,48|77,48|80,45|77,51|74,51|74,54|71,54|71,57");
                    LoadList.SaveToFile(sFileName);
                }
                finally
                {
                    Dispose(LoadList);
                }
            }
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                try
                {
                    LoadList.LoadFromFile(sFileName);
                    for (int I = 0; I < LoadList.Count; I++)
                    {
                        s18 = LoadList[I].Trim();
                        if ((s18 != "") && (s18[0] != ';'))
                        {
                            s18 = HUtil32.GetValidStrCap(s18, ref s20, new string[] { " ", "\t" });// 名字
                            s18 = HUtil32.GetValidStr3(s18, ref s28, new string[] { " ", "\t" });// 地图
                            s18 = HUtil32.GetValidStr3(s18, ref s24, new string[] { " ", "\t" });// 坐标
                            s30 = HUtil32.GetValidStr3(s24, ref s2C, new string[] { ",", "\t" });// X,Y
                            s18 = HUtil32.GetValidStr3(s18, ref s34, new string[] { " ", "\t" });// 方向
                            s18 = HUtil32.GetValidStr3(s18, ref s38, new string[] { " ", "\t" });// 攻击坐标
                            if ((s20 != "") && (s28 != ""))
                            {
                                Monster = UserEngine.RegenMonsterByName(s28, HUtil32.Str_ToInt(s2C, 0), HUtil32.Str_ToInt(s30, 0), s20);
                                if (Monster != null)
                                {
                                    if (Monster.m_btRaceServer == 129) // 守护兽才加入列表
                                    {
                                        Monster.m_btDirection = (byte)HUtil32.Str_ToInt(s34, 0);
                                        ((TFireDragonGuard)(Monster)).s_AttickXY = s38;
                                        UserEngine.m_MonObjectList.Add(Monster);
                                    }
                                    else
                                    {
                                        Dispose(Monster);
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Dispose(LoadList);
                }
            }
        }

        public void Dispose(object obj)
        {
            if (obj != null)
            {
                GC.KeepAlive(obj);
                GC.ReRegisterForFinalize(obj);
            }
        }
    }
}