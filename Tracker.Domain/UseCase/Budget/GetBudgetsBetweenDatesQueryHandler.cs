using MediatR;
using Tracker.Data.Queries;
using Tracker.Data.Repository;
using Tracker.Data.ResponseModels;

namespace Tracker.Domain.UseCase.Budget
{
    public class GetBudgetsBetweenDatesQueryHandler : IRequestHandler<GetBudgetsBetweenDatesQuery, IEnumerable<BudgetWithCategoryDetails>>
    {
        private readonly IBudgetRepository _budgetRepository;

        public GetBudgetsBetweenDatesQueryHandler(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<IEnumerable<BudgetWithCategoryDetails>> Handle(GetBudgetsBetweenDatesQuery request, CancellationToken cancellationToken)
        {
            return await _budgetRepository.GetBudgetsBetweenDatesAsync(request.StartDate, request.EndDate);
        }
    }
}
