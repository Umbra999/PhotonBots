using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VRChatAPI.Responses;
using System.IO;
using TheBotUI.VRCAPI.Responses;
using VRChatAPI;

namespace VRChatAPI.Endpoints
{
    public class Users
    {
        private Variables Variables;

        public Users(ref Variables variables) {
            Variables = variables;
        }

        public async Task<List<UserRES>> Get(int offset)
        {
            string json = "";
            List<UserRES> users = null;
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
            Console.WriteLine($"[Day API] Getting UserList [{Variables.UserSelfRES.username}]");
            var response = await Variables.HttpClient.GetAsync($"users?apiKey={Variables.APIKey}&n=100&offset={offset}");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                users = JsonConvert.DeserializeObject<List<UserRES>>(json);
                Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
                Console.WriteLine($"[Day API] Got List Length: {users.Count}");
            }

            return users;
        }

        public static async Task<NotificationRES> SendFriendrequest(string id)
        {
            string json = "";
            NotificationRES notif = null;
            HttpClient RequestClient = new HttpClient();
            RequestClient.DefaultRequestHeaders.Accept.Clear();
            RequestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine($"[Day API] Sending Friendrequest to {id}");
            var lines = File.ReadAllLines("Auth/AuthNormal.txt");
            foreach (var line in lines)
            {
                var Login = line;
                var byteArray = Encoding.ASCII.GetBytes(Login);
                RequestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
                var response = await RequestClient.PostAsync("https://api.vrchat.cloud/api/1/user/" + id + "/friendRequest?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", null);
                json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    notif = JsonConvert.DeserializeObject<NotificationRES>(json);
                    Console.ForegroundColor
                        = ConsoleColor.DarkCyan;
                    Console.WriteLine($"[Day API] Friendrequest Success [{Login}]");
                }
                else
                {
                    notif = JsonConvert.DeserializeObject<NotificationRES>(json);
                    Console.ForegroundColor
                        = ConsoleColor.Red;
                    Console.WriteLine($"[Day API] Failed To Friend [{Login}]\n" + json);
                }
            }
            return notif;
        }

        public static async Task<UserSelfRES> SwitchAvatar(string id)
        {
            string json = "";
            UserSelfRES notif = null;
            HttpClient RequestClient = new HttpClient();
            RequestClient.DefaultRequestHeaders.Accept.Clear();
            RequestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
            Console.WriteLine($"[Day API] Switching Avatar to {id}");
            var lines = File.ReadAllLines("Auth/AuthNormal.txt");
            foreach (var line in lines)
            {
                var Login = line;
                var byteArray = Encoding.ASCII.GetBytes(Login);
                RequestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = await RequestClient.PutAsync($"https://api.vrchat.cloud/api/1/avatars/" + id + "/select?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", null);
                json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    notif = JsonConvert.DeserializeObject<UserSelfRES>(json);
                    Console.ForegroundColor
                        = ConsoleColor.DarkCyan;
                    Console.WriteLine($"[Day API] Switched Success [{Login}]");
                }
                else
                {
                    notif = JsonConvert.DeserializeObject<UserSelfRES>(json);
                    Console.ForegroundColor
                        = ConsoleColor.Red;
                    Console.WriteLine($"[Day API] Failed To Switch [{Login}]\n" + json);
                }
            }
            return notif;
        }
    }
}