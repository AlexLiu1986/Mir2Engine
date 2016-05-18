namespace M2Server
{
  partial class TfrmViewOnlineHuman
    {
        public System.Windows.Forms.Panel PanelStatus;
        public System.Windows.Forms.DataGrid GridHuman;
        public System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Button ButtonRefGrid;
        public System.Windows.Forms.ComboBox ComboBoxSort;
        public System.Windows.Forms.TextBox EditSearchName;
        public System.Windows.Forms.Button ButtonSearch;
        public System.Windows.Forms.Button ButtonView;
        public System.Windows.Forms.Button Button1;
        public System.Windows.Forms.Button ButtonKick;
        public System.Windows.Forms.Timer Timer;
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
            this.PanelStatus = new System.Windows.Forms.Panel();
            this.GridHuman = new System.Windows.Forms.DataGrid();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.ButtonRefGrid = new System.Windows.Forms.Button();
            this.ComboBoxSort = new System.Windows.Forms.ComboBox();
            this.EditSearchName = new System.Windows.Forms.TextBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonView = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.ButtonKick = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(235, 281);
            this.ClientSize  = new System.Drawing.Size(826, 452);
            this.Font  = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(134)));
            //this.Load += new System.EventHandler(this.FormCreate);
            //this.Closed += new System.EventHandler(this.FormClose);
            this.AutoScroll = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmViewOnlineHuman";
            this.Text = "在线人物";
            //this.BackColor = clBtnFace;
            this.PanelStatus.Size  = new System.Drawing.Size(818, 362);
            this.PanelStatus.Location  = new System.Drawing.Point(0, 0);
            this.PanelStatus.SuspendLayout();
            this.PanelStatus.TabIndex = 0;
            this.PanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelStatus.Name = "PanelStatus";
            this.PanelStatus.Enabled = true;
            this.PanelStatus.Text = "正在读取数据...";
            //this.PanelStatus.BackColor = clBtnFace;
            ((System.ComponentModel.ISupportInitialize)(this.GridHuman)).BeginInit();
            this.GridHuman.Size  = new System.Drawing.Size(816, 360);
            this.GridHuman.Location  = new System.Drawing.Point(1, 1);
           // this.GridHuman.DoubleClick += new System.EventHandler(this.GridHumanDblClick);
            this.GridHuman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridHuman.Name = "GridHuman";
            this.GridHuman.Enabled = true;
            //this.GridHuman.PreferredColumnWidth = (int){33, 78, 29, 31, 39, 53, 37, 56, 89, 104, 31, 159, 55, 57, 64, 51, 158, 61, 39, 42};
            this.GridHuman.TabIndex = 0;
            this.Panel1.Size  = new System.Drawing.Size(818, 56);
            this.Panel1.Location  = new System.Drawing.Point(0, 362);
            this.Panel1.SuspendLayout();
            //this.Panel1.BackColor = clBtnFace;
            this.Panel1.TabIndex = 1;
            this.Panel1.Enabled = true;
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Name = "Panel1";
            this.Label1.Size  = new System.Drawing.Size(30, 12);
            this.Label1.Location  = new System.Drawing.Point(104, 20);
            this.Label1.Text = "排序:";
            this.Label1.Enabled = true;
            this.Label1.Name = "Label1";
            this.ButtonRefGrid.Size  = new System.Drawing.Size(73, 25);
            this.ButtonRefGrid.Location  = new System.Drawing.Point(8, 15);
           // this.ButtonRefGrid.Click += new System.EventHandler(this.ButtonRefGridClick);
            this.ButtonRefGrid.TabIndex = 0;
            this.ButtonRefGrid.Name = "ButtonRefGrid";
            this.ButtonRefGrid.Enabled = true;
            this.ButtonRefGrid.Text = "刷新(&R)";
           // this.ButtonRefGrid.BackColor = clBtnFace;
            this.ComboBoxSort.Size  = new System.Drawing.Size(113, 20);
            this.ComboBoxSort.Location  = new System.Drawing.Point(144, 20);
            this.ComboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           // this.ComboBoxSort.Click += new System.EventHandler(this.ComboBoxSortClick);
            this.ComboBoxSort.ItemHeight = 12;
            this.ComboBoxSort.TabIndex = 1;
            this.ComboBoxSort.Items.AddRange(new object[] { 
                "名称",
                "性别",
                "职业",
                "等级",
                "地图",
                "ＩＰ",
                "权限",
                "所在地区",
                "非挂机",
                "元宝",
                "内功等级"
                });
            this.ComboBoxSort.Name = "ComboBoxSort";
            this.ComboBoxSort.Enabled = true;
            this.EditSearchName.Size  = new System.Drawing.Size(129, 20);
            this.EditSearchName.Location  = new System.Drawing.Point(272, 20);
            this.EditSearchName.TabIndex = 2;
            this.EditSearchName.Enabled = true;
            this.EditSearchName.Name = "EditSearchName";
            this.ButtonSearch.Size  = new System.Drawing.Size(73, 25);
            this.ButtonSearch.Location  = new System.Drawing.Point(416, 15);
            //this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
            this.ButtonSearch.TabIndex = 3;
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Enabled = true;
            this.ButtonSearch.Text = "搜索(&S)";
            //this.ButtonSearch.BackColor = clBtnFace;
            this.ButtonView.Size  = new System.Drawing.Size(81, 25);
            this.ButtonView.Location  = new System.Drawing.Point(576, 15);
            //this.ButtonView.Click += new System.EventHandler(this.ButtonViewClick);
            this.ButtonView.TabIndex = 4;
            this.ButtonView.Name = "ButtonView";
            this.ButtonView.Enabled = true;
            this.ButtonView.Text = "人物信息(&H)";
            //this.ButtonView.BackColor = clBtnFace;
            this.Button1.Size  = new System.Drawing.Size(137, 25);
            this.Button1.Location  = new System.Drawing.Point(663, 16);
           // this.Button1.Click += new System.EventHandler(this.Button1Click);
            this.Button1.TabIndex = 5;
            this.Button1.Name = "Button1";
            this.Button1.Enabled = true;
            this.Button1.Text = "踢除离线挂机人物(&K)";
           // this.Button1.BackColor = clBtnFace;
            this.ButtonKick.Size  = new System.Drawing.Size(73, 25);
            this.ButtonKick.Location  = new System.Drawing.Point(495, 15);
            //this.ButtonKick.Click += new System.EventHandler(this.ButtonSearchClick);
            this.ButtonKick.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonKick.TabIndex = 6;
            this.ButtonKick.Name = "ButtonKick";
            this.ButtonKick.Enabled = true;
            this.ButtonKick.Text = "踢下线(&K)";
            //this.ButtonKick.BackColor = clBtnFace;
            //this.Timer.Tick += new System.EventHandler(this.TimerTimer);
            this.Timer.Enabled = false;
            this.PanelStatus.Controls.Add(GridHuman);
            ((System.ComponentModel.ISupportInitialize)(this.GridHuman)).EndInit();
            this.PanelStatus.ResumeLayout(false);
            this.Panel1.Controls.Add(Label1);
            this.Panel1.Controls.Add(ButtonRefGrid);
            this.Panel1.Controls.Add(ComboBoxSort);
            this.Panel1.Controls.Add(EditSearchName);
            this.Panel1.Controls.Add(ButtonSearch);
            this.Panel1.Controls.Add(ButtonView);
            this.Panel1.Controls.Add(Button1);
            this.Panel1.Controls.Add(ButtonKick);
            this.Panel1.ResumeLayout(false);
            this.Controls.Add(PanelStatus);
            this.Controls.Add(Panel1);
            this.ResumeLayout(false);
        }
#endregion

    }
}
