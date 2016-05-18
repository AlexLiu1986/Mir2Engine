﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 删除指定玩家属性点
    /// </summary>
    [GameCommand("DelBonuPoint", "删除指定玩家属性点", 10)]
    public class DelBonuPointCommand : BaseCommond
    {
        [DefaultCommand]
        public void DelBonuPoint(string[] @Params, TPlayObject PlayObject)
        {
            string sHumName = @Params.Length > 0 ? @Params[0] : "";
            if (sHumName == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumName);
            if (m_PlayObject != null)
            {
                m_PlayObject.m_nBonusPoint = 0;
                m_PlayObject.SendMsg(PlayObject, Grobal2.RM_ADJUST_BONUS, 0, 0, 0, 0, "");
                m_PlayObject.HasLevelUp(0);
                m_PlayObject.SysMsg("分配点数已清除！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(sHumName + " 的分配点数已清除.", TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}