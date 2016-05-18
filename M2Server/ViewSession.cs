using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmViewSession: Form
    {
        public static TfrmViewSession frmViewSession = null;
        //public TfrmViewSession()
        //{
        //    InitializeComponent();
        //}

        //public void FormCreate(object sender, EventArgs e)
        //{
            
        //    GridSession.Cells[0, 0] = "序号";
            
        //    GridSession.Cells[1, 0] = "登录帐号";
            
        //    GridSession.Cells[2, 0] = "登录地址";
            
        //    GridSession.Cells[3, 0] = "会话ID号";
            
        //    GridSession.Cells[4, 0] = "充值";
            
        //    GridSession.Cells[5, 0] = "充值模式";
        //}

        //public void Open()
        //{
        //    RefGridSession();
        //    this.ShowDialog();
        //}

        //private void RefGridSession()
        //{
        //    int I;
        //    TSessInfo SessInfo;
        //    PanelStatus.Text = "正在取得数据...";
        //    GridSession.Visible = false;
            
        //    GridSession.Cells[0, 1] = "";
            
        //    GridSession.Cells[1, 1] = "";
            
        //    GridSession.Cells[2, 1] = "";
            
        //    GridSession.Cells[3, 1] = "";
            
        //    GridSession.Cells[4, 1] = "";
            
        //    GridSession.Cells[5, 1] = "";
        //    IdSrvClient.Units.IdSrvClient.FrmIDSoc.m_SessionList.__Lock();
        //    try {
        //        if (IdSrvClient.Units.IdSrvClient.FrmIDSoc.m_SessionList.Count <= 0)
        //        {
                    
        //            GridSession.RowCount = 2;
                    
        //            GridSession.FixedRows = 1;
        //        }
        //        else
        //        {
                    
        //            GridSession.RowCount = IdSrvClient.Units.IdSrvClient.FrmIDSoc.m_SessionList.Count + 1;
        //        }
        //        for (I = 0; I < IdSrvClient.Units.IdSrvClient.FrmIDSoc.m_SessionList.Count; I ++ )
        //        {
        //            SessInfo = IdSrvClient.Units.IdSrvClient.FrmIDSoc.m_SessionList[I];
                    
        //            GridSession.Cells[0, I + 1] = (I).ToString();
                    
        //            GridSession.Cells[1, I + 1] = SessInfo.sAccount;
                    
        //            GridSession.Cells[2, I + 1] = SessInfo.sIPaddr;
                    
        //            GridSession.Cells[3, I + 1] = (SessInfo.nSessionID).ToString();
                    
        //            GridSession.Cells[4, I + 1] = (SessInfo.nPayMent).ToString();
                    
        //            GridSession.Cells[5, I + 1] = (SessInfo.nPayMode).ToString();
        //        }
        //    } finally {
        //        IdSrvClient.Units.IdSrvClient.FrmIDSoc.m_SessionList.UnLock();
        //    }
        //    GridSession.Visible = true;
        //}

        //public void ButtonRefGridClick(object sender, EventArgs e)
        //{
        //    RefGridSession();
        //}

        //// Note: the original parameters are Object Sender, ref TCloseAction Action
        //public void FormClose(object sender, EventArgs e)
        //{
            
        //    Action = caFree;
        //}

        //public void FormDestroy(Object Sender)
        //{
        //    Units.ViewSession.frmViewSession = null;
        //}
    } 
}

