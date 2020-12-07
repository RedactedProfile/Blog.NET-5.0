using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet50.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("server=localhost;database=dotnetblog;user=root;password=toor");
        }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Display { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
