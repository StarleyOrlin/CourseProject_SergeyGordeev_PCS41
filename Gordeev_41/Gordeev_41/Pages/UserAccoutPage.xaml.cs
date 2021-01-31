using Gordeev_41.Entities;
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
    /// Interaction logic for UserAccoutPage.xaml
    /// </summary>
    public partial class UserAccoutPage : Page
    {
        public UserAccoutPage()
        {
            InitializeComponent();
        }
        private void LoadAndUpdateData()
        {
            int userId = Properties.Settings.Default.UserId;
            if (userId > 0)
            {
                var currentUser = AppData.Context.Client_Table.ToList().FirstOrDefault(p => p.ClientId == userId);
                var currentClient = AppData.Context.Client_Table.ToList().FirstOrDefault(p => p.ClientId == userId);
                if (currentUser != null && currentClient != null)
                {
                    TextBoxSecondName.Text = currentClient.ClientSecondName.ToString();
                    TextBoxName.Text = currentClient.ClientName.ToString();
                    TextBoxThirdName.Text = currentClient.ClientThirdName.ToString();
                    TextBoxDateOfBirth.Text = currentClient.ClientDateOfBirth.ToShortDateString();
                    TextBoxAddress.Text = currentClient.ClientAddress.ToString();
                    TextBoxNumber.Text = currentClient.ClientNumber.ToString();
                    TextBoxLogin.Text = currentUser.ClientLogin.ToString();
                    TextBoxPassword.Text = currentUser.ClientPassword.ToString();
                }
            }
        }


        private void ButtonEditData_Click(object sender, RoutedEventArgs e)
        {
            int userId = Properties.Settings.Default.UserId;
            if (userId > 0)
            {
                var currentClient = AppData.Context.Client_Table.ToList().FirstOrDefault(p => p.RoleId == userId);
                if (currentClient != null)
                {
                    Windows.AdminAddClient EditClient = new Windows.AdminAddClient(currentClient);
                    EditClient.ShowDialog();
                    LoadAndUpdateData();
                }
            }
        }

        private void ButtonDeleteData_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить свою учетную запись навсегда?", "Удаление учетной записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int userId = Properties.Settings.Default.UserId;
                if (userId > 0)
                {
                    var currentClient = AppData.Context.Client_Table.ToList().FirstOrDefault(p => p.RoleId == userId);
                    if (currentClient != null)
                    {
                        Client_Table client = currentClient;
                        client.RoleId = 1;
                        AppData.Context.Client_Table.Remove(currentClient);
                        AppData.Context.SaveChanges();
                        MessageBox.Show("Вы удалили свою учетную запись!", "Удаление учетной записи", MessageBoxButton.OK, MessageBoxImage.Information);
                        Properties.Settings.Default.UserId = 0;
                        NavigationService.Navigate(new LoginPage());
                    }
                }
            }
        }
    }
}
