namespace bp01_chatapplicatie
{
  partial class ServerForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.grpServerSettings = new System.Windows.Forms.GroupBox();
      this.btnStopServer = new System.Windows.Forms.Button();
      this.btnStartServer = new System.Windows.Forms.Button();
      this.LabelBufferSize = new System.Windows.Forms.Label();
      this.LabelPort = new System.Windows.Forms.Label();
      this.LabelIp = new System.Windows.Forms.Label();
      this.labelUsername = new System.Windows.Forms.Label();
      this.serverBufferSize = new System.Windows.Forms.TextBox();
      this.serverPort = new System.Windows.Forms.TextBox();
      this.serverIP = new System.Windows.Forms.TextBox();
      this.serverUsername = new System.Windows.Forms.TextBox();
      this.grpClientsConnected = new System.Windows.Forms.GroupBox();
      this.listClientsConnected = new System.Windows.Forms.ListBox();
      this.grpChats = new System.Windows.Forms.GroupBox();
      this.listChatBox = new System.Windows.Forms.ListBox();
      this.grpServerSettings.SuspendLayout();
      this.grpClientsConnected.SuspendLayout();
      this.grpChats.SuspendLayout();
      this.SuspendLayout();
      // 
      // grpServerSettings
      // 
      this.grpServerSettings.BackColor = System.Drawing.Color.Transparent;
      this.grpServerSettings.Controls.Add(this.btnStopServer);
      this.grpServerSettings.Controls.Add(this.btnStartServer);
      this.grpServerSettings.Controls.Add(this.LabelBufferSize);
      this.grpServerSettings.Controls.Add(this.LabelPort);
      this.grpServerSettings.Controls.Add(this.LabelIp);
      this.grpServerSettings.Controls.Add(this.labelUsername);
      this.grpServerSettings.Controls.Add(this.serverBufferSize);
      this.grpServerSettings.Controls.Add(this.serverPort);
      this.grpServerSettings.Controls.Add(this.serverIP);
      this.grpServerSettings.Controls.Add(this.serverUsername);
      this.grpServerSettings.Location = new System.Drawing.Point(12, 12);
      this.grpServerSettings.Name = "grpServerSettings";
      this.grpServerSettings.Size = new System.Drawing.Size(334, 156);
      this.grpServerSettings.TabIndex = 0;
      this.grpServerSettings.TabStop = false;
      this.grpServerSettings.Text = "Server Settings";
      // 
      // btnStopServer
      // 
      this.btnStopServer.Location = new System.Drawing.Point(245, 123);
      this.btnStopServer.Name = "btnStopServer";
      this.btnStopServer.Size = new System.Drawing.Size(83, 23);
      this.btnStopServer.TabIndex = 9;
      this.btnStopServer.Text = "Stop Server";
      this.btnStopServer.UseVisualStyleBackColor = true;
      this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_click);
      // 
      // btnStartServer
      // 
      this.btnStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnStartServer.Location = new System.Drawing.Point(245, 123);
      this.btnStartServer.Name = "btnStartServer";
      this.btnStartServer.Size = new System.Drawing.Size(83, 23);
      this.btnStartServer.TabIndex = 8;
      this.btnStartServer.Text = "Start Server";
      this.btnStartServer.UseVisualStyleBackColor = true;
      this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
      // 
      // LabelBufferSize
      // 
      this.LabelBufferSize.AutoSize = true;
      this.LabelBufferSize.Location = new System.Drawing.Point(6, 100);
      this.LabelBufferSize.Name = "LabelBufferSize";
      this.LabelBufferSize.Size = new System.Drawing.Size(58, 13);
      this.LabelBufferSize.TabIndex = 7;
      this.LabelBufferSize.Text = "Buffer Size";
      // 
      // LabelPort
      // 
      this.LabelPort.AutoSize = true;
      this.LabelPort.Location = new System.Drawing.Point(6, 74);
      this.LabelPort.Name = "LabelPort";
      this.LabelPort.Size = new System.Drawing.Size(26, 13);
      this.LabelPort.TabIndex = 6;
      this.LabelPort.Text = "Port";
      // 
      // LabelIp
      // 
      this.LabelIp.AutoSize = true;
      this.LabelIp.Location = new System.Drawing.Point(6, 48);
      this.LabelIp.Name = "LabelIp";
      this.LabelIp.Size = new System.Drawing.Size(17, 13);
      this.LabelIp.TabIndex = 5;
      this.LabelIp.Text = "IP";
      // 
      // labelUsername
      // 
      this.labelUsername.AutoSize = true;
      this.labelUsername.Location = new System.Drawing.Point(6, 22);
      this.labelUsername.Name = "labelUsername";
      this.labelUsername.Size = new System.Drawing.Size(55, 13);
      this.labelUsername.TabIndex = 4;
      this.labelUsername.Text = "Username";
      // 
      // serverBufferSize
      // 
      this.serverBufferSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.serverBufferSize.Location = new System.Drawing.Point(116, 97);
      this.serverBufferSize.Name = "serverBufferSize";
      this.serverBufferSize.Size = new System.Drawing.Size(212, 20);
      this.serverBufferSize.TabIndex = 3;
      this.serverBufferSize.Text = "1024";
      // 
      // serverPort
      // 
      this.serverPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.serverPort.Location = new System.Drawing.Point(116, 71);
      this.serverPort.Name = "serverPort";
      this.serverPort.Size = new System.Drawing.Size(212, 20);
      this.serverPort.TabIndex = 2;
      this.serverPort.Text = "3000";
      // 
      // serverIP
      // 
      this.serverIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.serverIP.Location = new System.Drawing.Point(116, 45);
      this.serverIP.Name = "serverIP";
      this.serverIP.Size = new System.Drawing.Size(212, 20);
      this.serverIP.TabIndex = 1;
      this.serverIP.Text = "127.0.0.1";
      // 
      // serverUsername
      // 
      this.serverUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.serverUsername.Location = new System.Drawing.Point(116, 19);
      this.serverUsername.Name = "serverUsername";
      this.serverUsername.Size = new System.Drawing.Size(212, 20);
      this.serverUsername.TabIndex = 0;
      this.serverUsername.Text = "Patrick";
      // 
      // grpClientsConnected
      // 
      this.grpClientsConnected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.grpClientsConnected.Controls.Add(this.listClientsConnected);
      this.grpClientsConnected.Location = new System.Drawing.Point(12, 174);
      this.grpClientsConnected.Name = "grpClientsConnected";
      this.grpClientsConnected.Size = new System.Drawing.Size(334, 248);
      this.grpClientsConnected.TabIndex = 1;
      this.grpClientsConnected.TabStop = false;
      this.grpClientsConnected.Text = "Clients Connected";
      // 
      // listClientsConnected
      // 
      this.listClientsConnected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.listClientsConnected.FormattingEnabled = true;
      this.listClientsConnected.Location = new System.Drawing.Point(6, 17);
      this.listClientsConnected.Name = "listClientsConnected";
      this.listClientsConnected.Size = new System.Drawing.Size(322, 225);
      this.listClientsConnected.TabIndex = 0;
      // 
      // grpChats
      // 
      this.grpChats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpChats.Controls.Add(this.listChatBox);
      this.grpChats.Location = new System.Drawing.Point(352, 12);
      this.grpChats.Name = "grpChats";
      this.grpChats.Size = new System.Drawing.Size(310, 410);
      this.grpChats.TabIndex = 3;
      this.grpChats.TabStop = false;
      this.grpChats.Text = "Chats";
      // 
      // listChatBox
      // 
      this.listChatBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listChatBox.FormattingEnabled = true;
      this.listChatBox.Location = new System.Drawing.Point(6, 22);
      this.listChatBox.Name = "listChatBox";
      this.listChatBox.Size = new System.Drawing.Size(298, 381);
      this.listChatBox.TabIndex = 0;
      // 
      // ServerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(674, 434);
      this.Controls.Add(this.grpChats);
      this.Controls.Add(this.grpClientsConnected);
      this.Controls.Add(this.grpServerSettings);
      this.DoubleBuffered = true;
      this.Name = "ServerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Bikini Bottom Server";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
      this.grpServerSettings.ResumeLayout(false);
      this.grpServerSettings.PerformLayout();
      this.grpClientsConnected.ResumeLayout(false);
      this.grpChats.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    private System.Windows.Forms.Button btnStopServer;

    private System.Windows.Forms.GroupBox grpChats;
    private System.Windows.Forms.ListBox listChatBox;

    private System.Windows.Forms.GroupBox grpClientsConnected;
    private System.Windows.Forms.ListBox listClientsConnected;

    #endregion

    private System.Windows.Forms.GroupBox grpServerSettings;
    private System.Windows.Forms.Button btnStartServer;
    private System.Windows.Forms.Label LabelBufferSize;
    private System.Windows.Forms.Label LabelPort;
    private System.Windows.Forms.Label LabelIp;
    private System.Windows.Forms.Label labelUsername;
    private System.Windows.Forms.TextBox serverBufferSize;
    private System.Windows.Forms.TextBox serverPort;
    private System.Windows.Forms.TextBox serverIP;
    private System.Windows.Forms.TextBox serverUsername;
  }
}