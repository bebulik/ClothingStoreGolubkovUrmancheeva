﻿using ClothingStoreGolubkovUrmancheeva.ClassHelper;
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
    /// Логика взаимодействия для ClothesPage.xaml
    /// </summary>
    public partial class ClothesPage : Page
    {
        public ClothesPage()
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

    }
}
