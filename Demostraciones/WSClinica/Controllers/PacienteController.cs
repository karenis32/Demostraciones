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
    public class PacienteController : ControllerBase
    {
        private readonly DBWSClinicaContext context;

        public PacienteController(DBWSClinicaContext context)
        {

            this.context = context;

        }

        //GET Paciente
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get()
        {
            return context.Pacientes.ToList();
        }



        //GET BY ID - Paciente
        [HttpGet("{id}")]
        public ActionResult<Paciente> GetById(int id)
        {
            Paciente paciente = (from p in context.Pacientes
                                 where p.Id == id
                                 select p).SingleOrDefault();
            return paciente;

        }


        //POST - Paciente

        [HttpPost]
        public ActionResult Post(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(paciente);
            }
            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return Ok();
        }


        // PUT - Paciente
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }
            context.Entry(paciente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }


        //DELETE - Paciente
        [HttpDelete("{id}")]

        public ActionResult<Paciente> Delete(int id)
        {
            var paciente = (from p in context.Pacientes
                            where p.Id == id
                            select p).SingleOrDefault();
            if (paciente == null)
            {
                return NotFound();
            }
            context.Pacientes.Remove(paciente);
            context.SaveChanges();
            return paciente;


        }
    }
}
