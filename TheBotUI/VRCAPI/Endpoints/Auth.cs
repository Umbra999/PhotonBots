using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VRChatAPI.Responses;

namespace VRChatAPI.Endpoints {

    public class Auth {
        public string Username { get; set; }
        public string Password { get; set; }
        public Variables Variables;

        public Auth(ref Variables variables, string username, string password) {
            Username = username;
            Password = password;
            Variables = variables;
        }

        public async Task<UserSelfRES> Login() {
            string json = "";
            UserSelfRES currentUser = null;
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
            Console.WriteLine($"[Day API] Login in Using {Username}:{Password}");
            var response = await Variables.HttpClient.GetAsync($"auth/user?apiKey={Variables.APIKey}");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                currentUser = JsonConvert.DeserializeObject<UserSelfRES>(json);
                foreach (var cookie in Variables.CookieContainer.GetCookies(new Uri(Variables.BaseAddress)).Cast<Cookie>())
                    if (cookie.Name == "auth")
                    {
                        Variables.AuthCookie = cookie.Value;
                        Console.ForegroundColor
                            = ConsoleColor.DarkCyan;
                        Console.WriteLine($"[Day API] Got Cookie Auth:{cookie.Value} [{Username}]");
                    }
            }

            return currentUser;
        }
        public static async Task<UserSelfRES> Logout()
        {
            string json = "";
            UserSelfRES notif = null;
            HttpClient RequestClient = new HttpClient();
            RequestClient.DefaultRequestHeaders.Accept.Clear();
            RequestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var lines = File.ReadAllLines("Auth/AuthNormal.txt");
            var byteArray = Encoding.ASCII.GetBytes(lines[0]);
            RequestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
            Console.WriteLine($"[Day API] Logging out");
            var response = await RequestClient.PutAsync("https://api.vrchat.cloud/api/1/logout?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", null);
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                notif = JsonConvert.DeserializeObject<UserSelfRES>(json);
                Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
                Console.WriteLine($"[Day API] Logout Success");
            }
            else
            {
                notif = JsonConvert.DeserializeObject<UserSelfRES>(json);
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine($"[Day API] Failed To Logout\n" + json);
            }
            return notif;

        }
    }
}