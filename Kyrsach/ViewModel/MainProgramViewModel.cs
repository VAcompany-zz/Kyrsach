using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.ViewModel
{
    public class MainProgramViewModel : BaseViewModel
    {
        private int _Balance = 150;
        public int Balance
        {
            get => _Balance;
            set => Set(ref _Balance, value);
        }
        public List<DataPoint> Points { get; set; } = new List<DataPoint>()
        {
                                  new DataPoint(0, 25),
                                  new DataPoint(10, 13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
        };
        public PlotModel PlotModel2 { get; set; }
        public MainProgramViewModel()
        {
            var line = new LineSeries()
            {
                Title = "Kyrs",
                Color = OxyColors.White,
                StrokeThickness = 2.5,
                MarkerType = MarkerType.Circle,
                MarkerSize = 3.5,
                

            };

            this.PlotModel2 = new PlotModel { Title = "Курс" };
            //this.PlotModel2.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            foreach (var item in Points)
            {
                line.Points.Add(item);
            }
            PlotModel2.Series.Add(line);
            OnPropertyChanged("PlotModel2");
        }
    }
}
