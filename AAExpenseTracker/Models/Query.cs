using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAExpenseTracker.Models
{
    public class Query
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Statement { get; set; }
    }
}