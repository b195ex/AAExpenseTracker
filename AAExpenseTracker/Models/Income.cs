using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class Income
    {
        public int ID { get; set; }
        public string Concept { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<IncomeTag> Tags { get; set; }
    }
}