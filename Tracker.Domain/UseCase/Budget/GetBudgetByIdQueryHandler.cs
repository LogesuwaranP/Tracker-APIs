using MediatR;
using Tracker.Data.Entities;
using Tracker.Data.Queries;
using Tracker.Data.Repository;

namespace Tracker.Domain.UseCase.Budget
{
    public class GetBudgetByIdQueryHandler : IRequestHandler<GetBudgetByIdQuery, Data.Entities.Budget>
    {
        private readonly IBudgetRepository _budgetRepository;

        public GetBudgetByIdQueryHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<Data.Entities.Budget> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _budgetRepository.GetByIdAsync(request.BudgetId);
        }
    }
}
