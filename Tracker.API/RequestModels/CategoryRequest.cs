namespace Tracker.API.RequestModels
{
    public class CategoryRequest
    {
        public string CategoryTitle { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Allocated { get; set; }
        public decimal? Spent { get; set; }
        public string? ImageUrl { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
