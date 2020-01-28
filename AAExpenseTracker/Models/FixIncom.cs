using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class FixIncom
    {
        public int ID { get; set; }
        public string Concept { get; set; }
        public float Amount { get; set; }
        public virtual User User { get; set; }

    }
}