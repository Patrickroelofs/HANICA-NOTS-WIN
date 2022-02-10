using System;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace bp01_chatapplicatie
{
  public partial class ChatForm : Form
  {

    public ChatForm()
    {
      InitializeComponent();
      
      // Disable chat when not connected to server
      btnSend.Enabled = false;
      txtMessageToBeSend.Enabled = false;
      
      // Disable stop server button when not connected (or started) server
      btnStopServer.Visible = false;
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
    }

    private void btnSend_Click(object sender, EventArgs e)
    {

    }
    
    private void inputUsername_TextChanged(object sender, EventArgs e)
    {
      
    }

    private void btnStartServer_Click(object sender, EventArgs e)
    {
      connectServerGroupBox.Visible = false;
      txtMessageToBeSend.Enabled = false;
      btnSend.Enabled = false;

      ServerForm form = new ServerForm();
      form.ShowDialog();
    }

    private void btnStopServer_Click(object sender, EventArgs e)
    {
      // Disable Start Server button
      btnStartServer.Visible = true;
      btnStopServer.Visible = false;

      // Disable Connect to Server groupbox
      connectServerGroupBox.Visible = true;
    }
  }
}