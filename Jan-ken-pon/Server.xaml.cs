using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Jan_ken_pon
{
    /// <summary>
    /// Interaction logic for Server.xaml
    /// </summary>
    public partial class Server : Window
    {
        public Server()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var ram = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;

            string port, adres;
            IPAddress serverIP;
            try
            {
                serverIP = IPAddress.Parse(Adres.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong IP adress");
                return;
            }
            var server = new TcpListener(serverIP, Convert.ToInt32(Port.Text));
            TcpClient client = null;

            try
            {
                server.Start();
                ServerStatus.Content = "Waiting for connection";
                client = server.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                ServerStatus.Content = "Client try to connect";
                var read = new BinaryReader(ns);
                var write = new BinaryWriter(ns);
                if (read.ReadString() == "krzys")
                {
                    ServerStatus.Content = "Connection succesfull";
                    //coś zamiast background workera
                }
                else
                {
                    ServerStatus.Content = "Connection failure";
                    client.Close();
                    server.Stop();
                    ServerStatus.Content = "No connection";
                }
            }
            catch
            {
                ServerStatus.Content = "Server KABUMMMM!";
            }
        }
    }
}
