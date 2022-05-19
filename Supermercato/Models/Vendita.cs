using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Models
{
    public class Vendita
    {
        public int NumeroVendita { get; set; }
        public int Quantita { get; set; }
        public DateTime DataVendita { get; set; }

        public string CodiceProdotto { get; set; }
        public Prodotto Prodotto { get; set; }

        public override string ToString()
        {
            return $"{NumeroVendita} - {Prodotto} - {Quantita} - {DataVendita.ToShortDateString()}";
        }
    }
}
