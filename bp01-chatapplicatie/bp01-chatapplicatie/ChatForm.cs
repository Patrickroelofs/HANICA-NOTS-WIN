using System;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;

namespace bp01_chatapplicatie
{
  public partial class ChatForm : Form
  {
    private Client _client;
    private Server _server;

    public ChatForm()
    {
      InitializeComponent();

      btnStopServer.Visible = false;
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      _updateDisplayDelegate("Connecting to server...");
      _client = new Client(IPAddress.Parse("127.0.0.1"), 3000, _updateDisplayDelegate);
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      if (_server != null)
      {
        _server.sendMessage(txtMessageToBeSend.Text);
      } 
      else
      {
        try
        {
          _client.SendMessage(txtMessageToBeSend.Text);
        } catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
        }
      }
    }

    private void btnStartServer_Click(object sender, EventArgs e)
    {
      using (ServerForm form = new ServerForm())
      {
        if (form.ShowDialog() == DialogResult.OK)
        {
          _server = new Server(3000, _updateDisplayDelegate);
          _server.startServer();

          // Disable Start Server button
          btnStartServer.Visible = false;
          btnStopServer.Visible = true;

          // Disable Connect to Server groupbox
          connectServerGroupBox.Visible = false;
        }
      }
    }

    private void btnStopServer_Click(object sender, EventArgs e)
    {
      _server.stopServer();

      // Disable Start Server button
      btnStartServer.Visible = true;
      btnStopServer.Visible = false;

      // Disable Connect to Server groupbox
      connectServerGroupBox.Visible = true;
    }

    private void _updateDisplayDelegate(string input)
    {
      Invoke(new Action(() =>
      {
        messageBox.Items.Add(input);
      }));
    }
  }
}