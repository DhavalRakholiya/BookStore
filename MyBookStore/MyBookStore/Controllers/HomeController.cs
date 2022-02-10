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
        public ViewResult Index()
        {
            ViewData["prop1"] = "Vikas";

            ViewData["prop2"] = new BookModel() { Id = 1, Author = "Dhaval Rakholiya" };

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
