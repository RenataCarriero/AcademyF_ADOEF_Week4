using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPostDataAnnotation
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        //fk
        public string BlogUrl { get; set; }
        
        [ForeignKey(nameof(BlogUrl))]
        public Blog Blog { get; set; } //nav prop
    }
}