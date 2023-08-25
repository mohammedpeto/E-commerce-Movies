using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
   public interface IMovieService
    {
        public List<Movie> GetAll();
        public Movie GetByID(int id);
        public void Create(Movie movie);
        public void Update(int id, Movie mov);
        public void Delete(int id);
    }
}
