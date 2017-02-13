using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetBlog.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDataContext db = new BlogDataContext();
        // GET: /<controller>/

        public async Task<IActionResult> Index(int page)
        {
//            Post[] posts = {
//                new Post { Title = "My first blog post",
//                PostDate = DateTime.Now,
//                Author = "Henry Xie",
//                Body = "This is my first blog post. Welcome to my site"},
//                new Post { Title = "My second blog post",
//                PostDate = DateTime.Now,
//                Author = "Henry Xie",
//                Body = "This is my second blog post. Welcome to my site"},
//                new Post { Title = "My third blog post",
//                PostDate = DateTime.Now,
//                Author = "Henry Xie",
//                Body = "This is my third blog post. Welcome to my site"}
//
//            };
//            Post[] posts = db.Posts.ToArray();
//            Array.Reverse(posts);

            var pageSize = 3;
            var skip = page*pageSize;
            var posts = await db.Posts.OrderByDescending(x => x.PostDate).Skip(skip).Take(pageSize).ToArrayAsync();
//            Task<Post[]> posts = db.Posts.ToArrayAsync(); 

            var totalPosts = db.Posts.Count();
            var totalPages = totalPosts/pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage <= totalPages;

            if (Request.Headers["X-Requested-With"]=="XMLHttpRequest")
            {
                return PartialView("_ViewStart", posts);
            }
            return View(posts);
        }

        public IActionResult CauseAnError()
        {
            throw new Exception("Error!");
        }

        public IActionResult Error()
        {
            return View();
        }

        public string Echo(string id)
        {
            return "hello "+id+",welcome";
        }
    }
}
