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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.stopServerButton = new System.Windows.Forms.Button();
      this.startServerClick = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.serverBufferSize = new System.Windows.Forms.TextBox();
      this.serverPort = new System.Windows.Forms.TextBox();
      this.serverIP = new System.Windows.Forms.TextBox();
      this.serverUsername = new System.Windows.Forms.TextBox();
      this.clientsConnectedBox = new System.Windows.Forms.GroupBox();
      this.clientsConnectedListBox = new System.Windows.Forms.ListBox();
      this.chatBox = new System.Windows.Forms.GroupBox();
      this.chatListBox = new System.Windows.Forms.ListBox();
      this.groupBox1.SuspendLayout();
      this.clientsConnectedBox.SuspendLayout();
      this.chatBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.Transparent;
      this.groupBox1.Controls.Add(this.stopServerButton);
      this.groupBox1.Controls.Add(this.startServerClick);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.serverBufferSize);
      this.groupBox1.Controls.Add(this.serverPort);
      this.groupBox1.Controls.Add(this.serverIP);
      this.groupBox1.Controls.Add(this.serverUsername);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(334, 156);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Server Settings";
      // 
      // stopServerButton
      // 
      this.stopServerButton.Location = new System.Drawing.Point(245, 123);
      this.stopServerButton.Name = "stopServerButton";
      this.stopServerButton.Size = new System.Drawing.Size(83, 23);
      this.stopServerButton.TabIndex = 9;
      this.stopServerButton.Text = "Stop Server";
      this.stopServerButton.UseVisualStyleBackColor = true;
      this.stopServerButton.Click += new System.EventHandler(this.stopServerButton_Click);
      // 
      // startServerClick
      // 
      this.startServerClick.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.startServerClick.Location = new System.Drawing.Point(245, 123);
      this.startServerClick.Name = "startServerClick";
      this.startServerClick.Size = new System.Drawing.Size(83, 23);
      this.startServerClick.TabIndex = 8;
      this.startServerClick.Text = "Start Server";
      this.startServerClick.UseVisualStyleBackColor = true;
      this.startServerClick.Click += new System.EventHandler(this.startServerClick_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 100);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(58, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Buffer Size";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 74);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(26, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Port";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(17, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "IP";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 22);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Username";
      // 
      // serverBufferSize
      // 
      this.serverBufferSize.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.serverBufferSize.Location = new System.Drawing.Point(116, 97);
      this.serverBufferSize.Name = "serverBufferSize";
      this.serverBufferSize.Size = new System.Drawing.Size(212, 20);
      this.serverBufferSize.TabIndex = 3;
      this.serverBufferSize.Text = "1024";
      // 
      // serverPort
      // 
      this.serverPort.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.serverPort.Location = new System.Drawing.Point(116, 71);
      this.serverPort.Name = "serverPort";
      this.serverPort.Size = new System.Drawing.Size(212, 20);
      this.serverPort.TabIndex = 2;
      this.serverPort.Text = "3000";
      // 
      // serverIP
      // 
      this.serverIP.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.serverIP.Location = new System.Drawing.Point(116, 45);
      this.serverIP.Name = "serverIP";
      this.serverIP.Size = new System.Drawing.Size(212, 20);
      this.serverIP.TabIndex = 1;
      this.serverIP.Text = "127.0.0.1";
      // 
      // serverUsername
      // 
      this.serverUsername.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.serverUsername.Location = new System.Drawing.Point(116, 19);
      this.serverUsername.Name = "serverUsername";
      this.serverUsername.Size = new System.Drawing.Size(212, 20);
      this.serverUsername.TabIndex = 0;
      this.serverUsername.Text = "Patrick";
      // 
      // clientsConnectedBox
      // 
      this.clientsConnectedBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
      this.clientsConnectedBox.Controls.Add(this.clientsConnectedListBox);
      this.clientsConnectedBox.Location = new System.Drawing.Point(12, 174);
      this.clientsConnectedBox.Name = "clientsConnectedBox";
      this.clientsConnectedBox.Size = new System.Drawing.Size(334, 248);
      this.clientsConnectedBox.TabIndex = 1;
      this.clientsConnectedBox.TabStop = false;
      this.clientsConnectedBox.Text = "Clients Connected";
      // 
      // clientsConnectedListBox
      // 
      this.clientsConnectedListBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
      this.clientsConnectedListBox.FormattingEnabled = true;
      this.clientsConnectedListBox.Location = new System.Drawing.Point(6, 17);
      this.clientsConnectedListBox.Name = "clientsConnectedListBox";
      this.clientsConnectedListBox.Size = new System.Drawing.Size(322, 225);
      this.clientsConnectedListBox.TabIndex = 0;
      // 
      // chatBox
      // 
      this.chatBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.chatBox.Controls.Add(this.chatListBox);
      this.chatBox.Location = new System.Drawing.Point(352, 12);
      this.chatBox.Name = "chatBox";
      this.chatBox.Size = new System.Drawing.Size(310, 410);
      this.chatBox.TabIndex = 3;
      this.chatBox.TabStop = false;
      this.chatBox.Text = "Chats";
      // 
      // chatListBox
      // 
      this.chatListBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.chatListBox.FormattingEnabled = true;
      this.chatListBox.Location = new System.Drawing.Point(6, 22);
      this.chatListBox.Name = "chatListBox";
      this.chatListBox.Size = new System.Drawing.Size(298, 381);
      this.chatListBox.TabIndex = 0;
      // 
      // ServerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.ClientSize = new System.Drawing.Size(674, 434);
      this.Controls.Add(this.chatBox);
      this.Controls.Add(this.clientsConnectedBox);
      this.Controls.Add(this.groupBox1);
      this.DoubleBuffered = true;
      this.Name = "ServerForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Bikini Bottom Server";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.clientsConnectedBox.ResumeLayout(false);
      this.chatBox.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button stopServerButton;

    private System.Windows.Forms.GroupBox chatBox;
    private System.Windows.Forms.ListBox chatListBox;

    private System.Windows.Forms.GroupBox clientsConnectedBox;
    private System.Windows.Forms.ListBox clientsConnectedListBox;

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button startServerClick;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox serverBufferSize;
    private System.Windows.Forms.TextBox serverPort;
    private System.Windows.Forms.TextBox serverIP;
    private System.Windows.Forms.TextBox serverUsername;
  }
}