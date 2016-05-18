﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 在指定地图随机移动
    /// </summary>
    [GameCommand("MapMove", "在指定地图随机移动", 10)]
    public class MapMoveCommand : BaseCommond
    {
        [DefaultCommand]
        public void MapMove(string[] @Params, TPlayObject PlayObject)
        {
            string sMapName = @Params.Length > 0 ? @Params[0] : "";
            if ((sMapName == "") || ((sMapName != "") && (sMapName[0] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandMoveHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMapName);
            if ((Envir == null))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sTheMapNotFound, sMapName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((PlayObject.m_btPermission >= this.Attributes.nPermissionMin) || M2Share.CanMoveMap(sMapName))
            {
                PlayObject.SendRefMsg(Grobal2.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
                PlayObject.MapRandomMove(sMapName, 0);
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sTheMapDisableMove, sMapName, Envir.sMapDesc), TMsgColor.c_Red, TMsgType.t_Hint);//不允许传送
            }
        }
    }
}