using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using WebGrease.Css.Extensions;
using  System.Data.Entity;
using Vidly.Models.ViewModels;

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

       public ActionResult New()
        {

            var memberShips = _context.MemberShipTypes.ToList();

            var Customerviewmodel = new NewCustomerViewModel
            {
                MemberShipTypes = memberShips,

            };
            return View("CustomerForm",Customerviewmodel);
        }

        public ActionResult Save(Customeer customeer)
        {

            if (customeer.Id == 0)
            {
                _context.Customeers.Add(customeer);
                
            }
            else
            {
                var customerInDb = _context.Customeers.Single(c => c.Id == customeer.Id);

                customerInDb.Name = customeer.Name;
                customerInDb.MemberShipTypeId = customeer.MemberShipTypeId;
                customerInDb.BirthDate = customeer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customeer.IsSubscribedToNewsLetter;
                

            }
            _context.SaveChanges();


            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customeers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewmodel = new NewCustomerViewModel
            {
                Customeer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewmodel);
        }
      
    }
}