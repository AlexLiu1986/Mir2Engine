using System;
using System.Windows.Forms;
using System.Collections.Generic;
using GameFramework;

namespace M2Server
{
    public partial class TfrmViewOnlineHuman: Form
    {
        public static TfrmViewOnlineHuman frmViewOnlineHuman = null;
        //// �����ִ�С������ĺ��� 20090131
        //public static int DescCompareInt(List<string> List, int I1, int I2)
        //{
        //    int result;
        //    I1 = Convert.ToInt32(List[I1]);
        //    I2 = Convert.ToInt32(List[I2]);
        //    if (I1 > I2)
        //    {
        //        result = -1;
        //    }
        //    else if (I1 < I2)
        //    {
        //        result = 1;
        //    }
        //    else
        //    {
        //        result = 0;
        //    }
        //    return result;
        //}

        //// �ַ�������
        //public static int StrSort_2(List<string> List, int Index1, int Index2)
        //{
        //    int result;
        //    result = 0;
        //    try
        //    {
        //        result = List[Index1].CompareTo(List[Index2]);
        //    }
        //    catch
        //    {
        //    }
        //    return result;
        //}

        private List<string> ViewList = null;
        private uint dwTimeOutTick = 0;

        public TfrmViewOnlineHuman()
        {
            InitializeComponent();
        }

        public void Open()
        {
            //frmHumanInfo = new TfrmHumanInfo();
            dwTimeOutTick = HUtil32.GetTickCount();
            //GetOnlineList();
            //RefGridSession();
            Timer.Enabled = true;
            this.ShowDialog();
            Timer.Enabled = false;
        }

        // ȡ���������б�
        //private void GetOnlineList()
        //{
        //    int I;
        //    ViewList.Clear();
        //    try {
        //        EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
        //        if (M2Share.UserEngine != null)
        //        {
        //            for (I = 0; I < UserEngine.m_PlayObjectList.Count; I ++ )
        //            {
        //                ViewList.Add(UserEngine.m_PlayObjectList[I], UserEngine.m_PlayObjectList.Values[I]);
        //            }
        //        }
        //    } finally {
        //        LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
        //    }
        //}

        //private void RefGridSession()
        //{
        //    int I;
        //    TPlayObject PlayObject;
        //    PanelStatus.Text = "����ȡ������...";
        //    GridHuman.Visible = false;
        //    GridHuman.Cells[0, 1] = "";
        //    GridHuman.Cells[1, 1] = "";
        //    GridHuman.Cells[2, 1] = "";
        //    GridHuman.Cells[3, 1] = "";
        //    GridHuman.Cells[4, 1] = "";
        //    GridHuman.Cells[5, 1] = "";
        //    GridHuman.Cells[6, 1] = "";
        //    GridHuman.Cells[7, 1] = "";
        //    GridHuman.Cells[8, 1] = "";
        //    GridHuman.Cells[9, 1] = "";
        //    GridHuman.Cells[10, 1] = "";
        //    GridHuman.Cells[11, 1] = "";
        //    GridHuman.Cells[12, 1] = "";
        //    GridHuman.Cells[13, 1] = "";
        //    GridHuman.Cells[14, 1] = "";
        //    GridHuman.Cells[15, 1] = "";
        //    GridHuman.Cells[16, 1] = "";
        //    GridHuman.Cells[17, 1] = "";
        //    GridHuman.Cells[18, 1] = "";
        //    GridHuman.Cells[19, 1] = "";
        //    if (ViewList.Count <= 0)
        //    {
        //        GridHuman.RowCount = 2;
        //        GridHuman.FixedRows = 1;
        //    }
        //    else
        //    {
        //        GridHuman.RowCount = ViewList.Count + 1;
        //    }
        //    for (I = 0; I < ViewList.Count; I ++ )
        //    {
        //        PlayObject = ((TPlayObject)(ViewList.Values[I]));
        //        if (PlayObject != null)
        //        {
        //            GridHuman.Cells[0, I + 1] = (I).ToString();
        //            GridHuman.Cells[1, I + 1] = PlayObject.m_sCharName;
        //            GridHuman.Cells[2, I + 1] = HUtil32.IntToSex(PlayObject.m_btGender);
        //            GridHuman.Cells[3, I + 1] = HUtil32.IntToJob(PlayObject.m_btJob);
        //            GridHuman.Cells[4, I + 1] = (PlayObject.m_Abil.Level).ToString();
        //            GridHuman.Cells[5, I + 1] = (PlayObject.m_NGLevel).ToString();
        //            // �ڹ��ȼ�
        //            GridHuman.Cells[6, I + 1] = PlayObject.m_sMapName;
        //            GridHuman.Cells[7, I + 1] = (PlayObject.m_nCurrX).ToString() + ":" + (PlayObject.m_nCurrY).ToString();
        //            GridHuman.Cells[8, I + 1] = PlayObject.m_sUserID;
        //            GridHuman.Cells[9, I + 1] = PlayObject.m_sIPaddr;
        //            GridHuman.Cells[10, I + 1] = (PlayObject.m_btPermission).ToString();
        //            GridHuman.Cells[11, I + 1] = PlayObject.m_sIPLocal;
        //            // GetIPLocal(PlayObject.m_sIPaddr);
                    
        //            GridHuman.Cells[12, I + 1] = (PlayObject.m_nGameGold).ToString();
                    
        //            GridHuman.Cells[13, I + 1] = (PlayObject.m_nGamePoint).ToString();
                    
        //            GridHuman.Cells[14, I + 1] = (PlayObject.m_nPayMentPoint).ToString();
                    
        //            GridHuman.Cells[15, I + 1] = HUtil32.BooleanToStr(PlayObject.m_boNotOnlineAddExp);
                    
        //            GridHuman.Cells[16, I + 1] = PlayObject.m_sAutoSendMsg;
                    
        //            GridHuman.Cells[17, I + 1] = (PlayObject.MessageCount()).ToString();
                    
        //            GridHuman.Cells[18, I + 1] = (PlayObject.m_nGAMEDIAMOND).ToString();
                    
        //            GridHuman.Cells[19, I + 1] = (PlayObject.m_nGAMEGIRD).ToString();
        //        }
        //    }
        //    GridHuman.Visible = true;
        //}

        //public void FormCreate(object sender, EventArgs e)
        //{
        //    ViewList = new List<string>();
        //    GridHuman.Cells[0, 0] = "���";
        //    GridHuman.Cells[1, 0] = "��������";
        //    GridHuman.Cells[2, 0] = "�Ա�";
        //    GridHuman.Cells[3, 0] = "ְҵ";
        //    GridHuman.Cells[4, 0] = "�ȼ�";
        //    GridHuman.Cells[5, 0] = "�ڹ��ȼ�";
        //    GridHuman.Cells[6, 0] = "��ͼ";
        //    GridHuman.Cells[7, 0] = "����";
        //    GridHuman.Cells[8, 0] = "��¼�ʺ�";
        //    GridHuman.Cells[9, 0] = "��¼IP";
        //    GridHuman.Cells[10, 0] = "Ȩ��";
        //    GridHuman.Cells[11, 0] = "���ڵ���";
        //    GridHuman.Cells[12, 0] = M2Share.g_Config.sGameGoldName;
        //    GridHuman.Cells[13, 0] = M2Share.g_Config.sGamePointName;
        //    GridHuman.Cells[14, 0] = M2Share.g_Config.sPayMentPointName;
        //    GridHuman.Cells[15, 0] = "���߹һ�";
        //    GridHuman.Cells[16, 0] = "�Զ��ظ�";
        //    GridHuman.Cells[17, 0] = "δ������Ϣ";
        //    GridHuman.Cells[18, 0] = M2Share.g_Config.sGameDiaMond;
        //    GridHuman.Cells[19, 0] = M2Share.g_Config.sGameGird;
        //    if (M2Share.UserEngine != null)
        //    {
        //        this.Text = string.Format(" [����������%d]", new int[] {UserEngine.PlayObjectCount});
        //    }
        //}

        //public void ButtonRefGridClick(object sender, EventArgs e)
        //{
            
        //    dwTimeOutTick = GetTickCount();
        //    GetOnlineList();
        //    RefGridSession();
        //}

        //public void FormDestroy(Object Sender)
        //{
            
        //    ViewList.Free;
        //    Units.ViewOnlineHuman.frmViewOnlineHuman = null;
        //}

        //public void ComboBoxSortClick(object sender, EventArgs e)
        //{
        //    if (ComboBoxSort.SelectedIndex < 0)
        //    {
        //        return;
        //    }
            
        //    dwTimeOutTick = GetTickCount();
        //    GetOnlineList();
        //    SortOnlineList(ComboBoxSort.SelectedIndex);
        //    RefGridSession();
        //}

        //private void SortOnlineList(int nSort)
        //{
        //    int I;
        //    List<string> SortList;
        //    if ((ViewList == null) || (ViewList.Count == 0))
        //    {
        //        return;
        //    }
        //    // 20080503
        //    SortList = new List<string>();
        //    try {
        //        switch(nSort)
        //        {
        //            case 0:
        //                ViewList.Sort();
        //                return;
        //                break;
        //            case 1:
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add((((TPlayObject)(ViewList.Values[I])).m_btGender).ToString(), ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.DescCompareInt);
        //                break;
        //            case 2:
        //                // ����ʱ�����Ǹ����� 20081023 OK
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add((((TPlayObject)(ViewList.Values[I])).m_btJob).ToString(), ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.DescCompareInt);
        //                break;
        //            case 3:
        //                // ����ʱ�����Ǹ����� 20081023 OK
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add((((TPlayObject)(ViewList.Values[I])).m_Abil.Level).ToString(), ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.DescCompareInt);
        //                break;
        //            case 4:
        //                // ����ʱ�����Ǹ����� 20081005 OK
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add(((TPlayObject)(ViewList.Values[I])).m_sMapName, ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.StrSort_2);
        //                break;
        //            case 5:
        //                // �������� 20081024
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add(((TPlayObject)(ViewList.Values[I])).m_sIPaddr, ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.StrSort_2);
        //                break;
        //            case 6:
        //                // �������� 20081024
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add((((TPlayObject)(ViewList.Values[I])).m_btPermission).ToString(), ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.DescCompareInt);
        //                break;
        //            case 7:
        //                // ����ʱ�����Ǹ����� 20081005
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add(((TPlayObject)(ViewList.Values[I])).m_sIPLocal, ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.StrSort_2);
        //                break;
        //            case 8:
        //                // �������� 20081024
        //                // �ǹһ� 20080811
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
        //                    if (!((TPlayObject)(ViewList.Values[I])).m_boNotOnlineAddExp)
        //                    {
                                
        //                        SortList.Add((I).ToString(), ViewList.Values[I]);
        //                    }
        //                }
        //                break;
        //            case 9:
        //                // 8
        //                // Ԫ��
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add((((TPlayObject)(ViewList.Values[I])).m_nGameGold).ToString(), ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.DescCompareInt);
        //                break;
        //            case 10:
        //                // ����ʱ�����Ǹ����� 20080928
        //                // 9
        //                // �ڹ��ȼ�
        //                for (I = 0; I < ViewList.Count; I ++ )
        //                {
                            
                            
        //                    SortList.Add((((TPlayObject)(ViewList.Values[I])).m_NGLevel).ToString(), ViewList.Values[I]);
        //                }
                        
        //                SortList.CustomSort(Units.ViewOnlineHuman.DescCompareInt);
        //                break;
        //        // ����ʱ�����Ǹ�����
        //        // 10
        //        }
        //        // ViewList.Free;
        //        // ViewList := SortList; //20080503 �޸ĳ���������
        //        ViewList.Clear();
        //        for (I = 0; I < SortList.Count; I ++ )
        //        {
                    
        //            ViewList.Add((I).ToString(), SortList.Values[I]);
        //        }
        //        ViewList.Sort();
        //    } finally {
                
        //        SortList.Free;
        //    // 20080117
        //    }
        //}

        //public void GridHumanDblClick(object sender, EventArgs e)
        //{
        //    ShowHumanInfo();
        //}

        //public void TimerTimer(object sender, EventArgs e)
        //{
            
        //    if ((GetTickCount - dwTimeOutTick > 30000) && (ViewList.Count > 0))
        //    {
        //        ViewList.Clear();
        //        RefGridSession();
        //    }
        //}

        //public void ButtonSearchClick(object sender, EventArgs e)
        //{
        //    int I;
        //    string sHumanName;
        //    TPlayObject PlayObject;
        //    sHumanName = EditSearchName.Text.Trim();
        //    if (sHumanName == "")
        //    {
        //        System.Windows.Forms.MessageBox.Show("������һ���������ƣ�����", "������Ϣ", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Exclamation);
        //        return;
        //    }
        //    if (Sender == ButtonSearch)
        //    {
        //        for (I = 0; I < ViewList.Count; I ++ )
        //        {
                    
        //            PlayObject = ((TPlayObject)(ViewList.Values[I]));
        //            if ((PlayObject.m_sCharName).ToLower().CompareTo((sHumanName).ToLower()) == 0)
        //            {
        //                GridHuman.CurrentRowIndex = I + 1;
        //                return;
        //            }
        //        }
        //        System.Windows.Forms.MessageBox.Show("����û�����ߣ�����", "��ʾ��Ϣ", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Information);
        //        return;
        //    }
        //    if (Sender == ButtonKick)
        //    {
        //        for (I = 0; I < ViewList.Count; I ++ )
        //        {
                    
        //            PlayObject = ((TPlayObject)(ViewList.Values[I]));
        //            if ((PlayObject.m_sCharName.IndexOf(sHumanName) != -1))
        //            {
        //                PlayObject.m_boEmergencyClose = true;
        //                PlayObject.m_boNotOnlineAddExp = false;
        //                PlayObject.m_boPlayOffLine = false;
        //            }
        //        }
                
        //        dwTimeOutTick = GetTickCount();
        //        GetOnlineList();
        //        RefGridSession();
        //    }
        //}

        //public void ButtonViewClick(object sender, EventArgs e)
        //{
        //    ShowHumanInfo();
        //}

        //// ���������б�
        //private void ShowHumanInfo()
        //{
        //    int nSelIndex;
        //    string sPlayObjectName;
        //    TPlayObject PlayObject;
        //    nSelIndex = GridHuman.CurrentRowIndex;
        //    nSelIndex -= 1;
        //    if ((nSelIndex < 0) || (ViewList.Count <= nSelIndex))
        //    {
        //        System.Windows.Forms.MessageBox.Show("����ѡ��һ��Ҫ�鿴���������", "��ʾ��Ϣ", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Information);
        //        return;
        //    }
            
        //    sPlayObjectName = GridHuman.Cells[1, nSelIndex + 1];
        //    PlayObject = UserEngine.GetPlayObject(sPlayObjectName);
        //    if (PlayObject == null)
        //    {
        //        System.Windows.Forms.MessageBox.Show("�������Ѿ������ߣ�����", "��ʾ��Ϣ", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Information);
        //        return;
        //    }
            
        //    HumanInfo.Units.HumanInfo.frmHumanInfo.PlayObject = ((TPlayObject)(ViewList.Values[nSelIndex]));
        //    HumanInfo.Units.HumanInfo.frmHumanInfo.Top = this.Top + 20;
        //    HumanInfo.Units.HumanInfo.frmHumanInfo.Left = this.Left;
        //    HumanInfo.Units.HumanInfo.frmHumanInfo.Open();
        //}

        //public void Button1Click(object sender, EventArgs e)
        //{
        //    int I;
        //    try {
                
        //        EnterCriticalSection(M2Share.ProcessHumanCriticalSection);
        //        for (I = 0; I < UserEngine.m_PlayObjectList.Count; I ++ )
        //        {
                    
        //            if (((TPlayObject)(UserEngine.m_PlayObjectList.Values[I])).m_boNotOnlineAddExp)
        //            {
                        
        //                ((TPlayObject)(UserEngine.m_PlayObjectList.Values[I])).m_boNotOnlineAddExp = false;
                        
        //                ((TPlayObject)(UserEngine.m_PlayObjectList.Values[I])).m_boPlayOffLine = false;
                        
        //                ((TPlayObject)(UserEngine.m_PlayObjectList.Values[I])).m_boKickFlag = true;
        //            // 20080815 ����
        //            }
        //        }
        //    } finally {
                
        //        LeaveCriticalSection(M2Share.ProcessHumanCriticalSection);
        //    }
            
        //    dwTimeOutTick = GetTickCount();
        //    GetOnlineList();
        //    RefGridSession();
        //}

        //// Note: the original parameters are Object Sender, ref TCloseAction Action
        //public void FormClose(object sender, EventArgs e)
        //{
            
        //    Action = caFree;
        //}
    } 
}

