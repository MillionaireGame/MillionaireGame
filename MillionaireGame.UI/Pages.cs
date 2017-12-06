using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.UI
{
   static class Pages
    {
        private static AdminPage _adminPage = new AdminPage();
        public static AdminPage AdminPage
        {
            get
            {
                return _adminPage;
            }
        }

        private static AuthorizationPage _authPage = new AuthorizationPage();
        public static AuthorizationPage AuthorizationPage
        {
            get
            {
                return _authPage;
            }
        }

        private static RegistrationPage _regPage = new RegistrationPage();
        public static RegistrationPage RegistrationPage
        {
            get
            {
                return _regPage;
            }
        }

        private static GamePage _gamePage = new GamePage();
        public static GamePage GamePage
        {
            get
            {
                return _gamePage;
            }
        }
    }
}
