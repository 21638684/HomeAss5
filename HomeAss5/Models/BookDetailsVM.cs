using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAss5.Models
{
    public class BookDetailsVM
    {  
        public string Book { get; set; }
        public int ID { get; set; }
        public DateTime Takendate { get; set; }
        public DateTime Returndate { get; set; }
        public string Student { get; set; }
    } 
}
