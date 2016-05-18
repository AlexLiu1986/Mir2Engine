using GameFramework;
using System;
using System.Collections;
using System.IO;

namespace M2Server
{
    public class TRobotObject: TPlayObject
    {
        public string m_sScriptFileName = String.Empty;
        public ArrayList m_AutoRunList = null;

        public TRobotObject()
            : base()
        {
            m_AutoRunList = new ArrayList();
            this.m_boSuperMan = true;
            this.m_boRunPlayRobotManage = false;// 关闭个人机器人
            this.m_boRobotObject = true;
        }

        ~TRobotObject()
        {
            ClearScript();
            Dispose(m_AutoRunList);
        }

        private void AutoRun(TAutoRunInfo AutoRunInfo)
        {
            try {
                if ((M2Share.g_RobotNPC == null) || (AutoRunInfo == null))
                {
                    return;
                }
                
                if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > AutoRunInfo.dwRunTimeLen)
                {
                    switch(AutoRunInfo.nRunCmd)
                    {
                        case SDK.nRONPCLABLEJMP:
                            switch(AutoRunInfo.nMoethod)
                            {
                                case SDK.nRODAY:// 24 * 60 * 60 * 1000
                                    if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 8640000 * ((uint)AutoRunInfo.nParam1))
                                    {
                                        AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                        M2Share.g_RobotNPC.GotoLable(this, AutoRunInfo.sParam2, false);
                                    }
                                    break;
                                case SDK.nROHOUR:// 60 * 60 * 1000
                                    if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 3600000 * ((uint)AutoRunInfo.nParam1))
                                    {
                                        AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                        M2Share.g_RobotNPC.GotoLable(this, AutoRunInfo.sParam2, false);
                                    }
                                    break;
                                case SDK.nROMIN:// 60 * 1000
                                    if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 60000 * ((uint)AutoRunInfo.nParam1))
                                    {
                                        AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                        M2Share.g_RobotNPC.GotoLable(this, AutoRunInfo.sParam2, false);
                                    }
                                    break;
                                case SDK.nROSEC:
                                    if (HUtil32.GetTickCount() - AutoRunInfo.dwRunTick > 1000 * ((uint)AutoRunInfo.nParam1))
                                    {
                                        AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                        M2Share.g_RobotNPC.GotoLable(this, AutoRunInfo.sParam2, false);
                                    }
                                    break;
                                case SDK.nRUNONWEEK:
                                    AutoRunOfOnWeek(AutoRunInfo);
                                    break;
                                case SDK.nRUNONDAY:
                                    AutoRunOfOnDay(AutoRunInfo);
                                    break;
                            }
                            break;
                    }
                }
            }
            catch {
                M2Share.MainOutMessage("{异常} TRobotObject.AutoRun");
            }
        }

        private void AutoRunOfOnDay(TAutoRunInfo AutoRunInfo)
        {
            int nMIN;
            int nHOUR;
            int wHour;
            int wMin;
            int wSec;
            int wMSec;
            string sMIN = string.Empty;
            string sHOUR = string.Empty;
            string sLineText = string.Empty;
            string sLabel = string.Empty;
            sLineText = AutoRunInfo.sParam1;
            sLineText = HUtil32.GetValidStr3(sLineText, ref sHOUR, new string[] {":"});
            sLineText = HUtil32.GetValidStr3(sLineText, ref sMIN, new string[] {":"});
            nHOUR = HUtil32.Str_ToInt(sHOUR,  -1);
            nMIN = HUtil32.Str_ToInt(sMIN,  -1);
            sLabel = AutoRunInfo.sParam2;
            wHour = DateTime.Now.Hour;
            wMin = DateTime.Now.Minute;
            wSec = DateTime.Now.Second;
            wMSec = DateTime.Now.Millisecond;
            if ((nHOUR >= 0 && nHOUR<= 24) && (nMIN >= 0 && nMIN<= 60))
            {
                if ((wHour == nHOUR))
                {
                    if ((wMin == nMIN))
                    {
                        if (!AutoRunInfo.boStatus)
                        {
                            M2Share.g_RobotNPC.GotoLable(this, AutoRunInfo.sParam2, false);
                            AutoRunInfo.boStatus = true;
                        }
                    }
                    else
                    {
                        AutoRunInfo.boStatus = false;
                    }
                }
            }
        }

        private void AutoRunOfOnWeek(TAutoRunInfo AutoRunInfo)
        {
            int nMIN;
            int nHOUR;
            int nWeek;
            DayOfWeek wWeek;
            int wHour;
            int wMin;
            int wSec;
            int wMSec;
            string sMIN = string.Empty;
            string sHOUR = string.Empty;
            string sWeek = string.Empty;
            string sLineText = string.Empty;
            string sLabel = string.Empty;
            sLineText = AutoRunInfo.sParam1;
            sLineText = HUtil32.GetValidStr3(sLineText, ref sWeek, new string[] {":"});
            sLineText = HUtil32.GetValidStr3(sLineText, ref sHOUR, new string[] {":"});
            sLineText = HUtil32.GetValidStr3(sLineText, ref sMIN, new string[] {":"});
            nWeek = HUtil32.Str_ToInt(sWeek,  -1);
            nHOUR = HUtil32.Str_ToInt(sHOUR,  -1);
            nMIN = HUtil32.Str_ToInt(sMIN,  -1);
            sLabel = AutoRunInfo.sParam2;
            wHour = DateTime.Now.Hour;
            wMin = DateTime.Now.Minute;
            wSec = DateTime.Now.Second;
            wMSec = DateTime.Now.Millisecond;
            wWeek = DateTime.Now.DayOfWeek;
            if ((nWeek >= 1 && nWeek<= 7) && (nHOUR >= 0 && nHOUR<= 24) && (nMIN >= 0 && nMIN<= 60))
            {
                if ((wWeek.Equals(nWeek)) && (wHour == nHOUR))
                {
                    if ((wMin == nMIN))
                    {
                        if (!AutoRunInfo.boStatus)
                        {
                            M2Share.g_RobotNPC.GotoLable(this, AutoRunInfo.sParam2, false);
                            AutoRunInfo.boStatus = true;
                        }
                    }
                    else
                    {
                        AutoRunInfo.boStatus = false;
                    }
                }
            }
        }

        private void ClearScript()
        {
            if (m_AutoRunList.Count > 0)
            {
                for (int I = 0; I < m_AutoRunList.Count; I ++ )
                {
                    if (((TAutoRunInfo)(m_AutoRunList[I])) != null)
                    {
                        Dispose(((TAutoRunInfo)(m_AutoRunList[I])));
                    }
                }
            }
            m_AutoRunList.Clear();
        }

        // 是否已执行操作；
        public void LoadScript()
        {
            TStringList LoadList;
            string sFileName = string.Empty;
            string sLineText = string.Empty;
            string sActionType = string.Empty;
            string sRunCmd = string.Empty;
            string sMoethod = string.Empty;
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            string sParam4 = string.Empty;
            TAutoRunInfo AutoRunInfo;
            sFileName = M2Share.g_Config.sEnvirDir + "Robot_def\\" + m_sScriptFileName + ".txt";
            if (File.Exists(sFileName))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(sFileName);
                for (int I = 0; I < LoadList.Count; I ++ )
                {
                    sLineText = LoadList[I];
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sActionType, new string[] {" ", "/", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sRunCmd, new string[] {" ", "/", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sMoethod, new string[] {" ", "/", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sParam1, new string[] {" ", "/", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sParam2, new string[] {" ", "/", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sParam3, new string[] {" ", "/", "\09"});
                        sLineText = HUtil32.GetValidStr3(sLineText, ref sParam4, new string[] {" ", "/", "\09"});
                        if ((sActionType).ToLower().CompareTo((SDK.sROAUTORUN).ToLower()) == 0)
                        {
                            if ((sRunCmd).ToLower().CompareTo((SDK.sRONPCLABLEJMP).ToLower()) == 0)
                            {
                                AutoRunInfo = new TAutoRunInfo();
                                AutoRunInfo.dwRunTick = HUtil32.GetTickCount();
                                AutoRunInfo.dwRunTimeLen = 0;
                                AutoRunInfo.boStatus = false;
                                AutoRunInfo.nRunCmd = SDK.nRONPCLABLEJMP;
                                if ((sMoethod).ToLower().CompareTo((SDK.sRODAY).ToLower()) == 0)
                                {
                                    AutoRunInfo.nMoethod = SDK.nRODAY;
                                }
                                if ((sMoethod).ToLower().CompareTo((SDK.sROHOUR).ToLower()) == 0)
                                {
                                    AutoRunInfo.nMoethod = SDK.nROHOUR;
                                }
                                if ((sMoethod).ToLower().CompareTo((SDK.sROMIN).ToLower()) == 0)
                                {
                                    AutoRunInfo.nMoethod = SDK.nROMIN;
                                }
                                if ((sMoethod).ToLower().CompareTo((SDK.sROSEC).ToLower()) == 0)
                                {
                                    AutoRunInfo.nMoethod = SDK.nROSEC;
                                }
                                if ((sMoethod).ToLower().CompareTo((SDK.sRUNONWEEK).ToLower()) == 0)
                                {
                                    AutoRunInfo.nMoethod = SDK.nRUNONWEEK;
                                }
                                if ((sMoethod).ToLower().CompareTo((SDK.sRUNONDAY).ToLower()) == 0)
                                {
                                    AutoRunInfo.nMoethod = SDK.nRUNONDAY;
                                }
                                AutoRunInfo.sParam1 = sParam1;
                                AutoRunInfo.sParam2 = sParam2;
                                AutoRunInfo.sParam3 = sParam3;
                                AutoRunInfo.sParam4 = sParam4;
                                AutoRunInfo.nParam1 = HUtil32.Str_ToInt(sParam1, 1);
                                m_AutoRunList.Add(AutoRunInfo);
                            }
                        }
                    }
                }
                Dispose(LoadList);
            }
        }

        private void ProcessAutoRun()
        {
            TAutoRunInfo AutoRunInfo;
            for (int I = 0; I < m_AutoRunList.Count; I ++ )
            {
                AutoRunInfo = ((TAutoRunInfo)(m_AutoRunList[I]));
                if (AutoRunInfo != null)
                {
                    AutoRun(AutoRunInfo);
                }
            }
        }

        public void ReloadScript()
        {
            ClearScript();
            LoadScript();
        }

        public override void Run()
        {
            ProcessAutoRun();
        }

        public  override void SendSocket(TDefaultMessage DefMsg, string sMsg)
        {
        }
    }
}

