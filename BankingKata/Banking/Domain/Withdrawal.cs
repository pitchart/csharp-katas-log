using System;

namespace Banking.Domain
{

    public class Withdrawal : ITransaction
    {
        public DateTime Date { get; }
        public float Value { get; }
        public float Balance { get; }

        public Withdrawal(DateTime date, float value, float currentBalance)
        {
            TransactionValidator.ValidateAmount(value, typeof(Withdrawal));

            this.Date = date;
            this.Value = value;
            this.Balance = currentBalance - value;
        }
    }

}
