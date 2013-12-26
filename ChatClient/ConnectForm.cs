using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLib;
using System.Net.Sockets;
using System.IO;

namespace ChatClient
{
    public partial class ConnectForm : Form
    {
        private string username, ip, port;
        private TcpClient client;
        public ConnectForm()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// this will load username ip and port defaults
        /// </summary>
        private void LoadData() 
        {
             username ="Amd";
             ip = StaticHelper.GetLocalIP();
             port = "9911";

            txt_UserName.Text = username;
            txt_ip.Text = ip;
            txt_Port.Text = port;
        }


        private bool Connect() 
        {
            var toReturn = false;
            try
            {
                client = new TcpClient();
                client.Connect(ip, Int32.Parse(port));
                Stream stm = client.GetStream();
                //this is sending a message to the server
                ASCIIEncoding asen = new ASCIIEncoding();
                string str = username;
                byte[] b = asen.GetBytes(str);
                stm.Write(b, 0, b.Length);
                toReturn = true;
            }
            catch (Exception)
            {
                toReturn = false;
            }
                
           
            return toReturn;
        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (!Connect()) 
            {
                return;
            }
            var chatform   = new ChatForm(username , port , ip);
            chatform.SetClient(client);
            chatform.Show();
            this.Hide();
        }
    }
}
