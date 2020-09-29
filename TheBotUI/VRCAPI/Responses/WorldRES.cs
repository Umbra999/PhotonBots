using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBotUI.VRCAPI.Responses
{
    public class WorldRES
    {
        public string id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public int publicOccupants { get; set; }
        public object[][] instances { get; set; }
    }
}
