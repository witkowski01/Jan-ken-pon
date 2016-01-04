using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        public Chat()
        {
            InitializeComponent();
            Thread chatThread = new Thread(Read);
            chatThread.Start();
            //Task.Factory.StartNew(Read);
        }

        private bool isConnected = true;
        private void Dissconnect()
        {
            isConnected = false;
            this.Close();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Exchange.writeChat.Write(MessageWindow.Text.ToString());
                ChatWindow.Items.Add(MessageWindow.Text);
                MessageWindow.Text = " ";
            }
            catch (Exception)
            {
                Dissconnect();
            }
        }

        private void Read()
        {
            while (true)
            {
                string temp = Exchange.readChat.ReadString();
                App.Current.Dispatcher.Invoke(() =>
                {
                    if (!String.IsNullOrWhiteSpace(temp))
                    {
                        ChatWindow.Items.Add(temp);
                    }
                });
                Thread.Sleep(2000);
            }
            
        }
    }
}
