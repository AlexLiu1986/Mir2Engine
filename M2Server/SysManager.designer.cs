namespace M2Server
{
  partial class TfrmSysManager
    {
        public System.Windows.Forms.Panel PanelStatus;
        public System.Windows.Forms.ListView ListView;
        public System.Windows.Forms.ColumnHeader _column_48;
        public System.Windows.Forms.ColumnHeader _column_49;
        public System.Windows.Forms.ColumnHeader _column_50;
        public System.Windows.Forms.ColumnHeader _column_51;
        public System.Windows.Forms.ColumnHeader _column_52;
        public System.Windows.Forms.ColumnHeader _column_53;
        public System.Windows.Forms.ColumnHeader _column_55;
        public System.Windows.Forms.ColumnHeader _column_56;
        public System.Windows.Forms.ContextMenu PopupMenu;
        public System.Windows.Forms.MenuItem PopupMenu_Ref;
        public System.Windows.Forms.MenuItem PopupMenu_AutoRef;
        public System.Windows.Forms.MenuItem PopupMenu__;
        public System.Windows.Forms.MenuItem PopupMenu_MonGen;
        public System.Windows.Forms.MenuItem PopupMenu_RunHum;
        public System.Windows.Forms.MenuItem PopupMenu_RunMon;
        public System.Windows.Forms.MenuItem PopupMenu_Horser;
        public System.Windows.Forms.MenuItem PopupMenu_;
        public System.Windows.Forms.MenuItem PopupMenu_ShowHum;
        public System.Windows.Forms.MenuItem PopupMenu_ShowMon;
        public System.Windows.Forms.MenuItem PopupMenu_ShowNpc;
        public System.Windows.Forms.MenuItem PopupMenu_ShowItem;
        public System.Windows.Forms.MenuItem N1;
        public System.Windows.Forms.MenuItem PopupMenu_ClearMon;
        public System.Windows.Forms.MenuItem PopupMenu_ClearItem;
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PanelStatus = new System.Windows.Forms.Panel();
            this.ListView = new System.Windows.Forms.ListView();
            this._column_48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenu = new System.Windows.Forms.ContextMenu();
            this.PopupMenu_Ref = new System.Windows.Forms.MenuItem();
            this.PopupMenu_AutoRef = new System.Windows.Forms.MenuItem();
            this.PopupMenu__ = new System.Windows.Forms.MenuItem();
            this.PopupMenu_MonGen = new System.Windows.Forms.MenuItem();
            this.PopupMenu_RunHum = new System.Windows.Forms.MenuItem();
            this.PopupMenu_RunMon = new System.Windows.Forms.MenuItem();
            this.PopupMenu_Horser = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ShowHum = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ShowMon = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ShowNpc = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ShowItem = new System.Windows.Forms.MenuItem();
            this.N1 = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ClearMon = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ClearItem = new System.Windows.Forms.MenuItem();
            this.StatusBar = new System.Windows.Forms.StatusBar();
            this._panel_58 = new System.Windows.Forms.StatusBarPanel();
            this._panel_59 = new System.Windows.Forms.StatusBarPanel();
            this._panel_60 = new System.Windows.Forms.StatusBarPanel();
            this._panel_61 = new System.Windows.Forms.StatusBarPanel();
            this._panel_62 = new System.Windows.Forms.StatusBarPanel();
            this._panel_63 = new System.Windows.Forms.StatusBarPanel();
            this.PanelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panel_58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_63)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelStatus
            // 
            this.PanelStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PanelStatus.Controls.Add(this.ListView);
            this.PanelStatus.Controls.Add(this.StatusBar);
            this.PanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelStatus.Location = new System.Drawing.Point(0, 0);
            this.PanelStatus.Name = "PanelStatus";
            this.PanelStatus.Size = new System.Drawing.Size(663, 418);
            this.PanelStatus.TabIndex = 0;
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._column_48,
            this._column_49,
            this._column_50,
            this._column_51,
            this._column_52,
            this._column_53,
            this._column_55,
            this._column_56});
            this.ListView.ContextMenu = this.PopupMenu;
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.FullRowSelect = true;
            this.ListView.GridLines = true;
            this.ListView.Location = new System.Drawing.Point(0, 0);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(663, 399);
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.Click += new System.EventHandler(this.ListViewClick);
            // 
            // _column_48
            // 
            this._column_48.Name = "_column_48";
            this._column_48.Text = "�ļ�����";
            this._column_48.Width = 120;
            // 
            // _column_49
            // 
            this._column_49.Name = "_column_49";
            this._column_49.Text = "��ͼ����";
            this._column_49.Width = 120;
            // 
            // _column_50
            // 
            this._column_50.Name = "_column_50";
            this._column_50.Text = "����";
            // 
            // _column_51
            // 
            this._column_51.Name = "_column_51";
            this._column_51.Text = "����";
            // 
            // _column_52
            // 
            this._column_52.Name = "_column_52";
            this._column_52.Text = "NPC";
            // 
            // _column_53
            // 
            this._column_53.Name = "_column_53";
            this._column_53.Text = "��Ʒ";
            // 
            // _column_55
            // 
            this._column_55.Name = "_column_55";
            this._column_55.Text = "����";
            this._column_55.Width = 50;
            // 
            // _column_56
            // 
            this._column_56.Name = "_column_56";
            this._column_56.Text = "����";
            this._column_56.Width = 50;
            // 
            // PopupMenu
            // 
            this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.PopupMenu_Ref,
            this.PopupMenu_AutoRef,
            this.PopupMenu__,
            this.PopupMenu_MonGen,
            this.PopupMenu_RunHum,
            this.PopupMenu_RunMon,
            this.PopupMenu_Horser,
            this.PopupMenu_,
            this.PopupMenu_ShowHum,
            this.PopupMenu_ShowMon,
            this.PopupMenu_ShowNpc,
            this.PopupMenu_ShowItem,
            this.N1,
            this.PopupMenu_ClearMon,
            this.PopupMenu_ClearItem});
            // 
            // PopupMenu_Ref
            // 
            this.PopupMenu_Ref.Index = 0;
            this.PopupMenu_Ref.Text = "ˢ��(&R)";
            this.PopupMenu_Ref.Click += new System.EventHandler(this.PopupMenu_RefClick);
            // 
            // PopupMenu_AutoRef
            // 
            this.PopupMenu_AutoRef.Index = 1;
            this.PopupMenu_AutoRef.Text = "�Զ�ˢ��(&A)";
            this.PopupMenu_AutoRef.Click += new System.EventHandler(this.PopupMenu_AutoRefClick);
            // 
            // PopupMenu__
            // 
            this.PopupMenu__.Index = 2;
            this.PopupMenu__.Text = "-";
            // 
            // PopupMenu_MonGen
            // 
            this.PopupMenu_MonGen.Index = 3;
            this.PopupMenu_MonGen.Text = "����ˢ��";
            this.PopupMenu_MonGen.Click += new System.EventHandler(this.PopupMenu_MonGenClick);
            // 
            // PopupMenu_RunHum
            // 
            this.PopupMenu_RunHum.Index = 4;
            this.PopupMenu_RunHum.Text = "������";
            this.PopupMenu_RunHum.Click += new System.EventHandler(this.PopupMenu_MonGenClick);
            // 
            // PopupMenu_RunMon
            // 
            this.PopupMenu_RunMon.Index = 5;
            this.PopupMenu_RunMon.Text = "������";
            this.PopupMenu_RunMon.Click += new System.EventHandler(this.PopupMenu_MonGenClick);
            // 
            // PopupMenu_Horser
            // 
            this.PopupMenu_Horser.Index = 6;
            this.PopupMenu_Horser.Text = "��������";
            this.PopupMenu_Horser.Click += new System.EventHandler(this.PopupMenu_MonGenClick);
            // 
            // PopupMenu_
            // 
            this.PopupMenu_.Index = 7;
            this.PopupMenu_.Text = "-";
            // 
            // PopupMenu_ShowHum
            // 
            this.PopupMenu_ShowHum.Index = 8;
            this.PopupMenu_ShowHum.Text = "�鿴����(&H)";
            this.PopupMenu_ShowHum.Click += new System.EventHandler(this.PopupMenu_ShowHumClick);
            // 
            // PopupMenu_ShowMon
            // 
            this.PopupMenu_ShowMon.Index = 9;
            this.PopupMenu_ShowMon.Text = "�鿴����(&M)";
            this.PopupMenu_ShowMon.Click += new System.EventHandler(this.PopupMenu_ShowMonClick);
            // 
            // PopupMenu_ShowNpc
            // 
            this.PopupMenu_ShowNpc.Index = 10;
            this.PopupMenu_ShowNpc.Text = "�鿴NPC(&N)";
            this.PopupMenu_ShowNpc.Click += new System.EventHandler(this.PopupMenu_ShowNpcClick);
            // 
            // PopupMenu_ShowItem
            // 
            this.PopupMenu_ShowItem.Enabled = false;
            this.PopupMenu_ShowItem.Index = 11;
            this.PopupMenu_ShowItem.Text = "�鿴��Ʒ(&I)";
            this.PopupMenu_ShowItem.Click += new System.EventHandler(this.PopupMenu_ShowItemClick);
            // 
            // N1
            // 
            this.N1.Index = 12;
            this.N1.Text = "-";
            // 
            // PopupMenu_ClearMon
            // 
            this.PopupMenu_ClearMon.Index = 13;
            this.PopupMenu_ClearMon.Text = "������й���";
            this.PopupMenu_ClearMon.Click += new System.EventHandler(this.PopupMenu_ClearMonClick);
            // 
            // PopupMenu_ClearItem
            // 
            this.PopupMenu_ClearItem.Enabled = false;
            this.PopupMenu_ClearItem.Index = 14;
            this.PopupMenu_ClearItem.Text = "���������Ʒ";
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 399);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this._panel_58,
            this._panel_59,
            this._panel_60,
            this._panel_61,
            this._panel_62,
            this._panel_63});
            this.StatusBar.ShowPanels = true;
            this.StatusBar.Size = new System.Drawing.Size(663, 19);
            this.StatusBar.TabIndex = 1;
            // 
            // _panel_58
            // 
            this._panel_58.Name = "_panel_58";
            // 
            // _panel_59
            // 
            this._panel_59.Name = "_panel_59";
            // 
            // _panel_60
            // 
            this._panel_60.Name = "_panel_60";
            // 
            // _panel_61
            // 
            this._panel_61.Name = "_panel_61";
            // 
            // _panel_62
            // 
            this._panel_62.Name = "_panel_62";
            // 
            // _panel_63
            // 
            this._panel_63.Name = "_panel_63";
            // 
            // TfrmSysManager
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(663, 418);
            this.Controls.Add(this.PanelStatus);
            this.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(505, 253);
            this.MaximizeBox = false;
            this.Name = "TfrmSysManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ϵͳ����";
            this.PanelStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._panel_58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panel_63)).EndInit();
            this.ResumeLayout(false);

        }
#endregion
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.StatusBar StatusBar;
        private System.Windows.Forms.StatusBarPanel _panel_58;
        private System.Windows.Forms.StatusBarPanel _panel_59;
        private System.Windows.Forms.StatusBarPanel _panel_60;
        private System.Windows.Forms.StatusBarPanel _panel_61;
        private System.Windows.Forms.StatusBarPanel _panel_62;
        private System.Windows.Forms.StatusBarPanel _panel_63;
    }
}
