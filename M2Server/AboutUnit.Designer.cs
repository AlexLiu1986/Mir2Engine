namespace M2Server
{
  partial class TFrmAbout
    {
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Button ButtonOK;
        public System.Windows.Forms.GroupBox GroupBox1;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.GroupBox GroupBox2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label Label8;
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
            this.Label2 = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.LabProductName = new System.Windows.Forms.Label();
            this.LabVersion = new System.Windows.Forms.Label();
            this.LabUpDateTime = new System.Windows.Forms.Label();
            this.LabProgram = new System.Windows.Forms.Label();
            this.LabWebSite = new System.Windows.Forms.Label();
            this.LabBbsSite = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label2.Location = new System.Drawing.Point(11, 263);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(294, 36);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "本程序只适用于中华人民共和国法律允许范围内的个人\r娱乐，不得用于商业盈利性经营，如因此造成的后果自\r负与本软件无关。";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(306, 268);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 25);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "确定(&O)";
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(9, 168);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(373, 85);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "版权声明";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(13, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(348, 62);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "本计算机程序受中华人民共和国知识产权与版权保护，如未经授权\r而擅自复制或传播本程序（或其中任何部分），将受到严厉的民事\r及刑事制裁，并在法律许可的范围内受到最大可" +
    "能的起诉。";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.LabBbsSite);
            this.GroupBox2.Controls.Add(this.LabWebSite);
            this.GroupBox2.Controls.Add(this.LabProgram);
            this.GroupBox2.Controls.Add(this.LabUpDateTime);
            this.GroupBox2.Controls.Add(this.LabVersion);
            this.GroupBox2.Controls.Add(this.LabProductName);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Location = new System.Drawing.Point(9, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(380, 157);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "版本信息";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(6, 25);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 12);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "软件名称:";
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(6, 45);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(60, 12);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "软件版本:";
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(6, 65);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(60, 12);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "更新日期:";
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(6, 85);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 12);
            this.Label6.TabIndex = 3;
            this.Label6.Text = "程序制作:";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(6, 105);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(60, 12);
            this.Label7.TabIndex = 4;
            this.Label7.Text = "官 方 站:";
            // 
            // Label8
            // 
            this.Label8.Location = new System.Drawing.Point(6, 124);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(60, 12);
            this.Label8.TabIndex = 5;
            this.Label8.Text = "程 序 站:";
            // 
            // LabProductName
            // 
            this.LabProductName.AutoSize = true;
            this.LabProductName.Location = new System.Drawing.Point(68, 25);
            this.LabProductName.Name = "LabProductName";
            this.LabProductName.Size = new System.Drawing.Size(41, 12);
            this.LabProductName.TabIndex = 6;
            this.LabProductName.Text = "label9";
            // 
            // LabVersion
            // 
            this.LabVersion.AutoSize = true;
            this.LabVersion.Location = new System.Drawing.Point(67, 45);
            this.LabVersion.Name = "LabVersion";
            this.LabVersion.Size = new System.Drawing.Size(41, 12);
            this.LabVersion.TabIndex = 7;
            this.LabVersion.Text = "label9";
            // 
            // LabUpDateTime
            // 
            this.LabUpDateTime.AutoSize = true;
            this.LabUpDateTime.Location = new System.Drawing.Point(67, 66);
            this.LabUpDateTime.Name = "LabUpDateTime";
            this.LabUpDateTime.Size = new System.Drawing.Size(41, 12);
            this.LabUpDateTime.TabIndex = 8;
            this.LabUpDateTime.Text = "label9";
            // 
            // LabProgram
            // 
            this.LabProgram.AutoSize = true;
            this.LabProgram.Location = new System.Drawing.Point(67, 85);
            this.LabProgram.Name = "LabProgram";
            this.LabProgram.Size = new System.Drawing.Size(41, 12);
            this.LabProgram.TabIndex = 9;
            this.LabProgram.Text = "label9";
            // 
            // LabWebSite
            // 
            this.LabWebSite.AutoSize = true;
            this.LabWebSite.Location = new System.Drawing.Point(68, 105);
            this.LabWebSite.Name = "LabWebSite";
            this.LabWebSite.Size = new System.Drawing.Size(41, 12);
            this.LabWebSite.TabIndex = 10;
            this.LabWebSite.Text = "label9";
            // 
            // LabBbsSite
            // 
            this.LabBbsSite.AutoSize = true;
            this.LabBbsSite.Location = new System.Drawing.Point(67, 124);
            this.LabBbsSite.Name = "LabBbsSite";
            this.LabBbsSite.Size = new System.Drawing.Size(41, 12);
            this.LabBbsSite.TabIndex = 11;
            this.LabBbsSite.Text = "label9";
            // 
            // TFrmAbout
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(394, 306);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(348, 237);
            this.MaximizeBox = false;
            this.Name = "TFrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label LabUpDateTime;
        private System.Windows.Forms.Label LabVersion;
        private System.Windows.Forms.Label LabProductName;
        private System.Windows.Forms.Label LabBbsSite;
        private System.Windows.Forms.Label LabWebSite;
        private System.Windows.Forms.Label LabProgram;

    }
}
