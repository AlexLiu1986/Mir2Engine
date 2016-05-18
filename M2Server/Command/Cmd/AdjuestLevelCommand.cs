﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家等级
    /// </summary>
    [GameCommand("AdjuestLevel", "调整指定玩家等级", 10)]
    public class AdjuestLevelCommand : BaseCommond
    {
        [DefaultCommand]
        public void AdjuestLevel(string[] @Params, TPlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            int nLevel = @Params.Length > 1 ? int.Parse(@Params[1]) : 0;
            int nOLevel;
            if (sHumanName == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 等级", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (sHumanName == "")
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 等级", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                nOLevel = m_PlayObject.m_Abil.Level;
                //PlayObject.m_Abil.Level = HUtil32._MAX(1, HUtil32._MIN(M2Share.MAXUPLEVEL, nLevel));
                m_PlayObject.HasLevelUp(1);// 等级调整记录日志
                M2Share.AddGameDataLog("17" + "\09" + m_PlayObject.m_sMapName + "\09" + (m_PlayObject.m_nCurrX).ToString() + "\09" + (m_PlayObject.m_nCurrY).ToString() + "\09"
                    + m_PlayObject.m_sCharName + "\09" + (m_PlayObject.m_Abil.Level).ToString() + "\09" + PlayObject.m_sCharName + "\09" + "+(" + (nLevel).ToString() + ")" + "\09" + "0");
                PlayObject.SysMsg(sHumanName + " 等级调整完成。", TMsgColor.c_Green, TMsgType.t_Hint);
                if (M2Share.g_Config.boShowMakeItemMsg)
                {
                    M2Share.MainOutMessage("[等级调整] " + PlayObject.m_sCharName + "(" + m_PlayObject.m_sCharName + " " + (nOLevel).ToString() + " -> " + m_PlayObject.m_Abil.Level + ")");
                }
            }
            else
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, new string[] { sHumanName }), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}