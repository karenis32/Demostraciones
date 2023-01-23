using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiLibros.Models;

namespace WSClinica.Models
{
    [Table("Clínica")]
    public class Clínica
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        public DateTime? FechaInicioActividades { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        public List<Habitacion> ListaHabitaciones { get;set; }
        public List<Medico> ListaMedicos { get; set; }
        public List<Paciente> ListaPacientes { get; set; }

    }
}
