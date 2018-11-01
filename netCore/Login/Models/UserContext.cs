using Microsoft.EntityFrameworkCore;

namespace Login.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext>) : base(options) {}
    }
}