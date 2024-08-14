using MediatR;

namespace Tracker.Data.Commands
{
    public class CreateBudgetCommand : IRequest<Guid>
    {
        public Guid CategoryId { get; set; }
        public DateTime BudgetDate { get; set; }
        public decimal AllocatedBudget { get; set; }
        public decimal Spent { get; set; }
    }
}
