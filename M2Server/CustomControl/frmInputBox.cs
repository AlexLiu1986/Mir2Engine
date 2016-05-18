/*****************************************************
** �� �� ����frmInputBox.cs
** Copyright (c) 2011-2013 JohnSoft
** �ļ���ţ�
** �� �� �ˣ���־ǿ
** ��    �ڣ�2011��8��23��
** �� �� �ˣ�
** ��    �ڣ�
** ��    ����
********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace M2Server
{
    /// <summary>
    /// ģ���ţ�
    /// ����������������Ϣ��
    /// �� �� �ˣ���־ǿ
    /// ��    �ڣ�2011��8��23��
    /// Log ��ţ�
    /// �޸�������
    /// �� �� �ˣ�
    /// ��    �ڣ�
    /// </summary>
    public partial class frmInputBox : Form
    {
        public frmInputBox()
        {
            InitializeComponent();
            
        }

        public string strFileName = "";

        public void setInputBoxOption(string strTitle, string strPrompt, string strDefaultValue)
        {
            this.Text = strTitle;
            lblPrompt.Text = strPrompt;
            txtContent.Text = strDefaultValue;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            strFileName = txtContent.Text;
            this.Hide();
        }

        private void frmInputBox_Load(object sender, EventArgs e)
        {
           // this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}