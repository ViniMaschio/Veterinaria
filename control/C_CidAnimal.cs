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
    internal class C_CidAnimal : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String SqlApaga = "DELETE FROM cidanimal WHERE codcidanimal = @pcodcidanimal";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodcidanimal", aux);

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

        String SqlAtualiza = "UPDATE cidanimal SET nomecidanimal = @pnomecidanimal, descricao = @pdescricao WHERE codcidanimal = @pcodcidanimal";
        public void Atualizar_Dados(object aux)
        {
            M_CidAnimal m_CidAnimal = new M_CidAnimal();
            m_CidAnimal = (M_CidAnimal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodcidanimal", m_CidAnimal.codcidanimal);
            cmd.Parameters.AddWithValue("@pnomecidanimal", m_CidAnimal.nomecidanimal);
            cmd.Parameters.AddWithValue("@pdescricao", m_CidAnimal.descricao);

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

        String SqlFiltro = "SELECT * FROM cidanimal WHERE nomecidanimal LIKE @pnomecidanimal";
        public object Buscar_Filtro(string dados)
        {
            List<M_CidAnimal> listCidAnimal = new List<M_CidAnimal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pnomecidanimal", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    M_CidAnimal aux = new M_CidAnimal();
                    aux.codcidanimal = Int32.Parse(reader["codcidanimal"].ToString());
                    aux.nomecidanimal = reader["nomecidanimal"].ToString();
                    aux.descricao = reader["descricao"].ToString();

                    listCidAnimal.Add(aux);
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

            return listCidAnimal;
        }

        String SqlBuscaId = "SELECT * FROM cidanimal WHERE codcidanimal = @pcodcidanimal";
        public object Buscar_Id(int valor)
        {
            M_CidAnimal aux = new M_CidAnimal();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pcodcidanimal", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codcidanimal = Int32.Parse(reader["codcidanimal"].ToString());
                    aux.nomecidanimal = reader["nomecidanimal"].ToString();
                    aux.descricao = reader["descricao"].ToString();
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

        String SqlBuscaTodos = "SELECT * FROM cidanimal";
        public object Buscar_Todos()
        {
            List<M_CidAnimal> listCidAnimal = new List<M_CidAnimal>();

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
                    M_CidAnimal aux = new M_CidAnimal();
                    aux.codcidanimal = Int32.Parse(reader["codcidanimal"].ToString());
                    aux.nomecidanimal = reader["nomecidanimal"].ToString();
                    aux.descricao = reader["descricao"].ToString();

                    listCidAnimal.Add(aux);
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

            return listCidAnimal;
        }

        String SqlInsere = "INSERT INTO cidanimal (nomecidanimal,descricao) VALUES (@pnomecidanimal,@pdescricao)";
        public void Insere_Dados(object aux)
        {
            M_CidAnimal m_CidAnimal = new M_CidAnimal();
            m_CidAnimal = (M_CidAnimal)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomecidanimal", m_CidAnimal.nomecidanimal);
            cmd.Parameters.AddWithValue("@pdescricao", m_CidAnimal.descricao);

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
