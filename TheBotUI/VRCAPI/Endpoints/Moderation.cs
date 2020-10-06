using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatAPI;
using Newtonsoft.Json;

namespace TheBotUI.VRCAPI.Endpoints
{
    public class Moderation {
        private Variables Variables;
        public Moderation(ref Variables variables)
        {
            Variables = variables;
        }
        public async void SendModeration(string Id,Type type)
        {
            var json = JsonConvert.SerializeObject(new ModerationHeader() 
            {
                type = type.ToString(),
                moderated = Id,
            });
            System.Net.Http.HttpContent content = new System.Net.Http.StringContent(json);
            var response = await Variables.HttpClient.PostAsync($"auth/user/playermoderations?apiKey={Variables.APIKey}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("[Success] " + response.StatusCode);
            }
            else
            {
                Console.WriteLine("[Failure] " + response.StatusCode + " | " + response);
            }
        }
    }
    public class ModerationHeader
    {
        public string type;
        public string moderated;
    }
    public enum Type
    {
        block= 0,
        mute = 1,
        unmute= 2,
        hideAvatar=3,
        showAvatar=4,
    }
}
