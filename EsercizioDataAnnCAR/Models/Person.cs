using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioDataAnnCAR.Models
{
    internal class Person
    {
        [Key]
        [MinLength(16), MaxLength(16)]
        public string CodiceFiscale{ get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public override string ToString()
        {
            return $"{CodiceFiscale} - {Nome} {Cognome} ";
        }
    }
}
