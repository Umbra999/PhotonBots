﻿using Photon.Realtime;
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
        public const string APTXWebhook = "https://discord.com/api/webhooks/766062523211841596/Ss1zEfNSE2TI8dOWeKtToE7_drfCus_w1nwz7xNf5D8usNb77hTXQp_WyJj0-eGqMVvI";
        public const string ForgetfulWebhook = "https://discord.com/api/webhooks/766681072632070255/KEQIGfZDWpXdktR3kuc-SvKEI3bcdSlHsNARBgV6K16D0zqQRGeAL2z9l2MMCaDcvMiL";
        public const string DannyWebhook = "https://discord.com/api/webhooks/766789797959827467/Wi5k7oJYXfAz9UnpPFuuUEuslVhKN5W81aGntnl_2o-oHocpMN0YKsCTqy0pBfHmVKBt";
        public const string ZozeyWebhook = "https://discord.com/api/webhooks/768032802586624010/WEv0KHuzLjxLDOdUn1AH7qlDiaw4QdpQtH9lPTDXlzw5NtrDe-n87NBFRV3QzaAk-coH";
        public const string RiasWebhook = "https://discord.com/api/webhooks/768104425633742888/5RpYtyyAQzbJ4ekdnf_v-ZnyPAPdcEDUx9d-EVR-x4QBdR_DPpWQFnp8U5wACzgVDb_F";
        public const string SchahozWebhook = "https://discord.com/api/webhooks/768507496435548230/hsr3B90GOIiYvgMwxIioKYtRyz4IQCUslvteznqDrVrOVM1BxM5GuFesDyd8GjK8hQXm";
        public const string PickelWebhook = "https://discord.com/api/webhooks/769098732830457856/fIqx6B2PJ3aTmcfylSirJNkQg5CpW3VRyQ0o4-Jgkg3pXi5SJvkv7NlylwR4_IdRGXSH";
        public const string NightWebhook = "https://discord.com/api/webhooks/769740596423426059/3SgrT7_hrp073UKQltu68yoPrOu_32JM-O8fEOEQg-J4LjP8XFwf9s2uadwZeRXAzlIM";
        public const string YingWebhook = "https://discord.com/api/webhooks/770360909666320384/KBy29GfqncuUMnWLu-RCRi_CRnNtCw4vnhC8sgUnBx3ktEboqjci7N3Qv_zsEC4WmYtg";
        public const string InjectionWebhook = "https://discord.com/api/webhooks/776864545561116683/l3h-1SnSaYoL0QDKsi64R2ppFAjLizLvyY0hysHEaZwgN9y-NU0pLuTUZHcIRRu_ZxTw";
        public const string MuffinWebhook = "https://discord.com/api/webhooks/771351376805756948/F6MnAjW4GlUyHxpToaS3OllwcK5XlDj-gknxqKkc6gjwm7K48LMKij5yQSZDBimLjQKc";
        public const string TinnyWebhook = "https://discord.com/api/webhooks/771454381245333504/I5z-0twCIOOND-Pl9zcraP92JCHM8oRG6jdZCJpPp87Ta_A2hU0TsgBO_02CU9p2KaUr";
        public const string WigglyWebhook = "https://discord.com/api/webhooks/771647539467780116/-bAyLSwLeMZ-M3nVHK44AwosQt1JaLuFS-AzvrBSZ7fVskW-391KAnkvRaCWCRX0Rq0q";
        public const string UmbrellaWebhook = "https://discord.com/api/webhooks/771647677732749332/Qbz3aHmcW6ga3RXVASv17Kk2KH_xkZeKfmctQ4GyhyhpeqOp0pG3itO4VLq6ARDbuoLx";
        public const string SixringsWebhook = "https://discord.com/api/webhooks/774643692002213899/bJx7yXY-Cv71m-R1B5jV5sZB8D0hVw3G9CL9RcnXy6t3lDIeEMmMXcS_1YinZMttO-9H";
        public const string KozutohWebhook = "https://discord.com/api/webhooks/776864543871598602/C2NXZwK_ZAM1CUY5DywfyiaiMvmH7uVTShlno1a3broWXUl7hQw2ZyNnc4rMdMlxtzzN";

        public static void DoWebhooks(Player player, WorldRES world,string WorldInstanceID)
        {
            try
            {
                Dictionary<string, object> tictionary = (Dictionary<string, object>)player.CustomProperties["avatarDict"];
                var AvatarID = tictionary["id"];
                var AssetURL = tictionary["assetUrl"];
                var ReleaseStatus = tictionary["releaseStatus"];

                Dictionary<string, object> dictionary = (Dictionary<string, object>)player.CustomProperties["user"];
                var UserID = dictionary["id"];
                var Displayname = dictionary["displayName"];

                var UserFound = $" > **[--Wenga's Egirl--]** \n> **Player:** {Displayname}  [{UserID}]  \n> **World:** {world.name}  [{WorldInstanceID}]  \n> **AvatarID:** {AvatarID} [{ReleaseStatus}] \n> **AssetURL:** {AssetURL}";
                var StreamerFound = $" > **[--Wenga's Egirl--]** \n> **Streamer:** {Displayname}  [{UserID}]  \n> **World:** {world.name}  [{WorldInstanceID}]  \n> **AvatarID:** {AvatarID} [{ReleaseStatus}] \n> **AssetURL:** {AssetURL}";
                var AdminFound = $" > **[--Wenga's Egirl--]** \n> **Admin/Mod:** {Displayname}  [{UserID}]  \n> **World:** {world.name}  [{WorldInstanceID}]  \n> **AvatarID:** {AvatarID} [{ReleaseStatus}] \n> **AssetURL:** {AssetURL}";
                var CreatorFound = $" > **[--Wenga's Egirl--]** \n> **Creator:** {Displayname}  [{UserID}]  \n> **World:** {world.name}  [{WorldInstanceID}]  \n> **AvatarID:** {AvatarID} [{ReleaseStatus}] \n> **AssetURL:** {AssetURL}";

                if (File.ReadAllText("Access/Wenga.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found: " + Displayname);
                    SendWebHook(WengaWebhook, UserFound);
                }

                if (File.ReadAllText("Access/DayOfThePlay.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found: " + Displayname);
                    SendWebHook(GayClientWebhook, UserFound);
                }

                if (File.ReadAllText("UsersMod.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found Admin/Mod: " + Displayname);
                    SendWebHook(AdminWebhook, AdminFound);
                }

                if (File.ReadAllText("UsersStreamer.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found Streamer: " + Displayname);
                    SendWebHook(StreamerWebhook, StreamerFound);
                }

                if (File.ReadAllText("UsersAviCreator.txt").Contains(UserID.ToString()))
                {
                    Console.WriteLine("Found Creator: " + Displayname);
                    SendWebHook(AviCreatorWebhook, CreatorFound);
                }

                // SELL STUFF ONLY ADD AND REMOVE //
                if (File.ReadAllText("Access/Bigsmoke002.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(DickSmokeWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Jaypox.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(JaypoxWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Akeno.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(AkenoWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Catzii.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(CatziiWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Vx.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(VxWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/SexyToxiBuff.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(SexyToxiBuffWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Sypherr.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(SypherrWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Incognitoman.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(IncognitomanWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Toksin.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(ToksinWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Sirzechs.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(SirzechsWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/MircoPortmann.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(MircoPortmannWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Blank.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(BlankWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/APTX.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(APTXWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Forgetful.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(ForgetfulWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Danny.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(DannyWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Zozey.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(ZozeyWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Rias.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(RiasWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Schahoz.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(SchahozWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Pickel.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(PickelWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Night.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(NightWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Ying.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(YingWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Injection.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(InjectionWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Muffin.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(MuffinWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Tinny.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(TinnyWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Umbrella.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(UmbrellaWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Wiggly.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(WigglyWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Sixrings.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(SixringsWebhook, UserFound);
                    }
                }

                if (File.ReadAllText("Access/Kozutoh.txt").Contains(UserID.ToString()))
                {
                    if (File.ReadAllText("AntiSearch.txt").Contains(UserID.ToString()))
                    {
                        Console.WriteLine("Found Antisearch User: " + Displayname);
                    }
                    else
                    {
                        Console.WriteLine("Found: " + Displayname);
                        SendWebHook(KozutohWebhook, UserFound);
                    }
                }

            }
            catch (Exception)
            {
              
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
