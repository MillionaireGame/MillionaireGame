using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
