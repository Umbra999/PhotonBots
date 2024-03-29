﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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
        public async Task<WorldRES> GetWorlds(string WorldID)
        {
            string json = "";
            WorldRES world = null;
            try
            {
                Console.WriteLine($"[Day API] Getting World {WorldID} [{Variables.UserSelfRES.displayName}]");
                var response = await Variables.HttpClient.GetAsync("https://api.vrchat.cloud/api/1/worlds/" + WorldID + "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
                if (response.IsSuccessStatusCode)
                {
                    world = JsonConvert.DeserializeObject<WorldRES>(json);
                    Console.ForegroundColor
                        = ConsoleColor.DarkCyan;
                    Console.WriteLine($"[Day API] Got World [{Variables.UserSelfRES.displayName}]");
                }
                else
                {
                    Console.ForegroundColor
                        = ConsoleColor.Red;
                    Console.WriteLine($"[Day API] Failed To get World [{Variables.UserSelfRES.displayName}]\n" + json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return world;
        }
        public static int LineReader = 0;

        public static async Task<WorldRES> GetWorld(string WorldID)
        {
            string json = "";
            WorldRES world = null;
            HttpClient RequestClient = new HttpClient();
            RequestClient.DefaultRequestHeaders.Accept.Clear();
            RequestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var lines = File.ReadAllLines("Auth/APIAuth.txt");
            var Login = lines[LineReader];
            LineReader++;
            if (LineReader >= lines.Length) LineReader = 0;
            var byteArray = Encoding.ASCII.GetBytes(Login);
            RequestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
            Console.WriteLine($"[Day API] Getting World {WorldID} [{Login}]");
            var response = await RequestClient.GetAsync("https://api.vrchat.cloud/api/1/worlds/"+WorldID+ "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26");
            Thread.Sleep(100);
            await RequestClient.PutAsync("https://api.vrchat.cloud/api/1/logout?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", null);
            json = await response.Content.ReadAsStringAsync();
            Console.ForegroundColor
                    = ConsoleColor.DarkCyan;

            if (response.IsSuccessStatusCode)
            {
                world = JsonConvert.DeserializeObject<WorldRES>(json);
                Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
                Console.WriteLine($"[Day API] Got World [{Login}]");
            }
            return world;
        }
        public static int FetchRoomCap(string worldId)
        {
            WorldRES room = JsonConvert.DeserializeObject<WorldRES>(HttpUtils.HttpGet("https://www.vrchat.com/api/1/worlds/" + worldId + "?apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26", new Dictionary<string, string>()));
            return room.capacity;
        }
        public static string[] GetInstances(WorldRES world)
        {
            try
            {
                Console.ForegroundColor
                    = ConsoleColor.DarkCyan;
                Console.WriteLine($"[Day API] Getting World Instances");
                List<string> instances = new List<string>();
                foreach (var instance in world.instances)
                {
                    instances.Add(instance[0].ToString());
                    Console.ForegroundColor
                        = ConsoleColor.DarkCyan;
                    Console.WriteLine($"[Day API] Got {instance[0].ToString()} with {instance[1].ToString()} People");
                }
                return instances.ToArray();
            }
            catch (Exception)
            {
            }
            return new string[0];
        }
        public static class HttpUtils
        {
            public static string base64Encode(string data)
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }

            public static bool HttpDelete(string url)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";
                request.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                        return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            public static string HttpGet(string url, Dictionary<string, string> headers = null)
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                if (headers != null)
                    headers.ToList().ForEach(x => webRequest.Headers.Add(x.Key, x.Value));
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "GET";
                webRequest.Accept = "application/json";
                webRequest.KeepAlive = false;
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader webSource = new StreamReader(webResponse.GetResponseStream());
                string source = string.Empty;
                source = webSource.ReadToEnd();
                webResponse.Close();
                return source;
            }
            public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers = null)
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                if (headers != null)
                    headers.ToList().ForEach(x => webRequest.Headers.Add(x.Key, x.Value));
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "GET";
                webRequest.Accept = "application/json";
                webRequest.KeepAlive = false;
                var webResponse = await webRequest.GetResponseAsync();
                StreamReader webSource = new StreamReader(webResponse.GetResponseStream());
                string source = string.Empty;
                source = webSource.ReadToEnd();
                webResponse.Close();
                return source;
            }

            public static string HttpPost(string uri, string body, Dictionary<string, string> headers = null, bool getResponse = true)
            {
                WebRequest webRequest = WebRequest.Create(uri);
                if (headers != null)
                    headers.ToList().ForEach(x => webRequest.Headers.Add(x.Key, x.Value));
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                byte[] bytes = Encoding.ASCII.GetBytes(body);
                Stream os = null;
                try
                {
                    webRequest.ContentLength = bytes.Length;
                    os = webRequest.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    throw new Exception("HttpPost: Request error");
                }
                finally
                {
                    if (os != null) os.Close();
                }

                if (getResponse)
                {
                    try
                    {
                        WebResponse webResponse = webRequest.GetResponse();
                        if (webResponse == null)
                            return null;
                        StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                        return sr.ReadToEnd().Trim();
                    }
                    catch (WebException ex)
                    {
                        throw new Exception("HttpPost: Response error");
                        throw new Exception(ex.Message);
                    }
                }
                return null;
            }
            public static string HttpPut(string uri, string body, Dictionary<string, string> headers = null, bool getResponse = true)
            {
                WebRequest webRequest = WebRequest.Create(uri);
                if (headers != null)
                    headers.ToList().ForEach(x => webRequest.Headers.Add(x.Key, x.Value));
                webRequest.ContentType = "application/json;charset=UTF-8";
                webRequest.Method = "POST";
                byte[] bytes = Encoding.ASCII.GetBytes(body);
                Stream os = null;
                try
                {
                    webRequest.ContentLength = bytes.Length;
                    os = webRequest.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    throw new Exception("HttpPost: Request error");
                }
                finally
                {
                    if (os != null) os.Close();
                }

                if (getResponse)
                {
                    try
                    {
                        WebResponse webResponse = webRequest.GetResponse();
                        if (webResponse == null)
                            return null;
                        StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                        return sr.ReadToEnd().Trim();
                    }
                    catch (WebException ex)
                    {
                        throw new Exception("HttpPost: Response error");
                        throw new Exception(ex.Message);
                    }
                }
                return null;
            }
        }
        
    }
}
