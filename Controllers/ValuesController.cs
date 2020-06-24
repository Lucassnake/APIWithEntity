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
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "API started" };

        //}

        // GET api/values/5
        [HttpGet]
        public ActionResult Get()
        {
            var listHero = _context.Heros.ToList();
            return Ok(listHero);
        }

        // GET api/values/5
        [HttpGet("update")]
        public ActionResult Get(int id)
        {
            var hero = new Hero { Name = "Iron Man" };
            _context.Heros.Add(hero);
            _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost("insert")]
        public OkObjectResult Post([FromBody] Hero hero)
        {
            //context.Add(hero);
            //context.Remove(hero);
            _context.Heros.Add(hero);
            _context.SaveChanges();

            return Ok(hero);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
