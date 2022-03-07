using Approval.Shared.ReadModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Web.Controllers
{
    [Route("individualParties")]
    public class IndividualPartiesController : Controller
    {
        private IMapper _mapper;

        public IndividualPartiesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IndividualParty[]> GetIndividualParties()
        {
            return new IndividualParty[]
            {
                _mapper.Map<IndividualParty>(DataBuilder.AlCapone()),
                _mapper.Map<IndividualParty>(DataBuilder.Mesrine())
            };
        }
    }
}
