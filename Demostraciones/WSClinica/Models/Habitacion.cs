using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WSClinica.Models;
using System.Collections.Generic;

namespace WSClinica.Models
{
    [Table ("Habitacion")]
    public class Habitacion
    {
        public int Id { get; set; }

        //[RegularExpression("@^[A]{3}[0-9]{3}")]
        public string Numero { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Estado { get; set; }

        [ForeignKey("ClinicaID")]
        public int ClinicaID { get; set; }

        public Clínica Clinica { get; set; }

    }
}
