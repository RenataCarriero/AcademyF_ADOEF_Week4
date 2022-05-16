// See https://aka.ms/new-console-template for more information
Console.WriteLine("--------Esercitazione 1 --------");
string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ticketing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


ConnectedModeClient.ConnectionString = connectionStringSQL;
bool quit = false;
do
{
    Console.WriteLine($"===========MENU==========\n");
    Console.WriteLine("[1] - Elenco Tickets\n");
    Console.WriteLine("[2] - Aggiungi Ticket\n");
    Console.WriteLine("[3] - Elimina Ticket\n");
    Console.WriteLine("[q] - QUIT\n");

    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "1":
            //lista di tickets
            ConnectedModeClient.ListTickets();
            break;
        case "2":
            //aggiungi ticket
            ConnectedModeClient.AddTicket();
            break;
        case "3":
            //elimina ticket
            ConnectedModeClient.DeleteTicket();
            break;
        case "q":
            quit = true;
            break;
        default:
            Console.WriteLine("Comando sconosciuto");
            break;

    }
} while (!quit);