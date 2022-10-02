using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeAss5.Models;




namespace HomeAss5.Controllers
{
    public class HomeController : Controller

       
        
    {
        private DataService dataService = new DataService();


        public ActionResult Index(string Book,string Type,string Author)
        {

            List<BooksViewModel> book = dataService.GetBookbyNameTypeAuthor(Book, Type, Author);

            return View (book);
        }
    

        public ActionResult BookDetails()
        {
            List<BookDetailsVM> bookBorrows = dataService.GetbookBorrows();

            return View(bookBorrows);
        }

        
        public ActionResult Students(string Name,string Class)
        {
            List<StudentViewModel> students = dataService.GetStudentByNameClass(Name,Class);

            return View(students);
        }
    }
}