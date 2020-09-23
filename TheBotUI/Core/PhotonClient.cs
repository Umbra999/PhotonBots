using ExitGames.Client.Photon;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using VRChatAPI;

namespace TheBotUI.Core 
{

    public class PhotonClient : LoadBalancingClient, IConnectionCallbacks, IInRoomCallbacks, ILobbyCallbacks, IMatchmakingCallbacks 
    {
        private readonly Thread photonThread;
        private readonly Thread handlerThread;
        public List<string> logs;
        public List<string> eventLogs;
        private Variables Variables;

        private readonly Hashtable SendInstantiateEvHashtable = new Hashtable();
        private RaiseEventOptions SendInstantiateRaiseEventOptions = new RaiseEventOptions();

        private int intervalDispatch = 10;
        private int lastDispatch = Environment.TickCount;
        private int intervalSend = 50;
        private int lastSend = Environment.TickCount;

        public PhotonClient(Variables variables, string releaseServer) : base(ConnectionProtocol.Udp) 
        {
            logs = new List<string>(150);
            eventLogs = new List<string>(75);
            Variables = variables;

            this.AppId = "bf0942f7-9935-4192-b359-f092fa85bef1";
            AppVersion = releaseServer;
            this.NameServerHost = "ns.exitgames.com";

            photonThread = new Thread(PhotonLoop);
            photonThread.IsBackground = true;
            photonThread.Start();

            CustomTypes.Register(this);

            handlerThread = new Thread(HandlerLoop);
            handlerThread.IsBackground = true;
            handlerThread.Start();

            this.AuthValues = new AuthenticationValues() {
                AuthType = CustomAuthenticationType.Custom
            };
            this.AuthValues.AddAuthParameter("token", Variables.AuthCookie);

            this.AddCallbackTarget(this);
            this.EventReceived += CustomOnEvent;
            this.StateChanged += OnStateChanged;
            this.OpResponseReceived += OnResponseReceived;

            if (this.ConnectToRegionMaster("usw")) 
            {
                Console.ForegroundColor
                    = ConsoleColor.Blue;
                Console.WriteLine("[WengaBOT] Connecting to usw..");
            }
            else 
            {
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Something went wrong while connecting to usw!");
            }
        }

        private void OnResponseReceived(OperationResponse opResponse) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine($"[WengaBOT] Response received: {opResponse.ToString()}");
        }

        private void OnStateChanged(ClientState before, ClientState now) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine($"[WengaBOT] Changed state from {before} to {now.ToString()}");
        }

        private void CustomOnEvent(EventData eventData) {
            byte evCode = eventData.Code;
            switch (evCode) {
                case 1:     //USpeak
                case 201:   //Unreliable PhotonView
                case 206:   //Reliable PhotonView
                    break;

                default:
                    eventLogs.Insert(0, eventData.ToStringFull());
                    break;
            }
        }

        private void PhotonLoop() {
            while (true) {
                DoPhotonStuff();
                Thread.Sleep(10);
            }
        }

        private void DoPhotonStuff() {
            if (Environment.TickCount - this.lastDispatch > this.intervalDispatch) {
                lastDispatch = Environment.TickCount;
                this.LoadBalancingPeer.DispatchIncomingCommands();
            }
            if (Environment.TickCount - this.lastSend > this.intervalSend) {
                lastSend = Environment.TickCount;
                this.LoadBalancingPeer.SendOutgoingCommands();
            }
        }

        private void HandlerLoop() {
            while (true) {
                DoHandlerStuff();
                Thread.Sleep(10);
            }
        }

        private void DoHandlerStuff() 
        {

        }

        public void OnConnected() 
        {
            Console.ForegroundColor
                    = ConsoleColor.Blue;
            Console.WriteLine("[WengaBOT] Connected to Photonserver");
        }

        public void OnConnectedToMaster() 
        {
            Console.ForegroundColor
                    = ConsoleColor.Blue;
            Console.WriteLine("[WengaBOT] Connected to Masterserver");
            Hashtable hashtable = new Hashtable() {
                { "user", new Dictionary<string, object>()
                    {
                        { "id", "avtr_b8ee959b-7d38-4287-a5b2-9545f238a4b9" }
                    }
                },
                { 
                    "avatarDict", new Dictionary<string, object>()
                    {
                        { "id", "avtr_b8ee959b-7d38-4287-a5b2-9545f238a4b9" }
                    }
                },
                { "modTag", "Wenga#0001"},
                { "isInvisible", false },
                { "avatarVariations", "avtr_b960b658-58fe-4210-a0b0-773a6aa1f3bc" },
                { "status", "offline" },
                { "statusDescription", "Wenga#0001" },
                { "inVRMode", true },
                { "showSocialRank", true },
                { "steamUserID", "1337" }
            };
            this.LocalPlayer.SetCustomProperties(hashtable);
            Console.WriteLine($"{(LocalPlayer.CustomProperties.Count > 0 ? $"[WengaBOT] Set CustomProperties! ({LocalPlayer.CustomProperties.Count})" : "[WengaBOT] No CustomProperties were set!")}");
        }

        

        

        public void OnDisconnected(DisconnectCause cause) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Disconnected Cause:" + cause + "-> Re-Auth Disabled");
        }

        public void OnRegionListReceived(RegionHandler regionHandler) 
        {
            
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("[WengaBOT] Received CustomAuthenticationResponse!" + data.ToStringFull());
        }

        public void OnCustomAuthenticationFailed(string debugMessage) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] CustomAuthentication failed! Message:" + (string.IsNullOrEmpty(debugMessage) + "N/A" + ":" + debugMessage));
        }

        public void OnPlayerEnteredRoom(Player newPlayer) 
        {
            Console.ForegroundColor
                    = ConsoleColor.DarkGreen;
            Console.WriteLine("[WengaBOT] " + newPlayer.NickName + "joined the room!");
        }

        public void OnPlayerLeftRoom(Player otherPlayer) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] " + otherPlayer.NickName + "left the room!");
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("[WengaBOT] The room properties have been updated.");
            //New props: propertiesThatChanged.ToStringFull()
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("[WengaBOT] " + targetPlayer.NickName + "changed PhotonProperties!");
            //New props:" + changedProps.ToStringFull())
        }

        public void OnMasterClientSwitched(Player newMasterClient) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("[WengaBOT] " + newMasterClient.NickName + "is the new Masterclient");
        }

        public void OnJoinedLobby() 
        {
            Console.ForegroundColor
                    = ConsoleColor.DarkGreen;
            Console.WriteLine("[WengaBOT] Bot joined the default lobby!");
        }

        public void OnLeftLobby() 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Bot left the default lobby!");
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList) 
        {

        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics) 
        {

        }

        public void OnFriendListUpdate(List<FriendInfo> friendList) 
        {

        }

        public void OnCreatedRoom() 
        {
            Console.ForegroundColor
                    = ConsoleColor.DarkGreen;
            Console.WriteLine("[WengaBOT] Bot created a room!");
        }

        public void OnCreateRoomFailed(short returnCode, string message) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine($"[WengaBOT] Failed to create room! Code: {returnCode} Message: {(string.IsNullOrEmpty(message) ? "N/A" : message)}");
        }

        public void OnJoinedRoom() 
        {
            Console.ForegroundColor
                    = ConsoleColor.DarkGreen;
            Console.WriteLine("[WengaBOT] Bot joined the room!");
        }

        public void OnJoinRoomFailed(short returnCode, string message) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine($"[WengaBOT] Failed to join room! Code: {returnCode} Message: {(string.IsNullOrEmpty(message) ? "N/A" : message)}");
        }

        public void OnJoinRandomFailed(short returnCode, string message) 
        {

        }

        public void OnLeftRoom() 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Bot left the room!");
        }

        public bool BanInstanciate() 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Account Banned");
            InstantiateParameters parameters = new InstantiateParameters("VRCPlayer",
                0,
                null,
                0,
                new int[3]
                {
                    int.Parse(this.LocalPlayer.ActorNumber + "00001"),
                    int.Parse(this.LocalPlayer.ActorNumber + "00002"),
                    int.Parse(this.LocalPlayer.ActorNumber + "99999")
                },
                this.LocalPlayer,
                this.LoadBalancingPeer.ServerTimeInMilliSeconds);

            //Instantiation ID
            int intID = parameters.viewIDs[0];

            SendInstantiateEvHashtable.Clear();
            SendInstantiateEvHashtable[(byte)0] = parameters.prefabName;
            if (parameters.viewIDs.Length > 1)
                SendInstantiateEvHashtable[(byte)4] = parameters.viewIDs;
            SendInstantiateEvHashtable[(byte)6] = parameters.timestamp;
            SendInstantiateEvHashtable[(byte)7] = intID;

            //Adding our instantiation to the Roomcache
            SendInstantiateRaiseEventOptions = RaiseEventOptions.Default;
            SendInstantiateRaiseEventOptions.CachingOption = EventCaching.AddToRoomCache;
            //Finally calling OpRaiseEvent to send it over the network
            return this.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendUnreliable);
        }

        public bool InstantiateSelf()
        {
            //Creating instantiate parameters
            Console.ForegroundColor
                = ConsoleColor.DarkGreen;
            Console.WriteLine("[WengaBOT] Instantiate Bot");
            InstantiateParameters parameters = new InstantiateParameters("VRCPlayer",
                0,
                null,
                0,
                new int[3]
                {
                    int.Parse(this.LocalPlayer.ActorNumber + "00001"),
                    int.Parse(this.LocalPlayer.ActorNumber + "00002"),
                    int.Parse(this.LocalPlayer.ActorNumber + "00003")
                },
                this.LocalPlayer,
                this.LoadBalancingPeer.ServerTimeInMilliSeconds);

            //Instantiation ID
            int intID = parameters.viewIDs[0];

            SendInstantiateEvHashtable.Clear();
            SendInstantiateEvHashtable[(byte)0] = parameters.prefabName;
            if (parameters.viewIDs.Length > 1)
                SendInstantiateEvHashtable[(byte)4] = parameters.viewIDs;
            SendInstantiateEvHashtable[(byte)6] = parameters.timestamp;
            SendInstantiateEvHashtable[(byte)7] = intID;

            //Adding our instantiation to the Roomcache
            SendInstantiateRaiseEventOptions = RaiseEventOptions.Default;
            SendInstantiateRaiseEventOptions.CachingOption = EventCaching.AddToRoomCache;
            //Finally calling OpRaiseEvent to send it over the network
            return this.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendUnreliable);
        }

        public bool InstantiateSelfInvis()
        {
            //Creating instantiate parameters
            Console.ForegroundColor
                = ConsoleColor.DarkGreen;
            Console.WriteLine("[WengaBOT] Instantiate Bot Invisible");
            InstantiateParameters parameters = new InstantiateParameters(
                "VRCPlayer",0,null,0,
                new int[3]
                {
                    int.Parse(this.LocalPlayer.ActorNumber + "00001"),
                    int.Parse(this.LocalPlayer.ActorNumber + "00002"),
                    int.Parse(this.LocalPlayer.ActorNumber + "00003")
                },
                this.LocalPlayer,
                this.LoadBalancingPeer.ServerTimeInMilliSeconds);

            //Instantiation ID
            int intID = parameters.viewIDs[0];

            SendInstantiateEvHashtable[(byte)0] = parameters.prefabName;
            if (parameters.viewIDs.Length > 1)
                SendInstantiateEvHashtable[(byte)4] = parameters.viewIDs;
            SendInstantiateEvHashtable[(byte)6] = parameters.timestamp;
            SendInstantiateEvHashtable[(byte)7] = intID;

            //Adding our instantiation to the Roomcache
            SendInstantiateRaiseEventOptions = new RaiseEventOptions();
            SendInstantiateRaiseEventOptions.TargetActors = new int[] { 0 };
            //Finally calling OpRaiseEvent to send it over the network
            return this.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendUnreliable);
        }
    }
    public struct InstantiateParameters {
        public int[] viewIDs;
        public byte objLevelPrefix;
        public object[] data;
        public byte @group;
        public string prefabName;
        public Player creator;
        public int timestamp;

        public InstantiateParameters(string prefabName, byte @group, object[] data, byte objLevelPrefix, int[] viewIDs, Player creator, int timestamp) {
            this.prefabName = prefabName;
            this.@group = @group;
            this.data = data;
            this.objLevelPrefix = objLevelPrefix;
            this.viewIDs = viewIDs;
            this.creator = creator;
            this.timestamp = timestamp;
        }
    }
}