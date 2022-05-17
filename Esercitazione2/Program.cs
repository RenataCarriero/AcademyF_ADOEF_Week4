// See https://aka.ms/new-console-template for more information
Console.WriteLine("=== Esercitazione 2 ===");

bool quit = false;
do
{
    Console.WriteLine($"============= Menu =============");
    Console.WriteLine();
    Console.WriteLine("[ 1 ] - Elenco Tickets\n");
    Console.WriteLine("[ 2 ] - Aggiungi Ticket\n");
    Console.WriteLine("[ 3 ] - Cancella Ticket\n");
    Console.WriteLine("[ q ] - QUIT\n");


    // scelta utente
    Console.Write("> ");
    string scelta = Console.ReadLine();
    Console.WriteLine();

    switch (scelta)
    {
        case "1":
            // list tickets
            DisconnectedModeClient.ListTickets();
            break;
        case "2":
            // add new ticket
            DisconnectedModeClient.AddTicket();
            break;
        case "3":
            // delete ticket
            DisconnectedModeClient.DeleteTicket();
            break;
        case "q":
            quit = true;
            break;
        default:
            Console.WriteLine("Comando sconosciuto.");
            break;
    }

} while (!quit);


