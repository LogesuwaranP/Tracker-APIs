using MediatR;
using Tracker.Data.Queries;
using Tracker.Data.Repository;

namespace Tracker.Domain.UseCase.Budget
{
    public class GetBudgetsByCategoryAndDateQueryHandler : IRequestHandler<GetBudgetsByCategoryAndDateQuery, IEnumerable<Data.Entities.Budget>>
    {
        private readonly IBudgetRepository _budgetRepository;

        public GetBudgetsByCategoryAndDateQueryHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<IEnumerable<Data.Entities.Budget>> Handle(GetBudgetsByCategoryAndDateQuery request, CancellationToken cancellationToken)
        {            
            return await _budgetRepository.GetAllBudgetAsync(request.BudgetDate);
        }
    }
}
