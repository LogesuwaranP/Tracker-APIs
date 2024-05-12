using Microsoft.EntityFrameworkCore;
using Tracker.Data.Entities;

namespace Tracker.Data.Context
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options) { }
        
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Due> Dues { get; set; }
    }
}
