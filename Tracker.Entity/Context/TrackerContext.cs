using Microsoft.EntityFrameworkCore;
using Tracker.Data.Entities;

namespace Tracker.Data.Context
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options) { }
        
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Due> Dues { get; set; }
        public DbSet<ExpenseMail> ExpenseMails { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Budget>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(b => b.CategoryId);
        }

    }
}
