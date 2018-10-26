using Microsoft.EntityFrameworkCore;

namespace Lost.Models
{
    public class TrailsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public TrailsContext(DbContextOptions<TrailsContext> options) : base(options) { }
        public DbSet<Trail> Trails {get; set;} 
    }
}
