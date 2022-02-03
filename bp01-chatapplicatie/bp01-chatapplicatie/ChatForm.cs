using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace bp01_chatapplicatie
{
  public partial class Client : Form
  {
    TcpClient tcpClient;
    NetworkStream networkStream;
    Thread thread;

    protected delegate void UpdateDisplayDelegate(string message);

    public Client()
    {
      InitializeComponent();

      // Send message on input key enter
      txtMessageToBeSend.KeyDown += (sender, args) =>
      {
        if (args.KeyCode == Keys.Enter)
        {
          btnSend.PerformClick();
        }
      };
    }

    private void addMessage(string message)
    {
      if (MessageBox.InvokeRequired)
      {
        MessageBox.Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { message });
      } else
      {
        UpdateDisplay(message);
      }
    }

    private void UpdateDisplay(string message)
    {
      MessageBox.Items.Add(message);
    }

    private void btnListen_Click(object sender, EventArgs e)
    {
      TcpListener tcpListener = new TcpListener(IPAddress.Any, 9000);
      tcpListener.Start();

      addMessage("Listening for clients!");

      tcpClient = tcpListener.AcceptTcpClient();
      thread = new Thread(new ThreadStart(ReceiveData));
      thread.Start();
    }

    private void ReceiveData()
    {
      int bufferSize = 1024;
      string message = "";
      byte[] buffer = new byte[bufferSize];

      networkStream = tcpClient.GetStream();

      addMessage("Connected");

      while (true)
      {
        int readBytes = networkStream.Read(buffer, 0, bufferSize);
        message = Encoding.ASCII.GetString(buffer, 0, readBytes);

        if(message == "bye")
        {
          break;
        }

        addMessage(message);
      }

      buffer = Encoding.ASCII.GetBytes("bye");
      networkStream.Write(buffer, 0, buffer.Length);

      tcpClient.GetStream().Close();
      tcpClient.Close();

      addMessage("Connection Closed");
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      addMessage("Connecting");

      tcpClient = new TcpClient(txtChatServerIP.Text, 9000);
      thread = new Thread(new ThreadStart(ReceiveData));
      thread.Start();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      string message = txtMessageToBeSend.Text;

      byte[] buffer = Encoding.ASCII.GetBytes(message);
      networkStream.Write(buffer, 0, buffer.Length);

      addMessage(message);

      txtMessageToBeSend.Clear();
      txtMessageToBeSend.Focus();
    }
  }
}