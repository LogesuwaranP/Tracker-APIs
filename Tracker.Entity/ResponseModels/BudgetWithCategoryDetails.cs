namespace Tracker.Data.ResponseModels
{
    public class BudgetWithCategoryDetails
    {
        public Guid BudgetId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime BudgetDate { get; set; }
        public decimal AllocatedBudget { get; set; }
        public decimal Spent { get; set; }
        public decimal Remaining => AllocatedBudget - Spent;
        public string CategoryTitle { get; set; }
        public string Color { get; set; }
    }
}
