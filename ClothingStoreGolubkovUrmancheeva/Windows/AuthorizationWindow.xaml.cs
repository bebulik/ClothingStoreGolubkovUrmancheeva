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


namespace ClothingStoreGolubkovUrmancheeva.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var Auth = EFClass.Context.User.ToList().Where(x => x.Login == TbLogin.Text && x.Password == PbPassword.Text).FirstOrDefault();
            if ( Auth != null )
            {
                UserClass.user = Auth;
                switch (Auth.RoleId)
                {
                    case 1:
                        MessageBox.Show("ОК!");
                        MainWindow Bebra = new MainWindow();
                        Bebra.Show();
                        this.Close();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;

                    default:
                        break;
                }
                
            }
            else
            {
                MessageBox.Show("Пользователь не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            PbPassword.Text = "";
        }

        private void PbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void TbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "";
        }

        private void TbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            registration.Show();
            this.Close();
        }
    }
}
