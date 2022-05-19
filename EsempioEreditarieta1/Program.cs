// See https://aka.ms/new-console-template for more information
using EsempioEreditarieta1;

Console.WriteLine("Hello, World!");

var impiegato1 = new Impiegato()
{
    Nome = "Mario",
    Cognome = "Rossi",
    AnniServizio = 10,
    Eta=80
};

using(var ctx=new AziendaContext())
{
    ctx.Impiegati.Add(impiegato1);
    ctx.SaveChanges();
}