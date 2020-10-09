using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
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

            var response = await Variables.HttpClient.GetAsync($"auth/user?apiKey={Variables.APIKey}");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                currentUser = JsonConvert.DeserializeObject<UserSelfRES>(json);
                foreach (var cookie in Variables.CookieContainer.GetCookies(new Uri(Variables.BaseAddress)).Cast<Cookie>())
                    if (cookie.Name == "auth")
                        Variables.AuthCookie = cookie.Value;
            }

            return currentUser;
        }
    }
}