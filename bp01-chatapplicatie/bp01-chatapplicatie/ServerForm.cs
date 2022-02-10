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

    public ServerForm()
    {
      InitializeComponent();
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


      while (true)
      {
        _client = await _tcpListener.AcceptTcpClientAsync();
      }
    }
  }
}
