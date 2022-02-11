﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var group1 = new SelectListGroup() { Name = "Group 1" };
            var group2 = new SelectListGroup() { Name = "Group 2", Disabled = true };
            var group3 = new SelectListGroup() { Name = "Group 3" };

            //ViewBag.languageList = new SelectList(GetLanguage(), "Id", "Text", "2");
            ViewBag.languageList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Hindi", Value = "1", Group = group1 },
                new SelectListItem(){Text = "English", Value = "2", Group = group1 },
                new SelectListItem(){Text = "Dutch", Value = "3", Group = group2},
                new SelectListItem(){Text = "Tamil", Value = "4", Group = group2 },
                new SelectListItem(){Text = "Urdu", Value = "5" , Group = group3},
                new SelectListItem(){Text = "Chinese", Value = "6", Group = group3 }
            };
            ViewBag.isSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.languageList = new SelectList(GetLanguage(), "Id", "Text");
            return View();
        }


        public List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                 new LanguageModel(){ Id = 1, Text = "Gujarati"},
                 new LanguageModel(){ Id = 2, Text = "Hindi"},
                 new LanguageModel(){ Id = 3, Text = "English"}
            };
        }
    }
}
