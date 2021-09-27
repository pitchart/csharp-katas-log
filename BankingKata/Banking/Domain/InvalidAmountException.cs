using System;

namespace Banking.Domain
{

    public class InvalidAmountException : ArgumentException
    {
        public InvalidAmountException(string message) : base(message)
        {
            
        }
        public static Exception AccountCreationWithNegativeAmount()
        {
            return new InvalidAmountException("Cannot create an account with negative amount");
        }

        public static Exception WithdrawWithNegativeAmount()
        {
            return new InvalidAmountException("Cannot withdraw with negative amount");
        }
    }
}
