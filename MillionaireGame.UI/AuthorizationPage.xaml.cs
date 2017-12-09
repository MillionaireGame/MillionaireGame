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
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
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

            if (textBoxLogin.Text=="admin"&& PasswordBox.Password.ToString()=="12345678")
            {
                AdminPage adminpage = new AdminPage();
                //GamePage gp = new GamePage();
                RegistrationPage reg = new RegistrationPage();
                NavigationService.Navigate(adminpage);
            }

        }
    }
}
