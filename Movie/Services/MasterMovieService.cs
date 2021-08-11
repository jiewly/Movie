using Movie.EntityFramework;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Services
{
    public class MasterMovieService
    {
        private readonly MovieContext _movieContext;
        public MasterMovieService(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IEnumerable<MasterMovie> GetAll()
        {
            var movies = _movieContext.MasterMovies.ToList();
            return movies;
        }
        //เพิ่ม เมดตอด getbyid 
        //add
        //update
        //delete
        public MasterMovie GetById(int id)
        {
            var item = _movieContext.MasterMovies.Find(id);
            _movieContext.SaveChanges();
            return item;
        }
        public MasterMovie AddMovies(MasterMovie item)
        {
            _movieContext.MasterMovies.Add(item);
            _movieContext.SaveChanges();
            return item;
        }

        public MasterMovie PostMovies(int id)
        {
            MasterMovie item = _movieContext.MasterMovies.Find(id);
            if (item == null)
            { 
                _movieContext.MasterMovies.Add(item);
            _movieContext.SaveChanges();
                }
            return item;
        }

        public MasterMovie UpdateMovies(MasterMovie item)
        {
             _movieContext.MasterMovies.Update(item);
            _movieContext.SaveChanges();
            return item;
        }
        public MasterMovie DeleteMovies(int id)
        {
            MasterMovie item = _movieContext.MasterMovies.Find(id);
            if (item != null)
            {
                _movieContext.MasterMovies.Remove(item);
                _movieContext.SaveChanges();
            }

            return item;
        }

    }
}
