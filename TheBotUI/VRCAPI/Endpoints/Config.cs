using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBotUI.VRCAPI.Responses;
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

            var response = await Variables.HttpClient.GetAsync($"config");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                config = JsonConvert.DeserializeObject<ConfigRES>(json);
                Variables.Config = config;
            }
            return config;
        }
    }
}