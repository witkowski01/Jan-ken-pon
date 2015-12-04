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
            Exchange.server = new TcpListener(serverIP, Convert.ToInt32(Port.Text));
            Exchange.client = null;

            try
            {
                Exchange.server.Start();
                ServerStatus.Content = "Waiting for connection";
                Exchange.client = Exchange.server.AcceptTcpClient();
                Exchange.ns = Exchange.client.GetStream();
                ServerStatus.Content = "Client try to connect";
                Exchange.read = new BinaryReader(Exchange.ns);
                Exchange.write = new BinaryWriter(Exchange.ns);
                if (Exchange.read.ReadString() == "krzys")
                {
                    ServerStatus.Content = "Connection succesfull";
                    //coś zamiast background workera
                }
                else
                {
                    ServerStatus.Content = "Connection failure";
                    Exchange.client.Close();
                    Exchange.server.Stop();
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
