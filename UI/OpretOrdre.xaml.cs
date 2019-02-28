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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for OpretOrdre.xaml
    /// </summary>
    public partial class OpretOrdre : Window
    {
        Application.Controller cont = new Application.Controller();
        public OpretOrdre()
        {
            InitializeComponent();
        }
        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void _CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int OrderID = cont.GetOrderID();
            cont.AddOrderLine(OrderID,(Convert.ToInt32(productText.Text)), (Convert.ToInt32(mængdeText.Text)), (Convert.ToInt32(priceText.Text)));
        }

        private void SetButton()
        {
            _CreateOrderButton.IsEnabled = (productText.Text != String.Empty || productText.IsEnabled == false) && (mængdeText.Text != String.Empty || mængdeText.IsEnabled == false) && (priceText.Text != String.Empty || priceText.IsEnabled == false);
        }
        private void ProductText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void MængdeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void PriceText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
    }
}