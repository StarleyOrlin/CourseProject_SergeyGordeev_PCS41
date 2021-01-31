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
    /// Interaction logic for Authorisation.xaml
    /// </summary>
    public partial class UserMenuPage : Page
    {
        public UserMenuPage()
        {
            InitializeComponent();
        }

        private void ButtonLK_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserAccoutPage());
        }

        private void ButtonOrganisation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InformationPage());
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAssortiment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserAssortimentPage());
        }

        private void ButtonNews_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewsPage());
        }
    }
}
