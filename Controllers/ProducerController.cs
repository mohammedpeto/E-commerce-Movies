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
    public class ProducerController : Controller
    {
        
        public ProducerController(IProducerService _producerReop)
        {
            producerReop = _producerReop;
        }

        public IProducerService producerReop { get; }

        public IActionResult Index()
        {
            var pro = producerReop.GetAll();
            return View(pro);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producer p)
        {
            if (ModelState.IsValid == true)
            {
               producerReop.Create(p);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public IActionResult Edit(int id)
        {
            Producer p = producerReop.GetByID(id);
            return View(p);
        }
        
        [HttpPost]
        public IActionResult Edit(int id , Producer pr)
        {
            if (ModelState.IsValid == true)
            {
                producerReop.Update(id, pr);
                return RedirectToAction("Index");
            }
            return View(id);
        }

        public IActionResult Details(int id)
        {
           Producer p = producerReop.GetByID(id);
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            Producer p = producerReop.GetByID(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            try
            {
             
                producerReop.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
