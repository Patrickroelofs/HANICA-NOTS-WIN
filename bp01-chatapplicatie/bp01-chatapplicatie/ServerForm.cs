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

    public ServerForm()
    {
      InitializeComponent();

      //Disable all settings during startup.
      serverName.Enabled = false;
      serverIP.Enabled = false;
      serverPort.Enabled = false;
      serverBufferSize.Enabled = false;

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

    }
  }
}
