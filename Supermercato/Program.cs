// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Realizzare un sistema informativo relativo ad un supermercato. 
//Si richiede di tenere traccia delle informazioni relative all’entità Reparto caratterizzato da
//Numero (int) Nome(string)
//A ciascun reparto possono appartenere uno o più Dipendenti con i seguenti dati
//Codice (string), Cognome(string), Nome(string), Data di nascita (DateTime).
//Una caratteristica dei reparti è quella di contenere un certo numero di Prodotti di cui si conosce 
//Codice (string), Descrizione(string), Prezzo(decimal).
//Si vuole inoltre tenere traccia delle Vendite relative a ciascun prodotto.
//Ciascuna vendita sarà caratterizzata da 
//Numero vendita (int PK), Quantità(int), Data di vendita (DateTime).
//Realizzare il modello ER della base di dati descritta e le tabelle del database con EF.


//CREO IL MODELLO E-R (concettuale)
//CREO IL MODELLO CON LE CLASSI
//CREO IL CONTEXT 
//ADATTO IL MODELLO AL DB DI ENTITY FRAMEWORK CON DATA ANNOTATION 
//FLUENT API
//CREO IL DATABASE (CON MIGRATION)
//--
// Add-Migration NomeMigration
// Update-Database
//--
//CREO IL REPOSITORY --  
//CREO L'INTERFACCIA CON L'UTENTE


bool continua = true;
while (continua)
{
    continua = GestoreSupermercato.SchermoMenu();
}