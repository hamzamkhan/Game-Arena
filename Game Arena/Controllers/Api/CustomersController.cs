﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Game_Arena.Models;
using Game_Arena.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Game_Arena.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if(!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }
            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);


        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) // if customer is not found
            {
                return NotFound(); 
            }

            else
            {
                return Ok(Mapper.Map < Customer, CustomerDto >(customer));
            }
        }

        //POST /api/custoemrs
        [HttpPost] //only called with POST request
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;

                return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
            }
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if(customerInDb == null)
                {
                    return NotFound();
                }
                else
                {
                    Mapper.Map(customerDto, customerInDb); 
                    //passing existing objects so as to be changed and not creating new object

                    _context.SaveChanges();

                    return Ok();
                }
            }
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
