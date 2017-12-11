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
            Questions();

        }

        //started to write logic of the game
        private Question CurrentQuest { get; set; }

        List<int> questionUsedId = new List<int>();
        List<int> prices = new List<int>(new int[] { 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000, 500000, 1000000 }); //List for prices

        // hints

        //
        int correctAnswerCounter = 0;
        int questionsID;
       
        string correctLetter; //String to remember correct letter when you use audienceHelp
        string callAnswer; //String for correct answer when you use callHelp
        






        // one event for four buttons
        private void answer_Click(object sender, RoutedEventArgs e)
        {
            Repository rep = new Repository();
          //  questionUsedId.Add(rep.Questions[questionsID])
            string Tag = (sender as Button).Tag.ToString(); //Getting the Tag of button that has been checked (A,B,C or D)
            if (Tag == rep.Questions[questionsID].CorrectAnswer)
            {
                MessageBox.Show("Correct Answer yohooo");
                Questions();
                textBlockMoney.Text = prices[correctAnswerCounter].ToString();
                correctAnswerCounter++;
              //  UpdateButton.Content = "Next Question";//If answer is correct, the content of the button will be "Next Question"
              //  UpdateButton.Visibility = System.Windows.Visibility.Visible;
              //  (sender as Button).Background = System.Windows.Media.Brushes.Green;

            }

            else
            {
                MessageBox.Show("Incorrect answer Sorry");
                return;

            }


        }














        //methods for questions 

        private int  Questions()
        {// choosing a random number for quest 
            // rand quest+ 
            // answers

            Repository rep = new Repository();
            Random rnd = new Random();
            //  int month = rnd.Next(1, 13);
            questionsID = rnd.Next(0, rep.Questions.Count );
           
            if (questionUsedId.Contains(questionsID))
            {
              //  MessageBox.Show("This question has already been used");
               Questions();
                
            }
            else
            {
                textQuestion.Text = rep.Questions[questionsID].QuestionText.ToString();
                questionUsedId.Add(questionsID);
                buttonAnswerA.Content = "A" + rep.Questions[questionsID].AnswerA.ToString();
                buttonAnswerB.Content = "B" + rep.Questions[questionsID].AnswerB.ToString();
                buttonAnswerC.Content = "C" + rep.Questions[questionsID].AnswerC.ToString();
                buttonAnswerD.Content = "D" + rep.Questions[questionsID].AnswerD.ToString();

            }
            // randomCommand = "SELECT top 1 * from QuestionTable ORDER BY Rnd(-(100000*ID)*Time()) ";


            return questionsID;
        }




      // for going back ))))))))))))))))))))))))))))))))))))))))))
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

        private void Upd(object sender, RoutedEventArgs e)
        {
            Questions();
        }

        private void button50_50_Click(object sender, RoutedEventArgs e)
        {

        }
    }



    
   
}

