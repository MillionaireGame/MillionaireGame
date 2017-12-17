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
                        context.Persons.Add(new Person { Login = login, Password = password });

                        context.SaveChanges();

                        message = "New player was added!";
                    }
                    else message = "There is the same login in database!";
                }
           
        }

        public static void CheckPlayer(string login, string password, out string message)
        {
            message = "";
            Repository r = new Repository();
            int k = 0, i=0;
            while ((k==0)&&(i<r.Persons.Count))
            {
                k = 0;
                if (r.Persons[i].Login == login)
                {
                    if (r.Persons[i].Password == password)
                     k = 1; 

                    else  k = 2; 
                }
                
                i++;
            }
            switch (k)
            {
                case 1: message = "";
                    break;
                case 2: message = "The wrong password. Try again!";
                    break;
                case 0: message = "You should register!";
                    break;
            }
           
        }
    }
}
