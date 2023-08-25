using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{

    public class ActorsServices : IActorsService
    {
        private readonly TicketDbContext context;
        public ActorsServices(TicketDbContext _context)
        {
            context = _context;
        }

        public int Create(Actor a)
        {
            context.Actors.Add(a);
            int row = context.SaveChanges();
            return row;
        }

        public int Delete(int id)
        {
            context.Remove(context.Actors.FirstOrDefault(a => a.ID == id));
            int row = context.SaveChanges();
            return row;
        }

        public List<Actor> GetAll()
        {
            List<Actor> actors = context.Actors.ToList();
            return actors;
        }

        public Actor GetByID(int id)
        {
            Actor a = context.Actors.FirstOrDefault(a => a.ID == id);
            return a;
        }

        public int Update(int id, Actor a)
        {
            Actor actor = context.Actors.FirstOrDefault(a => a.ID == id);
            actor.FullName = a.FullName;
            actor.Bio = a.Bio;
            actor.ProfilePictureURL = a.ProfilePictureURL;
            int row = context.SaveChanges();
            return row;
        }
    }
}
