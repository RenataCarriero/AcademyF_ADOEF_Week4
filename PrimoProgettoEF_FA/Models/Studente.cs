using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimoProgettoEF_FA.Models
{
    public class Studente
    {
        public int StudentId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime? DataNascita { get; set; }

        public ICollection<Esame> Esami { get; set; }
    }
}
