using MillionaireGame.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.UI
{
    public class Tips
    {
        List<int> questionUsedId = new List<int>();
        Repository rep = new Repository();
        string correctLetter; //String to remember correct letter when you use audienceHelp
        //

        public int _questionsID { get; set; }
        public Tips(int questionsID)
        {

            _questionsID = questionsID;

        }
        public Tips()
        {

        }
        public string CallTip()
        {
           
            string msg;
            return msg = "Your friend thinks that correct answer is " + rep.Questions[_questionsID].CorrectAnswer;
        }


        public string AudienceTip()
        {
            List<string> tags = new List<string> { "A", "B", "C", "D" };
            string msg;
            Random myRandom = new Random();

            int correctPercent = myRandom.Next(51, 100);
            string correctAnswerPercent = correctPercent.ToString();

            int anotherPercent1 = myRandom.Next(0, 100 - correctPercent);
            string percent1 = anotherPercent1.ToString();

            int anotherPercent2 = myRandom.Next(0, 100 - correctPercent - anotherPercent1);
            string percent2 = anotherPercent2.ToString();

            string percent3 = (100 - correctPercent - anotherPercent1 - anotherPercent2).ToString();

            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i] == rep.Questions[_questionsID].CorrectAnswer)
                {
                    correctLetter = rep.Questions[_questionsID].CorrectAnswer;
                    tags.RemoveAt(i);
                    
                }
            }
            var anotherLetter1 = tags[0];
            var anotherLetter2 = tags[1];
            var anotherLetter3 = tags[2];
            return msg = correctLetter + " : " + correctPercent + " % \n" + anotherLetter1 + " : " + percent1 + " % \n" + anotherLetter2 + " : " + percent2 + " % \n" + anotherLetter3 + " : " + percent3 + " % \n";
        }

        public  List<string> TwoVarTip()
        {
            List<string> tags = new List<string> { "A", "B", "C", "D" };

            for (int i = 0; i < tags.Count; i++)
            {
                if (tags[i] == rep.Questions[_questionsID].CorrectAnswer)
                {
                    correctLetter = rep.Questions[_questionsID].CorrectAnswer;
                    tags.RemoveAt(i);
                }
            }

            Random myRandom = new Random();
            int tagForRemove = myRandom.Next(0, 2);
            tags.RemoveAt(tagForRemove);

            return tags;
        }

    }
}
