﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBotUI.VRCAPI.Responses
{
    public class ModerationRES
    {
        public string id { get; set; }
        public string type { get; set; }
        public string targetUserId { get; set; }
        public string targetDisplayName { get; set; }
        public string reason { get; set; }
        public string created { get; set; }
        public string expires { get; set; }
        public string worldId { get; set; }
        public string instanceId { get; set; }
        public string ip { get; set; }
        public string mac { get; set; }
        public bool active { get; set; }
    }
}
