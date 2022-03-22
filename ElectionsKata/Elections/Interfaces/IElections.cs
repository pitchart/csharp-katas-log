using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections.Interfaces
{
    public interface IElections
    {
        void VoteFor(string elector, string candidate, string electorDistrict);

        void AddCandidate(string candidate);

        Dictionary<string, string> Results();
    }
}
