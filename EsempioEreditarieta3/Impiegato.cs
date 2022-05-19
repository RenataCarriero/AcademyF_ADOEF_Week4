using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempioEreditarieta3
{
    [Table("Impiegato")]
    internal class Impiegato : Person
    {
        public int AnniServizio { get; set; }

        public int Eta { get; set; }
    }
}
