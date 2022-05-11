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

namespace Kyrsach.ViewModel
{
    class HistoryTranscriptionViewModel : BaseViewModel
    {
        private DataTable _Table;
        public DataTable Table
        {
            get => _Table;
            set { _Table = value; OnPropertyChanged(); }
        }
        
    }
}
