using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
        public ActionResult Index()
        {
            var context = _context.Movies.
                Include(m=> m.Genre).ToList();
            return View(context);
        }
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
    }
}