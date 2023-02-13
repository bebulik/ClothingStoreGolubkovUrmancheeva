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

using ClothingStoreGolubkovUrmancheeva.ClassHelper;
using ClothingStoreGolubkovUrmancheeva.DB;
using ClothingStoreGolubkovUrmancheeva.Windows;

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
            CmbGender.ItemsSource = ClassHelper.EFClass.Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "GenderName";

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
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Поле логин должно быть заполнено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                MessageBox.Show("Поле пароль должно быть заполнено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Поле фамилия должно быть заполнено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Поле имя должно быть заполнено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPhone.Text) )
            {
                MessageBox.Show("Поле телефон должно быть заполнено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            EFClass.Context.User.Add(new User
            {
                Login = TbLogin.Text,
                Password = TbPassword.Text,
                FirstName = TbFirstName.Text,
                LastName = TbLastName.Text,
                Patronymic = TbPatronymic.Text,
                Phone = TbPhone.Text,
                Birthdate = DpBirthday.SelectedDate.Value,
                GenderId = (CmbGender.SelectedItem as Gender).GenderId,
                RoleId = 3
            }) ;

            EFClass.Context.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно!");
        }
    }
}
