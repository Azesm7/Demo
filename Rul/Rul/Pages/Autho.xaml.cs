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
using Rul.Entities;

namespace Rul.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        private int countUnsuccessful = 0;
        public Autho()
        {
            InitializeComponent();
            txtCaptcha.Visibility = Visibility.Hidden;
            txtBlockCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            User user = new User();

            user = RulEntities.GetContext().User.Where(p => p.UserLogin == login && p.UserPassword == password).FirstOrDefault();
            int userCount = RulEntities.GetContext().User.Where(p => p.UserLogin == login && p.UserPassword == password).Count();

            if (countUnsuccessful < 1)
            {
                if(userCount > 0)
                {
                    MessageBox.Show("Вы вошли под: " + user.Role.RoleName.ToString());
                    LoadForm(user.Role.RoleName.ToString(), user);
                }
                else
                {
                    MessageBox.Show("Вы ввели неверно логин или пароль!");
                    countUnsuccessful++;
                    if (countUnsuccessful == 1)
                        GenerateCaptcha();
                }
            }
            else
            {
                if (userCount > 0 && txtBlockCaptcha.Text == txtCaptcha.Text)
                {
                    MessageBox.Show("Вы вошли под: " + user.Role.RoleName.ToString());
                    LoadForm(user.Role.RoleName.ToString(), user);
                }
                else
                {
                    MessageBox.Show("Введите данные заново!");
                }
            }
        }

        private void GenerateCaptcha()
        {
            txtCaptcha.Visibility = Visibility.Visible;
            txtBlockCaptcha.Visibility = Visibility.Visible;

            Random random = new Random();
            int randmNum = random.Next(0, 3);

            switch(randmNum)
            {
                case 1:
                    txtBlockCaptcha.Text = "ju2sT8Cbs";
                    txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 2:
                    txtBlockCaptcha.Text = "iNwK2cl";
                    txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 3:
                    txtBlockCaptcha.Text = "uOozGk95";
                    txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
            }
        }

        private void LoadForm(string _role, User user)
        {
            switch (_role)
            {
                case "Клиент":
                    NavigationService.Navigate(new Client(user));
                    break;
            }
        }
    }
}
