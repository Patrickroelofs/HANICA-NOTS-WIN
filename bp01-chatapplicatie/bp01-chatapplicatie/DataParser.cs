using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace bp01_chatapplicatie
{
  internal class DataParser
  {
    public delegate void UpdateDisplayDelegate(string input);
    private readonly UpdateDisplayDelegate _updateDisplayDelegate;

    public DataParser(TcpClient client, UpdateDisplayDelegate updateDisplayDelegate)
    {
      this._updateDisplayDelegate = updateDisplayDelegate;

      ReceiveMessages(client);
    }

    public  void ReceiveMessages(TcpClient client)
    {
      var byteArray = new byte[1024];
      string data;
      Thread thread = new Thread(delegate ()
      {
        NetworkStream stream = client.GetStream();
        _updateDisplayDelegate("Connected");

        var listen = true;
        var looping = true;

        while(looping)
        {
          if(listen)
          {
            try
            {
              var i = stream.Read(byteArray, 0, byteArray.Length);

              data = Encoding.ASCII.GetString(byteArray);

              foreach(var clientItem in Server.Clients)
              {
                if(client != clientItem)
                {
                  var streamItem = clientItem.GetStream();
                  streamItem.Write(byteArray, 0, byteArray.Length);
                }
              }

              Array.Clear(byteArray, 0, byteArray.Length);
            }catch (Exception ex)
            {
              Debug.WriteLine("Lost connection");
            }
          }
        }
      });

      thread.Start();
    }

    public  void SendMessages(NetworkStream stream, string message)
    {
      try
      {
        var byteArray = new byte[message.Length];

        byteArray = Encoding.ASCII.GetBytes(message);
        stream.Write(byteArray, 0, byteArray.Length);

        _updateDisplayDelegate(message);
      } catch (Exception ex)
      {
        _updateDisplayDelegate(ex.Message);
      }
    }
  }
}
