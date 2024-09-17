using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Cep : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String SqlApaga = "DELETE FROM cep WHERE codcep = @pcod";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlApaga, conn);
            cmd.Parameters.AddWithValue("pcod", aux);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message + "Apaga Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String SqlAtualiza = "UPDATE cep SET numerocep = @pnumerocep WHERE codcep = @pcodcep";
        public void Atualizar_Dados(object aux)
        {
            M_Cep m_Cep = new M_Cep();
            m_Cep = (M_Cep)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pnumerocep", m_Cep.numerocep);
            cmd.Parameters.AddWithValue("@pcodcep", m_Cep.codcep);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message + "Atualizar Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String SqlFiltro = "SELECT * FROM cep WHERE numerocep LIKE @pnumerocep";
        public object Buscar_Filtro(string dados)
        {
            List<M_Cep> listCep = new List<M_Cep>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pnumerocep", "%" + dados + "%");

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    M_Cep m_Cep = new M_Cep();
                    m_Cep.codcep = Convert.ToInt32(dr["codcep"]);
                    m_Cep.numerocep = dr["numerocep"].ToString();

                    listCep.Add(m_Cep);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message + "Buscar Filtro");
            }
            finally
            {
                conn.Close();
            }

            return listCep;
        }

        String SqlBuscaId = "SELECT * FROM cep WHERE codcep = @pcodcep";
        public object Buscar_Id(int valor)
        {
            M_Cep aux = new M_Cep();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlBuscaId, conn);
            cmd.Parameters.AddWithValue("@pcodcep", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codcep = Int32.Parse(reader["codcep"].ToString());
                    aux.numerocep = reader["numerocep"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Id");
            }

            conn.Close();
            return aux;
        }

        String SqlTodos = "SELECT * FROM cep";
        public object Buscar_Todos()
        {
            List<M_Cep> listCep = new List<M_Cep>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(SqlTodos, conn);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Cep aux = new M_Cep();
                    aux.codcep = Int32.Parse(reader["codcep"].ToString());
                    aux.numerocep = reader["numerocep"].ToString();

                    listCep.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro Buscar Todos");
            }
            finally
            {
                conn.Close();
            }

            return listCep;
        }

        String SqlInsere = "INSERT INTO cep (numerocep) VALUES (@pnumerocep)";
        public void Insere_Dados(object aux)
        {
            M_Cep m_Cep = new M_Cep();
            m_Cep = (M_Cep)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnumerocep", m_Cep.numerocep);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message + "Inserir Dados");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
