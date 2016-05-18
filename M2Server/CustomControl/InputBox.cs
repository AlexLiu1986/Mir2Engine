/*****************************************************
** �� �� ����InputBox.cs
** Copyright (c) 2011-2013 JohnSoft
** �ļ���ţ�
** �� �� �ˣ���־ǿ
** ��    �ڣ�2011��8��23��
** �� �� �ˣ�
** ��    �ڣ�
** ��    ����
********************************************************/
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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
    public partial class InputBox : Component
    {
        private static frmInputBox frm = null;
        public InputBox()
        {
            InitializeComponent();
            
        }

        public static string FileName
        {
            get { return frm.strFileName; }
        }

        public InputBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public static void Show(string strTitle, string strPrompt, string strDefaultValue)
        {
            if (frm == null)
            {
                frm = new frmInputBox();
            }
            frm.setInputBoxOption(strTitle, strPrompt, strDefaultValue);
            frm.ShowDialog();
        }

        ~InputBox()
        {
            frm.Close();
            frm.Dispose();
        }
    }
}
