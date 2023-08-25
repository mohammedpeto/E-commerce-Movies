using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService actorsService;
        public ActorsController(IActorsService _actorsService)
        {
            actorsService = _actorsService;
        }
        public IActionResult Index()
        {
            var ac = actorsService.GetAll();
            return View(ac);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            if (ModelState.IsValid == true)
            {
                actorsService.Create(actor);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public IActionResult Details(int id)
        {
            Actor a = actorsService.GetByID(id);
            return View(a);
        }

        public IActionResult Edit(int id)
        {
            Actor a = actorsService.GetByID(id);
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(int id, Actor actor)
        {
            if (ModelState.IsValid == true)
            {
                actorsService.Update(id, actor);
                return RedirectToAction("Details", id);
            }
            return View(id);


        }

        public IActionResult Delete(int id)
        {
            Actor a = actorsService.GetByID(id);
            return View(a);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            int row = actorsService.Delete(id);
            return View();
        }
    }
}
