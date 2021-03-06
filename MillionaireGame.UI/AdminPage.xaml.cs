﻿using System;
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

            if ((string.IsNullOrWhiteSpace(textBoxNewQuestion.Text)) || (string.IsNullOrWhiteSpace(textBoxAnswerA.Text)) ||
                (string.IsNullOrWhiteSpace(textBoxAnswerB.Text)) || (string.IsNullOrWhiteSpace(textBoxAnswerC.Text)) ||
                (string.IsNullOrWhiteSpace(textBoxAnswerD.Text)) || (string.IsNullOrWhiteSpace(textBoxCorrectAnswer.Text)))
            {
                MessageBox.Show("You have to fill in all the fields!");
            }

            else
            {
                if (textBoxAnswerA.Text == textBoxAnswerB.Text || textBoxAnswerB.Text == textBoxAnswerC.Text || textBoxAnswerC.Text == textBoxAnswerD.Text ||
                    textBoxAnswerD.Text == textBoxAnswerA.Text || textBoxAnswerA.Text == textBoxAnswerC.Text || textBoxAnswerB.Text == textBoxAnswerD.Text)
                {
                    MessageBox.Show(" Answers can't be the same!");
                }
                else
                {
                    if (textBoxCorrectAnswer.Text == "A" || textBoxCorrectAnswer.Text == "B" || textBoxCorrectAnswer.Text == "C" || textBoxCorrectAnswer.Text == "D")
                    {
                        CRUDoperations.AddQuestions(textBoxNewQuestion.Text, textBoxAnswerA.Text, textBoxAnswerB.Text, textBoxAnswerC.Text, textBoxAnswerD.Text, textBoxCorrectAnswer.Text, out msg);
                        MessageBox.Show(msg);

                        Refresh();
                        textBoxNewQuestion.Clear();
                        textBoxAnswerA.Clear();
                        textBoxAnswerB.Clear();
                        textBoxAnswerC.Clear();
                        textBoxAnswerD.Clear();
                        textBoxCorrectAnswer.Clear();
                    }
                    else
                    {
                        MessageBox.Show("You have to input letters 'A' , 'B' , 'C' or 'D' in Correct Answer's field!");
                        textBoxCorrectAnswer.Clear();
                    }
                }
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            CRUDoperations.EditQuestion(dataGridQuestions.ItemsSource as IList<Question>, out string msg);
            MessageBox.Show(msg);

            Refresh();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            CRUDoperations.DeleteQuestion(dataGridQuestions.SelectedItem as Question);

            Refresh();
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

        private void Refresh()
        {
            dataGridQuestions.ItemsSource = null;
            dataGridQuestions.ItemsSource = _repository.Questions;
        }

    }
}
