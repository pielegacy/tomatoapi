using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TomatoAPI.Controllers
{
    [Route("api/[controller]")]
    public class TomatosController : Controller
    {
        // GET api/Tomatos
        [HttpGet]
        public IEnumerable<Tomato> Get()
        {
            using (TomatoDb db = new TomatoDb())
            {
                return db.Tomatos.ToList();
            }
        }

        // GET api/Tomatos/5
        [HttpGet("{id}")]
        public Tomato Get(int id)
        {
            using (TomatoDb db = new TomatoDb())
            {
                return db.Tomatos.First(t => t.Id == id);
            }
        }

        // POST api/Tomatos
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            Tomato posted = value.ToObject<Tomato>();
            using (TomatoDb db = new TomatoDb())
            {
                db.Tomatos.Add(posted);
                db.SaveChanges();
            }
        }

        // PUT api/Tomatos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]JObject value)
        {
            Tomato posted = value.ToObject<Tomato>();
            posted.Id = id; // Ensure an id is attached
            using (TomatoDb db = new TomatoDb())
            {
                db.Tomatos.Update(posted);
                db.SaveChanges();
            }
        }

        // DELETE api/Tomatos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (TomatoDb db = new TomatoDb())
            {
                if (db.Tomatos.Where(t => t.Id == id).Count() > 0) // Check if element exists
                    db.Tomatos.Remove(db.Tomatos.First(t => t.Id == id));
                db.SaveChanges();
            }
        }
    }
}
