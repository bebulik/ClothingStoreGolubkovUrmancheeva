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
        private bool isEdit = false;
        Product editProduct;
        public ProductAddingWindow()
        {
            InitializeComponent();
            CmbSize.ItemsSource = EFClass.Context.Size.ToList();
            CmbSize.DisplayMemberPath = "Size1";
            CmbSize.SelectedIndex = 0;

        }
        public ProductAddingWindow(Product product)
        {
            InitializeComponent();

            // Заполнение комбобокса

            CmbSize.ItemsSource = EFClass.Context.Size.ToList();
            CmbSize.DisplayMemberPath = "Name";
            CmbSize.SelectedIndex = 0;

            // заполнение полей значениями 
            TbName.Text = product.ProductName;
            TbPrice.Text = product.Price.ToString();
            CmbSize.SelectedItem = EFClass.Context.Size.ToList().Where(i => i.SizeId == product.SizeId).FirstOrDefault();

            // вывод фото

            if (product.Image != null)
            {
                using (MemoryStream ms = new MemoryStream(product.Image))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    ProdImg.Source = bitmapImage;
                }
            }


            // Изменение заголовка и кнопки 

            WinLabel.Content = "Изменение товара";
            btnAdd.Content = "Изменить";

            // флаг на изменение
            isEdit = true;

            // выводим из контекста класса полученный продукт
            editProduct = product;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                // редактирование

                editProduct.ProductName = TbName.Text;
                editProduct.Price = Convert.ToDecimal(TbPrice.Text);
                editProduct.SizeId = (CmbSize.SelectedItem as DB.Size).SizeId;
                if (pathImageProduct != null)
                {
                    editProduct.Image = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар успешно изменен");


            }
            else
            {
                // добавление
                Product product = new Product();
                product.ProductName = TbName.Text;
                product.Price = Convert.ToDecimal(TbPrice.Text);
                product.SizeId = (CmbSize.SelectedItem as DB.Size).SizeId;
                if (pathImageProduct != null)
                {
                    product.Image = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.Product.Add(product);
                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар добавлен");
            }


            this.Close();
        }
    

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ProdImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImageProduct = openFileDialog.FileName;
            }

        }
    }
}
