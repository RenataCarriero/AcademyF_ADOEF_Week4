using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Models
{
    public class Dipendente : IEntity
    {
        public string Codice { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }

        public int? RepartoNumero { get; set; }
        public Reparto Reparto { get; set; }

        public override string ToString()
        {
            return $"{Codice} - {Nome} {Cognome} - {DataNascita.ToShortDateString()} - reparto: {Reparto}";
        }
    }
}
