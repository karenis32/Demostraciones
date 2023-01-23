using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Models;
using WSClinica.Data;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DBWSClinicaContext context;

        public MedicoController(DBWSClinicaContext context)
        {

            this.context = context;

        }

        //GET:
        [HttpGet]

        public ActionResult<IEnumerable<Medico>> Get()
        {
            return context.Medicos.ToList();
        }


        //GET BY ID

        [HttpGet("{IdMedico}")]
        public ActionResult<Medico> GetById(int id)
        {
            Medico medico = (from a in context.Medicos
                             where a.IdMedico == id
                             select a).SingleOrDefault();
            return medico;
        }
        //Post

        [HttpPost]
        public ActionResult Post(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(medico);
            }
            context.Medicos.Add(medico);
            context.SaveChanges();
            return Ok();
        }
        //Put


        [HttpPut("{IdMedico}")]
        public ActionResult Put(int id, [FromBody] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return BadRequest();
            }
            context.Entry(medico).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }
        //Delete

        [HttpDelete("{IdMedico}")]
        public ActionResult<Medico> Delete(int id)
        {
            var medico = (from a in context.Medicos
                          where a.IdMedico == id
                          select a).SingleOrDefault();
            if (medico == null)
            {
                return NotFound();
            }
            context.Medicos.Remove(medico);
            context.SaveChanges();
            return medico;


        }
    }
}
