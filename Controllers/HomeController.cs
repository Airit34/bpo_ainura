using System;
using Microsoft.AspNetCore.Mvc;
using ProgrammerBlog.Models;
using System.Linq;

namespace ProgrammerBlog.Controllers {

    public class HomeController : Controller {

        public ViewResult Index() {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Доброе утро!" : "Добрый день!";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult ProgrammerBlogForm() {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }
        public ViewResult MyView()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ProgrammerBlogForm(GuestResponse guestResponse) {
            if (ModelState.IsValid) {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            } else {
                // there is a validation error
                return View();
            }
        }

        public ViewResult ListResponses() {
            return View(Repository.Responses);
        }
    }
}
