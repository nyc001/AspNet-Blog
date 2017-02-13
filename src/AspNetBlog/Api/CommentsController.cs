using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetBlog.Models;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetBlog.Api
{
    [Route("api/posts/{postID:long}/comments")]
    public class CommentsController : Controller
    {
        private readonly BlogDataContext _db=new BlogDataContext();
        // GET: api/values
        [HttpGet]
        public IQueryable<Comment> Get(long postId)
        {
            return _db.Comments.Where(x => x.PostId == postId);
//            return _db.Posts.Where(x=>x.Id==postId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<Comment> Post([FromBody]Comment comment)
        {
            
            comment.Author = User.Identity.Name;
            comment.DateTime=DateTime.Now;

            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return comment;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
