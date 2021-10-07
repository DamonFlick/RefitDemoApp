using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAPI.Controllers
{
    [Route(template:"api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private static List<GuestModel> guests = new()
        {
            new GuestModel { Id = 1, FirstName = "Tim", LastName = "Corey" },
            new GuestModel { Id = 2, FirstName = "Sue", LastName = "Roberts" },
            new GuestModel { Id = 3, FirstName = "Damon", LastName = "Flick" }
        };

        // GET: api/<GuestsController>
        [HttpGet]
        public IEnumerable<GuestModel> Get()
        {
            return guests;
        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public GuestModel Get(int id)
        {
            return guests.Where(g => g.Id == id).FirstOrDefault();
        }

        // POST api/<GuestsController>
        [HttpPost]
        public void Post([FromBody] GuestModel value)
        {
            guests.Add(value);
        }

        // PUT api/<GuestsController>/5
        [HttpPut(template: "{id}")]
        public void Put(int id, [FromBody] GuestModel value)
        {
            guests.Remove(guests.Where(g => g.Id == id).FirstOrDefault());
            guests.Add(value);
        }

        // DELETE api/<GuestsController>/5
        [HttpDelete(template: "{id}")]
        public void Delete(int id)
        {
            guests.Remove(guests.Where(g => g.Id == id).FirstOrDefault());
        }
    }
}
