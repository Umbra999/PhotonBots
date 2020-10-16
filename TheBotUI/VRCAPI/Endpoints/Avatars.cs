using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TheBotUI.VRCAPI.Responses;
using VRChatAPI;

namespace TheBotUI.VRCAPI.Endpoints
{
    public class Avatars
    {
        public async void Switch(string ID)
        {
            HttpClient RequestClient = new HttpClient();
            RequestClient.DefaultRequestHeaders.Accept.Clear();
            RequestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var lines = File.ReadAllLines("Auth/NormalAuth.txt");
            var byteArray = Encoding.ASCII.GetBytes(lines[0]);
            RequestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
            await RequestClient.GetAsync("https://api.vrchat.cloud/api/1/avatars/" + ID + "/select?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
        }
    }
}
