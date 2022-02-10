using System;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace bp01_chatapplicatie
{
  public partial class ChatForm : Form
  {
    private Client _client;
    private Server _server;

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
      using (ServerForm form = new ServerForm())
      {
        if (form.ShowDialog() == DialogResult.OK)
        {


          // Disable Start Server button
          btnStartServer.Visible = false;
          btnStopServer.Visible = true;

          // Disable Connect to Server groupbox
          connectServerGroupBox.Visible = false;
          
          // Enable Chat box
          btnSend.Enabled = true;
          txtMessageToBeSend.Enabled = true;
        }
      }
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