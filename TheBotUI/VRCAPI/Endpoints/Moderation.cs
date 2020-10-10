using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRChatAPI;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

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
            /*var json = JsonConvert.SerializeObject(new ModerationHeader() 
            {
                type = type.ToString(),
                moderated = Id,
            });
            System.Net.Http.HttpContent content = new System.Net.Http.StringContent(json);
            Console.WriteLine($"[Day API] Sending Moderation [{Variables.UserSelfRES.username}]\n{json}");
            var response = await Variables.HttpClient.PostAsync($"auth/user/playermoderations?apiKey={Variables.APIKey}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("[Day API] [Success] " + response.StatusCode);
            }
            else
            {
                Console.WriteLine("[Day API] [Failure] " + response.StatusCode + " | " + response);
            }*/
            var json = JsonConvert.SerializeObject(new ModerationHeader()
            {
                type = type.ToString(),
                moderated = Id,
            });
            System.Net.Http.HttpContent content = new System.Net.Http.StringContent(json);
            HttpClient RequestClient = new HttpClient();
            RequestClient.DefaultRequestHeaders.Accept.Clear();
            RequestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var lines = File.ReadAllLines("Auth/APIAuth.txt");
            foreach(var line in lines)
            {
                var Login = line;
                var byteArray = Encoding.ASCII.GetBytes(Login);
                RequestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                Console.WriteLine($"[Day API] Sending Moderation [{Login}]\n{json}");
                var response = await RequestClient.PostAsync("https://api.vrchat.cloud/api/1/auth/user/playermoderations?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", content);
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
