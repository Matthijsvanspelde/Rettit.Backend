﻿using Microsoft.EntityFrameworkCore;
using Rettit.Models;
using System.Collections.Generic;

namespace Rettit.DAL
{
    public class UserContext : DbContext, IUserContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) 
        {
            base.OnConfiguring(dbContextOptionsBuilder);
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=mssql.fhict.local;Initial Catalog=dbi404906_rettit;User ID=dbi404906_rettit;Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);

        public User AddUser(User user) 
        {
            User.Add(user);
            SaveChangesAsync();
            return user;
        }

        public IEnumerable<User> GetUser() => User;
    }
}
