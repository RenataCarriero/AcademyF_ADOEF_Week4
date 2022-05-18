// See https://aka.ms/new-console-template for more information
using AcademyF_ADOEF.PrimoEsempioEF;
using AcademyF_ADOEF.PrimoEsempioEF.Models;

Console.WriteLine("Hello, World!");

using(var ctx= new BlogPostContext())
{
    ctx.Database.EnsureCreated();

    //inserire un blog
    //Blog blog1 = new Blog() { Name = "myBlog", Author = "Renata" };
    //ctx.Blogs.Add(blog1);

    //Blog blog2 = new Blog() { Name = "Blog di Chiara Ferragni", Author = "Chiara Ferragni" };
    //ctx.Blogs.Add(blog2);
    //ctx.SaveChanges();

    Console.WriteLine("Tutti i blogs sono: ");
    foreach (var item in ctx.Blogs)
    {
        Console.WriteLine(item.ToString());
    }

    var blogFerragni = ctx.Blogs.Where(b => b.Author.Contains("Ferragni"));
    Console.WriteLine("Tutti i blogs dei Ferragni sono: ");
    foreach (var item in blogFerragni)
    {
        Console.WriteLine(item.ToString());
    }

    var myBlog = ctx.Blogs.Find(1);
    var post = AddPost(myBlog);
    ctx.Posts.Add(post);
    ctx.SaveChanges();

}

Post AddPost(Blog? selectedBlog)
{
    return new Post()
    {
        Text = "New post per il mio blog",
        Date = DateTime.Now,
        Blog = selectedBlog,
    };
}