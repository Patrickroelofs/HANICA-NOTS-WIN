using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace bp01_chatapplicatie
{
  class Server
  {
    private TcpClient _tcpClient;
    private TcpListener _tcpListener;
    private NetworkStream _networkStream;
    private List<TcpClient> _clientsConnected = new List<TcpClient>();

    private bool _serverRunning;

    public Server(string ip, int port)
    {
      _tcpListener = new TcpListener(new IPEndPoint(IPAddress.Any, port));
    }

    private void UpdateClients(TcpClient tcpClient)
    {
      if(_clientsConnected.Count > 0 && _clientsConnected.Contains(tcpClient))
      {
        // TODO: Update client list
      } 
    }

    private void WipeClients()
    {
      // TODO: Wipe client list when needed
    }

    private void AddMessage(string message)
    {
      // TODO: Add message to chat
    }

    public async Task StartServer()
    {
      // TODO: Start Server
      // TODO: Check if input fields are correct e.g (port > 65535) etc
      // TODO: Add IPAdress input field to tcpListener
      try
      {
        _tcpListener.Start();
        _serverRunning = true;
        
        AddMessage("Server started...");
        
        // TODO: Wait for clients to connect
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    private void StopServer()
    {
      // TODO: Stop Server
    }

    private void ReceiveData(TcpClient tcpClient, int bufferSize)
    {
      // TODO: Receive data from client
    }

    private void SendDisconnectMessagesToClient(TcpClient tcpClient, string message)
    {
      // TODO: Send Disconnect Message to Client
    }

    private void SendMessageToClients(string message)
    {
      // TODO: Send message to all clients
    }
  }
}
