using Microsoft.EntityFrameworkCore;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.EntityFramework
{
    public class MovieContext:DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)//consturtor
        {
        }
        //register table
        public DbSet<MasterMovie> MasterMovies { get; set; }
        //run create property
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterMovie>().ToTable("MasterMovie");
           
        }
    }
}
