using GameFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace M2Server.Base
{
    /// <summary>
    /// 游戏服务基本操作类
    /// </summary>
    public abstract class GameBase
    {
        /// <summary>
        /// 服务器启动时间
        /// </summary>
        internal static readonly DateTime StartTime;

        /// <summary>
        /// 服务器运行时间
        /// </summary>
        public static TimeSpan RunTime
        {
            get { return DateTime.Now - StartTime; }
        }

        static GameBase()
        {
            StartTime = DateTime.Now;
        }

        /// <summary>
        /// 游戏主配置文件
        /// </summary>
        public TGameConfig GameConfig { get { return M2Share.g_Config; } }

        /// <summary>
        /// 游戏引擎主类
        /// </summary>
        public TUserEngine UserEngine { get { return M2Share.UserEngine; } }

        /// <summary>
        /// 物品属性管理类
        /// </summary>
        public TItemUnit ItemUnit { get { return M2Share.ItemUnit; } }

        /// <summary>
        /// 行会管理类
        /// </summary>
        public TGuildManager GuildManager { get { return M2Share.g_GuildManager; } }

        /// <summary>
        /// 技能管理类
        /// </summary>
        public TMagicManager MagicManager { get { return M2Share.MagicManager; } }

        /// <summary>
        /// 向主界面输出消息
        /// </summary>
        /// <param name="sMsg"></param>
        public virtual void MainOutMessage(string sMsg)
        {
            M2Share.MainOutMessage(sMsg);
        }

    }
}