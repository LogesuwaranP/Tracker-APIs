using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.API.ResponseModels;
using Tracker.Data.Entities;
using Tracker.Domain.Service.FinancialProductService;

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
