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
    public class SessionController : Controller
    {
        private readonly ISessionRepository sessionRepository;

        public SessionController(ISessionRepository _sessionRepository)
        {
            sessionRepository = _sessionRepository;
        }
        public IActionResult Index()
        {
            return View(sessionRepository.GetSessions());
        }

        public IActionResult PostSession()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostSession(Session session)
        {
            sessionRepository.PostSession(session);
            return RedirectToAction("Index");

        }

        public IActionResult UpdateSession(int id)
        {
            return View(sessionRepository.Where(x => x.Id == id).FirstOrDefault());
        }


        [HttpPost]
        public IActionResult UpdateSession(Session session)
        {
            sessionRepository.UpdateSession(session);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult DeleteSession(int id)
        {

            sessionRepository.DeleteSession(id);

            return RedirectToAction("Index");
        }
    }
}
