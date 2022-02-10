using System.Net.Sockets;

namespace bp01_chatapplicatie
{
  public class Client
  {
    private TcpClient _client;
    private NetworkStream _stream;

    private void AddMessage(string message)
    {
      // TODO: Add Message
    }

    private void updateDisplay()
    {
      // TODO: Update Display
    }

    public void Connect(string name, string ip, string port, string bufferSize)
    {
      // TODO: Connect to the server
    }

    private void UpdateClients()
    {
      // TODO: Update clients list box
    }

    private void ReceiveData(int bufferSize)
    {
      // TODO: Receive data from the server
    }

    private void DisconnectClient()
    {
      // TODO: Disconnect client
    }

    private void SendMessageToServer()
    {
      // TODO: Send message to the server
    }
  }
}
