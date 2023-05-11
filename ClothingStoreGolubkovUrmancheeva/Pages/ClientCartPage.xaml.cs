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
    /// Логика взаимодействия для ClientCartPage.xaml
    /// </summary>
    public partial class ClientCartPage : Page
    {
        public ClientCartPage()
        {
            InitializeComponent();
            GetCartList();
        }
        public void GetCartList()
        {
            LvProduct.ItemsSource = ClassHelper.CartClass.products;
        }

        private void btnDeleteFromCart_Click(object sender, RoutedEventArgs e)
            
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;
            ClassHelper.CartClass.products.Remove(selectedProduct);
            GetCartList();
        }
    }
}
