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
#if NET472
using System.Diagnostics;
#endif

namespace TheBotUI {

    public partial class Form1 : Form {
        public Bot selectedBot;

        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) 
        {
            Console.ForegroundColor
            = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] All bots on the instance are disconnected!");
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
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
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
                                pingVarLabel.Text = selectedBot.PhotonClient.LoadBalancingPeer.RoundTripTime.ToString();
                                inRoomVarLabel.Text = selectedBot.PhotonClient.InRoom ? "Yes" : "No";
                                playersVarLabel.Text = selectedBot.PhotonClient.CurrentRoom != null && selectedBot.PhotonClient.CurrentRoom.PlayerCount > 0 ? selectedBot.PhotonClient.CurrentRoom.PlayerCount.ToString() : "N/A";
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
                                    if (Search)
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
                //new Thread(() => {
                //    while (true) {
                //        if (selectedBot.PhotonClient.logs.Count > 0 || selectedBot.PhotonClient.eventLogs.Count > 0) {
                //            //Invoke(new MethodInvoker(() => { logsList.Items.Clear(); }));
                //            List<ListViewItem> logs = new List<ListViewItem>(225);
                //            if (photonLogsRadioButton.Checked)
                //                foreach (string log in selectedBot.PhotonClient.logs.ToList()) {
                //                    ListViewItem l = new ListViewItem(log);
                //                    logs.Add(l);
                //                }
                //            if (eventLogsRadioButton.Checked)
                //                foreach (string log in selectedBot.PhotonClient.eventLogs) {
                //                    ListViewItem l = new ListViewItem(log);
                //                    logs.Add(l);
                //                }
                //            Invoke(new MethodInvoker(() => { logsList.Items.AddRange(logs.ToArray()); }));
                //            Thread.Sleep(5000);
                //        }
                //    }    
                //}).Start();
            }
        }
        public void OnDisconnected(DisconnectCause cause)
        {
            
        }

        public void NormalAuth_Click(object sender, EventArgs e) 
        // Default Auth, needs atleast 1 bot to connect to VRC Api
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
         //   string[] authdata = File.ReadAllLines("auth.txt");
            string secondLine = File.ReadLines(@"AuthNormal.txt").ElementAtOrDefault(0);
           // foreach (string login in secondLine)
            {
                string[] userpass = secondLine.Split(new char[] { ':' }, 2);
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
            Thread.Sleep(2000);
            {
                Console.ForegroundColor
                = ConsoleColor.Green;
                Console.WriteLine("API Cleaned");
                botInstancesList.Items.Clear();
                playerList.Items.Clear();
            }
            {
                Console.ForegroundColor
                = ConsoleColor.Blue;
                Console.WriteLine("Fully Cleaned");
                botInstancesList.Items.Clear();
                playerList.Items.Clear();
            }
            string[] authdata = File.ReadAllLines("AuthNormal.txt");
            foreach(string login in authdata) {
                string[] userpass = login.Split(new char[] { ':' }, 2);
                new Thread(() => {
                    Bot bot = new Bot(userpass[0], userpass[1]);
                    if (bot != null) {
                        if (bot.APIClient != null) {
                            Invoke(new MethodInvoker(() => {
                                ListViewItem item = new ListViewItem(bot.APIClient.Variables.UserSelfRES.displayName);
                                item.Tag = bot;
                                botInstancesList.Items.Add(item);
                            }));
                        }
                        else {
                            MessageBox.Show("[WengaBOT] API failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show("[WengaBOT] Bot failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }).Start();
            }
        }

        private void JoinRoomButton_Click(object sender, EventArgs e) 
        {
            EnterRoomParams enterRoomParams = new EnterRoomParams();
            enterRoomParams.RoomName = worldAInstanceIDTextBox.Text;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = Convert.ToByte(usernameTextBox.Text);
            roomOptions.MaxPlayers = Convert.ToByte(roomOptions.MaxPlayers * 2);
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            hashtable["name"] = worldAInstanceIDTextBox.Text;
            roomOptions.CustomRoomProperties = hashtable;
            enterRoomParams.RoomOptions = roomOptions;
            string[] customRoomPropertiesForLobby = new string[]
            {
                    "name"
            };
            roomOptions.CustomRoomPropertiesForLobby = customRoomPropertiesForLobby;
            roomOptions.EmptyRoomTtl = 0;
            roomOptions.DeleteNullProperties = false;
            roomOptions.PublishUserId = false;
            bool isJoined = selectedBot.PhotonClient.OpJoinOrCreateRoom(enterRoomParams);
            Console.WriteLine(isJoined ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
        }
        private void LeaveRoomButton_Click(object sender, EventArgs e) {
            if (selectedBot.PhotonClient.InRoom)
                selectedBot.PhotonClient.OpLeaveRoom(false);
            else
                MessageBox.Show("[WengaBOT] Can't leave room when not in a room!", "[WengaBOT] Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void JoinLastRoomButton_Click(object sender, EventArgs e)
        {
            EnterRoomParams enterRoomParams = new EnterRoomParams();
            enterRoomParams.RoomName = worldAInstanceIDTextBox.Text;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsOpen = true;
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = Convert.ToByte(usernameTextBox.Text);
            roomOptions.MaxPlayers = Convert.ToByte(roomOptions.MaxPlayers * 2);
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            hashtable["name"] = worldAInstanceIDTextBox.Text;
            roomOptions.CustomRoomProperties = hashtable;
            enterRoomParams.RoomOptions = roomOptions;
            string[] customRoomPropertiesForLobby = new string[]
            {
                    "name"
            };
            roomOptions.CustomRoomPropertiesForLobby = customRoomPropertiesForLobby;
            roomOptions.EmptyRoomTtl = 0;
            roomOptions.DeleteNullProperties = false;
            roomOptions.PublishUserId = false;
            bool isJoined = selectedBot.PhotonClient.OpJoinOrCreateRoom(enterRoomParams);
            Console.WriteLine(isJoined ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
            InstantiateButton_Click(null, null);
        }
        private void InstantiateButton_Click(object sender, EventArgs e) 
        {
            if (selectedBot.PhotonClient.InRoom) 
            {
                selectedBot.PhotonClient.InstantiateSelf();
            }
        }

        private void InstantiateInvisButton_Click(object sender, EventArgs e) {
            if (selectedBot.PhotonClient.InRoom) 
            {
                selectedBot.PhotonClient.InstantiateSelfInvis();
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
                            var bot = (Bot)item.Tag;
                            EnterRoomParams enterRoomParams = new EnterRoomParams();
                            enterRoomParams.RoomName = worldAInstanceIDTextBox.Text;
                            RoomOptions roomOptions = new RoomOptions();
                            roomOptions.IsOpen = true;
                            roomOptions.IsVisible = true;
                            roomOptions.MaxPlayers = Convert.ToByte(usernameTextBox.Text);
                            roomOptions.MaxPlayers = Convert.ToByte(roomOptions.MaxPlayers * 2);
                            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                            hashtable["name"] = worldAInstanceIDTextBox.Text;
                            roomOptions.CustomRoomProperties = hashtable;
                            enterRoomParams.RoomOptions = roomOptions;
                            string[] customRoomPropertiesForLobby = new string[]
                            {
                                   "name"
                            };
                            roomOptions.CustomRoomPropertiesForLobby = customRoomPropertiesForLobby;
                            roomOptions.EmptyRoomTtl = 0;
                            roomOptions.DeleteNullProperties = true;
                            roomOptions.PublishUserId = false;
                            bool isJoined = bot.PhotonClient.OpJoinOrCreateRoom(enterRoomParams);
                            Console.WriteLine(isJoined ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
                            Thread.Sleep(100);
                        }
                    }));
                }).Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.ForegroundColor
            = ConsoleColor.Red;
            Console.WriteLine("[WengaBOT] All bots on the instance are disconnected!");
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
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void button5_Click(object sender, EventArgs e)
        {
          //  for (; ; )
            new Thread(() =>
            {
                for (; ; )
                foreach (ListViewItem item in botInstancesList.Items)
                {
                    var bot = (Bot)item.Tag;
                    if (bot.PhotonClient.InRoom)
                    {
                        Thread.Sleep(500);
                        bot.QQUspeakExploit(Convert.ToByte(textBox1.Text));
                    }
                }   
                
            })
            { IsBackground = true }.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            {
                if (selectedBot != null)
                {
                    EnterRoomParams enterRoomParams = new EnterRoomParams();
                    enterRoomParams.RoomName = worldAInstanceIDTextBox.Text;
                    RoomOptions roomOptions = new RoomOptions();
                    roomOptions.IsOpen = true;
                    roomOptions.IsVisible = true;
                    roomOptions.MaxPlayers = Convert.ToByte(usernameTextBox.Text);
                    roomOptions.MaxPlayers = Convert.ToByte(roomOptions.MaxPlayers * 2);
                    System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                    hashtable["name"] = worldAInstanceIDTextBox.Text;
                    roomOptions.CustomRoomProperties = hashtable;
                    enterRoomParams.RoomOptions = roomOptions;
                    string[] customRoomPropertiesForLobby = new string[]
                    {
                    "name"
                    };
                    roomOptions.CustomRoomPropertiesForLobby = customRoomPropertiesForLobby;
                    roomOptions.EmptyRoomTtl = 0;
                    roomOptions.DeleteNullProperties = false;
                    roomOptions.PublishUserId = false;
                    bool isJoined = selectedBot.PhotonClient.OpJoinOrCreateRoom(enterRoomParams);
                    Console.WriteLine(isJoined ? "[WengaBOT] Successfully joined to room!" : "[WengaBOT] JoinOrCreateRoom failed!");
                }
                Thread.Sleep(3000);
                //ggStream
                string toShow = "CurrentDate:" + DateTime.Now + "\nWorldID:" + worldAInstanceIDTextBox.Text + "\nPlayerCount:" + selectedBot.PhotonClient.CurrentRoom.PlayerCount.ToString() + "\n";
                //  string tDShow = "";
                foreach (var item in selectedBot.PhotonClient.CurrentRoom.Players)
                {
                    //avatarVariations
                    Dictionary<string, object> dictionary = (Dictionary<string, object>)item.Value.CustomProperties["user"];
                    Dictionary<string, object> tictionary = (Dictionary<string, object>)item.Value.CustomProperties["avatarDict"];
                    /*Dictionary<string, object> pictionary = (Dictionary<string, object>)item.Value.CustomProperties["steamUserID"];*///statusDescription steamUserID
                    //Dictionary<string, object> eictionary = (Dictionary<string, object>)item.Value.CustomProperties["steamUserID"];
                    toShow += dictionary["displayName"].ToString() + "\nUserID:" + dictionary["id"].ToString() + "\nAvatarID:" + tictionary["id"].ToString() + "\n--------------------------------------------------------------------------------\n";
                    // tDShow +=  tictionary["id"].ToString() + "\n";
                }
                MessageBox.Show(toShow, "Users on an instance:", MessageBoxButtons.OK, MessageBoxIcon.None);
                //    DateTime dateTime = new DateTime();
                string tath = @"InstanceCheckLog\\" + DateTime.Now.ToString("dd/MM") + ".txt";
                //string path = @"InstanceCheckLog\\" + DateTime.Now.ToString("dd/MM_HH");

                if (!File.Exists(tath))
                {
                    string[] createText = { "WengaBOT Logger" };
                    File.WriteAllLines(tath, createText);
                }

                string appendText = toShow + Environment.NewLine;
                File.AppendAllText(tath, appendText);

                // Open the file to read from.
                string[] readText = File.ReadAllLines(tath);
                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }
                {
                    Console.ForegroundColor
                    = ConsoleColor.Red;
                    Console.WriteLine("[WengaBOT] Leaving Room");
                    Console.ForegroundColor
                    = ConsoleColor.White;
                    selectedBot.PhotonClient.OpLeaveRoom(false);
                    playerList.Items.Clear();
                }
                //selectedBot.PhotonClient.Send253event();
                //selectedBot.PhotonClient.InstantiateSelfInvis();
                //if (selectedBot.PhotonClient.InRoom)
            }
        }
        public bool Search = false;
        private void Searchbutton_Click(object sender, EventArgs e)
        {
            SearchFunc();
        }
        public async void SearchFunc()
        {
            try
            {
                string[] Worlds = File.ReadAllLines(@"Worlds.txt");
                Search = true;
                Console.ForegroundColor
                    = ConsoleColor.Cyan;
                foreach (string worldID in Worlds)
                {
                    Thread.Sleep(3000);
                    Console.ForegroundColor
                                = ConsoleColor.Cyan;
                    WorldRES worldRES = await VRChatAPI.Endpoints.Worlds.GetWorld(worldID);
                    Console.WriteLine("[WengaBOT] Searching World: " + worldID + "  |name: " + worldRES.name + "   |Instances: " + worldRES.instances.Length);
                    if (worldRES.publicOccupants != 0)
                    {
                        Thread.Sleep(1500);
                        List<string> Instances = new List<string>();
                        foreach (object instanceObj in worldRES.instances)
                        {
                            Console.ForegroundColor
                                = ConsoleColor.Cyan;
                            Console.WriteLine("[WengaBOT] INSTANCE: " + instanceObj.ToString().Split(',')[0].Replace("[", "").Replace('"', ' '));
                            Instances.Add(float.Parse(instanceObj.ToString().Split(',')[0].Replace("[", "").Replace('"', ' '),System.Globalization.NumberStyles.Integer).ToString());
                        }
                        foreach (string Instance in Instances)
                        {
                            Console.ForegroundColor
                                = ConsoleColor.Cyan;
                            Console.WriteLine("[WengaBOT] Joining: " + worldID + ":" + Instance + " Cap: " + Convert.ToString(worldRES.capacity));
                            JoinRoom(worldRES, worldID + ":" + Instance);
                            Thread.Sleep(1500);
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
                        }
                    }
                    else
                    {
                        Thread.Sleep(800);
                    }
                }
                Console.WriteLine("----Search Stopped----");
                Search = false;
            }
            catch (Exception e5)
            {
                Console.WriteLine(e5.ToString());
            }
            SearchFunc();
        }
        public void JoinRoom(WorldRES world, string WorldInstanceID)
        {
            try
            {
                if (selectedBot != null)
                {
                    EnterRoomParams enterRoomParams = new EnterRoomParams();
                    enterRoomParams.RoomName = WorldInstanceID;
                    RoomOptions roomOptions = new RoomOptions();
                    roomOptions.IsOpen = true;
                    roomOptions.IsVisible = true;
                    roomOptions.MaxPlayers = Convert.ToByte(world.capacity * 2);
                    System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                    hashtable["name"] = world.id;
                    roomOptions.CustomRoomProperties = hashtable;
                    enterRoomParams.RoomOptions = roomOptions;
                    string[] customRoomPropertiesForLobby = new string[]
                    {
                    "name"
                    };
                    roomOptions.CustomRoomPropertiesForLobby = customRoomPropertiesForLobby;
                    roomOptions.EmptyRoomTtl = 0;
                    roomOptions.DeleteNullProperties = false;
                    roomOptions.PublishUserId = false;
                    bool isJoined = selectedBot.PhotonClient.OpJoinOrCreateRoom(enterRoomParams);
                    Thread.Sleep(3000);
                    Console.ForegroundColor
                        = ConsoleColor.Green;
                    Console.WriteLine("[WengaBOT] Instanciating all Bots");
                    if (selectedBot.PhotonClient.InRoom)
                    {
                        selectedBot.PhotonClient.InstantiateSelf();
                    }
                    Thread.Sleep(1500);
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
                    foreach (var item in selectedBot.PhotonClient.CurrentRoom.Players)
                    {
                        //avatarVariations
                        Dictionary<string, object> dictionary = (Dictionary<string, object>)item.Value.CustomProperties["user"];
                        /*Dictionary<string, object> pictionary = (Dictionary<string, object>)item.Value.CustomProperties["steamUserID"];*///statusDescription steamUserID
                                                                                                                                           //Dictionary<string, object> eictionary = (Dictionary<string, object>)item.Value.CustomProperties["steamUserID"];
                        var UserID = dictionary["id"];
                        if (File.ReadAllText("CSWenga.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755116773568938046/Ex_z8B5UuoE4_3K9uUKUceRPYnawtHfaM8X7ptde2l30SoqqxvJVElmcv1ZtrtGstwDJ", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }

                        if (File.ReadAllText("UsersMod.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755118582207086602/zjkJZI8VCcSiHUO5mOkYyTz4lxLNiPdi2kgsCkAeXLJ7g1lriVQCiaAyzJlUc86r3QAq", "[Wenga's Egirl] Found Moderator/Admin: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }

                        if (File.ReadAllText("UsersStreamer.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755119944852701235/4nuvJwP6XMiSaJp2C0pQjQ47h7wEMHv7-zLCn6hZmpZVRuJ4ngef1NEpIHzezw9UOpxI", "[Wenga's Egirl] Found Streamer: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }


                        // SELL STUFF ONLY ADD AND REMOVE //

                        if (File.ReadAllText("CSBigsmoke002.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755140836789846057/vaOWcGbThUHq_89bldjSDYaxBPUUVu8sxLE3jyVL1DBkObe-GZa1thsL5By0nstsecMY", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }

                        if (File.ReadAllText("CSJaypox.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755141107507134497/H6WesOAl55Ho5LDB_istpHdLlv4_Z_ZBO2K-bRb8n_UAqMcjg5rMaNiQ8iF_ZpRFrCfy", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }

                        if (File.ReadAllText("CSDayOfThePlay.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/757270851077931089/NgaMCNA6jNwRhkf59FjvDPUrxYkrUQmb5dF9xLhxlykbdkoZvjRlLiM1y0MCSKjnEss9", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }

                        if (File.ReadAllText("CSAkeno.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755141542145949797/TvMTcp5kBGADnvU0yixnAYWTeTbXa6FTamr2G4tHyDyo2FZjsItN-F7gy4y6R3XdJKdM", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }

                        if (File.ReadAllText("CSCatzii.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755141744047161444/R073aNP_DTrlMX6iDdxCqQ1iJol7TKSPIMWf0HPPZm5aZNPSf8ECA9b3bn2dqALlgKPZ", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }

                        if (File.ReadAllText("CSVx.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755149168858628127/xsgP0S3GklgPSd0H1yqkj389eqJIcC6SekCRtzgbgOJyihUdOAsCZ_9uBqoWCdqTI_k5", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }
                        if (File.ReadAllText("CSSexyToxiBuff.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755435782440878202/SKPQk-uQctaatpuiYlPhYHqpFsYtKFi4-qnqKYwSFpPeS3tDn7_3gldMx5BIkl6SVtnO", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }
                        if (File.ReadAllText("CSSypherr.txt").Contains(UserID.ToString()))
                        {
                            Console.WriteLine("Found: " + dictionary["displayName"].ToString());
                            SendWebHook("https://discord.com/api/webhooks/755141259458379887/nLP07lChyLOM3-fnnFoSx716151-E1932cuQ5wHeKltoRb2Eg3D8KKMEeAyMDbv1xrO8", "[Wenga's Egirl] Found Player: " + dictionary["displayName"].ToString() + "  | in: " + world.name + "  [" + WorldInstanceID + "]");
                        }
                    }
                }
                Thread.Sleep(3000);
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
                Thread.Sleep(1500);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void buttonSearchAuth_Click(object sender, EventArgs e)
            //Replace this with Authcookie stuff
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
                //   string[] authdata = File.ReadAllLines("auth.txt");
                string secondLine = File.ReadLines(@"AuthSearch.txt").ElementAtOrDefault(0);
                // foreach (string login in secondLine)
                {
                    string[] userpass = secondLine.Split(new char[] { ':' }, 2);
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
                Thread.Sleep(2000);
                {
                    Console.ForegroundColor
                    = ConsoleColor.Green;
                    Console.WriteLine("API Cleaned");
                    botInstancesList.Items.Clear();
                    playerList.Items.Clear();
                }
                {
                    Console.ForegroundColor
                    = ConsoleColor.Blue;
                    Console.WriteLine("Fully Cleaned");
                    botInstancesList.Items.Clear();
                    playerList.Items.Clear();
                }
                string[] authdata = File.ReadAllLines("AuthSearch.txt");
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

        private void CrashSearch_Click(object sender, EventArgs e)
        {
            CrashSearchFunc();
        }

        public async void CrashSearchFunc()
        {
            try
            {
                string[] Worlds = File.ReadAllLines(@"WorldsCrash.txt");
                Search = true;
                Console.ForegroundColor
                    = ConsoleColor.Cyan;
                foreach (string worldID in Worlds)
                {
                    Thread.Sleep(3000);
                    Console.ForegroundColor
                                = ConsoleColor.Cyan;
                    WorldRES worldRES = await VRChatAPI.Endpoints.Worlds.GetWorld(worldID);
                    Console.WriteLine("[WengaBOT] Searching World: " + worldID + "  |name: " + worldRES.name + "   |Instances: " + worldRES.instances.Length);
                    if (worldRES.publicOccupants != 0)
                    {
                        Thread.Sleep(1500);
                        List<string> Instances = new List<string>();
                        foreach (object instanceObj in worldRES.instances)
                        {
                            Console.ForegroundColor
                                = ConsoleColor.Cyan;
                            Console.WriteLine("[WengaBOT] INSTANCE: " + instanceObj.ToString().Split(',')[0].Replace("[", "").Replace('"', ' '));
                            Instances.Add(float.Parse(instanceObj.ToString().Split(',')[0].Replace("[", "").Replace('"', ' '), System.Globalization.NumberStyles.Integer).ToString());
                        }
                        foreach (string Instance in Instances)
                        {
                            Console.ForegroundColor
                                = ConsoleColor.Cyan;
                            Console.WriteLine("[WengaBOT] Joining: " + worldID + ":" + Instance + " Cap: " + Convert.ToString(worldRES.capacity));
                            CrashJoinRoom(worldRES, worldID + ":" + Instance);
                            Thread.Sleep(1500);
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
                        }
                    }
                    else
                    {
                        Thread.Sleep(800);
                    }
                }
                Console.WriteLine("----Search Stopped----");
                Search = false;
            }
            catch (Exception e5)
            {
                Console.WriteLine(e5.ToString());
            }
            CrashSearchFunc();
        }
        public void CrashJoinRoom(WorldRES world, string WorldInstanceID)
        {
            try
            {
                if (selectedBot != null)
                {
                    EnterRoomParams enterRoomParams = new EnterRoomParams();
                    enterRoomParams.RoomName = WorldInstanceID;
                    RoomOptions roomOptions = new RoomOptions();
                    roomOptions.IsOpen = true;
                    roomOptions.IsVisible = true;
                    roomOptions.MaxPlayers = Convert.ToByte(world.capacity * 2);
                    System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                    hashtable["name"] = world.id;
                    roomOptions.CustomRoomProperties = hashtable;
                    enterRoomParams.RoomOptions = roomOptions;
                    string[] customRoomPropertiesForLobby = new string[]
                    {
                    "name"
                    };
                    roomOptions.CustomRoomPropertiesForLobby = customRoomPropertiesForLobby;
                    roomOptions.EmptyRoomTtl = 0;
                    roomOptions.DeleteNullProperties = false;
                    roomOptions.PublishUserId = false;
                    bool isJoined = selectedBot.PhotonClient.OpJoinOrCreateRoom(enterRoomParams);
                    Thread.Sleep(3000);
                    Console.ForegroundColor
                        = ConsoleColor.Green;
                    Console.WriteLine("[WengaBOT] Instanciating all Bots");
                    if (selectedBot.PhotonClient.InRoom)
                    {
                        selectedBot.PhotonClient.InstantiateSelf();
                    }
                    Thread.Sleep(6500);
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
                Thread.Sleep(3000);
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
                Thread.Sleep(1500);
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
            if(!id.Contains("usr_"))
                Console.WriteLine("[WengaBOT]" + id + " Is not a Valid User Id");
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

        public void GetAppVersion()
        {
            FetchLatestAppVersion();
        }

        public void FetchLatestAppVersion()
        {
            var copycat = new LoadBalancingClient();
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
                                    copycat.AppVersion = arr[1] + "_2.5";
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
            //Day add Stuff here <3
        }
    }
}