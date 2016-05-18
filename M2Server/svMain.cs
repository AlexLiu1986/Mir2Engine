using GameFramework;
using GameFramework.Thrend;
using NetFramework;
using NetFramework.AsyncSocketClient;
using NetFramework.AsyncSocketServer;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace M2Server
{
    //\s*\n\s*\n ɾ�����д���
    public partial class TFrmMain : Form, IDisposable
    {
        #region ������

        private TFrmMain FrmMain;
        protected static Logger s_log = LogManager.GetCurrentClassLogger();
        public static IServerSocket g_GateSocket = null;
        public static IServerSocket GateSocket = null;
        public static IClientScoket DBSocket = null;
        public static uint l_dwRunTimeTick = 0;
        public static bool boSaveData = false;
        private bool boServiceStarted = false;
        private TGameConfig Config;
        private bool _IsRun = false;

        private TFrmSrvMsg FrmSrvMsg = new TFrmSrvMsg();
        private TFrmMsgClient FrmMsgClient = new TFrmMsgClient();
        private LocalDB FrmDB;

        public delegate void RefGataListViewDelegate();
        #endregion ������

        public TFrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���ɳ������
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="nLen"></param>
        public void SetWindowTitle(string Msg)
        {
            M2Share.sCaptionExtText = Msg;
            this.Invoke((MethodInvoker)delegate() { this.Text = M2Share.sCaptionExtText; });
        }

        /// <summary>
        /// �������ֹ���
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static bool LoadAbuseInformation(string FileName)
        {
            bool result = false;
            int I;
            string sText;
            if (File.Exists(FileName))
            {
                M2Share.AbuseTextList.Clear();
                M2Share.AbuseTextList.LoadFromFile(FileName);
                I = 0;
                while (true)
                {
                    if (M2Share.AbuseTextList.Count <= I)
                    {
                        break;
                    }
                    sText = M2Share.AbuseTextList[I].Trim();
                    if (sText == "")
                    {
                        M2Share.AbuseTextList.RemoveAt(I);
                        continue;// ����
                    }
                    I++;
                }
                result = true;
            }
            return result;
        }

        // ��ȡ������IP���˿�
        public static void LoadServerTable()
        {
            int I;
            int II;
            TStringList LoadList;
            TStringList GateList;
            string sLineText = string.Empty;
            string sGateMsg = string.Empty;
            string sIPaddr = string.Empty;
            string sPort = string.Empty;
            M2Share.ServerTableList.Clear();
            if (File.Exists(".\\!servertable.txt"))
            {
                LoadList = new TStringList();
                LoadList.LoadFromFile(".\\!servertable.txt");
                for (I = 0; I < LoadList.Count; I++)
                {
                    sLineText = LoadList[I].Trim();
                    if ((sLineText != "") && (sLineText[0] != ';'))
                    {
                        sGateMsg = HUtil32.GetValidStr3(sLineText, ref sGateMsg, new string[] { " ", "\09" }).Trim();
                        if (sGateMsg != "")
                        {
                            GateList = new TStringList();
                            for (II = 0; II <= 30; II++)
                            {
                                if (sGateMsg == "")
                                {
                                    break;
                                }
                                sGateMsg = HUtil32.GetValidStr3(sGateMsg, ref sIPaddr, new string[] { " ", "\09" }).Trim();
                                sGateMsg = HUtil32.GetValidStr3(sGateMsg, ref sPort, new string[] { " ", "\09" }).Trim();
                                if ((sIPaddr != "") && (sPort != ""))
                                {
                                    GateList.InsertText(HUtil32.Str_ToInt(sPort, 0), sIPaddr);
                                }
                            }
                            M2Share.ServerTableList.Add(GateList);
                            GateList = null;
                        }
                    }
                }
                LoadList.Dispose();
            }
            else
            {
                MessageBox.Show("�ļ�!servertable.txtδ�ҵ�������");
            }
        }

        /// <summary>
        /// д����־
        /// </summary>
        /// <param name="MsgList"></param>
        public static void WriteConLog(TStringList MsgList)
        {
            byte nCode = 0;
            try
            {
                if (MsgList.Count <= 0)
                {
                    return;
                }
                try
                {
                    if (MsgList.Count > 0)
                    {
                        nCode = 1;
                        for (int I = 0; I < MsgList.Count; I++)
                        {
                            s_log.Info(MsgList[I]);
                        }
                    }
                }
                finally
                {
                    nCode = 2;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} д��ConLogĿ¼��־���� Code:" + nCode);
            }
        }

        public static void ProcessGameRun()
        {
            HUtil32.EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
            try
            {
                try
                {
                    M2Share.UserEngine.PrcocessData();
                    M2Share.g_EventManager.Run();
                    M2Share.RobotManage.Run();
                    if (HUtil32.GetTickCount() - l_dwRunTimeTick > 10000)
                    {
                        l_dwRunTimeTick = HUtil32.GetTickCount();
                        M2Share.g_GuildManager.Run();
                        M2Share.g_CastleManager.Run();
                        lock (M2Share.g_DenySayMsgList)
                        {
                            try
                            {
                                for (int I = M2Share.g_DenySayMsgList.Count - 1; I >= 0; I--)
                                {
                                    if (M2Share.g_DenySayMsgList.Count <= 0)
                                    {
                                        break;
                                    }

                                    //if (HUtil32.GetTickCount() > ((uint)M2Share.g_DenySayMsgList[I]))
                                    //{
                                    //    M2Share.g_DenySayMsgList.RemoveAt(I);
                                    //}
                                }
                            }
                            finally
                            {
                            }
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{�쳣} ProcessGameRun");
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
            }
        }

        // ����!Setup.txt����
        private void SaveItemNumber()
        {
            try
            {
                M2Share.Config.WriteInteger("Setup", "ItemNumber", M2Share.g_Config.nItemNumber);
                M2Share.Config.WriteInteger("Setup", "ItemNumberEx", M2Share.g_Config.nItemNumberEx);
                for (int I = M2Share.g_Config.GlobalVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalVal.GetUpperBound(0); I++) // ����ϵͳ����
                {
                    M2Share.Config.WriteInteger("Setup", "GlobalVal" + I, M2Share.g_Config.GlobalVal[I]);
                }
                for (int I = M2Share.g_Config.GlobalAVal.GetLowerBound(0); I <= M2Share.g_Config.GlobalAVal.GetUpperBound(0); I++)  // ����ϵͳ����
                {
                    M2Share.Config.WriteString("Setup", "GlobalStrVal" + I, M2Share.g_Config.GlobalAVal[I]);
                }
                M2Share.Config.WriteInteger("Setup", "WinLotteryCount", M2Share.g_Config.nWinLotteryCount);
                M2Share.Config.WriteInteger("Setup", "NoWinLotteryCount", M2Share.g_Config.nNoWinLotteryCount);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel1", M2Share.g_Config.nWinLotteryLevel1);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel2", M2Share.g_Config.nWinLotteryLevel2);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel3", M2Share.g_Config.nWinLotteryLevel3);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel4", M2Share.g_Config.nWinLotteryLevel4);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel5", M2Share.g_Config.nWinLotteryLevel5);
                M2Share.Config.WriteInteger("Setup", "WinLotteryLevel6", M2Share.g_Config.nWinLotteryLevel6);
            }
            catch
            {
            }
        }

        /// <summary>
        /// ˢ�½�������
        /// </summary>
        /// <param name="obj"></param>
        private void RefreshData(object obj)
        {
            uint wHour;
            uint wMinute;
            uint wSecond;
            uint tSecond;
            byte nCode = 0;
            decimal tTimeCount;
            string sSrvType;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.LogMsgCriticalSection);
                try
                {
                    nCode = 1;
                    if (M2Share.MainLogMsgList.Count > 0)
                    {
                        try
                        {
                            nCode = 2;
                            if (_IsRun)
                            {
                                nCode = 3;
                                foreach (var Msg in M2Share.MainLogMsgList)
                                {
                                    nCode = 4;
                                    OutManMessage(Msg);
                                    s_log.Info(Msg);
                                }
                                nCode = 5;
                                M2Share.MainLogMsgList.Clear();
                                nCode = 6;
                            }
                        }
                        catch
                        {
                            OutManMessage("������־��Ϣ��������");
                        }
                    }
                    nCode = 7;
                    if (M2Share.LogStringList.Count > 0)
                    {
                        for (int I = 0; I < M2Share.LogStringList.Count; I++)
                        {
                            try
                            {
                                nCode = 8;
                                //sCaption = "1" + "\09" + M2Share.g_Config.nServerNumber + "\09" + M2Share.nServerIndex + "\09" + M2Share.LogStringList[I];
                                nCode = 9;
                                //IdUDPClientLog.Send(sCaption);// ������Ϸ��־,�ı�����
                            }
                            catch
                            {
                                continue;
                            }
                        }
                        nCode = 10;
                        M2Share.LogStringList.Clear();
                    }
                    nCode = 11;
                    if (M2Share.LogonCostLogList.Count > 0)
                    {
                        nCode = 12;
                        WriteConLog(M2Share.LogonCostLogList);// д����־
                        nCode = 13;
                        M2Share.LogonCostLogList.Clear();
                    }
                }
                finally
                {
                    HUtil32.LeaveCriticalSection(M2Share.LogMsgCriticalSection);
                }
                nCode = 14;
                tSecond = (HUtil32.GetTickCount() - M2Share.g_dwStartTick) / 1000;
                wHour = tSecond / 3600;
                wMinute = tSecond / 60 % 60;
                wSecond = tSecond % 60;
                sSrvType = "[M]";
                nCode = 15;

                // HUtil32.GetTickCount()���ڻ�ȡ��windows��������������ʱ�䳤�ȣ����룩
                tTimeCount = HUtil32.GetTickCount() / (24 * 60 * 60 * 1000);
                LbRunSocketTime.Invoke((MethodInvoker)delegate()
                {
                    this.LbRunSocketTime.Text = '[' + wHour + ':' + wMinute + ':' + wSecond + sSrvType + tTimeCount + ']';
                });
                LbUserCount.Invoke((MethodInvoker)delegate()
                {
                    LbUserCount.Text = string.Format("({0}) [{1}/{2}] [{3}/{4}] [{5}/{6}]", M2Share.UserEngine.MonsterCount,
                        TRunSocket.g_nGateRecvMsgLenMin, TRunSocket.g_nGateRecvMsgLenMax, M2Share.UserEngine.OnlinePlayObject,
                        M2Share.UserEngine.PlayObjectCount, M2Share.UserEngine.LoadPlayCount, M2Share.UserEngine.m_PlayObjectFreeList.Count);
                });
                Label1.Invoke((MethodInvoker)delegate()
                {
                    Label1.Text = string.Format("Run({0}/{1}) Soc({2}/{3}) Usr({4}/{5})", M2Share.nRunTimeMin, M2Share.nRunTimeMax, M2Share.g_nSockCountMin,
                        M2Share.g_nSockCountMax, M2Share.g_nUsrTimeMin, M2Share.g_nUsrTimeMax);
                });
                Label1.Invoke((MethodInvoker)delegate()
                {
                    Label2.Text = string.Format("Hum{0}/{1} Usr{2}/{3} Mer{4}/{5} Npc{6}/{7}", M2Share.g_nHumCountMin, M2Share.g_nHumCountMax,
                        M2Share.dwUsrRotCountMin, M2Share.dwUsrRotCountMax, M2Share.UserEngine.dwProcessMerchantTimeMin,
                        M2Share.UserEngine.dwProcessMerchantTimeMax, M2Share.UserEngine.dwProcessNpcTimeMin, M2Share.UserEngine.dwProcessNpcTimeMax,
                        M2Share.g_nProcessHumanLoopTime);
                });
                Label1.Invoke((MethodInvoker)delegate()
                {
                    Label20.Text = string.Format("MonG({0}/{1}/{2}) MonP({3}/{4}/{5}) ObjRun({6}/{7})", M2Share.g_nMonGenTime, M2Share.g_nMonGenTimeMin,
                      M2Share.g_nMonGenTimeMax, M2Share.g_nMonProcTime, M2Share.g_nMonProcTimeMin, M2Share.g_nMonProcTimeMax, M2Share.g_nBaseObjTimeMin,
                      M2Share.g_nBaseObjTimeMax);
                });
                Label1.Invoke((MethodInvoker)delegate() { Label5.Text = M2Share.g_sMonGenInfo1 + '-' + M2Share.g_sMonGenInfo2 + ' '; });
                if (M2Share.dwStartTimeTick == 0)
                {
                    M2Share.dwStartTimeTick = HUtil32.GetTickCount();
                }
                M2Share.dwStartTime = (HUtil32.GetTickCount() - M2Share.dwStartTimeTick) / 1000;
                nCode = 20;
                if (_IsRun)//By John ʹ���첽ˢ��UI����ˢ����������״̬��˸����
                {
                   GateListView.BeginInvoke(new RefGataListViewDelegate(BeginGateListView));
                }
                nCode = 21;
                M2Share.nRunTimeMax++;
                nCode = 22;
                if (M2Share.g_nSockCountMax > 0) { M2Share.g_nSockCountMax -= 1; }
                if (M2Share.g_nUsrTimeMax > 0) { M2Share.g_nUsrTimeMax -= 1; }
                if (M2Share.g_nHumCountMax > 0) { M2Share.g_nHumCountMax -= 1; }
                if (M2Share.g_nMonTimeMax > 0) { M2Share.g_nMonTimeMax -= 1; }
                if (M2Share.dwUsrRotCountMax > 0) { M2Share.dwUsrRotCountMax -= 1; }
                if (M2Share.g_nMonGenTimeMin > 1) { M2Share.g_nMonGenTimeMin -= 2; }
                if (M2Share.g_nMonProcTimeMin > 1) { M2Share.g_nMonProcTimeMin -= 2; }
                if (M2Share.g_nBaseObjTimeMax > 0) { M2Share.g_nBaseObjTimeMax -= 1; }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} Timer1Timer Code:" + nCode);
            }
        }

        /// <summary>
        /// ˢ����������״̬
        /// </summary>
        protected void BeginGateListView()
        {
            TGateInfo GateInfo;
            ListViewItem ListItem = null;
            GateListView.BeginUpdate();
            GateListView.Items.Clear();
            for (int i = TRunSocket.g_GateArr.GetLowerBound(0); i <= TRunSocket.g_GateArr.GetUpperBound(0); i++)
            {
                GateInfo = TRunSocket.g_GateArr[i];
                if (GateInfo.boUsed && (GateInfo.Socket != null))
                {
                    ListItem = new ListViewItem();
                    ListItem.Text = i.ToString();
                    ListItem.SubItems.Add(GateInfo.sAddr + ":" + GateInfo.nPort);
                    ListItem.SubItems.Add(GateInfo.nSendMsgCount.ToString());
                    ListItem.SubItems.Add(GateInfo.nSendedMsgCount.ToString());
                    ListItem.SubItems.Add(GateInfo.nSendRemainCount.ToString());
                    if (GateInfo.nSendMsgBytes < 1024)
                    {
                        ListItem.SubItems.Add(GateInfo.nSendMsgBytes + "b");
                    }
                    else
                    {
                        ListItem.SubItems.Add(GateInfo.nSendMsgBytes / 1024 + "kb");
                    }
                    if (GateInfo.UserList != null)
                    {
                        ListItem.SubItems.Add(GateInfo.nUserCount + "/" + GateInfo.UserList.Count);
                    }
                    else
                    {
                        ListItem.SubItems.Add(GateInfo.nUserCount + "/" + 0);
                    }
                    GateListView.Items.Add(ListItem);
                }
                else {
                    if (GateListView.Items.Count > 0)
                    {
                        GateListView.Items.RemoveByKey(i.ToString());
                    }
                }
            }
            GateListView.EndUpdate();
            ListItem = null;
            GateInfo = null;
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="Sender"></param>
        private void InitEngine(object Sender)
        {
            int nCode;
            FrmDB = LocalDB.GetInstance();
            StartService();
            try
            {
                if (!LoadClientFile())// ���û�м��ؿͻ�����Ϣ
                {
                    this.Close();
                    return;
                }
                if (M2Share.g_sADODBString != null) // �������ݿ���������
                {
                    M2Share.g_sADODBString.ConnectionString = M2Share.g_Config.sConnectionString;
                }
                M2Share.LoadGameLogItemNameList();// ������Ϸ��־��Ʒ��
                M2Share.LoadDenyIPAddrList();// ����IP�����б�
                M2Share.LoadDenyAccountList();// ���ص�¼�ʺŹ����б�
                M2Share.LoadDenyChrNameList();// ���ؽ�ֹ��¼�����б�
                M2Share.LoadNoClearMonList();// ���ز���������б�
                nCode = FrmDB.LoadItemsDB();
                if (nCode < 0)
                {
                    OutManMessage("��Ʒ���ݿ����ʧ�ܣ�����" + "����: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage(string.Format("������Ʒ���ݿ�ɹ�[{0}]...", M2Share.UserEngine.StdItemList.Count));
                }
                nCode = FrmDB.LoadMinMap();
                if (nCode < 0)
                {
                    OutManMessage("С��ͼ���ݼ���ʧ�ܣ�����" + "����: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("����С��ͼ���ݳɹ�...");
                }
                nCode = FrmDB.LoadMapInfo();
                if (nCode < 0)
                {
                    OutManMessage("��ͼ���ݼ���ʧ�ܣ�����" + "����: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage(string.Format("���ص�ͼ���ݳɹ�[{0}]...", M2Share.g_MapManager.m_MapList.Count));
                }
                nCode = FrmDB.LoadMonsterDB();
                if (nCode < 0)
                {
                    OutManMessage("���ع������ݿ�ʧ�ܣ�����" + "����: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage(string.Format("���ع������ݿ�ɹ�[{0}]...", M2Share.UserEngine.MonsterList.Count));
                }
                nCode = FrmDB.LoadMagicDB();
                if (nCode < 0)
                {
                    OutManMessage("���ؼ������ݿ�ʧ�ܣ�����" + "����: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage(string.Format("���ؼ������ݿ�ɹ�[{0}]...", M2Share.UserEngine.m_MagicList.Count));
                }
                nCode = FrmDB.LoadMonGen();
                if (nCode < 0)
                {
                    OutManMessage("���ع���ˢ��������Ϣʧ�ܣ�����" + "����: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage(string.Format("���ع���ˢ��������Ϣ�ɹ�[{0}]...", M2Share.UserEngine.m_MonGenList.Count));
                }
                if (M2Share.LoadMonSayMsg())
                {
                    OutManMessage(string.Format("���ع���˵��������Ϣ�ɹ�[{0}]...", M2Share.g_MonSayMsgList.Count));
                }
                M2Share.LoadDisableTakeOffList();// ���ؽ�ֹȡ����Ʒ�б�
                M2Share.LoadMonDropLimitList();// ���ع��ﱬ��Ʒ�����б�
                M2Share.LoadDisableMakeItem();// ���ؽ�ֹ������Ʒ�б�
                M2Share.LoadEnableMakeItem();// ���ؿ�������Ʒ�б�
                M2Share.LoadDisableMoveMap();// ���ؽ�ֹ�ƶ���ͼ�б�
                M2Share.ItemUnit.LoadCustomItemName();
                M2Share.LoadDisableSendMsgList();// ���ؽ�ֹ����Ϣ�����б�
                M2Share.LoadItemBindIPaddr();// ��������IP�б�
                M2Share.LoadItemBindAccount();
                M2Share.LoadItemBindCharName();
                M2Share.LoadItemBindDieNoDropName();// ��ȡ����װ�����������б�
                M2Share.LoadUnMasterList();// ���س�ʦ��¼��
                M2Share.LoadUnForceMasterList();// ����ǿ�г�ʦ��¼��
                M2Share.LoadItemDblClickList();// ���������ȡ��Ʒ
                M2Share.LoadAllowPickUpItemList();// �������޲ֿ�����
                string ItemName;
                nCode = FrmDB.LoadUnbindList(out ItemName);
                if (nCode < 0)
                {
                    OutManMessage(string.Format("������װ��Ʒ��Ϣʧ�ܣ����� [{0}]", ItemName));
                    return;
                }
                else
                {
                    OutManMessage("������װ��Ʒ��Ϣ�ɹ�...");
                }
                M2Share.LoadBindItemTypeFromUnbindList();// ������װ��Ʒ����
                nCode = FrmDB.LoadMapQuest();
                if (nCode > 0)
                {
                    OutManMessage("���������ͼ��Ϣ�ɹ�...");
                }
                else
                {
                    OutManMessage("���������ͼ��Ϣʧ�ܣ�����");
                    return;
                }
                nCode = FrmDB.LoadMapEvent();
                if (nCode < 0)
                {
                    OutManMessage("���ص�ͼ�����¼���Ϣʧ�ܣ�����");
                    return;
                }
                else
                {
                    OutManMessage("���ص�ͼ�����¼���Ϣ�ɹ�...");
                }
                nCode = FrmDB.LoadQuestDiary();
                if (nCode < 0)
                {
                    OutManMessage("��������˵����Ϣʧ�ܣ�����");
                    return;
                }
                else
                {
                    OutManMessage("��������˵����Ϣ�ɹ�...");
                }
                if (LoadAbuseInformation(".\\!abuse.txt"))
                {
                    OutManMessage("�������ֹ�����Ϣ�ɹ�...");
                }
                if (M2Share.LoadLineNotice(M2Share.g_Config.sNoticeDir + "LineNotice.txt"))
                {
                    OutManMessage("���ع�����ʾ��Ϣ�ɹ�...");
                }
                else
                {
                    OutManMessage("���ع�����ʾ��Ϣʧ�ܣ�����");
                }
                M2Share.LoadUserCmdList();// �����Զ�������
                M2Share.LoadCheckItemList();// ���ؽ�ֹ��Ʒ����
                M2Share.LoadMsgFilterList();// ������Ϣ����
                M2Share.LoadShopItemList();// ������������
                FrmDB.LoadAdminList();// ���ع���Ա�б�
                M2Share.g_GuildManager.LoadGuildInfo();// �����л��б�
                FrmDB.LoadBoxsList(); //���ر�������
                OutManMessage("���ر������óɹ�[" + M2Share.BoxsList.Count + "]...");
                FrmDB.LoadSuitItemList();// ��ȡ��װװ������
                OutManMessage("������װ���óɹ�[" + M2Share.SuitItemList.Count + "]...");
                FrmDB.LoadSellOffItemList();// ��ȡԪ�������б�
                OutManMessage("����Ԫ���������ݳɹ�[" + M2Share.sSellOffItemList.Count + "]...");
                FrmDB.LoadRefineItem();
                OutManMessage("���ش���������Ϣ�ɹ�[" + M2Share.g_RefineItemList.Count + "]...");
                M2Share.g_CastleManager.LoadCastleList();
                OutManMessage("���سǱ��б�ɹ�...");
                M2Share.NoticeManager.LoadingNotice();//��ȡ����
                FrmDB.LoadMonFireDragonGuard();// �����ػ��޲�д���б�
                M2Share.g_CastleManager.Initialize();
                OutManMessage("�Ǳ��ǳ�ʼ���...");
                if ((M2Share.nServerIndex == 0))
                {
                    FrmSrvMsg.StartMsgServer();
                }
                else
                {
                    FrmMsgClient.ConnectMsgServer();
                }
                StartEngine();
                M2Share.boStartReady = true;
                M2Share.g_dwRunTick = HUtil32.GetTickCount();
                M2Share.n4EBD1C = 0;
                M2Share.g_dwUsrRotCountTick = HUtil32.GetTickCount();
                M2Share.ThrendManage = new ThrendManage(RunEngine, new CycExecution(DateTime.Now, new TimeSpan(0, 0, 0, 0, 100)));
                M2Share.ThrendManage.Start();
                g_GateSocket = GateSocket;
                GateSocket.Init();
                GateSocket.Start(M2Share.g_Config.sGateAddr, M2Share.g_Config.nGatePort);
                M2Share.dwSaveDataTick = HUtil32.GetTickCount();
            }
            catch (Exception E)
            {
                _IsRun = true;
                OutManMessage("�����������쳣������" + E.Message);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void StartEngine()
        {
            int nCode;
            try
            {
                M2Share.FrmIDSoc.Initialize();
                OutManMessage("��¼���������ӳ�ʼ�����...");
                M2Share.g_MapManager.LoadMapDoor();
                OutManMessage("���ص�ͼ�����ɹ�...");
                OutManMessage("���ڳ�ʼ����������...");
                MakeStoneMines(); // �������
                OutManMessage("�������ݳ�ʼ�ɹ�...");
                nCode = FrmDB.LoadMerchant();
                if (nCode < 0)
                {
                    OutManMessage("����NPC�б����ʧ�� ������" + "������: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("���ؽ���NPC�б�ɹ�...");
                }
                if (!M2Share.g_Config.boVentureServer)
                {
                    nCode = FrmDB.LoadGuardList();
                    if (nCode < 0)
                    {
                        OutManMessage("�����б����ʧ�� ������" + "������: " + nCode);
                    }
                    else
                    {
                        OutManMessage("���������б�ɹ�...");
                    }
                }
                nCode = FrmDB.LoadNpcs();
                if (nCode < 0)
                {
                    OutManMessage("����NPC�б����ʧ�� ������" + "������: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("���ع���NPC�б�ɹ�...");
                }
                nCode = FrmDB.LoadMakeItem();
                if (nCode < 0)
                {
                    OutManMessage("������Ʒ��Ϣ����ʧ�� ������" + "������: " + nCode);
                    return;
                }
                else
                {
                    OutManMessage("����������Ʒ��Ϣ�ɹ�...");
                }
                nCode = FrmDB.LoadStartPoint();
                if (nCode < 0)
                {
                    OutManMessage("���ػسǵ�����ʱ���ִ��� ������(������: " + nCode + ")");
                    return;
                }
                else
                {
                    OutManMessage("���ػسǵ����óɹ�...");
                }
                OutManMessage("�����������������ɹ�...");
                FrmMain = this;
                M2Share.UserEngine.Initialize(ref FrmMain);
                OutManMessage("��Ϸ���������ʼ���ɹ�...");
                FrmMain = null;
                M2Share.g_MapManager.MakeSafePkZone();  // ���찲ȫ����Ȧ
                SetWindowTitle(M2Share.g_Config.sServerName);//���ó������
                boSaveData = true;// ��������;
                SaveVariableTimer.Enabled = true;
                _IsRun = true;
                M2Share.ThrendManage = new ThrendManage(ConnectTimerTimer, new CycExecution(DateTime.Now, new TimeSpan(0, 0, 0, 0, 3000)));
                M2Share.ThrendManage.Start();
            }
            catch
            {
                _IsRun = true;
                M2Share.MainOutMessage("��������ʱ�����쳣���� ������");
            }
        }

        /// <summary>
        /// ����ʯ��
        /// </summary>
        private void MakeStoneMines()
        {
            var MapMineList = M2Share.g_MapManager.m_MapList.FindAll(p => { return p.m_boMINE; });//���ؿ����ڿ�ĵ�ͼ�б�

            foreach (var Envir in MapMineList)
            {
                if (Envir.m_boMINE)
                {
                    for (int nW = 0; nW < Envir.m_nWidth; nW++)
                    {
                        for (int nH = 0; nH < Envir.m_nHeight; nH++)
                        {
                            new TStoneMineEvent(Envir, nW, nH, M2Share.ET_STONEMINE);
                        }
                    }
                }
            }

            #region ��ǰ����

            //TEnvirnoment Envir = null;
            //foreach (var item in M2Share.g_MapManager.m_MapList)
            //{
            //    Envir = item;
            //    if (Envir.m_boMINE)
            //    {
            //        for (int nW = 0; nW < Envir.m_nWidth; nW++)
            //        {
            //            for (int nH = 0; nH < Envir.m_nHeight; nH++)
            //            {
            //                new TStoneMineEvent(Envir, nW, nH, M2Share.ET_STONEMINE);
            //            }
            //        }
            //    }
            //}

            #endregion ��ǰ����
        }

        /// <summary>
        /// ��ȡ�ͻ��˰汾��Ϣ
        /// </summary>
        /// <returns></returns>
        private bool LoadClientFile()
        {
            bool result;
            if (!(M2Share.g_Config.sClientFile1 == ""))
            {
                //M2Share.g_Config.nClientFile1_CRC = EDcodeUnit.Units.EDcodeUnit.CalcFileCRC(M2Share.g_Config.sClientFile1);
            }
            if ((M2Share.g_Config.nClientFile1_CRC != 0))
            {
                OutManMessage("���ؿͻ��˰汾��Ϣ�ɹ�...");
                result = true;
            }
            else
            {
                OutManMessage("���ؿͻ��˰汾��Ϣʧ�ܣ�����");
                result = true;
            }
            return result;
        }

        public void FormCreate(object sender, EventArgs e)
        {
            GateSocket = new IServerSocket(20, Int16.MaxValue);
            GateSocket.OnClientConnect += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientConnect);
            GateSocket.OnClientDisconnect += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientDisconnect);

            //GateSocket.OnClientError += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientError);
            GateSocket.OnClientRead += new EventHandler<NetFramework.AsyncUserToken>(GateSocketClientRead);

            DBSocket = new IClientScoket();
            DBSocket.OnConnected += new DSCClientOnConnectedHandler(DBSocketConnect);
            DBSocket.ReceivedDatagram += new DSCClientOnDataInHandler(DBSocketRead);

            M2Share.ThrendManage = new ThrendManage(InitEngine, new ImmediateExecution());
            M2Share.ThrendManage.Start();
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        /// <summary>
        /// ���ݿ����ӳɹ�����ʾԶ��IP���˿�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBSocketConnect(object sender, DSCClientConnectedEventArgs e)
        {
            M2Share.MainOutMessage("���ݿ������[" + DBSocket.Address + ':' + DBSocket.Port + "]���ӳɹ�...");
            M2Share.g_nSaveRcdErrorCount = 0;
        }

        /// <summary>
        /// ���ݿ����Ӵ���
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Socket"></param>
        /// <param name="ErrorEvent"></param>
        /// <param name="ErrorCode"></param>
        private void DBSocketError(object sender, DSCClientConnectedEventArgs e)
        {
            OutManMessage("[Error]:DBSocketError");
        }

        /// <summary>
        /// ��ȡ���ݿ�����,��DBserver.exe �ش�������
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Socket"></param>
        private unsafe void DBSocketRead(object sender, DSCClientDataInEventArgs e)
        {
            string tStr = string.Empty;
            HUtil32.EnterCriticalSection(M2Share.UserDBSection);
            try
            {
                fixed (byte* pb = e.Data)
                {
                    tStr = HUtil32.SBytePtrToString((sbyte*)pb, 0, e.Data.Length);
                }
                M2Share.g_Config.sDBSocketRecvText = M2Share.g_Config.sDBSocketRecvText + tStr;// ReceiveText��ʾ�յ����ı�����
                if (!M2Share.g_Config.boDBSocketWorking)
                {
                    M2Share.g_Config.sDBSocketRecvText = "";
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.UserDBSection);
            }
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ThreadExceptionEventArgs error = e;
            if (error != null)
            {
                MessageBox.Show(string.Format("Application UnhandledException:{0};\n��ջ��Ϣ:{1}", error.Exception.Message, error.Exception.StackTrace));
            }
            else
            {
                MessageBox.Show(string.Format("Application UnhandledError:{0}", e));
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = e.ExceptionObject as Exception;
            if (error != null)
            {
                MessageBox.Show(string.Format("Application UnhandledException:{0};\n��ջ��Ϣ:{1}", error.Message, error.StackTrace));
            }
            else
            {
                MessageBox.Show(string.Format("Application UnhandledError:{0}", e));
            }
        }

        /// <summary>
        /// ���ش���ر���Ϣ
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            const string sCloseServerYesNo = "�Ƿ�ȷ�Ϲر���Ϸ��������";
            const string sCloseServerTitle = "ȷ����Ϣ";
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                if (!boServiceStarted) // ���û�з���ʼ
                {
                    System.Environment.Exit(System.Environment.ExitCode);
                    return;
                }
                if (M2Share.g_boExitServer)
                {
                    M2Share.boStartReady = false;
                    return;
                }
                if (MessageBox.Show(sCloseServerYesNo, sCloseServerTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    M2Share.g_boExitServer = true;
                    CloseGateSocket();
                    M2Share.g_Config.boKickAllUser = true;
                    M2Share.ThrendManage = new ThrendManage(CloseTimerTimer, new ImmediateExecution());
                    M2Share.ThrendManage.Start();
                }
                else
                {
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void CloseTimerTimer(object sender)
        {
            // FrmDB.SaveSellOffItemList;//����Ԫ�������б�
            SetWindowTitle(string.Format("{0} [���ڹرշ�����({1} {2}/{3} {4})...]", M2Share.g_Config.sServerName, "����",
                M2Share.UserEngine.OnlinePlayObject, "����", M2Share.FrontEngine.SaveListCount()));
            if (M2Share.UserEngine.OnlinePlayObject == 0)
            {
                if (M2Share.FrontEngine.IsIdle())
                {
                    SetWindowTitle(string.Format("{0} [�������ѹر�]", M2Share.g_Config.sServerName));
                    boSaveData = false;
                    M2Share.dwSaveDataTick = HUtil32.GetTickCount() - 600000; // 1000 * 60 * 10
                    SaveItemsData();
                    StopService();
                    M2Share.ThrendManage.Stop();
                    this.Close();
                    //Process.GetCurrentProcess().CloseMainWindow();
                }
            }
        }

        // ������Ʒ����
        private void SaveItemsData()
        {
            if (HUtil32.GetTickCount() - M2Share.dwSaveDataTick > 480000) // 1000 * 60 * 8
            {
                M2Share.dwSaveDataTick = HUtil32.GetTickCount();
                if (M2Share.sSellOffItemList != null)
                {
                    FrmDB.SaveSellOffItemList();
                }

                // ����Ԫ����������
                //if (GameMsgDef.g_Storage != null)
                //{
                //    GameMsgDef.g_Storage.SaveToFile(GameMsgDef.g_StorageFileName);
                //}
                SaveItemNumber();
            }
        }

        private void SaveVariableTimerTimer(Object Sender)
        {
            try
            {
                SaveItemNumber();
                if (boSaveData)
                {
                    SaveItemsData();
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} SaveVariableTimerTimer");
            }
        }

        /// <summary>
        /// �ͻ������Ӵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientError(object sender, NetFramework.AsyncUserToken e)
        {
            //M2Share.RunSocket.CloseErrGate(e.Client.ClientSocket);
        }

        /// <summary>
        /// �Ͽ��ͻ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientDisconnect(object sender, NetFramework.AsyncUserToken e)
        {
            M2Share.RunSocket.CloseGate(e);
        }

        /// <summary>
        /// �ͻ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientConnect(object sender, NetFramework.AsyncUserToken e)
        {
            M2Share.RunSocket.AddGate(e);
        }

        /// <summary>
        /// �ͻ��˷�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GateSocketClientRead(object sender, NetFramework.AsyncUserToken e)
        {
            M2Share.RunSocket.SocketRead(e);
        }

        private void RunEngine(object obj)
        {
            try
            {
                if (M2Share.boStartReady)
                {
                    M2Share.RunSocket.Run();
                    M2Share.FrmIDSoc.Run();
                    M2Share.UserEngine.Run();// ��������
                    ProcessGameRun();
                    FrmMsgClient.Run();
                }
                M2Share.n4EBD1C++;
                if ((HUtil32.GetTickCount() - M2Share.g_dwRunTick) > 250)
                {
                    M2Share.g_dwRunTick = HUtil32.GetTickCount();
                    M2Share.nRunTimeMin = M2Share.n4EBD1C;
                    if (M2Share.nRunTimeMax > M2Share.nRunTimeMin) { M2Share.nRunTimeMax = M2Share.nRunTimeMin; }
                    M2Share.n4EBD1C = 0;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} RunTimerTimer");
            }
        }

        /// <summary>
        /// ������룬���DBServer��LoginSrv�����Ƿ�����
        /// </summary>
        /// <param name="Sender"></param>
        private void ConnectTimerTimer(object Sender)
        {
            try
            {
                if (_IsRun)
                {
                    if (!DBSocket.IsConnected)//���DBServer�����Ƿ�����
                    {
                        DBSocket.Connect(DBSocket.Address, DBSocket.Port);
                    }
                    if (!M2Share.g_Config.boIDSocketConnected) //���LoginSrv�����Ƿ�����
                    {
                        M2Share.FrmIDSoc.Connected();
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} ConnectTimerTimer");
            }
        }

        private void ReloadConfig(object Sender)
        {
            try
            {
                M2Share.LoadConfig();

                //IdSrvClient.Units.IdSrvClient.FrmIDSoc.Timer1Timer(Sender);
                //if (!(M2Share.nServerIndex == 0))
                //{
                //    if (!InterMsgClient.Units.InterMsgClient.FrmMsgClient.MsgClient.Active)
                //    {
                //        InterMsgClient.Units.InterMsgClient.FrmMsgClient.MsgClient.Active = true;
                //    }
                //}
                //IdUDPClientLog.Host = M2Share.g_Config.sLogServerAddr;
                //IdUDPClientLog.Port = M2Share.g_Config.nLogServerPort;
                LoadServerTable();
                LoadClientFile();
            }
            finally
            {
            }
        }

        public void MemoLogChange(object sender, EventArgs e)
        {
            if (MemoLog.TextLength > 500)
            {
                MemoLog.Clear();
            }
        }

        public void MemoLogDblClick(object sender, EventArgs e)
        {
            ClearMemoLog();
        }

        public void MENU_CONTROL_EXITClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MENU_CONTROL_RELOAD_CONFClick(object sender, EventArgs e)
        {
            ReloadConfig(sender);
        }

        public void MENU_CONTROL_CLEARLOGMSGClick(object sender, EventArgs e)
        {
            ClearMemoLog();
        }

        public void SpeedButton1Click(Object Sender)
        {
            ReloadConfig(Sender);
        }

        public void MENU_CONTROL_RELOAD_ITEMDBClick(object sender, EventArgs e)
        {
            FrmDB.LoadItemsDB();
            M2Share.MainOutMessage("���¼�����Ʒ���ݿ����...");
        }

        public void MENU_CONTROL_RELOAD_MAGICDBClick(object sender, EventArgs e)
        {
            FrmDB.LoadMagicDB();
            M2Share.MainOutMessage("���¼��ؼ������ݿ����...");
        }

        public void MENU_CONTROL_RELOAD_MONSTERDBClick(object sender, EventArgs e)
        {
            FrmDB.LoadMonsterDB();
            M2Share.MainOutMessage("���¼��ع������ݿ����...");
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void StartService()
        {
            DateTime TimeNow;
            int Year;
            int Month;
            int Day;
            int Hour;
            int Min;
            int Sec;
            int MSec;
            Config = M2Share.g_Config;// ��ʼ������
            M2Share.nRunTimeMax = 99999;
            M2Share.g_nSockCountMax = 0;
            M2Share.g_nUsrTimeMax = 0;
            M2Share.g_nHumCountMax = 0;
            M2Share.g_nMonTimeMax = 0;
            M2Share.g_nMonGenTimeMax = 0;
            M2Share.g_nMonProcTime = 0;
            M2Share.g_nMonProcTimeMin = 0;
            M2Share.g_nMonProcTimeMax = 0;
            M2Share.dwUsrRotCountMin = 0;
            M2Share.dwUsrRotCountMax = 0;
            M2Share.g_nProcessHumanLoopTime = 0;
            M2Share.g_dwHumLimit = 30;
            M2Share.g_dwMonLimit = 30;
            M2Share.g_dwZenLimit = 5;
            M2Share.g_dwNpcLimit = 5;
            M2Share.g_dwSocLimit = 10;
            M2Share.nDecLimit = 20;
            Config.sDBSocketRecvText = "";
            Config.boDBSocketWorking = false;
            Config.nLoadDBErrorCount = 0;
            Config.nLoadDBCount = 0;
            Config.nSaveDBCount = 0;
            Config.nDBQueryID = 0;
            Config.nItemNumber = 0;
            Config.nItemNumberEx = Int32.MaxValue / 2;
            M2Share.boStartReady = false;
            M2Share.g_boExitServer = false;
            M2Share.boFilterWord = true;
            Config.nWinLotteryCount = 0;
            Config.nNoWinLotteryCount = 0;
            Config.nWinLotteryLevel1 = 0;
            Config.nWinLotteryLevel2 = 0;
            Config.nWinLotteryLevel3 = 0;
            Config.nWinLotteryLevel4 = 0;
            Config.nWinLotteryLevel5 = 0;
            Config.nWinLotteryLevel6 = 0;
            M2Share.Init();
            M2Share.LoadConfig();
            M2Share.Memo = MemoLog;
            M2Share.nServerIndex = 0;
            M2Share.RunSocket = new TRunSocket();
            M2Share.MainLogMsgList = new List<string>();
            M2Share.LogStringList = new TStringList();
            M2Share.LogonCostLogList = new TStringList();
            M2Share.g_MapManager = new TMapManager();
            M2Share.ItemUnit = new TItemUnit();
            M2Share.MagicManager = new TMagicManager();
            M2Share.NoticeManager = new TNoticeManager();
            M2Share.g_GuildManager = new TGuildManager();
            M2Share.g_EventManager = new TEventManager();
            M2Share.g_CastleManager = new TCastleManager();
            M2Share.FrontEngine = new TFrontEngine(true);
            M2Share.UserEngine = new TUserEngine();
            M2Share.CommandList = new List<TGameCmd>();//��Ϸ�����б�
            M2Share.FrmIDSoc = new TFrmIDSoc();
            M2Share.FrmMsgClient = new TFrmMsgClient();
            M2Share.FrmSrvMsg = new TFrmSrvMsg();
            M2Share.RobotManage = new TRobotManage();
            M2Share.g_MakeItemList = new TStringList();
            M2Share.g_RefineItemList = new List<TRefineItemInfo>();// ���������б�
            M2Share.g_StartPointList = new List<TStartPoint>();
            M2Share.ServerTableList = new List<TStringList>();
            M2Share.g_DenySayMsgList = new IList<string, uint>();
            M2Share.MiniMapList = new List<TMinMapInfo>();
            M2Share.g_UnbindList = new List<IntPtr>();//�����Ʒ�б�
            M2Share.LineNoticeList = new TStringList();
            M2Share.g_UserCmdList = new TStringList();// �Զ��������б�
            M2Share.g_CheckItemList = new List<TCheckItem>();// ��ֹ��Ʒ����
            M2Share.g_MsgFilterList = new List<TFilterMsg>();// ��Ϣ���˹���
            M2Share.g_ShopItemList = new List<IntPtr>();// ������Ʒ�б�
            M2Share.QuestDiaryList = new List<TQDDinfo>();
            M2Share.BoxsList = new List<IntPtr>();//  ����
            M2Share.SuitItemList = new List<TSuitItem>();//  ��װ
            M2Share.sSellOffItemList = new List<IntPtr>();// Ԫ�������б�
            M2Share.ItemEventList = new TStringList();
            M2Share.AbuseTextList = new TStringList();
            M2Share.g_MonSayMsgList = new TStringList();
            M2Share.g_DisableMakeItemList = new TStringList();
            M2Share.g_EnableMakeItemList = new TStringList();
            M2Share.g_DisableMoveMapList = new TStringList();
            M2Share.g_ItemNameList = new TStringList();
            M2Share.g_DisableSendMsgList = new TStringList();
            M2Share.g_MonDropLimitLIst = new List<TMonDrop>();
            M2Share.g_DisableTakeOffList = new TStringList();
            M2Share.g_UnMasterList = new TStringList();
            M2Share.g_UnForceMasterList = new TStringList();
            M2Share.g_GameLogItemNameList = new TStringList();
            M2Share.g_DenyIPAddrList = new TStringList();
            M2Share.g_DenyChrNameList = new TStringList();
            M2Share.g_DenyAccountList = new TStringList();
            M2Share.g_NoClearMonList = new TStringList();
            M2Share.g_ItemBindIPaddr = new List<TItemBind>();
            M2Share.g_ItemBindAccount = new List<TItemBind>();
            M2Share.g_ItemBindCharName = new List<TItemBind>();// ��Ʒ����󶨱�(��Ӧ����Ҳ��ܴ���Ʒ
            M2Share.g_ItemBindDieNoDropName = new List<TItemBind>();// ����װ�����������б�

            // GameMsgDef.g_Storage = new TStorage();
            M2Share.g_MapEventListOfDropItem = new List<TMapEvent>();
            M2Share.g_MapEventListOfPickUpItem = new List<TMapEvent>();
            M2Share.g_MapEventListOfMine = new List<TMapEvent>();
            M2Share.g_MapEventListOfWalk = new List<TMapEvent>();
            M2Share.g_MapEventListOfRun = new List<TMapEvent>();
            M2Share.LogMsgCriticalSection = new object();
            M2Share.ProcessMsgCriticalSection = new object();
            M2Share.ProcessHumanCriticalSection = new object();
            M2Share.HumanSortCriticalSection = new object();
            M2Share.g_Config.UserIDSection = new object();
            M2Share.UserDBSection = new object();
            M2Share.g_DynamicVarList = new List<TDynamicVar>();
            TimeNow = DateTime.Now;
            Year = TimeNow.Year;
            Month = TimeNow.Month;
            Day = TimeNow.Day;
            Hour = TimeNow.Hour;
            Min = TimeNow.Minute;
            Sec = TimeNow.Second;
            MSec = TimeNow.Millisecond;
            if (!Directory.Exists(M2Share.g_Config.sLogDir))
            {
                Directory.CreateDirectory(Config.sLogDir);
            }
            M2Share.nShiftUsrDataNameNo = 1;
            OutManMessage("���ڶ�ȡ������Ϣ...");
            DBSocket.Address = M2Share.g_Config.sDBAddr;
            DBSocket.Port = M2Share.g_Config.nDBPort;
            SetWindowTitle(M2Share.g_Config.sServerName);

            //LoadServerTable();
            //IdUDPClientLog.Host = M2Share.g_Config.sLogServerAddr;
            //IdUDPClientLog.Port = M2Share.g_Config.nLogServerPort;
            M2Share.g_dwStartTick = HUtil32.GetTickCount();
            boServiceStarted = true;
            M2Share.dwSaveDataTick = HUtil32.GetTickCount() + 300000;// 1000 * 60 * 5
            M2Share.g_StorageFileName = M2Share.g_Config.sEnvirDir + "\\Market_Storage\\";
            if (!Directory.Exists(M2Share.g_StorageFileName))
            {
                Directory.CreateDirectory(M2Share.g_StorageFileName);
            }
            M2Share.g_StorageFileName = M2Share.g_StorageFileName + "UserStorage.db";
            M2Share.ThrendManage = new ThrendManage(RefreshData, new CycExecution(DateTime.Now, new TimeSpan(0, 0, 0, 0, 2000)));
            M2Share.ThrendManage.Start();
            MemStatus.Invoke((MethodInvoker)delegate() { MemStatus.Text = EngineVersion.g_BuildVer; });
        }

        /// <summary>
        /// ֹͣ����
        /// </summary>
        private void StopService()
        {
            int I;
            TGameConfig Config;
            try
            {
                Config = M2Share.g_Config;
                GateSocket.Shutdown();
                SaveItemNumber();// ����ϵͳ����
                M2Share.MainLogMsgList = null;
                M2Share.LogStringList = null;
                M2Share.LogonCostLogList = null;
                M2Share.g_EventManager = null;
                M2Share.ServerTableList = null;
                M2Share.g_DenySayMsgList = null;
                M2Share.MiniMapList = null;
                M2Share.g_UnbindList = null;
                M2Share.LineNoticeList = null;
                M2Share.g_UserCmdList = null;// �Զ��������б�
                M2Share.QuestDiaryList = null;
                M2Share.g_CheckItemList = null;// ��ֹ��Ʒ����
                M2Share.g_MsgFilterList = null;// ��Ϣ���˹���
                unsafe
                {
                    if (M2Share.g_ShopItemList.Count > 0) // ������Ʒ�б�
                    {
                        for (I = 0; I < M2Share.g_ShopItemList.Count; I++)
                        {
                            if (M2Share.g_ShopItemList[I] != null)
                            {
                              System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)M2Share.g_ShopItemList[I]);//by John �ر�ʱ�ͷ��̳���Ʒ����
                            }
                        }
                    }
                }
                M2Share.g_ShopItemList = null;
                if (M2Share.BoxsList.Count > 0)
                {
                    for (I = 0; I < M2Share.BoxsList.Count; I++)
                    {
                        if (M2Share.BoxsList[I] != null)
                        {
                            System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)M2Share.BoxsList[I]);//by John �ر�ʱ�ͷŷ��й�ָ��
                        }
                    }
                }
                M2Share.BoxsList = null;// ����
                M2Share.SuitItemList = null; //��װ �й���GC�ͷ�
                if (M2Share.sSellOffItemList.Count > 0) // Ԫ�������б�
                {
                    for (I = 0; I < M2Share.sSellOffItemList.Count; I++)
                    {
                        if (M2Share.sSellOffItemList[I] != null)
                        {
                            System.Runtime.InteropServices.Marshal.FreeHGlobal((IntPtr)M2Share.sSellOffItemList[I]);//by John �ر�ʱ�ͷŷ��й�ָ��
                        }
                    }
                }
                M2Share.sSellOffItemList = null;// Ԫ�������б�
                M2Share.ItemEventList = null;
                M2Share.AbuseTextList = null;
                M2Share.g_HighMCHuman = null;
                M2Share.g_DisableMakeItemList = null;
                M2Share.g_EnableMakeItemList = null;
                M2Share.g_DisableMoveMapList = null;
                M2Share.g_ItemNameList = null;
                M2Share.g_DisableSendMsgList = null;
                M2Share.g_MonDropLimitLIst = null;
                M2Share.g_DisableTakeOffList = null;
                M2Share.g_UnMasterList = null;
                M2Share.g_UnForceMasterList = null;
                M2Share.g_GameLogItemNameList = null;
                M2Share.g_DenyIPAddrList = null;
                M2Share.g_DenyChrNameList = null;
                M2Share.g_DenyAccountList = null;
                M2Share.g_NoClearMonList = null;
                //GameMsgDef.g_Storage.UnLoadBigStorageList();
                //GameMsgDef.g_Storage.Free;
                M2Share.g_ItemBindIPaddr = null;//�й���
                M2Share.g_ItemBindAccount = null;//�й���
                M2Share.g_ItemBindCharName = null;//�й���
                M2Share.g_ItemBindDieNoDropName = null;
                M2Share.g_MapEventListOfDropItem = null;
                M2Share.g_MapEventListOfPickUpItem = null;
                M2Share.g_MapEventListOfMine = null;
                M2Share.g_MapEventListOfWalk = null;
                M2Share.g_MapEventListOfRun = null;
                M2Share.g_DynamicVarList = null;
                M2Share.g_BindItemTypeList = null;
                M2Share.g_AllowPickUpItemList = null;
                M2Share.g_ItemDblClickList = null;
                M2Share.g_StartPointList = null;
                M2Share.g_MakeItemList = null;
                if (M2Share.g_RefineItemList.Count > 0) //���й�
                {
                    for (I = 0; I < M2Share.g_RefineItemList.Count; I++)
                    {
                        //if (((M2Share.g_RefineItemList.Values[I]) as ArrayList).Count > 0)
                        //{
                        //    for (K = 0; K < ((M2Share.g_RefineItemList.Values[I]) as ArrayList).Count; K ++ )
                        //    {
                        //        if (((TRefineItemInfo)(((M2Share.g_RefineItemList.Values[I]) as ArrayList)[K])) != null)
                        //        {
                        //            this.Dispose(((TRefineItemInfo)(((M2Share.g_RefineItemList.Values[I]) as ArrayList)[K])));
                        //        }
                        //    }
                        //}
                        // ((M2Share.g_RefineItemList.Values[I]) as ArrayList).Free;
                    }
                }
                M2Share.g_RefineItemList = null;
                boServiceStarted = false;
            }
            catch
            {
            }
        }

        public void MENU_HELP_ABOUTClick(object sender, EventArgs e)
        {
            if (!(TfrmRegister.frmRegister != null))
            {
                TfrmRegister FrmAbout = new TfrmRegister();
                try
                {
                    FrmAbout.Icon = this.Icon;
                    FrmAbout.Open();
                }
                finally
                {
                    FrmAbout.Dispose();
                }
            }
        }

        public void MENU_OPTION_SERVERCONFIGClick(object sender, EventArgs e)
        {
            if (!(TFrmServerValue.FrmServerValue != null))
            {
                TFrmServerValue FrmServerValue = new TFrmServerValue();
                try
                {
                    FrmServerValue.Top = this.Top + 20;
                    FrmServerValue.Left = this.Left;
                    FrmServerValue.AdjuestServerConfig();
                }
                finally
                {
                    FrmServerValue.Dispose();
                }
            }
        }

        public void MENU_OPTION_GENERALClick(object sender, EventArgs e)
        {
            if (!(TfrmGeneralConfig.frmGeneralConfig != null))
            {
                TfrmGeneralConfig frmGeneralConfig = new TfrmGeneralConfig();
                try
                {
                    frmGeneralConfig.Top = this.Top + 20;
                    frmGeneralConfig.Left = this.Left;
                    frmGeneralConfig.Icon = this.Icon;
                    frmGeneralConfig.Open();
                }
                finally
                {
                    frmGeneralConfig.Dispose();
                }
            }
            this.Text = M2Share.g_Config.sServerName;
        }

        public void MENU_OPTION_GAMEClick(object sender, EventArgs e)
        {
            if (!(TfrmGameConfig.frmGameConfig != null))
            {
                TfrmGameConfig frmGameConfig = new TfrmGameConfig();
                try
                {
                    frmGameConfig.Top = this.Top + 20;
                    frmGameConfig.Left = this.Left;
                    frmGameConfig.Icon = this.Icon;
                    frmGameConfig.Open();
                }
                finally
                {
                    frmGameConfig.Dispose();
                }
            }
        }

        public void MENU_OPTION_FUNCTIONClick(object sender, EventArgs e)
        {
            if (!(TfrmFunctionConfig.frmFunctionConfig != null))
            {
                TfrmFunctionConfig frmFunctionConfig = new TfrmFunctionConfig();
                try
                {
                    frmFunctionConfig.Top = this.Top + 20;
                    frmFunctionConfig.Left = this.Left;
                    frmFunctionConfig.Icon = this.Icon;
                    frmFunctionConfig.Open();
                }
                finally
                {
                    frmFunctionConfig.Dispose();
                }
            }
        }

        public void G1Click(object sender, EventArgs e)
        {
            if (!(TfrmGameCmd.frmGameCmd != null))
            {
                TfrmGameCmd frmGameCmd = new TfrmGameCmd();
                try
                {
                    frmGameCmd.Top = this.Top + 20;
                    frmGameCmd.Left = this.Left;
                    frmGameCmd.Icon = this.Icon;
                    frmGameCmd.Open();
                }
                finally
                {
                    frmGameCmd.Dispose();
                }
            }
        }

        public void MENU_OPTION_MONSTERClick(object sender, EventArgs e)
        {
            //if (!(MonsterConfig.Units.MonsterConfig.frmMonsterConfig != null))
            //{
            //    MonsterConfig.Units.MonsterConfig.frmMonsterConfig = new TfrmMonsterConfig(this.Owner);
            //    try {
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Top = this.Top + 20;
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Left = this.Left;
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Open();
            //    } finally {
            //        MonsterConfig.Units.MonsterConfig.frmMonsterConfig.Free;
            //    }
            //}
        }

        public void MENU_CONTROL_RELOAD_MONSTERSAYClick(object sender, EventArgs e)
        {
            M2Share.UserEngine.ClearMonSayMsg();
            M2Share.LoadMonSayMsg();
            M2Share.MainOutMessage("���¼��ع���˵���������...");
        }

        public void MENU_CONTROL_RELOAD_DISABLEMAKEClick(object sender, EventArgs e)
        {
            M2Share.LoadDisableTakeOffList();
            M2Share.LoadDisableMakeItem();
            M2Share.LoadEnableMakeItem();
            M2Share.LoadDisableMoveMap();
            M2Share.ItemUnit.LoadCustomItemName();
            M2Share.LoadDisableSendMsgList();
            M2Share.LoadGameLogItemNameList();
            M2Share.LoadItemBindIPaddr();
            M2Share.LoadItemBindAccount();
            M2Share.LoadItemBindCharName();
            M2Share.LoadItemBindDieNoDropName();// ��ȡ����װ�����������б�
            M2Share.LoadUnMasterList();
            M2Share.LoadUnForceMasterList();
            M2Share.LoadDenyIPAddrList();
            M2Share.LoadDenyAccountList();
            M2Share.LoadDenyChrNameList();// ���ؽ�ֹ��¼�����б�
            M2Share.LoadNoClearMonList();
            FrmDB.LoadAdminList();
            M2Share.MainOutMessage("���¼����б��������...");
        }

        public void MENU_CONTROL_RELOAD_STARTPOINTClick(object sender, EventArgs e)
        {
            FrmDB.LoadStartPoint();
            M2Share.MainOutMessage("���µ�ͼ��ȫ���б����...");
        }

        public void MENU_CONTROL_GATE_OPENClick(object sender, EventArgs e)
        {
            //const string sGatePortOpen = "��Ϸ���ض˿�({0}:{1})�Ѵ�...";
            //if (!GateSocket.Active)
            //{
            //    GateSocket.Active = true;
            //    M2Share.MainOutMessage(string.Format(sGatePortOpen, GateSocket.Address, GateSocket.Port));
            //}
        }

        public void MENU_CONTROL_GATE_CLOSEClick(object sender, EventArgs e)
        {
            CloseGateSocket();
        }

        // �����־
        private void CloseGateSocket()
        {
            int I;
            const string sGatePortClose = "��Ϸ���ض˿�(%s:%d)�ѹر�...";

            //if (GateSocket.Active)
            //{
            //    if (GateSocket.Socket.ActiveConnections > 0)
            //    {
            //        for (I = 0; I < GateSocket.Socket.ActiveConnections; I ++ )
            //        {
            //            GateSocket.Socket.Connections[I].Close;
            //        }
            //    }
            //    GateSocket.Active = false;
            //    M2Share.MainOutMessage(string.Format(sGatePortClose, new object[] {GateSocket.Address, GateSocket.Port}));
            //}
        }

        public void MENU_CONTROLClick(object sender, EventArgs e)
        {
            //if (GateSocket.Active)
            //{
            //    MENU_CONTROL_GATE_OPEN.Enabled = false;
            //    MENU_CONTROL_GATE_CLOSE.Enabled = true;
            //}
            //else
            //{
            //    MENU_CONTROL_GATE_OPEN.Enabled = true;
            //    MENU_CONTROL_GATE_CLOSE.Enabled = false;
            //}
        }

        public void MENU_VIEW_GATEClick(Object Sender)
        {
            // MENU_VIEW_GATE.Checked := not MENU_VIEW_GATE.Checked;
            // GridGate.Visible := MENU_VIEW_GATE.Checked;
        }

        public void MENU_VIEW_SESSIONClick(object sender, EventArgs e)
        {
            //if (!(ViewSession.Units.ViewSession.frmViewSession != null))
            //{
            //    ViewSession.Units.ViewSession.frmViewSession = new TfrmViewSession(this.Owner);
            //    try {
            //        ViewSession.Units.ViewSession.frmViewSession.Top = this.Top + 20;
            //        ViewSession.Units.ViewSession.frmViewSession.Left = this.Left;
            //        ViewSession.Units.ViewSession.frmViewSession.Open();
            //    } finally {
            //        ViewSession.Units.ViewSession.frmViewSession.Free;
            //    }
            //}
        }

        public void MENU_VIEW_ONLINEHUMANClick(object sender, EventArgs e)
        {
            //if (!(ViewOnlineHuman.Units.ViewOnlineHuman.frmViewOnlineHuman != null))
            //{
            //    ViewOnlineHuman.Units.ViewOnlineHuman.frmViewOnlineHuman = new TfrmViewOnlineHuman(this.Owner);
            //    try {
            //        ViewOnlineHuman.Units.ViewOnlineHuman.frmViewOnlineHuman.Top = this.Top + 20;
            //        ViewOnlineHuman.Units.ViewOnlineHuman.frmViewOnlineHuman.Left = this.Left;
            //        ViewOnlineHuman.Units.ViewOnlineHuman.frmViewOnlineHuman.Open();
            //    } finally {
            //        ViewOnlineHuman.Units.ViewOnlineHuman.frmViewOnlineHuman.Free;
            //    }
            //}
        }

        public void MENU_VIEW_LEVELClick(object sender, EventArgs e)
        {
            //if (!(ViewLevel.Units.ViewLevel.frmViewLevel != null))
            //{
            //    ViewLevel.Units.ViewLevel.frmViewLevel = new TfrmViewLevel(this.Owner);
            //    try {
            //        ViewLevel.Units.ViewLevel.frmViewLevel.Top = this.Top + 20;
            //        ViewLevel.Units.ViewLevel.frmViewLevel.Left = this.Left;
            //        ViewLevel.Units.ViewLevel.frmViewLevel.Open();
            //    } finally {
            //        ViewLevel.Units.ViewLevel.frmViewLevel.Free;
            //    }
            //}
        }

        public void MENU_VIEW_LISTClick(object sender, EventArgs e)
        {
            if (!(TfrmViewList.frmViewList != null))
            {
                TfrmViewList frmViewList = new TfrmViewList();
                try
                {
                    frmViewList.Top = this.Top + 20;
                    frmViewList.Left = this.Left;
                    frmViewList.Icon = this.Icon;
                    frmViewList.Open();
                }
                finally
                {
                    frmViewList.Dispose();
                }
            }
        }

        public void MENU_MANAGE_ONLINEMSGClick(object sender, EventArgs e)
        {
            //if (!(OnlineMsg.Units.OnlineMsg.frmOnlineMsg != null))
            //{
            //    OnlineMsg.Units.OnlineMsg.frmOnlineMsg = new TfrmOnlineMsg(this.Owner);
            //    try {
            //        OnlineMsg.Units.OnlineMsg.frmOnlineMsg.Top = this.Top + 20;
            //        OnlineMsg.Units.OnlineMsg.frmOnlineMsg.Left = this.Left;
            //        OnlineMsg.Units.OnlineMsg.frmOnlineMsg.Open();
            //    } finally {
            //        OnlineMsg.Units.OnlineMsg.frmOnlineMsg.Free;
            //    }
            //}
        }

        public void MENU_MANAGE_PLUGClick(object sender, EventArgs e)
        {
            //if (!(PlugInManage.Units.PlugInManage.ftmPlugInManage != null))
            //{
            //    PlugInManage.Units.PlugInManage.ftmPlugInManage = new TftmPlugInManage(this.Owner);
            //    try {
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Top = this.Top + 20;
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Left = this.Left;
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Open();
            //    } finally {
            //        PlugInManage.Units.PlugInManage.ftmPlugInManage.Free;
            //    }
            //}
        }

        /// <summary>
        /// ���ó���˵�
        /// </summary>
        public virtual void SetMenu()
        {
            this.Menu = MainMenu;
        }

        public void MENU_VIEW_KERNELINFOClick(object sender, EventArgs e)
        {
            //if (!(ViewKernelInfo.Units.ViewKernelInfo.frmViewKernelInfo != null))
            //{
            //    ViewKernelInfo.Units.ViewKernelInfo.frmViewKernelInfo = new TfrmViewKernelInfo(this.Owner);
            //    try {
            //        ViewKernelInfo.Units.ViewKernelInfo.frmViewKernelInfo.Top = this.Top + 20;
            //        ViewKernelInfo.Units.ViewKernelInfo.frmViewKernelInfo.Left = this.Left;
            //        ViewKernelInfo.Units.ViewKernelInfo.frmViewKernelInfo.Open();
            //    } finally {
            //        ViewKernelInfo.Units.ViewKernelInfo.frmViewKernelInfo.Free;
            //    }
            //}
        }

        public void MENU_TOOLS_MERCHANTClick(object sender, EventArgs e)
        {
            //if (!(ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant != null))
            //{
            //    ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant = new TfrmConfigMerchant(this.Owner);
            //    try {
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Top = this.Top + 20;
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Left = this.Left;
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Open();
            //    } finally {
            //        ConfigMerchant.Units.ConfigMerchant.frmConfigMerchant.Free;
            //    }
            //}
        }

        public void MENU_OPTION_ITEMFUNCClick(object sender, EventArgs e)
        {
            //if (!(ItemSet.Units.ItemSet.frmItemSet != null))
            //{
            //    ItemSet.Units.ItemSet.frmItemSet = new TfrmItemSet(this.Owner);
            //    try {
            //        ItemSet.Units.ItemSet.frmItemSet.Top = this.Top + 20;
            //        ItemSet.Units.ItemSet.frmItemSet.Left = this.Left;
            //        ItemSet.Units.ItemSet.frmItemSet.Open();
            //    } finally {
            //        ItemSet.Units.ItemSet.frmItemSet.Free;
            //    }
            //}
        }

        private void ClearMemoLog()
        {
            if (MessageBox.Show("�Ƿ�ȷ�������־��Ϣ������", "��ʾ��Ϣ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MemoLog.Clear();
            }
        }

        public void MENU_TOOLS_MONGENClick(object sender, EventArgs e)
        {
            //if (!(ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen != null))
            //{
            //    ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen = new TfrmConfigMonGen(this.Owner);
            //    try {
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Top = this.Top + 20;
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Left = this.Left;
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Open();
            //    } finally {
            //        ConfigMonGen.Units.ConfigMonGen.frmConfigMonGen.Free;
            //    }
            //}
        }

        /// <summary>
        /// ��ѯIP���ڵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MENU_TOOLS_IPSEARCHClick(object sender, EventArgs e)
        {
            string sIPaddr = string.Empty;
            try
            {
                sIPaddr = "192.168.0.1";
                InputBox.Show("IP���ڵ�����ѯ", "����IP��ַ:", sIPaddr);
                if (string.IsNullOrEmpty(InputBox.FileName))
                {
                    return;
                }
                sIPaddr = InputBox.FileName;
                if (!HUtil32.IsIPAddr(sIPaddr))
                {
                    System.Windows.Forms.MessageBox.Show("�����IP��ַ��ʽ����ȷ������", "������Ϣ", System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }
                OutManMessage(string.Format("{0}:{1}",sIPaddr, M2Share.GetIPLocal(sIPaddr)));
            }
            catch
            {
                OutManMessage(string.Format("{0}:{1}",sIPaddr, M2Share.GetIPLocal(sIPaddr)));
            }
        }

        public void MENU_MANAGE_CASTLEClick(object sender, EventArgs e)
        {
            //if (!(CastleManage.Units.CastleManage.frmCastleManage != null))
            //{
            //    CastleManage.Units.CastleManage.frmCastleManage = new TfrmCastleManage(this.Owner);
            //    try {
            //        CastleManage.Units.CastleManage.frmCastleManage.Top = this.Top + 20;
            //        CastleManage.Units.CastleManage.frmCastleManage.Left = this.Left;
            //        CastleManage.Units.CastleManage.frmCastleManage.Open();
            //    } finally {
            //        CastleManage.Units.CastleManage.frmCastleManage.Free;
            //    }
            //}
        }

        public void QFunctionNPCClick(object sender, EventArgs e)
        {
            if (M2Share.g_FunctionNPC != null)
            {
                M2Share.g_FunctionNPC.ClearScript();
                M2Share.g_FunctionNPC.LoadNpcScript();
                M2Share.MainOutMessage("QFunction �ű��������...");
            }
        }

        public void QManageNPCClick(object sender, EventArgs e)
        {
            if (M2Share.g_ManageNPC != null)
            {
                M2Share.g_ManageNPC.ClearScript();
                M2Share.g_ManageNPC.LoadNpcScript();
                M2Share.MainOutMessage("���¼��ص�½�ű����...");
            }
        }

        public void RobotManageNPCClick(object sender, EventArgs e)
        {
            if (M2Share.g_RobotNPC != null)
            {
                M2Share.RobotManage.ReLoadRobot();
                M2Share.g_RobotNPC.ClearScript();
                M2Share.g_RobotNPC.LoadNpcScript();
                M2Share.MainOutMessage("���¼��ػ����˽ű����...");
            }
        }

        public void MonItemsClick(object sender, EventArgs e)
        {
            TMonInfo Monster;
            try
            {
                if (M2Share.UserEngine.MonsterList.Count > 0)
                {
                    for (int I = 0; I < M2Share.UserEngine.MonsterList.Count; I++)
                    {
                        Monster = M2Share.UserEngine.MonsterList[I];
                        FrmDB.LoadMonitems(Monster.sName, ref Monster.ItemList);
                    }
                }
                M2Share.MainOutMessage("���ﱬ��Ʒ�б��ؼ������...");
            }
            catch
            {
                M2Share.MainOutMessage("���ﱬ��Ʒ�б��ؼ���ʧ�ܣ�����");
            }
        }

        public void MENU_OPTION_HEROClick(object sender, EventArgs e)
        {
            if (!(TfrmHeroConfig.frmHeroConfig != null))
            {
                TfrmHeroConfig frmHeroConfig = new TfrmHeroConfig();
                try
                {
                    frmHeroConfig.Top = this.Top;
                    frmHeroConfig.Left = this.Left;
                    frmHeroConfig.Icon = this.Icon;
                    frmHeroConfig.Open();
                }
                finally
                {
                    frmHeroConfig.Dispose();
                }
            }
        }

        public void N3Click(object sender, EventArgs e)
        {
            FrmDB.LoadBoxsList();// ���¼��ر����б�
            M2Share.MainOutMessage("���¼��ر����������...");
        }

        public void N1Click(object sender, EventArgs e)
        {
            if (!(TfrmViewList2.frmViewList2 != null))
            {
                TfrmViewList2 frmViewList2 = new TfrmViewList2();
                try
                {
                    frmViewList2.Top = this.Top + 20;
                    frmViewList2.Left = this.Left;
                    frmViewList2.Icon = this.Icon;
                    frmViewList2.Open();
                }
                finally
                {
                    frmViewList2 = null;
                }
            }
        }

        public void N5Click(object sender, EventArgs e)
        {
            if (FrmDB.LoadMonGen() > 0)
            {
                M2Share.MainOutMessage("���¼��ع���ˢ���������...");
            }
        }

        public void N6Click(object sender, EventArgs e)
        {
            if (M2Share.LoadLineNotice(M2Share.g_Config.sNoticeDir + "LineNotice.txt"))
            {
                M2Share.MainOutMessage("���¼��ع�����ʾ��Ϣ���...");
            }
        }

        public void N7Click(object sender, EventArgs e)
        {
            FrmDB.LoadRefineItem();
            M2Share.MainOutMessage("���¼��ش���������Ϣ���...");
        }

        public void NPC1Click(object sender, EventArgs e)
        {
            FrmDB.ReLoadMerchants();
            M2Share.UserEngine.ReloadMerchantList();
            M2Share.MainOutMessage("���¼��ؽ���NPC������Ϣ���...");
        }

        public void NPC2Click(object sender, EventArgs e)
        {
            FrmDB.ReLoadNpc();
            M2Share.UserEngine.ReloadNpcList();
            M2Share.MainOutMessage("���¼��ع���NPC������Ϣ���...");
        }

        public void S1Click(object sender, EventArgs e)
        {
            M2Share.g_CastleManager.ReLoadCastle();
            M2Share.MainOutMessage("���¼��سǱ�������Ϣ���...");
        }

        public void G2Click(object sender, EventArgs e)
        {
            if (!(TfrmGuildManage.frmGuildManage != null))
            {
                TfrmGuildManage frmGuildManage = new TfrmGuildManage();
                try
                {
                    frmGuildManage.Top = this.Top + 20;
                    frmGuildManage.Left = this.Left;
                    frmGuildManage.Icon = this.Icon;
                    frmGuildManage.Open();
                }
                finally
                {
                    frmGuildManage.Dispose();
                }
            }
        }

        public void N4Click(object sender, EventArgs e)
        {
            M2Share.LoadShopItemList();
            M2Share.MainOutMessage("���¼�������������Ϣ���...");
        }

        public void mapconfigClick(object sender, EventArgs e)
        {
            FrmDB.LoadMapInfo();
            M2Share.MainOutMessage("���¼��ص�ͼ������Ϣ���...");
        }

        public void monsterClick(object sender, EventArgs e)
        {
            FrmDB.LoadMonGen();
            M2Share.MainOutMessage("���¼���ˢ��������Ϣ���...");
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="nMsg"></param>
        public void OutManMessage(string nMsg)
        {
            MemoLog.Invoke((MethodInvoker)delegate() { MemoLog.AppendText(nMsg + Environment.NewLine); });
        }

        private void MENU_MANAGE_SYS_Click(object sender, EventArgs e)
        {
            if (!(TfrmSysManager.frmSysManager != null))
            {
                TfrmSysManager frmSysManager = new TfrmSysManager();
                try
                {
                    frmSysManager.Top = this.Top + 20;
                    frmSysManager.Left = this.Left;
                    frmSysManager.Icon = this.Icon;
                    frmSysManager.Open();
                }
                finally
                {
                    frmSysManager.Dispose();
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            System.Environment.Exit(0);
            base.OnClosed(e);
        }
    }
}