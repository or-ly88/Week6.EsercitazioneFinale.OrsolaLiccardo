
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale.OrsolaLiccardo
{
    static class AdoDisconnected
    {

        static IConfiguration config = new ConfigurationBuilder()
           .SetBasePath(@"C:\Users\orsola.liccardo\Desktop\ConsoleApp1\Week6.EsercitazioneFinale.OrsolaLiccardo\Week6.EsercitazioneFinale.OrsolaLiccardo\")
           .AddJsonFile("json1.json")
           .Build();

        static string ConnectionString = config.GetConnectionString("GestioneSpesa");

        public static void FillDataSet()
        {
            DataSet gestioneSpesaDs = new DataSet();

            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                {
                    Console.WriteLine("connessione stabilita");
                }
                else
                {
                    Console.WriteLine("connessione non riuscita");
                    return;
                }

                //OPERAZIONI DI RECUPERO DATI


                conn.Close();
                //lavoro in modalità disconnessa
                Console.WriteLine("===Gestione Spesa List===");
                //STAMPA DEI DATI IN LOCALE



                #region DELETE
                public static void DeleteRowDemo()
                {
                    DataSet movieDs = new DataSet();

                    using SqlConnection connection = new SqlConnection(ConnectionString);
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = SupportDisconnected.InitGestioneSpesaDataSetAndAdapter(
                            GestioneSpesaDs, connection);
                        connection.Close();
                        DataRow rowToDelete = movieDs.Tables["GestioneSPesa"].Rows.Find(6);
                        if (rowToDelete != null)
                            rowToDelete.Delete(); //cancellata dal dataset (ma non dal db)
                        adapter.Update(GestioneSpesaDs, "GestioneSpesa");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Generic Error: {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                #endregion



            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Generic Error {ex.Message}");
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
    
