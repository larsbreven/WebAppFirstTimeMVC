using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFirstTimeMVC.Controllers
{
    public class ToDoItController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddToSession()
        {
            ViewBag.Msg = HttpContext.Session.GetString("Msg");
            return View();
        }
        [HttpPost]
        public IActionResult AddToSession(string textToAdd)
        {
            // Creating and setting Session string Msg
            HttpContext.Session.SetString("Msg", textToAdd);
            return RedirectToAction(nameof(AddToSession));
        }

        public IActionResult ShowCookies()
        {
            ViewBag.CookieMsg = Request.Cookies["CookieName"];
            return View();
        }

        [HttpGet]
        public IActionResult AddCookie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCookie(string cookieText)
        {
            //Add cookie to Response object
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append("CookieName", cookieText, option);

            return RedirectToAction("ShowCookies");
        }
    }
}
