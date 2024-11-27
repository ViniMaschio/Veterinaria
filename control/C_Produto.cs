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
    internal class C_Produto : I_Metodos_Comuns
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private C_Marca c_Marca = new C_Marca();
        private C_TipoProduto c_TipoProduto = new C_TipoProduto();


        private readonly String sqlApaga = "DELETE FROM produto WHERE codproduto = @pcodproduto";

        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodproduto", aux);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro:" + ex.Message + ". Apaga Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        private readonly String sqlAtualiza = "UPDATE produto SET nomeproduto = @pnomeproduto, quantidade = @pquantidade, valor = @pvalor, codmarcafk = @pcodmarcafk, codtipoprodutofk = @pcodtipoprodutofk WHERE codproduto = @pcodproduto";
        public void Atualizar_Dados(object aux)
        {
            M_Produto m_Produto = new M_Produto();
            m_Produto = (M_Produto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pnomeproduto", m_Produto.nomeproduto);
            cmd.Parameters.AddWithValue("@pquantidade", m_Produto.quantidade);
            cmd.Parameters.AddWithValue("@pvalor", m_Produto.valor);
            cmd.Parameters.AddWithValue("@pcodmarcafk", m_Produto.marca.codmarca);
            cmd.Parameters.AddWithValue("@pcodtipoprodutofk", m_Produto.tipoproduto.codtipoproduto);
            cmd.Parameters.AddWithValue("@pcodproduto", m_Produto.codproduto);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro:" + ex.Message + ". Atualiza Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        private readonly String sqlFiltro = "SELECT * FROM produto WHERE nomeproduto LIKE @pnomeproduto";
        public object Buscar_Filtro(string dados)
        {
            List<M_Produto> listProduto = new List<M_Produto>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pnomeproduto", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    M_Produto m_Produto = new M_Produto
                    {
                        codproduto = Int32.Parse(reader["codproduto"].ToString()),
                        nomeproduto = reader["nomeproduto"].ToString(),
                        quantidade = Double.Parse(reader["quantidade"].ToString()),
                        valor = Double.Parse(reader["valor"].ToString()),
                        marca = (M_Marca)c_Marca.Buscar_Id(Int32.Parse(reader["codmarcafk"].ToString())),
                        tipoproduto = (M_TipoProduto)c_TipoProduto.Buscar_Id(Int32.Parse(reader["codtipoprodutofk"].ToString()))
                    };

                    listProduto.Add(m_Produto);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro:" + ex.Message + ". Busca Filtro");
            }
            finally
            {
                conn.Close();
            }

            return listProduto;
        }

        private readonly String sqlBuscaId = "SELECT * FROM produto WHERE codproduto = @pcodproduto";
        public object Buscar_Id(int valor)
        {
            M_Produto aux = new M_Produto();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);
            cmd.Parameters.AddWithValue("@pcodproduto", valor);

            SqlDataReader reader;
            conn.Open();

            try { 
                reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    aux.codproduto = Int32.Parse(reader["codproduto"].ToString());
                    aux.nomeproduto = reader["nomeproduto"].ToString();
                    aux.quantidade = Double.Parse(reader["quantidade"].ToString());
                    aux.valor = Double.Parse(reader["valor"].ToString());
                    aux.marca = (M_Marca)c_Marca.Buscar_Id(Int32.Parse(reader["codmarcafk"].ToString()));
                    aux.tipoproduto = (M_TipoProduto)c_TipoProduto.Buscar_Id(Int32.Parse(reader["codtipoprodutofk"].ToString()));
                }
            } catch (SqlException ex) { 
                MessageBox.Show("Erro:" + ex.Message + ". Busca Id");
            }  

            conn.Close();

            return aux;
        }

        private readonly String sqlTodos = "SELECT * FROM produto";
        public object Buscar_Todos()
        {
            List<M_Produto> listProduto = new List<M_Produto>();

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
                    M_Produto aux = new M_Produto
                    {
                        codproduto = Int32.Parse(reader["codproduto"].ToString()),
                        nomeproduto = reader["nomeproduto"].ToString(),
                        quantidade = Double.Parse(reader["quantidade"].ToString()),
                        valor = Double.Parse(reader["valor"].ToString()),
                        marca = (M_Marca)c_Marca.Buscar_Id(Int32.Parse(reader["codmarcafk"].ToString())),
                        tipoproduto = (M_TipoProduto)c_TipoProduto.Buscar_Id(Int32.Parse(reader["codtipoprodutofk"].ToString()))
                    };

                    listProduto.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro:" + ex.Message + ". Busca Todos");
            }
            finally
            {
                conn.Close();
            }

            return listProduto;
        }

        private readonly String sqlInsere = "INSERT INTO produto (nomeproduto, quantidade, valor, codmarcafk, codtipoprodutofk) VALUES (@pnomeproduto, @pquantidade, @pvalor, @pcodmarcafk, @pcodtipoprodutofk)";

        public void Insere_Dados(object aux)
        {
            M_Produto m_Produto = new M_Produto();
            m_Produto = (M_Produto)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomeproduto", m_Produto.nomeproduto);
            cmd.Parameters.AddWithValue("@pquantidade", m_Produto.quantidade);
            cmd.Parameters.AddWithValue("@pvalor", m_Produto.valor);
            cmd.Parameters.AddWithValue("@pcodmarcafk", m_Produto.marca.codmarca);
            cmd.Parameters.AddWithValue("@pcodtipoprodutofk", m_Produto.tipoproduto.codtipoproduto);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro:" + ex.Message + ". Insere Dados");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
