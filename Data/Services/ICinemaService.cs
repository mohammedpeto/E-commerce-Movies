using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface ICinemaService
    {
        public List<Cinema> GetAll();
        public Cinema GetByID(int id);
        public int Create(Cinema cinema);
        public int Update(int id, Cinema cinema);
        public int Delete(int id);




    }
}
