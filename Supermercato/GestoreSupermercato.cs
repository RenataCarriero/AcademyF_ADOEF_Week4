// See https://aka.ms/new-console-template for more information
using Supermercato.Models;
using Supermercato.Repository;

internal static class GestoreSupermercato
{
    static IRepositoryReparto repoReparto = new RepositoryReparto();
    static IRepository<Dipendente> repoDipendente = new RepositoryDipendente();
    static IRepository<Prodotto> repoProdotto = new RepositoryProdotto();
    static IRepositoryVendita repoVendita = new RepositoryVendita();
    internal static bool SchermoMenu()
    {
        Console.WriteLine("Benvenuto");
        Console.WriteLine("1. Aggiungi reparto");
        Console.WriteLine("2. Aggiungi dipendente");
        Console.WriteLine("3. Aggiungi prodotto");
        Console.WriteLine("4. Visualizza dati");
        Console.WriteLine("5. Per uscire");
        int scelta = -1;
        Console.Write("Scelta ->");
        bool verifica = Int32.TryParse(Console.ReadLine(), out scelta);
        while (scelta > 5 || scelta < 0 || verifica == false)
        {
            Console.WriteLine("Inserisci un valore corretto");
            verifica = Int32.TryParse(Console.ReadLine(), out scelta);
        }
        return GestireScelta(scelta);
    }

    private static bool GestireScelta(int scelta)
    {
        bool continua = true;
        switch (scelta)
        {
            case 1:
                AggiungiReparto();
                break;
            case 2:
                AggiungiDipendente();
                break;
            case 3:
                AggiungiProdotti();
                break;
            case 4:
                Stampa();
                break;
            default:
                continua = false;
                Console.WriteLine("Arrivederci");
                break;
        }
        return continua;
    }

    private static void Stampa()
    {
        Console.WriteLine("Quale entità vuoi stampare?");
        Console.WriteLine("1. Reparti - 2. Dipendenti - 3. Prodotti");
        int scelta = int.Parse(Console.ReadLine());
        if (scelta == 1)
        {
            var reparti = repoReparto.GetAll();
            StampaCollection<Reparto>(reparti);
        }
        else if (scelta == 2)
        {
            var dipendenti = repoDipendente.GetAll();
            StampaCollection<Dipendente>(dipendenti);
        }
        else
        {
            StampaCollection<Prodotto>(repoProdotto.GetAll());
        }
    }

    private static void StampaCollection<T>(ICollection<T> collection) where T : class
    {
        if (collection.Count == 0)
        {
            Console.WriteLine("Lista vuota");
            return;
        }
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }

    private static void AggiungiProdotti()
    {
        Prodotto prodottoDaAggiungere = new Prodotto();
        Console.WriteLine("Inserisci il codice");
        string codice = Console.ReadLine();
        Console.WriteLine("Inserisci descrizione");
        string descrizione = Console.ReadLine();
        Console.WriteLine("Inserisci il prezzo");
        decimal prezzo;
        bool verificaPrezzo = decimal.TryParse(Console.ReadLine(), out prezzo);
        while (!verificaPrezzo || prezzo < 0)
        {
            verificaPrezzo = decimal.TryParse(Console.ReadLine(), out prezzo);
        }
        var reparti = repoReparto.GetAll();
        foreach (var item in reparti)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Scegli reparto:");
        int numeroReparto = int.Parse(Console.ReadLine());
        //controllo se esiste un reparto con quell'id/numero
        var repEsistente = repoReparto.GetByNumero(numeroReparto);
        if (repEsistente == null)
        {
            Console.WriteLine("Reparto errato o inesistente");
        }
        else
        {
            Console.WriteLine("Che tipo di prodotto vuoi inserire? 1-Alimentare 2-Casalingo");
            int tipoProdotto;
            bool verifica = Int32.TryParse(Console.ReadLine(), out tipoProdotto);
            while (tipoProdotto > 3 || tipoProdotto < 0 || verifica == false)
            {
                Console.WriteLine("Inserisci un valore corretto");
                verifica = Int32.TryParse(Console.ReadLine(), out tipoProdotto);
            }

            if (tipoProdotto == 1)
            {
                Console.WriteLine("Inserisci data scadenza");
                DateTime scadenza = VerificaData();
                prodottoDaAggiungere = new ProdottoAlimentare()
                {
                    Codice = codice,
                    Descrizione = descrizione,
                    Prezzo = prezzo,
                    DataScadenza = scadenza,
                    RepartoNumero = numeroReparto
                };
            }
            else if (tipoProdotto == 2)
            {
                Console.WriteLine("Inserisci marchio");
                string marchio = Console.ReadLine();
                prodottoDaAggiungere = new ProdottoCasalingo()
                {
                    Codice = codice,
                    Descrizione = descrizione,
                    Prezzo = prezzo,
                    Marchio = marchio,
                    RepartoNumero = numeroReparto
                };
            }
            repoProdotto.Create(prodottoDaAggiungere);
            Console.WriteLine("Prodotto aggiunto");
        }
    }

    private static void AggiungiDipendente()
    {
        Console.Write("Codice dipendente: ");
        string codice = Console.ReadLine();
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Cognome: ");
        string cognome = Console.ReadLine();
        Console.Write("Data di nascita (dd/mm/yyyy)");
        DateTime dataNascita = VerificaData();
        var reparti = repoReparto.GetAll();
        foreach (var item in reparti)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Scegli reparto:");
        int numeroReparto = int.Parse(Console.ReadLine());
        //controllo se esiste un reparto con quell'id/numero
        var repEsistente = repoReparto.GetByNumero(numeroReparto);
        if (repEsistente == null)
        {
            Console.WriteLine("Reparto errato o inesistente");
        }
        else
        {
            Dipendente dipendente = new Dipendente()
            {
                Codice = codice,
                Nome = nome,
                Cognome = cognome,
                DataNascita = dataNascita,
                RepartoNumero = numeroReparto
            };
            repoDipendente.Create(dipendente);
            Console.WriteLine("Dipendente aggiunto");
        }

    }

    private static DateTime VerificaData()
    {
        bool verifica = DateTime.TryParse(Console.ReadLine(), out DateTime dataNascita);
        while (!verifica)
        {
            verifica = DateTime.TryParse(Console.ReadLine(), out dataNascita);
        }
        return dataNascita;
    }

    private static void AggiungiReparto()
    {
        Console.WriteLine("Inserire nome reparto");
        string nomeReparto = Console.ReadLine();

        var repartoCreato = repoReparto.Create(new Reparto()
        {
            Nome = nomeReparto
        });

        if (repartoCreato != null)
        {
            Console.WriteLine("Reparto creato: ");
            Console.WriteLine(repartoCreato);
        }
        else
        {
            Console.WriteLine("Operazione non riuscita");
        }
    }
}