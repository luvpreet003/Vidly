using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult MovieIndex()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var dataObj = new Models.Movies
            {
                Id = id,
                Title = movie.Title,
                DateReleased = movie.DateReleased,
                PiecesInStock = movie.PiecesInStock,
                Genre = movie.Genre
            };

            return View("EditMovie",dataObj);
        }

        [HttpPost]
        public ActionResult Save(Models.Movies model)
        {
            if (model.Id == 0)
            {
                _context.Movies.Add(model);
            }
            else
            {
                var movie = _context.Movies.SingleOrDefault(x => x.Id == model.Id);
                if (movie != null)
                {
                    movie.Title = model.Title;
                    movie.DateReleased = model.DateReleased;
                    movie.PiecesInStock = model.PiecesInStock;
                    movie.Genre = model.Genre;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("MovieIndex", "Movies");
        }

        public ActionResult New()
        {
            var movie = new Models.Movies();
            return View("NewMovie", movie);
        }
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}