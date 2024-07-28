using System.ComponentModel.DataAnnotations;

namespace Tracker.Data.Entities
{
    public class ExpenseMail
    {
        [Key]
        public Guid Id { get; set; }
        public string GId { get; set; } = string.Empty;  //id
        public string ThreadId { get; set; } = string.Empty; //threadId
        public string Gmail { get; set; } = string.Empty; //hardcoded
        public string Message { get; set; } = string.Empty; //snippet
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}