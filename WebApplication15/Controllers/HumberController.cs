using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication15.Controllers
{
    [MyAuthentication]
    [RoutePrefix("api/humber")]
    public class HumberController : ApiController
    {
        private HumberContext _context;

        public HumberController()
        {
            _context = new HumberContext();
        }

        [HttpGet]
        [Route("{version}/{id}")]
        [ResponseType(typeof(Customer))]
        [HumberActionFilter]
        public IHttpActionResult Get(int version, Guid id, string Name)
        {

            switch (version)
            {
                case 1:
                    break;
                case 2:
                    break;

            }

            Customer cust = _context.
                Customers.
                SingleOrDefault(c => c.Id == id);

            if (cust == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cust);
            }
        }

        [HttpGet]
        [Route("v2/{id}/{Name}")]
        [ActionName("MumboJumbo")]
        public IHttpActionResult Get(Guid id, string Name)
        {
            Customer cust = _context.
                Customers.
                SingleOrDefault(c => c.Id == id);

            if (cust == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cust);
            }
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Ok(customer.Id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpPut]
        [Route("")]
        public IHttpActionResult Put([FromBody] Customer customer)
        {
            Customer custFound = 
                _context.Customers.Single(c => c.Id == customer.Id);

            if (custFound == null)
            {
                return NotFound();
            }
            else
            {
                _context.Entry(custFound).
                    CurrentValues.SetValues(customer);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            Customer custToDelete = 
                _context.Customers.
                Single(c => c.Id == id);

            if (custToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _context.Customers.Remove(custToDelete);
                _context.SaveChanges();
                return Ok();
            }
        }

    }
}
