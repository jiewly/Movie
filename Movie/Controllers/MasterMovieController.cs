using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.EntityFramework;
using Movie.Models;
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
            _movieContext = movieContext;//set dependency
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
        public IActionResult Create() => View();

        // POST: MasterMovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(item);
                await _movieContext.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);

        }

        // GET: MasterMovieController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            MasterMovie item = await _movieContext.MasterMovies.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }
        // POST: MasterMovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MasterMovie item)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(item);
                await _movieContext.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

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
        public async Task<ActionResult> Delete(int id)
        {
            MasterMovie item = await _movieContext.MasterMovies.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
               _movieContext.MasterMovies.Remove(item);
                await _movieContext.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
