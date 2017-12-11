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
            
            comboboxPrices.Items.Add("1000");
            comboboxPrices.Items.Add("500");
            comboboxPrices.Items.Add("5000");
            comboboxPrices.Items.Add("10000");
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            string m;
            if (comboboxPrices.SelectedIndex > -1) //somthing was selected
            {
                m = comboboxPrices.SelectedItem.ToString();
                MessageBox.Show("Your Safety Net is " + m);
            }
            else
            {
                MessageBox.Show("you havent chosen anything");
            }

        }
    }
}
