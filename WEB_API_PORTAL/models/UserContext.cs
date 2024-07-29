using Microsoft.EntityFrameworkCore;

namespace WEB_API_PORTAL.models
{
    public class UserContext : DbContext

    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins {  get; set; }





    }
}
