using Kyrsach.Model;
using Kyrsach.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SendCurrancy.xaml
    /// </summary>
    public partial class SendCurrancy : Page
    {

        public SendCurrancy(WalletViewModel currency)
        {
            
            InitializeComponent();
            _currency = currency;
            
        }
        
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private WalletViewModel _currency;

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (App.BalanceTransactions.SendCurrency(FirstLoginID.Text, Int32.Parse(Ammount.Text), _currency.CurrencyID))
            {
                MessageBox.Show("Средства отправлены");
            }
            else
            {
                MessageBox.Show("Недостаточно средств для перевода");
            };
        }
        
    }
}
