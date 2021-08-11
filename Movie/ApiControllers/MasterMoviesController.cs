using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.EntityFramework;
using Movie.Models;
using Movie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.ApiControllers
{
    [Route("api/mastermovies")]
    [ApiController]
    public class MasterMoviesController : ControllerBase
    {
        ////public string Whoami()
        ////{
        ////    return "Jiew";
        //}
        private readonly MovieContext _movieContext;
        private readonly IMasterMovieService _masterMovieService;

        public MasterMoviesController(MovieContext movieContext,IMasterMovieService masterMovieService)
        {
            _movieContext = movieContext; //set dependency injection
            _masterMovieService = masterMovieService; //set dependency injection
        }
        [Route("getall")]

        public IEnumerable<MasterMovie> GetAll()
        {
            var movies = _masterMovieService.GetAll();
            return movies;
        }
        [Route("getbyid/{id?}")]

        public MasterMovie GetById(int id)
        {
            var item =  _masterMovieService.GetById(id);//การส่งข้อมูลผ่านคิวรี่เพื่อที่จะได้เรียกค่ากลับคืนมา 
            return item;
        }
        [HttpPost]
        public MasterMovie Add(MasterMovie item)
        {
            var mastermovie = _masterMovieService.AddMovies(item);
            return mastermovie;
        }
        [HttpPut]
        public MasterMovie UpdateMovies(MasterMovie item)
        {
            var mastermovie = _masterMovieService.UpdateMovies(item);
            return mastermovie;
        }
       [HttpDelete]
        public MasterMovie DeleteMovies(int id)
        {
            var mastermovie = _masterMovieService.DeleteMovies(id);
            return mastermovie;
        }
    }
}
