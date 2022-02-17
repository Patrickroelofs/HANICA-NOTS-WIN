using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bp01_chatapplicatie
{
  public partial class ServerForm : Form
  {
    private string CLOSE_SERVER = "CLOSE_SERVER+";
    private string DISCONNECT = "DISCONNECT+";
    private string MESSAGE = "MESSAGE+";
    private string CONNECT = "CONNECT+";

    private TcpClient _client;
    private TcpListener _tcpListener;
    private List<TcpClient> clientsConnected = new List<TcpClient>();

    public ServerForm()
    {
      InitializeComponent();

      // disable stop server button on startup
      btnStopServer.Visible = false;

      //Dont allow the window to be resized below this number
      MinimumSize = new Size(600, 400);
    }

    // Start server
    private async void btnStartServerAsync_Click(object sender, EventArgs e)
    {
      try
      {
        // Check if inputs are correct
        if (Parsers.ParseInputs(serverIP.Text, serverPort.Text, serverUsername.Text, serverBufferSize.Text))
        {
          // Start server
          _tcpListener = new TcpListener(IPAddress.Parse(serverIP.Text), Parsers.ParseToInt(serverPort.Text));
          _tcpListener.Start();

          btnStartServer.Enabled = false;
          serverBufferSize.Enabled = false;
          serverUsername.Enabled = false;
          serverPort.Enabled = false;
          serverIP.Enabled = false;

          btnStartServer.Visible = false;
          btnStopServer.Visible = true;

          // Accept clients if the server exists
          if (_tcpListener != null)
          {
            while (true)
            {
              _client = await _tcpListener.AcceptTcpClientAsync();
              clientsConnected.Add(_client);
              await Task.Run(() => MessageReceiverAsync(_client));
            }
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
      catch (ObjectDisposedException)
      {
        AddMessage("Server shutdown success.");
        EmptyClientList();
      }
    }

    // Receives messages and parses them through custom filters.
    private async void MessageReceiverAsync(TcpClient client)
    {
      byte[] buffer = new byte[Parsers.ParseToInt(serverBufferSize.Text)];
      NetworkStream networkStream = client.GetStream();
      int numberOfBytesRead;

      while (true)
      {
        StringBuilder completeMessage = new StringBuilder();

        if (networkStream.CanRead)
        {
          // loop over the message and append every bit from the buffer to the string, continue when done.
          do
          { 
            numberOfBytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
            completeMessage.Append(Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead));

          } while (networkStream.DataAvailable);

          // if the completemessage starts with the message signature
          if (completeMessage.ToString().StartsWith(MESSAGE))
          {
            completeMessage.Remove(0, MESSAGE.Length);
            
            AddMessage(completeMessage.ToString());
            await SendMessageToClientsAsync(completeMessage.ToString());


          } 
          // if the completemessage starts with the disconnect signature
          else if (completeMessage.ToString().StartsWith(DISCONNECT))
          {
            completeMessage.Remove(0, DISCONNECT.Length);
            AddMessage("Client " + completeMessage + " has disconnected.");
            await SendMessageToClientsAsync("Client " + completeMessage + " has disconnected.");
            RemoveClientFromList(client);
            
          } 
          // if the completemessage starts with the closeServer signature
          else if (completeMessage.ToString().StartsWith(CLOSE_SERVER))
          {
            completeMessage.Remove(0, CLOSE_SERVER.Length);
            EmptyClientList();

          } 
          // if the completemessage starts with the connect signature
          else if (completeMessage.ToString().StartsWith(CONNECT))
          {
            completeMessage.Remove(0, CONNECT.Length);

            listClientsConnected.Invoke(new Action(() =>
              listClientsConnected.Items.Add(completeMessage.ToString())));

            AddMessage(completeMessage + " has connected.");
            await SendMessageToClientsAsync(completeMessage + " has connected.");
          }
        }
      }
    }

    // Stop server on click
    private async void btnStopServerAsync_click(object sender, EventArgs e)
    {
      btnStartServer.Enabled = true;
      serverBufferSize.Enabled = true;
      serverUsername.Enabled = true;
      serverPort.Enabled = true;
      serverIP.Enabled = true;

      btnStartServer.Visible = true;
      btnStopServer.Visible = false;

      await SendMessageToClientsAsync(CLOSE_SERVER + "Server is shutting down, Goodbye... smell ya later!");

      _tcpListener.Stop();

      _client = null;
      _tcpListener = null;
    }

    // Catch the windows close program button and ensure the server gets stopped when closing the form.
    private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        DialogResult result = MessageBox.Show("Are you sure you want to close the server this will also shut it down?", "Close Server", MessageBoxButtons.YesNo);

        if (result == DialogResult.Yes)
        {
          btnStopServer.PerformClick();

          Environment.Exit(0);
        }
        else
        {
          e.Cancel = true;
        }
      }
    }

    // Send message to all connected clients
    private async Task SendMessageToClientsAsync(string message)
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

    // Add Message to server listbox
    private void AddMessage(string message)
    {
      listChatBox.Invoke(new Action(() => listChatBox.Items.Add(message)));
    }

    // Clear one client out of the client list and listbox.
    private void RemoveClientFromList(TcpClient client)
    {
      if (clientsConnected.Count > 0 && clientsConnected.Contains(client))
      {
        listClientsConnected.Invoke(new Action(() => listClientsConnected.Items.RemoveAt(clientsConnected.IndexOf(client))));
        clientsConnected.Remove(client);
        client.Close();
      }
    }

    // Clear the clients out of the list and listbox.
    private void EmptyClientList()
    {
      if (clientsConnected.Count > 0 && listClientsConnected.Items.Count > 0)
      {
        clientsConnected.Clear();
        listClientsConnected.Invoke(new Action(() => listClientsConnected.Items.Clear()));
      }
    }

    private async void btnSendMessage_Click(object sender, EventArgs e)
    {
      if (!btnStartServer.Enabled && serverChatBox.Text.Length > 0)
      {
        AddMessage(serverUsername.Text + " : " + serverChatBox.Text);
        await SendMessageToClientsAsync(MESSAGE + serverUsername.Text + " : " + serverChatBox.Text);
      
        serverChatBox.Clear();
        serverChatBox.Focus();
      }
    }
  }
}
