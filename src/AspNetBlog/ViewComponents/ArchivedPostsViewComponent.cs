using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetBlog.Models;
using Microsoft.AspNet.Mvc;

namespace AspNetBlog.ViewComponents
{
    [ViewComponent]
    public class ArchivedPostsViewComponent:ViewComponent
    {
        private readonly BlogDataContext _db;

        public ArchivedPostsViewComponent(BlogDataContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var archivePosts = _db.GetArchivedPosts().ToArray();
            Array.Reverse(archivePosts);
            return View(archivePosts);
        }
    }
}
