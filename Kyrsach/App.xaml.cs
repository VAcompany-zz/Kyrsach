using Kyrsach.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Kyrsach
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AuthenticationService Authentication { get; set; }
        public static BalanceTransactions BalanceTransactions { get; set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var cultureInfo = new CultureInfo("en-US");
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            cultureInfo.NumberFormat = numberFormatInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;

            Authentication = new AuthenticationService();
            BalanceTransactions = new BalanceTransactions();
        }
    }
}
