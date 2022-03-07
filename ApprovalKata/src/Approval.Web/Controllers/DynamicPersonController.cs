using Approval.Shared.ReadModels;
using Microsoft.AspNetCore.Mvc;

namespace Approval.Web.Controllers
{
    [Route("dynamicPerson")]
    public class DynamicPersonController : Controller
    {
        [HttpGet]
        public ActionResult<DynamicPerson> Index()
        {
            return DataBuilder.Montana();
        }
    }
}
