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
        public GamePage()
        {
            InitializeComponent();
            Questions();
          //  string k = saf.ToAnotherWin();

        }

        //started to write logic of the game
        private Question CurrentQuest { get; set; }

        List<int> questionUsedId = new List<int>();
        List<string> prices = new List<string>(new string[] { "100", "200", "500", "1000", "2000", "5000", "10000", "20000", "50000", "100000", "200000", "500000", "1000000","" }); //List for prices
        SafetyNetPage saf = new SafetyNetPage();
        Repository rep = new Repository();
        // hints

        //
        int correctAnswerCounter = 1;
        int questionsID;
       
        string correctLetter; //String to remember correct letter when you use audienceHelp
        string callAnswer; //String for correct answer when you use callHelp

        
        // one event for four buttons
        private void answer_Click(object sender, RoutedEventArgs e)
        {
            
            //  questionUsedId.Add(rep.Questions[questionsID])
            string Tag = (sender as Button).Tag.ToString(); //Getting the Tag of button that has been checked (A,B,C or D)

            if (Tag == rep.Questions[questionsID].CorrectAnswer)
            {
                if (int.Parse(textBlockMoney.Text) == 1000000)
                {
                    MessageBox.Show("You are a millionaire Yohooooooo!!!!");

                    GoingBackOrUpdatingPage();
                }
                //  MessageBox.Show("Correct Answer yohooo");
                else
                {
                    //if (correctAnswerCounter != 12)
                    {
                        textBlockMoney.Text = prices[correctAnswerCounter].ToString();
                        textBlockMoneyPrev.Text = prices[correctAnswerCounter - 1].ToString();
                        textBlockMoneyNext.Text = prices[correctAnswerCounter + 1].ToString();
                        correctAnswerCounter++;

                        Questions();
                    }
                }
            }

            else
            {
                if (int.Parse(textBlockMoney.Text) < 5000) // suggesting that safety net is 10000
                {
                    MessageBox.Show("Sorry but your prize is NULL");
                    GoingBackOrUpdatingPage();
                }
                else
                {
                    MessageBox.Show("You have already reached your guaranteed prize. You have won 5000 Lucky u !!!");
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
                GamePage gp = new GamePage();
                NavigationService.Navigate(gp);
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
                buttonAnswerA.Content = "A: " + rep.Questions[questionsID].AnswerA.ToString();
                buttonAnswerB.Content = "B: " + rep.Questions[questionsID].AnswerB.ToString();
                buttonAnswerC.Content = "C: " + rep.Questions[questionsID].AnswerC.ToString();
                buttonAnswerD.Content = "D: " + rep.Questions[questionsID].AnswerD.ToString();

            }
            // randomCommand = "SELECT top 1 * from QuestionTable ORDER BY Rnd(-(100000*ID)*Time()) ";
            
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

        private void button50_50_Click(object sender, RoutedEventArgs e)
        {
            button50_50.Visibility = System.Windows.Visibility.Hidden;
            List<string> tags = new List<string> { "A", "B", "C", "D" };

            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i] == rep.Questions[questionsID].CorrectAnswer)
                {
                    correctLetter = rep.Questions[questionsID].CorrectAnswer;
                    tags.RemoveAt(i);
                }
            }

            Random myRandom = new Random();
            int tagForRemove = myRandom.Next(0, 2);
            tags.RemoveAt(tagForRemove);

            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i] == "A")
                {
                    buttonAnswerA.Content = String.Empty;
                }
                if (tags[i]=="B")
                {
                    buttonAnswerB.Content = String.Empty;
                }
                if (tags[i] == "C")
                {
                    buttonAnswerC.Content = String.Empty;
                }
                if (tags[i] == "D")
                {
                    buttonAnswerD.Content = String.Empty;
                }

            }

        }

        private void buttonCall_Click(object sender, RoutedEventArgs e)
        {
            buttonCall.Visibility = System.Windows.Visibility.Hidden;

            MessageBox.Show("Your friend thinks that correct answer is " + rep.Questions[questionsID].CorrectAnswer);
        }

        private void buttobAudience_Click(object sender, RoutedEventArgs e)
        {
            buttobAudience.Visibility = System.Windows.Visibility.Hidden;

            List<string> tags = new List<string> { "A", "B", "C", "D" };

            Random myRandom = new Random();

            int correctPercent = myRandom.Next(51, 100); 
            string correctAnswerPercent = correctPercent.ToString();

            int anotherPercent1 = myRandom.Next(0, 100 - correctPercent);
            string percent1 = anotherPercent1.ToString();

            int anotherPercent2 = myRandom.Next(0, 100 - correctPercent - anotherPercent1);
            string percent2 = anotherPercent2.ToString();

            string percent3 = (100 - correctPercent - anotherPercent1 - anotherPercent2).ToString();

            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i] == rep.Questions[questionsID].CorrectAnswer)
                {
                    correctLetter = rep.Questions[questionsID].CorrectAnswer;
                    tags.RemoveAt(i);
                }
            }
            var anotherLetter1 = tags[0];
            var anotherLetter2 = tags[1];
            var anotherLetter3 = tags[2];

            MessageBox.Show(correctLetter + " : " + correctPercent + "% \n" + anotherLetter1 + " : " + percent1 + "% \n" + anotherLetter2 + " : " + percent2 + "% \n" + anotherLetter3 + " : " + percent3 + "% \n");
        }
    }
    
}

