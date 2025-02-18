using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        [HttpGet]
        [Route("api/movies")]
        public IHttpActionResult GetMovies()
        {
            var dbMovies = _context.Movies.ToList();
            var result = dbMovies.Select(Mapper.Map<Movies, MoviesDTO>);
            return Ok(result);
        }

        //GET /api/customers/{id}
        [HttpGet]
        public IHttpActionResult GetMoviesById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MoviesDTO>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovies(MoviesDTO dtoObj)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var dbObj = Mapper.Map<MoviesDTO, Movies>(dtoObj);
            _context.Movies.Add(dbObj);
            _context.SaveChanges();

            dtoObj.Id = dbObj.Id;

            return Created(new Uri(Request.RequestUri + "/" + dtoObj.Id), dtoObj);
        }

        //PUT /api/movies/{id}
        [HttpPut]
        [Route("api/movies/edit/{id}")]
        public IHttpActionResult UpdateMovie(int id, MoviesDTO dtoObj)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            if(id != 0)
            {
                var dbObj = _context.Movies.FirstOrDefault(x => x.Id == id);
                if(dbObj != null)
                {
                    Mapper.Map(dtoObj, dbObj);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (id == 0)
                return BadRequest("Invalid Id");

            var dbObj = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (dbObj == null)
                return NotFound();

            _context.Movies.Remove(dbObj);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}
