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
            joinServer = this;
        }

        public static JoinServer joinServer;
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Exchange.write.Write("krzysbaybay");
            Exchange.client.Close();
            Stop.IsEnabled = false;
            Start.IsEnabled = true;

            ServerStatus.Content = "No connection";
            if (MainWindow.game != null)
            {
                ServerStatus.Content = "Dissconnect";
                MainWindow.game.Close();
                Stop.IsEnabled = false;
                Start.IsEnabled = true;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Stop.IsEnabled = true;
            Start.IsEnabled = false;
            try
            {
                //var serverIP = IPAddress.Parse(Adres.Text);
                Exchange.client = new TcpClient(Adres.Text, Convert.ToInt32(Port.Text));
                Exchange.ns = Exchange.client.GetStream();
                Exchange.read = new BinaryReader(Exchange.ns);
                Exchange.write = new BinaryWriter(Exchange.ns);
                Exchange.write.Write("krzys");
                ServerStatus.Content = "Authorisation";
            }
            catch
            {
                ServerStatus.Content = "Server KABumm!";
                Stop.IsEnabled = false;
                Start.IsEnabled = true;
            }

        }
    }
}
