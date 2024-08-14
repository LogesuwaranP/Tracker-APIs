using MediatR;
using Tracker.Data.Commands;
using Tracker.Data.Entities;
using Tracker.Data.Repository;

namespace Tracker.Domain.UseCase.Budget
{
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, Guid>
    {
        private readonly IBudgetRepository _budgetRepository;

        public CreateBudgetCommandHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<Guid> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = new Data.Entities.Budget
            {
                BudgetId = Guid.NewGuid(),
                CategoryId = request.CategoryId,
                BudgetDate = request.BudgetDate,
                AllocatedBudget = request.AllocatedBudget,
                Spent = request.Spent,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };

            await _budgetRepository.AddAsync(budget);
            return budget.BudgetId;
        }
    }
}
