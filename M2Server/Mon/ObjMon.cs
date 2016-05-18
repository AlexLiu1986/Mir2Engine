using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameFramework;

namespace M2Server
{
    public class TMonster : TAnimalObject
    {
        public uint m_dwThinkTick = 0;
        public bool m_boDupMode = false;

        public TMonster()
            : base()
        {
            m_boDupMode = false;
            m_dwThinkTick = HUtil32.GetTickCount();
            m_nViewRange = 6;
            m_nRunTime = 250;
            m_dwSearchTime = Convert.ToUInt32(3000 + HUtil32.Random(2000));
            m_dwSearchTick = HUtil32.GetTickCount();
            m_btRaceServer = 80;
            m_boAddToMaped = false;// 地图是否计数
        }

        public  TBaseObject MakeClone(string sMonName, TBaseObject OldMon)
        {
            TBaseObject result = null;
            TBaseObject ElfMon;
            try
            {
                ElfMon = UserEngine.RegenMonsterByName(m_PEnvir.sMapName, m_nCurrX, m_nCurrY, sMonName);
                if ((ElfMon != null) && (OldMon != null))
                {
                    ElfMon.m_Master = OldMon.m_Master;
                    ElfMon.m_dwMasterRoyaltyTick = OldMon.m_dwMasterRoyaltyTick;
                    ElfMon.m_dwMasterRoyaltyTime = OldMon.m_dwMasterRoyaltyTime;// 怪物叛变计时
                    ElfMon.m_btSlaveMakeLevel = OldMon.m_btSlaveMakeLevel;
                    ElfMon.m_btSlaveExpLevel = OldMon.m_btSlaveExpLevel;
                    ElfMon.RecalcAbilitys();
                    ElfMon.RefNameColor();
                    if (OldMon.m_Master != null)
                    {
                        OldMon.m_Master.m_SlaveList.Add(ElfMon);
                    }
                    ElfMon.m_WAbil = OldMon.m_WAbil;
                    ElfMon.m_wStatusTimeArr = OldMon.m_wStatusTimeArr;
                    ElfMon.m_TargetCret = OldMon.m_TargetCret;
                    ElfMon.m_dwTargetFocusTick = OldMon.m_dwTargetFocusTick;
                    ElfMon.m_LastHiter = OldMon.m_LastHiter;
                    ElfMon.m_LastHiterTick = OldMon.m_LastHiterTick;
                    ElfMon.m_btDirection = OldMon.m_btDirection;
                    result = ElfMon;
                }
            }
            catch
            {
            }
            return result;
        }

        public  override bool Operate(TProcessMessage ProcessMsg)
        {
            return base.Operate(ProcessMsg);
        }

        private bool Think()
        {
            bool result = false;
            int nOldX;
            int nOldY;
            if ((HUtil32.GetTickCount() - m_dwThinkTick) > 3000)
            {
                m_dwThinkTick = HUtil32.GetTickCount();
                if (m_PEnvir.GetXYObjCount(m_nCurrX, m_nCurrY) >= 2)
                {
                    m_boDupMode = true;
                }
                if (!IsProperTarget(m_TargetCret))
                {
                    m_TargetCret = null;
                }
            }
            if (m_boDupMode)
            {
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                WalkTo((byte)HUtil32.Random(8), false);
                if ((nOldX != m_nCurrX) || (nOldY != m_nCurrY))
                {
                    m_boDupMode = false;
                    result = true;
                }
            }
            return result;
        }

        public  virtual bool AttackTarget()
        {
            bool result;
            byte bt06 = 0;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (m_TargetCret != null)
                {
                    nCode = 1;
                    if ((m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) //判断攻击目标是不是英雄
                        && (m_TargetCret.m_Abil.Level <= 22) && (((THeroObject)(m_TargetCret)).m_btStatus == 1))// 英雄22级前,跟随时不打
                    {
                        nCode = 2;
                        DelTargetCreat();
                        return result;
                    }
                    nCode = 3;
                    if (GetAttackDir(m_TargetCret, ref  bt06))
                    {
                        nCode = 4;
                        if (((int)HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
                        {
                            m_dwHitTick = HUtil32.GetTickCount();
                            m_dwTargetFocusTick = HUtil32.GetTickCount();
                            nCode = 5;
                            this.Attack(m_TargetCret, bt06);
                            nCode = 6;
                            m_TargetCret.SetLastHiter(this);
                            nCode = 7;
                            BreakHolySeizeMode();
                        }
                        result = true;
                    }
                    else
                    {
                        nCode = 8;
                        if (m_TargetCret.m_PEnvir == m_PEnvir)
                        {
                            nCode = 9;
                            if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                            {
                                nCode = 10;
                                SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                            }
                        }
                        else
                        {
                            nCode = 11;
                            DelTargetCreat();
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMonster.AttackTarget Code:" + nCode);
            }
            return result;
        }

        public override void Run()
        {
            int nX = 0;
            int nY = 0;
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boGhost && !m_boDeath && !m_boFixedHideMode && !m_boStoneMode && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCode = 1;
                    if (Think())
                    {
                        base.Run();
                        return;
                    }
                    nCode = 2;
                    if (m_boWalkWaitLocked)
                    {
                        if ((HUtil32.GetTickCount() - m_dwWalkWaitTick) > m_dwWalkWait)
                        {
                            m_boWalkWaitLocked = false;
                        }
                    }
                    nCode = 3;
                    if (!m_boWalkWaitLocked && (((int)HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed))
                    {
                        m_dwWalkTick = HUtil32.GetTickCount();
                        m_nWalkCount++;
                        if (m_nWalkCount > m_nWalkStep)
                        {
                            m_nWalkCount = 0;
                            m_boWalkWaitLocked = true;
                            m_dwWalkWaitTick = HUtil32.GetTickCount();
                        }
                        nCode = 4;
                        if (!m_boRunAwayMode)
                        {
                            if (!m_boNoAttackMode)
                            {
                                if (m_TargetCret != null)
                                {
                                    nCode = 5;
                                    if (AttackTarget())
                                    {
                                        nCode = 51;
                                        base.Run();
                                        return;
                                    }
                                }
                                else
                                {
                                    m_nTargetX = -1;
                                    if (m_boMission)
                                    {
                                        m_nTargetX = m_nMissionX;
                                        m_nTargetY = m_nMissionY;
                                    }
                                }
                            }
                            nCode = 6;
                            if (m_Master != null)
                            {
                                if (m_TargetCret == null)
                                {
                                    nCode = 7;
                                    if (!m_Master.m_boGhost)
                                    {
                                        m_Master.GetBackPosition(ref nX, ref nY);
                                        if ((Math.Abs(m_nTargetX - nX) > 1) || (Math.Abs(m_nTargetY - nY) > 1))
                                        {
                                            m_nTargetX = nX;
                                            m_nTargetY = nY;
                                            if ((Math.Abs(m_nCurrX - nX) <= 2) && (Math.Abs(m_nCurrY - nY) <= 2))
                                            {
                                                nCode = 8;
                                                if (m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                                {
                                                    m_nTargetX = m_nCurrX;
                                                    m_nTargetY = m_nCurrY;
                                                }
                                            }
                                        }
                                    }
                                }
                                nCode = 9;
                                if (m_Master != null)
                                {
                                    if (!m_Master.m_boGhost)
                                    {
                                        if ((!m_Master.m_boSlaveRelax) && ((m_PEnvir != m_Master.m_PEnvir) || (Math.Abs(m_nCurrX - m_Master.m_nCurrX) > 20) 
                                            || (Math.Abs(m_nCurrY - m_Master.m_nCurrY) > 20)))
                                        {
                                            nCode = 10;
                                            SpaceMove(m_Master.m_PEnvir.sMapName, m_nTargetX, m_nTargetY, 1);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            nCode = 11;
                            if ((m_dwRunAwayTime > 0) && ((HUtil32.GetTickCount() - m_dwRunAwayStart) > m_dwRunAwayTime))
                            {
                                m_boRunAwayMode = false;
                                m_dwRunAwayTime = 0;
                            }
                        }
                        nCode = 12;
                        if ((m_Master != null))
                        {
                            if (m_Master.m_boSlaveRelax)
                            {
                                base.Run();
                                return;
                            }
                        }
                        if (m_nTargetX != -1)
                        {
                            nCode = 13;
                            this.GotoTargetXY();
                        }
                        else
                        {
                            nCode = 14;
                            if (m_TargetCret == null)
                            {
                                Wondering();
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TMonster.Run Code:" + nCode);
            }
        }
    }

    public class TChickenDeer : TMonster
    {
        public TChickenDeer()
            : base()
        {
            m_nViewRange = 5;
        }

        public override void Run()
        {
            int nC;
            int n10;
            int n14;
            TBaseObject BaseObject1C;
            TBaseObject BaseObject;
            try
            {
                n10 = 9999;
                BaseObject = null;
                BaseObject1C = null;
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((int)HUtil32.GetTickCount() - m_dwWalkTick) >= m_nWalkSpeed)
                    {
                        if (m_VisibleActors.Count > 0)
                        {
                            foreach (var item in m_VisibleActors)
                            {
                                BaseObject = item.BaseObject;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                if (IsProperTarget(BaseObject))
                                {
                                    if (!BaseObject.m_boHideMode || m_boCoolEye)
                                    {
                                        nC = Math.Abs(m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(m_nCurrY - BaseObject.m_nCurrY);
                                        if (nC < n10)
                                        {
                                            n10 = nC;
                                            BaseObject1C = BaseObject;
                                        }
                                    }
                                }
                            }
                        }
                        if (BaseObject1C != null)
                        {
                            m_boRunAwayMode = true;
                            m_TargetCret = BaseObject1C;
                        }
                        else
                        {
                            m_boRunAwayMode = false;
                            m_TargetCret = null;
                        }
                    }
                    if (m_boRunAwayMode && (m_TargetCret != null) && (((int)HUtil32.GetTickCount() - m_dwWalkTick) >= m_nWalkSpeed))
                    {
                        if ((Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 6) && (Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 6))
                        {
                            n14 = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                            m_PEnvir.GetNextPosition(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY, n14, 5, ref m_nTargetX, ref m_nTargetY);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TChickenDeer.Run");
            }
            base.Run();
        }
    }

    public class TATMonster : TMonster
    {
        public TATMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }

        public override void Run()
        {
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000) || (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null)))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();// 搜索目标
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TATMonster.Run");
            }
            base.Run();
        }
    }

    public class TSlowATMonster : TATMonster
    {
        public TSlowATMonster()
            : base()
        {
        }
    }

    public class TScorpion : TATMonster
    {
        public TScorpion()
            : base()
        {
            m_boAnimal = true;
        }
    }

    public class TSpitSpider : TATMonster
    {
        public bool m_boUsePoison = false;

        public TSpitSpider()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_boAnimal = true;
            m_boUsePoison = true;
        }

        private void SpitAttack(byte btDir)
        {
            TAbility WAbil;
            int nC;
            int n10;
            int n14;
            int n18;
            int n1C;
            TBaseObject BaseObject;
            this.m_btDirection = btDir;
            WAbil = this.m_WAbil;
            n1C = HUtil32.Random((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1 + HUtil32.LoWord(WAbil.DC);
            if (n1C <= 0)
            {
                return;
            }
            SendRefMsg(Grobal2.RM_HIT, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            nC = 0;
            while ((nC < 5))
            {
                n10 = 0;
                while ((n10 < 5))
                {
                    if (M2Share.g_Config.SpitMap[btDir, nC, n10] == 1)
                    {
                        n14 = m_nCurrX - 2 + n10;
                        n18 = m_nCurrY - 2 + nC;
                        BaseObject = m_PEnvir.GetMovingObject(n14, n18, true);
                        if ((BaseObject != null) && (BaseObject != this) && (IsProperTarget(BaseObject))
                            && (HUtil32.Random(BaseObject.m_btSpeedPoint) < m_btHitPoint))
                        {
                            n1C = BaseObject.GetMagStruckDamage(this, n1C);
                            if (n1C > 0)
                            {
                                BaseObject.StruckDamage(n1C);
                                BaseObject.SetLastHiter(this);
                                BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, n1C, m_WAbil.HP, m_WAbil.MaxHP, this.ToInt(), "", 300);
                                if (m_boUsePoison)
                                {
                                    if (HUtil32.Random(m_btAntiPoison + 20) == 0)
                                    {
                                        BaseObject.MakePosion(Grobal2.POISON_DECHEALTH, 30, 1);
                                    }
                                }
                            }
                        }
                    }
                    n10++;
                }
                nC++;
            }
        }

        public override bool AttackTarget()
        {
            bool result = false;
            byte btDir = 0;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (TargetInSpitRange(m_TargetCret, ref btDir))
            {
                if (((int)HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    SpitAttack(btDir);
                    BreakHolySeizeMode();
                }
                result = true;
                return result;
            }
            if (m_TargetCret.m_PEnvir == m_PEnvir)
            {
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                {
                    SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                }
            }
            else
            {
                DelTargetCreat();
            }
            return result;
        }
    }

    public class THighRiskSpider : TSpitSpider
    {
        public THighRiskSpider()
            : base()
        {
            m_boAnimal = false;
            this.m_boUsePoison = false;
        }
    }

    public class TBigPoisionSpider : TSpitSpider
    {
        public TBigPoisionSpider()
            : base()
        {
            m_boAnimal = false;
            this.m_boUsePoison = true;
        }
    }

    public class TGasAttackMonster : TATMonster
    {
        public TGasAttackMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_boAnimal = true;
        }

        public virtual TBaseObject sub_4A9C78(byte bt05)
        {
            TBaseObject result;
            TAbility WAbil;
            int n10;
            TBaseObject BaseObject;
            result = null;
            m_btDirection = bt05;
            WAbil = m_WAbil;
            n10 = HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC);
            if (n10 > 0)
            {
                SendRefMsg(Grobal2.RM_HIT, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                BaseObject = GetPoseCreate();
                if ((BaseObject != null) && IsProperTarget(BaseObject) && (HUtil32.Random(BaseObject.m_btSpeedPoint) < m_btHitPoint))
                {
                    n10 = BaseObject.GetMagStruckDamage(this, n10);
                    if (n10 > 0)
                    {
                        BaseObject.StruckDamage(n10);
                        BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, n10,
                            BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, this.ToInt(), "", 300);
                        if (HUtil32.Random(BaseObject.m_btAntiPoison + 20) == 0)
                        {
                            BaseObject.MakePosion(Grobal2.POISON_STONE, 5, 0);
                        }
                        result = BaseObject;
                    }
                }
            }
            return result;
        }

        public override bool AttackTarget()
        {
            bool result = false;
            byte btDir = 0;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (GetAttackDir(m_TargetCret, ref btDir))
            {
                if (((int)HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    sub_4A9C78(btDir);
                    BreakHolySeizeMode();
                }
                result = true;
            }
            else
            {
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }
    }

    public class TCowMonster : TATMonster
    {
        public TCowMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }
    }

    public class TMagCowMonster : TATMonster
    {
        public TMagCowMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }

        private void sub_4A9F6C(byte btDir)
        {
            TAbility WAbil;
            int n10;
            TBaseObject BaseObject;
            m_btDirection = btDir;
            WAbil = m_WAbil;
            n10 = HUtil32.Random((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1 + HUtil32.LoWord(WAbil.DC);
            if (n10 > 0)
            {
                SendRefMsg(Grobal2.RM_HIT, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                BaseObject = GetPoseCreate();
                if ((BaseObject != null) && IsProperTarget(BaseObject) && (m_nAntiMagic >= 0))
                {
                    n10 = BaseObject.GetMagStruckDamage(this, n10);
                    if (n10 > 0)
                    {
                        BaseObject.StruckDamage(n10);
                        BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, n10, BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, this.ToInt(), "", 300);
                    }
                }
            }
        }

        public override bool AttackTarget()
        {
            bool result;
            byte btDir = 0;
            result = false;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (GetAttackDir(m_TargetCret, ref btDir))
            {
                if (((int)HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    sub_4A9F6C(btDir);
                    BreakHolySeizeMode();
                }
                result = true;
            }
            else
            {
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }
    }

    public class TCowKingMonster : TATMonster
    {
        public uint dw558 = 0;
        public bool bo55C = false;
        public bool bo55D = false;
        public int n560 = 0;
        public uint dw564 = 0;
        public uint dw568 = 0;
        public uint dw56C = 0;
        public uint dw570 = 0;

        public TCowKingMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 500);
            dw558 = HUtil32.GetTickCount();
            bo2BF = true;
            n560 = 0;
            bo55C = false;
            bo55D = false;
        }

        ~TCowKingMonster()
        {

        }

        public override void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            TAbility WAbil;
            int nPower;
            WAbil = m_WAbil;
            nPower = GetAttackPower(HUtil32.LoWord(WAbil.DC), ((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)));
            HitMagAttackTarget(TargeTBaseObject, nPower / 2, nPower / 2, true);
        }

        public override void Initialize()
        {
            dw56C = (uint)m_nNextHitTime;
            dw570 = (uint)m_nWalkSpeed;
            base.Initialize();
        }

        public  override void Run()
        {
            int n8 = 0;
            int nC = 0;
            int n10;
            try
            {
                if (!m_boDeath && !m_boGhost && ((HUtil32.GetTickCount() - dw558) > 30000)) // 30 * 1000
                {
                    dw558 = HUtil32.GetTickCount();
                    if ((m_TargetCret != null) && (sub_4C3538() >= 5))
                    {
                        m_TargetCret.GetBackPosition(ref n8, ref  nC);
                        if (m_PEnvir.CanWalk(n8, nC, false))
                        {
                            SpaceMove(m_PEnvir.sMapName, n8, nC, 0);
                            return;
                        }
                        MapRandomMove(m_PEnvir.sMapName, 0);
                        return;
                    }
                    n10 = n560;
                    n560 = 7 - m_WAbil.HP / (m_WAbil.MaxHP / 7);
                    if ((n560 >= 2) && (n560 != n10))
                    {
                        bo55C = true;
                        dw564 = HUtil32.GetTickCount();
                    }
                    if (bo55C)
                    {
                        if ((HUtil32.GetTickCount() - dw564) < 8000)
                        {
                            m_nNextHitTime = 10000;
                        }
                        else
                        {
                            bo55C = false;
                            bo55D = true;
                            dw568 = HUtil32.GetTickCount();
                        }
                    }
                    if (bo55D)
                    {
                        if ((HUtil32.GetTickCount() - dw568) < 8000)
                        {
                            m_nNextHitTime = 500;
                            m_nWalkSpeed = 400;
                        }
                        else
                        {
                            bo55D = false;
                            m_nNextHitTime = dw56C;
                            m_nWalkSpeed = (int)dw570;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TCowKingMonster.Run");
            }
            base.Run();
        }
    }

    public class TElectronicScolpionMon : TMonster
    {
        private bool m_boUseMagic = false;

        public TElectronicScolpionMon()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_boUseMagic = false;
        }

        ~TElectronicScolpionMon()
        {

        }

        private void LightingAttack(int nDir)
        {
            TAbility WAbil;
            int nPower;
            int nDamage;
            int btGetBackHP;
            if (m_TargetCret != null)
            {
                m_btDirection = (byte)nDir;
                WAbil = m_WAbil;
                nPower = GetAttackPower(HUtil32.LoWord(WAbil.MC), ((short)HUtil32.HiWord(WAbil.MC) - HUtil32.LoWord(WAbil.MC)));
                nDamage = m_TargetCret.GetMagStruckDamage(this, nPower);
                if (nDamage > 0)
                {
                    btGetBackHP = (byte)m_WAbil.MP;
                    if (btGetBackHP != 0)
                    {
                        m_WAbil.HP += nDamage / btGetBackHP;
                    }
                    m_TargetCret.StruckDamage(nDamage);
                    m_TargetCret.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, m_TargetCret.m_WAbil.HP, m_TargetCret.m_WAbil.MaxHP, this.ToInt(), "", 200);
                }
                SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, m_TargetCret.ToInt(), "");
            }
        }

        public  override void Run()
        {
            int nAttackDir;
            int nX;
            int nY;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    // 血量低于一半时开始用魔法攻击
                    if (m_WAbil.HP < m_WAbil.MaxHP / 2)
                    {
                        m_boUseMagic = true;
                    }
                    else
                    {
                        m_boUseMagic = false;
                    }
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();
                    }
                    if (m_TargetCret == null)
                    {
                        return;
                    }
                    nX = Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX);
                    nY = Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY);
                    if ((nX <= 2) && (nY <= 2))
                    {
                        if (m_boUseMagic || ((nX == 2) || (nY == 2)))
                        {
                            if (((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime))
                            {
                                m_dwHitTick = HUtil32.GetTickCount();
                                nAttackDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                                LightingAttack(nAttackDir);
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TElectronicScolpionMon.Run");
            }
            base.Run();
        }

    }

    public class TLightingZombi : TMonster
    {
        public TLightingZombi()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
        }

        ~TLightingZombi()
        {

        }

        private void LightingAttack(int nDir)
        {
            int nSX = 0;
            int nSY = 0;
            int nTX = 0;
            int nTY = 0;
            int nPwr;
            TAbility WAbil;
            m_btDirection = (byte)nDir;
            SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, m_TargetCret.ToInt(), "");
            if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, nDir, 1, ref nSX, ref nSY))
            {
                m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, nDir, 9, ref nTX, ref nTY);
                WAbil = m_WAbil;
                nPwr = HUtil32.Random((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1 + HUtil32.LoWord(WAbil.DC);
                MagPassThroughMagic(nSX, nSY, nTX, nTY, nDir, nPwr, nPwr, true, 0);
            }
            BreakHolySeizeMode();
        }

        public override void Run()
        {
            int nAttackDir;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && ((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000))
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();
                    }
                    if ((((int)HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed) && (m_TargetCret != null) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 4))
                    {
                        if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 2)
                            && (HUtil32.Random(3) != 0))
                        {
                            base.Run();
                            return;
                        }
                        GetBackPosition(ref m_nTargetX, ref  m_nTargetY);
                    }
                    if ((m_TargetCret != null))
                    {
                        if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) < 6) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) < 6) && (((int)HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime))
                        {
                            m_dwHitTick = HUtil32.GetTickCount();
                            nAttackDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                            LightingAttack(nAttackDir);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TLightingZombi.Run");
            }
            base.Run();
        }
    }

    /// <summary>
    /// 月灵
    /// </summary>
    public class TFairyMonster : TMonster
    {
        /// <summary>
        /// 自动躲避间隔
        /// </summary>
        public uint m_dwAutoAvoidTick = 0;
        /// <summary>
        /// 最后的方向
        /// </summary>
        public byte m_btLastDirection = 0;
        /// <summary>
        /// 是否可以攻击
        /// </summary>
        public bool m_boIsUseAttackMagic = false;
        /// <summary>
        /// 动作间隔
        /// </summary>
        public uint m_dwActionTick = 0;
        /// <summary>
        /// DB设置的走路速度 
        /// </summary>
        public int nWalkSpeed = 0;
        /// <summary>
        /// 是否需要躲避
        /// </summary>
        public ushort nHitCount = 0;

        /// <summary>
        ///  检查身边一定范围的怪数量 
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nRange">范围大小（12格）</param>
        /// <returns></returns>
        private int CheckTargetXYCount(int nX, int nY, int nRange)
        {
            int result = 0;
            TBaseObject BaseObject;
            int nC;
            int n10 = nRange;
            if (m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < m_VisibleActors.Count; I++)
                {
                    BaseObject = m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || m_boCoolEye))
                            {
                                nC = Math.Abs(nX - BaseObject.m_nCurrX) + Math.Abs(nY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    result++;
                                    if (result > 1)// 月灵类只判断身边有一个目标接近即躲避
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

        public virtual bool IsNeedGotoXY()
        {
            bool result = false;// 是否走向目标
            if ((m_TargetCret != null) && !m_boIsUseAttackMagic && ((Math.Abs(m_TargetCret.m_nCurrX - m_nCurrX) > 7) 
                || (Math.Abs(m_TargetCret.m_nCurrY - m_nCurrY) > 7)))
            {
                m_dwAutoAvoidTick = HUtil32.GetTickCount();
                result = true;
            }
            return result;
        }

        // 自动躲避
        private bool IsNeedAvoid()
        {
            bool result;// 是否需要躲避
            result = false;
            if ((m_TargetCret != null) && !m_boIsUseAttackMagic)
            {
                if (CheckTargetXYCount(m_nCurrX, m_nCurrY, 2) > 0)// 怪在近身二格内
                {
                    m_dwAutoAvoidTick = HUtil32.GetTickCount();
                    result = true;
                }
            }
            return result;
        }

        // 检查身边一定范围的怪数量 
        private int CheckTargetXYCountOfDirection(int nX, int nY, int nDir, int nRange)
        {
            int result = 0;
            // 检测指定方向和范围内坐标的怪物数量
            TBaseObject BaseObject;
            if (m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < m_VisibleActors.Count; I++)
                {
                    BaseObject = m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || m_boCoolEye))
                            {
                                switch (nDir)
                                {
                                    case Grobal2.DR_UP:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_RIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWN:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_LEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool WalkToTargetXY(int nTargetX, int nTargetY)
        {
            bool result;
            int I;
            int nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            result = false;
            if ((Math.Abs(nTargetX - m_nCurrX) > 1) || (Math.Abs(nTargetY - m_nCurrY) > 1))
            {
                n10 = nTargetX;
                n14 = nTargetY;
                dwTick3F4 = HUtil32.GetTickCount();
                nDir = Grobal2.DR_DOWN;
                if (n10 > m_nCurrX)
                {
                    nDir = Grobal2.DR_RIGHT;
                    if (n14 > m_nCurrY)
                    {
                        nDir = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        nDir = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n10 < m_nCurrX)
                    {
                        nDir = Grobal2.DR_LEFT;
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNLEFT;
                        }
                        if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                    }
                    else
                    {
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWN;
                        }
                        else if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UP;
                        }
                    }
                }
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                WalkTo((byte)nDir, false);
                if ((Math.Abs(nTargetX - m_nCurrX) <= 1) && (Math.Abs(nTargetY - m_nCurrY) <= 1))
                {
                    result = true;
                }
                if (!result)
                {
                    n20 = HUtil32.Random(3);
                    for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                    {
                        if ((nOldX == m_nCurrX) && (nOldY == m_nCurrY))
                        {
                            if (n20 != 0)
                            {
                                nDir++;
                            }
                            if ((nDir > Grobal2.DR_UPLEFT))
                            {
                                nDir = Grobal2.DR_UP;
                            }
                            WalkTo((byte)nDir, false);
                            if ((Math.Abs(nTargetX - m_nCurrX) <= 1) && (Math.Abs(nTargetY - m_nCurrY) <= 1))
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool WalkToTargetXY2(int nTargetX, int nTargetY)
        {
            bool result = false;
            int I;
            int nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            if ((nTargetX != m_nCurrX) || (nTargetY != m_nCurrY))
            {
                n10 = nTargetX;
                n14 = nTargetY;
                dwTick3F4 = HUtil32.GetTickCount();
                nDir = Grobal2.DR_DOWN;
                if (n10 > m_nCurrX)
                {
                    nDir = Grobal2.DR_RIGHT;
                    if (n14 > m_nCurrY)
                    {
                        nDir = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        nDir = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n10 < m_nCurrX)
                    {
                        nDir = Grobal2.DR_LEFT;
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNLEFT;
                        }
                        if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPLEFT;
                        }
                    }
                    else
                    {
                        if (n14 > m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWN;
                        }
                        else if (n14 < m_nCurrY)
                        {
                            nDir = Grobal2.DR_UP;
                        }
                    }
                }
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                WalkTo((byte)nDir, false);
                if ((nTargetX == m_nCurrX) && (nTargetY == m_nCurrY))
                {
                    result = true;
                }
                if (!result)
                {
                    n20 = HUtil32.Random(3);
                    for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                    {
                        if ((nOldX == m_nCurrX) && (nOldY == m_nCurrY))
                        {
                            if (n20 != 0)
                            {
                                nDir++;
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
                            WalkTo((byte)nDir, false);
                            if ((nTargetX == m_nCurrX) && (nTargetY == m_nCurrY))
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool GotoTargetXY(int nTargetX, int nTargetY)
        {
            return WalkToTargetXY(nTargetX, nTargetY);
        }

        // 自动躲避
        public int AutoAvoid_GetAvoidDir()
        {
            int result;
            int n10;
            int n14;
            n10 = m_TargetCret.m_nCurrX;
            n14 = m_TargetCret.m_nCurrY;
            result = Grobal2.DR_DOWN;
            if (n10 > m_nCurrX)
            {
                result = Grobal2.DR_LEFT;
                if (n14 > m_nCurrY)
                {
                    result = Grobal2.DR_DOWNLEFT;
                }
                if (n14 < m_nCurrY)
                {
                    result = Grobal2.DR_UPLEFT;
                }
            }
            else
            {
                if (n10 < m_nCurrX)
                {
                    result = Grobal2.DR_RIGHT;
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        result = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                    else if (n14 < m_nCurrY)
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
            if (n10 > m_nCurrX)
            {
                result = Grobal2.DR_RIGHT;
                if (n14 > m_nCurrY)
                {
                    result = Grobal2.DR_DOWNRIGHT;
                }

                if (n14 < m_nCurrY)
                {
                    result = Grobal2.DR_UPRIGHT;
                }
            }
            else
            {
                if (n10 < m_nCurrX)
                {
                    result = Grobal2.DR_LEFT;
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNLEFT;
                    }
                    if (n14 < m_nCurrY)
                    {
                        result = Grobal2.DR_UPLEFT;
                    }
                }
                else
                {
                    if (n14 > m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                    else if (n14 < m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                }
            }
            return result;
        }

        public bool AutoAvoid_GetGotoXY(int nDir, ref int nTargetX, ref int nTargetY)
        {
            bool result = false;
            int n01;
            n01 = 0;
            while (true)
            {
                switch (nDir)
                {
                    case Grobal2.DR_UP:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                            n01++;
                            continue;
                        }
                    case Grobal2.DR_DOWN:
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                        if (m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
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
                    default:
                        break;
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
            result = AutoAvoid_GetGotoXY(m_btLastDirection, ref nTargetX, ref nTargetY);
            n10 = 0;
            while (true)
            {
                if (n10 >= 10)
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
                n10++;
            }
            return result;
        }

        public bool AutoAvoid_GotoMasterXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int nDir;
            result = false;
            if ((m_Master != null) && ((Math.Abs(m_Master.m_nCurrX - m_nCurrX) > 5) || (Math.Abs(m_Master.m_nCurrY - m_nCurrY) > 5)))
            {
                nTargetX = m_nCurrX;
                nTargetY = m_nCurrY;
                nDir = AutoAvoid_GetDirXY(m_Master.m_nCurrX, m_Master.m_nCurrY);
                switch (nDir)
                {
                    case Grobal2.DR_UP:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        break;
                    case Grobal2.DR_RIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        break;
                    case Grobal2.DR_DOWN:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        break;
                    case Grobal2.DR_LEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        if (!result)
                        {
                            nTargetX = m_nCurrX;
                            nTargetY = m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        break;
                }
            }
            return result;
        }

        // 增加检查两动作的间隔
        private bool AutoAvoid()
        {
            bool result = true;
            int nTargetX = 0;
            int nTargetY = 0;
            byte nDir;
            if ((m_TargetCret != null) && (!m_TargetCret.m_boDeath))
            {
                if (AutoAvoid_GotoMasterXY(ref nTargetX, ref nTargetY))
                {
                    result = GotoTargetXY(nTargetX, nTargetY);
                }
                else
                {
                    nTargetX = m_TargetCret.m_nCurrX;
                    nTargetY = m_TargetCret.m_nCurrY;
                    nDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, nTargetX, nTargetY);
                    nDir = GetBackDir(nDir);
                    m_PEnvir.GetNextPosition(nTargetX, nTargetY, nDir, 3, ref m_nTargetX, ref m_nTargetY);
                    result = GotoTargetXY(m_nTargetX, m_nTargetY);
                }
            }
            return result;
        }

        private void FlyAxeAttack(TBaseObject Target)
        {
            TAbility WAbil;
            int nDamage;
            // 重击几率,目标等级不高于自己,才使用重击
            if (((HUtil32.Random(M2Share.g_Config.nFairyDuntRate) == 0) && (Target.m_Abil.Level <= m_Abil.Level))
                || (nHitCount >= HUtil32._MIN((3 + M2Share.g_Config.nFairyDuntRateBelow),
                (m_btSlaveExpLevel + M2Share.g_Config.nFairyDuntRateBelow))))
            {
                // 月灵重击次数,达到次数时按等级出重击
                m_btDirection = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, Target.m_nCurrX, Target.m_nCurrY);
                WAbil = m_WAbil;// 重击倍数
                nDamage = (int)HUtil32._MAX(0, (int)HUtil32.Round((double)((HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1))
                    + HUtil32.LoWord(WAbil.DC)) * M2Share.g_Config.nFairyAttackRate / 100));
                if (nDamage > 0)
                {
                    nDamage = Target.GetHitStruckDamage(this, nDamage);
                }
                if (nDamage > 0)
                {
                    Target.StruckDamage(nDamage);
                }
                Target.SetLastHiter(this);
                Target.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, Target.m_WAbil.HP, Target.m_WAbil.MaxHP, this.ToInt(), "",
                    (uint)HUtil32._MAX(Math.Abs(m_nCurrX - Target.m_nCurrX), Math.Abs(m_nCurrY - Target.m_nCurrY)) * 50 + 600);
                SendRefMsg(Grobal2.RM_FAIRYATTACKRATE, 1, m_nCurrX, m_nCurrY, Target.ToInt(), "");
                m_dwActionTick = HUtil32.GetTickCount();
                nHitCount = 0;// 攻击计数
            }
            else
            {
                m_btDirection = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, Target.m_nCurrX, Target.m_nCurrY);
                WAbil = m_WAbil;
                nDamage = HUtil32._MAX(0, HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1)
                    + HUtil32.LoWord(WAbil.DC));
                if (nDamage > 0)
                {
                    nDamage = Target.GetHitStruckDamage(this, nDamage);
                }
                if (nDamage > 0)
                {
                    Target.StruckDamage(nDamage);
                }
                Target.SetLastHiter(this);
                Target.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nDamage, Target.m_WAbil.HP,
                    Target.m_WAbil.MaxHP, this.ToInt(), "", (uint)HUtil32._MAX(Math.Abs(m_nCurrX - Target.m_nCurrX), Math.Abs(m_nCurrY - Target.m_nCurrY)) * 50 + 600);
                SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, Target.ToInt(), "");
                m_dwActionTick = HUtil32.GetTickCount();
                nHitCount++;// 攻击计数
            }
        }

        // 增加检查两动作的间隔
        private bool CheckActionStatus()
        {
            bool result = false;
            if (HUtil32.GetTickCount() - m_dwActionTick > 1100)// 900
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
            }
            return result;
        }

        public override bool AttackTarget()
        {
            bool result;
            result = false;
            if ((m_TargetCret == null) || (m_TargetCret == m_Master))
            {
                return result;
            }
            if (!CheckActionStatus())
            {
                m_boIsUseAttackMagic = false;
                return result;
            }
            m_boIsUseAttackMagic = true;
            if ((HUtil32.GetTickCount() - m_dwHitTick) > m_nNextHitTime)
            {
                m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 7) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 7))
                {
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    FlyAxeAttack(m_TargetCret);
                    m_dwHitTick = HUtil32.GetTickCount();
                    result = true;
                    return result;
                }
                else
                {
                    m_boIsUseAttackMagic = false;
                }
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            else
            {
                m_boIsUseAttackMagic = false;
            }
            return result;
        }

        public TFairyMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_boIsUseAttackMagic = false;
            nHitCount = 0;// 轻击计数
            m_nViewRange = 8;
        }


        public override void Run()
        {
            int nX = 0;
            int nY = 0;
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCode = 1;
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        nCode = 2;
                        SearchTarget();// 搜索可攻击目标
                    }
                    nCode = 4;
                    if (((HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed))// 走路间隔
                    {
                        m_dwWalkTick = HUtil32.GetTickCount();// 走路间隔
                        if ((m_Master != null))//主人休息状态时的控制
                        {
                            if ((!m_Master.m_boSlaveRelax))
                            {
                                m_boNoAttackMode = false;
                            }
                            else
                            {
                                m_boNoAttackMode = true;
                            }
                        }
                        else
                        {
                            m_boNoAttackMode = false;
                        }
                        if (!m_boNoAttackMode)
                        {
                            nCode = 5;
                            if ((m_TargetCret != null))
                            {
                                if ((!m_TargetCret.m_boDeath)) // 目标不为空
                                {
                                    nCode = 6;
                                    if (IsNeedGotoXY())// 目标离远了,走向目标
                                    {
                                        nCode = 7;
                                        GotoTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                                        base.Run();
                                        return;
                                    }
                                    nCode = 8;
                                    if (AttackTarget())
                                    {
                                        base.Run();
                                        return;
                                    }
                                    nCode = 9;
                                    if (IsNeedAvoid()) // 月灵躲避
                                    {
                                        nCode = 10;
                                        AutoAvoid();// 自动躲避
                                        base.Run();
                                        return;
                                    }
                                }
                            }
                        }
                        nCode = 11;
                        if ((m_Master != null))
                        {
                            nCode = 12;
                            if ((!m_Master.m_boSlaveRelax)) // 离主人远后,自已走近主人
                            {
                                if (m_TargetCret == null)
                                {
                                    nCode = 13;
                                    m_Master.GetBackPosition(ref nX, ref nY);
                                    if ((Math.Abs(m_nTargetX - nX) > 1) || (Math.Abs(m_nTargetY - nY) > 1))
                                    {
                                        m_nTargetX = nX;
                                        m_nTargetY = nY;
                                        if ((Math.Abs(m_nCurrX - nX) <= 2) && (Math.Abs(m_nCurrY - nY) <= 2))
                                        {
                                            nCode = 14;
                                            if (m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                            {
                                                m_nTargetX = m_nCurrX;
                                                m_nTargetY = m_nCurrY;
                                            }
                                        }
                                    }
                                    nCode = 15;
                                    if (m_nTargetX != -1)
                                    {
                                        if ((Math.Abs(m_nCurrX - m_nTargetX) > 1) || (Math.Abs(m_nCurrY - m_nTargetY) > 1))
                                        {
                                            GotoTargetXY(m_nTargetX, m_nTargetY);
                                        }
                                    }
                                }
                            }
                            nCode = 16;
                            if ((m_Master != null))
                            {
                                // 离主人远了,直接飞到主人身边
                                if ((!m_Master.m_boSlaveRelax) && ((m_PEnvir != m_Master.m_PEnvir) || (Math.Abs(m_nCurrX - m_Master.m_nCurrX) > 20) || (Math.Abs(m_nCurrY - m_Master.m_nCurrY) > 20)))
                                {
                                    nCode = 17;
                                    SpaceMove(m_Master.m_PEnvir.sMapName, m_Master.m_nCurrX, m_Master.m_nCurrY, 1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (m_boDeath)
                    {
                        nCode = 18;
                        if ((HUtil32.GetTickCount() - m_dwDeathTick > 2000))
                        {
                            MakeGhost(); // 尸体消失
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFairyMonster.Run Code:" + nCode);
            }
            base.Run();
        }

        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            ResetElfMon();
        }

        // 月灵间隔
        private void ResetElfMon()
        {
            if (m_Master != null)
            {
                m_nWalkSpeed = HUtil32._MAX(200, nWalkSpeed - m_btSlaveMakeLevel * 50); // 走路速度 由DB设置的走路速度控制
            }
        }
    }

    public class TDigOutZombi : TMonster
    {
        public TDigOutZombi()
            : base()
        {
            m_nViewRange = 7;
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 2500);
            m_dwSearchTick = HUtil32.GetTickCount();
            m_btRaceServer = 95;
            m_boFixedHideMode = true;
        }

        private void sub_4AA8DC()
        {
            TEvent __Event;
            __Event = new TEvent(m_PEnvir, m_nCurrX, m_nCurrY, 1, 300000, true);// 5 * 60 * 1000
            M2Share.g_EventManager.AddEvent(__Event);
            m_boFixedHideMode = false;
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, __Event.ToInt(), "");
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            try
            {
                if (!m_boGhost && !m_boDeath && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (((int)HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed))
                {
                    if (m_boFixedHideMode)
                    {
                        if (m_VisibleActors.Count > 0)
                        {
                            for (int I = 0; I < m_VisibleActors.Count; I++)
                            {
                                BaseObject = m_VisibleActors[I].BaseObject;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                if (IsProperTarget(BaseObject))
                                {
                                    if (!BaseObject.m_boHideMode || m_boCoolEye)
                                    {
                                        if ((Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 3) && (Math.Abs(m_nCurrY - BaseObject.m_nCurrY) <= 3))
                                        {
                                            sub_4AA8DC();
                                            m_dwWalkTick = HUtil32.GetTickCount() + 1000;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000) || (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null)))
                        {
                            m_dwSearchEnemyTick = HUtil32.GetTickCount();
                            SearchTarget();
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TDigOutZombi.Run");
            }
            base.Run();
        }
    }

    public class TZilKinZombi : TATMonster
    {
        public uint dw558 = 0;
        public int nZilKillCount = 0;
        public uint dw560 = 0;

        public TZilKinZombi()
            : base()
        {
            m_nViewRange = 6;
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 2500);
            m_dwSearchTick = HUtil32.GetTickCount();
            m_btRaceServer = 96;
            nZilKillCount = 0;
            if (HUtil32.Random(3) == 0)
            {
                nZilKillCount = HUtil32.Random(3) + 1;
            }
        }

        public override void Die()
        {
            base.Die();
            if (nZilKillCount > 0)
            {
                dw558 = HUtil32.GetTickCount();
                dw560 = Convert.ToUInt32(HUtil32.Random(20) + 4 * 1000);
            }
            nZilKillCount -= 1;
        }

        public  override void Run()
        {
            try
            {
                if (m_boDeath && !m_boGhost && (nZilKillCount >= 0) && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)
                    && (m_VisibleActors.Count > 0) && ((HUtil32.GetTickCount() - dw558) >= dw560))
                {
                    m_Abil.MaxHP = m_Abil.MaxHP >> 1;
                    m_dwFightExp = m_dwFightExp / 2;
                    m_Abil.HP = m_Abil.MaxHP;
                    m_WAbil.HP = m_Abil.MaxHP;
                    ReAlive();
                    m_dwWalkTick = HUtil32.GetTickCount() + 1000;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TZilKinZombi.Run");
            }
            base.Run();
        }
    }

    public class TWhiteSkeleton : TATMonster
    {
        public bool m_boIsFirst = false;
        public TWhiteSkeleton()
            : base()
        {
            m_boIsFirst = true;
            m_boFixedHideMode = true;
            m_btRaceServer = 100;
            m_nViewRange = 6;
        }

        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            sub_4AAD54();
        }

        public override void Run()
        {
            try
            {
                if (m_boIsFirst)
                {
                    m_boIsFirst = false;
                    m_btDirection = 5;
                    m_boFixedHideMode = false;
                    SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TWhiteSkeleton.Run");
            }
            base.Run();
        }

        private void sub_4AAD54()
        {
            m_nNextHitTime = Convert.ToUInt32(3000 - m_btSlaveMakeLevel * 600);
            m_nWalkSpeed = 1200 - m_btSlaveMakeLevel * 250;
            m_dwWalkTick = HUtil32.GetTickCount() + 2000;
        }
    }

    public class TScultureMonster : TMonster
    {
        public TScultureMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_nViewRange = 7;
            m_boStoneMode = true;
            m_nCharStatusEx = Grobal2.STATE_STONE_MODE;
        }


        private void MeltStone()
        {
            m_nCharStatusEx = 0;
            m_nCharStatus = GetCharStatus();
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            m_boStoneMode = false;
        }

        private void MeltStoneAll()
        {
            List<TBaseObject> List10;
            TBaseObject BaseObject;
            MeltStone();
            List10 = new List<TBaseObject>();
            try
            {
                GetMapBaseObjects(m_PEnvir, m_nCurrX, m_nCurrY, 7, List10);
                if (List10.Count > 0)
                {
                    for (int I = 0; I < List10.Count; I++)
                    {
                        BaseObject =List10[I];
                        if (BaseObject != null)
                        {
                            if (BaseObject.m_boStoneMode)
                            {
                                if (BaseObject is TScultureMonster)
                                {
                                    ((BaseObject) as TScultureMonster).MeltStone();
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
            }
        }

        public override void Run()
        {
            TBaseObject BaseObject;
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boGhost && !m_boDeath && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (((int)HUtil32.GetTickCount() - m_dwWalkTick) >= m_nWalkSpeed))
                {
                    if (m_boStoneMode)
                    {
                        nCode = 1;
                        if (m_VisibleActors.Count > 0)
                        {
                            nCode = 2;
                            for (int I = 0; I < m_VisibleActors.Count; I++)
                            {
                                nCode = 3;
                                BaseObject = m_VisibleActors[I].BaseObject;
                                nCode = 4;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                nCode = 5;
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                nCode = 6;
                                if (IsProperTarget(BaseObject))
                                {
                                    nCode = 7;
                                    if (!BaseObject.m_boHideMode || m_boCoolEye)
                                    {
                                        nCode = 8;
                                        if ((Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - BaseObject.m_nCurrY) <= 2))
                                        {
                                            nCode = 9;
                                            MeltStoneAll();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000) || (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null)))
                        {
                            nCode = 10;
                            m_dwSearchEnemyTick = HUtil32.GetTickCount();
                            SearchTarget();
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TScultureMonster.Run Code:" + (nCode).ToString());
            }
        }

    }

    public class TScultureKingMonster : TMonster
    {
        public int m_nDangerLevel = 0;
        public ArrayList m_SlaveObjectList = null;

        public TScultureKingMonster()
            : base()
        {
            m_dwSearchTime = Convert.ToUInt32(HUtil32.Random(1500) + 1500);
            m_nViewRange = 8;
            m_boStoneMode = true;
            m_nCharStatusEx = Grobal2.STATE_STONE_MODE;
            m_btDirection = 5;
            m_nDangerLevel = 5;
            m_SlaveObjectList = new ArrayList();
        }

        ~TScultureKingMonster()
        {
            Dispose(m_SlaveObjectList);
        }

        private void MeltStone()
        {
            TEvent __Event;
            m_nCharStatusEx = 0;
            m_nCharStatus = GetCharStatus();
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            m_boStoneMode = false;
            __Event = new TEvent(m_PEnvir, m_nCurrX, m_nCurrY, 6, 300000, true);// 5 * 60 * 1000
            M2Share.g_EventManager.AddEvent(__Event);
        }

        // 召唤下属
        private void CallSlave()
        {
            int nC;
            int n10 = 0;
            int n14 = 0;
            TBaseObject BaseObject;
            nC = HUtil32.Random(6) + 6;
            GetFrontPosition(ref n10, ref n14);
            for (int I = 1; I <= nC; I++)
            {
                if (m_SlaveObjectList.Count >= 30)
                {
                    break;
                }
                BaseObject = UserEngine.RegenMonsterByName(m_sMapName, n10, n14,
                    M2Share.g_Config.sZuma[HUtil32.Random(4)]);
                if (BaseObject != null)
                {
                    m_SlaveObjectList.Add(BaseObject);
                }
            }
        }

        public override void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            TAbility WAbil;
            int nPower;
            if (TargeTBaseObject != null)
            {
                WAbil = m_WAbil;
                nPower = GetAttackPower(HUtil32.LoWord(WAbil.DC), ((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)));
                HitMagAttackTarget(TargeTBaseObject, 0, nPower, true);
            }
        }

        public  override void Run()
        {
            TBaseObject BaseObject;
            try
            {
                if (!m_boGhost && !m_boDeath && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (((int)HUtil32.GetTickCount() - m_dwWalkTick) >= m_nWalkSpeed))
                {
                    if (m_boStoneMode)
                    {
                        if (m_VisibleActors.Count > 0)
                        {
                            for (int I = 0; I < m_VisibleActors.Count; I++)
                            {
                                BaseObject = m_VisibleActors[I].BaseObject;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                if (IsProperTarget(BaseObject))
                                {
                                    if (!BaseObject.m_boHideMode || m_boCoolEye)
                                    {
                                        if ((Math.Abs(m_nCurrX - BaseObject.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - BaseObject.m_nCurrY) <= 2))
                                        {
                                            MeltStone();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000) || (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null)))
                        {
                            m_dwSearchEnemyTick = HUtil32.GetTickCount();
                            SearchTarget();
                            if ((m_nDangerLevel > m_WAbil.HP / m_WAbil.MaxHP * 5) && (m_nDangerLevel > 0))
                            {
                                m_nDangerLevel -= 1;
                                CallSlave();
                            }
                            if (m_WAbil.HP == m_WAbil.MaxHP)
                            {
                                m_nDangerLevel = 5;
                            }
                        }
                    }
                    for (int I = m_SlaveObjectList.Count - 1; I >= 0; I--)
                    {
                        if (m_SlaveObjectList.Count <= 0)
                        {
                            break;
                        }
                        BaseObject = ((TBaseObject)(m_SlaveObjectList[I]));
                        if (BaseObject != null)
                        {
                            if (BaseObject.m_boDeath || BaseObject.m_boGhost)
                            {
                                m_SlaveObjectList.RemoveAt(I);
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TScultureKingMonster.Run");
            }
            base.Run();
        }
    }

    public class TGasMothMonster : TGasAttackMonster
    {
        public TGasMothMonster()
            : base()
        {
            m_nViewRange = 7;
        }

        public override TBaseObject sub_4A9C78(byte bt05)
        {
            TBaseObject result;
            TBaseObject BaseObject;
            BaseObject = base.sub_4A9C78(bt05);
            if ((BaseObject != null) && (HUtil32.Random(3) == 0) && (BaseObject.m_boHideMode))
            {
                BaseObject.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;
            }
            result = BaseObject;
            return result;
        }

        public override void Run()
        {
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (((int)HUtil32.GetTickCount() - m_dwWalkTick) >= m_nWalkSpeed))
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000) || (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null)))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        sub_4C959C();
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TGasMothMonster.Run");
            }
            base.Run();
        }
    }

    public class TGasDungMonster : TGasAttackMonster
    {
        public TGasDungMonster()
            : base()
        {
            m_nViewRange = 7;
        }
    }

    public class TElfMonster : TMonster
    {
        public bool boIsFirst = false;

        public void AppearNow()
        {
            // 神兽
            boIsFirst = false;
            m_boFixedHideMode = false;
            RecalcAbilitys();
            m_dwWalkTick = m_dwWalkTick + 800;
        }

        public TElfMonster()
            : base()
        {
            m_nViewRange = 6;
            m_boFixedHideMode = true;
            m_boNoAttackMode = true;
            boIsFirst = true;
        }


        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            ResetElfMon();
        }

        private void ResetElfMon()
        {
            m_nWalkSpeed = 500 - m_btSlaveMakeLevel * 50;
            m_dwWalkTick = HUtil32.GetTickCount() + 2000;
        }

        public override void Run()
        {
            bool boChangeFace;
            TBaseObject ElfMon;
            byte nCode;
            nCode = 0;
            try
            {
                if (boIsFirst)
                {
                    nCode = 1;
                    boIsFirst = false;
                    m_boFixedHideMode = false;
                    nCode = 2;
                    SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                    nCode = 3;
                    ResetElfMon();
                }
                nCode = 4;
                if (m_boDeath)
                {
                    // 2 * 1000
                    if ((HUtil32.GetTickCount() - m_dwDeathTick > 2000))
                    {
                        MakeGhost();
                    }
                }
                else
                {
                    nCode = 6;
                    boChangeFace = false;
                    if (m_TargetCret != null)
                    {
                        boChangeFace = true;
                    }
                    if ((m_Master != null))
                    {
                        if (((m_Master.m_TargetCret != null) || (m_Master.m_LastHiter != null)))
                        {
                            boChangeFace = true;
                        }
                    }
                    nCode = 7;
                    if (boChangeFace)
                    {
                        nCode = 8;
                        ElfMon = this.MakeClone(m_sCharName + '1', this);
                        nCode = 9;
                        if (ElfMon != null)
                        {
                            nCode = 10;
                            ElfMon.m_boAutoChangeColor = m_boAutoChangeColor;
                            nCode = 11;
                            if (ElfMon is TElfWarriorMonster)
                            {
                                ((ElfMon) as TElfWarriorMonster).AppearNow();
                            }
                            nCode = 12;
                            m_Master = null;
                            KickException();
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TElfMonster.Run Code:" + (nCode).ToString());
                KickException();
            }
        }
    }

    public class TElfWarriorMonster : TSpitSpider
    {
        public int n55C = 0;
        public bool boIsFirst = false;
        public uint dwDigDownTick = 0;
        public void AppearNow()
        {
            boIsFirst = false;
            m_boFixedHideMode = false;
            SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            RecalcAbilitys();
            m_dwWalkTick = m_dwWalkTick + 800;
            dwDigDownTick = HUtil32.GetTickCount();
        }

        public TElfWarriorMonster()
            : base()
        {
            m_nViewRange = 6;
            m_boFixedHideMode = true;
            boIsFirst = true;
            this.m_boUsePoison = false;
        }

        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            ResetElfMon();
        }

        private void ResetElfMon()
        {
            m_nNextHitTime = Convert.ToUInt32(1500 - m_btSlaveMakeLevel * 100);
            m_nWalkSpeed = 500 - m_btSlaveMakeLevel * 50;
            m_dwWalkTick = HUtil32.GetTickCount() + 2000;
        }

        public override void Run()
        {
            bool boChangeFace;
            TBaseObject ElfMon;
            string ElfName;
            byte nCode = 0;
            try
            {
                ElfMon = null;
                nCode = 1;
                if (boIsFirst)
                {
                    nCode = 2;
                    boIsFirst = false;
                    m_boFixedHideMode = false;
                    nCode = 3;
                    SendRefMsg(Grobal2.RM_DIGUP, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                    ResetElfMon();
                }
                nCode = 4;
                if (m_boDeath)
                {
                    if ((HUtil32.GetTickCount() - m_dwDeathTick > 2000))// 2 * 1000
                    {
                        nCode = 5;
                        MakeGhost();
                    }
                }
                else
                {
                    nCode = 6;
                    boChangeFace = true;
                    if (m_TargetCret != null)
                    {
                        boChangeFace = false;
                    }
                    nCode = 7;
                    if ((m_Master != null))
                    {
                        if (((m_Master.m_TargetCret != null) || (m_Master.m_LastHiter != null)))
                        {
                            boChangeFace = false;
                        }
                    }
                    nCode = 8;
                    if (boChangeFace)
                    {
                        if ((HUtil32.GetTickCount() - dwDigDownTick) > 60000)// 6 * 10 * 1000
                        {
                            nCode = 9;
                            ElfName = m_sCharName;
                            if (ElfName[ElfName.Length] == '1')
                            {
                                ElfName = ElfName.Substring(1 - 1, ElfName.Length - 1);
                                nCode = 10;
                                ElfMon = this.MakeClone(ElfName, this);
                            }
                            if (ElfMon != null)
                            {
                                nCode = 11;
                                SendRefMsg(Grobal2.RM_DIGDOWN, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                                SendRefMsg(Grobal2.RM_CHANGEFACE, 0, this.ToInt(), ElfMon.ToInt(), 0, "");
                                nCode = 12;
                                ElfMon.m_boAutoChangeColor = m_boAutoChangeColor;
                                if (ElfMon is TElfMonster)
                                {
                                    ((ElfMon) as TElfMonster).AppearNow();
                                }
                                nCode = 13;
                                m_Master = null;
                                KickException();
                            }
                        }
                    }
                    else
                    {
                        dwDigDownTick = HUtil32.GetTickCount();
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TElfWarriorMonster.Run Code:" + nCode);
                KickException();
            }
        }
    }

    

    /// <summary>
    /// 狂热火蜥蜴:4×4火墙攻击,施毒术
    /// </summary>
    public class TSalamanderATMonster : TATMonster
    {
        public bool m_boExploration = false;// 是否可探索
        public byte m_nButchChargeClass = 0;// 探索收费模式(0金币，1元宝，2金刚石，3灵符)
        public int m_nButchChargeCount = 0;// 探索每次收费点数
        public bool boIntoTrigger = false;// 是否进入触发
        public ArrayList m_ButchItemList = null;

        public TSalamanderATMonster()
            : base()
        {
            m_boExploration = false;// 是否可探索
            m_ButchItemList = new ArrayList();// 可探索物品列表
        }

        ~TSalamanderATMonster()
        {
            int I;
            if (m_ButchItemList.Count > 0)
            {
                // 可探索物品列表
                for (I = 0; I < m_ButchItemList.Count; I++)
                {
                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                    {
                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                    }
                }
            }
            m_ButchItemList = null;
        }

        public override void Die()
        {
            if (m_boExploration)
            {
                // 可探索,则发消息让客户端提示
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            base.Die();
        }

        // 显示名字
        public override string GetShowName()
        {
            string result;
            result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)
            {
                // 可探索,则发消息让客户端提示
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            return result;
        }

        public void AddItemsFromConfig()
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
            IniFile ItemIni;
            // ---------------------------读取怪物配置----------------------------------
            s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + ".txt";
            if (File.Exists(s24))
            {
                ItemIni = new IniFile(s24);
                if (ItemIni != null)
                {
                    m_nButchChargeClass = (byte)ItemIni.ReadInteger("Info", "ButchChargeClass", 3);// 收费模式(0金币，1元宝，2金刚石，3灵符)
                    m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// 挖每次收费点数
                    boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 怪挖是否进入触发
                    // ---------------------------读取探索物品----------------------------------
                    s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + "-Item.txt";
                    if (File.Exists(s24))
                    {
                        if (m_ButchItemList != null)
                        {
                            if (m_ButchItemList.Count > 0)
                            {
                                for (I = 0; I < m_ButchItemList.Count; I++)
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
                            for (I = 0; I < LoadList.Count; I++)
                            {
                                s28 = LoadList[I];
                                if ((s28 != "") && (s28[0] != ';'))
                                {
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n18 = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n1C = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    if (s30 != "")
                                    {
                                        if (s30[0] == '\"')
                                        {
                                            HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                                        }
                                    }
                                    s2C = s30;
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    n20 = HUtil32.Str_ToInt(s30, 1);
                                    if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                                    {
                                        MonItem = new TMonItemInfo();
                                        MonItem.SelPoint = n18 - 1;
                                        MonItem.MaxPoint = n1C;
                                        MonItem.ItemName = s2C;
                                        MonItem.Count = n20;
                                        if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)
                                        {
                                            // 计算机率 1/10 随机10<=1 即为所得的物品
                                            m_ButchItemList.Add(MonItem);
                                        }
                                    }
                                }
                            }
                        }
                        if (m_ButchItemList.Count > 0)
                        {
                            m_boExploration = true; // 是否可探索
                        }
                    }
                }
            }
        }

        public  override void Run()
        {
            int nPower;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if ((m_TargetCret != null) && (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 2))
                    {
                        m_dwHitTick = HUtil32.GetTickCount();
                        if ((HUtil32.Random(4) == 0))// 癫狂状态
                        {
                            if ((M2Share.g_EventManager.GetEvent(m_PEnvir, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY, Grobal2.ET_FIRE) == null))
                            {
                                MagMakeFireCross(this, GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))), 4, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);// 火墙
                            }
                            else if ((HUtil32.Random(4) == 0))
                            {
                                if (IsProperTarget(m_TargetCret))
                                {
                                    if (HUtil32.Random(m_TargetCret.m_btAntiPoison + 7) <= 6)// 施毒
                                    {
                                        nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));// 中毒类型 - 绿毒
                                        m_TargetCret.SendDelayMsg(this, Grobal2.RM_POISON, Grobal2.POISON_DECHEALTH, nPower, this.ToInt(), 4, "", 150);
                                    }
                                }
                            }
                            else
                            {
                                AttackTarget();// 物理攻击
                            }
                        }
                        else
                        {
                            if (HUtil32.Random(4) == 0)
                            {
                                if (IsProperTarget(m_TargetCret))
                                {
                                    if (HUtil32.Random(m_TargetCret.m_btAntiPoison + 7) <= 6)// 施毒
                                    {
                                        nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));// 中毒类型 - 绿毒
                                        m_TargetCret.SendDelayMsg(this, Grobal2.RM_POISON, Grobal2.POISON_DECHEALTH, nPower, this.ToInt(), 4, "", 150);
                                    }
                                }
                            }
                            else if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) <= 2))
                            {
                                AttackTarget();// 物理攻击
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSalamanderATMonster.Run");
            }
            base.Run();
        }

        public override bool AttackTarget()
        {
            bool result;
            byte btDir = 0;
            result = false;
            if (m_TargetCret != null)
            {
                if (TargetInSpitRange(m_TargetCret, ref btDir))
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    this.Attack(m_TargetCret, btDir);
                    result = true;
                }
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }

        // 火墙 4*4
        private int MagMakeFireCross(TBaseObject PlayObject, int nDamage, int nHTime, int nX, int nY)
        {
            int result;
            TFireBurnEvent FireBurnEvent;
            result = 0;
            if (PlayObject.m_PEnvir.GetEvent(nX, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY - 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY - 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX, nY + 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX, nY + 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY) == null)
            {

                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY - 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY - 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 1, nY + 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 1, nY + 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 2, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 2, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 2, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 2, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX - 2, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX - 2, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY - 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY - 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 1, nY + 2) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 1, nY + 2, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 2, nY) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 2, nY, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 2, nY - 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 2, nY - 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            if (PlayObject.m_PEnvir.GetEvent(nX + 2, nY + 1) == null)
            {
                FireBurnEvent = new TFireBurnEvent(PlayObject, nX + 2, nY + 1, Grobal2.ET_FIRE, Convert.ToUInt32(nHTime * 1000), nDamage);
                M2Share.g_EventManager.AddEvent(FireBurnEvent);
            }
            result = 1;
            return result;
        }
    }

    /// <summary>
    /// 圣殿卫士
    /// </summary>
    public class TTempleGuardian : TScultureMonster
    {
        public bool m_boExploration = false;// 是否可探索
        public byte m_nButchChargeClass = 0;// 探索收费模式(0金币，1元宝，2金刚石，3灵符)
        public int m_nButchChargeCount = 0;// 探索每次收费点数
        public bool boIntoTrigger = false;// 是否进入触发
        public ArrayList m_ButchItemList = null;

        public TTempleGuardian()
            : base()
        {
            m_boExploration = false;// 是否可探索
            m_ButchItemList = new ArrayList();// 可探索物品列表
        }

        ~TTempleGuardian()
        {
            int I;
            if (m_ButchItemList.Count > 0) // 可探索物品列表
            {
                for (I = 0; I < m_ButchItemList.Count; I++)
                {
                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                    {
                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                    }
                }
            }
            m_ButchItemList = null;
        }

        public override void Die()
        {
            if (m_boExploration)// 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            base.Die();
        }

        // 显示名字
        public override string GetShowName()
        {
            string result;
            result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)// 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            return result;
        }

        public void AddItemsFromConfig()
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
            IniFile ItemIni;
            // ---------------------------读取怪物配置----------------------------------
            s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + ".txt";
            if (File.Exists(s24))
            {
                ItemIni = new IniFile(s24);
                if (ItemIni != null)
                {
                    m_nButchChargeClass = (byte)ItemIni.ReadInteger("Info", "ButchChargeClass", 3);// 收费模式(0金币，1元宝，2金刚石，3灵符)
                    m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// 挖每次收费点数
                    boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 怪挖是否进入触发
                    // ---------------------------读取探索物品----------------------------------
                    s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + "-Item.txt";
                    if (File.Exists(s24))
                    {
                        if (m_ButchItemList != null)
                        {
                            if (m_ButchItemList.Count > 0)
                            {
                                for (I = 0; I < m_ButchItemList.Count; I++)
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
                        try
                        {
                            LoadList.LoadFromFile(s24);
                            if (LoadList.Count > 0)
                            {
                                for (I = 0; I < LoadList.Count; I++)
                                {
                                    s28 = LoadList[I];
                                    if ((s28 != "") && (s28[0] != ';'))
                                    {
                                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                        n18 = HUtil32.Str_ToInt(s30, -1);
                                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                        n1C = HUtil32.Str_ToInt(s30, -1);
                                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                        if (s30 != "")
                                        {
                                            if (s30[0] == '\"')
                                            {
                                                HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                                            }
                                        }
                                        s2C = s30;
                                        s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                        n20 = HUtil32.Str_ToInt(s30, 1);
                                        if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                                        {
                                            MonItem = new TMonItemInfo();
                                            MonItem.SelPoint = n18 - 1;
                                            MonItem.MaxPoint = n1C;
                                            MonItem.ItemName = s2C;
                                            MonItem.Count = n20;
                                            if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)
                                            {
                                                // 计算机率 1/10 随机10<=1 即为所得的物品
                                                m_ButchItemList.Add(MonItem);
                                            }
                                        }
                                    }
                                }
                            }
                            if (m_ButchItemList.Count > 0)
                            {
                                m_boExploration = true; // 是否可探索
                            }
                        }
                        finally
                        {
                            //LoadList.Free;
                        }
                    }
                    //ItemIni.Free;
                }
            }
        }

        // 读取可探索物品
        public override void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            TAbility WAbil;
            int nPower;
            WAbil = m_WAbil;
            nPower = GetAttackPower(HUtil32.LoWord(WAbil.DC), ((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)));
            HitMagAttackTarget(TargeTBaseObject, nPower / 2, nPower / 2, true);
        }
    }

    /// <summary>
    /// 金杖蜘蛛:自我治疗(群疗),冰咆哮
    /// </summary>
    public class TheCrutchesSpider : TMonster
    {
        public bool m_boExploration = false;// 是否可探索
        public byte m_nButchChargeClass = 0;// 探索收费模式(0金币，1元宝，2金刚石，3灵符)
        public int m_nButchChargeCount = 0;// 探索每次收费点数
        public bool boIntoTrigger = false;// 是否进入触发
        public ArrayList m_ButchItemList = null;//可探索物品列表

        public TheCrutchesSpider()
            : base()
        {
            m_boExploration = false;
            m_ButchItemList = new ArrayList();
        }

        ~TheCrutchesSpider()
        {
            if (m_ButchItemList.Count > 0)  // 可探索物品列表
            {
                for (int I = 0; I < m_ButchItemList.Count; I++)
                {
                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                    {
                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                    }
                }
            }
            m_ButchItemList = null;
        }

        public override void Die()
        {
            if (m_boExploration)// 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            base.Die();
        }

        // 显示名字
        public override string GetShowName()
        {
            string result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");// 可探索,则发消息让客户端提示
            }
            return result;
        }

        public void AddItemsFromConfig()
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
            IniFile ItemIni;
            // ---------------------------读取怪物配置----------------------------------
            s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + ".txt";
            if (File.Exists(s24))
            {
                ItemIni = new IniFile(s24);
                if (ItemIni != null)
                {
                    m_nButchChargeClass = (byte)ItemIni.ReadInteger("Info", "ButchChargeClass", 3);// 收费模式(0金币，1元宝，2金刚石，3灵符)
                    m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// 挖每次收费点数
                    boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 怪挖是否进入触发
                    // ---------------------------读取探索物品----------------------------------
                    s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + "-Item.txt";
                    if (File.Exists(s24))
                    {
                        if (m_ButchItemList != null)
                        {
                            if (m_ButchItemList.Count > 0)
                            {
                                for (I = 0; I < m_ButchItemList.Count; I++)
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
                            for (I = 0; I < LoadList.Count; I++)
                            {
                                s28 = LoadList[I];
                                if ((s28 != "") && (s28[0] != ';'))
                                {
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n18 = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n1C = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    if (s30 != "")
                                    {
                                        if (s30[0] == '\"')
                                        {
                                            HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                                        }
                                    }
                                    s2C = s30;
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    n20 = HUtil32.Str_ToInt(s30, 1);
                                    if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                                    {
                                        MonItem = new TMonItemInfo();
                                        MonItem.SelPoint = n18 - 1;
                                        MonItem.MaxPoint = n1C;
                                        MonItem.ItemName = s2C;
                                        MonItem.Count = n20; ;
                                        if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)
                                        {
                                            // 计算机率 1/10 随机10<=1 即为所得的物品
                                            m_ButchItemList.Add(MonItem);
                                        }
                                    }
                                }
                            }
                        }
                        if (m_ButchItemList.Count > 0)
                        {
                            m_boExploration = true;// 是否可探索
                        }
                        //LoadList.Free;
                    }
                    //ItemIni.Free;
                }
            }
        }

        public  override void Run()
        {
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();// 搜索可攻击目标
                    }
                    if ((m_TargetCret != null))
                    {
                        // 走路间隔
                        if ((HUtil32.GetTickCount() - m_dwWalkTick > m_nWalkSpeed) && (!m_TargetCret.m_boDeath))
                        {
                            // 目标不为空
                            if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5))
                            {
                                if ((m_WAbil.HP < HUtil32.Round(Convert.ToDouble(m_WAbil.MaxHP))) && (HUtil32.Random(4) == 0))
                                {
                                    // 使用群体治疗术
                                    if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
                                    {
                                        m_dwHitTick = HUtil32.GetTickCount();
                                        M2Share.MagicManager.MagBigHealing(this, 50, m_nCurrX, m_nCurrY);// 群体治疗术
                                        SendRefMsg(Grobal2.RM_FAIRYATTACKRATE, 1, m_nCurrX, m_nCurrY, this.ToInt(), "");
                                    }
                                }
                                AttackTarget();
                            }
                            else
                            {
                                this.GotoTargetXY();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TheCrutchesSpider.Run");
            }
            base.Run();
        }

        // 远距离使用冰咆哮 5*5范围
        public  override bool AttackTarget()
        {
            bool result;
            result = false;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
            {
                m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 5))
                {
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    m_btDirection = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    M2Share.MagicManager.MagBigExplosion(this, GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC))),
                        m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY, M2Share.g_Config.nSnowWindRange, MagicConst.SKILL_SNOWWIND);
                    SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, m_TargetCret.ToInt(), "");
                    result = true;
                    return result;
                }
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }
    }

    /// <summary>
    /// 雷炎蛛王
    /// </summary>
    public class TYanLeiWangSpider : TATMonster
    {
        /// <summary>
        /// 是否可探索
        /// </summary>
        public bool m_boExploration = false;
        /// <summary>
        /// 探索收费模式(0金币，1元宝，2金刚石，3灵符)
        /// </summary>
        public byte m_nButchChargeClass = 0;
        /// <summary>
        /// 探索每次收费点数
        /// </summary>
        public int m_nButchChargeCount = 0;
        /// <summary>
        /// 是否进入触发
        /// </summary>
        public bool boIntoTrigger = false;
        /// <summary>
        /// 可探索物品列表
        /// </summary>
        public ArrayList m_ButchItemList = null;
        /// <summary>
        /// 是否喷出蜘蛛网
        /// </summary>
        public bool boIsSpiderMagic = false;
        public uint m_dwSpiderMagicTick = 0;

        public TYanLeiWangSpider()
            : base()
        {
            m_boExploration = false;// 是否可探索
            m_ButchItemList = new ArrayList();// 可探索物品列表
            boIsSpiderMagic = false;// 是否喷出蜘蛛网
        }

        ~TYanLeiWangSpider()
        {
            int I;
            if (m_ButchItemList.Count > 0)// 可探索物品列表
            {
                for (I = 0; I < m_ButchItemList.Count; I++)
                {
                    if (((TMonItemInfo)(m_ButchItemList[I])) != null)
                    {
                        Dispose(((TMonItemInfo)(m_ButchItemList[I])));
                    }
                }
            }
            m_ButchItemList = null;
        }

        public override void Die()
        {
            if (m_boExploration)
            {
                // 可探索,则发消息让客户端提示
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            base.Die();
        }

        // 显示名字
        public override string GetShowName()
        {
            string result;
            result = M2Share.FilterShowName(m_sCharName);// 过滤有数字的名称
            if (m_boExploration && m_boDeath && !m_boGhost)// 可探索,则发消息让客户端提示
            {
                SendRefMsg(Grobal2.RM_CANEXPLORATION, 0, 0, 0, 0, "");
            }
            return result;
        }

        public void AddItemsFromConfig()
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
            IniFile ItemIni;
            // ---------------------------读取怪物配置----------------------------------
            s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + ".txt";
            if (File.Exists(s24))
            {
                ItemIni = new IniFile(s24);
                if (ItemIni != null)
                {
                    m_nButchChargeClass = (byte)ItemIni.ReadInteger("Info", "ButchChargeClass", 3);// 收费模式(0金币，1元宝，2金刚石，3灵符)
                    m_nButchChargeCount = ItemIni.ReadInteger("Info", "ButchChargeCount", 1);// 挖每次收费点数
                    boIntoTrigger = ItemIni.ReadBool("Info", "ButchCloneItem", false);// 挖是否进入触发
                    // ---------------------------读取探索物品----------------------------------
                    s24 = M2Share.g_Config.sEnvirDir + "MonUseItems\\" + m_sCharName + "-Item.txt";
                    if (File.Exists(s24))
                    {
                        if (m_ButchItemList != null)
                        {
                            if (m_ButchItemList.Count > 0)
                            {
                                for (I = 0; I < m_ButchItemList.Count; I++)
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
                            for (I = 0; I < LoadList.Count; I++)
                            {
                                s28 = LoadList[I];
                                if ((s28 != "") && (s28[0] != ';'))
                                {
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n18 = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "/", "\09" });
                                    n1C = HUtil32.Str_ToInt(s30, -1);
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    if (s30 != "")
                                    {
                                        if (s30[0] == '\"')
                                        {
                                            HUtil32.ArrestStringEx(s30, "\"", "\"", ref s30);
                                        }
                                    }
                                    s2C = s30;
                                    s28 = HUtil32.GetValidStr3(s28, ref s30, new string[] { " ", "\09" });
                                    n20 = HUtil32.Str_ToInt(s30, 1);
                                    if ((n18 > 0) && (n1C > 0) && (s2C != ""))
                                    {
                                        MonItem = new TMonItemInfo();
                                        MonItem.SelPoint = n18 - 1;
                                        MonItem.MaxPoint = n1C;
                                        MonItem.ItemName = s2C;
                                        MonItem.Count = n20;
                                        if (HUtil32.Random(MonItem.MaxPoint) <= MonItem.SelPoint)
                                        {
                                            // 计算机率 1/10 随机10<=1 即为所得的物品
                                            m_ButchItemList.Add(MonItem);
                                        }
                                    }
                                }
                            }
                        }
                        if (m_ButchItemList.Count > 0)
                        {
                            m_boExploration = true;// 是否可探索
                        }
                        // LoadList.Free;
                    }
                    // ItemIni.Free;
                }
            }
        }

        public  override void Run()
        {
            int nPower = 0;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    // 走路间隔
                    if ((HUtil32.GetTickCount() - m_dwWalkTick > m_nWalkSpeed) && (m_TargetCret != null) && (!m_TargetCret.m_boDeath))
                    {
                        // 目标不为空
                        if (boIsSpiderMagic)
                        {
                            // 喷出网后,延时1100毫秒显示目标的效果
                            if (HUtil32.GetTickCount() - m_dwSpiderMagicTick > 1100)
                            {
                                boIsSpiderMagic = false;// 是否喷出蜘蛛网
                                SpiderMagicAttack(nPower / 2, m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY, 3);
                                base.Run();
                                return;
                            }
                        }
                        if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2))
                        {
                            if ((HUtil32.Random(4) == 0) && (m_TargetCret.m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] == 0))
                            {
                                // 喷出蜘蛛网
                                if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
                                {
                                    m_dwHitTick = HUtil32.GetTickCount();
                                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));
                                    SendRefMsg(Grobal2.RM_LIGHTING, 1, m_nCurrX, m_nCurrY, m_TargetCret.ToInt(), "");
                                    m_dwSpiderMagicTick = HUtil32.GetTickCount();// 喷出蜘蛛网计时,用于延时处理目标身上的小网显示
                                    boIsSpiderMagic = true;// 是否喷出蜘蛛网
                                }
                            }
                            else
                            {
                                AttackTarget();
                            }
                        }
                        else
                        {
                            this.GotoTargetXY();
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TYanLeiWangSpider.Run");
            }
            base.Run();
        }

        // 物理攻击
        new public  virtual bool AttackTarget()
        {
            bool result;
            int nPower;
            result = false;
            if (m_TargetCret == null)
            {
                return result;
            }
            if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
            {
                m_dwHitTick = HUtil32.GetTickCount();
                if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2))
                {
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC)));
                    HitMagAttackTarget(m_TargetCret, nPower / 2, nPower / 2, true);
                    result = true;
                    return result;
                }
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }

        // 喷出蜘蛛网   被蜘蛛网包围,只能走动,不能跑动
        private void SpiderMagicAttack(int nPower, int nX, int nY, int nRage)
        {
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            BaseObjectList = new List<TBaseObject>();
            try
            {
                GetMapBaseObjects(m_PEnvir, nX, nY, nRage, BaseObjectList);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (IsProperTarget(TargeTBaseObject))
                        {
                            if (TargeTBaseObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                            {
                                // 英雄锁定后,不打锁定怪
                                if (!((THeroObject)(TargeTBaseObject)).m_boTarget)
                                {
                                    TargeTBaseObject.SetTargetCreat(this);
                                }
                            }
                            else
                            {
                                TargeTBaseObject.SetTargetCreat(this);
                            }
                            TargeTBaseObject.SendMsg(this, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                            TargeTBaseObject.MakeSpiderMag(7);// 中蛛网，不能跑动   //改变角色状态
                        }
                    }
                }
            }
            finally
            {
                // BaseObjectList.Free;
            }
        }
    }

    /// <summary>
    /// 灵魂收割者,蓝影刀客 2格内可以攻击的怪
    /// </summary>
    public class TSwordsmanMon : TATMonster
    {
        public TSwordsmanMon()
            : base()
        {
            m_nViewRange = 8;
        }

        public  override bool AttackTarget()
        {
            bool result = false;
            int nPower;
            if (m_TargetCret == null)
            {
                return result;
            }
            if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 2))
            {
                // 2格内物理攻击
                if (HUtil32.GetTickCount() - m_dwHitTick > m_nNextHitTime)
                {
                    m_dwHitTick = HUtil32.GetTickCount();
                    m_dwTargetFocusTick = HUtil32.GetTickCount();
                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), ((short)HUtil32.HiWord(m_WAbil.DC)
                        - HUtil32.LoWord(m_WAbil.DC)));
                    HitMagAttackTarget(m_TargetCret, nPower / 2, nPower / 2, true);
                    result = true;
                    return result;
                }
            }
            else
            {
                if (m_TargetCret.m_PEnvir == m_PEnvir)
                {
                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11) && (Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) <= 11))
                    {
                        SetTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);
                    }
                }
                else
                {
                    DelTargetCreat();
                }
            }
            return result;
        }

        public override void Run()
        {
            byte nCode;
            nCode = 0;
            try
            {
                if (!m_boDeath && !m_boGhost && (m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    nCode = 1;
                    if (((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000) && (m_TargetCret == null))
                    {
                        nCode = 2;
                        m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        SearchTarget();// 搜索可攻击目标
                    }
                    nCode = 3;
                    if (((int)HUtil32.GetTickCount() - m_dwWalkTick) > m_nWalkSpeed)
                    {
                        m_dwWalkTick = HUtil32.GetTickCount();
                        if (!m_boNoAttackMode)
                        {
                            nCode = 4;
                            if (m_TargetCret != null)
                            {
                                nCode = 5;
                                if (AttackTarget())
                                {
                                    base.Run();
                                    return;
                                }
                                nCode = 6;
                                if (m_TargetCret != null)
                                {
                                    nCode = 61;
                                    if ((Math.Abs(m_nCurrX - m_TargetCret.m_nCurrX) > 2) ||
                                        (Math.Abs(m_nCurrY - m_TargetCret.m_nCurrY) > 2))
                                    {
                                        // 目标离远了,走向目标
                                        nCode = 62;
                                        m_nTargetX = m_TargetCret.m_nCurrX;
                                        m_nTargetY = m_TargetCret.m_nCurrY;
                                        this.GotoTargetXY();
                                        base.Run();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                m_nTargetX = -1;
                                if (m_boMission)
                                {
                                    m_nTargetX = m_nMissionX;
                                    m_nTargetY = m_nMissionY;
                                }
                            }
                        }
                        nCode = 7;
                        if (m_nTargetX != -1)
                        {
                            if ((m_TargetCret != null))
                            {
                                if ((Math.Abs(m_nCurrX - m_nTargetX) > 2) || (Math.Abs(m_nCurrY - m_nTargetY) > 2))
                                {
                                    nCode = 8;
                                    this.GotoTargetXY();
                                }
                            }
                            else
                            {
                                this.GotoTargetXY();
                            }
                        }
                        else
                        {
                            nCode = 9;
                            if ((m_TargetCret == null))
                            {
                                Wondering();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TSwordsmanMon.Run Code:" + nCode);
            }
            base.Run();
        }
    }
}
