using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Services
{
    public class AuthenticationService
    {
        MailSender MainFunck = new MailSender();
        DataBase dataBase = new DataBase();
        public bool Login(string login, string password)
        {
            App.Current.Resources["SaveLogin"] = login;
            string PasswordHash = dataBase.HashFuncExamination(password);

            var table = dataBase.CheckLoginAndPassword(login, PasswordHash);

            if (table.Rows.Count == 1)
            {
                App.Current.Resources["SaveMail"] = table.Rows[0][3].ToString();
                MainFunck.SendEmail();
                return true;
            }
            return false;
        }
        public bool Register(string RegLogin, string passwrod, string regMail, DateTime date) 
        {
            string PasswordHash = dataBase.HashFuncExamination(passwrod);

            return dataBase.RegisterInDataBase(RegLogin, PasswordHash, regMail, date);

        }
        public bool GanerateWalletForUser()
        {
            dataBase.GanerateWalletForUser();

            return dataBase.GanerateWalletForUser();

        }
        public bool CheckMail(string code1, string code2)
        {
            if (code1 == code2)
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }
}
