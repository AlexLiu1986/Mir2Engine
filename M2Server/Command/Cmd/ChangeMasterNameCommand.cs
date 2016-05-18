﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家师傅名称
    /// </summary>
    [GameCommand("ChangeMasterName", "调整指定玩家师傅名称", 10)]
    public class ChangeMasterNameCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeMasterName(string[] @Params, TPlayObject PlayObject)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sMasterName = @Params.Length > 1 ? @Params[1] : "";
            string sIsMaster = @Params.Length > 2 ? @Params[2] : "";
            if ((sHumanName == "") || (sMasterName == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 师徒名称(如果为 无 则清除)", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                if ((sMasterName).ToLower().CompareTo(("无").ToLower()) == 0)
                {
                    m_PlayObject.m_sMasterName = "";
                    m_PlayObject.RefShowName();
                    m_PlayObject.m_boMaster = false;
                    PlayObject.SysMsg(sHumanName + " 的师徒名清除成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                }
                else
                {
                    m_PlayObject.m_sMasterName = sMasterName;
                    if ((sIsMaster != "") && (sIsMaster[0] == '1'))
                    {
                        m_PlayObject.m_boMaster = true;
                    }
                    else
                    {
                        m_PlayObject.m_boMaster = false;
                    }
                    m_PlayObject.RefShowName();
                    PlayObject.SysMsg(sHumanName + " 的师徒名更改成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}