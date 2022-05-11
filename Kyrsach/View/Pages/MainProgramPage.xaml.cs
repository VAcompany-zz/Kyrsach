using Kyrsach.Model;
using Kyrsach.View.Windows;
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
    /// Логика взаимодействия для MainProgramPage.xaml
    /// </summary>
    public partial class MainProgramPage : Page
    {
        public MainProgramPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SendCurrancy(TabContorlWallets.SelectedItem as WalletViewModel));
        }
        private void Receive_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Receive(TabContorlWallets.SelectedItem as WalletViewModel));
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExchangeCurrancy());
        }
        private void OpenHistoryTransaction(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoryTransaction());
        }
    }
}
