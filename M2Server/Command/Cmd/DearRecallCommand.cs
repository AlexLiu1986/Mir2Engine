﻿using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 夫妻传送，将对方传送到自己身边，对方必须允许传送。
    /// </summary>
    [GameCommand("DearRecall", "夫妻传送", 10)]
    public class DearRecallCommond : BaseCommond
    {
        [DefaultCommand]
        public void DearRecall(string[] @params, TPlayObject PlayObject)
        {
            string sParam = @params.Length > 0 ? @params[0] : "";
            if (sParam == "")
            {
                return;
            }
            if ((sParam != "") && (sParam[0] == '?'))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " (夫妻传送，将对方传送到自己身边，对方必须允许传送。)", TMsgColor.c_Green, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_sDearName == "")
            {
                PlayObject.SysMsg("你没有结婚！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_PEnvir.m_boNODEARRECALL)
            {
                PlayObject.SysMsg("本地图禁止夫妻传送！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_DearHuman == null)
            {
                if (PlayObject.m_btGender == 0)
                {
                    PlayObject.SysMsg("你的老婆不在线！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                else
                {
                    PlayObject.SysMsg("你的老公不在线！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (HUtil32.GetTickCount() - PlayObject.m_dwDearRecallTick < 10000)
            {
                PlayObject.SysMsg("稍等会才能再次使用此功能！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.m_dwDearRecallTick = HUtil32.GetTickCount();
            if (PlayObject.m_DearHuman.m_boCanDearRecall)
            {
                PlayObject.RecallHuman(PlayObject.m_DearHuman.m_sCharName);
            }
            else
            {
                PlayObject.SysMsg(PlayObject.m_DearHuman.m_sCharName + " 不允许传送！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
        }
    }
}