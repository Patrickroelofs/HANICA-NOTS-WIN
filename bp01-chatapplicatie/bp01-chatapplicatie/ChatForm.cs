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
      clientSendMessage.Enabled = false;
      clientMessage.Enabled = false;
    }

    private async void btnConnect_Click(object sender, EventArgs e)
    {
      try
      {
        _client = new TcpClient();
        await _client.ConnectAsync(clientIP.Text, Parsers.ParsePort(clientPort.Text));
      
        _networkStream = _client.GetStream();

        clientSendMessage.Enabled = true;
        btnStartServer.Visible = false;
        clientMessage.Enabled = true;
        connectServerGroupBox.Visible = false;

        await Task.Run(MessageReceiver);
      }
      catch (SocketException)
      {
        AddMessage("Could not connect to server");
      }
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
      if (_networkStream.CanWrite)
      {
        byte[] messageByteArray = Encoding.ASCII.GetBytes(clientUsername.Text + " : " + clientMessage.Text);
        await _networkStream.WriteAsync(messageByteArray, 0, messageByteArray.Length);
      }
      
      clientMessage.Clear();
      clientMessage.Focus();
    }
    
    private void inputUsername_TextChanged(object sender, EventArgs e)
    {
      
    }

    private void btnStartServer_Click(object sender, EventArgs e)
    {
      connectServerGroupBox.Visible = false;
      clientMessage.Enabled = false;
      clientSendMessage.Enabled = false;

      Hide();
      ServerForm form = new ServerForm();
      form.ShowDialog();
    }

    private async void MessageReceiver()
    {
      byte[] buffer = new byte[Parsers.ParseToInt(clientBufferSize.Text)];
      StringBuilder completeMessage = new StringBuilder();
      NetworkStream networkStream = _client.GetStream();
      int numberOfBytesRead;

      if (networkStream.CanRead)
      {
        do
        {
          numberOfBytesRead = await networkStream.ReadAsync(buffer, 0, Parsers.ParseToInt(clientBufferSize.Text));
          completeMessage.Append(Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead));

          AddMessage("" + completeMessage);
        } while (networkStream.DataAvailable);
      }
    }

    private void AddMessage(string message)
    {
      clientMessageList.Invoke(new Action(() => clientMessageList.Items.Add(message)));
    }
  }
}