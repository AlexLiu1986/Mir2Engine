namespace M2Server
{
  partial class TfrmConfigMerchant
    {
        public System.Windows.Forms.Panel PanelStatus;
        public System.Windows.Forms.ListView ListView;
        public System.Windows.Forms.ColumnHeader _column_34;
        public System.Windows.Forms.ColumnHeader _column_35;
        public System.Windows.Forms.ColumnHeader _column_36;
        public System.Windows.Forms.ColumnHeader _column_37;
        public System.Windows.Forms.ColumnHeader _column_38;
        public System.Windows.Forms.ColumnHeader _column_39;
        public System.Windows.Forms.ColumnHeader _column_40;
        public System.Windows.Forms.ContextMenu PopupMenu;
        public System.Windows.Forms.MenuItem PopupMenu_Ref;
        public System.Windows.Forms.MenuItem PopupMenu_AutoRef;
        public System.Windows.Forms.MenuItem PopupMenu_;
        public System.Windows.Forms.MenuItem PopupMenu_Load;
        public System.Windows.Forms.MenuItem PopupMenu_Clear;
        public System.Windows.Forms.MenuItem PopupMenu_Open;
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
            this._column_34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenu = new System.Windows.Forms.ContextMenu();
            this.PopupMenu_Ref = new System.Windows.Forms.MenuItem();
            this.PopupMenu_AutoRef = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ = new System.Windows.Forms.MenuItem();
            this.PopupMenu_Load = new System.Windows.Forms.MenuItem();
            this.PopupMenu_Clear = new System.Windows.Forms.MenuItem();
            this.PopupMenu_Open = new System.Windows.Forms.MenuItem();
            this.PanelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelStatus
            // 
            this.PanelStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PanelStatus.Controls.Add(this.ListView);
            this.PanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelStatus.Location = new System.Drawing.Point(0, 0);
            this.PanelStatus.Name = "PanelStatus";
            this.PanelStatus.Size = new System.Drawing.Size(680, 336);
            this.PanelStatus.TabIndex = 0;
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._column_34,
            this._column_35,
            this._column_36,
            this._column_37,
            this._column_38,
            this._column_39,
            this._column_40});
            this.ListView.ContextMenu = this.PopupMenu;
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.FullRowSelect = true;
            this.ListView.GridLines = true;
            this.ListView.Location = new System.Drawing.Point(0, 0);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(680, 336);
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            // 
            // _column_34
            // 
            this._column_34.Name = "_column_34";
            this._column_34.Text = "���";
            // 
            // _column_35
            // 
            this._column_35.Name = "_column_35";
            this._column_35.Text = "����";
            this._column_35.Width = 120;
            // 
            // _column_36
            // 
            this._column_36.Name = "_column_36";
            this._column_36.Text = "����";
            this._column_36.Width = 80;
            // 
            // _column_37
            // 
            this._column_37.Name = "_column_37";
            this._column_37.Text = "����NPC";
            // 
            // _column_38
            // 
            this._column_38.Name = "_column_38";
            this._column_38.Text = "����NPC";
            // 
            // _column_39
            // 
            this._column_39.Name = "_column_39";
            this._column_39.Text = "����";
            // 
            // _column_40
            // 
            this._column_40.Name = "_column_40";
            this._column_40.Text = "��Ϣ";
            this._column_40.Width = 230;
            // 
            // PopupMenu
            // 
            this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.PopupMenu_Ref,
            this.PopupMenu_AutoRef,
            this.PopupMenu_,
            this.PopupMenu_Load,
            this.PopupMenu_Clear,
            this.PopupMenu_Open});
            // 
            // PopupMenu_Ref
            // 
            this.PopupMenu_Ref.Index = 0;
            this.PopupMenu_Ref.Text = "ˢ��(&R)";
            // 
            // PopupMenu_AutoRef
            // 
            this.PopupMenu_AutoRef.Enabled = false;
            this.PopupMenu_AutoRef.Index = 1;
            this.PopupMenu_AutoRef.Text = "�Զ�ˢ��(&A)";
            // 
            // PopupMenu_
            // 
            this.PopupMenu_.Index = 2;
            this.PopupMenu_.Text = "-";
            // 
            // PopupMenu_Load
            // 
            this.PopupMenu_Load.Index = 3;
            this.PopupMenu_Load.Text = "���¼���(&K)";
            // 
            // PopupMenu_Clear
            // 
            this.PopupMenu_Clear.Index = 4;
            this.PopupMenu_Clear.Text = "�������(&C)";
            // 
            // PopupMenu_Open
            // 
            this.PopupMenu_Open.Index = 5;
            this.PopupMenu_Open.Text = "�򿪽ű�(&O)";
            // 
            // TfrmConfigMerchant
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(680, 336);
            this.Controls.Add(this.PanelStatus);
            this.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(867, 376);
            this.MaximizeBox = false;
            this.Name = "TfrmConfigMerchant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConfigMerchant";
            this.PanelStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }
#endregion
        private System.ComponentModel.IContainer components;
    }
}
