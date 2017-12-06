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
        }
    }
}
