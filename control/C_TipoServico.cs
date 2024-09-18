using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_TipoServico : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String SqlApaga = "DELETE FROM tiposervico WHERE codtiposervico = @pcodtiposervico";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodtiposervico", aux);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Apaga Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String SqlAtualiza = "UPDATE tiposervico SET nometiposervico = @pnometiposervico, valortiposervico = @pvalortiposervico WHERE codtiposervico = @pcodtiposervico";
        public void Atualizar_Dados(object aux)
        {
            M_TipoServico m_TipoServico = new M_TipoServico();
            m_TipoServico = (M_TipoServico)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodtiposervico", m_TipoServico.codtiposervico);
            cmd.Parameters.AddWithValue("@pnometiposervico", m_TipoServico.nometiposervico);
            cmd.Parameters.AddWithValue("@pvalortiposervico", m_TipoServico.valortiposervico);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atualiza dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String SqlFiltro = "SELECT * FROM tiposervico WHERE nometiposervico LIKE @pnometiposervico";
        public object Buscar_Filtro(string dados)
        {
            List<M_TipoServico> listTipoServico = new List<M_TipoServico>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pnometiposervico", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    M_TipoServico aux = new M_TipoServico();
                    aux.codtiposervico = Int32.Parse(reader["codtiposervico"].ToString());
                    aux.nometiposervico = reader["nometiposervico"].ToString();
                    aux.valortiposervico = Double.Parse(reader["valortiposervico"].ToString());

                    listTipoServico.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Busca Filtro");
            }
            finally
            {
                conn.Close();
            }

            return listTipoServico;
        }

        String SqlBuscaId = "SELECT * FROM tiposervico WHERE codtiposervico = @pcodtiposervico";
        public object Buscar_Id(int valor)
        {
            M_TipoServico aux = new M_TipoServico();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pcodtiposervico", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codtiposervico = Int32.Parse(reader["codtiposervico"].ToString());
                    aux.nometiposervico = reader["nometiposervico"].ToString();
                    aux.valortiposervico = Double.Parse(reader["valortiposervico"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar ID");
            }
            finally
            {
                conn.Close();
            }

            return aux;
        }

        String SqlBuscaTodos = "SELECT * FROM tiposervico";
        public object Buscar_Todos()
        {
            List<M_TipoServico> listTipoServico = new List<M_TipoServico>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlBuscaTodos, conn);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_TipoServico aux = new M_TipoServico();

                    aux.codtiposervico = Int32.Parse(reader["codtiposervico"].ToString());
                    aux.nometiposervico = reader["nometiposervico"].ToString();
                    aux.valortiposervico = Double.Parse(reader["valortiposervico"].ToString());

                    listTipoServico.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Todos");
            }
            finally
            {
                conn.Close();
            }

            return listTipoServico;
        }

        String SqlInsere = "INSERT INTO tiposervico (nometiposervico,valortiposervico) VALUES (@nometiposervico,@pvalortiposervico)";
        public void Insere_Dados(object aux)
        {
            M_TipoServico m_TipoServico = new M_TipoServico();
            m_TipoServico = (M_TipoServico)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlInsere, conn);
            cmd.Parameters.AddWithValue("@nometiposervico", m_TipoServico.nometiposervico);
            cmd.Parameters.AddWithValue("@pvalortiposervico", m_TipoServico.valortiposervico);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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
