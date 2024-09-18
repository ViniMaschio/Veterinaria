using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_TipoProduto : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String SqlApaga = "DELETE FROM tipoproduto WHERE codtipoproduto = @pcodtipoproduto";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodtipoproduto", aux);

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

        String SqlAtualiza = "UPDATE tipoproduto SET nometipoproduto = @pnometipoproduto WHERE codtipoproduto = @pcodtipoproduto";
        public void Atualizar_Dados(object aux)
        {
            M_TipoProduto m_TipoProduto = new M_TipoProduto();
            m_TipoProduto = (M_TipoProduto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodtipoproduto", m_TipoProduto.codtipoproduto);
            cmd.Parameters.AddWithValue("@pnometipoproduto", m_TipoProduto.nometipoproduto);

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

        String SqlFiltro = "SELECT * FROM tipoproduto WHERE nometipoproduto LIKE @pnometipoproduto";
        public object Buscar_Filtro(string dados)
        {
            List<M_TipoProduto> listTipoProduto = new List<M_TipoProduto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pnometipoproduto", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    M_TipoProduto aux = new M_TipoProduto();
                    aux.codtipoproduto = Int32.Parse(reader["codtipoproduto"].ToString());
                    aux.nometipoproduto = reader["nometipoproduto"].ToString();

                    listTipoProduto.Add(aux);
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

            return listTipoProduto;
        }

        String SqlBuscaId = "SELECT * FROM tipoproduto WHERE codtipoproduto = @pcodtipoproduto";
        public object Buscar_Id(int valor)
        {
            M_TipoProduto aux = new M_TipoProduto();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pcodtipoproduto", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codtipoproduto = Int32.Parse(reader["codtipoproduto"].ToString());
                    aux.nometipoproduto = reader["nometipoproduto"].ToString();
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

        String SqlBuscaTodos = "SELECT * FROM tipoproduto";
        public object Buscar_Todos()
        {
            List<M_TipoProduto> listTipoProduto = new List<M_TipoProduto>();

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
                    M_TipoProduto aux = new M_TipoProduto();
                    aux.codtipoproduto = Int32.Parse(reader["codtipoproduto"].ToString());
                    aux.nometipoproduto = reader["nometipoproduto"].ToString();

                    listTipoProduto.Add(aux);
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

            return listTipoProduto;
        }

        String SqlInsere = "INSERT INTO tipoproduto (nometipoproduto) VALUES (@pnometipoproduto)";
        public void Insere_Dados(object aux)
        {
            M_TipoProduto m_TipoProduto = new M_TipoProduto();
            m_TipoProduto = (M_TipoProduto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnometipoproduto", m_TipoProduto.nometipoproduto);

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
