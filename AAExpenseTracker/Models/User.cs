using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<FixExpen> FixExpens { get; set; }
        public virtual ICollection<FixIncom> FixIncoms { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}