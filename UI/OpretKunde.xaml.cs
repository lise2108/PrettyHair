using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for OpretKunde.xaml
    /// </summary>
    public partial class OpretKunde : Window
    {

        Application.Controller cont = new Application.Controller();
        public OpretKunde()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            cont.CreateCustomer(nameText.Text, addressText.Text, Convert.ToInt32(zipText.Text), cityText.Text, telephoneText.Text);
            CustomerOrderAsk();
        }

        public void CustomerOrderAsk()
        {
            NameLabel.Visibility = Visibility.Hidden;
            AddressLabel.Visibility = Visibility.Hidden;
            ZipLabel.Visibility = Visibility.Hidden;
            CityLabel.Visibility = Visibility.Hidden;
            TelephoneLabel.Visibility = Visibility.Hidden;
            nameText.Visibility = Visibility.Hidden;
            addressText.Visibility = Visibility.Hidden;
            zipText.Visibility = Visibility.Hidden;
            cityText.Visibility = Visibility.Hidden;
            telephoneText.Visibility = Visibility.Hidden;
            _createButton.Visibility = Visibility.Hidden;
            OrderAskLabel.Visibility = Visibility.Visible;
            OpretKundeLabel.Visibility = Visibility.Visible;
            OpretOrder.Visibility = Visibility.Visible;

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


        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        

        private void SetButton()
        {
            _createButton.IsEnabled = (nameText.Text != "" || nameText.IsEnabled == false) && (addressText.Text != "" || addressText.IsEnabled == false) && (zipText.Text != "" && zipText.Text.Length == 4 || zipText.IsEnabled == false) && (cityText.Text != "" || cityText.IsEnabled == false) && (telephoneText.Text != "" || telephoneText.IsEnabled == false) && telephoneText.Text.Length == 8;
        }

        private void NameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void AddressText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void ZipText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void CityText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void TelephoneText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void OpretOrderLabel_click(object sender, RoutedEventArgs e)
        {
            int customerID = cont.GetCustomerID();
            cont.CreateOrder(DateTime.Now, DateTime.Now.AddDays(14), customerID, false);
            OpretOrdre opretordre = new OpretOrdre();
            opretordre.Show();
            this.Close();
        }

        private void OpretKundeLabel_click(object sender, RoutedEventArgs e)
        {
            NameLabel.Visibility = Visibility.Visible;
            AddressLabel.Visibility = Visibility.Visible;
            ZipLabel.Visibility = Visibility.Visible;
            CityLabel.Visibility = Visibility.Visible;
            TelephoneLabel.Visibility = Visibility.Visible;
            nameText.Visibility = Visibility.Visible;
            addressText.Visibility = Visibility.Visible;
            zipText.Visibility = Visibility.Visible;
            cityText.Visibility = Visibility.Visible;
            telephoneText.Visibility = Visibility.Visible;
            _createButton.Visibility = Visibility.Visible;
            OrderAskLabel.Visibility = Visibility.Hidden;
            OpretKundeLabel.Visibility = Visibility.Hidden;
            OpretOrder.Visibility = Visibility.Hidden;
            nameText.Clear();
            addressText.Clear();
            zipText.Clear();
            cityText.Clear();
            telephoneText.Clear();
            nameText.Focus();
        }
    }
}
