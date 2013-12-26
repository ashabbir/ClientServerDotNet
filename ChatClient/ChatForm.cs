using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
namespace ChatClient
{
    public partial class ChatForm : Form
    {

        private string UserName;
        private string Port;
        private string IP;
        private TcpClient client;
        Stream stm;
        //this is sending a message to the server
        ASCIIEncoding asen = new ASCIIEncoding();
               


        public ChatForm(string username , string port , string ip) : this()
        {
            UserName = username;
            Port = port;
            IP = ip;
           
        }

        public ChatForm()
        {
            InitializeComponent();
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(chatInput.Text)) 
            {
                return;
            }
            var msg = UserName + ": " + chatInput.Text;
            
            BroadCast(chatInput.Text);
            ChatWorld.AppendText(Receive());
            ChatWorld.AppendText(Environment.NewLine);
            chatInput.Text = "";
        }

        private void chatInput_TextChanged(object sender, EventArgs e)
        {

        }



        internal void SetClient(TcpClient _client)
        {
            client = _client;
            stm = client.GetStream();
        }

        private void BroadCast(string msg) 
        {
                byte[] b = asen.GetBytes(msg);
                stm.Write(b, 0, b.Length);
        }

        private string Receive() 
        {
              byte[] b =new byte[100000];
              stm.Read(b, 0 ,10000);
              var msg = asen.GetString(b);
              return msg;
        }
    }
}
