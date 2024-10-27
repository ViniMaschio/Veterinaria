using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Sexo : I_Metodos_Comuns
    {

        SqlConnection conn;
        SqlCommand cmd;
        

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
            cmd = new SqlCommand(sqlBuscarId, conn);
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
            List<M_Sexo> listaCliente = new List<M_Sexo>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader reader;
            conn.Open();

            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Sexo aux = new M_Sexo
                    {
                        codsexo = Int32.Parse(reader["codsexo"].ToString()),
                        nomesexo = reader["nomesexo"].ToString(),
                        
                    };

                    listaCliente.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return listaCliente;

        }

        public void Insere_Dados(object aux)
        {
            throw new System.NotImplementedException();
        }
    }
}
