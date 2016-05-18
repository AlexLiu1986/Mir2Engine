﻿using GameFramework;
using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 设置地图模式
    /// </summary>
    [GameCommand("SetMapMode", "设置地图模式", 10)]
    public class SetMapModeCommamd : BaseCommond
    {
        [DefaultCommand]
        public void SetMapMode(string[] @Params, TPlayObject PlayObject)
        {
            string sMapName = @Params.Length > 0 ? @Params[0] : "";
            string sMapMode = @Params.Length > 1 ? @Params[1] : "";
            string sParam1 = @Params.Length > 2 ? @Params[2] : "";
            string sParam2 = @Params.Length > 3 ? @Params[3] : "";
            if ((PlayObject.m_btPermission < 6))
            {
                return;
            }
            if ((sMapName == "") || (sMapMode == ""))
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 地图号 模式", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMapName);
            if ((Envir == null))
            {
                PlayObject.SysMsg(sMapName + " 不存在！！！", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if ((sMapMode).ToLower().CompareTo(("SAFE").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boSAFE = true;
                }
                else
                {
                    Envir.m_boSAFE = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("DARK").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boDARK = true;
                }
                else
                {
                    Envir.m_boDARK = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("DARK").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boDARK = true;
                }
                else
                {
                    Envir.m_boDARK = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("FIGHT").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boFightZone = true;
                }
                else
                {
                    Envir.m_boFightZone = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("FIGHT3").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boFight3Zone = true;
                }
                else
                {
                    Envir.m_boFight3Zone = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("DAY").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boDAY = true;
                }
                else
                {
                    Envir.m_boDAY = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("QUIZ").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boQUIZ = true;
                }
                else
                {
                    Envir.m_boQUIZ = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NORECONNECT").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNORECONNECT = true;
                    Envir.sNoReconnectMap = sParam1;
                }
                else
                {
                    Envir.m_boNORECONNECT = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("MUSIC").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boMUSIC = true;
                    Envir.m_nMUSICID = HUtil32.Str_ToInt(sParam1, -1);
                }
                else
                {
                    Envir.m_boMUSIC = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("EXPRATE").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boEXPRATE = true;
                    Envir.m_nEXPRATE = HUtil32.Str_ToInt(sParam1, -1);
                }
                else
                {
                    Envir.m_boEXPRATE = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("PKWINLEVEL").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boPKWINLEVEL = true;
                    Envir.m_nPKWINLEVEL = HUtil32.Str_ToInt(sParam1, -1);
                }
                else
                {
                    Envir.m_boPKWINLEVEL = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("PKWINEXP").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boPKWINEXP = true;
                    Envir.m_nPKWINEXP = (uint)HUtil32.Str_ToInt(sParam1, -1);
                }
                else
                {
                    Envir.m_boPKWINEXP = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("PKLOSTLEVEL").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boPKLOSTLEVEL = true;
                    Envir.m_nPKLOSTLEVEL = HUtil32.Str_ToInt(sParam1, -1);
                }
                else
                {
                    Envir.m_boPKLOSTLEVEL = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("PKLOSTEXP").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boPKLOSTEXP = true;
                    Envir.m_nPKLOSTEXP = (uint)HUtil32.Str_ToInt(sParam1, -1);
                }
                else
                {
                    Envir.m_boPKLOSTEXP = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("DECHP").ToLower()) == 0)
            {
                if ((sParam1 != "") && (sParam2 != ""))
                {
                    Envir.m_boDECHP = true;
                    Envir.m_nDECHPTIME = HUtil32.Str_ToInt(sParam1, -1);
                    Envir.m_nDECHPPOINT = HUtil32.Str_ToInt(sParam2, -1);
                }
                else
                {
                    Envir.m_boDECHP = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("DECGAMEGOLD").ToLower()) == 0)
            {
                if ((sParam1 != "") && (sParam2 != ""))
                {
                    Envir.m_boDecGameGold = true;
                    Envir.m_nDECGAMEGOLDTIME = HUtil32.Str_ToInt(sParam1, -1);
                    Envir.m_nDecGameGold = HUtil32.Str_ToInt(sParam2, -1);
                }
                else
                {
                    Envir.m_boDecGameGold = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("INCGAMEGOLD").ToLower()) == 0)
            {
                if ((sParam1 != "") && (sParam2 != ""))
                {
                    Envir.m_boIncGameGold = true;
                    Envir.m_nINCGAMEGOLDTIME = HUtil32.Str_ToInt(sParam1, -1);
                    Envir.m_nIncGameGold = HUtil32.Str_ToInt(sParam2, -1);
                }
                else
                {
                    Envir.m_boIncGameGold = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("INCGAMEPOINT").ToLower()) == 0)
            {
                if ((sParam1 != "") && (sParam2 != ""))
                {
                    Envir.m_boINCGAMEPOINT = true;
                    Envir.m_nINCGAMEPOINTTIME = HUtil32.Str_ToInt(sParam1, -1);
                    Envir.m_nINCGAMEPOINT = HUtil32.Str_ToInt(sParam2, -1);
                }
                else
                {
                    Envir.m_boIncGameGold = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("RUNHUMAN").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boRUNHUMAN = true;
                }
                else
                {
                    Envir.m_boRUNHUMAN = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("RUNMON").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boRUNMON = true;
                }
                else
                {
                    Envir.m_boRUNMON = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NEEDHOLE").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNEEDHOLE = true;
                }
                else
                {
                    Envir.m_boNEEDHOLE = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NORECALL").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNORECALL = true;
                }
                else
                {
                    Envir.m_boNORECALL = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NOGUILDRECALL").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNOGUILDRECALL = true;
                }
                else
                {
                    Envir.m_boNOGUILDRECALL = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NODEARRECALL").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNODEARRECALL = true;
                }
                else
                {
                    Envir.m_boNODEARRECALL = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NOMASTERRECALL").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNOMASTERRECALL = true;
                }
                else
                {
                    Envir.m_boNOMASTERRECALL = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NORANDOMMOVE").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNORANDOMMOVE = true;
                }
                else
                {
                    Envir.m_boNORANDOMMOVE = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NODRUG").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNODRUG = true;
                }
                else
                {
                    Envir.m_boNODRUG = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("MINE").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boMINE = true;
                }
                else
                {
                    Envir.m_boMINE = false;
                }
            }
            else if ((sMapMode).ToLower().CompareTo(("NOPOSITIONMOVE").ToLower()) == 0)
            {
                if ((sParam1 != ""))
                {
                    Envir.m_boNOPOSITIONMOVE = true;
                }
                else
                {
                    Envir.m_boNOPOSITIONMOVE = false;
                }
            }
            string sMsg = "地图模式: " + Envir.GetEnvirInfo();
            PlayObject.SysMsg(sMsg, TMsgColor.c_Blue, TMsgType.t_Hint);
        }
    }
}