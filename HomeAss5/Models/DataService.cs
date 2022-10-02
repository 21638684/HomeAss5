using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace HomeAss5.Models
{
    public class DataService
    {
      
        
        public List<BooksViewModel> GetBookbyNameTypeAuthor(string Book,string Type,string Author) 
        {
            List<BooksViewModel> Record = new List<BooksViewModel>();
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString))
            {
                Conn.Open();

                using (SqlCommand Comm = new SqlCommand("Select books.bookId, books.name as bookname,authors.surname, types.name as typename, books.pagecount, books.point from books Inner join authors on books.authorId = authors.authorId inner join types on books.typeId = types.typeId where books.name LIKE'%" + Book + "%' OR types.name LIKE'%" + Type + "%' OR surname LIKE '%" + Author + "%'", Conn))

                {
                 
                    using (SqlDataReader reader = Comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {
                                BooksViewModel records = new BooksViewModel()
                                {

                                    BookId = Convert.ToInt32(reader["bookId"]),
                                    Name = Convert.ToString(reader["bookname"]),
                                    Author = Convert.ToString(reader["surname"]),
                                    Type = Convert.ToString(reader["typename"]),
                                    PageCount = Convert.ToInt32(reader["pageCount"]),
                                    Points = Convert.ToInt32(reader["point"]),



                                };
                                Record.Add(records);
                            }
                        }
                    }
                }
                Conn.Close();
            }
            return Record;
        }

           
        public List<StudentViewModel> GetStudentByNameClass(string Name,string Class)
        {
            List<StudentViewModel> Student = new List<StudentViewModel>();
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString))
            {
                Conn.Open();
                using (SqlCommand Comm = new SqlCommand("select students.studentId,students.name as StuName,students.surname as StuSurname,students.class,students.point from students where name LIKE'%" + Name + "%' OR class LIKE'%" + Class + "%'", Conn))

                {

                    using (SqlDataReader reader = Comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentViewModel students = new StudentViewModel
                            {
                                StudentId = Convert.ToInt32(reader["studentId"]),
                                Name = Convert.ToString(reader["StuName"]),
                                Surname = Convert.ToString(reader["StuSurname"]),
                                Class = Convert.ToString(reader["class"]),
                                Points = Convert.ToInt32(reader["Point"])
                            };
                            Student.Add(students);
                        }
                    }
                }
                Conn.Close();
            }
            return Student;
        }


        //  method to retrieve all booksdetails  
        public List<BookDetailsVM> GetbookBorrows()
        {
            List<BookDetailsVM> BookDtl = new List<BookDetailsVM>();
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString))
            {
                Conn.Open();
                using (SqlCommand Comm = new SqlCommand("select name as BookName,borrowId, takenDate, broughtDate, students.name as StudentName from borrows inner join students on borrows.studentId = students.studentId", Conn))

                {

                    using (SqlDataReader reader = Comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookDetailsVM bookbrw = new BookDetailsVM
                            {
                                Book = Convert.ToString(reader["BookName"]),
                                ID = Convert.ToInt32(reader["borrowId"]),
                                Takendate = Convert.ToDateTime(reader["takenDate"]),
                                Returndate = Convert.ToDateTime(reader["BroughtDate"]),
                                Student = Convert.ToString(reader["StudentName"])
                            };
                            BookDtl.Add(bookbrw);
                        }
                    }
                }
                Conn.Close();
            }
            return BookDtl;
        }
        public void BorrowBook(int bookID, int StudentID)
        {
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString))
            {
                Conn.Open();
                using (SqlCommand comm = new SqlCommand("insert into borrows studentId,bookId,takendate values @studentId,@bookId,@takendate", Conn))
                {
                    comm.Parameters.Add(new SqlParameter("@studentId", StudentID));
                    comm.Parameters.Add(new SqlParameter("@bookId", bookID));
                    comm.Parameters.Add(new SqlParameter("@takendate", DateTime.Now));
                    comm.ExecuteNonQuery();
                }
                Conn.Close();
            }
        }
            
            public void ReturnBook(int bookID, int StudentID)
        {
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString))
            {
                Conn.Open();
                using (SqlCommand comm = new SqlCommand("update borrows set broughtDate =@broughtDate where borrows.studentId=@studentId AND borrows.bookId=@bookID and @broughtDate is Null", Conn))
                {
                    comm.Parameters.Add(new SqlParameter("@studentId", StudentID));
                    comm.Parameters.Add(new SqlParameter("@bookId", bookID));
                    comm.Parameters.Add(new SqlParameter("@broughtDate", DateTime.Now));
                    comm.ExecuteNonQuery();
                }
                Conn.Close();
            }

        }
    }
}
