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

                DataRow nuovaRiga=zioDS.Tables["IngredienteDT"].NewRow();
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
            //insert
            adapter.InsertCommand = new SqlCommand("Insert into Ingrediente values(@nome, @descr, @udm)", conn);
            adapter.InsertCommand.Parameters.AddWithValue("@nome", "Nome");
            adapter.InsertCommand.Parameters.AddWithValue("@descr", "Descrizione");
            adapter.InsertCommand.Parameters.AddWithValue("@udm", "UnitaDiMisura");
            
            return adapter;
        }
    }
}
