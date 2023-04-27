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
using System.Xml.Linq;

namespace ClothingStoreGolubkovUrmancheeva
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddEditWindow.xaml
    /// </summary>
    public partial class EmployeeAddEditWindow : Window
    {
        
        public EmployeeAddEditWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.GenderId = cbGender.Text;
            user.Phone = tbPhone.Text;
            user.LastName = tbLastName.Text;
            user.FirstName = tbFirstName.Text;
            user.Birthdate = (DateTime) dpBirth.SelectedDate ;
            user.Patronymic = tbPatr.Text;
            user.Password = pbPass.Password;
            user.Login = tbLogin.Text;
            user.RoleId = cbRole.SelectedIndex+1;


            EFClass.Context.User.Add(user);
            EFClass.Context.SaveChanges();

            MessageBox.Show("Работник добавлен успешно");
        }
    }
}
