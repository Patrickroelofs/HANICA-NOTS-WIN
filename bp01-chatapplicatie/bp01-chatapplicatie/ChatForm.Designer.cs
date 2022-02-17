namespace bp01_chatapplicatie
{
    partial class ChatForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
      this.btnStartServer = new System.Windows.Forms.Button();
      this.clientMessage = new System.Windows.Forms.TextBox();
      this.btnSendMessage = new System.Windows.Forms.Button();
      this.connectServerGroupBox = new System.Windows.Forms.GroupBox();
      this.clientBufferSize = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.PortLabel = new System.Windows.Forms.Label();
      this.clientPort = new System.Windows.Forms.TextBox();
      this.clientUsername = new System.Windows.Forms.TextBox();
      this.username = new System.Windows.Forms.Label();
      this.ipLabel = new System.Windows.Forms.Label();
      this.btnConnect = new System.Windows.Forms.Button();
      this.clientIP = new System.Windows.Forms.TextBox();
      this.clientMessageList = new System.Windows.Forms.ListBox();
      this.label2 = new System.Windows.Forms.Label();
      this.timer1 = new System.Timers.Timer();
      this.btnDisconnect = new System.Windows.Forms.Button();
      this.connectServerGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
      this.SuspendLayout();
      // 
      // btnStartServer
      // 
      resources.ApplyResources(this.btnStartServer, "btnStartServer");
      this.btnStartServer.Name = "btnStartServer";
      this.btnStartServer.UseVisualStyleBackColor = true;
      this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
      // 
      // clientMessage
      // 
      resources.ApplyResources(this.clientMessage, "clientMessage");
      this.clientMessage.Name = "clientMessage";
      this.clientMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clientMessage_KeyDown);
      // 
      // btnSendMessage
      // 
      resources.ApplyResources(this.btnSendMessage, "btnSendMessage");
      this.btnSendMessage.Name = "btnSendMessage";
      this.btnSendMessage.UseVisualStyleBackColor = true;
      this.btnSendMessage.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // connectServerGroupBox
      // 
      resources.ApplyResources(this.connectServerGroupBox, "connectServerGroupBox");
      this.connectServerGroupBox.BackColor = System.Drawing.Color.Transparent;
      this.connectServerGroupBox.Controls.Add(this.clientBufferSize);
      this.connectServerGroupBox.Controls.Add(this.label1);
      this.connectServerGroupBox.Controls.Add(this.PortLabel);
      this.connectServerGroupBox.Controls.Add(this.clientPort);
      this.connectServerGroupBox.Controls.Add(this.clientUsername);
      this.connectServerGroupBox.Controls.Add(this.username);
      this.connectServerGroupBox.Controls.Add(this.ipLabel);
      this.connectServerGroupBox.Controls.Add(this.btnConnect);
      this.connectServerGroupBox.Controls.Add(this.clientIP);
      this.connectServerGroupBox.Name = "connectServerGroupBox";
      this.connectServerGroupBox.TabStop = false;
      // 
      // clientBufferSize
      // 
      resources.ApplyResources(this.clientBufferSize, "clientBufferSize");
      this.clientBufferSize.Name = "clientBufferSize";
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // PortLabel
      // 
      resources.ApplyResources(this.PortLabel, "PortLabel");
      this.PortLabel.Name = "PortLabel";
      // 
      // clientPort
      // 
      resources.ApplyResources(this.clientPort, "clientPort");
      this.clientPort.Name = "clientPort";
      // 
      // clientUsername
      // 
      resources.ApplyResources(this.clientUsername, "clientUsername");
      this.clientUsername.Name = "clientUsername";
      // 
      // username
      // 
      resources.ApplyResources(this.username, "username");
      this.username.Name = "username";
      // 
      // ipLabel
      // 
      resources.ApplyResources(this.ipLabel, "ipLabel");
      this.ipLabel.Name = "ipLabel";
      // 
      // btnConnect
      // 
      resources.ApplyResources(this.btnConnect, "btnConnect");
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // clientIP
      // 
      resources.ApplyResources(this.clientIP, "clientIP");
      this.clientIP.Name = "clientIP";
      // 
      // clientMessageList
      // 
      resources.ApplyResources(this.clientMessageList, "clientMessageList");
      this.clientMessageList.BackColor = System.Drawing.SystemColors.Window;
      this.clientMessageList.FormattingEnabled = true;
      this.clientMessageList.Name = "clientMessageList";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.ForeColor = System.Drawing.Color.Yellow;
      this.label2.Name = "label2";
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.SynchronizingObject = this;
      // 
      // btnDisconnect
      // 
      resources.ApplyResources(this.btnDisconnect, "btnDisconnect");
      this.btnDisconnect.Name = "btnDisconnect";
      this.btnDisconnect.UseVisualStyleBackColor = true;
      this.btnDisconnect.Click += new System.EventHandler(this.clientDisconnect_Click);
      // 
      // ChatForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.btnDisconnect);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.clientMessageList);
      this.Controls.Add(this.connectServerGroupBox);
      this.Controls.Add(this.btnSendMessage);
      this.Controls.Add(this.clientMessage);
      this.Controls.Add(this.btnStartServer);
      this.Name = "ChatForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
      this.connectServerGroupBox.ResumeLayout(false);
      this.connectServerGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        private System.Windows.Forms.Button btnDisconnect;

        private System.Windows.Forms.TextBox clientBufferSize;

        private System.Windows.Forms.Label label1;

        private System.Timers.Timer timer1;

        private System.Windows.Forms.TextBox clientPort;
        private System.Windows.Forms.Label PortLabel;

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox clientUsername;

        private System.Windows.Forms.Label username;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.GroupBox connectServerGroupBox;
        private System.Windows.Forms.TextBox clientIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox clientMessageList;

        private System.Windows.Forms.TextBox clientMessage;
        private System.Windows.Forms.Button btnSendMessage;

        private System.Windows.Forms.Button btnStartServer;

    #endregion
    }
}