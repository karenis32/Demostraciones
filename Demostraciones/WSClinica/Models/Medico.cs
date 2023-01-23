using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WSClinica.Models;
using WSClinica.Data;

namespace WebApiLibros.Models
{
    [Table("Medico")]
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [ForeignKey("EspecialidadId")]
        public int EspecialidadId { get; set; }
        public int Matricula { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public Clínica clinica { get; set; }

        public List<Paciente> ListaPacientes { get; set; }

        public Especialidad Especialidad { get; set; }

    }
}
