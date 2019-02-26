﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using Application;
using Domain;

namespace PrettyHair
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

		private void _CreateCustomer_Click(object sender, RoutedEventArgs e)
		{
			OpretKunde opretKunde = new OpretKunde();
			opretKunde.Show();
            this.Close();
        }

        private void _FindCustomer_Click(object sender, RoutedEventArgs e)
        {
            FindKunde findKunde = new FindKunde();
            findKunde.Show();
            this.Close();
        }

        private void _MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            OpretOrdre opretOrdre = new OpretOrdre();
            opretOrdre.Show();
            this.Close();
        }

        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
