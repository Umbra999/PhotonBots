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
    public class SearchWebhooks
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

    }
}
