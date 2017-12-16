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
using System.Data.Entity;
using MillionaireGame.Logic;

namespace MillionaireGame.UI
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            textBoxLogin.Focus();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            if (PasswordBox.Password != PasswordBox2.Password)
            {
                MessageBox.Show("Passwords do not coincide. Try again!");
                PasswordBox.Clear();
                PasswordBox2.Clear();
            }
            if(PasswordBox.Password.Length<8)
            {
                MessageBox.Show("Your password is too short (minimal length is 8 numbers or/and letters). Try again!");
                PasswordBox.Clear();
                PasswordBox2.Clear();
            }
            else

            {
                Methods.AddPerson(textBoxLogin.Text, PasswordBox.Password, out msg);
                MessageBox.Show(msg);
                NavigationService.Navigate(new AuthorizationPage());
            }

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you do not want to register?", "Back to Authorization", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
               NavigationService.Navigate(new AuthorizationPage());
            }
        }
    }
}
