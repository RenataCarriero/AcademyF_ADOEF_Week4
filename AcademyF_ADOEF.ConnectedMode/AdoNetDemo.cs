using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_ADOEF.ConnectedMode
{
    public static class AdoNetDemo
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CocktailsDelloZio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

       

        public static void ConnectionDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            connessione.Open();

            if (connessione.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connessi al DB");
            }
            else
            {
                Console.WriteLine("Non connessi al DB");
            }

            connessione.Close();
        }

        public static void DataReaderDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non connessi al DB");
                }

                string query = "select * from Ingrediente";
                //istanziare SQLCommand (1 modo)
                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;

                ////istanziare SQLCommand (2 modo)
                //SqlCommand comando2 = new SqlCommand(query, connessione);

                ////istanziare SQLCommand (3 modo)
                //SqlCommand comando3= connessione.CreateCommand();
                //comando3.CommandText = query;

                SqlDataReader reader = comando.ExecuteReader();

                Console.WriteLine("Ingredienti");
                while (reader.Read())
                {
                    //var id = reader.GetInt32(0); //lettura tipizzata del dato               
                    //var nome=reader.GetString(1);
                    //var descrizione=reader.GetString(2);

                    //var id = int.Parse(reader.GetString(0));
                    //var nome = reader.GetString(1);
                    //var descrizione=reader.GetString(2);

                    var id = (int)reader["IdIngrediente"];
                    var nome = (string)reader["Nome"];
                    var descrizione = (string)reader["Descrizione"];

                    Console.WriteLine($"{id} - {nome} - {descrizione}");
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
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }

        public static void InsertDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non connessi al DB");
                }

                //string insertSQL="insert into Ingrediente values ('Cocco', 'latte di cocco', 'ml')";

                //chiediamo all'utente di inserire nome e descrizione del nuovo ingrediente
                string nomeNuovoIngrediente = "Cocco";
                string descrizioneNuovoIngrediente = "latte di Cocco";
                string udm = "ml";

                string insertSQL = $"insert into Ingrediente values ('{nomeNuovoIngrediente}', '{descrizioneNuovoIngrediente}', '{udm}')";

                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;

                int righeInserite = insertCommand.ExecuteNonQuery();

                if (righeInserite >= 1)
                {
                    Console.WriteLine($"{righeInserite} riga/righe inserite correttamente");
                }
                else
                {
                    Console.WriteLine("OOOOOPS...qualcosa non torna!");
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
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }

        internal static void InsertConParametriDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non connessi al DB");
                }

                //chiediamo all'utente di inserire nome e descrizione del nuovo ingrediente
                string nomeNuovoIngrediente = "Peperoncino";
                string descrizioneNuovoIngrediente = "peperoncino piccantissimo";
                string udm = "gr";

                string insertSQL = $"insert into Ingrediente values (@nomeIngrediente, @descrIngrediente, @udmIngr)";

                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;
                insertCommand.Parameters.AddWithValue("@nomeIngrediente", nomeNuovoIngrediente);
                insertCommand.Parameters.AddWithValue("@descrIngrediente", descrizioneNuovoIngrediente);
                //insertCommand.Parameters.AddWithValue("@udmIngr", udm);
                SqlParameter udmParametro = new SqlParameter();
                udmParametro.ParameterName = "@udmIngr";
                udmParametro.Value = udm;
                udmParametro.DbType = System.Data.DbType.String;
                udmParametro.Size = 10;
                insertCommand.Parameters.Add(udmParametro);

                int righeInserite = insertCommand.ExecuteNonQuery();
                if (righeInserite >= 1)
                {
                    Console.WriteLine($"{righeInserite} riga/righe inserite correttamente");
                }
                else
                {
                    Console.WriteLine("OOOOOPS...qualcosa non torna!");
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
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }
        public static void DeleteConParametriDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non connessi al DB");
                }

                //richiesta all'utente dell'id da eliminare
                int idDaEliminare = 20;

                string deleteSQL = "delete from Ingrediente where idIngrediente=@id";

                SqlCommand deleteCommand = connessione.CreateCommand();
                deleteCommand.CommandText = deleteSQL;
                deleteCommand.Parameters.AddWithValue("@id", idDaEliminare);

                int righeCancellate = deleteCommand.ExecuteNonQuery();
                if (righeCancellate >= 1)
                {
                    Console.WriteLine($"{righeCancellate} riga/righe eliminate correttamente");
                }
                else
                {
                    Console.WriteLine("OOOOOPS...qualcosa non torna!");
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
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }

        public static void StoredProcedureDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non connessi al DB");
                }

                //chiedo all'utente tutti i dati necessari per aggiungere il nuovo cocktail
                string nomeCocktail = "Cocktail Renata";
                int tempPrep = 5;
                int numPersone = 10;
                string preparaz = "mescola tutto bla bla";
                string libro = "Cocktails Classici";

                SqlCommand spInsertCocktail = connessione.CreateCommand();
                spInsertCocktail.CommandType = System.Data.CommandType.StoredProcedure;
                spInsertCocktail.CommandText = "InserisciCocktail";
                //parametri
                /*@nomeCocktail varchar(50),
                @tempoPreparazione int,
                @numeroPersone int,
                @procedimento varchar(100),
                @titololibro varchar(50)*/
                spInsertCocktail.Parameters.AddWithValue("@nomeCocktail", nomeCocktail);
                spInsertCocktail.Parameters.AddWithValue("@tempoPreparazione", tempPrep);
                spInsertCocktail.Parameters.AddWithValue("@numeroPersone", numPersone);
                spInsertCocktail.Parameters.AddWithValue("@procedimento", preparaz);
                spInsertCocktail.Parameters.AddWithValue("@titololibro", libro);

                int risultato= spInsertCocktail.ExecuteNonQuery();
                if (risultato >= 1)
                    Console.WriteLine($"{risultato} righa/righe inserite/aggiornate correttamente");
                else
                    Console.WriteLine("OOOOOPS...qualcosa non torna!");
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
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
           
        }
        public static void RisultatiMultipliDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non connessi al DB");
                }


                string sqlStatement = "Select * from Ingrediente Select * from Cocktail";
                SqlCommand readerCommand = new SqlCommand();
                readerCommand.Connection = connessione;
                readerCommand.CommandText = sqlStatement;
                readerCommand.CommandType=System.Data.CommandType.Text;

                SqlDataReader reader=readerCommand.ExecuteReader();
                int idx = 0;
                while (reader.HasRows)
                {
                    Console.WriteLine($"----------Result set {idx+1}-------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Nome"]}");

                    }
                    reader.NextResult();
                    idx++;
                    Console.WriteLine("------------------------------------------\n");
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
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }

        }
        public static void TransactionDemo()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            SqlTransaction transaction = null;
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connessi al DB");
                }
                else
                {
                    Console.WriteLine("Non connessi al DB");
                }

                transaction= connessione.BeginTransaction();
                SqlCommand insertIngrediente = connessione.CreateCommand();
                insertIngrediente.CommandText = "Insert into Ingrediente values( 'Ingrediente prova', 'descrizione prova', 'udm prova')";
                insertIngrediente.Transaction = transaction;
                int result= insertIngrediente.ExecuteNonQuery();

                SqlCommand insertLibro = connessione.CreateCommand();
                insertLibro.CommandText="Insert into Libro values('Nuovi Cocktails')";
                insertLibro.Transaction = transaction;
                result= insertLibro.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("Connessione chiusa");
            }
        }
    }
}
