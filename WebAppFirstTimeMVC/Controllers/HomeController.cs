using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFirstTimeMVC.Controllers
{
    public class HomeController : Controller
    {
        static List<string[]> contactList = new List<string[]>();


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Experiment()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            return View();
        }

        public IActionResult ContactMe()
        {
            return View();
        }


        public IActionResult Projects()
        {
            return View();
        }



        [HttpGet]//only client get request can call this one
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(string name, string email, string message)
        {
            contactList.Add(new string[]{name, email, message});

            ViewBag.ContactList = contactList;

            return View("ContactList");
        }
    }
}
