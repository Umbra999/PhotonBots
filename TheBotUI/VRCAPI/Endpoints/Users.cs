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

            var response = await Variables.HttpClient.GetAsync($"users?apiKey={Variables.APIKey}&n=100&offset={offset}");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                users = JsonConvert.DeserializeObject<List<UserRES>>(json);
            }

            return users;
        }

        public async Task<NotificationRES> SendFriendrequest(string id)
        {
            string json = "";
            NotificationRES notif = null;

            var response = await Variables.HttpClient.PostAsync($"user/{id}/friendRequest?apiKey={Variables.APIKey}", null);
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                notif = JsonConvert.DeserializeObject<NotificationRES>(json);
            }

            return notif;
        }
    }
}
