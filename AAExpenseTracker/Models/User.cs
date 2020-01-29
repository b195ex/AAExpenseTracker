using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class User
    {
        public string UserID { get; set; }

        [StringLength(128)]
        ///<summary>Hex string representation of the salted hash</summary>
        public string SaltedHash { get; set; }

        [StringLength(16)]
        ///<summary>Hex string representation of the salt</summary>
        public string Salt { get; set; }

        public virtual ICollection<Alarm> Alarms { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<FixExpen> FixExpens { get; set; }
        public virtual ICollection<FixIncom> FixIncoms { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}