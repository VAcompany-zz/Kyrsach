using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;
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


namespace Kyrsach.ViewModel
{
    public class WalletViewModel : BaseViewModel
    {


        private decimal _Balance;
        public decimal Balance
        {
            get => _Balance;
            set { _Balance = value; OnPropertyChanged(); }
        }
        public string CurrencyName { get; set; }
        private int _CurrencyID;
        public int CurrencyID
        {
            get => _CurrencyID;
            set { _CurrencyID = value; OnPropertyChanged(); }
        }
        public Color CurrencyColor { get; set; }
        public SolidColorBrush CurrencyColorBrush { get; set; }
       
        private string _CurrencyLogo = "/Resurser/BitCoin.png";
        public string CurrencyLogo
        {
            get => _CurrencyLogo;
            set { _CurrencyLogo = value; OnPropertyChanged(); }
        }
        public int WalletID { get; set; }
        
        public ObservableValue ObservableValue { get; set; }
        public WalletViewModel()
        {
           
        }
        public WalletViewModel(decimal balance, string currencyName, int currencyID, int walletID)
        {
            Balance = balance;
            CurrencyName = currencyName;
            CurrencyID = currencyID;
            WalletID = walletID;


            switch (currencyID)
            {
                case 1: CurrencyColor = Color.FromRgb(252,69,1); CurrencyColorBrush = new SolidColorBrush(Color.FromRgb(247, 147, 26)); break;
                case 2: CurrencyColor = Color.FromRgb(70,130,180); CurrencyColorBrush = new SolidColorBrush(Color.FromRgb(70, 130, 180)); break;
                case 4: CurrencyColor = Color.FromRgb(150, 99, 212); CurrencyColorBrush = new SolidColorBrush(Color.FromRgb(150, 99, 212)); break;
                case 5: CurrencyColor = Color.FromRgb(220, 220, 0); CurrencyColorBrush = new SolidColorBrush(Color.FromRgb(220, 220, 0)); break;
            }

            DataBase dataBase = new DataBase();
            var val = new ChartValues<ObservableValue>();
            var table = dataBase.exchangeRatesChanges(CurrencyID);
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    val.Add(new ObservableValue((double)(decimal)row[col]));
                }
            }
            switch (currencyID)
            {
                case 1: CurrencyLogo = "/Resurser/BitCoin.png"; break;
                case 2: CurrencyLogo = "/Resurser/Ethereum.png"; break;
                case 4: CurrencyLogo = "/Resurser/Zcash.png"; break;
                case 5: CurrencyLogo = "/Resurser/BNB.png"; break;
            }
            // Заполняем массив для графика значениями


            SeriesCollection = new SeriesCollection
            {
                new LiveCharts.Wpf.LineSeries
                {
                    Title= "",

                    Stroke = new SolidColorBrush(CurrencyColor),
                    Fill = new LinearGradientBrush(CurrencyColor,Color.FromRgb(24,27,31),90),
                    LineSmoothness = 0,
                    //Fill = Brushes.Transparent,
                    PointGeometry = DefaultGeometries.Circle,
                    //Values = new ChartValues<double> { -1, 1, 0, -1, 1 }
                    Values = val,
                    PointGeometrySize = 0
                }
            };

            Labels = Enumerable.Range(1, 31).Select(x => x.ToString() + ".01.2022").ToArray();
            YFormatter = value => value.ToString() + "$";

        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        
    }


}
    

