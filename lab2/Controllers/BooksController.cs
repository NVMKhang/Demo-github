using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        private List<Book> listBooks;
        public BooksController()
        {
            listBooks = new List<Book>();
            listBooks.Add(new Book()
            {
                id=1,
                Title="Sach 1",
                Author= "Tac gia sach 1",
                PublicYear= 2017,
                Price =40000,
                Cover="Content/image/TH006.jpg"
            });
            listBooks.Add(new Book()
            {
                id = 2,
                Title = "Sach 2",
                Author = "Tac gia sach 2",
                PublicYear = 2018,
                Price = 50000,
                Cover = "Content/image/TH007.jpg"
            });
            listBooks.Add(new Book()
            {
                id = 3,
                Title = "Sach 3",
                Author = "Tac gia sach 3",
                PublicYear = 2019,
                Price = 1000000,
                Cover = "Content/image/TH008.jpg"
            });
        }
        public ActionResult ListBooks()
        {
            ViewBag.TitlePagename = "Book view page";
            return View(listBooks);
        }
        public ActionResult Detail(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var editBook = listBooks.Find(b => b.id == book.id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.Cover = book.Cover;
                    editBook.Price = book.Price;
                    editBook.PublicYear = book.PublicYear;
                    return View("ListBooks", listBooks);

                }
                catch(Exception ex)
                {
                    //log exception ex
                    return HttpNotFound();
                }
            } 
            else
            {
                ModelState.AddModelError("", "Input Model Not Valid");
                return View(book);
            }    
        }
    }
}