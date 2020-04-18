using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Vidly.Models;
using My_Vidly.viewmodel;


namespace My_Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [Route("Movies/New")]
        public ActionResult New()
        {

            var genreTypes = _context.GenreTypes.ToList();


            var viewModel = new MovieFormModel()
            {
                GenreTypes = genreTypes
            };
            return View("MovieForm",viewModel);

        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        [Route("Movies/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormModel(movie)
            {
                GenreTypes = _context.GenreTypes.ToList()
            };
            return View("MovieForm", viewModel);

        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormModel(movie)
                {
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.DateAdded= movie.DateAdded;
                movieInDb.ReleaseDate= movie.ReleaseDate;
                movieInDb.ReleaseDate= movie.ReleaseDate;
                movieInDb.InStock= movie.InStock;


            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }

        // GET: Movies
        public ActionResult Index()
        {

            if(User.IsInRole("CanManageMovies"))
            return View("ViewIndex");

            return View("ReadOnlyViewIndex");

        }

    

        [Route("movies/released/{year:range(2000,2020)}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year= {year} month= {month}");
        }
    }
}