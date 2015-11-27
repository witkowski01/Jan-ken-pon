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
    /// Interaction logic for JoinServer.xaml
    /// </summary>
    public partial class JoinServer : Window
    {
        public JoinServer()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //var serverIP = IPAddress.Parse(Adres.Text);
                TcpClient client = new TcpClient(Adres.Text, Convert.ToInt32(Port.Text));
                NetworkStream ns = client.GetStream();
                var read = new BinaryReader(ns);
                var write = new BinaryWriter(ns);
                write.Write("krzys");
                ServerStatus.Content = "Authorisation";
            }
            catch
            {
                ServerStatus.Content = "Server KAbumm!  Krzys jest smutny";
            }

        }
    }
}
