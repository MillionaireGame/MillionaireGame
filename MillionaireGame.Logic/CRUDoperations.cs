using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;

namespace MillionaireGame.Logic
{
    public class CRUDoperations
    {
        public static void AddQuestions(string text, string answerA, string answerB, string answerC, string answerD, string correctans, out string message)
        {
            using (var context = new Context())
            {

                if (context.Questions.FirstOrDefault(q => q.QuestionText == text) == null)
                {
                   
                        context.Questions.Add(new Question { QuestionText = text, AnswerA = answerA, AnswerB = answerB, AnswerC = answerC, AnswerD = answerD, CorrectAnswer = correctans });
                        context.SaveChanges();
                        message = "Question was added!";
               
                }
                else message = "There is the same question in database!";
            }
            
        }

        public static void EditQuestion(IList<Question> questions, out string message)
        {
            message = "";
            
            int k = 0, i = 0;
            while ((k == 0) && (i < questions.Count))
            {
                k = 0;
                if ((string.IsNullOrWhiteSpace(questions[i].QuestionText) == false) && (string.IsNullOrWhiteSpace(questions[i].AnswerA) == false) &&
                    (string.IsNullOrWhiteSpace(questions[i].AnswerB) == false) && (string.IsNullOrWhiteSpace(questions[i].AnswerC) == false) &&
                    (string.IsNullOrWhiteSpace(questions[i].AnswerD) == false) && (string.IsNullOrWhiteSpace(questions[i].CorrectAnswer) == false))
                {
                    if ((questions[i].AnswerA != questions[i].AnswerB && questions[i].AnswerA != questions[i].AnswerC && questions[i].AnswerA != questions[i].AnswerD &&
                    questions[i].AnswerB != questions[i].AnswerC && questions[i].AnswerB != questions[i].AnswerD && questions[i].AnswerC != questions[i].AnswerD))
                    {
                        if (questions[i].CorrectAnswer == "A" || questions[i].CorrectAnswer == "B" || questions[i].CorrectAnswer == "C" || questions[i].CorrectAnswer == "D")
                        {
                            k = 0;
                        }
                        else k = 1;
                    }
                    else k = 2;
                }
                else k = 3;

                i++;
            }
            switch (k)
            {
                case 0:
                    message = "Questions were edited!";
                    break;
                case 1:
                    message = "You have to input letters 'A' , 'B' , 'C' or 'D' in Correct Answer field";
                    break;
                case 2:
                    message = "Answers can't be the same!";
                    break;
                case 3:
                    message = "You have to input all fields!";
                    break;
            }
            if (k == 0)
            {
                 using (var context = new Context())
                 {
                     foreach (var q in questions)
                     {
                         context.Questions.Find(q.ID).QuestionText=q.QuestionText;
                         context.Questions.Find(q.ID).AnswerA = q.AnswerA;
                         context.Questions.Find(q.ID).AnswerB = q.AnswerB;
                         context.Questions.Find(q.ID).AnswerC = q.AnswerC;
                         context.Questions.Find(q.ID).AnswerD = q.AnswerD;
                         context.Questions.Find(q.ID).CorrectAnswer = q.CorrectAnswer;

                     }

                     context.SaveChanges();
                 }
            }
        }

        public static void DeleteQuestion(Question question)
        {
            MessageBoxResult result = MessageBox.Show("Are sure that you want to delete this question?", "Delete question", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    using (var context = new Context())
                    {
                        var p = context.Questions.Find(question.ID);
                        context.Questions.Remove(p);
                        MessageBox.Show("Question was deleted!");
                        context.SaveChanges();

                    }
                }
                catch
                {
                    MessageBox.Show("You haven't chosen the question");
                }
            }
            

        }
    }
}
