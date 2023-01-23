using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DBLibrosContext context;

        public LibroController(DBLibrosContext context)
        {

            this.context = context;

        }

        //GET api/libro
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }

        // GET api/libro/3
        [HttpGet("{id}")]
        public ActionResult<Libro> GetbyId(int id)
        {
            Libro libro = (from a in context.Libros
                           where a.Id == id
                           select a).SingleOrDefault();

            return libro;

        }

        //GET api/libro/2
        [HttpGet("listado/{AutorId}")]
        public ActionResult<IEnumerable<Libro>> GetbyAutorId(int autorId)
        {
            List<Libro> libros = (from a in context.Libros
                                   where a.AutorId == autorId
                                   select a).ToList();
            return libros;
        }

        //POST api/libro
        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }

        // PUT api/libro/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }

        //DELETE api/libro/2
        [HttpDelete]
        public ActionResult<Libro> Delete(Libro libro) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Libros.Remove(libro);
            context.SaveChanges();

            return libro;
        }
    }
}
