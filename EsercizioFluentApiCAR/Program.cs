// See https://aka.ms/new-console-template for more information
using EsercizioFluentApiCAR;

Console.WriteLine("Hello, World!");


//Creare un'applicazione che consente di gestire Persone e
//relativi autovoeicoli
//Ogni persona è caratterizzata da 
//    Nome, Cognome, codice fiscale (chiave primaria), data di nascita
//Le automobili sono caratterizzate da:
//    Targa (chiave primaria), numero posti, marca, data immatricolazione

// Realizzare il database con Entity Framework e Fluent API
using (var ctx = new Context())
{
    ctx.Database.EnsureCreated();
}