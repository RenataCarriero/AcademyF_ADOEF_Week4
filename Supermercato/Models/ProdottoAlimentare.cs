using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Models
{
    public class ProdottoAlimentare : Prodotto
    {
        public DateTime DataScadenza { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Scadenza: {DataScadenza.ToShortDateString()}"; 
        }
    }
}
