using Tracker.Data.Context;
using Tracker.Data.Entities;
using Tracker.Data.Repository;

namespace Tracker.Domain.Service
{
    public class ExpenseMailRepository : IExpenseMailRepository
    {
        private readonly TrackerContext _dbContext;

        public ExpenseMailRepository(TrackerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddExpenseAsync(List<ExpenseMail> mails)
        {
            foreach (ExpenseMail mail in mails)
            {
                mail.Id = Guid.NewGuid();
                _dbContext.ExpenseMails.Add(mail);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
