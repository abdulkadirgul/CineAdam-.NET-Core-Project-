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
    public class SaloonController : Controller
    {
        private readonly ISaloonRepository saloonRepository;

        public SaloonController(ISaloonRepository _saloonRepository)
        {
            saloonRepository = _saloonRepository;
        }
        public IActionResult Index()
        {
            return View(saloonRepository.GetSaloons());
        }

        public IActionResult PostSaloon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostSaloon(Saloon saloon)
        {
            saloonRepository.PostSaloon(saloon);
            return RedirectToAction("Index");

        }

        public IActionResult UpdateSaloon(int id)
        {
            return View(saloonRepository.Where(x => x.Id == id).FirstOrDefault());
        }


        [HttpPost]
        public IActionResult UpdateSaloon(Saloon saloon)
        {
            saloonRepository.UpdateSaloon(saloon);
            return RedirectToAction("Index");
        }

        

        [HttpPost]
        public IActionResult DeleteSaloon(int id)
        {
           
            saloonRepository.DeleteSaloon(id);

            return RedirectToAction("Index");
        }
    }
}
