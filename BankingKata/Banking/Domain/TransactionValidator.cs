using System;

namespace Banking.Domain
{
    public static class TransactionValidator
    {
        public static void ValidateAmount(float value, Type type)
        {
            if (value > 0)
            {
                return;
            }

            if (type == typeof(Deposit))
            {
                throw InvalidAmountException.DepositWithNegativeAmount();
            }

            throw InvalidAmountException.WithdrawWithNegativeAmount();
        }

        public static void ValidateInitialDeposit(float initialDeposit)
        {
            if (initialDeposit < 0)
            {
                throw InvalidAmountException.AccountCreationWithNegativeAmount();
            }
        }
    }
}
