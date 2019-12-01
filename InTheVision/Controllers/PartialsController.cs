using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InTheVision.Models;

namespace InTheVision.Controllers
{
    public class PartialsController : Controller
    {
        movieDBEntities _db = new movieDBEntities();
        // Vizyonda olan filmleri alalım. (type=0)
         public PartialViewResult getThisSeason()
        {
            List<Movie> movies = _db.Movies
                .Where(t => t.type == 0)
                .OrderByDescending(t => t.id).Take(5).ToList();
            return PartialView(movies);
        }
        // tavsiye edilen filmleri alalım. (type=1)
        public PartialViewResult getRecommended()
        {
            List<Movie> recMovie = _db.Movies
                                .Where(t => t.type == 1)
                                 .ToList();
            return PartialView(recMovie);
        }


        //API tarafından tüm filmleri alıyoruz.
        [HttpPost]
        public ActionResult getMovies()
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://api.misfirindan.com/");
            myReq.ContentType = "application/json";


            // here's how to set response content type:
            Response.ContentType = "application/json"; // that's all

            var response = (HttpWebResponse)myReq.GetResponse();
            string text;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            return Json(text, JsonRequestBehavior.AllowGet);
        }

        //API tarafından rastgele film alıyoruz.
        [HttpPost]
        public ActionResult randomMovie()
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://api.misfirindan.com/random.php");
            myReq.ContentType = "application/json";


            // here's how to set response content type:
            Response.ContentType = "application/json"; // that's all

            var response = (HttpWebResponse)myReq.GetResponse();
            string text;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            return Json(text, JsonRequestBehavior.AllowGet);
        }

    }
}