using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmRegister : Form
    {
        public static TfrmRegister frmRegister = null;

        public TfrmRegister()
        {
            InitializeComponent();
        }

        public void Open()
        {
            RefRegInfo();
            this.ShowDialog();
        }

        private void RefRegInfo()
        {
            string RegName = M2Share.g_Config.sServerName;
            string CompanyName = AESEncrypt(M2Share.g_Config.sServerIPaddr + M2Share.g_Config.sServerName, "12345679");
            EditProductName.Text = EngineVersion.g_sTitleName;// �̿͵۹��ڶ�����Ϸ����
            EditVersion.Text = "����汾:" + EngineVersion.g_BuildVer;// ����汾: V5.18 Build 20100418(�ڲ���)
            EditUpDateTime.Text = "����ʱ��:" + EngineVersion.g_sUpDateTime;// ����ʱ��: 2010/04/18
            EditWebSite.Text = "������վ:" + EngineVersion.g_sWebSite;// ������վ: http://www.uc845.com
            EditBbsSite.Text = "������̳:" + EngineVersion.g_sWebSite;// ������̳: http://www.uc845.com
            EditCopyright.Text = "Copyright (C) 2009-2012 DraGon Corporation";// Copyright (C) 2009-2012 DraGon Corporation
            Editkeyxxi.Text = "ע����Ȩ: �뽫[Ӳ����Ϣ/ע���ʶ]���͸�����'";// ע����Ȩ: �뽫[Ӳ����Ϣ/ע���ʶ]���͸�����'
            try
            {
                EditRegHWInfo.Text = AESEncrypt(EngineVersion.g_sTitleName, "asdasdasd");
                EditTianShu.Text = "9999";
                EditChiShu.Text = "9999";
                EditRegCodeKey.Text = "";
                int nStatus = 6;
                switch (nStatus)
                {
                    case 0:
                        this.Text = "���ע�� [����ģʽ]";
                        break;
                    case 1:
                        this.Text = "���ע�� [��ע��]";
                        break;
                    case 2:
                        this.Text = "���ע�� [��Ȩ�ļ�����]";
                        break;
                    case 3:
                        this.Text = "���ע�� [��Ȩ�ļ�����]";
                        break;
                    case 4:
                        this.Text = "���ע�� [Ӳ���任���]";
                        break;
                    case 5:
                        this.Text = "���ע�� [��Ȩ�ļ�����)";
                        break;
                    case 6:
                        this.Text = "���ע�� [������)";
                        break;
                }
                if (nStatus == 1 || nStatus==6)
                {
                    EditRegCodeKey.Text = RegName;
                    EditRegUserIPAddr.Text = CompanyName;
                    EditRegCodeKey.BackColor = System.Drawing.SystemColors.ButtonFace;
                    EditRegCodeKey.ReadOnly = true;
                    //EditRegCodeKey.ParentCtl3D = false;
                    //EditRegCodeKey.ParentFont = false;
                    EditTianShu.Text = "������";
                    EditChiShu.Text = "������";
                    //FillChar(TrialDate, sizeof(SYSTEMTIME), '\0');
                    //WLRegExpirationDate(Addr(TrialDate));
                    //DateTimePicker1.Value = TrialDate;
                }
                else
                {
                    // EditRegUserIPAddr.Text = jiami;
                    //FillChar(TrialDate, sizeof(SYSTEMTIME), '\0');
                    //WLTrialExpirationDate(Addr(TrialDate));
                    //DateTimePicker1.Value = TrialDate;
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// AES ����(�߼����ܱ�׼������һ���ļ����㷨��׼���ٶȿ죬��ȫ����ߣ�Ŀǰ AES ��׼��һ��ʵ���� Rijndael �㷨)
        /// </summary>
        /// <param name="EncryptString">����������</param>
        /// <param name="EncryptKey">������Կ</param>
        /// <returns></returns>
        public static string AESEncrypt(string EncryptString, string EncryptKey)
        {
            if (string.IsNullOrEmpty(EncryptString)) { throw (new Exception("���Ĳ���Ϊ��")); }

            if (string.IsNullOrEmpty(EncryptKey)) { throw (new Exception("��Կ����Ϊ��")); }

            string m_strEncrypt = "";

            byte[] m_btIV = Convert.FromBase64String("Rkb4jvUy/ye7Cd7k89QQgQ==");

            Rijndael m_AESProvider = Rijndael.Create();

            try
            {
                byte[] m_btEncryptString = Encoding.Default.GetBytes(EncryptString);

                MemoryStream m_stream = new MemoryStream();

                CryptoStream m_csstream = new CryptoStream(m_stream, m_AESProvider.CreateEncryptor(Encoding.Default.GetBytes(EncryptKey), m_btIV), CryptoStreamMode.Write);

                m_csstream.Write(m_btEncryptString, 0, m_btEncryptString.Length);

                m_csstream.FlushFinalBlock();

                m_strEncrypt = Convert.ToBase64String(m_stream.ToArray());

                m_stream.Close(); m_stream.Dispose();

                m_csstream.Close(); m_csstream.Dispose();
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_AESProvider.Clear(); }

            return m_strEncrypt;
        }
    }
}