using GameFramework;
using GameFramework.Enum;
using M2Server.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace M2Server
{
    public class TBaseObject : GameBase
    {
        /// <summary>
        /// ��Ϸ��������
        /// </summary>
        public TObjType m_ObjType;
        /// <summary>
        /// ��ͼ����
        /// </summary>
        public string m_sMapName;
        /// <summary>
        /// ��������
        /// </summary>
        public string m_sCharName;
        /// <summary>
        /// ����������X(4�ֽ�)
        /// </summary>
        public int m_nCurrX = 0;
        /// <summary>
        /// ������������Y(4�ֽ�)
        /// </summary>
        public int m_nCurrY = 0;
        /// <summary>
        /// �������ڷ���(1�ֽ�)
        /// </summary>
        public byte m_btDirection = 0;
        /// <summary>
        /// ������Ա�(1�ֽ�)
        /// 0 �� 1Ů
        /// </summary>
        public byte m_btGender = 0;
        /// <summary>
        /// �����ͷ��(1�ֽ�)
        /// </summary>
        public byte m_btHair = 0;
        /// <summary>
        /// �����ְҵ 0-ս 1-�� 2-��
        /// </summary>
        public byte m_btJob = 0;
        /// <summary>
        /// ��������
        /// </summary>
        public int m_nGold = 0;
        /// <summary>
        /// �����������
        /// </summary>
        public TAbility m_Abil;
        /// <summary>
        /// ����״̬
        /// </summary>
        public int m_nCharStatus = 0;
        /// <summary>
        /// �سǵ�ͼ
        /// </summary>
        public string m_sHomeMap;
        /// <summary>
        /// �س�����X
        /// </summary>
        public int m_nHomeX = 0;
        /// <summary>
        /// �س�����Y
        /// </summary>
        public int m_nHomeY = 0;
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool m_boOnHorse = false;
        /// <summary>
        /// �������
        /// </summary>
        public byte m_btHorseType = 0;
        /// <summary>
        /// ��װЧ��
        /// </summary>
        public byte m_btDressEffType = 0;
        public uint m_BatterUseTick = 0;
        /// <summary>
        /// �����PKֵ
        /// </summary>
        public int m_nPkPoint = 0;
        public byte btB2 = 0;
        public TBatterZhuiXinMessage m_nBatterZhuiXin;
        /// <summary>
        /// ���ӽ���ֵ
        /// </summary>
        public int m_nIncHealth = 0;
        /// <summary>
        /// ���ӹ���ֵ
        /// </summary>
        public int m_nIncSpell = 0;
        /// <summary>
        /// ��������ֵ
        /// </summary>
        public int m_nIncHealing = 0;
        /// <summary>
        /// ���л�ս����ͼ����������
        /// </summary>
        public int m_nFightZoneDieCount = 0;
        /// <summary>
        /// ������������
        /// </summary>
        public TNakedAbility m_BonusAbil;
        /// <summary>
        /// �����
        /// </summary>
        public int m_nBonusPoint = 0;
        /// <summary>
        /// ���˶�
        /// </summary>
        public double m_dBodyLuck = 0;
        /// <summary>
        /// ���˶ȵȼ�
        /// </summary>
        public int m_nBodyLuckLevel = 0;
        /// <summary>
        /// �ű�����
        /// </summary>
        public byte[] m_QuestFlag = new byte[128];
        public int m_nCharStatusEx = 0;
        /// <summary>
        /// ���ﾭ��ֵ
        /// </summary>
        public UInt32 m_dwFightExp = 0;
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public TAbility m_WAbil;
        /// <summary>
        /// ���ӵ�����
        /// </summary>
        public TAddAbility m_AddAbil;
        /// <summary>
        /// ���ӷ�Χ��С
        /// </summary>
        public int m_nViewRange = 0;
        /// <summary>
        /// ����״̬����ֵ��һ���ǳ���������
        /// </summary>
        public ushort[] m_wStatusTimeArr = new ushort[12];
        /// <summary>
        /// ����״̬�����Ŀ�ʼʱ��
        /// </summary>
        public uint[] m_dwStatusArrTick = new uint[12];
        /// <summary>
        /// ����������  2-�޼����� 4-��������
        /// </summary>
        public ushort[] m_wStatusArrValue = new ushort[12];
        /// <summary>
        /// ������  2-�޼�����ʱ��  4-����������
        /// </summary>
        public uint[] m_dwStatusArrTimeOutTick = new uint[12];
        /// <summary>
        /// �������
        /// </summary>
        public ushort m_wAppr = 0;
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public byte m_btRaceServer = 0;
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public byte m_btRaceImg = 0;
        /// <summary>
        /// ���﹥��׼ȷ��
        /// </summary>
        public byte m_btHitPoint = 0;
        /// <summary>
        /// ��ӹ����˺�(��ɱ)
        /// </summary>
        public sbyte m_nHitPlus = 0;
        /// <summary>
        /// ˫�������˺�
        /// </summary>
        public sbyte m_nHitDouble = 0;
        /// <summary>
        /// ����ʹ�ü��
        /// </summary>
        public uint m_dwGroupRcallTick = 0;
        /// <summary>
        /// ����ȫ��
        /// </summary>
        public bool m_boRecallSuite = false;
        public bool bo245 = false;
        /// <summary>
        /// �����ָ�
        /// </summary>
        public sbyte m_nHealthRecover = 0;
        /// <summary>
        /// ħ���ָ�
        /// </summary>
        public sbyte m_nSpellRecover = 0;
        /// <summary>
        /// �ж����
        /// </summary>
        public byte m_btAntiPoison = 0;
        /// <summary>
        /// �ж��ָ�
        /// </summary>
        public sbyte m_nPoisonRecover = 0;
        /// <summary>
        /// ħ�����
        /// </summary>
        public sbyte m_nAntiMagic = 0;
        /// <summary>
        /// ���������ֵLuck (���ʻ���)
        /// </summary>
        public int m_nLuck = 0;
        /// <summary>
        /// ÿ������Ѫ�ĵ���
        /// </summary>
        public int m_nPerHealth = 0;
        /// <summary>
        /// ÿ������Ѫ�ĵ���(��ʿ��������)
        /// </summary>
        public int m_nPerHealing = 0;
        /// <summary>
        /// ÿ�����ӵ�ħ������
        /// </summary>
        public int m_nPerSpell = 0;
        /// <summary>
        /// ���ӹ����ļ��
        /// </summary>
        public uint m_dwIncHealthSpellTick = 0;
        /// <summary>
        /// ���̶���HP����
        /// </summary>
        public byte m_btGreenPoisoningPoint = 0;
        /// <summary>
        /// �����������ɴ������
        /// </summary>
        public int m_nGoldMax = 0;
        /// <summary>
        /// �������ݶ�
        /// </summary>
        public byte m_btSpeedPoint = 0;
        /// <summary>
        /// ����Ȩ�޵ȼ�
        /// </summary>
        public byte m_btPermission = 0;
        /// <summary>
        /// �����ٶ�
        /// </summary>
        public sbyte m_nHitSpeed = 0;
        /// <summary>
        /// ����ϵ,1-Ϊ����ϵ
        /// </summary>
        public byte m_btLifeAttrib = 0;
        /// <summary>
        /// ����Կ�����������(���߷�Χ)
        /// </summary>
        public ushort m_btCoolEye = 0;
        /// <summary>
        /// �Ƿ��ٻ�(����)
        /// </summary>
        public TBaseObject m_Master = null;
        /// <summary>
        /// �����ѱ�ʱ��
        /// </summary>
        public uint m_dwMasterRoyaltyTick = 0;
        /// <summary>
        /// �����ѱ��ʱ
        /// </summary>
        public uint m_dwMasterRoyaltyTime = 0;
        public uint m_dwMasterTick = 0;
        /// <summary>
        /// ����ɱ�ּ���,���ڱ���������
        /// </summary>
        public int n294 = 0;
        /// <summary>
        /// �����ȼ� 1-7
        /// </summary>
        public byte m_btSlaveExpLevel = 0;
        /// <summary>
        /// �ٻ��ȼ�
        /// </summary>
        public byte m_btSlaveMakeLevel = 0;
        /// <summary>
        /// �����б�
        /// </summary>
        public List<TBaseObject> m_SlaveList = null;
        /// <summary>
        /// ��������״̬(��Ϣ/����)
        /// </summary>
        public bool m_boSlaveRelax = false;
        /// <summary>
        /// ��������״̬
        /// </summary>
        public byte m_btAttatckMode = 0;
        /// <summary>
        /// ���ֵ���ɫ
        /// </summary>
        public byte m_btNameColor = 0;
        /// <summary>
        /// ����
        /// </summary>
        public int m_nLight = 0;
        /// <summary>
        /// �л�ռ����Χ
        /// </summary>
        public bool m_boGuildWarArea = false;
        /// <summary>
        /// �����Ǳ�
        /// </summary>
        public TUserCastle m_Castle = null;
        // �Ǳ���Ա
        public bool bo2B0 = false;
        public uint m_dw2B4Tick = 0;
        /// <summary>
        /// �޵�ģʽ
        /// </summary>
        public bool m_boSuperMan = false;
        public bool bo2B9 = false;
        /// <summary>
        /// �������ǽ
        /// </summary>
        public bool bo2BA = false;
        /// <summary>
        /// �Ƿ��Ƕ���
        /// </summary>
        public bool m_boAnimal = false;
        /// <summary>
        /// ���������Ƿ񲻵���Ʒ
        /// </summary>
        public bool m_boNoItem = false;
        /// <summary>
        /// ����ģʽ
        /// </summary>
        public bool m_boFixedHideMode = false;
        /// <summary>
        /// ���ܳ�ײģʽ(�����˲���ʹ��Ұ����ײ���ܹ���)
        /// </summary>
        public bool m_boStickMode = false;
        // �����Ƿ���������ٶ�,�ȼ�С��50�Ĺ� F-���� T-������
        public bool bo2BF = false;
        /// <summary>
        /// �ǹ���ģʽ
        /// </summary>
        public bool m_boNoAttackMode = false;
        public bool bo2C1 = false;
        /// <summary>
        /// ���ڱ���ʬ��
        /// </summary>
        public bool m_boButchSkeleton = false;
        /// <summary>
        /// ʬ��
        /// </summary>
        public bool m_boSkeleton = false;
        /// <summary>
        /// ���⣬���Ʒ��
        /// </summary>
        public int m_nMeatQuality = 0;
        /// <summary>
        /// ���������
        /// </summary>
        public int m_nBodyLeathery = 0;
        /// <summary>
        /// �����߶�ģʽ
        /// </summary>
        public bool m_boHolySeize = false;
        /// <summary>
        /// �����߶����
        /// </summary>
        public uint m_dwHolySeizeTick = 0;
        /// <summary>
        /// �����߶�ʱ��
        /// </summary>
        public uint m_dwHolySeizeInterval = 0;
        /// <summary>
        /// ��ģʽ(����)
        /// </summary>
        public bool m_boCrazyMode = false;
        /// <summary>
        /// ��ģʽ���
        /// </summary>
        public uint m_dwCrazyModeTick = 0;
        /// <summary>
        /// ��ģʽʱ��
        /// </summary>
        public uint m_dwCrazyModeInterval = 0;
        /// <summary>
        /// ������ʾ
        /// </summary>
        public bool m_boShowHP = false;
        /// <summary>
        /// ������ʾ���ʱ��
        /// </summary>
        public uint m_dwShowHPTick = 0;
        /// <summary>
        /// ������ʾ��Чʱ��
        /// </summary>
        public uint m_dwShowHPInterval = 0;
        public bool bo2F0 = false;
        public uint m_dwDupObjTick = 0;
        /// <summary>
        /// ���ڵ�ͼ����
        /// </summary>
        public TEnvirnoment m_PEnvir = null;
        /// <summary>
        /// ʬ���Ƿ����
        /// </summary>
        public bool m_boGhost = false;
        /// <summary>
        /// ʬ��������
        /// </summary>
        public uint m_dwGhostTick = 0;
        /// <summary>
        /// �����Ƿ�����
        /// </summary>
        public bool m_boDeath = false;
        /// <summary>
        /// �������
        /// </summary>
        public uint m_dwDeathTick = 0;
        /// <summary>
        /// �������õ�����
        /// </summary>
        public byte m_btMonsterWeapon = 0;
        // �������
        public uint m_dwStruckTick = 0;
        /// <summary>
        /// ˢ����Ϣ
        /// </summary>
        public bool m_boWantRefMsg = false;
        /// <summary>
        /// ���ӵ���ͼ�Ƿ�ɹ�
        /// </summary>
        public bool m_boAddtoMapSuccess = false;
        // 0x316
        public bool m_bo316 = false;
        /// <summary>
        /// �ҵ��л�
        /// </summary>
        public TGUild m_MyGuild = null;
        /// <summary>
        /// �л�����
        /// </summary>
        public int m_nGuildRankNo = 0;
        /// <summary>
        /// �л���
        /// </summary>
        public string m_sGuildRankName = String.Empty;
        // ��ɱ���
        public byte m_btAttackSkillCount = 0;
        // ��ɱ����
        public byte m_btAttackSkillPointCount = 0;
        /// <summary>
        /// �������е㼯��
        /// </summary>
        public bool m_boMission = false;
        /// <summary>
        /// ���е�����X
        /// </summary>
        public int m_nMissionX = 0;
        /// <summary>
        /// ���е�����Y
        /// </summary>
        public int m_nMissionY = 0;
        /// <summary>
        /// ����ģʽ�������ָ��
        /// </summary>
        public bool m_boHideMode = false;
        /// <summary>
        /// ʯ��
        /// </summary>
        public bool m_boStoneMode = false;
        /// <summary>
        /// �Ƿ���Կ�����������(���߷�Χ)
        /// </summary>
        public bool m_boCoolEye = false;
        // �Ƿ�������ˮ
        public bool m_boUserUnLockDurg = false;
        // ħ��������
        public bool m_boTransparent = false;
        // ����ģʽ
        public bool m_boAdminMode = false;
        // ����ģʽ
        public bool m_boObMode = false;
        // ���ͽ�ָ
        public bool m_boTeleport = false;
        // ��Խ�ָ
        public bool m_boParalysis = false;
        // �����
        public bool m_boUnParalysis = false;
        // �����ָ
        public bool m_boRevival = false;
        // ������
        public bool m_boUnRevival = false;
        // �����ָʹ�ü������
        public uint m_dwRevivalTick = 0;
        // �����ָ
        public bool m_boFlameRing = false;
        // �������ؼ���   ���콣
        public bool m_boYTPDRing = false;
        // Ѫ��һ��
        public bool m_boXPYJRing = false;
        // ���� ����     ���ǻ����ָ
        public bool m_boMeteorRing = false;
        // ������ָ
        public bool m_boRecoveryRing = false;
        // δ֪��ָ
        public bool m_boAngryRing = false;
        // �����ָ
        public bool m_boMagicShield = false;
        // ������
        public bool m_boUnMagicShield = false;
        // ������ָ
        public bool m_boMuscleRing = false;
        // ��������
        public bool m_boFastTrain = false;
        // ̽������
        public bool m_boProbeNecklace = false;
        // �лᴫ��
        public bool m_boGuildMove = false;
        // �޵�(δ��ȫ)��Ʒ
        public bool m_boSupermanItem = false;
        // ������
        public bool m_bopirit = false;
        // ����Ʒ
        public bool m_boNoDropItem = false;
        // �����ǲ��ǵ�װ��
        public bool m_boNoDropUseItem = false;
        // ������Ʒ
        public bool m_boExpItem = false;
        // ������Ʒֵ
        public double m_rExpItem = 0;
        // ������Ʒ(Ӱ����������Ʒ)
        public bool m_boPowerItem = false;
        // ������Ʒֵ
        public double m_rPowerItem = 0;
        // PK ���������飬��������͵��ȼ�
        public uint m_dwPKDieLostExp = 0;
        // PK �������ȼ�
        public int m_nPKDieLostLevel = 0;
        // ������ʾ
        public bool m_boAbilSeeHealGauge = false;
        // �Ƿ�ʹ��ħ����
        public bool m_boAbilMagBubbleDefence = false;
        // ħ���ܵȼ�
        public byte m_btMagBubbleDefenceLevel = 0;
        // �Ƿ�ʹ�û������
        public bool m_boProtectionDefence = false;
        // ������ܵȼ� 
        public byte m_boProtectionDefenceLevel = 0;
        // ʹ�û�����ܵĽ���ʱ�� 
        public uint m_boProtectionTick = 0;
        // ���л�λʹ�ü�� 
        public uint m_boMagChangXYTick = 0;
        /// <summary>
        /// ����Ŀ��ʱ��
        /// </summary>
        public uint m_dwSearchTime = 0;
        /// <summary>
        /// �������
        /// </summary>
        public uint m_dwSearchTick = 0;
        /// <summary>
        /// ���м��
        /// </summary>
        public uint m_dwRunTick = 0;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public int m_nRunTime = 0;
        /// <summary>
        /// �ر�ָ��Ϊ ��Ѫ���
        /// </summary>
        public int m_nHealthTick = 0;
        /// <summary>
        /// ��ħ���
        /// </summary>
        public int m_nSpellTick = 0;
        /// <summary>
        /// Ŀ��(�������Ѫ,�ȶ���)
        /// </summary>
        public TBaseObject m_TargetCret = null;
        // 0x37C
        public uint m_dwTargetFocusTick = 0;
        /// <summary>
        /// ���ﱻ�Է�ɱ��ʱ�Է�ָ��
        /// </summary>
        public TBaseObject m_LastHiter = null;
        // 0x384
        public uint m_LastHiterTick = 0;
        /// <summary>
        /// �����˺�ʱ�Է�ָ��
        /// </summary>
        public TBaseObject m_ExpHitter = null;
        // 0x38C
        public uint m_ExpHitterTick = 0;
        /// <summary>
        /// ���ͽ�ָʹ�ü��
        /// </summary>
        public uint m_dwTeleportTick = 0;
        /// <summary>
        /// ̽������ʹ�ü��
        /// </summary>
        public uint m_dwProbeTick = 0;
        /// <summary>
        /// ��ͼ����ʹ�ü��
        /// </summary>
        public uint m_dwMapMoveTick = 0;
        /// <summary>
        /// ���﹥����ɫ��־(��ɫ)
        /// </summary>
        public bool m_boPKFlag = false;
        // ���﹥����ɫʱ�䳤��(Dword)
        public uint m_dwPKTick = 0;
        /// <summary>
        /// ħѪһ��
        /// </summary>
        public int m_nMoXieSuite = 0;
        /// <summary>
        /// ��ħһ��
        /// </summary>
        public int m_nHongMoSuite = 0;
        /// <summary>
        /// ���ﾭ��
        /// </summary>
        public TBatterPulse[] m_HumPulses = new TBatterPulse[4];
        // 0x3B0
        public double m_db3B0 = 0;
        /// <summary>
        /// �ж�������ʱ��
        /// </summary>
        public uint m_dwPoisoningTick = 0;
        /// <summary>
        /// ��PKֵʱ��
        /// </summary>
        public uint m_dwDecPkPointTick = 0;
        /// <summary>
        /// ������Ʒʹ�ü��
        /// </summary>
        public uint m_DecLightItemDrugTick = 0;
        // 0x3C4
        public uint m_dwVerifyTick = 0;
        // 0x3C8
        public uint m_dwCheckRoyaltyTick = 0;
        // 0x3CC
        public uint m_dwDecHungerPointTick = 0;
        // 0x3D0
        public uint m_dwHPMPTick = 0;
        /// <summary>
        /// ��Ϣ�б�
        /// </summary>
        public IList<TSendMessage> m_MsgList = null;
        /// <summary>
        /// �ɼ��������б�
        /// </summary>
        public ArrayList m_VisibleHumanList = null;
        /// <summary>
        /// �ɼ�����Ʒ�б�
        /// </summary>
        public IList<TVisibleMapItem> m_VisibleItems = null;
        // 0x3E0
        public IList<TVisibleMapEvent> m_VisibleEvents = null;
        /// <summary>
        /// ����ˢ����Ϣ�ļ��
        /// </summary>
        public uint m_SendRefMsgTick = 0;
        /// <summary>
        /// �Ƿ��ڿ��л�ս
        /// </summary>
        public bool m_boInFreePKArea = false;
        /// <summary>
        /// �ܲ����
        /// </summary>
        public uint dwTick3F4 = 0;
        /// <summary>
        /// �������
        /// </summary>
        public uint m_dwHitTick = 0;
        /// <summary>
        /// ��·���
        /// </summary>
        public uint m_dwWalkTick = 0;
        public uint m_dwSearchEnemyTick = 0;
        /// <summary>
        /// ������ɫ�ı�
        /// </summary>
        public bool m_boNameColorChanged = false;
        /// <summary>
        /// �Ƿ��ڿ��ӷ�Χ��������,������
        /// </summary>
        public bool m_boIsVisibleActive = false;
        public sbyte m_nProcessRunCount = 0;
        /// <summary>
        /// �ɼ���ɫ�б�
        /// </summary>
        public IList<TVisibleBaseObject> m_VisibleActors = null;
        /// <summary>
        /// �����б�
        /// </summary>
        public IList<IntPtr> m_ItemList = null;
        /// <summary>
        /// ���ܱ�
        /// </summary>
        public IList<IntPtr> m_MagicList = null;
        /// <summary>
        /// װ������Ʒ
        /// </summary>
        public unsafe TUserItem*[] m_UseItems = new TUserItem*[14];
        public IList<TMonSayMsg> m_SayMsgList = null;
        /// <summary>
        /// ��·�ٶ�
        /// </summary>
        public int m_nWalkSpeed = 0;
        /// <summary>
        /// ���߲���
        /// </summary>
        public int m_nWalkStep = 0;
        // 0x504
        public int m_nWalkCount = 0;
        // 0x508
        public uint m_dwWalkWait = 0;
        // 0x50C
        public uint m_dwWalkWaitTick = 0;
        /// <summary>
        /// ���еȴ�����
        /// </summary>
        public bool m_boWalkWaitLocked = false;
        /// <summary>
        /// �¸�����ʱ��
        /// </summary>
        public uint m_nNextHitTime = 0;
        // ��������
        public unsafe TUserMagic* m_MagicOneSwordSkill = null;
        // ��ɱ
        public unsafe TUserMagic* m_MagicPowerHitSkill = null;
        // ��ɱ����
        public unsafe TUserMagic* m_MagicErgumSkill = null;
        // �����䵶
        public unsafe TUserMagic* m_MagicBanwolSkill = null;
        // �һ𽣷�
        public unsafe TUserMagic* m_MagicFireSwordSkill = null;
        // �����䵶
        public unsafe TUserMagic* m_MagicCrsSkill = null;
        // ʨ�Ӻ�
        public unsafe TUserMagic* m_Magic41Skill = null;
        // ����ն
        public unsafe TUserMagic* m_Magic42Skill = null;
        // ��Ӱ����
        public unsafe TUserMagic* m_Magic43Skill = null;
        // �ƻ�ն
        public unsafe TUserMagic* m_Magic60Skill = null;
        // ����Ԫ��
        public unsafe TUserMagic* m_Magic67Skill = null;
        // �������� 
        public unsafe TUserMagic* m_Magic68Skill = null;
        // ���ս��� 
        public unsafe TUserMagic* m_Magic74Skill = null;
        // ������� 
        public unsafe TUserMagic* m_Magic75Skill = null;
        // ����ɱ    սʿ
        public unsafe TUserMagic* m_MagicSkill_76 = null;
        // ˫����    ��ʦ
        public unsafe TUserMagic* m_MagicSkill_77 = null;
        // ��Х��    ��ʿ
        public unsafe TUserMagic* m_MagicSkill_78 = null;
        // ׷�Ĵ�    սʿ
        public unsafe TUserMagic* m_MagicSkill_79 = null;
        // �����    ��ʦ
        public unsafe TUserMagic* m_MagicSkill_80 = null;
        // ������    ��ʿ
        public unsafe TUserMagic* m_MagicSkill_81 = null;
        // ����ն    սʿ
        public unsafe TUserMagic* m_MagicSkill_82 = null;
        // ���ױ�    ��ʦ
        public unsafe TUserMagic* m_MagicSkill_83 = null;
        // ������    ��ʿ
        public unsafe TUserMagic* m_MagicSkill_84 = null;
        // ��ɨǧ��  սʿ
        public unsafe TUserMagic* m_MagicSkill_85 = null;
        // ����ѩ��  ��ʦ
        public unsafe TUserMagic* m_MagicSkill_86 = null;
        // �򽣹���  ��ʿ
        public unsafe TUserMagic* m_MagicSkill_87 = null;
        // ��������  ��ְҵ
        public unsafe TUserMagic* m_MagicSkill_69 = null;
        // Ѫ��һ��(ս)
        public unsafe TUserMagic* m_MagicSkill_96 = null;
        // �ļ���������
        public unsafe TUserMagic* m_MagicSkill_88 = null;
        // �ļ���ɱ
        public unsafe TUserMagic* m_MagicSkill_89 = null;
        // Բ���䵶
        public unsafe TUserMagic* m_MagicSkill_90 = null;
        // �ļ��׵�
        public unsafe TUserMagic* m_MagicSkill_91 = null;
        // �ļ����ǻ���
        public unsafe TUserMagic* m_MagicSkill_92 = null;
        // �ļ�ʩ����
        public unsafe TUserMagic* m_MagicSkill_93 = null;
        // �ļ���Ѫ��
        public unsafe TUserMagic* m_MagicSkill_94 = null;
        // ��ɱ�Ƿ����
        public bool m_boPowerHit = false;
        // ��ɱ�����Ƿ����
        public bool m_boUseThrusting = false;
        // �����䵶�Ƿ����
        public bool m_boUseHalfMoon = false;
        // �һ𽣷��Ƿ����
        public bool m_boFireHitSkill = false;
        // ���ս����Ƿ����
        public bool m_boDailySkill = false;
        // �����䵶�Ƿ����
        public bool m_boCrsHitkill = false;
        // ����ն�Ƿ����
        public bool m_bo42kill = false;
        // ����ն����� ��ʼΪ0,1��,2��
        public byte m_n42kill = 0;
        // ��Ӱ�����Ƿ����
        public bool m_bo43kill = false;
        // �ƻ�ն�Ƿ����
        public bool m_bo60kill = false;
        // �ļ���ɱ��������ʹ��
        public bool m_bo89Kill = false;
        // Բ���䵶�Ƿ����
        public bool m_bo90Kill = false;
        /// <summary>
        /// ����ʹ������
        /// </summary>
        public bool m_boUseBatter = false;
        /// <summary>
        /// ��ǰʹ�õ���������
        /// </summary>
        public int m_nBatter = 0;
        // ��������
        public UInt16[] m_nBatterOrder = new UInt16[3];
        // ��ʱ��������  ������� ��
        public UInt16[] bOrder = new UInt16[3];
        // �������ʱ�
        public TStormsRate[] m_HumStormsRate = new TStormsRate[5];
        // ��ͨ������Ҫ�ڹ��ȼ���
        public byte[] m_PulseNeedLev = new byte[20];
        // ������������ʹ�����
        public bool m_boBatterFinally = false;
        public int m_nBatterX = 0;
        public int m_nBatterY = 0;
        public byte m_nBatterDir = 0;
        // ʹ������ʱ���Ŀ��
        public TBaseObject m_nBatterTarget = null;
        // ��ǰʹ�������ļ���ID
        public int m_nCurrBatterMagicID = 0;
        // ����ʹ�õļ��
        public uint m_nBatterUseTick = 0;
        public uint m_nBatterSpellTick = 0;
        // ���������Ƿ����
        public bool m_boYTPDHitSkill = false;
        // Ѫ��һ���Ƿ����
        public bool m_boXPYJHitSkill = false;
        // �һ�ļ��
        public uint m_dwLatestFireHitTick = 0;
        // ���������ٻ����
        public uint m_dwLatestYTPDHitTick = 0;
        // Ѫ��һ��ʹ�ü��
        public uint m_dwLatestXPYJHittick = 0;
        // ������ʹ�ü��
        public uint m_dwLatestBatterHitTick = 0;
        // ���ս����ļ�� 
        public uint m_dwLatestDailyTick = 0;
        // ����ն�ļ�� 
        public uint m_dwLatest42Tick = 0;
        // ��Ӱ������� 
        public uint m_dwLatest43Tick = 0;
        // �������ļ�� 
        public uint m_dwLatest46Tick = 0;
        // �Ƿ�ˢ���ڵ�ͼ����Ϣ��
        public bool m_boDenyRefStatus = false;
        // �Ƿ����ӵ�ͼ����(������������) T-����Ҫ�ټ���,F-��Ҫ����
        public bool m_boAddToMaped = false;
        /// <summary>
        /// �Ƿ�ӵ�ͼ��ɾ������
        /// </summary>
        public bool m_boDelFormMaped = false;
        /// <summary>
        /// �Ƿ��Զ���ɫ
        /// </summary>
        public bool m_boAutoChangeColor = false;
        /// <summary>
        /// �Զ���ɫ���
        /// </summary>
        public uint m_dwAutoChangeColorTick = 0;
        /// <summary>
        /// �Զ��ı������
        /// </summary>
        public int m_nAutoChangeIdx = 0;
        /// <summary>
        /// ��ɫ������
        /// </summary>
        public int m_nChangeColorType = 0;
        /// <summary>
        /// �Ƿ��Զ���������ɫ
        /// </summary>
        public bool m_boSetNameColor = false;
        /// <summary>
        /// �Ƿ��Ѿ�������ʾ����ͼ��
        /// </summary>
        public bool m_boSendShowBatterIcon = false;
        /// <summary>
        /// �Ƿ����ʹ������(��û���������)
        /// </summary>
        public bool m_boCanUseBatter = false;
        /// <summary>
        /// �̶���ɫ
        /// </summary>
        public bool m_boFixColor = false;
        /// <summary>
        /// �̶���ɫ������
        /// </summary>
        public int m_nFixColorIdx = 0;
        public int m_nFixStatus = 0;
        /// <summary>
        /// ������ԣ��ܹ��������������ʧ
        /// </summary>
        public bool m_boFastParalysis = false;
        /// <summary>
        /// ��ɱװ�� ������װ������
        /// </summary>
        public bool m_DropUseItemPointer = false;
        /// <summary>
        /// ����ͨ�Žṹ
        /// </summary>
        public TDefaultMessage m_DefMsg;
        /// <summary>
        /// �����˱��ֵȼ�,��ʾ�����õ�
        /// </summary>
        public int m_nCopyHumanLevel = 0;
        /// <summary>
        /// ���Ӽ������վ������ʱ��
        /// </summary>
        public uint m_dwStationTick = 0;
        /// <summary>
        /// �˳�״̬ 1Ϊ����
        /// </summary>
        public byte m_btLastOutStatus = 0;
        /// <summary>
        /// �ۼƾ���,�ﵽһ��ֵ,����Ӣ�۵��ҳ϶�   ������ʹ��
        /// </summary>
        public UInt32 m_nWinExp = 0;
        /// <summary>
        /// ���ڲ��������б�
        /// </summary>
        public bool m_boOperationItemList = false;
        /// <summary>
        /// �ڹ���,����������������ֵ
        /// </summary>
        public bool m_boIsNGMonster = false;
        /// <summary>
        /// �Ƿ�����˶���
        /// </summary>
        public bool m_boRobotObject = false;

        public unsafe TBaseObject()
            : base()
        {
            m_ObjType = TObjType.t_Play;
            m_boSendShowBatterIcon = false;
            m_boCanUseBatter = false;
            m_boUseBatter = false;
            m_dwLatestBatterHitTick = HUtil32.GetTickCount();
            m_BatterUseTick = HUtil32.GetTickCount();
            m_nBatterOrder[0] = 0;
            m_nBatterOrder[1] = 0;
            m_nBatterOrder[2] = 0;
            m_boBatterFinally = false; // ������������ʹ�����
            m_nBatterX = 0;
            m_nBatterY = 0;
            m_nBatterDir = 0;
            m_nBatterTarget = null; // ʹ������ʱ���Ŀ��
            m_nCurrBatterMagicID = 0;
            m_nBatterUseTick = HUtil32.GetTickCount();// ����ʹ�õļ��
            m_nBatterSpellTick = HUtil32.GetTickCount();
            m_boGhost = false;
            m_dwGhostTick = 0;
            m_boDeath = false;
            m_dwDeathTick = 0;
            m_SendRefMsgTick = HUtil32.GetTickCount();
            m_btDirection = 4;
            m_btRaceServer = Grobal2.RC_ANIMAL;
            m_btRaceImg = 0;
            m_btHair = 0;
            m_btJob = 0;
            m_nGold = 0;
            m_wAppr = 0;
            bo2B9 = true;
            m_nViewRange = 5;
            m_sHomeMap = "0";
            m_btPermission = 0;
            m_nLight = 0;
            m_btNameColor = 255;
            m_nHitPlus = 0;
            m_nHitDouble = 0;
            m_dBodyLuck = 0;
            m_boRecallSuite = false;
            bo245 = false;
            bo2BA = false;
            m_boAbilSeeHealGauge = false;
            m_boPowerHit = false;
            m_boUseThrusting = false;
            m_boUseHalfMoon = false;
            m_boFireHitSkill = false;
            m_boYTPDHitSkill = false; // ���������Ƿ���� 
            m_boXPYJHitSkill = false; // Ѫ��һ���Ƿ���� 
            m_boDailySkill = false;// ���ս����Ƿ���� 
            m_bo42kill = false;// ����ն�Ƿ���� 
            m_bo43kill = false;// ��Ӱ�����Ƿ����  
            m_bo89Kill = false; // �ļ���ɱ
            m_bo90Kill = false;// Բ���䵶
            m_n42kill = 0;// ����ն�����ʼ�� 1--Ϊ�� 2--Ϊ��
            m_btHitPoint = 5;
            m_btSpeedPoint = 15;
            m_nHitSpeed = 0;
            m_btLifeAttrib = 0;
            m_btAntiPoison = 0;
            m_nPoisonRecover = 0;
            m_nHealthRecover = 0;
            m_nSpellRecover = 0;
            m_nAntiMagic = 0;
            m_nLuck = 0;
            m_nIncSpell = 0;
            m_nIncHealth = 0;
            m_nIncHealing = 0;
            m_nPerHealth = 5;
            m_nPerHealing = 5;
            m_nPerSpell = 5;
            m_dwIncHealthSpellTick = HUtil32.GetTickCount();
            m_btGreenPoisoningPoint = 0;
            m_nFightZoneDieCount = 0;
            m_nGoldMax = GameConfig.nHumanMaxGold;//����Я����Ϸ���������
            m_nCharStatus = 0;
            m_nCharStatusEx = 0;
            btB2 = 0;
            m_btAttatckMode = 0;
            m_boInFreePKArea = false;
            m_boGuildWarArea = false;
            bo2B0 = false;
            m_boSuperMan = false;
            m_boButchSkeleton = false; // ���ڱ���ʬ��
            m_boSkeleton = false;
            bo2BF = false;
            m_boHolySeize = false;
            m_boCrazyMode = false;
            m_boShowHP = false;
            bo2F0 = false;
            m_boAnimal = false;
            m_boNoItem = false;
            m_nBodyLeathery = 50;
            m_boFixedHideMode = false;
            m_boStickMode = false;
            m_boNoAttackMode = false;
            bo2C1 = false;
            m_boPKFlag = false;
            m_nMoXieSuite = 0;
            m_nHongMoSuite = 0;
            m_db3B0 = 0;
            m_AddAbil = new TAddAbility();
            m_MsgList = new List<TSendMessage>();
            m_VisibleHumanList = new ArrayList();
            m_VisibleActors = new List<TVisibleBaseObject>();
            m_VisibleItems = new List<TVisibleMapItem>();
            m_VisibleEvents = new List<TVisibleMapEvent>();
            m_ItemList = new List<IntPtr>();
            m_MagicList = new List<IntPtr>();
            m_boIsVisibleActive = false;
            m_nProcessRunCount = 0;
            m_Castle = null;
            m_Master = null;
            n294 = 0;
            m_btSlaveExpLevel = 0;
            m_boSetNameColor = false;// �Ƿ��Զ���������ɫ
            m_SlaveList = new List<TBaseObject>();
            #region ��ʼ��װ����װ��ָ������
            TUserItem* FirstItems = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem) * m_UseItems.Length);
            for (int i = 0; i < m_UseItems.Length; i++)
            {
                m_UseItems[i] = &FirstItems[i];
            }
            #endregion

            fixed (TAbility* WAbil = &m_WAbil)
            {
                HUtil32.ZeroMemory((IntPtr)WAbil, (IntPtr)sizeof(TAbility));
            }
            // FillChar(m_QuestUnitOpen, SizeOf(TQuestUnit), #0);
            // FillChar(m_QuestUnit, SizeOf(TQuestUnit), #0);
            m_Abil.Level = 1;
            m_Abil.AC = 0;
            m_Abil.MAC = 0;
            m_Abil.DC = HUtil32.MakeLong(1, 4);
            m_Abil.MC = HUtil32.MakeLong(1, 2);
            m_Abil.SC = HUtil32.MakeLong(1, 2);
            m_Abil.HP = 15;
            m_Abil.MP = 15;
            m_Abil.MaxHP = 15;
            m_Abil.MaxMP = 15;
            m_Abil.Exp = 0;
            m_Abil.MaxExp = 50;
            m_Abil.Weight = 0;
            m_Abil.MaxWeight = 100;
            m_boWantRefMsg = false;
            m_MyGuild = null;
            m_nGuildRankNo = 0;
            m_sGuildRankName = "";
            m_boMission = false;
            m_boHideMode = false;
            m_boStoneMode = false;
            m_boCoolEye = false;
            m_boUserUnLockDurg = false;
            m_boTransparent = false;
            m_boAdminMode = false;
            m_boObMode = false;
            m_dwRunTick = Convert.ToUInt32(HUtil32.GetTickCount() + ((uint)HUtil32.Random(1500)));
            m_nRunTime = 250;
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(2000) + 2000);
            m_dwSearchTick = HUtil32.GetTickCount();
            m_dwDecPkPointTick = HUtil32.GetTickCount();
            m_DecLightItemDrugTick = HUtil32.GetTickCount();
            m_dwPoisoningTick = HUtil32.GetTickCount();
            m_dwVerifyTick = HUtil32.GetTickCount();
            m_dwCheckRoyaltyTick = HUtil32.GetTickCount();
            m_dwDecHungerPointTick = HUtil32.GetTickCount();
            m_dwHPMPTick = HUtil32.GetTickCount();
            m_dwTeleportTick = 0;
            m_dwProbeTick = 0;
            m_dwMapMoveTick = HUtil32.GetTickCount();
            m_dwMasterTick = 0;
            m_nWalkSpeed = 1400;
            m_nNextHitTime = 2000;
            m_nWalkCount = 0;
            m_dwWalkWaitTick = HUtil32.GetTickCount();
            m_boWalkWaitLocked = false;
            m_nHealthTick = 0;
            m_nSpellTick = 0;
            m_TargetCret = null;
            m_LastHiter = null;
            m_ExpHitter = null;
            m_SayMsgList = null;
            m_boDenyRefStatus = false;
            m_btHorseType = 0;
            m_btDressEffType = 0;
            m_dwPKDieLostExp = 0;
            m_nPKDieLostLevel = 0;
            m_boAddToMaped = false;//ԭ��Ϊtrue ��ͼ�Ƿ����
            m_boAutoChangeColor = false;
            m_dwAutoChangeColorTick = HUtil32.GetTickCount();
            m_nAutoChangeIdx = 0;
            m_nChangeColorType = -1;// �Ƿ��ɫ
            m_boFixColor = false;
            m_nFixColorIdx = 0;
            m_nFixStatus = -1;
            m_boFastParalysis = false;
            m_nCopyHumanLevel = 0;// ������״̬
            m_dwStationTick = HUtil32.GetTickCount();// վ��ʱ��
            m_btLastOutStatus = 0;
            m_boProtectionDefence = false;// �Ƿ�ʹ�û������ 
            m_btMagBubbleDefenceLevel = 0;// ħ���ܵȼ� 
            m_boProtectionDefenceLevel = 0;// ������ܵȼ� 
            m_boOperationItemList = false;// ���ڲ��������б� 
            m_boIsNGMonster = false;// �ڹ���,����������������ֵ 
            m_boRobotObject = false;
        }

        unsafe ~TBaseObject()
        {
            int I;
            TSendMessage SendMessage;
            int nCheckCode;
            const string sExceptionMsg = "{�쳣} TBaseObject::Destroy Code: %d CharName: %s";
            nCheckCode = 0;
            try
            {
                nCheckCode = 1;
                if (m_MsgList != null)
                {
                    if (m_MsgList.Count > 0)
                    {
                        for (I = 0; I < m_MsgList.Count; I++)
                        {
                            nCheckCode = 2;
                            SendMessage = m_MsgList[I];
                            if (SendMessage != null)
                            {
                                if ((SendMessage.wIdent == Grobal2.RM_SENDDELITEMLIST) && (SendMessage.nParam1 != 0))
                                {
                                    nCheckCode = 3;
                                    if (SendMessage.nParam1 != 0)
                                    {
                                        Marshal.FreeHGlobal((IntPtr)SendMessage.nParam1);
                                        nCheckCode = 4;
                                    }
                                }
                                if ((SendMessage.wIdent == Grobal2.RM_10401) && (SendMessage.nParam1 != 0))
                                {
                                    nCheckCode = 5;
                                    Marshal.FreeHGlobal((IntPtr)SendMessage.nParam1);
                                }
                                nCheckCode = 6;
                                if (SendMessage.Buff != null && SendMessage.Buff.ToInt32() != 0)
                                {
                                    nCheckCode = 7;
                                    SendMessage.Buff = IntPtr.Zero;
                                }
                                SendMessage = null;
                                nCheckCode = 8;
                            }
                        }
                    }
                    nCheckCode = 9;
                    if (m_MsgList != null)
                    {
                        m_MsgList = null;
                    }
                }
                nCheckCode = 10;
                try
                {
                    if (m_VisibleHumanList != null)
                    {
                        m_VisibleHumanList = null;
                    }
                }
                catch
                {
                }
                nCheckCode = 120;
                if (m_VisibleActors != null)
                {
                    nCheckCode = 121;
                    if (m_VisibleActors.Count > 0)
                    {
                        nCheckCode = 122;
                        for (I = 0; I < m_VisibleActors.Count; I++)
                        {
                            try
                            {
                                if (m_VisibleActors[I] != null)
                                {
                                    Dispose(m_VisibleActors[I]);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    nCheckCode = 13;
                    try
                    {
                        if (m_VisibleActors != null)
                        {
                            m_VisibleActors = null;
                        }
                    }
                    catch
                    {
                    }
                }
                nCheckCode = 14;
                if (m_VisibleItems != null)
                {
                    if (m_VisibleItems.Count > 0)
                    {
                        for (I = 0; I < m_VisibleItems.Count; I++)
                        {
                            try
                            {
                                if (m_VisibleItems[I] != null)
                                {
                                    Dispose(m_VisibleItems[I]);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    nCheckCode = 15;
                    m_VisibleItems = null;
                }
                nCheckCode = 16;
                if (m_VisibleEvents != null)
                {
                    if (m_VisibleEvents.Count > 0)
                    {
                        nCheckCode = 17;
                        for (I = 0; I < m_VisibleEvents.Count; I++)
                        {
                            nCheckCode = 18;
                            try
                            {
                                if (m_VisibleEvents[I] != null)
                                {
                                    Dispose(m_VisibleEvents[I]);
                                }
                            }
                            finally { }
                        }
                    }
                    nCheckCode = 19;
                    m_VisibleEvents = null;
                }
                nCheckCode = 20;
                if (m_MagicList != null)
                {
                    if (m_MagicList.Count > 0)
                    {
                        for (I = 0; I < m_MagicList.Count; I++)
                        {
                            try
                            {
                                if (m_MagicList[I] != null)
                                {
                                    Dispose(m_MagicList[I]);
                                }
                            }
                            finally { }
                        }
                    }
                    m_MagicList = null;
                }
                nCheckCode = 21;
                if (m_SlaveList != null)
                {
                    m_SlaveList = null;
                }
                nCheckCode = 17;
                if (m_ItemList != null)
                {
                    m_boOperationItemList = true;// ��ֹͬʱ���������б�ʱ����
                    for (I = m_ItemList.Count - 1; I >= 0; I--)
                    {
                        if (m_ItemList.Count <= 0)
                        {
                            break;
                        }
                        nCheckCode = 24;
                        try
                        {
                            if (m_ItemList[I] != null)
                            {
                                Dispose(m_ItemList[I]);
                            }
                        }
                        catch
                        {
                            m_ItemList.RemoveAt(I);
                            M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode, m_sCharName));
                            if (m_ItemList.Count > 0)
                            {
                                continue;
                            }
                        }
                    }
                    nCheckCode = 18;
                    m_ItemList = null;
                    m_boOperationItemList = false;// ��ֹͬʱ���������б�ʱ����
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode, m_sCharName));
            }
        }

        /// <summary>
        /// �ı�PK״̬
        /// </summary>
        /// <param name="boWarFlag"></param>
        public void ChangePKStatus(bool boWarFlag)
        {
            if (m_boInFreePKArea != boWarFlag)
            {
                m_boInFreePKArea = boWarFlag;
                m_boNameColorChanged = true;
            }
        }

        /// <summary>
        /// ȡ�����λ��
        /// </summary>
        /// <param name="nOrgX"></param>
        /// <param name="nOrgY"></param>
        /// <param name="nRange"></param>
        /// <param name="nDX"></param>
        /// <param name="nDY"></param>
        /// <returns></returns>
        public bool GetDropPosition(int nOrgX, int nOrgY, int nRange, ref int nDX, ref int nDY)
        {
            bool result = false;
            int nItemCount = 0;
            int n24;
            int n28;
            int n2C;
            n24 = 999;
            n28 = 0;
            n2C = 0;
            for (int I = 1; I <= nRange; I++)
            {
                for (int k = -I; k <= I; k++)
                {
                    for (int j = -I; j <= I; j++)
                    {
                        nDX = nOrgX + j;
                        nDY = nOrgY + k;
                        if (m_PEnvir.GetItemEx(nDX, nDY, ref nItemCount) == null)
                        {
                            if (m_PEnvir.bo2C)
                            {
                                result = true;
                                break;
                            }
                        }
                        else
                        {
                            if (m_PEnvir.bo2C && (n24 > nItemCount))
                            {
                                n24 = nItemCount;
                                n28 = nDX;
                                n2C = nDY;
                            }
                        }
                    }
                    if (result)
                    {
                        break;
                    }
                }
                if (result)
                {
                    break;
                }
            }
            if (!result)
            {
                if (n24 < 8)
                {
                    nDX = n28;
                    nDY = n2C;
                }
                else
                {
                    nDX = nOrgX;
                    nDY = nOrgY;
                }
            }
            return result;
        }

        /// <summary>
        /// ��Ʒ����,��������Ʒ
        /// </summary>
        /// <param name="UserItem"></param>
        /// <param name="nScatterRange"></param>
        /// <param name="boDieDrop"></param>
        /// <param name="boCanHit"></param>
        /// <param name="ItemOfCreat"></param>
        /// <param name="DropCreat"></param>
        /// <returns></returns>
        public unsafe bool DropItemDown(TUserItem* UserItem, int nScatterRange, bool boDieDrop, bool boCanHit, TBaseObject ItemOfCreat, TBaseObject DropCreat)
        {
            bool result = false;
            int dx = 0;
            int dy = 0;
            int idura;
            TMapItem MapItem;
            TMapItem pr;
            TStdItem* StdItem;
            string logcap;
            string sUserItemName;
            byte nCode = 0;
            try
            {
                if (CheckItemValue(UserItem, 5))
                {
                    return result;
                }
                if (UserItem->btValue == null)
                {
                    return result;
                }
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem != null)
                {
                    if (CheckIsOKItem(UserItem, StdItem->StdMode))  // �����Ʒ���������Ƿ�����
                    {
                        return result;
                    }
                    if (StdItem->StdMode == 40)
                    {
                        idura = UserItem->Dura;
                        idura = idura - 2000;
                        if (idura < 0)
                        {
                            idura = 0;
                        }
                        UserItem->Dura = (ushort)idura;
                    }
                    MapItem = new TMapItem();
                    MapItem.UserItem = UserItem;
                    MapItem.Name = HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen);// ȡ�Զ�����Ʒ����
                    sUserItemName = "";
                    if (UserItem->btValue[13] == 1)
                    {
                        sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                        if (sUserItemName != "")
                        {
                            MapItem.Name = sUserItemName;
                        }
                    }
                    nCode = 7;
                    MapItem.Looks = StdItem->Looks;
                    if (StdItem->StdMode == 45)
                    {
                        MapItem.Looks = M2Share.GetRandomLook(MapItem.Looks, StdItem->Shape);
                    }
                    nCode = 8;
                    MapItem.AniCount = StdItem->AniCount;
                    MapItem.Reserved = 0;
                    MapItem.Count = 1;
                    MapItem.OfBaseObject = ItemOfCreat;
                    MapItem.dwCanPickUpTick = HUtil32.GetTickCount();
                    MapItem.DropBaseObject = DropCreat;
                    if (DropCreat.m_btRaceServer == 136)
                    {
                        nCode = 13;
                        GetDropPosition(DropCreat.m_LastHiter.m_nCurrX, DropCreat.m_LastHiter.m_nCurrY, nScatterRange, ref dx, ref dy);// ȡ�����λ��
                    }
                    else
                    {
                        nCode = 14;
                        GetDropPosition(m_nCurrX, m_nCurrY, nScatterRange, ref dx, ref dy);  // ȡ�����λ��
                    }
                    nCode = 20;
                    pr = (TMapItem)m_PEnvir.AddToMap(dx, dy, Grobal2.OS_ITEMOBJECT, MapItem);
                    nCode = 16;
                    if (pr == MapItem)
                    {
                        nCode = 17;
                        SendRefMsg(Grobal2.RM_ITEMSHOW, MapItem.Looks, 0, dx, dy, MapItem.Name);
                        nCode = 18;
                        PlugOfCheckCanItem(4, MapItem.Name, boCanHit, dx, dy); // ��ֹ��Ʒ����(������Ʒ��ʾ)
                        nCode = 19;
                        if (boDieDrop)
                        {
                            logcap = "15";
                        }
                        else
                        {
                            logcap = "7";
                        }
                        if (StdItem->NeedIdentify == 1)
                        {
                            M2Share.AddGameDataLog(logcap + "\09" + m_sMapName + "(" + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT) + ")"
                                + "\09" + (m_nCurrX).ToString() + "\09" + (m_nCurrY).ToString() + "\09" + m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09"
                                + (UserItem->MakeIndex).ToString() + "\09" + "(" + (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")"
                                + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString()
                                + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString()
                                + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")" + (UserItem->btValue[0]).ToString() + "/"
                                + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString() + "/" +
                                (UserItem->btValue[4]).ToString() + "/" + (UserItem->btValue[5]).ToString() + "/" + (UserItem->btValue[6]).ToString() + "/" +
                                (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString() + "\09" +
                                (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                        }
                        result = true;
                    }
                    else
                    {
                        Dispose(MapItem);
                        MapItem = null;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.DropItemDown Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// ��Ϸ�Ҹı�
        /// </summary>
        public void GoldChanged()
        {
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_GOLDCHANGED, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// ��Ϸ�Ҹı�
        /// </summary>
        public void GameGoldChanged()
        {
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_GAMEGOLDCHANGED, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// ����ֵ�ı�
        /// </summary>
        public void GameGloryChanged()
        {
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_GLORY, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// ���¼����ɫ�ĵȼ�������
        /// </summary>
        public void RecalcLevelAbilitys()
        {
            int nLevel = m_Abil.Level;
            int n;
            switch (m_btJob)
            {
                case 2:
                    m_Abil.MaxHP = HUtil32._MIN(Int32.MaxValue, 14 + (int)HUtil32.Round(((nLevel / (double)GameConfig.nLevelValueOfTaosHP + GameConfig.nLevelValueOfTaosHPRate) * nLevel)));
                    m_Abil.MaxMP = HUtil32._MIN(Int32.MaxValue, 13 + (int)HUtil32.Round(((nLevel / (double)GameConfig.nLevelValueOfTaosMP) * 2.2 * nLevel)));
                    m_Abil.MaxWeight = (ushort)HUtil32._MIN((int)ushort.MaxValue, 50 + (int)HUtil32.Round((double)(nLevel / (double)4) * nLevel));
                    m_Abil.MaxWearWeight = (ushort)HUtil32._MIN((int)ushort.MaxValue, 15 + (int)HUtil32.Round((double)(nLevel / (double)50) * nLevel));
                    m_Abil.MaxHandWeight = (ushort)HUtil32._MIN((int)ushort.MaxValue, 12 + (int)HUtil32.Round((double)(nLevel / (double)42) * nLevel));
                    n = nLevel / 7;
                    m_Abil.DC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.MC = 0;
                    m_Abil.SC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.AC = 0;
                    n = (int)HUtil32.Round((double)nLevel / 6);
                    m_Abil.MAC = HUtil32.MakeLong(n / 2, n + 1);
                    break;
                case 1:
                    m_Abil.MaxHP = HUtil32._MIN(Int32.MaxValue, 14 + (int)HUtil32.Round(((nLevel / (double)GameConfig.nLevelValueOfWizardHP + GameConfig.nLevelValueOfWizardHPRate) * nLevel)));
                    m_Abil.MaxMP = HUtil32._MIN(Int32.MaxValue, 13 + (int)HUtil32.Round((nLevel / (double)5 + 2) * 2.2 * nLevel));
                    m_Abil.MaxWeight = (ushort)HUtil32._MIN(ushort.MaxValue, 50 + (int)HUtil32.Round((double)(nLevel / (double)5) * nLevel));
                    m_Abil.MaxWearWeight = (ushort)HUtil32._MIN(ushort.MaxValue, 15 + (int)HUtil32.Round((double)(nLevel / (double)100) * nLevel));
                    m_Abil.MaxHandWeight = (ushort)HUtil32._MIN(ushort.MaxValue, 12 + (int)HUtil32.Round((double)(nLevel / (double)90) * nLevel));
                    n = nLevel / 7;
                    m_Abil.DC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.MC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.SC = 0;
                    m_Abil.AC = 0;
                    m_Abil.MAC = 0;
                    break;
                case 0:
                    m_Abil.MaxHP = HUtil32._MIN(Int32.MaxValue, 14 + (int)HUtil32.Round(((nLevel / (double)GameConfig.nLevelValueOfWarrHP + GameConfig.nLevelValueOfWarrHPRate + nLevel / 20) * nLevel)));
                    m_Abil.MaxMP = HUtil32._MIN(Int32.MaxValue, 11 + (int)HUtil32.Round(nLevel * 3.5));
                    m_Abil.MaxWeight = (ushort)HUtil32._MIN(ushort.MaxValue, 50 + (int)HUtil32.Round((double)(nLevel / (double)3) * nLevel));
                    m_Abil.MaxWearWeight = (ushort)HUtil32._MIN(ushort.MaxValue, 15 + (int)HUtil32.Round((double)(nLevel / (double)20) * nLevel));
                    m_Abil.MaxHandWeight = (ushort)HUtil32._MIN(ushort.MaxValue, 12 + (int)HUtil32.Round((double)(nLevel / (double)13) * nLevel));
                    m_Abil.DC = HUtil32.MakeLong(HUtil32._MAX((nLevel / 5) - 1, 1), HUtil32._MAX(1, (nLevel / 5)));
                    m_Abil.SC = 0;
                    m_Abil.MC = 0;
                    m_Abil.AC = HUtil32.MakeLong(0, (nLevel / 7));
                    m_Abil.MAC = 0;
                    break;
            }
            if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                // Ӣ��HPֵ�����ñ������� 17 112 1000
                m_Abil.MaxHP = HUtil32._MIN(Int32.MaxValue, (int)HUtil32.Round(m_Abil.MaxHP * (double)GameConfig.nHeroHPRate / 1000));
            }
            if (m_Abil.HP > m_Abil.MaxHP)
            {
                m_Abil.HP = m_Abil.MaxHP;
            }
            if (m_Abil.MP > m_Abil.MaxMP)
            {
                m_Abil.MP = m_Abil.MaxMP;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="nLevel"></param>
        public void HasLevelUp(int nLevel)
        {
            m_Abil.MaxExp = GetLevelExp(m_Abil.Level);
            RecalcLevelAbilitys();// ˢ�µȼ���������
            RecalcAbilitys();
            CompareSuitItem(false); // ��װ
            if (nLevel != 0) //���ݲ���������Ϣ,����Ϊ0������Ϣ
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    if (!((this) as TPlayObject).m_boNotOnlineAddExp) // �ǹһ�����
                    {
                        SendMsg(this, Grobal2.RM_LEVELUP, 0, (int)m_Abil.Exp, 0, 0, "");
                        SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, ""); // ������������
                        ((this) as TPlayObject).LevelUpFunc();// ������������
                    }
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT) // ����Ӣ��������Ϣ
                {
                    if ((((m_Master) as TPlayObject) != null) && (!((m_Master) as TPlayObject).m_boNotOnlineAddExp))
                    {
                        ((THeroObject)(this)).SendMsg(m_Master, Grobal2.RM_HEROLEVELUP, 0, (int)m_Abil.Exp, 0, 0, "");
                        SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, "");// ������������ 
                        ((THeroObject)(this)).GetBagItemCount();// ˢ��Ӣ�۰�������
                        ((THeroObject)(this)).LevelUpFunc();// Ӣ����������
                    }
                }
                else
                {
                    SendMsg(this, Grobal2.RM_LEVELUP, 0, (int)m_Abil.Exp, 0, 0, "");
                }
            }
        }

        /// <summary>
        /// �ߵ�ĳһ��
        /// </summary>
        /// <param name="btDir"></param>
        /// <param name="boFlag"></param>
        /// <returns></returns>
        public bool WalkTo(byte btDir, bool boFlag)
        {
            bool result = false;
            int nOX = 0;
            int nOY = 0;
            int nNX = 0;
            int nNY = 0;
            int n20 = 0;
            int n24 = 0;
            bool bo29;
            byte nCode = 0;
            const string sExceptionMsg = "{�쳣} TBaseObject::WalkTo Code:";
            if (m_boHolySeize)
            {
                return result;
            }
            try
            {
                nOX = m_nCurrX;
                nOY = m_nCurrY;
                m_btDirection = btDir;
                nNX = 0;
                nNY = 0;
                nCode = 1;
                switch (btDir)
                {
                    case Grobal2.DR_UP:
                        nNX = m_nCurrX;
                        nNY = m_nCurrY - 1;
                        break;
                    case Grobal2.DR_UPRIGHT:
                        nNX = m_nCurrX + 1;
                        nNY = m_nCurrY - 1;
                        break;
                    case Grobal2.DR_RIGHT:
                        nNX = m_nCurrX + 1;
                        nNY = m_nCurrY;
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        nNX = m_nCurrX + 1;
                        nNY = m_nCurrY + 1;
                        break;
                    case Grobal2.DR_DOWN:
                        nNX = m_nCurrX;
                        nNY = m_nCurrY + 1;
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        nNX = m_nCurrX - 1;
                        nNY = m_nCurrY + 1;
                        break;
                    case Grobal2.DR_LEFT:
                        nNX = m_nCurrX - 1;
                        nNY = m_nCurrY;
                        break;
                    case Grobal2.DR_UPLEFT:
                        nNX = m_nCurrX - 1;
                        nNY = m_nCurrY - 1;
                        break;
                }
                nCode = 2;
                if ((nNX >= 0) && ((m_PEnvir.m_nWidth - 1) >= nNX) && (nNY >= 0) && ((m_PEnvir.m_nHeight - 1) >= nNY))
                {
                    bo29 = true;
                    nCode = 3;
                    if (bo2BA && !m_PEnvir.CanSafeWalk(nNX, nNY))
                    {
                        bo29 = false;
                    }
                    nCode = 4;
                    if (m_Master != null)
                    {
                        if (!m_Master.m_boGhost)
                        {
                            nCode = 5;
                            m_Master.m_PEnvir.GetNextPosition(m_Master.m_nCurrX, m_Master.m_nCurrY, m_Master.m_btDirection, 1, ref n20, ref n24);
                            nCode = 6;
                            if ((nNX == n20) && (nNY == n24))
                            {
                                bo29 = false;
                            }
                        }
                    }
                    if (bo29)
                    {
                        nCode = 7;
                        if (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, nNX, nNY, boFlag) > 0)
                        {
                            m_nCurrX = nNX;
                            m_nCurrY = nNY;
                        }
                    }
                }
                if ((m_nCurrX != nOX) || (m_nCurrY != nOY))
                {
                    nCode = 8;
                    if (Walk(Grobal2.RM_WALK))
                    {
                        if (m_boTransparent && m_boHideMode) // 8
                        {
                            m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;
                        }
                        result = true;
                    }
                    else
                    {
                        nCode = 9;
                        m_PEnvir.DeleteFromMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                        m_nCurrX = nOX;
                        m_nCurrY = nOY;
                        nCode = 10;
                        m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// �Ƿ񳬹�����
        /// </summary>
        /// <param name="nWeight"></param>
        /// <returns></returns>
        public bool IsAddWeightAvailable(int nWeight)
        {
            bool result = false;
            if ((m_WAbil.Weight + nWeight) <= m_WAbil.MaxWeight)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// ˢ��PKֵ
        /// </summary>
        /// <returns></returns>
        public int PKLevel()
        {
            return m_nPkPoint / 100;
        }

        /// <summary>
        /// �ܲ�����Ѫ
        /// </summary>
        public void HealthSpellChanged()
        {
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                if (!((this) as TPlayObject).m_boNotOnlineAddExp)// ֻ���͸������߹һ�����
                {
                    SendUpdateMsg(this, Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                }
            }
            else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_Master != null)) // Ӣ��
            {
                if (!((m_Master) as TPlayObject).m_boNotOnlineAddExp)// ֻ���͸������߹һ�����
                {
                    m_Master.SendUpdateMsg(this, Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                }
            }
            else
            {
                SendUpdateMsg(this, Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
            }
            if (m_boShowHP)
            {
                SendRefMsg(Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
            }
        }

        // ������ĸı�
        public void PlugHealthSpellChanged()
        {
            // �����Ѫ�ı�Ѫ��
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                if (!((this) as TPlayObject).m_boNotOnlineAddExp)
                {
                    // ֻ���͸������߹һ�����
                    SendUpdateMsg(this, Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                }
            }
            else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_Master != null))
            {
                // Ӣ��
                if (!((m_Master) as TPlayObject).m_boNotOnlineAddExp)
                {
                    // ֻ���͸������߹һ�����
                    m_Master.SendUpdateMsg(this, Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
                }
            }
            else
            {
                SendUpdateMsg(this, Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
            }
            SendRefMsg(Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
        }

        // �����ָ��Ч�������ָ�
        public UInt32 CalcGetExp(int nLevel, UInt32 nExp)
        {
            UInt32 result;
            if (GameConfig.boHighLevelKillMonFixExp || (m_Abil.Level < (nLevel + 10)))
            {
                result = nExp;
            }
            else
            {
                result = nExp - (UInt32)HUtil32.Round((double)(nExp / 15) * (m_Abil.Level - (nLevel + 10)));
            }
            if (result <= 0)
            {
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// ˢ��������ɫ
        /// </summary>
        public void RefNameColor()
        {
            SendRefMsg(Grobal2.RM_CHANGENAMECOLOR, 0, 0, 0, 0, "");
        }

        /// <summary>
        /// ȡ������ɱ������
        /// </summary>
        /// <returns></returns>
        public int GainSlaveExp_GetUpKillCount()
        {
            int result;
            int tCount;
            if (m_btSlaveExpLevel < M2Share.SLAVEMAXLEVEL - 2)
            {
                tCount = GameConfig.MonUpLvNeedKillCount[m_btSlaveExpLevel];
            }
            else
            {
                tCount = 0;
            }
            // 16 100
            result = ((m_Abil.Level * GameConfig.nMonUpLvRate) - m_Abil.Level) + GameConfig.nMonUpLvNeedKillBase + tCount;
            return result;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="nLevel"></param>
        public void GainSlaveExp(int nLevel)
        {
            try
            {
                n294 += nLevel;
                if (GainSlaveExp_GetUpKillCount() < n294)
                {
                    n294 -= GainSlaveExp_GetUpKillCount();
                    if (m_btSlaveExpLevel < (m_btSlaveMakeLevel * 2 + 1))
                    {
                        m_btSlaveExpLevel++;
                        RecalcAbilitys();
                        if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            CompareSuitItem(false);  // ��װ
                        }
                        RefNameColor();
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.GainSlaveExp");
            }
        }

        /// <summary>
        /// ��ҵ���
        /// </summary>
        /// <param name="nGold"></param>
        /// <param name="boFalg"></param>
        /// <param name="GoldOfCreat"></param>
        /// <param name="DropGoldCreat"></param>
        /// <returns></returns>
        public bool DropGoldDown(int nGold, bool boFalg, TBaseObject GoldOfCreat, TBaseObject DropGoldCreat)
        {
            bool result;
            TMapItem MapItem = null;
            TMapItem MapItemA = null;
            int nX = 0;
            int nY = 0;
            string s20;
            result = false;
            MapItem = new TMapItem();
            MapItem.Name = M2Share.sSTRING_GOLDNAME;
            MapItem.Count = nGold;
            MapItem.Looks = M2Share.GetGoldShape(nGold);
            MapItem.OfBaseObject = GoldOfCreat;
            MapItem.dwCanPickUpTick = HUtil32.GetTickCount();
            MapItem.DropBaseObject = DropGoldCreat;
            GetDropPosition(m_nCurrX, m_nCurrY, 3, ref nX, ref nY);
            MapItemA = (TMapItem)m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, MapItem);
            if (MapItemA != null)
            {
                if (MapItemA != MapItem)
                {
                    Dispose(MapItem);
                    MapItem = MapItemA;
                }
                SendRefMsg(Grobal2.RM_ITEMSHOW, MapItem.Looks, MapItem.ToInt(), nX, nY, MapItem.Name);
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    if (boFalg)
                    {
                        s20 = "15";
                    }
                    else
                    {
                        s20 = "7";
                    }
                    if (M2Share.g_boGameLogGold)
                    {
                        M2Share.AddGameDataLog(s20 + "\09" + m_sMapName + "\09" + m_nCurrX + "\09" + m_nCurrY + "\09" + m_sCharName + "\09"
                            + M2Share.sSTRING_GOLDNAME + "\09" + nGold + "\09" + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT) + "\09" + "0");
                    }
                }
                result = true;
            }
            else
            {
                Dispose(MapItem);
            }
            return result;
        }

        /// <summary>
        /// ȡ�л��ϵ,���ѻ�ж�
        /// </summary>
        /// <param name="cert1"></param>
        /// <param name="cert2"></param>
        /// <returns></returns>
        public int GetGuildRelation(TBaseObject cert1, TBaseObject cert2)
        {
            int result = 0;
            m_boGuildWarArea = false;
            if ((cert1.m_MyGuild == null) || (cert2.m_MyGuild == null))
            {
                return result;
            }
            if (cert1.InSafeArea() || (cert2.InSafeArea()))
            {
                return result;
            }
            // ���ڴ˴�,�л�սɱӢ��,������ʾıɱ
            if (cert1.m_MyGuild.GuildWarList.Count <= 0)
            {
                return result;
            }
            m_boGuildWarArea = true;
            if (cert1.m_MyGuild.IsWarGuild(cert2.m_MyGuild) && cert2.m_MyGuild.IsWarGuild(cert1.m_MyGuild))
            {
                result = 2;
            }
            if (cert1.m_MyGuild == cert2.m_MyGuild)
            {
                result = 1;
            }
            if (cert1.m_MyGuild.IsAllyGuild(cert2.m_MyGuild) && cert2.m_MyGuild.IsAllyGuild(cert1.m_MyGuild))
            {
                result = 3;
            }
            return result;
        }

        /// <summary>
        /// ���ӽ�ɫPKֵ
        /// </summary>
        /// <param name="nPoint"></param>
        public void IncPkPoint(int nPoint)
        {
            int nOldPKLevel;
            if (m_btRaceServer == Grobal2.RC_HEROOBJECT) // Ӣ��
            {
                if (m_Master != null)
                {
                    nOldPKLevel = m_Master.PKLevel();
                    m_Master.m_nPkPoint += nPoint;
                    if (m_Master.PKLevel() != nOldPKLevel)
                    {
                        if (m_Master.PKLevel() <= 2)
                        {
                            m_Master.RefNameColor();
                        }
                    }
                }
                ((THeroObject)(this)).m_nLoyal = HUtil32._MAX(0, ((THeroObject)(this)).m_nLoyal - GameConfig.nPKDecLoyal);// PKֵ���Ӽ����ҳ϶�
            }
            else
            {
                nOldPKLevel = PKLevel();
                m_nPkPoint += nPoint;
                if (PKLevel() != nOldPKLevel)
                {
                    if (PKLevel() <= 2)
                    {
                        RefNameColor();
                    }
                }
            }
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <param name="dLuck"></param>
        public void AddBodyLuck(double dLuck)
        {
            int n = 0;
            if ((dLuck > 0) && (m_dBodyLuck < 5 * Grobal2.BODYLUCKUNIT))
            {
                m_dBodyLuck = m_dBodyLuck + dLuck;
            }
            if ((dLuck < 0) && (m_dBodyLuck > -(5 * Grobal2.BODYLUCKUNIT)))
            {
                m_dBodyLuck = m_dBodyLuck + dLuck;
            }
            n = Convert.ToInt32(m_dBodyLuck / Grobal2.BODYLUCKUNIT);
            if (n > 5)
            {
                n = 5;
            }
            if (n < -10)
            {
                n = -10;
            }
            m_nBodyLuckLevel = n;
        }

        /// <summary>
        /// ����������
        /// </summary>
        public unsafe virtual void MakeWeaponUnlock()
        {
            if (m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return;
            }
            if (m_UseItems[TPosition.U_WEAPON]->btValue[3] > 0)
            {
                m_UseItems[TPosition.U_WEAPON]->btValue[3] -= 1;
                SysMsg(GameMsgDef.g_sTheWeaponIsCursed, TMsgColor.c_Red, TMsgType.t_Hint);
            }
            else
            {
                if (m_UseItems[TPosition.U_WEAPON]->btValue[4] < 10)
                {
                    m_UseItems[TPosition.U_WEAPON]->btValue[4]++;
                    SysMsg(GameMsgDef.g_sTheWeaponIsCursed, TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                RecalcAbilitys();
                CompareSuitItem(false);// ��װ
                SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                SendMsg(this, Grobal2.RM_SUBABILITY, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// ȡ��������
        /// </summary>
        /// <param name="nBasePower"></param>
        /// <param name="nPower"></param>
        /// <returns></returns>
        public int GetAttackPower(int nBasePower, int nPower)
        {
            int result;
            TPlayObject PlayObject;
            THeroObject HeroObject;
            if (nPower < 0)
            {
                nPower = 0;
            }
            if (m_nLuck > 0)
            {
                if (HUtil32.Random(10 - HUtil32._MIN(9, m_nLuck)) == 0)
                {
                    result = nBasePower + nPower;
                }
                else
                {
                    result = nBasePower + HUtil32.Random(nPower + 1);
                }
            }
            else
            {
                result = nBasePower + HUtil32.Random(nPower + 1);
                if (m_nLuck < 0)
                {
                    if (HUtil32.Random(10 - HUtil32._MAX(0, -m_nLuck)) == 0)
                    {
                        result = nBasePower;
                    }
                }
            }
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                PlayObject = ((this) as TPlayObject);
                if ((PlayObject.m_dwPowerRateTime <= 0) && (PlayObject.m_nPowerRate > 100))
                {
                    PlayObject.m_nPowerRate = 100; // ������﹥���������Ƿ���ȷ
                }
                result = (int)HUtil32.Round((double)result * (PlayObject.m_nPowerRate / 100));
                if (PlayObject.m_boPowerItem)
                {
                    result = (int)HUtil32.Round(m_rPowerItem * result); // ������Ʒ
                }
            }
            if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                HeroObject = ((THeroObject)(this));
                if (HeroObject.m_boPowerItem)
                {
                    result = (int)HUtil32.Round(m_rPowerItem * result);
                }
            }
            if (m_boAutoChangeColor)
            {
                result = result * m_nAutoChangeIdx + 1;
            }
            if (m_boFixColor)
            {
                result = result * m_nFixColorIdx + 1;
            }
            return result;
        }

        /// <summary>
        /// ��Ѫ
        /// </summary>
        /// <param name="nDamage"></param>
        public void DamageHealth(int nDamage)
        {
            int nSpdam;
            if (m_LastHiter != null)
            {
                if ((!m_LastHiter.m_boUnMagicShield) && m_boMagicShield && (nDamage > 0) && (m_WAbil.MP > 0)) // �������ָ
                {
                    nSpdam = (int)HUtil32.Round(nDamage * 1.5);
                    if (((int)m_WAbil.MP) >= nSpdam)
                    {
                        m_WAbil.MP = m_WAbil.MP - nSpdam;
                        nSpdam = 0;
                    }
                    else
                    {
                        // ħ��ҩ������
                        nSpdam = nSpdam - m_WAbil.MP;
                        m_WAbil.MP = 0;
                    }
                    nDamage = (int)HUtil32.Round(nSpdam / 1.5);
                }
            }
            else
            {
                if (m_boMagicShield && (nDamage > 0) && (m_WAbil.MP > 0))
                {
                    nSpdam = (int)HUtil32.Round(nDamage * 1.5);
                    if (((int)m_WAbil.MP) >= nSpdam)
                    {
                        m_WAbil.MP = m_WAbil.MP - nSpdam;
                        nSpdam = 0;
                    }
                    else
                    {
                        nSpdam = nSpdam - m_WAbil.MP;
                        m_WAbil.MP = 0;
                    }
                    nDamage = (int)HUtil32.Round(nSpdam / 1.5);
                }
            }
            if (nDamage > 0)
            {
                if ((m_WAbil.HP - nDamage) > 0)
                {
                    m_WAbil.HP = m_WAbil.HP - nDamage;
                }
                else
                {
                    m_WAbil.HP = 0;
                }
            }
            else
            {
                if ((m_WAbil.HP - nDamage) < m_WAbil.MaxHP)
                {
                    m_WAbil.HP = m_WAbil.HP - nDamage;
                }
                else
                {
                    m_WAbil.HP = m_WAbil.MaxHP;
                }
            }
            HealthSpellChanged();
        }

        /// <summary>
        /// ȡ�����λ��
        /// </summary>
        /// <param name="nDir"></param>
        /// <returns></returns>
        public byte GetBackDir(byte nDir)
        {
            byte result = 0;
            switch (nDir)
            {
                case Grobal2.DR_UP:
                    result = Grobal2.DR_DOWN;
                    break;
                case Grobal2.DR_DOWN:
                    result = Grobal2.DR_UP;
                    break;
                case Grobal2.DR_LEFT:
                    result = Grobal2.DR_RIGHT;
                    break;
                case Grobal2.DR_RIGHT:
                    result = Grobal2.DR_LEFT;
                    break;
                case Grobal2.DR_UPLEFT:
                    result = Grobal2.DR_DOWNRIGHT;
                    break;
                case Grobal2.DR_UPRIGHT:
                    result = Grobal2.DR_DOWNLEFT;
                    break;
                case Grobal2.DR_DOWNLEFT:
                    result = Grobal2.DR_UPRIGHT;
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    result = Grobal2.DR_UPLEFT;
                    break;
            }
            return result;
        }

        // ȡ����ֵ
        // Ұ����ײ(��ײ) ע�⣺��nDir�����ķ�������
        public int CharPushed(byte nDir, int nPushCount)
        {
            int result = 0;
            int nX = 0;
            int nY = 0;
            byte olddir = m_btDirection;
            byte nBackDir = GetBackDir(nDir);
            this.m_btDirection = nDir;
            if (nPushCount > 0)
            {
                for (int I = 0; I < nPushCount; I++)
                {
                    GetFrontPosition(ref nX, ref nY);
                    if (m_PEnvir.CanWalk(nX, nY, false))
                    {
                        if (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, nX, nY, false) > 0)
                        {
                            m_nCurrX = nX;
                            m_nCurrY = nY;
                            // SendRefMsg(RM_PUSH, GetBackDir(ndir), m_nCurrX, m_nCurrY, 0, '');
                            SendRefMsg(Grobal2.RM_PUSH, nBackDir, m_nCurrX, m_nCurrY, 0, "");
                            result++;
                            if (m_btRaceServer >= Grobal2.RC_ANIMAL)
                            {
                                m_dwWalkTick = m_dwWalkTick + 800;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            m_btDirection = nBackDir;
            if (result == 0)
            {
                m_btDirection = olddir;
            }
            return result;
        }

        // Ұ����ײ(��ײ) ע�⣺��nDir�����ķ������� 
        public int CharPushedEx(byte nDir, int nPushCount)
        {
            int result = 0;
            int nX = 0;
            int nY = 0;
            byte olddir = m_btDirection;
            byte nBackDir = GetBackDir(nDir);
            this.m_btDirection = nDir;
            if (nPushCount > 0)
            {
                for (int I = 0; I < nPushCount; I++)
                {
                    GetFrontPosition(ref nX, ref nY);
                    if (m_PEnvir.CanWalk(nX, nY, false))
                    {
                        if (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, nX, nY, false) > 0)
                        {
                            m_nCurrX = nX;
                            m_nCurrY = nY;
                            result++;
                            if (m_btRaceServer >= Grobal2.RC_ANIMAL)
                            {
                                m_dwWalkTick = m_dwWalkTick + 800;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            m_btDirection = nBackDir;
            if (result == 0)
            {
                m_btDirection = olddir;
            }
            return result;
        }

        // ���𻵵�����
        public string MoneyToCharacter(int Money)
        {
            string result = string.Empty;
            // ����ת��Ϊ���Ĵ�д
            string temp;
            string resu;
            int i;
            int j;
            int len;
            string[] Num = new string[9 + 1];
            string[] A = new string[4 + 1];
            try
            {
                Num[0] = "��";
                Num[1] = "һ";
                Num[2] = "��";
                Num[3] = "��";
                Num[4] = "��";
                Num[5] = "��";
                Num[6] = "��";
                Num[7] = "��";
                Num[8] = "��";
                Num[9] = "��";
                A[1] = "ʮ";
                A[2] = "��";
                A[3] = "ǧ";
                A[4] = "��";
                // a[5]:='ʮ';
                // a[6]:='��';
                // a[7]:='ǧ';
                // a[8]:='��';
                // a[9]:='ʮ';
                // a[10]:='��';
                // a[11]:='ǧ';
                if (Money == 1)
                {
                    result = "��";
                    return result;
                }
                temp = (Money).ToString().Trim();
                len = temp.Length;
                resu = "";
                if ((len > 4) || (len == 0))
                {
                    return result;
                }
                for (i = 1; i <= len; i++)
                {
                    j = Convert.ToInt32(temp.Substring(i - 1, 1));
                    if ((j == 0) && (i == len))
                    {
                        continue;
                    }
                    if ((j == 0))
                    {
                        resu = resu + Num[j];
                    }
                    else
                    {
                        resu = resu + Num[j] + A[len - i];
                    }
                }
                result = resu;
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.MoneyToCharacter");
            }
            return result;
        }

        // ȡͬ����Ĺ��� �����Ӱʹ���жϹֵ�����
        // һ��ֱ���˺�������ħ��
        public unsafe int MagPassThroughMagic(int sX, int sY, int tx, int ty, int nDir, int magpwr, int nSccPwr, bool undeadattack, byte nCode)
        {
            int result;
            int I;
            int tCount;
            int acpwr;
            int nPwr;
            TBaseObject BaseObject;
            tCount = 0;
            for (I = 0; I <= 12; I++)
            {
                BaseObject = m_PEnvir.GetMovingObject(sX, sY, true);
                if (BaseObject != null)
                {
                    if (IsProperTarget(BaseObject))
                    {
                        if (HUtil32.Random(10) >= BaseObject.m_nAntiMagic)
                        {
                            if (undeadattack)
                            {
                                acpwr = (int)HUtil32.Round(magpwr * 1.5);
                            }
                            else
                            {
                                acpwr = magpwr;
                            }
                            switch (nCode)
                            {
                                case MagicConst.SKILL_FIRE:
                                    // ������
                                    if (((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (magpwr > nSccPwr))
                                    {
                                        nPwr = 0;
                                        if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            nPwr = M2Share.MagicManager.GetNGPow(BaseObject, ((BaseObject) as TPlayObject).m_MagicSkill_215, nSccPwr);
                                            // ��֮������
                                        }
                                        else if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            nPwr = M2Share.MagicManager.GetNGPow(BaseObject, ((THeroObject)(BaseObject)).m_MagicSkill_215, nSccPwr);
                                            // ��֮������
                                        }
                                        acpwr = HUtil32._MAX(0, acpwr - nPwr);
                                    }
                                    break;
                                case MagicConst.SKILL_SHOOTLIGHTEN:
                                    // �����Ӱ
                                    if (((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (magpwr > nSccPwr))
                                    {
                                        nPwr = 0;
                                        if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            nPwr = M2Share.MagicManager.GetNGPow(BaseObject, ((BaseObject) as TPlayObject).m_MagicSkill_217, nSccPwr);
                                            // ��֮�����Ӱ
                                        }
                                        else if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            nPwr = M2Share.MagicManager.GetNGPow(BaseObject, ((THeroObject)(BaseObject)).m_MagicSkill_217, nSccPwr);
                                            // ��֮�����Ӱ
                                        }
                                        acpwr = HUtil32._MAX(0, acpwr - nPwr);
                                    }
                                    break;
                            }
                            BaseObject.SendDelayMsg(this, Grobal2.RM_MAGSTRUCK, 0, acpwr, 0, 0, "", 600);
                            tCount++;
                        }
                    }
                }
                if (!((Math.Abs(sX - tx) <= 0) && (Math.Abs(sY - ty) <= 0)))
                {
                    nDir = M2Share.GetNextDirection(sX, sY, tx, ty);
                    if (!m_PEnvir.GetNextPosition(sX, sY, nDir, 1, ref sX, ref sY))
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            result = tCount;
            return result;
        }

        /// <summary>
        /// �Ƿ�ʹ�ö���
        /// </summary>
        /// <returns></returns>
        public unsafe bool IsUsesZhuLi()
        {
            bool result = false;
            TStdItem* StdItem;
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
            {
                if (m_UseItems[TPosition.U_ZHULI]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(m_UseItems[TPosition.U_ZHULI]->wIndex);
                    if ((StdItem != null) && (StdItem->StdMode == 16))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ��ʾ���� (��������NPC,��,����)
        /// </summary>
        /// <returns></returns>
        public virtual string GetShowName()
        {
            string result = string.Empty;
            string sShowName = string.Empty;
            string sTemp = string.Empty;
            int n10;
            byte nCode;
            nCode = 0;
            try
            {
                sShowName = m_sCharName;
                nCode = 1;
                n10 = M2Share.GetValNameNo(sShowName);// ֧��NPC������ʾ A T S ����
                nCode = 11;
                if ((n10 >= 0) && (m_btRaceServer == Grobal2.RC_NPC)) //ֻ���NPC
                {
                    if (HUtil32.rangeInDefined(n10, 600, 699))
                    {
                        nCode = 12;
                        sTemp = ((this) as TPlayObject).m_sString[n10 - 600];
                        if ((sTemp != "") && (sTemp[0] == '<') && (sTemp[1] == '$'))
                        {
                            sTemp = sTemp.Substring(sTemp.IndexOf("\\") - 1, sTemp.Length);
                        }
                        if (sTemp == "")
                        {
                            sTemp = ((TMerchant)(this)).m_sScript;
                        }
                    }
                    if (HUtil32.rangeInDefined(n10, 700, 799))
                    {
                        nCode = 13;
                        sTemp = GameConfig.GlobalAVal[n10 - 700];
                        if ((sTemp != "") && (sTemp[0] == '<') && (sTemp[1] == '$'))
                        {
                            sTemp = sTemp.Substring(sTemp.IndexOf("\\") - 1, sTemp.Length);
                        }
                        if (sTemp == "")
                        {
                            if (((TMerchant)(this)).m_sScript.IndexOf("_") > 0) //��������Ϊ "����/�����_��һ��սʿ",�ͻ���ֻ��ʾ"����"
                            {
                                sTemp = ((TMerchant)(this)).m_sScript.Substring(((TMerchant)(this)).m_sScript.IndexOf("_") + 1 - 1, ((TMerchant)(this)).m_sScript.Length);
                            }
                            else
                            {
                                sTemp = ((TMerchant)(this)).m_sScript;
                            }
                        }
                    }
                    if (HUtil32.rangeInDefined(n10, 700, 799))// A����(100-499)
                    {
                        nCode = 14;
                        sTemp = GameConfig.GlobalAVal[n10 - 1100];
                        if ((sTemp != "") && (sTemp[0] == '<') && (sTemp[1] == '$'))
                        {
                            sTemp = sTemp.Substring(sTemp.IndexOf("\\") - 1, sTemp.Length);
                        }
                        if (sTemp == "")
                        {
                            if (((TMerchant)(this)).m_sScript.IndexOf("_") > 0)
                            {
                                // ��������Ϊ "����/�����_��һ��սʿ",�ͻ���ֻ��ʾ"����"
                                sTemp = ((TMerchant)(this)).m_sScript.Substring(((TMerchant)(this)).m_sScript.IndexOf("_") + 1 - 1, ((TMerchant)(this)).m_sScript.Length);
                            }
                            else
                            {
                                sTemp = ((TMerchant)(this)).m_sScript;
                            }
                        }
                    }
                }
                nCode = 15;
                if (sTemp != "")
                {
                    result = sTemp;
                }
                else
                {
                    result = M2Share.FilterShowName(sShowName);// ���������ֵ�����
                }
                nCode = 2;
                if (new ArrayList(new int[] { 0, 1 }).Contains(m_nCopyHumanLevel))
                {
                    if ((m_Master != null))
                    {
                        if (!m_Master.m_boObMode)
                        {
                            if (GameConfig.boUnKnowHum && (m_Master.IsUsesZhuLi()))  // ����Ϊ������ʱ������ҲҪ��ʾ������
                            {
                                result = result + "(������)";
                            }
                            else
                            {
                                result = result + "(" + m_Master.m_sCharName + ")";
                            }
                        }
                    }
                }
                else
                {
                    nCode = 3;
                    if ((m_nCopyHumanLevel == 2) && (m_Master != null))
                    {
                        if (!m_Master.m_boObMode)
                        {
                            if (GameConfig.boAddMasterName)// ʹ������������ǰ׺
                            {
                                if (GameConfig.boUnKnowHum && (m_Master.IsUsesZhuLi()))
                                {
                                    result = "(������)" + GameConfig.sCopyHumName;
                                }
                                else
                                {
                                    result = m_Master.m_sCharName + GameConfig.sCopyHumName;
                                }
                            }
                            else
                            {
                                nCode = 4;
                                result = GameConfig.sCopyHumName;// �����������֧����ʾ������һ��,������ʾ�л���
                                if ((m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                                {
                                    nCode = 5;
                                    result = ((m_Master) as TPlayObject).GetShowName();
                                }
                            }
                        }
                    }
                }
                if (GameConfig.boUnKnowHum && IsUsesZhuLi())
                {
                    result = "������";// ���϶��Ҽ���ʾ������
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.GetShowName Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// ˢ������
        /// </summary>
        public unsafe virtual void RecalcAbilitys()
        {
            TAbility Abil;
            bool boOldHideMode;
            int nOldLight;
            TStdItem* StdItem;
            bool boRecallSuite1;
            bool boRecallSuite2;
            bool boRecallSuite3;
            bool boRecallSuite4;
            bool boMoXieSuite1;
            bool boMoXieSuite2;
            bool boMoXieSuite3;
            bool boHongMoSuite1;
            bool boHongMoSuite2;
            bool boHongMoSuite3;
            bool boSpirit1;
            bool boSpirit2;
            bool boSpirit3;
            bool boSpirit4;
            byte nCode;
            nCode = 0;
            try
            {
                fixed (TAddAbility* padt = &m_AddAbil)
                {
                    for (int I = 0; I < sizeof(TAddAbility); I++)
                        ((byte*)padt)[I] = 0;
                }
                Abil = m_WAbil;
                m_WAbil = m_Abil;
                m_WAbil.HP = Abil.HP;
                m_WAbil.MP = Abil.MP;
                m_WAbil.Weight = 0;
                m_WAbil.WearWeight = 0;
                m_WAbil.HandWeight = 0;
                m_btAntiPoison = 0;
                m_nPoisonRecover = 0;
                m_nHealthRecover = 0;
                m_nSpellRecover = 0;
                m_nAntiMagic = 1;
                m_nLuck = 0;
                m_nHitSpeed = 0;
                m_boExpItem = false;
                m_rExpItem = 0;
                m_boPowerItem = false;
                m_rPowerItem = 0;
                boOldHideMode = m_boHideMode;
                m_boHideMode = false;
                m_boTeleport = false;// ����
                m_boParalysis = false;// ���
                m_boRevival = false;// ����
                m_boUnRevival = false;
                m_boFlameRing = false;
                m_boYTPDRing = false;// ��������
                m_boXPYJRing = false;// Ѫ��һ��
                m_boMeteorRing = false;// ����
                m_boRecoveryRing = false;
                m_boAngryRing = false;
                m_boMagicShield = false;// ����
                m_boUnMagicShield = false;
                m_boMuscleRing = false;
                m_boFastTrain = false;
                m_boProbeNecklace = false;
                m_boSupermanItem = false;
                m_boGuildMove = false;
                m_boUnParalysis = false;// �����
                m_boExpItem = false;
                m_boPowerItem = false;
                m_boNoDropItem = false;
                m_boNoDropUseItem = false;
                m_bopirit = false;
                m_btHorseType = 0;
                m_btDressEffType = 0;
                m_nMoXieSuite = 0;
                boMoXieSuite1 = false;
                boMoXieSuite2 = false;
                boMoXieSuite3 = false;
                m_db3B0 = 0;
                m_nHongMoSuite = 0;
                boHongMoSuite1 = false;
                boHongMoSuite2 = false;
                boHongMoSuite3 = false;
                boSpirit1 = false;
                boSpirit2 = false;
                boSpirit3 = false;
                boSpirit4 = false;
                m_boRecallSuite = false;
                boRecallSuite1 = false;
                boRecallSuite2 = false;
                boRecallSuite3 = false;
                boRecallSuite4 = false;
                m_dwPKDieLostExp = 0;
                m_nPKDieLostLevel = 0;
                nCode = 1;
                for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                {
                    if ((m_UseItems[I]->wIndex <= 0) || (m_UseItems[I]->Dura <= 0))
                    {
                        continue;
                    }
                    StdItem = UserEngine.GetStdItem(m_UseItems[I]->wIndex);
                    if (StdItem == null)
                    {
                        continue;
                    }
                    fixed (TAddAbility* padby = &m_AddAbil)
                    {
                        GetAccessory(m_UseItems[I], StdItem, padby);// ȡ��Ʒ�ĸ�������
                    }
                    if ((I == TPosition.U_WEAPON) || (I == TPosition.U_RIGHTHAND) || (I == TPosition.U_DRESS))
                    {
                        if (I == TPosition.U_DRESS)
                        {
                            m_WAbil.WearWeight += StdItem->Weight;
                        }
                        else
                        {
                            m_WAbil.HandWeight += StdItem->Weight;
                        }
                        // ������ʼ
                        if (StdItem->AniCount == 120)
                        {
                            m_boFastTrain = true;
                        }
                        if (StdItem->AniCount == 121)
                        {
                            m_boProbeNecklace = true;
                        }
                        if (StdItem->AniCount == 145)
                        {
                            m_boGuildMove = true;
                        }
                        if (StdItem->AniCount == 111)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 60000; // 6 * 10 * 1000
                            m_boHideMode = true;
                        }
                        if (StdItem->AniCount == 112)
                        {
                            m_boTeleport = true;
                        }
                        if (StdItem->AniCount == 113)
                        {
                            m_boParalysis = true;
                        }
                        if (StdItem->AniCount == 114)
                        {
                            m_boRevival = true;
                        }
                        if (StdItem->AniCount == 115)
                        {
                            m_boFlameRing = true;
                        }
                        if (StdItem->AniCount == 116)
                        {
                            m_boRecoveryRing = true;
                        }
                        if (StdItem->AniCount == 117)
                        {
                            m_boAngryRing = true;
                        }
                        if (StdItem->AniCount == 118)
                        {
                            m_boMagicShield = true;
                        }
                        if (StdItem->AniCount == 119)
                        {
                            m_boMuscleRing = true;
                        }
                        if (StdItem->AniCount == 135)
                        {
                            boMoXieSuite1 = true;
                            m_nMoXieSuite += StdItem->Weight / 10;
                        }
                        if (StdItem->AniCount == 138)
                        {
                            m_nHongMoSuite += StdItem->Weight;
                        }
                        nCode = 2;
                        if (StdItem->AniCount == 139)
                        {
                            m_boUnParalysis = true;
                        }
                        if (StdItem->AniCount == 140)
                        {
                            m_boSupermanItem = true;
                        }
                        if (StdItem->AniCount == 141)
                        {
                            m_boExpItem = true;
                            m_rExpItem = m_rExpItem + (m_UseItems[I]->Dura / GameConfig.nItemExpRate);
                        }
                        if (StdItem->AniCount == 142)
                        {
                            m_boPowerItem = true;
                            m_rPowerItem = m_rPowerItem + (m_UseItems[I]->Dura / GameConfig.nItemPowerRate);
                        }
                        if (StdItem->AniCount == 182)
                        {
                            m_boExpItem = true;
                            m_rExpItem = m_rExpItem + (m_UseItems[I]->DuraMax / GameConfig.nItemExpRate);
                        }
                        if (StdItem->AniCount == 183)  // ���﹥��������(����Ϊ�־ó��� 10000)��������Ʒ�־�̫СӰ��
                        {
                            m_boPowerItem = true;
                            m_rPowerItem = m_rPowerItem + (m_UseItems[I]->DuraMax / GameConfig.nItemPowerRate);
                        }
                        if (StdItem->AniCount == 192)
                        {
                            m_boYTPDRing = true;
                        }
                        nCode = 3;
                        if (StdItem->AniCount == 143)
                        {
                            m_boUnMagicShield = true;
                        }
                        if (StdItem->AniCount == 144)
                        {
                            m_boUnRevival = true;
                        }
                        if (StdItem->AniCount == 170)
                        {
                            m_boAngryRing = true;
                        }
                        if (StdItem->AniCount == 171)
                        {
                            m_boNoDropItem = true;
                        }
                        if (StdItem->AniCount == 172)
                        {
                            m_boNoDropUseItem = true;
                        }
                        if (StdItem->AniCount == 150)  // ��Ի���
                        {
                            m_boParalysis = true;
                            m_boMagicShield = true;
                        }
                        if (StdItem->AniCount == 151)  // ��Ի���
                        {
                            m_boParalysis = true;
                            m_boFlameRing = true;
                        }
                        if (StdItem->AniCount == 152) // ��Է���
                        {
                            m_boParalysis = true;
                            m_boRecoveryRing = true;
                        }
                        if (StdItem->AniCount == 153) // ��Ը���
                        {
                            m_boParalysis = true;
                            m_boMuscleRing = true;
                        }
                        if (StdItem->Shape == 154) // �������
                        {
                            m_boMagicShield = true;
                            m_boFlameRing = true;
                        }
                        if (StdItem->AniCount == 155)// �������
                        {
                            m_boMagicShield = true;
                            m_boRecoveryRing = true;
                        }
                        if (StdItem->AniCount == 156)// ������
                        {
                            m_boMagicShield = true;
                            m_boMuscleRing = true;
                        }
                        nCode = 4;
                        if (StdItem->AniCount == 157)// �������
                        {
                            m_boTeleport = true;
                            m_boParalysis = true;
                        }
                        if (StdItem->AniCount == 158)// ���ͻ���
                        {
                            m_boTeleport = true;
                            m_boMagicShield = true;
                        }
                        if (StdItem->AniCount == 159)// ����̽��
                        {
                            m_boTeleport = true;
                            m_boProbeNecklace = true;
                        }
                        if (StdItem->AniCount == 160)// ���͸���
                        {
                            m_boTeleport = true;
                            m_boRevival = true;
                        }
                        if (StdItem->AniCount == 161) // ��Ը���
                        {
                            m_boParalysis = true;
                            m_boRevival = true;
                        }
                        if (StdItem->AniCount == 162)// ������
                        {
                            m_boMagicShield = true;
                            m_boRevival = true;
                        }
                        if (StdItem->AniCount == 180) // PK ����������
                        {
                            m_dwPKDieLostExp = Convert.ToUInt32(StdItem->DuraMax * GameConfig.dwPKDieLostExpRate);
                        }
                        if (StdItem->AniCount == 181) // PK �������ȼ�
                        {
                            m_nPKDieLostLevel = (int)StdItem->DuraMax / GameConfig.nPKDieLostLevelRate;
                        }
                        // ��������
                    }
                    else
                    {
                        m_WAbil.WearWeight += StdItem->Weight;
                    }
                    nCode = 5;
                    m_WAbil.Weight += StdItem->Weight;
                    if ((I == TPosition.U_WEAPON)) // ����
                    {
                        nCode = 51;
                        if ((StdItem->Source - 1 - 10) < 0)
                        {
                            m_AddAbil.btWeaponStrong = (byte)StdItem->Source; // ǿ��+
                        }
                        nCode = 52;
                        if ((StdItem->Source <= -1) && (StdItem->Source >= -50))
                        {
                            // -1 �� -50
                            m_AddAbil.bt1DF = (byte)HUtil32._MIN(Byte.MaxValue, m_AddAbil.bt1DF + -StdItem->Source);
                        }
                        // ��ʥ+
                        nCode = 53;
                        if ((StdItem->Source <= -51) && (StdItem->Source >= -100))
                        {
                            // -51 �� - 100
                            m_AddAbil.bt1DF = (byte)HUtil32._MIN(Byte.MaxValue, m_AddAbil.bt1DF + (StdItem->Source + 50));
                        }
                        continue;
                    }
                    nCode = 54;
                    if ((I == TPosition.U_RIGHTHAND))
                    {
                        nCode = 55;
                        if (StdItem->Shape >= 1 && StdItem->Shape <= 50)
                        {
                            m_btDressEffType = StdItem->Shape;
                        }
                        nCode = 56;
                        if (StdItem->Shape >= 51 && StdItem->Shape <= 100)
                        {
                            m_btHorseType = Convert.ToByte(StdItem->Shape - 50);
                        }
                        continue;
                    }
                    nCode = 6;
                    if ((I == TPosition.U_DRESS))
                    {
                        if (m_UseItems[I]->btValue[5] > 0)
                        {
                            m_btDressEffType = (byte)m_UseItems[I]->btValue[5];
                        }
                        if (StdItem->AniCount > 0)
                        {
                            m_btDressEffType = StdItem->AniCount;
                        }
                        continue;
                    }
                    nCode = 7;// ������ʼ
                    if (StdItem->Shape == 139)
                    {
                        m_boUnParalysis = true;
                    }
                    if (StdItem->Shape == 140)
                    {
                        m_boSupermanItem = true;
                    }
                    if (StdItem->Shape == 141)
                    {
                        m_boExpItem = true;
                        m_rExpItem = m_rExpItem + (m_UseItems[I]->Dura / GameConfig.nItemExpRate);
                    }
                    if (StdItem->Shape == 142)
                    {
                        m_boPowerItem = true;
                        m_rPowerItem = m_rPowerItem + (m_UseItems[I]->Dura / GameConfig.nItemPowerRate);
                    }
                    if (StdItem->Shape == 182)
                    {
                        m_boExpItem = true;
                        m_rExpItem = m_rExpItem + (m_UseItems[I]->DuraMax / GameConfig.nItemExpRate);
                    }
                    if (StdItem->Shape == 183)
                    {
                        m_boPowerItem = true;
                        m_rPowerItem = m_rPowerItem + (m_UseItems[I]->DuraMax / GameConfig.nItemPowerRate);
                    }
                    if (StdItem->Shape == 143)
                    {
                        m_boUnMagicShield = true;
                    }
                    if (StdItem->Shape == 144)
                    {
                        m_boUnRevival = true;
                    }
                    if (StdItem->Shape == 170)
                    {
                        m_boAngryRing = true;
                    }
                    if (StdItem->Shape == 171)
                    {
                        m_boNoDropItem = true;
                    }
                    if (StdItem->Shape == 172)
                    {
                        m_boNoDropUseItem = true;
                    }
                    nCode = 8;
                    if (StdItem->Shape == 150) // ��Ի���
                    {
                        m_boParalysis = true;
                        m_boMagicShield = true;
                    }
                    if (StdItem->Shape == 151) // ��Ի���
                    {
                        m_boParalysis = true;
                        m_boFlameRing = true;
                    }
                    if (StdItem->Shape == 152)// ��Է���
                    {
                        m_boParalysis = true;
                        m_boRecoveryRing = true;
                    }
                    if (StdItem->Shape == 153) // ��Ը���
                    {
                        m_boParalysis = true;
                        m_boMuscleRing = true;
                    }
                    if (StdItem->Shape == 154)// �������
                    {
                        m_boMagicShield = true;
                        m_boFlameRing = true;
                    }
                    if (StdItem->Shape == 155) // �������
                    {
                        m_boMagicShield = true;
                        m_boRecoveryRing = true;
                    }
                    if (StdItem->Shape == 156)  // ������
                    {
                        m_boMagicShield = true;
                        m_boMuscleRing = true;
                    }
                    if (StdItem->Shape == 157)// �������
                    {
                        m_boTeleport = true;
                        m_boParalysis = true;
                    }
                    if (StdItem->Shape == 158)// ���ͻ���
                    {
                        m_boTeleport = true;
                        m_boMagicShield = true;
                    }
                    if (StdItem->Shape == 159)// ����̽��
                    {
                        m_boTeleport = true;
                        m_boProbeNecklace = true;
                    }
                    if (StdItem->Shape == 160) // ���͸���
                    {
                        m_boTeleport = true;
                        m_boRevival = true;
                    }
                    if (StdItem->Shape == 161) // ��Ը���
                    {
                        m_boParalysis = true;
                        m_boRevival = true;
                    }
                    if (StdItem->Shape == 162) // ������
                    {
                        m_boMagicShield = true;
                        m_boRevival = true;
                    }
                    if (StdItem->Shape == 169)
                    {
                        m_boMeteorRing = true;
                    }
                    if (StdItem->Shape == 180) // PK ����������
                    {
                        m_dwPKDieLostExp = Convert.ToUInt32(StdItem->DuraMax * GameConfig.dwPKDieLostExpRate);
                    }
                    if (StdItem->Shape == 181)  // PK �������ȼ�
                    {
                        m_nPKDieLostLevel = Convert.ToInt32(StdItem->DuraMax / GameConfig.nPKDieLostLevelRate);
                    }
                    nCode = 9;
                    if (I == TPosition.U_BUJUK)
                    {
                        if ((StdItem->StdMode == 25) && (StdItem->Shape == 6))  // ���ͷ�
                        {
                            m_boTeleport = true;
                        }
                    }
                    // ��������
                    if (StdItem->Shape == 120)
                    {
                        m_boFastTrain = true;
                    }
                    if (StdItem->Shape == 121)
                    {
                        m_boProbeNecklace = true;
                    }
                    if (StdItem->Shape == 123)
                    {
                        boRecallSuite1 = true;
                    }
                    if (StdItem->Shape == 145)
                    {
                        m_boGuildMove = true;
                    }
                    if (StdItem->Shape == 127)
                    {
                        boSpirit1 = true;
                    }
                    if (StdItem->Shape == 135)
                    {
                        boMoXieSuite1 = true;
                        m_nMoXieSuite += StdItem->AniCount;
                    }
                    if (StdItem->Shape == 138)
                    {
                        boHongMoSuite1 = true;
                        m_nHongMoSuite += StdItem->AniCount;
                    }
                    if (StdItem->Shape == 111)
                    {
                        m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 60000;  // 6 * 10 * 1000
                        m_boHideMode = true;
                    }
                    if (StdItem->Shape == 112)
                    {
                        m_boTeleport = true;
                    }
                    if (StdItem->Shape == 113)
                    {
                        m_boParalysis = true;
                    }
                    if (StdItem->Shape == 114)
                    {
                        m_boRevival = true;
                    }
                    if (StdItem->Shape == 115)
                    {
                        m_boFlameRing = true;
                    }
                    if (StdItem->Shape == 116)
                    {
                        m_boRecoveryRing = true;
                    }
                    if (StdItem->Shape == 117)
                    {
                        m_boAngryRing = true;
                    }
                    if (StdItem->Shape == 118)
                    {
                        m_boMagicShield = true;
                    }
                    if (StdItem->Shape == 119)
                    {
                        m_boMuscleRing = true;
                    }
                    if (StdItem->Shape == 122)
                    {
                        boRecallSuite2 = true;
                    }
                    if (StdItem->Shape == 128)
                    {
                        boSpirit2 = true;
                    }
                    if (StdItem->Shape == 133)
                    {
                        boMoXieSuite2 = true;
                        m_nMoXieSuite += StdItem->AniCount;
                    }
                    if (StdItem->Shape == 136)
                    {
                        boHongMoSuite2 = true;
                        m_nHongMoSuite += StdItem->AniCount;
                    }
                    if (StdItem->Shape == 124)
                    {
                        boRecallSuite3 = true;
                    }
                    if (StdItem->Shape == 126)
                    {
                        boSpirit3 = true;
                    }
                    if (StdItem->Shape == 145)
                    {
                        m_boGuildMove = true;
                    }
                    if (StdItem->Shape == 134)
                    {
                        boMoXieSuite3 = true;
                        m_nMoXieSuite += StdItem->AniCount;
                    }
                    if (StdItem->Shape == 137)
                    {
                        boHongMoSuite3 = true;
                        m_nHongMoSuite += StdItem->AniCount;
                    }
                    if (StdItem->Shape == 125)
                    {
                        boRecallSuite4 = true;
                    }
                    if (StdItem->Shape == 129)
                    {
                        boSpirit4 = true;
                    }
                }
                nCode = 10;
                if (boRecallSuite1 && boRecallSuite2 && boRecallSuite3 && boRecallSuite4)
                {
                    m_boRecallSuite = true;
                }
                if (boMoXieSuite1 && boMoXieSuite2 && boMoXieSuite3)
                {
                    m_nMoXieSuite += 50;
                }
                if (boHongMoSuite1 && boHongMoSuite2 && boHongMoSuite3)
                {
                    m_AddAbil.wHitPoint += 2;
                }
                if (boSpirit1 && boSpirit2 && boSpirit3 && boSpirit4)
                {
                    m_bopirit = true;
                }
                nCode = 11;
                m_WAbil.Weight = RecalcBagWeight();
                if (m_boTransparent && (m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] > 0))
                {
                    m_boHideMode = true;
                }
                nCode = 120;
                if (m_boHideMode)
                {
                    if (!boOldHideMode)
                    {
                        nCode = 121;
                        m_nCharStatus = GetCharStatus();
                        nCode = 122;
                        StatusChanged("");
                    }
                }
                else
                {
                    if (boOldHideMode)
                    {
                        nCode = 123;// 8
                        m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 0;
                        m_nCharStatus = GetCharStatus();
                        nCode = 124;
                        StatusChanged("");
                    }
                }
                nCode = 125;
                nOldLight = m_nLight;
                if ((m_UseItems[TPosition.U_RIGHTHAND]->wIndex > 0) && (m_UseItems[TPosition.U_RIGHTHAND]->Dura > 0))
                {
                    m_nLight = 3;
                }
                else
                {
                    m_nLight = 0;
                }
                nCode = 127;
                if (nOldLight != m_nLight)
                {
                    SendRefMsg(Grobal2.RM_CHANGELIGHT, 0, 0, 0, 0, "");
                }
                nCode = 13;
                m_btSpeedPoint += (byte)m_AddAbil.wSpeedPoint;//����
                m_btHitPoint += (byte)m_AddAbil.wHitPoint;//׼ȷ
                m_btAntiPoison += (byte)m_AddAbil.wAntiPoison;//�ж����
                m_nPoisonRecover += (sbyte)m_AddAbil.wPoisonRecover;//�ж��ָ�
                m_nHealthRecover += (sbyte)m_AddAbil.wHealthRecover;//�����ָ�
                m_nSpellRecover += (sbyte)m_AddAbil.wSpellRecover;//ħ���ָ�
                m_nAntiMagic += (sbyte)m_AddAbil.wAntiMagic;//ħ�����
                m_nLuck += m_AddAbil.btLuck;// ���������ֵLuck (���ʻ���)
                m_nLuck -= m_AddAbil.btUnLuck;
                m_nHitSpeed = (sbyte)m_AddAbil.nHitSpeed;// �ٶ�
                nCode = 14;
                m_WAbil.MaxHP = HUtil32._MIN(Int32.MaxValue, m_Abil.MaxHP + m_AddAbil.wHP);// 21��Ѫ
                m_WAbil.MaxMP = HUtil32._MIN(Int32.MaxValue, m_Abil.MaxMP + m_AddAbil.wMP);
                m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(m_AddAbil.wAC) + HUtil32.LoWord(m_Abil.AC), HUtil32.HiWord(m_AddAbil.wAC) + HUtil32.HiWord(m_Abil.AC));
                m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(m_AddAbil.wMAC) + HUtil32.LoWord(m_Abil.MAC), HUtil32.HiWord(m_AddAbil.wMAC) + HUtil32.HiWord(m_Abil.MAC));
                m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_AddAbil.wDC) + HUtil32.LoWord(m_Abil.DC), HUtil32.HiWord(m_AddAbil.wDC) + HUtil32.HiWord(m_Abil.DC));
                m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(m_AddAbil.wMC) + HUtil32.LoWord(m_Abil.MC), HUtil32.HiWord(m_AddAbil.wMC) + HUtil32.HiWord(m_Abil.MC));
                m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(m_AddAbil.wSC) + HUtil32.LoWord(m_Abil.SC), HUtil32.HiWord(m_AddAbil.wSC) + HUtil32.HiWord(m_Abil.SC));
                m_WAbil.MaxWearWeight = (ushort)HUtil32.MakeLong(HUtil32.LoWord(m_AddAbil.wWearWeight) + HUtil32.LoWord(m_Abil.MaxWearWeight), HUtil32.HiWord(m_AddAbil.wWearWeight) + HUtil32.HiWord(m_Abil.MaxWearWeight));
                nCode = 15;// 9
                if (m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] > 0)
                {
                    m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.AC), HUtil32.HiWord(m_WAbil.AC) + 2 + (m_Abil.Level / 7));
                }
                if (m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] > 0)
                {
                    m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.MAC), HUtil32.HiWord(m_WAbil.MAC) + 2 + (m_Abil.Level / 7));
                }
                if (m_wStatusArrValue[11] > 0) // ��������
                {
                    m_btSpeedPoint += (byte)m_wStatusArrValue[11]; // ����
                }
                if (m_wStatusArrValue[0] > 0)
                {
                    m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.HiWord(m_WAbil.DC) + 2 + m_wStatusArrValue[0]);
                }
                if (m_wStatusArrValue[6] > 0)
                {
                    if (HUtil32.LoWord(m_WAbil.DC) > (HUtil32.HiWord(m_WAbil.DC) - m_wStatusArrValue[6]))
                    {
                        m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.LoWord(m_WAbil.DC));
                    }
                    else
                    {
                        m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.HiWord(m_WAbil.DC) - m_wStatusArrValue[6]);
                    }
                }
                if (m_wStatusArrValue[1] > 0)
                {
                    m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.MC), HUtil32.HiWord(m_WAbil.MC) + 2 + m_wStatusArrValue[1]);
                }
                if (m_wStatusArrValue[7] > 0)
                {
                    if (HUtil32.LoWord(m_WAbil.MC) > (HUtil32.HiWord(m_WAbil.MC) - m_wStatusArrValue[7]))
                    {
                        m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.MC), HUtil32.LoWord(m_WAbil.MC));
                    }
                    else
                    {
                        m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.MC), HUtil32.HiWord(m_WAbil.MC) - m_wStatusArrValue[7]);
                    }
                }
                nCode = 160;
                if (m_wStatusArrValue[2] > 0)
                {
                    m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.SC), HUtil32.HiWord(m_WAbil.SC) + m_wStatusArrValue[2]);
                }
                if (m_wStatusArrValue[8] > 0)
                {
                    if (HUtil32.LoWord(m_WAbil.SC) > (HUtil32.HiWord(m_WAbil.SC) - m_wStatusArrValue[8]))
                    {
                        m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.SC), HUtil32.LoWord(m_WAbil.SC));
                    }
                    else
                    {
                        m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.SC), HUtil32.HiWord(m_WAbil.SC) - m_wStatusArrValue[8]);
                    }
                }
                if (m_wStatusArrValue[3] > 0)
                {
                    m_nHitSpeed += (sbyte)m_wStatusArrValue[3];
                }
                if (m_wStatusArrValue[4] > 0)// ������������
                {
                    m_WAbil.MaxHP = HUtil32._MIN(Int32.MaxValue, m_WAbil.MaxHP + m_wStatusArrValue[4]);// 21��Ѫ
                }
                if (m_wStatusArrValue[5] > 0)
                {
                    m_WAbil.MaxMP = HUtil32._MIN(Int32.MaxValue, m_WAbil.MaxMP + m_wStatusArrValue[5]);
                }
                nCode = 161;
                if (m_boFlameRing)
                {
                    AddItemSkill(1);
                }
                else
                {
                    DelItemSkill(1);
                }
                nCode = 162;
                if (m_boRecoveryRing)
                {
                    AddItemSkill(2);
                }
                else
                {
                    DelItemSkill(2);
                }
                if (m_boYTPDRing)
                {
                    AddItemSkill(3);
                }
                else
                {
                    DelItemSkill(3);
                }
                if (m_boMeteorRing)
                {
                    AddItemSkill(4);
                }
                else
                {
                    DelItemSkill(4);
                }
                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER)
                    || (m_btRaceServer == Grobal2.RC_HEROOBJECT))//���Ӵ��У�ֻ������Ϊ����Ľ�ɫ�����¼��㹥������
                {
                    RecalcHitSpeed();
                }
                // ��ǰ������� ���ڸĵ����� 
                if (m_boMuscleRing) // ����
                {
                    m_WAbil.MaxWeight += m_WAbil.MaxWeight;
                    m_WAbil.MaxWearWeight += m_WAbil.MaxWearWeight;
                    m_WAbil.MaxHandWeight += m_WAbil.MaxHandWeight;
                }
                if (m_nMoXieSuite > 0) // ħѪ
                {
                    if (m_WAbil.MaxMP <= m_nMoXieSuite)
                    {
                        m_nMoXieSuite = m_WAbil.MaxMP - 1;
                    }
                    m_WAbil.MaxMP -= m_nMoXieSuite;
                    m_WAbil.MaxHP = HUtil32._MIN(Int32.MaxValue, m_WAbil.MaxHP + m_nMoXieSuite);// 21��Ѫ
                }
                nCode = 17;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    if (!((this) as TPlayObject).m_boNotOnlineAddExp)
                    {
                        SendUpdateMsg(this, Grobal2.RM_CHARSTATUSCHANGED, m_nHitSpeed, m_nCharStatus, 0, 0, "");
                    }
                }
                if ((m_btRaceServer >= Grobal2.RC_ANIMAL) && (m_btRaceServer != Grobal2.RC_PLAYMOSTER) &&
                    (m_btRaceServer != Grobal2.RC_HEROOBJECT) && (m_btRaceServer != 135))//135��Ҳ��ˢ������
                {
                    MonsterRecalcAbilitys();// ����ˢ��HP���޼�������
                }
                if (m_Magic67Skill != null) // ����Ԫ�����ӷ���,ħ������
                {
                    if (m_Abil.WineDrinkValue >= Math.Abs(m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue67 / 100))// �������ڻ���ھ������޵�5%ʱ����Ч
                    {
                        if (m_Magic67Skill->btLevel > 0)
                        {
                            m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.AC), HUtil32.HiWord(m_WAbil.AC) + m_Magic67Skill->btLevel * (m_Magic67Skill->btLevel + 1));
                            m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.MAC), HUtil32.HiWord(m_WAbil.MAC) + m_Magic67Skill->btLevel * (m_Magic67Skill->btLevel + 1));
                        }
                    }
                }
                nCode = 18;
                // ��ֹ�������޴�������
                if (HUtil32.LoWord(m_WAbil.AC) > HUtil32.HiWord(m_WAbil.AC))
                {
                    m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.AC), HUtil32.LoWord(m_WAbil.AC));
                }
                if (HUtil32.LoWord(m_WAbil.MAC) > HUtil32.HiWord(m_WAbil.MAC))
                {
                    m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.MAC), HUtil32.LoWord(m_WAbil.MAC));
                }
                if (HUtil32.LoWord(m_WAbil.DC) > HUtil32.HiWord(m_WAbil.DC))
                {
                    m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.LoWord(m_WAbil.DC));
                }
                if (HUtil32.LoWord(m_WAbil.MC) > HUtil32.HiWord(m_WAbil.MC))
                {
                    m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.MC), HUtil32.LoWord(m_WAbil.MC));
                }
                if (HUtil32.LoWord(m_WAbil.SC) > HUtil32.HiWord(m_WAbil.SC))
                {
                    m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.SC), HUtil32.LoWord(m_WAbil.SC));
                }
                //�����������
                m_WAbil.AC = HUtil32.MakeLong(HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.LoWord(m_WAbil.AC)), HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.HiWord(m_WAbil.AC)));
                m_WAbil.MAC = HUtil32.MakeLong(HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.LoWord(m_WAbil.MAC)), HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.HiWord(m_WAbil.MAC)));
                m_WAbil.DC = HUtil32.MakeLong(HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.LoWord(m_WAbil.DC)), HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.HiWord(m_WAbil.DC)));
                m_WAbil.MC = HUtil32.MakeLong(HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.LoWord(m_WAbil.MC)), HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.HiWord(m_WAbil.MC)));
                m_WAbil.SC = HUtil32.MakeLong(HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.LoWord(m_WAbil.SC)), HUtil32._MIN(M2Share.MAXHUMPOWER, HUtil32.HiWord(m_WAbil.SC)));
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.RecalcAbilitys Code:" + nCode);
            }
        }

        public void BreakOpenHealth()
        {
            if (m_boShowHP)
            {
                m_boShowHP = false;
                m_nCharStatusEx = m_nCharStatusEx ^ Grobal2.STATE_OPENHEATH;
                m_nCharStatus = GetCharStatus();
                SendRefMsg(Grobal2.RM_CLOSEHEALTH, 0, 0, 0, 0, "");
            }
        }

        public void MakeOpenHealth()
        {
            m_boShowHP = true;
            m_nCharStatusEx = m_nCharStatusEx | Grobal2.STATE_OPENHEATH;
            m_nCharStatus = GetCharStatus();
            SendRefMsg(Grobal2.RM_OPENHEALTH, 0, m_WAbil.HP, m_WAbil.MaxHP, 0, "");
        }

        /// <summary>
        /// ����HP,MP
        /// </summary>
        /// <param name="nHP"></param>
        /// <param name="nMP"></param>
        public void IncHealthSpell(int nHP, int nMP)
        {
            if ((nHP < 0) || (nMP < 0))
            {
                return;
            }
            if ((m_WAbil.HP + nHP) >= m_WAbil.MaxHP)
            {
                m_WAbil.HP = m_WAbil.MaxHP;
            }
            else
            {
                m_WAbil.HP += nHP;
            }
            if ((m_WAbil.MP + nMP) >= m_WAbil.MaxMP)
            {
                m_WAbil.MP = m_WAbil.MaxMP;
            }
            else
            {
                m_WAbil.MP += nMP;
            }
            HealthSpellChanged();
        }

        // �����ָ��Ч�������ָ�
        public unsafe void ItemDamageRevivalRing()
        {
            TStdItem* pSItem;
            int nDura;
            int tDura;
            TPlayObject PlayObject;
            for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                if (m_UseItems[I]->wIndex > 0)
                {
                    pSItem = UserEngine.GetStdItem(m_UseItems[I]->wIndex);
                    if (pSItem != null)
                    {
                        if ((new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem->Shape)) || (((I == TPosition.U_WEAPON)
                            || (I == TPosition.U_RIGHTHAND)) && (new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem->AniCount))))
                        {
                            nDura = m_UseItems[I]->Dura;
                            tDura = (int)HUtil32.Round((double)nDura / 1000);
                            nDura -= 1000;
                            if (nDura <= 0)
                            {
                                nDura = 0;
                                m_UseItems[I]->Dura = (byte)nDura;
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    PlayObject = ((this) as TPlayObject);
                                    PlayObject.SendDelItems(m_UseItems[I]);
                                }
                                m_UseItems[I]->wIndex = 0;
                                RecalcAbilitys();
                                CompareSuitItem(false);//��װ
                            }
                            else
                            {
                                m_UseItems[I]->Dura = (byte)nDura;
                            }
                            if (tDura != (int)HUtil32.Round((double)nDura / 1000))
                            {
                                SendMsg(this, Grobal2.RM_DURACHANGE, I, nDura, m_UseItems[I]->DuraMax, 0, "");
                            }
                        }
                    }
                }
            }
        }

        public virtual void Run()
        {
            bool boChg;
            bool boNeedRecalc;
            int nHP = 0;
            int nMP = 0;
            int n18 = 0;
            uint dwC = 0;
            uint dwInChsTime = 0;
            TProcessMessage ProcessMsg = null;
            byte nCheckCode = 0;
            int nInteger;
            bool boChangeColor;
            TFlowerEvent FlowerEvent;
            const string sExceptionMsg0 = "{�쳣} TBaseObject::Run 0 Code:";
            const string sExceptionMsg1 = "{�쳣} TBaseObject::Run 1 ";
            const string sExceptionMsg2 = "{�쳣} TBaseObject::Run 2";
            const string sExceptionMsg3 = "{�쳣} TBaseObject::Run 3 ";
            const string sExceptionMsg4 = "{�쳣} TBaseObject::Run 4 Code:{0}";
            const string sExceptionMsg5 = "{�쳣} TBaseObject::Run 5 Code:";
            const string sExceptionMsg6 = "{�쳣} TBaseObject::Run 6";
            uint dwRunTick = HUtil32.GetTickCount();
            try
            {
                ProcessMsg = new TProcessMessage();
                while (GetMessage(ProcessMsg))
                {
                    nCheckCode = 1;
                    Operate(ProcessMsg);
                    nCheckCode = 2;
                }
                Dispose(ProcessMsg);
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg0 + nCheckCode);
            }
            try
            {
                nCheckCode = 200;
                if (m_boSuperMan) // �޵�ģʽ
                {
                    m_WAbil.HP = m_WAbil.MaxHP;
                    m_WAbil.MP = m_WAbil.MaxMP;
                }
                if (((M2Share.nCrackedLevel != 0) || (M2Share.nErrorLevel != 0)) && (M2Share.dwStartTime > 36000))//60 * 60 * 10 �ƽ������10Сʱ��,���н�ɫ�޵�
                {
                    m_WAbil.HP = m_WAbil.MaxHP;
                    m_WAbil.MP = m_WAbil.MaxMP;
                }
                dwC = (HUtil32.GetTickCount() - m_dwHPMPTick) / 20;
                m_dwHPMPTick = HUtil32.GetTickCount();
                n18 = (int)dwC * (1 + m_nHealthRecover);
                m_nHealthTick += n18;
                n18 = (int)dwC * (1 + m_nSpellRecover);
                m_nSpellTick += n18;
                nCheckCode = 201;
                if (!m_boDeath) //�����ɫû�������򲻶�����HP��MPֵ
                {
                    if ((m_WAbil.HP < m_WAbil.MaxHP) && (m_nHealthTick >= GameConfig.nHealthFillTime)) //��������HPֵ
                    {
                        n18 = (m_WAbil.MaxHP / 75) + 1;
                        if ((m_WAbil.HP + n18) < m_WAbil.MaxHP)
                        {
                            m_WAbil.HP += n18;
                        }
                        else
                        {
                            m_WAbil.HP = m_WAbil.MaxHP;
                        }
                        nCheckCode = 3;
                        HealthSpellChanged();
                    }
                    nCheckCode = 202;
                    if ((m_WAbil.MP < m_WAbil.MaxMP) && (m_nSpellTick >= GameConfig.nSpellFillTime))// ��������MPֵ
                    {
                        n18 = (m_WAbil.MaxMP / 18) + 1;
                        if ((m_WAbil.MP + n18) < m_WAbil.MaxMP)
                        {
                            m_WAbil.MP += n18;
                        }
                        else
                        {
                            m_WAbil.MP = m_WAbil.MaxMP;
                        }
                        HealthSpellChanged();
                        nCheckCode = 4;
                    }
                    nCheckCode = 203;
                    if (m_WAbil.HP == 0)
                    {
                        if (m_LastHiter == null)
                        {
                            if (m_boRevival && (HUtil32.GetTickCount() - m_dwRevivalTick > GameConfig.dwRevivalTime)) // 60 * 1000
                            {
                                m_dwRevivalTick = HUtil32.GetTickCount();
                                ReAlive();// ����
                                nCheckCode = 9;
                                m_WAbil.HP = m_WAbil.MaxHP;
                                HealthSpellChanged();
                                nCheckCode = 5;
                                ItemDamageRevivalRing();
                                nCheckCode = 10;
                                if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                {
                                    // '�����ָ��Ч�������ָ�'
                                    ((THeroObject)(this)).SysMsg(GameMsgDef.g_sRevivalRecoverMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                                else
                                {
                                    // '�����ָ��Ч�������ָ�'
                                    SysMsg(GameMsgDef.g_sRevivalRecoverMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                        }
                        else if (m_LastHiter != null) // ������
                        {
                            if (!m_LastHiter.m_boUnRevival && m_boRevival && (HUtil32.GetTickCount() - m_dwRevivalTick > GameConfig.dwRevivalTime)) // 60 * 1000
                            {
                                m_dwRevivalTick = HUtil32.GetTickCount();
                                nCheckCode = 12;
                                ReAlive();// ����
                                m_WAbil.HP = m_WAbil.MaxHP;
                                HealthSpellChanged();
                                nCheckCode = 11;
                                ItemDamageRevivalRing();
                                nCheckCode = 13;
                                if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                {
                                    // '�����ָ��Ч�������ָ�'
                                    ((THeroObject)(this)).SysMsg(GameMsgDef.g_sRevivalRecoverMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                                else
                                {
                                    // '�����ָ��Ч�������ָ�'
                                    SysMsg(GameMsgDef.g_sRevivalRecoverMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                        }
                        nCheckCode = 14;
                        if ((m_WAbil.HP == 0) && !m_boGhost)
                        {
                            Die();
                        }
                    }
                    if (m_nHealthTick >= GameConfig.nHealthFillTime)
                    {
                        m_nHealthTick = 0;
                    }
                    if (m_nSpellTick >= GameConfig.nSpellFillTime)
                    {
                        m_nSpellTick = 0;
                    }
                    nCheckCode = 15;
                }
                else
                {
                    nCheckCode = 16;
                    if ((m_btRaceServer == Grobal2.RC_PLAYMOSTER) && (m_Master == null))
                    {
                        if ((HUtil32.GetTickCount() - m_dwDeathTick > GameConfig.dwMakeGhostPlayMosterTime))  // ���ι�ʬ������
                        {
                            if (((TPlayMonster)(this)).boIsDieEvent)
                            {
                                FlowerEvent = new TFlowerEvent(m_PEnvir, m_nCurrX, m_nCurrY, Grobal2.ET_DIEEVENT, 4000); // �����˳�������ʾ
                                M2Share.g_EventManager.AddEvent(FlowerEvent);
                            }
                            else
                            {
                                FlowerEvent = new TFlowerEvent(m_PEnvir, m_nCurrX, m_nCurrY, Grobal2.SM_HEROLOGOUT, 4000); // �����˳�������ʾ
                                M2Share.g_EventManager.AddEvent(FlowerEvent);
                            }
                            MakeGhost();
                        }
                    }
                    else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_Master != null))
                    {
                        if ((HUtil32.GetTickCount() - m_dwDeathTick > GameConfig.nMakeGhostHeroTime)) // Ӣ��ʬ������
                        {
                            MakeGhost();
                        }
                    }
                    else if ((m_btRaceServer >= 121 && m_btRaceServer <= 125) && (m_Master == null))
                    {
                        if ((HUtil32.GetTickCount() - m_dwDeathTick > GameConfig.dwMakeGhostPlayMosterTime)) // ���׹�����
                        {
                            MakeGhost();
                        }
                    }
                    else if ((HUtil32.GetTickCount() - m_dwDeathTick > GameConfig.dwMakeGhostTime))
                    {
                        MakeGhost();
                    }
                    nCheckCode = 17;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg1 + (nCheckCode).ToString() + " " + (m_btRaceServer).ToString());
            }
            // -------��ҩ ħ��ҩ ���ǵ������������Ѫ����ħ��ʼ   //-------
            try
            {
                if (!m_boDeath && ((m_nIncSpell > 0) || (m_nIncHealth > 0) || (m_nIncHealing > 0)))
                {
                    dwInChsTime = Convert.ToUInt32(600 - HUtil32._MIN(400, m_Abil.Level * 10));
                    if (((HUtil32.GetTickCount() - m_dwIncHealthSpellTick) >= dwInChsTime) && !m_boDeath)
                    {
                        dwC = (uint)HUtil32._MIN(200, (int)(HUtil32.GetTickCount() - m_dwIncHealthSpellTick - dwInChsTime));
                        m_dwIncHealthSpellTick = HUtil32.GetTickCount() + dwC;
                        if ((m_nIncSpell > 0) || (m_nIncHealth > 0) || (m_nPerHealing > 0))
                        {
                            if ((m_nPerHealth <= 0))
                            {
                                m_nPerHealth = 1;
                            }
                            if ((m_nPerSpell <= 0))
                            {
                                m_nPerSpell = 1;
                            }
                            if ((m_nPerHealing <= 0))
                            {
                                m_nPerHealing = 1;
                            }
                            if (m_nIncHealth < m_nPerHealth)
                            {
                                nHP = m_nIncHealth;
                                m_nIncHealth = 0;
                            }
                            else
                            {
                                nHP = m_nPerHealth;
                                m_nIncHealth -= m_nPerHealth;
                            }
                            if (m_nIncSpell < m_nPerSpell)
                            {
                                nMP = m_nIncSpell;
                                m_nIncSpell = 0;
                            }
                            else
                            {
                                nMP = m_nPerSpell;
                                m_nIncSpell -= m_nPerSpell;
                            }
                            if (m_nIncHealing < m_nPerHealing)
                            {
                                nHP += m_nIncHealing;
                                m_nIncHealing = 0;
                            }
                            else
                            {
                                nHP += m_nPerHealing;
                                m_nIncHealing -= m_nPerHealing;
                            }
                            m_nPerHealth = (m_Abil.Level / 10 + 5);
                            m_nPerSpell = (m_Abil.Level / 10 + 5);
                            m_nPerHealing = 5;
                            IncHealthSpell(nHP, nMP);
                            if (m_WAbil.HP == m_WAbil.MaxHP)
                            {
                                m_nIncHealth = 0;
                                m_nIncHealing = 0;
                            }
                            if (m_WAbil.MP == m_WAbil.MaxMP)
                            {
                                m_nIncSpell = 0;
                            }
                        }
                    }
                }
                else
                {
                    m_dwIncHealthSpellTick = HUtil32.GetTickCount();
                }
                // --------------��ҩ ħ��ҩ �Զ���Ѫ����ħ���� --------------
                if ((m_nHealthTick < -GameConfig.nHealthFillTime) && (m_WAbil.HP > 1))
                {
                    m_WAbil.HP -= 1;
                    m_nHealthTick += GameConfig.nHealthFillTime;
                    HealthSpellChanged(); // �ܲ�����Ѫ 
                }
                // ���HP/MPֵ�Ƿ�������ֵ�������򽵵͵�������С
                boNeedRecalc = false;
                if (m_WAbil.HP > m_WAbil.MaxHP)
                {
                    boNeedRecalc = true;
                    m_WAbil.HP = m_WAbil.MaxHP - 1;
                }
                if (m_WAbil.MP > m_WAbil.MaxMP)
                {
                    boNeedRecalc = true;
                    m_WAbil.MP = m_WAbil.MaxMP - 1;
                }
                if (boNeedRecalc)
                {
                    HealthSpellChanged();
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg2);
            }
            try
            {
                nCheckCode = 62;
                if ((m_TargetCret != null))//������ʿ��������뷿����ٳ��������ṥ������(����Ĺ���Ŀ��û���)
                {
                    if (((HUtil32.GetTickCount() - m_dwTargetFocusTick) > 30000) || m_TargetCret.m_boDeath || m_TargetCret.m_boGhost || (m_TargetCret.m_PEnvir != m_PEnvir)
                        || (Math.Abs(m_TargetCret.m_nCurrX - m_nCurrX) > 15) || (Math.Abs(m_TargetCret.m_nCurrY - m_nCurrY) > 15))
                    {
                        m_TargetCret = null;
                    }
                }
                nCheckCode = 63;
                try
                {
                    if ((m_LastHiter != null))
                    {
                        nCheckCode = 66;
                        if (((HUtil32.GetTickCount() - m_LastHiterTick) > 30000) || m_LastHiter.m_boDeath || m_LastHiter.m_boGhost)
                        {
                            nCheckCode = 67;
                            m_LastHiter = null;
                        }
                    }
                }
                catch
                {
                }
                nCheckCode = 64;
                try
                {
                    if ((m_ExpHitter != null))
                    {
                        nCheckCode = 65;
                        if (((HUtil32.GetTickCount() - m_ExpHitterTick) > 6000) || m_ExpHitter.m_boDeath || m_ExpHitter.m_boGhost)
                        {
                            nCheckCode = 68;
                            m_ExpHitter = null;
                        }
                    }
                }
                catch
                {
                }
                nCheckCode = 31;
                boChangeColor = true;
                if (m_nChangeColorType >= 0) // �����ɫ
                {
                    boChangeColor = false;
                    nCheckCode = 32;
                    if (m_nChangeColorType == 0)
                    {
                        nCheckCode = 33;
                        if (!m_boAutoChangeColor)
                        {
                            nCheckCode = 34;
                            m_boAutoChangeColor = true;
                            m_dwAutoChangeColorTick = HUtil32.GetTickCount();
                        }
                        nCheckCode = 35;
                        if (m_boAutoChangeColor && (HUtil32.GetTickCount() - m_dwAutoChangeColorTick > GameConfig.dwBBMonAutoChangeColorTime))
                        {
                            nCheckCode = 36;
                            m_dwAutoChangeColorTick = HUtil32.GetTickCount();
                            switch (m_nAutoChangeIdx)
                            {
                                case 0:
                                    nInteger = Grobal2.STATE_TRANSPARENT;
                                    break;
                                case 1:
                                    nInteger = Grobal2.POISON_STONE;
                                    break;
                                case 2:
                                    nInteger = Grobal2.POISON_DONTMOVE;
                                    break;
                                case 3:
                                    nInteger = Grobal2.POISON_68;
                                    break;
                                case 4:
                                    nInteger = Grobal2.POISON_DECHEALTH;
                                    break;
                                case 5:
                                    nInteger = Grobal2.POISON_LOCKSPELL;
                                    break;
                                case 6:
                                    nInteger = Grobal2.POISON_DAMAGEARMOR;
                                    break;
                                default:
                                    m_nAutoChangeIdx = 0;
                                    nInteger = Grobal2.STATE_TRANSPARENT;
                                    break;
                            }
                            nCheckCode = 37;
                            m_nAutoChangeIdx++;
                            m_nCharStatus = Convert.ToInt32((m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0));
                            StatusChanged("");// ״̬�ı�
                        }
                        nCheckCode = 38;
                        if (m_boFixColor && (m_nFixStatus != m_nCharStatus))
                        {
                            nCheckCode = 39;
                            switch (m_nFixColorIdx)
                            {
                                case 0:
                                    nInteger = Grobal2.STATE_TRANSPARENT;
                                    break;
                                case 1:
                                    nInteger = Grobal2.POISON_STONE;
                                    break;
                                case 2:
                                    nInteger = Grobal2.POISON_DONTMOVE;
                                    break;
                                case 3:
                                    nInteger = Grobal2.POISON_68;
                                    break;
                                case 4:
                                    nInteger = Grobal2.POISON_DECHEALTH;
                                    break;
                                case 5:
                                    nInteger = Grobal2.POISON_LOCKSPELL;
                                    break;
                                case 6:
                                    nInteger = Grobal2.POISON_DAMAGEARMOR;
                                    break;
                                default:
                                    m_nFixColorIdx = 0;
                                    nInteger = Grobal2.STATE_TRANSPARENT;
                                    break;
                            }
                            nCheckCode = 40;
                            m_nCharStatus = Convert.ToInt32((m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0));
                            //m_nCharStatus = (m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0);
                            m_nFixStatus = m_nCharStatus;
                            StatusChanged("");// ״̬�ı�
                        }
                    }
                    else
                    {
                        nCheckCode = 41;
                        m_boAutoChangeColor = false;// �̶���ɫ
                        m_boFixColor = true;
                        m_nFixColorIdx = m_nChangeColorType - 1;
                        if (m_boFixColor && (m_nFixStatus != m_nCharStatus))
                        {
                            nCheckCode = 42;
                            switch (m_nFixColorIdx)
                            {
                                case 0:
                                    nInteger = Grobal2.STATE_TRANSPARENT;
                                    break;
                                case 1:
                                    nInteger = Grobal2.POISON_STONE;
                                    break;
                                case 2:
                                    nInteger = Grobal2.POISON_DONTMOVE;
                                    break;
                                case 3:
                                    nInteger = Grobal2.POISON_68;
                                    break;
                                case 4:
                                    nInteger = Grobal2.POISON_DECHEALTH;
                                    break;
                                case 5:
                                    nInteger = Grobal2.POISON_LOCKSPELL;
                                    break;
                                case 6:
                                    nInteger = Grobal2.POISON_DAMAGEARMOR;
                                    break;
                                default:
                                    m_nFixColorIdx = 0;
                                    nInteger = Grobal2.STATE_TRANSPARENT;
                                    break;
                            }
                            nCheckCode = 43;
                            m_nCharStatus = Convert.ToInt32((m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0));
                            //m_nCharStatus = (m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0);
                            m_nFixStatus = m_nCharStatus;
                            StatusChanged("");// ״̬�ı�
                        }
                    }
                }
                nCheckCode = 44;
                if (m_Master != null)
                {
                    if (m_btRaceServer != Grobal2.RC_HEROOBJECT) // Ӣ�۳���,���б���������Ʒ
                    {
                        m_boNoItem = true;
                    }
                    nCheckCode = 45;// ������ɫ
                    if (m_boAutoChangeColor && (HUtil32.GetTickCount() - m_dwAutoChangeColorTick > GameConfig.dwBBMonAutoChangeColorTime) && boChangeColor)
                    {
                        nCheckCode = 46;
                        m_dwAutoChangeColorTick = HUtil32.GetTickCount();
                        switch (m_nAutoChangeIdx)
                        {
                            case 0:
                                nInteger = Grobal2.STATE_TRANSPARENT;
                                break;
                            case 1:
                                nInteger = Grobal2.POISON_STONE;
                                break;
                            case 2:
                                nInteger = Grobal2.POISON_DONTMOVE;
                                break;
                            case 3:
                                nInteger = Grobal2.POISON_68;
                                break;
                            case 4:
                                nInteger = Grobal2.POISON_DECHEALTH;
                                break;
                            case 5:
                                nInteger = Grobal2.POISON_LOCKSPELL;
                                break;
                            case 6:
                                nInteger = Grobal2.POISON_DAMAGEARMOR;
                                break;
                            default:
                                m_nAutoChangeIdx = 0;
                                nInteger = Grobal2.STATE_TRANSPARENT;
                                break;
                        }
                        nCheckCode = 47;
                        m_nAutoChangeIdx++;
                        m_nCharStatus = Convert.ToInt32((m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0));
                        // m_nCharStatus = (m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0);
                        StatusChanged("");// ״̬�ı�
                    }
                    nCheckCode = 48;
                    if (m_boFixColor && (m_nFixStatus != m_nCharStatus) && boChangeColor)
                    {
                        nCheckCode = 49;
                        switch (m_nFixColorIdx)
                        {
                            case 0:
                                nInteger = Grobal2.STATE_TRANSPARENT;
                                break;
                            case 1:
                                nInteger = Grobal2.POISON_STONE;
                                break;
                            case 2:
                                nInteger = Grobal2.POISON_DONTMOVE;
                                break;
                            case 3:
                                nInteger = Grobal2.POISON_68;
                                break;
                            case 4:
                                nInteger = Grobal2.POISON_DECHEALTH;
                                break;
                            case 5:
                                nInteger = Grobal2.POISON_LOCKSPELL;
                                break;
                            case 6:
                                nInteger = Grobal2.POISON_DAMAGEARMOR;
                                break;
                            default:
                                m_nFixColorIdx = 0;
                                nInteger = Grobal2.STATE_TRANSPARENT;
                                break;
                        }
                        nCheckCode = 50;
                        m_nCharStatus = Convert.ToInt32((m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0));
                        //m_nCharStatus = (m_nCharStatusEx & 0xFFFFF) | ((0x80000000 >> nInteger) | 0);
                        m_nFixStatus = m_nCharStatus;
                        StatusChanged("");
                    }
                    nCheckCode = 51;// ������������������������ (����������,Ӣ����Ҫ����ս��)
                    if (m_Master != null)
                    {
                        nCheckCode = 58;
                        if ((!m_Master.m_boGhost) && ((m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)))
                        {
                            nCheckCode = 59;
                            if (m_Master.m_boDeath && (HUtil32.GetTickCount() - m_Master.m_dwDeathTick > 1000))
                            {
                                nCheckCode = 52;
                                if (GameConfig.boMasterDieMutiny && (m_Master.m_LastHiter != null) && (HUtil32.Random(GameConfig.nMasterDieMutinyRate) == 0))
                                {
                                    nCheckCode = 53;
                                    if (m_btRaceServer != Grobal2.RC_HEROOBJECT)// ��Ӣ���⣬�����ѱ�
                                    {
                                        nCheckCode = 54;
                                        m_Master = null;
                                        m_btSlaveExpLevel = (byte)GameConfig.SlaveColor.GetUpperBound(0);
                                        RecalcAbilitys();
                                        m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC) * GameConfig.nMasterDieMutinyPower,
                                            HUtil32.HiWord(m_WAbil.DC) * GameConfig.nMasterDieMutinyPower);
                                        m_nWalkSpeed = m_nWalkSpeed / GameConfig.nMasterDieMutinySpeed;
                                        RefNameColor();
                                        RefShowName();
                                    }
                                    else
                                    {
                                        m_Master = null;  //��������,Ӣ��Ҳһ������
                                    }
                                }
                                else
                                {
                                    nCheckCode = 55;
                                    if (m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT) // ����(Ӣ��)����,Ӣ������Ҳһ������
                                    {
                                        if ((m_btRaceServer == Grobal2.RC_PLAYMOSTER))// �ջ�Ӣ�ۣ�Ӣ�۵ķ�����Ӣ��һ������ʧ
                                        {
                                            MakeGhost();
                                        }
                                        else
                                        {
                                            m_WAbil.HP = 0;
                                        }
                                    }
                                    if (m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                        {
                                            m_WAbil.HP = 0; //��������,Ӣ�ۡ�����Ҳһ������
                                        }
                                    }
                                }
                            }
                        }
                    }
                    nCheckCode = 56;
                    if (m_Master != null)
                    {
                        if (m_Master.m_boGhost && ((HUtil32.GetTickCount() - m_Master.m_dwGhostTick) > 1000))
                        {
                            nCheckCode = 57;
                            MakeGhost();
                        }
                    }
                }
                // ��������б����Ѿ��������ѱ�ı�����Ϣ
                nCheckCode = 183;
                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                {
                    for (int I = m_SlaveList.Count - 1; I >= 0; I--)
                    {
                        nCheckCode = 181;
                        if (m_SlaveList.Count <= 0)
                        {
                            break;
                        }
                        if (m_SlaveList[I] != null)
                        {
                            nCheckCode = 182;
                            if (m_SlaveList[I].m_boDeath || m_SlaveList[I].m_boGhost)
                            {
                                nCheckCode = 20;
                                m_SlaveList.RemoveAt(I);
                                m_dwLatest46Tick = HUtil32.GetTickCount();// �ٻ�������
                            }
                            else
                            {
                                nCheckCode = 187;
                                if (m_SlaveList[I].m_Master != null)
                                {
                                    nCheckCode = 188;
                                    if (m_SlaveList[I].m_Master != this)
                                    {
                                        nCheckCode = 189;
                                        m_SlaveList.RemoveAt(I);
                                        m_dwLatest46Tick = HUtil32.GetTickCount();// �ٻ�������
                                    }
                                }
                            }
                        }
                    }
                }
                nCheckCode = 184;
                if (m_boHolySeize && ((HUtil32.GetTickCount() - m_dwHolySeizeTick) > m_dwHolySeizeInterval))
                {
                    BreakHolySeizeMode();
                }
                nCheckCode = 185;
                if (m_boCrazyMode && ((HUtil32.GetTickCount() - m_dwCrazyModeTick) > m_dwCrazyModeInterval))
                {
                    BreakCrazyMode();
                }
                nCheckCode = 186;
                if (m_boShowHP && ((HUtil32.GetTickCount() - m_dwShowHPTick) > m_dwShowHPInterval))
                {
                    BreakOpenHealth();
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg3 + nCheckCode + "  Name:" + m_sCharName);
            }
            try
            {
                // ����PKֵ��ʼ
                if ((HUtil32.GetTickCount() - m_dwDecPkPointTick) > GameConfig.dwDecPkPointTime)// 120000
                {
                    m_dwDecPkPointTick = HUtil32.GetTickCount();
                    if (m_nPkPoint > 0)
                    {
                        DecPKPoint(GameConfig.nDecPkPointCount); // ����PKֵ����
                    }
                }
                // ���������Ʒ��PK״̬ ��ʼ
                nCheckCode = 24;
                if ((HUtil32.GetTickCount() - m_DecLightItemDrugTick) > GameConfig.dwDecLightItemDrugTime)
                {
                    m_DecLightItemDrugTick += GameConfig.dwDecLightItemDrugTime; // 1000
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        UseLamp();  // ʹ��������Ʒ
                        CheckPKStatus(); // ���PK״̬
                    }
                    else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)// Ӣ�ۻ�����Ϊ����
                    {
                        CheckPKStatus();// ���PK״̬
                    }
                    else if ((m_btRaceServer == Grobal2.RC_PLAYMOSTER) && (m_Master != null))// ���������Ϊ����
                    {
                        CheckPKStatus();// ���PK״̬
                    }
                }
                // ���������Ʒ��PK״̬ ����
                nCheckCode = 25;
                if (((HUtil32.GetTickCount() - m_dwCheckRoyaltyTick) > 10000) && (m_btRaceServer != Grobal2.RC_HEROOBJECT))// Ӣ�۲��ѱ�
                {
                    m_dwCheckRoyaltyTick = HUtil32.GetTickCount();
                    if (m_Master != null)
                    {
                        if ((m_btRaceServer != Grobal2.RC_PLAYMOSTER)) // �����ѱ�
                        {
                            if ((M2Share.g_dwSpiritMutinyTick > HUtil32.GetTickCount()) && (m_btSlaveExpLevel < 5))
                            {
                                m_dwMasterRoyaltyTick = 0;
                            }
                            // �����ѱ�  ��ʼ
                            nCheckCode = 26;
                            if ((HUtil32.GetTickCount() - m_dwMasterRoyaltyTime > m_dwMasterRoyaltyTick) && (m_Master != null))
                            {
                                if (!m_Master.m_boGhost)
                                {
                                    nCheckCode = 29;
                                    for (int I = m_Master.m_SlaveList.Count - 1; I >= 0; I--)
                                    {
                                        if (m_Master.m_SlaveList.Count <= 0)
                                        {
                                            break;
                                        }
                                        nCheckCode = 27;
                                        if (m_Master.m_SlaveList[I] == this)
                                        {
                                            nCheckCode = 28;
                                            m_Master.m_SlaveList.RemoveAt(I);
                                            m_Master.m_dwLatest46Tick = HUtil32.GetTickCount();// �ٻ�������
                                            break;
                                        }
                                    }
                                }
                                m_Master = null;
                                m_WAbil.HP = m_WAbil.HP / 10;
                                RefShowName();
                            }
                            // �����ѱ� ����
                            nCheckCode = 30;
                            if (m_dwMasterTick != 0)
                            {
                                if ((HUtil32.GetTickCount() - m_dwMasterTick) > 43200000) // 12 * 60 * 60 * 1000
                                {
                                    m_WAbil.HP = 0;
                                }
                            }
                        }
                        else
                        {
                            if ((HUtil32.GetTickCount() - m_dwMasterRoyaltyTime > m_dwMasterRoyaltyTick))  // ����ʱ�䵽ֱ����ʧ
                            {
                                for (int I = m_Master.m_SlaveList.Count - 1; I >= 0; I--)
                                {
                                    if (m_Master.m_SlaveList.Count <= 0)
                                    {
                                        break;
                                    }
                                    nCheckCode = 31;
                                    if (m_Master.m_SlaveList[I] == this)
                                    {
                                        nCheckCode = 32;
                                        m_Master.m_SlaveList.RemoveAt(I);
                                        m_Master.m_dwLatest46Tick = HUtil32.GetTickCount();// �ٻ�������
                                        break;
                                    }
                                }
                                m_Master = null;
                                FlowerEvent = new TFlowerEvent(m_PEnvir, m_nCurrX, m_nCurrY, Grobal2.SM_HEROLOGOUT, 4000);// �������ʱ�䵽����ʾ�˳�����(����Ӣ��һ��)
                                M2Share.g_EventManager.AddEvent(FlowerEvent);
                                m_WAbil.HP = 0;
                                MakeGhost();
                                nCheckCode = 33;
                            }
                        }
                    }
                }
                if ((HUtil32.GetTickCount() - m_dwVerifyTick) > 30000)// 30 * 1000
                {
                    m_dwVerifyTick = HUtil32.GetTickCount();
                    if (!m_boDenyRefStatus)
                    {
                        if (m_PEnvir != null)
                        {
                            m_PEnvir.VerifyMapTime(m_nCurrX, m_nCurrY, this);// ˢ���ڵ�ͼ��λ�õ�ʱ��
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg4, nCheckCode));
            }
            try
            {
                nCheckCode = 65;
                boChg = false;
                boNeedRecalc = false;
                for (int I = m_dwStatusArrTick.GetLowerBound(0); I <= m_dwStatusArrTick.GetUpperBound(0); I++)
                {
                    if ((m_wStatusTimeArr[I] > 0) && (m_wStatusTimeArr[I] < 60000))
                    {
                        if ((HUtil32.GetTickCount() - m_dwStatusArrTick[I]) > 1000)
                        {
                            m_wStatusTimeArr[I] -= 1;
                            m_dwStatusArrTick[I] += 1000;
                            nCheckCode = 66;
                            if ((m_wStatusTimeArr[I] == 0))
                            {
                                boChg = true;
                                switch (I)
                                {
                                    case Grobal2.STATE_TRANSPARENT:
                                        m_boHideMode = false;
                                        break;
                                    case Grobal2.STATE_DEFENCEUP:
                                        boNeedRecalc = true;
                                        if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.g_sDefenceUpTimeOver, TMsgColor.c_Green, TMsgType.t_Hint);// 20080602 Ӣ�ۼ���ʾ
                                        }
                                        else
                                        {
                                            SysMsg(GameMsgDef.g_sDefenceUpTimeOver, TMsgColor.c_Green, TMsgType.t_Hint); // '�������ظ�����'
                                        }
                                        break;
                                    case Grobal2.STATE_MAGDEFENCEUP:
                                        boNeedRecalc = true;
                                        if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.g_sMagDefenceUpTimeOver, TMsgColor.c_Green, TMsgType.t_Hint);  // Ӣ�ۼ���ʾ
                                        }
                                        else
                                        {
                                            SysMsg(GameMsgDef.g_sMagDefenceUpTimeOver, TMsgColor.c_Green, TMsgType.t_Hint); // 'ħ�����ظ�����'
                                        }
                                        break;
                                    case Grobal2.STATE_BUBBLEDEFENCEUP:// ��ħ����ֹͣ
                                        m_boAbilMagBubbleDefence = false;
                                        if (m_btMagBubbleDefenceLevel == 4)
                                        {
                                            StatusChanged("555");
                                        }
                                        break;
                                    case Grobal2.STATE_ProtectionDEFENCE:// 4����,������Ϣ���ͻ�����ʾ���е�Ч�� �������ʧЧ
                                        if (!m_boDeath && m_boProtectionDefence)
                                        {
                                            if (GameConfig.boShowProtectionEnv)
                                            {
                                                SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_PROTECTION_PIP, 0, 0, 0, ""); // ����û����������Ϣ
                                            }
                                            if ((!GameConfig.boAutoProtection))   // ���͵��ͻ����ƶ�Ч��ͼ��Ϣ
                                            {
                                                // '�������ʧЧ'
                                                SysMsg(GameMsgDef.g_sShieldTimeDisappearMsg, TMsgColor.c_Blue, TMsgType.t_Hint); // ��ʾ�û� û���Զ���������ʾ
                                            }
                                        }
                                        m_boProtectionDefence = false;// ������� ֹͣ
                                        m_boProtectionTick = HUtil32.GetTickCount();
                                        break;
                                    case Grobal2.STATE_LOCKRUN:// ������� ֹͣʱ�� 
                                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            ((this) as TPlayObject).m_boCanRun = true;// �Ƿ�������
                                        }
                                        if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            ((THeroObject)(this)).m_boCanRun = true;  // �Ƿ�������
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                nCheckCode = 67;
                for (int I = m_wStatusArrValue.GetLowerBound(0); I <= m_wStatusArrValue.GetUpperBound(0); I++)
                {
                    if (m_wStatusArrValue[I] > 0)
                    {
                        if (HUtil32.GetTickCount() > m_dwStatusArrTimeOutTick[I])
                        {
                            m_wStatusArrValue[I] = 0;
                            boNeedRecalc = true;
                            nCheckCode = 68;
                            switch (I)
                            {
                                case 0:
                                case 6:
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this)).SysMsg("(Ӣ��) �������ظ�����", TMsgColor.c_Green, TMsgType.t_Hint); // Ӣ�ۼ���ʾ
                                    }
                                    else
                                    {
                                        SysMsg("�������ظ�����", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    break;
                                case 1:
                                case 7:
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this)).SysMsg("(Ӣ��) ħ�����ظ�����", TMsgColor.c_Green, TMsgType.t_Hint); // Ӣ�ۼ���ʾ
                                    }
                                    else
                                    {
                                        SysMsg("ħ�����ظ�����", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    break;
                                case 2:
                                case 8:
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this)).SysMsg("(Ӣ��) �����ظ�����", TMsgColor.c_Green, TMsgType.t_Hint);   // Ӣ�ۼ���ʾ
                                    }
                                    else
                                    {
                                        SysMsg("�����ظ�����", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }

                                    m_dwStatusArrTimeOutTick[11] = HUtil32.GetTickCount();
                                    break;
                                case 3:
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT) // �޼��������
                                    {
                                        ((THeroObject)(this)).SysMsg("(Ӣ��) �����ٶȻظ�����", TMsgColor.c_Green, TMsgType.t_Hint);  // Ӣ�ۼ���ʾ
                                    }
                                    else
                                    {
                                        SysMsg("�����ٶȻظ�����", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    break;
                                case 4:
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this)).SysMsg("(Ӣ��) �����ظ�����", TMsgColor.c_Green, TMsgType.t_Hint);// Ӣ�ۼ���ʾ
                                    }
                                    else
                                    {
                                        SysMsg("�����ظ�����", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    break;
                                case 5:
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this)).SysMsg("(Ӣ��) ħ��ֵ�ظ�����", TMsgColor.c_Green, TMsgType.t_Hint); // Ӣ�ۼ���ʾ
                                    }
                                    else
                                    {
                                        SysMsg("ħ��ֵ�ظ�����", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    break;
                                case 11:
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this)).SysMsg("(Ӣ��) ���ݻظ�����", TMsgColor.c_Green, TMsgType.t_Hint); // �������ݶȻظ�����
                                    }
                                    else
                                    {
                                        SysMsg("���ݻظ�����", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (I)
                            {
                                case 9:
                                    DamageHealth(m_wStatusArrValue[I]);
                                    break;
                                case 10:
                                    DamageSpell(m_wStatusArrValue[I]);
                                    break;
                            }
                        }
                    }
                }
                nCheckCode = 69;
                if (boChg)
                {
                    m_nCharStatus = GetCharStatus();
                    StatusChanged("");
                }
                if (boNeedRecalc)
                {
                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                    {
                        nCheckCode = 70;
                        ((THeroObject)(this)).RecalcAbilitys();
                        ((THeroObject)(this)).CompareSuitItem(false);// ��װ
                        ((THeroObject)(this)).SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");// ����Ӣ������
                    }
                    else
                    {
                        nCheckCode = 71;
                        RecalcAbilitys();
                        CompareSuitItem(false);// ��װ
                        SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg5 + (nCheckCode).ToString());
            }
            nCheckCode = 72;
            try
            {
                if ((HUtil32.GetTickCount() - m_dwPoisoningTick) > GameConfig.dwPosionDecHealthTime)   // 2500
                {
                    m_dwPoisoningTick = HUtil32.GetTickCount();
                    if (m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] > 0)
                    {
                        nCheckCode = 73;
                        if (m_boAnimal)
                        {
                            m_nMeatQuality -= 1000;
                        }
                        DamageHealth(m_btGreenPoisoningPoint + 1);// �ж���Ѫ
                        m_nHealthTick = 0;
                        m_nSpellTick = 0;
                    }
                }
                nCheckCode = 74;
                M2Share.g_nBaseObjTimeMin = Convert.ToInt32(HUtil32.GetTickCount() - dwRunTick);
                if (M2Share.g_nBaseObjTimeMax < M2Share.g_nBaseObjTimeMin)
                {
                    M2Share.g_nBaseObjTimeMax = M2Share.g_nBaseObjTimeMin;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg6 + " nCode:" + (nCheckCode).ToString());
            }
        }

        // �������������ܶ� 
        public bool GetFrontPosition(ref int nX, ref int nY)
        {
            bool result;
            TEnvirnoment Envir;
            Envir = m_PEnvir;
            nX = m_nCurrX;
            nY = m_nCurrY;
            switch (m_btDirection)
            {
                case Grobal2.DR_UP:
                    if (nY > 0)
                    {
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_UPRIGHT:
                    if ((nX < (Envir.m_nWidth - 1)) && (nY > 0))
                    {
                        nX++;
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_RIGHT:
                    if (nX < (Envir.m_nWidth - 1))
                    {
                        nX++;
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    if ((nX < (Envir.m_nWidth - 1)) && (nY < (Envir.m_nHeight - 1)))
                    {
                        nX++;
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWN:
                    if (nY < (Envir.m_nHeight - 1))
                    {
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:
                    if ((nX > 0) && (nY < (Envir.m_nHeight - 1)))
                    {
                        nX -= 1;
                        nY++;
                    }
                    break;
                case Grobal2.DR_LEFT:
                    if (nX > 0)
                    {
                        nX -= 1;
                    }
                    break;
                case Grobal2.DR_UPLEFT:
                    if ((nX > 0) && (nY > 0))
                    {
                        nX -= 1;
                        nY -= 1;
                    }
                    break;
            }
            result = true;
            return result;
        }

        public bool SpaceMove_GetRandXY(TEnvirnoment Envir, ref int nX, ref int nY)
        {
            bool result;
            int n14;
            int n18;
            int n1C;
            result = false;
            if (Envir.m_nWidth < 80)
            {
                n18 = 3;
            }
            else
            {
                n18 = 10;
            }
            if (Envir.m_nHeight < 150)
            {
                if (Envir.m_nHeight < 50)
                {
                    n1C = 2;
                }
                else
                {
                    n1C = 15;
                }
            }
            else
            {
                n1C = 50;
            }
            n14 = 0;
            while (true)
            {
                if (Envir.CanWalk(nX, nY, true))
                {
                    result = true;
                    break;
                }
                if (nX < (Envir.m_nWidth - n1C - 1))
                {
                    nX += n18;
                }
                else
                {
                    nX = HUtil32.Random(Envir.m_nWidth);
                    if (nY < (Envir.m_nHeight - n1C - 1))
                    {
                        nY += n18;
                    }
                    else
                    {
                        nY = HUtil32.Random(Envir.m_nHeight);
                    }
                }
                n14++;
                if (n14 >= 201)
                {
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// ��ͼ�ƶ�
        /// </summary>
        /// <param name="sMAP"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nInt"></param>
        public void SpaceMove(string sMAP, int nX, int nY, int nInt)
        {
            TEnvirnoment Envir;
            TEnvirnoment OldEnvir;
            int nOldX;
            int nOldY;
            bool bo21;
            TPlayObject PlayObject;
            byte nCode;
            nCode = 0;
            try
            {
                Envir = M2Share.g_MapManager.FindMap(sMAP);
                nCode = 1;
                if (Envir != null)
                {
                    if (M2Share.nServerIndex == Envir.nServerIndex)
                    {
                        OldEnvir = m_PEnvir;
                        nOldX = m_nCurrX;
                        nOldY = m_nCurrY;
                        bo21 = false;
                        nCode = 2;
                        if (m_PEnvir.DeleteFromMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this) != 1)
                        {
                            DelMapCount();
                        }
                        nCode = 3;
                        m_VisibleHumanList.Clear();
                        nCode = 4;
                        if (m_VisibleItems.Count > 0)
                        {
                            for (int I = 0; I < m_VisibleItems.Count; I++)
                            {
                                if (m_VisibleItems[I] != null)
                                {
                                    Dispose(m_VisibleItems[I]);
                                }
                            }
                            m_VisibleItems.Clear();
                        }
                        nCode = 5;
                        if (m_VisibleActors.Count > 0)
                        {
                            for (int I = 0; I < m_VisibleActors.Count; I++)
                            {
                                try
                                {
                                    if (m_VisibleActors[I] != null)
                                    {
                                        Dispose(m_VisibleActors[I]);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            m_VisibleActors.Clear();
                        }
                        nCode = 6;
                        if (m_VisibleEvents.Count > 0)
                        {
                            for (int I = 0; I < m_VisibleEvents.Count; I++)
                            {
                                if (m_VisibleEvents[I] != null)
                                {
                                    Dispose(m_VisibleEvents[I]);
                                }
                            }
                            m_VisibleEvents.Clear();// �ƶ�ʱ����б�
                        }
                        nCode = 7;
                        m_PEnvir = Envir;
                        m_sMapName = Envir.sMapName;
                        m_nCurrX = nX;
                        m_nCurrY = nY;
                        nCode = 8;
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            TPlayObject m_PlayObject = (this) as TPlayObject;
                            if (m_PlayObject.m_boForMapShowHint && (m_PlayObject.m_dwUserTick[0] > 0))// ����ͼ�Ƿ���ʾ����ʱ��Ϣ
                            {
                                m_PlayObject.m_dwUserTick[0] = 0;
                                m_PlayObject.m_dwUserTick[3] = 0;
                                m_PlayObject.m_boForMapShowHint = false;// ����ʱ��Ϣ
                                SendMsg(this, Grobal2.RM_MOVEMESSAGE, 2, 255, 0, 1, "");// �رտͻ�����ʾ����ʱ(��ݼ��Ϸ���ʾ)
                            }
                            if (m_PlayObject.m_boShowExpCrystal)
                            {
                                m_PlayObject.m_boShowExpCrystal = false;
                                m_PlayObject.m_boGetExpCrystalExp = false;// �Ƿ������ȡ����// ����Ϣ�ر���ؽᾧͼ��
                                SendMsg(this, Grobal2.RM_OPENEXPCRYSTAL, 0, 1, 0, 0, "");
                            }
                        }
                        if (SpaceMove_GetRandXY(m_PEnvir, ref m_nCurrX, ref m_nCurrY))
                        {
                            nCode = 9;
                            m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                            SendMsg(this, Grobal2.RM_CLEAROBJECTS, 0, 0, 0, 0, "");
                            SendMsg(this, Grobal2.RM_CHANGEMAP, 0, 0, 0, 0, M2Share.g_MapManager.GetMainMap(Envir));// ��ȡ�ظ����õ�ͼ����
                            nCode = 10;
                            if (nInt == 1)
                            {
                                SendRefMsg(Grobal2.RM_SPACEMOVE_SHOW2, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                            }
                            else
                            {
                                SendRefMsg(Grobal2.RM_SPACEMOVE_SHOW, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                            }
                            m_dwMapMoveTick = HUtil32.GetTickCount();
                            m_bo316 = true;
                            bo21 = true;
                        }
                        if (!bo21)
                        {
                            m_PEnvir = OldEnvir;
                            m_nCurrX = nOldX;
                            m_nCurrY = nOldY;
                            nCode = 11;
                            m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                        }
                    }
                    else
                    {
                        nCode = 12;
                        if (SpaceMove_GetRandXY(Envir, ref nX, ref nY))
                        {
                            nCode = 13;
                            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                nCode = 14;
                                DisappearA();
                                m_bo316 = true;
                                PlayObject = ((this) as TPlayObject);
                                PlayObject.m_sSwitchMapName = Envir.sMapName;
                                PlayObject.m_nSwitchMapX = nX;
                                PlayObject.m_nSwitchMapY = nY;
                                PlayObject.m_boSwitchData = true;
                                PlayObject.m_nServerIndex = Envir.nServerIndex;
                                PlayObject.m_boEmergencyClose = true;
                                PlayObject.m_boReconnection = true;
                                PlayObject.m_boPlayOffLine = false;
                            }
                            else
                            {
                                KickException();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.SpaceMove Code:" + nCode);
            }
        }

        public bool SpaceMove2_GetRandXY(TEnvirnoment Envir, ref int nX, ref int nY)
        {
            bool result;
            int n14;
            int n18;
            int n1C;
            result = false;
            if (Envir.m_nWidth < 80)
            {
                n18 = 3;
            }
            else
            {
                n18 = 10;
            }
            if (Envir.m_nHeight < 150)
            {
                if (Envir.m_nHeight < 50)
                {
                    n1C = 2;
                }
                else
                {
                    n1C = 15;
                }
            }
            else
            {
                n1C = 50;
            }
            n14 = 0;
            while (true)
            {
                if (Envir.CanWalk(nX, nY, true))
                {
                    result = true;
                    break;
                }
                if (nX < (Envir.m_nWidth - n1C - 1))
                {
                    nX += n18;
                }
                else
                {
                    nX = HUtil32.Random(Envir.m_nWidth);
                    if (nY < (Envir.m_nHeight - n1C - 1))
                    {
                        nY += n18;
                    }
                    else
                    {
                        nY = HUtil32.Random(Envir.m_nHeight);
                    }
                }
                n14++;
                if (n14 >= 201)
                {
                    break;
                }
            }
            return result;
        }

        public void SpaceMove2(int nX, int nY, int nInt)
        {
            int nOldX;
            int nOldY;
            bool bo21;
            nOldX = m_nCurrX;
            nOldY = m_nCurrY;
            bo21 = false;
            if (m_PEnvir.DeleteFromMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this) != 1)
            {
                DelMapCount();
            }
            m_nCurrX = nX;
            m_nCurrY = nY;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                TPlayObject PlayObject = this as TPlayObject;
                if (PlayObject.m_boForMapShowHint && (PlayObject.m_dwUserTick[0] > 0))// ����ͼ�Ƿ���ʾ����ʱ��Ϣ
                {
                    PlayObject.m_dwUserTick[0] = 0;
                    PlayObject.m_dwUserTick[3] = 0;
                    PlayObject.m_boForMapShowHint = false;// ����ʱ��Ϣ
                    SendMsg(this, Grobal2.RM_MOVEMESSAGE, 2, 255, 0, 1, "");// �رտͻ�����ʾ����ʱ(��ݼ��Ϸ���ʾ)
                }
                if (PlayObject.m_boShowExpCrystal)
                {
                    PlayObject.m_boShowExpCrystal = false;
                    PlayObject.m_boGetExpCrystalExp = false;// �Ƿ������ȡ����
                    SendMsg(this, Grobal2.RM_OPENEXPCRYSTAL, 0, 1, 0, 0, "");// ����Ϣ�ر���ؽᾧͼ��
                }
            }
            if (SpaceMove2_GetRandXY(m_PEnvir, ref m_nCurrX, ref m_nCurrY))
            {
                m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                SendMsg(this, Grobal2.RM_CHANGEMAP, 0, 0, 0, 0, M2Share.g_MapManager.GetMainMap(m_PEnvir));
                if (nInt == 1)
                {
                    SendRefMsg(Grobal2.RM_SPACEMOVE_SHOW2, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                }
                else
                {
                    SendRefMsg(Grobal2.RM_SPACEMOVE_SHOW, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                }
                m_dwMapMoveTick = HUtil32.GetTickCount();
                m_bo316 = true;
                bo21 = true;
            }
            if (!bo21)
            {
                m_nCurrX = nOldX;
                m_nCurrY = nOldY;
                m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
            }
        }

        /// <summary>
        /// ˢ������
        /// </summary>
        public void RefShowName()
        {
            SendRefMsg(Grobal2.RM_USERNAME, 0, 0, 0, 0, GetShowName());
        }

        public virtual bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            int nDamage;
            int nTargetX = 0;
            int nTargetY = 0;
            byte nPower = 0;
            int nRage = 0;
            TBaseObject TargeTBaseObject = null;
            byte nCode = 0;
            const string sExceptionMsg = "{�쳣} TBaseObject::Operate Code:";
            try
            {
                if ((ProcessMsg == null) || (this == null))
                {
                    return result;
                }
                switch (ProcessMsg.wIdent)
                {
                    case Grobal2.RM_MAGSTRUCK:
                    case Grobal2.RM_MAGSTRUCK_MINE:
                        nCode = 1;
                        if ((ProcessMsg.wIdent == Grobal2.RM_MAGSTRUCK) && (m_btRaceServer >= Grobal2.RC_ANIMAL) && !bo2BF && (m_Abil.Level < 50))
                        {
                            m_dwWalkTick = m_dwWalkTick + 400 + (uint)HUtil32.Random(500);//�����У�С��50���Ĺ֣����������ٶ�
                        }
                        nCode = 11;
                        if (HUtil32.IntToObject<TBaseObject>(ProcessMsg.BaseObject) != null)
                        {
                            nDamage = GetMagStruckDamage(HUtil32.IntToObject<TBaseObject>(ProcessMsg.BaseObject), ProcessMsg.nParam1);// ����ѧ���ڹ����ħ�����ܲ����ӹ�����
                        }
                        else
                        {
                            nDamage = GetMagStruckDamage(null, ProcessMsg.nParam1);
                        }
                        if (nDamage > 0)
                        {
                            nCode = 12;
                            StruckDamage(nDamage);// �ܹ���,������װ���ĳ־�
                            nCode = 13;
                            HealthSpellChanged();
                            nCode = 14;
                            SendRefMsg(Grobal2.RM_STRUCK_MAG, nDamage, m_WAbil.HP, m_WAbil.MaxHP, ProcessMsg.BaseObject, "");
                            nCode = 15;
                            if (m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                            {
                                if (m_boAnimal)
                                {
                                    m_nMeatQuality -= nDamage * 1000;
                                }
                                nCode = 16;
                                SendMsg(this, Grobal2.RM_STRUCK, nDamage, m_WAbil.HP, m_WAbil.MaxHP, ProcessMsg.BaseObject, "");
                            }
                        }
                        if (m_boFastParalysis)
                        {
                            m_wStatusTimeArr[Grobal2.POISON_STONE] = 1;
                            m_boFastParalysis = false;
                        }
                        break;
                    case Grobal2.RM_MAGHEALING:
                        nCode = 2;
                        if ((m_nIncHealing + ProcessMsg.nParam1) < 300)
                        {
                            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                m_nIncHealing += ProcessMsg.nParam1;
                                m_nPerHealing = 5;
                            }
                            else
                            {
                                m_nIncHealing += ProcessMsg.nParam1;
                                m_nPerHealing = 5;
                            }
                        }
                        else
                        {
                            m_nIncHealing = 300;
                        }
                        break;
                    case Grobal2.RM_10101:
                        nCode = 3;
                        SendRefMsg(ProcessMsg.BaseObject, ProcessMsg.wParam, ProcessMsg.nParam1, ProcessMsg.nParam2, ProcessMsg.nParam3, ProcessMsg.sMsg);
                        if ((ProcessMsg.BaseObject == Grobal2.RM_STRUCK) && (m_btRaceServer != Grobal2.RC_PLAYOBJECT))
                        {
                            SendMsg(this, ProcessMsg.BaseObject, ProcessMsg.wParam, ProcessMsg.nParam1, ProcessMsg.nParam2, ProcessMsg.nParam3, ProcessMsg.sMsg);
                        }
                        if (m_boFastParalysis) // ������ԣ��ܹ��������������ʧ
                        {
                            m_wStatusTimeArr[Grobal2.POISON_STONE] = 1;
                            m_boFastParalysis = false;
                        }
                        break;
                    case Grobal2.RM_DELAYMAGIC:
                        nCode = 4;
                        nPower = (byte)ProcessMsg.wParam;
                        nTargetX = HUtil32.LoWord(ProcessMsg.nParam1);
                        nTargetY = HUtil32.HiWord(ProcessMsg.nParam1);
                        nRage = ProcessMsg.nParam2;
                        nCode = 41;
                        TargeTBaseObject = HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3);
                        nCode = 42;
                        if (TargeTBaseObject != null)
                        {
                            if (TargeTBaseObject.GetMagStruckDamage(this, nPower) > 0)
                            {
                                nCode = 43;
                                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)// ����Ӣ��������,����������
                                {
                                    nCode = 44;
                                    if (!((THeroObject)(this)).m_boTarget)
                                    {
                                        SetTargetCreat(TargeTBaseObject);
                                    }
                                }
                                else
                                {
                                    SetTargetCreat(TargeTBaseObject);
                                }
                                nCode = 45;
                                if (TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                                {
                                    nPower = (byte)HUtil32.Round((double)nPower / 1.2);
                                }
                                nCode = 46;
                                if ((Math.Abs(nTargetX - TargeTBaseObject.m_nCurrX) <= nRage) && (Math.Abs(nTargetY - TargeTBaseObject.m_nCurrY) <= nRage))
                                {
                                    TargeTBaseObject.SendMsg(this, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                                }
                            }
                        }
                        break;
                    case Grobal2.RM_10155:
                        nCode = 5;
                        MapRandomMove(ProcessMsg.sMsg, ProcessMsg.wParam);
                        break;
                    case Grobal2.RM_DELAYPUSHED:
                        nCode = 6;
                        nPower = (byte)ProcessMsg.wParam;
                        nRage = ProcessMsg.nParam2;
                        TargeTBaseObject = HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3);
                        if ((TargeTBaseObject != null))
                        {
                            TargeTBaseObject.CharPushed(nPower, nRage);
                        }
                        break;
                    case Grobal2.RM_POISON:
                        nCode = 7;
                        TargeTBaseObject = HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam2);
                        if (TargeTBaseObject != null)
                        {
                            if (IsProperTarget(TargeTBaseObject))
                            {
                                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    //����Ӣ��������,����������
                                    if ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))// Ӣ�ۻ�ɫ
                                    {
                                        SetPKFlag(TargeTBaseObject);
                                    }
                                    if (!((THeroObject)(this)).m_boTarget)
                                    {
                                        SetTargetCreat(TargeTBaseObject);
                                    }
                                }
                                else
                                {
                                    SetTargetCreat(TargeTBaseObject);
                                }
                                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) && ((TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) ||
                                    (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)))
                                {
                                    SetPKFlag(TargeTBaseObject);// Ӣ�ۻ�ɫ
                                }
                                SetLastHiter(TargeTBaseObject);
                            }
                            MakePosion(ProcessMsg.wParam, (ushort)ProcessMsg.nParam1, (byte)ProcessMsg.nParam3);
                        }
                        else
                        {
                            MakePosion(ProcessMsg.wParam, (ushort)ProcessMsg.nParam1, (byte)ProcessMsg.nParam3);
                        }
                        break;
                    case Grobal2.RM_TRANSPARENT:// 10308
                        nCode = 8;
                        M2Share.MagicManager.MagMakePrivateTransparent(this, ProcessMsg.nParam1);
                        break;
                    case Grobal2.RM_DOOPENHEALTH:// 10412
                        nCode = 9;
                        MakeOpenHealth();
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg + nCode);
            }
            return result;
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public int MakeSlave_GetSlaveCount()
        {
            int result = 0;
            TBaseObject BaseObject;
            if (m_SlaveList.Count <= 0)
            {
                return result;
            }
            for (int I = 0; I < m_SlaveList.Count; I++)
            {
                BaseObject = m_SlaveList[I];
                if (BaseObject.m_nCopyHumanLevel == 0)
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sMonName"></param>
        /// <param name="nMakeLevel"></param>
        /// <param name="nExpLevel"></param>
        /// <param name="nMaxMob"></param>
        /// <param name="dwRoyaltySec"></param>
        /// <returns></returns>
        public TBaseObject MakeSlave(string sMonName, int nMakeLevel, int nExpLevel, int nMaxMob, uint dwRoyaltySec)
        {
            TBaseObject result = null;
            int nX = 0;
            int nY = 0;
            TBaseObject MonObj;
            try
            {
                if (m_boGhost || m_boDeath)
                {
                    return result;
                }
                if (MakeSlave_GetSlaveCount() < nMaxMob)
                {
                    GetFrontPosition(ref nX, ref nY);
                    MonObj = UserEngine.RegenMonsterByName(m_PEnvir.sMapName, nX, nY, sMonName);
                    if (MonObj != null)
                    {
                        MonObj.m_Master = this;
                        MonObj.m_dwMasterRoyaltyTick = dwRoyaltySec * 1000;
                        MonObj.m_dwMasterRoyaltyTime = HUtil32.GetTickCount();
                        MonObj.m_btSlaveMakeLevel = (byte)nMakeLevel;
                        MonObj.m_btSlaveExpLevel = (byte)nExpLevel;
                        MonObj.RecalcAbilitys();
                        if (MonObj.m_WAbil.HP < MonObj.m_WAbil.MaxHP)
                        {
                            MonObj.m_WAbil.HP = MonObj.m_WAbil.HP + (MonObj.m_WAbil.MaxHP - MonObj.m_WAbil.HP) / 2;
                        }
                        MonObj.RefNameColor();//ˢ��������ɫ
                        m_SlaveList.Add(MonObj);
                        result = MonObj;
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        public bool RunTo(byte btDir, bool boFlag, int nDestX, int nDestY)
        {
            bool result = false;
            int nOldX;
            int nOldY;
            const string sExceptionMsg = "{�쳣} TBaseObject::RunTo";
            try
            {
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                m_btDirection = btDir;
                switch (btDir)
                {
                    case Grobal2.DR_UP:// 0
                        if ((m_nCurrY > 1) && (m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY - 1, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY - 2, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX, m_nCurrY - 2, true) > 0))
                        {
                            m_nCurrY -= 2;
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:// 1
                        if ((m_nCurrX < m_PEnvir.m_nWidth - 2) && (m_nCurrY > 1) && (m_PEnvir.CanWalkEx(m_nCurrX + 1, m_nCurrY - 1, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX + 2, m_nCurrY - 2, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX + 2, m_nCurrY - 2, true) > 0))
                        {
                            m_nCurrX += 2;
                            m_nCurrY -= 2;
                        }
                        break;
                    case Grobal2.DR_RIGHT:// 2
                        if ((m_nCurrX < m_PEnvir.m_nWidth - 2) && (m_PEnvir.CanWalkEx(m_nCurrX + 1, m_nCurrY, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX + 2, m_nCurrY, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX + 2, m_nCurrY, true) > 0))
                        {
                            m_nCurrX += 2;
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:// 3
                        if ((m_nCurrX < m_PEnvir.m_nWidth - 2) && (m_nCurrY < m_PEnvir.m_nHeight - 2) && (m_PEnvir.CanWalkEx(m_nCurrX + 1, m_nCurrY + 1, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX + 2, m_nCurrY + 2, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX + 2, m_nCurrY + 2, true) > 0))
                        {
                            m_nCurrX += 2;
                            m_nCurrY += 2;
                        }
                        break;
                    case Grobal2.DR_DOWN:// 4
                        if ((m_nCurrY < m_PEnvir.m_nHeight - 2) && (m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY + 1, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY + 2, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX, m_nCurrY + 2, true) > 0))
                        {
                            m_nCurrY += 2;
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:// 5
                        if ((m_nCurrX > 1) && (m_nCurrY < m_PEnvir.m_nHeight - 2) && (m_PEnvir.CanWalkEx(m_nCurrX - 1, m_nCurrY + 1, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX - 2, m_nCurrY + 2, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX - 2, m_nCurrY + 2, true) > 0))
                        {
                            m_nCurrX -= 2;
                            m_nCurrY += 2;
                        }
                        break;
                    case Grobal2.DR_LEFT:// 6
                        if ((m_nCurrX > 1) && (m_PEnvir.CanWalkEx(m_nCurrX - 1, m_nCurrY, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX - 2, m_nCurrY, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX - 2, m_nCurrY, true) > 0))
                        {
                            m_nCurrX -= 2;
                        }
                        break;
                    case Grobal2.DR_UPLEFT:// 7
                        if ((m_nCurrX > 1) && (m_nCurrY > 1) && (m_PEnvir.CanWalkEx(m_nCurrX - 1, m_nCurrY - 1, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX - 2, m_nCurrY - 2, GameConfig.boDiableHumanRun || ((m_btPermission > 9) && GameConfig.boGMRunAll)) || (GameConfig.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, m_nCurrX - 2, m_nCurrY - 2, true) > 0))
                        {
                            m_nCurrX -= 2;
                            m_nCurrY -= 2;
                        }
                        break;
                }
                if (((m_nCurrX != nOldX) || (m_nCurrY != nOldY)))
                {
                    if (Walk(Grobal2.RM_RUN))
                    {
                        result = true;
                    }
                    else
                    {
                        m_nCurrX = nOldX;
                        m_nCurrY = nOldY;
                        m_PEnvir.MoveToMovingObject(nOldX, nOldY, this, m_nCurrX, m_nCurrX, true);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            return result;
        }

        // ��ɱ��������
        public void ThrustingOnOff(bool boSwitch)
        {
            m_boUseThrusting = boSwitch;
            if (m_boUseThrusting)
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sThrustingOn, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sThrustingOn, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sThrustingOff, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sThrustingOff, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
        }

        // �����䵶����
        public void HalfMoonOnOff(bool boSwitch)
        {
            m_boUseHalfMoon = boSwitch;
            if (m_boUseHalfMoon)
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sHalfMoonOn, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sHalfMoonOn, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sHalfMoonOff, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sHalfMoonOff, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
        }

        // Բ���䵶����
        public void YuanYueOnOff(bool boSwitch)
        {
            m_bo90Kill = boSwitch;
            if (m_bo90Kill)
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sYuanYueOn, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sYuanYueOn, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sYuanYueOff, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sYuanYueOff, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
        }

        // Բ���䵶��/�ر�
        public void SkillCrsOnOff(bool boSwitch)
        {
            m_boCrsHitkill = boSwitch;
            if (m_boCrsHitkill)
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sCrsHitOn, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sCrsHitOn, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sCrsHitOff, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sCrsHitOff, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
        }

        // ����ն
        public bool Skill42OnOff()
        {
            bool result = false;
            if ((HUtil32.GetTickCount() - m_dwLatest42Tick) > GameConfig.nKill43UseTime * 1000)
            {
                m_dwLatest42Tick = HUtil32.GetTickCount();
                m_bo42kill = true;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sSkill42On, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sSkill42On, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sSkill42Off, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sSkill42Off, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        //����ն
        public bool Skill43OnOff()
        {
            bool result = false;
            if ((HUtil32.GetTickCount() - m_dwLatest43Tick) > GameConfig.nKill42UseTime * 1000)
            {
                m_dwLatest43Tick = HUtil32.GetTickCount();
                m_bo43kill = true;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sSkill43On, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sSkill43On, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sSkill43Off, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sSkill43Off, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        /// <summary>
        /// �һ𽣷�
        /// </summary>
        /// <returns></returns>
        public bool AllowFireHitSkill()
        {
            bool result = false;
            if ((HUtil32.GetTickCount() - m_dwLatestFireHitTick) > 10000)// 10 * 1000
            {
                m_dwLatestFireHitTick = HUtil32.GetTickCount();// �����һ���󹥻�ʱ��
                m_boFireHitSkill = true;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sFireSpiritsSummoned, TMsgColor.c_Green, TMsgType.t_Hint); // ��������������������
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sFireSpiritsSummoned, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sFireSpiritsFail, TMsgColor.c_Green, TMsgType.t_Hint);// �����һ�ʧ��
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sFireSpiritsFail, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        // ���ս���
        public virtual bool AllowDailySkill()
        {
            bool result = false;
            if ((HUtil32.GetTickCount() - m_dwLatestDailyTick) > 10000) // 10 * 1000
            {
                m_dwLatestDailyTick = HUtil32.GetTickCount();
                m_boDailySkill = true;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sDailySkillSummoned, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sDailySkillSummoned, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sDailySkillFail, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sDailySkillFail, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        // ��������
        public bool AllowYTPDHitSkill()
        {
            bool result = false;
            if ((HUtil32.GetTickCount() - m_dwLatestYTPDHitTick) > GameConfig.Magic69UseTime * 1000)
            {
                m_dwLatestYTPDHitTick = HUtil32.GetTickCount();// ��������������󹥻�ʱ��
                m_boYTPDHitSkill = true;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sYTPDSkillSummoned, TMsgColor.c_Green, TMsgType.t_Hint);// ���������ٻ��ɹ�
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + GameMsgDef.sYTPDSkillSummoned, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(string.Format(GameMsgDef.sYTPDNeedTick, GameConfig.Magic69UseTime - ((HUtil32.GetTickCount() - m_dwLatestYTPDHitTick) / 1000)), TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��) " + string.Format(GameMsgDef.sYTPDNeedTick, GameConfig.Magic69UseTime - ((HUtil32.GetTickCount() - m_dwLatestYTPDHitTick) / 1000)), TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        // Ѫ��һ��
        public bool AllowXPYJHitSkill()
        {
            bool result = false;
            if ((HUtil32.GetTickCount() - m_dwLatestXPYJHittick) > GameConfig.magic96usetime * 1000)
            {
                m_dwLatestXPYJHittick = HUtil32.GetTickCount();
                m_boXPYJHitSkill = true;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(GameMsgDef.sYTPDSkillSummoned, TMsgColor.c_Green, TMsgType.t_Hint); // Ѫ��һ���ٻ��ɹ�
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��)" + GameMsgDef.sXPYJSkillsummoned, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(string.Format(GameMsgDef.sXPYJNeedTick, GameConfig.magic96usetime - ((HUtil32.GetTickCount() - m_dwLatestXPYJHittick) / 1000)), TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).SysMsg("(Ӣ��)" + string.Format(GameMsgDef.sXPYJNeedTick, GameConfig.magic96usetime - ((HUtil32.GetTickCount() - m_dwLatestXPYJHittick) / 1000)), TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="NeedOpenBatter"></param>
        /// <returns></returns>
        public bool AllowBatterHitSkill(bool NeedOpenBatter)
        {
            bool result = false;
            if ((HUtil32.GetTickCount() - m_dwLatestBatterHitTick) > GameConfig.UseBatterTick)
            {
                if (!m_boSendShowBatterIcon)
                {
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_CANUSEBATTER, 1, 0, 0, 0, 0);
                        ((this) as TPlayObject).SendSocket(this.m_DefMsg, "");
                        m_boSendShowBatterIcon = true;
                    }
                }
                // ������Ϣ ʹ�ÿͻ�����ʾͼ��
                if (NeedOpenBatter)
                {
                    m_dwLatestBatterHitTick = HUtil32.GetTickCount();// ������������󹥻�ʱ��
                    m_boSendShowBatterIcon = false;
                    m_boUseBatter = true;
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        SysMsg(GameMsgDef.sBatterSummoned, TMsgColor.c_Green, TMsgType.t_Hint);// ����������
                    }
                    m_nBatter = 0;
                    result = true;
                }
            }
            else
            {
                if (NeedOpenBatter)
                {
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        SysMsg(string.Format(GameMsgDef.sBatterFail, (GameConfig.UseBatterTick - (HUtil32.GetTickCount()
                            - m_dwLatestBatterHitTick)) / 1000), TMsgColor.c_Green, TMsgType.t_Hint);// ������ʹ�û�ҪX��
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ��ͼ����ƶ�
        /// </summary>
        /// <param name="sMapName"></param>
        /// <param name="nInt"></param>
        public void MapRandomMove(string sMapName, int nInt)
        {
            int n10;
            int n14;
            int n18;
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMapName);
            if (Envir != null)
            {
                if (Envir.m_nHeight < 150)
                {
                    if (Envir.m_nHeight < 30)
                    {
                        n18 = 2;
                    }
                    else
                    {
                        n18 = 20;
                    }
                }
                else
                {
                    n18 = 50;
                }
                n10 = HUtil32.Random(Envir.m_nWidth - n18 - 1) + n18;
                n14 = HUtil32.Random(Envir.m_nHeight - n18 - 1) + n18;
                SpaceMove(sMapName, n10, n14, nInt);
            }
        }

        /// <summary>
        /// �����Ʒ����Ұ���
        /// </summary>
        /// <param name="UserItem"></param>
        /// <returns></returns>
        public unsafe virtual bool AddItemToBag(TUserItem* UserItem)
        {
            bool result = false;
            if (m_ItemList.Count < Grobal2.MAXBAGITEM)
            {
                m_ItemList.Add((IntPtr)UserItem);
                WeightChanged();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// �ж�������ʾ�ȼ�
        /// </summary>
        /// <param name="Magic"></param>
        public unsafe void sub_4C713C(TUserMagic* Magic)
        {
            if (Magic != null)
            {
                if (Magic->MagicInfo.wMagicId == 28)
                {
                    if (Magic->btLevel >= 2)
                    {
                        m_boAbilSeeHealGauge = true;
                    }
                }
            }
        }

        /// <summary>
        /// ȡ�������״̬
        /// </summary>
        /// <param name="nFlag"></param>
        /// <returns></returns>
        public int GetQuestFalgStatus(int nFlag)
        {
            int result;
            int n10;
            int n14;
            result = 0;
            nFlag -= 1;
            if (nFlag < 0)
            {
                return result;
            }
            n10 = nFlag / 8;
            n14 = (nFlag % 8);
            if ((n10 - m_QuestFlag.Length) < 0)
            {
                if (((128 >> n14) & m_QuestFlag[n10]) != 0)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// �����������״̬
        /// </summary>
        /// <param name="nFlag"></param>
        /// <param name="nValue"></param>
        public void SetQuestFlagStatus(int nFlag, int nValue)
        {
            int n10;
            int n14;
            byte bt15;
            nFlag -= 1;
            if (nFlag < 0)
            {
                return;
            }
            n10 = nFlag / 8;
            n14 = (nFlag % 8);
            if ((n10 - m_QuestFlag.Length) < 0)
            {
                bt15 = m_QuestFlag[n10];
                if (nValue == 0)
                {
                    m_QuestFlag[n10] = Convert.ToByte((~(128 >> n14)) & bt15);
                }
                else
                {
                    m_QuestFlag[n10] = Convert.ToByte((128 >> n14) | bt15);
                }
            }
        }

        /// <summary>
        /// ʹ��������Ʒ
        /// </summary>
        private unsafe void UseLamp()
        {
            int nOldDura;
            int nDura;
            TPlayObject PlayObject;
            TStdItem* StdItem;
            const string sExceptionMsg = "{�쳣} TBaseObject::UseLamp";
            try
            {
                if (m_UseItems[TPosition.U_RIGHTHAND]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(m_UseItems[TPosition.U_RIGHTHAND]->wIndex);
                    if ((StdItem == null) || (StdItem->Source != 0))
                    {
                        return;
                    }
                    nOldDura = (int)HUtil32.Round((double)m_UseItems[TPosition.U_RIGHTHAND]->Dura / 1000);
                    if (GameConfig.boDecLampDura)
                    {
                        nDura = m_UseItems[TPosition.U_RIGHTHAND]->Dura - 1;
                    }
                    else
                    {
                        nDura = m_UseItems[TPosition.U_RIGHTHAND]->Dura;
                    }
                    if (nDura <= 0)
                    {
                        m_UseItems[TPosition.U_RIGHTHAND]->Dura = 0;
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            PlayObject = ((this) as TPlayObject);
                            PlayObject.SendDelItems(m_UseItems[TPosition.U_RIGHTHAND]);
                        }
                        m_UseItems[TPosition.U_RIGHTHAND]->wIndex = 0;
                        m_nLight = 0;
                        SendRefMsg(Grobal2.RM_CHANGELIGHT, 0, 0, 0, 0, "");
                        SendMsg(this, Grobal2.RM_LAMPCHANGEDURA, 0, m_UseItems[TPosition.U_RIGHTHAND]->Dura, 0, 0, "");
                        RecalcAbilitys();
                        CompareSuitItem(false);//��װ
                        //FeatureChanged(); �����Ǳ��˲ſ��Կ����ģ�����Ҫ���͹㲥��Ϣ
                    }
                    else
                    {
                        m_UseItems[TPosition.U_RIGHTHAND]->Dura = (ushort)nDura;
                    }
                    if (nOldDura != (int)HUtil32.Round((double)nDura / 1000))
                    {
                        SendMsg(this, Grobal2.RM_LAMPCHANGEDURA, 0, m_UseItems[TPosition.U_RIGHTHAND]->Dura, 0, 0, "");
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        /// <summary>
        /// ȡ�������
        /// </summary>
        /// <returns></returns>
        public TBaseObject GetPoseCreate()
        {
            TBaseObject result = null;
            int nX = 0;
            int nY = 0;
            if (GetFrontPosition(ref nX, ref nY))
            {
                result = m_PEnvir.GetMovingObject(nX, nY, true);
            }
            return result;
        }

        // ����ɫ�������Ƿ���ָ����Χ����
        // TargeTBaseObject ΪҪ���Ľ�ɫ��nX,nY Ϊ�Ƚϵ�����
        // ����ɫ�Ƿ���ָ�������1x1 ��Χ���ڣ�������򷵻�True ���򷵻� False
        public bool CretInNearXY(TBaseObject TargeTBaseObject, int nX, int nY)
        {
            bool result = false;
            int I;
            int nCX;
            int nCY;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            if (m_PEnvir == null)
            {
                M2Share.MainOutMessage("CretInNearXY nil PEnvir");
                return result;
            }
            for (nCX = nX - 1; nCX <= nX + 1; nCX++)
            {
                for (nCY = nY - 1; nCY <= nY + 1; nCY++)
                {
                    if (m_PEnvir.GetMapCellInfo(nCX, nCY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                    {
                        if (MapCellInfo.ObjList.Count > 0)
                        {
                            for (I = 0; I < MapCellInfo.ObjList.Count; I++)
                            {
                                OSObject = MapCellInfo.ObjList[I];
                                if (OSObject != null)
                                {
                                    if (OSObject.btType == Grobal2.OS_MOVINGOBJECT)
                                    {
                                        BaseObject = (TBaseObject)OSObject.CellObj;
                                        if (BaseObject != null)
                                        {
                                            if (!BaseObject.m_boGhost && (BaseObject == TargeTBaseObject))
                                            {
                                                result = true;
                                                return result;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool CretInNearXY(TBaseObject TargeTBaseObject, int nX, int nY, int nRange)
        {
            bool result;
            int I;
            int nCX;
            int nCY;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            result = false;
            if (m_PEnvir == null)
            {
                M2Share.MainOutMessage("CretInNearXY nil PEnvir");
                return result;
            }
            for (nCX = nX - nRange; nCX <= nX + nRange; nCX++)
            {
                for (nCY = nY - nRange; nCY <= nY + nRange; nCY++)
                {
                    if (m_PEnvir.GetMapCellInfo(nCX, nCY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                    {
                        if (MapCellInfo.ObjList.Count > 0)
                        {
                            for (I = 0; I < MapCellInfo.ObjList.Count; I++)
                            {
                                OSObject = MapCellInfo.ObjList[I];
                                if (OSObject != null)
                                {
                                    if (OSObject.btType == Grobal2.OS_MOVINGOBJECT)
                                    {
                                        BaseObject = (TBaseObject)OSObject.CellObj;
                                        if (BaseObject != null)
                                        {
                                            if (!BaseObject.m_boGhost && (BaseObject == TargeTBaseObject))
                                            {
                                                result = true;
                                                return result;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// �������  ��Ӣ��,135����
        /// </summary>
        public void KillSlave()
        {
            TBaseObject Slave;
            if (m_SlaveList.Count > 0)
            {
                for (int I = 0; I < m_SlaveList.Count; I++)
                {
                    Slave = m_SlaveList[I];
                    if (Slave != null)
                    {
                        switch (Slave.m_btRaceServer)
                        {
                            // Modify the A .. B: 11 .. 65, 67 .. 99, 101 .. 107, 110 .. 111, 115 .. 120, 136, 150
                            case 11:
                            case 67:
                            case 101:
                            case 110:
                            case 115:
                            case 136:
                            case 150:
                                Slave.m_WAbil.HP = 0;
                                Slave.MakeGhost();
                                break;
                        }
                    }
                }
            }
        }

        // �����ڹ�����
        public void SendNGData()
        {
            int n14;
            int n15;
            int n16;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                n14 = (((this) as TPlayObject).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                n15 = (((this) as TPlayObject).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                n16 = ((this) as TPlayObject).m_NGLevel * 2 + (int)((this) as TPlayObject).m_dwIncAddNHPoint;
                ((this) as TPlayObject).m_MaxExpSkill69 = GetSkill69Exp(((this) as TPlayObject).m_NGLevel,
                    ref ((this) as TPlayObject).m_Skill69MaxNH);// ȡ�ڹ��ķ���������
                ((this) as TPlayObject).m_Skill69NH = ((this) as TPlayObject).m_Skill69MaxNH;
                ((this) as TPlayObject).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((this) as TPlayObject).m_Skill69NH,
                    ((this) as TPlayObject).m_Skill69MaxNH, 0, "");// ����ֵ�ñ��˿���
                SendMsg(this, Grobal2.RM_MAGIC69SKILLEXP, 0, HUtil32.MakeLong(n14, n15), 0, ((this) as TPlayObject).m_NGLevel,
                    EncryptUnit.EncodeString((this as TPlayObject).m_ExpSkill69.ToString() + "/" +
                    (((this) as TPlayObject).m_MaxExpSkill69).ToString() + "/" + (n16).ToString()));
            }
            else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                n14 = (((THeroObject)(this)).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                n15 = (((THeroObject)(this)).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                n16 = ((THeroObject)(this)).m_NGLevel * 2 + (int)((THeroObject)(this)).m_dwIncAddNHPoint;
                ((THeroObject)(this)).m_MaxExpSkill69 = GetSkill69Exp(((THeroObject)(this)).m_NGLevel,
                    ref ((THeroObject)(this)).m_Skill69MaxNH);// ȡ�ڹ��ķ���������
                ((THeroObject)(this)).m_Skill69NH = ((THeroObject)(this)).m_Skill69MaxNH;
                ((THeroObject)(this)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(this)).m_Skill69NH,
                    ((THeroObject)(this)).m_Skill69MaxNH, 0, "");// ����ֵ�ñ��˿���
                ((THeroObject)(this)).SendMsg(this, Grobal2.RM_HEROMAGIC69SKILLEXP, 0, HUtil32.MakeLong(n14, n15), 0,
                    ((THeroObject)(this)).m_NGLevel, EncryptUnit.EncodeString((((THeroObject)(this)).m_ExpSkill69).ToString() + "/"
                    + (((THeroObject)(this)).m_MaxExpSkill69).ToString() + "/" + (n16).ToString()));
            }
        }

        /// <summary>
        /// �����Ʒ���������Ƿ�����
        /// </summary>
        /// <param name="UserItem"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        public unsafe bool CheckIsOKItem(TUserItem* UserItem, int nType)
        {
            bool result = false;
            if (UserItem->btValue == null)
            {
                return result;
            }
            if (UserItem != null)
            {
                if ((UserItem->btValue[15] > 1) || (UserItem->btValue[16] > 1)
                    || (UserItem->btValue[17] > 1) || (UserItem->btValue[18] > 1)
                    || (UserItem->btValue[19] > 1))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// ʢ������װ��,��������ֵ      
        /// U_RINGR �ҽ�ָ
        /// U_RINGL ���ָ
        /// �·�������������
        /// </summary>
        /// <param name="nDamage"></param>
        /// <returns></returns>
        public unsafe int ItemStruckDamage(int nDamage)
        {
            int result;
            int nCount;
            TStdItem* StdItem;
            nCount = 0;// ����װ��������,��������ֵ�İٷֱ�
            try
            {
                for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                {
                    if (m_UseItems[I]->wIndex > 0)
                    {
                        StdItem = UserEngine.GetStdItem(m_UseItems[I]->wIndex);
                        if (StdItem != null)
                        {
                            switch (StdItem->StdMode)
                            {
                                case 15:
                                case 16:
                                case 19:
                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                case 24:
                                case 26:
                                case 30:
                                case 52:
                                case 54:
                                case 62:
                                case 64:// ͷ��,����,��ָ,����,Ь��,����,ѫ��
                                    if (StdItem->Shape == 188)
                                    {
                                        nCount = nCount + StdItem->Source + m_UseItems[I]->btValue[20];
                                    }
                                    break;
                            }
                        }
                    }
                }
                if (nCount > 100)
                {
                    nCount = 100;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.ItemStruckDamage");
            }
            result = (int)HUtil32.Round((double)nDamage * (100 - nCount) / 100);// ���˰ٷ���
            return result;
        }

        /// <summary>
        /// �ж��м���'|'��
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int CompareSuitItem_IsChar(string str)
        {
            int result;
            int I;
            result = 0;
            if (str.Length <= 0)
            {
                return result;
            }
            for (I = 1; I <= str.Length; I++)
            {
                if ((str[I] == '|'))
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// ��װ������װ���Ա�
        /// </summary>
        /// <param name="boHint">�Ƿ���봥����</param>
        public unsafe void CompareSuitItem(bool boHint)
        {
            TSuitItem SuitItem;
            int nCount;
            string Str = null;
            string Str1;
            TStdItem* StdItem;
            bool boSuitItem;
            List<string> Temp;
            ushort nMaxHP;
            ushort nMaxMP;
            byte nCode;
            nCode = 0;
            try
            {
                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) // Ӣ�ۺ��˲Ž�����װ���
                {
                    boSuitItem = false;
                    nMaxHP = 0;
                    nMaxMP = 0;
                    if (M2Share.SuitItemList.Count > 0)
                    {
                        nCode = 1;
                        for (int I = 0; I < M2Share.SuitItemList.Count; I++)
                        {
                            SuitItem = M2Share.SuitItemList[I];
                            nCode = 2;
                            if (SuitItem != null)
                            {
                                nCount = 0;
                                Str1 = SuitItem.Name;
                                nCode = 3;
                                Temp = new List<string>();
                                try
                                {
                                    for (int K = 0; K <= CompareSuitItem_IsChar(Str1); K++)
                                    {
                                        Str1 = HUtil32.GetValidStr3(Str1, ref Str, new string[] { "|" });
                                        if (Str != "")
                                        {
                                            Temp.Add(Str);
                                        }
                                    }
                                    nCode = 4;
                                    for (int J = m_UseItems.GetLowerBound(0); J <= m_UseItems.GetUpperBound(0); J++)
                                    {
                                        if (m_UseItems[J]->wIndex > 0)
                                        {
                                            StdItem = UserEngine.GetStdItem(m_UseItems[J]->wIndex);
                                            if (StdItem != null)
                                            {
                                                for (int K = Temp.Count - 1; K >= 0; K--)
                                                {
                                                    if (Temp.Count <= 0)
                                                    {
                                                        break;
                                                    }
                                                    Str = Temp[K];
                                                    if ((Str).ToLower().CompareTo((HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen)).ToLower()) == 0)
                                                    {
                                                        nCount++;
                                                        Temp.RemoveAt(K);
                                                        break;
                                                    }
                                                }
                                            }
                                            nCode = 5;
                                            if (nCount == SuitItem.ItemCount) // ����һ��
                                            {
                                                nMaxHP = (ushort)HUtil32._MIN(Int32.MaxValue, nMaxHP + (int)HUtil32.Round((double)m_WAbil.MaxHP * (SuitItem.MaxHP / 100)));// HP�������ӱ���
                                                nMaxMP = (ushort)HUtil32._MIN(Int32.MaxValue, nMaxMP + (int)HUtil32.Round((double)m_WAbil.MaxMP * (SuitItem.MaxMP / 100))); // MP�������ӱ���
                                                m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(SuitItem.MaxAC) + HUtil32.LoWord(m_WAbil.AC), SuitItem.AC + HUtil32.HiWord(m_WAbil.AC));// ����
                                                m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(SuitItem.MaxMAC) + HUtil32.LoWord(m_WAbil.MAC), SuitItem.MAC + HUtil32.HiWord(m_WAbil.MAC));// ħ��
                                                m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(SuitItem.MaxDC) + HUtil32.LoWord(m_WAbil.DC), SuitItem.DC + HUtil32.HiWord(m_WAbil.DC));   // ������
                                                m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(SuitItem.MaxMC) + HUtil32.LoWord(m_WAbil.MC), SuitItem.MC + HUtil32.HiWord(m_WAbil.MC)); // ħ��
                                                m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(SuitItem.MaxSC) + HUtil32.LoWord(m_WAbil.SC), SuitItem.SC + HUtil32.HiWord(m_WAbil.SC));//����
                                                m_btHitPoint += SuitItem.HitPoint; // ׼ȷ
                                                m_btSpeedPoint += SuitItem.SpeedPoint; // ����
                                                m_nHealthRecover += SuitItem.HealthRecover;// �����ָ�
                                                m_nSpellRecover += SuitItem.SpellRecover;// ħ���ָ�
                                                m_nLuck += SuitItem.RiskRate;// ���������ֵLuck (���ʻ���)
                                                m_nAntiMagic += SuitItem.nAntiMagic;// ħ�����
                                                m_btAntiPoison += SuitItem.nAntiPoison; // �ж����
                                                m_nPoisonRecover += SuitItem.nPoisonRecover;// �ж��ָ�
                                                m_nHongMoSuite += SuitItem.btReserved;// ��Ѫ(����)
                                                if (SuitItem.nPowerRate > 0)
                                                {
                                                    m_WAbil.DC = HUtil32.MakeLong((int)HUtil32.Round((double)HUtil32.LoWord(m_WAbil.DC) * (SuitItem.nPowerRate / 10)), (int)HUtil32.Round((double)HUtil32.HiWord(m_WAbil.DC) * (SuitItem.nPowerRate / 10)));
                                                }
                                                // ��������
                                                if (SuitItem.nMagicRate > 0)
                                                {
                                                    m_WAbil.MC = HUtil32.MakeLong((int)HUtil32.Round((double)HUtil32.LoWord(m_WAbil.MC) * (SuitItem.nMagicRate / 10)), (int)HUtil32.Round((double)HUtil32.HiWord(m_WAbil.MC) * (SuitItem.nMagicRate / 10)));
                                                }
                                                // ħ������
                                                if (SuitItem.nSCRate > 0)
                                                {
                                                    m_WAbil.SC = HUtil32.MakeLong((int)HUtil32.Round((double)HUtil32.LoWord(m_WAbil.SC) * (SuitItem.nSCRate / 10)), (int)HUtil32.Round((double)HUtil32.HiWord(m_WAbil.SC) * (SuitItem.nSCRate / 10)));
                                                }
                                                // ��������
                                                if (SuitItem.nACRate > 0)
                                                {
                                                    m_WAbil.AC = HUtil32.MakeLong((int)HUtil32.Round((double)HUtil32.LoWord(m_WAbil.AC) * (SuitItem.nACRate / 10)), (int)HUtil32.Round((double)HUtil32.HiWord(m_WAbil.AC) * (SuitItem.nACRate / 10)));
                                                }
                                                // ��������
                                                if (SuitItem.nMACRate > 0)
                                                {
                                                    m_WAbil.MAC = HUtil32.MakeLong((int)HUtil32.Round((double)HUtil32.LoWord(m_WAbil.MAC) * (SuitItem.nMACRate / 10)), (int)HUtil32.Round((double)HUtil32.HiWord(m_WAbil.MAC) * (SuitItem.nMACRate / 10)));
                                                }
                                                // ħ������
                                                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (SuitItem.nEXPRATE > 0))
                                                {
                                                    ((this) as TPlayObject).m_nItmeIncMonExpRate = (SuitItem.nEXPRATE - 1) * ((this) as TPlayObject).m_nOldKillMonExpRate;// ʹ����װ���ӵľ���
                                                    ((this) as TPlayObject).m_nKillMonExpRate = SuitItem.nEXPRATE * ((this) as TPlayObject).m_nOldKillMonExpRate;// ���鱶��
                                                }
                                                else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (SuitItem.nEXPRATE > 0))
                                                {
                                                    ((THeroObject)(this)).m_nKillMonExpRate = SuitItem.nEXPRATE * ((THeroObject)(this)).m_nOldKillMonExpRate;// ���鱶��
                                                }
                                                nCode = 6;
                                                if (SuitItem.boTeleport)// ����
                                                {
                                                    m_boTeleport = true;
                                                }
                                                if (SuitItem.boParalysis)// ���
                                                {
                                                    m_boParalysis = true;
                                                }
                                                if (SuitItem.boRevival)// ����
                                                {
                                                    m_boRevival = true;
                                                }
                                                if (SuitItem.boMagicShield)// ����
                                                {
                                                    m_boMagicShield = true;
                                                }
                                                if (SuitItem.boUnParalysis)// �����
                                                {
                                                    m_boUnParalysis = true;
                                                }
                                                nCode = 7;
                                                if ((M2Share.g_FunctionNPC != null) && boHint)
                                                {
                                                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                    {
                                                        M2Share.g_FunctionNPC.GotoLable(((this) as TPlayObject), "@SuitItem" + I, false);// ��װ����
                                                    }
                                                    else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_Master != null))
                                                    {
                                                        M2Share.g_FunctionNPC.GotoLable(((m_Master) as TPlayObject), "@SuitItem" + I, false);// ��װ����
                                                    }
                                                }
                                                boSuitItem = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                finally
                                {
                                    Dispose(Temp);
                                }
                            }
                        }
                        m_WAbil.MaxHP = HUtil32._MIN(Int32.MaxValue, m_WAbil.MaxHP + nMaxHP);// 21��Ѫ
                        m_WAbil.MaxMP = HUtil32._MIN(Int32.MaxValue, m_WAbil.MaxMP + nMaxMP);
                    }
                    nCode = 8;
                    if (!boSuitItem)// ��������װ,��ָ�ԭ���ľ��鱶��
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).m_nKillMonExpRate = ((this) as TPlayObject).m_nOldKillMonExpRate;
                            ((this) as TPlayObject).m_nItmeIncMonExpRate = 0;// ʹ����װ���ӵľ���
                        }
                        else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            ((THeroObject)(this)).m_nKillMonExpRate = ((THeroObject)(this)).m_nOldKillMonExpRate;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.CompareSuitItem Code:" + nCode);
            }
        }

        /// <summary>
        /// �жϰ���Ʒ������
        /// </summary>
        /// <param name="UserItem"></param>
        /// <param name="nType"></param>
        /// <returns></returns>
        public unsafe bool CheckItemValue(TUserItem* UserItem, int nType)
        {
            bool result = false;
            if (null == UserItem->btValue)
            {
                return result;
            }
            if (UserItem != null)
            {
                switch (nType)
                {
                    case 0:
                        if (UserItem->btValue[14] == 1) // ��ֹ��
                        {
                            result = true;
                        }
                        break;
                    case 1:
                        if (UserItem->btValue[15] == 1)// ��ֹ����
                        {
                            result = true;
                        }
                        break;
                    case 2:
                        if (UserItem->btValue[16] == 1)// ��ֹ��
                        {
                            result = true;
                        }
                        break;
                    case 3:
                        if (UserItem->btValue[17] == 1)// ��ֹ��
                        {
                            result = true;
                        }
                        break;
                    case 4:
                        if (UserItem->btValue[18] == 1) // ��ֹ����
                        {
                            result = true;
                        }
                        break;
                    case 5:
                        if (UserItem->btValue[19] == 1) // ��ֹ����
                        {
                            result = true;
                        }
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// ��ȡ����Ŀ�귽��
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="btDir"></param>
        /// <returns></returns>
        public bool GetAttackDir(TBaseObject BaseObject, ref byte btDir)
        {
            bool result = false;
            if ((m_nCurrX - 1 <= BaseObject.m_nCurrX) && (m_nCurrX + 1 >= BaseObject.m_nCurrX) && (m_nCurrY - 1 <= BaseObject.m_nCurrY)
                && (m_nCurrY + 1 >= BaseObject.m_nCurrY) && ((m_nCurrX != BaseObject.m_nCurrX) || (m_nCurrY != BaseObject.m_nCurrY)))
            {
                result = true;
                if (((m_nCurrX - 1) == BaseObject.m_nCurrX) && (m_nCurrY == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_LEFT;
                    return result;
                }
                if (((m_nCurrX + 1) == BaseObject.m_nCurrX) && (m_nCurrY == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_RIGHT;
                    return result;
                }
                if ((m_nCurrX == BaseObject.m_nCurrX) && ((m_nCurrY - 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_UP;
                    return result;
                }
                if ((m_nCurrX == BaseObject.m_nCurrX) && ((m_nCurrY + 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_DOWN;
                    return result;
                }
                if (((m_nCurrX - 1) == BaseObject.m_nCurrX) && ((m_nCurrY - 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_UPLEFT;
                    return result;
                }
                if (((m_nCurrX + 1) == BaseObject.m_nCurrX) && ((m_nCurrY - 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_UPRIGHT;
                    return result;
                }
                if (((m_nCurrX - 1) == BaseObject.m_nCurrX) && ((m_nCurrY + 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_DOWNLEFT;
                    return result;
                }
                if (((m_nCurrX + 1) == BaseObject.m_nCurrX) && ((m_nCurrY + 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_DOWNRIGHT;
                    return result;
                }
                btDir = 0;
            }
            return result;
        }

        /// <summary>
        /// �Ƿ��ڹ�����Χ֮��
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="btDir"></param>
        /// <returns></returns>
        public bool TargetInSpitRange(TBaseObject BaseObject, ref byte btDir)
        {
            bool result = false;
            int n14;
            int n18;
            if ((Math.Abs(BaseObject.m_nCurrX - m_nCurrX) <= 2) && (Math.Abs(BaseObject.m_nCurrY - m_nCurrY) <= 2))
            {
                n14 = BaseObject.m_nCurrX - m_nCurrX;
                n18 = BaseObject.m_nCurrY - m_nCurrY;
                if ((Math.Abs(n14) <= 1) && (Math.Abs(n18) <= 1))
                {
                    GetAttackDir(BaseObject, ref btDir);
                    result = true;
                    return result;
                }
                n14 += 2;
                n18 += 2;
                if (((n14 >= 0) && (n14 <= 4)) && ((n18 >= 0) && (n18 <= 4)))
                {
                    btDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
                    if (GameConfig.SpitMap[btDir, n18, n14] == 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ˢ�°�������
        /// </summary>
        /// <returns></returns>
        public unsafe ushort RecalcBagWeight()
        {
            ushort result = 0;
            TUserItem* UserItem;
            TStdItem* StdItem;
            byte nCode = 0;
            try
            {
                if (m_boDeath || m_boGhost)
                {
                    return result;
                }
                if (m_ItemList != null)
                {
                    if (m_ItemList.Count > 0)
                    {
                        nCode = 1;
                        for (int I = 0; I < m_ItemList.Count; I++)
                        {
                            nCode = 2;
                            UserItem = (TUserItem*)m_ItemList[I];
                            nCode = 3;
                            if (UserItem != null)
                            {
                                nCode = 4;
                                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                if (StdItem != null)
                                {
                                    nCode = 5;
                                    result += StdItem->Weight;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.RecalcBagWeight Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// ���¼��㹥������
        /// </summary>
        private unsafe void RecalcHitSpeed()
        {
            TUserMagic* UserMagic;
            TNakedAbility* BonusTick;
            try
            {
                BonusTick = null;
                switch (m_btJob)
                {
                    case 0:
                        fixed (TNakedAbility* item = &GameConfig.BonusAbilofWarr)
                        {
                            BonusTick = item;
                        }
                        break;
                    case 1:
                        fixed (TNakedAbility* item = &GameConfig.BonusAbilofWizard)
                        {
                            BonusTick = item;
                        }
                        break;
                    case 2:
                        fixed (TNakedAbility* item = &GameConfig.BonusAbilofTaos)
                        {
                            BonusTick = item;
                        }
                        break;
                }
                m_btHitPoint = Convert.ToByte(M2Share.DEFHIT + m_BonusAbil.Hit / BonusTick->Hit);
                switch (m_btJob)
                {
                    case M2Share.TAOS:
                        m_btSpeedPoint = Convert.ToByte(M2Share.DEFSPEED + m_BonusAbil.Speed / BonusTick->Speed + 3);
                        break;
                    default:
                        m_btSpeedPoint = Convert.ToByte(M2Share.DEFSPEED + m_BonusAbil.Speed / BonusTick->Speed);
                        break;
                }
                m_nHitPlus = 0;
                m_nHitDouble = 0;
                m_MagicOneSwordSkill = null;
                m_MagicPowerHitSkill = null;
                m_MagicErgumSkill = null;
                m_MagicBanwolSkill = null;
                m_MagicFireSwordSkill = null;
                m_Magic74Skill = null;// ���ս���
                m_MagicCrsSkill = null;
                m_Magic41Skill = null;
                m_Magic42Skill = null;
                m_Magic43Skill = null;
                m_Magic60Skill = null;
                m_Magic67Skill = null;// ����Ԫ��
                m_Magic68Skill = null;// ��������
                m_Magic75Skill = null;// �������
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    ((this) as TPlayObject).m_MagicSkill_200 = null;// ŭ֮��ɱ
                    ((this) as TPlayObject).m_MagicSkill_201 = null;// ��֮��ɱ
                    ((this) as TPlayObject).m_MagicSkill_202 = null;// ŭ֮����
                    ((this) as TPlayObject).m_MagicSkill_203 = null;// ��֮����
                    ((this) as TPlayObject).m_MagicSkill_204 = null;// ŭ֮�һ�
                    ((this) as TPlayObject).m_MagicSkill_205 = null;// ��֮�һ�
                    ((this) as TPlayObject).m_MagicSkill_206 = null;// ŭ֮����
                    ((this) as TPlayObject).m_MagicSkill_207 = null;// ��֮����
                    ((this) as TPlayObject).m_MagicSkill_208 = null;// ŭ֮����
                    ((this) as TPlayObject).m_MagicSkill_209 = null;// ��֮����
                    ((this) as TPlayObject).m_MagicSkill_210 = null;// ŭ֮�����
                    ((this) as TPlayObject).m_MagicSkill_211 = null;// ��֮�����
                    ((this) as TPlayObject).m_MagicSkill_212 = null;// ŭ֮��ǽ
                    ((this) as TPlayObject).m_MagicSkill_213 = null;// ��֮��ǽ
                    ((this) as TPlayObject).m_MagicSkill_214 = null;// ŭ֮������
                    ((this) as TPlayObject).m_MagicSkill_215 = null;// ��֮������
                    ((this) as TPlayObject).m_MagicSkill_216 = null;// ŭ֮�����Ӱ
                    ((this) as TPlayObject).m_MagicSkill_217 = null;// ��֮�����Ӱ
                    ((this) as TPlayObject).m_MagicSkill_218 = null;// ŭ֮���ѻ���
                    ((this) as TPlayObject).m_MagicSkill_219 = null;// ��֮���ѻ���
                    ((this) as TPlayObject).m_MagicSkill_220 = null;// ŭ֮������
                    ((this) as TPlayObject).m_MagicSkill_221 = null;// ��֮������
                    ((this) as TPlayObject).m_MagicSkill_222 = null;// ŭ֮�׵�
                    ((this) as TPlayObject).m_MagicSkill_223 = null;// ��֮�׵�
                    ((this) as TPlayObject).m_MagicSkill_224 = null;// ŭ֮�����׹�
                    ((this) as TPlayObject).m_MagicSkill_225 = null;// ��֮�����׹�
                    ((this) as TPlayObject).m_MagicSkill_226 = null;// ŭ֮������
                    ((this) as TPlayObject).m_MagicSkill_227 = null;// ��֮������
                    ((this) as TPlayObject).m_MagicSkill_228 = null;// ŭ֮�����
                    ((this) as TPlayObject).m_MagicSkill_229 = null;// ��֮�����
                    ((this) as TPlayObject).m_MagicSkill_230 = null;// ŭ֮���
                    ((this) as TPlayObject).m_MagicSkill_231 = null;// ��֮���
                    ((this) as TPlayObject).m_MagicSkill_232 = null;// ŭ֮��Ѫ
                    ((this) as TPlayObject).m_MagicSkill_233 = null;// ��֮��Ѫ
                    ((this) as TPlayObject).m_MagicSkill_234 = null;// ŭ֮���ǻ���
                    ((this) as TPlayObject).m_MagicSkill_235 = null;// ��֮���ǻ���
                    ((this) as TPlayObject).m_MagicSkill_236 = null;// ŭ֮�ڹ�����
                    ((this) as TPlayObject).m_MagicSkill_237 = null;// ��֮�ڹ�����
                    ((this) as TPlayObject).m_MagicSkill_76 = null;
                    ((this) as TPlayObject).m_MagicSkill_77 = null;
                    ((this) as TPlayObject).m_MagicSkill_78 = null;
                    ((this) as TPlayObject).m_MagicSkill_79 = null;
                    ((this) as TPlayObject).m_MagicSkill_80 = null;
                    ((this) as TPlayObject).m_MagicSkill_81 = null;
                    ((this) as TPlayObject).m_MagicSkill_82 = null;
                    ((this) as TPlayObject).m_MagicSkill_83 = null;
                    ((this) as TPlayObject).m_MagicSkill_84 = null;
                    ((this) as TPlayObject).m_MagicSkill_85 = null;
                    ((this) as TPlayObject).m_MagicSkill_86 = null;
                    ((this) as TPlayObject).m_MagicSkill_87 = null;
                    ((this) as TPlayObject).m_MagicSkill_69 = null;
                    ((this) as TPlayObject).m_MagicSkill_89 = null;
                    ((this) as TPlayObject).m_MagicSkill_90 = null;
                    ((this) as TPlayObject).m_MagicSkill_91 = null;
                    ((this) as TPlayObject).m_MagicSkill_92 = null;
                    ((this) as TPlayObject).m_MagicSkill_93 = null;
                    ((this) as TPlayObject).m_MagicSkill_94 = null;
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((THeroObject)(this)).m_Magic46Skill = null;// ������
                    ((THeroObject)(this)).m_MagicSkill_200 = null;// ŭ֮��ɱ
                    ((THeroObject)(this)).m_MagicSkill_201 = null;// ��֮��ɱ
                    ((THeroObject)(this)).m_MagicSkill_202 = null;// ŭ֮����
                    ((THeroObject)(this)).m_MagicSkill_203 = null;// ��֮����
                    ((THeroObject)(this)).m_MagicSkill_204 = null;// ŭ֮�һ�
                    ((THeroObject)(this)).m_MagicSkill_205 = null;// ��֮�һ�
                    ((THeroObject)(this)).m_MagicSkill_206 = null;// ŭ֮����
                    ((THeroObject)(this)).m_MagicSkill_207 = null;// ��֮����
                    ((THeroObject)(this)).m_MagicSkill_208 = null;// ŭ֮����
                    ((THeroObject)(this)).m_MagicSkill_209 = null;// ��֮����
                    ((THeroObject)(this)).m_MagicSkill_210 = null;// ŭ֮�����
                    ((THeroObject)(this)).m_MagicSkill_211 = null;// ��֮�����
                    ((THeroObject)(this)).m_MagicSkill_212 = null;// ŭ֮��ǽ
                    ((THeroObject)(this)).m_MagicSkill_213 = null;// ��֮��ǽ
                    ((THeroObject)(this)).m_MagicSkill_214 = null;// ŭ֮������
                    ((THeroObject)(this)).m_MagicSkill_215 = null;// ��֮������
                    ((THeroObject)(this)).m_MagicSkill_216 = null;// ŭ֮�����Ӱ
                    ((THeroObject)(this)).m_MagicSkill_217 = null;// ��֮�����Ӱ
                    ((THeroObject)(this)).m_MagicSkill_218 = null;// ŭ֮���ѻ���
                    ((THeroObject)(this)).m_MagicSkill_219 = null;// ��֮���ѻ���
                    ((THeroObject)(this)).m_MagicSkill_220 = null;// ŭ֮������
                    ((THeroObject)(this)).m_MagicSkill_221 = null;// ��֮������
                    ((THeroObject)(this)).m_MagicSkill_222 = null;// ŭ֮�׵�
                    ((THeroObject)(this)).m_MagicSkill_223 = null;// ��֮�׵�
                    ((THeroObject)(this)).m_MagicSkill_224 = null;// ŭ֮�����׹�
                    ((THeroObject)(this)).m_MagicSkill_225 = null;// ��֮�����׹�
                    ((THeroObject)(this)).m_MagicSkill_226 = null;// ŭ֮������
                    ((THeroObject)(this)).m_MagicSkill_227 = null;// ��֮������
                    ((THeroObject)(this)).m_MagicSkill_228 = null;// ŭ֮�����
                    ((THeroObject)(this)).m_MagicSkill_229 = null;// ��֮�����
                    ((THeroObject)(this)).m_MagicSkill_230 = null;// ŭ֮���
                    ((THeroObject)(this)).m_MagicSkill_231 = null;// ��֮���
                    ((THeroObject)(this)).m_MagicSkill_232 = null;// ŭ֮��Ѫ
                    ((THeroObject)(this)).m_MagicSkill_233 = null;// ��֮��Ѫ
                    ((THeroObject)(this)).m_MagicSkill_234 = null;// ŭ֮���ǻ���
                    ((THeroObject)(this)).m_MagicSkill_235 = null;// ��֮���ǻ���
                    ((THeroObject)(this)).m_MagicSkill_236 = null;// ŭ֮�ڹ�����
                    ((THeroObject)(this)).m_MagicSkill_237 = null;// ��֮�ڹ�����
                    ((THeroObject)(this)).m_MagicSkill_76 = null;
                    ((THeroObject)(this)).m_MagicSkill_77 = null;
                    ((THeroObject)(this)).m_MagicSkill_78 = null;
                    ((THeroObject)(this)).m_MagicSkill_79 = null;
                    ((THeroObject)(this)).m_MagicSkill_80 = null;
                    ((THeroObject)(this)).m_MagicSkill_81 = null;
                    ((THeroObject)(this)).m_MagicSkill_82 = null;
                    ((THeroObject)(this)).m_MagicSkill_83 = null;
                    ((THeroObject)(this)).m_MagicSkill_84 = null;
                    ((THeroObject)(this)).m_MagicSkill_85 = null;
                    ((THeroObject)(this)).m_MagicSkill_86 = null;
                    ((THeroObject)(this)).m_MagicSkill_87 = null;
                    ((THeroObject)(this)).m_MagicSkill_69 = null;
                }
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)m_MagicList[I];
                        if (UserMagic == null)
                        {
                            continue;
                        }
                        switch (UserMagic->wMagIdx)
                        {
                            case MagicConst.SKILL_ONESWORD:// ��������
                                m_MagicOneSwordSkill = UserMagic;
                                if (UserMagic->btLevel > 0)
                                {
                                    m_btHitPoint = Convert.ToByte(m_btHitPoint + HUtil32.Round((double)9 / 3 * UserMagic->btLevel));
                                }
                                break;
                            case MagicConst.SKILL_YEDO:// ��ɱ����
                                m_MagicPowerHitSkill = UserMagic;
                                if (UserMagic->btLevel > 0)
                                {
                                    m_btHitPoint = Convert.ToByte(m_btHitPoint + HUtil32.Round((double)3 / 3 * UserMagic->btLevel));
                                }
                                m_nHitPlus = Convert.ToSByte(M2Share.DEFHIT + UserMagic->btLevel);
                                m_btAttackSkillCount = Convert.ToByte(7 - UserMagic->btLevel);
                                m_btAttackSkillPointCount = Convert.ToByte(HUtil32.Random(m_btAttackSkillCount));
                                break;
                            case MagicConst.SKILL_ERGUM:// ��ɱ����
                                m_MagicErgumSkill = UserMagic;
                                break;
                            case MagicConst.SKILL_BANWOL:// �����䵶
                                m_MagicBanwolSkill = UserMagic;
                                break;
                            case MagicConst.SKILL_FIRESWORD:// �һ𽣷�
                                m_MagicFireSwordSkill = UserMagic;
                                m_nHitDouble = Convert.ToSByte(4 + UserMagic->btLevel * 4);
                                break;
                            case MagicConst.SKILL_74:// ���ս���
                                m_Magic74Skill = UserMagic;
                                break;
                            case MagicConst.SKILL_ILKWANG:// ������ս��
                                m_MagicOneSwordSkill = UserMagic;
                                if (UserMagic->btLevel > 0)
                                {
                                    m_btHitPoint = Convert.ToByte(m_btHitPoint + HUtil32.Round((double)8 / 3 * UserMagic->btLevel));
                                }
                                break;
                            case MagicConst.SKILL_40:// �����䵶
                                m_MagicCrsSkill = UserMagic;
                                break;
                            case MagicConst.SKILL_41:// ʨ�Ӻ�
                                m_Magic41Skill = UserMagic;
                                break;
                            case MagicConst.SKILL_42:// ����ն
                                m_Magic42Skill = UserMagic;
                                break;
                            case MagicConst.SKILL_43:// ��Ӱ����
                                m_Magic43Skill = UserMagic;
                                break;
                            case MagicConst.SKILL_46:// ������
                                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_Magic46Skill = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_67:// ����Ԫ��
                                m_Magic67Skill = UserMagic;
                                m_Magic67Skill->nTranPoint = m_Abil.MaxAlcohol;
                                break;
                            case MagicConst.SKILL_68:// ��������
                                m_Magic68Skill = UserMagic;
                                if (m_Magic68Skill != null)
                                {
                                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        if (((this) as TPlayObject).m_MaxExp68 <= 0)
                                        {
                                            ((this) as TPlayObject).m_MaxExp68 = (UInt16)GetSkill68Exp(UserMagic->btLevel); // ����������������
                                        }
                                        if (m_Magic68Skill->btLevel < 100)// ���;������徭��
                                        {
                                            //SendMsg(this, Grobal2.RM_MAGIC68SKILLEXP, 0, 0, 0, 0, EDcode.Units.EDcode.EncodeString((((this) as TPlayObject).m_Exp68).ToString() + "/" + (((this) as TPlayObject).m_MaxExp68).ToString()));
                                        }
                                    }
                                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT) // Ӣ��
                                    {
                                        if (((THeroObject)(this)).m_MaxExp68 <= 0)
                                        {
                                            ((THeroObject)(this)).m_MaxExp68 = GetSkill68Exp(UserMagic->btLevel);// ����������������
                                        }
                                        if (m_Magic68Skill->btLevel < 100)  // ���;������徭��
                                        {
                                            //SendMsg(this, Grobal2.RM_HEROMAGIC68SKILLEXP, 0, 0, 0, 0, EDcode.Units.EDcode.EncodeString((((THeroObject)(this)).m_Exp68).ToString() + "/" + (((THeroObject)(this)).m_MaxExp68).ToString()));
                                        }
                                    }
                                }
                                break;
                            case MagicConst.SKILL_75:// �������
                                m_Magic75Skill = UserMagic;
                                break;
                            case MagicConst.SKILL_76:
                                m_MagicSkill_76 = UserMagic;
                                break;
                            case MagicConst.SKILL_77:
                                m_MagicSkill_77 = UserMagic;
                                break;
                            case MagicConst.SKILL_78:
                                m_MagicSkill_78 = UserMagic;
                                break;
                            case MagicConst.SKILL_79:
                                m_MagicSkill_79 = UserMagic;
                                break;
                            case MagicConst.SKILL_80:
                                m_MagicSkill_80 = UserMagic;
                                break;
                            case MagicConst.SKILL_81:
                                m_MagicSkill_81 = UserMagic;
                                break;
                            case MagicConst.SKILL_82:
                                m_MagicSkill_82 = UserMagic;
                                break;
                            case MagicConst.SKILL_83:
                                m_MagicSkill_83 = UserMagic;
                                break;
                            case MagicConst.SKILL_84:
                                m_MagicSkill_84 = UserMagic;
                                break;
                            case MagicConst.SKILL_85:
                                m_MagicSkill_85 = UserMagic;
                                break;
                            case MagicConst.SKILL_86:
                                m_MagicSkill_86 = UserMagic;
                                break;
                            case MagicConst.SKILL_87:
                                m_MagicSkill_87 = UserMagic;
                                break;
                            case MagicConst.SKILL_69:
                                m_MagicSkill_69 = UserMagic;
                                break;
                            case MagicConst.SKILL_88:
                                m_MagicSkill_88 = UserMagic;
                                if (UserMagic->btLevel > 0)
                                {
                                    m_btHitPoint = Convert.ToByte(m_btHitPoint + HUtil32.Round((double)10 / 3 * UserMagic->btLevel));
                                }
                                break;
                            case MagicConst.SKILL_89:
                                m_MagicSkill_89 = UserMagic;
                                break;
                            case MagicConst.SKILL_90:
                                m_MagicSkill_90 = UserMagic;
                                break;
                            case MagicConst.SKILL_91:
                                m_MagicSkill_91 = UserMagic;
                                break;
                            case MagicConst.SKILL_92:
                                m_MagicSkill_92 = UserMagic;
                                break;
                            case MagicConst.SKILL_93:
                                m_MagicSkill_93 = UserMagic;
                                break;
                            case MagicConst.SKILL_94:
                                m_MagicSkill_94 = UserMagic;
                                break;
                            case MagicConst.SKILL_200:// ŭ֮��ɱ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_200 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_200 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_201:// ��֮��ɱ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_201 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_201 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_202:// ŭ֮����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_202 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_202 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_203:// ��֮����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_203 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_203 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_204:// ŭ֮�һ�
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_204 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_204 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_205:// ��֮�һ�
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_205 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_205 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_206:// ŭ֮����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_206 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_206 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_207:// ��֮����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_207 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_207 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_208:// ŭ֮����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_208 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_208 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_209:// ��֮����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_209 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_209 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_210:// ŭ֮�����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_210 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_210 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_211:// ��֮�����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_211 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_211 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_212:// ŭ֮��ǽ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_212 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_212 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_213:// ��֮��ǽ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_213 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_213 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_214:// ŭ֮������
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_214 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_214 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_215:// ��֮������
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_215 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_215 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_216:// ŭ֮�����Ӱ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_216 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_216 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_217:// ��֮�����Ӱ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_217 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_217 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_218:// ŭ֮���ѻ���
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_218 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_218 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_219:// ��֮���ѻ���
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_219 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_219 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_220:// ŭ֮������
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_220 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_220 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_221:// ��֮������
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_221 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_221 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_222:// ŭ֮�׵�
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_222 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_222 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_223:// ��֮�׵�
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_223 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_223 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_224:// ŭ֮�����׹�
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_224 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_224 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_225:// ��֮�����׹�
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_225 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_225 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_226:// ŭ֮������
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_226 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_226 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_227:// ��֮������
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_227 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_227 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_228:// ŭ֮�����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_228 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_228 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_229:// ��֮�����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_229 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_229 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_230:// ŭ֮���
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_230 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_230 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_231:// ��֮���
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_231 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_231 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_232:// ŭ֮��Ѫ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_232 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_232 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_233:// ��֮��Ѫ
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_233 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_233 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_234:// ŭ֮���ǻ���
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_234 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_234 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_235:// ��֮���ǻ���
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_235 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_235 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_236:// ŭ֮�ڹ�����(ս+������)
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_236 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_236 = UserMagic;
                                }
                                break;
                            case MagicConst.SKILL_237:// ��֮�ڹ�����
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    ((this) as TPlayObject).m_MagicSkill_237 = UserMagic;
                                }
                                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    ((THeroObject)(this)).m_MagicSkill_237 = UserMagic;
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.RecalcHitSpeed");
            }
        }

        private unsafe void AddItemSkill(int nIndex)
        {
            TMagic* Magic;
            TUserMagic* UserMagic = null;
            Magic = null;
            switch (nIndex)
            {
                case 1:
                    Magic = UserEngine.FindMagic(GameConfig.sFireBallSkill);
                    break;
                case 2:
                    Magic = UserEngine.FindMagic(GameConfig.sHealSkill);
                    break;
                case 3:
                    Magic = UserEngine.FindMagic(GameConfig.sHeavenSKill);
                    break;
                case 4:
                    Magic = UserEngine.FindMagic(GameConfig.MeteorSKill);
                    break;
            }
            if (Magic != null)
            {
                if (!IsTrainingSkill(Magic->wMagicId))
                {
                    UserMagic->MagicInfo = *Magic;
                    UserMagic->wMagIdx = Magic->wMagicId;
                    UserMagic->btKey = 0;
                    UserMagic->btLevel = 1;
                    UserMagic->nTranPoint = 0;
                    m_MagicList.Add((IntPtr)UserMagic);
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        ((this) as TPlayObject).SendAddMagic(UserMagic);
                    }
                }
            }
        }

        private bool AddToMap()
        {
            bool result = false;
            var Point = m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
            if (Point != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            if (!m_boFixedHideMode)
            {
                SendRefMsg(Grobal2.RM_TURN, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            }
            return result;
        }

        public unsafe int AttackDir_GetMagicSpell(TUserMagic* UserMagic)
        {
            return (int)HUtil32.Round((double)UserMagic->MagicInfo.wSpell / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1));
        }

        /// <summary>
        /// �����������״̬
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void AttackDir_CheckWeaponUpgradeStatus(TUserItem* UserItem)
        {
            if ((UserItem->btValue[0] + UserItem->btValue[1] + UserItem->btValue[2]) < GameConfig.nUpgradeWeaponMaxPoint)
            {
                if (HUtil32.rangeInDefined(UserItem->btValue[10], 1, 1))
                {
                    UserItem->wIndex = 0; // ��0 ɾ��װ�� 
                }
                if (HUtil32.rangeInDefined(UserItem->btValue[10], 10, 12))
                {
                    UserItem->btValue[0] = Convert.ToByte(UserItem->btValue[0] + UserItem->btValue[10] - 9);
                    if (UserItem->btValue[0] > GameConfig.nUpgradeWeaponMaxPoint)
                    {
                        UserItem->btValue[0] = (byte)GameConfig.nUpgradeWeaponMaxPoint;
                    }
                }
                if (HUtil32.rangeInDefined(UserItem->btValue[10], 20, 22))
                {
                    UserItem->btValue[1] = Convert.ToByte((byte)UserItem->btValue[1] + UserItem->btValue[10] - 19);
                    if (UserItem->btValue[1] > GameConfig.nUpgradeWeaponMaxPoint)
                    {
                        UserItem->btValue[1] = (byte)GameConfig.nUpgradeWeaponMaxPoint;
                    }
                }
                if (HUtil32.rangeInDefined(UserItem->btValue[10], 30, 32))
                {
                    UserItem->btValue[2] = Convert.ToByte((byte)UserItem->btValue[2] + UserItem->btValue[10] - 29);
                    if (UserItem->btValue[2] > GameConfig.nUpgradeWeaponMaxPoint)
                    {
                        UserItem->btValue[2] = (byte)GameConfig.nUpgradeWeaponMaxPoint;// ��������
                    }
                }
            }
            else
            {
                UserItem->wIndex = 0;
            }
            UserItem->btValue[10] = 0;
        }

        /// <summary>
        /// �����������
        /// </summary>
        public unsafe void AttackDir_CheckWeaponUpgrade()
        {
            TUserItem* UseItems;
            TPlayObject PlayObject;
            TStdItem* StdItem;
            if (m_UseItems[TPosition.U_WEAPON]->btValue[10] > 0)
            {
                UseItems = m_UseItems[TPosition.U_WEAPON];
                AttackDir_CheckWeaponUpgradeStatus(m_UseItems[TPosition.U_WEAPON]);
                if (m_UseItems[TPosition.U_WEAPON]->wIndex == 0)
                {
                    SysMsg(GameMsgDef.g_sTheWeaponBroke, TMsgColor.c_Red, TMsgType.t_Hint);
                    PlayObject = ((this) as TPlayObject);
                    PlayObject.SendDelItems(UseItems);
                    SendRefMsg(Grobal2.RM_BREAKWEAPON, 0, 0, 0, 0, "");
                    StdItem = UserEngine.GetStdItem(UseItems->wIndex);
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("21" + "\09" + m_sMapName + "\09" + (m_nCurrX).ToString() + "\09" + (m_nCurrY).ToString() + "\09"
                            + m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + (UseItems->MakeIndex).ToString() + "\09" + "(" + (HUtil32.LoWord(StdItem->DC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")"
                            + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/"
                            + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")"
                            + (UseItems->btValue[0]).ToString() + "/" + (UseItems->btValue[1]).ToString() + "/" + (UseItems->btValue[2]).ToString() + "/"
                            + (UseItems->btValue[3]).ToString() + "/" + (UseItems->btValue[4]).ToString() + "/" + (UseItems->btValue[5]).ToString() + "/"
                            + (UseItems->btValue[6]).ToString() + "/" + (UseItems->btValue[7]).ToString() + "/" + (UseItems->btValue[8]).ToString() + "/"
                            + (UseItems->btValue[14]).ToString() + "\09" + "0");
                    }
                    FeatureChanged();// ���������ɹ�
                }
                else
                {
                    SysMsg(GameMsgDef.sTheWeaponRefineSuccessfull, TMsgColor.c_Green, TMsgType.t_Hint);   // �޸������ɹ�����ɫ
                    PlayObject = ((this) as TPlayObject);
                    PlayObject.SendUpdateItem(m_UseItems[TPosition.U_WEAPON]);
                    StdItem = UserEngine.GetStdItem(UseItems->wIndex);
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("20" + "\09" + m_sMapName + "\09" + (m_nCurrX).ToString() + "\09" + (m_nCurrY).ToString() + "\09" + m_sCharName
                            + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + (UseItems->MakeIndex).ToString() + "\09" + "(" + (HUtil32.LoWord(StdItem->DC)).ToString() + "/"
                            + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MC)).ToString()
                            + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString()
                            + ")" + (UseItems->btValue[0]).ToString() + "/" + (UseItems->btValue[1]).ToString() + "/" + (UseItems->btValue[2]).ToString()
                            + "/" + (UseItems->btValue[3]).ToString() + "/" + (UseItems->btValue[4]).ToString() + "/" + (UseItems->btValue[5]).ToString()
                            + "/" + (UseItems->btValue[6]).ToString() + "/" + (UseItems->btValue[7]).ToString() + "/" + (UseItems->btValue[8]).ToString()
                            + "/" + (UseItems->btValue[14]).ToString() + "\09" + "0");
                    }
                    RecalcAbilitys();
                    CompareSuitItem(false);// ��װ������װ���Ա� 
                    SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                    SendMsg(this, Grobal2.RM_SUBABILITY, 0, 0, 0, 0, "");
                }
            }
        }

        /// <summary>
        /// ����Ŀ��
        /// ��˴��й�ϵ
        /// </summary>
        /// <param name="TargeTBaseObject"></param>
        /// <param name="wHitMode"></param>
        /// <param name="nDir"></param>
        public unsafe virtual void AttackDir(TBaseObject TargeTBaseObject, ushort wHitMode, int nDir)
        {
            TBaseObject AttackTarget;
            bool boPowerHit;
            bool boFireHit;
            bool bo42;
            bool bo43;
            bool bo74;
            ushort wIdent;
            int nCheckCode = 0;
            int n1;
            const string sExceptionMsg = "{�쳣} TBaseObject::AttackDir Code: {0}";
            try
            {
                if ((wHitMode == 5) && (m_MagicBanwolSkill != null))// ���¼���
                {
                    if (m_WAbil.MP > 0)
                    {
                        nCheckCode = 1;
                        DamageSpell(m_MagicBanwolSkill->MagicInfo.btDefSpell + AttackDir_GetMagicSpell(m_MagicBanwolSkill));
                        nCheckCode = 2;
                        HealthSpellChanged();
                        nCheckCode = 3;
                    }
                    else
                    {
                        wHitMode = Grobal2.RM_HIT;
                    }
                }
                if ((wHitMode == 8) && (m_MagicCrsSkill != null)) // �����䵶����
                {
                    if (m_WAbil.MP > 0)
                    {
                        nCheckCode = 10;
                        DamageSpell(m_MagicCrsSkill->MagicInfo.btDefSpell + AttackDir_GetMagicSpell(m_MagicCrsSkill));
                        nCheckCode = 12;
                        HealthSpellChanged();
                        nCheckCode = 13;
                    }
                    else
                    {
                        wHitMode = Grobal2.RM_HIT;
                    }
                }
                nCheckCode = 4;
                m_btDirection = (byte)nDir;
                if (TargeTBaseObject == null)
                {
                    nCheckCode = 41;
                    AttackTarget = GetPoseCreate();
                }
                else
                {
                    AttackTarget = TargeTBaseObject;
                }
                if ((AttackTarget != null) && (m_UseItems[TPosition.U_WEAPON]->wIndex > 0))
                {
                    nCheckCode = 42;
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        AttackDir_CheckWeaponUpgrade();
                    }
                }
                nCheckCode = 5;
                boPowerHit = m_boPowerHit;// ���ƹ�ɱ����
                if ((m_MagicPowerHitSkill != null) && (wHitMode == 3) && (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    boPowerHit = true;
                }
                boFireHit = m_boFireHitSkill;
                bo42 = m_bo42kill;
                bo43 = m_bo43kill;
                bo74 = m_boDailySkill;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT) // ѧ���ڹ��ķ�,ÿ����һ�μ�һ������ֵ
                {
                    if (((this) as TPlayObject).m_boTrainingNG)
                    {
                        // ѧ���ڹ��ķ�,ÿ����һ�μ�һ������ֵ
                        //((this) as TPlayObject).m_Skill69NH = HUtil32._MAX(0, ((this) as TPlayObject).m_Skill69NH - GameConfig.nHitStruckDecNH);
                        ((this) as TPlayObject).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((this) as TPlayObject).m_Skill69NH, ((this) as TPlayObject).m_Skill69MaxNH, 0, "");
                    }
                }
                else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    if (((THeroObject)(this)).m_boTrainingNG)
                    {
                        // Ӣ��ѧ���ڹ��ķ�,ÿ����һ�μ�һ������ֵ
                        //((THeroObject)(this)).m_Skill69NH = HUtil32._MAX(0, ((THeroObject)(this)).m_Skill69NH - GameConfig.nHitStruckDecNH);
                        ((THeroObject)(this)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(this)).m_Skill69NH, ((THeroObject)(this)).m_Skill69MaxNH, 0, "");
                    }
                }
                if (_Attack(ref wHitMode, AttackTarget))
                {
                    nCheckCode = 6;
                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT) // ����Ӣ��������,����������
                    {
                        if (!((THeroObject)(this)).m_boTarget)
                        {
                            SetTargetCreat(AttackTarget);
                        }
                    }
                    else
                    {
                        SetTargetCreat(AttackTarget);
                    }
                    nCheckCode = 7;
                }
                wIdent = Grobal2.RM_HIT;//10004
                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    switch (wHitMode)
                    {
                        case 0:// ���ӷ���ħ������
                            wIdent = Grobal2.RM_HIT;
                            break;
                        case 1:
                            wIdent = Grobal2.RM_HEAVYHIT;
                            break;
                        case 2:
                            wIdent = Grobal2.RM_BIGHIT;
                            break;
                        case 3:
                            if (boPowerHit)
                            {
                                wIdent = Grobal2.RM_SPELL2;
                            }
                            break;
                        case 4:
                            if (m_MagicErgumSkill != null)
                            {
                                wIdent = Grobal2.RM_LONGHIT;
                            }
                            break;
                        case 5:
                            if (m_MagicBanwolSkill != null)
                            {
                                wIdent = Grobal2.RM_WIDEHIT;
                            }
                            break;
                        case 7:
                            if (boFireHit && (m_MagicFireSwordSkill != null))
                            {
                                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    if ((m_MagicFireSwordSkill->btLevel == 4) &&
                                        (((THeroObject)(this)).m_nLoyal >= GameConfig.nGotoLV4))// Ӣ��4���һ�
                                    {
                                        wIdent = Grobal2.RM_4FIREHIT;// ����4���һ�����Ϣ 
                                    }
                                    else
                                    {
                                        wIdent = Grobal2.RM_FIREHIT; // �����һ𽣷���Ϣ
                                    }
                                }
                                else
                                {
                                    // ����Ӣ�������ҳ϶�
                                    if ((m_MagicFireSwordSkill->btLevel == 4)) // ����4���һ�
                                    {
                                        wIdent = Grobal2.RM_4FIREHIT;// ����4���һ�����Ϣ
                                    }
                                    else
                                    {
                                        wIdent = Grobal2.RM_FIREHIT;  // �����һ𽣷���Ϣ
                                    }
                                }
                            }
                            break;
                        case 8:
                            if (m_MagicCrsSkill != null)
                            {
                                wIdent = Grobal2.RM_CRSHIT;
                            }
                            break;
                        case 9:
                            if (m_Magic42Skill != null)
                            {
                                wIdent = Grobal2.RM_41;
                            }
                            break;
                        case 10:// ����ն
                            if (bo42)
                            {
                                wIdent = Grobal2.RM_42;
                            }
                            break;
                        case 11:// ����������д�
                            if (bo43)
                            {
                                wIdent = Grobal2.RM_43;
                            }
                            break;
                        case 12:// ����������д�
                            if (bo43 && (m_Magic43Skill != null))
                            {
                                wIdent = Grobal2.RM_44;
                            }
                            break;
                        case 13:// ��Ӱ����
                            if (bo74 && (m_Magic74Skill != null))
                            {
                                wIdent = Grobal2.RM_DAILY;
                            }
                            break;
                        case 14:// ���ս���
                            if ((m_MagicSkill_76 != null))
                            {
                                wIdent = Grobal2.RM_SANJUEHIT;// ����ɱ  
                            }
                            break;
                        case 15:
                            if ((m_MagicSkill_79 != null))
                            {
                                wIdent = Grobal2.RM_ZHUIXINHIT;// ׷�Ĵ�  
                            }
                            break;
                        case 16:
                            if ((m_MagicSkill_82 != null))
                            {
                                wIdent = Grobal2.RM_DUANYUEHIT;// ����ն  
                            }
                            break;
                        case 17:
                            if ((m_MagicSkill_85 != null))
                            {
                                wIdent = Grobal2.RM_HENGSAOHIT;// ��ɨǧ��
                            }
                            break;
                        case 18:
                            if ((m_MagicSkill_69 != null))
                            {
                                wIdent = Grobal2.RM_YTPDHIT;
                            }
                            break;
                        case 19:// ��������
                            if ((m_MagicSkill_89 != null))
                            {
                                wIdent = Grobal2.RM_4LONGHIT;
                            }
                            break;
                        case 20:// �ļ���ɱ
                            if ((m_MagicSkill_90 != null))
                            {
                                wIdent = Grobal2.RM_YUANYUEHIT;
                            }
                            break;
                        case 21:// Բ���䵶
                            if ((m_MagicSkill_96 != null))
                            {
                                wIdent = Grobal2.RM_XPYJHIT; // Ѫ��һ�� 
                            }
                            break;

                    }
                    if (m_boUseBatter)
                    {
                        if (wHitMode >= 14 && wHitMode <= 17)
                        {
                            m_boBatterFinally = true;
                        }
                    }
                }
                nCheckCode = 8;
                if (wIdent != Grobal2.RM_ZHUIXINHIT)
                {
                    SendAttackMsg(wIdent, m_btDirection, m_nCurrX, m_nCurrY);//���͹�����Ϣ
                }
                if (wIdent == Grobal2.RM_ZHUIXINHIT)
                {
                    m_nBatterZhuiXin.X = m_nCurrX;
                    m_nBatterZhuiXin.Y = m_nCurrY;
                    n1 = ((this) as TPlayObject).DoZXMotaebo(m_btDirection, 1);
                    SendRefMsg(wIdent, m_btDirection, m_nBatterZhuiXin.X, m_nBatterZhuiXin.Y, n1, "");
                    SendMsg(this, Grobal2.RM_ZHUIXIN_OK, m_btDirection, m_nCurrX, m_nCurrY, n1, "");
                    m_nBatterZhuiXin.X = m_nCurrX;
                    m_nBatterZhuiXin.Y = m_nCurrY;
                }
                nCheckCode = 9;
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode));
            }
        }

        /// <summary>
        /// ���PK״̬
        /// </summary>
        private void CheckPKStatus()
        {
            if (m_boPKFlag && ((HUtil32.GetTickCount() - m_dwPKTick) > GameConfig.dwPKFlagTime)) // 60 * 1000
            {
                m_boPKFlag = false;
                RefNameColor();
            }
        }

        /// <summary>
        /// ħ����
        /// </summary>
        /// <param name="nSpellPoint"></param>
        public void DamageSpell(int nSpellPoint)
        {
            if (nSpellPoint > 0)
            {
                if ((m_WAbil.MP - nSpellPoint) > 0)
                {
                    m_WAbil.MP -= nSpellPoint;
                }
                else
                {
                    m_WAbil.MP = 0;
                }
            }
            else
            {
                if ((m_WAbil.MP - nSpellPoint) < m_WAbil.MaxMP)
                {
                    m_WAbil.MP -= nSpellPoint;
                }
                else
                {
                    m_WAbil.MP = m_WAbil.MaxMP;
                }
            }
        }

        /// <summary>
        /// ��PKֵ
        /// </summary>
        /// <param name="nPoint"></param>
        private void DecPKPoint(int nPoint)
        {
            int nC;
            nC = PKLevel();
            m_nPkPoint -= nPoint;
            if (m_nPkPoint < 0)
            {
                m_nPkPoint = 0;
            }
            if ((PKLevel() != nC) && (nC > 0) && (nC <= 2))
            {
                RefNameColor();
            }
        }

        public unsafe void DelItemSkill_DELETESKILL(string sSkillName)
        {
            TUserMagic* UserMagic;
            TPlayObject PlayObject;
            for (int I = m_MagicList.Count - 1; I >= 0; I--)
            {
                if (m_MagicList.Count <= 0)
                {
                    break;
                }
                UserMagic = (TUserMagic*)m_MagicList[I];
                if (UserMagic != null)
                {
                    if (HUtil32.SBytePtrToString(UserMagic->MagicInfo.sMagicName, 0, UserMagic->MagicInfo.MagicNameLen) == sSkillName)
                    {
                        PlayObject = ((this) as TPlayObject);
                        PlayObject.SendDelMagic(UserMagic);
                        Marshal.FreeHGlobal((IntPtr)UserMagic);
                        m_MagicList.RemoveAt(I);
                        break;
                    }
                }
            }
        }

        private void DelItemSkill(int nIndex)
        {
            if (m_btRaceServer != Grobal2.RC_PLAYOBJECT)
            {
                return;
            }
            switch (nIndex)
            {
                case 1:
                    if (m_btJob != 1)
                    {
                        DelItemSkill_DELETESKILL(GameConfig.sFireBallSkill);
                    }
                    break;
                case 2:
                    if (m_btJob != 2)
                    {
                        DelItemSkill_DELETESKILL(GameConfig.sHealSkill);
                    }
                    break;
                case 3:
                    DelItemSkill_DELETESKILL(GameConfig.sHeavenSKill);
                    break;
                case 4:
                    DelItemSkill_DELETESKILL(GameConfig.MeteorSKill);
                    break;
            }
        }

        public unsafe virtual void DoDamageWeapon(int nWeaponDamage)
        {
            ushort nDura;
            int nDuraPoint;
            TPlayObject PlayObject;
            TStdItem* StdItem;
            if (m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return;
            }
            nDura = m_UseItems[TPosition.U_WEAPON]->Dura;
            nDuraPoint = (int)HUtil32.Round(nDura / 1.03);
            nDura -= (ushort)nWeaponDamage;
            if (nDura <= 0)
            {
                nDura = 0;
                m_UseItems[TPosition.U_WEAPON]->Dura = nDura;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    PlayObject = ((this) as TPlayObject);
                    PlayObject.SendDelItems(m_UseItems[TPosition.U_WEAPON]);
                    StdItem = UserEngine.GetStdItem(m_UseItems[TPosition.U_WEAPON]->wIndex);
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("3" + "\09" + m_sMapName + "\09" + (m_nCurrX).ToString() + "\09" + (m_nCurrY).ToString() + "\09"
                            + m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen) + "\09" + (m_UseItems[TPosition.U_WEAPON]->MakeIndex).ToString() + "\09" + "("
                            + (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString()
                            + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")" + (m_UseItems[TPosition.U_WEAPON]->btValue[0]).ToString() + "/" + m_UseItems[TPosition.U_WEAPON]->btValue[1] + "/" + m_UseItems[TPosition.U_WEAPON]->btValue[2]
                            + "/" + (m_UseItems[TPosition.U_WEAPON]->btValue[3]).ToString() + "/" + m_UseItems[TPosition.U_WEAPON]->btValue[4] + "/" + m_UseItems[TPosition.U_WEAPON]->btValue[5] + "/" + m_UseItems[TPosition.U_WEAPON]->btValue[6]
                            + "/" + (m_UseItems[TPosition.U_WEAPON]->btValue[7]).ToString() + "/" + m_UseItems[TPosition.U_WEAPON]->btValue[8] + "/" + m_UseItems[TPosition.U_WEAPON]->btValue[14] + "\09"
                            + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT));
                    }
                }
                m_UseItems[TPosition.U_WEAPON]->wIndex = 0;
                SendMsg(this, Grobal2.RM_DURACHANGE, TPosition.U_WEAPON, nDura, m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");
            }
            else
            {
                m_UseItems[TPosition.U_WEAPON]->Dura = nDura;
            }
            if ((nDura / 1.03) != nDuraPoint)
            {
                SendMsg(this, Grobal2.RM_DURACHANGE, TPosition.U_WEAPON, m_UseItems[TPosition.U_WEAPON]->Dura,
                    m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");
            }
        }

        /// <summary>
        /// ȡװ����Ʒ����
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="AddAbility"></param>
        private unsafe void GetAccessory(TUserItem* Item, TStdItem* StdItem, TAddAbility* AddAbility)
        {
            TStdItem* StdItemA = StdItem;
            ItemUnit.GetItemAddValue(Item, StdItemA);
            switch (StdItem->StdMode)
            {
                case 5:
                case 6:
                    AddAbility->wHitPoint += (ushort)HUtil32.HiWord(StdItemA->AC);
                    if (HUtil32.HiWord(StdItemA->MAC) > 10)
                    {
                        AddAbility->nHitSpeed += HUtil32.HiWord(StdItemA->MAC) - 10;
                    }
                    else
                    {
                        AddAbility->nHitSpeed -= HUtil32.HiWord(StdItemA->MAC);
                    }
                    AddAbility->btLuck += (byte)HUtil32.LoWord(StdItemA->AC);
                    AddAbility->btUnLuck += (byte)HUtil32.LoWord(StdItemA->MAC);
                    break;
                case 16:
                    switch (StdItem->Source)
                    {
                        case 10:
                            break;
                    }
                    break;
                case 19:// ����+����
                    AddAbility->wAntiMagic += (ushort)HUtil32.HiWord(StdItemA->AC);
                    AddAbility->btUnLuck += (byte)HUtil32.LoWord(StdItemA->MAC);
                    AddAbility->btLuck += (byte)HUtil32.HiWord(StdItemA->MAC);
                    break;
                case 53:// �¼���Ʒ����
                    if (!GameConfig.boAddUserItemNewValue)
                    {
                        AddAbility->wAntiMagic += (ushort)HUtil32.HiWord(StdItemA->AC);
                        AddAbility->btUnLuck += (byte)HUtil32.LoWord(StdItemA->MAC);
                        AddAbility->btLuck += (byte)HUtil32.HiWord(StdItemA->MAC);
                    }
                    else
                    {
                        AddAbility->wAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wAC) + HUtil32.LoWord(StdItemA->AC), HUtil32.HiWord(AddAbility->wAC) + HUtil32.HiWord(StdItemA->AC));
                        AddAbility->wMAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wMAC) + HUtil32.LoWord(StdItemA->MAC), HUtil32.HiWord(AddAbility->wMAC) + HUtil32.HiWord(StdItemA->MAC));
                    }
                    break;
                case 20:
                case 24:
                    AddAbility->wHitPoint += (ushort)HUtil32.HiWord(StdItemA->AC);
                    AddAbility->wSpeedPoint += (ushort)HUtil32.HiWord(StdItemA->MAC);
                    break;
                case 52:// ѥ��(������)
                    if (!GameConfig.boAddUserItemNewValue)
                    {
                        AddAbility->wHitPoint += (ushort)HUtil32.HiWord(StdItemA->AC);
                        AddAbility->wSpeedPoint += (ushort)HUtil32.HiWord(StdItemA->MAC);
                    }
                    else
                    {
                        AddAbility->wAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wAC) + HUtil32.LoWord(StdItemA->AC), HUtil32.HiWord(AddAbility->wAC) + HUtil32.HiWord(StdItemA->AC));
                        AddAbility->wMAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wMAC) + HUtil32.LoWord(StdItemA->MAC), HUtil32.HiWord(AddAbility->wMAC) + HUtil32.HiWord(StdItemA->MAC));
                        AddAbility->wWearWeight = (ushort)HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wWearWeight) + HUtil32.LoWord(StdItemA->AniCount), HUtil32.HiWord(AddAbility->wWearWeight) + HUtil32.HiWord(StdItemA->AniCount));// �Ӹ���
                    }
                    break;
                case 21:
                    AddAbility->wHealthRecover += (ushort)HUtil32.HiWord(StdItemA->AC);
                    AddAbility->wSpellRecover += (ushort)HUtil32.HiWord(StdItemA->MAC);
                    AddAbility->nHitSpeed += HUtil32.LoWord(StdItemA->AC);
                    AddAbility->nHitSpeed -= HUtil32.LoWord(StdItemA->MAC);
                    break;
                case 54:// ����(������)
                    if (!GameConfig.boAddUserItemNewValue)
                    {
                        AddAbility->wHealthRecover += (ushort)HUtil32.HiWord(StdItemA->AC);
                        AddAbility->wSpellRecover += (ushort)HUtil32.HiWord(StdItemA->MAC);
                        AddAbility->nHitSpeed += HUtil32.LoWord(StdItemA->AC);
                        AddAbility->nHitSpeed -= HUtil32.LoWord(StdItemA->MAC);
                    }
                    else
                    {
                        AddAbility->wAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wAC) + HUtil32.LoWord(StdItemA->AC), HUtil32.HiWord(AddAbility->wAC) + HUtil32.HiWord(StdItemA->AC));
                        AddAbility->wMAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wMAC) + HUtil32.LoWord(StdItemA->MAC), HUtil32.HiWord(AddAbility->wMAC) + HUtil32.HiWord(StdItemA->MAC));
                        AddAbility->wWearWeight = (ushort)HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wWearWeight) + HUtil32.LoWord(StdItemA->AniCount),
                            HUtil32.HiWord(AddAbility->wWearWeight) + HUtil32.HiWord(StdItemA->AniCount));// �Ӹ���
                    }
                    break;
                case 23:
                    AddAbility->wAntiPoison += (ushort)HUtil32.HiWord(StdItemA->AC);
                    AddAbility->wPoisonRecover += (ushort)HUtil32.HiWord(StdItemA->MAC);
                    AddAbility->nHitSpeed += HUtil32.LoWord(StdItemA->AC);
                    AddAbility->nHitSpeed -= HUtil32.LoWord(StdItemA->MAC);
                    break;
                default:
                    AddAbility->wAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wAC) + HUtil32.LoWord(StdItemA->AC), HUtil32.HiWord(AddAbility->wAC) + HUtil32.HiWord(StdItemA->AC));
                    AddAbility->wMAC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wMAC) + HUtil32.LoWord(StdItemA->MAC), HUtil32.HiWord(AddAbility->wMAC) + HUtil32.HiWord(StdItemA->MAC));
                    break;
            }
            AddAbility->wDC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wDC) + HUtil32.LoWord(StdItemA->DC), HUtil32.HiWord(AddAbility->wDC) + HUtil32.HiWord(StdItemA->DC));
            AddAbility->wMC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wMC) + HUtil32.LoWord(StdItemA->MC), HUtil32.HiWord(AddAbility->wMC) + HUtil32.HiWord(StdItemA->MC));
            AddAbility->wSC = HUtil32.MakeLong(HUtil32.LoWord(AddAbility->wSC) + HUtil32.LoWord(StdItemA->SC), HUtil32.HiWord(AddAbility->wSC) + HUtil32.HiWord(StdItemA->SC));
        }

        /// <summary>
        /// ȡ������ɫֵ
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public byte GetCharColor(TBaseObject BaseObject)
        {
            byte result = 0;
            int n10;
            TUserCastle Castle;
            byte nCode = 0;
            try
            {
                result = BaseObject.GetNamecolor();
                nCode = 1;
                if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    nCode = 2;
                    if (BaseObject.PKLevel() < 2)
                    {
                        if (BaseObject.m_boPKFlag)
                        {
                            result = GameConfig.btPKFlagNameColor;
                        }
                        nCode = 3;
                        n10 = GetGuildRelation(this, BaseObject);
                        nCode = 4;
                        switch (n10)
                        {
                            case 1:
                            case 3:
                                result = GameConfig.btAllyAndGuildNameColor;
                                break;
                            case 2:
                                result = GameConfig.btWarGuildNameColor;
                                break;
                        }
                        nCode = 5;
                        if (BaseObject.m_PEnvir.m_boFight3Zone)
                        {
                            nCode = 6;
                            if (m_MyGuild == BaseObject.m_MyGuild)
                            {
                                result = GameConfig.btAllyAndGuildNameColor;
                            }
                            else
                            {
                                result = GameConfig.btWarGuildNameColor;
                            }
                        }
                    }
                    nCode = 7;
                    Castle = M2Share.g_CastleManager.InCastleWarArea(BaseObject);
                    nCode = 8;
                    if ((Castle != null) && Castle.m_boUnderWar && m_boInFreePKArea && BaseObject.m_boInFreePKArea)
                    {
                        result = GameConfig.btInFreePKAreaNameColor;
                        m_boGuildWarArea = true;
                        if ((m_MyGuild == null))
                        {
                            return result;
                        }
                        nCode = 9;
                        if (Castle.IsMasterGuild(m_MyGuild))
                        {
                            nCode = 10;
                            if ((m_MyGuild == BaseObject.m_MyGuild) || (m_MyGuild.IsAllyGuild(BaseObject.m_MyGuild)))
                            {
                                nCode = 11;
                                result = GameConfig.btAllyAndGuildNameColor;
                            }
                            else
                            {
                                nCode = 12;
                                if (Castle.IsAttackGuild(BaseObject.m_MyGuild))
                                {
                                    nCode = 13;
                                    result = GameConfig.btWarGuildNameColor;
                                }
                            }
                        }
                        else
                        {
                            nCode = 14;
                            if (Castle.IsAttackGuild(((TGUild)(m_MyGuild))))
                            {
                                nCode = 15;
                                if ((m_MyGuild == BaseObject.m_MyGuild) || (m_MyGuild.IsAllyGuild(BaseObject.m_MyGuild)))
                                {
                                    nCode = 16;
                                    result = GameConfig.btAllyAndGuildNameColor;
                                }
                                else
                                {
                                    nCode = 17;
                                    if (Castle.IsMember(BaseObject))
                                    {
                                        nCode = 18;
                                        result = GameConfig.btWarGuildNameColor;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    nCode = 19;
                    if (BaseObject.PKLevel() < 2)
                    {
                        if (BaseObject.m_boPKFlag)
                        {
                            result = GameConfig.btPKFlagNameColor;
                        }
                        if (BaseObject.m_Master != null)
                        {
                            n10 = GetGuildRelation(this, BaseObject.m_Master);
                            nCode = 26;
                            switch (n10)
                            {
                                case 1:
                                case 3:
                                    result = GameConfig.btAllyAndGuildNameColor;
                                    break;
                                case 2:
                                    result = GameConfig.btWarGuildNameColor;
                                    break;
                            }
                            if (BaseObject.m_PEnvir.m_boFight3Zone)
                            {
                                nCode = 27;
                                if (m_MyGuild == BaseObject.m_Master.m_MyGuild)
                                {
                                    result = GameConfig.btAllyAndGuildNameColor;
                                }
                                else
                                {
                                    result = GameConfig.btWarGuildNameColor;
                                }
                            }
                        }
                    }
                    nCode = 20;
                    // ��������,Ӣ��Ҳһ������
                    Castle = M2Share.g_CastleManager.InCastleWarArea(BaseObject);
                    nCode = 21;
                    if (BaseObject.m_Master != null)
                    {
                        if ((Castle != null) && Castle.m_boUnderWar && BaseObject.m_Master.m_boInFreePKArea)
                        {
                            nCode = 22;
                            result = GameConfig.btInFreePKAreaNameColor;
                            m_boGuildWarArea = true;
                            if ((m_MyGuild == null))
                            {
                                return result;
                            }
                            nCode = 26;
                            if (Castle.IsMasterGuild(m_MyGuild))
                            {
                                nCode = 27;
                                if ((m_MyGuild == BaseObject.m_Master.m_MyGuild) || (m_MyGuild.IsAllyGuild((BaseObject.m_Master.m_MyGuild))))
                                {
                                    nCode = 28;
                                    result = GameConfig.btAllyAndGuildNameColor;
                                }
                                else
                                {
                                    nCode = 29;
                                    if (Castle.IsAttackGuild(BaseObject.m_Master.m_MyGuild))
                                    {
                                        nCode = 30;
                                        result = GameConfig.btWarGuildNameColor;
                                    }
                                }
                            }
                            else
                            {
                                nCode = 31;
                                if (Castle.IsAttackGuild(m_MyGuild))
                                {
                                    nCode = 32;
                                    if ((m_MyGuild == BaseObject.m_Master.m_MyGuild) || (m_MyGuild.IsAllyGuild(BaseObject.m_Master.m_MyGuild)))
                                    {
                                        nCode = 33;
                                        result = GameConfig.btAllyAndGuildNameColor;
                                    }
                                    else
                                    {
                                        nCode = 34;
                                        if (Castle.IsMember(BaseObject.m_Master))
                                        {
                                            nCode = 35;
                                            result = GameConfig.btWarGuildNameColor;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (BaseObject.m_btRaceServer == Grobal2.RC_NPC)
                {
                    result = GameConfig.btNPCNameColor; // NPC������ɫ
                    if (BaseObject.m_boCrazyMode)// ���ģʽ(����)
                    {
                        result = 0xF9;
                    }
                    if (BaseObject.m_boHolySeize) // �����߶�ģʽ
                    {
                        result = 0x7D;
                    }
                }
                else
                {
                    nCode = 23;
                    //û���Զ���������ɫ
                    if ((BaseObject.m_btSlaveExpLevel < M2Share.SLAVEMAXLEVEL) && (!BaseObject.m_boSetNameColor))
                    {
                        nCode = 24;
                        result = GameConfig.SlaveColor[BaseObject.m_btSlaveExpLevel];
                        if ((BaseObject.m_Master != null) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                        {
                            //���������������ɫһ��
                            result = BaseObject.m_btNameColor;
                        }
                    }
                    if ((BaseObject.m_Master != null) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                    {
                        if ((BaseObject.m_Master.m_boPKFlag)) // ���λ�����ʾ
                        {
                            result = GameConfig.btPKFlagNameColor;
                        }
                    }
                    nCode = 25;
                    if (BaseObject.m_boCrazyMode) // ���ģʽ(����)
                    {
                        result = 0xF9;
                    }
                    if (BaseObject.m_boHolySeize)// �����߶�ģʽ
                    {
                        result = 0x7D;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.GetCharColor Code:" + nCode);
            }
            return result;
        }

        public uint GetLevelExp_GetBaseExp(int nLevel)
        {
            uint result;
            long nInt64 = (nLevel - 1000) * GameConfig.nAddExp + GameConfig.nBaseExp;
            if (nInt64 > uint.MaxValue)
            {
                result = uint.MaxValue;
            }
            else
            {
                result = (uint)nInt64;
            }
            return result;
        }

        /// <summary>
        /// ȡ�ȼ����辭��ֵ
        /// </summary>
        /// <param name="nLevel"></param>
        /// <returns></returns>
        public uint GetLevelExp(int nLevel)
        {
            uint result;
            if (nLevel <= M2Share.MAXCHANGELEVEL)//1000
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    result = GameConfig.dwNeedExps[nLevel];
                }
                else
                {
                    result = GameConfig.dwHeroNeedExps[nLevel];// Ӣ�۾���
                }
                return result;
            }
            if (GameConfig.boUseFixExp)
            {
                if (nLevel <= M2Share.MAXLEVEL)
                {
                    result = Convert.ToUInt32(2000000000 + nLevel * 1500);
                }
                else
                {
                    result = uint.MaxValue;
                    // g_Config.dwNeedExps[High(g_Config.dwNeedExps)];
                }
            }
            else
            {
                if (nLevel <= M2Share.MAXLEVEL)
                {
                    result = GetLevelExp_GetBaseExp(nLevel);
                }
                else
                {
                    result = int.MaxValue;
                }
            }
            return result;
        }

        /// <summary>
        /// ȡ�ȼ�����ҩ��ֵ
        /// </summary>
        /// <param name="nLevel"></param>
        /// <returns></returns>
        public ushort GetMedicineExp(int nLevel)
        {
            ushort result = 0;
            if (nLevel <= M2Share.MAXCHANGELEVEL)// 1000
            {
                result = GameConfig.dwMedicineNeedExps[nLevel];
                return result;
            }
            if (nLevel <= M2Share.MAXLEVEL)
            {
                result = ushort.MaxValue;
            }
            return result;
        }

        /// <summary>
        /// �������� ȡ�ȼ����辭��ֵ
        /// </summary>
        /// <param name="nLevel"></param>
        /// <returns></returns>
        public UInt32 GetSkill68Exp(byte nLevel)
        {
            UInt32 result = 0;
            if (nLevel == 0)
            {
                return result;
            }
            if (nLevel < 100)
            {
                result = GameConfig.dwSkill68NeedExps[nLevel];
                return result;
            }
            else
            {
                result = UInt32.MaxValue;
            }
            return result;
        }

        /// <summary>
        /// �ڹ��ķ� ȡ�ȼ����辭��ֵ,����ֵ����
        /// </summary>
        /// <param name="nLevel"></param>
        /// <param name="nMaxNH"></param>
        /// <returns></returns>
        public uint GetSkill69Exp(byte nLevel, ref UInt32 nMaxNH)
        {
            uint result = 0;
            nMaxNH = (ushort)HUtil32.Round((double)(2 + 2 * (nLevel - 1)) * nLevel / 2 + GameConfig.nSkill69NG);
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT) // ����
            {
                result = Convert.ToUInt32(200 * nLevel * nLevel * nLevel + 13940 * nLevel * nLevel + GameConfig.nSkill69NGExp);
            }
            else// Ӣ�۾���
            {
                result = Convert.ToUInt32(200 * nLevel * nLevel * nLevel + 14240 * nLevel * nLevel + 14240 * nLevel + GameConfig.nHeroSkill69NGExp);
            }
            return result;
        }

        /// <summary>
        /// ȡ����������ɫ
        /// </summary>
        /// <returns></returns>
        public virtual byte GetNamecolor()
        {
            byte result = m_btNameColor;
            if (PKLevel() == 1) //����
            {
                result = GameConfig.btPKLevel1NameColor;
            }
            if (PKLevel() >= 2) //����
            {
                result = GameConfig.btPKLevel2NameColor;
            }
            return result;
        }

        private void HearMsg(string sMsg)
        {
            if (sMsg != "")
            {
                SendMsg(null, Grobal2.RM_HEAR, 0, GameConfig.btHearMsgFColor, GameConfig.btHearMsgBColor, 0, sMsg);
            }
        }

        /// <summary>
        /// �Ƿ��ڰ�ȫ��
        /// </summary>
        /// <returns></returns>
        public bool InSafeArea()
        {
            bool result = m_PEnvir.m_boSAFE;
            string SC;
            int n14;
            int n18;
            TStartPoint StartPoint;
            if (m_PEnvir == null)
            {
                return result;
            }
            if (result)
            {
                return result;
            }
            try
            {
                // M2Share.g_StartPointList.__Lock();
                if (M2Share.g_StartPointList.Count > 0)
                {
                    for (int I = 0; I < M2Share.g_StartPointList.Count; I++)
                    {
                        SC = M2Share.g_StartPointList[I].m_sMapName;
                        if (SC == m_PEnvir.sMapName)
                        {
                            StartPoint = M2Share.g_StartPointList[I];
                            if (StartPoint != null)
                            {
                                n14 = StartPoint.m_nCurrX;
                                n18 = StartPoint.m_nCurrY;// �޸�,ʹ�ð�ȫ����Χ���ж�
                                if ((Math.Abs(m_nCurrX - n14) <= GameConfig.nSafeZoneSize) && (Math.Abs(m_nCurrY - n18) <= GameConfig.nSafeZoneSize))
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                //M2Share.g_StartPointList.UnLock();
            }
            return result;
        }

        /// <summary>
        /// ���¼����������
        /// </summary>
        public void MonsterRecalcAbilitys()
        {
            int n8;
            m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.HiWord(m_Abil.DC));
            n8 = 0;
            if ((m_btRaceServer == 100) || (m_btRaceServer == 113) || (m_btRaceServer == 114))
            {
                m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), (ushort)HUtil32.Round((double)(m_btSlaveExpLevel * 0.1 + 0.3) * 3.0 * m_btSlaveExpLevel + HUtil32.HiWord(m_WAbil.DC)));
                n8 = n8 + (int)HUtil32.Round((double)(m_btSlaveExpLevel * 0.1 + 0.3) * m_Abil.MaxHP) * m_btSlaveExpLevel;
                n8 = n8 + m_Abil.MaxHP;
                if (m_btSlaveExpLevel > 0)
                {
                    m_WAbil.MaxHP = n8;
                }
                else
                {
                    m_WAbil.MaxHP = m_Abil.MaxHP;
                }
            }
            else
            {
                n8 = m_Abil.MaxHP;
                m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), (ushort)HUtil32.Round((double)m_btSlaveExpLevel * 2 + HUtil32.HiWord(m_WAbil.DC)));
                n8 = n8 + (int)HUtil32.Round(m_Abil.MaxHP * 0.15) * m_btSlaveExpLevel;
                m_WAbil.MaxHP = HUtil32._MIN((int)HUtil32.Round((double)m_Abil.MaxHP + m_btSlaveExpLevel * 60), n8);
            }
        }

        public unsafe void SendFirstMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg)
        {
            TSendMessage SendMessage = null;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                if (!m_boGhost)
                {
                    SendMessage = new TSendMessage();
                    SendMessage.wIdent = wIdent;
                    SendMessage.wParam = wParam;
                    SendMessage.nParam1 = lParam1;
                    SendMessage.nParam2 = lParam2;
                    SendMessage.nParam3 = lParam3;
                    SendMessage.dwDeliveryTime = 0;
                    SendMessage.BaseObject = BaseObject.ToInt();
                    if (sMsg != "" && sMsg != null)
                    {
                        try
                        {
                            byte[] bMsg = HUtil32.StringToByteAry(sMsg);
                            IntPtr Buff = Marshal.AllocHGlobal(bMsg.Length + sizeof(int));
                            *(int*)Buff = bMsg.Length;
                            Marshal.Copy(bMsg, 0, (IntPtr)((byte*)Buff + sizeof(int)), bMsg.Length);
                            SendMessage.Buff = Buff;
                        }
                        catch
                        {
                            SendMessage.Buff = IntPtr.Zero;
                        }
                    }
                    else
                    {
                        SendMessage.Buff = IntPtr.Zero;
                    }
                    m_MsgList.Insert(0, SendMessage);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        public unsafe void SendMsg(TBaseObject BaseObject, int wIdent, object wParam, object nParam1, object nParam2, object nParam3, string sMsg)
        {
            TSendMessage SendMessage = null;
            byte nCode = 0;
            try
            {
                try
                {
                    HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                    nCode = 1;
                    if (this == null)
                    {
                        return;
                    }
                    nCode = 7;
                    if (!m_boGhost)
                    {
                        nCode = 2;
                        SendMessage = new TSendMessage();
                        SendMessage.wIdent = (ushort)wIdent;
                        SendMessage.wParam = Convert.ToInt32(wParam);
                        SendMessage.nParam1 = Convert.ToInt32(nParam1);
                        SendMessage.nParam2 = Convert.ToInt32(nParam2);
                        SendMessage.nParam3 = Convert.ToInt32(nParam3);
                        nCode = 3;
                        SendMessage.dwDeliveryTime = 0;
                        nCode = 4;
                        SendMessage.BaseObject = BaseObject.ToInt();
                        SendMessage.boLateDelivery = false;
                        if (sMsg != "" && sMsg != null)
                        {
                            try
                            {
                                nCode = 5;
                                byte[] bMsg = HUtil32.StringToByteAry(sMsg);
                                IntPtr Buff = Marshal.AllocHGlobal(bMsg.Length + sizeof(int));
                                *(int*)Buff = bMsg.Length;
                                Marshal.Copy(bMsg, 0, (IntPtr)((byte*)Buff + sizeof(int)), bMsg.Length);
                                SendMessage.Buff = Buff;
                            }
                            catch
                            {
                                SendMessage.Buff = IntPtr.Zero;
                            }
                        }
                        else
                        {
                            if (SendMessage.Buff != null)
                            {
                                SendMessage.Buff = IntPtr.Zero;
                            }
                        }
                        nCode = 6;
                        try
                        {
                            m_MsgList.Add(SendMessage);
                        }
                        catch
                        {
                            SendMessage = null;
                        }
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.SendMsg Code:" + nCode + "  Name:" + m_sCharName);
                KickException();
            }
        }

        public unsafe void SendDelayMsg(int BaseObject, int wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, uint dwDelay)
        {
            TSendMessage SendMessage = null;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                if (!m_boGhost)
                {
                    SendMessage = new TSendMessage();
                    SendMessage.wIdent = (ushort)wIdent;
                    SendMessage.wParam = wParam;
                    SendMessage.nParam1 = lParam1;
                    SendMessage.nParam2 = lParam2;
                    SendMessage.nParam3 = lParam3;
                    SendMessage.dwDeliveryTime = HUtil32.GetTickCount() + dwDelay;
                    SendMessage.BaseObject = BaseObject;
                    SendMessage.boLateDelivery = true;
                    if (sMsg != "" && sMsg != null)
                    {
                        try
                        {
                            byte[] bMsg = HUtil32.StringToByteAry(sMsg);
                            IntPtr Buff = Marshal.AllocHGlobal(bMsg.Length + sizeof(int));
                            *(int*)Buff = bMsg.Length;
                            Marshal.Copy(bMsg, 0, (IntPtr)((byte*)Buff + sizeof(int)), bMsg.Length);
                            SendMessage.Buff = Buff;
                        }
                        catch
                        {
                            SendMessage.Buff = IntPtr.Zero;
                        }
                    }
                    else
                    {
                        SendMessage.Buff = IntPtr.Zero;
                    }
                    m_MsgList.Add(SendMessage);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        /// <summary>
        /// �ӳٷ�����Ϣ
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="wIdent"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam1"></param>
        /// <param name="lParam2"></param>
        /// <param name="lParam3"></param>
        /// <param name="sMsg"></param>
        /// <param name="dwDelay">Ϊ�ӳ�ʱ��(��λ������)</param>
        public unsafe void SendDelayMsg(TBaseObject BaseObject, int wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, uint dwDelay)
        {
            TSendMessage SendMessage = null;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                if (!m_boGhost)
                {
                    SendMessage = new TSendMessage();
                    SendMessage.wIdent = (ushort)wIdent;
                    SendMessage.wParam = wParam;
                    SendMessage.nParam1 = lParam1;
                    SendMessage.nParam2 = lParam2;
                    SendMessage.nParam3 = lParam3;
                    SendMessage.dwDeliveryTime = HUtil32.GetTickCount() + dwDelay;
                    SendMessage.BaseObject = BaseObject.ToInt();
                    SendMessage.boLateDelivery = true;
                    if (sMsg != "" && sMsg != null)
                    {
                        try
                        {
                            byte[] bMsg = HUtil32.StringToByteAry(sMsg);
                            IntPtr Buff = Marshal.AllocHGlobal(bMsg.Length + sizeof(int));
                            *(int*)Buff = bMsg.Length;
                            Marshal.Copy(bMsg, 0, (IntPtr)((byte*)Buff + sizeof(int)), bMsg.Length);
                            SendMessage.Buff = Buff;
                        }
                        catch
                        {
                            SendMessage.Buff = IntPtr.Zero;
                        }
                    }
                    else
                    {
                        SendMessage.Buff = IntPtr.Zero;
                    }
                    m_MsgList.Add(SendMessage);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        /// <summary>
        /// ������ʱ������Ϣ
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="wIdent"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam1"></param>
        /// <param name="lParam2"></param>
        /// <param name="lParam3"></param>
        /// <param name="sMsg"></param>
        /// <param name="dwDelay"></param>
        public unsafe virtual void SendUpdateDelayMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, uint dwDelay)
        {
            TSendMessage SendMessage = null;
            int I;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                I = 0;
                while (true)
                {
                    if (m_MsgList.Count <= I)
                    {
                        break;
                    }
                    SendMessage = m_MsgList[I];
                    if ((SendMessage.wIdent == wIdent) && (SendMessage.nParam1 == lParam1))
                    {
                        m_MsgList.RemoveAt(I);
                        if (SendMessage.Buff != null)
                        {
                            Marshal.FreeHGlobal(SendMessage.Buff);
                        }
                        SendMessage = null;
                        continue;
                    }
                    I++;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            SendDelayMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg, dwDelay);
        }

        /// <summary>
        /// ����ˢ����Ϣ
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="wIdent"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam1"></param>
        /// <param name="lParam2"></param>
        /// <param name="lParam3"></param>
        /// <param name="sMsg"></param>
        public unsafe void SendUpdateMsg(TBaseObject BaseObject, int wIdent, object wParam, object lParam1, object lParam2, object lParam3, string sMsg)
        {
            TSendMessage SendMessage = null;
            int I;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                I = 0;
                while (true)
                {
                    if (m_MsgList.Count <= I)
                    {
                        break;
                    }
                    SendMessage = m_MsgList[I];
                    if (SendMessage.wIdent == (int)wIdent)
                    {
                        m_MsgList.RemoveAt(I);
                        if (SendMessage.Buff != null)
                        {
                            Marshal.FreeHGlobal(SendMessage.Buff);
                        }
                        SendMessage = null;
                        continue;
                    }
                    I++;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            SendMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg);
        }

        /// <summary>
        /// ���Ͷ�����Ϣ
        /// ��· ������
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="wIdent"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam1"></param>
        /// <param name="lParam2"></param>
        /// <param name="lParam3"></param>
        /// <param name="sMsg"></param>
        public unsafe void SendActionMsg(TBaseObject BaseObject, int wIdent, object wParam, object lParam1, object lParam2, object lParam3, string sMsg)
        {
            TSendMessage SendMessage = null;
            int I = 0;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                while (true)
                {
                    if (m_MsgList.Count <= I && m_MsgList != null)
                    {
                        break;
                    }
                    // ���ս���  �һ� �ļ���ɱ Բ���䵶 4���һ� 
                    SendMessage = this.m_MsgList[I];
                    if ((SendMessage.wIdent == Grobal2.CM_TURN) || (SendMessage.wIdent == Grobal2.CM_WALK) || (SendMessage.wIdent == Grobal2.CM_SITDOWN) ||
                        (SendMessage.wIdent == Grobal2.CM_HORSERUN) || (SendMessage.wIdent == Grobal2.CM_RUN) || (SendMessage.wIdent == Grobal2.CM_HIT) ||
                        (SendMessage.wIdent == Grobal2.CM_HEAVYHIT) || (SendMessage.wIdent == Grobal2.CM_BIGHIT) || (SendMessage.wIdent == Grobal2.CM_POWERHIT) ||
                        (SendMessage.wIdent == Grobal2.CM_LONGHIT) || (SendMessage.wIdent == Grobal2.CM_WIDEHIT) || (SendMessage.wIdent == Grobal2.CM_CRSHIT) ||
                        (SendMessage.wIdent == Grobal2.CM_DAILY) || (SendMessage.wIdent == Grobal2.CM_FIREHIT) || (SendMessage.wIdent == Grobal2.CM_4LONGHIT) ||
                        (SendMessage.wIdent == Grobal2.CM_YUANYUEHIT) || (SendMessage.wIdent == Grobal2.CM_4FIREHIT))
                    {
                        m_MsgList.RemoveAt(I);
                        if (SendMessage.Buff != null && SendMessage.Buff.ToInt32() != 0)
                        {
                            Marshal.FreeHGlobal(SendMessage.Buff);
                        }
                        SendMessage = null;
                        continue;
                    }
                    I++;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            SendMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg);
        }

        /// <summary>
        /// �鿴��Ϣ����
        /// </summary>
        /// <returns></returns>
        public int MessageCount()
        {
            int result;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                result = m_MsgList.Count;
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// ��ȡMessage
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public unsafe virtual bool GetMessage(TProcessMessage Msg)
        {
            bool result = false;
            int I;
            TSendMessage SendMessage = null;
            byte nCode = 0;
            if (this == null || Msg == null)
            {
                return result;
            }
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                try
                {
                    I = 0;
                    Msg.wIdent = 0;
                    nCode = 1;
                    if (m_MsgList != null)
                    {
                        while (m_MsgList.Count > I)
                        {
                            if (m_MsgList.Count <= I)
                            {
                                break;
                            }
                            nCode = 20;
                            if (m_MsgList[I] == null)
                            {
                                nCode = 21;
                                m_MsgList.RemoveAt(I);
                                nCode = 22;
                                continue;
                            }
                            nCode = 23;
                            SendMessage = m_MsgList[I];
                            nCode = 24;
                            if (SendMessage == null)
                            {
                                nCode = 25;
                                m_MsgList.RemoveAt(I);
                                continue;
                            }
                            nCode = 3;
                            if (SendMessage.dwDeliveryTime != 0 && HUtil32.GetTickCount() < SendMessage.dwDeliveryTime)
                            {
                                I++;
                                continue;
                            }
                            nCode = 5;
                            m_MsgList.RemoveAt(I);
                            nCode = 6;
                            Msg.wIdent = SendMessage.wIdent;
                            nCode = 7;
                            Msg.wParam = SendMessage.wParam;
                            nCode = 8;
                            Msg.nParam1 = SendMessage.nParam1;
                            nCode = 9;
                            Msg.nParam2 = SendMessage.nParam2;
                            nCode = 10;
                            Msg.nParam3 = SendMessage.nParam3;
                            nCode = 11;
                            Msg.BaseObject = SendMessage.BaseObject;
                            nCode = 12;
                            Msg.dwDeliveryTime = SendMessage.dwDeliveryTime;
                            nCode = 13;
                            Msg.boLateDelivery = SendMessage.boLateDelivery;
                            nCode = 14;
                            if (SendMessage.Buff != null && (int)SendMessage.Buff != 0)
                            {
                                nCode = 15;
                                if (Msg != null)
                                {
                                    nCode = 5;
                                    byte* psb = (byte*)SendMessage.Buff;
                                    if (psb != null)
                                    {
                                        int nLen = *(int*)psb;
                                        Msg.sMsg = new string((sbyte*)psb, sizeof(int), nLen);
                                        //Msg.sMsg = HUtil32.SBytePtrToString((sbyte*)psb, sizeof(int), nLen);
                                    }
                                }
                                nCode = 16;
                                Marshal.FreeHGlobal(SendMessage.Buff);
                            }
                            else
                            {
                                nCode = 17;
                                if (Msg != null)
                                {
                                    Msg.sMsg = null;
                                }
                            }
                            nCode = 18;
                            if (SendMessage != null)
                            {
                                SendMessage = null;
                            }
                            nCode = 19;
                            result = true;
                            break;
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{�쳣} TBaseObject.GetMessage Code:" + nCode);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            return result;
        }

        /// <summary>
        /// ���ͬ��������һ����Χ��Ĺ�(��Ӱ)
        /// </summary>
        /// <param name="btDir"></param>
        /// <param name="nRage"></param>
        /// <param name="rList"></param>
        /// <returns></returns>
        public bool GetDirectionBaseObjects_42(int btDir, int nRage, List<TBaseObject> rList)
        {
            bool result;
            int X;
            int Y;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            const string sExceptionMsg = "{�쳣} TBaseObject::GetDirectionBaseObjects_42";
            result = false;
            if (rList == null)
            {
                return result;
            }
            try
            {
                switch (btDir)
                {
                    case Grobal2.DR_UP:// ��--OK
                        for (Y = m_nCurrY; Y >= m_nCurrY - nRage; Y--)
                        {
                            for (X = m_nCurrX - 1; X <= m_nCurrX + 1; X++)
                            {
                                if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                {
                                    if (MapCellInfo.ObjList.Count > 0)
                                    {
                                        for (int i = 0; i < MapCellInfo.ObjList.Count; i++)
                                        {
                                            OSObject = MapCellInfo.ObjList[i];
                                            if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                            {
                                                BaseObject = (TBaseObject)OSObject.CellObj;
                                                if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                                {
                                                    rList.Add(BaseObject);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:// Y ����--OK
                        for (int I = 0; I <= nRage; I++)
                        {
                            X = m_nCurrX + I;
                            Y = m_nCurrY - I;
                            for (X = X - 1; X <= X + 1; X++)
                            {
                                for (Y = Y - 1; Y <= Y + 1; Y++)
                                {
                                    if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                    {
                                        if (MapCellInfo.ObjList.Count > 0)
                                        {
                                            for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                            {
                                                OSObject = MapCellInfo.ObjList[j];
                                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                                {
                                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                                    if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                                    {
                                                        rList.Add(BaseObject);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_RIGHT:// ��--OK
                        for (X = m_nCurrX; X <= m_nCurrX + nRage; X++)
                        {
                            for (Y = m_nCurrY - 1; Y <= m_nCurrY + 1; Y++)
                            {
                                if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                {
                                    if (MapCellInfo.ObjList.Count > 0)
                                    {
                                        for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                        {
                                            OSObject = MapCellInfo.ObjList[j];
                                            if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                            {
                                                BaseObject = (TBaseObject)OSObject.CellObj;
                                                if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                                {
                                                    rList.Add(BaseObject);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:// X ����
                        for (int I = 0; I <= nRage; I++)
                        {
                            X = m_nCurrX + I;
                            Y = m_nCurrY + I;
                            for (X = X - 1; X <= X + 1; X++)
                            {
                                for (Y = Y - 1; Y <= Y + 1; Y++)
                                {
                                    if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                    {
                                        if (MapCellInfo.ObjList.Count > 0)
                                        {
                                            for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                            {
                                                OSObject = MapCellInfo.ObjList[j];
                                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                                {
                                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                                    if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                                    {
                                                        rList.Add(BaseObject);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWN:// ��--OK
                        for (Y = m_nCurrY; Y <= m_nCurrY + nRage; Y++)
                        {
                            for (X = m_nCurrX - 1; X <= m_nCurrX + 1; X++)
                            {
                                if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                {
                                    for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:// Y ������--OK
                        for (int I = 0; I <= nRage; I++)
                        {
                            X = m_nCurrX - I;
                            Y = m_nCurrY + I;
                            for (X = X - 1; X <= X + 1; X++)
                            {
                                for (Y = Y - 1; Y <= Y + 1; Y++)
                                {
                                    if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                    {
                                        if (MapCellInfo.ObjList.Count > 0)
                                        {
                                            for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                            {
                                                OSObject = MapCellInfo.ObjList[j];
                                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                                {
                                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                                    if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                                    {
                                                        rList.Add(BaseObject);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_LEFT:// ��--OK
                        for (X = m_nCurrX; X >= m_nCurrX - nRage; X--)
                        {
                            for (Y = m_nCurrY - 1; Y <= m_nCurrY + 1; Y++)
                            {
                                if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                {
                                    if (MapCellInfo.ObjList.Count > 0)
                                    {
                                        for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                        {
                                            OSObject = MapCellInfo.ObjList[j];
                                            if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                            {
                                                BaseObject = (TBaseObject)OSObject.CellObj;
                                                if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                                {
                                                    rList.Add(BaseObject);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_UPLEFT:// X ����
                        for (int I = 0; I <= nRage; I++)
                        {
                            X = m_nCurrX - I;
                            Y = m_nCurrY - I;
                            for (X = X - 1; X <= X + 1; X++)
                            {
                                for (Y = Y - 1; Y <= Y + 1; Y++)
                                {
                                    if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                                    {
                                        if (MapCellInfo.ObjList.Count > 0)
                                        {
                                            for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                            {
                                                OSObject = MapCellInfo.ObjList[j];
                                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                                {
                                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                                    if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                                    {
                                                        rList.Add(BaseObject);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            result = true;
            return result;
        }

        /// <summary>
        /// ȡͬ����Ĺ��� �����Ӱʹ���жϹֵ�����
        /// </summary>
        /// <param name="btDir"></param>
        /// <param name="nRage"></param>
        /// <returns></returns>
        public int GetDirBaseObjectsCount(int btDir, int nRage)
        {
            int result = 0;
            TMapCellinfo MapCellinfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            const string sExceptionMsg = "{�쳣} TBaseObject::GetDirectionBaseObjects";
            try
            {
                switch (btDir)
                {
                    case Grobal2.DR_UP:// ��
                        for (int Y = m_nCurrY; Y >= m_nCurrY - nRage; Y--)
                        {
                            if (m_PEnvir.GetMapCellInfo(m_nCurrX, Y, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:// ����
                        for (int i = 0; i <= nRage; i++)
                        {
                            int X = m_nCurrX + i;
                            int Y = m_nCurrY - i;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_RIGHT:// ��
                        for (int X = m_nCurrX; X <= m_nCurrX + nRage; X++)
                        {
                            if (m_PEnvir.GetMapCellInfo(X, m_nCurrY, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:// ����
                        for (int i = 0; i <= nRage; i++)
                        {
                            int X = m_nCurrX + i;
                            int Y = m_nCurrY + i;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWN:// ��
                        for (int Y = m_nCurrY; Y <= m_nCurrY + nRage; Y++)
                        {
                            if (m_PEnvir.GetMapCellInfo(m_nCurrX, Y, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:// ������
                        for (int i = 0; i <= nRage; i++)
                        {
                            int X = m_nCurrX - i;
                            int Y = m_nCurrY + i;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_LEFT:// ��
                        for (int X = m_nCurrX; X >= m_nCurrX - nRage; X--)
                        {
                            if (m_PEnvir.GetMapCellInfo(X, m_nCurrY, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_UPLEFT:// ����
                        for (int i = 0; i <= nRage; i++)
                        {
                            int X = m_nCurrX - i;
                            int Y = m_nCurrY - i;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellinfo) && (MapCellinfo.ObjList != null))
                            {
                                if (MapCellinfo.ObjList.Count > 0)
                                {
                                    for (int j = 0; j < MapCellinfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellinfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                result++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            return result;
        }

        /// <summary>
        /// ���ͬ��������һ����Χ��Ĺ�
        /// </summary>
        /// <param name="btDir"></param>
        /// <param name="nRage"></param>
        /// <param name="rList"></param>
        /// <returns></returns>
        public bool GetDirectionBaseObjects(int btDir, int nRage, List<TBaseObject> rList)
        {
            bool result = false;
            int I, j, X, Y;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            const string sExceptionMsg = "{�쳣} TBaseObject::GetDirectionBaseObjects";
            if (rList == null)
            {
                return result;
            }
            try
            {
                switch (btDir)
                {
                    case Grobal2.DR_UP:// ��
                        for (Y = m_nCurrY - 1; Y >= m_nCurrY - nRage; Y--)
                        {
                            if (m_PEnvir.GetMapCellInfo(m_nCurrX, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:// ����
                        for (I = 1; I <= nRage; I++)
                        {
                            X = m_nCurrX + I;
                            Y = m_nCurrY - I;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_RIGHT:// ��
                        for (X = m_nCurrX + 1; X <= m_nCurrX + nRage; X++)
                        {
                            if (m_PEnvir.GetMapCellInfo(X, m_nCurrY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:// ����
                        for (I = 1; I <= nRage; I++)
                        {
                            X = m_nCurrX + I;
                            Y = m_nCurrY + I;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWN:// ��
                        for (Y = m_nCurrY + 1; Y <= m_nCurrY + nRage; Y++)
                        {
                            if (m_PEnvir.GetMapCellInfo(m_nCurrX, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:// ������
                        for (I = 1; I <= nRage; I++)
                        {
                            X = m_nCurrX - I;
                            Y = m_nCurrY + I;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_LEFT:// ��
                        for (X = m_nCurrX - 1; X >= m_nCurrX - nRage; X--)
                        {
                            if (m_PEnvir.GetMapCellInfo(X, m_nCurrY, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Grobal2.DR_UPLEFT:// ����
                        for (I = 1; I <= nRage; I++)
                        {
                            X = m_nCurrX - I;
                            Y = m_nCurrY - I;
                            if (m_PEnvir.GetMapCellInfo(X, Y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                            {
                                if (MapCellInfo.ObjList.Count > 0)
                                {
                                    for (j = 0; j < MapCellInfo.ObjList.Count; j++)
                                    {
                                        OSObject = MapCellInfo.ObjList[j];
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                        {
                                            BaseObject = (TBaseObject)OSObject.CellObj;
                                            if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                            {
                                                rList.Add(BaseObject);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            result = true;
            return result;
        }

        /// <summary>
        /// ȡ��ͼ���귶Χ�ڵĹ�
        /// </summary>
        /// <param name="tEnvir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRage"></param>
        /// <param name="rList"></param>
        /// <returns></returns>
        public bool GetMapBaseObjects(TEnvirnoment tEnvir, int nX, int nY, int nRage, List<TBaseObject> rList)
        {
            bool result = false;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            const string sExceptionMsg = "{�쳣} TBaseObject::GetMapBaseObjects";
            if (rList == null)
            {
                return result;
            }
            try
            {
                int nStartX = nX - nRage;
                int nEndX = nX + nRage;
                int nStartY = nY - nRage;
                int nEndY = nY + nRage;
                for (int x = nStartX; x <= nEndX; x++)
                {
                    for (int y = nStartY; y <= nEndY; y++)
                    {
                        if (tEnvir.GetMapCellInfo(x, y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                        {
                            if (MapCellInfo.ObjList.Count > 0)
                            {
                                for (int j = 0; j < MapCellInfo.ObjList.Count; j++)
                                {
                                    OSObject = MapCellInfo.ObjList[j];
                                    if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                    {
                                        BaseObject = (TBaseObject)OSObject.CellObj;
                                        if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                        {
                                            rList.Add(BaseObject);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            result = true;
            return result;
        }

        /// <summary>
        /// ���͹㲥��Ϣ
        /// 12��Χ�����������Ч
        /// </summary>
        /// <param name="wIdent"></param>
        /// <param name="wParam"></param>
        /// <param name="nParam1"></param>
        /// <param name="nParam2"></param>
        /// <param name="nParam3"></param>
        /// <param name="sMsg"></param>
        public void SendRefMsg(int wIdent, object wParam, object nParam1, object nParam2, object nParam3, string sMsg)
        {
            int k;
            int nC;
            int nCX;
            int nCY;
            int nLX;
            int nLY;
            int nHX;
            int nHY;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject = null;
            TBaseObject BaseObject = null;
            byte btType;
            byte nCode = 0;
            bool boIsClear = false;
            const string sExceptionMsg = "{�쳣} TBaseObject::SendRefMsg Name:%s Code:{0}";
            try
            {
                if ((m_PEnvir == null))
                {
                    return;
                }
                nCode = 1;
                if (m_boObMode || m_boFixedHideMode)
                {
                    nCode = 2;
                    SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                    return;
                }
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                nCode = 30;
                try
                {
                    if (m_VisibleHumanList != null)
                    {
                        nCode = 31;
                        if (m_VisibleHumanList.Count == 0)
                        {
                            boIsClear = true;
                        }
                    }
                }
                catch
                {
                }
                nCode = 4;
                try
                {
                    if (((HUtil32.GetTickCount() - m_SendRefMsgTick) >= 500) || boIsClear)
                    {
                        m_SendRefMsgTick = HUtil32.GetTickCount();
                        nCode = 5;
                        try
                        {
                            m_VisibleHumanList.Clear();
                        }
                        catch
                        {
                        }
                        nCode = 6;
                        nLX = m_nCurrX - GameConfig.nSendRefMsgRange;// 12
                        nHX = m_nCurrX + GameConfig.nSendRefMsgRange;// 12
                        nLY = m_nCurrY - GameConfig.nSendRefMsgRange;// 12
                        nHY = m_nCurrY + GameConfig.nSendRefMsgRange;// 12
                        nCode = 7;
                        for (nCX = nLX; nCX <= nHX; nCX++)
                        {
                            for (nCY = nLY; nCY <= nHY; nCY++)
                            {
                                nCode = 8;
                                if (m_PEnvir.GetMapCellInfo(nCX, nCY, ref MapCellInfo))
                                {
                                    nCode = 9;
                                    if (MapCellInfo.ObjList != null)
                                    {
                                        if ((MapCellInfo.ObjList != null))
                                        {
                                            if (MapCellInfo.ObjList.Count > 0)
                                            {
                                                nCode = 200;
                                                for (k = MapCellInfo.ObjList.Count - 1; k >= 0; k--)
                                                {
                                                    nCode = 201;
                                                    if (MapCellInfo.ObjList.Count <= 0)
                                                    {
                                                        break;
                                                    }
                                                    nCode = 202;
                                                    try
                                                    {
                                                        OSObject = MapCellInfo.ObjList[k];
                                                    }
                                                    catch
                                                    {
                                                    }
                                                    nCode = 11;
                                                    if (OSObject != null)
                                                    {
                                                        nCode = 111;
                                                        try
                                                        {
                                                            btType = OSObject.btType;
                                                        }
                                                        catch
                                                        {
                                                            nCode = 112;
                                                            MapCellInfo.ObjList.RemoveAt(k);
                                                            nCode = 113;
                                                            if (MapCellInfo.ObjList.Count > 0)
                                                            {
                                                                continue;
                                                            }
                                                            nCode = 114;
                                                            MapCellInfo.ObjList = null;
                                                            m_PEnvir.UpdateMapCellInfo(nCX, nCY, MapCellInfo);
                                                            break;
                                                        }
                                                        if (btType == Grobal2.OS_MOVINGOBJECT)
                                                        {
                                                            if ((HUtil32.GetTickCount() - OSObject.dwAddTime) >= 60000) // 60 * 1000
                                                            {
                                                                nCode = 12;
                                                                if (MapCellInfo.ObjList != null)
                                                                {
                                                                    MapCellInfo.ObjList.RemoveAt(k);
                                                                }
                                                                Dispose(OSObject);
                                                                nCode = 121;
                                                                if (MapCellInfo.ObjList.Count <= 0)
                                                                {
                                                                    MapCellInfo.ObjList = null;
                                                                    m_PEnvir.UpdateMapCellInfo(nCX, nCY, MapCellInfo);
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                nCode = 122;
                                                                try
                                                                {
                                                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                                                    if ((BaseObject != null))
                                                                    {
                                                                        nCode = 123;
                                                                        if ((BaseObject.m_PEnvir == m_PEnvir) && (!BaseObject.m_boGhost))
                                                                        {
                                                                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                                            {
                                                                                nCode = 124;
                                                                                if (!((BaseObject) as TPlayObject).m_boNotOnlineAddExp)
                                                                                {
                                                                                    nCode = 125;
                                                                                    BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                                                                                    nCode = 126;
                                                                                    if ((m_VisibleHumanList != null) && (BaseObject != null))
                                                                                    {
                                                                                        m_VisibleHumanList.Add(BaseObject);
                                                                                    }
                                                                                    nCode = 130;
                                                                                }
                                                                            }
                                                                            else if (BaseObject.m_boWantRefMsg)
                                                                            {
                                                                                nCode = 127;
                                                                                if ((wIdent == Grobal2.RM_STRUCK) || (wIdent == Grobal2.RM_HEAR) || (wIdent == Grobal2.RM_DEATH)
                                                                                    || (wIdent == Grobal2.RM_CHARSTATUSCHANGED))
                                                                                {
                                                                                    // ���ӷ����ħ����Ч��
                                                                                    nCode = 128;
                                                                                    BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                                                                                    nCode = 129;
                                                                                    if ((m_VisibleHumanList != null) && (BaseObject != null))
                                                                                    {
                                                                                        m_VisibleHumanList.Add(BaseObject);
                                                                                    }
                                                                                    nCode = 130;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                catch
                                                                {
                                                                    MapCellInfo.ObjList.RemoveAt(k);
                                                                    if (MapCellInfo.ObjList.Count <= 0)
                                                                    {
                                                                        MapCellInfo.ObjList = null;
                                                                        m_PEnvir.UpdateMapCellInfo(nCX, nCY, MapCellInfo);
                                                                    }
                                                                    M2Share.MainOutMessage(string.Format(sExceptionMsg, m_sCharName, nCode));
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        nCode = 131;
                        if (m_VisibleHumanList != null)
                        {
                            nCode = 132;
                            if (m_VisibleHumanList.Count > 0)
                            {
                                nCode = 14;
                                for (nC = 0; nC < m_VisibleHumanList.Count; nC++)
                                {
                                    nCode = 15;
                                    try
                                    {
                                        BaseObject = ((m_VisibleHumanList[nC]) as TBaseObject);
                                    }
                                    catch
                                    {
                                        M2Share.MainOutMessage(string.Format(sExceptionMsg, m_sCharName));
                                    }
                                    nCode = 151;
                                    if ((BaseObject != null))
                                    {
                                        if ((!BaseObject.m_boGhost) && (BaseObject.m_PEnvir == m_PEnvir) && (Math.Abs(BaseObject.m_nCurrX - m_nCurrX) < 11)
                                            && (Math.Abs(BaseObject.m_nCurrY - m_nCurrY) < 11))
                                        {
                                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                nCode = 16;
                                                if (!((BaseObject) as TPlayObject).m_boNotOnlineAddExp)// �ǹһ���������Ϣ
                                                {
                                                    BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                                                }
                                            }
                                            else if (BaseObject.m_boWantRefMsg)
                                            {
                                                nCode = 17;
                                                if (((int)wIdent == Grobal2.RM_STRUCK) || ((int)wIdent == Grobal2.RM_HEAR)
                                                    || ((int)wIdent == Grobal2.RM_DEATH) || ((int)wIdent == Grobal2.RM_CHARSTATUSCHANGED))
                                                {
                                                    BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject::SendRefMsg Code:" + nCode);
            }
        }

        /// <summary>
        /// ���¿ɼ������б�
        /// </summary>
        /// <param name="BaseObject"></param>
        public void UpdateVisibleGay(TBaseObject BaseObject)
        {
            TVisibleBaseObject VisibleBaseObject = null;
            byte nCode = 0;
            try
            {
                nCode = 0;
                if (BaseObject == null)
                {
                    return;
                }
                if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_Master != null))
                {
                    m_boIsVisibleActive = true; // ���������򱦱�����true
                }
                nCode = 1;
                for (int I = 0; I < m_VisibleActors.Count; I++)
                {
                    nCode = 2;
                    VisibleBaseObject = m_VisibleActors[I];
                    nCode = 3;
                    if ((VisibleBaseObject != null) && (BaseObject != null))
                    {
                        nCode = 4;
                        if (VisibleBaseObject.BaseObject == BaseObject)
                        {
                            nCode = 5;
                            VisibleBaseObject.nVisibleFlag = 1;
                            return;
                        }
                    }
                }
                try
                {
                    nCode = 6;
                    VisibleBaseObject = new TVisibleBaseObject();
                    VisibleBaseObject.nVisibleFlag = 2;
                    VisibleBaseObject.BaseObject = BaseObject;
                    nCode = 7;
                    m_VisibleActors.Add(VisibleBaseObject);
                }
                catch
                {
                    Dispose(VisibleBaseObject);
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.UpdateVisibleGay Code:" + nCode);
            }
        }

        /// <summary>
        /// ���¿ɼ�����Ʒ
        /// </summary>
        /// <param name="wX"></param>
        /// <param name="wY"></param>
        /// <param name="MapItem"></param>
        public void UpdateVisibleItem(int wX, int wY, TMapItem MapItem)
        {
            TVisibleMapItem VisibleMapItem;
            if (m_VisibleItems.Count > 0)
            {
                for (int I = 0; I < m_VisibleItems.Count; I++)
                {
                    VisibleMapItem = m_VisibleItems[I];
                    if (VisibleMapItem != null)
                    {
                        if ((VisibleMapItem.MapItem != null) && (VisibleMapItem.MapItem == MapItem))
                        {
                            VisibleMapItem.nVisibleFlag = 1;
                            return;
                        }
                    }
                }
            }
            VisibleMapItem = new TVisibleMapItem();
            VisibleMapItem.nVisibleFlag = 2;
            VisibleMapItem.nX = wX;
            VisibleMapItem.nY = wY;
            VisibleMapItem.MapItem = MapItem;
            VisibleMapItem.sName = MapItem.Name;
            VisibleMapItem.wLooks = MapItem.Looks;
            m_VisibleItems.Add(VisibleMapItem);
        }

        /// <summary>
        /// ���¿ɼ����¼�
        /// </summary>
        /// <param name="wX"></param>
        /// <param name="wY"></param>
        /// <param name="MapEvent"></param>
        public void UpdateVisibleEvent(int wX, int wY, TEvent MapEvent)
        {
            bool boIsVisible = false;
            TVisibleMapEvent VisibleMapEvent = null;
            if (m_VisibleEvents.Count > 0)
            {
                for (int I = 0; I < m_VisibleEvents.Count; I++)
                {
                    VisibleMapEvent = m_VisibleEvents[I];
                    if (VisibleMapEvent != null)
                    {
                        if (VisibleMapEvent.MapEvent == MapEvent)
                        {
                            VisibleMapEvent.nVisibleFlag = 1;
                            boIsVisible = true;
                            break;
                        }
                    }
                }
            }
            if (boIsVisible)
            {
                return;
            }
            VisibleMapEvent = new TVisibleMapEvent();
            VisibleMapEvent.MapEvent = MapEvent;
            VisibleMapEvent.nVisibleFlag = 2;
            VisibleMapEvent.nX = wX;
            VisibleMapEvent.nY = wY;
            m_VisibleEvents.Add(VisibleMapEvent);
        }

        /// <summary>
        /// �����鿴��Χ
        /// </summary>
        public virtual void SearchViewRange()
        {
            int nStartX;
            int nEndX;
            int nStartY;
            int nEndY;
            int nIdx;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject = null;
            TBaseObject BaseObject;
            TMapItem MapItem;
            TVisibleBaseObject VisibleBaseObject = null;
            TVisibleMapItem VisibleMapItem;
            byte nCheckCode = 0;
            byte btType;
            int nVisibleFlag;
            try
            {
                if (this == null)
                {
                    return;
                }
                if (m_PEnvir == null)
                {
                    M2Share.MainOutMessage("SearchViewRange nil PEnvir Name:" + m_sCharName);
                    KickException();//��ͼ�����ڣ����߳���ɫ
                    return;
                }
                nCheckCode = 1;
                m_boIsVisibleActive = false;// ����ΪFALSE
                if (m_VisibleItems.Count > 0)
                {
                    for (int I = 0; I < m_VisibleItems.Count; I++)
                    {
                        VisibleMapItem = m_VisibleItems[I];
                        if (VisibleMapItem != null)
                        {
                            VisibleMapItem.nVisibleFlag = 0;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format("{�쳣} TBaseObject::SearchViewRange Code:{0}", nCheckCode));
                KickException();
            }
            nCheckCode = 2;
            try
            {
                if (m_VisibleActors.Count > 0)
                {
                    for (int I = 0; I < m_VisibleActors.Count; I++)
                    {
                        VisibleBaseObject = m_VisibleActors[I];
                        if (VisibleBaseObject != null)
                        {
                            VisibleBaseObject.nVisibleFlag = 0;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format("{�쳣} TBaseObject::SearchViewRange Code:{0}", nCheckCode));
                KickException();
            }
            try
            {
                nStartX = m_nCurrX - m_nViewRange;
                nEndX = m_nCurrX + m_nViewRange;
                nStartY = m_nCurrY - m_nViewRange;
                nEndY = m_nCurrY + m_nViewRange;
                nCheckCode = 3;
                for (int n18 = nStartX; n18 <= nEndX; n18++)
                {
                    for (int n1C = nStartY; n1C <= nEndY; n1C++)
                    {
                        nCheckCode = 4;
                        if (m_PEnvir.GetMapCellInfo(n18, n1C, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                        {
                            nCheckCode = 5;
                            nIdx = 0;
                            while (true)
                            {
                                nCheckCode = 53;
                                if (MapCellInfo.ObjList.Count <= nIdx)
                                {
                                    break;
                                }
                                nCheckCode = 52;
                                try
                                {
                                    OSObject = MapCellInfo.ObjList[nIdx];
                                }
                                catch
                                {
                                }
                                nCheckCode = 51;
                                if (OSObject != null)
                                {
                                    nCheckCode = 61;
                                    try
                                    {
                                        btType = OSObject.btType;// ��ֹ�ڴ����
                                    }
                                    catch
                                    {
                                        nCheckCode = 62;
                                        MapCellInfo.ObjList.RemoveAt(nIdx);
                                        if (MapCellInfo.ObjList.Count > 0)
                                        {
                                            continue;
                                        }
                                        nCheckCode = 63;
                                        MapCellInfo.ObjList = null;
                                        m_PEnvir.UpdateMapCellInfo(n18, n1C, MapCellInfo);
                                        break;
                                    }
                                    nCheckCode = 6;
                                    if (btType == Grobal2.OS_MOVINGOBJECT)
                                    {
                                        if ((HUtil32.GetTickCount() - OSObject.dwAddTime) >= 60000)//60 * 1000
                                        {
                                            nCheckCode = 70;
                                            MapCellInfo.ObjList.RemoveAt(nIdx);
                                            nCheckCode = 71;
                                            Dispose(OSObject);
                                            nCheckCode = 72;
                                            if (MapCellInfo.ObjList.Count > 0)
                                            {
                                                continue;
                                            }
                                            nCheckCode = 73;
                                            MapCellInfo.ObjList = null;
                                            m_PEnvir.UpdateMapCellInfo(n18, n1C, MapCellInfo);
                                            nCheckCode = 74;
                                            break;
                                        }
                                        nCheckCode = 8;
                                        BaseObject = (TBaseObject)OSObject.CellObj;
                                        if (BaseObject != null)
                                        {
                                            if ((!BaseObject.m_boGhost) && (!BaseObject.m_boFixedHideMode) && (!BaseObject.m_boObMode))
                                            {
                                                // ����,���¶�ħ3���,�Ͳ��ܹ���Ӣ��
                                                if ((m_btRaceServer < Grobal2.RC_ANIMAL) || (m_Master != null) || m_boCrazyMode || m_boWantRefMsg ||
                                                    ((BaseObject.m_Master != null) && (Math.Abs(BaseObject.m_nCurrX - m_nCurrX) <= 7)
                                                    && (Math.Abs(BaseObject.m_nCurrY - m_nCurrY) <= 7))
                                                    || (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                                {
                                                    nCheckCode = 9;
                                                    UpdateVisibleGay(BaseObject);
                                                }
                                            }
                                        }
                                    }
                                    // ���ӷ���������������Ʒ
                                    nCheckCode = 10;
                                    if (((m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                        && (m_Master != null) && (m_nCopyHumanLevel > 0))
                                    {
                                        if ((OSObject != null) && (OSObject.btType == Grobal2.OS_ITEMOBJECT))
                                        {
                                            nCheckCode = 11;
                                            if ((HUtil32.GetTickCount() - OSObject.dwAddTime) > GameConfig.dwClearDropOnFloorItemTime) // 60 * 60 * 1000
                                            {
                                                nCheckCode = 111;
                                                if (OSObject.CellObj != null)
                                                {
                                                    Dispose(OSObject.CellObj);
                                                }
                                                nCheckCode = 112;
                                                if ((OSObject != null))
                                                {
                                                    Dispose(OSObject);
                                                }
                                                nCheckCode = 113;
                                                MapCellInfo.ObjList.RemoveAt(nIdx);
                                                nCheckCode = 114;
                                                if (MapCellInfo.ObjList.Count > 0)
                                                {
                                                    continue;
                                                }
                                                MapCellInfo.ObjList = null;
                                                m_PEnvir.UpdateMapCellInfo(n18, n1C, MapCellInfo);
                                                break;
                                            }
                                            MapItem = (TMapItem)OSObject.CellObj;
                                            nCheckCode = 12;
                                            UpdateVisibleItem(n18, n1C, MapItem);
                                            nCheckCode = 13;
                                            if ((MapItem.OfBaseObject != null) || (MapItem.DropBaseObject != null))
                                            {
                                                if ((HUtil32.GetTickCount() - MapItem.dwCanPickUpTick) > GameConfig.dwFloorItemCanPickUpTime) // 2 * 60 * 1000
                                                {
                                                    MapItem.OfBaseObject = null;
                                                    MapItem.DropBaseObject = null;
                                                }
                                                else
                                                {
                                                    nCheckCode = 14;
                                                    if (((MapItem.OfBaseObject) as TBaseObject) != null)
                                                    {
                                                        if (((MapItem.OfBaseObject) as TBaseObject).m_boGhost)
                                                        {
                                                            MapItem.OfBaseObject = null;
                                                        }
                                                    }
                                                    if (((MapItem.DropBaseObject) as TBaseObject) != null)
                                                    {
                                                        if (((MapItem.DropBaseObject) as TBaseObject).m_boGhost)
                                                        {
                                                            MapItem.DropBaseObject = null;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                nIdx++;
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format("{�쳣} TBaseObject::SearchViewRange {0} {1} {2} {3} {4}", m_sCharName, m_sMapName, m_nCurrX, m_nCurrY, nCheckCode));
                KickException();
            }
            try
            {
                nCheckCode = 15;
                int n18 = 0;
                while (true)
                {
                    if (m_VisibleItems.Count <= n18)
                    {
                        break;
                    }
                    nCheckCode = 16;
                    VisibleMapItem = m_VisibleItems[n18];
                    nCheckCode = 17;
                    if (VisibleMapItem == null)
                    {
                        m_VisibleItems.RemoveAt(n18);
                        continue;
                    }
                    try
                    {
                        nCheckCode = 18;
                        nVisibleFlag = VisibleMapItem.nVisibleFlag;
                    }
                    catch
                    {
                        m_VisibleItems.RemoveAt(n18);
                        continue;
                    }
                    if (nVisibleFlag == 0)
                    {
                        nCheckCode = 19;
                        m_VisibleItems.RemoveAt(n18);
                        nCheckCode = 20;
                        if (VisibleMapItem != null)
                        {
                            Dispose(VisibleMapItem);
                        }
                        continue;
                    }
                    n18++;
                }
                nCheckCode = 21;
                n18 = 0;
                while (true)
                {
                    if (m_VisibleActors.Count <= n18)
                    {
                        break;
                    }
                    nCheckCode = 22;
                    VisibleBaseObject = m_VisibleActors[n18];
                    nCheckCode = 23;
                    if (VisibleBaseObject == null)
                    {
                        m_VisibleActors.RemoveAt(n18);
                        continue;
                    }
                    try
                    {
                        nCheckCode = 24;
                        nVisibleFlag = VisibleBaseObject.nVisibleFlag;
                    }
                    catch
                    {
                        m_VisibleActors.RemoveAt(n18);
                        continue;
                    }
                    if (nVisibleFlag == 0)
                    {
                        nCheckCode = 25;
                        m_VisibleActors.RemoveAt(n18);
                        nCheckCode = 26;
                        if (VisibleBaseObject != null)
                        {
                            Dispose(VisibleBaseObject);
                        }
                        nCheckCode = 27;
                        continue;
                    }
                    n18++;
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format("{�쳣} TBaseObject::SearchViewRange {0} {1} {2} {3} {4}", m_sCharName, m_sMapName, m_nCurrX,
                    m_nCurrY, nCheckCode));
                KickException();
            }
        }

        /// <summary>
        /// ��װ�ı�
        /// </summary>
        /// <returns></returns>
        public int GetFeatureToLong()
        {
            return GetFeature(null);
        }

        /// <summary>
        /// ȡ��װЧ��
        /// </summary>
        /// <returns></returns>
        public ushort GetFeatureEx()
        {
            return m_boOnHorse ? HUtil32.MakeWord(m_btHorseType, m_btDressEffType) : HUtil32.MakeWord(0, m_btDressEffType);
        }

        /// <summary>
        /// ��ȡ���
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public unsafe int GetFeature(TBaseObject BaseObject)
        {
            int result = 0;
            int nDress;
            int nWeapon;
            int nHair = 0;
            int nRaceImg;
            int nAppr;
            TStdItem* StdItem;
            bool bo25;
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
            {
                nDress = 0;
                if (m_UseItems[TPosition.U_DRESS]->wIndex > 0) // �·�
                {
                    StdItem = UserEngine.GetStdItem(m_UseItems[TPosition.U_DRESS]->wIndex);
                    if (StdItem != null)
                    {
                        nDress = StdItem->Shape * 2;
                    }
                }
                nDress += m_btGender;
                nWeapon = 0;
                if (m_UseItems[TPosition.U_WEAPON]->wIndex > 0) // ����
                {
                    StdItem = UserEngine.GetStdItem(m_UseItems[TPosition.U_WEAPON]->wIndex);
                    if (StdItem != null)
                    {
                        nWeapon = StdItem->Shape * 2;
                    }
                }
                nWeapon += m_btGender;
                if (m_UseItems[TPosition.U_ZHULI]->wIndex > 0) // ����
                {
                    StdItem = UserEngine.GetStdItem(m_UseItems[TPosition.U_ZHULI]->wIndex);
                    if (StdItem != null)
                    {
                        switch (StdItem->Shape)
                        {
                            case 0:
                                nHair = Byte.MaxValue;// ��ͨ����
                                break;
                            case 1:
                                nHair = 254; // ����
                                break;
                            case 2:
                                nHair = 254;// ����
                                break;
                            case 3:
                                nHair = 253;// ��ţ���� 
                                break;
                            case 4:
                                nHair = 252;// ��ɱ����   
                                break;
                        }
                    }
                    else
                    {
                        nHair = m_btHair * 2 + m_btGender;
                    }
                }
                else
                {
                    nHair = m_btHair * 2 + m_btGender;
                }
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    result = HUtil32.MakeHumanFeature((byte)Grobal2.RC_PLAYOBJECT, (byte)nDress, (byte)nWeapon, (byte)nHair);
                }
                if (m_btRaceServer == Grobal2.RC_PLAYMOSTER)
                {
                    result = HUtil32.MakeHumanFeature((byte)Grobal2.RC_PLAYMOSTER, (byte)nDress, (byte)nWeapon, (byte)nHair);
                }
                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    result = HUtil32.MakeHumanFeature((byte)1, (byte)nDress, (byte)nWeapon, (byte)nHair);
                }
                return result;
            }
            bo25 = false;
            if ((BaseObject != null) && (BaseObject.bo245))
            {
                bo25 = true;
            }
            if (bo25)
            {
                nRaceImg = m_btRaceImg;
                nAppr = m_wAppr;
                switch (nAppr)
                {
                    case 0:
                        nRaceImg = 12;
                        nAppr = 5;
                        break;
                    case 1:
                        nRaceImg = 11;
                        nAppr = 9;
                        break;
                    case 160:
                        nRaceImg = 10;
                        nAppr = 0;
                        break;
                    case 161:
                        nRaceImg = 10;
                        nAppr = 1;
                        break;
                    case 162:
                        nRaceImg = 11;
                        nAppr = 6;
                        break;
                    case 163:
                        nRaceImg = 11;
                        nAppr = 3;
                        break;
                }
                result = HUtil32.MakeMonsterFeature((byte)nRaceImg, m_btMonsterWeapon, (ushort)nAppr);
                return result;
            }
            result = HUtil32.MakeMonsterFeature(m_btRaceImg, m_btMonsterWeapon, m_wAppr);
            return result;
        }

        /// <summary>
        /// ȡ��ǰ״ֵ̬
        /// </summary>
        /// <returns></returns>
        public int GetCharStatus()
        {
            int result = 0;
            int nStatus = 0;
            try
            {
                for (int I = m_wStatusTimeArr.GetLowerBound(0); I <= m_wStatusTimeArr.GetUpperBound(0); I++)
                {
                    if (m_wStatusTimeArr[I] > 0)
                    {
                        nStatus = Convert.ToInt32((0x80000000 >> I)) | nStatus;
                        // (* $80000000 ָʮ������ֵ��ת�ɶ�������Ϊ10000000000000000000000000000000  Ȼ��Shr����
                        // ����IΪ3,����3λ���õ�������ֵ��10000000000000000000000000000
                        // or ��������, ��Ҫ����������������������λ���㣬ֻ������һ����1�ͷ���1; ����0�ŷ���0
                        // �������㷨�õ������� nStatus�õ���1,*)
                    }
                }
                result = (m_nCharStatusEx & 0xFFFFF) | nStatus;// and or ��Ϊ�����Ƶ�λ����
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.GetCharStatus");
            }
            return result;
        }

        /// <summary>
        /// ��������״̬����ɫ����
        /// </summary>
        public void AbilCopyToWAbil()
        {
            m_WAbil = m_Abil;
        }

        public void AddMapCount()
        {
            if (!m_boAddToMaped)
            {
                m_boDelFormMaped = false;
                m_boAddToMaped = true;
                if (m_PEnvir != null)
                {
                    m_PEnvir.AddObject(this);
                }
            }
        }

        public void DelMapCount()
        {
            if (!m_boDelFormMaped)
            {
                m_boDelFormMaped = true;
                m_boAddToMaped = false;
                if (m_PEnvir != null)
                {
                    m_PEnvir.DelObject(this);
                }
            }
        }

        /// <summary>
        /// ʼ����ħ��
        /// </summary>
        public unsafe virtual void Initialize()
        {
            TUserMagic* UserMagic;
            AbilCopyToWAbil();
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)m_MagicList[I];// �ļ���� �ļ��һ� �ļ������
                        if ((UserMagic->btLevel > 3) && (UserMagic->wMagIdx != 66) && (UserMagic->wMagIdx != 68) && !(new ArrayList(new int[] { 13, 26, 45, 88 }).Contains(UserMagic->wMagIdx)))
                        {
                            UserMagic->btLevel = 0; // ��4��ħ������
                        }
                    }
                }
            }
            else if ((m_btRaceServer == Grobal2.RC_PLAYMOSTER)) // Ӣ�۷��������4������
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)m_MagicList[I];
                        if ((m_Master != null) && (m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                        {
                            if (UserMagic->btLevel > 4)
                            {
                                UserMagic->btLevel = 0;
                            }
                            else if (UserMagic->btLevel > 3)
                            {
                                UserMagic->btLevel = 0;
                            }
                        }
                    }
                }
            }
            else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT)) // Ӣ�ۿ�����4������
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)m_MagicList[I];
                        if ((UserMagic->btLevel > 4) && (UserMagic->wMagIdx != 68))
                        {
                            UserMagic->btLevel = 0; // ������������
                        }
                    }
                }
            }
            m_boAddtoMapSuccess = true;
            if (m_PEnvir.CanWalk(m_nCurrX, m_nCurrY, true) && AddToMap())
            {
                m_boAddtoMapSuccess = false;
            }
            m_nCharStatus = GetCharStatus();
            AddBodyLuck(0);
            LoadSayMsg();
            if (GameConfig.boMonSayMsg)
            {
                MonsterSayMsg(null, TMonStatus.s_MonGen);
            }
        }

        /// <summary>
        /// ȡ�ù���˵����Ϣ�б�
        /// </summary>
        public void LoadSayMsg()
        {
            if (M2Share.g_MonSayMsgList.Count > 0)
            {
                for (int I = 0; I < M2Share.g_MonSayMsgList.Count; I++)
                {
                    if ((M2Share.g_MonSayMsgList[I]).ToLower().CompareTo((m_sCharName).ToLower()) == 0)
                    {
                        //m_SayMsgList = ((M2Share.g_MonSayMsgList[I]) as ArrayList);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// ��װЧ���ı�
        /// </summary>
        public void FeatureChanged()
        {
            SendRefMsg(Grobal2.RM_FEATURECHANGED, GetFeatureEx(), GetFeatureToLong(), 0, 0, "");
        }

        /// <summary>
        /// ״̬�ı�
        /// </summary>
        /// <param name="Str"></param>
        public void StatusChanged(string Str)
        {
            SendRefMsg(Grobal2.RM_CHARSTATUSCHANGED, m_nHitSpeed, m_nCharStatus, 0, 0, Str);
        }

        /// <summary>
        /// �������ʸı�
        /// </summary>
        public void OpenPulseNeedLevTabChanged()
        {
            m_PulseNeedLev[0] = (byte)GameConfig.PulsePointNGLevel0;
            m_PulseNeedLev[1] = (byte)GameConfig.PulsePointNGLevel1;
            m_PulseNeedLev[2] = (byte)GameConfig.PulsePointNGLevel2;
            m_PulseNeedLev[3] = (byte)GameConfig.PulsePointNGLevel3;
            m_PulseNeedLev[4] = (byte)GameConfig.PulsePointNGLevel4;
            m_PulseNeedLev[5] = (byte)GameConfig.PulsePointNGLevel5;
            m_PulseNeedLev[6] = (byte)GameConfig.PulsePointNGLevel6;
            m_PulseNeedLev[7] = (byte)GameConfig.PulsePointNGLevel7;
            m_PulseNeedLev[8] = (byte)GameConfig.PulsePointNGLevel8;
            m_PulseNeedLev[9] = (byte)GameConfig.PulsePointNGLevel9;
            m_PulseNeedLev[10] = (byte)GameConfig.PulsePointNGLevel10;
            m_PulseNeedLev[11] = (byte)GameConfig.PulsePointNGLevel11;
            m_PulseNeedLev[12] = (byte)GameConfig.PulsePointNGLevel12;
            m_PulseNeedLev[13] = (byte)GameConfig.PulsePointNGLevel13;
            m_PulseNeedLev[14] = (byte)GameConfig.PulsePointNGLevel14;
            m_PulseNeedLev[15] = (byte)GameConfig.PulsePointNGLevel15;
            m_PulseNeedLev[16] = (byte)GameConfig.PulsePointNGLevel16;
            m_PulseNeedLev[17] = (byte)GameConfig.PulsePointNGLevel17;
            m_PulseNeedLev[18] = (byte)GameConfig.PulsePointNGLevel18;
            m_PulseNeedLev[19] = (byte)GameConfig.PulsePointNGLevel19;
            SendMsg(this, Grobal2.RM_OPENPULSENEEDLEV, 0, 0, 0, 0, "");
        }

        public int StormsRateChanged_GetMagicIdByJob(byte Job, byte n)
        {
            int result = 0;
            switch (Job)
            {
                case 0:
                    switch (n)
                    {
                        case 0:
                            result = 76;
                            break;
                        case 1:
                            result = 79;
                            break;
                        case 2:
                            result = 82;
                            break;
                        case 3:
                            result = 85;
                            break;
                    }
                    break;
                case 1:
                    switch (n)
                    {
                        case 0:
                            result = 77;
                            break;
                        case 1:
                            result = 80;
                            break;
                        case 2:
                            result = 83;
                            break;
                        case 3:
                            result = 86;
                            break;
                    }
                    break;
                case 2:
                    switch (n)
                    {
                        case 0:
                            result = 78;
                            break;
                        case 1:
                            result = 81;
                            break;
                        case 2:
                            result = 84;
                            break;
                        case 3:
                            result = 87;
                            break;
                    }
                    break;
            }
            return result;
        }

        // ״̬�ı�
        public void StormsRateChanged()
        {
            m_HumStormsRate[0].nStormsRate = GameConfig.StormsHitAppearRate0;
            m_HumStormsRate[1].nStormsRate = GameConfig.StormsHitAppearRate1;
            m_HumStormsRate[2].nStormsRate = GameConfig.StormsHitAppearRate2;
            m_HumStormsRate[3].nStormsRate = GameConfig.StormsHitAppearRate3;
            m_HumStormsRate[4].nStormsRate = GameConfig.StormsHitAppearRate4;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                SendMsg(this, Grobal2.RM_STORMSRATECHANGED, 0, 0, 0, 0, "");
            }
            else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                //this.m_Master.SendMsg(this, Grobal2.RM_HEROSTORMSRATECHANGED, 0, 0, 0, 0, "");
                ((this.m_Master) as TPlayObject).SendMsg(this, Grobal2.RM_HEROSTORMSRATECHANGED, 0, 0, 0, 0, "");
            }
        }

        public virtual void Disappear() { }

        public void DisappearA()
        {
            TFlowerEvent FlowerEvent;
            TPlayObject PlayObject = null;
            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_Master != null))// Ӣ��ʬ����ʧ��,���Ͻ�Ӣ�۴��ڲ���ʧ
            {
                PlayObject = ((m_Master) as TPlayObject);
                if ((!PlayObject.m_boReconnection) && (!PlayObject.m_boSoftClose)
                    && (!((THeroObject)(this)).boCallLogOut))// ���˲���С��ʱ����ʾ����
                {
                    PlayObject.m_nRecallHeroTime = HUtil32.GetTickCount();// �ٻ�Ӣ�ۼ��
                    FlowerEvent = new TFlowerEvent(m_PEnvir, m_nCurrX, m_nCurrY, Grobal2.SM_HEROLOGOUT, 3000);// Ӣ���˳�������ʾ
                    M2Share.g_EventManager.AddEvent(FlowerEvent);
                }
                m_Master.SendMsg(m_Master, Grobal2.RM_HERODEATH, 0, 0, 0, 0, "");
                m_Master = null;
            }
            if (m_PEnvir != null)
            {
                if (m_PEnvir.DeleteFromMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this) != 1)
                {
                    DelMapCount();
                }
            }
            SendRefMsg(Grobal2.RM_DISAPPEAR, 0, 0, 0, 0, "");
        }

        /// <summary>
        /// �߳��쳣��ɫ
        /// </summary>
        public void KickException()
        {
            TPlayObject PlayObject;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                m_sMapName = GameConfig.sHomeMap;
                m_nCurrX = GameConfig.nHomeX;
                m_nCurrY = GameConfig.nHomeY;
                PlayObject = ((this) as TPlayObject);
                PlayObject.m_boEmergencyClose = true;
                PlayObject.m_boNotOnlineAddExp = false;
                PlayObject.m_boPlayOffLine = false;// �ر����ߴ���
            }
            else
            {
                m_boDeath = true;
                m_dwDeathTick = HUtil32.GetTickCount();
                MakeGhost();
            }
        }

        /// <summary>
        /// ��·
        /// </summary>
        /// <param name="nIdent"></param>
        /// <returns></returns>
        public bool Walk(int nIdent)
        {
            bool result = true;
            TMapCellinfo MapCellInfo;
            TOSObject OSObject;
            TGateObj GateObj;
            bool bo1D;
            TEvent __Event;
            TPlayObject PlayObject;
            int nCheckCode = -1;
            const string sExceptionMsg = "{�쳣} TBaseObject::Walk  CheckCode:{0} {1} {2} {3}:{4}";
            if (m_PEnvir == null)
            {
                M2Share.MainOutMessage("Walk nil PEnvir");
                return result;
            }
            try
            {
                nCheckCode = 1;
                MapCellInfo = new TMapCellinfo();
                bo1D = m_PEnvir.GetMapCellInfo(m_nCurrX, m_nCurrY, ref MapCellInfo);
                GateObj = null;
                __Event = null;
                nCheckCode = 2;
                if (bo1D && (MapCellInfo.ObjList != null))
                {
                    if (MapCellInfo.ObjList.Count > 0)
                    {
                        for (int I = 0; I < MapCellInfo.ObjList.Count; I++)
                        {
                            OSObject = MapCellInfo.ObjList[I];
                            if (OSObject != null)
                            {
                                if (OSObject.btType == Grobal2.OS_GATEOBJECT)
                                {
                                    GateObj = (TGateObj)OSObject.CellObj;
                                }
                                if (OSObject.btType == Grobal2.OS_EVENTOBJECT)
                                {
                                    if (((TEvent)OSObject.CellObj).m_OwnBaseObject != null) // ���¼� �����ǽ
                                    {
                                        __Event = (TEvent)OSObject.CellObj;
                                    }
                                }
                                if (OSObject.btType == Grobal2.OS_MAPEVENT)
                                {
                                }
                                if (OSObject.btType == Grobal2.OS_DOOR)
                                {
                                }
                                if (OSObject.btType == Grobal2.OS_ROON)
                                {
                                }
                            }
                        }
                    }
                }
                nCheckCode = 3;
                if (__Event != null)
                {
                    if (__Event.m_OwnBaseObject != null)
                    {
                        nCheckCode = 34;
                        if ((!__Event.m_OwnBaseObject.m_boRobotObject))
                        {
                            nCheckCode = 35;
                            if (__Event.m_OwnBaseObject.IsProperTarget(this))
                            {
                                nCheckCode = 33;
                                this.SendMsg(__Event.m_OwnBaseObject, Grobal2.RM_MAGSTRUCK_MINE, 0, __Event.m_nDamage, 0, 0, "");
                            }
                        }
                    }
                }
                nCheckCode = 4;
                if (result && (GateObj != null))
                {
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        if (m_PEnvir.ArroundDoorOpened(m_nCurrX, m_nCurrY))
                        {
                            if ((!GateObj.DEnvir.m_boNEEDHOLE) || (M2Share.g_EventManager.GetEvent(m_PEnvir, m_nCurrX, m_nCurrY, Grobal2.ET_DIGOUTZOMBI) != null))
                            {
                                if (M2Share.nServerIndex == GateObj.DEnvir.nServerIndex)
                                {
                                    if (!GateObj.DEnvir.m_boNEEDLEVELTIME) // �����ͼ����Ҫ�ȼ�
                                    {
                                        if (!EnterAnotherMap(GateObj.DEnvir, GateObj.nDMapX, GateObj.nDMapY))
                                        {
                                            result = false;
                                        }
                                    }
                                    else
                                    {
                                        if (m_Abil.Level >= GateObj.DEnvir.m_nNEEDLEVELPOINT) // ѩ���ͼ
                                        {
                                            if (!EnterAnotherMap(GateObj.DEnvir, GateObj.nDMapX, GateObj.nDMapY)) // �ȼ��ﵽʱ�ſɽ����ͼ
                                            {
                                                result = false;
                                            }
                                        }
                                        else
                                        {
                                            ((this) as TPlayObject).MoveToHome();// �ƶ����سǵ�
                                            SysMsg(string.Format(GameMsgDef.sNEEDLEVELToXYErrorMsg, GateObj.DEnvir.m_nNEEDLEVELPOINT), TMsgColor.c_Red, TMsgType.t_Hint);
                                        }
                                    }
                                }
                                else
                                {
                                    DisappearA();
                                    m_bo316 = true;
                                    PlayObject = ((this) as TPlayObject);
                                    PlayObject.m_sSwitchMapName = GateObj.DEnvir.sMapName;
                                    PlayObject.m_nSwitchMapX = GateObj.nDMapX;
                                    PlayObject.m_nSwitchMapY = GateObj.nDMapY;
                                    PlayObject.m_boSwitchData = true;
                                    PlayObject.m_nServerIndex = GateObj.DEnvir.nServerIndex;
                                    PlayObject.m_boEmergencyClose = true;
                                    PlayObject.m_boReconnection = true;
                                    PlayObject.m_boPlayOffLine = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    nCheckCode = 5;
                    if (result)
                    {
                        nCheckCode = 6;
                        SendRefMsg((ushort)nIdent, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode, m_sCharName, m_sMapName, m_nCurrX, m_nCurrY));
            }
            return result;
        }

        /// <summary>
        /// ����л���ͼ
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nDMapX"></param>
        /// <param name="nDMapY"></param>
        /// <returns></returns>
        public bool EnterAnotherMap(TEnvirnoment Envir, int nDMapX, int nDMapY)
        {
            bool result = false;
            TMapCellinfo MapCellInfo;
            TEnvirnoment OldEnvir;
            int nOldX;
            int nOldY;
            TUserCastle Castle;
            byte nCode = 0;
            TPlayObject PlayObject = null;
            const string sExceptionMsg1 = "{�쳣} TBaseObject::EnterAnotherMap -> MsgTargetList Clear";
            const string sExceptionMsg2 = "{�쳣} TBaseObject::EnterAnotherMap -> VisbleItems Dispose";
            const string sExceptionMsg3 = "{�쳣} TBaseObject::EnterAnotherMap -> VisbleItems Clear";
            const string sExceptionMsg4 = "{�쳣} TBaseObject::EnterAnotherMap -> VisbleEvents Clear";
            const string sExceptionMsg5 = "{�쳣} TBaseObject::EnterAnotherMap -> VisbleActors Dispose";
            const string sExceptionMsg6 = "{�쳣} TBaseObject::EnterAnotherMap -> VisbleActors Clear";
            const string sExceptionMsg7 = "{�쳣} TBaseObject::EnterAnotherMap";
            try
            {
                if (Envir == null)
                {
                    return result;
                }
                if (m_Abil.Level < Envir.nRequestLevel)
                {
                    return result;
                }
                nCode = 1;
                if (Envir != null)
                {
                    try
                    {
                        nCode = 15;
                        if (Envir.QuestNPC != null)
                        {
                            nCode = 17;
                            if (!m_boGhost)
                            {
                                ((TMerchant)(Envir.QuestNPC)).Click(((this) as TPlayObject));
                            }
                        }
                    }
                    catch
                    {
                        M2Share.MainOutMessage(sExceptionMsg7 + " Code:" + nCode);
                    }
                }
                nCode = 2;
                if (Envir.nNEEDSETONFlag >= 0)
                {
                    nCode = 3;
                    if (GetQuestFalgStatus(Envir.nNEEDSETONFlag) != Envir.nNeedONOFF)
                    {
                        return result;
                    }
                }
                nCode = 4;
                MapCellInfo = new TMapCellinfo();
                if (!Envir.GetMapCellInfo(nDMapX, nDMapY, ref MapCellInfo))//ȡ��ͼ·������ʧ�ܣ�������
                {
                    return result;
                }
                nCode = 5;
                Castle = M2Share.g_CastleManager.IsCastlePalaceEnvir(Envir);
                if ((Castle != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    nCode = 6;
                    if (!Castle.CheckInPalace(m_nCurrX, m_nCurrY, this))
                    {
                        return result;
                    }
                }
                OldEnvir = m_PEnvir;
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                nCode = 7;
                DisappearA();
                nCode = 8;
                try
                {
                    m_VisibleHumanList.Clear();
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg1);
                }
                try
                {
                    if (m_VisibleItems.Count > 0)
                    {
                        for (int I = 0; I < m_VisibleItems.Count; I++)
                        {
                            if (m_VisibleItems[I] != null)
                            {
                                Dispose(m_VisibleItems[I]);
                            }
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg2);
                }
                try
                {
                    m_VisibleItems.Clear();
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg3);
                }
                try
                {
                    if (m_VisibleEvents.Count > 0)
                    {
                        for (int I = 0; I < m_VisibleEvents.Count; I++)
                        {
                            if (m_VisibleEvents[I] != null)
                            {
                                Dispose(m_VisibleEvents[I]);
                            }
                        }
                    }
                    m_VisibleEvents.Clear();
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg4);
                }
                try
                {
                    if (m_VisibleActors.Count > 0)
                    {
                        for (int I = 0; I < m_VisibleActors.Count; I++)
                        {
                            if (m_VisibleActors[I] != null)
                            {
                                Dispose(m_VisibleActors[I]);
                            }
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg5);
                }
                try
                {
                    m_VisibleActors.Clear();
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg6);
                }
                nCode = 9;
                SendMsg(this, Grobal2.RM_CLEAROBJECTS, 0, 0, 0, 0, "");
                m_PEnvir = Envir;
                m_sMapName = Envir.sMapName;
                m_nCurrX = nDMapX;
                m_nCurrY = nDMapY;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    PlayObject = ((this) as TPlayObject);
                    if (PlayObject.m_boForMapShowHint && (PlayObject.m_dwUserTick[0] > 0))// ����ͼ�Ƿ���ʾ����ʱ��Ϣ
                    {
                        PlayObject.m_dwUserTick[0] = 0;
                        PlayObject.m_dwUserTick[3] = 0;
                        PlayObject.m_boForMapShowHint = false;// ����ʱ��Ϣ
                        SendMsg(this, Grobal2.RM_MOVEMESSAGE, 2, 255, 0, 1, "");// �رտͻ�����ʾ����ʱ(��ݼ��Ϸ���ʾ)
                    }
                    if (PlayObject.m_boShowExpCrystal)
                    {
                        PlayObject.m_boShowExpCrystal = false;
                        PlayObject.m_boGetExpCrystalExp = false;// �Ƿ������ȡ����
                        SendMsg(this, Grobal2.RM_OPENEXPCRYSTAL, 0, 1, 0, 0, "");// ����Ϣ�ر���ؽᾧͼ��
                    }
                }
                SendMsg(this, Grobal2.RM_CHANGEMAP, 0, 0, 0, 0, M2Share.g_MapManager.GetMainMap(Envir));
                nCode = 10;
                if (AddToMap())
                {
                    m_dwMapMoveTick = HUtil32.GetTickCount();
                    m_bo316 = true;
                    result = true;
                }
                else
                {
                    m_PEnvir = OldEnvir;
                    m_nCurrX = nOldX;
                    m_nCurrY = nOldY;
                    nCode = 11;
                    m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                }
                nCode = 12;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)// ��λ�ݵ㣬����ң�ʱ��
                {
                    nCode = 13;
                    PlayObject = ((this) as TPlayObject);
                    PlayObject.m_dwIncGamePointTick = HUtil32.GetTickCount();
                    PlayObject.m_dwIncGameGoldTick = HUtil32.GetTickCount();
                    PlayObject.m_dwAutoGetExpTick = HUtil32.GetTickCount();
                }
                nCode = 14;
                if (m_PEnvir.m_boFight3Zone && (m_PEnvir.m_boFight3Zone != OldEnvir.m_boFight3Zone))
                {
                    RefShowName();
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg7 + " Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// ��ͼ����ƶ�
        /// </summary>
        /// <param name="nDir"></param>
        public void TurnTo(int nDir)
        {
            m_btDirection = (byte)nDir;
            SendRefMsg(Grobal2.RM_TURN, nDir, m_nCurrX, m_nCurrY, 0, "");
        }

        /// <summary>
        /// �������˵����Ϣ
        /// </summary>
        /// <param name="sMsg"></param>
        public virtual void ProcessSayMsg(string sMsg)
        {
            string sCharName;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                return;
            }
            sCharName = M2Share.FilterShowName(m_sCharName);
            SendRefMsg(Grobal2.RM_HEAR, 0, GameConfig.btHearMsgFColor, GameConfig.btHearMsgBColor, 0, sCharName + ":" + sMsg);
        }

        // ��ǿ���ļ���Ϣ���ͺ���(��NPC����-SendMsgʹ��)
        public void ProcessExtendSayMsg(string sMsg, byte FColor, byte BColor)
        {
            string sCharName;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                return;
            }
            sCharName = M2Share.FilterShowName(m_sCharName);
            SendRefMsg(Grobal2.RM_HEAR, 0, FColor, BColor, 0, sCharName + ":" + sMsg);
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="MsgColor"></param>
        /// <param name="MsgType"></param>
        public virtual void SysMsg(string sMsg, TMsgColor MsgColor, TMsgType MsgType)
        {
            string str = string.Empty;
            string FColor = string.Empty;
            string BColor = string.Empty;
            string nTime = string.Empty;
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (((this) as TPlayObject).m_boNotOnlineAddExp))//���⹫��
            {
                return;
            }
            if (GameConfig.boShowPreFixMsg)// �������ﲻ����
            {
                switch (MsgType)
                {
                    case TMsgType.t_Mon:
                        sMsg = GameConfig.sMonSayMsgpreFix + sMsg;
                        break;
                    case TMsgType.t_Hint:
                        sMsg = GameConfig.sHintMsgPreFix + sMsg;
                        break;
                    case TMsgType.t_GM:
                        sMsg = GameConfig.sGMRedMsgpreFix + sMsg;
                        break;
                    case TMsgType.t_System:
                        sMsg = GameConfig.sSysMsgPreFix + sMsg;
                        break;
                    case TMsgType.t_Cust:
                        sMsg = GameConfig.sCustMsgpreFix + sMsg;
                        break;
                    case TMsgType.t_Castle:
                        sMsg = GameConfig.sCastleMsgpreFix + sMsg;
                        break;
                }
            }
            // ���ӹ�������
            if (MsgType == TMsgType.t_Notice)// ��������ǹ���
            {
                if ((sMsg[0] == '['))  // ������������
                {
                    sMsg = HUtil32.ArrestStringEx(sMsg, "[", "]", ref str);
                    BColor = HUtil32.GetValidStrCap(str, ref FColor, new string[] { "," });
                    if (GameConfig.boShowPreFixMsg)
                    {
                        sMsg = GameConfig.sLineNoticePreFix + sMsg;
                    }
                    SendMsg(this, Grobal2.RM_MOVEMESSAGE, 0, HUtil32.Str_ToInt(FColor, 255), HUtil32.Str_ToInt(BColor, 255), 0, sMsg);
                }
                else if ((sMsg[0] == '{'))  // ��Ļ���й���
                {
                    sMsg = HUtil32.ArrestStringEx(sMsg, "{", "}", ref str);
                    str = HUtil32.GetValidStrCap(str, ref FColor, new string[] { "," });
                    str = HUtil32.GetValidStrCap(str, ref BColor, new string[] { "," });
                    str = HUtil32.GetValidStrCap(str, ref nTime, new string[] { "," });
                    if (GameConfig.boShowPreFixMsg)
                    {
                        sMsg = GameConfig.sLineNoticePreFix + sMsg;
                    }
                    SendMsg(this, Grobal2.RM_MOVEMESSAGE, 1, HUtil32.Str_ToInt(FColor, 255), HUtil32.Str_ToInt(BColor, 255), HUtil32.Str_ToInt(nTime, 0), sMsg);
                }
                else
                {
                    switch (MsgColor)// ���ƹ������ɫ
                    {
                        case TMsgColor.c_Red:
                            if (GameConfig.boShowPreFixMsg)
                            {
                                sMsg = GameConfig.sLineNoticePreFix + sMsg;
                            }
                            //255 56
                            SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btRedMsgFColor, GameConfig.btRedMsgBColor, 0, sMsg);
                            break;
                        case TMsgColor.c_Green:
                            if (GameConfig.boShowPreFixMsg)
                            {
                                sMsg = GameConfig.sLineNoticePreFix + sMsg;
                            }
                            SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btGreenMsgFColor, GameConfig.btGreenMsgBColor, 0, sMsg);
                            break;
                        case TMsgColor.c_Blue:
                            if (GameConfig.boShowPreFixMsg)
                            {
                                sMsg = GameConfig.sLineNoticePreFix + sMsg;
                            }
                            SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btBlueMsgFColor, GameConfig.btBlueMsgBColor, 0, sMsg);
                            break;
                    }
                }
            }
            else
            {
                switch (MsgColor)
                {
                    case TMsgColor.c_Green:
                        SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btGreenMsgFColor, GameConfig.btGreenMsgBColor, 0, sMsg);
                        break;
                    case TMsgColor.c_Blue:
                        SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btBlueMsgFColor, GameConfig.btBlueMsgBColor, 0, sMsg);
                        break;
                    case TMsgColor.c_Fuchsia:
                        SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btSayMsgFColor, GameConfig.btSayeMsgBColor, 0, sMsg);
                        break;
                    case TMsgColor.BB_Fuchsia:// ǧ�ﴫ����ɫ
                        SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, 241, 255, 0, sMsg);
                        break;
                    case TMsgColor.C_HeroHint:// ������ʾ��ɫ
                        SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, 255, 252, 0, sMsg);
                        break;
                    default:// Ӣ��״̬��ʾ(���װ���)
                        if (MsgType == TMsgType.t_Cust) // ף����
                        {
                            SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btCustMsgFColor, GameConfig.btCustMsgBColor, 0, sMsg);
                        }
                        else
                        {
                            SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, GameConfig.btRedMsgFColor, GameConfig.btRedMsgBColor, 0, sMsg);
                        }
                        break;
                }
            }
        }

        // ��ǿ���ļ���Ϣ���ͺ���
        public void SysMsg1(string sMsg, TMsgColor MsgColor, TMsgType MsgType, byte FColor, byte BColor)
        {
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (((this) as TPlayObject).m_boNotOnlineAddExp)) // �������ﲻ����
            {
                return;
            }
            if (GameConfig.boShowPreFixMsg)
            {
                switch (MsgType)
                {
                    case TMsgType.t_System:
                        sMsg = GameConfig.sSysMsgPreFix + sMsg;
                        break;
                }
            }
            switch (MsgColor)
            {
                case TMsgColor.c_Green:
                    SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, FColor, BColor, 0, sMsg);
                    break;
                case TMsgColor.c_Blue:
                    SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, FColor, BColor, 0, sMsg);
                    break;
                default:
                    SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, FColor, BColor, 0, sMsg);
                    break;
            }
        }

        /// <summary>
        /// ����˵��
        /// </summary>
        /// <param name="AttackBaseObject"></param>
        /// <param name="MonStatus"></param>
        public void MonsterSayMsg(TBaseObject AttackBaseObject, TMonStatus MonStatus)
        {
            string sMsg;
            TMonSayMsg MonSayMsg;
            string sAttackName = string.Empty;
            byte nCode;
            nCode = 0;
            try
            {
                if (m_SayMsgList == null)
                {
                    return;
                }
                nCode = 1;
                if ((AttackBaseObject != null))
                {
                    if ((AttackBaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (AttackBaseObject.m_Master == null))
                    {
                        return;
                    }
                    nCode = 2;
                    if (AttackBaseObject.m_Master != null)
                    {
                        sAttackName = AttackBaseObject.m_Master.m_sCharName;
                    }
                    else
                    {
                        sAttackName = AttackBaseObject.m_sCharName;
                    }
                }
                nCode = 3;
                if (m_SayMsgList.Count > 0)
                {
                    for (int I = 0; I < m_SayMsgList.Count; I++)
                    {
                        MonSayMsg = m_SayMsgList[I];
                        nCode = 4;
                        if (MonSayMsg == null)
                        {
                            continue;
                        }
                        nCode = 5;
                        sMsg = MonSayMsg.sSayMsg.Replace("%s", M2Share.FilterShowName(m_sCharName));
                        sMsg = sMsg.Replace("%d", sAttackName);
                        nCode = 6;
                        if ((MonSayMsg.State == MonStatus) && (HUtil32.Random(MonSayMsg.nRate) == 0))
                        {
                            if (MonStatus == TMonStatus.s_MonGen)
                            {
                                nCode = 7;
                                UserEngine.SendBroadCastMsg(sMsg, TMsgType.t_Mon);
                                break;
                            }
                            nCode = 8;
                            if (MonSayMsg.Color == TMsgColor.c_White)
                            {
                                nCode = 9;
                                ProcessSayMsg(sMsg);
                            }
                            else
                            {
                                nCode = 10;
                                if ((AttackBaseObject != null))
                                {
                                    AttackBaseObject.SysMsg(sMsg, MonSayMsg.Color, TMsgType.t_Mon);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.MonsterSayMsg Code:" + nCode);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual void MakeGhost()
        {
            m_boGhost = true;
            m_dwGhostTick = HUtil32.GetTickCount();
            DisappearA();
        }

        /// <summary>
        /// �������Ʒ��
        /// </summary>
        public unsafe void ApplyMeatQuality()
        {
            TStdItem* StdItem;
            TUserItem* UserItem;
            if (m_ItemList.Count > 0)
            {
                for (int I = 0; I < m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)m_ItemList[I];
                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                    if (StdItem != null)
                    {
                        if (StdItem->StdMode == 40) // ��
                        {
                            UserItem->Dura = (ushort)m_nMeatQuality;
                        }
                    }
                }
            }
        }

        public unsafe bool TakeBagItems(TBaseObject BaseObject)
        {
            bool result = false;
            TUserItem* UserItem;
            TPlayObject PlayObject;
            while (true)
            {
                if (BaseObject.m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)BaseObject.m_ItemList[0];
                if (!AddItemToBag(UserItem))
                {
                    break;
                }
                if (this is TPlayObject)
                {
                    PlayObject = ((this) as TPlayObject);
                    PlayObject.SendAddItem(UserItem);
                    result = true;
                }
                BaseObject.m_ItemList.RemoveAt(0);
            }
            return result;
        }

        // �������Ʒ
        public unsafe virtual void ScatterBagItems(TBaseObject ItemOfCreat)
        {
            int DropWide;
            TUserItem* UserItem;
            TStdItem* StdItem;
            bool boCanNotDrop;
            TMonDrop MonDrop = null;
            TUserItem* pu;
            List<string> DelList;
            bool boDropall;
            string sCheckItemName;
            byte nCode;
            const string sExceptionMsg = "{�쳣} TBaseObject::ScatterBagItems Code:";
            if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                // Ӣ�����󱬰���
                ((m_Master) as TPlayObject).m_boCanQueryBag = true; // ����װ����Ʒʱ,����ˢ�°���
                try
                {
                    DelList = null;
                    if (m_PEnvir.m_boNODROPITEM)// ��ͼ��ֹ��������Ʒ���˳�
                    {
                        return;
                    }
                    if (m_boAngryRing || m_boNoDropItem)// ������ָ
                    {
                        return;
                    }
                    boDropall = false;
                    DropWide = 2;
                    if (GameConfig.boHeroDieRedScatterBagAll && (PKLevel() >= 2))
                    {
                        boDropall = true;
                    }
                    nCode = 0;
                    // �Ǻ�����1/3 //����ȫ��
                    try
                    {
                        for (int I = m_ItemList.Count - 1; I >= 0; I--)
                        {
                            nCode = 1;
                            if (m_ItemList.Count <= 0)
                            {
                                break;
                            }
                            nCode = 2;
                            if (boDropall || (HUtil32.Random(GameConfig.nHeroDieScatterBagRate) == 0)) // 3
                            {
                                nCode = 3;
                                if (m_ItemList[I] != null)
                                {
                                    nCode = 4;
                                    pu = (TUserItem*)m_ItemList[I];
                                    sCheckItemName = UserEngine.GetStdItemName(pu->wIndex);
                                    if (PlugOfCheckCanItem(6, sCheckItemName, false, 0, 0)) // ��ֹ��Ʒ����(��������)
                                    {
                                        continue;
                                    }
                                    if (((THeroObject)(this)).CheckItemBindDieNoDrop((TUserItem*)m_ItemList[I]))// ����װ������������
                                    {
                                        continue;
                                    }
                                    nCode = 5;
                                    StdItem = UserEngine.GetStdItem(pu->wIndex);
                                    if (StdItem != null)
                                    {
                                        if ((StdItem->StdMode == 51) && (StdItem->Shape == 0) && (pu->Dura > 0) &&
                                            (pu->btValue[20] == 1))  // �Ǿ�����
                                        {
                                            ((m_Master) as TPlayObject).n_UsesItemTick = 0;// ʱ���ʼ
                                            pu->btValue[12] = 2;// ���ܾۼ��ı�ʶ
                                        }
                                    }
                                    nCode = 6;
                                    if (DropItemDown(((TUserItem*)(m_ItemList[I])), DropWide, true, true, ItemOfCreat, this))
                                    {
                                        if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            if (DelList == null)
                                            {
                                                DelList = new List<string>();
                                            }
                                            DelList.Add(UserEngine.GetStdItemName(pu->wIndex));
                                            //DelList.Add(UserEngine.GetStdItemName(pu.wIndex), ((pu.MakeIndex) as Object));
                                        }
                                        Marshal.FreeHGlobal((IntPtr)m_ItemList[I]);
                                        m_ItemList.RemoveAt(I);
                                    }
                                }
                            }
                        }
                        if (DelList != null)
                        {
                            SendMsg(this, Grobal2.RM_SENDDELITEMLIST, 0, HUtil32.ObjectToInt(DelList), 0, 0, "");
                        }
                    }
                    catch
                    {
                        M2Share.MainOutMessage(sExceptionMsg + nCode);
                    }
                }
                finally
                {
                    ((m_Master) as TPlayObject).m_boCanQueryBag = false;// ����װ����Ʒʱ,����ˢ�°���
                }
            }
            else
            {
                DropWide = 3;
                nCode = 7;
                try
                {
                    //M2Share.g_MonDropLimitLIst.__Lock();
                    try
                    {
                        nCode = 8;
                        if (m_ItemList != null)
                        {
                            for (int I = m_ItemList.Count - 1; I >= 0; I--)
                            {
                                if (m_ItemList.Count <= 0)
                                {
                                    break;
                                }
                                nCode = 9;
                                UserItem = (TUserItem*)m_ItemList[I];
                                if (UserItem != null)
                                {
                                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                    boCanNotDrop = false;
                                    if ((StdItem != null) && (M2Share.g_MonDropLimitLIst.Count > 0))
                                    {
                                        nCode = 10;
                                        for (int k = 0; k < M2Share.g_MonDropLimitLIst.Count; k++)
                                        {
                                            if ((HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen))
                                                .ToLower().CompareTo((M2Share.g_MonDropLimitLIst[k].sItemName).ToLower()) == 0)
                                            {
                                                nCode = 11;
                                                MonDrop = M2Share.g_MonDropLimitLIst[k];
                                                if (MonDrop != null)
                                                {
                                                    nCode = 12;
                                                    if (MonDrop.nDropCount < MonDrop.nCountLimit)
                                                    {
                                                        MonDrop.nDropCount++;
                                                        M2Share.g_MonDropLimitLIst[k] = MonDrop;
                                                    }
                                                    else
                                                    {
                                                        MonDrop.nNoDropCount++;
                                                        boCanNotDrop = true;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    if (boCanNotDrop)
                                    {
                                        continue;
                                    }
                                    nCode = 13;
                                    if (DropItemDown(UserItem, DropWide, true, true, ItemOfCreat, this))
                                    {
                                        nCode = 14;
                                        Marshal.FreeHGlobal((IntPtr)UserItem);
                                        m_ItemList.RemoveAt(I);
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        //M2Share.g_MonDropLimitLIst.UnLock();
                    }
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg + nCode + " " + m_sCharName);
                }
            }
        }

        /// <summary>
        /// ��ɢ���
        /// </summary>
        /// <param name="GoldOfCreat"></param>
        public void ScatterGolds(TBaseObject GoldOfCreat)
        {
            int I;
            int nGold;
            if (m_nGold > 0)
            {
                I = 0;
                while (true)
                {
                    if (m_nGold > GameConfig.nMonOneDropGoldCount)
                    {
                        nGold = GameConfig.nMonOneDropGoldCount;
                        m_nGold = m_nGold - GameConfig.nMonOneDropGoldCount;
                    }
                    else
                    {
                        nGold = m_nGold;
                        m_nGold = 0;
                    }
                    if (nGold > 0)
                    {
                        if (!DropGoldDown(nGold, true, GoldOfCreat, this))
                        {
                            m_nGold = m_nGold + nGold;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    I++;
                    if (I >= 17)
                    {
                        break;
                    }
                }
                GoldChanged();
            }
        }

        /// <summary>
        /// ��װ��
        /// </summary>
        /// <param name="BaseObject"></param>
        public unsafe virtual void DropUseItems(TBaseObject BaseObject)
        {
            int nRate = 0;
            TStdItem* StdItem;
            List<IntPtr> DropItemList = null;
            const string sExceptionMsg = "{�쳣} TBaseObject::DropUseItems";
            try
            {
                if (m_boNoDropUseItem)
                {
                    return;
                }
                if (m_PEnvir.m_boNODROPITEM) // ��ͼ��ֹ��������Ʒ���˳�
                {
                    return;
                }
                if (m_Master != null)
                {
                    if (m_btRaceServer != Grobal2.RC_HEROOBJECT) // ����������ιֻ���Ӣ�ۣ�װ������
                    {
                        if (m_btRaceServer != Grobal2.RC_PLAYMOSTER)
                        {
                            return;
                        }
                    }
                }
                for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                {
                    StdItem = UserEngine.GetStdItem(m_UseItems[I]->wIndex);
                    if (StdItem != null)
                    {
                        if (CheckItemValue(m_UseItems[I], 5))// ��ֹ����
                        {
                            continue;
                        }
                        if (PlugOfCheckCanItem(6, HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), false, 0, 0))// ��ֹ��Ʒ����(��������)
                        {
                            continue;
                        }
                        if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            if (((THeroObject)(this)).CheckItemBindDieNoDrop(m_UseItems[I]))
                            {
                                continue;
                            }
                        }

                        // ����װ������������
                        if (Convert.ToInt32(StdItem->Reserved & 8) != 0)
                        {
                            if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                if (DropItemList == null)
                                {
                                    DropItemList = new List<IntPtr>();
                                }
                                DropItemList.Add((IntPtr)m_UseItems[I]);
                                //DropItemList.Add("", ((m_UseItems[I]->MakeIndex) as Object));
                            }
                            if (StdItem->NeedIdentify == 1)
                            {
                                M2Share.AddGameDataLog("16" + "\09" + m_sMapName + "(" + (m_btRaceServer).ToString() + ")" + "\09" + (m_nCurrX).ToString() + "\09" +
                                    (m_nCurrY).ToString() + "\09" + m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09"
                                    + (m_UseItems[I]->MakeIndex).ToString() + "\09" + "(" +
                                    (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" +
                                    (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" +
                                    (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" +
                                    (HUtil32.HiWord(StdItem->MAC)).ToString() + ")" + (this.m_UseItems[I]->btValue[0]).ToString() + "/" + (this.m_UseItems[I]->btValue[1]).ToString() + "/" +
                                    (this.m_UseItems[I]->btValue[2]).ToString() + "/" + (this.m_UseItems[I]->btValue[3]).ToString() + "/" + (this.m_UseItems[I]->btValue[4]).ToString() + "/" +
                                    (this.m_UseItems[I]->btValue[5]).ToString() + "/" + (this.m_UseItems[I]->btValue[6]).ToString() + "/" + (this.m_UseItems[I]->btValue[7]).ToString() + "/" +
                                    (this.m_UseItems[I]->btValue[8]).ToString() + "/" + (this.m_UseItems[I]->btValue[14]).ToString() + "\09" + "1");
                            }
                            m_UseItems[I]->wIndex = 0;
                        }
                    }
                }
                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    // �����Ӣ��
                    if (PKLevel() > 2)
                    {
                        nRate = GameConfig.nHeroDieRedDropUseItemRate; // 15
                    }
                    else
                    {
                        nRate = GameConfig.nHeroDieDropUseItemRate; // 30
                    }
                }
                else if (m_btRaceServer == Grobal2.RC_PLAYMOSTER)   // ��������ι�,��װ���ļ���
                {
                    if (!((TPlayMonster)(this)).m_boDropUseItem) // ������ò���װ��
                    {
                        return;
                    }
                    nRate = ((TPlayMonster)(this)).m_nDieDropUseItemRate;// ��װ���ļ���
                }
                for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                {
                    if (HUtil32.Random(nRate) != 0)
                    {
                        continue;
                    }
                    if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                    {
                        if (M2Share.InDisableTakeOffList(m_UseItems[I]->wIndex))// ����Ƿ��ڽ�ֹȡ���б�,������б����򲻵�����Ʒ
                        {
                            continue;
                        }
                    }
                    StdItem = UserEngine.GetStdItem(m_UseItems[I]->wIndex);
                    if (m_UseItems[I]->btValue == null)
                    {
                        continue;
                    }
                    if (CheckItemValue(m_UseItems[I], 5)) // ��ֹ����
                    {
                        continue;
                    }

                    if (StdItem != null)
                    {
                        if (PlugOfCheckCanItem(6, HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen), false, 0, 0))// ��ֹ��Ʒ����(��������)
                        {
                            continue;
                        }
                    }
                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                    {

                        if (((THeroObject)(this)).CheckItemBindDieNoDrop(m_UseItems[I]))  // ����װ������������
                        {
                            continue;
                        }

                    }
                    if (DropItemDown(m_UseItems[I], 3, true, true, BaseObject, this))
                    {
                        if (StdItem != null)
                        {
                            if (Convert.ToInt32(StdItem->Reserved & 10) == 0)
                            {
                                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    if (DropItemList == null)
                                    {
                                        DropItemList = new List<IntPtr>();
                                    }
                                    DropItemList.Add((IntPtr)m_UseItems[I]);
                                }
                                m_UseItems[I]->wIndex = 0;
                            }
                        }
                    }
                }
                if (DropItemList != null)
                {
                    SendMsg(this, Grobal2.RM_SENDDELITEMLIST, 0, DropItemList.ToInt(), 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        /// <summary>
        /// �����ص���Ʒ
        /// </summary>
        private unsafe void DieDropItems()
        {
            TStdItem* StdItem;
            TUserItem* UserItem;
            string ItemName;
            List<IntPtr> DelList = null;
            try
            {
                if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                    {
                        StdItem = UserEngine.GetStdItem(m_UseItems[I]->wIndex);
                        if (StdItem != null)
                        {
                            ItemName = HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen);
                            if (PlugOfCheckCanItem(6, ItemName, false, 0, 0))// ��ֹ��Ʒ����(��������)
                            {
                                continue;
                            }
                            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                            {
                                if (((this) as TPlayObject).CheckItemBindDieNoDrop(m_UseItems[I]))// ����װ������������
                                {
                                    continue;
                                }
                            }
                            else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                if (((THeroObject)(this)).CheckItemBindDieNoDrop(m_UseItems[I])) // Ӣ��װ������������
                                {
                                    continue;
                                }
                            }
                            if (PlugOfCheckCanItem(10, ItemName, false, 0, 0))
                            {
                                if (DropItemDown(m_UseItems[I], 3, true, true, null, this))// ��ֹ��Ʒ����(�����ر�)
                                {
                                    if (DelList == null)
                                    {
                                        DelList = new List<IntPtr>();
                                    }
                                    DelList.Add((IntPtr)m_UseItems[I]);
                                    //DelList.Add(UserEngine.GetStdItemName(m_UseItems[I]->wIndex), ((m_UseItems[I]->MakeIndex) as Object));
                                    m_UseItems[I]->wIndex = 0;
                                }
                            }
                        }
                    }
                    for (int I = m_ItemList.Count - 1; I >= 0; I--)// ������Ϊ��
                    {
                        if (m_ItemList.Count <= 0)
                        {
                            break;
                        }
                        UserItem = (TUserItem*)m_ItemList[I];
                        if (UserItem != null)
                        {
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            if (StdItem != null)
                            {
                                ItemName = HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen);
                                if (PlugOfCheckCanItem(6, ItemName, false, 0, 0))  // ��ֹ��Ʒ����(��������)
                                {
                                    continue;
                                }
                                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                {
                                    if (((this) as TPlayObject).CheckItemBindDieNoDrop(UserItem)) // ����װ������������
                                    {
                                        continue;
                                    }
                                }
                                else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                {
                                    if (((THeroObject)(this)).CheckItemBindDieNoDrop(UserItem)) // Ӣ��װ������������
                                    {
                                        continue;
                                    }
                                }
                                if (PlugOfCheckCanItem(10, ItemName, false, 0, 0))  // ��ֹ��Ʒ����(�����ر�)
                                {
                                    if (DropItemDown(UserItem, 3, true, true, null, this))
                                    {
                                        if (DelList == null)
                                        {
                                            DelList = new List<IntPtr>();
                                        }
                                        DelList.Add((IntPtr)m_UseItems[I]);
                                        //DelList.Add(UserEngine.GetStdItemName(UserItem->wIndex), ((UserItem->MakeIndex) as Object));
                                        Dispose(m_ItemList[I]);
                                        m_ItemList.RemoveAt(I);
                                    }
                                }
                            }
                        }
                    }
                }
                if (DelList != null)
                {
                    SendMsg(this, Grobal2.RM_SENDDELITEMLIST, 0, DelList.ToInt(), 0, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} procedure TBaseObject.DieDropItems");
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual void Die()
        {
            bool boPK;
            bool guildwarkill;
            string tStr;
            UInt32 tExp;
            int I;
            TPlayObject GroupHuman;
            TMerchant QuestNPC;
            bool tCheck;
            bool boCheck;
            TBaseObject AttackBaseObject = null;
            TBaseObject BaseObject;
            THeroObject HeroObject;
            TUserCastle Castle;
            int n10;
            byte nCheckCode = 0;
            const string sExceptionMsg1 = "{�쳣} TBaseObject::Die 1 CheckCode:";
            const string sExceptionMsg2 = "{�쳣} TBaseObject::Die 2 CheckCode:";
            const string sExceptionMsg3 = "{�쳣} TBaseObject::Die 3 CheckCode:";
            try
            {
                if (m_boSuperMan)
                {
                    return;
                }
                if (m_boSupermanItem)
                {
                    return;
                }
                m_boDeath = true;
                m_dwDeathTick = HUtil32.GetTickCount();
                nCheckCode = 0;
                if ((m_Master != null) && (m_btRaceServer != Grobal2.RC_HEROOBJECT))// ��Ӣ����
                {
                    m_ExpHitter = null;
                    m_LastHiter = null;
                }
                if ((m_Master != null) && (m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_LastHiter != null))// ɱ�Լ�Ӣ��
                {
                    if (m_LastHiter == m_Master)
                    {
                        m_ExpHitter = null;
                        m_LastHiter = null;
                    }
                }
                m_nIncSpell = 0;
                m_nIncHealth = 0;
                m_nIncHealing = 0;
                if ((m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (m_LastHiter != null))
                {
                    nCheckCode = 2;
                    if (GameConfig.boMonSayMsg)
                    {
                        MonsterSayMsg(m_LastHiter, TMonStatus.s_Die);
                    }
                    if ((m_ExpHitter != null))
                    {
                        if (m_ExpHitter.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            nCheckCode = 3;
                            tExp = m_ExpHitter.CalcGetExp(m_Abil.Level, m_dwFightExp);
                            if (!GameConfig.boVentureServer)
                            {
                                nCheckCode = 4;
                                if (m_boIsNGMonster)
                                {
                                    ((m_ExpHitter) as TPlayObject).GainExp(tExp, 1);
                                }
                                else
                                {
                                    ((m_ExpHitter) as TPlayObject).GainExp(tExp, 0);
                                }
                            }
                            nCheckCode = 5;
                            // �Ƿ�ִ������ű�
                            if ((m_PEnvir.IsCheapStuff()) && (m_ExpHitter != null))
                            {
                                boCheck = false;
                                if ((((m_ExpHitter) as TPlayObject).m_GroupOwner != null) && (((m_ExpHitter) as TPlayObject).m_GroupOwner.m_GroupMembers != null) &&
                                    (((m_ExpHitter) as TPlayObject).m_GroupOwner.m_GroupMembers.Count > 0))
                                {
                                    nCheckCode = 6;
                                    for (I = 0; I < ((m_ExpHitter) as TPlayObject).m_GroupOwner.m_GroupMembers.Count; I++)
                                    {
                                        GroupHuman = ((m_ExpHitter) as TPlayObject).m_GroupOwner.m_GroupMembers[I];
                                        if (GroupHuman != null)
                                        {
                                            if (!GroupHuman.m_boDeath && (m_ExpHitter == GroupHuman))
                                            {
                                                nCheckCode = 62;
                                                boCheck = true;
                                                if (m_PEnvir != null)
                                                {
                                                    nCheckCode = 63;
                                                    QuestNPC = ((TMerchant)(m_PEnvir.GetQuestNPC(GroupHuman, m_sCharName, "", false)));
                                                    nCheckCode = 64;
                                                    if ((QuestNPC != null) && (GroupHuman != null))
                                                    {
                                                        nCheckCode = 61;
                                                        if (!GroupHuman.m_boGhost)
                                                        {
                                                            nCheckCode = 70;
                                                            if (GroupHuman.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                            {
                                                                QuestNPC.Click(GroupHuman);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if (!GroupHuman.m_boDeath && (m_ExpHitter.m_PEnvir == GroupHuman.m_PEnvir) && (Math.Abs(m_ExpHitter.m_nCurrX - GroupHuman.m_nCurrX) <= 12)
                                                && (Math.Abs(m_ExpHitter.m_nCurrX - GroupHuman.m_nCurrX) <= 12) && (m_ExpHitter != GroupHuman))
                                            {
                                                tCheck = true;
                                                nCheckCode = 66;
                                                QuestNPC = ((TMerchant)(m_PEnvir.GetQuestNPC(GroupHuman, m_sCharName, "", tCheck)));
                                                if ((QuestNPC != null) && (GroupHuman != null))
                                                {
                                                    if (GroupHuman == m_ExpHitter)
                                                    {
                                                        boCheck = true;
                                                    }
                                                    nCheckCode = 67;
                                                    if (!GroupHuman.m_boGhost)
                                                    {
                                                        nCheckCode = 68;
                                                        if (GroupHuman.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                        {
                                                            QuestNPC.Click(GroupHuman);
                                                        }
                                                        nCheckCode = 69;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (!boCheck)
                                {
                                    nCheckCode = 7;
                                    if ((m_ExpHitter != null) && (m_PEnvir != null))
                                    {
                                        nCheckCode = 71;
                                        QuestNPC = ((TMerchant)(m_PEnvir.GetQuestNPC(m_ExpHitter, m_sCharName, "", false)));
                                        if ((QuestNPC != null) && (m_ExpHitter != null))
                                        {
                                            nCheckCode = 72;
                                            if (!m_ExpHitter.m_boGhost)
                                            {
                                                nCheckCode = 74;
                                                if (m_ExpHitter.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                {
                                                    QuestNPC.Click(m_ExpHitter as TPlayObject);
                                                }
                                                nCheckCode = 75;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (m_ExpHitter.m_Master != null)
                            {
                                nCheckCode = 8;
                                if (m_ExpHitter.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    // Ӣ�۱���ɱ����,Ӣ�ۻ�ȡ���� 
                                    m_ExpHitter.GainSlaveExp(m_Abil.Level);// ��������
                                    tExp = m_ExpHitter.CalcGetExp(m_Abil.Level, m_dwFightExp);
                                    if (!GameConfig.boVentureServer)
                                    {
                                        if (m_ExpHitter.m_Master != null)
                                        {
                                            if (m_ExpHitter.m_Master.m_Master != null)
                                            {
                                                nCheckCode = 95;
                                                if (m_boIsNGMonster)
                                                {
                                                    ((m_ExpHitter.m_Master.m_Master) as TPlayObject).GainExp(tExp, 1);
                                                }
                                                else
                                                {
                                                    ((m_ExpHitter.m_Master.m_Master) as TPlayObject).GainExp(tExp, 0);
                                                }
                                                nCheckCode = 97;
                                                if (m_PEnvir != null)
                                                {
                                                    if (m_PEnvir.IsCheapStuff())  // �Ƿ�ִ������ű�
                                                    {
                                                        nCheckCode = 99;
                                                        QuestNPC = ((TMerchant)(m_PEnvir.GetQuestNPC(m_ExpHitter.m_Master.m_Master, m_sCharName, "", false)));
                                                        if ((QuestNPC != null) && (m_ExpHitter != null))
                                                        {
                                                            nCheckCode = 98;
                                                            if ((m_ExpHitter.m_Master != null))
                                                            {
                                                                nCheckCode = 100;
                                                                if ((m_ExpHitter.m_Master.m_Master != null))
                                                                {
                                                                    nCheckCode = 201;
                                                                    if (!m_ExpHitter.m_Master.m_Master.m_boGhost)
                                                                    {
                                                                        nCheckCode = 202;
                                                                        if (m_ExpHitter.m_Master.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                                        {
                                                                            QuestNPC.Click(((m_ExpHitter.m_Master.m_Master) as TPlayObject));
                                                                        }
                                                                        nCheckCode = 203;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            nCheckCode = 202;
                                            ((THeroObject)(m_ExpHitter.m_Master)).GainExp(tExp);
                                            nCheckCode = 203;
                                            if (m_boIsNGMonster)
                                            {
                                                ((THeroObject)(m_ExpHitter.m_Master)).GetNGExp(tExp, 0); // ȡ����������
                                            }
                                        }
                                    }
                                }
                                else if (m_ExpHitter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) // ���ﱦ��ɱ����,Ӣ�ۻ�ȡ���� 
                                {
                                    nCheckCode = 10;
                                    m_ExpHitter.GainSlaveExp(m_Abil.Level);// ��������
                                    nCheckCode = 101;
                                    tExp = m_ExpHitter.CalcGetExp(m_Abil.Level, m_dwFightExp);
                                    if (!GameConfig.boVentureServer)
                                    {
                                        if (m_ExpHitter.m_Master != null)
                                        {
                                            if (m_boIsNGMonster)
                                            {
                                                ((m_ExpHitter.m_Master) as TPlayObject).GainExp(tExp, 1);
                                            }
                                            else
                                            {
                                                ((m_ExpHitter.m_Master) as TPlayObject).GainExp(tExp, 0);
                                            }
                                            nCheckCode = 103;
                                            if (m_PEnvir != null)
                                            {
                                                if (m_PEnvir.IsCheapStuff()) // �Ƿ�ִ������ű�
                                                {
                                                    nCheckCode = 104;
                                                    QuestNPC = ((TMerchant)(m_PEnvir.GetQuestNPC(m_ExpHitter.m_Master, m_sCharName, "", false)));
                                                    if ((QuestNPC != null) && (m_ExpHitter != null))
                                                    {
                                                        nCheckCode = 106;
                                                        if (m_ExpHitter.m_Master != null)
                                                        {
                                                            nCheckCode = 108;
                                                            if (!m_ExpHitter.m_Master.m_boGhost)
                                                            {
                                                                nCheckCode = 109;
                                                                if (m_ExpHitter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                                {
                                                                    QuestNPC.Click(((m_ExpHitter.m_Master) as TPlayObject));
                                                                }
                                                                nCheckCode = 110;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (m_ExpHitter.m_btRaceServer == Grobal2.RC_HEROOBJECT)// Ӣ�ۻ�ȡ����
                                {
                                    nCheckCode = 11;
                                    tExp = m_ExpHitter.CalcGetExp(m_Abil.Level, m_dwFightExp);
                                    nCheckCode = 117;
                                    if (!GameConfig.boVentureServer)
                                    {
                                        if (m_ExpHitter.m_Master != null)
                                        {
                                            nCheckCode = 111;
                                            if (m_boIsNGMonster)
                                            {
                                                ((m_ExpHitter.m_Master) as TPlayObject).GainExp(tExp, 1);
                                            }
                                            else
                                            {
                                                ((m_ExpHitter.m_Master) as TPlayObject).GainExp(tExp, 0);
                                            }
                                            nCheckCode = 112;
                                            if (m_PEnvir != null)
                                            {
                                                if (m_PEnvir.IsCheapStuff())  // �Ƿ�ִ������ű�
                                                {
                                                    nCheckCode = 114;
                                                    QuestNPC = ((TMerchant)(m_PEnvir.GetQuestNPC(m_ExpHitter.m_Master, m_sCharName, "", false)));
                                                    if ((QuestNPC != null) && (m_ExpHitter != null))
                                                    {
                                                        nCheckCode = 115;
                                                        if ((m_ExpHitter.m_Master != null))
                                                        {
                                                            nCheckCode = 116;
                                                            if (!m_ExpHitter.m_Master.m_boGhost)
                                                            {
                                                                nCheckCode = 118;
                                                                if (m_ExpHitter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                                {
                                                                    QuestNPC.Click(((m_ExpHitter.m_Master) as TPlayObject));
                                                                }
                                                                nCheckCode = 119;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    nCheckCode = 12;
                                    m_ExpHitter.GainSlaveExp(m_Abil.Level);// ��������
                                    nCheckCode = 121;
                                    tExp = m_ExpHitter.m_Master.CalcGetExp(m_Abil.Level, m_dwFightExp);
                                    nCheckCode = 122;
                                    if (!GameConfig.boVentureServer)
                                    {
                                        if (m_ExpHitter.m_Master != null)
                                        {
                                            nCheckCode = 123;
                                            if (m_boIsNGMonster)
                                            {
                                                ((m_ExpHitter.m_Master) as TPlayObject).GainExp(tExp, 1);
                                            }
                                            else
                                            {
                                                ((m_ExpHitter.m_Master) as TPlayObject).GainExp(tExp, 0);
                                            }
                                            nCheckCode = 124;
                                            if (m_PEnvir != null)
                                            {
                                                nCheckCode = 125;
                                                if (m_PEnvir.IsCheapStuff())// �Ƿ�ִ������ű�
                                                {
                                                    nCheckCode = 126;
                                                    QuestNPC = ((TMerchant)(m_PEnvir.GetQuestNPC(m_ExpHitter.m_Master, m_sCharName, "", false)));
                                                    nCheckCode = 127;
                                                    if ((QuestNPC != null) && (m_ExpHitter != null))
                                                    {
                                                        nCheckCode = 128;
                                                        if ((m_ExpHitter.m_Master != null))
                                                        {
                                                            nCheckCode = 129;
                                                            if (!m_ExpHitter.m_Master.m_boGhost)
                                                            {
                                                                nCheckCode = 130;
                                                                if (m_ExpHitter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                                {
                                                                    QuestNPC.Click(((m_ExpHitter.m_Master) as TPlayObject));
                                                                }
                                                                nCheckCode = 131;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (m_LastHiter != null)
                        {
                            if (m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                nCheckCode = 13;
                                tExp = m_LastHiter.CalcGetExp(m_Abil.Level, m_dwFightExp);
                                if (!GameConfig.boVentureServer)
                                {
                                    if (m_boIsNGMonster)
                                    {
                                        ((m_LastHiter) as TPlayObject).GainExp(tExp, 1);
                                    }
                                    else
                                    {
                                        ((m_LastHiter) as TPlayObject).GainExp(tExp, 0);
                                    }
                                }
                            }
                            else if ((m_LastHiter.m_Master != null) && (m_LastHiter.m_btRaceServer == 135))
                            {
                                // ����ħ�����֣���ʱ���þ���
                                if (m_LastHiter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    nCheckCode = 131;
                                    tExp = m_LastHiter.CalcGetExp(m_Abil.Level, m_dwFightExp);
                                    if (!GameConfig.boVentureServer)
                                    {
                                        if (m_boIsNGMonster)
                                        {
                                            ((m_LastHiter.m_Master) as TPlayObject).GainExp(tExp, 1);
                                        }
                                        else
                                        {
                                            ((m_LastHiter.m_Master) as TPlayObject).GainExp(tExp, 0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if ((GameConfig.boMonSayMsg) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_LastHiter != null))
                {
                    nCheckCode = 14;
                    m_LastHiter.MonsterSayMsg(this, TMonStatus.s_KillHuman);
                }
                nCheckCode = 151;
                // ����ɱ���ִ���    ħ����,135����ɱ�����˼���,
                if ((m_LastHiter != null))
                {
                    nCheckCode = 152;
                    if ((m_LastHiter.m_Master != null))
                    {
                        nCheckCode = 153;
                        if ((m_LastHiter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_LastHiter.m_btRaceServer == 135))
                        {
                            //��������
                            nCheckCode = 154;
                            ((m_LastHiter.m_Master) as TPlayObject).KillMissionMob();
                        }
                    }
                }
                nCheckCode = 16;// ִ��ɱ�ִ���
                if ((m_LastHiter != null))
                {
                    nCheckCode = 161;
                    if ((m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        ((m_LastHiter) as TPlayObject).KillMonsterFunc(this);
                    }
                    else if ((m_LastHiter.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_LastHiter.m_Master != null))
                    {
                        //Ӣ��ɱ��,����
                        ((m_LastHiter.m_Master) as TPlayObject).KillMonsterFunc(this);
                    }
                    else if ((m_LastHiter.m_Master != null))
                    {
                        nCheckCode = 162;
                        if ((m_LastHiter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                        {
                            nCheckCode = 163;
                            ((m_LastHiter.m_Master) as TPlayObject).KillMonsterFunc(this);
                        }
                        else if ((m_LastHiter.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                        {
                            nCheckCode = 164;
                            if (m_LastHiter.m_Master.m_Master != null)
                            {
                                ((m_LastHiter.m_Master.m_Master) as TPlayObject).KillMonsterFunc(this);
                            }
                        }
                    }
                }
                nCheckCode = 17;
                if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                {
                    m_Master = null;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg1 + nCheckCode + "  Name:" + m_sCharName);// ������ʾ����
            }
            try
            {
                nCheckCode = 183;// ִ��ɱ�˺���������
                if ((m_LastHiter != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    ((this) as TPlayObject).DieGotoLable();
                }
                nCheckCode = 181;
                boPK = false;
                if (m_PEnvir != null)
                {
                    nCheckCode = 182;
                    if ((!GameConfig.boVentureServer) && (!m_PEnvir.m_boFightZone) && (!m_PEnvir.m_boFight3Zone) && (!m_PEnvir.m_boFight2Zone) && (!m_PEnvir.m_boFight4Zone))
                    {
                        nCheckCode = 191;
                        // ����ɱӢ��
                        if (((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_LastHiter != null) && (PKLevel() < 2))
                        {
                            // Ӣ�۳��л�ս��
                            nCheckCode = 192;
                            if ((m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT) ||
                                (m_LastHiter.m_btRaceServer == Grobal2.RC_NPC) ||
                                ((m_LastHiter.m_btRaceServer == Grobal2.RC_HEROOBJECT) && !m_boInFreePKArea))// ����NPCɱ������
                            {
                                boPK = true;
                            }
                            nCheckCode = 193;
                            if ((m_LastHiter.m_Master != null) && (m_LastHiter.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                if ((m_LastHiter.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                {
                                    nCheckCode = 20;
                                    m_LastHiter = m_LastHiter.m_Master;
                                    boPK = true;
                                }
                            }
                        }
                    }
                }
                nCheckCode = 21;
                if ((m_LastHiter != null) && boPK) // PK������
                {
                    if (m_LastHiter.m_PEnvir != null)// ����
                    {
                        if (m_LastHiter.m_PEnvir.m_boFIGHTPK)
                        {
                            m_LastHiter.m_boPKFlag = true;
                        }
                    }
                }
                nCheckCode = 210;
                if (m_PEnvir.m_boFight4Zone && (m_btRaceServer == Grobal2.RC_PLAYOBJECT)) // ��ս��ͼ
                {
                    nCheckCode = 211;
                    if (((this) as TPlayObject).m_boChallengeing && (((this) as TPlayObject).m_ChallengeCreat != null))
                    {
                        if (((this) as TPlayObject).m_ChallengeCreat.m_PEnvir.m_boFight4Zone)
                        {
                            ((this) as TPlayObject).m_ChallengeCreat.MapRandomMove(((this) as TPlayObject).m_ChallengeCreat.m_sLastMapName, 0);
                        }
                        SysMsg(GameMsgDef.g_sChallengeLoseMsg, TMsgColor.c_Blue, TMsgType.t_Hint);// '����ս����!'
                        nCheckCode = 212;
                        ((this) as TPlayObject).m_ChallengeCreat.SysMsg(GameMsgDef.g_sChallengeWinMsg, TMsgColor.c_Blue, TMsgType.t_Hint);
                        nCheckCode = 213;
                        ((this) as TPlayObject).m_ChallengeCreat.WinGetChallengeItems();// ȡʤ����ս���õ���ս�ĵ�Ѻ��Ʒ(������ս��)
                    }
                }
                nCheckCode = 22;
                if (boPK && (m_LastHiter != null))
                {
                    guildwarkill = false;
                    if ((m_MyGuild != null) && (m_LastHiter.m_MyGuild != null))
                    {
                        if (GetGuildRelation(this, m_LastHiter) == 2)
                        {
                            guildwarkill = true;
                        }
                    }
                    nCheckCode = 23;
                    Castle = M2Share.g_CastleManager.InCastleWarArea(this);
                    if (((Castle != null) && Castle.m_boUnderWar) || m_boInFreePKArea)
                    {
                        guildwarkill = true;// ���ǻ��л�ս
                    }
                    if ((m_LastHiter.m_btRaceServer == Grobal2.RC_HEROOBJECT) && !guildwarkill) // Ӣ�۹��ǻ��л�սɱ�˲���PKֵ
                    {
                        if ((m_LastHiter.m_Master != null))
                        {
                            if (m_LastHiter.m_Master.m_boInFreePKArea)
                            {
                                guildwarkill = true;
                            }
                            if ((m_MyGuild != null) && (m_LastHiter.m_Master.m_MyGuild != null) && !guildwarkill)// ��������Ƿ������л�ս
                            {
                                if (GetGuildRelation(this, m_LastHiter.m_Master) == 2)
                                {
                                    guildwarkill = true;
                                }
                            }
                        }
                    }
                    if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && !guildwarkill)
                    {
                        if ((m_Master != null))
                        {
                            if (m_Master.m_boInFreePKArea)
                            {
                                guildwarkill = true;
                            }
                            if ((m_Master.m_MyGuild != null) && (m_LastHiter.m_MyGuild != null) && !guildwarkill)// ��������Ƿ������л�ս
                            {
                                if (GetGuildRelation(m_Master, m_LastHiter) == 2)
                                {
                                    guildwarkill = true;
                                }
                            }
                            if ((m_LastHiter.m_Master != null))
                            {
                                // �л�ս,Ӣ��ɱӢ�۲���PKֵ
                                if ((m_Master.m_MyGuild != null) && (m_LastHiter.m_Master.m_MyGuild != null) && !guildwarkill)
                                {
                                    if (GetGuildRelation(m_Master, m_LastHiter.m_Master) == 2)
                                    {
                                        guildwarkill = true;
                                    }
                                }
                            }
                        }
                    }
                    // =================================================================
                    if (!guildwarkill && (!m_PEnvir.m_boFight4Zone))
                    {
                        nCheckCode = 24;
                        if ((GameConfig.boKillHumanWinLevel || GameConfig.boKillHumanWinExp || m_PEnvir.m_boPKWINLEVEL || m_PEnvir.m_boFIGHTPK
                            || m_PEnvir.m_boPKWINEXP) && (m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                        {
                            ((this) as TPlayObject).PKDie(((m_LastHiter) as TPlayObject));
                        }
                        else
                        {
                            if (!m_LastHiter.IsGoodKilling(this))
                            {
                                nCheckCode = 25;// 100
                                m_LastHiter.IncPkPoint(GameConfig.nKillHumanAddPKPoint);// PKֵ����
                                if (m_LastHiter.m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                {
                                    nCheckCode = 251;
                                    m_LastHiter.SysMsg(GameMsgDef.g_sYouMurderedMsg, TMsgColor.c_Red, TMsgType.t_Hint);// '�㷸��ıɱ�����'
                                    m_LastHiter.AddBodyLuck(-GameConfig.nKillHumanDecLuckPoint);// 500
                                    if (PKLevel() < 1)
                                    {
                                        if (HUtil32.Random(GameConfig.nKillHumanWeaponUnlockRate) == 0)
                                        {
                                            m_LastHiter.MakeWeaponUnlock();
                                        }
                                    }
                                }
                                else
                                {
                                    nCheckCode = 252;
                                    if ((m_LastHiter.m_Master != null))
                                    {
                                        nCheckCode = 253;
                                        m_LastHiter.m_Master.SysMsg(GameMsgDef.g_sYouMurderedMsg, TMsgColor.c_Red, TMsgType.t_Hint);// Ӣ��ɱ��,��ʾ����ɱ��
                                        m_LastHiter.m_Master.AddBodyLuck(-GameConfig.nKillHumanDecLuckPoint); // 500
                                        if (PKLevel() < 1)
                                        {
                                            if (HUtil32.Random(GameConfig.nKillHumanWeaponUnlockRate) == 0) //5
                                            {
                                                m_LastHiter.m_Master.MakeWeaponUnlock();
                                            }
                                        }
                                    }
                                }
                                nCheckCode = 254;
                                if (GameConfig.boUnKnowHum && m_LastHiter.IsUsesZhuLi())
                                {
                                    // ���϶���,����ʾ�˵���������
                                    SysMsg(string.Format(GameMsgDef.g_sYouKilledByMsg, "������"), TMsgColor.c_Red, TMsgType.t_Hint);
                                }
                                else
                                {
                                    nCheckCode = 255;
                                    if (m_LastHiter.m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                    {
                                        SysMsg(string.Format(GameMsgDef.g_sYouKilledByMsg, m_LastHiter.m_sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
                                    }
                                    else
                                    {
                                        // Ӣ��ɱ��,��ʾ����ɱ��
                                        nCheckCode = 249;
                                        if ((m_LastHiter.m_Master != null))
                                        {
                                            nCheckCode = 248;
                                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                            {
                                                SysMsg(string.Format(GameMsgDef.g_sYouKilledByMsg, m_LastHiter.m_Master.m_sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
                                            }
                                            else
                                            {
                                                ((THeroObject)(this)).SysMsg(string.Format("(Ӣ��)" + GameMsgDef.g_sYouKilledByMsg, m_LastHiter.m_Master.m_sCharName), TMsgColor.c_Red, TMsgType.t_Hint);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // '[���ܵ��������򱣻���]'
                                m_LastHiter.SysMsg(GameMsgDef.g_sYouProtectedByLawOfDefense, TMsgColor.c_Green, TMsgType.t_Hint);
                            }
                        }
                        nCheckCode = 26;
                        // ��鹥�����Ƿ������ž����ȼ�װ��
                        if (m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            if (m_LastHiter.m_dwPKDieLostExp > 0)
                            {
                                if (m_Abil.Exp >= m_LastHiter.m_dwPKDieLostExp)
                                {
                                    m_Abil.Exp -= m_LastHiter.m_dwPKDieLostExp;
                                }
                                else
                                {
                                    m_Abil.Exp = 0;
                                }
                            }
                            nCheckCode = 27;
                            if (m_LastHiter.m_nPKDieLostLevel > 0)
                            {
                                if (m_Abil.Level >= m_LastHiter.m_nPKDieLostLevel)
                                {
                                    m_Abil.Level -= (ushort)m_LastHiter.m_nPKDieLostLevel;
                                }
                                else
                                {
                                    m_Abil.Level = 0;
                                }
                            }
                        }
                    }
                    // =================================================================
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg2 + nCheckCode);
            }
            try
            {
                nCheckCode = 28;
                DieDropItems();// �����ص���Ʒ
                if ((!m_PEnvir.m_boFightZone) && (!m_PEnvir.m_boFight3Zone) && !m_boAnimal)
                {
                    nCheckCode = 39;
                    if ((m_ExpHitter != null))
                    {
                        AttackBaseObject = m_ExpHitter;// ��λ��
                        if ((m_ExpHitter.m_Master != null))
                        {
                            AttackBaseObject = m_ExpHitter.m_Master;
                            if ((m_ExpHitter.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_ExpHitter.m_Master.m_Master != null))
                            {
                                AttackBaseObject = m_ExpHitter.m_Master.m_Master;//Ӣ�۱����򵽵���Ʒ,Ӣ�����˿��Լ�
                            }
                        }
                    }
                    nCheckCode = 29;
                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT) // Ӣ������
                    {
                        if (!m_boNoItem)//���Ӵ��У��������� m_boNoItem ����������������Ʒ
                        {
                            nCheckCode = 47;
                            if (AttackBaseObject != null)// Ӣ�۴���Ӣ��Ҳ�ܵ�װ��
                            {
                                nCheckCode = 48;
                                if ((GameConfig.boHeroKillByHumanDropUseItem &&
                                    ((AttackBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) ||
                                    (AttackBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))) ||
                                    (GameConfig.boHeroKillByMonstDropUseItem &&
                                    (AttackBaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT)))
                                {
                                    DropUseItems(null);
                                }
                            }
                            else
                            {
                                nCheckCode = 49;
                                DropUseItems(null);
                            }
                            if (GameConfig.boHeroDieScatterBag)
                            {
                                ScatterBagItems(null);
                            }
                        }
                    }
                    else if (m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                    {
                        nCheckCode = 30;
                        if (AttackBaseObject != null)
                        {
                            DropUseItems(AttackBaseObject); // ��װ��
                        }
                        nCheckCode = 31;
                        if (m_btRaceServer == 136)
                        {
                            // ħ����
                            nCheckCode = 32;
                            if ((m_Master == null) && !m_boNoItem)
                            {
                                if (m_LastHiter.m_Master != null)
                                {
                                    ScatterBagItems(m_LastHiter.m_Master);// ����Ʒ
                                }
                                else
                                {
                                    ScatterBagItems(m_LastHiter);
                                }
                            }
                        }
                        else
                        {
                            nCheckCode = 33;
                            if ((m_Master == null) && !m_boNoItem)
                            {
                                nCheckCode = 47;
                                if (AttackBaseObject != null)
                                {
                                    ScatterBagItems(AttackBaseObject);// ����Ʒ
                                }
                            }
                        }
                        nCheckCode = 34;
                        if ((m_btRaceServer >= Grobal2.RC_ANIMAL) && (m_Master == null) && !m_boNoItem && (AttackBaseObject != null))
                        {
                            nCheckCode = 39;
                            if ((AttackBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (GameConfig.boDropGoldToPlayBag))
                            {
                                nCheckCode = 40;
                                if (((AttackBaseObject) as TPlayObject).IncGold(m_nGold))
                                {
                                    nCheckCode = 41;
                                    ((AttackBaseObject) as TPlayObject).GoldChanged();
                                }
                                else
                                {
                                    nCheckCode = 42;
                                    ScatterGolds(AttackBaseObject);
                                }
                            }
                            else
                            {
                                // ����Ǳ����򵽵Ľ��,ֱ�ӽ������˰���
                                nCheckCode = 43;
                                if ((AttackBaseObject.m_Master != null) && (AttackBaseObject.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (GameConfig.boDropGoldToPlayBag))
                                {
                                    nCheckCode = 44;
                                    if (((AttackBaseObject.m_Master) as TPlayObject).IncGold(m_nGold))
                                    {
                                        nCheckCode = 45;
                                        ((AttackBaseObject.m_Master) as TPlayObject).GoldChanged();
                                    }
                                    else
                                    {
                                        nCheckCode = 46;
                                        ScatterGolds(AttackBaseObject);// ����ҷ�ɢ������
                                    }
                                }
                                else
                                {
                                    ScatterGolds(AttackBaseObject);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!m_boNoItem) //���Ӵ��У��������� m_boNoItem ����������������Ʒ
                        {
                            nCheckCode = 35;
                            if (AttackBaseObject != null)
                            {
                                if ((GameConfig.boKillByHumanDropUseItem && (AttackBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                    || (GameConfig.boKillByMonstDropUseItem && (AttackBaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT)))
                                {
                                    DropUseItems(null);
                                }
                            }
                            else
                            {
                                DropUseItems(null);
                            }
                            if (GameConfig.boDieScatterBag)
                            {
                                ScatterBagItems(null);
                            }
                            if (GameConfig.boDieDropGold)
                            {
                                ScatterGolds(null);
                            }
                        }
                        AddBodyLuck(-(50 - (50 - m_Abil.Level * 5)));
                    }
                }
                nCheckCode = 36;
                if (m_PEnvir.m_boFight3Zone)// �л�ս����ͼ
                {
                    m_nFightZoneDieCount++;// ���л�ս����ͼ����������
                    if (m_MyGuild != null)
                    {
                        m_MyGuild.TeamFightWhoDead(m_sCharName);
                    }
                    if ((m_LastHiter != null))
                    {
                        if (m_LastHiter.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            // �л�սɱ������Ӣ���ҳ϶�
                            ((THeroObject)(m_LastHiter)).m_nLoyal = ((THeroObject)(m_LastHiter)).m_nLoyal + GameConfig.nGuildIncLoyal;
                            if (((THeroObject)(m_LastHiter)).m_nLoyal > 10000)
                            {
                                ((THeroObject)(m_LastHiter)).m_nLoyal = 10000;
                            }
                        }
                        if ((m_LastHiter.m_MyGuild != null) && (m_MyGuild != null))
                        {
                            m_LastHiter.m_MyGuild.TeamFightWhoWinPoint(m_LastHiter.m_sCharName, 100);
                            tStr = m_LastHiter.m_MyGuild.sGuildName + ":" + m_LastHiter.m_MyGuild.nContestPoint + "  " + m_MyGuild.sGuildName + ":" + m_MyGuild.nContestPoint;
                            UserEngine.CryCry(Grobal2.RM_CRY, m_PEnvir, m_nCurrX, m_nCurrY, 1000, GameConfig.btCryMsgFColor, GameConfig.btCryMsgBColor, "- " + tStr);
                        }
                    }
                }
                nCheckCode = 246;
                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    m_btLastOutStatus = 1;  // ����Ӣ���˳�״̬ 1Ϊ�����˳�
                }
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    m_btLastOutStatus = 1;//������������˳�״̬ 1Ϊ�����˳�
                    nCheckCode = 247;
                    if (((this) as TPlayObject).m_GroupOwner != null)
                    {
                        ((this) as TPlayObject).m_GroupOwner.DelMember(((this) as TPlayObject)); // ���������������飬�Է�ֹ���ˢ����
                    }
                    nCheckCode = 245;
                    if (m_LastHiter != null)
                    {
                        if (m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            tStr = m_LastHiter.m_sCharName;
                        }
                        else
                        {
                            tStr = "#" + m_LastHiter.m_sCharName;
                        }
                    }
                    else
                    {
                        tStr = "####";
                    }
                    nCheckCode = 244;
                    M2Share.AddGameDataLog("19" + "\09" + m_sMapName + "\09" + (m_nCurrX).ToString() + "\09" + (m_nCurrY).ToString() + "\09" + m_sCharName
                        + "\09" + "FZ-" + HUtil32.BoolToIntStr(m_PEnvir.m_boFightZone) + "_F3-" + HUtil32.BoolToIntStr(m_PEnvir.m_boFight3Zone) + "\09" + "0" + "\09" + "1" + "\09" + tStr);
                }
                nCheckCode = 38;
                if ((m_Master == null) && !m_boDelFormMaped)
                {
                    m_PEnvir.DelObjectCount(this); // ���ٵ�ͼ�Ϲ������
                    m_boDelFormMaped = true;
                }
                SendRefMsg(Grobal2.RM_DEATH, m_btDirection, m_nCurrX, m_nCurrY, 1, "");
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg3 + (nCheckCode).ToString());
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public virtual void ReAlive()
        {
            m_boDeath = false;
            SendRefMsg(Grobal2.RM_ALIVE, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
        }

        /// <summary>
        /// ���������Լ�����
        /// </summary>
        /// <param name="BaseObject"></param>
        public void SetLastHiter(TBaseObject BaseObject)
        {
            if (BaseObject == null)
            {
                return;
            }
            m_LastHiter = BaseObject;
            m_LastHiterTick = HUtil32.GetTickCount();
            if (m_ExpHitter == null)
            {
                m_ExpHitter = BaseObject;

                m_ExpHitterTick = HUtil32.GetTickCount();
            }
            else
            {
                if (m_ExpHitter == BaseObject)
                {
                    m_ExpHitterTick = HUtil32.GetTickCount();
                }
            }
        }

        /// <summary>
        /// �����������ֱ�ɫ,������
        /// </summary>
        /// <param name="BaseObject"></param>
        public void SetPKFlag(TBaseObject BaseObject)
        {
            byte nCode = 0;
            if (BaseObject == null)
            {
                return;
            }
            try
            {
                // PK��װ����ͼ
                // ��ս��ͼ
                if ((PKLevel() < 2) && (BaseObject.PKLevel() < 2) && (!m_PEnvir.m_boFightZone) && (!m_PEnvir.m_boFight2Zone) && (!m_PEnvir.m_boFight3Zone) &&
                    (!m_PEnvir.m_boFight4Zone) && !m_boPKFlag)
                {
                    nCode = 1;
                    BaseObject.m_dwPKTick = HUtil32.GetTickCount();
                    if (!BaseObject.m_boPKFlag)
                    {
                        nCode = 2;
                        BaseObject.m_boPKFlag = true;
                        nCode = 3;
                        BaseObject.RefNameColor();
                        nCode = 4;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.SetPKFlag  Code:" + nCode);
            }
        }

        public bool IsGoodKilling(TBaseObject Cert)
        {
            return Cert.m_boPKFlag == true ? true : false;
        }

        /// <summary>
        /// �Ƿ���Ϲ���Ҫ��
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public virtual bool IsProtectTarget(TBaseObject BaseObject)
        {
            bool result = true;
            if (BaseObject == null)
            {
                return result;
            }
            if ((InSafeZone()) || (BaseObject.InSafeZone())) // ��ȫ��
            {
                result = false;
            }
            if (!BaseObject.m_boInFreePKArea)  // ���˱���
            {
                if (GameConfig.boPKLevelProtect)
                {
                    if ((m_Abil.Level > GameConfig.nPKProtectLevel))  // �������ָ���ȼ�
                    {
                        if (!BaseObject.m_boPKFlag && (BaseObject.m_Abil.Level <= GameConfig.nPKProtectLevel)
                            && (BaseObject.PKLevel() < 2)) // ������������Сָ���ȼ�û�к������򲻿��Թ�����
                        {
                            result = false;
                            return result;
                        }
                    }
                    if ((m_Abil.Level <= GameConfig.nPKProtectLevel))  // ���С��ָ���ȼ�
                    {
                        if (!BaseObject.m_boPKFlag && (BaseObject.m_Abil.Level > GameConfig.nPKProtectLevel)
                            && (BaseObject.PKLevel() < 2))
                        {
                            result = false;
                            return result;
                        }
                    }
                }
                // ����ָ������ĺ������ﲻ����ɱָ������δ���������
                if ((PKLevel() >= 2) && (m_Abil.Level > GameConfig.nRedPKProtectLevel))
                {
                    if ((BaseObject.m_Abil.Level <= GameConfig.nRedPKProtectLevel) && (BaseObject.PKLevel() < 2))
                    {
                        result = false;
                        return result;
                    }
                }
                // С��ָ������ķǺ������ﲻ����ɱָ������������
                if ((m_Abil.Level <= GameConfig.nRedPKProtectLevel) && (PKLevel() < 2))
                {
                    if ((BaseObject.PKLevel() >= 2) && (BaseObject.m_Abil.Level > GameConfig.nRedPKProtectLevel))
                    {
                        result = false;
                        return result;
                    }
                }
                if ((HUtil32.GetTickCount() - m_dwMapMoveTick < 3000) || (HUtil32.GetTickCount() - BaseObject.m_dwMapMoveTick < 3000))
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// �Ƿ��ǹ���Ŀ��
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public virtual bool IsAttackTarget(TBaseObject BaseObject)
        {
            bool result = false;
            byte nCode = 0;
            try
            {
                if (BaseObject == null || BaseObject != null && BaseObject == this)
                {
                    return result;
                }
                nCode = 1;
                if (BaseObject.m_btRaceServer == 135) // 135���͹� �ý�ɫ��Ӣ�ۡ�����������
                {
                    return result;
                }
                nCode = 2;// 50
                if (m_btRaceServer >= Grobal2.RC_ANIMAL)
                {
                    nCode = 3;
                    if (m_Master != null)
                    {
                        if (m_Master.m_LastHiter != null)
                        {
                            if (m_Master.m_LastHiter == BaseObject)
                            {
                                result = true;
                            }
                        }
                        if (m_Master.m_ExpHitter != null)
                        {
                            if (m_Master.m_ExpHitter == BaseObject)
                            {
                                result = true;
                            }
                        }
                        if (m_Master.m_TargetCret != null)
                        {
                            if (m_Master.m_TargetCret == BaseObject)
                            {
                                result = true;
                            }
                        }
                        if (m_LastHiter != null)
                        {
                            if ((m_LastHiter == BaseObject))
                            {
                                result = true; // ��������
                            }
                        }
                        if (m_ExpHitter != null)
                        {
                            if ((m_ExpHitter == BaseObject))
                            {
                                result = true; // ��������
                            }
                        }
                        nCode = 4;
                        if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && !result)
                        {
                            if ((m_TargetCret == BaseObject) || (m_LastHiter == BaseObject) || (m_ExpHitter == BaseObject))
                            {
                                result = true;
                            }
                            if ((m_SlaveList.Count > 0) && !result)
                            {
                                for (int I = 0; I < m_SlaveList.Count; I++)
                                {
                                    if (m_SlaveList[I].m_TargetCret != null)// ����������Ŀ��
                                    {
                                        nCode = 121;
                                        if (m_SlaveList[I].m_TargetCret == BaseObject)
                                        {
                                            nCode = 122;
                                            result = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if ((m_Master != null) && !result)
                            {
                                if ((m_Master.m_SlaveList.Count > 0))
                                {
                                    for (int I = 0; I < m_Master.m_SlaveList.Count; I++)
                                    {
                                        if (m_Master.m_SlaveList[I].m_TargetCret != null)
                                        {
                                            nCode = 123;
                                            if (m_Master.m_SlaveList[I].m_TargetCret == BaseObject)
                                            {
                                                nCode = 124;
                                                result = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        nCode = 5;
                        if (BaseObject.m_TargetCret != null)
                        {
                            if ((BaseObject.m_TargetCret == m_Master) && (BaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT))
                            {
                                result = true;
                            }
                            nCode = 6;
                            if ((BaseObject.m_TargetCret == this) && (BaseObject.m_btRaceServer > Grobal2.RC_ANIMAL))
                            {
                                result = true;
                            }
                        }
                        nCode = 7;
                        if ((BaseObject.m_Master != null) && !result)
                        {
                            nCode = 107;
                            if ((m_Master.m_LastHiter != null))
                            {
                                if ((BaseObject.m_Master == m_Master.m_LastHiter))
                                {
                                    result = true;
                                }
                            }
                            nCode = 108;
                            if ((m_Master.m_TargetCret != null))
                            {
                                if ((BaseObject.m_Master == m_Master.m_TargetCret))
                                {
                                    result = true;
                                }
                            }
                            if ((BaseObject.m_Master != null) && result)
                            {
                                nCode = 109;
                                if ((BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT))// ����Ӣ������
                                {
                                    nCode = 110;
                                    if (BaseObject.m_Master.m_Master != null)
                                    {
                                        nCode = 111;
                                        if (BaseObject.m_Master.m_Master == m_Master)
                                        {
                                            result = false;
                                        }
                                    }
                                }
                            }
                        }
                        nCode = 20;
                        if (((m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)) && result)
                        {
                            switch (m_Master.m_btAttatckMode)
                            {
                                case M2Share.HAM_PEACE:// 1 ��ƽ����
                                    nCode = 21;
                                    if (BaseObject.m_btRaceServer < Grobal2.RC_ANIMAL)
                                    {
                                        result = false;
                                    }
                                    nCode = 22;
                                    if (BaseObject.m_Master != null)
                                    {
                                        result = false;
                                    }
                                    break;
                                case M2Share.HAM_DEAR:// ���޹���
                                    nCode = 23;
                                    if (m_Master != null)
                                    {
                                        nCode = 28;
                                        if ((((m_Master) as TPlayObject).m_DearHuman != null) && (BaseObject != null))
                                        {
                                            nCode = 112;
                                            if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (BaseObject == ((m_Master) as TPlayObject).m_DearHuman))
                                            {
                                                result = false;
                                            }
                                            nCode = 24;
                                            if (BaseObject != null)
                                            {
                                                if (BaseObject.m_Master != null)
                                                {
                                                    nCode = 25;
                                                    if (BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                    {
                                                        nCode = 26;
                                                        if (BaseObject.m_Master.m_Master == ((m_Master) as TPlayObject).m_DearHuman)
                                                        {
                                                            result = false;
                                                        }
                                                    }
                                                    else if (BaseObject.m_Master == ((m_Master) as TPlayObject).m_DearHuman)
                                                    {
                                                        result = false;
                                                    }
                                                    nCode = 27;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case M2Share.HAM_MASTER:// ʦͽ����
                                    if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        nCode = 29;
                                        if ((m_Master != null) && (BaseObject != null))
                                        {
                                            nCode = 30;
                                            if ((((m_Master) as TPlayObject).m_boMaster))
                                            {
                                                if (((BaseObject) as TPlayObject).m_sMasterName == m_Master.m_sCharName)
                                                {
                                                    result = false;
                                                }
                                            }
                                        }
                                        nCode = 31;
                                        if (((BaseObject) as TPlayObject).m_boMaster)
                                        {
                                            nCode = 32;
                                            if (m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) // ��������
                                            {
                                                if (BaseObject.m_sCharName == ((m_Master) as TPlayObject).m_sMasterName)
                                                {
                                                    result = false;
                                                }
                                            }
                                            nCode = 33;
                                            if ((m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                && (m_Master.m_Master != null))// ������Ӣ��
                                            {
                                                if (BaseObject.m_sCharName == ((m_Master.m_Master) as TPlayObject).m_sMasterName)
                                                {
                                                    result = false;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (BaseObject.m_Master != null)
                                        {
                                            nCode = 38;
                                            if ((BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                && (BaseObject.m_Master.m_Master != null))
                                            {
                                                nCode = 39;
                                                if ((m_Master != null))
                                                {
                                                    nCode = 40;
                                                    if ((((m_Master) as TPlayObject).m_boMaster))
                                                    {
                                                        if (((BaseObject.m_Master.m_Master) as TPlayObject).m_sMasterName ==
                                                            m_Master.m_sCharName)
                                                        {
                                                            result = false;
                                                        }
                                                    }
                                                }
                                                nCode = 41;
                                                if (((BaseObject.m_Master.m_Master) as TPlayObject).m_boMaster)
                                                {
                                                    nCode = 42;
                                                    if (m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)// ��������
                                                    {
                                                        if (BaseObject.m_Master.m_Master.m_sCharName ==
                                                            ((m_Master) as TPlayObject).m_sMasterName)
                                                        {
                                                            result = false;
                                                        }
                                                    }
                                                    nCode = 43;
                                                    if ((m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT) &&
                                                        (m_Master.m_Master != null))// ������Ӣ��
                                                    {
                                                        if (BaseObject.m_Master.m_Master.m_sCharName ==
                                                            ((m_Master.m_Master) as TPlayObject).m_sMasterName)
                                                        {
                                                            result = false;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // ���˲���Ӣ��
                                                if ((BaseObject.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                                {
                                                    nCode = 45;
                                                    if ((m_Master != null))
                                                    {
                                                        nCode = 125;
                                                        if ((((m_Master) as TPlayObject).m_boMaster))
                                                        {
                                                            if (((BaseObject.m_Master) as TPlayObject).m_sMasterName == m_Master.m_sCharName)
                                                            {
                                                                result = false;
                                                            }
                                                        }
                                                    }
                                                    nCode = 48;
                                                    if (((BaseObject.m_Master) as TPlayObject).m_boMaster)
                                                    {
                                                        nCode = 46;
                                                        if (m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)// ��������
                                                        {
                                                            if (BaseObject.m_Master.m_sCharName == ((m_Master) as TPlayObject).m_sMasterName)
                                                            {
                                                                result = false;
                                                            }
                                                        }
                                                        nCode = 47;
                                                        if ((m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT) &&
                                                            (m_Master.m_Master != null))// ������Ӣ��
                                                        {
                                                            if (BaseObject.m_Master.m_sCharName ==
                                                                ((m_Master.m_Master) as TPlayObject).m_sMasterName)
                                                            {
                                                                result = false;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case M2Share.HAM_GROUP:// 2 ���鹥��
                                    nCode = 55;
                                    if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        if (((m_Master) as TPlayObject).IsGroupMember(BaseObject))
                                        {
                                            result = false;
                                            BreakCrazyMode();
                                            return result;
                                        }
                                    }
                                    nCode = 56;
                                    if (m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        nCode = 57;
                                        if ((m_Master.m_Master != null))
                                        {
                                            if (((m_Master.m_Master) as TPlayObject).IsGroupMember(BaseObject))
                                            {
                                                result = false;
                                                BreakCrazyMode();
                                                return result;
                                            }
                                        }
                                        nCode = 58;
                                        if ((BaseObject != null) && (BaseObject.m_Master != null) && (m_Master.m_Master != null) && (m_Master.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                        {
                                            nCode = 72;
                                            if (BaseObject.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                nCode = 96;
                                                if (((m_Master.m_Master) as TPlayObject).IsGroupMember(BaseObject.m_Master))
                                                {
                                                    result = false;
                                                    BreakCrazyMode();
                                                    return result;
                                                }
                                            }
                                            nCode = 73;
                                            if ((BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (BaseObject.m_Master.m_Master != null))
                                            {
                                                nCode = 97;
                                                if (((m_Master.m_Master) as TPlayObject).IsGroupMember(BaseObject.m_Master.m_Master))
                                                {
                                                    result = false;
                                                    BreakCrazyMode();
                                                    return result;
                                                }
                                            }
                                        }
                                    }
                                    if (m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        nCode = 59;
                                        if (((m_Master) as TPlayObject).IsGroupMember(BaseObject))
                                        {
                                            result = false;
                                            BreakCrazyMode();
                                            return result;
                                        }
                                        nCode = 71;
                                        if ((BaseObject != null) && result)
                                        {
                                            if ((BaseObject.m_Master != null) && (m_Master != null))
                                            {
                                                nCode = 82;
                                                if (BaseObject.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                {
                                                    nCode = 126;
                                                    if (((m_Master) as TPlayObject).IsGroupMember(BaseObject.m_Master))
                                                    {
                                                        result = false;
                                                    }
                                                }
                                                nCode = 95;
                                                if ((BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (BaseObject.m_Master.m_Master != null) && result)
                                                {
                                                    nCode = 127;
                                                    if (((m_Master) as TPlayObject).IsGroupMember(BaseObject.m_Master.m_Master))
                                                    {
                                                        result = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case M2Share.HAM_GUILD:// �лṥ��
                                    nCode = 60;
                                    if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        if ((m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                        {
                                            if ((m_Master.m_MyGuild != null))
                                            {
                                                nCode = 61;
                                                if (m_Master.m_MyGuild.IsMember(BaseObject.m_sCharName))
                                                {
                                                    result = false;
                                                }
                                                nCode = 62;
                                                if (m_boGuildWarArea && (BaseObject.m_MyGuild != null))
                                                {
                                                    nCode = 63;
                                                    if (m_Master.m_MyGuild.IsAllyGuild(BaseObject.m_MyGuild))
                                                    {
                                                        result = false;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            nCode = 161;
                                            if (m_Master.m_Master != null)
                                            {
                                                nCode = 162;
                                                if ((m_Master.m_Master.m_MyGuild != null))
                                                {
                                                    nCode = 163;
                                                    if (m_Master.m_Master.m_MyGuild.IsMember(BaseObject.m_sCharName))
                                                    {
                                                        result = false;
                                                    }
                                                    nCode = 164;
                                                    if (m_boGuildWarArea && (BaseObject.m_MyGuild != null))
                                                    {
                                                        nCode = 165;
                                                        if (m_Master.m_Master.m_MyGuild.IsAllyGuild(BaseObject.m_MyGuild))
                                                        {
                                                            result = false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    nCode = 64;
                                    if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (BaseObject.m_Master != null))
                                    {
                                        nCode = 65;
                                        if ((m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                        {
                                            if ((m_Master.m_MyGuild != null))
                                            {
                                                nCode = 66;
                                                if (m_Master.m_MyGuild.IsMember(BaseObject.m_Master.m_sCharName))
                                                {
                                                    result = false;
                                                }
                                                nCode = 67;
                                                if (m_boGuildWarArea && (BaseObject.m_Master.m_MyGuild != null))
                                                {
                                                    nCode = 68;
                                                    if (m_Master.m_MyGuild.IsAllyGuild(BaseObject.m_Master.m_MyGuild))
                                                    {
                                                        result = false;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            nCode = 166;
                                            if (m_Master.m_Master != null)
                                            {
                                                nCode = 167;
                                                if ((m_Master.m_Master.m_MyGuild != null))
                                                {
                                                    nCode = 168;
                                                    if (m_Master.m_Master.m_MyGuild.IsMember(BaseObject.m_Master.m_sCharName))
                                                    {
                                                        result = false;
                                                    }
                                                    nCode = 169;
                                                    if (m_boGuildWarArea && (BaseObject.m_Master.m_MyGuild != null))
                                                    {
                                                        nCode = 170;
                                                        if (m_Master.m_Master.m_MyGuild.IsAllyGuild(BaseObject.m_Master.m_MyGuild))
                                                        {
                                                            result = false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        nCode = 8;
                        if ((BaseObject.m_Master == m_Master) || (BaseObject == m_Master)) // ��������˲���������
                        {
                            result = false;
                        }
                        nCode = 9;
                        if ((m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (BaseObject.m_Master != null)) // ������������Ӣ������
                        {
                            if ((((m_Master) as TPlayObject).m_MyHero != null) && (BaseObject.m_Master == ((m_Master) as TPlayObject).m_MyHero))
                            {
                                result = false;
                            }
                        }
                        nCode = 10;
                        if ((m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)) // ���������Ӣ��,������Ӣ�۵�����
                        {
                            nCode = 11;
                            if (m_Master.m_Master != null)
                            {
                                nCode = 12;
                                if (BaseObject == m_Master.m_Master)// Ӣ�۵�����������������
                                {
                                    result = false;
                                }
                                nCode = 13;
                                if ((m_Master.m_Master.m_SlaveList.Count > 0))
                                {
                                    nCode = 14;
                                    for (int I = 0; I < m_Master.m_Master.m_SlaveList.Count; I++)
                                    {
                                        nCode = 15;
                                        if (((m_Master.m_Master.m_SlaveList[I]) as TBaseObject) == BaseObject)
                                        {
                                            nCode = 16;
                                            result = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        nCode = 17;
                        if ((m_SlaveList.Count > 0) && (m_btAttatckMode != M2Share.HAM_ALL))// ���������Լ�������
                        {
                            nCode = 18;
                            for (int I = 0; I < m_SlaveList.Count; I++)
                            {
                                nCode = 19;
                                if (((m_SlaveList[I]) as TBaseObject) == BaseObject)
                                {
                                    nCode = 20;
                                    result = false;
                                    break;
                                }
                            }
                        }
                        nCode = 74;
                        if (BaseObject.m_boHolySeize)
                        {
                            result = false;
                        }
                        nCode = 75;
                        if ((m_Master.m_boSlaveRelax) && (m_btRaceServer != Grobal2.RC_HEROOBJECT)) // ��ⱦ���Ƿ�����Ϣ״̬,Ӣ�۳���
                        {
                            result = false;
                        }
                        nCode = 76;
                        if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) ||
                            (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (BaseObject.m_Master != null))// ��ȫ�����ܴ������Ӣ��
                        {
                            nCode = 77;
                            if (BaseObject.InSafeZone() || InSafeZone())
                            {
                                result = false;
                            }
                        }
                        nCode = 78;
                        BreakCrazyMode();
                    }
                    else
                    {
                        nCode = 79;
                        if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            result = true;
                        }
                        nCode = 80;
                        if ((m_btRaceServer > Grobal2.RC_PEACENPC) && (m_btRaceServer < Grobal2.RC_ANIMAL))// 15 50
                        {
                            result = true;
                        }
                        nCode = 81;
                        if (BaseObject.m_Master != null)
                        {
                            result = true;
                        }
                    }
                    nCode = 96;
                    if (((BaseObject.m_btRaceServer == 10) || (BaseObject.m_btRaceServer == 11) ||
                        (BaseObject.m_btRaceServer == Grobal2.RC_GUARD)) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) ||
                        (m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_Master != null)))
                    {
                        result = false;
                    }
                    nCode = 83;
                    if (m_boCrazyMode)
                    {
                        result = true;
                    }
                }
                else
                {
                    nCode = 84;
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)// ���ӷ�����
                    {
                        switch (m_btAttatckMode)// ����״̬
                        {
                            case M2Share.HAM_ALL://0 ȫ�幥��
                                nCode = 85;// 10 15
                                if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                                {
                                    result = true;
                                }
                                if (GameConfig.boNonPKServer)
                                {
                                    result = true;
                                }
                                break;
                            case M2Share.HAM_PEACE:// û�н�ֹPK 1 ��ƽ����
                                nCode = 86;
                                if (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                                {
                                    result = true;
                                }
                                if (BaseObject.m_Master != null)
                                {
                                    result = false;
                                }
                                break;
                            case M2Share.HAM_DEAR:// ���޹���
                                nCode = 87;
                                if (BaseObject != ((this) as TPlayObject).m_DearHuman)
                                {
                                    result = true;
                                }
                                if (BaseObject.m_Master != null)
                                {
                                    if (BaseObject.m_Master != ((this) as TPlayObject).m_DearHuman)
                                    {
                                        result = true;
                                    }
                                }
                                break;
                            case M2Share.HAM_MASTER:// ʦͽ����
                                nCode = 88;
                                if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    nCode = 89;
                                    result = true;
                                    if (((this) as TPlayObject).m_boMaster)
                                    {
                                        if (((this) as TPlayObject).m_MasterList.Count > 0)
                                        {
                                            for (int I = 0; I < ((this) as TPlayObject).m_MasterList.Count; I++)
                                            {
                                                if (((this) as TPlayObject).m_MasterList[I] == BaseObject)
                                                {
                                                    result = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (((BaseObject) as TPlayObject).m_boMaster)
                                    {
                                        if (((BaseObject) as TPlayObject).m_MasterList.Count > 0)
                                        {
                                            for (int I = 0; I < ((BaseObject) as TPlayObject).m_MasterList.Count; I++)
                                            {
                                                if (((BaseObject) as TPlayObject).m_MasterList[I] == this)
                                                {
                                                    result = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    result = true;
                                }
                                break;
                            case M2Share.HAM_GROUP:// 2 ���鹥��
                                nCode = 90;
                                if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                                {
                                    result = true;
                                }
                                if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    if (((this) as TPlayObject).IsGroupMember(BaseObject))
                                    {
                                        result = false;
                                    }
                                }
                                if (BaseObject.m_Master != null)
                                {
                                    if (BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        if (BaseObject.m_Master.m_Master != null)
                                        {
                                            if (((this) as TPlayObject).IsGroupMember(BaseObject.m_Master.m_Master))
                                            {
                                                result = false;
                                            }
                                        }
                                    }
                                    else if (((this) as TPlayObject).IsGroupMember(BaseObject.m_Master))
                                    {
                                        result = false;
                                    }
                                }
                                if (GameConfig.boNonPKServer)
                                {
                                    result = true;
                                }
                                break;
                            case M2Share.HAM_GUILD:// �лṥ��
                                nCode = 91;
                                if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                                {
                                    result = true;
                                }
                                if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    if (m_MyGuild != null)
                                    {
                                        if (((TGUild)(m_MyGuild)).IsMember(BaseObject.m_sCharName))
                                        {
                                            result = false;
                                        }
                                        if (m_boGuildWarArea && (BaseObject.m_MyGuild != null))
                                        {
                                            if (((TGUild)(m_MyGuild)).IsAllyGuild(((TGUild)(BaseObject.m_MyGuild))))
                                            {
                                                result = false;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // ����ͬ�л�ı���
                                    nCode = 92;
                                    if (BaseObject.m_Master != null)
                                    {
                                        if (BaseObject.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            if (m_MyGuild != null)
                                            {
                                                if (((TGUild)(m_MyGuild)).IsMember(BaseObject.m_Master.m_sCharName))
                                                {
                                                    result = false;
                                                }
                                                if (m_boGuildWarArea && (BaseObject.m_Master.m_MyGuild != null))
                                                {
                                                    if (((TGUild)(m_MyGuild)).IsAllyGuild(((TGUild)(BaseObject.m_Master.m_MyGuild))))
                                                    {
                                                        result = false;
                                                    }
                                                }
                                            }
                                        }
                                        else if (BaseObject.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            nCode = 93;
                                            if ((m_MyGuild != null) && (BaseObject.m_Master.m_Master != null))
                                            {
                                                if (((TGUild)(m_MyGuild)).IsMember(BaseObject.m_Master.m_Master.m_sCharName))
                                                {
                                                    result = false;
                                                }
                                                if (m_boGuildWarArea && (BaseObject.m_Master.m_Master.m_MyGuild != null))
                                                {
                                                    if (((TGUild)(m_MyGuild)).IsAllyGuild(((TGUild)(BaseObject.m_Master.m_Master.m_MyGuild))))
                                                    {
                                                        result = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (GameConfig.boNonPKServer)
                                {
                                    result = true;
                                }
                                break;
                            case M2Share.HAM_PKATTACK:// ��������
                                nCode = 94;
                                if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                                {
                                    result = true;
                                }
                                if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    if (PKLevel() >= 2)
                                    {
                                        if (BaseObject.PKLevel() < 2)
                                        {
                                            result = true;
                                        }
                                        else
                                        {
                                            result = false;
                                        }
                                    }
                                    else
                                    {
                                        if (BaseObject.PKLevel() >= 2)
                                        {
                                            result = true;
                                        }
                                        else
                                        {
                                            result = false;
                                        }
                                    }
                                }
                                if (GameConfig.boNonPKServer)
                                {
                                    result = true;
                                }
                                break;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                }
                if (BaseObject.m_boAdminMode || BaseObject.m_boStoneMode)
                {
                    result = false;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.IsAttackTarget Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// �Ƿ����ʵ���Ŀ��
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public virtual bool IsProperTarget(TBaseObject BaseObject)
        {
            bool result = false;
            byte nCode = 0;
            try
            {
                result = IsAttackTarget(BaseObject);
                nCode = 1;
                if (result)
                {
                    nCode = 2;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        nCode = 3;
                        result = IsProtectTarget(BaseObject);// ��������Ƿ���Ϲ���Ҫ��
                    }
                }
                nCode = 4;
                if ((BaseObject != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (BaseObject.m_Master != null)
                    && (BaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT))
                {
                    nCode = 5;
                    if (BaseObject.m_Master == this)
                    {
                        nCode = 6;
                        if ((m_btAttatckMode != M2Share.HAM_ALL) &&
                            (BaseObject == ((this) as TPlayObject).m_MyHero))// ����Ƿ����Լ��ı���
                        {
                            result = false;
                        }
                        nCode = 7;
                        if ((m_SlaveList.Count > 0) && (m_btAttatckMode != M2Share.HAM_ALL))
                        {
                            nCode = 8;
                            for (int I = 0; I < m_SlaveList.Count; I++)
                            {
                                nCode = 9;
                                if (m_SlaveList[I] == BaseObject)
                                {
                                    nCode = 10;
                                    result = false;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        nCode = 11;
                        result = IsAttackTarget(BaseObject.m_Master);
                        nCode = 12;
                        if (InSafeZone() || BaseObject.InSafeZone())  // ����Ƿ����ڰ�ȫ��
                        {
                            result = false;
                        }
                        nCode = 13;
                        if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (InSafeZone() || BaseObject.InSafeZone())
                            && (BaseObject.m_Master != null))
                        {
                            result = false;
                        }
                        //Ӣ�۲����ڰ�ȫ��PK
                        nCode = 14;
                        if ((((this) as TPlayObject).m_MyHero != null) && (m_btAttatckMode != M2Share.HAM_ALL))
                        {
                            // ��������Ӣ�۵�����
                            nCode = 15;
                            if ((((this) as TPlayObject).m_MyHero.m_SlaveList.Count > 0) && (m_btAttatckMode != M2Share.HAM_ALL))
                            {
                                nCode = 16;
                                for (int I = 0; I < ((this) as TPlayObject).m_MyHero.m_SlaveList.Count; I++)
                                {
                                    nCode = 17;
                                    if (((((this) as TPlayObject).m_MyHero.m_SlaveList[I]) as TBaseObject) == BaseObject)
                                    {
                                        nCode = 18;
                                        result = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.IsProperTarget Code:" + nCode);
            }
            return result;
        }

        // ������Ŀ����
        public bool IsProperTargetSKILL_55(int nLevel, TBaseObject BaseObject)
        {
            bool result;
            result = false;
            if ((BaseObject == null) || (BaseObject == this))
            {
                return result;
            }
            if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
            {
                if ((BaseObject.m_btRaceServer != Grobal2.RC_GUARD) && (BaseObject.m_btRaceServer != Grobal2.RC_ARCHERGUARD) && (BaseObject.m_btRaceServer != 110)
                    && (BaseObject.m_btRaceServer != 111) && (nLevel >= BaseObject.m_Abil.Level) && (!BaseObject.m_boGhost) && (!BaseObject.m_boDeath))
                {
                    if (((!GameConfig.boPullPlayObject) || (nLevel < BaseObject.m_Abil.Level)) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        return result;
                    }
                    if (GameConfig.boPullCrossInSafeZone && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && BaseObject.InSafeZone())
                    {
                        return result;
                    }
                    if (GameConfig.boPullCrossInSafeZone && (BaseObject.m_Master != null) && BaseObject.InSafeZone()) // ������ץ��ȫ���ı���
                    {
                        return result;
                    }
                    result = true;
                }
            }
            return result;
        }

        // ������
        public bool IsProperTargetSKILL_54(TBaseObject BaseObject)
        {
            bool result;
            result = false;
            if ((BaseObject == null) || (BaseObject == this))
            {
                return result;
            }
            if (BaseObject.m_boDeath && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
            {
                if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                {
                    if ((BaseObject.m_btRaceServer != Grobal2.RC_GUARD) && (BaseObject.m_btRaceServer != Grobal2.RC_ARCHERGUARD)
                        && (BaseObject.m_btRaceServer != 110) && (BaseObject.m_btRaceServer != 111))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        // ������
        public bool IsProperTargetSKILL_57(TBaseObject BaseObject)
        {
            bool result = false;
            if ((BaseObject == null) || (BaseObject == this))
            {
                return result;
            }
            if (BaseObject.m_boDeath && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
            {
                if (((BaseObject) as TPlayObject).m_boAllowReAlive)
                {
                    result = true;
                }
                else
                {
                    SysMsg("�Է���ֹ�������", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            return result;
        }

        /// <summary>
        /// ���ظı�
        /// </summary>
        public virtual void WeightChanged()
        {
            m_WAbil.Weight = RecalcBagWeight();
            SendUpdateMsg(this, Grobal2.RM_WEIGHTCHANGED, 0, 0, 0, 0, "");
        }

        /// <summary>
        /// �Ƿ�ȫ��
        /// </summary>
        /// <returns></returns>
        public bool InSafeZone()
        {
            bool result;
            int I;
            int nSafeX;
            int nSafeY;
            string sMapName;
            TStartPoint StartPoint;
            byte nCode;
            result = false;
            nCode = 0;
            if (this == null)
            {
                return result;
            }
            if (m_boGhost)
            {
                return result;
            }
            try
            {
                nCode = 1;
                if (m_PEnvir == null) // ����������ˢ��ǽ�Ĵ���
                {
                    result = true;
                    return result;
                }
                nCode = 2;
                if ((m_PEnvir != null) && !m_boGhost)
                {
                    nCode = 21;
                    try
                    {
                        result = m_PEnvir.m_boSAFE;
                        nCode = 22;
                        if (result)
                        {
                            return result;
                        }
                        nCode = 3;
                        if ((m_PEnvir.sMapName != GameConfig.sRedHomeMap)
                            || (Math.Abs(m_nCurrX - GameConfig.nRedHomeX) > GameConfig.nSafeZoneSize)
                            || (Math.Abs(m_nCurrY - GameConfig.nRedHomeY) > GameConfig.nSafeZoneSize))
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    catch
                    {
                    }
                }
                nCode = 4;
                if (result)
                {
                    return result;
                }
                try
                {
                    //M2Share.g_StartPointList.__Lock();
                    nCode = 5;
                    if (M2Share.g_StartPointList.Count > 0)
                    {
                        for (I = 0; I < M2Share.g_StartPointList.Count; I++)
                        {
                            nCode = 6;
                            sMapName = M2Share.g_StartPointList[I].m_sMapName;
                            if (m_boGhost)
                            {
                                break;
                            }
                            nCode = 12;
                            try
                            {
                                if ((m_PEnvir != null) && (sMapName != "") && !m_boGhost)
                                {
                                    nCode = 11;
                                    if ((sMapName == m_PEnvir.sMapName))
                                    {
                                        nCode = 8;
                                        StartPoint = M2Share.g_StartPointList[I];
                                        if (StartPoint != null)
                                        {
                                            nCode = 9;
                                            nSafeX = StartPoint.m_nCurrX;
                                            nSafeY = StartPoint.m_nCurrY;
                                            nCode = 10;
                                            if ((Math.Abs(m_nCurrX - nSafeX) <= GameConfig.nSafeZoneSize)
                                                && (Math.Abs(m_nCurrY - nSafeY) <= GameConfig.nSafeZoneSize))
                                            {
                                                result = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                }
                finally
                {
                    //M2Share.g_StartPointList.UnLock();
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.InSafeZone Code:" + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// �ڰ�ȫ��
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        public bool InSafeZone(TEnvirnoment Envir, int nX, int nY)
        {
            bool result;
            int I;
            int nSafeX;
            int nSafeY;
            string sMapName;
            TStartPoint StartPoint;
            if (m_PEnvir == null)// ����������ˢ��ǽ�Ĵ���
            {
                result = true;
                return result;
            }
            result = Envir.m_boSAFE;
            if (result)
            {
                return result;
            }
            if ((Envir.sMapName != GameConfig.sRedHomeMap) ||
                (Math.Abs(nX - GameConfig.nRedHomeX) > GameConfig.nSafeZoneSize) ||
                (Math.Abs(nY - GameConfig.nRedHomeY) > GameConfig.nSafeZoneSize))
            {
                result = false;
            }
            else
            {
                result = true;
            }
            if (result)
            {
                return result;
            }
            try
            {
                if (M2Share.g_StartPointList.Count > 0)
                {
                    for (I = 0; I < M2Share.g_StartPointList.Count; I++)
                    {
                        sMapName = M2Share.g_StartPointList[I].m_sMapName;
                        if ((sMapName == Envir.sMapName))
                        {
                            StartPoint = M2Share.g_StartPointList[I];
                            if (StartPoint != null)
                            {
                                nSafeX = StartPoint.m_nCurrX;
                                nSafeY = StartPoint.m_nCurrY;
                                if ((Math.Abs(nX - nSafeX) <= GameConfig.nSafeZoneSize) &&
                                    (Math.Abs(nY - nSafeY) <= GameConfig.nSafeZoneSize))
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
            }
            return result;
        }

        // �����߶�ģʽ
        public void OpenHolySeizeMode(uint dwInterval)
        {
            m_boHolySeize = true;
            m_dwHolySeizeTick = HUtil32.GetTickCount();
            m_dwHolySeizeInterval = dwInterval;
            RefNameColor();
        }

        // ��ʥ��ģʽ
        public void BreakHolySeizeMode()
        {
            m_boHolySeize = false;
            RefNameColor();
        }

        // ���������ģʽ
        public void OpenCrazyMode(int nTime)
        {
            m_boCrazyMode = true;
            m_dwCrazyModeTick = HUtil32.GetTickCount();
            m_dwCrazyModeInterval = Convert.ToUInt32(nTime * 1000);
            RefNameColor();
        }

        // �رչ����ģʽ
        public void BreakCrazyMode()
        {
            if (m_boCrazyMode)
            {
                m_boCrazyMode = false;
                RefNameColor();
            }
        }

        /// <summary>
        /// ���Ӽ��ܵ�����ֵ
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <param name="nTranPoint"></param>
        public unsafe void TrainSkill(TUserMagic* UserMagic, int nTranPoint)
        {
            if (m_boFastTrain)
            {
                nTranPoint = nTranPoint * 3;
            }
            UserMagic->nTranPoint += nTranPoint;
        }

        /// <summary>
        /// ���ħ������
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe bool CheckMagicLevelup(TUserMagic* UserMagic)
        {
            bool result = false;
            int n10;
            if ((UserMagic->btLevel < 4) && (UserMagic->MagicInfo.btTrainLv >= UserMagic->btLevel))
            {
                n10 = UserMagic->btLevel;
            }
            else
            {
                n10 = 0;
            }
            if ((UserMagic->MagicInfo.btTrainLv > UserMagic->btLevel) && (UserMagic->MagicInfo.MaxTrain[n10] <= UserMagic->nTranPoint))
            {
                if ((UserMagic->MagicInfo.btTrainLv > UserMagic->btLevel))
                {
                    // ����Ԫ�������޸ľ���
                    if (UserMagic->MagicInfo.wMagicId != 67)
                    {
                        UserMagic->nTranPoint -= UserMagic->MagicInfo.MaxTrain[n10];
                    }
                    UserMagic->btLevel++;
                    if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                    {
                        // Ӣ��ħ������
                        ((THeroObject)(this)).SendUpdateDelayMsg(m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0,
                            UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                    }
                    else
                    {
                        SendUpdateDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId,
                            UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                    }
                    sub_4C713C(UserMagic);
                }
                else
                {
                    UserMagic->nTranPoint = UserMagic->MagicInfo.MaxTrain[n10];
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// ���ù���Ŀ��
        /// </summary>
        /// <param name="BaseObject"></param>
        public virtual void SetTargetCreat(TBaseObject BaseObject)
        {
            m_TargetCret = BaseObject;
            m_dwTargetFocusTick = HUtil32.GetTickCount();
        }

        /// <summary>
        /// �������Ŀ��
        /// </summary>
        public virtual void DelTargetCreat()
        {
            m_TargetCret = null;
        }

        /// <summary>
        /// ���㼼������
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe int _Attack_MPow(TUserMagic* UserMagic)
        {
            int result;
            int nPower = UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
            result = (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower -
                UserMagic->MagicInfo.btDefPower));
            return result;
        }

        public unsafe int _Attack_GetNGPow(TBaseObject BaseObject, TUserMagic* UserMagic, int Power)
        {
            int result;// �ڹ����ܵ�����ֵ
            uint nNHPoint;
            result = 0;
            if ((UserMagic != null) && (BaseObject != null))
            {
                if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    nNHPoint = (uint)((BaseObject) as TPlayObject).GetSpellPoint(UserMagic);// ������ֵ
                    if (((BaseObject) as TPlayObject).m_Skill69NH >= nNHPoint)
                    {
                        ((BaseObject) as TPlayObject).m_Skill69NH = (ushort)HUtil32._MAX(0, ((BaseObject) as TPlayObject).m_Skill69NH - nNHPoint);
                        ((BaseObject) as TPlayObject).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((BaseObject) as TPlayObject).m_Skill69NH, ((BaseObject) as TPlayObject).m_Skill69MaxNH, 0, "");
                        result = (int)HUtil32.Round((double)Power * ((UserMagic->btLevel + 1) * (GameConfig.nNGSkillRate / 100)));// ���㹥����
                        ((BaseObject) as TPlayObject).NGMagic_Lvexp(UserMagic);// �ڹ���������
                    }
                }
                else if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    nNHPoint = (uint)((THeroObject)(BaseObject)).GetSpellPoint(UserMagic);
                    if (((THeroObject)(BaseObject)).m_Skill69NH >= nNHPoint)
                    {
                        ((THeroObject)(BaseObject)).m_Skill69NH = (ushort)HUtil32._MAX(0, ((THeroObject)(BaseObject)).m_Skill69NH - nNHPoint);
                        ((THeroObject)(BaseObject)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(BaseObject)).m_Skill69NH, ((THeroObject)(BaseObject)).m_Skill69MaxNH, 0, "");
                        result = (int)HUtil32.Round((double)Power * ((UserMagic->btLevel + 1) * (GameConfig.nNGSkillRate / 100)));// ���㹥����
                        ((THeroObject)(BaseObject)).NGMAGIC_LVEXP(UserMagic);// �ڹ���������
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ������ɫ
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nSecPwr"></param>
        /// <param name="boIsObject"></param>
        /// <returns></returns>
        public bool _Attack_DirectAttack(TBaseObject BaseObject, int nSecPwr, bool boIsObject)
        {
            bool result = false;
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT) ||
                (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                || !(InSafeZone() && BaseObject.InSafeZone()))
            {
                if (IsProperTarget(BaseObject))
                {
                    if (HUtil32.Random(BaseObject.m_btSpeedPoint) < m_btHitPoint)
                    {
                        BaseObject.StruckDamage(nSecPwr);
                        BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nSecPwr,
                        BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, this.ToInt(), "", 500);//����Ӣ�۹���
                        if ((BaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (BaseObject.m_btRaceServer != Grobal2.RC_HEROOBJECT) && !boIsObject)
                        {
                            BaseObject.SendMsg(BaseObject, Grobal2.RM_STRUCK, nSecPwr, BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, this.ToInt(), "");
                        }
                        result = true;
                    }
                }
            }
            return result;
        }

        // ��ɱǰ��һ��λ�õĹ���
        public bool _Attack_SwordLongAttack(int nSecPwr, int nLevel, TBaseObject Target, bool boisBaseObject)
        {
            bool result;
            int nX = 0;
            int nY = 0;
            TBaseObject BaseObject = null;
            result = false;
            boisBaseObject = false;
            nSecPwr = (int)HUtil32.Round((double)nSecPwr * GameConfig.nSwordLongPowerRate / 100);
            nSecPwr = (int)HUtil32.Round((double)nSecPwr * (nLevel * 0.2 + 0.4));// �����ܵȼ����㹥����
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                // �ڹ�����,������ͨ������
                if (((this) as TPlayObject).m_boTrainingNG && (((this) as TPlayObject).m_Skill69NH > 0))
                {
                    nSecPwr += (((this) as TPlayObject).m_NGLevel + 4);
                }
            }
            else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                if (((THeroObject)(this)).m_boTrainingNG && (((THeroObject)(this)).m_Skill69NH > 0))
                {
                    nSecPwr += (((THeroObject)(this)).m_NGLevel + 4);
                }
            }
            if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, m_btDirection, 2, ref nX, ref nY))
            {
                BaseObject = m_PEnvir.GetMovingObject(nX, nY, true);
                if (BaseObject != null)
                {
                    if ((nSecPwr > 0) && IsProperTarget(BaseObject))
                    {
                        if (Target != null)// �жϵ���λ����Ŀ���ǲ���ͬ������
                        {
                            if (BaseObject == Target)
                            {
                                boisBaseObject = true;
                            }
                        }
                        if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            // �ڹ�����,���ӷ���
                            if (((BaseObject) as TPlayObject).m_boTrainingNG && (((BaseObject) as TPlayObject).m_Skill69NH > 0))
                            {
                                nSecPwr = HUtil32._MAX(0, nSecPwr - (((BaseObject) as TPlayObject).m_NGLevel + 4));
                                //((BaseObject) as TPlayObject).m_Skill69NH = HUtil32._MAX(0, ((BaseObject) as TPlayObject).m_Skill69NH - GameConfig.nHitStruckDecNH);
                                ((BaseObject) as TPlayObject).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((BaseObject) as TPlayObject).m_Skill69NH, ((BaseObject) as TPlayObject).m_Skill69MaxNH, 0, "");
                            }
                        }
                        else if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            if (((THeroObject)(BaseObject)).m_boTrainingNG && (((THeroObject)(BaseObject)).m_Skill69NH > 0))
                            {
                                nSecPwr = HUtil32._MAX(0, nSecPwr - (((THeroObject)(BaseObject)).m_NGLevel + 4));
                                //((THeroObject)(BaseObject)).m_Skill69NH = HUtil32._MAX(0, ((THeroObject)(BaseObject)).m_Skill69NH - GameConfig.nHitStruckDecNH);
                                ((THeroObject)(BaseObject)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(BaseObject)).m_Skill69NH, ((THeroObject)(BaseObject)).m_Skill69MaxNH, 0, "");
                            }
                        }
                        if (BaseObject.m_boAbilMagBubbleDefence)
                        {
                            // �ļ��ܿɷ���λ��ɱ
                            if (BaseObject.m_btMagBubbleDefenceLevel == 4)
                            {
                                nSecPwr = (int)HUtil32.Round((double)nSecPwr * 0.86);// �ļ��ܿ��Լ��ٸ�λ��ɱ14%�Ĺ�����
                            }
                        }
                        result = _Attack_DirectAttack(BaseObject, nSecPwr, boisBaseObject);
                        if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                        {
                            m_ExpHitter = BaseObject;
                        }
                        if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                        {
                            SetTargetCreat(BaseObject);
                        }
                    }
                    result = true;
                }
            }
            return result;
        }

        // ���¹���
        public unsafe bool _Attack_SwordWideAttack(int nSecPwr)
        {
            bool result = false;
            int nC = 0;
            int n10;
            int nX = 0;
            int nY = 0;
            TBaseObject BaseObject = null;
            int nPwr;
            int nSePwr;
            while (true)
            {
                n10 = (m_btDirection + GameConfig.WideAttack[nC]) % 8;
                if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, n10, 1, ref nX, ref nY))
                {
                    BaseObject = m_PEnvir.GetMovingObject(nX, nY, true);
                    if ((nSecPwr > 0) && (BaseObject != null))
                    {
                        if (IsProperTarget(BaseObject))
                        {
                            nSePwr = nSecPwr;
                            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                nPwr = 0;
                                if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    nPwr = _Attack_GetNGPow(BaseObject, ((BaseObject) as TPlayObject).m_MagicSkill_203, nSePwr);// ��֮����
                                }
                                else if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    nPwr = _Attack_GetNGPow(BaseObject, ((THeroObject)(BaseObject)).m_MagicSkill_203, nSePwr);// ��֮����
                                }
                                nSePwr = HUtil32._MAX(0, nSePwr - nPwr);
                            }
                            result = _Attack_DirectAttack(BaseObject, nSePwr, false);
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = BaseObject;
                            }
                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                            {
                                SetTargetCreat(BaseObject);
                            }
                        }
                    }
                }
                nC++;
                if (nC >= 3)
                {
                    break;
                }
            }
            return result;
        }

        // Բ�¹���
        public bool _Attack_YuanYueAttack(int nSecPwr)
        {
            bool result = false;
            int nC = 0;
            int n10;
            int nX = 0;
            int nY = 0;
            TBaseObject BaseObject = null;
            int nSePwr;
            while (true)
            {
                n10 = (m_btDirection + GameConfig.YuanYueAttack[nC]) % 8;
                if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, n10, 1, ref nX, ref nY))
                {
                    BaseObject = m_PEnvir.GetMovingObject(nX, nY, true);
                    if ((nSecPwr > 0) && (BaseObject != null))
                    {
                        if (IsProperTarget(BaseObject))
                        {
                            nSePwr = nSecPwr;
                            result = _Attack_DirectAttack(BaseObject, nSePwr, false);
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = BaseObject;
                            }
                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                            {
                                SetTargetCreat(BaseObject);
                            }
                        }
                    }
                }
                nC++;// Բ���䵶 8������
                if (nC >= 7)
                {
                    break;
                }
            }
            return result;
        }

        // �����䵶
        public bool _Attack_CrsWideAttack(int nSecPwr)
        {
            bool result;
            int nC;
            int n10;
            int nX = 0;
            int nY = 0;
            TBaseObject BaseObject = null;
            result = false;
            nC = 0;
            while (true)
            {
                n10 = (m_btDirection + GameConfig.CrsAttack[nC]) % 8;
                if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, n10, 1, ref nX, ref nY))
                {
                    BaseObject = m_PEnvir.GetMovingObject(nX, nY, true);
                    if ((nSecPwr > 0) && (BaseObject != null))
                    {
                        if (IsProperTarget(BaseObject))
                        {
                            result = _Attack_DirectAttack(BaseObject, nSecPwr, false);
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = BaseObject;
                            }
                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                            {
                                SetTargetCreat(BaseObject);
                            }
                        }
                    }
                }
                nC++;
                if (nC >= 6)
                {
                    break;
                }
            }
            return result;
        }

        // ���ս���
        public unsafe bool _Attack_Attack_74(TBaseObject Target, int nSecPwr)
        {
            bool result;
            int NGSecPwr;
            int nSePwr;
            int nTwePwr;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            int nDamage;
            bool nReadSkill;// �Ƿ�ѧ��ŭ֮���� 
            result = false;
            BaseObjectList = new List<TBaseObject>();
            nTwePwr = nSecPwr;
            nReadSkill = false;
            try
            {
                GetDirectionBaseObjects(m_btDirection, 4, BaseObjectList);// ͬ������Ĺ� 4��
                if (BaseObjectList.Count > 0)
                {
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        if (((this) as TPlayObject).m_MagicSkill_206 != null)
                        {
                            NGSecPwr = _Attack_GetNGPow(this, ((this) as TPlayObject).m_MagicSkill_206, nTwePwr);// ŭ֮����
                            nSecPwr = HUtil32._MAX(0, nSecPwr + NGSecPwr);
                            nReadSkill = true;
                        }
                    }
                    else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        if (((THeroObject)(this)).m_MagicSkill_206 != null)
                        {
                            NGSecPwr = _Attack_GetNGPow(this, ((THeroObject)(this)).m_MagicSkill_206, nTwePwr);// ŭ֮����
                            nSecPwr = HUtil32._MAX(0, nSecPwr + NGSecPwr);
                            nReadSkill = true;
                        }
                    }
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = TargeTBaseObject;
                            }
                            if (IsProperTarget(TargeTBaseObject))
                            {
                                nDamage = 0;
                                nSePwr = nSecPwr;
                                if (((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && nReadSkill)
                                {
                                    NGSecPwr = 0;
                                    if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = _Attack_GetNGPow(TargeTBaseObject, ((TargeTBaseObject) as TPlayObject).m_MagicSkill_207, nTwePwr);// ��֮����
                                    }
                                    else if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = _Attack_GetNGPow(TargeTBaseObject, ((THeroObject)(TargeTBaseObject)).m_MagicSkill_207, nTwePwr);// ��֮����
                                    }
                                    nSePwr = HUtil32._MAX(0, nSePwr - NGSecPwr);
                                }
                                nDamage += TargeTBaseObject.GetHitStruckDamage(this, nSePwr);// ħ����,������ܼ����˺�
                                result = _Attack_DirectAttack(TargeTBaseObject, nDamage, false);
                                if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                {
                                    SetTargetCreat(TargeTBaseObject);//����Ӣ�۴�һ��Ŀ����ֻ���һ��Ŀ��
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // ����ն
        public bool _Attack_Attack_42(int nSecPwr, int m_n42kill)
        {
            bool result;
            int I;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            int nDamage;
            result = false;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                switch (m_n42kill)// ����ػ���Χ�зֱ�
                {
                    case 1: // ���,3��
                        GetDirectionBaseObjects(m_btDirection, 3, BaseObjectList);
                        break;
                    case 2:// ͬ������Ĺ� �ػ�,5��
                        GetDirectionBaseObjects(m_btDirection, 5, BaseObjectList);
                        break;
                }
                if (BaseObjectList.Count > 0)
                {
                    for (I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = TargeTBaseObject;
                            }
                            if (IsProperTarget(TargeTBaseObject))
                            {
                                nDamage = 0;
                                nDamage += TargeTBaseObject.GetHitStruckDamage(this, nSecPwr);// ħ����,������ܼ����˺�
                                result = _Attack_DirectAttack(TargeTBaseObject, nDamage, false);
                                if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                {
                                    SetTargetCreat(TargeTBaseObject);//����Ӣ�۴�һ��Ŀ����ֻ���һ��Ŀ��
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // ��Ӱ����
        public bool _Attack_Attack_43(TBaseObject Target, int nSecPwr)
        {
            bool result;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            result = false;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                //��Ӱ������Χ
                GetDirectionBaseObjects_42(m_btDirection, GameConfig.nMagicAttackRage_42, BaseObjectList);// ͬ������Ĺ� 
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = TargeTBaseObject;
                            }
                            if (IsProperTarget(TargeTBaseObject))
                            {
                                result = _Attack_DirectAttack(TargeTBaseObject, nSecPwr, false);
                                if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                {
                                    SetTargetCreat(TargeTBaseObject);//����Ӣ�۴�һ��Ŀ����ֻ���һ��Ŀ��
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // ��������
        public bool _Attack_Attack_69(TBaseObject Target, int nSecPwr)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                GetMapBaseObjects(m_PEnvir, m_nCurrX, m_nCurrY, 12, BaseObjectList);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = TargeTBaseObject;
                            }
                            result = _Attack_DirectAttack(TargeTBaseObject, nSecPwr, false);
                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                            {
                                SetTargetCreat(TargeTBaseObject);//����Ӣ�۴�һ��Ŀ����ֻ���һ��Ŀ��
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // Ѫ��һ��
        public bool _Attack_Attack_96(TBaseObject Target, int nSecPwr)
        {
            bool result = false;
            int I;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                GetMapBaseObjects(m_PEnvir, m_nCurrX, m_nCurrY, 12, BaseObjectList);
                if (BaseObjectList.Count > 0)
                {
                    for (I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = TargeTBaseObject;
                            }
                            result = _Attack_DirectAttack(TargeTBaseObject, nSecPwr, false);
                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                            {
                                SetTargetCreat(TargeTBaseObject);//����Ӣ�۴�һ��Ŀ����ֻ���һ��Ŀ��
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // ����ն
        public bool _Attack_Attack_82(TBaseObject Target, int nSecPwr)
        {
            bool result = false;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                GetMapBaseObjects(m_PEnvir, m_nCurrX, m_nCurrY, 3, BaseObjectList);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = TargeTBaseObject;
                            }
                            result = _Attack_DirectAttack(TargeTBaseObject, nSecPwr, false);
                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                            {
                                SetTargetCreat(TargeTBaseObject);//����Ӣ�۴�һ��Ŀ����ֻ���һ��Ŀ��
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        // ��ɨǧ��
        public bool _Attack_Attack_85(TBaseObject Target, int nSecPwr)
        {
            bool result;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            result = false;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                GetMapBaseObjects(m_PEnvir, m_nCurrX, m_nCurrY, 3, BaseObjectList);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                            {
                                m_ExpHitter = TargeTBaseObject;
                            }
                            result = _Attack_DirectAttack(TargeTBaseObject, nSecPwr, false);
                            if (m_btRaceServer != Grobal2.RC_HEROOBJECT)
                            {
                                SetTargetCreat(TargeTBaseObject);//����Ӣ�۴�һ��Ŀ����ֻ���һ��Ŀ��
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(BaseObjectList);
            }
            return result;
        }

        public bool _Attack_sub_4C1E5C_sub_4C1DC0(TBaseObject BaseObject, byte btDir, ref int nX, ref int nY, int nSecPwr)
        {
            bool result = false;
            if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, btDir, 1, ref nX, ref nY))
            {
                BaseObject = m_PEnvir.GetMovingObject(nX, nY, true);
                if ((nSecPwr > 0) && (BaseObject != null))
                {
                    result = _Attack_DirectAttack(BaseObject, nSecPwr, false);
                }
            }
            return result;
        }

        public void _Attack_sub_4C1E5C(TBaseObject BaseObject, int nSecPwr)
        {
            byte btDir = 0;
            int nX = 0;
            int nY = 0;
            btDir = m_btDirection;
            m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, btDir, 1, ref nX, ref nY);
            _Attack_sub_4C1E5C_sub_4C1DC0(BaseObject, btDir, ref nX, ref nY, nSecPwr);
            btDir = M2Share.sub_4B2F80(m_btDirection, 2);
            _Attack_sub_4C1E5C_sub_4C1DC0(BaseObject, btDir, ref nX, ref nY, nSecPwr);
            btDir = M2Share.sub_4B2F80(m_btDirection, 6);
            _Attack_sub_4C1E5C_sub_4C1DC0(BaseObject, btDir, ref nX, ref nY, nSecPwr);
        }

        /// <summary>
        /// ����Ŀ��
        /// </summary>
        /// <param name="wHitMode"></param>
        /// <param name="AttackTarget"></param>
        /// <returns></returns>
        public unsafe bool _Attack(ref ushort wHitMode, TBaseObject AttackTarget)
        {
            bool result;
            int nPower = 0;
            int nSecPwr;
            int NGSecPwr;
            int NGSecPwr1;
            int nWeaponDamage;
            bool bo21;
            int n20 = -1;
            int n98;
            byte nCheckCode;
            bool boisBaseObject = false;
            const string sExceptionMsg = "{�쳣} TBaseObject::_Attack Name:%s Code:%d";
            result = false;
            nCheckCode = 0;
            try
            {
                bo21 = false;
                nWeaponDamage = 0;
                if (AttackTarget != null)
                {
                    switch (wHitMode)
                    {
                        case 3:// Ŀ�����
                            // ��DB����㹥����
                            if (m_MagicPowerHitSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicPowerHitSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 4:
                            if (m_MagicErgumSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicErgumSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 5:
                            if (m_MagicBanwolSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicBanwolSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 7:
                            if (m_MagicFireSwordSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicFireSwordSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 8:
                            if (m_MagicCrsSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicCrsSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 9:
                            if (m_Magic42Skill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_Magic42Skill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 12:
                            if (m_Magic43Skill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_Magic43Skill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 13:
                            if (m_Magic74Skill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_Magic74Skill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 14:
                            if (m_MagicSkill_76 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_76) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 15:
                            if (m_MagicSkill_79 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_79) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 16:
                            if (m_MagicSkill_82 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_82) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 17:
                            if (m_MagicSkill_85 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_85) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 18:
                            if (m_MagicSkill_69 != null)
                            {
                                switch (m_btJob)// ��������  3ְҵ���㹥����
                                {
                                    case 0:
                                        nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_69) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                                        break;
                                    case 1:
                                        nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_69) + HUtil32.LoWord(m_WAbil.MC), ((short)(HUtil32.HiWord(m_WAbil.MC) - HUtil32.LoWord(m_WAbil.MC))));
                                        break;
                                    case 2:
                                        nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_69) + HUtil32.LoWord(m_WAbil.SC), ((short)(HUtil32.HiWord(m_WAbil.SC) - HUtil32.LoWord(m_WAbil.SC))));
                                        break;
                                }
                            }
                            break;
                        case 19:
                            if (m_MagicSkill_89 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_89) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 20:
                            if (m_MagicSkill_90 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_90) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 21:
                            if (m_MagicSkill_96 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_96) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        default:// Ѫ��һ��  ���㹥����
                            nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            break;
                    }
                    if ((wHitMode == 3) && m_boPowerHit)// ��ɱ
                    {
                        m_boPowerHit = false;
                        if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                        {
                            if (((this) as TPlayObject).m_MagicSkill_200 != null)// ��ŭ֮���ܲŽ���
                            {
                                NGSecPwr = _Attack_GetNGPow(this, ((this) as TPlayObject).m_MagicSkill_200, nPower);// ŭ֮��ɱ
                                if (AttackTarget != null)
                                {
                                    if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_201, nPower);// ��֮��ɱ
                                    }
                                    else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_201, nPower);  // ��֮��ɱ
                                    }
                                }
                                nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                            }
                        }
                        else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                        {
                            if (((THeroObject)(this)).m_MagicSkill_200 != null) // ��ŭ֮���ܲŽ���
                            {
                                NGSecPwr = _Attack_GetNGPow(this, ((THeroObject)(this)).m_MagicSkill_200, nPower);// ŭ֮��ɱ
                                if (AttackTarget != null)
                                {
                                    if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_201, nPower); // ��֮��ɱ
                                    }
                                    else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_201, nPower); // ��֮��ɱ
                                    }
                                }
                                nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                            }
                        }
                        nPower += m_nHitPlus;
                        bo21 = true;
                    }
                    if ((wHitMode == 7) && m_boFireHitSkill)
                    {
                        m_boFireHitSkill = false; // �һ𽣷�
                        m_dwLatestFireHitTick = HUtil32.GetTickCount();// ��ֹ˫�һ�ʱ�����󹥻���ʱ�俪ʼ����
                        if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            if ((m_MagicFireSwordSkill->btLevel == 4) && (((THeroObject)(this)).m_nLoyal >= GameConfig.nGotoLV4))// �����4���һ���
                            {
                                // ����������ͨħ������  20081109 �һ���ӹ�����
                                nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10));
                            }
                            else
                            {
                                nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)); // ��ͨ�һ��ɱ����
                            }
                        }
                        else
                        {
                            // ����Ӣ�������ҳ϶�
                            if ((m_MagicFireSwordSkill->btLevel == 4))// �����4���һ��� 
                            {
                                // ����������ͨħ������ �һ���ӹ�����
                                nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10));
                            }
                            else
                            {
                                nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10));// ��ͨ�һ��ɱ����
                            }
                        }
                        nPower = (int)HUtil32.Round((double)nPower * (GameConfig.nAttackRate_26 / 100));// ��������
                        if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                        {
                            if (((this) as TPlayObject).m_MagicSkill_204 != null)
                            {
                                NGSecPwr = _Attack_GetNGPow(this, ((this) as TPlayObject).m_MagicSkill_204, nPower);// ŭ֮�һ�
                                if (AttackTarget != null)
                                {
                                    if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_205, nPower);// ��֮�һ�
                                    }
                                    else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_205, nPower);// ��֮�һ�
                                    }
                                }
                                nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                            }
                        }
                        else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                        {
                            if (((THeroObject)(this)).m_MagicSkill_204 != null)
                            {
                                NGSecPwr = _Attack_GetNGPow(this, ((THeroObject)(this)).m_MagicSkill_204, nPower);// ŭ֮�һ�
                                if (AttackTarget != null)
                                {
                                    if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_205, nPower);// ��֮�һ�
                                    }
                                    else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_205, nPower);// ��֮�һ�
                                    }
                                }
                                nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                            }
                        }
                        bo21 = true;
                    }
                    if ((wHitMode == 13) && m_boDailySkill)// ���ս���
                    {
                        m_boDailySkill = false;
                        m_dwLatestDailyTick = HUtil32.GetTickCount();
                        nPower = Convert.ToInt32(nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)));
                        nPower = Convert.ToInt32(HUtil32.Round((double)nPower * (GameConfig.nAttackRate_74 / 100)));// ��������
                        bo21 = true;
                    }
                    if ((wHitMode == 14)) // ����ɱ
                    {
                        nPower = Convert.ToInt32(nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)));
                        n98 = M2Share.MagicManager.GetStormsHitRate(this, m_MagicSkill_76->MagicInfo.wMagicId);
                        if (n98 > 0)
                        {

                            SysMsg(string.Format(M2Share.StrStorm, new string[] { M2Share.MagicManager.GetNameByMagicID(m_MagicSkill_76->MagicInfo.wMagicId) }), TMsgColor.c_Green, TMsgType.t_Hint);
                            SendRefMsg(Grobal2.RM_STORMSRATE, 0, 0, 0, 0, "");
                            nPower = Convert.ToInt32(HUtil32.Round((double)nPower + nPower * (n98 / 100)));
                        }
                        bo21 = true;
                    }
                    if ((wHitMode == 15))  // ׷�Ĵ�
                    {
                        nPower = Convert.ToInt32(nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)));
                        n98 = M2Share.MagicManager.GetStormsHitRate(this, m_MagicSkill_79->MagicInfo.wMagicId);
                        if (n98 > 0)
                        {
                            SysMsg(string.Format(M2Share.StrStorm, new string[] { M2Share.MagicManager.GetNameByMagicID(m_MagicSkill_79->MagicInfo.wMagicId) }), TMsgColor.c_Green, TMsgType.t_Hint);
                            SendRefMsg(Grobal2.RM_STORMSRATE, 0, 0, 0, 0, "");
                            nPower = Convert.ToInt32(HUtil32.Round((double)nPower + nPower * (n98 / 100)));
                        }
                        bo21 = true;
                    }
                    if ((wHitMode == 16)) // ����ն
                    {
                        nPower = Convert.ToInt32(nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)));
                        n98 = M2Share.MagicManager.GetStormsHitRate(this, m_MagicSkill_82->MagicInfo.wMagicId);
                        if (n98 > 0)
                        {
                            SysMsg(string.Format(M2Share.StrStorm, new string[] { M2Share.MagicManager.GetNameByMagicID(m_MagicSkill_82->MagicInfo.wMagicId) }), TMsgColor.c_Green, TMsgType.t_Hint);
                            SendRefMsg(Grobal2.RM_STORMSRATE, 0, 0, 0, 0, "");
                            nPower = (int)HUtil32.Round((double)nPower + nPower * (n98 / 100));
                        }
                        bo21 = true;
                    }
                    if ((wHitMode == 17))// ��ɨǧ��
                    {
                        nPower = Convert.ToInt32(nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)));
                        n98 = M2Share.MagicManager.GetStormsHitRate(this, m_MagicSkill_85->MagicInfo.wMagicId);
                        if (n98 > 0)
                        {
                            SysMsg(string.Format(M2Share.StrStorm, new string[] { M2Share.MagicManager.GetNameByMagicID(m_MagicSkill_85->MagicInfo.wMagicId) }), TMsgColor.c_Green, TMsgType.t_Hint);
                            SendRefMsg(Grobal2.RM_STORMSRATE, 0, 0, 0, 0, "");
                            nPower = (int)HUtil32.Round((double)nPower + nPower * (n98 / 100));
                        }
                        bo21 = true;
                    }
                    if ((wHitMode == 18) && m_boYTPDHitSkill)  // ��������
                    {
                        m_boYTPDHitSkill = false;
                        m_dwLatestYTPDHitTick = HUtil32.GetTickCount();
                        nPower = Convert.ToInt32(nPower + HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)));
                        nPower = Convert.ToInt32(HUtil32.Round((double)nPower * (GameConfig.nAttackRate_74 / 100)));// ��������
                        bo21 = true;
                    }
                    if ((wHitMode == 21) && m_boXPYJHitSkill)// Ѫ��һ��
                    {
                        m_boXPYJHitSkill = false;
                        m_dwLatestXPYJHittick = HUtil32.GetTickCount();
                        nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10));
                        nPower = (int)HUtil32.Round((double)nPower * (GameConfig.nAttackRate_74 / 100));// ��������
                        bo21 = true;
                    }
                    if ((wHitMode == 9) && m_bo42kill)  // ����ն 
                    {
                        m_bo42kill = false;
                        m_dwLatest42Tick = HUtil32.GetTickCount();
                        switch (m_n42kill)
                        {
                            case 1:// ��ֹ˫����ն
                                nPower = (int)nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10));
                                break;
                            case 2: // ���ɱ����
                                nPower = (int)(nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10))) * GameConfig.n43KillAttackRate; // �ػ�ɱ����
                                break;
                        }
                        nPower = (int)HUtil32.Round((double)nPower * (int)(GameConfig.nAttackRate_43 / 100));// ����ն�������� 
                        bo21 = true;
                    }
                    if ((wHitMode == 12) && m_bo43kill) // ��Ӱ���� 
                    {
                        m_dwLatest43Tick = HUtil32.GetTickCount();
                        m_bo43kill = false;
                        nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10));// ɱ����
                        nPower = (int)HUtil32.Round((double)nPower * (GameConfig.nAttackRate_42 / 100));// ��Ӱ������������
                        bo21 = true;
                    }
                }
                else
                {
                    switch (wHitMode)
                    {
                        case 3:// û��Ŀ�� //��DB����㹥����
                            if (m_MagicPowerHitSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicPowerHitSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 4:
                            if (m_MagicErgumSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicErgumSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 5:
                            if (m_MagicBanwolSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicBanwolSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 7:
                            if (m_MagicFireSwordSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicFireSwordSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 8:
                            if (m_MagicCrsSkill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicCrsSkill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 9:
                            if (m_Magic42Skill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_Magic42Skill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 12:
                            if (m_Magic43Skill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_Magic43Skill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 13:
                            if (m_Magic74Skill != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_Magic74Skill) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 14:
                            if (m_MagicSkill_76 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_76) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 15:
                            if (m_MagicSkill_79 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_79) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 16:
                            if (m_MagicSkill_82 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_82) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 17:
                            if (m_MagicSkill_85 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_85) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 18:
                            if (m_MagicSkill_69 != null)
                            {
                                switch (m_btJob)
                                {
                                    case 0:// �������� ����3ְҵ�����㹥��
                                        nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_69) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                                        break;
                                    case 1:
                                        nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_69) + HUtil32.LoWord(m_WAbil.MC), ((short)(HUtil32.HiWord(m_WAbil.MC) - HUtil32.LoWord(m_WAbil.MC))));
                                        break;
                                    case 2:
                                        nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_69) + HUtil32.LoWord(m_WAbil.SC), ((short)(HUtil32.HiWord(m_WAbil.SC) - HUtil32.LoWord(m_WAbil.SC))));
                                        break;
                                }
                            }
                            break;
                        case 19:
                            if (m_MagicSkill_89 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_89) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 20:
                            if (m_MagicSkill_90 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_90) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        case 21:
                            if (m_MagicSkill_96 != null)
                            {
                                nPower = GetAttackPower(_Attack_MPow(m_MagicSkill_96) + HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            }
                            break;
                        default:// Ѫ��һ����������
                            nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)(HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))));
                            break;
                    }
                    if ((wHitMode == 3) && m_boPowerHit)
                    {
                        m_boPowerHit = false;
                        nPower += m_nHitPlus;
                        bo21 = true;
                    }
                    // ��ֹ���յ����һ�
                    if ((wHitMode == 7) && m_boFireHitSkill)
                    {
                        m_boFireHitSkill = false;
                        nPower = (int)HUtil32.Round((double)nPower * (GameConfig.nAttackRate_26 / 100));// �������� 
                        m_dwLatestFireHitTick = HUtil32.GetTickCount();// ��ֹ˫�һ�
                    }
                    if ((wHitMode == 13) && m_boDailySkill)  // ���ս���
                    {
                        m_boDailySkill = false;
                        m_dwLatestDailyTick = HUtil32.GetTickCount();
                        nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10)); // �޸�����Զ�̹�������ʦ �����������һ������
                        nPower = (int)HUtil32.Round((double)nPower * (GameConfig.nAttackRate_74 / 100));// ��������
                        bo21 = true;
                        // --------------------------------------------
                    }
                    if ((wHitMode == 9) && m_bo42kill)
                    {
                        // ����ն
                        m_bo42kill = false;
                        m_dwLatest42Tick = HUtil32.GetTickCount();
                        switch (m_n42kill)
                        {
                            case 1:
                                // ��ֹ˫����ն
                                // --------------------------------------------
                                //�޸Ŀ���Զ�̹�������ʦ �����������һ������
                                nPower = nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10));
                                break;
                            case 2:
                                // ���ɱ����
                                nPower = (nPower + (int)HUtil32.Round((double)nPower / 100 * (m_nHitDouble * 10))) * GameConfig.n43KillAttackRate;
                                break;
                            // �ػ�ɱ����
                        }
                        nPower = (int)HUtil32.Round((double)nPower * (GameConfig.nAttackRate_43 / 100));
                        // ����ն��������
                        bo21 = true;
                        // --------------------------------------------
                    }
                    if ((wHitMode == 12) && m_bo43kill)
                    {
                        // ��Ӱ����
                        m_dwLatest43Tick = HUtil32.GetTickCount();
                        m_bo43kill = false;
                    }
                }
                nCheckCode = 1;
                if ((wHitMode == 4))// ��ɱ
                {
                    nSecPwr = 0;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicErgumSkill != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if ((nSecPwr > 0) && (m_MagicErgumSkill != null))
                    {
                        nCheckCode = 100;
                        if (!_Attack_SwordLongAttack(nSecPwr, m_MagicErgumSkill->btLevel, AttackTarget, boisBaseObject) && GameConfig.boLimitSwordLong)
                        {
                            wHitMode = 0;
                        }
                        if (boisBaseObject && (AttackTarget.m_btRaceServer != 55))
                        {
                            nPower = 0;// ���λĿ��һ��,�����ظ���Ŀ���Ѫ
                        }
                    }
                }
                if ((wHitMode == 19))
                {
                    // �ļ���ɱ
                    nSecPwr = 0;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicSkill_89 != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if ((nSecPwr > 0) && (m_MagicSkill_89 != null))
                    {
                        nCheckCode = 100;
                        if (!_Attack_SwordLongAttack(nSecPwr, m_MagicSkill_89->btLevel, AttackTarget, boisBaseObject) && GameConfig.boLimitSwordLong)
                        {
                            wHitMode = 0;
                        }
                        if (boisBaseObject && (AttackTarget.m_btRaceServer != 55))
                        {
                            nPower = 0;  //���λĿ��һ��,�����ظ���Ŀ���Ѫ
                        }
                    }
                }
                nCheckCode = 2;
                if ((wHitMode == 5)) // ����
                {
                    nSecPwr = 0;
                    NGSecPwr1 = 0;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicBanwolSkill != null)
                        {
                            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                            {
                                if (((this) as TPlayObject).m_MagicSkill_202 != null)
                                {
                                    NGSecPwr = _Attack_GetNGPow(this, ((this) as TPlayObject).m_MagicSkill_202, nPower);// ŭ֮����
                                    if (AttackTarget != null)
                                    {
                                        if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            NGSecPwr1 = _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_203, nPower);// ��֮����
                                        }
                                        else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            NGSecPwr1 = _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_203, nPower);// ��֮����
                                        }
                                    }
                                    nPower += NGSecPwr;
                                }
                            }
                            else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                if (((THeroObject)(this)).m_MagicSkill_202 != null)
                                {
                                    NGSecPwr = _Attack_GetNGPow(this, ((THeroObject)(this)).m_MagicSkill_202, nPower);// ŭ֮����
                                    if ((AttackTarget != null))
                                    {
                                        if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                        {
                                            NGSecPwr1 = _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_203, nPower);// ��֮����
                                        }
                                        else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            NGSecPwr1 = _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_203, nPower);// ��֮����
                                        }
                                    }
                                    nPower += NGSecPwr;
                                }
                            }
                            nPower = HUtil32._MAX(0, nPower - NGSecPwr1);// ����Ŀ���Ѫֵ
                            nSecPwr = (int)HUtil32.Round((double)nPower * (m_MagicBanwolSkill->btLevel * 0.077 + 0.1538));// ��ΧĿ���Ѫֵ
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_SwordWideAttack(nSecPwr);
                    }
                }
                nCheckCode = 102;
                if ((wHitMode == 20))
                {
                    // Բ���䵶
                    nSecPwr = 0;
                    NGSecPwr1 = 0;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicSkill_90 != null)
                        {
                            nPower = HUtil32._MAX(0, nPower - NGSecPwr1);// ����Ŀ���Ѫֵ
                            nSecPwr = (int)HUtil32.Round((double)nPower * (m_MagicSkill_90->btLevel * 0.077 + 0.1538));// ��ΧĿ���Ѫֵ
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_YuanYueAttack(nSecPwr);
                    }
                }
                nCheckCode = 3;
                if ((wHitMode == 6))
                {
                    nSecPwr = 0;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_sub_4C1E5C(AttackTarget, nSecPwr);
                    }
                }
                nCheckCode = 32;
                if ((wHitMode == 8))
                {
                    // ���µ���
                    nSecPwr = 0;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER)
                        || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicCrsSkill != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_CrsWideAttack(nSecPwr);
                    }
                }
                if ((wHitMode == 9))
                {
                    // ����ն
                    nSecPwr = 0;
                    nCheckCode = 33;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER)
                        || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_Magic42Skill != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        nCheckCode = 101;
                        _Attack_Attack_42(nSecPwr, m_n42kill);
                    }
                }
                if ((wHitMode == 12))
                {
                    // ��Ӱ����
                    nSecPwr = 0;
                    nCheckCode = 12;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_Magic43Skill != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_Attack_43(AttackTarget, nSecPwr);
                    }
                }
                if ((wHitMode == 13))
                {
                    // ���ս���
                    nSecPwr = 0;
                    nCheckCode = 13;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        if (m_Magic74Skill != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_Attack_74(AttackTarget, nSecPwr);
                    }
                }
                if ((wHitMode == 16)) // ����ն
                {
                    nSecPwr = 0;
                    nCheckCode = 16;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicSkill_82 != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_Attack_82(AttackTarget, nSecPwr);
                    }
                }
                if ((wHitMode == 17))
                {
                    // ��ɨǧ��
                    nSecPwr = 0;
                    nCheckCode = 17;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicSkill_85 != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_Attack_85(AttackTarget, nSecPwr);
                    }
                }
                if ((wHitMode == 18))
                {
                    // ��������
                    nSecPwr = 0;
                    nCheckCode = 18;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicSkill_69 != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_Attack_69(AttackTarget, nSecPwr);
                    }
                }
                if ((wHitMode == 21))
                {
                    // Ѫ��һ��
                    nSecPwr = 0;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        // ���ӷ���ħ������
                        if (m_MagicSkill_96 != null)
                        {
                            nSecPwr = nPower;
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_Attack_96(AttackTarget, nSecPwr);
                    }
                }
                if (AttackTarget == null)
                {
                    return result;
                }
                nCheckCode = 4;
                if (IsProperTarget(AttackTarget))
                {
                    if ((HUtil32.Random(AttackTarget.m_btSpeedPoint) >= m_btHitPoint))
                    {
                        nPower = 0;
                    }
                }
                else
                {
                    nPower = 0;
                }
                nCheckCode = 5;
                if (nPower > 0)
                {
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        if (((this) as TPlayObject).m_MagicSkill_236 != null)
                        {
                            NGSecPwr = _Attack_GetNGPow(this, ((this) as TPlayObject).m_MagicSkill_236, nPower);// ŭ֮�ڹ�����
                            if (AttackTarget != null)
                            {
                                if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_237, nPower);// ��֮�ڹ�����
                                }
                                else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_237, nPower);// ��֮�ڹ�����
                                }
                            }
                            nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                        }
                    }
                    else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        if (((THeroObject)(this)).m_MagicSkill_236 != null)
                        {
                            NGSecPwr = _Attack_GetNGPow(this, ((THeroObject)(this)).m_MagicSkill_236, nPower);// ŭ֮�ڹ�����
                            if (AttackTarget != null)
                            {
                                if (AttackTarget.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((AttackTarget) as TPlayObject).m_MagicSkill_237, nPower);// ��֮�ڹ�����
                                }
                                else if (AttackTarget.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    NGSecPwr = NGSecPwr - _Attack_GetNGPow(AttackTarget, ((THeroObject)(AttackTarget)).m_MagicSkill_237, nPower);// ��֮�ڹ�����
                                }
                            }
                            nPower = HUtil32._MAX(0, nPower + NGSecPwr);
                        }
                    }
                    nPower = AttackTarget.GetHitStruckDamage(this, nPower);
                    nWeaponDamage = (HUtil32.Random(5) + 2) - m_AddAbil.btWeaponStrong;
                }
                nCheckCode = 60;
                if (nPower > 0)
                {
                    nCheckCode = 61;
                    if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT) || (m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                    {
                        if ((wHitMode != 9) && (wHitMode != 13) && (wHitMode != 12))// ������Ӱ����
                        {
                            if ((AttackTarget != null))
                            {
                                AttackTarget.StruckDamage(nPower);// ��װ���־�
                                AttackTarget.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nPower, AttackTarget.m_WAbil.HP, AttackTarget.m_WAbil.MaxHP, this.ToInt(), "", 200);
                            }
                        }
                    }
                    else
                    {
                        nCheckCode = 200;
                        if ((AttackTarget != null))
                        {
                            nCheckCode = 201;
                            AttackTarget.StruckDamage(nPower);// ��װ���־�
                            nCheckCode = 202;
                            AttackTarget.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nPower, AttackTarget.m_WAbil.HP, AttackTarget.m_WAbil.MaxHP, this.ToInt(), "", 200);
                        }
                    }
                    if ((AttackTarget != null))
                    {
                        if ((!AttackTarget.m_boUnParalysis) && m_boParalysis && (HUtil32.Random(AttackTarget.m_btAntiPoison + GameConfig.nAttackPosionRate) == 0))
                        {
                            nCheckCode = 64;
                            if ((m_btRaceServer == Grobal2.RC_HEROOBJECT) && (m_btJob == 0)) // Ӣ�۴�ɱλ����Ŀ��
                            {
                                if ((Math.Abs(AttackTarget.m_nCurrX - m_nCurrX) == 1) || (Math.Abs(AttackTarget.m_nCurrY - m_nCurrY) == 1))
                                {
                                    AttackTarget.MakePosion(Grobal2.POISON_STONE, GameConfig.nAttackPosionTime, 0);// ���
                                }
                            }
                            else
                            {
                                AttackTarget.MakePosion(Grobal2.POISON_STONE, GameConfig.nAttackPosionTime, 0);// ���
                            }
                        }
                    }
                    nCheckCode = 65;// ��ħ����Ѫ
                    if (m_nHongMoSuite > 0)
                    {
                        m_db3B0 = nPower / 1.0E2 * m_nHongMoSuite;
                        if (m_db3B0 >= 2.0)
                        {
                            n20 = Convert.ToInt32(m_db3B0);
                            m_db3B0 = n20;
                            DamageHealth(-n20);
                        }
                    }
                    nCheckCode = 66;
                    if ((m_MagicOneSwordSkill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicOneSwordSkill->btLevel < 3) && (m_MagicOneSwordSkill->MagicInfo.TrainLevel[m_MagicOneSwordSkill->btLevel] <= m_Abil.Level))
                    {
                        nCheckCode = 67;
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicOneSwordSkill, HUtil32.Random(3) + 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicOneSwordSkill))
                            {
                                nCheckCode = 68;
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicOneSwordSkill->MagicInfo.wMagicId, m_MagicOneSwordSkill->btLevel, m_MagicOneSwordSkill->nTranPoint, "", 3000);
                                RecalcAbilitys();// ����
                                CompareSuitItem(false);// ��װ
                                SendMsg(this, Grobal2.RM_SUBABILITY, 0, 0, 0, 0, "");// ����
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicOneSwordSkill, HUtil32.Random(3) + 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicOneSwordSkill))
                            {
                                nCheckCode = 69;
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicOneSwordSkill->MagicInfo.wMagicId, m_MagicOneSwordSkill->btLevel, m_MagicOneSwordSkill->nTranPoint, "", 3000);
                                ((THeroObject)(this)).RecalcAbilitys();
                                CompareSuitItem(false);//��װ
                                ((THeroObject)(this)).SendMsg(this, Grobal2.RM_SUBABILITY, 0, 0, 0, 0, "");
                            }
                        }
                        nCheckCode = 70;
                    }// ��ɱ
                    if (bo21 && (m_MagicPowerHitSkill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicPowerHitSkill->btLevel < 3) && (m_MagicPowerHitSkill->MagicInfo.TrainLevel[m_MagicPowerHitSkill->btLevel] <= m_Abil.Level))
                    {
                        nCheckCode = 71;
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicPowerHitSkill, HUtil32.Random(3) + 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicPowerHitSkill))
                            {
                                nCheckCode = 72;
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicPowerHitSkill->MagicInfo.wMagicId, m_MagicPowerHitSkill->btLevel, m_MagicPowerHitSkill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicPowerHitSkill, HUtil32.Random(3) + 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicPowerHitSkill))
                            {
                                nCheckCode = 73;
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicPowerHitSkill->MagicInfo.wMagicId, m_MagicPowerHitSkill->btLevel, m_MagicPowerHitSkill->nTranPoint, "", 3000);
                            }
                        }
                        nCheckCode = 74;
                    }
                    nCheckCode = 75;// ��ɱ
                    if ((wHitMode == 4) && (m_MagicErgumSkill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicErgumSkill->btLevel < 3) && (m_MagicErgumSkill->MagicInfo.TrainLevel[m_MagicErgumSkill->btLevel] <= m_Abil.Level))
                    {
                        nCheckCode = 76;
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicErgumSkill, HUtil32.Random(3) + 1);// ��1-3�� 20080924
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicErgumSkill))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicErgumSkill->MagicInfo.wMagicId, m_MagicErgumSkill->btLevel, m_MagicErgumSkill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicErgumSkill, HUtil32.Random(3) + 1);// ��1-3�� 20080924
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicErgumSkill))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicErgumSkill->MagicInfo.wMagicId, m_MagicErgumSkill->btLevel, m_MagicErgumSkill->nTranPoint, "", 3000);
                            }
                        }
                    }
                    nCheckCode = 77;// �����䵶
                    if ((wHitMode == 5) && (m_MagicBanwolSkill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicBanwolSkill->btLevel < 3) && (m_MagicBanwolSkill->MagicInfo.TrainLevel[m_MagicBanwolSkill->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicBanwolSkill, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicBanwolSkill))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicBanwolSkill->MagicInfo.wMagicId, m_MagicBanwolSkill->btLevel, m_MagicBanwolSkill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicBanwolSkill, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicBanwolSkill))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicBanwolSkill->MagicInfo.wMagicId, m_MagicBanwolSkill->btLevel, m_MagicBanwolSkill->nTranPoint, "", 3000);
                            }
                        }
                    }
                    nCheckCode = 8;// �һ𽣷���������
                    if ((wHitMode == 7) && (m_MagicFireSwordSkill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicFireSwordSkill->btLevel < 3) && (m_MagicFireSwordSkill->MagicInfo.TrainLevel[m_MagicFireSwordSkill->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicFireSwordSkill, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicFireSwordSkill))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicFireSwordSkill->MagicInfo.wMagicId, m_MagicFireSwordSkill->btLevel, m_MagicFireSwordSkill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicFireSwordSkill, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicFireSwordSkill))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicFireSwordSkill->MagicInfo.wMagicId, m_MagicFireSwordSkill->btLevel, m_MagicFireSwordSkill->nTranPoint, "", 3000);
                            }
                        }
                    }// ���ս�����������
                    if ((wHitMode == 13) && (m_Magic74Skill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_Magic74Skill->btLevel < 3) && (m_Magic74Skill->MagicInfo.TrainLevel[m_Magic74Skill->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_Magic74Skill, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_Magic74Skill))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_Magic74Skill->MagicInfo.wMagicId, m_Magic74Skill->btLevel, m_Magic74Skill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_Magic74Skill, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_Magic74Skill))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_Magic74Skill->MagicInfo.wMagicId, m_Magic74Skill->btLevel, m_Magic74Skill->nTranPoint, "", 3000);
                            }
                        }
                    }// ����ն��������
                    if ((wHitMode == 9) && (m_Magic42Skill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_Magic42Skill->btLevel < 3) && (m_Magic42Skill->MagicInfo.TrainLevel[m_Magic42Skill->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_Magic42Skill, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_Magic42Skill))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_Magic42Skill->MagicInfo.wMagicId, m_Magic42Skill->btLevel, m_Magic42Skill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_Magic42Skill, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_Magic42Skill))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_Magic42Skill->MagicInfo.wMagicId, m_Magic42Skill->btLevel, m_Magic42Skill->nTranPoint, "", 3000);
                            }
                        }
                    }// ��Ӱ������������
                    if ((wHitMode == 12) && (m_Magic43Skill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_Magic43Skill->btLevel < 3) && (m_Magic43Skill->MagicInfo.TrainLevel[m_Magic43Skill->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_Magic43Skill, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_Magic43Skill))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_Magic43Skill->MagicInfo.wMagicId, m_Magic43Skill->btLevel, m_Magic43Skill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_Magic43Skill, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_Magic43Skill))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_Magic43Skill->MagicInfo.wMagicId, m_Magic43Skill->btLevel, m_Magic43Skill->nTranPoint, "", 3000);
                            }
                        }
                    }// �����䵶
                    if ((wHitMode == 8) && (m_MagicCrsSkill != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicCrsSkill->btLevel < 3) && (m_MagicCrsSkill->MagicInfo.TrainLevel[m_MagicCrsSkill->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicCrsSkill, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicCrsSkill))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicCrsSkill->MagicInfo.wMagicId, m_MagicCrsSkill->btLevel, m_MagicCrsSkill->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicCrsSkill, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicCrsSkill))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicCrsSkill->MagicInfo.wMagicId, m_MagicCrsSkill->btLevel, m_MagicCrsSkill->nTranPoint, "", 3000);
                            }
                        }
                    }// ����ɱ ħ������
                    if ((wHitMode == 14) && (m_MagicSkill_76 != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicSkill_76->btLevel < 3) && (m_MagicSkill_76->MagicInfo.TrainLevel[m_MagicSkill_76->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicSkill_76, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicSkill_76))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicSkill_76->MagicInfo.wMagicId, m_MagicSkill_76->btLevel, m_MagicSkill_76->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicSkill_76, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicSkill_76))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicSkill_76->MagicInfo.wMagicId, m_MagicSkill_76->btLevel, m_MagicSkill_76->nTranPoint, "", 3000);
                            }
                        }
                    }// ׷�Ĵ� ħ������
                    if ((wHitMode == 15) && (m_MagicSkill_79 != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicSkill_79->btLevel < 3) && (m_MagicSkill_79->MagicInfo.TrainLevel[m_MagicSkill_79->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicSkill_79, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicSkill_79))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicSkill_79->MagicInfo.wMagicId, m_MagicSkill_79->btLevel, m_MagicSkill_79->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicSkill_79, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicSkill_79))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicSkill_79->MagicInfo.wMagicId, m_MagicSkill_79->btLevel, m_MagicSkill_79->nTranPoint, "", 3000);
                            }
                        }
                    }// ����ն ħ������
                    if ((wHitMode == 16) && (m_MagicSkill_82 != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicSkill_82->btLevel < 3) && (m_MagicSkill_82->MagicInfo.TrainLevel[m_MagicSkill_82->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicSkill_82, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicSkill_82))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicSkill_82->MagicInfo.wMagicId, m_MagicSkill_82->btLevel, m_MagicSkill_82->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicSkill_82, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicSkill_82))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicSkill_82->MagicInfo.wMagicId, m_MagicSkill_82->btLevel, m_MagicSkill_82->nTranPoint, "", 3000);
                            }
                        }
                    }// ��ɨǧ�� ħ������
                    if ((wHitMode == 17) && (m_MagicSkill_85 != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicSkill_85->btLevel < 3) && (m_MagicSkill_85->MagicInfo.TrainLevel[m_MagicSkill_85->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicSkill_85, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicSkill_85))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicSkill_85->MagicInfo.wMagicId, m_MagicSkill_85->btLevel, m_MagicSkill_85->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicSkill_85, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicSkill_85))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicSkill_85->MagicInfo.wMagicId, m_MagicSkill_85->btLevel, m_MagicSkill_85->nTranPoint, "", 3000);
                            }
                        }
                    }// �������� ħ������
                    if ((wHitMode == 18) && (m_MagicSkill_69 != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicSkill_69->btLevel < 3) && (m_MagicSkill_69->MagicInfo.TrainLevel[m_MagicSkill_69->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicSkill_69, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicSkill_69))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicSkill_69->MagicInfo.wMagicId, m_MagicSkill_69->btLevel, m_MagicSkill_69->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicSkill_69, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicSkill_69))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicSkill_69->MagicInfo.wMagicId, m_MagicSkill_69->btLevel, m_MagicSkill_69->nTranPoint, "", 3000);
                            }
                        }
                    }// Ѫ��һ�� ħ������
                    if ((wHitMode == 21) && (m_MagicSkill_96 != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicSkill_96->btLevel < 3) && (m_MagicSkill_96->MagicInfo.TrainLevel[m_MagicSkill_96->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicSkill_96, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicSkill_96))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicSkill_96->MagicInfo.wMagicId, m_MagicSkill_96->btLevel, m_MagicSkill_96->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicSkill_96, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicSkill_96))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicSkill_96->MagicInfo.wMagicId, m_MagicSkill_96->btLevel, m_MagicSkill_96->nTranPoint, "", 3000);
                            }
                        }
                    }// Բ���䵶 ħ������
                    if ((wHitMode == 20) && (m_MagicSkill_90 != null) && ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (m_btRaceServer == Grobal2.RC_HEROOBJECT)) && (m_MagicSkill_90->btLevel < 3) && (m_MagicSkill_90->MagicInfo.TrainLevel[m_MagicSkill_90->btLevel] <= m_Abil.Level))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            ((this) as TPlayObject).TrainSkill(m_MagicSkill_90, 1);
                            if (!((this) as TPlayObject).CheckMagicLevelup(m_MagicSkill_90))
                            {
                                SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicSkill_90->MagicInfo.wMagicId, m_MagicSkill_90->btLevel, m_MagicSkill_90->nTranPoint, "", 3000);
                            }
                        }
                        else
                        {
                            ((THeroObject)(this)).TrainSkill(m_MagicSkill_90, 1);
                            if (!((THeroObject)(this)).CheckMagicLevelup(m_MagicSkill_90))
                            {
                                ((THeroObject)(this)).SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, m_MagicSkill_90->MagicInfo.wMagicId, m_MagicSkill_90->btLevel, m_MagicSkill_90->nTranPoint, "", 3000);
                            }
                        }
                    }
                    result = true;
                }
                nCheckCode = 9;
                if ((nWeaponDamage > 0) && (m_UseItems[TPosition.U_WEAPON]->wIndex > 0))
                {
                    DoDamageWeapon(nWeaponDamage);
                }
                if ((AttackTarget != null) && (AttackTarget.m_btRaceServer != Grobal2.RC_PLAYOBJECT))
                {
                    switch (wHitMode)
                    {
                        case 9:
                        case 13:
                        case 12:
                        case 16:
                        case 17:
                        case 18:
                            break;
                        default://�޸� ����,���ս���,���ط���Ϣ ������Ӱ����
                            AttackTarget.SendMsg(AttackTarget, Grobal2.RM_STRUCK, nPower, AttackTarget.m_WAbil.HP, AttackTarget.m_WAbil.MaxHP, this.ToInt(), "");
                            break;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, m_sCharName, nCheckCode));
            }
            return result;
        }

        /// <summary>
        /// ���͹�����Ϣ
        /// </summary>
        /// <param name="wIdent"></param>
        /// <param name="btDir"></param>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        public void SendAttackMsg(ushort wIdent, byte btDir, int nX, int nY)
        {
            SendRefMsg(wIdent, btDir, nX, nY, 0, "");
        }

        /// <summary>
        /// ȡ������ٵ���
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="nDamage"></param>
        /// <returns></returns>
        public int GetHitStruckDamage(TBaseObject Target, int nDamage)
        {
            int result = 0;
            int n14;
            int n15 = 0;
            try
            {
                if (Target != null) // �ڹ�����,������ͨ������
                {
                    try
                    {
                        if (!Target.m_boDeath)
                        {
                            if (Target.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                if (((Target) as TPlayObject).m_boTrainingNG && (((Target) as TPlayObject).m_Skill69NH > 0))
                                {
                                    n15 = (((Target) as TPlayObject).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                                }
                            }
                            else if (Target.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                if (((THeroObject)(Target)).m_boTrainingNG && (((THeroObject)(Target)).m_Skill69NH > 0))
                                {
                                    n15 = (((THeroObject)(Target)).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                                }
                            }
                        }
                    }
                    catch
                    {
                        M2Share.MainOutMessage("{�쳣} TBaseObject.GetHitStruckDamage1");
                    }
                }
                nDamage += n15;
                n14 = HUtil32.LoWord(m_WAbil.AC) + HUtil32.Random(((short)HUtil32.HiWord(m_WAbil.AC) - HUtil32.LoWord(m_WAbil.AC)) + 1);
                if (n14 < 0)
                {
                    n14 = 0; // ��ֹΪ����
                }
                nDamage = HUtil32._MAX(0, nDamage - n14);
                if ((m_btLifeAttrib == Grobal2.LA_UNDEAD) && (Target != null))
                {
                    nDamage += Target.m_AddAbil.bt1DF;
                }
                if ((nDamage > 0))
                {
                    if ((HUtil32.Random(GameConfig.nProtectionBadRate) == 0) && m_boProtectionDefence)// ������ܱ����ƻ���
                    {
                        m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                    }
                    // ��ɱ,����ն���һ� �������
                    else if ((m_LastHiter != null) && m_boProtectionDefence)  // ��ɱ
                    {
                        if (GameConfig.RushkungBadProtection && m_LastHiter.m_boUseThrusting)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                        }
                        // �һ�
                        else if (GameConfig.FirehitBadProtection && m_LastHiter.m_boFireHitSkill)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                        }
                        // ����
                        else if (GameConfig.TwnhitBadProtection && m_LastHiter.m_bo42kill)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                        }
                    }
                    if (m_boProtectionDefence)// �������  ÿ������3%����Ч����
                    {
                        if (HUtil32.Random(100) <= (GameConfig.nProtectionOKRate + m_boProtectionDefenceLevel * 3))  // ��Ч����
                        {
                            if (GameConfig.nProtectionDefenceTime != 0)// �ʱ�䲻Ϊ0
                            {
                                if (HUtil32.GetTickCount() - m_dwStatusArrTick[Grobal2.STATE_ProtectionDEFENCE] < GameConfig.nProtectionDefenceTime) // �ʱ��
                                {
                                    nDamage = (int)HUtil32.Round((double)nDamage * (1 - GameConfig.nProtectionRate / 100), 1);// ���ͻ������ �ܹ��� ����
                                    if (GameConfig.boShowProtectionEnv)
                                    {
                                        SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_PROTECTION_STRUCK, 0, 0, 0, "");
                                    }
                                }
                                else
                                {
                                    m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                                }
                            }
                            else
                            {
                                nDamage = (int)HUtil32.Round((double)nDamage * (1 - GameConfig.nProtectionRate / 100));
                                if (GameConfig.boShowProtectionEnv)
                                {
                                    SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_PROTECTION_STRUCK, 0, 0, 0, "");  // ���ͻ������ �ܹ��� ����
                                }
                            }
                        }
                        DamageProtectionDefence(nDamage);// ����ʹ��ʱ��
                    }
                    if (m_boAbilMagBubbleDefence)
                    {
                        // ħ���� 0-15% 1-30% 2-45% 3-60% 4-75%
                        if (m_btMagBubbleDefenceLevel < 4)
                        {
                            nDamage = (int)HUtil32.Round((double)nDamage * ((100 - (m_btMagBubbleDefenceLevel + 1) * GameConfig.nOrdinarySkill66Rate) / 100));
                        }
                        else
                        {
                            nDamage = (int)HUtil32.Round((double)nDamage * ((100 - GameConfig.nSkill66Rate) / 100));// �ļ���
                        }
                        DamageBubbleDefence(nDamage);// ���ٴ������
                    }
                    if ((nDamage > 0)) // �ڹ�����,������ͨ�����˺�
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            if (((this) as TPlayObject).m_boTrainingNG && (((this) as TPlayObject).m_Skill69NH > 0))
                            {
                                nDamage = HUtil32._MAX(0, nDamage - ((((this) as TPlayObject).m_NGLevel / GameConfig.nNGLevelDamage) + 5));// �ĳ�8������1�������
                                ((this) as TPlayObject).m_Skill69NH = (ushort)HUtil32._MAX(0, ((this) as TPlayObject).m_Skill69NH - GameConfig.nHitStruckDecNH);
                                ((this) as TPlayObject).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((this) as TPlayObject).m_Skill69NH, ((this) as TPlayObject).m_Skill69MaxNH, 0, "");
                            }
                        }
                        else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            if (((THeroObject)(this)).m_boTrainingNG && (((THeroObject)(this)).m_Skill69NH > 0))
                            {
                                nDamage = HUtil32._MAX(0, nDamage - ((((THeroObject)(this)).m_NGLevel / GameConfig.nNGLevelDamage) + 5));// �ĳ�8������1�������
                                ((THeroObject)(this)).m_Skill69NH = (ushort)HUtil32._MAX(0, ((THeroObject)(this)).m_Skill69NH - GameConfig.nHitStruckDecNH);
                                ((THeroObject)(this)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(this)).m_Skill69NH, ((THeroObject)(this)).m_Skill69MaxNH, 0, "");
                            }
                        }
                    }
                }
                result = ItemStruckDamage(nDamage);// �½�ָ������ֵ
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.GetHitStruckDamage");
            }
            return result;
        }

        /// <summary>
        /// ȡħ������,���ٵ���
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nDamage"></param>
        /// <returns></returns>
        public int GetMagStruckDamage(TBaseObject BaseObject, int nDamage)
        {
            int result = 0;
            int n14;
            int n15;
            byte nCode = 0;
            try
            {
                nCode = 0;
                n15 = 0;// �ڹ�����,������ͨ������
                if (BaseObject != null)
                {
                    try
                    {
                        nCode = 18;
                        if (!BaseObject.m_boDeath)
                        {
                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                nCode = 16;
                                if (((BaseObject) as TPlayObject).m_boTrainingNG)
                                {
                                    nCode = 17;
                                    if ((((BaseObject) as TPlayObject).m_Skill69NH > 0))
                                    {
                                        nCode = 19;
                                        n15 = (((BaseObject) as TPlayObject).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                                    }
                                }
                            }
                            else if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                nCode = 3;
                                if (((THeroObject)(BaseObject)).m_boTrainingNG)
                                {
                                    if ((((THeroObject)(BaseObject)).m_Skill69NH > 0))
                                    {
                                        nCode = 4;
                                        n15 = (((THeroObject)(BaseObject)).m_NGLevel / GameConfig.nNGLevelDamage) + 5;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        M2Share.MainOutMessage("{�쳣} TBaseObject.GetMagStruckDamage1 Code:" + nCode);
                    }
                }
                nDamage += n15;
                nCode = 5;
                n14 = HUtil32.LoWord(m_WAbil.MAC) + HUtil32.Random(((short)HUtil32.HiWord(m_WAbil.MAC) - HUtil32.LoWord(m_WAbil.MAC)) + 1);
                if (n14 < 0)
                {
                    n14 = 0;// ��ֹΪ����
                }
                nDamage = HUtil32._MAX(0, nDamage - n14);
                if ((m_btLifeAttrib == Grobal2.LA_UNDEAD) && (BaseObject != null))
                {
                    nDamage += m_AddAbil.bt1DF;
                }
                nCode = 6;
                if ((nDamage > 0))
                {
                    if ((HUtil32.Random(GameConfig.nProtectionBadRate) == 0) && m_boProtectionDefence)// ������ܱ����ƻ���
                    {
                        m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                    }
                    // ��ɱ,����ն���һ� ������� 
                    else if ((m_LastHiter != null) && m_boProtectionDefence)
                    {
                        // ��ɱ
                        if (GameConfig.RushkungBadProtection && m_LastHiter.m_boUseThrusting)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                        }
                        // �һ�
                        else if (GameConfig.FirehitBadProtection && m_LastHiter.m_boFireHitSkill)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                        }
                        // ����
                        else if (GameConfig.TwnhitBadProtection && m_LastHiter.m_bo42kill)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                        }
                    }
                    nCode = 7;
                    if (m_boProtectionDefence) // �������  ÿ������3%����Ч����
                    {
                        if (HUtil32.Random(100) <= (GameConfig.nProtectionOKRate + m_boProtectionDefenceLevel * 3))// ��Ч���� 
                        {
                            if (GameConfig.nProtectionDefenceTime != 0) // �ʱ�䲻Ϊ0
                            {
                                if (HUtil32.GetTickCount() - m_dwStatusArrTick[Grobal2.STATE_ProtectionDEFENCE] < GameConfig.nProtectionDefenceTime)
                                {
                                    // �ʱ��
                                    nDamage = (int)HUtil32.Round((double)nDamage * (1 - GameConfig.nProtectionRate / 100));// ���ͻ������ �ܹ��� ����
                                    if (GameConfig.boShowProtectionEnv)
                                    {
                                        SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_PROTECTION_STRUCK, 0, 0, 0, "");
                                    }
                                }
                                else
                                {
                                    m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
                                }
                            }
                            else
                            {
                                nDamage = (int)HUtil32.Round((double)nDamage * (1 - GameConfig.nProtectionRate / 100));// ���ͻ������ �ܹ��� ����
                                if (GameConfig.boShowProtectionEnv)
                                {
                                    SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_PROTECTION_STRUCK, 0, 0, 0, "");
                                }
                            }
                        }
                        DamageProtectionDefence(nDamage);// ����ʹ��ʱ��
                    }
                    nCode = 8;
                    if (m_boAbilMagBubbleDefence)// ħ����  0-15% 1-30% 2-45% 3-60% 4-75%
                    {
                        if (m_btMagBubbleDefenceLevel < 4) // �ļ��ܿ����Լ����ñ���
                        {
                            // 15
                            nDamage = (int)HUtil32.Round((double)nDamage * ((100 - (m_btMagBubbleDefenceLevel + 1) * GameConfig.nOrdinarySkill66Rate) / 100));
                        }
                        else
                        {
                            nDamage = (int)HUtil32.Round((double)nDamage * ((100 - GameConfig.nSkill66Rate) / 100));// �ļ���
                        }
                        DamageBubbleDefence(nDamage);// ���ٶܵ�ʹ��ʱ��
                    }
                    nCode = 9;
                    if ((nDamage > 0)) // �ڹ�����,������ͨ�����˺�
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            nCode = 10;
                            if (((this) as TPlayObject).m_boTrainingNG && (((this) as TPlayObject).m_Skill69NH > 0))
                            {
                                nCode = 11;
                                nDamage = HUtil32._MAX(0, nDamage - ((((this) as TPlayObject).m_NGLevel / GameConfig.nNGLevelDamage) + 5));//8������1�������
                                //((this) as TPlayObject).m_Skill69NH = HUtil32._MAX(0, ((this) as TPlayObject).m_Skill69NH - GameConfig.nHitStruckDecNH);
                                ((this) as TPlayObject).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((this) as TPlayObject).m_Skill69NH, ((this) as TPlayObject).m_Skill69MaxNH, 0, "");
                            }
                        }
                        else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            nCode = 12;
                            if (((THeroObject)(this)).m_boTrainingNG && (((THeroObject)(this)).m_Skill69NH > 0))
                            {
                                nCode = 13;
                                nDamage = HUtil32._MAX(0, nDamage - ((((THeroObject)(this)).m_NGLevel / GameConfig.nNGLevelDamage) + 5));//8������1�������
                                // ((THeroObject)(this)).m_Skill69NH = HUtil32._MAX(0, ((THeroObject)(this)).m_Skill69NH - GameConfig.nHitStruckDecNH);
                                ((THeroObject)(this)).SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, ((THeroObject)(this)).m_Skill69NH, ((THeroObject)(this)).m_Skill69MaxNH, 0, "");
                            }
                        }
                    }
                }
                nCode = 14;
                result = ItemStruckDamage(nDamage);// ���˼�����ֵ
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.GetMagStruckDamage Code:" + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// �ܹ���,������װ���ĳ־�
        /// </summary>
        /// <param name="nDamage"></param>
        public unsafe virtual void StruckDamage(int nDamage)
        {
            int nDam;
            int nDura;
            int nOldDura;
            TPlayObject PlayObject;
            TStdItem* StdItem;
            bool bo19;
            byte nCode;
            nCode = 0;
            try
            {
                if (nDamage <= 0)
                {
                    return;
                }
                nDam = HUtil32.Random(10) + 5;
                nCode = 1;
                if (m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] > 0)
                {
                    nDam = (int)HUtil32.Round((double)nDam * (GameConfig.nPosionDamagarmor / 10));// 1.2
                    nDamage = (int)HUtil32.Round((double)nDamage * (GameConfig.nPosionDamagarmor / 10));// 1.2
                }
                bo19 = false;
                nCode = 2;
                if (m_UseItems[TPosition.U_DRESS]->wIndex > 0)
                {
                    nDura = m_UseItems[TPosition.U_DRESS]->Dura;
                    nOldDura = (int)HUtil32.Round((double)nDura / 1000);
                    nDura -= nDam;
                    if (nDura <= 0)
                    {
                        nCode = 3;
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            PlayObject = ((this) as TPlayObject);
                            nCode = 4;
                            PlayObject.SendDelItems(m_UseItems[TPosition.U_DRESS]);
                            nCode = 5;
                            StdItem = UserEngine.GetStdItem(m_UseItems[TPosition.U_DRESS]->wIndex);
                            if (StdItem != null)
                            {
                                nCode = 6;
                                if (StdItem->NeedIdentify == 1)
                                {
                                    M2Share.AddGameDataLog("3" + "\09" + m_sMapName + "\09" + (m_nCurrX).ToString() + "\09" + (m_nCurrY).ToString()
                                        + "\09" + m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + (m_UseItems[TPosition.U_DRESS]->MakeIndex).ToString() + "\09"
                                        + "(" + (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" +
                                        (HUtil32.LoWord(StdItem->MC)).ToString()
                                        + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" +
                                        (HUtil32.HiWord(StdItem->SC)).ToString()
                                        + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")"
                                        + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString()
                                        + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")" + (m_UseItems[TPosition.U_DRESS]->btValue[0]).ToString() + "/"
                                        + (m_UseItems[TPosition.U_DRESS]->btValue[1]).ToString() + "/" + (m_UseItems[TPosition.U_DRESS]->btValue[2]).ToString() + "/"
                                        + (m_UseItems[TPosition.U_DRESS]->btValue[3]).ToString() + "/" + (m_UseItems[TPosition.U_DRESS]->btValue[4]).ToString() + "/"
                                        + (m_UseItems[TPosition.U_DRESS]->btValue[5]).ToString() + "/" + (m_UseItems[TPosition.U_DRESS]->btValue[6]).ToString() + "/"
                                        + (m_UseItems[TPosition.U_DRESS]->btValue[7]).ToString() + "/" + (m_UseItems[TPosition.U_DRESS]->btValue[8]).ToString() + "/"
                                        + (m_UseItems[TPosition.U_DRESS]->btValue[14]).ToString() + "\09" + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT));
                                }
                            }
                            m_UseItems[TPosition.U_DRESS]->wIndex = 0;
                            nCode = 7;
                            FeatureChanged();
                        }
                        m_UseItems[TPosition.U_DRESS]->wIndex = 0;
                        m_UseItems[TPosition.U_DRESS]->Dura = 0;
                        bo19 = true;
                    }
                    else
                    {
                        m_UseItems[TPosition.U_DRESS]->Dura = (ushort)nDura;
                    }
                    nCode = 8;
                    if (nOldDura != (int)HUtil32.Round((double)nDura / 1000))
                    {
                        SendMsg(this, Grobal2.RM_DURACHANGE, TPosition.U_DRESS, nDura, m_UseItems[TPosition.U_DRESS]->DuraMax, 0, "");
                    }
                }
                for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                {
                    nCode = 9;
                    if ((m_UseItems[I]->wIndex > 0) && (HUtil32.Random(8) == 0))
                    {
                        StdItem = UserEngine.GetStdItem(m_UseItems[I]->wIndex);
                        nCode = 10;
                        if (StdItem == null)
                        {
                            continue;
                        }
                        if ((StdItem != null) && (((StdItem->StdMode == 2) && (StdItem->AniCount == 21))
                            || (StdItem->StdMode == 25) || (StdItem->StdMode == 7)))  // ��ף����,����֮����Ʒ������
                        {
                            continue;
                        }
                        nDura = m_UseItems[I]->Dura;
                        nOldDura = (int)HUtil32.Round((double)nDura / 1000);
                        nDura -= nDam;
                        if (nDura <= 0)
                        {
                            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                nCode = 11;
                                PlayObject = this as TPlayObject;
                                nCode = 12;
                                PlayObject.SendDelItems(m_UseItems[I]);
                                if (StdItem->NeedIdentify == 1)
                                {
                                    M2Share.AddGameDataLog("3" + "\09" + m_sMapName + "\09" + (m_nCurrX).ToString() + "\09" + (m_nCurrY).ToString() + "\09"
                                        + m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen) + "\09" + (m_UseItems[I]->MakeIndex).ToString() + "\09" + "(" + (HUtil32.LoWord(StdItem->DC)).ToString()
                                        + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")"
                                        + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/"
                                        + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")"
                                        + (m_UseItems[I]->btValue[0]).ToString() + "/" + (m_UseItems[I]->btValue[1]).ToString() + "/" + (m_UseItems[I]->btValue[2]).ToString()
                                        + "/" + (m_UseItems[I]->btValue[3]).ToString() + "/" + (m_UseItems[I]->btValue[4]).ToString() + "/" + (m_UseItems[I]->btValue[5]).ToString()
                                        + "/" + (m_UseItems[I]->btValue[6]).ToString() + "/" + (m_UseItems[I]->btValue[7]).ToString() + "/" + (m_UseItems[I]->btValue[8]).ToString() +
                                        "/" + (m_UseItems[I]->btValue[14]).ToString() + "\09" + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT));
                                }
                                m_UseItems[I]->wIndex = 0;
                                nCode = 13;
                                FeatureChanged();
                            }
                            m_UseItems[I]->wIndex = 0;
                            m_UseItems[I]->Dura = 0;
                            bo19 = true;
                        }
                        else
                        {
                            m_UseItems[I]->Dura = (ushort)nDura;
                        }
                        nCode = 14;
                        if (nOldDura != (int)HUtil32.Round((double)nDura / 1000))
                        {
                            SendMsg(this, Grobal2.RM_DURACHANGE, I, nDura, m_UseItems[I]->DuraMax, 0, "");
                        }
                    }
                }
                if (bo19)
                {
                    nCode = 15;
                    RecalcAbilitys();
                    nCode = 16;
                    CompareSuitItem(false);// ��װ������װ���Ա�
                }
                nCode = 18;
                DamageHealth(nDamage);
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.StruckDamage Code:" + nCode);
            }
        }

        public virtual string GeTBaseObjectInfo()
        {
            string result;
            result = m_sCharName + " " + "��ͼ:" + m_sMapName + "(" + m_PEnvir.sMapDesc + ") " + "����:" + (m_nCurrX).ToString()
                + "/" + (m_nCurrY).ToString() + " " + "�ȼ�:" + (m_Abil.Level).ToString() + " " + "����:" + (m_Abil.Exp).ToString()
                + " " + "����ֵ: " + (m_WAbil.HP).ToString() + "-" + (m_WAbil.MaxHP).ToString() + " " + "ħ��ֵ: " + (m_WAbil.MP).ToString()
                + "-" + (m_WAbil.MaxMP).ToString() + " " + "������: " + (HUtil32.LoWord(m_WAbil.DC)).ToString() + "-" + (HUtil32.HiWord(m_WAbil.DC)).ToString()
                + " " + "ħ����: " + (HUtil32.LoWord(m_WAbil.MC)).ToString() + "-" + (HUtil32.HiWord(m_WAbil.MC)).ToString() + " " + "����: "
                + (HUtil32.LoWord(m_WAbil.SC)).ToString() + "-" + (HUtil32.HiWord(m_WAbil.SC)).ToString() + " " + "������: " + (HUtil32.LoWord(m_WAbil.AC)).ToString()
                + "-" + (HUtil32.HiWord(m_WAbil.AC)).ToString() + " " + "ħ����: " + (HUtil32.LoWord(m_WAbil.MAC)).ToString() + "-" + (HUtil32.HiWord(m_WAbil.MAC)).ToString()
                + " " + "׼ȷ:" + (m_btHitPoint).ToString() + " " + "����:" + (m_btSpeedPoint).ToString();
            return result;
        }

        public bool GetBackPosition(ref int nX, ref int nY)
        {
            bool result;
            TEnvirnoment Envir = m_PEnvir;
            nX = m_nCurrX;
            nY = m_nCurrY;
            switch (m_btDirection)
            {
                case Grobal2.DR_UP:// 0
                    if (nY < (Envir.m_nHeight - 1))
                    {
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWN:// 4
                    if (nY > 0)
                    {
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_LEFT:// 6
                    if (nX < (Envir.m_nWidth - 1))
                    {
                        nX++;
                    }
                    break;
                case Grobal2.DR_RIGHT:// 2
                    if (nX > 0)
                    {
                        nX -= 1;
                    }
                    break;
                case Grobal2.DR_UPLEFT:// ������
                    if ((nX < (Envir.m_nWidth - 1)) && (nY < (Envir.m_nHeight - 1)))
                    {
                        nX++;
                        nY++;
                    }
                    break;
                case Grobal2.DR_UPRIGHT:// ������
                    if ((nX < (Envir.m_nWidth - 1)) && (nY > 0))
                    {
                        nX -= 1;
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:// ������
                    if ((nX > 0) && (nY < (Envir.m_nHeight - 1)))
                    {
                        nX++;
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:// ������
                    if ((nX > 0) && (nY > 0))
                    {
                        nX -= 1;
                        nY -= 1;
                    }
                    break;
            }
            result = true;
            return result;
        }

        /// <summary>
        /// �������״̬���ж� ��֩�����ȣ�
        /// </summary>
        /// <param name="nType">����</param>
        /// <param name="nTime">����ʱ��</param>
        /// <param name="nPoint">��HP����</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool MakePosion(int nType, ushort nTime, byte nPoint)
        {
            bool result = false;
            int nOldCharStatus;
            byte nCheckCode = 0;
            try
            {
                if ((nType < Grobal2.MAX_STATUS_ATTRIBUTE) && (nType >= 0))
                {
                    nCheckCode = 1;
                    nOldCharStatus = m_nCharStatus;
                    nCheckCode = 2;
                    if (m_wStatusTimeArr[nType] > 0)
                    {
                        if (m_wStatusTimeArr[nType] < nTime)
                        {
                            m_wStatusTimeArr[nType] = nTime;
                        }
                    }
                    else
                    {
                        m_wStatusTimeArr[nType] = nTime;
                    }
                    nCheckCode = 3;
                    m_dwStatusArrTick[nType] = HUtil32.GetTickCount();
                    m_nCharStatus = GetCharStatus();
                    m_btGreenPoisoningPoint = nPoint;
                    nCheckCode = 4;
                    if (nOldCharStatus != m_nCharStatus)
                    {
                        StatusChanged("");
                    }
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        nCheckCode = 5;
                        SysMsg(string.Format(GameMsgDef.sYouPoisoned, nTime, nPoint), TMsgColor.c_Red, TMsgType.t_Hint);// '�ж��ˣ�����%d�� %d��'
                        switch (nType)
                        {
                            case Grobal2.POISON_STONE:
                                SysMsg("�㱻ʯ���ˣ�", TMsgColor.c_Red, TMsgType.t_Hint);
                                break;
                            default:// �ж��ˣ�����
                                SysMsg(GameMsgDef.sYouPoisoned, TMsgColor.c_Red, TMsgType.t_Hint);
                                break;
                        }
                    }
                    else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                    {
                        nCheckCode = 6;
                        if (m_Master != null)
                        {
                            m_Master.SysMsg(string.Format("(Ӣ��) " + GameMsgDef.sYouPoisoned, nTime, nPoint), TMsgColor.c_Red, TMsgType.t_Hint);
                        }
                        if (m_Master != null)
                        {
                            switch (nType)
                            {
                                case Grobal2.POISON_STONE:
                                    m_Master.SysMsg("(Ӣ��) �㱻ʯ���ˣ�", TMsgColor.c_Red, TMsgType.t_Hint);
                                    break;
                                default:
                                    m_Master.SysMsg("(Ӣ��) " + GameMsgDef.sYouPoisoned, TMsgColor.c_Red, TMsgType.t_Hint);
                                    break;
                            }
                        }
                    }
                    result = true;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.MakePosion Code:" + nCheckCode);
            }
            return result;
        }

        /// <summary>
        /// ���������֩���������ܶ�
        /// </summary>
        /// <param name="nTime">����ʱ��</param>
        /// <returns></returns>
        public bool MakeSpiderMag(ushort nTime)
        {
            bool result = false;
            int nOldCharStatus;
            if (m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] != 0)
            {
                return result;
            }
            nOldCharStatus = m_nCharStatus;
            m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] = nTime; // �̶ּ��پ�(��)
            m_dwStatusArrTick[Grobal2.STATE_LOCKRUN] = HUtil32.GetTickCount();// ����״̬�����Ŀ�ʼʱ��
            m_nCharStatus = GetCharStatus();
            if (nOldCharStatus != m_nCharStatus)
            {
                StatusChanged("");
            }
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                ((this) as TPlayObject).m_boCanRun = false;// �Ƿ�������
                SysMsg(GameMsgDef.sYouPoisonedSpider, TMsgColor.c_Red, TMsgType.t_Hint);// ��������ʾ
            }
            else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                ((THeroObject)(this)).m_boCanRun = false;// �Ƿ�������
                if (m_Master != null)
                {
                    m_Master.SysMsg("(Ӣ��) " + GameMsgDef.sYouPoisonedSpider, TMsgColor.c_Red, TMsgType.t_Hint); // ��������ʾ
                }
            }
            result = true;
            return result;
        }

        public unsafe bool sub_4DD704()
        {
            bool result = false;
            TSendMessage SendMessage;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                if (m_MsgList.Count > 0)
                {
                    for (int I = 0; I < m_MsgList.Count; I++)
                    {
                        SendMessage = m_MsgList[I];
                        if (SendMessage.wIdent == Grobal2.RM_10401)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            return result;
        }

        public bool sub_4C5370(int nX, int nY, int nRange, ref int nDX, ref int nDY)
        {
            bool result = false;
            if (m_PEnvir.GetMovingObject(nX, nY, true) == null)
            {
                result = true;
                nDX = nX;
                nDY = nY;
            }
            if (!result)
            {
                for (int I = 1; I <= nRange; I++)
                {
                    for (int J = -I; J <= I; J++)
                    {
                        for (int K = -I; K <= I; K++)
                        {
                            nDX = nX + K;
                            nDY = nY + J;
                            if (m_PEnvir.GetMovingObject(nDX, nDY, true) == null)
                            {
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
                        break;
                    }
                }
            }
            if (!result)
            {
                nDX = nX;
                nDY = nY;
            }
            return result;
        }

        /// <summary>
        /// �Ƿ�ѧϰ��ĳ������
        /// </summary>
        /// <param name="nIndex">���ܱ��</param>
        /// <returns></returns>
        public unsafe bool IsTrainingSkill(int nIndex)
        {
            bool result = false;
            TUserMagic* UserMagic;
            if (nIndex != 31)// ����ħ����
            {
                if (m_MagicList.Count > 0)
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)m_MagicList[I];
                        if ((UserMagic != null) && (UserMagic->wMagIdx == nIndex))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (m_MagicList.Count > 0)// ��ħ�������ж��ǲ�����4��ħ���ܻ���ͨħ����
                {
                    for (int I = 0; I < m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)m_MagicList[I];
                        if ((UserMagic != null) && ((UserMagic->wMagIdx == 31) || (UserMagic->wMagIdx == 66)))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public unsafe TUserMagic* CanTrainingFoueSkill(TStdItem* StdItem)
        {
            TUserMagic* result = null;
            TUserMagic* UserMagic;
            if ((StdItem->Need == 0) || (StdItem->NeedLevel == 0))
            {
                return result;
            }
            if (m_MagicList.Count > 0)
            {
                for (int I = 0; I < m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)m_MagicList[I];
                    if ((UserMagic != null) && (UserMagic->wMagIdx == StdItem->Need) && (UserMagic->btLevel == 3))
                    {
                        result = UserMagic;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ���ٴ������ֵ
        /// </summary>
        /// <param name="nInt"></param>
        public void DamageBubbleDefence(int nInt)
        {
            if (m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] > 0)
            {
                if (m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] > 3)
                {
                    m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] -= 3;
                }
                else
                {
                    m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] = 1;
                }
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="nInt"></param>
        public void DamageProtectionDefence(int nInt)
        {
            if (GameConfig.nProtectionDefenceTime > 0)// �������,�ʱ�����0
            {
                if (m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] > 0)
                {
                    m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] -= 1;
                }
                else
                {
                    m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;
                }
            }
        }

        /// <summary>
        /// �Ƿ����л�����
        /// </summary>
        /// <returns></returns>
        public bool IsGuildMaster()
        {
            bool result = false;
            if ((m_MyGuild != null) && (m_nGuildRankNo == 1))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// ħ���ܴ�Ŀ��
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="TargeTBaseObject"></param>
        /// <returns></returns>
        public bool MagCanHitTarget(int nX, int nY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int n18;
            int n1C;
            if (TargeTBaseObject == null)
            {
                return result;
            }
            int n20 = Math.Abs(nX - TargeTBaseObject.m_nCurrX) + Math.Abs(nY - TargeTBaseObject.m_nCurrY);
            int n14 = 0;
            while (n14 < 13)
            {
                n18 = M2Share.GetNextDirection(nX, nY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
                if (m_PEnvir.GetNextPosition(nX, nY, n18, 1, ref nX, ref nY) && m_PEnvir.sub_4B5FC8(nX, nY))
                {
                    if ((nX == TargeTBaseObject.m_nCurrX) && (nY == TargeTBaseObject.m_nCurrY))
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        n1C = Math.Abs(nX - TargeTBaseObject.m_nCurrX) + Math.Abs(nY - TargeTBaseObject.m_nCurrY);
                        if (n1C > n20)
                        {
                            result = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
                n14++;
            }
            return result;
        }

        public bool IsProperFriend_IsFriend(TBaseObject cret)
        {
            bool result = false;
            byte nCode = 0;
            try
            {
                if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    // Ӣ�۸��Լ��ı����ӷ�
                    if (cret.m_Master != null)
                    {
                        if (m_Master == cret.m_Master)
                        {
                            result = true;
                        }
                        if (cret.m_Master == this)
                        {
                            result = true;
                        }
                    }
                    else if (m_Master == cret)
                    {
                        result = true;
                    }
                }
                nCode = 21;
                if (cret.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    // ���˸�Ӣ�۱����ӷ�
                    if (cret.m_Master == this)
                    {
                        result = true;
                    }
                }
                nCode = 1;
                if ((cret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    switch (m_btAttatckMode)
                    {
                        case M2Share.HAM_ALL:// �������������
                            result = true;
                            break;
                        case M2Share.HAM_PEACE:// ��ƽ����
                            nCode = 2;
                            result = true;
                            if ((cret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_btRaceServer == Grobal2.RC_HEROOBJECT))
                            {
                                result = false; // Ӣ�ۺ�ƽģʽ�²���������
                            }
                            nCode = 3;
                            break;
                        case M2Share.HAM_DEAR:
                            nCode = 4;
                            if ((this == cret) || (cret == ((this) as TPlayObject).m_DearHuman))
                            {
                                result = true;
                            }
                            break;
                        case M2Share.HAM_MASTER:// ʦͽ����
                            nCode = 5;
                            if ((this == cret))
                            {
                                result = true;
                            }
                            else if (((this) as TPlayObject).m_boMaster)
                            {
                                nCode = 6;
                                if (((this) as TPlayObject).m_MasterList.Count > 0)
                                {
                                    for (int I = 0; I < ((this) as TPlayObject).m_MasterList.Count; I++)
                                    {
                                        nCode = 7;
                                        if (((this) as TPlayObject).m_MasterList[I] == cret)
                                        {
                                            nCode = 8;
                                            result = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (((cret) as TPlayObject).m_boMaster)
                            {
                                nCode = 9;
                                if (((cret) as TPlayObject).m_MasterList.Count > 0)
                                {
                                    for (int I = 0; I < ((cret) as TPlayObject).m_MasterList.Count; I++)
                                    {
                                        nCode = 10;
                                        if (((cret) as TPlayObject).m_MasterList[I] == this)
                                        {
                                            nCode = 11;
                                            result = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        case M2Share.HAM_GROUP:
                            nCode = 12;
                            if (cret == this)
                            {
                                result = true;
                            }
                            nCode = 13;
                            if (((this) as TPlayObject).IsGroupMember(((cret) as TPlayObject)))
                            {
                                result = true;
                            }
                            break;
                        case M2Share.HAM_GUILD:
                            nCode = 14;
                            if (cret == this)
                            {
                                result = true;
                            }
                            nCode = 15;
                            if (m_MyGuild != null)
                            {
                                nCode = 16;
                                if (((TGUild)(m_MyGuild)).IsMember(cret.m_sCharName))
                                {
                                    result = true;
                                }
                                nCode = 17;
                                if (m_boGuildWarArea && (cret.m_MyGuild != null))
                                {
                                    nCode = 18;
                                    if (((TGUild)(m_MyGuild)).IsAllyGuild(((TGUild)(cret.m_MyGuild))))
                                    {
                                        result = true;
                                    }
                                    nCode = 19;
                                }
                            }
                            break;
                        case M2Share.HAM_PKATTACK:
                            nCode = 20;
                            if (cret == this)
                            {
                                result = true;
                            }
                            if (PKLevel() >= 2)
                            {
                                if (cret.PKLevel() < 2)
                                {
                                    result = true;
                                }
                            }
                            else
                            {
                                if (cret.PKLevel() >= 2)
                                {
                                    result = true;
                                }
                            }
                            break;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.IsProperFriend  Code:" + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// �Ƿ����ѷ�
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <returns></returns>
        public virtual bool IsProperFriend(TBaseObject BaseObject)
        {
            bool result = false;
            if (BaseObject == null)
            {
                return result;
            }
            if ((m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (m_btRaceServer == Grobal2.RC_HEROOBJECT))// ������
            {
                if (m_Master == null)
                {
                    if ((BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                    {
                        result = true;
                    }
                    if ((BaseObject.m_Master != null) || (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        result = false;
                    }
                }
                else
                {
                    if ((BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                    {
                        result = false;
                    }
                    if (BaseObject.m_Master != null)
                    {
                        result = IsProperFriend_IsFriend(BaseObject.m_Master);
                    }
                    if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        result = IsProperFriend_IsFriend(BaseObject);
                    }
                    if (BaseObject == m_Master)
                    {
                        result = true;
                    }
                }
                return result;
            }
            if ((m_btRaceServer >= Grobal2.RC_ANIMAL))
            {
                if ((BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                {
                    result = true;
                }
                if (BaseObject.m_Master != null)
                {
                    result = false;
                }
                return result;
            }
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                result = IsProperFriend_IsFriend(BaseObject);
                if (BaseObject.m_btRaceServer < Grobal2.RC_ANIMAL)
                {
                    return result;
                }
                if (BaseObject.m_Master == this)
                {
                    result = true;
                    return result;
                }
                if (BaseObject.m_Master != null)
                {
                    result = IsProperFriend_IsFriend(BaseObject.m_Master);
                    return result;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// �����  ��ʥս���� 
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRange"></param>
        /// <param name="nSec"></param>
        /// <param name="btState">1 ����� 0 ��ʥս����</param>
        /// <returns></returns>
        public int MagMakeDefenceArea(int nX, int nY, int nRange, ushort nSec, byte btState)
        {
            int result = 0;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            int nStartX = nX - nRange;
            int nEndX = nX + nRange;
            int nStartY = nY - nRange;
            int nEndY = nY + nRange;
            for (int I = nStartX; I <= nEndX; I++)
            {
                for (int J = nStartY; J <= nEndY; J++)
                {
                    if (m_PEnvir.GetMapCellInfo(I, J, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                    {
                        if (MapCellInfo.ObjList.Count > 0)
                        {
                            for (int K = 0; K < MapCellInfo.ObjList.Count; K++)
                            {
                                OSObject = MapCellInfo.ObjList[K];
                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                {
                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                    if ((BaseObject != null) && (!BaseObject.m_boGhost))
                                    {
                                        if (IsProperFriend(BaseObject))
                                        {
                                            if (btState == 0)
                                            {
                                                BaseObject.DefenceUp(nSec);
                                            }
                                            else
                                            {
                                                BaseObject.MagDefenceUp(nSec);
                                            }
                                            result++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // ������
        public int MagMakeAbilityArea(int nX, int nY, int nRange, int nSec)
        {
            int result = 0;
            TMapCellinfo MapCellInfo = new TMapCellinfo();
            TOSObject OSObject;
            TBaseObject BaseObject;
            bool bo06;
            int nStartX = nX - nRange;
            int nEndX = nX + nRange;
            int nStartY = nY - nRange;
            int nEndY = nY + nRange;
            for (int I = nStartX; I <= nEndX; I++)
            {
                for (int J = nStartY; J <= nEndY; J++)
                {
                    if (m_PEnvir.GetMapCellInfo(I, J, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                    {
                        if (MapCellInfo.ObjList.Count > 0)
                        {
                            for (int K = 0; K < MapCellInfo.ObjList.Count; K++)
                            {
                                OSObject = MapCellInfo.ObjList[K];
                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                {
                                    BaseObject = (TBaseObject)OSObject.CellObj;
                                    if ((BaseObject != null) && (!BaseObject.m_boGhost))
                                    {
                                        if (IsProperTarget(BaseObject))
                                        {
                                            bo06 = false;
                                            switch (BaseObject.m_btJob)
                                            {
                                                case 0:
                                                    if (BaseObject.m_wStatusArrValue[6] == 0)
                                                    {
                                                        BaseObject.m_wStatusArrValue[6] = Convert.ToUInt16(HUtil32.MakeLong(HUtil32.LoWord(BaseObject.m_WAbil.DC),
                                                            HUtil32.HiWord(BaseObject.m_WAbil.DC) - 2 - (BaseObject.m_Abil.Level / 7)));
                                                        BaseObject.m_dwStatusArrTimeOutTick[6] = Convert.ToUInt32(HUtil32.GetTickCount() + nSec * 1000);
                                                        if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                        {
                                                            BaseObject.m_Master.SysMsg("(Ӣ��) ����������" + nSec + "��", TMsgColor.c_Green, TMsgType.t_Hint);
                                                        }
                                                        else
                                                        {
                                                            BaseObject.SysMsg("����������" + nSec + "��", TMsgColor.c_Green, TMsgType.t_Hint);
                                                        }
                                                        bo06 = true;
                                                    }
                                                    break;
                                                case 1:
                                                    if (BaseObject.m_wStatusArrValue[7] == 0)
                                                    {
                                                        BaseObject.m_wStatusArrValue[7] = Convert.ToUInt16(HUtil32.MakeLong(HUtil32.LoWord(BaseObject.m_WAbil.MC),
                                                            HUtil32.HiWord(BaseObject.m_WAbil.MC) - 2 - (BaseObject.m_Abil.Level / 7)));
                                                        BaseObject.m_dwStatusArrTimeOutTick[7] = Convert.ToUInt32(HUtil32.GetTickCount() + nSec * 1000);
                                                        if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                        {
                                                            BaseObject.m_Master.SysMsg("(Ӣ��) ħ��������" + nSec + "��", TMsgColor.c_Green, TMsgType.t_Hint);
                                                        }
                                                        else
                                                        {
                                                            BaseObject.SysMsg("ħ��������" + nSec + "��", TMsgColor.c_Green, TMsgType.t_Hint);
                                                        }
                                                        bo06 = true;
                                                    }
                                                    break;
                                                case 2:
                                                    if (BaseObject.m_wStatusArrValue[8] == 0)
                                                    {
                                                        BaseObject.m_wStatusArrValue[8] = Convert.ToUInt16(HUtil32.MakeLong(HUtil32.LoWord(BaseObject.m_WAbil.SC), HUtil32.HiWord(BaseObject.m_WAbil.SC)
                                                            - 2 - (BaseObject.m_Abil.Level / 7)));
                                                        BaseObject.m_dwStatusArrTimeOutTick[8] = Convert.ToUInt32(HUtil32.GetTickCount() + nSec * 1000);
                                                        if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                        {
                                                            BaseObject.m_Master.SysMsg("(Ӣ��) ��������" + nSec + "��", TMsgColor.c_Green, TMsgType.t_Hint);
                                                        }
                                                        else
                                                        {
                                                            BaseObject.SysMsg("��������" + nSec + "��", TMsgColor.c_Green, TMsgType.t_Hint);
                                                        }
                                                        bo06 = true;
                                                    }
                                                    break;
                                            }
                                            if (bo06)
                                            {
                                                if (BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                                {
                                                    ((THeroObject)(BaseObject)).RecalcAbilitys();
                                                    BaseObject.CompareSuitItem(false);// ��װ������װ���Ա�
                                                    ((THeroObject)(BaseObject)).SendMsg(BaseObject, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");// ����Ӣ������
                                                }
                                                else
                                                {
                                                    BaseObject.RecalcAbilitys();
                                                    BaseObject.CompareSuitItem(false);// ��װ������װ���Ա�
                                                    BaseObject.SendMsg(BaseObject, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                                                }
                                            }
                                            result++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // ���ٵ���ʱ��
        public void MagDownHealth(int nType, int nTime, ushort nPoint)
        {
            int nHealthType = 9 + nType;
            if ((nHealthType >= 0) && (nHealthType < Grobal2.MAX_STATUS_ATTRIBUTE))
            {
                if (m_wStatusArrValue[nHealthType] == 0)
                {
                    m_wStatusArrValue[nHealthType] = nPoint;
                    m_dwStatusArrTimeOutTick[nHealthType] = Convert.ToUInt32(HUtil32.GetTickCount() + nTime * 1000);
                }
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="nSec"></param>
        /// <returns></returns>
        public bool DefenceUp(ushort nSec)
        {
            bool result = false;
            if (m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] > 0)
            {
                if (m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] < nSec)
                {
                    m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] = nSec;
                    result = true;
                }
            }
            else
            {
                m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] = nSec;
                result = true;
            }
            m_dwStatusArrTick[Grobal2.STATE_DEFENCEUP] = HUtil32.GetTickCount();
            SysMsg(string.Format(GameMsgDef.g_sDefenceUpTime, nSec), TMsgColor.c_Green, TMsgType.t_Hint);
            if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                ((THeroObject)(this)).RecalcAbilitys();
                CompareSuitItem(false);// ��װ������װ���Ա�
                ((THeroObject)(this)).SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");// ����Ӣ������
            }
            else
            {
                RecalcAbilitys();
                CompareSuitItem(false);// ��װ������װ���Ա�
                SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
            }
            return result;
        }

        /// <summary>
        /// ħ��������
        /// </summary>
        /// <param name="nSec"></param>
        /// <returns></returns>
        public bool MagDefenceUp(ushort nSec)
        {
            bool result = false;
            if (m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] > 0)
            {
                if (m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] < nSec)
                {
                    m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] = nSec;
                    result = true;
                }
            }
            else
            {
                m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] = nSec;
                result = true;
            }

            m_dwStatusArrTick[Grobal2.STATE_MAGDEFENCEUP] = HUtil32.GetTickCount();
            SysMsg(string.Format(GameMsgDef.g_sMagDefenceUpTime, nSec), TMsgColor.c_Green, TMsgType.t_Hint);
            if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                ((THeroObject)(this)).RecalcAbilitys();
                CompareSuitItem(false);// ��װ������װ���Ա�
                ((THeroObject)(this)).SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");// ����Ӣ������
            }
            else
            {
                RecalcAbilitys();
                CompareSuitItem(false);// ��װ������װ���Ա�
                SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
            }
            return result;
        }

        /// <summary>
        /// ħ����  ������
        /// </summary>
        /// <param name="nLevel"></param>
        /// <param name="nSec"></param>
        /// <returns></returns>
        public bool MagBubbleDefenceUp(int nLevel, ushort nSec)
        {
            bool result = false;
            int nOldStatus;
            if (m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] != 0)
            {
                return result;
            }
            nOldStatus = m_nCharStatus;
            m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] = nSec;// �̶ּ��پ�(��)
            m_dwStatusArrTick[Grobal2.STATE_BUBBLEDEFENCEUP] = HUtil32.GetTickCount();// ����״̬�����Ŀ�ʼʱ��
            m_nCharStatus = GetCharStatus();
            if (nOldStatus != m_nCharStatus)
            {
                if (nLevel == 4)
                {
                    //4����,������Ϣ���ͻ�����ʾ���е�Ч��
                    StatusChanged("444");
                }
                else
                {
                    StatusChanged("");
                }
            }
            m_boAbilMagBubbleDefence = true;// �Ƿ�ʹ��ħ����
            m_btMagBubbleDefenceLevel = (byte)nLevel;// ħ���ܵȼ�
            result = true;
            return result;
        }

        // �������
        public bool MagProtectionDefenceUp(int nLevel)
        {
            bool result = false;
            int nOldStatus;
            if (m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] != 0)
            {
                return result;
            }
            nOldStatus = m_nCharStatus;
            m_boProtectionDefence = true;// ʹ�û������
            if (GameConfig.nProtectionDefenceTime != 0)
            {
                // �̶ּ��پ�(��):��������ʱ�� + �ȼ� * 0.5��
                m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = Convert.ToUInt16((GameConfig.nProtectionDefenceTime + nLevel * 500) / 1000);
            }
            else
            {
                m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 6;
            }
            m_dwStatusArrTick[Grobal2.STATE_ProtectionDEFENCE] = HUtil32.GetTickCount();// ����״̬�����Ŀ�ʼʱ��
            m_nCharStatus = GetCharStatus();
            if (nOldStatus != m_nCharStatus)
            {
                StatusChanged("");
            }
            m_boProtectionDefenceLevel = (byte)nLevel;// ������ܵȼ�
            result = true;
            return result;
        }

        // ����
        public unsafe TUserItem* sub_4C4CD4(string sItemName, ref int nCount)
        {
            TUserItem* result = null;
            string sName;
            nCount = 0;
            for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                sName = UserEngine.GetStdItemName(m_UseItems[I]->wIndex);
                if (string.Compare(sName, sItemName, true) == 0)
                {
                    result = m_UseItems[I];
                    nCount++;
                }
            }
            return result;
        }

        public unsafe TUserItem* CheckItems(string sItemName)
        {
            TUserItem* result = null;
            TUserItem* UserItem;
            if (m_ItemList.Count > 0)
            {
                for (int I = 0; I < m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)m_ItemList[I];
                    if ((UserEngine.GetStdItemName(UserItem->wIndex)).ToLower().CompareTo((sItemName).ToLower()) == 0)
                    {
                        result = UserItem;
                        break;
                    }
                }
            }
            return result;
        }

        public int sub_4C3538()
        {
            int result;
            int nC;
            int n10;
            result = 0;
            nC = -1;
            while ((nC != 2))
            {
                n10 = -1;
                while ((n10 != 2))
                {
                    if (!m_PEnvir.CanWalk(m_nCurrX + nC, m_nCurrY + n10, false))
                    {
                        if ((nC != 0) || (n10 != 0))
                        {
                            result++;
                        }
                    }
                    n10++;
                }
                nC++;
            }
            return result;
        }

        /// <summary>
        /// ɾ��������Ʒ
        /// </summary>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        public bool DelBagItem(int nIndex)
        {
            bool result = false;
            if ((nIndex < 0) || (nIndex >= m_ItemList.Count))
            {
                return result;
            }
            if (m_ItemList[nIndex] != null)
            {
                Dispose(m_ItemList[nIndex]);
                m_ItemList.RemoveAt(nIndex);
                result = true;
            }
            if (result)
            {
                WeightChanged();
            }
            return result;
        }

        /// <summary>
        /// ɾ��������Ʒ
        /// </summary>
        /// <param name="nItemIndex"></param>
        /// <param name="sItemName"></param>
        /// <returns></returns>
        public unsafe bool DelBagItem(int nItemIndex, string sItemName)
        {
            bool result = false;
            TUserItem* UserItem;
            for (int I = m_ItemList.Count - 1; I >= 0; I--)
            {
                if (m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)m_ItemList[I];
                if ((UserItem->MakeIndex == nItemIndex) && (string.Compare(UserEngine.GetStdItemName(UserItem->wIndex), sItemName) == 0))
                {
                    m_ItemList.RemoveAt(I);
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    result = true;
                    break;
                }
            }
            if (result)
            {
                WeightChanged();
            }
            return result;
        }

        /// <summary>
        /// ɾ��������Ʒ
        /// </summary>
        /// <param name="UserItem"></param>
        /// <returns></returns>
        public unsafe bool DelBagItem(TUserItem* UserItem)
        {
            bool result = false;
            TUserItem* Item;
            for (int I = m_ItemList.Count - 1; I >= 0; I--)
            {
                if (m_ItemList.Count <= 0)
                {
                    break;
                }
                Item = (TUserItem*)m_ItemList[I];
                if (UserItem->wIndex == Item->wIndex)
                {
                    m_ItemList.RemoveAt(I);
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    result = true;
                    break;
                }
            }
            if (result)
            {
                WeightChanged();
            }
            return result;
        }

        /// <summary>
        /// ��ֹ��Ʒ����(����������) 
        /// </summary>
        /// <param name="nCode">
        /// 0-��Ʒ��ֹ�� 1-��Ʒ��ֹ���� 2-��Ʒ��ֹ��  3-��Ʒ��ֹ�� 4-��Ʒ������ʾ  5-����������ʾ
        /// 6-��������   7-��ȡ��ʾ    8-��ֹӢ��ʹ�� 9-��ֹ����(��GM��) 10-��������
        /// </param>
        /// <param name="ItemName">��Ʒ����</param>
        /// <param name="boCanHit">�����Ƿ���Ҫ��ʾ</param>
        /// <param name="dx">����λ��X</param>
        /// <param name="dy">����λ��Y</param>
        /// <returns>�Ƿ�����</returns>
        public bool PlugOfCheckCanItem(byte nCode, string ItemName, bool boCanHit, int dx, int dy)
        {
            bool result = false;
            TCheckItem CheckItem;
            string sMsg;
            try
            {
                if (M2Share.g_CheckItemList == null)
                {
                    return result;
                }
                if (M2Share.g_CheckItemList.Count > 0)
                {
                    for (int I = 0; I < M2Share.g_CheckItemList.Count; I++)
                    {
                        CheckItem = M2Share.g_CheckItemList[I];
                        if (CheckItem != null)
                        {
                            if (string.Compare(CheckItem.szItemName, ItemName, true) == 0)
                            {
                                switch (nCode)
                                {
                                    case 0:// ��Ʒ��ֹ��
                                        if (CheckItem.boCanDrop)
                                        {
                                            if (M2Share.g_ManageNPC != null)
                                            {
                                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                {
                                                    SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, this.ToInt(), 0, 0, "����Ʒ��ֹ���ڵ��ϣ�����");
                                                }
                                                else if ((m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                                {
                                                    ((THeroObject)(this)).SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, this.ToInt(), 0, 0, "����Ʒ��ֹ���ڵ��ϣ�����");
                                                }
                                            }
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 1:// 0 ��Ʒ��ֹ����  *
                                        if (CheckItem.boCanDeal)
                                        {
                                            if ((M2Share.g_ManageNPC != null) && !boCanHit)
                                            {
                                                SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, this.ToInt(), 0, 0, "����Ʒ��ֹ���ף�����");
                                            }
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 2:// 1 ��Ʒ��ֹ��
                                        if (CheckItem.boCanStorage)
                                        {
                                            if (M2Share.g_ManageNPC != null)
                                            {
                                                SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, this.ToInt(), 0, 0, "����Ʒ��ֹ��ֿ⣡����");
                                            }
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 3:// 2 ��Ʒ��ֹ��  *
                                        if (CheckItem.boCanRepair)
                                        {
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 4:// ��Ʒ������ʾ *
                                        if (CheckItem.boCanDropHint && boCanHit && (m_PEnvir != null))
                                        {
                                            sMsg = GameMsgDef.g_sItmeDropHintMsg.Replace("%X", (dx).ToString());
                                            sMsg = sMsg.Replace("%Y", (dy).ToString());
                                            sMsg = sMsg.Replace("%map", m_PEnvir.sMapDesc);
                                            sMsg = sMsg.Replace("%item", ItemName);
                                            sMsg = sMsg.Replace("%name", m_sCharName);
                                            UserEngine.SendBroadCastMsgExt(sMsg, TMsgType.t_Say);
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 5:// 4 ����������ʾ  *
                                        if (CheckItem.boCanOpenBoxsHint)
                                        {
                                            sMsg = GameMsgDef.g_sBoxsItemHintMsg.Replace("%name", m_sCharName);
                                            sMsg = sMsg.Replace("%s", ItemName);
                                            UserEngine.SendBroadCastMsgExt(sMsg, TMsgType.t_Say);
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 6:// ��������  *
                                        if (CheckItem.boCanNoDropItem)
                                        {
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 7:// ��ȡ��ʾ *
                                        if (CheckItem.boCanButchHint)
                                        {
                                            sMsg = GameMsgDef.g_sButchItemHintMsg.Replace("%s", m_sCharName);
                                            sMsg = sMsg.Replace("%map", m_PEnvir.sMapDesc);
                                            sMsg = sMsg.Replace("%item", ItemName);
                                            sMsg = sMsg.Replace("%x", m_nCurrX.ToString());
                                            sMsg = sMsg.Replace("%y", m_nCurrY.ToString());
                                            UserEngine.SendBroadCastMsgExt(sMsg, TMsgType.t_Say);
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 8:// ��ֹӢ��ʹ��
                                        if (CheckItem.boCanHeroUse)
                                        {
                                            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                SysMsg("����Ʒ��ֹӢ��ʹ��!", TMsgColor.c_Red, TMsgType.t_Hint);
                                            }
                                            else if (m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                            {
                                                ((THeroObject)(this)).SysMsg("����Ʒ��ֹӢ��ʹ��!", TMsgColor.c_Red, TMsgType.t_Hint);
                                            }
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 9:// ��ֹ����(��GM��) *
                                        if (CheckItem.boPickUpItem)
                                        {
                                            result = true;
                                            break;
                                        }
                                        break;
                                    case 10:// ��������  *
                                        if (CheckItem.boDieDropItems)
                                        {
                                            result = true;
                                            break;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TBaseObject.PlugOfCheckCanItem Code:" + nCode);
            }
            return result;
        }

        /// <summary>
        /// �ͷ�ָ��������Դ
        /// </summary>
        /// <param name="obj"></param>
        public void Dispose(object obj)
        {
            obj = null;
        }
    }
}