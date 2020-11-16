using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {


        private readonly ILogger<BlogController> _logger;
        private readonly BloggingContext _context;

        public BlogController(BloggingContext context, ILogger<BlogController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public Blog Get()
        {
            Console.WriteLine("Querying for a blog");
            var blog = _context.Blogs
                .FirstOrDefault();

            return blog;
        }

        [HttpGet("count")]
        public int Count()
        {
            Console.WriteLine("Counting blogs");
            var Count = _context.Blogs.Count();


            return Count;
        }
        [HttpPost]
        public Blog Create(Blog newBlog)
        {
            var createBlog = new Blog { Url = newBlog.Url };
            // Create
            Console.WriteLine("Inserting a new blog");
            _context.Add(createBlog);
            _context.SaveChanges();


            return createBlog;
        }

    }
}
