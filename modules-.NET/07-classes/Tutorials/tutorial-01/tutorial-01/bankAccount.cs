using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tutorial_01
{
    public class BankAccount
    {
        public string Number { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
        
        private List<transaction> _transactions = new List<transaction>();

        public BankAccount(string owner)
        {
            this.Owner = owner;
        }
        public void makeDeposit(decimal amount)
        {
            var transaction = new transaction(amount);
            _transactions.Add(transaction);
            
            Balance = amount;

        }
        public string PrintOutTransaction()
        {
            string result = $"History for Transaction {Owner}{Environment.NewLine}";
            _transactions.OrderBy(t => t.Amount);
            _transactions.ForEach(t => result += $"data is {t.Date} : amount is {t.Amount}{Environment.NewLine}");
            return result;
        }
    }
}
