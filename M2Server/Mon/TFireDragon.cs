﻿using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M2Server.Mon
{
    /// <summary>
    /// 火龙
    /// </summary>
    public class TFireDragon : TCentipedeKingMonster
    {
        public uint m_dwLightTick = 0;

        public TFireDragon()
            : base()
        {
            this.m_boAnimal = false;// 不是动物,即不能挖
            this.m_boStickMode = true;// 不能冲撞模式(即敌人不能使用野蛮冲撞技能攻击)
            this.m_btAntiPoison = 200;// 中毒躲避
            this.m_boUnParalysis = true;// 防麻痹
            this.m_nViewRange = 13;
            this.m_dwAttickTick = HUtil32.GetTickCount();
            this.m_boFixedHideMode = false;// 不隐身
            m_dwLightTick = HUtil32.GetTickCount();// 守护兽发光间
        }

        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            this.m_boStickMode = true;// 不能冲撞模式(即敌人不能使用野蛮冲撞技能攻击)
            this.m_btAntiPoison = 200;// 中毒躲避
            this.m_boUnParalysis = true;// 防麻痹
            this.m_boFixedHideMode = false;// 不隐身
        }

        private bool sub_4A5B0C(int nCode)
        {
            bool result;
            TBaseObject BaseObject;
            result = false;
            if (this.m_VisibleActors.Count > 0)
            {
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = this.m_VisibleActors[I].BaseObject;
                    if (BaseObject == null)
                    {
                        continue;
                    }
                    if (BaseObject.m_boDeath)
                    {
                        continue;
                    }
                    if (this.IsProperTarget(BaseObject))
                    {
                        if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) <= nCode) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) <= nCode))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        // 大火圈攻击
        private bool MagBigExplosion(int nPower, int nX, int nY, int nRage)
        {
            bool result;
            List<TBaseObject> BaseObjectList;
            TBaseObject TargeTBaseObject;
            result = false;
            this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);// 调整火龙的方向
            BaseObjectList = new List<TBaseObject>();
            try
            {
                this.GetMapBaseObjects(this.m_PEnvir, nX, nY, nRage, BaseObjectList);
                if (BaseObjectList.Count > 0)
                {
                    for (int I = 0; I < BaseObjectList.Count; I++)
                    {
                        TargeTBaseObject = BaseObjectList[I];
                        if (TargeTBaseObject != null)
                        {
                            if (TargeTBaseObject.m_boDeath || (TargeTBaseObject.m_boGhost))
                            {
                                continue;
                            }
                            if (this.IsProperTarget(TargeTBaseObject))
                            {
                                this.SetTargetCreat(TargeTBaseObject);
                                TargeTBaseObject.SendMsg(this, Grobal2.RM_MAGSTRUCK, 0, nPower, 0, 0, "");
                                result = true;
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

        // 刷新属性
        public  override bool AttackTarget()
        {
            bool result;
            TAbility WAbil;
            int nPower;
            int K;
            int J;
            TBaseObject BaseObject;
            result = false;
            try
            {
                if (!sub_4A5B0C(this.m_nViewRange))  // 守护兽15格开始发亮，没有目标则退出
                {
                    return result;
                }
                if ((HUtil32.GetTickCount() - m_dwLightTick > 10000))
                {
                    // 通知守护兽发光
                    m_dwLightTick = HUtil32.GetTickCount();
                    if (UserEngine.m_MonObjectList.Count > 0) // 循环列表，找出同个地图的守护兽，
                    {
                        K = HUtil32.Random(6);// 随机一个守护兽攻击
                        J = 0;
                        for (int I = 0; I < UserEngine.m_MonObjectList.Count; I++)
                        {
                            BaseObject = ((TBaseObject)(UserEngine.m_MonObjectList[I]));
                            if (BaseObject != null)
                            {
                                if (BaseObject.m_PEnvir == this.m_PEnvir)
                                {
                                    // 同个地图内
                                    if (((BaseObject) as TFireDragonGuard).m_boLight || ((BaseObject) as TFireDragonGuard).m_boAttick)
                                    {
                                        break;// 上次没有处理完就退出循环
                                    }
                                    if (J == K)// 最后熄灭的怪，即攻击怪
                                    {
                                        ((BaseObject) as TFireDragonGuard).m_boAttick = true;
                                        ((BaseObject) as TFireDragonGuard).m_dwLightTime = 3000;// 发光时长比其它怪多
                                        BaseObject.SendRefMsg(Grobal2.RM_FAIRYATTACKRATE, 1, BaseObject.m_nCurrX, BaseObject.m_nCurrY, 0, "");// 发送最后熄灭的特殊消息(发亮)
                                    }
                                    else
                                    {
                                        // 发送同时熄灭的消息(发亮)
                                        BaseObject.SendRefMsg(Grobal2.RM_LIGHTING, 1, BaseObject.m_nCurrX, BaseObject.m_nCurrY, 0, "");
                                    }
                                    ((BaseObject) as TFireDragonGuard).m_boLight = true;
                                    ((BaseObject) as TFireDragonGuard).m_dwSearchEnemyTick = HUtil32.GetTickCount();
                                    J++;
                                    if (J >= 6)
                                    {
                                        break;// 6个怪就退出循环
                                    }
                                }
                            }
                        }
                    }
                }
                if (!sub_4A5B0C(this.m_nViewRange - 2))
                {
                    return result;// 火龙魔兽11格,没有目标则退出
                }
                if (((int)HUtil32.GetTickCount() - this.m_dwHitTick) > this.m_nNextHitTime)
                {
                    this.m_dwHitTick = HUtil32.GetTickCount();
                    if (HUtil32.Random(3) == 0)
                    {
                        // 群雷攻击
                        this.SendAttackMsg(Grobal2.RM_HIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY);
                        WAbil = this.m_WAbil;
                        nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                        if (this.m_VisibleActors.Count > 0)
                        {
                            for (int I = 0; I < this.m_VisibleActors.Count; I++)
                            {
                                BaseObject = this.m_VisibleActors[I].BaseObject;
                                if (BaseObject == null)
                                {
                                    continue;
                                }
                                if (BaseObject.m_boDeath)
                                {
                                    continue;
                                }
                                if (this.IsProperTarget(BaseObject))
                                {
                                    if ((Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) < this.m_nViewRange) && (Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY) < this.m_nViewRange))
                                    {
                                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                        this.SendDelayMsg(this, Grobal2.RM_DELAYMAGIC, nPower, HUtil32.MakeLong(BaseObject.m_nCurrX, BaseObject.m_nCurrY), 2, 0, "", 600);
                                        if (HUtil32.Random(4) == 0)
                                        {
                                            this.m_TargetCret = BaseObject;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // 大火圈攻击
                        if (this.m_TargetCret != null)
                        {
                            WAbil = this.m_WAbil;
                            nPower = (HUtil32.Random(((short)HUtil32.HiWord(WAbil.DC) - HUtil32.LoWord(WAbil.DC)) + 1) + HUtil32.LoWord(WAbil.DC));
                            MagBigExplosion(nPower, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3);
                            this.SendRefMsg(Grobal2.RM_LIGHTING, 1, this.m_nCurrX, this.m_nCurrY, 0, "");
                        }
                    }
                }
                result = true;
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFireDragon.AttackTarget");
            }
            return result;
        }

        public override void Run()
        {
            try
            {
                if (!this.m_boGhost && !this.m_boDeath && (this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))
                {
                    if (((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 1000) && (this.m_TargetCret == null))
                    {
                        this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                        this.SearchTarget();// 搜索可攻击目标
                    }
                    if (((int)HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed)
                    {
                        this.m_dwWalkTick = HUtil32.GetTickCount();
                        if ((HUtil32.GetTickCount() - this.m_dwAttickTick) > 3000)
                        {
                            if (AttackTarget())
                            {
                                base.Run();
                                return;
                            }
                            if ((HUtil32.GetTickCount() - this.m_dwAttickTick) > 10000)
                            {
                                if (this.m_VisibleActors.Count > 0)
                                {
                                    for (int I = 0; I < this.m_VisibleActors.Count; I++)
                                    {
                                        Dispose((this.m_VisibleActors[I]));
                                    }
                                }
                                this.m_VisibleActors.Clear();
                                this.m_dwAttickTick = HUtil32.GetTickCount();
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{异常} TFireDragon.Run");
            }
            base.Run();
        }
    }
}
