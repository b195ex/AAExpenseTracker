using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class IncomeTag
    {
        public string ID { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}