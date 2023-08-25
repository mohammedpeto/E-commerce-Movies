using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly TicketDbContext context;
        public MovieService(TicketDbContext _context)
        {
            context = _context;
        }
        public void Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Movies.Remove(context.Movies.FirstOrDefault(m => m.ID == id));
            context.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return context.Movies.Include(m => m.Cinema).Include(m => m.Producer).ToList();
        }

        public Movie GetByID(int id)
        {
            return context.Movies.Include(m => m.Cinema).Include(m => m.Producer).FirstOrDefault(m => m.ID == id);
        }

        public void Update(int id, Movie mov)
        {
            Movie m = context.Movies.FirstOrDefault(m => m.ID == id);
            if(m !=null)
            {
                m.Name = mov.Name;
                m.ImageURL = mov.ImageURL;
                m.MovieCatagory = mov.MovieCatagory;
                m.Price = mov.Price;
                m.StartDate = mov.StartDate;
                m.ProducerId = mov.ProducerId;
                context.SaveChanges();
            }
        }
    }
}
