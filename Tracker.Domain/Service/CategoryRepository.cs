using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

namespace Tracker.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TrackerContext _dbContext;

         public class Result
        {
            public Guid Id { get; set; }
            public string CategoryTitle { get; set; }
            public decimal? Allocated { get; set; }
            public decimal? Spent { get; set; }
            public decimal? Remaining { get; set; }
            public List<Expense>? Expense { get; set; }
        }
        
        public CategoryRepository(TrackerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            Category? category = await _dbContext.Categories.FindAsync(id);

            return category!;
        }

        public async Task AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<object>> GetAllData()
        {

            List<Result> result =
            _dbContext.Categories
                .GroupJoin(
                    _dbContext.Expense,
                    category => category.Id,
                    expense => expense.ExpenseType,
                    (category, expenseGroup) => new Result
                    {
                        Id = category.Id,
                        CategoryTitle = category.CategoryTitle,
                        Allocated = category.Allocated,
                        Spent = category.Spent,
                        Remaining = category.Remaining,
                        Expense = expenseGroup.ToList()
                    })
                .ToList();

            return result.Cast<object>();
        }
    }
}
