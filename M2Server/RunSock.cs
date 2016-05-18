using GameFramework;
using M2Server.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace M2Server
{
    /// <summary>
    /// �����û���Ϣ
    /// </summary>
    public class TGateUserInfo
    {
        public string sAccount;
        public string sCharName;
        public string sIPaddr;
        public int nSocket;
        public int nGSocketIdx;
        /// <summary>
        /// �ỰID
        /// </summary>
        public int nSessionID;
        /// <summary>
        /// �ͻ��˰汾��Ϣ
        /// </summary>
        public int nClientVersion;
        public TUserEngine UserEngine;
        public TFrontEngine FrontEngine;
        public TPlayObject PlayObject;
        /// <summary>
        /// �Ự״̬��Ϣ
        /// </summary>
        public TSessInfo SessInfo;
        public uint dwNewUserTick;
        /// <summary>
        /// �ͻ��������֤�Ƿ�ɹ�
        /// </summary>
        public bool boCertification;
    }

    public class TRunSocket : GameBase
    {
        public static TGateInfo[] g_GateArr;
        public static int g_nGateRecvMsgLenMin = 0;
        public static int g_nGateRecvMsgLenMax = 0;
        public static int nRunSocketRun = -1;
        public static int nExecGateBuffers = -1;

        public object m_RunSocketSection = null;
        public TStringList m_RunAddrList = null;
        public int n8 = 0;
        public TIPAddr[] m_IPaddrArr;
        public int n4F8 = 0;
        public uint dwSendTestMsgTick = 0;
        public int m_nErrorCount = 0;

        public TRunSocket()
        {
            TGateInfo Gate;
            m_RunSocketSection = new object();
            m_RunAddrList = new TStringList();
            g_GateArr = new TGateInfo[5];
            TGateInfo.InitGateList(ref g_GateArr);
            for (int I = g_GateArr.GetLowerBound(0); I <= g_GateArr.GetUpperBound(0); I++)
            {
                Gate = g_GateArr[I];
                Gate.Socket = null;
                Gate.boUsed = false;
                Gate.Socket = null;
                Gate.boSendKeepAlive = false;
                Gate.nSendMsgCount = 0;
                Gate.nSendRemainCount = 0;
                Gate.dwSendTick = HUtil32.GetTickCount();
                Gate.nSendMsgBytes = 0;
                Gate.nSendedMsgCount = 0;
            }
            m_nErrorCount = 0;
            LoadRunAddr();
            n4F8 = 0;
        }

        ~TRunSocket()
        {
            m_RunAddrList.Dispose();
            m_RunSocketSection = null;

            //m_RunAddrList.Free;
            // DeleteCriticalSection(m_RunSocketSection);
        }

        /// <summary>
        /// �����Ϸ����
        /// </summary>
        /// <param name="e"></param>
        public void AddGate(NetFramework.AsyncUserToken e)
        {
            string sIPaddr;
            TGateInfo Gate;
            const string sGateOpen = "��Ϸ����[{0}]({1}:{2})�Ѵ�...";
            const string sKickGate = "������δ����: {0}";
            sIPaddr = e.EndPoint.Address.ToString();
            if (M2Share.boStartReady)
            {
                for (int I = g_GateArr.GetLowerBound(0); I <= g_GateArr.GetUpperBound(0); I++)
                {
                    Gate = g_GateArr[I];
                    if (Gate.boUsed)
                    {
                        continue;
                    }
                    Gate.boUsed = true;
                    Gate.Socket = e.Socket;
                    Gate.sAddr = GetGateAddr(sIPaddr);
                    Gate.nPort = e.EndPoint.Port;
                    Gate.n520 = 1;
                    Gate.UserList = new List<TGateUserInfo>();
                    Gate.nUserCount = 0;
                    Gate.Buffer = IntPtr.Zero;
                    Gate.nBuffLen = 0;
                    Gate.BufferList = new List<IntPtr>();
                    Gate.boSendKeepAlive = false;
                    Gate.nSendChecked = 0;
                    Gate.nSendBlockCount = 0;
                    Gate.dwTime544 = HUtil32.GetTickCount();
                    M2Share.MainOutMessage(string.Format(sGateOpen, I, sIPaddr, Gate.nPort));
                    break;
                }
            }
            else
            {
                M2Share.MainOutMessage(string.Format(sKickGate, sIPaddr));

                //e.Client.ClientSocket.Close();
            }
        }

        /// <summary>
        /// �ر�������������
        /// </summary>
        public void CloseAllGate()
        {
            TGateInfo Gate;
            for (int GateIdx = g_GateArr.GetLowerBound(0); GateIdx <= g_GateArr.GetUpperBound(0); GateIdx++)
            {
                Gate = g_GateArr[GateIdx];
                if (Gate.Socket != null)
                {
                    Gate.Socket.Close();
                }
            }
        }

        /// <summary>
        /// �رմ��������
        /// </summary>
        /// <param name="Socket"></param>
        /// <param name="ErrorCode"></param>
        public void CloseErrGate(Socket Socket)
        {
            if (Socket.Connected)
            {
                Socket.Close();
            }
        }

        /// <summary>
        /// �ر���Ϸ����
        /// </summary>
        /// <param name="e"></param>
        public void CloseGate(NetFramework.AsyncUserToken e)
        {
            int GateIdx;
            TGateUserInfo GateUser;
            IList<TGateUserInfo> UserList;
            TGateInfo Gate;
            const string sGateClose = "��Ϸ����[{0}]({1}:{2})�ѹر�...";
            HUtil32.EnterCriticalSection(m_RunSocketSection);
            try
            {
                for (GateIdx = g_GateArr.GetLowerBound(0); GateIdx <= g_GateArr.GetUpperBound(0); GateIdx++)
                {
                    Gate = g_GateArr[GateIdx];
                    if (Gate.Socket == e.Socket)
                    {
                        UserList = Gate.UserList;
                        for (int I = 0; I < UserList.Count; I++)
                        {
                            GateUser = UserList[I];
                            if (GateUser != null)
                            {
                                if (GateUser.PlayObject != null)
                                {
                                    GateUser.PlayObject.m_boEmergencyClose = true;
                                    GateUser.PlayObject.m_boPlayOffLine = false;
                                    if (!GateUser.PlayObject.m_boReconnection)
                                    {
                                        M2Share.FrmIDSoc.SendHumanLogOutMsg(GateUser.sAccount, GateUser.nSessionID);
                                    }
                                }
                                Dispose(GateUser);
                                UserList[I] = null;
                            }
                        }
                        Gate.UserList = null;
                        if (Gate.Buffer != null)
                        {
                            Marshal.FreeHGlobal(Gate.Buffer);
                        }
                        Gate.nBuffLen = 0;
                        for (int I = 0; I < Gate.BufferList.Count; I++)
                        {
                            Marshal.FreeHGlobal(Gate.BufferList[I]);
                        }
                        Gate.BufferList = null;
                        Gate.boUsed = false;
                        Gate.Socket = null;

                        M2Share.MainOutMessage(string.Format(sGateClose, GateIdx, e.EndPoint.Address, e.EndPoint.Port));
                        break;
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_RunSocketSection);
            }
        }

        /// <summary>
        /// ִ�����ط��͹���������
        /// </summary>
        /// <param name="nGateIndex"></param>
        /// <param name="Gate"></param>
        /// <param name="Buffer"></param>
        /// <param name="nMsgLen"></param>
        private unsafe void ExecGateBuffers(int nGateIndex, TGateInfo Gate, byte[] Buffer, int nMsgLen)
        {
            int nLen;
            byte* Buff;
            TMsgHeader MsgHeader;// Size 20
            int nCheckMsgLen;
            IntPtr TempBuff;
            IntPtr ip;
            const string sExceptionMsg1 = "{�쳣} TRunSocket::ExecGateBuffers -> pBuffer";
            const string sExceptionMsg2 = "{�쳣} TRunSocket::ExecGateBuffers -> @pwork,ExecGateMsg ";
            const string sExceptionMsg3 = "{�쳣} TRunSocket::ExecGateBuffers -> FreeMem";
            nLen = 0;
            Buff = null;
            try
            {
                if (Buffer != null)
                {
                    if (nMsgLen > 20)
                    {
                        ip = (IntPtr)(Gate.nBuffLen + nMsgLen);
                        if (Gate.Buffer != (IntPtr)0)
                        {
                            Gate.Buffer = Marshal.ReAllocHGlobal(Gate.Buffer, ip);
                        }
                        else
                        {
                            Gate.Buffer = Marshal.AllocHGlobal(ip);
                        }
                        Marshal.Copy(Buffer, 0, (IntPtr)((byte*)Gate.Buffer + Gate.nBuffLen), nMsgLen);
                    }
                    else
                    {
                        ip = (IntPtr)(Gate.nBuffLen + nMsgLen);
                        if (Gate.Buffer != (IntPtr)0)
                        {
                            Gate.Buffer = Marshal.ReAllocHGlobal(Gate.Buffer, ip);
                        }
                        else
                        {
                            Gate.Buffer = Marshal.AllocHGlobal(ip);
                        }
                        Marshal.Copy(Buffer, 0, (IntPtr)((byte*)Gate.Buffer + Gate.nBuffLen), nMsgLen);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg1);
            }
            try
            {
                nLen = Gate.nBuffLen + nMsgLen;
                Buff = (byte*)Gate.Buffer;
                if (nLen >= sizeof(TMsgHeader)) //Size 20
                {
                    while (true)
                    {
                        MsgHeader = *((TMsgHeader*)Buff);
                        nCheckMsgLen = Math.Abs(MsgHeader.nLength) + sizeof(TMsgHeader);
                        if ((MsgHeader.dwCode == Grobal2.RUNGATECODE) && (nCheckMsgLen < 0x8000))
                        {
                            if (nLen < nCheckMsgLen)
                            {
                                break;
                            }
                            byte* MsgBuff = Buff + sizeof(TMsgHeader);
                            if (MsgHeader.nLength > 0)
                            {
                                ExecGateMsg(nGateIndex, Gate, MsgHeader, MsgBuff, MsgHeader.nLength);
                            }
                            else
                            {
                                ExecGateMsg(nGateIndex, Gate, MsgHeader, MsgBuff, MsgHeader.nLength);
                            }
                            Buff += sizeof(TMsgHeader) + MsgHeader.nLength;
                            nLen = nLen - (MsgHeader.nLength + sizeof(TMsgHeader));
                        }
                        else
                        {
                            Buff++;
                            nLen--;
                        }
                        if (nLen < sizeof(TMsgHeader))
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg2);
            }
            try
            {
                if (nLen > 0)
                {
                    TempBuff = Marshal.AllocHGlobal(nLen);
                    HUtil32.IntPtrToIntPtr((IntPtr)Buff, 0, TempBuff, 0, nLen);
                    Marshal.FreeHGlobal(Gate.Buffer);
                    Gate.Buffer = TempBuff;
                    Gate.nBuffLen = nLen;
                }
                else
                {
                    Marshal.FreeHGlobal(Gate.Buffer);
                    Gate.Buffer = (IntPtr)0;
                    Gate.nBuffLen = 0;
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg3);
            }
        }

        public void SocketRead(NetFramework.AsyncUserToken e)
        {
            int nMsgLen = -1;
            int GateIdx;
            TGateInfo Gate;
            const string sExceptionMsg1 = "{�쳣} TRunSocket::SocketRead";
            byte[] data = null;
            try
            {
                for (GateIdx = g_GateArr.GetLowerBound(0); GateIdx <= g_GateArr.GetUpperBound(0); GateIdx++)
                {
                    Gate = g_GateArr[GateIdx];
                    if (Gate.Socket == e.Socket)
                    {
                        try
                        {
                            while (true)
                            {
                                if (e.ReceiveBuffer != null)
                                {
                                    data = new byte[e.BytesReceived];
                                    Array.Copy(e.ReceiveBuffer, e.Offset, data, 0, e.BytesReceived);
                                    nMsgLen = e.BytesReceived;
                                }
                                if (nMsgLen <= 0)
                                {
                                    break;
                                }

                                if (nMsgLen >= 59)
                                {
                                    lock (this)
                                    {
                                        ExecGateBuffers(GateIdx, Gate, data, nMsgLen);
                                    }
                                }
                                else
                                {
                                    lock (this)
                                    {
                                        ExecGateBuffers(GateIdx, Gate, data, nMsgLen);
                                    }
                                }
                                break;
                            }
                        }
                        catch
                        {
                            M2Share.MainOutMessage(sExceptionMsg1);
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TRunSocket::SocketRead1");
            }
        }

        public void Run()
        {
            uint dwRunTick;
            int nG;
            TGateInfo Gate;
            TGateUserInfo GateUser;
            int nSocket;
            int nGSocketIdx;
            byte nCode;
            const string sExceptionMsg = "{�쳣} TRunSocket::Run Code:";
            dwRunTick = HUtil32.GetTickCount();
            if (M2Share.boStartReady)
            {
                nCode = 0;
                try
                {
                    if (M2Share.g_Config.nGateLoad > 0)
                    {
                        nCode = 1;
                        if ((HUtil32.GetTickCount() - dwSendTestMsgTick) >= 100)
                        {
                            nCode = 2;
                            dwSendTestMsgTick = HUtil32.GetTickCount();
                            for (int I = g_GateArr.GetLowerBound(0); I <= g_GateArr.GetUpperBound(0); I++)
                            {
                                nCode = 3;
                                Gate = g_GateArr[I];
                                if (Gate.BufferList != null)
                                {
                                    nCode = 4;
                                    for (nG = 0; nG < M2Share.g_Config.nGateLoad; nG++)
                                    {
                                        SendGateTestMsg(I);
                                    }
                                }
                            }
                        }
                    }
                    nCode = 5;
                    for (int I = g_GateArr.GetLowerBound(0); I <= g_GateArr.GetUpperBound(0); I++)
                    {
                        Gate = g_GateArr[I];
                        nCode = 6;
                        if (Gate.UserList != null)
                        {
                            HUtil32.EnterCriticalSection(m_RunSocketSection);
                            try
                            {
                                nCode = 7;
                                for (int II = Gate.UserList.Count - 1; II >= 0; II--)
                                {
                                    nCode = 8;
                                    if (Gate.UserList[II] != null)
                                    {
                                        nCode = 9;
                                        GateUser = Gate.UserList[II];
                                        if (GateUser != null)
                                        {
                                            nCode = 10;
                                            if ((HUtil32.GetTickCount() - GateUser.dwNewUserTick > 20000) && !GateUser.boCertification)// 1000 * 20
                                            {
                                                nCode = 11;
                                                nSocket = GateUser.nSocket;
                                                nGSocketIdx = GateUser.nGSocketIdx;
                                                CloseUser(I, GateUser.nSocket);
                                                nCode = 12;
                                                SendOutConnectMsg(I, GateUser.nSocket, GateUser.nGSocketIdx);
                                                nCode = 13;
                                                SendTickUserCon(Gate.Socket, nSocket, (short)nGSocketIdx);// ����Ϣ��Rungate.exe,T����Ӧ������
                                            }
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                HUtil32.LeaveCriticalSection(m_RunSocketSection);
                            }
                        }
                    }
                    nCode = 14;
                    for (int I = g_GateArr.GetLowerBound(0); I <= g_GateArr.GetUpperBound(0); I++)
                    {
                        Gate = g_GateArr[I];
                        nCode = 15;
                        if (Gate.BufferList != null)
                        {
                            HUtil32.EnterCriticalSection(m_RunSocketSection);
                            try
                            {
                                nCode = 16;
                                Gate.nSendMsgCount = Gate.BufferList.Count;
                                nCode = 17;
                                if (SendGateBuffers(I, @Gate, Gate.BufferList))
                                {
                                    Gate.nSendRemainCount = Gate.BufferList.Count;
                                }
                                else
                                {
                                    Gate.nSendRemainCount = Gate.BufferList.Count;
                                }
                            }
                            finally
                            {
                                HUtil32.LeaveCriticalSection(m_RunSocketSection);
                            }
                        }
                    }
                    nCode = 18;
                    for (int I = g_GateArr.GetLowerBound(0); I <= g_GateArr.GetUpperBound(0); I++)
                    {
                        nCode = 19;
                        if (g_GateArr[I].Socket != null)
                        {
                            Gate = g_GateArr[I];
                            nCode = 20;
                            if ((HUtil32.GetTickCount() - Gate.dwSendTick) >= 1000)
                            {
                                Gate.dwSendTick = HUtil32.GetTickCount();
                                Gate.nSendMsgBytes = Gate.nSendBytesCount;
                                Gate.nSendedMsgCount = Gate.nSendCount;
                                Gate.nSendBytesCount = 0;
                                Gate.nSendCount = 0;
                            }
                            nCode = 21;
                            if (Gate.boSendKeepAlive)
                            {
                                Gate.boSendKeepAlive = false;
                                nCode = 22;
                                SendCheck(Gate.Socket, Common.GM_CHECKSERVER); // ����Rungate.exe���������Ƿ�����
                            }
                        }
                    }
                }
                catch
                {
                    M2Share.MainOutMessage(sExceptionMsg + nCode);
                }
            }
            M2Share.g_nSockCountMin = Convert.ToInt32(HUtil32.GetTickCount() - dwRunTick);
            if (M2Share.g_nSockCountMin > M2Share.g_nSockCountMax)
            {
                M2Share.g_nSockCountMax = M2Share.g_nSockCountMin;
            }
        }

        public bool DoClientCertification_GetCertification(string sMsg, ref string sAccount, ref string sChrName, ref int nSessionID, ref int nClientVersion, ref bool boFlag)
        {
            bool result = false;
            string sData = string.Empty;
            string sCodeStr = string.Empty;
            string sClientVersion = string.Empty;
            string sIdx;
            const string sExceptionMsg = "{�쳣} TRunSocket::DoClientCertification -> GetCertification";
            try
            {
                sData = EncryptUnit.DeCodeString(sMsg, true);
                if ((sData.Length > 2) && (sData[0] == '*') && (sData[1] == '*'))
                {
                    sData = sData.Substring(3 - 1, sData.Length - 2);
                    sData = HUtil32.GetValidStr3(sData, ref sAccount, new string[] { "/" });
                    sData = HUtil32.GetValidStr3(sData, ref sChrName, new string[] { "/" });
                    sData = HUtil32.GetValidStr3(sData, ref sCodeStr, new string[] { "/" });
                    sData = HUtil32.GetValidStr3(sData, ref sClientVersion, new string[] { "/" });
                    sIdx = sData;
                    nSessionID = HUtil32.Str_ToInt(sCodeStr, 0);
                    if (sIdx == "0")
                    {
                        boFlag = true;
                    }
                    else
                    {
                        boFlag = false;
                    }
                    if ((sAccount != "") && (sChrName != "") && (nSessionID >= 2))
                    {
                        nClientVersion = HUtil32.Str_ToInt(sClientVersion, 0);
                        result = true;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
            return result;
        }

        /// <summary>
        /// �ͻ�����֤
        /// </summary>
        /// <param name="GateIdx"></param>
        /// <param name="GateUser"></param>
        /// <param name="nSocket"></param>
        /// <param name="sMsg"></param>
        private void DoClientCertification(int GateIdx, TGateUserInfo GateUser, int nSocket, string sMsg)
        {
            int nCheckCode = 0;
            string sData;
            string sAccount = string.Empty;
            string sChrName = string.Empty;
            int nSessionID = 0;
            bool boFlag = false;
            int nClientVersion = 0;
            int nPayMent = 0;
            int nPayMode = 0;
            TSessInfo SessInfo;
            TPlayObject PlayObject;
            const string sExceptionMsg = "{�쳣} TRunSocket::DoClientCertification CheckCode: ";
            const string sDisable = "*disable*";
            try
            {
                if (GateUser.sAccount == "")
                {
                    if (HUtil32.TagCount(sMsg, '!') > 0)
                    {
                        sData = HUtil32.ArrestStringEx(sMsg, "#", "!", ref sMsg);
                        sMsg = sMsg.Substring(2 - 1, sMsg.Length - 1);
                        if (DoClientCertification_GetCertification(sMsg, ref sAccount, ref sChrName, ref nSessionID, ref nClientVersion, ref boFlag))
                        {
                            SessInfo = M2Share.FrmIDSoc.GetAdmission(sAccount, GateUser.sIPaddr, nSessionID, ref nPayMode, ref nPayMent);
                            if ((SessInfo != null) && (nPayMent > 0))
                            {
                                PlayObject = UserEngine.GetPlayObjectExOfAutoGetExp(sAccount.Trim());

                                #region ���߹һ�����ֱ�ӵ�½��Ϸ

                                if (PlayObject != null) // ���߹һ�����ֱ�ӵ�½��Ϸ
                                {
                                    if ((PlayObject.m_sCharName).ToLower().CompareTo((sChrName.Trim()).ToLower()) == 0)
                                    {
                                        PlayObject.m_boGhost = false;
                                        PlayObject.m_boDeath = false;
                                        PlayObject.m_boEmergencyClose = false;
                                        PlayObject.m_boSwitchData = false;
                                        PlayObject.m_boReconnection = false;
                                        PlayObject.m_boKickFlag = false;
                                        PlayObject.m_boSoftClose = false;
                                        PlayObject.m_dwSaveRcdTick = HUtil32.GetTickCount();
                                        PlayObject.m_boWantRefMsg = true;
                                        PlayObject.m_boDieInFight3Zone = false;
                                        PlayObject.m_Script = null;
                                        PlayObject.m_boTimeRecall = false;
                                        PlayObject.m_sMoveMap = "";
                                        PlayObject.m_nMoveX = 0;
                                        PlayObject.m_nMoveY = 0;
                                        PlayObject.m_dwRunTick = HUtil32.GetTickCount();
                                        PlayObject.m_nRunTime = 250;
                                        PlayObject.m_dwSearchTime = 1000;
                                        PlayObject.m_dwSearchTick = HUtil32.GetTickCount();
                                        PlayObject.m_nViewRange = 12;
                                        PlayObject.m_boNewHuman = false;
                                        PlayObject.m_boLoginNoticeOK = false;
                                        PlayObject.bo6AB = false;
                                        PlayObject.m_boExpire = false;
                                        PlayObject.m_boSendNotice = false;
                                        PlayObject.m_dwCheckDupObjTick = HUtil32.GetTickCount();
                                        PlayObject.dwTick578 = HUtil32.GetTickCount();
                                        PlayObject.dwTick57C = HUtil32.GetTickCount();
                                        PlayObject.m_boInSafeArea = false;

                                        // PlayObject.n5FC := 0;//δʹ�� 20080329
                                        PlayObject.m_dwMagicAttackTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwMagicAttackInterval = 0;
                                        PlayObject.m_dwAttackTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwMoveTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwTurnTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwActionTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwAttackCount = 0;
                                        PlayObject.m_dwAttackCountA = 0;
                                        PlayObject.m_dwMagicAttackCount = 0;
                                        PlayObject.m_dwMoveCount = 0;
                                        PlayObject.m_dwMoveCountA = 0;
                                        PlayObject.m_nOverSpeedCount = 0;

                                        // PlayObject.m_sOldSayMsg := '';//δʹ�� 20080329
                                        PlayObject.m_dwSayMsgTick = HUtil32.GetTickCount();
                                        PlayObject.m_boDisableSayMsg = false;
                                        PlayObject.m_dwDisableSayMsgTick = HUtil32.GetTickCount();
                                        PlayObject.m_dLogonTime = DateTime.Now;
                                        PlayObject.m_dwLogonTick = HUtil32.GetTickCount();
                                        PlayObject.m_boSwitchData = false;
                                        PlayObject.m_boSwitchDataSended = false;
                                        PlayObject.m_nWriteChgDataErrCount = 0;
                                        PlayObject.m_dwShowLineNoticeTick = HUtil32.GetTickCount();
                                        PlayObject.m_nShowLineNoticeIdx = 0;
                                        // PlayObject.m_nSoftVersionDateEx := 0;
                                        PlayObject.m_nKillMonExpRate = PlayObject.m_nKillMonExpRate;
                                        if (PlayObject.m_nKillMonExpRate == 0)
                                        {
                                            PlayObject.m_nKillMonExpRate = 100;
                                        }
                                        PlayObject.m_nOldKillMonExpRate = PlayObject.m_nKillMonExpRate;
                                        PlayObject.m_dwRateTick = HUtil32.GetTickCount();
                                        PlayObject.m_nPowerRate = 100;
                                        PlayObject.m_boSetStoragePwd = false;
                                        PlayObject.m_boReConfigPwd = false;
                                        PlayObject.m_boCheckOldPwd = false;
                                        PlayObject.m_boUnLockPwd = false;
                                        PlayObject.m_boUnLockStoragePwd = false;
                                        PlayObject.m_boPasswordLocked = false;// ���ֿ�
                                        PlayObject.m_btPwdFailCount = 0;
                                        PlayObject.m_boFilterSendMsg = false;
                                        PlayObject.m_boCanDeal = true;
                                        PlayObject.m_boCanDrop = true;
                                        PlayObject.m_boCanGetBackItem = true;
                                        PlayObject.m_boCanWalk = true;
                                        PlayObject.m_boCanRun = true;
                                        PlayObject.m_boCanHit = true;
                                        PlayObject.m_boCanSpell = true;
                                        PlayObject.m_boCanUseItem = true;
                                        PlayObject.m_nMemberType = 0;
                                        PlayObject.m_nMemberLevel = 0;
                                        PlayObject.m_boDecGameGold = false;
                                        PlayObject.m_nDecGameGold = 1;
                                        PlayObject.m_dwDecGameGoldTick = HUtil32.GetTickCount();// 60 * 1000
                                        PlayObject.m_dwDecGameGoldTime = 60000;
                                        PlayObject.m_boIncGameGold = false;
                                        PlayObject.m_nIncGameGold = 1;
                                        PlayObject.m_dwIncGameGoldTick = HUtil32.GetTickCount();// 60 * 1000
                                        PlayObject.m_dwIncGameGoldTime = 60000;
                                        PlayObject.m_dwIncGamePointTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwDecGamePointTick = HUtil32.GetTickCount();
                                        PlayObject.m_nPayMentPoint = 0;
                                        PlayObject.m_DearHuman = null;
                                        PlayObject.m_MasterHuman = null;
                                        PlayObject.m_MasterList = new List<TPlayObject>();
                                        PlayObject.m_boSendMsgFlag = false;
                                        PlayObject.m_boChangeItemNameFlag = false;
                                        PlayObject.m_boCanMasterRecall = false;
                                        PlayObject.m_boCanDearRecall = false;
                                        PlayObject.m_dwDearRecallTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwMasterRecallTick = HUtil32.GetTickCount();
                                        PlayObject.m_btReColorIdx = 0;
                                        PlayObject.m_GetWhisperHuman = null;
                                        PlayObject.m_boOnHorse = false;
                                        PlayObject.m_wContribution = 0;
                                        PlayObject.m_sRankLevelName = GameMsgDef.g_sRankLevelName;
                                        PlayObject.m_boFixedHideMode = true;
                                        PlayObject.m_nStep = 0;
                                        PlayObject.m_nClientFlagMode = -1;
                                        PlayObject.m_dwAutoGetExpTick = HUtil32.GetTickCount();
                                        PlayObject.m_nAutoGetExpPoint = 0;
                                        PlayObject.m_AutoGetExpEnvir = null;

                                        // PlayObject.m_dwHitIntervalTime = g_Config.dwHitIntervalTime; //������� δʹ��
                                        PlayObject.m_dwMagicHitIntervalTime = M2Share.g_Config.dwMagicHitIntervalTime;// ħ�����
                                        PlayObject.m_dwRunIntervalTime = M2Share.g_Config.dwRunIntervalTime;// ��·���
                                        PlayObject.m_dwWalkIntervalTime = M2Share.g_Config.dwWalkIntervalTime;// ��·���
                                        PlayObject.m_dwTurnIntervalTime = M2Share.g_Config.dwTurnIntervalTime;// ��������
                                        PlayObject.m_dwActionIntervalTime = M2Share.g_Config.dwActionIntervalTime;// ��ϲ������
                                        PlayObject.m_dwRunLongHitIntervalTime = M2Share.g_Config.dwRunLongHitIntervalTime;// ��ϲ������
                                        PlayObject.m_dwRunHitIntervalTime = M2Share.g_Config.dwRunHitIntervalTime;// ��ϲ������
                                        PlayObject.m_dwWalkHitIntervalTime = M2Share.g_Config.dwWalkHitIntervalTime;// ��ϲ������
                                        PlayObject.m_dwRunMagicIntervalTime = M2Share.g_Config.dwRunMagicIntervalTime;// ��λħ�����
                                        PlayObject.m_boTestSpeedMode = false;
                                        PlayObject.m_boLockLogon = true;
                                        PlayObject.m_boLockLogoned = false;
                                        PlayObject.m_boRemoteMsg = false;// �Ƿ����������Ϣ
                                        // PlayObject.m_boNotOnlineAddExp := False; //�Ƿ������߹һ�����
                                        PlayObject.m_boStartAutoAddExpPoint = false;// �Ƿ�ʼ���Ӿ���
                                        PlayObject.m_dwStartNotOnlineAddExpTime = 0;// ���߹һ���ʼʱ��
                                        PlayObject.m_dwNotOnlineAddExpTime = 0;// ���߹һ�ʱ��
                                        PlayObject.m_nNotOnlineAddExpPoint = 0;// ���߹һ�ÿ�������Ӿ���ֵ
                                        PlayObject.m_dwAutoAddExpPointTick = HUtil32.GetTickCount();
                                        PlayObject.m_dwAutoAddExpPointTimeTick = HUtil32.GetTickCount();
                                        PlayObject.m_sAutoSendMsg = "���ã������������ݵ���......";// �Զ��ظ���Ϣ
                                        PlayObject.m_boKickAutoAddExpUser = false;
                                        PlayObject.m_boTimeGoto = false;
                                        PlayObject.m_dwTimeGotoTick = HUtil32.GetTickCount();
                                        PlayObject.m_sTimeGotoLable = "";
                                        PlayObject.m_TimeGotoNPC = null;
                                        PlayObject.m_nDealGoldPose = 0;
                                        PlayObject.m_nScriptGotoCount = 0;//�������߹һ������߻��нű���ѭ���Ĵ���
                                        PlayObject.m_MyGuild = M2Share.g_GuildManager.MemberOfGuild(PlayObject.m_sCharName);//�����ѻ��������¶�ȡ�л�
                                        if (PlayObject.m_DynamicVarList.Count > 0)
                                        {
                                            for (int I = 0; I < PlayObject.m_DynamicVarList.Count; I++)// �����������
                                            {
                                                if (PlayObject.m_DynamicVarList[I] != null)
                                                {
                                                    Dispose(PlayObject.m_DynamicVarList[I]);
                                                }
                                            }
                                        }
                                        PlayObject.m_DynamicVarList.Clear();
                                        PlayObject.m_sIPaddr = GateUser.sIPaddr;
                                        PlayObject.m_nGSocketIdx = GateUser.nGSocketIdx;
                                        PlayObject.m_nGateIdx = GateIdx;
                                        PlayObject.m_nSocket = nSocket;
                                        PlayObject.m_nSessionID = nSessionID;
                                        PlayObject.m_nPayMent = nPayMent;
                                        PlayObject.m_nPayMode = nPayMode;
                                        PlayObject.m_boReadyRun = false;
                                        GateUser.boCertification = true;
                                        GateUser.sAccount = sAccount.Trim();
                                        GateUser.sCharName = sChrName.Trim();
                                        GateUser.nSessionID = nSessionID;
                                        GateUser.nClientVersion = nClientVersion;
                                        GateUser.SessInfo = SessInfo;
                                        SetGateUserList(PlayObject.m_nGateIdx, PlayObject.m_nSocket, PlayObject);
                                        UserEngine.SendServerGroupMsg(Grobal2.SS_201, M2Share.nServerIndex, PlayObject.m_sCharName);
                                    }
                                    else
                                    {
                                        // ͬһ���˺Ų�ͬ����
                                        PlayObject.m_boPlayOffLine = false;
                                        PlayObject.m_boNotOnlineAddExp = false;
                                        GateUser.boCertification = true;
                                        GateUser.sAccount = sAccount.Trim();
                                        GateUser.sCharName = sChrName.Trim();
                                        GateUser.nSessionID = nSessionID;
                                        GateUser.nClientVersion = nClientVersion;
                                        GateUser.SessInfo = SessInfo;
                                        try
                                        {
                                            M2Share.FrontEngine.AddToLoadRcdList(sAccount, sChrName, GateUser.sIPaddr, boFlag, nSessionID, nPayMent, nPayMode,
                                                nClientVersion, nSocket, GateUser.nGSocketIdx, GateIdx);
                                        }
                                        catch
                                        {
                                            M2Share.MainOutMessage(string.Format(sExceptionMsg, new int[] { nCheckCode }));
                                        }
                                    }
                                }

                                #endregion ���߹һ�����ֱ�ӵ�½��Ϸ

                                #region ���������½��Ϸ

                                else
                                {
                                    GateUser.boCertification = true;
                                    GateUser.sAccount = sAccount.Trim();
                                    GateUser.sCharName = sChrName.Trim();
                                    GateUser.nSessionID = nSessionID;
                                    GateUser.nClientVersion = nClientVersion;
                                    GateUser.SessInfo = SessInfo;
                                    try
                                    {
                                        M2Share.FrontEngine.AddToLoadRcdList(sAccount, sChrName, GateUser.sIPaddr, boFlag, nSessionID, nPayMent, nPayMode, nClientVersion,
                                            nSocket, GateUser.nGSocketIdx, GateIdx);
                                    }
                                    catch
                                    {
                                        M2Share.MainOutMessage(string.Format(sExceptionMsg, new int[] { nCheckCode }));
                                    }
                                }

                                #endregion ���������½��Ϸ
                            }
                            else
                            {
                                nCheckCode = 2;
                                GateUser.sAccount = sDisable;
                                GateUser.boCertification = false;
                                CloseUser(GateIdx, nSocket);
                                nCheckCode = 3;
                            }
                        }
                        else
                        {
                            nCheckCode = 4;
                            GateUser.sAccount = sDisable;
                            GateUser.boCertification = false;
                            CloseUser(GateIdx, nSocket);
                            nCheckCode = 5;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode));
            }
        }

        /// <summary>
        /// ����Ϣ����Rungate
        /// </summary>
        /// <param name="GateIdx"></param>
        /// <param name="Gate"></param>
        /// <param name="MsgList"></param>
        /// <returns></returns>
        private unsafe bool SendGateBuffers(int GateIdx, TGateInfo Gate, IList<IntPtr> MsgList)
        {
            bool result = true;
            uint dwRunTick;
            IntPtr BufferA;
            IntPtr BufferB;
            IntPtr BufferC;
            int nBuffALen = -1;
            int nBuffBLen = -1;
            int nBuffCLen = -1;
            int nSendBuffLen = -1;
            const string sExceptionMsg1 = "{�쳣} TRunSocket::SendGateBuffers -> ProcessBuff Code:";
            const string sExceptionMsg2 = "{�쳣} TRunSocket::SendGateBuffers -> SendBuff Code:";
            byte nCode = 0;
            int I;
            if (MsgList.Count == 0 || !Gate.Socket.Connected) //�����ж��Ƿ���������������
            {
                return result;
            }
            dwRunTick = HUtil32.GetTickCount();
            nCode = 1;
            if (Gate.nSendChecked > 0) // �������δ�ظ�״̬��Ϣ�����ٷ�������
            {
                nCode = 2;
                if ((HUtil32.GetTickCount() - Gate.dwSendCheckTick) > M2Share.g_dwSocCheckTimeOut)// 2 * 1000
                {
                    nCode = 3;
                    Gate.nSendChecked = 0;
                    Gate.nSendBlockCount = 0;
                }
                return result;
            }

            // ��С���ݺϲ�Ϊһ��ָ����С������
            try
            {
                I = 0;
                nCode = 4;
                BufferA = MsgList[I];
                while (true)
                {
                    try
                    {
                        if ((I + 1) >= MsgList.Count)
                        {
                            break;
                        }
                        nCode = 5;
                        BufferB = MsgList[I + 1];
                        nCode = 6;
                        nBuffALen = *(int*)BufferA;

                        //Move(BufferA, nBuffALen, sizeof(int));
                        nBuffBLen = *(int*)BufferB;

                        //Move(BufferB, nBuffBLen, sizeof(int));
                        nCode = 7;
                        if ((nBuffALen + nBuffBLen) < M2Share.g_Config.nSendBlock)
                        {
                            nCode = 8;
                            MsgList.RemoveAt(I + 1);
                            nCode = 25;
                            BufferC = Marshal.AllocHGlobal(nBuffALen + sizeof(int) + nBuffBLen);

                            //GetMem(BufferC, nBuffALen + sizeof(int) + nBuffBLen);
                            nCode = 26;
                            nBuffCLen = nBuffALen + nBuffBLen;
                            nCode = 10;
                            *(int*)BufferC = nBuffCLen;

                            //Move(nBuffCLen, BufferC, sizeof(int));
                            HUtil32.IntPtrToIntPtr(BufferA, sizeof(int), BufferC, sizeof(int), nBuffALen);

                            //Move(BufferA[sizeof(int)], (BufferC + sizeof(int) as string), nBuffALen);
                            HUtil32.IntPtrToIntPtr(BufferB, sizeof(int), BufferC, nBuffALen + sizeof(int), nBuffBLen);

                            //Move(BufferB[sizeof(int)], (BufferC + nBuffALen + sizeof(int) as string), nBuffBLen);
                            nCode = 11;
                            Marshal.FreeHGlobal(BufferA);

                            //FreeMem(BufferA);
                            Marshal.FreeHGlobal(BufferB);

                            //FreeMem(BufferB);
                            nCode = 12;
                            BufferA = BufferC;
                            nCode = 13;
                            MsgList[I] = BufferA;
                            continue;
                        }
                        I++;
                        BufferA = BufferB;
                    }
                    catch
                    {
                        M2Share.MainOutMessage(sExceptionMsg1 + (nCode).ToString());
                        break;//�쳣���˳�ѭ��
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg1 + (nCode).ToString());
            }
            try
            {
                nCode = 15;
                while (MsgList.Count > 0)
                {
                    BufferA = MsgList[0];
                    if (BufferA == null)
                    {
                        MsgList.RemoveAt(0);
                        continue;
                    }
                    nCode = 16;
                    nSendBuffLen = *(int*)BufferA;

                    //Move(BufferA, nSendBuffLen, sizeof(int));
                    if ((Gate.nSendChecked == 0) && ((Gate.nSendBlockCount + nSendBuffLen) >= M2Share.g_Config.nCheckBlock))
                    {
                        nCode = 17;
                        if ((Gate.nSendBlockCount == 0) && (M2Share.g_Config.nCheckBlock <= nSendBuffLen))
                        {
                            nCode = 18;
                            MsgList.RemoveAt(0);// ������ݴ�С����ָ����С���ӵ�(�༭���ݱȽϴ�����е��ϵ)
                            Marshal.FreeHGlobal(BufferA);

                            //BufferA = null;
                            //FreeMem(BufferA);
                        }
                        else
                        {
                            nCode = 19;
                            SendCheck(Gate.Socket, Common.GM_RECEIVE_OK);
                            Gate.nSendChecked = 1;
                            Gate.dwSendCheckTick = HUtil32.GetTickCount();
                        }
                        break;
                    }
                    nCode = 20;
                    MsgList.RemoveAt(0);
                    BufferB = (IntPtr)((byte*)BufferA + sizeof(int));

                    //BufferB = BufferA + sizeof(int);
                    if (nSendBuffLen > 0)
                    {
                        while (true)
                        {
                            if (M2Share.g_Config.nSendBlock <= nSendBuffLen)
                            {
                                nCode = 21;
                                if (Gate.Socket != null)
                                {
                                    if (Gate.Socket.Connected)
                                    {
                                        byte[] SendBy = new byte[M2Share.g_Config.nSendBlock];
                                        Marshal.Copy(BufferB, SendBy, 0, M2Share.g_Config.nSendBlock);
                                        Gate.Socket.Send(SendBy, SocketFlags.None);

                                        //Gate.Socket.Send(BufferB, M2Share.g_Config.nSendBlock, SocketFlags.None);
                                    }
                                    Gate.nSendCount++;
                                    Gate.nSendBytesCount += M2Share.g_Config.nSendBlock;
                                }
                                nCode = 22;
                                Gate.nSendBlockCount += M2Share.g_Config.nSendBlock;
                                BufferB = (IntPtr)((byte*)BufferB + M2Share.g_Config.nSendBlock);

                                //BufferB = BufferB[M2Share.g_Config.nSendBlock];
                                nSendBuffLen -= M2Share.g_Config.nSendBlock;
                                continue;
                            }
                            nCode = 23;
                            if (Gate.Socket != null)
                            {
                                if (Gate.Socket.Connected)
                                {
                                    byte[] SendBy = new byte[nSendBuffLen];
                                    Marshal.Copy(BufferB, SendBy, 0, nSendBuffLen);
                                    Gate.Socket.Send(SendBy, SocketFlags.None);

                                    //Gate.Socket.Send(BufferB, nSendBuffLen,SocketFlags.None);
                                }
                                Gate.nSendCount++;
                                Gate.nSendBytesCount += nSendBuffLen;
                                Gate.nSendBlockCount += nSendBuffLen;
                            }
                            nSendBuffLen = 0;
                            break;
                        }
                    }
                    nCode = 24;
                    Marshal.FreeHGlobal(BufferA);

                    //FreeMem(BufferA);
                    if ((HUtil32.GetTickCount() - dwRunTick) > M2Share.g_dwSocLimit)
                    {
                        result = false;
                        break;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg2 + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// �ر��û�
        /// </summary>
        /// <param name="GateIdx"></param>
        /// <param name="nSocket"></param>
        public void CloseUser(int GateIdx, int nSocket)
        {
            TGateUserInfo GateUser;
            TGateInfo Gate;
            const string sExceptionMsg0 = "{�쳣} TRunSocket::CloseUser 0";
            const string sExceptionMsg1 = "{�쳣} TRunSocket::CloseUser 1";
            const string sExceptionMsg2 = "{�쳣} TRunSocket::CloseUser 2";
            const string sExceptionMsg3 = "{�쳣} TRunSocket::CloseUser 3";
            const string sExceptionMsg4 = "{�쳣} TRunSocket::CloseUser 4";
            if (GateIdx <= g_GateArr.GetUpperBound(0))
            {
                Gate = g_GateArr[GateIdx];
                if (Gate.UserList != null)
                {
                    HUtil32.EnterCriticalSection(m_RunSocketSection);
                    try
                    {
                        try
                        {
                            for (int I = 0; I < Gate.UserList.Count; I++)
                            {
                                if (Gate.UserList[I] != null)
                                {
                                    GateUser = Gate.UserList[I];
                                    if (GateUser.nSocket == nSocket)
                                    {
                                        try
                                        {
                                            if (GateUser.FrontEngine != null)
                                            {
                                                GateUser.FrontEngine.DeleteHuman(I, GateUser.nSocket);
                                            }
                                        }
                                        catch
                                        {
                                            M2Share.MainOutMessage(sExceptionMsg1);
                                        }
                                        try
                                        {
                                            if (GateUser.PlayObject != null)
                                            {
                                                GateUser.PlayObject.m_boSoftClose = true;
                                            }
                                        }
                                        catch
                                        {
                                            M2Share.MainOutMessage(sExceptionMsg2);
                                        }
                                        try
                                        {
                                            if ((GateUser.PlayObject != null))
                                            {
                                                if ((GateUser.PlayObject.m_boGhost) && (!GateUser.PlayObject.m_boReconnection))
                                                {
                                                    M2Share.FrmIDSoc.SendHumanLogOutMsg(GateUser.sAccount, GateUser.nSessionID);
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            M2Share.MainOutMessage(sExceptionMsg3);
                                        }
                                        try
                                        {
                                            Dispose(GateUser);
                                            Gate.UserList[I] = null;
                                            Gate.nUserCount -= 1;
                                        }
                                        catch
                                        {
                                            M2Share.MainOutMessage(sExceptionMsg4);
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            M2Share.MainOutMessage(sExceptionMsg0);
                        }
                    }
                    finally
                    {
                        HUtil32.LeaveCriticalSection(m_RunSocketSection);
                    }
                }
            }
        }

        private int OpenNewUser(int nSocket, int nGSocketIdx, string sIPaddr, IList<TGateUserInfo> UserList)
        {
            int result;
            TGateUserInfo GateUser;
            GateUser = new TGateUserInfo();
            GateUser.sAccount = "";
            GateUser.sCharName = "";
            GateUser.sIPaddr = sIPaddr;
            GateUser.nSocket = nSocket;
            GateUser.nGSocketIdx = nGSocketIdx;
            GateUser.nSessionID = 0;
            GateUser.UserEngine = null;
            GateUser.FrontEngine = null;
            GateUser.PlayObject = null;
            GateUser.dwNewUserTick = HUtil32.GetTickCount();
            GateUser.boCertification = false;
            for (int I = 0; I < UserList.Count - 1; I++)
            {
                if (UserList[I] == null)
                {
                    UserList[I] = GateUser;
                    result = I;
                    return result;
                }
            };
            UserList.Add(GateUser);
            result = UserList.Count - 1;
            return result;
        }

        /// <summary>
        /// ���͸������������û�
        /// </summary>
        /// <param name="Socket"></param>
        /// <param name="nSocket"></param>
        /// <param name="nSocketIndex"></param>
        /// <param name="nUserIdex"></param>
        private unsafe void SendNewUserMsg(Socket Socket, int nSocket, short nSocketIndex, int nUserIdex)
        {
            TMsgHeader MsgHeader;
            if (!Socket.Connected)
            {
                return;
            }
            MsgHeader = new TMsgHeader();
            MsgHeader.dwCode = Grobal2.RUNGATECODE;
            MsgHeader.nSocket = nSocket;
            MsgHeader.wGSocketIdx = nSocketIndex;
            MsgHeader.wIdent = Common.GM_SERVERUSERINDEX;
            MsgHeader.wUserListIndex = nUserIdex;
            MsgHeader.nLength = 0;
            if ((Socket != null) && Socket.Connected)
            {
                byte[] data = new byte[sizeof(TMsgHeader)];
                fixed (byte* pb = data)
                {
                    *(TMsgHeader*)pb = MsgHeader;
                }
                Socket.Send(data, 0, data.Length, SocketFlags.None);
            }
        }

        /// <summary>
        /// �߳�Rungate.exe��Ӧ������
        /// </summary>
        /// <param name="Socket"></param>
        /// <param name="nSocket"></param>
        /// <param name="nSocketIndex"></param>
        private unsafe void SendTickUserCon(Socket Socket, int nSocket, short nSocketIndex)
        {
            TMsgHeader MsgHeader;
            if (!Socket.Connected)
            {
                return;
            }
            MsgHeader = new TMsgHeader();
            MsgHeader.dwCode = Grobal2.RUNGATECODE;
            MsgHeader.nSocket = nSocket;
            MsgHeader.wGSocketIdx = nSocketIndex;
            MsgHeader.wIdent = Common.GM_KickConn;
            MsgHeader.nLength = 0;
            if ((Socket != null) && Socket.Connected)
            {
                byte[] data = new byte[sizeof(TMsgHeader)];
                fixed (byte* pb = data)
                {
                    *(TMsgHeader*)pb = MsgHeader;
                }
                Socket.Send(data, 0, data.Length, SocketFlags.None);
            }
        }

        /// <summary>
        /// ����Rungate�����İ�
        /// </summary>
        /// <param name="GateIdx"></param>
        /// <param name="Gate"></param>
        /// <param name="MsgHeader"></param>
        /// <param name="MsgBuff"></param>
        /// <param name="nMsgLen"></param>
        private unsafe void ExecGateMsg(int GateIdx, TGateInfo Gate, TMsgHeader MsgHeader, byte* MsgBuff, int nMsgLen)
        {
            int nCheckCode;
            int nUserIdx;
            string sIPaddr;
            TGateUserInfo GateUser;
            int nSocket;
            int nGSocketIdx;
            const string sExceptionMsg = "{�쳣} TRunSocket::ExecGateMsg {0}";
            nCheckCode = 0;
            TDefaultMessage* DefMsg = null;
            try
            {
                switch (MsgHeader.wIdent)
                {
                    case Common.GM_OPEN:  // 1 �ͻ�������Rungate
                        nCheckCode = 1;
                        sIPaddr = HUtil32.SBytePtrToString((sbyte*)MsgBuff, 0, nMsgLen);
                        nUserIdx = OpenNewUser(MsgHeader.nSocket, MsgHeader.wGSocketIdx, sIPaddr, Gate.UserList);
                        SendNewUserMsg(Gate.Socket, MsgHeader.nSocket, MsgHeader.wGSocketIdx, nUserIdx + 1);
                        Gate.nUserCount++;
                        break;

                    case Common.GM_CLOSE: // 2
                        nCheckCode = 2;
                        CloseUser(GateIdx, MsgHeader.nSocket);
                        break;

                    case Common.GM_CHECKCLIENT:// 4 RunGate��M2��ͨѶ ÿ����RunGate���͵�������
                        nCheckCode = 3;
                        Gate.boSendKeepAlive = true;
                        break;

                    case Common.GM_RECEIVE_OK: // 7
                        nCheckCode = 4;
                        Gate.nSendChecked = 0;
                        Gate.nSendBlockCount = 0;
                        break;

                    case Common.GM_DATA: // 5
                        nCheckCode = 5;
                        GateUser = null;
                        if (MsgHeader.wUserListIndex >= 1)
                        {
                            nUserIdx = MsgHeader.wUserListIndex - 1;
                            if (Gate.UserList.Count > nUserIdx)
                            {
                                GateUser = Gate.UserList[nUserIdx];
                                if ((GateUser != null) && (GateUser.nSocket != MsgHeader.nSocket))
                                {
                                    GateUser = null;
                                }
                            }
                        }
                        if (GateUser == null)
                        {
                            for (int I = 0; I < Gate.UserList.Count; I++)
                            {
                                if (Gate.UserList[I] == null)
                                {
                                    continue;
                                }
                                if (Gate.UserList[I].nSocket == MsgHeader.nSocket)
                                {
                                    GateUser = Gate.UserList[I];
                                    break;
                                }
                            }
                        }
                        nCheckCode = 6;
                        if (GateUser != null)
                        {
                            if ((GateUser.PlayObject != null) && (GateUser.UserEngine != null))
                            {
                                if (GateUser.boCertification && (nMsgLen >= sizeof(TDefaultMessage)))
                                {
                                    DefMsg = (TDefaultMessage*)MsgBuff;
                                    if (nMsgLen == sizeof(TDefaultMessage))
                                    {
                                        UserEngine.ProcessUserMessage(GateUser.PlayObject, DefMsg, null);
                                    }
                                    else
                                    {
                                        UserEngine.ProcessUserMessage(GateUser.PlayObject, DefMsg, MsgBuff + sizeof(TDefaultMessage));
                                    }
                                }
                            }
                            else
                            {
                                if (HUtil32.GetTickCount() - GateUser.dwNewUserTick < 20000) // 1000 * 20 20����û��½�ɹ�������
                                {
                                    DoClientCertification(GateIdx, GateUser, MsgHeader.nSocket, HUtil32.SBytePtrToString((sbyte*)MsgBuff, 0, nMsgLen));
                                }
                                else
                                {
                                    nSocket = GateUser.nSocket;
                                    nGSocketIdx = GateUser.nGSocketIdx;
                                    CloseUser(GateIdx, MsgHeader.nSocket);
                                    SendOutConnectMsg(GateIdx, MsgHeader.nSocket, GateUser.nGSocketIdx);
                                    SendTickUserCon(Gate.Socket, nSocket, (short)nGSocketIdx);// ����Ϣ��Rungate.exe,T����Ӧ������
                                }
                            }
                        }
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode));
            }
        }

        /// <summary>
        /// ����������������(RunGate)
        /// </summary>
        /// <param name="Socket"></param>
        /// <param name="nIdent"></param>
        private unsafe void SendCheck(Socket Socket, short nIdent)
        {
            TMsgHeader MsgHeader;
            if (!Socket.Connected && Socket.Connected)
            {
                return;
            }
            MsgHeader = new TMsgHeader();
            MsgHeader.dwCode = Grobal2.RUNGATECODE;
            MsgHeader.nSocket = 0;
            MsgHeader.wIdent = nIdent;
            MsgHeader.nLength = 0;
            if ((Socket != null) && Socket.Connected)
            {
                byte[] data = new byte[sizeof(TMsgHeader)];
                fixed (byte* pb = data)
                {
                    *(TMsgHeader*)pb = MsgHeader;
                }
                Socket.Send(data, 0, data.Length, SocketFlags.None);
            }
        }

        private void LoadRunAddr()
        {
            string sFileName = ".\\RunAddr.txt";
            if (File.Exists(sFileName))
            {
                m_RunAddrList.LoadFromFile(sFileName);
                M2Share.TrimStringList(m_RunAddrList);
            }
        }

        /// <summary>
        /// ����Ϣ�������б��У�Ȼ�󷢸���Ϸ���ؼ�(RunGate)
        /// </summary>
        /// <param name="GateIdx"></param>
        /// <param name="Buffer"></param>
        /// <returns></returns>
        public bool AddGateBuffer(int GateIdx, byte[] Buffer)
        {
            bool result;
            TGateInfo Gate;
            result = false;
            HUtil32.EnterCriticalSection(m_RunSocketSection);
            try
            {
                if (GateIdx < Grobal2.RUNGATEMAX)
                {
                    Gate = g_GateArr[GateIdx];
                    if ((Gate.BufferList != null) && (Buffer != null))
                    {
                        if (Gate.boUsed && (Gate.Socket != null))
                        {
                            IntPtr Ptr = Marshal.AllocHGlobal(Buffer.Length);
                            Marshal.Copy(Buffer, 0, Ptr, Buffer.Length);
                            Gate.BufferList.Add(Ptr);
                            result = true;
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_RunSocketSection);
            }
            return result;
        }

        /// <summary>
        /// ǿ���û�����
        /// </summary>
        /// <param name="nGateIdx"></param>
        /// <param name="nSocket"></param>
        /// <param name="nGsIdx"></param>
        public unsafe void SendOutConnectMsg(int nGateIdx, int nSocket, int nGsIdx)
        {
            TDefaultMessage DefMsg;
            TMsgHeader MsgHeader = new TMsgHeader();
            int nLen;
            byte[] Buff;
            DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_OUTOFCONNECTION, 0, 0, 0, 0, 0);
            MsgHeader.dwCode = Grobal2.RUNGATECODE;
            MsgHeader.nSocket = nSocket;
            MsgHeader.wGSocketIdx = (short)nGsIdx;
            MsgHeader.wIdent = Common.GM_DATA;
            MsgHeader.nLength = Marshal.SizeOf(typeof(TDefaultMessage));
            nLen = MsgHeader.nLength + Marshal.SizeOf(typeof(TMsgHeader));
            Buff = new byte[nLen + sizeof(int)]; //GetMem(Buff, nLen + sizeof(int));
            fixed (byte* pb = Buff)
            {
                *(int*)pb = nLen;//Move(nLen, Buff, sizeof(int));
                *(TMsgHeader*)(pb + sizeof(int)) = MsgHeader;//Move(MsgHeader, Buff[sizeof(int)], Marshal.SizeOf(typeof(TMsgHeader)));
                *(TDefaultMessage*)(pb + sizeof(int) + sizeof(TMsgHeader)) = DefMsg; //Move(DefMsg, Buff[sizeof(int) + Marshal.SizeOf(typeof(TMsgHeader))], Marshal.SizeOf(typeof(TDefaultMessage)));
            }
            if (!AddGateBuffer(nGateIdx, Buff))
            {
                Dispose(Buff);
            }
        }

        private unsafe void SendScanMsg(TDefaultMessage* DefMsg, string sMsg, int nGateIdx, int nSocket, int nGsIdx)
        {
            TMsgHeader MsgHdr;
            byte[] Buff = null;
            int nSendBytes;
            MsgHdr = new TMsgHeader();
            MsgHdr.dwCode = Grobal2.RUNGATECODE;
            MsgHdr.nSocket = nSocket;
            MsgHdr.wGSocketIdx = (short)nGsIdx;
            MsgHdr.wIdent = Common.GM_DATA;
            MsgHdr.nLength = Marshal.SizeOf(typeof(TDefaultMessage));
            if (DefMsg != null)
            {
                if (sMsg != "")
                {
                    MsgHdr.nLength = sMsg.Length + sizeof(TDefaultMessage) + 1;
                    nSendBytes = MsgHdr.nLength + sizeof(TMsgHeader);
                    Buff = new byte[nSendBytes + sizeof(int)];//GetMem(Buff, nSendBytes + sizeof(int));
                    fixed (byte* pb = Buff)
                    {
                        *(int*)pb = nSendBytes;
                        *(TMsgHeader*)(pb + sizeof(int)) = MsgHdr;
                        *(TDefaultMessage*)(pb + sizeof(int) + sizeof(TMsgHeader)) = *DefMsg;
                        *(char*)(pb + sizeof(TDefaultMessage) + sizeof(TMsgHeader) + sizeof(int) + sMsg.Length + 1) = sMsg[0];//sMsg[1]
                    }
                }
                else
                {
                    MsgHdr.nLength = sizeof(TDefaultMessage);
                    nSendBytes = MsgHdr.nLength + sizeof(TMsgHeader);
                    Buff = new byte[nSendBytes + sizeof(int)];
                    fixed (byte* pb = Buff)
                    {
                        *(int*)pb = nSendBytes;
                        *(TMsgHeader*)(pb + sizeof(int)) = MsgHdr;
                        *(TDefaultMessage*)(pb + sizeof(int) + sizeof(TMsgHeader)) = *DefMsg;
                    }
                }
            }
            else
            {
                if (sMsg != "")
                {
                    MsgHdr.nLength = -(sMsg.Length + 1);
                    nSendBytes = Math.Abs(MsgHdr.nLength) + sizeof(TMsgHeader);
                    Buff = new byte[nSendBytes + sizeof(int)];

                    fixed (byte* pb = Buff)
                    {
                        *(int*)pb = nSendBytes;
                        *(TMsgHeader*)(pb + sizeof(int)) = MsgHdr;
                        *(char*)(pb + sizeof(TMsgHeader) + sizeof(int) + sMsg.Length + 1) = sMsg[1];
                    }

                    //Move(sMsg[1], Buff[sizeof(TMsgHeader) + sizeof(int)], sMsg.Length + 1);
                }
            }
            if (!M2Share.RunSocket.AddGateBuffer(nGateIdx, Buff))
            {
                Dispose(Buff);

                //FreeMem(Buff);
            }
        }

        /// <summary>
        /// ���������û��б�
        /// </summary>
        /// <param name="nGateIdx"></param>
        /// <param name="nSocket"></param>
        /// <param name="PlayObject"></param>
        public void SetGateUserList(int nGateIdx, int nSocket, TPlayObject PlayObject)
        {
            TGateUserInfo GateUserInfo;
            TGateInfo Gate;
            if (nGateIdx > g_GateArr.GetUpperBound(0))
            {
                return;
            }
            Gate = g_GateArr[nGateIdx];
            if (Gate.UserList == null)
            {
                return;
            }
            HUtil32.EnterCriticalSection(m_RunSocketSection);
            try
            {
                for (int I = 0; I < Gate.UserList.Count; I++)
                {
                    GateUserInfo = Gate.UserList[I];
                    if ((GateUserInfo != null))
                    {
                        if ((GateUserInfo.nSocket == nSocket))
                        {
                            GateUserInfo.FrontEngine = null;
                            GateUserInfo.UserEngine = M2Share.UserEngine;
                            GateUserInfo.PlayObject = PlayObject;
                            break;
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(m_RunSocketSection);
            }
        }

        /// <summary>
        /// �߳�Rungate.exe��Ӧ������
        /// </summary>
        /// <param name="nIndex"></param>
        private unsafe void SendGateTestMsg(int nIndex)
        {
            TMsgHeader MsgHdr;
            byte[] Buff;
            int nLen;
            TDefaultMessage DefMsg = new TDefaultMessage();
            MsgHdr = new TMsgHeader();
            MsgHdr.dwCode = Grobal2.RUNGATECODE;
            MsgHdr.nSocket = 0;
            MsgHdr.wIdent = Common.GM_TEST;
            MsgHdr.nLength = 100;
            nLen = MsgHdr.nLength + Marshal.SizeOf(typeof(TMsgHeader));
            Buff = new byte[nLen + sizeof(int)];//GetMem(Buff, nLen + sizeof(int));
            fixed (byte* pb = Buff)
            {
                *(int*)pb = nLen;
                *(TMsgHeader*)(pb + sizeof(int)) = MsgHdr;
                *(TDefaultMessage*)(pb + sizeof(int) + sizeof(TMsgHeader)) = DefMsg;
            }
            if (!AddGateBuffer(nIndex, Buff))
            {
                //FreeMem(Buff);
                Dispose(Buff);
            }
        }

        /// <summary>
        /// �޳��û�
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="nSessionID"></param>
        public void KickUser(string sAccount, int nSessionID)
        {
            int I;
            int II;
            TGateUserInfo GateUserInfo;
            TGateInfo Gate;
            int nCheckCode;
            const string sExceptionMsg = "{�쳣} TRunSocket::KickUser CheckCode: {0}";
            const string sKickUserMsg = "��ǰ��¼�ʺ���������λ�õ�¼�������ѱ�ǿ�����ߣ�����";
            nCheckCode = 0;
            try
            {
                for (I = g_GateArr.GetLowerBound(0); I <= g_GateArr.GetUpperBound(0); I++)
                {
                    Gate = g_GateArr[I];
                    nCheckCode = 1;
                    if (Gate.boUsed && (Gate.Socket != null) && (Gate.UserList != null))
                    {
                        nCheckCode = 2;
                        HUtil32.EnterCriticalSection(m_RunSocketSection);
                        try
                        {
                            nCheckCode = 3;
                            for (II = 0; II < Gate.UserList.Count; II++)
                            {
                                nCheckCode = 4;
                                GateUserInfo = Gate.UserList[II];
                                if (GateUserInfo == null)
                                {
                                    continue;
                                }
                                nCheckCode = 5;
                                if ((GateUserInfo.sAccount == sAccount) || (GateUserInfo.nSessionID == nSessionID))
                                {
                                    nCheckCode = 6;
                                    if (GateUserInfo.FrontEngine != null)
                                    {
                                        nCheckCode = 7;
                                        (GateUserInfo.FrontEngine).DeleteHuman(I, GateUserInfo.nSocket);
                                    }
                                    nCheckCode = 8;
                                    if (GateUserInfo.PlayObject != null)
                                    {
                                        nCheckCode = 9;
                                        (GateUserInfo.PlayObject).SysMsg(sKickUserMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                                        (GateUserInfo.PlayObject).m_boEmergencyClose = true;
                                        (GateUserInfo.PlayObject).m_boSoftClose = true;
                                        (GateUserInfo.PlayObject).m_boPlayOffLine = false;
                                    }
                                    nCheckCode = 10;

                                    Dispose(GateUserInfo);
                                    nCheckCode = 11;
                                    Gate.UserList[II] = null;
                                    nCheckCode = 12;
                                    Gate.nUserCount -= 1;
                                    break;
                                }
                            }
                            nCheckCode = 13;
                        }
                        finally
                        {
                            HUtil32.LeaveCriticalSection(m_RunSocketSection);
                        }
                        nCheckCode = 14;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, nCheckCode));
            }
        }

        /// <summary>
        /// ��ȡ���ص�ַ
        /// </summary>
        /// <param name="sIPaddr"></param>
        /// <returns></returns>
        private string GetGateAddr(string sIPaddr)
        {
            string result;
            int I;
            result = sIPaddr;
            for (I = 0; I < n8; I++)
            {
                if (m_IPaddrArr[I].sIPaddr == sIPaddr)
                {
                    result = m_IPaddrArr[I].dIPaddr;
                    break;
                }
            }
            return result;
        }

        public void Execute()
        {
            Run();
        }

        public void Dispose(object obj)
        {
            GC.KeepAlive(obj);
            GC.ReRegisterForFinalize(obj);
        }
    }
}