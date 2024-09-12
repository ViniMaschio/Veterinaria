using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;
using System.Collections.Generic;

namespace Veterinaria.control
{
    internal class C_Rua : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String sqlApaga = "delete from rua where codrua = @pcodrua";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodrua", aux);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message,"Apaga Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String sqlAtualiza = "update rua set nomerua = @pnomerua where codrua = @pcodrua";
        public void Atualizar_Dados(object aux)
        {
            M_Rua m_Rua = new M_Rua();
            m_Rua = (M_Rua)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodrua", m_Rua.codrua);
            cmd.Parameters.AddWithValue("@pnomerua", m_Rua.nomerua);

            // cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message,"Atualiza Dados");
            }
            finally
            {
                conn.Close();
            };
        }

        String sqlFiltro = "select * from rua where nomerua like @pnomerua";
        public object Buscar_Filtro(string dados)
        {
            List<M_Rua> listRua = new List<M_Rua>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnomerua", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Rua aux = new M_Rua();
                    aux.codrua = Int32.Parse(reader["codrua"].ToString());
                    aux.nomerua = reader["nomerua"].ToString();

                    listRua.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Busca dados");
            }

            return listRua;
        }

        String sqlBuscaId = "select * from rua where codrua = @pcodrua";
        public object Buscar_Id(int valor)
        {
            M_Rua aux = new M_Rua();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pcodrua", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codrua = Int32.Parse(reader["codrua"].ToString());
                    aux.nomerua = reader["nomerua"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            conn.Close();

            return aux;
        }

        String sqlTodos = "select * from rua";
        public object Buscar_Todos()
        {
            List<M_Rua> listRua = new List<M_Rua>();

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
                    M_Rua aux = new M_Rua();
                    aux.codrua = Int32.Parse(reader["codrua"].ToString());
                    aux.nomerua = reader["nomerua"].ToString();

                    listRua.Add(aux);
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

            return listRua;
        }

        String sqlInsere = "insert into rua(nomerua) values (@pnomerua)";
        public void Insere_Dados(object aux)
        {
            M_Rua m_Rua = new M_Rua();
            m_Rua = (M_Rua)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomerua", m_Rua.nomerua);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
