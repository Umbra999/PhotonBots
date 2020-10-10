using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VRChatAPI.Responses;

namespace VRChatAPI.Endpoints {

    public class Config {
        private Variables Variables;

        public Config(ref Variables variables) {
            Variables = variables;
        }

        public async Task<ConfigRES> Get() {
            string json = "";
            ConfigRES config = null;
            Console.WriteLine($"[Day API] Getting Config [{Variables.UserSelfRES?.username}]");
            var response = await Variables.HttpClient.GetAsync($"config");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                config = JsonConvert.DeserializeObject<ConfigRES>(json);
                Variables.Config = config;
                Console.WriteLine($"[Day API] Got Config");
            }
            return config;
        }
    }
}