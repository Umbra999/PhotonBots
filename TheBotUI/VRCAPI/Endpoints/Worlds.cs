using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TheBotUI.VRCAPI.Responses;
using VRChatAPI;

namespace VRChatAPI.Endpoints
{
    public class Worlds
    {
        private Variables Variables;
        public Worlds(ref Variables variables)
        {
            Variables = variables;
        }


        public async Task<WorldRES> GetWorld(string WorldID)
        {
            string json = "";
            WorldRES world = null;
            var response = await Variables.HttpClient.GetAsync("https://api.vrchat.cloud/api/1/worlds/"+WorldID+ "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
            json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                world = JsonConvert.DeserializeObject<WorldRES>(json);
            }
            else
            {
                Console.WriteLine("[Failure] " + response.StatusCode + " | " + json);
            }
            return world;
        }
        public static string[] GetInstances(WorldRES worldRES)
        {
            List<string> instances = new List<string>();
            foreach(var sex in worldRES.instances)
            {
                instances.Add(sex[0].ToString());
            }
            return instances.ToArray();
        }
    }
}
