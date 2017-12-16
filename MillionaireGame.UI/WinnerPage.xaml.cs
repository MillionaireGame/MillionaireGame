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
using System.Drawing;
using System.Windows.Interop;

namespace MillionaireGame.UI
{
    /// <summary>
    /// Логика взаимодействия для WinnerPage.xaml
    /// </summary>

    public partial class WinnerPage : Page
    {
        public WinnerPage(string msg, string chosenNet)
        {
            InitializeComponent();
            _msg = msg;
            _chosenNet = chosenNet;
            textBlockMoney.Text = _chosenNet;
            textBlockMessage.Text = _msg;
        }
        public WinnerPage()
        {
            InitializeComponent();
        }

        public string _msg { get; set; }
        public string _chosenNet { get; set; }

        private void buttonPlayAgain_Click(object sender, RoutedEventArgs e)
        {
            SafetyNetPage safetyNetPage = new SafetyNetPage();
            NavigationService.Navigate(safetyNetPage);
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationPage authPage = new AuthorizationPage();
            NavigationService.Navigate(authPage);
        }
    }
}
