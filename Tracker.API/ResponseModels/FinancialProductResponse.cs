namespace Tracker.API.ResponseModels
{
    public class FinancialProductResponse
    {
        public int ProductType { get; set; } = 1; //SIP
        public string ProductName { get; set; } = string.Empty;
        public decimal PrincepleAmout { get; set; }
        public decimal RateOfIntrest { get; set; }
        public decimal TimePeriod { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RecurringPeriod { get; set; }
        public decimal? AmountPlannedToPaidPerPeriod { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PlannedToClose { get; set; }
        public DateTime? EstimatedToClose { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}
