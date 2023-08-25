using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ProducerService : IProducerService
    {

        public ProducerService(TicketDbContext _context)
        {
            context = _context;
        }

        public TicketDbContext context { get; }

        public int Create(Producer producer)
        {
            context.Producers.Add(producer);
            int row = context.SaveChanges();
            return row;
        }

        public int Delete(int id)
        {
            context.Producers.Remove(context.Producers.FirstOrDefault(p => p.ID == id));
            int roe = context.SaveChanges();
            return roe;
        }

        public List<Producer> GetAll()
        {
            return context.Producers.ToList();
        }

        public Producer GetByID(int id)
        {
            return context.Producers.FirstOrDefault(p => p.ID == id);
        }

        public int Update(int id, Producer producer)
        {
            Producer p = context.Producers.FirstOrDefault(p => p.ID == id);
            if(p !=null)
            {
                p.FullName = producer.FullName;
                p.ProfilePictureURL = producer.ProfilePictureURL;
                p.Bio = producer.Bio;
                return context.SaveChanges();
            }
            return -1;

        }
    }
}
