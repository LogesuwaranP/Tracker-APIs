using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Tracker.API.RequestModels;
using Tracker.API.ResponseModels;
using Tracker.Data.Entities;
using Tracker.Domain.Service.ExpenseFilter;
using Tracker.Domain.Service.ExpenseService;
using Tracker.Domain.Service.FinancialProductService;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {

        private readonly IFinancialProductService _financialProductService;
        private readonly IMapper _mapper;

        public BudgetController(IFinancialProductService financialProductService, IMapper mapper)
        {
            _financialProductService = financialProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public Task<List<FinancialProductResponse>> GetListOfFinancialProduct()
        {
           List<FinancialProduct> data = _financialProductService.GetFinancialProductList();
           List<FinancialProductResponse> financialProductList = _mapper.Map<List<FinancialProductResponse>>(data);

            return Task.FromResult(financialProductList);
        }

        [HttpPost]
        public Task<IActionResult> AddFinancialProduct(GetFinancialProduct req)
        {
            _financialProductService.AddFinancialProduct(
                            _mapper.Map<FinancialProduct>(req)
                        );

            return Task.FromResult<IActionResult>(Ok("Add successfully"));
        }

        [HttpPatch]
        [Route("{id}")]
        public Task<IActionResult> UpdateFinancialProduct([NotNull] Guid id, [FromBody] UpdateFinancialProductDto req)
        {
            _financialProductService.UpdateFinancialProduct(id,
                            _mapper.Map<UpdateFinancialProductDto>(req)
                        );

            return Task.FromResult<IActionResult>(Ok("Updated successfully"));
        }
    }
}