using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bp01_chatapplicatie
{
  public partial class ServerForm : Form
  {
    public string ValueForUsername { get; set; }
    public string ValueForIP { get; set; }
    public int ValueForPort { get; set; }
    public string ValueForBufferSize { get; set; }

    public ServerForm()
    {
      InitializeComponent();

      // Set result of dialog to OK so that ChatForm can pick it up
      startServer.DialogResult = DialogResult.OK;
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

    private void startServer_Click(object sender, EventArgs e)
    {
      ValueForUsername = serverUsername.Text;
      ValueForIP = serverIP.Text;
      ValueForPort = Parsers.ParsePortStringToPortInt(serverPort.Text);
      ValueForBufferSize = serverBufferSize.Text;
    }
  }
}
