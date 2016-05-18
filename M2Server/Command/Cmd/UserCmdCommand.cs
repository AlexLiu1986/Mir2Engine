using GameFramework.Command;

namespace M2Server
{
    /// <summary>
    /// 自定义命令
    /// </summary>
    [GameCommand("UserCmd", "自定义命令", 10)]
    public class UserCmdCommand : BaseCommond
    {
        [DefaultCommand]
        public void UserCmd(string[] @Params, TPlayObject PlayObject)
        {
            string sLable = @Params.Length > 1 ? @Params[0] : "";
            if (M2Share.g_FunctionNPC != null)
            {
                PlayObject.m_nScriptGotoCount = 0;
                M2Share.g_FunctionNPC.GotoLable(PlayObject,sLable, false);
            }
        }
    }
}