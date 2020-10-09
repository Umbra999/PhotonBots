using System.Net;
using System.Net.Http;
using VRChatAPI.Responses;

namespace VRChatAPI {

    public class Variables {
        public HttpClient HttpClient { get; set; }
        public HttpClientHandler HttpClientHandler { get; set; }
        public CookieContainer CookieContainer { get; set; }
        public ConfigRES Config { get; set; }
        public UserSelfRES UserSelfRES { get; set; }
        public string BaseAddress = "https://api.vrchat.cloud/api/1/";
        public string APIKey = "";
        public string AuthCookie = "";
    }
}