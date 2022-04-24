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

    }
}
