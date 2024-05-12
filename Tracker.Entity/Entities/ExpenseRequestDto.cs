namespace Tracker.Data.Entities
{
    public class ExpenseRequestDto
    {
        public Guid ExpenseType { get; set; }
        public string ExpenseTitle { get; set; } = string.Empty;
        public decimal ExpenseAmount { get; set; }
        public string? ExpenseDiscription { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public string? ExpenseImage { get; set; }
        public string? ExpenseTransaction { get; set; }
        public bool? ExpenseHide { get; set; } = false;
    }
}
