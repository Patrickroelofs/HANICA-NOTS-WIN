namespace bp01_chatapplicatie
{
    partial class Client
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
      this.btnListen = new System.Windows.Forms.Button();
      this.txtMessageToBeSend = new System.Windows.Forms.TextBox();
      this.btnSend = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtChatServerIP = new System.Windows.Forms.TextBox();
      this.MessageBox = new System.Windows.Forms.ListBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnListen
      // 
      resources.ApplyResources(this.btnListen, "btnListen");
      this.btnListen.Name = "btnListen";
      this.btnListen.UseVisualStyleBackColor = true;
      this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
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
      // groupBox1
      // 
      resources.ApplyResources(this.groupBox1, "groupBox1");
      this.groupBox1.BackColor = System.Drawing.Color.Transparent;
      this.groupBox1.Controls.Add(this.btnConnect);
      this.groupBox1.Controls.Add(this.txtChatServerIP);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
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
      // MessageBox
      // 
      resources.ApplyResources(this.MessageBox, "MessageBox");
      this.MessageBox.BackColor = System.Drawing.SystemColors.Window;
      this.MessageBox.FormattingEnabled = true;
      this.MessageBox.Name = "MessageBox";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.ForeColor = System.Drawing.Color.Yellow;
      this.label2.Name = "label2";
      // 
      // Client
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
      resources.ApplyResources(this, "$this");
      this.Controls.Add(this.label2);
      this.Controls.Add(this.MessageBox);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnSend);
      this.Controls.Add(this.txtMessageToBeSend);
      this.Controls.Add(this.btnListen);
      this.Name = "Client";
      this.TopMost = true;
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtChatServerIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox MessageBox;

        private System.Windows.Forms.TextBox txtMessageToBeSend;
        private System.Windows.Forms.Button btnSend;

        private System.Windows.Forms.Button btnListen;

        #endregion
    }
}