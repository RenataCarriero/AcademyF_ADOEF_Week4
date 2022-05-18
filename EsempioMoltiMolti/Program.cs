// See https://aka.ms/new-console-template for more information
using EsempioMoltiMolti;

Console.WriteLine("Hello, World!");

using(var ctx= new MyContext())
{
    ctx.Database.EnsureCreated();
}
