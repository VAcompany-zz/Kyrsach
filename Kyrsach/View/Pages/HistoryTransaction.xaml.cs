using Kyrsach.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Threading;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryTransaction.xaml
    /// </summary>
    public partial class HistoryTransaction : Page
    {
        DataBase data = new DataBase();

       
        DataTable dt = new DataTable();
        private BindingList<HistoryTransactionModel> _todoData;
        public HistoryTransaction()
        {
            InitializeComponent();
            update();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += UpdateTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            dt = data.LoadDataHistory();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            update();
        }
        public void update()
        {
            dt = data.LoadDataHistory();
            _todoData = new BindingList<HistoryTransactionModel>();
            foreach (DataRow row in dt.Rows)
            {
                _todoData.Add(new HistoryTransactionModel() { FirstWalletId = row[0].ToString(), SecondWalletId = row[1].ToString(), Currency = row[2].ToString(), SumTransfer = row[3].ToString() });
            };

            HistoryList.ItemsSource = _todoData;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

