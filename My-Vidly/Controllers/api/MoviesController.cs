using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using My_Vidly.DtoS;
using My_Vidly.Models;

namespace My_Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //Get /api/Customers
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies.Include(c => c.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);
        }

        //Get /api/Customers/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //Post /api/customers
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }


        //Put /api/customers/id
        [System.Web.Http.HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieDto == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);

            _context.SaveChanges();
            ;
        }

        //DELETE /api/Customers/id
        [System.Web.Http.HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }
    }
}
