using MillionaireGame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public GamePage(string net)
        {
            InitializeComponent();
            Questions();

            chosenNet = net;

        }
        public GamePage()
        {
            InitializeComponent();
            Questions();
        }
        //started to write logic of the game
        private Question CurrentQuest { get; set; }

        List<int> questionUsedId = new List<int>();
        List<string> prices = new List<string>(new string[] { "100", "200", "500", "1000", "2000", "5000", "10000", "20000", "50000", "100000", "200000", "500000", "1000000","" }); //List for prices
        SafetyNetPage saf = new SafetyNetPage();
        Repository rep = new Repository();
        public string chosenNet { get; set; }
        // hints

        //
        int correctAnswerCounter = 1;
        //  int questionsID;
        public int questionsID { get; set; }

        
        // one event for four buttons
        private void answer_Click(object sender, RoutedEventArgs e)
        {
            
            //  questionUsedId.Add(rep.Questions[questionsID])
            string Tag = (sender as Button).Tag.ToString(); //Getting the Tag of button that has been checked (A,B,C or D)

            if (Tag == rep.Questions[questionsID].CorrectAnswer)
            {
                if (int.Parse(textBlockMoney.Text) == 1000000)
                {
                    WinnerPage winnerPage = new WinnerPage();
                    NavigationService.Navigate(winnerPage);
                }
                //  MessageBox.Show("Correct Answer yohooo");
                else
                {
                    
                        textBlockMoney.Text = prices[correctAnswerCounter].ToString();
                        textBlockMoneyPrev.Text = prices[correctAnswerCounter - 1].ToString();
                        textBlockMoneyNext.Text = prices[correctAnswerCounter + 1].ToString();
                        correctAnswerCounter++;

                        Questions();
                    
                }
            }

            else
            {
                if (int.Parse(textBlockMoney.Text) <=int.Parse(chosenNet)) 
                {
                    MessageBox.Show("Sorry but your prize is NULL");
                    GoingBackOrUpdatingPage();
                }
                else
                {
                    MessageBox.Show($"You have already reached your guaranteed prize. You have won {chosenNet} Lucky u !!!");
                    GoingBackOrUpdatingPage();
                    return;
                }
            }
        }

        private void GoingBackOrUpdatingPage()
        {
            MessageBoxResult result = MessageBox.Show("Do you want to play again?", "Back to Authorization", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                AuthorizationPage authpage = new AuthorizationPage();
                NavigationService.Navigate(authpage);
            }
            else
            {
                SafetyNetPage sp = new SafetyNetPage();
                NavigationService.Navigate(sp);
            }
        }


        //methods for questions 
        Tips tips;
        private int  Questions()
        {// choosing a random number for quest 
            // rand quest+ 
            // answers

            Repository rep = new Repository();
            Random rnd = new Random();
            //  int month = rnd.Next(1, 13);
            questionsID = rnd.Next(0, rep.Questions.Count );
             tips = new Tips(questionsID);
            if (questionUsedId.Contains(questionsID))
            {
              //  MessageBox.Show("This question has already been used");
               Questions();
                
            }
            else
            {
                textQuestion.Text = rep.Questions[questionsID].QuestionText.ToString();
                questionUsedId.Add(questionsID);
                buttonAnswerA.Content = "A: " + rep.Questions[questionsID].AnswerA.ToString();
                buttonAnswerB.Content = "B: " + rep.Questions[questionsID].AnswerB.ToString();
                buttonAnswerC.Content = "C: " + rep.Questions[questionsID].AnswerC.ToString();
                buttonAnswerD.Content = "D: " + rep.Questions[questionsID].AnswerD.ToString();

            }
            
            
            return questionsID;
        }

        
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Are you sure, you want to exit?", "Exit the Game", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
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




        // Tips
        private void button50_50_Click(object sender, RoutedEventArgs e)
        {
            button50_50.Visibility = System.Windows.Visibility.Hidden;
            List<string> _tags;

            _tags = tips.TwoVarTip();
            for (int i = 0; i < _tags.Count; i++)
            {
                if (_tags[i] == "A")
                {
                    buttonAnswerA.Content = String.Empty;
                }
                if (_tags[i] == "B")
                {
                    buttonAnswerB.Content = String.Empty;
                }
                if (_tags[i] == "C")
                {
                    buttonAnswerC.Content = String.Empty;
                }
                if (_tags[i] == "D")
                {
                    buttonAnswerD.Content = String.Empty;
                }

            }

        }

        
        private void buttonCall_Click(object sender, RoutedEventArgs e)
        {
            buttonCall.Visibility = System.Windows.Visibility.Hidden;
            MessageBox.Show(tips.CallTip().ToString());
        }

        private void buttobAudience_Click(object sender, RoutedEventArgs e)
        {
            buttobAudience.Visibility = System.Windows.Visibility.Hidden;
            MessageBox.Show(tips.AudienceTip().ToString());
        }
    }
    
}

