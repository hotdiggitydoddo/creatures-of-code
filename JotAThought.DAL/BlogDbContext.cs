using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using JotAThought.Model;


namespace JotAThought.DAL
{
    public class BlogDbContext : DbContext 
    {
        public BlogDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
