namespace M2Server
{
  partial class TfrmViewLevel
    {
        public System.Windows.Forms.GroupBox GroupBox10;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.NumericUpDown EditHumanLevel;
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox ComboBoxJob;
        public System.Windows.Forms.DataGrid GridHumanInfo;
        public System.Windows.Forms.Button ButtonClose;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(this.GetType());
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.EditHumanLevel = new System.Windows.Forms.NumericUpDown();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboBoxJob = new System.Windows.Forms.ComboBox();
            this.GridHumanInfo = new System.Windows.Forms.DataGrid();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(770, 208);
            this.ClientSize  = new System.Drawing.Size(318, 313);
            this.Font  = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(134)));
            this.Load += new System.EventHandler(this.FormCreate);
            this.AutoScroll = true;
            this.Closed += new System.EventHandler(this.FormClose);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "frmViewLevel";
            this.Text = "人物等级属性";
            //this.BackColor = clBtnFace;
            this.GroupBox10.Size  = new System.Drawing.Size(121, 49);
            this.GroupBox10.Location  = new System.Drawing.Point(8, 8);
            this.GroupBox10.SuspendLayout();
            this.GroupBox10.Text = "人物等级";
            this.GroupBox10.TabIndex = 0;
            this.GroupBox10.Enabled = true;
            this.GroupBox10.Name = "GroupBox10";
            this.Label4.Size  = new System.Drawing.Size(30, 12);
            this.Label4.Location  = new System.Drawing.Point(8, 20);
            this.Label4.Text = "等级:";
            this.Label4.Enabled = true;
            this.Label4.Name = "Label4";
            ((System.ComponentModel.ISupportInitialize)(this.EditHumanLevel)).BeginInit();
            this.EditHumanLevel.Size  = new System.Drawing.Size(45, 21);
            this.EditHumanLevel.Location  = new System.Drawing.Point(44, 15);
            this.EditHumanLevel.Value = 1;
            this.EditHumanLevel.TabIndex = 0;
            this.EditHumanLevel.Name = "EditHumanLevel";
            this.EditHumanLevel.Enabled = true;
            this.GroupBox1.Size  = new System.Drawing.Size(121, 49);
            this.GroupBox1.Location  = new System.Drawing.Point(8, 64);
            this.GroupBox1.SuspendLayout();
            this.GroupBox1.Text = "人物职业";
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.Enabled = true;
            this.GroupBox1.Name = "GroupBox1";
            this.Label1.Size  = new System.Drawing.Size(30, 12);
            this.Label1.Location  = new System.Drawing.Point(8, 20);
            this.Label1.Text = "职业:";
            this.Label1.Enabled = true;
            this.Label1.Name = "Label1";
            this.ComboBoxJob.Size  = new System.Drawing.Size(73, 20);
            this.ComboBoxJob.Location  = new System.Drawing.Point(40, 16);
            this.ComboBoxJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxJob.Items.AddRange(new object[] { 
                "武士",
                "魔法师",
                "道士"
                });
            this.ComboBoxJob.ItemHeight = 12;
            this.ComboBoxJob.TabIndex = 0;
            this.ComboBoxJob.SelectedIndexChanged += new System.EventHandler(this.ComboBoxJobChange);
            this.ComboBoxJob.Name = "ComboBoxJob";
            this.ComboBoxJob.Enabled = true;
            this.ComboBoxJob.SelectedIndex = 0;
            this.ComboBoxJob.Text = "武士";
            ((System.ComponentModel.ISupportInitialize)(this.GridHumanInfo)).BeginInit();
            this.GridHumanInfo.Size  = new System.Drawing.Size(169, 257);
            this.GridHumanInfo.Location  = new System.Drawing.Point(136, 8);
            this.GridHumanInfo.Name = "GridHumanInfo";
            this.GridHumanInfo.Enabled = true;
            //this.GridHumanInfo.PreferredColumnWidth = (int){64, 99};
            this.GridHumanInfo.TabIndex = 2;
            this.ButtonClose.Size  = new System.Drawing.Size(65, 25);
            this.ButtonClose.Location  = new System.Drawing.Point(32, 152);
            this.ButtonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Enabled = true;
            this.ButtonClose.Text = "关闭(&C)";
           // this.ButtonClose.BackColor = clBtnFace;
            this.GroupBox10.Controls.Add(Label4);
            this.GroupBox10.Controls.Add(EditHumanLevel);
            ((System.ComponentModel.ISupportInitialize)(this.EditHumanLevel)).EndInit();
            this.GroupBox10.ResumeLayout(false);
            this.GroupBox1.Controls.Add(Label1);
            this.GroupBox1.Controls.Add(ComboBoxJob);
            this.GroupBox1.ResumeLayout(false);
            this.Controls.Add(GroupBox10);
            this.Controls.Add(GroupBox1);
            this.Controls.Add(GridHumanInfo);
            this.Controls.Add(ButtonClose);
            ((System.ComponentModel.ISupportInitialize)(this.GridHumanInfo)).EndInit();
            this.ResumeLayout(false);
        }
#endregion

    }
}
