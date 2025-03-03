using System;
using System.Linq;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO obj)
        {
            if (obj.MovieIds.Count == 0)
                return BadRequest("No movies added");

            var customer = _context.Customers.FirstOrDefault(x => obj.CustomerName.Equals(x.Name));
            if (customer == null)
                return BadRequest("Invalid customer");

            var movies = _context.Movies.Where(x => obj.MovieIds.Contains(x.Id)).ToList();
            if (movies.Count != obj.MovieIds.Count)
                return BadRequest("One or more invalid movies");

            foreach (var movie in movies)
            {
                if (movie.PiecesInStock == 0)
                    return BadRequest("movie unavilable");

                movie.PiecesInStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
