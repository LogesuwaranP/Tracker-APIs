using MediatR;
using Tracker.Data.Commands;
using Tracker.Data.Repository;

namespace Tracker.Domain.UseCase.Budget
{
    public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand>
    {
        private readonly IBudgetRepository _budgetRepository;

        public UpdateBudgetCommandHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<Unit> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetByIdAsync(request.BudgetId);

            if (budget == null)
            {
                throw new Exception("Budget not found");
            }

            budget.CategoryId = request.CategoryId;
            budget.BudgetDate = request.BudgetDate;
            budget.AllocatedBudget = request.AllocatedBudget;
            budget.Spent = request.Spent;
            budget.ModifiedOn = DateTime.Now;

            await _budgetRepository.UpdateAsync(budget);

            return Unit.Value;
        }
    }
}
