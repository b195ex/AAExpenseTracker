using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class BudgetContext : DbContext
    {
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseTag> ExpenseTags { get; set; }
        public DbSet<FixExpen> FixExpens { get; set; }
        public DbSet<FixIncom> FixIncoms { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeTag> IncomeTags { get; set; }
        public DbSet<User> Users { get; set; }
    }
}