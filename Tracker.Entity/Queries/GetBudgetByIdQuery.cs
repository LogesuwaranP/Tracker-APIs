using MediatR;
using Tracker.Data.Entities;

namespace Tracker.Data.Queries
{
    public class GetBudgetByIdQuery : IRequest<Budget>
    {
        public Guid BudgetId { get; set; }

        public GetBudgetByIdQuery(Guid budgetId)
        {
            BudgetId = budgetId;
        }
    }
}
