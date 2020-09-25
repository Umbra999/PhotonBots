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
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.settingsButton = new System.Windows.Forms.Button();
            this.botInstancesLabel = new System.Windows.Forms.Label();
            this.playerlistLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.loginViaTXTButton = new System.Windows.Forms.Button();
            this.loginToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.connectionStatusVarLabel = new System.Windows.Forms.Label();
            this.statsLabel = new System.Windows.Forms.Label();
            this.pingVarLabel = new System.Windows.Forms.Label();
            this.pingLabel = new System.Windows.Forms.Label();
            this.inRoomVarLabel = new System.Windows.Forms.Label();
            this.inRoomLabel = new System.Windows.Forms.Label();
            this.playersVarLabel = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.buttonTokenAuth = new System.Windows.Forms.Button();
            this.CrashSearch = new System.Windows.Forms.Button();
            this.DerankButton = new System.Windows.Forms.Button();
            this.DerankInput = new System.Windows.Forms.TextBox();
            this.BanExploit = new System.Windows.Forms.Button();
            this.UpdateRelease = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.SwitchAvi = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.playerList = new TheBotUI.CustomComponents.CustomListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.botInstancesList = new TheBotUI.CustomComponents.CustomListView();
            this.botInstances = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.minimizeButton);
            this.panel1.Controls.Add(this.maximizeButton);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Location = new System.Drawing.Point(1539, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 39);
            this.panel1.TabIndex = 0;
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Image = global::TheBotUI.Properties.Resources.minimize;
            this.minimizeButton.Location = new System.Drawing.Point(0, 0);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(56, 39);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.ForeColor = System.Drawing.Color.White;
            this.maximizeButton.Image = global::TheBotUI.Properties.Resources.maximize;
            this.maximizeButton.Location = new System.Drawing.Point(56, 0);
            this.maximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(56, 39);
            this.maximizeButton.TabIndex = 2;
            this.maximizeButton.UseVisualStyleBackColor = true;
            this.maximizeButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::TheBotUI.Properties.Resources.close;
            this.exitButton.Location = new System.Drawing.Point(112, 0);
            this.exitButton.Margin = new System.Windows.Forms.Padding(0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(56, 39);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.settingsButton);
            this.panel2.Controls.Add(this.botInstancesLabel);
            this.panel2.Controls.Add(this.playerlistLabel);
            this.panel2.Controls.Add(this.infoLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1708, 79);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Image = global::TheBotUI.Properties.Resources.settings;
            this.settingsButton.Location = new System.Drawing.Point(0, 0);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(56, 39);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // botInstancesLabel
            // 
            this.botInstancesLabel.AutoSize = true;
            this.botInstancesLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botInstancesLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.botInstancesLabel.Location = new System.Drawing.Point(16, 52);
            this.botInstancesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.botInstancesLabel.Name = "botInstancesLabel";
            this.botInstancesLabel.Size = new System.Drawing.Size(170, 29);
            this.botInstancesLabel.TabIndex = 1;
            this.botInstancesLabel.Text = "Bot Instances";
            // 
            // playerlistLabel
            // 
            this.playerlistLabel.AutoSize = true;
            this.playerlistLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerlistLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerlistLabel.Location = new System.Drawing.Point(299, 52);
            this.playerlistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerlistLabel.Name = "playerlistLabel";
            this.playerlistLabel.Size = new System.Drawing.Size(119, 29);
            this.playerlistLabel.TabIndex = 0;
            this.playerlistLabel.Text = "Playerlist";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.infoLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.infoLabel.Location = new System.Drawing.Point(1676, 53);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(21, 23);
            this.infoLabel.TabIndex = 16;
            this.infoLabel.Text = "?";
            this.loginToolTip.SetToolTip(this.infoLabel, "1 = Userpass Auth Only\r\n2 = Token Auth Only");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel4.Location = new System.Drawing.Point(579, 47);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 832);
            this.panel4.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel8.Location = new System.Drawing.Point(597, 186);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1100, 2);
            this.panel8.TabIndex = 7;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel3.Location = new System.Drawing.Point(285, 46);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 833);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel5.Location = new System.Drawing.Point(583, 684);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1124, 5);
            this.panel5.TabIndex = 5;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.usernameTextBox.Location = new System.Drawing.Point(867, 114);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(173, 30);
            this.usernameTextBox.TabIndex = 9;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel6.Location = new System.Drawing.Point(11, 44);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1693, 5);
            this.panel6.TabIndex = 6;
            // 
            // loginViaTXTButton
            // 
            this.loginViaTXTButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.loginViaTXTButton.FlatAppearance.BorderSize = 0;
            this.loginViaTXTButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.loginViaTXTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginViaTXTButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.loginViaTXTButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginViaTXTButton.Location = new System.Drawing.Point(1085, 96);
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
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel7.Location = new System.Drawing.Point(583, 148);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1124, 5);
            this.panel7.TabIndex = 6;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.connectionStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectionStatusLabel.Location = new System.Drawing.Point(595, 191);
            this.connectionStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(217, 27);
            this.connectionStatusLabel.TabIndex = 17;
            this.connectionStatusLabel.Text = "Connection Status:";
            // 
            // connectionStatusVarLabel
            // 
            this.connectionStatusVarLabel.AutoSize = true;
            this.connectionStatusVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.connectionStatusVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectionStatusVarLabel.Location = new System.Drawing.Point(828, 191);
            this.connectionStatusVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatusVarLabel.Name = "connectionStatusVarLabel";
            this.connectionStatusVarLabel.Size = new System.Drawing.Size(51, 27);
            this.connectionStatusVarLabel.TabIndex = 18;
            this.connectionStatusVarLabel.Text = "N/A";
            // 
            // statsLabel
            // 
            this.statsLabel.AutoSize = true;
            this.statsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsLabel.Location = new System.Drawing.Point(593, 156);
            this.statsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(71, 29);
            this.statsLabel.TabIndex = 5;
            this.statsLabel.Text = "Stats";
            // 
            // pingVarLabel
            // 
            this.pingVarLabel.AutoSize = true;
            this.pingVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.pingVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pingVarLabel.Location = new System.Drawing.Point(1159, 191);
            this.pingVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pingVarLabel.Name = "pingVarLabel";
            this.pingVarLabel.Size = new System.Drawing.Size(51, 27);
            this.pingVarLabel.TabIndex = 20;
            this.pingVarLabel.Text = "N/A";
            // 
            // pingLabel
            // 
            this.pingLabel.AutoSize = true;
            this.pingLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.pingLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pingLabel.Location = new System.Drawing.Point(1080, 191);
            this.pingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pingLabel.Name = "pingLabel";
            this.pingLabel.Size = new System.Drawing.Size(68, 27);
            this.pingLabel.TabIndex = 19;
            this.pingLabel.Text = "Ping:";
            // 
            // inRoomVarLabel
            // 
            this.inRoomVarLabel.AutoSize = true;
            this.inRoomVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.inRoomVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inRoomVarLabel.Location = new System.Drawing.Point(1400, 191);
            this.inRoomVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inRoomVarLabel.Name = "inRoomVarLabel";
            this.inRoomVarLabel.Size = new System.Drawing.Size(51, 27);
            this.inRoomVarLabel.TabIndex = 22;
            this.inRoomVarLabel.Text = "N/A";
            // 
            // inRoomLabel
            // 
            this.inRoomLabel.AutoSize = true;
            this.inRoomLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.inRoomLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inRoomLabel.Location = new System.Drawing.Point(1275, 191);
            this.inRoomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inRoomLabel.Name = "inRoomLabel";
            this.inRoomLabel.Size = new System.Drawing.Size(109, 27);
            this.inRoomLabel.TabIndex = 21;
            this.inRoomLabel.Text = "In Room:";
            // 
            // playersVarLabel
            // 
            this.playersVarLabel.AutoSize = true;
            this.playersVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.playersVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playersVarLabel.Location = new System.Drawing.Point(1629, 191);
            this.playersVarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playersVarLabel.Name = "playersVarLabel";
            this.playersVarLabel.Size = new System.Drawing.Size(51, 27);
            this.playersVarLabel.TabIndex = 24;
            this.playersVarLabel.Text = "N/A";
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.playersLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playersLabel.Location = new System.Drawing.Point(1517, 191);
            this.playersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(99, 27);
            this.playersLabel.TabIndex = 23;
            this.playersLabel.Text = "Players:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel9.Location = new System.Drawing.Point(597, 266);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1100, 2);
            this.panel9.TabIndex = 26;
            // 
            // roomsLabel
            // 
            this.roomsLabel.AutoSize = true;
            this.roomsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roomsLabel.Location = new System.Drawing.Point(593, 236);
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
            this.worldAInstanceIDLabel.Location = new System.Drawing.Point(596, 274);
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
            this.worldAInstanceIDTextBox.Location = new System.Drawing.Point(852, 272);
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
            this.joinRoomButton.Location = new System.Drawing.Point(601, 310);
            this.joinRoomButton.Margin = new System.Windows.Forms.Padding(4);
            this.joinRoomButton.Name = "joinRoomButton";
            this.joinRoomButton.Size = new System.Drawing.Size(281, 32);
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
            this.leaveRoomButton.Location = new System.Drawing.Point(891, 311);
            this.leaveRoomButton.Margin = new System.Windows.Forms.Padding(4);
            this.leaveRoomButton.Name = "leaveRoomButton";
            this.leaveRoomButton.Size = new System.Drawing.Size(281, 32);
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
            this.joinLastRoomButton.Location = new System.Drawing.Point(1180, 311);
            this.joinLastRoomButton.Margin = new System.Windows.Forms.Padding(4);
            this.joinLastRoomButton.Name = "joinLastRoomButton";
            this.joinLastRoomButton.Size = new System.Drawing.Size(283, 32);
            this.joinLastRoomButton.TabIndex = 31;
            this.joinLastRoomButton.Text = "Connect and Join";
            this.joinLastRoomButton.UseVisualStyleBackColor = false;
            this.joinLastRoomButton.Click += new System.EventHandler(this.JoinLastRoomButton_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel10.Location = new System.Drawing.Point(597, 385);
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
            this.inRoomActions.Location = new System.Drawing.Point(593, 356);
            this.inRoomActions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inRoomActions.Name = "inRoomActions";
            this.inRoomActions.Size = new System.Drawing.Size(204, 29);
            this.inRoomActions.TabIndex = 32;
            this.inRoomActions.Text = "In Room Actions";
            // 
            // instantiateButton
            // 
            this.instantiateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.instantiateButton.FlatAppearance.BorderSize = 0;
            this.instantiateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.instantiateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instantiateButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.instantiateButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.instantiateButton.Location = new System.Drawing.Point(601, 395);
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
            this.instantiateInvisButton.Location = new System.Drawing.Point(1141, 395);
            this.instantiateInvisButton.Margin = new System.Windows.Forms.Padding(4);
            this.instantiateInvisButton.Name = "instantiateInvisButton";
            this.instantiateInvisButton.Size = new System.Drawing.Size(549, 32);
            this.instantiateInvisButton.TabIndex = 35;
            this.instantiateInvisButton.Text = "Desync Instantiate ";
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
            this.button1.Location = new System.Drawing.Point(601, 434);
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
            this.button2.Location = new System.Drawing.Point(1141, 434);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(549, 32);
            this.button2.TabIndex = 39;
            this.button2.Text = "ClearList";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.usernameLabel.Location = new System.Drawing.Point(876, 84);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(148, 27);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "MAXPlayers:";
            this.usernameLabel.Click += new System.EventHandler(this.usernameLabel_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(601, 474);
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
            this.button4.Location = new System.Drawing.Point(1141, 474);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(549, 32);
            this.button4.TabIndex = 41;
            this.button4.Text = "Disconnect All";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(601, 513);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(532, 32);
            this.button5.TabIndex = 42;
            this.button5.Text = "Uspeak";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox1.Location = new System.Drawing.Point(639, 114);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 30);
            this.textBox1.TabIndex = 43;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(613, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 27);
            this.label1.TabIndex = 44;
            this.label1.Text = "Connection Status:";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(1467, 311);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(223, 32);
            this.button6.TabIndex = 45;
            this.button6.Text = "Check";
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
            this.SearchButton.Location = new System.Drawing.Point(601, 553);
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
            this.buttonTokenAuth.Location = new System.Drawing.Point(1268, 96);
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
            this.CrashSearch.Location = new System.Drawing.Point(600, 593);
            this.CrashSearch.Margin = new System.Windows.Forms.Padding(4);
            this.CrashSearch.Name = "CrashSearch";
            this.CrashSearch.Size = new System.Drawing.Size(533, 32);
            this.CrashSearch.TabIndex = 49;
            this.CrashSearch.Text = "CrashSearch";
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
            this.DerankButton.Location = new System.Drawing.Point(1141, 514);
            this.DerankButton.Margin = new System.Windows.Forms.Padding(4);
            this.DerankButton.Name = "DerankButton";
            this.DerankButton.Size = new System.Drawing.Size(296, 32);
            this.DerankButton.TabIndex = 50;
            this.DerankButton.Text = "Derank (1)";
            this.DerankButton.UseVisualStyleBackColor = false;
            this.DerankButton.Click += new System.EventHandler(this.DerankButton_Click);
            // 
            // DerankInput
            // 
            this.DerankInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DerankInput.Font = new System.Drawing.Font("Arial", 12F);
            this.DerankInput.Location = new System.Drawing.Point(1443, 513);
            this.DerankInput.Margin = new System.Windows.Forms.Padding(4);
            this.DerankInput.Name = "DerankInput";
            this.DerankInput.Size = new System.Drawing.Size(247, 30);
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
            this.BanExploit.Location = new System.Drawing.Point(601, 633);
            this.BanExploit.Margin = new System.Windows.Forms.Padding(4);
            this.BanExploit.Name = "BanExploit";
            this.BanExploit.Size = new System.Drawing.Size(532, 32);
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
            this.UpdateRelease.Location = new System.Drawing.Point(597, 734);
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
            this.label2.Location = new System.Drawing.Point(592, 693);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 55;
            this.label2.Text = "Misc";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel11.Location = new System.Drawing.Point(597, 724);
            this.panel11.Margin = new System.Windows.Forms.Padding(4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1100, 2);
            this.panel11.TabIndex = 56;
            // 
            // SwitchAvi
            // 
            this.SwitchAvi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.SwitchAvi.FlatAppearance.BorderSize = 0;
            this.SwitchAvi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.SwitchAvi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwitchAvi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.SwitchAvi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SwitchAvi.Location = new System.Drawing.Point(1141, 554);
            this.SwitchAvi.Margin = new System.Windows.Forms.Padding(4);
            this.SwitchAvi.Name = "SwitchAvi";
            this.SwitchAvi.Size = new System.Drawing.Size(296, 32);
            this.SwitchAvi.TabIndex = 58;
            this.SwitchAvi.Text = "Switch Avatar";
            this.SwitchAvi.UseVisualStyleBackColor = false;
            this.SwitchAvi.Click += new System.EventHandler(this.SwitchAvi_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox2.Location = new System.Drawing.Point(1443, 553);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(247, 30);
            this.textBox2.TabIndex = 59;
            // 
            // playerList
            // 
            this.playerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.playerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.playerList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerList.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.playerList.GridLines = true;
            this.playerList.HideSelection = false;
            this.playerList.Location = new System.Drawing.Point(299, 86);
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
            this.columnHeader1.Width = 155;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 45;
            // 
            // botInstancesList
            // 
            this.botInstancesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.botInstancesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botInstancesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.botInstances});
            this.botInstancesList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botInstancesList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.botInstancesList.FullRowSelect = true;
            this.botInstancesList.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.botInstancesList.GridLines = true;
            this.botInstancesList.HideSelection = false;
            this.botInstancesList.Location = new System.Drawing.Point(11, 86);
            this.botInstancesList.Margin = new System.Windows.Forms.Padding(0);
            this.botInstancesList.Name = "botInstancesList";
            this.botInstancesList.Size = new System.Drawing.Size(266, 785);
            this.botInstancesList.TabIndex = 6;
            this.botInstancesList.UseCompatibleStateImageBehavior = false;
            this.botInstancesList.View = System.Windows.Forms.View.Details;
            this.botInstancesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_itemSelectionChanged);
            // 
            // botInstances
            // 
            this.botInstances.Text = "Bot Instance";
            this.botInstances.Width = 197;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.12F);
            this.checkBox1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.checkBox1.Location = new System.Drawing.Point(1588, 350);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 29);
            this.checkBox1.TabIndex = 60;
            this.checkBox1.Text = "Follow ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1708, 886);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.SwitchAvi);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpdateRelease);
            this.Controls.Add(this.BanExploit);
            this.Controls.Add(this.DerankInput);
            this.Controls.Add(this.DerankButton);
            this.Controls.Add(this.CrashSearch);
            this.Controls.Add(this.buttonTokenAuth);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
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
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.roomsLabel);
            this.Controls.Add(this.playersVarLabel);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.inRoomVarLabel);
            this.Controls.Add(this.inRoomLabel);
            this.Controls.Add(this.pingVarLabel);
            this.Controls.Add(this.pingLabel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.connectionStatusVarLabel);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.loginViaTXTButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.botInstancesList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "TheBot UI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Panel panel1;
        public Button exitButton;
        public Button minimizeButton;
        public Button maximizeButton;
        public Panel panel2;
        public Panel panel3;
        public Label botInstancesLabel;
        public Label playerlistLabel;
        public Panel panel4;
        public Panel panel5;
        public ColumnHeader botInstances;
        public ColumnHeader columnHeader1;
        public ColumnHeader columnHeader2;
        public CustomListView botInstancesList;
        public CustomListView playerList;
        public Button settingsButton;
        public TextBox usernameTextBox;
        public Panel panel6;
        public Button loginViaTXTButton;
        public Label infoLabel;
        public ToolTip loginToolTip;
        public Panel panel7;
        public Label connectionStatusLabel;
        public Label connectionStatusVarLabel;
        public Panel panel8;
        public Label statsLabel;
        public Label pingVarLabel;
        public Label pingLabel;
        public Label inRoomVarLabel;
        public Label inRoomLabel;
        public Label playersVarLabel;
        public Label playersLabel;
        public Panel panel9;
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
        public Label usernameLabel;
        public Button button3;
        public Button button4;
        public Button button5;
        public TextBox textBox1;
        public Label label1;
        public Button button6;
        public Button SearchButton;
        public Button buttonTokenAuth;
        public Button CrashSearch;
        public Button DerankButton;
        public TextBox DerankInput;
        public Button BanExploit;
        public Button UpdateRelease;
        public Label label2;
        public Panel panel11;
        public Button SwitchAvi;
        public TextBox textBox2;
        private CheckBox checkBox1;
    }
}

