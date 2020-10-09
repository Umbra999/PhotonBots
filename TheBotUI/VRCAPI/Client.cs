using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using VRChatAPI.Endpoints;

namespace VRChatAPI {

    public class Client {
        public Auth Auth { get; set; }
        public Config Config { get; set; }
        public Users Users { get; set; }
        public Variables Variables;

        public string Mac {
            get {
                //Create mac.txt at \forwardbot\ForwardBot\ForwardBotClient\bin\Debug\netcoreapp2.1
                string mac = "";
                if (string.IsNullOrEmpty(File.ReadAllText("mac.txt")) || string.IsNullOrWhiteSpace(File.ReadAllText("mac.txt"))) {
                    mac = Guid.NewGuid().ToString();
                    File.WriteAllText("mac.txt", mac);
                    return mac;
                }
                else
                    mac = File.ReadAllText("mac.txt");
                return mac;
            }
        }

        public Client(string username, string password) {
            this.Variables = new Variables();

            if (Variables.HttpClient == null) {
                //Cookie Container to grab the AuthCookie
                Variables.CookieContainer = new CookieContainer();
                Variables.HttpClientHandler = new HttpClientHandler() {
                    CookieContainer = Variables.CookieContainer
                };
                Variables.HttpClient = new HttpClient(Variables.HttpClientHandler) {
                    BaseAddress = new Uri(Variables.BaseAddress)
                };
            }

            this.Auth = new Auth(ref this.Variables, username, password);
            this.Config = new Config(ref this.Variables);
            this.Users = new Users(ref this.Variables);

            //Grabbing config to get the APIKey
            Config.Get().GetAwaiter().GetResult();
            Variables.APIKey = Variables.Config.apiKey;

            var header = Variables.HttpClient.DefaultRequestHeaders;
            //Adding normal auth, then using authcookie auth
            if (header.Contains("Authorization"))
                header.Remove("Authorization");
            header.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Auth.Username}:{Auth.Password}")));
            if (header.Contains("X-MacAddress"))
                header.Remove("X-MacAddress");
            header.Add("X-MacAddress", this.Mac);
            if (header.Contains("X-Client-Version"))
                header.Remove("X-Client-Version");
            header.Add("X-Client-Version", "VRCApplication");
            if (header.Contains("Origin"))
                header.Remove("Origin");
            header.Add("Origin", "vrchat.com");
            if (header.Contains("X-Platform"))
                header.Remove("X-Platform");
            header.Add("X-Platform", "standalonewindows");
            Variables.UserSelfRES = Auth.Login().GetAwaiter().GetResult();
            header.Remove("Authorization");
            Variables.CookieContainer.Add(new Uri(Variables.BaseAddress), new Cookie("auth", Variables.AuthCookie));
        }
    }
}