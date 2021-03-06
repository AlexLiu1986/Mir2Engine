﻿using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 调整当前玩家管理模式
    /// </summary>
    [GameCommand("ChangeAdminMode", "调整当前玩家管理模式", 10)]
    public class ChangeAdminModeCommand : BaseCommond
    {
        public void ChangeAdminMode(string[] @Params, TPlayObject PlayObject)
        {
            int nPermission = @Params.Length > 0 ? int.Parse(Params[0]) : 0;
            string sParam1 = @Params.Length > 1 ? Params[1] : "";
            bool boFlag = @Params.Length > 2 ? bool.Parse(Params[2]) : false;
            if ((PlayObject.m_btPermission < nPermission))
            {
                PlayObject.SysMsg(GameMsgDef.g_sGameCommandPermissionTooLow, TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (((sParam1 != "") && (sParam1[0] == '?')))
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.m_boAdminMode = boFlag;
            if (PlayObject.m_boAdminMode)
            {
                PlayObject.SysMsg(GameMsgDef.sGameMasterMode, TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg(GameMsgDef.sReleaseGameMasterMode, TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}