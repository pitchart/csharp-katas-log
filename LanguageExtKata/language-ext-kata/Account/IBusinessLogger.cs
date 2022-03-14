using System;

namespace language_ext.kata.Account
{
    public interface IBusinessLogger
    {
        void LogSuccessRegister(Guid id);
        void LogFailureRegister(Guid id, Exception exception);
    }
}
