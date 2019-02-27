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
            cont.CreateOrder(DateTime.Now, DateTime.Now.AddDays(14), Convert.ToInt32(productIDText.Text), Convert.ToInt32(mængdeText.Text), Convert.ToInt32(kundeIDtxt.Text), false);
        }
        
    }
}