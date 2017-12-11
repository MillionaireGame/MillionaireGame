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
            MessageBox.Show("Question was deleted!");
            
            
        }

        private void Refresh()
        {
            dataGridQuestions.ItemsSource = null;
            dataGridQuestions.ItemsSource = _repository.Questions;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationPage authpage = new AuthorizationPage();
            NavigationService.Navigate(authpage);
        }
    }
}
