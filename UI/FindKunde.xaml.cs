﻿using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI
{
    /// <summary>
    /// Interaction logic for FindKunde.xaml
    /// </summary>
    public partial class FindKunde : Window
    {
        Application.Controller cont = new Application.Controller();
        public FindKunde()
        {
            InitializeComponent();
        }
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void CustomerSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string[] tmp = cont.GetCustomer(int.Parse(customeridText.Text)).Split(';');
            firstnameText.Text = tmp[0];
            addressText.Text = tmp[1];

            if (String.IsNullOrEmpty(tmp[0]))
            {
                OrderAskLabel.Content = "Kunde findes ikke. Vil du oprette en ny kunde?";
                OrderAskLabel.Foreground = Brushes.Red;
            }
            else if (tmp[0].Length > 0)
            {
                OrderAskLabel.Content = "Vil du oprette en ny ordre til " + tmp[0] + "?";
                OrderAskLabel.Foreground = Brushes.Black;
            }


            EnableLabelAndButtons();
        }

        private void Customerid_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerSearchButton.IsEnabled = (customeridText.Text != "");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
        public void EnableLabelAndButtons()
        {
            firstnameText.Visibility = Visibility.Visible;
            addressText.Visibility = Visibility.Visible;
            FirstnameLabel.Visibility = Visibility.Visible;
            AddressLabel.Visibility = Visibility.Visible;
            _CreateOrder.Visibility = Visibility.Visible;
            _SearchAgain.Visibility = Visibility.Visible;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void _CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            cont.CreateOrder(DateTime.Now, DateTime.Now.AddDays(14), int.Parse(customeridText.Text), false);
            OpretOrdre opretordre = new OpretOrdre();
            opretordre.Show();
            this.Close();
        }
    }
}



