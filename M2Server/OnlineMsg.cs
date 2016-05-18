using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace M2Server
{
    public partial class TfrmOnlineMsg: Form
    {
        //public static TfrmOnlineMsg frmOnlineMsg = null;

        //private List<string> StrList = null;
        //private string StrListFile = String.Empty;
        //public TfrmOnlineMsg()
        //{
        //    InitializeComponent();
        //}

        //public void ComboBoxMsgKeyPress(System.Object Sender, System.Windows.Forms.KeyPressEventArgs _e1)
        //{
        //    string Msg;
        //    try {
        //        switch((int)(Key))
        //        {
        //            case 13:
        //                Msg = ComboBoxMsg.Text;
        //                if (Msg.Trim() != "")
        //                {
        //                    if (ComboBoxMsg.Items.Count == 0)
        //                    {
        //                        ComboBoxMsg.Items.Add(Msg);
        //                    }
        //                    ComboBoxMsg.Items.Insert(1, Msg);
        //                    UserEngine.SendBroadCastMsgExt(Msg, TMsgType.t_System);
                            
        //                    MemoMsg.Lines.Add(M2Share.g_Config.sSysMsgPreFix + Msg);
        //                }
        //                ComboBoxMsg.SelectedIndex = 0;
        //                ComboBoxMsg.Text = "";
        //                ButtonAdd.Enabled = false;
        //                break;
        //        }
        //    } finally {
        //    }
        //}

        //public void ComboBoxMsgChange(object sender, EventArgs e)
        //{
        //    try {
        //        if (ComboBoxMsg.Items.Count > 20)
        //        {
                    
        //            ComboBoxMsg.Items.Delete(19);
        //        }
        //        if (ComboBoxMsg.Text.Trim() != "")
        //        {
        //            ButtonAdd.Enabled = true;
        //        }
        //        else
        //        {
        //            ButtonAdd.Enabled = false;
        //        }
        //    } finally {
        //    }
        //}

        //public void StringGridClick(object sender, EventArgs e)
        //{
        //    try {
        //        if (StringGrid.CurrentCell.ColumnNumberx >= 0)
        //        {
        //            ButtonDelete.Enabled = true;
        //        }
        //    } finally {
        //    }
        //}

        //public void FormCreate(object sender, EventArgs e)
        //{
        //    StrListFile = ".\\MsgList.txt";
        //    StrList = new List<string>();
        //    if (File.Exists(StrListFile))
        //    {
                
        //        StrList.LoadFromFile(StrListFile);
                
        //        StringGrid.RowCount = StrList.Count;
                
        //        StringGrid.Cols[0] = StrList;
        //    }
        //    else
        //    {
                
        //        StrList.SaveToFile(StrListFile);
        //    }
        //    MemoMsg.Clear();
        //}

        //public void ButtonAddClick(object sender, EventArgs e)
        //{
        //    string Msg;
        //    try {
        //        Msg = ComboBoxMsg.Text.Trim();
        //        if (Msg != "")
        //        {
        //            StrList.Add(Msg);
        //        }
                
        //        StringGrid.RowCount = StrList.Count;
                
        //        StringGrid.Cols[0] = StrList;
        //        ButtonAdd.Enabled = false;
                
        //        StrList.SaveToFile(StrListFile);
        //    } finally {
        //    }
        //}

        //public void StringGridDblClick(object sender, EventArgs e)
        //{
        //    try {
        //        ComboBoxMsg.Text = StrList[StringGrid.CurrentRowIndex];
        //        ComboBoxMsg.Focus();
        //    } finally {
        //    }
        //}

        //public void ButtonDeleteClick(object sender, EventArgs e)
        //{
        //    try {
                
        //        if (StringGrid.RowCount == 1)
        //        {
        //            ButtonDelete.Enabled = false;
        //            return;
        //        }
        //        StrList.Remove(StringGrid.CurrentRowIndex);
                
        //        StringGrid.RowCount = StrList.Count;
                
        //        StringGrid.Cols[0] = StrList;
                
        //        StrList.SaveToFile(StrListFile);
        //    } finally {
        //    }
        //}

        //public void MemoMsgChange(object sender, EventArgs e)
        //{
        //    try {
                
        //        if (MemoMsg.Lines.Count > 80)
        //        {
                    
        //            MemoMsg.Lines.Clear;
        //        }
        //    } finally {
        //    }
        //}

        //public void ButtonSendClick(object sender, EventArgs e)
        //{
        //    string Msg;
        //    Msg = ComboBoxMsg.Text;
        //    if (Msg.Trim() != "")
        //    {
        //        if (ComboBoxMsg.Items.Count == 0)
        //        {
        //            ComboBoxMsg.Items.Add(Msg);
        //        }
        //        ComboBoxMsg.Items.Insert(1, Msg);
        //        UserEngine.SendBroadCastMsgExt(Msg, TMsgType.t_System);
                
        //        MemoMsg.Lines.Add(M2Share.g_Config.sSysMsgPreFix + Msg);
        //    }
        //    ComboBoxMsg.SelectedIndex = 0;
        //    // ComboBoxMsg.Text := '';//不清空Edit里的内容 20080929

        //}

        //public void Open()
        //{
        //    this.ShowDialog();
        //}

        //// Note: the original parameters are Object Sender, ref bool CanClose
        //public void FormCloseQuery(System.Object Sender, System.ComponentModel.CancelEventArgs _e1)
        //{
            
        //    StrList.Free;
        //    // 20080401

        //}

        //public void FormDestroy(Object Sender)
        //{
        //    Units.OnlineMsg.frmOnlineMsg = null;
        //}

        //// Note: the original parameters are Object Sender, ref TCloseAction Action
        //public void FormClose(object sender, EventArgs e)
        //{
            
        //    Action = caFree;
        //}
    }
}