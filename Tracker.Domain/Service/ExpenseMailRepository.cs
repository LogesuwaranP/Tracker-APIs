using Microsoft.EntityFrameworkCore;
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
            var mailPairs = mails.Select(mail => new { mail.GId, mail.ThreadId }).ToList();

            // Retrieve existing GId and ThreadId pairs from the database
            var existingRecords = await _dbContext.ExpenseMails
                .AsNoTracking()
                .Select(em => new { em.GId, em.ThreadId })
                .ToListAsync();

            // Convert the result to a HashSet for efficient lookups
            var existingRecordSet = new HashSet<(string GId, string ThreadId)>(
                existingRecords.Select(em => (em.GId, em.ThreadId)));

            // Filter out mails that already exist in the database
            var newMails = mails
                .Where(mail => !existingRecordSet.Contains((mail.GId, mail.ThreadId)))
                .ToList();

            // Assign new Ids and add new records
            foreach (var mail in newMails)
            {
                mail.Id = Guid.NewGuid();
                _dbContext.ExpenseMails.Add(mail);
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ExpenseMail>> GetAllExpenseMailAsync()
        {
            List<ExpenseMail> mails = await _dbContext.ExpenseMails.ToListAsync();

            if (mails.Any())
            {
                return mails;
            }

            throw new ArgumentException("No mails available");
        }

    }
}
