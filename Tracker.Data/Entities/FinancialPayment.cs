using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class FinancialPayment
    {
            [Key]
            public Guid PaymentId { get; set; }
            public Guid ProductId { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; } = DateTime.Now;
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public DateTime? ModifiedDate { get; set; }
    }
}
