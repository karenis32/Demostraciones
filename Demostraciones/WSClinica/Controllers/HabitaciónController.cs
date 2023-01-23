using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly DBWSClinicaContext context;

        public HabitacionController(DBWSClinicaContext context)
        {

            this.context = context;

        }

        //GET: api/habitacion
        [HttpGet]

        public ActionResult<IEnumerable<Habitacion>> Get()
        {
            return context.Habitaciones.ToList();
        }

        //GET BY ID
        //GET: api/habitacion/5
        [HttpGet("{id}")]
        public ActionResult<Habitacion> GetById(int id)
        {
            Habitacion habitacion = (from a in context.Habitaciones
                                     where a.Id == id
                                     select a).SingleOrDefault();
            return habitacion;
        }

        //Post api/habitacion
        [HttpPost]

        public ActionResult Post(Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(habitacion);
            }
            context.Habitaciones.Add(habitacion);
            context.SaveChanges();
            return Ok();
        }

        //Put
        //Put api/habitacion/2

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Habitacion habitacion)
        {
            if (id != habitacion.Id)
            {
                return BadRequest();
            }
            context.Entry(habitacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }


        //DELETE api/habitacion/3
        [HttpDelete("{id}")]

        public ActionResult<Habitacion> Delete(int id)
        {
            var habitacion = (from a in context.Habitaciones
                           where a.Id == id
                           select a).SingleOrDefault();
            if (habitacion == null)
            {
                return NotFound();
            }
            context.Habitaciones.Remove(habitacion);
            context.SaveChanges();
            return habitacion;


        }
    }

}
