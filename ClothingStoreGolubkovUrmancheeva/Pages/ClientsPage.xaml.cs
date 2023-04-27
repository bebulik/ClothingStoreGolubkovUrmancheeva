using ClothingStoreGolubkovUrmancheeva.DB;
using ClothingStoreGolubkovUrmancheeva.Windows;
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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        Entities e = new Entities();
        public ClientsPage()
        {
            InitializeComponent();
            GetListClients();
        }
        public void GetListClients()
        {
            var query =
                from U in e.User 
                where U.RoleId == 3
                orderby U.FirstName

                select new
                {
                    U.FirstName, U.LastName, U.Phone, U.GenderId, U.Birthdate, U.Patronymic, U.Login, U.Password, U.RoleId
                };
            dgClients.ItemsSource = query.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClientAddEditWindow ca = new ClientAddEditWindow();
            ca.ShowDialog();
            GetListClients();
        }
    }
}
