using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAss5.Models
{
    public class Students
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public int Points { get; set; }
    }
}
