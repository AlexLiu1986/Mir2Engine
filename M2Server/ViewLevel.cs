using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmViewLevel : Form
    {
        private TPlayObject PlayObject = null;
        public static TfrmViewLevel frmViewLevel = null;
        public TfrmViewLevel()
        {
            InitializeComponent();
        }

        // TfrmLevel
        public  void Open()
        {
            PlayObject = new TPlayObject();
            PlayObject.m_Abil.Level = 1;
            PlayObject.m_btJob = 0;
            PlayObject.m_sMapName = "0";
            PlayObject.m_PEnvir = M2Share.g_MapManager.FindMap("0");
            PlayObject.m_nCurrX = 330;
            PlayObject.m_nCurrY = 266;
            EditHumanLevel.Value = 1;
            ComboBoxJob.SelectedIndex = 0;
            RefView();
            this.ShowDialog();
            //PlayObject.Free;
        }

        public void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormCreate(object sender, EventArgs e)
        {

            //GridHumanInfo.Cells[0, 0] = "属性";

            //GridHumanInfo.Cells[1, 0] = "数值";

            //GridHumanInfo.Cells[0, 1] = "经验值";

            //GridHumanInfo.Cells[0, 2] = "防御";

            //GridHumanInfo.Cells[0, 3] = "魔防";

            //GridHumanInfo.Cells[0, 4] = "攻击力";

            //GridHumanInfo.Cells[0, 5] = "魔法";

            //GridHumanInfo.Cells[0, 6] = "道术";

            //GridHumanInfo.Cells[0, 7] = "生命值";

            //GridHumanInfo.Cells[0, 8] = "魔法值";

            //GridHumanInfo.Cells[0, 9] = "背包";

            //GridHumanInfo.Cells[0, 10] = "负重";

            //GridHumanInfo.Cells[0, 11] = "腕力";
        }

        private void RecalcHuman()
        {
            PlayObject.RecalcLevelAbilitys();
            PlayObject.RecalcAbilitys();
            PlayObject.CompareSuitItem(false);
            // 套装与身上装备对比 20080729
            PlayObject.HasLevelUp(0);
        }

        private void RefView()
        {
            RecalcHuman();

            //GridHumanInfo.Cells[1, 1] = (PlayObject.m_Abil.MaxExp).ToString();



            //GridHumanInfo.Cells[1, 2] = (LoWord(PlayObject.m_WAbil.AC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.AC)).ToString();



            //GridHumanInfo.Cells[1, 3] = (LoWord(PlayObject.m_WAbil.MAC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.MAC)).ToString();



            //GridHumanInfo.Cells[1, 4] = (LoWord(PlayObject.m_WAbil.DC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.DC)).ToString();



            //GridHumanInfo.Cells[1, 5] = (LoWord(PlayObject.m_WAbil.MC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.MC)).ToString();



            //GridHumanInfo.Cells[1, 6] = (LoWord(PlayObject.m_WAbil.SC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.SC)).ToString();

            //GridHumanInfo.Cells[1, 7] = (PlayObject.m_WAbil.HP).ToString() + "/" + (PlayObject.m_WAbil.MaxHP).ToString();

            //GridHumanInfo.Cells[1, 8] = (PlayObject.m_WAbil.MP).ToString() + "/" + (PlayObject.m_WAbil.MaxMP).ToString();

            //GridHumanInfo.Cells[1, 9] = (PlayObject.m_WAbil.Weight).ToString() + "/" + (PlayObject.m_WAbil.MaxWeight).ToString();

            //GridHumanInfo.Cells[1, 10] = (PlayObject.m_WAbil.WearWeight).ToString() + "/" + (PlayObject.m_WAbil.MaxWearWeight).ToString();

            //GridHumanInfo.Cells[1, 11] = (PlayObject.m_WAbil.HandWeight).ToString() + "/" + (PlayObject.m_WAbil.MaxHandWeight).ToString();
        }

        public void EditHumanLevelChange(Object Sender)
        {
            if (EditHumanLevel.Value < 1)
            {
                EditHumanLevel.Value = 1;
            }
           // PlayObject.m_Abil.Level = EditHumanLevel.Value;
            RefView();
        }

        public void ComboBoxJobChange(object sender, EventArgs e)
        {
           // PlayObject.m_btJob = ComboBoxJob.SelectedIndex;
            RefView();
        }

        public void FormDestroy(Object Sender)
        {
           // Units.ViewLevel.frmViewLevel = null;
        }

        // Note: the original parameters are Object Sender, ref TCloseAction Action
        public void FormClose(object sender, EventArgs e)
        {
           // Action = caFree;
        }
    }
}