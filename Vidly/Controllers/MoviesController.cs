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

        public ActionResult Edit(int id)
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

            var obj = new MovieFormViewModel
            {
                Movie = dataObj
            };
            

            return View("MovieForm",obj);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("MovieForm", model);
            }

            if (model.Movie.Id == 0)
            {
                _context.Movies.Add(model.Movie);
            }
            else
            {
                var movie = _context.Movies.SingleOrDefault(x => x.Id == model.Movie.Id);
                if (movie != null)
                {
                    movie.Title = model.Movie.Title;
                    movie.DateReleased = model.Movie.DateReleased;
                    movie.PiecesInStock = model.Movie.PiecesInStock;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("MovieIndex", "Movies");
        }

        public ActionResult New()
        {
            var obj = new MovieFormViewModel()
            {
                Movie = new Models.Movies()
            };
            return View("MovieForm",obj);
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