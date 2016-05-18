using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TFrmAbout : Form
    {
        public static TFrmAbout FrmAbout = null;

        public TFrmAbout()
        {
            InitializeComponent();
        }

        public void Open()
        {
            LabProductName.Text = Application.ProductName;
            LabVersion.Text = Application.ProductVersion;
            //LabUpDateTime.Text = sUpDateTime;
            //LabProgram.Text = sProgram;
            //LabWebSite.Text = sWebSite;
            //LabBbsSite.Text = sBbsSite;
            this.ShowDialog();
        }

        public void ButtonOKClick(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}