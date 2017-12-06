using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Logic
{
   public class Person
    {
        public int ID;
        public string Login { get; set; }
        public string Password { get; set; }

        

        public Person(string login, string password)
        {
            Password = password;
            Login = login;
        }
    }
}
