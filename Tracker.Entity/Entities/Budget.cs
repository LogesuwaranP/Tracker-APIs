using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class Budget
    {
        [Key]
        public Guid BudgetId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime BudgetDate { get; set; }
        public decimal AllocatedBudget { get; set; }
        public decimal Spent { get; set; }
        public decimal Remaining => AllocatedBudget - Spent;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
