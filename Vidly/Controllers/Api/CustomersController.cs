using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customersQuery = _context.Customers
                            .Include(c => c.MembershipType);

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET /api/customers/{name}
        [HttpGet]
        public IHttpActionResult GetCustomerById(string name)
        {
            var customers = _context.Customers
                           .Where(x => x.Name.Contains(name))
                           .Select(c => new { c.Name }) // Only return Name property
                           .ToList();

            return Ok(customers); // Always return an array, even if empty
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/{id}
        [HttpPut]
        public int UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (id != 0)
            {
                var dbObj = _context.Customers.FirstOrDefault(x => x.Id == id);
                if (dbObj != null)
                {
                    Mapper.Map(customerDto, dbObj);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                _context.SaveChanges();
                return id;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("api/customers/{id}")]  // Ensure correct routing
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (id == 0)
                return BadRequest("Invalid ID");

            var customerInDb = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(id); // Return HTTP 200 OK with deleted ID
        }

    }
}
