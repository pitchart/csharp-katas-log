using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace language_ext.kata.Account
{
    public record Context(string accountId, User user, string token, string url);
}
