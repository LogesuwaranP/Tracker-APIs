
using Tracker.Data.Entities;

namespace Tracker.Domain.Service.ExpenseService
{
    public interface IExpenseService
    {
        public IEnumerable<ExpenseResponseDto> GetExpenseList();
        public Expense AddExpense(ExpenseRequestDto expense);
        public Expense GetExpenseById(Guid id);
        public Expense UpdateExpense(Guid id, ExpenseRequestDto expense);
        public Expense DeleteExpense();
    }
}
