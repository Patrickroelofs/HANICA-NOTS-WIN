using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace bp01_chatapplicatie
{
  class Server
  {
    private readonly IPAddress _ipAdress = IPAddress.Any;
    private readonly TcpListener _server;

    public static List<TcpClient> Clients = new List<TcpClient>();

    public delegate void UpdateDisplayDelegate(string input);
    private readonly UpdateDisplayDelegate _updateDisplay;

    public Server(int port, UpdateDisplayDelegate updateDisplayDelegate)
    {
      this._updateDisplay = updateDisplayDelegate;
      _server = new TcpListener(new IPEndPoint(_ipAdress, 3000));
    }

    public void startServer()
    {
      try
      {
        _updateDisplay("Listening for Clients");
        _server.Start();

      } catch (Exception ex)
      {
        _updateDisplay("Cannot create server... Woops!");
        Debug.WriteLine(ex);
      }
    }

    public void stopServer()
    {
      try
      {
        _updateDisplay("Stopped Server");
        _server.Stop();
      } 
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
    }

    public void sendMessage(string input)
    {
      _updateDisplay(input);
    }
  }
}
