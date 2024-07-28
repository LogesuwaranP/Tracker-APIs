using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;
using Tracker.Domain.Service.ExpenseFilter;
using Tracker.Domain.Service.ExpenseService;
using Tracker.Infrastructure.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IConfiguration _configuration;
        private readonly IExpenseFilter _expenseFilter;

        private readonly IMediator _mediator;

        public ExpenseController(IExpenseService expenseService, IConfiguration configuration, IExpenseFilter expenseFilter, ICategoryRepository categoryRepository, IMediator mediator)
        {
            _expenseService = expenseService;
            _categoryRepository = categoryRepository;
            _configuration = configuration;
            _expenseFilter = expenseFilter;
            _mediator = mediator;
        }
        // GET: api/<ExpenseController>
        [HttpGet]
        // [Authorize]
        [ResponseCache(Duration = 15)]
        public async Task<IActionResult> GetAll()
        {
            var expenseList = _expenseService.GetExpenseList();

            if (expenseList != null)
            {
                return Ok(expenseList);
            }
            else
            {
                return NotFound("No Expense Found");
            }
           
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var expense = _expenseService.GetExpenseById(id);
            if (expense != null)
            {
                return Ok(expense);
            }
            else
            {
                return NotFound("No such Expense Id");
            }
        }

        ///{startDate}/{endDate}
        //[HttpGet]
        //[Route("start={startDate:datetime}&end={endDate:datetime}")]
        //public async Task<IActionResult> GetByDates(DateTime startDate, DateTime endDate)
        //{
        //    var expenseList = _expenseFilter.FilterDates(startDate, endDate);

        //    if (expenseList != null)
        //    {
        //        return Ok(expenseList);
        //    }
        //    else
        //    {
        //        return NotFound("No Expense Found");
        //    }
        //}

        //[HttpGet]
        //[Route("{month}")]
        //public async Task<IActionResult> GetByMonth(int month)
        //{
        //    var expenseList = _expenseFilter.FilterByMonth(month);

        //    if (expenseList != null)
        //    {
        //        return Ok(expenseList);
        //    }
        //    else
        //    {
        //        return NotFound("No Expense Found");
        //    }
        //}

        //[HttpGet]
        //[Route("{type}")]
        //public async Task<IActionResult> GetByType(Guid type)
        //{
        //    var expenseList = _expenseFilter.FilterByType(type);

        //    if (expenseList != null)
        //    {
        //        return Ok(expenseList);
        //    }
        //    else
        //    {
        //        return NotFound("No Expense Found");
        //    }
        //}

        //[HttpGet]
        //[Route("groupbytype")]
        //public async Task<IActionResult> Groupbytype()
        //{
        //    var expenseList = _expenseFilter.Groupbytype();

        //    if (expenseList != null)
        //    {
        //        return Ok(expenseList);
        //    }
        //    else
        //    {
        //        return NotFound("No Expense Found");
        //    }
        //}



        // POST api/<ExpenseController>

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] ExpenseRequestDto expense)
        {
            var result = _expenseService.AddExpense(expense);
            if (result != null)
            {
                await _categoryRepository.UpdateSpent(expense.ExpenseType, expense.ExpenseAmount);
            }
            return Ok(result);
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ExpenseRequestDto expense)
        {
            var result = _expenseService.UpdateExpense(id, expense);
            return Ok(result);
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("/withcategory")]
        public async Task<IActionResult> GetExpenseWithCategoryType()
        {
            var expenseList = await _expenseService.GetExpensesWithCategoryAsync();

            if (expenseList != null)
            {
                return Ok(expenseList);
            }
            else
            {
                return NotFound("No Expense Found");
            }
        }
    }
}
