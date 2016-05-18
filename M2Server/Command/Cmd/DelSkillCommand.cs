﻿using GameFramework;
using GameFramework.Command;
using System;
using System.Runtime.InteropServices;

namespace M2Server
{
    /// <summary>
    /// 删除指定玩家技能
    /// </summary>
    [GameCommand("DelSkill", "删除指定玩家技能", 10)]
    public class DelSkillCommand : BaseCommond
    {
        [DefaultCommand]
        public unsafe void DelSkill(string[] @Params, TPlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            string sHumanName = @Params.Length > 0 ? @Params[0] : "";
            string sSkillName = @Params.Length > 1 ? @Params[1] : "";
            string Herostr = @Params.Length > 2 ? @Params[2] : "";

            TPlayObject m_PlayObject;
            THeroObject m_HeroObject;
            bool boDelAll;
            TUserMagic* UserMagic;
            if ((sHumanName == "") || (sSkillName == ""))
            {
                if (GameConfig.boGMShowFailMsg)
                {
                    PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 人物名称 技能名称)", TMsgColor.c_Red, TMsgType.t_Hint);
                }
                return;
            }
            if ((sSkillName).ToLower().CompareTo(("All").ToLower()) == 0)
            {
                boDelAll = true;
            }
            else
            {
                boDelAll = false;
            }
            if ((Herostr).ToLower().CompareTo(("hero").ToLower()) == 0)
            {
                m_HeroObject = ((THeroObject)(UserEngine.GetHeroObject(sHumanName)));
                if (m_HeroObject == null)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, new string[] { sHumanName }), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                for (int I = m_HeroObject.m_MagicList.Count - 1; I >= 0; I--)
                {
                    if (m_HeroObject.m_MagicList.Count <= 0)
                    {
                        break;
                    }
                    UserMagic = (TUserMagic*)m_HeroObject.m_MagicList[I];
                    if (UserMagic != null)
                    {
                        if ((UserMagic->MagicInfo.wMagicId == 68) && ((m_HeroObject.m_MaxExp68 != 0) || (m_HeroObject.m_Exp68 != 0))) // 是酒气护体
                        {
                            m_HeroObject.m_MaxExp68 = 0;
                            m_HeroObject.m_Exp68 = 0;
                        }
                        if (boDelAll)
                        {
                            UserMagic = null;
                            m_HeroObject.m_MagicList.RemoveAt(I);
                        }
                        else
                        {
                            if (HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, 0, UserMagic->MagicInfo.DescrLen).ToLower().CompareTo((sSkillName).ToLower()) == 0)
                            {
                                m_HeroObject.SendDelMagic(UserMagic);
                                UserMagic = null;
                                m_HeroObject.m_MagicList.RemoveAt(I);
                                m_HeroObject.SysMsg(string.Format("技能{0}已删除。", sSkillName), TMsgColor.c_Green, TMsgType.t_Hint);
                                PlayObject.SysMsg(string.Format("{0}的技能{1}已删除。", sHumanName, sSkillName), TMsgColor.c_Green, TMsgType.t_Hint);
                                break;
                            }
                        }
                    }
                }
                m_HeroObject.RecalcAbilitys();
                m_HeroObject.CompareSuitItem(false);// 套装
            }
            else
            {
                m_PlayObject = UserEngine.GetPlayObject(sHumanName);
                if (m_PlayObject == null)
                {
                    PlayObject.SysMsg(string.Format(GameMsgDef.g_sNowNotOnLineOrOnOtherServer, new string[] { sHumanName }), TMsgColor.c_Red, TMsgType.t_Hint);
                    return;
                }
                for (int I = m_PlayObject.m_MagicList.Count - 1; I >= 0; I--)
                {
                    if (m_PlayObject.m_MagicList.Count <= 0)
                    {
                        break;
                    }
                    UserMagic = (TUserMagic*)m_PlayObject.m_MagicList[I];
                    if (UserMagic != null)
                    {
                        if ((UserMagic->MagicInfo.wMagicId == 68) && ((m_PlayObject.m_MaxExp68 != 0) || (m_PlayObject.m_Exp68 != 0)))// 是酒气护体
                        {
                            m_PlayObject.m_MaxExp68 = 0;
                            m_PlayObject.m_Exp68 = 0;
                        }
                        if (boDelAll)
                        {
                            Marshal.FreeHGlobal((IntPtr)UserMagic);
                            m_PlayObject.m_MagicList.RemoveAt(I);
                        }
                        else
                        {
                            if (HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, 0, UserMagic->MagicInfo.DescrLen).ToLower().CompareTo((sSkillName).ToLower()) == 0)
                            {
                                m_PlayObject.SendDelMagic(UserMagic);
                                Marshal.FreeHGlobal((IntPtr)UserMagic);
                                m_PlayObject.m_MagicList.RemoveAt(I);
                                m_PlayObject.SysMsg(string.Format("技能{0}已删除。", sSkillName), TMsgColor.c_Green, TMsgType.t_Hint);
                                PlayObject.SysMsg(string.Format("{0}的技能{1}已删除。", sHumanName, sSkillName), TMsgColor.c_Green, TMsgType.t_Hint);
                                break;
                            }
                        }
                    }
                }
                m_PlayObject.RecalcAbilitys();
                m_PlayObject.CompareSuitItem(false);
            }
        }
    }
}