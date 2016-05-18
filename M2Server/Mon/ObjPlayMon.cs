using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using GameFramework;
using GameFramework.Enum;

namespace M2Server
{
    /// <summary>
    /// ���ι��� ����
    /// </summary>
    public class TPlayMonster: TBaseObject
    {
        public uint m_dwThinkTick = 0;
        public bool m_boDupMode = false;// �����ص���
        public int m_nTargetX = 0;
        public int m_nTargetY = 0;
        public bool m_boRunAwayMode = false;
        public uint m_dwRunAwayStart = 0;
        public uint m_dwRunAwayTime = 0;
        public bool m_boCanPickUpItem = false;
        public uint m_dwPickUpItemTick = 0;
        public ushort m_wHitMode = 0;
        public uint m_dwAutoAvoidTick = 0;// �Զ���ܼ��
        public bool m_boAutoAvoid = false;// �Ƿ���
        public bool m_boDoSpellMagic = false;// �Ƿ����ʹ��ħ��
        public uint m_dwDoSpellMagicTick = 0;// ʹ��ħ�����
        public bool m_boGotoTargetXY = false;// �Ƿ�����Ŀ��
        public uint m_SkillShieldTick = 0;// ħ����ʹ�ü��
        public uint m_Skill_75_Tick = 0;// �������ʹ�ü�� 
        public uint m_SkillBigHealling = 0;// Ⱥ��������ʹ�ü��
        public uint m_SkillDejiwonho = 0;// ��ʥս����ʹ�ü��
        public uint m_dwCheckDoSpellMagic = 0;
        public int m_nDieDropUseItemRate = 0;// ������װ������
        public bool m_boDropUseItem = false;// �Ƿ��װ��
        public bool m_boButchUseItem = false;// �Ƿ�������ȡ����װ��
        public int m_nButchRate = 0;// ��ȡ����װ������
        public byte m_nButchChargeClass = 0;// ��ȡ����װ���շ�ģʽ(0��ң�1Ԫ����2���ʯ��3���)
        public int m_nButchChargeCount = 0;// ��ȡ����װ��ÿ���շѵ���
        public uint m_nButchItemTime = 0;// ����Ʒ���ʱ��
        public ArrayList m_ButchItemList = null;// ���ι�����Ʒ�б�
        public bool boIntoTrigger = false;// ���ι����Ƿ���봥��
        public bool boIsDieEvent = false;// ��������ʬ��,�Ƿ���ʾ������Ч��(��������Ч��)
        public uint m_dwActionTick = 0;// �������
        public ushort wSkill_05 = 0;// ħ����
        public ushort wSkill_66 = 0;// �ļ�ħ����
        public ushort wSkill_01 = 0;// �׵���
        public ushort wSkill_02 = 0;// �����׹�
        public ushort wSkill_03 = 0;// ������
        public ushort wSKILL_58 = 0;// ���ǻ���
        public ushort wSKILL_36 = 0;// �����
        public ushort wSKILL_45 = 0;// �����
        public ushort wSkill_04 = 0;// ������
        public ushort wSkill_06 = 0;// ʩ����
        public ushort wSkill_07 = 0;// �����
        public ushort wSKILL_59 = 0;// ��Ѫ��
        public ushort wSkill_14 = 0;// �����
        public ushort wSkill_73 = 0;// ������
        public ushort wSkill_50 = 0;// �޼�����
        public ushort wSkill_08 = 0;// ��ʥս����
        public ushort wSkill_09 = 0;// Ⱥ��������
        public ushort wSkill_10 = 0;// Ⱥ��ʩ����
        public ushort wSkill_48 = 0;// ������
        public ushort wSkill_51 = 0;// 쫷���
        public ushort wSkill_11 = 0;// �һ𽣷�
        public ushort wSkill_12 = 0;// ��ɱ����
        public ushort wSkill_13 = 0;// �����䵶
        public ushort wSkill_27 = 0;// Ұ����ײ
        public ushort wSKILL_40 = 0;// ���µ���
        public ushort wSKILL_42 = 0;// ����ն
        public ushort wSKILL_43 = 0;// ��Ӱ����
        public ushort wSKILL_74 = 0;// ���ս���
        public ushort wSkill_75 = 0;// �������
        public uint m_nSkill_5Tick = 0;// �޼�����ʹ�ü��
        public uint m_nSkill_48Tick = 0;// ������ʹ�ü��
        public uint dwRockAddHPTick = 0;// ħѪʯ��HP ʹ�ü��
        public uint dwRockAddMPTick = 0;// ħѪʯ��MP ʹ�ü��
        public uint m_dwDoMotaeboTick = 0;// Ұ����ײ���
        public int m_nSelectMagic = 0;// ħ��
        /// <summary>
        /// �ػ�ģʽ
        /// </summary>
        public bool m_boProtectStatus = false;
        public int m_nProtectTargetX = 0;
        public int m_nProtectTargetY = 0;// �ػ�����
        public bool m_boProtectOK = false;// �����ػ�����
        public int m_nGotoProtectXYCount = 0;

        public TPlayMonster() : base()
        {
            m_boDupMode = false;
            m_nSkill_5Tick = HUtil32.GetTickCount();// �޼�����ʹ�ü��
            m_nSkill_48Tick = HUtil32.GetTickCount();// ������ʹ�ü��
            m_dwThinkTick = HUtil32.GetTickCount();
            this.m_nViewRange = 10;
            this.m_nRunTime = 250;
            this.m_dwSearchTick = HUtil32.GetTickCount();
            this.m_btRaceServer = Grobal2.RC_PLAYMOSTER;
            this.m_nCopyHumanLevel = 2;
            m_nTargetX =  -1;
            this.dwTick3F4 = HUtil32.GetTickCount();
            this.m_dwHitTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_dwWalkTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_nWalkSpeed = 500;
            this.m_nWalkStep = 10;
            this.m_dwWalkWait = 0;
            this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
            m_boRunAwayMode = false;
            m_dwRunAwayStart = HUtil32.GetTickCount();
            m_dwRunAwayTime = 0;
            m_boCanPickUpItem = true;
            m_dwPickUpItemTick = HUtil32.GetTickCount();
            m_dwAutoAvoidTick = HUtil32.GetTickCount();// �Զ���ܼ��
            m_boAutoAvoid = false;// �Ƿ���
            m_boDoSpellMagic = true;// �Ƿ�ʹ��ħ��
            m_boGotoTargetXY = true;// �Ƿ�����Ŀ��
            this.m_nNextHitTime = 300;
            m_dwDoSpellMagicTick = HUtil32.GetTickCount();// ʹ��ħ�����
            m_SkillShieldTick = HUtil32.GetTickCount();// ħ����ʹ��ħ�����
            m_Skill_75_Tick = HUtil32.GetTickCount();// �������ʹ��ħ�����
            m_SkillBigHealling = HUtil32.GetTickCount();// Ⱥ��������ʹ�ü��
            m_SkillDejiwonho = HUtil32.GetTickCount();// ��ʥս����ʹ�ü��
            m_dwCheckDoSpellMagic = HUtil32.GetTickCount();
            m_nDieDropUseItemRate = 100;
            m_nButchItemTime = HUtil32.GetTickCount();// ����Ʒ���ʱ��
            m_ButchItemList = new ArrayList();// ���ι�����Ʒ�б�
            m_dwDoMotaeboTick = HUtil32.GetTickCount();// Ұ����ײʹ�ü��
            m_boProtectStatus = false;// �ػ�ģʽ
            m_boProtectOK = true;// �����ػ�����
            m_nGotoProtectXYCount = 0;// �����ػ�������ۼ���
        }
        
        ~TPlayMonster()
        {
            int I;
            if (m_ButchItemList.Count > 0)
            {
                for (I = 0; I < m_ButchItemList.Count; I ++ )// ���ι�����Ʒ�б�
                {
                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                    {
                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                    }
                }
            }
            m_ButchItemList = null;
        }

        public void InitializeMonster()
        {
            AddItemsFromConfig();
            switch (this.m_btJob)
            {
                case 0:
                    wSkill_11 = (ushort)CheckUserMagic(MagicConst.SKILL_FIRESWORD);// �һ𽣷�
                    wSkill_12 = (ushort)CheckUserMagic(MagicConst.SKILL_ERGUM);// ��ɱ����
                    wSkill_13 = (ushort)CheckUserMagic(MagicConst.SKILL_BANWOL);// �����䵶
                    wSkill_27 = (ushort)CheckUserMagic(MagicConst.SKILL_MOOTEBO);// Ұ����ײ
                    wSKILL_40 = (ushort)CheckUserMagic(MagicConst.SKILL_40);// ���µ���
                    wSKILL_42 = (ushort)CheckUserMagic(MagicConst.SKILL_42);// ����ն
                    wSKILL_43 = (ushort)CheckUserMagic(MagicConst.SKILL_43);// ��Ӱ����
                    wSKILL_74 = (ushort)CheckUserMagic(MagicConst.SKILL_74);// ���ս���
                    wSkill_75 = (ushort)CheckUserMagic(MagicConst.SKILL_75);
                    break;
                case 1:// �������
                    wSkill_01 = (ushort)CheckUserMagic(MagicConst.SKILL_LIGHTENING);// �׵���
                    wSkill_02 = (ushort)CheckUserMagic(MagicConst.SKILL_LIGHTFLOWER);// �����׹�
                    wSkill_03 = (ushort)CheckUserMagic(MagicConst.SKILL_SNOWWIND);// ������
                    wSkill_04 = (ushort)CheckUserMagic(MagicConst.SKILL_47);// ������
                    wSkill_05 = (ushort)CheckUserMagic(MagicConst.SKILL_SHIELD);// ħ����
                    wSkill_66 = (ushort)CheckUserMagic(MagicConst.SKILL_66);// �ļ�ħ����
                    wSKILL_58 = (ushort)CheckUserMagic(MagicConst.SKILL_58);// ���ǻ���
                    wSKILL_36 = (ushort)CheckUserMagic(MagicConst.SKILL_MABE);// �����
                    wSKILL_45 = (ushort)CheckUserMagic(MagicConst.SKILL_45);// �����
                    wSkill_75 = (ushort)CheckUserMagic(MagicConst.SKILL_75);// �������
                    if ((wSkill_01 == 0) && (wSkill_02 == 0) && (wSkill_03 == 0) && (wSkill_04 == 0))
                    {
                        m_boDoSpellMagic = false;
                    }
                    break;
                case 2:
                    wSkill_06 = (ushort)CheckUserMagic(MagicConst.SKILL_AMYOUNSUL);// ʩ����
                    wSkill_07 = (ushort)CheckUserMagic(MagicConst.SKILL_FIRECHARM);// �����
                    wSKILL_59 = (ushort)CheckUserMagic(MagicConst.SKILL_59);// ��Ѫ��
                    wSkill_14 = (ushort)CheckUserMagic(MagicConst.SKILL_HANGMAJINBUB);// �����
                    wSkill_73 = (ushort)CheckUserMagic(MagicConst.SKILL_73);// ������
                    wSkill_50 = (ushort)CheckUserMagic(MagicConst.SKILL_50);// �޼�����
                    wSkill_08 = (ushort)CheckUserMagic(MagicConst.SKILL_DEJIWONHO);// ��ʥս����
                    wSkill_09 = (ushort)CheckUserMagic(MagicConst.SKILL_BIGHEALLING);// Ⱥ��������
                    wSkill_10 = (ushort)CheckUserMagic(MagicConst.SKILL_GROUPAMYOUNSUL);// Ⱥ��ʩ����
                    wSkill_75 = (ushort)CheckUserMagic(MagicConst.SKILL_75);// �������
                    wSkill_48 = (ushort)CheckUserMagic(MagicConst.SKILL_48);// ������
                    wSkill_51 = (ushort)CheckUserMagic(MagicConst.SKILL_51);// 쫷���
                    if ((wSkill_06 == 0) && (wSkill_07 == 0) && (wSkill_10 == 0))
                    {
                        m_boDoSpellMagic = false;
                    }
                    break;
            }
        }

        public virtual void GotoTargetXY(int nTargetX, int nTargetY)
        {
            int I;
            byte nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            if (((this.m_nCurrX != nTargetX) || (this.m_nCurrY != nTargetY)))
            {
                n10 = nTargetX;
                n14 = nTargetY;
                
                this.dwTick3F4 = HUtil32.GetTickCount();
                nDir = Grobal2.DR_DOWN;
                if (n10 > this.m_nCurrX)
                {
                    nDir = Grobal2.DR_RIGHT;
                    if (n14 > this.m_nCurrY)
                    {
                        nDir = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        nDir = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n10 < this.m_nCurrX)
                    {
                        nDir = Grobal2.DR_LEFT;
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNLEFT;
                        }
                        if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                    }
                    else
                    {
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWN;
                        }
                        else if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UP;
                        }
                    }
                }
                nOldX = this.m_nCurrX;
                nOldY = this.m_nCurrY;
                if ((Math.Abs(this.m_nCurrX - nTargetX) >= 3) || (Math.Abs(this.m_nCurrY - nTargetY) >= 3))
                {
                    if (!this.RunTo(nDir, false, nTargetX, nTargetY))
                    {
                        this.WalkTo(nDir, false);
                        n20 = HUtil32.Random(3);
                        for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I ++ )
                        {
                            if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                            {
                                if (n20 != 0)
                                {
                                    nDir ++;
                                }
                                else if (nDir > 0)
                                {
                                    nDir -= 1;
                                }
                                else
                                {
                                    nDir = Grobal2.DR_UPLEFT;
                                }
                                if ((nDir > Grobal2.DR_UPLEFT))
                                {
                                    nDir = Grobal2.DR_UP;
                                }
                                this.WalkTo(nDir, false);
                            }
                        }
                    }
                }
                else
                {
                    this.WalkTo(nDir, false);
                    n20 = HUtil32.Random(3);
                    for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I ++ )
                    {
                        if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                        {
                            if (n20 != 0)
                            {
                                nDir ++;
                            }
                            else if (nDir > 0)
                            {
                                nDir -= 1;
                            }
                            else
                            {
                                nDir = Grobal2.DR_UPLEFT;
                            }
                            if ((nDir > Grobal2.DR_UPLEFT))
                            {
                                nDir = Grobal2.DR_UP;
                            }
                            this.WalkTo(nDir, false);
                        }
                    }
                }
            }
        }
       
        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            try {
                result = false;
                if (ProcessMsg.wIdent == Grobal2.RM_STRUCK)
                {
                    TBaseObject TBase = HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3);
                    if ((TBase == this) && (TBase != null))
                    {
                        this.SetLastHiter(TBase);
                        Struck(TBase);
                        this.BreakHolySeizeMode();// ������Լ�������ɫ,��Ӣ�۷���Ҳ����ɫ
                        if ((this.m_Master != null) && (TBase != this.m_Master) && ((TBase.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            || (TBase.m_btRaceServer == Grobal2.RC_HEROOBJECT)))
                        {
                            if (this.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                this.m_Master.SetPKFlag(TBase);
                            }
                            if (this.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                if ((this.m_Master.m_Master != null))
                                {
                                    if (TBase != this.m_Master.m_Master)
                                    {
                                        this.m_Master.SetPKFlag(TBase);
                                    }
                                }
                                else
                                {
                                    this.m_Master.SetPKFlag(TBase);
                                }
                            }
                        }
                        if (M2Share.g_Config.boMonSayMsg)
                        {
                            this.MonsterSayMsg((TBase), TMonStatus.s_UnderFire);
                        }
                    }
                    result = true;
                }
                else
                {
                    result = base.Operate(ProcessMsg);
                }
            }
            catch {
                M2Share.MainOutMessage("{�쳣} TPlayMonster.Operate");
            }
            return result;
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="hiter"></param>
        public  virtual void Struck(TBaseObject hiter)
        {
            byte btDir = 0;
            this.m_dwStruckTick = HUtil32.GetTickCount();
            if (hiter != null)
            {
                if ((this.m_TargetCret == null) || this.GetAttackDir(this.m_TargetCret, ref btDir) || (HUtil32.Random(6) == 0))
                {
                    if (this.IsProperTarget(hiter))
                    {
                        this.SetTargetCreat(hiter);
                    }
                }
            }
            if (this.m_boAnimal)//�Ƕ���
            {
                this.m_nMeatQuality = this.m_nMeatQuality - HUtil32.Random(300);
                if (this.m_nMeatQuality < 0)
                {
                    this.m_nMeatQuality = 0;
                }
            }
            this.m_dwHitTick = Convert.ToUInt32(this.m_dwHitTick + ((uint)150 - HUtil32._MIN(130, this.m_Abil.Level * 4)));
        }

        /// <summary>
        /// ����Ŀ��
        /// </summary>
        /// <param name="TargeTBaseObject"></param>
        /// <param name="nDir"></param>
        public virtual void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            base.AttackDir(TargeTBaseObject, m_wHitMode, nDir);
        }

        public override void DelTargetCreat()
        {
            base.DelTargetCreat();
            m_nTargetX =  -1;
            m_nTargetY =  -1;
        }

        public  void SearchTarget()
        {
            TBaseObject BaseObject;
            TBaseObject BaseObject18;
            int I;
            int nC;
            int n10;
            if (m_boProtectStatus)// �ػ�״̬
            {
                if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 12) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 12) || !m_boProtectOK) // ���ӣ�û���ܵ��ػ��㲻����Ŀ��
                {
                    return;
                }
            }
            BaseObject18 = null;
            n10 = 12;// ���ιֵ�̽����Χ
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I ++ )
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)  // Ŀ��ΪӢ��,�ҵȼ�������22��,����״̬,�򲻹���Ӣ��
                        {
                            if ((BaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (BaseObject.m_Abil.Level <= 22) && (((THeroObject)(BaseObject)).m_btStatus == 1))
                            {
                                continue;
                            }
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    n10 = nC;
                                    if (m_boProtectStatus)// �ػ�״̬
                                    {
                                        if ((Math.Abs(BaseObject.m_nCurrX - m_nProtectTargetX) <= 13) || (Math.Abs(BaseObject.m_nCurrY - m_nProtectTargetY) <= 13))
                                        {
                                            BaseObject18 = BaseObject;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        BaseObject18 = BaseObject;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (BaseObject18 != null)
            {
                if (m_boProtectStatus)// �ػ�״̬
                {
                    if ((Math.Abs(BaseObject18.m_nCurrX - m_nProtectTargetX) > 11) || (Math.Abs(BaseObject18.m_nCurrY - m_nProtectTargetY) > 11))
                    {
                        GotoTargetXY(m_nProtectTargetX, m_nProtectTargetY);
                        return;
                    }
                }
                this.SetTargetCreat(BaseObject18);
            }
        }

        /// <summary>
        /// ���ù���Ŀ��
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        public virtual void SetTargetXY(int nX, int nY)
        {
            m_nTargetX = nX;
            m_nTargetY = nY;
        }

        public virtual void Wondering()
        {
            if ((HUtil32.Random(20) == 0))
            {
                if ((HUtil32.Random(4) == 1))
                {
                    this.TurnTo(HUtil32.Random(8));
                }
                else
                {
                    this.WalkTo(this.m_btDirection, false);
                }
            }
        }

        // ��鹥����ħ��
        private  bool CheckDoSpellMagic()
        {
            bool result;
            byte nCode;
            result = true;
            nCode = 0;
            try {
                if (this.m_btJob > 0)
                {
                    if (this.m_btJob == 1)
                    {
                        if ((wSkill_01 == 0) && (wSkill_02 == 0) && (wSkill_03 == 0) && (wSkill_04 == 0))
                        {
                            result = false;
                            return result;
                        }
                    }
                    if (this.m_btJob == 2)
                    {
                        if ((wSkill_06 == 0) && (wSkill_07 == 0) && (wSkill_10 == 0))
                        {
                            result = false;
                            return result;
                        }
                    }
                    if (this.m_WAbil.MP == 0)
                    {
                        result = false;
                        return result;
                    }
                    if (this.m_btJob == 2)
                    {
                        nCode = 1;
                        if ((wSkill_06 > 0) || (wSkill_10 > 0)) // ʩ����
                        {
                            nCode = 2;
                            if (((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1))) // �̶�
                            {
                                nCode = 3;
                                result = CheckUserItemType(2, 1);
                                if (result)
                                {
                                    return result;
                                }
                                nCode = 4;
                                if (GetUserItemList(2, 1) < 0)
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
                            }
                            nCode = 5;
                            if (((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))  // �춾
                            {
                                nCode = 6;
                                result = CheckUserItemType(2, 2);
                                if (result)
                                {
                                    return result;
                                }
                                nCode = 7;
                                if (GetUserItemList(2, 2) < 0)
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
                            }
                        }
                        if ((wSkill_07 > 0) || (wSKILL_59 > 0))// �����  ��Ѫ��
                        {
                            nCode = 8;
                            result = CheckUserItemType(1, 0);
                            if (result)
                            {
                                return result;
                            }
                            nCode = 9;
                            if (GetUserItemList(1, 0) < 0)
                            {
                                result = false;
                            }
                            else
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{�쳣} TPlayMonster.CheckDoSpellMagic Code:" + (nCode).ToString());
            }
            return result;
        }

        private bool Think()
        {
            bool result;
            int nOldX;
            int nOldY;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if ((this.m_Master != null) && (this.m_Master.m_nCurrX == this.m_nCurrX) && (this.m_Master.m_nCurrY == this.m_nCurrY))
                {
                    m_boDupMode = true;
                }
                else if ((HUtil32.GetTickCount() - m_dwThinkTick) > 3000)// 3 * 1000
                {
                    m_dwThinkTick = HUtil32.GetTickCount();
                    nCode = 1;
                    if (this.m_PEnvir.GetXYObjCount(this.m_nCurrX, this.m_nCurrY) >= 2)
                    {
                        m_boDupMode = true;
                    }
                    if (!this.IsProperTarget(this.m_TargetCret))
                    {
                        this.m_TargetCret = null;
                    }
                }
                nCode = 2;
                if (SearchPickUpItemOK())// ����Ʒ
                {
                    SearchPickUpItem(500);
                }
                nCode = 3;
                EatMedicine();// ��ҩ
                nCode = 4;
                if ((HUtil32.GetTickCount() - m_dwCheckDoSpellMagic) > 1000)
                {
                    // ����Ƿ����ʹ��ħ��
                    m_dwCheckDoSpellMagic = HUtil32.GetTickCount();
                    m_boDoSpellMagic = CheckDoSpellMagic();
                }
                nCode = 5;
                if (StartAutoAvoid() && m_boDoSpellMagic)
                {
                    AutoAvoid();
                }
                // �Զ����
                nCode = 6;
                if (m_boDupMode)
                {
                    nOldX = this.m_nCurrX;
                    nOldY = this.m_nCurrY;
                    nCode = 7;
                    this.WalkTo((byte)HUtil32.Random(8), false);
                    if ((nOldX != this.m_nCurrX) || (nOldY != this.m_nCurrY))
                    {
                        m_boDupMode = false;
                        result = true;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TPlayMonster.Think Code:" + nCode);
            }
            return result;
        }

        // �Զ����
        // �Ƿ���Լ�����Ʒ
        private bool SearchPickUpItemOK()
        {
            bool result;
            TVisibleMapItem VisibleMapItem;
            TMapItem MapItem;
            int I;
            result = false;
            if ((this.m_VisibleItems.Count == 0) || (this.m_nCopyHumanLevel == 0))
            {
                return result;
            }
            if (this.m_Master == null)
            {
                return result;
            }
            if ((this.m_Master != null) && (this.m_Master.m_boDeath))
            {
                return result;
            }
            if (this.m_TargetCret != null)
            {
                if (this.m_TargetCret.m_boDeath)
                {
                    this.m_TargetCret = null;
                    result = true;
                }
            }
            // if (m_Master.m_WAbil.Weight >= m_Master.m_WAbil.MaxWeight) and (m_WAbil.Weight >= m_WAbil.MaxWeight) then Exit;
            if (this.m_TargetCret == null)
            {
                if (this.m_VisibleItems.Count > 0)
                {
                    // 20080630
                    for (I = 0; I < this.m_VisibleItems.Count; I ++ )
                    {
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        if ((VisibleMapItem != null))
                        {
                            if ((VisibleMapItem.nVisibleFlag > 0))
                            {
                                MapItem = VisibleMapItem.MapItem;
                                if ((MapItem != null))
                                {
                                    if ((MapItem.DropBaseObject != this.m_Master))
                                    {
                                        if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName))
                                        {
                                            // if (MapItem.DropBaseObject <> nil) and (TBaseObject(MapItem.DropBaseObject).m_btRaceServer = RC_PLAYOBJECT) then Continue;
                                            if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                            {
                                                result = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                // for
                }
            }
            if (result)
            {
                if ((this.m_ItemList.Count >= M2Share.g_Config.nCopyHumanBagCount) && !m_boCanPickUpItem)
                {
                    result = false;
                }
                if (m_boCanPickUpItem && (!((TPlayObject)(this.m_Master)).IsEnoughBag()) && (this.m_ItemList.Count >= M2Share.g_Config.nCopyHumanBagCount))
                {
                    result = true;
                }
            }
            return result;
        }

        // �Զ����
        public int AutoAvoid_GetAvoidDir()
        {
            int result;
            int n10;
            int n14;
            n10 = this.m_TargetCret.m_nCurrX;
            n14 = this.m_TargetCret.m_nCurrY;
            result = Grobal2.DR_DOWN;
            if (n10 > this.m_nCurrX)
            {
                result = Grobal2.DR_LEFT;
                if (n14 > this.m_nCurrY)
                {
                    result = Grobal2.DR_DOWNLEFT;
                }
                if (n14 < this.m_nCurrY)
                {
                    result = Grobal2.DR_UPLEFT;
                }
            }
            else
            {
                if (n10 < this.m_nCurrX)
                {
                    result = Grobal2.DR_RIGHT;
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                    else if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                }
            }
            return result;
        }

        public byte AutoAvoid_GetDirXY(int nTargetX, int nTargetY)
        {
            byte result;
            int n10;
            int n14;
            n10 = nTargetX;
            n14 = nTargetY;
            result = Grobal2.DR_DOWN;
            if (n10 > this.m_nCurrX)
            {
                result = Grobal2.DR_RIGHT;
                if (n14 > this.m_nCurrY)
                {
                    result = Grobal2.DR_DOWNRIGHT;
                }
                if (n14 < this.m_nCurrY)
                {
                    result = Grobal2.DR_UPRIGHT;
                }
            }
            else
            {
                if (n10 < this.m_nCurrX)
                {
                    result = Grobal2.DR_LEFT;
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNLEFT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UPLEFT;
                    }
                }
                else
                {
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                    else if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                }
            }
            return result;
        }

        public bool AutoAvoid_GetGotoXY(int nDir, ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n01;
            result = false;
            n01 = 0;
            while (true)
            {
                switch(nDir)
                {
                    case Grobal2.DR_UP:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPRIGHT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_RIGHT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNRIGHT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY += 2;
                            n01 ++;
                            continue;
                        }
                    case Grobal2.DR_DOWN:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNLEFT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_LEFT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPLEFT:
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                }
            }
            return result;
        }

        public bool AutoAvoid_GetAvoidXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n10;
            int nDir;
            int nX;
            int nY;
            nX = nTargetX;
            nY = nTargetY;
            nDir = 0;
            result = AutoAvoid_GetGotoXY(this.m_btDirection, ref nTargetX, ref nTargetY);
            n10 = 0;
            while (true)
            {
                if (n10 >= 7)
                {
                    break;
                }
                if (result)
                {
                    break;
                }
                nTargetX = nX;
                nTargetY = nY;
                nDir = HUtil32.Random(7);
                result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                n10 ++;
            }
            this.m_btDirection = (byte)nDir;
            // m_btDirection;

            return result;
        }

        public bool AutoAvoid_GotoMasterXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int nDir;
            result = false;
            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 5) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 5)))
            {
                nTargetX = this.m_nCurrX;
                nTargetY = this.m_nCurrY;
                nDir = AutoAvoid_GetDirXY(this.m_Master.m_nCurrX, this.m_Master.m_nCurrY);
                this.m_btDirection = (byte)nDir;
                switch(nDir)
                {
                    case Grobal2.DR_UP:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UP;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_RIGHT;
                        }
                        break;
                    case Grobal2.DR_RIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_RIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWN;
                        }
                        break;
                    case Grobal2.DR_DOWN:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNLEFT;
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWN;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_LEFT;
                        }
                        break;
                    case Grobal2.DR_LEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_DOWNLEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_LEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            this.m_btDirection = Grobal2.DR_UP;
                        }
                        break;
                }
            }
            return result;
        }

        // �Զ���ҩ
        // ------------------------------------------------------------------------------
        // ����ԭ�Զ���ܵĴ���,Ӧ��Ӣ�۵�Ԫ����Զ���ܴ�������޸�
        private bool AutoAvoid()
        {
            bool result = true;
            int nTargetX = 0;
            int nTargetY = 0;
            byte nDir;
            if ((this.m_TargetCret != null) && !this.m_TargetCret.m_boDeath)
            {
                if (AutoAvoid_GotoMasterXY(ref nTargetX, ref nTargetY))
                {
                    GotoTargetXY(nTargetX, nTargetY);
                }
                else
                {
                    nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                    nDir = this.GetBackDir(nDir);
                    this.m_PEnvir.GetNextPosition(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, nDir, 5, ref m_nTargetX, ref m_nTargetY);
                    GotoTargetXY(m_nTargetX, m_nTargetY);
                }
            }
            return result;
        }

        public unsafe bool SearchPickUpItem_PickUpItem(TVisibleMapItem VisibleMapItem)
        {
            bool result;
            TUserItem* UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
            TStdItem* StdItem;
            TMapItem MapItem;
            result = false;
            MapItem = this.m_PEnvir.GetItem(VisibleMapItem.nX, VisibleMapItem.nY);
            if (MapItem == null)
            {
                return result;
            }
            if ((VisibleMapItem.sName).ToLower().CompareTo((M2Share.sSTRING_GOLDNAME).ToLower()) == 0)
            {
                // m_nCurrX, m_nCurrY
                if (this.m_PEnvir.DeleteFromMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                {
                    if ((this.m_Master != null) && (!this.m_Master.m_boDeath) && (this.m_Master.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        // �񵽵�Ǯ�Ӹ�����
                        if (((TPlayObject)(this.m_Master)).IncGold(MapItem.Count))
                        {
                            //this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, VisibleMapItem.nX, VisibleMapItem.nY, "");
                            if (M2Share.g_boGameLogGold)
                            {
                                M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (VisibleMapItem.nX).ToString() + "\09" + (VisibleMapItem.nY).ToString() + "\09" + this.m_sCharName + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (MapItem.Count).ToString() + "\09" + "1" + "\09" + "0");
                            }
                            result = true;
                            this.m_Master.GoldChanged();
                            Dispose(MapItem);
                            //HUtil32.DisPoseAndNil(ref MapItem);
                        }
                        else
                        {
                            this.m_PEnvir.AddToMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                        }
                    }
                }
                return result;
            }
            else
            {
                if ((this.m_Master != null) && (!this.m_Master.m_boDeath)) // ����Ʒ
                {
                    // �񵽵���Ʒ�Ӹ�����
                    if (this.m_ItemList.Count < M2Share.g_Config.nCopyHumanBagCount)
                    {
                        // ��ҩƷ�ȸ��Լ�
                        StdItem = UserEngine.GetStdItem(MapItem.UserItem->wIndex);
                        if ((StdItem != null) && IsPickUpItem(StdItem))
                        {
                            if (this.m_PEnvir.DeleteFromMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                            {
                                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                for (int i = 0; i < 22; i++)
                                {
                                    UserItem->btValue[i] = 0;
                                }
                                UserItem = MapItem.UserItem;
                                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                if ((StdItem != null) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(UserItem->wIndex)))
                                {
                                    this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, HUtil32.ObjectToInt(MapItem), VisibleMapItem.nX, VisibleMapItem.nY, "");
                                    this.m_ItemList.Add((IntPtr)UserItem);
                                    if (StdItem->NeedIdentify == 1)
                                    {
                                        M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (VisibleMapItem.nX).ToString() + "\09" +
                                            (VisibleMapItem.nY).ToString() + "\09" + this.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen) + "\09" +
                                            (UserItem->MakeIndex).ToString() + "\09" + "(" + (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" +
                                            "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() +
                                            "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")"
                                            + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")" + (UserItem->btValue[0]).ToString() + "/"
                                            + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString() + "/"
                                            + (UserItem->btValue[4]).ToString() + "/" + (UserItem->btValue[5]).ToString() + "/" + (UserItem->btValue[6]).ToString() + "/" +
                                            (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString() + "\09" +
                                            (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                                    }
                                    result = true;
                                    Dispose(MapItem);
                                }
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                this.m_PEnvir.AddToMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                            }
                            return result;
                        }
                    }
                    if (((TPlayObject)(this.m_Master)).IsEnoughBag() && m_boCanPickUpItem)
                    {
                        // m_nCurrX, m_nCurrY
                        if (this.m_PEnvir.DeleteFromMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                        {
                            UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                            for (int i = 0; i < 22; i++)
                            {
                                UserItem->btValue[i] = 0;
                            }
                            UserItem = MapItem.UserItem;
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            if ((StdItem != null) && ((TPlayObject)(this.m_Master)).IsAddWeightAvailable(UserEngine.GetStdItemWeight(UserItem->wIndex)))
                            {
                                // m_nCurrX, m_nCurrY
                                //this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, VisibleMapItem.nX, VisibleMapItem.nY, "");
                                ((TPlayObject)(this.m_Master)).AddItemToBag(UserItem);
                                if (StdItem->NeedIdentify == 1)
                                {
                                    M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (VisibleMapItem.nX).ToString() + "\09" + (VisibleMapItem.nY).ToString() + "\09" +
                                        this.m_sCharName + " - " + this.m_Master.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen) + "\09" + (UserItem->MakeIndex).ToString()
                                        + "\09" + "(" +
                                        (HUtil32.LoWord(StdItem->DC)).ToString() + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" +
                                        (HUtil32.HiWord(StdItem->MC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" +
                                        (HUtil32.LoWord(StdItem->AC)).ToString() + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString()
                                        + ")" + (UserItem->btValue[0]).ToString() + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" +
                                        (UserItem->btValue[3]).ToString() + "/" + (UserItem->btValue[4]).ToString() + "/" + (UserItem->btValue[5]).ToString() + "/" +
                                        (UserItem->btValue[6]).ToString() + "/" + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" +
                                        (UserItem->btValue[14]).ToString() + "\09" + (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                                }
                                result = true;
                                Dispose(MapItem);
                                //HUtil32.DisPoseAndNil(ref MapItem);
                                if (!this.m_Master.m_boDeath)
                                {
                                    if ((((TPlayObject)(this.m_Master)).m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                    {
                                        ((TPlayObject)(this.m_Master)).SendAddItem(UserItem);
                                    }
                                    else if (this.m_Master.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        ((THeroObject)(this.m_Master)).SendAddItem(UserItem);
                                    }
                                }
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                this.m_PEnvir.AddToMap(VisibleMapItem.nX, VisibleMapItem.nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                            }
                        }
                    }
                }
            }
            return result;
        }

        private void SearchPickUpItem(uint dwSearchTime)
        {
            TMapItem MapItem;
            TVisibleMapItem VisibleMapItem;
            int I;
            byte nCode = 0;
            const string sExceptionMsg2 = "{�쳣} TPlayMonster::SearchItemRange 1-%d %s %s %d %d %d";
            try {
                nCode = 0;
                if (HUtil32.GetTickCount() - m_dwPickUpItemTick > dwSearchTime)
                {
                    m_dwPickUpItemTick = HUtil32.GetTickCount();
                    nCode = 1;
                    if (this.m_VisibleItems.Count > 0)
                    {
                        // 20080630
                        nCode = 2;
                        for (I = 0; I < this.m_VisibleItems.Count; I ++ )
                        {
                            VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                            nCode = 3;
                            if ((VisibleMapItem != null))
                            {
                                if ((VisibleMapItem.nVisibleFlag > 0))
                                {
                                    nCode = 4;
                                    MapItem = VisibleMapItem.MapItem;
                                    if ((MapItem != null))
                                    {
                                        if ((MapItem.DropBaseObject != this.m_Master))
                                        {
                                            nCode = 5;
                                            if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName))
                                            {
                                                nCode = 6;
                                                // if (MapItem.DropBaseObject <> nil) and (TBaseObject(MapItem.DropBaseObject).m_btRaceServer = RC_PLAYOBJECT) then Continue;
                                                // or IsOfGroup(TBaseObject(MapItem.OfBaseObject))
                                                if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                                {
                                                    // GotoTargetXY(VisibleMapItem.nX, VisibleMapItem.nY);
                                                    nCode = 7;
                                                    if (SearchPickUpItem_PickUpItem(VisibleMapItem))
                                                    {
                                                        // MainOutMessage('����Ʒ');
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    // for
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{�쳣} TPlayMonster.SearchPickUpItem Code:" + (nCode).ToString());
            }
        }

        // ����Ƿ���Լ������Ʒ
        // �ǲ��ǿ��Լ��ҩƷ
        private unsafe bool IsPickUpItem(TStdItem* StdItem)
        {
            bool result = false;
            if (StdItem->StdMode == 0)
            {
                if ((new ArrayList(new int[] { 0, 1, 2 }).Contains(StdItem->Shape)))
                {
                    result = true;
                }
            }
            else if (StdItem->StdMode == 31)
            {
                if (M2Share.GetBindItemType(StdItem->Shape) >= 0)
                {
                    result = true;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        // �Զ���ҩ
        public unsafe bool EatUseItems_EatItems(TStdItem* StdItem)
        {
            bool result = false;
            if (this.m_PEnvir.m_boNODRUG)
            {
                return result;
            }
            switch(StdItem->StdMode)
            {
                case 0:
                    switch(StdItem->Shape)
                    {
                        case 0:// ��ҩ
                            if ((StdItem->AC > 0))
                            {
                                this.m_nIncHealth += StdItem->AC;
                                result = true;
                            }
                            if ((StdItem->MAC > 0))
                            {
                                
                                this.m_nIncSpell += StdItem->MAC;
                                result = true;
                            }
                            break;
                        case 1:// ��ҩ
                            if ((StdItem->AC > 0) && (StdItem->MAC > 0))
                            {
                                this.IncHealthSpell(StdItem->AC, StdItem->MAC);
                                result = true;
                            }
                            break;
                    }
                    break;
            }
            return result;
        }

        public string EatUseItems_GetUnbindItemName(int nShape)
        {
            string result = string.Empty;
            if (M2Share.g_UnbindList.Count > 0)
            {
                for (int I = 0; I < M2Share.g_UnbindList.Count; I ++ )
                {
                    //if (((int)M2Share.g_UnbindList[I]) == nShape)
                    //{
                    //    result = M2Share.g_UnbindList[I];
                    //    break;
                    //}
                }
            }
            return result;
        }

        public unsafe bool EatUseItems_GetUnBindItems(string sItemName, int nCount)
        {
            bool result = false;
            TUserItem* UserItem = null;
            if (nCount <= 0)
            {
                nCount = 1;
            }
            for (int I = 0; I < nCount; I ++ )
            {
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (UserEngine.CopyToUserItemFromName(sItemName, UserItem))
                {
                    this.m_ItemList.Add((IntPtr)UserItem);
                    result = true;
                }
                else
                {
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    break;
                }
            }
            return result;
        }

        public unsafe bool EatUseItems_FoundUserItem(int nItemIdx)
        {
            bool result = false;
            TUserItem* UserItem;
            if (this.m_ItemList.Count > 0)
            {
                for (int I = 0; I < this.m_ItemList.Count; I ++ )
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem == null)
                    {
                        continue;
                    }
                    if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public unsafe int EatUseItems_FoundAddHealthItem(byte ItemType)
        {
            int result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = -1;
            if (this.m_ItemList.Count > 0)
            {
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem != null)
                    {
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if (StdItem != null)
                        {
                            switch (ItemType)
                            {
                                case 0:// ��ҩ
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->AC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 1:// ��ҩ
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->MAC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 2:// ̫��ˮ
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 1) && (StdItem->AC > 0) && (StdItem->MAC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 3:// ��ҩ��
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 4:// ��ҩ��
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 1))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 5:// ��ҩ
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 2))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public unsafe bool EatUseItems_UseAddHealthItem(int nItemIdx)
        {
            bool result;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = false;
            UserItem = (TUserItem*)this.m_ItemList[nItemIdx];
            if (UserItem != null)
            {
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem != null)
                {
                    if (!this.m_PEnvir.AllowStdItems(UserItem->wIndex))
                    {
                        return result;
                    }
                    switch (StdItem->StdMode)// , 1, 2, 3
                    {
                        case 0:// ҩ
                            if (EatUseItems_EatItems(StdItem))
                            {
                                if (UserItem != null)
                                {
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                }
                                this.m_ItemList.RemoveAt(nItemIdx);
                                result = true;
                            }
                            break;
                        case 31:// �����Ʒ
                            if ((StdItem->AniCount == 0) && (M2Share.GetBindItemType(StdItem->Shape) >= 0))
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                this.m_ItemList.RemoveAt(nItemIdx);
                                EatUseItems_GetUnBindItems(EatUseItems_GetUnbindItemName(StdItem->Shape), 6);
                                result = true;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        // ��ʿ����
        private bool EatUseItems(byte btItemType)
        {
            bool result;
            int nItemIdx;
            result = false;
            if (!this.m_boDeath)
            {
                nItemIdx = EatUseItems_FoundAddHealthItem(btItemType);
                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                {
                    result = EatUseItems_UseAddHealthItem(nItemIdx);
                }
                else
                {
                    switch(btItemType)
                    {
                        case 0:// ���ҽ����Ʒ
                            nItemIdx = EatUseItems_FoundAddHealthItem(3);
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = EatUseItems_UseAddHealthItem(nItemIdx);
                            }
                            else
                            {
                                nItemIdx = EatUseItems_FoundAddHealthItem(2);
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = EatUseItems_UseAddHealthItem(nItemIdx);
                                }
                                else
                                {
                                    nItemIdx = EatUseItems_FoundAddHealthItem(5);
                                    if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                    {
                                        result = EatUseItems_UseAddHealthItem(nItemIdx);
                                    }
                                }
                            }
                            break;
                        case 1:
                            nItemIdx = EatUseItems_FoundAddHealthItem(4);
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = EatUseItems_UseAddHealthItem(nItemIdx);
                            }
                            else
                            {
                                nItemIdx = EatUseItems_FoundAddHealthItem(2);
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = EatUseItems_UseAddHealthItem(nItemIdx);
                                }
                                else
                                {
                                    nItemIdx = EatUseItems_FoundAddHealthItem(5);
                                    if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                    {
                                        result = EatUseItems_UseAddHealthItem(nItemIdx);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            return result;
        }

        private bool AllowGotoTargetXY()
        {
            bool result = true;
            if ((this.m_btJob == 0) || !m_boDoSpellMagic || (this.m_TargetCret == null))
            {
                return result;
            }
            result = false;
            return result;
        }

        // �һ�
        new public bool AllowFireHitSkill()
        {
            bool result;
            result = false;
            if ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 10000) // 10 * 1000
            {
                this.m_dwLatestFireHitTick = HUtil32.GetTickCount();
                this.m_boFireHitSkill = true;
                result = true;
            }
            return result;
        }

        // ���ս���
        public override bool AllowDailySkill()
        {
            bool result;
            result = false;
            if ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 10000) // 10 * 1000
            {
                this.m_dwLatestDailyTick = HUtil32.GetTickCount();
                this.m_boDailySkill = true;
                result = true;
            }
            return result;
        }

        // �Ƿ���Ҫ���,��սʿ��
        private  bool StartAutoAvoid()
        {
            bool result;
            result = false;
            if (((HUtil32.GetTickCount() - m_dwAutoAvoidTick) > 3000) && m_boAutoAvoid) // �Ƿ���
            {
                if (((this.m_btJob > 0) || (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.25))) && m_boDoSpellMagic && (this.m_TargetCret != null) && (!this.m_TargetCret.m_boDeath))
                {
                    m_dwAutoAvoidTick = HUtil32.GetTickCount();
                    switch(this.m_btJob)
                    {
                        case 1:
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0)
                            {
                                result = true;
                            }
                            break;
                        case 2:
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 3) > 0)
                            {
                                result = true;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        // �Զ����״̬
        // �Ƿ�����Ŀ�� 20080206
        private bool IsNeedGotoXY()
        {
            bool result;
            result = false;
            
            // 3 * 1000
            if ((this.m_TargetCret != null) && ((HUtil32.GetTickCount() - m_dwAutoAvoidTick) > 3000) && (!m_boDoSpellMagic || (this.m_btJob == 0)))
            {
                // սʿ
                if (this.m_btJob > 0)
                {
                    if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                    {
                        result = true;
                    }
                }
                else
                {
                    switch(m_nSelectMagic)
                    {
                        case 12:
                            // ս 20081205
                            // ��ɱ
                            m_nSelectMagic = 0;
                            if ((wSkill_12 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY)))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // �������ʱ�Ĺ����ٶ�

                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 4;
                                            // ��ɱ
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // Ϊ����ʱ��DB���õĹ����ٶ�
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 4;
                                            // ��ɱ
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    // new
                                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 74:
                            // 12
                            // ���ս���
                            m_nSelectMagic = 0;
                            if ((wSKILL_74 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4))))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // �������ʱ�Ĺ����ٶ�
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 13;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // Ϊ����ʱ��DB���õĹ����ٶ�
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 13;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    if ((wSkill_12 > 0))
                                    {
                                        if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                        {
                                            result = true;
                                            return result;
                                        }
                                    }
                                    else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 43:
                            // 74
                            // ʵ�ָ�λ�ſ���
                            m_nSelectMagic = 0;
                            if ((wSKILL_42 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)) && (this.m_n42kill == 2))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 5)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 5) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 5))))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // �������ʱ�Ĺ����ٶ�
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {

                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // Ϊ����ʱ��DB���õĹ����ٶ�
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    if ((wSkill_12 > 0))
                                    {
                                        if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                        {
                                            result = true;
                                            return result;
                                        }
                                    }
                                    else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSKILL_42 > 0) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY)) && (new ArrayList(new int[] {1, 2}).Contains(this.m_n42kill)))
                            {
                                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0) || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2) || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                {
                                    if (this.m_Master != null)
                                    {
                                        // �������ʱ�Ĺ����ٶ�
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime)
                                        {
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                    else
                                    {
                                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                                        {
                                            // Ϊ����ʱ��DB���õĹ����ٶ�
                                            this.m_dwHitTick = HUtil32.GetTickCount();
                                            m_wHitMode = 9;
                                            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                            Attack(this.m_TargetCret, this.m_btDirection);
                                            this.BreakHolySeizeMode();
                                            return result;
                                        }
                                    }
                                }
                                else
                                {
                                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 7:
                        case 25:
                        case 26:
                            // 43
                            m_nSelectMagic = 0;
                            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        default:
                            if ((wSkill_12 > 0))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ȡ�������ĵ�MPֵ
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        private unsafe int GetSpellPoint(TUserMagic* UserMagic)
        {
            return (int)HUtil32.Round((double)UserMagic->MagicInfo.wSpell / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                + UserMagic->MagicInfo.btDefSpell;
        }

        /// <summary>
        /// ���2�ζ������
        /// </summary>
        /// <returns></returns>
        public bool DoSpellMagic_CheckActionStatus()
        {
            bool result = false;
            if (HUtil32.GetTickCount() - m_dwActionTick > 1000)
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
            }
            return result;
        }

        public unsafe int DoSpellMagic_DoSpell_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe ushort DoSpellMagic_DoSpell_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return Convert.ToUInt16(HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower
                  + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
        }

        public  int DoSpellMagic_DoSpell_GetPower13(TUserMagic UserMagic, int nInt)
        {
            int result;
            double d10;
            double d18;
            d10 = nInt / 3.0;
            d18 = nInt - d10;
            result = (int)HUtil32.Round(d18 / (UserMagic.MagicInfo.btTrainLv + 1) * (UserMagic.btLevel + 1) + d10 + (UserMagic.MagicInfo.btDefPower + HUtil32.Random(UserMagic.MagicInfo.btDefMaxPower - UserMagic.MagicInfo.btDefPower)));
            return result;
        }

        public unsafe void DoSpellMagic_DoSpell_DelUseItem()
        {
            if (this.m_UseItems[TPosition.U_BUJUK]->Dura < 100)
            {
                this.m_UseItems[TPosition.U_BUJUK]->Dura = 0;
                this.m_UseItems[TPosition.U_BUJUK]->wIndex = 0;
            }
        }

        public unsafe bool DoSpellMagic_DoSpell(TUserMagic* UserMagic, int wMagIdx, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            int nSpellPoint;
            bool boSpellFail;
            bool boSpellFire;
            int nPower = 0;
            int nAmuletIdx = 0;
            result = false;
            boSpellFail = false;
            boSpellFire = true;
            if ((Math.Abs(this.m_nCurrX - nTargetX) > M2Share.g_Config.nMagicAttackRage) || (Math.Abs(this.m_nCurrY - nTargetY) > M2Share.g_Config.nMagicAttackRage))
            {
                return result;
            }
            if (!DoSpellMagic_CheckActionStatus())
            {
                return result;
            }
            if (UserMagic->btLevel == 4)// 4������ �����,���,ħ����
            {
                if (wMagIdx == MagicConst.SKILL_45)
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, 101, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
                else if (wMagIdx == MagicConst.SKILL_FIRECHARM)
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, 100, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
                else if (wMagIdx == MagicConst.SKILL_66)
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
            }
            else
            {
                if (wMagIdx != MagicConst.SKILL_MOOTEBO)// ����Ұ����ײ
                {
                    this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                }
            }
            if ((TargeTBaseObject != null) && (TargeTBaseObject.m_boDeath))
            {
                TargeTBaseObject = null;
            }
            switch(wMagIdx)
            {
                case MagicConst.SKILL_LIGHTENING:// �׵���
                    nSpellPoint = GetSpellPoint(UserMagic);
                    if (nSpellPoint > 0)
                    {
                        if (this.m_WAbil.MP < nSpellPoint)
                        {
                            return result;
                        }
                        this.DamageSpell(nSpellPoint);
                    // HealthSpellChanged();
                    }
                    if (TargeTBaseObject != null)
                    {
                        if (this.IsProperTarget(TargeTBaseObject))
                        {
                            if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                            {
                                nPower = this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                                if (TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                                {
                                    nPower = (int)HUtil32.Round(nPower * 1.5);
                                }
                                //this.SendDelayMsg(this, Grobal2.RM_DELAYMAGIC, nPower, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                                result = true;
                            }
                            else
                            {
                                TargeTBaseObject = null;
                            }
                        }
                        else
                        {
                            TargeTBaseObject = null;
                        }
                    }
                    break;
                case MagicConst.SKILL_SHIELD:
                case MagicConst.SKILL_66:
                    // 31
                    // 66
                    // ħ���� �ļ�ħ���� 20080728
                    if (this.MagBubbleDefenceUp(UserMagic->btLevel, DoSpellMagic_DoSpell_GetPower(UserMagic, Magic.GetRPow(this.m_WAbil.MC) + 15)))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_73:// ������ 
                    if (this.MagBubbleDefenceUp(UserMagic->btLevel, DoSpellMagic_DoSpell_GetPower(UserMagic,Magic.GetRPow(this.m_WAbil.SC) + 15)))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_75:// �������
                    if (HUtil32.GetTickCount() - this.m_boProtectionTick < M2Share.g_Config.dwProtectionTick)
                    {
                        return result;
                    }
                    // �������ʹ�ü�� 20080109
                    if (this.MagProtectionDefenceUp(UserMagic->btLevel))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_SNOWWIND:
                    // 33
                    // ������
                    if (M2Share.MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic,DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, M2Share.g_Config.nSnowWindRange, MagicConst.SKILL_SNOWWIND))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_LIGHTFLOWER:
                    // 24
                    // �����׹�
                    if (M2Share.MagicManager.MagElecBlizzard(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1)))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_MOOTEBO:
                    // 27
                    // Ұ����ײ
                    result = true;
                    boSpellFire = false;
                    if (this.GetAttackDir(TargeTBaseObject, ref this.m_btDirection))
                    {
                        // Ұ����ײ�ķ���
                        nSpellPoint = GetSpellPoint(UserMagic);
                        if (this.m_WAbil.MP >= nSpellPoint)
                        {
                            if (nSpellPoint > 0)
                            {
                                this.DamageSpell(nSpellPoint);
                                this.HealthSpellChanged();
                            }
                            if (DoMotaebo(this.m_btDirection, UserMagic->btLevel))
                            {
                                if (UserMagic->btLevel < 3)
                                {
                                    if (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] < this.m_Abil.Level)
                                    {
                                        this.TrainSkill(UserMagic, HUtil32.Random(3) + 1);
                                        this.CheckMagicLevelup(UserMagic);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case MagicConst.SKILL_MABE:
                    // ����� 
                    //nPower = this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + this.HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - this.HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                    if (MabMabe(this, TargeTBaseObject, nPower, UserMagic->btLevel, nTargetX, nTargetY))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_45:
                    // ����� 20080410
                    if (MagMakeFireDay(this, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_47:
                    // ������
                    if (M2Share.MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, M2Share.g_Config.nFireBoomRage, MagicConst.SKILL_47))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_58:
                    // ���ǻ��� 20080528
                    if (M2Share.MagicManager.MagBigExplosion1(this, this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, M2Share.g_Config.nMeteorFireRainRage))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_AMYOUNSUL:
                    // ��ʿ
                    // 6
                    // ʩ����
                    if (M2Share.MagicManager.MagLightening(this, UserMagic, nTargetX, nTargetY, TargeTBaseObject, ref boSpellFail))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_50:
                    // �޼����� 20080405
                    if (AbilityUp(UserMagic))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_51:
                    // 쫷��� 20080917
                    if (M2Share.MagicManager.MagGroupFengPo(this, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_48:
                    // ������ 20090111
                    if (M2Share.MagicManager.MagPushArround(this, UserMagic->btLevel) > 0)
                    {
                        result = true;
                    }
                    break;
                case MagicConst.SKILL_FIRECHARM:
                case MagicConst.SKILL_HANGMAJINBUB:
                case MagicConst.SKILL_DEJIWONHO:
                case MagicConst.SKILL_59:
                    // 13
                    // 14
                    // 15
                    boSpellFail = true;
                    //if (Magic.CheckAmulet(this, 1, 1, ref nAmuletIdx))
                    //{
                    //    Magic.UseAmulet(this, 1, 1, ref nAmuletIdx);
                    //    switch(wMagIdx)
                    //    {
                    //        case MagicConst.SKILL_FIRECHARM:
                    //            // 13
                    //            // �����
                    //            if (M2Share.MagicManager.MagMakeFireCharm(this, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //        case MagicConst.SKILL_HANGMAJINBUB:
                    //            // �����
                    //            //nPower = this.GetAttackPower(UserMagic, DoSpellMagic_DoSpell_GetPower13(UserMagic,60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                    //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 1) > 0)
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //        case MagicConst.SKILL_DEJIWONHO:
                    //            // ��ʥս����
                    //            //nPower = this.GetAttackPower(UserMagic, DoSpellMagic_DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                    //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 0) > 0)
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //        case MagicConst.SKILL_59:
                    //            // ��Ѫ�� 20080528
                    //            if (M2Share.MagicManager.MagFireCharmTreatment(this, UserMagic, nTargetX, nTargetY, ref TargeTBaseObject))
                    //            {
                    //                result = true;
                    //            }
                    //            break;
                    //    }
                    //    boSpellFail = false;
                    //    DoSpellMagic_DoSpell_DelUseItem();
                    //}
                    break;
                case MagicConst.SKILL_GROUPAMYOUNSUL:
                    // 38 Ⱥ��ʩ����
                    boSpellFail = true;
                    //if (Magic.CheckAmulet(this, 1, 2, ref nAmuletIdx))
                    //{
                    //    Magic.UseAmulet(this, 1, 2, ref nAmuletIdx);
                    //    if (M2Share.MagicManager.MagGroupAmyounsul(this, UserMagic, nTargetX, nTargetY, TargeTBaseObject))
                    //    {
                    //        result = true;
                    //    }
                    //    boSpellFail = false;
                    //    DoSpellMagic_DoSpell_DelUseItem();
                    //}
                    break;
                case MagicConst.SKILL_BIGHEALLING:
                    // 29
                    // Ⱥ��������
                    nPower = this.GetAttackPower(DoSpellMagic_DoSpell_GetPower(UserMagic, DoSpellMagic_DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.SC) * 2, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) * 2 + 1);
                    if (M2Share.MagicManager.MagBigHealing(this, nPower, nTargetX, nTargetY))
                    {
                        result = true;
                    }
                    break;
            }
            m_dwActionTick = HUtil32.GetTickCount();
            // 20080715
            this.m_dwHitTick = HUtil32.GetTickCount();
            // 20080715
            m_boAutoAvoid = true;
            // �Ƿ��ܶ�� 20080715
            if (boSpellFire)
            {
                if (UserMagic->btLevel == 4)
                {
                    // 4������ ����� ��� 20080617
                    if (wMagIdx == MagicConst.SKILL_45)
                    {
                       // this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 101), MakeLong(nTargetX, nTargetY), (int)TargeTBaseObject, "");
                    }
                    else if (wMagIdx == MagicConst.SKILL_FIRECHARM)
                    {
                        //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 100), MakeLong(nTargetX, nTargetY), (int)TargeTBaseObject, "");
                    }
                }
                else
                {
                    //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), MakeLong(nTargetX, nTargetY), (int)TargeTBaseObject, "");
                }
            }
            return result;
        }

        /// <summary>
        /// ʹ��ħ��
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        private unsafe bool DoSpellMagic(ushort wMagIdx)
        {
            bool result = false;
            TBaseObject BaseObject;
            int I;
            int nSpellPoint;
            TUserMagic* UserMagic = null;
            int nNewTargetX;
            int nNewTargetY;
            try
            {
                switch (wMagIdx)
                {
                    case MagicConst.SKILL_ERGUM:// ��ɱ����
                        if (this.m_MagicErgumSkill != null)
                        {
                            if (!this.m_boUseThrusting)
                            {
                                this.m_boUseThrusting = true;
                            }
                            else
                            {
                                this.m_boUseThrusting = false;
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_BANWOL:// �����䵶
                        if (this.m_MagicBanwolSkill != null)
                        {
                            if (!this.m_boUseHalfMoon)
                            {
                                this.m_boUseHalfMoon = true;
                            }
                            else
                            {
                                this.m_boUseHalfMoon = false;
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_FIRESWORD:// �һ𽣷�
                        if (this.m_MagicFireSwordSkill != null)
                        {
                            if (AllowFireHitSkill())
                            {
                                nSpellPoint = GetSpellPoint(this.m_MagicFireSwordSkill);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        // HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_74:// //���ս���
                        if (this.m_Magic74Skill != null)
                        {
                            if (AllowDailySkill())
                            {
                                nSpellPoint = GetSpellPoint(this.m_Magic74Skill);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        // HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_42:// ����ն
                        if (this.m_Magic42Skill != null)
                        {
                            if (this.Skill42OnOff())
                            {
                                nSpellPoint = GetSpellPoint(this.m_Magic42Skill);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_43:// ��Ӱ����
                        if (this.m_Magic43Skill != null)
                        {
                            if (this.Skill43OnOff())
                            {
                                nSpellPoint = GetSpellPoint(UserMagic);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        return result;
                    case MagicConst.SKILL_40:// ���µ���
                        if (this.m_MagicCrsSkill != null)
                        {
                            if (!this.m_boCrsHitkill)
                            {
                                this.SkillCrsOnOff(true);
                            }
                            else
                            {
                                this.SkillCrsOnOff(false);
                            }
                        }
                        result = true;
                        return result;
                    default:
                        nNewTargetX = 0;
                        nNewTargetY = 0;
                        if (this.m_MagicList.Count > 0)
                        {
                            for (I = 0; I < this.m_MagicList.Count; I++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[I];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == wMagIdx))
                                {
                                    this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                    BaseObject = null;
                                    // ���Ŀ���ɫ����Ŀ��������Χ���������Χ��������Ŀ������
                                    if (this.CretInNearXY(this.m_TargetCret, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY))
                                    {
                                        BaseObject = this.m_TargetCret;
                                        nNewTargetX = BaseObject.m_nCurrX;
                                        nNewTargetY = BaseObject.m_nCurrY;
                                    }
                                    if (new ArrayList(new int[] { MagicConst.SKILL_DEJIWONHO, MagicConst.SKILL_HANGMAJINBUB }).Contains(wMagIdx))
                                    {
                                        // ����� ��ʥս����,�����,���Ŀ������Ϊ�Լ�  20080610 ԭ��ע��
                                        BaseObject = this;
                                        nNewTargetX = this.m_nCurrX;
                                        nNewTargetY = this.m_nCurrY;
                                    }
                                    result = DoSpellMagic_DoSpell(UserMagic, wMagIdx, nNewTargetX, nNewTargetY, BaseObject);
                                    break;
                                }
                            }
                        }
                        break;
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="wHitMode"></param>
        /// <returns></returns>
        private  bool WarrAttackTarget(ushort wHitMode)
        {
            bool result = false;
            byte bt06 = 0;
            if (this.m_TargetCret != null)
            {
                if ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (this.m_TargetCret.m_Abil.Level <= 22)
                    && (((THeroObject)(this.m_TargetCret)).m_btStatus == 1))// Ӣ��22��ǰ,����ʱ����
                {
                    DelTargetCreat();
                    return result;
                }
                else if (m_boProtectStatus)  // �ػ�״̬
                {
                    if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 13) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 13))
                    {
                        DelTargetCreat();
                        return result;
                    }
                }
                if (this.GetAttackDir(this.m_TargetCret, ref bt06))
                {
                    this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                    Attack(this.m_TargetCret, bt06);
                    this.BreakHolySeizeMode();
                    result = true;
                }
                else
                {
                    if ((this.m_TargetCret.m_PEnvir == this.m_PEnvir))
                    {
                        if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 12) && (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 12))
                        {
                            SetTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                        }
                    }
                    else
                    {
                        DelTargetCreat();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ��ҩ
        /// </summary>
        private  void EatMedicine()
        {
            int n01;
            if ((this.m_nCopyHumanLevel > 0) && (this.m_ItemList.Count > 0))
            {
                if (this.m_WAbil.HP < (this.m_WAbil.MaxHP * M2Share.g_Config.nCopyHumAddHPRate) / 100)
                {
                    n01 = 0;
                    while (this.m_WAbil.HP < this.m_WAbil.MaxHP)
                    {
                        if (n01 >= 2)// ������������ƿ
                        {
                            break;
                        }
                        EatUseItems(0);
                        if (this.m_ItemList.Count == 0)
                        {
                            break;
                        }
                        n01 ++;
                    }
                }
                if (this.m_WAbil.MP < (this.m_WAbil.MaxMP * M2Share.g_Config.nCopyHumAddMPRate) / 100)
                {
                    n01 = 0;
                    while (this.m_WAbil.MP < this.m_WAbil.MaxMP)
                    {
                        if (n01 >= 2)// ������������ƿ
                        {
                            break;
                        }
                        EatUseItems(1);
                        if (this.m_ItemList.Count == 0)
                        {
                            break;
                        }
                        n01 ++;
                    }
                }
                if ((this.m_ItemList.Count == 0) || (this.m_WAbil.HP < (this.m_WAbil.MaxHP * 20) / 100) || (this.m_WAbil.MP < (this.m_WAbil.MaxMP * 20) / 100))
                {
                    if (this.m_VisibleItems.Count > 0)
                    {
                        SearchPickUpItem(500);
                    }
                }
            }
        }

        // ����ħ��
        // ���ָ������ͷ�Χ������Ĺ�������
        private int CheckTargetXYCountOfDirection(int nX, int nY, int nDir, int nRange)
        {
            int result = 0;
            TBaseObject BaseObject;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I ++ )
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                switch(nDir)
                                {
                                    case Grobal2.DR_UP:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && (new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrY - nY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_UPRIGHT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrX - nX))) && (new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrY - nY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_RIGHT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrX - nX))) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNRIGHT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrX - nX))) && (new ArrayList(new int[] {0, nRange}).Contains((nY - BaseObject.m_nCurrY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWN:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && (new ArrayList(new int[] {0, nRange}).Contains((nY - BaseObject.m_nCurrY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNLEFT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((nX - BaseObject.m_nCurrX))) && (new ArrayList(new int[] {0, nRange}).Contains((nY - BaseObject.m_nCurrY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_LEFT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((nX - BaseObject.m_nCurrX))) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result ++;
                                        }
                                        break;
                                    case Grobal2.DR_UPLEFT:
                                        if ((new ArrayList(new int[] {0, nRange}).Contains((nX - BaseObject.m_nCurrX))) && (new ArrayList(new int[] {0, nRange}).Contains((BaseObject.m_nCurrY - nY))))
                                        {
                                            result ++;
                                        }
                                        break;
                                }
                                if (result > 2)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void WarrorAttackTarget_SelectMagic()
        {
            // Զ�������ÿ����ػ��������ս��� 20081211
            // 2
            // 20090105 �޸�,���ڻ�С��5
            // 2
            if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 5)) || ((Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 5)))
            {
                if ((wSKILL_42 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > M2Share.g_Config.nKill43UseTime * 1000))
                {
                    this.m_n42kill = 2;
                    // �ػ�
                    if (!this.m_bo42kill)
                    {
                        DoSpellMagic(MagicConst.SKILL_42);
                    }
                    // �򿪿���
                    m_nSelectMagic = 43;
                    // ��ѯħ�� 20081206
                    if (this.m_bo42kill)
                    {
                        return;
                    }
                }
                
                // 12 * 1000
                if ((wSKILL_74 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 12000))
                {
                    // ���ս���
                    if (!this.m_boDailySkill)
                    {
                        DoSpellMagic(MagicConst.SKILL_74);
                    }
                    // �����ս���
                    m_nSelectMagic = 74;
                    // ��ѯħ�� 20081206
                    return;
                }
            }
            // ��ɱλ 20081204
            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2))
            {
                if ((wSkill_12 > 0))
                {
                    // ��ɱ����
                    if (!this.m_boUseThrusting)
                    {
                        DoSpellMagic(MagicConst.SKILL_ERGUM);
                    }
                    m_nSelectMagic = 12;
                    // ��ѯħ�� 20081206
                    return;
                }
            }
            if ((wSKILL_42 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > M2Share.g_Config.nKill43UseTime * 1000))
            {
                // ����ն  20080203
                if (HUtil32.Random(M2Share.g_Config.n43KillHitRate) == 0)
                {
                    // ���� ������� 20080213
                    this.m_n42kill = 2;
                }
                else
                {
                    this.m_n42kill = 1;
                }
                if (!this.m_bo42kill)
                {
                    DoSpellMagic(MagicConst.SKILL_42);
                }
                // �򿪿���
                m_nSelectMagic = 43;
                // ��ѯħ�� 20081206
                if (this.m_bo42kill)
                {
                    return;
                }
            }
            if ((MagicConst.SKILL_43 > 0) && ((HUtil32.GetTickCount() - this.m_dwLatest43Tick) > M2Share.g_Config.nKill42UseTime * 1000))
            {
                // 20080619 ��Ӱ����
                if (!this.m_bo43kill)
                {
                    DoSpellMagic(MagicConst.SKILL_43);
                }
                if (this.m_bo43kill)
                {
                    return;
                }
            }
            if (this.m_boFireHitSkill)
            {
                DoSpellMagic(MagicConst.SKILL_FIRESWORD);
            }
            // �ر��һ�
            if (this.m_boUseThrusting)
            {
                DoSpellMagic(MagicConst.SKILL_ERGUM);
            }
            // �رմ�ɱ
            if (this.m_boUseHalfMoon)
            {
                DoSpellMagic(MagicConst.SKILL_BANWOL);
            }
            // �رհ���
            if (this.m_boCrsHitkill)
            {
                DoSpellMagic(MagicConst.SKILL_40);
            }
            // �رյ���
            // if m_bo43kill then DoSpellMagic(SKILL_43);            //�ر���Ӱ
            if (this.m_boDailySkill)
            {
                DoSpellMagic(MagicConst.SKILL_74);
            }
            // �ر����ս��� 20080528 20080619 ע��
            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 2))
            {
                switch(HUtil32.Random(5))
                {
                    case 0:
                        // Ŀ�����ʱ
                        if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // �򿪴�ɱ
                            m_nSelectMagic = 12;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        break;
                    case 1:
                        // ���µ���
                        if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // �򿪴�ɱ
                            m_nSelectMagic = 12;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // ���µ���
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        }
                        break;
                    case 2:
                        if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // �򿪴�ɱ
                            m_nSelectMagic = 12;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // ���µ���
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        break;
                    case 3:
                        if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // ���µ���
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // �򿪴�ɱ
                            m_nSelectMagic = 12;
                        // ��ѯħ�� 20081206
                        }
                        break;
                    case 4:
                        if ((wSKILL_40 > 0))
                        {
                            // ���µ���
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_12 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_ERGUM);
                            // �򿪴�ɱ
                            m_nSelectMagic = 12;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        break;
                }
            // Case Random(4) of
            }
            else
            {
                switch(HUtil32.Random(4))
                {
                    case 0:
                        // Ŀ�겻����
                        // 5
                        // 20080619
                        if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43)    //����Ӱ   20080619 ע��
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        break;
                    case 1:
                        // ���µ���
                        if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // ���µ���
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        }
                        break;
                    case 2:
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43);      //����Ӱ  20080619 ע��
                        if ((wSKILL_40 > 0))
                        {
                            // ���µ���
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43)        //����Ӱ  20080619 ע��
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        break;
                    case 3:
                        if ((wSkill_13 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_BANWOL);
                            // �򿪰���
                            m_nSelectMagic = 25;
                        // ��ѯħ�� 20081206
                        }
                        else if ((wSKILL_40 > 0))
                        {
                            // ���µ���
                            DoSpellMagic(MagicConst.SKILL_40);
                        }
                        else if ((wSkill_11 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_FIRESWORD);
                            // ʹ���һ�
                            m_nSelectMagic = 26;
                        // ��ѯħ�� 20081206
                        // else if (wSKILL_43 > 0) then DoSpellMagic(SKILL_43)      //����Ӱ   20080619 ע��
                        }
                        else if ((wSKILL_74 > 0))
                        {
                            DoSpellMagic(MagicConst.SKILL_74);
                            // �����ս��� 20080528
                            m_nSelectMagic = 74;
                        // ��ѯħ�� 20081206
                        }
                        break;
                }
            // Case Random(4) of
            }
        }

        // ������
        // սʿ���� �д���һ���Ż�
        private  bool WarrorAttackTarget()
        {
            bool result;
            result = false;
            try {
                m_wHitMode = 0;
                if (this.m_WAbil.MP > 0)
                {
                    // 20080420 ����
                    if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2)))
                    {
                        // ħ�����ܴ򵽹� 20080420
                        if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7)))
                        {
                            this.m_TargetCret = null;
                            return result;
                        }
                        else
                        {
                            GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                        }
                    }
                    
                    if ((wSkill_75 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (HUtil32.GetTickCount() - this.m_boProtectionTick > M2Share.g_Config.dwProtectionTick))
                    {
                        DoSpellMagic(wSkill_75);
                    }
                    // ������� 20080405

                    if ((wSkill_27 > 0) && ((HUtil32.GetTickCount() - m_dwDoMotaeboTick) > 10000) && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.8)))
                    {
                        if (this.m_TargetCret != null)
                        {
                            if ((this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                            {
                                m_dwDoMotaeboTick = HUtil32.GetTickCount();
                                DoSpellMagic(wSkill_27);
                                // Ұ����ײ 20081016
                                return result;
                            }
                        }
                    }
                    WarrorAttackTarget_SelectMagic();
                    // 20080405 �޸�
                    if (this.m_boUseThrusting)
                    {
                        // ʹ�ô�ɱ
                        m_wHitMode = 4;
                    }
                    else if (this.m_boUseHalfMoon)
                    {
                        // ʹ�ð���
                        m_wHitMode = 5;
                    }
                    else if (this.m_boCrsHitkill)
                    {
                        // �����䵶 20080410
                        m_wHitMode = 8;
                    }
                    else if (this.m_bo43kill)
                    {
                        // ʹ����Ӱ���� 20080201
                        m_wHitMode = 12;
                    }
                    else if (this.m_bo42kill)
                    {
                        // ʹ�ÿ���ն 20080201
                        m_wHitMode = 9;
                    }
                    else if (this.m_boFireHitSkill)
                    {
                        // ʹ���һ�
                        m_wHitMode = 7;
                    }
                    else if (this.m_boDailySkill)
                    {
                        m_wHitMode = 13;
                    }
                // ʹ�����ս��� 20080528
                }
                result = WarrAttackTarget(m_wHitMode);
                if (result)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                }
            }
            catch {
            }
            return result;
        }

        /// <summary>
        /// ���ʹ�õ�ħ��
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        private unsafe int CheckUserMagic(int wMagIdx)
        {
            int result = 0;
            TUserMagic* UserMagic;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I ++ )
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = wMagIdx;
                        break;
                    }
                }
            }
            return result;
        }

        private unsafe ushort CheckUserMagic(ushort wMagIdx)
        {
            ushort result = 0;
            TUserMagic* UserMagic;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = wMagIdx;
                        break;
                    }
                }
            }
            return result;
        }

        // ���ʹ�õ�ħ��
        // ȡָ�����귶Χ�ڵ�Ŀ������
        private int CheckTargetXYCount(int nX, int nY, int nRange)
        {
            int result;
            TBaseObject BaseObject;
            int nC;
            int n10;
            result = 0;
            n10 = nRange;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I ++ )
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(nX - BaseObject.m_nCurrX) + Math.Abs(nY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    result ++;
                                    if (result > 2)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // ��ʦ����
        public int WizardAttackTarget_SearchDoSpell()
        {
            int result;
            result = 0;

            if ((wSkill_75 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (HUtil32.GetTickCount() - this.m_boProtectionTick > M2Share.g_Config.dwProtectionTick))
            {
                // ʹ�� �������
                result = wSkill_75;
                return result;
            }
            if ((this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence))
            {
                // ʹ�� ħ����
                if ((wSkill_66 > 0))
                {
                    result = wSkill_66;
                    return result;
                }
                else if ((wSkill_05 > 0))
                {
                    result = wSkill_05;
                    return result;
                }
            }
            if (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1)
            {
                // ȡָ�����귶Χ�ڵ�Ŀ������
                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 1))
                {
                    if ((this.m_Master != null) && (wSkill_02 > 0))
                    {
                        // ���ο���ʹ�õ����׹�
                        if (new ArrayList(new int[] {91, 92, 97, 101, 102, 104}).Contains(this.m_TargetCret.m_btRaceServer))
                        {
                            result = wSkill_02;
                            return result;
                        }
                    }
                    if ((wSkill_02 > 0) && (this.m_Master == null))
                    {
                        result = wSkill_02;
                    }
                    else if (wSkill_03 > 0)
                    {
                        result = wSkill_03;
                    }
                    else if (wSkill_04 > 0)
                    {
                        result = wSkill_04;
                    }
                    else if (wSkill_01 > 0)
                    {
                        result = wSkill_01;
                    }
                    else if (wSKILL_45 > 0)
                    {
                        result = wSKILL_45;
                    }
                    return result;
                }
                else
                {
                    if ((wSkill_03 > 0) && (wSkill_04 > 0) && (wSKILL_45 > 0) && (wSKILL_36 > 0) && (wSKILL_58 > 0))
                    {
                        switch(HUtil32.Random(5))
                        {
                            case 0:
                                result = wSkill_03;
                                break;
                            case 1:
                                result = wSkill_04;
                                break;
                            case 2:
                                result = wSKILL_45;
                                break;
                            case 3:
                                result = wSKILL_36;
                                break;
                            case 4:
                                result = wSKILL_58;
                                break;
                        }
                        return result;
                    }
                    else
                    {
                        switch(HUtil32.Random(6))
                        {
                            case 0:
                                if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                break;
                            case 1:
                                if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                break;
                            case 2:
                                if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                break;
                            case 3:
                                if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                break;
                            case 4:
                                if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                else if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                break;
                            case 5:
                                if (wSKILL_58 > 0)
                                {
                                    result = wSKILL_58;
                                }
                                else if (wSkill_01 > 0)
                                {
                                    result = wSkill_01;
                                }
                                else if (wSKILL_45 > 0)
                                {
                                    result = wSKILL_45;
                                }
                                else if (wSkill_03 > 0)
                                {
                                    result = wSkill_03;
                                }
                                else if (wSkill_04 > 0)
                                {
                                    result = wSkill_04;
                                }
                                else if (wSKILL_36 > 0)
                                {
                                    result = wSKILL_36;
                                }
                                break;
                        }
                        return result;
                    }
                }
            }
            else
            {
                switch(HUtil32.Random(6))
                {
                    case 0:
                        if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        break;
                    case 1:
                        if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        break;
                    case 2:
                        if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        break;
                    case 3:
                        if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        break;
                    case 4:
                        if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        break;
                    case 5:
                        if (wSKILL_58 > 0)
                        {
                            result = wSKILL_58;
                        }
                        else if (wSKILL_45 > 0)
                        {
                            result = wSKILL_45;
                        }
                        else if (wSkill_03 > 0)
                        {
                            result = wSkill_03;
                        }
                        else if (wSkill_04 > 0)
                        {
                            result = wSkill_04;
                        }
                        else if (wSKILL_36 > 0)
                        {
                            result = wSKILL_36;
                        }
                        else if (wSkill_01 > 0)
                        {
                            result = wSkill_01;
                        }
                        break;
                }
            }
            return result;
        }

        // սʿ����
        private bool WizardAttackTarget()
        {
            bool result;
            int nMagicID;
            byte nCode;
            result = false;
            nCode = 0;
            try {
                m_wHitMode = 0;
                if (m_boDoSpellMagic && (this.m_TargetCret != null))
                {
                    nCode = 1;
                    nMagicID = WizardAttackTarget_SearchDoSpell();
                    nCode = 5;
                    if (nMagicID == 0)
                    {
                        m_boAutoAvoid = true; // �Ƿ��ܶ��
                    }
                    nCode = 6;
                    if (nMagicID > 0)
                    {
                        nCode = 2;
                        if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7) 
                            || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))// ħ�����ܴ򵽹�
                        {
                            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7)))
                            {
                                nCode = 3;
                                this.m_TargetCret = null;
                                return result;
                            }
                            else
                            {
                                GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                            }
                        }
                        nCode = 4;
                        if (!DoSpellMagic((ushort)nMagicID))
                        {
                            this.SendRefMsg(Grobal2.RM_MAGICFIREFAIL, 0, 0, 0, 0, "");
                        }
                        result = true;
                    }
                    else
                    {
                        result = WarrAttackTarget(m_wHitMode);
                    }
                }
                else
                {
                    result = WarrAttackTarget(m_wHitMode);
                }
                this.m_dwHitTick = HUtil32.GetTickCount();
            }
            catch {
                M2Share.MainOutMessage("{�쳣} TPlayMonster.WizardAttackTarget:" + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// ��ʿ--��������Ƿ��з���
        /// </summary>
        /// <param name="nItemType"></param>
        /// <param name="StdItem"></param>
        /// <param name="nItemShape"></param>
        /// <returns></returns>
        private unsafe bool CheckItemType(int nItemType, TStdItem* StdItem, int nItemShape)
        {
            bool result = false;
            switch (nItemType)
            {
                case 1:
                    if ((StdItem->StdMode == 25) && (StdItem->Shape == 5))
                    {
                        result = true;
                    }
                    break;
                case 2:
                    switch (nItemShape)
                    {
                        case 1:
                            if ((StdItem->StdMode == 25) && (StdItem->Shape == 1))
                            {
                                result = true;
                            }
                            break;
                        case 2:
                            if ((StdItem->StdMode == 25) && (StdItem->Shape == 2))
                            {
                                result = true;
                            }
                            break;
                    }
                    break;
            }
            return result;
        }

        // �ж�װ�����Ƿ���ָ������Ʒ
        private unsafe bool CheckUserItemType(int nItemType, int nItemShape)
        {
            bool result = false;
            TStdItem* StdItem;
            if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                if ((StdItem != null))
                {
                    switch (nItemType)
                    {
                        case 1:
                            if (this.m_UseItems[TPosition.U_ARMRINGL]->Dura >= nItemShape * 100)
                            {
                                result = CheckItemType(nItemType, StdItem, nItemShape);
                            }
                            break;
                        case 2:
                            result = CheckItemType(nItemType, StdItem, nItemShape);
                            break;
                    }
                }
            }
            return result;
        }

        private unsafe bool UseItem(int nItemType, int nIndex, int nItemShape)
        {
            bool result = false;
            TUserItem* UserItem;
            TUserItem* AddUserItem;
            TStdItem* StdItem;
            if ((nIndex >= 0) && (nIndex < this.m_ItemList.Count))
            {
                UserItem = (TUserItem*)this.m_ItemList[nIndex];
                if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                    if (StdItem != null)
                    {
                        if (CheckItemType(nItemType, StdItem, nItemShape))
                        {
                            result = true;
                        }
                        else
                        {
                            this.m_ItemList.RemoveAt(nIndex);
                            AddUserItem = this.m_UseItems[TPosition.U_BUJUK];
                            if (this.AddItemToBag(AddUserItem))
                            {
                                this.m_UseItems[TPosition.U_BUJUK] = UserItem;
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                result = true;
                            }
                            else
                            {
                                this.m_ItemList.Add((IntPtr)UserItem);
                            }
                        }
                    }
                    else
                    {
                        this.m_ItemList.RemoveAt(nIndex);
                        this.m_UseItems[TPosition.U_BUJUK] = UserItem;
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        result = true;
                    }
                }
                else
                {
                    this.m_ItemList.RemoveAt(nIndex);
                    this.m_UseItems[TPosition.U_BUJUK] = UserItem;
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    result = true;
                }
            }
            return result;
        }

        // ���������Ƿ��з��Ͷ�
        // nType Ϊָ������ 1 Ϊ����� 2 Ϊ��ҩ
        private unsafe int GetUserItemList(int nItemType, int nItemShape)
        {
            int result = -1;
            TUserItem* UserItem;
            TStdItem* StdItem;
            for (int I = this.m_ItemList.Count - 1; I >= 0; I-- )
            {
                if (this.m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)this.m_ItemList[I];
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem != null)
                {
                    if (CheckItemType(nItemType, StdItem, nItemShape))
                    {
                        if (UserItem->Dura < 100)
                        {
                            this.m_ItemList.RemoveAt(I);
                            continue;
                        }
                        result = I;
                        break;
                    }
                }
            }
            return result;
        }

        public int TaoistAttackTarget_SearchDoSpell_GetMagic01()
        {
            int result;
            result = 0;
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1)))
            {
                // �̶�
                if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
                else if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
            }
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))
            {
                // �춾
                if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
                else if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
            }
            return result;
        }

        public int TaoistAttackTarget_SearchDoSpell_GetMagic02()
        {
            int result = 0;
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && (this.m_TargetCret.m_btRaceServer != 128) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1)))
            {
                // �̶�
                if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
                else if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
            }
            if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && (this.m_TargetCret.m_btRaceServer != 128) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))
            {
                // �춾
                if (wSkill_06 > 0)
                {
                    result = wSkill_06;
                }
                else if (wSkill_10 > 0)
                {
                    result = wSkill_10;
                }
            }
            return result;
        }

        public int TaoistAttackTarget_SearchDoSpell_GetMagic03()
        {
            int result = 0;
            if (CheckUserItemType(1, 0) || (GetUserItemList(1, 0) >= 0))
            {
                switch(HUtil32.Random(2))
                {
                    case 0:
                        if (wSkill_07 > 0)
                        {
                            // �����
                            result = wSkill_07;
                        }
                        else if (wSKILL_59 > 0)
                        {
                            result = wSKILL_59;
                        }
                        break;
                    case 1:
                        // ��Ѫ��
                        if (wSKILL_59 > 0)
                        {
                            // ��Ѫ��
                            result = wSKILL_59;
                        }
                        else if (wSkill_07 > 0)
                        {
                            result = wSkill_07;
                        }
                        break;
                // �����
                }
            }
            return result;
        }

        // ��ʿ����
        public  int TaoistAttackTarget_SearchDoSpell()
        {
            int result = 0;
            try {
                if (this.m_TargetCret == null)
                {
                    return result;
                }
                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                {
                    if ((wSkill_08 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && (CheckUserItemType(1, 0) || (GetUserItemList(1, 0) >= 0)))
                    {
                        result = wSkill_08;// ʹ����ʥս����
                        return result;
                    }
                    if ((wSkill_14 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && (CheckUserItemType(1, 0) || (GetUserItemList(1, 0) >= 0)))
                    {
                        result = wSkill_14;// ʹ�������
                        return result;
                    }
                }
                if ((wSkill_50 > 0) && (this.m_wStatusArrValue[2] == 0) && (HUtil32.GetTickCount() - m_nSkill_5Tick > 15000)) // �޼�����
                {
                    m_nSkill_5Tick = HUtil32.GetTickCount();// �޼�����ʹ�ü��
                    result = wSkill_50;
                    return result;
                }
                if ((wSkill_75 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) 
                    && (!this.m_boProtectionDefence) && (HUtil32.GetTickCount() - this.m_boProtectionTick > M2Share.g_Config.dwProtectionTick))// ʹ�� �������
                {
                    result = wSkill_75;
                    return result;
                }
                else if ((wSkill_73 > 0) && (this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (wSkill_75 == 0)) // ʹ�� ������
                {
                    result = wSkill_73;
                    return result;
                }
                if (wSkill_51 > 0)
                {
                    if (HUtil32.Random(4) == 0)
                    {
                        result = wSkill_51;// 쫷���
                        return result;
                    }
                }
                if (wSkill_48 > 0)
                {
                    if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level <= this.m_WAbil.Level) 
                        && (HUtil32.GetTickCount() - m_nSkill_48Tick > 5000))// ������
                    {
                        m_nSkill_48Tick = HUtil32.GetTickCount();// ������ʹ�ü��
                        result = wSkill_48;
                        return result;
                    }
                }
                if (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1)
                {
                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1))) // �̶�
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic01();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))// �춾
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic01();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic01();
                        }
                    }
                }
                else
                {
                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1)))// �̶�
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic02();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2))) // �춾
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic02();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        }
                    }
                    else
                    {
                        result = TaoistAttackTarget_SearchDoSpell_GetMagic03();
                        if (result == 0)
                        {
                            result = TaoistAttackTarget_SearchDoSpell_GetMagic02();
                        }
                    }
                }
            }
            catch {
            }
            return result;
        }

        // ��ʦ����
        private bool TaoistAttackTarget()
        {
            bool result = false;
            int nMagicID;
            int nIndex;
            byte nCode = 0;
            try {
                if (this.m_TargetCret.m_boDeath)// ��ֹ��������,���ιֻ���ʹ��ħ��,����M2����
                {
                    return result;
                }
                m_wHitMode = 0;
                nCode = 1;
                if (m_boDoSpellMagic && (this.m_TargetCret != null))
                {
                    nCode = 12;
                    nMagicID = TaoistAttackTarget_SearchDoSpell();
                    nCode = 13;
                    if (nMagicID == 0)
                    {
                        m_boAutoAvoid = true; // �Ƿ��ܶ��
                    }
                    nCode = 2;
                    if (nMagicID > 0)
                    {
                        if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7)
                            || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))// ħ�����ܴ򵽹�
                        {
                            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7)))
                            {
                                nCode = 3;
                                this.m_TargetCret = null;
                                return result;
                            }
                            else
                            {
                                GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                            }
                        }
                        nCode = 4;
                        switch(nMagicID)
                        {
                            case MagicConst.SKILL_AMYOUNSUL:// ʩ��
                            case MagicConst.SKILL_GROUPAMYOUNSUL:
                                if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && ((GetUserItemList(2, 1) >= 0) || CheckUserItemType(2, 1))) // �̶� 
                                {
                                    nCode = 5;
                                    if (!CheckUserItemType(2, 1))// ���װ��������Ʒ����
                                    {
                                        nCode = 6;
                                        nIndex = GetUserItemList(2, 1);// ȡ���������ƷID
                                        if (nIndex >= 0)
                                        {
                                            nCode = 7;
                                            UseItem(2, nIndex, 1);// �Զ�����
                                        }
                                    }
                                }
                                else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && ((GetUserItemList(2, 2) >= 0) || CheckUserItemType(2, 2)))// �춾
                                {
                                    nCode = 8;
                                    if (!CheckUserItemType(2, 2)) // ���װ��������Ʒ����
                                    {
                                        nCode = 9;
                                        nIndex = GetUserItemList(2, 2);// ȡ���������ƷID
                                        if (nIndex >= 0)
                                        {
                                            nCode = 10;
                                            UseItem(2, nIndex, 2);// �Զ�����
                                        }
                                    }
                                }
                                break;
                        }
                        nCode = 11;
                        if (!DoSpellMagic((ushort)nMagicID))
                        {
                            this.SendRefMsg(Grobal2.RM_MAGICFIREFAIL, 0, 0, 0, 0, "");
                        }
                        result = true;
                    }
                    else
                    {
                        result = WarrAttackTarget(m_wHitMode);
                    }
                }
                else
                {
                    result = WarrAttackTarget(m_wHitMode);
                }
                this.m_dwHitTick = HUtil32.GetTickCount();
            }
            catch {
                M2Share.MainOutMessage("{�쳣} TPlayMonster.TaoistAttackTarget Code:" + nCode);
            }
            return result;
        }

        public bool AttackTarget()
        {
            bool result = false;
            if (this.m_WAbil.MP < 100)
            {
                this.m_WAbil.MP = 100;
            }
            switch (this.m_btJob)
            {
                case 0:// ��MP����100ʱ,��ʼΪ100
                    if (this.m_Master != null)
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWarrorAttackTime) //  �������ʱ�Ĺ����ٶ�
                        {
                            m_nSelectMagic = 0;// ��ѯħ�� 
                            m_boAutoAvoid = false;// �Ƿ��ܶ��
                            result = WarrorAttackTarget();
                        }
                    }
                    else
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime) // Ϊ����ʱ��DB���õĹ����ٶ�
                        {
                            m_nSelectMagic = 0;// ��ѯħ��
                            m_boAutoAvoid = false;// �Ƿ��ܶ��
                            result = WarrorAttackTarget();
                        }
                    }
                    break;
                case 1:
                    if (this.m_Master != null)
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwWizardAttackTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// �Ƿ��ܶ��
                            result = WizardAttackTarget();
                        }
                    }
                    else
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// �Ƿ��ܶ��
                            result = WizardAttackTarget();
                        }
                    }
                    break;
                case 2:
                    if (this.m_Master != null)
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > M2Share.g_Config.dwTaoistAttackTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// �Ƿ��ܶ��
                            result = TaoistAttackTarget();
                        }
                    }
                    else
                    {
                        if (HUtil32.GetTickCount() - this.m_dwHitTick > this.m_nNextHitTime)
                        {
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            m_boAutoAvoid = false;// �Ƿ��ܶ��
                            result = TaoistAttackTarget();
                        }
                    }
                    break;
            }
            return result;
        }

        public  override void Run()
        {
            int nX = 0;
            int nY = 0;
            int nCheckCode;
            const string sExceptionMsg = "{�쳣} TPlayMonster.Run Code:%d";
            nCheckCode = 0;
            try
            {
                if ((!this.m_boGhost) && (!this.m_boDeath) && (!this.m_boFixedHideMode) && (!this.m_boStoneMode) && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCheckCode = 12;
                    if (Think())
                    {
                        base.Run();
                        return;
                    }
                    PlaySuperRock();// ��Ѫʯ����
                    nCheckCode = 1;
                    if (this.m_boFireHitSkill && ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 20000))// 20 * 1000
                    {
                        this.m_boFireHitSkill = false;// �ر��һ�
                    }
                    if (this.m_boDailySkill && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 20000))// 20 * 1000
                    {
                        this.m_boDailySkill = false;// �ر����ս���
                    }
                    nCheckCode = 2;
                    if ((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 1100)
                    {
                        this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        if ((this.m_TargetCret == null))
                        {
                            SearchTarget(); // ����Ŀ��
                        }
                    }
                    nCheckCode = 3;
                    if (this.m_boWalkWaitLocked)
                    {
                        if ((HUtil32.GetTickCount() - this.m_dwWalkWaitTick) > this.m_dwWalkWait)
                        {
                            this.m_boWalkWaitLocked = false;
                        }
                    }
                    nCheckCode = 4;
                    if (!this.m_boWalkWaitLocked && ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed))
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        this.m_nWalkCount++;
                        if (this.m_nWalkCount > this.m_nWalkStep)
                        {
                            this.m_nWalkCount = 0;
                            this.m_boWalkWaitLocked = true;
                            this.m_dwWalkWaitTick = HUtil32.GetTickCount();
                        }
                        nCheckCode = 5;
                        if (!m_boRunAwayMode)
                        {
                            if (!this.m_boNoAttackMode)
                            {
                                if (m_boProtectStatus) // �ػ�״̬,����̫Զ 
                                {
                                    if (!m_boProtectOK)// û�ߵ��ػ�����
                                    {
                                        if ((this.m_TargetCret != null))
                                        {
                                            this.m_TargetCret = null;
                                        }
                                        GotoTargetXY(m_nProtectTargetX, m_nProtectTargetY);
                                        m_nGotoProtectXYCount++;
                                        if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) <= 2) && (Math.Abs(this.m_nCurrY - m_nProtectTargetY) <= 2))
                                        {
                                            m_boProtectOK = true;
                                            m_nGotoProtectXYCount = 0;// �����ػ�������ۼ���
                                        }
                                        if ((m_nGotoProtectXYCount > 20) && !m_boProtectOK)// 20�λ�û���ߵ��ػ����꣬��ɻ�������
                                        {
                                            if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 13) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 13))
                                            {
                                                this.SpaceMove(this.m_PEnvir.sMapName, m_nProtectTargetX, m_nProtectTargetY, 1);// ��ͼ�ƶ�
                                                m_boProtectOK = true;
                                                m_nGotoProtectXYCount = 0;// �����ػ�������ۼ���
                                            }
                                        }
                                    }
                                }
                                if ((this.m_TargetCret != null))
                                {
                                    if ((!this.m_TargetCret.m_boDeath) && (this.m_TargetCret.m_WAbil.HP > 0))
                                    {
                                        nCheckCode = 51;
                                        if (AttackTarget())
                                        {
                                            base.Run();
                                            return;
                                        }
                                        nCheckCode = 6;
                                        if (StartAutoAvoid() && m_boDoSpellMagic)
                                        {
                                            AutoAvoid();// �Զ����
                                            base.Run();
                                            return;
                                        }
                                        else
                                        {
                                            nCheckCode = 61;
                                            if (IsNeedGotoXY())
                                            {
                                                nCheckCode = 62;
                                                GotoTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                                base.Run();
                                                return;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    m_nTargetX = -1;
                                    nCheckCode = 7;
                                    if (this.m_boMission)  // ��������˹���Ἧ��,����Ἧ���ƶ�
                                    {
                                        m_nTargetX = this.m_nMissionX;
                                        m_nTargetY = this.m_nMissionY;
                                    }
                                }
                            }
                            nCheckCode = 8;
                            if (this.m_Master != null)
                            {
                                if (this.m_TargetCret == null)
                                {
                                    nCheckCode = 81;
                                    this.m_Master.GetBackPosition(ref nX, ref nY);
                                    if ((Math.Abs(m_nTargetX - nX) > 1) || (Math.Abs(m_nTargetY - nY) > 1))
                                    {
                                        m_nTargetX = nX;
                                        m_nTargetY = nY;
                                        if ((Math.Abs(this.m_nCurrX - nX) <= 2) && (Math.Abs(this.m_nCurrY - nY) <= 2))
                                        {
                                            if (this.m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                            {
                                                m_nTargetX = this.m_nCurrX;
                                                m_nTargetY = this.m_nCurrY;
                                            }
                                        }
                                    }
                                }
                                if ((!this.m_Master.m_boSlaveRelax) && ((this.m_PEnvir != this.m_Master.m_PEnvir) || (Math.Abs(this.m_nCurrX - this.m_Master.m_nCurrX) > 20) || (Math.Abs(this.m_nCurrY - this.m_Master.m_nCurrY) > 20)))
                                {
                                    nCheckCode = 82;
                                    this.SpaceMove(this.m_Master.m_PEnvir.sMapName, m_nTargetX, m_nTargetY, 1);// ��ͼ�ƶ�
                                }
                            }
                            else
                            {
                                nCheckCode = 83;
                                if (m_boProtectStatus)// �ػ�״̬
                                {
                                    if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 13) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 13))
                                    {
                                        m_nTargetX = m_nProtectTargetX;
                                        m_nTargetY = m_nProtectTargetY;
                                        this.m_TargetCret = null;
                                        m_boProtectOK = false;
                                        GotoTargetXY(m_nTargetX, m_nTargetY);
                                        if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) <= 1) && (Math.Abs(this.m_nCurrY - m_nProtectTargetY) <= 1))
                                        {
                                            m_boProtectOK = true;
                                        }
                                    }
                                    else
                                    {
                                        m_nTargetX = -1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            nCheckCode = 9;

                            if ((m_dwRunAwayTime > 0) && ((HUtil32.GetTickCount() - m_dwRunAwayStart) > m_dwRunAwayTime))
                            {
                                m_boRunAwayMode = false;
                                m_dwRunAwayTime = 0;
                            }
                        }
                        if ((this.m_Master != null) && this.m_Master.m_boSlaveRelax)
                        {
                            base.Run();
                            return;
                        }
                        if ((this.m_TargetCret == null))
                        {
                            if ((m_nTargetX != -1) && AllowGotoTargetXY())// ����:��Χ����תȦȦ,ת������Ȧ�ٿ�һ��
                            {
                                nCheckCode = 10;
                                GotoTargetXY(m_nTargetX, m_nTargetY);
                            }
                            else
                            {
                                nCheckCode = 11;
                                Wondering();
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode));
            }
        }

        public unsafe bool AddItems(TUserItem* UserItem, int btWhere)
        {
            bool result = false;
            if (btWhere >= m_UseItems.GetLowerBound(0) && btWhere <= m_UseItems.GetUpperBound(0))
            {
                this.m_UseItems[btWhere] = UserItem;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// �������ι���ȡ�б�
        /// </summary>
        private void LoadButchItemList()
        {
            int I;
            string s24;
            TStringList LoadList;
            TMonItemInfo MonItem;
            string s28;
            string s2C;
            string s30 = string.Empty;
            int n18;
            int n1C;
            int n20;
            s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + this.m_sCharName + "-Item.txt";
            if (File.Exists(s24))
            {
                if (m_ButchItemList != null)
                {
                    if (m_ButchItemList.Count > 0)
                    {
                        for (I = 0; I < m_ButchItemList.Count; I ++ )
                        {
                            if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                            {
                                
                                Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                            }
                        }
                    }
                    m_ButchItemList.Clear();
                }
                LoadList = new TStringList();
                LoadList.LoadFromFile(s24);
                if (LoadList.Count > 0)
                {
                    for (I = 0; I < LoadList.Count; I ++ )
                    {
                        s28 = LoadList[I];
                        if ((s28 != "") && (s28[0] != ';'))
                        {
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "/", "\09"});
                            n18 = HUtil32.Str_ToInt(s30,  -1);
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "/", "\09"});
                            n1C = HUtil32.Str_ToInt(s30,  -1);
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "\09"});
                            if (s30 != "")
                            {
                                if (s30[0] == '\'')
                                {
                                    HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                                }
                            }
                            s2C = s30;
                            s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] {" ", "\09"});
                            n20 = HUtil32.Str_ToInt(s30, 1);
                            if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                            {
                                MonItem = new TMonItemInfo();
                                MonItem.SelPoint = n18 - 1;
                                MonItem.MaxPoint = n1C;
                                MonItem.ItemName = s2C;
                                MonItem.Count = n20;
                                if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)// ������� 1/10 ���10<=1 ��Ϊ���õ���Ʒ
                                {
                                    m_ButchItemList.Add(MonItem);
                                }
                            }
                        }
                    }
                }
                
                Dispose(LoadList);
            }
        }

        public unsafe void AddItemsFromConfig()
        {
            List<string> TempList;
            string sCopyHumBagItems = string.Empty;
            TUserItem* UserItem = null;
            string sFileName;
            IniFile ItemIni;
            string sMagic;
            string sMagicName;
            TMagic* Magic;
            TUserMagic* UserMagic = null;
            TStdItem* StdItem;
            string[] StdItemNameArray = new string[16 + 1];// ��չ��13 ֧�ֶ���
            if (this.m_nCopyHumanLevel > 0)
            {
                switch (this.m_btJob)
                {
                    case 0:
                        sCopyHumBagItems = M2Share.g_Config.sCopyHumBagItems1.Trim();
                        break;
                    case 1:
                        sCopyHumBagItems = M2Share.g_Config.sCopyHumBagItems2.Trim();
                        break;
                    case 2:
                        sCopyHumBagItems = M2Share.g_Config.sCopyHumBagItems3.Trim();
                        break;
                }
                if (sCopyHumBagItems != "")
                {
                    TempList = new List<string>();
                    fixed (char* Content = sCopyHumBagItems.Trim().ToCharArray())
                    {
                        HUtil32.ExtractStrings(new char[] { '|', '\\', '/', ',' }, new char[] { }, Content, TempList);
                    }
                    if (TempList.Count > 0)
                    {
                        for (int I = 0; I < TempList.Count; I++)
                        {
                            UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                            if (UserEngine.CopyToUserItemFromName(TempList[I], UserItem))
                            {
                                this.m_ItemList.Add((IntPtr)UserItem);
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                            }
                        }
                    }
                    Dispose(TempList);
                }
            }
            else
            {
                sFileName = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + this.m_sCharName + ".txt";
                if (File.Exists(sFileName))
                {
                    ItemIni = new IniFile(sFileName);
                    if (ItemIni != null)
                    {
                        m_boDropUseItem = ItemIni.ReadBool("Info", "DropUseItem", false);// �Ƿ��װ�� 
                        m_nDieDropUseItemRate = ItemIni.ReadInteger("Info", "DropUseItemRate", 100);// ������װ������
                        // m_nButchUserItemRate:= ItemIni.ReadInteger('Info','ButchUserItemRate',10);//����ȡʱ�����ڵ�����װ���ļ��� 
                        m_boButchUseItem = ItemIni.ReadBool("Info", "ButchUseItem", false);// �Ƿ�������ȡ����װ��
                        m_nButchRate = ItemIni.ReadInteger("Info", "ButchRate", 10);// ��ȡ����װ������ 
                        m_nButchChargeClass = (byte)ItemIni.ReadInteger("Info", "ButchChargeClass", 3);// ��ȡ����װ���շ�ģʽ(0��ң�1Ԫ����2���ʯ��3���)  
                        m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// ��ȡ����װ��ÿ���շѵ��� 
                        sCopyHumBagItems = ItemIni.ReadString("UseItems", "InitItems", "");// ������Ʒ �綾����Ʒ 
                        boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// ���ι����Ƿ���봥�� 
                        boIsDieEvent = ItemIni.ReadBool("Info", "IsDieEvent", false);// ��������ʬ��,�Ƿ���ʾ������Ч��(��������Ч��) 
                        m_boProtectStatus = ItemIni.ReadBool("Info", "ProtectStatus", false);// �Ƿ��ػ�ģʽ 
                        if (sCopyHumBagItems != "")
                        {
                            TempList = new List<string>();
                            try
                            {
                                fixed (char* Content = sCopyHumBagItems.Trim().ToCharArray())
                                {
                                    HUtil32.ExtractStrings(new char[] { '|', '\\', '/', ',' }, new char[] { }, Content, TempList);
                                }
                                if (TempList.Count > 0)
                                {
                                    for (int I = 0; I < TempList.Count; I++)
                                    {
                                        UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                        if (UserEngine.CopyToUserItemFromName(TempList[I], UserItem))
                                        {
                                            this.m_ItemList.Add((IntPtr)UserItem);
                                        }
                                        else
                                        {
                                            Marshal.FreeHGlobal((IntPtr)UserItem);
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                Dispose(TempList);
                            }
                        }
                        this.m_btJob = (byte)ItemIni.ReadInteger("Info", "Job", 0);// ְҵ
                        this.m_btGender = (byte)ItemIni.ReadInteger("Info", "Gender", 0);// �Ա�
                        this.m_btHair = (byte)ItemIni.ReadInteger("Info", "Hair", 0);// ͷ��
                        sMagic = ItemIni.ReadString("Info", "UseSkill", "");// ʹ��ħ��
                        if (sMagic != "")
                        {
                            TempList = new List<string>();
                            fixed (char* Content = sMagic.Trim().ToCharArray())
                            {
                                HUtil32.ExtractStrings(new char[] { '|', '\\', '/',',' }, new char[] { }, Content, TempList);
                            }
                            if (TempList.Count > 0)
                            {
                                for (int I = 0; I < TempList.Count; I++)
                                {
                                    sMagicName = TempList[I].Trim();
                                    if (FindMagic(sMagicName) == null)
                                    {
                                        Magic = UserEngine.FindMagic(sMagicName);
                                        if (Magic != null)
                                        {
                                            if ((Magic->btJob == 99) || (Magic->btJob == this.m_btJob))
                                            {
                                                UserMagic->MagicInfo = *Magic;
                                                UserMagic->wMagIdx = Magic->wMagicId;
                                                if (Magic->wMagicId == 66)
                                                {
                                                    UserMagic->btLevel = 4;// �ļ�ħ����
                                                }
                                                else
                                                {
                                                    UserMagic->btLevel = 3;
                                                }
                                                UserMagic->btKey = 0;
                                                UserMagic->nTranPoint = Magic->MaxTrain[3];
                                                this.m_MagicList.Add((IntPtr)UserMagic);
                                            }
                                        }
                                    }
                                }
                            }
                            Dispose(TempList);
                        }
                        //FillChar(StdItemNameArray, sizeof(StdItemNameArray), '\0');
                        StdItemNameArray[TPosition.U_DRESS] = ItemIni.ReadString("UseItems", "UseItems0", "");// '�·�';
                        StdItemNameArray[TPosition.U_WEAPON] = ItemIni.ReadString("UseItems", "UseItems1", "");// '����';
                        StdItemNameArray[TPosition.U_RIGHTHAND] = ItemIni.ReadString("UseItems", "UseItems2", "");// '������';
                        StdItemNameArray[TPosition.U_NECKLACE] = ItemIni.ReadString("UseItems", "UseItems3", "");// '����';
                        StdItemNameArray[TPosition.U_HELMET] = ItemIni.ReadString("UseItems", "UseItems4", "");// 'ͷ��';
                        StdItemNameArray[TPosition.U_ARMRINGL] = ItemIni.ReadString("UseItems", "UseItems5", "");// '������';
                        StdItemNameArray[TPosition.U_ARMRINGR] = ItemIni.ReadString("UseItems", "UseItems6", "");// '������';
                        StdItemNameArray[TPosition.U_RINGL] = ItemIni.ReadString("UseItems", "UseItems7", "");// '���ָ';
                        StdItemNameArray[TPosition.U_RINGR] = ItemIni.ReadString("UseItems", "UseItems8", "");// '�ҽ�ָ';
                        StdItemNameArray[TPosition.U_BUJUK] = ItemIni.ReadString("UseItems", "UseItems9", "");// '��Ʒ';
                        StdItemNameArray[TPosition.U_BELT] = ItemIni.ReadString("UseItems", "UseItems10", "");// '����';
                        StdItemNameArray[TPosition.U_BOOTS] = ItemIni.ReadString("UseItems", "UseItems11", "");// 'Ь��';
                        StdItemNameArray[TPosition.U_CHARM] = ItemIni.ReadString("UseItems", "UseItems12", "");// '��ʯ';
                        StdItemNameArray[TPosition.U_ZHULI] = ItemIni.ReadString("UseItems", "UseItems13", "");// '����'
                        for (int I = TPosition.U_DRESS; I <= TPosition.U_ZHULI; I++) // ����
                        {
                            if (StdItemNameArray[I] != "")
                            {
                                StdItem = UserEngine.GetStdItem(StdItemNameArray[I]);
                                if (StdItem != null)
                                {
                                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                                    if (UserEngine.CopyToUserItemFromName(StdItemNameArray[I], UserItem))
                                    {
                                        if (HUtil32.Random(M2Share.g_Config.nPlayMonRandomAddValue) == 0)
                                        {
                                            UserEngine.RandomUpgradeItem(UserItem);  // ����֧�ּ�Ʒװ��
                                        }
                                        AddItems(UserItem, I);
                                    }
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                }
                            }
                        }
                        LoadButchItemList();// �������ι���ȡ�б�
                        Dispose(ItemIni);
                    }
                }
            }
        }

        /// <summary>
        /// ����ħ��
        /// </summary>
        /// <param name="sMagicName"></param>
        /// <returns></returns>
        private unsafe TUserMagic* FindMagic(string sMagicName)
        {
            TUserMagic* result;
            TUserMagic* UserMagic;
            result = null;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sMagicName, 0, UserMagic->MagicInfo.MagicNameLen)).ToLower().CompareTo((sMagicName).ToLower()) == 0)
                    {
                        result = UserMagic;
                        break;
                    }
                }
            }
            return result;
        }

        // �޼�����
        // 0����������40%   1������60%   2������80%  3������100%  ʱ�䶼��6��
        private unsafe bool AbilityUp(TUserMagic* UserMagic)
        {
            int n14;
            bool result = false;
            int nSpellPoint = GetSpellPoint(UserMagic);
            if (nSpellPoint > 0)
            {
                if (this.m_WAbil.MP < nSpellPoint)
                {
                    return result;
                }
                n14 = (HUtil32.Random(10 + UserMagic->btLevel) + UserMagic->btLevel) * UserMagic->btLevel;
                this.m_dwStatusArrTimeOutTick[2] = Convert.ToUInt32(HUtil32.GetTickCount() + n14 * 1000);
                this.RecalcAbilitys();
                result = true;
            }
            return result;
        }

        public unsafe int MagMakeFireDay_MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe int MagMakeFireDay_GetPower(TUserMagic* UserMagic, int nPower)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        // �����
        private unsafe bool MagMakeFireDay(TBaseObject PlayObject, TUserMagic* UserMagic, int nTargetX, int nTargetY, ref TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int nPower;
            if (PlayObject.IsProperTarget(TargeTBaseObject))
            {
                if ((HUtil32.Random(10) >= TargeTBaseObject.m_nAntiMagic))
                {
                    nPower = PlayObject.GetAttackPower(MagMakeFireDay_GetPower(UserMagic,MagMakeFireDay_MPow(UserMagic)) + HUtil32.LoWord(PlayObject.m_WAbil.MC), ((short)HUtil32.HiWord(PlayObject.m_WAbil.MC) - HUtil32.LoWord(PlayObject.m_WAbil.MC)) + 1);
                    if (UserMagic->btLevel == 4)
                    {
                        nPower = nPower + M2Share.g_Config.nPowerLV4; // 4 ������
                    }
                    if (TargeTBaseObject.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                    {
                        nPower = (int)HUtil32.Round(nPower * 1.5);
                    }                    
                    //PlayObject.SendDelayMsg(PlayObject, Grobal2.RM_DELAYMAGIC, nPower, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                    if (M2Share.g_Config.boPlayObjectReduceMP)
                    {
                        // ���м�MPֵ,��35%
                        //TargeTBaseObject.DamageSpell(Math.Abs(HUtil32.Round(nPower * 0.35)));
                    }
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER) || (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        result = true;
                    }
                    else if (TargeTBaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                    {
                        result = true;
                    }
                }
                else
                {
                    TargeTBaseObject = null;
                }
            }
            else
            {
                TargeTBaseObject = null;
            }
            return result;
        }

        // �����
        private bool MabMabe(TBaseObject BaseObject, TBaseObject TargeTBaseObject, int nPower, int nLevel, int nTargetX, int nTargetY)
        {
            bool result = false;
            int nLv;
            if (BaseObject.MagCanHitTarget(BaseObject.m_nCurrX, BaseObject.m_nCurrY, TargeTBaseObject))
            {
                if (BaseObject.IsProperTarget(TargeTBaseObject) && (BaseObject != TargeTBaseObject))
                {
                    if ((TargeTBaseObject.m_nAntiMagic <= HUtil32.Random(10)) && (Math.Abs(TargeTBaseObject.m_nCurrX - nTargetX) <= 1) && (Math.Abs(TargeTBaseObject.m_nCurrY - nTargetY) <= 1))
                    {
                        //BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DELAYMAGIC, nPower / 3, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                        if ((HUtil32.Random(2) + (BaseObject.m_Abil.Level - 1)) > TargeTBaseObject.m_Abil.Level)
                        {
                            nLv = BaseObject.m_Abil.Level - TargeTBaseObject.m_Abil.Level;
                            if ((HUtil32.Random(M2Share.g_Config.nMabMabeHitRandRate) < HUtil32._MAX(M2Share.g_Config.nMabMabeHitMinLvLimit, (nLevel * 8) - nLevel + 15 + nLv)))
                            {
                                // 21
                                if ((HUtil32.Random(M2Share.g_Config.nMabMabeHitSucessRate) < nLevel * 2 + 4))
                                {
                                    if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        BaseObject.SetPKFlag(BaseObject);
                                        BaseObject.SetTargetCreat(TargeTBaseObject);
                                    }
                                    TargeTBaseObject.SetLastHiter(BaseObject);
                                    nPower = TargeTBaseObject.GetMagStruckDamage(BaseObject, nPower);
                                    //BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DELAYMAGIC, nPower, MakeLong(nTargetX, nTargetY), 2, (int)TargeTBaseObject, "", 600);
                                    if (!TargeTBaseObject.m_boUnParalysis)
                                    {
                                        // �ж����� - ���
                                        // 20
                                       // TargeTBaseObject.SendDelayMsg(BaseObject, Grobal2.RM_POISON, Grobal2.POISON_STONE, nPower / M2Share.g_Config.nMabMabeHitMabeTimeRate + HUtil32.Random(nLevel), (int)BaseObject, nLevel, "", 650);
                                    }
                                    result = true;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ��Ѫʯ����
        /// </summary>
        private unsafe void PlaySuperRock()
        {
            TStdItem* StdItem;
            int nTempDura = 0;
            try {
                if ((!this.m_boDeath) && (!this.m_boGhost) && (this.m_WAbil.HP > 0))
                {
                    if ((this.m_UseItems[TPosition.U_CHARM]->wIndex > 0) && (this.m_UseItems[TPosition.U_CHARM]->Dura > 0))
                    {
                        StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_CHARM]->wIndex);
                        if ((StdItem != null))
                        {
                            if ((StdItem->Shape > 0) && this.m_PEnvir.AllowStdItems(HUtil32.SBytePtrToString(StdItem->Name, StdItem->NameLen)))
                            {
                                switch (StdItem->Shape)
                                {
                                    case 1:// ��Ѫʯ
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= M2Share.g_Config.nStartHPRock)// �ĳɵ���������
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > M2Share.g_Config.nHPRockSpell)
                                            {
                                                dwRockAddHPTick = HUtil32.GetTickCount();// ��ʯ��HP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nHPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nHPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.HP > this.m_WAbil.MaxHP)
                                                {
                                                    this.m_WAbil.HP = this.m_WAbil.MaxHP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                    case 2:
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= M2Share.g_Config.nStartMPRock)// �ĳɵ���������
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > M2Share.g_Config.nMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();// ��ʯ��MP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = Convert.ToUInt16(HUtil32.Round((double)nTempDura / 10));
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.MP > this.m_WAbil.MaxMP)
                                                {
                                                    this.m_WAbil.MP = this.m_WAbil.MaxMP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                    case 3:
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= M2Share.g_Config.nStartHPMPRock) // �ĳɵ���������
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > M2Share.g_Config.nHPMPRockSpell)
                                            {
                                                dwRockAddHPTick = (uint)HUtil32.Round((double)nTempDura / 10);// ��ʯ��HP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = Convert.ToUInt16(HUtil32.Round((double)nTempDura / 10));
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += M2Share.g_Config.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.HP > this.m_WAbil.MaxHP)
                                                {
                                                    this.m_WAbil.HP = this.m_WAbil.MaxHP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        // ======================================================================
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= M2Share.g_Config.nStartHPMPRock)// �ĳɵ���������
                                        {
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > M2Share.g_Config.nHPMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();// ��ʯ��MP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > M2Share.g_Config.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= M2Share.g_Config.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura <= 0)
                                                    {
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += M2Share.g_Config.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.MP > this.m_WAbil.MaxMP)
                                                {
                                                    this.m_WAbil.MP = this.m_WAbil.MaxMP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{�쳣} TPlayMonster.PlaySuperRock");
            }
        }

        public  bool DoMotaebo_CanMotaebo(TBaseObject BaseObject, int nMagicLevel)
        {
            bool result;
            int nC;
            result = false;
            if ((this.m_Abil.Level > BaseObject.m_Abil.Level) && (!BaseObject.m_boStickMode))
            {
                nC = this.m_Abil.Level - BaseObject.m_Abil.Level;
                if (HUtil32.Random(20) < ((nMagicLevel * 4) + 6 + nC))
                {
                    if (this.IsProperTarget(BaseObject))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        // ���ν���Ұ����ײ 
        private  bool DoMotaebo(byte nDir, int nMagicLevel)
        {
            bool result;
            bool bo35;
            int I;
            int n20;
            int n24;
            int n28;
            TBaseObject PoseCreate;
            TBaseObject BaseObject_30 = null;
            TBaseObject BaseObject_34;
            int nX = 0;
            int nY = 0;
            result = false;
            bo35 = true;
            this.m_btDirection = nDir;
            BaseObject_34 = null;
            n24 = nMagicLevel + 1;
            n28 = n24;
            PoseCreate = this.GetPoseCreate();
            if (PoseCreate != null)
            {
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I ++ )
                {
                    PoseCreate = this.GetPoseCreate();
                    if (PoseCreate != null)
                    {
                        n28 = 0;
                        if (!DoMotaebo_CanMotaebo(PoseCreate,nMagicLevel))
                        {
                            break;
                        }
                        if (nMagicLevel >= 3)
                        {
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref nX, ref nY))
                            {
                                //BaseObject_30 = this.m_PEnvir.GetMovingObject(nX, nY, true);
                                if ((BaseObject_30 != null) && DoMotaebo_CanMotaebo(BaseObject_30, nMagicLevel))
                                {
                                    BaseObject_30.CharPushed(this.m_btDirection, 1);
                                }
                            }
                        }
                        BaseObject_34 = PoseCreate;
                        if (PoseCreate.CharPushed(this.m_btDirection, 1) != 1)
                        {
                            break;
                        }
                        this.GetFrontPosition(ref nX, ref nY);
                        if (this.m_PEnvir.MoveToMovingObject(this.m_nCurrX, this.m_nCurrY, this, nX, nY, false) > 0)
                        {
                            this.m_nCurrX = nX;
                            this.m_nCurrY = nY;
                            this.SendRefMsg(Grobal2.RM_RUSH, nDir, this.m_nCurrX, this.m_nCurrY, 0, "");
                            bo35 = false;
                            result = true;
                        }
                        n24 -= 1;
                    }
                }
            }
            else
            {
                bo35 = false;
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I ++ )
                {
                    this.GetFrontPosition(ref nX, ref nY);
                    // sub_004B2790
                    if (this.m_PEnvir.MoveToMovingObject(this.m_nCurrX, this.m_nCurrY, this, nX, nY, false) > 0)
                    {
                        this.m_nCurrX = nX;
                        this.m_nCurrY = nY;
                        this.SendRefMsg(Grobal2.RM_RUSH, nDir, this.m_nCurrX, this.m_nCurrY, 0, "");
                        n28 -= 1;
                    }
                    else
                    {
                        if (this.m_PEnvir.CanWalk(nX, nY, true))
                        {
                            n28 = 0;
                        }
                        else
                        {
                            bo35 = true;
                            break;
                        }
                    }
                }
            }
            if ((BaseObject_34 != null))
            {
                if (n24 < 0)
                {
                    n24 = 0;
                }
                n20 = HUtil32.Random((n24 + 1) * 10) + ((n24 + 1) * 10);
                n20 = BaseObject_34.GetHitStruckDamage(this, n20);
                BaseObject_34.StruckDamage(n20);
                BaseObject_34.SendRefMsg(Grobal2.RM_STRUCK, n20, BaseObject_34.m_WAbil.HP, BaseObject_34.m_WAbil.MaxHP, this.ToInt(), "");
                if (BaseObject_34.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                {
                    BaseObject_34.SendMsg(BaseObject_34, Grobal2.RM_STRUCK, n20, BaseObject_34.m_WAbil.HP, BaseObject_34.m_WAbil.MaxHP, this.ToInt(), "");
                }
            }
            if (bo35)
            {
                this.GetFrontPosition(ref nX, ref nY);
                this.SendRefMsg(Grobal2.RM_RUSHKUNG, this.m_btDirection, nX, nY, 0, "");
            }
            if (n28 > 0)
            {
                if (n24 < 0)
                {
                    n24 = 0;
                }
                n20 = HUtil32.Random(n24 * 10) + ((n24 + 1) * 3);
                n20 = this.GetHitStruckDamage(this, n20);
                this.StruckDamage(n20);
                this.SendRefMsg(Grobal2.RM_STRUCK, n20, this.m_WAbil.HP, this.m_WAbil.MaxHP, 0, "");
            }
            return result;
        }
    } 
}

