using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string CategoryTitle { get; set; } = string.Empty;
        public decimal? Allocated { get; set; }
        public decimal? Spent { get; set; }
        public decimal? Remaining { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}
