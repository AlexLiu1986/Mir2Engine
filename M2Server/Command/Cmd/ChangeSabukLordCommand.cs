﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整沙巴克所属行会
    /// </summary>
    [GameCommand("ChangeSabukLord", "调整沙巴克所属行会", 10)]
    public class ChangeSabukLordCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeSabukLord(string[] @Params, TPlayObject PlayObject)
        {
            string sCASTLENAME = @Params.Length > 0 ? @Params[0] : "";
            string sGuildName = @Params.Length > 1 ? @Params[1] : "";
            bool boFlag = @Params.Length > 2 ? bool.Parse(@Params[2]) : false;

            if ((sCASTLENAME == "") || (sGuildName == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 城堡名称 行会名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TUserCastle Castle = M2Share.g_CastleManager.Find(sCASTLENAME);
            if (Castle == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandSbkGoldCastleNotFoundMsg, sCASTLENAME), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TGUild Guild = GuildManager.FindGuild(sGuildName);
            if (Guild != null)
            {
                M2Share.AddGameDataLog("27" + "\09" + Castle.m_sOwnGuild + "\09" + '0' + "\09" + '1' + "\09" + "sGuildName" + "\09"
                    + PlayObject.m_sCharName + "\09" + '0' + "\09" + '1' + "\09" + '0');
                Castle.GetCastle(Guild);

                // UserEngine.SendServerGroupMsg(SS_211, nServerIndex, sGuildName);
                PlayObject.SysMsg(Castle.m_sName + " 所属行会已经更改为 " + sGuildName, TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg("行会 " + sGuildName + "还没建立！！！", TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}