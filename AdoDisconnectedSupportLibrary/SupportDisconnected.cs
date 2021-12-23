using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AdoDisconnectedSupportLibrary
{
    internal class SupportDisconnected
    {
        public static SqlDataAdapter InitGestioneSpesaDataSetANdAdapter(DataSet gestioneSpesaDs, SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            //SELECT
            adapter.SelectCommand = GenerateSelectCommand(conn);
            //INSERT
            adapter.InsertCommand = GenerateInsertCommand(conn);
            //UPDATE
            adapter.UpdateCommand = GenerateUpdateCommand(conn);
            //DELETE
            adapter.DeleteCommand = GenerateDeleteCommand(conn);

            //primo parametro:dataset -- secondo parametro:nome tabella nel db
            adapter.Fill(gestioneSpesaDs, "GestioneSpesa");

            return adapter;
        }
        private static SqlCommand GenerateInsertCommand(SqlConnection conn)
        {
            SqlCommand GestioneSpesaInsertCommand = new SqlCommand();
            GestioneSpesaInsertCommand.Connection = conn;
            GestioneSpesaInsertCommand.CommandType = CommandType.Text;
            GestioneSpesaInsertCommand.CommandText = "INSERT INTO GestioneSpesa VALUES (@date,@descrizione,@utente,@importo,@approvata,@categoria)";
        }
        GestioneSpesaInsertCommand.Parameters.Add(new)
         
        private static object SqlCommand  GenerateUpdateCommand(SqlConnection conn)
        {
            SqlCommand GestioneSpesaSelectCommand = new SqlCommand();
            GestioneSpesaSelectCommand.Connection = conn;
            GestioneSpesaSelectCommand.CommandType = GestioneSpesaSelectCommand.CommandType = CommandType.Text;
            GestioneSpesaSelectCommand.CommandText = "UPDATE GestioneSpesa SET Data= @date, " +
             "Descrizione=@descrizione,Utente=@utente,Importo=@importo,Approvata=@approvata,Categoria=@categoria WHERE ID=@id";
            updateGestioneSpesaCommand.Parameters.Add(new SqlParameter(
            "@categoria", SqlDbType.NVarchar, 50, "shopping"
            ));
            updateGestioneSpesaCommand.Parameters.Add(new SqlParameter(
                "@date", SqlDbType.DateTime, 2021,09,08));
            updateGestioneSpesaCommand.Parameters.Add(new SqlParameter(
                "@descrizione", SqlDbType.NVarChar, 0, "descrizione"));
            updateGestioneSpesaCommand.Parameters.Add(new SqlParameter(
                "@utente", SqlDbType.NVarChar, 100, "utente"));
            updateGestioneSpesaCommand.Parameters.Add(new SqlParameter(
                "@importo", SqlDbType.Decimal, 45));
            updateGestioneSpesaCommand.Parameters.Add(new SqlParameter(
                "@approvata", SqlDbType.Bit, 1, "approvata"));
            updateGestioneSpesaCommand.Parameters.Add(new SqlParameter(
                "@categoria", SqlDbType.NVarChar, 0, "categoria"));


            ;

            return updateGestioneSpesaCommand;


        }
    }
}
