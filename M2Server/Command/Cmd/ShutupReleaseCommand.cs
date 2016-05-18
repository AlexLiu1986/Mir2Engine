using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    [GameCommand("ShutupRelease", "", 10)]
    public class ShutupReleaseCommand : BaseCommond
    {
        [DefaultCommand]
        public void ShutupRelease(string[] @params, TPlayObject PlayObject)
        {
            string sHumanName = @params.Length > 0 ? @params[0] : "";
            bool boAll = @params.Length > 1 ? bool.Parse(@params[1]) : false;

            if ((sHumanName == "") || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandShutupReleaseHelpMsg),
                    TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            HUtil32.EnterCriticalSection(M2Share.g_DenySayMsgList);
            try
            {
                //if (M2Share.g_DenySayMsgList.ContainsKey(sHumanName))
                //{
                //    M2Share.g_DenySayMsgList.Remove(sHumanName);
                //    TPlayObject m_PlayObject = UserEngine.GetPlayObject(sHumanName);
                //    //PlayObject = UserEngine.GetPlayObject(sHumanName);
                //    if (m_PlayObject != null)
                //    {
                //        m_PlayObject.SysMsg(GameMsgDef.g_sGameCommandShutupReleaseCanSendMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                //    }
                //    if (boAll)
                //    {
                //        //UserEngine.SendServerGroupMsg(SS_210, nServerIndex, sHumanName);
                //    }
                //    PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandShutupReleaseHumanCanSendMsg, sHumanName),
                //        TMsgColor.c_Green, TMsgType.t_Hint);
                //}
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.g_DenySayMsgList);
            }
        }
    }
}