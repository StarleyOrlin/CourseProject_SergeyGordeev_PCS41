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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TextBoxName.Clear();
            TextBoxFamily.Clear();
            TextBoxThirdName.Clear();
            TextBoxAddress.Clear();
            TextBoxNumber.Clear();
            
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var errors = "";

            if (string.IsNullOrWhiteSpace(TextBoxFamily.Text)) errors += "Вы не ввели фамилию" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxName.Text)) errors += "Вы не ввели имя" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxThirdName.Text)) errors += "Вы не ввели отчество" + Environment.NewLine;
            if (DPDateOfBirth.SelectedDate == null) errors += "Вы не выбрали дату рождения" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxAddress.Text)) errors += "Вы не ввели адрес" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxNumber.Text)) errors += "Вы не ввели номер телефона" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(TextBoxLogin.Text)) errors += "Вы не ввели логин" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(PasswordBoxPassword.Password)) errors += "Вы не ввели пароль" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(PasswordBoxPasswordRepeat.Password)) errors += "Вы не ввели пароль повторно" + Environment.NewLine;
            if (PasswordBoxPassword.Password != PasswordBoxPasswordRepeat.Password) errors += "Введенные пароли не совпадают" + Environment.NewLine;
            if (string.IsNullOrWhiteSpace(errors))
            {
                var currentResult = MessageBox.Show("Вы уверены, что хотите зарегистрироваться?", "Регистрация", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (currentResult == MessageBoxResult.Yes)
                {
                    DateTime? selectedDate = DPDateOfBirth.SelectedDate;
                    selectedDate.Value.Date.ToShortDateString();


                    var currentClient = new Entities.Client_Table
                    {
                        ClientId = AppData.Context.Client_Table.ToList().Max(p => p.ClientId) + 1,
                        ClientSecondName = TextBoxFamily.Text,
                        ClientName = TextBoxName.Text,
                        ClientThirdName = TextBoxThirdName.Text,
                        ClientDateOfBirth = selectedDate.Value,
                        ClientAddress = TextBoxAddress.Text,
                        ClientNumber = TextBoxNumber.Text,
                        ClientLogin = TextBoxLogin.Text,
                        ClientPassword = PasswordBoxPassword.Password,
                        RoleId = 1
                    };
                    AppData.Context.Client_Table.Add(currentClient);
                    AppData.Context.SaveChanges();

                    MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new Pages.LoginPage());
                }
            }
            else
                MessageBox.Show($"{errors}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void CheckBoxShowPass_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = PasswordBoxPassword.Password;
            PasswordBoxPassword.Password = TextBoxPassword.Text;
            TextBoxPassword.Visibility = Visibility.Visible;
            PasswordBoxPassword.Visibility = Visibility.Collapsed;

            TextBoxPasswordRepeat.Text = PasswordBoxPasswordRepeat.Password;
            PasswordBoxPasswordRepeat.Password = TextBoxPasswordRepeat.Text;
            TextBoxPasswordRepeat.Visibility = Visibility.Visible;
            PasswordBoxPasswordRepeat.Visibility = Visibility.Collapsed;
        }

        private void CheckBoxShowPass_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBoxPassword.Password = TextBoxPassword.Text;
            TextBoxPassword.Visibility = Visibility.Collapsed;
            PasswordBoxPassword.Visibility = Visibility.Visible;

            PasswordBoxPasswordRepeat.Password = TextBoxPasswordRepeat.Text;
            TextBoxPasswordRepeat.Visibility = Visibility.Collapsed;
            PasswordBoxPasswordRepeat.Visibility = Visibility.Visible;
        }
    }
}
