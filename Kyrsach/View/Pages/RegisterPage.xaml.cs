using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Kyrsach.Model;

namespace Kyrsach.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        MailSender MainFunc = new MailSender();
        bool flag = false;
        public RegisterPage()
        {
            InitializeComponent();
        }
     
        private void txtEmail_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            string email = RegMail.Text.Trim();

            if (!Util.IsEmail(email))
            {
                e.Handled = true;
                txtEmail_Error.Visibility = Visibility.Visible;
                RegMail.Focus();
            }
            else
                txtEmail_Error.Visibility = Visibility.Collapsed;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string email = RegMail.Text.Trim();

            if (!Util.IsEmail(email))
            {
                e.Handled = true;
                txtEmail_Error.Visibility = Visibility.Visible;
                RegMail.Focus();
                RegMail.Clear();
            }
            else
            {
                txtEmail_Error.Visibility = Visibility.Hidden;

                App.Current.Resources["SaveMail"] = RegMail.Text;
                MainFunc.SendEmail();
                RegMail.IsReadOnly = true;
                CheckMailCode.Visibility = Visibility.Visible;
                CheckMailCode2.Visibility = Visibility.Visible;
                CheckMail.Visibility = Visibility.Hidden;
                CheckMailCodey.Visibility = Visibility.Visible;
                CheckMailCodey.Visibility = Visibility.Visible;
            }
            

        }
        private void CheckMailCode3(object sender, RoutedEventArgs e)
        {
            if (App.Authentication.CheckMail(CheckMailCode.Text, App.Current.Resources["Code"].ToString()))
            {
                MessageBox.Show("Почта подтверждена");
                RegMail.IsReadOnly = true;
                CheckMailCodey.Visibility = Visibility.Collapsed;
                CheckMailCode.Visibility = Visibility.Collapsed;
                CheckMailCode2.Visibility = Visibility.Collapsed;
                CheckMail2.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Неверный код");
            };
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            CheckMail.Visibility = Visibility.Hidden;
            DateTime now = DateTime.Now;

            DateTime date = RegDate.DisplayDate;
            int Year = now.Year - date.Year;
            if (RegLogin.Text == "")
            {
                MessageBox.Show("Логин не заполнен");
            }
            else
            {
                if ((RegPWDPasswordBox.Password.Length >= 6) && (RegPWDPasswordBox2.Password.Length >= 6))
                {
                    MessageBox.Show("Пароль должен быть больше 6 символов");
                }
                else
                {

                if (RegPWDPasswordBox.Password != RegPWDPasswordBox2.Password)
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                else
                {
                    if (Year >= 18)
                    {
                        flag = true;
                        if (flag)
                        {
                            if (App.Authentication.Register(RegLogin.Text, RegPWDPasswordBox.Password, RegMail.Text, date))
                            {
                                MessageBox.Show("Аккаунт зарегестрирован");
                                NavigationService.Navigate(new PageLogin());
                            }
                            else { MessageBox.Show("Аккаунт не зарегестрирован"); }
                        }
                        else
                        {
                            CheckMail.Visibility = Visibility.Hidden;
                        }
                    }
                    else { MessageBox.Show("Вам нет 18"); }
                }
                }
            }
        }
        private void Close_Window(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
