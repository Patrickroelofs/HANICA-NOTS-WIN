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
    private string CLOSE_SERVER = "~close_server~";
    
    private TcpClient _client;
    private NetworkStream _networkStream;

    public ChatForm()
    {
      InitializeComponent();
      
      // Disable chat when not connected to server
      clientSendMessage.Enabled = false;
      clientMessage.Enabled = false;
      clientDisconnect.Visible = false;
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
          clientDisconnect.Visible = true;

          AddMessage("Connected to " + clientIP.Text + ":" + clientPort.Text);
          await SendMessageToServer("", clientUsername.Text, "~connect~");

          await Task.Run(MessageReceiver);
        }
        else
        {
          AddMessage("One or more inputs are incorrect, please try again.");
        }
      }
      catch (SocketException)
      {
        AddMessage("Could not connect to server");
      }
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
      await SendMessageToServer(" : " + clientMessage.Text, clientUsername.Text, "~message~");
    }

    private async Task SendMessageToServer(string message, string chatUsername, string command)
    {
      if (_networkStream.CanWrite)
      {
        byte[] messageByteArray = Encoding.ASCII.GetBytes(command + chatUsername + message);
        await _networkStream.WriteAsync(messageByteArray, 0, messageByteArray.Length);
      }
      
      clientMessage.Clear();
      clientMessage.Focus();
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
      NetworkStream networkStream = _client.GetStream();
      int numberOfBytesRead;

      try
      {
        while (true)
        {
          StringBuilder completeMessage = new StringBuilder();
      
          if (networkStream.CanRead)
          {
            do
            {
              numberOfBytesRead = await networkStream.ReadAsync(buffer, 0, Parsers.ParseToInt(clientBufferSize.Text));
              completeMessage.Append(Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead));


              if (completeMessage.ToString().StartsWith(CLOSE_SERVER) && completeMessage.Length > 0)
              {
                completeMessage.Remove(0, CLOSE_SERVER.Length);
              
                AddMessage(completeMessage.ToString());

                _networkStream.Close();
                _client.Close();

              }
              else
              {
                if (completeMessage.Length > 0)
                {
                  AddMessage("" + completeMessage);
                }
              }
            } while (networkStream.DataAvailable);
          }
        }
      }
      catch (ObjectDisposedException)
      {
        clientSendMessage.Invoke(new Action(() => clientSendMessage.Enabled = false));
        clientMessage.Invoke(new Action(() => clientMessage.Enabled = false));
        btnStartServer.Invoke(new Action(() => btnStartServer.Visible = true));
        connectServerGroupBox.Invoke(new Action(() => connectServerGroupBox.Visible = true));
        clientDisconnect.Invoke(new Action(() => clientDisconnect.Visible = false));
        
        AddMessage("Server was shutdown.");
      }
    }

    private void AddMessage(string message)
    {
      clientMessageList.Invoke(new Action(() => clientMessageList.Items.Add(message)));
    }

    private async void clientDisconnect_Click(object sender, EventArgs e)
    {
      clientSendMessage.Invoke(new Action(() => clientSendMessage.Enabled = false));
      clientMessage.Invoke(new Action(() => clientMessage.Enabled = false));
      btnStartServer.Invoke(new Action(() => btnStartServer.Visible = true));
      connectServerGroupBox.Invoke(new Action(() => connectServerGroupBox.Visible = true));
      clientDisconnect.Invoke(new Action(() => clientDisconnect.Visible = false));
      
      await SendMessageToServer("", clientUsername.Text, "~disconnect~");
    }

    private void clientMessage_KeyDown_2(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        btnSend_Click(sender, e);
      }
    }
  }
}