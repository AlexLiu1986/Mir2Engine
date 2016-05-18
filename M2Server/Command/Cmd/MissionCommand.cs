﻿using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 设置怪物集中目标
    /// </summary>
    [GameCommand("Mission", "设置怪物集中目标", 10)]
    public class MissionCommand : BaseCommond
    {
        [DefaultCommand]
        public void Mission(string[] @Params, TPlayObject PlayObject)
        {
            string sX = @Params.Length > 0 ? @Params[0] : "";
            string sY = @Params.Length > 1 ? @Params[1] : "";
            int nX;
            int nY;
            if ((sX == "") || (sY == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " X  Y", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            nX = HUtil32.Str_ToInt(sX, 0);
            nY = HUtil32.Str_ToInt(sY, 0);
            M2Share.g_boMission = true;
            M2Share.g_sMissionMap = PlayObject.m_sMapName;
            M2Share.g_nMissionX = nX;
            M2Share.g_nMissionY = nY;
            PlayObject.SysMsg("怪物集中目标已设定为: " + PlayObject.m_sMapName + '(' + M2Share.g_nMissionX + ':' + M2Share.g_nMissionY + ')', TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}