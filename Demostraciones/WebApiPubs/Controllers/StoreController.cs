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
    public class StoreController : ControllerBase
    {
        private readonly pubsContext context;

        public StoreController(pubsContext context)
        {

            this.context = context;

        }

        //GET: api/store
        [HttpGet]
        public ActionResult<IEnumerable<Store>> Get()
        {
            return context.Stores.ToList();
        }


        // GET api/store/5
        [HttpGet("{id}")]
        public ActionResult<Store> GetbyId(string id)
        {
            Store store = (from a in context.Stores
                           where a.StorId == id
                           select a).SingleOrDefault();

            return store;

        }


        //POST api/store
        [HttpPost]
        public ActionResult Post(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Stores.Add(store);
            context.SaveChanges();
            return Ok();
        }


        //UPDATE
        // PUT api/store/2
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Store store)
        {
            if (id != store.StorId)
            {
                return BadRequest();
            }

            context.Entry(store).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        //DELETE api/publisher/2
        [HttpDelete("{id}")]

        public ActionResult<Store> Delete(string id)
        {
            var store = context.Stores.Find(id);
            if (store == null)
            {
                return NotFound();
            }

            List<Sale> sales = (from a in context.Sales
                                where store.StorId == id
                                select a).ToList();

            if (sales.Count != 0)
            {
                foreach (Sale a in sales)
                {
                    context.Sales.Remove(a);
                    context.SaveChanges();
                }
            }
            context.Stores.Remove(store);
            context.SaveChanges();

            return store;

        }


        // GET api/store/name
        [HttpGet("name/{name}")]
        public ActionResult<Store> GetbyName(string name)
        {
            Store store = (from a in context.Stores
                           where a.StorName == name
                           select a).SingleOrDefault();

            return store;

        }

        //GET: api/store/zip
        [HttpGet("listado/{zip}")]//ruta personalizada
        public ActionResult<IEnumerable<Store>> GetbyZip(string zip)
        {
            List<Store> stores = (from a in context.Stores
                                  where a.Zip == zip
                                  select a).ToList();
            return stores;
        }

        //GET: api/store/city
        [HttpGet("listado/{city}/{state}")]//ruta personalizada
        public ActionResult<IEnumerable<Store>> GetbyCityState(string city, string state)
        {
            List<Store> stores = (from a in context.Stores
                                  where a.City == city && a.State == state
                                  select a).ToList();
            return stores;
        }
    }
}

