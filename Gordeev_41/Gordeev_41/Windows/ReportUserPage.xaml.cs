using mshtml;
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

namespace Gordeev_41.Windows
{
    /// <summary>
    /// Interaction logic for ReportUserPage.xaml
    /// </summary>
    public partial class ReportUserPage : Window
    {
        public ReportUserPage()
        {
            InitializeComponent();
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            var document = BrowserReport.Document as IHTMLDocument2;
            document.execCommand("Print");
        }

        private void ButtonPDF_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog PD = new PrintDialog();
            if (PD.ShowDialog() == true)
            {
                ButtonPDF.Visibility = Visibility.Hidden;
                ButtonPDF.Visibility = Visibility.Hidden;

                var currentWindowState = App.Current.MainWindow.WindowState;
                App.Current.MainWindow.WindowState = WindowState.Maximized;
                PD.PrintVisual(this, "PDF");
                App.Current.MainWindow.WindowState = currentWindowState;

                ButtonPDF.Visibility = Visibility.Visible;
                ButtonPDF.Visibility = Visibility.Visible;

                MessageBox.Show("Отчет в формате PDF успешно сформирован!", "Отчет в PDF", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
