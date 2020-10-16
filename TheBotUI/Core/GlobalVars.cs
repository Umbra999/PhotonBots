using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBotUI.Core
{
    static class GlobalVars
    {
        public static bool EventLog = false;
        public static int[] IgnoreEvents = new int[]{ 1, 226 };
        public static bool Desync = false;
        public static bool MasterDesync = false;
        public static bool Search = false;
        public static bool ShouldPauseRoomCheckerLoop = false;
    }
}
