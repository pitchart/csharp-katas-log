using System;

namespace Banking
{
    public class Account
    {
        DateTime Date { set; get; }
        decimal Credit { set; get; }

        public void Deposite(decimal p0, DateTime dateTime)
        {
            Credit += p0;
            Date = dateTime;
        }

        public Statement GetStatement()
        {
            return new Statement();
        }

        public void WithDraw(int p0, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
