using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Services
{
    public class BalanceTransactions
    {
        DataBase dataBase = new DataBase();
        public bool SendCurrency(string LoginID, int amount, int CurrancyID)
        {
            return dataBase.SendCurrency(LoginID, App.Current.Resources["SaveLogin"].ToString(), amount, CurrancyID);
        }
        public bool ExchangeCurrency(decimal amoung, int FirstCurrency, int SecondCurrency)
        {
            return dataBase.ExchangeCurrency(amoung, FirstCurrency, SecondCurrency, App.Current.Resources["SaveLogin"].ToString());
        }
        public DataTable GetCof(int FirstCurrency, int SecondCurrency)
        {
            return dataBase.GetCof(FirstCurrency, SecondCurrency);
        }
    }
}
