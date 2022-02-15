using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bp01_chatapplicatie
{
  public partial class ServerForm : Form
  {
    private string CLOSE_SERVER = "~close_server~";
    private string DISCONNECT = "~disconnect~";
    private string MESSAGE = "~message~";
    private string CONNECT = "~connect~";

    private TcpClient _client;
    private TcpListener _tcpListener;
    private List<TcpClient> clientsConnected = new List<TcpClient>();

    public ServerForm()
    {
      InitializeComponent();

      // disable stop server button on startup
      stopServerButton.Visible = false;
      SendMessageBox.Visible = false;
    }

    private void serverName_TextChanged(object sender, EventArgs e)
    {

    }

    private void serverIP_TextChanged(object sender, EventArgs e)
    {

    }

    private void serverPort_TextChanged(object sender, EventArgs e)
    {

    }

    private void serverBufferSize_TextChanged(object sender, EventArgs e)
    {

    }

    private async void startServerClick_Click(object sender, EventArgs e)
    {
      try
      {
        if (Parsers.ParseInputs(serverIP.Text, serverPort.Text, serverUsername.Text, serverBufferSize.Text))
        {
          _tcpListener = new TcpListener(IPAddress.Parse(serverIP.Text), Parsers.ParseToInt(serverPort.Text));
          _tcpListener.Start();

          startServerClick.Enabled = false;
          serverBufferSize.Enabled = false;
          serverUsername.Enabled = false;
          serverPort.Enabled = false;
          serverIP.Enabled = false;

          startServerClick.Visible = false;
          stopServerButton.Visible = true;

          while (true)
          {
            _client = await _tcpListener.AcceptTcpClientAsync();
            clientsConnected.Add(_client);
            await Task.Run(() => MessageReceiver(_client));
          }
        }
        else
        {
          AddMessage("One or more inputs are incorrect, please try again.");
        }
      }
      catch (SocketException)
      {
        AddMessage("There's already a server on those settings.");
      }
    }

    private async void MessageReceiver(TcpClient client)
    {
      byte[] buffer = new byte[Parsers.ParseToInt(serverBufferSize.Text)];
      NetworkStream networkStream = client.GetStream();
      int numberOfBytesRead;

      while (true)
      {
        StringBuilder completeMessage = new StringBuilder();

        if (networkStream.CanRead)
        {
          do
          {
            numberOfBytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
            completeMessage.Append(Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead));
          } while (networkStream.DataAvailable);

          if (completeMessage.ToString().StartsWith(MESSAGE))
          {
            completeMessage.Remove(0, MESSAGE.Length);
            
            AddMessage(completeMessage.ToString());
            await SendMessageToClients(completeMessage.ToString());
            
          } else if (completeMessage.ToString().StartsWith(DISCONNECT))
          {
            completeMessage.Remove(0, DISCONNECT.Length);

          } else if (completeMessage.ToString().StartsWith(CLOSE_SERVER))
          {
            completeMessage.Remove(0, CLOSE_SERVER.Length);

          } else if (completeMessage.ToString().StartsWith(CONNECT))
          {
            completeMessage.Remove(0, CONNECT.Length);

            clientsConnectedListBox.Invoke(new Action(() =>
              clientsConnectedListBox.Items.Add(completeMessage.ToString())));

            AddMessage(completeMessage + " has connected.");
            await SendMessageToClients(completeMessage + " has connected.");
          }
        }
      }
    }

    private async Task SendMessageToClients(string message)
    {
      if (clientsConnected.Count > 0)
      {
        foreach (TcpClient client in clientsConnected)
        {
          NetworkStream networkStream = client.GetStream();

          if (networkStream.CanRead)
          {
            byte[] serverMessageByteArray = Encoding.ASCII.GetBytes(message);
            await networkStream.WriteAsync(serverMessageByteArray, 0, serverMessageByteArray.Length);
          }
        }
      }
    }

    private void AddMessage(string message)
    {
      chatListBox.Invoke(new Action(() => chatListBox.Items.Add(message)));
    }

    private async void stopServerButton_Click(object sender, EventArgs e)
    {
      await SendMessageToClients("Server is shutting down");
      
      //TODO: Disconnect clients and shutdown server gracefully

      startServerClick.Enabled = true;
      serverBufferSize.Enabled = true;
      serverUsername.Enabled = true;
      serverPort.Enabled = true;
      serverIP.Enabled = true;

      startServerClick.Visible = true;
      stopServerButton.Visible = false;
    }
  }
}
