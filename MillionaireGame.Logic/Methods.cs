using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Logic
{
    public class Methods
    {
        public static void AddPerson(string login, string password, out string message)
        {
            using (var context = new Context())
            {
                if (context.Persons.FirstOrDefault(q => q.Login == login) == null)
                {
                    context.Persons.Add(new Person { Login=login, Password=password });

                    context.SaveChanges();

                    message = "New player was added!";
                }
                else message = "There is the same login in database!";
            }

        }
    }
}
