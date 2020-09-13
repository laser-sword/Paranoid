using Microsoft.Ajax.Utilities;
using Paranoid.Models;
using Paranoid.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Paranoid.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController() {

            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movie.Include(x => x.Genre).ToList();
            return View(movies);
        }


        public ActionResult Details(int id) {

            var movies = _context.Movie.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

            if (movies == null)
                return HttpNotFound();
               

            return View(movies);
        }
        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie  { Id = 1, Name = "Shithouse!"},
        //        new Movie  { Id = 2, Name = "Tits!"}
        //    };
        //}

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "ASS" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Dumbass 1"},
                new Customer { Name = "Dumbass 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ViewResult New()
        {
    
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {

                Genre = genre
            };

            return View("MovieForm", viewModel);
        }
        //public ActionResult Edit(int id) {
        //    return Content("id=" + id);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {

                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            
            {
                var movieInDb = _context.Movie.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                //movieInDb.DateAdded = movie.DateAdded;
                movieInDb.Stock = movie.Stock;
            }


                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        //public ActionResult Index(int? pageIndex, string sortBy) {
        //    if (pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}&sortBy{1}", pageIndex, sortBy));
        //}
        //[Route("movies/released/{year}/{month:regex(\\{4})}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}







        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}