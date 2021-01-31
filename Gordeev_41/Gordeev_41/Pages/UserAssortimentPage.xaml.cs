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
    /// Interaction logic for UserAssortimentPage.xaml
    /// </summary>
    public partial class UserAssortimentPage : Page
    {
        public UserAssortimentPage()
        {
            InitializeComponent();
            LVAssortiment.ItemsSource = AppData.Context.Good_Table.ToList();

        }

        private void ComboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBoxSearching_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAssortimentByKeyWord();
        }
        private void UpdateAssortimentByKeyWord()
        {

            string keyWord = TextBoxSearching.Text.ToLower();
            LVAssortiment.ItemsSource = AppData.Context.Good_Table.ToList()
                .Where(p => p.GoodName.ToLower().Contains(keyWord) ||
                p.GoodCategory.ToLower().Contains(keyWord) ||
                p.GoodWeight.ToLower().Contains(keyWord) ||
                p.GoodPrice.ToString().Contains(keyWord)).ToList();

        }
        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
