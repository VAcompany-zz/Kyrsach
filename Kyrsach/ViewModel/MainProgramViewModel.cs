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
        

        //    public partial class PointShapeLineExample : UserControl
        //    {
        //        public PointShapeLineExample()
        //        {

        //            SeriesCollection = new SeriesCollection
        //        {
        //            new LiveCharts.Wpf.LineSeries
        //            {
        //                Title = "Series 1",
        //                Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
        //            },
        //            new LiveCharts.Wpf.LineSeries
        //            {
        //                Title = "Series 2",
        //                Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
        //                PointGeometry = null
        //            },
        //            new LiveCharts.Wpf.LineSeries
        //            {
        //                Title = "Series 3",
        //                Values = new ChartValues<double> { 4,2,7,2,7 },
        //                PointGeometry = DefaultGeometries.Square,
        //                PointGeometrySize = 15
        //            }
        //        };

        //            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
        //            YFormatter = value => value.ToString("C");

        //            //modifying the series collection will animate and update the chart
        //            SeriesCollection.Add(new LiveCharts.Wpf.LineSeries
        //            {
        //                Title = "Series 4",
        //                Values = new ChartValues<double> { 5, 3, 2, 4 },
        //                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
        //                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
        //                PointGeometrySize = 50,
        //                PointForeground = Brushes.Gray
        //            });

        //            //modifying any series values will also animate and update the chart
        //            SeriesCollection[3].Values.Add(5d);

        //            DataContext = this;
        //        }

        //        public SeriesCollection SeriesCollection { get; set; }
        //        public string[] Labels { get; set; }
        //        public Func<double, string> YFormatter { get; set; }

        //    }

        //public List<DataPoint> Points { get; set; } = new List<DataPoint>()
        //    {
        //                              new DataPoint(0, 44531),
        //                              new DataPoint(10, 44551),
        //                              new DataPoint(20, 46026),
        //                              new DataPoint(30, 48093),
        //                              new DataPoint(40, 47454),
        //                              new DataPoint(50, 47242),
        //                              new DataPoint(60, 45727),
        //                              new DataPoint(70, 46170),
        //                              new DataPoint(80, 46158),
        //                              new DataPoint(90, 46386),
        //                              new DataPoint(100, 46437),
        //                              new DataPoint(110, 45927),
        //                              new DataPoint(120, 43834),
        //                              new DataPoint(130, 43510),
        //                              new DataPoint(140, 42800),
        //                              new DataPoint(150, 42433),
        //                              new DataPoint(160, 43161),
        //                              new DataPoint(170, 39908),
        //                              new DataPoint(180, 39537),
        //                              new DataPoint(190, 41245),
        //                              new DataPoint(200, 39911),
        //                              new DataPoint(210, 40415),
        //                              new DataPoint(220, 40322),
        //                              new DataPoint(230, 40258),
        //                              new DataPoint(240, 40724),
        //                              new DataPoint(250, 41410),
        //                              new DataPoint(260, 40659),
        //                              new DataPoint(270, 39608),
        //                              new DataPoint(280, 39821),
        //                              new DataPoint(290, 39507)
        //    };

        //public PlotModel PlotModel2 { get; set; }
        //public MainProgramViewModel()
        //{
        //    var line = new OxyPlot.Series.LineSeries()
        //    {
        //        Title = "Kyrs",
        //        Color = OxyColors.White,
        //        StrokeThickness = 2.5,
        //        MarkerType = MarkerType.Circle,
        //        MarkerSize = 3.5,



        //    };

        //    this.PlotModel2 = new PlotModel { Title = "Курс" };
        //    //this.PlotModel2.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
        //    foreach (var item in Points)
        //    {
        //        line.Points.Add(item);
        //    }
        //    PlotModel2.Series.Add(line);
        //    OnPropertyChanged("PlotModel2");
        //}

        private int _Balance;
        public int Balance
        {
            get => _Balance;
            set { _Balance = value; OnPropertyChanged(); }
        }
        private string _Login = App.Current.Resources["SaveLogin"].ToString();
        public string Login
        {
            get => _Login;
            set { _Login = value; OnPropertyChanged(); }
        }

        public static DataBase data = new DataBase();
        public static DataTable table = data.CheckBalance(App.Current.Resources["SaveLogin"].ToString());
        public ObservableCollection<WalletViewModel> _Wallets = new ObservableCollection<WalletViewModel>();

        public MainProgramViewModel()
        {
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
           
            if (table.Rows.Count != Wallets.Count+1)
            {
                return;
            }
            table = data.CheckBalance(App.Current.Resources["SaveLogin"].ToString());
            
            for (int i = 0,j = 0 ; i < table.Rows.Count; i++,j++)
            {
                
                DataRow row = table.Rows[i];
                if (Int32.Parse(row[2].ToString()) == 3)
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
                if (Int32.Parse(row[2].ToString()) != 3)
                {
                    Wallets.Add(CreateWallet(row));
                }
               
            }
        }


    public WalletViewModel CreateWallet(DataRow row)
        {
            return new WalletViewModel(decimal.Parse(row[0].ToString()), row[3].ToString(), Int32.Parse(row[2].ToString()), Int32.Parse(row[1].ToString()));
        }
    }
}

  
