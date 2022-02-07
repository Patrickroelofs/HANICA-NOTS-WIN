using System;
using System.Windows.Forms;

namespace bp01_chatapplicatie
{
  public partial class ChatForm : Form
  {

    public ChatForm()
    {
      InitializeComponent();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {

    }

    private void btnSend_Click(object sender, EventArgs e)
    {

    }

    private void btnStartServer_Click(object sender, EventArgs e)
    {
      using(ServerForm form = new ServerForm())
      {
        if(form.ShowDialog() == DialogResult.OK)
        {
          // Disable Start Server button
          // TODO: Add Delete Server Command
          btnStartServer.Text = "Server Started";
          btnStartServer.Enabled = false;

          // Disable Connect to Server groupbox
          connectServerGroupBox.Visible = false;

          // Enable Clients Connected Groupbox
          clientsConnectedGroupBox.Visible = true;
        }
      }
    }
  }
}