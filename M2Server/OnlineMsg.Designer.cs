namespace M2Server
{
  partial class TfrmOnlineMsg
    {
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox ComboBoxMsg;
        public System.Windows.Forms.TextBox MemoMsg;
        public System.Windows.Forms.DataGrid StringGrid;
        public System.Windows.Forms.Button ButtonAdd;
        public System.Windows.Forms.Button ButtonDelete;
        public System.Windows.Forms.Button ButtonSend;
        private System.ComponentModel.IContainer components;
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
        	this.Label1 = new System.Windows.Forms.Label();
        	this.ComboBoxMsg = new System.Windows.Forms.ComboBox();
        	this.MemoMsg = new System.Windows.Forms.TextBox();
        	this.StringGrid = new System.Windows.Forms.DataGrid();
        	this.ButtonAdd = new System.Windows.Forms.Button();
        	this.ButtonDelete = new System.Windows.Forms.Button();
        	this.ButtonSend = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.StringGrid)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// Label1
        	// 
        	this.Label1.Location = new System.Drawing.Point(4, 169);
        	this.Label1.Name = "Label1";
        	this.Label1.Size = new System.Drawing.Size(62, 16);
        	this.Label1.TabIndex = 0;
        	this.Label1.Text = "在线信息:";
        	// 
        	// ComboBoxMsg
        	// 
        	this.ComboBoxMsg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
        	this.ComboBoxMsg.ItemHeight = 12;
        	this.ComboBoxMsg.Location = new System.Drawing.Point(72, 165);
        	this.ComboBoxMsg.Name = "ComboBoxMsg";
        	this.ComboBoxMsg.Size = new System.Drawing.Size(365, 20);
        	this.ComboBoxMsg.TabIndex = 0;
        	// 
        	// MemoMsg
        	// 
        	this.MemoMsg.Location = new System.Drawing.Point(3, 4);
        	this.MemoMsg.Multiline = true;
        	this.MemoMsg.Name = "MemoMsg";
        	this.MemoMsg.Size = new System.Drawing.Size(434, 153);
        	this.MemoMsg.TabIndex = 1;
        	this.MemoMsg.Text = "MemoMsg";
        	// 
        	// StringGrid
        	// 
        	this.StringGrid.DataMember = "";
        	this.StringGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	this.StringGrid.Location = new System.Drawing.Point(3, 219);
        	this.StringGrid.Name = "StringGrid";
        	this.StringGrid.Size = new System.Drawing.Size(434, 106);
        	this.StringGrid.TabIndex = 2;
        	// 
        	// ButtonAdd
        	// 
        	this.ButtonAdd.Enabled = false;
        	this.ButtonAdd.Location = new System.Drawing.Point(367, 191);
        	this.ButtonAdd.Name = "ButtonAdd";
        	this.ButtonAdd.Size = new System.Drawing.Size(67, 23);
        	this.ButtonAdd.TabIndex = 3;
        	this.ButtonAdd.Text = "增加(&A)";
        	// 
        	// ButtonDelete
        	// 
        	this.ButtonDelete.Enabled = false;
        	this.ButtonDelete.Location = new System.Drawing.Point(293, 191);
        	this.ButtonDelete.Name = "ButtonDelete";
        	this.ButtonDelete.Size = new System.Drawing.Size(67, 23);
        	this.ButtonDelete.TabIndex = 4;
        	this.ButtonDelete.Text = "删除(&D)";
        	// 
        	// ButtonSend
        	// 
        	this.ButtonSend.Location = new System.Drawing.Point(148, 190);
        	this.ButtonSend.Name = "ButtonSend";
        	this.ButtonSend.Size = new System.Drawing.Size(67, 23);
        	this.ButtonSend.TabIndex = 5;
        	this.ButtonSend.Text = "发送(&S)";
        	this.ButtonSend.Click += new System.EventHandler(this.ButtonSendClick);
        	// 
        	// TfrmOnlineMsg
        	// 
        	this.AutoScroll = true;
        	this.ClientSize = new System.Drawing.Size(440, 332);
        	this.Controls.Add(this.Label1);
        	this.Controls.Add(this.ComboBoxMsg);
        	this.Controls.Add(this.MemoMsg);
        	this.Controls.Add(this.StringGrid);
        	this.Controls.Add(this.ButtonAdd);
        	this.Controls.Add(this.ButtonDelete);
        	this.Controls.Add(this.ButtonSend);
        	this.Font = new System.Drawing.Font("宋体", 9F);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Location = new System.Drawing.Point(367, 319);
        	this.Name = "TfrmOnlineMsg";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "在线发送消息";
        	((System.ComponentModel.ISupportInitialize)(this.StringGrid)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
#endregion

        
        void ButtonSendClick(object sender, System.EventArgs e)
        {
        	
        }
    }
}
