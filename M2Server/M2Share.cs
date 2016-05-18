using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using GameFramework;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameFramework.Thrend;
using GameFramework.Enum;

namespace M2Server
{
    public class TItemBind
    {
        // 物品绑定(绑定的玩家才能戴此物品)
        public int nMakeIdex;
        public int nItemIdx;// 物品分类
        public string sBindName;
    }

    /// <summary>
    ///  地图连接点
    /// </summary>
    public class TGateObj
    {
        public bool boFlag;
        public TEnvirnoment DEnvir;
        public int nDMapX;
        public int nDMapY;
    }

    /// <summary>
    /// 任务地图
    /// </summary>
    public class TMapQuestInfo
    {
        // 地图名称
        public string[] sMapName;
        public int nFlags;
        public int nFlag;
        public int nValue;
        public bool boFlag;
        public string[] sMonName;// 怪物名称
        public string[] sNeedItem;
        public string[] sScriptName;
        public bool boGroup;
        public string s08;
        public string s0C;
        public bool bo10;
        public TMerchant NPC;
    } 

    public class TMagicEvent
    {
        public List<TBaseObject> BaseObjectList;
        public uint dwStartTick;
        public uint dwTime;
        public THolyCurtainEvent[] Events;
    }

    public struct TLevelInfo
    {
        public ushort wHP;
        public ushort wMP;
        public uint dwExp;
        public ushort wAC;
        public ushort wMaxAC;
        public ushort wACLimit;
        public ushort wMAC;
        public ushort wMaxMAC;
        public ushort wMACLimit;
        public ushort wDC;
        public ushort wMaxDC;
        public ushort wDCLimit;
        public uint dwDCExp;
        public ushort wMC;
        public ushort wMaxMC;
        public ushort wMCLimit;
        public uint dwMCExp;
        public ushort wSC;
        public ushort wMaxSC;
        public ushort wSCLimit;
        public uint dwSCExp;
    }

    public class M2Share
    {
        public static string sCaptionExtText = String.Empty;
        /// <summary>
        /// 游戏参数配置文件
        /// </summary>
        public static IniFile Config = null;
        /// <summary>
        /// 游戏命令配置文件
        /// </summary>
        public static IniFile CommandConf = null;
        /// <summary>
        /// 提示信息配置文件
        /// </summary>
        public static IniFile StringConf = null;
        /// <summary>
        /// 全局变量配置文件
        /// </summary>
        public static IniFile GlobalConf = null;
        /// <summary>
        /// 游戏线程管理对象
        /// </summary>
        public static ThrendManage ThrendManage;
        public static RichTextBox Memo = null;
        public static int nServerIndex = 0;
        public static TRunSocket RunSocket = null;
        /// <summary>
        /// 消息输出列表
        /// </summary>
        public static List<string> MainLogMsgList = null;
        public static TStringList LogStringList = null;
        public static TStringList LogonCostLogList = null;
        public static TMapManager g_MapManager = null;// 地图管理类
        public static TItemUnit ItemUnit = null;
        public static TMagicManager MagicManager = null;
        public static TNoticeManager NoticeManager = null;
        public static TGuildManager g_GuildManager = null;// 行会管理类
        public static TEventManager g_EventManager = null;
        public static TCastleManager g_CastleManager = null;// 城堡管理类
        public static TFrontEngine FrontEngine = null;
        public static TUserEngine UserEngine = null;
        public static List<TGameCmd> CommandList = null;//游戏命令列表
        public static TFrmIDSoc FrmIDSoc = null;
        public static TFrmSrvMsg FrmSrvMsg =null;
        public static TFrmMsgClient FrmMsgClient=null;
        public static TRobotManage RobotManage = null;
        public static TStringList g_MakeItemList = null;// 制造物品列表
        public static List<TRefineItemInfo> g_RefineItemList = null;// 淬炼配置列表
        public static List<TStartPoint> g_StartPointList = null;
        public static List<TStringList> ServerTableList = null;
        public static IList<string, uint> g_DenySayMsgList = null;
        /// <summary>
        /// 小地图列表
        /// </summary>
        public static List<TMinMapInfo> MiniMapList = null;
        /// <summary>
        /// 解包物品列表
        /// </summary>
        public static List<IntPtr> g_UnbindList = null;
        /// <summary>
        /// 公告信息列表
        /// </summary>
        public static TStringList LineNoticeList = null;
        /// <summary>
        /// 自定义命令列表
        /// </summary>
        public static TStringList g_UserCmdList = null;  
        public static List<TCheckItem> g_CheckItemList = null;// 禁止物品规则 
        public static List<TFilterMsg> g_MsgFilterList = null;// 消息过滤规则 
        public static List<IntPtr> g_ShopItemList = null;// 商铺物品列表 
        public static List<TQDDinfo> QuestDiaryList = null;
        public static TStringList ItemEventList = null;
        public static TStringList AbuseTextList = null;// 文字过滤列表 
        public static TStringList g_MonSayMsgList = null;// 怪物说明信息列表
        public static TStringList g_DisableMakeItemList = null;// 禁止制造物品列表
        public static TStringList g_EnableMakeItemList = null;// 制造物品列表
        public static TStringList g_DisableMoveMapList = null;// 禁止移动地图列表
        public static TStringList g_ItemNameList = null;// 物品别名列表
        public static TStringList g_DisableSendMsgList = null;// 禁止发信息名称列表
        public static List<TMonDrop> g_MonDropLimitLIst = null;// 怪物爆物品限制
        public static TStringList g_DisableTakeOffList = null;// 禁止取下物品列表
        public static List<IntPtr> BoxsList = null;// 宝箱物品列表 
        public static List<TSuitItem> SuitItemList = null;// 套装装备列表 
        public static List<IntPtr> sSellOffItemList = null;// 元宝寄售列表 
        //public static TStorage g_Storage = null;// 无限仓库
        public static string g_StorageFileName = String.Empty;
        public static uint dwSaveDataTick = 0;
        public static List<TMapEvent> g_MapEventListOfDropItem = null;// 地图触发掉物品
        public static List<TMapEvent> g_MapEventListOfPickUpItem = null;
        public static List<TMapEvent> g_MapEventListOfMine = null;
        public static List<TMapEvent> g_MapEventListOfWalk = null;
        public static List<TMapEvent> g_MapEventListOfRun = null;
        public static TStringList g_AllowPickUpItemList = null;// 分身允许捡取物品列表
        public static List<TItemEvent> g_ItemDblClickList = null;// 物品事件触发列表
        public static List<TBindItem> g_BindItemTypeList = null;
        public static List<TItemBind> g_ItemBindIPaddr = null;
        public static List<TItemBind> g_ItemBindAccount = null;
        public static List<TItemBind> g_ItemBindCharName = null;// 物品人物绑定表(对应的玩家才能戴物品)
        public static List<TItemBind> g_ItemBindDieNoDropName = null;// 人物装备死亡不爆列表
        public static TStringList g_UnMasterList = null;// 出师记录表
        public static TStringList g_UnForceMasterList = null;// 强行出师记录表
        public static TStringList g_GameLogItemNameList = null;// 游戏日志物品名
        public static bool g_boGameLogGold = false;// 是否写入日志(金币)
        public static bool g_boGameLogGameGold = false;// 是否写入日志(调整游戏币)
        public static bool g_boGameLogGameDiaMond = false;// 是否写入日志(调整金刚石) 
        public static bool g_boGameLogGameGird = false;// 是否写入日志(调整灵符) 
        public static bool g_boGameLogGameGlory = false;// 是否写入日志(调整荣誉值) 
        public static bool g_boGameLogGamePoint = false;// 是否写入日志(调整游戏点)
        public static bool g_boGameLogHumanDie = false;
        public static TStringList g_DenyIPAddrList = null;// IP过滤列表
        public static TStringList g_DenyChrNameList = null;// 角色过滤列表
        public static TStringList g_DenyAccountList = null;// 登录帐号过滤列表
        public static TStringList g_NoClearMonList = null;// 不清除怪物列表
        public static TProcessMessage g_ProcessMsg;
        public static object LogMsgCriticalSection = null;
        public static object ProcessMsgCriticalSection = null;
        public static object UserDBSection = null;
        public static object ProcessHumanCriticalSection = null;
        public static object HumanSortCriticalSection = null;
        public static int g_nTotalHumCount = 0;
        public static bool g_boMission = false;// 是否设置怪物集中点
        public static string g_sMissionMap = String.Empty;// 怪物集中点 地图
        public static int g_nMissionX = 0;// 怪物集中点X
        public static int g_nMissionY = 0;// 怪物集中点Y
        public static bool boStartReady = false;
        public static bool g_boExitServer = false;
        public static bool boFilterWord = false;
        public static int nRunTimeMin = 0;
        public static int nRunTimeMax = 0;
        public static int g_nBaseObjTimeMin = 0;
        public static int g_nBaseObjTimeMax = 0;
        public static int g_nSockCountMin = 0;
        public static int g_nSockCountMax = 0;
        public static uint g_nUsrTimeMin = 0;
        public static uint g_nUsrTimeMax = 0;
        public static int g_nHumCountMin = 0;
        public static int g_nHumCountMax = 0;
        public static uint g_nMonTimeMin = 0;
        public static uint g_nMonTimeMax = 0;
        public static uint g_nMonGenTime = 0;
        public static uint g_nMonGenTimeMin = 0;
        public static uint g_nMonGenTimeMax = 0;
        public static uint g_nMonProcTime = 0;
        public static uint g_nMonProcTimeMin = 0;
        public static uint g_nMonProcTimeMax = 0;
        public static uint dwUsrRotCountMin = 0;
        public static uint dwUsrRotCountMax = 0;
        public static uint g_dwUsrRotCountTick = 0;
        public static int g_nProcessHumanLoopTime = 0; //处理人物列表循环次数
        public static uint g_dwHumLimit = 30;
        public static uint g_dwMonLimit = 30;
        public static uint g_dwZenLimit = 5;
        public static uint g_dwNpcLimit = 5;
        public static uint g_dwSocLimit = 10;
        public static uint g_dwSocCheckTimeOut = 50;
        public static int nDecLimit = 20;
        public static int nShiftUsrDataNameNo = 0;
        public static string sConfig775FileName = ".\\775.txt";
        public static string sConfigFileName = ".\\!Setup.txt";
        public static string sExpConfigFileName = ".\\Exps.ini";
        public static string sCommandFileName = ".\\Command.ini";
        public static string sStringFileName = ".\\String.ini";
        public static string sGlobalFileName = ".\\Global.ini";
        public static uint g_dwStartTick = 0;// 启动间隔
        public static uint g_dwRunTick = 0;// 运行间隔
        public static int n4EBD1C = 0;
        public static int g_nGameTime = 0;
        public static string g_sMonGenInfo1 = String.Empty;
        public static string g_sMonGenInfo2 = String.Empty;
        public static TNormNpc g_ManageNPC = null;
        public static TNormNpc g_RobotNPC = null;
        public static TMerchant g_FunctionNPC = null;// 脚本触发NPC
        public static TMerchant g_BatterNPC = null;// 连击NPC
        public static IList<TDynamicVar> g_DynamicVarList = null;
        public static int nCurrentMonthly = 0;
        public static int nTotalTimeUsage = 0;
        public static int nLastMonthlyTotalUsage = 0;
        public static int nGrossTotalCnt = 0;
        public static int nGrossResetCnt = 0;
        public static int nCrackedLevel = 0;
        public static int nErrorLevel = 0;
        public static bool g_boMinimize = true;
        public static TRGBQuad[] ColorTable = new TRGBQuad[256];
        public static char g_GMRedMsgCmd = '!';
        public static int g_nGMREDMSGCMD = 6;
        public static uint g_dwSendOnlineTick = 0;
        public static TPlayObject g_HighLevelHuman = null;
        public static TPlayObject g_HighPKPointHuman = null;
        public static TPlayObject g_HighDCHuman = null;
        public static TPlayObject g_HighMCHuman = null;
        public static TPlayObject g_HighSCHuman = null;
        public static TPlayObject g_HighOnlineHuman = null;
        public static uint g_dwSpiritMutinyTick = 0;

        public static TGameConfig g_Config = new TGameConfig();
        // ===============================================================
        public static string sDBName = "HeroDB";
        public static SqlConnection g_sADODBString = new SqlConnection();
        public static TLevelInfo[] g_LevelInfo = new TLevelInfo[MAXLEVEL + 1];
        public static uint[] g_dwOldNeedExps;
        public static uint[] g_dwHeroNeedExps;
        public static uint[] g_dwExpCrystalNeedExps;
        public static uint[] g_dwNGExpCrystalNeedExps;
        public static ushort[] g_dwMedicineExps;
        public static uint[] g_dwSkill68Exps;
        public static TGameCommand g_GameCommand = new TGameCommand();// 游戏命令方面参数
        
        // ===============================================================
        public static int nIPLocal = -1;
        public static int nStartModule = -1;
        public static uint dwStartTime = 0;
        public static uint dwStartTimeTick = 0;
        public static int g_nSaveRcdErrorCount = 0;
        public static uint g_dwShowSaveRcdErrorTick = 0;
        public const string g_sSellOffGoldInfo = "当前没有您的拍卖款";
        public const string g_sSellOffItemInfo = "您没有在这拍卖物品"; 
        /// <summary>
        /// 动作失败
        /// </summary>
        public const string sSTATUS_FAIL = "+FAIL/";
        /// <summary>
        /// 动作成功
        /// </summary>
        public const string sSTATUS_GOOD = "+GOOD/";
        public const int MAXLEVEL = ushort.MaxValue;
        public const int MAXCHANGELEVEL = 1000;
        public const int LOG_GAMEGOLD = 111;// 游戏币(日志代码)
        public const int LOG_GAMEPOINT = 112;// 游戏点(日志代码)
        public const int LOG_GameDiaMond = 113;// 金刚石(日志代码)
        public const int LOG_GameGird = 114;// 灵符(日志代码)
        public const int LOG_HeroLoyal = 115;// 英雄的忠诚度(日志代码)
        public const int LOG_GameGlory = 116;// 荣誉(日志代码)
        public const int ET_STONEMINE = 11;// 矿石
        public const string sSTRING_GOLDNAME = "金币";
        public const int SLAVEMAXLEVEL = 9;// 宝宝最大等级
        /// <summary>
        /// 可学技能数
        /// </summary>
        public const int MAXMAGIC = 30;
        /// <summary>
        /// 最高可升级等级
        /// </summary>
        public const int MAXUPLEVEL = ushort.MaxValue;
        public const int MAXHUMPOWER = ushort.MaxValue;
        public const double BODYLUCKUNIT = 5.0E3;
        public const int HAM_ALL = 0;// [攻击模式: 全体攻击]
        public const int HAM_PEACE = 1;// [攻击模式: 和平攻击]
        public const int HAM_DEAR = 2;// [攻击模式: 夫妻攻击]
        public const int HAM_MASTER = 3;// [攻击模式: 师徒攻击]
        public const int HAM_GROUP = 4;// [攻击模式: 编组攻击]
        public const int HAM_GUILD = 5;// [攻击模式: 行会攻击]
        public const int HAM_PKATTACK = 6;// [攻击模式: 红名攻击]
        public const int DEFHIT = 5;
        public const int DEFSPEED = 15;
        public const int WARR = 0;
        public const int WIZARD = 1;
        public const int TAOS = 2;
        public const string sCHECKOPEN = "CHECKOPEN";
        public const int nCHECKOPEN = 5;
        public const string sCHECKUNIT = "CHECKUNIT";
        public const int nCHECKUNIT = 6;// 脚本命令
        public const string sSET = "SET";
        public const int nSET = 1;
        public const string sTAKE = "TAKE";
        public const int nTAKE = 2;
        public const string sSC_GIVE = "GIVE";// 给物品
        public const int nSC_GIVE = 3;
        public const string sTAKEW = "TAKEW";
        public const int nTAKEW = 4;
        public const string sCLOSE = "CLOSE";
        public const int nCLOSE = 5;
        public const string sRESET = "RESET";
        public const int nRESET = 6;
        public const string sSETOPEN = "SETOPEN";// 未使用的命令
        public const int nSETOPEN = 7;
        public const string sSETUNIT = "SETUNIT";// 未使用的命令 
        public const int nSETUNIT = 8;
        public const string sRESETUNIT = "RESETUNIT";// 未使用的命令
        public const int nRESETUNIT = 9;
        public const string sBREAK = "BREAK";
        public const int nBREAK = 10;
        public const string sTIMERECALL = "TIMERECALL";
        public const int nTIMERECALL = 11;
        public const string sSC_PARAM1 = "PARAM1";
        public const int nSC_PARAM1 = 12;
        public const string sSC_PARAM2 = "PARAM2";
        public const int nSC_PARAM2 = 13;
        public const string sSC_PARAM3 = "PARAM3";
        public const int nSC_PARAM3 = 14;
        public const string sSC_PARAM4 = "PARAM4";
        public const int nSC_PARAM4 = 15;
        public const string sSC_EXEACTION = "EXEACTION";
        public const int nSC_EXEACTION = 16;
        public const string sCHECKNAMELIST = "CHECKNAMELIST";
        public const int nCHECKNAMELIST = 17;
        public const string sSC_ISGUILDMASTER = "ISGUILDMASTER";
        public const int nSC_ISGUILDMASTER = 18;
        public const string sMAPMOVE = "MAPMOVE";
        public const int nMAPMOVE = 19;
        public const string sMAP = "MAP";
        public const int nMAP = 20;
        public const string sTAKECHECKITEM = "TAKECHECKITEM";
        public const int nTAKECHECKITEM = 21;
        public const string sMONGEN = "MONGEN";
        public const int nMONGEN = 22;
        public const string sISTAKEITEM = "ISTAKEITEM";
        public const int nISTAKEITEM = 23;
        public const string sMONCLEAR = "MONCLEAR";
        public const int nMONCLEAR = 24;
        public const string sMOV = "MOV";
        public const int nMOV = 25;
        public const string sINC = "INC";
        public const int nINC = 26;
        public const string sDEC = "DEC";
        public const int nDEC = 27;
        public const string sSUM = "SUM";
        public const int nSUM = 28;
        public const string sBREAKTIMERECALL = "BREAKTIMERECALL";
        public const int nBREAKTIMERECALL = 29;
        public const string sSENDMSG = "SENDMSG";// 发送文字信息
        public const int nSENDMSG = 30;
        public const string sPKPOINT = "PKPOINT";
        public const int nPKPOINT = 32;
        public const string sCHECKHUM = "CHECKHUM";
        public const int nCHECKHUM = 33;
        public const string sSC_RECALLMOB = "RECALLMOB";
        public const int nSC_RECALLMOB = 34;
        public const string sKICK = "KICK";
        public const int nKICK = 35;
        public const string sLARGE = "LARGE";
        public const int nLARGE = 36;
        public const string sSMALL = "SMALL";
        public const int nSMALL = 37;
        public const string sCHECKPKPOINT = "CHECKPKPOINT";
        public const int nCHECKPKPOINT = 38;
        public const string sCHECKLUCKYPOINT = "CHECKLUCKYPOINT";
        public const int nCHECKLUCKYPOINT = 39;
        public const string sCHECKMONMAP = "CHECKMONMAP";
        public const int nCHECKMONMAP = 40;
        public const string sCHECKBAGGAGE = "CHECKBAGGAGE";
        public const int nCHECKBAGGAGE = 41;
        public const string sEQUAL = "EQUAL";
        public const int nEQUAL = 42;
        public const string sCHECKDURA = "CHECKDURA";
        public const int nCHECKDURA = 43;
        public const string sCHECKDURAEVA = "CHECKDURAEVA";
        public const int nCHECKDURAEVA = 44;
        public const string sDAYOFWEEK = "DAYOFWEEK";
        public const int nDAYOFWEEK = 45;
        public const string sHOUR = "HOUR";
        public const int nHOUR = 46;
        public const string sMIN = "MIN";
        public const int nMIN = 47;
        public const string sCHECK = "CHECK";
        public const int nCHECK = 48;
        public const string sRANDOM = "RANDOM";
        public const int nRANDOM = 49;
        public const string sMOVR = "MOVR";
        public const int nMOVR = 50;
        public const string sEXCHANGEMAP = "EXCHANGEMAP";
        public const int nEXCHANGEMAP = 51;
        public const string sRECALLMAP = "RECALLMAP";
        public const int nRECALLMAP = 52;
        public const string sADDBATCH = "ADDBATCH";
        public const int nADDBATCH = 53;
        public const string sBATCHDELAY = "BATCHDELAY";
        public const int nBATCHDELAY = 54;
        public const string sBATCHMOVE = "BATCHMOVE";
        public const int nBATCHMOVE = 55;
        public const string sPLAYDICE = "PLAYDICE";
        public const int nPLAYDICE = 56;
        public const string sADDNAMELIST = "ADDNAMELIST";
        public const int nADDNAMELIST = 57;
        public const string sDELNAMELIST = "DELNAMELIST";
        public const int nDELNAMELIST = 58;
        public const string sADDGUILDLIST = "ADDGUILDLIST";
        public const int nADDGUILDLIST = 59;
        public const string sDELGUILDLIST = "DELGUILDLIST";
        public const int nDELGUILDLIST = 60;
        public const string sADDACCOUNTLIST = "ADDACCOUNTLIST";
        public const int nADDACCOUNTLIST = 61;
        public const string sDELACCOUNTLIST = "DELACCOUNTLIST";
        public const int nDELACCOUNTLIST = 62;
        public const string sADDIPLIST = "ADDIPLIST";
        public const int nADDIPLIST = 63;
        public const string sDELIPLIST = "DELIPLIST";
        public const int nDELIPLIST = 64;
        public const string sSC_ISDEFENSEGUILD = "ISDEFENSEGUILD";// 是否为守城方
        public const int nSC_ISDEFENSEGUILD = 65;
        public const string sSC_ISCASTLEGUILD = "ISCASTLEGUILD";
        public const int nSC_ISCASTLEGUILD = 66;
        public const string sSC_ISATTACKGUILD = "ISATTACKGUILD";// 是否为攻城方
        public const int nSC_ISATTACKGUILD = 67;
        public const string sSC_HASGUILD = "HAVEGUILD";// 是否加入行会
        public const int nSC_HASGUILD = 68;
        public const string sSC_CHECKCASTLEDOOR = "CHECKCASTLEDOOR";// 检查城门
        public const int nSC_CHECKCASTLEDOOR = 69;
        public const string sGENDER = "GENDER";
        public const int nGENDER = 70;
        public const string sDAYTIME = "DAYTIME";
        public const int nDAYTIME = 71;
        public const string sCHECKLEVEL = "CHECKLEVEL";
        public const int nCHECKLEVEL = 72;
        public const string sSC_ISATTACKALLYGUILD = "ISATTACKALLYGUILD";// 是否为攻城方联盟行会
        public const int nSC_ISATTACKALLYGUILD = 73;
        public const string sSC_ISDEFENSEALLYGUILD = "ISDEFENSEALLYGUILD";// 是否为守城方联盟行会
        public const int nSC_ISDEFENSEALLYGUILD = 74;
        public const string sCHECKJOB = "CHECKJOB";
        public const int nCHECKJOB = 75;
        public const string sSC_ISSYSOP = "ISSYSOP";
        public const int nSC_ISSYSOP = 76;
        public const string sSC_ISADMIN = "ISADMIN";
        public const int nSC_ISADMIN = 77;
        public const string sCHECKITEM = "CHECKITEM";
        public const int nCHECKITEM = 78;
        public const string sCHECKITEMW = "CHECKITEMW";
        public const int nCHECKITEMW = 79;
        public const string sCHECKGOLD = "CHECKGOLD";
        public const int nCHECKGOLD = 80;
        public const string sCHECKBBCOUNT = "CHECKBBCOUNT";
        public const int nCHECKBBCOUNT = 81;
        public const string sSC_CHECKSERVER = "CHECKSERVER";
        public const int nSC_CHECKSERVER = 82;
        public const string sSC_CHECKGROUPCOUNT = "CHECKGROUPCOUNT";
        public const int nSC_CHECKGROUPCOUNT = 83;
        public const string sSC_REPAIRITEM = "REPAIRITEM";
        public const int nSC_REPAIRITEM = 84;
        public const string sSC_CLEARMAPITEM = "CLEARMAPITEM";// 清除地图物品 增加对blue脚本的命令支持
        public const string sSC_CLEARITEMMAP = "CLEARITEMMAP";// 清除地图物品
        public const int nSC_CLEARITEMMAP = 85;
        public const string sSC_GROUPMOVE = "GROUPMOVE";
        public const int nSC_GROUPMOVE = 86;
        public const string sSC_CLEARNAMELIST = "CLEARNAMELIST";
        public const int nSC_CLEARNAMELIST = 87;
        public const string sSC_KILLSLAVE = "KILLSLAVE";
        public const int nSC_KILLSLAVE = 88;
        public const string sSC_CHANGEGENDER = "CHANGEGENDER";
        public const int nSC_CHANGEGENDER = 89;
        public const string sCHANGESKILL = "CHANGESKILL";// 修改魔法ID
        public const int nCHANGESKILL = 90;
        public const string sCHALLENGMAPMOVE = "CHALLENGMAPMOVE";// 挑战地图移动 20080705
        public const int nCHALLENGMAPMOVE = 91;
        public const string sGETCHALLENGEBAKITEM = "GETCHALLENGEBAKITEM";// 没有挑战地图可移动,则退回抵押的物品 
        public const int nGETCHALLENGEBAKITEM = 92;
        public const string sHEROLOGOUT = "HEROLOGOUT";// 人物在线英雄下线 
        public const int nHEROLOGOUT = 93;
        public const string sSC_ADDGUILDMEMBER = "ADDGUILDMEMBER";// 添加行会成员
        public const int nSC_ADDGUILDMEMBER = 94;
        public const string sSC_DELGUILDMEMBER = "DELGUILDMEMBER";// 删除行会成员（删除掌门无效）
        public const int nSC_DELGUILDMEMBER = 95;
        public const string sSC_CHECKLISTTEXT = "CHECKLISTTEXT";// 检查文件是否包含指定文本 
        public const int nSC_CHECKLISTTEXT = 96;
        public const string sQUERYREFINEITEM = "QUERYREFINEITEM";// 打开淬炼窗口
        public const int nQUERYREFINEITEM = 97;
        public const string sGOHOME = "GOHOME";// 移动到回城点 
        public const int nGOHOME = 98;
        public const string sTHROWITEM = "THROWITEM";// 将指定物品刷新到指定地图坐标范围内
        public const int nTHROWITEM = 99;
        public const string sGOQUEST = "GOQUEST";
        public const int nGOQUEST = 100;
        public const string sENDQUEST = "ENDQUEST";
        public const int nENDQUEST = 101;
        public const string sGOTO = "GOTO";
        public const int nGOTO = 102;
        public const string sSetOnTimer = "SETONTIMER";// 个人定时器
        public const string sSetScTimer = "SETSCTIMER";// 对blue的定时器的识别
        public const int nSetOnTimer = 103;
        public const string sSETOFFTIMER = "SETOFFTIMER";// 停止定时器
        public const string sKILLSCTIMER = "KILLSCTIMER";// 对blue的定时器的识别
        public const int nSETOFFTIMER = 104;
        public const string sSC_CHECKGAMEGLORY = "CHECKGAMEGLORY";// 检查荣誉值
        public const int nSC_CHECKGAMEGLORY = 105;
        public const string sSC_HAIRSTYLE = "HAIRSTYLE";
        public const int nSC_HAIRSTYLE = 106;
        // -----------------------酒馆系统-----------------------------------------
        public const string sSC_SAVEHERO = "SAVEHERO";// 寄放英雄
        public const int nSC_SAVEHERO = 107;
        public const string sSC_GETHERO = "GETHERO";// 取回英雄
        public const int nSC_GETHERO = 108;
        public const string sSC_CLOSEDRINK = "CLOSEDRINK";// 关闭斗酒窗口
        public const int nSC_CLOSEDRINK = 109;
        public const string sSC_PLAYDRINKMSG = "PLAYDRINKMSG";// 斗酒窗口说话信息
        public const int nSC_PLAYDRINKMSG = 110;
        public const string sSC_OPENPLAYDRINK = "OPENPLAYDRINK";// 指定人物喝酒
        public const int nSC_OPENPLAYDRINK = 111;
        // -------------------------------------------------------------------------
        public const string sGETSORTNAME = "GETSORTNAME";// 取指定排行榜指定排名的玩家名字
        public const int nGETSORTNAME = 112;
        public const string sWEBBROWSER = "WEBBROWSER";// 连接指定网站网址
        public const int nWEBBROWSER = 113;
        public const string sSC_CHANGEHUMABILITY = "CHANGEHUMABILITY";// 调整人物属性
        public const int nSC_CHANGEHUMABILITY = 114;
        public const string sADDATTACKSABUKALL = "ADDATTACKSABUKALL";// 设置所有行会攻城
        public const int nADDATTACKSABUKALL = 115;
        public const string sKICKALLPLAY = "KICKALLPLAY";// 踢除服务器所有在线人物  
        public const int nKICKALLPLAY = 116;
        public const string sREPAIRALL = "REPAIRALL";// 修理全身装备 
        public const int nREPAIRALL = 117;
        public const string sAUTOGOTOXY = "AUTOGOTOXY";// 自动寻路 
        public const int nAUTOGOTOXY = 118;
        // ----------------------------酿酒系统------------------------------------------
        public const string sOPENMAKEWINE = "OPENMAKEWINE";
        // 打开酿酒窗口 20080619
        public const int nOPENMAKEWINE = 119;
        public const string sGETGOODMAKEWINE = "GETGOODMAKEWINE";
        // 取回酿好的酒 20080620
        public const int nGETGOODMAKEWINE = 120;
        public const string sDECMAKEWINETIME = "DECMAKEWINETIME";
        // 减少酿酒的时间 20080620
        public const int nDECMAKEWINETIME = 121;
        public const string sISONMAKEWINE = "ISONMAKEWINE";
        // 判断是否在酿哪种酒 20080620
        public const int nISONMAKEWINE = 122;
        public const string sMAKEWINENPCMOVE = "MAKEWINENPCMOVE";
        // 酿酒NPC的走动 20080621
        public const int nMAKEWINENPCMOVE = 123;
        public const string sFOUNTAIN = "FOUNTAIN";
        // 设置泉水喷发 20080624
        public const int nFOUNTAIN = 124;
        public const string sCHECKGUILDFOUNTAIN = "CHECKGUILDFOUNTAIN";
        // 判断是否开启行会泉水仓库 20080625
        public const int nCHECKGUILDFOUNTAIN = 125;
        public const string sSETGUILDFOUNTAIN = "SETGUILDFOUNTAIN";
        // 开启/关闭行会泉水仓库 20080625
        public const int nSETGUILDFOUNTAIN = 126;
        public const string sGIVEGUILDFOUNTAIN = "GIVEGUILDFOUNTAIN";
        // 领取行会酒水 20080625
        public const int nGIVEGUILDFOUNTAIN = 127;
        // ------------------------------------------------------------------------------
        public const string sHCall = "HCALL";
        // 通过脚本命令让别人执行QManage.txt中的脚本 20080422
        public const int nHCall = 128;
        public const string sSC_CHECKCASTLEWAR = "CHECKCASTLEWAR";
        // 检查是否在攻城期间 20080422
        public const int nSC_CHECKCASTLEWAR = 129;
        public const string sINCASTLEWARAY = "INCASTLEWARAY";
        // 检测人物是否在攻城期间的范围内，在则BB叛变 20080422
        public const int nINCASTLEWARAY = 130;
        public const string sHEROCHECKSKILL = "HEROCHECKSKILL";
        // 检查英雄技能 20080423
        public const int nHEROCHECKSKILL = 131;
        public const string sSC_CHECKSIDESLAVENAME = "CHECKSIDESLAVENAME";
        // 检查人物周围自己宝宝数量 20080425
        public const int nSC_CHECKSIDESLAVENAME = 132;
        public const string sSC_ISONMAP = "ISONMAP";
        // 检测地图命令  20080426
        public const int nSC_ISONMAP = 133;
        public const string sSC_CHANGEHEROTRANPOINT = "CHANGEHEROTRANPOINT";
        // 调整英雄技能升级点数 20080512
        public const int nSC_CHANGEHEROTRANPOINT = 134;
        public const string sCHECKACCOUNTLIST = "CHECKACCOUNTLIST";
        public const int nCHECKACCOUNTLIST = 135;
        public const string sCHECKIPLIST = "CHECKIPLIST";
        public const int nCHECKIPLIST = 136;
        public const string sSC_CHECKSKILLLEVEL = "CHECKSKILLLEVEL";
        // 检查技能等级 20080512
        public const int nSC_CHECKSKILLLEVEL = 137;
        public const string sSC_CHECKPOSEDIR = "CHECKPOSEDIR";
        public const int nSC_CHECKPOSEDIR = 138;
        public const string sSC_CHECKPOSELEVEL = "CHECKPOSELEVEL";
        public const int nSC_CHECKPOSELEVEL = 139;
        public const string sSC_CHECKPOSEGENDER = "CHECKPOSEGENDER";
        public const int nSC_CHECKPOSEGENDER = 140;
        public const string sSC_CHECKLEVELEX = "CHECKLEVELEX";
        public const int nSC_CHECKLEVELEX = 141;
        public const string sSC_CHECKBONUSPOINT = "CHECKBONUSPOINT";
        public const int nSC_CHECKBONUSPOINT = 142;
        public const string sSC_CHECKMARRY = "CHECKMARRY";
        public const int nSC_CHECKMARRY = 143;
        public const string sSC_CHECKPOSEMARRY = "CHECKPOSEMARRY";
        public const int nSC_CHECKPOSEMARRY = 144;
        public const string sSC_CHECKMARRYCOUNT = "CHECKMARRYCOUNT";
        public const int nSC_CHECKMARRYCOUNT = 145;
        public const string sSC_CHECKMASTER = "CHECKMASTER";
        public const int nSC_CHECKMASTER = 146;
        public const string sSC_HAVEMASTER = "HAVEMASTER";
        public const int nSC_HAVEMASTER = 147;
        public const string sSC_CHECKPOSEMASTER = "CHECKPOSEMASTER";
        public const int nSC_CHECKPOSEMASTER = 148;
        public const string sSC_POSEHAVEMASTER = "POSEHAVEMASTER";
        public const int nSC_POSEHAVEMASTER = 149;
        public const string sSC_CHECKISMASTER = "CHECKPOSEISMASTER";
        public const int nSC_CHECKISMASTER = 150;
        public const string sSC_CHECKPOSEISMASTER = "CHECKISMASTER";
        public const int nSC_CHECKPOSEISMASTER = 151;
        public const string sSC_CHECKNAMEIPLIST = "CHECKNAMEIPLIST";
        public const int nSC_CHECKNAMEIPLIST = 152;
        public const string sSC_CHECKACCOUNTIPLIST = "CHECKACCOUNTIPLIST";
        public const int nSC_CHECKACCOUNTIPLIST = 153;
        public const string sSC_CHECKSLAVECOUNT = "CHECKSLAVECOUNT";
        public const int nSC_CHECKSLAVECOUNT = 154;
        public const string sSC_CHECKCASTLEMASTER = "ISCASTLEMASTER";
        public const int nSC_CHECKCASTLEMASTER = 155;
        public const string sSC_ISNEWHUMAN = "ISNEWHUMAN";
        public const int nSC_ISNEWHUMAN = 156;
        public const string sSC_CHECKMEMBERTYPE = "CHECKMEMBERTYPE";
        public const int nSC_CHECKMEMBERTYPE = 157;
        public const string sSC_CHECKMEMBERLEVEL = "CHECKMEMBERLEVEL";
        public const int nSC_CHECKMEMBERLEVEL = 158;
        public const string sSC_CHECKGAMEGOLD = "CHECKGAMEGOLD";
        public const int nSC_CHECKGAMEGOLD = 159;
        public const string sSC_CHECKGAMEPOINT = "CHECKGAMEPOINT";
        public const int nSC_CHECKGAMEPOINT = 160;
        public const string sSC_CHECKNAMELISTPOSITION = "CHECKNAMELISTPOSITION";// 检查人物在列表中的位置
        public const int nSC_CHECKNAMELISTPOSITION = 161;
        public const string sSC_CHECKGUILDLIST = "CHECKGUILDLIST";
        public const int nSC_CHECKGUILDLIST = 162;
        public const string sSC_CHECKRENEWLEVEL = "CHECKRENEWLEVEL";
        public const int nSC_CHECKRENEWLEVEL = 163;
        public const string sSC_CHECKSLAVELEVEL = "CHECKSLAVELEVEL";
        public const int nSC_CHECKSLAVELEVEL = 164;
        public const string sSC_CHECKSLAVENAME = "CHECKSLAVENAME";
        public const int nSC_CHECKSLAVENAME = 165;
        public const string sSC_CHECKCREDITPOINT = "CHECKCREDITPOINT";
        public const int nSC_CHECKCREDITPOINT = 166;
        public const string sSC_CHECKOFGUILD = "CHECKOFGUILD";
        public const int nSC_CHECKOFGUILD = 167;
        public const string sSC_CHECKPAYMENT = "CHECKPAYMENT";
        public const int nSC_CHECKPAYMENT = 168;
        public const string sSC_CHECKUSEITEM = "CHECKUSEITEM";
        public const int nSC_CHECKUSEITEM = 169;
        public const string sSC_CHECKBAGSIZE = "CHECKBAGSIZE";
        public const int nSC_CHECKBAGSIZE = 170;
        public const string sSC_CHECKDC = "CHECKDC";
        public const int nSC_CHECKDC = 172;
        public const string sSC_CHECKMC = "CHECKMC";
        public const int nSC_CHECKMC = 173;
        public const string sSC_CHECKSC = "CHECKSC";
        public const int nSC_CHECKSC = 174;
        public const string sSC_CHECKHP = "CHECKHP";
        public const int nSC_CHECKHP = 175;
        public const string sSC_CHECKMP = "CHECKMP";
        public const int nSC_CHECKMP = 176;
        public const string sSC_CHECKCODELIST = "CHECKCODELIST";// 检测文本里的编码是否存在 
        public const int nSC_CHECKCODELIST = 177;
        public const string sCLEARCODELIST = "CLEARCODELIST";// 删除指定文本里的编码
        public const int nCLEARCODELIST = 178;
        public const string sSC_HEROSKILLLEVEL = "HEROSKILLLEVEL";// 调整英雄技能等级
        public const int nSC_HEROSKILLLEVEL = 179;
        public const string sSC_CHECKITEMTYPE = "CHECKITEMTYPE";
        public const int nSC_CHECKITEMTYPE = 180;
        public const string sSC_CHECKEXP = "CHECKEXP";
        public const int nSC_CHECKEXP = 181;
        public const string sSC_CHECKCASTLEGOLD = "CHECKCASTLEGOLD";
        public const int nSC_CHECKCASTLEGOLD = 182;
        public const string sSC_PASSWORDERRORCOUNT = "PASSWORDERRORCOUNT";
        public const int nSC_PASSWORDERRORCOUNT = 183;
        public const string sSC_ISLOCKPASSWORD = "ISLOCKPASSWORD";
        public const int nSC_ISLOCKPASSWORD = 184;
        public const string sSC_ISLOCKSTORAGE = "ISLOCKSTORAGE";
        public const int nSC_ISLOCKSTORAGE = 185;
        public const string sSC_CHECKBUILDPOINT = "CHECKGUILDBUILDPOINT";
        public const int nSC_CHECKBUILDPOINT = 186;
        public const string sSC_CHECKAURAEPOINT = "CHECKGUILDAURAEPOINT";
        public const int nSC_CHECKAURAEPOINT = 187;
        public const string sSC_CHECKSTABILITYPOINT = "CHECKGUILDSTABILITYPOINT";
        public const int nSC_CHECKSTABILITYPOINT = 188;
        public const string sSC_CHECKFLOURISHPOINT = "CHECKGUILDFLOURISHPOINT";
        public const int nSC_CHECKFLOURISHPOINT = 189;
        public const string sSC_CHECKCONTRIBUTION = "CHECKCONTRIBUTION";// 贡献度
        public const int nSC_CHECKCONTRIBUTION = 190;
        public const string sSC_CHECKRANGEMONCOUNT = "CHECKRANGEMONCOUNT";// 检查一个区域中有多少怪
        public const int nSC_CHECKRANGEMONCOUNT = 191;
        public const string sSC_CHECKITEMADDVALUE = "CHECKITEMADDVALUE";
        public const int nSC_CHECKITEMADDVALUE = 192;
        public const string sSC_CHECKINMAPRANGE = "CHECKINMAPRANGE";
        public const int nSC_CHECKINMAPRANGE = 193;
        public const string sSC_CASTLECHANGEDAY = "CASTLECHANGEDAY";
        public const int nSC_CASTLECHANGEDAY = 194;
        public const string sSC_CASTLEWARDAY = "CASTLEWARAY";
        public const int nSC_CASTLEWARDAY = 195;
        public const string sSC_ONLINELONGMIN = "ONLINELONGMIN";
        public const int nSC_ONLINELONGMIN = 196;
        public const string sSC_CHECKGUILDCHIEFITEMCOUNT = "CHECKGUILDCHIEFITEMCOUNT";
        public const int nSC_CHECKGUILDCHIEFITEMCOUNT = 197;
        public const string sSC_CHECKNAMEDATELIST = "CHECKNAMEDATELIST";
        public const int nSC_CHECKNAMEDATELIST = 198;
        public const string sSC_CHECKMAPHUMANCOUNT = "CHECKMAPHUMANCOUNT";
        public const int nSC_CHECKMAPHUMANCOUNT = 199;
        public const string sSC_CHECKMAPMONCOUNT = "CHECKMAPMONCOUNT";
        public const int nSC_CHECKMAPMONCOUNT = 200;
        public const string sSC_CHECKVAR = "CHECKVAR";
        public const int nSC_CHECKVAR = 201;
        public const string sSC_CHECKSERVERNAME = "CHECKSERVERNAME";
        public const int nSC_CHECKSERVERNAME = 202;
        public const string sCHECKMAPNAME = "CHECKMAPNAME";
        public const int nCHECKMAPNAME = 203;
        public const string sINSAFEZONE = "INSAFEZONE";
        public const int nINSAFEZONE = 204;
        public const string sCHECKSKILL = "CHECKSKILL";
        public const int nCHECKSKILL = 205;
        public const string sSC_CHECKUSERDATE = "CHECKUSERDATE";
        public const int nSC_CHECKUSERDATE = 206;
        public const string sSC_CHECKCONTAINSTEXT = "CHECKCONTAINSTEXT";
        public const int nSC_CHECKCONTAINSTEXT = 207;
        public const string sSC_COMPARETEXT = "COMPARETEXT";
        public const int nSC_COMPARETEXT = 208;
        public const string sSC_CHECKTEXTLIST = "CHECKTEXTLIST";
        public const int nSC_CHECKTEXTLIST = 209;
        public const string sSC_ISGROUPMASTER = "ISGROUPMASTER";
        public const int nSC_ISGROUPMASTER = 210;
        public const string sSC_CHECKCONTAINSTEXTLIST = "CHECKCONTAINSTEXTLIST";
        public const int nSC_CHECKCONTAINSTEXTLIST = 211;
        public const string sSC_CHECKONLINE = "CHECKONLINE";// 检查玩家是否在线
        public const int nSC_CHECKONLINE = 212;
        public const string sOPENDRAGONBOX = "OPENDRAGONBOX";// 打开卧龙宝藏 20080306
        public const int nOPENDRAGONBOX = 213;
        public const string sSC_ISDUPMODE = "ISDUPMODE";
        public const int nSC_ISDUPMODE = 214;
        public const string sSC_ISOFFLINEMODE = "ISOFFLINEMODE";
        public const int nSC_ISOFFLINEMODE = 215;
        public const string sSC_CHECKSTATIONTIME = "CHECKSTATIONTIME";
        public const int nSC_CHECKSTATIONTIME = 216;
        public const string sSC_CHECKSIGNMAP = "CHECKSIGNMAP";
        public const int nSC_CHECKSIGNMAP = 217;
        public const string sSC_HAVEHERO = "HAVEHERO";
        public const int nSC_HAVEHERO = 218;
        public const string sSC_CHECKHEROONLINE = "CHECKHEROONLINE";
        public const int nSC_CHECKHEROONLINE = 219;
        public const string sSC_CHECKHEROLEVEL = "CHECKHEROLEVEL";
        public const int nSC_CHECKHEROLEVEL = 220;
        public const string sSC_CHECKHEROJOB = "CHECKHEROJOB";
        public const int nSC_CHECKHEROJOB = 221;
        public const string sSC_CHECKMINE = "CHECKMINE";// 检测矿纯度  
        public const int nSC_CHECKMINE = 222;
        public const string sSC_GIVEMINE = "GIVEMINE";// 给矿石  
        public const int nSC_GIVEMINE = 223;
        public const string sSC_CHECKCURRENTDATE = "CHECKCURRENTDATE";// 检测当前日期是否小于大于等于指定的日期 
        public const int nSC_CHECKCURRENTDATE = 224;
        public const string sSC_CHECKMASTERONLINE = "CHECKMASTERONLINE";// 检测师傅(或徒弟)是否在线 
        public const int nSC_CHECKMASTERONLINE = 225;
        public const string sSC_CHECKDEARONLINE = "CHECKDEARONLINE";// 检测夫妻一方是否在线
        public const int nSC_CHECKDEARONLINE = 226;
        public const string sSC_CHECKMASTERONMAP = "CHECKMASTERONMAP";// 检测师傅(或徒弟)是否在XXX地图，支持SELF(是否同一地图) 
        public const int nSC_CHECKMASTERONMAP = 227;
        public const string sSC_CHECKDEARONMAP = "CHECKDEARONMAP";// 检测夫妻一方是否在XXX地图，支持SELF(是否同一地图) 
        public const int nSC_CHECKDEARONMAP = 228;
        public const string sSC_CHECKPOSEISPRENTICE = "CHECKPOSEISPRENTICE";// 检测对面是否为自己的徒弟
        public const int nSC_CHECKPOSEISPRENTICE = 229;
        // -------------------------------------------------------------------------
        public const string sSENDTOPMSG = "SENDTOPMSG";// 顶端滚动公告
        public const int nSENDTOPMSG = 230;
        public const string sSENDCENTERMSG = "SENDCENTERMSG";// 屏幕居中显示公告
        public const int nSENDCENTERMSG = 231;
        public const string sSENDEDITTOPMSG = "SENDEDITTOPMSG";// 聊天框顶端公告
        public const int nSENDEDITTOPMSG = 232;
        // -------------------------------------------------------------------------
        public const string sSC_CHECKHEROLOYAL = "CHECKHEROLOYAL";// 检测英雄的忠诚度 
        public const int nSC_CHECKHEROLOYAL = 233;
        public const string sSC_CHANGEHEROLOYAL = "CHANGEHEROLOYAL";// 调整英雄的忠诚度 
        public const int nSC_CHANGEHEROLOYAL = 234;
        // -------------------------------------------------------------------------
        public const string sOPENBOOK = "OPENBOOK";// 卧龙    blue翻书
        public const string sOPENBOOKS = "OPENBOOKS";// 卧龙 
        public const int nOPENBOOKS = 235;
        public const string sSC_RECALLMOBEX = "RECALLMOBEX";// 召唤宝宝
        public const int nSC_RECALLMOBEX = 236;
        public const string sSC_MOVEMOBTO = "MOVEMOBTO";// 将指定坐标的怪物移动到新坐标
        public const int nSC_MOVEMOBTO = 237;
        public const string sSC_CHECKRANGEMONCOUNTEX = "CHECKRANGEMONCOUNTEX";// 魔王岭
        public const string sSC_CHECKMAPMOBCOUNT = "CHECKMAPMOBCOUNT";// 检查地图指定坐标指定名称怪物数量
        public const int nSC_CHECKMAPMOBCOUNT = 238;
        public const string sSC_FINDMAPPATH = "FINDMAPPATH";// 设置地图的起终XY值
        public const int nSC_FINDMAPPATH = 239;
        public const string sREADRANDOMSTR = "READRANDOMSTR";
        // blue的命令随机取文本 无忧加
        public const string sGETRANDOMNAME = "GETRANDOMNAME";
        // 从文件中随机取文本 20080126
        public const int nGETRANDOMNAME = 240;
        public const string sSC_DIV = "DIV";
        // 20080220 变量运算 除法
        public const int nSC_DIV = 241;
        public const string sSC_MUL = "MUL";
        // 20080220 变量运算 乘法
        public const int nSC_MUL = 242;
        public const string sSC_PERCENT = "PERCENT";
        // 20080220 变量运算 百分比
        public const int nSC_PERCENT = 243;
        public const string sTHROUGHHUM = "THROUGHHUM";
        // 改变穿人模式 20080221
        public const int nTHROUGHHUM = 245;
        public const string sSETITEMSLIGHT = "SETITEMSLIGHT";
        // 装备发光设置 20080223
        public const int nSETITEMSLIGHT = 246;
        public const string sSC_CHECKHEROPKPOINT = "CHECKHEROPKPOINT";
        // 检测英雄PK值  20080304
        public const int nSC_CHECKHEROPKPOINT = 247;
        public const string sGIVESTATEITEM = "GIVESTATEITEM";
        // 给予带绑定状态装备 20080312
        public const int nGIVESTATEITEM = 248;
        public const string sSETITEMSTATE = "SETITEMSTATE";
        // 设置装备绑定状态 20080312
        public const int nSETITEMSTATE = 249;
        public const string sCHECKITEMSTATE = "CHECKITEMSTATE";
        // 检查装备绑定状态 20080312
        public const int nCHECKITEMSTATE = 250;
        public const string sISHIGH = "ISHIGH";
        // 检测服务器最高属性人物命令 20080313
        public const int nISHIGH = 251;
        // -------------------------------------------------------------------------
        public const string sOPENYBDEAL = "OPENYBDEAL";
        // 开通元宝交易 20080316
        public const int nOPENYBDEAL = 252;
        public const string sQUERYYBSELL = "QUERYYBSELL";
        // 查询正在出售的物品 20080317
        public const int nQUERYYBSELL = 253;
        public const string sQUERYYBDEAL = "QUERYYBDEAL";
        // 查询可以的购买物品 20080317
        public const int nQUERYYBDEAL = 254;
        public const string sSC_GMEXECUTE = "GMEXECUTE";
        public const int nSC_GMEXECUTE = 255;
        public const string sSC_GUILDCHIEFITEMCOUNT = "GUILDCHIEFITEMCOUNT";
        public const int nSC_GUILDCHIEFITEMCOUNT = 256;
        public const string sSC_GAMEDIAMOND = "GAMEDIAMOND";
        // 调整金刚石数量 20071226
        public const int nSC_GAMEDIAMOND = 257;
        public const string sSC_GAMEGIRD = "GAMEGIRD";
        // 调整灵符数量 20071226
        public const int nSC_GAMEGIRD = 258;
        public const string sSC_MOBFIREBURN = "MOBFIREBURN";
        public const int nSC_MOBFIREBURN = 259;
        public const string sSC_MESSAGEBOX = "MESSAGEBOX";
        public const int nSC_MESSAGEBOX = 260;
        public const string sSC_SETSCRIPTFLAG = "SETSCRIPTFLAG";
        // 设置用于NPC输入框操作的控制标志
        public const int nSC_SETSCRIPTFLAG = 261;
        public const string sSC_SETAUTOGETEXP = "SETAUTOGETEXP";
        public const int nSC_SETAUTOGETEXP = 262;
        public const string sSC_CHANGEHEROEXP = "CHANGEHEROEXP";
        public const int nSC_CHANGEHEROEXP = 263;
        public const string sSC_VAR = "VAR";
        public const int nSC_VAR = 264;
        public const string sSC_LOADVAR = "LOADVAR";
        public const int nSC_LOADVAR = 265;
        public const string sSC_SAVEVAR = "SAVEVAR";
        public const int nSC_SAVEVAR = 266;
        public const string sSC_CALCVAR = "CALCVAR";
        // 自定义变量功能
        public const int nSC_CALCVAR = 267;
        public const string sOFFLINEPLAY = "OFFLINEPLAY";
        // 挂机脚本
        public const int nOFFLINEPLAY = 268;
        public const string sKICKOFFLINE = "KICKOFFLINE";
        public const int nKICKOFFLINE = 269;
        public const string sSTARTTAKEGOLD = "STARTTAKEGOLD";
        public const int nSTARTTAKEGOLD = 270;
        public const string sDELAYGOTO = "DELAYGOTO";
        public const string sDELAYCALL = "DELAYCALL";
        public const int nDELAYGOTO = 271;
        public const string sCLEARDELAYGOTO = "CLEARDELAYGOTO";
        public const int nCLEARDELAYGOTO = 272;
        public const string sSC_CHANGEHEROPKPOINT = "CHANGEHEROPKPOINT";
        public const int nSC_CHANGEHEROPKPOINT = 273;
        public const string sSC_ADDUSERDATE = "ADDUSERDATE";
        public const int nSC_ADDUSERDATE = 274;
        public const string sSC_DELUSERDATE = "DELUSERDATE";
        public const int nSC_DELUSERDATE = 275;
        public const string sSC_ANSIREPLACETEXT = "ANSIREPLACETEXT";
        public const int nSC_ANSIREPLACETEXT = 276;
        public const string sSC_ENCODETEXT = "ENCODETEXT";
        public const int nSC_ENCODETEXT = 277;
        public const string sSC_GAMEGLORY = "CHANGEGLORY";
        // 调整荣誉值 20080511
        public const int nSC_GAMEGLORY = 278;
        public const string sSC_ADDTEXTLIST = "ADDTEXTLIST";
        public const int nSC_ADDTEXTLIST = 279;
        public const string sSC_DELTEXTLIST = "DELTEXTLIST";
        public const int nSC_DELTEXTLIST = 280;
        public const string sSC_GROUPMAPMOVE = "GROUPMAPMOVE";
        public const int nSC_GROUPMAPMOVE = 281;
        public const string sSC_RECALLHUMAN = "RECALLHUMAN";
        public const int nSC_RECALLHUMAN = 282;
        public const string sSC_REGOTO = "REGOTO";
        public const int nSC_REGOTO = 283;
        public const string sSC_INTTOSTR = "INTTOSTR";
        public const int nSC_INTTOSTR = 284;
        public const string sSC_STRTOINT = "STRTOINT";
        public const int nSC_STRTOINT = 285;
        public const string sSC_GUILDMOVE = "GUILDMOVE";
        public const int nSC_GUILDMOVE = 286;
        public const string sSC_GUILDMAPMOVE = "GUILDMAPMOVE";
        public const int nSC_GUILDMAPMOVE = 287;
        public const string sSC_RANDOMMOVE = "RANDOMMOVE";
        public const int nSC_RANDOMMOVE = 288;
        public const string sSC_BONUSABIL = "BONUSABIL";
        // 无忧加对blue脚本的支持
        public const string sSC_USEBONUSPOINT = "USEBONUSPOINT";
        // 永久增加人物属性点
        public const int nSC_USEBONUSPOINT = 289;
        public const string sSC_TAKEONITEM = "TAKEONITEM";
        // 穿上物品
        public const int nSC_TAKEONITEM = 290;
        public const string sSC_TAKEOFFITEM = "TAKEOFFITEM";
        public const int nSC_TAKEOFFITEM = 291;
        public const string sSC_CREATEHERO = "CREATEHERO";
        public const int nSC_CREATEHERO = 292;
        public const string sSC_DELETEHERO = "DELETEHERO";
        public const int nSC_DELETEHERO = 293;
        public const string sSC_CHANGEHEROLEVEL = "CHANGEHEROLEVEL";
        public const int nSC_CHANGEHEROLEVEL = 294;
        public const string sSC_CHANGEHEROJOB = "CHANGEHEROJOB";
        public const int nSC_CHANGEHEROJOB = 295;
        public const string sSC_CLEARHEROSKILL = "CLEARHEROSKILL";
        // 清除英雄技能
        public const int nSC_CLEARHEROSKILL = 296;
        public const string sSC_CHECKGAMEDIAMOND = "CHECKGAMEDIAMOND";
        // 检查金刚石数量 20071227
        public const int nSC_CHECKGAMEDIAMOND = 297;
        public const string sSC_CHECKGAMEGIRD = "CHECKGAMEGIRD";
        // 检查灵符数量 20071227
        public const int nSC_CHECKGAMEGIRD = 298;
        public const string sSC_SETRANKLEVELNAME = "SETRANKLEVELNAME";
        public const int nSC_SETRANKLEVELNAME = 299;
        public const string sSC_CHANGELEVEL = "CHANGELEVEL";
        public const int nSC_CHANGELEVEL = 300;
        public const string sSC_MARRY = "MARRY";
        public const int nSC_MARRY = 301;
        public const string sSC_UNMARRY = "UNMARRY";
        public const int nSC_UNMARRY = 302;
        public const string sSC_GETMARRY = "GETMARRY";
        public const int nSC_GETMARRY = 303;
        public const string sSC_GETMASTER = "GETMASTER";
        public const int nSC_GETMASTER = 304;
        public const string sSC_CLEARSKILL = "CLEARSKILL";
        public const int nSC_CLEARSKILL = 305;
        public const string sSC_DELNOJOBSKILL = "DELNOJOBSKILL";
        public const int nSC_DELNOJOBSKILL = 306;
        public const string sSC_DELSKILL = "DELSKILL";
        // 删除技能
        public const int nSC_DELSKILL = 307;
        public const string sSC_ADDSKILL = "ADDSKILL";
        // 增加技能 支持英雄
        public const int nSC_ADDSKILL = 308;
        public const string sSC_SKILLLEVEL = "SKILLLEVEL";
        // 调整技能等级
        public const int nSC_SKILLLEVEL = 309;
        public const string sSC_CHANGEPKPOINT = "CHANGEPKPOINT";
        public const int nSC_CHANGEPKPOINT = 310;
        public const string sSC_CHANGEEXP = "CHANGEEXP";
        public const int nSC_CHANGEEXP = 311;
        public const string sSC_CHANGEJOB = "CHANGEJOB";
        public const int nSC_CHANGEJOB = 312;
        public const string sSC_MISSION = "MISSION";
        public const int nSC_MISSION = 313;
        public const string sSC_MOBPLACE = "MOBPLACE";
        public const int nSC_MOBPLACE = 314;
        public const string sSC_SETMEMBERTYPE = "SETMEMBERTYPE";
        public const int nSC_SETMEMBERTYPE = 315;
        public const string sSC_SETMEMBERLEVEL = "SETMEMBERLEVEL";
        public const int nSC_SETMEMBERLEVEL = 316;
        public const string sSC_GAMEGOLD = "GAMEGOLD";
        // 调整元宝数
        public const int nSC_GAMEGOLD = 317;
        public const string sSC_AUTOADDGAMEGOLD = "AUTOADDGAMEGOLD";
        public const int nSC_AUTOADDGAMEGOLD = 318;
        public const string sSC_AUTOSUBGAMEGOLD = "AUTOSUBGAMEGOLD";
        public const int nSC_AUTOSUBGAMEGOLD = 319;
        public const string sSC_CHANGENAMECOLOR = "CHANGENAMECOLOR";
        public const int nSC_CHANGENAMECOLOR = 320;
        public const string sSC_CLEARPASSWORD = "CLEARPASSWORD";
        public const int nSC_CLEARPASSWORD = 321;
        public const string sSC_RENEWLEVEL = "RENEWLEVEL";
        public const int nSC_RENEWLEVEL = 322;
        public const string sSC_KILLMONEXPRATE = "KILLMONEXPRATE";
        // 调整杀怪经验的倍数
        public const int nSC_KILLMONEXPRATE = 323;
        public const string sSC_POWERRATE = "POWERRATE";
        public const int nSC_POWERRATE = 324;
        public const string sSC_CHANGEMODE = "CHANGEMODE";
        // 改变管理模式(不检查权限)
        public const int nSC_CHANGEMODE = 325;
        public const string sSC_CHANGEPERMISSION = "CHANGEPERMISSION";
        public const int nSC_CHANGEPERMISSION = 326;
        public const string sSC_KILL = "KILL";
        public const int nSC_KILL = 327;
        public const string sSC_KICK = "KICK";
        public const int nSC_KICK = 328;
        public const string sSC_BONUSPOINT = "BONUSPOINT";
        public const int nSC_BONUSPOINT = 329;
        public const string sSC_RESTRENEWLEVEL = "RESTRENEWLEVEL";
        public const int nSC_RESTRENEWLEVEL = 330;
        public const string sSC_DELMARRY = "DELMARRY";
        public const int nSC_DELMARRY = 331;
        public const string sSC_DELMASTER = "DELMASTER";
        public const int nSC_DELMASTER = 332;
        public const string sSC_MASTER = "MASTER";
        public const int nSC_MASTER = 333;
        public const string sSC_UNMASTER = "UNMASTER";
        public const int nSC_UNMASTER = 334;
        public const string sSC_CREDITPOINT = "CREDITPOINT";
        public const int nSC_CREDITPOINT = 335;
        public const string sSC_CLEARNEEDITEMS = "CLEARNEEDITEMS";
        public const int nSC_CLEARNEEDITEMS = 336;
        public const string sSC_CLEARMAKEITEMS = "CLEARMAKEITEMS";
        public const int nSC_CLEARMAEKITEMS = 337;
        public const string sSC_SETSENDMSGFLAG = "SETSENDMSGFLAG";
        public const int nSC_SETSENDMSGFLAG = 338;
        public const string sSC_UPGRADEITEMS = "UPGRADEITEM";
        public const int nSC_UPGRADEITEMS = 339;
        public const string sSC_UPGRADEITEMSEX = "UPGRADEITEMEX";
        public const int nSC_UPGRADEITEMSEX = 340;
        public const string sSC_MONGENEX = "MONGENEX";
        public const int nSC_MONGENEX = 341;
        public const string sSC_CLEARMAPMON = "CLEARMAPMON";
        public const int nSC_CLEARMAPMON = 342;
        public const string sSC_SETMAPMODE = "SETMPAMODE";
        public const int nSC_SETMAPMODE = 343;
        public const string sSC_GAMEPOINT = "GAMEPOINT";
        public const int nSC_GAMEPOINT = 344;
        public const string sSC_PKZONE = "PKZONE";
        public const int nSC_PKZONE = 345;
        public const string sSC_RESTBONUSPOINT = "RESTBONUSPOINT";
        public const int nSC_RESTBONUSPOINT = 346;
        public const string sSC_TAKECASTLEGOLD = "TAKECASTLEGOLD";
        public const int nSC_TAKECASTLEGOLD = 347;
        public const string sSC_HUMANHP = "HUMANHP";
        public const int nSC_HUMANHP = 348;
        public const string sSC_HUMANMP = "HUMANMP";
        public const int nSC_HUMANMP = 349;
        public const string sSC_BUILDPOINT = "GUILDBUILDPOINT";
        public const int nSC_BUILDPOINT = 350;
        public const string sSC_AURAEPOINT = "GUILDAURAEPOINT";
        public const int nSC_AURAEPOINT = 351;
        public const string sSC_STABILITYPOINT = "GUILDSTABILITYPOINT";
        public const int nSC_STABILITYPOINT = 352;
        public const string sSC_FLOURISHPOINT = "GUILDFLOURISHPOINT";
        public const int nSC_FLOURISHPOINT = 353;
        public const string sSC_OPENBOX = "OPENBOX";
        // 无忧加对blue脚本开宝箱的功能
        public const string sSC_OPENMAGICBOX = "OPENITEMBOX";
        public const int nSC_OPENMAGICBOX = 354;
        public const string sSC_CHECKMAKEWINE = "CHECKMAKEWINE";
        // 检测酒品质  20080806
        public const int nSC_CHECKMAKEWINE = 356;
        // ---------------------------------------------------------
        public const string sSC_CHECKONLINEPLAYCOUNT = "CHECKONLINEPLAYCOUNT";
        public const int nSC_CHECKONLINEPLAYCOUNT = 357;
        public const string sSC_CHECKPLAYDIELVL = "CHECKPLAYDIELVL";
        public const int nSC_CHECKPLAYDIELVL = 358;
        // 杀人后检测
        public const string sSC_CHECKPLAYDIEJOB = "CHECKPLAYDIEJOB";
        public const int nSC_CHECKPLAYDIEJOB = 359;
        public const string sSC_CHECKPLAYDIESEX = "CHECKPLAYDIESEX";
        public const int nSC_CHECKPLAYDIESEX = 360;
        public const string sSC_CHECKKILLPLAYLVL = "CHECKKILLPLAYLVL";
        public const int nSC_CHECKKILLPLAYLVL = 361;
        // 死亡后检测
        public const string sSC_CHECKKILLPLAYJOB = "CHECKKILLPLAYJOB";
        public const int nSC_CHECKKILLPLAYJOB = 362;
        public const string sSC_CHECKKILLPLAYSEX = "CHECKKILLPLAYSEX";
        public const int nSC_CHECKKILLPLAYSEX = 363;
        public const string sSC_CHECKITEMLEVEL = "CHECKITEMLEVEL";
        // 检查装备升级次数 
        public const int nSC_CHECKITEMLEVEL = 364;
        public const string sCHECKITEMSNAME = "CHECKITEMSNAME";
        // 检查指定装备位置是否带有指定的物品
        public const int nCHECKITEMSNAME = 365;
        public const string sKILLBYHUM = "KILLBYHUM";
        // 检测是否被人物所杀 
        public const int nKILLBYHUM = 366;
        public const string sREADSKILLNG = "READSKILLNG";
        // NPC学习内功 
        public const int nREADSKILLNG = 367;
        public const string sSC_CHANGENGEXP = "CHANGENGEXP";
        // 调整人物内力经验点数 
        public const int nSC_CHANGENGEXP = 368;
        public const string sSC_CHANGREADNG = "CHANGREADNG";
        // 检查角色是否学过内功 
        public const int nSC_CHANGREADNG = 369;
        public const string sSC_CHANGENGLEVEL = "CHANGENGLEVEL";
        // 调整人物内力等级 
        public const int nSC_CHANGENGLEVEL = 370;
        public const string sSC_CHANGEGUILDFOUNTAIN = "CHANGEGUILDFOUNTAIN";
        // 调整行会酒泉 
        public const int nSC_CHANGEGUILDFOUNTAIN = 371;
        public const string sCHECKGUILDFOUNTAINVALUE = "CHECKGUILDFOUNTAINVALUE";
        // 检测行会酒泉数 20081017
        public const int nCHECKGUILDFOUNTAINVALUE = 372;
        public const string sSC_TAGMAPINFO = "TAGMAPINFO";
        // 记路标石 20081019
        public const int nSC_TAGMAPINFO = 373;
        public const string sSC_TAGMAPMOVE = "TAGMAPMOVE";
        // 移动到记路标石记录的地图XY 20081019
        public const int nSC_TAGMAPMOVE = 374;
        public const string sCHECKNGLEVEL = "CHECKNGLEVEL";
        // 检查角色内功等级 20081223
        public const int nCHECKNGLEVEL = 375;
        public const string sCREATEFILE = "CREATEFILE";
        // 创建文本文件 20081226
        public const int nCREATEFILE = 376;
        public const string sSC_SENDMSGWINDOWS = "SENDMSGWINDOWS";
        // 时间到解发QF段 20090124
        public const int nSC_SENDMSGWINDOWS = 377;
        public const string sSC_CHECKSTRINGLENGTH = "CHECKSTRINGLENGTH";
        // 检查字符串的长度 20090105
        public const int nSC_CHECKSTRINGLENGTH = 378;
        public const string sCHECKGUILDMEMBERCOUNT = "CHECKGUILDMEMBERCOUNT";
        // 检测行会成员上限 20090115
        public const int nCHECKGUILDMEMBERCOUNT = 379;
        public const string sSC_CHANGEGUILDMEMBERCOUNT = "CHANGEGUILDMEMBERCOUNT";
        // 调整行会成员上限 20090115
        public const int nSC_CHANGEGUILDMEMBERCOUNT = 380;
        public const string sSC_SENDTIMEMSG = "SENDTIMEMSG";
        // 时间到解发QF段(客户端显示时间) 20090124
        public const int nSC_SENDTIMEMSG = 381;
        public const string sSC_GETGROUPCOUNT = "GETGROUPCOUNT";
        // 取组队成员数 
        public const int nSC_GETGROUPCOUNT = 382;
        public const string sSC_CLOSEMSGWINDOWS = "CLOSEMSGWINDOWS";
        // 关闭客户端'!'图标的显示 
        public const int nSC_CLOSEMSGWINDOWS = 383;
        public const string sSC_OPENEXPCRYSTAL = "OPENEXPCRYSTAL";
        // 客户端显示天地结晶 20090131
        public const int nSC_OPENEXPCRYSTAL = 384;
        public const string sSC_CLOSEEXPCRYSTAL = "CLOSEEXPCRYSTAL";
        // 客户端显示天地结晶 20090131
        public const int nSC_CLOSEEXPCRYSTAL = 385;
        public const string sSC_GETEXPTOCRYSTAL = "GETEXPTOCRYSTAL";
        // 取提天地结晶中的经验(只提取可提取的经验) 20090202
        public const int nSC_GETEXPTOCRYSTAL = 386;
        // --------------------------连击相关------------------------------------------//
        public const string sSC_OPENMAKEKIMNEEDLE = "OPENMAKEKIMNEEDLE";
        // 客户端显示锻练金针窗口
        public const int nSC_OPENMAKEKIMNEEDLE = 387;
        public const string sSC_CHECKKIMNEEDLE = "CHECKKIMNEEDLE";
        // 检查包裹是否有指定叠加物品
        public const int nSC_CHECKKIMNEEDLE = 388;
        public const string sSC_TAKEKIMNEEDLE = "TAKEKIMNEEDLE";
        public const int nSC_TAKEKIMNEEDLE = 389;
        public const string sSC_GIVEKIMNEEDLE = "GIVEKIMNEEDLE";
        public const int nSC_GIVEKIMNEEDLE = 390;
        public const string sSC_CHECKHUMANPULSE = "CHECKHUMANPULSE";
        public const int nSC_CHECKHUMANPULSE = 391;
        public const string sSC_CHECKOPENPULSELEVEL = "CHECKOPENPULSELEVEL";
        public const int nSC_CHECKOPENPULSELEVEL = 392;
        public const string sSC_OPENPULSE = "OPENPULSE";
        public const int nSC_OPENPULSE = 393;
        // sSC_USEBONUSPOINT     = 'USEBONUSPOINT';
        // nSC_USEBONUSPOINT     = 394;
        public const string sSC_CHANGEPULSELEVEL = "CHANGEPULSELEVEL";
        public const int nSC_CHANGEPULSELEVEL = 395;
        public const string sSC_CHECKPULSELEVEL = "CHECKPULSELEVEL";
        public const int nSC_CHECKPULSELEVEL = 396;
        public const string sSC_CHANGHEARMSGCOLOR = "CHANGHEARMSGCOLOR";
        // 未实现 20091219 邱高奇
        public const int nSC_CHANGHEARMSGCOLOR = 397;
        public const string sSC_CHECKHEARMSGCOLOR = "CHECKHEARMSGCOLOR";
        public const int nSC_CHECKHEARMSGCOLOR = 398;
        // 功能：开通英雄经脉(学了内功才能使用)
        // 格式：OPENHEROPULS
        public const string sSC_OPENHEROPULS = "OPENHEROPULS";
        public const int nSC_OPENHEROPULS = 400;
        // 功能：改变英雄经络修炼点(打通一条经络后才有效)
        // 格式：CHANGEHEROPULSEXP 控制符(+,-,=) 经验值
        public const string sSC_CHANGEHEROPULSEXP = "CHANGEHEROPULSEXP";
        public const int nSC_CHANGEHEROPULSEXP = 401;
        // 功能：检查英雄是否开通经脉系统(英雄不在线，没学内功都将为F)
        // 格式：CHECKHEROOPENOPULS
        public const string sSC_CHECKHEROOPENOPULS = "CHECKHEROOPENOPULS";
        // 未实现 20091219 邱高奇
        public const int nSC_CHECKHEROOPENOPULS = 402;
        // 功能：检查英雄经络修炼点
        // 格式：CHECKHEROPULSEXP 控制符(>,<,=) 经验值
        public const string sSC_CHECKHEROPULSEXP = "CHECKHEROPULSEXP";
        public const int nSC_CHECKHEROPULSEXP = 403;
        // 功能：检查物品数量以及持久值
        // 命令格式:CHECKITMECOUNTDURA 物品名称 数量 操作符(<>=) 持久(MaxDura--物品的持久上限)
        // 注：持久是按M2上的数据，并非客户端显示的数据
        public const string sSC_CHECKITMECOUNTDURA = "CHECKITMECOUNTDURA";
        // 未实现 20091219 邱高奇
        public const int nSC_CHECKITMECOUNTDURA = 404;
        // 功能：收回指定名称物品(按数量，持久)
        // 格式：TAKEITMECOUNTDURA 物品名称 数量 操作符(<>=) 持久(MaxDura--物品的持久上限)
        public const string sSC_TAKEITMECOUNTDURA = "TAKEITMECOUNTDURA";
        // 未实现 20091219 邱高奇
        public const int nSC_TAKEITMECOUNTDURA = 405;
        // -------富贵兽相关------------//
        // 功能：客户端显示牛气管图标
        // 格式：OPENCATTLEGAS 是否清空变量
        // 说明: 参数为空时,表示清空变量,不为空时,表示不需要清变量
        public const string sSC_OPENCATTLEGAS = "OPENCATTLEGAS";
        public const int nSC_OPENCATTLEGAS = 406;
        // 功能：客户端关闭牛气管图标
        // 格式：CLOSECATTLEGAS
        public const string sSC_CLOSECATTLEGAS = "CLOSECATTLEGAS";
        public const int nSC_CLOSECATTLEGAS = 407;
        // 功能:调整人物牛气值
        // 格式:CHANGECATTLEGASEXP 控制符(=,+,-) 牛气值点数
        public const string sSC_CHANGECATTLEGASEXP = "CHANGECATTLEGASEXP";// 未实现
        public const int nSC_CHANGECATTLEGASEXP = 408;
        // -------双英雄相关--------------------//
        public const string sSC_ASSESSMENTHERO = "ASSESSMENTHERO";// 功能：弹出评定主副将窗口 20091219 邱高奇
        public const int nSC_ASSESSMENTHERO = 409;
        public const string sSC_CheckAssessMentHero = "CHECKASSESSMENTHERO";// 功能：检查是否评定过主副将英雄 20091219 邱高奇
        public const int nSC_CheckAssessMentHero = 410;
        public const string sSC_CheckDeputyHero = "CHECKDEPUTYHERO";// 功能：检查当前在线英雄是否为副将英雄
        public const int nSC_CheckDeputyHero = 411;
        public const string sSC_CheckHeroAutoPractice = "CHECKHEROAUTOPRACTICE";// 功能：检查副将英雄是否正在自我修
        public const int nSC_CheckHeroAutoPractice = 412;
        public const string sSC_OpenHeroAutoPractice = "OPENHEROAUTOPRACTICE";// 功能: 打开英雄自我修炼窗口
        public const int nSC_OpenHeroAutoPractice = 413;
        public const string sSC_StopHeroAutoPractice = "STOPHEROAUTOPRACTICE";// 功能: 停止英雄自我修炼 
        public const int nSC_StopHeroAutoPractice = 414;// 注：当修炼计时达到7200秒后，执行命令则触发@StopHeroAuto脚本，以实现给玩家物品
        public const string sSC_CHECKSKILL75 = "CHECKSKILL75";// 检查是否学习过护体神盾
        public const int nSC_CHECKSKILL75 = 415;
        public const string sSC_CHANGETRANPOINT = "CHANGETRANPOINT";// 技能名 操作符(+ - =) 数值
        public const int nSC_CHANGETRANPOINT = 416;
        public const string sSC_NPCGIVEITEM = "NPCGIVEITEM";
        public const int nSC_NPCGIVEITEM = 417;
        public const string sSC_CHECKHUMINRANGE = "CHECKHUMINRANGE";// 无忧加检测指定人物是否在指定地图范围之内
        public const int nSC_CHECKHUMINRANGE = 418;
        public const string sSC_MAPHUMISSAMEGUILD = "MAPHUMISSAMEGUILD";// 无忧加检测当前地图中的人物是否属于同一个行会(所有人是同一行会才为真)
        public const int nSC_MAPHUMISSAMEGUILD = 419;
        public const string sSL_SENDMSG = "@@sendmsg";// 祝福语标识
        public const string sSUPERREPAIR = "@s_repair";
        public const string sSUPERREPAIROK = "~@s_repair";// 特殊修理
        public const string sSUPERREPAIRFAIL = "@fail_s_repair";
        public const string sREPAIR = "@repair";// 修理
        public const string sREPAIROK = "~@repair";
        public const string sBUY = "@buy";// 买物品
        public const string sSELL = "@sell";// 卖物品
        public const string sMAKEDURG = "@makedrug";// 炼药
        public const string sPRICES = "@prices";
        public const string sSTORAGE = "@storage";// 存仓库
        public const string sGETBACK = "@getback";// 取仓库
        public const string sBIGSTORAGE = "@bigstorage";
        public const string sBIGGETBACK = "@biggetback";
        public const string sGETPREVIOUSPAGE = "@getpreviouspage";
        public const string sGETNEXTPAGE = "@getnextpage";
        public const string sUPGRADENOW = "@upgradenow";// 升级物品
        public const string sUPGRADEING = "~@upgradenow_ing";
        public const string sUPGRADEOK = "~@upgradenow_ok";
        public const string sUPGRADEFAIL = "~@upgradenow_fail";
        public const string sGETBACKUPGNOW = "@getbackupgnow";
        public const string sGETBACKUPGOK = "~@getbackupgnow_ok";
        public const string sGETBACKUPGFAIL = "~@getbackupgnow_fail";
        public const string sGETBACKUPGFULL = "~@getbackupgnow_bagfull";
        public const string sGETBACKUPGING = "~@getbackupgnow_ing";
        public const string sEXIT = "@exit";
        public const string sBACK = "@back";
        public const string sMAIN = "@main";
        public const string sFAILMAIN = "~@main";
        public const string sGETMASTER = "@@getmaster";
        public const string sGETMARRY = "@@getmarry";
        public const string sUSEITEMNAME = "@@useitemname";
        public const string sRMST = "@@rmst";// 接受歌曲
        public const string sofflinemsg = "@@offlinemsg";// 挂机自动回复
        public const string sstartdealgold = "@startdealgold";// 元宝转帐
        public const string sdealgold = "@@dealgold";
        public const string sBUILDGUILDNOW = "@@buildguildnow";
        public const string sSCL_GUILDWAR = "@@guildwar";
        public const string sDONATE = "@@donate";
        public const string sREQUESTCASTLEWAR = "@requestcastlewarnow";
        public const string sCASTLENAME = "@@castlename";// 城堡改名
        public const string sWITHDRAWAL = "@@withdrawal";// 沙巴克取回资金
        public const string sRECEIPTS = "@@receipts";// 沙巴克存资金
        public const string sOPENMAINDOOR = "@openmaindoor";// 沙巴克开门
        public const string sCLOSEMAINDOOR = "@closemaindoor";// 沙巴克关门
        public const string sREPAIRDOORNOW = "@repairdoornow";// 马上修复城门
        public const string sREPAIRWALLNOW1 = "@repairwallnow1";// 修城墙一
        public const string sREPAIRWALLNOW2 = "@repairwallnow2";// 修城墙二
        public const string sREPAIRWALLNOW3 = "@repairwallnow3";// 修城墙三
        public const string sHIREARCHERNOW = "@hirearchernow";
        public const string sHIREGUARDNOW = "@hireguardnow";
        public const string sHIREGUARDOK = "@hireguardok";
        public const string sMarket_Def = "Market_Def\\";
        public const string sNpc_def = "Npc_def\\";
        public const string sUserLevelOrder = "@UserLevelOrder";
        public const string sWarrorLevelOrder = "@WarrorLevelOrder";
        public const string sWizardLevelOrder = "@WizardLevelOrder";
        public const string sTaoistLevelOrder = "@TaoistLevelOrder";
        public const string sMasterCountOrder = "@MasterCountOrder";
        public const string sLevelOrderHomePage = "@LevelOrderHomePage";
        public const string sLevelOrderPreviousPage = "@LevelOrderPreviousPage";
        public const string sLevelOrderNextPage = "@LevelOrderNextPage";
        public const string sLevelOrderLastPage = "@LevelOrderLastPage";
        public const string sMyLevelOrder = "@MyLevelOrder";
        public const string sLyCreateHero = "@@LyCreateHero";// 创建英雄脚本命令
        public const string sBuHero = "@@BuHero";// 酒馆英雄NPC
        public const string sPlayMakeWine = "@PlayMakeWine";// 酿酒 标识
        public const string sPlayDrink = "@PlayDrink";// 请酒,斗酒
        public const string sDealYBme = "@dealybme";// 元宝寄售:出售物品
        public const string sybdeal = "@ybdeal";
        public const string U_DRESSNAME = "衣服";
        public const string U_WEAPONNAME = "武器";
        public const string U_RIGHTHANDNAME = "照明物";
        public const string U_NECKLACENAME = "项链";
        public const string U_HELMETNAME = "头盔";
        public const string U_ARMRINGLNAME = "左手镯";
        public const string U_ARMRINGRNAME = "右手镯";
        public const string U_RINGLNAME = "左戒指";
        public const string U_RINGRNAME = "右戒指";
        public const string U_ZHULINAME = "斗笠";// 斗笠
        public const string U_BUJUKNAME = "物品";
        public const string U_BELTNAME = "腰带";
        public const string U_BOOTSNAME = "鞋子";
        public const string U_CHARMNAME = "宝石";
        public const string StrStorm = "您的%s出现暴击, 造成了额外的伤害";
        public static int GetPageCount(int ItemCount)
        {
            int result;
            result = 0;
            if (ItemCount > 7)
            {
                result = ItemCount / 7;
                if ((ItemCount % 7) > 0)
                {
                    result++;
                }
                result -= 1;
            }
            return result;
        }
        public static TStringList GetPlayObjectOrderList(int nType)
        {
            TStringList result;
            //EnterCriticalSection(HumanSortCriticalSection);
            try
            {
                result = null;
                switch (nType)
                {
                    case 0:
                        result = UserEngine.m_PlayObjectLevelList;
                        break;
                    case 1:
                        // 人物等级排名
                        result = UserEngine.m_WarrorObjectLevelList;
                        break;
                    case 2:
                        result = UserEngine.m_WizardObjectLevelList;
                        break;
                    case 3:
                        result = UserEngine.m_TaoistObjectLevelList;
                        break;
                    case 4:
                        result = UserEngine.m_PlayObjectMasterList;
                        break;
                }
            }
            finally
            {
                // LeaveCriticalSection(HumanSortCriticalSection);
            }
            return result;
        }

        public static string GetStartTime(uint nTime)
        {
            string result;
            uint h;
            uint s;
            uint m;
            uint s1;
            if (nTime >= 3600)
            {
                h = nTime / 3600;
                s = nTime % 3600;// 剩余秒
                m = s / 60;
                s1 = s % 60;
                result = string.Format("{0}小时{1}分钟{2}秒", h, m, s1);
            }
            else
            {
                if (nTime >= 60)
                {
                    m = nTime / 60;
                    s = nTime % 60;
                    result = string.Format("{0}分钟{1}秒", m, s);
                }
                else
                {
                    result = string.Format("{0}秒", nTime);
                }
            }
            return result;
        }

        public unsafe static void CopyStdItemToOStdItem(TStdItem* StdItem, TOStdItem* OStdItem)
        {
            HUtil32.StrToSByteArry(HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen), OStdItem->Name, 14, ref OStdItem->NameLen);
            OStdItem->StdMode = StdItem->StdMode;
            OStdItem->Shape = StdItem->Shape;
            OStdItem->Weight = StdItem->Weight;
            OStdItem->AniCount = StdItem->AniCount;
            OStdItem->Source = StdItem->Source;
            OStdItem->Reserved = StdItem->Reserved;
            OStdItem->NeedIdentify = StdItem->NeedIdentify;
            OStdItem->Looks = StdItem->Looks;
            OStdItem->DuraMax = (ushort)StdItem->DuraMax;
            OStdItem->AC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->AC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->AC)));
            OStdItem->MAC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->MAC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->MAC)));
            OStdItem->DC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->DC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->DC)));
            OStdItem->MC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->MC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->MC)));
            OStdItem->SC = HUtil32.MakeWord((byte)HUtil32._MIN(Byte.MaxValue, (byte)HUtil32.LoWord((byte)StdItem->SC)), (byte)HUtil32._MIN(Byte.MaxValue, HUtil32.HiWord((byte)StdItem->SC)));
            OStdItem->Need = (byte)StdItem->Need;
            OStdItem->NeedLevel = (byte)StdItem->NeedLevel;
            OStdItem->Price = StdItem->Price;
        }

        /// <summary>
        /// 读取公告内容
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static bool LoadLineNotice(string FileName)
        {
            bool result = false;
            int I;
            string sText;
            if (File.Exists(FileName))
            {
                LineNoticeList.LoadFromFile(FileName);
                I = 0;
                while (true)
                {
                    if (LineNoticeList.Count <= I)
                    {
                        break;
                    }
                    sText = LineNoticeList[I].Trim();
                    if (sText == "")
                    {
                        LineNoticeList.RemoveAt(I);
                        continue;
                    }
                    LineNoticeList[I] = sText;
                    I++;
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 加载自定义命令
        /// </summary>
        public static void LoadUserCmdList()
        {
            string sFileName;
            TStringList LoadList;
            string sLineText = string.Empty;
            string sUserCmd = string.Empty;
            string sCmdNo = string.Empty;
            int nCmdNo = 0;
            sFileName = ".\\UserCmd.txt";
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件配置文件");
                LoadList.Add(";命令名称\09对应编号");
                LoadList.SaveToFile(sFileName);
                return;
            }
            g_UserCmdList.Clear();
            LoadList = new TStringList();
            LoadList.LoadFromFile(sFileName);
            for (int I = 0; I < LoadList.Count; I++)
            {
                sLineText = LoadList[I];
                if ((sLineText != "") && (sLineText[0] != ';'))
                {
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sUserCmd, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCmdNo, new string[] { " ", "\09" });
                    nCmdNo = HUtil32.Str_ToInt(sCmdNo, -1);
                    if ((sUserCmd != "") && (nCmdNo >= 0))
                    {
                        // g_UserCmdList.Add(sUserCmd, ((nCmdNo) as Object));
                    }
                }
            }
        }

        /// <summary>
        /// 加载禁止物品规则
        /// </summary>
        public static void LoadCheckItemList()
        {
            string sFileName;
            TStringList LoadList;
            string sLineText;
            string sItemName = string.Empty;// 物品名称
            string sCanDrop = string.Empty;// 能否丢弃
            string sCanDeal = string.Empty;// 能否交易
            string sCanStorage = string.Empty;// 能否存仓
            string sCanRepair = string.Empty;// 能否修理
            string sCanDropHint = string.Empty;// 是否掉落提示
            string sCanOpenBoxsHint = string.Empty;// 是否开宝箱提示
            string sCanNoDropItem = string.Empty;// 是否永不暴出
            string sCanButchHint = string.Empty;// 是否挖取提示
            string sCanHeroUse = string.Empty;// 是否禁止英雄使用
            string sCanPickUpItem = string.Empty;// 禁止捡起(除GM外)
            string sCanDieDropItems = string.Empty;// 死亡掉落
            TCheckItem CheckItem;
            sFileName = ".\\CheckItemList.txt";
            if (g_CheckItemList.Count > 0)// 禁止物品规则
            {
                for (int I = 0; I < g_CheckItemList.Count; I++)
                {
                    if (g_CheckItemList[I] != null)
                    {
                        Dispose(g_CheckItemList[I]);
                    }
                }
            }
            g_CheckItemList.Clear();
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件禁止物品配置文件");
                LoadList.Add(";物品名称\09丢弃\09交易\09存仓\09修理\09掉落提示\09开宝箱提示\09永不暴出\09挖取提示");
                LoadList.SaveToFile(sFileName);
                return;
            }
            LoadList = new TStringList();
            LoadList.LoadFromFile(sFileName);
            for (int I = 0; I < LoadList.Count; I++)
            {
                sLineText = LoadList[I];
                if ((sLineText != "") && (sLineText[0] != ';'))
                {
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDrop, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDeal, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanStorage, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanRepair, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDropHint, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanOpenBoxsHint, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanNoDropItem, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanButchHint, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanHeroUse, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanPickUpItem, new string[] { " ", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sCanDieDropItems, new string[] { " ", "\09" });
                    if ((sItemName != ""))
                    {
                        CheckItem = new TCheckItem();
                        CheckItem.szItemName = sItemName;
                        CheckItem.boCanDrop = sCanDrop != "0";
                        CheckItem.boCanDeal = sCanDeal != "0";
                        CheckItem.boCanStorage = sCanStorage != "0";
                        CheckItem.boCanRepair = sCanRepair != "0";
                        CheckItem.boCanDropHint = sCanDropHint != "0";
                        CheckItem.boCanOpenBoxsHint = sCanOpenBoxsHint != "0";
                        CheckItem.boCanNoDropItem = sCanNoDropItem != "0";
                        CheckItem.boCanButchHint = sCanButchHint != "0";
                        CheckItem.boCanHeroUse = sCanHeroUse != "0";
                        CheckItem.boPickUpItem = sCanPickUpItem != "0";
                        CheckItem.boDieDropItems = sCanDieDropItems != "0";// 死亡掉落
                        g_CheckItemList.Add(CheckItem);
                    }
                }
            }
        }

        /// <summary>
        /// 加载消息过滤
        /// </summary>
        public static void LoadMsgFilterList()
        {
            string sFileName = string.Empty;
            TStringList LoadList;
            string sLineText = string.Empty;
            string sFilterMsg = string.Empty;
            string sNewMsg = string.Empty;
            TFilterMsg FilterMsg;
            sFileName = ".\\MsgFilterList.txt";
            if (g_MsgFilterList.Count > 0)
            {
                for (int I = 0; I < g_MsgFilterList.Count; I++)
                {
                    if (g_MsgFilterList[I] != null)
                    {
                        Dispose(g_MsgFilterList[I]);
                    }
                }
            }
            g_MsgFilterList.Clear();
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件消息过滤配置文件");
                LoadList.Add(";过滤消息\09替换消息");
                LoadList.SaveToFile(sFileName);
                return;
            }
            LoadList = new TStringList();
            try
            {
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sFilterMsg, new string[] { " ", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sNewMsg, new string[] { " ", "\09" });
                        if ((sFilterMsg != ""))
                        {
                            FilterMsg = new TFilterMsg();
                            FilterMsg.sFilterMsg = sFilterMsg;
                            FilterMsg.sNewMsg = sNewMsg;
                            g_MsgFilterList.Add(FilterMsg);
                        }
                    }
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// 检查文字是否在消息过滤列表里面
        /// </summary>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public static  bool IsFilterMsg(ref string sMsg)
        {
            bool result = false;
            TFilterMsg FilterMsg;
            if (g_MsgFilterList == null)
            {
                result = true;
                return result;
            }
            if (g_MsgFilterList.Count > 0)
            {
                for (int I = 0; I < g_MsgFilterList.Count; I++)
                {
                    FilterMsg = g_MsgFilterList[I];
                    if ((FilterMsg.sFilterMsg != "") && ((sMsg.IndexOf(FilterMsg.sFilterMsg) != -1)))
                    {
                        if (FilterMsg.sNewMsg == "")
                        {
                            sMsg = "";
                        }
                        else
                        {
                            sMsg = sMsg.Replace(FilterMsg.sFilterMsg, FilterMsg.sNewMsg);
                        }
                        result = true;
                        break;
                    }
                }
            }
            result = true;
            return result;
        }

        /// <summary>
        /// 加载商铺配置
        /// 商品分类  商品名称  出售价格  图片开始  图片结束  简单介绍  商品描述
        /// </summary>
        public unsafe static void LoadShopItemList()
        {
            int nPrice;
            int nCount;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sItemName = string.Empty;
            string sPrice = string.Empty;
            string sIntroduce = string.Empty;
            string sIdx = string.Empty;
            string sImgBegin = string.Empty;
            string sImgend = string.Empty;
            string sIntroduce1 = string.Empty;
            string sCount = string.Empty;
            TStringList LoadList;
            TStdItem* StdItem;
            TShopInfo ShopInfo;
            sFileName = ".\\BuyItemList.txt";
            if (!File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.Add(";引擎插件商铺配置文件");
                LoadList.Add(";商品分类\09商品名称\09出售价格\09图片开始\09图片结束\09简单介绍\09商品描述");
                LoadList.SaveToFile(sFileName);
                return;
            }
            if (g_ShopItemList.Count > 0)
            {
                for (int I = 0; I < g_ShopItemList.Count; I++)
                {
                    if (g_ShopItemList[I] != null)
                    {
                        Dispose(g_ShopItemList[I]);
                    }
                }
            }
            g_ShopItemList.Clear();
            LoadList = new TStringList();
            try
            {
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sIdx, new string[] { " ", "\t" });// 商品分类
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "\t" });// 商品名称
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sPrice, new string[] { " ", "\t" });// 出售价格
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sImgBegin, new string[] { " ", "\t" });// 图片开始
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sImgend, new string[] { " ", "\t" });// 图片结束
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sIntroduce1, new string[] { " ", "\t" });// 简单介绍
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sIntroduce, new string[] { " ", "\t" });// 商品描述
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sCount, new string[] { " ", "\t" });// 数量
                        nPrice = HUtil32.Str_ToInt(sPrice, -1);
                        nCount = HUtil32.Str_ToInt(sCount, 1);
                        if ((sItemName != "") && (nPrice >= 0) && (sIntroduce != "") && (sIdx != ""))
                        {
                            StdItem = UserEngine.GetStdItem(sItemName);
                            if (StdItem != null)
                            {
                                ShopInfo = new TShopInfo();
                                ShopInfo.Idx = Convert.ToInt32(sIdx);
                                //ShopInfo->ImgBegin = Convert.ToInt32(sImgBegin);
                                //ShopInfo->Imgend = Convert.ToInt32(sImgend);
                                //ShopInfo->Introduce1 = Convert.ToInt32(sIntroduce1);
                                //ShopInfo->StdItem = StdItem;
                                //ShopInfo->StdItem.Price = nPrice * 100;// 价格
                                //ShopInfo->StdItem.NeedLevel = nCount;// 数量
                                //FillChar(ShopInfo.sIntroduce, sizeof(ShopInfo.sIntroduce), 0);
                                //Move(sIntroduce[0], ShopInfo.sIntroduce, sIntroduce.Length);
                                //g_ShopItemList.Add((IntPtr)ShopInfo);
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }

        public static bool GetMultiServerAddrPort(int btServerIndex, ref string sIPaddr, ref int nPort)
        {
            bool result;
            result = false;
            // ServerTableList
            return result;
        }

        public static void MainOutMessage(string Msg)
        {
            if (!g_Config.boShowExceptionMsg)
            {
                if ((Msg.Length > 2) && ((Msg[0] == '{') || (Msg[0] == 'A')))
                {
                    return;
                }
            }
            HUtil32.EnterCriticalSection(LogMsgCriticalSection);
            try
            {
                MainLogMsgList.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + Msg);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
            }
        }

        public static int GetExVersionNO(int nVersionDate, ref int nOldVerstionDate)
        {
            int result;
            result = 0;
            nOldVerstionDate = 0;
            if (nVersionDate > 900000000)
            {
                while ((nVersionDate > 900000000))
                {
                    nVersionDate -= 900000000;
                    result += 900000000;
                }
            }
            nOldVerstionDate = nVersionDate;
            return result;
        }

        public static byte GetNextDirection(int sX, int sY, int dx, int dy)
        {
            byte result;
            int flagx;
            int flagy;
            result = Grobal2.DR_DOWN;
            if (sX < dx)
            {
                flagx = 1;
            }
            else if (sX == dx)
            {
                flagx = 0;
            }
            else
            {
                flagx = -1;
            }
            if (Math.Abs(sY - dy) > 2)
            {
                if ((sX >= dx - 1) && (sX <= dx + 1))
                {
                    flagx = 0;
                }
            }
            if (sY < dy)
            {
                flagy = 1;
            }
            else if (sY == dy)
            {
                flagy = 0;
            }
            else
            {
                flagy = -1;
            }
            if (Math.Abs(sX - dx) > 2)
            {
                if ((sY > dy - 1) && (sY <= dy + 1))
                {
                    flagy = 0;
                }
            }
            if ((flagx == 0) && (flagy == -1))
            {
                result = Grobal2.DR_UP;
            }
            if ((flagx == 1) && (flagy == -1))
            {
                result = Grobal2.DR_UPRIGHT;
            }
            if ((flagx == 1) && (flagy == 0))
            {
                result = Grobal2.DR_RIGHT;
            }
            if ((flagx == 1) && (flagy == 1))
            {
                result = Grobal2.DR_DOWNRIGHT;
            }
            if ((flagx == 0) && (flagy == 1))
            {
                result = Grobal2.DR_DOWN;
            }
            if ((flagx == -1) && (flagy == 1))
            {
                result = Grobal2.DR_DOWNLEFT;
            }
            if ((flagx == -1) && (flagy == 0))
            {
                result = Grobal2.DR_LEFT;
            }
            if ((flagx == -1) && (flagy == -1))
            {
                result = Grobal2.DR_UPLEFT;
            }
            return result;
        }

        // 检查是否可以穿上装备
        public unsafe static bool CheckUserItems(int nIdx, TStdItem* StdItem)
        {
            bool result = false;
            switch (nIdx)
            {
                case TPosition.U_DRESS:
                    if ((StdItem->StdMode == 10) || (StdItem->StdMode == 11))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_WEAPON:
                    if ((StdItem->StdMode == 5) || (StdItem->StdMode == 6))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_RIGHTHAND:
                    if ((StdItem->StdMode == 29) || (StdItem->StdMode == 30) || (StdItem->StdMode == 28))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_NECKLACE:
                    if ((StdItem->StdMode == 19) || (StdItem->StdMode == 20) || (StdItem->StdMode == 21))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_HELMET:
                    if (StdItem->StdMode == 15)
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_ZHULI:// 斗笠
                    if (StdItem->StdMode == 16)
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_ARMRINGL:
                    if ((StdItem->StdMode == 24) || (StdItem->StdMode == 25) || (StdItem->StdMode == 26))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_ARMRINGR:
                    if ((StdItem->StdMode == 24) || (StdItem->StdMode == 26))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_RINGL:
                case TPosition.U_RINGR:
                    if ((StdItem->StdMode == 22) || (StdItem->StdMode == 23))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_BUJUK:
                    if ((StdItem->StdMode == 25) || ((StdItem->StdMode == 2) && (StdItem->AniCount == 21)))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_BELT:
                    if ((StdItem->StdMode == 54) || (StdItem->StdMode == 64))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_BOOTS:
                    if ((StdItem->StdMode == 52) || (StdItem->StdMode == 62))
                    {
                        result = true;
                    }
                    break;
                case TPosition.U_CHARM:
                    if ((StdItem->StdMode == 53) || (StdItem->StdMode == 63) || (StdItem->StdMode == 7))
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }

        public static DateTime AddDateTimeOfDay(DateTime DateTime, int nDay)
        {
            DateTime result;
            // 00455DD4
            int Year;
            int Month;
            int Day;
            if (nDay > 0)
            {
                nDay -= 1;
                Year = DateTime.Year;
                Month = DateTime.Month;
                Day = DateTime.Day;
                while (true)
                {
                    //if (MonthDays[false][Month] >= (Day + nDay))
                    //{
                    //    break;
                    //}
                    //nDay = (Day + nDay) - MonthDays[false][Month] - 1;
                    Day = 1;
                    if (Month <= 11)
                    {
                        Month++;
                        continue;
                    }
                    Month = 1;
                    if (Year == 99)
                    {
                        Year = 2000;
                        continue;
                    }
                    Year++;
                }
                // while
                // TryEncodeDate(Year,Month,Day,Result);
                Day += nDay;
                result = new DateTime(Year, Month, Day);
            }
            else
            {
                result = DateTime;
            }
            return result;
        }

        /// <summary>
        /// 金币在地上显示的外形ID
        /// </summary>
        /// <param name="nGold"></param>
        /// <returns></returns>
        public static ushort GetGoldShape(long nGold)
        {
            ushort result = 112;
            if (nGold >= 30)
            {
                result = 113;
            }
            if (nGold >= 70)
            {
                result = 114;
            }
            if (nGold >= 300)
            {
                result = 115;
            }
            if (nGold >= 1000)
            {
                result = 116;
            }
            return result;
        }

        public static ushort GetRandomLook(int nBaseLook, int nRage)
        {
            return Convert.ToUInt16(nBaseLook + HUtil32.Random(nRage));
        }

        /// <summary>
        /// 检查行会名称
        /// </summary>
        /// <param name="sGuildName"></param>
        /// <returns></returns>
        public static bool CheckGuildName(string sGuildName)
        {
            bool result;
            int I;
            result = true;
            if (sGuildName.Length > g_Config.nGuildNameLen)
            {
                result = false;
                return result;
            }
            for (I = 1; I <= sGuildName.Length; I++)
            {
                if ((sGuildName[I] < '0') || (sGuildName[I] == '/') || (sGuildName[I] == '\\') || (sGuildName[I] == ':') || (sGuildName[I] == '*') || (sGuildName[I] == ' ') || 
                    (sGuildName[I] == '\'') || (sGuildName[I] == '\'') || (sGuildName[I] == '<') || (sGuildName[I] == '|') || (sGuildName[I] == '?') || (sGuildName[I] == '>'))
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// 取物品制造ID
        /// </summary>
        /// <returns></returns>
        public static int GetItemNumber()
        {
            int result;
            g_Config.nItemNumber++;
            if (g_Config.nItemNumber > (Int32.MaxValue / 2 - 1))
            {
                g_Config.nItemNumber = 1;
            }
            result = g_Config.nItemNumber;
            return result;
        }

        public static int GetItemNumberEx()
        {
            int result;
            g_Config.nItemNumberEx++;
            if (g_Config.nItemNumberEx < Int32.MaxValue / 2)
            {
                g_Config.nItemNumberEx = Int32.MaxValue / 2;
            }
            if (g_Config.nItemNumberEx > (Int32.MaxValue - 1))
            {
                g_Config.nItemNumberEx = Int32.MaxValue / 2;
            }
            result = g_Config.nItemNumberEx;
            return result;
        }

        /// <summary>
        /// 过滤客户端显示的名字,去除数字及-符号
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public static string FilterShowName(string sName)
        {
            string result = string.Empty;
            string SC = string.Empty;
            bool bo11 = false;
            if (sName == null)
            {
                return null;
            }
            for (int I = 0; I <= sName.Length - 1; I++)
            {
                if (((sName[I] >= '0') && (sName[I] <= '9')) || (sName[I] == '-'))
                {
                    result = sName.Substring(0, I);
                    SC = sName.Substring(I + 1, sName.Length - I - 1);
                    bo11 = true;
                    break;
                }
            }
            if (!bo11)
            {
                result = sName;
            }
            return result;
        }

        public static byte sub_4B2F80(int nDir, int nRage)
        {
            return Convert.ToByte((nDir + nRage) % 8);
        }

        /// <summary>
        /// 取服务器全局变量
        /// </summary>
        /// <param name="sText"></param>
        /// <returns></returns>
        public static int GetValNameNo(string sText)
        {
            int result = -1;
            int nValNo;
            string sNo;
            if (sText == null || sText.Length > 4)
            {
                return result;
            }
            if (sText.Length >= 2)
            {
                sNo = sText.Substring(2 - 1, sText.Length - 1);
                if (HUtil32.IsStringNumber(sNo))
                {
                    if (Char.ToUpper(sText[0]) == 'P')  // 0..99
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);//  扩展为0-99
                            if (nValNo < 100)
                            {
                                result = nValNo;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'G')// OK 100..199 800..1199
                    {
                        if (sText.Length == 4)// 扩展为0-499
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 4 - 1), -1);
                            if ((nValNo < 500) && (nValNo > 99))
                            {
                                result = nValNo + 700;
                            }
                        }
                        else
                        {
                            if (sText.Length == 3)
                            {
                                nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                                if (nValNo < 100)
                                {
                                    result = nValNo + 100;
                                }
                            }
                            else
                            {
                                nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                                if (nValNo < 10)
                                {
                                    result = nValNo + 100;
                                }
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'M')// 300..399
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 300;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 300;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'I')
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, sText.Length - (2 - 1)), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 400;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 400;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'D')  // 200..299
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);  // 20080125  扩展为0-99
                            if (nValNo < 100)
                            {
                                result = nValNo + 200;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 200;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'N') // 500..599
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 500;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 500;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'S') // 600..699
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 2), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 600;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 600;
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'A')  // 700..799 1200..1599
                    {
                        if (sText.Length == 4)  // 扩展为0-999
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 4 - 1), -1);
                            if ((nValNo < 500) && (nValNo > 99))
                            {
                                result = nValNo + 1100;
                            }
                        }
                        else
                        {
                            if (sText.Length == 3)
                            {
                                nValNo = HUtil32.Str_ToInt(sText.Substring(1, sText.Length - (2 - 1)), -1);
                                if (nValNo < 100)
                                {
                                    result = nValNo + 700;
                                }
                            }
                            else
                            {
                                nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                                if (nValNo < 10)
                                {
                                    result = nValNo + 700;
                                }
                            }
                        }
                    }
                    if (Char.ToUpper(sText[0]) == 'T') // 新增加变量,0-999
                    {
                        if (sText.Length == 3)
                        {
                            nValNo = HUtil32.Str_ToInt(sText.Substring(1, 3), -1);
                            if (nValNo < 100)
                            {
                                result = nValNo + 700;
                            }
                        }
                        else
                        {
                            nValNo = HUtil32.Str_ToInt(sText[1].ToString(), -1);
                            if (nValNo < 10)
                            {
                                result = nValNo + 700;
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 是可以使用的物品
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public unsafe static bool IsUseItem(int nIndex)
        {
            bool result;
            TStdItem* StdItem = UserEngine.GetStdItem(nIndex);
            if (new ArrayList(new int[] { 19, 20, 21, 22, 23, 24, 26 }).Contains(StdItem->StdMode))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static TStringList GetMakeItemInfo(string sItemName)
        {
            TStringList result = null;
            if (g_MakeItemList.Count > 0)
            {
                for (int I = 0; I < g_MakeItemList.Count; I++)
                {
                    //if (g_MakeItemList[I] == sItemName)
                    //{
                    //    result = ((g_MakeItemList[I]) as TStringList);
                    //    break;
                    //}
                }
            }
            return result;
        }

        public bool GetRefineItemInfo_InStr(string Str, string sItemName, string sItemName1, string sItemName2)
        {
            bool result;
            result = false;
            //if (Str.Length == sItemName + "+" + sItemName1 + "+" + sItemName2.Length)
            //{
            //    if (Str.IndexOf(sItemName) > 0)
            //    {
            //        Str = Str.Substring(0 - 1, Str.IndexOf(sItemName)) + Str.Substring(Str.IndexOf(sItemName) + sItemName.Length - 1, Str.Length);
            //        if (Str.IndexOf(sItemName1) > 0)
            //        {
            //            Str = Str.Substring(0 - 1, Str.IndexOf(sItemName1)) + Str.Substring(Str.IndexOf(sItemName1) + sItemName1.Length - 1, Str.Length);
            //            if (Str.IndexOf(sItemName2) > 0)
            //            {
            //                result = true;
            //            }
            //        }
            //    }
            //}
            return result;
        }

        // 取淬炼后的物品列表
        public static ArrayList GetRefineItemInfo(string sItemName, string sItemName1, string sItemName2)
        {
            ArrayList result;
            int I;
            string Str;
            result = null;
            if (g_RefineItemList.Count > 0)
            {
                for (I = 0; I < g_RefineItemList.Count; I++)
                {
                    Str = g_RefineItemList[I].sItemName;
                    //if (GetRefineItemInfo_InStr(Str, sItemName, sItemName1, sItemName2))
                    //{
                    //    result = ((g_RefineItemList[I]) as ArrayList);
                    //    break;
                    //}
                }
            }
            return result;
        }
        
        // 增加游戏日志
        public static void AddGameDataLog(string sMsg)
        {
            try
            {
                HUtil32.EnterCriticalSection(LogMsgCriticalSection);
                try
                {
                    //LogStringList.Add(sMsg);
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
                }
            }
            catch
            {
                MainOutMessage("{异常} AddGameDataLog");
            }
        }

        public static void AddLogonCostLog(string sMsg)
        {
            HUtil32.EnterCriticalSection(LogMsgCriticalSection);
            try
            {
                //LogonCostLogList.Add(sMsg);
            }
            finally
            {
                HUtil32.LeaveCriticalSection(LogMsgCriticalSection);
            }
        }

        public static void TrimStringList(TStringList sList)
        {
            int n8;
            string SC;
            n8 = 0;
            while (true)
            {
                if ((sList.Count) <= n8)
                {
                    break;
                }
                SC = sList[n8].Trim();
                if (SC == "")
                {
                    sList.RemoveAt(n8);
                    continue;
                }
                n8++;
            }
        }

        // 是否能制造物品
        public static bool CanMakeItem(string sItemName)
        {
            bool result;
            int I;
            result = false;
            //g_DisableMakeItemList.__Lock();
            //try
            //{
            //    if (g_DisableMakeItemList.Count > 0)
            //    {
            //        for (I = 0; I < g_DisableMakeItemList.Count; I++)
            //        {
            //            if ((g_DisableMakeItemList[I]).ToLower().CompareTo((sItemName).ToLower()) == 0)
            //            {
            //                result = false;
            //                return result;
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    g_DisableMakeItemList.UnLock();
            //}
            //g_EnableMakeItemList.__Lock();
            //try
            //{
            //    if (g_EnableMakeItemList.Count > 0)
            //    {
            //        for (I = 0; I < g_EnableMakeItemList.Count; I++)
            //        {
            //            if ((g_EnableMakeItemList[I]).ToLower().CompareTo((sItemName).ToLower()) == 0)
            //            {
            //                result = true;
            //                break;
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    g_EnableMakeItemList.UnLock();
            //}
            return result;
        }

        /// <summary>
        /// 获取安全区配置信息
        /// </summary>
        /// <param name="nIndex"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public static string GetStartPointInfo(int nIndex, ref int nX, ref int nY)
        {
            string result = "";
            TStartPoint StartPoint;
            nX = 0;
            nY = 0;
            if ((nIndex >= 0) && (nIndex < g_StartPointList.Count))
            {
                StartPoint =g_StartPointList[nIndex];
                if (StartPoint != null)
                {
                    nX = StartPoint.m_nCurrX;
                    nY = StartPoint.m_nCurrY;
                    result = StartPoint.m_sMapName;
                }
            }
            return result;
        }
      
        /// <summary>
        /// 是否可以移动的地图
        /// </summary>
        /// <param name="sMapName"></param>
        /// <returns></returns>
        public static bool CanMoveMap(string sMapName)
        {
            bool result;
            int I;
            result = true;
            //g_DisableMoveMapList.__Lock();
            //try
            //{
            //    if (g_DisableMoveMapList.Count > 0)
            //    {
            //        for (I = 0; I < g_DisableMoveMapList.Count; I++)
            //        {
            //            if ((g_DisableMoveMapList[I]).ToLower().CompareTo((sMapName).ToLower()) == 0)
            //            {
            //                result = false;
            //                break;
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    g_DisableMoveMapList.UnLock();
            //}
            return result;
        }

        public static bool LoadItemBindIPaddr()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            string sMakeIndex;
            string sItemIndex;
            string sBindName;
            int nMakeIndex;
            int nItemIndex;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindIPaddr.txt";
            LoadList = new TStringList();
            //if (File.Exists(sFileName))
            //{
            //    g_ItemBindIPaddr.__Lock();
            //    try
            //    {
            //        if (g_ItemBindIPaddr.Count > 0)
            //        {
            //            for (I = 0; I < g_ItemBindIPaddr.Count; I++)
            //            {
            //                if (((g_ItemBindIPaddr[I]) as TItemBind) != null)
            //                {
            //                    Dispose(((g_ItemBindIPaddr[I]) as TItemBind));
            //                }
            //            }
            //            g_ItemBindIPaddr.Clear();
            //        }
            //        LoadList.LoadFromFile(sFileName);
            //        if (LoadList.Count > 0)
            //        {
            //            for (I = 0; I < LoadList.Count; I++)
            //            {
            //                sLineText = LoadList[I].Trim();
            //                if (sLineText[0] == ";")
            //                {
            //                    continue;
            //                }
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
            //                nMakeIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sMakeIndex, -1);
            //                nItemIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sItemIndex, -1);
            //                if ((nMakeIndex > 0) && (nItemIndex > 0) && (sBindName != ""))
            //                {
            //                    ItemBind = new TItemBind();
            //                    ItemBind.nMakeIdex = nMakeIndex;
            //                    ItemBind.nItemIdx = nItemIndex;
            //                    ItemBind.sBindName = sBindName;
            //                    g_ItemBindIPaddr.Add(ItemBind);
            //                }
            //            }
            //            // for
            //        }
            //    }
            //    finally
            //    {
            //        g_ItemBindIPaddr.UnLock();
            //    }
            //    result = true;
            //}
            //else
            //{
            //    LoadList.SaveToFile(sFileName);
            //}
            return result;
        }

        public static bool SaveItemBindIPaddr()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindIPaddr.txt";
            SaveList = new TStringList();
            //g_ItemBindIPaddr.__Lock();
            //try
            //{
            //    if (g_ItemBindIPaddr.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemBindIPaddr.Count; I++)
            //        {
            //            //ItemBind = g_ItemBindIPaddr[I];
            //            SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + (ItemBind.nMakeIdex).ToString() + "\09" + ItemBind.sBindName);
            //        }
            //    }
            //}
            //finally
            //{
            //    g_ItemBindIPaddr.UnLock();
            //}
            SaveList.SaveToFile(sFileName);
            result = true;
            return result;
        }

        public static bool LoadItemBindAccount()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            string sMakeIndex;
            string sItemIndex;
            string sBindName;
            int nMakeIndex;
            int nItemIndex;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindAccount.txt";
            LoadList = new TStringList();
            //if (File.Exists(sFileName))
            //{
            //    g_ItemBindAccount.__Lock();
            //    try
            //    {
            //        if (g_ItemBindAccount.Count > 0)
            //        {
            //            for (I = 0; I < g_ItemBindAccount.Count; I++)
            //            {
            //                if (((g_ItemBindAccount[I]) as TItemBind) != null)
            //                {
            //                    Dispose(((g_ItemBindAccount[I]) as TItemBind));
            //                }
            //            }
            //            g_ItemBindAccount.Clear();
            //        }
            //        LoadList.LoadFromFile(sFileName);
            //        if (LoadList.Count > 0)
            //        {
            //            for (I = 0; I < LoadList.Count; I++)
            //            {
            //                sLineText = LoadList[I].Trim();
            //                if (sLineText[0] == ";")
            //                {
            //                    continue;
            //                }
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
            //                nMakeIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sMakeIndex, -1);
            //                nItemIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sItemIndex, -1);
            //                if ((nMakeIndex > 0) && (nItemIndex > 0) && (sBindName != ""))
            //                {
            //                    ItemBind = new TItemBind();
            //                    ItemBind.nMakeIdex = nMakeIndex;
            //                    ItemBind.nItemIdx = nItemIndex;
            //                    ItemBind.sBindName = sBindName;
            //                    g_ItemBindAccount.Add(ItemBind);
            //                }
            //            }
            //            // for
            //        }
            //    }
            //    finally
            //    {
            //        g_ItemBindAccount.UnLock();
            //    }
            //    result = true;
            //}
            //else
            //{
            //    LoadList.SaveToFile(sFileName);
            //}
            return result;
        }

        public static bool SaveItemBindAccount()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindAccount.txt";
            SaveList = new TStringList();
            //g_ItemBindAccount.__Lock();
            //try
            //{
            //    if (g_ItemBindAccount.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemBindAccount.Count; I++)
            //        {
            //            ItemBind = g_ItemBindAccount[I];
            //            SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + (ItemBind.nMakeIdex).ToString() + "\09" + ItemBind.sBindName);
            //        }
            //    }
            //}
            //finally
            //{
            //    g_ItemBindAccount.UnLock();
            //}
            SaveList.SaveToFile(sFileName);
            result = true;
            return result;
        }

        public static bool LoadItemDblClickList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            string sMakeIndex;
            string sItemName;
            string sMapName;
            string sX;
            string sY;
            int nMakeIndex;
            int nCurrX;
            int nCurrY;
            TItemEvent ItemEvent;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemDblClickList.txt";
            LoadList = new TStringList();
            //if (g_ItemDblClickList != null)
            //{
            //    if (g_ItemDblClickList.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemDblClickList.Count; I++)
            //        {
            //            if (((TItemEvent)(g_ItemDblClickList[I])) != null)
            //            {
            //                Dispose(((TItemEvent)(g_ItemDblClickList[I])));
            //            }
            //        }
            //    }
            //}
            //g_ItemDblClickList = new TGList();
            //if (File.Exists(sFileName))
            //{
            //    g_ItemDblClickList.__Lock();
            //    try
            //    {
            //        LoadList.LoadFromFile(sFileName);
            //        if (LoadList.Count > 0)
            //        {
            //            for (I = 0; I < LoadList.Count; I++)
            //            {
            //                sLineText = LoadList[I].Trim();
            //                if ((sLineText == "") || (sLineText[0] == ';'))
            //                {
            //                    continue;
            //                }
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sMapName, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sX, new string[] { " ", ",", "\09" });
            //                sLineText = HUtil32.GetValidStr3(sLineText, ref sY, new string[] { " ", ",", "\09" });
            //                nMakeIndex = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sMakeIndex, -1);
            //                nCurrX = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sX, -1);
            //                nCurrY = EDcodeUnit.Units.EDcodeUnit.Str_ToInt(sY, -1);
            //                if ((nMakeIndex > 0) && (sMapName != "") && (nCurrX >= 0) && (nCurrY >= 0))
            //                {
            //                    ItemEvent = new TItemEvent();
            //                    ItemEvent.m_sItemName = sItemName;
            //                    ItemEvent.m_nMakeIndex = nMakeIndex;
            //                    ItemEvent.m_sMapName = sMapName;
            //                    ItemEvent.m_nCurrX = nCurrX;
            //                    ItemEvent.m_nCurrY = nCurrY;
            //                    g_ItemDblClickList.Add(ItemEvent);
            //                }
            //            }
            //            // for
            //        }
            //    }
            //    finally
            //    {
            //        g_ItemDblClickList.UnLock();
            //    }
            //    result = true;
            //}
            //else
            //{
            //    LoadList.SaveToFile(sFileName);
            //}
            return result;
        }

        // 加载物品事件触发列表
        public static bool SaveItemDblClickList()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemEvent ItemEvent;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemDblClickList.txt";
            SaveList = new TStringList();
            //g_ItemDblClickList.__Lock();
            //try
            //{
            //    if (g_ItemDblClickList.Count > 0)
            //    {
            //        for (I = 0; I < g_ItemDblClickList.Count; I++)
            //        {
            //            ItemEvent = g_ItemDblClickList[I];
            //            SaveList.Add(ItemEvent.m_sItemName + "\09" + (ItemEvent.m_nMakeIndex).ToString() + "\09" + ItemEvent.m_sMapName + "\09" + (ItemEvent.m_nCurrX).ToString() + "\09" + (ItemEvent.m_nCurrY).ToString());
            //        }
            //    }
            //}
            //finally
            //{
            //    g_ItemBindCharName.UnLock();
            //}
            SaveList.SaveToFile(sFileName); ;
            result = true;
            return result;
        }

        public static bool LoadItemBindCharName()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText = string.Empty;
            string sMakeIndex = string.Empty;
            string sItemIndex = string.Empty;
            string sBindName = string.Empty;
            int nMakeIndex;
            int nItemIndex;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindChrName.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                //g_ItemBindCharName.__Lock();
                try
                {
                    if (g_ItemBindCharName.Count > 0)
                    {
                        for (I = 0; I < g_ItemBindCharName.Count; I++)
                        {
                            if (g_ItemBindCharName[I] != null)
                            {
                                Dispose(g_ItemBindCharName[I]);
                            }
                        }
                        g_ItemBindCharName.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I].Trim();
                            if (sLineText[0] == ';')
                            {
                                continue;
                            }
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sMakeIndex, new string[] { " ", ",", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
                            nMakeIndex = HUtil32.Str_ToInt(sMakeIndex, -1);
                            nItemIndex = HUtil32.Str_ToInt(sItemIndex, -1);
                            if ((nMakeIndex > 0) && (nItemIndex > 0) && (sBindName != ""))
                            {
                                ItemBind = new TItemBind();
                                ItemBind.nMakeIdex = nMakeIndex;
                                ItemBind.nItemIdx = nItemIndex;
                                ItemBind.sBindName = sBindName;
                                g_ItemBindCharName.Add(ItemBind);
                            }
                        }
                    }
                }
                finally
                {
                    //g_ItemBindCharName.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool SaveItemBindCharName()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindChrName.txt";
            SaveList = new TStringList();
            //g_ItemBindCharName.__Lock();
            try
            {
                if (g_ItemBindCharName.Count > 0)
                {
                    for (I = 0; I < g_ItemBindCharName.Count; I++)
                    {
                        ItemBind = g_ItemBindCharName[I];
                        SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + (ItemBind.nMakeIdex).ToString() + "\09" + ItemBind.sBindName);
                    }
                }
            }
            finally
            {
               // g_ItemBindCharName.UnLock();
            }
            SaveList.SaveToFile(sFileName);
            SaveList.Dispose();
            Dispose(SaveList);
            result = true;
            return result;
        }

        /// <summary>
        /// 读取人物装备死亡不爆列表
        /// </summary>
        /// <returns></returns>
        public static bool LoadItemBindDieNoDropName()
        {
            bool result = false;
            int nItemIndex;
            string sLineText = string.Empty;
            string sItemIndex = string.Empty;
            string sBindName = string.Empty;
            TItemBind ItemBind;
            TStringList LoadList = new TStringList();
            string sFileName = g_Config.sEnvirDir + "ItemBindDieNoDropName.txt";
            if (File.Exists(sFileName))
            {
                HUtil32.EnterCriticalSection(g_ItemBindDieNoDropName);
                try
                {
                    if (g_ItemBindDieNoDropName.Count > 0)
                    {
                        for (int I = 0; I < g_ItemBindDieNoDropName.Count; I++)
                        {
                            if (g_ItemBindDieNoDropName[I] != null)
                            {
                                Dispose(g_ItemBindDieNoDropName[I]);
                            }
                        }
                        g_ItemBindDieNoDropName.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (int I = 0; I < LoadList.Count; I++)
                        {
                            sLineText = LoadList[I].Trim();
                            if (sLineText[0] == ';')
                            {
                                continue;
                            }
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIndex, new string[] { " ", ",", "\09" });
                            sLineText = HUtil32.GetValidStr3(sLineText, ref sBindName, new string[] { " ", ",", "\09" });
                            nItemIndex = HUtil32.Str_ToInt(sItemIndex, -1);
                            if ((nItemIndex > 0) && (sBindName != ""))
                            {
                                ItemBind = new TItemBind();
                                ItemBind.nMakeIdex = 0;
                                ItemBind.nItemIdx = nItemIndex;
                                ItemBind.sBindName = sBindName;
                                g_ItemBindDieNoDropName.Add(ItemBind);
                            }
                        }
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(g_ItemBindDieNoDropName);
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        // 保存人物装备死亡不爆列表
        public static bool SaveItemBindDieNoDropName()
        {
            bool result;
            int I;
            TStringList SaveList;
            string sFileName;
            TItemBind ItemBind = null;
            result = false;
            sFileName = g_Config.sEnvirDir + "ItemBindDieNoDropName.txt";
            SaveList = new TStringList();
            //g_ItemBindDieNoDropName.__Lock();
            try
            {
                if (g_ItemBindDieNoDropName.Count > 0)
                {
                    for (I = 0; I < g_ItemBindDieNoDropName.Count; I++)
                    {
                        //ItemBind = g_ItemBindDieNoDropName[I];
                        SaveList.Add((ItemBind.nItemIdx).ToString() + "\09" + ItemBind.sBindName);
                    }
                }
            }
            finally
            {
              //  g_ItemBindDieNoDropName.UnLock();
            }
            SaveList.SaveToFile(sFileName);
            Dispose(SaveList);
            result = true;
            return result;
        }
       
        public static bool LoadDisableMakeItem()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableMakeItem.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                //g_DisableMakeItemList.__Lock();
                try
                {
                    if (g_DisableMakeItemList.Count > 0)
                    {
                        g_DisableMakeItemList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_DisableMakeItemList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                   // g_DisableMakeItemList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            //Dispose(LoadList);
            return result;
        }
        public static bool SaveDisableMakeItem()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "DisableMakeItem.txt";
           // g_DisableMakeItemList.__Lock();
            try
            {
                g_DisableMakeItemList.SaveToFile(sFileName);
            }
            finally
            {
              //  g_DisableMakeItemList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool SaveAdminList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            string sPermission = string.Empty;
            int nPermission;
            TAdminInfo AdminInfo;
            sFileName = g_Config.sEnvirDir + "AdminList.txt";
            SaveList = new TStringList();
            //UserEngine.m_AdminList.__Lock();
            try
            {
                if (UserEngine.m_AdminList.Count > 0)
                {
                    for (I = 0; I < UserEngine.m_AdminList.Count; I++)
                    {
                        AdminInfo = UserEngine.m_AdminList[I];
                        nPermission = AdminInfo.nLv;
                        if (nPermission == 10)
                        {
                            sPermission = "*";
                        }
                        if (nPermission == 9)
                        {
                            sPermission = "1";
                        }
                        if (nPermission == 8)
                        {
                            sPermission = "2";
                        }
                        if (nPermission == 7)
                        {
                            sPermission = "3";
                        }
                        if (nPermission == 6)
                        {
                            sPermission = "4";
                        }
                        if (nPermission == 5)
                        {
                            sPermission = "5";
                        }
                        if (nPermission == 4)
                        {
                            sPermission = "6";
                        }
                        if (nPermission == 3)
                        {
                            sPermission = "7";
                        }
                        if (nPermission == 2)
                        {
                            sPermission = "8";
                        }
                        if (nPermission == 1)
                        {
                            sPermission = "9";
                        }
                        SaveList.Add(sPermission + "\09" + AdminInfo.sChrName + "\09" + AdminInfo.sIPaddr);
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                //UserEngine.m_AdminList.UnLock();
            }
            SaveList.Dispose();
            Dispose(SaveList);
            result = true;
            return result;
        }

        public static bool LoadUnMasterList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "UnMaster.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
               // g_UnMasterList.__Lock();
                try
                {
                    if (g_UnMasterList.Count > 0)
                    {
                        g_UnMasterList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                           // g_UnMasterList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                   // g_UnMasterList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            LoadList.Dispose();
            Dispose(LoadList);
            //Dispose(LoadList);
            return result;
        }

        public static bool SaveUnMasterList()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "UnMaster.txt";
           // g_UnMasterList.__Lock();
            try
            {
                g_UnMasterList.SaveToFile(sFileName);
            }
            finally
            {
               // g_UnMasterList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadUnForceMasterList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "UnForceMaster.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                //g_UnForceMasterList.__Lock();
                try
                {
                    if (g_UnForceMasterList.Count > 0)
                    {
                        g_UnForceMasterList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_UnForceMasterList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                   // g_UnForceMasterList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
           // Dispose(LoadList);
            return result;
        }

        public static bool SaveUnForceMasterList()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "UnForceMaster.txt";
            //g_UnForceMasterList.__Lock();
            try
            {
                g_UnForceMasterList.SaveToFile(sFileName);
            }
            finally
            {
              //  g_UnForceMasterList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadEnableMakeItem()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "EnableMakeItem.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_EnableMakeItemList.__Lock();
                try
                {
                    if (g_EnableMakeItemList.Count > 0)
                    {
                        g_EnableMakeItemList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_EnableMakeItemList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                    g_EnableMakeItemList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public bool SaveEnableMakeItem()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "EnableMakeItem.txt";
           // g_EnableMakeItemList.__Lock();
            try
            {
                g_EnableMakeItemList.SaveToFile(sFileName);
            }
            finally
            {
               // g_EnableMakeItemList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadDisableMoveMap()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableMoveMap.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
               // g_DisableMoveMapList.__Lock();
                try
                {
                    if (g_DisableMoveMapList.Count > 0)
                    {
                        g_DisableMoveMapList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    if (LoadList.Count > 0)
                    {
                        for (I = 0; I < LoadList.Count; I++)
                        {
                            //g_DisableMoveMapList.Add(LoadList[I].Trim());
                        }
                    }
                }
                finally
                {
                   // g_DisableMoveMapList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            //Dispose(LoadList);
            return result;
        }

        public static bool SaveDisableMoveMap()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "DisableMoveMap.txt";
           // g_DisableMoveMapList.__Lock();
            try
            {
                g_DisableMoveMapList.SaveToFile(sFileName);
            }
            finally
            {
                //g_DisableMoveMapList.UnLock();
            }
            result = true;
            return result;
        }

        public unsafe bool LoadBindItemTypeFromUnbindList_AddBindItemType(string sItemName, int nShape)
        {
            bool result;
            TBindItem BindItem;
            int I;
            TStdItem* StdItem;
            result = false;
            if (UserEngine.StdItemList.Count > 0)
            {
                for (I = 0; I < UserEngine.StdItemList.Count; I++)
                {
                    StdItem = (TStdItem*)UserEngine.StdItemList[I];
                    if ((HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen)).ToLower().CompareTo((sItemName).ToLower()) == 0)
                    {
                        if (StdItem->StdMode == 0)
                        {
                            if ((StdItem->Shape == 0) && (StdItem->AC > 0) && (StdItem->MAC == 0))
                            {
                                // 红药
                                BindItem = new TBindItem();
                                BindItem.sUnbindItemName = HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen);
                                BindItem.nStdMode = 31;
                                BindItem.nShape = nShape;
                                BindItem.btItemType = 0;
                                g_BindItemTypeList.Add(BindItem);
                                result = true;
                                break;
                            }
                            else if ((StdItem->Shape == 0) && (StdItem->AC == 0) && (StdItem->MAC > 0))
                            {
                                BindItem = new TBindItem();
                                BindItem.sUnbindItemName = HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen);
                                BindItem.nStdMode = 31;
                                BindItem.nShape = nShape;
                                BindItem.btItemType = 1;
                                g_BindItemTypeList.Add(BindItem);
                                result = true;
                                break;
                            }
                            else if ((StdItem->Shape == 1) && (StdItem->AC > 0) && (StdItem->MAC > 0))
                            {
                                BindItem = new TBindItem();
                                BindItem.sUnbindItemName = HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen);
                                BindItem.nStdMode = 31;
                                BindItem.nShape = nShape;
                                BindItem.btItemType = 2;
                                g_BindItemTypeList.Add(BindItem);
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // 查找指定解包分类能解出的物品名称 
        public static void LoadBindItemTypeFromUnbindList()
        {
            int I;
            string sItemName;
            int nShape;
            //if (UserEngine != null)
            //{
            //    g_BindItemTypeList = new TGList();
            //    if (g_UnbindList.Count > 0)
            //    {
            //        for (I = 0; I < g_UnbindList.Count; I++)
            //        {
            //            sItemName = g_UnbindList[I];
            //            nShape = ((int)g_UnbindList[I]);
            //            LoadBindItemTypeFromUnbindList_AddBindItemType(sItemName, nShape);
            //        }
            //    }
            //}
        }

        public static int GetBindItemType(int nShape)
        {
            int result;
            TBindItem BindItem;
            int I;
            result = -1;
            if (g_BindItemTypeList != null)
            {
                if (g_BindItemTypeList.Count > 0)
                {
                    for (I = 0; I < g_BindItemTypeList.Count; I++)
                    {
                        BindItem = g_BindItemTypeList[I];
                        if (BindItem.nShape == nShape)
                        {
                            result = BindItem.btItemType;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // 查找指定解包分类能解出的物品名称 
        public static string GetBindItemName(int nShape)
        {
            string result;
            TBindItem BindItem;
            int I;
            result = "";
            if (g_BindItemTypeList != null)
            {
                if (g_BindItemTypeList.Count > 0)
                {
                    for (I = 0; I < g_BindItemTypeList.Count; I++)
                    {
                        BindItem = g_BindItemTypeList[I];
                        if (BindItem.nShape == nShape)
                        {
                            result = BindItem.sUnbindItemName;
                            break;
                        }
                    }
                }
            }
            return result;
        }
        public static void LoadAllowPickUpItemList()
        {
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            sFileName = g_Config.sEnvirDir + "AllowPickUpItemList.txt";
            if (g_AllowPickUpItemList != null)
            {
                g_AllowPickUpItemList = null;
            }
            g_AllowPickUpItemList = new TStringList();
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count > 0)
                {
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        sLineText = LoadList[I].Trim();
                        if ((sLineText != "") && (sLineText[0] != ';'))
                        {
                            //g_AllowPickUpItemList.Add(sLineText);
                        }
                    }
                }
                Dispose(LoadList);
            }
            else
            {
                //g_AllowPickUpItemList.Add(";允许分身捡取物品列表");
                g_AllowPickUpItemList.SaveToFile(sFileName);
            }
        }
        public static bool IsAllowPickUpItem(string sItemName)
        {
            bool result;
            int I;
            result = false;
            if (g_AllowPickUpItemList != null)
            {
                g_AllowPickUpItemList.__Lock();
                try
                {
                    if (g_AllowPickUpItemList.Count > 0)
                    {
                        for (I = 0; I < g_AllowPickUpItemList.Count; I++)
                        {
                            if ((sItemName).ToLower().CompareTo((g_AllowPickUpItemList[I]).ToLower()) == 0)
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
                finally
                {
                    g_AllowPickUpItemList.UnLock();
                }
            }
            return result;
        }

        public static int GetUseItemIdx(string sName)
        {
            int result = -1;
            if ((sName).ToLower().CompareTo((U_DRESSNAME).ToLower()) == 0)
            {
                result = 0;
            }
            else if ((sName).ToLower().CompareTo((U_WEAPONNAME).ToLower()) == 0)
            {
                result = 1;
            }
            else if ((sName).ToLower().CompareTo((U_RIGHTHANDNAME).ToLower()) == 0)
            {
                result = 2;
            }
            else if ((sName).ToLower().CompareTo((U_NECKLACENAME).ToLower()) == 0)
            {
                result = 3;
            }
            else if ((sName).ToLower().CompareTo((U_HELMETNAME).ToLower()) == 0)
            {
                result = 4;
            }
            else if ((sName).ToLower().CompareTo((U_ARMRINGLNAME).ToLower()) == 0)
            {
                result = 5;
            }
            else if ((sName).ToLower().CompareTo((U_ARMRINGRNAME).ToLower()) == 0)
            {
                result = 6;
            }
            else if ((sName).ToLower().CompareTo((U_RINGLNAME).ToLower()) == 0)
            {
                result = 7;
            }
            else if ((sName).ToLower().CompareTo((U_RINGRNAME).ToLower()) == 0)
            {
                result = 8;
            }
            else if ((sName).ToLower().CompareTo((U_BUJUKNAME).ToLower()) == 0)
            {
                result = 9;
            }
            else if ((sName).ToLower().CompareTo((U_BELTNAME).ToLower()) == 0)
            {
                result = 10;
            }
            else if ((sName).ToLower().CompareTo((U_BOOTSNAME).ToLower()) == 0)
            {
                result = 11;
            }
            else if ((sName).ToLower().CompareTo((U_CHARMNAME).ToLower()) == 0)
            {
                result = 12;
            }
            else if ((sName).ToLower().CompareTo((U_ZHULINAME).ToLower()) == 0) //斗笠
            {
                result = 13;
            }
            return result;
        }
        // 保存物品事件触发列表
        public static string GetUseItemName(int nIndex)
        {
            string result = string.Empty;
            switch (nIndex)
            {
                case 0:
                    result = U_DRESSNAME;
                    break;
                case 1:
                    result = U_WEAPONNAME;
                    break;
                case 2:
                    result = U_RIGHTHANDNAME;
                    break;
                case 3:
                    result = U_NECKLACENAME;
                    break;
                case 4:
                    result = U_HELMETNAME;
                    break;
                case 5:
                    result = U_ARMRINGLNAME;
                    break;
                case 6:
                    result = U_ARMRINGRNAME;
                    break;
                case 7:
                    result = U_RINGLNAME;
                    break;
                case 8:
                    result = U_RINGRNAME;
                    break;
                case 9:
                    result = U_BUJUKNAME;
                    break;
                case 10:
                    result = U_BELTNAME;
                    break;
                case 11:
                    result = U_BOOTSNAME;
                    break;
                case 12:
                    result = U_CHARMNAME;
                    break;
                case 13:
                    result = U_ZHULINAME;
                    break;
                // 20080416 斗笠
            }
            return result;
        }
        public static bool LoadDisableSendMsgList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableSendMsgList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                if (g_DisableSendMsgList.Count > 0)
                {
                    g_DisableSendMsgList.Clear();
                }
                // 20080831 修改
                LoadList.LoadFromFile(sFileName);
                if (LoadList.Count > 0)
                {
                    // 20080629
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_DisableSendMsgList.Add(LoadList[I].Trim());
                    }
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }
        public static bool LoadMonDropLimitList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sLineText;
            string sFileName;
            string sItemName = string.Empty;
            string sItemCount = string.Empty;
            int nItemCount;
            TMonDrop MonDrop;
            result = false;
            sFileName = g_Config.sEnvirDir + "MonDropLimitList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                if (g_MonDropLimitLIst.Count > 0)
                {
                    g_MonDropLimitLIst.Clear();
                }
                // 20080831 修改
                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText == "") || (sLineText[0] == ';'))
                    {
                        continue;
                    }
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "/", ",", "\09" });
                    sLineText = HUtil32.GetValidStr3(sLineText, ref sItemCount, new string[] { " ", "/", ",", "\09" });
                    nItemCount = HUtil32.Str_ToInt(sItemCount, -1);
                    if ((sItemName != "") && (nItemCount >= 0))
                    {
                        MonDrop = new TMonDrop();
                        MonDrop.sItemName = sItemName;
                        MonDrop.nDropCount = 0;
                        MonDrop.nNoDropCount = 0;
                        MonDrop.nCountLimit = nItemCount;
                        //g_MonDropLimitLIst.Add(sItemName, ((MonDrop) as Object));
                    }
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }
        public static bool SaveMonDropLimitList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            TMonDrop MonDrop;
            sFileName = g_Config.sEnvirDir + "MonDropLimitList.txt";
            LoadList = new TStringList();
            if (g_MonDropLimitLIst.Count > 0)
            {
                for (I = 0; I < g_MonDropLimitLIst.Count; I++)
                {
                    // MonDrop = ((TMonDrop)(g_MonDropLimitLIst[I]));
                    // sLineText = MonDrop.sItemName + "\09" + (MonDrop.nCountLimit).ToString();
                    // LoadList.Add(sLineText);
                }
            }
            LoadList.SaveToFile(sFileName);
            Dispose(LoadList);
            result = true;
            return result;
        }
        public static bool LoadDisableTakeOffList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sLineText;
            string sFileName;
            string sItemName = string.Empty;
            string sItemIdx = string.Empty;
            int nItemIdx;
            result = false;
            sFileName = g_Config.sEnvirDir + "DisableTakeOffList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                LoadList.LoadFromFile(sFileName);
                g_DisableTakeOffList.__Lock();
                try
                {
                    if (g_DisableTakeOffList.Count > 0)
                    {
                        g_DisableTakeOffList.Clear();
                    }
                    // 20080831
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        sLineText = LoadList[I].Trim();
                        if ((sLineText == "") || (sLineText[0] == ';'))
                        {
                            continue;
                        }
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemName, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sItemIdx, new string[] { " ", "/", ",", "\09" });
                        nItemIdx = HUtil32.Str_ToInt(sItemIdx, -1);
                        if ((sItemName != "") && (nItemIdx >= 0))
                        {
                            //g_DisableTakeOffList.Add(sItemName, ((nItemIdx) as Object));
                        }
                    }
                }
                finally
                {
                    g_DisableTakeOffList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }
        public static bool SaveDisableTakeOffList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            string sLineText;
            sFileName = g_Config.sEnvirDir + "DisableTakeOffList.txt";
            LoadList = new TStringList();
            g_DisableTakeOffList.__Lock();
            try
            {
                if (g_DisableTakeOffList.Count > 0)
                {
                    // 20080629
                    for (I = 0; I < g_DisableTakeOffList.Count; I++)
                    {
                        //sLineText = g_DisableTakeOffList[I] + "\09" + (((int)g_DisableTakeOffList[I])).ToString();
                        //LoadList.Add(sLineText);
                    }
                }
            }
            finally
            {
                g_DisableTakeOffList.UnLock();
            }
            LoadList.SaveToFile(sFileName);
            Dispose(LoadList);
            result = true;
            return result;
        }

        public static bool InDisableTakeOffList(int nItemIdx)
        {
            bool result;
            int I;
            result = false;
            g_DisableTakeOffList.__Lock();
            try
            {
                if (g_DisableTakeOffList.Count > 0)
                {
                    for (I = 0; I < g_DisableTakeOffList.Count; I++)
                    {
                        //if (((int)g_DisableTakeOffList[I]) == nItemIdx - 1)
                        //{
                        //    result = true;
                        //    break;
                        //}
                    }
                }
            }
            finally
            {
                g_DisableTakeOffList.UnLock();
            }
            return result;
        }

        public static bool SaveDisableSendMsgList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "DisableSendMsgList.txt";
            LoadList = new TStringList();
            if (g_DisableSendMsgList.Count > 0)
            {
                for (I = 0; I < g_DisableSendMsgList.Count; I++)
                {
                    //LoadList.Add(g_DisableSendMsgList[I]);
                }
            }
            LoadList.SaveToFile(sFileName);
            Dispose(LoadList);
            result = true;
            return result;
        }

        public static bool GetDisableSendMsgList(string sHumanName)
        {
            bool result;
            int I;
            result = false;
            if (g_DisableSendMsgList.Count > 0)
            {
                for (I = 0; I < g_DisableSendMsgList.Count; I++)
                {
                    if ((sHumanName).ToLower().CompareTo((g_DisableSendMsgList[I]).ToLower()) == 0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool LoadGameLogItemNameList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "GameLogItemNameList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_GameLogItemNameList.__Lock();
                try
                {
                    g_GameLogItemNameList.Clear();
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_GameLogItemNameList.Add(LoadList[I].Trim());
                        // 20080303 出现异常
                    }
                }
                finally
                {
                    g_GameLogItemNameList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static byte GetGameLogItemNameList(string sItemName)
        {
            byte result;
            int I;
            result = 0;
            g_GameLogItemNameList.__Lock();
            try
            {
                if (g_GameLogItemNameList.Count > 0)
                {
                    for (I = 0; I < g_GameLogItemNameList.Count; I++)
                    {
                        if ((sItemName).ToLower().CompareTo((g_GameLogItemNameList[I]).ToLower()) == 0)
                        {
                            result = 1;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_GameLogItemNameList.UnLock();
            }
            return result;
        }

        public bool SaveGameLogItemNameList()
        {
            bool result;
            string sFileName;
            sFileName = g_Config.sEnvirDir + "GameLogItemNameList.txt";
            g_GameLogItemNameList.__Lock();
            try
            {
                g_GameLogItemNameList.SaveToFile(sFileName);
            }
            finally
            {
                g_GameLogItemNameList.UnLock();
            }
            result = true;
            return result;
        }

        public static bool LoadDenyIPAddrList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DenyIPAddrList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_DenyIPAddrList.__Lock();
                try
                {
                    if (g_DenyIPAddrList.Count > 0)
                    {
                        g_DenyIPAddrList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_DenyIPAddrList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_DenyIPAddrList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetDenyIPaddrList(string sIPaddr)
        {
            bool result;
            int I;
            result = false;
            g_DenyIPAddrList.__Lock();
            try
            {
                if (g_DenyIPAddrList.Count > 0)
                {
                    for (I = 0; I < g_DenyIPAddrList.Count; I++)
                    {
                        if ((sIPaddr).ToLower().CompareTo((g_DenyIPAddrList[I]).ToLower()) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_DenyIPAddrList.UnLock();
            }
            return result;
        }

        public static bool SaveDenyIPAddrList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "DenyIPAddrList.txt";
            SaveList = new TStringList();
            g_DenyIPAddrList.__Lock();
            try
            {
                if (g_DenyIPAddrList.Count > 0)
                {
                    for (I = 0; I < g_DenyIPAddrList.Count; I++)
                    {
                        //if (((int)g_DenyIPAddrList[I]) != 0)
                        //{
                        //    SaveList.Add(g_DenyIPAddrList[I]);
                        //}
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_DenyIPAddrList.UnLock();
            }
            SaveList.Dispose();
           
            //SaveList.Free;
            result = true;
            return result;
        }

        // 读取禁止登录人物列表
        public static bool LoadDenyChrNameList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DenyChrNameList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_DenyChrNameList.__Lock();
                try
                {
                    if (g_DenyChrNameList.Count > 0)
                    {
                        g_DenyChrNameList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                       //g_DenyChrNameList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_DenyChrNameList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetDenyChrNameList(string sChrName)
        {
            bool result;
            int I;
            result = false;
            g_DenyChrNameList.__Lock();
            try
            {
                if (g_DenyChrNameList.Count > 0)
                {
                    for (I = 0; I < g_DenyChrNameList.Count; I++)
                    {
                        if ((sChrName).ToLower().CompareTo((g_DenyChrNameList[I]).ToLower()) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_DenyChrNameList.UnLock();
            }
            return result;
        }

        // 保存禁止登录人物列表
        public static bool SaveDenyChrNameList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "DenyChrNameList.txt";
            SaveList = new TStringList();
            g_DenyChrNameList.__Lock();
            try
            {
                if (g_DenyChrNameList.Count > 0)
                {
                    for (I = 0; I < g_DenyChrNameList.Count; I++)
                    {
                        //if (((int)g_DenyChrNameList[I]) != 0)
                        //{
                        //    SaveList.Add(g_DenyChrNameList[I]);
                        //}
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_DenyChrNameList.UnLock();
            }
            SaveList.Dispose();
            //SaveList.Free;
            result = true;
            return result;
        }

        public static bool LoadDenyAccountList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "DenyAccountList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_DenyAccountList.__Lock();
                try
                {
                    if (g_DenyAccountList.Count > 0)
                    {
                        g_DenyAccountList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_DenyAccountList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_DenyAccountList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetDenyAccountList(string sAccount)
        {
            bool result;
            int I;
            result = false;
            g_DenyAccountList.__Lock();
            try
            {
                if (g_DenyAccountList.Count > 0)
                {
                    for (I = 0; I < g_DenyAccountList.Count; I++)
                    {
                        if ((sAccount).ToLower().CompareTo((g_DenyAccountList[I]).ToLower()) == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                g_DenyAccountList.UnLock();
            }
            return result;
        }

        public static bool SaveDenyAccountList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "DenyAccountList.txt";
            SaveList = new TStringList();
            g_DenyAccountList.__Lock();
            try
            {
                if (g_DenyAccountList.Count > 0)
                {
                    // 20080629
                    for (I = 0; I < g_DenyAccountList.Count; I++)
                    {
                        //if (((int)g_DenyAccountList.Values[I]) != 0)
                        //{
                        //    SaveList.Add(g_DenyAccountList[I]);
                        //}
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_DenyAccountList.UnLock();
            }
            SaveList.Dispose();
            //SaveList.Free;
            result = true;
            return result;
        }

        public static bool LoadNoClearMonList()
        {
            bool result;
            int I;
            TStringList LoadList;
            string sFileName;
            result = false;
            sFileName = g_Config.sEnvirDir + "NoClearMonList.txt";
            LoadList = new TStringList();
            if (File.Exists(sFileName))
            {
                g_NoClearMonList.__Lock();
                try
                {
                    if (g_NoClearMonList.Count > 0)
                    {
                        g_NoClearMonList.Clear();
                    }
                    LoadList.LoadFromFile(sFileName);
                    for (I = 0; I < LoadList.Count; I++)
                    {
                        //g_NoClearMonList.Add(LoadList[I].Trim());
                    }
                }
                finally
                {
                    g_NoClearMonList.UnLock();
                }
                result = true;
            }
            else
            {
                LoadList.SaveToFile(sFileName);
            }
            Dispose(LoadList);
            return result;
        }

        public static bool GetNoClearMonList(string sMonName)
        {
            bool result;
            int I;
            result = false;
            g_NoClearMonList.__Lock();
            try
            {
                for (I = 0; I < g_NoClearMonList.Count; I++)
                {
                    if ((sMonName).ToLower().CompareTo((g_NoClearMonList[I]).ToLower()) == 0)
                    {
                        result = true;
                        break;
                    }
                }
            }
            finally
            {
                g_NoClearMonList.UnLock();
            }
            return result;
        }

        public static bool SaveNoClearMonList()
        {
            bool result;
            int I;
            string sFileName;
            TStringList SaveList;
            sFileName = g_Config.sEnvirDir + "NoClearMonList.txt";
            SaveList = new TStringList();
            g_NoClearMonList.__Lock();
            try
            {
                if (g_NoClearMonList.Count > 0)
                {
                    for (I = 0; I < g_NoClearMonList.Count; I++)
                    {
                        //SaveList.Add(g_NoClearMonList[I]);
                    }
                }
                SaveList.SaveToFile(sFileName);
            }
            finally
            {
                g_NoClearMonList.UnLock();
            }
            SaveList.Dispose();
            //SaveList.Free;
            result = true;
            return result;
        }

        public static bool LoadMonSayMsg()
        {
            bool result;
            int I;
            int II;
            string sStatus = string.Empty;
            string sRate = string.Empty;
            string sColor = string.Empty;
            string sMonName = string.Empty;
            string sSayMsg = string.Empty;
            int nStatus;
            int nRate;
            int nColor;
            TStringList LoadList;
            string sLineText;
            TMonSayMsg MonSayMsg;
            string sFileName;
            ArrayList MonSayList;
            bool boSearch;
            result = false;
            sFileName = g_Config.sEnvirDir + "MonSayMsg.txt";
            if (File.Exists(sFileName))
            {
                if (g_MonSayMsgList.Count > 0)
                {
                    g_MonSayMsgList.Clear();
                }
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText != "") && (sLineText[0] < ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sStatus, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sRate, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sColor, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sMonName, new string[] { " ", "/", ",", "\09" });
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sSayMsg, new string[] { " ", "/", ",", "\09" });
                        if ((sStatus != "") && (sRate != "") && (sColor != "") && (sMonName != "") && (sSayMsg != ""))
                        {
                            nStatus = HUtil32.Str_ToInt(sStatus, -1);
                            nRate = HUtil32.Str_ToInt(sRate, -1);
                            nColor = HUtil32.Str_ToInt(sColor, -1);
                            if ((nStatus >= 0) && (nRate >= 0) && (nColor >= 0))
                            {
                                MonSayMsg = new TMonSayMsg();
                                switch (nStatus)
                                {
                                    case 0:
                                        MonSayMsg.State = TMonStatus.s_KillHuman;
                                        break;
                                    case 1:
                                        MonSayMsg.State = TMonStatus.s_UnderFire;
                                        break;
                                    case 2:
                                        MonSayMsg.State = TMonStatus.s_Die;
                                        break;
                                    case 3:
                                        MonSayMsg.State = TMonStatus.s_MonGen;
                                        break;
                                    default:
                                        MonSayMsg.State = TMonStatus.s_UnderFire;
                                        break;
                                }
                                switch (nColor)
                                {
                                    case 0:
                                        MonSayMsg.Color = TMsgColor.c_Red;
                                        break;
                                    case 1:
                                        MonSayMsg.Color = TMsgColor.c_Green;
                                        break;
                                    case 2:
                                        MonSayMsg.Color = TMsgColor.c_Blue;
                                        break;
                                    case 3:
                                        MonSayMsg.Color = TMsgColor.c_White;
                                        break;
                                    default:
                                        MonSayMsg.Color = TMsgColor.c_White;
                                        break;
                                }
                                MonSayMsg.nRate = nRate;
                                MonSayMsg.sSayMsg = sSayMsg;
                                boSearch = false;
                                if (g_MonSayMsgList.Count > 0)
                                {
                                    for (II = 0; II < g_MonSayMsgList.Count; II++)
                                    {
                                        if ((g_MonSayMsgList[II]).ToLower().CompareTo((sMonName).ToLower()) == 0)
                                        {
                                            //((g_MonSayMsgList[II]) as ArrayList).Add(MonSayMsg);
                                            boSearch = true;
                                            break;
                                        }
                                    }
                                }
                                if (!boSearch)
                                {
                                    MonSayList = new ArrayList();
                                    MonSayList.Add(MonSayMsg);
                                    //g_MonSayMsgList.Add(sMonName, ((MonSayList) as Object));
                                }
                            }
                        }
                    }
                }
                LoadList.Dispose();
                //Dispose(LoadList);
                result = true;
            }
            return result;
        }

        public static void StartFixExp()
        {
            int I;
            g_dwOldNeedExps = new uint[MAXCHANGELEVEL];
            g_dwHeroNeedExps = new uint[MAXCHANGELEVEL];
            g_dwMedicineExps = new ushort[50];
            g_dwSkill68Exps = new uint[110];
            g_dwExpCrystalNeedExps=new uint[5];
            g_dwNGExpCrystalNeedExps = new uint[5];
            g_dwOldNeedExps[0] = 100;
            g_dwOldNeedExps[2] = 200;
            g_dwOldNeedExps[3] = 300;
            g_dwOldNeedExps[4] = 400;
            g_dwOldNeedExps[5] = 600;
            g_dwOldNeedExps[6] = 900;
            g_dwOldNeedExps[7] = 1200;
            g_dwOldNeedExps[8] = 1700;
            g_dwOldNeedExps[9] = 2500;
            g_dwOldNeedExps[10] = 6000;
            g_dwOldNeedExps[11] = 8000;
            g_dwOldNeedExps[12] = 10000;
            g_dwOldNeedExps[13] = 15000;
            g_dwOldNeedExps[14] = 30000;
            g_dwOldNeedExps[15] = 40000;
            g_dwOldNeedExps[16] = 50000;
            g_dwOldNeedExps[17] = 70000;
            g_dwOldNeedExps[18] = 10000;
            g_dwOldNeedExps[19] = 120000;
            g_dwOldNeedExps[20] = 140000;
            g_dwOldNeedExps[21] = 250000;
            g_dwOldNeedExps[22] = 300000;
            g_dwOldNeedExps[23] = 350000;
            g_dwOldNeedExps[24] = 400000;
            g_dwOldNeedExps[25] = 500000;
            g_dwOldNeedExps[26] = 700000;
            g_dwOldNeedExps[27] = 1000000;
            g_dwOldNeedExps[28] = 1400000;
            g_dwOldNeedExps[29] = 1800000;
            g_dwOldNeedExps[30] = 2000000;
            g_dwOldNeedExps[31] = 2400000;
            g_dwOldNeedExps[32] = 2800000;
            g_dwOldNeedExps[33] = 3200000;
            g_dwOldNeedExps[34] = 3600000;
            g_dwOldNeedExps[35] = 4000000;
            g_dwOldNeedExps[36] = 4800000;
            g_dwOldNeedExps[37] = 5600000;
            g_dwOldNeedExps[38] = 8200000;
            g_dwOldNeedExps[39] = 9000000;
            g_dwOldNeedExps[40] = 12000000;
            g_dwOldNeedExps[41] = 16000000;
            g_dwOldNeedExps[42] = 30000000;
            g_dwOldNeedExps[43] = 50000000;
            g_dwOldNeedExps[44] = 80000000;
            g_dwOldNeedExps[45] = 120000000;
            g_dwOldNeedExps[46] = 480000000;
            g_dwOldNeedExps[47] = 1000000000;
            g_dwOldNeedExps[48] = 1500000000;
            g_dwOldNeedExps[49] = 1800000000;
            for (I = 50; I <= g_dwOldNeedExps.GetUpperBound(0); I++)
            {
                g_dwOldNeedExps[I] = 2000000000;
            }
            g_dwHeroNeedExps[0] = 50;
            g_dwHeroNeedExps[2] = 100;
            g_dwHeroNeedExps[3] = 150;
            g_dwHeroNeedExps[4] = 200;
            g_dwHeroNeedExps[5] = 300;
            g_dwHeroNeedExps[6] = 450;
            g_dwHeroNeedExps[7] = 600;
            g_dwHeroNeedExps[8] = 800;
            g_dwHeroNeedExps[9] = 1200;
            g_dwHeroNeedExps[10] = 3000;
            g_dwHeroNeedExps[11] = 4000;
            g_dwHeroNeedExps[12] = 5000;
            g_dwHeroNeedExps[13] = 7500;
            g_dwHeroNeedExps[14] = 15000;
            g_dwHeroNeedExps[15] = 20000;
            g_dwHeroNeedExps[16] = 25000;
            g_dwHeroNeedExps[17] = 35000;
            g_dwHeroNeedExps[18] = 50000;
            g_dwHeroNeedExps[19] = 60000;
            g_dwHeroNeedExps[20] = 70000;
            g_dwHeroNeedExps[21] = 100000;
            g_dwHeroNeedExps[22] = 150000;
            g_dwHeroNeedExps[23] = 160000;
            g_dwHeroNeedExps[24] = 200000;
            g_dwHeroNeedExps[25] = 250000;
            g_dwHeroNeedExps[26] = 350000;
            g_dwHeroNeedExps[27] = 500000;
            g_dwHeroNeedExps[28] = 700000;
            g_dwHeroNeedExps[29] = 800000;
            g_dwHeroNeedExps[30] = 1000000;
            g_dwHeroNeedExps[31] = 1200000;
            g_dwHeroNeedExps[32] = 1400000;
            g_dwHeroNeedExps[33] = 1600000;
            g_dwHeroNeedExps[34] = 1800000;
            g_dwHeroNeedExps[35] = 2000000;
            g_dwHeroNeedExps[36] = 2400000;
            g_dwHeroNeedExps[37] = 2800000;
            g_dwHeroNeedExps[38] = 4000000;
            g_dwHeroNeedExps[39] = 4500000;
            g_dwHeroNeedExps[40] = 6000000;
            g_dwHeroNeedExps[41] = 8000000;
            g_dwHeroNeedExps[42] = 15000000;
            g_dwHeroNeedExps[43] = 25000000;
            g_dwHeroNeedExps[44] = 40000000;
            g_dwHeroNeedExps[45] = 60000000;
            g_dwHeroNeedExps[46] = 240000000;
            g_dwHeroNeedExps[47] = 500000000;
            g_dwHeroNeedExps[48] = 800000000;
            g_dwHeroNeedExps[49] = 900000000;
            for (I = 50; I <= g_dwHeroNeedExps.GetUpperBound(0); I++)
            {
                g_dwHeroNeedExps[I] = 1000000000;
            }
            g_dwMedicineExps[0] = 48;
            g_dwMedicineExps[2] = 142;
            g_dwMedicineExps[3] = 232;
            g_dwMedicineExps[4] = 318;
            g_dwMedicineExps[5] = 400;
            g_dwMedicineExps[6] = 478;
            g_dwMedicineExps[7] = 556;
            g_dwMedicineExps[8] = 634;
            g_dwMedicineExps[9] = 712;
            g_dwMedicineExps[10] = 790;
            g_dwMedicineExps[11] = 868;
            g_dwMedicineExps[12] = 946;
            g_dwMedicineExps[13] = 1024;
            g_dwMedicineExps[14] = 1102;
            g_dwMedicineExps[15] = 1180;
            g_dwMedicineExps[16] = 1258;
            g_dwMedicineExps[17] = 1336;
            g_dwMedicineExps[18] = 1414;
            g_dwMedicineExps[19] = 1492;
            g_dwMedicineExps[20] = 1570;
            g_dwMedicineExps[21] = 1648;
            g_dwMedicineExps[22] = 1726;
            g_dwMedicineExps[23] = 1804;
            g_dwMedicineExps[24] = 1882;
            g_dwMedicineExps[25] = 1960;
            g_dwMedicineExps[26] = 2038;
            g_dwMedicineExps[27] = 2116;
            g_dwMedicineExps[28] = 2194;
            g_dwMedicineExps[29] = 2272;
            g_dwMedicineExps[30] = 2350;
            g_dwMedicineExps[31] = 2428;
            g_dwMedicineExps[32] = 2506;
            g_dwMedicineExps[33] = 2584;
            g_dwMedicineExps[34] = 2662;
            g_dwMedicineExps[35] = 2740;
            g_dwMedicineExps[36] = 2818;
            g_dwMedicineExps[37] = 2896;
            g_dwMedicineExps[38] = 2974;
            g_dwMedicineExps[39] = 3052;
            g_dwMedicineExps[40] = 3130;
            g_dwMedicineExps[41] = 3208;
            g_dwMedicineExps[42] = 3286;
            g_dwMedicineExps[43] = 3364;
            g_dwMedicineExps[44] = 3442;
            g_dwMedicineExps[45] = 3520;
            g_dwMedicineExps[46] = 3598;
            g_dwMedicineExps[47] = 3676;
            g_dwMedicineExps[48] = 3754;
            g_dwMedicineExps[49] = 3832;
            for (I = 50; I <= g_dwMedicineExps.GetUpperBound(0); I++)
            {
                g_dwMedicineExps[I] = 3910;
            }
            g_dwSkill68Exps[0] = 3333000;
            g_dwSkill68Exps[2] = 3816000;
            g_dwSkill68Exps[3] = 4329000;
            g_dwSkill68Exps[4] = 4872000;
            g_dwSkill68Exps[5] = 5445000;
            g_dwSkill68Exps[6] = 6048000;
            g_dwSkill68Exps[7] = 6681000;
            g_dwSkill68Exps[8] = 7344000;
            g_dwSkill68Exps[9] = 8037000;
            g_dwSkill68Exps[10] = 8760000;
            g_dwSkill68Exps[11] = 9513000;
            g_dwSkill68Exps[12] = 10296000;
            g_dwSkill68Exps[13] = 11109000;
            g_dwSkill68Exps[14] = 11952000;
            g_dwSkill68Exps[15] = 12825000;
            g_dwSkill68Exps[16] = 13728000;
            g_dwSkill68Exps[17] = 14661000;
            g_dwSkill68Exps[18] = 15624000;
            g_dwSkill68Exps[19] = 16617000;
            g_dwSkill68Exps[20] = 17640000;
            g_dwSkill68Exps[21] = 18693000;
            g_dwSkill68Exps[22] = 19776000;
            g_dwSkill68Exps[23] = 20889000;
            g_dwSkill68Exps[24] = 22032000;
            g_dwSkill68Exps[25] = 23205000;
            g_dwSkill68Exps[26] = 24408000;
            g_dwSkill68Exps[27] = 25641000;
            g_dwSkill68Exps[28] = 26904000;
            g_dwSkill68Exps[29] = 28197000;
            g_dwSkill68Exps[30] = 29520000;
            g_dwSkill68Exps[31] = 30873000;
            g_dwSkill68Exps[32] = 32256000;
            g_dwSkill68Exps[33] = 33669000;
            g_dwSkill68Exps[34] = 35112000;
            g_dwSkill68Exps[35] = 36585000;
            g_dwSkill68Exps[36] = 38088000;
            g_dwSkill68Exps[37] = 39621000;
            g_dwSkill68Exps[38] = 41184000;
            g_dwSkill68Exps[39] = 42777000;
            g_dwSkill68Exps[40] = 44400000;
            g_dwSkill68Exps[41] = 46053000;
            g_dwSkill68Exps[42] = 47736000;
            g_dwSkill68Exps[43] = 49449000;
            g_dwSkill68Exps[44] = 51192000;
            g_dwSkill68Exps[45] = 52965000;
            g_dwSkill68Exps[46] = 54768000;
            g_dwSkill68Exps[47] = 56601000;
            g_dwSkill68Exps[48] = 58464000;
            g_dwSkill68Exps[49] = 60357000;
            g_dwSkill68Exps[50] = 62280000;
            g_dwSkill68Exps[51] = 64233000;
            g_dwSkill68Exps[52] = 66216000;
            g_dwSkill68Exps[53] = 68229000;
            g_dwSkill68Exps[54] = 70272000;
            g_dwSkill68Exps[55] = 72345000;
            g_dwSkill68Exps[56] = 74448000;
            g_dwSkill68Exps[57] = 76581000;
            g_dwSkill68Exps[58] = 78744000;
            g_dwSkill68Exps[59] = 80937000;
            g_dwSkill68Exps[60] = 83160000;
            g_dwSkill68Exps[61] = 85413000;
            g_dwSkill68Exps[62] = 87696000;
            g_dwSkill68Exps[63] = 90009000;
            g_dwSkill68Exps[64] = 92352000;
            g_dwSkill68Exps[65] = 94725000;
            g_dwSkill68Exps[66] = 97128000;
            g_dwSkill68Exps[67] = 99561000;
            g_dwSkill68Exps[68] = 102024000;
            g_dwSkill68Exps[69] = 104517000;
            g_dwSkill68Exps[70] = 107040000;
            g_dwSkill68Exps[71] = 109593000;
            g_dwSkill68Exps[72] = 112176000;
            g_dwSkill68Exps[73] = 114789000;
            g_dwSkill68Exps[74] = 117432000;
            g_dwSkill68Exps[75] = 120105000;
            g_dwSkill68Exps[76] = 122808000;
            g_dwSkill68Exps[77] = 125541000;
            g_dwSkill68Exps[78] = 128304000;
            g_dwSkill68Exps[79] = 131097000;
            g_dwSkill68Exps[80] = 133920000;
            g_dwSkill68Exps[81] = 136773000;
            g_dwSkill68Exps[82] = 139656000;
            g_dwSkill68Exps[83] = 142569000;
            g_dwSkill68Exps[84] = 145512000;
            g_dwSkill68Exps[85] = 148485000;
            g_dwSkill68Exps[86] = 151488000;
            g_dwSkill68Exps[87] = 154521000;
            g_dwSkill68Exps[88] = 157584000;
            g_dwSkill68Exps[89] = 160677000;
            g_dwSkill68Exps[90] = 163800000;
            g_dwSkill68Exps[91] = 166953000;
            g_dwSkill68Exps[92] = 170136000;
            g_dwSkill68Exps[93] = 173349000;
            g_dwSkill68Exps[94] = 176592000;
            g_dwSkill68Exps[95] = 179865000;
            g_dwSkill68Exps[96] = 183168000;
            g_dwSkill68Exps[97] = 186501000;
            g_dwSkill68Exps[98] = 189864000;
            g_dwSkill68Exps[99] = 193257000;
            g_dwSkill68Exps[100] = 203257000;
            g_dwExpCrystalNeedExps[0] = 300000;
            // 天地结晶升级经验
            g_dwExpCrystalNeedExps[2] = 700000;
            g_dwExpCrystalNeedExps[3] = 1200000;
            g_dwExpCrystalNeedExps[4] = 1800000;
            g_dwNGExpCrystalNeedExps[0] = 100000;
            // 天地结晶内功升级经验
            g_dwNGExpCrystalNeedExps[2] = 240000;
            g_dwNGExpCrystalNeedExps[3] = 400000;
            g_dwNGExpCrystalNeedExps[4] = 580000;
        }

        public static void LoadExp()
        {
            int I;
            int LoadInteger;
            int LoadInteger1;
            string LoadString;
            LoadInteger = Config.ReadInteger("Exp", "KillMonExpMultiple", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "KillMonExpMultiple", g_Config.dwKillMonExpMultiple);
            }
            else
            {
                g_Config.dwKillMonExpMultiple = Config.ReadInteger("Exp", "KillMonExpMultiple", g_Config.dwKillMonExpMultiple);
            }
            // 杀怪内功经验倍数
            LoadInteger = Config.ReadInteger("Exp", "KillMonNGExpMultiple", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "KillMonNGExpMultiple", g_Config.dwKillMonNGExpMultiple);
            }
            else
            {
                g_Config.dwKillMonNGExpMultiple = Config.ReadInteger("Exp", "KillMonNGExpMultiple", g_Config.dwKillMonNGExpMultiple);
            }
            LoadInteger = Config.ReadInteger("Exp", "HighLevelKillMonFixExp", -1);
            if (LoadInteger < 0)
            {
                Config.WriteBool("Exp", "HighLevelKillMonFixExp", g_Config.boHighLevelKillMonFixExp);
            }
            else
            {
                g_Config.boHighLevelKillMonFixExp = Config.ReadBool("Exp", "HighLevelKillMonFixExp", g_Config.boHighLevelKillMonFixExp);
            }
            for (I = 0; I <= MAXCHANGELEVEL -1; I++)
            {
                LoadString = Config.ReadString("Exp", "Level" + I, "");
                LoadInteger1 = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger1 == 0)
                {
                    Config.WriteString("Exp", "Level" + I, g_dwOldNeedExps[I].ToString());
                    g_Config.dwNeedExps[I] = g_dwOldNeedExps[I];
                }
                else
                {
                    if ((LoadInteger1 > 0))
                    {
                        g_Config.dwNeedExps[I] = (uint)LoadInteger1;
                    }
                    else
                    {
                        g_Config.dwNeedExps[I] = g_dwOldNeedExps[I];
                    }
                }
            }
            for (I = 0; I <= MAXCHANGELEVEL - 1; I++)
            {
                LoadString = Config.ReadString("HeroExp", "Level" + I, "");
                LoadInteger1 = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger1 == 0)
                {
                    Config.WriteString("HeroExp", "Level" + I, (g_dwHeroNeedExps[I]).ToString());
                    g_Config.dwHeroNeedExps[I] = g_dwHeroNeedExps[I];
                }
                else
                {
                    if ((LoadInteger1 > 0))
                    {
                        g_Config.dwHeroNeedExps[I] = (uint)LoadInteger1;
                    }
                    else
                    {
                        g_Config.dwHeroNeedExps[I] = g_dwHeroNeedExps[I];
                    }
                }
            }
            // ----------------------------------------------------------------------------
            // 药力值
            for (I = 0; I <= 50 - 1; I++)
            {
                LoadString = Config.ReadString("MedicineExp", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("MedicineExp", "Level" + I, (g_dwMedicineExps[I]).ToString());
                    g_Config.dwMedicineNeedExps[I] = g_dwMedicineExps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwMedicineNeedExps[I] = (ushort)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwMedicineNeedExps[I] = g_dwMedicineExps[I];
                    }
                }
            }
            // ----------------------------------------------------------------------------
            // 酒气护体
            for (I = 0; I <= 100-1; I++)
            {
                LoadString = Config.ReadString("Skill68", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("Skill68", "Level" + I, (int)g_dwSkill68Exps[I]);
                    g_Config.dwSkill68NeedExps[I] = g_dwSkill68Exps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwSkill68NeedExps[I] = (uint)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwSkill68NeedExps[I] = g_dwSkill68Exps[I];
                    }
                }
            }
            // 天地结晶经验
            for (I = 0; I <= 4; I++)
            {
                LoadString = Config.ReadString("ExpCrystal", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("ExpCrystal", "Level" + I, (int)g_dwExpCrystalNeedExps[I]);
                    g_Config.dwExpCrystalNeedExps[I] = g_dwExpCrystalNeedExps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwExpCrystalNeedExps[I] = (uint)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwExpCrystalNeedExps[I] = g_dwExpCrystalNeedExps[I];
                    }
                }
            }
            // 天地结晶内功经验
            for (I = 0; I <= 4; I++)
            {
                LoadString = Config.ReadString("NGExpCrystal", "Level" + I, "");
                LoadInteger = HUtil32.Str_ToInt(LoadString, 0);
                if (LoadInteger == 0)
                {
                    Config.WriteString("NGExpCrystal", "Level" + I, (int)g_dwNGExpCrystalNeedExps[I]);
                    g_Config.dwNGExpCrystalNeedExps[I] = g_dwNGExpCrystalNeedExps[I];
                }
                else
                {
                    if ((LoadInteger > 0))
                    {
                        g_Config.dwNGExpCrystalNeedExps[I] = (uint)LoadInteger;
                    }
                    else
                    {
                        g_Config.dwNGExpCrystalNeedExps[I] = g_dwNGExpCrystalNeedExps[I];
                    }
                }
            }
            // ----------------------------------------------------------------------------
            if (Config.ReadInteger("Exp", "UseFixExp", -1) < 0)
            {
                Config.WriteBool("Exp", "UseFixExp", g_Config.boUseFixExp);
            }
            g_Config.boUseFixExp = Config.ReadBool("Setup", "UseFixExp", g_Config.boUseFixExp);
            LoadInteger = Config.ReadInteger("Exp", "BaseExp", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "BaseExp", g_Config.nBaseExp);
            }
            else
            {
                g_Config.nBaseExp = LoadInteger;
            }
            LoadInteger = Config.ReadInteger("Setup", "AddExp", -1);
            if (LoadInteger < 0)
            {
                Config.WriteInteger("Exp", "AddExp", g_Config.nAddExp);
            }
            else
            {
                g_Config.nAddExp = LoadInteger;
            }
        }

        /// <summary>
        /// 加载游戏命令
        /// </summary>
        public static void LoadGameCommand()
        {
            string LoadString;
            int nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "Date", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Date", g_GameCommand.Data.sCmd);
            }
            else
            {
                g_GameCommand.Data.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Date", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Date", g_GameCommand.Data.nPermissionMin);
            }
            else
            {
                g_GameCommand.Data.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "PrvMsg", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "PrvMsg", g_GameCommand.PRVMSG.sCmd);
            }
            else
            {
                g_GameCommand.PRVMSG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "PrvMsg", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "PrvMsg", g_GameCommand.PRVMSG.nPermissionMin);
            }
            else
            {
                g_GameCommand.PRVMSG.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "AllowMsg", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AllowMsg", g_GameCommand.ALLOWMSG.sCmd);
            }
            else
            {
                g_GameCommand.ALLOWMSG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AllowMsg", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AllowMsg", g_GameCommand.ALLOWMSG.nPermissionMin);
            }
            else
            {
                g_GameCommand.ALLOWMSG.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "LetShout", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "LetShout", g_GameCommand.LETSHOUT.sCmd);
            }
            else
            {
                g_GameCommand.LETSHOUT.sCmd = LoadString;
            }
            g_GameCommand.BANGMMSG.sCmd = "禁止喊话";
            LoadString = CommandConf.ReadString("Command", "LetTrade", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "LetTrade", g_GameCommand.LETTRADE.sCmd);
            }
            else
            {
                g_GameCommand.LETTRADE.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "LetGuild", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "LetGuild", g_GameCommand.LETGUILD.sCmd);
            }
            else
            {
                g_GameCommand.LETGUILD.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "EndGuild", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "EndGuild", g_GameCommand.ENDGUILD.sCmd);
            }
            else
            {
                g_GameCommand.ENDGUILD.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "BanGuildChat", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "BanGuildChat", g_GameCommand.BANGUILDCHAT.sCmd);
            }
            else
            {
                g_GameCommand.BANGUILDCHAT.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "AuthAlly", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AuthAlly", g_GameCommand.AUTHALLY.sCmd);
            }
            else
            {
                g_GameCommand.AUTHALLY.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "Auth", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Auth", g_GameCommand.AUTH.sCmd);
            }
            else
            {
                g_GameCommand.AUTH.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "AuthCancel", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AuthCancel", g_GameCommand.AUTHCANCEL.sCmd);
            }
            else
            {
                g_GameCommand.AUTHCANCEL.sCmd = LoadString;
            }
            // 未使用 20080823
            // LoadString := CommandConf.ReadString('Command', 'ViewDiary', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ViewDiary', g_GameCommand.DIARY.sCmd)
            // else g_GameCommand.DIARY.sCmd := LoadString;
            LoadString = CommandConf.ReadString("Command", "UserMove", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "UserMove", g_GameCommand.USERMOVE.sCmd);
            }
            else
            {
                g_GameCommand.USERMOVE.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "Searching", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Searching", g_GameCommand.SEARCHING.sCmd);
            }
            else
            {
                g_GameCommand.SEARCHING.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "AllowGroupCall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AllowGroupCall", g_GameCommand.ALLOWGROUPCALL.sCmd);
            }
            else
            {
                g_GameCommand.ALLOWGROUPCALL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "GroupCall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GroupCall", g_GameCommand.GROUPRECALLL.sCmd);
            }
            else
            {
                g_GameCommand.GROUPRECALLL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "AllowGuildReCall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AllowGuildReCall", g_GameCommand.ALLOWGUILDRECALL.sCmd);
            }
            else
            {
                g_GameCommand.ALLOWGUILDRECALL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "GuildReCall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GuildReCall", g_GameCommand.GUILDRECALLL.sCmd);
            }
            else
            {
                g_GameCommand.GUILDRECALLL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "StorageUnLock", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StorageUnLock", g_GameCommand.UNLOCKSTORAGE.sCmd);
            }
            else
            {
                g_GameCommand.UNLOCKSTORAGE.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "PasswordUnLock", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "PasswordUnLock", g_GameCommand.UnLock.sCmd);
            }
            else
            {
                g_GameCommand.UnLock.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "StorageLock", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StorageLock", g_GameCommand.__Lock.sCmd);
            }
            else
            {
                g_GameCommand.__Lock.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "StorageSetPassword", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StorageSetPassword", g_GameCommand.SETPASSWORD.sCmd);
            }
            else
            {
                g_GameCommand.SETPASSWORD.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "PasswordLock", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "PasswordLock", g_GameCommand.PASSWORDLOCK.sCmd);
            }
            else
            {
                g_GameCommand.PASSWORDLOCK.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "StorageChgPassword", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StorageChgPassword", g_GameCommand.CHGPASSWORD.sCmd);
            }
            else
            {
                g_GameCommand.CHGPASSWORD.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "StorageClearPassword", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StorageClearPassword", g_GameCommand.CLRPASSWORD.sCmd);
            }
            else
            {
                g_GameCommand.CLRPASSWORD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "StorageClearPassword", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "StorageClearPassword", g_GameCommand.CLRPASSWORD.nPermissionMin);
            }
            else
            {
                g_GameCommand.CLRPASSWORD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "StorageUserClearPassword", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StorageUserClearPassword", g_GameCommand.UNPASSWORD.sCmd);
            }
            else
            {
                g_GameCommand.UNPASSWORD.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "MemberFunc", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MemberFunc", g_GameCommand.MEMBERFUNCTION.sCmd);
            }
            else
            {
                g_GameCommand.MEMBERFUNCTION.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "MemberFuncEx", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MemberFuncEx", g_GameCommand.MEMBERFUNCTIONEX.sCmd);
            }
            else
            {
                g_GameCommand.MEMBERFUNCTIONEX.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "Dear", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Dear", g_GameCommand.DEAR.sCmd);
            }
            else
            {
                g_GameCommand.DEAR.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "Master", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Master", g_GameCommand.MASTER.sCmd);
            }
            else
            {
                g_GameCommand.MASTER.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "DearRecall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DearRecall", g_GameCommand.DEARRECALL.sCmd);
            }
            else
            {
                g_GameCommand.DEARRECALL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "MasterRecall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MasterRecall", g_GameCommand.MASTERECALL.sCmd);
            }
            else
            {
                g_GameCommand.MASTERECALL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "AllowDearRecall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AllowDearRecall", g_GameCommand.ALLOWDEARRCALL.sCmd);
            }
            else
            {
                g_GameCommand.ALLOWDEARRCALL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "AllowMasterRecall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AllowMasterRecall", g_GameCommand.ALLOWMASTERRECALL.sCmd);
            }
            else
            {
                g_GameCommand.ALLOWMASTERRECALL.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "AttackMode", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AttackMode", g_GameCommand.ATTACKMODE.sCmd);
            }
            else
            {
                g_GameCommand.ATTACKMODE.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "Rest", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Rest", g_GameCommand.REST.sCmd);
            }
            else
            {
                g_GameCommand.REST.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "TakeOnHorse", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "TakeOnHorse", g_GameCommand.TAKEONHORSE.sCmd);
            }
            else
            {
                g_GameCommand.TAKEONHORSE.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "TakeOffHorse", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "TakeOffHorse", g_GameCommand.TAKEOFHORSE.sCmd);
            }
            else
            {
                g_GameCommand.TAKEOFHORSE.sCmd = LoadString;
            }
            LoadString = CommandConf.ReadString("Command", "HumanLocal", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "HumanLocal", g_GameCommand.HUMANLOCAL.sCmd);
            }
            else
            {
                g_GameCommand.HUMANLOCAL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "HumanLocal", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "HumanLocal", g_GameCommand.HUMANLOCAL.nPermissionMin);
            }
            else
            {
                g_GameCommand.HUMANLOCAL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Move", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Move", g_GameCommand.Move.sCmd);
            }
            else
            {
                g_GameCommand.Move.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MoveMin", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MoveMin", g_GameCommand.Move.nPermissionMin);
            }
            else
            {
                g_GameCommand.Move.nPermissionMin = nLoadInteger;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MoveMax", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MoveMax", g_GameCommand.Move.nPermissionMax);
            }
            else
            {
                g_GameCommand.Move.nPermissionMax = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "PositionMove", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "PositionMove", g_GameCommand.POSITIONMOVE.sCmd);
            }
            else
            {
                g_GameCommand.POSITIONMOVE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "PositionMoveMin", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "PositionMoveMin", g_GameCommand.POSITIONMOVE.nPermissionMin);
            }
            else
            {
                g_GameCommand.POSITIONMOVE.nPermissionMin = nLoadInteger;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "PositionMoveMax", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "PositionMoveMax", g_GameCommand.POSITIONMOVE.nPermissionMax);
            }
            else
            {
                g_GameCommand.POSITIONMOVE.nPermissionMax = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Info", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Info", g_GameCommand.INFO.sCmd);
            }
            else
            {
                g_GameCommand.INFO.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Info", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Info", g_GameCommand.INFO.nPermissionMin);
            }
            else
            {
                g_GameCommand.INFO.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "MobLevel", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MobLevel", g_GameCommand.MOBLEVEL.sCmd);
            }
            else
            {
                g_GameCommand.MOBLEVEL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MobLevel", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MobLevel", g_GameCommand.MOBLEVEL.nPermissionMin);
            }
            else
            {
                g_GameCommand.MOBLEVEL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "MobCount", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MobCount", g_GameCommand.MOBCOUNT.sCmd);
            }
            else
            {
                g_GameCommand.MOBCOUNT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MobCount", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MobCount", g_GameCommand.MOBCOUNT.nPermissionMin);
            }
            else
            {
                g_GameCommand.MOBCOUNT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "HumanCount", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "HumanCount", g_GameCommand.HUMANCOUNT.sCmd);
            }
            else
            {
                g_GameCommand.HUMANCOUNT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "HumanCount", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "HumanCount", g_GameCommand.HUMANCOUNT.nPermissionMin);
            }
            else
            {
                g_GameCommand.HUMANCOUNT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Map", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Map", g_GameCommand.Map.sCmd);
            }
            else
            {
                g_GameCommand.Map.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Map", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Map", g_GameCommand.Map.nPermissionMin);
            }
            else
            {
                g_GameCommand.Map.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Kick", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Kick", g_GameCommand.KICK.sCmd);
            }
            else
            {
                g_GameCommand.KICK.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Kick", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Kick", g_GameCommand.KICK.nPermissionMin);
            }
            else
            {
                g_GameCommand.KICK.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Ting", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Ting", g_GameCommand.TING.sCmd);
            }
            else
            {
                g_GameCommand.TING.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Ting", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Ting", g_GameCommand.TING.nPermissionMin);
            }
            else
            {
                g_GameCommand.TING.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SuperTing", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SuperTing", g_GameCommand.SUPERTING.sCmd);
            }
            else
            {
                g_GameCommand.SUPERTING.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SuperTing", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SuperTing", g_GameCommand.SUPERTING.nPermissionMin);
            }
            else
            {
                g_GameCommand.SUPERTING.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "MapMove", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MapMove", g_GameCommand.MAPMOVE.sCmd);
            }
            else
            {
                g_GameCommand.MAPMOVE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MapMove", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MapMove", g_GameCommand.MAPMOVE.nPermissionMin);
            }
            else
            {
                g_GameCommand.MAPMOVE.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Shutup", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Shutup", g_GameCommand.SHUTUP.sCmd);
            }
            else
            {
                g_GameCommand.SHUTUP.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Shutup", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Shutup", g_GameCommand.SHUTUP.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHUTUP.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReleaseShutup", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReleaseShutup", g_GameCommand.RELEASESHUTUP.sCmd);
            }
            else
            {
                g_GameCommand.RELEASESHUTUP.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReleaseShutup", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReleaseShutup", g_GameCommand.RELEASESHUTUP.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELEASESHUTUP.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ShutupList", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ShutupList", g_GameCommand.SHUTUPLIST.sCmd);
            }
            else
            {
                g_GameCommand.SHUTUPLIST.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ShutupList", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ShutupList", g_GameCommand.SHUTUPLIST.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHUTUPLIST.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "GameMaster", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GameMaster", g_GameCommand.GAMEMASTER.sCmd);
            }
            else
            {
                g_GameCommand.GAMEMASTER.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "GameMaster", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "GameMaster", g_GameCommand.GAMEMASTER.nPermissionMin);
            }
            else
            {
                g_GameCommand.GAMEMASTER.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ObServer", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ObServer", g_GameCommand.OBSERVER.sCmd);
            }
            else
            {
                g_GameCommand.OBSERVER.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ObServer", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ObServer", g_GameCommand.OBSERVER.nPermissionMin);
            }
            else
            {
                g_GameCommand.OBSERVER.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SuperMan", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SuperMan", g_GameCommand.SUEPRMAN.sCmd);
            }
            else
            {
                g_GameCommand.SUEPRMAN.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SuperMan", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SuperMan", g_GameCommand.SUEPRMAN.nPermissionMin);
            }
            else
            {
                g_GameCommand.SUEPRMAN.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Level", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Level", g_GameCommand.Level.sCmd);
            }
            else
            {
                g_GameCommand.Level.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Level", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Level", g_GameCommand.Level.nPermissionMin);
            }
            else
            {
                g_GameCommand.Level.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SabukWallGold", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SabukWallGold", g_GameCommand.SABUKWALLGOLD.sCmd);
            }
            else
            {
                g_GameCommand.SABUKWALLGOLD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SabukWallGold", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SabukWallGold", g_GameCommand.SABUKWALLGOLD.nPermissionMin);
            }
            else
            {
                g_GameCommand.SABUKWALLGOLD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Recall", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Recall", g_GameCommand.RECALL.sCmd);
            }
            else
            {
                g_GameCommand.RECALL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Recall", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Recall", g_GameCommand.RECALL.nPermissionMin);
            }
            else
            {
                g_GameCommand.RECALL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReGoto", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReGoto", g_GameCommand.REGOTO.sCmd);
            }
            else
            {
                g_GameCommand.REGOTO.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReGoto", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReGoto", g_GameCommand.REGOTO.nPermissionMin);
            }
            else
            {
                g_GameCommand.REGOTO.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Flag", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Flag", g_GameCommand.SHOWFLAG.sCmd);
            }
            else
            {
                g_GameCommand.SHOWFLAG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Flag", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Flag", g_GameCommand.SHOWFLAG.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHOWFLAG.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'ShowOpen', ''); //20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ShowOpen', g_GameCommand.SHOWOPEN.sCmd)
            // else g_GameCommand.SHOWOPEN.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ShowOpen', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ShowOpen', g_GameCommand.SHOWOPEN.nPermissionMin)
            // else g_GameCommand.SHOWOPEN.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ShowUnit', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ShowUnit', g_GameCommand.SHOWUNIT.sCmd)
            // else g_GameCommand.SHOWUNIT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ShowUnit', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ShowUnit', g_GameCommand.SHOWUNIT.nPermissionMin)
            // else g_GameCommand.SHOWUNIT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'Attack', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Attack', g_GameCommand.Attack.sCmd)
            // else g_GameCommand.Attack.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Attack', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Attack', g_GameCommand.Attack.nPermissionMin)
            // else g_GameCommand.Attack.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "Mob", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Mob", g_GameCommand.MOB.sCmd);
            }
            else
            {
                g_GameCommand.MOB.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Mob", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Mob", g_GameCommand.MOB.nPermissionMin);
            }
            else
            {
                g_GameCommand.MOB.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "MobNpc", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MobNpc", g_GameCommand.MOBNPC.sCmd);
            }
            else
            {
                g_GameCommand.MOBNPC.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MobNpc", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MobNpc", g_GameCommand.MOBNPC.nPermissionMin);
            }
            else
            {
                g_GameCommand.MOBNPC.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelNpc", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelNpc", g_GameCommand.DELNPC.sCmd);
            }
            else
            {
                g_GameCommand.DELNPC.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelNpc", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelNpc", g_GameCommand.DELNPC.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELNPC.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "NpcScript", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "NpcScript", g_GameCommand.NPCSCRIPT.sCmd);
            }
            else
            {
                g_GameCommand.NPCSCRIPT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "NpcScript", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "NpcScript", g_GameCommand.NPCSCRIPT.nPermissionMin);
            }
            else
            {
                g_GameCommand.NPCSCRIPT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "RecallMob", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "RecallMob", g_GameCommand.RECALLMOB.sCmd);
            }
            else
            {
                g_GameCommand.RECALLMOB.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "RecallMob", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "RecallMob", g_GameCommand.RECALLMOB.nPermissionMin);
            }
            else
            {
                g_GameCommand.RECALLMOB.nPermissionMin = nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            // 20080122 召唤宝宝
            LoadString = CommandConf.ReadString("Command", "RECALLMOBEX", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "RECALLMOBEX", g_GameCommand.RECALLMOBEX.sCmd);
            }
            else
            {
                g_GameCommand.RECALLMOBEX.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "RECALLMOBEX", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "RECALLMOBEX", g_GameCommand.RECALLMOBEX.nPermissionMin);
            }
            else
            {
                g_GameCommand.RECALLMOBEX.nPermissionMin = nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            // 20080403 给指定纯度的矿石
            LoadString = CommandConf.ReadString("Command", "GIVEMINE", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GIVEMINE", g_GameCommand.GIVEMINE.sCmd);
            }
            else
            {
                g_GameCommand.GIVEMINE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "GIVEMINE", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "GIVEMINE", g_GameCommand.GIVEMINE.nPermissionMin);
            }
            else
            {
                g_GameCommand.GIVEMINE.nPermissionMin = nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            // 20080123 将指定坐标的怪物移动到新坐标
            LoadString = CommandConf.ReadString("Command", "MOVEMOBTO", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MOVEMOBTO", g_GameCommand.MOVEMOBTO.sCmd);
            }
            else
            {
                g_GameCommand.MOVEMOBTO.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MOVEMOBTO", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MOVEMOBTO", g_GameCommand.MOVEMOBTO.nPermissionMin);
            }
            else
            {
                g_GameCommand.MOVEMOBTO.nPermissionMin = nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            // 20080124 清除地图物品
            LoadString = CommandConf.ReadString("Command", "CLEARITEMMAP", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "CLEARITEMMAP", g_GameCommand.CLEARITEMMAP.sCmd);
            }
            else
            {
                g_GameCommand.CLEARITEMMAP.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "CLEARITEMMAP", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "CLEARITEMMAP", g_GameCommand.CLEARITEMMAP.nPermissionMin);
            }
            else
            {
                g_GameCommand.CLEARITEMMAP.nPermissionMin = nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            LoadString = CommandConf.ReadString("Command", "LuckPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "LuckPoint", g_GameCommand.LUCKYPOINT.sCmd);
            }
            else
            {
                g_GameCommand.LUCKYPOINT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "LuckPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "LuckPoint", g_GameCommand.LUCKYPOINT.nPermissionMin);
            }
            else
            {
                g_GameCommand.LUCKYPOINT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "LotteryTicket", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "LotteryTicket", g_GameCommand.LOTTERYTICKET.sCmd);
            }
            else
            {
                g_GameCommand.LOTTERYTICKET.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "LotteryTicket", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "LotteryTicket", g_GameCommand.LOTTERYTICKET.nPermissionMin);
            }
            else
            {
                g_GameCommand.LOTTERYTICKET.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadGuild", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadGuild", g_GameCommand.RELOADGUILD.sCmd);
            }
            else
            {
                g_GameCommand.RELOADGUILD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadGuild", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadGuild", g_GameCommand.RELOADGUILD.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADGUILD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadLineNotice", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadLineNotice", g_GameCommand.RELOADLINENOTICE.sCmd);
            }
            else
            {
                g_GameCommand.RELOADLINENOTICE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadLineNotice", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadLineNotice", g_GameCommand.RELOADLINENOTICE.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADLINENOTICE.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadAbuse", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadAbuse", g_GameCommand.RELOADABUSE.sCmd);
            }
            else
            {
                g_GameCommand.RELOADABUSE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadAbuse", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadAbuse", g_GameCommand.RELOADABUSE.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADABUSE.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "BackStep", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "BackStep", g_GameCommand.BACKSTEP.sCmd);
            }
            else
            {
                g_GameCommand.BACKSTEP.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "BackStep", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "BackStep", g_GameCommand.BACKSTEP.nPermissionMin);
            }
            else
            {
                g_GameCommand.BACKSTEP.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'Ball', ''); //20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Ball', g_GameCommand.BALL.sCmd)
            // else g_GameCommand.BALL.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Ball', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Ball', g_GameCommand.BALL.nPermissionMin)
            // else g_GameCommand.BALL.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "FreePenalty", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "FreePenalty", g_GameCommand.FREEPENALTY.sCmd);
            }
            else
            {
                g_GameCommand.FREEPENALTY.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "FreePenalty", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "FreePenalty", g_GameCommand.FREEPENALTY.nPermissionMin);
            }
            else
            {
                g_GameCommand.FREEPENALTY.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "PkPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "PkPoint", g_GameCommand.PKPOINT.sCmd);
            }
            else
            {
                g_GameCommand.PKPOINT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "PkPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "PkPoint", g_GameCommand.PKPOINT.nPermissionMin);
            }
            else
            {
                g_GameCommand.PKPOINT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "IncPkPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "IncPkPoint", g_GameCommand.IncPkPoint.sCmd);
            }
            else
            {
                g_GameCommand.IncPkPoint.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "IncPkPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "IncPkPoint", g_GameCommand.IncPkPoint.nPermissionMin);
            }
            else
            {
                g_GameCommand.IncPkPoint.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'ChangeLuck', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ChangeLuck', g_GameCommand.CHANGELUCK.sCmd)
            // else g_GameCommand.CHANGELUCK.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ChangeLuck', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ChangeLuck', g_GameCommand.CHANGELUCK.nPermissionMin)
            // else g_GameCommand.CHANGELUCK.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "Hunger", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Hunger", g_GameCommand.HUNGER.sCmd);
            }
            else
            {
                g_GameCommand.HUNGER.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Hunger", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Hunger", g_GameCommand.HUNGER.nPermissionMin);
            }
            else
            {
                g_GameCommand.HUNGER.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Hair", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Hair", g_GameCommand.HAIR.sCmd);
            }
            else
            {
                g_GameCommand.HAIR.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Hair", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Hair", g_GameCommand.HAIR.nPermissionMin);
            }
            else
            {
                g_GameCommand.HAIR.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Training", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Training", g_GameCommand.TRAINING.sCmd);
            }
            else
            {
                g_GameCommand.TRAINING.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Training", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Training", g_GameCommand.TRAINING.nPermissionMin);
            }
            else
            {
                g_GameCommand.TRAINING.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DeleteSkill", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DeleteSkill", g_GameCommand.DELETESKILL.sCmd);
            }
            else
            {
                g_GameCommand.DELETESKILL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DeleteSkill", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DeleteSkill", g_GameCommand.DELETESKILL.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELETESKILL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ChangeJob", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeJob", g_GameCommand.CHANGEJOB.sCmd);
            }
            else
            {
                g_GameCommand.CHANGEJOB.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeJob", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeJob", g_GameCommand.CHANGEJOB.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHANGEJOB.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ChangeGender", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeGender", g_GameCommand.CHANGEGENDER.sCmd);
            }
            else
            {
                g_GameCommand.CHANGEGENDER.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeGender", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeGender", g_GameCommand.CHANGEGENDER.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHANGEGENDER.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'NameColor', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'NameColor', g_GameCommand.NAMECOLOR.sCmd)
            // else g_GameCommand.NAMECOLOR.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'NameColor', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'NameColor', g_GameCommand.NAMECOLOR.nPermissionMin)
            // else g_GameCommand.NAMECOLOR.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "Mission", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Mission", g_GameCommand.Mission.sCmd);
            }
            else
            {
                g_GameCommand.Mission.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Mission", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Mission", g_GameCommand.Mission.nPermissionMin);
            }
            else
            {
                g_GameCommand.Mission.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "MobPlace", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MobPlace", g_GameCommand.MobPlace.sCmd);
            }
            else
            {
                g_GameCommand.MobPlace.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MobPlace", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MobPlace", g_GameCommand.MobPlace.nPermissionMin);
            }
            else
            {
                g_GameCommand.MobPlace.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'Transparecy', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Transparecy', g_GameCommand.TRANSPARECY.sCmd)
            // else g_GameCommand.TRANSPARECY.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Transparecy', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Transparecy', g_GameCommand.TRANSPARECY.nPermissionMin)
            // else g_GameCommand.TRANSPARECY.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "DeleteItem", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DeleteItem", g_GameCommand.DELETEITEM.sCmd);
            }
            else
            {
                g_GameCommand.DELETEITEM.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DeleteItem", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DeleteItem", g_GameCommand.DELETEITEM.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELETEITEM.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'Level0', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Level0', g_GameCommand.LEVEL0.sCmd)
            // else g_GameCommand.LEVEL0.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Level0', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Level0', g_GameCommand.LEVEL0.nPermissionMin)
            // else g_GameCommand.LEVEL0.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "ClearMission", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ClearMission", g_GameCommand.CLEARMISSION.sCmd);
            }
            else
            {
                g_GameCommand.CLEARMISSION.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ClearMission", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ClearMission", g_GameCommand.CLEARMISSION.nPermissionMin);
            }
            else
            {
                g_GameCommand.CLEARMISSION.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SetFlag", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SetFlag", g_GameCommand.SETFLAG.sCmd);
            }
            else
            {
                g_GameCommand.SETFLAG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SetFlag", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SetFlag", g_GameCommand.SETFLAG.nPermissionMin);
            }
            else
            {
                g_GameCommand.SETFLAG.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'SetOpen', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'SetOpen', g_GameCommand.SETOPEN.sCmd)
            // else g_GameCommand.SETOPEN.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'SetOpen', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'SetOpen', g_GameCommand.SETOPEN.nPermissionMin)
            // else g_GameCommand.SETOPEN.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'SetUnit', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'SetUnit', g_GameCommand.SETUNIT.sCmd)
            // else g_GameCommand.SETUNIT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'SetUnit', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'SetUnit', g_GameCommand.SETUNIT.nPermissionMin)
            // else g_GameCommand.SETUNIT.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "ReConnection", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReConnection", g_GameCommand.RECONNECTION.sCmd);
            }
            else
            {
                g_GameCommand.RECONNECTION.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReConnection", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReConnection", g_GameCommand.RECONNECTION.nPermissionMin);
            }
            else
            {
                g_GameCommand.RECONNECTION.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DisableFilter", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DisableFilter", g_GameCommand.DISABLEFILTER.sCmd);
            }
            else
            {
                g_GameCommand.DISABLEFILTER.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DisableFilter", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DisableFilter", g_GameCommand.DISABLEFILTER.nPermissionMin);
            }
            else
            {
                g_GameCommand.DISABLEFILTER.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ChangeUserFull", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeUserFull", g_GameCommand.CHGUSERFULL.sCmd);
            }
            else
            {
                g_GameCommand.CHGUSERFULL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeUserFull", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeUserFull", g_GameCommand.CHGUSERFULL.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHGUSERFULL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ChangeZenFastStep", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeZenFastStep", g_GameCommand.CHGZENFASTSTEP.sCmd);
            }
            else
            {
                g_GameCommand.CHGZENFASTSTEP.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeZenFastStep", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeZenFastStep", g_GameCommand.CHGZENFASTSTEP.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHGZENFASTSTEP.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ContestPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ContestPoint", g_GameCommand.CONTESTPOINT.sCmd);
            }
            else
            {
                g_GameCommand.CONTESTPOINT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ContestPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ContestPoint", g_GameCommand.CONTESTPOINT.nPermissionMin);
            }
            else
            {
                g_GameCommand.CONTESTPOINT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "StartContest", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StartContest", g_GameCommand.STARTCONTEST.sCmd);
            }
            else
            {
                g_GameCommand.STARTCONTEST.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "StartContest", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "StartContest", g_GameCommand.STARTCONTEST.nPermissionMin);
            }
            else
            {
                g_GameCommand.STARTCONTEST.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "EndContest", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "EndContest", g_GameCommand.ENDCONTEST.sCmd);
            }
            else
            {
                g_GameCommand.ENDCONTEST.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "EndContest", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "EndContest", g_GameCommand.ENDCONTEST.nPermissionMin);
            }
            else
            {
                g_GameCommand.ENDCONTEST.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Announcement", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Announcement", g_GameCommand.ANNOUNCEMENT.sCmd);
            }
            else
            {
                g_GameCommand.ANNOUNCEMENT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Announcement", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Announcement", g_GameCommand.ANNOUNCEMENT.nPermissionMin);
            }
            else
            {
                g_GameCommand.ANNOUNCEMENT.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'OXQuizRoom', ''); //20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'OXQuizRoom', g_GameCommand.OXQUIZROOM.sCmd)
            // else g_GameCommand.OXQUIZROOM.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'OXQuizRoom', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'OXQuizRoom', g_GameCommand.OXQUIZROOM.nPermissionMin)
            // else g_GameCommand.OXQUIZROOM.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'Gsa', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'Gsa', g_GameCommand.GSA.sCmd)
            // else g_GameCommand.GSA.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'Gsa', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'Gsa', g_GameCommand.GSA.nPermissionMin)
            // else g_GameCommand.GSA.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "ChangeItemName", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeItemName", g_GameCommand.CHANGEITEMNAME.sCmd);
            }
            else
            {
                g_GameCommand.CHANGEITEMNAME.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeItemName", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeItemName", g_GameCommand.CHANGEITEMNAME.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHANGEITEMNAME.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DisableSendMsg", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DisableSendMsg", g_GameCommand.DISABLESENDMSG.sCmd);
            }
            else
            {
                g_GameCommand.DISABLESENDMSG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DisableSendMsg", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DisableSendMsg", g_GameCommand.DISABLESENDMSG.nPermissionMin);
            }
            else
            {
                g_GameCommand.DISABLESENDMSG.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "EnableSendMsg", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "EnableSendMsg", g_GameCommand.ENABLESENDMSG.sCmd);
            }
            else
            {
                g_GameCommand.ENABLESENDMSG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "EnableSendMsg", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "EnableSendMsg", g_GameCommand.ENABLESENDMSG.nPermissionMin);
            }
            else
            {
                g_GameCommand.ENABLESENDMSG.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DisableSendMsgList", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DisableSendMsgList", g_GameCommand.DISABLESENDMSGLIST.sCmd);
            }
            else
            {
                g_GameCommand.DISABLESENDMSGLIST.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DisableSendMsgList", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DisableSendMsgList", g_GameCommand.DISABLESENDMSGLIST.nPermissionMin);
            }
            else
            {
                g_GameCommand.DISABLESENDMSGLIST.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Kill", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Kill", g_GameCommand.KILL.sCmd);
            }
            else
            {
                g_GameCommand.KILL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Kill", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Kill", g_GameCommand.KILL.nPermissionMin);
            }
            else
            {
                g_GameCommand.KILL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Make", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Make", g_GameCommand.MAKE.sCmd);
            }
            else
            {
                g_GameCommand.MAKE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MakeMin", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MakeMin", g_GameCommand.MAKE.nPermissionMin);
            }
            else
            {
                g_GameCommand.MAKE.nPermissionMin = nLoadInteger;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MakeMax", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MakeMax", g_GameCommand.MAKE.nPermissionMax);
            }
            else
            {
                g_GameCommand.MAKE.nPermissionMax = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SuperMake", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SuperMake", g_GameCommand.SMAKE.sCmd);
            }
            else
            {
                g_GameCommand.SMAKE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SuperMake", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SuperMake", g_GameCommand.SMAKE.nPermissionMin);
            }
            else
            {
                g_GameCommand.SMAKE.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "BonusPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "BonusPoint", g_GameCommand.BonusPoint.sCmd);
            }
            else
            {
                g_GameCommand.BonusPoint.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "BonusPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "BonusPoint", g_GameCommand.BonusPoint.nPermissionMin);
            }
            else
            {
                g_GameCommand.BonusPoint.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelBonuPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelBonuPoint", g_GameCommand.DELBONUSPOINT.sCmd);
            }
            else
            {
                g_GameCommand.DELBONUSPOINT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelBonuPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelBonuPoint", g_GameCommand.DELBONUSPOINT.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELBONUSPOINT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "RestBonuPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "RestBonuPoint", g_GameCommand.RESTBONUSPOINT.sCmd);
            }
            else
            {
                g_GameCommand.RESTBONUSPOINT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "RestBonuPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "RestBonuPoint", g_GameCommand.RESTBONUSPOINT.nPermissionMin);
            }
            else
            {
                g_GameCommand.RESTBONUSPOINT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "FireBurn", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "FireBurn", g_GameCommand.FIREBURN.sCmd);
            }
            else
            {
                g_GameCommand.FIREBURN.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "FireBurn", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "FireBurn", g_GameCommand.FIREBURN.nPermissionMin);
            }
            else
            {
                g_GameCommand.FIREBURN.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "TestStatus", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "TestStatus", g_GameCommand.TESTSTATUS.sCmd);
            }
            else
            {
                g_GameCommand.TESTSTATUS.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "TestStatus", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "TestStatus", g_GameCommand.TESTSTATUS.nPermissionMin);
            }
            else
            {
                g_GameCommand.TESTSTATUS.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelGold", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelGold", g_GameCommand.DELGOLD.sCmd);
            }
            else
            {
                g_GameCommand.DELGOLD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelGold", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelGold", g_GameCommand.DELGOLD.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELGOLD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "AddGold", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AddGold", g_GameCommand.ADDGOLD.sCmd);
            }
            else
            {
                g_GameCommand.ADDGOLD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AddGold", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AddGold", g_GameCommand.ADDGOLD.nPermissionMin);
            }
            else
            {
                g_GameCommand.ADDGOLD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelGameGold", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelGameGold", g_GameCommand.DELGAMEGOLD.sCmd);
            }
            else
            {
                g_GameCommand.DELGAMEGOLD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelGameGold", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelGameGold", g_GameCommand.DELGAMEGOLD.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELGAMEGOLD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "AddGamePoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AddGamePoint", g_GameCommand.ADDGAMEGOLD.sCmd);
            }
            else
            {
                g_GameCommand.ADDGAMEGOLD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AddGameGold", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AddGameGold", g_GameCommand.ADDGAMEGOLD.nPermissionMin);
            }
            else
            {
                g_GameCommand.ADDGAMEGOLD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "GameGold", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GameGold", g_GameCommand.GAMEGOLD.sCmd);
            }
            else
            {
                g_GameCommand.GAMEGOLD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "GameGold", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "GameGold", g_GameCommand.GAMEGOLD.nPermissionMin);
            }
            else
            {
                g_GameCommand.GAMEGOLD.nPermissionMin = nLoadInteger;
            }
            // 20071226 add
            LoadString = CommandConf.ReadString("Command", "GAMEDIAMOND", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GAMEDIAMOND", g_GameCommand.GAMEDIAMOND.sCmd);
            }
            else
            {
                g_GameCommand.GAMEDIAMOND.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "GAMEDIAMOND", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "GAMEDIAMOND", g_GameCommand.GAMEDIAMOND.nPermissionMin);
            }
            else
            {
                g_GameCommand.GAMEDIAMOND.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "GAMEGIRD", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GAMEGIRD", g_GameCommand.GAMEGIRD.sCmd);
            }
            else
            {
                g_GameCommand.GAMEGIRD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "GAMEGIRD", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "GAMEGIRD", g_GameCommand.GAMEGIRD.nPermissionMin);
            }
            else
            {
                g_GameCommand.GAMEGIRD.nPermissionMin = nLoadInteger;
            }
            // 20071226 end
            // ------------------------------------------------------------------------------
            // 调整人物的荣誉值 20080511
            LoadString = CommandConf.ReadString("Command", "GAMEGLORY", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GAMEGLORY", g_GameCommand.GAMEGLORY.sCmd);
            }
            else
            {
                g_GameCommand.GAMEGLORY.sCmd = LoadString;
            }
            // ------------------------------------------------------------------------------
            // 调整英雄的忠诚度 20080109
            LoadString = CommandConf.ReadString("Command", "HEROLOYAL", "");
            if (LoadString == "")
            {
                // g_GameCommand.HEROLOYAL.sCmd
                CommandConf.WriteString("Command", "HEROLOYAL", "改变忠诚");
            }
            else
            {
                g_GameCommand.HEROLOYAL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "HEROLOYAL", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "HEROLOYAL", g_GameCommand.HEROLOYAL.nPermissionMin);
            }
            else
            {
                g_GameCommand.HEROLOYAL.nPermissionMin = nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            LoadString = CommandConf.ReadString("Command", "GamePoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GamePoint", g_GameCommand.GAMEPOINT.sCmd);
            }
            else
            {
                g_GameCommand.GAMEPOINT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "GamePoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "GamePoint", g_GameCommand.GAMEPOINT.nPermissionMin);
            }
            else
            {
                g_GameCommand.GAMEPOINT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "CreditPoint", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "CreditPoint", g_GameCommand.CREDITPOINT.sCmd);
            }
            else
            {
                g_GameCommand.CREDITPOINT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "CreditPoint", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "CreditPoint", g_GameCommand.CREDITPOINT.nPermissionMin);
            }
            else
            {
                g_GameCommand.CREDITPOINT.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'TestGoldChange', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'TestGoldChange', g_GameCommand.TESTGOLDCHANGE.sCmd)
            // else g_GameCommand.TESTGOLDCHANGE.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'TestGoldChange', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'TestGoldChange', g_GameCommand.TESTGOLDCHANGE.nPermissionMin)
            // else g_GameCommand.TESTGOLDCHANGE.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "RefineWeapon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "RefineWeapon", g_GameCommand.REFINEWEAPON.sCmd);
            }
            else
            {
                g_GameCommand.REFINEWEAPON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "RefineWeapon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "RefineWeapon", g_GameCommand.REFINEWEAPON.nPermissionMin);
            }
            else
            {
                g_GameCommand.REFINEWEAPON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadAdmin", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadAdmin", g_GameCommand.RELOADADMIN.sCmd);
            }
            else
            {
                g_GameCommand.RELOADADMIN.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadAdmin", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadAdmin", g_GameCommand.RELOADADMIN.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADADMIN.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadNpc", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadNpc", g_GameCommand.ReLoadNpc.sCmd);
            }
            else
            {
                g_GameCommand.ReLoadNpc.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadNpc", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadNpc", g_GameCommand.ReLoadNpc.nPermissionMin);
            }
            else
            {
                g_GameCommand.ReLoadNpc.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadManage", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadManage", g_GameCommand.RELOADMANAGE.sCmd);
            }
            else
            {
                g_GameCommand.RELOADMANAGE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadManage", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadManage", g_GameCommand.RELOADMANAGE.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADMANAGE.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadRobotManage", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadRobotManage", g_GameCommand.RELOADROBOTMANAGE.sCmd);
            }
            else
            {
                g_GameCommand.RELOADROBOTMANAGE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadRobotManage", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadRobotManage", g_GameCommand.RELOADROBOTMANAGE.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADROBOTMANAGE.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadRobot", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadRobot", g_GameCommand.RELOADROBOT.sCmd);
            }
            else
            {
                g_GameCommand.RELOADROBOT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadRobot", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadRobot", g_GameCommand.RELOADROBOT.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADROBOT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadMonitems", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadMonitems", g_GameCommand.RELOADMONITEMS.sCmd);
            }
            else
            {
                g_GameCommand.RELOADMONITEMS.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadMonitems", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadMonitems", g_GameCommand.RELOADMONITEMS.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADMONITEMS.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadItemDB", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadItemDB", g_GameCommand.RELOADITEMDB.sCmd);
            }
            else
            {
                g_GameCommand.RELOADITEMDB.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadItemDB", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadItemDB", g_GameCommand.RELOADITEMDB.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADITEMDB.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadMagicDB", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadMagicDB", g_GameCommand.RELOADMAGICDB.sCmd);
            }
            else
            {
                g_GameCommand.RELOADMAGICDB.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadMagicDB", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadMagicDB", g_GameCommand.RELOADMAGICDB.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADMAGICDB.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReloadMonsterDB", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReloadMonsterDB", g_GameCommand.RELOADMONSTERDB.sCmd);
            }
            else
            {
                g_GameCommand.RELOADMONSTERDB.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReloadMonsterDB", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReloadMonsterDB", g_GameCommand.RELOADMONSTERDB.nPermissionMin);
            }
            else
            {
                g_GameCommand.RELOADMONSTERDB.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReAlive", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReAlive", g_GameCommand.ReAlive.sCmd);
            }
            else
            {
                g_GameCommand.ReAlive.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReAlive", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReAlive", g_GameCommand.ReAlive.nPermissionMin);
            }
            else
            {
                g_GameCommand.ReAlive.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SysMsg", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SysMsg", "传");
            }
            else
            {
                g_GameCommand.SysMsg.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SysMsg", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SysMsg", g_GameCommand.SysMsg.nPermissionMin);
            }
            else
            {
                g_GameCommand.SysMsg.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "HEROLEVEL", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "HEROLEVEL", g_GameCommand.HEROLEVEL.sCmd);
            }
            else
            {
                g_GameCommand.HEROLEVEL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "HEROLEVEL", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "HEROLEVEL", g_GameCommand.HEROLEVEL.nPermissionMin);
            }
            else
            {
                g_GameCommand.HEROLEVEL.nPermissionMin = nLoadInteger;
            }
            // 调整英雄等级 20071227 end
            LoadString = CommandConf.ReadString("Command", "AdjuestTLevel", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AdjuestTLevel", g_GameCommand.ADJUESTLEVEL.sCmd);
            }
            else
            {
                g_GameCommand.ADJUESTLEVEL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AdjuestTLevel", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AdjuestTLevel", g_GameCommand.ADJUESTLEVEL.nPermissionMin);
            }
            else
            {
                g_GameCommand.ADJUESTLEVEL.nPermissionMin = nLoadInteger;
            }
            // 调整人物内功等级 20081221
            LoadString = CommandConf.ReadString("Command", "NGLevel", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "NGLEVEL", g_GameCommand.NGLEVEL.sCmd);
            }
            else
            {
                g_GameCommand.NGLEVEL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "NGLEVEL", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "NGLEVEL", g_GameCommand.NGLEVEL.nPermissionMin);
            }
            else
            {
                g_GameCommand.NGLEVEL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "AdjuestExp", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AdjuestExp", g_GameCommand.ADJUESTEXP.sCmd);
            }
            else
            {
                g_GameCommand.ADJUESTEXP.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AdjuestExp", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AdjuestExp", g_GameCommand.ADJUESTEXP.nPermissionMin);
            }
            else
            {
                g_GameCommand.ADJUESTEXP.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "AddGuild", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AddGuild", g_GameCommand.AddGuild.sCmd);
            }
            else
            {
                g_GameCommand.AddGuild.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AddGuild", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AddGuild", g_GameCommand.AddGuild.nPermissionMin);
            }
            else
            {
                g_GameCommand.AddGuild.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelGuild", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelGuild", g_GameCommand.DELGUILD.sCmd);
            }
            else
            {
                g_GameCommand.DELGUILD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelGuild", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelGuild", g_GameCommand.DELGUILD.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELGUILD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ChangeSabukLord", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeSabukLord", g_GameCommand.CHANGESABUKLORD.sCmd);
            }
            else
            {
                g_GameCommand.CHANGESABUKLORD.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeSabukLord", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeSabukLord", g_GameCommand.CHANGESABUKLORD.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHANGESABUKLORD.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ForcedWallConQuestWar", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ForcedWallConQuestWar", g_GameCommand.FORCEDWALLCONQUESTWAR.sCmd);
            }
            else
            {
                g_GameCommand.FORCEDWALLCONQUESTWAR.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ForcedWallConQuestWar", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ForcedWallConQuestWar", g_GameCommand.FORCEDWALLCONQUESTWAR.nPermissionMin);
            }
            else
            {
                g_GameCommand.FORCEDWALLCONQUESTWAR.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'AddToItemEvent', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'AddToItemEvent', g_GameCommand.ADDTOITEMEVENT.sCmd)
            // else g_GameCommand.ADDTOITEMEVENT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'AddToItemEvent', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'AddToItemEvent', g_GameCommand.ADDTOITEMEVENT.nPermissionMin)
            // else g_GameCommand.ADDTOITEMEVENT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'AddToItemEventAspieces', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'AddToItemEventAspieces', g_GameCommand.ADDTOITEMEVENTASPIECES.sCmd)
            // else g_GameCommand.ADDTOITEMEVENTASPIECES.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'AddToItemEventAspieces', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'AddToItemEventAspieces', g_GameCommand.ADDTOITEMEVENTASPIECES.nPermissionMin)
            // else g_GameCommand.ADDTOITEMEVENTASPIECES.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ItemEventList', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ItemEventList', g_GameCommand.ItemEventList.sCmd)
            // else g_GameCommand.ItemEventList.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ItemEventList', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ItemEventList', g_GameCommand.ItemEventList.nPermissionMin)
            // else g_GameCommand.ItemEventList.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'StartIngGiftNO', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'StartIngGiftNO', g_GameCommand.STARTINGGIFTNO.sCmd)
            // else g_GameCommand.STARTINGGIFTNO.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'StartIngGiftNO', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'StartIngGiftNO', g_GameCommand.STARTINGGIFTNO.nPermissionMin)
            // else g_GameCommand.STARTINGGIFTNO.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'DeleteAllItemEvent', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'DeleteAllItemEvent', g_GameCommand.DELETEALLITEMEVENT.sCmd)
            // else g_GameCommand.DELETEALLITEMEVENT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'DeleteAllItemEvent', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'DeleteAllItemEvent', g_GameCommand.DELETEALLITEMEVENT.nPermissionMin)
            // else g_GameCommand.DELETEALLITEMEVENT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'StartItemEvent', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'StartItemEvent', g_GameCommand.STARTITEMEVENT.sCmd)
            // else g_GameCommand.STARTITEMEVENT.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'StartItemEvent', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'StartItemEvent', g_GameCommand.STARTITEMEVENT.nPermissionMin)
            // else g_GameCommand.STARTITEMEVENT.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ItemEventTerm', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ItemEventTerm', g_GameCommand.ITEMEVENTTERM.sCmd)
            // else g_GameCommand.ITEMEVENTTERM.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ItemEventTerm', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ItemEventTerm', g_GameCommand.ITEMEVENTTERM.nPermissionMin)
            // else g_GameCommand.ITEMEVENTTERM.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "AdjuestTestLevel", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AdjuestTestLevel", g_GameCommand.ADJUESTTESTLEVEL.sCmd);
            }
            else
            {
                g_GameCommand.ADJUESTTESTLEVEL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AdjuestTestLevel", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AdjuestTestLevel", g_GameCommand.ADJUESTTESTLEVEL.nPermissionMin);
            }
            else
            {
                g_GameCommand.ADJUESTTESTLEVEL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "OpTraining", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "OpTraining", g_GameCommand.TRAININGSKILL.sCmd);
            }
            else
            {
                g_GameCommand.TRAININGSKILL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "OpTraining", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "OpTraining", g_GameCommand.TRAININGSKILL.nPermissionMin);
            }
            else
            {
                g_GameCommand.TRAININGSKILL.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'OpDeleteSkill', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'OpDeleteSkill', g_GameCommand.OPDELETESKILL.sCmd)
            // else g_GameCommand.OPDELETESKILL.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'OpDeleteSkill', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'OpDeleteSkill', g_GameCommand.OPDELETESKILL.nPermissionMin)
            // else g_GameCommand.OPDELETESKILL.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ChangeWeaponDura', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ChangeWeaponDura', g_GameCommand.CHANGEWEAPONDURA.sCmd)
            // else g_GameCommand.CHANGEWEAPONDURA.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ChangeWeaponDura', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ChangeWeaponDura', g_GameCommand.CHANGEWEAPONDURA.nPermissionMin)
            // else g_GameCommand.CHANGEWEAPONDURA.nPermissionMin := nLoadInteger;
            // 
            // LoadString := CommandConf.ReadString('Command', 'ReloadGuildAll', '');
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'ReloadGuildAll', g_GameCommand.RELOADGUILDALL.sCmd)
            // else g_GameCommand.RELOADGUILDALL.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'ReloadGuildAll', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'ReloadGuildAll', g_GameCommand.RELOADGUILDALL.nPermissionMin)
            // else g_GameCommand.RELOADGUILDALL.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "Who", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Who", g_GameCommand.WHO.sCmd);
            }
            else
            {
                g_GameCommand.WHO.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Who", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Who", g_GameCommand.WHO.nPermissionMin);
            }
            else
            {
                g_GameCommand.WHO.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "Total", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "Total", g_GameCommand.TOTAL.sCmd);
            }
            else
            {
                g_GameCommand.TOTAL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "Total", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "Total", g_GameCommand.TOTAL.nPermissionMin);
            }
            else
            {
                g_GameCommand.TOTAL.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'TestGa', '');//20081014 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'TestGa', g_GameCommand.TESTGA.sCmd)
            // else g_GameCommand.TESTGA.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'TestGa', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'TestGa', g_GameCommand.TESTGA.nPermissionMin)
            // else g_GameCommand.TESTGA.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "MapInfo", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "MapInfo", g_GameCommand.MAPINFO.sCmd);
            }
            else
            {
                g_GameCommand.MAPINFO.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "MapInfo", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "MapInfo", g_GameCommand.MAPINFO.nPermissionMin);
            }
            else
            {
                g_GameCommand.MAPINFO.nPermissionMin = nLoadInteger;
            }
            // LoadString := CommandConf.ReadString('Command', 'SbkDoor', '');//20080812 注释
            // if LoadString = '' then
            // CommandConf.WriteString('Command', 'SbkDoor', g_GameCommand.SBKDOOR.sCmd)
            // else g_GameCommand.SBKDOOR.sCmd := LoadString;
            // nLoadInteger := CommandConf.ReadInteger('Permission', 'SbkDoor', -1);
            // if nLoadInteger < 0 then
            // CommandConf.WriteInteger('Permission', 'SbkDoor', g_GameCommand.SBKDOOR.nPermissionMin)
            // else g_GameCommand.SBKDOOR.nPermissionMin := nLoadInteger;
            LoadString = CommandConf.ReadString("Command", "ChangeDearName", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeDearName", g_GameCommand.CHANGEDEARNAME.sCmd);
            }
            else
            {
                g_GameCommand.CHANGEDEARNAME.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeDearName", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeDearName", g_GameCommand.CHANGEDEARNAME.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHANGEDEARNAME.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ChangeMasterName", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ChangeMasterrName", g_GameCommand.CHANGEMASTERNAME.sCmd);
            }
            else
            {
                g_GameCommand.CHANGEMASTERNAME.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ChangeMasterName", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ChangeMasterName", g_GameCommand.CHANGEMASTERNAME.nPermissionMin);
            }
            else
            {
                g_GameCommand.CHANGEMASTERNAME.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "StartQuest", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "StartQuest", g_GameCommand.STARTQUEST.sCmd);
            }
            else
            {
                g_GameCommand.STARTQUEST.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "StartQuest", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "StartQuest", g_GameCommand.STARTQUEST.nPermissionMin);
            }
            else
            {
                g_GameCommand.STARTQUEST.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SetPermission", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SetPermission", g_GameCommand.SETPERMISSION.sCmd);
            }
            else
            {
                g_GameCommand.SETPERMISSION.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SetPermission", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SetPermission", g_GameCommand.SETPERMISSION.nPermissionMin);
            }
            else
            {
                g_GameCommand.SETPERMISSION.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ClearMon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ClearMon", g_GameCommand.CLEARMON.sCmd);
            }
            else
            {
                g_GameCommand.CLEARMON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ClearMon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ClearMon", g_GameCommand.CLEARMON.nPermissionMin);
            }
            else
            {
                g_GameCommand.CLEARMON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ReNewLevel", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ReNewLevel", g_GameCommand.RENEWLEVEL.sCmd);
            }
            else
            {
                g_GameCommand.RENEWLEVEL.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ReNewLevel", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ReNewLevel", g_GameCommand.RENEWLEVEL.nPermissionMin);
            }
            else
            {
                g_GameCommand.RENEWLEVEL.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DenyIPaddrLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DenyIPaddrLogon", g_GameCommand.DENYIPLOGON.sCmd);
            }
            else
            {
                g_GameCommand.DENYIPLOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DenyIPaddrLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DenyIPaddrLogon", g_GameCommand.DENYIPLOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.DENYIPLOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DenyAccountLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DenyAccountLogon", g_GameCommand.DENYACCOUNTLOGON.sCmd);
            }
            else
            {
                g_GameCommand.DENYACCOUNTLOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DenyAccountLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DenyAccountLogon", g_GameCommand.DENYACCOUNTLOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.DENYACCOUNTLOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DenyCharNameLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DenyCharNameLogon", g_GameCommand.DENYCHARNAMELOGON.sCmd);
            }
            else
            {
                g_GameCommand.DENYCHARNAMELOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DenyCharNameLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DenyCharNameLogon", g_GameCommand.DENYCHARNAMELOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.DENYCHARNAMELOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelDenyIPLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelDenyIPLogon", g_GameCommand.DELDENYIPLOGON.sCmd);
            }
            else
            {
                g_GameCommand.DELDENYIPLOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelDenyIPLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelDenyIPLogon", g_GameCommand.DELDENYIPLOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELDENYIPLOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelDenyAccountLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelDenyAccountLogon", g_GameCommand.DELDENYACCOUNTLOGON.sCmd);
            }
            else
            {
                g_GameCommand.DELDENYACCOUNTLOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelDenyAccountLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelDenyAccountLogon", g_GameCommand.DELDENYACCOUNTLOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELDENYACCOUNTLOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "DelDenyCharNameLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "DelDenyCharNameLogon", g_GameCommand.DELDENYCHARNAMELOGON.sCmd);
            }
            else
            {
                g_GameCommand.DELDENYCHARNAMELOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "DelDenyCharNameLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "DelDenyCharNameLogon", g_GameCommand.DELDENYCHARNAMELOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.DELDENYCHARNAMELOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ShowDenyIPLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ShowDenyIPLogon", g_GameCommand.SHOWDENYIPLOGON.sCmd);
            }
            else
            {
                g_GameCommand.SHOWDENYIPLOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ShowDenyIPLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ShowDenyIPLogon", g_GameCommand.SHOWDENYIPLOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHOWDENYIPLOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ShowDenyAccountLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ShowDenyAccountLogon", g_GameCommand.SHOWDENYACCOUNTLOGON.sCmd);
            }
            else
            {
                g_GameCommand.SHOWDENYACCOUNTLOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ShowDenyAccountLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ShowDenyAccountLogon", g_GameCommand.SHOWDENYACCOUNTLOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHOWDENYACCOUNTLOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ShowDenyCharNameLogon", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ShowDenyCharNameLogon", g_GameCommand.SHOWDENYCHARNAMELOGON.sCmd);
            }
            else
            {
                g_GameCommand.SHOWDENYCHARNAMELOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ShowDenyCharNameLogon", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ShowDenyCharNameLogon", g_GameCommand.SHOWDENYCHARNAMELOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHOWDENYCHARNAMELOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ViewWhisper", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ViewWhisper", g_GameCommand.VIEWWHISPER.sCmd);
            }
            else
            {
                g_GameCommand.VIEWWHISPER.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ViewWhisper", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ViewWhisper", g_GameCommand.VIEWWHISPER.nPermissionMin);
            }
            else
            {
                g_GameCommand.VIEWWHISPER.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SpiritStart", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SpiritStart", g_GameCommand.SPIRIT.sCmd);
            }
            else
            {
                g_GameCommand.SPIRIT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SpiritStart", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SpiritStart", g_GameCommand.SPIRIT.nPermissionMin);
            }
            else
            {
                g_GameCommand.SPIRIT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SpiritStop", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SpiritStop", g_GameCommand.SPIRITSTOP.sCmd);
            }
            else
            {
                g_GameCommand.SPIRITSTOP.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SpiritStop", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SpiritStop", g_GameCommand.SPIRITSTOP.nPermissionMin);
            }
            else
            {
                g_GameCommand.SPIRITSTOP.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SetMapMode", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SetMapMode", g_GameCommand.SetMapMode.sCmd);
            }
            else
            {
                g_GameCommand.SetMapMode.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SetMapMode", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SetMapMode", g_GameCommand.SetMapMode.nPermissionMin);
            }
            else
            {
                g_GameCommand.SetMapMode.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ShoweMapMode", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ShoweMapMode", g_GameCommand.SHOWMAPMODE.sCmd);
            }
            else
            {
                g_GameCommand.SHOWMAPMODE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ShoweMapMode", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ShoweMapMode", g_GameCommand.SHOWMAPMODE.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHOWMAPMODE.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ClearBag", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ClearBag", g_GameCommand.CLEARBAG.sCmd);
            }
            else
            {
                g_GameCommand.CLEARBAG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ClearBag", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ClearBag", g_GameCommand.CLEARBAG.nPermissionMin);
            }
            else
            {
                g_GameCommand.CLEARBAG.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "RemoteMsg", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "RemoteMsg", g_GameCommand.REMTEMSG.sCmd);
            }
            else
            {
                g_GameCommand.REMTEMSG.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "RemoteMsg", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "RemoteMsg", g_GameCommand.REMTEMSG.nPermissionMin);
            }
            else
            {
                g_GameCommand.REMTEMSG.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "ColorSay", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "ColorSay", g_GameCommand.COLORSAY.sCmd);
            }
            else
            {
                g_GameCommand.COLORSAY.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "ColorSay", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "ColorSay", g_GameCommand.COLORSAY.nPermissionMin);
            }
            else
            {
                g_GameCommand.COLORSAY.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SETCOLORSAY", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SETCOLORSAY", g_GameCommand.SETCOLORSAY.sCmd);
            }
            else
            {
                g_GameCommand.SETCOLORSAY.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SETCOLORSAY", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SETCOLORSAY", g_GameCommand.SETCOLORSAY.nPermissionMin);
            }
            else
            {
                g_GameCommand.SETCOLORSAY.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "AllowRebirth", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "AllowReAlive", g_GameCommand.AllowReAlive.sCmd);
            }
            else
            {
                g_GameCommand.AllowReAlive.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "AllowReAlive", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "AllowReAlive", g_GameCommand.AllowReAlive.nPermissionMin);
            }
            else
            {
                g_GameCommand.AllowReAlive.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "USERITEM", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "USERITEM", g_GameCommand.UserItem.sCmd);
            }
            else
            {
                g_GameCommand.UserItem.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "USERITEM", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "USERITEM", g_GameCommand.UserItem.nPermissionMin);
            }
            else
            {
                g_GameCommand.UserItem.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SIGNMOVE", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SIGNMOVE", g_GameCommand.SIGNMOVE.sCmd);
            }
            else
            {
                g_GameCommand.SIGNMOVE.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SIGNMOVE", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SIGNMOVE", g_GameCommand.SIGNMOVE.nPermissionMin);
            }
            else
            {
                g_GameCommand.SIGNMOVE.nPermissionMin = nLoadInteger;
            }
            // 20080816 清理指定玩家复制品
            LoadString = CommandConf.ReadString("Command", "CLEARCOPYITEM", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "CLEARCOPYITEM", g_GameCommand.CLEARCOPYITEM.sCmd);
            }
            else
            {
                g_GameCommand.CLEARCOPYITEM.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "CLEARCOPYITEM", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "CLEARCOPYITEM", g_GameCommand.CLEARCOPYITEM.nPermissionMin);
            }
            else
            {
                g_GameCommand.CLEARCOPYITEM.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "SHOWEFFECT", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "SHOWEFFECT", g_GameCommand.SHOWEFFECT.sCmd);
            }
            else
            {
                g_GameCommand.SHOWEFFECT.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "SHOWEFFECT", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "SHOWEFFECT", g_GameCommand.SHOWEFFECT.nPermissionMin);
            }
            else
            {
                g_GameCommand.SHOWEFFECT.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "LockLogin", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "LockLogin", g_GameCommand.LOCKLOGON.sCmd);
            }
            else
            {
                g_GameCommand.LOCKLOGON.sCmd = LoadString;
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "LockLogin", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "LockLogin", g_GameCommand.LOCKLOGON.nPermissionMin);
            }
            else
            {
                g_GameCommand.LOCKLOGON.nPermissionMin = nLoadInteger;
            }
            LoadString = CommandConf.ReadString("Command", "GMRedMsgCmd", "");
            if (LoadString == "")
            {
                CommandConf.WriteString("Command", "GMRedMsgCmd", g_GMRedMsgCmd.ToString());
            }
            else
            {
                g_GMRedMsgCmd = LoadString[0];
            }
            nLoadInteger = CommandConf.ReadInteger("Permission", "GMRedMsgCmd", -1);
            if (nLoadInteger < 0)
            {
                CommandConf.WriteInteger("Permission", "GMRedMsgCmd", g_nGMREDMSGCMD);
            }
            else
            {
                g_nGMREDMSGCMD = nLoadInteger;
            }
        }
        
        public static string LoadString_LoadConfigString(string sSection, string sIdent, string sDefault)
        {
            string result;
            string sString;
            sString = StringConf.ReadString(sSection, sIdent, "");
            if (sString == "")
            {
                StringConf.WriteString(sSection, sIdent, sDefault);
                result = sDefault;
            }
            else
            {
                result = sString;
            }
            return result;
        }
        /// <summary>
        /// 加载游戏文字提示信息
        /// </summary>
        public static void LoadString()
        {
            string LoadString;
            LoadString = StringConf.ReadString("String", "ClientSoftVersionError", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ClientSoftVersionError", GameMsgDef.sClientSoftVersionError);
            }
            else
            {
                GameMsgDef.sClientSoftVersionError = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DownLoadNewClientSoft", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DownLoadNewClientSoft", GameMsgDef.sDownLoadNewClientSoft);
            }
            else
            {
                GameMsgDef.sDownLoadNewClientSoft = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ForceDisConnect", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ForceDisConnect", GameMsgDef.sForceDisConnect);
            }
            else
            {
                GameMsgDef.sForceDisConnect = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ClientSoftVersionTooOld", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ClientSoftVersionTooOld", GameMsgDef.sClientSoftVersionTooOld);
            }
            else
            {
                GameMsgDef.sClientSoftVersionTooOld = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DownLoadAndUseNewClient", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DownLoadAndUseNewClient", GameMsgDef.sDownLoadAndUseNewClient);
            }
            else
            {
                GameMsgDef.sDownLoadAndUseNewClient = LoadString;
            }
            LoadString = StringConf.ReadString("String", "OnlineUserFull", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "OnlineUserFull", GameMsgDef.sOnlineUserFull);
            }
            else
            {
                GameMsgDef.sOnlineUserFull = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouNowIsTryPlayMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouNowIsTryPlayMode", GameMsgDef.sYouNowIsTryPlayMode);
            }
            else
            {
                GameMsgDef.sYouNowIsTryPlayMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NowIsFreePlayMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NowIsFreePlayMode", GameMsgDef.g_sNowIsFreePlayMode);
            }
            else
            {
                GameMsgDef.g_sNowIsFreePlayMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AttackModeOfDear", "");// 夫妻攻击模式
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AttackModeOfDear", GameMsgDef.sAttackModeOfDear);
            }
            else
            {
                GameMsgDef.sAttackModeOfDear = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AttackModeOfMaster", "");
            // 师徒攻击模式 20080409
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AttackModeOfMaster", GameMsgDef.sAttackModeOfMaster);
            }
            else
            {
                GameMsgDef.sAttackModeOfMaster = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AttackModeOfAll", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AttackModeOfAll", GameMsgDef.sAttackModeOfAll);
            }
            else
            {
                GameMsgDef.sAttackModeOfAll = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AttackModeOfPeaceful", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AttackModeOfPeaceful", GameMsgDef.sAttackModeOfPeaceful);
            }
            else
            {
                GameMsgDef.sAttackModeOfPeaceful = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AttackModeOfGroup", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AttackModeOfGroup", GameMsgDef.sAttackModeOfGroup);
            }
            else
            {
                GameMsgDef.sAttackModeOfGroup = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AttackModeOfGuild", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AttackModeOfGuild", GameMsgDef.sAttackModeOfGuild);
            }
            else
            {
                GameMsgDef.sAttackModeOfGuild = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AttackModeOfRedWhite", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AttackModeOfRedWhite", GameMsgDef.sAttackModeOfRedWhite);
            }
            else
            {
                GameMsgDef.sAttackModeOfRedWhite = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StartChangeAttackModeHelp", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StartChangeAttackModeHelp", GameMsgDef.sStartChangeAttackModeHelp);
            }
            else
            {
                GameMsgDef.sStartChangeAttackModeHelp = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StartNoticeMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StartNoticeMsg", GameMsgDef.sStartNoticeMsg);
            }
            else
            {
                GameMsgDef.sStartNoticeMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ThrustingOn", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ThrustingOn", GameMsgDef.sThrustingOn);
            }
            else
            {
                GameMsgDef.sThrustingOn = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ThrustingOff", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ThrustingOff", GameMsgDef.sThrustingOff);
            }
            else
            {
                GameMsgDef.sThrustingOff = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HalfMoonOn", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HalfMoonOn", GameMsgDef.sHalfMoonOn);
            }
            else
            {
                GameMsgDef.sHalfMoonOn = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HalfMoonOff", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HalfMoonOff", GameMsgDef.sHalfMoonOff);
            }
            else
            {
                GameMsgDef.sHalfMoonOff = LoadString;
            }
            GameMsgDef.sCrsHitOn = LoadString_LoadConfigString("String", "CrsHitOn", GameMsgDef.sCrsHitOn);
            GameMsgDef.sCrsHitOff = LoadString_LoadConfigString("String", "CrsHitOff", GameMsgDef.sCrsHitOff);
            GameMsgDef.sSkill43On = LoadString_LoadConfigString("String", "TwinSkillSummoned2", GameMsgDef.sSkill43On);
            GameMsgDef.sSkill43Off = LoadString_LoadConfigString("String", "TwinSkillsFail2", GameMsgDef.sSkill43Off);
            GameMsgDef.sSkill42On = LoadString_LoadConfigString("String", "KTZSpiritsSummoned", GameMsgDef.sSkill42On);
            GameMsgDef.sSkill42Off = LoadString_LoadConfigString("String", "KTZSpiritsGone", GameMsgDef.sSkill42Off);
            LoadString = StringConf.ReadString("String", "FireSpiritsSummoned", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "FireSpiritsSummoned", GameMsgDef.sFireSpiritsSummoned);
            }
            else
            {
                GameMsgDef.sFireSpiritsSummoned = LoadString;
            }
            LoadString = StringConf.ReadString("String", "FireSpiritsFail", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "FireSpiritsFail", GameMsgDef.sFireSpiritsFail);
            }
            else
            {
                GameMsgDef.sFireSpiritsFail = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SpiritsGone", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SpiritsGone", GameMsgDef.sSpiritsGone);
            }
            else
            {
                GameMsgDef.sSpiritsGone = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DailySkillSummoned", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DailySkillSummoned", GameMsgDef.sDailySkillSummoned);
            }
            else
            {
                GameMsgDef.sDailySkillSummoned = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DailySkillFail", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DailySkillFail", GameMsgDef.sDailySkillFail);
            }
            else
            {
                GameMsgDef.sDailySkillFail = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DailySpiritsGone", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DailySpiritsGone", GameMsgDef.sDailySpiritsGone);
            }
            else
            {
                GameMsgDef.sDailySpiritsGone = LoadString;
            }
            // ------------------------------------------------------------------------------
            LoadString = StringConf.ReadString("String", "MateDoTooweak", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MateDoTooweak", GameMsgDef.sMateDoTooweak);
            }
            else
            {
                GameMsgDef.sMateDoTooweak = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TheWeaponBroke", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TheWeaponBroke", GameMsgDef.g_sTheWeaponBroke);
            }
            else
            {
                GameMsgDef.g_sTheWeaponBroke = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TheWeaponRefineSuccessfull", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TheWeaponRefineSuccessfull", GameMsgDef.sTheWeaponRefineSuccessfull);
            }
            else
            {
                GameMsgDef.sTheWeaponRefineSuccessfull = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouPoisoned", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouPoisoned", GameMsgDef.sYouPoisoned);
            }
            else
            {
                GameMsgDef.sYouPoisoned = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouPoisonedSpider", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouPoisonedSpider", GameMsgDef.sYouPoisonedSpider);
            }
            else
            {
                GameMsgDef.sYouPoisonedSpider = LoadString;
            }
            LoadString = StringConf.ReadString("String", "GetSellOffGlod", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "GetSellOffGlod", GameMsgDef.sGetSellOffGlod);
            }
            else
            {
                GameMsgDef.sGetSellOffGlod = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ButchEnoughBagHintMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ButchEnoughBagHintMsg", GameMsgDef.sButchEnoughBagHintMsg);
            }
            else
            {
                GameMsgDef.sButchEnoughBagHintMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HumLevelOrderDropMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HumLevelOrderDropMsg", GameMsgDef.sHumLevelOrderDropMsg);
            }
            else
            {
                GameMsgDef.sHumLevelOrderDropMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "RefineItemSuccess", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "RefineItemSuccess", GameMsgDef.sRefineItemSuccessMsg);
            }
            else
            {
                GameMsgDef.sRefineItemSuccessMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "RefineItemFail", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "RefineItemFail", GameMsgDef.sRefineItemFailMsg);
            }
            else
            {
                GameMsgDef.sRefineItemFailMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "RefineItemError", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "RefineItemError", GameMsgDef.sRefineItemErrorMsg);
            }
            else
            {
                GameMsgDef.sRefineItemErrorMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NeedLevelToXYErrorMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NeedLevelToXYErrorMsg", GameMsgDef.sNEEDLEVELToXYErrorMsg);
            }
            else
            {
                GameMsgDef.sNEEDLEVELToXYErrorMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PetRest", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PetRest", GameMsgDef.sPetRest);
            }
            else
            {
                GameMsgDef.sPetRest = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PetAttack", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PetAttack", GameMsgDef.sPetAttack);
            }
            else
            {
                GameMsgDef.sPetAttack = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WearNotOfWoMan", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WearNotOfWoMan", GameMsgDef.sWearNotOfWoMan);
            }
            else
            {
                GameMsgDef.sWearNotOfWoMan = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WearNotOfMan", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WearNotOfMan", GameMsgDef.sWearNotOfMan);
            }
            else
            {
                GameMsgDef.sWearNotOfMan = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HandWeightNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HandWeightNot", GameMsgDef.sHandWeightNot);
            }
            else
            {
                GameMsgDef.sHandWeightNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WearWeightNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WearWeightNot", GameMsgDef.sWearWeightNot);
            }
            else
            {
                GameMsgDef.sWearWeightNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ItemIsNotThisAccount", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ItemIsNotThisAccount", GameMsgDef.g_sItemIsNotThisAccount);
            }
            else
            {
                GameMsgDef.g_sItemIsNotThisAccount = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ItemIsNotThisIPaddr", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ItemIsNotThisIPaddr", GameMsgDef.g_sItemIsNotThisIPaddr);
            }
            else
            {
                GameMsgDef.g_sItemIsNotThisIPaddr = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ItemIsNotThisCharName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ItemIsNotThisCharName", GameMsgDef.g_sItemIsNotThisCharName);
            }
            else
            {
                GameMsgDef.g_sItemIsNotThisCharName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "LevelNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "LevelNot", GameMsgDef.g_sLevelNot);
            }
            else
            {
                GameMsgDef.g_sLevelNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "JobOrLevelNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "JobOrLevelNot", GameMsgDef.g_sJobOrLevelNot);
            }
            else
            {
                GameMsgDef.g_sJobOrLevelNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "JobOrDCNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "JobOrDCNot", GameMsgDef.g_sJobOrDCNot);
            }
            else
            {
                GameMsgDef.g_sJobOrDCNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "JobOrMCNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "JobOrMCNot", GameMsgDef.g_sJobOrMCNot);
            }
            else
            {
                GameMsgDef.g_sJobOrMCNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "JobOrSCNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "JobOrSCNot", GameMsgDef.g_sJobOrSCNot);
            }
            else
            {
                GameMsgDef.g_sJobOrSCNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DCNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DCNot", GameMsgDef.g_sDCNot);
            }
            else
            {
                GameMsgDef.g_sDCNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MCNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MCNot", GameMsgDef.g_sMCNot);
            }
            else
            {
                GameMsgDef.g_sMCNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SCNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SCNot", GameMsgDef.g_sSCNot);
            }
            else
            {
                GameMsgDef.g_sSCNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CreditPointNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CreditPointNot", GameMsgDef.g_sCreditPointNot);
            }
            else
            {
                GameMsgDef.g_sCreditPointNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ReNewLevelNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ReNewLevelNot", GameMsgDef.g_sReNewLevelNot);
            }
            else
            {
                GameMsgDef.g_sReNewLevelNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "GuildNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "GuildNot", GameMsgDef.g_sGuildNot);
            }
            else
            {
                GameMsgDef.g_sGuildNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "GuildMasterNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "GuildMasterNot", GameMsgDef.g_sGuildMasterNot);
            }
            else
            {
                GameMsgDef.g_sGuildMasterNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SabukHumanNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SabukHumanNot", GameMsgDef.g_sSabukHumanNot);
            }
            else
            {
                GameMsgDef.g_sSabukHumanNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SabukMasterManNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SabukMasterManNot", GameMsgDef.g_sSabukMasterManNot);
            }
            else
            {
                GameMsgDef.g_sSabukMasterManNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MemberNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MemberNot", GameMsgDef.g_sMemberNot);
            }
            else
            {
                GameMsgDef.g_sMemberNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MemberTypeNot", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MemberTypeNot", GameMsgDef.g_sMemberTypeNot);
            }
            else
            {
                GameMsgDef.g_sMemberTypeNot = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanottWearIt", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanottWearIt", GameMsgDef.g_sCanottWearIt);
            }
            else
            {
                GameMsgDef.g_sCanottWearIt = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotUseDrugOnThisMap", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotUseDrugOnThisMap", GameMsgDef.sCanotUseDrugOnThisMap);
            }
            else
            {
                GameMsgDef.sCanotUseDrugOnThisMap = LoadString;
            }
            LoadString = StringConf.ReadString("String", "GameMasterMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "GameMasterMode", GameMsgDef.sGameMasterMode);
            }
            else
            {
                GameMsgDef.sGameMasterMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ReleaseGameMasterMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ReleaseGameMasterMode", GameMsgDef.sReleaseGameMasterMode);
            }
            else
            {
                GameMsgDef.sReleaseGameMasterMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ObserverMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ObserverMode", GameMsgDef.sObserverMode);
            }
            else
            {
                GameMsgDef.sObserverMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ReleaseObserverMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ReleaseObserverMode", GameMsgDef.g_sReleaseObserverMode);
            }
            else
            {
                GameMsgDef.g_sReleaseObserverMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SupermanMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SupermanMode", GameMsgDef.sSupermanMode);
            }
            else
            {
                GameMsgDef.sSupermanMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ReleaseSupermanMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ReleaseSupermanMode", GameMsgDef.sReleaseSupermanMode);
            }
            else
            {
                GameMsgDef.sReleaseSupermanMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouFoundNothing", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouFoundNothing", GameMsgDef.sYouFoundNothing);
            }
            else
            {
                GameMsgDef.sYouFoundNothing = LoadString;
            }
            LoadString = StringConf.ReadString("String", "LineNoticePreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "LineNoticePreFix", g_Config.sLineNoticePreFix);
            }
            else
            {
                g_Config.sLineNoticePreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SysMsgPreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SysMsgPreFix", g_Config.sSysMsgPreFix);
            }
            else
            {
                g_Config.sSysMsgPreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "GuildMsgPreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "GuildMsgPreFix", g_Config.sGuildMsgPreFix);
            }
            else
            {
                g_Config.sGuildMsgPreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "GroupMsgPreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "GroupMsgPreFix", g_Config.sGroupMsgPreFix);
            }
            else
            {
                g_Config.sGroupMsgPreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HintMsgPreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HintMsgPreFix", g_Config.sHintMsgPreFix);
            }
            else
            {
                g_Config.sHintMsgPreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "GMRedMsgpreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "GMRedMsgpreFix", g_Config.sGMRedMsgpreFix);
            }
            else
            {
                g_Config.sGMRedMsgpreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MonSayMsgpreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MonSayMsgpreFix", g_Config.sMonSayMsgpreFix);
            }
            else
            {
                g_Config.sMonSayMsgpreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CustMsgpreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CustMsgpreFix", g_Config.sCustMsgpreFix);
            }
            else
            {
                g_Config.sCustMsgpreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CastleMsgpreFix", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CastleMsgpreFix", g_Config.sCastleMsgpreFix);
            }
            else
            {
                g_Config.sCastleMsgpreFix = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NoPasswordLockSystemMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NoPasswordLockSystemMsg", GameMsgDef.g_sNoPasswordLockSystemMsg);
            }
            else
            {
                GameMsgDef.g_sNoPasswordLockSystemMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "AlreadySetPassword", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "AlreadySetPassword", GameMsgDef.g_sAlreadySetPasswordMsg);
            }
            else
            {
                GameMsgDef.g_sAlreadySetPasswordMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ReSetPassword", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ReSetPassword", GameMsgDef.g_sReSetPasswordMsg);
            }
            else
            {
                GameMsgDef.g_sReSetPasswordMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PasswordOverLong", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PasswordOverLong", GameMsgDef.g_sPasswordOverLongMsg);
            }
            else
            {
                GameMsgDef.g_sPasswordOverLongMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ReSetPasswordOK", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ReSetPasswordOK", GameMsgDef.g_sReSetPasswordOKMsg);
            }
            else
            {
                GameMsgDef.g_sReSetPasswordOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ReSetPasswordNotMatch", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ReSetPasswordNotMatch", GameMsgDef.g_sReSetPasswordNotMatchMsg);
            }
            else
            {
                GameMsgDef.g_sReSetPasswordNotMatchMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PleaseInputUnLockPassword", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PleaseInputUnLockPassword", GameMsgDef.g_sPleaseInputUnLockPasswordMsg);
            }
            else
            {
                GameMsgDef.g_sPleaseInputUnLockPasswordMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StorageUnLockOK", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StorageUnLockOK", GameMsgDef.g_sStorageUnLockOKMsg);
            }
            else
            {
                GameMsgDef.g_sStorageUnLockOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StorageAlreadyUnLock", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StorageAlreadyUnLock", GameMsgDef.g_sStorageAlreadyUnLockMsg);
            }
            else
            {
                GameMsgDef.g_sStorageAlreadyUnLockMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StorageNoPassword", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StorageNoPassword", GameMsgDef.g_sStorageNoPasswordMsg);
            }
            else
            {
                GameMsgDef.g_sStorageNoPasswordMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "UnLockPasswordFail", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "UnLockPasswordFail", GameMsgDef.g_sUnLockPasswordFailMsg);
            }
            else
            {
                GameMsgDef.g_sUnLockPasswordFailMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "LockStorageSuccess", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "LockStorageSuccess", GameMsgDef.g_sLockStorageSuccessMsg);
            }
            else
            {
                GameMsgDef.g_sLockStorageSuccessMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StoragePasswordClearMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StoragePasswordClearMsg", GameMsgDef.g_sStoragePasswordClearMsg);
            }
            else
            {
                GameMsgDef.g_sStoragePasswordClearMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PleaseUnloadStoragePasswordMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PleaseUnloadStoragePasswordMsg", GameMsgDef.g_sPleaseUnloadStoragePasswordMsg);
            }
            else
            {
                GameMsgDef.g_sPleaseUnloadStoragePasswordMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StorageAlreadyLock", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StorageAlreadyLock", GameMsgDef.g_sStorageAlreadyLockMsg);
            }
            else
            {
                GameMsgDef.g_sStorageAlreadyLockMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StoragePasswordLocked", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StoragePasswordLocked", GameMsgDef.g_sStoragePasswordLockedMsg);
            }
            else
            {
                GameMsgDef.g_sStoragePasswordLockedMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StorageSetPassword", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StorageSetPassword", GameMsgDef.g_sSetPasswordMsg);
            }
            else
            {
                GameMsgDef.g_sSetPasswordMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PleaseInputOldPassword", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PleaseInputOldPassword", GameMsgDef.g_sPleaseInputOldPasswordMsg);
            }
            else
            {
                GameMsgDef.g_sPleaseInputOldPasswordMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PasswordIsClearMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PasswordIsClearMsg", GameMsgDef.g_sOldPasswordIsClearMsg);
            }
            else
            {
                GameMsgDef.g_sOldPasswordIsClearMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NoPasswordSet", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NoPasswordSet", GameMsgDef.g_sNoPasswordSetMsg);
            }
            else
            {
                GameMsgDef.g_sNoPasswordSetMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "OldPasswordIncorrect", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "OldPasswordIncorrect", GameMsgDef.g_sOldPasswordIncorrectMsg);
            }
            else
            {
                GameMsgDef.g_sOldPasswordIncorrectMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StorageIsLocked", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StorageIsLocked", GameMsgDef.g_sStorageIsLockedMsg);
            }
            else
            {
                GameMsgDef.g_sStorageIsLockedMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PleaseTryDealLaterMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PleaseTryDealLaterMsg", GameMsgDef.g_sPleaseTryDealLaterMsg);
            }
            else
            {
                GameMsgDef.g_sPleaseTryDealLaterMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DealItemsDenyGetBackMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DealItemsDenyGetBackMsg", GameMsgDef.g_sDealItemsDenyGetBackMsg);
            }
            else
            {
                GameMsgDef.g_sDealItemsDenyGetBackMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableDealItemsMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableDealItemsMsg", GameMsgDef.g_sDisableDealItemsMsg);
            }
            else
            {
                GameMsgDef.g_sDisableDealItemsMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotTryDealMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotTryDealMsg", GameMsgDef.g_sCanotTryDealMsg);
            }
            else
            {
                GameMsgDef.g_sCanotTryDealMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DealActionCancelMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DealActionCancelMsg", GameMsgDef.g_sDealActionCancelMsg);
            }
            else
            {
                GameMsgDef.g_sDealActionCancelMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PoseDisableDealMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PoseDisableDealMsg", GameMsgDef.g_sPoseDisableDealMsg);
            }
            else
            {
                GameMsgDef.g_sPoseDisableDealMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DealSuccessMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DealSuccessMsg", GameMsgDef.g_sDealSuccessMsg);
            }
            else
            {
                GameMsgDef.g_sDealSuccessMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DealOKTooFast", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DealOKTooFast", GameMsgDef.g_sDealOKTooFast);
            }
            else
            {
                GameMsgDef.g_sDealOKTooFast = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourBagSizeTooSmall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourBagSizeTooSmall", GameMsgDef.g_sYourBagSizeTooSmall);
            }
            else
            {
                GameMsgDef.g_sYourBagSizeTooSmall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DealHumanBagSizeTooSmall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DealHumanBagSizeTooSmall", GameMsgDef.g_sDealHumanBagSizeTooSmall);
            }
            else
            {
                GameMsgDef.g_sDealHumanBagSizeTooSmall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourGoldLargeThenLimit", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourGoldLargeThenLimit", GameMsgDef.g_sYourGoldLargeThenLimit);
            }
            else
            {
                GameMsgDef.g_sYourGoldLargeThenLimit = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DealHumanGoldLargeThenLimit", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DealHumanGoldLargeThenLimit", GameMsgDef.g_sDealHumanGoldLargeThenLimit);
            }
            else
            {
                GameMsgDef.g_sDealHumanGoldLargeThenLimit = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouDealOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouDealOKMsg", GameMsgDef.g_sYouDealOKMsg);
            }
            else
            {
                GameMsgDef.g_sYouDealOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PoseDealOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PoseDealOKMsg", GameMsgDef.g_sPoseDealOKMsg);
            }
            else
            {
                GameMsgDef.g_sPoseDealOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "KickClientUserMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "KickClientUserMsg", GameMsgDef.g_sKickClientUserMsg);
            }
            else
            {
                GameMsgDef.g_sKickClientUserMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ActionIsLockedMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ActionIsLockedMsg", GameMsgDef.g_sActionIsLockedMsg);
            }
            else
            {
                GameMsgDef.g_sActionIsLockedMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PasswordNotSetMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PasswordNotSetMsg", GameMsgDef.g_sPasswordNotSetMsg);
            }
            else
            {
                GameMsgDef.g_sPasswordNotSetMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CallHeroTime", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CallHeroTime", GameMsgDef.g_sRecallHeroHint);
            }
            else
            {
                GameMsgDef.g_sRecallHeroHint = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NotHero", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NotHero", GameMsgDef.g_sNotHero);
            }
            else
            {
                GameMsgDef.g_sNotHero = LoadString;
            }
            LoadString = StringConf.ReadString("String", "OpenShieldMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "OpenShieldMsg", GameMsgDef.g_sOpenShieldMsg);
            }
            else
            {
                GameMsgDef.g_sOpenShieldMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "OpenShieldTickMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "OpenShieldTickMsg", GameMsgDef.g_sOpenShieldTickMsg);
            }
            else
            {
                GameMsgDef.g_sOpenShieldTickMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ButchItemHintMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ButchItemHintMsg", GameMsgDef.g_sButchItemHintMsg);
            }
            else
            {
                GameMsgDef.g_sButchItemHintMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "BoxsItemHintMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "BoxsItemHintMsg", GameMsgDef.g_sBoxsItemHintMsg);
            }
            else
            {
                GameMsgDef.g_sBoxsItemHintMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ItmeDropHintMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ItmeDropHintMsg", GameMsgDef.g_sItmeDropHintMsg);
            }
            else
            {
                GameMsgDef.g_sItmeDropHintMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "JiujinOverHintMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "JiujinOverHintMsg", GameMsgDef.g_sJiujinOverHintMsg);
            }
            else
            {
                GameMsgDef.g_sJiujinOverHintMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "UpAlcoholHintMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "UpAlcoholHintMsg", GameMsgDef.g_sUpAlcoholHintMsg);
            }
            else
            {
                GameMsgDef.g_sUpAlcoholHintMsg = LoadString;
            }
            // 20080713 挑战提示 begin
            LoadString = StringConf.ReadString("String", "ChallengeWinMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeWinMsg", GameMsgDef.g_sChallengeWinMsg);
            }
            else
            {
                GameMsgDef.g_sChallengeWinMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeLoseMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeLoseMsg", GameMsgDef.g_sChallengeLoseMsg);
            }
            else
            {
                GameMsgDef.g_sChallengeLoseMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PleaseTryChallengeLaterMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PleaseTryChallengeLaterMsg", GameMsgDef.g_sPleaseTryChallengeLaterMsg);
            }
            else
            {
                GameMsgDef.g_sPleaseTryChallengeLaterMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeActionCancelMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeActionCancelMsg", GameMsgDef.g_sChallengeActionCancelMsg);
            }
            else
            {
                GameMsgDef.g_sChallengeActionCancelMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeItemsDenyGetBackMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeItemsDenyGetBackMsg", GameMsgDef.g_sChallengeItemsDenyGetBackMsg);
            }
            else
            {
                GameMsgDef.g_sChallengeItemsDenyGetBackMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeOKTooFast", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeOKTooFast", GameMsgDef.g_sChallengeOKTooFast);
            }
            else
            {
                GameMsgDef.g_sChallengeOKTooFast = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeYourBagSizeTooSmall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeYourBagSizeTooSmall", GameMsgDef.g_sChallengeYourBagSizeTooSmall);
            }
            else
            {
                GameMsgDef.g_sChallengeYourBagSizeTooSmall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeYourGoldLargeThenLimit", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeYourGoldLargeThenLimit", GameMsgDef.g_sChallengeYourGoldLargeThenLimit);
            }
            else
            {
                GameMsgDef.g_sChallengeYourGoldLargeThenLimit = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeHumanBagSizeTooSmall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeHumanBagSizeTooSmall", GameMsgDef.g_sChallengeHumanBagSizeTooSmall);
            }
            else
            {
                GameMsgDef.g_sChallengeHumanBagSizeTooSmall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeHumanGoldLargeThenLimit", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeHumanGoldLargeThenLimit", GameMsgDef.g_sChallengeHumanGoldLargeThenLimit);
            }
            else
            {
                GameMsgDef.g_sChallengeHumanGoldLargeThenLimit = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouChallengeOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouChallengeOKMsg", GameMsgDef.g_sYouChallengeOKMsg);
            }
            else
            {
                GameMsgDef.g_sYouChallengeOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PoseChallengeOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PoseChallengeOKMsg", GameMsgDef.g_sPoseChallengeOKMsg);
            }
            else
            {
                GameMsgDef.g_sPoseChallengeOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChallengeTimeOverMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChallengeTimeOverMsg", GameMsgDef.g_sChallengeTimeOverMsg);
            }
            else
            {
                GameMsgDef.g_sChallengeTimeOverMsg = LoadString;
            }
            // 20080713 挑战提示 end
            LoadString = StringConf.ReadString("String", "PickUpItemHintMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PickUpItemHintMsg", GameMsgDef.g_sPickUpItemHintMsg);
            }
            else
            {
                GameMsgDef.g_sPickUpItemHintMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ShieldTimeDisappearMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ShieldTimeDisappearMsg", GameMsgDef.g_sShieldTimeDisappearMsg);
            }
            else
            {
                GameMsgDef.g_sShieldTimeDisappearMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "OpenShieldOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "OpenShieldOKMsg", GameMsgDef.g_sOpenShieldOKMsg);
            }
            else
            {
                GameMsgDef.g_sOpenShieldOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HeroHit", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HeroHit", GameMsgDef.g_sHeroLoginMsg);
            }
            else
            {
                GameMsgDef.g_sHeroLoginMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HeroProtect", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HeroProtect", GameMsgDef.g_sHeroProtect);
            }
            else
            {
                GameMsgDef.g_sHeroProtect = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HeroNotProtect", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HeroNotProtect", GameMsgDef.g_sHeroNotProtect);
            }
            else
            {
                GameMsgDef.g_sHeroNotProtect = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HeroClose", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HeroClose", GameMsgDef.g_sHeroClose);
            }
            else
            {
                GameMsgDef.g_sHeroClose = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HeroRest", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HeroRest", GameMsgDef.g_sHeroRest);
            }
            else
            {
                GameMsgDef.g_sHeroRest = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HeroAttack", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HeroAttack", GameMsgDef.g_sHeroAttack);
            }
            else
            {
                GameMsgDef.g_sHeroAttack = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HeroFollow", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HeroFollow", GameMsgDef.g_sHeroFollow);
            }
            else
            {
                GameMsgDef.g_sHeroFollow = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NotPasswordProtectMode", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NotPasswordProtectMode", GameMsgDef.g_sNotPasswordProtectMode);
            }
            else
            {
                GameMsgDef.g_sNotPasswordProtectMode = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotDropGoldMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotDropGoldMsg", GameMsgDef.g_sCanotDropGoldMsg);
            }
            else
            {
                GameMsgDef.g_sCanotDropGoldMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotDropInSafeZoneMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotDropInSafeZoneMsg", GameMsgDef.g_sCanotDropInSafeZoneMsg);
            }
            else
            {
                GameMsgDef.g_sCanotDropInSafeZoneMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotDropItemMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotDropItemMsg", GameMsgDef.g_sCanotDropItemMsg);
            }
            else
            {
                GameMsgDef.g_sCanotDropItemMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotDropItemMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotDropItemMsg", GameMsgDef.g_sCanotDropItemMsg);
            }
            else
            {
                GameMsgDef.g_sCanotDropItemMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotUseItemMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotUseItemMsg", GameMsgDef.g_sCanotUseItemMsg);
            }
            else
            {
                GameMsgDef.g_sCanotUseItemMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StartMarryManMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StartMarryManMsg", GameMsgDef.g_sStartMarryManMsg);
            }
            else
            {
                GameMsgDef.g_sStartMarryManMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StartMarryWoManMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StartMarryWoManMsg", GameMsgDef.g_sStartMarryWoManMsg);
            }
            else
            {
                GameMsgDef.g_sStartMarryWoManMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StartMarryManAskQuestionMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StartMarryManAskQuestionMsg", GameMsgDef.g_sStartMarryManAskQuestionMsg);
            }
            else
            {
                GameMsgDef.g_sStartMarryManAskQuestionMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "StartMarryWoManAskQuestionMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "StartMarryWoManAskQuestionMsg", GameMsgDef.g_sStartMarryWoManAskQuestionMsg);
            }
            else
            {
                GameMsgDef.g_sStartMarryWoManAskQuestionMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MarryManAnswerQuestionMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MarryManAnswerQuestionMsg", GameMsgDef.g_sMarryManAnswerQuestionMsg);
            }
            else
            {
                GameMsgDef.g_sMarryManAnswerQuestionMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MarryManAskQuestionMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MarryManAskQuestionMsg", GameMsgDef.g_sMarryManAskQuestionMsg);
            }
            else
            {
                GameMsgDef.g_sMarryManAskQuestionMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MarryWoManAnswerQuestionMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MarryWoManAnswerQuestionMsg", GameMsgDef.g_sMarryWoManAnswerQuestionMsg);
            }
            else
            {
                GameMsgDef.g_sMarryWoManAnswerQuestionMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MarryWoManGetMarryMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MarryWoManGetMarryMsg", GameMsgDef.g_sMarryWoManGetMarryMsg);
            }
            else
            {
                GameMsgDef.g_sMarryWoManGetMarryMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MarryWoManDenyMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MarryWoManDenyMsg", GameMsgDef.g_sMarryWoManDenyMsg);
            }
            else
            {
                GameMsgDef.g_sMarryWoManDenyMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MarryWoManCancelMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MarryWoManCancelMsg", GameMsgDef.g_sMarryWoManCancelMsg);
            }
            else
            {
                GameMsgDef.g_sMarryWoManCancelMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ForceUnMarryManLoginMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ForceUnMarryManLoginMsg", GameMsgDef.g_sfUnMarryManLoginMsg);
            }
            else
            {
                GameMsgDef.g_sfUnMarryManLoginMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ForceUnMarryWoManLoginMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ForceUnMarryWoManLoginMsg", GameMsgDef.g_sfUnMarryWoManLoginMsg);
            }
            else
            {
                GameMsgDef.g_sfUnMarryWoManLoginMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ManLoginDearOnlineSelfMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ManLoginDearOnlineSelfMsg", GameMsgDef.g_sManLoginDearOnlineSelfMsg);
            }
            else
            {
                GameMsgDef.g_sManLoginDearOnlineSelfMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ManLoginDearOnlineDearMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ManLoginDearOnlineDearMsg", GameMsgDef.g_sManLoginDearOnlineDearMsg);
            }
            else
            {
                GameMsgDef.g_sManLoginDearOnlineDearMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WoManLoginDearOnlineSelfMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WoManLoginDearOnlineSelfMsg", GameMsgDef.g_sWoManLoginDearOnlineSelfMsg);
            }
            else
            {
                GameMsgDef.g_sWoManLoginDearOnlineSelfMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WoManLoginDearOnlineDearMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WoManLoginDearOnlineDearMsg", GameMsgDef.g_sWoManLoginDearOnlineDearMsg);
            }
            else
            {
                GameMsgDef.g_sWoManLoginDearOnlineDearMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ManLoginDearNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ManLoginDearNotOnlineMsg", GameMsgDef.g_sManLoginDearNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sManLoginDearNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WoManLoginDearNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WoManLoginDearNotOnlineMsg", GameMsgDef.g_sWoManLoginDearNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sWoManLoginDearNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ManLongOutDearOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ManLongOutDearOnlineMsg", GameMsgDef.g_sManLongOutDearOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sManLongOutDearOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WoManLongOutDearOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WoManLongOutDearOnlineMsg", GameMsgDef.g_sWoManLongOutDearOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sWoManLongOutDearOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouAreNotMarryedMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouAreNotMarryedMsg", GameMsgDef.g_sYouAreNotMarryedMsg);
            }
            else
            {
                GameMsgDef.g_sYouAreNotMarryedMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourWifeNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourWifeNotOnlineMsg", GameMsgDef.g_sYourWifeNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sYourWifeNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourHusbandNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourHusbandNotOnlineMsg", GameMsgDef.g_sYourHusbandNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sYourHusbandNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourWifeNowLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourWifeNowLocateMsg", GameMsgDef.g_sYourWifeNowLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourWifeNowLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourHusbandSearchLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourHusbandSearchLocateMsg", GameMsgDef.g_sYourHusbandSearchLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourHusbandSearchLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourHusbandNowLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourHusbandNowLocateMsg", GameMsgDef.g_sYourHusbandNowLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourHusbandNowLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourWifeSearchLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourWifeSearchLocateMsg", GameMsgDef.g_sYourWifeSearchLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourWifeSearchLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "FUnMasterLoginMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "FUnMasterLoginMsg", GameMsgDef.g_sfUnMasterLoginMsg);
            }
            else
            {
                GameMsgDef.g_sfUnMasterLoginMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "UnMasterListLoginMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "UnMasterListLoginMsg", GameMsgDef.g_sfUnMasterListLoginMsg);
            }
            else
            {
                GameMsgDef.g_sfUnMasterListLoginMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterListOnlineSelfMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterListOnlineSelfMsg", GameMsgDef.g_sMasterListOnlineSelfMsg);
            }
            else
            {
                GameMsgDef.g_sMasterListOnlineSelfMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterListOnlineMasterMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterListOnlineMasterMsg", GameMsgDef.g_sMasterListOnlineMasterMsg);
            }
            else
            {
                GameMsgDef.g_sMasterListOnlineMasterMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterOnlineSelfMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterOnlineSelfMsg", GameMsgDef.g_sMasterOnlineSelfMsg);
            }
            else
            {
                GameMsgDef.g_sMasterOnlineSelfMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterOnlineMasterListMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterOnlineMasterListMsg", GameMsgDef.g_sMasterOnlineMasterListMsg);
            }
            else
            {
                GameMsgDef.g_sMasterOnlineMasterListMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterLongOutMasterListOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterLongOutMasterListOnlineMsg", GameMsgDef.g_sMasterLongOutMasterListOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sMasterLongOutMasterListOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterListLongOutMasterOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterListLongOutMasterOnlineMsg", GameMsgDef.g_sMasterListLongOutMasterOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sMasterListLongOutMasterOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterListNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterListNotOnlineMsg", GameMsgDef.g_sMasterListNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sMasterListNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterNotOnlineMsg", GameMsgDef.g_sMasterNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sMasterNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouAreNotMasterMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouAreNotMasterMsg", GameMsgDef.g_sYouAreNotMasterMsg);
            }
            else
            {
                GameMsgDef.g_sYouAreNotMasterMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourMasterNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourMasterNotOnlineMsg", GameMsgDef.g_sYourMasterNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sYourMasterNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourMasterListNotOnlineMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourMasterListNotOnlineMsg", GameMsgDef.g_sYourMasterListNotOnlineMsg);
            }
            else
            {
                GameMsgDef.g_sYourMasterListNotOnlineMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourMasterNowLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourMasterNowLocateMsg", GameMsgDef.g_sYourMasterNowLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourMasterNowLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourMasterListSearchLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourMasterListSearchLocateMsg", GameMsgDef.g_sYourMasterListSearchLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourMasterListSearchLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourMasterListNowLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourMasterListNowLocateMsg", GameMsgDef.g_sYourMasterListNowLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourMasterListNowLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourMasterSearchLocateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourMasterSearchLocateMsg", GameMsgDef.g_sYourMasterSearchLocateMsg);
            }
            else
            {
                GameMsgDef.g_sYourMasterSearchLocateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourMasterListUnMasterOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourMasterListUnMasterOKMsg", GameMsgDef.g_sYourMasterListUnMasterOKMsg);
            }
            else
            {
                GameMsgDef.g_sYourMasterListUnMasterOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouAreUnMasterOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouAreUnMasterOKMsg", GameMsgDef.g_sYouAreUnMasterOKMsg);
            }
            else
            {
                GameMsgDef.g_sYouAreUnMasterOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "UnMasterLoginMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "UnMasterLoginMsg", GameMsgDef.g_sUnMasterLoginMsg);
            }
            else
            {
                GameMsgDef.g_sUnMasterLoginMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NPCSayUnMasterOKMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NPCSayUnMasterOKMsg", GameMsgDef.g_sNPCSayUnMasterOKMsg);
            }
            else
            {
                GameMsgDef.g_sNPCSayUnMasterOKMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NPCSayForceUnMasterMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NPCSayForceUnMasterMsg", GameMsgDef.g_sNPCSayForceUnMasterMsg);
            }
            else
            {
                GameMsgDef.g_sNPCSayForceUnMasterMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MyInfo", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MyInfo", GameMsgDef.g_sMyInfo);
            }
            else
            {
                GameMsgDef.g_sMyInfo = LoadString;
            }
            LoadString = StringConf.ReadString("String", "OpenedDealMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "OpenedDealMsg", GameMsgDef.g_sOpenedDealMsg);
            }
            else
            {
                GameMsgDef.g_sOpenedDealMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SendCustMsgCanNotUseNowMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SendCustMsgCanNotUseNowMsg", GameMsgDef.g_sSendCustMsgCanNotUseNowMsg);
            }
            else
            {
                GameMsgDef.g_sSendCustMsgCanNotUseNowMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SubkMasterMsgCanNotUseNowMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SubkMasterMsgCanNotUseNowMsg", GameMsgDef.g_sSubkMasterMsgCanNotUseNowMsg);
            }
            else
            {
                GameMsgDef.g_sSubkMasterMsgCanNotUseNowMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "SendOnlineCountMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "SendOnlineCountMsg", GameMsgDef.g_sSendOnlineCountMsg);
            }
            else
            {
                GameMsgDef.g_sSendOnlineCountMsg = LoadString.Replace("%c","{0}");
            }
            LoadString = StringConf.ReadString("String", "WeaponRepairSuccess", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WeaponRepairSuccess", GameMsgDef.g_sWeaponRepairSuccess);
            }
            else
            {
                GameMsgDef.g_sWeaponRepairSuccess = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DefenceUpTime", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DefenceUpTime", GameMsgDef.g_sDefenceUpTime);
            }
            else
            {
                GameMsgDef.g_sDefenceUpTime = LoadString.Replace("%d", "{0}");
            }
            LoadString = StringConf.ReadString("String", "MagDefenceUpTime", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MagDefenceUpTime", GameMsgDef.g_sMagDefenceUpTime);
            }
            else
            {
                GameMsgDef.g_sMagDefenceUpTime = LoadString.Replace("%d", "{0}");
            }
            LoadString = StringConf.ReadString("String", "DefenceUpTimeOver", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DefenceUpTimeOver", GameMsgDef.g_sDefenceUpTimeOver);
            }
            else
            {
                GameMsgDef.g_sDefenceUpTimeOver = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MagDefenceUpTimeOver", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MagDefenceUpTimeOver", GameMsgDef.g_sMagDefenceUpTimeOver);
            }
            else
            {
                GameMsgDef.g_sMagDefenceUpTimeOver = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WinLottery1Msg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WinLottery1Msg", GameMsgDef.g_sWinLottery1Msg);
            }
            else
            {
                GameMsgDef.g_sWinLottery1Msg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WinLottery2Msg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WinLottery2Msg", GameMsgDef.g_sWinLottery2Msg);
            }
            else
            {
                GameMsgDef.g_sWinLottery2Msg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WinLottery3Msg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WinLottery3Msg", GameMsgDef.g_sWinLottery3Msg);
            }
            else
            {
                GameMsgDef.g_sWinLottery3Msg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WinLottery4Msg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WinLottery4Msg", GameMsgDef.g_sWinLottery4Msg);
            }
            else
            {
                GameMsgDef.g_sWinLottery4Msg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WinLottery5Msg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WinLottery5Msg", GameMsgDef.g_sWinLottery5Msg);
            }
            else
            {
                GameMsgDef.g_sWinLottery5Msg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WinLottery6Msg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WinLottery6Msg", GameMsgDef.g_sWinLottery6Msg);
            }
            else
            {
                GameMsgDef.g_sWinLottery6Msg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NotWinLotteryMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NotWinLotteryMsg", GameMsgDef.g_sNotWinLotteryMsg);
            }
            else
            {
                GameMsgDef.g_sNotWinLotteryMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WeaptonMakeLuck", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WeaptonMakeLuck", GameMsgDef.g_sWeaptonMakeLuck);
            }
            else
            {
                GameMsgDef.g_sWeaptonMakeLuck = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WeaptonNotMakeLuck", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WeaptonNotMakeLuck", GameMsgDef.g_sWeaptonNotMakeLuck);
            }
            else
            {
                GameMsgDef.g_sWeaptonNotMakeLuck = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TheWeaponIsCursed", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TheWeaponIsCursed", GameMsgDef.g_sTheWeaponIsCursed);
            }
            else
            {
                GameMsgDef.g_sTheWeaponIsCursed = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotTakeOffItem", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotTakeOffItem", GameMsgDef.g_sCanotTakeOffItem);
            }
            else
            {
                GameMsgDef.g_sCanotTakeOffItem = LoadString;
            }
            LoadString = StringConf.ReadString("String", "JoinGroupMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "JoinGroupMsg", GameMsgDef.g_sJoinGroup);
            }
            else
            {
                GameMsgDef.g_sJoinGroup = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TryModeCanotUseStorage", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TryModeCanotUseStorage", GameMsgDef.g_sTryModeCanotUseStorage);
            }
            else
            {
                GameMsgDef.g_sTryModeCanotUseStorage = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotGetItemsMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotGetItemsMsg", GameMsgDef.g_sCanotGetItems);
            }
            else
            {
                GameMsgDef.g_sCanotGetItems = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableDearRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableDearRecall", GameMsgDef.g_sEnableDearRecall);
            }
            else
            {
                GameMsgDef.g_sEnableDearRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableDearRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableDearRecall", GameMsgDef.g_sDisableDearRecall);
            }
            else
            {
                GameMsgDef.g_sDisableDearRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableMasterRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableMasterRecall", GameMsgDef.g_sEnableMasterRecall);
            }
            else
            {
                GameMsgDef.g_sEnableMasterRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableMasterRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableMasterRecall", GameMsgDef.g_sDisableMasterRecall);
            }
            else
            {
                GameMsgDef.g_sDisableMasterRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NowCurrDateTime", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NowCurrDateTime", GameMsgDef.g_sNowCurrDateTime);
            }
            else
            {
                GameMsgDef.g_sNowCurrDateTime = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableAllowRebirth", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableAllowRebirth", GameMsgDef.g_sEnableAllowRebirth);
            }
            else
            {
                GameMsgDef.g_sEnableAllowRebirth = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableAllowRebirth", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableAllowRebirth", GameMsgDef.g_sDisableAllowRebirth);
            }
            else
            {
                GameMsgDef.g_sDisableAllowRebirth = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableHearWhisper", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableHearWhisper", GameMsgDef.g_sEnableHearWhisper);
            }
            else
            {
                GameMsgDef.g_sEnableHearWhisper = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableHearWhisper", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableHearWhisper", GameMsgDef.g_sDisableHearWhisper);
            }
            else
            {
                GameMsgDef.g_sDisableHearWhisper = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableShoutMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableShoutMsg", GameMsgDef.g_sEnableShoutMsg);
            }
            else
            {
                GameMsgDef.g_sEnableShoutMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableShoutMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableShoutMsg", GameMsgDef.g_sDisableShoutMsg);
            }
            else
            {
                GameMsgDef.g_sDisableShoutMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableDealMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableDealMsg", GameMsgDef.g_sEnableDealMsg);
            }
            else
            {
                GameMsgDef.g_sEnableDealMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableDealMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableDealMsg", GameMsgDef.g_sDisableDealMsg);
            }
            else
            {
                GameMsgDef.g_sDisableDealMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableGuildChat", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableGuildChat", GameMsgDef.g_sEnableGuildChat);
            }
            else
            {
                GameMsgDef.g_sEnableGuildChat = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableGuildChat", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableGuildChat", GameMsgDef.g_sDisableGuildChat);
            }
            else
            {
                GameMsgDef.g_sDisableGuildChat = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableJoinGuild", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableJoinGuild", GameMsgDef.g_sEnableJoinGuild);
            }
            else
            {
                GameMsgDef.g_sEnableJoinGuild = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableJoinGuild", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableJoinGuild", GameMsgDef.g_sDisableJoinGuild);
            }
            else
            {
                GameMsgDef.g_sDisableJoinGuild = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableAuthAllyGuild", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableAuthAllyGuild", GameMsgDef.g_sEnableAuthAllyGuild);
            }
            else
            {
                GameMsgDef.g_sEnableAuthAllyGuild = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableAuthAllyGuild", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableAuthAllyGuild", GameMsgDef.g_sDisableAuthAllyGuild);
            }
            else
            {
                GameMsgDef.g_sDisableAuthAllyGuild = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableGroupRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableGroupRecall", GameMsgDef.g_sEnableGroupRecall);
            }
            else
            {
                GameMsgDef.g_sEnableGroupRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableGroupRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableGroupRecall", GameMsgDef.g_sDisableGroupRecall);
            }
            else
            {
                GameMsgDef.g_sDisableGroupRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "EnableGuildRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "EnableGuildRecall", GameMsgDef.g_sEnableGuildRecall);
            }
            else
            {
                GameMsgDef.g_sEnableGuildRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "DisableGuildRecall", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "DisableGuildRecall", GameMsgDef.g_sDisableGuildRecall);
            }
            else
            {
                GameMsgDef.g_sDisableGuildRecall = LoadString;
            }
            LoadString = StringConf.ReadString("String", "PleaseInputPassword", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "PleaseInputPassword", GameMsgDef.g_sPleaseInputPassword);
            }
            else
            {
                GameMsgDef.g_sPleaseInputPassword = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TheMapDisableMove", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TheMapDisableMove", GameMsgDef.g_sTheMapDisableMove);
            }
            else
            {
                GameMsgDef.g_sTheMapDisableMove = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TheMapNotFound", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TheMapNotFound", GameMsgDef.g_sTheMapNotFound);
            }
            else
            {
                GameMsgDef.g_sTheMapNotFound = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourIPaddrDenyLogon", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourIPaddrDenyLogon", GameMsgDef.g_sYourIPaddrDenyLogon);
            }
            else
            {
                GameMsgDef.g_sYourIPaddrDenyLogon = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourAccountDenyLogon", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourAccountDenyLogon", GameMsgDef.g_sYourAccountDenyLogon);
            }
            else
            {
                GameMsgDef.g_sYourAccountDenyLogon = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YourCharNameDenyLogon", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YourCharNameDenyLogon", GameMsgDef.g_sYourCharNameDenyLogon);
            }
            else
            {
                GameMsgDef.g_sYourCharNameDenyLogon = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotPickUpItem", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotPickUpItem", GameMsgDef.g_sCanotPickUpItem);
            }
            else
            {
                GameMsgDef.g_sCanotPickUpItem = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CanotSendmsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CanotSendmsg", GameMsgDef.g_sCanotSendmsg);
            }
            else
            {
                GameMsgDef.g_sCanotSendmsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "UserDenyWhisperMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "UserDenyWhisperMsg", GameMsgDef.g_sUserDenyWhisperMsg);
            }
            else
            {
                GameMsgDef.g_sUserDenyWhisperMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "UserNotOnLine", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "UserNotOnLine", GameMsgDef.g_sUserNotOnLine);
            }
            else
            {
                GameMsgDef.g_sUserNotOnLine = LoadString;
            }
            LoadString = StringConf.ReadString("String", "RevivalRecoverMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "RevivalRecoverMsg", GameMsgDef.g_sRevivalRecoverMsg);
            }
            else
            {
                GameMsgDef.g_sRevivalRecoverMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ClientVersionTooOld", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ClientVersionTooOld", GameMsgDef.g_sClientVersionTooOld);
            }
            else
            {
                GameMsgDef.g_sClientVersionTooOld = LoadString;
            }
            LoadString = StringConf.ReadString("String", "CastleGuildName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "CastleGuildName", GameMsgDef.g_sCastleGuildName);
            }
            else
            {
                GameMsgDef.g_sCastleGuildName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NoCastleGuildName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NoCastleGuildName", GameMsgDef.g_sNoCastleGuildName);
            }
            else
            {
                GameMsgDef.g_sNoCastleGuildName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WarrReNewName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WarrReNewName", GameMsgDef.g_sWarrReNewName);
            }
            else
            {
                GameMsgDef.g_sWarrReNewName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WizardReNewName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WizardReNewName", GameMsgDef.g_sWizardReNewName);
            }
            else
            {
                GameMsgDef.g_sWizardReNewName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TaosReNewName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TaosReNewName", GameMsgDef.g_sTaosReNewName);
            }
            else
            {
                GameMsgDef.g_sTaosReNewName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "RankLevelName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "RankLevelName", GameMsgDef.g_sRankLevelName);
            }
            else
            {
                GameMsgDef.g_sRankLevelName = LoadString.Replace("%s","{0}");
            }
            LoadString = StringConf.ReadString("String", "ManDearName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ManDearName", GameMsgDef.g_sManDearName);
            }
            else
            {
                GameMsgDef.g_sManDearName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "WoManDearName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "WoManDearName", GameMsgDef.g_sWoManDearName);
            }
            else
            {
                GameMsgDef.g_sWoManDearName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "MasterName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "MasterName", GameMsgDef.g_sMasterName);
            }
            else
            {
                GameMsgDef.g_sMasterName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "NoMasterName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "NoMasterName", GameMsgDef.g_sNoMasterName);
            }
            else
            {
                GameMsgDef.g_sNoMasterName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "HumanShowName", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "HumanShowName", GameMsgDef.g_sHumanShowName);
            }
            else
            {
                GameMsgDef.g_sHumanShowName = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChangePermissionMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChangePermissionMsg", GameMsgDef.g_sChangePermissionMsg);
            }
            else
            {
                GameMsgDef.g_sChangePermissionMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChangeKillMonExpRateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChangeKillMonExpRateMsg", GameMsgDef.g_sChangeKillMonExpRateMsg);
            }
            else
            {
                GameMsgDef.g_sChangeKillMonExpRateMsg = LoadString.Replace("%g", "{0}").Replace("%d", "{1}");
            }
            LoadString = StringConf.ReadString("String", "ChangePowerRateMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChangePowerRateMsg", GameMsgDef.g_sChangePowerRateMsg);
            }
            else
            {
                GameMsgDef.g_sChangePowerRateMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChangeMemberLevelMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChangeMemberLevelMsg", GameMsgDef.g_sChangeMemberLevelMsg);
            }
            else
            {
                GameMsgDef.g_sChangeMemberLevelMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ChangeMemberTypeMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ChangeMemberTypeMsg", GameMsgDef.g_sChangeMemberTypeMsg);
            }
            else
            {
                GameMsgDef.g_sChangeMemberTypeMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ScriptChangeHumanHPMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ScriptChangeHumanHPMsg", GameMsgDef.g_sScriptChangeHumanHPMsg);
            }
            else
            {
                GameMsgDef.g_sScriptChangeHumanHPMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ScriptChangeHumanMPMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ScriptChangeHumanMPMsg", GameMsgDef.g_sScriptChangeHumanMPMsg);
            }
            else
            {
                GameMsgDef.g_sScriptChangeHumanMPMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouCanotDisableSayMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouCanotDisableSayMsg", GameMsgDef.g_sDisableSayMsg);
            }
            else
            {
                GameMsgDef.g_sDisableSayMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "OnlineCountMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "OnlineCountMsg", GameMsgDef.g_sOnlineCountMsg);
            }
            else
            {
                GameMsgDef.g_sOnlineCountMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "TotalOnlineCountMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "TotalOnlineCountMsg", GameMsgDef.g_sTotalOnlineCountMsg);
            }
            else
            {
                GameMsgDef.g_sTotalOnlineCountMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouNeedLevelSendMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouNeedLevelSendMsg", GameMsgDef.g_sYouNeedLevelMsg);
            }
            else
            {
                GameMsgDef.g_sYouNeedLevelMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "ThisMapDisableSendCyCyMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "ThisMapDisableSendCyCyMsg", GameMsgDef.g_sThisMapDisableSendCyCyMsg);
            }
            else
            {
                GameMsgDef.g_sThisMapDisableSendCyCyMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouCanSendCyCyLaterMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouCanSendCyCyLaterMsg", GameMsgDef.g_sYouCanSendCyCyLaterMsg);
            }
            else
            {
                GameMsgDef.g_sYouCanSendCyCyLaterMsg = LoadString.Replace("%d", "{0}");
            }
            LoadString = StringConf.ReadString("String", "YouIsDisableSendMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouIsDisableSendMsg", GameMsgDef.g_sYouIsDisableSendMsg);
            }
            else
            {
                GameMsgDef.g_sYouIsDisableSendMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouMurderedMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouMurderedMsg", GameMsgDef.g_sYouMurderedMsg);
            }
            else
            {
                GameMsgDef.g_sYouMurderedMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouKilledByMsg", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouKilledByMsg", GameMsgDef.g_sYouKilledByMsg);
            }
            else
            {
                GameMsgDef.g_sYouKilledByMsg = LoadString;
            }
            LoadString = StringConf.ReadString("String", "YouProtectedByLawOfDefense", "");
            if (LoadString == "")
            {
                StringConf.WriteString("String", "YouProtectedByLawOfDefense", GameMsgDef.g_sYouProtectedByLawOfDefense);
            }
            else
            {
                GameMsgDef.g_sYouProtectedByLawOfDefense = LoadString;
            }
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public static void LoadConfig()
        {
            int I;
            int nLoadInteger;
            double nLoadFloat;
            string sLoadString;
            StartFixExp();
            LoadString();
            LoadGameCommand();
            LoadExp();
            LoadVarGlobal();
            // ============================================================================
            if (StringConf.ReadString("Guild", "GuildNotice", "") == "")
            {
                StringConf.WriteString("Guild", "GuildNotice", g_Config.sGuildNotice);
            }
            g_Config.sGuildNotice = StringConf.ReadString("Guild", "GuildNotice", g_Config.sGuildNotice);
            if (StringConf.ReadString("Guild", "GuildWar", "") == "")
            {
                StringConf.WriteString("Guild", "GuildWar", g_Config.sGuildWar);
            }
            g_Config.sGuildWar = StringConf.ReadString("Guild", "GuildWar", g_Config.sGuildWar);
            if (StringConf.ReadString("Guild", "GuildAll", "") == "")
            {
                StringConf.WriteString("Guild", "GuildAll", g_Config.sGuildAll);
            }
            g_Config.sGuildAll = StringConf.ReadString("Guild", "GuildAll", g_Config.sGuildAll);
            if (StringConf.ReadString("Guild", "GuildMember", "") == "")
            {
                StringConf.WriteString("Guild", "GuildMember", g_Config.sGuildMember);
            }
            g_Config.sGuildMember = StringConf.ReadString("Guild", "GuildMember", g_Config.sGuildMember);
            if (StringConf.ReadString("Guild", "GuildMemberRank", "") == "")
            {
                StringConf.WriteString("Guild", "GuildMemberRank", g_Config.sGuildMemberRank);
            }
            g_Config.sGuildMemberRank = StringConf.ReadString("Guild", "GuildMemberRank", g_Config.sGuildMemberRank);
            if (StringConf.ReadString("Guild", "GuildChief", "") == "")
            {
                StringConf.WriteString("Guild", "GuildChief", g_Config.sGuildChief);
            }
            g_Config.sGuildChief = StringConf.ReadString("Guild", "GuildChief", g_Config.sGuildChief);
            // 服务器设置
            if (Config.ReadString("Server", "ConnectionString", "") == "") //By John 2012.3.4 增加数据库连接配置
            {
                Config.WriteString("Server", "ConnectionString", g_Config.sConnectionString);
            }
            g_Config.sConnectionString = Config.ReadString("Server", "ConnectionString", g_Config.sConnectionString);
            if (Config.ReadInteger("Server", "ServerIndex", -1) < 0)
            {
                Config.WriteInteger("Server", "ServerIndex", nServerIndex);
            }
            nServerIndex = Config.ReadInteger("Server", "ServerIndex", nServerIndex);
            if (Config.ReadString("Server", "ServerName", "") == "")
            {
                Config.WriteString("Server", "ServerName", g_Config.sServerName);
            }
            g_Config.sServerName = Config.ReadString("Server", "ServerName", g_Config.sServerName);
            if (StringConf.ReadString("Server", "ServerIP", "") == "")
            {
                StringConf.WriteString("Server", "ServerIP", g_Config.sServerIPaddr);
            }
            g_Config.sServerIPaddr = StringConf.ReadString("Server", "ServerIP", g_Config.sServerIPaddr);
            if (Config.ReadInteger("Server", "Minimize", -1) < 0)
            {
                Config.WriteBool("Server", "Minimize", g_boMinimize);
            }
            g_boMinimize = Config.ReadBool("Server", "Minimize", g_boMinimize);
            if (StringConf.ReadString("Server", "WebSite", "") == "")
            {
                StringConf.WriteString("Server", "WebSite", g_Config.sWebSite);
            }
            g_Config.sWebSite = StringConf.ReadString("Server", "WebSite", g_Config.sWebSite);
            if (StringConf.ReadString("Server", "BbsSite", "") == "")
            {
                StringConf.WriteString("Server", "BbsSite", g_Config.sBbsSite);
            }
            g_Config.sBbsSite = StringConf.ReadString("Server", "BbsSite", g_Config.sBbsSite);
            if (StringConf.ReadString("Server", "ClientDownload", "") == "")
            {
                StringConf.WriteString("Server", "ClientDownload", g_Config.sClientDownload);
            }
            g_Config.sClientDownload = StringConf.ReadString("Server", "ClientDownload", g_Config.sClientDownload);
            if (StringConf.ReadString("Server", "QQ", "") == "")
            {
                StringConf.WriteString("Server", "QQ", g_Config.sQQ);
            }
            g_Config.sQQ = StringConf.ReadString("Server", "QQ", g_Config.sQQ);
            if (StringConf.ReadString("Server", "Phone", "") == "")
            {
                StringConf.WriteString("Server", "Phone", g_Config.sPhone);
            }
            g_Config.sPhone = StringConf.ReadString("Server", "Phone", g_Config.sPhone);
            if (StringConf.ReadString("Server", "BankAccount0", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount0", g_Config.sBankAccount0);
            }
            g_Config.sBankAccount0 = StringConf.ReadString("Server", "BankAccount0", g_Config.sBankAccount0);
            if (StringConf.ReadString("Server", "BankAccount1", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount1", g_Config.sBankAccount1);
            }
            g_Config.sBankAccount1 = StringConf.ReadString("Server", "BankAccount1", g_Config.sBankAccount1);
            if (StringConf.ReadString("Server", "BankAccount2", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount2", g_Config.sBankAccount2);
            }
            g_Config.sBankAccount2 = StringConf.ReadString("Server", "BankAccount2", g_Config.sBankAccount2);
            if (StringConf.ReadString("Server", "BankAccount3", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount3", g_Config.sBankAccount3);
            }
            g_Config.sBankAccount3 = StringConf.ReadString("Server", "BankAccount3", g_Config.sBankAccount3);
            if (StringConf.ReadString("Server", "BankAccount4", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount4", g_Config.sBankAccount4);
            }
            g_Config.sBankAccount4 = StringConf.ReadString("Server", "BankAccount4", g_Config.sBankAccount4);
            if (StringConf.ReadString("Server", "BankAccount5", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount5", g_Config.sBankAccount5);
            }
            g_Config.sBankAccount5 = StringConf.ReadString("Server", "BankAccount5", g_Config.sBankAccount5);
            if (StringConf.ReadString("Server", "BankAccount6", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount6", g_Config.sBankAccount6);
            }
            g_Config.sBankAccount6 = StringConf.ReadString("Server", "BankAccount6", g_Config.sBankAccount6);
            if (StringConf.ReadString("Server", "BankAccount7", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount7", g_Config.sBankAccount7);
            }
            g_Config.sBankAccount7 = StringConf.ReadString("Server", "BankAccount7", g_Config.sBankAccount7);
            if (StringConf.ReadString("Server", "BankAccount8", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount8", g_Config.sBankAccount8);
            }
            g_Config.sBankAccount8 = StringConf.ReadString("Server", "BankAccount8", g_Config.sBankAccount8);
            if (StringConf.ReadString("Server", "BankAccount9", "") == "")
            {
                StringConf.WriteString("Server", "BankAccount9", g_Config.sBankAccount9);
            }
            g_Config.sBankAccount9 = StringConf.ReadString("Server", "BankAccount9", g_Config.sBankAccount9);
            if (Config.ReadInteger("Server", "ServerNumber", -1) < 0)
            {
                Config.WriteInteger("Server", "ServerNumber", g_Config.nServerNumber);
            }
            g_Config.nServerNumber = Config.ReadInteger("Server", "ServerNumber", g_Config.nServerNumber);
            if (Config.ReadString("Server", "VentureServer", "") == "")
            {
                Config.WriteString("Server", "VentureServer", HUtil32.BoolToStr(g_Config.boVentureServer));
            }
            g_Config.boVentureServer = (Config.ReadString("Server", "VentureServer", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadString("Server", "TestServer", "") == "")
            {
                Config.WriteString("Server", "TestServer", HUtil32.BoolToStr(g_Config.boTestServer));
            }
            g_Config.boTestServer = (Config.ReadString("Server", "TestServer", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadInteger("Server", "TestLevel", -1) < 0)
            {
                Config.WriteInteger("Server", "TestLevel", g_Config.nTestLevel);
            }
            g_Config.nTestLevel = Config.ReadInteger("Server", "TestLevel", g_Config.nTestLevel);
            if (Config.ReadInteger("Server", "TestGold", -1) < 0)
            {
                Config.WriteInteger("Server", "TestGold", g_Config.nTestGold);
            }
            g_Config.nTestGold = Config.ReadInteger("Server", "TestGold", g_Config.nTestGold);
            if (Config.ReadInteger("Server", "TestServerUserLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "TestServerUserLimit", g_Config.nTestUserLimit);
            }
            g_Config.nTestUserLimit = Config.ReadInteger("Server", "TestServerUserLimit", g_Config.nTestUserLimit);
            if (Config.ReadString("Server", "ServiceMode", "") == "")
            {
                Config.WriteString("Server", "ServiceMode", HUtil32.BoolToStr(g_Config.boServiceMode));
            }
            g_Config.boServiceMode = (Config.ReadString("Server", "ServiceMode", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadString("Server", "NonPKServer", "") == "")
            {
                Config.WriteString("Server", "NonPKServer", HUtil32.BoolToStr(g_Config.boNonPKServer));
            }
            g_Config.boNonPKServer = (Config.ReadString("Server", "NonPKServer", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadString("Server", "ViewHackMessage", "") == "")
            {
                Config.WriteString("Server", "ViewHackMessage", HUtil32.BoolToStr(g_Config.boViewHackMessage));
            }
            g_Config.boViewHackMessage = (Config.ReadString("Server", "ViewHackMessage", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadString("Server", "ViewAdmissionFailure", "") == "")
            {
                Config.WriteString("Server", "ViewAdmissionFailure", HUtil32.BoolToStr(g_Config.boViewAdmissionFailure));
            }
            g_Config.boViewAdmissionFailure = (Config.ReadString("Server", "ViewAdmissionFailure", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadString("Server", "DBName", "") == "")
            {
                Config.WriteString("Server", "DBName", sDBName);
            }
            sDBName = Config.ReadString("Server", "DBName", sDBName);
            if (Config.ReadString("Server", "GateAddr", "") == "")
            {
                Config.WriteString("Server", "GateAddr", g_Config.sGateAddr);
            }
            g_Config.sGateAddr = Config.ReadString("Server", "GateAddr", g_Config.sGateAddr);
            if (Config.ReadInteger("Server", "GatePort", -1) < 0)
            {
                Config.WriteInteger("Server", "GatePort", g_Config.nGatePort);
            }
            g_Config.nGatePort = Config.ReadInteger("Server", "GatePort", g_Config.nGatePort);
            if (Config.ReadString("Server", "DBAddr", "") == "")
            {
                Config.WriteString("Server", "DBAddr", g_Config.sDBAddr);
            }
            g_Config.sDBAddr = Config.ReadString("Server", "DBAddr", g_Config.sDBAddr);
            if (Config.ReadInteger("Server", "DBPort", -1) < 0)
            {
                Config.WriteInteger("Server", "DBPort", g_Config.nDBPort);
            }
            g_Config.nDBPort = Config.ReadInteger("Server", "DBPort", g_Config.nDBPort);
            if (Config.ReadString("Server", "IDSAddr", "") == "")
            {
                Config.WriteString("Server", "IDSAddr", g_Config.sIDSAddr);
            }
            g_Config.sIDSAddr = Config.ReadString("Server", "IDSAddr", g_Config.sIDSAddr);
            if (Config.ReadInteger("Server", "IDSPort", -1) < 0)
            {
                Config.WriteInteger("Server", "IDSPort", g_Config.nIDSPort);
            }
            g_Config.nIDSPort = Config.ReadInteger("Server", "IDSPort", g_Config.nIDSPort);
            if (Config.ReadString("Server", "MsgSrvAddr", "") == "")
            {
                Config.WriteString("Server", "MsgSrvAddr", g_Config.sMsgSrvAddr);
            }
            g_Config.sMsgSrvAddr = Config.ReadString("Server", "MsgSrvAddr", g_Config.sMsgSrvAddr);
            if (Config.ReadInteger("Server", "MsgSrvPort", -1) < 0)
            {
                Config.WriteInteger("Server", "MsgSrvPort", g_Config.nMsgSrvPort);
            }
            g_Config.nMsgSrvPort = Config.ReadInteger("Server", "MsgSrvPort", g_Config.nMsgSrvPort);
            if (Config.ReadString("Server", "LogServerAddr", "") == "")
            {
                Config.WriteString("Server", "LogServerAddr", g_Config.sLogServerAddr);
            }
            g_Config.sLogServerAddr = Config.ReadString("Server", "LogServerAddr", g_Config.sLogServerAddr);
            if (Config.ReadInteger("Server", "LogServerPort", -1) < 0)
            {
                Config.WriteInteger("Server", "LogServerPort", g_Config.nLogServerPort);
            }
            g_Config.nLogServerPort = Config.ReadInteger("Server", "LogServerPort", g_Config.nLogServerPort);
            if (Config.ReadString("Server", "DiscountForNightTime", "") == "")
            {
                Config.WriteString("Server", "DiscountForNightTime", HUtil32.BoolToStr(g_Config.boDiscountForNightTime));
            }
            g_Config.boDiscountForNightTime = (Config.ReadString("Server", "DiscountForNightTime", "FALSE")).ToLower().CompareTo(("TRUE").ToLower()) == 0;
            if (Config.ReadInteger("Server", "HalfFeeStart", -1) < 0)
            {
                Config.WriteInteger("Server", "HalfFeeStart", g_Config.nHalfFeeStart);
            }
            g_Config.nHalfFeeStart = Config.ReadInteger("Server", "HalfFeeStart", g_Config.nHalfFeeStart);
            if (Config.ReadInteger("Server", "HalfFeeEnd", -1) < 0)
            {
                Config.WriteInteger("Server", "HalfFeeEnd", g_Config.nHalfFeeEnd);
            }
            g_Config.nHalfFeeEnd = Config.ReadInteger("Server", "HalfFeeEnd", g_Config.nHalfFeeEnd);
            if (Config.ReadInteger("Server", "HumLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "HumLimit", g_dwHumLimit);
            }
            g_dwHumLimit = Config.ReadInteger("Server", "HumLimit", g_dwHumLimit);
            if (Config.ReadInteger("Server", "MonLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "MonLimit", g_dwMonLimit);
            }
            g_dwMonLimit = Config.ReadInteger("Server", "MonLimit", g_dwMonLimit);
            if (Config.ReadInteger("Server", "ZenLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "ZenLimit", g_dwZenLimit);
            }
            g_dwZenLimit = Config.ReadInteger("Server", "ZenLimit", g_dwZenLimit);
            if (Config.ReadInteger("Server", "NpcLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "NpcLimit", g_dwNpcLimit);
            }
            g_dwNpcLimit = Config.ReadInteger("Server", "NpcLimit", g_dwNpcLimit);
            if (Config.ReadInteger("Server", "SocLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "SocLimit", g_dwSocLimit);
            }
            g_dwSocLimit = Config.ReadInteger("Server", "SocLimit", g_dwSocLimit);
            if (Config.ReadInteger("Server", "DecLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "DecLimit", nDecLimit);
            }
            nDecLimit = Config.ReadInteger("Server", "DecLimit", nDecLimit);
            if (Config.ReadInteger("Server", "SendBlock", -1) < 0)
            {
                Config.WriteInteger("Server", "SendBlock", g_Config.nSendBlock);
            }
            g_Config.nSendBlock = Config.ReadInteger("Server", "SendBlock", g_Config.nSendBlock);
            if (Config.ReadInteger("Server", "CheckBlock", -1) < 0)
            {
                Config.WriteInteger("Server", "CheckBlock", g_Config.nCheckBlock);
            }
            g_Config.nCheckBlock = Config.ReadInteger("Server", "CheckBlock", g_Config.nCheckBlock);
            if (Config.ReadInteger("Server", "SocCheckTimeOut", -1) < 0)
            {
                Config.WriteInteger("Server", "SocCheckTimeOut", g_dwSocCheckTimeOut);
            }
            g_dwSocCheckTimeOut = Config.ReadInteger("Server", "SocCheckTimeOut", g_dwSocCheckTimeOut);
            if (Config.ReadInteger("Server", "AvailableBlock", -1) < 0)
            {
                Config.WriteInteger("Server", "AvailableBlock", g_Config.nAvailableBlock);
            }
            g_Config.nAvailableBlock = Config.ReadInteger("Server", "AvailableBlock", g_Config.nAvailableBlock);
            if (Config.ReadInteger("Server", "GateLoad", -1) < 0)
            {
                Config.WriteInteger("Server", "GateLoad", g_Config.nGateLoad);
            }
            g_Config.nGateLoad = Config.ReadInteger("Server", "GateLoad", g_Config.nGateLoad);
            if (Config.ReadInteger("Server", "UserFull", -1) < 0)
            {
                Config.WriteInteger("Server", "UserFull", g_Config.nUserFull);
            }
            g_Config.nUserFull = Config.ReadInteger("Server", "UserFull", g_Config.nUserFull);
            if (Config.ReadInteger("Server", "ZenFastStep", -1) < 0)
            {
                Config.WriteInteger("Server", "ZenFastStep", g_Config.nZenFastStep);
            }
            g_Config.nZenFastStep = Config.ReadInteger("Server", "ZenFastStep", g_Config.nZenFastStep);
            if (Config.ReadInteger("Server", "ProcessMonstersTime", -1) < 0)
            {
                Config.WriteInteger("Server", "ProcessMonstersTime", g_Config.dwProcessMonstersTime);
            }
            g_Config.dwProcessMonstersTime = Config.ReadInteger("Server", "ProcessMonstersTime", g_Config.dwProcessMonstersTime);
            if (Config.ReadInteger("Server", "RegenMonstersTime", -1) < 0)
            {
                Config.WriteInteger("Server", "RegenMonstersTime", g_Config.dwRegenMonstersTime);
            }
            g_Config.dwRegenMonstersTime = Config.ReadInteger("Server", "RegenMonstersTime", g_Config.dwRegenMonstersTime);
            if (Config.ReadInteger("Server", "HumanGetMsgTimeLimit", -1) < 0)
            {
                Config.WriteInteger("Server", "HumanGetMsgTimeLimit", g_Config.dwHumanGetMsgTime);
            }
            g_Config.dwHumanGetMsgTime = Config.ReadInteger("Server", "HumanGetMsgTimeLimit", g_Config.dwHumanGetMsgTime);
            // ============================================================================
            // 目录设置
            if (Config.ReadString("Share", "BaseDir", "") == "")
            {
                Config.WriteString("Share", "BaseDir", g_Config.sBaseDir);
            }
            g_Config.sBaseDir = Config.ReadString("Share", "BaseDir", g_Config.sBaseDir);
            if (Config.ReadString("Share", "GuildDir", "") == "")
            {
                Config.WriteString("Share", "GuildDir", g_Config.sGuildDir);
            }
            g_Config.sGuildDir = Config.ReadString("Share", "GuildDir", g_Config.sGuildDir);
            if (Config.ReadString("Share", "GuildFile", "") == "")
            {
                Config.WriteString("Share", "GuildFile", g_Config.sGuildFile);
            }
            g_Config.sGuildFile = Config.ReadString("Share", "GuildFile", g_Config.sGuildFile);
            if (Config.ReadString("Share", "VentureDir", "") == "")
            {
                Config.WriteString("Share", "VentureDir", g_Config.sVentureDir);
            }
            g_Config.sVentureDir = Config.ReadString("Share", "VentureDir", g_Config.sVentureDir);
            if (Config.ReadString("Share", "ConLogDir", "") == "")
            {
                Config.WriteString("Share", "ConLogDir", g_Config.sConLogDir);
            }
            g_Config.sConLogDir = Config.ReadString("Share", "ConLogDir", g_Config.sConLogDir);
            if (Config.ReadString("Share", "CastleDir", "") == "")
            {
                Config.WriteString("Share", "CastleDir", g_Config.sCastleDir);
            }
            g_Config.sCastleDir = Config.ReadString("Share", "CastleDir", g_Config.sCastleDir);
            // 沙巴克文件
            if (Config.ReadString("Share", "CastleFile", "") == "")
            {
                Config.WriteString("Share", "CastleFile", g_Config.sCastleDir + "List.txt");
            }
            g_Config.sCastleFile = Config.ReadString("Share", "CastleFile", g_Config.sCastleFile);
            // 排行榜路径 20080220
            if (Config.ReadString("Share", "SortDir", "") == "")
            {
                Config.WriteString("Share", "SortDir", g_Config.sSortDir);
            }
            g_Config.sSortDir = Config.ReadString("Share", "SortDir", g_Config.sSortDir);
            // ------------------------------------------------------------------------------
            // 宝箱路径,文件 20080114
            if (Config.ReadString("Share", "BoxsDir", "") == "")
            {
                Config.WriteString("Share", "BoxsDir", g_Config.sBoxsDir);
            }
            g_Config.sBoxsDir = Config.ReadString("Share", "BoxsDir", g_Config.sBoxsDir);
            if (Config.ReadString("Share", "BoxsFile", "") == "")
            {
                Config.WriteString("Share", "BoxsFile", g_Config.sBoxsFile);
            }
            g_Config.sBoxsFile = Config.ReadString("Share", "BoxsFile", g_Config.sBoxsFile);
            // ------------------------------------------------------------------------------
            if (Config.ReadString("Share", "EnvirDir", "") == "")
            {
                Config.WriteString("Share", "EnvirDir", g_Config.sEnvirDir);
            }
            g_Config.sEnvirDir = Config.ReadString("Share", "EnvirDir", g_Config.sEnvirDir);
            if (Config.ReadString("Share", "MapDir", "") == "")
            {
                Config.WriteString("Share", "MapDir", g_Config.sMapDir);
            }
            g_Config.sMapDir = Config.ReadString("Share", "MapDir", g_Config.sMapDir);
            if (Config.ReadString("Share", "NoticeDir", "") == "")
            {
                Config.WriteString("Share", "NoticeDir", g_Config.sNoticeDir);
            }
            g_Config.sNoticeDir = Config.ReadString("Share", "NoticeDir", g_Config.sNoticeDir);
            sLoadString = Config.ReadString("Share", "LogDir", "");
            if (sLoadString == "")
            {
                Config.WriteString("Share", "LogDir", g_Config.sLogDir);
            }
            else
            {
                g_Config.sLogDir = sLoadString;
            }
            if (Config.ReadString("Share", "PlugDir", "") == "")
            {
                Config.WriteString("Share", "PlugDir", g_Config.sPlugDir);
            }
            g_Config.sPlugDir = Config.ReadString("Share", "PlugDir", g_Config.sPlugDir);
            // ============================================================================
            // 名称设置
            if (Config.ReadString("Names", "HealSkill", "") == "")
            {
                Config.WriteString("Names", "HealSkill", g_Config.sHealSkill);
            }
            g_Config.sHealSkill = Config.ReadString("Names", "HealSkill", g_Config.sHealSkill);
            if (Config.ReadString("Names", "FireBallSkill", "") == "")
            {
                Config.WriteString("Names", "FireBallSkill", g_Config.sFireBallSkill);
            }
            g_Config.sFireBallSkill = Config.ReadString("Names", "FireBallSkill", g_Config.sFireBallSkill);
            if (Config.ReadString("Names", "HeavenSKill", "") == "")
            {
                Config.WriteString("Names", "HeavenSKill", g_Config.sHeavenSKill);
            }
            g_Config.sHeavenSKill = Config.ReadString("Names", "HeavenSKill", g_Config.sHeavenSKill);
            if (Config.ReadString("Names", "MeteorSKill", "") == "")
            {
                Config.WriteString("Names", "MeteorSKill", g_Config.MeteorSKill);
            }
            g_Config.MeteorSKill = Config.ReadString("Names", "MeteorSKill", g_Config.MeteorSKill);
            if (Config.ReadString("Names", "ClothsMan", "") == "")
            {
                Config.WriteString("Names", "ClothsMan", g_Config.sClothsMan);
            }
            g_Config.sClothsMan = Config.ReadString("Names", "ClothsMan", g_Config.sClothsMan);
            if (Config.ReadString("Names", "ClothsWoman", "") == "")
            {
                Config.WriteString("Names", "ClothsWoman", g_Config.sClothsWoman);
            }
            g_Config.sClothsWoman = Config.ReadString("Names", "ClothsWoman", g_Config.sClothsWoman);
            if (Config.ReadString("Names", "WoodenSword", "") == "")
            {
                Config.WriteString("Names", "WoodenSword", g_Config.sWoodenSword);
            }
            g_Config.sWoodenSword = Config.ReadString("Names", "WoodenSword", g_Config.sWoodenSword);
            if (Config.ReadString("Names", "Candle", "") == "")
            {
                Config.WriteString("Names", "Candle", g_Config.sCandle);
            }
            g_Config.sCandle = Config.ReadString("Names", "Candle", g_Config.sCandle);
            if (Config.ReadString("Names", "BasicDrug", "") == "")
            {
                Config.WriteString("Names", "BasicDrug", g_Config.sBasicDrug);
            }
            g_Config.sBasicDrug = Config.ReadString("Names", "BasicDrug", g_Config.sBasicDrug);
            if (Config.ReadString("Names", "GoldStone", "") == "")
            {
                Config.WriteString("Names", "GoldStone", g_Config.sGoldStone);
            }
            g_Config.sGoldStone = Config.ReadString("Names", "GoldStone", g_Config.sGoldStone);
            if (Config.ReadString("Names", "SilverStone", "") == "")
            {
                Config.WriteString("Names", "SilverStone", g_Config.sSilverStone);
            }
            g_Config.sSilverStone = Config.ReadString("Names", "SilverStone", g_Config.sSilverStone);
            if (Config.ReadString("Names", "SteelStone", "") == "")
            {
                Config.WriteString("Names", "SteelStone", g_Config.sSteelStone);
            }
            g_Config.sSteelStone = Config.ReadString("Names", "SteelStone", g_Config.sSteelStone);
            if (Config.ReadString("Names", "CopperStone", "") == "")
            {
                Config.WriteString("Names", "CopperStone", g_Config.sCopperStone);
            }
            g_Config.sCopperStone = Config.ReadString("Names", "CopperStone", g_Config.sCopperStone);
            if (Config.ReadString("Names", "BlackStone", "") == "")
            {
                Config.WriteString("Names", "BlackStone", g_Config.sBlackStone);
            }
            g_Config.sBlackStone = Config.ReadString("Names", "BlackStone", g_Config.sBlackStone);
            if (Config.ReadString("Names", "Zuma1", "") == "")
            {
                Config.WriteString("Names", "Zuma1", g_Config.sZuma[0]);
            }
            g_Config.sZuma[0] = Config.ReadString("Names", "Zuma1", g_Config.sZuma[0]);
            if (Config.ReadString("Names", "Zuma2", "") == "")
            {
                Config.WriteString("Names", "Zuma2", g_Config.sZuma[0]);
            }
            g_Config.sZuma[0] = Config.ReadString("Names", "Zuma2", g_Config.sZuma[0]);
            if (Config.ReadString("Names", "Zuma3", "") == "")
            {
                Config.WriteString("Names", "Zuma3", g_Config.sZuma[2]);
            }
            g_Config.sZuma[2] = Config.ReadString("Names", "Zuma3", g_Config.sZuma[2]);
            if (Config.ReadString("Names", "Zuma4", "") == "")
            {
                Config.WriteString("Names", "Zuma4", g_Config.sZuma[3]);
            }
            g_Config.sZuma[3] = Config.ReadString("Names", "Zuma4", g_Config.sZuma[3]);
            if (Config.ReadString("Names", "Bee", "") == "")
            {
                Config.WriteString("Names", "Bee", g_Config.sBee);
            }
            g_Config.sBee = Config.ReadString("Names", "Bee", g_Config.sBee);
            if (Config.ReadString("Names", "Spider", "") == "")
            {
                Config.WriteString("Names", "Spider", g_Config.sSpider);
            }
            g_Config.sSpider = Config.ReadString("Names", "Spider", g_Config.sSpider);
            if (Config.ReadString("Names", "WomaHorn", "") == "")
            {
                Config.WriteString("Names", "WomaHorn", g_Config.sWomaHorn);
            }
            g_Config.sWomaHorn = Config.ReadString("Names", "WomaHorn", g_Config.sWomaHorn);
            if (Config.ReadString("Names", "ZumaPiece", "") == "")
            {
                Config.WriteString("Names", "ZumaPiece", g_Config.sZumaPiece);
            }
            g_Config.sZumaPiece = Config.ReadString("Names", "ZumaPiece", g_Config.sZumaPiece);
            if (Config.ReadString("Names", "Dogz", "") == "")
            {
                Config.WriteString("Names", "Dogz", g_Config.sDogz);
            }
            g_Config.sDogz = Config.ReadString("Names", "Dogz", g_Config.sDogz);
            // 月灵
            if (Config.ReadString("Names", "Fairy", "") == "")
            {
                Config.WriteString("Names", "Fairy", g_Config.sFairy);
            }
            g_Config.sFairy = Config.ReadString("Names", "Fairy", g_Config.sFairy);
            if (Config.ReadString("Names", "BoneFamm", "") == "")
            {
                Config.WriteString("Names", "BoneFamm", g_Config.sBoneFamm);
            }
            g_Config.sBoneFamm = Config.ReadString("Names", "BoneFamm", g_Config.sBoneFamm);
            sLoadString = Config.ReadString("Names", "GameGold", "");
            if (sLoadString == "")
            {
                Config.WriteString("Names", "GameGold", g_Config.sGameGoldName);
            }
            else
            {
                g_Config.sGameGoldName = sLoadString;
            }
            // 金刚石
            sLoadString = Config.ReadString("Names", "GameDiaMond", "");
            if (sLoadString == "")
            {
                Config.WriteString("Names", "GameDiaMond", g_Config.sGameDiaMond);
            }
            else
            {
                g_Config.sGameDiaMond = sLoadString;
            }
            // 灵符
            sLoadString = Config.ReadString("Names", "GameGird", "");
            if (sLoadString == "")
            {
                Config.WriteString("Names", "GameGird", g_Config.sGameGird);
            }
            else
            {
                g_Config.sGameGird = sLoadString;
            }
            // 荣誉
            sLoadString = Config.ReadString("Names", "GameGlory", "");
            if (sLoadString == "")
            {
                Config.WriteString("Names", "GameGlory", g_Config.sGameGlory);
            }
            else
            {
                g_Config.sGameGlory = sLoadString;
            }
            sLoadString = Config.ReadString("Names", "GamePoint", "");
            if (sLoadString == "")
            {
                Config.WriteString("Names", "GamePoint", g_Config.sGamePointName);
            }
            else
            {
                g_Config.sGamePointName = sLoadString;
            }
            sLoadString = Config.ReadString("Names", "PayMentPointName", "");
            if (sLoadString == "")
            {
                Config.WriteString("Names", "PayMentPointName", g_Config.sPayMentPointName);
            }
            else
            {
                g_Config.sPayMentPointName = sLoadString;
            }
            // ============================================================================
            // 游戏设置
            if (Config.ReadInteger("Setup", "ItemNumber", -1) < 0)
            {
                Config.WriteInteger("Setup", "ItemNumber", g_Config.nItemNumber);
            }
            g_Config.nItemNumber = Config.ReadInteger("Setup", "ItemNumber", g_Config.nItemNumber);
            if (Config.ReadInteger("Setup", "ItemNumberEx", -1) < 0)
            {
                Config.WriteInteger("Setup", "ItemNumberEx", g_Config.nItemNumberEx);
            }
            g_Config.nItemNumberEx = Config.ReadInteger("Setup", "ItemNumberEx", g_Config.nItemNumberEx);
            if (Config.ReadString("Setup", "ClientFile1", "") == "")
            {
                Config.WriteString("Setup", "ClientFile1", g_Config.sClientFile1);
            }
            g_Config.sClientFile1 = Config.ReadString("Setup", "ClientFile1", g_Config.sClientFile1);
            if (Config.ReadInteger("Setup", "MonUpLvNeedKillBase", -1) < 0)
            {
                Config.WriteInteger("Setup", "MonUpLvNeedKillBase", g_Config.nMonUpLvNeedKillBase);
            }
            g_Config.nMonUpLvNeedKillBase = Config.ReadInteger("Setup", "MonUpLvNeedKillBase", g_Config.nMonUpLvNeedKillBase);
            if (Config.ReadInteger("Setup", "MonUpLvRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "MonUpLvRate", g_Config.nMonUpLvRate);
            }
            g_Config.nMonUpLvRate = Config.ReadInteger("Setup", "MonUpLvRate", g_Config.nMonUpLvRate);
            for (I = g_Config.MonUpLvNeedKillCount.GetLowerBound(0); I <= g_Config.MonUpLvNeedKillCount.GetUpperBound(0); I++)
            {
                if (Config.ReadInteger("Setup", "MonUpLvNeedKillCount" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "MonUpLvNeedKillCount" + I, g_Config.MonUpLvNeedKillCount[I]);
                }
                g_Config.MonUpLvNeedKillCount[I] = Config.ReadInteger("Setup", "MonUpLvNeedKillCount" + I, g_Config.MonUpLvNeedKillCount[I]);
            }
            for (I = g_Config.SlaveColor.GetLowerBound(0); I <= g_Config.SlaveColor.GetUpperBound(0); I++)
            {
                if (Config.ReadInteger("Setup", "SlaveColor" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "SlaveColor" + I, g_Config.SlaveColor[I]);
                }
                g_Config.SlaveColor[I] = Config.ReadInteger("Setup", "SlaveColor" + I, g_Config.SlaveColor[I]);
            }
            if (Config.ReadString("Setup", "HomeMap", "") == "")
            {
                Config.WriteString("Setup", "HomeMap", g_Config.sHomeMap);
            }
            g_Config.sHomeMap = Config.ReadString("Setup", "HomeMap", g_Config.sHomeMap);
            if (Config.ReadInteger("Setup", "HomeX", -1) < 0)
            {
                Config.WriteInteger("Setup", "HomeX", g_Config.nHomeX);
            }
            g_Config.nHomeX = Config.ReadInteger("Setup", "HomeX", g_Config.nHomeX);
            if (Config.ReadInteger("Setup", "HomeY", -1) < 0)
            {
                Config.WriteInteger("Setup", "HomeY", g_Config.nHomeY);
            }
            g_Config.nHomeY = Config.ReadInteger("Setup", "HomeY", g_Config.nHomeY);
            if (Config.ReadString("Setup", "RedHomeMap", "") == "")
            {
                Config.WriteString("Setup", "RedHomeMap", g_Config.sRedHomeMap);
            }
            g_Config.sRedHomeMap = Config.ReadString("Setup", "RedHomeMap", g_Config.sRedHomeMap);
            if (Config.ReadInteger("Setup", "RedHomeX", -1) < 0)
            {
                Config.WriteInteger("Setup", "RedHomeX", g_Config.nRedHomeX);
            }
            g_Config.nRedHomeX = Config.ReadInteger("Setup", "RedHomeX", g_Config.nRedHomeX);
            if (Config.ReadInteger("Setup", "RedHomeY", -1) < 0)
            {
                Config.WriteInteger("Setup", "RedHomeY", g_Config.nRedHomeY);
            }
            g_Config.nRedHomeY = Config.ReadInteger("Setup", "RedHomeY", g_Config.nRedHomeY);
            if (Config.ReadString("Setup", "RedDieHomeMap", "") == "")
            {
                Config.WriteString("Setup", "RedDieHomeMap", g_Config.sRedDieHomeMap);
            }
            g_Config.sRedDieHomeMap = Config.ReadString("Setup", "RedDieHomeMap", g_Config.sRedDieHomeMap);
            if (Config.ReadInteger("Setup", "RedDieHomeX", -1) < 0)
            {
                Config.WriteInteger("Setup", "RedDieHomeX", g_Config.nRedDieHomeX);
            }
            g_Config.nRedDieHomeX = Config.ReadInteger("Setup", "RedDieHomeX", g_Config.nRedDieHomeX);
            if (Config.ReadInteger("Setup", "RedDieHomeY", -1) < 0)
            {
                Config.WriteInteger("Setup", "RedDieHomeY", g_Config.nRedDieHomeY);
            }
            g_Config.nRedDieHomeY = Config.ReadInteger("Setup", "RedDieHomeY", g_Config.nRedDieHomeY);
            nLoadInteger = Config.ReadInteger("Setup", "HealthFillTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "HealthFillTime", g_Config.nHealthFillTime);
            }
            else
            {
                g_Config.nHealthFillTime = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "SpellFillTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "SpellFillTime", g_Config.nSpellFillTime);
            }
            else
            {
                g_Config.nSpellFillTime = nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "DecPkPointTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "DecPkPointTime", g_Config.dwDecPkPointTime);
            }
            g_Config.dwDecPkPointTime = Config.ReadInteger("Setup", "DecPkPointTime", g_Config.dwDecPkPointTime);
            if (Config.ReadInteger("Setup", "DecPkPointCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "DecPkPointCount", g_Config.nDecPkPointCount);
            }
            g_Config.nDecPkPointCount = Config.ReadInteger("Setup", "DecPkPointCount", g_Config.nDecPkPointCount);
            if (Config.ReadInteger("Setup", "PKFlagTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "PKFlagTime", g_Config.dwPKFlagTime);
            }
            g_Config.dwPKFlagTime = Config.ReadInteger("Setup", "PKFlagTime", g_Config.dwPKFlagTime);// 杀人武器被诅咒机率
            if (Config.ReadInteger("Setup", "KillHumanWeaponUnlockRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "KillHumanWeaponUnlockRate", g_Config.nKillHumanWeaponUnlockRate);
            }
            g_Config.nKillHumanWeaponUnlockRate = Config.ReadInteger("Setup", "KillHumanWeaponUnlockRate", g_Config.nKillHumanWeaponUnlockRate);
            if (Config.ReadInteger("Setup", "KillHumanAddPKPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "KillHumanAddPKPoint", g_Config.nKillHumanAddPKPoint);
            }
            g_Config.nKillHumanAddPKPoint = Config.ReadInteger("Setup", "KillHumanAddPKPoint", g_Config.nKillHumanAddPKPoint);
            if (Config.ReadInteger("Setup", "KillHumanDecLuckPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "KillHumanDecLuckPoint", g_Config.nKillHumanDecLuckPoint);
            }
            g_Config.nKillHumanDecLuckPoint = Config.ReadInteger("Setup", "KillHumanDecLuckPoint", g_Config.nKillHumanDecLuckPoint);
            if (Config.ReadInteger("Setup", "DecLightItemDrugTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "DecLightItemDrugTime", g_Config.dwDecLightItemDrugTime);
            }
            g_Config.dwDecLightItemDrugTime = Config.ReadInteger("Setup", "DecLightItemDrugTime", g_Config.dwDecLightItemDrugTime);
            if (Config.ReadInteger("Setup", "SafeZoneSize", -1) < 0)
            {
                Config.WriteInteger("Setup", "SafeZoneSize", g_Config.nSafeZoneSize);
            }
            g_Config.nSafeZoneSize = Config.ReadInteger("Setup", "SafeZoneSize", g_Config.nSafeZoneSize);
            if (Config.ReadInteger("Setup", "StartPointSize", -1) < 0)
            {
                Config.WriteInteger("Setup", "StartPointSize", g_Config.nStartPointSize);
            }
            g_Config.nStartPointSize = Config.ReadInteger("Setup", "StartPointSize", g_Config.nStartPointSize);
            for (I = g_Config.ReNewNameColor.GetLowerBound(0); I <= g_Config.ReNewNameColor.GetUpperBound(0); I++)
            {
                if (Config.ReadInteger("Setup", "ReNewNameColor" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "ReNewNameColor" + I, g_Config.ReNewNameColor[I]);
                }
                g_Config.ReNewNameColor[I] = Config.ReadInteger("Setup", "ReNewNameColor" + I, g_Config.ReNewNameColor[I]);
            }
            if (Config.ReadInteger("Setup", "ReNewNameColorTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "ReNewNameColorTime", g_Config.dwReNewNameColorTime);
            }
            g_Config.dwReNewNameColorTime = Config.ReadInteger("Setup", "ReNewNameColorTime", g_Config.dwReNewNameColorTime);
            if (Config.ReadInteger("Setup", "ReNewChangeColor", -1) < 0)
            {
                Config.WriteBool("Setup", "ReNewChangeColor", g_Config.boReNewChangeColor);
            }
            g_Config.boReNewChangeColor = Config.ReadBool("Setup", "ReNewChangeColor", g_Config.boReNewChangeColor);
            if (Config.ReadInteger("Setup", "ReNewLevelClearExp", -1) < 0)
            {
                Config.WriteBool("Setup", "ReNewLevelClearExp", g_Config.boReNewLevelClearExp);
            }
            g_Config.boReNewLevelClearExp = Config.ReadBool("Setup", "ReNewLevelClearExp", g_Config.boReNewLevelClearExp);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrDC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrDC", g_Config.BonusAbilofWarr.DC);
            }
            g_Config.BonusAbilofWarr.DC = Config.ReadInteger("Setup", "BonusAbilofWarrDC", g_Config.BonusAbilofWarr.DC);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrMC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrMC", g_Config.BonusAbilofWarr.MC);
            }
            g_Config.BonusAbilofWarr.MC = Config.ReadInteger("Setup", "BonusAbilofWarrMC", g_Config.BonusAbilofWarr.MC);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrSC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrSC", g_Config.BonusAbilofWarr.SC);
            }
            g_Config.BonusAbilofWarr.SC = Config.ReadInteger("Setup", "BonusAbilofWarrSC", g_Config.BonusAbilofWarr.SC);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrAC", g_Config.BonusAbilofWarr.AC);
            }
            g_Config.BonusAbilofWarr.AC = Config.ReadInteger("Setup", "BonusAbilofWarrAC", g_Config.BonusAbilofWarr.AC);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrMAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrMAC", g_Config.BonusAbilofWarr.MAC);
            }
            g_Config.BonusAbilofWarr.MAC = Config.ReadInteger("Setup", "BonusAbilofWarrMAC", g_Config.BonusAbilofWarr.MAC);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrHP", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrHP", g_Config.BonusAbilofWarr.HP);
            }
            g_Config.BonusAbilofWarr.HP = Config.ReadInteger("Setup", "BonusAbilofWarrHP", g_Config.BonusAbilofWarr.HP);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrMP", g_Config.BonusAbilofWarr.MP);
            }
            g_Config.BonusAbilofWarr.MP = Config.ReadInteger("Setup", "BonusAbilofWarrMP", g_Config.BonusAbilofWarr.MP);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrHit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrHit", g_Config.BonusAbilofWarr.Hit);
            }
            g_Config.BonusAbilofWarr.Hit = Config.ReadInteger("Setup", "BonusAbilofWarrHit", g_Config.BonusAbilofWarr.Hit);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrSpeed", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrSpeed", g_Config.BonusAbilofWarr.Speed);
            }
            g_Config.BonusAbilofWarr.Speed = Config.ReadInteger("Setup", "BonusAbilofWarrSpeed", g_Config.BonusAbilofWarr.Speed);
            if (Config.ReadInteger("Setup", "BonusAbilofWarrX2", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWarrX2", g_Config.BonusAbilofWarr.X2);
            }
            g_Config.BonusAbilofWarr.X2 = Config.ReadInteger("Setup", "BonusAbilofWarrX2", g_Config.BonusAbilofWarr.X2);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardDC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardDC", g_Config.BonusAbilofWizard.DC);
            }
            g_Config.BonusAbilofWizard.DC = Config.ReadInteger("Setup", "BonusAbilofWizardDC", g_Config.BonusAbilofWizard.DC);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardMC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardMC", g_Config.BonusAbilofWizard.MC);
            }
            g_Config.BonusAbilofWizard.MC = Config.ReadInteger("Setup", "BonusAbilofWizardMC", g_Config.BonusAbilofWizard.MC);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardSC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardSC", g_Config.BonusAbilofWizard.SC);
            }
            g_Config.BonusAbilofWizard.SC = Config.ReadInteger("Setup", "BonusAbilofWizardSC", g_Config.BonusAbilofWizard.SC);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardAC", g_Config.BonusAbilofWizard.AC);
            }
            g_Config.BonusAbilofWizard.AC = Config.ReadInteger("Setup", "BonusAbilofWizardAC", g_Config.BonusAbilofWizard.AC);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardMAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardMAC", g_Config.BonusAbilofWizard.MAC);
            }
            g_Config.BonusAbilofWizard.MAC = Config.ReadInteger("Setup", "BonusAbilofWizardMAC", g_Config.BonusAbilofWizard.MAC);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardHP", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardHP", g_Config.BonusAbilofWizard.HP);
            }
            g_Config.BonusAbilofWizard.HP = Config.ReadInteger("Setup", "BonusAbilofWizardHP", g_Config.BonusAbilofWizard.HP);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardMP", g_Config.BonusAbilofWizard.MP);
            }
            g_Config.BonusAbilofWizard.MP = Config.ReadInteger("Setup", "BonusAbilofWizardMP", g_Config.BonusAbilofWizard.MP);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardHit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardHit", g_Config.BonusAbilofWizard.Hit);
            }
            g_Config.BonusAbilofWizard.Hit = Config.ReadInteger("Setup", "BonusAbilofWizardHit", g_Config.BonusAbilofWizard.Hit);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardSpeed", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardSpeed", g_Config.BonusAbilofWizard.Speed);
            }
            g_Config.BonusAbilofWizard.Speed = Config.ReadInteger("Setup", "BonusAbilofWizardSpeed", g_Config.BonusAbilofWizard.Speed);
            if (Config.ReadInteger("Setup", "BonusAbilofWizardX2", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofWizardX2", g_Config.BonusAbilofWizard.X2);
            }
            g_Config.BonusAbilofWizard.X2 = Config.ReadInteger("Setup", "BonusAbilofWizardX2", g_Config.BonusAbilofWizard.X2);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosDC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosDC", g_Config.BonusAbilofTaos.DC);
            }
            g_Config.BonusAbilofTaos.DC = Config.ReadInteger("Setup", "BonusAbilofTaosDC", g_Config.BonusAbilofTaos.DC);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosMC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosMC", g_Config.BonusAbilofTaos.MC);
            }
            g_Config.BonusAbilofTaos.MC = Config.ReadInteger("Setup", "BonusAbilofTaosMC", g_Config.BonusAbilofTaos.MC);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosSC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosSC", g_Config.BonusAbilofTaos.SC);
            }
            g_Config.BonusAbilofTaos.SC = Config.ReadInteger("Setup", "BonusAbilofTaosSC", g_Config.BonusAbilofTaos.SC);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosAC", g_Config.BonusAbilofTaos.AC);
            }
            g_Config.BonusAbilofTaos.AC = Config.ReadInteger("Setup", "BonusAbilofTaosAC", g_Config.BonusAbilofTaos.AC);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosMAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosMAC", g_Config.BonusAbilofTaos.MAC);
            }
            g_Config.BonusAbilofTaos.MAC = Config.ReadInteger("Setup", "BonusAbilofTaosMAC", g_Config.BonusAbilofTaos.MAC);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosHP", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosHP", g_Config.BonusAbilofTaos.HP);
            }
            g_Config.BonusAbilofTaos.HP = Config.ReadInteger("Setup", "BonusAbilofTaosHP", g_Config.BonusAbilofTaos.HP);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosMP", g_Config.BonusAbilofTaos.MP);
            }
            g_Config.BonusAbilofTaos.MP = Config.ReadInteger("Setup", "BonusAbilofTaosMP", g_Config.BonusAbilofTaos.MP);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosHit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosHit", g_Config.BonusAbilofTaos.Hit);
            }
            g_Config.BonusAbilofTaos.Hit = Config.ReadInteger("Setup", "BonusAbilofTaosHit", g_Config.BonusAbilofTaos.Hit);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosSpeed", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosSpeed", g_Config.BonusAbilofTaos.Speed);
            }
            g_Config.BonusAbilofTaos.Speed = Config.ReadInteger("Setup", "BonusAbilofTaosSpeed", g_Config.BonusAbilofTaos.Speed);
            if (Config.ReadInteger("Setup", "BonusAbilofTaosX2", -1) < 0)
            {
                Config.WriteInteger("Setup", "BonusAbilofTaosX2", g_Config.BonusAbilofTaos.X2);
            }
            g_Config.BonusAbilofTaos.X2 = Config.ReadInteger("Setup", "BonusAbilofTaosX2", g_Config.BonusAbilofTaos.X2);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrDC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrDC", g_Config.NakedAbilofWarr.DC);
            }
            g_Config.NakedAbilofWarr.DC = Config.ReadInteger("Setup", "NakedAbilofWarrDC", g_Config.NakedAbilofWarr.DC);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrMC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrMC", g_Config.NakedAbilofWarr.MC);
            }
            g_Config.NakedAbilofWarr.MC = Config.ReadInteger("Setup", "NakedAbilofWarrMC", g_Config.NakedAbilofWarr.MC);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrSC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrSC", g_Config.NakedAbilofWarr.SC);
            }
            g_Config.NakedAbilofWarr.SC = Config.ReadInteger("Setup", "NakedAbilofWarrSC", g_Config.NakedAbilofWarr.SC);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrAC", g_Config.NakedAbilofWarr.AC);
            }
            g_Config.NakedAbilofWarr.AC = Config.ReadInteger("Setup", "NakedAbilofWarrAC", g_Config.NakedAbilofWarr.AC);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrMAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrMAC", g_Config.NakedAbilofWarr.MAC);
            }
            g_Config.NakedAbilofWarr.MAC = Config.ReadInteger("Setup", "NakedAbilofWarrMAC", g_Config.NakedAbilofWarr.MAC);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrHP", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrHP", g_Config.NakedAbilofWarr.HP);
            }
            g_Config.NakedAbilofWarr.HP = Config.ReadInteger("Setup", "NakedAbilofWarrHP", g_Config.NakedAbilofWarr.HP);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrMP", g_Config.NakedAbilofWarr.MP);
            }
            g_Config.NakedAbilofWarr.MP = Config.ReadInteger("Setup", "NakedAbilofWarrMP", g_Config.NakedAbilofWarr.MP);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrHit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrHit", g_Config.NakedAbilofWarr.Hit);
            }
            g_Config.NakedAbilofWarr.Hit = Config.ReadInteger("Setup", "NakedAbilofWarrHit", g_Config.NakedAbilofWarr.Hit);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrSpeed", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrSpeed", g_Config.NakedAbilofWarr.Speed);
            }
            g_Config.NakedAbilofWarr.Speed = Config.ReadInteger("Setup", "NakedAbilofWarrSpeed", g_Config.NakedAbilofWarr.Speed);
            if (Config.ReadInteger("Setup", "NakedAbilofWarrX2", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWarrX2", g_Config.NakedAbilofWarr.X2);
            }
            g_Config.NakedAbilofWarr.X2 = Config.ReadInteger("Setup", "NakedAbilofWarrX2", g_Config.NakedAbilofWarr.X2);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardDC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardDC", g_Config.NakedAbilofWizard.DC);
            }
            g_Config.NakedAbilofWizard.DC = Config.ReadInteger("Setup", "NakedAbilofWizardDC", g_Config.NakedAbilofWizard.DC);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardMC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardMC", g_Config.NakedAbilofWizard.MC);
            }
            g_Config.NakedAbilofWizard.MC = Config.ReadInteger("Setup", "NakedAbilofWizardMC", g_Config.NakedAbilofWizard.MC);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardSC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardSC", g_Config.NakedAbilofWizard.SC);
            }
            g_Config.NakedAbilofWizard.SC = Config.ReadInteger("Setup", "NakedAbilofWizardSC", g_Config.NakedAbilofWizard.SC);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardAC", g_Config.NakedAbilofWizard.AC);
            }
            g_Config.NakedAbilofWizard.AC = Config.ReadInteger("Setup", "NakedAbilofWizardAC", g_Config.NakedAbilofWizard.AC);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardMAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardMAC", g_Config.NakedAbilofWizard.MAC);
            }
            g_Config.NakedAbilofWizard.MAC = Config.ReadInteger("Setup", "NakedAbilofWizardMAC", g_Config.NakedAbilofWizard.MAC);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardHP", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardHP", g_Config.NakedAbilofWizard.HP);
            }
            g_Config.NakedAbilofWizard.HP = Config.ReadInteger("Setup", "NakedAbilofWizardHP", g_Config.NakedAbilofWizard.HP);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardMP", g_Config.NakedAbilofWizard.MP);
            }
            g_Config.NakedAbilofWizard.MP = Config.ReadInteger("Setup", "NakedAbilofWizardMP", g_Config.NakedAbilofWizard.MP);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardHit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardHit", g_Config.NakedAbilofWizard.Hit);
            }
            g_Config.NakedAbilofWizard.Hit = Config.ReadInteger("Setup", "NakedAbilofWizardHit", g_Config.NakedAbilofWizard.Hit);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardSpeed", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardSpeed", g_Config.NakedAbilofWizard.Speed);
            }
            g_Config.NakedAbilofWizard.Speed = Config.ReadInteger("Setup", "NakedAbilofWizardSpeed", g_Config.NakedAbilofWizard.Speed);
            if (Config.ReadInteger("Setup", "NakedAbilofWizardX2", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofWizardX2", g_Config.NakedAbilofWizard.X2);
            }
            g_Config.NakedAbilofWizard.X2 = Config.ReadInteger("Setup", "NakedAbilofWizardX2", g_Config.NakedAbilofWizard.X2);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosDC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosDC", g_Config.NakedAbilofTaos.DC);
            }
            g_Config.NakedAbilofTaos.DC = Config.ReadInteger("Setup", "NakedAbilofTaosDC", g_Config.NakedAbilofTaos.DC);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosMC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosMC", g_Config.NakedAbilofTaos.MC);
            }
            g_Config.NakedAbilofTaos.MC = Config.ReadInteger("Setup", "NakedAbilofTaosMC", g_Config.NakedAbilofTaos.MC);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosSC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosSC", g_Config.NakedAbilofTaos.SC);
            }
            g_Config.NakedAbilofTaos.SC = Config.ReadInteger("Setup", "NakedAbilofTaosSC", g_Config.NakedAbilofTaos.SC);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosAC", g_Config.NakedAbilofTaos.AC);
            }
            g_Config.NakedAbilofTaos.AC = Config.ReadInteger("Setup", "NakedAbilofTaosAC", g_Config.NakedAbilofTaos.AC);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosMAC", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosMAC", g_Config.NakedAbilofTaos.MAC);
            }
            g_Config.NakedAbilofTaos.MAC = Config.ReadInteger("Setup", "NakedAbilofTaosMAC", g_Config.NakedAbilofTaos.MAC);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosHP", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosHP", g_Config.NakedAbilofTaos.HP);
            }
            g_Config.NakedAbilofTaos.HP = Config.ReadInteger("Setup", "NakedAbilofTaosHP", g_Config.NakedAbilofTaos.HP);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosMP", g_Config.NakedAbilofTaos.MP);
            }
            g_Config.NakedAbilofTaos.MP = Config.ReadInteger("Setup", "NakedAbilofTaosMP", g_Config.NakedAbilofTaos.MP);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosHit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosHit", g_Config.NakedAbilofTaos.Hit);
            }
            g_Config.NakedAbilofTaos.Hit = Config.ReadInteger("Setup", "NakedAbilofTaosHit", g_Config.NakedAbilofTaos.Hit);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosSpeed", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosSpeed", g_Config.NakedAbilofTaos.Speed);
            }
            g_Config.NakedAbilofTaos.Speed = Config.ReadInteger("Setup", "NakedAbilofTaosSpeed", g_Config.NakedAbilofTaos.Speed);
            if (Config.ReadInteger("Setup", "NakedAbilofTaosX2", -1) < 0)
            {
                Config.WriteInteger("Setup", "NakedAbilofTaosX2", g_Config.NakedAbilofTaos.X2);
            }
            g_Config.NakedAbilofTaos.X2 = Config.ReadInteger("Setup", "NakedAbilofTaosX2", g_Config.NakedAbilofTaos.X2);
            // 新建行会成员上限 20090115
            if (Config.ReadInteger("Setup", "GuildMemberCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildMemberCount", g_Config.nGuildMemberCount);
            }
            g_Config.nGuildMemberCount = Config.ReadInteger("Setup", "GuildMemberCount", g_Config.nGuildMemberCount);
            if (Config.ReadInteger("Setup", "GroupMembersMax", -1) < 0)
            {
                Config.WriteInteger("Setup", "GroupMembersMax", g_Config.nGroupMembersMax);
            }
            g_Config.nGroupMembersMax = Config.ReadInteger("Setup", "GroupMembersMax", g_Config.nGroupMembersMax);
            if (Config.ReadInteger("Setup", "UPgradeWeaponGetBackTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "UPgradeWeaponGetBackTime", g_Config.dwUPgradeWeaponGetBackTime);
            }
            g_Config.dwUPgradeWeaponGetBackTime = Config.ReadInteger("Setup", "UPgradeWeaponGetBackTime", g_Config.dwUPgradeWeaponGetBackTime);
            if (Config.ReadInteger("Setup", "ClearExpireUpgradeWeaponDays", -1) < 0)
            {
                Config.WriteInteger("Setup", "ClearExpireUpgradeWeaponDays", g_Config.nClearExpireUpgradeWeaponDays);
            }
            g_Config.nClearExpireUpgradeWeaponDays = Config.ReadInteger("Setup", "ClearExpireUpgradeWeaponDays", g_Config.nClearExpireUpgradeWeaponDays);
            if (Config.ReadInteger("Setup", "UpgradeWeaponPrice", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponPrice", g_Config.nUpgradeWeaponPrice);
            }
            g_Config.nUpgradeWeaponPrice = Config.ReadInteger("Setup", "UpgradeWeaponPrice", g_Config.nUpgradeWeaponPrice);
            if (Config.ReadInteger("Setup", "UpgradeWeaponMaxPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponMaxPoint", g_Config.nUpgradeWeaponMaxPoint);
            }
            g_Config.nUpgradeWeaponMaxPoint = Config.ReadInteger("Setup", "UpgradeWeaponMaxPoint", g_Config.nUpgradeWeaponMaxPoint);
            if (Config.ReadInteger("Setup", "UpgradeWeaponDCRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponDCRate", g_Config.nUpgradeWeaponDCRate);
            }
            g_Config.nUpgradeWeaponDCRate = Config.ReadInteger("Setup", "UpgradeWeaponDCRate", g_Config.nUpgradeWeaponDCRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponDCTwoPointRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponDCTwoPointRate", g_Config.nUpgradeWeaponDCTwoPointRate);
            }
            g_Config.nUpgradeWeaponDCTwoPointRate = Config.ReadInteger("Setup", "UpgradeWeaponDCTwoPointRate", g_Config.nUpgradeWeaponDCTwoPointRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponDCThreePointRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponDCThreePointRate", g_Config.nUpgradeWeaponDCThreePointRate);
            }
            g_Config.nUpgradeWeaponDCThreePointRate = Config.ReadInteger("Setup", "UpgradeWeaponDCThreePointRate", g_Config.nUpgradeWeaponDCThreePointRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponMCRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponMCRate", g_Config.nUpgradeWeaponMCRate);
            }
            g_Config.nUpgradeWeaponMCRate = Config.ReadInteger("Setup", "UpgradeWeaponMCRate", g_Config.nUpgradeWeaponMCRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponMCTwoPointRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponMCTwoPointRate", g_Config.nUpgradeWeaponMCTwoPointRate);
            }
            g_Config.nUpgradeWeaponMCTwoPointRate = Config.ReadInteger("Setup", "UpgradeWeaponMCTwoPointRate", g_Config.nUpgradeWeaponMCTwoPointRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponMCThreePointRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponMCThreePointRate", g_Config.nUpgradeWeaponMCThreePointRate);
            }
            g_Config.nUpgradeWeaponMCThreePointRate = Config.ReadInteger("Setup", "UpgradeWeaponMCThreePointRate", g_Config.nUpgradeWeaponMCThreePointRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponSCRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponSCRate", g_Config.nUpgradeWeaponSCRate);
            }
            g_Config.nUpgradeWeaponSCRate = Config.ReadInteger("Setup", "UpgradeWeaponSCRate", g_Config.nUpgradeWeaponSCRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponSCTwoPointRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponSCTwoPointRate", g_Config.nUpgradeWeaponSCTwoPointRate);
            }
            g_Config.nUpgradeWeaponSCTwoPointRate = Config.ReadInteger("Setup", "UpgradeWeaponSCTwoPointRate", g_Config.nUpgradeWeaponSCTwoPointRate);
            if (Config.ReadInteger("Setup", "UpgradeWeaponSCThreePointRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "UpgradeWeaponSCThreePointRate", g_Config.nUpgradeWeaponSCThreePointRate);
            }
            g_Config.nUpgradeWeaponSCThreePointRate = Config.ReadInteger("Setup", "UpgradeWeaponSCThreePointRate", g_Config.nUpgradeWeaponSCThreePointRate);
            if (Config.ReadInteger("Setup", "BuildGuild", -1) < 0)
            {
                Config.WriteInteger("Setup", "BuildGuild", g_Config.nBuildGuildPrice);
            }
            g_Config.nBuildGuildPrice = Config.ReadInteger("Setup", "BuildGuild", g_Config.nBuildGuildPrice);
            if (Config.ReadInteger("Setup", "MakeDurg", -1) < 0)
            {
                Config.WriteInteger("Setup", "MakeDurg", g_Config.nMakeDurgPrice);
            }
            g_Config.nMakeDurgPrice = Config.ReadInteger("Setup", "MakeDurg", g_Config.nMakeDurgPrice);
            if (Config.ReadInteger("Setup", "GuildWarFee", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildWarFee", g_Config.nGuildWarPrice);
            }
            g_Config.nGuildWarPrice = Config.ReadInteger("Setup", "GuildWarFee", g_Config.nGuildWarPrice);
            if (Config.ReadInteger("Setup", "HireGuard", -1) < 0)
            {
                Config.WriteInteger("Setup", "HireGuard", g_Config.nHireGuardPrice);
            }
            g_Config.nHireGuardPrice = Config.ReadInteger("Setup", "HireGuard", g_Config.nHireGuardPrice);
            if (Config.ReadInteger("Setup", "HireArcher", -1) < 0)
            {
                Config.WriteInteger("Setup", "HireArcher", g_Config.nHireArcherPrice);
            }
            g_Config.nHireArcherPrice = Config.ReadInteger("Setup", "HireArcher", g_Config.nHireArcherPrice);
            if (Config.ReadInteger("Setup", "RepairDoor", -1) < 0)
            {
                Config.WriteInteger("Setup", "RepairDoor", g_Config.nRepairDoorPrice);
            }
            g_Config.nRepairDoorPrice = Config.ReadInteger("Setup", "RepairDoor", g_Config.nRepairDoorPrice);
            if (Config.ReadInteger("Setup", "RepairWall", -1) < 0)
            {
                Config.WriteInteger("Setup", "RepairWall", g_Config.nRepairWallPrice);
            }
            g_Config.nRepairWallPrice = Config.ReadInteger("Setup", "RepairWall", g_Config.nRepairWallPrice);
            if (Config.ReadInteger("Setup", "CastleMemberPriceRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleMemberPriceRate", g_Config.nCastleMemberPriceRate);
            }
            g_Config.nCastleMemberPriceRate = Config.ReadInteger("Setup", "CastleMemberPriceRate", g_Config.nCastleMemberPriceRate);
            if (Config.ReadInteger("Setup", "CastleGoldMax", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleGoldMax", g_Config.nCastleGoldMax);
            }
            g_Config.nCastleGoldMax = Config.ReadInteger("Setup", "CastleGoldMax", g_Config.nCastleGoldMax);
            if (Config.ReadInteger("Setup", "CastleOneDayGold", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleOneDayGold", g_Config.nCastleOneDayGold);
            }
            g_Config.nCastleOneDayGold = Config.ReadInteger("Setup", "CastleOneDayGold", g_Config.nCastleOneDayGold);
            if (Config.ReadString("Setup", "CastleName", "") == "")
            {
                Config.WriteString("Setup", "CastleName", g_Config.sCASTLENAME);
            }
            g_Config.sCASTLENAME = Config.ReadString("Setup", "CastleName", g_Config.sCASTLENAME);
            if (Config.ReadString("Setup", "CastleHomeMap", "") == "")
            {
                Config.WriteString("Setup", "CastleHomeMap", g_Config.sCastleHomeMap);
            }
            g_Config.sCastleHomeMap = Config.ReadString("Setup", "CastleHomeMap", g_Config.sCastleHomeMap);
            if (Config.ReadInteger("Setup", "CastleHomeX", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleHomeX", g_Config.nCastleHomeX);
            }
            g_Config.nCastleHomeX = Config.ReadInteger("Setup", "CastleHomeX", g_Config.nCastleHomeX);
            if (Config.ReadInteger("Setup", "CastleHomeY", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleHomeY", g_Config.nCastleHomeY);
            }
            g_Config.nCastleHomeY = Config.ReadInteger("Setup", "CastleHomeY", g_Config.nCastleHomeY);
            if (Config.ReadInteger("Setup", "CastleWarRangeX", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleWarRangeX", g_Config.nCastleWarRangeX);
            }
            g_Config.nCastleWarRangeX = Config.ReadInteger("Setup", "CastleWarRangeX", g_Config.nCastleWarRangeX);
            if (Config.ReadInteger("Setup", "CastleWarRangeY", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleWarRangeY", g_Config.nCastleWarRangeY);
            }
            g_Config.nCastleWarRangeY = Config.ReadInteger("Setup", "CastleWarRangeY", g_Config.nCastleWarRangeY);
            if (Config.ReadInteger("Setup", "CastleTaxRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleTaxRate", g_Config.nCastleTaxRate);
            }
            g_Config.nCastleTaxRate = Config.ReadInteger("Setup", "CastleTaxRate", g_Config.nCastleTaxRate);
            if (Config.ReadInteger("Setup", "CastleGetAllNpcTax", -1) < 0)
            {
                Config.WriteBool("Setup", "CastleGetAllNpcTax", g_Config.boGetAllNpcTax);
            }
            g_Config.boGetAllNpcTax = Config.ReadBool("Setup", "CastleGetAllNpcTax", g_Config.boGetAllNpcTax);
            nLoadInteger = Config.ReadInteger("Setup", "GenMonRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "GenMonRate", g_Config.nMonGenRate);
            }
            else
            {
                g_Config.nMonGenRate = (ushort)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "HumanMaxGold", -1) < 0)
            {
                Config.WriteInteger("Setup", "HumanMaxGold", g_Config.nHumanMaxGold);
            }
            g_Config.nHumanMaxGold = Config.ReadInteger("Setup", "HumanMaxGold", g_Config.nHumanMaxGold);
            if (Config.ReadInteger("Setup", "HumanTryModeMaxGold", -1) < 0)
            {
                Config.WriteInteger("Setup", "HumanTryModeMaxGold", g_Config.nHumanTryModeMaxGold);
            }
            g_Config.nHumanTryModeMaxGold = Config.ReadInteger("Setup", "HumanTryModeMaxGold", g_Config.nHumanTryModeMaxGold);
            if (Config.ReadInteger("Setup", "TryModeLevel", -1) < 0)
            {
                Config.WriteInteger("Setup", "TryModeLevel", g_Config.nTryModeLevel);
            }
            g_Config.nTryModeLevel = Config.ReadInteger("Setup", "TryModeLevel", g_Config.nTryModeLevel);
            if (Config.ReadInteger("Setup", "TryModeUseStorage", -1) < 0)
            {
                Config.WriteBool("Setup", "TryModeUseStorage", g_Config.boTryModeUseStorage);
            }
            g_Config.boTryModeUseStorage = Config.ReadBool("Setup", "TryModeUseStorage", g_Config.boTryModeUseStorage);
            if (Config.ReadInteger("Setup", "ShutRedMsgShowGMName", -1) < 0)
            {
                Config.WriteBool("Setup", "ShutRedMsgShowGMName", g_Config.boShutRedMsgShowGMName);
            }
            g_Config.boShutRedMsgShowGMName = Config.ReadBool("Setup", "ShutRedMsgShowGMName", g_Config.boShutRedMsgShowGMName);
            if (Config.ReadInteger("Setup", "ShowMakeItemMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "ShowMakeItemMsg", g_Config.boShowMakeItemMsg);
            }
            g_Config.boShowMakeItemMsg = Config.ReadBool("Setup", "ShowMakeItemMsg", g_Config.boShowMakeItemMsg);
            // 人物名是否显示行会信息
            if (Config.ReadInteger("Setup", "ShowGuildName", -1) < 0)
            {
                Config.WriteBool("Setup", "ShowGuildName", g_Config.boShowGuildName);
            }
            g_Config.boShowGuildName = Config.ReadBool("Setup", "ShowGuildName", g_Config.boShowGuildName);
            if (Config.ReadInteger("Setup", "ShowRankLevelName", -1) < 0)
            {
                Config.WriteBool("Setup", "ShowRankLevelName", g_Config.boShowRankLevelName);
            }
            g_Config.boShowRankLevelName = Config.ReadBool("Setup", "ShowRankLevelName", g_Config.boShowRankLevelName);
            if (Config.ReadInteger("Setup", "MonSayMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "MonSayMsg", g_Config.boMonSayMsg);
            }
            g_Config.boMonSayMsg = Config.ReadBool("Setup", "MonSayMsg", g_Config.boMonSayMsg);
            if (Config.ReadInteger("Setup", "SayMsgMaxLen", -1) < 0)
            {
                Config.WriteInteger("Setup", "SayMsgMaxLen", g_Config.nSayMsgMaxLen);
            }
            g_Config.nSayMsgMaxLen = Config.ReadInteger("Setup", "SayMsgMaxLen", g_Config.nSayMsgMaxLen);
            if (Config.ReadInteger("Setup", "SayMsgTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "SayMsgTime", g_Config.dwSayMsgTime);
            }
            g_Config.dwSayMsgTime = Config.ReadInteger("Setup", "SayMsgTime", g_Config.dwSayMsgTime);
            if (Config.ReadInteger("Setup", "SayMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "SayMsgCount", g_Config.nSayMsgCount);
            }
            g_Config.nSayMsgCount = Config.ReadInteger("Setup", "SayMsgCount", g_Config.nSayMsgCount);
            if (Config.ReadInteger("Setup", "DisableSayMsgTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "DisableSayMsgTime", g_Config.dwDisableSayMsgTime);
            }
            g_Config.dwDisableSayMsgTime = Config.ReadInteger("Setup", "DisableSayMsgTime", g_Config.dwDisableSayMsgTime);
            if (Config.ReadInteger("Setup", "SayRedMsgMaxLen", -1) < 0)
            {
                Config.WriteInteger("Setup", "SayRedMsgMaxLen", g_Config.nSayRedMsgMaxLen);
            }
            g_Config.nSayRedMsgMaxLen = Config.ReadInteger("Setup", "SayRedMsgMaxLen", g_Config.nSayRedMsgMaxLen);
            if (Config.ReadInteger("Setup", "CanShoutMsgLevel", -1) < 0)
            {
                Config.WriteInteger("Setup", "CanShoutMsgLevel", g_Config.nCanShoutMsgLevel);
            }
            g_Config.nCanShoutMsgLevel = Config.ReadInteger("Setup", "CanShoutMsgLevel", g_Config.nCanShoutMsgLevel);
            if (Config.ReadInteger("Setup", "StartPermission", -1) < 0)
            {
                Config.WriteInteger("Setup", "StartPermission", g_Config.nStartPermission);
            }
            g_Config.nStartPermission = Config.ReadInteger("Setup", "StartPermission", g_Config.nStartPermission);
            if (Config.ReadInteger("Setup", "SendRefMsgRange", -1) < 0)
            {
                Config.WriteInteger("Setup", "SendRefMsgRange", g_Config.nSendRefMsgRange);
            }
            g_Config.nSendRefMsgRange = Config.ReadInteger("Setup", "SendRefMsgRange", g_Config.nSendRefMsgRange);
            if (Config.ReadInteger("Setup", "DecLampDura", -1) < 0)
            {
                Config.WriteBool("Setup", "DecLampDura", g_Config.boDecLampDura);
            }
            g_Config.boDecLampDura = Config.ReadBool("Setup", "DecLampDura", g_Config.boDecLampDura);
            if (Config.ReadInteger("Setup", "HungerSystem", -1) < 0)
            {
                Config.WriteBool("Setup", "HungerSystem", g_Config.boHungerSystem);
            }
            g_Config.boHungerSystem = Config.ReadBool("Setup", "HungerSystem", g_Config.boHungerSystem);
            if (Config.ReadInteger("Setup", "HungerDecHP", -1) < 0)
            {
                Config.WriteBool("Setup", "HungerDecHP", g_Config.boHungerDecHP);
            }
            g_Config.boHungerDecHP = Config.ReadBool("Setup", "HungerDecHP", g_Config.boHungerDecHP);
            if (Config.ReadInteger("Setup", "HungerDecPower", -1) < 0)
            {
                Config.WriteBool("Setup", "HungerDecPower", g_Config.boHungerDecPower);
            }
            g_Config.boHungerDecPower = Config.ReadBool("Setup", "HungerDecPower", g_Config.boHungerDecPower);
            if (Config.ReadInteger("Setup", "DiableHumanRun", -1) < 0)
            {
                Config.WriteBool("Setup", "DiableHumanRun", g_Config.boDiableHumanRun);
            }
            g_Config.boDiableHumanRun = Config.ReadBool("Setup", "DiableHumanRun", g_Config.boDiableHumanRun);
            if (Config.ReadInteger("Setup", "RunHuman", -1) < 0)
            {
                Config.WriteBool("Setup", "RunHuman", g_Config.boRUNHUMAN);
            }
            g_Config.boRUNHUMAN = Config.ReadBool("Setup", "RunHuman", g_Config.boRUNHUMAN);
            if (Config.ReadInteger("Setup", "RunMon", -1) < 0)
            {
                Config.WriteBool("Setup", "RunMon", g_Config.boRUNMON);
            }
            g_Config.boRUNMON = Config.ReadBool("Setup", "RunMon", g_Config.boRUNMON);
            if (Config.ReadInteger("Setup", "RunNpc", -1) < 0)
            {
                Config.WriteBool("Setup", "RunNpc", g_Config.boRunNpc);
            }
            g_Config.boRunNpc = Config.ReadBool("Setup", "RunNpc", g_Config.boRunNpc);
            nLoadInteger = Config.ReadInteger("Setup", "RunGuard", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "RunGuard", g_Config.boRunGuard);
            }
            else
            {
                g_Config.boRunGuard = nLoadInteger == 1;
            }
            if (Config.ReadInteger("Setup", "WarDisableHumanRun", -1) < 0)
            {
                Config.WriteBool("Setup", "WarDisableHumanRun", g_Config.boWarDisHumRun);
            }
            g_Config.boWarDisHumRun = Config.ReadBool("Setup", "WarDisableHumanRun", g_Config.boWarDisHumRun);
            // 魔法盾效果 T-特色效果 F-盛大效果 20080808
            if (Config.ReadInteger("Setup", "Skill31Effect", -1) < 0)
            {
                Config.WriteBool("Setup", "Skill31Effect", g_Config.boSkill31Effect);
            }
            g_Config.boSkill31Effect = Config.ReadBool("Setup", "Skill31Effect", g_Config.boSkill31Effect);
            // 四级魔法盾抵御伤害百分率 20080829
            if (Config.ReadInteger("Setup", "Skill66Rate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Skill66Rate", g_Config.nSkill66Rate);
            }
            g_Config.nSkill66Rate = Config.ReadInteger("Setup", "Skill66Rate", g_Config.nSkill66Rate);
            // 普通魔法盾抵御伤害百分率 20081226
            if (Config.ReadInteger("Setup", "OrdinarySkill66Rate", -1) < 0)
            {
                Config.WriteInteger("Setup", "OrdinarySkill66Rate", g_Config.nOrdinarySkill66Rate);
            }
            g_Config.nOrdinarySkill66Rate = Config.ReadInteger("Setup", "OrdinarySkill66Rate", g_Config.nOrdinarySkill66Rate);
            if (g_Config.nOrdinarySkill66Rate > 20)
            {
                g_Config.nOrdinarySkill66Rate = 20;
            }
            // 内功技能增强的攻防比率 
            if (Config.ReadInteger("Setup", "NGSkillRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NGSkillRate", g_Config.nNGSkillRate);
            }
            g_Config.nNGSkillRate = Config.ReadInteger("Setup", "NGSkillRate", g_Config.nNGSkillRate);
            // 内功等级增加攻防的级数比率 
            if (Config.ReadInteger("Setup", "NGLevelDamage", -1) < 0)
            {
                Config.WriteInteger("Setup", "NGLevelDamage", g_Config.nNGLevelDamage);
            }
            g_Config.nNGLevelDamage = Config.ReadInteger("Setup", "NGLevelDamage", g_Config.nNGLevelDamage);
            // 内力值参数 
            if (Config.ReadInteger("Setup", "Skill69NG", -1) < 0)
            {
                Config.WriteInteger("Setup", "Skill69NG", g_Config.nSkill69NG);
            }
            g_Config.nSkill69NG = Config.ReadInteger("Setup", "Skill69NG", g_Config.nSkill69NG);
            // 主体内功经验参数 20081001
            if (Config.ReadInteger("Setup", "Skill69NGExp", -1) < 0)
            {
                Config.WriteInteger("Setup", "Skill69NGExp", g_Config.nSkill69NGExp);
            }
            g_Config.nSkill69NGExp = Config.ReadInteger("Setup", "Skill69NGExp", g_Config.nSkill69NGExp);
            // 英雄内功经验参数 20081001
            if (Config.ReadInteger("Setup", "HeroSkill69NGExp", -1) < 0)
            {
                Config.WriteInteger("Setup", "HeroSkill69NGExp", g_Config.nHeroSkill69NGExp);
            }
            g_Config.nHeroSkill69NGExp = Config.ReadInteger("Setup", "HeroSkill69NGExp", g_Config.nHeroSkill69NGExp);
            // 增加内力值间隔 20081002
            if (Config.ReadInteger("Setup", "dwIncNHTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "dwIncNHTime", g_Config.dwIncNHTime);
            }
            g_Config.dwIncNHTime = Config.ReadInteger("Setup", "dwIncNHTime", g_Config.dwIncNHTime);
            // 饮酒增加内功经验 20081003
            if (Config.ReadInteger("Setup", "DrinkIncNHExp", -1) < 0)
            {
                Config.WriteInteger("Setup", "DrinkIncNHExp", g_Config.nDrinkIncNHExp);
            }
            g_Config.nDrinkIncNHExp = Config.ReadInteger("Setup", "DrinkIncNHExp", g_Config.nDrinkIncNHExp);
            // 内功抵御普通攻击消耗内力值 20081003
            if (Config.ReadInteger("Setup", "HitStruckDecNH", -1) < 0)
            {
                Config.WriteInteger("Setup", "HitStruckDecNH", g_Config.nHitStruckDecNH);
            }
            g_Config.nHitStruckDecNH = Config.ReadInteger("Setup", "HitStruckDecNH", g_Config.nHitStruckDecNH);
            if (Config.ReadInteger("Setup", "GMRunAll", -1) < 0)
            {
                Config.WriteBool("Setup", "GMRunAll", g_Config.boGMRunAll);
            }
            g_Config.boGMRunAll = Config.ReadBool("Setup", "GMRunAll", g_Config.boGMRunAll);
            if (Config.ReadInteger("Setup", "SafeAreaLimitedRun", -1) < 0)
            {
                Config.WriteBool("Setup", "SafeAreaLimitedRun", g_Config.boSafeAreaLimited);
            }
            g_Config.boSafeAreaLimited = Config.ReadBool("Setup", "SafeAreaLimitedRun", g_Config.boSafeAreaLimited);
            if (Config.ReadInteger("Setup", "BoneFammCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "BoneFammCount", g_Config.nBoneFammCount);
            }
            g_Config.nBoneFammCount = Config.ReadInteger("Setup", "BoneFammCount", g_Config.nBoneFammCount);
            for (I = g_Config.BoneFammArray.GetLowerBound(0); I <= g_Config.BoneFammArray.GetUpperBound(0); I++)
            {
                if (Config.ReadInteger("Setup", "BoneFammHumLevel" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "BoneFammHumLevel" + I, g_Config.BoneFammArray[I].nHumLevel);
                }
                g_Config.BoneFammArray[I].nHumLevel = Config.ReadInteger("Setup", "BoneFammHumLevel" + I, g_Config.BoneFammArray[I].nHumLevel);
                if (Config.ReadString("Names", "BoneFamm" + I, "") == "")
                {
                    Config.WriteString("Names", "BoneFamm" + I, g_Config.BoneFammArray[I].sMonName == null ? "" : g_Config.BoneFammArray[I].sMonName);
                }
                g_Config.BoneFammArray[I].sMonName = Config.ReadString("Names", "BoneFamm" + I, g_Config.BoneFammArray[I].sMonName);
                if (Config.ReadInteger("Setup", "BoneFammCount" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "BoneFammCount" + I, g_Config.BoneFammArray[I].nCount);
                }
                g_Config.BoneFammArray[I].nCount = Config.ReadInteger("Setup", "BoneFammCount" + I, g_Config.BoneFammArray[I].nCount);
                if (Config.ReadInteger("Setup", "BoneFammLevel" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "BoneFammLevel" + I, g_Config.BoneFammArray[I].nLevel);
                }
                g_Config.BoneFammArray[I].nLevel = Config.ReadInteger("Setup", "BoneFammLevel" + I, g_Config.BoneFammArray[I].nLevel);
            }
            if (Config.ReadInteger("Setup", "DogzCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "DogzCount", g_Config.nDogzCount);
            }
            g_Config.nDogzCount = Config.ReadInteger("Setup", "DogzCount", g_Config.nDogzCount);
            for (I = g_Config.DogzArray.GetLowerBound(0); I <= g_Config.DogzArray.GetUpperBound(0); I++)
            {
                if (Config.ReadInteger("Setup", "DogzHumLevel" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "DogzHumLevel" + I, g_Config.DogzArray[I].nHumLevel);
                }
                g_Config.DogzArray[I].nHumLevel = Config.ReadInteger("Setup", "DogzHumLevel" + I, g_Config.DogzArray[I].nHumLevel);
                if (Config.ReadString("Names", "Dogz" + I, "") == "")
                {
                    Config.WriteString("Names", "Dogz" + I, g_Config.DogzArray[I].sMonName == null ? "" : g_Config.DogzArray[I].sMonName);
                }
                g_Config.DogzArray[I].sMonName = Config.ReadString("Names", "Dogz" + I, g_Config.DogzArray[I].sMonName);
                if (Config.ReadInteger("Setup", "DogzCount" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "DogzCount" + I, g_Config.DogzArray[I].nCount);
                }
                g_Config.DogzArray[I].nCount = Config.ReadInteger("Setup", "DogzCount" + I, g_Config.DogzArray[I].nCount);
                if (Config.ReadInteger("Setup", "DogzLevel" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "DogzLevel" + I, g_Config.DogzArray[I].nLevel);
                }
                g_Config.DogzArray[I].nLevel = Config.ReadInteger("Setup", "DogzLevel" + I, g_Config.DogzArray[I].nLevel);
            }
            // 月灵
            if (Config.ReadInteger("Setup", "FairyCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "FairyCount", g_Config.nFairyCount);
            }
            g_Config.nFairyCount = Config.ReadInteger("Setup", "FairyCount", g_Config.nFairyCount);
            if (Config.ReadInteger("Setup", "FairyDuntRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "FairyDuntRate", g_Config.nFairyDuntRate);
            }
            g_Config.nFairyDuntRate = Config.ReadInteger("Setup", "FairyDuntRate", g_Config.nFairyDuntRate);// 月灵重击次数,达到次数时按等级出重击 
            if (Config.ReadInteger("Setup", "FairyDuntRateBelow", -1) < 0)
            {
                Config.WriteInteger("Setup", "FairyDuntRateBelow", g_Config.nFairyDuntRateBelow);
            }
            g_Config.nFairyDuntRateBelow = Config.ReadInteger("Setup", "FairyDuntRateBelow", g_Config.nFairyDuntRateBelow);
            if (Config.ReadInteger("Setup", "FairyAttackRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "FairyAttackRate", g_Config.nFairyAttackRate);
            }
            g_Config.nFairyAttackRate = Config.ReadInteger("Setup", "FairyAttackRate", g_Config.nFairyAttackRate);
            // 开天斩重击几率 20080213
            if (Config.ReadInteger("Setup", "43KillHitRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "43KillHitRate", g_Config.n43KillHitRate);
            }
            g_Config.n43KillHitRate = Config.ReadInteger("Setup", "43KillHitRate", g_Config.n43KillHitRate);
            // 开天斩重击倍数  20080213
            if (Config.ReadInteger("Setup", "43KillAttackRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "43KillAttackRate", g_Config.n43KillAttackRate);
            }
            g_Config.n43KillAttackRate = Config.ReadInteger("Setup", "43KillAttackRate", g_Config.n43KillAttackRate);
            // 开天斩威力 20080213
            if (Config.ReadInteger("Setup", "AttackRate_43", -1) < 0)
            {
                Config.WriteInteger("Setup", "AttackRate_43", g_Config.nAttackRate_43);
            }
            g_Config.nAttackRate_43 = Config.ReadInteger("Setup", "AttackRate_43", g_Config.nAttackRate_43);
            // 烈火剑法威力倍数 20081208
            if (Config.ReadInteger("Setup", "AttackRate_26", -1) < 0)
            {
                Config.WriteInteger("Setup", "AttackRate_26", g_Config.nAttackRate_26);
            }
            g_Config.nAttackRate_26 = Config.ReadInteger("Setup", "AttackRate_26", g_Config.nAttackRate_26);
            // 逐日剑法威力倍数 20080511
            if (Config.ReadInteger("Setup", "AttackRate_74", -1) < 0)
            {
                Config.WriteInteger("Setup", "AttackRate_74", g_Config.nAttackRate_74);
            }
            g_Config.nAttackRate_74 = Config.ReadInteger("Setup", "AttackRate_74", g_Config.nAttackRate_74);
            for (I = g_Config.FairyArray.GetLowerBound(0); I <= g_Config.FairyArray.GetUpperBound(0); I++)
            {
                if (Config.ReadInteger("Setup", "FairyHumLevel" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "FairyHumLevel" + I, g_Config.FairyArray[I].nHumLevel);
                }
                g_Config.FairyArray[I].nHumLevel = Config.ReadInteger("Setup", "FairyHumLevel" + I, g_Config.FairyArray[I].nHumLevel);
                if (Config.ReadString("Names", "Fairy" + I, "") == "")
                {
                    Config.WriteString("Names", "Fairy" + I, g_Config.FairyArray[I].sMonName == null ? "" : g_Config.FairyArray[I].sMonName);
                }
                g_Config.FairyArray[I].sMonName = Config.ReadString("Names", "Fairy" + I, g_Config.FairyArray[I].sMonName);
                if (Config.ReadInteger("Setup", "FairyCount" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "FairyCount" + I, g_Config.FairyArray[I].nCount);
                }
                g_Config.FairyArray[I].nCount = Config.ReadInteger("Setup", "FairyCount" + I, g_Config.FairyArray[I].nCount);
                if (Config.ReadInteger("Setup", "FairyLevel" + I, -1) < 0)
                {
                    Config.WriteInteger("Setup", "FairyLevel" + I, g_Config.FairyArray[I].nLevel);
                }
                g_Config.FairyArray[I].nLevel = Config.ReadInteger("Setup", "FairyLevel" + I, g_Config.FairyArray[I].nLevel);
            }
            if (Config.ReadInteger("Setup", "TryDealTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "TryDealTime", g_Config.dwTryDealTime);
            }
            g_Config.dwTryDealTime = Config.ReadInteger("Setup", "TryDealTime", g_Config.dwTryDealTime);
            if (Config.ReadInteger("Setup", "DealOKTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "DealOKTime", g_Config.dwDealOKTime);
            }
            g_Config.dwDealOKTime = Config.ReadInteger("Setup", "DealOKTime", g_Config.dwDealOKTime);
            if (Config.ReadInteger("Setup", "CanNotGetBackDeal", -1) < 0)
            {
                Config.WriteBool("Setup", "CanNotGetBackDeal", g_Config.boCanNotGetBackDeal);
            }
            g_Config.boCanNotGetBackDeal = Config.ReadBool("Setup", "CanNotGetBackDeal", g_Config.boCanNotGetBackDeal);
            if (Config.ReadInteger("Setup", "DisableDeal", -1) < 0)
            {
                Config.WriteBool("Setup", "DisableDeal", g_Config.boDisableDeal);
            }
            g_Config.boDisableDeal = Config.ReadBool("Setup", "DisableDeal", g_Config.boDisableDeal);// 可收徒弟数
            if (Config.ReadInteger("Setup", "MasterCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MasterCount", g_Config.nMasterCount);
            }
            g_Config.nMasterCount = Config.ReadInteger("Setup", "MasterCount", g_Config.nMasterCount);
            if (Config.ReadInteger("Setup", "MasterOKLevel", -1) < 0)
            {
                Config.WriteInteger("Setup", "MasterOKLevel", g_Config.nMasterOKLevel);
            }
            g_Config.nMasterOKLevel = Config.ReadInteger("Setup", "MasterOKLevel", g_Config.nMasterOKLevel);
            if (Config.ReadInteger("Setup", "MasterOKCreditPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "MasterOKCreditPoint", g_Config.nMasterOKCreditPoint);
            }
            g_Config.nMasterOKCreditPoint = Config.ReadInteger("Setup", "MasterOKCreditPoint", g_Config.nMasterOKCreditPoint);
            if (Config.ReadInteger("Setup", "MasterOKBonusPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "MasterOKBonusPoint", g_Config.nMasterOKBonusPoint);
            }
            g_Config.nMasterOKBonusPoint = Config.ReadInteger("Setup", "MasterOKBonusPoint", g_Config.nMasterOKBonusPoint);
            if (Config.ReadInteger("Setup", "PKProtect", -1) < 0)
            {
                Config.WriteBool("Setup", "PKProtect", g_Config.boPKLevelProtect);
            }
            g_Config.boPKLevelProtect = Config.ReadBool("Setup", "PKProtect", g_Config.boPKLevelProtect);
            if (Config.ReadInteger("Setup", "PKProtectLevel", -1) < 0)
            {
                Config.WriteInteger("Setup", "PKProtectLevel", g_Config.nPKProtectLevel);
            }
            g_Config.nPKProtectLevel = Config.ReadInteger("Setup", "PKProtectLevel", g_Config.nPKProtectLevel);
            if (Config.ReadInteger("Setup", "RedPKProtectLevel", -1) < 0)
            {
                Config.WriteInteger("Setup", "RedPKProtectLevel", g_Config.nRedPKProtectLevel);
            }
            g_Config.nRedPKProtectLevel = Config.ReadInteger("Setup", "RedPKProtectLevel", g_Config.nRedPKProtectLevel);
            if (Config.ReadInteger("Setup", "ItemPowerRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ItemPowerRate", g_Config.nItemPowerRate);
            }
            g_Config.nItemPowerRate = Config.ReadInteger("Setup", "ItemPowerRate", g_Config.nItemPowerRate);
            if (Config.ReadInteger("Setup", "ItemExpRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ItemExpRate", g_Config.nItemExpRate);
            }
            g_Config.nItemExpRate = Config.ReadInteger("Setup", "ItemExpRate", g_Config.nItemExpRate);
            if (Config.ReadInteger("Setup", "ScriptGotoCountLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "ScriptGotoCountLimit", g_Config.nScriptGotoCountLimit);
            }
            g_Config.nScriptGotoCountLimit = Config.ReadInteger("Setup", "ScriptGotoCountLimit", g_Config.nScriptGotoCountLimit);
            if (Config.ReadInteger("Setup", "HearMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "HearMsgFColor", g_Config.btHearMsgFColor);
            }
            g_Config.btHearMsgFColor = Config.ReadInteger("Setup", "HearMsgFColor", g_Config.btHearMsgFColor);
            if (Config.ReadInteger("Setup", "HearMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "HearMsgBColor", g_Config.btHearMsgBColor);
            }
            g_Config.btHearMsgBColor = Config.ReadInteger("Setup", "HearMsgBColor", g_Config.btHearMsgBColor);
            if (Config.ReadInteger("Setup", "WhisperMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "WhisperMsgFColor", g_Config.btWhisperMsgFColor);
            }
            g_Config.btWhisperMsgFColor = Config.ReadInteger("Setup", "WhisperMsgFColor", g_Config.btWhisperMsgFColor);
            if (Config.ReadInteger("Setup", "WhisperMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "WhisperMsgBColor", g_Config.btWhisperMsgBColor);
            }
            g_Config.btWhisperMsgBColor = Config.ReadInteger("Setup", "WhisperMsgBColor", g_Config.btWhisperMsgBColor);
            if (Config.ReadInteger("Setup", "GMWhisperMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GMWhisperMsgFColor", g_Config.btGMWhisperMsgFColor);
            }
            g_Config.btGMWhisperMsgFColor = Config.ReadInteger("Setup", "GMWhisperMsgFColor", g_Config.btGMWhisperMsgFColor);
            if (Config.ReadInteger("Setup", "GMWhisperMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GMWhisperMsgBColor", g_Config.btGMWhisperMsgBColor);
            }
            g_Config.btGMWhisperMsgBColor = Config.ReadInteger("Setup", "GMWhisperMsgBColor", g_Config.btGMWhisperMsgBColor);
            if (Config.ReadInteger("Setup", "CryMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "CryMsgFColor", g_Config.btCryMsgFColor);
            }
            g_Config.btCryMsgFColor = Config.ReadInteger("Setup", "CryMsgFColor", g_Config.btCryMsgFColor);
            if (Config.ReadInteger("Setup", "CryMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "CryMsgBColor", g_Config.btCryMsgBColor);
            }
            g_Config.btCryMsgBColor = Config.ReadInteger("Setup", "CryMsgBColor", g_Config.btCryMsgBColor);
            if (Config.ReadInteger("Setup", "GreenMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GreenMsgFColor", g_Config.btGreenMsgFColor);
            }
            g_Config.btGreenMsgFColor = Config.ReadInteger("Setup", "GreenMsgFColor", g_Config.btGreenMsgFColor);
            if (Config.ReadInteger("Setup", "GreenMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GreenMsgBColor", g_Config.btGreenMsgBColor);
            }
            g_Config.btGreenMsgBColor = Config.ReadInteger("Setup", "GreenMsgBColor", g_Config.btGreenMsgBColor);
            if (Config.ReadInteger("Setup", "BlueMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "BlueMsgFColor", g_Config.btBlueMsgFColor);
            }
            g_Config.btBlueMsgFColor = Config.ReadInteger("Setup", "BlueMsgFColor", g_Config.btBlueMsgFColor);
            if (Config.ReadInteger("Setup", "BlueMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "BlueMsgBColor", g_Config.btBlueMsgBColor);
            }
            g_Config.btBlueMsgBColor = Config.ReadInteger("Setup", "BlueMsgBColor", g_Config.btBlueMsgBColor);// 千里传音
            if (Config.ReadInteger("Setup", "SayMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "SayMsgFColor", g_Config.btSayMsgFColor);
            }
            g_Config.btSayMsgFColor = Config.ReadInteger("Setup", "SayMsgFColor", g_Config.btSayMsgFColor);
            if (Config.ReadInteger("Setup", "SayeMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "SayeMsgBColor", g_Config.btSayeMsgBColor);
            }
            g_Config.btSayeMsgBColor = Config.ReadInteger("Setup", "SayeMsgBColor", g_Config.btSayeMsgBColor);
            // ---
            if (Config.ReadInteger("Setup", "RedMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "RedMsgFColor", g_Config.btRedMsgFColor);
            }
            g_Config.btRedMsgFColor = Config.ReadInteger("Setup", "RedMsgFColor", g_Config.btRedMsgFColor);
            if (Config.ReadInteger("Setup", "RedMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "RedMsgBColor", g_Config.btRedMsgBColor);
            }
            g_Config.btRedMsgBColor = Config.ReadInteger("Setup", "RedMsgBColor", g_Config.btRedMsgBColor);
            if (Config.ReadInteger("Setup", "GuildMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildMsgFColor", g_Config.btGuildMsgFColor);
            }
            g_Config.btGuildMsgFColor = Config.ReadInteger("Setup", "GuildMsgFColor", g_Config.btGuildMsgFColor);
            if (Config.ReadInteger("Setup", "GuildMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildMsgBColor", g_Config.btGuildMsgBColor);
            }
            g_Config.btGuildMsgBColor = Config.ReadInteger("Setup", "GuildMsgBColor", g_Config.btGuildMsgBColor);
            if (Config.ReadInteger("Setup", "GroupMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GroupMsgFColor", g_Config.btGroupMsgFColor);
            }
            g_Config.btGroupMsgFColor = Config.ReadInteger("Setup", "GroupMsgFColor", g_Config.btGroupMsgFColor);
            if (Config.ReadInteger("Setup", "GroupMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "GroupMsgBColor", g_Config.btGroupMsgBColor);
            }
            g_Config.btGroupMsgBColor = Config.ReadInteger("Setup", "GroupMsgBColor", g_Config.btGroupMsgBColor);
            if (Config.ReadInteger("Setup", "CustMsgFColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "CustMsgFColor", g_Config.btCustMsgFColor);
            }
            g_Config.btCustMsgFColor = Config.ReadInteger("Setup", "CustMsgFColor", g_Config.btCustMsgFColor);
            if (Config.ReadInteger("Setup", "CustMsgBColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "CustMsgBColor", g_Config.btCustMsgBColor);
            }
            g_Config.btCustMsgBColor = Config.ReadInteger("Setup", "CustMsgBColor", g_Config.btCustMsgBColor);
            if (Config.ReadInteger("Setup", "MonRandomAddValue", -1) < 0)
            {
                Config.WriteInteger("Setup", "MonRandomAddValue", g_Config.nMonRandomAddValue);
            }
            g_Config.nMonRandomAddValue = Config.ReadInteger("Setup", "MonRandomAddValue", g_Config.nMonRandomAddValue);
            if (Config.ReadInteger("Setup", "MakeRandomAddValue", -1) < 0)
            {
                Config.WriteInteger("Setup", "MakeRandomAddValue", g_Config.nMakeRandomAddValue);
            }
            g_Config.nMakeRandomAddValue = Config.ReadInteger("Setup", "MakeRandomAddValue", g_Config.nMakeRandomAddValue);// 人形身上装备极品机率
            if (Config.ReadInteger("Setup", "PlayMonRandomAddValue", -1) < 0)
            {
                Config.WriteInteger("Setup", "PlayMonRandomAddValue", g_Config.nPlayMonRandomAddValue);
            }
            g_Config.nPlayMonRandomAddValue = Config.ReadInteger("Setup", "PlayMonRandomAddValue", g_Config.nPlayMonRandomAddValue);
            // -------------气血石配置------------------------------
            if (Config.ReadInteger("Setup", "StartHPRock", -1) < 0)
            {
                Config.WriteInteger("Setup", "StartHPRock", g_Config.nStartHPRock);
            }
            g_Config.nStartHPRock = Config.ReadInteger("Setup", "StartHPRock", g_Config.nStartHPRock);
            if (Config.ReadInteger("Setup", "RockAddHP", -1) < 0)
            {
                Config.WriteInteger("Setup", "RockAddHP", g_Config.nRockAddHP);
            }
            g_Config.nRockAddHP = Config.ReadInteger("Setup", "RockAddHP", g_Config.nRockAddHP);
            if (Config.ReadInteger("Setup", "HPRockSpell", -1) < 0)
            {
                Config.WriteInteger("Setup", "HPRockSpell", g_Config.nHPRockSpell);
            }
            g_Config.nHPRockSpell = Config.ReadInteger("Setup", "HPRockSpell", g_Config.nHPRockSpell);
            if (Config.ReadInteger("Setup", "HPRockDecDura", -1) < 0)
            {
                Config.WriteInteger("Setup", "HPRockDecDura", g_Config.nHPRockDecDura);
            }
            g_Config.nHPRockDecDura = Config.ReadInteger("Setup", "HPRockDecDura", g_Config.nHPRockDecDura);
            if (Config.ReadInteger("Setup", "StartMPRock", -1) < 0)
            {
                Config.WriteInteger("Setup", "StartMPRock", g_Config.nStartMPRock);
            }
            g_Config.nStartMPRock = Config.ReadInteger("Setup", "StartMPRock", g_Config.nStartMPRock);
            if (Config.ReadInteger("Setup", "RockAddMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "RockAddMP", g_Config.nRockAddMP);
            }
            g_Config.nRockAddMP = Config.ReadInteger("Setup", "RockAddMP", g_Config.nRockAddMP);
            if (Config.ReadInteger("Setup", "MPRockSpell", -1) < 0)
            {
                Config.WriteInteger("Setup", "MPRockSpell", g_Config.nMPRockSpell);
            }
            g_Config.nMPRockSpell = Config.ReadInteger("Setup", "MPRockSpell", g_Config.nMPRockSpell);
            if (Config.ReadInteger("Setup", "MPRockDecDura", -1) < 0)
            {
                Config.WriteInteger("Setup", "MPRockDecDura", g_Config.nMPRockDecDura);
            }
            g_Config.nMPRockDecDura = Config.ReadInteger("Setup", "MPRockDecDura", g_Config.nMPRockDecDura);
            if (Config.ReadInteger("Setup", "StartHPMPRock", -1) < 0)
            {
                Config.WriteInteger("Setup", "StartHPMPRock", g_Config.nStartHPMPRock);
            }
            g_Config.nStartHPMPRock = Config.ReadInteger("Setup", "StartHPMPRock", g_Config.nStartHPMPRock);
            if (Config.ReadInteger("Setup", "RockAddHPMP", -1) < 0)
            {
                Config.WriteInteger("Setup", "RockAddHPMP", g_Config.nRockAddHPMP);
            }
            g_Config.nRockAddHPMP = Config.ReadInteger("Setup", "RockAddHPMP", g_Config.nRockAddHPMP);
            if (Config.ReadInteger("Setup", "HPMPRockSpell", -1) < 0)
            {
                Config.WriteInteger("Setup", "HPMPRockSpell", g_Config.nHPMPRockSpell);
            }
            g_Config.nHPMPRockSpell = Config.ReadInteger("Setup", "HPMPRockSpell", g_Config.nHPMPRockSpell);
            if (Config.ReadInteger("Setup", "HPMPRockDecDura", -1) < 0)
            {
                Config.WriteInteger("Setup", "HPMPRockDecDura", g_Config.nHPMPRockDecDura);
            }
            g_Config.nHPMPRockDecDura = Config.ReadInteger("Setup", "HPMPRockDecDura", g_Config.nHPMPRockDecDura);
            // ---------------------------------------------
            if (Config.ReadInteger("Setup", "WeaponDCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponDCAddValueMaxLimit", g_Config.nWeaponDCAddValueMaxLimit);
            }
            g_Config.nWeaponDCAddValueMaxLimit = Config.ReadInteger("Setup", "WeaponDCAddValueMaxLimit", g_Config.nWeaponDCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "WeaponDCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponDCAddValueRate", g_Config.nWeaponDCAddValueRate);
            }
            g_Config.nWeaponDCAddValueRate = Config.ReadInteger("Setup", "WeaponDCAddValueRate", g_Config.nWeaponDCAddValueRate);
            if (Config.ReadInteger("Setup", "WeaponMCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponMCAddValueMaxLimit", g_Config.nWeaponMCAddValueMaxLimit);
            }
            g_Config.nWeaponMCAddValueMaxLimit = Config.ReadInteger("Setup", "WeaponMCAddValueMaxLimit", g_Config.nWeaponMCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "WeaponMCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponMCAddValueRate", g_Config.nWeaponMCAddValueRate);
            }
            g_Config.nWeaponMCAddValueRate = Config.ReadInteger("Setup", "WeaponMCAddValueRate", g_Config.nWeaponMCAddValueRate);
            if (Config.ReadInteger("Setup", "WeaponSCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponSCAddValueMaxLimit", g_Config.nWeaponSCAddValueMaxLimit);
            }
            g_Config.nWeaponSCAddValueMaxLimit = Config.ReadInteger("Setup", "WeaponSCAddValueMaxLimit", g_Config.nWeaponSCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "WeaponSCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponSCAddValueRate", g_Config.nWeaponSCAddValueRate);
            }
            g_Config.nWeaponSCAddValueRate = Config.ReadInteger("Setup", "WeaponSCAddValueRate", g_Config.nWeaponSCAddValueRate);
            if (Config.ReadInteger("Setup", "WeaponDCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponDCAddRate", g_Config.nWeaponDCAddRate);
            }
            g_Config.nWeaponDCAddRate = Config.ReadInteger("Setup", "WeaponDCAddRate", g_Config.nWeaponDCAddRate);
            if (Config.ReadInteger("Setup", "WeaponSCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponSCAddRate", g_Config.nWeaponSCAddRate);
            }
            g_Config.nWeaponSCAddRate = Config.ReadInteger("Setup", "WeaponSCAddRate", g_Config.nWeaponSCAddRate);
            if (Config.ReadInteger("Setup", "WeaponMCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "WeaponMCAddRate", g_Config.nWeaponMCAddRate);
            }
            g_Config.nWeaponMCAddRate = Config.ReadInteger("Setup", "WeaponMCAddRate", g_Config.nWeaponMCAddRate);
            if (Config.ReadInteger("Setup", "DressDCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressDCAddValueMaxLimit", g_Config.nDressDCAddValueMaxLimit);
            }
            g_Config.nDressDCAddValueMaxLimit = Config.ReadInteger("Setup", "DressDCAddValueMaxLimit", g_Config.nDressDCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "DressDCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressDCAddValueRate", g_Config.nDressDCAddValueRate);
            }
            g_Config.nDressDCAddValueRate = Config.ReadInteger("Setup", "DressDCAddValueRate", g_Config.nDressDCAddValueRate);
            if (Config.ReadInteger("Setup", "DressDCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressDCAddRate", g_Config.nDressDCAddRate);
            }
            g_Config.nDressDCAddRate = Config.ReadInteger("Setup", "DressDCAddRate", g_Config.nDressDCAddRate);
            if (Config.ReadInteger("Setup", "DressMCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressMCAddValueMaxLimit", g_Config.nDressMCAddValueMaxLimit);
            }
            g_Config.nDressMCAddValueMaxLimit = Config.ReadInteger("Setup", "DressMCAddValueMaxLimit", g_Config.nDressMCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "DressMCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressMCAddValueRate", g_Config.nDressMCAddValueRate);
            }
            g_Config.nDressMCAddValueRate = Config.ReadInteger("Setup", "DressMCAddValueRate", g_Config.nDressMCAddValueRate);
            if (Config.ReadInteger("Setup", "DressMCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressMCAddRate", g_Config.nDressMCAddRate);
            }
            g_Config.nDressMCAddRate = Config.ReadInteger("Setup", "DressMCAddRate", g_Config.nDressMCAddRate);
            if (Config.ReadInteger("Setup", "DressSCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressSCAddValueMaxLimit", g_Config.nDressSCAddValueMaxLimit);
            }
            g_Config.nDressSCAddValueMaxLimit = Config.ReadInteger("Setup", "DressSCAddValueMaxLimit", g_Config.nDressSCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "DressSCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressSCAddValueRate", g_Config.nDressSCAddValueRate);
            }
            g_Config.nDressSCAddValueRate = Config.ReadInteger("Setup", "DressSCAddValueRate", g_Config.nDressSCAddValueRate);
            if (Config.ReadInteger("Setup", "DressSCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressSCAddRate", g_Config.nDressSCAddRate);
            }
            g_Config.nDressSCAddRate = Config.ReadInteger("Setup", "DressSCAddRate", g_Config.nDressSCAddRate);
            if (Config.ReadInteger("Setup", "DressACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressACAddValueMaxLimit", g_Config.nDressACAddValueMaxLimit);
            }
            g_Config.nDressACAddValueMaxLimit = Config.ReadInteger("Setup", "DressACAddValueMaxLimit", g_Config.nDressACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "DressACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressACAddValueRate", g_Config.nDressACAddValueRate);
            }
            g_Config.nDressACAddValueRate = Config.ReadInteger("Setup", "DressACAddValueRate", g_Config.nDressACAddValueRate);
            if (Config.ReadInteger("Setup", "DressACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressACAddRate", g_Config.nDressACAddRate);
            }
            g_Config.nDressACAddRate = Config.ReadInteger("Setup", "DressACAddRate", g_Config.nDressACAddRate);
            if (Config.ReadInteger("Setup", "DressMACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressMACAddValueMaxLimit", g_Config.nDressMACAddValueMaxLimit);
            }
            g_Config.nDressMACAddValueMaxLimit = Config.ReadInteger("Setup", "DressMACAddValueMaxLimit", g_Config.nDressMACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "DressMACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressMACAddValueRate", g_Config.nDressMACAddValueRate);
            }
            g_Config.nDressMACAddValueRate = Config.ReadInteger("Setup", "DressMACAddValueRate", g_Config.nDressMACAddValueRate);
            if (Config.ReadInteger("Setup", "DressMACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DressMACAddRate", g_Config.nDressMACAddRate);
            }
            g_Config.nDressMACAddRate = Config.ReadInteger("Setup", "DressMACAddRate", g_Config.nDressMACAddRate);
            if (Config.ReadInteger("Setup", "NeckLace19DCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19DCAddValueMaxLimit", g_Config.nNeckLace19DCAddValueMaxLimit);
            }
            g_Config.nNeckLace19DCAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace19DCAddValueMaxLimit", g_Config.nNeckLace19DCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace19DCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19DCAddValueRate", g_Config.nNeckLace19DCAddValueRate);
            }
            g_Config.nNeckLace19DCAddValueRate = Config.ReadInteger("Setup", "NeckLace19DCAddValueRate", g_Config.nNeckLace19DCAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace19DCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19DCAddRate", g_Config.nNeckLace19DCAddRate);
            }
            g_Config.nNeckLace19DCAddRate = Config.ReadInteger("Setup", "NeckLace19DCAddRate", g_Config.nNeckLace19DCAddRate);
            if (Config.ReadInteger("Setup", "NeckLace19MCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19MCAddValueMaxLimit", g_Config.nNeckLace19MCAddValueMaxLimit);
            }
            g_Config.nNeckLace19MCAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace19MCAddValueMaxLimit", g_Config.nNeckLace19MCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace19MCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19MCAddValueRate", g_Config.nNeckLace19MCAddValueRate);
            }
            g_Config.nNeckLace19MCAddValueRate = Config.ReadInteger("Setup", "NeckLace19MCAddValueRate", g_Config.nNeckLace19MCAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace19MCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19MCAddRate", g_Config.nNeckLace19MCAddRate);
            }
            g_Config.nNeckLace19MCAddRate = Config.ReadInteger("Setup", "NeckLace19MCAddRate", g_Config.nNeckLace19MCAddRate);
            if (Config.ReadInteger("Setup", "NeckLace19SCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19SCAddValueMaxLimit", g_Config.nNeckLace19SCAddValueMaxLimit);
            }
            g_Config.nNeckLace19SCAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace19SCAddValueMaxLimit", g_Config.nNeckLace19SCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace19SCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19SCAddValueRate", g_Config.nNeckLace19SCAddValueRate);
            }
            g_Config.nNeckLace19SCAddValueRate = Config.ReadInteger("Setup", "NeckLace19SCAddValueRate", g_Config.nNeckLace19SCAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace19SCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19SCAddRate", g_Config.nNeckLace19SCAddRate);
            }
            g_Config.nNeckLace19SCAddRate = Config.ReadInteger("Setup", "NeckLace19SCAddRate", g_Config.nNeckLace19SCAddRate);
            if (Config.ReadInteger("Setup", "NeckLace19ACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19ACAddValueMaxLimit", g_Config.nNeckLace19ACAddValueMaxLimit);
            }
            g_Config.nNeckLace19ACAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace19ACAddValueMaxLimit", g_Config.nNeckLace19ACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace19ACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19ACAddValueRate", g_Config.nNeckLace19ACAddValueRate);
            }
            g_Config.nNeckLace19ACAddValueRate = Config.ReadInteger("Setup", "NeckLace19ACAddValueRate", g_Config.nNeckLace19ACAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace19ACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19ACAddRate", g_Config.nNeckLace19ACAddRate);
            }
            g_Config.nNeckLace19ACAddRate = Config.ReadInteger("Setup", "NeckLace19ACAddRate", g_Config.nNeckLace19ACAddRate);
            if (Config.ReadInteger("Setup", "NeckLace19MACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19MACAddValueMaxLimit", g_Config.nNeckLace19MACAddValueMaxLimit);
            }
            g_Config.nNeckLace19MACAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace19MACAddValueMaxLimit", g_Config.nNeckLace19MACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace19MACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19MACAddValueRate", g_Config.nNeckLace19MACAddValueRate);
            }
            g_Config.nNeckLace19MACAddValueRate = Config.ReadInteger("Setup", "NeckLace19MACAddValueRate", g_Config.nNeckLace19MACAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace19MACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace19MACAddRate", g_Config.nNeckLace19MACAddRate);
            }
            g_Config.nNeckLace19MACAddRate = Config.ReadInteger("Setup", "NeckLace19MACAddRate", g_Config.nNeckLace19MACAddRate);
            if (Config.ReadInteger("Setup", "NeckLace202124DCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124DCAddValueMaxLimit", g_Config.nNeckLace202124DCAddValueMaxLimit);
            }
            g_Config.nNeckLace202124DCAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace202124DCAddValueMaxLimit", g_Config.nNeckLace202124DCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace202124DCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124DCAddValueRate", g_Config.nNeckLace202124DCAddValueRate);
            }
            g_Config.nNeckLace202124DCAddValueRate = Config.ReadInteger("Setup", "NeckLace202124DCAddValueRate", g_Config.nNeckLace202124DCAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace202124DCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124DCAddRate", g_Config.nNeckLace202124DCAddRate);
            }
            g_Config.nNeckLace202124DCAddRate = Config.ReadInteger("Setup", "NeckLace202124DCAddRate", g_Config.nNeckLace202124DCAddRate);
            if (Config.ReadInteger("Setup", "NeckLace202124MCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124MCAddValueMaxLimit", g_Config.nNeckLace202124MCAddValueMaxLimit);
            }
            g_Config.nNeckLace202124MCAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace202124MCAddValueMaxLimit", g_Config.nNeckLace202124MCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace202124MCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124MCAddValueRate", g_Config.nNeckLace202124MCAddValueRate);
            }
            g_Config.nNeckLace202124MCAddValueRate = Config.ReadInteger("Setup", "NeckLace202124MCAddValueRate", g_Config.nNeckLace202124MCAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace202124MCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124MCAddRate", g_Config.nNeckLace202124MCAddRate);
            }
            g_Config.nNeckLace202124MCAddRate = Config.ReadInteger("Setup", "NeckLace202124MCAddRate", g_Config.nNeckLace202124MCAddRate);
            if (Config.ReadInteger("Setup", "NeckLace202124SCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124SCAddValueMaxLimit", g_Config.nNeckLace202124SCAddValueMaxLimit);
            }
            g_Config.nNeckLace202124SCAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace202124SCAddValueMaxLimit", g_Config.nNeckLace202124SCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace202124SCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124SCAddValueRate", g_Config.nNeckLace202124SCAddValueRate);
            }
            g_Config.nNeckLace202124SCAddValueRate = Config.ReadInteger("Setup", "NeckLace202124SCAddValueRate", g_Config.nNeckLace202124SCAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace202124SCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124SCAddRate", g_Config.nNeckLace202124SCAddRate);
            }
            g_Config.nNeckLace202124SCAddRate = Config.ReadInteger("Setup", "NeckLace202124SCAddRate", g_Config.nNeckLace202124SCAddRate);
            if (Config.ReadInteger("Setup", "NeckLace202124ACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124ACAddValueMaxLimit", g_Config.nNeckLace202124ACAddValueMaxLimit);
            }
            g_Config.nNeckLace202124ACAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace202124ACAddValueMaxLimit", g_Config.nNeckLace202124ACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace202124ACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124ACAddValueRate", g_Config.nNeckLace202124ACAddValueRate);
            }
            g_Config.nNeckLace202124ACAddValueRate = Config.ReadInteger("Setup", "NeckLace202124ACAddValueRate", g_Config.nNeckLace202124ACAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace202124ACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124ACAddRate", g_Config.nNeckLace202124ACAddRate);
            }
            g_Config.nNeckLace202124ACAddRate = Config.ReadInteger("Setup", "NeckLace202124ACAddRate", g_Config.nNeckLace202124ACAddRate);
            if (Config.ReadInteger("Setup", "NeckLace202124MACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124MACAddValueMaxLimit", g_Config.nNeckLace202124MACAddValueMaxLimit);
            }
            g_Config.nNeckLace202124MACAddValueMaxLimit = Config.ReadInteger("Setup", "NeckLace202124MACAddValueMaxLimit", g_Config.nNeckLace202124MACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "NeckLace202124MACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124MACAddValueRate", g_Config.nNeckLace202124MACAddValueRate);
            }
            g_Config.nNeckLace202124MACAddValueRate = Config.ReadInteger("Setup", "NeckLace202124MACAddValueRate", g_Config.nNeckLace202124MACAddValueRate);
            if (Config.ReadInteger("Setup", "NeckLace202124MACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "NeckLace202124MACAddRate", g_Config.nNeckLace202124MACAddRate);
            }
            g_Config.nNeckLace202124MACAddRate = Config.ReadInteger("Setup", "NeckLace202124MACAddRate", g_Config.nNeckLace202124MACAddRate);
            if (Config.ReadInteger("Setup", "ArmRing26DCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26DCAddValueMaxLimit", g_Config.nArmRing26DCAddValueMaxLimit);
            }
            g_Config.nArmRing26DCAddValueMaxLimit = Config.ReadInteger("Setup", "ArmRing26DCAddValueMaxLimit", g_Config.nArmRing26DCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "ArmRing26DCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26DCAddValueRate", g_Config.nArmRing26DCAddValueRate);
            }
            g_Config.nArmRing26DCAddValueRate = Config.ReadInteger("Setup", "ArmRing26DCAddValueRate", g_Config.nArmRing26DCAddValueRate);
            if (Config.ReadInteger("Setup", "ArmRing26DCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26DCAddRate", g_Config.nArmRing26DCAddRate);
            }
            g_Config.nArmRing26DCAddRate = Config.ReadInteger("Setup", "ArmRing26DCAddRate", g_Config.nArmRing26DCAddRate);
            if (Config.ReadInteger("Setup", "ArmRing26MCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26MCAddValueMaxLimit", g_Config.nArmRing26MCAddValueMaxLimit);
            }
            g_Config.nArmRing26MCAddValueMaxLimit = Config.ReadInteger("Setup", "ArmRing26MCAddValueMaxLimit", g_Config.nArmRing26MCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "ArmRing26MCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26MCAddValueRate", g_Config.nArmRing26MCAddValueRate);
            }
            g_Config.nArmRing26MCAddValueRate = Config.ReadInteger("Setup", "ArmRing26MCAddValueRate", g_Config.nArmRing26MCAddValueRate);
            if (Config.ReadInteger("Setup", "ArmRing26MCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26MCAddRate", g_Config.nArmRing26MCAddRate);
            }
            g_Config.nArmRing26MCAddRate = Config.ReadInteger("Setup", "ArmRing26MCAddRate", g_Config.nArmRing26MCAddRate);
            if (Config.ReadInteger("Setup", "ArmRing26SCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26SCAddValueMaxLimit", g_Config.nArmRing26SCAddValueMaxLimit);
            }
            g_Config.nArmRing26SCAddValueMaxLimit = Config.ReadInteger("Setup", "ArmRing26SCAddValueMaxLimit", g_Config.nArmRing26SCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "ArmRing26SCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26SCAddValueRate", g_Config.nArmRing26SCAddValueRate);
            }
            g_Config.nArmRing26SCAddValueRate = Config.ReadInteger("Setup", "ArmRing26SCAddValueRate", g_Config.nArmRing26SCAddValueRate);
            if (Config.ReadInteger("Setup", "ArmRing26SCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26SCAddRate", g_Config.nArmRing26SCAddRate);
            }
            g_Config.nArmRing26SCAddRate = Config.ReadInteger("Setup", "ArmRing26SCAddRate", g_Config.nArmRing26SCAddRate);
            if (Config.ReadInteger("Setup", "ArmRing26ACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26ACAddValueMaxLimit", g_Config.nArmRing26ACAddValueMaxLimit);
            }
            g_Config.nArmRing26ACAddValueMaxLimit = Config.ReadInteger("Setup", "ArmRing26ACAddValueMaxLimit", g_Config.nArmRing26ACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "ArmRing26ACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26ACAddValueRate", g_Config.nArmRing26ACAddValueRate);
            }
            g_Config.nArmRing26ACAddValueRate = Config.ReadInteger("Setup", "ArmRing26ACAddValueRate", g_Config.nArmRing26ACAddValueRate);
            if (Config.ReadInteger("Setup", "ArmRing26ACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26ACAddRate", g_Config.nArmRing26ACAddRate);
            }
            g_Config.nArmRing26ACAddRate = Config.ReadInteger("Setup", "ArmRing26ACAddRate", g_Config.nArmRing26ACAddRate);
            if (Config.ReadInteger("Setup", "ArmRing26MACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26MACAddValueMaxLimit", g_Config.nArmRing26MACAddValueMaxLimit);
            }
            g_Config.nArmRing26MACAddValueMaxLimit = Config.ReadInteger("Setup", "ArmRing26MACAddValueMaxLimit", g_Config.nArmRing26MACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "ArmRing26MACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26MACAddValueRate", g_Config.nArmRing26MACAddValueRate);
            }
            g_Config.nArmRing26MACAddValueRate = Config.ReadInteger("Setup", "ArmRing26MACAddValueRate", g_Config.nArmRing26MACAddValueRate);
            if (Config.ReadInteger("Setup", "ArmRing26MACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ArmRing26MACAddRate", g_Config.nArmRing26MACAddRate);
            }
            g_Config.nArmRing26MACAddRate = Config.ReadInteger("Setup", "ArmRing26MACAddRate", g_Config.nArmRing26MACAddRate);
            if (Config.ReadInteger("Setup", "Ring22DCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22DCAddValueMaxLimit", g_Config.nRing22DCAddValueMaxLimit);
            }
            g_Config.nRing22DCAddValueMaxLimit = Config.ReadInteger("Setup", "Ring22DCAddValueMaxLimit", g_Config.nRing22DCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring22DCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22DCAddValueRate", g_Config.nRing22DCAddValueRate);
            }
            g_Config.nRing22DCAddValueRate = Config.ReadInteger("Setup", "Ring22DCAddValueRate", g_Config.nRing22DCAddValueRate);
            if (Config.ReadInteger("Setup", "Ring22DCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22DCAddRate", g_Config.nRing22DCAddRate);
            }
            g_Config.nRing22DCAddRate = Config.ReadInteger("Setup", "Ring22DCAddRate", g_Config.nRing22DCAddRate);
            if (Config.ReadInteger("Setup", "Ring22MCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22MCAddValueMaxLimit", g_Config.nRing22MCAddValueMaxLimit);
            }
            g_Config.nRing22MCAddValueMaxLimit = Config.ReadInteger("Setup", "Ring22MCAddValueMaxLimit", g_Config.nRing22MCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring22MCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22MCAddValueRate", g_Config.nRing22MCAddValueRate);
            }
            g_Config.nRing22MCAddValueRate = Config.ReadInteger("Setup", "Ring22MCAddValueRate", g_Config.nRing22MCAddValueRate);
            if (Config.ReadInteger("Setup", "Ring22MCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22MCAddRate", g_Config.nRing22MCAddRate);
            }
            g_Config.nRing22MCAddRate = Config.ReadInteger("Setup", "Ring22MCAddRate", g_Config.nRing22MCAddRate);
            if (Config.ReadInteger("Setup", "Ring22SCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22SCAddValueMaxLimit", g_Config.nRing22SCAddValueMaxLimit);
            }
            g_Config.nRing22SCAddValueMaxLimit = Config.ReadInteger("Setup", "Ring22SCAddValueMaxLimit", g_Config.nRing22SCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring22SCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22SCAddValueRate", g_Config.nRing22SCAddValueRate);
            }
            g_Config.nRing22SCAddValueRate = Config.ReadInteger("Setup", "Ring22SCAddValueRate", g_Config.nRing22SCAddValueRate);
            if (Config.ReadInteger("Setup", "Ring22SCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring22SCAddRate", g_Config.nRing22SCAddRate);
            }
            g_Config.nRing22SCAddRate = Config.ReadInteger("Setup", "Ring22SCAddRate", g_Config.nRing22SCAddRate);
            if (Config.ReadInteger("Setup", "Ring23DCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23DCAddValueMaxLimit", g_Config.nRing23DCAddValueMaxLimit);
            }
            g_Config.nRing23DCAddValueMaxLimit = Config.ReadInteger("Setup", "Ring23DCAddValueMaxLimit", g_Config.nRing23DCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring23DCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23DCAddValueRate", g_Config.nRing23DCAddValueRate);
            }
            g_Config.nRing23DCAddValueRate = Config.ReadInteger("Setup", "Ring23DCAddValueRate", g_Config.nRing23DCAddValueRate);
            if (Config.ReadInteger("Setup", "Ring23DCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23DCAddRate", g_Config.nRing23DCAddRate);
            }
            g_Config.nRing23DCAddRate = Config.ReadInteger("Setup", "Ring23DCAddRate", g_Config.nRing23DCAddRate);
            if (Config.ReadInteger("Setup", "Ring23MCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23MCAddValueMaxLimit", g_Config.nRing23MCAddValueMaxLimit);
            }
            g_Config.nRing23MCAddValueMaxLimit = Config.ReadInteger("Setup", "Ring23MCAddValueMaxLimit", g_Config.nRing23MCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring23MCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23MCAddValueRate", g_Config.nRing23MCAddValueRate);
            }
            g_Config.nRing23MCAddValueRate = Config.ReadInteger("Setup", "Ring23MCAddValueRate", g_Config.nRing23MCAddValueRate);
            if (Config.ReadInteger("Setup", "Ring23MCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23MCAddRate", g_Config.nRing23MCAddRate);
            }
            g_Config.nRing23MCAddRate = Config.ReadInteger("Setup", "Ring23MCAddRate", g_Config.nRing23MCAddRate);
            if (Config.ReadInteger("Setup", "Ring23SCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23SCAddValueMaxLimit", g_Config.nRing23SCAddValueMaxLimit);
            }
            g_Config.nRing23SCAddValueMaxLimit = Config.ReadInteger("Setup", "Ring23SCAddValueMaxLimit", g_Config.nRing23SCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring23SCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23SCAddValueRate", g_Config.nRing23SCAddValueRate);
            }
            g_Config.nRing23SCAddValueRate = Config.ReadInteger("Setup", "Ring23SCAddValueRate", g_Config.nRing23SCAddValueRate);
            if (Config.ReadInteger("Setup", "Ring23SCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23SCAddRate", g_Config.nRing23SCAddRate);
            }
            g_Config.nRing23SCAddRate = Config.ReadInteger("Setup", "Ring23SCAddRate", g_Config.nRing23SCAddRate);
            if (Config.ReadInteger("Setup", "Ring23ACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23ACAddValueMaxLimit", g_Config.nRing23ACAddValueMaxLimit);
            }
            g_Config.nRing23ACAddValueMaxLimit = Config.ReadInteger("Setup", "Ring23ACAddValueMaxLimit", g_Config.nRing23ACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring23ACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23ACAddValueRate", g_Config.nRing23ACAddValueRate);
            }
            g_Config.nRing23ACAddValueRate = Config.ReadInteger("Setup", "Ring23ACAddValueRate", g_Config.nRing23ACAddValueRate);
            if (Config.ReadInteger("Setup", "Ring23ACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23ACAddRate", g_Config.nRing23ACAddRate);
            }
            g_Config.nRing23ACAddRate = Config.ReadInteger("Setup", "Ring23ACAddRate", g_Config.nRing23ACAddRate);
            if (Config.ReadInteger("Setup", "Ring23MACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23MACAddValueMaxLimit", g_Config.nRing23MACAddValueMaxLimit);
            }
            g_Config.nRing23MACAddValueMaxLimit = Config.ReadInteger("Setup", "Ring23MACAddValueMaxLimit", g_Config.nRing23MACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "Ring23MACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23MACAddValueRate", g_Config.nRing23MACAddValueRate);
            }
            g_Config.nRing23MACAddValueRate = Config.ReadInteger("Setup", "Ring23MACAddValueRate", g_Config.nRing23MACAddValueRate);
            if (Config.ReadInteger("Setup", "Ring23MACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "Ring23MACAddRate", g_Config.nRing23MACAddRate);
            }
            g_Config.nRing23MACAddRate = Config.ReadInteger("Setup", "Ring23MACAddRate", g_Config.nRing23MACAddRate);
            // ------------------------------------------------------------------------------
            // 20080503 极品鞋子加攻最高点
            if (Config.ReadInteger("Setup", "BootsDCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsDCAddValueMaxLimit", g_Config.nBootsDCAddValueMaxLimit);
            }
            g_Config.nBootsDCAddValueMaxLimit = Config.ReadInteger("Setup", "BootsDCAddValueMaxLimit", g_Config.nBootsDCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "BootsDCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsDCAddValueRate", g_Config.nBootsDCAddValueRate);
            }
            g_Config.nBootsDCAddValueRate = Config.ReadInteger("Setup", "BootsDCAddValueRate", g_Config.nBootsDCAddValueRate);
            if (Config.ReadInteger("Setup", "BootsDCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsDCAddRate", g_Config.nBootsDCAddRate);
            }
            g_Config.nBootsDCAddRate = Config.ReadInteger("Setup", "BootsDCAddRate", g_Config.nBootsDCAddRate);
            // 道术
            if (Config.ReadInteger("Setup", "BootsSCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsSCAddValueMaxLimit", g_Config.nBootsSCAddValueMaxLimit);
            }
            g_Config.nBootsSCAddValueMaxLimit = Config.ReadInteger("Setup", "BootsSCAddValueMaxLimit", g_Config.nBootsSCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "BootsSCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsSCAddValueRate", g_Config.nBootsSCAddValueRate);
            }
            g_Config.nBootsSCAddValueRate = Config.ReadInteger("Setup", "BootsSCAddValueRate", g_Config.nBootsSCAddValueRate);
            if (Config.ReadInteger("Setup", "BootsSCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsSCAddRate", g_Config.nBootsSCAddRate);
            }
            g_Config.nBootsSCAddRate = Config.ReadInteger("Setup", "BootsSCAddRate", g_Config.nBootsSCAddRate);
            // 魔法
            if (Config.ReadInteger("Setup", "BootsMCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsMCAddValueMaxLimit", g_Config.nBootsMCAddValueMaxLimit);
            }
            g_Config.nBootsMCAddValueMaxLimit = Config.ReadInteger("Setup", "BootsMCAddValueMaxLimit", g_Config.nBootsMCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "BootsMCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsMCAddValueRate", g_Config.nBootsMCAddValueRate);
            }
            g_Config.nBootsMCAddValueRate = Config.ReadInteger("Setup", "BootsMCAddValueRate", g_Config.nBootsMCAddValueRate);
            if (Config.ReadInteger("Setup", "BootsMCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsMCAddRate", g_Config.nBootsMCAddRate);
            }
            g_Config.nBootsMCAddRate = Config.ReadInteger("Setup", "BootsMCAddRate", g_Config.nBootsMCAddRate);
            // 防御
            if (Config.ReadInteger("Setup", "BootsACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsACAddValueMaxLimit", g_Config.nBootsACAddValueMaxLimit);
            }
            g_Config.nBootsACAddValueMaxLimit = Config.ReadInteger("Setup", "BootsACAddValueMaxLimit", g_Config.nBootsACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "BootsACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsACAddValueRate", g_Config.nBootsACAddValueRate);
            }
            g_Config.nBootsACAddValueRate = Config.ReadInteger("Setup", "BootsACAddValueRate", g_Config.nBootsACAddValueRate);
            if (Config.ReadInteger("Setup", "BootsACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsACAddRate", g_Config.nBootsACAddRate);
            }
            g_Config.nBootsACAddRate = Config.ReadInteger("Setup", "BootsACAddRate", g_Config.nBootsACAddRate);
            // 魔御
            if (Config.ReadInteger("Setup", "BootsMACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsMACAddValueMaxLimit", g_Config.nBootsMACAddValueMaxLimit);
            }
            g_Config.nBootsMACAddValueMaxLimit = Config.ReadInteger("Setup", "BootsMACAddValueMaxLimit", g_Config.nBootsMACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "BootsMACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsMACAddValueRate", g_Config.nBootsMACAddValueRate);
            }
            g_Config.nBootsMACAddValueRate = Config.ReadInteger("Setup", "BootsMACAddValueRate", g_Config.nBootsMACAddValueRate);
            if (Config.ReadInteger("Setup", "BootsMACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "BootsMACAddRate", g_Config.nBootsMACAddRate);
            }
            g_Config.nBootsMACAddRate = Config.ReadInteger("Setup", "BootsMACAddRate", g_Config.nBootsMACAddRate);
            // ------------------------------------------------------------------------------
            if (Config.ReadInteger("Setup", "HelMetDCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetDCAddValueMaxLimit", g_Config.nHelMetDCAddValueMaxLimit);
            }
            g_Config.nHelMetDCAddValueMaxLimit = Config.ReadInteger("Setup", "HelMetDCAddValueMaxLimit", g_Config.nHelMetDCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "HelMetDCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetDCAddValueRate", g_Config.nHelMetDCAddValueRate);
            }
            g_Config.nHelMetDCAddValueRate = Config.ReadInteger("Setup", "HelMetDCAddValueRate", g_Config.nHelMetDCAddValueRate);
            if (Config.ReadInteger("Setup", "HelMetDCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetDCAddRate", g_Config.nHelMetDCAddRate);
            }
            g_Config.nHelMetDCAddRate = Config.ReadInteger("Setup", "HelMetDCAddRate", g_Config.nHelMetDCAddRate);
            if (Config.ReadInteger("Setup", "HelMetMCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetMCAddValueMaxLimit", g_Config.nHelMetMCAddValueMaxLimit);
            }
            g_Config.nHelMetMCAddValueMaxLimit = Config.ReadInteger("Setup", "HelMetMCAddValueMaxLimit", g_Config.nHelMetMCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "HelMetMCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetMCAddValueRate", g_Config.nHelMetMCAddValueRate);
            }
            g_Config.nHelMetMCAddValueRate = Config.ReadInteger("Setup", "HelMetMCAddValueRate", g_Config.nHelMetMCAddValueRate);
            if (Config.ReadInteger("Setup", "HelMetMCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetMCAddRate", g_Config.nHelMetMCAddRate);
            }
            g_Config.nHelMetMCAddRate = Config.ReadInteger("Setup", "HelMetMCAddRate", g_Config.nHelMetMCAddRate);
            if (Config.ReadInteger("Setup", "HelMetSCAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetSCAddValueMaxLimit", g_Config.nHelMetSCAddValueMaxLimit);
            }
            g_Config.nHelMetSCAddValueMaxLimit = Config.ReadInteger("Setup", "HelMetSCAddValueMaxLimit", g_Config.nHelMetSCAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "HelMetSCAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetSCAddValueRate", g_Config.nHelMetSCAddValueRate);
            }
            g_Config.nHelMetSCAddValueRate = Config.ReadInteger("Setup", "HelMetSCAddValueRate", g_Config.nHelMetSCAddValueRate);
            if (Config.ReadInteger("Setup", "HelMetSCAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetSCAddRate", g_Config.nHelMetSCAddRate);
            }
            g_Config.nHelMetSCAddRate = Config.ReadInteger("Setup", "HelMetSCAddRate", g_Config.nHelMetSCAddRate);
            if (Config.ReadInteger("Setup", "HelMetACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetACAddValueMaxLimit", g_Config.nHelMetACAddValueMaxLimit);
            }
            g_Config.nHelMetACAddValueMaxLimit = Config.ReadInteger("Setup", "HelMetACAddValueMaxLimit", g_Config.nHelMetACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "HelMetACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetACAddValueRate", g_Config.nHelMetACAddValueRate);
            }
            g_Config.nHelMetACAddValueRate = Config.ReadInteger("Setup", "HelMetACAddValueRate", g_Config.nHelMetACAddValueRate);
            if (Config.ReadInteger("Setup", "HelMetACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetACAddRate", g_Config.nHelMetACAddRate);
            }
            g_Config.nHelMetACAddRate = Config.ReadInteger("Setup", "HelMetACAddRate", g_Config.nHelMetACAddRate);
            if (Config.ReadInteger("Setup", "HelMetMACAddValueMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetMACAddValueMaxLimit", g_Config.nHelMetMACAddValueMaxLimit);
            }
            g_Config.nHelMetMACAddValueMaxLimit = Config.ReadInteger("Setup", "HelMetMACAddValueMaxLimit", g_Config.nHelMetMACAddValueMaxLimit);
            if (Config.ReadInteger("Setup", "HelMetMACAddValueRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetMACAddValueRate", g_Config.nHelMetMACAddValueRate);
            }
            g_Config.nHelMetMACAddValueRate = Config.ReadInteger("Setup", "HelMetMACAddValueRate", g_Config.nHelMetMACAddValueRate);
            if (Config.ReadInteger("Setup", "HelMetMACAddRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "HelMetMACAddRate", g_Config.nHelMetMACAddRate);
            }
            g_Config.nHelMetMACAddRate = Config.ReadInteger("Setup", "HelMetMACAddRate", g_Config.nHelMetMACAddRate);
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetACAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetACAddRate", g_Config.nUnknowHelMetACAddRate);
            }
            else
            {
                g_Config.nUnknowHelMetACAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetACAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetACAddValueMaxLimit", g_Config.nUnknowHelMetACAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowHelMetACAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetMACAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetMACAddRate", g_Config.nUnknowHelMetMACAddRate);
            }
            else
            {
                g_Config.nUnknowHelMetMACAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetMACAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetMACAddValueMaxLimit", g_Config.nUnknowHelMetMACAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowHelMetMACAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetDCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetDCAddRate", g_Config.nUnknowHelMetDCAddRate);
            }
            else
            {
                g_Config.nUnknowHelMetDCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetDCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetDCAddValueMaxLimit", g_Config.nUnknowHelMetDCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowHelMetDCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetMCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetMCAddRate", g_Config.nUnknowHelMetMCAddRate);
            }
            else
            {
                g_Config.nUnknowHelMetMCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetMCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetMCAddValueMaxLimit", g_Config.nUnknowHelMetMCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowHelMetMCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetSCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetSCAddRate", g_Config.nUnknowHelMetSCAddRate);
            }
            else
            {
                g_Config.nUnknowHelMetSCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowHelMetSCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowHelMetSCAddValueMaxLimit", g_Config.nUnknowHelMetSCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowHelMetSCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceACAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceACAddRate", g_Config.nUnknowNecklaceACAddRate);
            }
            else
            {
                g_Config.nUnknowNecklaceACAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceACAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceACAddValueMaxLimit", g_Config.nUnknowNecklaceACAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowNecklaceACAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceMACAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceMACAddRate", g_Config.nUnknowNecklaceMACAddRate);
            }
            else
            {
                g_Config.nUnknowNecklaceMACAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceMACAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceMACAddValueMaxLimit", g_Config.nUnknowNecklaceMACAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowNecklaceMACAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceDCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceDCAddRate", g_Config.nUnknowNecklaceDCAddRate);
            }
            else
            {
                g_Config.nUnknowNecklaceDCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceDCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceDCAddValueMaxLimit", g_Config.nUnknowNecklaceDCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowNecklaceDCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceMCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceMCAddRate", g_Config.nUnknowNecklaceMCAddRate);
            }
            else
            {
                g_Config.nUnknowNecklaceMCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceMCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceMCAddValueMaxLimit", g_Config.nUnknowNecklaceMCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowNecklaceMCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceSCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceSCAddRate", g_Config.nUnknowNecklaceSCAddRate);
            }
            else
            {
                g_Config.nUnknowNecklaceSCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowNecklaceSCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowNecklaceSCAddValueMaxLimit", g_Config.nUnknowNecklaceSCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowNecklaceSCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingACAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingACAddRate", g_Config.nUnknowRingACAddRate);
            }
            else
            {
                g_Config.nUnknowRingACAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingACAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingACAddValueMaxLimit", g_Config.nUnknowRingACAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowRingACAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingMACAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingMACAddRate", g_Config.nUnknowRingMACAddRate);
            }
            else
            {
                g_Config.nUnknowRingMACAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingMACAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingMACAddValueMaxLimit", g_Config.nUnknowRingMACAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowRingMACAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingDCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingDCAddRate", g_Config.nUnknowRingDCAddRate);
            }
            else
            {
                g_Config.nUnknowRingDCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingDCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingDCAddValueMaxLimit", g_Config.nUnknowRingDCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowRingDCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingMCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingMCAddRate", g_Config.nUnknowRingMCAddRate);
            }
            else
            {
                g_Config.nUnknowRingMCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingMCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingMCAddValueMaxLimit", g_Config.nUnknowRingMCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowRingMCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingSCAddRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingSCAddRate", g_Config.nUnknowRingSCAddRate);
            }
            else
            {
                g_Config.nUnknowRingSCAddRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UnknowRingSCAddValueMaxLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UnknowRingSCAddValueMaxLimit", g_Config.nUnknowRingSCAddValueMaxLimit);
            }
            else
            {
                g_Config.nUnknowRingSCAddValueMaxLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MonOneDropGoldCount", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MonOneDropGoldCount", g_Config.nMonOneDropGoldCount);
            }
            else
            {
                g_Config.nMonOneDropGoldCount = nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "MakeMineHitRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "MakeMineHitRate", g_Config.nMakeMineHitRate);
            }
            g_Config.nMakeMineHitRate = Config.ReadInteger("Setup", "MakeMineHitRate", g_Config.nMakeMineHitRate);
            if (Config.ReadInteger("Setup", "MakeMineRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "MakeMineRate", g_Config.nMakeMineRate);
            }
            g_Config.nMakeMineRate = Config.ReadInteger("Setup", "MakeMineRate", g_Config.nMakeMineRate);
            if (Config.ReadInteger("Setup", "StoneTypeRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "StoneTypeRate", g_Config.nStoneTypeRate);
            }
            g_Config.nStoneTypeRate = Config.ReadInteger("Setup", "StoneTypeRate", g_Config.nStoneTypeRate);
            if (Config.ReadInteger("Setup", "StoneTypeRateMin", -1) < 0)
            {
                Config.WriteInteger("Setup", "StoneTypeRateMin", g_Config.nStoneTypeRateMin);
            }
            g_Config.nStoneTypeRateMin = Config.ReadInteger("Setup", "StoneTypeRateMin", g_Config.nStoneTypeRateMin);
            if (Config.ReadInteger("Setup", "GoldStoneMin", -1) < 0)
            {
                Config.WriteInteger("Setup", "GoldStoneMin", g_Config.nGoldStoneMin);
            }
            g_Config.nGoldStoneMin = Config.ReadInteger("Setup", "GoldStoneMin", g_Config.nGoldStoneMin);
            if (Config.ReadInteger("Setup", "GoldStoneMax", -1) < 0)
            {
                Config.WriteInteger("Setup", "GoldStoneMax", g_Config.nGoldStoneMax);
            }
            g_Config.nGoldStoneMax = Config.ReadInteger("Setup", "GoldStoneMax", g_Config.nGoldStoneMax);
            if (Config.ReadInteger("Setup", "SilverStoneMin", -1) < 0)
            {
                Config.WriteInteger("Setup", "SilverStoneMin", g_Config.nSilverStoneMin);
            }
            g_Config.nSilverStoneMin = Config.ReadInteger("Setup", "SilverStoneMin", g_Config.nSilverStoneMin);
            if (Config.ReadInteger("Setup", "SilverStoneMax", -1) < 0)
            {
                Config.WriteInteger("Setup", "SilverStoneMax", g_Config.nSilverStoneMax);
            }
            g_Config.nSilverStoneMax = Config.ReadInteger("Setup", "SilverStoneMax", g_Config.nSilverStoneMax);
            if (Config.ReadInteger("Setup", "SteelStoneMin", -1) < 0)
            {
                Config.WriteInteger("Setup", "SteelStoneMin", g_Config.nSteelStoneMin);
            }
            g_Config.nSteelStoneMin = Config.ReadInteger("Setup", "SteelStoneMin", g_Config.nSteelStoneMin);
            if (Config.ReadInteger("Setup", "SteelStoneMax", -1) < 0)
            {
                Config.WriteInteger("Setup", "SteelStoneMax", g_Config.nSteelStoneMax);
            }
            g_Config.nSteelStoneMax = Config.ReadInteger("Setup", "SteelStoneMax", g_Config.nSteelStoneMax);
            if (Config.ReadInteger("Setup", "BlackStoneMin", -1) < 0)
            {
                Config.WriteInteger("Setup", "BlackStoneMin", g_Config.nBlackStoneMin);
            }
            g_Config.nBlackStoneMin = Config.ReadInteger("Setup", "BlackStoneMin", g_Config.nBlackStoneMin);
            if (Config.ReadInteger("Setup", "BlackStoneMax", -1) < 0)
            {
                Config.WriteInteger("Setup", "BlackStoneMax", g_Config.nBlackStoneMax);
            }
            g_Config.nBlackStoneMax = Config.ReadInteger("Setup", "BlackStoneMax", g_Config.nBlackStoneMax);
            if (Config.ReadInteger("Setup", "StoneMinDura", -1) < 0)
            {
                Config.WriteInteger("Setup", "StoneMinDura", g_Config.nStoneMinDura);
            }
            g_Config.nStoneMinDura = Config.ReadInteger("Setup", "StoneMinDura", g_Config.nStoneMinDura);
            if (Config.ReadInteger("Setup", "StoneGeneralDuraRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "StoneGeneralDuraRate", g_Config.nStoneGeneralDuraRate);
            }
            g_Config.nStoneGeneralDuraRate = Config.ReadInteger("Setup", "StoneGeneralDuraRate", g_Config.nStoneGeneralDuraRate);
            if (Config.ReadInteger("Setup", "StoneAddDuraRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "StoneAddDuraRate", g_Config.nStoneAddDuraRate);
            }
            g_Config.nStoneAddDuraRate = Config.ReadInteger("Setup", "StoneAddDuraRate", g_Config.nStoneAddDuraRate);
            if (Config.ReadInteger("Setup", "StoneAddDuraMax", -1) < 0)
            {
                Config.WriteInteger("Setup", "StoneAddDuraMax", g_Config.nStoneAddDuraMax);
            }
            g_Config.nStoneAddDuraMax = Config.ReadInteger("Setup", "StoneAddDuraMax", g_Config.nStoneAddDuraMax);
            if (Config.ReadInteger("Setup", "WinLottery1Min", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery1Min", g_Config.nWinLottery1Min);
            }
            g_Config.nWinLottery1Min = Config.ReadInteger("Setup", "WinLottery1Min", g_Config.nWinLottery1Min);
            if (Config.ReadInteger("Setup", "WinLottery1Max", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery1Max", g_Config.nWinLottery1Max);
            }
            g_Config.nWinLottery1Max = Config.ReadInteger("Setup", "WinLottery1Max", g_Config.nWinLottery1Max);
            if (Config.ReadInteger("Setup", "WinLottery2Min", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery2Min", g_Config.nWinLottery2Min);
            }
            g_Config.nWinLottery2Min = Config.ReadInteger("Setup", "WinLottery2Min", g_Config.nWinLottery2Min);
            if (Config.ReadInteger("Setup", "WinLottery2Max", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery2Max", g_Config.nWinLottery2Max);
            }
            g_Config.nWinLottery2Max = Config.ReadInteger("Setup", "WinLottery2Max", g_Config.nWinLottery2Max);
            if (Config.ReadInteger("Setup", "WinLottery3Min", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery3Min", g_Config.nWinLottery3Min);
            }
            g_Config.nWinLottery3Min = Config.ReadInteger("Setup", "WinLottery3Min", g_Config.nWinLottery3Min);
            if (Config.ReadInteger("Setup", "WinLottery3Max", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery3Max", g_Config.nWinLottery3Max);
            }
            g_Config.nWinLottery3Max = Config.ReadInteger("Setup", "WinLottery3Max", g_Config.nWinLottery3Max);
            if (Config.ReadInteger("Setup", "WinLottery4Min", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery4Min", g_Config.nWinLottery4Min);
            }
            g_Config.nWinLottery4Min = Config.ReadInteger("Setup", "WinLottery4Min", g_Config.nWinLottery4Min);
            if (Config.ReadInteger("Setup", "WinLottery4Max", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery4Max", g_Config.nWinLottery4Max);
            }
            g_Config.nWinLottery4Max = Config.ReadInteger("Setup", "WinLottery4Max", g_Config.nWinLottery4Max);
            if (Config.ReadInteger("Setup", "WinLottery5Min", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery5Min", g_Config.nWinLottery5Min);
            }
            g_Config.nWinLottery5Min = Config.ReadInteger("Setup", "WinLottery5Min", g_Config.nWinLottery5Min);
            if (Config.ReadInteger("Setup", "WinLottery5Max", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery5Max", g_Config.nWinLottery5Max);
            }
            g_Config.nWinLottery5Max = Config.ReadInteger("Setup", "WinLottery5Max", g_Config.nWinLottery5Max);
            if (Config.ReadInteger("Setup", "WinLottery6Min", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery6Min", g_Config.nWinLottery6Min);
            }
            g_Config.nWinLottery6Min = Config.ReadInteger("Setup", "WinLottery6Min", g_Config.nWinLottery6Min);
            if (Config.ReadInteger("Setup", "WinLottery6Max", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery6Max", g_Config.nWinLottery6Max);
            }
            g_Config.nWinLottery6Max = Config.ReadInteger("Setup", "WinLottery6Max", g_Config.nWinLottery6Max);
            if (Config.ReadInteger("Setup", "WinLotteryRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryRate", g_Config.nWinLotteryRate);
            }
            g_Config.nWinLotteryRate = Config.ReadInteger("Setup", "WinLotteryRate", g_Config.nWinLotteryRate);
            if (Config.ReadInteger("Setup", "WinLottery1Gold", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery1Gold", g_Config.nWinLottery1Gold);
            }
            g_Config.nWinLottery1Gold = Config.ReadInteger("Setup", "WinLottery1Gold", g_Config.nWinLottery1Gold);
            if (Config.ReadInteger("Setup", "WinLottery2Gold", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery2Gold", g_Config.nWinLottery2Gold);
            }
            g_Config.nWinLottery2Gold = Config.ReadInteger("Setup", "WinLottery2Gold", g_Config.nWinLottery2Gold);
            if (Config.ReadInteger("Setup", "WinLottery3Gold", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery3Gold", g_Config.nWinLottery3Gold);
            }
            g_Config.nWinLottery3Gold = Config.ReadInteger("Setup", "WinLottery3Gold", g_Config.nWinLottery3Gold);
            if (Config.ReadInteger("Setup", "WinLottery4Gold", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery4Gold", g_Config.nWinLottery4Gold);
            }
            g_Config.nWinLottery4Gold = Config.ReadInteger("Setup", "WinLottery4Gold", g_Config.nWinLottery4Gold);
            if (Config.ReadInteger("Setup", "WinLottery5Gold", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery5Gold", g_Config.nWinLottery5Gold);
            }
            g_Config.nWinLottery5Gold = Config.ReadInteger("Setup", "WinLottery5Gold", g_Config.nWinLottery5Gold);
            if (Config.ReadInteger("Setup", "WinLottery6Gold", -1) < 0)
            {
                Config.WriteInteger("Setup", "WinLottery6Gold", g_Config.nWinLottery6Gold);
            }
            g_Config.nWinLottery6Gold = Config.ReadInteger("Setup", "WinLottery6Gold", g_Config.nWinLottery6Gold);
            if (Config.ReadInteger("Setup", "GuildRecallTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildRecallTime", g_Config.nGuildRecallTime);
            }
            g_Config.nGuildRecallTime = Config.ReadInteger("Setup", "GuildRecallTime", g_Config.nGuildRecallTime);
            if (Config.ReadInteger("Setup", "GroupRecallTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "GroupRecallTime", g_Config.nGroupRecallTime);
            }
            g_Config.nGroupRecallTime = Config.ReadInteger("Setup", "GroupRecallTime", g_Config.nGroupRecallTime);
            if (Config.ReadInteger("Setup", "ControlDropItem", -1) < 0)
            {
                Config.WriteBool("Setup", "ControlDropItem", g_Config.boControlDropItem);
            }
            g_Config.boControlDropItem = Config.ReadBool("Setup", "ControlDropItem", g_Config.boControlDropItem);
            if (Config.ReadInteger("Setup", "InSafeDisableDrop", -1) < 0)
            {
                Config.WriteBool("Setup", "InSafeDisableDrop", g_Config.boInSafeDisableDrop);
            }
            g_Config.boInSafeDisableDrop = Config.ReadBool("Setup", "InSafeDisableDrop", g_Config.boInSafeDisableDrop);
            if (Config.ReadInteger("Setup", "CanDropGold", -1) < 0)
            {
                Config.WriteInteger("Setup", "CanDropGold", g_Config.nCanDropGold);
            }
            g_Config.nCanDropGold = Config.ReadInteger("Setup", "CanDropGold", g_Config.nCanDropGold);
            if (Config.ReadInteger("Setup", "CanDropPrice", -1) < 0)
            {
                Config.WriteInteger("Setup", "CanDropPrice", g_Config.nCanDropPrice);
            }
            g_Config.nCanDropPrice = Config.ReadInteger("Setup", "CanDropPrice", g_Config.nCanDropPrice);
            nLoadInteger = Config.ReadInteger("Setup", "SendCustemMsg", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "SendCustemMsg", g_Config.boSendCustemMsg);
            }
            else
            {
                g_Config.boSendCustemMsg = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "SubkMasterSendMsg", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "SubkMasterSendMsg", g_Config.boSubkMasterSendMsg);
            }
            else
            {
                g_Config.boSubkMasterSendMsg = nLoadInteger == 1;
            }
            if (Config.ReadInteger("Setup", "SuperRepairPriceRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "SuperRepairPriceRate", g_Config.nSuperRepairPriceRate);
            }
            g_Config.nSuperRepairPriceRate = Config.ReadInteger("Setup", "SuperRepairPriceRate", g_Config.nSuperRepairPriceRate);
            if (Config.ReadInteger("Setup", "RepairItemDecDura", -1) < 0)
            {
                Config.WriteInteger("Setup", "RepairItemDecDura", g_Config.nRepairItemDecDura);
            }
            g_Config.nRepairItemDecDura = Config.ReadInteger("Setup", "RepairItemDecDura", g_Config.nRepairItemDecDura);
            if (Config.ReadInteger("Setup", "DieScatterBag", -1) < 0)
            {
                Config.WriteBool("Setup", "DieScatterBag", g_Config.boDieScatterBag);
            }
            g_Config.boDieScatterBag = Config.ReadBool("Setup", "DieScatterBag", g_Config.boDieScatterBag);
            if (Config.ReadInteger("Setup", "DieScatterBagRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DieScatterBagRate", g_Config.nDieScatterBagRate);
            }
            g_Config.nDieScatterBagRate = Config.ReadInteger("Setup", "DieScatterBagRate", g_Config.nDieScatterBagRate);
            if (Config.ReadInteger("Setup", "DieRedScatterBagAll", -1) < 0)
            {
                Config.WriteBool("Setup", "DieRedScatterBagAll", g_Config.boDieRedScatterBagAll);
            }
            g_Config.boDieRedScatterBagAll = Config.ReadBool("Setup", "DieRedScatterBagAll", g_Config.boDieRedScatterBagAll);
            if (Config.ReadInteger("Setup", "DieDropUseItemRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DieDropUseItemRate", g_Config.nDieDropUseItemRate);
            }
            g_Config.nDieDropUseItemRate = Config.ReadInteger("Setup", "DieDropUseItemRate", g_Config.nDieDropUseItemRate);
            if (Config.ReadInteger("Setup", "DieRedDropUseItemRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "DieRedDropUseItemRate", g_Config.nDieRedDropUseItemRate);
            }
            g_Config.nDieRedDropUseItemRate = Config.ReadInteger("Setup", "DieRedDropUseItemRate", g_Config.nDieRedDropUseItemRate);
            if (Config.ReadInteger("Setup", "DieDropGold", -1) < 0)
            {
                Config.WriteBool("Setup", "DieDropGold", g_Config.boDieDropGold);
            }
            g_Config.boDieDropGold = Config.ReadBool("Setup", "DieDropGold", g_Config.boDieDropGold);
            if (Config.ReadInteger("Setup", "KillByHumanDropUseItem", -1) < 0)
            {
                Config.WriteBool("Setup", "KillByHumanDropUseItem", g_Config.boKillByHumanDropUseItem);
            }
            g_Config.boKillByHumanDropUseItem = Config.ReadBool("Setup", "KillByHumanDropUseItem", g_Config.boKillByHumanDropUseItem);
            if (Config.ReadInteger("Setup", "KillByMonstDropUseItem", -1) < 0)
            {
                Config.WriteBool("Setup", "KillByMonstDropUseItem", g_Config.boKillByMonstDropUseItem);
            }
            g_Config.boKillByMonstDropUseItem = Config.ReadBool("Setup", "KillByMonstDropUseItem", g_Config.boKillByMonstDropUseItem);
            if (Config.ReadInteger("Setup", "KickExpireHuman", -1) < 0)
            {
                Config.WriteBool("Setup", "KickExpireHuman", g_Config.boKickExpireHuman);
            }
            g_Config.boKickExpireHuman = Config.ReadBool("Setup", "KickExpireHuman", g_Config.boKickExpireHuman);
            if (Config.ReadInteger("Setup", "GuildRankNameLen", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildRankNameLen", g_Config.nGuildRankNameLen);
            }
            g_Config.nGuildRankNameLen = Config.ReadInteger("Setup", "GuildRankNameLen", g_Config.nGuildRankNameLen);
            if (Config.ReadInteger("Setup", "GuildNameLen", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildNameLen", g_Config.nGuildNameLen);
            }
            g_Config.nGuildNameLen = Config.ReadInteger("Setup", "GuildNameLen", g_Config.nGuildNameLen);
            if (Config.ReadInteger("Setup", "GuildMemberMaxLimit", -1) < 0)
            {
                Config.WriteInteger("Setup", "GuildMemberMaxLimit", g_Config.nGuildMemberMaxLimit);
            }
            g_Config.nGuildMemberMaxLimit = Config.ReadInteger("Setup", "GuildMemberMaxLimit", g_Config.nGuildMemberMaxLimit);
            if (Config.ReadInteger("Setup", "AttackPosionRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "AttackPosionRate", g_Config.nAttackPosionRate);
            }
            g_Config.nAttackPosionRate = Config.ReadInteger("Setup", "AttackPosionRate", g_Config.nAttackPosionRate);
            if (Config.ReadInteger("Setup", "AttackPosionTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "AttackPosionTime", g_Config.nAttackPosionTime);
            }
            g_Config.nAttackPosionTime = Config.ReadInteger("Setup", "AttackPosionTime", g_Config.nAttackPosionTime);
            if (Config.ReadInteger("Setup", "RevivalTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "RevivalTime", g_Config.dwRevivalTime);
            }
            g_Config.dwRevivalTime = Config.ReadInteger("Setup", "RevivalTime", g_Config.dwRevivalTime);
            nLoadInteger = Config.ReadInteger("Setup", "UserMoveCanDupObj", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "UserMoveCanDupObj", g_Config.boUserMoveCanDupObj);
            }
            else
            {
                g_Config.boUserMoveCanDupObj = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UserMoveCanOnItem", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "UserMoveCanOnItem", g_Config.boUserMoveCanOnItem);
            }
            else
            {
                g_Config.boUserMoveCanOnItem = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "UserMoveTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "UserMoveTime", g_Config.dwUserMoveTime);
            }
            else
            {
                g_Config.dwUserMoveTime = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "PKDieLostExpRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "PKDieLostExpRate", g_Config.dwPKDieLostExpRate);
            }
            else
            {
                g_Config.dwPKDieLostExpRate = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "PKDieLostLevelRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "PKDieLostLevelRate", g_Config.nPKDieLostLevelRate);
            }
            else
            {
                g_Config.nPKDieLostLevelRate = nLoadInteger;
            }
            // 挑战时间 20080706
            if (Config.ReadInteger("Setup", "ChallengeTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "ChallengeTime", g_Config.nChallengeTime);
            }
            g_Config.nChallengeTime = Config.ReadInteger("Setup", "ChallengeTime", g_Config.nChallengeTime);
            // NPC名字颜色 20081218
            if (Config.ReadInteger("Setup", "NPCNameColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "NPCNameColor", g_Config.btNPCNameColor);
            }
            g_Config.btNPCNameColor = Config.ReadInteger("Setup", "NPCNameColor", g_Config.btNPCNameColor);
            if (Config.ReadInteger("Setup", "PKFlagNameColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "PKFlagNameColor", g_Config.btPKFlagNameColor);
            }
            g_Config.btPKFlagNameColor = Config.ReadInteger("Setup", "PKFlagNameColor", g_Config.btPKFlagNameColor);
            if (Config.ReadInteger("Setup", "AllyAndGuildNameColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "AllyAndGuildNameColor", g_Config.btAllyAndGuildNameColor);
            }
            g_Config.btAllyAndGuildNameColor = Config.ReadInteger("Setup", "AllyAndGuildNameColor", g_Config.btAllyAndGuildNameColor);
            if (Config.ReadInteger("Setup", "WarGuildNameColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "WarGuildNameColor", g_Config.btWarGuildNameColor);
            }
            g_Config.btWarGuildNameColor = Config.ReadInteger("Setup", "WarGuildNameColor", g_Config.btWarGuildNameColor);
            if (Config.ReadInteger("Setup", "InFreePKAreaNameColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "InFreePKAreaNameColor", g_Config.btInFreePKAreaNameColor);
            }
            g_Config.btInFreePKAreaNameColor = Config.ReadInteger("Setup", "InFreePKAreaNameColor", g_Config.btInFreePKAreaNameColor);
            if (Config.ReadInteger("Setup", "PKLevel1NameColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "PKLevel1NameColor", g_Config.btPKLevel1NameColor);
            }
            g_Config.btPKLevel1NameColor = Config.ReadInteger("Setup", "PKLevel1NameColor", g_Config.btPKLevel1NameColor);
            if (Config.ReadInteger("Setup", "PKLevel2NameColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "PKLevel2NameColor", g_Config.btPKLevel2NameColor);
            }
            g_Config.btPKLevel2NameColor = Config.ReadInteger("Setup", "PKLevel2NameColor", g_Config.btPKLevel2NameColor);
            if (Config.ReadInteger("Setup", "SpiritMutiny", -1) < 0)
            {
                Config.WriteBool("Setup", "SpiritMutiny", g_Config.boSpiritMutiny);
            }
            g_Config.boSpiritMutiny = Config.ReadBool("Setup", "SpiritMutiny", g_Config.boSpiritMutiny);
            if (Config.ReadInteger("Setup", "SpiritMutinyTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "SpiritMutinyTime", g_Config.dwSpiritMutinyTime);
            }
            g_Config.dwSpiritMutinyTime = Config.ReadInteger("Setup", "SpiritMutinyTime", g_Config.dwSpiritMutinyTime);
            // //20080504 未使用  祈祷能量倍数
            // if Config.ReadInteger('Setup', 'SpiritPowerRate', -1) < 0 then
            // Config.WriteInteger('Setup', 'SpiritPowerRate', g_Config.nSpiritPowerRate);
            // g_Config.nSpiritPowerRate := Config.ReadInteger('Setup', 'SpiritPowerRate', g_Config.nSpiritPowerRate);
            if (Config.ReadInteger("Setup", "MasterDieMutiny", -1) < 0)
            {
                Config.WriteBool("Setup", "MasterDieMutiny", g_Config.boMasterDieMutiny);
            }
            g_Config.boMasterDieMutiny = Config.ReadBool("Setup", "MasterDieMutiny", g_Config.boMasterDieMutiny);
            if (Config.ReadInteger("Setup", "MasterDieMutinyRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "MasterDieMutinyRate", g_Config.nMasterDieMutinyRate);
            }
            g_Config.nMasterDieMutinyRate = Config.ReadInteger("Setup", "MasterDieMutinyRate", g_Config.nMasterDieMutinyRate);
            if (Config.ReadInteger("Setup", "MasterDieMutinyPower", -1) < 0)
            {
                Config.WriteInteger("Setup", "MasterDieMutinyPower", g_Config.nMasterDieMutinyPower);
            }
            g_Config.nMasterDieMutinyPower = Config.ReadInteger("Setup", "MasterDieMutinyPower", g_Config.nMasterDieMutinyPower);
            if (Config.ReadInteger("Setup", "MasterDieMutinyPower", -1) < 0)
            {
                Config.WriteInteger("Setup", "MasterDieMutinyPower", g_Config.nMasterDieMutinySpeed);
            }
            g_Config.nMasterDieMutinySpeed = Config.ReadInteger("Setup", "MasterDieMutinyPower", g_Config.nMasterDieMutinySpeed);
            nLoadInteger = Config.ReadInteger("Setup", "BBMonAutoChangeColor", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "BBMonAutoChangeColor", g_Config.boBBMonAutoChangeColor);
            }
            else
            {
                g_Config.boBBMonAutoChangeColor = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "BBMonAutoChangeColorTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "BBMonAutoChangeColorTime", g_Config.dwBBMonAutoChangeColorTime);
            }
            else
            {
                g_Config.dwBBMonAutoChangeColorTime = nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "OldClientShowHiLevel", -1) < 0)
            {
                Config.WriteBool("Setup", "OldClientShowHiLevel", g_Config.boOldClientShowHiLevel);
            }
            g_Config.boOldClientShowHiLevel = Config.ReadBool("Setup", "OldClientShowHiLevel", g_Config.boOldClientShowHiLevel);
            if (Config.ReadInteger("Setup", "ShowScriptActionMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "ShowScriptActionMsg", g_Config.boShowScriptActionMsg);
            }
            g_Config.boShowScriptActionMsg = Config.ReadBool("Setup", "ShowScriptActionMsg", g_Config.boShowScriptActionMsg);
            // //未使用变量 20080504
            // if Config.ReadInteger('Setup', 'RunSocketDieLoopLimit', -1) < 0 then
            // Config.WriteInteger('Setup', 'RunSocketDieLoopLimit', g_Config.nRunSocketDieLoopLimit);
            // g_Config.nRunSocketDieLoopLimit := Config.ReadInteger('Setup', 'RunSocketDieLoopLimit', g_Config.nRunSocketDieLoopLimit);
            if (Config.ReadInteger("Setup", "ThreadRun", -1) < 0)
            {
                Config.WriteBool("Setup", "ThreadRun", g_Config.boThreadRun);
            }
            g_Config.boThreadRun = Config.ReadBool("Setup", "ThreadRun", g_Config.boThreadRun);
            if (Config.ReadInteger("Setup", "DeathColorEffect", -1) < 0)
            {
                Config.WriteInteger("Setup", "DeathColorEffect", g_Config.ClientConf.btDieColor);
            }
            g_Config.ClientConf.btDieColor = Config.ReadInteger("Setup", "DeathColorEffect", g_Config.ClientConf.btDieColor);
            if (Config.ReadInteger("Setup", "ParalyCanRun", -1) < 0)
            {
                Config.WriteBool("Setup", "ParalyCanRun", g_Config.ClientConf.boParalyCanRun);
            }
            g_Config.ClientConf.boParalyCanRun = Config.ReadBool("Setup", "ParalyCanRun", g_Config.ClientConf.boParalyCanRun);
            if (Config.ReadInteger("Setup", "ParalyCanWalk", -1) < 0)
            {
                Config.WriteBool("Setup", "ParalyCanWalk", g_Config.ClientConf.boParalyCanWalk);
            }
            g_Config.ClientConf.boParalyCanWalk = Config.ReadBool("Setup", "ParalyCanWalk", g_Config.ClientConf.boParalyCanWalk);
            if (Config.ReadInteger("Setup", "ParalyCanHit", -1) < 0)
            {
                Config.WriteBool("Setup", "ParalyCanHit", g_Config.ClientConf.boParalyCanHit);
            }
            g_Config.ClientConf.boParalyCanHit = Config.ReadBool("Setup", "ParalyCanHit", g_Config.ClientConf.boParalyCanHit);
            if (Config.ReadInteger("Setup", "ParalyCanSpell", -1) < 0)
            {
                Config.WriteBool("Setup", "ParalyCanSpell", g_Config.ClientConf.boParalyCanSpell);
            }
            g_Config.ClientConf.boParalyCanSpell = Config.ReadBool("Setup", "ParalyCanSpell", g_Config.ClientConf.boParalyCanSpell);
            if (Config.ReadInteger("Setup", "ShowExceptionMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "ShowExceptionMsg", g_Config.boShowExceptionMsg);
            }
            g_Config.boShowExceptionMsg = Config.ReadBool("Setup", "ShowExceptionMsg", g_Config.boShowExceptionMsg);
            if (Config.ReadInteger("Setup", "ShowPreFixMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "ShowPreFixMsg", g_Config.boShowPreFixMsg);
            }
            g_Config.boShowPreFixMsg = Config.ReadBool("Setup", "ShowPreFixMsg", g_Config.boShowPreFixMsg);
            // GM命令错误是否提示 20080602
            if (Config.ReadInteger("Setup", "GMShowFailMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "GMShowFailMsg", g_Config.boGMShowFailMsg);
            }
            g_Config.boGMShowFailMsg = Config.ReadBool("Setup", "GMShowFailMsg", g_Config.boGMShowFailMsg);
            // 记录人物私聊，行会聊天信息 20081213
            if (Config.ReadInteger("Setup", "RecordClientMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "RecordClientMsg", g_Config.boRecordClientMsg);
            }
            g_Config.boRecordClientMsg = Config.ReadBool("Setup", "RecordClientMsg", g_Config.boRecordClientMsg);
            if (Config.ReadInteger("Setup", "MagTurnUndeadLevel", -1) < 0)
            {
                Config.WriteInteger("Setup", "MagTurnUndeadLevel", g_Config.nMagTurnUndeadLevel);
            }
            g_Config.nMagTurnUndeadLevel = Config.ReadInteger("Setup", "MagTurnUndeadLevel", g_Config.nMagTurnUndeadLevel);
            nLoadInteger = Config.ReadInteger("Setup", "MagTammingLevel", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagTammingLevel", g_Config.nMagTammingLevel);
            }
            else
            {
                g_Config.nMagTammingLevel = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MagTammingTargetLevel", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagTammingTargetLevel", g_Config.nMagTammingTargetLevel);
            }
            else
            {
                g_Config.nMagTammingTargetLevel = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MagTammingTargetHPRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagTammingTargetHPRate", g_Config.nMagTammingHPRate);
            }
            else
            {
                g_Config.nMagTammingHPRate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MagTammingCount", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagTammingCount", g_Config.nMagTammingCount);
            }
            else
            {
                g_Config.nMagTammingCount = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MabMabeHitRandRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MabMabeHitRandRate", g_Config.nMabMabeHitRandRate);
            }
            else
            {
                g_Config.nMabMabeHitRandRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MabMabeHitMinLvLimit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MabMabeHitMinLvLimit", g_Config.nMabMabeHitMinLvLimit);
            }
            else
            {
                g_Config.nMabMabeHitMinLvLimit = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MabMabeHitSucessRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MabMabeHitSucessRate", g_Config.nMabMabeHitSucessRate);
            }
            else
            {
                g_Config.nMabMabeHitSucessRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MabMabeHitMabeTimeRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MabMabeHitMabeTimeRate", g_Config.nMabMabeHitMabeTimeRate);
            }
            else
            {
                g_Config.nMabMabeHitMabeTimeRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MagicAttackRage", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagicAttackRage", g_Config.nMagicAttackRage);
            }
            else
            {
                g_Config.nMagicAttackRage = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "AmyOunsulPoint", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "AmyOunsulPoint", g_Config.nAmyOunsulPoint);
            }
            else
            {
                g_Config.nAmyOunsulPoint = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "DisableInSafeZoneFireCross", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "DisableInSafeZoneFireCross", g_Config.boDisableInSafeZoneFireCross);
            }
            else
            {
                g_Config.boDisableInSafeZoneFireCross = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "GroupMbAttackPlayObject", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "GroupMbAttackPlayObject", g_Config.boGroupMbAttackPlayObject);
            }
            else
            {
                g_Config.boGroupMbAttackPlayObject = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "PosionDecHealthTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "PosionDecHealthTime", g_Config.dwPosionDecHealthTime);
            }
            else
            {
                g_Config.dwPosionDecHealthTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "PosionDamagarmor", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "PosionDamagarmor", g_Config.nPosionDamagarmor);
            }
            else
            {
                g_Config.nPosionDamagarmor = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "LimitSwordLong", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "LimitSwordLong", g_Config.boLimitSwordLong);
            }
            else
            {
                g_Config.boLimitSwordLong = !(nLoadInteger == 0);
            }
            nLoadInteger = Config.ReadInteger("Setup", "SwordLongPowerRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "SwordLongPowerRate", g_Config.nSwordLongPowerRate);
            }
            else
            {
                g_Config.nSwordLongPowerRate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "FireBoomRage", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "FireBoomRage", g_Config.nFireBoomRage);
            }
            else
            {
                g_Config.nFireBoomRage = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "SnowWindRange", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "SnowWindRange", g_Config.nSnowWindRange);
            }
            else
            {
                g_Config.nSnowWindRange = (byte)nLoadInteger;
            }
            // 流星火雨攻击范围 20080510
            nLoadInteger = Config.ReadInteger("Setup", "MeteorFireRainRage", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MeteorFireRainRage", g_Config.nMeteorFireRainRage);
            }
            else
            {
                g_Config.nMeteorFireRainRage = (byte)nLoadInteger;
            }
            // 噬血术加血百分率 20080511
            nLoadInteger = Config.ReadInteger("Setup", "MagFireCharmTreatment", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagFireCharmTreatment", g_Config.nMagFireCharmTreatment);
            }
            else
            {
                g_Config.nMagFireCharmTreatment = (byte)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "ElecBlizzardRange", -1) < 0)
            {
                Config.WriteInteger("Setup", "ElecBlizzardRange", g_Config.nElecBlizzardRange);
            }
            g_Config.nElecBlizzardRange = Config.ReadInteger("Setup", "ElecBlizzardRange", g_Config.nElecBlizzardRange);
            if (Config.ReadInteger("Setup", "HumanLevelDiffer", -1) < 0)
            {
                Config.WriteInteger("Setup", "HumanLevelDiffer", g_Config.nHumanLevelDiffer);
            }
            g_Config.nHumanLevelDiffer = Config.ReadInteger("Setup", "HumanLevelDiffer", g_Config.nHumanLevelDiffer);
            if (Config.ReadInteger("Setup", "KillHumanWinLevel", -1) < 0)
            {
                Config.WriteBool("Setup", "KillHumanWinLevel", g_Config.boKillHumanWinLevel);
            }
            g_Config.boKillHumanWinLevel = Config.ReadBool("Setup", "KillHumanWinLevel", g_Config.boKillHumanWinLevel);
            if (Config.ReadInteger("Setup", "KilledLostLevel", -1) < 0)
            {
                Config.WriteBool("Setup", "KilledLostLevel", g_Config.boKilledLostLevel);
            }
            g_Config.boKilledLostLevel = Config.ReadBool("Setup", "KilledLostLevel", g_Config.boKilledLostLevel);
            if (Config.ReadInteger("Setup", "KillHumanWinLevelPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "KillHumanWinLevelPoint", g_Config.nKillHumanWinLevel);
            }
            g_Config.nKillHumanWinLevel = Config.ReadInteger("Setup", "KillHumanWinLevelPoint", g_Config.nKillHumanWinLevel);
            if (Config.ReadInteger("Setup", "KilledLostLevelPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "KilledLostLevelPoint", g_Config.nKilledLostLevel);
            }
            g_Config.nKilledLostLevel = Config.ReadInteger("Setup", "KilledLostLevelPoint", g_Config.nKilledLostLevel);
            if (Config.ReadInteger("Setup", "KillHumanWinExp", -1) < 0)
            {
                Config.WriteBool("Setup", "KillHumanWinExp", g_Config.boKillHumanWinExp);
            }
            g_Config.boKillHumanWinExp = Config.ReadBool("Setup", "KillHumanWinExp", g_Config.boKillHumanWinExp);
            if (Config.ReadInteger("Setup", "KilledLostExp", -1) < 0)
            {
                Config.WriteBool("Setup", "KilledLostExp", g_Config.boKilledLostExp);
            }
            g_Config.boKilledLostExp = Config.ReadBool("Setup", "KilledLostExp", g_Config.boKilledLostExp);
            if (Config.ReadInteger("Setup", "KillHumanWinExpPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "KillHumanWinExpPoint", g_Config.nKillHumanWinExp);
            }
            g_Config.nKillHumanWinExp = Config.ReadInteger("Setup", "KillHumanWinExpPoint", g_Config.nKillHumanWinExp);
            if (Config.ReadInteger("Setup", "KillHumanLostExpPoint", -1) < 0)
            {
                Config.WriteInteger("Setup", "KillHumanLostExpPoint", g_Config.nKillHumanLostExp);
            }
            g_Config.nKillHumanLostExp = Config.ReadInteger("Setup", "KillHumanLostExpPoint", g_Config.nKillHumanLostExp);
            if (Config.ReadInteger("Setup", "MonsterPowerRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "MonsterPowerRate", g_Config.nMonsterPowerRate);
            }
            g_Config.nMonsterPowerRate = Config.ReadInteger("Setup", "MonsterPowerRate", g_Config.nMonsterPowerRate);
            if (Config.ReadInteger("Setup", "ItemsPowerRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ItemsPowerRate", g_Config.nItemsPowerRate);
            }
            g_Config.nItemsPowerRate = Config.ReadInteger("Setup", "ItemsPowerRate", g_Config.nItemsPowerRate);
            if (Config.ReadInteger("Setup", "ItemsACPowerRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "ItemsACPowerRate", g_Config.nItemsACPowerRate);
            }
            g_Config.nItemsACPowerRate = Config.ReadInteger("Setup", "ItemsACPowerRate", g_Config.nItemsACPowerRate);
            if (Config.ReadInteger("Setup", "SendOnlineCount", -1) < 0)
            {
                Config.WriteBool("Setup", "SendOnlineCount", g_Config.boSendOnlineCount);
            }
            g_Config.boSendOnlineCount = Config.ReadBool("Setup", "SendOnlineCount", g_Config.boSendOnlineCount);
            if (Config.ReadInteger("Setup", "SendOnlineCountRate", -1) < 0)
            {
                Config.WriteInteger("Setup", "SendOnlineCountRate", g_Config.nSendOnlineCountRate);
            }
            g_Config.nSendOnlineCountRate = Config.ReadInteger("Setup", "SendOnlineCountRate", g_Config.nSendOnlineCountRate);
            if (Config.ReadInteger("Setup", "SendOnlineTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "SendOnlineTime", g_Config.dwSendOnlineTime);
            }
            g_Config.dwSendOnlineTime = Config.ReadInteger("Setup", "SendOnlineTime", g_Config.dwSendOnlineTime);
            if (Config.ReadInteger("Setup", "SaveHumanRcdTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "SaveHumanRcdTime", g_Config.dwSaveHumanRcdTime);
            }
            g_Config.dwSaveHumanRcdTime = Config.ReadInteger("Setup", "SaveHumanRcdTime", g_Config.dwSaveHumanRcdTime);
            if (Config.ReadInteger("Setup", "HumanFreeDelayTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "HumanFreeDelayTime", g_Config.dwHumanFreeDelayTime);
            }
            // g_Config.dwHumanFreeDelayTime:=Config.ReadInteger('Setup','HumanFreeDelayTime',g_Config.dwHumanFreeDelayTime);
            // 尸体清理时间
            if (Config.ReadInteger("Setup", "MakeGhostTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "MakeGhostTime", g_Config.dwMakeGhostTime);
            }
            g_Config.dwMakeGhostTime = Config.ReadInteger("Setup", "MakeGhostTime", g_Config.dwMakeGhostTime);
            // 人形怪尸体清理时间 20080418
            if (Config.ReadInteger("Setup", "MakeGhostPlayMosterTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "MakeGhostPlayMosterTime", g_Config.dwMakeGhostPlayMosterTime);
            }
            g_Config.dwMakeGhostPlayMosterTime = Config.ReadInteger("Setup", "MakeGhostPlayMosterTime", g_Config.dwMakeGhostPlayMosterTime);
            if (Config.ReadInteger("Setup", "ClearDropOnFloorItemTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "ClearDropOnFloorItemTime", g_Config.dwClearDropOnFloorItemTime);
            }
            g_Config.dwClearDropOnFloorItemTime = Config.ReadInteger("Setup", "ClearDropOnFloorItemTime", g_Config.dwClearDropOnFloorItemTime);
            if (Config.ReadInteger("Setup", "FloorItemCanPickUpTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "FloorItemCanPickUpTime", g_Config.dwFloorItemCanPickUpTime);
            }
            g_Config.dwFloorItemCanPickUpTime = Config.ReadInteger("Setup", "FloorItemCanPickUpTime", g_Config.dwFloorItemCanPickUpTime);
            if (Config.ReadInteger("Setup", "PasswordLockSystem", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockSystem", g_Config.boPasswordLockSystem);
            }
            g_Config.boPasswordLockSystem = Config.ReadBool("Setup", "PasswordLockSystem", g_Config.boPasswordLockSystem);
            if (Config.ReadInteger("Setup", "PasswordLockDealAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockDealAction", g_Config.boLockDealAction);
            }
            g_Config.boLockDealAction = Config.ReadBool("Setup", "PasswordLockDealAction", g_Config.boLockDealAction);
            if (Config.ReadInteger("Setup", "PasswordLockDropAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockDropAction", g_Config.boLockDropAction);
            }
            g_Config.boLockDropAction = Config.ReadBool("Setup", "PasswordLockDropAction", g_Config.boLockDropAction);
            if (Config.ReadInteger("Setup", "PasswordLockGetBackItemAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockGetBackItemAction", g_Config.boLockGetBackItemAction);
            }
            g_Config.boLockGetBackItemAction = Config.ReadBool("Setup", "PasswordLockGetBackItemAction", g_Config.boLockGetBackItemAction);
            if (Config.ReadInteger("Setup", "PasswordLockHumanLogin", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockHumanLogin", g_Config.boLockHumanLogin);
            }
            g_Config.boLockHumanLogin = Config.ReadBool("Setup", "PasswordLockHumanLogin", g_Config.boLockHumanLogin);
            if (Config.ReadInteger("Setup", "PasswordLockWalkAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockWalkAction", g_Config.boLockWalkAction);
            }
            g_Config.boLockWalkAction = Config.ReadBool("Setup", "PasswordLockWalkAction", g_Config.boLockWalkAction);
            if (Config.ReadInteger("Setup", "PasswordLockRunAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockRunAction", g_Config.boLockRunAction);
            }
            g_Config.boLockRunAction = Config.ReadBool("Setup", "PasswordLockRunAction", g_Config.boLockRunAction);
            if (Config.ReadInteger("Setup", "PasswordLockHitAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockHitAction", g_Config.boLockHitAction);
            }
            g_Config.boLockHitAction = Config.ReadBool("Setup", "PasswordLockHitAction", g_Config.boLockHitAction);
            if (Config.ReadInteger("Setup", "PasswordLockSpellAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockSpellAction", g_Config.boLockSpellAction);
            }
            g_Config.boLockSpellAction = Config.ReadBool("Setup", "PasswordLockSpellAction", g_Config.boLockSpellAction);
            // 是否锁定召唤英雄操作  20080529
            if (Config.ReadInteger("Setup", "PasswordLockCallHeroAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockCallHeroAction", g_Config.boLockCallHeroAction);
            }
            g_Config.boLockCallHeroAction = Config.ReadBool("Setup", "PasswordLockCallHeroAction", g_Config.boLockCallHeroAction);
            if (Config.ReadInteger("Setup", "PasswordLockSendMsgAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockSendMsgAction", g_Config.boLockSendMsgAction);
            }
            g_Config.boLockSendMsgAction = Config.ReadBool("Setup", "PasswordLockSendMsgAction", g_Config.boLockSendMsgAction);
            if (Config.ReadInteger("Setup", "PasswordLockUserItemAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockUserItemAction", g_Config.boLockUserItemAction);
            }
            g_Config.boLockUserItemAction = Config.ReadBool("Setup", "PasswordLockUserItemAction", g_Config.boLockUserItemAction);
            if (Config.ReadInteger("Setup", "PasswordLockInObModeAction", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordLockInObModeAction", g_Config.boLockInObModeAction);
            }
            g_Config.boLockInObModeAction = Config.ReadBool("Setup", "PasswordLockInObModeAction", g_Config.boLockInObModeAction);
            if (Config.ReadInteger("Setup", "PasswordErrorKick", -1) < 0)
            {
                Config.WriteBool("Setup", "PasswordErrorKick", g_Config.boPasswordErrorKick);
            }
            g_Config.boPasswordErrorKick = Config.ReadBool("Setup", "PasswordErrorKick", g_Config.boPasswordErrorKick);
            if (Config.ReadInteger("Setup", "PasswordErrorCountLock", -1) < 0)
            {
                Config.WriteInteger("Setup", "PasswordErrorCountLock", g_Config.nPasswordErrorCountLock);
            }
            g_Config.nPasswordErrorCountLock = Config.ReadInteger("Setup", "PasswordErrorCountLock", g_Config.nPasswordErrorCountLock);
            if (Config.ReadInteger("Setup", "SoftVersionDate", -1) < 0)
            {
                Config.WriteInteger("Setup", "SoftVersionDate", g_Config.nSoftVersionDate);
            }
            g_Config.nSoftVersionDate = Config.ReadInteger("Setup", "SoftVersionDate", g_Config.nSoftVersionDate);
            nLoadInteger = Config.ReadInteger("Setup", "CanOldClientLogon", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "CanOldClientLogon", g_Config.boCanOldClientLogon);
            }
            else
            {
                g_Config.boCanOldClientLogon = nLoadInteger == 1;
            }
            if (Config.ReadInteger("Setup", "ConsoleShowUserCountTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "ConsoleShowUserCountTime", g_Config.dwConsoleShowUserCountTime);
            }
            g_Config.dwConsoleShowUserCountTime = Config.ReadInteger("Setup", "ConsoleShowUserCountTime", g_Config.dwConsoleShowUserCountTime);
            if (Config.ReadInteger("Setup", "ShowLineNoticeTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "ShowLineNoticeTime", g_Config.dwShowLineNoticeTime);
            }
            g_Config.dwShowLineNoticeTime = Config.ReadInteger("Setup", "ShowLineNoticeTime", g_Config.dwShowLineNoticeTime);
            if (Config.ReadInteger("Setup", "LineNoticeColor", -1) < 0)
            {
                Config.WriteInteger("Setup", "LineNoticeColor", g_Config.nLineNoticeColor);
            }
            g_Config.nLineNoticeColor = Config.ReadInteger("Setup", "LineNoticeColor", g_Config.nLineNoticeColor);
            if (Config.ReadInteger("Setup", "ItemSpeedTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "ItemSpeedTime", g_Config.ClientConf.btItemSpeed);
            }
            g_Config.ClientConf.btItemSpeed = Config.ReadInteger("Setup", "ItemSpeedTime", g_Config.ClientConf.btItemSpeed);
            if (Config.ReadInteger("Setup", "MaxHitMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MaxHitMsgCount", g_Config.nMaxHitMsgCount);
            }
            g_Config.nMaxHitMsgCount = Config.ReadInteger("Setup", "MaxHitMsgCount", g_Config.nMaxHitMsgCount);
            if (Config.ReadInteger("Setup", "MaxSpellMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MaxSpellMsgCount", g_Config.nMaxSpellMsgCount);
            }
            g_Config.nMaxSpellMsgCount = Config.ReadInteger("Setup", "MaxSpellMsgCount", g_Config.nMaxSpellMsgCount);
            if (Config.ReadInteger("Setup", "MaxRunMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MaxRunMsgCount", g_Config.nMaxRunMsgCount);
            }
            g_Config.nMaxRunMsgCount = Config.ReadInteger("Setup", "MaxRunMsgCount", g_Config.nMaxRunMsgCount);
            if (Config.ReadInteger("Setup", "MaxWalkMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MaxWalkMsgCount", g_Config.nMaxWalkMsgCount);
            }
            g_Config.nMaxWalkMsgCount = Config.ReadInteger("Setup", "MaxWalkMsgCount", g_Config.nMaxWalkMsgCount);
            if (Config.ReadInteger("Setup", "MaxTurnMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MaxTurnMsgCount", g_Config.nMaxTurnMsgCount);
            }
            g_Config.nMaxTurnMsgCount = Config.ReadInteger("Setup", "MaxTurnMsgCount", g_Config.nMaxTurnMsgCount);
            if (Config.ReadInteger("Setup", "MaxSitDonwMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MaxSitDonwMsgCount", g_Config.nMaxSitDonwMsgCount);
            }
            g_Config.nMaxSitDonwMsgCount = Config.ReadInteger("Setup", "MaxSitDonwMsgCount", g_Config.nMaxSitDonwMsgCount);
            if (Config.ReadInteger("Setup", "MaxDigUpMsgCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "MaxDigUpMsgCount", g_Config.nMaxDigUpMsgCount);
            }
            g_Config.nMaxDigUpMsgCount = Config.ReadInteger("Setup", "MaxDigUpMsgCount", g_Config.nMaxDigUpMsgCount);
            if (Config.ReadInteger("Setup", "SpellSendUpdateMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "SpellSendUpdateMsg", g_Config.boSpellSendUpdateMsg);
            }
            g_Config.boSpellSendUpdateMsg = Config.ReadBool("Setup", "SpellSendUpdateMsg", g_Config.boSpellSendUpdateMsg);
            if (Config.ReadInteger("Setup", "ActionSendActionMsg", -1) < 0)
            {
                Config.WriteBool("Setup", "ActionSendActionMsg", g_Config.boActionSendActionMsg);
            }
            g_Config.boActionSendActionMsg = Config.ReadBool("Setup", "ActionSendActionMsg", g_Config.boActionSendActionMsg);
            if (Config.ReadInteger("Setup", "OverSpeedKickCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "OverSpeedKickCount", g_Config.nOverSpeedKickCount);
            }
            g_Config.nOverSpeedKickCount = Config.ReadInteger("Setup", "OverSpeedKickCount", g_Config.nOverSpeedKickCount);
            if (Config.ReadInteger("Setup", "DropOverSpeed", -1) < 0)
            {
                Config.WriteInteger("Setup", "DropOverSpeed", g_Config.dwDropOverSpeed);
            }
            g_Config.dwDropOverSpeed = Config.ReadInteger("Setup", "DropOverSpeed", g_Config.dwDropOverSpeed);
            if (Config.ReadInteger("Setup", "KickOverSpeed", -1) < 0)
            {
                Config.WriteBool("Setup", "KickOverSpeed", g_Config.boKickOverSpeed);
            }
            g_Config.boKickOverSpeed = Config.ReadBool("Setup", "KickOverSpeed", g_Config.boKickOverSpeed);
            nLoadInteger = Config.ReadInteger("Setup", "SpeedControlMode", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "SpeedControlMode", g_Config.btSpeedControlMode);
            }
            else
            {
                g_Config.btSpeedControlMode = (byte)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "HitIntervalTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "HitIntervalTime", g_Config.dwHitIntervalTime);
            }
            g_Config.dwHitIntervalTime = Config.ReadInteger("Setup", "HitIntervalTime", g_Config.dwHitIntervalTime);
            if (Config.ReadInteger("Setup", "MagicHitIntervalTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "MagicHitIntervalTime", g_Config.dwMagicHitIntervalTime);
            }
            g_Config.dwMagicHitIntervalTime = Config.ReadInteger("Setup", "MagicHitIntervalTime", g_Config.dwMagicHitIntervalTime);
            if (Config.ReadInteger("Setup", "RunIntervalTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "RunIntervalTime", g_Config.dwRunIntervalTime);
            }
            g_Config.dwRunIntervalTime = Config.ReadInteger("Setup", "RunIntervalTime", g_Config.dwRunIntervalTime);
            if (Config.ReadInteger("Setup", "WalkIntervalTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "WalkIntervalTime", g_Config.dwWalkIntervalTime);
            }
            g_Config.dwWalkIntervalTime = Config.ReadInteger("Setup", "WalkIntervalTime", g_Config.dwWalkIntervalTime);
            if (Config.ReadInteger("Setup", "TurnIntervalTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "TurnIntervalTime", g_Config.dwTurnIntervalTime);
            }
            g_Config.dwTurnIntervalTime = Config.ReadInteger("Setup", "TurnIntervalTime", g_Config.dwTurnIntervalTime);
            nLoadInteger = Config.ReadInteger("Setup", "ControlActionInterval", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "ControlActionInterval", g_Config.boControlActionInterval);
            }
            else
            {
                g_Config.boControlActionInterval = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ControlWalkHit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "ControlWalkHit", g_Config.boControlWalkHit);
            }
            else
            {
                g_Config.boControlWalkHit = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ControlRunLongHit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "ControlRunLongHit", g_Config.boControlRunLongHit);
            }
            else
            {
                g_Config.boControlRunLongHit = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ControlRunHit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "ControlRunHit", g_Config.boControlRunHit);
            }
            else
            {
                g_Config.boControlRunHit = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ControlRunMagic", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "ControlRunMagic", g_Config.boControlRunMagic);
            }
            else
            {
                g_Config.boControlRunMagic = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ActionIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "ActionIntervalTime", g_Config.dwActionIntervalTime);
            }
            else
            {
                g_Config.dwActionIntervalTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "RunLongHitIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "RunLongHitIntervalTime", g_Config.dwRunLongHitIntervalTime);
            }
            else
            {
                g_Config.dwRunLongHitIntervalTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "RunHitIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "RunHitIntervalTime", g_Config.dwRunHitIntervalTime);
            }
            else
            {
                g_Config.dwRunHitIntervalTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WalkHitIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WalkHitIntervalTime", g_Config.dwWalkHitIntervalTime);
            }
            else
            {
                g_Config.dwWalkHitIntervalTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "RunMagicIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "RunMagicIntervalTime", g_Config.dwRunMagicIntervalTime);
            }
            else
            {
                g_Config.dwRunMagicIntervalTime = (uint)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "DisableStruck", -1) < 0)
            {
                Config.WriteBool("Setup", "DisableStruck", g_Config.boDisableStruck);
            }
            g_Config.boDisableStruck = Config.ReadBool("Setup", "DisableStruck", g_Config.boDisableStruck);
            if (Config.ReadInteger("Setup", "DisableSelfStruck", -1) < 0)
            {
                Config.WriteBool("Setup", "DisableSelfStruck", g_Config.boDisableSelfStruck);
            }
            g_Config.boDisableSelfStruck = Config.ReadBool("Setup", "DisableSelfStruck", g_Config.boDisableSelfStruck);
            if (Config.ReadInteger("Setup", "StruckTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "StruckTime", g_Config.dwStruckTime);
            }
            g_Config.dwStruckTime = Config.ReadInteger("Setup", "StruckTime", g_Config.dwStruckTime);
            nLoadInteger = Config.ReadInteger("Setup", "AddUserItemNewValue", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "AddUserItemNewValue", g_Config.boAddUserItemNewValue);
            }
            else
            {
                g_Config.boAddUserItemNewValue = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "TestSpeedMode", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "TestSpeedMode", g_Config.boTestSpeedMode);
            }
            else
            {
                g_Config.boTestSpeedMode = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WeaponMakeUnLuckRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WeaponMakeUnLuckRate", g_Config.nWeaponMakeUnLuckRate);
            }
            else
            {
                g_Config.nWeaponMakeUnLuckRate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WeaponMakeLuckPoint1", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WeaponMakeLuckPoint1", g_Config.nWeaponMakeLuckPoint1);
            }
            else
            {
                g_Config.nWeaponMakeLuckPoint1 = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WeaponMakeLuckPoint2", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WeaponMakeLuckPoint2", g_Config.nWeaponMakeLuckPoint2);
            }
            else
            {
                g_Config.nWeaponMakeLuckPoint2 = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WeaponMakeLuckPoint3", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WeaponMakeLuckPoint3", g_Config.nWeaponMakeLuckPoint3);
            }
            else
            {
                g_Config.nWeaponMakeLuckPoint3 = (ushort)(ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WeaponMakeLuckPoint2Rate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WeaponMakeLuckPoint2Rate", g_Config.nWeaponMakeLuckPoint2Rate);
            }
            else
            {
                g_Config.nWeaponMakeLuckPoint2Rate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WeaponMakeLuckPoint3Rate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WeaponMakeLuckPoint3Rate", g_Config.nWeaponMakeLuckPoint3Rate);
            }
            else
            {
                g_Config.nWeaponMakeLuckPoint3Rate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "CheckUserItemPlace", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "CheckUserItemPlace", g_Config.boCheckUserItemPlace);
            }
            else
            {
                g_Config.boCheckUserItemPlace = nLoadInteger == 1;
            }
            nLoadInteger = Config.ReadInteger("Setup", "LevelValueOfTaosHP", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "LevelValueOfTaosHP", g_Config.nLevelValueOfTaosHP);
            }
            else
            {
                g_Config.nLevelValueOfTaosHP = (ushort)nLoadInteger;
            }
            nLoadFloat = Config.ReadFloat("Setup", "LevelValueOfTaosHPRate", 0);
            if (nLoadFloat == 0)
            {
                Config.WriteFloat("Setup", "LevelValueOfTaosHPRate", g_Config.nLevelValueOfTaosHPRate);
            }
            else
            {
                g_Config.nLevelValueOfTaosHPRate = nLoadFloat;
            }
            nLoadInteger = Config.ReadInteger("Setup", "LevelValueOfTaosMP", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "LevelValueOfTaosMP", g_Config.nLevelValueOfTaosMP);
            }
            else
            {
                g_Config.nLevelValueOfTaosMP = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "LevelValueOfWizardHP", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "LevelValueOfWizardHP", g_Config.nLevelValueOfWizardHP);
            }
            else
            {
                g_Config.nLevelValueOfWizardHP = (ushort)nLoadInteger;
            }
            nLoadFloat = Config.ReadFloat("Setup", "LevelValueOfWizardHPRate", 0);
            if (nLoadFloat == 0)
            {
                Config.WriteFloat("Setup", "LevelValueOfWizardHPRate", g_Config.nLevelValueOfWizardHPRate);
            }
            else
            {
                g_Config.nLevelValueOfWizardHPRate = nLoadFloat;
            }
            nLoadInteger = Config.ReadInteger("Setup", "LevelValueOfWarrHP", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "LevelValueOfWarrHP", g_Config.nLevelValueOfWarrHP);
            }
            else
            {
                g_Config.nLevelValueOfWarrHP = (ushort)nLoadInteger;
            }
            nLoadFloat = Config.ReadFloat("Setup", "LevelValueOfWarrHPRate", 0);
            if (nLoadFloat == 0)
            {
                Config.WriteFloat("Setup", "LevelValueOfWarrHPRate", g_Config.nLevelValueOfWarrHPRate);
            }
            else
            {
                g_Config.nLevelValueOfWarrHPRate = nLoadFloat;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ProcessMonsterInterval", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "ProcessMonsterInterval", g_Config.nProcessMonsterInterval);
            }
            else
            {
                g_Config.nProcessMonsterInterval = (sbyte)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "StartCastleWarDays", -1) < 0)
            {
                Config.WriteInteger("Setup", "StartCastleWarDays", g_Config.nStartCastleWarDays);
            }
            g_Config.nStartCastleWarDays = Config.ReadInteger("Setup", "StartCastleWarDays", g_Config.nStartCastleWarDays);
            if (Config.ReadInteger("Setup", "StartCastlewarTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "StartCastlewarTime", g_Config.nStartCastlewarTime);
            }
            g_Config.nStartCastlewarTime = Config.ReadInteger("Setup", "StartCastlewarTime", g_Config.nStartCastlewarTime);
            if (Config.ReadInteger("Setup", "ShowCastleWarEndMsgTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "ShowCastleWarEndMsgTime", g_Config.dwShowCastleWarEndMsgTime);
            }
            g_Config.dwShowCastleWarEndMsgTime = Config.ReadInteger("Setup", "ShowCastleWarEndMsgTime", g_Config.dwShowCastleWarEndMsgTime);
            if (Config.ReadInteger("Setup", "CastleWarTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "CastleWarTime", g_Config.dwCastleWarTime);
            }
            g_Config.dwCastleWarTime = Config.ReadInteger("Setup", "CastleWarTime", g_Config.dwCastleWarTime);
            nLoadInteger = Config.ReadInteger("Setup", "GetCastleTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "GetCastleTime", g_Config.dwGetCastleTime);
            }
            else
            {
                g_Config.dwGetCastleTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "GuildWarTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "GuildWarTime", g_Config.dwGuildWarTime);
            }
            else
            {
                g_Config.dwGuildWarTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WinLotteryCount", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryCount", g_Config.nWinLotteryCount);
            }
            else
            {
                g_Config.nWinLotteryCount = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "NoWinLotteryCount", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "NoWinLotteryCount", g_Config.nNoWinLotteryCount);
            }
            else
            {
                g_Config.nNoWinLotteryCount = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WinLotteryLevel1", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryLevel1", g_Config.nWinLotteryLevel1);
            }
            else
            {
                g_Config.nWinLotteryLevel1 = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WinLotteryLevel2", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryLevel2", g_Config.nWinLotteryLevel2);
            }
            else
            {
                g_Config.nWinLotteryLevel2 = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WinLotteryLevel3", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryLevel3", g_Config.nWinLotteryLevel3);
            }
            else
            {
                g_Config.nWinLotteryLevel3 = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WinLotteryLevel4", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryLevel4", g_Config.nWinLotteryLevel4);
            }
            else
            {
                g_Config.nWinLotteryLevel4 = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WinLotteryLevel5", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryLevel5", g_Config.nWinLotteryLevel5);
            }
            else
            {
                g_Config.nWinLotteryLevel5 = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WinLotteryLevel6", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WinLotteryLevel6", g_Config.nWinLotteryLevel6);
            }
            else
            {
                g_Config.nWinLotteryLevel6 = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "DecUserGameGold", -1); // 每次扣多少元宝(元宝寄售)
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "DecUserGameGold", g_Config.nDecUserGameGold);
            }
            else
            {
                g_Config.nDecUserGameGold = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MakeWineTime", -1);// 酿普通酒等待时间
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MakeWineTime", g_Config.nMakeWineTime);
            }
            else
            {
                g_Config.nMakeWineTime = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MakeWineTime1", -1);// 酿药酒等待时间
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MakeWineTime1", g_Config.nMakeWineTime1);
            }
            else
            {
                g_Config.nMakeWineTime1 = nLoadInteger;
            }
            // 酿酒获得酒曲机率 20080621
            nLoadInteger = Config.ReadInteger("Setup", "MakeWineRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MakeWineRate", g_Config.nMakeWineRate);
            }
            else
            {
                g_Config.nMakeWineRate = (byte)nLoadInteger;
            }
            // 增加酒量进度的间隔时间 20080623
            nLoadInteger = Config.ReadInteger("Setup", "IncAlcoholTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "IncAlcoholTick", g_Config.nIncAlcoholTick);
            }
            else
            {
                g_Config.nIncAlcoholTick = nLoadInteger;
            }
            // 减少醉酒度的间隔时间 20080623
            nLoadInteger = Config.ReadInteger("Setup", "DesDrinkTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "DesDrinkTick", g_Config.nDesDrinkTick);
            }
            else
            {
                g_Config.nDesDrinkTick = nLoadInteger;
            }
            // 酒量上限初始值 20080623
            nLoadInteger = Config.ReadInteger("Setup", "MaxAlcoholValue", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MaxAlcoholValue", g_Config.nMaxAlcoholValue);
            }
            else
            {
                g_Config.nMaxAlcoholValue = (ushort)nLoadInteger;
            }
            // 升级后增加酒量上限值 20080623
            nLoadInteger = Config.ReadInteger("Setup", "IncAlcoholValue", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "IncAlcoholValue", g_Config.nIncAlcoholValue);
            }
            else
            {
                g_Config.nIncAlcoholValue = (ushort)nLoadInteger;
            }
            // 长时间不使用酒,减药力值 20080623
            nLoadInteger = Config.ReadInteger("Setup", "DesMedicineValue", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "DesMedicineValue", g_Config.nDesMedicineValue);
            }
            else
            {
                g_Config.nDesMedicineValue = (ushort)nLoadInteger;
            }
            // 减药力值时间间隔 20080624
            nLoadInteger = Config.ReadInteger("Setup", "DesMedicineTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "DesMedicineTick", g_Config.nDesMedicineTick);
            }
            else
            {
                g_Config.nDesMedicineTick = (UInt16)nLoadInteger;
            }
            // 站在泉眼上的累积时间(秒) 20080624
            nLoadInteger = Config.ReadInteger("Setup", "InFountainTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "InFountainTime", g_Config.nInFountainTime);
            }
            else
            {
                g_Config.nInFountainTime = (ushort)nLoadInteger;
            }
            // 行会酒泉蓄量少于时,不能领取 20080627
            nLoadInteger = Config.ReadInteger("Setup", "MinGuildFountain", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MinGuildFountain", g_Config.nMinGuildFountain);
            }
            else
            {
                g_Config.nMinGuildFountain = (ushort)nLoadInteger;
            }
            // 行会成员领取酒泉,蓄量减少 20080627
            nLoadInteger = Config.ReadInteger("Setup", "DecGuildFountain", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "DecGuildFountain", g_Config.nDecGuildFountain);
            }
            else
            {
                g_Config.nDecGuildFountain = (ushort)nLoadInteger;
            }
            // 天地结晶英雄分配比例 20090202
            nLoadInteger = Config.ReadInteger("Setup", "HeroCrystalExpRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "HeroCrystalExpRate", g_Config.nHeroCrystalExpRate);
            }
            else
            {
                g_Config.nHeroCrystalExpRate = (byte)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "PullPlayObject", -1) < 0)
            {
                Config.WriteBool("Setup", "PullPlayObject", g_Config.boPullPlayObject);
            }
            g_Config.boPullPlayObject = Config.ReadBool("Setup", "PullPlayObject", g_Config.boPullPlayObject);
            if (Config.ReadInteger("Setup", "GroupMbAttackPlayObject", -1) < 0)
            {
                Config.WriteBool("Setup", "GroupMbAttackPlayObject", g_Config.boGroupMbAttackPlayObject);
            }
            g_Config.boGroupMbAttackPlayObject = Config.ReadBool("Setup", "GroupMbAttackPlayObject", g_Config.boGroupMbAttackPlayObject);
            if (Config.ReadInteger("Setup", "DamageMP", -1) < 0)
            {
                Config.WriteBool("Setup", "DamageMP", g_Config.boPlayObjectReduceMP);
            }
            g_Config.boPlayObjectReduceMP = Config.ReadBool("Setup", "DamageMP", g_Config.boPlayObjectReduceMP);
            if (Config.ReadInteger("Setup", "GroupMbAttackSlave", -1) < 0)
            {
                Config.WriteBool("Setup", "GroupMbAttackSlave", g_Config.boGroupMbAttackSlave);
            }
            g_Config.boGroupMbAttackSlave = Config.ReadBool("Setup", "GroupMbAttackSlave", g_Config.boGroupMbAttackSlave);
            nLoadInteger = Config.ReadInteger("Setup", "BigStorageLimitCount", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "BigStorageLimitCount", g_Config.nBigStorageLimitCount);
            }
            else
            {
                g_Config.nBigStorageLimitCount = (ushort)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "DropGoldToPlayBag", -1) < 0)
            {
                Config.WriteBool("Setup", "DropGoldToPlayBag", g_Config.boDropGoldToPlayBag);
            }
            g_Config.boDropGoldToPlayBag = Config.ReadBool("Setup", "DropGoldToPlayBag", g_Config.boDropGoldToPlayBag);
            if (Config.ReadInteger("Setup", "ChangeUseItemNameByPlayName", -1) < 0)
            {
                Config.WriteBool("Setup", "ChangeUseItemNameByPlayName", g_Config.boChangeUseItemNameByPlayName);
            }
            g_Config.boChangeUseItemNameByPlayName = Config.ReadBool("Setup", "ChangeUseItemNameByPlayName", g_Config.boChangeUseItemNameByPlayName);
            if (Config.ReadString("Setup", "ChangeUseItemName", "") == "")
            {
                Config.WriteString("Setup", "ChangeUseItemName", g_Config.sChangeUseItemName);
            }
            g_Config.sChangeUseItemName = Config.ReadString("Setup", "ChangeUseItemName", g_Config.sChangeUseItemName);
            // 开天斩使用间隔
            nLoadInteger = Config.ReadInteger("Setup", "Magic43UseTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "Magic43UseTime", g_Config.nKill43UseTime);
            }
            else
            {
                g_Config.nKill43UseTime = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "MagicDedingUseTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagicDedingUseTime", g_Config.nDedingUseTime);
            }
            else
            {
                g_Config.nDedingUseTime = (byte)nLoadInteger;
            }
            // 无极真气使用间隔 20080603
            nLoadInteger = Config.ReadInteger("Setup", "AbilityUpTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "AbilityUpTick", g_Config.nAbilityUpTick);
            }
            else
            {
                g_Config.nAbilityUpTick = (byte)nLoadInteger;
            }
            // 无极真气使用时长模式 20081109
            if (Config.ReadInteger("Setup", "AbilityUpFixMode", -1) < 0)
            {
                Config.WriteBool("Setup", "AbilityUpFixMode", g_Config.boAbilityUpFixMode);
            }
            g_Config.boAbilityUpFixMode = Config.ReadBool("Setup", "AbilityUpFixMode", g_Config.boAbilityUpFixMode);
            // 无极真气使用固定时长 20081109
            nLoadInteger = Config.ReadInteger("Setup", "AbilityUpFixUseTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "AbilityUpFixUseTime", g_Config.nAbilityUpFixUseTime);
            }
            else
            {
                g_Config.nAbilityUpFixUseTime = (byte)nLoadInteger;
            }
            // 无极真气使用时长 20080603
            nLoadInteger = Config.ReadInteger("Setup", "AbilityUpUseTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "AbilityUpUseTime", g_Config.nAbilityUpUseTime);
            }
            else
            {
                g_Config.nAbilityUpUseTime = (byte)nLoadInteger;
            }
            // 先天元力失效酒量下限比例 20080626
            nLoadInteger = Config.ReadInteger("Setup", "MinDrinkValue67", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MinDrinkValue67", g_Config.nMinDrinkValue67);
            }
            else
            {
                g_Config.nMinDrinkValue67 = (byte)nLoadInteger;
            }
            // 酒气护体失效酒量下限比例 20080626
            nLoadInteger = Config.ReadInteger("Setup", "MinDrinkValue68", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MinDrinkValue68", g_Config.nMinDrinkValue68);
            }
            else
            {
                g_Config.nMinDrinkValue68 = (byte)nLoadInteger;
            }
            // 酒气护体使用间隔 20080625
            nLoadInteger = Config.ReadInteger("Setup", "HPUpTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "HPUpTick", g_Config.nHPUpTick);
            }
            else
            {
                g_Config.nHPUpTick = (byte)nLoadInteger;
            }
            // 酒气护体增加使用时长 20080625
            nLoadInteger = Config.ReadInteger("Setup", "HPUpUseTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "HPUpUseTime", g_Config.nHPUpUseTime);
            }
            else
            {
                g_Config.nHPUpUseTime = (byte)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "DedingAllowPK", -1) < 0)
            {
                Config.WriteBool("Setup", "DedingAllowPK", g_Config.boDedingAllowPK);
            }
            g_Config.boDedingAllowPK = Config.ReadBool("Setup", "DedingAllowPK", g_Config.boDedingAllowPK);
            // 分身术设置
            nLoadInteger = Config.ReadInteger("Setup", "MakeSelfTick", -1);
            // 分身使用时长 20080404
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MakeSelfTick", g_Config.nMakeSelfTick);
            }
            else
            {
                g_Config.nMakeSelfTick = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "CopyHumanTick", -1);
            // 召唤分身的间隔 20080204
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "CopyHumanTick", g_Config.nCopyHumanTick);
            }
            else
            {
                g_Config.nCopyHumanTick = nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "CopyHumanBagCount", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "CopyHumanBagCount", g_Config.nCopyHumanBagCount);
            }
            else
            {
                g_Config.nCopyHumanBagCount = nLoadInteger;
            }
            // 分身名字颜色 20080404
            nLoadInteger = Config.ReadInteger("Setup", "CopyHumNameColor", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "CopyHumNameColor", g_Config.nCopyHumNameColor);
            }
            else
            {
                g_Config.nCopyHumNameColor = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "AllowCopyHumanCount", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "AllowCopyHumanCount", g_Config.nAllowCopyHumanCount);
            }
            else
            {
                g_Config.nAllowCopyHumanCount = nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "AddMasterName", -1) < 0)
            {
                Config.WriteBool("Setup", "AddMasterName", g_Config.boAddMasterName);
            }
            g_Config.boAddMasterName = Config.ReadBool("Setup", "AddMasterName", g_Config.boAddMasterName);
            // if Config.ReadString('Setup', 'CopyHumName', '') = '' then
            // Config.WriteString('Setup', 'CopyHumName', g_Config.sCopyHumName);
            g_Config.sCopyHumName = Config.ReadString("Setup", "CopyHumName", g_Config.sCopyHumName);
            nLoadInteger = Config.ReadInteger("Setup", "CopyHumAddHPRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "CopyHumAddHPRate", g_Config.nCopyHumAddHPRate);
            }
            else
            {
                g_Config.nCopyHumAddHPRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "CopyHumAddMPRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "CopyHumAddMPRate", g_Config.nCopyHumAddMPRate);
            }
            else
            {
                g_Config.nCopyHumAddMPRate = (byte)nLoadInteger;
            }
            if (Config.ReadString("Setup", "CopyHumBagItems1", "") == "")
            {
                Config.WriteString("Setup", "CopyHumBagItems1", g_Config.sCopyHumBagItems1);
            }
            g_Config.sCopyHumBagItems1 = Config.ReadString("Setup", "CopyHumBagItems1", g_Config.sCopyHumBagItems1);
            if (Config.ReadString("Setup", "CopyHumBagItems2", "") == "")
            {
                Config.WriteString("Setup", "CopyHumBagItems2", g_Config.sCopyHumBagItems2);
            }
            g_Config.sCopyHumBagItems2 = Config.ReadString("Setup", "CopyHumBagItems1", g_Config.sCopyHumBagItems2);
            if (Config.ReadString("Setup", "CopyHumBagItems3", "") == "")
            {
                Config.WriteString("Setup", "CopyHumBagItems3", g_Config.sCopyHumBagItems3);
            }
            g_Config.sCopyHumBagItems3 = Config.ReadString("Setup", "CopyHumBagItems3", g_Config.sCopyHumBagItems3);
            if (Config.ReadInteger("Setup", "AllowGuardAttack", -1) < 0)
            {
                Config.WriteBool("Setup", "AllowGuardAttack", g_Config.boAllowGuardAttack);
            }
            g_Config.boAllowGuardAttack = Config.ReadBool("Setup", "AllowGuardAttack", g_Config.boAllowGuardAttack);
            nLoadInteger = Config.ReadInteger("Setup", "WarrorAttackTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WarrorAttackTime", g_Config.dwWarrorAttackTime);
            }
            else
            {
                g_Config.dwWarrorAttackTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "WizardAttackTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "WizardAttackTime", g_Config.dwWizardAttackTime);
            }
            else
            {
                g_Config.dwWizardAttackTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "TaoistAttackTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "TaoistAttackTime", g_Config.dwTaoistAttackTime);
            }
            else
            {
                g_Config.dwTaoistAttackTime = (uint)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "AllowReCallMobOtherHum", -1) < 0)
            {
                Config.WriteBool("Setup", "AllowReCallMobOtherHum", g_Config.boAllowReCallMobOtherHum);
            }
            g_Config.boAllowReCallMobOtherHum = Config.ReadBool("Setup", "AllowReCallMobOtherHum", g_Config.boAllowReCallMobOtherHum);
            if (Config.ReadInteger("Setup", "NeedLevelHighTarget", -1) < 0)
            {
                Config.WriteBool("Setup", "NeedLevelHighTarget", g_Config.boNeedLevelHighTarget);
            }
            g_Config.boNeedLevelHighTarget = Config.ReadBool("Setup", "NeedLevelHighTarget", g_Config.boNeedLevelHighTarget);
            // /////////////////数据读取和保存等待时间 //////////////////////////////////////
            nLoadInteger = Config.ReadInteger("Setup", "GetDBSockMsgTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "GetDBSockMsgTime", g_Config.dwGetDBSockMsgTime);
            }
            else
            {
                g_Config.dwGetDBSockMsgTime = (uint)nLoadInteger;
            }
            // /////////////////数据读取和保存等待时间 //////////////////////////////////////
            if (Config.ReadInteger("Setup", "PullCrossInSafeZone", -1) < 0)
            {
                Config.WriteBool("Setup", "PullCrossInSafeZone", g_Config.boPullCrossInSafeZone);
            }
            g_Config.boPullCrossInSafeZone = Config.ReadBool("Setup", "PullCrossInSafeZone", g_Config.boPullCrossInSafeZone);
            if (Config.ReadInteger("Exp", "HighLevelGroupFixExp", -1) < 0)
            {
                Config.WriteBool("Exp", "HighLevelGroupFixExp", g_Config.boHighLevelGroupFixExp);
            }
            g_Config.boHighLevelGroupFixExp = Config.ReadBool("Exp", "HighLevelGroupFixExp", g_Config.boHighLevelGroupFixExp);
            if (Config.ReadInteger("Setup", "StartMapEvent", -1) < 0)
            {
                Config.WriteBool("Setup", "StartMapEvent", g_Config.boStartMapEvent);
            }
            g_Config.boStartMapEvent = Config.ReadBool("Setup", "StartMapEvent", g_Config.boStartMapEvent);
            // 斗笠可带选项 20080417
            if (Config.ReadInteger("Setup", "IsUseZhuLi", -1) < 0)
            {
                Config.WriteInteger("Setup", "IsUseZhuLi", g_Config.nIsUseZhuLi);
            }
            g_Config.nIsUseZhuLi = (sbyte)Config.ReadInteger("Setup", "IsUseZhuLi", g_Config.nIsUseZhuLi);
            // 带上斗笠是否显示神秘人 20080424
            if (Config.ReadInteger("Setup", "UnKnowHum", -1) < 0)
            {
                Config.WriteBool("Setup", "UnKnowHum", g_Config.boUnKnowHum);
            }
            g_Config.boUnKnowHum = Config.ReadBool("Setup", "UnKnowHum", g_Config.boUnKnowHum);
            // 是否保存双倍经验时间 20080412
            if (Config.ReadInteger("Exp", "SaveExpRate", -1) < 0)
            {
                Config.WriteBool("Exp", "SaveExpRate", g_Config.boSaveExpRate);
            }
            g_Config.boSaveExpRate = Config.ReadBool("Exp", "SaveExpRate", g_Config.boSaveExpRate);
            nLoadInteger = Config.ReadInteger("Exp", "LimitExpLevel", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Exp", "LimitExpLevel", g_Config.nLimitExpLevel);
            }
            else
            {
                g_Config.nLimitExpLevel = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Exp", "LimitExpValue", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Exp", "LimitExpValue", g_Config.nLimitExpValue);
            }
            else
            {
                g_Config.nLimitExpValue = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "FireDelayTimeRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "FireDelayTimeRate", g_Config.nFireDelayTimeRate);
            }
            else
            {
                g_Config.nFireDelayTimeRate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "FirePowerRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "FirePowerRate", g_Config.nFirePowerRate);
            }
            else
            {
                g_Config.nFirePowerRate = (ushort)nLoadInteger;
            }
            if (Config.ReadInteger("Setup", "ChangeMapFireExtinguish", -1) < 0)
            {
                Config.WriteBool("Setup", "ChangeMapFireExtinguish", g_Config.boChangeMapFireExtinguish);
            }
            g_Config.boChangeMapFireExtinguish = Config.ReadBool("Setup", "ChangeMapFireExtinguish", g_Config.boChangeMapFireExtinguish);
            nLoadInteger = Config.ReadInteger("Setup", "DidingPowerRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "DidingPowerRate", g_Config.nDidingPowerRate);
            }
            else
            {
                g_Config.nDidingPowerRate = (ushort)nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            // 移行换位使用间隔 20080616
            nLoadInteger = Config.ReadInteger("Setup", "MagChangXYTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagChangXYTick", g_Config.dwMagChangXYTick);
            }
            else
            {
                g_Config.dwMagChangXYTick = (uint)nLoadInteger;
            }
            // 护体神盾相关设置参数 20080108
            nLoadInteger = Config.ReadInteger("Setup", "ProtectionDefenceTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "ProtectionDefenceTime", g_Config.nProtectionDefenceTime);
            }
            else
            {
                g_Config.nProtectionDefenceTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ProtectionTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "ProtectionTick", g_Config.dwProtectionTick);
            }
            else
            {
                g_Config.dwProtectionTick = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ProtectionRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "ProtectionRate", g_Config.nProtectionRate);
            }
            else
            {
                g_Config.nProtectionRate = (byte)nLoadInteger;
            }
            // 护体神盾生效机率 20080929
            nLoadInteger = Config.ReadInteger("Setup", "ProtectionOKRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "ProtectionOKRate", g_Config.nProtectionOKRate);
            }
            else
            {
                g_Config.nProtectionOKRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "ProtectionBadRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "ProtectionBadRate", g_Config.nProtectionBadRate);
            }
            else
            {
                g_Config.nProtectionBadRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("Setup", "RushkungBadProtection", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "RushkungBadProtection", g_Config.RushkungBadProtection);
            }
            else
            {
                g_Config.RushkungBadProtection = !(nLoadInteger == 0);
            }
            nLoadInteger = Config.ReadInteger("Setup", "ErgumBadProtection", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "ErgumBadProtection", g_Config.ErgumBadProtection);
            }
            else
            {
                g_Config.ErgumBadProtection = !(nLoadInteger == 0);
            }
            nLoadInteger = Config.ReadInteger("Setup", "FirehitBadProtection", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "FirehitBadProtection", g_Config.FirehitBadProtection);
            }
            else
            {
                g_Config.FirehitBadProtection = !(nLoadInteger == 0);
            }
            nLoadInteger = Config.ReadInteger("Setup", "TwnhitBadProtection", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "TwnhitBadProtection", g_Config.TwnhitBadProtection);
            }
            else
            {
                g_Config.TwnhitBadProtection = !(nLoadInteger == 0);
            }
            // 显示护体神盾效果 20080328
            nLoadInteger = Config.ReadInteger("Setup", "ShowProtectionEnv", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "ShowProtectionEnv", g_Config.boShowProtectionEnv);
            }
            else
            {
                g_Config.boShowProtectionEnv = !(nLoadInteger == 0);
            }
            // 自动使用神盾 20080328
            nLoadInteger = Config.ReadInteger("Setup", "AutoProtection", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "AutoProtection", g_Config.boAutoProtection);
            }
            else
            {
                g_Config.boAutoProtection = !(nLoadInteger == 0);
            }
            // 智能锁定 20080418
            nLoadInteger = Config.ReadInteger("Setup", "AutoCanHit", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "AutoCanHit", g_Config.boAutoCanHit);
            }
            else
            {
                g_Config.boAutoCanHit = !(nLoadInteger == 0);
            }
            // 宝宝是否飞到主人身边 20080713
            nLoadInteger = Config.ReadInteger("Setup", "SlaveMoveMaster", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("Setup", "SlaveMoveMaster", g_Config.boSlaveMoveMaster);
            }
            else
            {
                g_Config.boSlaveMoveMaster = !(nLoadInteger == 0);
            }
            // ------------------------------------------------------------------------------
            // 龙影剑法使用间隔 20080204
            nLoadInteger = Config.ReadInteger("Setup", "Magic42UseTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "Magic42UseTime", g_Config.nKill42UseTime);
            }
            else
            {
                g_Config.nKill42UseTime = (byte)nLoadInteger;
            }
            // 龙影剑法威力 20080213
            nLoadInteger = Config.ReadInteger("Setup", "AttackRate_42", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "AttackRate_42", g_Config.nAttackRate_42);
            }
            else
            {
                g_Config.nAttackRate_42 = (ushort)nLoadInteger;
            }
            // 龙影剑法范围 20080218
            nLoadInteger = Config.ReadInteger("Setup", "MagicAttackRage_42", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Setup", "MagicAttackRage_42", g_Config.nMagicAttackRage_42);
            }
            else
            {
                g_Config.nMagicAttackRage_42 = (byte)nLoadInteger;
            }
            // ------------------------------------------------------------------------------
            // 英雄尸体清理时间 20080418
            nLoadInteger = Config.ReadInteger("HeroSetup", "MakeGhostHeroTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "MakeGhostHeroTime", g_Config.nMakeGhostHeroTime);
            }
            else
            {
                g_Config.nMakeGhostHeroTime = (uint)nLoadInteger;
            }
            // 召唤英雄间隔 20071201 begin
            nLoadInteger = Config.ReadInteger("HeroSetup", "RecallHeroTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "RecallHeroTime", g_Config.nRecallHeroTime);
            }
            else
            {
                g_Config.nRecallHeroTime = (uint)nLoadInteger;
            }
            // 召唤英雄间隔 20071201 end
            // ------------------------------------------------------------------------------
            // 英雄HP为人物的倍数 20081219
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroHPRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroHPRate", g_Config.nHeroHPRate);
            }
            else
            {
                g_Config.nHeroHPRate = (ushort)nLoadInteger;
            }
            // 死亡减少忠诚度 20080110
            nLoadInteger = Config.ReadInteger("HeroSetup", "DeathDecLoyal", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DeathDecLoyal", g_Config.nDeathDecLoyal);
            }
            else
            {
                g_Config.nDeathDecLoyal = (ushort)nLoadInteger;
            }
            // PK值减少忠诚度 20080214
            nLoadInteger = Config.ReadInteger("HeroSetup", "PKDecLoyal", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "PKDecLoyal", g_Config.nPKDecLoyal);
            }
            else
            {
                g_Config.nPKDecLoyal = (ushort)nLoadInteger;
            }
            // 行会战增加忠诚度 20080214
            nLoadInteger = Config.ReadInteger("HeroSetup", "GuildIncLoyal", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "GuildIncLoyal", g_Config.nGuildIncLoyal);
            }
            else
            {
                g_Config.nGuildIncLoyal = (ushort)nLoadInteger;
            }
            // 人物等级排名上升增加忠诚度 20080214
            nLoadInteger = Config.ReadInteger("HeroSetup", "LevelOrderIncLoyal", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "LevelOrderIncLoyal", g_Config.nLevelOrderIncLoyal);
            }
            else
            {
                g_Config.nLevelOrderIncLoyal = (ushort)nLoadInteger;
            }
            // 人物等级排名下降减少忠诚度 20080214
            nLoadInteger = Config.ReadInteger("HeroSetup", "LevelOrderDecLoyal", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "LevelOrderDecLoyal", g_Config.nLevelOrderDecLoyal);
            }
            else
            {
                g_Config.nLevelOrderDecLoyal = (ushort)nLoadInteger;
            }
            // 获得经验->忠诚度 20080110
            nLoadInteger = Config.ReadInteger("HeroSetup", "WinExp", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "WinExp", g_Config.nWinExp);
            }
            else
            {
                g_Config.nWinExp = nLoadInteger;
            }
            // 经验加忠诚 20080110
            nLoadInteger = Config.ReadInteger("HeroSetup", "ExpAddLoyal", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "ExpAddLoyal", g_Config.nExpAddLoyal);
            }
            else
            {
                g_Config.nExpAddLoyal = (ushort)nLoadInteger;
            }
            // 四级触发 20080110
            nLoadInteger = Config.ReadInteger("HeroSetup", "GotoLV4", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "GotoLV4", g_Config.nGotoLV4);
            }
            else
            {
                g_Config.nGotoLV4 = (ushort)nLoadInteger;
            }
            // 四级技能杀伤力增加值 20080112
            nLoadInteger = Config.ReadInteger("HeroSetup", "PowerLV4", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "PowerLV4", g_Config.nPowerLV4);
            }
            else
            {
                g_Config.nPowerLV4 = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroWalkIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroWalkIntervalTime", g_Config.dwHeroWalkIntervalTime);
            }
            else
            {
                g_Config.dwHeroWalkIntervalTime = (uint)nLoadInteger;
            }
            // 英雄转向间隔 20080213
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroTurnIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroTurnIntervalTime", g_Config.dwHeroTurnIntervalTime);
            }
            else
            {
                g_Config.dwHeroTurnIntervalTime = (uint)nLoadInteger;
            }
            // 英雄魔法间隔 20080524
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroMagicHitIntervalTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroMagicHitIntervalTime", g_Config.dwHeroMagicHitIntervalTime);
            }
            else
            {
                g_Config.dwHeroMagicHitIntervalTime = (uint)nLoadInteger;
            }
            // 英雄施毒术使用模式 20080604
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkillMode", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("HeroSetup", "HeroSkillMode", g_Config.btHeroSkillMode);
            }
            else
            {
                g_Config.btHeroSkillMode = !(nLoadInteger == 0);
            }
            // 英雄无极真气使用模式 20080827
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkillMode50", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("HeroSetup", "HeroSkillMode50", g_Config.btHeroSkillMode50);
            }
            else
            {
                g_Config.btHeroSkillMode50 = !(nLoadInteger == 0);
            }
            // 英雄分身术模式 20081029
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkillMode46", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("HeroSetup", "HeroSkillMode46", g_Config.btHeroSkillMode46);
            }
            else
            {
                g_Config.btHeroSkillMode46 = !(nLoadInteger == 0);
            }
            // 英雄开天斩重击模式 20081221
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkillMode43", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("HeroSetup", "HeroSkillMode43", g_Config.btHeroSkillMode43);
            }
            else
            {
                g_Config.btHeroSkillMode43 = !(nLoadInteger == 0);
            }
            // 噬魂沼泽使用绿毒模式 20080911
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkillMode_63", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteBool("HeroSetup", "HeroSkillMode_63", g_Config.btHeroSkillMode_63);
            }
            else
            {
                g_Config.btHeroSkillMode_63 = !(nLoadInteger == 0);
            }
            // ------------------------------------------------------------------------------
            nLoadInteger = Config.ReadInteger("HeroSetup", "StartLevel", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "StartLevel", g_Config.nHeroStartLevel);
            }
            else
            {
                g_Config.nHeroStartLevel = (ushort)nLoadInteger;
            }
            // 卧龙英雄开始等级 20080514
            nLoadInteger = Config.ReadInteger("HeroSetup", "DrinkHeroStartLevel", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DrinkHeroStartLevel", g_Config.nDrinkHeroStartLevel);
            }
            else
            {
                g_Config.nDrinkHeroStartLevel = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "KillMonExpRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "KillMonExpRate", g_Config.nHeroKillMonExpRate);
            }
            else
            {
                g_Config.nHeroKillMonExpRate = (byte)nLoadInteger;
            }
            // 20080803 非杀怪分配经验比例
            nLoadInteger = Config.ReadInteger("HeroSetup", "NoKillMonExpRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "NoKillMonExpRate", g_Config.nHeroNoKillMonExpRate);
            }
            else
            {
                g_Config.nHeroNoKillMonExpRate = (byte)nLoadInteger;
            }
            for (I = g_Config.nHeroBagItemCount.GetLowerBound(0); I <= g_Config.nHeroBagItemCount.GetUpperBound(0); I++)
            {
                nLoadInteger = Config.ReadInteger("HeroSetup", "BagItemCount" + I, -1);
                if (nLoadInteger < 0)
                {
                    Config.WriteInteger("HeroSetup", "BagItemCount" + I, g_Config.nHeroBagItemCount[I]);
                }
                else
                {
                    g_Config.nHeroBagItemCount[I] = (ushort)nLoadInteger;
                }
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "WarrorAttackTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "WarrorAttackTime", g_Config.dwHeroWarrorAttackTime);
            }
            else
            {
                g_Config.dwHeroWarrorAttackTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "WizardAttackTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "WizardAttackTime", g_Config.dwHeroWizardAttackTime);
            }
            else
            {
                g_Config.dwHeroWizardAttackTime = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "TaoistAttackTime", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "TaoistAttackTime", g_Config.dwHeroTaoistAttackTime);
            }
            else
            {
                g_Config.dwHeroTaoistAttackTime = (uint)nLoadInteger;
            }
            if (Config.ReadInteger("HeroSetup", "KillByMonstDropUseItem", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "KillByMonstDropUseItem", g_Config.boHeroKillByMonstDropUseItem);
            }
            g_Config.boHeroKillByMonstDropUseItem = Config.ReadBool("HeroSetup", "KillByMonstDropUseItem", g_Config.boHeroKillByMonstDropUseItem);
            if (Config.ReadInteger("HeroSetup", "KillByHumanDropUseItem", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "KillByHumanDropUseItem", g_Config.boHeroKillByHumanDropUseItem);
            }
            g_Config.boHeroKillByHumanDropUseItem = Config.ReadBool("HeroSetup", "KillByHumanDropUseItem", g_Config.boHeroKillByHumanDropUseItem);
            if (Config.ReadInteger("HeroSetup", "DieScatterBag", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "DieScatterBag", g_Config.boHeroDieScatterBag);
            }
            g_Config.boHeroDieScatterBag = Config.ReadBool("HeroSetup", "DieScatterBag", g_Config.boHeroDieScatterBag);
            // 英雄无目标下自动开启护体神盾 20080715
            if (Config.ReadInteger("HeroSetup", "HeroAutoProtectionDefence", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "HeroAutoProtectionDefence", g_Config.boHeroAutoProtectionDefence);
            }
            g_Config.boHeroAutoProtectionDefence = Config.ReadBool("HeroSetup", "HeroAutoProtectionDefence", g_Config.boHeroAutoProtectionDefence);
            // 英雄无目标下可召唤宝宝 20080615
            if (Config.ReadInteger("HeroSetup", "HeroNoTargetCall", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "HeroNoTargetCall", g_Config.boHeroNoTargetCall);
            }
            g_Config.boHeroNoTargetCall = Config.ReadBool("HeroSetup", "HeroNoTargetCall", g_Config.boHeroNoTargetCall);
            // 英雄死亡掉经验 20080605
            if (Config.ReadInteger("HeroSetup", "HeroDieExp", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "HeroDieExp", g_Config.boHeroDieExp);
            }
            g_Config.boHeroDieExp = Config.ReadBool("HeroSetup", "HeroDieExp", g_Config.boHeroDieExp);
            // 英雄死亡掉经验比率 20080605
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroDieExpRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroDieExpRate", g_Config.nHeroDieExpRate);
            }
            else
            {
                g_Config.nHeroDieExpRate = (byte)nLoadInteger;
            }
            if (Config.ReadInteger("HeroSetup", "DieRedScatterBagAll", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "DieRedScatterBagAll", g_Config.boHeroDieRedScatterBagAll);
            }
            g_Config.boHeroDieRedScatterBagAll = Config.ReadBool("HeroSetup", "DieRedScatterBagAll", g_Config.boHeroDieRedScatterBagAll);
            nLoadInteger = Config.ReadInteger("HeroSetup", "DieDropUseItemRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DieDropUseItemRate", g_Config.nHeroDieDropUseItemRate);
            }
            else
            {
                g_Config.nHeroDieDropUseItemRate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "DieRedDropUseItemRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DieRedDropUseItemRate", g_Config.nHeroDieRedDropUseItemRate);
            }
            else
            {
                g_Config.nHeroDieRedDropUseItemRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "DieScatterBagRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DieScatterBagRate", g_Config.nHeroDieScatterBagRate);
            }
            else
            {
                g_Config.nHeroDieScatterBagRate = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAddHPRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAddHPRate", g_Config.nHeroAddHPRate);
            }
            else
            {
                g_Config.nHeroAddHPRate = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAddMPRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAddMPRate", g_Config.nHeroAddMPRate);
            }
            else
            {
                g_Config.nHeroAddMPRate = (byte)nLoadInteger;
            }
            // 英雄吃普通药速度 20080601
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAddHPMPTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAddHPMPTick", g_Config.nHeroAddHPMPTick);
            }
            else
            {
                g_Config.nHeroAddHPMPTick = (uint)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAddHPRate1", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAddHPRate1", g_Config.nHeroAddHPRate1);
            }
            else
            {
                g_Config.nHeroAddHPRate1 = (byte)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAddMPRate1", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAddMPRate1", g_Config.nHeroAddMPRate1);
            }
            else
            {
                g_Config.nHeroAddMPRate1 = (byte)nLoadInteger;
            }
            // 吃特殊药速度 20080910
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAddHPMPTick1", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAddHPMPTick1", g_Config.nHeroAddHPMPTick1);
            }
            else
            {
                g_Config.nHeroAddHPMPTick1 = (uint)nLoadInteger;
            }
            // ------------------------------------------
            nLoadInteger = Config.ReadInteger("HeroSetup", "MaxFirDragonPoint", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "MaxFirDragonPoint", g_Config.nMaxFirDragonPoint);
            }
            else
            {
                g_Config.nMaxFirDragonPoint = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "AddFirDragonPoint", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "AddFirDragonPoint", g_Config.nAddFirDragonPoint);
            }
            else
            {
                g_Config.nAddFirDragonPoint = (ushort)nLoadInteger;
            }
            nLoadInteger = Config.ReadInteger("HeroSetup", "DecFirDragonPoint", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DecFirDragonPoint", g_Config.nDecFirDragonPoint);
            }
            else
            {
                g_Config.nDecFirDragonPoint = (ushort)nLoadInteger;
            }
            // 加怒气时间间隔 20080606
            nLoadInteger = Config.ReadInteger("HeroSetup", "IncDragonPointTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "IncDragonPointTick", g_Config.nIncDragonPointTick);
            }
            else
            {
                g_Config.nIncDragonPointTick = (uint)nLoadInteger;
            }
            // 0级 英雄召唤分身HP的比率 20080907
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkill46MaxHP_0", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_0", g_Config.nHeroSkill46MaxHP_0);
            }
            else
            {
                g_Config.nHeroSkill46MaxHP_0 = (byte)nLoadInteger;
            }
            // 1级 英雄召唤分身HP的比率 20081217
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkill46MaxHP_1", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_1", g_Config.nHeroSkill46MaxHP_1);
            }
            else
            {
                g_Config.nHeroSkill46MaxHP_1 = (byte)nLoadInteger;
            }
            // 2级 英雄召唤分身HP的比率 20081217
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkill46MaxHP_2", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_2", g_Config.nHeroSkill46MaxHP_2);
            }
            else
            {
                g_Config.nHeroSkill46MaxHP_2 = (byte)nLoadInteger;
            }
            // 3级 英雄召唤分身HP的比率 20081217
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroSkill46MaxHP_3", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroSkill46MaxHP_3", g_Config.nHeroSkill46MaxHP_3);
            }
            else
            {
                g_Config.nHeroSkill46MaxHP_3 = (byte)nLoadInteger;
            }
            // 英雄分身延长使用时间 20081217
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroMakeSelfTick", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroMakeSelfTick", g_Config.nHeroMakeSelfTick);
            }
            else
            {
                g_Config.nHeroMakeSelfTick = (ushort)nLoadInteger;
            }
            // 饮酒减少合击伤害 20080626
            nLoadInteger = Config.ReadInteger("HeroSetup", "DecDragonHitPoint", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DecDragonHitPoint", g_Config.nDecDragonHitPoint);
            }
            else
            {
                g_Config.nDecDragonHitPoint = (byte)nLoadInteger;
            }
            // 合击对人物的伤害比例 20080803
            nLoadInteger = Config.ReadInteger("HeroSetup", "DecDragonRate", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "DecDragonRate", g_Config.nDecDragonRate);
            }
            else
            {
                g_Config.nDecDragonRate = (byte)nLoadInteger;
            }
            // 英雄名字颜色 20080315
            nLoadInteger = Config.ReadInteger("HeroSetup", "nHeroNameColor", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "nHeroNameColor", g_Config.nHeroNameColor);
            }
            else
            {
                g_Config.nHeroNameColor = (byte)nLoadInteger;
            }
            g_Config.sHeroName = Config.ReadString("HeroSetup", "sHeroName", g_Config.sHeroName);
            // 英雄名后缀  20080315
            if (Config.ReadString("HeroSetup", "sHeroNameSuffix", "") == "")
            {
                Config.WriteString("HeroSetup", "sHeroNameSuffix", g_Config.sHeroNameSuffix);
            }
            g_Config.sHeroNameSuffix = Config.ReadString("HeroSetup", "sHeroNameSuffix", g_Config.sHeroNameSuffix);
            // 是否显示后缀  20080315
            if (Config.ReadInteger("HeroSetup", "boNameSuffix", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "boNameSuffix", g_Config.boNameSuffix);
            }
            g_Config.boNameSuffix = Config.ReadBool("HeroSetup", "boNameSuffix", g_Config.boNameSuffix);
            // 禁止安全区守护 20080603
            if (Config.ReadInteger("HeroSetup", "boNoSafeProtect", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "boNoSafeProtect", g_Config.boNoSafeProtect);
            }
            g_Config.boNoSafeProtect = Config.ReadBool("HeroSetup", "boNoSafeProtect", g_Config.boNoSafeProtect);
            // 道法22前是否物理攻击 20081218
            if (Config.ReadInteger("HeroSetup", "boHeroAttackTarget", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "boHeroAttackTarget", g_Config.boHeroAttackTarget);
            }
            g_Config.boHeroAttackTarget = Config.ReadBool("HeroSetup", "boHeroAttackTarget", g_Config.boHeroAttackTarget);
            // 道22后是否物理攻击 20090108
            if (Config.ReadInteger("HeroSetup", "boHeroAttackTao", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "boHeroAttackTao", g_Config.boHeroAttackTao);
            }
            g_Config.boHeroAttackTao = Config.ReadBool("HeroSetup", "boHeroAttackTao", g_Config.boHeroAttackTao);
            // 英雄休息不跟随主人切换地图 20081209
            if (Config.ReadInteger("HeroSetup", "boRestNoFollow", -1) < 0)
            {
                Config.WriteBool("HeroSetup", "boRestNoFollow", g_Config.boRestNoFollow);
            }
            g_Config.boRestNoFollow = Config.ReadBool("HeroSetup", "boRestNoFollow", g_Config.boRestNoFollow);
            // ------------------------------------------------------------------------------
            // 破魂斩威力 20080131
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAttackRate_60", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRate_60", g_Config.nHeroAttackRate_60);
            }
            else
            {
                g_Config.nHeroAttackRate_60 = (ushort)nLoadInteger;
            }
            // 破魂斩 攻击范围 20080406
            if (Config.ReadInteger("HeroSetup", "HeroAttackRange_60", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRange_60", g_Config.nHeroAttackRange_60);
            }
            g_Config.nHeroAttackRange_60 = Config.ReadInteger("HeroSetup", "HeroAttackRange_60", g_Config.nHeroAttackRange_60);
            // 劈星斩威力 20080131
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAttackRate_61", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRate_61", g_Config.nHeroAttackRate_61);
            }
            else
            {
                g_Config.nHeroAttackRate_61 = (ushort)nLoadInteger;
            }
            // 雷霆一击威力 20080131
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAttackRate_62", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRate_62", g_Config.nHeroAttackRate_62);
            }
            else
            {
                g_Config.nHeroAttackRate_62 = (ushort)nLoadInteger;
            }
            // 噬魂沼泽威力 20080131
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAttackRate_63", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRate_63", g_Config.nHeroAttackRate_63);
            }
            else
            {
                g_Config.nHeroAttackRate_63 = (ushort)nLoadInteger;
            }
            // 噬魂沼泽 攻击范围 20080131
            if (Config.ReadInteger("HeroSetup", "HeroAttackRange_63", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRange_63", g_Config.nHeroAttackRange_63);
            }
            g_Config.nHeroAttackRange_63 = Config.ReadInteger("HeroSetup", "HeroAttackRange_63", g_Config.nHeroAttackRange_63);
            // 末日审判威力 20080131
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAttackRate_64", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRate_64", g_Config.nHeroAttackRate_64);
            }
            else
            {
                g_Config.nHeroAttackRate_64 = (ushort)nLoadInteger;
            }
            // 火龙气焰威力 20080131
            nLoadInteger = Config.ReadInteger("HeroSetup", "HeroAttackRate_65", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRate_65", g_Config.nHeroAttackRate_65);
            }
            else
            {
                g_Config.nHeroAttackRate_65 = (ushort)nLoadInteger;
            }
            // 末日审判  攻击范围 20081216
            if (Config.ReadInteger("HeroSetup", "HeroAttackRange_64", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRange_64", g_Config.nHeroAttackRange_64);
            }
            g_Config.nHeroAttackRange_64 = Config.ReadInteger("HeroSetup", "HeroAttackRange_64", g_Config.nHeroAttackRange_64);
            // 火龙气焰 攻击范围 20080131
            if (Config.ReadInteger("HeroSetup", "HeroAttackRange_65", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "HeroAttackRange_65", g_Config.nHeroAttackRange_65);
            }
            g_Config.nHeroAttackRange_65 = Config.ReadInteger("HeroSetup", "HeroAttackRange_65", g_Config.nHeroAttackRange_65);
            // ------------------------------------------------------------------------------
            if (Config.ReadString("HeroNames", "ClothsMan", "") == "")
            {
                Config.WriteString("HeroNames", "ClothsMan", g_Config.sHeroClothsMan);
            }
            g_Config.sHeroClothsMan = Config.ReadString("HeroNames", "ClothsMan", g_Config.sHeroClothsMan);
            if (Config.ReadString("HeroNames", "ClothsWoman", "") == "")
            {
                Config.WriteString("HeroNames", "ClothsWoman", g_Config.sClothsWoman);
            }
            g_Config.sHeroClothsWoman = Config.ReadString("HeroNames", "ClothsWoman", g_Config.sHeroClothsWoman);
            if (Config.ReadString("HeroNames", "WoodenSword", "") == "")
            {
                Config.WriteString("HeroNames", "WoodenSword", g_Config.sHeroWoodenSword);
            }
            g_Config.sHeroWoodenSword = Config.ReadString("HeroNames", "WoodenSword", g_Config.sHeroWoodenSword);
            if (Config.ReadString("HeroNames", "BasicDrug", "") == "")
            {
                Config.WriteString("HeroNames", "BasicDrug", g_Config.sBasicDrug);
            }
            g_Config.sHeroBasicDrug = Config.ReadString("HeroNames", "BasicDrug", g_Config.sHeroBasicDrug);
            // ------------------------------------------------------------------------------
            if (Config.ReadInteger("Shop", "ShopBuyGameGird", -1) < 0)
            {
                Config.WriteBool("Shop", "ShopBuyGameGird", g_Config.g_boGameGird);
            }
            else
            {
                g_Config.g_boGameGird = Config.ReadBool("Shop", "ShopBuyGameGird", g_Config.g_boGameGird);
            }
            nLoadInteger = Config.ReadInteger("Shop", "GameGold", -1);
            if (nLoadInteger < 0)
            {
                Config.WriteInteger("Shop", "GameGold", g_Config.g_nGameGold);
            }
            else
            {
                g_Config.g_nGameGold = nLoadInteger;
            }
            // ***********        连击配置文件加载处       **************//
            if (Config.ReadInteger("Setup", "PulsePointNGLevel0", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel0", g_Config.PulsePointNGLevel0);
            }
            g_Config.PulsePointNGLevel0 = Config.ReadInteger("Setup", "PulsePointNGLevel0", g_Config.PulsePointNGLevel0);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel1", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel1", g_Config.PulsePointNGLevel1);
            }
            g_Config.PulsePointNGLevel1 = Config.ReadInteger("Setup", "PulsePointNGLevel1", g_Config.PulsePointNGLevel1);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel2", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel2", g_Config.PulsePointNGLevel2);
            }
            g_Config.PulsePointNGLevel2 = Config.ReadInteger("Setup", "PulsePointNGLevel2", g_Config.PulsePointNGLevel2);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel3", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel3", g_Config.PulsePointNGLevel3);
            }
            g_Config.PulsePointNGLevel3 = Config.ReadInteger("Setup", "PulsePointNGLevel3", g_Config.PulsePointNGLevel3);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel4", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel4", g_Config.PulsePointNGLevel4);
            }
            g_Config.PulsePointNGLevel4 = Config.ReadInteger("Setup", "PulsePointNGLevel4", g_Config.PulsePointNGLevel4);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel5", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel5", g_Config.PulsePointNGLevel5);
            }
            g_Config.PulsePointNGLevel5 = Config.ReadInteger("Setup", "PulsePointNGLevel5", g_Config.PulsePointNGLevel5);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel6", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel6", g_Config.PulsePointNGLevel6);
            }
            g_Config.PulsePointNGLevel6 = Config.ReadInteger("Setup", "PulsePointNGLevel6", g_Config.PulsePointNGLevel6);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel7", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel7", g_Config.PulsePointNGLevel7);
            }
            g_Config.PulsePointNGLevel7 = Config.ReadInteger("Setup", "PulsePointNGLevel7", g_Config.PulsePointNGLevel7);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel8", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel8", g_Config.PulsePointNGLevel8);
            }
            g_Config.PulsePointNGLevel8 = Config.ReadInteger("Setup", "PulsePointNGLevel8", g_Config.PulsePointNGLevel8);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel9", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel9", g_Config.PulsePointNGLevel9);
            }
            g_Config.PulsePointNGLevel9 = Config.ReadInteger("Setup", "PulsePointNGLevel9", g_Config.PulsePointNGLevel9);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel10", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel10", g_Config.PulsePointNGLevel10);
            }
            g_Config.PulsePointNGLevel10 = Config.ReadInteger("Setup", "PulsePointNGLevel10", g_Config.PulsePointNGLevel10);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel11", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel11", g_Config.PulsePointNGLevel11);
            }
            g_Config.PulsePointNGLevel11 = Config.ReadInteger("Setup", "PulsePointNGLevel11", g_Config.PulsePointNGLevel11);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel12", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel12", g_Config.PulsePointNGLevel12);
            }
            g_Config.PulsePointNGLevel12 = Config.ReadInteger("Setup", "PulsePointNGLevel12", g_Config.PulsePointNGLevel12);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel13", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel13", g_Config.PulsePointNGLevel13);
            }
            g_Config.PulsePointNGLevel13 = Config.ReadInteger("Setup", "PulsePointNGLevel13", g_Config.PulsePointNGLevel13);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel14", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel14", g_Config.PulsePointNGLevel14);
            }
            g_Config.PulsePointNGLevel14 = Config.ReadInteger("Setup", "PulsePointNGLevel14", g_Config.PulsePointNGLevel14);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel15", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel15", g_Config.PulsePointNGLevel15);
            }
            g_Config.PulsePointNGLevel15 = Config.ReadInteger("Setup", "PulsePointNGLevel15", g_Config.PulsePointNGLevel15);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel16", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel16", g_Config.PulsePointNGLevel16);
            }
            g_Config.PulsePointNGLevel16 = Config.ReadInteger("Setup", "PulsePointNGLevel16", g_Config.PulsePointNGLevel16);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel17", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel17", g_Config.PulsePointNGLevel17);
            }
            g_Config.PulsePointNGLevel17 = Config.ReadInteger("Setup", "PulsePointNGLevel17", g_Config.PulsePointNGLevel17);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel18", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel18", g_Config.PulsePointNGLevel18);
            }
            g_Config.PulsePointNGLevel18 = Config.ReadInteger("Setup", "PulsePointNGLevel18", g_Config.PulsePointNGLevel18);
            if (Config.ReadInteger("Setup", "PulsePointNGLevel19", -1) < 0)
            {
                Config.WriteInteger("Setup", "PulsePointNGLevel19", g_Config.PulsePointNGLevel19);
            }
            g_Config.PulsePointNGLevel19 = Config.ReadInteger("Setup", "PulsePointNGLevel19", g_Config.PulsePointNGLevel19);
            if (Config.ReadInteger("Setup", "BatterSkillFireRange_82", -1) < 0)
            {
                Config.WriteInteger("Setup", "BatterSkillFireRange_82", g_Config.BatterSkillFireRange_82);
            }
            g_Config.BatterSkillFireRange_82 = Config.ReadInteger("Setup", "BatterSkillFireRange_82", g_Config.BatterSkillFireRange_82);
            if (Config.ReadInteger("Setup", "BatterSkillFireRange_85", -1) < 0)
            {
                Config.WriteInteger("Setup", "BatterSkillFireRange_85", g_Config.BatterSkillFireRange_85);
            }
            g_Config.BatterSkillFireRange_85 = Config.ReadInteger("Setup", "BatterSkillFireRange_85", g_Config.BatterSkillFireRange_85);
            if (Config.ReadInteger("Setup", "BatterSkillFireRange_86", -1) < 0)
            {
                Config.WriteInteger("Setup", "BatterSkillFireRange_86", g_Config.BatterSkillFireRange_86);
            }
            g_Config.BatterSkillFireRange_86 = Config.ReadInteger("Setup", "BatterSkillFireRange_86", g_Config.BatterSkillFireRange_86);
            if (Config.ReadInteger("Setup", "BatterSkillFireRange_87", -1) < 0)
            {
                Config.WriteInteger("Setup", "BatterSkillFireRange_87", g_Config.BatterSkillFireRange_87);
            }
            g_Config.BatterSkillFireRange_87 = Config.ReadInteger("Setup", "BatterSkillFireRange_87", g_Config.BatterSkillFireRange_87);
            if (Config.ReadInteger("Setup", "BatterSkillPoinson_86", -1) < 0)
            {
                Config.WriteInteger("Setup", "BatterSkillPoinson_86", g_Config.BatterSkillPoinson_86);
            }
            g_Config.BatterSkillPoinson_86 = Config.ReadInteger("Setup", "BatterSkillPoinson_86", g_Config.BatterSkillPoinson_86);
            if (Config.ReadInteger("Setup", "BatterSkillPoinson_87", -1) < 0)
            {
                Config.WriteInteger("Setup", "BatterSkillPoinson_87", g_Config.BatterSkillPoinson_87);
            }
            g_Config.BatterSkillPoinson_87 = Config.ReadInteger("Setup", "BatterSkillPoinson_87", g_Config.BatterSkillPoinson_87);
            if (Config.ReadInteger("Setup", "StormsHitRate1", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitRate1", g_Config.StormsHitRate1);
            }
            g_Config.StormsHitRate1 = Config.ReadInteger("Setup", "StormsHitRate1", g_Config.StormsHitRate1);
            if (Config.ReadInteger("Setup", "StormsHitRate2", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitRate2", g_Config.StormsHitRate2);
            }
            g_Config.StormsHitRate2 = Config.ReadInteger("Setup", "StormsHitRate2", g_Config.StormsHitRate2);
            if (Config.ReadInteger("Setup", "StormsHitRate3", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitRate3", g_Config.StormsHitRate3);
            }
            g_Config.StormsHitRate3 = Config.ReadInteger("Setup", "StormsHitRate3", g_Config.StormsHitRate3);
            if (Config.ReadInteger("Setup", "StormsHitRate4", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitRate4", g_Config.StormsHitRate4);
            }
            g_Config.StormsHitRate4 = Config.ReadInteger("Setup", "StormsHitRate4", g_Config.StormsHitRate4);
            if (Config.ReadInteger("Setup", "StormsHitRate5", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitRate5", g_Config.StormsHitRate5);
            }
            g_Config.StormsHitRate5 = Config.ReadInteger("Setup", "StormsHitRate5", g_Config.StormsHitRate5);
            if (Config.ReadInteger("Setup", "StormsHitAppearRate0", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitAppearRate0", g_Config.StormsHitAppearRate0);
            }
            g_Config.StormsHitAppearRate0 = Config.ReadInteger("Setup", "StormsHitAppearRate0", g_Config.StormsHitAppearRate0);
            if (Config.ReadInteger("Setup", "StormsHitAppearRate1", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitAppearRate1", g_Config.StormsHitAppearRate1);
            }
            g_Config.StormsHitAppearRate1 = Config.ReadInteger("Setup", "StormsHitAppearRate1", g_Config.StormsHitAppearRate1);
            if (Config.ReadInteger("Setup", "StormsHitAppearRate2", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitAppearRate2", g_Config.StormsHitAppearRate2);
            }
            g_Config.StormsHitAppearRate2 = Config.ReadInteger("Setup", "StormsHitAppearRate2", g_Config.StormsHitAppearRate2);
            if (Config.ReadInteger("Setup", "StormsHitAppearRate3", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitAppearRate3", g_Config.StormsHitAppearRate3);
            }
            g_Config.StormsHitAppearRate3 = Config.ReadInteger("Setup", "StormsHitAppearRate3", g_Config.StormsHitAppearRate3);
            if (Config.ReadInteger("Setup", "StormsHitAppearRate4", -1) < 0)
            {
                Config.WriteInteger("Setup", "StormsHitAppearRate4", g_Config.StormsHitAppearRate4);
            }
            g_Config.StormsHitAppearRate4 = Config.ReadInteger("Setup", "StormsHitAppearRate4", g_Config.StormsHitAppearRate4);
            if (Config.ReadInteger("Setup", "UseBatterTick", -1) < 0)
            {
                Config.WriteInteger("Setup", "UseBatterTick", g_Config.UseBatterTick);
            }
            g_Config.UseBatterTick = Config.ReadInteger("Setup", "UseBatterTick", g_Config.UseBatterTick);
            if (Config.ReadInteger("Setup", "Magic69UseTime", -1) < 0)
            {
                Config.WriteInteger("Setup", "Magic69UseTime", g_Config.Magic69UseTime);
            }
            g_Config.Magic69UseTime = Config.ReadInteger("Setup", "Magic69UseTime", g_Config.Magic69UseTime);
            // -------------------英雄其他设置 包括双英雄设置--------------//
            if (Config.ReadInteger("HeroSetup", "Strength1DecGold", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength1DecGold", g_Config.Strength1DecGold);
            }
            g_Config.Strength1DecGold = Config.ReadInteger("HeroSetup", "Strength1DecGold", g_Config.Strength1DecGold);
            if (Config.ReadInteger("HeroSetup", "Strength1DecGameGird", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength1DecGameGird", g_Config.Strength1DecGameGird);
            }
            g_Config.Strength1DecGameGird = Config.ReadInteger("HeroSetup", "Strength1DecGameGird", g_Config.Strength1DecGameGird);
            if (Config.ReadInteger("HeroSetup", "Strength1Exp", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength1Exp", g_Config.Strength1Exp);
            }
            g_Config.Strength1Exp = Config.ReadInteger("HeroSetup", "Strength1Exp", g_Config.Strength1Exp);
            if (Config.ReadInteger("HeroSetup", "Strength2DecGold", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength2DecGold", g_Config.Strength2DecGold);
            }
            g_Config.Strength2DecGold = Config.ReadInteger("HeroSetup", "Strength2DecGold", g_Config.Strength2DecGold);
            if (Config.ReadInteger("HeroSetup", "Strength2DecGameGird", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength2DecGameGird", g_Config.Strength2DecGameGird);
            }
            g_Config.Strength2DecGameGird = Config.ReadInteger("HeroSetup", "Strength2DecGameGird", g_Config.Strength2DecGameGird);
            if (Config.ReadInteger("HeroSetup", "Strength2Exp", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength2Exp", g_Config.Strength2Exp);
            }
            g_Config.Strength2Exp = Config.ReadInteger("HeroSetup", "Strength2Exp", g_Config.Strength2Exp);
            if (Config.ReadInteger("HeroSetup", "Strength3DecGold", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength3DecGold", g_Config.Strength3DecGold);
            }
            g_Config.Strength3DecGold = Config.ReadInteger("HeroSetup", "Strength3DecGold", g_Config.Strength3DecGold);
            if (Config.ReadInteger("HeroSetup", "Strength3DecGameGird", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength3DecGameGird", g_Config.Strength3DecGameGird);
            }
            g_Config.Strength3DecGameGird = Config.ReadInteger("HeroSetup", "Strength3DecGameGird", g_Config.Strength3DecGameGird);
            if (Config.ReadInteger("HeroSetup", "Strength3Exp", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "Strength3Exp", g_Config.Strength3Exp);
            }
            g_Config.Strength3Exp = Config.ReadInteger("HeroSetup", "Strength3Exp", g_Config.Strength3Exp);
            if (Config.ReadInteger("HeroSetup", "RecallDeputyHeroTime", -1) < 0)
            {
                Config.WriteInteger("HeroSetup", "RecallDeputyHeroTime", g_Config.RecallDeputyHeroTime);
            }
            g_Config.RecallDeputyHeroTime = Config.ReadInteger("HeroSetup", "RecallDeputyHeroTime", g_Config.RecallDeputyHeroTime);// 召唤圣兽相关
            if (Config.ReadString("Setup", "Sacred", "") == "")
            {
                Config.WriteString("Setup", "Sacred", g_Config.SacRed);
            }
            g_Config.SacRed = Config.ReadString("Setup", "Sacred", g_Config.SacRed);
            if (Config.ReadInteger("Setup", "SacredCount", -1) < 0)
            {
                Config.WriteInteger("Setup", "SacredCount", g_Config.SacredCount);
            }
            g_Config.SacredCount = Config.ReadInteger("Setup", "SacredCount", g_Config.SacredCount);
        }

        /// <summary>
        /// 加载游戏变量配置
        /// </summary>
        internal static void LoadVarGlobal()
        {
            int nLoadInteger = 0;
            string sLoadString = string.Empty;
            for (int i = g_Config.GlobalVal.GetLowerBound(0); i <= g_Config.GlobalVal.GetUpperBound(0); i++)
            {
                nLoadInteger = GlobalConf.ReadInteger("Integer", "GlobalVal" + i, -1);
                if (nLoadInteger < 0)
                {
                    GlobalConf.WriteInteger("Integer", "GlobalVal" + i, g_Config.GlobalVal[i]);
                }
                else
                {
                    g_Config.GlobalVal[i] = nLoadInteger;
                }
            }
            for (int i = g_Config.GlobalAVal.GetLowerBound(0); i <= g_Config.GlobalAVal.GetUpperBound(0); i++)
            {
                sLoadString = GlobalConf.ReadString("String", "GlobalStrVal" + i, "");
                if (sLoadString == "")
                {
                    GlobalConf.WriteString("String", "GlobalStrVal" + i, "");
                }
                g_Config.GlobalAVal[i] = sLoadString;
            }
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="c256"></param>
        /// <returns></returns>
        public static Color GetRGB(byte c256)
        {
            return Color.FromArgb(ColorTable[c256].rgbRed, ColorTable[c256].rgbGreen, ColorTable[c256].rgbBlue);
        }

        /// <summary>
        /// 查询IP地址
        /// </summary>
        /// <param name="sIPaddr"></param>
        /// <returns></returns>
        public static string GetIPLocal(string sIPaddr)
        {
            string result = string.Empty;
            try
            {
                string sQqwryPath = Environment.CurrentDirectory + @"\qqwry.dat";
                if (File.Exists(sQqwryPath))
                {
                    IPScaner objIPScaner = new IPScaner();
                    objIPScaner.DataPath = sQqwryPath;
                    objIPScaner.IP = sIPaddr;
                    result = objIPScaner.IPLocation() + objIPScaner.ErrMsg;
                }
                else
                {
                    result = "请下载纯真IP数据库qqwry.dat文件放入M2目录下!";
                }
                return result;
            }
            catch
            {
                result = "未知！！！";
            }
            return result;
        }

        // sIPaddr 为当前IP
        // dIPaddr 为要比较的IP
        // * 号为通配符
        public static bool CompareIPaddr(string sIPaddr, string dIPaddr)
        {
            bool result;
            int nPos;
            result = false;
            if ((sIPaddr == "") || (dIPaddr == ""))
            {
                return result;
            }
            if ((dIPaddr[0] == '*'))
            {
                result = true;
                return result;
            }
            nPos = dIPaddr.IndexOf("*");
            if (nPos > 0)
            {
                result = HUtil32.CompareLStr(sIPaddr, dIPaddr, nPos - 1);
            }
            else
            {
                result = (sIPaddr).ToLower().CompareTo((dIPaddr).ToLower()) == 0;
            }
            return result;
        }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void Init()
        {
            Config = new IniFile(sConfigFileName);
            CommandConf = new IniFile(sCommandFileName);
            StringConf = new IniFile(sStringFileName);
            GlobalConf = new IniFile(sGlobalFileName);
            for (int i = 0; i < 256; i++)
            {
                ColorTable[i].rgbRed = ColorHelper.ColorArray[i * 4 + 2];
                ColorTable[i].rgbGreen = ColorHelper.ColorArray[i * 4 + 1];
                ColorTable[i].rgbBlue = ColorHelper.ColorArray[i * 4];
                ColorTable[i].rgbReserved = ColorHelper.ColorArray[i * 4 + 3];
            }
        }

        /// <summary>
        /// 释放指定对象资源
        /// </summary>
        /// <param name="obj"></param>
        public static void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}