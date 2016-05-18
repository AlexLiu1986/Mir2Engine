﻿using GameFramework;
using GameFramework.Command;
using System;
using System.Collections;

namespace M2Server
{
    /// <summary>
    /// 调整指定玩家声望
    /// </summary>
    [GameCommand("GamePoint", "调整指定玩家声望", 10)]
    public class GamePointCommand : BaseCommond
    {
        [DefaultCommand]
        public void GamePoint(string[] @params, TPlayObject PlayObject)
        {
            TPlayObject m_PlayObject;
            char Ctr = '1';
            string sHumanName = @params.Length > 0 ? @params[0] : "";
            string sCtr = @params.Length > 1 ? @params[1] : "";
            var nPoint = @params.Length > 2 ? Convert.ToUInt16(@params[2]) : 0;
            if (sHumanName == "")
            {
                return;
            }
            if ((sCtr != ""))
            {
                Ctr = sCtr[0];
            }
            if ((sHumanName == "") || !(new ArrayList(new char[] { '=', '+', '-' }).Contains(Ctr)) || (nPoint < 0) || (nPoint > 100000000)
                || ((sHumanName != "") && (sHumanName[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name,
                    GameMsgDef.g_sGameCommandGamePointHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            switch (sCtr[1])
            {
                case '=':
                    m_PlayObject.m_nGamePoint = (UInt16)nPoint;
                    break;

                case '+':
                    m_PlayObject.m_nGamePoint += (UInt16)nPoint;
                    break;

                case '-':
                    m_PlayObject.m_nGamePoint -= (UInt16)nPoint;
                    break;
            }
            if (M2Share.g_boGameLogGamePoint)
            {
                M2Share.AddGameDataLog(String.Format(GameMsgDef.g_sGameLogMsg1, M2Share.LOG_GAMEPOINT, m_PlayObject.m_sMapName, m_PlayObject.m_nCurrX, m_PlayObject.m_nCurrY,
                    m_PlayObject.m_sCharName, M2Share.g_Config.sGamePointName, nPoint, sCtr[1], m_PlayObject.m_sCharName));
            }
            PlayObject.GameGoldChanged();
            m_PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandGamePointHumanMsg, nPoint, m_PlayObject.m_nGamePoint), TMsgColor.c_Green, TMsgType.t_Hint);
            PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandGamePointGMMsg, sHumanName, nPoint, m_PlayObject.m_nGamePoint), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}