using ClothingStoreGolubkovUrmancheeva.Pages;
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

namespace ClothingStoreGolubkovUrmancheeva
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int a)
        {
            InitializeComponent();
            
            if(a == 2)
            {
                btnEmpl.Visibility = Visibility.Hidden;
            }
            if (a == 3)
            {
                btnEmpl.Visibility = Visibility.Hidden;
                
                btnClients.Visibility = Visibility.Hidden;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            EmployeesPage ep = new EmployeesPage();
            MainFrame.Navigate(ep);
        }

        private void btnClothes_Click(object sender, RoutedEventArgs e)
        {
            ProductsPage1 pr = new ProductsPage1();
            MainFrame.Navigate(pr);
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            ClientsPage cp = new ClientsPage();
            MainFrame.Navigate(cp);
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
           ClientCartPage cp = new ClientCartPage();
            MainFrame.Navigate(cp);
        }
    }
}
