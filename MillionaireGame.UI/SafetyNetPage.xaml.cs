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
    /// Логика взаимодействия для SafetyNetPage.xaml
    /// </summary>
    public partial class SafetyNetPage : Page
    {
        public  SafetyNetPage()
        {
            InitializeComponent();           
            
            comboboxPrices.Items.Add("100");
            comboboxPrices.Items.Add("200");
            comboboxPrices.Items.Add("500");
            comboboxPrices.Items.Add("1000");
            comboboxPrices.Items.Add("2000");
            comboboxPrices.Items.Add("5000");
            comboboxPrices.Items.Add("10000");
            comboboxPrices.Items.Add("20000");
            comboboxPrices.Items.Add("50000");
            comboboxPrices.Items.Add("100000");
            comboboxPrices.Items.Add("200000");
            comboboxPrices.Items.Add("500000");
        }
        
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you do not want to continue?", "Back to Authorization", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                AuthorizationPage authpage = new AuthorizationPage();
                NavigationService.Navigate(authpage);
            }
        }
        
        private void Play_Click(object sender, RoutedEventArgs e)
        {            
            if (comboboxPrices.SelectedIndex > -1) //somthing was selected
            {
                GamePage gamepage = new GamePage(comboboxPrices.SelectedItem.ToString());
                NavigationService.Navigate(gamepage);
            }
            else
            {
                MessageBox.Show("You haven't chosen anything");
            }
        }
    }
}
