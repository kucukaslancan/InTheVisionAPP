using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InTheVision.Models;
using PagedList;

namespace InTheVision.Controllers
{
    public class AdminController : Controller
    {
        movieDBEntities _db = new movieDBEntities();
        SettingsMv getSettings = new SettingsMv();
        // GET: Admin
        public ActionResult Index()
        {
           
           
            return View(getSettings);
        }

        public ActionResult Login()
        {
            return View();
        }

        //User giriş kontrolünü yapıyoruz.
        [HttpPost]
        public ActionResult Login(User user)
        {
           
                var loginUser = _db.Users.Where(t => t.username == user.username && t.password == user.password).SingleOrDefault();
                if (loginUser != null)
                {
                    Session["logined"] = loginUser.username;
                    Session["userId"] = loginUser.id;
                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    ViewBag.error = "User Not Found!";
                    
                }
           

            return View(user);
        }

        // Tüm filmleri listele
        public ActionResult listMovies()
        {
            List<Movie> listAll = _db.Movies.ToList();
            return View(listAll);
        }

        //Film Ekle View
        public ActionResult AddMovie()
        {
            return View();
        }

        // Filmi veritabanına kaydet
        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction("listMovies", "Admin");
        }


        // Film düzenle
        public ActionResult Edit(int id)
        {
            Movie edit = _db.Movies.Find(id);
            return View(edit);
        }


        // Film düzenle
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            Movie edited = _db.Movies.Find(movie.id);
            edited.mCountry = movie.mCountry;
            edited.mDescription = movie.mDescription;
            edited.mGenre = movie.mGenre;
            edited.mImdb = movie.mImdb;
            edited.mName = movie.mName;
            edited.mPoster = movie.mPoster;
            edited.mReleaseYear = movie.mReleaseYear;
            edited.mTime = movie.mReleaseYear;
            edited.mTrailer = movie.mTrailer;
            edited.type = movie.type;
            _db.SaveChanges();
            return View(edited);
        }

        //Film Sil
        [HttpGet]
        public ActionResult deleteMovie(int id)
        {
            Movie deleted = _db.Movies.Find(id);
            _db.Movies.Remove(deleted);
            _db.SaveChanges();
            return RedirectToAction("listMovies");
        }

        //sessionları sıfırlıyoruz ve sistemden çıkış yapıyoruz.
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}