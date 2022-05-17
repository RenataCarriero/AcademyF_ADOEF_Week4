using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF_ADOEF.DisconnectedMode
{
    public static class AdoNetDemoDisconnected
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CocktailsDelloZio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        public static void FillDataSet()
        {
            DataSet zioDS = new DataSet();

            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al DB");

                SqlDataAdapter zioAdapter = InizializzaAdapter(conn);
                zioAdapter.Fill(zioDS, "IngredienteDT");
                conn.Close();
                Console.WriteLine("Connessione chiusa");

                //da qui si lavora in modalità disconnessa --> siamo offline
                foreach (DataTable table in zioDS.Tables)
                {
                    Console.WriteLine($"{table.TableName} - {table.Rows.Count}");
                }

                //Console.WriteLine("Di seguito le constraint sula tabella IngredienteDT");
                //foreach (Constraint vincolo in zioDS.Tables["IngredienteDT"].Constraints)
                //{
                //    Console.WriteLine($"{vincolo.ConstraintName} - {vincolo.ExtendedProperties}");
                //}

                Console.WriteLine("----------------Ingredienti-----------------");
                foreach (DataRow riga in zioDS.Tables["ingredienteDT"].Rows)
                {
                    Console.WriteLine($"{riga["idIngrediente"]} - {riga["Nome"]} - {riga["Descrizione"]} - {riga["UnitaDiMisura"]}");
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

        internal static void InsertRowDemo()
        {
            DataSet zioDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al DB");

                SqlDataAdapter zioAdapter = InizializzaAdapter(conn);
                zioAdapter.Fill(zioDS, "IngredienteDT");
                conn.Close();
                Console.WriteLine("connessione chiusa");

                DataRow nuovaRiga = zioDS.Tables["IngredienteDT"].NewRow();
                nuovaRiga["Nome"] = "Cannella";
                nuovaRiga["Descrizione"] = "Cannella macinata";
                nuovaRiga["UnitaDiMisura"] = "gr";

                zioDS.Tables["IngredienteDT"].Rows.Add(nuovaRiga);// aggiungendo la mia  nuova riga

                //riconciliazione e quindi il vero salvataggio del dato sul DB
                zioAdapter.Update(zioDS, "IngredienteDT");
                Console.WriteLine("Database aggiornato");

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
            SqlDataAdapter adapter = new SqlDataAdapter();
            //Fill
            adapter.SelectCommand = new SqlCommand("Select * from Ingrediente", conn);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //INSERT
            //adapter.InsertCommand = new SqlCommand("Insert into Ingrediente values(@nome, @descr, @udm)", conn);
            //adapter.InsertCommand.Parameters.AddWithValue("@nome", "Nome");
            //adapter.InsertCommand.Parameters.AddWithValue("@descr", "Descrizione");
            //adapter.InsertCommand.Parameters.AddWithValue("@udm", "UnitaDiMisura");
            adapter.InsertCommand = GeneraInsertCommand(conn);

            //UPDATE
            adapter.UpdateCommand = GeneraUpdateCommand(conn);

            //DELETE
            adapter.DeleteCommand = GeneraDeleteCommand(conn);


            return adapter;
        }

        private static SqlCommand GeneraDeleteCommand(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from Ingrediente where idIngrediente=@id";

            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "IdIngrediente"));
            return command;
        }

        private static SqlCommand GeneraUpdateCommand(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Update Ingrediente set Nome=@nome, Descrizione=@descr, UnitaDiMisura=@udm where idIngrediente=@id";

            command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "IdIngrediente"));
            command.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar, 50, "Nome"));
            command.Parameters.Add(new SqlParameter("@descr", SqlDbType.VarChar, 50, "Descrizione"));
            command.Parameters.Add(new SqlParameter("@udm", SqlDbType.VarChar, 10, "UnitaDiMisura"));

            return command;
        }

        private static SqlCommand GeneraInsertCommand(SqlConnection conn)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Ingrediente values(@nome, @descr, @udm)";

            command.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar, 50, "Nome"));
            command.Parameters.Add(new SqlParameter("@descr", SqlDbType.VarChar, 50, "Descrizione"));
            command.Parameters.Add(new SqlParameter("@udm", SqlDbType.VarChar, 10, "UnitaDiMisura"));

            return command;
        }

        public static void UpdateRowDemo()
        {
            DataSet zioDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al DB");

                SqlDataAdapter zioAdapter = InizializzaAdapter(conn);
                zioAdapter.Fill(zioDS, "IngredienteDT");
                conn.Close();
                Console.WriteLine("connessione chiusa");

                DataRow rigaDaAggiornare = zioDS.Tables["IngredienteDT"].Rows.Find(4);
                if (rigaDaAggiornare != null)
                {
                    rigaDaAggiornare["Descrizione"] = "Descrizione latte modificata";
                }

                //riconciliazione e quindi il vero salvataggio del dato sul DB
                zioAdapter.Update(zioDS, "IngredienteDT");
                Console.WriteLine("Database aggiornato");

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

        public static void DeleteRowDemo()
        {
            DataSet zioDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al DB");

                SqlDataAdapter zioAdapter = InizializzaAdapter(conn);
                zioAdapter.Fill(zioDS, "IngredienteDT");
                conn.Close();
                Console.WriteLine("connessione chiusa");

                DataRow rigaDaEliminare = zioDS.Tables["IngredienteDT"].Rows.Find(21);
                if (rigaDaEliminare != null)
                {
                    rigaDaEliminare.Delete();
                }

                //riconciliazione e quindi il vero salvataggio del dato sul DB
                zioAdapter.Update(zioDS, "IngredienteDT");
                Console.WriteLine("Database aggiornato");

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
        public static void MultiTabelleDemo()
        {
            DataSet zioDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al DB");

                SqlDataAdapter libroAdapter = new SqlDataAdapter();
                libroAdapter.SelectCommand = new SqlCommand("Select * from Libro", conn);
                libroAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                libroAdapter.Fill(zioDS, "LibroDT");

                SqlDataAdapter cocktailAdapter = new SqlDataAdapter();
                cocktailAdapter.SelectCommand = new SqlCommand("Select * from Cocktail", conn);
                cocktailAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                cocktailAdapter.Fill(zioDS, "CocktailDT");

                conn.Close();
                Console.WriteLine("connessione chiusa");

                foreach (DataTable table in zioDS.Tables)
                {
                    Console.WriteLine($"{table.TableName} - {table.Rows.Count}");
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
        public static void ConstraintDemo()
        {
            DataSet zioDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al DB");

                SqlDataAdapter libroAdapter = new SqlDataAdapter();
                libroAdapter.SelectCommand = new SqlCommand("Select * from Libro", conn);
                libroAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                libroAdapter.Fill(zioDS, "LibroDT");

                SqlDataAdapter cocktailAdapter = new SqlDataAdapter();
                cocktailAdapter.SelectCommand = new SqlCommand("Select * from Cocktail", conn);
                cocktailAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                cocktailAdapter.Fill(zioDS, "CocktailDT");

                //Unique
                DataTable tabellaLibro = zioDS.Tables["LibroDT"];
                UniqueConstraint titoloUnique = new UniqueConstraint(tabellaLibro.Columns["Titolo"]);
                tabellaLibro.Constraints.Add(titoloUnique);

                //Fk
                DataColumn colonnaPadre = zioDS.Tables["LibroDT"].Columns["IdLibro"];
                DataColumn colonnaFiglio = zioDS.Tables["CocktailDT"].Columns["IdLibro"];
                ForeignKeyConstraint fk_Libro = new ForeignKeyConstraint("FK_Libro_cocktail", colonnaPadre, colonnaFiglio);
                zioDS.Tables["CocktailDT"].Constraints.Add(fk_Libro);

                conn.Close();
                Console.WriteLine("connessione chiusa");

                foreach (DataTable table in zioDS.Tables)
                {
                    Console.WriteLine($"{table.TableName} - {table.Rows.Count}");

                    foreach (Constraint constraint in table.Constraints)
                    {
                        if (constraint is UniqueConstraint)
                        {
                            UniqueConstraint vincoloUnique = (UniqueConstraint)constraint;
                            DataColumn[] arrayColonne = vincoloUnique.Columns;

                            for (int i = 0; i < arrayColonne.Length; i++)
                            {
                                Console.WriteLine($"Nome colonna: " + arrayColonne[i].ColumnName + " unique " + vincoloUnique.ConstraintName);
                            }
                        }
                        else if (constraint is ForeignKeyConstraint)
                        {
                            ForeignKeyConstraint vincoloFK = (ForeignKeyConstraint)constraint;
                            DataColumn[] arrayColonne = vincoloFK.Columns;

                            for (int i = 0; i < arrayColonne.Length; i++)
                            {
                                Console.WriteLine($"Nome colonna: " + arrayColonne[i].ColumnName + " fk " + vincoloFK.ConstraintName);
                            }
                        }

                    }

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
    }
}
