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
using System.Windows.Shapes;

namespace ClothingStoreGolubkovUrmancheeva.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void TbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "";
        }

        private void TbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "Логин";
        }

        private void TbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TbPassword.Text = "";
        }

        private void TbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            TbPassword.Text = "Пароль";
        }

        private void TbLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            TbLastName.Text = "Фамилия";
        }

        private void TbLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            TbLastName.Text = "";
        }

        private void TbFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            TbFirstName.Text = "";
        }

        private void TbFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            TbFirstName.Text = "Имя";
        }

        private void TbPatronymic_GotFocus(object sender, RoutedEventArgs e)
        {
            TbPatronymic.Text = "";
        }

        private void TbPatronymic_LostFocus(object sender, RoutedEventArgs e)
        {
            TbPatronymic.Text = "Отчество";
        }

        private void TbRole_GotFocus(object sender, RoutedEventArgs e)
        {
            TbRole.Text = "";
        }

        private void TbRole_LostFocus(object sender, RoutedEventArgs e)
        {
            TbRole.Text = "Должность";
        }
    }
}
