using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExchangeCurrancy.xaml
    /// </summary>
    public partial class ExchangeCurrancy : Page
    {
        public ExchangeCurrancy()
        {
            InitializeComponent();
           
        }
        
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Exchange(object sender, RoutedEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            int first = Int32.Parse(FirstCombo.SelectedIndex.ToString()) + 1;
            int second = Int32.Parse(SecondCombo.SelectedIndex.ToString()) + 1;
            decimal a = decimal.Parse(Amount.Text,numberFormatInfo);
            if (first >= 3)
            {
                first++;
            }
            if (second >= 3)
            {
                second++;
            }
            if (App.BalanceTransactions.ExchangeCurrency(a, first, second))
                MessageBox.Show("Обмен произведён успешно");
            else
                MessageBox.Show("Обмен не произведен");
        }

        private void Amount_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 8)
            {
                e.Handled = true;
                return;
            }
            Regex reg = new Regex(@"^[0-9]+[\.]?[0-9]*$");
            e.Handled = !reg.IsMatch((sender as TextBox).Text + e.Text);
            
        }
    }
}
