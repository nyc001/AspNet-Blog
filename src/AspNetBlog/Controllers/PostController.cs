using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetBlog.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDataContext db;

        public PostController(BlogDataContext _db)
        {
            db = _db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            post.PostDate = DateTime.Now;
            post.Author = User.Identity.Name;

//            var db=new BlogDataContext();
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            
            return RedirectToAction("Post",new {post.PostDate.Year,post.PostDate.Month,key = post.Key});
        }

        public async Task<IActionResult> Post(long id)
        {
            Post post = await db.Posts.SingleOrDefaultAsync(x => x.Id == id);
//            Models.Post post = db.Posts.SingleOrDefault(x => x.Id == id);
//            var post = new Post();
//            post.Title = "My first blog post";
//            post.PostDate = DateTime.Now;
//            post.Author = "Henry Xie";
//            post.Body = "This is my first blog post. Welcome to my site";

            return View(post);
        }

        [Route("posts/{year:int}/{month:int}/{key}")]
        public async Task<IActionResult> Post(int year,int month, string key)
        {
            Post post = await db.Posts.SingleOrDefaultAsync(x => x.PostDate.Year==year&&x.PostDate.Month==month&&x.Key==key);
            return View(post);
        } 
    }
}
