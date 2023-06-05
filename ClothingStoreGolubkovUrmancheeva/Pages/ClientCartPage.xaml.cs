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
            if (selectedProduct.Count == 1)
            {
                ClassHelper.CartClass.products.Remove(selectedProduct);
                
            }
            else if (ClassHelper.CartClass.products.Contains(selectedProduct))
            {
                int a = ClassHelper.CartClass.products.IndexOf(selectedProduct);
                ClassHelper.CartClass.products[a].Count--;
                
            }
            
            
            
            

        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            List<Client> clients = new List<Client>();
            clients = EFClass.Context.Client.ToList();
            int id = UserClass.user.UserId;

            Order order = new Order()
            {
                ClientId = clients.Where(x => x.UserId == id).First().ClientId,
                EmployeeId = 1,
                DateTime = DateTime.Now

            };
            EFClass.Context.Order.Add(order);
            EFClass.Context.SaveChanges();
            foreach (var item in CartClass.products)
            {
                ProductOrder po = new ProductOrder()
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    Quantity = item.Count,
                    Price = item.Price * item.Count
                };
                EFClass.Context.ProductOrder.Add(po);

            }
            EFClass.Context.SaveChanges();
            MessageBox.Show("Покупка прошла успешно");

        }
    }
}

