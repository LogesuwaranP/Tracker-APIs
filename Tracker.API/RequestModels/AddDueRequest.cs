namespace Tracker.API.RequestModels
{
    public class AddDueRequest
    {
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
    }
}
