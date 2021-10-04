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
    public class WeekController : Controller
    {
        private readonly IWeekRepository weekRepository;

        public WeekController(IWeekRepository _weekRepository)
        {
            weekRepository = _weekRepository;
        }
        public IActionResult Index()
        {
            return View(weekRepository.GetWeeks());
        }

        public IActionResult PostWeek()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostWeek(Week Week)
        {
            weekRepository.PostWeek(Week);
            return RedirectToAction("Index");

        }

        public IActionResult UpdateWeek(int id)
        {
            return View(weekRepository.Where(x => x.Id == id).FirstOrDefault());
        }


        [HttpPost]
        public IActionResult UpdateWeek(Week Week)
        {
            weekRepository.UpdateWeek(Week);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult DeleteWeek(int id)
        {

            weekRepository.DeleteWeek(id);

            return RedirectToAction("Index");
        }
    }
}
