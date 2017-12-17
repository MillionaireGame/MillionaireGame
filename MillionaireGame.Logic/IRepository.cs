using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Logic
{
    interface IRepository
    {
        IList<Question> Questions { get; }
        IList<Person> Persons { get; }
    }
}
