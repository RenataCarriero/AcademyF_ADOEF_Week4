using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostDataAnnotation
{
    [Table("TabellaBlog")]
    public class Blog
    {
        [Key]
        public string Url { get; set; }


        [Required]
        public string Name { get; set; } //string? per nullable

        [MaxLength(20)]
        public string Author { get; set; }
        [NotMapped]
        public string Descrizione { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
