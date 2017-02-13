using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetBlog.Models
{
    public class ArchivedPostsSummary
    {
        public int Count { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public DateTime Date => new DateTime(Year,Month,1);
    }
}
