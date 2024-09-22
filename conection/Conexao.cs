using System;
using System.Data.SqlClient;

namespace Veterinaria.conection
{

    internal class Conexao
    {
        //Declaração de Atribututos
        SqlConnection conn;
        String strConnection = @"Server=localhost\SQLEXPRESS;Database=Veterinaria_Unifunec;Trusted_Connection=True";

        //Método para conexao no banco de dados
        public SqlConnection ConectarBanco()
        {
            //Cria a conexao com banco
            conn = new SqlConnection(strConnection);
            return conn;
        }
    }
}
