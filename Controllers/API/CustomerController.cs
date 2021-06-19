using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dto;
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



        //Get/api/customer     [List Of Customers]
        [HttpGet] //By Default All Fuction is [Get]
        public IEnumerable<CustomerDto> GetCustomeers()
        {
            return _Context.Customeers.
                Include(c =>c.MemberShipType)
                .ToList()

                //select data from [Entity]{Customeer}
                //and make [ViewModel]{CustomerDto} show it.
                .Select(Mapper.Map<Customeer ,CustomerDto>);
        }



        //Get /api/customer/1  [one Customer]
        public IHttpActionResult Customeer(int id)
        {
            var customer = _Context.Customeers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();


            //Else
            
            return Ok (Mapper.Map<Customeer , CustomerDto>(customer));
        }


        //Post/api/Customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) //Validation
                return BadRequest();


            //Else

            var customer = Mapper.Map<CustomerDto, Customeer>(customerDto);
            _Context.Customeers.Add(customer);
            _Context.SaveChanges();

            customerDto.Id = customer.Id;
            return  Created
                (new Uri(Request.RequestUri + "/" + customer.Id) ,  customerDto);
          
        }


        //Put/api/customer
        [HttpPut]
        public void UpdateCustomeer(int id ,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)//Validation
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            //To Select The Customer I  Clicked on 
            var CustomerInDb = _Context.Customeers.SingleOrDefault(c => c.Id == id);


            //Validation om The [Id] That I Select it.
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            //Else

           Mapper.Map(customerDto, CustomerInDb);
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
