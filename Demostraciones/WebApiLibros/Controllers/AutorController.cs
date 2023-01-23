using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiLibros.Models;
using WebApiLibros.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //inyección de dependencia----inicia
        //propiedad
        private readonly DBLibrosContext context;
        //contructor 
        public AutorController(DBLibrosContext context)
        {

            this.context = context;

        }
        //inyección de dependencia----fin


        //GET: api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();
        }


        // GET api/autor/5
        [HttpGet("{id}")]
        public ActionResult<Autor> GetbyId(int id)
        {
            Autor autor = (from a in context.Autores
                           where a.IdAutor == id
                           select a).SingleOrDefault();

            return autor;

        }


        //POST api/autor
        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Autores.Add(autor);
            context.SaveChanges();
            return Ok();
        }


        //UPDATE
        // PUT api/autor/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return BadRequest();
            }

            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        //GET: api/autor/33
        [HttpGet("listado/{edad}")]//ruta personalizada
        public ActionResult<IEnumerable<Autor>> GetEdad(int edad)
        {
            List<Autor> autores = (from a in context.Autores
                                   where a.Edad == edad
                                   select a).ToList();
            return autores;
        }



    }
}
