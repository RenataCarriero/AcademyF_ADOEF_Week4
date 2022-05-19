using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempioEreditarieta3
{
    [Table("Dirigente")]
    internal class Dirigente: Person
    {
        public string Reporto { get; set; }
        public int NumeroDipendenti { get; set; }
    }
}
