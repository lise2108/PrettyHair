using System;
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

        private void KundeSøgBTN_Click(object sender, RoutedEventArgs e)
        {
            string[] tmp = cont.GetCustomer(int.Parse(KundeID.Text)).Split(';');
            FornavnTxt.Text = tmp[0];
            AdresseTxt.Text = tmp[1];
        }
    }
}
