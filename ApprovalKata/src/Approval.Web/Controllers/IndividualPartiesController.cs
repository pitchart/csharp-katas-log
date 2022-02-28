using Approval.Shared.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Web.Controllers
{
    [Route("individualParties")]
    public class IndividualPartiesController : Controller
    {
        [HttpGet]
        public ActionResult<IndividualParty[]> GetIndividualParties()
        {
            return Array.Empty<IndividualParty>();
        }
    }
}
