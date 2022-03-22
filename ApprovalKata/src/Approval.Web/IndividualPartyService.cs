using Approval.Shared.ReadModels;
using Approval.Shared.SalesForce;
using AutoMapper;

namespace Approval.Web
{
    public class IndividualPartyService 
    {
        private readonly IMapper _mapper;

        public IndividualPartyService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<IndividualParty> GetIndividualParties()
        {
            IList<PersonAccount> personAccounts = new List<PersonAccount>();
            personAccounts.Add(DataBuilder.AlCapone());
            personAccounts.Add(DataBuilder.Mesrine());
            return _mapper.Map<List<IndividualParty>>(personAccounts);
        }
    }
}
