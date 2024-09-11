using System;
using System.Data;
using System.Data.SqlClient;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Sexo : I_Metodos_Comuns
    {

        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_Sexo;
        SqlDataAdapter da_Sexo;

        public void Apaga_Dados(int aux)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar_Dados(object aux)
        {
            throw new System.NotImplementedException();
        }


        public Object Buscar_Filtro(string dados)
        {
            throw new System.NotImplementedException();
        }

        String sqlBuscarId = "select * from sexo where codsexo = @pcodsexo";
        public object Buscar_Id(int valor)
        {
            M_Sexo m_Sexo = new M_Sexo();
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);
            cmd.Parameters.AddWithValue("@pcodsexo", valor);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                m_Sexo.codsexo = (int)reader[0];
                m_Sexo.nomesexo = (string)reader[1];
            }

            conn.Close();

            return m_Sexo;


        }

        String sqlTodos = "select * from sexo";
        public Object Buscar_Todos()
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            conn.Open();

            da_Sexo = new SqlDataAdapter(cmd);

            dt_Sexo = new DataTable();
            da_Sexo.Fill(dt_Sexo);

            conn.Close();

            return dt_Sexo;

        } // tem que arrumar para list de sexo

        public void Insere_Dados(object aux)
        {
            throw new System.NotImplementedException();
        }
    }
}
