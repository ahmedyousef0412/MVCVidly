using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Dto;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {

       private readonly ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            
            _context.Dispose();
        }





        // GET: Movie
        
        public ViewResult Index()
        {
            
                var context = _context.Movies.
               Include(m => m.Genre).ToList();

            if (User.IsInRole(RoleName.CanMangeMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
          



        }
        [Authorize(Roles = RoleName.CanMangeMovies)]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.
                Include(m=>m.Genre).
                SingleOrDefault(m => m.Id == id);


           
            

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [Authorize(Roles =RoleName.CanMangeMovies)]

        public ActionResult New()
        {

            var genre = _context.Genres.ToList();
            

            var ViewModel = new NewMovieViewModel
            {
                Genres = genre
            };

            return View("New",ViewModel);
        }


        [Authorize(Roles = RoleName.CanMangeMovies)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                //This Paramter[movie] I Create it in Ctor In ViewModel
                var viewModel = new NewMovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()

                };

                return View("New", viewModel);
            }
            else if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }



           
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);


               
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
               
                movieInDb.NumberInStock = movie.NumberInStock;
            }
                        
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }




        [Authorize(Roles = RoleName.CanMangeMovies)]
        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie== null)
                return HttpNotFound();
            //This Paramter[movie] I Create it in Ctor In ViewModel
            var viewModel = new NewMovieViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("New", viewModel);
        }
    }
}