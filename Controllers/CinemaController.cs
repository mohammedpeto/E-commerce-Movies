using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize]
    public class CinemaController : Controller
    {
        

        public CinemaController(ICinemaService _cinema)
        {
            cinemaRepo = _cinema;
        }

        public ICinemaService cinemaRepo { get; }

        public IActionResult Index()
        {
            var ci = cinemaRepo.GetAll();
            return View(ci);
        }

        public IActionResult Edit(int id)
        {
            Cinema c = cinemaRepo.GetByID(id);
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(int id , Cinema c)
        {
            if(ModelState.IsValid == true)
            {
                cinemaRepo.Update(id, c);
                return RedirectToAction("index");
            }
            return View(id);
        }

        public IActionResult Details(int id)
        {
            Cinema c = cinemaRepo.GetByID(id);
            return View(c);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cinema c)
        {
            if(ModelState.IsValid == true)
            {
                cinemaRepo.Create(c);
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int id )
        {
            Cinema c = cinemaRepo.GetByID(id);
            return View(c);
        }

        [HttpPost]
        public IActionResult Deleted(int id)
        {
            try
            {
                cinemaRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
                
               
            
        }

    }
}
