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
    private string CLOSE_SERVER = "CLOSE_SERVER+";
    private string DISCONNECT = "DISCONNECT+";
    private string MESSAGE = "MESSAGE+";
    private string CONNECT = "CONNECT+";

    private TcpClient _client;
    private NetworkStream _networkStream;

    public ChatForm()
    {
      InitializeComponent();
      
      // Disable chat when not connected to server
      btnSendMessage.Enabled = false;
      clientMessage.Enabled = false;
      btnDisconnect.Visible = false;
      
      MinimumSize = new Size(600, 400);
    }

    // Start server button, opens new Form
    private void btnStartServer_Click(object sender, EventArgs e)
    {
      connectServerGroupBox.Visible = false;
      clientMessage.Enabled = false;
      btnSendMessage.Enabled = false;

      Hide();
      ServerForm form = new ServerForm();
      form.ShowDialog();
    }

    // Connect to server as client
    private async void btnConnect_Click(object sender, EventArgs e)
    {
      try
      {
        // if all inputs are correct
        if (Parsers.ParseInputs(clientIP.Text, clientPort.Text, clientUsername.Text, clientBufferSize.Text))
        {
          AddMessage("Attempting to connect to " + clientIP.Text + ":" + clientPort.Text);

          _client = new TcpClient();
          await _client.ConnectAsync(clientIP.Text, Parsers.ParseToInt(clientPort.Text));
      
          _networkStream = _client.GetStream();

          btnSendMessage.Enabled = true;
          btnStartServer.Visible = false;
          clientMessage.Enabled = true;
          connectServerGroupBox.Visible = false;
          btnDisconnect.Visible = true;

          AddMessage("Connected to " + clientIP.Text + ":" + clientPort.Text);
          await SendMessageToServer("", clientUsername.Text, CONNECT);

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

    // Send message to the server on click
    private async void btnSend_Click(object sender, EventArgs e)
    {
      await SendMessageToServer(" : " + clientMessage.Text, clientUsername.Text, MESSAGE);
    }

    // send message to the server
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

    // Receives messages and parses them through custom filters.
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

          // loop over the message and append every bit from the buffer to the string, continue when done.
          if (networkStream.CanRead)
          {
            do
            {
              numberOfBytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
              completeMessage.Append(Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead));
            } while (networkStream.DataAvailable);
          }
          
          // if the message contains the close server command, disconnect the client
          if (completeMessage.ToString().StartsWith(CLOSE_SERVER) && completeMessage.Length > 0)
          {
            completeMessage.Remove(0, CLOSE_SERVER.Length);
              
            AddMessage(completeMessage.ToString());

            _networkStream.Close();
            _client.Close();

          }
          else
          {
            // Write message to list
            if (completeMessage.Length > 0)
            {
              AddMessage("" + completeMessage);
            }
          }
        }
      }
      catch (ObjectDisposedException)
      {
        btnSendMessage.Invoke(new Action(() => btnSendMessage.Enabled = false));
        clientMessage.Invoke(new Action(() => clientMessage.Enabled = false));
        btnStartServer.Invoke(new Action(() => btnStartServer.Visible = true));
        connectServerGroupBox.Invoke(new Action(() => connectServerGroupBox.Visible = true));
        btnDisconnect.Invoke(new Action(() => btnDisconnect.Visible = false));
        
        AddMessage("Server was shutdown.");
      }
    }

    // Add Message to client listbox
    private void AddMessage(string message)
    {
      clientMessageList.Invoke(new Action(() => clientMessageList.Items.Add(message)));
    }

    // Client disconnect button
    private async void clientDisconnect_Click(object sender, EventArgs e)
    { 
      btnSendMessage.Enabled = false;
      clientMessage.Enabled = false;
      btnStartServer.Visible = true;
      connectServerGroupBox.Visible = true;
      btnDisconnect.Visible = false;
      
      await SendMessageToServer("", clientUsername.Text, DISCONNECT);
    }

    // Catch the enter key so the client can send messages with keyboard.
    private void clientMessage_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        btnSendMessage.PerformClick();
      }
    }

    // Catch the windows close program button and ensure the client gets stopped when closing the form.
    private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        DialogResult result = MessageBox.Show("Are you sure you want to close the client this will also disconnect it?", "Close Client", MessageBoxButtons.YesNo);

        if (result == DialogResult.Yes)
        {
          btnDisconnect.PerformClick();

          Environment.Exit(0);
        }
        else
        {
          e.Cancel = true;
        }
      }
    }
  }
}