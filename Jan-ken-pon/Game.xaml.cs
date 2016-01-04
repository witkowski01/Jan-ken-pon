using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
            Task.Factory.StartNew(Read);
            WhatIChoose = WhatOpChoose = 0;
        }

        private void Dissconnect()
        {
            Image_my.Source = null;
            Image_op.Source = null;
            MessageBox.Show("Server is currently down, or opponent disconnect");
            if (JoinServer.joinServer != null)
            {
                JoinServer.joinServer.ServerStatus.Content = "Dissconnect";
                JoinServer.joinServer.Stop.IsEnabled = false;
                JoinServer.joinServer.Start.IsEnabled = true;
            }
            if (Server.server != null)
            {
                Server.server.ServerStatus.Content = "Dissconnect";
                Server.server.Stop.IsEnabled = false;
                Server.server.Start.IsEnabled = true;
            }
            MainWindow.chat.Close();
            this.Close();
        }
        public void ButtonStatusChange(bool status)
        {
            Stone.IsEnabled = Paper.IsEnabled = Scissors.IsEnabled = status;
            Next.IsEnabled = !status;
        }

        private bool ChooseYet = false;
        private byte WhatIChoose, WhatOpChoose;
        private void Read()
        {
            while (true)
            {
                if (ChooseYet)
                {
                    string temp = Exchange.read.ReadString();
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        
                        if (temp == "Stone")
                        {
                            Image_op.Source = new BitmapImage(new Uri(new FileInfo(@"Stone.jpg").FullName));
                            WhatOpChoose = 1;
                            runGame();
                            ChooseYet = false;
                        }
                        else if (temp == "Scissors")
                        {
                            Image_op.Source = new BitmapImage(new Uri(new FileInfo(@"Scissors.png").FullName));
                            WhatOpChoose = 2;
                            runGame();
                            ChooseYet = false;
                        }
                        else if (temp == "Paper")
                        {
                            Image_op.Source = new BitmapImage(new Uri(new FileInfo(@"Paper.jpg").FullName));
                            WhatOpChoose = 3;
                            runGame();
                            ChooseYet = false;
                        }
                        else if (temp == "krzysbaybay")
                        {
                            Dissconnect();
                        }

                    });


                }


                Thread.Sleep(100);
            }

        }

        private void Stone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Exchange.write.Write("Stone");
                Image_my.Source = new BitmapImage(new Uri(new FileInfo(@"Stone.jpg").FullName));
                WhatIChoose = 1;
                ChooseYet = true;
                ButtonStatusChange(false);
            }
            catch (Exception)
            {
                Dissconnect();
            }


        }

        private void Scissors_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Exchange.write.Write("Scissors");
                Image_my.Source = new BitmapImage(new Uri(new FileInfo(@"Scissors.png").FullName));
                WhatIChoose = 2;
                ChooseYet = true;
                ButtonStatusChange(false);
            }
            catch (Exception)
            {
                Dissconnect();
            }

        }

        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Exchange.write.Write("Paper");
                Image_my.Source = new BitmapImage(new Uri(new FileInfo(@"Paper.jpg").FullName));
                WhatIChoose = 3;
                ChooseYet = true;
                ButtonStatusChange(false);
            }
            catch (Exception)
            {
                Dissconnect();
            }

        }

        private void runGame()
        {
            if (WhatIChoose == 1 && WhatOpChoose == 1)
            {
                WinLost.Content = "Draw";
            }
            else if (WhatIChoose == 2 && WhatOpChoose == 2)
            {
                WinLost.Content = "Draw";
            }
            else if (WhatIChoose == 3 && WhatOpChoose == 3)
            {
                WinLost.Content = "Draw";
            }
            else if (WhatIChoose == 1 && WhatOpChoose == 2)
            {
                WinLost.Content = "You win";
            }
            else if (WhatIChoose == 1 && WhatOpChoose == 3)
            {
                WinLost.Content = "You lost";
            }
            else if (WhatIChoose == 2 && WhatOpChoose == 1)
            {
                WinLost.Content = "You lost";
            }
            else if (WhatIChoose == 2 && WhatOpChoose == 3)
            {
                WinLost.Content = "You win";
            }
            else if (WhatIChoose == 3 && WhatOpChoose == 1)
            {
                WinLost.Content = "You win";
            }
            else if (WhatIChoose == 3 && WhatOpChoose == 2)
            {
                WinLost.Content = "You lost";
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Image_op.Source = Image_my.Source = null;
            WinLost.Content = " ";
            ButtonStatusChange(true);
        }
    }
}
