using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspNetBlog.Models
{
    public class Post
    {
        public long Id { get; set; }

        public string Key
        {
            get
            {
                if (Title==null)
                {
                    return null;
                }
                var key = Regex.Replace(Title, @"[^a-zA-Z0-9\-]", " ");
                return key.Replace(" ", "-").ToLower();
            }
            
        }

        [Required]
        [Display(Name = "Blog post title")]
        [DataType(DataType.Text)]
        [StringLength(30,MinimumLength = 5,ErrorMessage = "Blog post title must between 5 and 30 characters long")]
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string Author { get; set; }

        [Required]
        [Display(Name = "Blog post body")]
        [DataType(DataType.MultilineText)]
        [MinLength(5,ErrorMessage = "Blog post body mininum 5 characters")]
        public string Body { get; set; }
    }
}
