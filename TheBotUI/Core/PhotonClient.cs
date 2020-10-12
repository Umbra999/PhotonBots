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
            this.EventReceived += Form1.CustomOnEvent;
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

        public bool JoinRoom(string roomdata)
        {
            string[] tempSplit = roomdata.Split(':');
            int cap = VRChatAPI.Endpoints.Worlds.FetchRoomCap(tempSplit[0]);

            EnterRoomParams enterRoomParams = new EnterRoomParams
            {
                CreateIfNotExists = true,
                RoomName = roomdata
            };
            RoomOptions roomOptions = new RoomOptions
            {
                IsOpen = true,
                IsVisible = true,
                MaxPlayers = Convert.ToByte(cap * 2)
            };
            Hashtable hashtable = new Hashtable
            {
                ["name"] = "name"
            };
            roomOptions.CustomRoomProperties = hashtable;
            enterRoomParams.RoomOptions = roomOptions;
            string[] customroompropertiesforlobby = new string[]
            {
                "name"
            };
            roomOptions.CustomRoomPropertiesForLobby = customroompropertiesforlobby;
            roomOptions.EmptyRoomTtl = 0;
            roomOptions.DeleteNullProperties = true;
            roomOptions.PublishUserId = false;
            return OpJoinRoom(enterRoomParams);
        }
        private void OnResponseReceived(OperationResponse opResponse) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine($"[WengaBOT] Response received: {opResponse}");
        }

        private void OnStateChanged(ClientState before, ClientState now) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine($"[WengaBOT] Changed state from {before} to {now}");
        }

        private void CustomOnEvent(EventData eventData) 
        {
            byte evCode = eventData.Code;
            switch (evCode) 
            {
                case 1:     //USpeak
                case 201:   //Unreliable PhotonView
                case 206:   //Reliable PhotonView
                    break;

                default:
                    eventLogs.Insert(0, eventData.ToStringFull());
                    break;
            }
        }

        private void PhotonLoop() 
        {
            while (true) 
            {
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
            while (true) 
            {
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
                        { "id", Variables.UserSelfRES.id }
                    }
                },
                { 
                    "avatarDict", new Dictionary<string, object>()
                    {
                        { "id", Variables.UserSelfRES.currentAvatar }
                    }
                },
                { "modTag", ""},
                { "isInvisible", false },
                { "avatarVariations", Variables.UserSelfRES.currentAvatar },
                { "status", "active" },
                { "statusDescription", "Wenga#0666" },
                { "inVRMode", true },
                { "showSocialRank", true },
                { "steamUserID", "1337" }
            };
            this.LocalPlayer.SetCustomProperties(hashtable);
            Console.WriteLine($"{(LocalPlayer.CustomProperties.Count > 0 ? $"[WengaBOT] Set CustomProperties! ({LocalPlayer.CustomProperties.Count})" : "[WengaBOT] No CustomProperties were set!")}");
        }


        public void OnDisconnected(DisconnectCause cause) 
        {
            if (GlobalVars.Search)
            {
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Disconnected while Search Cause:" + cause + "-> Re-Auth (Master Only)");
                //Form1.SendWebHook("https://discordapp.com/api/webhooks/758563365534302220/6RBmwDCRbeikeRwnKCkVtuR6Qi5Ha97h11y6NwLP4AO10s24UkU_n25tI5NPl5zn7jO3", "[WengaBOT ERROR] Bot disconnected while searching cause: " + (cause) + " -> Re-Auth");
                ReconnectToMaster();
            }
            else if (GlobalVars.Desync)
            {
                // Add Auto Rejoin world 
                Console.ForegroundColor
                = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Disconnected while Desync Cause:" + cause + "-> Re-Auth (Master Only");
                ReconnectToMaster();
            }
            else if (Form1.Disconnecting)
            {
                Console.ForegroundColor
                = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Disconnected while Disconnect Cause:" + cause + "-> Re-Auth (Master Only)");
                ReconnectToMaster();
            }
            else
            {
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Disconnected Random Cause:" + cause + "-> Re-Auth (Master Only)");
                //Form1.SendWebHook("https://discordapp.com/api/webhooks/758563365534302220/6RBmwDCRbeikeRwnKCkVtuR6Qi5Ha97h11y6NwLP4AO10s24UkU_n25tI5NPl5zn7jO3", "[WengaBOT ERROR] Bot disconnected random cause: " + (cause) + " -> Re-Auth");
                ReconnectToMaster();
            }
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
            Console.WriteLine("[WengaBOT] " + newPlayer.GetDisplayName() + " [" + newPlayer.ActorNumber + "]" + " joined the room!");
        }

        public void OnPlayerLeftRoom(Player otherPlayer) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] " + otherPlayer.GetDisplayName() + " [" + otherPlayer.ActorNumber + "]" + " left the room!");
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
            Console.WriteLine("[WengaBOT] " + targetPlayer.GetDisplayName() + " [" + targetPlayer.ActorNumber + "]" + " changed PhotonProperties");
            //New props:" + changedProps.ToStringFull())
        }

        public void OnMasterClientSwitched(Player newMasterClient) 
        {
            if (Form1.MasterDesync)
            {
                Console.ForegroundColor
                    = ConsoleColor.Yellow;
                Console.WriteLine("[WengaBOT] " + newMasterClient.GetDisplayName() + " [" + newMasterClient.ActorNumber + "]" + " is the new Masterclient");
                OpLeaveRoom(false);
            }
            else
            {
                Console.ForegroundColor
                    = ConsoleColor.Yellow;
                Console.WriteLine("[WengaBOT] " + newMasterClient.GetDisplayName() + " [" + newMasterClient.ActorNumber + "]" + " is the new Masterclient");
            }
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
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("[WengaBOT] Room list updated!");
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("[WengaBOT] Lobby stats updated!");
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("[WengaBOT] Friends list updated!");
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
            Console.WriteLine($"[WengaBOT] Bot failed to create room! Code: {returnCode} Message: {(string.IsNullOrEmpty(message) ? "N/A" : message)}");
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
            Console.WriteLine($"[WengaBOT] Bot failed to join room! Code: {returnCode} Message: {(string.IsNullOrEmpty(message) ? "N/A" : message)}");
        }

        public void OnJoinRandomFailed(short returnCode, string message) 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Bot failed to join random room!");
        }

        public void OnLeftRoom() 
        {
            Console.ForegroundColor
                    = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Bot left the room!");
        }

        public bool BanInstanciate()
        {
            //Creating instantiate parameters
            Console.ForegroundColor
                = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Account Banned");
            InstantiateParameters parameters = new InstantiateParameters(
                "VRCPlayer", 0, null, 0,
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
            return this.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendReliable);
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