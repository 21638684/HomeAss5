using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAss5.Models
{
    public class Books
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Pagecount { get; set; }
        public int Points { get; set; }
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
    }
}
