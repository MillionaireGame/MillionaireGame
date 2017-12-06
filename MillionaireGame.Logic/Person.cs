using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Logic
{
   public class Person
    {
        private string _login, _password;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Person(string login, string password)
        {
            _password = password;
            _login = login;
        }
    }
}
