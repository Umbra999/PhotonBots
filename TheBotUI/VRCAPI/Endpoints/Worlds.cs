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
    static class Worlds
    {
  
        public static async Task<WorldRES> GetWorld(string WorldID)
        {
            string json = "";
            WorldRES world = null;
            HttpClient RequestClient = new HttpClient();
            RequestClient.DefaultRequestHeaders.Accept.Clear();
            RequestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string[] Login = File.ReadAllLines("Auth/APIAuth.txt");
            var byteArray = Encoding.ASCII.GetBytes(Login[0]);
            RequestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await RequestClient.GetAsync("https://api.vrchat.cloud/api/1/worlds/"+WorldID+ "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                world = JsonConvert.DeserializeObject<WorldRES>(json);
            }

            return world;
        }
        public static async Task<string[]> GetInstances(string worldID)
        {
            try
            {
                WorldRES world = await GetWorld(worldID);
                List<string> instances = new List<string>();
                foreach (object instance in world.instances)
                {
                    instances.Add(float.Parse(instance.ToString().Split(',')[0].Replace("[", "").Replace('"', ' ')).ToString());
                }
                return instances.ToArray();
            }
            catch (Exception)
            {
            }
            return new string[0];
        }
    }
}
