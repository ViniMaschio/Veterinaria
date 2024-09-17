using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Telefone : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String sqlApaga = "delete from telefone where codtelefone = @pcodtelefone";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodtelefone", aux);

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

        String sqlAtualiza = "update telefone set numerotelefone = @pnumerotelefone where codtelefone = @pcodtelefone";
        public void Atualizar_Dados(object aux)
        {
            M_Telefone m_Telefone = new M_Telefone();
            m_Telefone = (M_Telefone)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodtelefone", m_Telefone.codtelefone);
            cmd.Parameters.AddWithValue("@pnumerotelefone", m_Telefone.numerotelefone);

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

        String sqlFiltro = "select * from telefone where numerotelefone like @pnumerotelefone";
        public object Buscar_Filtro(string dados)
        {
            List<M_Telefone> listTelefone = new List<M_Telefone>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnumerotelefone", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Telefone aux = new M_Telefone();
                    aux.codtelefone = Int32.Parse(reader["codtelefone"].ToString());
                    aux.numerotelefone = reader["numerotelefone"].ToString();

                    listTelefone.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            return listTelefone;
        }

        String sqlBuscaId = "select * from telefone where codtelefone = @pcodtelefone";
        public object Buscar_Id(int valor)
        {
            M_Telefone aux = new M_Telefone();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pcodtelefone", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codtelefone = Int32.Parse(reader["codtelefone"].ToString());
                    aux.numerotelefone = reader["numerotelefone"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            conn.Close();

            return aux;
        }

        String sqlTodos = "select * from telefone";
        public object Buscar_Todos()
        {
            List<M_Telefone> listTelefone = new List<M_Telefone>();

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
                    M_Telefone aux = new M_Telefone();
                    aux.codtelefone = Int32.Parse(reader["codtelefone"].ToString());
                    aux.numerotelefone = reader["numerotelefone"].ToString();

                    listTelefone.Add(aux);
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

            return listTelefone;
        }

        String sqlInsere = "insert into telefone(numerotelefone) values (@pnumerotelefone)";
        public void Insere_Dados(object aux)
        {
            M_Telefone m_Telefone = new M_Telefone();
            m_Telefone = (M_Telefone)aux;
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnumerotelefone", m_Telefone.numerotelefone);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message,"Insere Dados");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
