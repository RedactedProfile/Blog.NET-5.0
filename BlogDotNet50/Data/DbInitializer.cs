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
                new Author {Display="Ky.", Title="Webmaster", Bio="The fearless web slinger of this publication. He writes things and doesn't afraid of anything", Avatar="https://pbs.twimg.com/profile_images/1256722569752793089/ixhYhBaq_400x400.jpg", Banner="https://pbs.twimg.com/profile_banners/15066954/1522344196/1500x500"},
                new Author {Display="Steve.", Title="Editor in Chief", Bio="Known as 'The Music Dude', he can often be seen doing music things about music. music.", Avatar="https://scontent.fyvr4-1.fna.fbcdn.net/v/t1.0-9/1918086_583051901871560_6137820596111035053_n.jpg?_nc_cat=105&ccb=2&_nc_sid=09cbfe&_nc_ohc=vTKRzQj_SacAX_gglPp&_nc_ht=scontent.fyvr4-1.fna&oh=1ad00f7b2c669b9500bb0e9f9b859021&oe=5FF81619", Banner="https://scontent.fyvr4-1.fna.fbcdn.net/v/t1.0-9/118484715_1677475029095903_730379601442002005_o.jpg?_nc_cat=104&ccb=2&_nc_sid=e3f864&_nc_ohc=hiO30JZX240AX8KTNPB&_nc_ht=scontent.fyvr4-1.fna&oh=8cfeccd29ffa2496d64ae8c55c340cdf&oe=5FFA8AFF"}
            };
            foreach (Author a in authors)
            {
                context.Authors.Add(a);
            }

            var posts = new Post[]
            {
                new Post { Title="First Post", AuthorID=1, Content="First post test", DateCreated=DateTime.Now.AddDays(-45), DatePublished=DateTime.Now.AddDays(-44), DateUpdated = DateTime.Now },
                new Post { Title="Steve's First Post", AuthorID=2, Content="Oh shit, here's some content", DateCreated=DateTime.Now.AddDays(-35), DatePublished=DateTime.Now.AddDays(-37), DateUpdated = DateTime.Now },
                new Post { Title="Second Post", AuthorID=1, Content="Second post test", DateCreated=DateTime.Now.AddDays(-25), DatePublished=DateTime.Now.AddDays(-6), DateUpdated = DateTime.Now  },
            };
            foreach (Post p in posts)
            {
                context.Posts.Add(p);
            }

            context.SaveChanges();
        }
    }
}
