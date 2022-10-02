using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAss5.Models
{
    public class Borrows
    {
        public int BorrowId { get; set; }
        public int StudentID { get; set; }
        public int BookId { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughtDate { get; set; }

    }
}
