using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.API
{
    public class RentalController : ApiController
    {

        private readonly  ApplicationDbContext Context;
        public RentalController()
        {
            Context = new ApplicationDbContext();
        }


       [HttpPost] 
       public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            

            var customer = Context.Customeers
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

           

            var movies = Context.Movies
                .Where(m => newRental.MoviesId.Contains(m.Id)).ToList();


           

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is Not Available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Movie = movie,
                    Customeer = customer,
                    DataRented = DateTime.Now
                };
                Context.Rentals.Add(rental);
            }

            Context.SaveChanges();
            return Ok();

             
       }
       
    }
}
