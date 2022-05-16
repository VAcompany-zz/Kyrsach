using Kyrsach.Services;
using System.Linq;

namespace Kyrsach.Model
{
    public class HistoryTransactionModel
    {
        public HistoryTransactionModel(string firstUser, int firstWalletId, int secondWalletId, string currency, string sumTransfer, string dataTrans)
        {
            FirstUser = firstUser;
            FirstWalletId = firstWalletId;
            SecondWalletId = secondWalletId;
            Currency = currency;
            SumTransfer = sumTransfer;
            DataTrans = dataTrans;

            if (VMLocator.VMService.MainVM.Wallets.FirstOrDefault(a => a.CurrencyID == FirstWalletId) == null)
            {
                TypeTrans = "Received";
            }
            else
            {
                TypeTrans = "Send";
            }
        }
        public string FirstUser { get; set; }

        private int _FirstWalletId;

        public int FirstWalletId
        {
            get { return _FirstWalletId; }
            set { _FirstWalletId = value; }
        }
        private int _SecondWalletId;

        public int SecondWalletId
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
        private string _DataTrans;

        public string DataTrans
        {
            get { return _DataTrans; }
            set { _DataTrans = value; }
        }
        private string _TypeTrans;

        public string TypeTrans
        {
            get { return _TypeTrans; }
            set { _TypeTrans = value; }
        }
    }
}