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
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public List<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookModel GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
    }
}
