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
    /// Interaction logic for NewsPage.xaml
    /// </summary>
    public partial class NewsPage : Page
    {
        public NewsPage()
        {
            InitializeComponent();
            LViewNews.ItemsSource = AppData.Context.NewsItems.ToList();

        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboAutors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
