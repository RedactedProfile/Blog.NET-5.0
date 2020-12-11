using BlogDotNet50.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogDotNet50.Data;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace BlogDotNet50.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("", Name = "Home")]
        public IActionResult Index()
        {
            var posts = _context.Posts.Include(p => p.Author).OrderByDescending(p => p.DatePublished).ToList();
            dynamic viewModel = new ExpandoObject();
            viewModel.Posts = posts;
            return View(viewModel);
        }

        [Route("read/{id:int:min(1)}", Name = "ReadArticle")]
        public IActionResult Read(int id)
        {
            var query = _context.Posts
                .Include(p => p.Author);

            Console.WriteLine(query.ToQueryString());

            var post = query
                .FirstOrDefault(m => m.ID == id);

            dynamic viewModel = new ExpandoObject();
            viewModel.Post = post;

            return View(viewModel);
        }

        [Route("author/{id:int:min(1)}", Name = "ByAuthor")]
        public IActionResult ByAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            var posts = _context.Posts.Include(p => p.Author).Where(p => p.Author == author).ToList();
            dynamic viewModel = new ExpandoObject();
            viewModel.Author = author;
            viewModel.Posts = posts;
            
            return View(viewModel);
        }


        [Route("archives", Name = "Archives")]
        public IActionResult Archive()
        {
            return View();
        }

        [Route("about", Name = "About")]
        public IActionResult AboutMe()
        {
            var authors = _context.Authors.ToList();
            dynamic viewModel = new ExpandoObject();
            viewModel.Authors = authors;

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
