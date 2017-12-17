using MillionaireGame.Logic;
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

namespace MillionaireGame.UI
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            textBoxLogin.Focus();
        }

       

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        { 
            NavigationService.Navigate(new RegistrationPage());
        }

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text == "")

            {
                MessageBox.Show("Enter login");
                return;
            }
            if (PasswordBox.Password.ToString() == "")
            {
                MessageBox.Show("Enter password");
                return;
            }


            if (textBoxLogin.Text == "admin" && PasswordBox.Password.ToString() == "12345678")
            {
                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                string msg;
                MethodsForPersons.CheckPlayer(textBoxLogin.Text, PasswordBox.Password, out msg);
                if (msg == "")
                {
                    NavigationService.Navigate(new SafetyNetPage());
                }
                else MessageBox.Show(msg);
            }
        }
    }
}
