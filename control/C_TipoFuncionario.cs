using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_TipoFuncionario : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String sqlApaga = "delete from tipofuncionario where codtipofuncionario = @pcodtipofuncionario";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodtipofuncionario", aux);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Apaga Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String sqlAtualiza = "update tipofuncionario set nometipofuncionario = @pnometipofuncionario where codtipofuncionario = @pcodtipofuncionario";
        public void Atualizar_Dados(object aux)
        {
            M_Tipofuncionario m_Tipofuncionario = new M_Tipofuncionario();
            m_Tipofuncionario = (M_Tipofuncionario)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodtipofuncionario", m_Tipofuncionario.codtipofuncionario);
            cmd.Parameters.AddWithValue("@pnometipofuncionario", m_Tipofuncionario.nometipofuncionario);

            // cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Atualiza Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String sqlFiltro = "select * from tipofuncionario where nometipofuncionario like @pnometipofuncionario";
        public object Buscar_Filtro(string dados)
        {
            List<M_Tipofuncionario> listTipoFuncionario = new List<M_Tipofuncionario>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnometipofuncionario", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Tipofuncionario aux = new M_Tipofuncionario();
                    aux.codtipofuncionario = Int32.Parse(reader["codtipofuncionario"].ToString());
                    aux.nometipofuncionario = reader["nometipofuncionario"].ToString();

                    listTipoFuncionario.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            return listTipoFuncionario;
        }

        String sqlBuscaId = "select * from tipofuncionario where codtipofuncionario = @codtipofuncionario";
        public object Buscar_Id(int valor)
        {

            M_Tipofuncionario aux = new M_Tipofuncionario();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@codtipofuncionario", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codtipofuncionario = Int32.Parse(reader["codtipofuncionario"].ToString());
                    aux.nometipofuncionario = reader["nometipofuncionario"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Busca ID");
            }

            conn.Close();

            return aux;
        }

        String sqlTodos = "select * from tipofuncionario";
        public object Buscar_Todos()
        {
            List<M_Tipofuncionario> listTipoFuncionario = new List<M_Tipofuncionario>();

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
                    M_Tipofuncionario aux = new M_Tipofuncionario();
                    aux.codtipofuncionario = Int32.Parse(reader["codtipofuncionario"].ToString());
                    aux.nometipofuncionario = reader["nometipofuncionario"].ToString();

                    listTipoFuncionario.Add(aux);
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

            return listTipoFuncionario;
        }

        String sqlInsere = "insert into tipofuncionario(nometipofuncionario) values (@nometipofuncionario)";
        public void Insere_Dados(object aux)
        {
            M_Tipofuncionario m_TipoFuncionario = new M_Tipofuncionario();
            m_TipoFuncionario = (M_Tipofuncionario)aux;
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@nometipofuncionario", m_TipoFuncionario.nometipofuncionario);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Insere Dados");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
