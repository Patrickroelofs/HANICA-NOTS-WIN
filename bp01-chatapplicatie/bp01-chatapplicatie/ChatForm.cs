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
        if (Parsers.ParseInputs(clientIP.Text, clientPort.Text, clientUsername.Text, clientBufferSize.Text))
        {
          AddMessage("Attempting to connect to " + clientIP.Text + ":" + clientPort.Text);

          _client = new TcpClient();
          await _client.ConnectAsync(clientIP.Text, Parsers.ParseToInt(clientPort.Text));
      
          _networkStream = _client.GetStream();

          clientSendMessage.Enabled = true;
          btnStartServer.Visible = false;
          clientMessage.Enabled = true;
          connectServerGroupBox.Visible = false;

          AddMessage("Connected to " + clientIP.Text + ":" + clientPort.Text);

          await Task.Run(MessageReceiver);
        }
        
        AddMessage("One or more inputs are incorrect, please try again.");
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
      try
      {
        byte[] buffer = new byte[Parsers.ParseToInt(clientBufferSize.Text)];
        NetworkStream networkStream = _client.GetStream();
        int numberOfBytesRead;

        while (true)
        {
          StringBuilder completeMessage = new StringBuilder();
        
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
      }
      catch (ObjectDisposedException)
      {
        AddMessage("Server was shut down.");
      }
    }

    private void AddMessage(string message)
    {
      clientMessageList.Invoke(new Action(() => clientMessageList.Items.Add(message)));
    }
  }
}