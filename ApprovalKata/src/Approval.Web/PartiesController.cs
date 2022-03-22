using Approval.Shared.ReadModels;
using Approval.Shared.SalesForce;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Web
{
    [ApiController]
    [Route("[controller]")]
    public class PartiesController
    {
        private readonly IndividualPartyService _individualPartyService;

        public PartiesController(IndividualPartyService service)
        {
            _individualPartyService = service;
        }
        [HttpGet]
        public IEnumerable<IndividualParty> GetIndividualParties()
        { 
            return _individualPartyService.GetIndividualParties();
        }
    }
}
