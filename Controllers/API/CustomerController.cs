using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomerController : ApiController
    {

        private readonly ApplicationDbContext _Context;



        //Constructor
        public CustomerController()
        {
            _Context = new ApplicationDbContext();
        }


        //Get/api/customer [List Of Customers]
        [HttpGet] //By Default All Fuction is [Get]
        public IEnumerable<Customeer> GetCustomeers()
        {
            return _Context.Customeers.ToList();
        }



        //Get /api/customer/1  [one Customer]
        public Customeer Customeer(int id)
        {
            var customer = _Context.Customeers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            //Else
            return customer;
        }


        //Post/api/Customer
        [HttpPost]
        public Customeer CreateCustomer(Customeer customeer)
        {
            if (!ModelState.IsValid) //Validation
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            //Else
            _Context.Customeers.Add(customeer);
            _Context.SaveChanges();

            return customeer;
        }

        //Put/api/customer
        [HttpPut]
        public void UpdateCustomeer(int id ,Customeer customeer)
        {
            if (!ModelState.IsValid)//Validation
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            //To Select The Customer I  Clicked on 
            var CustomerInDb = _Context.Customeers.SingleOrDefault(c => c.Id == id);


            //Validation om The [Id] That I Select it.
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            //Else
            CustomerInDb.Name = customeer.Name;
            CustomerInDb.BirthDate = customeer.BirthDate;
            CustomerInDb.IsSubscribedToNewsLetter = customeer.IsSubscribedToNewsLetter;
            CustomerInDb.MemberShipTypeId = customeer.MemberShipTypeId;

            _Context.SaveChanges();
            
        }



        //Delete /api/Customer
        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            var customerInDb = _Context.Customeers.SingleOrDefault(c => c.Id == id);

            //Validation On Customer That I select it.
            if (customerInDb ==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            //Else
            _Context.Customeers.Remove(customerInDb);
            _Context.SaveChanges();

            

        }
    }
}
