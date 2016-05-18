using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmViewKernelInfo : Form
    {
        //public static TfrmViewKernelInfo frmViewKernelInfo = null;

        //public TfrmViewKernelInfo()
        //{
        //    InitializeComponent();
        //}

        //public void FormCreate(object sender, EventArgs e)
        //{
        //    const string sNo = "序号";
        //    const string sHandle = "句柄";
        //    const string sThreadID = "线程ID";
        //    const string sRunTime = "运行时间";
        //    const string sRunFlag = "运行状态";
        //    TConfig Config;
        //    TThreadInfo ThreadInfo;
        //    Config = M2Share.g_Config;

        //    GridThread.Cells[0, 0] = sNo;

        //    GridThread.Cells[1, 0] = sHandle;

        //    GridThread.Cells[2, 0] = sThreadID;

        //    GridThread.Cells[3, 0] = sRunTime;

        //    GridThread.Cells[4, 0] = sRunFlag;
        //    ThreadInfo = Config.UserEngineThread;
        //    ThreadInfo.hThreadHandle = 0;
        //    ThreadInfo.dwRunTick = 0;
        //    ThreadInfo.nRunTime = 0;
        //    ThreadInfo.nMaxRunTime = 0;
        //    ThreadInfo.nRunFlag = 0;
        //    ThreadInfo = Config.IDSocketThread;
        //    ThreadInfo.hThreadHandle = 0;
        //    ThreadInfo.dwRunTick = 0;
        //    ThreadInfo.nRunTime = 0;
        //    ThreadInfo.nMaxRunTime = 0;
        //    ThreadInfo.nRunFlag = 0;
        //    ThreadInfo = Config.DBSOcketThread;
        //    ThreadInfo.hThreadHandle = 0;
        //    ThreadInfo.dwRunTick = 0;
        //    ThreadInfo.nRunTime = 0;
        //    ThreadInfo.nMaxRunTime = 0;
        //    ThreadInfo.nRunFlag = 0;
        //}

        //public void Open()
        //{
        //    Timer.Enabled = true;
        //    this.ShowDialog();
        //    Timer.Enabled = false;
        //}

        //public void TimerTimer(object sender, EventArgs e)
        //{
        //    TConfig Config;
        //    TThreadInfo ThreadInfo;
        //    Config = M2Share.g_Config;
        //    EditLoadHumanDBCount.Text = (M2Share.g_Config.nLoadDBCount).ToString();
        //    EditLoadHumanDBErrorCoun.Text = (M2Share.g_Config.nLoadDBErrorCount).ToString();
        //    EditSaveHumanDBCount.Text = (M2Share.g_Config.nSaveDBCount).ToString();
        //    EditHumanDBQueryID.Text = (M2Share.g_Config.nDBQueryID).ToString();
        //    EditItemNumber.Text = (M2Share.g_Config.nItemNumber).ToString();
        //    EditItemNumberEx.Text = (M2Share.g_Config.nItemNumberEx).ToString();
        //    EditWinLotteryCount.Text = (M2Share.g_Config.nWinLotteryCount).ToString();
        //    EditNoWinLotteryCount.Text = (M2Share.g_Config.nNoWinLotteryCount).ToString();
        //    EditWinLotteryLevel1.Text = (M2Share.g_Config.nWinLotteryLevel1).ToString();
        //    EditWinLotteryLevel2.Text = (M2Share.g_Config.nWinLotteryLevel2).ToString();
        //    EditWinLotteryLevel3.Text = (M2Share.g_Config.nWinLotteryLevel3).ToString();
        //    EditWinLotteryLevel4.Text = (M2Share.g_Config.nWinLotteryLevel4).ToString();
        //    EditWinLotteryLevel5.Text = (M2Share.g_Config.nWinLotteryLevel5).ToString();
        //    EditWinLotteryLevel6.Text = (M2Share.g_Config.nWinLotteryLevel6).ToString();
        //    EditGlobalVal1.Text = (M2Share.g_Config.GlobalVal[0]).ToString();
        //    EditGlobalVal2.Text = (M2Share.g_Config.GlobalVal[1]).ToString();
        //    EditGlobalVal3.Text = (M2Share.g_Config.GlobalVal[2]).ToString();
        //    EditGlobalVal4.Text = (M2Share.g_Config.GlobalVal[3]).ToString();
        //    EditGlobalVal5.Text = (M2Share.g_Config.GlobalVal[4]).ToString();
        //    EditGlobalVal6.Text = (M2Share.g_Config.GlobalVal[5]).ToString();
        //    EditGlobalVal7.Text = (M2Share.g_Config.GlobalVal[6]).ToString();
        //    EditGlobalVal8.Text = (M2Share.g_Config.GlobalVal[7]).ToString();
        //    EditGlobalVal9.Text = (M2Share.g_Config.GlobalVal[8]).ToString();
        //    EditGlobalVal10.Text = (M2Share.g_Config.GlobalVal[9]).ToString();

        //    EditAllocMemSize.Text = (AllocMemSize).ToString();

        //    EditAllocMemCount.Text = (AllocMemCount).ToString();
        //    // GridThread.Row:=2;
        //    ThreadInfo = Config.UserEngineThread;
        //    GridThreadAdd(ThreadInfo, 0);
        //    ThreadInfo = Config.IDSocketThread;
        //    GridThreadAdd(ThreadInfo, 1);
        //    ThreadInfo = Config.DBSOcketThread;
        //    GridThreadAdd(ThreadInfo, 2);
        //}

        //private void GridThreadAdd(TThreadInfo ThreadInfo, int Index)
        //{


        //    GridThread.Cells[0, Index + 1] = string.Format("%d", new int[] { Index });


        //    GridThread.Cells[1, Index + 1] = string.Format("%d", new int[] { ThreadInfo.hThreadHandle });


        //    GridThread.Cells[2, Index + 1] = string.Format("%d", new uint[] { ThreadInfo.dwThreadID });



        //    GridThread.Cells[3, Index + 1] = string.Format("%d/%d/%d", new int[] { GetTickCount - ThreadInfo.dwRunTick, ThreadInfo.nRunTime, ThreadInfo.nMaxRunTime });


        //    GridThread.Cells[4, Index + 1] = string.Format("%d", new int[] { ThreadInfo.nRunFlag });
        //}

        //public void FormDestroy(Object Sender)
        //{
        //    Units.ViewKernelInfo.frmViewKernelInfo = null;
        //}

        //public void FormClose(object sender, EventArgs e)
        //{

        //    Action = caFree;
        //}
    }
}
