using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using WebGrease.Css.Extensions;
using  System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var context = _context.Customeers.
                Include(c => c.MemberShipType).ToList();
            return View(context);
        }

        public ActionResult Details(int id)
        {
            var context = _context.Customeers.Include(m=>m.MemberShipType).
                SingleOrDefault(c => c.Id == id);


            if (context == null)
                return HttpNotFound();

            return View(context);
        }
    }
}