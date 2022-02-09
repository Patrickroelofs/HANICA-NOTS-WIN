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
    private readonly IPAddress _ipAdress = IPAddress.Parse("127.0.0.1");
    private DataParser _dataParser;
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

        Thread thread = new Thread(delegate ()
        {
          while(true)
          {
            try
            {
              if (!_server.Pending()) continue;
              var client = _server.AcceptTcpClient();
              Clients.Add(client);

              foreach(var clientItem in Clients)
              {
                _dataParser = new DataParser(clientItem, delegate (string input)
                {
                  _updateDisplay(input);
                });
              }

            } catch(Exception ex)
            {
              Debug.WriteLine(ex);
            }
          }
        });

        thread.Start();

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
      foreach(var stream in Clients.Select(client => client.GetStream()))
      {
        _dataParser.SendMessages(stream, input);
      }
    }
  }
}
