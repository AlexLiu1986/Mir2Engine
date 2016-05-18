﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 查看禁言列表中的内容(支持权限分配)
    /// </summary>
    [GameCommand("ShutupList", "查看禁言列表中的内容(支持权限分配)", 10)]
    public class ShutupListCommand : BaseCommond
    {
        [DefaultCommand]
        public void ShutupList(string[] @Params, TPlayObject PlayObject)
        {
            string sParam1 = @Params.Length > 0 ? @Params[0] : "";
            if (((sParam1 != "") && (sParam1[1] == '?')))
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, ""), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            HUtil32.EnterCriticalSection(M2Share.g_DenySayMsgList);
            try
            {
                int nCount = M2Share.g_DenySayMsgList.Count;
                if (M2Share.g_DenySayMsgList.Count <= 0)
                {
                    PlayObject.SysMsg(GameMsgDef.g_sGameCommandShutupListIsNullMsg, TMsgColor.c_Green, TMsgType.t_Hint);
                }
                if (nCount > 0)
                {
                    //foreach (var item in M2Share.g_DenySayMsgList)
                    //{
                    //    PlayObject.SysMsg(M2Share.g_DenySayMsgList[item.Key] + ' ' + (((M2Share.g_DenySayMsgList[item.Key]) - HUtil32.GetTickCount()) / 60000).ToString()
                    //        , TMsgColor.c_Green, TMsgType.t_Hint);
                    //}

                    //for (int I = 0; I < M2Share.g_DenySayMsgList.Count; I++)
                    //{
                    //this.SysMsg(M2Share.g_DenySayMsgList[I] + ' ' + ((((uint)M2Share.g_DenySayMsgList[I]) - HUtil32.GetTickCount()) / 60000).ToString(), TMsgColor.c_Green, TMsgType.t_Hint);
                    //}
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.g_DenySayMsgList);
            }
        }
    }
}