using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tracker.Data.Commands;
using Tracker.Data.Queries;

namespace Tracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BudgetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBudgetCommand command)
        {
            var budgetId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = budgetId }, budgetId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateBudgetCommand command)
        {
            if (id != command.BudgetId)
            {
                return BadRequest("Budget ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteBudgetCommand { BudgetId = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var budget = await _mediator.Send(new GetBudgetByIdQuery(id));
            return Ok(budget);
        }

        [HttpGet("by-category-and-date")]
        public async Task<IActionResult> GetByCategoryAndDate([FromQuery] Guid categoryId, [FromQuery] DateTime budgetDate)
        {
            var budget = await _mediator.Send(new GetBudgetsByCategoryAndDateQuery(categoryId, budgetDate));
            return Ok(budget);
        }

        [HttpGet("between-dates")]
        public async Task<IActionResult> GetBudgetsBetweenDates([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var query = new GetBudgetsBetweenDatesQuery(startDate, endDate);
            var budgets = await _mediator.Send(query);
            return Ok(budgets);
        }
    }
}
