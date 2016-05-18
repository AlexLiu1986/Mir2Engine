﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("TestGetBagItems", "", 10)]
    public class TestGetBagItemsCommand : BaseCommond
    {
        [DefaultCommand]
        public void TestGetBagItems(string[] @Params, TPlayObject PlayObject)
        {
            string sParam = @Params.Length > 0 ? @Params[0] : "";
            if ((sParam != "") && (sParam[1] == '?'))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandTestGetBagItemsHelpMsg),
                    TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            byte btDc = 0;
            byte btSc = 0;
            byte btMc = 0;
            byte btDura = 0;
            PlayObject.GetBagUseItems(ref btDc, ref btSc, ref btMc, ref btDura);
            PlayObject.SysMsg(String.Format("DC:%d SC:%d MC:%d DURA:%d", btDc, btSc, btMc, btDura), TMsgColor.c_Blue, TMsgType.t_Hint);
        }
    }
}