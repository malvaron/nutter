using Microsoft.EntityFrameworkCore;

namespace nutter.api.Models
{
    public class FoodItemContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }

        public FoodItemContext(DbContextOptions<FoodItemContext> options) : base(options)
        {

        }
    }
}
