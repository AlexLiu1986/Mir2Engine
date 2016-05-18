﻿using GameFramework;
using GameFramework.Command;

namespace M2Server.Command
{
    /// <summary>
    /// 调整指定物品名称
    /// </summary>
    [GameCommand("ChangeItemName", "调整指定物品名称", 10)]
    public class ChangeItemNameCommand : BaseCommond
    {
        [DefaultCommand]
        public void ChangeItemName(string[] @params, TPlayObject PlayObject)
        {
            int nMakeIndex;
            int nItemIndex;
            string sMakeIndex = @params.Length > 0 ? @params[0] : "";
            string sItemIndex = @params.Length > 1 ? @params[1] : "";
            string sItemName = @params.Length > 2 ? @params[2] : "";
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            if ((sMakeIndex == "") || (sItemIndex == "") || (sItemName == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 物品编号 物品ID号 物品名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            nMakeIndex = HUtil32.Str_ToInt(sMakeIndex, -1);
            nItemIndex = HUtil32.Str_ToInt(sItemIndex, -1);
            if ((nMakeIndex <= 0) || (nItemIndex < 0))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 物品编号 物品ID号 物品名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (ItemUnit.AddCustomItemName(nMakeIndex, nItemIndex, sItemName))
            {
                ItemUnit.SaveCustomItemName();
                PlayObject.SysMsg("物品名称设置成功。", TMsgColor.c_Green, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg("此物品，已经设置了其它的名称！！！", TMsgColor.c_Red, TMsgType.t_Hint);
        }
    }
}