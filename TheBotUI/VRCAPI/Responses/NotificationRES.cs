using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VRChatAPI.Responses
{
    public class NotificationRES
    {
        public string id { get; set; }
        public string type { get; set; }
        public string senderUserId { get; set; }
        public string receiverUserId { get; set; }
        public string message { get; set; }
        public JObject details { get; set; } // unknown
        public string jobName { get; set; }
        public string jobColor { get; set; }
    }
}
