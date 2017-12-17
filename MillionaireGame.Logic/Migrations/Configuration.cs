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
                new Question { QuestionText = "Who was the first president of USA?", AnswerA = "George Washington", AnswerB = "Abraham Lincoln", AnswerC = "Theodore Roosevelt", AnswerD = "John F.Kennedy", CorrectAnswer = "A" }, 
                new Question { QuestionText = "245*16?", AnswerA = "0", AnswerB = "3920", AnswerC = "4126", AnswerD = "3921", CorrectAnswer = "B" }, 
                new Question { QuestionText = "How many oceans are there in the World?", AnswerA = "5", AnswerB = "7", AnswerC = "0", AnswerD = "3", CorrectAnswer = "A" }, 
                new Question { QuestionText = "Who did discover America?", AnswerA = "Amerigo Vespucci", AnswerB = "Vasco da Gama", AnswerC = "Christopher Columbus", AnswerD = "George Washington", CorrectAnswer = "C" }, 
                new Question { QuestionText = "What is the capital of Australia?", AnswerA = "Vienna", AnswerB = "Canberra", AnswerC = "Sydney", AnswerD = "Ottawa", CorrectAnswer = "B" }, 
                new Question { QuestionText = "Which of the following countries do not border France?", AnswerA = "Italy", AnswerB = "Germany", AnswerC = "Spain", AnswerD = "Netherlands", CorrectAnswer = "D" }, 
                new Question { QuestionText = "Which is the smallest country, measured by total land area?", AnswerA = "Vatican", AnswerB = "Monaco", AnswerC = "Luxembourg", AnswerD = "Maldives", CorrectAnswer = "A" }, 
                new Question { QuestionText = "How many planets are there in our solar system?", AnswerA = "9", AnswerB = "6", AnswerC = "8", AnswerD = "7", CorrectAnswer = "C" },
                new Question { QuestionText = "The rainbow does not consist of :", AnswerA = "Red Color", AnswerB = "Pink Color", AnswerC = "Orange Color", AnswerD = "Yellow Color", CorrectAnswer = "B" },
                new Question { QuestionText = "Who is a dolphin?", AnswerA = "Mammal", AnswerB = "Fish", AnswerC = "Bird", AnswerD = "Insect", CorrectAnswer = "A" },
                new Question { QuestionText = "Who is the author of 'War and Peace' ?", AnswerA = "Fyodor Dostoyevsky", AnswerB = "Anton Chekhov", AnswerC = "Leo Tolstoy", AnswerD = "Nikolai Gogol", CorrectAnswer = "C" },
                new Question { QuestionText = "Who was the first programmer in the world?", AnswerA = "Mark Zuckerberg", AnswerB = "Steve Jobs", AnswerC = "Bill Gates", AnswerD = "Ada Lovelace", CorrectAnswer = "D" },
                new Question { QuestionText = "Which body part stays the same size from when we are born until we die?", AnswerA = "Liver", AnswerB = "Hand", AnswerC = "Heart", AnswerD = "Eyeball", CorrectAnswer = "D" },
                new Question { QuestionText = "Which country has the largest population?", AnswerA = "Russia", AnswerB = "France", AnswerC = "China", AnswerD = "India", CorrectAnswer = "C" },
                new Question { QuestionText = "What is the only mammal that can't jump?", AnswerA = "Elephants", AnswerB = "Foxes", AnswerC = "Hamster", AnswerD = "Giraffes", CorrectAnswer = "A" },
                new Question { QuestionText = "Who invented the electric chair?", AnswerA = "Carpenter", AnswerB = "Lawyer", AnswerC = "Dentist", AnswerD = "Programmer", CorrectAnswer = "C" },
                new Question { QuestionText = "What is the only food that doesn't spoil?", AnswerA = "Honey", AnswerB = "Jam", AnswerC = "Vinegar", AnswerD = "Egg", CorrectAnswer = "A" },
                new Question { QuestionText = "Which Scandinavian country is not a part of the European Union?", AnswerA = "Sweden", AnswerB = "Norway", AnswerC = "Denmark", AnswerD = "Iceland", CorrectAnswer = "B" },
                new Question { QuestionText = "What is the most common name in the world?", AnswerA = "John", AnswerB = "Ivan", AnswerC = "Mark", AnswerD = "Muhammed", CorrectAnswer = "D" },
                new Question { QuestionText = "What percentage of people are left-handed?", AnswerA = "13%", AnswerB = "40%", AnswerC = "66%", AnswerD = "3%", CorrectAnswer = "A" },
                new Question { QuestionText = "What was the first novel written on a typewriter?", AnswerA = "To Kill A Mockingbird", AnswerB = "Tom Sawyer", AnswerC = "Anna Karenina", AnswerD = "Robinson Crusoe", CorrectAnswer = "B" },
                new Question { QuestionText = "What is the longest river in the world?", AnswerA = "The Nile", AnswerB = "The Don", AnswerC = "The Volga", AnswerD = "The Amazon", CorrectAnswer = "A" },
                new Question { QuestionText = "Which insect shorted out an early supercomputer and inspired the term 'computer bug'?", AnswerA = "Moth", AnswerB = "Roach", AnswerC = "Fly", AnswerD = "Japanese beetle", CorrectAnswer = "A" },
                new Question { QuestionText = "Which of the following men does not have a chemical element named for him?", AnswerA = "Albert Einstein", AnswerB = "Niels Bohr", AnswerC = "Isaac Newton", AnswerD = "Enrico Fermi", CorrectAnswer = "C" },
                
               

            };

            context.Questions.AddOrUpdate(p => p.QuestionText, questions);
        }
    }
}
