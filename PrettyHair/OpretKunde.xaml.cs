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
	/// Interaction logic for OpretKunde.xaml
	/// </summary>
	public partial class OpretKunde : Window
	{
		public OpretKunde()
		{
			InitializeComponent();
		}

		private void OpretKundeOK_Click(object sender, RoutedEventArgs e)
		{

		}

		private void NavnText_TextChanged(object sender, TextChangedEventArgs e)
		{
			if ((NavnText.Text != null))
			{
				OpretKundeOK.IsEnabled = true;
			}
			else
			{
				OpretKundeOK.IsEnabled = false;
			}
		}

		private void AdresseText_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

	}
}
