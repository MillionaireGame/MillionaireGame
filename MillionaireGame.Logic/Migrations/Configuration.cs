namespace MillionaireGame.Logic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MillionaireGame.Logic.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MillionaireGame.Logic.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Question[] questions =
                {
                new Question { QuestionText = "Who was the first president of USA?", AnswerA = "George Qashington", AnswerB = "Abraham Lincoln", AnswerC = "Theodore Roosevelt", AnswerD = "John F.Kennedy", CorrectAnswer = "A" }, 
                new Question { QuestionText = "2+2?", AnswerA = "2", AnswerB = "4", AnswerC = "3", AnswerD = "0", CorrectAnswer = "B" }, 
                new Question { QuestionText = "How many oceans are there in the World?", AnswerA = "5", AnswerB = "7", AnswerC = "0", AnswerD = "3", CorrectAnswer = "A" }, 
                new Question { QuestionText = "Who did discover America?", AnswerA = "Amerigo Vespucci", AnswerB = "Vasco da Gama", AnswerC = "Christopher Columbus", AnswerD = "George Washington", CorrectAnswer = "B" }, 
                new Question { QuestionText = "What is the capital of Australia?", AnswerA = "Vienna", AnswerB = "Canberra", AnswerC = "Sydney", AnswerD = "Ottawa", CorrectAnswer = "B" }, 
                new Question { QuestionText = "Which of the following countries do not border France?", AnswerA = "Italy", AnswerB = "Germany", AnswerC = "Spain", AnswerD = "Netherlands", CorrectAnswer = "D" }, 
                new Question { QuestionText = "Which is the smallest country, measured by total land area?", AnswerA = "Vatican", AnswerB = "Monaco", AnswerC = "Luxembourg", AnswerD = "Maldives", CorrectAnswer = "A" }, 
                new Question { QuestionText = "How many planets are there in our solar system?", AnswerA = "9", AnswerB = "6", AnswerC = "8", AnswerD = "7", CorrectAnswer = "C" }, 
                };

            context.Questions.AddOrUpdate(p => p.QuestionText, questions);
        }
    }
}
