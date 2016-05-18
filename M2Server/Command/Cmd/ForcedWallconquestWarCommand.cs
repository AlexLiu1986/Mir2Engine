using GameFramework;
using GameFramework.Command;
using System;

namespace M2Server
{
    /// <summary>
    /// 开始工程战役
    /// </summary>
    [GameCommand("ForcedWallconquestWar", "开始工程战役", 10)]
    public class ForcedWallconquestWarCommand : BaseCommond
    {
        [DefaultCommand]
        public void ForcedWallconquestWar(string[] @Params, TPlayObject PlayObject)
        {
            string sCASTLENAME = @Params.Length > 0 ? @Params[0] : "";

            if (sCASTLENAME == "")
            {
                PlayObject.SysMsg("命令格式: @" + this.Attributes.Name + " 城堡名称", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            TUserCastle Castle = M2Share.g_CastleManager.Find(sCASTLENAME);
            if (Castle != null)
            {
                Castle.m_boUnderWar = !Castle.m_boUnderWar;
                if (Castle.m_boUnderWar)
                {
                    Castle.m_dwStartCastleWarTick = HUtil32.GetTickCount();
                    Castle.StartWallconquestWar();

                    // UserEngine.SendServerGroupMsg(SS_212, nServerIndex, '');
                    string s20 = '[' + Castle.m_sName + "攻城战已经开始]";
                    UserEngine.SendBroadCastMsg(s20, TMsgType.t_System);

                    // UserEngine.SendServerGroupMsg(SS_204, nServerIndex, s20);
                    Castle.MainDoorControl(true);
                }
                else
                {
                    Castle.StopWallconquestWar();
                }
            }
            else
            {
                PlayObject.SysMsg(String.Format(GameMsgDef.g_sGameCommandSbkGoldCastleNotFoundMsg, sCASTLENAME), TMsgColor.c_Red, TMsgType.t_Hint);
            }
        }
    }
}