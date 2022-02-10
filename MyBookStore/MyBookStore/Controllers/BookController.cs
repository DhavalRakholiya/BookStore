using Microsoft.AspNetCore.Mvc;
using MyBookStore.Models;
using MyBookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult GetAllBooks()
        {
            var data =  _bookRepository.GetAllBooks();

            return View(data);
        }

        public ViewResult GetBookById(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
            int id =  _bookRepository.AddNewBook(bookModel);
            if(id > 0)
            {
                return RedirectToAction("AddNewBook", new { isSuccess = true , bookId = id });
            }
            return View();
        }
    }
}
