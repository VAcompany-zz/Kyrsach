using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace Kyrsach.View.Convertors
{
    class CorrencyConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int TargetIndex = 3;
           
            if (values[1] == null || (int)values[1] == -1 || (string)values[0] == "")
            {
                return "0";
            }

            if (values.Length == 3)
            {
                TargetIndex = (int)values[2]+1;
                if (TargetIndex >= 3)
                {
                    TargetIndex++;
                }
            }
            int index = (int)values[1]+1;
            if (index >= 3)
            {
                index++;
            }
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            decimal sum = System.Convert.ToDecimal((string)values[0],numberFormatInfo);
            if (index == TargetIndex)
            {
                return sum.ToString();
            }
           
            DataTable db = App.BalanceTransactions.GetCof(index, TargetIndex);
            decimal cof = decimal.Parse(db.Rows[0][0].ToString());
            return (sum * cof).ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
