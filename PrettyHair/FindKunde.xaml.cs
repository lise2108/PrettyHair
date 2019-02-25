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
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        public FindKunde()
		{
			InitializeComponent();
        }

        private void KundeSøgBTN_Click(object sender, RoutedEventArgs e)
        {
            string[] tmp = cont.GetCustomer(int.Parse(KundeID.Text)).Split(';');
            FornavnTxt.Text = tmp[0];
            AdresseTxt.Text = tmp[1];
            FornavnTxt.Visibility = Visibility.Visible;
            AdresseTxt.Visibility = Visibility.Visible;
            FornavnLbl.Visibility = Visibility.Visible;
            AddressLbl.Visibility = Visibility.Visible;
            OpretOrdreJa.Visibility = Visibility.Visible;
            OpretOrdreNej.Visibility = Visibility.Visible;
            OrdreStart.Content = "Vil du oprette en ny ordre til " + tmp[0] + "?";
        }

        private void KundeID_TextChanged(object sender, TextChangedEventArgs e)
        {
            KundeSøgBTN.IsEnabled = (KundeID.Text != "");
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



