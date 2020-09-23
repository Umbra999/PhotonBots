using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VRChatAPI.Responses
{
    public class PastDisplayName
    {
        public string displayName { get; set; }
        public string updated_at { get; set; }
    }

    public class UserSelfRES : UserRES
    {
        public List<PastDisplayName> pastDisplayNames { get; set; }
        public bool hasEmail { get; set; }
        public string obfuscatedEmail { get; set; }
        public bool emailVerified { get; set; }
        public bool hasBirthday { get; set; }
        public bool unsubscribe { get; set; }
        public List<string> friends { get; set; }
        public JObject blueprints { get; set; }
        public JObject currentAvatarBlueprint { get; set; }
        public List<string> events { get; set; }
        public string currentAvatar { get; set; }
        public string currentAvatarAssetUrl { get; set; }
        public int acceptedTOSVersion { get; set; }
        public JObject steamDetails { get; set; }
        public bool hasLoggedInFromClient { get; set; }
    }
}
