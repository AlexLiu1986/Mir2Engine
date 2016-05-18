﻿using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 解除指定玩家物品绑定属性
    /// </summary>
    [GameCommand("UnBindUseItem", "解除指定玩家物品绑定属性", 10)]
    public class UnBindUseItemCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void UnBindUseItem(string[] @Params, TPlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sItem = @Params.Length > 1 ? @Params[1] : "";
            string sType = @Params.Length > 2 ? @Params[2] : "";

            TPlayObject m_PlayObject;
            TUserItem* UserItem = null;
            int nItem = M2Share.GetUseItemIdx(sItem);
            int nBind = -1;
            TItemBind ItemBind;
            int nItemIdx;
            int nMakeIdex;
            string sBindName;
            if ((sType).ToLower().CompareTo(("帐号").ToLower()) == 0)
            {
                nBind = 0;
            }
            if ((sType).ToLower().CompareTo(("人物").ToLower()) == 0)
            {
                nBind = 1;
            }
            if ((sType).ToLower().CompareTo(("IP").ToLower()) == 0)
            {
                nBind = 2;
            }
            if ((sType).ToLower().CompareTo(("死亡").ToLower()) == 0) // 死亡不爆出
            {
                nBind = 3;
            }
            if ((nItem < 0) || (nBind < 0) || (sHumanName == "") || ((sHumanName != "") && (sHumanName[0] == '?')))
            {
                if (M2Share.g_Config.boGMShowFailMsg)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandParamUnKnow, this.Attributes.Name, GameMsgDef.g_sGameCommandBindUseItemHelpMsg), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            m_PlayObject = UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            UserItem = m_PlayObject.m_UseItems[nItem];
            if (UserItem->wIndex == 0)
            {
                PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandBindUseItemNoItemMsg, sHumanName, sItem), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            nItemIdx = UserItem->wIndex;
            nMakeIdex = UserItem->MakeIndex;
            switch (nBind)
            {
                case 0:
                    sBindName = m_PlayObject.m_sUserID;
                    //M2Share.g_ItemBindAccount.__Lock();
                    try
                    {
                        if (M2Share.g_ItemBindAccount.Count > 0)
                        {
                            for (int I = 0; I < M2Share.g_ItemBindAccount.Count; I++)
                            {
                                ItemBind = M2Share.g_ItemBindAccount[I];
                                if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
                                {
                                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sGameCommandBindUseItemAlreadBindMsg, new string[] { sHumanName, sItem }), TMsgColor.c_Red, TMsgType.t_Hint);
                                    return;
                                }
                            }
                        }
                        ItemBind = new TItemBind();
                        ItemBind.nItemIdx = nItemIdx;
                        ItemBind.nMakeIdex = nMakeIdex;
                        ItemBind.sBindName = sBindName;
                        M2Share.g_ItemBindAccount.Insert(0, ItemBind);
                    }
                    finally
                    {
                        //M2Share.g_ItemBindAccount.UnLock();
                    }
                    M2Share.SaveItemBindAccount();
                    PlayObject.SysMsg(string.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]，绑定到%s成功。", M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex, UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);
                    m_PlayObject.SysMsg(string.Format("您的%s[%s]已经绑定到%s[%s]上了。", M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), sType, sBindName), TMsgColor.c_Blue, TMsgType.t_Hint);
                    break;
                case 1:
                    sBindName = m_PlayObject.m_sCharName;
                    //M2Share.g_ItemBindCharName.__Lock();
                    try
                    {
                        if (M2Share.g_ItemBindCharName.Count > 0)
                        {
                            for (int I = 0; I < M2Share.g_ItemBindCharName.Count; I++)
                            {
                                //ItemBind = M2Share.g_ItemBindCharName[I];
                                //if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
                                //{
                                //    this.SysMsg(string.Format(M2Share.g_sGameCommandBindUseItemAlreadBindMsg, new string[] { sHumanName, sItem }), TMsgColor.c_Red, TMsgType.t_Hint);
                                //    return;
                                //}
                            }
                        }
                        ItemBind = new TItemBind();
                        ItemBind.nItemIdx = nItemIdx;
                        ItemBind.nMakeIdex = nMakeIdex;
                        ItemBind.sBindName = sBindName;
                        // M2Share.g_ItemBindCharName.InsertText(0, ItemBind);
                    }
                    finally
                    {
                        //M2Share.g_ItemBindCharName.UnLock();
                    }
                    M2Share.SaveItemBindCharName();
                    //this.SysMsg(string.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]，绑定到%s成功。", new string[] { M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex, UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax, sBindName }), TMsgColor.c_Blue, TMsgType.t_Hint);
                    //PlayObject.SysMsg(string.Format("您的%s[%s]已经绑定到%s[%s]上了。", new string[] { M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), sType, sBindName }), TMsgColor.c_Blue, TMsgType.t_Hint);
                    break;
                case 2:
                    sBindName = m_PlayObject.m_sIPaddr;
                    //M2Share.g_ItemBindIPaddr.__Lock();
                    try
                    {
                        if (M2Share.g_ItemBindIPaddr.Count > 0)
                        {
                            for (int I = 0; I < M2Share.g_ItemBindIPaddr.Count; I++)
                            {
                                //ItemBind = M2Share.g_ItemBindIPaddr[I];
                                //if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.nMakeIdex == nMakeIdex))
                                //{
                                //    this.SysMsg(string.Format(M2Share.g_sGameCommandBindUseItemAlreadBindMsg, new string[] { sHumanName, sItem }), TMsgColor.c_Red, TMsgType.t_Hint);
                                //    return;
                                //}
                            }
                        }
                        ItemBind = new TItemBind();
                        ItemBind.nItemIdx = nItemIdx;
                        ItemBind.nMakeIdex = nMakeIdex;
                        ItemBind.sBindName = sBindName;
                        // M2Share.g_ItemBindIPaddr.InsertText(0, ItemBind);
                    }
                    finally
                    {
                        //M2Share.g_ItemBindIPaddr.UnLock();
                    }
                    M2Share.SaveItemBindIPaddr();
                    //this.SysMsg(string.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]，绑定到%s成功。", new string[] { M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex, UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax, sBindName }), TMsgColor.c_Blue, TMsgType.t_Hint);
                    //PlayObject.SysMsg(string.Format("您的%s[%s]已经绑定到%s[%s]上了。", new string[] { M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), sType, sBindName }), TMsgColor.c_Blue, TMsgType.t_Hint);
                    break;
                case 3:// 人物装备死亡不爆绑定
                    sBindName = m_PlayObject.m_sCharName;
                    HUtil32.EnterCriticalSection(M2Share.g_ItemBindDieNoDropName);
                    try
                    {
                        if (M2Share.g_ItemBindDieNoDropName.Count > 0)
                        {
                            for (int I = 0; I < M2Share.g_ItemBindDieNoDropName.Count; I++)
                            {
                                //ItemBind = M2Share.g_ItemBindDieNoDropName[I];
                                //if ((ItemBind.nItemIdx == nItemIdx) && (ItemBind.sBindName == sBindName))
                                //{
                                //    this.SysMsg(string.Format(M2Share.g_sGameCommandBindUseItemAlreadBindMsg, new string[] { sHumanName, sItem }), TMsgColor.c_Red, TMsgType.t_Hint);
                                //    return;
                                //}
                            }
                        }
                        ItemBind = new TItemBind();
                        ItemBind.nItemIdx = nItemIdx;
                        ItemBind.nMakeIdex = 0;
                        ItemBind.sBindName = sBindName;
                        //M2Share.g_ItemBindDieNoDropName.InsertText(0, ItemBind);
                    }
                    finally
                    {
                        HUtil32.LeaveCriticalSection(M2Share.g_ItemBindDieNoDropName);
                    }
                    M2Share.SaveItemBindDieNoDropName();
                    // 保存人物装备死亡不爆列表 20081127
                    //this.SysMsg(string.Format("%s[%s]IDX[%d]系列号[%d]持久[%d-%d]，绑定到%s成功。", new string[] { M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), UserItem->wIndex, UserItem->MakeIndex, UserItem->Dura, UserItem->DuraMax, sBindName }), TMsgColor.c_Blue, TMsgType.t_Hint);
                    //PlayObject.SysMsg(string.Format("您的%s[%s]已经绑定到%s[%s]上了。", new string[] { M2Share.GetUseItemName(nItem), UserEngine.GetStdItemName(UserItem->wIndex), sType, sBindName }), TMsgColor.c_Blue, TMsgType.t_Hint);
                    break;
            }
        }
    }
}