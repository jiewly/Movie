using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.EntityFramework;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext _movieContext;

        public HomeController(ILogger<HomeController> logger,MovieContext movieContext)
        {
            //Dependensy
            _logger = logger;
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
