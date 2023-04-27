using ClothingStoreGolubkovUrmancheeva.ClassHelper;
using ClothingStoreGolubkovUrmancheeva.DB;
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
    /// Логика взаимодействия для ClientAddEditWindow.xaml
    /// </summary>
    public partial class ClientAddEditWindow : Window
    {
        public ClientAddEditWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EFClass.Context.User.Add(new User
            {
                Login = tbLogin.Text,
                Password = pbPass.Password,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Patronymic = tbPatr.Text,
                Phone = tbPhone.Text,
                Birthdate = dpBirth.SelectedDate.Value,
                GenderId = cbGender.Text,
                RoleId = 3
            }) ;

            EFClass.Context.SaveChanges();
            MessageBox.Show("Клиент добавлен успешно");
        }
    }
}
