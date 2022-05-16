using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Collections.ObjectModel;
using Kyrsach.Model;
using Kyrsach.View;
using System.Windows.Threading;

namespace Kyrsach.ViewModel
{
    public class MainProgramViewModel : BaseViewModel
    {
        private int _Balance;
        public int Balance
        {
            get => _Balance;
            set => Set(ref _Balance, value);
        }
        private string _Login;
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        public DataBase data = new DataBase();
        public DataTable table;
        public ObservableCollection<WalletViewModel> _Wallets = new ObservableCollection<WalletViewModel>();

        public MainProgramViewModel()
        {
            table = data.CheckBalance(Application.Current.Resources["SaveLogin"].ToString());
            _Login = Application.Current.Resources["SaveLogin"].ToString();
            CreateWallets();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += UpdateTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateBalance();
        }

        public ObservableCollection<WalletViewModel> Wallets
        {
            get => _Wallets;
            set { _Wallets = value; OnPropertyChanged(); }
        }
        public void UpdateBalance()
        {

            if (table.Rows.Count != Wallets.Count + 1)
            {
                return;
            }
            table = data.CheckBalance(Application.Current.Resources["SaveLogin"].ToString());

            for (int i = 0, j = 0; i < table.Rows.Count; i++, j++)
            {

                DataRow row = table.Rows[i];
                if (int.Parse(row[2].ToString()) == 3)
                {
                    j--;
                }
                else
                {
                    Wallets[j].Balance = decimal.Parse(row[0].ToString());
                }
            }
        }
        public void CreateWallets()
        {
            foreach (DataRow row in table.Rows)
            {
                if (int.Parse(row[2].ToString()) != 3)
                {
                    Wallets.Add(CreateWallet(row));
                }
            }
        }
        public WalletViewModel CreateWallet(DataRow row)
        {
            return new WalletViewModel(decimal.Parse(row[0].ToString()), row[3].ToString(), int.Parse(row[2].ToString()), int.Parse(row[1].ToString()));
        }
    }
}