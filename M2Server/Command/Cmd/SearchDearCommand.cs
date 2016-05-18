﻿using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 此命令用于查询配偶当前所在位置
    /// </summary>
    [GameCommand("SearchDear", "此命令用于查询配偶当前所在位置", 10)]
    public class SearchDearCommand
    {
        [DefaultCommand]
        public void SearchDear(string[] @Params, TPlayObject PlayObject)
        {
            string sParam = @Params.Length > 0 ? @Params[0] : "";
            if ((sParam != "") && (sParam[0] == '?'))
            {
                PlayObject.SysMsg("此命令用于查询配偶当前所在位置。", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_sDearName == "")
            {
                // '你都没结婚查什么？'
                PlayObject.SysMsg(GameMsgDef.g_sYouAreNotMarryedMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_DearHuman == null)
            {
                if (PlayObject.m_btGender == 0)
                {
                    // '你的老婆还没有上线！！！'
                    PlayObject.SysMsg(GameMsgDef.g_sYourWifeNotOnlineMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                }
                else
                {
                    // '你的老公还没有上线！！！'
                    PlayObject.SysMsg(GameMsgDef.g_sYourHusbandNotOnlineMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if (PlayObject.m_btGender == 0)
            {
                // '你的老婆现在位于:'
                PlayObject.SysMsg(GameMsgDef.g_sYourWifeNowLocateMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                PlayObject.SysMsg(PlayObject.m_DearHuman.m_sCharName + ' ' + PlayObject.m_DearHuman.m_PEnvir.sMapDesc + '(' + PlayObject.m_DearHuman.m_nCurrX + ':'
                    + PlayObject.m_DearHuman.m_nCurrY + ')', TMsgColor.c_Green, TMsgType.t_Hint);

                // '你的老公正在找你，他现在位于:'
                PlayObject.m_DearHuman.SysMsg(GameMsgDef.g_sYourHusbandSearchLocateMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                PlayObject.m_DearHuman.SysMsg(PlayObject.m_sCharName + ' ' + PlayObject.m_PEnvir.sMapDesc + '(' + PlayObject.m_nCurrX + ':'
                    + PlayObject.m_nCurrY + ')', TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                // '你的老公现在位于:'
                PlayObject.SysMsg(GameMsgDef.g_sYourHusbandNowLocateMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(PlayObject.m_DearHuman.m_sCharName + ' ' + PlayObject.m_DearHuman.m_PEnvir.sMapDesc + '(' + PlayObject.m_DearHuman.m_nCurrX + ':'
                    + PlayObject.m_DearHuman.m_nCurrY + ')', TMsgColor.c_Green, TMsgType.t_Hint);

                // '你的老婆正在找你，她现在位于:'
                PlayObject.m_DearHuman.SysMsg(GameMsgDef.g_sYourWifeSearchLocateMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                PlayObject.m_DearHuman.SysMsg(PlayObject.m_sCharName + ' ' + PlayObject.m_PEnvir.sMapDesc + '(' + PlayObject.m_nCurrX + ':'
                    + PlayObject.m_nCurrY + ')', TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}