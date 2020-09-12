using Microsoft.Ajax.Utilities;
using Paranoid.Models;
using Paranoid.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paranoid.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie  { Id = 1, Name = "Shithouse!"},
                new Movie  { Id = 2, Name = "Tits!"}
            };
        }

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


        public ActionResult Edit(int id) {
            return Content("id=" + id);
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