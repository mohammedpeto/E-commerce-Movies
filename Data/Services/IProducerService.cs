using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
   public interface IProducerService
    {
        public List<Producer> GetAll();
        public Producer GetByID(int id);
        public int Create(Producer producer);
        public int Update(int id, Producer producer);
        public int Delete(int id);
    }
}
