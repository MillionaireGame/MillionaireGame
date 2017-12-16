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
      
        //started to write logic of the game
        private Question CurrentQuest { get; set; }

        List<int> questionUsedId = new List<int>();
        List<string> prices = new List<string>(new string[] { "100", "200", "500", "1000", "2000", "5000", "10000", "20000", "50000", "100000", "200000", "500000", "1000000","" }); //List for prices
        SafetyNetPage saf = new SafetyNetPage();
        Repository rep = new Repository();
        public string chosenNet { get; set; }
        int correctAnswerCounter = 1;
        public int questionsID { get; set; }
        public string msg { get; set; }
        Tips tips;


      

        // one event for four buttons
        private async void answer_Click(object sender, RoutedEventArgs e)
        {
            
          
            string Tag = (sender as Button).Tag.ToString(); //Getting the Tag of button that has been checked (A,B,C or D)

            if (Tag == rep.Questions[questionsID].CorrectAnswer)
            {
                if (int.Parse(textBlockMoney.Text) == 1000000)
                {
                    msg = "Congratulations! \n You're a millionaire!";
                    chosenNet = "";
                    NavigationService.Navigate(new WinnerPage(msg, chosenNet));
                }
              
                else
                {
                    (sender as Button).Background = System.Windows.Media.Brushes.Green;

                    await MethodToWait();
                    (sender as Button).Background = System.Windows.Media.Brushes.Black;
                    textBlockMoney.Text = prices[correctAnswerCounter].ToString();
                    textBlockMoneyPrev.Text = prices[correctAnswerCounter - 1].ToString();
                    textBlockMoneyNext.Text = prices[correctAnswerCounter + 1].ToString();
                    correctAnswerCounter++;
                    Questions();

                }
            }

            else
            {
                if (int.Parse(textBlockMoney.Text) <= int.Parse(chosenNet))
                {
                    chosenNet = "";
                    msg = "Sorry! \n Your prize is 0";
                    NavigationService.Navigate(new WinnerPage(msg, chosenNet));
                    return;
                }
                else
                {
                    msg = "Congratulations! \n Your prize is";
                    NavigationService.Navigate(new WinnerPage(msg, chosenNet));
                    return;
                }
                

            }
        }
        private async Task MethodToWait()
        {
            await Task.Run(() => { Thread.Sleep(1500); });
        }

        //methods for questions 
        
        private int  Questions()
        {// choosing a random number for quest 
            // rand quest+ 
            // answers
            
            Random rnd = new Random();
            questionsID = rnd.Next(0, rep.Questions.Count );
             tips = new Tips(questionsID);
            if (questionUsedId.Contains(questionsID))
            {
              
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
                NavigationService.Navigate(new AuthorizationPage());
            }
            else
            {
                return;
            }
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

