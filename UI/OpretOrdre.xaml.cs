using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for OpretOrdre.xaml
    /// </summary>
    public partial class OpretOrdre : Window
    {
        Application.Controller cont = new Application.Controller();
        int counter;
        int count;
        public OpretOrdre()
        {
            InitializeComponent();
            ProductIDCombo.ItemsSource = cont.GetProducts();
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

        private void _AddToOrder_Click(object sender, RoutedEventArgs e)
        {
            cont.AddOrderLine(cont.GetOrderID(), count, int.Parse(amountText.Text), double.Parse(priceText.Text));
            _OrderDone.IsEnabled = true;
            counter++;
        }

        private void _OrderDone_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ordren er blevet oprettet!");
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void ProductIDCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            count = ProductIDCombo.SelectedIndex;

            string[] price = cont.GetPrice();
            int[] quantity = cont.GetQuantity();
            AmountLabel.Content = "Antal (" + quantity[count] + ") på lager.";
            priceText.Text = price[count].ToString();
            
            if (amountText.Text == "")
            {
                priceText.Clear();
            }
            else
            {
                bool success = double.TryParse(amountText.Text, out double number);
                if (success)
                {
                    string[] prices = cont.GetPrice();
                    string price4 = prices[count];
                    double number2 = double.Parse(price4);
                    priceText.Text = (number * number2).ToString();;
                }
                else
                {
                    amountText.Text = "";
                }
            }

            DescriptionLabel.Content = "Beskrivelse:\n" + cont.GetDescription(count+1);
        }


        private void AmountText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int[] quantity = cont.GetQuantity();
            bool successs = double.TryParse(amountText.Text, out double number);
            if (successs)
            {
                if (number < quantity[count] && counter > 0)
                {
                    _OrderDone.IsEnabled = true;
                }
                else
                    _OrderDone.IsEnabled = false;
            }
            else
            {
                amountText.Text = "";
            }
                bool success = double.TryParse(amountText.Text, out double number1);
                if (success)
                {
                    int count = ProductIDCombo.SelectedIndex;
                    string[] prices = cont.GetPrice();
                    string price = prices[count];
                    double number2 = double.Parse(price);
                    priceText.Text = (number1 * number2).ToString();
                }
                else
                {
                    amountText.Text = "";
                }
            }
        }
    }
    
