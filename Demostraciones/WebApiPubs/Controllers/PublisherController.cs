using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiPubs.Models;

namespace WebApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        private readonly pubsContext context;

        public PublisherController(pubsContext context)
        {

            this.context = context;

        }

        //GET: api/publisher
        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> Get()
        {
            return context.Publishers.ToList();
        }


        // GET api/publisher/5
        [HttpGet("{id}")]
        public ActionResult<Publisher> GetbyId(string id)
        {
            Publisher publisher = (from a in context.Publishers
                           where a.PubId == id
                           select a).SingleOrDefault();

            return publisher;

        }


        //POST api/publisher
        [HttpPost]
        public ActionResult Post(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Publishers.Add(publisher);
            context.SaveChanges();
            return Ok();
        }


        //UPDATE
        // PUT api/publisher/2
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Publisher publisher)
        {
            if (id != publisher.PubId)
            {
                return BadRequest();
            }

            context.Entry(publisher).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        //DELETE api/publisher/2
        [HttpDelete]
        public ActionResult<Publisher> Delete(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Publishers.Remove(publisher);
            context.SaveChanges();

            return publisher;
        }

    }
}
