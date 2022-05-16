using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


namespace Kyrsach
{
    public class DataBase
    {
        HashFunc Hash = new HashFunc();
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PQRNELH\SQLEXPRESS;Initial Catalog=VA_Crypto;Integrated Security=True");
        public string HashFuncExamination(string source)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = Hash.GetHash(sha256Hash, source);

                //MessageBox.Show($"Хэш SHA256 строки {source} равен: {hash}.");
                //Login.Text = hash.ToString();
                return hash;
                //MessageBox.Show("Проверка хэша...");

                //if (Hash.VerifyHash(sha256Hash, source, hash))
                //{
                //    MessageBox.Show("Хэши одинаковые.");
                //}
                //else
                //{
                //    MessageBox.Show("Хэши не совпадают.");
                //}
            }
        }

        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            //sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            //sqlConnection.Close();
            return dataTable;
        }
        public DataTable CheckLoginAndPassword(string login, string password)
        {
            DataTable dataTable = new DataTable("dataBase");
            dataTable = Select($"select userID, loginID, password, mail, date from users where loginID = '{login}' and password = '{password}'");
            return dataTable;
        }
        public bool Insert(string selectSQL)
        {
            DataBase dataBase = new DataBase();
            //sqlConnection.Open();
            SqlCommand command = new SqlCommand(selectSQL, dataBase.getConnection());
            //dataBase.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                //dataBase.closeConnection();
                //sqlConnection.Close();
                return true;
            }      
            else
            {
                //dataBase.closeConnection();
                //sqlConnection.Close();
                return false;
            }

        }
        public bool Send(string selectSQL)
        {
            DataBase dataBase = new DataBase();
            //sqlConnection.Open();
            SqlCommand command = new SqlCommand(selectSQL, dataBase.getConnection());
            dataBase.openConnection();

            var returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(returnParameter);

            // execute
            command.ExecuteNonQuery();

            int ret = int.Parse(command.Parameters["@ReturnVal"].Value.ToString());
            if (ret == 1)
            {
                MessageBox.Show("Успех");
                //sqlConnection.Close();
                dataBase.closeConnection();
                return true;
            }
            else
            {
                MessageBox.Show("Неудача");
                //sqlConnection.Close();
                dataBase.closeConnection();
                return false;
            }

        }
        public bool RegisterInDataBase(string login, string PasswordHash, string mail, DateTime date)
        {

            if (Insert($"insert into users(loginID, password, mail, date) values('{login}','{PasswordHash}','{mail}','{date}')"))
            {
                return true;
            }
            else return false;
            
        }
        public DataTable exchangeRatesChanges(int cyrrencyID)
        {
            DataTable dataTable = new DataTable("dataBase");
            dataTable = Select($"select converstationCard from exchangeRatesChanges where FirstCurrencyID = '{cyrrencyID}'");
            //sqlConnection.Close();
            return dataTable;
        }
        public bool GanerateWalletForUser()
        {
            if (Insert($"EXEC CreateWalletForUser"))
            {
                return true;

            }
            else return false;
        }

        public DataTable CheckBalance(string loginID)
        {
            DataTable dataTable = new DataTable("dataBase");
            dataTable = Select($"EXEC CheckInBalance '{loginID}'");
            //sqlConnection.Close();
            return dataTable;
        }
        public bool SendCurrency(string LoginID, string LoginID2, int amount, int CurrancyID)
        {
            return Send($"EXEC SendCurrancy '{LoginID}','{LoginID2}','{amount}','{CurrancyID}'");

        }
        public DataTable CheckTransaction()
        {
            DataTable dataTable = new DataTable("dataBase");
            dataTable = Select($"selcet * from transactionTable");
            //sqlConnection.Close();
            return dataTable;
        }
        public bool ExchangeCurrency(decimal amoung, int FirstCurrency, int SecondCurrency, string login)
        {
            return Send($"EXEC ExchangeCurrency '{amoung.ToString("0.0000",System.Globalization.CultureInfo.InvariantCulture)}','{FirstCurrency}','{SecondCurrency}','{login}'");

        }
        public DataTable LoadDataHistory(string userID)
        {
            DataTable dataTable = new DataTable("dataBase");
            dataTable = Select($"EXEC CheckHistory '{userID}'");
            //sqlConnection.Close();
            return dataTable;

        }
        public DataTable GetCof(int FirstCurrency, int SecondCurrency)
        {
            DataTable dataTable = new DataTable("dataBase");
            dataTable = Select($"EXEC GetCof '{FirstCurrency}','{SecondCurrency}'");
            //sqlConnection.Close();
            return dataTable;

        }
    }
}
