using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.EntityFrameworkCore;
using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Domain.Repository;

namespace Tracker.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly TrackerContext _dbContext;

        public GroupRepository(TrackerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string CategoryTitle { get; set; }
            public decimal? Allocated { get; set; }
            public decimal? Spent { get; set; }
            public decimal? Remaining { get; set; }
            public List<Expense>? Expense { get; set; }
        }

        public async Task<IEnumerable<object>> GetAllGroups()
        {
            var result =  
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

        public async Task AddGroup(Group category)
        {
            _dbContext.Groups.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Group> GetGroupById(Guid id)
        {
            Group? category = await _dbContext.Groups.FindAsync(id);

            return category!;
        }

        public async Task UpdateGroup(Group category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGroup(Guid id)
        {
            var category = await _dbContext.Groups.FindAsync(id);
            if (category != null)
            {
                _dbContext.Groups.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
