using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercato.Models
{
    public class ProdottoCasalingo : Prodotto
    {
        public String Marchio { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Marchio: {Marchio}";
        }
    }
}
