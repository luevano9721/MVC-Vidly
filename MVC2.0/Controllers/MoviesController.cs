using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2._0.Models;
using MVC2._0.ViewModels;

namespace MVC2._0.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie= new Movie()
        //    {
        //        Name="Shrek!"
        //    };

        //    var customers= new List<Customer>
        //    {
        //        new Customer{ Name = "customer 1"},
        //        new Customer{ Name = "customer 2"}
        //    };

        //    var viewModel= new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //    Customers = customers
        //    };

        //    return View(viewModel);
        //    //return Content("Hello world!");
        //    //return HttpNotFound();
        //    //return  new EmptyResult();
        //    //return RedirectToAction("Index", "Home", new{ page=1, sortBy="name"});
        //}

        public ActionResult index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");    
            }
            //var movies = _context.Movies
            //    .Include("Genre")
            //    .ToList();
            //return View(movies);

        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include("Genre")
                .SingleOrDefault(m => m.Id == id);
            return View(movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreTypes = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                
                Genres = genreTypes
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movies = new MovieFormViewModel(movie)
                {

                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", movies);

            }
            if (movie.Id==0)
            {
                movie.DateAdded=DateTime.Now;
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.InStock = movie.InStock;
                movieInDb.GenreId = movie.GenreId;
                

            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("index", "Movies");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movieSelected = _context.Movies.Single(m => m.Id == id);
            if (movieSelected==null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movieSelected)
            {
                
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex,sortBy));
        //}


        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year+"/"+month);
        //}
    }
}