using language_ext.kata.Account;
using System;

namespace language_ext.kata.tests
{
    internal class TestLogger : IBusinessLogger
    {
        public void LogSuccessRegister(Guid id)
        {
            throw new NotImplementedException();
        }

        public void LogFailureRegister(Guid id, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
