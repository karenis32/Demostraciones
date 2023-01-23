using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using WSClinica.Models;
using WebApiLibros.Models;

namespace WSClinica.Models
{
    [Table("Especialidad")]
    public class Especialidad
    {
        public int EspecialidadId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        public List<Medico> medicos { get; set; }

    }
}
