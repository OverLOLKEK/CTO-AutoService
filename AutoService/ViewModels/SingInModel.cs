using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutoService.ViewPage;

namespace AutoService.ViewModels
{
    public class SingInModel
    {
        /*
        private void ResetCaptchaButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateCaptcha();
        }

        private void CreateCaptcha()
        {
            string allowchar = string.Empty;
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            string[] ar = allowchar.Split(a);
            string pwd = string.Empty;
            string temp = string.Empty;
            System.Random r = new System.Random();

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];

                pwd += temp;
            }

            CaptchaText.Text = pwd;

            CaptchaValue = CaptchaText.Text;

            CaptchaRefreshed?.Invoke(this, System.EventArgs.Empty);
        }

        private void revealModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (RevealModeCheckBox.IsChecked == true)
            {
                StatusText.Text = passwordBox.Password;
            }
            else
            {
                statusText.Text = string.Empty;
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (revealModeCheckBox.IsChecked == true)
            {
                StatusText.Text = PasswordBox.Password;
            }
            else
            {
                statusText.Text = string.Empty;
            }
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var connection = DBInstance.Get();
            var paswordslogins = connection.PasswordsLogins.ToList();
            var users = connection.User.ToList();
            string login = loginBox.Text.Trim();
            string pass = passwordBox.Password.Trim();
            if (IsValid(login, pass))
            {
                foreach (var prof in paswordslogins)
                {
                    if (login == prof.Login)
                    {
                        errorLogin.Text = "";
                        if (pass == prof.Password)
                        {

                            if (captchabox.Text.Equals(CaptchaText.Text, StringComparison.OrdinalIgnoreCase))
                            {
                                Laborant laborant = laborants.First(s => s.LoginPasswordId == prof.Id);
                                Window window = new LaborantView(laborant);
                                window.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            ErrorPassword.Text = "Пароль не верный";
                        }
                    }

                    else
                    {
                        ErrorLogin.Text = "Логин не найден";
                    }

                }

            }

        }

        public bool IsValid(string login, string pass)
        {
            if (login == string.Empty)
            {
                ErrorLogin.Text = "Введите логин";
                //MessageBox.Show("Требуется ввод логина");
                return false;
            }

            else if (pass == string.Empty || pass.Length < 8)
            {
                ErrorPassword.Text = "Введите корректный пароль";
                return false;
            }
            ErrorLogin.Text = "";
            ErrorPassword.Text = "";
            return true;
        }

        //connection.SaveChanges();
    }

    public class LogInfo : IDataErrorInfo
    {
        public string Login { get; set; }


        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case "Login":
                        if (string.IsNullOrEmpty(Login))
                            error = "Не введен логин";
                        break;
                }
                return error;
            }
        }

        public string Error => throw new NotImplementedException();
    }


*/

    }
}
