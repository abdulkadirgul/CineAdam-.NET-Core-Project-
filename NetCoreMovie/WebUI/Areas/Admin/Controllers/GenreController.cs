using DataAccess.Context;
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreRepository genreRepository;
        private object movieContext;

        public GenreController(IGenreRepository _genreRepository)
        {
            genreRepository = _genreRepository;
        }


        public IActionResult Index()
        {
            return View(genreRepository.GetGenres());
        }

        public IActionResult PostGenre()
        {


            return View();

        }
        [HttpPost]
        public IActionResult PostGenre(Genre genre)
        {
            genreRepository.PostGenre(genre);
            

            return RedirectToAction("Index");
         

        }

    }
}
