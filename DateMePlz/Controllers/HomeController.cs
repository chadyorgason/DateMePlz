using DateMePlz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DateMePlz.Controllers
{
    public class HomeController : Controller
    {
        private DateApplicationContext daContext { get; set; }

        //constructor
        public HomeController(DateApplicationContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        //Get for adding a movie
        [HttpGet]
        public IActionResult DatingApplication()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View("DatingApplication", new ApplicationResponse());
        }

        // Post for adding a movie
        [HttpPost]
        public IActionResult DatingApplication(ApplicationResponse ar)
        {
            // if it has required fields
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View(ar);
            }
        }

        // show list of movies
        public IActionResult Waitlist()
        {
            var applications = daContext.responses
                .Include(x => x.Category)
                //.Where(whatever => whatever.Rating == "PG-13")
                .OrderBy(x => x.Year)
                .ToList();

            return View(applications);
        }

        // Edit form 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var application = daContext.responses.Single(x => x.MovieID == id);

            return View("DatingApplication", application);
        }

        // Post edit form
        [HttpPost]
        public IActionResult Edit(ApplicationResponse meh)
        {
            daContext.Update(meh);
            daContext.SaveChanges();
            return RedirectToAction("Waitlist");
        }

        // delete form
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var application = daContext.responses.Single(x => x.MovieID == id);

            return View(application);
        }

        // Post delete
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();

            return RedirectToAction("Waitlist");
        }
    }
}
