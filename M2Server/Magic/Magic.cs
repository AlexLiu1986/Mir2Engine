using GameFramework;
using GameFramework.Enum;
using M2Server.Base;
using System;

namespace M2Server
{
    public class Magic : GameBase
    {
        // �����������
        public unsafe static int MPow(TUserMagic* UserMagic)
        {
            return UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
        }

        public unsafe static int GetPower(int nPower, TUserMagic* UserMagic)
        {
            return (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + (UserMagic->MagicInfo.btDefPower
                   + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
        }

        public unsafe static int GetPower13(int nInt, TUserMagic* UserMagic)
        {
            int result;
            double d10;
            double d18;
            d10 = nInt / 3.0;
            d18 = nInt - d10;
            result = (int)HUtil32.Round(d18 / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1) + d10 + (UserMagic->MagicInfo.btDefPower
                + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
            return result;
        }

        public static int GetRPow(int wInt)
        {
            int result = 0;
            if (HUtil32.HiWord(wInt) > HUtil32.LoWord(wInt))
            {
                result = HUtil32.Random(HUtil32.HiWord(wInt) - HUtil32.LoWord(wInt) + 1) + HUtil32.LoWord(wInt);
            }
            else
            {
                result = HUtil32.LoWord(wInt);
            }
            return result;
        }

        // ----------------------------------------------------------------------
        // ��������:��黤����� �Ƿ����
        // ���� nType Ϊָ������ 1 Ϊ����� 2 Ϊ��ҩ
        // ���ж�װ�������Ƿ���д�����Ʒ,��û��,����������Ƿ���д�����Ʒ
        // -----------------------------------------------------------------------
        public unsafe static bool CheckAmulet(TBaseObject PlayObject, int nCount, int nType, ref int Idx)
        {
            bool result = false;
            TUserItem* UserItem;// ��,�����ֱ��ʹ��
            TStdItem* AmuletStdItem;
            try
            {
                if (PlayObject.m_boGhost)
                {
                    return result;
                }
                Idx = 0;
                if (PlayObject.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
                {
                    AmuletStdItem = M2Share.UserEngine.GetStdItem(PlayObject.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                    if ((AmuletStdItem != null))
                    {
                        if ((AmuletStdItem->StdMode == 25))
                        {
                            switch (nType)
                            {
                                case 1:
                                    if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                    {
                                        Idx = TPosition.U_ARMRINGL;
                                        result = true;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                    {
                                        if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                        {
                                            Idx = TPosition.U_ARMRINGL;
                                            result = true;
                                            return result;
                                        }
                                    }
                                    else if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                    {
                                        switch (((THeroObject)(PlayObject)).n_AmuletIndx)
                                        {
                                            case 1:// �̶�
                                                if ((AmuletStdItem->Shape == 1) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                                {
                                                    Idx = TPosition.U_ARMRINGL;
                                                    result = true;
                                                    return result;
                                                }
                                                break;
                                            case 2:// �춾
                                                if ((AmuletStdItem->Shape == 2) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                                {
                                                    Idx = TPosition.U_ARMRINGL;
                                                    result = true;
                                                    return result;
                                                }
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }

                    if (PlayObject.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
                    {
                        AmuletStdItem = M2Share.UserEngine.GetStdItem(PlayObject.m_UseItems[TPosition.U_BUJUK]->wIndex);
                        if ((AmuletStdItem != null))
                        {
                            if ((AmuletStdItem->StdMode == 25))
                            {
                                switch (nType)
                                {
                                    case 1:// ��
                                        if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                        {
                                            Idx = TPosition.U_BUJUK;
                                            result = true;
                                            return result;
                                        }
                                        break;
                                    case 2:// ��
                                        if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (PlayObject.m_btRaceServer == Grobal2.RC_PLAYMOSTER))
                                        {
                                            if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                            {
                                                Idx = TPosition.U_BUJUK;
                                                result = true;
                                                return result;
                                            }
                                        }
                                        else if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                        {
                                            switch (((THeroObject)(PlayObject)).n_AmuletIndx)
                                            {
                                                case 1:// �̶�
                                                    if ((AmuletStdItem->Shape == 1) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                                    {
                                                        Idx = TPosition.U_BUJUK;
                                                        result = true;
                                                        return result;
                                                    }
                                                    break;
                                                case 2:// �춾
                                                    if ((AmuletStdItem->Shape == 2) && (HUtil32.Round((double)PlayObject.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                                    {
                                                        Idx = TPosition.U_BUJUK;
                                                        result = true;
                                                        return result;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    //��,�����ֱ��ʹ��(�����������Ƿ���ڶ�,�����)
                    if (PlayObject.m_ItemList.Count > 0)
                    {
                        for (int I = 0; I < PlayObject.m_ItemList.Count; I++)// ���������Ϊ��
                        {
                            UserItem = (TUserItem*)PlayObject.m_ItemList[I];
                            AmuletStdItem = M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                            if ((AmuletStdItem != null))
                            {
                                if ((AmuletStdItem->StdMode == 25))
                                {
                                    switch (nType)
                                    {
                                        case 1:
                                            if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                            {
                                                Idx = UserItem->wIndex;
                                                result = true;
                                                return result;
                                            }
                                            break;
                                        case 2:
                                            if (PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                            {
                                                if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                                {
                                                    Idx = UserItem->wIndex;
                                                    result = true;
                                                    return result;
                                                }
                                            }
                                            else if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                            {
                                                switch (((THeroObject)(PlayObject)).n_AmuletIndx)
                                                {
                                                    case 1:// �̶�
                                                        if ((AmuletStdItem->Shape == 1) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                                        {
                                                            Idx = UserItem->wIndex;
                                                            result = true;
                                                            return result;
                                                        }
                                                        break;
                                                    case 2:// �춾
                                                        if ((AmuletStdItem->Shape == 2) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                                        {
                                                            Idx = UserItem->wIndex;
                                                            result = true;
                                                            return result;
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} TMagic.CheckAmulet");
            }
            return result;
        }

        // -------------------------------------------------------------------------------
        // ʹ�û���� nType Ϊָ������ 1 Ϊ����� 2 Ϊ��ҩ
        // �޸�,ʹ�����еĶ�,���������ֱ��ʹ��,��װ����û�з��ϻ������,
        // �������д�����Ʒ,��ֱ��ʹ�ð������д�����Ʒ
        // --------------------------------------------------------------------------------
        public unsafe static void UseAmulet(TBaseObject PlayObject, int nCount, int nType, ref int Idx)
        {
            TUserItem* UserItem;// ��,�����ֱ��ʹ��
            TStdItem* AmuletStdItem;
            byte nCode = 1;
            try
            {
                nCode = 0;
                if (PlayObject.m_boGhost)
                {
                    return;
                }
                nCode = 1;
                if (((PlayObject.m_UseItems[TPosition.U_BUJUK]->wIndex > 0) || (PlayObject.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)) && ((TPosition.U_BUJUK == Idx)
                    || (TPosition.U_ARMRINGL == Idx)) && (PlayObject.m_UseItems[Idx]->Dura >= nCount * 100))//�ж�װ����û���������Ʒ
                {
                    nCode = 2;
                    PlayObject.m_UseItems[Idx]->Dura -= (ushort)(nCount * 100);
                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                    {
                        nCode = 3;
                        PlayObject.SendMsg(PlayObject, Grobal2.RM_DURACHANGE, Idx, PlayObject.m_UseItems[Idx]->Dura, PlayObject.m_UseItems[Idx]->DuraMax, 0, "");
                        nCode = 4;
                        ((TPlayObject)(PlayObject)).SendUpdateItem(PlayObject.m_UseItems[Idx]);//������Ʒ
                        if (PlayObject.m_UseItems[Idx]->Dura <= 0)
                        {
                            nCode = 5;
                            ((TPlayObject)(PlayObject)).SendDelItems(PlayObject.m_UseItems[Idx]);
                            PlayObject.m_UseItems[Idx]->wIndex = 0;
                        }
                    }
                    else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                    {
                        nCode = 6;
                        PlayObject.SendMsg(PlayObject, Grobal2.RM_HERODURACHANGE, Idx, PlayObject.m_UseItems[Idx]->Dura, PlayObject.m_UseItems[Idx]->DuraMax, 0, "");
                        nCode = 7;
                        ((THeroObject)(PlayObject)).SendUpdateItem(PlayObject.m_UseItems[Idx]);//������Ʒ
                        if (PlayObject.m_UseItems[Idx]->Dura <= 0)
                        {
                            nCode = 8;
                            ((THeroObject)(PlayObject)).SendUpdateItem(PlayObject.m_UseItems[Idx]);
                            PlayObject.m_UseItems[Idx]->wIndex = 0;
                        }
                    }
                }
                else
                {
                    nCode = 9;
                    for (int I = PlayObject.m_ItemList.Count - 1; I >= 0; I--)
                    {
                        if (PlayObject.m_ItemList.Count <= 0)
                        {
                            break;
                        }
                        nCode = 10;
                        UserItem = (TUserItem*)PlayObject.m_ItemList[I];
                        if (UserItem->wIndex == Idx)
                        {
                            nCode = 11;
                            AmuletStdItem = M2Share.UserEngine.GetStdItem(UserItem->wIndex);
                            if ((AmuletStdItem != null))
                            {
                                nCode = 12;
                                if ((AmuletStdItem->StdMode == 25))
                                {
                                    switch (nType)
                                    {
                                        case 1:// �����
                                            if ((AmuletStdItem->Shape == 5) && (UserItem->Dura >= nCount * 100))
                                            {
                                                UserItem->Dura -= (ushort)(nCount * 100);
                                            }
                                            break;
                                        case 2:// ��ҩ
                                            if ((AmuletStdItem->Shape <= 2) && (UserItem->Dura >= nCount * 100))
                                            {
                                                UserItem->Dura -= (ushort)(nCount * 100);
                                            }
                                            break;
                                    }
                                    if ((PlayObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                    {
                                        nCode = 13;
                                        PlayObject.SendMsg(PlayObject, Grobal2.RM_DURACHANGE, UserItem->wIndex, UserItem->Dura, UserItem->DuraMax, 0, "");
                                        nCode = 14;
                                        ((TPlayObject)(PlayObject)).SendUpdateItem(UserItem);// ������Ʒ
                                        if (UserItem->Dura <= 0)
                                        {
                                            nCode = 15;
                                            PlayObject.m_ItemList.RemoveAt(I);
                                            nCode = 16;
                                            ((TPlayObject)(PlayObject)).SendDelItems(UserItem);
                                        }
                                    }
                                    else if ((PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                                    {
                                        nCode = 17;
                                        PlayObject.SendMsg(PlayObject, Grobal2.RM_HERODURACHANGE, UserItem->wIndex, UserItem->Dura, UserItem->DuraMax, 0, "");
                                        nCode = 18;
                                        ((THeroObject)(PlayObject)).SendUpdateItem(UserItem);// ������Ʒ
                                        if (UserItem->Dura <= 0)
                                        {
                                            nCode = 19;
                                            PlayObject.m_ItemList.RemoveAt(I);
                                            nCode = 20;
                                            ((THeroObject)(PlayObject)).SendDelItems(UserItem);
                                        }
                                    }
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage("{�쳣} TMagic.UseAmulet Code:" + nCode);
            }
        }

        /// <summary>
        /// �ƻ������
        /// </summary>
        /// <param name="PlayObject"></param>
        public static void FinancialsDefence(TBaseObject PlayObject)
        {
            if (PlayObject.m_boProtectionDefence)// ���Ŀ����ʹ�û������
            {
                PlayObject.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] = 1;// �����ƶܵĶ���
            }
        }
    }
}