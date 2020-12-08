using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDotNet50.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet50.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Post>().ToTable("Posts");
        }
        
    }
}
