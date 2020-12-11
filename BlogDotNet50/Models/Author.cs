using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogDotNet50.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Display { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public string Avatar { get; set; }
        public string Banner { get; set; }

        public List<Post> Posts { get; set; }
    }
}
