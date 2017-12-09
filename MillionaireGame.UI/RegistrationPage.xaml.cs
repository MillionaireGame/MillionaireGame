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
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            Methods.AddPerson(textBoxLogin.Text, PasswordBox.Password, out msg);
            MessageBox.Show(msg);

            textBoxLogin.Text = null;
            PasswordBox.Password = null;
            PasswordBox2.Password = null;
        }
    }
}
