using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Commands;
using Tracker.Data.Repository;

namespace Tracker.Domain.UseCase.Budget
{
    public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand>
    {
        private readonly IBudgetRepository _budgetRepository;

        public DeleteBudgetCommandHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<Unit> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            var budget = await _budgetRepository.GetByIdAsync(request.BudgetId);

            if (budget == null)
            {
                throw new Exception("Budget not found");
            }

            await _budgetRepository.DeleteAsync(budget);

            return Unit.Value;
        }
    }
}
