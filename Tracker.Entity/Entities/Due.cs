using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data.Entities
{
    public class Due
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; } = decimal.Zero;
        public decimal? AmountPlannedToPaidPerPeriod { get; set; }
        public DateTime? DueDate { get; set; }
        public string? PaymentFrequency { get; set; } = string.Empty;
        public string? Status { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; } = string.Empty;
        public DateTime? ReminderDate { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}
