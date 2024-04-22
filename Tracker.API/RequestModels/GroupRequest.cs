namespace Tracker.API.RequestModels
{
    public class GroupRequest
    {
        public string GroupTitle { get; set; } = string.Empty;
        public decimal? Allocated { get; set; }
        public decimal? Spent { get; set; }
    }
}
