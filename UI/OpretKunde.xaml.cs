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
using Application;

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
            MessageBox.Show("Kunde oprettet! \n Vil du oprette en ordre?");
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


        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

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
    }
}
