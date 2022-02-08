using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "All Books";
        }

        public string GetBookById(int id)
        {
            return $"Book With Id: {id}";
        }

        public string SearchBooks(string bookName, string authorName)
        {
            return $"Book with Name: {bookName} & Author: {authorName}";
        }
    }
}
