using System;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Net.Sockets;

namespace bp01_chatapplicatie
{
  public class Client
  {
    private NetworkStream _networkStream;
    public delegate void UpdateDisplayDelegate(string input);
    private readonly UpdateDisplayDelegate _updateDisplayDelegate;

    public Client(IPAddress ipAddress, int port, UpdateDisplayDelegate updateDisplayDelegate)
    {
      this._updateDisplayDelegate = updateDisplayDelegate;

      Thread thread = new Thread(delegate ()
      {
        try
        {
          TcpClient client = new TcpClient();
          client.Connect(new IPEndPoint(ipAddress, port));
          _networkStream = client.GetStream();

        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex);
        }
      });

      thread.Start();
    }
  }
}
