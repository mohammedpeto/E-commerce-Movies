using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        public List<Actor> GetAll();
        public Actor GetByID(int id);
        public int Create(Actor a);
        public int Update(int id, Actor a);
        public int Delete(int id);
    }
}
