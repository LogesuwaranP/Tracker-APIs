namespace Tracker.API.RequestModels
{
    public class CategoryRequest
    {
        public string CategoryTitle { get; set; } = string.Empty;
        public decimal? Allocated { get; set; }
        public decimal? Spent { get; set; }
    }
}
