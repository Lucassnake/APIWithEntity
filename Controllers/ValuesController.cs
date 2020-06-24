using System.Collections.Generic;
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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "API started" };

        }

        // GET api/values/insert
        [HttpGet("teste")]
        public ActionResult<string> Get(int id)
        {
            var hero = new Hero(); //{ Name = "Iron Man" };
            //using (var context = new HeroContext())
            //{
            //    //context.Add(hero);
            //    context.Remove(hero);
            //    context.Heros.Add(hero);
            //}
           
            return Ok();
        }

        // POST api/values
        [HttpPost("insert")]
        public OkObjectResult Post([FromBody] Hero hero)
        {
            using (var context = new HeroContext())
            {
                //context.Add(hero);
                //context.Remove(hero);
                context.Heros.Add(hero);
            }
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
