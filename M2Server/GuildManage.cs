using System;
using System.Windows.Forms;

namespace M2Server
{
    // �л����
    public partial class TfrmGuildManage : Form
    {
        public static TfrmGuildManage frmGuildManage = null;
        public static TGUild CurGuild = null;
        public static bool boRefing = false;

        public TfrmGuildManage()
        {
            InitializeComponent();
        }

        private void RefGuildList()
        {
            TGUild Guild;
            ListViewItem ListItem;
            if (M2Share.g_GuildManager.GuildList.Count > 0)
            {
                for (int I = 0; I < M2Share.g_GuildManager.GuildList.Count; I++)
                {
                    Guild = M2Share.g_GuildManager.GuildList[I];
                    ListItem = new ListViewItem();
                    ListItem.Text = (I).ToString();
                    ListItem.SubItems.Add(Guild.sGuildName);
                    ListViewGuild.Items.Add(ListItem);
                }
            }
        }

        public void Open()
        {
            EditGuildMemberCount.Value = M2Share.g_Config.nGuildMemberCount;
            RefGuildList();
            this.ShowDialog();
        }

        private void RefGuildInfo()
        {
            if (CurGuild == null)
            {
                return;
            }
            boRefing = true;
            EditGuildName.Text = CurGuild.sGuildName;
            EditBuildPoint.Value = CurGuild.nBuildPoint;// ������
            EditAurae.Value = CurGuild.nAurae;// ������
            EditStability.Value = CurGuild.nStability;// ������
            EditFlourishing.Value = CurGuild.nFlourishing;// ���ٶ�
            EditChiefItemCount.Value = CurGuild.nChiefItemCount;// �л���ȡװ������
            EditGuildFountain.Value = CurGuild.m_nGuildFountain;// �л�Ȫˮ�ֿ�
            SpinEditGuildMemberCount.Value = CurGuild.m_nGuildMemberCount;// �л��Ա����
            boRefing = false;
        }

        public void ListViewGuildClick(object sender, EventArgs e)
        {
            ListViewItem ListItem;
            //ListItem = ListViewGuild.Selected;
            //if (ListItem == null)
            //{
            //    return;
            //}
            // CurGuild = ((TGUild)(ListItem.SubItems.Objects[0]));
            RefGuildInfo();
        }

        public void Button1Click(object sender, EventArgs e)
        {
            try
            {
                if (CurGuild == null)
                {
                    return;
                }
                if (EditGuildName.Text != "")
                {
                    if ((CurGuild.sGuildName).ToLower().CompareTo((EditGuildName.Text).ToLower()) == 0)
                    {
                        CurGuild.nBuildPoint = (int)EditBuildPoint.Value;// ������
                        CurGuild.nAurae = (int)EditAurae.Value;// ������
                        CurGuild.nStability = (int)EditStability.Value;// ������
                        CurGuild.nFlourishing = (int)EditFlourishing.Value;// ���ٶ�
                        CurGuild.nChiefItemCount = (int)EditChiefItemCount.Value;// �л���ȡװ������
                        CurGuild.m_nGuildFountain = (int)EditGuildFountain.Value;// �л�Ȫˮ�ֿ�
                        CurGuild.m_nGuildMemberCount = (ushort)SpinEditGuildMemberCount.Value;// �л��Ա����
                        CurGuild.SaveGuildInfoFile();
                    }
                }
                Button1.Enabled = false;
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TfrmGuildManage.Button1Click");
            }
        }

        public void EditBuildPointClick(object sender, EventArgs e)
        {
            Button1.Enabled = true;
        }

        public void EditGuildMemberCountChange(Object Sender)
        {
            M2Share.g_Config.nGuildMemberCount = (ushort)EditGuildMemberCount.Value;
        }

        public void Button2Click(object sender, EventArgs e)
        {
            M2Share.Config.WriteInteger("Setup", "GuildMemberCount", M2Share.g_Config.nGuildMemberCount);// �½��л��Ա����
            Button2.Enabled = false;
        }

        public void EditGuildMemberCountClick(object sender, EventArgs e)
        {
            Button2.Enabled = true;
        }

        private void ListViewGuild_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ListViewGuild.SelectedItems.Count > 0)
            {
                EditGuildName.Text = e.Item.SubItems[1].Text;
            }
        }
    }
}