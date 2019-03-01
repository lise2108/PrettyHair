using System.Windows;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void _CreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            OpretKunde opretKunde = new OpretKunde();
            opretKunde.Show();
            this.Close();
        }

        private void _FindCustomer_Click(object sender, RoutedEventArgs e)
        {
            FindKunde findKunde = new FindKunde();
            findKunde.Show();
            this.Close();
        }

        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
