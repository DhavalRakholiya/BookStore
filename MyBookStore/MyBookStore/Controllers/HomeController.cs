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
            ViewBag.Title = 123;

            dynamic data = new ExpandoObject();
            data.id = 1;
            data.name = "Bhaumik";
            ViewBag.Obj = data;

            ViewBag.Type = new BookModel() { Id = 1, Author = "Dhaval" };
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
