using Movie.Models;
using Movie.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.services
{
    public class movieservices : Imovieservices
    {
        private ApplicationDbcontext _context;

        public movieservices(ApplicationDbcontext context)
        {
            _context = context;
        }

        public List<movie> Getmovies()
        {
            return _context.movies.ToList();
        }

        public void displaymovie()
        {

            List<movie> movies = Getmovies();
            foreach (movie movie in movies)
            {
                Console.WriteLine($"Name:{movie.Name}");
                Console.WriteLine($"type:{movie.category}");
                Console.WriteLine($"description:{movie.Description}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public void AddMovie(string name, string Category, string Description)
        {
            movie movie = MovieManagerFactory.create(name, Description, Category);
            _context.movies.Add(movie);
            _context.SaveChanges();
            Console.WriteLine("Added successfully");
        }

        public void RemoveMovie(string name)
        {
            _context.movies.Remove(_context.movies.SingleOrDefault(x => x.Name == name));
            _context.SaveChanges();
            Console.WriteLine("Removed");
        }
    }
}
