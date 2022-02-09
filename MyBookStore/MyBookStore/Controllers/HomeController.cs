using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
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
