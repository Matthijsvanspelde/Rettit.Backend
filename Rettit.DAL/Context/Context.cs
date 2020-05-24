using Microsoft.EntityFrameworkCore;
using Rettit.Models;

namespace Rettit.DAL
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<SubForum> SubForum { get; set; } 
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Follow> Follow { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) 
        {
            base.OnConfiguring(dbContextOptionsBuilder);
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=rettit.database.windows.net;Initial Catalog=Rettit;User ID=rettitAdmin;Password=Ddba5030df7");
            //dbContextOptionsBuilder.UseSqlServer(@"Server=tcp:rettit.database.windows.net,1433;Initial Catalog=Rettit;Persist Security Info=False;User ID=rettitAdmin;Password=Ddba5030df7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
       
    }
}
