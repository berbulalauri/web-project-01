using System;
using System.Collections.Generic;
using System.Text;

namespace tutorial_01
{
    public class transaction
    {
        public decimal Amount { get; set;}
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public transaction(decimal amount, string note = "")
        {
            this.Amount = amount;
            Date = DateTime.Now;
        }
    }
}
