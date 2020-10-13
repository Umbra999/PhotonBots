using Photon.Realtime;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TheBotUI.Core;
using System.Linq;
using VRChatAPI.Endpoints;
using TheBotUI.VRCAPI.Responses;
using System.Net;
using System.Collections.Specialized;
using ExitGames.Client.Photon;
using System.Collections;
using VRChatAPI;
using Newtonsoft.Json;
using VRChatAPI.Responses;
#if NET472
using System.Diagnostics;
#endif
namespace TheBotUI.Core
{
    static class SearchWebhooks
    {
        public const string StreamerWebhook = "https://discord.com/api/webhooks/755119944852701235/4nuvJwP6XMiSaJp2C0pQjQ47h7wEMHv7-zLCn6hZmpZVRuJ4ngef1NEpIHzezw9UOpxI";
        public const string WengaWebhook = "https://discord.com/api/webhooks/755116773568938046/Ex_z8B5UuoE4_3K9uUKUceRPYnawtHfaM8X7ptde2l30SoqqxvJVElmcv1ZtrtGstwDJ";
        public const string GayClientWebhook = "https://discord.com/api/webhooks/757270851077931089/NgaMCNA6jNwRhkf59FjvDPUrxYkrUQmb5dF9xLhxlykbdkoZvjRlLiM1y0MCSKjnEss9";
        public const string AdminWebhook = "https://discord.com/api/webhooks/755118582207086602/zjkJZI8VCcSiHUO5mOkYyTz4lxLNiPdi2kgsCkAeXLJ7g1lriVQCiaAyzJlUc86r3QAq";
        public const string AviCreatorWebhook = "https://discord.com/api/webhooks/764542937081708595/X73q-TDcnUXVOOSqH4-d-5QDUvaAdkaZSDuRUE5wpBSwJ9-11gSo7afHVVp-COyi1g4d";
        //Sell Webhooks
        public const string DickSmokeWebhook = "https://discord.com/api/webhooks/755140836789846057/vaOWcGbThUHq_89bldjSDYaxBPUUVu8sxLE3jyVL1DBkObe-GZa1thsL5By0nstsecMY";
        public const string SypherrWebhook = "https://discord.com/api/webhooks/755141259458379887/nLP07lChyLOM3-fnnFoSx716151-E1932cuQ5wHeKltoRb2Eg3D8KKMEeAyMDbv1xrO8";
        public const string JaypoxWebhook = "https://discord.com/api/webhooks/755141107507134497/H6WesOAl55Ho5LDB_istpHdLlv4_Z_ZBO2K-bRb8n_UAqMcjg5rMaNiQ8iF_ZpRFrCfy";
        public const string AkenoWebhook = "https://discord.com/api/webhooks/755141542145949797/TvMTcp5kBGADnvU0yixnAYWTeTbXa6FTamr2G4tHyDyo2FZjsItN-F7gy4y6R3XdJKdM";
        public const string CatziiWebhook = "https://discord.com/api/webhooks/755141744047161444/R073aNP_DTrlMX6iDdxCqQ1iJol7TKSPIMWf0HPPZm5aZNPSf8ECA9b3bn2dqALlgKPZ";
        public const string VxWebhook = "https://discord.com/api/webhooks/755149168858628127/xsgP0S3GklgPSd0H1yqkj389eqJIcC6SekCRtzgbgOJyihUdOAsCZ_9uBqoWCdqTI_k5";
        public const string SexyToxiBuffWebhook = "https://discord.com/api/webhooks/755435782440878202/SKPQk-uQctaatpuiYlPhYHqpFsYtKFi4-qnqKYwSFpPeS3tDn7_3gldMx5BIkl6SVtnO";
        public const string IncognitomanWebhook = "https://discord.com/api/webhooks/764276573875863603/RXVxNzkC6OEwIz727j1YyuC_cbtJ8VbSCC5Xa6f4l4mIJxsytnT70VTybXgZZpcNkrf7";
        public const string ToksinWebhook = "https://discord.com/api/webhooks/764800785267556352/GtabtiusGZNA5Gi7SUwJ8HKoMQ1U5q45abtH_2BP__SSBU_iD7aITVbIpgR9Wupepjh0";
        public const string SirzechsWebhook = "https://discord.com/api/webhooks/765184879339372544/mO8jdxrqvgxcK8qtZvQUrzWHCrCuIxRAGX7txPogfVfWM4ud75swmD97ztcg60oJ5bqi";
        public const string MircoPortmannWebhook = "https://discord.com/api/webhooks/765276836552376390/tVePRPxWrdBKq5qj2UvyU8a5PElYvkIbvtctJXcZkJX3kOVPAvrT-sTsua32y5x5Hdox";
        public const string BlankWebhook = "https://discord.com/api/webhooks/765679400518811650/RiFmU-cHuv20VjTPOlWKprziDstHFBLLzhrdBGdyNCM27Q1lp4nRN2Vui1n0U65Gyfu6";

        public static void DoWebhooks(Player player, WorldRES world,string WorldInstanceID)
        {
            Dictionary<string, object> tictionary = (Dictionary<string, object>)player.CustomProperties["avatarDict"];
            var AvatarID = tictionary["id"];

            Dictionary<string, object> dictionary = (Dictionary<string, object>)player.CustomProperties["user"];
            var UserID = dictionary["id"];
            var Displayname = dictionary["displayName"];

            if (File.ReadAllText("Access/Wenga.txt").Contains(UserID.ToString()))
            {
                Console.WriteLine("Found: " + Displayname);
                SendWebHook(WengaWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
            }

            if (File.ReadAllText("Access/DayOfThePlay.txt").Contains(UserID.ToString()))
            {
                Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                SendWebHook(GayClientWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
            }

            if (File.ReadAllText("UsersMod.txt").Contains(UserID.ToString()))
            {
                Console.WriteLine("Found: " + Displayname);
                SendWebHook(AdminWebhook, $"**[Wenga's Egirl]**\n \n **Admin/Mod:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
            }

            if (File.ReadAllText("UsersStreamer.txt").Contains(UserID.ToString()))
            {
                Console.WriteLine("Found: " + Displayname);
                SendWebHook(StreamerWebhook, $"**[Wenga's Egirl]**\n \n **Streamer:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
            }

            if (File.ReadAllText("UsersAviCreator.txt").Contains(UserID.ToString()))
            {
                Console.WriteLine("Found: " + Displayname);
                SendWebHook(AviCreatorWebhook, $"**[Wenga's Egirl]**\n \n **Creator:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
            }

            // SELL STUFF ONLY ADD AND REMOVE //
            if (File.ReadAllText("Access/Bigsmoke002.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(DickSmokeWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Jaypox.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(JaypoxWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Akeno.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(AkenoWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Catzii.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(CatziiWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Vx.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(VxWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/SexyToxiBuff.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(SexyToxiBuffWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Sypherr.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(SypherrWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Incognitoman.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(IncognitomanWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Toksin.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(ToksinWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Sirzechs.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(SirzechsWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/MircoPortmann.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(MircoPortmannWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }

            if (File.ReadAllText("Access/Blank.txt").Contains(UserID.ToString()))
            {
                if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found AntiSearch User: " + dictionary["displayName"].ToString());
                }
                else
                {
                    Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                    SendWebHook(BlankWebhook, $"**[Wenga's Egirl]**\n \n **Player:** {Displayname} \n **UserID:** {UserID}  \n **World:** {world.name}  [{WorldInstanceID}]  \n **AvatarID:** {AvatarID}");
                }
            }
        }


        public static void SendWebHook(string URL, string MSG)
        {
            NameValueCollection pairs = new NameValueCollection()
            {
                { "content", MSG }
            };
            byte[] numArray;
            using (WebClient webClient = new WebClient())
            {
                numArray = webClient.UploadValues(URL, pairs);
            }
        }
    }
}
