using Microsoft.EntityFrameworkCore;

namespace Chefs.Models
{
    public class ChefsNDishesContext : DbContext
    {
        public ChefsNDishesContext(DbContextOptions<ChefsNDishesContext> options) : base(options) {}
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}