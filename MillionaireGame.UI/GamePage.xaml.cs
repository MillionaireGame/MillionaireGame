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
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();

        }

        //started to write logic of the game
        private Question NewQuestion { get; set; }

        List<int> questionUsedId = new List<int>();
        List<int> prices = new List<int>(new int[] { 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000, 500000, 1000000 }); //List for prices

        // hints

        //
        int correctAnswerCounter = 0;
        string questionsID;
        string randomCommand; //String for sql random command
        string correctLetter; //String to remember correct letter when you use audienceHelp
        string callAnswer; //String for correct answer when you use callHelp
        string win;// for sum






        // one event for four buttons
        private void answer_Click(object sender, RoutedEventArgs e)
        {
            string Tag = (sender as Button).Tag.ToString(); //Getting the Tag of button that has been checked (A,B,C or D)


        }




        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Are you sure, you want to exit ?", "Exit the Game", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.OK)
            {
                AuthorizationPage authpage = new AuthorizationPage();
                NavigationService.Navigate(authpage);
            }
            else
            {
                return;
            }
        }
    }



    
   
}

