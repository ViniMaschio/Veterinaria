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
    internal class C_Pais : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String sqlApaga = "delete from pais where codpais = @pcodpais";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodpais", aux);

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

        String sqlAtualiza = "update pais set nomepais = @pnomepais, bandeira = @pbandeira where codpais = @pcodpais";
        public void Atualizar_Dados(object aux)
        {
            M_Pais m_pais = new M_Pais();
            m_pais = (M_Pais)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodpais", m_pais.codpais);
            cmd.Parameters.AddWithValue("@pnomepais", m_pais.nomepais);
            cmd.Parameters.AddWithValue("@pbandeira", m_pais.bandeira);

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
            };
        }

        String sqlFiltro = "select * from pais where nomepais like @pnomepais";
        public object Buscar_Filtro(string dados)   
        {
            List<M_Pais> lisPais = new List<M_Pais>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnomepais", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Pais aux = new M_Pais();
                    aux.codpais = Int32.Parse(reader["codpais"].ToString());
                    aux.nomepais = reader["nomepais"].ToString();
                    aux.bandeira = (byte[])reader["bandeira"];

                    lisPais.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Busca dados filtro");
            }

            return lisPais;
        }

        String sqlBuscaId = "select * from pais where codpais = @pcodpais";
        public object Buscar_Id(int valor)
        {
            M_Pais aux = new M_Pais();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pcodpais", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codpais = Int32.Parse(reader["codpais"].ToString());
                    aux.nomepais = reader["nomepais"].ToString();
                    aux.bandeira = (byte[])reader["bandeira"];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Id");
            }

            conn.Close();

            return aux;
        }

        String sqlTodos = "select * from pais";
        public object Buscar_Todos()
        {
            List<M_Pais> listPais = new List<M_Pais>();

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
                    M_Pais aux = new M_Pais();
                    aux.codpais = Int32.Parse(reader["codpais"].ToString());
                    aux.nomepais = reader["nomepais"].ToString();
                    aux.bandeira = (byte[])reader["bandeira"];

                    listPais.Add(aux);
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

            return listPais;
        }
        String sqlInsere = "insert into pais(nomepais,bandeira) values (@nomepais,@pbandeira)";
        public void Insere_Dados(object aux)
        {
            M_Pais m_Pais = new M_Pais();
            m_Pais = (M_Pais)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@nomepais", m_Pais.nomepais);
            cmd.Parameters.AddWithValue("@pbandeira", m_Pais.bandeira);

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
