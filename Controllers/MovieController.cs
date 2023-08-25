using eTickets.Data;
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
        private readonly TicketDbContext context;

        public MovieController(TicketDbContext _context)
        {
            context = _context;
        }


        public IActionResult Index()
        {
            var mo = context.Movies.Include(n=>n.Cinema).ToList();
            return View(mo);
        }
    }
}
