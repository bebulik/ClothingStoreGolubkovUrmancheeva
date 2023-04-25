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
            GetListProduct();
        }
        public void GetListProduct()
        {
            var query =

            from User in e.User join Role
            where User.RoleId == 1 || User.RoleId == 2
            
            orderby User.LastName
            select new { User.LastName, User.FirstName, User.Patronymic, User.Birthdate,  };
            dgEmpl.ItemsSource = query.ToList();
        }
    }
}
