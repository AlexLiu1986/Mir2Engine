using System;
using System.Windows.Forms;

namespace M2Server
{
    public partial class TfrmHumanInfo: Form
    {
//            public static TfrmHumanInfo frmHumanInfo = null;
//        public static bool boRefHuman = false;
//        public TPlayObject PlayObject = null;
//        public TfrmHumanInfo()
//        {
//            InitializeComponent();
//        }

//        public void FormCreate(object sender, EventArgs e)
//        {
//            GridUserItem->Cells[0, 0] = "װ��λ��";
//            GridUserItem->Cells[1, 0] = "װ������";
//            GridUserItem->Cells[2, 0] = "ϵ�к�";
//            GridUserItem->Cells[3, 0] = "�־�";
//            GridUserItem->Cells[4, 0] = "��";
//            GridUserItem->Cells[5, 0] = "ħ";
//            GridUserItem->Cells[6, 0] = "��";
//            GridUserItem->Cells[7, 0] = "��";
//            GridUserItem->Cells[8, 0] = "ħ��";
//            GridUserItem->Cells[9, 0] = "��������";
//            GridUserItem->Cells[0, 1] = "�·�";
//            GridUserItem->Cells[0, 2] = "����";
//            GridUserItem->Cells[0, 3] = "������";
//            GridUserItem->Cells[0, 4] = "����";
//            GridUserItem->Cells[0, 5] = "ͷ��";
//            GridUserItem->Cells[0, 6] = "������";
//            GridUserItem->Cells[0, 7] = "������";
//            GridUserItem->Cells[0, 8] = "���ָ";
//            GridUserItem->Cells[0, 9] = "�ҽ�ָ";
//            GridUserItem->Cells[0, 10] = "��Ʒ";
//            GridUserItem->Cells[0, 11] = "����";
//            GridUserItem->Cells[0, 12] = "Ь��";
//            GridUserItem->Cells[0, 13] = "��ʯ";
//            GridBagItem.Cells[0, 0] = "���";
//            GridBagItem.Cells[1, 0] = "װ������";
//            GridBagItem.Cells[2, 0] = "ϵ�к�";
//            GridBagItem.Cells[3, 0] = "�־�";
//            GridBagItem.Cells[4, 0] = "��";
//            GridBagItem.Cells[5, 0] = "ħ";
//            GridBagItem.Cells[6, 0] = "��";
//            GridBagItem.Cells[7, 0] = "��";
//            GridBagItem.Cells[8, 0] = "ħ��";
//            GridBagItem.Cells[9, 0] = "��������";
//            GridStorageItem.Cells[0, 0] = "���";
//            GridStorageItem.Cells[1, 0] = "װ������";
//            GridStorageItem.Cells[2, 0] = "ϵ�к�";
//            GridStorageItem.Cells[3, 0] = "�־�";
//            GridStorageItem.Cells[4, 0] = "��";
//            GridStorageItem.Cells[5, 0] = "ħ";
//            GridStorageItem.Cells[6, 0] = "��";
//            GridStorageItem.Cells[7, 0] = "��";
//            GridStorageItem.Cells[8, 0] = "ħ��";
//            GridStorageItem.Cells[9, 0] = "��������";
//            GridHeroUserItem->Cells[0, 0] = "װ��λ��";
//            GridHeroUserItem->Cells[1, 0] = "װ������";
//            GridHeroUserItem->Cells[2, 0] = "ϵ�к�";
//            GridHeroUserItem->Cells[3, 0] = "�־�";
//            GridHeroUserItem->Cells[4, 0] = "��";
//            GridHeroUserItem->Cells[5, 0] = "ħ";
//            GridHeroUserItem->Cells[6, 0] = "��";
//            GridHeroUserItem->Cells[7, 0] = "��";
//            GridHeroUserItem->Cells[8, 0] = "ħ��";
//            GridHeroUserItem->Cells[9, 0] = "��������";
//            GridHeroUserItem->Cells[0, 1] = "�·�";
//            GridHeroUserItem->Cells[0, 2] = "����";
//            GridHeroUserItem->Cells[0, 3] = "������";
//            GridHeroUserItem->Cells[0, 4] = "����";
//            GridHeroUserItem->Cells[0, 5] = "ͷ��";
//            GridHeroUserItem->Cells[0, 6] = "������";
//            GridHeroUserItem->Cells[0, 7] = "������";
//            GridHeroUserItem->Cells[0, 8] = "���ָ";
//            GridHeroUserItem->Cells[0, 9] = "�ҽ�ָ";
//            GridHeroUserItem->Cells[0, 10] = "��Ʒ";
//            GridHeroUserItem->Cells[0, 11] = "����";
//            GridHeroUserItem->Cells[0, 12] = "Ь��";
//            GridHeroUserItem->Cells[0, 13] = "��ʯ";
//            GridHeroBagItem.Cells[0, 0] = "���";
//            GridHeroBagItem.Cells[1, 0] = "װ������";
//            GridHeroBagItem.Cells[2, 0] = "ϵ�к�";
//            GridHeroBagItem.Cells[3, 0] = "�־�";
//            GridHeroBagItem.Cells[4, 0] = "��";
//            GridHeroBagItem.Cells[5, 0] = "ħ";
//            GridHeroBagItem.Cells[6, 0] = "��";
//            GridHeroBagItem.Cells[7, 0] = "��";
//            GridHeroBagItem.Cells[8, 0] = "ħ��";
//            GridHeroBagItem.Cells[9, 0] = "��������";
//            PageControl1.SelectedIndex = 0;
//            PageControl1.TabPages[6].TabVisible = true;
//            PageControl1.TabPages[7].TabVisible = true;
//            PageControl1.TabPages[8].TabVisible = true;
//            PageControl1.TabPages[6].TabVisible = false;
//            PageControl1.TabPages[7].TabVisible = false;
//            PageControl1.TabPages[8].TabVisible = false;
//        }

//        public void Open()
//        {
//            PageControl1.SelectedTab = TabSheet1;
//            // 20080901 ����
//            RefHumanInfo();
//            ButtonKick.Enabled = true;
//            Timer.Enabled = true;
//            this.ShowDialog();
//            CheckBoxMonitor.Checked = false;
//            Timer.Enabled = false;
//        }

//        private void RefHumanInfo()
//        {
//            int I;
//            int nTotleUsePoint;
//            TStdItem StdItem;
//            TStdItem Item;
//            TUserItem* UserItem;
//            if ((PlayObject == null))
//            {
//                return;
//            }
//            if (PlayObject.m_boNotOnlineAddExp)
//            {
//                EditSayMsg.Enabled = true;
//            }
//            else
//            {
//                EditSayMsg.Enabled = false;
//            }
//            EditSayMsg.Text = PlayObject.m_sAutoSendMsg;
//            EditName.Text = PlayObject.m_sCharName;
//            EditMap.Text = PlayObject.m_sMapName + "(" + PlayObject.m_PEnvir.sMapDesc + ")";
//            EditXY.Text = (PlayObject.m_nCurrX).ToString() + ":" + (PlayObject.m_nCurrY).ToString();
//            EditAccount.Text = PlayObject.m_sUserID;
//            EditIPaddr.Text = PlayObject.m_sIPaddr;
//            EditLogonTime.Text = (PlayObject.m_dLogonTime).ToString();
            
//            // (60 * 1000)
//            EditLogonLong.Text = ((GetTickCount - PlayObject.m_dwLogonTick) / 60000).ToString() + " ����";
//            EditLevel.Value = PlayObject.m_Abil.Level;
//            EditGold.Value = PlayObject.m_nGold;
//            EditPKPoint.Value = PlayObject.m_nPkPoint;
//            EditExp.Value = PlayObject.m_Abil.Exp;
//            EditMaxExp.Value = PlayObject.m_Abil.MaxExp;
//            if (PlayObject.m_boTrainingNG)
//            {
//                EditNGLevel.Enabled = true;
//                EditExpSkill69.Enabled = true;
//                EditNGLevel.Value = PlayObject.m_NGLevel;
//                // 20081005 �ڹ��ȼ�
//                EditExpSkill69.Value = PlayObject.m_ExpSkill69;
//            // 20081005 �ڹ��ķ���ǰ����
//            }
            
            
//            EditAC.Text = (LoWord(PlayObject.m_WAbil.AC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.AC)).ToString();
//            // ����
            
            
//            EditMAC.Text = (LoWord(PlayObject.m_WAbil.MAC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.MAC)).ToString();
//            // ħ��
            
            
//            EditDC.Text = (LoWord(PlayObject.m_WAbil.DC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.DC)).ToString();
//            // ������
            
            
//            EditMC.Text = (LoWord(PlayObject.m_WAbil.MC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.MC)).ToString();
//            // ħ��
            
            
//            EditSC.Text = (LoWord(PlayObject.m_WAbil.SC)).ToString() + "/" + (HiWord(PlayObject.m_WAbil.SC)).ToString();
//            // ����
//            EditHP.Text = (PlayObject.m_WAbil.HP).ToString() + "/" + (PlayObject.m_WAbil.MaxHP).ToString();
//            EditMP.Text = (PlayObject.m_WAbil.MP).ToString() + "/" + (PlayObject.m_WAbil.MaxMP).ToString();
//            EditGameGold.Value = PlayObject.m_nGameGold;
//            EditGameDiaMond.Value = PlayObject.m_nGAMEDIAMOND;
//            // ���ʯ
//            EditGameGird.Value = PlayObject.m_nGAMEGIRD;
//            // ���
//            EditGamePoint.Value = PlayObject.m_nGamePoint;
//            EditCreditPoint.Value = PlayObject.m_btCreditPoint;
//            EditBonusPoint.Value = PlayObject.m_nBonusPoint;
//            nTotleUsePoint = PlayObject.m_BonusAbil.DC + PlayObject.m_BonusAbil.MC + PlayObject.m_BonusAbil.SC + PlayObject.m_BonusAbil.AC + PlayObject.m_BonusAbil.MAC + PlayObject.m_BonusAbil.HP + PlayObject.m_BonusAbil.MP + PlayObject.m_BonusAbil.Hit + PlayObject.m_BonusAbil.Speed + PlayObject.m_BonusAbil.X2;
//            EditEditBonusPointUsed.Value = nTotleUsePoint;
//            CheckBoxGameMaster.Checked = PlayObject.m_boAdminMode;
//            CheckBoxSuperMan.Checked = PlayObject.m_boSuperMan;
//            CheckBoxObserver.Checked = PlayObject.m_boObMode;
//            if (PlayObject.m_boDeath)
//            {
//                EditHumanStatus.Text = "����";
//            }
//            else if (PlayObject.m_boGhost)
//            {
//                EditHumanStatus.Text = "����";
//                PlayObject = null;
//            }
//            else
//            {
//                EditHumanStatus.Text = "����";
//            }
//            for (I = PlayObject.m_UseItems.GetLowerBound(0); I <= PlayObject.m_UseItems.GetUpperBound(0); I ++ )
//            {
//                UserItem = PlayObject.m_UseItems[I];
//                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
//                if (StdItem == null)
//                {
                    
//                    GridUserItem->Cells[1, I + 1] = "";
                    
//                    GridUserItem->Cells[2, I + 1] = "";
                    
//                    GridUserItem->Cells[3, I + 1] = "";
                    
//                    GridUserItem->Cells[4, I + 1] = "";
                    
//                    GridUserItem->Cells[5, I + 1] = "";
                    
//                    GridUserItem->Cells[6, I + 1] = "";
                    
//                    GridUserItem->Cells[7, I + 1] = "";
                    
//                    GridUserItem->Cells[8, I + 1] = "";
                    
//                    GridUserItem->Cells[9, I + 1] = "";
//                    continue;
//                }
//                Item = StdItem;
//                M2Share.ItemUnit.GetItemAddValue(UserItem, ref Item);
                
//                GridUserItem->Cells[1, I + 1] = Item.Name;
                
//                GridUserItem->Cells[2, I + 1] = (UserItem->MakeIndex).ToString();
                
                
//                GridUserItem->Cells[3, I + 1] = string.Format("%d/%d", new ushort[] {UserItem->Dura, UserItem->DuraMax});
                
                
                
                
//                GridUserItem->Cells[4, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.DC), HiWord(Item.DC)});
                
                
                
                
//                GridUserItem->Cells[5, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MC), HiWord(Item.MC)});
                
                
                
                
//                GridUserItem->Cells[6, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.SC), HiWord(Item.SC)});
                
                
                
                
//                GridUserItem->Cells[7, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.AC), HiWord(Item.AC)});
                
                
                
                
//                GridUserItem->Cells[8, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MAC), HiWord(Item.MAC)});
                
                
//                GridUserItem->Cells[9, I + 1] = string.Format("%d/%d/%d/%d/%d/%d/%d", new byte[] {UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]});
//            }
//            if (PlayObject.m_ItemList.Count <= 0)
//            {
                
//                GridBagItem.RowCount = 2;
//            }
//            else
//            {
                
//                GridBagItem.RowCount = PlayObject.m_ItemList.Count + 1;
//            }
//            if (PlayObject.m_ItemList.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < PlayObject.m_ItemList.Count; I ++ )
//                {
//                    UserItem = PlayObject.m_ItemList[I];
//                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
//                    if (StdItem == null)
//                    {
                        
//                        GridBagItem.Cells[1, I + 1] = "";
                        
//                        GridBagItem.Cells[2, I + 1] = "";
                        
//                        GridBagItem.Cells[3, I + 1] = "";
                        
//                        GridBagItem.Cells[4, I + 1] = "";
                        
//                        GridBagItem.Cells[5, I + 1] = "";
                        
//                        GridBagItem.Cells[6, I + 1] = "";
                        
//                        GridBagItem.Cells[7, I + 1] = "";
                        
//                        GridBagItem.Cells[8, I + 1] = "";
                        
//                        GridBagItem.Cells[9, I + 1] = "";
//                        continue;
//                    }
//                    Item = StdItem;
//                    M2Share.ItemUnit.GetItemAddValue(UserItem, ref Item);
                    
//                    GridBagItem.Cells[0, I + 1] = (I).ToString();
                    
//                    GridBagItem.Cells[1, I + 1] = Item.Name;
                    
//                    GridBagItem.Cells[2, I + 1] = (UserItem->MakeIndex).ToString();
                    
                    
//                    GridBagItem.Cells[3, I + 1] = string.Format("%d/%d", new ushort[] {UserItem->Dura, UserItem->DuraMax});
                    
                    
                    
                    
//                    GridBagItem.Cells[4, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.DC), HiWord(Item.DC)});
                    
                    
                    
                    
//                    GridBagItem.Cells[5, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MC), HiWord(Item.MC)});
                    
                    
                    
                    
//                    GridBagItem.Cells[6, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.SC), HiWord(Item.SC)});
                    
                    
                    
                    
//                    GridBagItem.Cells[7, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.AC), HiWord(Item.AC)});
                    
                    
                    
                    
//                    GridBagItem.Cells[8, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MAC), HiWord(Item.MAC)});
                    
                    
//                    GridBagItem.Cells[9, I + 1] = string.Format("%d/%d/%d/%d/%d/%d/%d", new byte[] {UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]});
//                }
//            }
//            if (PlayObject.m_StorageItemList.Count <= 0)
//            {
                
//                GridStorageItem.RowCount = 2;
//            }
//            else
//            {
                
//                GridStorageItem.RowCount = PlayObject.m_StorageItemList.Count + 1;
//            }
//            if (PlayObject.m_StorageItemList.Count > 0)
//            {
//                // 20080630
//                for (I = 0; I < PlayObject.m_StorageItemList.Count; I ++ )
//                {
//                    UserItem = PlayObject.m_StorageItemList[I];
//                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
//                    if (StdItem == null)
//                    {
                        
//                        GridStorageItem.Cells[1, I + 1] = "";
                        
//                        GridStorageItem.Cells[2, I + 1] = "";
                        
//                        GridStorageItem.Cells[3, I + 1] = "";
                        
//                        GridStorageItem.Cells[4, I + 1] = "";
                        
//                        GridStorageItem.Cells[5, I + 1] = "";
                        
//                        GridStorageItem.Cells[6, I + 1] = "";
                        
//                        GridStorageItem.Cells[7, I + 1] = "";
                        
//                        GridStorageItem.Cells[8, I + 1] = "";
                        
//                        GridStorageItem.Cells[9, I + 1] = "";
//                        continue;
//                    }
//                    Item = StdItem;
//                    M2Share.ItemUnit.GetItemAddValue(UserItem, ref Item);
                    
//                    GridStorageItem.Cells[0, I + 1] = (I).ToString();
                    
//                    GridStorageItem.Cells[1, I + 1] = Item.Name;
                    
//                    GridStorageItem.Cells[2, I + 1] = (UserItem->MakeIndex).ToString();
                    
                    
//                    GridStorageItem.Cells[3, I + 1] = string.Format("%d/%d", new ushort[] {UserItem->Dura, UserItem->DuraMax});
                    
                    
                    
                    
//                    GridStorageItem.Cells[4, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.DC), HiWord(Item.DC)});
                    
                    
                    
                    
//                    GridStorageItem.Cells[5, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MC), HiWord(Item.MC)});
                    
                    
                    
                    
//                    GridStorageItem.Cells[6, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.SC), HiWord(Item.SC)});
                    
                    
                    
                    
//                    GridStorageItem.Cells[7, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.AC), HiWord(Item.AC)});
                    
                    
                    
                    
//                    GridStorageItem.Cells[8, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MAC), HiWord(Item.MAC)});
                    
                    
//                    GridStorageItem.Cells[9, I + 1] = string.Format("%d/%d/%d/%d/%d/%d/%d", new byte[] {UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]});
//                }
//            }
//#if HEROVERSION = 1
//            try {
//                if (PlayObject.m_MyHero == null)
//                {
//                    return;
//                }
//                EditHeroName.Text = PlayObject.m_MyHero.m_sCharName;
//                EditHeroMap.Text = PlayObject.m_MyHero.m_sMapName + "(" + PlayObject.m_PEnvir.sMapDesc + ")";
//                EditHeroXY.Text = (PlayObject.m_MyHero.m_nCurrX).ToString() + ":" + (PlayObject.m_MyHero.m_nCurrY).ToString();
//                EditHeroLevel.Value = PlayObject.m_MyHero.m_Abil.Level;
//                EditHeroPKPoint.Value = PlayObject.m_MyHero.m_nPkPoint;
//                EditHeroExp.Value = PlayObject.m_MyHero.m_Abil.Exp;
//                EditHeroMaxExp.Value = PlayObject.m_MyHero.m_Abil.MaxExp;
//                EditHeroLoyal.Value = ((THeroObject)(PlayObject.m_MyHero)).m_nLoyal;
//                // Ӣ�۵��ҳ϶�(20080110)
//                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
//                {
//                    EditHeroNGLevel.Enabled = true;
//                    EditHeroExpSkill69.Enabled = true;
//                    EditHeroNGLevel.Value = ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel;
//                    // 20081005 �ڹ��ȼ�
//                    EditHeroExpSkill69.Value = ((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69;
//                // 20081005 �ڹ��ķ���ǰ����
//                }
//                for (I = PlayObject.m_MyHero.m_UseItems.GetLowerBound(0); I <= PlayObject.m_MyHero.m_UseItems.GetUpperBound(0); I ++ )
//                {
//                    UserItem = PlayObject.m_MyHero.m_UseItems[I];
//                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
//                    if (StdItem == null)
//                    {
                        
//                        GridHeroUserItem->Cells[1, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[2, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[3, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[4, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[5, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[6, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[7, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[8, I + 1] = "";
                        
//                        GridHeroUserItem->Cells[9, I + 1] = "";
//                        continue;
//                    }
//                    Item = StdItem;
//                    M2Share.ItemUnit.GetItemAddValue(UserItem, ref Item);
                    
//                    GridHeroUserItem->Cells[1, I + 1] = Item.Name;
                    
//                    GridHeroUserItem->Cells[2, I + 1] = (UserItem->MakeIndex).ToString();
                    
                    
//                    GridHeroUserItem->Cells[3, I + 1] = string.Format("%d/%d", new ushort[] {UserItem->Dura, UserItem->DuraMax});
                    
                    
                    
                    
//                    GridHeroUserItem->Cells[4, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.DC), HiWord(Item.DC)});
                    
                    
                    
                    
//                    GridHeroUserItem->Cells[5, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MC), HiWord(Item.MC)});
                    
                    
                    
                    
//                    GridHeroUserItem->Cells[6, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.SC), HiWord(Item.SC)});
                    
                    
                    
                    
//                    GridHeroUserItem->Cells[7, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.AC), HiWord(Item.AC)});
                    
                    
                    
                    
//                    GridHeroUserItem->Cells[8, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MAC), HiWord(Item.MAC)});
                    
                    
//                    GridHeroUserItem->Cells[9, I + 1] = string.Format("%d/%d/%d/%d/%d/%d/%d", new byte[] {UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]});
//                }
//                if (PlayObject.m_MyHero.m_ItemList.Count <= 0)
//                {
                    
//                    GridBagItem.RowCount = 2;
//                }
//                else
//                {
                    
//                    GridBagItem.RowCount = PlayObject.m_MyHero.m_ItemList.Count + 1;
//                }
//                if (PlayObject.m_MyHero.m_ItemList.Count > 0)
//                {
//                    // 20080630
//                    for (I = 0; I < PlayObject.m_MyHero.m_ItemList.Count; I ++ )
//                    {
//                        UserItem = PlayObject.m_MyHero.m_ItemList[I];
//                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
//                        if (StdItem == null)
//                        {
                            
//                            GridHeroBagItem.Cells[1, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[2, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[3, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[4, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[5, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[6, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[7, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[8, I + 1] = "";
                            
//                            GridHeroBagItem.Cells[9, I + 1] = "";
//                            continue;
//                        }
//                        Item = StdItem;
//                        M2Share.ItemUnit.GetItemAddValue(UserItem, ref Item);
                        
//                        GridHeroBagItem.Cells[0, I + 1] = (I).ToString();
                        
//                        GridHeroBagItem.Cells[1, I + 1] = Item.Name;
                        
//                        GridHeroBagItem.Cells[2, I + 1] = (UserItem->MakeIndex).ToString();
                        
                        
//                        GridHeroBagItem.Cells[3, I + 1] = string.Format("%d/%d", new ushort[] {UserItem->Dura, UserItem->DuraMax});
                        
                        
                        
                        
//                        GridHeroBagItem.Cells[4, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.DC), HiWord(Item.DC)});
                        
                        
                        
                        
//                        GridHeroBagItem.Cells[5, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MC), HiWord(Item.MC)});
                        
                        
                        
                        
//                        GridHeroBagItem.Cells[6, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.SC), HiWord(Item.SC)});
                        
                        
                        
                        
//                        GridHeroBagItem.Cells[7, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.AC), HiWord(Item.AC)});
                        
                        
                        
                        
//                        GridHeroBagItem.Cells[8, I + 1] = string.Format("%d/%d", new object[] {LoWord(Item.MAC), HiWord(Item.MAC)});
                        
                        
//                        GridHeroBagItem.Cells[9, I + 1] = string.Format("%d/%d/%d/%d/%d/%d/%d", new byte[] {UserItem->btValue[0], UserItem->btValue[1], UserItem->btValue[2], UserItem->btValue[3], UserItem->btValue[4], UserItem->btValue[5], UserItem->btValue[6]});
//                    }
//                }
//            }
//            catch {
//            }
//#endif

//        }

//        public void TimerTimer(object sender, EventArgs e)
//        {
//            if (PlayObject == null)
//            {
//                return;
//            }
//            if (PlayObject.m_boGhost)
//            {
//                EditHumanStatus.Text = "����";
//                PlayObject = null;
//                return;
//            }
//            if (Units.HumanInfo.boRefHuman)
//            {
//                RefHumanInfo();
//            }
//        }

//        public void CheckBoxMonitorClick(object sender, EventArgs e)
//        {
//            Units.HumanInfo.boRefHuman = CheckBoxMonitor.Checked;
//            ButtonSave.Enabled = !Units.HumanInfo.boRefHuman;
//        }

//        public void ButtonKickClick(object sender, EventArgs e)
//        {
//            if (PlayObject == null)
//            {
//                return;
//            }
//            PlayObject.m_boEmergencyClose = true;
//            PlayObject.m_boNotOnlineAddExp = false;
//            PlayObject.m_boPlayOffLine = false;
//            ButtonKick.Enabled = false;
//        }

//        public void ButtonSaveClick(object sender, EventArgs e)
//        {
//            int nLevel;
//            int nGold;
//            int nPKPOINT;
//            int nGameGold;
//            int nGameDiaMond;
//            // 20071226 ���ʯ
//            int nGameGird;
//            // 20071226 ���
//            int nLoyal;
//            // Ӣ�۵��ҳ϶�(20080109)
//            int nGamePoint;
//            int nCreditPoint;
//            int nBonusPoint;
//            bool boGameMaster;
//            bool boObServer;
//            bool boSuperman;
//            string sAutoSendMsg;
//            if (PlayObject == null)
//            {
//                return;
//            }
//            sAutoSendMsg = EditSayMsg.Text.Trim();
//            nLevel = EditLevel.Value;
//            nGold = EditGold.Value;
//            nPKPOINT = EditPKPoint.Value;
//            nGameGold = EditGameGold.Value;
//            nGameDiaMond = EditGameDiaMond.Value;
//            // 20071226 ���ʯ
//            nGameGird = EditGameGird.Value;
//            // 20071226 ���
//            nLoyal = EditHeroLoyal.Value;
//            // Ӣ�۵��ҳ϶�(20080109)
//            nGamePoint = EditGamePoint.Value;
//            nCreditPoint = EditCreditPoint.Value;
//            nBonusPoint = EditBonusPoint.Value;
//            boGameMaster = CheckBoxGameMaster.Checked;
//            boObServer = CheckBoxObserver.Checked;
//            boSuperman = CheckBoxSuperMan.Checked;
            
//            // (*or (nCreditPoint > High(Integer{Byte}))*)
//            // 20080118
//            if ((nLevel < 0) || (nLevel > High(ushort)) || (nGold < 0) || (nGold > 200000000) || (nPKPOINT < 0) || (nPKPOINT > 2000000) || (nCreditPoint < 0) || (nBonusPoint < 0) || (nBonusPoint > 20000000) || (nLoyal > 10000))
//            {
//                MessageBox.Show("�������ݲ���ȷ������", "������Ϣ",System.Windows.Forms.MessageBoxButtons.OK);
//                return;
//            }
//            PlayObject.m_sAutoSendMsg = sAutoSendMsg;
//            if (PlayObject.m_Abil.Level != nLevel)
//            {
//                // �ȼ�������¼��־ 20081102
//                M2Share.AddGameDataLog("17" + "\09" + PlayObject.m_sMapName + "\09" + (PlayObject.m_nCurrX).ToString() + "\09" + (PlayObject.m_nCurrY).ToString() + "\09" + PlayObject.m_sCharName + "\09" + (PlayObject.m_Abil.Level).ToString() + "\09" + "0" + "\09" + "����(" + (nLevel).ToString() + ")" + "\09" + "�������ﴰ��");
//            }
//            PlayObject.m_Abil.Level = nLevel;
//            PlayObject.m_nGold = nGold;
//            PlayObject.m_nPkPoint = nPKPOINT;
//            PlayObject.m_nGameGold = nGameGold;
//            PlayObject.m_nGAMEDIAMOND = nGameDiaMond;
//            // 20071226 ���ʯ
//            PlayObject.m_nGAMEGIRD = nGameGird;
//            // 20071226 ���
//            PlayObject.m_nGamePoint = nGamePoint;
//            PlayObject.m_btCreditPoint = nCreditPoint;
//            PlayObject.m_nBonusPoint = nBonusPoint;
//            PlayObject.m_boAdminMode = boGameMaster;
//            PlayObject.m_boObMode = boObServer;
//            PlayObject.m_boSuperMan = boSuperman;
//            if (PlayObject.m_boTrainingNG)
//            {
//                PlayObject.m_NGLevel = EditNGLevel.Value;
//                // 20081005 �ڹ��ȼ�
//                PlayObject.m_ExpSkill69 = EditExpSkill69.Value;
//                // 20081005 �ڹ��ķ���ǰ����
//                PlayObject.SendNGData();
//            // �����ڹ����� 20081005
//            }
//            PlayObject.GoldChanged();
//            PlayObject.GameGoldChanged();
//            // 20080211
//            PlayObject.HasLevelUp(1);
//#if HEROVERSION = 1
//            if (PlayObject.m_MyHero != null)
//            {
//                nLevel = EditHeroLevel.Value;
//                nPKPOINT = EditHeroPKPoint.Value;
//                if (PlayObject.m_MyHero.m_Abil.Level != nLevel)
//                {
//                    // �ȼ�������¼��־ 20081102
//                    M2Share.AddGameDataLog("17" + "\09" + PlayObject.m_MyHero.m_sMapName + "\09" + (PlayObject.m_MyHero.m_nCurrX).ToString() + "\09" + (PlayObject.m_MyHero.m_nCurrY).ToString() + "\09" + PlayObject.m_MyHero.m_sCharName + "\09" + (PlayObject.m_MyHero.m_Abil.Level).ToString() + "\09" + "0" + "\09" + "����(" + (nLevel).ToString() + ")" + "\09" + "�������ﴰ��");
//                }
//                PlayObject.m_MyHero.m_Abil.Level = nLevel;
//                PlayObject.m_MyHero.m_nPkPoint = nPKPOINT;
//                ((THeroObject)(PlayObject.m_MyHero)).m_nLoyal = nLoyal;
//                // Ӣ�۵��ҳ϶�(20080110)
//                if (((THeroObject)(PlayObject.m_MyHero)).m_boTrainingNG)
//                {
//                    ((THeroObject)(PlayObject.m_MyHero)).m_NGLevel = EditHeroNGLevel.Value;
//                    // 20081005 �ڹ��ȼ�
//                    ((THeroObject)(PlayObject.m_MyHero)).m_ExpSkill69 = EditHeroExpSkill69.Value;
//                    // 20081005 �ڹ��ķ���ǰ����
//                    PlayObject.m_MyHero.SendNGData();
//                // �����ڹ����� 20081005
//                }
//                PlayObject.m_MyHero.HasLevelUp(1);
//            }
//#endif
//            MessageBox.Show("���������ѱ��档", "��ʾ��Ϣ",System.Windows.Forms.MessageBoxButtons.OK);
//        }

    } 
}