﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家属性的复位
    /// </summary>
    [GameCommand("RestBonuPoint", "调整指定玩家属性的复位", 10)]
    public class RestBonuPointCommand : BaseCommond
    {
        [DefaultCommand]
        public void RestBonuPoint(string[] @Params, TPlayObject PlayObject)
        {
            string sHumName = @Params.Length > 0 ? @Params[0] : "";
            int nTotleUsePoint;
            if (sHumName == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumName);
            if (m_PlayObject != null)
            {
                nTotleUsePoint = m_PlayObject.m_BonusAbil.DC + m_PlayObject.m_BonusAbil.MC + m_PlayObject.m_BonusAbil.SC + m_PlayObject.m_BonusAbil.AC + m_PlayObject.m_BonusAbil.MAC
                    + m_PlayObject.m_BonusAbil.HP + m_PlayObject.m_BonusAbil.MP + m_PlayObject.m_BonusAbil.Hit + m_PlayObject.m_BonusAbil.Speed + m_PlayObject.m_BonusAbil.X2;
                m_PlayObject.m_nBonusPoint += nTotleUsePoint;
                m_PlayObject.SendMsg(m_PlayObject, Grobal2.RM_ADJUST_BONUS, 0, 0, 0, 0, "");
                m_PlayObject.HasLevelUp(0);
                m_PlayObject.SysMsg("分配点数已复位！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(sHumName + " 的分配点数已复位.", TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}