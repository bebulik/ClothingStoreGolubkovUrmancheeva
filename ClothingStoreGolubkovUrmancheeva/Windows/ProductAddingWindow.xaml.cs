using Microsoft.Win32;
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
using ClothingStoreGolubkovUrmancheeva.Pages;
using ClothingStoreGolubkovUrmancheeva.Windows;
using System.IO;


namespace ClothingStoreGolubkovUrmancheeva.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductAddingWindow.xaml
    /// </summary>
    public partial class ProductAddingWindow : Window
    {
        private string pathImageProduct = null;
        public ProductAddingWindow()
        {
            InitializeComponent();
            CmbSize.ItemsSource = EFClass.Context.Size.ToList();
            CmbSize.DisplayMemberPath = "Size1";
            CmbSize.SelectedIndex = 0;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ProdImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImageProduct = openFileDialog.FileName;
            }

        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ProductName = TbName.Text;
            product.Price = Convert.ToDecimal(TbPrice.Text);
        }
    }
}
