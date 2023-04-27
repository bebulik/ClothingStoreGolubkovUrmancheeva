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
        private bool isEdit = false;
        User editEmpl;
        public EmployeeAddEditWindow()
        {
            InitializeComponent();
        }

        
        public EmployeeAddEditWindow(User item)
        {
            InitializeComponent();
            tbFirstName.Text = item.FirstName;
            tbLastName.Text = item.LastName;
            tbLogin.Text = item.Login;
            tbPatr.Text = item.Patronymic;
            tbPhone.Text = item.Phone;
            pbPass.Password = item.Password;
            dpBirth.Text = Convert.ToString(item.Birthdate);

            
            isEdit = true;
            editEmpl = item;    
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                User user = new User();
                user.GenderId = cbGender.Text;
                user.Phone = tbPhone.Text;
                user.LastName = tbLastName.Text;
                user.FirstName = tbFirstName.Text;
                user.Birthdate = (DateTime)dpBirth.SelectedDate;
                user.Patronymic = tbPatr.Text;
                user.Password = pbPass.Password;
                user.Login = tbLogin.Text;
                user.RoleId = cbRole.SelectedIndex + 1;


                EFClass.Context.User.Add(user);
                EFClass.Context.SaveChanges();

                MessageBox.Show("Работник добавлен успешно");
            }
            if (isEdit == true)
            {
                editEmpl.LastName = tbLastName.Text;
                editEmpl.FirstName = tbFirstName.Text;
                editEmpl.Phone = tbPhone.Text;
                editEmpl.Birthdate = (DateTime)dpBirth.SelectedDate;
                editEmpl.Patronymic = tbPatr.Text;
                editEmpl.Password = pbPass.Password;
                editEmpl.Login = tbLogin.Text;
                editEmpl.RoleId = cbRole.SelectedIndex + 1;
                editEmpl.GenderId = cbGender.Text;
                EFClass.Context.SaveChanges();

                MessageBox.Show("Работник успешно изменен");
            }
            
        }
    }
}
