using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
 
namespace PrettyHair
{
	/// <summary>
	/// Interaction logic for FindKunde.xaml
	/// </summary>
	public partial class FindKunde : Window
	{
        PrettyHair.Controller cont = new PrettyHair.Controller();
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
    }
}



