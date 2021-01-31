using Gordeev_41.Entities;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Gordeev_41.Pages
{
    /// <summary>
    /// Interaction logic for AdminClientPage.xaml
    /// </summary>
    public partial class AdminClientPage : Page
    {
        Client_Table Client = new Client_Table();
        public AdminClientPage()
        {
            InitializeComponent();
            DataGridClients.ItemsSource = AppData.Context.Client_Table.ToList();

            Client_Table Clientt = new Client_Table();
        }


        private void DateTimePickerFirst_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DateTimePickerSecond_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBoxKeyWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Windows.AdminAddClient AddClient = new Windows.AdminAddClient((Client_Table)DataGridClients.SelectedItem);
            AddClient.ShowDialog();
            DataGridClients.ItemsSource = AppData.Context.Client_Table.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AdminAddClient EditClient = new Windows.AdminAddClient();
            EditClient.ShowDialog();
            DataGridClients.ItemsSource = AppData.Context.Client_Table.ToList();

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этого клиента из базы данных?", "Уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Client_Table selectedClient = (Client_Table)DataGridClients.SelectedItem;
                selectedClient.RoleId = 1;
                AppData.Context.Client_Table.Remove((Client_Table)DataGridClients.SelectedItem);
                AppData.Context.SaveChanges();
                MessageBox.Show("Вы удалили клиента!", "Удаление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridClients.ItemsSource = AppData.Context.Client_Table.ToList();
            }
        }

        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var currentClient = AppData.Context.Client_Table.ToList();

            var result = new StringBuilder();

            // Основные теги перед генерацией таблицы.
            result.Append("<html>");
            result.Append("<meta charset='utf-8'/>");
            result.Append("<title>Отчет по клиентам</title>");
            result.Append("<body>");

            // Заголовок отчета.
            result.Append("<p align='center'><b>Отчет по клиентской базе</b></p>");

            // Тег с параметрами таблицы.
            result.Append("<table width=100% border=1 bordercolor=#000 style='border-collapse:collapse;'>");

            // Настройка строк и столбцов внутри. tr - строка, td - столбец.
            result.Append("<tr>");
            // Необходимые заголовки таблицы.
            result.Append("<td align=center><b>Имя</b></td>");
            result.Append("<td align=center><b>Фамилия</b></td>");
            result.Append("<td align=center><b>Отчество</b></td>");
            result.Append("<td align=center><b>Адрес</b></td>");
            result.Append("<td align=center><b>Дата рождения</b></td>");   
            result.Append("<td align=center><b>Номер телефона</b></td>");
            result.Append("</tr>");

            // Генерация содержимого через цикл.
            foreach (var client in currentClient)
            {
                // Настройка строк и столбцов внутри. tr - строка, td - столбец.
                result.Append("<tr>");
                // Обращение к переменной client и получение необходимого свойства в соответствии с заголовком.
                result.Append($"<td align=center>{client.ClientName}</td>");
                result.Append($"<td align=center>{client.ClientSecondName}</td>");
                result.Append($"<td align=center>{client.ClientThirdName}</td>");
                result.Append($"<td align=center>{client.ClientAddress}</td>");
                result.Append($"<td align=center>{client.ClientDateOfBirth}</td>");
                result.Append($"<td align=center>{client.ClientNumber}</td>");
                result.Append("</tr>");
            }

            // Закрытие основных тегов.
            result.Append("</table>");
            result.Append("</body>");
            result.Append("</html>");

            // Загрузка отчета в WebBrowser.
            Windows.ReportUserPage reportWindow = new Windows.ReportUserPage();
            string filename = Application.ResourceAssembly + @"\Отчет по клиенту.html";
            using (FileStream fs = new FileStream("Отчет по клиенту.html", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(result);
                }
            }
            reportWindow.BrowserReport.NavigateToString(result.ToString());
            reportWindow.Width = reportWindow.MaxWidth = 500;
            reportWindow.ShowDialog();
        }

        private void DataGridClients_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataGridClients.SelectedItems.Count == 1)
            {
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                
            }
            else
            {
                ButtonEdit.IsEnabled = false;
                ButtonDelete.IsEnabled = false;
                
            }
        }
    }
}
