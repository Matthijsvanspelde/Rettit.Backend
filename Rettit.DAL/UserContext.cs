using Microsoft.EntityFrameworkCore;
using Rettit.Models;

namespace Rettit.DAL
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
