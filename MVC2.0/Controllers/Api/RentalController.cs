using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MVC2._0.DTO;
using MVC2._0.Models;

namespace MVC2._0.Controllers.Api
{
    public class RentalController : ApiController
    {

        private ApplicationDbContext _context;

        public RentalController()
        {
            _context=new ApplicationDbContext();
        }

        public IHttpActionResult GetRental()
        {
            var rental = _context.Rentals.ToList();

            return Ok(rental);
        }

        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental==null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var rentals = Mapper.Map<RentalDto, Rental>(rental);

            _context.Rentals.Add(rentals);
            _context.SaveChanges();


            rental.Id = rentals.Id;

            return Created(Request.RequestUri + "/" + rental.Id,rental);
        }

        [HttpPut]
        public void EditRental(int id, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(RentalDto, rental);
            _context.SaveChanges();

        } 
    }
}
