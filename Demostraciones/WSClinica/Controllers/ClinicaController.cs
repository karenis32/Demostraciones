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
    public class ClinicaController : ControllerBase
    {
        private readonly DBWSClinicaContext context;

        public ClinicaController(DBWSClinicaContext context)
        {

            this.context = context;

        }

        //GET: api/clinica
        [HttpGet]

        public ActionResult<IEnumerable<Clínica>> Get()
        {
            return context.Clinicas.ToList();
        }

        //GET BY ID
        //GET: api/clinica/5
        [HttpGet("{id}")]
        public ActionResult<Clínica> GetById(int id)
        {
            Clínica clinica = (from a in context.Clinicas
                               where a.ID == id
                               select a).SingleOrDefault();
            return clinica;
        }

        //Post api/clinica
        [HttpPost]

        public ActionResult Post(Clínica clinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(clinica);
            }
            context.Clinicas.Add(clinica);
            context.SaveChanges();
            return Ok();
        }

        //Put
        //Put api/clinica/2

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Clínica clinica)
        {
            if (id != clinica.ID)
            {
                return BadRequest();
            }
            context.Entry(clinica).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult<Clínica> Delete(int id)
        {
            var clinica = (from a in context.Clinicas
                           where a.ID == id
                           select a).SingleOrDefault();
            if (clinica == null)
            {
                return NotFound();
            }
            context.Clinicas.Remove(clinica);
            context.SaveChanges();
            return clinica;


        }
    }
}
