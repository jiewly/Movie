using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class MasterMovieController : Controller
    {
        private readonly MovieContext _movieContext;

        public MasterMovieController(MovieContext movieContext)
        {
          _movieContext= movieContext;//set dependency
        }
        // GET: MasterMovieController
        public ActionResult Index()
        {
            var movies = _movieContext.MasterMovies.ToList();
            return View(movies);
        }

        // GET: MasterMovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterMovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterMovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterMovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
