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

    public Server()
    {
      _server = new TcpListener(new IPEndPoint(_ipAdress, 3000));
    }

    public void startServer()
    {
      try
      {
        _server.Start();

        Thread thread = new Thread(delegate ()
        {
          while(true)
          {
            Debug.WriteLine("Poggers");
          }
        });
      } catch (Exception ex)
      {
        Debug.WriteLine(ex);
        stopServer();
      }
    }

    public void stopServer()
    {
      Debug.WriteLine("STOPPING SERVER");
      _server.Stop();
    }
  }
}
