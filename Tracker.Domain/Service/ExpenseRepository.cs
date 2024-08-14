using Microsoft.EntityFrameworkCore;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Data.Repository;

namespace Tracker.Domain.Service
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly TrackerContext _context;

        public ExpenseRepository(TrackerContext context)
        {
            _context = context;
        }

        public async Task<Expense> GetByIdAsync(Guid id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetByCategoryAndDateRangeAsync(Guid categoryId, DateTime budgetDate)
        {
            var startDate = new DateTime(budgetDate.Year, budgetDate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return await _context.Expenses
                .Where(e => e.CategoryId == categoryId && e.ExpenseDate >= startDate && e.ExpenseDate <= endDate)
                .ToListAsync();
        }

        public async Task AddAsync(Expense expense)
        {
            expense.ExpenseCreatedDate = DateTime.Now;
            expense.ExpenseModifiedDate = DateTime.Now;
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expense expense)
        {
            expense.ExpenseModifiedDate = DateTime.Now;
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expense expense)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }

}
