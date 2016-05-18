namespace M2Server
{
  partial class TfrmConfigMonGen
    {
        public System.Windows.Forms.Panel PanelStatus;
        public System.Windows.Forms.ListView ListView;
        public System.Windows.Forms.ColumnHeader _column_41;
        public System.Windows.Forms.ColumnHeader _column_42;
        public System.Windows.Forms.ColumnHeader _column_43;
        public System.Windows.Forms.ColumnHeader _column_44;
        public System.Windows.Forms.ColumnHeader _column_45;
        public System.Windows.Forms.ColumnHeader _column_46;
        public System.Windows.Forms.ColumnHeader _column_47;
        public System.Windows.Forms.ContextMenu PopupMenu;
        public System.Windows.Forms.MenuItem PopupMenu_Ref;
        public System.Windows.Forms.MenuItem PopupMenu_AutoRef;
        public System.Windows.Forms.MenuItem PopupMenu_;
        public System.Windows.Forms.MenuItem PopupMenu_Clear;
        public System.Windows.Forms.MenuItem PopupMenu_ClearAll;
        public System.Windows.Forms.Timer Timer;
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
            this._column_41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._column_47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenu = new System.Windows.Forms.ContextMenu();
            this.PopupMenu_Ref = new System.Windows.Forms.MenuItem();
            this.PopupMenu_AutoRef = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ = new System.Windows.Forms.MenuItem();
            this.PopupMenu_Clear = new System.Windows.Forms.MenuItem();
            this.PopupMenu_ClearAll = new System.Windows.Forms.MenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
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
            this.PanelStatus.Size = new System.Drawing.Size(551, 411);
            this.PanelStatus.TabIndex = 0;
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._column_41,
            this._column_42,
            this._column_43,
            this._column_44,
            this._column_45,
            this._column_46,
            this._column_47});
            this.ListView.ContextMenu = this.PopupMenu;
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.FullRowSelect = true;
            this.ListView.GridLines = true;
            this.ListView.Location = new System.Drawing.Point(0, 0);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(551, 411);
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            // 
            // _column_41
            // 
            this._column_41.Name = "_column_41";
            this._column_41.Text = "���";
            // 
            // _column_42
            // 
            this._column_42.Name = "_column_42";
            this._column_42.Text = "����";
            this._column_42.Width = 120;
            // 
            // _column_43
            // 
            this._column_43.Name = "_column_43";
            this._column_43.Text = "����";
            this._column_43.Width = 80;
            // 
            // _column_44
            // 
            this._column_44.Name = "_column_44";
            this._column_44.Text = "�ȼ�";
            // 
            // _column_45
            // 
            this._column_45.Name = "_column_45";
            this._column_45.Text = "HP";
            this._column_45.Width = 90;
            // 
            // _column_46
            // 
            this._column_46.Name = "_column_46";
            this._column_46.Text = "MP";
            this._column_46.Width = 75;
            // 
            // _column_47
            // 
            this._column_47.Name = "_column_47";
            this._column_47.Text = "����";
            // 
            // PopupMenu
            // 
            this.PopupMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.PopupMenu_Ref,
            this.PopupMenu_AutoRef,
            this.PopupMenu_,
            this.PopupMenu_Clear,
            this.PopupMenu_ClearAll});
            // 
            // PopupMenu_Ref
            // 
            this.PopupMenu_Ref.Index = 0;
            this.PopupMenu_Ref.Text = "ˢ��(&R)";
            // 
            // PopupMenu_AutoRef
            // 
            this.PopupMenu_AutoRef.Index = 1;
            this.PopupMenu_AutoRef.Text = "�Զ�ˢ��(&A)";
            // 
            // PopupMenu_
            // 
            this.PopupMenu_.Index = 2;
            this.PopupMenu_.Text = "-";
            // 
            // PopupMenu_Clear
            // 
            this.PopupMenu_Clear.Index = 3;
            this.PopupMenu_Clear.Text = "���ѡ��(&K)";
            // 
            // PopupMenu_ClearAll
            // 
            this.PopupMenu_ClearAll.Index = 4;
            this.PopupMenu_ClearAll.Text = "�������(&C)";
            // 
            // TfrmConfigMonGen
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(551, 411);
            this.Controls.Add(this.PanelStatus);
            this.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(615, 258);
            this.MaximizeBox = false;
            this.Name = "TfrmConfigMonGen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.PanelStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }
#endregion
        private System.ComponentModel.IContainer components;
    }
}
