using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBookStore.Models;
using MyBookStore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null; 
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        public async Task<ViewResult> GetBookById(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguage(), "Id", "Name") ;
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover";
                    folder += Guid.NewGuid().ToString() + "_" + bookModel.CoverPhoto.FileName;
                    bookModel.CoverImageUrl = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguage(), "Id", "Name");
            return View();
        }
    }
}
