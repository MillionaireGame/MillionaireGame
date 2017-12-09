using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Logic
{
    [Table("Persons")]
   public class Person
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

      
    }
}
