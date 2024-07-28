using Microsoft.AspNetCore.Mvc;
using Tracker.Data.Entities;

namespace Tracker.Data.Repository
{
    public interface IExpenseMailRepository
    {
        Task AddExpenseAsync(List<ExpenseMail> mails);
    }
}
