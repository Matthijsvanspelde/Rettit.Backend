using Microsoft.EntityFrameworkCore;
using Rettit.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rettit.DAL
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public User AddUser(User user) 
        {
            User.Add(user);
            SaveChangesAsync();
            return user;
        }

        public IEnumerable<User> GetUser()
        {
            return User;
        }
    }
}
