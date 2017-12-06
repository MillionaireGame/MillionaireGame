using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MillionaireGame.Logic
{
    public class Context: DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public Context(): base("localsql") { }
    }
}
