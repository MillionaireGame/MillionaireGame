using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Logic
{
    public class Repository
    {
        public IList<Question> Questions
        {
            get
            {
                
                    using (var context = new Context())
                    {
                        return context.Questions.ToList();
                    }
                
            }
        }

        public IList<Person> Persons
        {
            get
            {
                using (var context = new Context())
                {
                    return context.Persons.ToList();
                }
            }
        }


    }
}
