using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public enum AlarmType
    {
        Percentage, Amount
    }
    public class Alarm
    {
        public int ID { get; set; }
        public AlarmType AlarmType { get; set; }
        public float Amount { get; set; }
        public string Message { get; set; }
        public bool Active { get; set; }
        public virtual User User { get; set; }
        public virtual ExpenseTag Tag { get; set; }
    }
}