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
using Kyrsach.ViewModel;
using Kyrsach.Model;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class PageLogin : Page
    {

        DataBase data = new DataBase();
        public PageLogin()
        {

            InitializeComponent();
            
        }
        private string password;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBoxPwd.IsChecked)
            {
                password = pwdTextBox.Text;
            }
            else password = pwdPasswordBox.Password;

            if (Login.Text.Length > 0)
            {
                if (pwdPasswordBox.Password.Length > 0)
                {
                    if (App.Authentication.Login(Login.Text, password))
                    {
                        NavigationService.Navigate(new PageAuthentication());
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль неверные!");
                    }
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");

        }
        //public string HashFuncExamination(string source)
        //{
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        string hash = Hash.GetHash(sha256Hash, source);

        //        //MessageBox.Show($"Хэш SHA256 строки {source} равен: {hash}.");
        //        //Login.Text = hash.ToString();
        //        return hash;
        //        //MessageBox.Show("Проверка хэша...");

        //        //if (Hash.VerifyHash(sha256Hash, source, hash))
        //        //{
        //        //    MessageBox.Show("Хэши одинаковые.");
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("Хэши не совпадают.");
        //        //}
        //    }
        //}
        private void RegisterClick(object sender, RoutedEventArgs e)
        {
              
            NavigationService.Navigate(new RegisterPage());
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                pwdTextBox.Text = pwdPasswordBox.Password; // скопируем в TextBox из PasswordBox
                pwdTextBox.Visibility = Visibility.Visible; // TextBox - отобразить
                pwdPasswordBox.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                pwdPasswordBox.Password = pwdTextBox.Text; // скопируем в PasswordBox из TextBox 
                pwdTextBox.Visibility = Visibility.Hidden; // TextBox - скрыть
                pwdPasswordBox.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //var date2 = data.exchangeRatesChanges2();
            //MessageBox.Show(date2.Rows[0][2].ToString());
          
            NavigationService.Navigate(new MainProgramPage());
        }
    }
}
