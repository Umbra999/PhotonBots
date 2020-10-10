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
            Console.WriteLine($"[Day API] Getting UserList [{Variables.UserSelfRES.username}]");
            var response = await Variables.HttpClient.GetAsync($"users?apiKey={Variables.APIKey}&n=100&offset={offset}");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                users = JsonConvert.DeserializeObject<List<UserRES>>(json);
                Console.WriteLine($"[Day API] Got List Length: {users.Count}");
            }

            return users;
        }

        public async Task<NotificationRES> SendFriendrequest(string id)
        {
            string json = "";
            NotificationRES notif = null;
            Console.WriteLine($"[Day API] Sending Friendrequest to {id} [{Variables.UserSelfRES.username}]");
            var response = await Variables.HttpClient.PostAsync($"user/{id}/friendRequest?apiKey={Variables.APIKey}", null);
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                notif = JsonConvert.DeserializeObject<NotificationRES>(json);
                Console.WriteLine($"[Day API] Friendrequest Success [{Variables.UserSelfRES.username}]");
            }

            return notif;
        }
    }
}
