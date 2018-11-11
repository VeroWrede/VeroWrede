using Microsoft.EntityFrameworkCore;

namespace Weddingplanner.Models
{
    public class WeddingContext : DbContext
    {
        public WeddingContext(DbContextOptions options) : base(options) { }
        // Tables
        public DbSet<Person> People { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}