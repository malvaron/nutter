using Microsoft.EntityFrameworkCore;

namespace nutter.api.Models
{
    public class FoodItemContext : DbContext
    {
        public DbSet<FoodItem> FoodItem { get; set; }

        public FoodItemContext(DbContextOptions<FoodItemContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItem>();
        }
    }
}
