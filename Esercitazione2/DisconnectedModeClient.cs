// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

public static class DisconnectedModeClient
{

    static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ticketing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    public static void ListTickets()
    {
        DataSet dataset = new DataSet();
        using SqlConnection conn = new SqlConnection(connectionStringSQL);
        try
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Connessi al db");
            else
                Console.WriteLine("NON connessi al db");

            var zioAdapter = InizializzaAdapter(conn);

            zioAdapter.Fill(dataset, "Ticket");

            conn.Close();
            Console.WriteLine("Connessione chiusa");

            //da qui lavoro in modalità disconnessa-> sono offline

            //foreach (DataTable table in dataset.Tables)
            //{
            //    Console.WriteLine($"{table.TableName} - {table.Rows.Count}");
            //}

            //Console.WriteLine("Come è fatta la tabella Ticket del mio dataset");
            //foreach (DataColumn colonna in dataset.Tables["Ticket"].Columns)
            //{
            //    Console.WriteLine($"{colonna.ColumnName} - {colonna.DataType}");
            //}


            Console.WriteLine("----------------Tickets---------------");
            foreach (DataRow item in dataset.Tables["Ticket"].Rows)
            {
                Console.WriteLine($"{item["Id"]} - {item["Descrizione"]} - {item["Data"]} - {item["Username"]} - {item["Stato"]}");
            }

        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Errore SQL: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore generico: {ex.Message}");
        }
        finally
        {
            conn.Close();
        }
    }

    public static void DeleteTicket()
    {
        DataSet dataset = new DataSet();
        using SqlConnection conn = new SqlConnection(connectionStringSQL);
        try
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Connessi al db");
            else
                Console.WriteLine("NON connessi al db");

            var zioAdapter = InizializzaAdapter(conn);
            zioAdapter.Fill(dataset, "Ticket");


            conn.Close();
            Console.WriteLine("Connessione chiusa");

            Console.WriteLine();
            Console.Write("ID del ticket da cancellare: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Formato errato. Riprova. ID del ticket da cancellare: ");
            };

            DataRow rigaDaEliminare = dataset.Tables["Ticket"].Rows.Find(id); //by PK
            if (rigaDaEliminare != null)
            {
                rigaDaEliminare.Delete();
            }

            //riconciliazione e quindi vero salvataggio del dato sul db
            zioAdapter.Update(dataset, "Ticket");
            Console.WriteLine("Database Aggiornato");
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Errore SQL: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore generico: {ex.Message}");
        }
        finally
        {
            conn.Close();
        }
    }

    public static void AddTicket()
    {
        DataSet dataset = new DataSet();
        using SqlConnection conn = new SqlConnection(connectionStringSQL);
        try
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Connessi al db");
            else
                Console.WriteLine("NON connessi al db");


            var zioAdapter = InizializzaAdapter(conn);
            zioAdapter.Fill(dataset, "Ticket");

            conn.Close();
            Console.WriteLine("Connessione chiusa");

            Console.WriteLine("---- Inserire un nuovo Ticket ----");
            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine();
            Console.Write("Utente: ");
            string utente = Console.ReadLine();


            DataRow nuovaRiga = dataset.Tables["Ticket"].NewRow();
            nuovaRiga["Descrizione"] = descrizione;
            nuovaRiga["Data"] = DateTime.Now;
            nuovaRiga["Username"] = utente;
            nuovaRiga["Stato"] = "New";


            dataset.Tables["Ticket"].Rows.Add(nuovaRiga); //aggiunto la mia nuova riga nel dataset

            //riconciliazione e quindi vero salvataggio del dato sul db
            zioAdapter.Update(dataset, "Ticket");
            Console.WriteLine("Database Aggiornato");

        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Errore SQL: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore generico: {ex.Message}");
        }
        finally
        {
            conn.Close();
        }
    }

    private static SqlDataAdapter InizializzaAdapter(SqlConnection conn)
    {
        SqlDataAdapter ticketAdapter = new SqlDataAdapter();

        //SELECT (serve al metodo FILL)
        ticketAdapter.SelectCommand = new SqlCommand("Select * from Ticket", conn);
        ticketAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        //INSERT
        ticketAdapter.InsertCommand = GeneraInsertCommand(conn);

        //UPDATE
        ticketAdapter.UpdateCommand = GeneraUpdateCommand(conn);

        //DELETE
        ticketAdapter.DeleteCommand = GeneraDeleteCommand(conn);

        return ticketAdapter;
    }





    private static SqlCommand GeneraDeleteCommand(SqlConnection conn)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Delete from Ticket where ID=@id";

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "ID"));

        return cmd;
    }

    private static SqlCommand GeneraUpdateCommand(SqlConnection conn)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Update Ticket set Descrizione=@descr, Data=@data, Username=@username, stato=@stato where ID=@id";

        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "ID"));
        cmd.Parameters.Add(new SqlParameter("@descr", SqlDbType.NVarChar, 50, "Descrizione"));
        cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.DateTime, 0, "Data"));
        cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50, "Username"));
        cmd.Parameters.Add(new SqlParameter("@stato", SqlDbType.NVarChar, 50, "Stato"));

        return cmd;
    }

    private static SqlCommand GeneraInsertCommand(SqlConnection conn)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Insert into Ticket values (@descr, @data, @username, @stato)";

        cmd.Parameters.Add(new SqlParameter("@descr", SqlDbType.NVarChar, 50, "Descrizione"));
        cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.DateTime, 0, "Data"));
        cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50, "Username"));
        cmd.Parameters.Add(new SqlParameter("@stato", SqlDbType.NVarChar, 50, "Stato"));

        return cmd;
    }

}