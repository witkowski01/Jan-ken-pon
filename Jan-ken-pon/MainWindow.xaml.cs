﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jan_ken_pon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static Game game;
        public static Chat chat;

        private void StartServer_Click(object sender, RoutedEventArgs e)
        {
            var server = new Server();
            server.Show();
        }

        private void JoinServer_Click(object sender, RoutedEventArgs e)
        {
            var server = new JoinServer();
            server.Show();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            game = new Game();
            game.Show();
        }

        private void StartChat_Click(object sender, RoutedEventArgs e)
        {
            chat = new Chat();
            chat.Show();
        }
    }

    
}
