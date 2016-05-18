namespace M2Server
{
  partial class TFrmMain
    {
        public System.Windows.Forms.Panel Panel;
        public System.Windows.Forms.Label Lbcheck;
        public System.Windows.Forms.Timer SaveVariableTimer;
        public System.Windows.Forms.MainMenu MainMenu;
        public System.Windows.Forms.MenuItem MENU_CONTROL;
        public System.Windows.Forms.MenuItem MENU_CONTROL_CLEARLOGMSG;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_ITEMDB;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_MAGICDB;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_MONSTERDB;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_MONSTERSAY;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_DISABLEMAKE;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_STARTPOINT;
        public System.Windows.Forms.MenuItem MENU_CONTROL_RELOAD_CONF;
        public System.Windows.Forms.MenuItem QFunctionNPC;
        public System.Windows.Forms.MenuItem QManageNPC;
        public System.Windows.Forms.MenuItem RobotManageNPC;
        public System.Windows.Forms.MenuItem MonItems;
        public System.Windows.Forms.MenuItem N2;
        public System.Windows.Forms.MenuItem N3;
        public System.Windows.Forms.MenuItem N5;
        public System.Windows.Forms.MenuItem N6;
        public System.Windows.Forms.MenuItem NPC1;
        public System.Windows.Forms.MenuItem NPC2;
        public System.Windows.Forms.MenuItem N7;
        public System.Windows.Forms.MenuItem S1;
        public System.Windows.Forms.MenuItem N4;
        public System.Windows.Forms.MenuItem mapconfig;
        public System.Windows.Forms.MenuItem monster;
        public System.Windows.Forms.MenuItem MENU_CONTROL_GATE;
        public System.Windows.Forms.MenuItem MENU_CONTROL_GATE_OPEN;
        public System.Windows.Forms.MenuItem MENU_CONTROL_GATE_CLOSE;
        public System.Windows.Forms.MenuItem MENU_CONTROL_EXIT;
        public System.Windows.Forms.MenuItem MENU_VIEW;
        public System.Windows.Forms.MenuItem MENU_VIEW_ONLINEHUMAN;
        public System.Windows.Forms.MenuItem MENU_VIEW_SESSION;
        public System.Windows.Forms.MenuItem MENU_VIEW_LEVEL;
        public System.Windows.Forms.MenuItem MENU_VIEW_LIST;
        public System.Windows.Forms.MenuItem N1;
        public System.Windows.Forms.MenuItem MENU_VIEW_KERNELINFO;
        public System.Windows.Forms.MenuItem MENU_OPTION;
        public System.Windows.Forms.MenuItem MENU_OPTION_GENERAL;
        public System.Windows.Forms.MenuItem MENU_OPTION_GAME;
        public System.Windows.Forms.MenuItem MENU_OPTION_ITEMFUNC;
        public System.Windows.Forms.MenuItem MENU_OPTION_FUNCTION;
        public System.Windows.Forms.MenuItem G1;
        public System.Windows.Forms.MenuItem MENU_OPTION_MONSTER;
        public System.Windows.Forms.MenuItem MENU_OPTION_SERVERCONFIG;
        public System.Windows.Forms.MenuItem MENU_OPTION_HERO;
        public System.Windows.Forms.MenuItem MENU_MANAGE;
        public System.Windows.Forms.MenuItem MENU_MANAGE_ONLINEMSG;
        public System.Windows.Forms.MenuItem MENU_MANAGE_CASTLE;
        public System.Windows.Forms.MenuItem G2;
        public System.Windows.Forms.MenuItem MENU_TOOLS;
        public System.Windows.Forms.MenuItem MENU_TOOLS_MERCHANT;
        public System.Windows.Forms.MenuItem MENU_TOOLS_NPC;
        public System.Windows.Forms.MenuItem MENU_TOOLS_MONGEN;
        public System.Windows.Forms.MenuItem MENU_TOOLS_IPSEARCH;
        public System.Windows.Forms.MenuItem MENU_HELP;
        public System.Windows.Forms.MenuItem MENU_HELP_ABOUT;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFrmMain));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Panel = new System.Windows.Forms.Panel();
            this.Lbcheck = new System.Windows.Forms.Label();
            this.SaveVariableTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.MENU_CONTROL = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_CLEARLOGMSG = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_ITEMDB = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_MAGICDB = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_MONSTERDB = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_MONSTERSAY = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_DISABLEMAKE = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_STARTPOINT = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_RELOAD_CONF = new System.Windows.Forms.MenuItem();
            this.QFunctionNPC = new System.Windows.Forms.MenuItem();
            this.QManageNPC = new System.Windows.Forms.MenuItem();
            this.RobotManageNPC = new System.Windows.Forms.MenuItem();
            this.MonItems = new System.Windows.Forms.MenuItem();
            this.N2 = new System.Windows.Forms.MenuItem();
            this.N3 = new System.Windows.Forms.MenuItem();
            this.N5 = new System.Windows.Forms.MenuItem();
            this.N6 = new System.Windows.Forms.MenuItem();
            this.NPC1 = new System.Windows.Forms.MenuItem();
            this.NPC2 = new System.Windows.Forms.MenuItem();
            this.N7 = new System.Windows.Forms.MenuItem();
            this.S1 = new System.Windows.Forms.MenuItem();
            this.N4 = new System.Windows.Forms.MenuItem();
            this.mapconfig = new System.Windows.Forms.MenuItem();
            this.monster = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_GATE = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_GATE_OPEN = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_GATE_CLOSE = new System.Windows.Forms.MenuItem();
            this.MENU_CONTROL_EXIT = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_ONLINEHUMAN = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_SESSION = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_LEVEL = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_LIST = new System.Windows.Forms.MenuItem();
            this.N1 = new System.Windows.Forms.MenuItem();
            this.MENU_VIEW_KERNELINFO = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_GENERAL = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_GAME = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_ITEMFUNC = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_FUNCTION = new System.Windows.Forms.MenuItem();
            this.G1 = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_MONSTER = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_SERVERCONFIG = new System.Windows.Forms.MenuItem();
            this.MENU_OPTION_HERO = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE_ONLINEMSG = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE_CASTLE = new System.Windows.Forms.MenuItem();
            this.G2 = new System.Windows.Forms.MenuItem();
            this.MENU_MANAGE_SYS = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_MERCHANT = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_NPC = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_MONGEN = new System.Windows.Forms.MenuItem();
            this.MENU_TOOLS_IPSEARCH = new System.Windows.Forms.MenuItem();
            this.MENU_HELP = new System.Windows.Forms.MenuItem();
            this.MENU_HELP_ABOUT = new System.Windows.Forms.MenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label20 = new System.Windows.Forms.Label();
            this.LbRunTime = new System.Windows.Forms.Label();
            this.LbUserCount = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.LbRunSocketTime = new System.Windows.Forms.Label();
            this.MemStatus = new System.Windows.Forms.Label();
            this.GateListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemoLog = new System.Windows.Forms.RichTextBox();
            this.Panel.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.Lbcheck);
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(200, 100);
            this.Panel.TabIndex = 0;
            // 
            // Lbcheck
            // 
            this.Lbcheck.Location = new System.Drawing.Point(48, 64);
            this.Lbcheck.Name = "Lbcheck";
            this.Lbcheck.Size = new System.Drawing.Size(6, 12);
            this.Lbcheck.TabIndex = 4;
            this.Lbcheck.Visible = false;
            // 
            // SaveVariableTimer
            // 
            this.SaveVariableTimer.Interval = 30000;
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL,
            this.MENU_VIEW,
            this.MENU_OPTION,
            this.MENU_MANAGE,
            this.MENU_TOOLS,
            this.MENU_HELP});
            // 
            // MENU_CONTROL
            // 
            this.MENU_CONTROL.Index = 0;
            this.MENU_CONTROL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL_CLEARLOGMSG,
            this.MENU_CONTROL_RELOAD,
            this.MENU_CONTROL_GATE,
            this.MENU_CONTROL_EXIT});
            this.MENU_CONTROL.Text = "����(&C)";
            this.MENU_CONTROL.Click += new System.EventHandler(this.MENU_CONTROLClick);
            // 
            // MENU_CONTROL_CLEARLOGMSG
            // 
            this.MENU_CONTROL_CLEARLOGMSG.Index = 0;
            this.MENU_CONTROL_CLEARLOGMSG.Text = "�����־(&C)";
            this.MENU_CONTROL_CLEARLOGMSG.Click += new System.EventHandler(this.MENU_CONTROL_CLEARLOGMSGClick);
            // 
            // MENU_CONTROL_RELOAD
            // 
            this.MENU_CONTROL_RELOAD.Index = 1;
            this.MENU_CONTROL_RELOAD.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL_RELOAD_ITEMDB,
            this.MENU_CONTROL_RELOAD_MAGICDB,
            this.MENU_CONTROL_RELOAD_MONSTERDB,
            this.MENU_CONTROL_RELOAD_MONSTERSAY,
            this.MENU_CONTROL_RELOAD_DISABLEMAKE,
            this.MENU_CONTROL_RELOAD_STARTPOINT,
            this.MENU_CONTROL_RELOAD_CONF,
            this.QFunctionNPC,
            this.QManageNPC,
            this.RobotManageNPC,
            this.MonItems,
            this.N2,
            this.N3,
            this.N5,
            this.N6,
            this.NPC1,
            this.NPC2,
            this.N7,
            this.S1,
            this.N4,
            this.mapconfig,
            this.monster});
            this.MENU_CONTROL_RELOAD.Text = "���¼���(&R)";
            // 
            // MENU_CONTROL_RELOAD_ITEMDB
            // 
            this.MENU_CONTROL_RELOAD_ITEMDB.Index = 0;
            this.MENU_CONTROL_RELOAD_ITEMDB.Text = "��Ʒ���ݿ�(&I)";
            this.MENU_CONTROL_RELOAD_ITEMDB.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_ITEMDBClick);
            // 
            // MENU_CONTROL_RELOAD_MAGICDB
            // 
            this.MENU_CONTROL_RELOAD_MAGICDB.Index = 1;
            this.MENU_CONTROL_RELOAD_MAGICDB.Text = "�������ݿ�(&S)";
            this.MENU_CONTROL_RELOAD_MAGICDB.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_MAGICDBClick);
            // 
            // MENU_CONTROL_RELOAD_MONSTERDB
            // 
            this.MENU_CONTROL_RELOAD_MONSTERDB.Index = 2;
            this.MENU_CONTROL_RELOAD_MONSTERDB.Text = "�������ݿ�(&M)";
            this.MENU_CONTROL_RELOAD_MONSTERDB.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_MONSTERDBClick);
            // 
            // MENU_CONTROL_RELOAD_MONSTERSAY
            // 
            this.MENU_CONTROL_RELOAD_MONSTERSAY.Index = 3;
            this.MENU_CONTROL_RELOAD_MONSTERSAY.Text = "����˵������(&M)";
            this.MENU_CONTROL_RELOAD_MONSTERSAY.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_MONSTERSAYClick);
            // 
            // MENU_CONTROL_RELOAD_DISABLEMAKE
            // 
            this.MENU_CONTROL_RELOAD_DISABLEMAKE.Index = 4;
            this.MENU_CONTROL_RELOAD_DISABLEMAKE.Text = "�����б�(&D)";
            this.MENU_CONTROL_RELOAD_DISABLEMAKE.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_DISABLEMAKEClick);
            // 
            // MENU_CONTROL_RELOAD_STARTPOINT
            // 
            this.MENU_CONTROL_RELOAD_STARTPOINT.Index = 5;
            this.MENU_CONTROL_RELOAD_STARTPOINT.Text = "��ͼ��ȫ��(&S)";
            this.MENU_CONTROL_RELOAD_STARTPOINT.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_STARTPOINTClick);
            // 
            // MENU_CONTROL_RELOAD_CONF
            // 
            this.MENU_CONTROL_RELOAD_CONF.Index = 6;
            this.MENU_CONTROL_RELOAD_CONF.Text = "��������(&C)";
            this.MENU_CONTROL_RELOAD_CONF.Click += new System.EventHandler(this.MENU_CONTROL_RELOAD_CONFClick);
            // 
            // QFunctionNPC
            // 
            this.QFunctionNPC.Index = 7;
            this.QFunctionNPC.Text = "QFunction �ű�(&Q)";
            this.QFunctionNPC.Click += new System.EventHandler(this.QFunctionNPCClick);
            // 
            // QManageNPC
            // 
            this.QManageNPC.Index = 8;
            this.QManageNPC.Text = "��½�ű�(&L)";
            this.QManageNPC.Click += new System.EventHandler(this.QManageNPCClick);
            // 
            // RobotManageNPC
            // 
            this.RobotManageNPC.Index = 9;
            this.RobotManageNPC.Text = "�����˽ű�(&R)";
            this.RobotManageNPC.Click += new System.EventHandler(this.RobotManageNPCClick);
            // 
            // MonItems
            // 
            this.MonItems.Index = 10;
            this.MonItems.Text = "���ﱬ��(&M)";
            this.MonItems.Click += new System.EventHandler(this.MonItemsClick);
            // 
            // N2
            // 
            this.N2.Index = 11;
            this.N2.Text = "-";
            // 
            // N3
            // 
            this.N3.Index = 12;
            this.N3.Text = "��������";
            this.N3.Click += new System.EventHandler(this.N3Click);
            // 
            // N5
            // 
            this.N5.Index = 13;
            this.N5.Text = "����ˢ������";
            this.N5.Click += new System.EventHandler(this.N5Click);
            // 
            // N6
            // 
            this.N6.Index = 14;
            this.N6.Text = "������ʾ��Ϣ";
            this.N6.Click += new System.EventHandler(this.N6Click);
            // 
            // NPC1
            // 
            this.NPC1.Index = 15;
            this.NPC1.Text = "����NPC����";
            this.NPC1.Click += new System.EventHandler(this.NPC1Click);
            // 
            // NPC2
            // 
            this.NPC2.Index = 16;
            this.NPC2.Text = "����NPC����";
            this.NPC2.Click += new System.EventHandler(this.NPC2Click);
            // 
            // N7
            // 
            this.N7.Index = 17;
            this.N7.Text = "��������";
            this.N7.Click += new System.EventHandler(this.N7Click);
            // 
            // S1
            // 
            this.S1.Index = 18;
            this.S1.Text = "��ʼ��ɳ������(&S)";
            this.S1.Click += new System.EventHandler(this.S1Click);
            // 
            // N4
            // 
            this.N4.Index = 19;
            this.N4.Text = "��������";
            this.N4.Click += new System.EventHandler(this.N4Click);
            // 
            // mapconfig
            // 
            this.mapconfig.Index = 20;
            this.mapconfig.Text = "��ͼ����";
            this.mapconfig.Click += new System.EventHandler(this.mapconfigClick);
            // 
            // monster
            // 
            this.monster.Index = 21;
            this.monster.Text = "ˢ������";
            this.monster.Click += new System.EventHandler(this.monsterClick);
            // 
            // MENU_CONTROL_GATE
            // 
            this.MENU_CONTROL_GATE.Index = 2;
            this.MENU_CONTROL_GATE.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_CONTROL_GATE_OPEN,
            this.MENU_CONTROL_GATE_CLOSE});
            this.MENU_CONTROL_GATE.Text = "��Ϸ����(&G)";
            // 
            // MENU_CONTROL_GATE_OPEN
            // 
            this.MENU_CONTROL_GATE_OPEN.Index = 0;
            this.MENU_CONTROL_GATE_OPEN.Text = "��(&O)";
            this.MENU_CONTROL_GATE_OPEN.Click += new System.EventHandler(this.MENU_CONTROL_GATE_OPENClick);
            // 
            // MENU_CONTROL_GATE_CLOSE
            // 
            this.MENU_CONTROL_GATE_CLOSE.Index = 1;
            this.MENU_CONTROL_GATE_CLOSE.Text = "�ر�(&C)";
            this.MENU_CONTROL_GATE_CLOSE.Click += new System.EventHandler(this.MENU_CONTROL_GATE_CLOSEClick);
            // 
            // MENU_CONTROL_EXIT
            // 
            this.MENU_CONTROL_EXIT.Index = 3;
            this.MENU_CONTROL_EXIT.Text = "�˳�(&X)";
            this.MENU_CONTROL_EXIT.Click += new System.EventHandler(this.MENU_CONTROL_EXITClick);
            // 
            // MENU_VIEW
            // 
            this.MENU_VIEW.Index = 1;
            this.MENU_VIEW.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_VIEW_ONLINEHUMAN,
            this.MENU_VIEW_SESSION,
            this.MENU_VIEW_LEVEL,
            this.MENU_VIEW_LIST,
            this.N1,
            this.MENU_VIEW_KERNELINFO});
            this.MENU_VIEW.Text = "�鿴(&V)";
            // 
            // MENU_VIEW_ONLINEHUMAN
            // 
            this.MENU_VIEW_ONLINEHUMAN.Index = 0;
            this.MENU_VIEW_ONLINEHUMAN.Text = "��������(&O)";
            this.MENU_VIEW_ONLINEHUMAN.Click += new System.EventHandler(this.MENU_VIEW_ONLINEHUMANClick);
            // 
            // MENU_VIEW_SESSION
            // 
            this.MENU_VIEW_SESSION.Index = 1;
            this.MENU_VIEW_SESSION.Text = "ȫ�ֻỰ(&S)";
            this.MENU_VIEW_SESSION.Click += new System.EventHandler(this.MENU_VIEW_SESSIONClick);
            // 
            // MENU_VIEW_LEVEL
            // 
            this.MENU_VIEW_LEVEL.Index = 2;
            this.MENU_VIEW_LEVEL.Text = "�ȼ�����(&L)";
            this.MENU_VIEW_LEVEL.Click += new System.EventHandler(this.MENU_VIEW_LEVELClick);
            // 
            // MENU_VIEW_LIST
            // 
            this.MENU_VIEW_LIST.Index = 3;
            this.MENU_VIEW_LIST.Text = "�б���Ϣһ(&L)";
            this.MENU_VIEW_LIST.Click += new System.EventHandler(this.MENU_VIEW_LISTClick);
            // 
            // N1
            // 
            this.N1.Index = 4;
            this.N1.Text = "�б���Ϣ��(&L)";
            this.N1.Click += new System.EventHandler(this.N1Click);
            // 
            // MENU_VIEW_KERNELINFO
            // 
            this.MENU_VIEW_KERNELINFO.Index = 5;
            this.MENU_VIEW_KERNELINFO.Text = "�ں�����(&K)";
            this.MENU_VIEW_KERNELINFO.Click += new System.EventHandler(this.MENU_VIEW_KERNELINFOClick);
            // 
            // MENU_OPTION
            // 
            this.MENU_OPTION.Index = 2;
            this.MENU_OPTION.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_OPTION_GENERAL,
            this.MENU_OPTION_GAME,
            this.MENU_OPTION_ITEMFUNC,
            this.MENU_OPTION_FUNCTION,
            this.G1,
            this.MENU_OPTION_MONSTER,
            this.MENU_OPTION_SERVERCONFIG,
            this.MENU_OPTION_HERO});
            this.MENU_OPTION.Text = "ѡ��(&P)";
            // 
            // MENU_OPTION_GENERAL
            // 
            this.MENU_OPTION_GENERAL.Index = 0;
            this.MENU_OPTION_GENERAL.Text = "��������(&G)";
            this.MENU_OPTION_GENERAL.Click += new System.EventHandler(this.MENU_OPTION_GENERALClick);
            // 
            // MENU_OPTION_GAME
            // 
            this.MENU_OPTION_GAME.Index = 1;
            this.MENU_OPTION_GAME.Text = "��������(&O)";
            this.MENU_OPTION_GAME.Click += new System.EventHandler(this.MENU_OPTION_GAMEClick);
            // 
            // MENU_OPTION_ITEMFUNC
            // 
            this.MENU_OPTION_ITEMFUNC.Index = 2;
            this.MENU_OPTION_ITEMFUNC.Text = "��Ʒװ��(&I)";
            this.MENU_OPTION_ITEMFUNC.Click += new System.EventHandler(this.MENU_OPTION_ITEMFUNCClick);
            // 
            // MENU_OPTION_FUNCTION
            // 
            this.MENU_OPTION_FUNCTION.Index = 3;
            this.MENU_OPTION_FUNCTION.Text = "��������(&F)";
            this.MENU_OPTION_FUNCTION.Click += new System.EventHandler(this.MENU_OPTION_FUNCTIONClick);
            // 
            // G1
            // 
            this.G1.Index = 4;
            this.G1.Text = "��Ϸ����(&C)";
            this.G1.Click += new System.EventHandler(this.G1Click);
            // 
            // MENU_OPTION_MONSTER
            // 
            this.MENU_OPTION_MONSTER.Index = 5;
            this.MENU_OPTION_MONSTER.Text = "��������(&M)";
            this.MENU_OPTION_MONSTER.Click += new System.EventHandler(this.MENU_OPTION_MONSTERClick);
            // 
            // MENU_OPTION_SERVERCONFIG
            // 
            this.MENU_OPTION_SERVERCONFIG.Index = 6;
            this.MENU_OPTION_SERVERCONFIG.Text = "���ܲ���(&P)";
            this.MENU_OPTION_SERVERCONFIG.Click += new System.EventHandler(this.MENU_OPTION_SERVERCONFIGClick);
            // 
            // MENU_OPTION_HERO
            // 
            this.MENU_OPTION_HERO.Index = 7;
            this.MENU_OPTION_HERO.Text = "Ӣ������(&H)";
            this.MENU_OPTION_HERO.Click += new System.EventHandler(this.MENU_OPTION_HEROClick);
            // 
            // MENU_MANAGE
            // 
            this.MENU_MANAGE.Index = 3;
            this.MENU_MANAGE.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_MANAGE_ONLINEMSG,
            this.MENU_MANAGE_CASTLE,
            this.G2,
            this.MENU_MANAGE_SYS});
            this.MENU_MANAGE.Text = "����(&M)";
            // 
            // MENU_MANAGE_ONLINEMSG
            // 
            this.MENU_MANAGE_ONLINEMSG.Index = 0;
            this.MENU_MANAGE_ONLINEMSG.Text = "������Ϣ(&S)";
            this.MENU_MANAGE_ONLINEMSG.Click += new System.EventHandler(this.MENU_MANAGE_ONLINEMSGClick);
            // 
            // MENU_MANAGE_CASTLE
            // 
            this.MENU_MANAGE_CASTLE.Index = 1;
            this.MENU_MANAGE_CASTLE.Text = "�Ǳ�����(&C)";
            this.MENU_MANAGE_CASTLE.Click += new System.EventHandler(this.MENU_MANAGE_CASTLEClick);
            // 
            // G2
            // 
            this.G2.Index = 2;
            this.G2.Text = "�л���� (&G)";
            this.G2.Click += new System.EventHandler(this.G2Click);
            // 
            // MENU_MANAGE_SYS
            // 
            this.MENU_MANAGE_SYS.Index = 3;
            this.MENU_MANAGE_SYS.Text = "ϵͳ����(&S)";
            this.MENU_MANAGE_SYS.Click += new System.EventHandler(this.MENU_MANAGE_SYS_Click);
            // 
            // MENU_TOOLS
            // 
            this.MENU_TOOLS.Index = 4;
            this.MENU_TOOLS.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_TOOLS_MERCHANT,
            this.MENU_TOOLS_NPC,
            this.MENU_TOOLS_MONGEN,
            this.MENU_TOOLS_IPSEARCH});
            this.MENU_TOOLS.Text = "����(&T)";
            // 
            // MENU_TOOLS_MERCHANT
            // 
            this.MENU_TOOLS_MERCHANT.Index = 0;
            this.MENU_TOOLS_MERCHANT.Text = "����NPC����(&M)";
            this.MENU_TOOLS_MERCHANT.Click += new System.EventHandler(this.MENU_TOOLS_MERCHANTClick);
            // 
            // MENU_TOOLS_NPC
            // 
            this.MENU_TOOLS_NPC.Index = 1;
            this.MENU_TOOLS_NPC.Text = "����NPC����(&N)";
            this.MENU_TOOLS_NPC.Visible = false;
            // 
            // MENU_TOOLS_MONGEN
            // 
            this.MENU_TOOLS_MONGEN.Index = 2;
            this.MENU_TOOLS_MONGEN.Text = "ˢ������(&G)";
            this.MENU_TOOLS_MONGEN.Click += new System.EventHandler(this.MENU_TOOLS_MONGENClick);
            // 
            // MENU_TOOLS_IPSEARCH
            // 
            this.MENU_TOOLS_IPSEARCH.Index = 3;
            this.MENU_TOOLS_IPSEARCH.Text = "������ѯ(&S)";
            this.MENU_TOOLS_IPSEARCH.Click += new System.EventHandler(this.MENU_TOOLS_IPSEARCHClick);
            // 
            // MENU_HELP
            // 
            this.MENU_HELP.Index = 5;
            this.MENU_HELP.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MENU_HELP_ABOUT});
            this.MENU_HELP.Text = "����(&H)";
            // 
            // MENU_HELP_ABOUT
            // 
            this.MENU_HELP_ABOUT.Index = 0;
            this.MENU_HELP_ABOUT.Text = "����(&A)";
            this.MENU_HELP_ABOUT.Click += new System.EventHandler(this.MENU_HELP_ABOUTClick);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Panel1.Controls.Add(this.Label20);
            this.Panel1.Controls.Add(this.LbRunTime);
            this.Panel1.Controls.Add(this.LbUserCount);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.LbRunSocketTime);
            this.Panel1.Controls.Add(this.MemStatus);
            this.Panel1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(-3, 188);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(443, 60);
            this.Panel1.TabIndex = 2;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(3, 29);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(0, 12);
            this.Label20.TabIndex = 15;
            // 
            // LbRunTime
            // 
            this.LbRunTime.Location = new System.Drawing.Point(339, 31);
            this.LbRunTime.Name = "LbRunTime";
            this.LbRunTime.Size = new System.Drawing.Size(96, 12);
            this.LbRunTime.TabIndex = 8;
            this.LbRunTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LbUserCount
            // 
            this.LbUserCount.Location = new System.Drawing.Point(339, 5);
            this.LbUserCount.Name = "LbUserCount";
            this.LbUserCount.Size = new System.Drawing.Size(96, 12);
            this.LbUserCount.TabIndex = 9;
            this.LbUserCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(3, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(235, 12);
            this.Label1.TabIndex = 10;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(3, 18);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(235, 12);
            this.Label2.TabIndex = 11;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(3, 44);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(235, 12);
            this.Label5.TabIndex = 12;
            // 
            // LbRunSocketTime
            // 
            this.LbRunSocketTime.Location = new System.Drawing.Point(339, 18);
            this.LbRunSocketTime.Name = "LbRunSocketTime";
            this.LbRunSocketTime.Size = new System.Drawing.Size(96, 12);
            this.LbRunSocketTime.TabIndex = 13;
            this.LbRunSocketTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MemStatus
            // 
            this.MemStatus.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemStatus.ForeColor = System.Drawing.Color.Blue;
            this.MemStatus.Location = new System.Drawing.Point(261, 44);
            this.MemStatus.Name = "MemStatus";
            this.MemStatus.Size = new System.Drawing.Size(175, 12);
            this.MemStatus.TabIndex = 14;
            this.MemStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GateListView
            // 
            this.GateListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.GateListView.AllowColumnReorder = true;
            this.GateListView.AutoArrange = false;
            this.GateListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.GateListView.FullRowSelect = true;
            this.GateListView.GridLines = true;
            this.GateListView.HideSelection = false;
            this.GateListView.Location = new System.Drawing.Point(1, 251);
            this.GateListView.MultiSelect = false;
            this.GateListView.Name = "GateListView";
            this.GateListView.Scrollable = false;
            this.GateListView.Size = new System.Drawing.Size(439, 104);
            this.GateListView.TabIndex = 4;
            this.GateListView.UseCompatibleStateImageBehavior = false;
            this.GateListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "����";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "���ص�ַ";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "��������";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "��������";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ʣ������";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ƽ������";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "�������";
            // 
            // MemoLog
            // 
            this.MemoLog.AutoWordSelection = true;
            this.MemoLog.BackColor = System.Drawing.Color.Black;
            this.MemoLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MemoLog.DetectUrls = false;
            this.MemoLog.ForeColor = System.Drawing.Color.Lime;
            this.MemoLog.HideSelection = false;
            this.MemoLog.Location = new System.Drawing.Point(0, 1);
            this.MemoLog.Name = "MemoLog";
            this.MemoLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.MemoLog.Size = new System.Drawing.Size(440, 185);
            this.MemoLog.TabIndex = 5;
            this.MemoLog.Text = "";
            // 
            // TFrmMain
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(444, 355);
            this.Controls.Add(this.MemoLog);
            this.Controls.Add(this.GateListView);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(292, 174);
            this.MaximizeBox = false;
            this.Menu = this.MainMenu;
            this.Name = "TFrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormCreate);
            this.Panel.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }
#endregion

        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.ListView GateListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.RichTextBox MemoLog;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label5;
        private System.Windows.Forms.MenuItem MENU_MANAGE_SYS;
        private System.Windows.Forms.Label Label20;
        private System.Windows.Forms.Label LbRunTime;
        private System.Windows.Forms.Label LbUserCount;
        private System.Windows.Forms.Label LbRunSocketTime;
        private System.Windows.Forms.Label MemStatus;

    }
}
