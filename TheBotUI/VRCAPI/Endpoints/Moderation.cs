using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatAPI;

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
            System.Net.Http.HttpContent content = new System.Net.Http.StringContent("");
            content.Headers.Add("type", type.ToString());
            content.Headers.Add("moderated", Id);
            Variables.HttpClient.DefaultRequestHeaders.Add("type", type.ToString());
            Variables.HttpClient.DefaultRequestHeaders.Add("moderated", Id);
            var response = await Variables.HttpClient.PostAsync($"auth/user/playermoderations?apiKey={Variables.APIKey}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("[Success] " + response.StatusCode);
            }
            else
            {
                Console.WriteLine("[Failure] " + response.StatusCode + " | " + response.ReasonPhrase);
            }
        }
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
