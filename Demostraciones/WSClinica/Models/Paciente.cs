using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WSClinica.Models;
using System.Collections.Generic;
using WSClinica.Data;
using WebApiLibros.Models;

namespace WSClinica.Models
{
    [Table ("Paciente")]
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        public int NroHistClinica { get; set; }

        [ForeignKey ("MedicoId")]
        public int MedicoId { get; set; }

        public Medico Medico { get; set; }

        public Clínica clinica { get; set; }

    }
}
