using Microsoft.EntityFrameworkCore;

namespace Lost.Models
{
    public class TrailContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public TrailContext(DbContextOptions<TrailContext> options) : base(options) { }
        public DbSet<Trail> Trail {get; set;} 
    }
}
