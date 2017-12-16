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
                   /* if (correctans == "A" || correctans == "B" || correctans == "C" || correctans == "D")
                    {*/
                        context.Questions.Add(new Question { QuestionText = text, AnswerA = answerA, AnswerB = answerB, AnswerC = answerC, AnswerD = answerD, CorrectAnswer = correctans });

                        context.SaveChanges();

                        message = "Question was added!";
                   /* }
                    else
                    {
                        message = "You have to put the letters 'A' , 'B' , 'C' or 'D' in the field with the correct answers! ";
                    }*/
                    
                }
                else message = "There is the same question in database!";
            }
            
        }

        public static void EditQuestion(IEnumerable<Question> questions)
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

        public static void DeleteQuestion(Question question)
        {
            MessageBoxResult result = MessageBox.Show("Are sure that you want to delete this question?", "Delete question", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                using (var context = new Context())
                {
                    var p = context.Questions.Find(question.ID);
                    context.Questions.Remove(p);
                    MessageBox.Show("Question was deleted!");
                    context.SaveChanges();

                }
            }
            

        }
    }
}
