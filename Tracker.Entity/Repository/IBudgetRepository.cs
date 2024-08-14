using Tracker.Data.Entities;
using Tracker.Data.ResponseModels;

namespace Tracker.Data.Repository
{
    public interface IBudgetRepository : IRepository<Budget, Guid>
    {
        Task<Budget> GetByCategoryAndDateAsync(Guid categoryId, DateTime budgetDate);
        Task<IEnumerable<Budget>> GetAllBudgetAsync(DateTime budgetDate);
        Task<IEnumerable<BudgetWithCategoryDetails>> GetBudgetsBetweenDatesAsync(DateTime startDate, DateTime endDate);

    }
}
