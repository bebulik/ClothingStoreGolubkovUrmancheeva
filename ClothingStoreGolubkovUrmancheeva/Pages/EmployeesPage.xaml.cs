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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClothingStoreGolubkovUrmancheeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {   
        Entities e = new Entities();
        public EmployeesPage()
        {
            InitializeComponent();
            GetListEmployee();
        }
        public void GetListEmployee()
        {
            var query =

            from U  in e.User join R  in e.Role on U.RoleId equals R.RoleId
            where U.RoleId == 1 || U.RoleId == 2
            orderby U.FirstName
            select new {U.Login, U.Password, U.LastName, U.FirstName, U.Patronymic, U.Birthdate, R.RoleName, U.GenderId, U.Phone };
            dgEmpl.ItemsSource = query.ToList();
            //List<Employee> employees = new List<Employee>();
            //employees = EFClass.Context.Employee.ToList();
            //dgEmpl.ItemsSource = employees;
        }

        private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAddEditWindow employeeAddEditWindow = new EmployeeAddEditWindow();
            employeeAddEditWindow.ShowDialog();
            GetListEmployee();
        }

        private void dgEmpl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User item = dgEmpl.SelectedItem as User;
            EmployeeAddEditWindow employeeAddEditWindow = new EmployeeAddEditWindow(item);
            employeeAddEditWindow.ShowDialog();
            GetListEmployee();
            
        }

        private void btnEditEmpl_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Gender = dgEmpl.log as Gender;
            user.Phone = dgEmpl.
            EmployeeAddEditWindow employeeAddEditWindow = new EmployeeAddEditWindow(user);
            Console.WriteLine(user);
            employeeAddEditWindow.Show();
            
            GetListEmployee();
        }
    }
}
