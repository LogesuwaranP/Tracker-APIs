using Microsoft.EntityFrameworkCore;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Data.Repository;
using Tracker.Data.ResponseModels;

namespace Tracker.Domain.Service
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly TrackerContext _context;

        public BudgetRepository(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Budget> GetByIdAsync(Guid id)
        {
            Budget? result = await _context.Budgets.FindAsync(id);
            
            if (result == null)
            {
                throw new ArgumentException($"No budget found with {id}");
            }

            return result;
        }

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            return await _context.Budgets.ToListAsync();
        }

        public async Task AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Budget budget)
        {
            _context.Budgets.Update(budget);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Budget budget)
        {
            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
        }

        public async Task<Budget> GetByCategoryAndDateAsync(Guid categoryId, DateTime budgetDate)
        {
            return await _context.Budgets.SingleOrDefaultAsync(b => b.CategoryId == categoryId && b.BudgetDate.Month == budgetDate.Month && b.BudgetDate.Year == budgetDate.Year);
        }

        public async Task<IEnumerable<Budget>> GetAllBudgetAsync(DateTime budgetDate)
        {
            var result = await _context.Budgets
                            .Where(b => b.BudgetDate.Month == budgetDate.Month && b.BudgetDate.Year == budgetDate.Year)
                            .ToListAsync();

            if (result.Any())
            {
                return result;
            }

            throw new ArgumentException($"No budget found with {budgetDate}");
        }

        public async Task<IEnumerable<BudgetWithCategoryDetails>> GetBudgetsBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _context.Budgets
                            .Where(b => b.BudgetDate >= startDate && b.BudgetDate <= endDate)
                            .Join(
                                _context.Categories,
                                b => b.CategoryId,
                                c => c.Id,
                                (b, c) => new BudgetWithCategoryDetails
                                {
                                    BudgetId = b.BudgetId,
                                    CategoryId = b.CategoryId,
                                    BudgetDate = b.BudgetDate,
                                    AllocatedBudget = b.AllocatedBudget,
                                    Spent = b.Spent,
                                    CategoryTitle = c.CategoryTitle,
                                    Color = c.Color
                                }
                            )
                            .ToListAsync();

            if (result.Any())
            {
                return result;
            }

            throw new ArgumentException($"No budget found with {startDate} - {endDate}");
        }

    }

}
