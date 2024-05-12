using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class ExpenseResponseDto
    {
        [Key]
        public Guid ExpenseId { get; set; }
        public Guid ExpenseType { get; set; }
        public string ExpenseCategory { get; set; } = string.Empty;
        public string ExpenseTitle { get; set; } = string.Empty;
        public int ExpenseAmount { get; set; }
        public string? ExpenseDiscription { get; set; }
        public string? ExpenseTransaction { get; set; }
        public string? ExpenseDate { get; set; }
        public string? ExpenseImage { get; set; }
        public bool ExpenseHide { get; set; } = false;
    }
}
