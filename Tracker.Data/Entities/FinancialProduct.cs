using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class FinancialProduct
    {
        [Key]
        public Guid FinancialProductID { get; set; }
        // e.g., SIP, Loan, EMI, etc.
        public int ProductType { get; set; } = 1; //SIP
        public string ProductName { get; set; } = string.Empty;
        public decimal PrincepleAmout { get; set; }
        public decimal RateOfIntrest { get; set; }
        public decimal TimePeriod { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RecurringPeriod { get; set; } = 1;
        public decimal? AmountPlannedToPaidPerPeriod { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PlannedToClose { get; set; }
        public DateTime? EstimatedToClose { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; }

    }
}
