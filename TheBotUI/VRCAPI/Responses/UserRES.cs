using System.Collections.Generic;

namespace VRChatAPI.Responses
{
    public class UserRES
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string currentAvatarImageUrl { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public List<string> tags { get; set; }
        public string developerType { get; set; }
        public string last_login { get; set; }
        public bool allowAvatarCopying { get; set; }
        public bool isFriend { get; set; }
        public string friendKey { get; set; }
        public string location { get; set; }
        public string worldId { get; set; }
        public string instanceId { get; set; }
    }
}
