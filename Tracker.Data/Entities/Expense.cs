using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class Expense
    {
        [Key]
        public Guid ExpenseId { get; set; }
        public Guid ExpenseType { get; set; }
        public string ExpenseTitle { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public string? ExpenseDiscription { get; set; }
        public string? ExpenseImage { get; set; }
        public string? ExpenseTransaction { get; set; }
        public DateTime ExpenseCreatedDate { get; set; }
        public DateTime ExpenseModifiedDate { get;set; }
        public bool? ExpenseHide { get; set;} = false;
    }
}
