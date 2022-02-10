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
            this.txtMessageToBeSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.connectServerGroupBox = new System.Windows.Forms.GroupBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.txtChatServerPort = new System.Windows.Forms.TextBox();
            this.inputUsername = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtChatServerIP = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.connectServerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            resources.ApplyResources(this.btnStartServer, "btnStartServer");
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // txtMessageToBeSend
            // 
            resources.ApplyResources(this.txtMessageToBeSend, "txtMessageToBeSend");
            this.txtMessageToBeSend.Name = "txtMessageToBeSend";
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // connectServerGroupBox
            // 
            resources.ApplyResources(this.connectServerGroupBox, "connectServerGroupBox");
            this.connectServerGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.connectServerGroupBox.Controls.Add(this.PortLabel);
            this.connectServerGroupBox.Controls.Add(this.txtChatServerPort);
            this.connectServerGroupBox.Controls.Add(this.inputUsername);
            this.connectServerGroupBox.Controls.Add(this.username);
            this.connectServerGroupBox.Controls.Add(this.ipLabel);
            this.connectServerGroupBox.Controls.Add(this.btnConnect);
            this.connectServerGroupBox.Controls.Add(this.txtChatServerIP);
            this.connectServerGroupBox.Name = "connectServerGroupBox";
            this.connectServerGroupBox.TabStop = false;
            // 
            // PortLabel
            // 
            resources.ApplyResources(this.PortLabel, "PortLabel");
            this.PortLabel.Name = "PortLabel";
            // 
            // txtChatServerPort
            // 
            resources.ApplyResources(this.txtChatServerPort, "txtChatServerPort");
            this.txtChatServerPort.Name = "txtChatServerPort";
            // 
            // inputUsername
            // 
            resources.ApplyResources(this.inputUsername, "inputUsername");
            this.inputUsername.Name = "inputUsername";
            this.inputUsername.TextChanged += new System.EventHandler(this.inputUsername_TextChanged);
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
            // txtChatServerIP
            // 
            resources.ApplyResources(this.txtChatServerIP, "txtChatServerIP");
            this.txtChatServerIP.Name = "txtChatServerIP";
            // 
            // messageBox
            // 
            resources.ApplyResources(this.messageBox, "messageBox");
            this.messageBox.BackColor = System.Drawing.SystemColors.Window;
            this.messageBox.FormattingEnabled = true;
            this.messageBox.Name = "messageBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Name = "label2";
            // 
            // btnStopServer
            // 
            resources.ApplyResources(this.btnStopServer, "btnStopServer");
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.connectServerGroupBox);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessageToBeSend);
            this.Controls.Add(this.btnStartServer);
            this.Name = "ChatForm";
            this.connectServerGroupBox.ResumeLayout(false);
            this.connectServerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtChatServerPort;
        private System.Windows.Forms.Label PortLabel;

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox inputUsername;

        private System.Windows.Forms.Label username;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.GroupBox connectServerGroupBox;
        private System.Windows.Forms.TextBox txtChatServerIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox messageBox;

        private System.Windows.Forms.TextBox txtMessageToBeSend;
        private System.Windows.Forms.Button btnSend;

        private System.Windows.Forms.Button btnStartServer;

    #endregion
    private System.Windows.Forms.Button btnStopServer;
  }
}