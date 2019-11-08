using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount("bebebe bub");
            //Console.WriteLine(bankAccount.Owner);
            bankAccount.makeDeposit(55.5m);
            bankAccount.makeDeposit(-325.5m);

           var printedTransaction = bankAccount.PrintOutTransaction();
            Console.WriteLine(printedTransaction);

        }
    }
}
