using System;
using System.Windows.Forms;
using GameFramework;

namespace M2Server
{
    public partial class TfrmGameCmd: Form
    {
        private int nRefGameUserIndex = 0;
        private int nRefGameMasterIndex = 0;
        private int nRefGameDebugIndex = 0;
        public static TfrmGameCmd frmGameCmd = null;
        public TfrmGameCmd()
        {
            InitializeComponent();
        }

//        public void FormCreate(object sender, EventArgs e)
//        {
//            PageControl.SelectedIndex = 0;
            
//            StringGridGameCmd.RowCount = 50;
            
//            StringGridGameCmd.Cells[0, 0] = "��Ϸ����";
            
//            StringGridGameCmd.Cells[1, 0] = "����Ȩ��";
            
//            StringGridGameCmd.Cells[2, 0] = "�����ʽ";
            
//            StringGridGameCmd.Cells[3, 0] = "����˵��";
            
//            StringGridGameMasterCmd.RowCount = 105;
            
//            StringGridGameMasterCmd.Cells[0, 0] = "��Ϸ����";
            
//            StringGridGameMasterCmd.Cells[1, 0] = "����Ȩ��";
            
//            StringGridGameMasterCmd.Cells[2, 0] = "�����ʽ";
            
//            StringGridGameMasterCmd.Cells[3, 0] = "����˵��";
            
//            StringGridGameDebugCmd.RowCount = 41;
            
//            StringGridGameDebugCmd.Cells[0, 0] = "��Ϸ����";
            
//            StringGridGameDebugCmd.Cells[1, 0] = "����Ȩ��";
            
//            StringGridGameDebugCmd.Cells[2, 0] = "�����ʽ";
            
//            StringGridGameDebugCmd.Cells[3, 0] = "����˵��";
//        }

        public void Open()
        {
            //RefUserCommand();
            //RefGameMasterCommand();
            //RefDebugCommand();
            this.ShowDialog();
        }

        private void RefGameUserCmd(TGameCmd GameCmd, string sCmdParam, string sDesc)
        {
            nRefGameUserIndex++;

            //if (StringGridGameCmd.RowCount - 1 < nRefGameUserIndex)
            //{
            //    StringGridGameCmd.RowCount = nRefGameUserIndex + 1;
            //}

            //StringGridGameCmd.Cells[0, nRefGameUserIndex] = GameCmd.sCmd;

            //StringGridGameCmd.Cells[1, nRefGameUserIndex] = (GameCmd.nPermissionMin).ToString() + "/" + (GameCmd.nPermissionMax).ToString();

            //StringGridGameCmd.Cells[2, nRefGameUserIndex] = sCmdParam;

            //StringGridGameCmd.Cells[3, nRefGameUserIndex] = sDesc;

            //StringGridGameCmd.Objects[0, nRefGameUserIndex] = ((GameCmd) as Object);
        }

//        // StringGridGameCmd.Cells[3,12]:='δʹ��';
//        // StringGridGameCmd.Cells[3,13]:='�ƶ���ͼָ������(��Ҫ������װ��)';
//        // StringGridGameCmd.Cells[3,14]:='̽����������λ��(��Ҫ������װ��)';
//        // StringGridGameCmd.Cells[3,15]:='������䴫��';
//        // StringGridGameCmd.Cells[3,16]:='�������Ա���͵����(��Ҫ������ȫ��װ��)';
//        // StringGridGameCmd.Cells[3,17]:='�����лᴫ��';
//        // StringGridGameCmd.Cells[3,18]:='���л��Ա�������(��Ҫ���лᴫ��װ��)';
//        // StringGridGameCmd.Cells[3,19]:='�����ֿ�������';
//        // StringGridGameCmd.Cells[3,20]:='������¼������';
//        // StringGridGameCmd.Cells[3,21]:='���ֿ���������';
//        // StringGridGameCmd.Cells[3,22]:='���òֿ�����';
//        // StringGridGameCmd.Cells[3,23]:='�޸Ĳֿ�����';
//        // StringGridGameCmd.Cells[3,24]:='�������(�ȿ������������)';
//        // StringGridGameCmd.Cells[3,25]:='δʹ��';
//        // StringGridGameCmd.Cells[3,26]:='��ѯ����λ��';
//        // StringGridGameCmd.Cells[3,27]:='������޴���';
//        // StringGridGameCmd.Cells[3,28]:='���޽��Է����͵����';
//        // StringGridGameCmd.Cells[3,29]:='��ѯʦͽλ��';
//        // StringGridGameCmd.Cells[3,30]:='����ʦͽ����';
//        // StringGridGameCmd.Cells[3,31]:='ʦ����ͽ���ٻ������';
//        // StringGridGameCmd.Cells[3,32]:='��������ģʽ(�����Ҫ�޸�)';
//        // StringGridGameCmd.Cells[3,33]:='��������״̬(�����Ҫ�޸�)';
//        // StringGridGameCmd.Cells[3,34]:='�����ƺ�������';
//        // StringGridGameCmd.Cells[3,35]:='����������';
//        // StringGridGameCmd.Cells[3,36]:='';
//        // StringGridGameCmd.Cells[3,37]:='����/�رյ�¼��';

//        private void RefUserCommand()
//        {
//            EditUserCmdOK.Enabled = false;
//            nRefGameUserIndex = 0;
//            RefGameUserCmd(M2Share.g_GameCommand.Data, "@" + M2Share.g_GameCommand.Data.sCmd, "�鿴��ǰ����������ʱ��");
//            RefGameUserCmd(M2Share.g_GameCommand.PRVMSG, "@" + M2Share.g_GameCommand.PRVMSG.sCmd, "��ָֹ�����﷢��˽����Ϣ");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWMSG, "@" + M2Share.g_GameCommand.ALLOWMSG.sCmd, "��ֹ�������Լ���˽����Ϣ");
//            RefGameUserCmd(M2Share.g_GameCommand.LETSHOUT, "@" + M2Share.g_GameCommand.LETSHOUT.sCmd, "��ֹ�������������Ϣ");
//            // RefGameUserCmd(@g_GameCommand.BANGMMSG, //�ܾ����к�����Ϣ 20080211
//            // '@' + g_GameCommand.BANGMMSG.sCmd,
//            // '��ֹ�������к�����Ϣ');
//            RefGameUserCmd(M2Share.g_GameCommand.LETTRADE, "@" + M2Share.g_GameCommand.LETTRADE.sCmd, "��ֹ���׽�����Ʒ");
//            RefGameUserCmd(M2Share.g_GameCommand.LETGUILD, "@" + M2Share.g_GameCommand.LETGUILD.sCmd, "��������л�");
//            RefGameUserCmd(M2Share.g_GameCommand.ENDGUILD, "@" + M2Share.g_GameCommand.ENDGUILD.sCmd, "�˳���ǰ��������л�");
//            RefGameUserCmd(M2Share.g_GameCommand.BANGUILDCHAT, "@" + M2Share.g_GameCommand.BANGUILDCHAT.sCmd, "��ֹ�����л�������Ϣ");
//            RefGameUserCmd(M2Share.g_GameCommand.AUTHALLY, "@" + M2Share.g_GameCommand.AUTHALLY.sCmd, "���л��������");
//            RefGameUserCmd(M2Share.g_GameCommand.AUTH, "@" + M2Share.g_GameCommand.AUTH.sCmd, "��ʼ�����л�����(�����ʽ��Ϊ@Alliance,������Ϸ�����޷�����)");
//            RefGameUserCmd(M2Share.g_GameCommand.AUTHCANCEL, "@" + M2Share.g_GameCommand.AUTHCANCEL.sCmd, "ȡ���л����˹�ϵ(�����ʽ��Ϊ@CancelAlliance,������Ϸ�����޷�ȡ������)");
//            // Exit;//20080823
//            RefGameUserCmd(M2Share.g_GameCommand.USERMOVE, "@" + M2Share.g_GameCommand.USERMOVE.sCmd + "  ����X  ����Y", "���͵�ָ������");
//            RefGameUserCmd(M2Share.g_GameCommand.SEARCHING, "@" + M2Share.g_GameCommand.SEARCHING.sCmd + " ��������", "̽��ָ�������ںδ�");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWGROUPCALL, "@" + M2Share.g_GameCommand.ALLOWGROUPCALL.sCmd, "������غ�һ(����������������ֹ���鴫�͹���)");
//            RefGameUserCmd(M2Share.g_GameCommand.GROUPRECALLL, "@" + M2Share.g_GameCommand.GROUPRECALLL.sCmd, "��غ�һ");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWGUILDRECALL, "@" + M2Share.g_GameCommand.ALLOWGUILDRECALL.sCmd, "�����л��һ(�лᴫ�ͣ��л������˿��Խ������л��Աȫ������)");
//            RefGameUserCmd(M2Share.g_GameCommand.GUILDRECALLL, "@" + M2Share.g_GameCommand.GUILDRECALLL.sCmd, "�л��һ");
//            RefGameUserCmd(M2Share.g_GameCommand.UNLOCKSTORAGE, "@" + M2Share.g_GameCommand.UNLOCKSTORAGE.sCmd, "�ֿ⿪��");
//            RefGameUserCmd(M2Share.g_GameCommand.UnLock, "@" + M2Share.g_GameCommand.UnLock.sCmd, "����");
//            RefGameUserCmd(M2Share.g_GameCommand.__Lock, "@" + M2Share.g_GameCommand.__Lock.sCmd, "�����ֿ�");
//            RefGameUserCmd(M2Share.g_GameCommand.SETPASSWORD, "@" + M2Share.g_GameCommand.SETPASSWORD.sCmd, "��������");
//            RefGameUserCmd(M2Share.g_GameCommand.CHGPASSWORD, "@" + M2Share.g_GameCommand.CHGPASSWORD.sCmd, "�޸�����");
//            RefGameUserCmd(M2Share.g_GameCommand.UNPASSWORD, "@" + M2Share.g_GameCommand.UNPASSWORD.sCmd, "�������");
//            RefGameUserCmd(M2Share.g_GameCommand.MEMBERFUNCTION, "@" + M2Share.g_GameCommand.MEMBERFUNCTION.sCmd, "�򿪻�Ա���ܴ���(QManage-[@Member])");
//            RefGameUserCmd(M2Share.g_GameCommand.DEAR, "@" + M2Share.g_GameCommand.DEAR.sCmd + " ��������", "���������ڲ�ѯ��ż��ǰ����λ��");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWDEARRCALL, "@" + M2Share.g_GameCommand.ALLOWDEARRCALL.sCmd, "������޴���");
//            RefGameUserCmd(M2Share.g_GameCommand.DEARRECALL, "@" + M2Share.g_GameCommand.DEARRECALL.sCmd, "���޴��ͣ����Է����͵��Լ���ߣ��Է�����������");
//            RefGameUserCmd(M2Share.g_GameCommand.MASTER, "@" + M2Share.g_GameCommand.MASTER.sCmd + " ��������", "���������ڲ�ѯʦͽ��ǰ����λ��");
//            RefGameUserCmd(M2Share.g_GameCommand.ALLOWMASTERRECALL, "@" + M2Share.g_GameCommand.ALLOWMASTERRECALL.sCmd, "����ʦͽ����");
//            RefGameUserCmd(M2Share.g_GameCommand.MASTERECALL, "@" + M2Share.g_GameCommand.MASTERECALL.sCmd + " ��������", "ʦͽ����");
//            RefGameUserCmd(M2Share.g_GameCommand.ATTACKMODE, "@" + M2Share.g_GameCommand.ATTACKMODE.sCmd, "�ı乥��ģʽ");
//            RefGameUserCmd(M2Share.g_GameCommand.REST, "@" + M2Share.g_GameCommand.REST.sCmd, "�ı�����״̬");
//            RefGameUserCmd(M2Share.g_GameCommand.MEMBERFUNCTIONEX, "@" + M2Share.g_GameCommand.MEMBERFUNCTIONEX.sCmd, "�򿪻�Ա����(QFunction-[@Member])");
//            RefGameUserCmd(M2Share.g_GameCommand.LOCKLOGON, "@" + M2Share.g_GameCommand.LOCKLOGON.sCmd, "���õ�¼������");
//            // RefGameUserCmd(@g_GameCommand.REMTEMSG,
//            // '@' +  g_GameCommand.REMTEMSG.sCmd ,
//            // '���������Ϣ(���)');
//            // //δʹ�� 20080823
//            // StringGridGameCmd.Cells[0, 12] := g_GameCommand.DIARY.sCmd;
//            // StringGridGameCmd.Cells[1, 12] := IntToStr(g_GameCommand.DIARY.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 12] := '@' + g_GameCommand.DIARY.sCmd;
//            // StringGridGameCmd.Objects[0, 12] := TObject(@g_GameCommand.DIARY);
//            // StringGridGameCmd.Cells[0, 13] := g_GameCommand.USERMOVE.sCmd;
//            // StringGridGameCmd.Cells[1, 13] := IntToStr(g_GameCommand.USERMOVE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 13] := '@' + g_GameCommand.USERMOVE.sCmd;
//            // StringGridGameCmd.Objects[0, 13] := TObject(@g_GameCommand.USERMOVE);
//            // 
//            // StringGridGameCmd.Cells[0, 14] := g_GameCommand.SEARCHING.sCmd;
//            // StringGridGameCmd.Cells[1, 14] := IntToStr(g_GameCommand.SEARCHING.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 14] := '@' + g_GameCommand.SEARCHING.sCmd;
//            // StringGridGameCmd.Objects[0, 14] := TObject(@g_GameCommand.SEARCHING);
//            // 
//            // StringGridGameCmd.Cells[0, 15] := g_GameCommand.ALLOWGROUPCALL.sCmd;//������غ�һ
//            // StringGridGameCmd.Cells[1, 15] := IntToStr(g_GameCommand.ALLOWGROUPCALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 15] := '@' + g_GameCommand.ALLOWGROUPCALL.sCmd;
//            // StringGridGameCmd.Objects[0, 15] := TObject(@g_GameCommand.ALLOWGROUPCALL);
//            // 
//            // StringGridGameCmd.Cells[0, 16] := g_GameCommand.GROUPRECALLL.sCmd;//��غ�һ
//            // StringGridGameCmd.Cells[1, 16] := IntToStr(g_GameCommand.GROUPRECALLL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 16] := '@' + g_GameCommand.GROUPRECALLL.sCmd;
//            // StringGridGameCmd.Objects[0, 16] := TObject(@g_GameCommand.GROUPRECALLL);
//            // 
//            // StringGridGameCmd.Cells[0, 17] := g_GameCommand.ALLOWGUILDRECALL.sCmd;//�����л��һ
//            // StringGridGameCmd.Cells[1, 17] := IntToStr(g_GameCommand.ALLOWGUILDRECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 17] := '@' + g_GameCommand.ALLOWGUILDRECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 17] := TObject(@g_GameCommand.ALLOWGUILDRECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 18] := g_GameCommand.GUILDRECALLL.sCmd;//�л��һ
//            // StringGridGameCmd.Cells[1, 18] := IntToStr(g_GameCommand.GUILDRECALLL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 18] := '@' + g_GameCommand.GUILDRECALLL.sCmd;
//            // StringGridGameCmd.Objects[0, 18] := TObject(@g_GameCommand.GUILDRECALLL);
//            // 
//            // StringGridGameCmd.Cells[0, 19] := g_GameCommand.UNLOCKSTORAGE.sCmd;//�ֿ⿪��
//            // StringGridGameCmd.Cells[1, 19] := IntToStr(g_GameCommand.UNLOCKSTORAGE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 19] := '@' + g_GameCommand.UNLOCKSTORAGE.sCmd;
//            // StringGridGameCmd.Objects[0, 19] := TObject(@g_GameCommand.UNLOCKSTORAGE);
//            // 
//            // StringGridGameCmd.Cells[0, 20] := g_GameCommand.UnLock.sCmd;//����
//            // StringGridGameCmd.Cells[1, 20] := IntToStr(g_GameCommand.UnLock.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 20] := '@' + g_GameCommand.UnLock.sCmd;
//            // StringGridGameCmd.Objects[0, 20] := TObject(@g_GameCommand.UnLock);
//            // 
//            // StringGridGameCmd.Cells[0, 21] := g_GameCommand.Lock.sCmd;//�����ֿ�
//            // StringGridGameCmd.Cells[1, 21] := IntToStr(g_GameCommand.Lock.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 21] := '@' + g_GameCommand.Lock.sCmd;
//            // StringGridGameCmd.Objects[0, 21] := TObject(@g_GameCommand.Lock);
//            // 
//            // StringGridGameCmd.Cells[0, 22] := g_GameCommand.SETPASSWORD.sCmd;//��������
//            // StringGridGameCmd.Cells[1, 22] := IntToStr(g_GameCommand.SETPASSWORD.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 22] := '@' + g_GameCommand.SETPASSWORD.sCmd;
//            // StringGridGameCmd.Objects[0, 22] := TObject(@g_GameCommand.SETPASSWORD);
//            // 
//            // StringGridGameCmd.Cells[0, 23] := g_GameCommand.CHGPASSWORD.sCmd;//�޸�����
//            // StringGridGameCmd.Cells[1, 23] := IntToStr(g_GameCommand.CHGPASSWORD.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 23] := '@' + g_GameCommand.CHGPASSWORD.sCmd;
//            // StringGridGameCmd.Objects[0, 23] := TObject(@g_GameCommand.CHGPASSWORD);
//            // 
//            // StringGridGameCmd.Cells[0, 24] := g_GameCommand.UNPASSWORD.sCmd;//�������
//            // StringGridGameCmd.Cells[1, 24] := IntToStr(g_GameCommand.UNPASSWORD.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 24] := '@' + g_GameCommand.UNPASSWORD.sCmd;
//            // StringGridGameCmd.Objects[0, 24] := TObject(@g_GameCommand.UNPASSWORD);
//            // 
//            // StringGridGameCmd.Cells[0, 25] := g_GameCommand.MEMBERFUNCTION.sCmd;//��̨����
//            // StringGridGameCmd.Cells[1, 25] := IntToStr(g_GameCommand.MEMBERFUNCTION.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 25] := '@' + g_GameCommand.MEMBERFUNCTION.sCmd;
//            // StringGridGameCmd.Objects[0, 25] := TObject(@g_GameCommand.MEMBERFUNCTION);
//            // 
//            // StringGridGameCmd.Cells[0, 26] := g_GameCommand.DEAR.sCmd;//���������ڲ�ѯ��ż��ǰ����λ��
//            // StringGridGameCmd.Cells[1, 26] := IntToStr(g_GameCommand.DEAR.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 26] := '@' + g_GameCommand.DEAR.sCmd;
//            // StringGridGameCmd.Objects[0, 26] := TObject(@g_GameCommand.DEAR);
//            // 
//            // StringGridGameCmd.Cells[0, 27] := g_GameCommand.ALLOWDEARRCALL.sCmd;//������޴���
//            // StringGridGameCmd.Cells[1, 27] := IntToStr(g_GameCommand.ALLOWDEARRCALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 27] := '@' + g_GameCommand.ALLOWDEARRCALL.sCmd;
//            // StringGridGameCmd.Objects[0, 27] := TObject(@g_GameCommand.ALLOWDEARRCALL);
//            // 
//            // StringGridGameCmd.Cells[0, 28] := g_GameCommand.DEARRECALL.sCmd;//���޴���
//            // StringGridGameCmd.Cells[1, 28] := IntToStr(g_GameCommand.DEARRECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 28] := '@' + g_GameCommand.DEARRECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 28] := TObject(@g_GameCommand.DEARRECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 29] := g_GameCommand.MASTER.sCmd;//���������ڲ�ѯʦͽ��ǰ����λ��
//            // StringGridGameCmd.Cells[1, 29] := IntToStr(g_GameCommand.MASTER.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 29] := '@' + g_GameCommand.MASTER.sCmd;
//            // StringGridGameCmd.Objects[0, 29] := TObject(@g_GameCommand.MASTER);
//            // 
//            // StringGridGameCmd.Cells[0, 30] := g_GameCommand.ALLOWMASTERRECALL.sCmd;//����ʦͽ����
//            // StringGridGameCmd.Cells[1, 30] := IntToStr(g_GameCommand.ALLOWMASTERRECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 30] := '@' + g_GameCommand.ALLOWMASTERRECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 30] := TObject(@g_GameCommand.ALLOWMASTERRECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 31] := g_GameCommand.MASTERECALL.sCmd;//ʦͽ����
//            // StringGridGameCmd.Cells[1, 31] := IntToStr(g_GameCommand.MASTERECALL.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 31] := '@' + g_GameCommand.MASTERECALL.sCmd;
//            // StringGridGameCmd.Objects[0, 31] := TObject(@g_GameCommand.MASTERECALL);
//            // 
//            // StringGridGameCmd.Cells[0, 32] := g_GameCommand.ATTACKMODE.sCmd;//�ı乥��ģʽ
//            // StringGridGameCmd.Cells[1, 32] := IntToStr(g_GameCommand.ATTACKMODE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 32] := '@' + g_GameCommand.ATTACKMODE.sCmd;
//            // StringGridGameCmd.Objects[0, 32] := TObject(@g_GameCommand.ATTACKMODE);
//            // 
//            // StringGridGameCmd.Cells[0, 33] := g_GameCommand.REST.sCmd;//�ı�����״̬
//            // StringGridGameCmd.Cells[1, 33] := IntToStr(g_GameCommand.REST.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 33] := '@' + g_GameCommand.REST.sCmd;
//            // StringGridGameCmd.Objects[0, 33] := TObject(@g_GameCommand.REST);
//            // StringGridGameCmd.Cells[0, 34] := g_GameCommand.TAKEONHORSE.sCmd;//����
//            // StringGridGameCmd.Cells[1, 34] := IntToStr(g_GameCommand.TAKEONHORSE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 34] := '@' + g_GameCommand.TAKEONHORSE.sCmd;
//            // StringGridGameCmd.Objects[0, 34] := TObject(@g_GameCommand.TAKEONHORSE);
//            // 
//            // StringGridGameCmd.Cells[0, 35] := g_GameCommand.TAKEOFHORSE.sCmd;//����
//            // StringGridGameCmd.Cells[1, 35] := IntToStr(g_GameCommand.TAKEOFHORSE.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 35] := '@' + g_GameCommand.TAKEOFHORSE.sCmd;
//            // StringGridGameCmd.Objects[0, 35] := TObject(@g_GameCommand.TAKEOFHORSE);
//            // StringGridGameCmd.Cells[0, 36] := g_GameCommand.MEMBERFUNCTIONEX.sCmd;//�򿪻�Ա����
//            // StringGridGameCmd.Cells[1, 36] := IntToStr(g_GameCommand.MEMBERFUNCTIONEX.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 36] := '@' + g_GameCommand.MEMBERFUNCTIONEX.sCmd;
//            // StringGridGameCmd.Objects[0, 36] := TObject(@g_GameCommand.MEMBERFUNCTIONEX);
//            // 
//            // StringGridGameCmd.Cells[0, 37] := g_GameCommand.LOCKLOGON.sCmd;//���õ�¼������
//            // StringGridGameCmd.Cells[1, 37] := IntToStr(g_GameCommand.LOCKLOGON.nPermissionMin);
//            // StringGridGameCmd.Cells[2, 37] := '@' + g_GameCommand.LOCKLOGON.sCmd;
//            // StringGridGameCmd.Objects[0, 37] := TObject(@g_GameCommand.LOCKLOGON);

//        }

//        public void StringGridGameCmdClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            nIndex = StringGridGameCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                EditUserCmdName.Text = GameCmd.sCmd;
//                EditUserCmdPerMission.Value = GameCmd.nPermissionMin;
                
//                LabelUserCmdParam.Text = StringGridGameCmd.Cells[2, nIndex];
                
//                LabelUserCmdFunc.Text = StringGridGameCmd.Cells[3, nIndex];
//            }
//            EditUserCmdOK.Enabled = false;
//        }

//        public void EditUserCmdNameChange(object sender, EventArgs e)
//        {
//            EditUserCmdOK.Enabled = true;
//            EditUserCmdSave.Enabled = true;
//        }

//        public void EditUserCmdPerMissionChange(Object Sender)
//        {
//            EditUserCmdOK.Enabled = true;
//            EditUserCmdSave.Enabled = true;
//        }

//        public void EditUserCmdOKClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            string sCmd;
//            int nPermission;
//            sCmd = EditUserCmdName.Text.Trim();
//            nPermission = EditUserCmdPerMission.Value;
//            if (sCmd == "")
//            {
//                System.Windows.Forms.MessageBox.Show("�������Ʋ���Ϊ�գ�����", "��ʾ��Ϣ", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditUserCmdName.Focus();
//                return;
//            }
//            nIndex = StringGridGameCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                GameCmd.sCmd = sCmd;
//                GameCmd.nPermissionMin = nPermission;
//            }
//            RefUserCommand();
//        }

//        public void EditUserCmdSaveClick(object sender, EventArgs e)
//        {
//            EditUserCmdSave.Enabled = false;
//#if SoftVersion <> VERDEMO
            
//            M2Share.CommandConf.WriteString("Command", "Date", M2Share.g_GameCommand.Data.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PrvMsg", M2Share.g_GameCommand.PRVMSG.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowMsg", M2Share.g_GameCommand.ALLOWMSG.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "LetShout", M2Share.g_GameCommand.LETSHOUT.sCmd);
//            // CommandConf.WriteString('Command', 'BanGmMsg', g_GameCommand.BANGMMSG.sCmd);//�ܾ����к�����Ϣ 20080211
            
//            M2Share.CommandConf.WriteString("Command", "LetTrade", M2Share.g_GameCommand.LETTRADE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "LetGuild", M2Share.g_GameCommand.LETGUILD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "EndGuild", M2Share.g_GameCommand.ENDGUILD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "BanGuildChat", M2Share.g_GameCommand.BANGUILDCHAT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AuthAlly", M2Share.g_GameCommand.AUTHALLY.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Auth", M2Share.g_GameCommand.AUTH.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AuthCancel", M2Share.g_GameCommand.AUTHCANCEL.sCmd);
//            // CommandConf.WriteString('Command', 'ViewDiary', g_GameCommand.DIARY.sCmd);//δʹ�� 20080823
            
//            M2Share.CommandConf.WriteString("Command", "UserMove", M2Share.g_GameCommand.USERMOVE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Searching", M2Share.g_GameCommand.SEARCHING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowGroupCall", M2Share.g_GameCommand.ALLOWGROUPCALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GroupCall", M2Share.g_GameCommand.GROUPRECALLL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowGuildReCall", M2Share.g_GameCommand.ALLOWGUILDRECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GuildReCall", M2Share.g_GameCommand.GUILDRECALLL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageUnLock", M2Share.g_GameCommand.UNLOCKSTORAGE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PasswordUnLock", M2Share.g_GameCommand.UnLock.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageLock", M2Share.g_GameCommand.__Lock.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageSetPassword", M2Share.g_GameCommand.SETPASSWORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageChgPassword", M2Share.g_GameCommand.CHGPASSWORD.sCmd);
//            // CommandConf.WriteString('Command','StorageClearPassword',g_GameCommand.CLRPASSWORD.sCmd)
//            // CommandConf.WriteInteger('Permission','StorageClearPassword', g_GameCommand.CLRPASSWORD.nPermissionMin)
            
//            M2Share.CommandConf.WriteString("Command", "StorageUserClearPassword", M2Share.g_GameCommand.UNPASSWORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MemberFunc", M2Share.g_GameCommand.MEMBERFUNCTION.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Dear", M2Share.g_GameCommand.DEAR.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Master", M2Share.g_GameCommand.MASTER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DearRecall", M2Share.g_GameCommand.DEARRECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MasterRecall", M2Share.g_GameCommand.MASTERECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowDearRecall", M2Share.g_GameCommand.ALLOWDEARRCALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AllowMasterRecall", M2Share.g_GameCommand.ALLOWMASTERRECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AttackMode", M2Share.g_GameCommand.ATTACKMODE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Rest", M2Share.g_GameCommand.REST.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "TakeOnHorse", M2Share.g_GameCommand.TAKEONHORSE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "TakeOffHorse", M2Share.g_GameCommand.TAKEOFHORSE.sCmd);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Date", M2Share.g_GameCommand.Data.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PrvMsg", M2Share.g_GameCommand.PRVMSG.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "AllowMsg", M2Share.g_GameCommand.ALLOWMSG.nPermissionMin);
//#endif

//        }

//        private void RefGameMasterCmd(TGameCmd GameCmd, string sCmdParam, string sDesc)
//        {
//            byte nCode;
//            // 20080829
//            nCode = 0;
//            try {
//                nRefGameMasterIndex ++;
//                nCode = 1;
                
//                if (StringGridGameMasterCmd.RowCount - 1 < nRefGameMasterIndex)
//                {
//                    nCode = 2;
                    
//                    StringGridGameMasterCmd.RowCount = nRefGameMasterIndex + 1;
//                }
//                nCode = 3;
                
//                StringGridGameMasterCmd.Cells[0, nRefGameMasterIndex] = GameCmd.sCmd;
//                nCode = 4;
                
//                StringGridGameMasterCmd.Cells[1, nRefGameMasterIndex] = (GameCmd.nPermissionMin).ToString() + "/" + (GameCmd.nPermissionMax).ToString();
//                nCode = 5;
                
//                StringGridGameMasterCmd.Cells[2, nRefGameMasterIndex] = sCmdParam;
//                nCode = 6;
                
//                StringGridGameMasterCmd.Cells[3, nRefGameMasterIndex] = sDesc;
//                nCode = 7;
                
//                StringGridGameMasterCmd.Objects[0, nRefGameMasterIndex] = ((GameCmd) as Object);
//            }
//            catch {
//                M2Share.MainOutMessage("{�쳣} TfrmGameCmd.RefGameMasterCmd Code:" + (nCode).ToString());
//            }
//        }

//        // ��Ϸ����˵��
//        private void RefGameMasterCommand()
//        {
//            EditGameMasterCmdOK.Enabled = false;
//            nRefGameMasterIndex = 0;
//            RefGameMasterCmd(M2Share.g_GameCommand.CLRPASSWORD, "@" + M2Share.g_GameCommand.CLRPASSWORD.sCmd + " ��������", "�������ֿ�/��¼����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.WHO, "/" + M2Share.g_GameCommand.WHO.sCmd, "�鿴��ǰ��������������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TOTAL, "/" + M2Share.g_GameCommand.TOTAL.sCmd, "�鿴���з�������������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEMASTER, "@" + M2Share.g_GameCommand.GAMEMASTER.sCmd, "����/�˳�����Աģʽ(����ģʽ�󲻻��ܵ��κν�ɫ����)(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.OBSERVER, "@" + M2Share.g_GameCommand.OBSERVER.sCmd, "����/�˳�����ģʽ(����ģʽ����˿������Լ�)(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SUEPRMAN, "@" + M2Share.g_GameCommand.SUEPRMAN.sCmd, "����/�˳��޵�ģʽ(����ģʽ�����ﲻ������)(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MAKE, "@" + M2Share.g_GameCommand.MAKE.sCmd + " ��Ʒ���� ����", "����ָ����Ʒ(֧��Ȩ�޷��䣬С�����Ȩ����������ֹ�����б�����)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SMAKE, "@" + M2Share.g_GameCommand.SMAKE.sCmd + " �������ʹ��˵��", "�����Լ����ϵ���Ʒ����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Move, "@" + M2Share.g_GameCommand.Move.sCmd + " ��ͼ��", "�ƶ���ָ����ͼ(֧��Ȩ�޷��䣬С�����Ȩ�����ܽ�ֹ���͵�ͼ�б�����)");
//            RefGameMasterCmd(M2Share.g_GameCommand.POSITIONMOVE, "@" + M2Share.g_GameCommand.POSITIONMOVE.sCmd + " ��ͼ�� X Y", "�ƶ���ָ����ͼ(֧��Ȩ�޷��䣬С�����Ȩ�����ܽ�ֹ���͵�ͼ�б�����)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RECALL, "@" + M2Share.g_GameCommand.RECALL.sCmd + " ��������", "��ָ�������ٻ������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.REGOTO, "@" + M2Share.g_GameCommand.REGOTO.sCmd + " ��������", "����ָ������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TING, "@" + M2Share.g_GameCommand.TING.sCmd + " ��������", "��ָ�������������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SUPERTING, "@" + M2Share.g_GameCommand.SUPERTING.sCmd + " �������� ��Χ��С", "��ָ���������ָ����Χ�ڵ������������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MAPMOVE, "@" + M2Share.g_GameCommand.MAPMOVE.sCmd + " Դ��ͼ�� Ŀ���ͼ��", "��������ͼ�е������ƶ���������ͼ��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.INFO, "@" + M2Share.g_GameCommand.INFO.sCmd + " ��������", "��������Ϣ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.HUMANLOCAL, "@" + M2Share.g_GameCommand.HUMANLOCAL.sCmd + " ��ͼ��", "��ѯ����IP���ڵ���(�����IP������ѯ���)(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.VIEWWHISPER, "@" + M2Share.g_GameCommand.VIEWWHISPER.sCmd + " ��������", "�鿴ָ�������˽����Ϣ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MOBLEVEL, "@" + M2Share.g_GameCommand.MOBLEVEL.sCmd, "�鿴��߽�ɫ��Ϣ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MOBCOUNT, "@" + M2Share.g_GameCommand.MOBCOUNT.sCmd + " ��ͼ��", "�鿴��ͼ�й�������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.HUMANCOUNT, "@" + M2Share.g_GameCommand.HUMANCOUNT.sCmd, "�鿴�������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Map, "@" + M2Share.g_GameCommand.Map.sCmd, "��ʾ��ǰ���ڵ�ͼ�����Ϣ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Level, "@" + M2Share.g_GameCommand.Level.sCmd, "�����Լ��ĵȼ�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.KICK, "@" + M2Share.g_GameCommand.KICK.sCmd + " ��������", "��ָ������������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ReAlive, "@" + M2Share.g_GameCommand.ReAlive.sCmd + " ��������", "��ָ�����︴��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.KILL, "@" + M2Share.g_GameCommand.KILL.sCmd + "��������", "��ָ����������ɱ��(ɱ����ʱ����Թ���)(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEJOB, "@" + M2Share.g_GameCommand.CHANGEJOB.sCmd + " �������� ְҵ����(Warr Wizard Taos)", "���������ְҵ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.FREEPENALTY, "@" + M2Share.g_GameCommand.FREEPENALTY.sCmd + " ��������", "���ָ�������PKֵ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.PKPOINT, "@" + M2Share.g_GameCommand.PKPOINT.sCmd + " ��������", "�鿴ָ�������PKֵ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.IncPkPoint, "@" + M2Share.g_GameCommand.IncPkPoint.sCmd + " �������� ����", "����ָ�������PKֵ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEGENDER, "@" + M2Share.g_GameCommand.CHANGEGENDER.sCmd + " �������� �Ա�(�С�Ů)", "����������Ա�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.HAIR, "@" + M2Share.g_GameCommand.HAIR.sCmd + " ����ֵ", "����ָ�������ͷ������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.BonusPoint, "@" + M2Share.g_GameCommand.BonusPoint.sCmd + " �������� ���Ե���", "������������Ե���(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELBONUSPOINT, "@" + M2Share.g_GameCommand.DELBONUSPOINT.sCmd + " ��������", "ɾ����������Ե���(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RESTBONUSPOINT, "@" + M2Share.g_GameCommand.RESTBONUSPOINT.sCmd + " ��������", "����������Ե������·���(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SETPERMISSION, "@" + M2Share.g_GameCommand.SETPERMISSION.sCmd + " �������� Ȩ�޵ȼ�(0 - 10)", "���������Ȩ�޵ȼ������Խ���ͨ������ΪGMȨ��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RENEWLEVEL, "@" + M2Share.g_GameCommand.RENEWLEVEL.sCmd + " �������� ����(Ϊ����鿴)", "�����鿴�����ת���ȼ�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELGOLD, "@" + M2Share.g_GameCommand.DELGOLD.sCmd + " �������� ����", "ɾ������ָ�������Ľ��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ADDGOLD, "@" + M2Share.g_GameCommand.ADDGOLD.sCmd + " �������� ����", "��������ָ�������Ľ��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEGOLD, "@" + M2Share.g_GameCommand.GAMEGOLD.sCmd + " �������� ���Ʒ�(+ - =) ����", "�����������Ϸ������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEGIRD, "@" + M2Share.g_GameCommand.GAMEGIRD.sCmd + " �������� ���Ʒ�(+ - =) ����", "����������������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEDIAMOND, "@" + M2Share.g_GameCommand.GAMEDIAMOND.sCmd + " �������� ���Ʒ�(+ - =) ����", "��������Ľ��ʯ����(֧��Ȩ�޷���)");
//            // ------------------------------------------------------------------------------
//            // ����Ӣ�۵��ҳ϶� 20080109
//            // g_GameCommand.HEROLOYAL.sCmd
//            RefGameMasterCmd(M2Share.g_GameCommand.HEROLOYAL, "@" + "�ı��ҳ�" + " Ӣ������  �ҳ϶�(0-10000)", "����Ӣ�۵��ҳ϶�(֧��Ȩ�޷���)");
//            // ------------------------------------------------------------------------------
//            RefGameMasterCmd(M2Share.g_GameCommand.GAMEPOINT, "@" + M2Share.g_GameCommand.GAMEPOINT.sCmd + " �������� ���Ʒ�(+ - =) ����", "�����������Ϸ������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CREDITPOINT, "@" + M2Share.g_GameCommand.CREDITPOINT.sCmd + " �������� ���Ʒ�(+ - =) ����", "�����������������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.REFINEWEAPON, "@" + M2Share.g_GameCommand.REFINEWEAPON.sCmd + " ������ ħ���� ���� ׼ȷ��", "����������������(֧��Ȩ�޷���)");
//            // ǧ�ﴫ�� 20071228
//            RefGameMasterCmd(M2Share.g_GameCommand.SysMsg, "@" + M2Share.g_GameCommand.SysMsg.sCmd + " ������Ϣ", "ǧ�ﴫ������");
//            // ����Ӣ�۵ȼ� 20071227
//            RefGameMasterCmd(M2Share.g_GameCommand.HEROLEVEL, "@" + M2Share.g_GameCommand.HEROLEVEL.sCmd + " Ӣ������ �ȼ�", "����ָ��Ӣ�۵ĵȼ�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ADJUESTLEVEL, "@" + M2Share.g_GameCommand.ADJUESTLEVEL.sCmd + " �������� �ȼ�", "����ָ������ĵȼ�(֧��Ȩ�޷���)");
//            // ���������ڹ��ȼ� 20081221
//            RefGameMasterCmd(M2Share.g_GameCommand.NGLEVEL, "@" + M2Share.g_GameCommand.NGLEVEL.sCmd + " �������� �ڹ��ȼ�(1-255)", "����ָ�������Ӣ���ڹ��ȼ�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ADJUESTEXP, "@" + M2Share.g_GameCommand.ADJUESTEXP.sCmd + " �������� ����ֵ", "����ָ������ľ���ֵ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEDEARNAME, "@" + M2Share.g_GameCommand.CHANGEDEARNAME.sCmd + " �������� ��ż����(���Ϊ �� �����)", "����ָ���������ż����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEMASTERNAME, "@" + M2Share.g_GameCommand.CHANGEMASTERNAME.sCmd + " �������� ʦͽ����(���Ϊ �� �����)", "����ָ�������ʦͽ����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RECALLMOB, "@" + M2Share.g_GameCommand.RECALLMOB.sCmd + " �������� ���� �ٻ��ȼ�", "�ٻ�ָ������Ϊ����(֧��Ȩ�޷���)");
//            // 20080122 �ٻ�����
//            RefGameMasterCmd(M2Share.g_GameCommand.RECALLMOBEX, "@" + M2Share.g_GameCommand.RECALLMOBEX.sCmd + " �������� ������ɫ ����X ����Y", "�ٻ�ָ������Ϊ����(֧��Ȩ�޷���)-ħ����");
//            // 20080403 ��ָ�����ȵĿ�ʯ
//            RefGameMasterCmd(M2Share.g_GameCommand.GIVEMINE, "@" + M2Share.g_GameCommand.GIVEMINE.sCmd + " ��ʯ���� ���� ����", "��ָ�����ȵĿ�ʯ(֧��Ȩ�޷���)");
//            // 20080123 ��ָ������Ĺ����ƶ���������
//            RefGameMasterCmd(M2Share.g_GameCommand.MOVEMOBTO, "@" + M2Share.g_GameCommand.MOVEMOBTO.sCmd + " �������� ԭ��ͼ ԭX ԭY �µ�ͼ ��X ��Y", "��ָ������Ĺ����ƶ���������(֧��Ȩ�޷���)");
//            // 20080124 �����ͼ��Ʒ
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARITEMMAP, "@" + M2Share.g_GameCommand.CLEARITEMMAP.sCmd + " ��ͼ X Y ��Χ ��Ʒ����", "�����ͼ��Ʒ����Ʒ����ΪALL���������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TRAINING, "@" + M2Share.g_GameCommand.TRAINING.sCmd + " ��������  �������� �����ȼ�(0-3)", "��������ļ��������ȼ�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.TRAININGSKILL, "@" + M2Share.g_GameCommand.TRAININGSKILL.sCmd + " ��������  �������� �����ȼ�(0-3)", "��ָ���������Ӽ���(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELETESKILL, "@" + M2Share.g_GameCommand.DELETESKILL.sCmd + " �������� ��������(All)", "ɾ������ļ��ܣ�All����ɾ��ȫ������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELETEITEM, "@" + M2Share.g_GameCommand.DELETEITEM.sCmd + " �������� ��Ʒ���� ����", "ɾ����������ָ������Ʒ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARMISSION, "@" + M2Share.g_GameCommand.CLEARMISSION.sCmd + " ��������", "�������������־(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.AddGuild, "@" + M2Share.g_GameCommand.AddGuild.sCmd + " �л����� ������", "�½�һ���л�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELGUILD, "@" + M2Share.g_GameCommand.DELGUILD.sCmd + " �л�����", "ɾ��һ���л�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGESABUKLORD, "@" + M2Share.g_GameCommand.CHANGESABUKLORD.sCmd + " �л�����", "���ĳǱ������л�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR, "@" + M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR.sCmd, "ǿ�п�ʼ/ֹͣ����ս(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CONTESTPOINT, "@" + M2Share.g_GameCommand.CONTESTPOINT.sCmd + " �л�����", "�鿴�л��������÷����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.STARTCONTEST, "@" + M2Share.g_GameCommand.STARTCONTEST.sCmd, "��ʼ�л�������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ENDCONTEST, "@" + M2Share.g_GameCommand.ENDCONTEST.sCmd, "�����л�������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ANNOUNCEMENT, "@" + M2Share.g_GameCommand.ANNOUNCEMENT.sCmd + " �л�����", "�鿴�л����������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.MOB, "@" + M2Share.g_GameCommand.MOB.sCmd + " �������� ���� �ڹ���(0,1)", "����߷���ָ�����������Ĺ���(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.Mission, "@" + M2Share.g_GameCommand.Mission.sCmd + " X  Y", "���ù���ļ��е�(���й��﹥����)(֧��Ȩ�޷���");
//            RefGameMasterCmd(M2Share.g_GameCommand.MobPlace, "@" + M2Share.g_GameCommand.MobPlace.sCmd + " X  Y �������� �������� �ڹ���(0,1)", "�ڵ�ǰ��ͼָ��XY���ù���(֧��Ȩ�޷���(�ȱ������ù���ļ��е�)�����õĹ�����������ṥ����Щ����");
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARMON, "@" + M2Share.g_GameCommand.CLEARMON.sCmd + " ��ͼ��(* Ϊ����) ��������(* Ϊ����) ����Ʒ(0,1)", "�����ͼ�еĹ���(֧��Ȩ�޷���\')");
//            RefGameMasterCmd(M2Share.g_GameCommand.DISABLESENDMSG, "@" + M2Share.g_GameCommand.DISABLESENDMSG.sCmd + " ��������", "��ָ��������뷢�Թ����б������б���Լ����������Լ����Կ����������˿�����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.ENABLESENDMSG, "@" + M2Share.g_GameCommand.ENABLESENDMSG.sCmd, "��ָ������ӷ��Թ����б���ɾ��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DISABLESENDMSGLIST, "@" + M2Share.g_GameCommand.DISABLESENDMSGLIST.sCmd, "�鿴���Թ����б��е�����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHUTUP, "@" + M2Share.g_GameCommand.SHUTUP.sCmd + " ��������", "��ָ���������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.RELEASESHUTUP, "@" + M2Share.g_GameCommand.RELEASESHUTUP.sCmd + " ��������", "��ָ������ӽ����б���ɾ��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHUTUPLIST, "@" + M2Share.g_GameCommand.SHUTUPLIST.sCmd, "�鿴�����б��е�����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SABUKWALLGOLD, "@" + M2Share.g_GameCommand.SABUKWALLGOLD.sCmd, "�鿴�Ǳ������(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.STARTQUEST, "@" + M2Share.g_GameCommand.STARTQUEST.sCmd, "��ʼ���ʹ��ܣ���Ϸ��������ͬʱ�������ⴰ��(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DENYIPLOGON, "@" + M2Share.g_GameCommand.DENYIPLOGON.sCmd + " IP��ַ �Ƿ����÷�(0,1)", "��ָ��IP��ַ�����ֹ��¼�б�����ЩIP��¼���û����޷�������Ϸ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DENYACCOUNTLOGON, "@" + M2Share.g_GameCommand.DENYACCOUNTLOGON.sCmd + " ��¼�ʺ� �Ƿ����÷�(0,1)", "��ָ����¼�ʺż����ֹ��¼�б��Դ��ʺŵ�¼���û����޷�������Ϸ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DENYCHARNAMELOGON, "@" + M2Share.g_GameCommand.DENYCHARNAMELOGON.sCmd + " �������� �Ƿ����÷�(0,1)", "��ָ���������Ƽ����ֹ��¼�б������ｫ�޷�������Ϸ(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELDENYIPLOGON, "@" + M2Share.g_GameCommand.DELDENYIPLOGON.sCmd + " IP��ַ", "�ָ���ֹ��½IP(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELDENYACCOUNTLOGON, "@" + M2Share.g_GameCommand.DELDENYACCOUNTLOGON.sCmd + " ��¼�ʺ�", "�ָ���ֹ��½�ʺ�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.DELDENYCHARNAMELOGON, "@" + M2Share.g_GameCommand.DELDENYCHARNAMELOGON.sCmd + " ��������", "�ָ���ֹ��½����(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWDENYIPLOGON, "@" + M2Share.g_GameCommand.SHOWDENYIPLOGON.sCmd, "�鿴��ֹ��½IP(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWDENYACCOUNTLOGON, "@" + M2Share.g_GameCommand.SHOWDENYACCOUNTLOGON.sCmd, "�鿴��ֹ��½�ʺ�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWDENYCHARNAMELOGON, "@" + M2Share.g_GameCommand.SHOWDENYCHARNAMELOGON.sCmd, "�鿴��ֹ��¼��ɫ�б�(֧��Ȩ�޷���)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SetMapMode, "@" + M2Share.g_GameCommand.SetMapMode.sCmd, "���õ�ͼģʽ");
//            RefGameMasterCmd(M2Share.g_GameCommand.SHOWMAPMODE, "@" + M2Share.g_GameCommand.SHOWMAPMODE.sCmd, "��ʾ��ͼģʽ");
//            // RefGameMasterCmd(@g_GameCommand.Attack,//20080812 ע��
//            // '@' + g_GameCommand.Attack.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.LUCKYPOINT, "@" + M2Share.g_GameCommand.LUCKYPOINT.sCmd + " �������� ������(+,-,=) ����", "����ָ�����������ֵ(֧��Ȩ�޷���)");
//            // RefGameMasterCmd(@g_GameCommand.CHANGELUCK,//20080812 ע��
//            // '@' + g_GameCommand.CHANGELUCK.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.HUNGER, "@" + M2Share.g_GameCommand.HUNGER.sCmd + " �������� ����ֵ", "����ָ�����������ֵ(Ȩ��6����)");
//            // RefGameMasterCmd(@g_GameCommand.NAMECOLOR,//20080812 ע��
//            // '@' + g_GameCommand.NAMECOLOR.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.TRANSPARECY,
//            // '@' + g_GameCommand.TRANSPARECY.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.LEVEL0,
//            // '@' + g_GameCommand.LEVEL0.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.CHANGEITEMNAME, "@" + M2Share.g_GameCommand.CHANGEITEMNAME.sCmd + " ��Ʒ��� ��ƷID�� ��Ʒ����", "�ı���Ʒ����(Ȩ��6����)");
//            // RefGameMasterCmd(@g_GameCommand.ADDTOITEMEVENT,//20080812 ע��
//            // '@' + g_GameCommand.ADDTOITEMEVENT.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.ADDTOITEMEVENTASPIECES,
//            // '@' + g_GameCommand.ADDTOITEMEVENTASPIECES.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.ItemEventList,
//            // '@' + g_GameCommand.ItemEventList.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.STARTINGGIFTNO,
//            // '@' + g_GameCommand.STARTINGGIFTNO.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.DELETEALLITEMEVENT,
//            // '@' + g_GameCommand.DELETEALLITEMEVENT.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.STARTITEMEVENT,
//            // '@' + g_GameCommand.STARTITEMEVENT.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.ITEMEVENTTERM,
//            // '@' + g_GameCommand.ITEMEVENTTERM.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.OPDELETESKILL,
//            // '@' + g_GameCommand.OPDELETESKILL.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.CHANGEWEAPONDURA,
//            // '@' + g_GameCommand.CHANGEWEAPONDURA.sCmd,
//            // '');
//            // 
//            // RefGameMasterCmd(@g_GameCommand.SBKDOOR,
//            // '@' + g_GameCommand.SBKDOOR.sCmd,
//            // '');
//            RefGameMasterCmd(M2Share.g_GameCommand.SPIRIT, "@" + M2Share.g_GameCommand.SPIRIT.sCmd + "  ʱ��(��)", "���ڿ�ʼ����Ч�����ѱ�(Ȩ��6����)");
//            RefGameMasterCmd(M2Share.g_GameCommand.SPIRITSTOP, "@" + M2Share.g_GameCommand.SPIRITSTOP.sCmd, "����ֹͣ����Ч���±����ѱ�(Ȩ��6����)");
//            RefGameMasterCmd(M2Share.g_GameCommand.CLEARCOPYITEM, "@" + M2Share.g_GameCommand.CLEARCOPYITEM.sCmd + " ��������", "�����������ֿ⸴��Ʒ(֧��Ȩ�޷���)");
//        }

//        private void RefGameDebugCmd(TGameCmd GameCmd, string sCmdParam, string sDesc)
//        {
//            nRefGameDebugIndex ++;
            
//            if (StringGridGameMasterCmd.RowCount - 1 < nRefGameDebugIndex)
//            {
                
//                StringGridGameDebugCmd.RowCount = nRefGameDebugIndex + 1;
//            }
            
//            StringGridGameDebugCmd.Cells[0, nRefGameDebugIndex] = GameCmd.sCmd;
            
//            StringGridGameDebugCmd.Cells[1, nRefGameDebugIndex] = (GameCmd.nPermissionMin).ToString() + "/" + (GameCmd.nPermissionMax).ToString();
            
//            StringGridGameDebugCmd.Cells[2, nRefGameDebugIndex] = sCmdParam;
            
//            StringGridGameDebugCmd.Cells[3, nRefGameDebugIndex] = sDesc;
            
//            StringGridGameDebugCmd.Objects[0, nRefGameDebugIndex] = ((GameCmd) as Object);
//        }

//        // ��������
//        private void RefDebugCommand()
//        {
//            TGameCmd GameCmd;
//            EditGameDebugCmdOK.Enabled = false;
//            // StringGridGameDebugCmd.RowCount:=41;
//            GameCmd = M2Share.g_GameCommand.SHOWFLAG;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "");
//            GameCmd = M2Share.g_GameCommand.SETFLAG;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " �������� ��־�� ����(0 - 1)", "");
//            // GameCmd := @g_GameCommand.SHOWOPEN;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            // 
//            // GameCmd := @g_GameCommand.SETOPEN;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            // 
//            // GameCmd := @g_GameCommand.SHOWUNIT;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            // 
//            // GameCmd := @g_GameCommand.SETUNIT;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '');
//            GameCmd = M2Share.g_GameCommand.MOBNPC;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " NPC���� �ű��ļ��� ����(����) ��ɳ��(0,1)", "����NPC");
//            GameCmd = M2Share.g_GameCommand.DELNPC;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "ɾ��NPC(����NPC�����)");
//            GameCmd = M2Share.g_GameCommand.LOTTERYTICKET;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "�鿴��Ʊ�н�����");
//            GameCmd = M2Share.g_GameCommand.RELOADADMIN;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼��ع���Ա�б�");
//            GameCmd = M2Share.g_GameCommand.ReLoadNpc;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼���NPC�ű�");
//            GameCmd = M2Share.g_GameCommand.RELOADMANAGE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼��ص�¼�ű�");
//            GameCmd = M2Share.g_GameCommand.RELOADROBOTMANAGE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼��ػ���������");
//            GameCmd = M2Share.g_GameCommand.RELOADROBOT;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼��ػ����˽ű�");
//            GameCmd = M2Share.g_GameCommand.RELOADMONITEMS;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼��ع��ﱬ������");
//            // GameCmd := @g_GameCommand.RELOADDIARY; //20080812 ע��
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // 'δʹ��');
//            GameCmd = M2Share.g_GameCommand.RELOADITEMDB;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼�����Ʒ���ݿ�");
//            GameCmd = M2Share.g_GameCommand.RELOADMAGICDB;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼���ħ�����ݿ�");
//            GameCmd = M2Share.g_GameCommand.RELOADMONSTERDB;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼��ع������ݿ�");
//            GameCmd = M2Share.g_GameCommand.RELOADMINMAP;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼���С��ͼ����");
//            GameCmd = M2Share.g_GameCommand.RELOADGUILD;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " �л�����", "���¼���ָ�����л�");
//            // GameCmd := @g_GameCommand.RELOADGUILDALL;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // 'δʹ��');
//            GameCmd = M2Share.g_GameCommand.RELOADLINENOTICE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼�����Ϸ������Ϣ");
//            GameCmd = M2Share.g_GameCommand.RELOADABUSE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "���¼����໰��������");
//            GameCmd = M2Share.g_GameCommand.BACKSTEP;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " ����(0-8) ����", "�ƿ�����");
//            GameCmd = M2Share.g_GameCommand.RECONNECTION;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "��ָ�����������л���������");
//            GameCmd = M2Share.g_GameCommand.DISABLEFILTER;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd, "�����໰���˹���");
//            GameCmd = M2Share.g_GameCommand.CHGUSERFULL;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " ����", "���÷����������������");
//            GameCmd = M2Share.g_GameCommand.CHGZENFASTSTEP;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " �ٶ�", "���ù����ж��ٶ�");
//            // GameCmd := @g_GameCommand.OXQUIZROOM;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // 'δʹ��');
//            // 
//            // GameCmd := @g_GameCommand.BALL;//20080812 ע��
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // 'δʹ��');
//            GameCmd = M2Share.g_GameCommand.FIREBURN;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " ����(1-6) ʱ��(��) ����", "���ӳ���");
//            GameCmd = M2Share.g_GameCommand.TESTFIRE;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " ��Χ ����(1-6) ʱ��(��) ����", "��һ����Χ���ӳ���");
//            GameCmd = M2Share.g_GameCommand.TESTSTATUS;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " ����(0..11) ʱ��", "�ı��������ʱ����");
//            // GameCmd := @g_GameCommand.TESTGOLDCHANGE; //20080812 ע��
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // 'δʹ��');
//            // 
//            // GameCmd := @g_GameCommand.GSA;
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // 'δʹ��');
//            // GameCmd := @g_GameCommand.TESTGA;//20081014 ע��
//            // RefGameDebugCmd(GameCmd,
//            // '@' + GameCmd.sCmd,
//            // '����TESTGA����');
//            GameCmd = M2Share.g_GameCommand.MAPINFO;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " ��ͼ�� X Y", "��ʾ��ͼ��Ϣ");
//            GameCmd = M2Share.g_GameCommand.CLEARBAG;
//            RefGameDebugCmd(GameCmd, "@" + GameCmd.sCmd + " ��������", "�������ȫ����Ʒ");
//        }

//        public void StringGridGameMasterCmdClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            nIndex = StringGridGameMasterCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameMasterCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                EditGameMasterCmdName.Text = GameCmd.sCmd;
//                EditGameMasterCmdPerMission.Value = GameCmd.nPermissionMin;
                
//                LabelGameMasterCmdParam.Text = StringGridGameMasterCmd.Cells[2, nIndex];
                
//                LabelGameMasterCmdFunc.Text = StringGridGameMasterCmd.Cells[3, nIndex];
//            }
//            EditGameMasterCmdOK.Enabled = false;
//        }

//        public void EditGameMasterCmdNameChange(object sender, EventArgs e)
//        {
//            EditGameMasterCmdOK.Enabled = true;
//            EditGameMasterCmdSave.Enabled = true;
//        }

//        public void EditGameMasterCmdPerMissionChange(Object Sender)
//        {
//            EditGameMasterCmdOK.Enabled = true;
//            EditGameMasterCmdSave.Enabled = true;
//        }

//        public void EditGameMasterCmdOKClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            string sCmd;
//            int nPermission;
//            sCmd = EditGameMasterCmdName.Text.Trim();
//            nPermission = EditGameMasterCmdPerMission.Value;
//            if (sCmd == "")
//            {
//                System.Windows.Forms.MessageBox.Show("�������Ʋ���Ϊ�գ�����", "��ʾ��Ϣ", System.Windows.Forms.MessageBoxButtons.OK);
//                EditGameMasterCmdName.Focus();
//                return;
//            }
//            nIndex = StringGridGameMasterCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameMasterCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                GameCmd.sCmd = sCmd;
//                GameCmd.nPermissionMin = nPermission;
//            }
//            RefGameMasterCommand();
//        }

//        public void EditGameMasterCmdSaveClick(object sender, EventArgs e)
//        {
//            EditGameMasterCmdSave.Enabled = false;
            
//            M2Share.CommandConf.WriteString("Command", "ObServer", M2Share.g_GameCommand.OBSERVER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GameMaster", M2Share.g_GameCommand.GAMEMASTER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "SuperMan", M2Share.g_GameCommand.SUEPRMAN.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StorageClearPassword", M2Share.g_GameCommand.CLRPASSWORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ClearCopyItem", M2Share.g_GameCommand.CLEARCOPYITEM.sCmd);
//            // 20080816 ������Ҹ���Ʒ
            
//            M2Share.CommandConf.WriteString("Command", "Who", M2Share.g_GameCommand.WHO.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Total", M2Share.g_GameCommand.TOTAL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Make", M2Share.g_GameCommand.MAKE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PositionMove", M2Share.g_GameCommand.POSITIONMOVE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Move", M2Share.g_GameCommand.Move.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Recall", M2Share.g_GameCommand.RECALL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ReGoto", M2Share.g_GameCommand.REGOTO.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Ting", M2Share.g_GameCommand.TING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "SuperTing", M2Share.g_GameCommand.SUPERTING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MapMove", M2Share.g_GameCommand.MAPMOVE.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Info", M2Share.g_GameCommand.INFO.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "HumanLocal", M2Share.g_GameCommand.HUMANLOCAL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ViewWhisper", M2Share.g_GameCommand.VIEWWHISPER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobCount", M2Share.g_GameCommand.MOBCOUNT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "HumanCount", M2Share.g_GameCommand.HUMANCOUNT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Map", M2Share.g_GameCommand.Map.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Level", M2Share.g_GameCommand.Level.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Kick", M2Share.g_GameCommand.KICK.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ReAlive", M2Share.g_GameCommand.ReAlive.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Kill", M2Share.g_GameCommand.KILL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeJob", M2Share.g_GameCommand.CHANGEJOB.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "FreePenalty", M2Share.g_GameCommand.FREEPENALTY.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "PkPoint", M2Share.g_GameCommand.PKPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "IncPkPoint", M2Share.g_GameCommand.IncPkPoint.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeGender", M2Share.g_GameCommand.CHANGEGENDER.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Hair", M2Share.g_GameCommand.HAIR.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "BonusPoint", M2Share.g_GameCommand.BonusPoint.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DelBonuPoint", M2Share.g_GameCommand.DELBONUSPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RestBonuPoint", M2Share.g_GameCommand.RESTBONUSPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "SetPermission", M2Share.g_GameCommand.SETPERMISSION.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ReNewLevel", M2Share.g_GameCommand.RENEWLEVEL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DelGold", M2Share.g_GameCommand.DELGOLD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AddGold", M2Share.g_GameCommand.ADDGOLD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GameGold", M2Share.g_GameCommand.GAMEGOLD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "GameDiaMond", M2Share.g_GameCommand.GAMEDIAMOND.sCmd);
//            // 20071226 ���ʯ
            
//            M2Share.CommandConf.WriteString("Command", "GameGird", M2Share.g_GameCommand.GAMEGIRD.sCmd);
//            // 20071226 ���
            
//            M2Share.CommandConf.WriteString("Command", "HEROLOYAL", M2Share.g_GameCommand.HEROLOYAL.sCmd);
//            // 20080109 Ӣ�۵��ҳ϶�
            
//            M2Share.CommandConf.WriteString("Command", "GamePoint", M2Share.g_GameCommand.GAMEPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "CreditPoint", M2Share.g_GameCommand.CREDITPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RefineWeapon", M2Share.g_GameCommand.REFINEWEAPON.sCmd);
//            // g_GameCommand.SysMsg.sCmd
            
//            M2Share.CommandConf.WriteString("Command", "SysMsg", "��");
//            // ǧ�ﴫ�� 20071228
            
//            M2Share.CommandConf.WriteString("Command", "HEROLEVEL", M2Share.g_GameCommand.HEROLEVEL.sCmd);
//            // ����Ӣ�۵ȼ� 20071227
            
//            M2Share.CommandConf.WriteString("Command", "AdjuestTLevel", M2Share.g_GameCommand.ADJUESTLEVEL.sCmd);
//            // ��������ȼ�
            
//            M2Share.CommandConf.WriteString("Command", "NGLevel", M2Share.g_GameCommand.NGLEVEL.sCmd);
//            // ���������ڹ��ȼ� 20081221
            
//            M2Share.CommandConf.WriteString("Command", "AdjuestExp", M2Share.g_GameCommand.ADJUESTEXP.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeDearName", M2Share.g_GameCommand.CHANGEDEARNAME.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeMasterrName", M2Share.g_GameCommand.CHANGEMASTERNAME.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RecallMob", M2Share.g_GameCommand.RECALLMOB.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "RECALLMOBEX", M2Share.g_GameCommand.RECALLMOBEX.sCmd);
//            // 20080122 �ٻ�����
            
//            M2Share.CommandConf.WriteString("Command", "GIVEMINE", M2Share.g_GameCommand.GIVEMINE.sCmd);
//            // 20080403 ��ָ�����ȵĿ�ʯ
            
//            M2Share.CommandConf.WriteString("Command", "MOVEMOBTO", M2Share.g_GameCommand.MOVEMOBTO.sCmd);
//            // 20080123 ��ָ������Ĺ����ƶ���������
            
//            M2Share.CommandConf.WriteString("Command", "CLEARITEMMAP", M2Share.g_GameCommand.CLEARITEMMAP.sCmd);
//            // 20080124 �����ͼ��Ʒ
            
//            M2Share.CommandConf.WriteString("Command", "Training", M2Share.g_GameCommand.TRAINING.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "OpTraining", M2Share.g_GameCommand.TRAININGSKILL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DeleteSkill", M2Share.g_GameCommand.DELETESKILL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DeleteItem", M2Share.g_GameCommand.DELETEITEM.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ClearMission", M2Share.g_GameCommand.CLEARMISSION.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "AddGuild", M2Share.g_GameCommand.AddGuild.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "DelGuild", M2Share.g_GameCommand.DELGUILD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ChangeSabukLord", M2Share.g_GameCommand.CHANGESABUKLORD.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ForcedWallConQuestWar", M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "ContestPoint", M2Share.g_GameCommand.CONTESTPOINT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "StartContest", M2Share.g_GameCommand.STARTCONTEST.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "EndContest", M2Share.g_GameCommand.ENDCONTEST.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Announcement", M2Share.g_GameCommand.ANNOUNCEMENT.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "Mission", M2Share.g_GameCommand.Mission.sCmd);
            
//            M2Share.CommandConf.WriteString("Command", "MobPlace", M2Share.g_GameCommand.MobPlace.sCmd);
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameMaster", M2Share.g_GameCommand.GAMEMASTER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ObServer", M2Share.g_GameCommand.OBSERVER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SuperMan", M2Share.g_GameCommand.SUEPRMAN.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "StorageClearPassword", M2Share.g_GameCommand.CLRPASSWORD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ClearCopyItem", M2Share.g_GameCommand.CLEARCOPYITEM.nPermissionMin);
//            // 20080816 ������Ҹ���Ʒ
            
//            M2Share.CommandConf.WriteInteger("Permission", "Who", M2Share.g_GameCommand.WHO.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Total", M2Share.g_GameCommand.TOTAL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MakeMin", M2Share.g_GameCommand.MAKE.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MakeMax", M2Share.g_GameCommand.MAKE.nPermissionMax);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PositionMoveMin", M2Share.g_GameCommand.POSITIONMOVE.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PositionMoveMax", M2Share.g_GameCommand.POSITIONMOVE.nPermissionMax);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MoveMin", M2Share.g_GameCommand.Move.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MoveMax", M2Share.g_GameCommand.Move.nPermissionMax);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Recall", M2Share.g_GameCommand.RECALL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ReGoto", M2Share.g_GameCommand.REGOTO.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Ting", M2Share.g_GameCommand.TING.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SuperTing", M2Share.g_GameCommand.SUPERTING.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MapMove", M2Share.g_GameCommand.MAPMOVE.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Info", M2Share.g_GameCommand.INFO.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "HumanLocal", M2Share.g_GameCommand.HUMANLOCAL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ViewWhisper", M2Share.g_GameCommand.VIEWWHISPER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobCount", M2Share.g_GameCommand.MOBCOUNT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "HumanCount", M2Share.g_GameCommand.HUMANCOUNT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Map", M2Share.g_GameCommand.Map.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Level", M2Share.g_GameCommand.Level.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Kick", M2Share.g_GameCommand.KICK.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ReAlive", M2Share.g_GameCommand.ReAlive.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Kill", M2Share.g_GameCommand.KILL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeJob", M2Share.g_GameCommand.CHANGEJOB.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "FreePenalty", M2Share.g_GameCommand.FREEPENALTY.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "PkPoint", M2Share.g_GameCommand.PKPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "IncPkPoint", M2Share.g_GameCommand.IncPkPoint.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeGender", M2Share.g_GameCommand.CHANGEGENDER.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Hair", M2Share.g_GameCommand.HAIR.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "BonusPoint", M2Share.g_GameCommand.BonusPoint.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DelBonuPoint", M2Share.g_GameCommand.DELBONUSPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RestBonuPoint", M2Share.g_GameCommand.RESTBONUSPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SetPermission", M2Share.g_GameCommand.SETPERMISSION.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ReNewLevel", M2Share.g_GameCommand.RENEWLEVEL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DelGold", M2Share.g_GameCommand.DELGOLD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "AddGold", M2Share.g_GameCommand.ADDGOLD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameGold", M2Share.g_GameCommand.GAMEGOLD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameDiaMond", M2Share.g_GameCommand.GAMEDIAMOND.nPermissionMin);
//            // 20071226 ���ʯ
            
//            M2Share.CommandConf.WriteInteger("Permission", "GameGird", M2Share.g_GameCommand.GAMEGIRD.nPermissionMin);
//            // 20071226 ���
            
//            M2Share.CommandConf.WriteInteger("Permission", "HEROLOYAL", M2Share.g_GameCommand.HEROLOYAL.nPermissionMin);
//            // 20080109 Ӣ�۵��ҳ϶�
            
//            M2Share.CommandConf.WriteInteger("Permission", "GamePoint", M2Share.g_GameCommand.GAMEPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "CreditPoint", M2Share.g_GameCommand.CREDITPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RefineWeapon", M2Share.g_GameCommand.REFINEWEAPON.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "SysMsg", M2Share.g_GameCommand.SysMsg.nPermissionMin);
//            // ǧ�ﴫ�� 20071228
            
//            M2Share.CommandConf.WriteInteger("Permission", "HEROLEVEL", M2Share.g_GameCommand.HEROLEVEL.nPermissionMin);
//            // ����Ӣ�۵ȼ� 20071227
            
//            M2Share.CommandConf.WriteInteger("Permission", "AdjuestTLevel", M2Share.g_GameCommand.ADJUESTLEVEL.nPermissionMin);
//            // ��������ȼ�
            
//            M2Share.CommandConf.WriteInteger("Permission", "NGLevel", M2Share.g_GameCommand.NGLEVEL.nPermissionMin);
//            // ���������ڹ��ȼ� 20081221
            
//            M2Share.CommandConf.WriteInteger("Permission", "AdjuestExp", M2Share.g_GameCommand.ADJUESTEXP.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeDearName", M2Share.g_GameCommand.CHANGEDEARNAME.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeMasterName", M2Share.g_GameCommand.CHANGEMASTERNAME.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RecallMob", M2Share.g_GameCommand.RECALLMOB.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "RECALLMOBEX", M2Share.g_GameCommand.RECALLMOBEX.nPermissionMin);
//            // 20080122 �ٻ�����
            
//            M2Share.CommandConf.WriteInteger("Permission", "GIVEMINE", M2Share.g_GameCommand.GIVEMINE.nPermissionMin);
//            // 20080403 ��ָ�����ȵĿ�ʯ
            
//            M2Share.CommandConf.WriteInteger("Permission", "MOVEMOBTO", M2Share.g_GameCommand.MOVEMOBTO.nPermissionMin);
//            // 20080123 ��ָ������Ĺ����ƶ���������
            
//            M2Share.CommandConf.WriteInteger("Permission", "CLEARITEMMAP", M2Share.g_GameCommand.CLEARITEMMAP.nPermissionMin);
//            // 20080124 �����ͼ��Ʒ
            
//            M2Share.CommandConf.WriteInteger("Permission", "Training", M2Share.g_GameCommand.TRAINING.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "OpTraining", M2Share.g_GameCommand.TRAININGSKILL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DeleteSkill", M2Share.g_GameCommand.DELETESKILL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DeleteItem", M2Share.g_GameCommand.DELETEITEM.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ClearMission", M2Share.g_GameCommand.CLEARMISSION.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "AddGuild", M2Share.g_GameCommand.AddGuild.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "DelGuild", M2Share.g_GameCommand.DELGUILD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ChangeSabukLord", M2Share.g_GameCommand.CHANGESABUKLORD.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ForcedWallConQuestWar", M2Share.g_GameCommand.FORCEDWALLCONQUESTWAR.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "ContestPoint", M2Share.g_GameCommand.CONTESTPOINT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "StartContest", M2Share.g_GameCommand.STARTCONTEST.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "EndContest", M2Share.g_GameCommand.ENDCONTEST.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Announcement", M2Share.g_GameCommand.ANNOUNCEMENT.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobLevel", M2Share.g_GameCommand.MOBLEVEL.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "Mission", M2Share.g_GameCommand.Mission.nPermissionMin);
            
//            M2Share.CommandConf.WriteInteger("Permission", "MobPlace", M2Share.g_GameCommand.MobPlace.nPermissionMin);
//        }

//        public void StringGridGameDebugCmdClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            nIndex = StringGridGameDebugCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameDebugCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                EditGameDebugCmdName.Text = GameCmd.sCmd;
//                EditGameDebugCmdPerMission.Value = GameCmd.nPermissionMin;
                
//                LabelGameDebugCmdParam.Text = StringGridGameDebugCmd.Cells[2, nIndex];
                
//                LabelGameDebugCmdFunc.Text = StringGridGameDebugCmd.Cells[3, nIndex];
//            }
//            EditGameDebugCmdOK.Enabled = false;
//        }

//        public void EditGameDebugCmdNameChange(object sender, EventArgs e)
//        {
//            EditGameDebugCmdOK.Enabled = true;
//            EditGameDebugCmdSave.Enabled = true;
//        }

//        public void EditGameDebugCmdPerMissionChange(Object Sender)
//        {
//            EditGameDebugCmdOK.Enabled = true;
//            EditGameDebugCmdSave.Enabled = true;
//        }

//        public void EditGameDebugCmdOKClick(object sender, EventArgs e)
//        {
//            int nIndex;
//            TGameCmd GameCmd;
//            string sCmd;
//            int nPermission;
//            sCmd = EditGameDebugCmdName.Text.Trim();
//            nPermission = EditGameDebugCmdPerMission.Value;
//            if (sCmd == "")
//            {
//                System.Windows.Forms.MessageBox.Show("�������Ʋ���Ϊ�գ�����", "��ʾ��Ϣ", System.Windows.Forms.MessageBoxButtons.OK + System.Windows.Forms.MessageBoxIcon.Error);
//                EditGameDebugCmdName.Focus();
//                return;
//            }
//            nIndex = StringGridGameDebugCmd.CurrentRowIndex;
            
//            GameCmd = ((TGameCmd)(StringGridGameDebugCmd.Objects[0, nIndex]));
//            if (GameCmd != null)
//            {
//                GameCmd.sCmd = sCmd;
//                GameCmd.nPermissionMin = nPermission;
//            }
//            RefDebugCommand();
//        }

//        public void EditGameDebugCmdSaveClick(object sender, EventArgs e)
//        {
//            EditGameDebugCmdSave.Enabled = false;
//        }

//        public void FormDestroy(Object Sender)
//        {
//            Units.GameCommand.frmGameCmd = null;
//        }

//        public void FormClose(object sender, EventArgs e)
//        {
            
//            Action = caFree;
//        }

    } 
}

