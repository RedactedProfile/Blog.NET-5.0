using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet50.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DatePublished { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
