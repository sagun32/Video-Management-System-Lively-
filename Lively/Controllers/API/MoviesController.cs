using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lively.Models;
using Lively.Dtos;
using AutoMapper;

namespace Lively.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET/api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        // GET/api/movies/1
        public IHttpActionResult GetMovie(int ID)
        {
            var movie= _context.Movies.SingleOrDefault(c => c.ID == ID);

            if (movie== null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST/api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie= Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.ID = movie.ID;

            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }

        // PUT/api/movies/1
        [HttpPut]
        public void UpdateMovie(int ID, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(c => c.ID == ID);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        // DELETE/api/movies/1
        [HttpDelete]
        public void DeleteMovie(int ID)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.ID == ID);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
