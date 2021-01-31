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

namespace Gordeev_41
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.LoginPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var page = MainFrame.Content as Page;
            if (page is Pages.AdminMenuPage || page is Pages.UserMenuPage)
            {
                Properties.Settings.Default.UserId = 0;
                Properties.Settings.Default.Save();
            }
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var page = (sender as Frame).Content as Page;

            if (page is Pages.LoginPage)
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            if (page is Pages.AdminMenuPage || page is Pages.UserMenuPage)
            {

            }
        }
    }
}
