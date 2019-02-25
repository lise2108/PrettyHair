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
    /// Interaction logic for OpretKunde.xaml
    /// </summary>
    public partial class OpretKunde : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        PrettyHair.Controller cont = new PrettyHair.Controller();
        public OpretKunde()
        {
            InitializeComponent();
        }

        private void OpretKundeOK_Click(object sender, RoutedEventArgs e)
        {
            cont.CreateCustomer(NavnText.Text, AdresseText.Text, Convert.ToInt32(ZipText.Text), ByText.Text, TlfText.Text);
        }

        private void SetButton()
        {
            OpretKundeOK.IsEnabled = (NavnText.Text != "" || NavnText.IsEnabled == false) && (AdresseText.Text != "" || AdresseText.IsEnabled == false) && (ZipText.Text != "" && ZipText.Text.Length == 4 || ZipText.IsEnabled == false) && (ByText.Text != "" || ByText.IsEnabled == false) && (TlfText.Text != "" || TlfText.IsEnabled == false) && TlfText.Text.Length == 8;
        }

        private void NavnText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void AdresseText_TextChanged(object sender, TextChangedEventArgs e)
        {
           SetButton();
        }

        private void ZipText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void ByText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void TlfText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Shutdown_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
