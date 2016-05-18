// ------------------------------------------------------------------------------
// ��Ԫ����: ObjHero.pas
// 
// ��Ԫ����: Mars
// ��������: 2007-02-12 20:30:00
// 
// ���ܽ���: ʵ��Ӣ�۹��ܵ�Ԫ
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using GameFramework;
using GameFramework.Enum;

namespace M2Server
{
    public class THeroObject : TBaseObject
    {
        public uint m_dwDoMotaeboTick = 0;// Ұ����ײ��� 
        public uint m_dwThinkTick = 0;
        public bool m_boDupMode = false;// �����ص���
        public int m_nTargetX = 0;// Ŀ������X
        public int m_nTargetY = 0;// Ŀ������Y
        public bool m_boRunAwayMode = false;// ����Զ��ģʽ
        public uint m_dwRunAwayStart = 0;
        public uint m_dwRunAwayTime = 0;
        public uint m_dwPickUpItemTick = 0;// ������Ʒ���
        public TMapItem m_SelMapItem = null;
        public ushort m_wHitMode = 0;// ������ʽ
        public ushort m_wBatterHitMode = 0;
        public byte m_btOldDir = 0;
        public uint m_dwActionTick = 0;// �������
        public ushort m_wOldIdent = 0;
        public byte m_btMentHero = 0;
        public uint m_dwTurnIntervalTime = 0;// ת�����ʱ��
        public uint m_dwMagicHitIntervalTime = 0;// ħ��������ʱ��
        /// <summary>
        /// �ܼ��ʱ��
        /// </summary>
        public uint m_dwRunIntervalTime = 0;
        /// <summary>
        /// �߼��ʱ��
        /// </summary>
        public uint m_dwWalkIntervalTime = 0;
        public uint m_dwActionIntervalTime = 0;// �������ʱ��
        public uint m_dwRunLongHitIntervalTime = 0;// ���г������ʱ��
        public uint m_dwWalkHitIntervalTime = 0;// �߶��������ʱ��
        public uint m_dwRunHitIntervalTime = 0;// �ܹ������ʱ��
        public uint m_dwRunMagicIntervalTime = 0;// ��ħ�����ʱ��
        public int m_nDieDropUseItemRate = 0;// ������װ������
        /// <summary>
        /// ħ��ʹ�ü��
        /// </summary>
        public uint[] m_SkillUseTick = new uint[80];
        public int m_nItemBagCount = 0;// ��������
        public byte m_btStatus = 0;// ״̬ 0-���� 1-���� 2-��Ϣ
        public bool m_boProtectStatus = false;// �Ƿ����ػ�״̬
        public bool m_boProtectOK = false;// �����ػ����� 
        public bool m_boTarget = false;// �Ƿ�����Ŀ��
        public int m_nProtectTargetX = 0;
        public int m_nProtectTargetY = 0;// �ػ�����
        public uint m_dwAutoAvoidTick = 0;// �Զ���ܼ��
        public bool m_boIsNeedAvoid = false;// �Ƿ���Ҫ���
        public uint m_dwEatItemNoHintTick = 0;// Ӣ��ûҩ��ʾʱ���� 
        public uint m_dwEatItemTick = 0;// ����ͨҩ���
        public uint m_dwEatItemTick1 = 0;// ������ҩ���
        public uint m_dwSearchIsPickUpItemTick = 0;// �����ɼ������Ʒ���
        public uint m_dwSearchIsPickUpItemTime = 0;// �����ɼ������Ʒʱ��
        public bool m_boCanDrop = false;// �Ƿ���������
        public bool m_boCanUseItem = false;// �Ƿ�����ʹ����Ʒ
        public bool m_boCanWalk = false;// �Ƿ�������
        public bool m_boCanRun = false;// �Ƿ�������
        public bool m_boCanHit = false;// �Ƿ�������
        public bool m_boCanSpell = false;// �Ƿ�����ħ��
        public bool m_boCanSendMsg = false;// �Ƿ���������Ϣ
        public byte m_btReLevel = 0;// ת���ȼ�
        public int m_btCreditPoint = 0;// ������ 
        public int m_nMemberType = 0;// ��Ա����
        public int m_nMemberLevel = 0;// ��Ա�ȼ�
        public int m_nKillMonExpRate = 0;// ɱ�־���ٷ���(�������� 100 Ϊ��������)
        public int m_nOldKillMonExpRate = 0;// ûʹ����װǰɱ�־��鱶�� 
        public uint m_dwMagicAttackInterval = 0;// ħ���������ʱ��(Dword)
        public uint m_dwMagicAttackTick = 0;// ħ������ʱ��(Dword)
        public uint m_dwMagicAttackCount = 0;// ħ����������(Dword) 
        public uint m_dwSearchMagic = 0;// ����ħ�����  û��ʹ��
        public int m_nSelectMagic = 0;// ��ѯħ��
        public bool m_boIsUseMagic = false;// �Ƿ����ʹ�õ�ħ��(True�ſ��ܶ��)
        public bool m_boIsUseAttackMagic = false;// �Ƿ����ʹ�õĹ���ħ��
        public byte m_btLastDirection = 0;// ���ķ���
        public ushort m_wLastHP = 0;// ����HPֵ
        public int m_nPickUpItemPosition = 0;// �ɼ�����Ʒ��λ��
        public int m_nFirDragonPoint = 0;// Ӣ��ŭ��ֵ
        public uint m_dwAddFirDragonTick = 0;// ����Ӣ��ŭ��ֵ�ļ��
        public bool m_boStartUseSpell = false;// �Ƿ�ʼʹ�úϻ�
        public bool m_boDecDragonPoint = false;// ��ʼ��ŭ��
        public uint m_dwStartUseSpellTick = 0;// ʹ�úϻ��ļ��
        public bool m_boNewHuman = false;// �Ƿ�Ϊ������
        public int m_nLoyal = 0;// Ӣ�۵��ҳ϶�
        public uint m_dwCheckNoHintTick = 0;// Ӣ��û������ʾʱ����  
        public byte n_AmuletIndx = 0;// �̺춾��ʶ 
        public byte n_HeroTpye = 0;// Ӣ������ 0-������Ӣ�� 1-����Ӣ�� 
        public uint m_dwDedingUseTick = 0;// �ض�ʹ�ü�� 
        public bool boCallLogOut = false;// �Ƿ��ٻ���ȥ 
        public uint m_dwAddAlcoholTick = 0;// ���Ӿ������ȵļ��  
        public uint m_dwDecWineDrinkValueTick = 0;// ������ƶȵļ��  
        public byte n_DrinkWineQuality = 0;// ����ʱ�Ƶ�Ʒ�� 
        public byte n_DrinkWineAlcohol = 0;// ����ʱ�ƵĶ��� 
        public bool n_DrinkWineDrunk = false;// �Ⱦ����� 
        public ushort dw_UseMedicineTime = 0;// ʹ��ҩ��ʱ��,���㳤ʱ��ûʹ��ҩ�� 
        public ushort n_MedicineLevel = 0;// ҩ��ֵ�ȼ� 
        public uint dwRockAddHPTick = 0;// ħѪʯ��HP ʹ�ü�� 
        public uint dwRockAddMPTick = 0;// ħѪʯ��MP ʹ�ü�� 
        public uint m_Exp68 = 0;// �������嵱ǰ���� 
        public uint m_MaxExp68 = 0;// ���������������� 
        public bool boAutoOpenDefence = false;// �Զ�����ħ���� 
        public bool m_boTrainingNG = false;// �Ƿ�ѧϰ���ڹ� 
        public byte m_NGLevel = 0;// �ڹ��ȼ� 
        public uint m_ExpSkill69 = 0;// �ڹ��ķ���ǰ���� 
        public uint m_MaxExpSkill69 = 0;// �ڹ��ķ��������� 
        public uint m_Skill69NH = 0;// ��ǰ����ֵ 
        public uint m_Skill69MaxNH = 0;// �������ֵ 
        public uint m_dwIncNHTick = 0;// ��������ֵ��ʱ 
        public uint m_dwIncAddNHTick = 0;// ���������ָ��ٶ� %  
        public uint m_dwIncAddNHPoint = 0;// �����ָ��ٶȼӼ���  
        public bool m_boisOpenPuls = false;// �Ƿ��Ӣ�۾���
        public int m_nPulseExp = 0;// Ӣ�۾��羭��
        public unsafe TUserMagic* m_Magic46Skill = null;// ������ 
        public unsafe TUserMagic* m_MagicSkill_200 = null;// ŭ֮��ɱ
        public unsafe TUserMagic* m_MagicSkill_201 = null;// ��֮��ɱ
        public unsafe TUserMagic* m_MagicSkill_202 = null;// ŭ֮����
        public unsafe TUserMagic* m_MagicSkill_203 = null;// ��֮����
        public unsafe TUserMagic* m_MagicSkill_204 = null;// ŭ֮�һ�
        public unsafe TUserMagic* m_MagicSkill_205 = null;// ��֮�һ�
        public unsafe TUserMagic* m_MagicSkill_206 = null;// ŭ֮����
        public unsafe TUserMagic* m_MagicSkill_207 = null;// ��֮����
        public unsafe TUserMagic* m_MagicSkill_208 = null;// ŭ֮����
        public unsafe TUserMagic* m_MagicSkill_209 = null;// ��֮����
        public unsafe TUserMagic* m_MagicSkill_210 = null;// ŭ֮�����
        public unsafe TUserMagic* m_MagicSkill_211 = null;// ��֮�����
        public unsafe TUserMagic* m_MagicSkill_212 = null;// ŭ֮��ǽ
        public unsafe TUserMagic* m_MagicSkill_213 = null;// ��֮��ǽ
        public unsafe TUserMagic* m_MagicSkill_214 = null;// ŭ֮������
        public unsafe TUserMagic* m_MagicSkill_215 = null;// ��֮������
        public unsafe TUserMagic* m_MagicSkill_216 = null;// ŭ֮�����Ӱ
        public unsafe TUserMagic* m_MagicSkill_217 = null;// ��֮�����Ӱ
        public unsafe TUserMagic* m_MagicSkill_218 = null;// ŭ֮���ѻ���
        public unsafe TUserMagic* m_MagicSkill_219 = null;// ��֮���ѻ���
        public unsafe TUserMagic* m_MagicSkill_220 = null;// ŭ֮������
        public unsafe TUserMagic* m_MagicSkill_221 = null;// ��֮������
        public unsafe TUserMagic* m_MagicSkill_222 = null;// ŭ֮�׵�
        public unsafe TUserMagic* m_MagicSkill_223 = null;// ��֮�׵�
        public unsafe TUserMagic* m_MagicSkill_224 = null;// ŭ֮�����׹�
        public unsafe TUserMagic* m_MagicSkill_225 = null;// ��֮�����׹�
        public unsafe TUserMagic* m_MagicSkill_226 = null;// ŭ֮������
        public unsafe TUserMagic* m_MagicSkill_227 = null;// ��֮������
        public unsafe TUserMagic* m_MagicSkill_228 = null;// ŭ֮�����
        public unsafe TUserMagic* m_MagicSkill_229 = null;// ��֮�����
        public unsafe TUserMagic* m_MagicSkill_230 = null;// ŭ֮���
        public unsafe TUserMagic* m_MagicSkill_231 = null;// ��֮���
        public unsafe TUserMagic* m_MagicSkill_232 = null;// ŭ֮��Ѫ
        public unsafe TUserMagic* m_MagicSkill_233 = null;// ��֮��Ѫ
        public unsafe TUserMagic* m_MagicSkill_234 = null;// ŭ֮���ǻ���
        public unsafe TUserMagic* m_MagicSkill_235 = null;// ��֮���ǻ���
        public unsafe TUserMagic* m_MagicSkill_236 = null;// ŭ֮�ڹ�����
        public unsafe TUserMagic* m_MagicSkill_237 = null;// ��֮�ڹ�����
        public uint m_GetExp = 0;// Ӣ��ȡ�õľ���,$HeroGetExp����ʹ��
        public ushort m_AvoidHp = 0;// ����Ѫ��
        public bool m_boCrazyProtection = false;

        public THeroObject()
            : base()
        {
            m_dwIncAddNHTick = 0;
            m_dwIncAddNHPoint = 0;
            boCallLogOut = false;
            this.m_btRaceServer = Grobal2.RC_HEROOBJECT;
            m_boDupMode = false;
            m_dwThinkTick = HUtil32.GetTickCount();
            this.m_nViewRange = 12;
            this.m_nRunTime = 250;
            this.m_dwSearchTick = HUtil32.GetTickCount();
            this.m_nCopyHumanLevel = 3;
            m_nTargetX = -1;
            this.dwTick3F4 = HUtil32.GetTickCount();// 6
            this.m_btNameColor = GameConfig.nHeroNameColor;// ���ֵ���ɫ 
            this.m_boFixedHideMode = true;
            m_dwMagicHitIntervalTime = GameConfig.dwMagicHitIntervalTime;
            m_dwRunIntervalTime = HUtil32.GetTickCount();
            m_dwWalkIntervalTime = GameConfig.dwHeroWalkIntervalTime;// Ӣ����·��� 
            m_dwTurnIntervalTime = GameConfig.dwHeroTurnIntervalTime;// Ӣ�ۻ�������
            m_dwActionIntervalTime = GameConfig.dwActionIntervalTime;// ��ϲ������
            m_dwRunLongHitIntervalTime = GameConfig.dwRunLongHitIntervalTime;// ��ϲ������
            m_dwRunHitIntervalTime = GameConfig.dwRunHitIntervalTime;// ��ϲ������
            m_dwWalkHitIntervalTime = GameConfig.dwWalkHitIntervalTime;// ��ϲ������
            m_dwRunMagicIntervalTime = GameConfig.dwRunMagicIntervalTime;// ��λħ�����
            this.m_dwHitTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_dwWalkTick = HUtil32.GetTickCount() - ((uint)HUtil32.Random(3000));
            this.m_nWalkSpeed = 350;// ԭΪ300
            this.m_nWalkStep = 10;
            this.m_dwWalkWait = 0;
            this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
            m_boRunAwayMode = false;
            m_dwRunAwayStart = HUtil32.GetTickCount();
            m_dwRunAwayTime = 0;
            m_dwPickUpItemTick = HUtil32.GetTickCount();
            m_dwAutoAvoidTick = HUtil32.GetTickCount();
            m_dwEatItemTick = HUtil32.GetTickCount();
            m_dwEatItemTick1 = HUtil32.GetTickCount();
            m_dwEatItemNoHintTick = HUtil32.GetTickCount();
            m_boIsNeedAvoid = false;
            m_SelMapItem = null;
            this.m_nNextHitTime = 300;// �´ι���ʱ��
            m_nDieDropUseItemRate = 100;
            m_nItemBagCount = 10;
            m_btStatus = 0;// ״̬ Ĭ��Ϊ����
            m_boProtectStatus = false;// �Ƿ����ػ�״̬
            m_boProtectOK = false;// �����ػ�����
            m_boTarget = false;// �Ƿ�����Ŀ��
            m_nProtectTargetX = -1;// �ػ�����
            m_nProtectTargetY = -1;// �ػ�����
            m_boCanDrop = true;// �Ƿ���������Ʒ
            m_boCanUseItem = true;// �Ƿ�����ʹ����Ʒ
            m_boCanWalk = true;
            m_boCanRun = true;
            m_boCanHit = true;
            m_boCanSpell = true;
            m_boCanSendMsg = true;
            m_btReLevel = 0;
            m_btCreditPoint = 0;
            m_nMemberType = 0;
            m_nMemberLevel = 0;
            m_nKillMonExpRate = 100;
            m_nOldKillMonExpRate = m_nKillMonExpRate;
            m_boIsUseMagic = false;// �Ƿ��ܶ��
            m_boIsUseAttackMagic = false;
            m_nSelectMagic = 0;
            m_nPickUpItemPosition = 0;
            m_nFirDragonPoint = 0;// ŭ�����ó�ʼ��,
            m_dwAddFirDragonTick = HUtil32.GetTickCount();
            m_btLastDirection = this.m_btDirection;
            m_wLastHP = 0;
            m_boStartUseSpell = false;
            m_boDecDragonPoint = false;// ��ʼ��ŭ��
            m_dwSearchMagic = HUtil32.GetTickCount();
            m_boNewHuman = false;
            m_nLoyal = 0;// Ӣ�۵��ҳ϶�
            n_AmuletIndx = 0;
            m_dwDedingUseTick = 0;// �ض�ʹ�ü��
            m_dwAddAlcoholTick = HUtil32.GetTickCount();// ���Ӿ������ȵļ�� 
            m_dwDecWineDrinkValueTick = HUtil32.GetTickCount();// ������ƶȵļ�� 
            n_DrinkWineQuality = 0;// ����ʱ�Ƶ�Ʒ��
            n_DrinkWineAlcohol = 0;// ����ʱ�ƵĶ���
            n_DrinkWineDrunk = false;// �Ⱦ�����
            dw_UseMedicineTime = 0;// ʹ��ҩ��ʱ��,���㳤ʱ��ûʹ��ҩ�� 
            n_MedicineLevel = 0;// ҩ��ֵ�ȼ� 
            m_Exp68 = 0;// �������嵱ǰ����
            m_MaxExp68 = 0;// ����������������
            boAutoOpenDefence = false;// �Զ�����ħ����
            m_boTrainingNG = false;// �Ƿ�ѧϰ���ڹ�
            m_NGLevel = 1;// �ڹ��ȼ�
            m_ExpSkill69 = 0;// �ڹ��ķ���ǰ����
            m_MaxExpSkill69 = 0;// �ڹ��ķ���������
            m_Skill69NH = 0;// ��ǰ����ֵ
            m_Skill69MaxNH = 0;// �������ֵ
            m_dwIncNHTick = HUtil32.GetTickCount();// ��������ֵ��ʱ
            //m_Magic46Skill = null;// ������
            //m_MagicSkill_200 = null;// ŭ֮��ɱ
            //m_MagicSkill_201 = null;// ��֮��ɱ
            //m_MagicSkill_202 = null;// ŭ֮����
            //m_MagicSkill_203 = null;// ��֮����
            //m_MagicSkill_204 = null;// ŭ֮�һ�
            //m_MagicSkill_205 = null;// ��֮�һ�
            //m_MagicSkill_206 = null;// ŭ֮����
            //m_MagicSkill_207 = null;// ��֮����
            //m_MagicSkill_208 = null;// ŭ֮����
            //m_MagicSkill_209 = null;// ��֮����
            //m_MagicSkill_210 = null;// ŭ֮�����
            //m_MagicSkill_211 = null;// ��֮�����
            //m_MagicSkill_212 = null;// ŭ֮��ǽ
            //m_MagicSkill_213 = null;// ��֮��ǽ
            //m_MagicSkill_214 = null;// ŭ֮������
            //m_MagicSkill_215 = null;// ��֮������
            //m_MagicSkill_216 = null;// ŭ֮�����Ӱ
            //m_MagicSkill_217 = null;// ��֮�����Ӱ
            //m_MagicSkill_218 = null;// ŭ֮���ѻ���
            //m_MagicSkill_219 = null;// ��֮���ѻ���
            //m_MagicSkill_220 = null;// ŭ֮������
            //m_MagicSkill_221 = null;// ��֮������
            //m_MagicSkill_222 = null;// ŭ֮�׵�
            //m_MagicSkill_223 = null;// ��֮�׵�
            //m_MagicSkill_224 = null;// ŭ֮�����׹�
            //m_MagicSkill_225 = null;// ��֮�����׹�
            //m_MagicSkill_226 = null;// ŭ֮������
            //m_MagicSkill_227 = null;// ��֮������
            //m_MagicSkill_228 = null;// ŭ֮�����
            //m_MagicSkill_229 = null;// ��֮�����
            //m_MagicSkill_230 = null;// ŭ֮���
            //m_MagicSkill_231 = null;// ��֮���
            //m_MagicSkill_232 = null;// ŭ֮��Ѫ
            //m_MagicSkill_233 = null;// ��֮��Ѫ
            //m_MagicSkill_234 = null;// ŭ֮���ǻ���
            //m_MagicSkill_235 = null;// ��֮���ǻ���
            //m_MagicSkill_236 = null;// ŭ֮�ڹ�����
            //m_MagicSkill_237 = null;// ��֮�ڹ�����
            m_GetExp = 0;// ����ȡ�õľ���,$GetExp����ʹ�� 
            m_AvoidHp = 0;// ����Ѫ��
            m_boCrazyProtection = false;// ����񻯱���
        }

        public unsafe override void Run()
        {
            int nX = 0;
            int nY = 0;
            byte nCheckCode = 0;
            const string sExceptionMsg = "{�쳣} THeroObject.Run Code:{0}";
            try
            {
                if ((!this.m_boGhost) && (!this.m_boDeath) && (!this.m_boFixedHideMode) && (!this.m_boStoneMode))
                {
                    EatMedicine();// ��ҩ
                    if (this.m_boCanUseBatter && (!this.m_boUseBatter))
                    {
                        // Ӣ�ۼ�鲢������
                        if (this.AllowBatterHitSkill(true))
                        {
                            this.m_nBatter = 0;
                            this.m_boBatterFinally = false;
                        }
                    }
                    if (this.m_boUseBatter)
                    {
                        ClientUseBatter();
                    }
                    if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0))// û�б����
                    {
                        nCheckCode = 11;
                        if (Think())
                        {
                            base.Run();
                            return;
                        }
                        nCheckCode = 12;
                        if (this.m_Master != null)
                        {
                            PlaySuperRock();// ��Ѫʯ ħѪʯ 
                        }
                        // ------------------------------------------------------------------------------
                        // ���ƾ�����������
                        if (this.m_Abil.WineDrinkValue > 0)
                        {
                            // ��ƶȴ���0ʱ�Ŵ���
                            if ((HUtil32.GetTickCount() - m_dwAddAlcoholTick + n_DrinkWineQuality * 1000 > (GameConfig.nIncAlcoholTick * 1000)) && !n_DrinkWineDrunk)
                            {
                                // ���Ӿ�������
                                m_dwAddAlcoholTick = HUtil32.GetTickCount();
                                this.SendRefMsg(Grobal2.RM_MYSHOW, 8, 0, 0, 0, "");
                                // �������Ӷ���  20080623
                                this.m_Abil.Alcohol += (ushort)HUtil32._MAX(5, (n_DrinkWineAlcohol * this.m_Abil.MaxAlcohol) / 1000);
                                // �ƶ��� ����������
                                if (this.m_Abil.Alcohol > this.m_Abil.MaxAlcohol)
                                {
                                    // ��������
                                    this.m_Abil.Alcohol = Convert.ToUInt16(this.m_Abil.Alcohol - this.m_Abil.MaxAlcohol);
                                    this.m_Abil.MaxAlcohol = Convert.ToUInt16(this.m_Abil.MaxAlcohol + GameConfig.nIncAlcoholValue);
                                    if (this.m_Magic67Skill != null)
                                    {
                                        // ����Ԫ��ħ������
                                        this.m_Magic67Skill->nTranPoint = this.m_Abil.MaxAlcohol;
                                        if (!this.CheckMagicLevelup(this.m_Magic67Skill))
                                        {
                                            SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, this.m_Magic67Skill->MagicInfo.wMagicId, this.m_Magic67Skill->btLevel, this.m_Magic67Skill->nTranPoint, "", 1000);
                                        }
                                        if (this.m_Abil.WineDrinkValue >= Math.Abs(this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue67 / 100))
                                        {
                                            // �������ڻ���ھ������޵�5%ʱ����Ч
                                            if (this.m_Magic67Skill->btLevel > 0)
                                            {
                                                this.m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.AC), HUtil32.HiWord(this.m_WAbil.AC) + this.m_Magic67Skill->btLevel * 2);
                                                this.m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.MAC), HUtil32.HiWord(this.m_WAbil.MAC) + this.m_Magic67Skill->btLevel * 2);
                                                SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                                            }
                                        }
                                    }
                                }
                                GetNGExp(GameConfig.nDrinkIncNHExp, 2);// ���������ڹ����� 
                                RecalcAbilitys();
                                this.CompareSuitItem(false);// ��װ������װ���Ա� 
                                SendMsg(this, Grobal2.RM_HEROMAKEWINEABILITY, 0, 0, 0, 0, "");// ��2�������
                            }
                            if (HUtil32.GetTickCount() - m_dwDecWineDrinkValueTick > GameConfig.nDesDrinkTick * 1000)
                            {
                                // ������ƶ�
                                m_dwDecWineDrinkValueTick = HUtil32.GetTickCount();
                                this.m_Abil.WineDrinkValue = (ushort)HUtil32._MAX(0, this.m_Abil.WineDrinkValue - this.m_Abil.MaxAlcohol / 100);
                                if (this.m_Abil.WineDrinkValue == 0)
                                {
                                    n_DrinkWineQuality = 0;// ����ʱ�Ƶ�Ʒ��
                                    n_DrinkWineAlcohol = 0;// ����ʱ�ƵĶ���
                                    n_DrinkWineDrunk = false;// �Ⱦ�����
                                    SysMsg("Ӣ�� " + GameMsgDef.g_sJiujinOverHintMsg, TMsgColor.c_Green, TMsgType.t_Hint); // '�ƾ�������ʧ��,����Ҳ�ָ�ƽ����״̬'
                                }
                                RecalcAbilitys();
                                this.CompareSuitItem(false);// ��װ������װ���Ա� 
                                SendMsg(this, Grobal2.RM_HEROMAKEWINEABILITY, 0, 0, 0, 0, "");// ��2�������
                            }
                        }
                        if (m_boTrainingNG && (m_Skill69NH < m_Skill69MaxNH)) // ѧ���ڹ�,���ʱ����������ֵ
                        {
                            // ���������ָ��ٶ�
                            if (HUtil32.GetTickCount() - m_dwIncAddNHTick + (int)HUtil32.Round((double)GameConfig.dwIncNHTime / 100 * m_dwIncAddNHTick) > GameConfig.dwIncNHTime)
                            {
                                m_dwIncNHTick = HUtil32.GetTickCount();// �����ָ���
                                m_Skill69NH = (ushort)HUtil32._MIN((int)m_Skill69MaxNH, Convert.ToInt32(m_Skill69NH + HUtil32._MAX(1, (int)HUtil32.Round(m_Skill69MaxNH * 0.014)) + m_dwIncAddNHPoint));
                                this.SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, m_Skill69NH, m_Skill69MaxNH, 0, "");
                            }
                        }
                        // ------------------------------------------------------------------------------
                        nCheckCode = 1;
                        if (!m_boStartUseSpell && !m_boDecDragonPoint)
                        {
                            if (m_nFirDragonPoint < GameConfig.nMaxFirDragonPoint)
                            {
                                if (HUtil32.GetTickCount() - m_dwAddFirDragonTick > GameConfig.nIncDragonPointTick) // 1000 * 3
                                {
                                    m_dwAddFirDragonTick = HUtil32.GetTickCount(); // ��ŭ��ʱ��ɵ���
                                    if (WearFirDragon() && (this.m_UseItems[TPosition.U_BUJUK]->Dura > 0))
                                    {
                                        // ����֮�ĳ־�
                                        if (this.m_UseItems[TPosition.U_BUJUK]->Dura >= GameConfig.nDecFirDragonPoint)
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura -= GameConfig.nDecFirDragonPoint;
                                        }
                                        else
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura = 0;
                                        }
                                        m_nFirDragonPoint += GameConfig.nAddFirDragonPoint;// ����Ӣ��ŭ��
                                        if (m_nFirDragonPoint > GameConfig.nMaxFirDragonPoint)
                                        {
                                            m_nFirDragonPoint = GameConfig.nMaxFirDragonPoint; // ����ŭ��ֵ��ӳ���
                                        }
                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_BUJUK, this.m_UseItems[TPosition.U_BUJUK]->Dura, this.m_UseItems[TPosition.U_BUJUK]->DuraMax, 0, "");
                                        SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (m_boDecDragonPoint && WearFirDragon()) // ��ŭ��
                            {
                                if (m_nFirDragonPoint > 0)
                                {
                                    if (HUtil32.GetTickCount() - m_dwAddFirDragonTick > 2000)// 1000 * 2
                                    {
                                        m_dwAddFirDragonTick = HUtil32.GetTickCount();
                                        m_nFirDragonPoint -= (GameConfig.nMaxFirDragonPoint / 10);// ��Ӣ��ŭ�� 
                                        if (m_nFirDragonPoint <= 0)
                                        {
                                            m_nFirDragonPoint = 0;
                                            m_boDecDragonPoint = false;// ֹͣ��ŭ��
                                            m_boStartUseSpell = false;
                                        }
                                        SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");
                                    }
                                    // ְҵ��ս,�������,�Զ��źϻ�
                                    if ((this.m_TargetCret != null) && (!this.m_TargetCret.m_boDeath) && (this.m_Master != null))
                                    {
                                        switch (GetTogetherUseSpell())
                                        {
                                            case 60:
                                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || (GameConfig.ClientConf.boParalyCanSpell))
                                                {
                                                    //�޸ģ�ֱ�߲ŷ��ƻ�ն
                                                    if ((((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2))) && (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 0)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 1) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 2)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 1)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) == 0) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) == 2))))
                                                    {
                                                        m_boDecDragonPoint = false;// ֹͣ��ŭ��
                                                        m_boStartUseSpell = true;// �ϻ����ܿ���
                                                        m_dwStartUseSpellTick = HUtil32.GetTickCount();
                                                    }
                                                }
                                                break;
                                            case 61:
                                            case 62:// ����ն,����һ��
                                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || (GameConfig.ClientConf.boParalyCanSpell))
                                                {
                                                    // �����
                                                    if (((this.m_btJob == 0) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 2))) || ((this.m_Master.m_btJob == 0) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_Master.m_nCurrX) <= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_Master.m_nCurrY) <= 2))))
                                                    {
                                                        m_boDecDragonPoint = false;// ֹͣ��ŭ��
                                                        m_boStartUseSpell = true;// �ϻ����ܿ���
                                                        m_dwStartUseSpellTick = HUtil32.GetTickCount();
                                                    }
                                                }
                                                break;
                                            case 63:
                                            case 64:
                                            case 65://�����
                                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || (GameConfig.ClientConf.boParalyCanSpell))
                                                {
                                                    m_boDecDragonPoint = false;// ֹͣ��ŭ��
                                                    m_boStartUseSpell = true;// �ϻ����ܿ���
                                                    m_dwStartUseSpellTick = HUtil32.GetTickCount();
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            // 1000 * 3
                            if (m_boStartUseSpell && (HUtil32.GetTickCount() - m_dwStartUseSpellTick > 3000))
                            {
                                m_boStartUseSpell = false;
                                m_boDecDragonPoint = false;// ֹͣ��ŭ��
                            }
                            SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");// ����Ӣ��ŭ��ֵ
                        }
                        // 20 * 1000
                        if (this.m_boFireHitSkill && ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 20000))
                        {
                            this.m_boFireHitSkill = false;// �ٻ��һ����
                        }
                        // 20 * 1000
                        if (this.m_boDailySkill && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 20000))
                        {
                            this.m_boDailySkill = false;// ���ս�������
                        }
                        nCheckCode = 2;
                        if (IsSearchTarget())
                        {
                            SearchTarget(); // ����Ŀ��
                        }
                        if (this.m_boWalkWaitLocked)
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwWalkWaitTick) > this.m_dwWalkWait)
                            {
                                this.m_boWalkWaitLocked = false;
                            }
                        }
                        if (!this.m_boWalkWaitLocked && ((HUtil32.GetTickCount() - this.m_dwWalkTick) > this.m_nWalkSpeed))
                        {
                            this.m_dwWalkTick = HUtil32.GetTickCount();
                            this.m_nWalkCount++;
                            if (this.m_nWalkCount > this.m_nWalkStep)
                            {
                                this.m_nWalkCount = 0;
                                this.m_boWalkWaitLocked = true;

                                this.m_dwWalkWaitTick = HUtil32.GetTickCount();
                            }
                            if (!m_boRunAwayMode)
                            {
                                if (!this.m_boNoAttackMode)
                                {
                                    if (m_boProtectStatus) // �ػ�״̬,����̫Զ,ֱ�ӷɹ�ȥ 
                                    {
                                        if (!m_boProtectOK)  // û�ߵ��ػ�����
                                        {
                                            if (RunToTargetXY(m_nProtectTargetX, m_nProtectTargetY))
                                            {
                                                m_boProtectOK = true;
                                            }
                                            else if (WalkToTargetXY2(m_nProtectTargetX, m_nProtectTargetY))
                                            {
                                                m_boProtectOK = true; // ת��
                                            }
                                        }
                                    }
                                    nCheckCode = 6;
                                    if ((this.m_TargetCret != null))
                                    {
                                        if (m_boStartUseSpell)
                                        {
                                            nCheckCode = 61;
                                            m_nSelectMagic = GetTogetherUseSpell();// �жϺϻ�ħ��ID
                                            nCheckCode = 62;
                                            if ((this.m_btJob == 0) && (m_nSelectMagic == 60))
                                            {
                                                //  ����Ϣ��ǰ�Ƿ��ͺϻ� ���ͻ��˵���Ϣ  ����ûʵ���ô�  �����ڷ��ƻ��ȹ�����ʾ�±���������
                                                SendMsg(this.m_TargetCret, Grobal2.RM_GOTETHERUSESPELL, m_nSelectMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 0, "");
                                            }
                                            // ʹ�úϻ�
                                            m_nFirDragonPoint = 0;
                                            // SearchMagic(); //��ѯħ�� 20080328ע��
                                        }
                                        if (AttackTarget())  // ���� 
                                        {
                                            nCheckCode = 70;
                                            m_boStartUseSpell = false;
                                            base.Run();
                                            return;
                                        }
                                        else if (IsNeedAvoid())
                                        {
                                            // �Զ����
                                            nCheckCode = 71;
                                            m_dwActionTick = HUtil32.GetTickCount() - 10;
                                            AutoAvoid();
                                            base.Run();
                                            return;
                                        }
                                        else
                                        {
                                            if (IsNeedGotoXY())// �Ƿ�����Ŀ��
                                            {
                                                nCheckCode = 72;
                                                m_dwActionTick = HUtil32.GetTickCount();
                                                m_nTargetX = this.m_TargetCret.m_nCurrX;
                                                m_nTargetY = this.m_TargetCret.m_nCurrY;
                                                if (IsAllowUseMagic(12) && (this.m_btJob == 0))
                                                {
                                                    GetGotoXY(this.m_TargetCret, 2);
                                                }
                                                if ((this.m_btJob > 0))
                                                {
                                                    if ((GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22)) || (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_WAbil.MaxHP < 700) && (this.m_btJob == 2) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)))
                                                    {
                                                        // ����22ǰ�Ƿ�������
                                                        if (this.m_Master != null)
                                                        {
                                                            if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) > 6) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) > 6))
                                                            {
                                                                base.Run();
                                                                return;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        GetGotoXY(this.m_TargetCret, 3); // ����ֻ����Ŀ��3��Χ
                                                    }
                                                }
                                                GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                                                base.Run();
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!m_boProtectStatus)
                                        {
                                            m_nTargetX = -1;
                                        }
                                    }
                                }
                                nCheckCode = 8;
                                if (this.m_TargetCret != null)
                                {
                                    m_nTargetX = this.m_TargetCret.m_nCurrX;
                                    m_nTargetY = this.m_TargetCret.m_nCurrY;
                                }
                                nCheckCode = 81;
                                if (SearchIsPickUpItem())
                                {
                                    nCheckCode = 82;
                                    SearchPickUpItem(500);
                                    base.Run();
                                    return;
                                }
                                nCheckCode = 9;
                                if (this.m_Master != null)
                                {
                                    if (m_boProtectStatus) // �ػ�״̬
                                    {
                                        if ((Math.Abs(this.m_nCurrX - m_nProtectTargetX) > 9) || (Math.Abs(this.m_nCurrY - m_nProtectTargetY) > 9))// �޸��ػ���Χ
                                        {
                                            m_nTargetX = m_nProtectTargetX;
                                            m_nTargetY = m_nProtectTargetY;
                                            this.m_TargetCret = null;
                                        }
                                        else
                                        {
                                            m_nTargetX = -1;
                                        }
                                    }
                                    else
                                    {
                                        if ((this.m_TargetCret == null) && !m_boProtectStatus && (m_btStatus != 2))
                                        {
                                            nCheckCode = 95;
                                            this.m_Master.GetBackPosition(ref nX, ref nY);
                                            if ((Math.Abs(m_nTargetX - nX) > 2) || (Math.Abs(m_nTargetY - nY) > 2)) // �޸�2��
                                            {
                                                m_nTargetX = nX;
                                                m_nTargetY = nY;
                                                if ((Math.Abs(this.m_nCurrX - nX) <= 3) && (Math.Abs(this.m_nCurrY - nY) <= 3))
                                                {
                                                    if (this.m_PEnvir.GetMovingObject(nX, nY, true) != null)
                                                    {
                                                        m_nTargetX = this.m_nCurrX;
                                                        m_nTargetY = this.m_nCurrY;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (this.m_Master != null)
                                    {
                                        if (!m_boProtectStatus && (m_btStatus != 2) && ((this.m_PEnvir != this.m_Master.m_PEnvir) || (Math.Abs(this.m_nCurrX - this.m_Master.m_nCurrX) > 20) || (Math.Abs(this.m_nCurrY - this.m_Master.m_nCurrY) > 20)))
                                        {
                                            nCheckCode = 96;
                                            this.SpaceMove(this.m_Master.m_PEnvir.sMapName, m_nTargetX, m_nTargetY, 1);
                                        }
                                    }
                                    if ((this.m_TargetCret != null))
                                    {
                                        // ��Ŀ����Ӣ�۲���ͬ����ͼ��ɾ��Ŀ��
                                        if ((this.m_TargetCret.m_PEnvir != this.m_PEnvir))
                                        {
                                            DelTargetCreat();
                                        }
                                    }
                                }
                            }
                            else
                            {

                                if ((m_dwRunAwayTime > 0) && ((HUtil32.GetTickCount() - m_dwRunAwayStart) > m_dwRunAwayTime))
                                {
                                    m_boRunAwayMode = false;
                                    m_dwRunAwayTime = 0;
                                }
                            }
                            nCheckCode = 10;
                            if ((this.m_TargetCret == null) && (m_btStatus != 2))
                            {
                                if (m_nTargetX != -1)
                                {
                                    if ((Math.Abs(this.m_nCurrX - m_nTargetX) > 1) || (Math.Abs(this.m_nCurrY - m_nTargetY) > 1))
                                    {
                                        GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                                    }
                                }
                                else
                                {
                                    Wondering();
                                }
                            }
                        }
                    }
                    else
                    {
                        // ���ʱ,��������ŭ��
                        if (!m_boStartUseSpell && !m_boDecDragonPoint)
                        {
                            if (m_nFirDragonPoint < GameConfig.nMaxFirDragonPoint)
                            {
                                if (HUtil32.GetTickCount() - m_dwAddFirDragonTick > GameConfig.nIncDragonPointTick)// 1000 * 3
                                {
                                    m_dwAddFirDragonTick = HUtil32.GetTickCount();//  ��ŭ��ʱ��ɵ���
                                    if (WearFirDragon() && (this.m_UseItems[TPosition.U_BUJUK]->Dura > 0))
                                    {
                                        if (this.m_UseItems[TPosition.U_BUJUK]->Dura >= GameConfig.nDecFirDragonPoint)  // ����֮�ĳ־�
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura -= GameConfig.nDecFirDragonPoint;
                                        }
                                        else
                                        {
                                            this.m_UseItems[TPosition.U_BUJUK]->Dura = 0;
                                        }
                                        m_nFirDragonPoint += GameConfig.nAddFirDragonPoint;// ����Ӣ��ŭ��
                                        if (m_nFirDragonPoint > GameConfig.nMaxFirDragonPoint)
                                        {
                                            m_nFirDragonPoint = GameConfig.nMaxFirDragonPoint; // ����ŭ��ֵ��ӳ���
                                        }
                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_BUJUK, this.m_UseItems[TPosition.U_BUJUK]->Dura, this.m_UseItems[TPosition.U_BUJUK]->DuraMax, 0, "");
                                        SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");
                                    }
                                }
                            }
                        }
                    }
                }
                base.Run();
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, new byte[] { nCheckCode }));
            }
        }

        public override void SysMsg(string sMsg, TMsgColor MsgColor, TMsgType MsgType)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SysMsg(sMsg, MsgColor, MsgType);
        }

        public unsafe void SendSocket(TDefaultMessage DefMsg, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            ((TPlayObject)(this.m_Master)).SendSocket(DefMsg, sMsg);
        }

        public unsafe void SendSocket(TDefaultMessage* DefMsg, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            ((TPlayObject)(this.m_Master)).SendSocket(DefMsg, sMsg);
        }

        public void SendDefMessage(ushort wIdent, int nRecog, int nParam, int nTag, int nSeries, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            ((TPlayObject)(this.m_Master)).SendDefMessage(wIdent, nRecog, (ushort)nParam, (ushort)nTag, (ushort)nSeries, sMsg);
        }

        public void SendMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int nParam1, int nParam2, int nParam3, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendMsg(BaseObject, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
        }

        public void SendUpdateMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendUpdateMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg);
        }

        public void SendDelayMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, uint dwDelay)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendDelayMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg, dwDelay);
        }

        public override void SendUpdateDelayMsg(TBaseObject BaseObject, ushort wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, uint dwDelay)
        {
            if (this.m_Master == null)
            {
                return;
            }
            if ((this.m_Master != null) && ((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
            {
                return;
            }
            this.m_Master.SendUpdateDelayMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg, dwDelay);
        }

        public unsafe TUserMagic* FindTogetherMagic()
        {
            return FindMagic(GetTogetherUseSpell());
        }

        // ȫ���޸�,��Ҫ�ĳ־�ֵ 
        // ����ְҵ,�ж�Ӣ�ۿ���ѧϰ���ּ���
        private int GetTogetherUseSpell()
        {
            int result;
            result = 0;
            if (this.m_Master == null)
            {
                return result;
            }
            switch (this.m_Master.m_btJob)
            {
                case 0:
                    switch (this.m_btJob)
                    {
                        case 0:
                            result = 60;
                            break;
                        case 1:
                            result = 62;
                            break;
                        case 2:
                            result = 61;
                            break;
                    }
                    break;
                case 1:
                    switch (this.m_btJob)
                    {
                        case 0:
                            result = 62;
                            break;
                        case 1:
                            result = 65;
                            break;
                        case 2:
                            result = 64;
                            break;
                    }
                    break;
                case 2:
                    switch (this.m_btJob)
                    {
                        case 0:
                            result = 61;
                            break;
                        case 1:
                            result = 64;
                            break;
                        case 2:
                            result = 63;
                            break;
                    }
                    break;
            }
            return result;
        }

        // ˢ��Ӣ�۵İ���
        public unsafe void ClientQueryBagItems()
        {
            TStdItem* Item;
            string sSENDMSG;
            TClientItem* ClientItem = null;
            TStdItem* StdItem;
            TUserItem* UserItem;
            string sUserItemName;
            if (this.m_Master != null)
            {
                if (((TPlayObject)(this.m_Master)).m_boCanQueryBag || this.m_boDeath)// �Ƿ����ˢ�°���  ��������ˢ�°���
                {
                    return;
                }
                ((TPlayObject)(this.m_Master)).m_boCanQueryBag = true;
                try
                {
                    sSENDMSG = "";
                    if (this.m_ItemList.Count > 0)
                    {
                        for (int I = 0; I < this.m_ItemList.Count; I++)
                        {
                            UserItem = (TUserItem*)this.m_ItemList[I];
                            if (UserItem != null)
                            {
                                Item = UserEngine.GetStdItem(UserItem->wIndex);
                                if (Item != null)
                                {
                                    StdItem = Item;
                                    ItemUnit.GetItemAddValue(UserItem, StdItem);
                                    ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                                    ClientItem->s = *StdItem;
                                    //Move(StdItem, ClientItem->s, sizeof(TStdItem));
                                    // ȡ�Զ�����Ʒ����
                                    sUserItemName = "";
                                    if (UserItem->btValue[13] == 1)
                                    {
                                        sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                                    }
                                    if (sUserItemName != "")
                                    {
                                        // ClientItem->s->Name = sUserItemName;
                                    }
                                    if (UserItem->btValue[12] == 1)
                                    {
                                        // ��Ʒ����
                                        ClientItem->s.Reserved1 = 1;
                                    }
                                    else
                                    {
                                        ClientItem->s.Reserved1 = 0;
                                    }
                                    if ((StdItem->StdMode == 60) && (StdItem->Shape != 0))  // ����,���վ���
                                    {
                                        if (UserItem->btValue[0] != 0)
                                        {
                                            ClientItem->s.AC = UserItem->btValue[0]; // �Ƶ�Ʒ��
                                        }
                                        if (UserItem->btValue[1] != 0)
                                        {
                                            ClientItem->s.MAC = UserItem->btValue[1]; // �Ƶľƾ���
                                        }
                                    }
                                    if (StdItem->StdMode == 8)  // ��Ʋ���
                                    {
                                        if (UserItem->btValue[0] != 0)
                                        {
                                            ClientItem->s.AC = UserItem->btValue[0];// ���ϵ�Ʒ��
                                        }
                                    }
                                    ClientItem->Dura = UserItem->Dura;
                                    ClientItem->DuraMax = UserItem->DuraMax;
                                    ClientItem->MakeIndex = UserItem->MakeIndex;
                                    sSENDMSG = sSENDMSG + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                                }
                            }
                        }
                    }
                    if (sSENDMSG != "")
                    {
                        this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROBAGITEMS, HUtil32.ObjectToInt(this.m_Master), 0, 0, this.m_ItemList.Count, 0);
                        fixed (TDefaultMessage* msg = &this.m_DefMsg)
                        {
                            SendSocket(msg, sSENDMSG);
                        }
                    }
                    else
                    {
                        //�����Զ���װ��ʱ�������ﻹ�м�����Ʒ
                        this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROBAGITEMS, HUtil32.ObjectToInt(this.m_Master), 0, 0, this.m_ItemList.Count, 0);
                        fixed (TDefaultMessage* msg = &this.m_DefMsg)
                        {
                            SendSocket(msg, "");
                        }
                    }
                }
                finally
                {
                    ((TPlayObject)(this.m_Master)).m_boCanQueryBag = false;
                }
            }
        }

        // Ӣ�۳�ҩ
        public unsafe void GetBagItemCount()
        {
            int nOldBagCount;
            nOldBagCount = m_nItemBagCount;
            for (int I = GameConfig.nHeroBagItemCount.GetUpperBound(0); I >= GameConfig.nHeroBagItemCount.GetLowerBound(0); I--)
            {
                if (this.m_Abil.Level >= GameConfig.nHeroBagItemCount[I])
                {
                    switch (I)
                    {
                        case 0:
                            m_nItemBagCount = 10;
                            break;
                        case 1:
                            m_nItemBagCount = 20;
                            break;
                        case 2:
                            m_nItemBagCount = 30;
                            break;
                        case 3:
                            m_nItemBagCount = 35;
                            break;
                        case 4:
                            m_nItemBagCount = 40;
                            break;
                    }
                    break;
                }
            }
            if (nOldBagCount != m_nItemBagCount)
            {
                SendMsg(this.m_Master, Grobal2.RM_QUERYHEROBAGCOUNT, 0, m_nItemBagCount, 0, 0, "");
            }
        }

        public override unsafe bool AddItemToBag(TUserItem* UserItem)
        {
            bool result = false;
            if (this.m_Master == null)
            {
                return result;
            }
            if (this.m_ItemList.Count < m_nItemBagCount)
            {
                this.m_ItemList.Add((IntPtr)UserItem);
                WeightChanged();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// ����ʹ�õ�ħ��
        /// </summary>
        public unsafe void SendUseMagic()
        {
            string sSENDMSG = "";
            TUserMagic* UserMagic = null;
            TClientMagic* ClientMagic = null;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic != null)
                    {
                        ClientMagic = (TClientMagic*)Marshal.AllocHGlobal(sizeof(TClientMagic));
                        ClientMagic->Key = (char)(UserMagic->btKey);
                        ClientMagic->Level = UserMagic->btLevel;
                        ClientMagic->CurTrain = UserMagic->nTranPoint;
                        ClientMagic->Def = UserMagic->MagicInfo;
                        sSENDMSG = sSENDMSG + EncryptUnit.EncodeBuffer(ClientMagic, sizeof(TClientMagic)) + "/";
                    }
                }
            }
            if (sSENDMSG != "")
            {
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROSENDMYMAGIC, 0, 0, 0, this.m_MagicList.Count, 0);
                fixed (TDefaultMessage* msg = &this.m_DefMsg)
                {
                    SendSocket(msg, sSENDMSG);
                }
            }
        }

        /// <summary>
        /// ����ʹ�õ���Ʒ,�����ϵ�װ��
        /// </summary>
        public unsafe void SendUseitems()
        {
            TStdItem* Item;
            string sSENDMSG;
            TClientItem* ClientItem = null;
            TStdItem* StdItem;
            string sUserItemName;
            try
            {
                sSENDMSG = "";
                for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                {
                    if (this.m_UseItems[I]->wIndex > 0)
                    {
                        Item = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                        if (Item != null)
                        {
                            StdItem = Item;
                            ItemUnit.GetItemAddValue(this.m_UseItems[I], StdItem);
                            ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                            ClientItem->s = *StdItem;
                            // ȡ�Զ�����Ʒ����
                            sUserItemName = "";
                            if (this.m_UseItems[I]->btValue[13] == 1)
                            {
                                sUserItemName = ItemUnit.GetCustomItemName(this.m_UseItems[I]->MakeIndex, this.m_UseItems[I]->wIndex);
                            }
                            if (this.m_UseItems[I]->btValue[12] == 1)
                            {
                                // ��Ʒ����
                                ClientItem->s.Reserved1 = 1;
                            }
                            else
                            {
                                ClientItem->s.Reserved1 = 0;
                            }
                            if (sUserItemName != "")
                            {
                                //ClientItem->s->Name = sUserItemName;
                            }
                            ClientItem->Dura = this.m_UseItems[I]->Dura;
                            ClientItem->DuraMax = this.m_UseItems[I]->DuraMax;
                            ClientItem->MakeIndex = this.m_UseItems[I]->MakeIndex;
                            sSENDMSG = sSENDMSG + I + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                        }
                    }
                }
                if (sSENDMSG != "")
                {
                    this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_SENDHEROUSEITEMS, 0, 0, 0, 0, 0);
                    fixed (TDefaultMessage* msg = &this.m_DefMsg)
                    {
                        SendSocket(msg, sSENDMSG);
                    }
                }
                if (this.m_Master != null)
                {
                    ((TPlayObject)(this.m_Master)).IsItem_51(1);
                }
                // ���;�����ľ��� 
                if (WearFirDragon() && (m_nFirDragonPoint > 0))
                {
                    // �л���֮��,��ŭ������0ʱ����  
                    if (m_nFirDragonPoint > GameConfig.nMaxFirDragonPoint)
                    {
                        m_nFirDragonPoint = GameConfig.nMaxFirDragonPoint;// ��ֹŭ�������󳬹�
                    }
                    SendMsg(this, Grobal2.RM_FIRDRAGONPOINT, GameConfig.nMaxFirDragonPoint, m_nFirDragonPoint, 0, 0, "");// ����Ӣ��ŭ��ֵ 
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.SendUseitems");
            }
        }

        public unsafe void SendChangeItems(int nWhere1, int nWhere2, TUserItem* UserItem1, TUserItem* UserItem2)
        {
            TStdItem* StdItem1;
            TStdItem* StdItem2;
            TStdItem* StdItem80;
            TClientItem* ClientItem = null;
            string sUserItemName;
            string sSendText;
            sSendText = "";
            if (UserItem1 != null)
            {
                StdItem1 = UserEngine.GetStdItem(UserItem1->wIndex);
                if (StdItem1 != null)
                {
                    StdItem80 = StdItem1;
                    ItemUnit.GetItemAddValue(UserItem1, StdItem80);
                    ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                    ClientItem->s = *StdItem80;
                    //Move(StdItem80, ClientItem->s, sizeof(TStdItem));
                    // ȡ�Զ�����Ʒ����
                    sUserItemName = "";
                    if (UserItem1->btValue[13] == 1)
                    {
                        sUserItemName = ItemUnit.GetCustomItemName(UserItem1->MakeIndex, UserItem1->wIndex);
                    }
                    if (sUserItemName != "")
                    {
                        //ClientItem->s->Name = sUserItemName;
                    }
                    ClientItem->MakeIndex = UserItem1->MakeIndex;
                    ClientItem->Dura = UserItem1->Dura;
                    ClientItem->DuraMax = UserItem1->DuraMax;
                    sSendText = "0/" + nWhere1 + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                }
            }
            if (UserItem2 != null)
            {
                StdItem2 = UserEngine.GetStdItem(UserItem2->wIndex);
                if (StdItem2 != null)
                {
                    StdItem2 = UserEngine.GetStdItem(UserItem2->wIndex);
                    StdItem80 = StdItem2;
                    ItemUnit.GetItemAddValue(UserItem2, StdItem80);
                    ClientItem->s = *StdItem80;
                    // ȡ�Զ�����Ʒ����
                    sUserItemName = "";
                    if (UserItem2->btValue[13] == 1)
                    {
                        sUserItemName = ItemUnit.GetCustomItemName(UserItem2->MakeIndex, UserItem2->wIndex);
                    }
                    if (sUserItemName != "")
                    {
                        //ClientItem->s->Name = sUserItemName;
                    }
                    ClientItem->MakeIndex = UserItem2->MakeIndex;
                    ClientItem->Dura = UserItem2->Dura;
                    ClientItem->DuraMax = UserItem2->DuraMax;
                    if (sSendText == "")
                    {
                        sSendText = "1/" + nWhere2 + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                    }
                    else
                    {
                        sSendText = sSendText + "1/" + nWhere2 + "/" + EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)) + "/";
                    }
                }
            }
            if (sSendText != "")
            {
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROCHANGEITEM, Convert.ToInt32(this.m_Master), 0, 0, 0, 0);
                fixed (TDefaultMessage* msg = &this.m_DefMsg)
                {
                    SendSocket(msg, sSendText);
                }
            }
        }

        public void SendDelItemList(List<string> ItemList)
        {
            int I;
            string s10;
            s10 = "";
            if (ItemList.Count > 0)
            {
                for (I = 0; I < ItemList.Count; I++)
                {
                    //s10 = s10 + ItemList[I] + "/" + (((int)ItemList[I])).ToString() + "/";
                }
            }
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HERODELITEMS, 0, 0, 0, ItemList.Count, 0);
            //SendSocket(this.m_DefMsg, EncryptUnit.EncodeString(s10));
        }

        /// <summary>
        /// ����ɾ����Ʒ
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void SendDelItems(TUserItem* UserItem)
        {
            TStdItem* StdItem;
            TStdItem* StdItem80;
            TClientItem* ClientItem = null;
            string sUserItemName;
            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
            if (StdItem != null)
            {
                StdItem80 = StdItem;
                ItemUnit.GetItemAddValue(UserItem, StdItem80);
                ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                ClientItem->s = *StdItem80;
                //Move(StdItem80, ClientItem->s, sizeof(TStdItem));
                // ȡ�Զ�����Ʒ����
                sUserItemName = "";
                if (UserItem->btValue[13] == 1)
                {
                    sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                }
                if (sUserItemName != "")
                {
                    //ClientItem->s->Name = sUserItemName;
                }
                if (UserItem->btValue[12] == 1)
                {
                    // ��Ʒ����
                    ClientItem->s.Reserved1 = 1;
                }
                else
                {
                    ClientItem->s.Reserved1 = 0;
                }
                ClientItem->MakeIndex = UserItem->MakeIndex;
                ClientItem->Dura = UserItem->Dura;
                ClientItem->DuraMax = UserItem->DuraMax;
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HERODELITEM, HUtil32.ObjectToInt(this.m_Master), 0, 0, 1, 0);
                SendSocket(this.m_DefMsg, EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)));
            }
        }

        /// <summary>
        /// ����������Ʒ
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void SendAddItem(TUserItem* UserItem)
        {
            TStdItem* StdItem;
            TClientItem* ClientItem = null;
            string sUserItemName;
            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
            if (StdItem == null)
            {
                return;
            }
            ItemUnit.GetItemAddValue(UserItem, StdItem);
            ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
            ClientItem->s = *StdItem;
            //Move(StdItem, ClientItem->s, sizeof(TStdItem));
            // ȡ�Զ�����Ʒ����
            sUserItemName = "";
            if (UserItem->btValue[13] == 1)
            {
                sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
            }
            if (sUserItemName != "")
            {
                //ClientItem->s->Name = sUserItemName;
            }
            if (UserItem->btValue[12] == 1)
            {
                // ��Ʒ����
                ClientItem->s.Reserved1 = 1;
            }
            else
            {
                ClientItem->s.Reserved1 = 0;
            }
            ClientItem->MakeIndex = UserItem->MakeIndex;
            ClientItem->Dura = UserItem->Dura;
            ClientItem->DuraMax = UserItem->DuraMax;
            if (new ArrayList(new int[] { 15, 19, 20, 21, 22, 23, 24, 26 }).Contains(StdItem->StdMode))
            {
                if (UserItem->btValue[8] != 0)
                {
                    ClientItem->s.Shape = 130;
                }
            }
            if ((StdItem->StdMode == 60) && (StdItem->Shape != 0)) // ����,���վ���
            {
                if (UserItem->btValue[0] != 0)
                {
                    ClientItem->s.AC = UserItem->btValue[0];// �Ƶ�Ʒ��
                }
                if (UserItem->btValue[1] != 0)
                {
                    ClientItem->s.MAC = UserItem->btValue[1];// �Ƶľƾ���
                }
            }
            if (StdItem->StdMode == 8) // ��Ʋ���
            {
                if (UserItem->btValue[0] != 0)
                {
                    ClientItem->s.AC = UserItem->btValue[0];// ���ϵ�Ʒ��
                }
            }
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROADDITEM, HUtil32.ObjectToInt(this.m_Master), 0, 0, 1, 0);
            SendSocket(this.m_DefMsg, EncryptUnit.EncodeBuffer(ClientItem, sizeof(TClientItem)));
        }

        /// <summary>
        /// ������Ʒ
        /// </summary>
        /// <param name="UserItem"></param>
        public unsafe void SendUpdateItem(TUserItem* UserItem)
        {
            TStdItem* StdItem;
            TStdItem* StdItem80;
            TClientItem* ClientItem = null;
            string sUserItemName;
            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
            if (StdItem != null)
            {
                StdItem80 = StdItem;
                ItemUnit.GetItemAddValue(UserItem, StdItem80);
                ClientItem = (TClientItem*)Marshal.AllocHGlobal(sizeof(TClientItem));
                ClientItem->s = *StdItem80;// ȡ�Զ�����Ʒ����
                sUserItemName = "";
                if (UserItem->btValue[13] == 1)
                {
                    sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                }
                if (sUserItemName != "")
                {
                    HUtil32.StrToSByteArry(sUserItemName, ClientItem->s.Name, 14, ref ClientItem->s.NameLen);
                }
                if (UserItem->btValue[12] == 1) // ��Ʒ����
                {
                    ClientItem->s.Reserved1 = 1;
                }
                else
                {
                    ClientItem->s.Reserved1 = 0;
                }
                if ((StdItem->StdMode == 60) && (StdItem->Shape != 0))// ����,���վ���
                {
                    if (UserItem->btValue[0] != 0) // �Ƶ�Ʒ��
                    {
                        ClientItem->s.AC = UserItem->btValue[0];
                    }
                    if (UserItem->btValue[1] != 0)// �Ƶľƾ���
                    {
                        ClientItem->s.MAC = UserItem->btValue[1];
                    }
                }
                ClientItem->MakeIndex = UserItem->MakeIndex;
                ClientItem->Dura = UserItem->Dura;
                ClientItem->DuraMax = UserItem->DuraMax;
                this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROUPDATEITEM, HUtil32.ObjectToInt(this), 0, 0, 1, 0);
                byte[] data = new byte[sizeof(TClientItem)];
                fixed (byte* pb = data)
                {
                    *(TClientItem*)pb = *ClientItem;
                }
                fixed (TDefaultMessage* msg = &this.m_DefMsg)
                {
                    SendSocket(msg, EncryptUnit.EncodeBuffer(data, sizeof(TClientItem)));
                }
            }
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <returns></returns>
        public override string GetShowName()
        {
            string result;
            if (GameConfig.boNameSuffix) // �Ƿ���ʾ��׺ 
            {
                result = this.m_sCharName + "\\(" + this.m_Master.m_sCharName + GameConfig.sHeroNameSuffix + ")";
            }
            else
            {
                result = this.m_sCharName + GameConfig.sHeroName;
            }
            if (GameConfig.boUnKnowHum && this.IsUsesZhuLi()) // ���϶��Ҽ���ʾ������
            {
                result = "������";
            }
            return result;
        }

        new public unsafe void ItemDamageRevivalRing()
        {
            TStdItem* pSItem;
            int nDura;
            int tDura;
            THeroObject HeroObject;
            for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                if (this.m_UseItems[I]->wIndex > 0)
                {
                    pSItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                    if (pSItem != null)
                    {
                        if ((new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem->Shape)) || (((I == TPosition.U_WEAPON) || (I == TPosition.U_RIGHTHAND))
                            && (new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem->AniCount))))
                        {
                            nDura = this.m_UseItems[I]->Dura;
                            // 1.03
                            tDura = (int)HUtil32.Round((double)nDura / 1000);
                            nDura -= 1000;
                            if (nDura <= 0)
                            {
                                nDura = 0;
                                this.m_UseItems[I]->Dura = (ushort)nDura;
                                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                                {
                                    HeroObject = ((this) as THeroObject);
                                    HeroObject.SendDelItems(this.m_UseItems[I]);
                                }
                                this.m_UseItems[I]->wIndex = 0;
                                RecalcAbilitys();
                                this.CompareSuitItem(false);// ��װ������װ���Ա�
                            }
                            else
                            {
                                this.m_UseItems[I]->Dura = (ushort)nDura;
                            }
                            if (tDura != HUtil32.Round((double)nDura / 1000))
                            {
                                SendMsg(this, Grobal2.RM_HERODURACHANGE, I, nDura, this.m_UseItems[I]->DuraMax, 0, "");
                            }
                        }
                    }
                }
            }
        }

        public unsafe override void DoDamageWeapon(int nWeaponDamage)
        {
            int nDura;
            int nDuraPoint;
            THeroObject HeroObject;
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return;
            }
            nDura = this.m_UseItems[TPosition.U_WEAPON]->Dura;
            nDuraPoint = (int)HUtil32.Round(nDura / 1.03);
            nDura -= nWeaponDamage;
            if (nDura <= 0)
            {
                nDura = 0;
                this.m_UseItems[TPosition.U_WEAPON]->Dura = (ushort)nDura;
                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    HeroObject = ((this) as THeroObject);
                    HeroObject.SendDelItems(this.m_UseItems[TPosition.U_WEAPON]);
                }
                this.m_UseItems[TPosition.U_WEAPON]->wIndex = 0;
                SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_WEAPON, nDura, this.m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");
            }
            else
            {
                this.m_UseItems[TPosition.U_WEAPON]->Dura = (ushort)nDura;
            }
            if ((nDura / 1.03) != nDuraPoint)
            {
                SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_WEAPON, this.m_UseItems[TPosition.U_WEAPON]->Dura, this.m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");
            }
        }

        /// <summary>
        /// �ܹ���,����װ�����־�
        /// </summary>
        /// <param name="nDamage"></param>
        public unsafe override void StruckDamage(int nDamage)
        {
            int nDam;
            int nDura;
            int nOldDura;
            THeroObject HeroObject;
            TStdItem* StdItem;
            bool bo19;
            if (nDamage <= 0)
            {
                return;
            }
            nDam = HUtil32.Random(10) + 5;
            if (this.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] > 0)
            {
                nDam = (int)HUtil32.Round((double)nDam * (GameConfig.nPosionDamagarmor / 10));
                nDamage = (int)HUtil32.Round((double)nDamage * (GameConfig.nPosionDamagarmor / 10));
            }
            bo19 = false;
            if (this.m_UseItems[TPosition.U_DRESS]->wIndex > 0)
            {
                nDura = this.m_UseItems[TPosition.U_DRESS]->Dura;
                nOldDura = (int)HUtil32.Round((double)nDura / 1000);
                nDura -= nDam;
                if (nDura <= 0)
                {
                    if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                    {
                        HeroObject = ((this) as THeroObject);
                        HeroObject.SendDelItems(this.m_UseItems[TPosition.U_DRESS]);
                        this.m_UseItems[TPosition.U_DRESS]->wIndex = 0;
                        this.FeatureChanged();
                    }
                    this.m_UseItems[TPosition.U_DRESS]->wIndex = 0;
                    this.m_UseItems[TPosition.U_DRESS]->Dura = 0;
                    bo19 = true;
                }
                else
                {
                    this.m_UseItems[TPosition.U_DRESS]->Dura = (ushort)nDura;
                }
                if (nOldDura != (int)HUtil32.Round((double)nDura / 1000))
                {
                    SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_DRESS, nDura, this.m_UseItems[TPosition.U_DRESS]->DuraMax, 0, "");
                }
            }
            for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                if ((this.m_UseItems[I]->wIndex > 0) && (HUtil32.Random(8) == 0))
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                    if ((StdItem != null) && (((StdItem->StdMode == 2) && (StdItem->AniCount == 21)) || (StdItem->StdMode == 25) || (StdItem->StdMode == 7)))  // ��ף����,����֮����Ʒ������
                    {
                        continue;
                    }
                    nDura = this.m_UseItems[I]->Dura;
                    nOldDura = (int)HUtil32.Round((double)nDura / 1000);
                    nDura -= nDam;
                    if (nDura <= 0)
                    {
                        if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                        {
                            HeroObject = ((this) as THeroObject);
                            HeroObject.SendDelItems(this.m_UseItems[I]);
                            this.m_UseItems[I]->wIndex = 0;
                            this.FeatureChanged();
                        }
                        this.m_UseItems[I]->wIndex = 0;
                        this.m_UseItems[I]->Dura = 0;
                        bo19 = true;
                    }
                    else
                    {
                        this.m_UseItems[I]->Dura = (ushort)nDura;
                    }
                    if (nOldDura != (int)HUtil32.Round((double)nDura / 1000))
                    {
                        SendMsg(this, Grobal2.RM_HERODURACHANGE, I, nDura, this.m_UseItems[I]->DuraMax, 0, "");
                    }
                }
            }
            if (bo19)
            {
                RecalcAbilitys();
                this.CompareSuitItem(false);// ��װ������װ���Ա�
            }
            this.DamageHealth(nDamage);
        }

        /// <summary>
        /// Ӣ������Ʒ
        /// </summary>
        /// <param name="sItemName"></param>
        /// <param name="nItemIdx"></param>
        /// <returns></returns>
        public unsafe bool ClientDropItem(string sItemName, int nItemIdx)
        {
            bool result;
            int I;
            int wIndex;
            int MakeIndex;
            TUserItem* UserItem;
            TStdItem* StdItem;
            string sUserItemName;
            byte nCode;
            result = false;
            nCode = 0;
            ((TPlayObject)(this.m_Master)).m_boCanQueryBag = true;// ����Ʒʱ,����ˢ�°���
            try
            {
                try
                {
                    if (GameConfig.boInSafeDisableDrop && this.InSafeZone())
                    {
                        SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, HUtil32.ObjectToInt(this), 0, 0, GameMsgDef.g_sCanotDropInSafeZoneMsg);
                        return result;
                    }
                    nCode = 1;
                    if (!m_boCanDrop)
                    {
                        SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, HUtil32.ObjectToInt(this), 0, 0, GameMsgDef.g_sCanotDropItemMsg);
                        return result;
                    }
                    nCode = 2;
                    if (sItemName.IndexOf(" ") > 0)
                    {
                        // �۷���Ʒ����(�ż���Ʒ�����ƺ������ʹ�ô���)
                        HUtil32.GetValidStr3(sItemName, ref sItemName, new string[] { " " });
                    }
                    nCode = 3;
                    for (I = this.m_ItemList.Count - 1; I >= 0; I--)
                    {
                        if (this.m_ItemList.Count <= 0)
                        {
                            break;
                        }
                        nCode = 4;
                        UserItem = (TUserItem*)this.m_ItemList[I];
                        if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                        {
                            StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                            nCode = 5;
                            if (StdItem == null)
                            {
                                continue;
                            }
                            // ȡ�Զ�����Ʒ����
                            sUserItemName = "";
                            if (UserItem->btValue[13] == 1)
                            {
                                sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                            }
                            if (sUserItemName == "")
                            {
                                sUserItemName = UserEngine.GetStdItemName(UserItem->wIndex);
                            }
                            if ((sUserItemName).ToLower().CompareTo((sItemName).ToLower()) == 0)
                            {
                                nCode = 6;
                                if (this.CheckItemValue(UserItem, 0))// �����Ʒ�Ƿ��ֹ��
                                {
                                    break;
                                }
                                nCode = 7;
                                if (this.PlugOfCheckCanItem(0, HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen), false, 0, 0))  // ��ֹ��Ʒ����(����������)
                                {
                                    break;
                                }
                                nCode = 9;
                                wIndex = UserItem->wIndex;
                                MakeIndex = UserItem->MakeIndex;
                                if (GameConfig.boControlDropItem && (StdItem->Price < GameConfig.nCanDropPrice))
                                {
                                    nCode = 10;
                                    this.m_ItemList.RemoveAt(I);
                                    ClearCopyItem(wIndex, MakeIndex);// ������Ʒ
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                    UserItem = null;
                                    result = true;
                                    break;
                                }
                                nCode = 11;
                                if (((TPlayObject)(this.m_Master)).m_boHeroLogOut)
                                {
                                    return result;
                                }
                                // Ӣ���˳�,��ʧ��(��ֹˢ��Ʒ)
                                if (this.DropItemDown(UserItem, 3, false, false, null, this.m_Master))
                                {
                                    nCode = 12;
                                    this.m_ItemList.RemoveAt(I);
                                    ClearCopyItem(wIndex, MakeIndex);// ������Ʒ
                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                    UserItem = null;
                                    result = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (result)
                    {
                        WeightChanged();
                    }
                }
                catch
                {
                    M2Share.MainOutMessage("{�쳣} THeroObject.ClientDropItem Code:" + nCode);
                }
            }
            finally
            {
                ((TPlayObject)(this.m_Master)).m_boCanQueryBag = false;// ����Ʒʱ,����ˢ�°���
            }
            return result;
        }

        /// <summary>
        /// ȫ���޸�,��Ҫ�ĳ־�ֵ
        /// </summary>
        /// <returns></returns>
        private unsafe int RepairAllItemDura()
        {
            int result;
            int nWhere;
            TStdItem* StdItem;
            result = 0;
            for (nWhere = m_UseItems.GetLowerBound(0); nWhere <= m_UseItems.GetUpperBound(0); nWhere++)
            {
                if (this.m_UseItems[nWhere]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[nWhere]->wIndex);
                    if (StdItem != null)
                    {
                        if (((this.m_UseItems[nWhere]->DuraMax / 1000) > (this.m_UseItems[nWhere]->Dura / 1000)) && (StdItem->StdMode != 7) && (StdItem->StdMode != 25)
                            && (StdItem->StdMode != 43) && (StdItem->AniCount != 21))
                        {
                            if (this.CheckItemValue(this.m_UseItems[nWhere], 3)) // ��ֹ��
                            {
                                continue;
                            }
                            else if (this.PlugOfCheckCanItem(3, HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen), false, 0, 0)) // ��ֹ��Ʒ����(����������)
                            {
                                continue;
                            }
                            result += (this.m_UseItems[nWhere]->DuraMax - this.m_UseItems[nWhere]->Dura);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// �ٻ�ǿ����,���г��ı������7��
        /// </summary>
        /// <returns></returns>
        private bool CallMobeItem()
        {
            bool result;
            TBaseObject Slave;
            result = false;
            if (this.m_SlaveList.Count == 0)
            {
                SysMsg("��û���ٻ�����,����ʹ�ô���Ʒ!", TMsgColor.c_Red, TMsgType.t_Hint);
                return result;
            }
            if (this.m_SlaveList.Count > 0)
            {
                for (int I = 0; I < this.m_SlaveList.Count; I++)
                {
                    Slave = this.m_SlaveList[I];
                    if (Slave.m_btRaceServer == Grobal2.RC_PLAYMOSTER)//�����ܵ���
                    {
                        continue;
                    }
                    if (Slave.m_btSlaveExpLevel < 7)
                    {
                        Slave.m_btSlaveExpLevel = 7;
                        Slave.RecalcAbilitys();//�ı�ȼ�,ˢ������
                        Slave.RefNameColor();
                        Slave.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, "");// ������������
                        result = true;
                        SysMsg("�����ص�����Ӱ���£���ĳ���:" + Slave.m_sCharName + " �ɳ�Ϊ7��", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ȫ���޸�
        /// </summary>
        /// <param name="DureCount"></param>
        /// <param name="boDec"></param>
        private unsafe void RepairAllItem(int DureCount, bool boDec)
        {
            int nWhere;
            int RepCount;
            TStdItem* StdItem;
            for (nWhere = m_UseItems.GetLowerBound(0); nWhere <= m_UseItems.GetUpperBound(0); nWhere++)
            {
                if (this.m_UseItems[nWhere]->wIndex > 0)
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[nWhere]->wIndex);
                    if (StdItem != null)
                    {
                        if (((this.m_UseItems[nWhere]->DuraMax / 1000) > (this.m_UseItems[nWhere]->Dura / 1000)) && (StdItem->StdMode != 7) && (StdItem->StdMode != 25) && (StdItem->StdMode != 43) && (StdItem->AniCount != 21))
                        {
                            if (this.CheckItemValue(this.m_UseItems[nWhere], 3))//��ֹ��
                            {
                                continue;
                            }
                            else if (this.PlugOfCheckCanItem(3, HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen), false, 0, 0))// ��ֹ��Ʒ����(����������)
                            {
                                continue;
                            }
                            if (!boDec)
                            {
                                // �޸��㹻,��ֱ���޸�������
                                if ((this.m_UseItems[nWhere]->DuraMax / 1000) - (this.m_UseItems[nWhere]->Dura / 1000) > 0)
                                {
                                    SysMsg(HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen) + "�޲��ɹ���", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                                this.m_UseItems[nWhere]->Dura = this.m_UseItems[nWhere]->DuraMax;
                                SendMsg(this, Grobal2.RM_HERODURACHANGE, nWhere, this.m_UseItems[nWhere]->Dura, this.m_UseItems[nWhere]->DuraMax, 0, "");
                            }
                            else
                            {
                                RepCount = (this.m_UseItems[nWhere]->DuraMax / 1000) - (this.m_UseItems[nWhere]->Dura / 1000);
                                if (DureCount >= RepCount)
                                {
                                    DureCount -= RepCount;
                                    if ((this.m_UseItems[nWhere]->DuraMax / 1000) - (this.m_UseItems[nWhere]->Dura / 1000) > 0)
                                    {
                                        SysMsg(HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen) + "�޲��ɹ���", TMsgColor.c_Green, TMsgType.t_Hint);
                                    }
                                    this.m_UseItems[nWhere]->Dura = this.m_UseItems[nWhere]->DuraMax;
                                    SendMsg(this, Grobal2.RM_HERODURACHANGE, nWhere, this.m_UseItems[nWhere]->Dura, this.m_UseItems[nWhere]->DuraMax, 0, "");
                                }
                                else if (DureCount > 0)
                                {
                                    DureCount = 0;
                                    this.m_UseItems[nWhere]->Dura = Convert.ToUInt16(this.m_UseItems[nWhere]->Dura + DureCount * 1000);
                                    SendMsg(this, Grobal2.RM_HERODURACHANGE, nWhere, this.m_UseItems[nWhere]->Dura, this.m_UseItems[nWhere]->DuraMax, 0, "");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public string ClientHeroUseItems_GetUnbindItemName(int nShape)
        {
            string result;
            int I;
            result = "";
            if (M2Share.g_UnbindList.Count > 0)
            {
                for (I = 0; I < M2Share.g_UnbindList.Count; I++)
                {
                    //if (((int)M2Share.g_UnbindList[I]) == nShape)
                    //{
                    //    result = M2Share.g_UnbindList[I];
                    //    break;
                    //}
                }
            }
            return result;
        }

        public unsafe bool ClientHeroUseItems_GetUnBindItems(string sItemName, int nCount)
        {
            bool result;
            int I;
            TUserItem* UserItem = null;
            result = false;
            if (nCount <= 0)
            {
                nCount = 1;
            }
            for (I = 0; I < nCount; I++)
            {
                UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                if (UserEngine.CopyToUserItemFromName(sItemName, UserItem))
                {
                    this.m_ItemList.Add((IntPtr)UserItem);
                    SendAddItem(UserItem);
                    result = true;
                }
                else
                {
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    break;
                }
            }
            return result;
        }

        public unsafe bool ClientHeroUseItems_FoundUserItem(TUserItem* Item)
        {
            bool result;
            int I;
            TUserItem* UserItem;
            result = false;
            if (this.m_ItemList.Count > 0)
            {
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem == Item)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// �ͻ���Ӣ�۰�����ʹ����Ʒ
        /// </summary>
        /// <param name="nItemIdx"></param>
        /// <param name="sItemName"></param>
        public unsafe void ClientHeroUseItems(int nItemIdx, string sItemName)
        {
            int I;
            int ItemCount;
            bool boEatOK;
            bool boSendUpDate;
            TUserItem* UserItem = null;
            TStdItem* StdItem = null;
            TUserItem* UserItem34 = null;
            ((TPlayObject)(this.m_Master)).m_boCanQueryBag = true;// ʹ����Ʒʱ,����ˢ�°���
            try
            {
                boEatOK = false;
                boSendUpDate = false;
                StdItem = null;
                if (m_boCanUseItem)
                {
                    if (!this.m_boDeath)
                    {
                        for (I = this.m_ItemList.Count - 1; I >= 0; I--)
                        {
                            if (this.m_ItemList.Count <= 0)
                            {
                                break;
                            }
                            UserItem = (TUserItem*)this.m_ItemList[I];
                            if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                            {
                                UserItem34 = UserItem;
                                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                if (StdItem != null)
                                {
                                    if (!this.m_PEnvir.AllowStdItems(UserItem->wIndex))
                                    {
                                        SysMsg(string.Format(GameMsgDef.g_sCanotMapUseItemMsg, HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen)), TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                        break;
                                    }
                                    if (this.PlugOfCheckCanItem(8, HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen), false, 0, 0))
                                    {
                                        break;
                                    }
                                    switch (StdItem->StdMode)
                                    {
                                        case 0:
                                        case 1:
                                        case 3:
                                            // ��ֹ��Ʒ����(����������) 20080729
                                            // ҩ
                                            if (EatItems(StdItem))
                                            {
                                                if (UserItem != null)
                                                {
                                                    this.m_ItemList.RemoveAt(I);
                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                    //Dispose(UserItem);
                                                    UserItem = null;
                                                    //HUtil32.DisPoseAndNil(ref UserItem);
                                                }
                                                boEatOK = true;
                                            }
                                            break;
                                        case 2:
                                            if (StdItem->AniCount == 21)
                                            {
                                                // ף���� ���͵���Ʒ  20080315
                                                if (StdItem->Reserved != 56)
                                                {
                                                    if (UserItem->Dura > 0)
                                                    {
                                                        if ((this.m_ItemList.Count - 1) <= Grobal2.MAXBAGITEM)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                // �޸�Ϊ1000,20071229
                                                                UserItem->Dura -= 1000;
                                                                UserItem->DuraMax -= 1000;// ���ٴ���Ʒ����
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                                UserItem->DuraMax = 0;// ���ٴ���Ʒ����
                                                            }
                                                            // ��Ҫ�޸�UnbindList.txt,���� 3 ף����  20071229  3---Ϊ ף���޵����ֵ
                                                            ClientHeroUseItems_GetUnBindItems(ClientHeroUseItems_GetUnbindItemName(StdItem->Shape), 1);
                                                            // ��һ��ף����  20080310
                                                            if (UserItem->DuraMax == 0)
                                                            {
                                                                // ���ܴ�ȡ��Ʒ,��ɾ����Ʒ
                                                                if (UserItem != null)
                                                                {
                                                                    this.m_ItemList.RemoveAt(I);
                                                                    //Dispose(UserItem);
                                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                    UserItem = null;
                                                                    //HUtil32.DisPoseAndNil(ref UserItem);
                                                                }
                                                                boEatOK = true;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // Ȫˮ��
                                                    if (UserItem->Dura >= 1000)
                                                    {
                                                        if ((this.m_ItemList.Count - 1) <= Grobal2.MAXBAGITEM)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                UserItem->Dura -= 1000;
                                                                // Dec(UserItem->DuraMax, 1000);//20080324 ���ٴ���Ʒ����
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                                // UserItem->DuraMax:= 0;//20080324 ���ٴ���Ʒ����
                                                            }
                                                            // ��Ҫ�޸�UnbindList.txt,���� 1 Ȫˮ    1---Ϊ Ȫˮ�����ֵ
                                                            ClientHeroUseItems_GetUnBindItems(ClientHeroUseItems_GetUnbindItemName(StdItem->Shape), 1);//��һ��Ȫˮ 
                                                        }
                                                    }
                                                }
                                                boSendUpDate = true;
                                            }
                                            else
                                            {
                                                switch (StdItem->Shape)
                                                {
                                                    case 1:
                                                        // �ٻ�ǿ���� 20080329
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                if (CallMobeItem())
                                                                {
                                                                    // �ٻ�ǿ����,���г��ı������7��  20080221
                                                                    UserItem->Dura -= 1000;
                                                                    boEatOK = true;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                            }
                                                        }
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            boSendUpDate = true;
                                                            boEatOK = false;
                                                        }
                                                        else
                                                        {
                                                            if (UserItem != null)
                                                            {
                                                                UserItem->wIndex = 0;
                                                                // 20081014
                                                                this.m_ItemList.RemoveAt(I);
                                                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                //Dispose(UserItem);
                                                                UserItem = null;
                                                                //HUtil32.DisPoseAndNil(ref UserItem);
                                                            }
                                                        }
                                                        break;
                                                    case 9:
                                                        // ԭֵΪ1,20071229 //�޸���ˮ
                                                        ItemCount = RepairAllItemDura();
                                                        if ((UserItem->Dura > 0) && (ItemCount > 0))
                                                        {
                                                            // 100
                                                            if (UserItem->Dura >= (ItemCount / 10))
                                                            {
                                                                // 20080325
                                                                // 100
                                                                UserItem->Dura -= Convert.ToUInt16((ItemCount / 10));
                                                                RepairAllItem(ItemCount / 1000, false);
                                                                if (UserItem->Dura < 100)
                                                                {
                                                                    UserItem->Dura = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                                RepairAllItem(ItemCount / 1000, true);
                                                            }
                                                        }
                                                        boEatOK = false;
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            boSendUpDate = true;
                                                        }
                                                        else
                                                        {
                                                            if (UserItem != null)
                                                            {
                                                                this.m_ItemList.RemoveAt(I);
                                                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                //Dispose(UserItem);
                                                                UserItem = null;
                                                                //HUtil32.DisPoseAndNil(ref UserItem);
                                                            }
                                                            boEatOK = true;
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                        case 4:
                                            // Case
                                            // ��
                                            if (ReadBook(StdItem))
                                            {
                                                if (UserItem != null)
                                                {
                                                    this.m_ItemList.RemoveAt(I);
                                                    //Dispose(UserItem);
                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                    UserItem = null;
                                                    //HUtil32.DisPoseAndNil(ref UserItem);
                                                }
                                                boEatOK = true;
                                            }
                                            break;
                                        case 31:
                                            switch (StdItem->AniCount)
                                            {
                                                // �����Ʒ
                                                // Modify the A .. B: 0 .. 3
                                                case 0:
                                                    if ((this.m_ItemList.Count + 6 - 1) <= m_nItemBagCount)
                                                    {
                                                        if (UserItem != null)
                                                        {
                                                            this.m_ItemList.RemoveAt(I);
                                                            Marshal.FreeHGlobal((IntPtr)UserItem);
                                                            UserItem = null;
                                                        }
                                                        ClientHeroUseItems_GetUnBindItems(ClientHeroUseItems_GetUnbindItemName(StdItem->Shape), 6);
                                                        boEatOK = true;
                                                    }
                                                    break;
                                                // 0..3
                                                // Modify the A .. B: 4 .. 255
                                                case 4:
                                                    switch (StdItem->Shape)
                                                    {
                                                        case 0:
                                                            if (ClientHeroUseItems_FoundUserItem(UserItem)) // �Ȳ�����Ʒ��ɾ����Ʒ���ٴ���
                                                            {
                                                                if (UserItem != null)
                                                                {
                                                                    this.m_ItemList.RemoveAt(I);
                                                                    ClearCopyItem(UserItem->wIndex, UserItem->MakeIndex);// ������Ʒ
                                                                    Marshal.FreeHGlobal((IntPtr)UserItem);
                                                                    UserItem = null;
                                                                    UseStdmodeFunItem(StdItem);// ʹ����Ʒ�����ű���
                                                                }
                                                                boEatOK = true;
                                                            }
                                                            break;
                                                    }
                                                    break;
                                            }
                                            break;
                                        case 60:// ����
                                            if (StdItem->Shape != 0)
                                            {
                                                // ���վ���,����ֵ�ﵽҪ��
                                                if (!n_DrinkWineDrunk)
                                                {
                                                    if (this.m_Abil.MaxAlcohol >= StdItem->Need)
                                                    {
                                                        // ����ֵ�ﵽҪ��
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            if (UserItem->Dura >= 1000)
                                                            {
                                                                UserItem->Dura -= 1000;
                                                            }
                                                            else
                                                            {
                                                                UserItem->Dura = 0;
                                                            }
                                                            this.SendRefMsg(Grobal2.RM_MYSHOW, 7, 0, 0, 0, "");// �Ⱦ������� 
                                                            if (this.m_Abil.WineDrinkValue == 0)// �����ƶ�Ϊ0,���ʼʱ����
                                                            {
                                                                m_dwDecWineDrinkValueTick = HUtil32.GetTickCount();
                                                                m_dwAddAlcoholTick = HUtil32.GetTickCount();
                                                            }
                                                            this.m_Abil.WineDrinkValue += (ushort)(UserItem->btValue[1] * this.m_Abil.MaxAlcohol / 200);// ������ƶ� 
                                                            n_DrinkWineAlcohol = (byte)UserItem->btValue[1];// ����ʱ�ƵĶ��� 
                                                            n_DrinkWineQuality = (byte)UserItem->btValue[0];// ����ʱ�Ƶ�Ʒ�� 
                                                            if (this.m_Abil.WineDrinkValue >= this.m_Abil.MaxAlcohol) // ��ƶȳ�������,��������
                                                            {
                                                                this.m_Abil.WineDrinkValue = this.m_Abil.MaxAlcohol;
                                                                n_DrinkWineDrunk = true;// �Ⱦ����� 
                                                                SysMsg("(Ӣ��)�Ծ�ͷ�β���,����Ϊ����ϵ,�κ���ȥ����,������������!", TMsgColor.c_Red, TMsgType.t_Hint);
                                                                this.SendRefMsg(Grobal2.RM_MYSHOW, 9, 0, 0, 0, "");// ����������  
                                                            }
                                                            // ��ͨ��,Ʒ��2����,25%���ʼ���ʱ���� 20080713
                                                            if ((StdItem->AniCount == 1) && (n_DrinkWineQuality > 2) && (HUtil32.Random(4) == 0) && !n_DrinkWineDrunk)
                                                            {
                                                                switch (HUtil32.Random(2))
                                                                {
                                                                    case 0:// ���ӷ�����300��
                                                                        this.DefenceUp(300);
                                                                        break;
                                                                    case 1:// ����ħ��300��
                                                                        this.MagDefenceUp(300);
                                                                        break;
                                                                }
                                                            }
                                                            if ((StdItem->AniCount == 2) && !n_DrinkWineDrunk)
                                                            {
                                                                // ҩ�ƿ�����ҩ��ֵ
                                                                // Ʒ��Ϊ4����,ҩ��������ʱ���� 20080626
                                                                if (n_DrinkWineQuality > 4)
                                                                {
                                                                    switch (StdItem->Shape)
                                                                    {
                                                                        case 8:
                                                                            switch (this.m_btJob)
                                                                            {
                                                                                case 0:
                                                                                    // ���Ǿ� ���ӹ�������,ħ�����޻��������2��,Ч������600��
                                                                                    this.m_wStatusArrValue[0] = 2;// 600 * 1000
                                                                                    this.m_dwStatusArrTimeOutTick[0] = HUtil32.GetTickCount() + 600000;
                                                                                    break;
                                                                                case 1:
                                                                                    this.m_wStatusArrValue[1] = 2;// 600 * 1000
                                                                                    this.m_dwStatusArrTimeOutTick[1] = HUtil32.GetTickCount() + 600000;
                                                                                    break;
                                                                                case 2:
                                                                                    this.m_wStatusArrValue[2] = 2;// 600 * 1000
                                                                                    this.m_dwStatusArrTimeOutTick[2] = HUtil32.GetTickCount() + 600000;
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case 9:// �𲭾�  ��������ֵ����100��,Ч������600��
                                                                            this.m_wStatusArrValue[4] = 100;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[4] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                        case 10:// ������  ��������2��,Ч������600��
                                                                            this.m_wStatusArrValue[11] = 2;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[11] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                        case 11:// ���ξ�  ���ӷ�������4��,Ч������600��
                                                                            this.m_wStatusTimeArr[9] = 4;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[9] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                        case 12:// �ߵ���  ����ħ��ֵ����200��,Ч������600��
                                                                            this.m_wStatusArrValue[5] = 200;// 600 * 1000
                                                                            this.m_dwStatusArrTimeOutTick[5] = HUtil32.GetTickCount() + 600000;
                                                                            break;
                                                                    }
                                                                }
                                                                dw_UseMedicineTime = (ushort)GameConfig.nDesMedicineTick;// ʼ��ʹ��ҩ��ʱ��(12Сʱ)
                                                                this.m_Abil.MedicineValue += (ushort)UserItem->btValue[2];// ����ҩ��ֵ
                                                                if (this.m_Abil.MedicineValue >= this.m_Abil.MaxMedicineValue) // ��ǰҩ��ֵ�ﵽ��ǰ�ȼ�����ʱ
                                                                {
                                                                    this.m_Abil.MedicineValue -= this.m_Abil.MaxMedicineValue;
                                                                    switch ((n_MedicineLevel % 6))
                                                                    {
                                                                        case 0:// ������������
                                                                            switch (this.m_btJob)// ����/ħ��/��������(��ְҵ)
                                                                            {
                                                                                case 0:
                                                                                    this.m_Abil.DC = HUtil32.MakeLong(this.m_Abil.DC, this.m_Abil.DC + 1);
                                                                                    break;
                                                                                case 1:
                                                                                    this.m_Abil.MC = HUtil32.MakeLong(this.m_Abil.MC, this.m_Abil.MC + 1);
                                                                                    break;
                                                                                case 2:
                                                                                    this.m_Abil.SC = HUtil32.MakeLong(this.m_Abil.SC, this.m_Abil.SC + 1);
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case 1:// ��ħ������
                                                                            this.m_Abil.MAC = HUtil32.MakeLong(this.m_Abil.MAC + 1, this.m_Abil.MAC);
                                                                            break;
                                                                        case 2:// �ӷ�������
                                                                            this.m_Abil.AC = HUtil32.MakeLong(this.m_Abil.AC + 1, this.m_Abil.AC);
                                                                            break;
                                                                        case 3:// ����/ħ��/��������(��ְҵ)
                                                                            switch (this.m_btJob)
                                                                            {
                                                                                case 0:
                                                                                    this.m_Abil.DC = HUtil32.MakeLong(this.m_Abil.DC + 1, this.m_Abil.DC);
                                                                                    break;
                                                                                case 1:
                                                                                    this.m_Abil.MC = HUtil32.MakeLong(this.m_Abil.MC + 1, this.m_Abil.MC);
                                                                                    break;
                                                                                case 2:
                                                                                    this.m_Abil.SC = HUtil32.MakeLong(this.m_Abil.SC + 1, this.m_Abil.SC);
                                                                                    break;
                                                                            }
                                                                            break;
                                                                        case 4:// ħ������
                                                                            this.m_Abil.MAC = HUtil32.MakeLong(this.m_Abil.MAC, this.m_Abil.MAC + 1);
                                                                            break;
                                                                        case 5:// ��������
                                                                            this.m_Abil.AC = HUtil32.MakeLong(this.m_Abil.AC, this.m_Abil.AC + 1);
                                                                            break;
                                                                    }
                                                                    if (n_MedicineLevel < M2Share.MAXUPLEVEL)
                                                                    {
                                                                        n_MedicineLevel++;  // ���ӵȼ�
                                                                    }
                                                                    this.m_Abil.MaxMedicineValue = this.GetMedicineExp(n_MedicineLevel);   // ȡ������ĵȼ���Ӧ��ҩ��ֵ
                                                                    SysMsg("(Ӣ��)�ƾ�����������,�о�����״̬�����ı�", TMsgColor.c_Red, TMsgType.t_Hint); // ��ʾ�û�
                                                                }
                                                            }
                                                            RecalcAbilitys();
                                                            this.CompareSuitItem(false);// ��װ������װ���Ա�
                                                            SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                                                            boEatOK = true;
                                                        }
                                                        if (UserItem->Dura > 0)
                                                        {
                                                            boSendUpDate = true;
                                                            boEatOK = false;
                                                        }
                                                        else
                                                        {
                                                            if (UserItem != null)
                                                            {
                                                                UserItem->wIndex = 0;
                                                                this.m_ItemList.RemoveAt(I);
                                                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SysMsg("(Ӣ��)������ﵽ" + (StdItem->Need).ToString() + "��������!", TMsgColor.c_Red, TMsgType.t_Hint);// ��ʾ�û�
                                                    }
                                                }
                                                else
                                                {
                                                    SysMsg("(Ӣ��)�Ծ�ͷ�β���,����Ϊ����ϵ,�κ���ȥ����,������������!", TMsgColor.c_Red, TMsgType.t_Hint);
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.m_Master != null)
                    {
                        this.m_Master.SendMsg(M2Share.g_ManageNPC, Grobal2.RM_MENU_OK, 0, HUtil32.ObjectToInt(this.m_Master), 0, 0, GameMsgDef.g_sCanotUseItemMsg);
                    }
                }
                if (boEatOK)
                {
                    WeightChanged();
                    SendDefMessage(Grobal2.SM_HEROEAT_OK, 0, 0, 0, 0, "");
                    if (StdItem->NeedIdentify == 1)
                    {
                        M2Share.AddGameDataLog("11" + "\09" + this.m_sMapName + "\09" + (this.m_nCurrX).ToString() + "\09" + (this.m_nCurrY).ToString()
                            + "\09" + this.m_sCharName + "\09" + HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen) + "\09" + (UserItem34->MakeIndex).ToString() + "\09" + "(" + (HUtil32.LoWord(StdItem->DC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MC)).ToString()
                            + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString()
                            + "/" + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")"
                            + (UserItem34->btValue[0]).ToString() + "/" + (UserItem34->btValue[1]).ToString() + "/" + (UserItem34->btValue[2]).ToString() + "/" + (UserItem34->btValue[3]).ToString()
                            + "/" + (UserItem34->btValue[4]).ToString() + "/" + (UserItem34->btValue[5]).ToString() + "/" + (UserItem34->btValue[6]).ToString() + "/" + (UserItem34->btValue[7]).ToString()
                            + "/" + (UserItem34->btValue[8]).ToString() + "/" + (UserItem34->btValue[14]).ToString() + "\09" + "0");
                    }
                }
                else
                {
                    SendDefMessage(Grobal2.SM_HEROEAT_FAIL, 0, 0, 0, 0, "");
                }
                if ((UserItem != null) && boSendUpDate)
                {
                    SendUpdateItem(UserItem);
                }
            }
            finally
            {
                ((TPlayObject)(this.m_Master)).m_boCanQueryBag = false;
            }
        }

        /// <summary>
        /// ���ظı�
        /// </summary>
        public unsafe override void WeightChanged()
        {
            if (this.m_Master == null)
            {
                return;
            }
            this.m_WAbil.Weight = this.RecalcBagWeight();
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                SendUpdateMsg(this.m_Master, Grobal2.RM_HEROWEIGHTCHANGED, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// ˢ������
        /// </summary>
        public void RefMyStatus()
        {
            RecalcAbilitys();
            this.CompareSuitItem(false);  // ��װ������װ���Ա�
            this.m_Master.SendMsg(this.m_Master, Grobal2.RM_MYSTATUS, 0, 1, 0, 0, "");
        }

        /// <summary>
        /// ʹ����Ʒ
        /// </summary>
        /// <param name="StdItem"></param>
        /// <returns></returns>
        public unsafe bool EatItems(TStdItem* StdItem)
        {
            bool result;
            bool bo06;
            result = false;
            if (this.m_PEnvir.m_boNODRUG)
            {
                SysMsg(GameMsgDef.sCanotUseDrugOnThisMap, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                return result;
            }
            switch (StdItem->StdMode)
            {
                case 0:
                    switch (StdItem->Shape)
                    {
                        case 1:// �����ڹ�������Ʒ
                            this.IncHealthSpell(StdItem->AC, StdItem->MAC);
                            result = true;
                            break;
                        case 2://Ӣ�۲���ʹ���ڹ���Ʒ  
                            this.m_boUserUnLockDurg = true;
                            result = true;
                            break;
                        case 3:
                            break;
                        default:
                            if ((StdItem->AC > 0))
                            {
                                this.m_nIncHealth += StdItem->AC;
                            }
                            if ((StdItem->MAC > 0))
                            {
                                this.m_nIncSpell += StdItem->MAC;
                            }
                            result = true;
                            break;
                    }
                    break;
                case 1:
                    result = false;
                    break;
                case 3:
                    if (StdItem->Shape == 12)
                    {
                        bo06 = false;
                        if (HUtil32.LoWord(StdItem->DC) > 0)
                        {
                            this.m_wStatusArrValue[0] = (ushort)HUtil32.LoWord(StdItem->DC);
                            this.m_dwStatusArrTimeOutTick[0] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("����������" + HUtil32.HiWord(StdItem->MAC) + "��", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.LoWord(StdItem->MC) > 0)
                        {
                            this.m_wStatusArrValue[1] = (ushort)HUtil32.LoWord(StdItem->MC);
                            this.m_dwStatusArrTimeOutTick[1] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("ħ��������" + HUtil32.HiWord(StdItem->MAC) + "��", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if ((StdItem->SC) > 0)
                        {
                            this.m_wStatusArrValue[2] = (ushort)HUtil32.LoWord(StdItem->SC);
                            this.m_dwStatusArrTimeOutTick[2] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("��������" + HUtil32.HiWord(StdItem->MAC) + "��", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.HiWord(StdItem->AC) > 0)
                        {
                            this.m_wStatusArrValue[3] = (ushort)HUtil32.HiWord(StdItem->AC);
                            this.m_dwStatusArrTimeOutTick[3] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("�����ٶ�����" + HUtil32.HiWord(StdItem->MAC) + "��", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.LoWord(StdItem->AC) > 0)
                        {
                            this.m_wStatusArrValue[4] = (ushort)HUtil32.LoWord(StdItem->AC);
                            this.m_dwStatusArrTimeOutTick[4] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("����ֵ����" + HUtil32.HiWord(StdItem->MAC) + "��", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (HUtil32.LoWord(StdItem->MAC) > 0)
                        {
                            this.m_wStatusArrValue[5] = (ushort)HUtil32.LoWord(StdItem->MAC);
                            this.m_dwStatusArrTimeOutTick[5] = Convert.ToUInt32(HUtil32.GetTickCount() + HUtil32.HiWord(StdItem->MAC) * 1000);
                            SysMsg("ħ��ֵ����" + HUtil32.HiWord(StdItem->MAC) + "��", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                            bo06 = true;
                        }
                        if (bo06)
                        {
                            RecalcAbilitys();
                            this.CompareSuitItem(false);// ��װ������װ���Ա�
                            SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                            SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
                            result = true;
                        }
                    }
                    else
                    {
                        result = EatUseItems(StdItem->Shape);
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// ѧϰ����
        /// </summary>
        /// <param name="StdItem"></param>
        /// <returns></returns>
        public unsafe bool ReadBook(TStdItem* StdItem)
        {
            bool result;
            TMagic* Magic;
            TUserMagic* UserMagic = null;
            int I;
            byte btOldKey;
            result = false;
            if (!(new ArrayList(new int[] { 88, 89, 91 }).Contains(StdItem->NeedLevel)))
            {
                Magic = UserEngine.FindHeroMagic(HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen));
                if (Magic != null)
                {
                    if (!this.IsTrainingSkill(Magic->wMagicId)) // ������ܲ�����ְҵ
                    {
                        if (((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "Ӣ��")
                            || (HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "�ڹ�") || (HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "����")) &&
                            ((Magic->btJob == 99) || (Magic->btJob == this.m_btJob) || (Magic->wMagicId == 75)))
                        {
                            if ((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "�ڹ�") || (HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "����"))// �ڹ�����
                            {
                                if (m_boTrainingNG)  // ѧ���ڹ��ķ�����ѧϰ����
                                {
                                    if (m_NGLevel >= Magic->TrainLevel[0])// �ȼ��ﵽ���Ҫ��
                                    {
                                        UserMagic->MagicInfo = *Magic;
                                        UserMagic->wMagIdx = Magic->wMagicId;
                                        UserMagic->btKey = 0;
                                        UserMagic->btLevel = 0;
                                        UserMagic->nTranPoint = 0;
                                        this.m_MagicList.Add((IntPtr)UserMagic);
                                        RecalcAbilitys();
                                        this.CompareSuitItem(false);// ��װ������װ���Ա�
                                        SendAddMagic(UserMagic);
                                        ((TPlayObject)(this.m_Master)).HeroAddSkillFunc(Magic->wMagicId);// Ӣ��ѧ���ܴ���
                                        result = true;
                                        if ((HUtil32.SBytePtrToString(Magic->sDescr, 0, Magic->DescrLen) == "����"))
                                        {
                                            this.m_boCanUseBatter = true;
                                        }
                                    }
                                    else
                                    {
                                        SysMsg(string.Format("(Ӣ��) �ڹ��ķ��ȼ�û�дﵽ %d,����ѧϰ���ڹ����ܣ�����", Magic->TrainLevel[0]), TMsgColor.c_Red, TMsgType.t_Hint);
                                    }
                                }
                                else
                                {
                                    SysMsg("(Ӣ��) ûѧ���ڹ��ķ�,����ѧϰ���ڹ����ܣ�����", TMsgColor.c_Red, TMsgType.t_Hint);
                                }
                            }
                            else
                            {
                                // ��ͨ����
                                if ((Magic->wMagicId >= 60 && Magic->wMagicId <= 65) && (Magic->wMagicId != GetTogetherUseSpell()))
                                {
                                    SysMsg("(Ӣ��) ����ѧϰ�˺ϻ����ܣ�����", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                    return result;
                                }
                                if (this.m_Abil.Level >= Magic->TrainLevel[0])
                                {
                                    if ((Magic->wMagicId == 68) && ((m_MaxExp68 != 0) || (m_Exp68 != 0))) // �Ǿ�������
                                    {
                                        m_MaxExp68 = 0;
                                        m_Exp68 = 0;
                                    }
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = Magic->wMagicId;
                                    UserMagic->btKey = 0;
                                    UserMagic->btLevel = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                    RecalcAbilitys();
                                    this.CompareSuitItem(false);// ��װ������װ���Ա�
                                    SendAddMagic(UserMagic);
                                    ((TPlayObject)(this.m_Master)).HeroAddSkillFunc(Magic->wMagicId);// Ӣ��ѧ���ܴ���
                                    result = true;
                                }
                            }
                        }
                        else
                        {
                            SysMsg("(Ӣ��) ����ѧϰ�˼��ܣ�����", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(Ӣ��) �Ѿ�ѧ���˼���,������ѧϰ������", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                }
            }
            else
            {
                Magic = UserEngine.FindHeroMagic(StdItem->NeedLevel);
                if (this.m_Abil.Level >= Magic->TrainLevel[0])  // Ӣ����
                {
                    if ((Magic != null) && (StdItem->AC == 1))
                    {
                        for (I = this.m_MagicList.Count - 1; I >= 0; I--)
                        {
                            if (this.m_MagicList.Count <= 0)
                            {
                                break;
                            }
                            UserMagic = (TUserMagic*)this.m_MagicList[I];
                            if (UserMagic != null)
                            {
                                if (((new ArrayList(new int[] { 26, 45, 13 }).Contains(UserMagic->wMagIdx)) && (UserMagic->btLevel < 4)) || (UserMagic->wMagIdx != StdItem->NeedLevel))
                                {
                                    if (UserMagic->MagicInfo.wMagicId == StdItem->Need)
                                    {
                                        ((this) as THeroObject).SendDelMagic(UserMagic);
                                        btOldKey = UserMagic->btKey;// �����ݼ�
                                        Marshal.FreeHGlobal((IntPtr)UserMagic);
                                        //Dispose(UserMagic);
                                        this.m_MagicList.RemoveAt(I);
                                        UserMagic->MagicInfo = *Magic;
                                        UserMagic->wMagIdx = Magic->wMagicId;
                                        UserMagic->btKey = btOldKey;
                                        UserMagic->btLevel = 4;
                                        UserMagic->nTranPoint = 0;
                                        this.m_MagicList.Add((IntPtr)UserMagic);
                                        ((this) as THeroObject).SendAddMagic(UserMagic);
                                        RecalcAbilitys();
                                        this.CompareSuitItem(false);// ��װ������װ���Ա�
                                        ((TPlayObject)(this.m_Master)).HeroAddSkillFunc(Magic->wMagicId);// Ӣ��ѧ���ܴ���
                                        result = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        SysMsg("(Ӣ��) ����ѧϰ����ļ��ܣ�����", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                }
                else
                {
                    SysMsg("(Ӣ��) ����ѧϰ�˼��ܣ�����", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            return result;
        }

        /// <summary>
        /// �������ӵ�ħ��
        /// </summary>
        /// <param name="UserMagic"></param>
        public unsafe void SendAddMagic(TUserMagic* UserMagic)
        {
            TClientMagic* ClientMagic = (TClientMagic*)Marshal.AllocHGlobal(sizeof(TUserMagic)); ;
            ClientMagic->Key = (char)UserMagic->btKey;
            ClientMagic->Level = UserMagic->btLevel;
            ClientMagic->CurTrain = UserMagic->nTranPoint;
            ClientMagic->Def = UserMagic->MagicInfo;
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROADDMAGIC, 0, 0, 0, 1, 0);
            byte[] data = new byte[sizeof(TClientMagic)];
            fixed (byte* pb = data)
            {
                *(TClientMagic*)pb = *ClientMagic;
            }
            fixed (TDefaultMessage* msg = &this.m_DefMsg)
            {
                SendSocket(msg, EncryptUnit.EncodeBuffer(data, sizeof(TClientMagic)));
            }
        }

        /// <summary>
        /// ����ɾ��ħ��
        /// </summary>
        /// <param name="UserMagic"></param>
        public unsafe void SendDelMagic(TUserMagic* UserMagic)
        {
            this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HERODELMAGIC, UserMagic->wMagIdx, 0, 0, 1, 0);
            fixed (TDefaultMessage* msg = &this.m_DefMsg)
            {
                SendSocket(msg, "");
            }
        }

        public bool IsEnoughBag()
        {
            bool result;
            result = false;
            if (this.m_ItemList.Count < m_nItemBagCount)
            {
                result = true;
            }
            return result;
        }

        public unsafe override void MakeWeaponUnlock()
        {
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return;
            }
            if (this.m_UseItems[TPosition.U_WEAPON]->btValue[3] > 0)
            {
                this.m_UseItems[TPosition.U_WEAPON]->btValue[3] -= 1;
                SysMsg(GameMsgDef.g_sTheWeaponIsCursed, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
            }
            else
            {
                if (this.m_UseItems[TPosition.U_WEAPON]->btValue[4] < 10)
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[4]++;
                    SysMsg(GameMsgDef.g_sTheWeaponIsCursed, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                RecalcAbilitys();
                this.CompareSuitItem(false);// ��װ������װ���Ա�
                SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
            }
        }

        /// <summary>
        /// ʹ��ף����,������������
        /// </summary>
        /// <returns></returns>
        public unsafe bool WeaptonMakeLuck()
        {
            bool result;
            TStdItem* StdItem;
            int nRand;
            bool boMakeLuck;
            result = false;
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return result;
            }
            nRand = 0;
            StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_WEAPON]->wIndex);
            if (StdItem != null)
            {
                nRand = Math.Abs((HUtil32.HiWord(StdItem->DC) - HUtil32.LoWord(StdItem->DC))) / 5;
            }
            if (HUtil32.Random(GameConfig.nWeaponMakeUnLuckRate) == 1)
            {
                MakeWeaponUnlock();
            }
            else
            {
                boMakeLuck = false;
                if (this.m_UseItems[TPosition.U_WEAPON]->btValue[4] > 0)
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[4] -= 1;// '��������������...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                else if (this.m_UseItems[TPosition.U_WEAPON]->btValue[3] < GameConfig.nWeaponMakeLuckPoint1)
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[3]++;// '��������������...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                else if ((this.m_UseItems[TPosition.U_WEAPON]->btValue[3] < GameConfig.nWeaponMakeLuckPoint2) && (HUtil32.Random(nRand + GameConfig.nWeaponMakeLuckPoint2Rate) == 1))
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[3]++;// '��������������...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                else if ((this.m_UseItems[TPosition.U_WEAPON]->btValue[3] < GameConfig.nWeaponMakeLuckPoint3) && (HUtil32.Random(nRand * GameConfig.nWeaponMakeLuckPoint3Rate) == 1))
                {
                    this.m_UseItems[TPosition.U_WEAPON]->btValue[3]++;// '��������������...'
                    SysMsg(GameMsgDef.g_sWeaptonMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    boMakeLuck = true;
                }
                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    RecalcAbilitys();
                    this.CompareSuitItem(false);// ��װ������װ���Ա�
                    SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                    SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
                }
                if (!boMakeLuck)
                {
                    SysMsg(GameMsgDef.g_sWeaptonNotMakeLuck, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
            }
            result = true;
            return result;
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <returns></returns>
        public unsafe bool RepairWeapon()
        {
            bool result;
            int nDura;
            TUserItem* UserItem = null;
            result = false;
            *UserItem = *this.m_UseItems[TPosition.U_WEAPON];
            if ((UserItem->wIndex <= 0) || (UserItem->DuraMax <= UserItem->Dura))
            {
                return result;
            }
            UserItem->DuraMax -= Convert.ToUInt16((UserItem->DuraMax - UserItem->Dura) / GameConfig.nRepairItemDecDura);
            nDura = HUtil32._MIN(5000, UserItem->DuraMax - UserItem->Dura);
            if (nDura > 0)
            {
                UserItem->Dura += (ushort)nDura;
                if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    SendMsg(this.m_Master, Grobal2.RM_HERODURACHANGE, 1, UserItem->Dura, UserItem->DuraMax, 0, "");  // '�����޸��ɹ�...'
                    SysMsg(GameMsgDef.g_sWeaponRepairSuccess, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// �ص�Ʒ�����޸�
        /// </summary>
        /// <returns></returns>
        public unsafe bool SuperRepairWeapon()
        {
            bool result = false;
            if (this.m_UseItems[TPosition.U_WEAPON]->wIndex <= 0)
            {
                return result;
            }
            this.m_UseItems[TPosition.U_WEAPON]->Dura = this.m_UseItems[TPosition.U_WEAPON]->DuraMax;
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                SendMsg(this.m_Master, Grobal2.RM_HERODURACHANGE, 1, this.m_UseItems[TPosition.U_WEAPON]->Dura, this.m_UseItems[TPosition.U_WEAPON]->DuraMax, 0, "");// '�����޸��ɹ�...'
                SysMsg(GameMsgDef.g_sWeaponRepairSuccess, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
            }
            result = true;
            return result;
        }

        /// <summary>
        /// Ӣ���޼�����
        /// 0����������40%   1������60%   2������80%  3������100%  ʱ�䶼��6��
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe bool AbilityUp(TUserMagic* UserMagic)
        {
            bool result;
            int nSpellPoint;
            int n14;
            result = false;
            nSpellPoint = GetSpellPoint(UserMagic);
            if (nSpellPoint > 0)
            {
                if (this.m_WAbil.MP < nSpellPoint)
                {
                    return result;
                }
                if (GameConfig.boAbilityUpFixMode)// �޼�����ʹ�ù̶�ʱ��ģʽ
                {
                    n14 = GameConfig.nAbilityUpFixUseTime;// �޼�����ʹ�ù̶�ʱ��
                }
                else
                {
                    n14 = (UserMagic->btLevel * 2) + 2 + GameConfig.nAbilityUpUseTime;
                }
                this.m_dwStatusArrTimeOutTick[2] = Convert.ToUInt32(HUtil32.GetTickCount() + n14 * 1000);
                this.m_wStatusArrValue[2] = (ushort)HUtil32.Round(HUtil32.HiWord(this.m_WAbil.SC) * (UserMagic->btLevel * 0.2 + 0.4));// ����ֵ
                SysMsg("(Ӣ��) ����˲ʱ����" + this.m_wStatusArrValue[2] + "������ " + n14 + " ��", TMsgColor.c_Green, TMsgType.t_Hint);
                RecalcAbilitys();
                this.CompareSuitItem(false);// ��װ������װ���Ա�
                SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                SendMsg(this, Grobal2.RM_HEROSUBABILITY, 0, 0, 0, 0, "");
                result = true;
            }
            return result;
        }

        public void GainExp(uint dwExp)
        {
            WinExp(dwExp);
        }

        // ȡ�þ���
        public unsafe void WinExp(uint dwExp)
        {
            if (this.m_Abil.Level > GameConfig.nLimitExpLevel)
            {
                dwExp = (uint)GameConfig.nLimitExpValue;
                GetExp(dwExp);
            }
            else if (dwExp > 0)
            {
                dwExp = GameConfig.dwKillMonExpMultiple * dwExp;// ϵͳָ��ɱ�־��鱶��
                dwExp = (uint)HUtil32.Round((double)(m_nKillMonExpRate / 100) * dwExp);// ����ָ����ɱ�־���ٷ���
                if (this.m_PEnvir.m_boEXPRATE) // ��ͼ��ָ��ɱ�־��鱶��
                {
                    dwExp = (uint)HUtil32.Round((double)(this.m_PEnvir.m_nEXPRATE / 100) * dwExp);
                }
                if (this.m_boExpItem)// ��Ʒ���鱶��
                {
                    dwExp = (uint)HUtil32.Round((double)this.m_rExpItem * dwExp);
                }
                GetExp(dwExp);
            }
        }

        /// <summary>
        /// ȡ���������� 
        /// </summary>
        /// <param name="dwExp"></param>
        /// <param name="Code">0-ɱ�ַ��� 1-��ɱ�ַ��� 2-����,˭������˭ 3-���˷���ɱ�־���</param>
        public unsafe void GetNGExp(uint dwExp, byte Code)
        {
            if (m_boTrainingNG)
            {
                if (this.m_Abil.Level > GameConfig.nLimitExpLevel)
                {
                    dwExp = (uint)GameConfig.nLimitExpValue;
                }
                else if ((dwExp > 0) && (Code == 0))
                {
                    dwExp = GameConfig.dwKillMonExpMultiple * dwExp;// ϵͳָ��ɱ�־��鱶��
                    dwExp = (uint)HUtil32.Round((double)(m_nKillMonExpRate / 100) * dwExp);// ����ָ����ɱ�־���ٷ���
                    if (this.m_PEnvir.m_boEXPRATE)
                    {
                        dwExp = (uint)HUtil32.Round((double)(this.m_PEnvir.m_nEXPRATE / 100) * dwExp);// ��ͼ��ָ��ɱ�־��鱶��
                    }
                    if (this.m_boExpItem) // ��Ʒ���鱶��
                    {
                        dwExp = (uint)HUtil32.Round((double)this.m_rExpItem * dwExp);
                    }
                }
                else if ((dwExp > 0) && (Code == 3))
                {
                    dwExp = (uint)Math.Abs(HUtil32.Round((double)dwExp * GameConfig.dwKillMonNGExpMultiple / 100)); // ɱ���ڹ����鱶��
                }
                if ((dwExp > 0))
                {
                    if (m_ExpSkill69 >= dwExp)
                    {
                        if ((int.MaxValue - m_ExpSkill69) < dwExp)
                        {
                            dwExp = uint.MaxValue - m_ExpSkill69;
                        }
                    }
                    else
                    {
                        if ((int.MaxValue - dwExp) < m_ExpSkill69)
                        {
                            dwExp = int.MaxValue - dwExp;
                        }
                    }
                    m_ExpSkill69 += dwExp;// �ڹ��ķ���ǰ����
                    if (this.m_Master != null)
                    {
                        if (!((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
                        {
                            // ֻ���͸������߹һ�����
                            SendMsg(this.m_Master, Grobal2.RM_HEROWINNHEXP, 0, dwExp, 0, 0, "");
                        }
                    }
                    if (m_ExpSkill69 >= m_MaxExpSkill69)
                    {
                        m_ExpSkill69 -= m_MaxExpSkill69;
                        m_NGLevel++;
                        m_MaxExpSkill69 = this.GetSkill69Exp(m_NGLevel, ref m_Skill69MaxNH);// ȡ�ڹ��ķ���������
                        m_Skill69NH = m_Skill69MaxNH;
                        this.SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, m_Skill69NH, m_Skill69MaxNH, 0, "");// ����ֵ�ñ��˿���
                        this.SendRefMsg(Grobal2.RM_MYSHOW, Grobal2.ET_OBJECTLEVELUP, 0, 0, 0, "");// ������������ 
                        NGLevelUpFunc();// �ڹ���������
                    }
                    this.SendNGData();
                }
            }
        }

        /// <summary>
        /// �����Ӣ�۾���
        /// </summary>
        /// <param name="dwExp"></param>
        public unsafe void GetExp(uint dwExp)
        {
            byte nCode = 0;
            try
            {
                if (this.m_Abil.Exp >= dwExp)
                {
                    if ((int.MaxValue - this.m_Abil.Exp) < (uint)dwExp)
                    {
                        dwExp = uint.MaxValue - this.m_Abil.Exp;
                    }
                }
                else
                {
                    if ((int.MaxValue - dwExp) < this.m_Abil.Exp)
                    {
                        dwExp = int.MaxValue - dwExp;
                    }
                }
                m_GetExp = dwExp;// Ӣ��ȡ�õľ���,$HeroGetExp����ʹ�� 
                if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
                {
                    M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroGetExp", false);// ȡ���鴥��
                }
                this.m_nWinExp += dwExp;
                nCode = 1;
                if (this.m_nWinExp >= GameConfig.nWinExp) // �ۼƾ���,�ﵽһ��ֵ,����Ӣ�۵��ҳ϶�
                {
                    nCode = 2;
                    this.m_nWinExp = 0;
                    m_nLoyal = m_nLoyal + GameConfig.nExpAddLoyal;
                    if (m_nLoyal > 10000)
                    {
                        m_nLoyal = 10000;
                    }
                    nCode = 3;
                    this.m_DefMsg = EncryptUnit.MakeDefaultMsg(Grobal2.SM_HEROABILITY, this.m_btGender, 0, this.m_btJob, m_nLoyal, 0);// ����Ӣ�۵��ҳ϶�
                    byte[] data = new byte[sizeof(TAbility)];
                    fixed (byte* pb = data)
                    {
                        *(TAbility*)pb = this.m_WAbil;
                    }
                    SendSocket(this.m_DefMsg, EncryptUnit.EncodeBuffer(data, sizeof(TAbility)));
                }
                nCode = 4;
                this.m_Abil.Exp += dwExp;
                //AddBodyLuck(dwExp * 0.002);
                nCode = 5;
                if ((this.m_Master != null))
                {
                    //ֻ���͸������߹һ�����
                    if (!((TPlayObject)(this.m_Master)).m_boNotOnlineAddExp)
                    {
                        SendMsg(this.m_Master, Grobal2.RM_HEROWINEXP, 0, dwExp, 0, 0, "");
                    }
                }
                if (this.m_Abil.Exp >= this.m_Abil.MaxExp)
                {
                    nCode = 6;
                    this.m_Abil.Exp -= this.m_Abil.MaxExp;
                    if ((this.m_Abil.Level < M2Share.MAXUPLEVEL) && (this.m_Abil.Level < GameConfig.nLimitExpLevel))
                    {
                        this.m_Abil.Level++; //�������Ƶȼ�
                    }
                    if (this.m_Abil.Level < GameConfig.nLimitExpLevel)
                    {
                        this.HasLevelUp(this.m_Abil.Level - 1); // �������Ƶȼ�
                    }
                    // AddBodyLuck(100);
                    nCode = 7;
                    // Ӣ��������¼��־
                    M2Share.AddGameDataLog("12" + "\09" + this.m_sMapName + "\09" + (this.m_Abil.Level).ToString() + "\09" + (this.m_Abil.Exp).ToString() + "/" + (this.m_Abil.MaxExp).ToString() + "\09" + this.m_sCharName + "\09" + "0" + "\09" + "0" + "\09" + "1" + "\09" + "(Ӣ��)");
                    nCode = 8;
                    this.IncHealthSpell(2000, 2000);
                }
                nCode = 9;
                if (this.m_Magic68Skill != null) // ѧ����������
                {
                    nCode = 10;
                    if (this.m_Magic68Skill->btLevel < 100)
                    {
                        m_Exp68 += dwExp;
                    }
                    nCode = 11;
                    if (m_Exp68 >= m_MaxExp68)// ������������,����������
                    {
                        m_Exp68 -= m_MaxExp68;
                        if (this.m_Magic68Skill->btLevel < 100)
                        {
                            this.m_Magic68Skill->btLevel++;
                        }
                        nCode = 12;
                        m_MaxExp68 = this.GetSkill68Exp(this.m_Magic68Skill->btLevel);
                        SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, this.m_Magic68Skill->MagicInfo.wMagicId, this.m_Magic68Skill->btLevel, this.m_Magic68Skill->nTranPoint, "", 100);
                    }
                    nCode = 13;
                    if ((this != null) && (this.m_Magic68Skill->btLevel < 100))
                    {
                        SendMsg(this, Grobal2.RM_HEROMAGIC68SKILLEXP, 0, 0, 0, 0, EncryptUnit.EncodeString(m_Exp68 + "/" + m_MaxExp68));
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.GetExp Code:" + nCode);
            }
        }

        /// <summary>
        /// �ܵ�Ŀ������
        /// </summary>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <returns></returns>
        public bool RunToTargetXY(int nTargetX, int nTargetY)
        {
            bool result = false;
            byte nDir;
            int n10;
            int n14;
            if (this.m_boTransparent && (this.m_boHideMode))
            {
                this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;//����,һ��������
            }
            if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && (!GameConfig.ClientConf.boParalyCanSpell)) // ��Բ����ܶ�
            {
                return result;
            }
            if (!m_boCanRun) // ��ֹ��,���˳�
            {
                return result;
            }
            if (HUtil32.GetTickCount() - m_dwRunIntervalTime > GameConfig.dwRunIntervalTime)
            {
                n10 = nTargetX;
                n14 = nTargetY;
                nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, n10, n14);
                if (!this.RunTo(nDir, false, nTargetX, nTargetY))
                {
                    result = WalkToTargetXY(nTargetX, nTargetY);
                    if (result)
                    {
                        this.dwTick3F4 = HUtil32.GetTickCount();
                    }
                }
                else
                {
                    if ((Math.Abs(nTargetX - this.m_nCurrX) <= 1) && (Math.Abs(nTargetY - this.m_nCurrY) <= 1))
                    {
                        result = true;
                        m_dwRunIntervalTime = HUtil32.GetTickCount();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ����Ŀ��
        /// </summary>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <returns></returns>
        public bool WalkToTargetXY(int nTargetX, int nTargetY)
        {
            bool result;
            int I;
            byte nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            result = false;
            if (this.m_boTransparent && (this.m_boHideMode))
            {
                this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;
            }
            //����,һ��������
            if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && (!GameConfig.ClientConf.boParalyCanSpell))
            {
                return result;
            }
            // ��Բ����ܶ�
            if ((Math.Abs(nTargetX - this.m_nCurrX) > 1) || (Math.Abs(nTargetY - this.m_nCurrY) > 1))
            {
                if (HUtil32.GetTickCount() - this.dwTick3F4 > m_dwWalkIntervalTime)
                {
                    // �����߼��
                    n10 = nTargetX;
                    n14 = nTargetY;
                    nDir = Grobal2.DR_DOWN;
                    if (n10 > this.m_nCurrX)
                    {
                        nDir = Grobal2.DR_RIGHT;
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNRIGHT;
                        }
                        if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPRIGHT;
                        }
                    }
                    else
                    {
                        if (n10 < this.m_nCurrX)
                        {
                            nDir = Grobal2.DR_LEFT;
                            if (n14 > this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_DOWNLEFT;
                            }
                            if (n14 < this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_UPLEFT;
                            }
                        }
                        else
                        {
                            if (n14 > this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_DOWN;
                            }
                            else if (n14 < this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_UP;
                            }
                        }
                    }
                    nOldX = this.m_nCurrX;
                    nOldY = this.m_nCurrY;
                    this.WalkTo(nDir, false);
                    if ((Math.Abs(nTargetX - this.m_nCurrX) <= 1) && (Math.Abs(nTargetY - this.m_nCurrY) <= 1))
                    {
                        result = true;
                        this.dwTick3F4 = HUtil32.GetTickCount();
                    }
                    if (!result)
                    {
                        n20 = HUtil32.Random(3);
                        for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                        {
                            if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                            {
                                if (n20 != 0)
                                {
                                    nDir++;
                                }
                                else if (nDir > 0)
                                {
                                    nDir -= 1;
                                }
                                else
                                {
                                    nDir = Grobal2.DR_UPLEFT;
                                }
                                if ((nDir > Grobal2.DR_UPLEFT))
                                {
                                    nDir = Grobal2.DR_UP;
                                }
                                this.WalkTo(nDir, false);
                                if ((Math.Abs(nTargetX - this.m_nCurrX) <= 1) && (Math.Abs(nTargetY - this.m_nCurrY) <= 1))
                                {
                                    result = true;
                                    this.dwTick3F4 = HUtil32.GetTickCount();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ת��
        /// </summary>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <returns></returns>
        public bool WalkToTargetXY2(int nTargetX, int nTargetY)
        {
            bool result;
            int I;
            byte nDir;
            int n10;
            int n14;
            int n20;
            int nOldX;
            int nOldY;
            result = false;
            if (this.m_boTransparent && (this.m_boHideMode))
            {
                this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;
            }
            //����,һ��������
            if ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && (!GameConfig.ClientConf.boParalyCanSpell))
            {
                return result;
            }
            // ��Բ����ܶ�
            if ((nTargetX != this.m_nCurrX) || (nTargetY != this.m_nCurrY))
            {
                if (HUtil32.GetTickCount() - this.dwTick3F4 > m_dwTurnIntervalTime)
                {
                    // ����ת����
                    n10 = nTargetX;
                    n14 = nTargetY;
                    nDir = Grobal2.DR_DOWN;
                    if (n10 > this.m_nCurrX)
                    {
                        nDir = Grobal2.DR_RIGHT;
                        if (n14 > this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_DOWNRIGHT;
                        }
                        if (n14 < this.m_nCurrY)
                        {
                            nDir = Grobal2.DR_UPRIGHT;
                        }
                    }
                    else
                    {
                        if (n10 < this.m_nCurrX)
                        {
                            nDir = Grobal2.DR_LEFT;
                            if (n14 > this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_DOWNLEFT;
                            }
                            if (n14 < this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_UPLEFT;
                            }
                        }
                        else
                        {
                            if (n14 > this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_DOWN;
                            }
                            else if (n14 < this.m_nCurrY)
                            {
                                nDir = Grobal2.DR_UP;
                            }
                        }
                    }
                    nOldX = this.m_nCurrX;
                    nOldY = this.m_nCurrY;
                    this.WalkTo(nDir, false);
                    if ((nTargetX == this.m_nCurrX) && (nTargetY == this.m_nCurrY))
                    {
                        result = true;
                        this.dwTick3F4 = HUtil32.GetTickCount();
                    }
                    if (!result)
                    {
                        n20 = HUtil32.Random(3);
                        for (I = Grobal2.DR_UP; I <= Grobal2.DR_UPLEFT; I++)
                        {
                            if ((nOldX == this.m_nCurrX) && (nOldY == this.m_nCurrY))
                            {
                                if (n20 != 0)
                                {
                                    nDir++;
                                }
                                else if (nDir > 0)
                                {
                                    nDir -= 1;
                                }
                                else
                                {
                                    nDir = Grobal2.DR_UPLEFT;
                                }
                                if ((nDir > Grobal2.DR_UPLEFT))
                                {
                                    nDir = Grobal2.DR_UP;
                                }
                                this.WalkTo(nDir, false);
                                if ((nTargetX == this.m_nCurrX) && (nTargetY == this.m_nCurrY))
                                {
                                    result = true;
                                    this.dwTick3F4 = HUtil32.GetTickCount();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool GotoTargetXY(int nTargetX, int nTargetY, int nCode)
        {
            bool result = false;
            switch (nCode)
            {
                case 0:// ����ģʽ
                    if ((Math.Abs(this.m_nCurrX - nTargetX) > 2) || (Math.Abs(this.m_nCurrY - nTargetY) > 2))
                    {
                        if (this.m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] == 0)  // ����,������������
                        {
                            result = RunToTargetXY(nTargetX, nTargetY);
                        }
                        else
                        {
                            result = WalkToTargetXY2(nTargetX, nTargetY);// ת��
                        }
                    }
                    else
                    {
                        result = WalkToTargetXY2(nTargetX, nTargetY);// ת��
                    }
                    break;
                case 1:// ���ģʽ
                    if ((Math.Abs(this.m_nCurrX - nTargetX) > 1) || (Math.Abs(this.m_nCurrY - nTargetY) > 1))
                    {
                        if (this.m_wStatusTimeArr[Grobal2.STATE_LOCKRUN] == 0)  // ����,������������
                        {
                            result = RunToTargetXY(nTargetX, nTargetY);
                        }
                        else
                        {
                            result = WalkToTargetXY2(nTargetX, nTargetY);// ת��
                        }
                    }
                    else
                    {
                        result = WalkToTargetXY2(nTargetX, nTargetY);// ת��
                    }
                    break;
            }
            return result;
        }

        public unsafe override bool Operate(TProcessMessage ProcessMsg)
        {
            bool result = false;
            try
            {
                switch (ProcessMsg.wIdent)
                {
                    case Grobal2.RM_STRUCK:// ��������
                        if ((HUtil32.IntToObject<THeroObject>(ProcessMsg.BaseObject) == this) && (HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3) != null))
                        {
                            if (HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3).m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                if ((!HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3).InSafeZone()) && (!this.InSafeZone()))
                                {
                                    this.SetLastHiter(HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3));// ����������Լ�����
                                    Struck(HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3));
                                    this.BreakHolySeizeMode();
                                }
                            }
                            else
                            {
                                this.SetLastHiter(HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3));// ����������Լ�����
                                Struck(HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3));
                                this.BreakHolySeizeMode();
                            }
                            if ((this.m_Master != null) && (HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3) != this.m_Master)
                                && ((HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3).m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                || (HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3).m_btRaceServer == Grobal2.RC_HEROOBJECT)))
                            {
                                // Ӣ�ۻ�ɫ
                                this.m_Master.SetPKFlag(HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3));
                            }
                            if (GameConfig.boMonSayMsg)
                            {
                                this.MonsterSayMsg(HUtil32.IntToObject<TBaseObject>(ProcessMsg.nParam3), TMonStatus.s_UnderFire);
                            }
                        }
                        result = true;
                        break;
                    default:
                        result = base.Operate(ProcessMsg);
                        break;
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.Operate");
            }
            return result;
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="hiter"></param>
        public unsafe virtual void Struck(TBaseObject hiter)
        {
            if (!m_boTarget)
            {
                this.m_dwStruckTick = HUtil32.GetTickCount();
                if (hiter != null)
                {
                    if ((this.m_TargetCret == null) && !m_boTarget)
                    {
                        if (this.IsProperTarget(hiter))
                        {
                            this.SetTargetCreat(hiter);// ����ΪĿ��
                        }
                    }
                }
                if (this.m_boAnimal)
                {
                    this.m_nMeatQuality = this.m_nMeatQuality - HUtil32.Random(300);
                    if (this.m_nMeatQuality < 0)
                    {
                        this.m_nMeatQuality = 0;
                    }
                }
            }
            this.m_dwHitTick = Convert.ToUInt32(this.m_dwHitTick + ((uint)150 - HUtil32._MIN(130, this.m_Abil.Level * 4)));
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="TargeTBaseObject"></param>
        /// <param name="nDir"></param>
        public virtual void Attack(TBaseObject TargeTBaseObject, int nDir)
        {
            if (this.m_boUseBatter && (m_wBatterHitMode >= 14 && m_wBatterHitMode <= 17))
            {
                base.AttackDir(TargeTBaseObject, m_wBatterHitMode, nDir);
            }
            else
            {
                base.AttackDir(TargeTBaseObject, m_wHitMode, nDir);
            }
        }

        /// <summary>
        /// ɾ��Ŀ��
        /// </summary>
        public override void DelTargetCreat()
        {
            base.DelTargetCreat();
            m_nTargetX = -1;
            m_nTargetY = -1;
        }

        /// <summary>
        /// ����Ŀ��
        /// </summary>
        public void SearchTarget()
        {
            TBaseObject BaseObject;
            TBaseObject BaseObject18;
            int nC;
            int n10;
            if ((this.m_TargetCret == null) && m_boTarget)
            {
                m_boTarget = false;
            }
            if ((this.m_TargetCret != null) && m_boTarget)
            {
                if (this.m_TargetCret.m_boDeath)
                {
                    m_boTarget = false;
                }
            }
            if ((m_btStatus == 0) && !m_boTarget)// �ػ�״̬һ������Ŀ�� 
            {
                BaseObject18 = null;
                n10 = 15;
                for (int I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = (TBaseObject)this.m_VisibleActors[I].BaseObject;
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(this.m_nCurrX - BaseObject.m_nCurrX) + Math.Abs(this.m_nCurrY - BaseObject.m_nCurrY);
                                if (nC < n10)
                                {
                                    n10 = nC;
                                    BaseObject18 = BaseObject;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (BaseObject18 != null)
                {
                    this.SetTargetCreat(BaseObject18);
                }
            }
        }

        public virtual void SetTargetXY(int nX, int nY)
        {
            m_nTargetX = nX;
            m_nTargetY = nY;
        }

        public virtual void Wondering()
        {
            if ((HUtil32.Random(10) == 0))
            {
                if ((HUtil32.Random(4) == 1))
                {
                    this.TurnTo(HUtil32.Random(8));
                }
                else
                {
                    this.WalkTo(this.m_btDirection, false);
                }
            }
        }

        /// <summary>
        /// �ǲ��ǿ���ʹ�õ�ħ��
        /// UserMagic->btKey 0-���ܿ�,1--���ܹ�
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        public unsafe bool IsAllowUseMagic(ushort wMagIdx)
        {
            bool result = false;
            TUserMagic* UserMagic = CheckUserMagic(wMagIdx);
            if (UserMagic != null)
            {
                if ((GetSpellPoint(UserMagic) < this.m_WAbil.MP) && (UserMagic->btKey == 0))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// ����ħ��
        /// </summary>
        /// <returns></returns>
        private unsafe int SelectMagic()
        {
            int result;
            result = 0;
            switch (this.m_btJob)
            {
                case 0:// սʿ
                    // �ܹ���ʱ�ſ���
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (this.m_ExpHitter != null) && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 3000))
                    {
                        // ʹ�� �������
                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        result = 75;
                        return result;
                    }
                    if (IsAllowUseMagic(68) && (this.m_WAbil.MP > 30) && (HUtil32.GetTickCount() - m_SkillUseTick[68] > 3000))
                    {
                        // ��������
                        if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))
                            {
                                m_SkillUseTick[68] = HUtil32.GetTickCount();
                                result = 68;
                                return result;
                            }
                        }
                    }
                    // Զ�������ÿ����ػ��������ս���
                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) >= 2) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) < 5)) || ((Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) >= 2) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) < 5)))
                    {
                        if (IsAllowUseMagic(43) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > GameConfig.nKill43UseTime * 1000))
                        {
                            this.m_bo42kill = true;
                            this.m_n42kill = 2;// �ػ�
                            result = 43;
                            return result;
                        }
                        if (IsAllowUseMagic(74) && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 12000))
                        {
                            // ���ս���
                            this.m_boDailySkill = true;
                            result = 74;
                            return result;
                        }
                    }
                    if (IsAllowUseMagic(43) && ((HUtil32.GetTickCount() - this.m_dwLatest42Tick) > GameConfig.nKill43UseTime * 1000)) // ����ն 
                    {
                        this.m_bo42kill = true;
                        result = 43;
                        if ((HUtil32.Random(GameConfig.n43KillHitRate) == 0) && (GameConfig.btHeroSkillMode43 || (this.m_TargetCret.m_Abil.Level <= this.m_Abil.Level))) // Ŀ��ȼ��������Լ�,��ʹ���ػ�
                        {
                            this.m_n42kill = 2;// �ػ�
                        }
                        else
                        {
                            this.m_n42kill = 1;// ���
                        }
                        return result;
                    }
                    // ��ɱλ
                    if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) == 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) == 2))
                    {
                        if (IsAllowUseMagic(12))// Ӣ�۴�ɱ����
                        {
                            if (!this.m_boUseThrusting)
                            {
                                this.ThrustingOnOff(true);
                            }
                            result = 12;
                            return result;
                        }
                    }
                    // 12 * 1000
                    if (IsAllowUseMagic(74) && ((HUtil32.GetTickCount() - this.m_dwLatestDailyTick) > 12000))// ���ս���
                    {
                        this.m_boDailySkill = true;
                        result = 74;
                        return result;
                    }
                    // 9 * 1000
                    if (IsAllowUseMagic(26) && ((HUtil32.GetTickCount() - this.m_dwLatestFireHitTick) > 9000))//�һ�
                    {
                        this.m_boFireHitSkill = true;
                        result = 26;
                        return result;
                    }
                    if (IsAllowUseMagic(42) && (HUtil32.GetTickCount() - this.m_dwLatest43Tick > GameConfig.nKill42UseTime * 1000)) // ��Ӱ����
                    {
                        this.m_bo43kill = true;
                        result = 42;
                        return result;
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                    {
                        // PKʱ,ʹ��Ұ����ײ   Ѫ����800ʱʹ��
                        // 10 * 1000
                        if (IsAllowUseMagic(27) && ((HUtil32.GetTickCount() - m_SkillUseTick[27]) > 10000))
                        {
                            // pkʱ����Է��ȼ����Լ��;�ÿ��һ��ʱ����һ��Ұ�� 
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    else
                    {
                        // ���ʹ��
                        // 10 * 1000
                        if (IsAllowUseMagic(27) && ((HUtil32.GetTickCount() - m_SkillUseTick[27]) > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level)
                            && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.85)))
                        {
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    if ((this.m_TargetCret.m_Master != null))
                    {
                        this.m_ExpHitter = this.m_TargetCret.m_Master;
                    }
                    // 20080924
                    if (CheckTargetXYCount1(this.m_nCurrX, this.m_nCurrY, 1) > 1)
                    {
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // �������Χ
                                //  PKʱ����ʨ�Ӻ�
                                // 10 * 1000
                                if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level)
                                    && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)
                                    && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                                {
                                    m_SkillUseTick[41] = HUtil32.GetTickCount();// ʨ�Ӻ�
                                    result = 41;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))
                                {
                                    // ��ɱ����
                                    m_SkillUseTick[7] = HUtil32.GetTickCount();
                                    this.m_boPowerHit = true;// ������ɱ
                                    result = 7;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 10000))
                                {
                                    m_SkillUseTick[39] = HUtil32.GetTickCount();// Ӣ�۳��ض�
                                    result = 39;
                                    return result;
                                }
                                if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0))
                                {
                                    // Ӣ�۰����䵶
                                    if (!this.m_boUseHalfMoon)
                                    {
                                        this.HalfMoonOnOff(true);
                                    }
                                    result = 25;
                                    return result;
                                }
                                if (IsAllowUseMagic(40))
                                {
                                    // Ӣ�۱��µ���
                                    if (!this.m_boCrsHitkill)
                                    {
                                        this.SkillCrsOnOff(true);
                                    }
                                    result = 40;
                                    return result;
                                }
                                if (IsAllowUseMagic(12))
                                {
                                    // Ӣ�۴�ɱ����
                                    if (!this.m_boUseThrusting)
                                    {
                                        this.ThrustingOnOff(true);
                                    }
                                    result = 12;
                                    return result;
                                }
                                break;
                            case 1:// 10 * 1000
                                if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                                {
                                    m_SkillUseTick[41] = HUtil32.GetTickCount();// ʨ�Ӻ�
                                    result = 41;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))
                                {
                                    // ��ɱ���� 20071213
                                    m_SkillUseTick[7] = HUtil32.GetTickCount();
                                    this.m_boPowerHit = true;// ������ɱ
                                    result = 7;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 10000))
                                {
                                    m_SkillUseTick[39] = HUtil32.GetTickCount();// Ӣ�۳��ض�
                                    result = 39;
                                    return result;
                                }
                                if (IsAllowUseMagic(40))
                                {
                                    // Ӣ�۱��µ���
                                    if (!this.m_boCrsHitkill)
                                    {
                                        this.SkillCrsOnOff(true);
                                    }
                                    result = 40;
                                    return result;
                                }
                                if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0))
                                {
                                    // Ӣ�۰����䵶
                                    if (!this.m_boUseHalfMoon)
                                    {
                                        this.HalfMoonOnOff(true);
                                    }
                                    result = 25;
                                    return result;
                                }
                                if (IsAllowUseMagic(12))
                                {
                                    // Ӣ�۴�ɱ����
                                    if (!this.m_boUseThrusting)
                                    {
                                        this.ThrustingOnOff(true);
                                    }
                                    result = 12;
                                    return result;
                                }
                                break;
                            case 2:// 10 * 1000
                                if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3) && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                                {
                                    m_SkillUseTick[41] = HUtil32.GetTickCount();
                                    // ʨ�Ӻ�
                                    result = 41;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 10000))
                                {
                                    m_SkillUseTick[39] = HUtil32.GetTickCount();
                                    // Ӣ�۳��ض�
                                    result = 39;
                                    return result;
                                }
                                // 10 * 1000
                                if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))
                                {
                                    // ��ɱ����
                                    m_SkillUseTick[7] = HUtil32.GetTickCount();
                                    this.m_boPowerHit = true;// ������ɱ
                                    result = 7;
                                    return result;
                                }
                                if (IsAllowUseMagic(40))
                                {
                                    // Ӣ�۱��µ���
                                    if (!this.m_boCrsHitkill)
                                    {
                                        this.SkillCrsOnOff(true);
                                    }
                                    result = 40;
                                    return result;
                                }
                                if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0))
                                {
                                    // Ӣ�۰����䵶
                                    if (!this.m_boUseHalfMoon)
                                    {
                                        this.HalfMoonOnOff(true);
                                    }
                                    result = 25;
                                    return result;
                                }
                                if (IsAllowUseMagic(12))
                                {
                                    // Ӣ�۴�ɱ����
                                    if (!this.m_boUseThrusting)
                                    {
                                        this.ThrustingOnOff(true);
                                    }
                                    result = 12;
                                    return result;
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (CheckTargetXYCount1(this.m_nCurrX, this.m_nCurrY, 1) > 1))
                        {
                            // ��߳���2��Ŀ���ʹ��
                            if (IsAllowUseMagic(40) && (HUtil32.GetTickCount() - m_SkillUseTick[40] > 3000))
                            {
                                // Ӣ�۱��µ���
                                m_SkillUseTick[40] = HUtil32.GetTickCount();
                                if (!this.m_boCrsHitkill)
                                {
                                    this.SkillCrsOnOff(true);
                                }
                                result = 40;
                                return result;
                            }
                            if (IsAllowUseMagic(25) && (CheckTargetXYCount2() > 0) && (HUtil32.GetTickCount() - m_SkillUseTick[25] > 1500))
                            {
                                // Ӣ�۰����䵶

                                m_SkillUseTick[25] = HUtil32.GetTickCount();
                                if (!this.m_boUseHalfMoon)
                                {
                                    this.HalfMoonOnOff(true);
                                }
                                result = 25;
                                return result;
                            }
                        }
                        // ���� ������������ ��ɱ����
                        // 10 * 1000
                        if (IsAllowUseMagic(7) && ((HUtil32.GetTickCount() - m_SkillUseTick[7]) > 10000))  // ��ɱ����
                        {
                            m_SkillUseTick[7] = HUtil32.GetTickCount();
                            this.m_boPowerHit = true;//������ɱ
                            result = 7;
                            return result;
                        }
                        if (IsAllowUseMagic(12) && (HUtil32.GetTickCount() - m_SkillUseTick[12] > 1000))
                        {
                            // Ӣ�۴�ɱ����
                            if (!this.m_boUseThrusting)
                            {
                                this.ThrustingOnOff(true);
                            }
                            m_SkillUseTick[12] = HUtil32.GetTickCount();
                            result = 12;
                            return result;
                        }
                    }
                    // �Ӹߵ���ʹ��ħ��
                    if (IsAllowUseMagic(43) && (HUtil32.GetTickCount() - this.m_dwLatest42Tick > GameConfig.nKill43UseTime * 1000))
                    {
                        // ����ն
                        this.m_bo42kill = true;
                        result = 43;
                        if ((HUtil32.Random(GameConfig.n43KillHitRate) == 0) && (GameConfig.btHeroSkillMode43 || (this.m_TargetCret.m_Abil.Level <= this.m_Abil.Level)))
                        {
                            this.m_n42kill = 2;// �ػ�
                        }
                        else
                        {
                            this.m_n42kill = 1;// ���
                        }
                        return result;
                    }
                    else if (IsAllowUseMagic(42) && (HUtil32.GetTickCount() - this.m_dwLatest43Tick > GameConfig.nKill42UseTime * 1000))
                    {
                        // ��Ӱ����
                        this.m_bo43kill = true;
                        result = 42;
                        return result;
                    }
                    else if (IsAllowUseMagic(74) && (HUtil32.GetTickCount() - this.m_dwLatestDailyTick > 12000))
                    {
                        // ���ս���
                        this.m_boDailySkill = true;
                        result = 74;
                        return result;
                    }
                    else if (IsAllowUseMagic(26) && (HUtil32.GetTickCount() - this.m_dwLatestFireHitTick > 9000))
                    {
                        // �һ�
                        this.m_boFireHitSkill = true;
                        result = 26;
                        return result;
                    }
                    if (IsAllowUseMagic(40) && (HUtil32.GetTickCount() - m_SkillUseTick[40] > 3000) && (CheckTargetXYCount1(this.m_nCurrX, this.m_nCurrY, 1) > 1))
                    {
                        // Ӣ�۱��µ���
                        if (!this.m_boCrsHitkill)
                        {
                            this.SkillCrsOnOff(true);
                        }
                        m_SkillUseTick[40] = HUtil32.GetTickCount();
                        result = 40;
                        return result;
                    }
                    if (IsAllowUseMagic(39) && (HUtil32.GetTickCount() - m_SkillUseTick[39] > 3000))
                    {
                        // Ӣ�۳��ض�

                        m_SkillUseTick[39] = HUtil32.GetTickCount();
                        result = 39;
                        return result;
                    }
                    if (IsAllowUseMagic(25) && (HUtil32.GetTickCount() - m_SkillUseTick[25] > 3000) && (CheckTargetXYCount2() > 0))
                    {
                        // Ӣ�۰����䵶
                        if (!this.m_boUseHalfMoon)
                        {
                            this.HalfMoonOnOff(true);
                        }
                        m_SkillUseTick[25] = HUtil32.GetTickCount();
                        result = 25;
                        return result;
                    }

                    if (IsAllowUseMagic(12) && (HUtil32.GetTickCount() - m_SkillUseTick[12] > 3000))
                    {
                        // Ӣ�۴�ɱ����
                        if (!this.m_boUseThrusting)
                        {
                            this.ThrustingOnOff(true);
                        }
                        m_SkillUseTick[12] = HUtil32.GetTickCount();
                        result = 12;
                        return result;
                    }
                    if (IsAllowUseMagic(7) && (HUtil32.GetTickCount() - m_SkillUseTick[7] > 3000))
                    {
                        // ��ɱ����
                        this.m_boPowerHit = true;
                        m_SkillUseTick[7] = HUtil32.GetTickCount();
                        result = 7;
                        return result;
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.6)))
                    {
                        // PKʱ,ʹ��Ұ����ײ

                        if (IsAllowUseMagic(27) && (HUtil32.GetTickCount() - m_SkillUseTick[27] > 3000))
                        {
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    else
                    {
                        // ���ʹ��
                        if (IsAllowUseMagic(27) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level) && (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.6))
                            && (HUtil32.GetTickCount() - m_SkillUseTick[27] > 3000))
                        {
                            m_SkillUseTick[27] = HUtil32.GetTickCount();
                            result = 27;
                            return result;
                        }
                    }
                    if (IsAllowUseMagic(41) && (HUtil32.GetTickCount() - m_SkillUseTick[41] > 10000) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level)
                        && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 3)
                        && (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 3))
                    {
                        // ʨ�Ӻ�
                        m_SkillUseTick[41] = HUtil32.GetTickCount();
                        result = 41;
                        return result;
                    }
                    break;
                case 1:
                    // ��ʦ
                    // ʹ�� �������
                    // �ܹ���ʱ�ſ���
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (this.m_ExpHitter != null)
                        && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 3000))
                    {
                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        result = 75;
                        return result;
                    }
                    // ʹ�� ħ����
                    if ((this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence))
                    {
                        if (IsAllowUseMagic(66))// 4��ħ����
                        {
                            result = 66;
                            return result;
                        }
                        if (IsAllowUseMagic(31))
                        {
                            result = 31;
                            return result;
                        }
                    }
                    // ��������
                    if (IsAllowUseMagic(68) && (this.m_WAbil.MP > 30) && (HUtil32.GetTickCount() - m_SkillUseTick[68] > 3000))
                    {
                        if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))
                            {
                                m_SkillUseTick[68] = HUtil32.GetTickCount();
                                result = 68;
                                return result;
                            }
                        }
                    }
                    // ��������,��ʹ�÷�����
                    // �ٻ�������
                    if ((this.m_SlaveList.Count == 0) && IsAllowUseMagic(46) && ((HUtil32.GetTickCount() - this.m_dwLatest46Tick) > GameConfig.nCopyHumanTick * 1000)
                        && ((GameConfig.btHeroSkillMode46) || (this.m_LastHiter != null) || (this.m_ExpHitter != null)))
                    {
                        if (m_Magic46Skill != null)
                        {
                            switch (m_Magic46Skill->btLevel)
                            {
                                case 0:
                                    // �����ܵȼ����ȼ�����������ж��Ƿ��ʹ�÷�����
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_0 / 100))))
                                    {
                                        //�ܵ�������,HP����80%��ʹ�÷���
                                        result = 46;
                                        return result;
                                    }
                                    break;
                                case 1:
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_1 / 100))))
                                    {
                                        // 1�� Ӣ���ٻ�����HP�ı��� 20081217
                                        result = 46;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_2 / 100))))
                                    {
                                        // 1�� Ӣ���ٻ�����HP�ı��� 20081217
                                        result = 46;
                                        return result;
                                    }
                                    break;
                                case 3:
                                    if ((this.m_WAbil.HP <= HUtil32.Round((double)this.m_WAbil.MaxHP * (GameConfig.nHeroSkill46MaxHP_3 / 100))))
                                    {
                                        // 1�� Ӣ���ٻ�����HP�ı��� 20081217
                                        result = 46;
                                        return result;
                                    }
                                    break;
                            }
                            // case
                        }
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null))
                        && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                    {
                        // PKʱ,�Ա���������,ʹ�ÿ��ܻ�

                        // 3 * 1000
                        if (IsAllowUseMagic(8) && ((HUtil32.GetTickCount() - m_SkillUseTick[8]) > 3000))
                        {

                            m_SkillUseTick[8] = HUtil32.GetTickCount();
                            result = 8;
                            return result;
                        }
                    }
                    else
                    {
                        // ���,�ּ������Լ�,�����йְ�Χ�Լ����� ���ܻ�

                        // 3 * 1000
                        if (IsAllowUseMagic(8) && ((HUtil32.GetTickCount() - m_SkillUseTick[8]) > 3000) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0)
                            && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                        {

                            m_SkillUseTick[8] = HUtil32.GetTickCount();
                            result = 8;
                            return result;
                        }
                    }
                    if ((m_nLoyal >= 500) && ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)))
                    {

                        if (IsAllowUseMagic(45) && (HUtil32.GetTickCount() - m_SkillUseTick[45] > 1300))
                        {
                            // �ҳ϶�5%ʱ��PKʱʹ������������ 20080828

                            m_SkillUseTick[45] = HUtil32.GetTickCount();
                            result = 45;
                            // Ӣ�������
                            return result;
                        }
                    }
                    else
                    {

                        // 1000 * 3
                        if (IsAllowUseMagic(45) && (HUtil32.GetTickCount() - m_SkillUseTick[45] > 3000))
                        {

                            m_SkillUseTick[45] = HUtil32.GetTickCount();
                            result = 45;
                            // Ӣ�������
                            return result;
                        }
                    }

                    // 1000 * 5
                    if ((HUtil32.GetTickCount() - m_SkillUseTick[10] > 5000) && this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY))
                    {
                        if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null))
                            && (this.GetDirBaseObjectsCount(this.m_btDirection, 5) > 0) && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                        {
                            if (IsAllowUseMagic(10))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 10;// Ӣ�ۼ����Ӱ 
                                return result;
                            }
                            else if (IsAllowUseMagic(9))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 9;// ������
                                return result;
                            }
                        }
                        else if ((this.GetDirBaseObjectsCount(this.m_btDirection, 5) > 1) && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4)
                            && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                        {
                            if (IsAllowUseMagic(10))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 10;// Ӣ�ۼ����Ӱ
                                return result;
                            }
                            else if (IsAllowUseMagic(9))
                            {
                                m_SkillUseTick[10] = HUtil32.GetTickCount();
                                result = 9;// ������
                                return result;
                            }
                        }
                    }
                    // 1000 * 10
                    if (IsAllowUseMagic(32) && (HUtil32.GetTickCount() - m_SkillUseTick[32] > 10000) && (this.m_TargetCret.m_Abil.Level < GameConfig.nMagTurnUndeadLevel)
                        && (this.m_TargetCret.m_btLifeAttrib == Grobal2.LA_UNDEAD) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level - 1))
                    {
                        // Ŀ��Ϊ����ϵ
                        m_SkillUseTick[32] = HUtil32.GetTickCount();
                        result = 32;// ʥ����
                        return result;
                    }
                    if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 2) > 1)
                    {
                        // �������Χ
                        // 10 * 1000
                        if (IsAllowUseMagic(22) && (HUtil32.GetTickCount() - m_SkillUseTick[22] > 10000) && (M2Share.g_EventManager.GetRangeEvent(this.m_PEnvir, this, this.m_nCurrX, this.m_nCurrY, 6, Grobal2.ET_FIRE) != 0))
                        {
                            if ((this.m_TargetCret.m_btRaceServer != 101) && (this.m_TargetCret.m_btRaceServer != 102) && (this.m_TargetCret.m_btRaceServer != 104))
                            {
                                // �������,�ŷŻ�ǽ 20081217

                                m_SkillUseTick[22] = HUtil32.GetTickCount();
                                result = 22;
                                // ��ǽ
                                return result;
                            }
                        }
                        // �����׹�,ֻ������(101,102,104)������(91,92,97)��Ұ��(81)ϵ�е���   20080217
                        // ��������Ĺ�Ӧ�ö��õ����׹⣬�����׵��������ñ����� 20080228
                        if (new ArrayList(new int[] { 91, 92, 97, 101, 102, 104 }).Contains(this.m_TargetCret.m_btRaceServer))
                        {
                            // 1000 * 4
                            if (IsAllowUseMagic(24) && (HUtil32.GetTickCount() - m_SkillUseTick[24] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                            {
                                m_SkillUseTick[24] = HUtil32.GetTickCount();
                                result = 24;
                                // �����׹�
                                return result;
                            }
                            else if (IsAllowUseMagic(11))
                            {
                                result = 11;
                                // Ӣ���׵���
                                return result;
                            }
                            else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 2) > 2))
                            {
                                result = 33;
                                // Ӣ�۱�����
                                return result;
                            }
                            // 1000 * 4
                            else if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                            {
                                m_SkillUseTick[58] = HUtil32.GetTickCount();
                                result = 58;// ���ǻ���
                                return result;
                            }
                        }
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // ���ѡ��ħ��
                                // ������,�����,�׵���,���ѻ���,Ӣ�۱�����,���ǻ��� �Ӹߵ���ѡ��
                                // 1000 * 4
                                if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                                {
                                    m_SkillUseTick[58] = HUtil32.GetTickCount();
                                    result = 58;
                                    // ���ǻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 33;
                                    // Ӣ�۱�����
                                    return result;
                                }
                                else if (IsAllowUseMagic(23) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 23;
                                    // ���ѻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(11))
                                {
                                    result = 11;
                                    // Ӣ���׵���
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;
                                    // �����
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;
                                    // ������
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    // Ӣ��Ⱥ���׵�
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    // ������
                                    return result;
                                }
                                break;
                            case 1:
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                // 1000 * 4
                                if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                                {
                                    m_SkillUseTick[58] = HUtil32.GetTickCount();
                                    result = 58;
                                    // ���ǻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    // ������,�����,������,���ѻ���,������  �Ӹߵ���ѡ��
                                    result = 33;
                                    // ������
                                    return result;
                                }
                                else if (IsAllowUseMagic(23) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 23;
                                    // ���ѻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(11))
                                {
                                    result = 11;
                                    // Ӣ���׵���
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;
                                    // �����
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;
                                    // ������
                                    return result;
                                }
                                break;
                            case 2:
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                // 1000 * 4
                                if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                                {
                                    m_SkillUseTick[58] = HUtil32.GetTickCount();
                                    result = 58;// ���ǻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(33) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    // ������,�����,������,���ѻ��� �Ӹߵ���ѡ��
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 1))
                                {
                                    result = 23;// ���ѻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(11))
                                {
                                    result = 11;// Ӣ���׵���
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;// �����
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;// ������
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                break;
                        }
                    }
                    else
                    {
                        // ֻ��һ����ʱ���õ�ħ��
                        // 10 * 1000
                        if (IsAllowUseMagic(22) && (HUtil32.GetTickCount() - m_SkillUseTick[22] > 10000) && (M2Share.g_EventManager.GetRangeEvent(this.m_PEnvir, this, this.m_nCurrX, this.m_nCurrY, 6, Grobal2.ET_FIRE) == 0))
                        {
                            if ((this.m_TargetCret.m_btRaceServer != 101) && (this.m_TargetCret.m_btRaceServer != 102) && (this.m_TargetCret.m_btRaceServer != 104))
                            {
                                // �������,�ŷŻ�ǽ
                                m_SkillUseTick[22] = HUtil32.GetTickCount();
                                result = 22;
                                return result;
                            }
                        }
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // ���ѡ��ħ��
                                if (IsAllowUseMagic(11))
                                {
                                    result = 11;// �׵���
                                    return result;
                                }
                                else if (IsAllowUseMagic(33))
                                {
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23))
                                {
                                    // ������,�����,������,���ѻ��� �Ӹߵ���ѡ��
                                    result = 23;// ���ѻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;// �����
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;// ������
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                break;
                            case 1:
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                if (IsAllowUseMagic(11))
                                {
                                    result = 11;
                                    // �׵���
                                    return result;
                                }
                                else if (IsAllowUseMagic(33))
                                {
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23))
                                {
                                    result = 23;// ���ѻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;// �����
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;// ������
                                    return result;
                                }
                                break;
                            case 2:
                                if (IsAllowUseMagic(47))
                                {
                                    result = 47;
                                    return result;
                                }
                                if (IsAllowUseMagic(11))
                                {
                                    result = 11;// �׵���
                                    return result;
                                }
                                else if (IsAllowUseMagic(33))
                                {
                                    result = 33;
                                    return result;
                                }
                                else if (IsAllowUseMagic(23))
                                {
                                    result = 23;// ���ѻ���
                                    return result;
                                }
                                else if (IsAllowUseMagic(5) && (m_nLoyal < 500))
                                {
                                    result = 5;
                                    // �����
                                    return result;
                                }
                                else if (IsAllowUseMagic(1) && (m_nLoyal < 500))
                                {
                                    result = 1;
                                    // ������
                                    return result;
                                }
                                if (IsAllowUseMagic(37))
                                {
                                    result = 37;
                                    return result;
                                }
                                break;
                            // end;
                        }
                    }
                    // �Ӹߵ���ʹ��ħ�� 20080710

                    // 1000 * 4
                    if (IsAllowUseMagic(58) && (HUtil32.GetTickCount() - m_SkillUseTick[58] > 4000))
                    {
                        // ���ǻ���

                        m_SkillUseTick[58] = HUtil32.GetTickCount();
                        result = 58;
                        return result;
                    }
                    if (IsAllowUseMagic(47))
                    {
                        // ������
                        result = 47;
                        return result;
                    }
                    if (IsAllowUseMagic(45))
                    {
                        // Ӣ�������
                        result = 45;
                        return result;
                    }
                    if (IsAllowUseMagic(37))
                    {
                        // Ӣ��Ⱥ���׵�
                        result = 37;
                        return result;
                    }
                    if (IsAllowUseMagic(33))
                    {
                        // Ӣ�۱�����
                        result = 33;
                        return result;
                    }
                    if (IsAllowUseMagic(32) && (this.m_TargetCret.m_Abil.Level < GameConfig.nMagTurnUndeadLevel) && (this.m_TargetCret.m_btLifeAttrib == Grobal2.LA_UNDEAD)
                        && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level - 1))
                    {
                        // Ŀ��Ϊ����ϵ
                        result = 32;
                        // ʥ���� 20080710
                        return result;
                    }
                    if (IsAllowUseMagic(24) && (CheckTargetXYCount(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, 3) > 2))
                    {
                        // �����׹�
                        result = 24;
                        return result;
                    }
                    if (IsAllowUseMagic(23))
                    {
                        // ���ѻ���
                        result = 23;
                        return result;
                    }
                    if (IsAllowUseMagic(11))
                    {
                        // Ӣ���׵���
                        result = 11;
                        return result;
                    }
                    if (IsAllowUseMagic(10) && this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)
                        && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) ||
                        (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                    {
                        result = 10;
                        // Ӣ�ۼ����Ӱ
                        return result;
                    }
                    if (IsAllowUseMagic(9) && this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY)
                        && (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0))
                        || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) ||
                        (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) ||
                        ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4)))))
                    {
                        result = 9;
                        // ������
                        return result;
                    }
                    if (IsAllowUseMagic(5))
                    {
                        result = 5;
                        // �����
                        return result;
                    }
                    if (IsAllowUseMagic(1))
                    {
                        result = 1;
                        // ������
                        return result;
                    }
                    if (IsAllowUseMagic(22) && (M2Share.g_EventManager.GetRangeEvent(this.m_PEnvir, this, this.m_nCurrX, this.m_nCurrY, 6, Grobal2.ET_FIRE) != 0))
                    {
                        if ((this.m_TargetCret.m_btRaceServer != 101) && (this.m_TargetCret.m_btRaceServer != 102) && (this.m_TargetCret.m_btRaceServer != 104))
                        {
                            // �������,�ŷŻ�ǽ 20081217
                            result = 22;
                            // ��ǽ
                            return result;
                        }
                    }
                    break;
                case 2:
                    // ��ʿ
                    // Ӣ��HPֵ���ڻ�����60%ʱ,ʹ�������� 20080204 �޸�
                    if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)))
                    {
                        // ʹ��������
                        // 1000 * 3
                        if (IsAllowUseMagic(2) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000))
                        {
                            // ʹ��������
                            m_SkillUseTick[2] = HUtil32.GetTickCount();
                            result = 2;
                            return result;
                        }
                    }
                    // ����HPֵ���ڻ�����60%ʱ,ʹ��Ⱥ��������
                    if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)))
                    {
                        if (CheckMasterXYOfDirection(this.m_Master, m_nTargetX, m_nTargetY, this.m_btDirection, 3) >= 1)
                        {
                            // �ж�������Ӣ�۵ľ���
                            // 1000 * 3
                            if (IsAllowUseMagic(29) && (HUtil32.GetTickCount() - m_SkillUseTick[29] > 3000))
                            {
                                // ʹ��Ⱥ��������
                                m_SkillUseTick[29] = HUtil32.GetTickCount();
                                result = 29;
                            }
                            // 1000 * 3
                            else if (IsAllowUseMagic(2) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000))
                            {
                                // ʹ��������
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                result = 2;
                            }
                        }
                        else
                        {
                            // 1000 * 3
                            if (IsAllowUseMagic(2) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000))
                            {
                                // ʹ��������
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                result = 2;
                            }
                        }
                        if (result > 0)
                        {
                            return result;
                        }
                    }
                    if ((this.m_SlaveList.Count == 0) && CheckHeroAmulet(1, 5) && (HUtil32.GetTickCount() - m_SkillUseTick[17] > 1000 * 3) && (IsAllowUseMagic(72) || IsAllowUseMagic(30) || IsAllowUseMagic(17)) && (this.m_WAbil.MP > 20))
                    {
                        m_SkillUseTick[17] = HUtil32.GetTickCount();
                        // Ĭ��,�Ӹߵ���
                        if (IsAllowUseMagic(72))
                        {
                            // �ٻ�����
                            result = 72;
                        }
                        else if (IsAllowUseMagic(30))
                        {
                            // �ٻ�����
                            result = 30;
                        }
                        else if (IsAllowUseMagic(17))
                        {
                            result = 17;
                        }
                        // �ٻ�����
                        return result;
                    }
                    // �ܹ���ʱ�ſ���
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence) && (this.m_ExpHitter != null) && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 3000))
                    {
                        // ʹ�� ������� 20080107

                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        // 20080228
                        result = 75;
                        return result;
                    }
                    if ((this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence))
                    {
                        if (IsAllowUseMagic(73))
                        {
                            // ������ 
                            result = 73;
                            return result;
                        }
                    }
                    // �������� 
                    if (IsAllowUseMagic(68) && (this.m_WAbil.MP > 30) && (HUtil32.GetTickCount() - m_SkillUseTick[68] > 3000))
                    {
                        if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                        {
                            if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))
                            {
                                m_SkillUseTick[68] = HUtil32.GetTickCount();
                                result = 68;
                                return result;
                            }
                        }
                    }
                    if (CheckHeroAmulet(1, 1) && (this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] == 0))
                    {
                        // �������Χʱ,����������,PKʱ���� 
                        if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 2) > 1) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                        {
                            if (IsAllowUseMagic(19) && (HUtil32.GetTickCount() - m_SkillUseTick[19] > 8000))
                            {
                                // Ӣ��Ⱥ�������� 20081214
                                m_SkillUseTick[19] = HUtil32.GetTickCount();
                                result = 19;
                                return result;
                            }

                            else if (IsAllowUseMagic(18) && (HUtil32.GetTickCount() - m_SkillUseTick[18] > 8000))
                            {
                                // Ӣ�������� 20081214

                                m_SkillUseTick[18] = HUtil32.GetTickCount();
                                result = 18;
                                return result;
                            }
                        }
                    }
                    if (((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_Master != null)) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level <= this.m_WAbil.Level))
                    {
                        // PKʱ,�Ա���������,ʹ��������
                        // 3 * 1000
                        if (IsAllowUseMagic(48) && ((HUtil32.GetTickCount() - m_SkillUseTick[48]) > 3000))
                        {
                            m_SkillUseTick[48] = HUtil32.GetTickCount();
                            result = 48;
                            return result;
                        }
                    }
                    else
                    {
                        // ���,�ּ������Լ�,�����йְ�Χ�Լ����� ������
                        // 20090108 ��3��ĵ�5��
                        if (IsAllowUseMagic(48) && ((HUtil32.GetTickCount() - m_SkillUseTick[48]) > 5000) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level <= this.m_WAbil.Level))
                        {
                            m_SkillUseTick[48] = HUtil32.GetTickCount();
                            result = 48;
                            return result;
                        }
                    }

                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && (GetUserItemList(2, 1) >= 0) && ((GameConfig.btHeroSkillMode) || (this.m_TargetCret.m_Abil.HP >= 700) || ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYMOSTER)) || m_boTarget) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) < 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) < 7)) && (this.m_TargetCret.m_btRaceServer != 110) && (this.m_TargetCret.m_btRaceServer != 111) && (this.m_TargetCret.m_btRaceServer != 55) && (this.m_TargetCret.m_btRaceServer != 128))
                    {
                        // ����Ѫ������800�Ĺ���  �޸ľ��� 20080704 ������ǽ
                        n_AmuletIndx = 0;
                        switch (HUtil32.Random(2))
                        {
                            case 0:
                                // 20080413

                                if (IsAllowUseMagic(38) && (HUtil32.GetTickCount() - m_SkillUseTick[38] > 1000))
                                {

                                    m_SkillUseTick[38] = HUtil32.GetTickCount();
                                    result = 38;
                                    // Ӣ��Ⱥ��ʩ��
                                    return result;
                                }

                                else if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // Ӣ��ʩ����
                                    return result;
                                }
                                break;
                            case 1:

                                if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // Ӣ��ʩ����
                                    return result;
                                }
                                break;
                        }
                    }
                    // �춾
                    // 4
                    // 4
                    if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && (GetUserItemList(2, 2) >= 0) && ((GameConfig.btHeroSkillMode) || (this.m_TargetCret.m_Abil.HP >= 700) || ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYMOSTER)) || m_boTarget) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) < 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) < 7)) && (this.m_TargetCret.m_btRaceServer != 110) && (this.m_TargetCret.m_btRaceServer != 111) && (this.m_TargetCret.m_btRaceServer != 55) && (this.m_TargetCret.m_btRaceServer != 128))
                    {
                        // ����Ѫ������100�Ĺ��� ������ǽ
                        n_AmuletIndx = 0;
                        switch (HUtil32.Random(2))
                        {
                            case 0:
                                // 20080413

                                if (IsAllowUseMagic(38) && (HUtil32.GetTickCount() - m_SkillUseTick[38] > 1000))
                                {

                                    m_SkillUseTick[38] = HUtil32.GetTickCount();
                                    result = 38;
                                    // Ӣ��Ⱥ��ʩ��
                                    return result;
                                }

                                else if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // Ӣ��ʩ����
                                    return result;
                                }
                                break;
                            case 1:

                                if (IsAllowUseMagic(6) && (HUtil32.GetTickCount() - m_SkillUseTick[6] > 1000))
                                {

                                    m_SkillUseTick[6] = HUtil32.GetTickCount();
                                    result = 6;
                                    // Ӣ��ʩ����
                                    return result;
                                }
                                break;
                        }
                    }
                    // �޼����� 20080323

                    if (IsAllowUseMagic(50) && (HUtil32.GetTickCount() - m_SkillUseTick[50] > GameConfig.nAbilityUpTick * 1000) && (this.m_wStatusArrValue[2] == 0) && ((GameConfig.btHeroSkillMode50) || (this.m_TargetCret.m_Abil.HP >= 700) || ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYMOSTER))))
                    {
                        // 20080827

                        m_SkillUseTick[50] = HUtil32.GetTickCount();
                        result = 50;
                        return result;
                    }
                    // end;

                    if (IsAllowUseMagic(51) && (HUtil32.GetTickCount() - m_SkillUseTick[51] > 5000))
                    {
                        // Ӣ��쫷��� 20080917

                        m_SkillUseTick[51] = HUtil32.GetTickCount();
                        result = 51;
                        return result;
                    }
                    if (CheckHeroAmulet(1, 1))
                    {
                        switch (HUtil32.Random(3))
                        {
                            case 0:
                                // ʹ�÷���ħ��
                                if (IsAllowUseMagic(59))
                                {
                                    result = 59;
                                    // Ӣ����Ѫ��
                                    return result;
                                }

                                // 1000
                                if (IsAllowUseMagic(13) && (HUtil32.GetTickCount() - m_SkillUseTick[13] > 3000))
                                {
                                    // 20090106
                                    result = 13;
                                    // Ӣ�������

                                    m_SkillUseTick[13] = HUtil32.GetTickCount();
                                    // 20080714
                                    return result;
                                }
                                if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                                {
                                    // ������
                                    result = 52;
                                    // Ӣ��������
                                    return result;
                                }
                                break;
                            case 1:
                                if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                                {
                                    // ������
                                    result = 52;
                                    return result;
                                }
                                if (IsAllowUseMagic(59))
                                {
                                    result = 59;
                                    // Ӣ����Ѫ��
                                    return result;
                                }

                                // 1000
                                if (IsAllowUseMagic(13) && (HUtil32.GetTickCount() - m_SkillUseTick[13] > 3000))
                                {
                                    // 20080401�޸��жϷ��ķ��� //20090106
                                    result = 13;
                                    // Ӣ�������

                                    m_SkillUseTick[13] = HUtil32.GetTickCount();
                                    // 20080714
                                    return result;
                                }
                                break;
                            case 2:
                                // 1

                                // 1000
                                if (IsAllowUseMagic(13) && (HUtil32.GetTickCount() - m_SkillUseTick[13] > 3000))
                                {
                                    // 20090106
                                    result = 13;
                                    // Ӣ�������

                                    m_SkillUseTick[13] = HUtil32.GetTickCount();
                                    // 20080714
                                    return result;
                                }
                                if (IsAllowUseMagic(59))
                                {
                                    result = 59;
                                    // Ӣ����Ѫ��
                                    return result;
                                }
                                if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                                {
                                    // ������
                                    result = 52;
                                    return result;
                                }
                                break;
                            // 2
                        }
                        // case Random(3) of ��
                        // ���ܴӸߵ���ѡ�� 20080710
                        if (IsAllowUseMagic(59))
                        {
                            // Ӣ����Ѫ��
                            result = 59;
                            return result;
                        }
                        if (IsAllowUseMagic(54))
                        {
                            // Ӣ�������� 20080917
                            result = 54;
                            return result;
                        }
                        if (IsAllowUseMagic(53))
                        {
                            // Ӣ��Ѫ�� 20080917
                            result = 53;
                            return result;
                        }
                        if (IsAllowUseMagic(51))
                        {
                            // Ӣ��쫷��� 20080917
                            result = 51;
                            return result;
                        }
                        if (IsAllowUseMagic(13))
                        {
                            // Ӣ�������
                            result = 13;
                            return result;
                        }
                        if (IsAllowUseMagic(52) && (this.m_TargetCret.m_wStatusArrValue[this.m_TargetCret.m_btJob] == 0))
                        {
                            // ������
                            result = 52;
                            return result;
                        }
                    }
                    break;
                // if CheckHeroAmulet(1,1) then begin//ʹ�÷���ħ��
                // ��ʿ
            }
            // case ְҵ

            return result;
        }

        /// <summary>
        /// ���Ӽ���������ļ��
        /// </summary>
        /// <param name="wIdent"></param>
        /// <param name="dwDelayTime"></param>
        /// <returns></returns>
        private bool CheckActionStatus(ushort wIdent, ref uint dwDelayTime)
        {
            bool result;
            uint dwCheckTime;
            uint dwActionIntervalTime;
            result = false;
            dwDelayTime = 0;
            dwCheckTime = HUtil32.GetTickCount() - m_dwActionTick;// ��������ͬ����֮��������ʱ��
            if (HUtil32.rangeInDefined(wIdent, 60, 65))// �ϻ�������
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
                return result;
            }
            dwActionIntervalTime = 530;
            if (dwCheckTime >= dwActionIntervalTime)
            {
                m_dwActionTick = HUtil32.GetTickCount();
                result = true;
            }
            else
            {
                dwDelayTime = dwActionIntervalTime - dwCheckTime;
            }
            m_wOldIdent = wIdent;
            m_btOldDir = this.m_btDirection;
            return result;
        }

        // 1 Ϊ����� 2 Ϊ��ҩ
        private bool IsUseAttackMagic()
        {
            bool result;
            // ����Ƿ����ʹ�ù���ħ��
            result = false;
            if (m_nSelectMagic <= 0)
            {
                return result;
            }
            switch (this.m_btJob)
            {
                case 0:
                case 1:
                    result = true;
                    break;
                case 2:
                    switch (m_nSelectMagic)
                    {
                        case MagicConst.SKILL_AMYOUNSUL:
                        case MagicConst.SKILL_GROUPAMYOUNSUL:
                            // 6 ʩ����
                            // 38 Ⱥ��ʩ����
                            result = CheckHeroAmulet(2, 1);
                            break;
                        case MagicConst.SKILL_FIRECHARM:
                        case MagicConst.SKILL_HOLYSHIELD:
                        case MagicConst.SKILL_SKELLETON:
                        case MagicConst.SKILL_52:
                        case MagicConst.SKILL_59:
                            // 13
                            // 16
                            // 17
                            // ��Ҫ��
                            result = CheckHeroAmulet(1, 1);
                            break;
                    }
                    break;
                // case
                // 2
            }
            return result;
        }

        private unsafe bool Think()
        {
            bool result;
            int nOldX;
            int nOldY;
            int UserMagicID = 0;
            TUserMagic* UserMagic = null;
            byte nCheckCode;
            const string sExceptionMsg = "{�쳣} THeroObject.Think Code:%d";
            result = false;
            nCheckCode = 0;
            try
            {
                if (this.m_Master == null)
                {
                    return result;
                }
                if ((this.m_Master.m_nCurrX == this.m_nCurrX) && (this.m_Master.m_nCurrY == this.m_nCurrY))
                {
                    m_boDupMode = true;
                }
                else
                {
                    if ((HUtil32.GetTickCount() - m_dwThinkTick) > 1000)
                    {
                        m_dwThinkTick = HUtil32.GetTickCount();
                        if (this.m_PEnvir.GetXYObjCount(this.m_nCurrX, this.m_nCurrY) >= 2)
                        {
                            m_boDupMode = true;
                        }
                        nCheckCode = 13;
                        if ((this.m_TargetCret != null))
                        {
                            if ((!this.IsProperTarget(this.m_TargetCret)))
                            {
                                this.m_TargetCret = null;
                            }
                        }
                    }
                }
                nCheckCode = 1;
                if (m_boDupMode && (m_btStatus != 2) && (HUtil32.GetTickCount() - this.dwTick3F4 > m_dwWalkIntervalTime))//�����߼��
                {
                    this.dwTick3F4 = HUtil32.GetTickCount();//����
                    nOldX = this.m_nCurrX;
                    nOldY = this.m_nCurrY;
                    this.WalkTo((byte)HUtil32.Random(8), false);
                    if ((nOldX != this.m_nCurrX) || (nOldY != this.m_nCurrY))
                    {
                        m_boDupMode = false;
                        result = true;
                    }
                }
                nCheckCode = 2;
                if (GameConfig.boHeroAutoProtectionDefence) // Ӣ����Ŀ�����Զ������������
                {
                    if (IsAllowUseMagic(75) && (this.m_wStatusTimeArr[Grobal2.STATE_ProtectionDEFENCE] == 0) && (!this.m_boProtectionDefence)
                        && (HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick) && (HUtil32.GetTickCount() - m_SkillUseTick[75] > 1000 * 3))
                    {
                        // ʹ�û������
                        m_SkillUseTick[75] = HUtil32.GetTickCount();
                        UserMagic = FindMagic(75);
                        m_boIsUseMagic = false;// �Ƿ��ܶ��
                        if (UserMagic != null)
                        {
                            ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                        }
                    }
                }
                switch (this.m_btJob)
                {
                    case 0:// սʿ
                        nCheckCode = 20;
                        if ((m_btStatus == 1) && (this.m_TargetCret != null))// ����״̬����
                        {
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 3) > 1) // �������Χʱʹ��ʨ�Ӻ�
                            {
                                if (IsAllowUseMagic(41) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                                {
                                    UserMagic = FindMagic(41);
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret); // ʹ��ħ��
                                    }
                                }
                            }
                            else
                            {
                                // Ұ��
                                if (IsAllowUseMagic(27) && (this.m_TargetCret.m_Abil.Level < this.m_Abil.Level))
                                {
                                    UserMagic = FindMagic(27);
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// ʹ��ħ��
                                    }
                                }
                            }
                            this.m_TargetCret = null;
                        }
                        break;
                    case 1:// ��ʦ
                        nCheckCode = 21;
                        if ((m_btStatus == 1) && (this.m_TargetCret != null)) // ����״̬����
                        {
                            if (IsAllowUseMagic(31) && (this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0) && (!this.m_boAbilMagBubbleDefence) && boAutoOpenDefence)
                            {
                                UserMagic = FindMagic(31);
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// ʹ��ħ����
                                }
                            }
                            if (IsAllowUseMagic(8) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                            {
                                UserMagic = FindMagic(8);
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret); // ʹ�ÿ��ܻ�
                                }
                            }
                            this.m_TargetCret = null;
                        }
                        // ����ģʽ,һֱ����ħ����
                        if ((m_btStatus == 0) && (IsAllowUseMagic(31) || IsAllowUseMagic(66)) && (this.m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] == 0)
                            && (!this.m_boAbilMagBubbleDefence) && boAutoOpenDefence)
                        {
                            if (IsAllowUseMagic(66))
                            {
                                UserMagic = FindMagic(66);
                            }
                            else if (IsAllowUseMagic(31))
                            {
                                UserMagic = FindMagic(31);
                            }
                            m_boIsUseMagic = false;// �Ƿ��ܶ��
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            if (UserMagic != null)
                            {
                                ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                            }
                        }
                        break;
                    case 2:// ��ʿ
                        nCheckCode = 28;
                        if ((m_nLoyal > 500) && (this.m_TargetCret != null)) // �ҳ϶ȳ���5%ʱ��PKʱ����ʹ����ʥս���� �����
                        {
                            if ((this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                if (IsAllowUseMagic(15) && (this.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && CheckHeroAmulet(1, 1)) // ��ħ��
                                {
                                    UserMagic = FindMagic(15);
                                    m_boIsUseMagic = false;// �Ƿ��ܶ��
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// ��ʥս����
                                    }
                                }
                                nCheckCode = 29;
                                if (IsAllowUseMagic(14) && (this.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && CheckHeroAmulet(1, 1))// ����ħ��
                                {
                                    UserMagic = FindMagic(14);
                                    m_boIsUseMagic = false;// �Ƿ��ܶ��
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this); // �����
                                    }
                                }
                                nCheckCode = 29;
                                if (this.m_Master != null)
                                {
                                    if (IsAllowUseMagic(15) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && (HUtil32.GetTickCount() - m_SkillUseTick[15] > 1000 * 3) && CheckHeroAmulet(1, 1))
                                    {
                                        // �����˴�ħ��
                                        m_SkillUseTick[15] = HUtil32.GetTickCount();
                                        UserMagic = FindMagic(15);
                                        m_boIsUseMagic = false;// �Ƿ��ܶ��
                                        if (UserMagic != null)
                                        {
                                            ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);// ʹ��ħ��
                                        }
                                    }
                                    nCheckCode = 26;
                                    // 1000 * 3
                                    if (IsAllowUseMagic(14) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && (HUtil32.GetTickCount() - m_SkillUseTick[14] > 3000) && CheckHeroAmulet(1, 1))
                                    {
                                        // �����˴�ħ��
                                        m_SkillUseTick[14] = HUtil32.GetTickCount();
                                        UserMagic = FindMagic(14);
                                        m_boIsUseMagic = false;// �Ƿ��ܶ��
                                        if (UserMagic != null)
                                        {
                                            ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master); // ʹ��ħ��
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (IsAllowUseMagic(15) && (this.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) && CheckHeroAmulet(1, 1))  // ��ħ��
                            {
                                UserMagic = FindMagic(15);
                                m_boIsUseMagic = false;// �Ƿ��ܶ��
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// ��ʥս����
                                }
                            }
                            nCheckCode = 29;
                            if (IsAllowUseMagic(14) && (this.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && CheckHeroAmulet(1, 1))// ����ħ��
                            {
                                UserMagic = FindMagic(14);
                                m_boIsUseMagic = false;// �Ƿ��ܶ��
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this); // �����
                                }
                            }
                            if (this.m_Master != null)
                            {
                                if (IsAllowUseMagic(15) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] == 0) &&
                                    (HUtil32.GetTickCount() - m_SkillUseTick[15] > 1000 * 3) && CheckHeroAmulet(1, 1))
                                {
                                    // �����˴�ħ��
                                    m_SkillUseTick[15] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(15);
                                    m_boIsUseMagic = false;// �Ƿ��ܶ��
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master); // ʹ��ħ��
                                    }
                                }
                                nCheckCode = 26;
                                // 1000 * 3
                                if (IsAllowUseMagic(14) && (this.m_Master.m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] == 0) && (HUtil32.GetTickCount() - m_SkillUseTick[14] > 3000) && CheckHeroAmulet(1, 1))
                                {
                                    // �����˴�ħ��
                                    m_SkillUseTick[14] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(14);
                                    m_boIsUseMagic = false;// �Ƿ��ܶ��
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master); // ʹ��ħ��
                                    }
                                }
                            }
                        }
                        nCheckCode = 27;
                        if ((m_btStatus == 1) && (this.m_TargetCret != null))
                        {
                            // ����״̬����
                            if (IsAllowUseMagic(48) && (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 1) > 0) && (this.m_TargetCret.m_WAbil.Level < this.m_WAbil.Level))
                            {
                                UserMagic = FindMagic(48);
                                m_boIsUseMagic = false;// �Ƿ��ܶ��
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// ʹ��������
                                }
                            }
                            this.m_TargetCret = null;
                        }
                        if ((m_btStatus != 0) && (this.m_ExpHitter != null))
                        {
                            if (CheckHeroAmulet(1, 1) && (this.m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] == 0))
                            {
                                if (IsAllowUseMagic(19) && (HUtil32.GetTickCount() - m_SkillUseTick[19] > 8000)) // ������
                                {
                                    m_SkillUseTick[19] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(19);
                                    m_boIsUseMagic = false;// �Ƿ��ܶ��
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                                    }
                                }
                                else if (IsAllowUseMagic(18) && (HUtil32.GetTickCount() - m_SkillUseTick[18] > 8000))
                                {
                                    m_SkillUseTick[18] = HUtil32.GetTickCount();
                                    UserMagic = FindMagic(18);
                                    m_boIsUseMagic = false;// �Ƿ��ܶ��
                                    if (UserMagic != null)
                                    {
                                        ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                                    }
                                }
                            }
                            this.m_ExpHitter = null;
                        }
                        nCheckCode = 22;
                        // ����HPֵ���ڻ�����60%ʱ,ʹ��������,�ȼ������ټ��Լ���Ѫ
                        if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)) && (this.m_WAbil.MP > 10) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000)
                            && (this.m_TargetCret == null))
                        {
                            if (IsAllowUseMagic(29))
                            {

                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(29);
                                m_boIsUseMagic = false;// �Ƿ��ܶ��
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);// ʹ��ħ��
                                }
                            }
                            else if (IsAllowUseMagic(2))
                            {
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(2);
                                m_boIsUseMagic = false;// �Ƿ��ܶ��
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);// ʹ��ħ��
                                }
                            }
                        }
                        nCheckCode = 23;
                        if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)) && (this.m_WAbil.MP > 10) && (HUtil32.GetTickCount() - m_SkillUseTick[2] > 3000) && (this.m_TargetCret == null))
                        {
                            if (IsAllowUseMagic(29))
                            {

                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(29);
                                m_boIsUseMagic = false;// �Ƿ��ܶ��
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, null);// ʹ��ħ��
                                }
                            }
                            else if (IsAllowUseMagic(2))
                            {
                                m_SkillUseTick[2] = HUtil32.GetTickCount();
                                UserMagic = FindMagic(2);
                                m_boIsUseMagic = false;// �Ƿ��ܶ��
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, null);// ʹ��ħ��
                                }
                            }
                        }
                        nCheckCode = 24;
                        if ((this.m_SlaveList.Count == 0) && GameConfig.boHeroNoTargetCall && CheckHeroAmulet(1, 5) && (HUtil32.GetTickCount() - m_SkillUseTick[17] > 1000 * 3))
                        {
                            m_SkillUseTick[17] = HUtil32.GetTickCount();// Ĭ��,�Ӹߵ���
                            if (IsAllowUseMagic(72))
                            {
                                // �ٻ�����
                                UserMagicID = 72;
                            }
                            else if (IsAllowUseMagic(30))
                            {
                                // �ٻ�����
                                UserMagicID = 30;
                            }
                            else if (IsAllowUseMagic(17))
                            {
                                UserMagicID = 17;
                            }
                            // �ٻ�����
                            if (UserMagicID > 0)
                            {
                                UserMagic = FindMagic((ushort)UserMagicID); // �޸�Ӣ���ٻ�����
                                m_boIsUseMagic = false;// �Ƿ��ܶ�� 20080719
                                if (UserMagic != null)
                                {
                                    ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);// ʹ��ħ��
                                }
                            }
                        }
                        nCheckCode = 25;
                        // 30 * 1000
                        if (((HUtil32.GetTickCount() - m_dwCheckNoHintTick) > 30000) && !m_boIsUseAttackMagic && (m_btStatus == 0))
                        {
                            // û������ʾ
                            m_dwCheckNoHintTick = HUtil32.GetTickCount();
                            if (IsAllowUseMagic(13) || IsAllowUseMagic(59))
                            {
                                if (!CheckHeroAmulet(1, 1))
                                {
                                    SysMsg("(Ӣ��) ����������꣡", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                            if (IsAllowUseMagic(6) || IsAllowUseMagic(38))
                            {
                                if (!CheckHeroAmulet(2, 1))
                                {
                                    SysMsg("(Ӣ��) ��ɫ��ҩ�Ѿ��꣡", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                                if (!CheckHeroAmulet(2, 2))
                                {
                                    SysMsg("(Ӣ��) ��ɫ��ҩ�Ѿ��꣡", TMsgColor.c_Green, TMsgType.t_Hint);
                                }
                            }
                        }
                        break;
                }
                nCheckCode = 3;
                if (m_nLoyal >= GameConfig.nGotoLV4) // Ӣ���ҳ϶ȴﵽָ��ֵ������ؼ���(��������һ𽣷��������)��3�����Զ��л����ļ�״̬ 
                {
                    switch (this.m_btJob)
                    {
                        case 0:
                            UserMagic = FindMagic(26);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 3)
                                {
                                    UserMagic->btLevel = 4;// ����Ϊ4������
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                    SysMsg("�����������ܵĹ�ϵ,����Ӣ���Ѿ�������4���һ𽣷�!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                        case 1:
                            UserMagic = FindMagic(45);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 3)
                                {
                                    UserMagic->btLevel = 4;// ����Ϊ4������
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                    SysMsg("�����������ܵĹ�ϵ,����Ӣ���Ѿ�������4�������!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                        case 2:
                            UserMagic = FindMagic(13);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 3)
                                {
                                    UserMagic->btLevel = 4;// ����Ϊ4������
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                    SysMsg("�����������ܵĹ�ϵ,����Ӣ���Ѿ�������4�������!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                    }
                }
                else
                {
                    switch (this.m_btJob)
                    {
                        case 0:// �ҳ϶ȵ��ڴ���ֵʱ,4����Ϊ3��
                            UserMagic = FindMagic(26);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 4)
                                {
                                    UserMagic->btLevel = 3;// 4����Ϊ3��
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                }
                            }
                            break;
                        case 1:
                            UserMagic = FindMagic(45);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 4)
                                {
                                    UserMagic->btLevel = 3;// 4����Ϊ3��
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                }
                            }
                            break;
                        case 2:
                            UserMagic = FindMagic(13);
                            if (UserMagic != null)
                            {
                                if (UserMagic->btLevel == 4)
                                {
                                    UserMagic->btLevel = 3;// 4����Ϊ3��
                                    SendUpdateDelayMsg(this.m_Master, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 800);
                                }
                            }
                            break;
                    }
                }
                nCheckCode = 4;
                if (SearchIsPickUpItem())
                {
                    SearchPickUpItem(500);// ����Ʒ
                }
                nCheckCode = 6;
                if (this.m_Master != null)
                {
                    // ����,���˻���ͼ,Ӣ������һ����
                    // ����ͬ����ͼʱ�ŷ�
                    if (((m_btStatus < 2) || ((m_btStatus == 2) && (!GameConfig.boRestNoFollow))) && !m_boProtectStatus && (this.m_PEnvir != this.m_Master.m_PEnvir)
                        && ((Math.Abs(this.m_nCurrX - this.m_Master.m_nCurrX) > 20) || (Math.Abs(this.m_nCurrY - this.m_Master.m_nCurrY) > 20)))
                    {
                        this.SpaceMove(this.m_Master.m_PEnvir.sMapName, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, 1);
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage(string.Format(sExceptionMsg, new byte[] { nCheckCode }));
            }
            return result;
        }

        // �Զ����
        private unsafe bool SearchIsPickUpItem()
        {
            bool result;
            TVisibleMapItem VisibleMapItem;
            TMapItem MapItem;
            int I;
            int nCurrX;
            int nCurrY;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (this.m_Master == null)
                {
                    return result;
                }
                if ((this.m_Master != null) && (this.m_Master.m_boDeath))
                {
                    return result;
                }
                if (m_btStatus == 2)
                {
                    return result;
                }
                if (this.m_TargetCret != null)
                {
                    return result;
                }
                if (m_boProtectStatus)
                {
                    return result;
                }
                nCode = 3;
                if (this.m_VisibleItems.Count == 0)
                {
                    return result;
                }
                nCode = 4;

                if (HUtil32.GetTickCount() < m_dwSearchIsPickUpItemTime)
                {
                    return result;
                }
                if ((!IsEnoughBag()))
                {
                    return result;
                }
                // 20080428 ע��
                if (this.m_Master != null)
                {
                    nCurrX = this.m_Master.m_nCurrX;
                    nCurrY = this.m_Master.m_nCurrY;
                    if (m_boProtectStatus)
                    {
                        nCurrX = m_nProtectTargetX;
                        nCurrY = m_nProtectTargetY;
                    }
                    if ((Math.Abs(nCurrX - this.m_nCurrX) > 15) || (Math.Abs(nCurrY - this.m_nCurrY) > 15))
                    {
                        // 1000 * 5
                        m_dwSearchIsPickUpItemTime = HUtil32.GetTickCount() + 5000;
                        return result;
                    }
                }
                nCode = 10;
                if (this.m_VisibleItems.Count > 0)
                {
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 11;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 12;
                        if ((VisibleMapItem != null))
                        {
                            if ((VisibleMapItem.nVisibleFlag > 0))
                            {
                                MapItem = VisibleMapItem.MapItem;
                                nCode = 13;
                                if ((MapItem != null))
                                {
                                    if ((this.m_Master != null))
                                    {
                                        nCode = 14;
                                        if (MapItem.DropBaseObject != null)
                                        {
                                            nCode = 15;
                                            if ((MapItem.DropBaseObject != this.m_Master))
                                            {
                                                nCode = 16;
                                                if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(MapItem.UserItem->wIndex)))
                                                {
                                                    nCode = 17;
                                                    if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                                    {
                                                        nCode = 18;
                                                        if ((Math.Abs(VisibleMapItem.nX - this.m_nCurrX) <= 5) && (Math.Abs(VisibleMapItem.nY - this.m_nCurrY) <= 5))
                                                        {
                                                            result = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // MainOutMessage('{�쳣} THeroObject.SearchIsPickUpItem Code:'+inttostr(nCode));
            }
            return result;
        }

        // �����䵶�ж�Ŀ�꺯�� 20081207
        // δʹ�õĺ���
        private bool GotoTargetXYRange()
        {
            bool result;
            int n10;
            int n14;
            int nTargetX;
            int nTargetY;
            result = true;
            nTargetX = 0;
            // 20080529
            nTargetY = 0;
            // 20080529
            n10 = Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX);
            n14 = Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY);
            if (n10 > 4)
            {
                n10 -= 5;
            }
            else
            {
                n10 = 0;
            }
            if (n14 > 4)
            {
                n14 -= 5;
            }
            else
            {
                n14 = 0;
            }
            if (this.m_TargetCret.m_nCurrX > this.m_nCurrX)
            {
                nTargetX = this.m_nCurrX + n10;
            }
            if (this.m_TargetCret.m_nCurrX < this.m_nCurrX)
            {
                nTargetX = this.m_nCurrX - n10;
            }
            if (this.m_TargetCret.m_nCurrY > this.m_nCurrY)
            {
                nTargetY = this.m_nCurrY + n14;
            }
            if (this.m_TargetCret.m_nCurrY < this.m_nCurrY)
            {
                nTargetY = this.m_nCurrY - n14;
            }
            result = GotoTargetXY(nTargetX, nTargetY, 0);
            return result;
        }

        // �Զ����
        public int AutoAvoid_GetAvoidDir()
        {
            int result;
            int n10;
            int n14;
            n10 = this.m_TargetCret.m_nCurrX;
            n14 = this.m_TargetCret.m_nCurrY;
            result = Grobal2.DR_DOWN;
            if (n10 > this.m_nCurrX)
            {
                result = Grobal2.DR_LEFT;
                if (n14 > this.m_nCurrY)
                {
                    result = Grobal2.DR_DOWNLEFT;
                }
                if (n14 < this.m_nCurrY)
                {
                    result = Grobal2.DR_UPLEFT;
                }
            }
            else
            {
                if (n10 < this.m_nCurrX)
                {
                    result = Grobal2.DR_RIGHT;
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNRIGHT;
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UPRIGHT;
                    }
                }
                else
                {
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_UP;
                    }
                    else if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWN;
                    }
                }
            }
            return result;
        }

        public byte AutoAvoid_GetDirXY(int nTargetX, int nTargetY)
        {
            byte result;
            int n10;
            int n14;
            n10 = nTargetX;
            n14 = nTargetY;
            result = Grobal2.DR_DOWN;// ��
            if (n10 > this.m_nCurrX)
            {
                result = Grobal2.DR_RIGHT;// ��
                if (n14 > this.m_nCurrY)
                {
                    result = Grobal2.DR_DOWNRIGHT;// ������
                }
                if (n14 < this.m_nCurrY)
                {
                    result = Grobal2.DR_UPRIGHT; // ������
                }
            }
            else
            {
                if (n10 < this.m_nCurrX)
                {
                    result = Grobal2.DR_LEFT;// ��
                    if (n14 > this.m_nCurrY)
                    {
                        result = Grobal2.DR_DOWNLEFT;// ������
                    }
                    if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UPLEFT; // ������
                    }
                }
                else
                {
                    if (n14 > this.m_nCurrY)// ��
                    {
                        result = Grobal2.DR_DOWN;
                    }
                    else if (n14 < this.m_nCurrY)
                    {
                        result = Grobal2.DR_UP;  // ����
                    }
                }
            }
            return result;
        }

        public bool AutoAvoid_GetGotoXY(int nDir, ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n01;
            result = false;
            n01 = 0;
            while (true)
            {
                switch (nDir)
                {
                    case Grobal2.DR_UP:// ��
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPRIGHT:// ����
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_RIGHT:// ��
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNRIGHT:// ����
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX += 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX += 2;
                            nTargetY += 2;
                            n01++;
                            continue;
                        }
                    case Grobal2.DR_DOWN:// ��
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_DOWNLEFT:// ����
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY += 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY += 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_LEFT:// ��
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            n01 += 2;
                            continue;
                        }
                    case Grobal2.DR_UPLEFT:// ������
                        if (this.m_PEnvir.CanWalk(nTargetX, nTargetY, false) && (CheckTargetXYCountOfDirection(nTargetX, nTargetY, nDir, 3) == 0))
                        {
                            nTargetX -= 2;
                            nTargetY -= 2;
                            result = true;
                            break;
                        }
                        else
                        {
                            if (n01 >= 10)
                            {
                                break;
                            }
                            nTargetX -= 2;
                            nTargetY -= 2;
                            n01 += 2;
                            continue;
                        }
                    default:
                        break;
                }
            }
            return result;
        }

        public bool AutoAvoid_GetAvoidXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int n10;
            int nDir = 0;
            int nX;
            int nY;
            nX = nTargetX;
            nY = nTargetY;
            result = AutoAvoid_GetGotoXY(m_btLastDirection, ref nTargetX, ref nTargetY);
            n10 = 0;
            while (true)
            {
                if (n10 >= 7)
                {
                    break;
                }
                if (result)
                {
                    break;
                }
                nTargetX = nX;
                nTargetY = nY;
                nDir = HUtil32.Random(7);
                result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                n10++;
            }
            m_btLastDirection = (byte)nDir;
            // m_btDirection;

            return result;
        }

        public bool AutoAvoid_GotoMasterXY(ref int nTargetX, ref int nTargetY)
        {
            bool result;
            int nDir;
            result = false;
            if ((this.m_Master != null) && ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 6) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 6)) && !m_boProtectStatus)
            {
                nTargetX = this.m_nCurrX;
                nTargetY = this.m_nCurrY;
                // nTargetX := m_Master.m_nCurrX;//20080215
                // nTargetY := m_Master.m_nCurrY;//20080215
                nDir = AutoAvoid_GetDirXY(this.m_Master.m_nCurrX, this.m_Master.m_nCurrY);
                switch (nDir)
                {
                    case Grobal2.DR_UP:
                        // m_btLastDirection := nDir;//20080402
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        break;
                    case Grobal2.DR_RIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_RIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_RIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        break;
                    case Grobal2.DR_DOWN:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNRIGHT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNRIGHT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWN, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWN;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        break;
                    case Grobal2.DR_LEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_DOWNLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_DOWNLEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UPLEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UPLEFT;
                        }
                        break;
                    case Grobal2.DR_UPLEFT:
                        result = AutoAvoid_GetGotoXY(nDir, ref nTargetX, ref nTargetY);
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_LEFT, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_LEFT;
                        }
                        if (!result)
                        {
                            nTargetX = this.m_nCurrX;
                            nTargetY = this.m_nCurrY;
                            result = AutoAvoid_GetGotoXY(Grobal2.DR_UP, ref nTargetX, ref nTargetY);
                            m_btLastDirection = Grobal2.DR_UP;
                        }
                        break;
                }
            }
            return result;
        }

        // ʹ�õ���Ʒ
        private bool AutoAvoid()
        {
            bool result;
            int nTargetX = 0;
            int nTargetY = 0;
            int nDir;
            result = true;
            if ((this.m_TargetCret != null) && !this.m_TargetCret.m_boDeath)
            {
                if (AutoAvoid_GotoMasterXY(ref nTargetX, ref nTargetY))
                {
                    result = GotoTargetXY(nTargetX, nTargetY, 1);
                }
                else
                {
                    nTargetX = this.m_nCurrX;
                    nTargetY = this.m_nCurrY;
                    nDir = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                    nDir = this.GetBackDir((byte)nDir);
                    this.m_PEnvir.GetNextPosition(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, nDir, 5, ref m_nTargetX, ref m_nTargetY);
                    result = GotoTargetXY(m_nTargetX, m_nTargetY, 1);
                }
            }
            return result;
        }

        public void SearchPickUpItem_SetHideItem(TMapItem MapItem)
        {
            TVisibleMapItem VisibleMapItem;
            int I;
            for (I = 0; I < this.m_VisibleItems.Count; I++)
            {
                VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                if ((VisibleMapItem != null) && (VisibleMapItem.nVisibleFlag > 0))
                {
                    if (VisibleMapItem.MapItem == MapItem)
                    {
                        VisibleMapItem.nVisibleFlag = 0;
                        break;
                    }
                }
            }
        }

        public unsafe bool SearchPickUpItem_PickUpItem(int nX, int nY)
        {
            bool result;
            TUserItem* UserItem = null;
            TStdItem* StdItem;
            TMapItem MapItem;
            result = false;
            MapItem = this.m_PEnvir.GetItem(nX, nY);
            if (MapItem == null)
            {
                return result;
            }
            if ((MapItem.Name).ToLower().CompareTo((M2Share.sSTRING_GOLDNAME).ToLower()) == 0)
            {
                if (this.m_PEnvir.DeleteFromMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                {
                    if ((this.m_Master != null) && (!this.m_Master.m_boDeath))
                    {
                        // �񵽵�Ǯ�Ӹ�����
                        if (((TPlayObject)(this.m_Master)).IncGold(MapItem.Count))
                        {
                            //this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, nX, nY, "");
                            if (M2Share.g_boGameLogGold)
                            {
                                M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (nX).ToString() + "\09" + (nY).ToString()
                                    + "\09" + this.m_sCharName + "\09" + M2Share.sSTRING_GOLDNAME + "\09" + (MapItem.Count).ToString() + "\09"
                                    + "1" + "\09" + "0");
                            }
                            result = true;
                            this.m_Master.GoldChanged();
                            SearchPickUpItem_SetHideItem(MapItem);
                            Dispose(MapItem);
                        }
                        else
                        {
                            this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                        }
                    }
                    else
                    {
                        this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                    }
                }
                else
                {
                    this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                }
            }
            else
            {
                // ����Ʒ
                StdItem = UserEngine.GetStdItem(MapItem.UserItem->wIndex);
                if (StdItem != null)
                {
                    if (this.m_PEnvir.DeleteFromMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object)) == 1)
                    {
                        //FillChar(UserItem, sizeof(TUserItem), '\0');
                        // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);
                        UserItem = MapItem.UserItem;
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if ((StdItem != null) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(UserItem->wIndex)))
                        {
                            if (AddItemToBag(UserItem))
                            {
                                // this.SendRefMsg(Grobal2.RM_ITEMHIDE, 0, (int)MapItem, nX, nY, "");
                                SendAddItem(UserItem);
                                //this.m_WAbil.Weight = this.RecalcBagWeight();
                                if (StdItem->NeedIdentify == 1)
                                {
                                    M2Share.AddGameDataLog("4" + "\09" + this.m_sMapName + "\09" + (nX).ToString() + "\09" + (nY).ToString() + "\09" + this.m_sCharName
                                        + "\09" + HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen) + "\09" + (UserItem->MakeIndex).ToString() + "\09" + "(" + (HUtil32.LoWord(StdItem->DC)).ToString() + "/"
                                        + (HUtil32.HiWord(StdItem->DC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MC)).ToString()
                                        + ")" + "(" + (HUtil32.LoWord(StdItem->SC)).ToString() + "/" + (HUtil32.HiWord(StdItem->SC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->AC)).ToString() + "/"
                                        + (HUtil32.HiWord(StdItem->AC)).ToString() + ")" + "(" + (HUtil32.LoWord(StdItem->MAC)).ToString() + "/" + (HUtil32.HiWord(StdItem->MAC)).ToString() + ")"
                                        + (UserItem->btValue[0]).ToString() + "/" + (UserItem->btValue[1]).ToString() + "/" + (UserItem->btValue[2]).ToString() + "/" + (UserItem->btValue[3]).ToString()
                                        + "/" + (UserItem->btValue[4]).ToString() + "/" + (UserItem->btValue[5]).ToString() + "/" + (UserItem->btValue[6]).ToString() + "/"
                                        + (UserItem->btValue[7]).ToString() + "/" + (UserItem->btValue[8]).ToString() + "/" + (UserItem->btValue[14]).ToString() + "\09"
                                        + (UserItem->Dura).ToString() + "/" + (UserItem->DuraMax).ToString());
                                }
                                result = true;
                                SearchPickUpItem_SetHideItem(MapItem);

                                Dispose(MapItem);
                            }
                            else
                            {
                                Marshal.FreeHGlobal((IntPtr)UserItem);
                                //Dispose(UserItem);
                                this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                            }
                        }
                        else
                        {
                            Marshal.FreeHGlobal((IntPtr)UserItem);
                            //Dispose(UserItem);
                            this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                        }
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        //Dispose(UserItem);
                        this.m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, ((MapItem) as Object));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Ӣ���Զ�����Ʒ
        /// </summary>
        /// <param name="nPickUpTime">���</param>
        /// <returns></returns>
        private unsafe bool SearchPickUpItem(int nPickUpTime)
        {
            bool result;
            TMapItem MapItem;
            TVisibleMapItem VisibleMapItem = null;
            TVisibleMapItem SelVisibleMapItem = null;
            int I;
            bool boFound;
            int n01;
            int n02;
            byte nCode;
            result = false;
            nCode = 0;
            try
            {
                if (HUtil32.GetTickCount() - m_dwPickUpItemTick < nPickUpTime)
                {
                    return result;
                }
                m_dwPickUpItemTick = HUtil32.GetTickCount();
                boFound = false;
                nCode = 1;
                if (m_SelMapItem != null)
                {
                    nCode = 2;
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 3;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 4;
                        if ((VisibleMapItem != null) && (VisibleMapItem.nVisibleFlag > 0))
                        {
                            if (VisibleMapItem.MapItem == m_SelMapItem)
                            {
                                nCode = 5;
                                boFound = true;
                                break;
                            }
                        }
                    }
                }
                if (!boFound)
                {
                    m_SelMapItem = null;
                }
                nCode = 6;
                if (m_SelMapItem != null)
                {
                    if (SearchPickUpItem_PickUpItem(this.m_nCurrX, this.m_nCurrY))
                    {
                        result = true;
                        return result;
                    }
                }
                n01 = 999;
                nCode = 7;
                SelVisibleMapItem = null;
                boFound = false;
                if (m_SelMapItem != null)
                {
                    nCode = 8;
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 9;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 10;
                        if ((VisibleMapItem != null) && (VisibleMapItem.nVisibleFlag > 0))
                        {
                            nCode = 11;
                            if (VisibleMapItem.MapItem == m_SelMapItem)
                            {
                                SelVisibleMapItem = VisibleMapItem;
                                boFound = true;
                                break;
                            }
                        }
                    }
                }
                if (!boFound)
                {
                    nCode = 12;
                    for (I = 0; I < this.m_VisibleItems.Count; I++)
                    {
                        nCode = 13;
                        VisibleMapItem = ((TVisibleMapItem)(this.m_VisibleItems[I]));
                        nCode = 14;
                        if ((VisibleMapItem != null))
                        {
                            if ((VisibleMapItem.nVisibleFlag > 0))
                            {
                                MapItem = VisibleMapItem.MapItem;
                                nCode = 15;
                                if ((MapItem != null))
                                {
                                    if ((MapItem.DropBaseObject != this.m_Master))
                                    {
                                        nCode = 16;
                                        if (M2Share.IsAllowPickUpItem(VisibleMapItem.sName) && this.IsAddWeightAvailable(UserEngine.GetStdItemWeight(MapItem.UserItem->wIndex)))
                                        {
                                            nCode = 17;
                                            if ((MapItem.OfBaseObject == null) || (MapItem.OfBaseObject == this.m_Master) || (MapItem.OfBaseObject == this))
                                            {
                                                nCode = 18;
                                                if ((Math.Abs(VisibleMapItem.nX - this.m_nCurrX) <= 5) && (Math.Abs(VisibleMapItem.nY - this.m_nCurrY) <= 5))
                                                {
                                                    n02 = Math.Abs(VisibleMapItem.nX - this.m_nCurrX) + Math.Abs(VisibleMapItem.nY - this.m_nCurrY);
                                                    if (n02 < n01)
                                                    {
                                                        n01 = n02;
                                                        nCode = 19;
                                                        SelVisibleMapItem = VisibleMapItem;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // for
                }
                nCode = 20;
                if (SelVisibleMapItem != null)
                {
                    nCode = 21;
                    m_SelMapItem = SelVisibleMapItem.MapItem;
                    if ((this.m_nCurrX != SelVisibleMapItem.nX) || (this.m_nCurrY != SelVisibleMapItem.nY))
                    {
                        nCode = 22;
                        WalkToTargetXY2(SelVisibleMapItem.nX, VisibleMapItem.nY);
                        result = true;
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.SearchPickUpItem Code:" + nCode);
            }
            return result;
        }

        private bool EatUseItems(int nShape)
        {
            bool result;
            result = false;
            switch (nShape)
            {
                case 4:
                    if (WeaptonMakeLuck())
                    {
                        result = true;
                    }
                    break;
                case 9:
                    if (RepairWeapon())
                    {
                        result = true;
                    }
                    break;
                case 10:
                    if (SuperRepairWeapon())
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }

        // �Զ���ҩ
        public unsafe int AutoEatUseItems_FoundAddHealthItem(byte ItemType)
        {
            int result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            TUserItem* UserItem1;
            TStdItem* StdItem1;
            TStdItem* StdItem2;
            TStdItem* StdItem3;
            int II;
            int MinHP;
            int j = 0;
            int nHP;
            result = -1;
            if (this.m_ItemList.Count > 0)
            {
                // 20080628
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem != null)
                    {
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if (StdItem != null)
                        {
                            switch (ItemType)
                            {
                                case 0:
                                    // ��ҩ
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->AC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 1:
                                    // ��ҩ
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 0) && (StdItem->MAC > 0))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 2:
                                    // ̫��ˮ(��������ҩƷ,�Ա�HP,ѡ���ʺϵ�ҩƷ)
                                    if ((StdItem->StdMode == 0) && (StdItem->Shape == 1) && (StdItem->AC > 0) && (StdItem->MAC > 0))
                                    {
                                        MinHP = StdItem->AC;
                                        nHP = this.m_WAbil.MaxHP - this.m_WAbil.HP;
                                        // ȡ��ǰѪ�Ĳ�ֵ
                                        j = I;
                                        for (II = 0; II < this.m_ItemList.Count; II++)
                                        {
                                            // ѭ���ҳ�+HP���ʺϵ�������Ʒ
                                            UserItem1 = (TUserItem*)this.m_ItemList[II];
                                            if (UserItem1 != null)
                                            {
                                                StdItem1 = UserEngine.GetStdItem(UserItem1->wIndex);
                                                if (StdItem1 != null)
                                                {
                                                    if ((StdItem1->StdMode == 0) && (StdItem1->Shape == 1) && (StdItem1->AC > 0) && (StdItem1->MAC > 0))
                                                    {
                                                        if (Math.Abs(StdItem1->AC - nHP) < Math.Abs(MinHP - nHP))
                                                        {
                                                            MinHP = StdItem1->AC;
                                                            j = II;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        for (II = 0; II < this.m_ItemList.Count; II++)
                                        {
                                            UserItem1 = (TUserItem*)this.m_ItemList[II];
                                            if (UserItem1 != null)
                                            {
                                                StdItem1 = UserEngine.GetStdItem(UserItem1->wIndex);
                                                if (StdItem1 != null)
                                                {
                                                    if ((StdItem1->StdMode == 31) && (M2Share.GetBindItemType(StdItem1->Shape) == 2) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                                    {
                                                        StdItem3 = UserEngine.GetStdItem(M2Share.GetBindItemName(StdItem1->Shape));
                                                        // ���Խ��������Ʒ��
                                                        if (StdItem3 != null)
                                                        {
                                                            if ((StdItem3->StdMode == 0) && (StdItem3->Shape == 1) && (StdItem3->AC > 0) && (StdItem3->MAC > 0))
                                                            {
                                                                if (Math.Abs(StdItem3->AC - nHP) < Math.Abs(MinHP - nHP))
                                                                {
                                                                    // 20080926
                                                                    MinHP = StdItem3->AC;
                                                                    j = II;
                                                                }
                                                            }
                                                        }
                                                        // if StdItem3 <> nil then begin
                                                    }
                                                }
                                            }
                                        }
                                        result = j;
                                        break;
                                    }
                                    break;
                                case 3:
                                    // ��ҩ��
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 0) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 4:
                                    // ��ҩ��
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 1) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                    {
                                        result = I;
                                        break;
                                    }
                                    break;
                                case 5:
                                    // ��ҩ�� ���ܽ��
                                    if ((StdItem->StdMode == 31) && (M2Share.GetBindItemType(StdItem->Shape) == 2) && (this.m_ItemList.Count + 6 < m_nItemBagCount))
                                    {
                                        StdItem1 = UserEngine.GetStdItem(M2Share.GetBindItemName(StdItem->Shape));
                                        // ���Խ��������Ʒ��
                                        if (StdItem1 != null)
                                        {
                                            MinHP = StdItem1->AC;
                                            nHP = this.m_WAbil.MaxHP - this.m_WAbil.HP;
                                            // ȡ��ǰѪ�Ĳ�ֵ
                                            j = I;
                                            for (II = 0; II < this.m_ItemList.Count; II++)
                                            {
                                                // ѭ���ҳ�+HP���ʺϵ�������Ʒ
                                                UserItem1 = (TUserItem*)this.m_ItemList[II];
                                                if (UserItem1 != null)
                                                {
                                                    StdItem2 = UserEngine.GetStdItem(UserItem1->wIndex);
                                                    if (StdItem2 != null)
                                                    {
                                                        if ((StdItem2->StdMode == 31) && (M2Share.GetBindItemType(StdItem2->Shape) == 2))
                                                        {
                                                            StdItem3 = UserEngine.GetStdItem(M2Share.GetBindItemName(StdItem2->Shape));
                                                            // ���Խ��������Ʒ��
                                                            if (StdItem3 != null)
                                                            {
                                                                if ((StdItem3->StdMode == 0) && (StdItem3->Shape == 1) && (StdItem3->AC > 0) && (StdItem3->MAC > 0))
                                                                {
                                                                    if (Math.Abs(StdItem3->AC - nHP) < Math.Abs(MinHP - nHP))
                                                                    {
                                                                        // 20080926
                                                                        MinHP = StdItem3->AC;
                                                                        j = II;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        result = j;
                                        break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // ��ҩ
        private unsafe bool AutoEatUseItems(byte btItemType)
        {
            bool result;
            int nItemIdx;
            TUserItem* UserItem;
            result = false;
            if (!this.m_boDeath)
            {
                nItemIdx = AutoEatUseItems_FoundAddHealthItem(btItemType);
                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                {
                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                    SendDelItems(UserItem);
                    ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                    result = true;
                }
                else
                {
                    switch (btItemType)// ���ҽ����Ʒ
                    {
                        case 0:
                            nItemIdx = AutoEatUseItems_FoundAddHealthItem(0);// ���Һ�ҩ
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = true;
                                UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                SendDelItems(UserItem);
                                ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                            }
                            else
                            {
                                nItemIdx = AutoEatUseItems_FoundAddHealthItem(3);// ���Һ�ҩ��
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = true;
                                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                    SendDelItems(UserItem);
                                    ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                                }
                            }
                            break;
                        case 1:
                            nItemIdx = AutoEatUseItems_FoundAddHealthItem(1);// ������ҩ
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = true;
                                UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                SendDelItems(UserItem);
                                ClientHeroUseItems(UserItem->MakeIndex,
                                    HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                            }
                            else
                            {
                                nItemIdx = AutoEatUseItems_FoundAddHealthItem(4);// ��ҩ��
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = true;
                                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                    SendDelItems(UserItem);
                                    ClientHeroUseItems(UserItem->MakeIndex,
                                        HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                                }
                            }
                            break;
                        case 2:
                            nItemIdx = AutoEatUseItems_FoundAddHealthItem(2);// ��������ҩƷ,�Ա�HP,ѡ���ʺϵ�ҩƷ
                            if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                            {
                                result = true;
                                UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                SendDelItems(UserItem);
                                ClientHeroUseItems(UserItem->MakeIndex,
                                    HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                            }
                            else
                            {
                                nItemIdx = AutoEatUseItems_FoundAddHealthItem(5);// ��ҩ��
                                if ((nItemIdx >= 0) && (nItemIdx < this.m_ItemList.Count))
                                {
                                    result = true;
                                    UserItem = ((TUserItem*)(this.m_ItemList[nItemIdx]));
                                    SendDelItems(UserItem);
                                    ClientHeroUseItems(UserItem->MakeIndex, HUtil32.SBytePtrToString(UserEngine.GetStdItem(UserItem->wIndex)->Name, 0, UserEngine.GetStdItem(UserItem->wIndex)->NameLen));
                                }
                            }
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// �Ƿ�����Ŀ��
        /// </summary>
        /// <returns></returns>
        public unsafe bool IsNeedGotoXY()
        {
            bool result = false;
            uint dwAttackTime = 0;
            if ((this.m_TargetCret != null) && (HUtil32.GetTickCount() - m_dwAutoAvoidTick > 1100) && (!m_boIsUseAttackMagic || (this.m_btJob == 0)))
            {
                if (this.m_btJob > 0)
                {
                    if ((m_btStatus != 2) && !m_boIsUseMagic && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 3) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 3)))
                    {
                        result = true;
                        return result;
                    }
                    if ((m_btStatus != 2) && ((GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22)) ||
                        (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_WAbil.MaxHP < 700) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                        && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT) && (this.m_btJob == 2) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1)
                        || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))))// ����22ǰ�Ƿ�������
                    {
                        result = true;
                        return result;
                    }
                }
                else if ((m_btStatus != 2))
                {
                    switch (m_nSelectMagic)
                    {
                        case 12:// ��ɱ
                            if (IsAllowUseMagic(12) && (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY)))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // ��ֹ��������
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
                                    {
                                        this.m_dwHitTick = HUtil32.GetTickCount();
                                        m_wHitMode = 4;// ��ɱ
                                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                        Attack(this.m_TargetCret, this.m_btDirection);
                                        this.BreakHolySeizeMode();
                                        return result;
                                    }
                                }
                                else
                                {
                                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            m_nSelectMagic = 0;
                            if (IsAllowUseMagic(12))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 74:// ���ս���
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)) ||
                                    ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4)) ||
                                    (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)) ||
                                    ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3)) ||
                                    ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4))))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // ��ֹ��������
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
                                    {
                                        this.m_dwHitTick = HUtil32.GetTickCount();
                                        m_wHitMode = 13;
                                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                        Attack(this.m_TargetCret, this.m_btDirection);
                                        this.BreakHolySeizeMode();
                                        return result;
                                    }
                                }
                                else
                                {
                                    if (IsAllowUseMagic(12))
                                    {
                                        if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                        {
                                            result = true;
                                            return result;
                                        }
                                    }
                                    else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            m_nSelectMagic = 0;
                            if (IsAllowUseMagic(12))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 43:// ʵ�ָ�λ�ſ���
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 5, ref m_nTargetX, ref m_nTargetY) && (this.m_n42kill == 2))
                            {
                                if (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) <= 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) <= 4))
                                    || (((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 3) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 3))
                                    || ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 4) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 4))))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // ��ֹ��������
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
                                    {
                                        this.m_dwHitTick = HUtil32.GetTickCount();
                                        m_wHitMode = 9;
                                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                        Attack(this.m_TargetCret, this.m_btDirection);
                                        this.BreakHolySeizeMode();
                                        return result;
                                    }
                                }
                                else
                                {
                                    if (IsAllowUseMagic(12))
                                    {
                                        if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                        {
                                            result = true;
                                            return result;
                                        }
                                    }
                                    else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            m_nSelectMagic = 0;
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref m_nTargetX, ref m_nTargetY) && (new ArrayList(new int[] { 1, 2 }).Contains(this.m_n42kill)))
                            {
                                if ((Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 0)
                                    || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 0) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2)
                                    || (Math.Abs(this.m_nCurrX - this.m_TargetCret.m_nCurrX) == 2) && (Math.Abs(this.m_nCurrY - this.m_TargetCret.m_nCurrY) == 2))
                                {
                                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);
                                    // ��ֹ��������
                                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime))
                                    {
                                        this.m_dwHitTick = HUtil32.GetTickCount();
                                        m_wHitMode = 9;
                                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                                        Attack(this.m_TargetCret, this.m_btDirection);
                                        this.BreakHolySeizeMode();
                                        return result;
                                    }
                                }
                                else
                                {
                                    if (((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1)))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            m_nSelectMagic = 0;
                            if (IsAllowUseMagic(12))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 7:
                        case 25:
                        case 26:
                            if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                m_nSelectMagic = 0;
                                return result;
                            }
                            break;
                        default:
                            if (IsAllowUseMagic(12))
                            {
                                if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 2) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 2))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            else if ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 1) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 1))
                            {
                                result = true;
                                return result;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        // �Ƿ���Լ����Ʒ
        // function IsPickUpItem(StdItem: pTStdItem): Boolean; 20080117
        // �Ƿ���Ҫ���
        private unsafe bool IsNeedAvoid()
        {
            bool result;
            result = false;

            if (((HUtil32.GetTickCount() - m_dwAutoAvoidTick) > 1100) && m_boIsUseMagic)
            {
                // Ѫ����25%ʱ,�ض�Ҫ�� 20080711
                if ((this.m_btJob > 0) && (m_btStatus != 2) && ((m_nSelectMagic == 0) || (this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.25))))
                {

                    m_dwAutoAvoidTick = HUtil32.GetTickCount();
                    switch (this.m_btJob)
                    {
                        case 1:
                            if (CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0)
                            {
                                result = true;
                                return result;
                            }
                            break;
                        case 2:
                            // 20090112
                            if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                // 22����Ѫ���Ĺ� 20090108
                                if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                {
                                    // 20090108
                                    // 3
                                    if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0))
                                    {
                                        result = true;
                                        return result;
                                    }
                                }
                            }
                            else
                            {
                                // 3
                                if ((CheckTargetXYCount(this.m_nCurrX, this.m_nCurrY, 4) > 0))
                                {
                                    result = true;
                                    return result;
                                }
                            }
                            break;
                    }
                    // if CheckTargetXYCount(m_nCurrX, m_nCurrY, 3) > 0 then begin
                    // Result := True;
                    // end;
                }
                // if (not Result) and (m_WAbil.HP <= Round(m_WAbil.MaxHP * 0.15)) then Result := True;//20080711 20090202ע��
            }
            return result;
        }

        public unsafe bool EatMedicine_FoundItem(byte ItemType)
        {
            bool result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = false;
            if (this.m_ItemList.Count > 0)
            {
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if (UserItem != null)
                    {
                        StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if (StdItem != null)
                        {
                            switch (ItemType)
                            {
                                case 0:
                                    // ��ҩ
                                    if ((StdItem->StdMode == 0) && ((StdItem->Shape == 0) || (StdItem->Shape == 1)) && (StdItem->AC > 0))
                                    {
                                        result = true;
                                        break;
                                    }
                                    if ((StdItem->StdMode == 31) && ((M2Share.GetBindItemType(StdItem->Shape) == 0) || (M2Share.GetBindItemType(StdItem->Shape) == 2)))
                                    {
                                        result = true;
                                        break;
                                    }
                                    break;
                                case 1:
                                    // ��ҩ
                                    if ((StdItem->StdMode == 0) && ((StdItem->Shape == 0) || (StdItem->Shape == 1)) && (StdItem->MAC > 0))
                                    {
                                        result = true;
                                        break;
                                    }
                                    if ((StdItem->StdMode == 31) && ((M2Share.GetBindItemType(StdItem->Shape) == 1) || (M2Share.GetBindItemType(StdItem->Shape) == 2)))
                                    {
                                        result = true;
                                        break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // ����Ʒ
        // ��ҩ
        private unsafe void EatMedicine()
        {
            int n01;
            bool boFound;
            byte btItemType;
            boFound = false;
            btItemType = 0;
            if (!this.m_PEnvir.m_boMISSION)
            {
                //��ͼû������ʹ����Ʒʱ,�����Զ���ҩ
                if ((HUtil32.GetTickCount() - m_dwEatItemTick) > GameConfig.nHeroAddHPMPTick)
                {
                    // Ӣ�۳���ͨҩ��� 20080601
                    m_dwEatItemTick = HUtil32.GetTickCount();
                    if ((this.m_nCopyHumanLevel > 0))
                    {
                        if (this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate) / 100)
                        {
                            n01 = 0;
                            while (this.m_WAbil.HP < this.m_WAbil.MaxHP) // ������������ƿ
                            {
                                if ((n01 >= 1)) // �ĳ�һ��һƿ
                                {
                                    break;
                                }
                                btItemType = 0;
                                if (AutoEatUseItems(btItemType))
                                {
                                    boFound = true;
                                }
                                if (this.m_ItemList.Count == 0)
                                {
                                    break;
                                }
                                n01++;
                            }
                        }
                        if (this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate) / 100)
                        {
                            n01 = 0;
                            while (this.m_WAbil.MP < this.m_WAbil.MaxMP)
                            {
                                // ������������ƿ
                                if ((n01 >= 1))
                                {
                                    break;
                                }
                                // 20080401 �ĳ�һ��һƿ
                                btItemType = 1;
                                if (AutoEatUseItems(btItemType))
                                {
                                    boFound = true;
                                }
                                if (this.m_ItemList.Count == 0)
                                {
                                    break;
                                }
                                n01++;
                            }
                        }
                    }
                }

                if ((HUtil32.GetTickCount() - m_dwEatItemTick1) > GameConfig.nHeroAddHPMPTick1)
                {
                    // Ӣ�۳�����ҩ��� 20080910

                    m_dwEatItemTick1 = HUtil32.GetTickCount();
                    if ((this.m_nCopyHumanLevel > 0) && (this.m_ItemList.Count > 0))
                    {
                        if ((this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate1) / 100) || (this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate1) / 100))
                        {
                            btItemType = 2;
                            if (AutoEatUseItems(btItemType))
                            {
                                boFound = true;
                            }
                        }
                    }
                }
            }
            if (!boFound)
            {

                // 30 * 1000
                if ((HUtil32.GetTickCount() - m_dwEatItemNoHintTick) > 30000)
                {
                    // 20080129
                    m_dwEatItemNoHintTick = HUtil32.GetTickCount();
                    switch (btItemType)
                    {
                        case 0:
                            if ((this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate) / 100) || (this.m_WAbil.HP < (this.m_WAbil.MaxHP * GameConfig.nHeroAddHPRate1) / 100))
                            {
                                if (!EatMedicine_FoundItem(btItemType))
                                {
                                    SysMsg("(Ӣ��) ��ҩ�Ѿ����꣡����", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                        case 1:
                            if ((this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate) / 100) || (this.m_WAbil.MP < (this.m_WAbil.MaxMP * GameConfig.nHeroAddMPRate1) / 100))
                            {
                                if (!EatMedicine_FoundItem(btItemType))
                                {
                                    SysMsg("(Ӣ��) ħ��ҩ�Ѿ����꣡����", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// ���ָ������ͷ�Χ������Ĺ�������
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <param name="nDir"></param>
        /// <param name="nRange"></param>
        /// <returns></returns>
        private int CheckTargetXYCountOfDirection(int nX, int nY, int nDir, int nRange)
        {
            int result;
            TBaseObject BaseObject;
            int I;
            result = 0;
            if (this.m_VisibleActors.Count > 0)
            {
                // 20080630
                for (I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = ((TBaseObject)(((TVisibleBaseObject)(this.m_VisibleActors[I])).BaseObject));
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                switch (nDir)
                                {
                                    case Grobal2.DR_UP:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_RIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNRIGHT:
                                        if (((BaseObject.m_nCurrX - nX) >= 0 && (BaseObject.m_nCurrX - nX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWN:
                                        if ((Math.Abs(nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_DOWNLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((nY - BaseObject.m_nCurrY) >= 0 && (nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_LEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && (Math.Abs(nY - BaseObject.m_nCurrY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                    case Grobal2.DR_UPLEFT:
                                        if (((nX - BaseObject.m_nCurrX) >= 0 && (nX - BaseObject.m_nCurrX) <= nRange) && ((BaseObject.m_nCurrY - nY) >= 0 && (BaseObject.m_nCurrY - nY) <= nRange))
                                        {
                                            result++;
                                        }
                                        break;
                                }
                                // if Result > 2 then break;
                            }
                        }
                    }
                }
            }
            return result;
        }

        // ���ָ������ͷ�Χ������Ĺ�������
        // ���ָ������ͷ�Χ��,Ŀ����Ӣ�۵ľ��� 20080426
        private int CheckMasterXYOfDirection(TBaseObject TargeTBaseObject, int nX, int nY, int nDir, int nRange)
        {
            int result;
            result = 0;
            if (TargeTBaseObject != null)
            {
                if (!TargeTBaseObject.m_boDeath)
                {
                    switch (nDir)
                    {
                        case Grobal2.DR_UP:
                            if ((Math.Abs(nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((TargeTBaseObject.m_nCurrY - nY) >= 0 && (TargeTBaseObject.m_nCurrY - nY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_UPRIGHT:
                            if (((TargeTBaseObject.m_nCurrX - nX) >= 0 && (TargeTBaseObject.m_nCurrX - nX) <= nRange) && ((TargeTBaseObject.m_nCurrY - nY) >= 0 && (TargeTBaseObject.m_nCurrY - nY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_RIGHT:
                            if (((TargeTBaseObject.m_nCurrX - nX) >= 0 && (TargeTBaseObject.m_nCurrX - nX) <= nRange) && (Math.Abs(nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_DOWNRIGHT:
                            if (((TargeTBaseObject.m_nCurrX - nX) >= 0 && (TargeTBaseObject.m_nCurrX - nX) <= nRange) && ((nY - TargeTBaseObject.m_nCurrY) >= 0 && (nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_DOWN:
                            if ((Math.Abs(nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((nY - TargeTBaseObject.m_nCurrY) >= 0 && (nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_DOWNLEFT:
                            if (((nX - TargeTBaseObject.m_nCurrX) >= 0 && (nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((nY - TargeTBaseObject.m_nCurrY) >= 0 && (nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_LEFT:
                            if (((nX - TargeTBaseObject.m_nCurrX) >= 0 && (nX - TargeTBaseObject.m_nCurrX) <= nRange) && (Math.Abs(nY - TargeTBaseObject.m_nCurrY) <= nRange))
                            {
                                result++;
                            }
                            break;
                        case Grobal2.DR_UPLEFT:
                            if (((nX - TargeTBaseObject.m_nCurrX) >= 0 && (nX - TargeTBaseObject.m_nCurrX) <= nRange) && ((TargeTBaseObject.m_nCurrY - nY) >= 0 && (TargeTBaseObject.m_nCurrY - nY) <= nRange))
                            {
                                result++;
                            }
                            break;
                    }
                }
            }
            return result;
        }

        // �Զ���ҩ
        private bool WarrAttackTarget(ushort wHitMode)
        {
            bool result;
            // ������
            byte bt06 = 0;
            byte nCode;
            uint dwDelayTime;
            result = false;
            nCode = 0;
            try
            {
                nCode = 1;
                if (this.m_TargetCret != null)
                {
                    nCode = 2;
                    if (this.GetAttackDir(this.m_TargetCret, ref bt06))
                    {
                        nCode = 3;

                        this.m_dwTargetFocusTick = HUtil32.GetTickCount();
                        nCode = 4;
                        Attack(this.m_TargetCret, bt06);
                        m_dwActionTick = HUtil32.GetTickCount();
                        nCode = 5;
                        this.BreakHolySeizeMode();
                        result = true;
                    }
                    else
                    {
                        nCode = 6;
                        if (this.m_TargetCret.m_PEnvir == this.m_PEnvir)
                        {
                            nCode = 7;
                            SetTargetXY(this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY);
                        }
                        else
                        {
                            nCode = 8;
                            if (!m_boTarget)
                            {
                                DelTargetCreat();
                            }
                            // 20080424 ����������Ŀ��,����ɾ��Ŀ��
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.WarrAttackTarget Code:" + (nCode).ToString());
            }
            return result;
        }

        /// <summary>
        /// սʿ����
        /// </summary>
        /// <returns></returns>
        private unsafe bool WarrorAttackTarget()
        {
            bool result;
            TUserMagic* UserMagic;
            result = false;
            if (m_btStatus != 0)
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            m_wHitMode = 0;
            if (this.m_WAbil.MP > 0)
            {
                if (!m_boStartUseSpell && ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.3)) || this.m_TargetCret.m_boCrazyMode))
                {
                    // ����ѭ��ȫΪ��ʱ
                    if (IsAllowUseMagic(12) && (this.m_nBatterOrder[0] == 0))  // Ѫ��ʱ��Ŀ����ģʽʱ������λ��ɱ
                    {
                        GetGotoXY(this.m_TargetCret, 2);
                        GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                    }
                }
                if (!m_boStartUseSpell)
                {
                    SearchMagic();
                }
                // ��ѯħ�� 20080328����
                if (m_nSelectMagic > 0)
                {
                    if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 5) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 5)))
                    {
                        // ħ�����ܴ򵽹�
                        if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7))
                        {
                            this.m_TargetCret = null;
                            return result;
                        }
                        // else RunToTargetXY(m_TargetCret.m_nCurrX, m_TargetCret.m_nCurrY);//20080720 ע��
                    }
                    UserMagic = FindMagic(m_nSelectMagic);
                    if ((UserMagic != null))
                    {
                        if ((UserMagic->btKey == 0))
                        {
                            switch (m_nSelectMagic)
                            {
                                // ���ܴ�״̬����ʹ�� 20080606
                                // Modify the A .. B: 27, 39, 41, 60 .. 65, 68, 75
                                case 27:
                                case 39:
                                case 41:
                                case 60:
                                case 68:
                                case 75:
                                    this.m_dwHitTick = HUtil32.GetTickCount();
                                    result = ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// սʿħ��
                                    return result;
                                case 7:// ��ɱ
                                    m_wHitMode = 3;
                                    break;
                                case 12:// ʹ�ô�ɱ
                                    m_wHitMode = 4;
                                    break;
                                case 25:// ʹ�ð���
                                    m_wHitMode = 5;
                                    break;
                                case 26:// ʹ���һ�
                                    m_wHitMode = 7;
                                    break;
                                case 40:// ���µ���
                                    m_wHitMode = 8;
                                    break;
                                case 43:// ����ն  
                                    m_wHitMode = 9;
                                    break;
                                case 42:// ��Ӱ���� 
                                    m_wHitMode = 12;
                                    break;
                                case 74:// ���ս���
                                    m_wHitMode = 13;
                                    break;
                            }
                        }
                    }
                }
            }
            if (!m_boStartUseSpell)
            {
                result = WarrAttackTarget(m_wHitMode);
            }
            if (result)
            {
                this.m_dwHitTick = HUtil32.GetTickCount();
            }
            return result;
        }

        /// <summary>
        /// ��ʦ����
        /// </summary>
        /// <returns></returns>
        private unsafe bool WizardAttackTarget()
        {
            bool result;
            TUserMagic* UserMagic;
            result = false;
            if (m_btStatus != 0)
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            m_wHitMode = 0;
            if (!m_boStartUseSpell)
            {
                SearchMagic();
                // ��ѯħ��
                if (m_nSelectMagic == 0)
                {
                    m_boIsUseMagic = true; // �Ƿ��ܶ��
                }
            }
            if (m_nSelectMagic > 0)
            {
                if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))
                {
                    // ħ�����ܴ򵽹�
                    if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7))
                    {
                        m_nSelectMagic = 0;
                        this.m_TargetCret = null;
                        return result;
                    }
                    else
                    {
                        if (m_nSelectMagic != 10)
                        {
                            // �������Ӱ��
                            GetGotoXY(this.m_TargetCret, 3);
                            // ����ֻ����Ŀ��3��Χ
                            GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                        }
                    }
                }
                UserMagic = FindMagic((ushort)m_nSelectMagic);
                if ((UserMagic != null))
                {
                    if ((UserMagic->btKey == 0)) // ���ܴ�״̬����ʹ��
                    {
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        result = ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// ʹ��ħ��
                        return result;
                    }
                }
            }
            this.m_dwHitTick = HUtil32.GetTickCount();
            if (GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22))//��ʦ22��ǰ�Ƿ�������
            {
                m_boIsUseMagic = false;// �Ƿ��ܶ��
                result = WarrAttackTarget(m_wHitMode);
            }
            return result;
        }

        /// <summary>
        /// ��ʿ����
        /// </summary>
        /// <returns></returns>
        private unsafe bool TaoistAttackTarget()
        {
            bool result;
            TUserMagic* UserMagic;
            result = false;
            if (m_btStatus != 0)
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            m_wHitMode = 0;
            if (!m_boStartUseSpell)
            {
                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)) // 22����Ѫ���Ĺ�
                {
                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                    {
                        SearchMagic();// ��ѯħ��
                    }
                    else
                    {
                        if ((HUtil32.GetTickCount() - m_dwSearchMagic > 1300))// ��ѯħ���ļ��
                        {
                            SearchMagic();// ��ѯħ��
                            m_dwSearchMagic = HUtil32.GetTickCount();
                        }
                    }
                }
                else
                {
                    SearchMagic(); // ��ѯħ��
                }
                if (m_nSelectMagic == 0)
                {
                    m_boIsUseMagic = true;// �Ƿ��ܶ�� 
                }
            }
            if (m_nSelectMagic > 0)
            {
                if ((!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret)) || ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) > 7) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) > 7)))
                {
                    // ħ�����ܴ򵽹�
                    if ((Math.Abs(this.m_Master.m_nCurrX - this.m_nCurrX) >= 7) || (Math.Abs(this.m_Master.m_nCurrY - this.m_nCurrY) >= 7))
                    {
                        m_nSelectMagic = 0;
                        this.m_TargetCret = null;
                        return result;
                    }
                    else
                    {
                        if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                        {
                            // 22����Ѫ���Ĺ�
                            if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                            {
                                GetGotoXY(this.m_TargetCret, 3);//����ֻ����Ŀ��3��Χ
                                GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                            }
                        }
                        else
                        {
                            GetGotoXY(this.m_TargetCret, 3);// ����ֻ����Ŀ��3��Χ
                            GotoTargetXY(m_nTargetX, m_nTargetY, 0);
                        }
                    }
                }
                switch (m_nSelectMagic)
                {
                    case MagicConst.SKILL_HEALLING:// ������
                        if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // ���ܴ�״̬����ʹ�� 
                                ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22����Ѫ���Ĺ�
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;// �ܶ��
                                        return result;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// �ܶ��
                                    return result;
                                }
                            }
                        }
                        if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // ���ܴ�״̬����ʹ��
                                ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, null);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22����Ѫ���Ĺ�
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;
                                        // �ܶ��
                                        return result;
                                    }
                                    else
                                    {
                                        m_nSelectMagic = 0;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// �ܶ��
                                    return result;
                                }
                            }
                        }
                        break;
                    case MagicConst.SKILL_BIGHEALLING:// Ⱥ�������� 
                        if ((this.m_Master.m_WAbil.HP <= HUtil32.Round(this.m_Master.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // ���ܴ�״̬����ʹ��
                                ClientSpellXY(UserMagic, this.m_Master.m_nCurrX, this.m_Master.m_nCurrY, this.m_Master);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22����Ѫ���Ĺ�
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;// �ܶ��
                                        return result;
                                    }
                                    else
                                    {
                                        m_nSelectMagic = 0;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// �ܶ��
                                    return result;
                                }
                            }
                        }
                        if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.7)))
                        {
                            UserMagic = FindMagic((ushort)m_nSelectMagic);
                            if ((UserMagic != null) && (UserMagic->btKey == 0))
                            {
                                // ���ܴ�״̬����ʹ��
                                ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                                this.m_dwHitTick = HUtil32.GetTickCount();
                                if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                                {
                                    // 22����Ѫ���Ĺ�
                                    if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                    {
                                        m_boIsUseMagic = true;// �ܶ��
                                        return result;
                                    }
                                    else
                                    {
                                        m_nSelectMagic = 0;
                                    }
                                }
                                else
                                {
                                    m_boIsUseMagic = true;// �ܶ��
                                    return result;
                                }
                            }
                        }
                        break;
                    case MagicConst.SKILL_FIRECHARM:// ������,�򲻵�Ŀ��ʱ,�ƶ�
                        if (!this.MagCanHitTarget(this.m_nCurrX, this.m_nCurrY, this.m_TargetCret))
                        {
                            GetGotoXY(this.m_TargetCret, 3);
                            GotoTargetXY(m_nTargetX, m_nTargetY, 1);
                        }
                        break;
                    case MagicConst.SKILL_AMYOUNSUL:
                    case MagicConst.SKILL_GROUPAMYOUNSUL:// ����
                        if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DECHEALTH] == 0) && (GetUserItemList(2, 1) >= 0))// �̶�
                        {
                            n_AmuletIndx = 1;//  �̶���ʶ
                        }
                        else if ((this.m_TargetCret.m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] == 0) && (GetUserItemList(2, 2) >= 0))// �춾
                        {
                            n_AmuletIndx = 2;//  �춾��ʶ
                        }
                        break;
                    case MagicConst.SKILL_CLOAK:
                    case MagicConst.SKILL_BIGCLOAK:// ����������  ������
                        UserMagic = FindMagic((ushort)m_nSelectMagic);
                        if ((UserMagic != null) && (UserMagic->btKey == 0))
                        {
                            // ���ܴ�״̬����ʹ��
                            ClientSpellXY(UserMagic, this.m_nCurrX, this.m_nCurrY, this);
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                // 22����Ѫ���Ĺ�
                                if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                {
                                    m_boIsUseMagic = false;// �ܶ��
                                    return result;
                                }
                                else
                                {
                                    m_nSelectMagic = 0;
                                }
                            }
                            else
                            {
                                m_boIsUseMagic = false;// �ܶ��
                                return result;
                            }
                        }
                        break;
                    case MagicConst.SKILL_48:
                    case MagicConst.SKILL_SKELLETON:
                    case MagicConst.SKILL_SINSU:
                    case MagicConst.SKILL_50:
                    case MagicConst.SKILL_72:
                    case MagicConst.SKILL_73:
                    case MagicConst.SKILL_75:// ������ʱ�������ж��
                        UserMagic = FindMagic((ushort)m_nSelectMagic);
                        if ((UserMagic != null) && (UserMagic->btKey == 0))
                        {
                            ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);
                            // ʹ��ħ��
                            this.m_dwHitTick = HUtil32.GetTickCount();
                            if (GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT))
                            {
                                // 22����Ѫ���Ĺ�
                                if ((this.m_TargetCret.m_WAbil.MaxHP >= 700))
                                {
                                    m_boIsUseMagic = true;// �ܶ��
                                    return result;
                                }
                                else
                                {
                                    m_nSelectMagic = 0;
                                }
                            }
                            else
                            {
                                m_boIsUseMagic = true;// �ܶ��
                                return result;
                            }
                        }
                        break;
                }
                UserMagic = FindMagic((ushort)m_nSelectMagic);
                if ((UserMagic != null))
                {
                    if ((UserMagic->btKey == 0)) // ���ܴ�״̬����ʹ��
                    {
                        result = ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);// ʹ��ħ��
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        if ((this.m_TargetCret.m_WAbil.MaxHP >= 700) || (!GameConfig.boHeroAttackTao))
                        {
                            return result;
                        }
                    }
                }
            }
            this.m_dwHitTick = HUtil32.GetTickCount();
            if ((this.m_WAbil.HP <= HUtil32.Round(this.m_WAbil.MaxHP * 0.15)))
            {
                m_boIsUseMagic = true;
            }
            // �Ƿ��ܶ��
            if ((GameConfig.boHeroAttackTarget && (this.m_Abil.Level < 22)) || ((this.m_TargetCret.m_WAbil.MaxHP < 700) && GameConfig.boHeroAttackTao && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (this.m_TargetCret.m_btRaceServer != Grobal2.RC_HEROOBJECT)))
            {
                // ��ʿ22��ǰ�Ƿ�������  �ֵȼ�С��Ӣ��ʱ
                m_boIsUseMagic = false;// �Ƿ��ܶ��
                result = WarrAttackTarget(m_wHitMode);
            }
            return result;
        }

        // �Ƿ���Ҫ���
        private unsafe TUserMagic* CheckUserMagic(ushort wMagIdx)
        {
            TUserMagic* result;
            int I;
            result = null;
            if (this.m_MagicList.Count > 0)
            {
                for (I = 0; I < this.m_MagicList.Count; I++)
                {
                    if (((TUserMagic*)(this.m_MagicList[I]))->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = ((TUserMagic*)(this.m_MagicList[I]));
                        break;
                    }
                }
            }
            return result;
        }

        // ���ʹ��ħ��
        private int CheckTargetXYCount(int nX, int nY, int nRange)
        {
            int result;
            TBaseObject BaseObject;
            int I;
            int nC;
            int n10;
            result = 0;
            n10 = nRange;
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = ((TBaseObject)(((TVisibleBaseObject)(this.m_VisibleActors[I])).BaseObject));
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                nC = Math.Abs(nX - BaseObject.m_nCurrX) + Math.Abs(nY - BaseObject.m_nCurrY);
                                if (nC <= n10)
                                {
                                    result++;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // սʿ�ж�ʹ��
        private int CheckTargetXYCount1(int nX, int nY, int nRange)
        {
            int result;
            TBaseObject BaseObject;
            int I;
            int n10;
            result = 0;
            n10 = nRange;
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    BaseObject = ((TBaseObject)(((TVisibleBaseObject)(this.m_VisibleActors[I])).BaseObject));
                    if (BaseObject != null)
                    {
                        if (!BaseObject.m_boDeath)
                        {
                            if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                            {
                                if ((Math.Abs(nX - BaseObject.m_nCurrX) <= n10) && (Math.Abs(nY - BaseObject.m_nCurrY) <= n10))
                                {
                                    result++;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        // �����䵶�ж�Ŀ�꺯��
        private int CheckTargetXYCount2()
        {
            int result;
            int nC;
            int n10;
            int I;
            int nX = 0;
            int nY = 0;
            TBaseObject BaseObject = null;
            result = 0;
            nC = 0;
            if (this.m_VisibleActors.Count > 0)
            {
                for (I = 0; I < this.m_VisibleActors.Count; I++)
                {
                    n10 = (this.m_btDirection + GameConfig.WideAttack[nC]) % 8;
                    if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, n10, 1, ref nX, ref nY))
                    {
                        //BaseObject = this.m_PEnvir.GetMovingObject(nX, nY, true);
                        if (BaseObject != null)
                        {
                            if (!BaseObject.m_boDeath)
                            {
                                if (this.IsProperTarget(BaseObject) && (!BaseObject.m_boHideMode || this.m_boCoolEye))
                                {
                                    result++;
                                }
                            }
                        }
                    }
                    nC++;
                    if (nC >= 3)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        // �����Ʒ����
        private unsafe bool CheckItemType(int nItemType, TStdItem* StdItem, int nItemShape)
        {
            bool result;
            result = false;
            switch (nItemType)
            {
                case 1:
                    if ((StdItem->StdMode == 25) && (StdItem->Shape == 5))
                    {
                        result = true;
                    }
                    break;
                case 2:
                    switch (nItemShape)
                    {
                        case 1:
                            if ((StdItem->StdMode == 25) && (StdItem->Shape == 1))
                            {
                                result = true;
                            }
                            break;
                        case 2:
                            if ((StdItem->StdMode == 25) && (StdItem->Shape == 2))
                            {
                                result = true;
                            }
                            break;
                    }
                    break;
            }
            return result;
        }

        // �ж�װ�������Ƿ���ָ�����͵���Ʒ
        private unsafe bool CheckUserItemType(int nItemType, int nItemShape)
        {
            bool result;
            TStdItem* StdItem;
            result = false;
            if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                if ((StdItem != null))
                {
                    switch (nItemType)
                    {
                        case 1:
                            if (this.m_UseItems[TPosition.U_ARMRINGL]->Dura >= nItemShape * 100)
                            {
                                result = CheckItemType(nItemType, StdItem, nItemShape);
                            }
                            break;
                        case 2:
                            result = CheckItemType(nItemType, StdItem, nItemShape);
                            break;
                    }
                }
            }
            return result;
        }

        private unsafe bool UseItem(int nItemType, int nIndex, int nItemShape)
        {
            bool result;
            // �Զ�������
            TUserItem* UserItem;
            TUserItem* AddUserItem;
            TStdItem* StdItem;
            result = false;
            if ((nIndex >= 0) && (nIndex < this.m_ItemList.Count))
            {
                UserItem = (TUserItem*)this.m_ItemList[nIndex];
                // U_BUJUK
                if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
                {
                    // U_BUJUK
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                    if (StdItem != null)
                    {
                        switch (nItemType)
                        {
                            case 1:
                                // U_BUJUK
                                if (CheckItemType(nItemType, StdItem, nItemShape) && (this.m_UseItems[TPosition.U_ARMRINGL]->Dura >= nItemShape * 100))
                                {
                                    result = true;
                                }
                                else
                                {
                                    this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                                    AddUserItem = this.m_UseItems[TPosition.U_ARMRINGL];
                                    if (AddItemToBag(AddUserItem)) // U_BUJUK
                                    {
                                        this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                                        SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, AddUserItem);
                                        Marshal.FreeHGlobal((IntPtr)UserItem);
                                        //Dispose(UserItem);
                                        result = true;
                                    }
                                    else
                                    {
                                        this.m_ItemList.Add((IntPtr)UserItem);
                                    }
                                }
                                break;
                            case 2:
                                if (CheckItemType(nItemType, StdItem, nItemShape))
                                {
                                    result = true;
                                }
                                else
                                {
                                    this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                                    AddUserItem = this.m_UseItems[TPosition.U_ARMRINGL];
                                    if (AddItemToBag(AddUserItem))
                                    {
                                        // U_BUJUK
                                        this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                                        SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, AddUserItem);
                                        Marshal.FreeHGlobal((IntPtr)UserItem);
                                        //Dispose(UserItem);
                                        result = true;
                                    }
                                    else
                                    {
                                        this.m_ItemList.Add((IntPtr)UserItem);
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                        this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                        SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, null);
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                        //Dispose(UserItem);
                        result = true;
                    }
                }
                else
                {
                    this.m_ItemList.RemoveAt(nIndex);// U_BUJUK
                    this.m_UseItems[TPosition.U_ARMRINGL] = UserItem;
                    SendChangeItems(TPosition.U_ARMRINGL, TPosition.U_ARMRINGL, UserItem, null);
                    Marshal.FreeHGlobal((IntPtr)UserItem);
                    //Dispose(UserItem);
                    result = true;
                }
            }
            return result;
        }

        // ���������Ƿ��з��Ͷ�
        // nType Ϊָ������ 1 Ϊ����� 2 Ϊ��ҩ  ��Ϊ��,�� nItemShape ��ʾ���ĳ־�,��ʱ,1-�̶�,2-�춾
        private unsafe int GetUserItemList(int nItemType, int nItemShape)
        {
            int result;
            int I;
            TUserItem* UserItem;
            TStdItem* StdItem;
            result = -1;
            if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                if ((StdItem != null) && (StdItem->StdMode == 25))
                {
                    switch (nItemType)
                    {
                        case 1:
                            if ((StdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nItemShape))
                            {
                                result = 1;
                                return result;
                            }
                            break;
                        case 2:
                            switch (nItemShape)
                            {
                                case 1:
                                    if (StdItem->Shape == 1)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if (StdItem->Shape == 2)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
            if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                if ((StdItem != null) && (StdItem->StdMode == 25))
                {
                    switch (nItemType)
                    {
                        case 1:
                            // ��
                            if ((StdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nItemShape))
                            {
                                result = 1;
                                return result;
                            }
                            break;
                        case 2:
                            switch (nItemShape)
                            {
                                case 1:
                                    // ��
                                    if (StdItem->Shape == 1)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if (StdItem->Shape == 2)
                                    {
                                        result = 1;
                                        return result;
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
            for (I = this.m_ItemList.Count - 1; I >= 0; I--)
            {
                if (this.m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = (TUserItem*)this.m_ItemList[I];
                StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                if (StdItem != null)
                {
                    if (CheckItemType(nItemType, StdItem, nItemShape))
                    {
                        if (UserItem->Dura < 100)
                        {
                            this.m_ItemList.RemoveAt(I);
                            continue;
                        }
                        switch (nItemType)
                        {
                            case 1:
                                if (UserItem->Dura >= nItemShape * 100)
                                {
                                    result = I;
                                    break;
                                }
                                break;
                            case 2:
                                switch (nItemShape)
                                {
                                    case 1:
                                        if (StdItem->Shape == 1)
                                        {
                                            result = I;
                                            break;
                                        }
                                        break;
                                    case 2:
                                        if (StdItem->Shape == 2)
                                        {
                                            result = I;
                                            break;
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// ����Ŀ��
        /// </summary>
        /// <returns></returns>
        public bool AttackTarget()
        {
            bool result = false;
            uint dwAttackTime = 0;
            if (this.m_boUseBatter)
            {
                return result;
            }
            if (m_btStatus != 0)// ���治���
            {
                if (this.m_TargetCret != null)
                {
                    this.m_TargetCret = null;
                }
                return result;
            }
            if (this.InSafeZone() && (this.m_TargetCret != null)) // Ӣ�۽��밲ȫ���ھͲ���PKĿ��
            {
                if ((this.m_TargetCret.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (this.m_TargetCret.m_btRaceServer == Grobal2.RC_HEROOBJECT))
                {
                    this.m_TargetCret = null;
                    return result;
                }
            }
            this.m_dwTargetFocusTick = HUtil32.GetTickCount();
            switch (this.m_btJob)
            {
                case 0:
                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWarrorAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);// ��ֹ��������  +�ٶ� 
                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime) || m_boStartUseSpell)
                    {
                        m_boIsUseMagic = false;// �Ƿ��ܶ��
                        result = WarrorAttackTarget();
                    }
                    break;
                case 1:
                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroWizardAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);// ��ֹ��������  +�ٶ�
                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime) || m_boStartUseSpell)
                    {
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        m_boIsUseMagic = false;// �Ƿ��ܶ��
                        result = WizardAttackTarget();
                        return result;
                    }
                    m_nSelectMagic = 0;
                    break;
                case 2:
                    dwAttackTime = (uint)HUtil32._MAX(0, ((int)GameConfig.dwHeroTaoistAttackTime) - this.m_nHitSpeed * GameConfig.ClientConf.btItemSpeed);// ��ֹ��������  +�ٶ�
                    if ((HUtil32.GetTickCount() - this.m_dwHitTick > dwAttackTime) || m_boStartUseSpell)
                    {
                        this.m_dwHitTick = HUtil32.GetTickCount();
                        m_boIsUseMagic = false;// �Ƿ��ܶ��
                        result = TaoistAttackTarget();
                        return result;
                    }
                    m_nSelectMagic = 0;
                    break;
            }
            return result;
        }

        // ���ָ������ͷ�Χ��,������Ӣ�۵ľ���
        private unsafe void SearchMagic()
        {
            TUserMagic* UserMagic;
            m_nSelectMagic = 0;
            m_nSelectMagic = SelectMagic();
            if (m_nSelectMagic > 0)
            {
                UserMagic = FindMagic((ushort)m_nSelectMagic);
                if (UserMagic != null)
                {
                    m_boIsUseAttackMagic = IsUseAttackMagic();   // ��Ҫ������ħ��
                }
                else
                {
                    m_boIsUseAttackMagic = false;
                }
            }
            else
            {
                m_boIsUseAttackMagic = false;
            }
        }

        private bool IsSearchTarget()
        {
            bool result = false;
            if ((this.m_TargetCret != null))
            {
                if ((this.m_TargetCret == this))
                {
                    this.m_TargetCret = null;
                }
            }
            // 8000
            if ((this.m_TargetCret == null) && ((HUtil32.GetTickCount() - this.m_dwSearchEnemyTick) > 400) && (m_btStatus == 0))
            {
                this.m_dwSearchEnemyTick = HUtil32.GetTickCount();
                result = true;
                return result;
            }
            return result;
        }

        // �����Ʒ�Ƿ�Ϊ����֮��
        public unsafe bool WearFirDragon()
        {
            bool result;
            TStdItem* StdItem;
            result = false;
            if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
            {
                StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                if ((StdItem != null) && (StdItem->StdMode == 25) && (StdItem->Shape == 9))
                {
                    result = true;
                }
            }
            return result;
        }

        // �޲�����֮��    btType:2--����  4--Ӣ��
        public unsafe void RepairFirDragon(byte btType, int nItemIdx, string sItemName)
        {
            int I;
            int n14;
            TUserItem* UserItem = null;
            TStdItem* StdItem;
            string sUserItemName;
            bool boRepairOK;
            IList<IntPtr> ItemList;
            int OldDura;
            boRepairOK = false;
            ItemList = null;
            StdItem = null;
            n14 = -1;
            OldDura = 0;
            if ((this.m_Master != null) && WearFirDragon())
            {
                if (this.m_UseItems[TPosition.U_BUJUK]->Dura < this.m_UseItems[TPosition.U_BUJUK]->DuraMax)
                {
                    OldDura = this.m_UseItems[TPosition.U_BUJUK]->Dura;
                    switch (btType)
                    {
                        case 2:
                            ItemList = this.m_Master.m_ItemList;
                            break;
                        case 4:
                            ItemList = this.m_ItemList;
                            break;
                    }
                    if (ItemList != null)
                    {
                        if (ItemList.Count > 0)
                        {
                            // 20080630
                            for (I = 0; I < ItemList.Count; I++)
                            {
                                UserItem = (TUserItem*)ItemList[I];
                                if ((UserItem != null) && (UserItem->MakeIndex == nItemIdx))
                                {
                                    // ȡ�Զ�����Ʒ����
                                    sUserItemName = "";
                                    if (UserItem->btValue[13] == 1)
                                    {
                                        sUserItemName = ItemUnit.GetCustomItemName(UserItem->MakeIndex, UserItem->wIndex);
                                    }
                                    if (sUserItemName == "")
                                    {
                                        sUserItemName = UserEngine.GetStdItemName(UserItem->wIndex);
                                    }
                                    StdItem = UserEngine.GetStdItem(UserItem->wIndex);
                                    if (StdItem != null)
                                    {
                                        if ((sUserItemName).ToLower().CompareTo((sItemName).ToLower()) == 0)
                                        {
                                            n14 = I;
                                            break;
                                        }
                                    }
                                }
                                UserItem = null;
                            }
                        }
                        if ((StdItem != null) && (UserItem != null) && (StdItem->StdMode == 42))
                        {
                            this.m_UseItems[TPosition.U_BUJUK]->Dura += UserItem->DuraMax;
                            if (this.m_UseItems[TPosition.U_BUJUK]->Dura > this.m_UseItems[TPosition.U_BUJUK]->DuraMax)
                            {
                                this.m_UseItems[TPosition.U_BUJUK]->Dura = this.m_UseItems[TPosition.U_BUJUK]->DuraMax;
                            }
                            boRepairOK = true;
                            switch (btType)
                            {
                                case 2:
                                    this.m_Master.DelBagItem(n14);
                                    break;
                                case 4:
                                    this.DelBagItem(n14);
                                    break;
                            }
                        }
                    }
                }
            }
            if (boRepairOK)
            {
                if (OldDura != this.m_UseItems[TPosition.U_BUJUK]->Dura)
                {
                    SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_BUJUK, this.m_UseItems[TPosition.U_BUJUK]->Dura, this.m_UseItems[TPosition.U_BUJUK]->DuraMax, 0, "");
                }
                SendDefMessage(Grobal2.SM_REPAIRFIRDRAGON_OK, btType, 0, 0, 0, "");
            }
            else
            {
                SendDefMessage(Grobal2.SM_REPAIRFIRDRAGON_FAIL, btType, 0, 0, 0, "");
                SysMsg("�޲�����֮��ʧ��!", TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                // 20071231
            }
        }

        /// <summary>
        /// ����Ŀ��
        /// </summary>
        /// <param name="BaseObject"></param>
        /// <param name="nCode">���ٷ�Χ��2-7</param>
        /// <returns></returns>
        public bool GetGotoXY(TBaseObject BaseObject, byte nCode)
        {
            bool result = false;
            switch (nCode)
            {
                case 2:// ��ɱλ
                    if ((this.m_nCurrX - 2 <= BaseObject.m_nCurrX) && (this.m_nCurrX + 2 >= BaseObject.m_nCurrX) && (this.m_nCurrY - 2 <= BaseObject.m_nCurrY) && (this.m_nCurrY + 2 >= BaseObject.m_nCurrY) && ((this.m_nCurrX != BaseObject.m_nCurrX) || (this.m_nCurrY != BaseObject.m_nCurrY)))
                    {
                        result = true;
                        if (((this.m_nCurrX - 2) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 2;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if (((this.m_nCurrX + 2) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 2;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY - 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY - 2;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY + 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY + 2;
                            return result;
                        }
                        if (((this.m_nCurrX - 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 2;
                            m_nTargetY = this.m_nCurrY - 2;
                            return result;
                        }
                        if (((this.m_nCurrX + 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 2;
                            m_nTargetY = this.m_nCurrY - 2;
                            return result;
                        }
                        if (((this.m_nCurrX - 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 2;
                            m_nTargetY = this.m_nCurrY + 2;
                            return result;
                        }
                        if (((this.m_nCurrX + 2) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 2) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 2;
                            m_nTargetY = this.m_nCurrY + 2;
                            return result;
                        }
                    }
                    break;
                case 3:// 3��
                    if ((this.m_nCurrX - 3 <= BaseObject.m_nCurrX) && (this.m_nCurrX + 3 >= BaseObject.m_nCurrX) && (this.m_nCurrY - 3 <= BaseObject.m_nCurrY) && (this.m_nCurrY + 3 >= BaseObject.m_nCurrY) && ((this.m_nCurrX != BaseObject.m_nCurrX) || (this.m_nCurrY != BaseObject.m_nCurrY)))
                    {
                        result = true;
                        if (((this.m_nCurrX - 3) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 3;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if (((this.m_nCurrX + 3) == BaseObject.m_nCurrX) && (this.m_nCurrY == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 3;
                            m_nTargetY = this.m_nCurrY;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY - 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY - 3;
                            return result;
                        }
                        if ((this.m_nCurrX == BaseObject.m_nCurrX) && ((this.m_nCurrY + 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX;
                            m_nTargetY = this.m_nCurrY + 3;
                            return result;
                        }
                        if (((this.m_nCurrX - 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 3;
                            m_nTargetY = this.m_nCurrY - 3;
                            return result;
                        }
                        if (((this.m_nCurrX + 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY - 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 3;
                            m_nTargetY = this.m_nCurrY - 3;
                            return result;
                        }
                        if (((this.m_nCurrX - 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX - 3;
                            m_nTargetY = this.m_nCurrY + 3;
                            return result;
                        }
                        if (((this.m_nCurrX + 3) == BaseObject.m_nCurrX) && ((this.m_nCurrY + 3) == BaseObject.m_nCurrY))
                        {
                            m_nTargetX = this.m_nCurrX + 3;
                            m_nTargetY = this.m_nCurrY + 3;
                            return result;
                        }
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// ˢ��Ӣ������������
        /// </summary>
        public override void RecalcAbilitys()
        {
            base.RecalcAbilitys();
            if (this.m_btRaceServer == Grobal2.RC_HEROOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_CHARSTATUSCHANGED, this.m_nHitSpeed, this.m_nCharStatus, 0, 0, "");
                RecalcAdjusBonus();
            }
        }

        // Ӣ������   ����Ӣ������  ���ﱻ���� Ӣ���Զ�ǿ���ٻ�  
        public unsafe override void Die()
        {
            int nDecExp;
            base.Die();
            try
            {
                // ����������,���鲻��,�򽵼�
                if (GameConfig.boHeroDieExp)
                {
                    GetLevelExp(m_Abil.Level);
                    nDecExp = (int)HUtil32.Round((double)this.m_Abil.Exp * (GameConfig.nHeroDieExpRate / 100));
                    // �����о����һ������ 20090108
                    SysMsg("(Ӣ��) �������侭��ֵ������ " + (nDecExp).ToString(), TMsgColor.c_Red, TMsgType.t_Hint);
                    if (this.m_Abil.Exp >= nDecExp)
                    {
                        this.m_Abil.Exp -= (uint)nDecExp;
                    }
                    else
                    {
                        this.m_Abil.Exp = 0;
                    }
                }
                // �޸��ջ�֮���ٻ������󻹿������ٻ�Ӣ��
                if ((this.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (this.m_Master != null) && (((TPlayObject)(this.m_Master)).m_MyHero == this))
                {
                    // ����Ӣ��������Ϣ
                    ((TPlayObject)(this.m_Master)).m_nRecallHeroTime = HUtil32.GetTickCount();// �ٻ�Ӣ�ۼ�� 
                    m_nLoyal = HUtil32._MAX(0, m_nLoyal - GameConfig.nDeathDecLoyal);// ���������ҳ϶� 
                    UserEngine.SaveHeroRcd(((TPlayObject)(this.m_Master)));// ��������  
                    ((TPlayObject)(this.m_Master)).m_MyHero = null;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ����ħ��
        /// </summary>
        /// <param name="wMagIdx"></param>
        /// <returns></returns>
        public unsafe TUserMagic* FindMagic(int wMagIdx)
        {
            TUserMagic* result = null;
            TUserMagic* UserMagic;
            if (this.m_MagicList.Count > 0)
            {
                for (int I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if (UserMagic->MagicInfo.wMagicId == wMagIdx)
                    {
                        result = UserMagic;
                        break;
                    }
                }
            }
            return result;
        }

        public unsafe int CheckTakeOnItems_GetUserItemWeitht(int nWhere)
        {
            int result;
            int I;
            int n14;
            TStdItem* StdItem;
            n14 = 0;
            for (I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
            {
                if ((nWhere == -1) || (!(I == nWhere) && !(I == 1) && !(I == 2)))
                {
                    StdItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                    if (StdItem != null)
                    {
                        n14 += StdItem->Weight;
                    }
                }
            }
            result = n14;
            return result;
        }

        /// <summary>
        /// Ӣ�ۼ�鴩��װ��������
        /// </summary>
        /// <param name="nWhere"></param>
        /// <param name="StdItem"></param>
        /// <returns></returns>
        public unsafe bool CheckTakeOnItems(int nWhere, TStdItem* StdItem)
        {
            bool result = false;
            TUserCastle Castle;
            if ((StdItem->StdMode == 10) && (this.m_btGender != 0))
            {
                SysMsg("(Ӣ��) " + GameMsgDef.sWearNotOfWoMan, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                return result;
            }
            if ((StdItem->StdMode == 11) && (this.m_btGender != 1))
            {
                SysMsg("(Ӣ��) " + GameMsgDef.sWearNotOfMan, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                return result;
            }
            if ((nWhere == 1) || (nWhere == 2))
            {
                if (StdItem->Weight > this.m_WAbil.MaxHandWeight)
                {
                    SysMsg("(Ӣ��) " + GameMsgDef.sHandWeightNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    return result;
                }
            }
            else
            {
                if ((StdItem->Weight + CheckTakeOnItems_GetUserItemWeitht(nWhere)) > this.m_WAbil.MaxWearWeight)
                {
                    SysMsg("(Ӣ��) " + GameMsgDef.sWearWeightNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    return result;
                }
            }
            Castle = M2Share.g_CastleManager.IsCastleMember(this);
            switch (StdItem->Need)
            {
                case 34:
                case 0:
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 35:
                case 1:
                    if (HUtil32.HiWord(this.m_WAbil.DC) >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sDCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 10:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (this.m_Abil.Level >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sJobOrLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 11:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sJobOrDCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 12:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sJobOrMCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 13:
                    if ((this.m_btJob == HUtil32.LoWord(StdItem->NeedLevel)) && (HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sJobOrSCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 36:
                case 2:

                    if (HUtil32.HiWord(this.m_WAbil.MC) >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 37:
                case 3:

                    if (HUtil32.HiWord(this.m_WAbil.SC) >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sSCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 4:
                    if (m_btReLevel >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 18:
                    // Need=18(��ʾ������ȼ���װ������������ָ��ٶ�) NeedLevel=50(�ȼ�����) Stock=3(��������ָ��ٶ�)
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        // m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 19:
                    // Need=19(��ʾ�����蹥������װ������������ָ��ٶ�%) NeedLevel=50(����������) Stock=3(��������ָ��ٶ�%)
                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Price);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 20:
                    // Need=20(��ʾ������ħ����װ������������ָ��ٶ�%) NeedLevel=50(ħ������) Stock=3(��������ָ��ٶ�%)


                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 21:
                    // Need=21(��ʾ�����������װ������������ָ��ٶ�%) NeedLevel=50(��������) Stock=3(��������ָ��ٶ�%)


                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        //m_dwIncAddNHTick = m_dwIncAddNHTick + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 22:
                    // Need=22(��ʾ������ȼ���װ������������ָ��ٶ�+��) NeedLevel=50(�ȼ�����) Stock=3(ÿ�ο��������ֵ)
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        //m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 23:
                    // Need=23(��ʾ�����蹥������װ������������ָ��ٶ�+��) NeedLevel=50(����������) Stock=3(ÿ�ο��������ֵ)


                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 24:
                    // Need=24(��ʾ������ħ����װ������������ָ��ٶ�+��) NeedLevel=50(ħ������) Stock=3(ÿ�ο��������ֵ)


                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 25:
                    // Need=25(��ʾ�����������װ������������ָ��ٶ�+��) NeedLevel=50(��������) Stock=3(ÿ�ο��������ֵ)


                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        // m_dwIncAddNHPoint = m_dwIncAddNHPoint + HUtil32._MIN(65535, StdItem->Stock);
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 26:
                    // ======��Ʒ֧�ַ�����������=============//
                    // Need-(26)��ȼ���Stock-Ϊ������ NeedLevel-����ȼ�
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 27:
                    // Need-(27)�蹥������Stock-Ϊ������ NeedLevel-���蹥����


                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 28:
                    // Need-(28)��ħ����Stock-Ϊ������ NeedLevel-����ħ��
                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 29:
                    // Need-(29)�������Stock-Ϊ������ NeedLevel-�������
                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 30:
                    // ===========��������Ѫ���� Need==============//
                    // Need-(30)��ȼ���Stock-Ϊ��Ѫ�� NeedLevel-����ȼ�  Reserved-�ɹ�����
                    if (this.m_Abil.Level >= StdItem->NeedLevel)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sLevelNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 31:
                    // Need-(31)�蹥������Stock-Ϊ��Ѫ�� NeedLevel-���蹥����  Reserved-�ɹ�����
                    if ((HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sDCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 32:
                    // Need-(32)��ħ����Stock-Ϊ��Ѫ�� NeedLevel-����ħ��  Reserved-�ɹ�����
                    if ((HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 33:
                    // Need-(33)�������Stock-Ϊ��Ѫ�� NeedLevel-�������  Reserved-�ɹ�����
                    if ((HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sSCNot, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                    break;
                case 40:
                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {
                        if (this.m_Abil.Level >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(Ӣ��) " + GameMsgDef.g_sLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 41:

                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {
                        if (HUtil32.HiWord(this.m_WAbil.DC) >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(Ӣ��) " + GameMsgDef.g_sDCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 42:
                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {
                        if (HUtil32.HiWord(this.m_WAbil.MC) >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(Ӣ��) " + GameMsgDef.g_sMCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 43:

                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel))
                    {


                        if (HUtil32.HiWord(this.m_WAbil.SC) >= HUtil32.HiWord(StdItem->NeedLevel))
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(Ӣ��) " + GameMsgDef.g_sSCNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 44:
                    if (m_btReLevel >= HUtil32.LoWord(StdItem->NeedLevel)) // ����װ��,������
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sReNewLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 5:
                    result = true;
                    break;
                case 6:
                    if ((this.m_MyGuild != null))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sGuildNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 60:
                    if ((this.m_MyGuild != null) && (this.m_nGuildRankNo == 1))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sGuildMasterNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 7:
                    if ((this.m_MyGuild != null) && (Castle != null))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sSabukHumanNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 70:
                    if ((this.m_MyGuild != null) && (Castle != null) && (this.m_nGuildRankNo == 1))
                    {
                        if (this.m_Abil.Level >= StdItem->NeedLevel)
                        {
                            result = true;
                        }
                        else
                        {
                            SysMsg("(Ӣ��) " + GameMsgDef.g_sLevelNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                        }
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sSabukMasterManNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 8:
                    if (m_nMemberType != 0)
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMemberNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 81:
                    if ((m_nMemberType == HUtil32.LoWord(StdItem->NeedLevel)) && (m_nMemberLevel >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMemberTypeNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
                case 82:
                    if ((m_nMemberType >= HUtil32.LoWord(StdItem->NeedLevel)) && (m_nMemberLevel >= HUtil32.HiWord(StdItem->NeedLevel)))
                    {
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��) " + GameMsgDef.g_sMemberTypeNot, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
                    }
                    break;
            }
            return result;
        }

        /// <summary>
        /// ȡ�������ĵ�MPֵ(ħ��ֵ)
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public unsafe int GetSpellPoint(TUserMagic* UserMagic)
        {
            int result = (int)HUtil32.Round((double)UserMagic->MagicInfo.wSpell / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1)) + UserMagic->MagicInfo.btDefSpell;
            return result;
        }

        public unsafe bool DoMotaebo_CanMotaebo(TBaseObject BaseObject, int nMagicLevel)
        {
            bool result;
            int nC;
            result = false;
            if ((this.m_Abil.Level > BaseObject.m_Abil.Level) && (!BaseObject.m_boStickMode))
            {
                nC = this.m_Abil.Level - BaseObject.m_Abil.Level;
                if (HUtil32.Random(20) < ((nMagicLevel * 4) + 6 + nC))
                {
                    if (this.IsProperTarget(BaseObject))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        // Ӣ�۽���Ұ����ײ
        private unsafe bool DoMotaebo(byte nDir, int nMagicLevel)
        {
            bool result;
            bool bo35;
            int I;
            int n20;
            int n24;
            int n28;
            TBaseObject PoseCreate;
            TBaseObject BaseObject_30;
            TBaseObject BaseObject_34;
            int nX = 0;
            int nY = 0;
            result = false;
            bo35 = true;
            this.m_btDirection = nDir;
            BaseObject_34 = null;
            n24 = nMagicLevel + 1;
            n28 = n24;
            PoseCreate = this.GetPoseCreate();
            if (PoseCreate != null)
            {
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I++)
                {
                    PoseCreate = this.GetPoseCreate();
                    if (PoseCreate != null)
                    {
                        n28 = 0;
                        if (!DoMotaebo_CanMotaebo(PoseCreate, nMagicLevel))
                        {
                            break;
                        }
                        if (nMagicLevel >= 3)
                        {
                            if (this.m_PEnvir.GetNextPosition(this.m_nCurrX, this.m_nCurrY, this.m_btDirection, 2, ref nX, ref nY))
                            {
                                //BaseObject_30 = this.m_PEnvir.GetMovingObject(nX, nY, true);
                                //if ((BaseObject_30 != null) && DoMotaebo_CanMotaebo(BaseObject_30))
                                //{
                                //    BaseObject_30.CharPushed(this.m_btDirection, 1);
                                //}
                            }
                        }
                        BaseObject_34 = PoseCreate;
                        if (PoseCreate.CharPushed(this.m_btDirection, 1) != 1)
                        {
                            break;
                        }
                        this.GetFrontPosition(ref nX, ref nY);
                        if (this.m_PEnvir.MoveToMovingObject(this.m_nCurrX, this.m_nCurrY, this, nX, nY, false) > 0)
                        {
                            this.m_nCurrX = nX;
                            this.m_nCurrY = nY;
                            this.SendRefMsg(Grobal2.RM_RUSH, nDir, this.m_nCurrX, this.m_nCurrY, 0, "");
                            bo35 = false;
                            result = true;
                        }
                        n24 -= 1;
                    }
                }
            }
            else
            {
                bo35 = false;
                for (I = 0; I <= HUtil32._MAX(2, nMagicLevel + 1); I++)
                {
                    this.GetFrontPosition(ref nX, ref nY);
                    if (this.m_PEnvir.MoveToMovingObject(this.m_nCurrX, this.m_nCurrY, this, nX, nY, false) > 0)
                    {
                        this.m_nCurrX = nX;
                        this.m_nCurrY = nY;
                        this.SendRefMsg(Grobal2.RM_RUSH, nDir, this.m_nCurrX, this.m_nCurrY, 0, "");
                        n28 -= 1;
                    }
                    else
                    {
                        if (this.m_PEnvir.CanWalk(nX, nY, true))
                        {
                            n28 = 0;
                        }
                        else
                        {
                            bo35 = true;
                            break;
                        }
                    }
                }
            }
            if ((BaseObject_34 != null))
            {
                if (n24 < 0)
                {
                    n24 = 0;
                }
                n20 = HUtil32.Random((n24 + 1) * 10) + ((n24 + 1) * 10);
                n20 = BaseObject_34.GetHitStruckDamage(this, n20);
                BaseObject_34.StruckDamage(n20);
                BaseObject_34.SendRefMsg(Grobal2.RM_STRUCK, n20, BaseObject_34.m_WAbil.HP, BaseObject_34.m_WAbil.MaxHP, HUtil32.ObjectToInt(this), "");
                if (BaseObject_34.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                {
                    BaseObject_34.SendMsg(BaseObject_34, Grobal2.RM_STRUCK, n20, BaseObject_34.m_WAbil.HP, BaseObject_34.m_WAbil.MaxHP, HUtil32.ObjectToInt(this), "");
                }
            }
            if (bo35)
            {
                this.GetFrontPosition(ref nX, ref nY);
                this.SendRefMsg(Grobal2.RM_RUSHKUNG, this.m_btDirection, nX, nY, 0, "");// ��ײ������������
                SysMsg("(Ӣ��) " + GameMsgDef.sMateDoTooweak, TMsgColor.BB_Fuchsia, TMsgType.t_Hint);
            }
            if (n28 > 0)
            {
                if (n24 < 0)
                {
                    n24 = 0;
                }
                n20 = HUtil32.Random(n24 * 10) + ((n24 + 1) * 3);
                n20 = this.GetHitStruckDamage(this, n20);
                StruckDamage(n20);
                this.SendRefMsg(Grobal2.RM_STRUCK, n20, this.m_WAbil.HP, this.m_WAbil.MaxHP, 0, "");
            }
            return result;
        }

        /// <summary>
        /// Ӣ��ʹ�ü���
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <param name="nTargetX"></param>
        /// <param name="nTargetY"></param>
        /// <param name="TargeTBaseObject"></param>
        /// <returns></returns>
        public unsafe bool ClientSpellXY(TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject TargeTBaseObject)
        {
            bool result;
            int nSpellPoint = 0;
            int n14;
            TBaseObject BaseObject;
            uint dwCheckTime;
            uint dwDelayTime;
            bool boIsWarrSkill;
            const string sDisableMagicCross = "��ǰ��ͼ������ʹ�ã�{0}";
            result = false;
            if (UserMagic == null)
            {
                return result;
            }
            this.m_nCurrBatterMagicID = 0;
            if (!this.m_boUseBatter)
            {
                if (!m_boCanSpell)
                {
                    return result;
                }
            }
            // ������ʹ��ħ����������ʹ��������
            this.m_nCurrBatterMagicID = UserMagic->wMagIdx;
            if (this.m_boDeath || ((this.m_wStatusTimeArr[Grobal2.POISON_STONE] != 0) && !GameConfig.ClientConf.boParalyCanSpell))
            {
                return result;
            }
            // ����
            if (this.m_PEnvir != null)
            {
                if (!this.m_PEnvir.AllowMagics(HUtil32.SBytePtrToString(UserMagic->MagicInfo.sMagicName, 0, UserMagic->MagicInfo.MagicNameLen)))
                {
                    SysMsg(string.Format(sDisableMagicCross, HUtil32.SBytePtrToString(UserMagic->MagicInfo.sMagicName, 0, UserMagic->MagicInfo.MagicNameLen)), TMsgColor.BB_Fuchsia, TMsgType.t_Notice);
                    return result;
                }
            }
            boIsWarrSkill = MagicManager.IsWarrSkill(UserMagic->wMagIdx);// �Ƿ���սʿ����
            if (!boIsWarrSkill)
            {
                dwCheckTime = HUtil32.GetTickCount() - m_dwMagicAttackTick;
                if (dwCheckTime < m_dwMagicAttackInterval)
                {
                    m_dwMagicAttackCount++;
                    dwDelayTime = m_dwMagicAttackInterval - dwCheckTime;
                    if (dwDelayTime > GameConfig.dwHeroMagicHitIntervalTime / 3)
                    {
                        if (m_dwMagicAttackCount >= 2)
                        {
                            m_dwMagicAttackTick = HUtil32.GetTickCount();
                            m_dwMagicAttackCount = 0;
                        }
                        else
                        {
                            m_dwMagicAttackCount = 0;
                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            this.m_nSpellTick -= 450;
            this.m_nSpellTick = HUtil32._MAX(0, this.m_nSpellTick);
            if (boIsWarrSkill)
            {
                m_dwMagicAttackInterval = UserMagic->MagicInfo.dwDelayTime;
            }
            else
            {
                m_dwMagicAttackInterval = UserMagic->MagicInfo.dwDelayTime + GameConfig.dwHeroMagicHitIntervalTime;
            }
            if (HUtil32.GetTickCount() - m_dwMagicAttackTick > m_dwMagicAttackInterval)// Ӣ��ħ�����
            {
                m_dwMagicAttackTick = HUtil32.GetTickCount();
                switch (UserMagic->wMagIdx)
                {
                    case MagicConst.SKILL_YEDO:// ��ɱ����
                        if (this.m_MagicPowerHitSkill != null)
                        {
                            if (this.m_boPowerHit)
                            {
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_ERGUM:// ��ɱ����
                        if (this.m_MagicErgumSkill != null)
                        {
                            if (!this.m_boUseThrusting)
                            {
                                this.ThrustingOnOff(true);
                            }
                            else
                            {
                                this.ThrustingOnOff(false);
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_BANWOL:// �����䵶
                        if (this.m_MagicBanwolSkill != null)
                        {
                            if (!this.m_boUseHalfMoon)
                            {
                                this.HalfMoonOnOff(true);
                            }
                            else
                            {
                                this.HalfMoonOnOff(false);
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_FIRESWORD:// �һ𽣷�
                        if (this.m_MagicFireSwordSkill != null)
                        {
                            if (this.AllowFireHitSkill())
                            {
                                nSpellPoint = GetSpellPoint(UserMagic);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_74:
                        // //���ս��� 20080511
                        if (this.m_Magic74Skill != null)
                        {
                            if (this.AllowDailySkill())
                            {
                                nSpellPoint = GetSpellPoint(this.m_Magic74Skill);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        // HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        break;
                    case MagicConst.SKILL_MOOTEBO:
                        // 27
                        // Ұ����ײ
                        result = true;

                        // 3 * 1000
                        if ((HUtil32.GetTickCount() - m_dwDoMotaeboTick) > 3000)
                        {

                            m_dwDoMotaeboTick = HUtil32.GetTickCount();
                            // m_btDirection := TargeTBaseObject.m_btDirection{nTargetX};//20080409 �޸�Ұ����ײ�ķ���
                            if (this.GetAttackDir(TargeTBaseObject, ref this.m_btDirection))
                            {
                                // 20080409 �޸�Ұ����ײ�ķ���
                                nSpellPoint = GetSpellPoint(UserMagic);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                    if (DoMotaebo(this.m_btDirection, UserMagic->btLevel))
                                    {
                                        if (UserMagic->btLevel < 3)
                                        {
                                            if (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] < this.m_Abil.Level)
                                            {
                                                this.TrainSkill(UserMagic, HUtil32.Random(3) + 1);
                                                if (!this.CheckMagicLevelup(UserMagic))
                                                {
                                                    SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 1000);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case MagicConst.SKILL_40:
                        // ˫��ն ���µ���
                        if (this.m_MagicCrsSkill != null)
                        {
                            if (!this.m_boCrsHitkill)
                            {
                                this.SkillCrsOnOff(true);
                            }
                            else
                            {
                                this.SkillCrsOnOff(false);
                            }
                        }
                        result = true;
                        break;
                    case 43:
                        // ����ն
                        if (this.m_Magic42Skill != null)
                        {
                            if (this.Skill42OnOff())
                            {
                                nSpellPoint = GetSpellPoint(UserMagic);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        break;
                    case 42:
                        // ��Ӱ����
                        if (this.m_Magic43Skill != null)
                        {
                            if (this.Skill43OnOff())
                            {
                                // 20080619
                                nSpellPoint = GetSpellPoint(UserMagic);
                                if (this.m_WAbil.MP >= nSpellPoint)
                                {
                                    if (nSpellPoint > 0)
                                    {
                                        this.DamageSpell(nSpellPoint);
                                        this.HealthSpellChanged();
                                    }
                                }
                            }
                        }
                        result = true;
                        break;
                    default:
                        n14 = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, nTargetX, nTargetY);
                        this.m_btDirection = (byte)n14;
                        BaseObject = null;
                        switch (UserMagic->wMagIdx)
                        {
                            // ���Ŀ���ɫ����Ŀ��������Χ���������Χ��������Ŀ������
                            // Modify the A .. B: 60 .. 65
                            case 60:
                                if (((this.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0) && (this.m_Master.m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)) || GameConfig.ClientConf.boParalyCanSpell)
                                {
                                    // ��Բ��ܺϻ�
                                    if (this.CretInNearXY(TargeTBaseObject, nTargetX, nTargetY, 12))
                                    {
                                        BaseObject = TargeTBaseObject;
                                        nTargetX = BaseObject.m_nCurrX;
                                        nTargetY = BaseObject.m_nCurrY;
                                        if (this.m_Master != null)
                                        {
                                            ((TPlayObject)(this.m_Master)).DoSpell(UserMagic, nTargetX, nTargetY, BaseObject); // �ϻ����˹���
                                        }
                                    }
                                }
                                else
                                {
                                    return result;
                                }
                                break;
                            default:
                                if (this.CretInNearXY(TargeTBaseObject, nTargetX, nTargetY))
                                {
                                    BaseObject = TargeTBaseObject;
                                    nTargetX = BaseObject.m_nCurrX;
                                    nTargetY = BaseObject.m_nCurrY;
                                }
                                break;
                        }
                        if (!DoSpell(UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            this.SendRefMsg(Grobal2.RM_MAGICFIREFAIL, 0, 0, 0, 0, "");// �������Ӣ�ۻ���ʧ
                        }
                        result = true;
                        break;
                }
                if (this.m_boUseBatter)
                {
                    this.m_boBatterFinally = true;
                }
            }
            return result;
        }

        public unsafe int GetHitMode(int MagicID)
        {
            int result = 0;
            switch (MagicID)
            {
                case 76:// ����ɱ
                    if ((this.m_MagicSkill_76 != null))
                    {
                        result = 14;
                    }
                    break;
                case 79:// ׷�Ĵ�
                    if ((this.m_MagicSkill_79 != null))
                    {
                        result = 15;
                    }
                    break;
                case 82:// ����ն
                    if ((this.m_MagicSkill_82 != null))
                    {
                        result = 16;
                    }
                    break;
                case 85:// ��ɨǧ��
                    if ((this.m_MagicSkill_85 != null))
                    {
                        result = 17;
                    }
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        public void ClientUseBatter_ExitBatter()
        {
            this.m_boUseBatter = false;
            m_boCanSpell = true;
            m_boCanHit = true;
            m_boCanRun = true;
            m_boCanWalk = true;
        }

        public unsafe void ClientUseBatter_GetRandomOrder()
        {
            int I;
            int J;
            ArrayList List = null;
            TUserMagic* UserMagic;
            try
            {
                for (I = 0; I <= 2; I++)
                {
                    this.bOrder[I] = this.m_nBatterOrder[I];
                }
                List = new ArrayList();
                for (I = 0; I < this.m_MagicList.Count; I++)
                {
                    UserMagic = (TUserMagic*)this.m_MagicList[I];
                    if ((UserMagic != null) && (HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, 0, UserMagic->MagicInfo.DescrLen) == "����") && (UserMagic->MagicInfo.btJob == this.m_btJob))
                    {
                        List.Add((UserMagic->wMagIdx as object));
                    }
                }
                for (I = List.Count - 1; I >= 0; I--)
                {
                    for (J = 0; J <= 2; J++)
                    {
                        if (((int)List[I]) == this.bOrder[J])
                        {
                            List.RemoveAt(I);
                            break;
                        }
                    }
                }
                for (I = 0; I <= 2; I++)
                {
                    if (this.bOrder[I] == 2222)
                    {
                        if (List.Count > 0)
                        {
                            J = HUtil32.Random(List.Count - 1);
                            if (J >= 0)
                            {
                                this.bOrder[I] = ((ushort)List[J]);
                                List.RemoveAt(J);
                            }
                        }
                    }
                }
            }
            finally
            {
                Dispose(List);
            }
        }

        /// <summary>
        /// ʹ������
        /// </summary>
        public unsafe void ClientUseBatter()
        {
            uint dwTime;
            TUserMagic* UserMagic;
            byte bt06 = 0;
            if (this.m_nBatter == 0)
            {
                ClientUseBatter_GetRandomOrder();
                this.m_nBatterSpellTick = HUtil32.GetTickCount() - 1500;
                this.m_boBatterFinally = true;
            }
            if ((HUtil32.GetTickCount() - this.m_nBatterSpellTick > 1200))
            {
                if ((this.bOrder[this.m_nBatter] == 0) || (this.m_nBatter > 2))
                {
                    ClientUseBatter_ExitBatter();
                    return;
                }
                this.m_nBatterSpellTick = HUtil32.GetTickCount();
                switch (this.m_btJob)
                {
                    case 0:
                    case 3:
                        if (this.m_TargetCret == null)
                        {
                            ClientUseBatter_ExitBatter();
                            return;
                        }
                        else
                        {
                            if (!this.GetAttackDir(this.m_TargetCret, ref bt06))
                            {
                                // ExitBatter();
                                return;
                            }
                        }
                        this.m_boBatterFinally = false;
                        this.m_nBatterUseTick = HUtil32.GetTickCount();
                        UserMagic = FindMagic(this.bOrder[this.m_nBatter]);
                        if (UserMagic != null)
                        {
                            ClientSpellXY(UserMagic, 0, 0, null);
                            m_wHitMode = (ushort)GetHitMode(UserMagic->wMagIdx);
                            if (m_wHitMode > 0)
                            {
                                Attack(this.m_TargetCret, bt06);
                            }
                            else
                            {
                                ClientUseBatter_ExitBatter();
                            }
                        }
                        else
                        {
                            ClientUseBatter_ExitBatter();
                        }
                        break;
                    case 1:
                    case 2:
                        this.m_boBatterFinally = false;
                        m_boCanWalk = false;
                        m_boCanRun = false;
                        m_boCanHit = false;
                        m_boCanSpell = false;
                        if ((this.m_TargetCret != null) && ((Math.Abs(this.m_TargetCret.m_nCurrX - this.m_nCurrX) <= 12) || (Math.Abs(this.m_TargetCret.m_nCurrY - this.m_nCurrY) <= 12)))
                        {
                            UserMagic = FindMagic(this.bOrder[this.m_nBatter]);
                            ClientSpellXY(UserMagic, this.m_TargetCret.m_nCurrX, this.m_TargetCret.m_nCurrY, this.m_TargetCret);
                        }
                        else
                        {
                            ClientUseBatter_ExitBatter();
                            return;
                        }
                        break;
                }
                this.m_nBatter++;
            }
        }

        public unsafe int DoSpell_MPow(TUserMagic* UserMagic)
        {
            int result;
            result = UserMagic->MagicInfo.wPower + HUtil32.Random(UserMagic->MagicInfo.wMaxPower - UserMagic->MagicInfo.wPower);
            return result;
        }

        public unsafe int DoSpell_GetPower(TUserMagic* UserMagic, int nPower)
        {
            int result;
            result = (int)HUtil32.Round((double)nPower / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1))
                + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower));
            return result;
        }

        public unsafe int DoSpell_GetPower13(TUserMagic* UserMagic, int nInt)
        {
            int result;
            double d10;
            double d18;
            d10 = nInt / 3.0;
            d18 = nInt - d10;
            result = (int)HUtil32.Round(d18 / (UserMagic->MagicInfo.btTrainLv + 1) * (UserMagic->btLevel + 1) + d10 + (UserMagic->MagicInfo.btDefPower + HUtil32.Random(UserMagic->MagicInfo.btDefMaxPower - UserMagic->MagicInfo.btDefPower)));
            return result;
        }

        public unsafe void DoSpell_sub_4934B4(TBaseObject PlayObject)
        {
            if (PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura < 100)
            {
                PlayObject.m_UseItems[TPosition.U_ARMRINGL]->Dura = 0;
                if (PlayObject.m_btRaceServer == Grobal2.RC_HEROOBJECT)
                {
                    ((PlayObject) as THeroObject).SendDelItems(PlayObject.m_UseItems[TPosition.U_ARMRINGL]);
                }
                PlayObject.m_UseItems[TPosition.U_ARMRINGL]->wIndex = 0;
            }
        }

        public unsafe bool DoSpell(TUserMagic* UserMagic, int nTargetX, int nTargetY, TBaseObject BaseObject)
        {
            bool result;
            bool boTrain;
            int nSpellPoint;
            bool boSpellFail;
            bool boSpellFire;
            int nPower;
            int nAmuletIdx;
            int nPowerRate;
            int nDelayTime;
            int nDelayTimeRate;
            uint dwDelayTime = 0;
            byte nCode;
            nCode = 0;
            result = false;
            boSpellFail = false;
            boSpellFire = true;
            nSpellPoint = GetSpellPoint(UserMagic);// ��Ҫ��ħ��ֵ
            if ((nSpellPoint > 0) && (UserMagic->wMagIdx != 68)) // ��� ��Ҫ��ħ��ֵ >0  �������岻�ڴ˴���HP
            {
                if (this.m_WAbil.MP < nSpellPoint)
                {
                    return result; // ���ħ��ֵ С�� ��Ҫ��ħ��ֵ ��ô�˳�
                }
                this.DamageSpell(nSpellPoint);// ��Ӣ�� ���� nSpellPoint mp
                this.HealthSpellChanged();
            }
            if (m_boTrainingNG)//ѧ���ڹ��ķ�,ÿ����һ�μ�һ������ֵ
            {
                m_Skill69NH = Convert.ToUInt16(HUtil32._MAX(0, m_Skill69NH - GameConfig.nHitStruckDecNH));
                this.SendRefMsg(Grobal2.RM_MAGIC69SKILLNH, 0, m_Skill69NH, m_Skill69MaxNH, 0, "");
            }
            nCode = 1;
            try
            {
                if (BaseObject != null)
                {
                    if ((BaseObject.m_boGhost) || (BaseObject.m_boDeath) || (BaseObject.m_WAbil.HP <= 0))
                    {
                        return result;
                    }
                }
                if (MagicManager.IsWarrSkill(UserMagic->wMagIdx))
                {
                    return result;
                }
                if ((Math.Abs(this.m_nCurrX - nTargetX) > GameConfig.nMagicAttackRage) || (Math.Abs(this.m_nCurrY - nTargetY) > GameConfig.nMagicAttackRage))
                {
                    return result;
                }
                nCode = 2;
                if ((!CheckActionStatus(UserMagic->MagicInfo.wMagicId, ref dwDelayTime)))
                {
                    return result;
                }
                if ((this.m_btJob == 0) && (UserMagic->MagicInfo.wMagicId == 61))
                {
                    //����նսʿЧ��
                    nCode = 20;
                    if (BaseObject != null)
                    {
                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
                    }
                    nCode = 21;
                    this.SendRefMsg(Grobal2.RM_MYSHOW, 5, 0, 0, 0, "");// ����սʿ������
                    this.SendAttackMsg(Grobal2.RM_PIXINGHIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY);
                }
                else if ((this.m_btJob == 0) && (UserMagic->MagicInfo.wMagicId == 62))//����һ��սʿЧ��
                {
                    nCode = 22;
                    if (BaseObject != null)
                    {
                        this.m_btDirection = M2Share.GetNextDirection(this.m_nCurrX, this.m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
                    }
                    nCode = 23;
                    this.SendAttackMsg(Grobal2.RM_LEITINGHIT, this.m_btDirection, this.m_nCurrX, this.m_nCurrY);
                }
                else
                {
                    switch (UserMagic->MagicInfo.wMagicId)
                    {
                        case 13:// 4�����ܷ���ͬ����Ϣ
                            if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))// 4�����
                            {
                                this.SendRefMsg(Grobal2.RM_SPELL, 100, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            else
                            {
                                this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            break;
                        case 26:
                            break;
                        case 45:
                            if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))
                            {
                                // �ļ������
                                this.SendRefMsg(Grobal2.RM_SPELL, 101, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            else
                            {
                                this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            }
                            break;
                        default:
                            // 0..12,14..25,27..44,46..100:
                            this.SendRefMsg(Grobal2.RM_SPELL, UserMagic->MagicInfo.btEffect, nTargetX, nTargetY, UserMagic->MagicInfo.wMagicId, "");
                            break;
                    }
                }

                nCode = 3;
                if ((BaseObject != null) && (UserMagic->MagicInfo.wMagicId != MagicConst.SKILL_57) && (UserMagic->MagicInfo.wMagicId != MagicConst.SKILL_54) && (UserMagic->MagicInfo.wMagicId < 100))
                {
                    if ((BaseObject.m_boDeath))
                    {
                        BaseObject = null;
                    }
                }
                boTrain = false;
                boSpellFail = false;
                boSpellFire = true;
                nCode = 4;
                switch (UserMagic->MagicInfo.wMagicId)
                {
                    case MagicConst.SKILL_FIREBALL:
                    case MagicConst.SKILL_FIREBALL2:// ������ �����
                        if (MagicManager.MagMakeFireball(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_HEALLING:// ������
                        if (MagicManager.MagTreatment(this, UserMagic, ref nTargetX, ref nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_AMYOUNSUL:// ʩ����
                        if (MagicManager.MagLightening(this, UserMagic, nTargetX, nTargetY, BaseObject, ref boSpellFail))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIREWIND:// ���ܻ�
                        if (MagicManager.MagPushArround(this, UserMagic->btLevel) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIRE:// ������
                        if (MagicManager.MagMakeHellFire(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SHOOTLIGHTEN:// �����Ӱ
                        if (MagicManager.MagMakeQuickLighting(this, UserMagic, ref nTargetX, ref nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_LIGHTENING:// �׵���
                        if (MagicManager.MagMakeLighting(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIRECHARM:
                    case MagicConst.SKILL_HANGMAJINBUB:
                    case MagicConst.SKILL_DEJIWONHO:
                    case MagicConst.SKILL_HOLYSHIELD:
                    case MagicConst.SKILL_SKELLETON:
                    case MagicConst.SKILL_CLOAK:
                    case MagicConst.SKILL_BIGCLOAK:
                    case MagicConst.SKILL_52:
                    case MagicConst.SKILL_57:
                    case MagicConst.SKILL_59:
                        boSpellFail = true;
                        //if (Magic.CheckAmulet(this, 1, 1, ref nAmuletIdx))
                        //{
                        //    Magic.UseAmulet(this, 1, 1, ref nAmuletIdx);
                        //    switch (UserMagic->MagicInfo.wMagicId)
                        //    {
                        //        case MagicConst.SKILL_FIRECHARM:
                        //            // 13
                        //            // �����
                        //            if (MagicManager.MagMakeFireCharm(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_HANGMAJINBUB:
                        //            // 14
                        //            // �����
                        //            nPower = this.GetAttackPower(DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                        //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 1) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_DEJIWONHO:
                        //            // 15
                        //            // ��ʥս����
                        //            nPower = this.GetAttackPower(DoSpell_GetPower13(UserMagic, 60) + HUtil32.LoWord(this.m_WAbil.SC) * 10, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                        //            if (this.MagMakeDefenceArea(nTargetX, nTargetY, 3, nPower, 0) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_HOLYSHIELD:
                        //            // 16
                        //            // ��ħ��
                        //            if (MagicManager.MagMakeHolyCurtain(this, DoSpell_GetPower13(UserMagic, 40) + Magic.GetRPow(this.m_WAbil.SC) * 3, nTargetX, nTargetY) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_SKELLETON:
                        //            // 17
                        //            // �ٻ�����
                        //            if (MagicManager.MagMakeSlave(this, UserMagic))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_CLOAK:
                        //            // 18
                        //            // ������
                        //            if (MagicManager.MagMakePrivateTransparent(this, DoSpell_GetPower13(UserMagic, 30) + Magic.GetRPow(this.m_WAbil.SC) * 3))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_BIGCLOAK:
                        //            // 19
                        //            // ����������
                        //            if (MagicManager.MagMakeGroupTransparent(this, nTargetX, nTargetY, DoSpell_GetPower13(UserMagic, 30) + Magic.GetRPow(this.m_WAbil.SC) * 3))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_52:
                        //            // ������
                        //            nPower = this.GetAttackPower(DoSpell_GetPower13(UserMagic, 20) + HUtil32.LoWord(this.m_WAbil.SC) * 2, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) + 1);
                        //            if (this.MagMakeAbilityArea(nTargetX, nTargetY, 3, nPower) > 0)
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_57:
                        //            // ������
                        //            if (MagicManager.MagMakeLivePlayObject(this, UserMagic, BaseObject))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //        case MagicConst.SKILL_59:
                        //            // ��Ѫ�� 20080511
                        //            if (MagicManager.MagFireCharmTreatment(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        //            {
                        //                boTrain = true;
                        //            }
                        //            break;
                        //    }
                        //    boSpellFail = false;
                        //    DoSpell_sub_4934B4(this);
                        //}
                        break;
                    case MagicConst.SKILL_TAMMING:
                        // 20
                        // �ջ�֮��
                        if (this.IsProperTarget(BaseObject))
                        {
                            if (MagicManager.MagTamming(this, BaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_SPACEMOVE:
                        // 21
                        // ˲Ϣ�ƶ�
                        //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                        boSpellFire = false;
                        if (MagicManager.MagSaceMove(this, UserMagic->btLevel))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_EARTHFIRE:
                        // 22
                        // ��ǽ
                        nPower = this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                        nDelayTime = DoSpell_GetPower(UserMagic, 10) + (((ushort)Magic.GetRPow(this.m_WAbil.MC)) >> 1);
                        nPowerRate = (int)HUtil32.Round((double)nPower * (GameConfig.nFirePowerRate / 100));
                        // ��ǽ��������
                        nDelayTimeRate = (int)HUtil32.Round((double)nDelayTime * (GameConfig.nFireDelayTimeRate / 100));
                        // ��ǽʱ��
                        if (MagicManager.MagMakeFireCross(this, nPowerRate, nDelayTimeRate, nTargetX, nTargetY) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_FIREBOOM:
                        // 23
                        // ���ѻ���
                        if (MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nFireBoomRage, MagicConst.SKILL_FIREBOOM))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_LIGHTFLOWER:
                        // 24
                        // �����׹�
                        if (MagicManager.MagElecBlizzard(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SHOWHP:// ������ʾ
                        if ((BaseObject != null) && !BaseObject.m_boShowHP)
                        {
                            if (HUtil32.Random(6) <= (UserMagic->btLevel + 3))
                            {
                                BaseObject.m_dwShowHPTick = HUtil32.GetTickCount();
                                //BaseObject.m_dwShowHPInterval = DoSpell_GetPower13(UserMagic, Magic.GetRPow(this.m_WAbil.SC) * 2 + 30) * 1000;
                                BaseObject.SendDelayMsg(BaseObject, Grobal2.RM_DOOPENHEALTH, 0, 0, 0, 0, "", 1500);
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_BIGHEALLING:// Ⱥ��������
                        nPower = this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.SC) * 2, ((short)HUtil32.HiWord(this.m_WAbil.SC) - HUtil32.LoWord(this.m_WAbil.SC)) * 2 + 1);
                        if (MagicManager.MagBigHealing(this, nPower + this.m_WAbil.Level, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_SINSU:// �ٻ�����
                        boSpellFail = true;
                        //if (Magic.CheckAmulet(this, 5, 1, ref nAmuletIdx))
                        //{
                        //    Magic.UseAmulet(this, 5, 1, ref nAmuletIdx);
                        //    if (MagicManager.MagMakeSinSuSlave(this, UserMagic))
                        //    {
                        //        boTrain = true;
                        //    }
                        //    boSpellFail = false;
                        //}
                        break;
                    case MagicConst.SKILL_SHIELD:
                    case MagicConst.SKILL_66:// ħ����,4��ħ����
                        if (this.MagBubbleDefenceUp(UserMagic->btLevel, (ushort)DoSpell_GetPower(UserMagic, Magic.GetRPow(this.m_WAbil.MC) + 15)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_73:// ������ 
                        if (this.MagBubbleDefenceUp(UserMagic->btLevel, (ushort)DoSpell_GetPower(UserMagic, Magic.GetRPow(this.m_WAbil.SC) + 15)))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_75:// �������
                        if ((HUtil32.GetTickCount() - this.m_boProtectionTick > GameConfig.dwProtectionTick))
                        {
                            if (this.MagProtectionDefenceUp(UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        else
                        {
                            return result;
                        }
                        break;
                    case MagicConst.SKILL_KILLUNDEAD:
                        // 32
                        // ʥ����
                        if (this.IsProperTarget(BaseObject))
                        {
                            if (MagicManager.MagTurnUndead(this, BaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_SNOWWIND:
                        // 33
                        // ������
                        if (MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nSnowWindRange, MagicConst.SKILL_SNOWWIND))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_UNAMYOUNSUL:
                        // 34
                        // �ⶾ��
                        if (MagicManager.MagMakeUnTreatment(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_WINDTEBO:
                        // 35
                        if (MagicManager.MagWindTebo(this, UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_MABE:
                        // 36
                        // �����
                        nPower = this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1);
                        if (MagicManager.MabMabe(this, BaseObject, nPower, UserMagic->btLevel, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPLIGHTENING:
                        // 37
                        // Ⱥ���׵���
                        if (MagicManager.MagGroupLightening(this, UserMagic, nTargetX, nTargetY, BaseObject, ref boSpellFire))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPAMYOUNSUL:
                        // 38
                        // Ⱥ��ʩ����
                        if (MagicManager.MagGroupAmyounsul(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_GROUPDEDING:
                        // 39
                        // �ض�
                        if (HUtil32.GetTickCount() - m_dwDedingUseTick > GameConfig.nDedingUseTime * 1000)
                        {
                            m_dwDedingUseTick = HUtil32.GetTickCount();
                            if (MagicManager.MagGroupDeDing(this, UserMagic, nTargetX, nTargetY, BaseObject))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_41:
                        // ʨ�Ӻ�
                        if (MagicManager.MagGroupMb(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_42:
                        // ����ն
                        if (MagicManager.MagHbFireBall(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_43:
                        // ��Ӱ����
                        if (MagicManager.MagHbFireBall(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_44:
                        // ������
                        if (MagicManager.MagHbFireBall(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_45:
                        // �����
                        if (MagicManager.MagMakeFireDay(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_46:
                        // boSpellFire:=False;//20080113
                        // ������
                        if (MagicManager.MagMakeSelf(this, BaseObject, UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_47:
                        // ��������
                        // 1
                        if (MagicManager.MagBigExplosion(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nFireBoomRage, MagicConst.SKILL_47))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_58:
                        // ���ǻ��� 20080510
                        if (MagicManager.MagBigExplosion1(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1), nTargetX, nTargetY, GameConfig.nMeteorFireRainRage))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_48:
                        // ��ʿ
                        // ������
                        if (MagicManager.MagPushArround(this, UserMagic->btLevel) > 0)
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_49:
                        // ������
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_50:
                        // �޼�����
                        if (AbilityUp(UserMagic))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_51:
                        // 쫷���
                        if (MagicManager.MagGroupFengPo(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_53:
                        // Ѫ��
                        boTrain = true;
                        break;
                    case MagicConst.SKILL_54:
                        // ������
                        if (this.IsProperTargetSKILL_54(BaseObject))
                        {
                            if (MagicManager.MagTamming2(this, BaseObject, nTargetX, nTargetY, UserMagic->btLevel))
                            {
                                boTrain = true;
                            }
                        }
                        break;
                    case MagicConst.SKILL_55:
                        // ������
                        if (MagicManager.MagMakeArrestObject(this, UserMagic, BaseObject))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_56:
                        // ���л�λ
                        if (MagicManager.MagChangePosition(this, nTargetX, nTargetY))
                        {
                            boTrain = true;
                        }
                        break;
                    case MagicConst.SKILL_68:
                        // Ӣ�۾������� 20080925
                        MagMakeHPUp(UserMagic);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_72:
                        // �ٻ�����
                        //if (Magic.CheckAmulet(this, 5, 1, ref nAmuletIdx))
                        //{
                        //    Magic.UseAmulet(this, 5, 1, ref nAmuletIdx);
                        //    if (MagicManager.MagMakeFairy(this, UserMagic))
                        //    {
                        //        boTrain = true;
                        //    }
                        //}
                        break;
                    case MagicConst.SKILL_60:
                        // �ƻ�ն  ս+ս
                        nCode = 5;
                        if (MagicManager.MagMakeSkillFire_60(this, UserMagic, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.DC), ((short)HUtil32.HiWord(this.m_WAbil.DC) - HUtil32.LoWord(this.m_WAbil.DC)) + 1) * 3))
                        {
                            boTrain = true;
                        }
                        nCode = 6;
                        break;
                    case MagicConst.SKILL_61:
                        // ����ն  ս+��
                        nCode = 7;
                        if (MagicManager.MagMakeSkillFire_61(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        nCode = 8;
                        break;
                    case MagicConst.SKILL_62:
                        // ����һ��  ս+��
                        nCode = 9;
                        if (MagicManager.MagMakeSkillFire_62(this, UserMagic, nTargetX, nTargetY, ref BaseObject))
                        {
                            boTrain = true;
                        }
                        // if m_btJob = 1 then boSpellFire := False;//20080611
                        nCode = 10;
                        break;
                    case MagicConst.SKILL_63:
                        // �ɻ�����  ��+��
                        nCode = 11;
                        if (MagicManager.MagMakeSkillFire_63(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        nCode = 12;
                        break;
                    case MagicConst.SKILL_64:
                        // ĩ������  ��+��
                        nCode = 13;
                        if (MagicManager.MagMakeSkillFire_64(this, UserMagic, nTargetX, nTargetY, BaseObject))
                        {
                            boTrain = true;
                        }
                        nCode = 14;
                        break;
                    case MagicConst.SKILL_65:
                        // ��������  ��+��
                        nCode = 15;
                        if (MagicManager.MagMakeSkillFire_65(this, this.GetAttackPower(DoSpell_GetPower(UserMagic, DoSpell_MPow(UserMagic)) + HUtil32.LoWord(this.m_WAbil.MC), ((short)HUtil32.HiWord(this.m_WAbil.MC) - HUtil32.LoWord(this.m_WAbil.MC)) + 1)))
                        {
                            boTrain = true;
                        }
                        nCode = 16;
                        break;
                    case MagicConst.SKILL_77:
                        // ˫���� ��ʦ
                        MagicManager.MagMakeSkillFire_77(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_78:
                        // ��Х�� ��ʿ
                        MagicManager.MagMakeSkillFire_78(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_80:
                        // ����� ��ʦ
                        MagicManager.MagMakeSkillFire_80(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_81:
                        // ������ ��ʿ
                        MagicManager.MagMakeSkillFire_81(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_83:
                        // ���ױ� ��ʦ
                        MagicManager.MagMakeSkillFire_83(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_84:
                        // ������ ��ʿ
                        MagicManager.MagMakeSkillFire_84(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_86:
                        // ����ѩ��   ��ʦ
                        MagicManager.MagMakeSkillFire_86(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    case MagicConst.SKILL_87:
                        // �򽣹���   ��ʿ
                        MagicManager.MagMakeSkillFire_87(this, UserMagic, nTargetX, nTargetY, BaseObject);
                        boTrain = false;
                        break;
                    default:
                        break;
                }
                nCode = 17;
                m_dwActionTick = HUtil32.GetTickCount();
                // 20080713
                this.m_dwHitTick = HUtil32.GetTickCount();
                // 20080713
                m_nSelectMagic = 0;
                m_boIsUseMagic = true;
                // �Ƿ��ܶ�� 20080714
                if (boSpellFail)
                {
                    return result;
                }
                nCode = 18;
                if (boSpellFire)
                {
                    // 20080111 ��4���ټ��ܲ�����Ϣ
                    try
                    {
                        switch (UserMagic->MagicInfo.wMagicId)
                        {
                            case 13:
                                // 20080113 ��4���ټ��ܲ�����Ϣ      20080227 �޸�
                                if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))
                                {
                                    // 4����� 20080111
                                    // this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 100), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                else
                                {
                                    // this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                break;
                            case 26:
                                break;
                            case 45:
                                if ((UserMagic->btLevel == 4) && (m_nLoyal >= GameConfig.nGotoLV4))
                                {
                                    // 20080227 �޸�
                                    //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, 101), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                else
                                {
                                    //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                }
                                break;
                            default:
                                // 0..12,14..25,27..44,46..100://20080324
                                //this.SendRefMsg(Grobal2.RM_MAGICFIRE, 0, MakeWord(UserMagic->MagicInfo.btEffectType, UserMagic->MagicInfo.btEffect), HUtil32.MakeLong(nTargetX, nTargetY), (int)BaseObject, "");
                                break;
                        }
                        // Case
                    }
                    catch
                    {
                    }
                }
                nCode = 19;
                if ((UserMagic->btLevel < 3) && boTrain)
                {
                    // ���ܼ���������
                    if (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] <= this.m_Abil.Level)
                    {
                        this.TrainSkill(UserMagic, HUtil32.Random(3) + 1);
                        if (!this.CheckMagicLevelup(UserMagic))
                        {
                            SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 1000);
                        }
                    }
                }
                result = true;
            }
            catch (Exception E)
            {
                M2Share.MainOutMessage(string.Format("{�쳣} THeroObject.DoSpell MagID:%d X:%d Y:%d Code:%d", UserMagic->wMagIdx, nTargetX, nTargetY, nCode));
            }
            return result;
        }

        /// <summary>
        /// ����Ӣ�۱�������
        /// </summary>
        /// <param name="HumanRcd"></param>
        public unsafe void MakeSaveRcd(THumDataInfo* HumanRcd)
        {
            THumData* HumData;
            TUserItem* HumItems;
            TUserItem* HumAddItems;
            TUserItem* BagItems;
            THumMagic* HumMagics;
            THumMagic* HumNGMagics;
            THumMagic* HumBatterMagics;
            TUserMagic* UserMagic;
            byte nCode;
            nCode = 0;
            try
            {
                HumanRcd->Header.boIsHero = true;
                HumanRcd->Header.btJob = this.m_btJob;
                HUtil32.StrToSByteArry(this.m_sCharName, HumanRcd->Header.sName, Grobal2.ACTORNAMELEN, ref HumanRcd->Header.NameLen);
                HumData = &HumanRcd->Data;
                HumData->m_btFHeroType = m_btMentHero;
                HUtil32.StrToSByteArry(this.m_sCharName, HumData->sChrName, Grobal2.ACTORNAMELEN, ref  HumData->ChrNameLen);
                HUtil32.StrToSByteArry(this.m_sMapName, HumData->sCurMap, Grobal2.MAPNAMELEN, ref  HumData->CurMapLen);
                HumData->wCurX = (ushort)this.m_nCurrX;
                HumData->wCurY = (ushort)this.m_nCurrY;
                HumData->btDir = this.m_btDirection;
                HumData->btHair = this.m_btHair;
                HumData->btSex = this.m_btGender;
                HumData->btJob = this.m_btJob;
                HumData->nGold = m_nFirDragonPoint;// �����������������ŭ��ֵ
                nCode = 1;
                HumData->Abil.Level = this.m_Abil.Level;
                HumData->Abil.HP = this.m_Abil.HP;
                HumData->Abil.MP = this.m_Abil.MP;
                HumData->Abil.MaxHP = this.m_Abil.MaxHP;
                HumData->Abil.MaxMP = this.m_Abil.MaxMP;
                HumData->Abil.Exp = (int)this.m_Abil.Exp;
                HumData->Abil.MaxExp = (int)this.m_Abil.MaxExp;
                HumData->Abil.Weight = this.m_Abil.Weight;
                HumData->Abil.MaxWeight = this.m_Abil.MaxWeight;
                HumData->Abil.WearWeight = (byte)this.m_Abil.WearWeight;
                HumData->Abil.MaxWearWeight = (byte)this.m_Abil.MaxWearWeight;
                HumData->Abil.HandWeight = (byte)this.m_Abil.HandWeight;
                HumData->Abil.MaxHandWeight = (byte)this.m_Abil.MaxHandWeight;
                nCode = 2;
                HumData->Abil.NG = (ushort)m_Skill69NH;// �ڹ���ǰ����ֵ
                HumData->Abil.MaxNG = (ushort)m_Skill69MaxNH;// ����ֵ����
                nCode = 3;
                HumData->n_Reserved = this.m_Abil.Alcohol;// ����
                HumData->n_Reserved1 = this.m_Abil.MaxAlcohol;// ��������
                HumData->n_Reserved2 = this.m_Abil.WineDrinkValue;// ��ƶ�
                HumData->btUnKnow2[2] = n_DrinkWineQuality;// ����ʱ�Ƶ�Ʒ��
                HumData->UnKnow[4] = (byte)n_DrinkWineAlcohol;// ����ʱ�ƵĶ��� 
                HumData->UnKnow[5] = (byte)this.m_btMagBubbleDefenceLevel;// ħ���ܵȼ�
                nCode = 4;
                HumData->nReserved1 = this.m_Abil.MedicineValue;// ��ǰҩ��ֵ 
                HumData->nReserved2 = this.m_Abil.MaxMedicineValue;// ҩ��ֵ���� 
                HumData->boReserved3 = n_DrinkWineDrunk;// ���Ƿ�Ⱦ����� 
                HumData->nReserved3 = dw_UseMedicineTime;// ʹ��ҩ��ʱ��,���㳤ʱ��ûʹ��ҩ�� 
                HumData->n_Reserved3 = n_MedicineLevel;// ҩ��ֵ�ȼ� 
                HumData->Abil.HP = this.m_WAbil.HP;
                HumData->Abil.MP = this.m_WAbil.MP;
                HumData->Exp68 = (int)m_Exp68; // �������嵱ǰ����
                HumData->MaxExp68 = (int)m_MaxExp68;// ����������������
                nCode = 5;
                HumData->UnKnow[6] = Convert.ToByte(m_boTrainingNG); // �Ƿ�ѧϰ���ڹ�
                if (m_boTrainingNG)
                {
                    HumData->UnKnow[7] = (byte)m_NGLevel;// �ڹ��ȼ�
                }
                else
                {
                    HumData->UnKnow[7] = 0;
                }
                HumData->nExpSkill69 = (int)m_ExpSkill69; // �ڹ���ǰ����
                nCode = 6;
                for (int i = 0; i < this.m_wStatusTimeArr.Length; i++)
                {
                    HumData->wStatusTimeArr[i] = this.m_wStatusTimeArr[i];
                }
                nCode = 13;
                HUtil32.StrToSByteArry(this.m_sHomeMap, HumData->sHomeMap, Grobal2.MAPNAMELEN, ref HumData->HomeMapLen);
                HumData->wHomeX = (ushort)this.m_nHomeX;
                HumData->wHomeY = (ushort)this.m_nHomeY;
                HumData->nPKPOINT = this.m_nPkPoint;
                nCode = 14;
                HumData->BonusAbil = this.m_BonusAbil;//Ӣ����������
                HumData->nBonusPoint = this.m_nBonusPoint;
                HumData->btCreditPoint = m_btCreditPoint;
                HumData->btReLevel = m_btReLevel;
                HumData->nLoyal = m_nLoyal; // Ӣ�۵��ҳ϶�
                HumData->n_WinExp = (int)this.m_nWinExp;// �������ۼƾ���
                nCode = 15;
                if (this.m_Master != null)
                {
                    HUtil32.StrToSByteArry(this.m_Master.m_sCharName, HumData->sMasterName, Grobal2.ACTORNAMELEN, ref  HumData->MasterNameLen);
                }
                nCode = 7;
                HumData->btAttatckMode = this.m_btAttatckMode;
                HumData->btIncHealth = (byte)this.m_nIncHealth;
                HumData->btIncSpell = (byte)this.m_nIncSpell;
                HumData->btIncHealing = (byte)this.m_nIncHealing;
                HumData->btFightZoneDieCount = (byte)this.m_nFightZoneDieCount;
                nCode = 8;
                HumData->btEF = n_HeroTpye;// Ӣ������ 0-������Ӣ�� 1-����Ӣ��
                HumData->dBodyLuck = this.m_dBodyLuck;
                HumData->btLastOutStatus = this.m_btLastOutStatus;//���� �˳�״̬ 1Ϊ�����˳�
                HUtil32.ByteArrayToBytePtr(HumData->QuestFlag, 128, this.m_QuestFlag);
                HumData->boHasHero = false;
                HumData->boIsHero = true;
                HumData->btStatus = m_btStatus;// ����Ӣ�۵�״̬
                nCode = 9;
                HumItems = (TUserItem*)HumanRcd->Data.BagItemsBuff;
                HumItems[TPosition.U_DRESS] = *this.m_UseItems[TPosition.U_DRESS];
                HumItems[TPosition.U_WEAPON] = *this.m_UseItems[TPosition.U_WEAPON];
                HumItems[TPosition.U_RIGHTHAND] = *this.m_UseItems[TPosition.U_RIGHTHAND];
                HumItems[TPosition.U_HELMET] = *this.m_UseItems[TPosition.U_NECKLACE];
                HumItems[TPosition.U_NECKLACE] = *this.m_UseItems[TPosition.U_HELMET];
                HumItems[TPosition.U_ARMRINGL] = *this.m_UseItems[TPosition.U_ARMRINGL];
                HumItems[TPosition.U_ARMRINGR] = *this.m_UseItems[TPosition.U_ARMRINGR];
                HumItems[TPosition.U_RINGL] = *this.m_UseItems[TPosition.U_RINGL];
                HumItems[TPosition.U_RINGR] = *this.m_UseItems[TPosition.U_RINGR];
                nCode = 10;
                HumAddItems = (TUserItem*)HumanRcd->Data.HumAddItemsBuff;
                HumAddItems[TPosition.U_BUJUK] = *this.m_UseItems[TPosition.U_BUJUK];
                HumAddItems[TPosition.U_BELT] = *this.m_UseItems[TPosition.U_BELT];
                HumAddItems[TPosition.U_BOOTS] = *this.m_UseItems[TPosition.U_BOOTS];
                HumAddItems[TPosition.U_CHARM] = *this.m_UseItems[TPosition.U_CHARM];
                HumAddItems[TPosition.U_ZHULI] = *this.m_UseItems[TPosition.U_ZHULI];//����
                nCode = 11;
                BagItems = (TUserItem*)HumanRcd->Data.BagItemsBuff;
                TBatterPulse* pbtpl = (TBatterPulse*)HumData->HumPulses;// �������ﾭ��
                pbtpl[0] = this.m_HumPulses[0];
                pbtpl[1] = this.m_HumPulses[1];
                pbtpl[2] = this.m_HumPulses[2];
                pbtpl[3] = this.m_HumPulses[3];
                HumData->BatterMagicOrder[0] = (ushort)this.m_nBatterOrder[0];// ��������ѭ��
                HumData->BatterMagicOrder[1] = (ushort)this.m_nBatterOrder[1];// ��������ѭ��
                HumData->BatterMagicOrder[2] = (ushort)this.m_nBatterOrder[2];// ��������ѭ��
                HumData->m_boIsOpenPuls = m_boisOpenPuls;// �Ƿ�򿪾���
                HumData->m_nPulseExp = (uint)m_nPulseExp;// ������������
                for (int I = 0; I < this.m_ItemList.Count; I++)
                {
                    if (I >= Grobal2.MAXHEROBAGITEM)
                    {
                        break;
                    }
                    TUserItem* item = (TUserItem*)this.m_ItemList[I];
                    if (item->wIndex == 0)  //IDΪ0����Ʒ�򲻱���
                    {
                        continue;
                    }
                    BagItems[I] = *item;
                }
                nCode = 12;
                HumMagics = (THumMagic*)HumanRcd->Data.HumMagicsBuff;
                HumNGMagics = (THumMagic*)HumanRcd->Data.HumNGMagicsBuff;// �ڹ�����
                HumBatterMagics = (THumMagic*)HumanRcd->Data.HumBatterMagicsBuff;// ��������
                if (this.m_MagicList.Count > 0)
                {
                    int J = 0;
                    int K = 0;
                    int B = 0;
                    for (int I = 0; I < this.m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)this.m_MagicList[I];
                        if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) != "�ڹ�"))
                        {
                            if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) != "����"))
                            {
                                if (J >= M2Share.MAXMAGIC)
                                {
                                    continue;
                                }
                                HumMagics[J].wMagIdx = UserMagic->wMagIdx;
                                HumMagics[J].btLevel = UserMagic->btLevel;
                                HumMagics[J].btKey = UserMagic->btKey;
                                HumMagics[J].nTranPoint = UserMagic->nTranPoint;
                                J++;
                            }
                            else
                            {
                                if (B >= 4)
                                {
                                    continue;
                                }
                                HumBatterMagics[B].wMagIdx = UserMagic->wMagIdx;
                                HumBatterMagics[B].btLevel = UserMagic->btLevel;
                                HumBatterMagics[B].btKey = UserMagic->btKey;
                                HumBatterMagics[B].nTranPoint = UserMagic->nTranPoint;
                                B++;
                            }
                        }
                        else
                        {
                            if (K >= M2Share.MAXMAGIC)
                            {
                                continue;
                            }
                            HumNGMagics[K].wMagIdx = UserMagic->wMagIdx;
                            HumNGMagics[K].btLevel = UserMagic->btLevel;
                            HumNGMagics[K].btKey = UserMagic->btKey;
                            HumNGMagics[K].nTranPoint = UserMagic->nTranPoint;
                            K++;
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.MakeSaveRcd Code:" + nCode);
            }
        }

        /// <summary>
        /// Ӣ�۵�¼
        /// </summary>
        public unsafe void Login()
        {
            TUserItem* UserItem = null;
            TUserItem* UserItem1 = null;
            TStdItem* StdItem;
            TUserMagic* UserMagic = null;
            TMagic* Magic;
            int n08;
            int n09;
            string s14;
            string sItem;
            const string sExceptionMsg = "{�쳣} THeroObject::Login";
            for (int I = 0; I <= 3; I++)
            {
                n09 = 0;
                if (this.m_HumPulses[I].PulseLevel > 0)
                {
                    switch (this.m_btJob)
                    {
                        case 0:
                            n08 = 76 + I * 3;
                            for (int II = 0; II < this.m_MagicList.Count; II++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[II];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == n08))
                                {
                                    n09 = 1;
                                    break;
                                }
                            }
                            if (n09 != 1)
                            {
                                Magic = UserEngine.FindMagic(n08);
                                if (Magic != null)
                                {
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = (ushort)I;
                                    UserMagic->btLevel = 3;
                                    UserMagic->btKey = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                }
                            }
                            break;
                        case 1:
                            n08 = 77 + I * 3;
                            for (int II = 0; II < this.m_MagicList.Count; II++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[II];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == n08))
                                {
                                    n09 = 1;
                                    break;
                                }
                            }
                            if (n09 != 1)
                            {
                                Magic = UserEngine.FindMagic(n08);
                                if (Magic != null)
                                {
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = (ushort)I;
                                    UserMagic->btLevel = 3;
                                    UserMagic->btKey = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                }
                            }
                            break;
                        case 2:
                            n08 = 78 + I * 3;
                            for (int II = 0; II < this.m_MagicList.Count; II++)
                            {
                                UserMagic = (TUserMagic*)this.m_MagicList[II];
                                if ((UserMagic != null) && (UserMagic->wMagIdx == n08))
                                {
                                    n09 = 1;
                                    break;
                                }
                            }
                            if (n09 != 1)
                            {
                                Magic = UserEngine.FindMagic(n08);
                                if (Magic != null)
                                {
                                    UserMagic->MagicInfo = *Magic;
                                    UserMagic->wMagIdx = (ushort)I;
                                    UserMagic->btLevel = 3;
                                    UserMagic->btKey = 0;
                                    UserMagic->nTranPoint = 0;
                                    this.m_MagicList.Add((IntPtr)UserMagic);
                                }
                            }
                            break;
                        case 3:
                            break;
                    }
                }
            }
            try
            {
                // ����������������Ʒ
                if (m_boNewHuman)
                {
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    if (UserEngine.CopyToUserItemFromName(GameConfig.sHeroBasicDrug, UserItem))
                    {
                        this.m_ItemList.Add((IntPtr)UserItem);
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                    }
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    if (UserEngine.CopyToUserItemFromName(GameConfig.sHeroWoodenSword, UserItem))
                    {
                        this.m_ItemList.Add((IntPtr)UserItem);
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                    }
                    if (this.m_btGender == 0)
                    {
                        sItem = GameConfig.sHeroClothsMan;
                    }
                    else
                    {
                        sItem = GameConfig.sHeroClothsWoman;
                    }
                    UserItem = (TUserItem*)Marshal.AllocHGlobal(sizeof(TUserItem));
                    if (UserEngine.CopyToUserItemFromName(sItem, UserItem))
                    {
                        this.m_ItemList.Add((IntPtr)UserItem);
                    }
                    else
                    {
                        Marshal.FreeHGlobal((IntPtr)UserItem);
                    }
                }
                // ��鱳���е���Ʒ�Ƿ�Ϸ�
                for (int I = this.m_ItemList.Count - 1; I >= 0; I--)
                {
                    if (this.m_ItemList.Count <= 0)
                    {
                        break;
                    }
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    //���ӣ��ж�����ID�Ƿ�Ϊ����
                    if ((UserEngine.GetStdItemName(UserItem->wIndex) == "") || (UserItem->MakeIndex < 0) || this.CheckIsOKItem(UserItem, 0))  // ����̬��Ʒ
                    {
                        //Marshal.FreeHGlobal((IntPtr)this.m_ItemList[I]);
                        Dispose((IntPtr)this.m_ItemList[I]);
                        this.m_ItemList.RemoveAt(I);
                    }
                }
                // ����������ϵ���Ʒ�Ƿ����ʹ�ù���
                if (GameConfig.boCheckUserItemPlace)
                {
                    for (int I = m_UseItems.GetLowerBound(0); I <= m_UseItems.GetUpperBound(0); I++)
                    {
                        if (this.m_UseItems[I]->wIndex > 0)
                        {
                            StdItem = UserEngine.GetStdItem(this.m_UseItems[I]->wIndex);
                            if (StdItem != null)
                            {
                                if (this.CheckIsOKItem(this.m_UseItems[I], 0))// ����̬��Ʒ
                                {
                                    this.m_UseItems[I]->wIndex = 0;
                                    continue;
                                }
                                if (!M2Share.CheckUserItems(I, StdItem))
                                {
                                    //FillChar(UserItem, sizeof(TUserItem), '\0');
                                    // FillChar(UserItem^.btValue, SizeOf(UserItem^.btValue), 0);//20080820 ����
                                    *UserItem = *this.m_UseItems[I];
                                    if (!AddItemToBag(UserItem))
                                    {
                                        this.m_ItemList.Insert(0, (IntPtr)UserItem);
                                    }
                                    this.m_UseItems[I]->wIndex = 0;
                                }
                            }
                            else
                            {
                                this.m_UseItems[I]->wIndex = 0;
                            }
                        }
                    }
                }
                // ������������
                if (this.m_MagicList.Count > 0)
                {
                    for (int I = 0; I < this.m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)this.m_MagicList[I];
                        if (UserMagic != null)
                        {
                            if (HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) == "����")
                            {
                                this.m_boCanUseBatter = true;
                                break;
                            }
                        }
                    }
                }
                for (int I = 0; I <= 2; I++)
                {
                    n08 = this.m_nBatterOrder[I];
                    n09 = 0;
                    if ((n08 == 0) || (n08 == 2222))
                    {
                        continue;
                    }
                    if (this.m_MagicList.Count > 0)
                    {
                        for (int II = 0; II < this.m_MagicList.Count; II++)
                        {
                            UserMagic = (TUserMagic*)this.m_MagicList[II];
                            if (UserMagic != null)
                            {
                                if ((HUtil32.SBytePtrToString(UserMagic->MagicInfo.sDescr, UserMagic->MagicInfo.DescrLen) == "����") &&
                                    (UserMagic->MagicInfo.wMagicId == n08))
                                {
                                    this.m_boCanUseBatter = true;
                                    n09 = 8;
                                    break;
                                }
                            }
                        }
                    }
                    if (n09 != 8)
                    {
                        this.m_nBatterOrder[I] = 0;
                    }
                }
                // ��������ѭ�� ��ֹ��
                // ��鱳�����Ƿ��и���Ʒ
                for (int I = this.m_ItemList.Count - 1; I >= 0; I--)
                {
                    if (this.m_ItemList.Count <= 0)
                    {
                        break;
                    }
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    s14 = UserEngine.GetStdItemName(UserItem->wIndex);
                    for (int II = I - 1; II >= 0; II--)
                    {
                        UserItem1 = (TUserItem*)this.m_ItemList[II];
                        if ((UserEngine.GetStdItemName(UserItem1->wIndex) == s14) && (UserItem->MakeIndex == UserItem1->MakeIndex))
                        {
                            this.m_ItemList.RemoveAt(II);
                            break;
                        }
                    }
                }
                for (int I = this.m_dwStatusArrTick.GetLowerBound(0); I <= this.m_dwStatusArrTick.GetUpperBound(0); I++)
                {
                    if (this.m_wStatusTimeArr[I] > 0)
                    {
                        this.m_dwStatusArrTick[I] = HUtil32.GetTickCount();
                    }
                }
                if (this.m_btLastOutStatus == 1)
                {
                    this.m_WAbil.HP = (this.m_WAbil.MaxHP / 15) + 2;// ��������Ӣ��,ѪҪ���ܵ�
                    this.m_btLastOutStatus = 0;
                }
                // RecalcLevelAbilitys();
                // RecalcAbilitys();
                if ((M2Share.g_ManageNPC != null) && (this.m_Master != null))
                {
                    M2Share.g_ManageNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroLogin", false);
                }
                this.m_boFixedHideMode = false;
            }
            catch
            {
                M2Share.MainOutMessage(sExceptionMsg);
            }
        }

        /// <summary>
        /// �жϵ�Ӣ�۶����Ƿ�����,��ʾ�û�
        /// ���� nType Ϊָ������ 1 Ϊ����� 2 Ϊ��ҩ    nCount Ϊ�־�,������
        /// </summary>
        /// <param name="nType"></param>
        /// <param name="nCount"></param>
        /// <returns></returns>
        private unsafe bool CheckHeroAmulet(int nType, int nCount)
        {
            bool result = false;
            TUserItem* UserItem;
            TStdItem* AmuletStdItem;
            try
            {
                result = false;
                if (this.m_UseItems[TPosition.U_ARMRINGL]->wIndex > 0)
                {
                    AmuletStdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_ARMRINGL]->wIndex);
                    if ((AmuletStdItem != null) && (AmuletStdItem->StdMode == 25))
                    {
                        switch (nType)
                        {
                            case 1:
                                if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                            case 2:
                                if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_ARMRINGL]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                        }
                    }
                }
                if (this.m_UseItems[TPosition.U_BUJUK]->wIndex > 0)
                {
                    AmuletStdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_BUJUK]->wIndex);
                    if ((AmuletStdItem != null) && (AmuletStdItem->StdMode == 25))
                    {
                        switch (nType)
                        {
                            case 1:// ��
                                if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                            case 2:// ��
                                if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)this.m_UseItems[TPosition.U_BUJUK]->Dura / 100) >= nCount))
                                {
                                    result = true;
                                    return result;
                                }
                                break;
                        }
                    }
                }
                // �����������Ƿ���ڶ�,�����
                if (this.m_ItemList.Count > 0)
                {
                    for (int I = 0; I < this.m_ItemList.Count; I++) // ���������Ϊ��
                    {
                        UserItem = (TUserItem*)this.m_ItemList[I];
                        AmuletStdItem = UserEngine.GetStdItem(UserItem->wIndex);
                        if ((AmuletStdItem != null) && (AmuletStdItem->StdMode == 25))
                        {
                            switch (nType)
                            {
                                case 1:
                                    if ((AmuletStdItem->Shape == 5) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                    {
                                        result = true;
                                        return result;
                                    }
                                    break;
                                case 2:
                                    if ((AmuletStdItem->Shape <= 2) && (HUtil32.Round((double)UserItem->Dura / 100) >= nCount))
                                    {
                                        result = true;
                                        return result;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.CheckHeroAmulet");
            }
            return result;
        }

        /// <summary>
        /// Ӣ����������
        /// </summary>
        /// <returns></returns>
        public bool LevelUpFunc()
        {
            bool result;
            result = false;
            if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
            {
                M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroLevelUp", false);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Ӣ���ڹ���������
        /// </summary>
        /// <returns></returns>
        public bool NGLevelUpFunc()
        {
            bool result;
            result = false;
            if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
            {
                M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@HeroNGLevelUp", false);
                result = true;
            }
            return result;
        }

        // �жϵ�Ӣ�۶����Ƿ�����,��ʾ�û�
        // Ӣ��ʹ����Ʒ���� 
        private unsafe bool UseStdmodeFunItem(TStdItem* StdItem)
        {
            bool result;
            result = false;
            if ((M2Share.g_FunctionNPC != null) && (this.m_Master != null))
            {
                M2Share.g_FunctionNPC.GotoLable(((TPlayObject)(this.m_Master)), "@StdModeFunc" + StdItem->AniCount, false);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// �ͻ�������ħ������
        /// </summary>
        /// <param name="nSkillIdx"></param>
        /// <param name="nKey"></param>
        public unsafe void ChangeHeroMagicKey(int nSkillIdx, int nKey)
        {
            int I;
            TUserMagic* UserMagic;
            if (new ArrayList(new int[] { 0, 1 }).Contains(nKey))
            {
                if (this.m_MagicList.Count > 0)
                {
                    for (I = 0; I < this.m_MagicList.Count; I++)
                    {
                        UserMagic = (TUserMagic*)this.m_MagicList[I];
                        if (UserMagic->MagicInfo.wMagicId == nSkillIdx)
                        {
                            UserMagic->btKey = (byte)nKey;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �������и���Ʒ
        /// </summary>
        /// <param name="wIndex"></param>
        /// <param name="MakeIndex"></param>
        public unsafe void ClearCopyItem(int wIndex, int MakeIndex)
        {
            int I;
            TUserItem* UserItem;
            try
            {
                this.m_boOperationItemList = true; // ��ֹͬʱ���������б�ʱ����

                for (I = this.m_ItemList.Count - 1; I >= 0; I--)
                {
                    if (this.m_ItemList.Count <= 0)
                    {
                        break;
                    }
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    if ((UserItem->wIndex == wIndex) && (UserItem->MakeIndex == MakeIndex))
                    {
                        SendDelItems(UserItem);
                        this.m_ItemList.RemoveAt(I);
                        break;  //ֻ�ҵ�һ�����˳������Ч��
                    }
                }
                this.m_boOperationItemList = false; // ��ֹͬʱ���������б�ʱ����
            }
            catch
            {
                this.m_boOperationItemList = false; // ��ֹͬʱ���������б�ʱ����
                M2Share.MainOutMessage("{�쳣} THeroObject.ClearCopyItem");
            }
        }

        /// <summary>
        /// ��Ѫʯ����
        /// </summary>
        private unsafe void PlaySuperRock()
        {
            TStdItem* StdItem;
            int nTempDura;
            try
            {
                if ((!this.m_boDeath) && (!this.m_boGhost) && (this.m_WAbil.HP > 0))
                {
                    if ((this.m_UseItems[TPosition.U_CHARM]->wIndex > 0) && (this.m_UseItems[TPosition.U_CHARM]->Dura > 0))
                    {
                        StdItem = UserEngine.GetStdItem(this.m_UseItems[TPosition.U_CHARM]->wIndex);
                        if ((StdItem != null))
                        {
                            if ((StdItem->Shape > 0) && this.m_PEnvir.AllowStdItems(HUtil32.SBytePtrToString(StdItem->Name, 0, StdItem->NameLen)))
                            {
                                switch (StdItem->Shape)
                                {
                                    case 1:// ��Ѫʯ
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= GameConfig.nStartHPRock)
                                        {
                                            // �ĳɵ���������
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > GameConfig.nHPRockSpell)
                                            {
                                                dwRockAddHPTick = HUtil32.GetTickCount();// ��ʯ��HP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nHPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nHPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.HP > this.m_WAbil.MaxHP)
                                                {
                                                    this.m_WAbil.HP = this.m_WAbil.MaxHP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                    case 2:
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= GameConfig.nStartMPRock)
                                        {
                                            // �ĳɵ���������
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > GameConfig.nMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();
                                                // ��ʯ��MP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.MP > this.m_WAbil.MaxMP)
                                                {
                                                    this.m_WAbil.MP = this.m_WAbil.MaxMP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                    case 3:
                                        if ((this.m_WAbil.MaxHP - this.m_WAbil.HP) >= GameConfig.nStartHPMPRock)
                                        {
                                            //�ĳɵ���������
                                            if (HUtil32.GetTickCount() - dwRockAddHPTick > GameConfig.nHPMPRockSpell)
                                            {
                                                dwRockAddHPTick = HUtil32.GetTickCount();// ��ʯ��HP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.HP += GameConfig.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.HP > this.m_WAbil.MaxHP)
                                                {
                                                    this.m_WAbil.HP = this.m_WAbil.MaxHP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        // ======================================================================
                                        if ((this.m_WAbil.MaxMP - this.m_WAbil.MP) >= GameConfig.nStartHPMPRock)
                                        {
                                            // �ĳɵ���������
                                            if (HUtil32.GetTickCount() - dwRockAddMPTick > GameConfig.nHPMPRockSpell)
                                            {
                                                dwRockAddMPTick = HUtil32.GetTickCount();// ��ʯ��MP���
                                                if (this.m_UseItems[TPosition.U_CHARM]->Dura * 10 > GameConfig.nHPMPRockDecDura)
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddHPMP;
                                                    nTempDura = this.m_UseItems[TPosition.U_CHARM]->Dura * 10;
                                                    nTempDura -= GameConfig.nHPMPRockDecDura;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = (ushort)HUtil32.Round((double)nTempDura / 10);
                                                    if (this.m_UseItems[TPosition.U_CHARM]->Dura > 0)
                                                    {
                                                        SendMsg(this, Grobal2.RM_HERODURACHANGE, TPosition.U_CHARM, this.m_UseItems[TPosition.U_CHARM]->Dura, this.m_UseItems[TPosition.U_CHARM]->DuraMax, 0, "");
                                                    }
                                                    else
                                                    {
                                                        SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                        this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    this.m_WAbil.MP += GameConfig.nRockAddHPMP;
                                                    this.m_UseItems[TPosition.U_CHARM]->Dura = 0;
                                                    SendDelItems(this.m_UseItems[TPosition.U_CHARM]);
                                                    this.m_UseItems[TPosition.U_CHARM]->wIndex = 0;
                                                }
                                                if (this.m_WAbil.MP > this.m_WAbil.MaxMP)
                                                {
                                                    this.m_WAbil.MP = this.m_WAbil.MaxMP;
                                                }
                                                this.PlugHealthSpellChanged();
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.MainOutMessage("{�쳣} THeroObject.PlaySuperRock");
            }
        }

        public unsafe int MagMakeHPUp_GetSpellPoint(TUserMagic* UserMagic)
        {
            int result;
            result = UserMagic->MagicInfo.wSpell + UserMagic->MagicInfo.btDefSpell;
            return result;
        }

        /// <summary>
        /// Ӣ�۾�������
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        private unsafe bool MagMakeHPUp(TUserMagic* UserMagic)
        {
            bool result = false;
            int nSpellPoint;
            int n14;
            result = false;
            nSpellPoint = MagMakeHPUp_GetSpellPoint(UserMagic);
            if (nSpellPoint > 0)
            {
                if ((this.m_Abil.WineDrinkValue >= HUtil32.Round((double)this.m_Abil.MaxAlcohol * GameConfig.nMinDrinkValue68 / 100)))
                {
                    if ((HUtil32.GetTickCount() - this.m_dwStatusArrTimeOutTick[4] > GameConfig.nHPUpTick * 1000) && (this.m_wStatusArrValue[4] == 0))// ʱ����
                    {
                        if (this.m_WAbil.MP < nSpellPoint)
                        {
                            SysMsg("MPֵ����!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                            return result;
                        }
                        this.DamageSpell(nSpellPoint);// ��MPֵ
                        this.HealthSpellChanged();
                        n14 = 300 + GameConfig.nHPUpUseTime;
                        this.m_dwStatusArrTimeOutTick[4] = Convert.ToUInt32(HUtil32.GetTickCount() + n14 * 1000);// ʹ��ʱ��
                        this.m_wStatusArrValue[4] = Convert.ToUInt16(UserMagic->btLevel + 1);// ����ֵ
                        SysMsg("(Ӣ��)����ֵ˲������, ����" + n14 + "��", TMsgColor.c_Green, TMsgType.t_Hint);
                        SysMsg("(Ӣ��)���������Ѿ��ڼ���״̬", TMsgColor.c_Green, TMsgType.t_Hint);
                        RecalcAbilitys();
                        this.CompareSuitItem(false);// ��װ������װ���Ա�
                        SendMsg(this, Grobal2.RM_HEROABILITY, 0, 0, 0, 0, "");
                        result = true;
                    }
                    else
                    {
                        SysMsg("(Ӣ��)" + GameMsgDef.g_sOpenShieldOKMsg, TMsgColor.c_Red, TMsgType.t_Hint);
                    }
                }
                else
                {
                    SysMsg("(Ӣ��)��ƶȲ�����" + GameConfig.nMinDrinkValue68 + "%ʱ,����ʹ�ô˼��� ", TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            return result;
        }

        // �ڹ���������
        public unsafe void NGMAGIC_LVEXP(TUserMagic* UserMagic)
        {
            if ((UserMagic != null))
            {
                if ((this.m_btRaceServer == Grobal2.RC_HEROOBJECT) && (UserMagic->btLevel < 3) && (UserMagic->MagicInfo.TrainLevel[UserMagic->btLevel] <= m_NGLevel))
                {
                    this.TrainSkill(UserMagic, HUtil32.Random(3) + 1);
                    if (!this.CheckMagicLevelup(UserMagic))
                    {
                        SendDelayMsg(this, Grobal2.RM_HEROMAGIC_LVEXP, 0, UserMagic->MagicInfo.wMagicId, UserMagic->btLevel, UserMagic->nTranPoint, "", 3000);
                    }
                }
            }
        }

        public void RecalcAdjusBonus_AdjustAb(byte Abil, ushort Val, ref ushort lov, ref ushort hiv)
        {
            byte Lo = 0;
            byte Hi = 0;
            int I;
            //Lo = LoByte(Abil);
            //Hi = HiByte(Abil);
            lov = 0;
            hiv = 0;
            for (I = 1; I <= Val; I++)
            {
                if (Lo + 1 < Hi)
                {
                    Lo++;
                    lov++;
                }
                else
                {
                    Hi++;
                    hiv++;
                }
            }
        }

        // ˢ��Ӣ����������
        private unsafe void RecalcAdjusBonus()
        {
            TNakedAbility* BonusTick;
            TNakedAbility* NakedAbil;
            int adc;
            int amc;
            int asc;
            int aac;
            int amac;
            ushort ldc = 0;
            ushort lmc = 0;
            ushort lsc = 0;
            ushort lac = 0;
            ushort lmac = 0;
            ushort hdc = 0;
            ushort hmc = 0;
            ushort hsc = 0;
            ushort hac = 0;
            ushort hmac = 0;
            BonusTick = null;
            NakedAbil = null;
            switch (this.m_btJob)
            {
                case 0:
                    fixed (TNakedAbility* item = &GameConfig.BonusAbilofWarr)
                    {
                        BonusTick = item;
                    }
                    fixed (TNakedAbility* item = &GameConfig.NakedAbilofWarr)
                    {
                        NakedAbil = item;
                    }
                    break;
                case 1:
                    fixed (TNakedAbility* item = &GameConfig.BonusAbilofWizard)
                    {
                        BonusTick = item;
                    }
                    fixed (TNakedAbility* item = &GameConfig.NakedAbilofWizard)
                    {
                        NakedAbil = item;
                    }
                    break;
                case 2:
                    fixed (TNakedAbility* item = &GameConfig.BonusAbilofTaos)
                    {
                        BonusTick = item;
                    }
                    fixed (TNakedAbility* item = &GameConfig.NakedAbilofTaos)
                    {
                        NakedAbil = item;
                    }
                    break;
            }
            adc = this.m_BonusAbil.DC / BonusTick->DC;
            amc = this.m_BonusAbil.MC / BonusTick->MC;
            asc = this.m_BonusAbil.SC / BonusTick->SC;
            aac = this.m_BonusAbil.AC / BonusTick->AC;
            amac = this.m_BonusAbil.MAC / BonusTick->MAC;
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->DC, (ushort)adc, ref ldc, ref hdc);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->MC, (ushort)amc, ref lmc, ref hmc);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->SC, (ushort)asc, ref lsc, ref hsc);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->AC, (ushort)aac, ref lac, ref hac);
            RecalcAdjusBonus_AdjustAb((byte)NakedAbil->MAC, (ushort)amac, ref lmac, ref hmac);
            this.m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.DC) + ldc, HUtil32.HiWord(this.m_WAbil.DC) + hdc);
            this.m_WAbil.MC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.MC) + lmc, HUtil32.HiWord(this.m_WAbil.MC) + hmc);
            this.m_WAbil.SC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.SC) + lsc, HUtil32.HiWord(this.m_WAbil.SC) + hsc);
            this.m_WAbil.AC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.AC) + lac, HUtil32.HiWord(this.m_WAbil.AC) + hac);
            this.m_WAbil.MAC = HUtil32.MakeLong(HUtil32.LoWord(this.m_WAbil.MAC) + lmac, HUtil32.HiWord(this.m_WAbil.MAC) + hmac);
            this.m_WAbil.MaxHP = HUtil32._MIN(Int32.MaxValue, this.m_WAbil.MaxHP + this.m_BonusAbil.HP / BonusTick->HP);
            this.m_WAbil.MaxMP = HUtil32._MIN(Int32.MaxValue, this.m_WAbil.MaxMP + this.m_BonusAbil.MP / BonusTick->MP);
        }

        // �ڹ���������
        // �������װ��������Ʒ�Ƿ�
        public unsafe bool CheckItemBindDieNoDrop(TUserItem* UserItem)
        {
            bool result;
            int I;
            TItemBind ItemBind;
            result = false;
            HUtil32.EnterCriticalSection(M2Share.g_ItemBindDieNoDropName);
            try
            {
                if (M2Share.g_ItemBindDieNoDropName.Count > 0)
                {
                    for (I = 0; I < M2Share.g_ItemBindDieNoDropName.Count; I++)
                    {
                        //ItemBind = M2Share.g_ItemBindDieNoDropName[I];
                        //if (ItemBind != null)
                        //{
                        //    if (ItemBind.nItemIdx == UserItem->wIndex)
                        //    {
                        //        if (((ItemBind.sBindName).ToLower().CompareTo((this.m_sCharName).ToLower()) == 0))
                        //        {
                        //            result = true;
                        //        }
                        //        return result;
                        //    }
                        //}
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.g_ItemBindDieNoDropName);
            }
            return result;
        }

        // ���Ӣ�۰�������Ʒ �ű�
        public unsafe TUserItem* QuestCheckItem(string sItemName, ref int nCount, ref int nParam, ref int nDura)
        {
            TUserItem* result = null;
            int I;
            TUserItem* UserItem;
            string s1C;
            nParam = 0;
            nDura = 0;
            nCount = 0;
            if (this.m_ItemList.Count > 0)
            {
                for (I = 0; I < this.m_ItemList.Count; I++)
                {
                    UserItem = (TUserItem*)this.m_ItemList[I];
                    s1C = UserEngine.GetStdItemName(UserItem->wIndex);
                    if ((s1C).ToLower().CompareTo((sItemName).ToLower()) == 0)
                    {
                        if (UserItem->Dura > nDura)
                        {
                            nDura = UserItem->Dura;
                            result = UserItem;
                        }
                        nParam += UserItem->Dura;
                        if (result == null)
                        {
                            result = UserItem;
                        }
                        nCount++;
                    }
                }
            }
            return result;
        }

        // ���Ӣ�۰�������Ʒ
        public bool DecGold(int nGold)
        {
            bool result;
            result = false;
            if (this.m_nGold >= nGold)
            {
                this.m_nGold -= nGold;
                result = true;
            }
            return result;
        }
    }
}

