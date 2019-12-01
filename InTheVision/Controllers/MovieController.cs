using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InTheVision.Models;

namespace InTheVision.Controllers
{
    
    public class MovieController : Controller
    {
        movieDBEntities _db = new movieDBEntities();

         
        public ActionResult Details(int id)
        {
            var details = _db.Movies.Where(t => t.id == id).SingleOrDefault();
            ViewBag.mTitle = details.mName + " Details";
            return View(details);
        }


        public ActionResult Random()
        {
            var movies = _db.Movies
                .OrderBy(x => Guid.NewGuid()).Take(1).SingleOrDefault();
            ViewBag.mTitle = movies.mName + " Details";
            return RedirectToAction("Details", "Movie", new { id = movies.id });
        }

    }
}