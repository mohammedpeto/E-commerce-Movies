using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class CinemaServices : ICinemaService
    {

        public CinemaServices(TicketDbContext _context)
        {
            context = _context;
        }

        public TicketDbContext context { get; }

        public int Create(Cinema cinema)
        {
            context.Cinemas.Add(cinema);
            int row = context.SaveChanges();
            return row;
        }

        public int Delete(int id)
        {
            context.Cinemas.Remove(context.Cinemas.FirstOrDefault(c => c.ID == id));
            int row = context.SaveChanges();
            return row;
        }

        public List<Cinema> GetAll()
        {
            return context.Cinemas.ToList();
        }

        public Cinema GetByID(int id)
        {
            return context.Cinemas.FirstOrDefault(c => c.ID == id);
        }

        public int Update(int id, Cinema cinema)
        {
            Cinema c = context.Cinemas.FirstOrDefault(c => c.ID == id);
            if(c !=null)
            {
                c.Logo = cinema.Logo;
                c.Name = cinema.Name;
                c.Description = cinema.Description;
                int row = context.SaveChanges();
                return row;
            }
            return -1;
        }
    }
}
