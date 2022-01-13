using System;

namespace Banking
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public decimal Balance { get; set; }
    }
}
