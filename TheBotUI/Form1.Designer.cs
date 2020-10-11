using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using TheBotUI.CustomComponents;

namespace TheBotUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AdressVarLabel = new System.Windows.Forms.Label();
            this.OpenVarLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ServerVarLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.connectionStatusVarLabel = new System.Windows.Forms.Label();
            this.MasterVarLabel = new System.Windows.Forms.Label();
            this.pingLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pingVarLabel = new System.Windows.Forms.Label();
            this.inRoomLabel = new System.Windows.Forms.Label();
            this.inRoomVarLabel = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.playersVarLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.loginViaTXTButton = new System.Windows.Forms.Button();
            this.loginToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.roomsLabel = new System.Windows.Forms.Label();
            this.worldAInstanceIDLabel = new System.Windows.Forms.Label();
            this.worldAInstanceIDTextBox = new System.Windows.Forms.TextBox();
            this.joinRoomButton = new System.Windows.Forms.Button();
            this.leaveRoomButton = new System.Windows.Forms.Button();
            this.joinLastRoomButton = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.inRoomActions = new System.Windows.Forms.Label();
            this.instantiateButton = new System.Windows.Forms.Button();
            this.instantiateInvisButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.buttonTokenAuth = new System.Windows.Forms.Button();
            this.CrashSearch = new System.Windows.Forms.Button();
            this.DerankButton = new System.Windows.Forms.Button();
            this.DerankInput = new System.Windows.Forms.TextBox();
            this.BanExploit = new System.Windows.Forms.Button();
            this.UpdateRelease = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SwitchAvi = new System.Windows.Forms.Button();
            this.AvatarSwitchText = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.JoinAll = new System.Windows.Forms.Button();
            this.MasterDisconnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.RegionVarLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ConnectionVarLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AllPlayersVarLabel = new System.Windows.Forms.Label();
            this.AllRoomsVarLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AllMasterVarLabel = new System.Windows.Forms.Label();
            this.Master = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.playerList = new TheBotUI.CustomComponents.CustomListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.botInstancesList = new TheBotUI.CustomComponents.CustomListView();
            this.botInstances = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            EventLogger = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Image = global::TheBotUI.Properties.Resources.minimize;
            this.minimizeButton.Location = new System.Drawing.Point(1579, 9);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(56, 39);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AdressVarLabel);
            this.panel2.Controls.Add(this.OpenVarLabel);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.ServerVarLabel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.exitButton);
            this.panel2.Controls.Add(this.minimizeButton);
            this.panel2.Controls.Add(this.settingsButton);
            this.panel2.Controls.Add(this.connectionStatusLabel);
            this.panel2.Controls.Add(this.connectionStatusVarLabel);
            this.panel2.Controls.Add(this.MasterVarLabel);
            this.panel2.Controls.Add(this.pingLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pingVarLabel);
            this.panel2.Controls.Add(this.inRoomLabel);
            this.panel2.Controls.Add(this.inRoomVarLabel);
            this.panel2.Controls.Add(this.playersLabel);
            this.panel2.Controls.Add(this.playersVarLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1708, 76);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // AdressVarLabel
            // 
            this.AdressVarLabel.AutoSize = true;
            this.AdressVarLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdressVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.AdressVarLabel.Location = new System.Drawing.Point(493, 48);
            this.AdressVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AdressVarLabel.Name = "AdressVarLabel";
            this.AdressVarLabel.Size = new System.Drawing.Size(0, 19);
            this.AdressVarLabel.TabIndex = 78;
            // 
            // OpenVarLabel
            // 
            this.OpenVarLabel.AutoSize = true;
            this.OpenVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.OpenVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.OpenVarLabel.Location = new System.Drawing.Point(1316, 21);
            this.OpenVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OpenVarLabel.Name = "OpenVarLabel";
            this.OpenVarLabel.Size = new System.Drawing.Size(51, 27);
            this.OpenVarLabel.TabIndex = 66;
            this.OpenVarLabel.Text = "N/A";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(1229, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 27);
            this.label10.TabIndex = 65;
            this.label10.Text = "Open:";
            // 
            // ServerVarLabel
            // 
            this.ServerVarLabel.AutoSize = true;
            this.ServerVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.ServerVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ServerVarLabel.Location = new System.Drawing.Point(1170, 21);
            this.ServerVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerVarLabel.Name = "ServerVarLabel";
            this.ServerVarLabel.Size = new System.Drawing.Size(51, 27);
            this.ServerVarLabel.TabIndex = 64;
            this.ServerVarLabel.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(1073, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 27);
            this.label5.TabIndex = 63;
            this.label5.Text = "Visible:";
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::TheBotUI.Properties.Resources.close;
            this.exitButton.Location = new System.Drawing.Point(1635, 9);
            this.exitButton.Margin = new System.Windows.Forms.Padding(0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(56, 39);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Image = global::TheBotUI.Properties.Resources.settings;
            this.settingsButton.Location = new System.Drawing.Point(19, 18);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(56, 39);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.connectionStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectionStatusLabel.Location = new System.Drawing.Point(96, 21);
            this.connectionStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(88, 27);
            this.connectionStatusLabel.TabIndex = 17;
            this.connectionStatusLabel.Text = "Status:";
            // 
            // connectionStatusVarLabel
            // 
            this.connectionStatusVarLabel.AutoSize = true;
            this.connectionStatusVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.connectionStatusVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.connectionStatusVarLabel.Location = new System.Drawing.Point(183, 21);
            this.connectionStatusVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatusVarLabel.Name = "connectionStatusVarLabel";
            this.connectionStatusVarLabel.Size = new System.Drawing.Size(51, 27);
            this.connectionStatusVarLabel.TabIndex = 18;
            this.connectionStatusVarLabel.Text = "N/A";
            // 
            // MasterVarLabel
            // 
            this.MasterVarLabel.AutoSize = true;
            this.MasterVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.MasterVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.MasterVarLabel.Location = new System.Drawing.Point(999, 21);
            this.MasterVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MasterVarLabel.Name = "MasterVarLabel";
            this.MasterVarLabel.Size = new System.Drawing.Size(51, 27);
            this.MasterVarLabel.TabIndex = 62;
            this.MasterVarLabel.Text = "N/A";
            // 
            // pingLabel
            // 
            this.pingLabel.AutoSize = true;
            this.pingLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.pingLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pingLabel.Location = new System.Drawing.Point(344, 21);
            this.pingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pingLabel.Name = "pingLabel";
            this.pingLabel.Size = new System.Drawing.Size(68, 27);
            this.pingLabel.TabIndex = 19;
            this.pingLabel.Text = "Ping:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(877, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 27);
            this.label3.TabIndex = 61;
            this.label3.Text = "MasterID:";
            // 
            // pingVarLabel
            // 
            this.pingVarLabel.AutoSize = true;
            this.pingVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.pingVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.pingVarLabel.Location = new System.Drawing.Point(420, 21);
            this.pingVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pingVarLabel.Name = "pingVarLabel";
            this.pingVarLabel.Size = new System.Drawing.Size(51, 27);
            this.pingVarLabel.TabIndex = 20;
            this.pingVarLabel.Text = "N/A";
            // 
            // inRoomLabel
            // 
            this.inRoomLabel.AutoSize = true;
            this.inRoomLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.inRoomLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inRoomLabel.Location = new System.Drawing.Point(492, 21);
            this.inRoomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inRoomLabel.Name = "inRoomLabel";
            this.inRoomLabel.Size = new System.Drawing.Size(109, 27);
            this.inRoomLabel.TabIndex = 21;
            this.inRoomLabel.Text = "In Room:";
            // 
            // inRoomVarLabel
            // 
            this.inRoomVarLabel.AutoSize = true;
            this.inRoomVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.inRoomVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.inRoomVarLabel.Location = new System.Drawing.Point(609, 21);
            this.inRoomVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inRoomVarLabel.Name = "inRoomVarLabel";
            this.inRoomVarLabel.Size = new System.Drawing.Size(51, 27);
            this.inRoomVarLabel.TabIndex = 22;
            this.inRoomVarLabel.Text = "N/A";
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.playersLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playersLabel.Location = new System.Drawing.Point(687, 21);
            this.playersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(99, 27);
            this.playersLabel.TabIndex = 23;
            this.playersLabel.Text = "Players:";
            // 
            // playersVarLabel
            // 
            this.playersVarLabel.AutoSize = true;
            this.playersVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.playersVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.playersVarLabel.Location = new System.Drawing.Point(794, 21);
            this.playersVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playersVarLabel.Name = "playersVarLabel";
            this.playersVarLabel.Size = new System.Drawing.Size(51, 27);
            this.playersVarLabel.TabIndex = 24;
            this.playersVarLabel.Text = "N/A";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.infoLabel.ForeColor = System.Drawing.Color.Lime;
            this.infoLabel.Location = new System.Drawing.Point(1669, 84);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(21, 23);
            this.infoLabel.TabIndex = 16;
            this.infoLabel.Text = "?";
            this.loginToolTip.SetToolTip(this.infoLabel, "1 = Userpass Auth Only\r\n2 = Token Auth Only");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel4.Location = new System.Drawing.Point(563, 84);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(11, 811);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel5.Location = new System.Drawing.Point(576, 734);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1124, 5);
            this.panel5.TabIndex = 5;
            // 
            // loginViaTXTButton
            // 
            this.loginViaTXTButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.loginViaTXTButton.FlatAppearance.BorderSize = 0;
            this.loginViaTXTButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.loginViaTXTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginViaTXTButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.loginViaTXTButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginViaTXTButton.Location = new System.Drawing.Point(584, 108);
            this.loginViaTXTButton.Margin = new System.Windows.Forms.Padding(4);
            this.loginViaTXTButton.Name = "loginViaTXTButton";
            this.loginViaTXTButton.Size = new System.Drawing.Size(163, 32);
            this.loginViaTXTButton.TabIndex = 15;
            this.loginViaTXTButton.Text = "Userpass Auth";
            this.loginViaTXTButton.UseVisualStyleBackColor = false;
            this.loginViaTXTButton.Click += new System.EventHandler(this.NormalAuth_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel7.Location = new System.Drawing.Point(583, 148);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1124, 5);
            this.panel7.TabIndex = 6;
            // 
            // roomsLabel
            // 
            this.roomsLabel.AutoSize = true;
            this.roomsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roomsLabel.Location = new System.Drawing.Point(1012, 158);
            this.roomsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roomsLabel.Name = "roomsLabel";
            this.roomsLabel.Size = new System.Drawing.Size(175, 29);
            this.roomsLabel.TabIndex = 25;
            this.roomsLabel.Text = "Room Actions";
            // 
            // worldAInstanceIDLabel
            // 
            this.worldAInstanceIDLabel.AutoSize = true;
            this.worldAInstanceIDLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.worldAInstanceIDLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.worldAInstanceIDLabel.Location = new System.Drawing.Point(585, 234);
            this.worldAInstanceIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.worldAInstanceIDLabel.Name = "worldAInstanceIDLabel";
            this.worldAInstanceIDLabel.Size = new System.Drawing.Size(234, 27);
            this.worldAInstanceIDLabel.TabIndex = 28;
            this.worldAInstanceIDLabel.Text = "World && Instance ID:";
            // 
            // worldAInstanceIDTextBox
            // 
            this.worldAInstanceIDTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.worldAInstanceIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldAInstanceIDTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.worldAInstanceIDTextBox.Location = new System.Drawing.Point(835, 234);
            this.worldAInstanceIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.worldAInstanceIDTextBox.Name = "worldAInstanceIDTextBox";
            this.worldAInstanceIDTextBox.Size = new System.Drawing.Size(838, 30);
            this.worldAInstanceIDTextBox.TabIndex = 27;
            // 
            // joinRoomButton
            // 
            this.joinRoomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.joinRoomButton.FlatAppearance.BorderSize = 0;
            this.joinRoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.joinRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinRoomButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.joinRoomButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.joinRoomButton.Location = new System.Drawing.Point(835, 194);
            this.joinRoomButton.Margin = new System.Windows.Forms.Padding(4);
            this.joinRoomButton.Name = "joinRoomButton";
            this.joinRoomButton.Size = new System.Drawing.Size(196, 32);
            this.joinRoomButton.TabIndex = 29;
            this.joinRoomButton.Text = "Join";
            this.joinRoomButton.UseVisualStyleBackColor = false;
            this.joinRoomButton.Click += new System.EventHandler(this.JoinRoomButton_Click);
            // 
            // leaveRoomButton
            // 
            this.leaveRoomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.leaveRoomButton.FlatAppearance.BorderSize = 0;
            this.leaveRoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.leaveRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveRoomButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.leaveRoomButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.leaveRoomButton.Location = new System.Drawing.Point(1039, 194);
            this.leaveRoomButton.Margin = new System.Windows.Forms.Padding(4);
            this.leaveRoomButton.Name = "leaveRoomButton";
            this.leaveRoomButton.Size = new System.Drawing.Size(239, 32);
            this.leaveRoomButton.TabIndex = 30;
            this.leaveRoomButton.Text = "Leave";
            this.leaveRoomButton.UseVisualStyleBackColor = false;
            this.leaveRoomButton.Click += new System.EventHandler(this.LeaveRoomButton_Click);
            // 
            // joinLastRoomButton
            // 
            this.joinLastRoomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.joinLastRoomButton.FlatAppearance.BorderSize = 0;
            this.joinLastRoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.joinLastRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinLastRoomButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.joinLastRoomButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.joinLastRoomButton.Location = new System.Drawing.Point(1285, 194);
            this.joinLastRoomButton.Margin = new System.Windows.Forms.Padding(4);
            this.joinLastRoomButton.Name = "joinLastRoomButton";
            this.joinLastRoomButton.Size = new System.Drawing.Size(187, 32);
            this.joinLastRoomButton.TabIndex = 31;
            this.joinLastRoomButton.Text = "Connect and Join";
            this.joinLastRoomButton.UseVisualStyleBackColor = false;
            this.joinLastRoomButton.Click += new System.EventHandler(this.JoinLastRoomButton_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel10.Location = new System.Drawing.Point(580, 878);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1100, 2);
            this.panel10.TabIndex = 33;
            // 
            // inRoomActions
            // 
            this.inRoomActions.AutoSize = true;
            this.inRoomActions.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inRoomActions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inRoomActions.Location = new System.Drawing.Point(1012, 282);
            this.inRoomActions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inRoomActions.Name = "inRoomActions";
            this.inRoomActions.Size = new System.Drawing.Size(191, 29);
            this.inRoomActions.TabIndex = 32;
            this.inRoomActions.Text = "Photon Actions";
            // 
            // instantiateButton
            // 
            this.instantiateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.instantiateButton.FlatAppearance.BorderSize = 0;
            this.instantiateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.instantiateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instantiateButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.instantiateButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.instantiateButton.Location = new System.Drawing.Point(580, 315);
            this.instantiateButton.Margin = new System.Windows.Forms.Padding(4);
            this.instantiateButton.Name = "instantiateButton";
            this.instantiateButton.Size = new System.Drawing.Size(532, 32);
            this.instantiateButton.TabIndex = 34;
            this.instantiateButton.Text = "Instantiate";
            this.instantiateButton.UseVisualStyleBackColor = false;
            this.instantiateButton.Click += new System.EventHandler(this.InstantiateButton_Click);
            // 
            // instantiateInvisButton
            // 
            this.instantiateInvisButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.instantiateInvisButton.FlatAppearance.BorderSize = 0;
            this.instantiateInvisButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.instantiateInvisButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instantiateInvisButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.instantiateInvisButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.instantiateInvisButton.Location = new System.Drawing.Point(580, 566);
            this.instantiateInvisButton.Margin = new System.Windows.Forms.Padding(4);
            this.instantiateInvisButton.Name = "instantiateInvisButton";
            this.instantiateInvisButton.Size = new System.Drawing.Size(531, 32);
            this.instantiateInvisButton.TabIndex = 35;
            this.instantiateInvisButton.Text = "Desync Lobby";
            this.instantiateInvisButton.UseVisualStyleBackColor = false;
            this.instantiateInvisButton.Click += new System.EventHandler(this.InstantiateInvisButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(1123, 315);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(532, 32);
            this.button1.TabIndex = 38;
            this.button1.Text = "Inst All";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(589, 815);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 32);
            this.button2.TabIndex = 39;
            this.button2.Text = "ClearList";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(580, 354);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(532, 32);
            this.button3.TabIndex = 40;
            this.button3.Text = "Connect All";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(1123, 434);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(533, 32);
            this.button4.TabIndex = 41;
            this.button4.Text = "Disconnect All";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(1481, 194);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(192, 32);
            this.button6.TabIndex = 45;
            this.button6.Text = "Log";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.SearchButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchButton.Location = new System.Drawing.Point(580, 395);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(532, 32);
            this.SearchButton.TabIndex = 46;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.Searchbutton_Click);
            // 
            // buttonTokenAuth
            // 
            this.buttonTokenAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.buttonTokenAuth.FlatAppearance.BorderSize = 0;
            this.buttonTokenAuth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.buttonTokenAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTokenAuth.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.buttonTokenAuth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonTokenAuth.Location = new System.Drawing.Point(755, 108);
            this.buttonTokenAuth.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTokenAuth.Name = "buttonTokenAuth";
            this.buttonTokenAuth.Size = new System.Drawing.Size(169, 32);
            this.buttonTokenAuth.TabIndex = 48;
            this.buttonTokenAuth.Text = "Token Auth";
            this.buttonTokenAuth.UseVisualStyleBackColor = false;
            this.buttonTokenAuth.Click += new System.EventHandler(this.buttonSearchAuth_Click);
            // 
            // CrashSearch
            // 
            this.CrashSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.CrashSearch.FlatAppearance.BorderSize = 0;
            this.CrashSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.CrashSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CrashSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.CrashSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CrashSearch.Location = new System.Drawing.Point(1123, 395);
            this.CrashSearch.Margin = new System.Windows.Forms.Padding(4);
            this.CrashSearch.Name = "CrashSearch";
            this.CrashSearch.Size = new System.Drawing.Size(533, 32);
            this.CrashSearch.TabIndex = 49;
            this.CrashSearch.Text = "Woldcrash Loop";
            this.CrashSearch.UseVisualStyleBackColor = false;
            this.CrashSearch.Click += new System.EventHandler(this.CrashSearch_Click);
            // 
            // DerankButton
            // 
            this.DerankButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.DerankButton.FlatAppearance.BorderSize = 0;
            this.DerankButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.DerankButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DerankButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.DerankButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DerankButton.Location = new System.Drawing.Point(1123, 527);
            this.DerankButton.Margin = new System.Windows.Forms.Padding(4);
            this.DerankButton.Name = "DerankButton";
            this.DerankButton.Size = new System.Drawing.Size(296, 32);
            this.DerankButton.TabIndex = 50;
            this.DerankButton.Text = "Derank ";
            this.DerankButton.UseVisualStyleBackColor = false;
            this.DerankButton.Click += new System.EventHandler(this.DerankButton_Click);
            // 
            // DerankInput
            // 
            this.DerankInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DerankInput.Font = new System.Drawing.Font("Arial", 12F);
            this.DerankInput.Location = new System.Drawing.Point(1433, 527);
            this.DerankInput.Margin = new System.Windows.Forms.Padding(4);
            this.DerankInput.Name = "DerankInput";
            this.DerankInput.Size = new System.Drawing.Size(223, 30);
            this.DerankInput.TabIndex = 51;
            this.DerankInput.TextChanged += new System.EventHandler(this.DerankInput_TextChanged);
            // 
            // BanExploit
            // 
            this.BanExploit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.BanExploit.FlatAppearance.BorderSize = 0;
            this.BanExploit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.BanExploit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BanExploit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.BanExploit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BanExploit.Location = new System.Drawing.Point(1123, 606);
            this.BanExploit.Margin = new System.Windows.Forms.Padding(4);
            this.BanExploit.Name = "BanExploit";
            this.BanExploit.Size = new System.Drawing.Size(533, 33);
            this.BanExploit.TabIndex = 52;
            this.BanExploit.Text = "SelfBan Exploit";
            this.BanExploit.UseVisualStyleBackColor = false;
            this.BanExploit.Click += new System.EventHandler(this.BanExploit_Click);
            // 
            // UpdateRelease
            // 
            this.UpdateRelease.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.UpdateRelease.FlatAppearance.BorderSize = 0;
            this.UpdateRelease.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.UpdateRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateRelease.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.UpdateRelease.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.UpdateRelease.Location = new System.Drawing.Point(589, 775);
            this.UpdateRelease.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateRelease.Name = "UpdateRelease";
            this.UpdateRelease.Size = new System.Drawing.Size(196, 32);
            this.UpdateRelease.TabIndex = 54;
            this.UpdateRelease.Text = "Update Release";
            this.UpdateRelease.UseVisualStyleBackColor = false;
            this.UpdateRelease.Click += new System.EventHandler(this.button7_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(1091, 742);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 55;
            this.label2.Text = "Misc";
            // 
            // SwitchAvi
            // 
            this.SwitchAvi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.SwitchAvi.FlatAppearance.BorderSize = 0;
            this.SwitchAvi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.SwitchAvi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwitchAvi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.SwitchAvi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SwitchAvi.Location = new System.Drawing.Point(1123, 567);
            this.SwitchAvi.Margin = new System.Windows.Forms.Padding(4);
            this.SwitchAvi.Name = "SwitchAvi";
            this.SwitchAvi.Size = new System.Drawing.Size(296, 32);
            this.SwitchAvi.TabIndex = 58;
            this.SwitchAvi.Text = "Switch Avatar";
            this.SwitchAvi.UseVisualStyleBackColor = false;
            this.SwitchAvi.Click += new System.EventHandler(this.SwitchAvi_Click);
            // 
            // AvatarSwitchText
            // 
            this.AvatarSwitchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AvatarSwitchText.Font = new System.Drawing.Font("Arial", 12F);
            this.AvatarSwitchText.Location = new System.Drawing.Point(1433, 569);
            this.AvatarSwitchText.Margin = new System.Windows.Forms.Padding(4);
            this.AvatarSwitchText.Name = "AvatarSwitchText";
            this.AvatarSwitchText.Size = new System.Drawing.Size(223, 30);
            this.AvatarSwitchText.TabIndex = 59;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.12F);
            this.checkBox1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.checkBox1.Location = new System.Drawing.Point(589, 194);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 29);
            this.checkBox1.TabIndex = 60;
            this.checkBox1.Text = "Follow ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // JoinAll
            // 
            this.JoinAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.JoinAll.FlatAppearance.BorderSize = 0;
            this.JoinAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.JoinAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.JoinAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.JoinAll.Location = new System.Drawing.Point(1123, 354);
            this.JoinAll.Margin = new System.Windows.Forms.Padding(4);
            this.JoinAll.Name = "JoinAll";
            this.JoinAll.Size = new System.Drawing.Size(532, 32);
            this.JoinAll.TabIndex = 63;
            this.JoinAll.Text = "Connect and Join All";
            this.JoinAll.UseVisualStyleBackColor = false;
            this.JoinAll.Click += new System.EventHandler(this.JoinAll_Click_1);
            // 
            // MasterDisconnect
            // 
            this.MasterDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.MasterDisconnect.FlatAppearance.BorderSize = 0;
            this.MasterDisconnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.MasterDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MasterDisconnect.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.MasterDisconnect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MasterDisconnect.Location = new System.Drawing.Point(580, 528);
            this.MasterDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.MasterDisconnect.Name = "MasterDisconnect";
            this.MasterDisconnect.Size = new System.Drawing.Size(531, 32);
            this.MasterDisconnect.TabIndex = 64;
            this.MasterDisconnect.Text = "Desync Masterclient";
            this.MasterDisconnect.UseVisualStyleBackColor = false;
            this.MasterDisconnect.Click += new System.EventHandler(this.MasterDisconnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(1073, 491);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 65;
            this.label4.Text = "Exploits";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel3.Location = new System.Drawing.Point(583, 272);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1124, 5);
            this.panel3.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel1.Location = new System.Drawing.Point(584, 482);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1124, 5);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(1499, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 23);
            this.label1.TabIndex = 66;
            this.label1.Text = "Photonbots by Wenga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(1073, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 29);
            this.label6.TabIndex = 67;
            this.label6.Text = "Auth";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel6.Controls.Add(this.RegionVarLabel);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.ConnectionVarLabel);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.AllPlayersVarLabel);
            this.panel6.Controls.Add(this.AllRoomsVarLabel);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.AllMasterVarLabel);
            this.panel6.Controls.Add(this.Master);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(1400, 737);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(300, 142);
            this.panel6.TabIndex = 6;
            // 
            // RegionVarLabel
            // 
            this.RegionVarLabel.AutoSize = true;
            this.RegionVarLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegionVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.RegionVarLabel.Location = new System.Drawing.Point(77, 94);
            this.RegionVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegionVarLabel.Name = "RegionVarLabel";
            this.RegionVarLabel.Size = new System.Drawing.Size(36, 19);
            this.RegionVarLabel.TabIndex = 76;
            this.RegionVarLabel.Text = "N/A";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(4, 94);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 19);
            this.label11.TabIndex = 75;
            this.label11.Text = "Region:";
            // 
            // ConnectionVarLabel
            // 
            this.ConnectionVarLabel.AutoSize = true;
            this.ConnectionVarLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ConnectionVarLabel.Location = new System.Drawing.Point(75, 113);
            this.ConnectionVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionVarLabel.Name = "ConnectionVarLabel";
            this.ConnectionVarLabel.Size = new System.Drawing.Size(36, 19);
            this.ConnectionVarLabel.TabIndex = 74;
            this.ConnectionVarLabel.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(4, 113);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 19);
            this.label12.TabIndex = 73;
            this.label12.Text = "Server:";
            // 
            // AllPlayersVarLabel
            // 
            this.AllPlayersVarLabel.AutoSize = true;
            this.AllPlayersVarLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllPlayersVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.AllPlayersVarLabel.Location = new System.Drawing.Point(103, 64);
            this.AllPlayersVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AllPlayersVarLabel.Name = "AllPlayersVarLabel";
            this.AllPlayersVarLabel.Size = new System.Drawing.Size(36, 19);
            this.AllPlayersVarLabel.TabIndex = 72;
            this.AllPlayersVarLabel.Text = "N/A";
            // 
            // AllRoomsVarLabel
            // 
            this.AllRoomsVarLabel.AutoSize = true;
            this.AllRoomsVarLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllRoomsVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.AllRoomsVarLabel.Location = new System.Drawing.Point(103, 46);
            this.AllRoomsVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AllRoomsVarLabel.Name = "AllRoomsVarLabel";
            this.AllRoomsVarLabel.Size = new System.Drawing.Size(36, 19);
            this.AllRoomsVarLabel.TabIndex = 71;
            this.AllRoomsVarLabel.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(4, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 19);
            this.label9.TabIndex = 70;
            this.label9.Text = "All Players:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(4, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 19);
            this.label8.TabIndex = 69;
            this.label8.Text = "All Rooms :";
            // 
            // AllMasterVarLabel
            // 
            this.AllMasterVarLabel.AutoSize = true;
            this.AllMasterVarLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllMasterVarLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.AllMasterVarLabel.Location = new System.Drawing.Point(103, 26);
            this.AllMasterVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AllMasterVarLabel.Name = "AllMasterVarLabel";
            this.AllMasterVarLabel.Size = new System.Drawing.Size(36, 19);
            this.AllMasterVarLabel.TabIndex = 65;
            this.AllMasterVarLabel.Text = "N/A";
            // 
            // Master
            // 
            this.Master.AutoSize = true;
            this.Master.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Master.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Master.Location = new System.Drawing.Point(4, 26);
            this.Master.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Master.Name = "Master";
            this.Master.Size = new System.Drawing.Size(93, 19);
            this.Master.TabIndex = 65;
            this.Master.Text = "All Masters:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(99, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 19);
            this.label7.TabIndex = 68;
            this.label7.Text = "VRC Stats";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Location = new System.Drawing.Point(580, 606);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(531, 32);
            this.button7.TabIndex = 68;
            this.button7.Text = "USpeak";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(580, 646);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(531, 32);
            this.button5.TabIndex = 69;
            this.button5.Text = "Disconnect Lobby";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // playerList
            // 
            this.playerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.playerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.playerList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerList.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.playerList.GridLines = true;
            this.playerList.HideSelection = false;
            this.playerList.Location = new System.Drawing.Point(288, 84);
            this.playerList.Margin = new System.Windows.Forms.Padding(4);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(266, 785);
            this.playerList.TabIndex = 7;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Player";
            this.columnHeader1.Width = 177;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 85;
            // 
            // botInstancesList
            // 
            this.botInstancesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.botInstancesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botInstancesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.botInstances});
            this.botInstancesList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botInstancesList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.botInstancesList.FullRowSelect = true;
            this.botInstancesList.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.botInstancesList.GridLines = true;
            this.botInstancesList.HideSelection = false;
            this.botInstancesList.Location = new System.Drawing.Point(9, 84);
            this.botInstancesList.Margin = new System.Windows.Forms.Padding(0);
            this.botInstancesList.Name = "botInstancesList";
            this.botInstancesList.Size = new System.Drawing.Size(257, 785);
            this.botInstancesList.TabIndex = 6;
            this.botInstancesList.UseCompatibleStateImageBehavior = false;
            this.botInstancesList.View = System.Windows.Forms.View.Details;
            this.botInstancesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_itemSelectionChanged);
            // 
            // botInstances
            // 
            this.botInstances.Text = "Bot Instance";
            this.botInstances.Width = 252;
            // 
            // EventLogger
            // 
            EventLogger.AutoSize = true;
            EventLogger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.12F);
            EventLogger.ForeColor = System.Drawing.Color.LavenderBlush;
            EventLogger.Location = new System.Drawing.Point(692, 194);
            EventLogger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            EventLogger.Name = "EventLogger";
            EventLogger.Size = new System.Drawing.Size(131, 29);
            EventLogger.TabIndex = 70;
            EventLogger.Text = "Event Log";
            EventLogger.UseVisualStyleBackColor = true;
            EventLogger.CheckedChanged += new System.EventHandler(EventLogger_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(1708, 886);
            this.Controls.Add(EventLogger);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MasterDisconnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.JoinAll);
            this.Controls.Add(this.buttonTokenAuth);
            this.Controls.Add(this.loginViaTXTButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.AvatarSwitchText);
            this.Controls.Add(this.SwitchAvi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpdateRelease);
            this.Controls.Add(this.BanExploit);
            this.Controls.Add(this.DerankInput);
            this.Controls.Add(this.DerankButton);
            this.Controls.Add(this.CrashSearch);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.instantiateInvisButton);
            this.Controls.Add(this.instantiateButton);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.inRoomActions);
            this.Controls.Add(this.joinLastRoomButton);
            this.Controls.Add(this.leaveRoomButton);
            this.Controls.Add(this.joinRoomButton);
            this.Controls.Add(this.worldAInstanceIDLabel);
            this.Controls.Add(this.worldAInstanceIDTextBox);
            this.Controls.Add(this.roomsLabel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.botInstancesList);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "TheBot UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Button minimizeButton;
        public Panel panel2;
        public Panel panel4;
        public Panel panel5;
        public ColumnHeader botInstances;
        public ColumnHeader columnHeader1;
        public ColumnHeader columnHeader2;
        public Button loginViaTXTButton;
        public Label infoLabel;
        public ToolTip loginToolTip;
        public Panel panel7;
        public Label connectionStatusLabel;
        public Label connectionStatusVarLabel;
        public Label pingVarLabel;
        public Label pingLabel;
        public Label inRoomVarLabel;
        public Label inRoomLabel;
        public Label playersVarLabel;
        public Label playersLabel;
        public Label roomsLabel;
        public Label worldAInstanceIDLabel;
        public TextBox worldAInstanceIDTextBox;
        public Button joinRoomButton;
        public Button leaveRoomButton;
        public Button joinLastRoomButton;
        public Panel panel10;
        public Label inRoomActions;
        public Button instantiateButton;
        public Button instantiateInvisButton;
        public Button button1;
        public Button button2;
        public Button button3;
        public Button button4;
        public Button button6;
        public Button SearchButton;
        public Button buttonTokenAuth;
        public Button CrashSearch;
        public Button DerankButton;
        public TextBox DerankInput;
        public Button BanExploit;
        public Button UpdateRelease;
        public Label label2;
        public Button SwitchAvi;
        public TextBox AvatarSwitchText;
        private CheckBox checkBox1;
        public Label label3;
        public Label MasterVarLabel;
        public Button JoinAll;
        public Button MasterDisconnect;
        public Button exitButton;
        public Button settingsButton;
        public Label label4;
        public Panel panel3;
        public Panel panel1;
        public Label label1;
        public Label ServerVarLabel;
        public Label label5;
        public Label label6;
        public Panel panel6;
        public Label label8;
        public Label AllMasterVarLabel;
        public Label Master;
        public Label label7;
        public Label ConnectionVarLabel;
        public Label label12;
        public Label AllPlayersVarLabel;
        public Label AllRoomsVarLabel;
        public Label label9;
        public Label OpenVarLabel;
        public Label label10;
        public Label RegionVarLabel;
        public Label label11;
        public Label AdressVarLabel;
        public Button button7;
        public Button button5;
        public CustomListView playerList;
        public CustomListView botInstancesList;
        private static CheckBox EventLogger;
    }
}

