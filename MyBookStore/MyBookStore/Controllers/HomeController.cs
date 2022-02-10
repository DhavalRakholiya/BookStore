using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using MyBookStore.Models;

namespace MyBookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string prop1 { get; set; }

        [ViewData]
        public BookModel book { get; set; }

        public ViewResult Index()
        {
            prop1 = "Dhaval Rakholiya";
            book = new BookModel() { Id = 1, Author = "Vikas Patel" };
            return View();
            
            //return View("AboutUs");
            //Full Path
            //return View("TempView/Index.cshtml");
            //return View("~/TempView/Index.cshtml");
            //Relative Path
            //return View("../../TempView/Index");
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
