using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _Title = "VA_Crypto";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
     


    }
}
