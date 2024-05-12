using Microsoft.AspNetCore.Mvc;

namespace Tracker.API.Controllers
{
    [Route("")]
    [ApiController]
    public class BaseController : Controller
    {

        [HttpGet]
        public Task<string> GetListOfFinancialProduct()
        {
            return Task.FromResult("Server up in running... ");
        }
    }
}
