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
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private Thread _thread;

        public Client()
        {
            InitializeComponent();
        }

        public delegate void setMessage(string input);

        private void btnListen_Click(object sender, EventArgs e)
        {
            var server = new TcpListener(IPAddress.Any, 9000);
            server.Start();

            MessageBox.Items.Add("Listening for a client..." + Environment.NewLine);

            _tcpClient = server.AcceptTcpClient();
            _thread = new Thread(new ThreadStart(ReceiveData));
            _thread.Start();
        }

        private void ReceiveData()
        {
            int bufferSize = 1024;
            string message;
            byte[] buffer = new byte[bufferSize];

            _networkStream = _tcpClient.GetStream();

            while(true)
            {
                int readBytes = _networkStream.Read(buffer, 0, buffer.Length);
                message = Encoding.ASCII.GetString(buffer);

                if (message == "bye") break;
            }
        }
    }
}