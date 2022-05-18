// See https://aka.ms/new-console-template for more information
using EsercizioDataAnnCAR;
using EsercizioDataAnnCAR.Models;

Console.WriteLine("Hello, World!");

//Creare un'applicazione che consente di gestire Persone e
//relativi autovoeicoli
//Ogni persona è caratterizzata da 
//    Nome, Cognome, codice fiscale (chiave primaria), data di nascita
//Le automobili sono caratterizzate da:
//    Targa (chiave primaria), numero posti, marca, data immatricolazione

// Realizzare il database con Entity Framework e data annotation

using (var ctx = new Context())
{
    ctx.Database.EnsureCreated();

    var persona1 = new Person()
    {
        CodiceFiscale = "1234567890123456",
        Cognome = "Rossi",
        Nome = "Mario",
        DataNascita = new DateTime(2000, 01, 12)
    };
    ctx.People.Add(persona1);
    ctx.SaveChanges();

    //TODO: creare un veicolo da associare alla persona.

    foreach (var item in ctx.People)
    {
        Console.WriteLine(item);
    }

    foreach (var item in ctx.Vehicles)
    {
        Console.WriteLine(item);
    }
}