using Microsoft.EntityFrameworkCore;
using Rettit.Models;

namespace Rettit.DAL
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<SubForum> SubForum { get; set; } 
        public DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) 
        {
            base.OnConfiguring(dbContextOptionsBuilder);
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_rettit;User ID=dbi404906_rettit;Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
       
    }
}
