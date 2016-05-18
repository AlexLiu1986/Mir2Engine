using GameFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace M2Server
{
    public class Grobal2
    {
        // ȫ��(�������Ϳͻ���ͨ��)��Ϣ,���ݽṹ,������
        public const int MAXPATHLEN = 255;
        public const int DIRPATHLEN = 80;
        public const int MAPNAMELEN = 16;
        public const int ACTORNAMELEN = 14;
        public const int DEFBLOCKSIZE = 32;
        public const int GROUPMAX = 11;
        public const int BAGGOLD = 5000000;
        public const int BODYLUCKUNIT = 10;
        public const int MAX_STATUS_ATTRIBUTE = 12;
        // ����������ֻ��8������,���Ǵ��,�ƶ����,��ӥ����16����
        public const byte DR_UP = 0;
        // ��
        public const byte DR_UPRIGHT = 1;
        // ������
        public const byte DR_RIGHT = 2;
        // ��
        public const byte DR_DOWNRIGHT = 3;
        // ������
        public const byte DR_DOWN = 4;
        // ��
        public const byte DR_DOWNLEFT = 5;
        // ������
        public const byte DR_LEFT = 6;
        // ��
        public const byte DR_UPLEFT = 7;
        // ������
        // װ����Ŀ
     
        /// <summary>
        /// �޲�����֮��
        /// </summary>
        public const int X_RepairFir = 20;
        /// <summary>
        /// �ж����ͣ��̶�
        /// </summary>
        public const int POISON_DECHEALTH = 0;
        /// <summary>
        /// �ж����ͣ��춾
        /// </summary>
        public const int POISON_DAMAGEARMOR = 1;
        /// <summary>
        /// ���ܹ���
        /// </summary>
        public const int POISON_LOCKSPELL = 2;
        /// <summary>
        /// �����ƶ�
        /// </summary>
        public const int POISON_DONTMOVE = 4;
        /// <summary>
        /// �ж�����:���
        /// </summary>
        public const int POISON_STONE = 5;
        /// <summary>
        /// ��ʯ��
        /// </summary>
        public const int STATE_STONE_MODE = 1;
        /// <summary>
        /// �����ܶ�(������)
        /// </summary>
        public const int STATE_LOCKRUN = 3;
        /// <summary>
        /// �������
        /// </summary>
        public const int STATE_ProtectionDEFENCE = 7;
        /// <summary>
        /// ����
        /// </summary>
        public const int STATE_TRANSPARENT = 8;
        /// <summary>
        /// ��ʥս����(������)
        /// </summary>
        public const int STATE_DEFENCEUP = 9;
        /// <summary>
        /// �����  ħ����
         /// </summary>
        public const int STATE_MAGDEFENCEUP = 10;
        /// <summary>
        /// ħ����
        /// </summary>
        public const int STATE_BUBBLEDEFENCEUP = 11;

        public const int USERMODE_PLAYGAME = 1;
        public const int USERMODE_LOGIN = 2;
        public const int USERMODE_LOGOFF = 3;
        public const int USERMODE_NOTICE = 4;
        public const int RUNGATEMAX = 20;
        public const uint RUNGATECODE = 0xAA55AA55;
        public const int OS_MOVINGOBJECT = 1;
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public const int OS_ITEMOBJECT = 2;
        /// <summary>
        /// �¼�����
        /// </summary>
        public const int OS_EVENTOBJECT = 3;
        public const int OS_GATEOBJECT = 4;
        public const int OS_SWITCHOBJECT = 5;
        public const int OS_MAPEVENT = 6;
        public const int OS_DOOR = 7;
        public const int OS_ROON = 8;
        /// <summary>
        /// ����
        /// </summary>
        public const int RC_PLAYOBJECT = 0;
        /// <summary>
        /// ���ι���
        /// </summary>
        public const int RC_PLAYMOSTER = 150;
        /// <summary>
        /// Ӣ��
        /// </summary>
        public const int RC_HEROOBJECT = 66;
        /// <summary>
        /// ������
        /// </summary>
        public const int RC_GUARD = 12;
        public const int RC_PEACENPC = 15;
        public const int RC_ANIMAL = 50;
        public const int RC_MONSTER = 80;
        /// <summary>
        /// NPC
        /// </summary>
        public const int RC_NPC = 10;
        /// <summary>
        /// ������
        /// </summary>
        public const int RC_ARCHERGUARD = 112;
        public const int RCC_USERHUMAN = RC_PLAYOBJECT;
        public const int RCC_GUARD = RC_GUARD;
        public const int RCC_MERCHANT = RC_ANIMAL;
        public const int ISM_WHISPER = 1234;
        public const int CM_QUERYCHR = 100;
        // ��¼�ɹ�,�ͻ����Գ����ҽ�ɫ����һ˲
        public const int CM_NEWCHR = 101;
        // ������ɫ
        public const int CM_DELCHR = 102;
        // ɾ����ɫ
        public const int CM_SELCHR = 103;
        // ѡ���ɫ
        public const int CM_SELECTSERVER = 104;
        // ������,ע�ⲻ��ѡ��,ʢ��һ��������(����8��??group.dat������ôд��)��ֹһ���ķ�����
        public const int CM_QUERYDELCHR = 105;
        // ��ѯɾ�����Ľ�ɫ��Ϣ 20080706
        public const int CM_RESDELCHR = 106;
        // �ָ�ɾ���Ľ�ɫ 20080706
        public const int SM_RUSH = 6;
        // �ܶ��иı䷽��
        public const int SM_RUSHKUNG = 7;
        // Ұ����ײ
        public const int SM_FIREHIT = 8;
        // �һ�
        public const int SM_4FIREHIT = 58;
        // 4���һ� 20080112
        public const int SM_BACKSTEP = 9;
        // ����,Ұ��Ч��? //����ͳ�칫���ֹ�����ҵĺ���??axemon.pas��procedure   TDualAxeOma.Run
        public const int SM_TURN = 10;
        // ת��
        public const int SM_WALK = 11;
        // ��
        public const int SM_SITDOWN = 12;
        public const int SM_RUN = 13;
        // ��
        public const int SM_HIT = 14;
        // ��
        public const int SM_HEAVYHIT = 15;
        public const int SM_BIGHIT = 16;
        public const int SM_SPELL = 17;
        // ʹ��ħ��
        public const int SM_POWERHIT = 18;
        // ��ɱ
        public const int SM_LONGHIT = 19;
        // ��ɱ
        public const int SM_DIGUP = 20;
        // ����һ"��"һ"��",�������ڶ�����"��"
        public const int SM_DIGDOWN = 21;
        // �ڶ�����"��"
        public const int SM_FLYAXE = 22;
        // �ɸ�,����ͳ��Ĺ�����ʽ?
        public const int SM_LIGHTING = 23;
        // ��������
        public const int SM_WIDEHIT = 24;
        // ����
        public const int SM_CRSHIT = 25;
        // ���µ�
        public const int SM_TWINHIT = 26;
        // ����ն�ػ�
        public const int SM_QTWINHIT = 59;
        // ����ն���
        public const int SM_CIDHIT = 57;
        // ��Ӱ����
        public const int SM_SANJUEHIT = 60;
        // ����ɱ
        public const int SM_ZHUIXINHIT = 61;
        // ׷�Ĵ�
        public const int SM_DUANYUEHIT = 62;
        // ����ն
        public const int SM_HENGSAOHIT = 63;
        // ��ɨǧ��
        public const int SM_YTPDHIT = 64;
        // ��������
        public const int SM_XPYJHIT = 65;
        // Ѫ��һ��
        public const int SM_4LONGHIT = 66;
        // �ļ���ɱ
        public const int SM_YUANYUEHIT = 67;
        // Բ���䵶
        public const int SM_ALIVE = 27;
        // ����??�����ָ
        public const int SM_MOVEFAIL = 28;
        // �ƶ�ʧ��,�߶����ܶ�
        public const int SM_HIDE = 29;
        // ����?
        public const int SM_DISAPPEAR = 30;
        // ������Ʒ��ʧ
        public const int SM_STRUCK = 31;
        // �ܹ���
        public const int SM_DEATH = 32;
        // ��������
        public const int SM_SKELETON = 33;
        // ʬ��
        public const int SM_NOWDEATH = 34;
        // ��ɱ?
        public const int SM_ACTION_MIN = SM_RUSH;
        public const int SM_ACTION_MAX = SM_WIDEHIT;
        public const int SM_ACTION2_MIN = 65072;
        public const int SM_ACTION2_MAX = 65073;
        public const int SM_HEAR = 40;
        // ���˻���Ļ�
        public const int SM_FEATURECHANGED = 41;
        public const int SM_USERNAME = 42;
        public const int SM_WINEXP = 44;
        // ��þ���
        public const int SM_LEVELUP = 45;
        // ����,���Ͻǳ���ī�̵���������
        public const int SM_DAYCHANGING = 46;
        // ����������½ǵ�̫����������
        public const int SM_LOGON = 50;
        // logon
        public const int SM_NEWMAP = 51;
        // �µ�ͼ??
        public const int SM_ABILITY = 52;
        // �����ԶԻ���,F11
        public const int SM_HEALTHSPELLCHANGED = 53;
        // ������ʹ�����������
        public const int SM_MAPDESCRIPTION = 54;
        // ��ͼ����,�л�ս��ͼ?��������?��ȫ����?
        public const int SM_SPELL2 = 117;
        // �Ի���Ϣ
        public const int SM_MOVEMESSAGE = 99;
        public const int SM_SYSMESSAGE = 100;
        // ϵͳ��Ϣ,ʢ��һ�����,˽������
        public const int SM_GROUPMESSAGE = 101;
        // ��������!!
        public const int SM_CRY = 102;
        // ����
        public const int SM_WHISPER = 103;
        // ˽��
        public const int SM_GUILDMESSAGE = 104;
        // �л�����!~
        public const int SM_ADDITEM = 200;
        public const int SM_BAGITEMS = 201;
        public const int SM_DELITEM = 202;
        public const int SM_UPDATEITEM = 203;
        public const int SM_ADDMAGIC = 210;
        public const int SM_SENDMYMAGIC = 211;
        public const int SM_DELMAGIC = 212;
        public const int SM_BACKSTEPEX = 250;
        // �������˷��͵����� SM:server msg,�������ͻ��˷��͵���Ϣ
        // ��¼�����ʺš��½�ɫ����ѯ��ɫ��
        public const int SM_CERTIFICATION_FAIL = 501;
        public const int SM_ID_NOTFOUND = 502;
        public const int SM_PASSWD_FAIL = 503;
        // ��֤ʧ��,"��������֤ʧ��,��Ҫ���µ�¼"??
        public const int SM_NEWID_SUCCESS = 504;
        // �������˺ųɹ�
        public const int SM_NEWID_FAIL = 505;
        // �������˺�ʧ��
        public const int SM_CHGPASSWD_SUCCESS = 506;
        // �޸�����ɹ�
        public const int SM_CHGPASSWD_FAIL = 507;
        // �޸�����ʧ��
        public const int SM_GETBACKPASSWD_SUCCESS = 508;
        // �����һسɹ�
        public const int SM_GETBACKPASSWD_FAIL = 509;
        // �����һ�ʧ��
        public const int SM_QUERYCHR = 520;
        // ���ؽ�ɫ��Ϣ���ͻ���
        public const int SM_NEWCHR_SUCCESS = 521;
        // �½���ɫ�ɹ�
        public const int SM_NEWCHR_FAIL = 522;
        // �½���ɫʧ��
        public const int SM_DELCHR_SUCCESS = 523;
        // ɾ����ɫ�ɹ�
        public const int SM_DELCHR_FAIL = 524;
        // ɾ����ɫʧ��
        public const int SM_STARTPLAY = 525;
        // ��ʼ������Ϸ����(���˽�����Ϸ�Ҹ�������Ϸ����)
        public const int SM_STARTFAIL = 526;
        // //��ʼʧ��,�洫���������,��ʱѡ���ɫ,�㽡����Ϸ�Ҹ�����
        public const int SM_QUERYCHR_FAIL = 527;
        // ���ؽ�ɫ��Ϣ���ͻ���ʧ��
        public const int SM_OUTOFCONNECTION = 528;
        // �������������,ǿ���û�����
        public const int SM_PASSOK_SELECTSERVER = 529;
        // ������֤�����������ȷ,��ʼѡ��
        public const int SM_SELECTSERVER_OK = 530;
        // ѡ���ɹ�
        public const int SM_NEEDUPDATE_ACCOUNT = 531;
        // ��Ҫ����,ע����ID�ᷢ��ʲô�仯?˽���е���ͨID������ֵ??��������ͨID��Ϊ��ԱID,GM?
        public const int SM_UPDATEID_SUCCESS = 532;
        // ���³ɹ�
        public const int SM_UPDATEID_FAIL = 533;
        // ����ʧ��
        public const int SM_QUERYDELCHR = 534;
        // ����ɾ�����Ľ�ɫ 20080706
        public const int SM_QUERYDELCHR_FAIL = 535;
        // ����ɾ�����Ľ�ɫʧ�� 20080706
        public const int SM_RESDELCHR_SUCCESS = 536;
        // �ָ�ɾ����ɫ�ɹ� 20080706
        public const int SM_RESDELCHR_FAIL = 537;
        // �ָ�ɾ����ɫʧ�� 20080706
        public const int SM_NOCANRESDELCHR = 538;
        // ��ֹ�ָ�ɾ����ɫ,�����ɲ鿴 200800706
        public const int SM_DROPITEM_SUCCESS = 600;
        public const int SM_DROPITEM_FAIL = 601;
        public const int SM_ITEMSHOW = 610;
        public const int SM_ITEMHIDE = 611;
        // SM_DOOROPEN           = 612;
        public const int SM_OPENDOOR_OK = 612;
        // ͨ�����ŵ�ɹ�
        public const int SM_OPENDOOR_LOCK = 613;
        // ���ֹ��ſ��Ƿ�����,��ǰʢ������ͨ��ȥ���µ���Ҫ5���ӿ�һ��
        public const int SM_CLOSEDOOR = 614;
        // �û�����,�����йر�
        public const int SM_TAKEON_OK = 615;
        public const int SM_TAKEON_FAIL = 616;
        public const int SM_TAKEOFF_OK = 619;
        public const int SM_TAKEOFF_FAIL = 620;
        public const int SM_SENDUSEITEMS = 621;
        public const int SM_WEIGHTCHANGED = 622;
        public const int SM_CLEAROBJECTS = 633;
        public const int SM_CHANGEMAP = 634;
        // ��ͼ�ı�,�����µ�ͼ
        public const int SM_EAT_OK = 635;
        public const int SM_EAT_FAIL = 636;
        public const int SM_BUTCH = 637;
        // Ұ��?
        public const int SM_MAGICFIRE = 638;
        // ������,��ǽ??
        public const int SM_MAGICFIRE_FAIL = 639;
        public const int SM_MAGIC_LVEXP = 640;
        public const int SM_DURACHANGE = 642;
        public const int SM_MERCHANTSAY = 643;
        public const int SM_MERCHANTDLGCLOSE = 644;
        public const int SM_SENDGOODSLIST = 645;
        public const int SM_SENDUSERSELL = 646;
        public const int SM_SENDBUYPRICE = 647;
        public const int SM_USERSELLITEM_OK = 648;
        public const int SM_USERSELLITEM_FAIL = 649;
        public const int SM_BUYITEM_SUCCESS = 650;
        // ?
        public const int SM_BUYITEM_FAIL = 651;
        // ?
        public const int SM_SENDDETAILGOODSLIST = 652;
        public const int SM_GOLDCHANGED = 653;
        public const int SM_CHANGELIGHT = 654;
        // ���ظı�
        public const int SM_LAMPCHANGEDURA = 655;
        // ����־øı�
        public const int SM_CHANGENAMECOLOR = 656;
        // ������ɫ�ı�,����,����,����,����
        public const int SM_CHARSTATUSCHANGED = 657;
        public const int SM_SENDNOTICE = 658;
        // ���ͽ�����Ϸ�Ҹ�(����)
        public const int SM_GROUPMODECHANGED = 659;
        // ���ģʽ�ı�
        public const int SM_CREATEGROUP_OK = 660;
        public const int SM_CREATEGROUP_FAIL = 661;
        public const int SM_GROUPADDMEM_OK = 662;
        public const int SM_GROUPDELMEM_OK = 663;
        public const int SM_GROUPADDMEM_FAIL = 664;
        public const int SM_GROUPDELMEM_FAIL = 665;
        public const int SM_GROUPCANCEL = 666;
        public const int SM_GROUPMEMBERS = 667;
        public const int SM_SENDUSERREPAIR = 668;
        public const int SM_USERREPAIRITEM_OK = 669;
        public const int SM_USERREPAIRITEM_FAIL = 670;
        public const int SM_SENDREPAIRCOST = 671;
        public const int SM_DEALMENU = 673;
        public const int SM_DEALTRY_FAIL = 674;
        public const int SM_DEALADDITEM_OK = 675;
        public const int SM_DEALADDITEM_FAIL = 676;
        public const int SM_DEALDELITEM_OK = 677;
        /// <summary>
        /// ����ʧ��
        /// </summary>
        public const int SM_DEALDELITEM_FAIL = 678;
        public const int SM_DEALCANCEL = 681;
        public const int SM_DEALREMOTEADDITEM = 682;
        public const int SM_DEALREMOTEDELITEM = 683;
        public const int SM_DEALCHGGOLD_OK = 684;
        public const int SM_DEALCHGGOLD_FAIL = 685;
        public const int SM_DEALREMOTECHGGOLD = 686;
        public const int SM_DEALSUCCESS = 687;
        public const int SM_SENDUSERSTORAGEITEM = 700;
        /// <summary>
        /// �洢��Ʒ�ɹ�
        /// </summary>
        public const int SM_STORAGE_OK = 701;
        /// <summary>
        /// �ֿ���Ʒ��
        /// </summary>
        public const int SM_STORAGE_FULL = 702;
        /// <summary>
        /// �洢��Ʒʧ��
        /// </summary>
        public const int SM_STORAGE_FAIL = 703;
        public const int SM_SAVEITEMLIST = 704;
        public const int SM_TAKEBACKSTORAGEITEM_OK = 705;
        public const int SM_TAKEBACKSTORAGEITEM_FAIL = 706;
        public const int SM_TAKEBACKSTORAGEITEM_FULLBAG = 707;
        public const int SM_AREASTATE = 708;
        // ��Χ״̬
        public const int SM_MYSTATUS = 766;
        // �ҵ�״̬,���һ������״̬,���Ƿ񱻶�,���˾�ǿ�ƻس�
        public const int SM_DELITEMS = 709;
        public const int SM_READMINIMAP_OK = 710;
        public const int SM_READMINIMAP_FAIL = 711;
        public const int SM_SENDUSERMAKEDRUGITEMLIST = 712;
        public const int SM_MAKEDRUG_SUCCESS = 713;
        // 714
        // 716
        public const int SM_MAKEDRUG_FAIL = 65036;
        public const int SM_CHANGEGUILDNAME = 750;
        public const int SM_SENDUSERSTATE = 751;
        public const int SM_SUBABILITY = 752;
        // ���������ԶԻ���
        public const int SM_OPENGUILDDLG = 753;
        public const int SM_OPENGUILDDLG_FAIL = 754;
        public const int SM_SENDGUILDMEMBERLIST = 756;
        public const int SM_GUILDADDMEMBER_OK = 757;
        public const int SM_GUILDADDMEMBER_FAIL = 758;
        public const int SM_GUILDDELMEMBER_OK = 759;
        public const int SM_GUILDDELMEMBER_FAIL = 760;
        public const int SM_GUILDRANKUPDATE_FAIL = 761;
        public const int SM_BUILDGUILD_OK = 762;
        public const int SM_BUILDGUILD_FAIL = 763;
        public const int SM_DONATE_OK = 764;
        public const int SM_DONATE_FAIL = 765;
        public const int SM_MENU_OK = 767;
        // ?
        public const int SM_GUILDMAKEALLY_OK = 768;
        public const int SM_GUILDMAKEALLY_FAIL = 769;
        public const int SM_GUILDBREAKALLY_OK = 770;
        // ?
        public const int SM_GUILDBREAKALLY_FAIL = 771;
        // ?
        public const int SM_DLGMSG = 772;
        // Jacky
        public const int SM_SPACEMOVE_HIDE = 800;
        // ��ʿ��һ������
        public const int SM_SPACEMOVE_SHOW = 801;
        // ��ʿ��һ���������Ϊ����
        public const int SM_RECONNECT = 802;
        // �����������
        public const int SM_GHOST = 803;
        // ʬ�����,��ħ��������Ч��?
        public const int SM_SHOWEVENT = 804;
        // ��ʾ�¼�
        public const int SM_HIDEEVENT = 805;
        // �����¼�
        public const int SM_SPACEMOVE_HIDE2 = 806;
        public const int SM_SPACEMOVE_SHOW2 = 807;
        public const int SM_TIMECHECK_MSG = 810;
        // ʱ�Ӽ��,����ͻ�������
        public const int SM_ADJUST_BONUS = 811;
        // ?
        // ----SM_��Ϣ ��6000��ʼ���----//
        public const int SM_OPENPULSE_OK = 6000;
        public const int SM_OPENPULSE_FAIL = 6001;
        public const int SM_RUSHPULSE_OK = 6002;
        public const int SM_RUSHPULSE_FAIL = 6003;
        public const int SM_PULSECHANGED = 6004;
        public const int SM_BATTERORDER = 6005;
        public const int SM_CANUSEBATTER = 6006;
        public const int SM_BATTERUSEFINALLY = 6007;
        public const int SM_BATTERSTART = 6008;
        public const int SM_OPENPULS = 6009;
        // �򿪾���
        public const int SM_HEROBATTERORDER = 6010;
        public const int SM_HEROPULSECHANGED = 6011;
        public const int SM_BATTERBACKSTEP = 6012;
        public const int SM_STORMSRATE = 6013;
        public const int SM_STORMSRATECHANGED = 6014;
        public const int SM_HEROSTORMSRATECHANGED = 6015;
        public const int SM_OPENPULSENEEDLEV = 6016;
        public const int SM_HEROATTECTMODE = 6017;
        public const int SM_GETASSESSHEROINFO = 6018;
        public const int SM_QUERYASSESSHERO = 6019;
        public const int SM_SHOWASSESSDLG = 6020;
        public const int SM_ISDEHERO = 6021;
        public const int SM_OPENTRAININGDLG = 6022;
        public const int SM_OPENHEALTH = 1100;
        public const int SM_CLOSEHEALTH = 1101;
        public const int SM_BREAKWEAPON = 1102;
        // ��������
        public const int SM_INSTANCEHEALGUAGE = 1103;
        // ʵʱ����
        public const int SM_CHANGEFACE = 1104;
        // ����,���͸ı�?
        public const int SM_VERSION_FAIL = 1106;
        // �ͻ��˰汾��֤ʧ��
        public const int SM_ITEMUPDATE = 1500;
        public const int SM_MONSTERSAY = 1501;
        public const int SM_EXCHGTAKEON_OK = 65023;
        public const int SM_EXCHGTAKEON_FAIL = 65024;
        public const int SM_TEST = 65037;
        public const int SM_TESTHERO = 65038;
        public const int SM_THROW = 65069;
        public const int RM_DELITEMS = 9000;
        // Jacky
        public const int RM_TURN = 10001;
        public const int RM_WALK = 10002;
        public const int RM_RUN = 10003;
        public const int RM_HIT = 10004;
        public const int RM_SPELL = 10007;
        public const int RM_SPELL2 = 10008;
        public const int RM_POWERHIT = 10009;
        public const int RM_LONGHIT = 10011;
        public const int RM_WIDEHIT = 10012;
        public const int RM_PUSH = 10013;
        public const int RM_FIREHIT = 10014;
        // �һ�
        public const int RM_4FIREHIT = 10016;
        // 4���һ� 20080112
        public const int RM_RUSH = 10015;
        public const int RM_STRUCK = 10020;
        // ��������
        public const int RM_DEATH = 10021;
        public const int RM_DISAPPEAR = 10022;
        public const int RM_MAGSTRUCK = 10025;
        public const int RM_MAGHEALING = 10026;
        public const int RM_STRUCK_MAG = 10027;
        // ��ħ�����
        public const int RM_MAGSTRUCK_MINE = 10028;
        public const int RM_INSTANCEHEALGUAGE = 10029;
        // jacky
        public const int RM_HEAR = 10030;
        // ����
        public const int RM_WHISPER = 10031;
        public const int RM_CRY = 10032;
        public const int RM_RIDE = 10033;
        public const int RM_WINEXP = 10044;
        public const int RM_USERNAME = 10043;
        public const int RM_LEVELUP = 10045;
        public const int RM_CHANGENAMECOLOR = 10046;
        public const int RM_PUSHEX = 10047;
        public const int RM_LOGON = 10050;
        public const int RM_ABILITY = 10051;
        public const int RM_HEALTHSPELLCHANGED = 10052;
        public const int RM_DAYCHANGING = 10053;
        public const int RM_MOVEMESSAGE = 10099;
        // ��������   ���� 2007.11.13
        public const int RM_SYSMESSAGE = 10100;
        public const int RM_GROUPMESSAGE = 10102;
        public const int RM_SYSMESSAGE2 = 10103;
        public const int RM_GUILDMESSAGE = 10104;
        public const int RM_SYSMESSAGE3 = 10105;
        /// <summary>
        /// ��ʾ��Ʒ
        /// </summary>
        public const int RM_ITEMSHOW = 10110;
        /// <summary>
        /// ������Ʒ
        /// </summary>
        public const int RM_ITEMHIDE = 10111;
        public const int RM_DOOROPEN = 10112;
        public const int RM_DOORCLOSE = 10113;
        public const int RM_SENDUSEITEMS = 10114;
        // ����ʹ�õ���Ʒ
        public const int RM_WEIGHTCHANGED = 10115;
        public const int RM_FEATURECHANGED = 10116;
        public const int RM_CLEAROBJECTS = 10117;
        public const int RM_CHANGEMAP = 10118;
        public const int RM_BUTCH = 10119;
        // ��
        public const int RM_MAGICFIRE = 10120;
        public const int RM_SENDMYMAGIC = 10122;
        // ����ʹ�õ�ħ��
        public const int RM_MAGIC_LVEXP = 10123;
        public const int RM_SKELETON = 10024;
        public const int RM_DURACHANGE = 10125;
        /// <summary>
        /// �־øı�
        /// </summary>
        public const int RM_MERCHANTSAY = 10126;
        /// <summary>
        /// ��Ҹı�
        /// </summary>
        public const int RM_GOLDCHANGED = 10136;
        public const int RM_CHANGELIGHT = 10137;
        public const int RM_CHARSTATUSCHANGED = 10139;
        public const int RM_DELAYMAGIC = 10154;
        public const int RM_DIGUP = 10200;
        public const int RM_DIGDOWN = 10201;
        public const int RM_FLYAXE = 10202;
        public const int RM_LIGHTING = 10204;
        public const int RM_SUBABILITY = 10302;
        public const int RM_TRANSPARENT = 10308;
        public const int RM_SPACEMOVE_SHOW = 10331;
        public const int RM_RECONNECTION = 11332;
        public const int RM_SPACEMOVE_SHOW2 = 10332;
        // �����̻�
        public const int RM_HIDEEVENT = 10333;
        // ��ʾ�̻�
        public const int RM_SHOWEVENT = 10334;
        public const int RM_ZEN_BEE = 10337;
        public const int RM_OPENHEALTH = 10410;
        public const int RM_CLOSEHEALTH = 10411;
        public const int RM_DOOPENHEALTH = 10412;
        public const int RM_CHANGEFACE = 10415;
        public const int RM_ITEMUPDATE = 11000;
        public const int RM_MONSTERSAY = 11001;
        public const int RM_MAKESLAVE = 11002;
        public const int RM_MONMOVE = 21004;
        public const int SS_200 = 200;
        public const int SS_201 = 201;
        public const int SS_202 = 202;
        public const int SS_WHISPER = 203;
        public const int SS_204 = 204;
        public const int SS_205 = 205;
        public const int SS_206 = 206;
        public const int SS_207 = 207;
        public const int SS_208 = 208;
        public const int SS_209 = 219;
        public const int SS_210 = 210;
        public const int SS_211 = 211;
        public const int SS_212 = 212;
        public const int SS_213 = 213;
        public const int SS_214 = 214;
        public const int RM_10205 = 10205;
        public const int RM_10101 = 10101;
        public const int RM_ALIVE = 10153;
        // ����
        public const int RM_CHANGEGUILDNAME = 10301;
        public const int RM_10414 = 10414;
        public const int RM_POISON = 10300;
        public const int LA_UNDEAD = 1;
        // ����ϵ
        public const int RM_DELAYPUSHED = 10555;
        public const int CM_GETBACKPASSWORD = 2010;
        // �����һ�
        public const int CM_SPELL = 3017;
        // ʩħ��
        public const int CM_QUERYUSERNAME = 80;
        // ������Ϸ,���������ؽ�ɫ�����ͻ���
        public const int CM_DROPITEM = 1000;
        // �Ӱ������ӳ���Ʒ����ͼ,��ʱ��������ڰ�ȫ�����ܻ���ʾ��ȫ���������Ӷ���
        public const int CM_PICKUP = 1001;
        // ����
        public const int CM_TAKEONITEM = 1003;
        // װ��װ�������ϵ�װ��λ��
        public const int CM_TAKEOFFITEM = 1004;
        // ������ĳ��װ��λ��ȡ��ĳ��װ��
        public const int CM_EAT = 1006;
        // ��ҩ
        public const int CM_BUTCH = 1007;
        // ��
        public const int CM_MAGICKEYCHANGE = 1008;
        // ħ����ݼ��ı�
        public const int CM_HEROMAGICKEYCHANGE = 1046;
        // Ӣ��ħ���������� 20080606
        public const int CM_1005 = 1005;
        // ���̵�NPC�������
        public const int CM_CLICKNPC = 1010;
        // �û������ĳ��NPC���н���
        public const int CM_MERCHANTDLGSELECT = 1011;
        // ��Ʒѡ��,����
        public const int CM_MERCHANTQUERYSELLPRICE = 1012;
        // ���ؼ۸�,��׼�۸�,����֪���̵��û��������Щ�������־û�������
        public const int CM_USERSELLITEM = 1013;
        // �û�������
        public const int CM_USERBUYITEM = 1014;
        // �û����붫��
        public const int CM_USERGETDETAILITEM = 1015;
        // ȡ����Ʒ�嵥,������"���۽�ָ"����,�����һ�����۽�ָ����ѡ��
        public const int CM_DROPGOLD = 1016;
        // �û����½�Ǯ������
        public const int CM_LOGINNOTICEOK = 1018;
        // ������Ϸ�Ҹ����ȷʵ,������Ϸ
        public const int CM_GROUPMODE = 1019;
        // ���黹�ǿ���
        public const int CM_CREATEGROUP = 1020;
        // �½����
        public const int CM_ADDGROUPMEMBER = 1021;
        // ��������
        public const int CM_DELGROUPMEMBER = 1022;
        // ����ɾ��
        public const int CM_USERREPAIRITEM = 1023;
        // �û�������
        public const int CM_MERCHANTQUERYREPAIRCOST = 1024;
        // �ͻ�����NPCȡ���������
        public const int CM_DEALTRY = 1025;
        // ��ʼ����,���׿�ʼ
        public const int CM_DEALADDITEM = 1026;
        // �Ӷ�����������Ʒ����
        public const int CM_DEALDELITEM = 1027;
        // �ӽ�����Ʒ���ϳ��ض���???��������Ŷ
        public const int CM_DEALCANCEL = 1028;
        // ȡ������
        public const int CM_DEALCHGGOLD = 1029;
        // �����������Ͻ�ǮΪ0,,���н�Ǯ����,����˫�������������Ϣ
        public const int CM_DEALEND = 1030;
        // ���׳ɹ�,��ɽ���
        public const int CM_USERSTORAGEITEM = 1031;
        // �û��Ĵ涫��
        public const int CM_USERTAKEBACKSTORAGEITEM = 1032;
        // �û��򱣹�Աȡ�ض���
        public const int CM_WANTMINIMAP = 1033;
        // �û������"С��ͼ"��ť
        public const int CM_USERMAKEDRUGITEM = 1034;
        // �û����춾ҩ(������Ʒ)
        public const int CM_OPENGUILDDLG = 1035;
        // �û������"�л�"��ť
        public const int CM_GUILDHOME = 1036;
        // ���"�л���ҳ"
        public const int CM_GUILDMEMBERLIST = 1037;
        // ���"��Ա�б�"
        public const int CM_GUILDADDMEMBER = 1038;
        // ���ӳ�Ա
        public const int CM_GUILDDELMEMBER = 1039;
        // ���˳��л�
        public const int CM_GUILDUPDATENOTICE = 1040;
        // �޸��лṫ��
        public const int CM_GUILDUPDATERANKINFO = 1041;
        // ����������Ϣ(ȡ����������)
        public const int CM_ADJUST_BONUS = 1043;
        // �û��õ�����??˽���бȽ�����,С������ʱ��ó���Ǯ������,���Ǻ�ȷ��,//�󾭹����Եĸ��ֵ���֤
        public const int CM_SPEEDHACKUSER = 10430;
        // �û��������׼��
        public const int CM_PASSWORD = 1105;
        public const int CM_CHGPASSWORD = 1221;
        // ?
        public const int CM_SETPASSWORD = 1222;
        // ?
        public const int CM_HORSERUN = 3009;
        public const int CM_THROW = 3005;
        // �׷�
        // ��������1
        public const int CM_TURN = 3010;
        // ת��(����ı�)
        public const int CM_WALK = 3011;
        // ��
        public const int CM_SITDOWN = 3012;
        // ��(����)
        public const int CM_RUN = 3013;
        // ��

        /// <summary>
        /// ��ͨ���������
        /// </summary>
        public const int CM_HIT = 3014;
        // 
        public const int CM_HEAVYHIT = 3015;
        // ��������Ķ���
        public const int CM_BIGHIT = 3016;
        public const int CM_POWERHIT = 3018;
        // ��ɱ
        public const int CM_LONGHIT = 3019;
        // ��ɱ
        public const int CM_4LONGHIT = 3066;
        // 4����ɱ
        public const int CM_YUANYUEHIT = 3067;
        // Բ���䵶
        public const int CM_WIDEHIT = 3024;
        // ����
        public const int CM_FIREHIT = 3025;
        // �һ𹥻�
        public const int CM_4FIREHIT = 3031;
        // 4���һ𹥻�
        public const int CM_CRSHIT = 3036;
        // ���µ�
        public const int CM_TWNHIT = 3037;
        // ����ն�ػ�
        public const int CM_QTWINHIT = 3041;
        // ����ն���
        public const int CM_CIDHIT = 3040;
        // ��Ӱ����
        public const int CM_TWINHIT = CM_TWNHIT;
        public const int CM_PHHIT = 3038;
        // �ƻ�ն
        public const int CM_DAILY = 3042;
        // ���ս��� 20080511
        public const int CM_SANJUEHIT = 3060;
        // ����ɱ
        public const int CM_ZHUIXINHIT = 3061;
        // ׷�Ĵ�
        public const int CM_DUANYUEHIT = 3062;
        // ����ն
        public const int CM_HENGSAOHIT = 3063;
        // ��ɨǧ��
        public const int CM_YTPDHIT = 3064;
        // ��������
        public const int CM_XPYJHIT = 3065;
        // Ѫ��һ��
        public const int RM_SANJUEHIT = 10060;
        // ����ɱ
        public const int RM_ZHUIXINHIT = 10061;
        // ׷�Ĵ�  �˸ոտ�ʼ�Ķ���
        public const int RM_DUANYUEHIT = 10062;
        // ����ն
        public const int RM_HENGSAOHIT = 10063;
        // ��ɨǧ��
        public const int RM_ZHUIXIN_OK = 10064;
        // ׷�Ĵ�  ��ײ��ȥ�Ķ���
        public const int RM_YTPDHIT = 10065;
        // ��������
        public const int RM_XPYJHIT = 10066;
        // Ѫ��һ��
        // --RM_��Ϣ ��Ӵ� 36000��--//
        public const int RM_OPENPULSE_OK = 36000;
        public const int RM_OPENPULSE_FAIL = 36001;
        public const int RM_RUSHPULSE_OK = 36002;
        public const int RM_RUSHPULSE_FAIL = 36003;
        public const int RM_PULSECHANGED = 36004;
        public const int RM_BATTERORDER = 36005;
        public const int RM_BATTERUSEFINALLY = 36006;
        public const int RM_HEROBATTERORDER = 36007;
        public const int RM_HEROPULSECHANGED = 36008;
        public const int RM_STORMSRATE = 36009;
        public const int RM_STORMSRATECHANGED = 36010;
        public const int RM_HEROSTORMSRATECHANGED = 36011;
        public const int RM_OPENPULSENEEDLEV = 36012;
        // ˫Ӣ�� ���
        // RM_GETDOUBLEHEROINFO     = 36013;
        public const int RM_HEROATTECTMODE = 36014;
        public const int RM_GETASSESSHEROINFO = 36015;
        public const int RM_QUERYASSESSHERO = 36016;
        public const int RM_SHOWASSESSDLG = 36017;
        public const int RM_ISDEHERO = 36018;
        public const int RM_OPENTRAININGDLG = 36019;
        // �¼��ܺ��ļ��������
        public const int RM_4LONGHIT = 36020;
        public const int RM_YUANYUEHIT = 36021;
        public const int CM_SAY = 3030;
        // ��ɫ����
        public const int CM_40HIT = 3026;
        public const int CM_41HIT = 3027;
        public const int CM_42HIT = 3029;
        public const int CM_43HIT = 3028;
        public const int CM_USEBATTER = 3080;
        // ʹ������
        public const int RM_10401 = 10401;
        /// <summary>
        /// �˵�
        /// </summary>
        public const int RM_MENU_OK = 10309;
        public const int RM_MERCHANTDLGCLOSE = 10127;
        public const int RM_SENDDELITEMLIST = 10148;
        // ����ɾ����Ŀ������
        public const int RM_SENDUSERSREPAIR = 10141;
        // �����û�����
        public const int RM_SENDGOODSLIST = 10128;
        // ������Ʒ����
        public const int RM_SENDUSERSELL = 10129;
        // �����û�����
        public const int RM_SENDUSERREPAIR = 11139;
        // �����û�����
        public const int RM_USERMAKEDRUGITEMLIST = 10149;
        // �û���ҩƷ��Ŀ������
        public const int RM_USERSTORAGEITEM = 10146;
        // �û��ֿ���Ŀ
        public const int RM_USERGETBACKITEM = 10147;
        // �û���ûصĲֿ���Ŀ
        public const int RM_SPACEMOVE_FIRE2 = 11330;
        // �ռ��ƶ�
        public const int RM_SPACEMOVE_FIRE = 11331;
        // �ռ��ƶ�
        public const int RM_BUYITEM_SUCCESS = 10133;
        // ������Ŀ�ɹ�
        public const int RM_BUYITEM_FAIL = 10134;
        // ������Ŀʧ��
        public const int RM_SENDDETAILGOODSLIST = 10135;
        // ������ϸ����Ʒ����
        public const int RM_SENDBUYPRICE = 10130;
        // ���͹���۸�
        public const int RM_USERSELLITEM_OK = 10131;
        // �û����۳ɹ�
        public const int RM_USERSELLITEM_FAIL = 10132;
        // �û�����ʧ��
        public const int RM_MAKEDRUG_SUCCESS = 10150;
        // ��ҩ�ɹ�
        public const int RM_MAKEDRUG_FAIL = 10151;
        // ��ҩʧ��
        public const int RM_SENDREPAIRCOST = 10142;
        // ��������ɱ�
        public const int RM_USERREPAIRITEM_OK = 10143;
        // �û�������Ŀ�ɹ�
        public const int RM_USERREPAIRITEM_FAIL = 10144;
        // �û�������Ŀʧ��
        public const int MAXBAGITEM = 46;
        // ���ﱳ���������
        public const int MAXHEROBAGITEM = 40;
        // Ӣ�۰����������
        public const int RM_10155 = 10155;
        public const int RM_PLAYDICE = 10500;
        public const int RM_ADJUST_BONUS = 10400;
        public const int RM_BUILDGUILD_OK = 10303;
        public const int RM_BUILDGUILD_FAIL = 10304;
        public const int RM_DONATE_OK = 10305;
        public const int RM_GAMEGOLDCHANGED = 10666;
        public const int STATE_OPENHEATH = 1;
        public const int POISON_68 = 68;
        public const int RM_MYSTATUS = 10777;
        public const int CM_QUERYUSERSTATE = 82;
        // ��ѯ�û�״̬(�û���¼��ȥ,ʵ�����ǿͻ������������ȡ��ѯ���һ��,�˳�������ǰ��״̬�Ĺ���,
        // �������Զ����û����һ������������Ϸ������һЩ��Ϣ���ص��ͻ���)
        public const int CM_QUERYBAGITEMS = 81;
        // ��ѯ������Ʒ
        public const int CM_QUERYUSERSET = 49999;
        public const int CM_OPENDOOR = 1002;
        // ����,�����ߵ���ͼ��ĳ�����ŵ�ʱ
        public const int CM_SOFTCLOSE = 1009;
        // �˳�����(��Ϸ����,��������Ϸ�д���,Ҳ����ʱѡ��ʱ�˳�)
        public const int CM_1017 = 1017;
        public const int CM_1042 = 1042;
        public const int CM_GUILDALLY = 1044;
        public const int CM_GUILDBREAKALLY = 1045;
        public const int RM_HORSERUN = 11000;
        public const int RM_HEAVYHIT = 10005;
        public const int RM_BIGHIT = 10006;
        public const int RM_MOVEFAIL = 10010;
        public const int RM_CRSHIT = 11014;
        public const int RM_RUSHKUNG = 11015;
        public const int RM_41 = 41;
        public const int RM_42 = 42;
        public const int RM_43 = 43;
        public const int RM_44 = 56;
        public const int RM_MAGICFIREFAIL = 10121;
        public const int RM_LAMPCHANGEDURA = 10138;
        public const int RM_GROUPCANCEL = 10140;
        public const int RM_DONATE_FAIL = 10306;
        public const int RM_BREAKWEAPON = 10413;
        public const int RM_PASSWORD = 10416;
        public const int RM_PASSWORDSTATUS = 10601;
        public const int SM_40 = 35;
        public const int SM_41 = 36;
        public const int SM_42 = 37;
        public const int SM_43 = 38;
        public const int SM_44 = 39;
        // ��Ӱ����
        public const int SM_HORSERUN = 5;
        public const int SM_716 = 716;
        public const int SM_PASSWORD = 3030;
        public const int SM_PLAYDICE = 1200;
        public const int SM_PASSWORDSTATUS = 20001;
        public const int SM_GAMEGOLDNAME = 55;
        // ��ͻ��˷�����Ϸ��,��Ϸ��,���ʯ,�������
        public const int SM_SERVERCONFIG = 20002;
        public const int SM_GETREGINFO = 20003;
        public const int ET_DIGOUTZOMBI = 1;
        public const int ET_PILESTONES = 3;
        public const int ET_HOLYCURTAIN = 4;
        public const int ET_FIRE = 5;
        public const int ET_SCULPEICE = 6;
        // 6���̻�
        public const int ET_FIREFLOWER_1 = 7;
        // һ��һ��
        public const int ET_FIREFLOWER_2 = 8;
        // ������ӡ
        public const int ET_FIREFLOWER_3 = 9;
        public const int ET_FIREFLOWER_4 = 10;
        public const int ET_FIREFLOWER_5 = 11;
        public const int ET_FIREFLOWER_6 = 12;
        public const int ET_FIREFLOWER_7 = 13;
        public const int ET_FIREFLOWER_8 = 14;
        // û��ͼƬ
        public const int ET_FOUNTAIN = 15;
        // ��ȪЧ�� 20080624
        public const int ET_DIEEVENT = 16;
        // ����ׯ����������Ч�� 20080918
        public const int ET_FIREDRAGON = 17;
        // �ػ���С��ȦЧ�� 20090123
        public const int CM_PROTOCOL = 2000;
        public const int CM_IDPASSWORD = 2001;
        // �ͻ��������������ID������
        public const int CM_ADDNEWUSER = 2002;
        // �½��û�,����ע�����˺�,��¼ʱѡ����"���û�"�������ɹ�
        public const int CM_CHANGEPASSWORD = 2003;
        // �޸�����
        public const int CM_UPDATEUSER = 2004;
        // ����ע������??
        public const int CM_RANDOMCODE = 2006;
        // ȡ��֤�� 20080612
        public const int SM_RANDOMCODE = 2007;

        public const int CM_3037 = 3039;
        // 2007.10.15����ֵ  ��ǰ��  3037
        public const int SM_NEEDPASSWORD = 8003;
        public const int CM_POWERBLOCK = 0;
        // �������
        public const int CM_OPENSHOP = 9000;
        // ������
        public const int SM_SENGSHOPITEMS = 9001;
        // SERIES 7 ÿҳ������    wParam ��ҳ��
        public const int CM_BUYSHOPITEM = 9002;
        public const int SM_BUYSHOPITEM_SUCCESS = 9003;
        public const int SM_BUYSHOPITEM_FAIL = 9004;
        public const int SM_SENGSHOPSPECIALLYITEMS = 9005;
        // ��������
        public const int CM_BUYSHOPITEMGIVE = 9006;
        // ����
        public const int SM_BUYSHOPITEMGIVE_FAIL = 9007;
        public const int SM_BUYSHOPITEMGIVE_SUCCESS = 9008;
        public const int RM_OPENSHOPSpecially = 30000;
        public const int RM_OPENSHOP = 30001;
        public const int RM_BUYSHOPITEM_FAIL = 30003;
        // ���̹�����Ʒʧ��
        public const int RM_BUYSHOPITEMGIVE_FAIL = 30004;
        public const int RM_BUYSHOPITEMGIVE_SUCCESS = 30005;
        // ==============================================================================
        public const int CM_QUERYUSERLEVELSORT = 3500;
        // �û��ȼ�����
        public const int RM_QUERYUSERLEVELSORT = 35000;
        public const int SM_QUERYUSERLEVELSORT = 2500;
        // ==============================������Ʒ����ϵͳ(����)==========================
        public const int RM_SENDSELLOFFGOODSLIST = 21008;
        // ����
        public const int SM_SENDSELLOFFGOODSLIST = 20008;
        // ����
        public const int RM_SENDUSERSELLOFFITEM = 21005;
        // ������Ʒ
        public const int SM_SENDUSERSELLOFFITEM = 20005;
        // ������Ʒ
        public const int RM_SENDSELLOFFITEMLIST = 22009;
        // ��ѯ�õ��ļ�����Ʒ
        public const int CM_SENDSELLOFFITEMLIST = 20009;
        // ��ѯ�õ��ļ�����Ʒ
        public const int RM_SENDBUYSELLOFFITEM_OK = 21010;
        // ���������Ʒ�ɹ�
        public const int SM_SENDBUYSELLOFFITEM_OK = 20010;
        // ���������Ʒ�ɹ�
        public const int RM_SENDBUYSELLOFFITEM_FAIL = 21011;
        // ���������Ʒʧ��
        public const int SM_SENDBUYSELLOFFITEM_FAIL = 20011;
        // ���������Ʒʧ��
        public const int RM_SENDBUYSELLOFFITEM = 41005;
        // ����ѡ�������Ʒ
        public const int CM_SENDBUYSELLOFFITEM = 4005;
        // ����ѡ�������Ʒ
        public const int RM_SENDQUERYSELLOFFITEM = 41006;
        // ��ѯѡ�������Ʒ
        public const int CM_SENDQUERYSELLOFFITEM = 4006;
        // ��ѯѡ�������Ʒ
        public const int RM_SENDSELLOFFITEM = 41004;
        // ���ܼ�����Ʒ
        public const int CM_SENDSELLOFFITEM = 4004;
        // ���ܼ�����Ʒ
        public const int RM_SENDUSERSELLOFFITEM_FAIL = 2007;
        // R = -3  ������Ʒʧ��
        public const int RM_SENDUSERSELLOFFITEM_OK = 2006;
        // ������Ʒ�ɹ�
        public const int SM_SENDUSERSELLOFFITEM_FAIL = 20007;
        // R = -3  ������Ʒʧ��
        public const int SM_SENDUSERSELLOFFITEM_OK = 20006;
        // ������Ʒ�ɹ�
        // ==============================Ԫ������ϵͳ(20080316)==========================
        public const int RM_SENDDEALOFFFORM = 23000;
        // �򿪳�����Ʒ����
        public const int SM_SENDDEALOFFFORM = 23001;
        // �򿪳�����Ʒ����
        public const int CM_SELLOFFADDITEM = 23002;
        // �ͻ�����������Ʒ���������Ʒ
        public const int SM_SELLOFFADDITEM_OK = 23003;
        // �ͻ�����������Ʒ���������Ʒ �ɹ�
        public const int RM_SELLOFFADDITEM_OK = 23004;
        public const int SM_SellOffADDITEM_FAIL = 23005;
        // �ͻ�����������Ʒ���������Ʒ ʧ��
        public const int RM_SellOffADDITEM_FAIL = 23006;
        public const int CM_SELLOFFDELITEM = 23007;
        // �ͻ���ɾ��������Ʒ�������Ʒ
        public const int SM_SELLOFFDELITEM_OK = 23008;
        // �ͻ���ɾ��������Ʒ�������Ʒ �ɹ�
        public const int RM_SELLOFFDELITEM_OK = 23009;
        public const int SM_SELLOFFDELITEM_FAIL = 23010;
        // �ͻ���ɾ��������Ʒ�������Ʒ ʧ��
        public const int RM_SELLOFFDELITEM_FAIL = 23011;
        /// <summary>
        /// �ͻ���ȡ��Ԫ������
        /// </summary>
        public const int CM_SELLOFFCANCEL = 23012;
        /// <summary>
        /// Ԫ������ȡ������
        /// </summary>
        public const int RM_SELLOFFCANCEL = 23013;
        /// <summary>
        /// Ԫ������ȡ������
        /// </summary>
        public const int SM_SellOffCANCEL = 23014;
        /// <summary>
        /// �ͻ���Ԫ�����۽���
        /// </summary>
        public const int CM_SELLOFFEND = 23015;
        /// <summary>
        /// �ͻ���Ԫ�����۽��� �ɹ�
        /// </summary>
        public const int SM_SELLOFFEND_OK = 23016;
        /// <summary>
        /// �ͻ���Ԫ�����۽��� �ɹ�
        /// </summary>
        public const int RM_SELLOFFEND_OK = 23017;
        /// <summary>
        /// �ͻ���Ԫ�����۽��� ʧ��
        /// </summary>
        public const int SM_SELLOFFEND_FAIL = 23018;
        /// <summary>
        /// �ͻ���Ԫ�����۽��� ʧ��
        /// </summary>
        public const int RM_SELLOFFEND_FAIL = 23019;
        public const int RM_QUERYYBSELL = 23020;
        // ��ѯ���ڳ��۵���Ʒ
        public const int SM_QUERYYBSELL = 23021;
        // ��ѯ���ڳ��۵���Ʒ
        public const int RM_QUERYYBDEAL = 23022;
        // ��ѯ���ԵĹ�����Ʒ
        public const int SM_QUERYYBDEAL = 23023;
        // ��ѯ���ԵĹ�����Ʒ
        public const int CM_CANCELSELLOFFITEMING = 23024;
        // ȡ�����ڼ��۵���Ʒ 20080318(������)
        // SM_CANCELSELLOFFITEMING_OK =23018;//ȡ�����ڼ��۵���Ʒ �ɹ�
        public const int CM_SELLOFFBUYCANCEL = 23025;
        // ȡ������ ��Ʒ���� 20080318(������)
        public const int CM_SELLOFFBUY = 23026;
        // ȷ�����������Ʒ 20080318
        public const int SM_SELLOFFBUY_OK = 23027;
        /// <summary>
        /// ����ɹ�
        /// </summary>
        public const int RM_SELLOFFBUY_OK = 23028;
        // ==============================================================================
        // Ӣ��
        // //////////////////////////////////////////////////////////////////////////////
        public const int CM_RECALLHERO = 5000;
        // �ٻ�Ӣ��
        public const int SM_RECALLHERO = 5001;
        public const int CM_HEROLOGOUT = 5002;
        // Ӣ���˳�
        public const int SM_HEROLOGOUT = 5003;
        public const int SM_CREATEHERO = 5004;
        // ����Ӣ��
        public const int SM_HERODEATH = 5005;
        // ��������
        public const int CM_HEROCHGSTATUS = 5006;
        // �ı�Ӣ��״̬
        public const int CM_HEROATTACKTARGET = 5007;
        // Ӣ������Ŀ��
        public const int CM_HEROPROTECT = 5008;
        // �ػ�Ŀ��
        public const int CM_HEROTAKEONITEM = 5009;
        // ����Ʒ��
        public const int CM_HEROTAKEOFFITEM = 5010;
        // �ر���Ʒ��
        public const int CM_TAKEOFFITEMHEROBAG = 5011;
        // װ�����µ�Ӣ�۰���
        public const int CM_TAKEOFFITEMTOMASTERBAG = 5012;
        // װ�����µ����˰���
        public const int CM_SENDITEMTOMASTERBAG = 5013;
        // ���˰�����Ӣ�۰���
        public const int CM_SENDITEMTOHEROBAG = 5014;
        // Ӣ�۰��������˰���
        public const int SM_HEROTAKEON_OK = 5015;
        public const int SM_HEROTAKEON_FAIL = 5016;
        public const int SM_HEROTAKEOFF_OK = 5017;
        public const int SM_HEROTAKEOFF_FAIL = 5018;
        public const int SM_TAKEOFFTOHEROBAG_OK = 5019;
        public const int SM_TAKEOFFTOHEROBAG_FAIL = 5020;
        public const int SM_TAKEOFFTOMASTERBAG_OK = 5021;
        public const int SM_TAKEOFFTOMASTERBAG_FAIL = 5022;
        public const int CM_HEROTAKEONITEMFORMMASTERBAG = 5023;
        // �����˰�����װ����Ӣ�۰���
        public const int CM_TAKEONITEMFORMHEROBAG = 5024;
        // ��Ӣ�۰�����װ�������˰���
        public const int SM_SENDITEMTOMASTERBAG_OK = 5025;
        // ���˰�����Ӣ�۰����ɹ�
        public const int SM_SENDITEMTOMASTERBAG_FAIL = 5026;
        // ���˰�����Ӣ�۰���ʧ��
        public const int SM_SENDITEMTOHEROBAG_OK = 5027;
        // Ӣ�۰��������˰���
        public const int SM_SENDITEMTOHEROBAG_FAIL = 5028;
        // Ӣ�۰��������˰���
        public const int CM_QUERYHEROBAGCOUNT = 5029;
        // �鿴Ӣ�۰�������
        public const int SM_QUERYHEROBAGCOUNT = 5030;
        // �鿴Ӣ�۰�������
        public const int CM_QUERYHEROBAGITEMS = 5031;
        // �鿴Ӣ�۰���
        public const int SM_SENDHEROUSEITEMS = 5032;
        // ����Ӣ������װ��
        public const int SM_HEROBAGITEMS = 5033;
        // ����Ӣ����Ʒ
        public const int SM_HEROADDITEM = 5034;
        // Ӣ�۰��������Ʒ
        public const int SM_HERODELITEM = 5035;
        // Ӣ�۰���ɾ����Ʒ
        public const int SM_HEROUPDATEITEM = 5036;
        // Ӣ�۰���������Ʒ
        public const int SM_HEROADDMAGIC = 5037;
        // ���Ӣ��ħ��
        public const int SM_HEROSENDMYMAGIC = 5038;
        // ����Ӣ�۵�ħ��
        public const int SM_HERODELMAGIC = 5039;
        // ɾ��Ӣ��ħ��
        public const int SM_HEROABILITY = 5040;
        // Ӣ������1
        public const int SM_HEROSUBABILITY = 5041;
        // Ӣ������2
        public const int SM_HEROWEIGHTCHANGED = 5042;
        public const int CM_HEROEAT = 5043;
        // �Զ���
        public const int SM_HEROEAT_OK = 5044;
        // �Զ����ɹ�
        public const int SM_HEROEAT_FAIL = 5045;
        // �Զ���ʧ��
        public const int SM_HEROMAGIC_LVEXP = 5046;
        // ħ���ȼ�
        public const int SM_HERODURACHANGE = 5047;
        // Ӣ�۳־øı�
        public const int SM_HEROWINEXP = 5048;
        // Ӣ�����Ӿ���
        public const int SM_HEROLEVELUP = 5049;
        // Ӣ������
        public const int SM_HEROCHANGEITEM = 5050;
        // ����û���ϣ�
        public const int SM_HERODELITEMS = 5051;
        // ɾ��Ӣ����Ʒ
        public const int CM_HERODROPITEM = 5052;
        // Ӣ������������Ʒ
        public const int SM_HERODROPITEM_SUCCESS = 5053;
        // Ӣ������Ʒ�ɹ�
        public const int SM_HERODROPITEM_FAIL = 5054;
        // Ӣ������Ʒʧ��
        public const int CM_HEROGOTETHERUSESPELL = 5055;
        // ʹ�úϻ�
        public const int SM_GOTETHERUSESPELL = 5056;
        // ʹ�úϻ�
        public const int SM_FIRDRAGONPOINT = 5057;
        // Ӣ��ŭ��ֵ
        public const int CM_REPAIRFIRDRAGON = 5058;
        // �޲�����֮��
        public const int SM_REPAIRFIRDRAGON_OK = 5059;
        // �޲�����֮�ĳɹ�
        public const int SM_REPAIRFIRDRAGON_FAIL = 5060;
        // �޲�����֮��ʧ��
        // ---------------------------------------------------
        // ף����.ħ������� 20080102
        public const int CM_REPAIRDRAGON = 5061;
        // ף����.ħ�������
        public const int SM_REPAIRDRAGON_OK = 5062;
        // �޲�ף����.ħ����ɹ�
        public const int SM_REPAIRDRAGON_FAIL = 5063;
        // �޲�ף����.ħ���ʧ��
        // ----------------------------------------------------
        // ----CM_��Ϣ ��26000��ʼ���----//
        // -------���� ����----- /
        public const int CM_OPENPULSE = 26000;
        public const int CM_RUSHPULSE = 26001;
        public const int CM_QUERYOPENPULSE = 26002;
        public const int CM_SETBATTERORDER = 26003;
        public const int CM_SETHEROBATTERORDER = 26004;
        public const int CM_QUERYHEROOPENPULSE = 26005;
        public const int CM_RUSHHEROPULSE = 26006;
        public const int CM_CHANGEHEROATTECTMODE = 26007;
        // �ı丱��Ӣ�۹���ģʽ
        public const int CM_QUERYASSESSHERO = 26008;
        public const int CM_ASSESSMENTHERO = 26009;
        public const int CM_TRAININGHERO = 26010;
        public const int RM_RECALLHERO = 19999;
        // �ٻ�Ӣ��
        public const int RM_HEROWEIGHTCHANGED = 20000;
        public const int RM_SENDHEROUSEITEMS = 20001;
        public const int RM_SENDHEROMYMAGIC = 20002;
        public const int RM_HEROMAGIC_LVEXP = 20003;
        public const int RM_QUERYHEROBAGCOUNT = 20004;
        public const int RM_HEROABILITY = 20005;
        public const int RM_HERODURACHANGE = 20006;
        public const int RM_HERODEATH = 20007;
        public const int RM_HEROLEVELUP = 20008;
        public const int RM_HEROWINEXP = 20009;
        // RM_HEROLOGOUT = 20010;
        public const int RM_CREATEHERO = 20011;
        public const int RM_MAKEGHOSTHERO = 20012;
        public const int RM_HEROSUBABILITY = 20013;
        public const int RM_GOTETHERUSESPELL = 20014;
        // ʹ�úϻ�
        public const int RM_FIRDRAGONPOINT = 20015;
        // ����Ӣ��ŭ��ֵ
        public const int RM_CHANGETURN = 20016;
        // -----------------------------------�����ػ�
        public const int RM_FAIRYATTACKRATE = 20017;
        public const int SM_FAIRYATTACKRATE = 20018;
        // -----------------------------------
        public const int SM_SERVERUNBIND = 20019;
        public const int RM_DESTROYHERO = 20020;
        // Ӣ������
        public const int SM_DESTROYHERO = 20021;
        // Ӣ������
        public const int ET_PROTECTION_STRUCK = 20022;
        // �����ܹ���  20080108
        public const int ET_PROTECTION_PIP = 20023;
        // ���屻��
        public const int SM_MYSHOW = 20024;
        // ��ʾ������
        public const int RM_MYSHOW = 20025;
        public const int RM_OPENBOXS = 20026;
        // �򿪱��� 20080115
        public const int SM_OPENBOXS = 5064;
        // �򿪱��� 20080115
        public const int CM_OPENBOXS = 20027;
        // �򿪱��� 20080115 �����
        public const int CM_MOVEBOXS = 20028;
        // ת������ 20080117
        public const int RM_MOVEBOXS = 20029;
        // ת������ 20080117
        public const int SM_MOVEBOXS = 20030;
        // ת������ 20080117
        public const int CM_GETBOXS = 20031;
        // �ͻ���ȡ�ñ�����Ʒ 20080118
        public const int SM_GETBOXS = 20032;
        public const int RM_GETBOXS = 20033;
        public const int SM_OPENBOOKS = 20034;
        // ������NPC 20080119
        public const int RM_OPENBOOKS = 20035;
        public const int RM_DRAGONPOINT = 20036;
        // ���ͻ�����ֵ 20080201
        public const int SM_DRAGONPOINT = 20037;
        public const int ET_OBJECTLEVELUP = 20038;
        // ��������������ʾ 20080222
        public const int RM_CHANGEATTATCKMODE = 20039;
        // �ı乥��ģʽ 20080228
        public const int SM_CHANGEATTATCKMODE = 20040;
        // �ı乥��ģʽ 20080228
        public const int CM_EXCHANGEGAMEGIRD = 20042;
        // ���̶һ����  20080302
        public const int SM_EXCHANGEGAMEGIRD_FAIL = 20043;
        // ���̹�����Ʒʧ��
        public const int SM_EXCHANGEGAMEGIRD_SUCCESS = 20044;
        public const int RM_EXCHANGEGAMEGIRD_FAIL = 20045;
        public const int RM_EXCHANGEGAMEGIRD_SUCCESS = 20046;
        public const int RM_OPENDRAGONBOXS = 20047;
        // ���������� 20080306
        public const int SM_OPENDRAGONBOXS = 20048;
        // ���������� 20080306
        // SM_OPENBOXS_OK = 20047; //�򿪱���ɹ� 20080306
        public const int RM_OPENBOXS_FAIL = 20049;
        // �򿪱���ʧ�� 20080306
        public const int SM_OPENBOXS_FAIL = 20050;
        // �򿪱���ʧ�� 20080306
        public const int RM_EXPTIMEITEMS = 20051;
        // ������ ����ʱ��ı���Ϣ 20080306
        public const int SM_EXPTIMEITEMS = 20052;
        // ������ ����ʱ��ı���Ϣ 20080306
        public const int ET_OBJECTBUTCHMON = 20053;
        // ������ʬ��õ���Ʒ��ʾ 20080325
        public const int ET_DRINKDECDRAGON = 20054;
        // �ȾƵ����ϻ�����ʾ����Ч�� 20090105
        // SM_CLOSEDRAGONPOINT = 20055;  //�ر���Ӱ���� 20080329
        // ---------------------------����ϵͳ------------------------------------------
        public const int RM_QUERYREFINEITEM = 20056;
        // �򿪴������
        public const int SM_QUERYREFINEITEM = 20057;
        // �򿪴������
        public const int CM_REFINEITEM = 20058;
        // �ͻ��˷��ʹ�����Ʒ 20080507
        public const int SM_UPDATERYREFINEITEM = 20059;
        // ���´�����Ʒ 20080507
        public const int CM_REPAIRFINEITEM = 20060;
        // �޲�����ʯ 20080507 20080507
        public const int SM_REPAIRFINEITEM_OK = 20061;
        // �޲�����ʯ�ɹ�  20080507
        public const int SM_REPAIRFINEITEM_FAIL = 20062;
        // �޲�����ʯʧ��  20080507
        // -----------------------------------------------------------------------------
        public const int RM_DAILY = 20063;
        // ���ս��� 20080511
        public const int SM_DAILY = 20064;
        // ���ս��� 20080511
        public const int RM_GLORY = 20065;
        // ���͵��ͻ��� ����ֵ 20080511
        public const int SM_GLORY = 20066;
        // ���͵��ͻ��� ����ֵ 20080511
        public const int RM_GETHEROINFO = 20067;
        public const int SM_GETHEROINFO = 20068;
        // ���Ӣ������
        public const int CM_SELGETHERO = 20069;
        // ȡ��Ӣ��
        public const int RM_SENDUSERPLAYDRINK = 20070;
        // ������ƶԻ��� 20080515
        public const int SM_SENDUSERPLAYDRINK = 20071;
        // ������ƶԻ��� 20080515
        public const int CM_USERPLAYDRINKITEM = 20072;
        // ��ƿ������Ʒ���͵�M2
        public const int SM_USERPLAYDRINK_OK = 20073;
        // ��Ƴɹ�  20080515
        public const int SM_USERPLAYDRINK_FAIL = 20074;
        // ���ʧ�� 20080515
        public const int RM_PLAYDRINKSAY = 20075;
        public const int SM_PLAYDRINKSAY = 20076;
        public const int CM_PlAYDRINKDLGSELECT = 20077;
        // ��Ʒѡ��,����
        public const int RM_OPENPLAYDRINK = 20078;
        // �򿪴���
        public const int SM_OPENPLAYDRINK = 20079;
        // �򿪴���
        public const int CM_PlAYDRINKGAME = 20080;
        // ���Ͳ�ȭ���� 20080517
        public const int RM_PlayDrinkToDrink = 20081;
        // ���͵��ͻ���˭Ӯ˭��
        public const int SM_PlayDrinkToDrink = 20082;
        public const int CM_DrinkUpdateValue = 20083;
        // ���ͺȾ�
        public const int RM_DrinkUpdateValue = 20084;
        // ���غȾ�
        public const int SM_DrinkUpdateValue = 20085;
        // ���غȾ�
        public const int RM_CLOSEDRINK = 20086;
        // �رն��ƣ���ƴ���
        public const int SM_CLOSEDRINK = 20087;
        // �رն��ƣ���ƴ���
        public const int CM_USERPLAYDRINK = 20088;
        // �ͻ��˷��������Ʒ
        public const int SM_USERPLAYDRINKITEM_OK = 20089;
        // �����Ʒ�ɹ�
        public const int SM_USERPLAYDRINKITEM_FAIL = 20090;
        // �����Ʒʧ��
        public const int RM_Browser = 20091;
        // ����ָ����վ
        public const int SM_Browser = 20092;
        public const int RM_PIXINGHIT = 20093;
        // ����նЧ�� 20080611
        public const int SM_PIXINGHIT = 20094;
        public const int RM_LEITINGHIT = 20095;
        // ����һ��Ч�� 20080611
        public const int SM_LEITINGHIT = 20096;
        public const int CM_CHECKNUM = 20097;
        // �����֤�� 20080612
        public const int SM_CHECKNUM_OK = 20098;
        public const int CM_CHANGECHECKNUM = 20099;
        public const int RM_AUTOGOTOXY = 20100;
        // �Զ�Ѱ·
        public const int SM_AUTOGOTOXY = 20101;
        // -----------------------���ϵͳ---------------------------------------------
        public const int RM_OPENMAKEWINE = 20102;
        // ����ƴ���
        public const int SM_OPENMAKEWINE = 20103;
        // ����ƴ���
        public const int CM_BEGINMAKEWINE = 20104;
        // ��ʼ���(���Ѳ���ȫ���ϴ���)
        public const int RM_MAKEWINE_OK = 20105;
        // ��Ƴɹ�
        public const int SM_MAKEWINE_OK = 20106;
        // ��Ƴɹ�
        public const int RM_MAKEWINE_FAIL = 20107;
        // ���ʧ��
        public const int SM_MAKEWINE_FAIL = 20108;
        // ���ʧ��
        public const int RM_NPCWALK = 20109;
        // ���NPC�߶�
        public const int SM_NPCWALK = 20110;
        // ���NPC�߶�
        public const int RM_MAGIC68SKILLEXP = 20111;
        // �������弼�ܾ���
        public const int SM_MAGIC68SKILLEXP = 20112;
        // �������弼�ܾ���
        // ------------------------��սϵͳ--------------------------------------------
        public const int SM_CHALLENGE_FAIL = 20113;
        // ��սʧ��
        public const int SM_CHALLENGEMENU = 20114;
        // ����ս��Ѻ��Ʒ����
        public const int CM_CHALLENGETRY = 20115;
        // ��ҵ���ս
        public const int CM_CHALLENGEADDITEM = 20116;
        // ��Ұ���Ʒ�ŵ���ս����
        public const int SM_CHALLENGEADDITEM_OK = 20117;
        // ������ӵ�Ѻ��Ʒ�ɹ�
        public const int SM_CHALLENGEADDITEM_FAIL = 20118;
        // ������ӵ�Ѻ��Ʒʧ��
        public const int SM_CHALLENGEREMOTEADDITEM = 20119;
        // �������ӵ�Ѻ����Ʒ��,���ͻ�����ʾ
        public const int CM_CHALLENGEDELITEM = 20120;
        // ��Ҵ���ս����ȡ����Ʒ
        public const int SM_CHALLENGEDELITEM_OK = 20121;
        // ���ɾ����Ѻ��Ʒ�ɹ�
        public const int SM_CHALLENGEDELITEM_FAIL = 20122;
        // ���ɾ����Ѻ��Ʒʧ��
        public const int SM_CHALLENGEREMOTEDELITEM = 20123;
        // ����ɾ����Ѻ����Ʒ��,���ͻ�����ʾ
        public const int CM_CHALLENGECANCEL = 20124;
        // ���ȡ����ս
        public const int SM_CHALLENGECANCEL = 20125;
        // ���ȡ����ս
        public const int CM_CHALLENGECHGGOLD = 20126;
        // �ͻ��˰ѽ�ҷŵ���ս����
        public const int SM_CHALLENCHGGOLD_FAIL = 20127;
        // �ͻ��˰ѽ�ҷŵ���ս����ʧ��
        public const int SM_CHALLENCHGGOLD_OK = 20128;
        // �ͻ��˰ѽ�ҷŵ���ս���гɹ�
        public const int SM_CHALLENREMOTECHGGOLD = 20129;
        // �ͻ��˰ѽ�ҷŵ���ս����,���ͻ�����ʾ
        public const int CM_CHALLENGECHGDIAMOND = 20130;
        // �ͻ��˰ѽ��ʯ�ŵ���ս����
        public const int SM_CHALLENCHGDIAMOND_FAIL = 20131;
        // �ͻ��˰ѽ��ʯ�ŵ���ս����ʧ��
        public const int SM_CHALLENCHGDIAMOND_OK = 20132;
        // �ͻ��˰ѽ��ʯ�ŵ���ս���гɹ�
        public const int SM_CHALLENREMOTECHGDIAMOND = 20133;
        // �ͻ��˰ѽ��ʯ�ŵ���ս����,���ͻ�����ʾ
        public const int CM_CHALLENGEEND = 20134;
        // ��ս��Ѻ��Ʒ����
        public const int SM_CLOSECHALLENGE = 20135;
        // �ر���ս��Ѻ��Ʒ����
        // ----------------------------------------------------------------------------
        public const int RM_PLAYMAKEWINEABILITY = 20136;
        // ��2������� 20080804
        public const int SM_PLAYMAKEWINEABILITY = 20137;
        // ��2������� 20080804
        public const int RM_HEROMAKEWINEABILITY = 20138;
        // ��2������� 20080804
        public const int SM_HEROMAKEWINEABILITY = 20139;
        // ��2������� 20080804
        public const int RM_CANEXPLORATION = 20140;
        // ��̽�� 20080810
        public const int SM_CANEXPLORATION = 20141;
        // ��̽�� 20080810
        // ----------------------------------------------------------------------------
        public const int SM_SENDLOGINKEY = 20142;
        // ���ظ��ͻ��˻��½�����͵�½������� 20080901
        public const int SM_GATEPASS_FAIL = 20143;
        // �����ص��������
        public const int RM_HEROMAGIC68SKILLEXP = 20144;
        // Ӣ�۾������弼�ܾ���  20080925
        public const int SM_HEROMAGIC68SKILLEXP = 20145;
        // Ӣ�۾������弼�ܾ���  20080925
        public const int RM_USERBIGSTORAGEITEM = 20146;
        // �û����޲ֿ���Ŀ
        public const int RM_USERBIGGETBACKITEM = 20147;
        // �û���ûص����޲ֿ���Ŀ
        public const int RM_USERLEVELORDER = 20148;
        // �û��ȼ�����
        public const int RM_HEROAUTOOPENDEFENCE = 20149;
        // Ӣ���ڹ��Զ��������� 20080930
        public const int SM_HEROAUTOOPENDEFENCE = 20150;
        // Ӣ���ڹ��Զ��������� 20080930
        public const int CM_HEROAUTOOPENDEFENCE = 20151;
        // Ӣ���ڹ��Զ��������� 20080930
        public const int RM_MAGIC69SKILLEXP = 20152;
        // �ڹ��ķ�����
        public const int SM_MAGIC69SKILLEXP = 20153;
        // �ڹ��ķ�����
        public const int RM_HEROMAGIC69SKILLEXP = 20154;
        // Ӣ���ڹ��ķ�����  20080930
        public const int SM_HEROMAGIC69SKILLEXP = 20155;
        // Ӣ���ڹ��ķ�����  20080930
        public const int RM_MAGIC69SKILLNH = 20156;
        // ����ֵ(����) 20081002
        public const int SM_MAGIC69SKILLNH = 20157;
        // ����ֵ(����) 20081002
        public const int RM_WINNHEXP = 20158;
        // ȡ���ڹ����� 20081007
        public const int SM_WINNHEXP = 20159;
        // ȡ���ڹ����� 20081007
        public const int RM_HEROWINNHEXP = 20160;
        // Ӣ��ȡ���ڹ����� 20081007
        public const int SM_HEROWINNHEXP = 20161;
        // Ӣ��ȡ���ڹ����� 20081007
        public const int SM_SHOWSIGHICON = 20162;
        // ��ʾ��̾��ͼ�� 20090126
        public const int RM_HIDESIGHICON = 20163;
        // ���ظ�̾��ͼ�� 20090126
        public const int SM_HIDESIGHICON = 20164;
        // ���ظ�̾��ͼ�� 20090126
        public const int CM_CLICKSIGHICON = 20165;
        // �����̾��ͼ�� 20090126
        public const int SM_UPDATETIME = 20166;
        // ͳһ��ͻ��˵ĵ���ʱ 20090129
        public const int RM_OPENEXPCRYSTAL = 20167;
        // ��ʾ��ؽᾧͼ�� 20090201
        public const int SM_OPENEXPCRYSTAL = 20168;
        // ��ʾ��ؽᾧͼ�� 20090201
        public const int SM_SENDCRYSTALNGEXP = 20169;
        // ������ؽᾧ���ڹ����� 20090201
        public const int SM_SENDCRYSTALEXP = 20170;
        // ������ؽᾧ���ڹ����� 20090201
        public const int SM_SENDCRYSTALLEVEL = 20171;
        // ������ؽᾧ�ĵȼ� 20090202
        public const int CM_CLICKCRYSTALEXPTOP = 20172;
        // �����ؽᾧ��þ��� 20090202
        public const int SM_ZHUIXIN_OK = 20172;
        // ׷�Ĵ�
        // //////////////////////////////////////////////////////////////////////////////
        public const int UNITX = 48;
        public const int UNITY = 32;
        public const int HALFX = 24;
        public const int HALFY = 16;
        // MAXBAGITEM = 46; //�û������������
        // MAXMAGIC = 30{20}; //ԭ��54; 200081227 ע��
        public const int MAXSTORAGEITEM = 50;
        public const int LOGICALMAPUNIT = 40;
    }


    // [ҩƷ] [����]      [�·�]    [ͷ��][����]     [����]      [��ָ] [����] [Ь��] [��ʯ]         [������][��ҩ]        [����Ʒ][����]
    public class TShowItem
    {
        public string sItemName;
        public bool boAutoPickup;
        public bool boShowName;
    }

    public class TOSObject
    {
        public byte btType;
        public object CellObj;
        public uint dwAddTime;
        public bool boObjectDisPose;
    }

    public class TLoadDoubleHero
    {
        public string sAccount;
        public string sChrName;
        public string sUserAddr;
        public byte btJob;
        public int nSessionID;
    }

    public struct TShortMessage
    {
        public ushort Ident;
        public ushort wMsg;
    } 

    public struct TQuestInfo
    {
        public ushort wFlag;
        public byte btValue;
        public int nRandRage;
    }

    /// <summary>
    /// С��ͼ������Ϣ
    /// </summary>
    public class TMinMapInfo
    {
        public int nIdx;
        public string sMapNO;
    }

    public class TScript
    {
        public bool boQuest;
        public TQuestInfo[] QuestInfo;
        public int nQuest;
        public IList<TSayingRecord> RecordList;
    }

    public class TItemName
    {
        public int nItemIndex;
        public int nMakeIndex;
        public string sItemName;
    }

    public class TIPAddr
    {
        public string dIPaddr;
        public string sIPaddr;
    }

    public class TSrvNetInfo
    {
        public string[] sIPaddr;
        public int nPort;
    }

    /// <summary>
    /// С��ͼ�ṹ
    /// </summary>
    public class TMinMap
    {
        public string sName;
        public int nID;
    }



    public class TQuestDiaryInfo
    {
        public ArrayList QDDinfoList;
    }

    /// <summary>
    /// ����Ա��
    /// </summary>
    public class TAdminInfo
    {
        public int nLv;
        public string sChrName;
        public string sIPaddr;
    } 

    /// <summary>
    /// ͽ����������
    /// </summary>
    public class TMasterList
    {
        // ����   
        public int ID;
        public string sChrName;
    }

    public class TVisibleMapEvent
    {
        public TEvent MapEvent;
        public int nVisibleFlag;
        public int nX;
        public int nY;
    }

    public class TVisibleBaseObject
    {
        public TBaseObject BaseObject;
        public int nVisibleFlag;
    }

    public class TObjectFeature
    {
        public byte btGender;
        public byte btWear;
        public byte btHair;
        public byte btWeapon;
    }
   
    public class TSellOffHeader
    {
        public int nItemCount;
    }


    public struct TStormsRate
    {
        public int nStormsRate;
        public int nMagicID;
    }

    public class TIdxRecord
    {
        public string[] sChrName;
        public int nIndex;
    }

    public class TGoldChangeInfo
    {
        public string sGameMasterName;
        public string sGetGoldUser;
        public int nGold;
    }

    public class TGateInfo
    {
        public TGateInfo()
        {
            this.Socket = null;
            this.boUsed = false;
            this.sAddr = string.Empty;
            this.n520 = -1;
            this.UserList = null;
            this.nUserCount = -1;
            //this.Buffer = IntPtr.Zero ;
            this.nBuffLen = -1;
            this.BufferList = null;
            this.boSendKeepAlive = false;
            this.nSendChecked = -1;
            this.nSendBlockCount = -1;
            this.dwTime544 = 0;
            this.nSendMsgCount = -1;
            this.nSendRemainCount = -1;
            this.dwSendTick = 0;
            this.nSendMsgBytes = 0;
            this.nSendedMsgCount = 0;
            this.nSendCount = 0;
            this.dwSendCheckTick = 0;
        }

        public Socket Socket;
        public bool boUsed;
        public string sAddr;
        public int nPort;
        public int n520;
        public IList<TGateUserInfo> UserList;
        public int nUserCount;// ��������
        public IntPtr Buffer;
        public int nBuffLen;
        public IList<IntPtr> BufferList;
        public bool boSendKeepAlive;
        public int nSendChecked;
        public int nSendBlockCount;
        public uint dwTime544;
        public int nSendMsgCount;
        public int nSendRemainCount;
        public uint dwSendTick;
        public int nSendMsgBytes;
        public int nSendBytesCount;
        public int nSendedMsgCount;
        public int nSendCount;
        public uint dwSendCheckTick;

        public static void InitGateList(ref TGateInfo[] g_GateArr)
        {
            for (int i = 0; i < g_GateArr.Length; i++)
            {
                g_GateArr[i] = new TGateInfo();
            }
        }
    }

    public class TItemEvent
    {
        public string m_sItemName;
        public int m_nMakeIndex;
        public string m_sMapName;
        public int m_nCurrX;
        public int m_nCurrY;
    }

    public class TRecordDeletedHeader
    {
        public bool boDeleted;
        public byte bt1;
        public byte bt2;
        public byte bt3;
        public DateTime CreateDate;
        public DateTime LastLoginDate;
        public int n14;
        public int nNextDeletedIdx;
    }


    public class TUserLevelSort
    {
        // ����ȼ�����
        public int nIndex;
        public ushort wLevel;
        public string[] sChrName;
    } 

    public class THeroLevelSort
    {
        // Ӣ�۵ȼ�����
        public int nIndex;
        public ushort wLevel;
        public string sChrName;
        public string sHeroName;
    } 

    public class TUserMasterSort
    {
        // ͽ����������
        public int nIndex;
        public int nMasterCount;
        public string sChrName;
    } 

    public class TFilterMsg
    {
        // ��Ϣ����
        public string sFilterMsg;
        public string sNewMsg;
    } // end TFilterMsg

    // ��·��ʯ
    public class TagMapInfo
    {
        
        public string TagMapName;
        public int TagX;
        public int TagY;
    } 
}


