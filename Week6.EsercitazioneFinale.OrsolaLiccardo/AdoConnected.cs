using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercitazioneFinale.OrsolaLiccardo
{
    internal class AdoConnected
    {

        static string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=GestioneSpesa;Trusted_Connection=True;";
       
        #region PROVA CONNESSIONE
        public static void ConnectionDemo()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Connessi al DB");
            else
                Console.WriteLine("NON connessi al DB");

            connection.Close();
        }

        #endregion

        #region READ

        public static void DataReaderDemo()
        {
            //CREO LA CONNESSIONE
            using SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                //OPERZIONI DA ESEGUIRE SUL DATABASE
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al DB");
                else
                    Console.WriteLine("Non connsessi al DB");

                //ISTANZIARE UN SQLCOMMAND
                SqlCommand readCommand = new SqlCommand();
                readCommand.Connection = conn;
                readCommand.CommandType = System.Data.CommandType.Text;
                readCommand.CommandText = "SELECT * FROM GestioneSpesa"; //Sql Statement

                //MODALITà EQUIVALENTE DI INSTANZIAMENTO DEL CMANDO (2)
                string sqlStatement = "SELECT*FROM GestioneSpesa";
                SqlCommand readCommand2 = new SqlCommand(sqlStatement, conn);

                //MODALITà N.3
                SqlCommand readCommand3 = conn.CreateCommand();
                readCommand3.CommandText = sqlStatement;

                SqlDataReader reader = readCommand.ExecuteReader();
                Console.WriteLine("---Gestione Spesa---");
                while (reader.Read())
                {
                    Console.WriteLine("{0}-{1} {2}{3}{4}{5}",
                     reader["ID"],
                     reader["Data"],
                     reader["Descrizione"],
                     reader["Utente"],
                     reader["Importo"],
                      reader["Categoria"]
                     );
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore:{ ex.Message}");
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion

        #region INSERT
        public static void InsertDemo()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();
  
                var date = "2021/09/09";
                var descrizione = "Shopping";
                var utente ="Maria";
                var importo =23.70;
                var categoria ="Shopping";


                //INSERT INTO GESTIONE SPESA VALUES 
                string insertSqlStatement = "INSERT INTO GestioneSpesa " +
                " VALUES (' " + date + "','" + descrizione + "'," + utente + ",'" + importo + "','" + categoria + "')";

                SqlCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = insertSqlStatement;

                int result = insertCommand.ExecuteNonQuery();
                if (result == 1)
                    Console.WriteLine("Record inserito con successo!");
                else
                    Console.WriteLine("OOOPS...è successo qualcosa");

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                conn.Close();
            }


        }
        #endregion

        #region INSERT WITH PARAMETER
        public static void InsertWithParameter()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connesso al DB");
                else
                    Console.WriteLine("NON Connesso a DB");

          
                var date = "2021/08/07";
                var descrizione = "Rata Auto";
                var utente = "Ursula";
                var importo = 230.50;
                var categoria = "Finanziamento";

                string insertSqlStatement = "INSERT INTO GestioneSpesa  VAlues(@date,@descrizione,@utente,@importo,@categoria)";

                SqlCommand insertCommand = conn.CreateCommand();
                insertCommand.CommandText = insertSqlStatement;

                //Metodo 1
                insertCommand.Parameters.AddWithValue("@date", date);

                ////Metodo2
                //SqlParameter dateParameter = new SqlParameter();
                //dateParameter.ParameterName = "@date";
                //dateParameter.Value = date;
                //dateParameter.DbType = System.Data.DbType.DateTime;
                //dateParameter.Size = 50;
                //insertCommand.Parameters.Add(dateParameter);

                //insertCommand.Parameters.AddWithValue("@date", date);


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error:{ex.Message}");
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

        #endregion


    }
}
