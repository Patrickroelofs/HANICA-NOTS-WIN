using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bp01_chatapplicatie
{
  public partial class ServerForm : Form
  {

    private TcpClient _client;
    private TcpListener _tcpListener;
    private List<TcpClient> clientsConnected = new List<TcpClient>();

    public ServerForm()
    {
      InitializeComponent();
      
      // disable stop server button on startup
      stopServerButton.Visible = false;
      SendMessageBox.Visible = false;
      clientsConnectedBox.Visible = false;
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
      _tcpListener = new TcpListener(IPAddress.Any, 3000);
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

    private async void MessageReceiver(TcpClient client)
    {
      byte[] buffer = new byte[Parsers.ParsePort(serverBufferSize.Text)];
      NetworkStream networkStream = client.GetStream();

      while (networkStream.CanRead)
      {
        int bytes = await networkStream.ReadAsync(buffer, 0, Parsers.ParsePort(serverBufferSize.Text));
        string message = Encoding.ASCII.GetString(buffer, 0, bytes);

        AddMessage(message);
        await SendMessageToClients(message);
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


      foreach (TcpClient client in clientsConnected)
      {
        client.Close();
      }
      
      clientsConnected.Clear();
      _tcpListener.Stop();
    }
  }
}
