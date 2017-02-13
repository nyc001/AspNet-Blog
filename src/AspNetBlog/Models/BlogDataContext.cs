using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Framework.DependencyInjection;

namespace AspNetBlog.Models
{
    public class BlogDataContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; } 

        public BlogDataContext()
        {
            Database.EnsureCreated();
        }

        public IQueryable<ArchivedPostsSummary> GetArchivedPosts()
        {
            return
                Posts.GroupBy(x => new {x.PostDate.Year, x.PostDate.Month}).Select(group => new ArchivedPostsSummary
                {
                    Count = group.Count(),
                    Month = group.Key.Month,
                    Year = group.Key.Year
                });
        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString= @"Data Source=localhost\sqlexpress;Initial Catalog=AspNetBlog;User ID=sa;Password=1201";
            optionsBuilder.UseSqlServer(connectionString);
            
        }

    }
}
