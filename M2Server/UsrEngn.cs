using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SDK;
using GameOfMir.Lib;
using Common;
using System.Threading;

namespace M2Server
{

    public class TMonGenInfo
    {
        // 刷怪类
        public string sMapName;
        // 地图名
        public int nRace;
        public int nRange;
        // 范围
        public int nMissionGenRate;
        // 集中座标刷新机率 1 -100
        public uint dwStartTick;
        // 刷怪间隔
        public int nX;
        // X坐标
        public int nY;
        // Y坐标
        public string sMonName;
        // 怪物名
        public int nAreaX;
        public int nAreaY;
        public int nCount;
        // 怪物数量
        public uint dwZenTime;
        // 刷怪时间
        public uint dwStartTime;
        // 启动时间
        public bool boIsNGMon;
        // 内功怪,打死可以增加内力值 20081001
        public byte nNameColor;
        // 自定义名字的颜色 20080810
        public int nChangeColorType;
        // 2007-02- 01 增加  0自动变色 >0改变颜色 -1不改变
        public IList<object> CertList;
        public TEnvirnoment Envir;
        public int nCurrMonGen;
    }

    public class TMapMonGenCount
    {
        public string sMapName;
        // 地图名称
        public int nMonGenCount;
        // 刷怪数量
        public uint dwNotHumTimeTick;
        // 没玩家的间隔
        public int nClearCount;
        // 清除数量
        public bool boNotHum;
        // 是否有玩家
        public uint dwMakeMonGenTimeTick;
        // 刷怪的间隔
        public int nMonGenRate;
        // 刷怪倍数  10
        public uint dwRegenMonstersTime;
    } // end TMapMonGenCount

    public class TUserEngine:HUtil32
    {
        public static uint g_dwEngineTick = 0;
        public static uint g_dwEngineRunTime = 0;
        public static bool m_boHumProcess = false;
        // 20080717 检查过程是否重入
        public static bool m_boProcessEffects = false;
        // //20080726 检查雷炎效果过程是否重入
        public static bool m_boPrcocessData = false;

        public int MonsterCount
        {
          get {
            return nMonsterCount;
          }
        }
        // 怪物数量
        public int OnlinePlayObject
        {
          get {
            return GetOnlineHumCount();
          }
        }
        // 在线人数
        public int PlayObjectCount
        {
          get {
            return GetUserCount();
          }
        }
        // 总人数
        public int AutoAddExpPlayCount
        {
          get {
            return GetAutoAddExpPlayCount();
          }
        }
        // 自动挂机人数
        public int LoadPlayCount
        {
          get {
            return GetLoadPlayCount();
          }
        }

        public ReaderWriterLock m_LoadPlaySection = null;
        public IList<TUserOpenInfo> m_LoadPlayList = null;
        // 从DB读取人物数据
        public IList<TPlayObject> m_PlayObjectList = null;
        // 在线角色列表
        public ArrayList m_PlayObjectFreeList = null;
        // 0x10
        public ArrayList m_MonObjectList = null;
        // 火龙殿中的守护兽 20090111
        public IList<TGoldChangeInfo> m_ChangeHumanDBGoldList = null;
        // 0x14
        public uint dwShowOnlineTick = 0;
        // 显示在线人数间隔
        public uint dwSendOnlineHumTime = 0;
        // 发送在线人数间隔
        public uint dwProcessMapDoorTick = 0;
        // 0x20
        public uint dwProcessMissionsTime = 0;
        // 0x24
        public uint dwRegenMonstersTick = 0;
        // 0x28
        public uint m_dwProcessLoadPlayTick = 0;
        // 0x30
        public int m_nCurrMonGen = 0;
        // 刷怪索引
        public int m_nMonGenListPosition = 0;
        // 0x3C
        public int m_nMonGenCertListPosition = 0;
        // 0x40
        public int m_nProcHumIDx = 0;
        // 0x44 处理人物开始索引（每次处理人物数限制）
        // nProcessHumanLoopTime: Integer; //20080815 注释
        public int nMerchantPosition = 0;
        // 0x4C
        public int nNpcPosition = 0;
        // 物品列表(即数据库中的数据)
        public IList<TStdItem> StdItemList = null;
        // 怪物列表
        public List<TMonInfo> MonsterList = null;
         // 怪物列表(MonGen.txt文件里的设置)
        public IList<TMonGenInfo> m_MonGenList = null;
        // 魔法列表
        public IList<TMagic> m_MagicList = null;
        public IList<TMapMonGenCount> m_MapMonGenCountList = null;
         // 管理员列表
        public IList<TAdminInfo> m_AdminList = null;
        //NPC列表(Merchant.txt)
        public IList<TMerchant> m_MerchantList = null;
        public IList<TNormNpc> QuestNPCList = null;
        // 0x6C
        public IList<TSwitchDataInfo> m_ChangeServerList = null;
        public IList<TMagicEvent> m_MagicEventList = null;
        public int nMonsterCount = 0;
        // 怪物总数
        public int nMonsterProcessPostion = 0;
        // 0x80处理怪物总数位置，用于计算怪物总数
        public int nMonsterProcessCount = 0;
        // 0x88处理怪物数，用于统计处理怪物个数
        public bool boItemEvent = false;
        public int dwProcessMerchantTimeMin = 0;
        public int dwProcessMerchantTimeMax = 0;
        public uint dwProcessNpcTimeMin = 0;
        public uint dwProcessNpcTimeMax = 0;
        public ArrayList m_NewHumanList = null;
        public ArrayList m_ListOfGateIdx = null;
        public ArrayList m_ListOfSocket = null;
        public IList<TMagic> OldMagicList = null;
        public ArrayList EffectList = null;
        // 地图效果列表
        public ArrayList m_TargetList = null;
        // 雷炎地图(中魔法的对像) 20080726
        public int m_nLimitUserCount = 0;
        // 限制用户数
        public int m_nLimitNumber = 0;
        // 限制使用天数或次数
        public bool m_boStartLoadMagic = false;
        // 开始读取魔法
        public uint m_dwSearchTick = 0;
        public uint m_dwGetTodyDayDateTick = 0;
        public DateTime m_TodayDate;
        // 今天日期
        public TStringList m_PlayObjectLevelList = null;
        // 人物等级排行
        public TStringList m_WarrorObjectLevelList = null;
        // 战士等级排行
        public TStringList m_WizardObjectLevelList = null;
        // 法师等级排行
        public TStringList m_TaoistObjectLevelList = null;
        // 道士等级排行
        public TStringList m_PlayObjectMasterList = null;
        // 徒弟数排行
        public TStringList m_HeroObjectLevelList = null;
        // 英雄等级排行
        public TStringList m_WarrorHeroObjectLevelList = null;
        // 英雄战士等级排行
        public TStringList m_WizardHeroObjectLevelList = null;
        // 英雄法师等级排行
        public TStringList m_TaoistHeroObjectLevelList = null;
        // 英雄道士等级排行
        public uint dwGetOrderTick = 0;
        // 取人物等级排行的间隔
        public int m_nCurrX_136 = 0;
        // 起始座标X 20080124
        public int m_nCurrY_136 = 0;
        // 起始座标Y 20080124
        public int m_NewCurrX_136 = 0;
        // 终止座标X 20080124
        public int m_NewCurrY_136 = 0;
        // 终止座标Y 20080124
        // m_sMapName_136: string[MAPNAMELEN]; //地图名称 20080124  20090204
        public bool bo_ReadPlayLeveList = false;
        // {$R+}//20081204 检查数组越界
 
        public TUserEngine()
        {
            m_LoadPlaySection = new ReaderWriterLock();
            m_LoadPlayList = new List<TUserOpenInfo>();
            m_PlayObjectList = new List<TPlayObject>();
            m_PlayObjectFreeList = new ArrayList();
            m_MonObjectList = new ArrayList();
            // 火龙殿中的守护兽 20090111
            m_ChangeHumanDBGoldList = new List<TGoldChangeInfo>();
            dwShowOnlineTick = GetTickCount();
            dwSendOnlineHumTime = GetTickCount();
            dwProcessMapDoorTick = GetTickCount();
            dwProcessMissionsTime = GetTickCount();
            dwRegenMonstersTick = GetTickCount();
            m_dwProcessLoadPlayTick = GetTickCount();
            m_nCurrMonGen = 0;
            m_nMonGenListPosition = 0;
            m_nMonGenCertListPosition = 0;
            m_nProcHumIDx = 0;
            nMerchantPosition = 0;
            nNpcPosition = 0;
            m_nLimitNumber = 1000000;
            // 20080630(注册)
            m_nLimitUserCount = 1000000;
            // 20080630(注册)
            StdItemList = new List<TStdItem>();
            // List_54
            MonsterList = new List<TMonInfo>();
            m_MonGenList = new List<TMonGenInfo>();
            m_MagicList = new List<TMagic>();
            m_AdminList = new List<TAdminInfo>();
            m_MerchantList = new List<TMerchant>();
            QuestNPCList = new List<TNormNpc>();
            m_ChangeServerList = new List<TSwitchDataInfo>();
            m_MagicEventList = new List<TMagicEvent>();
            m_MapMonGenCountList = new List<TMapMonGenCount>();
            boItemEvent = false;
            dwProcessMerchantTimeMin = 0;
            dwProcessMerchantTimeMax = 0;
            dwProcessNpcTimeMin = 0;
            dwProcessNpcTimeMax = 0;
            m_NewHumanList = new ArrayList();
            m_ListOfGateIdx = new ArrayList();
            m_ListOfSocket = new ArrayList();
            OldMagicList = new List<TMagic>();
            EffectList = new ArrayList();
            // 20080327  //20080408
            m_TargetList = new ArrayList();
            // 雷炎地图(中魔法的对像) 20080726
            m_boStartLoadMagic = false;
            m_dwSearchTick = GetTickCount();
            m_dwGetTodyDayDateTick = GetTickCount();
            m_TodayDate = new DateTime();
            m_PlayObjectLevelList = new TStringList();
            // 人物排行 等级
            m_WarrorObjectLevelList = new TStringList();
            // 战士等级排行
            m_WizardObjectLevelList = new TStringList();
            // 法师等级排行
            m_TaoistObjectLevelList = new TStringList();
            // 道士等级排行
            m_PlayObjectMasterList = new TStringList();
            // 徒弟数排行
            m_HeroObjectLevelList = new TStringList();
            // 英雄等级排行
            m_WarrorHeroObjectLevelList = new TStringList();
            // 英雄战士等级排行
            m_WizardHeroObjectLevelList = new TStringList();
            // 英雄法师等级排行
            m_TaoistHeroObjectLevelList = new TStringList();
            // 英雄道士等级排行
            // dwGetOrderTick := GetTickCount(); //20080220 注释
            bo_ReadPlayLeveList = false;
            // 是否正在读取排行文件 20080829
        }
        
        ~TUserEngine()
        {
            int I;
            int II;
            TMonInfo MonInfo;
            TMonGenInfo MonGenInfo;
            TMagicEvent MagicEvent;
            ArrayList TmpList;
            if (m_LoadPlayList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_LoadPlayList.Count; I ++ )
                {
                    if (((TUserOpenInfo)(m_LoadPlayList[I])) != null)
                    {
                        Dispose(((TUserOpenInfo)(m_LoadPlayList[I])));
                    }
                }
            }
            

            if (m_PlayObjectList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                   // ((TPlayObject)(m_PlayObjectList.Values[I])).Free;
                }
            }
           
            if (m_PlayObjectFreeList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_PlayObjectFreeList.Count; I ++ )
                {
                  // ((TPlayObject)(m_PlayObjectFreeList[I])).Free;
                }
            }

            if (m_MonObjectList.Count > 0)
            {
                // 火龙殿中的守护兽 20090111
                for (I = 0; I < m_MonObjectList.Count; I ++ )
                {
                   // ((TBaseObject)(m_MonObjectList[I])).Free;
                }
            }

            if (m_ChangeHumanDBGoldList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_ChangeHumanDBGoldList.Count; I ++ )
                {
                    if (((TGoldChangeInfo)(m_ChangeHumanDBGoldList[I])) != null)
                    {
                        Dispose(((TGoldChangeInfo)(m_ChangeHumanDBGoldList[I])));
                    }
                }
            }

            if (StdItemList.Count > 0)
            {
                // 20080629
                for (I = 0; I < StdItemList.Count; I ++ )
                {
                    if (((TStdItem)(StdItemList[I])) != null)
                    {
                        
                        Dispose(((TStdItem)(StdItemList[I])));
                    }
                }
            }

            if (MonsterList.Count > 0)
            {
                // 20080629
                for (I = 0; I < MonsterList.Count; I ++ )
                {
                    MonInfo = MonsterList[I];
                    if (MonInfo.ItemList != null)
                    {
                        if (MonInfo.ItemList.Count > 0)
                        {
                            for (II = 0; II < MonInfo.ItemList.Count; II ++ )
                            {
                                if (((TMonItem)(MonInfo.ItemList[II])) != null)
                                {
                                    Dispose(((TMonItem)(MonInfo.ItemList[II])));
                                }
                            }
                        }
                    }
                    Dispose(MonInfo);
                }
            }

            if (m_MagicList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_MagicList.Count; I ++ )
                {
                    if (((TMagic)(m_MagicList[I])) != null)
                    {
                        Dispose(((TMagic)(m_MagicList[I])));
                    }
                }
            }
            if (m_AdminList != null)
            {
                if (m_AdminList.Count > 0)
                {
                    // 20080814
                    for (I = 0; I < m_AdminList.Count; I++)
                    {
                        //if (((TAdminInfo)(m_AdminList[I])) != null)
                        //{
                        //    Dispose(((TAdminInfo)(m_AdminList[I])));
                        //}
                    }
                }
            }
            if (m_MerchantList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_MerchantList.Count; I ++ )
                {
                    //((TMerchant)(m_MerchantList[I])).Free;
                }
            }
            if (QuestNPCList.Count > 0)
            {
                // 20080629
                for (I = 0; I < QuestNPCList.Count; I ++ )
                {
                    //((TNormNpc)(QuestNPCList[I])).Free;
                }
            }
            if (m_ChangeServerList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_ChangeServerList.Count; I ++ )
                {
                    if (((TSwitchDataInfo)(m_ChangeServerList[I])) != null)
                    {
                        //Dispose(((TSwitchDataInfo)(m_ChangeServerList[I])));
                    }
                }
            }
            if (m_MagicEventList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_MagicEventList.Count; I ++ )
                {
                    MagicEvent = (M2Server.TMagicEvent)m_MagicEventList[I];
                    
                    if (MagicEvent.BaseObjectList != null)
                    {
                    }
                    
                    Dispose(MagicEvent);
                }
            }
           
            if (OldMagicList.Count > 0)
            {
                // 20080629
                for (I = 0; I < OldMagicList.Count; I ++ )
                {
                    //TmpList = ((OldMagicList[I]) as ArrayList);
                    //if (TmpList.Count > 0)
                    //{
                        //for (II = 0; II < TmpList.Count; II ++ )
                        //{
                        //    if (((TMagic)(TmpList[II])) != null)
                        //    {
                        //        Dispose(((TMagic)(TmpList[II])));
                        //    }
                        //}
                    //}
                }
            }
            
            if (m_MapMonGenCountList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_MapMonGenCountList.Count; I ++ )
                {
                    if (((m_MapMonGenCountList[I]) as TMapMonGenCount) != null)
                    {
                        Dispose(((m_MapMonGenCountList[I]) as TMapMonGenCount));
                    }
                }
            }
            if (EffectList.Count > 0)
            {
                // 20080629
                for (I = EffectList.Count - 1; I >= 0; I-- )
                {
                    //((TEnvirnoment)(EffectList[I])).Free;
                    //EffectList.RemoveAt(I);
                }
            }
            // 雷电 岩浆地图 //20080408
            // 雷炎地图(中魔法的对像) 20080726
            
            if (m_PlayObjectLevelList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_PlayObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_PlayObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_PlayObjectLevelList[I])));
                    //}
                }
            }
            // 人物排行 等级
            if (m_WarrorObjectLevelList.Count > 0)
            {
                // 20080814
                for (I = 0; I < m_WarrorObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_WarrorObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WarrorObjectLevelList[I])));
                    //}
                }
            }
            // 战士等级排行
            
            if (m_WizardObjectLevelList.Count > 0)
            {
                // 20080814
                for (I = 0; I < m_WizardObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_WizardObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WizardObjectLevelList[I])));
                    //}
                }
            }
            // 法师等级排行
            
            if (m_TaoistObjectLevelList.Count > 0)
            {
                // 20080814
                for (I = 0; I < m_TaoistObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_TaoistObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_TaoistObjectLevelList[I])));
                    //}
                }
            }
            // 道士等级排行
            
            if (m_PlayObjectMasterList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_PlayObjectMasterList.Count; I ++ )
                {
                    //if (((string[])(m_PlayObjectMasterList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_PlayObjectMasterList[I])));
                    //}
                }
            }
            // 徒弟数排行
            
            if (m_HeroObjectLevelList.Count > 0)
            {
                // 20080629
                for (I = 0; I < m_HeroObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_HeroObjectLevelList[I])) != null)
                    //{
                    //    Dispose(((string[])(m_HeroObjectLevelList[I])));
                    //}
                }
            }
            // 英雄等级排行
            if (m_WarrorHeroObjectLevelList.Count > 0)
            {
                // 20080814
                for (I = 0; I < m_WarrorHeroObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_WarrorHeroObjectLevelList.Objects[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WarrorHeroObjectLevelList.Objects[I])));
                    //}
                }
            }

            // 英雄战士等级排行
            if (m_WizardHeroObjectLevelList.Count > 0)
            {
                // 20080814
                for (I = 0; I < m_WizardHeroObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_WizardHeroObjectLevelList.Objects[I])) != null)
                    //{
                    //    Dispose(((string[])(m_WizardHeroObjectLevelList.Objects[I])));
                    //}
                }
            }
            // 英雄法师等级排行
            if (m_TaoistHeroObjectLevelList.Count > 0)
            {
                // 20080814
                for (I = 0; I < m_TaoistHeroObjectLevelList.Count; I ++ )
                {
                    //if (((string[])(m_TaoistHeroObjectLevelList.Objects[I])) != null)
                    //{
                    //    Dispose(((string[])(m_TaoistHeroObjectLevelList.Objects[I])));
                    //}
                }
            }
            // 英雄道士等级排行
            //DeleteCriticalSection(m_LoadPlaySection);
        }

        public bool GetPlayObjectLevelList_IsFileInUse(string fName)
        {
            bool result;
            result = false;
            return result;
        }

        // ------------------------------------------------------------------------------
        // 20080220 读取排行榜文件
        private void GetPlayObjectLevelList()
        {
            //string sHumDBFile;
            //string sWarrHum;
            //string sWizardHum;
            //string sTaosHum;
            //string sMaster;
            //string sAllHero;
            //string sWarrHero;
            //string sWizardHero;
            //string sTaosHero;
            //TStringList LoadList;
            //int I;
            //string sLineText;
            //string sData;
            //string s_Master;
            //string CharName;
            //string HeroName;
            //byte nCode;
            //nCode = 0;
            //bo_ReadPlayLeveList = true;
            //try {
            //    EnterCriticalSection(M2Share.HumanSortCriticalSection);
            //    // 20080926
            //    LoadList = new TStringList();
            //    try {
            //        EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            //        try {
            //            nCode = 1;
            //            sHumDBFile = M2Share.g_Config.sSortDir + "AllHum.DB";
            //            sWarrHum = M2Share.g_Config.sSortDir + "WarrHum.DB";
            //            sWizardHum = M2Share.g_Config.sSortDir + "WizardHum.DB";
            //            sTaosHum = M2Share.g_Config.sSortDir + "TaosHum.DB";
            //            sMaster = M2Share.g_Config.sSortDir + "Master.DB";
            //            sAllHero = M2Share.g_Config.sSortDir + "AllHero.DB";
            //            sWarrHero = M2Share.g_Config.sSortDir + "WarrHero.DB";
            //            sWizardHero = M2Share.g_Config.sSortDir + "WizardHero.DB";
            //            sTaosHero = M2Share.g_Config.sSortDir + "TaosHero.DB";
            //            nCode = 2;
            //            if (File.Exists(sHumDBFile) && (!GetPlayObjectLevelList_IsFileInUse(sHumDBFile)))
            //            {
            //                // 人物等级总排行
            //                LoadList.LoadFromFile(sHumDBFile);
            //                nCode = 3;
            //                if (m_PlayObjectLevelList.Count > 0)
            //                {
            //                    // 20080629
            //                    nCode = 4;
                                
            //                    for (I = m_PlayObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        // 20080527 可读文件,才清空原来的排行数据
            //                        if (((string[])(m_PlayObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_PlayObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_PlayObjectLevelList.Clear();
            //                }
            //                nCode = 5;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[0] != ';'))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
                                        
            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
                                        
            //                            m_PlayObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 6;
            //            if (File.Exists(sWarrHum) && (!GetPlayObjectLevelList_IsFileInUse(sWarrHum)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sWarrHum);
            //                nCode = 7;
                            
            //                if (m_WarrorObjectLevelList.Count > 0)
            //                {
            //                    // 20080814
                                
            //                    for (I = m_WarrorObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        // 20080814 可读文件,才清空原来的排行数据
            //                        if (((string[])(m_WarrorObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_WarrorObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_WarrorObjectLevelList.Clear();
            //                // 战士等级排行
            //                }
            //                nCode = 8;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
                                        
            //                            //FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
                                        
            //                            m_WarrorObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 9;
            //            if (File.Exists(sWizardHum) && (!GetPlayObjectLevelList_IsFileInUse(sWizardHum)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sWizardHum);
            //                nCode = 10;
                            
            //                if (m_WizardObjectLevelList.Count > 0)
            //                {
            //                    // 20080814
                                
            //                    for (I = m_WizardObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        // 20080814 可读文件,才清空原来的排行数据
            //                        if (((string[])(m_WizardObjectLevelList.Objects[I])) != null)
            //                        {
            //                            Dispose(((string[])(m_WizardObjectLevelList.Objects[I])));
            //                        }
            //                    }
            //                    m_WizardObjectLevelList.Clear;
            //                // 法师等级排行
            //                }
            //                nCode = 11;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
                                        
            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
                                        
            //                            m_WizardObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 12;
            //            if (File.Exists(sTaosHum) && (!GetPlayObjectLevelList_IsFileInUse(sTaosHum)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sTaosHum);
            //                nCode = 13;
                            
            //                if (m_TaoistObjectLevelList.Count > 0)
            //                {
            //                    // 20080814
                                
            //                    for (I = m_TaoistObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        // 20080814 可读文件,才清空原来的排行数据
                                    
            //                        if (((string[])(m_TaoistObjectLevelList.Objects[I])) != null)
            //                        {
                                        
                                        
            //                            Dispose(((string[])(m_TaoistObjectLevelList.Objects[I])));
            //                        }
            //                    }
                                
            //                    m_TaoistObjectLevelList.Clear;
            //                // 道士等级排行
            //                }
            //                nCode = 14;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
                                        
            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
                                        
            //                            m_TaoistObjectLevelList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 15;
            //            if (File.Exists(sMaster) && (!GetPlayObjectLevelList_IsFileInUse(sMaster)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sMaster);
            //                nCode = 16;
                            
            //                if (m_PlayObjectMasterList.Count > 0)
            //                {
            //                    // 20080629
                                
            //                    for (I = m_PlayObjectMasterList.Count - 1; I >= 0; I-- )
            //                    {
                                    
            //                        if (((string[])(m_PlayObjectMasterList.Objects[I])) != null)
            //                        {
                                        
                                        
            //                            Dispose(((string[])(m_PlayObjectMasterList.Objects[I])));
            //                        }
            //                    }
                                
            //                    m_PlayObjectMasterList.Clear;
            //                // 徒弟数排行
            //                }
            //                nCode = 17;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            CharName = new string();
                                        
            //                            FillChar(CharName, sizeof(Grobal2.string), 0);
            //                            CharName = sData;
                                        
            //                            m_PlayObjectMasterList.AddObject(sLineText, ((CharName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 18;
            //            if (File.Exists(sAllHero) && (!GetPlayObjectLevelList_IsFileInUse(sAllHero)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sAllHero);
            //                nCode = 19;
                            
            //                if (m_HeroObjectLevelList.Count > 0)
            //                {
            //                    // 20080629
                                
            //                    for (I = m_HeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
                                    
            //                        if (((string[])(m_HeroObjectLevelList.Objects[I])) != null)
            //                        {
                                        
                                        
            //                            Dispose(((string[])(m_HeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
                                
            //                    m_HeroObjectLevelList.Clear;
            //                // 英雄等级排行
            //                }
            //                nCode = 20;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
                                        
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
                                        
            //                            m_HeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 21;
            //            if (File.Exists(sWarrHero) && (!GetPlayObjectLevelList_IsFileInUse(sWarrHero)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sWarrHero);
            //                nCode = 22;
                            
            //                if (m_WarrorHeroObjectLevelList.Count > 0)
            //                {
            //                    // 20090114
                                
            //                    for (I = m_WarrorHeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
                                    
            //                        if (((string[])(m_WarrorHeroObjectLevelList.Objects[I])) != null)
            //                        {
                                        
                                        
            //                            Dispose(((string[])(m_WarrorHeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
                                
            //                    m_WarrorHeroObjectLevelList.Clear;
            //                // 英雄战士等级排行
            //                }
            //                nCode = 23;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
                                        
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
                                        
            //                            m_WarrorHeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 24;
            //            if (File.Exists(sWizardHero) && (!GetPlayObjectLevelList_IsFileInUse(sWizardHero)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sWizardHero);
            //                nCode = 25;
                            
            //                if (m_WizardHeroObjectLevelList.Count > 0)
            //                {
            //                    // 20090114
                                
            //                    for (I = m_WizardHeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
                                    
            //                        if (((string[])(m_WizardHeroObjectLevelList.Objects[I])) != null)
            //                        {
                                        
                                        
            //                            Dispose(((string[])(m_WizardHeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
                                
            //                    m_WizardHeroObjectLevelList.Clear;
            //                // 英雄法师等级排行
            //                }
            //                nCode = 26;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
                                        
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
                                        
            //                            m_WizardHeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //            nCode = 27;
            //            if (File.Exists(sTaosHero) && (!GetPlayObjectLevelList_IsFileInUse(sTaosHero)))
            //            {
            //                LoadList.Clear();
                            
            //                LoadList.LoadFromFile(sTaosHero);
            //                nCode = 30;
                            
            //                if (m_TaoistHeroObjectLevelList.Count > 0)
            //                {
            //                    // 20090114
            //                    nCode = 31;
                                
            //                    for (I = m_TaoistHeroObjectLevelList.Count - 1; I >= 0; I-- )
            //                    {
            //                        nCode = 32;
                                    
            //                        if (((string[])(m_TaoistHeroObjectLevelList.Objects[I])) != null)
            //                        {
                                        
                                        
            //                            Dispose(((string[])(m_TaoistHeroObjectLevelList.Objects[I])));
            //                        }
            //                    }
                                
            //                    m_TaoistHeroObjectLevelList.Clear;
            //                // 英雄道士等级排行
            //                }
            //                nCode = 29;
            //                if (LoadList.Count > 0)
            //                {
            //                    // 20090108
            //                    for (I = 0; I < LoadList.Count; I ++ )
            //                    {
            //                        sLineText = LoadList[I];
            //                        if ((sLineText != "") && (sLineText[1] != ";"))
            //                        {
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref sData, new string[] {" ", "\09"});
            //                            sLineText = HUtil32.GetValidStrCap(sLineText, ref s_Master, new string[] {" ", "\09"});
            //                            HeroName = new string();
                                        
            //                            FillChar(HeroName, sizeof(Grobal2.string), 0);
            //                            HeroName = sData + '\r' + s_Master;
                                        
            //                            m_TaoistHeroObjectLevelList.AddObject(sLineText, ((HeroName) as Object));
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch {
            //            M2Share.MainOutMessage("{异常} TUserEngine::GetPlayObjectLevelList Code:" + (nCode).ToString());
            //        }
            //    } finally {
                    
            //        Dispose(LoadList);
                    
            //        LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            //    }
            //} finally {
            //    LeaveCriticalSection(M2Share.HumanSortCriticalSection);
            //    // 20080926
            //    bo_ReadPlayLeveList = false;
            //    // 重新记时读取间隔 200808029
            //    dwGetOrderTick = GetTickCount();
            
            //}
        }

        
        public void Initialize()
        {
            int I;
            TMonGenInfo MonGen;
            MerchantInitialize();
            NPCinitialize();
            if (m_MonGenList.Count > 0)
            {
                for (I = 0; I < m_MonGenList.Count; I ++ )
                {
                    MonGen = m_MonGenList[I];
                    if (MonGen != null)
                    {
                        MonGen.nRace = GetMonRace(MonGen.sMonName);
                    }
                }
            }
        }

        public int AddMapMonGenCount(string sMapName, int nMonGenCount)
        {
            int result;
            int I;
            TMapMonGenCount MapMonGenCount;
            bool boFound;
            result =  -1;
            boFound = false;
            if (m_MapMonGenCountList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_MapMonGenCountList.Count; I ++ )
                {
                    MapMonGenCount = m_MapMonGenCountList[I];
                    if (MapMonGenCount != null)
                    {
                        if ((MapMonGenCount.sMapName).CompareTo((sMapName).ToLower()) == 0)
                        {
                            MapMonGenCount.nMonGenCount += nMonGenCount;
                            result = MapMonGenCount.nMonGenCount;
                            boFound = true;
                        }
                    }
                }
            // for
            }
            if (!boFound)
            {
                MapMonGenCount = new TMapMonGenCount();
                MapMonGenCount.sMapName = sMapName;
                MapMonGenCount.nMonGenCount = nMonGenCount;
                MapMonGenCount.dwNotHumTimeTick = GetTickCount();
                MapMonGenCount.dwMakeMonGenTimeTick = GetTickCount();
                MapMonGenCount.nClearCount = 0;
                MapMonGenCount.boNotHum = true;
                m_MapMonGenCountList.Add(MapMonGenCount);
                result = MapMonGenCount.nMonGenCount;
            }
            return result;
        }

        public TMapMonGenCount GetMapMonGenCount(string sMapName)
        {
            TMapMonGenCount result;
            int I;
            TMapMonGenCount MapMonGenCount;
            result = null;
            if (m_MapMonGenCountList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_MapMonGenCountList.Count; I ++ )
                {
                    MapMonGenCount = m_MapMonGenCountList[I];
                    if (MapMonGenCount != null)
                    {
                        if ((MapMonGenCount.sMapName).ToLower().CompareTo((sMapName).ToLower()) == 0)
                        {
                            result = MapMonGenCount;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // 取怪物的种族
        public int GetMonRace(string sMonName)
        {
            int result;
            int I;
            TMonInfo MonInfo;
            result =  -1;
            if (MonsterList.Count > 0)
            {
                // 20081008
                for (I = 0; I < MonsterList.Count; I ++ )
                {
                    MonInfo = MonsterList[I];
                    if (MonInfo != null)
                    {
                        if (string.Compare(MonInfo.sName, sMonName, true) == 0) {
                            result = MonInfo.btRace;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // 交易NPC初始化
        private void MerchantInitialize()
        {
            int I;
            TMerchant Merchant;
            string sCaption;
            //sCaption = svMain.Units.svMain.FrmMain.Text;
            //m_MerchantList.__Lock();
            try {
                for (I = m_MerchantList.Count - 1; I >= 0; I-- )
                {
                    if (m_MerchantList.Count <= 0)
                    {
                        break;
                    }
                    // 20081008
                    Merchant = ((TMerchant)(m_MerchantList[I]));
                    if (Merchant != null)
                    {
                        Merchant.m_PEnvir = M2Share.g_MapManager.FindMap(Merchant.m_sMapName);
                        if (Merchant.m_PEnvir != null)
                        {
                            Merchant.Initialize();
                            if (Merchant.m_boAddtoMapSuccess && (!Merchant.m_boIsHide))
                            {
                                M2Share.MainOutMessage("交易NPC 初始化失败..." + Merchant.m_sCharName + " " + Merchant.m_sMapName + "(" + (Merchant.m_nCurrX).ToString() + ":" + (Merchant.m_nCurrY).ToString() + ")");
                                m_MerchantList.RemoveAt(I);
                            }
                            else
                            {
                                Merchant.AddMapCount();
                                Merchant.LoadNpcScript();
                                Merchant.LoadNPCData();
                            }
                        }
                        else
                        {
                            M2Share.MainOutMessage(Merchant.m_sCharName + "交易NPC 初始化失败... (所在地图不存在)");
                            m_MerchantList.RemoveAt(I);
                        }
                        //FrmMain.Text = sCaption + "[正在初始交易NPC(" + (m_MerchantList.Count).ToString() + "/" + (m_MerchantList.Count - I).ToString() + ")]";
                    }
                }
            // for
            } finally {
                //m_MerchantList.UnLock();
            }
        }

        // 20080327
        private void NPCinitialize()
        {
            int I;
            TNormNpc NormNpc;
            for (I = QuestNPCList.Count - 1; I >= 0; I-- )
            {
                if (QuestNPCList.Count <= 0)
                {
                    break;
                }
                // 20081008
                NormNpc = ((TNormNpc)(QuestNPCList[I]));
                if (NormNpc != null)
                {
                    NormNpc.m_PEnvir = M2Share.g_MapManager.FindMap(NormNpc.m_sMapName);
                    if (NormNpc.m_PEnvir != null)
                    {
                        NormNpc.Initialize();
                        if (NormNpc.m_boAddtoMapSuccess && (!NormNpc.m_boIsHide))
                        {
                            M2Share.MainOutMessage(NormNpc.m_sCharName + " Npc 初始化失败... ");
                            QuestNPCList.RemoveAt(I);
                            Dispose(NormNpc);
                            //NormNpc.Free;
                        }
                        else
                        {
                            NormNpc.LoadNpcScript();
                        }
                    }
                    else
                    {
                        M2Share.MainOutMessage(NormNpc.m_sCharName + " Npc 初始化失败... (npc.PEnvir=nil) ");
                        QuestNPCList.RemoveAt(I);
                        Dispose(NormNpc);
                       // NormNpc.Free;
                    }
                }
            }
        }

        private int GetLoadPlayCount()
        {
            int result;
            result = m_LoadPlayList.Count;
            return result;
        }

        private int GetOnlineHumCount()
        {
            int result;
            result = m_PlayObjectList.Count;
            return result;
        }

        // 取玩家数量
        private int GetUserCount()
        {
            int result;
            result = m_PlayObjectList.Count;
            return result;
        }

        // 取自动挂机人物数量
        private int GetAutoAddExpPlayCount()
        {
            int result;
            int I;
            result = 0;
            M2Share.ProcessHumanCriticalSection.AcquireReaderLock(-1);
            try {
                if (m_PlayObjectList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_PlayObjectList.Count; I ++ )
                    {
                        //if (((TPlayObject)(m_PlayObjectList[I])).m_boNotOnlineAddExp)
                        //{
                        //    result ++;
                        //}
                    }
                }
            } finally {
                M2Share.ProcessHumanCriticalSection.ReleaseLock();
            }
            return result;
        }

        public bool ProcessHumans_IsLogined(string sAccount, string sChrName)
        {
            bool result;
            // 是否是登录过的账号
            int I;
            result = false;
            if (M2Share.FrontEngine.InSaveRcdList(sAccount, sChrName))
            {
                result = true;
            }
            else
            {
                if (m_PlayObjectList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_PlayObjectList.Count; I ++ )
                    {
                        //if (((((TPlayObject)(m_PlayObjectList.Values[I])).m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0) && ((m_PlayObjectList[I]).ToLower().CompareTo((sChrName).ToLower()) == 0))
                        //{
                        //    result = true;
                        //    break;
                        //}
                    }
                // for
                }
            }
            return result;
        }

        public TPlayObject ProcessHumans_MakeNewHuman(TUserOpenInfo UserOpenInfo)
        {
            TPlayObject result;
            // 制造新的人物
            TPlayObject PlayObject;
            TAbility Abil;
            TEnvirnoment Envir;
            int nC;
            TSwitchDataInfo SwitchDataInfo;
            TUserCastle Castle;
            result = null;
            try {
                PlayObject = new TPlayObject();
                SwitchDataInfo = null;
                if (SwitchDataInfo == null)
                {
                    GetHumData(PlayObject, ref UserOpenInfo.HumanRcd);
                    PlayObject.m_btRaceServer = Grobal2.RC_PLAYOBJECT;
                    if (PlayObject.m_sHomeMap == "")
                    {
ReGetMap:
                        PlayObject.m_sHomeMap = GetHomeInfo(ref PlayObject.m_nHomeX, ref PlayObject.m_nHomeY);
                        PlayObject.m_sMapName = PlayObject.m_sHomeMap;
                        PlayObject.m_nCurrX = GetRandHomeX(PlayObject);
                        PlayObject.m_nCurrY = GetRandHomeY(PlayObject);
                        if (PlayObject.m_Abil.Level >= 0)
                        {
                            Abil = PlayObject.m_Abil;
                            Abil.Level = 1;
                            Abil.AC = 0;
                            Abil.MAC = 0;
                            Abil.DC = MakeLong(1, 2);
                            Abil.MC = MakeLong(1, 2);
                            Abil.SC = MakeLong(1, 2);
                            Abil.MP = 15;
                            Abil.HP = 15;
                            Abil.MaxHP = 15;
                            Abil.MaxMP = 15;
                            Abil.Exp = 10;
                            Abil.MaxExp = 100;
                            Abil.Weight = 100;
                            Abil.MaxWeight = 100;
                            PlayObject.m_boNewHuman = true;
                        }
                    }
                    Envir = M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, PlayObject.m_sMapName);
                    if (Envir != null)
                    {
                        if (Envir.m_boFight3Zone)
                        {
                            // 是否在行会战争地图死亡
                            if ((PlayObject.m_Abil.HP <= 0) && (PlayObject.m_nFightZoneDieCount < 3))
                            {
                                PlayObject.m_Abil.HP = PlayObject.m_Abil.MaxHP;
                                PlayObject.m_Abil.MP = PlayObject.m_Abil.MaxMP;
                                PlayObject.m_boDieInFight3Zone = true;
                            }
                            else
                            {
                                PlayObject.m_nFightZoneDieCount = 0;
                            }
                        }
                    }
                    PlayObject.m_MyGuild = M2Share.g_GuildManager.MemberOfGuild(PlayObject.m_sCharName);
                    // 取玩家所属的行会
                    Castle = M2Share.g_CastleManager.InCastleWarArea(Envir, PlayObject.m_nCurrX, PlayObject.m_nCurrY);
                    // 
                    // if (Envir <> nil) and ((UserCastle.m_MapPalace = Envir) or
                    // (UserCastle.m_boUnderWar and UserCastle.InCastleWarArea(PlayObject.m_PEnvir,PlayObject.m_nCurrX,PlayObject.m_nCurrY))) then begin
                    // 
                    if ((Envir != null) && (Castle != null) && ((Castle.m_MapPalace == Envir) || Castle.m_boUnderWar))
                    {
                        Castle = M2Share.g_CastleManager.IsCastleMember(PlayObject);
                        // if not UserCastle.IsMember(PlayObject) then begin
                        if (Castle == null)
                        {
                            PlayObject.m_sMapName = PlayObject.m_sHomeMap;
                            PlayObject.m_nCurrX = PlayObject.m_nHomeX - 2 + HUtil32.Random(5);
                            PlayObject.m_nCurrY = PlayObject.m_nHomeY - 2 + HUtil32.Random(5);
                        }
                        else
                        {
                            // 
                            // if UserCastle.m_MapPalace = Envir then begin
                            // PlayObject.m_sMapName:=UserCastle.GetMapName();
                            // PlayObject.m_nCurrX:=UserCastle.GetHomeX;
                            // PlayObject.m_nCurrY:=UserCastle.GetHomeY;
                            // end;
                            // 
                            if (Castle.m_MapPalace == Envir)
                            {
                                PlayObject.m_sMapName = Castle.GetMapName();
                                PlayObject.m_nCurrX = Castle.GetHomeX();
                                PlayObject.m_nCurrY = Castle.GetHomeY();
                            }
                        }
                    }
                    // if (PlayObject.nC4 <= 1) and (PlayObject.m_Abil.Level >= 1) then//20081007 注释，nC4无实际用处
                    // PlayObject.nC4 := 2;
                    if (M2Share.g_MapManager.FindMap(PlayObject.m_sMapName) == null)
                    {
                        PlayObject.m_Abil.HP = 0;
                    }
                    if (PlayObject.m_Abil.HP <= 0)
                    {
                        PlayObject.ClearStatusTime();
                        if (PlayObject.PKLevel() < 2)
                        {
                            // 没有红名
                            Castle = M2Share.g_CastleManager.IsCastleMember(PlayObject);
                            // if UserCastle.m_boUnderWar and (UserCastle.IsMember(PlayObject)) then begin
                            if ((Castle != null) && Castle.m_boUnderWar)
                            {
                                PlayObject.m_sMapName = Castle.m_sHomeMap;
                                PlayObject.m_nCurrX = Castle.GetHomeX();
                                PlayObject.m_nCurrY = Castle.GetHomeY();
                            }
                            else
                            {
                                PlayObject.m_sMapName = PlayObject.m_sHomeMap;
                                PlayObject.m_nCurrX = PlayObject.m_nHomeX - 2 + HUtil32.Random(5);
                                PlayObject.m_nCurrY = PlayObject.m_nHomeY - 2 + HUtil32.Random(5);
                            }
                        }
                        else
                        {
                            // '3'
                            PlayObject.m_sMapName = M2Share.g_Config.sRedDieHomeMap;
                            // 839
                            PlayObject.m_nCurrX = HUtil32.Random(13) + M2Share.g_Config.nRedDieHomeX;
                            // 668
                            PlayObject.m_nCurrY = HUtil32.Random(13) + M2Share.g_Config.nRedDieHomeY;
                        }
                        PlayObject.m_Abil.HP = 14;
                    }
                    PlayObject.AbilCopyToWAbil();
                    Envir = M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, PlayObject.m_sMapName);
                    if (Envir == null)
                    {
                        PlayObject.m_nSessionID = UserOpenInfo.LoadUser.nSessionID;
                        PlayObject.m_nSocket = UserOpenInfo.LoadUser.nSocket;
                        PlayObject.m_nGateIdx = UserOpenInfo.LoadUser.nGateIdx;
                        PlayObject.m_nGSocketIdx = UserOpenInfo.LoadUser.nGSocketIdx;
                        PlayObject.m_WAbil = PlayObject.m_Abil;
                        PlayObject.m_nServerIndex = M2Share.g_MapManager.GetMapOfServerIndex(PlayObject.m_sMapName);
                        SendSwitchData(PlayObject, PlayObject.m_nServerIndex);
                        SendChangeServer(PlayObject, PlayObject.m_nServerIndex);
                        // PlayObject.Free;
                        PlayObject = null;
                        return result;
                    }
                    nC = 0;
                    while (true)
                    {
                        if (Envir.CanWalk(PlayObject.m_nCurrX, PlayObject.m_nCurrY, true))
                        {
                            break;
                        }
                        PlayObject.m_nCurrX = PlayObject.m_nCurrX - 3 + HUtil32.Random(6);
                        PlayObject.m_nCurrY = PlayObject.m_nCurrY - 3 + HUtil32.Random(6);
                        nC ++;
                        if (nC >= 5)
                        {
                            break;
                        }
                    }
                    if (!Envir.CanWalk(PlayObject.m_nCurrX, PlayObject.m_nCurrY, true))
                    {
                        PlayObject.m_sMapName = M2Share.g_Config.sHomeMap;
                        Envir = M2Share.g_MapManager.FindMap(M2Share.g_Config.sHomeMap);
                        PlayObject.m_nCurrX = M2Share.g_Config.nHomeX;
                        PlayObject.m_nCurrY = M2Share.g_Config.nHomeY;
                    }
                    PlayObject.m_PEnvir = Envir;
                    if (PlayObject.m_PEnvir == null)
                    {
                        M2Share.MainOutMessage("[错误] PlayObject.PEnvir = nil");
                        //goto ReGetMap; 
                    }
                    else
                    {
                        PlayObject.m_boReadyRun = false;
                    }
                }
                else
                {
                    GetHumData(PlayObject, ref UserOpenInfo.HumanRcd);
                    PlayObject.m_sMapName = SwitchDataInfo.sMAP;
                    PlayObject.m_nCurrX = SwitchDataInfo.wX;
                    PlayObject.m_nCurrY = SwitchDataInfo.wY;
                    PlayObject.m_Abil = SwitchDataInfo.Abil;
                    PlayObject.m_WAbil = SwitchDataInfo.Abil;
                    LoadSwitchData(SwitchDataInfo, ref PlayObject);
                    DelSwitchData(SwitchDataInfo);
                    Envir = M2Share.g_MapManager.GetMapInfo(M2Share.nServerIndex, PlayObject.m_sMapName);
                    if (Envir != null)
                    {
                        PlayObject.m_sMapName = M2Share.g_Config.sHomeMap;
                        // Envir := g_MapManager.FindMap(g_Config.sHomeMap); //20080408 没有使用
                        PlayObject.m_nCurrX = M2Share.g_Config.nHomeX;
                        PlayObject.m_nCurrY = M2Share.g_Config.nHomeY;
                    }
                    else
                    {
                        if (!Envir.CanWalk(PlayObject.m_nCurrX, PlayObject.m_nCurrY, true))
                        {
                            PlayObject.m_sMapName = M2Share.g_Config.sHomeMap;
                            Envir = M2Share.g_MapManager.FindMap(M2Share.g_Config.sHomeMap);
                            PlayObject.m_nCurrX = M2Share.g_Config.nHomeX;
                            PlayObject.m_nCurrY = M2Share.g_Config.nHomeY;
                        }
                        PlayObject.AbilCopyToWAbil();
                        PlayObject.m_PEnvir = Envir;
                        if (PlayObject.m_PEnvir == null)
                        {
                            M2Share.MainOutMessage("[错误] PlayObject.PEnvir = nil");
                            //goto ReGetMap; 
                        }
                        else
                        {
                            PlayObject.m_boReadyRun = false;
                            PlayObject.m_boLoginNoticeOK = true;
                            PlayObject.bo6AB = true;
                        }
                    }
                }
                PlayObject.m_sUserID = UserOpenInfo.LoadUser.sAccount;
                PlayObject.m_sIPaddr = UserOpenInfo.LoadUser.sIPaddr;
                PlayObject.m_sIPLocal = M2Share.GetIPLocal(PlayObject.m_sIPaddr);
                PlayObject.m_nSocket = UserOpenInfo.LoadUser.nSocket;
                PlayObject.m_nGSocketIdx = UserOpenInfo.LoadUser.nGSocketIdx;
                PlayObject.m_nGateIdx = UserOpenInfo.LoadUser.nGateIdx;
                PlayObject.m_nSessionID = UserOpenInfo.LoadUser.nSessionID;
                PlayObject.m_nPayMent = UserOpenInfo.LoadUser.nPayMent;
                PlayObject.m_nPayMode = UserOpenInfo.LoadUser.nPayMode;
                // PlayObject.m_dwLoadTick := UserOpenInfo.LoadUser.dwNewUserTick; //未使用 20080329
                PlayObject.m_nSoftVersionDateEx = M2Share.GetExVersionNO(UserOpenInfo.LoadUser.nSoftVersionDate, ref PlayObject.m_nSoftVersionDate);
                result = PlayObject;
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine::MakeNewHuman");
            }
            return result;
        }

        private void ProcessHumans()
        {
            // type //20080815 注释
            // TGetLicense = function(var nProVersion: Integer; var UserLicense: Integer; var ErrorCode: Integer): Integer; stdcall;
            uint dwUsrRotTime;
            uint dwCheckTime;
            uint dwCurTick;
            byte nCheck30;
            bool boCheckTimeLimit;
            int nIdx;
            TPlayObject PlayObject;
            int I;
            TUserOpenInfo UserOpenInfo;
            TGoldChangeInfo GoldChangeInfo;
            string LineNoticeMsg;
            if (m_boHumProcess)
            {
                return;
            }
            // 20080717 检查过程是否重入
            m_boHumProcess = true;
            // 20080717 检查过程是否重入
            try {
                nCheck30 = 0;
                
                dwCheckTime = GetTickCount();
                if ((GetTickCount() - m_dwProcessLoadPlayTick) > 200)
                {
                    nCheck30 = 21;
                    m_dwProcessLoadPlayTick = GetTickCount();
                    try {
                        m_LoadPlaySection.AcquireReaderLock(-1);
                        try {
                            if (m_LoadPlayList.Count > 0)
                            {
                                // 20081008
                                for (I = 0; I < m_LoadPlayList.Count; I ++ )
                                {
                                    nCheck30 = 22;
                                    
                                    UserOpenInfo = m_LoadPlayList[I];
                                    if (!UserOpenInfo.LoadUser.boIsHero)
                                    {
                                        nCheck30 = 23;
                                        if (!M2Share.FrontEngine.IsFull() && !ProcessHumans_IsLogined(UserOpenInfo.sAccount, m_LoadPlayList[I].sChrName))
                                        {
                                            nCheck30 = 24;
                                            PlayObject = ProcessHumans_MakeNewHuman(UserOpenInfo);
                                            // 制造新的人物
                                            if (PlayObject != null)
                                            {
                                                nCheck30 = 25;
                                                PlayObject.AddMapCount();
                                                PlayObject.m_boClientFlag = UserOpenInfo.LoadUser.boClinetFlag;
                                                // 将客户端标志传到人物数据中
                                                //m_PlayObjectList.Add(m_LoadPlayList[I], PlayObject);
                                                SendServerGroupMsg(Grobal2.SS_201, M2Share.nServerIndex, PlayObject.m_sCharName);
                                                nCheck30 = 26;
                                                m_NewHumanList.Add(PlayObject);
                                            }
                                        }
                                        else
                                        {
                                            nCheck30 = 27;
                                            KickOnlineUser(m_LoadPlayList[I].sChrName);
                                            // /踢出在线人物
                                            m_ListOfGateIdx.Add((UserOpenInfo.LoadUser.nGateIdx as object));
                                            m_ListOfSocket.Add((UserOpenInfo.LoadUser.nSocket as object));
                                        }
                                    }
                                    else
                                    {
                                        nCheck30 = 28;
                                        if (UserOpenInfo.LoadUser.PlayObject != null)
                                        {
                                            // 开始召唤英雄
                                            PlayObject = GetPlayObject(((TBaseObject)(UserOpenInfo.LoadUser.PlayObject)));
                                            nCheck30 = 29;
                                            if (PlayObject != null)
                                            {
                                                switch(UserOpenInfo.LoadUser.btLoadDBType)
                                                {
                                                    case 0:
                                                        // 召唤
                                                        nCheck30 = 30;
                                                        if (UserOpenInfo.nOpenStatus == 1)
                                                        {
                                                            PlayObject.m_MyHero = PlayObject.MakeHero(PlayObject, UserOpenInfo.HumanRcd);
                                                            if (PlayObject.m_MyHero != null)
                                                            {
                                                                nCheck30 = 31;
                                                                ((THeroObject)(PlayObject.m_MyHero)).Login();
                                                                // 英雄登录
                                                                PlayObject.m_MyHero.m_btAttatckMode = PlayObject.m_btAttatckMode;
                                                                // 与主人的攻击模式一致，以修正宝宝可以正常攻击目标 20090113
                                                                PlayObject.m_MyHero.SendRefMsg(Grobal2.RM_CREATEHERO, PlayObject.m_MyHero.m_btDirection, PlayObject.m_MyHero.m_nCurrX, PlayObject.m_MyHero.m_nCurrY, 0, "");
                                                                // 刷新客户端，创建英雄信息
                                                                //PlayObject.SendMsg(PlayObject, Grobal2.RM_RECALLHERO, 0, ((int)PlayObject.m_MyHero), 0, 0, "");
                                                                PlayObject.n_myHeroTpye = ((THeroObject)(PlayObject.m_MyHero)).n_HeroTpye;
                                                                switch(((THeroObject)(PlayObject.m_MyHero)).m_btStatus)
                                                                {
                                                                    case 1:
                                                                        // 20080515 英雄的类型
                                                                        // THeroObject(PlayObject.m_MyHero).SysMsg('(英雄) 忠诚度为'+floattostr(THeroObject(PlayObject.m_MyHero).m_nLoyal / 100)+'%', c_Green, t_Hint);//20090114 取消忠城度提示
                                                                        ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroFollow, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 0:
                                                                        // 20080316
                                                                        // THeroObject(PlayObject.m_MyHero).SysMsg('(英雄) 忠诚度为'+floattostr(THeroObject(PlayObject.m_MyHero).m_nLoyal / 100)+'%', c_Green, t_Hint);//20090114 取消忠城度提示
                                                                        ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroAttack, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 2:
                                                                        // 20080316
                                                                        // THeroObject(PlayObject.m_MyHero).SysMsg('(英雄) 忠诚度为'+floattostr(THeroObject(PlayObject.m_MyHero).m_nLoyal / 100)+'%', c_Green, t_Hint);//20090114 取消忠城度提示
                                                                        ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroRest, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                // 20080316
                                                                }
                                                                ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroLoginMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
                                                                {
                                                                    // 学过内功
                                                                    ((THeroObject)(PlayObject.m_MyHero)).m_MaxExpSkill69 = ((THeroObject)(PlayObject.m_MyHero)).GetSkill69Exp(((THeroObject)(PlayObject.m_MyHero)).m_NGLevel, ref ((THeroObject)(PlayObject.m_MyHero)).m_Skill69MaxNH);
                                                                    // 登录重新取内功心法升级经验 20081002
                                                                    //((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROMAGIC69SKILLEXP, 0, 0, 0, ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel, EDcode.Units.EDcode.EncodeString((((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69).ToString() + "/" + (((THeroObject)(PlayObject.m_MyHero)).m_MaxExpSkill69).ToString()));
                                                                    ((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(PlayObject.m_MyHero)).m_Skill69NH, ((THeroObject)(PlayObject.m_MyHero)).m_Skill69MaxNH, 0, "");
                                                                    // 内力值让别人看到 20081002
                                                                    //((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.SM_OPENPULS, ((ushort)((THeroObject)(PlayObject.m_MyHero)).m_boisOpenPuls), 0, 0, 0, "");
                                                                    // 英雄经络
                                                                    ((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROPULSECHANGED, 0, 0, 0, 0, "");
                                                                    // 英雄经络
                                                                    ((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROBATTERORDER, 0, 0, 0, 1, "");
                                                                // 英雄连击次序
                                                                // THeroObject(PlayObject.m_MyHero).StormsRateChanged(); 已修改成全局的表 只需发送主人一份就可以了
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 1:
                                                        // 新建
                                                        nCheck30 = 32;
                                                        switch(UserOpenInfo.nOpenStatus)
                                                        {
                                                            case 1:
                                                                switch(PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        // 20080519
                                                                        PlayObject.m_boHasHero = true;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = true;
                                                                        break;
                                                                }
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@CreateHeroOK", false);
                                                                }
                                                                break;
                                                            case 2:
                                                                switch(PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        // 20080519
                                                                        PlayObject.m_boHasHero = false;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = false;
                                                                        break;
                                                                }
                                                                PlayObject.m_sHeroCharName = "";
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@HeroNameExists", false);
                                                                }
                                                                break;
                                                            case 3:
                                                                switch(PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        // 20080519
                                                                        PlayObject.m_boHasHero = false;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = false;
                                                                        break;
                                                                }
                                                                PlayObject.m_sHeroCharName = "";
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@HeroOverChrCount", false);
                                                                }
                                                                break;
                                                            default:
                                                                nCheck30 = 33;
                                                                switch(PlayObject.n_tempHeroTpye)
                                                                {
                                                                    case 0:
                                                                        // 20080519
                                                                        PlayObject.m_boHasHero = false;
                                                                        break;
                                                                    case 1:
                                                                        PlayObject.m_boHasHeroTwo = false;
                                                                        break;
                                                                }
                                                                PlayObject.m_sHeroCharName = "";
                                                                if (M2Share.g_FunctionNPC != null)
                                                                {
                                                                    M2Share.g_FunctionNPC.GotoLable(PlayObject, "@CreateHeroFail", false);
                                                                }
                                                                break;
                                                        }
                                                        break;
                                                    case 2:
                                                        // 删除英雄
                                                        nCheck30 = 34;
                                                        if (UserOpenInfo.nOpenStatus == 1)
                                                        {
                                                            switch(PlayObject.n_myHeroTpye)
                                                            {
                                                                case 0:
                                                                    // 20080519
                                                                    PlayObject.m_boHasHero = false;
                                                                    break;
                                                                case 1:
                                                                    PlayObject.m_boHasHeroTwo = false;
                                                                    break;
                                                            }
                                                            PlayObject.m_sHeroCharName = "";
                                                            PlayObject.n_myHeroTpye = 3;
                                                            // 英雄的类型 20080515
                                                            if (M2Share.g_FunctionNPC != null)
                                                            {
                                                                M2Share.g_FunctionNPC.GotoLable(PlayObject, "@DeleteHeroOK", false);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (M2Share.g_FunctionNPC != null)
                                                            {
                                                                M2Share.g_FunctionNPC.GotoLable(PlayObject, "@DeleteHeroFail", false);
                                                            }
                                                        }
                                                        break;
                                                    case 3:
                                                        // 查询英雄相关数据 20080514
                                                        nCheck30 = 35;
                                                        if (UserOpenInfo.LoadUser.sMsg != "")
                                                        {
                                                            PlayObject.SendMsg(PlayObject, Grobal2.RM_GETHEROINFO, 0, 0, 0, 0, UserOpenInfo.LoadUser.sMsg);
                                                        }
                                                        break;
                                                    case 4:
                                                        // 召唤  双英雄
                                                        nCheck30 = 30;
                                                        if (UserOpenInfo.nOpenStatus == 1)
                                                        {
                                                            PlayObject.m_MyHero = PlayObject.MakeHero(PlayObject, UserOpenInfo.HumanRcd);
                                                            if (PlayObject.m_MyHero != null)
                                                            {
                                                                nCheck30 = 31;
                                                                ((THeroObject)(PlayObject.m_MyHero)).m_btMentHero = UserOpenInfo.HumanRcd.Data.m_btFHeroType;
                                                                ((THeroObject)(PlayObject.m_MyHero)).Login();
                                                                // 英雄登录
                                                                PlayObject.m_MyHero.m_btAttatckMode = PlayObject.m_btAttatckMode;
                                                                // 与主人的攻击模式一致，以修正宝宝可以正常攻击目标 20090113
                                                                PlayObject.m_MyHero.SendRefMsg(Grobal2.RM_CREATEHERO, PlayObject.m_MyHero.m_btDirection, PlayObject.m_MyHero.m_nCurrX, PlayObject.m_MyHero.m_nCurrY, 0, "");
                                                                // 刷新客户端，创建英雄信息
                                                                //PlayObject.SendMsg(PlayObject, Grobal2.RM_RECALLHERO, 0, ((int)PlayObject.m_MyHero), 0, 0, "");
                                                                PlayObject.n_myHeroTpye = ((THeroObject)(PlayObject.m_MyHero)).n_HeroTpye;
                                                                switch(((THeroObject)(PlayObject.m_MyHero)).m_btStatus)
                                                                {
                                                                    case 1:
                                                                        // 20080515 英雄的类型
                                                                        // THeroObject(PlayObject.m_MyHero).SysMsg('(英雄) 忠诚度为'+floattostr(THeroObject(PlayObject.m_MyHero).m_nLoyal / 100)+'%', c_Green, t_Hint);//20090114 取消忠城度提示
                                                                        ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroFollow, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 0:
                                                                        // 20080316
                                                                        // THeroObject(PlayObject.m_MyHero).SysMsg('(英雄) 忠诚度为'+floattostr(THeroObject(PlayObject.m_MyHero).m_nLoyal / 100)+'%', c_Green, t_Hint);//20090114 取消忠城度提示
                                                                        ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroAttack, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                    case 2:
                                                                        // 20080316
                                                                        // THeroObject(PlayObject.m_MyHero).SysMsg('(英雄) 忠诚度为'+floattostr(THeroObject(PlayObject.m_MyHero).m_nLoyal / 100)+'%', c_Green, t_Hint);//20090114 取消忠城度提示
                                                                        ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroRest, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                        break;
                                                                // 20080316
                                                                }
                                                                ((THeroObject)(PlayObject.m_MyHero)).SysMsg(M2Share.g_sHeroLoginMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                                                ((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_ISDEHERO, 0, 0, 0, 1, "");
                                                                // 是副将英雄
                                                                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
                                                                {
                                                                    // 学过内功
                                                                    ((THeroObject)(PlayObject.m_MyHero)).m_MaxExpSkill69 = ((THeroObject)(PlayObject.m_MyHero)).GetSkill69Exp(((THeroObject)(PlayObject.m_MyHero)).m_NGLevel, ref ((THeroObject)(PlayObject.m_MyHero)).m_Skill69MaxNH);
                                                                    // 登录重新取内功心法升级经验 20081002
                                                                    //((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROMAGIC69SKILLEXP, 0, 0, 0, ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel, EDcode.Units.EDcode.EncodeString((((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69).ToString() + "/" + (((THeroObject)(PlayObject.m_MyHero)).m_MaxExpSkill69).ToString()));
                                                                    ((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(PlayObject.m_MyHero)).m_Skill69NH, ((THeroObject)(PlayObject.m_MyHero)).m_Skill69MaxNH, 0, "");
                                                                    // 内力值让别人看到 20081002
                                                                    //((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.SM_OPENPULS, ((ushort)((THeroObject)(PlayObject.m_MyHero)).m_boisOpenPuls), 0, 0, 0, "");
                                                                    // 英雄经络
                                                                    ((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROPULSECHANGED, 0, 0, 0, 0, "");
                                                                    // 英雄经络
                                                                    ((THeroObject)(PlayObject.m_MyHero)).SendMsg(PlayObject.m_MyHero, Grobal2.RM_HEROBATTERORDER, 0, 0, 0, 1, "");
                                                                // 英雄连击次序
                                                                // THeroObject(PlayObject.m_MyHero).StormsRateChanged(); 已修改成全局的表 只需发送主人一份就可以了
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case 5:
                                                        // 新建  双英雄
                                                        if ((PlayObject.sName1 != "") && (PlayObject.sName2 != ""))
                                                        {
                                                            PlayObject.m_sHeroCharName = PlayObject.sName1;
                                                            PlayObject.m_sDeputyHeroCharName = PlayObject.sName2;
                                                        }
                                                        break;
                                                    case 6:
                                                        break;
                                                    case 7:
                                                        // 删除  双英雄
                                                        // 查询  双英雄
                                                        nCheck30 = 35;
                                                        if (UserOpenInfo.LoadUser.sMsg != "")
                                                        {
                                                            PlayObject.SendMsg(PlayObject, Grobal2.RM_GETASSESSHEROINFO, 0, 0, 0, 0, UserOpenInfo.LoadUser.sMsg);
                                                        }
                                                        break;
                                                }
                                                PlayObject.m_boWaitHeroDate = false;
                                            }
                                        }

                                    }
                                    nCheck30 = 36;
                                    Dispose(m_LoadPlayList[I]);
                                }
                                nCheck30 = 37;
                                m_LoadPlayList.Clear();
                            }
                            if (m_ChangeHumanDBGoldList.Count > 0)
                            {
                                // 20081008
                                for (I = 0; I < m_ChangeHumanDBGoldList.Count; I ++ )
                                {
                                    nCheck30 = 38;
                                    GoldChangeInfo = m_ChangeHumanDBGoldList[I];
                                    PlayObject = GetPlayObject(GoldChangeInfo.sGameMasterName);
                                    if (PlayObject != null)
                                    {
                                        PlayObject.GoldChange(GoldChangeInfo.sGetGoldUser, GoldChangeInfo.nGold);
                                    }
                                    nCheck30 = 39;
                                    
                                    Dispose(GoldChangeInfo);
                                }
                                nCheck30 = 40;
                                m_ChangeHumanDBGoldList.Clear();
                            }
                        } finally {
                            
                            LeaveCriticalSection(m_LoadPlaySection);
                        }
                        nCheck30 = 41;
                        if (m_NewHumanList.Count > 0)
                        {
                            // 20081008
                            for (I = 0; I < m_NewHumanList.Count; I ++ )
                            {
                                nCheck30 = 42;
                                //M2Share.RunSocket.SetGateUserList(PlayObject.m_nGateIdx, PlayObject.m_nSocket, PlayObject);
                            }
                            nCheck30 = 44;
                            m_NewHumanList.Clear();
                        }
                        nCheck30 = 45;
                        if (m_ListOfGateIdx.Count > 0)
                        {
                            // 20081008
                            for (I = 0; I < m_ListOfGateIdx.Count; I ++ )
                            {
                                nCheck30 = 46;
                                //M2Share.RunSocket.CloseUser(((int)m_ListOfGateIdx[I]), ((int)m_ListOfSocket[I]));
                            // GateIdx,nSocket
                            }
                            nCheck30 = 47;
                            m_ListOfGateIdx.Clear();
                        }
                        nCheck30 = 48;
                        m_ListOfSocket.Clear();
                    }
                    catch(Exception E) {
                        M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans -> Ready, Save, Load... Code:" + (nCheck30).ToString());
                    }
                }
                try {
                    if (m_PlayObjectFreeList.Count > 0)
                    {
                        // 20081008
                        for (I = 0; I < m_PlayObjectFreeList.Count; I ++ )
                        {
                            PlayObject = ((TPlayObject)(m_PlayObjectFreeList[I]));
                            // 5 * 60 * 1000
                            if ((GetTickCount() - PlayObject.m_dwGhostTick) > M2Share.g_Config.dwHumanFreeDelayTime)
                            {
                                try {
                                    // TPlayObject(m_PlayObjectFreeList.Items[I]).Free;
                                    if (PlayObject != null)
                                    {
                                        // 20080821 修改
                                        Dispose(PlayObject);
                                        PlayObject = null;
                                    }
                                }
                                catch {
                                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans ClosePlayer.Delete - Free");
                                }
                                m_PlayObjectFreeList.RemoveAt(I);
                                break;
                            }
                            else
                            {
                                if (PlayObject.m_boSwitchData && (PlayObject.m_boRcdSaved))
                                {
                                    if (SendSwitchData(PlayObject, PlayObject.m_nServerIndex) || (PlayObject.m_nWriteChgDataErrCount > 20))
                                    {
                                        PlayObject.m_boSwitchData = false;
                                        PlayObject.m_boSwitchDataSended = true;
                                        
                                        PlayObject.m_dwChgDataWritedTick = GetTickCount();
                                    }
                                    else
                                    {
                                        PlayObject.m_nWriteChgDataErrCount ++;
                                    }
                                }
                                
                                if (PlayObject.m_boSwitchDataSended && ((GetTickCount() - PlayObject.m_dwChgDataWritedTick) > 100))
                                {
                                    PlayObject.m_boSwitchDataSended = false;
                                    SendChangeServer(PlayObject, PlayObject.m_nServerIndex);
                                }
                            }
                        }
                    // for
                    }
                }
                catch {
                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans ClosePlayer.Delete");
                }
                // ===================================重新获取授权===============================
                try {
                    
                    // 1000 * 60 * 60
                    if (((GetTickCount() - m_dwSearchTick) > 3600000) || (m_TodayDate != DateTime.Today))
                    {
                        m_TodayDate = DateTime.Today;
                        // 20080603 //判断M2标题是否被破解修改
                        m_dwSearchTick = GetTickCount();
                        m_nLimitNumber = 1000000;
                        m_nLimitUserCount = 1000000;
                    }
                }
                catch {
                    M2Share.MainOutMessage("{异常} TUserEngine::GetLicense");
                }
                // --------------------------------------------------------------------------------
                boCheckTimeLimit = false;
                try {
                    
                    dwCurTick = GetTickCount();
                    nIdx = m_nProcHumIDx;
                    while (true)
                    {
                        if (m_PlayObjectList.Count <= nIdx)
                        {
                            break;
                        }
                        
                        PlayObject = ((TPlayObject)(m_PlayObjectList[nIdx]));
                        if (PlayObject != null)
                        {
                            if (PlayObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                            {
                                break;
                            }
                            // 20080901 不是人物则退出
                            if (((int)dwCurTick - PlayObject.m_dwRunTick) > PlayObject.m_nRunTime)
                            {
                                PlayObject.m_dwRunTick = dwCurTick;
                                if (!PlayObject.m_boGhost)
                                {
                                    if (!PlayObject.m_boLoginNoticeOK)
                                    {
                                        try {
                                            PlayObject.RunNotice();
                                        // 运行游戏忠告,即将进入游戏时的提示框
                                        }
                                        catch {
                                            M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans RunNotice");
                                        }
                                    }
                                    else
                                    {
                                        try {
                                            if (!PlayObject.m_boReadyRun)
                                            {
                                                // 是否进入游戏完成
                                                PlayObject.m_boReadyRun = true;
                                                // PlayObject.m_boNotOnlineAddExp := False;//20080522
                                                PlayObject.UserLogon();
                                                // 人物登录游戏
                                                if (PlayObject.m_boNotOnlineAddExp)
                                                {
                                                    // 人物在挂机状态 20080523
                                                    PlayObject.m_boNotOnlineAddExp = false;
                                                    PlayObject.m_boPlayOffLine = false;
                                                    // 不下线触发 20080716
                                                    if (M2Share.g_ManageNPC != null)
                                                    {
                                                        M2Share.g_ManageNPC.GotoLable(PlayObject, "@RESUME", false);
                                                    }
                                                // 人物在挂机状态,让人物小退
                                                }
                                            }
                                            else
                                            {
                                                if ((GetTickCount() - PlayObject.m_dwSearchTick) > PlayObject.m_dwSearchTime)
                                                {
                                                    PlayObject.m_dwSearchTick = GetTickCount();
                                                    nCheck30 = 10;
                                                    PlayObject.SearchViewRange();
                                                    // 搜索对像
                                                    nCheck30 = 11;
                                                    PlayObject.GameTimeChanged();
                                                // 游戏时间改变
                                                }
                                            }
                                            
                                            if ((GetTickCount() - PlayObject.m_dwShowLineNoticeTick) > M2Share.g_Config.dwShowLineNoticeTime)
                                            {
                                                PlayObject.m_dwShowLineNoticeTick = GetTickCount();
                                                if (M2Share.LineNoticeList.Count > PlayObject.m_nShowLineNoticeIdx)
                                                {
                                                    LineNoticeMsg = M2Share.g_ManageNPC.GetLineVariableText(PlayObject, M2Share.LineNoticeList[PlayObject.m_nShowLineNoticeIdx]);
                                                    nCheck30 = 13;
                                                    switch(LineNoticeMsg[1])
                                                    {
                                                        case 'R':
                                                            PlayObject.SysMsg(LineNoticeMsg.Substring(2 - 1 ,LineNoticeMsg.Length - 1), TMsgColor.c_Red, TMsgType.t_Notice);
                                                            break;
                                                        case 'G':
                                                            PlayObject.SysMsg(LineNoticeMsg.Substring(2 - 1 ,LineNoticeMsg.Length - 1), TMsgColor.c_Green, TMsgType.t_Notice);
                                                            break;
                                                        case 'B':
                                                            PlayObject.SysMsg(LineNoticeMsg.Substring(2 - 1 ,LineNoticeMsg.Length - 1), TMsgColor.c_Blue, TMsgType.t_Notice);
                                                            break;
                                                        default:
                                                            PlayObject.SysMsg(LineNoticeMsg, ((TMsgColor)(M2Share.g_Config.nLineNoticeColor)), TMsgType.t_Notice);
                                                            break;
                                                    }
                                                }
                                                PlayObject.m_nShowLineNoticeIdx ++;
                                                if ((M2Share.LineNoticeList.Count <= PlayObject.m_nShowLineNoticeIdx))
                                                {
                                                    PlayObject.m_nShowLineNoticeIdx = 0;
                                                }
                                            }
                                            nCheck30 = 14;
                                            PlayObject.Run();
                                            nCheck30 = 15;
                                            
                                            if (!M2Share.FrontEngine.IsFull() && ((GetTickCount() - PlayObject.m_dwSaveRcdTick) > M2Share.g_Config.dwSaveHumanRcdTime))
                                            {
                                                nCheck30 = 16;

                                                PlayObject.m_dwSaveRcdTick = GetTickCount();
                                                nCheck30 = 17;
                                                PlayObject.DealCancelA();
                                                nCheck30 = 18;
                                                SaveHumanRcd(PlayObject);

                                                nCheck30 = 19;
                                                SaveHeroRcd(PlayObject);
                                            // 保存英雄数据

                                            }
                                        }
                                        catch(Exception E) {
                                            M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans Human.Operate Code:" + (nCheck30).ToString() + " Name:" + PlayObject.m_sCharName);
                                            PlayObject.KickException();
                                        // 踢除异常 20090103
                                        }
                                    }
                                }
                                else
                                {
                                    // if not PlayObject.m_boGhost then begin
                                    try {
                                        m_PlayObjectList.RemoveAt(nIdx);
                                        nCheck30 = 2;
                                        PlayObject.Disappear();
                                        nCheck30 = 3;
                                    }
                                    catch(Exception E) {
                                        M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans Human.Finalize Code:" + (nCheck30).ToString());
                                    }
                                    try {
                                        nCheck30 = 4;
                                        PlayObject.DealCancelA();
                                        nCheck30 = 5;
                                        SaveHumanRcd(PlayObject);

                                        nCheck30 = 6;
                                        SaveHeroRcd(PlayObject);
                                        // 保存英雄数据

                                        AddToHumanFreeList(PlayObject);
                                        // 20090106 换位置
                                        nCheck30 = 7;
                                        if ((!PlayObject.m_boReconnection))
                                        {
                                            // 20090102 非重新连接才关闭
                                            //M2Share.RunSocket.CloseUser(PlayObject.m_nGateIdx, PlayObject.m_nSocket);
                                        }
                                    }
                                    catch {
                                        M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans RunSocket.CloseUser Code:" + (nCheck30).ToString());
                                    }
                                    SendServerGroupMsg(Grobal2.SS_202, M2Share.nServerIndex, PlayObject.m_sCharName);
                                    continue;
                                }
                            }
                            // if (dwTime14 - PlayObject.dw368) > PlayObject.dw36C then begin
                            nIdx ++;
                            
                            if ((GetTickCount() - dwCheckTime) > M2Share.g_dwHumLimit)
                            {
                                boCheckTimeLimit = true;
                                m_nProcHumIDx = nIdx;
                                break;
                            }
                        }
                    // while True do begin
                    }
                    if (!boCheckTimeLimit)
                    {
                        m_nProcHumIDx = 0;
                    }
                }
                catch {
                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessHumans");
                }
                // Inc(nProcessHumanLoopTime);//20080815 注释
                // g_nProcessHumanLoopTime := nProcessHumanLoopTime;//20080815 注释
                M2Share.g_nProcessHumanLoopTime ++;
                // 20080815
                if (m_nProcHumIDx == 0)
                {
                    // nProcessHumanLoopTime := 0;//20080815 注释
                    // g_nProcessHumanLoopTime := nProcessHumanLoopTime; //20080815 注释
                    M2Share.g_nProcessHumanLoopTime = 0;
                    // 20080815

                    dwUsrRotTime = GetTickCount() - M2Share.g_dwUsrRotCountTick;
                    M2Share.dwUsrRotCountMin = (int)dwUsrRotTime;

                    M2Share.g_dwUsrRotCountTick = GetTickCount();
                    if (M2Share.dwUsrRotCountMax < dwUsrRotTime)
                    {
                        M2Share.dwUsrRotCountMax = (int)dwUsrRotTime;
                    }
                }
                M2Share.g_nHumCountMin = Convert.ToInt32(GetTickCount() - dwCheckTime);
                if (M2Share.g_nHumCountMax < M2Share.g_nHumCountMin)
                {
                    M2Share.g_nHumCountMax = M2Share.g_nHumCountMin;
                }
            } finally {
                //Units.UsrEngn.m_boHumProcess = false;
            // 20080717 检查过程是否重入
            }
        }

        private void ProcessMerchants()
        {
            uint dwRunTick;
            uint dwCurrTick;
            int I;
            TMerchant MerchantNPC;
            bool boProcessLimit;
            dwRunTick = GetTickCount();
            boProcessLimit = false;
            try {

                dwCurrTick = GetTickCount();
                //m_MerchantList.__Lock();
                try {
                    I = nMerchantPosition;
                    while (true)
                    {
                        // for i := nMerchantPosition to m_MerchantList.Count - 1 do begin
                        if (m_MerchantList.Count <= I)
                        {
                            break;
                        }
                        MerchantNPC = m_MerchantList[I];
                        if (MerchantNPC != null)
                        {
                            if (!MerchantNPC.m_boGhost)
                            {
                                if (((int)dwCurrTick - MerchantNPC.m_dwRunTick) > MerchantNPC.m_nRunTime)
                                {
                                    
                                    if ((GetTickCount() - MerchantNPC.m_dwSearchTick) > MerchantNPC.m_dwSearchTime)
                                    {

                                        MerchantNPC.m_dwSearchTick = GetTickCount();
                                        MerchantNPC.SearchViewRange();
                                    }
                                    if (((int)dwCurrTick - MerchantNPC.m_dwRunTick) > MerchantNPC.m_nRunTime)
                                    {
                                        MerchantNPC.m_dwRunTick = dwCurrTick;
                                        MerchantNPC.Run();
                                    }
                                }
                            }
                            else
                            {
                                
                                // 60 * 1000
                                if ((GetTickCount() - MerchantNPC.m_dwGhostTick) > 60000)
                                {
                                    Dispose(MerchantNPC);
                                    m_MerchantList.RemoveAt(I);
                                    break;
                                }
                            }
                        }
                        
                        if ((GetTickCount() - dwRunTick) > M2Share.g_dwNpcLimit)
                        {
                            nMerchantPosition = I;
                            boProcessLimit = true;
                            break;
                        }
                        I ++;
                    }
                } finally {
                    //m_MerchantList.UnLock();
                }
                if (!boProcessLimit)
                {
                    nMerchantPosition = 0;
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine::ProcessMerchants");
            }

            dwProcessMerchantTimeMin = Convert.ToInt32(GetTickCount() - dwRunTick);
            if (dwProcessMerchantTimeMin > dwProcessMerchantTimeMax)
            {
                dwProcessMerchantTimeMax = dwProcessMerchantTimeMin;
            }
            if (dwProcessNpcTimeMin > dwProcessNpcTimeMax)
            {
                dwProcessNpcTimeMax = dwProcessNpcTimeMin;
            }
        }

        // function GetMonRaceImg(sMonName: string): Integer;//20080313 取怪的图
        public bool InsMonstersList(TMonGenInfo MonGen, TAnimalObject Monster)
        {
            bool result;
            int I;
            int II;
            TMonGenInfo MonGenInfo;
            result = false;
            if (m_MonGenList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_MonGenList.Count; I ++ )
                {
                    MonGenInfo = m_MonGenList[I];
                    if ((MonGenInfo != null) && (MonGenInfo.CertList != null) && (MonGen != null) && (MonGen == MonGenInfo))
                    {
                        if (MonGenInfo.CertList.Count > 0)
                        {
                            for (II = 0; II < MonGenInfo.CertList.Count; II ++ )
                            {
                                if ((Monster != null) && (((TBaseObject)(MonGenInfo.CertList[II])) == Monster))
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 清除怪物
        public bool ClearMonsters(string sMapName)
        {
            bool result;
            int I;
            int II;
            // MonGenInfo: pTMonGenInfo;
            // Monster: TAnimalObject;
            ArrayList MonList;
            TEnvirnoment Envir;
            TBaseObject BaseObject;
            result = false;
            MonList = new ArrayList();
            try {
                if (M2Share.g_MapManager.m_MapList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < M2Share.g_MapManager.m_MapList.Count; I++)
                    {
                        Envir = M2Share.g_MapManager.m_MapList[I];
                        if ((Envir != null) && (((Envir.sMapName).ToLower().CompareTo((sMapName).ToLower()) == 0)))
                        {
                            M2Share.UserEngine.GetMapMonster(Envir, MonList);
                            if (MonList.Count > 0)
                            {
                                // 20081008
                                for (II = 0; II < MonList.Count; II ++ )
                                {
                                    BaseObject = ((TBaseObject)(MonList[II]));
                                    if (BaseObject != null)
                                    {
                                        if ((BaseObject.m_btRaceServer != 110) && (BaseObject.m_btRaceServer != 111) && (BaseObject.m_btRaceServer != Grobal2.RC_GUARD) && (BaseObject.m_btRaceServer != Grobal2.RC_ARCHERGUARD) && (BaseObject.m_btRaceServer != 55))
                                        {
                                            BaseObject.m_boNoItem = true;
                                            BaseObject.m_WAbil.HP = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                // for
                }
            } finally {
                Dispose(MonList);
            }
            result = true;
            return result;
        }

        public uint ProcessMonsters_GetZenTime(uint dwTime)
        {
            uint result;
            double d10;
            // 30 * 60 * 1000
            if (dwTime < 1800000)
            {
                // 1000
                // 300
                d10 = (PlayObjectCount - M2Share.g_Config.nUserFull) / M2Share.g_Config.nZenFastStep;
                if (d10 > 0)
                {
                    if (d10 > 6)
                    {
                        d10 = 6;
                    }
                    result = dwTime - (uint)Math.Round((dwTime / 10) * d10);
                }
                else
                {
                    result = dwTime;
                }
            }
            else
            {
                result = dwTime;
            }
            return result;
        }

        // 怪物过程
        private void ProcessMonsters()
        {
            uint dwCurrentTick;
            uint dwRunTick;
            uint dwMonProcTick;
            TMonGenInfo MonGen;
            int nGenCount;
            int nGenModCount;
            bool boProcessLimit;
            bool boRegened;
            int I = 0;
            int nProcessPosition;
            TAnimalObject Monster = null;
            int tCode;
            int nMakeMonsterCount;
            bool boCanCreate;
            // 20080525
            // nActiveMonsterCount: Integer;
            // nActiveHumCount: Integer;
            // MapMonGenCount: pTMapMonGenCount;
            tCode = 0;
            dwRunTick = GetTickCount();
            try
            {
                tCode = 1;
                boProcessLimit = false;
                dwCurrentTick = GetTickCount();
                MonGen = null;
                // 刷新怪物开始,判断是否超过刷怪的间隔
                if (((GetTickCount() - dwRegenMonstersTick) > M2Share.g_Config.dwRegenMonstersTime))
                {
                    tCode = 2;
                    dwRegenMonstersTick = GetTickCount();
                    if (m_nCurrMonGen < m_MonGenList.Count)
                    {
                        tCode = 25;
                        MonGen = m_MonGenList[m_nCurrMonGen];
                        // 取得当前刷怪的索引
                        tCode = 26;
                        if (MonGen != null)
                        {
                            // 20081222
                            tCode = 27;
                            if (MonGen.nCurrMonGen == 0)
                            {
                                MonGen.nCurrMonGen = m_nCurrMonGen;
                            }
                            // 刷怪索引 20080830
                        }
                    }
                    tCode = 3;
                    if (m_nCurrMonGen < m_MonGenList.Count - 1)
                    {
                        m_nCurrMonGen++;
                    }
                    else
                    {
                        m_nCurrMonGen = 0;
                    }
                    tCode = 4;
                    if ((MonGen != null))
                    {
                        if ((MonGen.sMonName != "") && (!M2Share.g_Config.boVentureServer))
                        {

                            if ((MonGen.dwStartTick == 0) || ((GetTickCount() - MonGen.dwStartTick) > ProcessMonsters_GetZenTime(MonGen.dwZenTime)))
                            {
                                tCode = 5;
                                nGenCount = GetGenMonCount(MonGen);
                                boRegened = true;
                                if (M2Share.g_Config.nMonGenRate <= 0)
                                {
                                    M2Share.g_Config.nMonGenRate = 10;
                                }
                                // 防止除法错误
                                nGenModCount = (int)HUtil32._MAX(1, (int)Math.Round((decimal)HUtil32._MAX(1, MonGen.nCount) / (M2Share.g_Config.nMonGenRate / 10)));
                                nMakeMonsterCount = nGenModCount - nGenCount;
                                if (nMakeMonsterCount < 0)
                                {
                                    nMakeMonsterCount = 0;
                                }
                                tCode = 6;
                                if (MonGen.Envir != null)
                                {
                                    // 20081005
                                    tCode = 7;
                                    if (MonGen.Envir.m_boNoManNoMon)
                                    {
                                        // 没人不刷怪 20080712
                                        if ((MonGen.Envir.HumCount > 0))
                                        {
                                            boCanCreate = true;
                                        }
                                        else
                                        {
                                            boCanCreate = false;
                                        }
                                    }
                                    else
                                    {
                                        boCanCreate = true;
                                    }
                                }
                                else
                                {
                                    boCanCreate = true;
                                }
                                // nGenModCount 需要刷怪数
                                // nGenCount 已经刷怪数}
                                // nMakeMonsterCount 当前需制造怪物的数量
                                // ===============================智能刷怪========================================
                                // (* if (MonGen.Envir <> nil) and boCanCreate then begin
                                // if (MonGen.nRace <> 110) and (MonGen.nRace <> 111) and (MonGen.nRace <> RC_GUARD) and
                                // (MonGen.nRace <> RC_ARCHERGUARD) and(MonGen.nRace <> 55) then begin
                                // 
                                // MapMonGenCount := GetMapMonGenCount(MonGen.sMapName);
                                // if MapMonGenCount <> nil then begin
                                // nActiveHumCount := GetMapHuman(MonGen.sMapName);
                                // nActiveMonsterCount := GetMapMonster(MonGen.Envir, nil);//地图怪物数量
                                // if (nActiveHumCount > 0) and (not MapMonGenCount.boNotHum) then begin
                                // MapMonGenCount.boNotHum := True;
                                // end else
                                // if (nActiveHumCount <= 0) and (MapMonGenCount.boNotHum) then begin
                                // MapMonGenCount.boNotHum := False;
                                // MapMonGenCount.dwNotHumTimeTick := GetTickCount();
                                // end;
                                // //如果地图无人,30分钟清怪
                                // if (GetTickCount() - MapMonGenCount.dwNotHumTimeTick > 1800000{1000 * 60 * 30}) and not MapMonGenCount.boNotHum then begin
                                // MapMonGenCount.dwNotHumTimeTick := GetTickCount();
                                // if nActiveMonsterCount > 0 then begin
                                // if ClearMonsters(MonGen.sMapName) then begin
                                // //MainOutMessage('智能清怪物:'+MonGen.sMonName+'  数量:'+inttostr(nActiveMonsterCount)+'  地图人物数量:'+inttostr(nActiveHumCount));
                                // Inc(MapMonGenCount.nClearCount);
                                // end;
                                // end;
                                // nMakeMonsterCount := 0;
                                // end;
                                // { //刷怪
                                // if MapMonGenCount.boNotHum then begin
                                // 
                                // end;   }
                                // end;
                                // end;
                                // end;  *)
                                tCode = 8;
                                if ((nMakeMonsterCount > 0) && boCanCreate)
                                {
                                    // 0806 增加 控制刷怪数量比例
                                    if ((M2Share.nErrorLevel == 0) && (M2Share.nCrackedLevel == 0))
                                    {
                                        boRegened = RegenMonsters(MonGen, nMakeMonsterCount);
                                        // 创建怪物对象 RegenMonsters()
                                    }
                                    // 60 * 60 * 10
                                    else if (M2Share.dwStartTime < 36000)
                                    {
                                        // 破解后在10小时以内正常刷怪
                                        boRegened = RegenMonsters(MonGen, nMakeMonsterCount);
                                    }
                                }
                                if (boRegened)
                                {
                                    MonGen.dwStartTick = HUtil32.GetTickCount();
                                }
                            }
                            M2Share.g_sMonGenInfo1 = MonGen.sMonName + "," + (m_nCurrMonGen).ToString() + "/" + (m_MonGenList.Count).ToString();
                        }
                    }
                }
                tCode = 9;

                M2Share.g_nMonGenTime = Convert.ToInt32(HUtil32.GetTickCount() - dwCurrentTick);
                if (M2Share.g_nMonGenTime > M2Share.g_nMonGenTimeMin)
                {
                    M2Share.g_nMonGenTimeMin = M2Share.g_nMonGenTime;
                }
                if (M2Share.g_nMonGenTime > M2Share.g_nMonGenTimeMax)
                {
                    M2Share.g_nMonGenTimeMax = M2Share.g_nMonGenTime;
                }
                // 刷新怪物结束
                dwMonProcTick = HUtil32.GetTickCount();
                nMonsterProcessCount = 0;
                tCode = 10;
                if (m_MonGenList.Count > 0)
                {
                    // 20080629
                    for (I = m_nMonGenListPosition; I < m_MonGenList.Count; I++)
                    {
                        tCode = 11;
                        MonGen = m_MonGenList[I];
                        if (m_nMonGenCertListPosition < MonGen.CertList.Count)
                        {
                            tCode = 12;
                            nProcessPosition = m_nMonGenCertListPosition;
                        }
                        else
                        {
                            nProcessPosition = 0;
                        }
                        m_nMonGenCertListPosition = 0;
                        while (true)
                        {
                            if (nProcessPosition >= MonGen.CertList.Count)
                            {
                                break;
                            }
                            tCode = 13;
                            Monster = (TAnimalObject)MonGen.CertList[nProcessPosition];
                            if (Monster != null)
                            {
                                tCode = 14;
                                if (!Monster.m_boGhost)
                                {
                                    tCode = 15;
                                    if (((int)dwCurrentTick - Monster.m_dwRunTick) > Monster.m_nRunTime)
                                    {
                                        tCode = 16;
                                        Monster.m_dwRunTick = dwRunTick;
                                        if ((dwCurrentTick - Monster.m_dwSearchTick) > Monster.m_dwSearchTime)
                                        {
                                            tCode = 17;
                                            Monster.m_dwSearchTick = HUtil32.GetTickCount();
                                            Monster.SearchViewRange();
                                            // 怪多,占CUP
                                        }
                                        if (!Monster.m_boIsVisibleActive && (Monster.m_nProcessRunCount < M2Share.g_Config.nProcessMonsterInterval))
                                        {
                                            Monster.m_nProcessRunCount++;
                                        }
                                        else
                                        {
                                            if (Monster != null)
                                            {
                                                // 20080526 增加
                                                Monster.m_nProcessRunCount = 0;
                                                tCode = 18;
                                                Monster.Run();
                                            }
                                        }
                                        nMonsterProcessCount++;
                                    }
                                    nMonsterProcessPostion++;
                                }
                                else
                                {
                                    // 5 * 60 * 1000
                                    if ((GetTickCount() - Monster.m_dwGhostTick) > 300000)
                                    {
                                        tCode = 19;
                                        MonGen.CertList.RemoveAt(nProcessPosition);
                                        tCode = 20;
                                        if (Monster != null)
                                        {
                                            Monster = null;
                                        }
                                        // 20081130
                                        // Monster.Free;
                                        tCode = 24;
                                        continue;
                                    }
                                }
                            }
                            nProcessPosition++;

                            if ((GetTickCount() - dwMonProcTick) > M2Share.g_dwMonLimit)
                            {
                                tCode = 21;
                                M2Share.g_sMonGenInfo2 = Monster.m_sCharName + "/" + (I).ToString() + "/" + (nProcessPosition).ToString();
                                tCode = 22;
                                boProcessLimit = true;
                                m_nMonGenCertListPosition = nProcessPosition;
                                break;
                            }
                        }
                        // while (True) do begin
                        if (boProcessLimit)
                        {
                            break;
                        }
                    }
                }
                tCode = 23;
                if (m_MonGenList.Count <= I)
                {
                    m_nMonGenListPosition = 0;
                    nMonsterCount = nMonsterProcessPostion;
                    nMonsterProcessPostion = 0;
                }
                if (!boProcessLimit)
                {
                    m_nMonGenListPosition = 0;
                }
                else
                {
                    m_nMonGenListPosition = I;
                }
                M2Share.g_nMonProcTime = Convert.ToInt32(HUtil32.GetTickCount() - dwMonProcTick);
                if (M2Share.g_nMonProcTime > M2Share.g_nMonProcTimeMin)
                {
                    M2Share.g_nMonProcTimeMin = M2Share.g_nMonProcTime;
                }
                if (M2Share.g_nMonProcTime > M2Share.g_nMonProcTimeMax)
                {
                    M2Share.g_nMonProcTimeMax = M2Share.g_nMonProcTime;
                }
            }
            catch (Exception E)
            {
                if (Monster != null)
                {
                    M2Share.MainOutMessage(string.Format("{异常} TUserEngine::ProcessMonsters %d %s", tCode, Monster.m_sCharName));
                    Monster.KickException();
                    // 踢除异常 20090103
                }
                else
                {
                    M2Share.MainOutMessage(string.Format("{异常} TUserEngine::ProcessMonsters %d %s", tCode, ""));
                }
            }
            M2Share.g_nMonTimeMin = Convert.ToInt32(GetTickCount() - dwRunTick);
            if (M2Share.g_nMonTimeMax < M2Share.g_nMonTimeMin)
            {
                M2Share.g_nMonTimeMax = M2Share.g_nMonTimeMin;
            }
        }

        // 创建怪物对像
        // procedure WriteShiftUserData;//未使用 20080522
        private int GetGenMonCount(TMonGenInfo MonGen)
        {
            int result;
            int I;
            int nCount;
            TBaseObject BaseObject;
            nCount = 0;
            if (MonGen.CertList.Count > 0)
            {
                for (I = 0; I < MonGen.CertList.Count; I ++ )
                {
                    BaseObject = ((TBaseObject)(MonGen.CertList[I]));
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath && !BaseObject.m_boGhost)
                        {
                            nCount ++;
                        }
                    }
                }
            }
            result = nCount;
            return result;
        }

        private void ProcessNpcs()
        {
            uint dwRunTick;
            uint dwCurrTick;
            int I;
            TNormNpc NPC;
            bool boProcessLimit;
            dwRunTick = HUtil32.GetTickCount();
            boProcessLimit = false;
            try {
                dwCurrTick = HUtil32.GetTickCount();
                for (I = nNpcPosition; I < QuestNPCList.Count; I ++ )
                {
                    NPC = QuestNPCList[I];
                    if (NPC != null)
                    {
                        if (!NPC.m_boGhost)
                        {
                            if (((int)dwCurrTick - NPC.m_dwRunTick) > NPC.m_nRunTime)
                            {
                                if ((GetTickCount() - NPC.m_dwSearchTick) > NPC.m_dwSearchTime)
                                {
                                    NPC.m_dwSearchTick = HUtil32.GetTickCount();
                                    NPC.SearchViewRange();
                                }
                                if (((int)dwCurrTick - NPC.m_dwRunTick) > NPC.m_nRunTime)
                                {
                                    NPC.m_dwRunTick = dwCurrTick;
                                    NPC.Run();
                                }
                            }
                        }
                        else
                        {
                            
                            // 60 * 1000
                            if ((GetTickCount() - NPC.m_dwGhostTick) > 60000)
                            {
                                //NPC.Free;
                                QuestNPCList.RemoveAt(I);
                                break;
                            }
                        }
                    }
                    if ((GetTickCount() - dwRunTick) > M2Share.g_dwNpcLimit)
                    {
                        nNpcPosition = I;
                        boProcessLimit = true;
                        break;
                    }
                }
                // for
                if (!boProcessLimit)
                {
                    nNpcPosition = 0;
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.ProcessNpcs");
            }
            dwProcessNpcTimeMin = HUtil32.GetTickCount() - dwRunTick;
            if (dwProcessNpcTimeMin > dwProcessNpcTimeMax)
            {
                dwProcessNpcTimeMax = dwProcessNpcTimeMin;
            }
        }

        public TBaseObject RegenMonsterByName(string sMAP, int nX, int nY, string sMonName)
        {
            TBaseObject result;
            int nRace;
            TBaseObject BaseObject;
            int n18;
            TMonGenInfo MonGen;
            nRace = GetMonRace(sMonName);
            BaseObject = AddBaseObject(sMAP, nX, nY, nRace, sMonName);
            if (BaseObject != null)
            {
                n18 = m_MonGenList.Count - 1;
                if (n18 < 0)
                {
                    n18 = 0;
                }
                MonGen = m_MonGenList[n18];
                if (MonGen != null)
                {
                    MonGen.CertList.Add(BaseObject);
                    BaseObject.AddMapCount();
                    //BaseObject.m_boAddToMaped = true;
                }
            }
            result = BaseObject;
            return result;
        }

        public TBaseObject RegenPlayByName(TPlayObject PlayObject, int nX, int nY, string sMonName)
        {
            TBaseObject result;
            TBaseObject BaseObject;
            int n18;
            TMonGenInfo MonGen;
            BaseObject = AddPlayObject(PlayObject, nX, nY, sMonName);
            if (BaseObject != null)
            {
                n18 = m_MonGenList.Count - 1;
                if (n18 < 0)
                {
                    n18 = 0;
                }
                MonGen = m_MonGenList[n18];
                MonGen.CertList.Add(BaseObject);
                BaseObject.AddMapCount();
                //BaseObject.m_boAddToMaped = true;
            }
            result = BaseObject;
            return result;
        }

        public void AddObjectToMonList(TBaseObject BaseObject)
        {
            int n18;
            TMonGenInfo MonGen;
            n18 = m_MonGenList.Count - 1;
            if (n18 < 0)
            {
                n18 = 0;
            }
            MonGen = m_MonGenList[n18];
            MonGen.CertList.Add(BaseObject);
            BaseObject.AddMapCount();
            //BaseObject.m_boAddToMaped = true;
        }

        public TBaseObject RegenMyHero(TPlayObject PlayObject, int nX, int nY, THumDataInfo HumanRcd)
        {
            TBaseObject result;
            TBaseObject BaseObject;
            int n18;
            TMonGenInfo MonGen;
            BaseObject = AddHeroObject(PlayObject, nX, nY, HumanRcd);
            if (BaseObject != null)
            {
                n18 = m_MonGenList.Count - 1;
                if (n18 < 0)
                {
                    n18 = 0;
                }
                MonGen = m_MonGenList[n18];
                MonGen.CertList.Add(BaseObject);
                BaseObject.AddMapCount();
                //BaseObject.m_boAddToMaped = true;
            }
            result = BaseObject;
            return result;
        }

        public void Run_ShowOnlineCount()
        {
            // 取在线人数
            int nOnlineCount;
            int nOnlineCount2;
            int nAutoAddExpPlayCount;
            nOnlineCount = PlayObjectCount;
            nAutoAddExpPlayCount = AutoAddExpPlayCount;
            // 挂机人物
            nOnlineCount2 = nOnlineCount - nAutoAddExpPlayCount;
            // 真正在线人数
            
            M2Share.MainOutMessage(string.Format("在线数: %d (%d/%d)", new int[] {nOnlineCount, nOnlineCount2, nAutoAddExpPlayCount}));
        }

        public void Run()
        {
            try {
                if ((GetTickCount() - dwShowOnlineTick) > M2Share.g_Config.dwConsoleShowUserCountTime)
                {
                    dwShowOnlineTick = HUtil32.GetTickCount();
                    // NoticeManager.LoadingNotice;//读取公告  20080815 注释 移动到程序启动时加载
                    Run_ShowOnlineCount();
                    // 取在线人数
                    // MainOutMessage('在线数: ' + IntToStr(GetUserCount));//20080815 修改
                    M2Share.g_CastleManager.Save();
                }
                // 10000
                if ((GetTickCount() - dwSendOnlineHumTime) > 15000)
                {
                    dwSendOnlineHumTime = HUtil32.GetTickCount();
                    //IdSrvClient.Units.IdSrvClient.FrmIDSoc.SendOnlineHumCountMsg(OnlinePlayObject);
                }
            }
            catch(Exception E) {
                M2Share.MainOutMessage("{异常} TUserEngine::Run");
            }
        }

        public TStdItem GetStdItem(int nItemIdx)
        {
            TStdItem result;
            result = null;
            nItemIdx -= 1;
            if ((nItemIdx >= 0) && (StdItemList.Count > nItemIdx))
            {
                result = StdItemList[nItemIdx];
                if (result.Name == "")
                {
                    result = null;
                }
            }
            return result;
        }

        public TStdItem GetStdItem(string sItemName)
        {
            TStdItem result;
            int I;
            TStdItem StdItem;
            result = null;
            if (sItemName == "")
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                // 20081008
                for (I = 0; I < StdItemList.Count; I ++ )
                {
                    StdItem = StdItemList[I];
                    if (StdItem != null)
                    {
                        // 20090128
                        if ((StdItem.Name).ToLower().CompareTo((sItemName).ToLower()) == 0)
                        {
                            result = StdItem;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // (酿酒)通过材料Anicount得到对应酒的函数  20080620
        public TStdItem GetMakeWineStdItem(int Anicount)
        {
            TStdItem result;
            int I;
            TStdItem StdItem;
            result = null;
            if (Anicount < 0)
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                for (I = 0; I < StdItemList.Count; I ++ )
                {
                    StdItem = StdItemList[I];
                    if (StdItem != null)
                    {
                        // 20090128
                        if ((StdItem.Shape == Anicount) && (StdItem.StdMode == 60))
                        {
                            result = StdItem;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // (酿酒)通过材料Anicount得到对应酒的函数  20080620
        // 通过酒Shape得到对应酒曲的函数  20080621
        public TStdItem GetMakeWineStdItem1(int Shape)
        {
            TStdItem result;
            int I;
            TStdItem StdItem;
            result = null;
            if (Shape < 0)
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                for (I = 0; I < StdItemList.Count; I ++ )
                {
                    StdItem = StdItemList[I];
                    if (StdItem != null)
                    {
                        // 20090128
                        if ((StdItem.Shape == Shape) && (StdItem.StdMode == 13))
                        {
                            result = StdItem;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // (酿酒)通过酒Shape得到对应酒曲的函数  20080621
        // 通过索引取物品重量
        public int GetStdItemWeight(int nItemIdx)
        {
            int result = 0;
            TStdItem StdItem;
            nItemIdx -= 1;
            if ((nItemIdx >= 0) && (StdItemList.Count > nItemIdx))
            {
                StdItem = StdItemList[nItemIdx];
                if (StdItem != null)
                {
                    // 20090128
                    result = StdItem.Weight;
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }

        // 通过索引取物品名字
        public string GetStdItemName(int nItemIdx)
        {
            string result;
            result = "";
            nItemIdx -= 1;
            if ((nItemIdx >= 0) && (StdItemList.Count > nItemIdx))
            {
                result = ((TStdItem)(StdItemList[nItemIdx])).Name;
            }
            else
            {
                result = "";
            }
            return result;
        }

        // 查找其它服务器上的角色 暂时无效
        public bool FindOtherServerUser(string sName, ref int nServerIndex)
        {
            bool result;
            result = false;
            return result;
        }

        // 黄字喊话
        public void CryCry(ushort wIdent, TEnvirnoment pMap, int nX, int nY, int nWide, byte btFColor, byte btBColor, string sMsg)
        {
            int I;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    PlayObject = m_PlayObjectList[I];
                    // 允许群组聊天
                    // 20080211  拒绝接收喊话信息
                    if (!PlayObject.m_boGhost && (PlayObject.m_PEnvir == pMap) && (PlayObject.m_boBanShout) && (PlayObject.m_boBanGmMsg) && (Math.Abs(PlayObject.m_nCurrX - nX) < nWide) && (Math.Abs(PlayObject.m_nCurrY - nY) < nWide))
                    {
                        // PlayObject.SendMsg(nil,wIdent,0,0,$FFFF,0,sMsg);
                        PlayObject.SendMsg(PlayObject, wIdent, 0, btFColor, btBColor, 0, sMsg);
                    }
                }
            }
        }

        // 获取怪物爆率物品  20080523
        private int MonGetRandomItems(TBaseObject mon)
        {
            int result = 0;
            int I;
            IList<TMonItemInfo> ItemList = null;
            string iname;
            TMonItemInfo MonItem;
            TUserItem UserItem;
            TMonInfo Monster;
            TStdItem StdItem;
            byte nCode;
            // 20090113
            nCode = 0;
            try {
                if (mon == null)
                {
                    return result;
                }
                // 20090113
                nCode = 1;
                if (MonsterList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < MonsterList.Count; I ++ )
                    {
                        Monster = MonsterList[I];
                        nCode = 2;
                        if (Monster != null)
                        {
                            // 20090113
                            if ((Monster.sName).ToLower().CompareTo((mon.m_sCharName).ToLower()) == 0)
                            {
                                ItemList = new List<TMonItemInfo>();
                                if (Monster.ItemList != null)
                                {
                                    foreach (var item in Monster.ItemList)
                                    {
                                        ItemList.Add(new TMonItemInfo() { SelPoint = item.n00, MaxPoint = item.n04, ItemName = item.sMonName, Count = item.n18 });
                                    }
                                    //ItemList = Monster.ItemList;
                                    break;
                                }
                            }
                        }
                    }
                }
                nCode = 3;
                if (ItemList != null)
                {
                    if (ItemList.Count > 0)
                    {
                        // 20080627
                        for (I = 0; I < ItemList.Count; I ++ )
                        {
                            MonItem = ((TMonItemInfo)(ItemList[I]));
                            nCode = 4;
                            if (MonItem != null)
                            {
                                // 20090113
                                if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)
                                {
                                    // 计算机率 1/10 随机10<=1 即为所得的物品
                                    nCode = 5;
                                    if ((MonItem.ItemName).ToLower().CompareTo((M2Share.sSTRING_GOLDNAME).ToLower()) == 0)
                                    {
                                        // 如果是金币
                                        mon.m_nGold = mon.m_nGold + (MonItem.Count / 2) + HUtil32.Random(MonItem.Count);
                                    }
                                    else
                                    {
                                        iname = "";
                                        if (iname == "")
                                        {
                                            iname = MonItem.ItemName;
                                        }
                                        nCode = 6;
                                        UserItem = new TUserItem();
                                        if (CopyToUserItemFromName(iname, UserItem))
                                        {
                                            UserItem.Dura = (ushort)Math.Round((decimal)(UserItem.DuraMax / 100) * (20 + HUtil32.Random(80)));
                                            if (HUtil32.Random(M2Share.g_Config.nMonRandomAddValue) == 0)
                                            {
                                                RandomUpgradeItem(UserItem);
                                            }
                                            StdItem = M2Share.UserEngine.GetStdItem(UserItem.wIndex);
                                            if (StdItem != null)
                                            {
                                                switch(StdItem.StdMode)
                                                {
                                                    case 2:
                                                        if (StdItem.AniCount == 21)
                                                        {
                                                            UserItem.Dura = 0;
                                                        }
                                                        break;
                                                    case 8:
                                                        // 是魔令包和祝福罐,则把当前持久设置为0
                                                        switch(StdItem.Source)
                                                        {
                                                            case 0:
                                                                // 是酿酒材料 20080702
                                                                UserItem.btValue[0] = Convert.ToByte(HUtil32.Random(3) + 1);
                                                                break;
                                                            case 1:
                                                                // 随机给材料的品质
                                                                UserItem.btValue[0] = Convert.ToByte(HUtil32.Random(3) + 5);
                                                                break;
                                                        }
                                                        break;
                                                    case 51:
                                                        if ((StdItem.Shape == 0))
                                                        {
                                                            UserItem.Dura = 0;
                                                        }
                                                        break;
                                                // 聚灵珠则清空当前持久 20081108
                                                }
                                            // case
                                            }
                                            nCode = 7;
                                            mon.m_ItemList.Add(UserItem);
                                        }
                                        else
                                        {
                                            Dispose(UserItem);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                result = 1;
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.MonGetRandomItems Code:" + (nCode).ToString());
            }
            return result;
        }

        // 随机升级物品(极品属性)
        public void RandomUpgradeItem(TUserItem Item)
        {
            TStdItem StdItem;
            StdItem = GetStdItem(Item.wIndex);
            if (StdItem == null)
            {
                return;
            }
            switch(StdItem.StdMode)
            {
                case 5:
                case 6:
                    M2Share.ItemUnit.RandomUpgradeWeapon(Item);
                    break;
                case 10:
                case 11:
                    // 武器
                    M2Share.ItemUnit.RandomUpgradeDress(Item);
                    break;
                case 19:
                    // 衣服
                    M2Share.ItemUnit.RandomUpgrade19(Item);
                    break;
                case 20:
                case 21:
                case 24:
                    // 项链(幸运型)
                    M2Share.ItemUnit.RandomUpgrade202124(Item);
                    break;
                case 26:
                    // 项链(准确敏捷型、体力魔法恢复型)、手镯(特别型)
                    M2Share.ItemUnit.RandomUpgrade26(Item);
                    break;
                case 22:
                    // 手套手镯
                    M2Share.ItemUnit.RandomUpgrade22(Item);
                    break;
                case 23:
                    // 戒指
                    M2Share.ItemUnit.RandomUpgrade23(Item);
                    break;
                case 15:
                case 16:
                    // 戒指(特别型)
                    M2Share.ItemUnit.RandomUpgradeHelMet(Item);
                    break;
                case 52:
                case 54:
                case 62:
                case 64:
                    // 头盔,斗笠
                    M2Share.ItemUnit.RandomUpgradeBoots(Item);
                    break;
            // 20080503 鞋子，腰带
            }
        }

        // 随机升级物品
        public void GetUnknowItemValue(TUserItem Item)
        {
            TStdItem StdItem;
            StdItem = GetStdItem(Item.wIndex);
            if (StdItem == null)
            {
                return;
            }
            switch(StdItem.StdMode)
            {
                case 15:
                case 16:
                    M2Share.ItemUnit.UnknowHelmet(Item);
                    break;
                case 22:
                case 23:
                    // 神秘头盔,斗笠
                    M2Share.ItemUnit.UnknowRing(Item);
                    break;
                case 24:
                case 26:
                    // 神秘戒指
                    M2Share.ItemUnit.UnknowNecklace(Item);
                    break;
            // 神秘手套手镯
            }
        }

        // function InMerchantList(Merchant: TMerchant): Boolean;//是否是交易NPC,未使用 20080406
        // function InQuestNPCList(NPC: TNormNpc): Boolean;//未使用的函数  20080422
        public bool CopyToUserItemFromName(string sItemName, TUserItem Item)
        {
            bool result;
            int I;
            TStdItem StdItem;
            result = false;
            try {
                if (sItemName != "")
                {
                    if (StdItemList.Count > 0)
                    {
                        // 20081008
                        for (I = 0; I < StdItemList.Count; I ++ )
                        {
                            // StdItem := StdItemList.Items[I];
                            StdItem = ((TStdItem)(StdItemList[I]));
                            // 20080725
                            if (StdItem != null)
                            {
                                // 20080725
                                if ((StdItem.Name).ToLower().CompareTo((sItemName).ToLower()) == 0)
                                {
                                    //FillChar(Item, sizeof(TUserItem), '\0');
                                    // FillChar(Item^.btValue, SizeOf(Item^.btValue), 0);//20080812 增加
                                    Item.wIndex = Convert.ToUInt16(I + 1);
                                    Item.MakeIndex = M2Share.GetItemNumber();
                                    Item.Dura = StdItem.DuraMax;
                                    Item.DuraMax = StdItem.DuraMax;
                                    switch(StdItem.StdMode)
                                    {
                                        // 是魔令包和祝福罐,则把当前持久设置为0  20080305
                                        // Modify the A .. B: 15, 16, 19 .. 24, 26
                                        case 15:
                                        case 16:
                                        case 19:
                                        case 26:
                                            if ((StdItem.Shape == 130) || (StdItem.Shape == 131) || (StdItem.Shape == 132))
                                            {
                                                M2Share.UserEngine.GetUnknowItemValue(Item);
                                            }
                                            break;
                                        case 2:
                                            if (StdItem.AniCount == 21)
                                            {
                                                Item.Dura = 0;
                                            }
                                            break;
                                        case 51:
                                            // 是魔令包和祝福罐,则把当前持久设置为0
                                            // 20080221 聚灵珠
                                            if (StdItem.Shape == 0)
                                            {
                                                Item.Dura = 0;
                                            }
                                            break;
                                        case 60:
                                            // 是聚灵珠,则把当前持久设置为0
                                            // 酒类,除烧酒外 20080806
                                            if (StdItem.Shape != 0)
                                            {
                                                Item.btValue[1] = Convert.ToByte(HUtil32.Random(40) + 10);
                                                // 酒的酒精度
                                                Item.btValue[0] = Convert.ToByte(HUtil32.Random(8));
                                                // 酒的品质
                                                if (StdItem.AniCount == 2)
                                                {
                                                    Item.btValue[2] = Convert.ToByte(HUtil32.Random(4) + 1);
                                                }
                                            // 药力值 20081210
                                            }
                                            break;
                                    // 60
                                    }
                                    result = true;
                                    break;
                                }
                            }
                        }
                    // for
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.CopyToUserItemFromName");
            }
            return result;
        }

        public void ProcessUserMessage(TPlayObject PlayObject, TDefaultMessage DefMsg, string Buff)
        {
            // ,sTemp,sTemp1
            string sMsg;
            // NewBuff: array[0..DATA_BUFSIZE2 - 1] of Char;
            // sDefMsg: string;
            const string sExceptionMsg = "{异常} TUserEngine::ProcessUserMessage..";
            if ((DefMsg == null) || (PlayObject == null))
            {
                return;
            }
            try {
                if (Buff == null)
                {
                    sMsg = "";
                }
                else
                {
                    sMsg = Buff;
                }
                if (DefMsg.nSessionID != PlayObject.m_nSessionID)
                {
                    // 20081210 检查客户端会话ID是否正确, DefMsg.nSessionID客户端发来的值
                    return;
                }
                switch(DefMsg.Ident)
                {
                    case Grobal2.CM_SPELL:
                    case Grobal2.CM_USEBATTER:
                        // 以下处理每一种消息的取值方法 20091206 邱高奇
                        // 3017
                        // if PlayObject.GetSpellMsgCount <=2 then  //如果队排里有超过二个魔法操作，则不加入队排
                        if (M2Share.g_Config.boSpellSendUpdateMsg)
                        {
                            // 使用UpdateMsg 可以防止消息队列里有多个操作
                            PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, LoWord(DefMsg.Recog), HiWord(DefMsg.Recog), MakeLong(DefMsg.Param, DefMsg.Series), "");
                        }
                        else
                        {
                            PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, LoWord(DefMsg.Recog), HiWord(DefMsg.Recog), MakeLong(DefMsg.Param, DefMsg.Series), "");
                        }
                        break;
                    case Grobal2.CM_QUERYUSERNAME:
                    case Grobal2.CM_HEROATTACKTARGET:
                    case Grobal2.CM_HEROPROTECT:
                        // 80
                        // x
                        // y
                        PlayObject.SendMsg(PlayObject, DefMsg.Ident, 0, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, "");
                        break;
                    case Grobal2.CM_DROPITEM:
                    case Grobal2.CM_HERODROPITEM:
                    case Grobal2.CM_TAKEONITEM:
                    case Grobal2.CM_TAKEOFFITEM:
                    case Grobal2.CM_1005:
                    case Grobal2.CM_MERCHANTDLGSELECT:
                    case Grobal2.CM_PlAYDRINKDLGSELECT:
                    case Grobal2.CM_MERCHANTQUERYSELLPRICE:
                    case Grobal2.CM_USERSELLITEM:
                    case Grobal2.CM_USERBUYITEM:
                    case Grobal2.CM_USERGETDETAILITEM:
                    case Grobal2.CM_SENDSELLOFFITEM:
                    case Grobal2.CM_SENDSELLOFFITEMLIST:
                    case Grobal2.CM_SENDQUERYSELLOFFITEM:
                    case Grobal2.CM_SENDBUYSELLOFFITEM:
                    case Grobal2.CM_HEROTAKEONITEM:
                    case Grobal2.CM_HEROTAKEOFFITEM:
                    case Grobal2.CM_TAKEOFFITEMHEROBAG:
                    case Grobal2.CM_TAKEOFFITEMTOMASTERBAG:
                    case Grobal2.CM_SENDITEMTOMASTERBAG:
                    case Grobal2.CM_SENDITEMTOHEROBAG:
                    case Grobal2.CM_HEROTAKEONITEMFORMMASTERBAG:
                    case Grobal2.CM_TAKEONITEMFORMHEROBAG:
                    case Grobal2.CM_REPAIRFIRDRAGON:
                    case Grobal2.CM_REPAIRDRAGON:
                    case Grobal2.CM_REPAIRFINEITEM:
                    case Grobal2.CM_CREATEGROUP:
                    case Grobal2.CM_ADDGROUPMEMBER:
                    case Grobal2.CM_DELGROUPMEMBER:
                    case Grobal2.CM_USERREPAIRITEM:
                    case Grobal2.CM_MERCHANTQUERYREPAIRCOST:
                    case Grobal2.CM_DEALTRY:
                    case Grobal2.CM_DEALADDITEM:
                    case Grobal2.CM_DEALDELITEM:
                    case Grobal2.CM_CHALLENGETRY:
                    case Grobal2.CM_CHALLENGEADDITEM:
                    case Grobal2.CM_CHALLENGEDELITEM:
                    case Grobal2.CM_CHALLENGECANCEL:
                    case Grobal2.CM_CHALLENGECHGGOLD:
                    case Grobal2.CM_CHALLENGECHGDIAMOND:
                    case Grobal2.CM_CHALLENGEEND:
                    case Grobal2.CM_SELLOFFADDITEM:
                    case Grobal2.CM_SELLOFFDELITEM:
                    case Grobal2.CM_SELLOFFCANCEL:
                    case Grobal2.CM_SELLOFFEND:
                    case Grobal2.CM_CANCELSELLOFFITEMING:
                    case Grobal2.CM_SELLOFFBUYCANCEL:
                    case Grobal2.CM_SELLOFFBUY:
                    case Grobal2.CM_REFINEITEM:
                    case Grobal2.CM_USERSTORAGEITEM:
                    case Grobal2.CM_USERPLAYDRINKITEM:
                    case Grobal2.CM_USERTAKEBACKSTORAGEITEM:
                    case Grobal2.CM_USERMAKEDRUGITEM:
                    case Grobal2.CM_GUILDADDMEMBER:
                    case Grobal2.CM_GUILDDELMEMBER:
                    case Grobal2.CM_GUILDUPDATENOTICE:
                    case Grobal2.CM_OPENBOXS:
                    case Grobal2.CM_MOVEBOXS:
                    case Grobal2.CM_GETBOXS:
                    case Grobal2.CM_SELGETHERO:
                    case Grobal2.CM_PlAYDRINKGAME:
                    case Grobal2.CM_BEGINMAKEWINE:
                    case Grobal2.CM_CLICKSIGHICON:
                    case Grobal2.CM_CLICKCRYSTALEXPTOP:
                    case Grobal2.CM_DrinkUpdateValue:
                    case Grobal2.CM_USERPLAYDRINK:
                    case Grobal2.CM_GUILDUPDATERANKINFO:
                        // 拍卖
                        // 拍卖
                        // 拍卖
                        // 装备脱下到英雄包裹
                        // 装备脱下到主人包裹
                        // 主人包裹到英雄包裹
                        // 英雄包裹到主人包裹
                        // 从主人包裹穿装备到英雄包裹
                        // 从英雄包裹穿装备到主人包裹
                        // 接收客户发来的:修补火龙之心
                        // 修补祝福罐.魔令包 20080102
                        // 修补火云石
                        // 客户端点挑战 20080705
                        // 玩家把物品放到挑战框中
                        // 玩家从挑战框中取回物品
                        // 玩家取消挑战
                        // 客户端把金币放到挑战框中
                        // 客户端把金刚石放到挑战框中
                        // 挑战抵押物品结束
                        // 元宝寄售系统 客户端往出售物品窗口里加物品  20080316
                        // 客户端删除出售物品窗里的物品  20080316
                        // 客户端取消元宝寄售  20080316
                        // 客户端元宝寄售结束  20080316
                        // 取消正在寄售的物品 20080318(出售人)
                        // 取消寄售 物品购买 20080318(购买人)
                        // 确定购买寄售物品 20080318
                        // 客户端发送粹练物品 20080507
                        // 请酒框 20080515
                        // CM_WANTMINIMAP,
                        // CM_GUILDHOME,
                        // 转动宝箱
                        // 取得宝箱物品
                        // 取回英雄 20080514
                        // 猜拳码数
                        // 开始酿酒(即把材料全放上窗口) 20080620
                        // 点击感叹号
                        // 点击天地结晶获得经验 20090202
                        // 把消息数据传给ObjBase单元
                        //PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, EDcode.Units.EDcode.DeCodeString(sMsg));
                        break;
                    case Grobal2.CM_PASSWORD:
                    case Grobal2.CM_CHGPASSWORD:
                    case Grobal2.CM_SETPASSWORD:
                        //PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Param, DefMsg.Recog, DefMsg.Series, DefMsg.Tag, EDcode.Units.EDcode.DeCodeString(sMsg));
                        break;
                    case Grobal2.CM_ADJUST_BONUS:
                        // 1043
                        PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, sMsg);
                        break;
                    case Grobal2.CM_HORSERUN:
                    case Grobal2.CM_TURN:
                    case Grobal2.CM_WALK:
                    case Grobal2.CM_SITDOWN:
                    case Grobal2.CM_RUN:
                    case Grobal2.CM_HIT:
                    case Grobal2.CM_HEAVYHIT:
                    case Grobal2.CM_BIGHIT:
                    case Grobal2.CM_POWERHIT:
                    case Grobal2.CM_LONGHIT:
                    case Grobal2.CM_CRSHIT:
                    case Grobal2.CM_TWNHIT:
                    case Grobal2.CM_QTWINHIT:
                    case Grobal2.CM_CIDHIT:
                    case Grobal2.CM_WIDEHIT:
                    case Grobal2.CM_PHHIT:
                    case Grobal2.CM_DAILY:
                    case Grobal2.CM_FIREHIT:
                    case Grobal2.CM_4FIREHIT:
                    case Grobal2.CM_SANJUEHIT:
                    case Grobal2.CM_ZHUIXINHIT:
                    case Grobal2.CM_DUANYUEHIT:
                    case Grobal2.CM_HENGSAOHIT:
                    case Grobal2.CM_4LONGHIT:
                    case Grobal2.CM_YUANYUEHIT:
                    case Grobal2.CM_YTPDHIT:
                    case Grobal2.CM_XPYJHIT:
                        // 开天斩重击
                        // 开天斩轻击 20080212
                        // 龙影剑法
                        // 逐日剑法 20080511
                        // 烈火
                        // 4级烈火 20080112
                        // 倚天劈地 20091223 邱高奇
                        // 血魄一击 20100517 无忧居士
                        if (M2Share.g_Config.boActionSendActionMsg)
                        {
                            // 使用UpdateMsg 可以防止消息队列里有多个操作
                            // x
                            // y
                            PlayObject.SendActionMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, LoWord(DefMsg.Recog), HiWord(DefMsg.Recog), 0, "");
                        }
                        else
                        {
                            // x
                            // y
                            PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Tag, LoWord(DefMsg.Recog), HiWord(DefMsg.Recog), 0, "");
                        }
                        break;
                    case Grobal2.CM_SAY:
                        if (DefMsg.Recog > 0)
                        {
                            //PlayObject.m_btHearMsgFColor = LoByte(DefMsg.Param);
                            //PlayObject.m_btWhisperMsgFColor = HiByte(DefMsg.Param);
                        }
                        else
                        {
                            PlayObject.m_btHearMsgFColor = M2Share.g_Config.btHearMsgFColor;
                            PlayObject.m_btWhisperMsgFColor = M2Share.g_Config.btWhisperMsgFColor;
                        }
                        //PlayObject.SendMsg(PlayObject, Grobal2.CM_SAY, 0, 0, 0, 0, EDcode.Units.EDcode.DeCodeString(sMsg));
                        break;
                    case Grobal2.CM_QUERYUSERLEVELSORT:
                        PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, 0, DefMsg.Param, DefMsg.Tag, DefMsg.Recog, "");
                        break;
                    case Grobal2.CM_HEROGOTETHERUSESPELL:
                        PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, 0, 0, 0, 0, "");
                        break;
                    case Grobal2.CM_OPENSHOP:
                        PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, "");
                        break;
                    case Grobal2.CM_BUYSHOPITEMGIVE:
                    case Grobal2.CM_EXCHANGEGAMEGIRD:
                        // 赠送,灵符兑换 20080302
                        PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, sMsg);
                        break;
                    case Grobal2.CM_BUYSHOPITEM:
                        //PlayObject.SendUpdateMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, EDcode.Units.EDcode.DeCodeString(sMsg));
                        break;
                    default:
                        // if Assigned(zPlugOfEngine.ObjectClientMsg) then begin //20080813 注释
                        // zPlugOfEngine.ObjectClientMsg(PlayObject, DefMsg, Buff, @NewBuff);
                        // if @NewBuff = nil then sMsg := ''
                        // else sMsg := StrPas(@NewBuff);
                        // end;
                        PlayObject.SendMsg(PlayObject, DefMsg.Ident, DefMsg.Series, DefMsg.Recog, DefMsg.Param, DefMsg.Tag, sMsg);
                        break;
                }
                if (PlayObject.m_boReadyRun)
                {
                    switch(DefMsg.Ident)
                    {
                        case Grobal2.CM_TURN:
                        case Grobal2.CM_WALK:
                        case Grobal2.CM_SITDOWN:
                        case Grobal2.CM_RUN:
                        case Grobal2.CM_HIT:
                        case Grobal2.CM_HEAVYHIT:
                        case Grobal2.CM_BIGHIT:
                        case Grobal2.CM_POWERHIT:
                        case Grobal2.CM_LONGHIT:
                        case Grobal2.CM_WIDEHIT:
                        case Grobal2.CM_FIREHIT:
                        case Grobal2.CM_4FIREHIT:
                        case Grobal2.CM_CRSHIT:
                        case Grobal2.CM_DAILY:
                        case Grobal2.CM_PHHIT:
                        case Grobal2.CM_TWNHIT:
                        case Grobal2.CM_QTWINHIT:
                        case Grobal2.CM_CIDHIT:
                        case Grobal2.CM_4LONGHIT:
                        case Grobal2.CM_YUANYUEHIT:
                            // 半月
                            // 烈火
                            // 4级烈火
                            // 抱月刀
                            // 逐日剑法 20080511
                            // 破魂斩
                            // 开天斩重击
                            // 开天斩轻击 20080212
                            // 龙影剑法
                            PlayObject.m_dwRunTick -= 100;
                            break;
                    }
                }
            }
            catch {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        public void SendServerGroupMsg(int nCode, int nServerIdx, string sMsg)
        {
            if (M2Share.nServerIndex == 0)
            {
                //InterServerMsg.Units.InterServerMsg.FrmSrvMsg.SendSocketMsg((nCode).ToString() + "/" + EDcode.Units.EDcode.EncodeString((nServerIdx).ToString()) + "/" + EDcode.Units.EDcode.EncodeString(sMsg));
            }
            else
            {
                //InterMsgClient.Units.InterMsgClient.FrmMsgClient.SendSocket((nCode).ToString() + "/" + EDcode.Units.EDcode.EncodeString((nServerIdx).ToString()) + "/" + EDcode.Units.EDcode.EncodeString(sMsg));
            }
        }

        public TBaseObject AddHeroObject(TPlayObject PlayObject, int nX, int nY, THumDataInfo HumanRcd)
        {
            TBaseObject result;
            TEnvirnoment Map;
            THeroObject Cert;
            int n1C;
            int n20;
            int n24;
            object p28;
            result = null;
            // Cert := nil;//20080408 未使用
            Map = M2Share.g_MapManager.FindMap(PlayObject.m_sMapName);
            if (Map == null)
            {
                return result;
            }
            Cert = new THeroObject();
            if (Cert != null)
            {
                // MonInitialize(Cert, sMonName);
                GetHeroData(Cert, ref HumanRcd);
                // 取英雄的数据
                if (Cert.m_sHomeMap == "")
                {
                    // 第一次召唤
                    Cert.m_sHomeMap = PlayObject.m_sHomeMap;
                    Cert.m_nHomeX = PlayObject.m_nHomeX;
                    Cert.m_nHomeY = PlayObject.m_nHomeY;
                    switch(Cert.n_HeroTpye)
                    {
                        case 0:
                            Cert.m_Abil.Level = M2Share.g_Config.nHeroStartLevel;
                            break;
                        case 1:
                            Cert.m_Abil.Level = M2Share.g_Config.nDrinkHeroStartLevel;
                            break;
                    }
                    Cert.m_boNewHuman = true;
                }
                else
                {
                    Cert.m_sHomeMap = PlayObject.m_sHomeMap;
                    Cert.m_nHomeX = PlayObject.m_nHomeX;
                    Cert.m_nHomeY = PlayObject.m_nHomeY;
                    Cert.m_boNewHuman = false;
                }
                Cert.m_PEnvir = Map;
                Cert.m_sMapName = PlayObject.m_sMapName;
                Cert.m_nCurrX = nX;
                Cert.m_nCurrY = nY;
                Cert.m_btDirection = (byte)HUtil32.Random(8);
                if (Cert.m_Abil.Exp <= 0)
                {
                    Cert.m_Abil.Exp = 1;
                }
                if (Cert.m_Abil.MaxExp <= 0)
                {
                    Cert.m_Abil.MaxExp = Cert.GetLevelExp(Cert.m_Abil.Level);
                }
                Cert.GetBagItemCount();
                Cert.m_btRaceImg = PlayObject.m_btRaceImg;
                Cert.RecalcLevelAbilitys();
                Cert.RecalcAbilitys();
                if (HUtil32.Random(100) < Cert.m_btCoolEye)
                {
                    Cert.m_boCoolEye = true;
                }
                Cert.Initialize();
                if (Cert.m_boAddtoMapSuccess)
                {
                    p28 = null;
                    if (Cert.m_PEnvir.m_nWidth < 50)
                    {
                        n20 = 2;
                    }
                    else
                    {
                        n20 = 3;
                    }
                    if ((Cert.m_PEnvir.m_nHeight < 250))
                    {
                        if ((Cert.m_PEnvir.m_nHeight < 30))
                        {
                            n24 = 2;
                        }
                        else
                        {
                            n24 = 20;
                        }
                    }
                    else
                    {
                        n24 = 50;
                    }
                    n1C = 0;
                    while (true)
                    {
                        if (!Cert.m_PEnvir.CanWalk(Cert.m_nCurrX, Cert.m_nCurrY, false))
                        {
                            if ((Cert.m_PEnvir.m_nWidth - n24 - 1) > Cert.m_nCurrX)
                            {
                                Cert.m_nCurrX += n20;
                            }
                            else
                            {
                                Cert.m_nCurrX = HUtil32.Random(Cert.m_PEnvir.m_nWidth / 2) + n24;
                                if (Cert.m_PEnvir.m_nHeight - n24 - 1 > Cert.m_nCurrY)
                                {
                                    Cert.m_nCurrY += n20;
                                }
                                else
                                {
                                    Cert.m_nCurrY = HUtil32.Random(Cert.m_PEnvir.m_nHeight / 2) + n24;
                                }
                            }
                        }
                        else
                        {
                            p28 = Cert.m_PEnvir.AddToMap(Cert.m_nCurrX, Cert.m_nCurrY, Grobal2.OS_MOVINGOBJECT, Cert);
                            break;
                        }
                        n1C ++;
                        if (n1C >= 31)
                        {
                            break;
                        }
                    }
                    if (p28 == null)
                    {
                        Dispose(Cert);
                        //Cert.Free;
                        Cert = null;
                    }
                }
            }
            result = Cert;
            return result;
        }

        private TBaseObject AddPlayObject(TPlayObject PlayObject, int nX, int nY, string sMonName)
        {
            TBaseObject result;
            TEnvirnoment Map;
            TBaseObject Cert;
            int n1C;
            int n20;
            int n24;
            object p28;
            TUserItem UserItem;
            TUserMagic UserMagic;
            TUserMagic MonsterMagic;
            int I;
            TStdItem StdItem;
            result = null;
            // Cert := nil;//未使用 20080408
            Map = M2Share.g_MapManager.FindMap(PlayObject.m_sMapName);
            if (Map == null)
            {
                return result;
            }
            Cert = new TPlayMonster();
            if (Cert != null)
            {
                // MonInitialize(Cert, sMonName);
                Cert.m_PEnvir = Map;
                Cert.m_sMapName = PlayObject.m_sMapName;
                Cert.m_nCurrX = nX;
                Cert.m_nCurrY = nY;
                Cert.m_btDirection = (byte)HUtil32.Random(8);
                Cert.m_sCharName = sMonName;
                Cert.m_Abil = PlayObject.m_Abil;
                Cert.m_Abil.HP = Cert.m_Abil.MaxHP;
                Cert.m_Abil.MP = Cert.m_Abil.MaxMP;
                // TPlayMonster(Cert).GetAbility(PlayObject.m_Abil);
                // Cert.m_WAbil := Cert.m_Abil;// 20080418 注释
                Cert.m_WAbil = PlayObject.m_WAbil;
                // 20080418
                Cert.m_btJob = PlayObject.m_btJob;
                Cert.m_btGender = PlayObject.m_btGender;
                Cert.m_btHair = PlayObject.m_btHair;
                Cert.m_btRaceImg = PlayObject.m_btRaceImg;
                for (I = PlayObject.m_UseItems.GetLowerBound(0); I <= PlayObject.m_UseItems.GetUpperBound(0); I++)
                {
                    if (PlayObject.m_UseItems[I].wIndex > 0)
                    {
                        StdItem = M2Share.UserEngine.GetStdItem(PlayObject.m_UseItems[I].wIndex);
                        if (StdItem != null)
                        {
                            UserItem = new TUserItem();
                            if (M2Share.UserEngine.CopyToUserItemFromName(StdItem.Name, UserItem))
                            {
                                UserItem.btValue = PlayObject.m_UseItems[I].btValue;
                                // 20080418  让分身可以支持极品装备
                                UserItem.Dura = PlayObject.m_UseItems[I].Dura;
                                // 20090203 分身的装备持久与主体的一致
                                ((TPlayMonster)(Cert)).AddItems(UserItem, I);
                            }
                            else
                            {
                                
                                Dispose(UserItem);
                            }
                        // 20080820 修改
                        }
                    }
                }
                if (PlayObject.m_MagicList.Count > 0)
                {
                    // 20080629
                    for (I = 0; I < PlayObject.m_MagicList.Count; I ++ )
                    {
                        // 添加魔法
                        UserMagic = PlayObject.m_MagicList[I];
                        if (UserMagic != null)
                        {
                            MonsterMagic = new TUserMagic();
                            MonsterMagic.MagicInfo = UserMagic.MagicInfo;
                            MonsterMagic.wMagIdx = UserMagic.wMagIdx;
                            MonsterMagic.btLevel = UserMagic.btLevel;
                            MonsterMagic.btKey = UserMagic.btKey;
                            MonsterMagic.nTranPoint = UserMagic.nTranPoint;
                            Cert.m_MagicList.Add(MonsterMagic);
                        }
                    }
                }
                ((TPlayMonster)(Cert)).InitializeMonster();
                // 初始化
                Cert.RecalcAbilitys();
                if (HUtil32.Random(100) < Cert.m_btCoolEye)
                {
                    Cert.m_boCoolEye = true;
                }
                Cert.Initialize();
                if (Cert.m_boAddtoMapSuccess)
                {
                    p28 = null;
                    if (Cert.m_PEnvir.m_nWidth < 50)
                    {
                        n20 = 2;
                    }
                    else
                    {
                        n20 = 3;
                    }
                    if ((Cert.m_PEnvir.m_nHeight < 250))
                    {
                        if ((Cert.m_PEnvir.m_nHeight < 30))
                        {
                            n24 = 2;
                        }
                        else
                        {
                            n24 = 20;
                        }
                    }
                    else
                    {
                        n24 = 50;
                    }
                    n1C = 0;
                    while (true)
                    {
                        if (!Cert.m_PEnvir.CanWalk(Cert.m_nCurrX, Cert.m_nCurrY, false))
                        {
                            if ((Cert.m_PEnvir.m_nWidth - n24 - 1) > Cert.m_nCurrX)
                            {
                                Cert.m_nCurrX += n20;
                            }
                            else
                            {
                                Cert.m_nCurrX = HUtil32.Random(Cert.m_PEnvir.m_nWidth / 2) + n24;
                                if (Cert.m_PEnvir.m_nHeight - n24 - 1 > Cert.m_nCurrY)
                                {
                                    Cert.m_nCurrY += n20;
                                }
                                else
                                {
                                    Cert.m_nCurrY = HUtil32.Random(Cert.m_PEnvir.m_nHeight / 2) + n24;
                                }
                            }
                        }
                        else
                        {
                            p28 = Cert.m_PEnvir.AddToMap(Cert.m_nCurrX, Cert.m_nCurrY, Grobal2.OS_MOVINGOBJECT, Cert);
                            break;
                        }
                        n1C ++;
                        if (n1C >= 31)
                        {
                            break;
                        }
                    }
                    if (p28 == null)
                    {
                        Dispose(Cert);
                        //Cert.Free;
                        Cert = null;
                    }
                }
            }
            result = Cert;
            return result;
        }

        private TBaseObject AddBaseObject(string sMapName, int nX, int nY, int nMonRace, string sMonName)
        {
            TBaseObject result;
            // 004AD56C
            TEnvirnoment Map;
            TBaseObject Cert;
            int n1C;
            int n20;
            int n24;
            object p28;
            byte nCode;
            result = null;
            Cert = null;
            nCode = 0;
            try {
                Map = M2Share.g_MapManager.FindMap(sMapName);
                nCode = 1;
                if (Map == null)
                {
                    return result;
                }
                switch(nMonRace)
                {
                    case 11:
                        Cert = new TSuperGuard();
                        break;
                    case 20:
                        // 大刀卫士
                        Cert = new TArcherPolice();
                        break;
                    case 51:
                        // 没有  清清 2007.11.26
                        // 鸡和神鹰  清清 2007.11.26
                        Cert = new TMonster();
                        Cert.m_boAnimal = true;
                        Cert.m_nMeatQuality = HUtil32.Random(3500) + 3000;
                        Cert.m_nBodyLeathery = 50;
                        break;
                    case 52:
                        // 鹿，羊，守卫   清清 2007.11.26
                        if (HUtil32.Random(30) == 0)
                        {
                            Cert = new TChickenDeer();
                            Cert.m_boAnimal = true;
                            Cert.m_nMeatQuality = HUtil32.Random(20000) + 10000;
                            Cert.m_nBodyLeathery = 150;
                        }
                        else
                        {
                            Cert = new TMonster();
                            Cert.m_boAnimal = true;
                            Cert.m_nMeatQuality = HUtil32.Random(8000) + 8000;
                            Cert.m_nBodyLeathery = 150;
                        }
                        break;
                    case 53:
                        // 狼  清清 2007.11.26
                        Cert = new TATMonster();
                        Cert.m_boAnimal = true;
                        Cert.m_nMeatQuality = HUtil32.Random(8000) + 8000;
                        Cert.m_nBodyLeathery = 150;
                        break;
                    case 55:
                        // 练功师
                        Cert = new TTrainer();
                        Cert.m_btRaceServer = 55;
                        break;
                    case 80:
                        Cert = new TMonster();
                        break;
                    case 81:
                        // 可能是  Tmonster主类 初始化  清清 2007.11.26
                        Cert = new TATMonster();
                        break;
                    case 82:
                        // 物理攻击类的怪物,进入范围自动攻击
                        Cert = new TSpitSpider();
                        break;
                    case 83:
                        // 攻击的时候吐毒的怪物  2x2范围内毒液攻击-弱
                        Cert = new TSlowATMonster();
                        break;
                    case 84:
                        // 也是物理攻击的  其中有  蛤蟆 半兽人
                        Cert = new TScorpion();
                        break;
                    case 85:
                        // 蝎子
                        Cert = new TStickMonster();
                        break;
                    case 86:
                        // 食人花
                        Cert = new TATMonster();
                        break;
                    case 87:
                        // 骷髅
                        Cert = new TDualAxeMonster();
                        break;
                    case 88:
                        // 投斧头那种怪物 (远程攻击)
                        Cert = new TATMonster();
                        break;
                    case 89:
                        // 骷髅战士
                        Cert = new TATMonster();
                        break;
                    case 90:
                        // 骷髅战将   骷髅精灵   跟上面的一样类
                        Cert = new TGasAttackMonster();
                        break;
                    case 91:
                        // 洞蛆
                        Cert = new TMagCowMonster();
                        break;
                    case 92:
                        // 火焰沃玛
                        Cert = new TCowKingMonster();
                        break;
                    case 93:
                        // 沃玛教主  其中攻击属于魔法(遇到攻击对象在范围外时会瞬移)
                        Cert = new TThornDarkMonster();
                        break;
                    case 94:
                        // 暗黑战士  跟投斧差不多  也是远程攻击
                        Cert = new TLightingZombi();
                        break;
                    case 95:
                        // 电僵尸
                        // 石墓尸王   从地下冒出来的怪
                        Cert = new TDigOutZombi();
                        if (HUtil32.Random(2) == 0)
                        {
                            Cert.bo2BA = true;
                        }
                        break;
                    case 96:
                        // 这个 有代研究
                        Cert = new TZilKinZombi();
                        if (HUtil32.Random(4) == 0)
                        {
                            Cert.bo2BA = true;
                        }
                        break;
                    case 97:
                        // 不进入火墙
                        Cert = new TCowMonster();
                        // 沃玛战士   沃玛勇士  那类的  物理攻击
                        if (HUtil32.Random(2) == 0)
                        {
                            Cert.bo2BA = true;
                        }
                        break;
                    case 98:
                        Cert = new TSwordsmanMon();
                        break;
                    case 100:
                        // 灵魂收割者,蓝影刀客 2格内可以攻击的怪 20090123
                        Cert = new TWhiteSkeleton();
                        break;
                    case 101:
                        // 变异骷髅    道士召唤的宝宝
                        // 祖玛雕像  祖玛卫士 怪物刚开始是黑的(进入范围会从石像状态激活)
                        Cert = new TScultureMonster();
                        Cert.bo2BA = true;
                        break;
                    case 102:
                        Cert = new TScultureKingMonster();
                        break;
                    case 103:
                        // 祖玛教主
                        Cert = new TBeeQueen();
                        break;
                    case 104:
                        // 有代分析
                        Cert = new TArcherMonster();
                        break;
                    case 105:
                        // 祖玛弓箭手  魔龙弓箭手 那类的
                        Cert = new TGasMothMonster();
                        break;
                    case 106:
                        // 楔蛾
                        Cert = new TGasDungMonster();
                        break;
                    case 107:
                        // 粪虫
                        Cert = new TCentipedeKingMonster();
                        break;
                    case 108:
                        // 触龙神  不能动的怪物？
                        Cert = new TFairyMonster();
                        // 月灵
                        Cert.bo2BA = true;
                        break;
                    case 110:
                        // 不进入火墙 20080327
                        Cert = new TCastleDoor();
                        break;
                    case 111:
                        // 沙巴克的 城门
                        Cert = new TWallStructure();
                        break;
                    case 112:
                        // 沙巴克的 左墙,中，右
                        Cert = new TArcherGuard();
                        break;
                    case 113:
                        // 弓箭手那类的 NPC
                        Cert = new TElfMonster();
                        break;
                    case 114:
                        // 神兽
                        Cert = new TElfWarriorMonster();
                        break;
                    case 115:
                        // 神兽1
                        Cert = new TBigHeartMonster();
                        break;
                    case 116:
                        // 赤月恶魔  千年树妖  从地下冒刺的  不能动的怪
                        Cert = new TSpiderHouseMonster();
                        break;
                    case 117:
                        // 属于可以 怪生怪的 怪
                        Cert = new TExplosionSpider();
                        break;
                    case 118:
                        // 幻影蜘蛛
                        Cert = new THighRiskSpider();
                        break;
                    case 119:
                        // 天狼蜘蛛
                        Cert = new TBigPoisionSpider();
                        break;
                    case 120:
                        // 花吻蜘蛛
                        Cert = new TSoccerBall();
                        break;
                    case 121:
                        // 飞火流星   其实就是足球
                        Cert = new TGiantSickleSpiderATMonster();
                        break;
                    case 122:
                        // 巨镰蜘蛛 20080809
                        Cert = new TSalamanderATMonster();
                        break;
                    case 123:
                        // 狂热火蜥蜴 20080809
                        Cert = new TTempleGuardian();
                        break;
                    case 124:
                        // 圣殿卫士 20080809
                        Cert = new TheCrutchesSpider();
                        break;
                    case 125:
                        // 金杖蜘蛛 20080809
                        Cert = new TYanLeiWangSpider();
                        break;
                    case 126:
                        // 雷炎蛛王 20080811
                        Cert = new TSnowyFireDay();
                        break;
                    case 127:
                        // 雪域灭天魔 用灭天火,会施放红毒 20090113
                        Cert = new TDevilBat();
                        break;
                    case 128:
                        // 恶魔蝙蝠 20090112 施毒术,气功波,抗拒,野蛮对它无效,只有道士捆魔咒可以捆住,只有战士刺杀的第2格能攻击到,攻击方式靠近人物自爆攻击
                        Cert = new TFireDragon();
                        break;
                    case 129:
                        // 火龙魔兽 20090111
                        Cert = new TFireDragonGuard();
                        break;
                    case 130:
                        // 火龙守护兽 20090111
                        Cert = new TSnowyHanbing();
                        break;
                    case 131:
                        // 雪域寒冰魔:冰咆哮，会施放绿毒 20090113
                        Cert = new TSnowyWuDu();
                        break;
                    case 132:
                        // 雪域五毒魔:寒冰掌,治疗术 20090113
                        Cert = new TElfMonster();
                        break;
                    case 135:
                        // 圣兽
                        Cert = new TArcherGuardMon();
                        break;
                    case 136:
                        // 类似弓箭手的怪,只打怪物 20080121
                        Cert = new TArcherGuardMon1();
                        break;
                    case 150:
                        // 不会移动,不会攻击的怪 20080122 魔王岭的怪
                        Cert = new TPlayMonster();
                        break;
                    case 200:
                        // 人形怪
                        Cert = new TElectronicScolpionMon();
                        break;
                // 有代研究
                }
                nCode = 2;
                if (Cert != null)
                {
                    nCode = 3;
                    MonInitialize(Cert, sMonName);
                    nCode = 4;
                    Cert.m_PEnvir = Map;
                    Cert.m_sMapName = sMapName;
                    Cert.m_nCurrX = nX;
                    Cert.m_nCurrY = nY;
                    Cert.m_btDirection = (byte)HUtil32.Random(8);
                    Cert.m_sCharName = sMonName;
                    Cert.m_WAbil = Cert.m_Abil;
                    nCode = 5;
                    if (HUtil32.Random(100) < Cert.m_btCoolEye)
                    {
                        Cert.m_boCoolEye = true;
                    }
                    nCode = 6;
                    MonGetRandomItems(Cert); // 取得怪物可以爆物品
                   
                    nCode = 7;
                    Cert.Initialize();
                    nCode = 8;
                    switch(nMonRace)
                    {
                        case 108:
                            ((TFairyMonster)(Cert)).nWalkSpeed = Cert.m_nWalkSpeed;
                            break;
                        case 121:
                            // 保存月灵DB设置的走路速度 20090105
                            ((TGiantSickleSpiderATMonster)(Cert)).AddItemsFromConfig();
                            break;
                        case 122:
                            // 巨镰蜘蛛(读取可探索物品) 20080810
                            ((TSalamanderATMonster)(Cert)).AddItemsFromConfig();
                            break;
                        case 123:
                            // 狂热火蜥蜴(读取可探索物品) 20080810
                            ((TTempleGuardian)(Cert)).AddItemsFromConfig();
                            break;
                        case 124:
                            // 圣殿卫士(读取可探索物品) 20080810
                            ((TheCrutchesSpider)(Cert)).AddItemsFromConfig();
                            break;
                        case 125:
                            // 金杖蜘蛛(读取可探索物品) 20080810
                            ((TYanLeiWangSpider)(Cert)).AddItemsFromConfig();
                            break;
                        case 136:
                            // 雷炎蛛王(读取可探索物品) 20080815
                            // 20080124 136怪自动走动 魔王岭怪
                            // (CompareText(Cert.m_sMapName, m_sMapName_136) = 0) and
                            // 20090204
                            if ((m_nCurrX_136 != 0) && (m_nCurrY_136 != 0))
                            {
                                Cert.m_nCurrX = m_nCurrX_136;
                                Cert.m_nCurrY = m_nCurrY_136;
                                ((TArcherGuardMon1)(Cert)).m_NewCurrX = m_NewCurrX_136;
                                ((TArcherGuardMon1)(Cert)).m_NewCurrY = m_NewCurrY_136;
                                ((TArcherGuardMon1)(Cert)).m_boWalk = true;
                            }
                            break;
                        case 150:
                            // 人型怪
                            Cert.m_nCopyHumanLevel = 0;
                            Cert.m_Abil.MP = Cert.m_Abil.MaxMP;
                            Cert.m_Abil.HP = Cert.m_Abil.MaxHP;
                            // 数据库HP为0,使怪一出来就死 20080120
                            Cert.m_WAbil = Cert.m_Abil;
                            ((TPlayMonster)(Cert)).InitializeMonster();
                            // 初始化人形怪物,读文件配置(技能,装备)
                            Cert.RecalcAbilitys();
                            break;
                    }
                    // case
                    nCode = 9;
                    if (Cert.m_boAddtoMapSuccess)
                    {
                        p28 = null;
                        if (Cert.m_PEnvir.m_nWidth < 50)
                        {
                            n20 = 2;
                        }
                        else
                        {
                            n20 = 3;
                        }
                        if ((Cert.m_PEnvir.m_nHeight < 250))
                        {
                            if ((Cert.m_PEnvir.m_nHeight < 30))
                            {
                                n24 = 2;
                            }
                            else
                            {
                                n24 = 20;
                            }
                        }
                        else
                        {
                            n24 = 50;
                        }
                        n1C = 0;
                        while (true)
                        {
                            if (!Cert.m_PEnvir.CanWalk(Cert.m_nCurrX, Cert.m_nCurrY, false))
                            {
                                if ((Cert.m_PEnvir.m_nWidth - n24 - 1) > Cert.m_nCurrX)
                                {
                                    Cert.m_nCurrX += n20;
                                }
                                else
                                {
                                    Cert.m_nCurrX = HUtil32.Random(Cert.m_PEnvir.m_nWidth / 2) + n24;
                                    if (Cert.m_PEnvir.m_nHeight - n24 - 1 > Cert.m_nCurrY)
                                    {
                                        Cert.m_nCurrY += n20;
                                    }
                                    else
                                    {
                                        Cert.m_nCurrY = HUtil32.Random(Cert.m_PEnvir.m_nHeight / 2) + n24;
                                    }
                                }
                            }
                            else
                            {
                                p28 = Cert.m_PEnvir.AddToMap(Cert.m_nCurrX, Cert.m_nCurrY, Grobal2.OS_MOVINGOBJECT, Cert);
                                break;
                            }
                            n1C ++;
                            if (n1C >= 31)
                            {
                                break;
                            }
                        }
                        if (p28 == null)
                        {
                            //Cert.Free;
                            Cert = null;
                            Dispose(Cert);
                        }
                        if (Cert != null)
                        {
                            Cert.m_nViewRange += 2;
                        // 2006-12-30 怪物视觉+2
                        }
                    }
                }
                nCode = 10;
                if (Cert != null)
                {
                    if (Cert.m_btRaceServer == 150)
                    {
                        // 20090203 取守护坐标
                        ((TPlayMonster)(Cert)).m_nProtectTargetX = Cert.m_nCurrX;
                        // 守护坐标
                        ((TPlayMonster)(Cert)).m_nProtectTargetY = Cert.m_nCurrY;
                    // 守护坐标
                    }
                }
                result = Cert;
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.AddBaseObject MonRace:" + (nMonRace).ToString() + " Code:" + (nCode).ToString());
            }
            return result;
        }

        // ====================================================
        // 功能:创建怪物对象
        // 返回值：在指定时间内创建完对象，则返加TRUE，如果超过指定时间则返回FALSE
        // ====================================================
        private bool RegenMonsters(TMonGenInfo MonGen, int nCount)
        {
            bool result;
            uint dwStartTick;
            int nX;
            int nY;
            int I;
            TBaseObject Cert;
            const string sExceptionMsg = "{异常} TUserEngine::RegenMonsters";
            result = true;
            dwStartTick = GetTickCount();
            try {
                if (MonGen != null)
                {
                    if (MonGen.nRace > 0)
                    {
                        if (nCount <= 0)
                        {
                            nCount = 1;
                        }
                        // 20081008
                        if (HUtil32.Random(100) < MonGen.nMissionGenRate)
                        {
                            // 是否集中刷怪
                            nX = (MonGen.nX - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                            nY = (MonGen.nY - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                            for (I = 0; I < nCount; I ++ )
                            {
                                Cert = AddBaseObject(MonGen.sMapName, ((nX - 10) + HUtil32.Random(20)), ((nY - 10) + HUtil32.Random(20)), MonGen.nRace, MonGen.sMonName);
                                if (Cert != null)
                                {
                                    Cert.m_nChangeColorType = MonGen.nChangeColorType;
                                    // 是否变色
                                    Cert.m_btNameColor = MonGen.nNameColor;
                                    // 自定义名字的颜色 20080810
                                    if (MonGen.nNameColor != 255)
                                    {
                                        Cert.m_boSetNameColor = true;
                                    }
                                    // 20081001 自定义名字颜色
                                    Cert.m_boIsNGMonster = MonGen.boIsNGMon;
                                    // 内功怪,打死可以增加内力值 20081001
                                    MonGen.CertList.Add(Cert);
                                    Cert.AddMapCount();
                                }
                                
                                if ((GetTickCount() - dwStartTick) > M2Share.g_dwZenLimit)
                                {
                                    result = false;
                                    break;
                                }
                            }
                        // for
                        }
                        else
                        {
                            for (I = 0; I < nCount; I ++ )
                            {
                                nX = (MonGen.nX - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                                nY = (MonGen.nY - MonGen.nRange) + HUtil32.Random(MonGen.nRange * 2 + 1);
                                Cert = AddBaseObject(MonGen.sMapName, nX, nY, MonGen.nRace, MonGen.sMonName);
                                if (Cert != null)
                                {
                                    Cert.m_nChangeColorType = MonGen.nChangeColorType;
                                    // 是否变色
                                    Cert.m_btNameColor = MonGen.nNameColor;
                                    // 自定义怪物名字颜色 20080810
                                    if (MonGen.nNameColor != 255)
                                    {
                                        Cert.m_boSetNameColor = true;
                                    }
                                    // 20081001 自定义名字颜色
                                    Cert.m_boIsNGMonster = MonGen.boIsNGMon;
                                    // 内功怪,打死可以增加内力值 20081001
                                    MonGen.CertList.Add(Cert);
                                    Cert.AddMapCount();
                                }
                                
                                if ((GetTickCount() - dwStartTick) > M2Share.g_dwZenLimit)
                                {
                                    result = false;
                                    break;
                                }
                            }
                        // for
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            return result;
        }

        // 20071227 根据名字查找英雄类
        // 取师傅类 20080512
        public TPlayObject GetMasterObject(string sName)
        {
            TPlayObject result;
            int I;
            TPlayObject PlayObject;
            result = null;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    //PlayObject = ((TPlayObject)(m_PlayObjectList[I]));
                    //if (PlayObject != null)
                    //{
                    //    if ((!PlayObject.m_boGhost))
                    //    {
                    //        if (!(PlayObject.m_boPasswordLocked && PlayObject.m_boObMode && PlayObject.m_boAdminMode))
                    //        {
                    //            if ((PlayObject.m_sMasterName).ToLower().CompareTo((sName).ToLower()) == 0)
                    //            {
                    //                result = PlayObject;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            return result;
        }

        // 取师傅类 20080512
        public TPlayObject GetPlayObject(string sName)
        {
            TPlayObject result;
            int I;
            TPlayObject PlayObject;
            result = null;
            if (m_PlayObjectList.Count > 0)
            {
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    //if ((m_PlayObjectList[I]).ToLower().CompareTo((sName).ToLower()) == 0)
                    //{
                    //    PlayObject = ((TPlayObject)(m_PlayObjectList.Values[I]));
                    //    if (PlayObject != null)
                    //    {
                    //        if ((!PlayObject.m_boGhost))
                    //        {
                    //            if (!(PlayObject.m_boPasswordLocked && PlayObject.m_boObMode && PlayObject.m_boAdminMode))
                    //            {
                    //                result = PlayObject;
                    //            }
                    //        }
                    //        break;
                    //    }
                    //}
                }
            }
            return result;
        }

        public TPlayObject GetPlayObject(TBaseObject PlayObject)
        {
            TPlayObject result;
            int I;
            result = null;
            if (m_PlayObjectList.Count > 0)
            {
                //for (I = 0; I < m_PlayObjectList.Count; I ++ )
                //{
                //    if ((PlayObject != null) && (PlayObject == ((TPlayObject)(m_PlayObjectList.Values[I]))))
                //    {
                //        result = ((TPlayObject)(m_PlayObjectList.Values[I]));
                //        break;
                //    }
                //}
            }
            return result;
        }

        // 20071227 按英雄名字查找英雄
        public TBaseObject GetHeroObject(string sName)
        {
            TBaseObject result;
            int I;
            TBaseObject PlayObject;
            result = null;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                //for (I = 0; I < m_PlayObjectList.Count; I ++ )
                //{
                //    PlayObject = ((TPlayObject)(m_PlayObjectList.Values[I])).m_MyHero;
                //    if (PlayObject != null)
                //    {
                //        if ((PlayObject.m_sCharName).ToLower().CompareTo((sName).ToLower()) == 0)
                //        {
                //            result = PlayObject;
                //            break;
                //        }
                //    }
                //}
            }
            return result;
        }

        public TPlayObject GetHeroObject(TBaseObject HeroObject)
        {
            TPlayObject result;
            int I;
            result = null;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                //for (I = 0; I < m_PlayObjectList.Count; I ++ )
                //{
                //    if ((HeroObject != null) && (HeroObject == ((TPlayObject)(m_PlayObjectList.Values[I])).m_MyHero))
                //    {
                //        result = ((TPlayObject)(m_PlayObjectList.Values[I]));
                //        break;
                //    }
                //}
            }
            return result;
        }

        // 踢出人物
        public void KickPlayObjectEx(string sAccount, string sName)
        {
            int I;
            TPlayObject PlayObject;
            
            EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try {
                if (m_PlayObjectList.Count > 0)
                {
                    for (I = 0; I < m_PlayObjectList.Count; I ++ )
                    {
                        //PlayObject = ((TPlayObject)(m_PlayObjectList.Values[I]));
                        //if (PlayObject != null)
                        //{
                        //    if (((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0) && ((m_PlayObjectList[I]).ToLower().CompareTo((sName).ToLower()) == 0))
                        //    {
                        //        PlayObject.m_boEmergencyClose = true;
                        //        PlayObject.m_boPlayOffLine = false;
                        //        break;
                        //    }
                        //}
                    }
                }
            } finally {
                
                LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        public TPlayObject GetPlayObjectEx(string sAccount, string sName)
        {
            TPlayObject result;
            int I;
            TPlayObject PlayObject;
            result = null;
            
            EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try {
                if (m_PlayObjectList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_PlayObjectList.Count; I ++ )
                    {
                        //PlayObject = ((TPlayObject)(m_PlayObjectList.Values[I]));
                        //if (PlayObject != null)
                        //{
                        //    if (((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0) && ((m_PlayObjectList[I]).ToLower().CompareTo((sName).ToLower()) == 0))
                        //    {
                        //        result = PlayObject;
                        //        break;
                        //    }
                        //}
                    }
                }
            } finally {
                
                LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        // 获取离线挂人物
        public TPlayObject GetPlayObjectExOfAutoGetExp(string sAccount)
        {
            TPlayObject result;
            int I;
            TPlayObject PlayObject;
            result = null;
            EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try {
                if (m_PlayObjectList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_PlayObjectList.Count; I ++ )
                    {
                        PlayObject = m_PlayObjectList[I];
                        if (PlayObject != null)
                        {
                            if (((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0) && PlayObject.m_boNotOnlineAddExp)
                            {
                                result = PlayObject;
                                break;
                            }
                        }
                    }
                }
            } finally {
                LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
            return result;
        }

        // 查找交易NPC
        public TMerchant FindMerchant(Object Merchant)
        {
            TMerchant result;
            int I;
            result = null;
            //m_MerchantList.__Lock();
            try {
                if (m_MerchantList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MerchantList.Count; I ++ )
                    {
                        if ((((m_MerchantList[I]) as Object) != null) && (((m_MerchantList[I]) as Object) == Merchant))
                        {
                            result = ((TMerchant)(m_MerchantList[I]));
                            break;
                        }
                    }
                }
            } finally {
                //m_MerchantList.UnLock();
            }
            return result;
        }

        public TGuildOfficial FindNPC(Object GuildOfficial)
        {
            TGuildOfficial result;
            int I;
            result = null;
            if (QuestNPCList.Count > 0)
            {
                // 20081008
                for (I = 0; I < QuestNPCList.Count; I ++ )
                {
                    if ((((QuestNPCList[I]) as Object) != null) && (((QuestNPCList[I]) as Object) == GuildOfficial))
                    {
                        result = ((TGuildOfficial)(QuestNPCList[I]));
                        break;
                    }
                }
            }
            return result;
        }

        public int GetMapOfRangeHumanCount(TEnvirnoment Envir, int nX, int nY, int nRange)
        {
            int result;
            int I;
            TPlayObject PlayObject;
            result = 0;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    PlayObject = m_PlayObjectList[I];
                    if (PlayObject != null)
                    {
                        if (!PlayObject.m_boGhost && (PlayObject.m_PEnvir == Envir))
                        {
                            if ((Math.Abs(PlayObject.m_nCurrX - nX) < nRange) && (Math.Abs(PlayObject.m_nCurrY - nY) < nRange))
                            {
                                result ++;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 取人物权限
        public bool GetHumPermission(string sUserName, ref string sIPaddr, ref byte btPermission)
        {
            bool result;
            // 4AE590
            int I;
            TAdminInfo AdminInfo;
            result = false;
            btPermission = M2Share.g_Config.nStartPermission;
            //m_AdminList.__Lock();
            //try {
            //    if (m_AdminList.Count > 0)
            //    {
            //         20081008
            //        for (I = 0; I < m_AdminList.Count; I ++ )
            //        {
            //            AdminInfo = m_AdminList[I];
            //            if (AdminInfo != null)
            //            {
            //                if ((AdminInfo.sChrName).ToLower().CompareTo((sUserName).ToLower()) == 0)
            //                {
            //                    btPermission = AdminInfo.nLv;
            //                    sIPaddr = AdminInfo.sIPaddr;
            //                    result = true;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //} finally {
            //    m_AdminList.UnLock();
            //}
            return result;
        }

        // //20080522 注释
        // procedure TUserEngine.GenShiftUserData;
        // begin
        // 
        // end;
        public void AddUserOpenInfo(TUserOpenInfo UserOpenInfo)
        {
            
            EnterCriticalSection(m_LoadPlaySection);
            try {
                //m_LoadPlayList.Add(UserOpenInfo.sChrName, ((UserOpenInfo) as Object));
            } finally {
                LeaveCriticalSection(m_LoadPlaySection);
            }
        }

        // 创建分身
        // procedure GenShiftUserData();//20080522 注释
        // 踢出在线人物
        private void KickOnlineUser(string sChrName)
        {
            int I;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    PlayObject = m_PlayObjectList[I];
                    if (PlayObject != null)
                    {
                        if ((PlayObject.m_sCharName).ToLower().CompareTo((sChrName).ToLower()) == 0)
                        {
                            PlayObject.m_boKickFlag = true;
                            break;
                        }
                    }
                }
            }
        }

        private bool SendSwitchData(TPlayObject PlayObject, int nServerIndex)
        {
            bool result;
            result = true;
            return result;
        }

        private void SendChangeServer(TPlayObject PlayObject, int nServerIndex)
        {
            string sIPaddr = string.Empty;
            int nPort = 0;
            const string sMsg = "%s/%d";
            if (M2Share.GetMultiServerAddrPort((byte)nServerIndex, ref sIPaddr, ref nPort))
            {
                PlayObject.SendDefMessage(Grobal2.SM_RECONNECT, 0, 0, 0, 0, string.Format(sMsg, sIPaddr, nPort));
            }
        }

        // 保存人数数据
        public void SaveHumanRcd(TPlayObject PlayObject)
        {
            TSaveRcd SaveRcd;
            byte nCode;
            nCode = 0;
            try {
                if (PlayObject != null)
                {
                    // 20090104
                    if (PlayObject.m_boOperationItemList)
                    {
                        return;
                    }
                    // 20080928 防止同时操作背包列表时保存
                    if (PlayObject.m_boRcdSaveding)
                    {
                        return;
                    }
                    // 是否正在保存数据 20090106 防止同进入过程
                    PlayObject.m_boRcdSaveding = true;
                    try {
                        SaveRcd = new TSaveRcd();
                        
                        //FillChar(SaveRcd, sizeof(TSaveRcd), '\0');
                        nCode = 1;
                        SaveRcd.sAccount = PlayObject.m_sUserID;
                        SaveRcd.sChrName = PlayObject.m_sCharName;
                        SaveRcd.nSessionID = PlayObject.m_nSessionID;
                        SaveRcd.PlayObject = PlayObject;
                        SaveRcd.nReTryCount = 0;
                        SaveRcd.dwSaveTick = GetTickCount();
                        SaveRcd.boIsHero = false;
                        nCode = 2;
                        PlayObject.MakeSaveRcd(ref SaveRcd.HumanRcd);
                        nCode = 3;
                        if (M2Share.FrontEngine.UpDataSaveRcdList(SaveRcd))
                        {
                            Dispose(SaveRcd);
                        }
                    } finally {
                        PlayObject.m_boRcdSaveding = false;
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.SaveHumanRcd Code:" + (nCode).ToString());
            }
        }

        // 创建英雄
        public void SaveHeroRcd(TPlayObject PlayObject)
        {
            TSaveRcd SaveRcd;
            byte nCode;
            nCode = 0;
            try {
                if (PlayObject != null)
                {
                    // 20090106
                    nCode = 1;
                    if (PlayObject.m_boOperationItemList)
                    {
                        return;
                    }
                    // 20080928 防止同时操作背包列表时保存
                    nCode = 2;
                    if (PlayObject.m_MyHero != null)
                    {
                        if (PlayObject.m_boRcdSaveding)
                        {
                            return;
                        }
                        // 是否正在保存数据 20090106 防止同进入过程
                        PlayObject.m_boRcdSaveding = true;
                        try {
                            SaveRcd = new TSaveRcd();
                            //FillChar(SaveRcd, sizeof(TSaveRcd), '\0');
                            SaveRcd.sAccount = PlayObject.m_sUserID;
                            nCode = 3;
                            SaveRcd.sChrName = PlayObject.m_MyHero.m_sCharName;
                            SaveRcd.nSessionID = PlayObject.m_nSessionID;
                            SaveRcd.PlayObject = PlayObject;
                            SaveRcd.nReTryCount = 0;
                            SaveRcd.dwSaveTick = GetTickCount();
                            SaveRcd.boIsHero = true;
                            if (((THeroObject)(PlayObject.m_MyHero)).m_btMentHero == 2)
                            {
                                SaveRcd.boisDoubleHero = true;
                            // 20100301 是否是副将英雄
                            }
                            nCode = 4;
                            ((THeroObject)(PlayObject.m_MyHero)).MakeSaveRcd(ref SaveRcd.HumanRcd);
                            nCode = 5;
                            if (M2Share.FrontEngine.UpDataSaveRcdList(SaveRcd))
                            {
                                Dispose(SaveRcd);
                            }
                        } finally {
                            PlayObject.m_boRcdSaveding = false;
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.SaveHeroRcd Code:" + (nCode).ToString());
            }
        }

        // 加入销毁列表
        private void AddToHumanFreeList(TPlayObject PlayObject)
        {
            PlayObject.m_dwGhostTick = GetTickCount();
            m_PlayObjectFreeList.Add(PlayObject);
        }

        // 取数据库人物的数据
        private void GetHumData(TPlayObject PlayObject, ref THumDataInfo HumanRcd)
        {
            THumData HumData;
            TUserItem[] HumItems;
            TUserItem[] HumAddItems;
            TUserItem[] BagItems;
            TUserItem UserItem;
            THumMagic[] HumMagics;
            THumMagic[] HumNGMagics;
            // 20081001
            TUserMagic UserMagic;
            THumMagic[] HumBatterMagics;
            TMagic MagicInfo;
            TUserItem[] StorageItems;
            int I;
            IniFile IniFile;
            string sFileName;
            string sMap = string.Empty;
            string sX = string.Empty;
            string sY = string.Empty;
            HumData = HumanRcd.Data;
            PlayObject.m_sCharName = HumData.sChrName;
            PlayObject.m_sMapName = HumData.sCurMap;
            PlayObject.m_nCurrX = HumData.wCurX;
            PlayObject.m_nCurrY = HumData.wCurY;
            PlayObject.m_btDirection = HumData.btDir;
            PlayObject.m_btHair = HumData.btHair;
            PlayObject.m_btGender = HumData.btSex;
            PlayObject.m_btJob = HumData.btJob;
            PlayObject.m_nGold = HumData.nGold;
            PlayObject.m_sLastMapName = PlayObject.m_sMapName;
            // 2006-01-12增加人物上次退出地图
            PlayObject.m_nLastCurrX = PlayObject.m_nCurrX;
            // 2006-01-12增加人物上次退出所在座标X
            PlayObject.m_nLastCurrY = PlayObject.m_nCurrY;
            // 2006-01-12增加人物上次退出所在座标Y
            PlayObject.m_Abil.Level = HumData.Abil.Level;
            PlayObject.m_Abil.HP = HumData.Abil.HP;
            PlayObject.m_Abil.MP = HumData.Abil.MP;
            PlayObject.m_Abil.MaxHP = HumData.Abil.MaxHP;
            PlayObject.m_Abil.MaxMP = HumData.Abil.MaxMP;
            PlayObject.m_Abil.Exp = HumData.Abil.Exp;
            PlayObject.m_Abil.MaxExp = HumData.Abil.MaxExp;
            PlayObject.m_Abil.Weight = HumData.Abil.Weight;
            PlayObject.m_Abil.MaxWeight = HumData.Abil.MaxWeight;
            //PlayObject.m_Abil.WearWeight = HumData.Abil.WearWeight;
            //PlayObject.m_Abil.MaxWearWeight = HumData.Abil.MaxWearWeight;
            //PlayObject.m_Abil.HandWeight = HumData.Abil.HandWeight;
            //PlayObject.m_Abil.MaxHandWeight = HumData.Abil.MaxHandWeight;
            PlayObject.m_Abil.Alcohol = HumData.n_Reserved;
            // 酒量 20080622
            PlayObject.m_Abil.MaxAlcohol = HumData.n_Reserved1;
            // 酒量上限 20080622
            if (PlayObject.m_Abil.MaxAlcohol < M2Share.g_Config.nMaxAlcoholValue)
            {
                PlayObject.m_Abil.MaxAlcohol = M2Share.g_Config.nMaxAlcoholValue;
            }
            // 酒量上限小限初始值时,则修改 20080623
            PlayObject.m_Abil.WineDrinkValue = HumData.n_Reserved2;
            // 醉酒度 2008623
            PlayObject.n_DrinkWineQuality = HumData.btUnKnow2[2];
            // 饮酒时酒的品质
            PlayObject.n_DrinkWineAlcohol = HumData.UnKnow[4];
            // 饮酒时酒的度数 20080624
            PlayObject.m_btMagBubbleDefenceLevel = HumData.UnKnow[5];
            // 魔法盾等级 20080811
           // PlayObject.m_Abil.MedicineValue = HumData.nReserved1;
            // 当前药力值 20080623
           // PlayObject.m_Abil.MaxMedicineValue = HumData.nReserved2;
            // 药力值上限 20080623
            PlayObject.n_DrinkWineDrunk = HumData.boReserved3;
            // 人是否喝酒醉了 20080627
            PlayObject.dw_UseMedicineTime = HumData.nReserved3;
            // 使用药酒时间,计算长时间没使用药酒 20080623
            PlayObject.n_MedicineLevel = HumData.n_Reserved3;
            // 药力值等级 20080623
            if (PlayObject.n_MedicineLevel <= 0)
            {
                PlayObject.n_MedicineLevel = 1;
            }
            // 如果药力值等级为0,则设置为1 20080624
            if (PlayObject.m_Abil.MaxMedicineValue <= 0)
            {
                PlayObject.m_Abil.MaxMedicineValue = PlayObject.GetMedicineExp(PlayObject.n_MedicineLevel);
            }
            PlayObject.m_Exp68 = HumData.Exp68;
            // 酒气护体当前经验 20080625
            PlayObject.m_MaxExp68 = HumData.MaxExp68;
            // 酒气护体升级经验 20080625
            PlayObject.m_boTrainingNG = HumData.UnKnow[6] != 0;
            // 是否学习过内功 20081002
            if (PlayObject.m_boTrainingNG)
            {
                // 内功等级 20081204
                PlayObject.m_NGLevel = HumData.UnKnow[7];
            }
            else
            {
                PlayObject.m_NGLevel = 0;
            }
            //PlayObject.m_ExpSkill69 = HumData.nExpSkill69;
            // 内功当前经验 20080930
            PlayObject.m_Skill69NH = HumData.Abil.NG;
            // 内功当前内力值 20080930
            PlayObject.m_Skill69MaxNH = HumData.Abil.MaxNG;
            // 内力值上限 20081001
            if (PlayObject.m_Abil.Exp <= 0)
            {
                PlayObject.m_Abil.Exp = 1;
            }
            if (PlayObject.m_Abil.MaxExp <= 0)
            {
                PlayObject.m_Abil.MaxExp = PlayObject.GetLevelExp(PlayObject.m_Abil.Level);
            }
            PlayObject.m_wStatusTimeArr = HumData.wStatusTimeArr;
            PlayObject.m_sHomeMap = HumData.sHomeMap;
            PlayObject.m_nHomeX = HumData.wHomeX;
            PlayObject.m_nHomeY = HumData.wHomeY;
            PlayObject.m_BonusAbil = HumData.BonusAbil;
            // 08/09
            PlayObject.m_nBonusPoint = HumData.nBonusPoint;
            // 08/09
            PlayObject.m_btCreditPoint = HumData.btCreditPoint;
            PlayObject.m_btReLevel = HumData.btReLevel;
            PlayObject.m_sMasterName = HumData.sMasterName;
            PlayObject.m_boMaster = HumData.boMaster;
            if (PlayObject.m_boMaster || (PlayObject.m_sMasterName != ""))
            {
                PlayObject.GetMasterNoList();
            }
            // 20080530 取师徒数据
            PlayObject.m_sDearName = HumData.sDearName;
            PlayObject.m_sStoragePwd = HumData.sStoragePwd;
            if (PlayObject.m_sStoragePwd != "")
            {
                PlayObject.m_boPasswordLocked = true;
            }
            PlayObject.m_nGameGold = HumData.nGameGold;
            PlayObject.m_nGAMEDIAMOND = HumData.nGameDiaMond;
            // 20071226 金刚石
            PlayObject.m_nGAMEGIRD = HumData.nGameGird;
            // 20071226 灵符
            // if g_Config.boSaveExpRate then begin //是否保存双倍经验时间 20080412
            PlayObject.m_nKillMonExpRate = HumData.nEXPRATE;
            // 20071230 经验倍数
            //PlayObject.m_dwKillMonExpRateTime = HumData.nExpTime;
            // 20071230 经验倍数时间
            PlayObject.m_nOldKillMonExpRate = PlayObject.m_nKillMonExpRate;
            // 20080607
            if (PlayObject.m_nKillMonExpRate <= 0)
            {
                PlayObject.m_nKillMonExpRate = 100;
            }
            // 20081229
            // end;
            PlayObject.m_nGamePoint = HumData.nGamePoint;
            PlayObject.m_nPayMentPoint = HumData.nPayMentPoint;
            PlayObject.m_btGameGlory = HumData.btGameGlory;
            // 荣誉 20080511
            PlayObject.m_nPkPoint = HumData.nPKPOINT;
            if (HumData.btAllowGroup > 0)
            {
                PlayObject.m_boAllowGroup = true;
            }
            else
            {
                PlayObject.m_boAllowGroup = false;
            }
            PlayObject.btB2 = HumData.btF9;
            PlayObject.m_btAttatckMode = HumData.btAttatckMode;
            PlayObject.m_nIncHealth = HumData.btIncHealth;
            PlayObject.m_nIncSpell = HumData.btIncSpell;
            PlayObject.m_nIncHealing = HumData.btIncHealing;
            PlayObject.m_nFightZoneDieCount = HumData.btFightZoneDieCount;
            PlayObject.m_sUserID = HumData.sAccount;
            // PlayObject.nC4 := HumData.btEE;//20081007 注释，nC4无实际用处
            PlayObject.m_boLockLogon = HumData.boLockLogon;
            PlayObject.m_wContribution = HumData.wContribution;
            PlayObject.m_nHungerStatus = HumData.nHungerStatus;
            PlayObject.m_boAllowGuildReCall = HumData.boAllowGuildReCall;
            PlayObject.m_wGroupRcallTime = HumData.wGroupRcallTime;
            PlayObject.m_dBodyLuck = HumData.dBodyLuck;
            PlayObject.m_boAllowGroupReCall = HumData.boAllowGroupReCall;
            // PlayObject.m_QuestUnitOpen := HumData.QuestUnitOpen;
            // PlayObject.m_QuestUnit := HumData.QuestUnit;
            PlayObject.m_btLastOutStatus = HumData.btLastOutStatus;
            // 退出状态 1为死亡
            PlayObject.m_wMasterCount = HumData.wMasterCount;
            // 出师徒弟数
            PlayObject.bo_YBDEAL = HumData.btUnKnow2[0] == 1;
            // 是否开通元宝寄售 20080316
            PlayObject.m_nWinExp = HumData.n_WinExp;
            // 20080221 聚灵珠  累计经验
            PlayObject.n_UsesItemTick = HumData.n_UsesItemTick;
            // 聚灵珠聚集时间 20080221
            PlayObject.m_QuestFlag = HumData.QuestFlag;
            PlayObject.m_boHasHero = HumData.boHasHero;
            PlayObject.m_boHasHeroTwo = HumData.boReserved1;
            // 20080519 是否有卧龙英雄
            PlayObject.m_sHeroCharName = HumData.sHeroChrName;
            PlayObject.m_sDeputyHeroCharName = HumData.sMentHeroChrName;
            // 副将英雄名字
            PlayObject.n_HeroSave = HumData.btUnKnow2[1];
            // 是否保存英雄 20080513
            PlayObject.n_myHeroTpye = HumData.btEF;
            // 角色身上带的英雄所属的类型  20080515
            PlayObject.m_boPlayDrink = HumData.boReserved;
            // 是否请过酒 T-请过酒 20080515
            PlayObject.m_GiveGuildFountationDate = HumData.m_GiveDate;
            // 人物领取行会酒泉日期 20080625
            PlayObject.m_boMakeWine = HumData.boReserved2;
            // 是否酿酒 20080620
            PlayObject.m_MakeWineTime = HumData.nReserved;
            // 酿酒的时间,即还有多长时间可以取回酒 20080620
            PlayObject.n_MakeWineItmeType = HumData.UnKnow[0];
            // 酿酒后,应该可以得到酒的类型 2008020
            PlayObject.n_MakeWineType = HumData.UnKnow[1];
            // 酿酒的类型 1-普通酒 2-药酒  20080620
            PlayObject.n_MakeWineQuality = HumData.UnKnow[2];
            // 酿酒后,应该可以得到酒的品质 20080620
            PlayObject.n_MakeWineAlcohol = HumData.UnKnow[3];
            // 酿酒后,应该可以得到酒的酒精度 20080620
            HumItems = HumanRcd.Data.HumItems;
            PlayObject.m_UseItems[Grobal2.U_DRESS] = HumItems[Grobal2.U_DRESS];
            PlayObject.m_UseItems[Grobal2.U_WEAPON] = HumItems[Grobal2.U_WEAPON];
            PlayObject.m_UseItems[Grobal2.U_RIGHTHAND] = HumItems[Grobal2.U_RIGHTHAND];
            PlayObject.m_UseItems[Grobal2.U_NECKLACE] = HumItems[Grobal2.U_HELMET];
            PlayObject.m_UseItems[Grobal2.U_HELMET] = HumItems[Grobal2.U_NECKLACE];
            PlayObject.m_UseItems[Grobal2.U_ARMRINGL] = HumItems[Grobal2.U_ARMRINGL];
            PlayObject.m_UseItems[Grobal2.U_ARMRINGR] = HumItems[Grobal2.U_ARMRINGR];
            PlayObject.m_UseItems[Grobal2.U_RINGL] = HumItems[Grobal2.U_RINGL];
            PlayObject.m_UseItems[Grobal2.U_RINGR] = HumItems[Grobal2.U_RINGR];
            HumAddItems = HumanRcd.Data.HumAddItems;
            PlayObject.m_UseItems[Grobal2.U_BUJUK] = HumAddItems[Grobal2.U_BUJUK];
            PlayObject.m_UseItems[Grobal2.U_BELT] = HumAddItems[Grobal2.U_BELT];
            PlayObject.m_UseItems[Grobal2.U_BOOTS] = HumAddItems[Grobal2.U_BOOTS];
            PlayObject.m_UseItems[Grobal2.U_CHARM] = HumAddItems[Grobal2.U_CHARM];
            PlayObject.m_UseItems[Grobal2.U_ZHULI] = HumAddItems[Grobal2.U_ZHULI];
            // 20080416 斗笠
            PlayObject.m_HumPulses[0] = HumanRcd.Data.HumPulses[0];
            PlayObject.m_HumPulses[1] = HumanRcd.Data.HumPulses[1];
            PlayObject.m_HumPulses[2] = HumanRcd.Data.HumPulses[2];
            PlayObject.m_HumPulses[3] = HumanRcd.Data.HumPulses[3];
            // 人物经络
            PlayObject.m_nBatterOrder[0] = HumanRcd.Data.BatterMagicOrder[0];
            // 连击循序
            PlayObject.m_nBatterOrder[1] = HumanRcd.Data.BatterMagicOrder[1];
            // 连击循序
            PlayObject.m_nBatterOrder[2] = HumanRcd.Data.BatterMagicOrder[2];
            // 连击循序
            BagItems = HumanRcd.Data.BagItems;
            for (I = BagItems.GetLowerBound(0); I <= BagItems.GetUpperBound(0); I++)
            {
                if (BagItems[I].wIndex > 0)
                {
                    UserItem = new TUserItem();
                    
                    //FillChar(UserItem, sizeof(TUserItem), '\0');
                    // 20080820 增加
                    // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);//20080820 增加
                    UserItem = BagItems[I];
                    PlayObject.m_ItemList.Add(UserItem);
                }
            }
            HumMagics = HumanRcd.Data.HumMagics;
            for (I = HumMagics.GetLowerBound(0); I <= HumMagics.GetUpperBound(0); I++)
            {
                MagicInfo = M2Share.UserEngine.FindMagic(HumMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = new TUserMagic();
                    UserMagic.MagicInfo = MagicInfo;
                    UserMagic.wMagIdx = HumMagics[I].wMagIdx;
                    UserMagic.btLevel = HumMagics[I].btLevel;
                    UserMagic.btKey = HumMagics[I].btKey;
                    UserMagic.nTranPoint = HumMagics[I].nTranPoint;
                    PlayObject.m_MagicList.Add(UserMagic);
                }
            }
            HumNGMagics = HumanRcd.Data.HumNGMagics;
            // 20081001 内功技能
            for (I = HumNGMagics.GetLowerBound(0); I <= HumNGMagics.GetUpperBound(0); I++)
            {
                // 内功技能 20081001
                MagicInfo = M2Share.UserEngine.FindMagic(HumNGMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = new TUserMagic();
                    UserMagic.MagicInfo = MagicInfo;
                    UserMagic.wMagIdx = HumNGMagics[I].wMagIdx;
                    UserMagic.btLevel = HumNGMagics[I].btLevel;
                    UserMagic.btKey = HumNGMagics[I].btKey;
                    UserMagic.nTranPoint = HumNGMagics[I].nTranPoint;
                    PlayObject.m_MagicList.Add(UserMagic);
                }
            }
            HumBatterMagics = HumanRcd.Data.HumBatterMagics;
            // 20091211 连击技能
            for (I = HumBatterMagics.GetLowerBound(0); I <= HumBatterMagics.GetUpperBound(0); I++)
            {
                // 连击技能 20091211
                MagicInfo = M2Share.UserEngine.FindMagic(HumBatterMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = new TUserMagic();
                    UserMagic.MagicInfo = MagicInfo;
                    UserMagic.wMagIdx = HumBatterMagics[I].wMagIdx;
                    UserMagic.btLevel = HumBatterMagics[I].btLevel;
                    UserMagic.btKey = HumBatterMagics[I].btKey;
                    UserMagic.nTranPoint = HumBatterMagics[I].nTranPoint;
                    PlayObject.m_MagicList.Add(UserMagic);
                }
            }
            StorageItems = HumanRcd.Data.StorageItems;
            for (I = StorageItems.GetLowerBound(0); I <= StorageItems.GetUpperBound(0); I++)
            {
                // 仓库物品
                if (StorageItems[I].wIndex > 0)
                {
                    UserItem = new TUserItem();
                    //FillChar(UserItem, sizeof(TUserItem), '\0');
                    // 20080820 增加
                    // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);//20080820 增加
                    UserItem = StorageItems[I];
                    PlayObject.m_StorageItemList.Add(UserItem);
                }
            }
            //PlayObject.m_BigStorageItemList = M2Share.g_Storage.GetUserBigStorageList(PlayObject.m_sCharName);
            // 获取无限仓库数据
            // 读取记路标石记录的地图及XY值 20081019
            sFileName = M2Share.g_Config.sEnvirDir + "UserData\\HumRecallPoint.txt";
            if (File.Exists(sFileName))
            {
                IniFile = new IniFile(sFileName);
                try {
                    for (I = 1; I <= 6; I ++ )
                    {
                        
                        sY = IniFile.ReadString(PlayObject.m_sCharName, "记录" + (I).ToString(), "");
                        sY = HUtil32.GetValidStr3(sY, ref sMap, new string[] {","});
                        if (sMap != "")
                        {
                            sY = HUtil32.GetValidStr3(sY, ref sX, new string[] {","});
                            PlayObject.m_TagMapInfos[I].TagMapName = sMap;
                            PlayObject.m_TagMapInfos[I].TagX = HUtil32.Str_ToInt(sX, 0);
                            PlayObject.m_TagMapInfos[I].TagY = HUtil32.Str_ToInt(sY, 0);
                        }
                    }
                } finally {
                    Dispose(IniFile);
                    //IniFile.Free;
                }
            }
        }

        // 取角色的数据
        // 取英雄数据
        private void GetHeroData(TBaseObject BaseObject, ref THumDataInfo HumanRcd)
        {
            THumData HumData;
            TUserItem[] HumItems;
            TUserItem[] HumAddItems;
            TUserItem[] BagItems;
            TUserItem UserItem;
            THumMagic[] HumMagics;
            THumMagic[] HumNGMagics;
            // 20081001
            THumMagic[] HumBatterMagics;
            TUserMagic UserMagic;
            TMagic MagicInfo;
            // StorageItems: pTStorageItems;
            int I;
            THeroObject HeroObject;
            HeroObject = ((THeroObject)(BaseObject));
            HumData = HumanRcd.Data;
            HeroObject.m_sCharName = HumData.sChrName;
            HeroObject.m_sMapName = HumData.sCurMap;
            HeroObject.m_nCurrX = HumData.wCurX;
            HeroObject.m_nCurrY = HumData.wCurY;
            HeroObject.m_btDirection = HumData.btDir;
            HeroObject.m_btHair = HumData.btHair;
            HeroObject.m_btGender = HumData.btSex;
            HeroObject.m_btJob = HumData.btJob;
            HeroObject.m_nFirDragonPoint = HumData.nGold;
            // 金币数变量用来保存怒气值 20080419
            // PlayObject.m_nGold := HumData.nGold;
            // HeroObject.m_sLastMapName := PlayObject.m_sMapName; //2006-01-12增加人物上次退出地图
            // HeroObject.m_nLastCurrX := HeroObject.m_nCurrX; //2006-01-12增加人物上次退出所在座标X
            // HeroObject.m_nLastCurrY := HeroObject.m_nCurrY; //2006-01-12增加人物上次退出所在座标Y
            HeroObject.m_Abil.Level = HumData.Abil.Level;
            HeroObject.m_Abil.HP = HumData.Abil.HP;
            HeroObject.m_Abil.MP = HumData.Abil.MP;
            HeroObject.m_Abil.MaxHP = HumData.Abil.MaxHP;
            HeroObject.m_Abil.MaxMP = HumData.Abil.MaxMP;
            HeroObject.m_Abil.Exp = HumData.Abil.Exp;
            HeroObject.m_Abil.MaxExp = HumData.Abil.MaxExp;
            HeroObject.m_Abil.Weight = HumData.Abil.Weight;
            HeroObject.m_Abil.MaxWeight = HumData.Abil.MaxWeight;
            //HeroObject.m_Abil.WearWeight = HumData.Abil.WearWeight;
            //HeroObject.m_Abil.MaxWearWeight = HumData.Abil.MaxWearWeight;
            //HeroObject.m_Abil.HandWeight = HumData.Abil.HandWeight;
            //HeroObject.m_Abil.MaxHandWeight = HumData.Abil.MaxHandWeight;
            HeroObject.m_Abil.Alcohol = HumData.n_Reserved;
            // 酒量 20080622
            HeroObject.m_Abil.MaxAlcohol = HumData.n_Reserved1;
            // 酒量上限 20080622
            if (HeroObject.m_Abil.MaxAlcohol < M2Share.g_Config.nMaxAlcoholValue)
            {
                HeroObject.m_Abil.MaxAlcohol = M2Share.g_Config.nMaxAlcoholValue;
            }
            // 酒量上限小限初始值时,则修改 20080623
            HeroObject.m_Abil.WineDrinkValue = HumData.n_Reserved2;
            // 醉酒度 2008623
            HeroObject.n_DrinkWineQuality = HumData.btUnKnow2[2];
            // 饮酒时酒的品质
            HeroObject.n_DrinkWineAlcohol = HumData.UnKnow[4];
            // 饮酒时酒的度数 20080624
            HeroObject.m_btMagBubbleDefenceLevel = HumData.UnKnow[5];
            // 魔法盾等级 20080811
            HeroObject.m_Exp68 = HumData.Exp68;
            // 酒气护体当前经验 20080925
            HeroObject.m_MaxExp68 = HumData.MaxExp68;
            // 酒气护体升级经验 20080925
            HeroObject.m_boTrainingNG = HumData.UnKnow[6] != 0;
            // 是否学习过内功 20081002
            if (HeroObject.m_boTrainingNG)
            {
                // 内功等级 20081002
                HeroObject.m_NGLevel = HumData.UnKnow[7];
            }
            else
            {
                HeroObject.m_NGLevel = 0;
            }
            //HeroObject.m_ExpSkill69 = HumData.nExpSkill69;
            // 内功当前经验 20080930
            HeroObject.m_Skill69NH = HumData.Abil.NG;
            // 内功当前内力值 20080930
            HeroObject.m_Skill69MaxNH = HumData.Abil.MaxNG;
            // 内力值上限 20081001
            //HeroObject.m_Abil.MedicineValue = HumData.nReserved1;
            // 当前药力值 20080623
            //HeroObject.m_Abil.MaxMedicineValue = HumData.nReserved2;
            // 药力值上限 20080623
            HeroObject.n_DrinkWineDrunk = HumData.boReserved3;
            // 人是否喝酒醉了 20080627
            HeroObject.dw_UseMedicineTime = HumData.nReserved3;
            // 使用药酒时间,计算长时间没使用药酒 20080623
            HeroObject.n_MedicineLevel = HumData.n_Reserved3;
            // 药力值等级 20080623
            if (HeroObject.n_MedicineLevel <= 0)
            {
                HeroObject.n_MedicineLevel = 1;
            }
            // 如果药力值等级为0,则设置为1 20080624
            if (HeroObject.m_Abil.MaxMedicineValue <= 0)
            {
                // 药力值经验为0时,取设置的经验 20080624
                HeroObject.m_Abil.MaxMedicineValue = HeroObject.GetMedicineExp(HeroObject.n_MedicineLevel);
            }
            // if HeroObject.m_Abil.Exp <= 0 then HeroObject.m_Abil.Exp := 1;
            // if HeroObject.m_Abil.MaxExp <= 0 then begin
            // HeroObject.m_Abil.MaxExp := HeroObject.GetLevelExp(HeroObject.m_Abil.Level);
            // end;
            // PlayObject.m_Abil:=HumData.Abil;
            HeroObject.m_wStatusTimeArr = HumData.wStatusTimeArr;
            HeroObject.m_sHomeMap = HumData.sHomeMap;
            HeroObject.m_nHomeX = HumData.wHomeX;
            HeroObject.m_nHomeY = HumData.wHomeY;
            HeroObject.m_BonusAbil = HumData.BonusAbil;
            // 20081126 英雄永久属性
            HeroObject.m_nBonusPoint = HumData.nBonusPoint;
            // 08/09
            HeroObject.m_btCreditPoint = HumData.btCreditPoint;
            HeroObject.m_btReLevel = HumData.btReLevel;
            HeroObject.m_nWinExp = HumData.n_WinExp;
            // 英雄累计经验值 20080110
            HeroObject.m_nLoyal = HumData.nLoyal;
            if (HeroObject.m_nLoyal > 10000)
            {
                HeroObject.m_nLoyal = 10000;
            }
            HeroObject.m_btLastOutStatus = HumData.btLastOutStatus;
            // 退出状态 1为死亡
            // HeroObject.m_sMasterName := m_Master.;
            // HeroObject.m_boMaster := HumData.boMaster;
            // HeroObject.m_sDearName := HumData.sDearName;
            // HeroObject.m_sStoragePwd := HumData.sStoragePwd;
            // if PlayObject.m_sStoragePwd <> '' then
            // PlayObject.m_boPasswordLocked := True;
            // PlayObject.m_nGameGold := HumData.nGameGold;
            // PlayObject.m_nGamePoint := HumData.nGamePoint;
            // PlayObject.m_nPayMentPoint := HumData.nPayMentPoint;
            HeroObject.m_nPkPoint = HumData.nPKPOINT;
            // if HumData.btAllowGroup > 0 then PlayObject.m_boAllowGroup := True
            // else PlayObject.m_boAllowGroup := False;
            HeroObject.btB2 = HumData.btF9;
            HeroObject.m_btAttatckMode = HumData.btAttatckMode;
            HeroObject.m_nIncHealth = HumData.btIncHealth;
            HeroObject.m_nIncSpell = HumData.btIncSpell;
            HeroObject.m_nIncHealing = HumData.btIncHealing;
            HeroObject.m_nFightZoneDieCount = HumData.btFightZoneDieCount;
            // HeroObject.m_sUserID := HumData.sAccount;
            // HeroObject.nC4 := HumData.btEE;//20081007 注释，nC4无实际用处
            HeroObject.n_HeroTpye = HumData.btEF;
            // 英雄类型 0-白日门英雄 1-卧龙英雄 20080514
            // HeroObject.m_boLockLogon := HumData.boLockLogon;
            // HeroObject.m_wContribution := HumData.wContribution;
            // HeroObject.m_nHungerStatus := HumData.nHungerStatus;
            // HeroObject.m_boAllowGuildReCall := HumData.boAllowGuildReCall;
            // HeroObject.m_wGroupRcallTime := HumData.wGroupRcallTime;
            HeroObject.m_dBodyLuck = HumData.dBodyLuck;
            // HeroObject.m_boAllowGroupReCall := HumData.boAllowGroupReCall;
            // PlayObject.m_wMasterCount := HumData.wMasterCount; //出师徒弟数
            HeroObject.m_QuestFlag = HumData.QuestFlag;
            // HeroObject.m_boHasHero := HumData.boHasHero;
            HeroObject.m_btStatus = HumData.btStatus;
            // 英雄的状态 20080717
            if (HeroObject.m_Abil.Level <= 22)
            {
                HeroObject.m_btStatus = 1;
            }
            // 20080710 22级之前,默认跟随
            HumItems = HumanRcd.Data.HumItems;
            HeroObject.m_UseItems[Grobal2.U_DRESS] = HumItems[Grobal2.U_DRESS];
            HeroObject.m_UseItems[Grobal2.U_WEAPON] = HumItems[Grobal2.U_WEAPON];
            HeroObject.m_UseItems[Grobal2.U_RIGHTHAND] = HumItems[Grobal2.U_RIGHTHAND];
            HeroObject.m_UseItems[Grobal2.U_NECKLACE] = HumItems[Grobal2.U_HELMET];
            HeroObject.m_UseItems[Grobal2.U_HELMET] = HumItems[Grobal2.U_NECKLACE];
            HeroObject.m_UseItems[Grobal2.U_ARMRINGL] = HumItems[Grobal2.U_ARMRINGL];
            HeroObject.m_UseItems[Grobal2.U_ARMRINGR] = HumItems[Grobal2.U_ARMRINGR];
            HeroObject.m_UseItems[Grobal2.U_RINGL] = HumItems[Grobal2.U_RINGL];
            HeroObject.m_UseItems[Grobal2.U_RINGR] = HumItems[Grobal2.U_RINGR];
            HumAddItems = HumanRcd.Data.HumAddItems;
            HeroObject.m_UseItems[Grobal2.U_BUJUK] = HumAddItems[Grobal2.U_BUJUK];
            HeroObject.m_UseItems[Grobal2.U_BELT] = HumAddItems[Grobal2.U_BELT];
            HeroObject.m_UseItems[Grobal2.U_BOOTS] = HumAddItems[Grobal2.U_BOOTS];
            HeroObject.m_UseItems[Grobal2.U_CHARM] = HumAddItems[Grobal2.U_CHARM];
            HeroObject.m_UseItems[Grobal2.U_ZHULI] = HumAddItems[Grobal2.U_ZHULI];
            // 20080416 斗笠
            HeroObject.m_HumPulses[0] = HumanRcd.Data.HumPulses[0];
            HeroObject.m_HumPulses[1] = HumanRcd.Data.HumPulses[1];
            HeroObject.m_HumPulses[2] = HumanRcd.Data.HumPulses[2];
            HeroObject.m_HumPulses[3] = HumanRcd.Data.HumPulses[3];
            // 人物经络
            HeroObject.m_nBatterOrder[0] = HumanRcd.Data.BatterMagicOrder[0];
            // 连击循序
            HeroObject.m_nBatterOrder[1] = HumanRcd.Data.BatterMagicOrder[1];
            // 连击循序
            HeroObject.m_nBatterOrder[2] = HumanRcd.Data.BatterMagicOrder[2];
            // 连击循序
            HeroObject.m_boisOpenPuls = HumanRcd.Data.m_boIsOpenPuls;
            // (英雄) 是否打开经络
           // HeroObject.m_nPulseExp = HumanRcd.Data.m_nPulseExp;
            // (英雄) 经络修炼经验
            BagItems = HumanRcd.Data.BagItems;
            for (I = BagItems.GetLowerBound(0); I <= BagItems.GetUpperBound(0); I++)
            {
                if (BagItems[I].wIndex > 0)
                {
                    UserItem = new TUserItem();
                    
                    //FillChar(UserItem, sizeof(TUserItem), '\0');
                    // 20080820 增加
                    // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);//20080820 增加
                    UserItem = BagItems[I];
                    HeroObject.m_ItemList.Add(UserItem);
                }
            }
            HumMagics = HumanRcd.Data.HumMagics;
            for (I = HumMagics.GetLowerBound(0); I <= HumMagics.GetUpperBound(0); I++)
            {
                MagicInfo = M2Share.UserEngine.FindHeroMagic(HumMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = new TUserMagic();
                    UserMagic.MagicInfo = MagicInfo;
                    UserMagic.wMagIdx = HumMagics[I].wMagIdx;
                    UserMagic.btLevel = HumMagics[I].btLevel;
                    UserMagic.btKey = HumMagics[I].btKey;
                    // 魔法快捷键(即魔法开关)
                    UserMagic.nTranPoint = HumMagics[I].nTranPoint;
                    HeroObject.m_MagicList.Add(UserMagic);
                }
            }
            HumNGMagics = HumanRcd.Data.HumNGMagics;
            // 20081001 内功技能
            for (I = HumNGMagics.GetLowerBound(0); I <= HumNGMagics.GetUpperBound(0); I++)
            {
                // 内功技能 20081001
                MagicInfo = M2Share.UserEngine.FindMagic(HumNGMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = new TUserMagic();
                    UserMagic.MagicInfo = MagicInfo;
                    UserMagic.wMagIdx = HumNGMagics[I].wMagIdx;
                    UserMagic.btLevel = HumNGMagics[I].btLevel;
                    UserMagic.btKey = HumNGMagics[I].btKey;
                    UserMagic.nTranPoint = HumNGMagics[I].nTranPoint;
                    HeroObject.m_MagicList.Add(UserMagic);
                }
            }
            HumBatterMagics = HumanRcd.Data.HumBatterMagics;
            // 20091211 连击技能
            for (I = HumBatterMagics.GetLowerBound(0); I <= HumBatterMagics.GetUpperBound(0); I++)
            {
                // 连击技能 20091211
                MagicInfo = M2Share.UserEngine.FindHeroMagic(HumBatterMagics[I].wMagIdx);
                if (MagicInfo != null)
                {
                    UserMagic = new TUserMagic();
                    UserMagic.MagicInfo = MagicInfo;
                    UserMagic.wMagIdx = HumBatterMagics[I].wMagIdx;
                    UserMagic.btLevel = HumBatterMagics[I].btLevel;
                    UserMagic.btKey = HumBatterMagics[I].btKey;
                    UserMagic.nTranPoint = HumBatterMagics[I].nTranPoint;
                    HeroObject.m_MagicList.Add(UserMagic);
                }
            }
            HeroObject.m_btMentHero = HumanRcd.Data.m_btFHeroType;
        }

        // 取英雄的数据
        // 取回城数据
        private string GetHomeInfo(ref int nX, ref int nY)
        {
            string result;
            int I;
            lock (M2Share.g_StartPointList)
            try {
                if (M2Share.g_StartPointList.Count > 0)
                {
                    // 1
                    if (M2Share.g_StartPointList.Count > M2Share.g_Config.nStartPointSize)
                    {
                        // 2
                        I = HUtil32.Random(M2Share.g_Config.nStartPointSize);
                    }
                    else
                    {
                        I = 0;
                    }
                    result = M2Share.GetStartPointInfo(I, ref nX, ref nY);
                }
                else
                {
                    result = M2Share.g_Config.sHomeMap;
                    nX = M2Share.g_Config.nHomeX;
                    nX = M2Share.g_Config.nHomeY;
                }
            } finally {
                
            }
            return result;
        }

        private int GetRandHomeX(TPlayObject PlayObject)
        {
            int result;
            result = HUtil32.Random(3) + (PlayObject.m_nHomeX - 2);
            return result;
        }

        private int GetRandHomeY(TPlayObject PlayObject)
        {
            int result;
            result = HUtil32.Random(3) + (PlayObject.m_nHomeY - 2);
            return result;
        }

        private void LoadSwitchData(TSwitchDataInfo SwitchData, ref TPlayObject PlayObject)
        {
            int nCount;
            TSlaveInfo SlaveInfo;
            if (SwitchData.boC70)
            {
            }
            PlayObject.m_boBanShout = SwitchData.boBanShout;
            PlayObject.m_boHearWhisper = SwitchData.boHearWhisper;
            PlayObject.m_boBanGuildChat = SwitchData.boBanGuildChat;
            PlayObject.m_boBanGuildChat = SwitchData.boBanGuildChat;
            PlayObject.m_boAdminMode = SwitchData.boAdminMode;
            PlayObject.m_boObMode = SwitchData.boObMode;
            nCount = 0;
            while (true)
            {
                if (SwitchData.BlockWhisperArr[nCount] == "")
                {
                    break;
                }
                PlayObject.m_BlockWhisperList.Add(SwitchData.BlockWhisperArr[nCount]);
                nCount ++;
                if (nCount >= SwitchData.BlockWhisperArr.GetUpperBound(0))
                {
                    break;
                }
            }
            nCount = 0;
            while (true)
            {
                if (SwitchData.SlaveArr[nCount].sSalveName == "")
                {
                    break;
                }
                SlaveInfo = new TSlaveInfo();
                SlaveInfo = SwitchData.SlaveArr[nCount];
                //PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_10401, 0, (int)SlaveInfo, 0, 0, "", 500);
                nCount ++;
                if (nCount >= 5)
                {
                    break;
                }
            }
            nCount = 0;
            while (true)
            {
                PlayObject.m_wStatusArrValue[nCount] = SwitchData.StatusValue[nCount];
                PlayObject.m_dwStatusArrTimeOutTick[nCount] = SwitchData.StatusTimeOut[nCount];
                nCount ++;
                if (nCount >= 6)
                {
                    break;
                }
            }
        }

        private void DelSwitchData(TSwitchDataInfo SwitchData)
        {
            int I;
            TSwitchDataInfo SwitchDataInfo;
            I = 0;
            while (true)
            {
                // for i := 0 to m_ChangeServerList.Count - 1 do begin
                if (I >= m_ChangeServerList.Count)
                {
                    break;
                }
                if (m_ChangeServerList.Count <= 0)
                {
                    break;
                }
                SwitchDataInfo = m_ChangeServerList[I];
                if ((SwitchDataInfo != null) && (SwitchDataInfo == SwitchData))
                {
                    Dispose(SwitchDataInfo);
                    m_ChangeServerList.RemoveAt(I);
                    break;
                }
                I ++;
            }
            // for

        }

        // 查找魔法
        public TMagic FindMagic(int nMagIdx)
        {
            TMagic result;
            int I;
            TMagic Magic;
            IList<TMagic> MagicList;
            result = null;
            if (m_boStartLoadMagic && (OldMagicList.Count > 0))
            {
                MagicList = OldMagicList;
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        // 20081008
                        for (I = 0; I < MagicList.Count; I ++ )
                        {
                            Magic = MagicList[I];
                            if ((Magic != null) && ((Magic.sDescr == "") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                            {
                                if (Magic.wMagicId == nMagIdx)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    // for
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MagicList.Count; I ++ )
                    {
                        Magic = m_MagicList[I];
                        if ((Magic != null) && ((Magic.sDescr == "") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                        {
                            if (Magic.wMagicId == nMagIdx)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                // for
                }
            }
            return result;
        }

        public TMagic FindHeroMagic(int nMagIdx)
        {
            TMagic result;
            int I;
            TMagic Magic;
            IList<TMagic> MagicList = null;
            result = null;
            if (m_boStartLoadMagic && (OldMagicList.Count > 0))
            {
                //MagicList = ((OldMagicList[OldMagicList.Count - 1]) as ArrayList);
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        // 20081008
                        for (I = 0; I < MagicList.Count; I ++ )
                        {
                            Magic = MagicList[I];
                            if ((Magic != null) && ((Magic.sDescr == "英雄") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                            {
                                if (Magic.wMagicId == nMagIdx)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    // for
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MagicList.Count; I ++ )
                    {
                        Magic = m_MagicList[I];
                        if ((Magic != null) && ((Magic.sDescr == "英雄") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                        {
                            if (Magic.wMagicId == nMagIdx)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                // for
                }
            }
            return result;
        }

        // 怪物初始化
        private void MonInitialize(TBaseObject BaseObject, string sMonName)
        {
            int I;
            TMonInfo Monster;
            byte nCode;
            nCode = 0;
            try {
                if (MonsterList.Count > 0)
                {
                    nCode = 1;
                    for (I = 0; I < MonsterList.Count; I ++ )
                    {
                        Monster = MonsterList[I];
                        nCode = 2;
                        if (Monster != null)
                        {
                            nCode = 3;
                            if (((Monster.sName).ToLower().CompareTo((sMonName).ToLower()) == 0) && (BaseObject != null))
                            {
                                nCode = 4;
                                BaseObject.m_btRaceServer = Monster.btRace;
                                BaseObject.m_btRaceImg = Monster.btRaceImg;
                                BaseObject.m_wAppr = Monster.wAppr;
                                BaseObject.m_Abil.Level = Monster.wLevel;
                                BaseObject.m_btLifeAttrib = Monster.btLifeAttrib;
                                // 不死系
                                BaseObject.m_btCoolEye = Monster.wCoolEye;
                                // 可视范围
                                BaseObject.m_dwFightExp = Monster.dwExp;
                                BaseObject.m_Abil.HP = Monster.wHP;
                                BaseObject.m_Abil.MaxHP = Monster.wHP;
                                nCode = 5;

                                BaseObject.m_btMonsterWeapon = (byte)Monster.wMP;
                               // BaseObject.m_btMonsterWeapon = LoByte(Monster.wMP);
                                // BaseObject.m_Abil.MP:=Monster.wMP;
                                BaseObject.m_Abil.MP = 0;
                                BaseObject.m_Abil.MaxMP = Monster.wMP;
                                nCode = 6;
                                
                                BaseObject.m_Abil.AC = MakeLong(Monster.wAC, Monster.wAC);
                                
                                BaseObject.m_Abil.MAC = MakeLong(Monster.wMAC, Monster.wMAC);
                                
                                BaseObject.m_Abil.DC = MakeLong(Monster.wDC, Monster.wMaxDC);
                                
                                BaseObject.m_Abil.MC = MakeLong(Monster.wMC, Monster.wMC);
                                
                                BaseObject.m_Abil.SC = MakeLong(Monster.wSC, Monster.wSC);
                                nCode = 7;
                                BaseObject.m_btSpeedPoint = (byte)HUtil32._MIN(Byte.MaxValue, Monster.wSpeed);
                                // 20081204 由于 m_btSpeedPoint为Byte，所以需判断
                                nCode = 8;
                                BaseObject.m_btHitPoint = (byte)HUtil32._MIN(Byte.MaxValue, Monster.wHitPoint);
                                // 20081204 由于 m_btHitPoint为Byte，所以需判断
                                nCode = 9;
                                BaseObject.m_nWalkSpeed = Monster.wWalkSpeed;
                                // 行走速度
                                BaseObject.m_nWalkStep = Monster.wWalkStep;
                                BaseObject.m_dwWalkWait = Monster.wWalkWait;
                                BaseObject.m_nNextHitTime = Monster.wAttackSpeed;
                                // 攻击速度
                                nCode = 10;
                                break;
                            }
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.MonInitialize Name:" + sMonName + " Code:" + (nCode).ToString());
            }
        }

        // 打开门
        public bool OpenDoor(TEnvirnoment Envir, int nX, int nY)
        {
            bool result;
            TDoorInfo Door;
            result = false;
            Door = Envir.GetDoor(nX, nY);
            if ((Door != null) && !Door.Status.boOpened && !Door.Status.bo01)
            {
                Door.Status.boOpened = true;
                Door.Status.dwOpenTick = GetTickCount();
                SendDoorStatus(Envir, nX, nY, Grobal2.RM_DOOROPEN, 0, nX, nY, 0, "");
                result = true;
            }
            return result;
        }

        // 关闭门
        public bool CloseDoor(TEnvirnoment Envir, TDoorInfo Door)
        {
            bool result;
            result = false;
            if ((Door != null) && (Door.Status.boOpened))
            {
                Door.Status.boOpened = false;
                SendDoorStatus(Envir, Door.nX, Door.nY, Grobal2.RM_DOORCLOSE, 0, Door.nX, Door.nY, 0, "");
                result = true;
            }
            return result;
        }

        // 发送门的状态
        public void SendDoorStatus(TEnvirnoment Envir, int nX, int nY, ushort wIdent, ushort wX, int nDoorX, int nDoorY, int nA, string sStr)
        {
            int I;
            int n10;
            int n14;
            int n1C;
            int n20;
            int n24;
            int n28;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TBaseObject BaseObject;
            n1C = nX - 12;
            n24 = nX + 12;
            n20 = nY - 12;
            n28 = nY + 12;
            if (n1C < 0)
            {
                n1C = 0;
            }
            // 20080629
            if (n20 < 0)
            {
                n20 = 0;
            }
            // 20080629
            if (Envir != null)
            {
                for (n10 = n1C; n10 <= n24; n10 ++ )
                {
                    for (n14 = n20; n14 <= n28; n14 ++ )
                    {
                        MapCellInfo = new TMapCellinfo();
                        if (Envir.GetMapCellInfo(n10, n14, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                        {
                            if (MapCellInfo.ObjList.Count > 0)
                            {
                                // 20080629
                                for (I = 0; I < MapCellInfo.ObjList.Count; I ++ )
                                {
                                    OSObject = ((TOSObject)(MapCellInfo.ObjList[I]));
                                    if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                    {
                                        BaseObject = ((TBaseObject)(OSObject.CellObj));
                                        if ((BaseObject != null) && (!BaseObject.m_boGhost) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                        {
                                            BaseObject.SendMsg(BaseObject, wIdent, wX, nDoorX, nDoorY, nA, sStr);
                                        }
                                    }
                                }
                            // for
                            }
                        }
                    }
                }
            }
        }

        private void ProcessMapDoor()
        {
            int I;
            int II;
            TEnvirnoment Envir;
            TDoorInfo Door;
            if (M2Share.g_MapManager.m_MapList.Count > 0)
            {
                // 20081008
                for (I = 0; I < M2Share.g_MapManager.m_MapList.Count; I ++ )
                {
                    Envir = ((TEnvirnoment)(M2Share.g_MapManager.m_MapList[I]));
                    if (Envir != null)
                    {
                        if (Envir.m_DoorList.Count > 0)
                        {
                            // 20081008
                            for (II = 0; II < Envir.m_DoorList.Count; II ++ )
                            {
                                Door = Envir.m_DoorList[II];
                                if (Door != null)
                                {
                                    if (Door.Status.boOpened)
                                    {
                                        // 5 * 1000
                                        if ((GetTickCount() - Door.Status.dwOpenTick) > 5000)
                                        {
                                            CloseDoor(Envir, Door);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // -----------------------------------------------------------------------------
        // 闪电  地上冒岩浆 20080327
        private void ProcessEffects()
        {
            // 20080327
            // , III
            int I;
            int II;
            int X;
            int Y;
            TEnvirnoment Envir;
            int Amount;
            if (m_boProcessEffects)
            {
                return;
            }
            m_boProcessEffects = true;
            try {
                try {
                    if (EffectList.Count > 0)
                    {
                        // 20080629
                        for (I = 0; I < EffectList.Count; I ++ )
                        {
                            Envir = ((TEnvirnoment)(EffectList[I]));
                            if (Envir != null)
                            {
                                if ((Envir.nThunder != 0) || (Envir.nLava != 0))
                                {
                                    // 闪电,岩浆效果
                                    Amount = GetMapHuman(Envir.sMapName);
                                    // 取地图人物数
                                    if (Amount == 0)
                                    {
                                        continue;
                                    }
                                    // Amount:=(Amount * 2) * ((Envir.m_nWidth * Envir.m_nHeight) div {2500}3500);
                                    // Amount *
                                    Amount = (Envir.m_nWidth * Envir.m_nHeight) / 3200;
                                    for (II = 0; II <= Amount; II ++ )
                                    {
                                        // 0-50
                                        X = HUtil32.Random(Envir.m_nWidth);
                                        Y = HUtil32.Random(Envir.m_nHeight);
                                        if (Envir.CanWalk(X, Y, true))
                                        {
                                            EffectTarget(X, Y, Envir);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch {
                    M2Share.MainOutMessage("{异常} TUserEngine.ProcessEffects");
                }
            } finally {
                m_boProcessEffects = false;
            }
        }

        // 20080327
        private void EffectTarget(int x, int y, TEnvirnoment Envir)
        {
            TBaseObject Target;
            TBaseObject BaseObject;
            int Dmg;
            int magpwr;
            int i;
            TBaseObject freshbaseobject;
            byte nCode;
            Dmg = 0;
            // 20080522
            nCode = 0;
            try {
                Target = FindNearbyTarget(x, y, Envir, m_TargetList);
                // 查找目标
                nCode = 22;
                if ((Target == null))
                {
                    return;
                }
                nCode = 1;
                if (HUtil32.Random(3) == 0)
                {
                    x = Target.m_nCurrX;
                    y = Target.m_nCurrY;
                }
                else
                {
                    // 20080726 增加
                    Envir.GetNextPosition(Target.m_nCurrX, Target.m_nCurrY, HUtil32.Random(8), HUtil32.Random(4) + 1, ref x, ref y);
                }
                nCode = 2;
                // xTargetList := TList.Create;
                m_TargetList.Clear();
                if ((Envir.nThunder != 0) && (Envir.nLava != 0))
                {
                    switch(HUtil32.Random(2))
                    {
                        case 0:
                            nCode = 3;
                            if (Envir.nThunder != 0)
                            {
                                nCode = 4;
                                Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 10, "");
                                nCode = 5;
                                Dmg = Envir.nThunder;
                                nCode = 6;
                                Envir.GeTBaseObjects(x, y, true, m_TargetList);
                            }
                            break;
                        case 1:
                            if (Envir.nLava != 0)
                            {
                                nCode = 7;
                                Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 11, "");
                                nCode = 8;
                                Dmg = Envir.nLava;
                                nCode = 9;
                                Envir.GetRangeBaseObject(x, y, 1, true, m_TargetList);
                            }
                            break;
                    }
                // case Random(2) of
                }
                else
                {
                    if (Envir.nThunder != 0)
                    {
                        nCode = 10;
                        Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 10, "");
                        nCode = 11;
                        Dmg = Envir.nThunder;
                        nCode = 12;
                        Envir.GeTBaseObjects(x, y, true, m_TargetList);
                    }
                    if (Envir.nLava != 0)
                    {
                        nCode = 13;
                        Target.SendRefMsg(Grobal2.RM_10205, 0, x, y, 11, "");
                        nCode = 14;
                        Dmg = Envir.nLava;
                        nCode = 15;
                        Envir.GetRangeBaseObject(x, y, 1, true, m_TargetList);
                    }
                }
                freshbaseobject = new TBaseObject();
                if ((m_TargetList.Count > 0))
                {
                    for (i = m_TargetList.Count - 1; i >= 0; i-- )
                    {
                        nCode = 17;
                        BaseObject = ((TBaseObject)(m_TargetList[i]));
                        if ((BaseObject != null))
                        {
                            // (Target.IsProperFriend(BaseObject) or (Target = BaseObject))
                            if (((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_Master != null)) && (BaseObject.m_PEnvir == Envir))
                            {
                                nCode = 18;
                                magpwr = (Dmg - (Dmg / 3)) + HUtil32.Random(Dmg / 3);
                                // 20080412 损害值
                                nCode = 19;
                                BaseObject.SendDelayMsg(freshbaseobject, Grobal2.RM_MAGSTRUCK, 0, magpwr, 1, 0, "", 600);
                            }
                            m_TargetList.RemoveAt(i);
                        }
                    }
                }
                nCode = 20;
                // xTargetList.Free;
                freshbaseobject.Dispose(freshbaseobject);
                //freshbaseobject.Destroy();
                nCode = 21;
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.EffectTarget Code:" + (nCode).ToString());
            }
        }

        // 20080327
        private TBaseObject FindNearbyTarget(int x, int y, TEnvirnoment Envir, ArrayList xTargetList)
        {
            TBaseObject result;
            // xTargetList:TList;
            // dist:Integer;
            TBaseObject BaseObject;
            int nRage;
            int i;
            // dist:= 999;
            nRage = 11;
            result = null;
            try {
                xTargetList.Clear();
                // xTargetList := TList.Create;
                Envir.GetRangeBaseObject(x, y, nRage, true, xTargetList);
                // 不包括死的对像
                if (xTargetList.Count > 0)
                {
                    // 20080629
                    for (i = 0; i < xTargetList.Count; i ++ )
                    {
                        BaseObject = ((TBaseObject)(xTargetList[i]));
                        if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_Master != null))
                        {
                            // 20080418 增加or (BaseObject.m_Master <> nil)
                            // if abs(BaseObject.m_nCurrX - x) + abs(BaseObject.m_nCurrY - y) < dist then begin
                            // dist := abs(BaseObject.m_nCurrX - x)+ abs(BaseObject.m_nCurrY - y);//20080726
                            result = BaseObject;
                            // if (BaseObject.m_nCurrX = x) and (BaseObject.m_nCurrY = y) then exit;//20080726
                            break;
                        // 20080726
                        // end;
                        }
                    }
                }
            // xTargetList.Free;
            }
            catch {
            }
            return result;
        }

        // -----------------------------------------------------------------------------
        private void ProcessEvents()
        {
            int I;
            int II;
            int III;
            TMagicEvent MagicEvent;
            TBaseObject BaseObject;
            for (I = m_MagicEventList.Count - 1; I >= 0; I-- )
            {
                if (m_MagicEventList.Count <= 0)
                {
                    break;
                }
                MagicEvent = m_MagicEventList[I];
                if ((MagicEvent != null))
                {
                    if ((MagicEvent.BaseObjectList != null))
                    {
                        for (II = MagicEvent.BaseObjectList.Count - 1; II >= 0; II-- )
                        {
                            if (MagicEvent.BaseObjectList.Count <= 0)
                            {
                                break;
                            }
                            // 20081008
                            BaseObject = ((TBaseObject)(MagicEvent.BaseObjectList[II]));
                            if (BaseObject != null)
                            {
                                if (BaseObject.m_boDeath || (BaseObject.m_boGhost) || (!BaseObject.m_boHolySeize))
                                {
                                    MagicEvent.BaseObjectList.RemoveAt(II);
                                }
                            }
                        }
                        // for
                        
                        
                        if ((MagicEvent.BaseObjectList.Count <= 0) || ((GetTickCount() - MagicEvent.dwStartTick) > MagicEvent.dwTime) || ((GetTickCount() - MagicEvent.dwStartTick) > 180000))
                        {
                            Dispose(MagicEvent.BaseObjectList);
                            //MagicEvent.BaseObjectList.Free;
                            III = 0;
                            while (true)
                            {
                                if (MagicEvent.Events[III] != null)
                                {
                                    ((TEvent)(MagicEvent.Events[III])).Close();
                                }
                                III ++;
                                if (III >= 8)
                                {
                                    break;
                                }
                            }
                            
                            Dispose(MagicEvent);
                            m_MagicEventList.RemoveAt(I);
                        }
                    }
                }
            }
        }

        public bool AddMagic(TMagic Magic)
        {
            bool result;
            TMagic UserMagic;
            result = false;
            UserMagic = new TMagic();
            UserMagic.wMagicId = Magic.wMagicId;
            UserMagic.sMagicName = Magic.sMagicName;
            UserMagic.btEffectType = Magic.btEffectType;
            UserMagic.btEffect = Magic.btEffect;
            // UserMagic.bt11 := Magic.bt11;
            UserMagic.wSpell = Magic.wSpell;
            UserMagic.wPower = Magic.wPower;
            UserMagic.TrainLevel = Magic.TrainLevel;
            // UserMagic.w02 := Magic.w02;
            UserMagic.MaxTrain = Magic.MaxTrain;
            UserMagic.btTrainLv = Magic.btTrainLv;
            UserMagic.btJob = Magic.btJob;
            // UserMagic.wMagicIdx := Magic.wMagicIdx;
            UserMagic.dwDelayTime = Magic.dwDelayTime;
            UserMagic.btDefSpell = Magic.btDefSpell;
            UserMagic.btDefPower = Magic.btDefPower;
            UserMagic.wMaxPower = Magic.wMaxPower;
            UserMagic.btDefMaxPower = Magic.btDefMaxPower;
            UserMagic.sDescr = Magic.sDescr;
            m_MagicList.Add(UserMagic);
            result = true;
            return result;
        }

        public bool DelMagic(ushort wMagicId)
        {
            bool result;
            int I;
            TMagic Magic;
            result = false;
            for (I = m_MagicList.Count - 1; I >= 0; I-- )
            {
                if (m_MagicList.Count <= 0)
                {
                    break;
                }
                Magic = ((TMagic)(m_MagicList[I]));
                if (Magic != null)
                {
                    if (Magic.wMagicId == wMagicId)
                    {
                        
                        Dispose(Magic);
                        m_MagicList.RemoveAt(I);
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public TMagic FindHeroMagic(string sMagicName)
        {
            TMagic result;
            int I;
            TMagic Magic;
            IList<TMagic> MagicList;
            result = null;
            if (m_boStartLoadMagic && (OldMagicList.Count > 0))
            {
                MagicList = OldMagicList;
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        // 20081008
                        for (I = 0; I < MagicList.Count; I ++ )
                        {
                            Magic = MagicList[I];
                            if ((Magic != null) && ((Magic.sDescr == "英雄") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                            {
                                if ((Magic.sMagicName).ToLower().CompareTo((sMagicName).ToLower()) == 0)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    // for
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MagicList.Count; I ++ )
                    {
                        Magic = m_MagicList[I];
                        if ((Magic != null) && ((Magic.sDescr == "英雄") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                        {
                            if ((Magic.sMagicName).ToLower().CompareTo((sMagicName).ToLower()) == 0)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                // fof
                }
            }
            return result;
        }

        public TMagic FindMagic(string sMagicName)
        {
            TMagic result;
            int I;
            TMagic Magic;
            IList<TMagic> MagicList;
            result = null;
            if (m_boStartLoadMagic && (OldMagicList.Count > 0))
            {
                MagicList = OldMagicList;
                if (MagicList != null)
                {
                    if (MagicList.Count > 0)
                    {
                        // 20081008
                        for (I = 0; I < MagicList.Count; I ++ )
                        {
                            Magic = MagicList[I];
                            if ((Magic != null) && ((Magic.sDescr == "") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                            {
                                if ((Magic.sMagicName).CompareTo((sMagicName).ToLower()) == 0)
                                {
                                    result = Magic;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MagicList.Count; I ++ )
                    {
                        Magic = m_MagicList[I];
                        if ((Magic != null) && ((Magic.sDescr == "") || (Magic.sDescr == "内功") || (Magic.sDescr == "连击")))
                        {
                            if ((Magic.sMagicName).CompareTo((sMagicName).ToLower()) == 0)
                            {
                                result = Magic;
                                break;
                            }
                        }
                    }
                // for
                }
            }
            return result;
        }

        // 20081217 检查地图指定坐标指定名称怪物数量
        // 取地图范围内有怪
        public int GetMapRangeMonster(TEnvirnoment Envir, int nX, int nY, int nRange, ArrayList List)
        {
            int result;
            int I;
            int II;
            TMonGenInfo MonGen;
            TBaseObject BaseObject;
            result = 0;
            if (Envir == null)
            {
                return result;
            }
            if (m_MonGenList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_MonGenList.Count; I ++ )
                {
                    MonGen = m_MonGenList[I];
                    if ((MonGen.Envir != null) && (MonGen.Envir != Envir))
                    {
                        continue;
                    }
                    if (MonGen.CertList.Count > 0)
                    {
                        // 20081008
                        for (II = 0; II < MonGen.CertList.Count; II ++ )
                        {
                            BaseObject = ((TBaseObject)(MonGen.CertList[II]));
                            if (BaseObject != null)
                            {
                                if (!BaseObject.m_boDeath && !BaseObject.m_boGhost && (BaseObject.m_PEnvir == Envir) && (Math.Abs(BaseObject.m_nCurrX - nX) <= nRange) && (Math.Abs(BaseObject.m_nCurrY - nY) <= nRange))
                                {
                                    if (List != null)
                                    {
                                        List.Add(BaseObject);
                                    }
                                    result ++;
                                }
                            }
                        }
                    // for
                    }
                }
            }
            return result;
        }

        // 增加交易NPC
        public void AddMerchant(TMerchant Merchant)
        {
            //M2Share.UserEngine.m_MerchantList.__Lock();
            try {
                M2Share.UserEngine.m_MerchantList.Add(Merchant);
            } finally {
                //M2Share.UserEngine.m_MerchantList.UnLock();
            }
        }

        // 取交易NPC列表
        public int GetMerchantList(TEnvirnoment Envir, int nX, int nY, int nRange, ArrayList TmpList)
        {
            int result;
            int I;
            TMerchant Merchant;
            //m_MerchantList.__Lock();
            try {
                if (m_MerchantList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MerchantList.Count; I ++ )
                    {
                        Merchant = ((TMerchant)(m_MerchantList[I]));
                        if (Merchant != null)
                        {
                            if ((Merchant.m_PEnvir == Envir) && (Math.Abs(Merchant.m_nCurrX - nX) <= nRange) && (Math.Abs(Merchant.m_nCurrY - nY) <= nRange))
                            {
                                TmpList.Add(Merchant);
                            }
                        }
                    }
                // for
                }
            } finally {
                //m_MerchantList.UnLock();
            }
            result = TmpList.Count;
            return result;
        }

        // 取NPC列表
        public int GetNpcList(TEnvirnoment Envir, int nX, int nY, int nRange, ArrayList TmpList)
        {
            int result;
            int I;
            TNormNpc NPC;
            if (QuestNPCList.Count > 0)
            {
                // 20081008
                for (I = 0; I < QuestNPCList.Count; I ++ )
                {
                    NPC = ((TNormNpc)(QuestNPCList[I]));
                    if (NPC != null)
                    {
                        if ((NPC.m_PEnvir == Envir) && (Math.Abs(NPC.m_nCurrX - nX) <= nRange) && (Math.Abs(NPC.m_nCurrY - nY) <= nRange))
                        {
                            TmpList.Add(NPC);
                        }
                    }
                }
            // for
            }
            result = TmpList.Count;
            return result;
        }

        // 重新加载NPC列表
        public void ReloadMerchantList()
        {
            int I;
            TMerchant Merchant;
            //m_MerchantList.__Lock();
            try {
                if (m_MerchantList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MerchantList.Count; I ++ )
                    {
                        Merchant = ((TMerchant)(m_MerchantList[I]));
                        if (Merchant != null)
                        {
                            if (!Merchant.m_boGhost)
                            {
                                Merchant.ClearScript();
                                Merchant.LoadNpcScript();
                            }
                        }
                    }
                // for
                }
            } finally {
                //m_MerchantList.UnLock();
            }
        }

        // 重读NPC脚本
        public void ReloadNpcList()
        {
            int I;
            TNormNpc NPC;
            if (QuestNPCList.Count > 0)
            {
                // 20081008
                for (I = 0; I < QuestNPCList.Count; I ++ )
                {
                    NPC = ((TNormNpc)(QuestNPCList[I]));
                    if (NPC != null)
                    {
                        NPC.ClearScript();
                        NPC.LoadNpcScript();
                    }
                }
            }
        }

        // 取地图怪物数量 20080123
        public int GetMapMonster(TEnvirnoment Envir, ArrayList List)
        {
            int result;
            int I;
            int II;
            TMonGenInfo MonGen;
            TBaseObject BaseObject;
            result = 0;
            if (Envir == null)
            {
                return result;
            }
            if (m_MonGenList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_MonGenList.Count; I ++ )
                {
                    MonGen = m_MonGenList[I];
                    if (MonGen == null)
                    {
                        continue;
                    }
                    if (MonGen.CertList.Count > 0)
                    {
                        // 20081008
                        for (II = 0; II < MonGen.CertList.Count; II ++ )
                        {
                            BaseObject = ((TBaseObject)(MonGen.CertList[II]));
                            if (BaseObject != null)
                            {
                                if ((!BaseObject.m_boDeath) && (!BaseObject.m_boGhost) && (BaseObject.m_PEnvir == Envir))
                                {
                                    if (List != null)
                                    {
                                        List.Add(BaseObject);
                                    }
                                    result ++;
                                }
                            }
                        }
                    }
                }
            // for
            }
            return result;
        }

        // function IsMapRageHuman(sMapName: string; nRageX, nRageY, nRage: Integer): Boolean;//判断怪物坐标范围内是否有玩家 20080520
        // 20080123 检查地图指定坐标指定名称怪物数量
        public int GetMapMonsterCount(TEnvirnoment Envir, int nX, int nY, int nRange, string Name)
        {
            int result;
            int I;
            int II;
            int nC;
            TMonGenInfo MonGen;
            TBaseObject BaseObject;
            result = 0;
            nC = nRange;
            if (Envir == null)
            {
                return result;
            }
            if (m_MonGenList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_MonGenList.Count; I ++ )
                {
                    MonGen = m_MonGenList[I];
                    if (MonGen == null)
                    {
                        continue;
                    }
                    if (MonGen.CertList.Count > 0)
                    {
                        // 20081008
                        for (II = 0; II < MonGen.CertList.Count; II ++ )
                        {
                            BaseObject = ((TBaseObject)(MonGen.CertList[II]));
                            if (BaseObject != null)
                            {
                                if (!BaseObject.m_boDeath && !BaseObject.m_boGhost && (BaseObject.m_PEnvir == Envir) && ((BaseObject.m_sCharName).ToLower().CompareTo((Name).ToLower()) == 0))
                                {
                                    // nC := abs(nX - BaseObject.m_nCurrX) + abs(nY - BaseObject.m_nCurrY);
                                    // if nC <= 5  then Inc(Result); //20080323 修改 <=5
                                    if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nC) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nC))
                                    {
                                        // 20081217 修改
                                        result ++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 20080801 取商铺物品
        // 取有人才刷怪地图,刷怪索引 20080830
        public int GetMapMonGenIdx(TEnvirnoment Envir, ref int Idx)
        {
            int result;
            int I;
            TMonGenInfo MonGen;
            result = 0;
            try {
                if (Envir == null)
                {
                    return result;
                }
                if (Envir.MonCount == 0)
                {
                    if (m_MonGenList.Count > 0)
                    {
                        // 20081008
                        for (I = 0; I < m_MonGenList.Count; I ++ )
                        {
                            MonGen = m_MonGenList[I];
                            if (MonGen == null)
                            {
                                continue;
                            }
                            if ((MonGen.Envir == Envir) && (MonGen.nCurrMonGen != 0))
                            {
                                if (result == 0)
                                {
                                    result = 1;
                                    Idx = MonGen.nCurrMonGen;
                                }
                                MonGen.dwStartTick = 0;
                            }
                        }
                    // for
                    }
                }
            }
            catch {
            }
            return result;
        }

        public void HumanExpire(string sAccount)
        {
            int I;
            TPlayObject PlayObject;
            if (!M2Share.g_Config.boKickExpireHuman)
            {
                return;
            }
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    PlayObject = m_PlayObjectList[I];
                    if (PlayObject != null)
                    {
                        if ((PlayObject.m_sUserID).ToLower().CompareTo((sAccount).ToLower()) == 0)
                        {
                            PlayObject.m_boExpire = true;
                            break;
                        }
                    }
                }
            }
        }

        // 取地图人数
        public int GetMapHuman(string sMapName)
        {
            int result;
            int I;
            TEnvirnoment Envir;
            TPlayObject PlayObject;
            result = 0;
            Envir = M2Share.g_MapManager.FindMap(sMapName);
            if (Envir == null)
            {
                return result;
            }
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    PlayObject = m_PlayObjectList[I];
                    if (PlayObject != null)
                    {
                        if (!PlayObject.m_boDeath && !PlayObject.m_boGhost && (PlayObject.m_PEnvir == Envir))
                        {
                            result ++;
                        }
                    }
                }
            }
            return result;
        }

        // 取地图范围内的人物
        public int GetMapRageHuman(TEnvirnoment Envir, int nRageX, int nRageY, int nRage, ArrayList List)
        {
            int result;
            int I;
            TPlayObject PlayObject;
            result = 0;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    //PlayObject = ((TPlayObject)(m_PlayObjectList.Values[I]));
                    //if (PlayObject != null)
                    //{
                    //    if (!PlayObject.m_boDeath && !PlayObject.m_boGhost && (PlayObject.m_PEnvir == Envir) && (Math.Abs(PlayObject.m_nCurrX - nRageX) <= nRage) && (Math.Abs(PlayObject.m_nCurrY - nRageY) <= nRage))
                    //    {
                    //        List.Add(PlayObject);
                    //        result ++;
                    //    }
                    //}
                }
            }
            return result;
        }

        public int GetStdItemIdx(string sItemName)
        {
            int result;
            int I;
            TStdItem StdItem;
            result =  -1;
            if (sItemName == "")
            {
                return result;
            }
            if (StdItemList.Count > 0)
            {
                // 20081008
                for (I = 0; I < StdItemList.Count; I ++ )
                {
                    StdItem = StdItemList[I];
                    if (StdItem != null)
                    {
                        if ((StdItem.Name).ToLower().CompareTo((sItemName).ToLower()) == 0)
                        {
                            result = I + 1;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // 加强版文件信息发送函数(供NPC命令-SendMsg使用) 20081214
        // ==========================================
        // 向每个人物发送消息
        // 线程安全
        // ==========================================
        public void SendBroadCastMsgExt(string sMsg, TMsgType MsgType)
        {
            int I;
            TPlayObject PlayObject;
            try {
                
                EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
                if (m_PlayObjectList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_PlayObjectList.Count; I ++ )
                    {
                        //PlayObject = ((TPlayObject)(m_PlayObjectList[I]));
                        //if (PlayObject != null)
                        //{
                        //    if (!PlayObject.m_boGhost)
                        //    {
                        //        PlayObject.SysMsg(sMsg, TMsgColor.c_Red, MsgType);
                        //    }
                        //}
                    }
                }
            } finally {
                
                LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        public void SendBroadCastMsg(string sMsg, TMsgType MsgType)
        {
            int I;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    //PlayObject = ((TPlayObject)(m_PlayObjectList[I]));
                    //if (PlayObject != null)
                    //{
                    //    if (!PlayObject.m_boGhost)
                    //    {
                    //        PlayObject.SysMsg(sMsg, TMsgColor.c_Red, MsgType);
                    //    }
                    //}
                }
            }
        }

        // 加强版文件信息发送函数(供NPC命令-SendMsg使用) 20081214
        public void SendBroadCastMsg1(string sMsg, TMsgType MsgType, byte FColor, byte BColor)
        {
            int I;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    //PlayObject = ((TPlayObject)(m_PlayObjectList[I]));
                    //if (PlayObject != null)
                    //{
                    //    if (!PlayObject.m_boGhost)
                    //    {
                    //        PlayObject.SysMsg1(sMsg, TMsgColor.c_Red, MsgType, FColor, BColor);
                    //    }
                    //}
                }
            }
        }

        public void Execute()
        {
            Run();
        }

        public void sub_4AE514(TGoldChangeInfo GoldChangeInfo)
        {
            TGoldChangeInfo GoldChange;
            if (GoldChangeInfo != null)
            {
                // 20090202
                GoldChange = new TGoldChangeInfo();
                GoldChange = GoldChangeInfo;
                
                EnterCriticalSection(m_LoadPlaySection);
                try {
                    m_ChangeHumanDBGoldList.Add(GoldChange);
                } finally {
                    
                    LeaveCriticalSection(m_LoadPlaySection);
                }
            }
        }

        public void ClearMonSayMsg()
        {
            int I;
            int II;
            TMonGenInfo MonGen;
            TBaseObject MonBaseObject;
            if (m_MonGenList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_MonGenList.Count; I ++ )
                {
                    MonGen = m_MonGenList[I];
                    if ((MonGen != null) && (MonGen.CertList != null))
                    {
                        if (MonGen.CertList.Count > 0)
                        {
                            // 20081008
                            for (II = 0; II < MonGen.CertList.Count; II ++ )
                            {
                                MonBaseObject = ((TBaseObject)(MonGen.CertList[II]));
                                if (MonBaseObject != null)
                                {
                                    MonBaseObject.m_SayMsgList = null;
                                }
                            }
                        }
                    }
                }
            }
        }

        // M2所有主要过程,CPU 内存的占用大部分这过程
        public void PrcocessData()
        {
            uint dwUsrTimeTick;
            string sMsg;
            byte nCode;
            if (m_boPrcocessData)
            {
                return;
            }
            m_boPrcocessData = true;
            // sleep(1);
            nCode = 0;
            try
            {
                try
                {

                    dwUsrTimeTick = GetTickCount();
                    ProcessHumans();
                    nCode = 1;
                    // 1000 * 60 * 2
                    if ((GetTickCount() - dwGetOrderTick > 150000) && !bo_ReadPlayLeveList)
                    {
                        // 20080926 修改,每2.5分钟读取一次排行文件
                        dwGetOrderTick = GetTickCount();
                        nCode = 2;
                        // GetHumanOrder(); //获取人物等级排序 20080527
                        GetPlayObjectLevelList();
                        // 获取人物等级排序 20080527
                    }
                    nCode = 3;
                    if (M2Share.g_Config.boSendOnlineCount && (GetTickCount() - M2Share.g_dwSendOnlineTick > M2Share.g_Config.dwSendOnlineTime))
                    {
                        M2Share.g_dwSendOnlineTick = GetTickCount();
                        nCode = 4;
                        sMsg = string.Format(M2Share.g_sSendOnlineCountMsg, OnlinePlayObject * (M2Share.g_Config.nSendOnlineCountRate / 10));
                        SendBroadCastMsg(sMsg, TMsgType.t_System);
                    }
                    nCode = 5;
                    ProcessMonsters();
                    nCode = 6;
                    ProcessMerchants();
                    nCode = 7;
                    ProcessNpcs();
                    if ((GetTickCount() - dwProcessMissionsTime) > 1000)
                    {
                        dwProcessMissionsTime = GetTickCount();
                        nCode = 8;
                        ProcessEvents();
                        nCode = 9;
                        ProcessEffects();
                        // 20080327 闪电(雷炎洞魔法效果)
                    }
                    nCode = 10;

                    if ((GetTickCount() - dwProcessMapDoorTick) > 500)
                    {
                        dwProcessMapDoorTick = GetTickCount();
                        nCode = 11;
                        ProcessMapDoor();
                    }
                    nCode = 12;
                    M2Share.g_nUsrTimeMin = Convert.ToInt32(GetTickCount() - dwUsrTimeTick);
                    if (M2Share.g_nUsrTimeMax < M2Share.g_nUsrTimeMin)
                    {
                        M2Share.g_nUsrTimeMax = M2Share.g_nUsrTimeMin;
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{异常} TUserEngine::ProcessData Code:" + (nCode).ToString());
                }
            }
            finally
            {
                m_boPrcocessData = false;
            }
        }

        private bool MapRageHuman(string sMapName, int nMapX, int nMapY, int nRage)
        {
            bool result;
            int nX;
            int nY;
            TEnvirnoment Envir;
            result = false;
            Envir = M2Share.g_MapManager.FindMap(sMapName);
            if (Envir != null)
            {
                for (nX = nMapX - nRage; nX <= nMapX + nRage; nX ++ )
                {
                    for (nY = nMapY - nRage; nY <= nMapY + nRage; nY ++ )
                    {
                        if (Envir.GetXYHuman(nMapX, nMapY))
                        {
                            result = true;
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        public void SendQuestMsg(string sQuestName)
        {
            int I;
            TPlayObject PlayObject;
            if (m_PlayObjectList.Count > 0)
            {
                // 20081008
                for (I = 0; I < m_PlayObjectList.Count; I ++ )
                {
                    //PlayObject = ((TPlayObject)(m_PlayObjectList[I]));
                    //if (PlayObject != null)
                    //{
                    //    if (!PlayObject.m_boDeath && !PlayObject.m_boGhost)
                    //    {
                    //        M2Share.g_ManageNPC.GotoLable(PlayObject, sQuestName, false);
                    //    }
                    //}
                }
            }
        }

        public virtual void ClearItemList()
        {
            int I;
            I = 0;
            while (true)
            {
                //StdItemList.Exchange(HUtil32.Random(StdItemList.Count), StdItemList.Count - 1);
                //I ++;
                //if (I >= StdItemList.Count)
                //{
                //    break;
                //}
            }
            ClearMerchantData(); // 清空交易NPC临时数据
        }

        public void SwitchMagicList()
        {
            if (m_MagicList.Count > 0)
            {
                //OldMagicList.Add(m_MagicList);
                m_MagicList = new List<TMagic>();
            }
            m_boStartLoadMagic = true;
        }

        // 清空交易NPC数据
        public void ClearMerchantData()
        {
            int I;
            TMerchant Merchant;
            lock (m_MerchantList)
            try {
                if (m_MerchantList.Count > 0)
                {
                    // 20081008
                    for (I = 0; I < m_MerchantList.Count; I ++ )
                    {
                        Merchant = ((TMerchant)(m_MerchantList[I]));
                        if (Merchant != null)
                        {
                            Merchant.ClearData();
                        }
                    }
                }
            } finally {
                
            }
        }

        // 取商铺物品
        public TStdItem GetShopStdItem(string sItemName)
        {
            TStdItem result;
            int I;
            TShopInfo ShopInfo;
            result = null;
            try {
                if (sItemName == "")
                {
                    return result;
                }
                if (M2Share.g_ShopItemList.Count > 0)
                {
                    // 20080629
                    for (I = 0; I < M2Share.g_ShopItemList.Count; I ++ )
                    {
                        ShopInfo = M2Share.g_ShopItemList[I];
                        if ((ShopInfo.StdItem.Name).ToLower().CompareTo((sItemName).ToLower()) == 0)
                        {
                            result = ShopInfo.StdItem;
                            break;
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TUserEngine.GetShopStdItem");
            }
            return result;
        }

        public void EnterCriticalSection(ReaderWriterLock obj) {
            obj.AcquireReaderLock(-1);
        }

        public void LeaveCriticalSection(ReaderWriterLock obj)
        {
            obj.ReleaseLock();
        }

        public void Dispose(object obj){
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    } 
}