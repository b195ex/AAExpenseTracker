using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class ExpenseTag
    {
        public string ID { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}