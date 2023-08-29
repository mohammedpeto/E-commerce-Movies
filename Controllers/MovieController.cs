using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MovieController : Controller
    {
      

        public MovieController(IMovieService _movieRepo)
        {
            MovieRepo = _movieRepo;
        }

        public IMovieService MovieRepo { get; }

        public IActionResult Index()
        {
            var mo = MovieRepo.GetAll();
            return View(mo);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var mov = MovieRepo.GetByID(id);
            return View(mov);
        }
    }
}
