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
using ClothingStoreGolubkovUrmancheeva.ClassHelper;
using ClothingStoreGolubkovUrmancheeva.DB;
using ClothingStoreGolubkovUrmancheeva.Pages;
using ClothingStoreGolubkovUrmancheeva.Windows;

namespace ClothingStoreGolubkovUrmancheeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage1.xaml
    /// </summary>
    public partial class ProductsPage1 : Page
    {
       
        
            public ProductsPage1()
            {
                InitializeComponent();
                GetListProduct();

            }
            public void GetListProduct()
            {
                List<Product> products = new List<Product>();
                products = EFClass.Context.Product.ToList();

                LvProduct.ItemsSource = products;
            }

        private void addProductBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductAddingWindow additingwindow = new ProductAddingWindow();
            additingwindow.ShowDialog();
            GetListProduct();

        }
    }
}
