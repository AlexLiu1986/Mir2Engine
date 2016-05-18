﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("TakeOffHorse", "", 10)]
    public class TakeOffHorseCommand : BaseCommond
    {
        [DefaultCommand]
        public void TakeOffHorse(string[] @Params, TPlayObject PlayObject)
        {
            string sParam = @Params.Length > 0 ? @Params[0] : "";

            if ((sParam != "") && (sParam[1] == '?'))
            {
                PlayObject.SysMsg("下马命令，在骑马状态输入此命令下马。", TMsgColor.c_Red, TMsgType.t_Hint);
                PlayObject.SysMsg(String.Format("命令格式: @%s", this.Attributes.Name), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (!PlayObject.m_boOnHorse)
            {
                return;
            }
            PlayObject.m_boOnHorse = false;
            PlayObject.FeatureChanged();
        }
    }
}