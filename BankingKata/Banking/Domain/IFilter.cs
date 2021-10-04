using System.Collections.Generic;

namespace Banking.Domain
{

    public interface IFilter
    {
        IList<ITransaction> Filter(IList<ITransaction> transactions);
    }

}
