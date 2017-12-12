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
        List<int> prices = new List<int>(new int[] { 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000, 500000, 1000000 }); //List for prices
        SafetyNetPage saf = new SafetyNetPage();
        
        // hints

        //
        int correctAnswerCounter = 1;
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
                if (int.Parse(textBlockMoneyNext.Text) == 1000000) // menshe na odin vopros nado chto to sdelat 
                {
                    MessageBox.Show("You are a millionaire Yohooooooo!!!!");

                    GoingBackOrUpdatingPage();
                }
                //  MessageBox.Show("Correct Answer yohooo");
                else
                {
                    if (correctAnswerCounter != 12)
                    {
                        textBlockMoney.Text = prices[correctAnswerCounter].ToString();
                        textBlockMoneyPrev.Text = prices[correctAnswerCounter - 1].ToString();
                        textBlockMoneyNext.Text = prices[correctAnswerCounter + 1].ToString();
                        correctAnswerCounter++;


                        Questions();
                    }
                    else
                    {
                        textBlockMoney.Text = prices[correctAnswerCounter].ToString();
                        textBlockMoneyPrev.Text = prices[correctAnswerCounter - 1].ToString();
                        textBlockMoneyNext.Text = ("");
                       // Questions();


                    }
                    
                }
               
            }

            else
            {
                if (int.Parse(textBlockMoney.Text)<5000) // suggesting that safety net is 10000
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

        }
    }



    
   
}

