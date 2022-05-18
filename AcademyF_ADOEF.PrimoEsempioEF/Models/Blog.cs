using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_ADOEF.PrimoEsempioEF.Models
{
    public class Blog
    {
        public int BlogId { get; set; } //id o ID
        public string Name { get; set; }
        public string Author { get; set; }
        public ICollection<Post> Posts { get; set; }

        public override string ToString()
        {
            return $"{BlogId} - Nome: {Name} - Autore: {Author}";
        }
    }
}
