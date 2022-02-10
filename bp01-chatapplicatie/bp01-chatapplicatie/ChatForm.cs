using System;
using System.Net;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bp01_chatapplicatie
{
  public partial class ChatForm : Form
  {
    private TcpClient _client;
    private NetworkStream _networkStream;

    public ChatForm()
    {
      InitializeComponent();
      
      // Disable chat when not connected to server
      btnSend.Enabled = false;
      txtMessageToBeSend.Enabled = false;
      
      // Disable stop server button when not connected (or started) server
      btnStopServer.Visible = false;
    }

    private async void btnConnect_Click(object sender, EventArgs e)
    {
      btnSend.Enabled = true;
      txtMessageToBeSend.Enabled = true;
      
      _client = new TcpClient();
      await _client.ConnectAsync("127.0.0.1", 3000);
      
      _networkStream = _client.GetStream();

      await Task.Run(() => MessageReceiver());
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
      if (_networkStream.CanWrite)
      {
        byte[] messageByteArray = Encoding.ASCII.GetBytes(username + " : " + txtMessageToBeSend);
        await _networkStream.WriteAsync(messageByteArray, 0, messageByteArray.Length);
      }
      
      txtMessageToBeSend.Clear();
      txtMessageToBeSend.Focus();
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

    private async void MessageReceiver()
    {
      string message;
      byte[] buffer = new byte[1024];
      NetworkStream networkStream = _client.GetStream();

      while (networkStream.CanRead)
      {
        int bytes = await networkStream.ReadAsync(buffer, 0, 1024);
        message = Encoding.ASCII.GetString(buffer, 0, bytes);

        AddMessage(message);
      }
      
      networkStream.Close();
      _client.Close();
    }

    private void AddMessage(string message)
    {
      messageBox.Invoke(new Action(() => messageBox.Items.Add(message)));
    }
  }
}