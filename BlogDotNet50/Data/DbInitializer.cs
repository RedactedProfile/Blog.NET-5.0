using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogDotNet50.Models;

namespace BlogDotNet50.Data
{
    public class DbInitializer
    {
        public static void Initalize(BlogContext context)
        {
            context.Database.EnsureCreated();

            if (context.Authors.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author {Display="Ky."},
            };
            foreach (Author a in authors)
            {
                context.Authors.Add(a);
            }

            var posts = new Post[]
            {
                new Post { Title="First Post", AuthorID=1, Content="First post test" },
                new Post { Title="Second Post", AuthorID=1, Content="Second post test" },
            };
            foreach (Post p in posts)
            {
                context.Posts.Add(p);
            }

            context.SaveChanges();
        }
    }
}
