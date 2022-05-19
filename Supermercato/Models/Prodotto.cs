using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Models
{
    public class Prodotto : IEntity
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }

        public int RepartoNumero { get; set; }
        public Reparto Reparto { get; set; }

        public ICollection<Vendita> Vendite { get; set; } = new List<Vendita>();

        public override string ToString()
        {
            return $"{Codice} - {Descrizione} - {Prezzo} euro - reparto: {Reparto}";
        }
    }
}
