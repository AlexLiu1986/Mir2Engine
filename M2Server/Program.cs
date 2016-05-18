using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime;

namespace M2Server
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (GCSettings.IsServerGC)
            {
                GCSettings.LatencyMode = GCLatencyMode.Batch;
            }
            else
            {
                GCSettings.LatencyMode = GCLatencyMode.Interactive;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TFrmMain());
        }
    }
}