﻿using GameFramework.Command;

namespace M2Server
{
    [GameCommand("SbkDoorControl", "", 10)]
    public class SbkDoorControlCommand : BaseCommond
    {
        [DefaultCommand]
        public void SbkDoorControl(string[] @Parasm, TPlayObject PlayObject)
        {
        }
    }
}