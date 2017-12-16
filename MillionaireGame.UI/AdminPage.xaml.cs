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
using MillionaireGame.Logic;

namespace MillionaireGame.UI
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Repository _repository = new Repository();

        public AdminPage()
        {
            InitializeComponent();
            dataGridQuestions.ItemsSource = _repository.Questions;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string msg;

            if (string.IsNullOrWhiteSpace(textBoxNewQuestion.Text))
            {
                MessageBox.Show("You have to input a new question");
                textBoxNewQuestion.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAnswerA.Text))
            {
                MessageBox.Show("You have to input answer A");
                textBoxAnswerA.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAnswerB.Text))
            {
                MessageBox.Show("You have to input answer B");
                textBoxAnswerB.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAnswerC.Text))
            {
                MessageBox.Show("You have to input answer C");
                textBoxAnswerC.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAnswerD.Text))
            {
                MessageBox.Show("You have to input answer D");
                textBoxAnswerD.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxCorrectAnswer.Text))
            {
                MessageBox.Show("You have to input a correct answer");
                textBoxCorrectAnswer.Focus();
                return;
            }
            if(textBoxAnswerA.Text==textBoxAnswerB.Text || textBoxAnswerB.Text==textBoxAnswerC.Text || textBoxAnswerC.Text==textBoxAnswerD.Text || 
                textBoxAnswerD.Text==textBoxAnswerA.Text || textBoxAnswerA.Text==textBoxAnswerC.Text || textBoxAnswerB.Text==textBoxAnswerD.Text)
            {
                MessageBox.Show("All answers should not be the same!");
            }
            if (textBoxCorrectAnswer.Text == "A" || textBoxCorrectAnswer.Text == "B" || textBoxCorrectAnswer.Text == "C" || textBoxCorrectAnswer.Text == "D")
            {
                CRUDoperations.AddQuestions(textBoxNewQuestion.Text, textBoxAnswerA.Text, textBoxAnswerB.Text, textBoxAnswerC.Text, textBoxAnswerD.Text, textBoxCorrectAnswer.Text, out msg);
                MessageBox.Show(msg);

                dataGridQuestions.ItemsSource = null;
                dataGridQuestions.ItemsSource = _repository.Questions;
                textBoxNewQuestion.Text = null;
                textBoxAnswerA.Text = null;
                textBoxAnswerB.Text = null;
                textBoxAnswerC.Text = null;
                textBoxAnswerD.Text = null;
                textBoxCorrectAnswer.Text = null;
            }
            else
            {
                MessageBox.Show("You have to input letters 'A' , 'B' , 'C' or 'D' in Correct Answer field");
                textBoxCorrectAnswer.Clear();
                return;
            }
        

        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            CRUDoperations.EditQuestion(dataGridQuestions.ItemsSource as IEnumerable<Question>);
            MessageBox.Show("Quetions were edited!");

            Refresh();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            CRUDoperations.DeleteQuestion(dataGridQuestions.SelectedItem as Question);
            Refresh();
            
            
            
        }

        private void Refresh()
        {
            dataGridQuestions.ItemsSource = null;
            dataGridQuestions.ItemsSource = _repository.Questions;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                AuthorizationPage authpage = new AuthorizationPage();
                NavigationService.Navigate(authpage);
            }
        }
    }
}
