using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace TCPServer
{
    public partial class TCPServer : Form
    {
        TcpListener listener;
        TcpClient client;
        int port = 12345;
        
        public TCPServer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TCPServer_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e) //När knappen trycks på så startas servern
        {
            listener = new TcpListener(IPAddress.Any, port); //En ny lyssnare till IP adressen och porten skapas
            listener.Start(); //Lyssnaren startas
            client = listener.AcceptTcpClient(); //Lyssnaren accepterar förfrågan att ansluta från klienten.

            byte[] inData = new byte[256];
            int byteAmount = client.GetStream().Read(inData, 0, inData.Length); //Servern läser in meddelandet skickat från klienten. 

            tbxInbox.Text = Encoding.Unicode.GetString(inData, 0, byteAmount); //Servern skriver ut meddelandet som kommer från klienten i textrutan.
            client.Close();
            listener.Stop();
        }

        private void tbxInbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
