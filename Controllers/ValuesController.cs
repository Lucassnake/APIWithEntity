using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using APIWithEntity.Domain;
using APIWithEntity.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIWithEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroContext _context;
        public ValuesController(HeroContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "API started" };

        }

        // GET api/values/5
        [HttpGet("allhero")]
        public ActionResult GetAllHero()            
        {
            // LINQ Method
            var listHero = _context.Heros.ToList();
            //LINQ Query
            //var listHero = (from s in _context.Heros select s).ToList();
            return Ok(listHero);
        }

        [HttpGet("filter/{name}")]
        public ActionResult GetFilter(string name)
        {
            var filter = _context.Heros.Where(h => h.Name.Contains(name)).ToList();
            return Ok(filter);
        }

        // POST api/values
        [HttpPost("insert")]
        public OkObjectResult Post([FromBody] Hero character)
        {
            //context.Add(hero);
            _context.Heros.AddRange(character);
            _context.SaveChanges();
            return Ok(character);
        }

        // PUT api/values/5
        [HttpPut("update/{id}")]
        public void Put(int id, [FromBody] Hero character)
        {
            var hero = _context.Heros.Where(h => h.Id == id).FirstOrDefault();
            hero.Name = character.Name;            
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            var hero = _context.Heros.Where(x => x.Id == id).Single();
            _context.Heros.Remove(hero);
            _context.SaveChanges();
        }
    }
}
