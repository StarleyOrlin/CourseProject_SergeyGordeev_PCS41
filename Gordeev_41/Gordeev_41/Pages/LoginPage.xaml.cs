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

namespace Gordeev_41.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxLogin.Text !="" && TBoxPassword.Password != "")
            {
                var currentClient = AppData.Context.Client_Table.ToList().FirstOrDefault(p =>
                p.ClientLogin == TBoxLogin.Text && p.ClientPassword == TBoxPassword.Password);
                if (currentClient != null)
                {
                    NavigateUser(currentClient);
                }
                else
                {
                    MessageBox.Show("Пользователь не найден",
                   "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } 
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
            }
        }

        private void NavigateUser(Entities.Client_Table currentClient)
        {
            switch (currentClient.RoleId)
            {
                case 1:
                    SaveUserSettings(currentClient.ClientId, CheckRememberMe.IsChecked.Value);
                    NavigationService.Navigate(new UserMenuPage());
                    break;
                case 2:
                    SaveUserSettings(currentClient.ClientId, CheckRememberMe.IsChecked.Value);
                    NavigationService.Navigate(new AdminMenuPage());
                    break;
                case 3:
                    SaveUserSettings(currentClient.ClientId, CheckRememberMe.IsChecked.Value);
                    NavigationService.Navigate(new CourierPage());
                    break;

                default:
                    MessageBox.Show("Для данной роли функционал не предусмотрен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }

        }

        public void SaveUserSettings(int id, bool isChecked)
        {
            if (isChecked)
            { 
            Properties.Settings.Default.UserId = id;
            Properties.Settings.Default.Save();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var UserId = Properties.Settings.Default.UserId;
            if (UserId > 0)
            {
                var currentUser = AppData.Context.Client_Table.ToList().FirstOrDefault(p => p.ClientId == UserId);
                if (currentUser != null)
                {
                    NavigateUser(currentUser);
                }
            }
        }

        private void BtnNews_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewsPage());
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
