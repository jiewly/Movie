using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.EntityFramework;
using Movie.Models;
using Movie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{

    public class MasterMovieController : Controller
    {
        private readonly MovieContext _movieContext;
        private readonly MasterMovieService _masterMovieService;

        public MasterMovieController(MovieContext movieContext )
        {
            _movieContext = movieContext;//set dependency
            _masterMovieService = new MasterMovieService(_movieContext);
         }
        // GET: MasterMovieController
        public ActionResult Index()
        {
            var movies = _masterMovieService.GetAll();
            return View(movies);
        }

        //// GET: MasterMovieController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: MasterMovieController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MasterMovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.AddMovies(item);

                return RedirectToAction("Index");
            }

            return View(item);

        }

        // GET: MasterMovieController/Edit/5
        public ActionResult Edit(int id)
        {
            MasterMovie item = _masterMovieService.PostMovies(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }
        // POST: MasterMovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _masterMovieService.UpdateMovies(item);

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: MasterMovieController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: MasterMovieController/Delete/5
        public ActionResult Delete(int id)
        {
            _masterMovieService.DeleteMovies(id);
            return RedirectToAction("index");

        }   

    }
}

