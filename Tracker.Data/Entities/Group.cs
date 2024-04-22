using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class Group
    {
        [Key]
        public Guid Id { get; set; }
        public string GroupTitle { get; set; } = string.Empty;
        public decimal? Allocated { get; set; }
        public decimal? Spent { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
