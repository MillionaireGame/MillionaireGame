﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionaireGame.Logic
{
    public class Repository
    {
        public IEnumerable<Question> Questions
        {
            get
            {
                using (var context = new Context())
                {
                    return context.Questions.ToList();
                }
            }
        }

    }
}