using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Cidade : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        public void Apaga_Dados(int aux)
        {
            throw new NotImplementedException();
        }

        public void Atualizar_Dados(object aux)
        {
            throw new NotImplementedException();
        }

        String sqlFiltro = "select * from cidade where nomecidade like @pnomecidade";
        public object Buscar_Filtro(string dados)
        {
            List<M_Cidade> listCidade = new List<M_Cidade>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnomecidade", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Cidade aux = new M_Cidade();
                    aux.codcidade = Int32.Parse(reader["codcidade"].ToString());
                    aux.nomecidade = reader["nomecidade"].ToString();

                    listCidade.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Busca dados filtro");
            }

            return listCidade;
        }

        String sqlBuscaId = "select * from cidade where codcidade = @pcodcidade";
        public object Buscar_Id(int valor)
        {
            M_Cidade aux = new M_Cidade();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pcodcidade", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codcidade = Int32.Parse(reader["codcidade"].ToString());
                    aux.nomecidade = reader["nomecidade"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Id");
            }

            conn.Close();

            return aux;
        }

        String sqlTodos = "select * from cidade";
        public object Buscar_Todos()
        {
            List<M_Cidade> listCidade = new List<M_Cidade>();

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
                    M_Cidade aux = new M_Cidade();
                    aux.codcidade = Int32.Parse(reader["codcidade"].ToString());
                    aux.nomecidade = reader["nomecidade"].ToString();

                    listCidade.Add(aux);
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

            return listCidade;
        }

        public void Insere_Dados(object aux)
        {
            throw new NotImplementedException();
        }
    }
}
