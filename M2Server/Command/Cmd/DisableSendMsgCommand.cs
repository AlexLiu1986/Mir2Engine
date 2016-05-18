﻿using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    [GameCommand("DisableSendMsg", "", 10)]
    public class DisableSendMsgCommand : BaseCommond
    {
        [DefaultCommand]
        public void DisableSendMsg(string[] @Params, TPlayObject PlayObject)
        {
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            if (sHumanName == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject != null)
            {
                m_PlayObject.m_boFilterSendMsg = true;
            }
            M2Share.g_DisableSendMsgList.Add(sHumanName);
            M2Share.SaveDisableSendMsgList();
            PlayObject.SysMsg(sHumanName + " 已加入禁言列表。", TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}