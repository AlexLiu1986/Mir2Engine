﻿using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("ShowDenyCharNameLogon", "", 10)]
    public class ShowDenyCharNameLogonCommand : BaseCommond
    {
        [DefaultCommand]
        public void ShowDenyCharNameLogon(string[] @Params, TPlayObject PlayObject)
        {
            M2Share.g_DenyChrNameList.__Lock();
            try
            {
                if (M2Share.g_DenyChrNameList.Count <= 0)
                {
                    PlayObject.SysMsg("禁止登录角色列表为空。", TMsgColor.c_Green, TMsgType.t_Hint);
                    return;
                }
                for (int I = 0; I < M2Share.g_DenyChrNameList.Count; I++)
                {
                    PlayObject.SysMsg(M2Share.g_DenyChrNameList[I], TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            finally
            {
                M2Share.g_DenyChrNameList.UnLock();
            }
        }
    }
}