using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.ViewModel
{
    class ExchangeViewModel : BaseViewModel
    {
        private string _DollarOne = "$" + "10";
        public string DollarOne
        {
            get => _DollarOne;
            set { _DollarOne = value; OnPropertyChanged(); }
        }
        private string _DollarTwo = "$"+"100";
        public string DollarTwo
        {
            get => _DollarTwo;
            set { _DollarTwo = value; OnPropertyChanged(); }
        }
    }
}
