using Gordeev_41.Entities;
using System;
using System.Linq;
using System.Windows;

namespace Gordeev_41.Windows
{
    /// <summary>
    /// Interaction logic for AdminAddClient.xaml
    /// </summary>
    public partial class AdminAddClient : Window
    {

        bool isUpdates = false;
        Client_Table currentClient = new Client_Table();
        public AdminAddClient()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            TextBoxName.Clear();
            TextBoxFamily.Clear();
            TextBoxThirdName.Clear();
            TextBoxAddress.Clear();
            TextBoxNumber.Clear();
            TextBoxLogin.Clear();
            TextBoxPassword.Clear();
        }
        public AdminAddClient(Client_Table selectedClient)
        {
            InitializeComponent();

            Title = "Редактирование данных клиента";
            isUpdates = true;
            currentClient = selectedClient;
            TextBoxFamily.SelectedText = currentClient.ClientSecondName;
            TextBoxName.SelectedText = currentClient.ClientName;
            TextBoxThirdName.SelectedText = currentClient.ClientThirdName;
            DPDateOfBirth.SelectedDate = currentClient.ClientDateOfBirth;
            TextBoxAddress.SelectedText = currentClient.ClientAddress;
            TextBoxNumber.SelectedText = currentClient.ClientNumber;
            TextBoxLogin.SelectedText = currentClient.ClientLogin;
            TextBoxPassword.SelectedText = currentClient.ClientPassword;
            
        }

        private void ButtonAddClient_Click(object sender, RoutedEventArgs e)
        {
            var errors = "";

            if (string.IsNullOrWhiteSpace(TextBoxFamily.Text)) errors += "Вы не ввели фамилию" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxName.Text)) errors += "Вы не ввели имя" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxThirdName.Text)) errors += "Вы не ввели отчество" + Environment.NewLine;
            if (DPDateOfBirth.SelectedDate == null) errors += "Вы не выбрали дату рождения" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxAddress.Text)) errors += "Вы не ввели адрес" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxNumber.Text)) errors += "Вы не ввели номер телефона" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxLogin.Text)) errors += "Вы не ввели логин" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxPassword.Text)) errors += "Вы не ввели пароль" + Environment.NewLine;

            if (!isUpdates)
            {
                var currentResult = MessageBox.Show("Вы уверены, что хотите добавить нового клиента?", "Добавление данных", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (currentResult == MessageBoxResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(errors))
                    {
                        var newClient = new Client_Table
                        {
                            ClientId = AppData.Context.Client_Table.ToList().Max(p => p.RoleId) + 1,
                            ClientSecondName = TextBoxFamily.Text.Trim(),
                            ClientName = TextBoxName.Text.Trim(),
                            ClientThirdName = TextBoxThirdName.Text.Trim(),
                            ClientDateOfBirth = DPDateOfBirth.SelectedDate.Value.Date,
                            ClientAddress = TextBoxAddress.Text.Trim(),
                            ClientNumber = TextBoxNumber.Text.Trim(),
                            RoleId = 1
                        };
                        AppData.Context.Client_Table.Add(newClient);
                        AppData.Context.SaveChanges();

                        MessageBox.Show("Вы добавили нового клиента в базу данных!", "Добавление клиента в базу данных", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show($"{errors}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                var result = MessageBox.Show("Вы уверены, что хотите сохранить введеные данные?", "Редактирование введеных данных", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(errors))
                    {
                        currentClient.ClientSecondName = TextBoxFamily.Text.Trim();
                        currentClient.ClientName = TextBoxName.Text.Trim();
                        currentClient.ClientThirdName = TextBoxThirdName.Text.Trim();
                        currentClient.ClientDateOfBirth = DPDateOfBirth.SelectedDate.Value.Date;
                        currentClient.ClientAddress = TextBoxAddress.Text.Trim();
                        currentClient.ClientNumber = TextBoxNumber.Text.Trim();
                        currentClient.ClientLogin = TextBoxLogin.Text.Trim();
                        currentClient.ClientPassword = TextBoxPassword.Text.Trim();
                        AppData.Context.SaveChanges();

                        MessageBox.Show("Вы отредактировали данные!", "Редактирование данных", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show($"{errors}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
