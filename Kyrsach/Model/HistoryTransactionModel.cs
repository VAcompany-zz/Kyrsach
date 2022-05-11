using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Model
{
    public class HistoryTransactionModel
    {
        public string FirstUser { get; set; }

        private string _FirstWalletId;

        public string FirstWalletId
        {
            get { return _FirstWalletId; }
            set { _FirstWalletId = value; }
        }
        private string _SecondWalletId;

        public string SecondWalletId
        {
            get { return _SecondWalletId; }
            set { _SecondWalletId = value; }
        }
        private string _currency;

        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        private string _sumTransfer;

        public string SumTransfer
        {
            get { return _sumTransfer; }
            set { _sumTransfer = value; }
        }



    }
}
