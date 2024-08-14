using MediatR;

namespace Tracker.Data.Commands
{
    public class UpdateBudgetCommand : IRequest
    {
        public Guid BudgetId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime BudgetDate { get; set; }
        public decimal AllocatedBudget { get; set; }
        public decimal Spent { get; set; }
    }
}
