using Microsoft.AspNetCore.Mvc;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository _movieRepository)
        {
            movieRepository =_movieRepository;
        }
        public IActionResult Index()
        {
            return View(movieRepository.GetMovies()) ;
        }
    }
}
