// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

public static class ConnectedModeClient
{
    public static string ConnectionString { get; set; }
    public static void ListTickets()
    {
        using SqlConnection connection = new SqlConnection(ConnectionString);
        try
        {
            connection.Open();
            SqlCommand selectCommand = connection.CreateCommand();
            selectCommand.CommandType = System.Data.CommandType.Text;
            selectCommand.CommandText = "SELECT * FROM Ticket ORDER BY Data DESC";

            SqlDataReader reader = selectCommand.ExecuteReader();
            Console.Clear();
            Console.WriteLine("------Elenco Tickets------\n");
            Console.WriteLine("ID\tDescrizione\tStato\t Creato\n");
            Console.WriteLine("-------------------------");
            while (reader.Read())
            {
                string formattedDate = ((DateTime)reader["Data"]).ToString("dd-MM-yyyy");
                Console.WriteLine(reader["Id"].ToString() + "\t" + reader["Descrizione"].ToString() + "\t" +reader["Stato"].ToString() + "\t" +formattedDate);
            }
            Console.WriteLine("------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
            Console.WriteLine("-----Premi un tasto------ ");
            Console.ReadKey();
        }
    }

    
    public static void AddTicket()
    {
        using SqlConnection connection = new SqlConnection(ConnectionString);
        try
        {
            connection.Open();
            SqlCommand insertCommand= connection.CreateCommand();
            insertCommand.CommandType = System.Data.CommandType.Text;
            insertCommand.CommandText = "INSERT INTO Ticket VALUES(@descrizione, @data, @utente, @stato)";
            Console.Clear();
            Console.WriteLine("-------------Inserire un nuovo ticket-----------");
            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine();
            insertCommand.Parameters.AddWithValue("@descrizione", descrizione);
            insertCommand.Parameters.AddWithValue("@data", DateTime.Now);
            Console.Write("Utente: ");
            string utente=Console.ReadLine();
            insertCommand.Parameters.AddWithValue("@utente", utente);
            insertCommand.Parameters.AddWithValue("@stato", "New");

            int result= insertCommand.ExecuteNonQuery();
            if (result != 1)
                Console.WriteLine("Si è verificato un problema nell'inserimento del ticket");
            else
                Console.WriteLine("Ticket aggiuto correttamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
            Console.WriteLine("-----Premi un tasto------ ");
            Console.ReadKey();
        }
    }

    public static void DeleteTicket()
    {
        using SqlConnection connection =new SqlConnection(ConnectionString);
        try
        {
            connection.Open();
            SqlCommand deleteCommand= connection.CreateCommand();
            deleteCommand.CommandType = System.Data.CommandType.Text;
            deleteCommand.CommandText = "DELETE from Ticket where id= @id";
            Console.Write("Id del ticket da cancellare: ");
            string idValue=Console.ReadLine();
            deleteCommand.Parameters.AddWithValue("@id", idValue);
            int result = deleteCommand.ExecuteNonQuery();
            if (result != 1)
                Console.WriteLine("Si è verificato un problema nell'eliminazione del ticket");
            else
                Console.WriteLine("Ticket eliminato correttamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
            Console.WriteLine("-----Premi un tasto------ ");
            Console.ReadKey();
        }
    }
}