using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HomeAss5.Models
{
    public class BooksViewModel
    {

        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int PageCount { get; set; }
        public int Points { get; set; }
        
    }
}
