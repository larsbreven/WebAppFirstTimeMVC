using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppFirstTimeMVC.Models;

namespace WebAppFirstTimeMVC.Controllers
{
    public class HomeController : Controller
    {
        IMessagesService _messagesService = new FileMessagesService();

        public HomeController()
        {
            _messagesService = new FileMessagesService();
        }

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

        // --------------------------------------------------------------------------------------------------------------------

        [HttpGet]//only client get request can call this one
        public IActionResult ContactUs()                            // This is the first page the client will see "ContactUs Views"
        {
            return View();
        }

        [HttpPost]//only client post request can call this one
        public IActionResult ContactUs(string name, string email, string message)
        {
            if (
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(message)
                )
            {
                ViewBag.Msg = "Fill in Name, Email and Message!";
                return View();
            }

            if (_messagesService.Save(name, email, message))
            {
                //ViewBag.ContactList = _messagesService.GetAll();

                //return RedirectToAction("ContactList");
                return RedirectToAction(nameof(ContactList));
            }

            ViewBag.Msg = "Something went wrong";
            return View();                                                                  // Show the view again in case of failure
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            ViewBag.ContactList = _messagesService.GetAll();
            return View();
        }
    }
}