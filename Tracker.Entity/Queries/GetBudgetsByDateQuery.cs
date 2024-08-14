using MediatR;
using Tracker.Data.Entities;

namespace Tracker.Data.Queries
{
    public class GetBudgetsByCategoryAndDateQuery : IRequest<IEnumerable<Budget>>
    {
        public Guid CategoryId { get; set; }
        public DateTime BudgetDate { get; set; }

        public GetBudgetsByCategoryAndDateQuery(Guid categoryId, DateTime budgetDate)
        {
            CategoryId = categoryId;
            BudgetDate = budgetDate;
        }
    }
}
