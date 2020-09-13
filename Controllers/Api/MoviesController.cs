using AutoMapper;
using Paranoid.DTOs;
using Paranoid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Paranoid.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movie.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/movies/1

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movie == null) {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }

        //POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movie.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT / api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movie.SingleOrDefault(c=> c.Id == id);

            if (movieInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            
            //movieInDb.Name = movieDto.Name; 
            //movieInDb.ReleaseDate = movieDto.ReleaseDate;
            //movieInDb.DateAdded = movieDto.DateAdded;
            //movieInDb.GenreId = movieDto.GenreId;
            //movieInDb.Stock = movieDto.Stock;

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/Movie/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
