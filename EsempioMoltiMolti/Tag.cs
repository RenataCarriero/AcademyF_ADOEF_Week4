using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsempioMoltiMolti
{
    internal class Tag
    {
        public int TagId { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
