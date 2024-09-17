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
    internal class C_Marca : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String SqlApaga = "DELETE FROM marca WHERE codmarca = @codmarca";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlApaga, conn);
            cmd.Parameters.AddWithValue("codmarca", aux);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Apaga Dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String SqlAtualiza = "UPDATE marca SET nomemarca = @pnomecarma WHERE codmarca = @pcodmarca";
        public void Atualizar_Dados(object aux)
        {
            M_Marca m_Marca = new M_Marca();
            m_Marca = (M_Marca)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodmarca", m_Marca.codmarca);
            cmd.Parameters.AddWithValue("@pnomecarma", m_Marca.nomemarca);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Atualiza dados");
            }
            finally
            {
                conn.Close();
            }
        }

        String SqlFiltro = "SELECT * FROM marca WHERE nomemarca LIKE @pnomemarca";
        public object Buscar_Filtro(string dados)
        {
            List<M_Marca> listMarca = new List<M_Marca>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pnomemarca", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    M_Marca aux = new M_Marca();
                    aux.codmarca = Int32.Parse(reader["codmarca"].ToString());
                    aux.nomemarca = reader["nomemarca"].ToString();

                    listMarca.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return listMarca;
        }

        String SqlBuscaId = "SELECT * FROM marca WHERE codmarca = @pcodmarca";
        public object Buscar_Id(int valor)
        {
            M_Marca aux = new M_Marca();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("pcodmarca", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codmarca = Int32.Parse(reader["codmarca"].ToString());
                    aux.nomemarca = reader["nomemarca"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message,"Buscar ID");
            }
            finally
            {
                conn.Close();
            }

            return aux;
        }

        String SqlBuscaTodos = "SELECT * FROM marca";
        public object Buscar_Todos()
        {
            List<M_Marca> listMarca = new List<M_Marca>();

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
                    M_Marca aux = new M_Marca();
                    aux.codmarca = Int32.Parse(reader["codmarca"].ToString());
                    aux.nomemarca = reader["nomemarca"].ToString();

                    listMarca.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message,"Buscar Todos");
            }
            finally
            {
                conn.Close();
            }

            return listMarca;
        }

        String SqlInsere = "INSERT INTO marca (nomemarca) VALUES (@pnomemarca)";
        public void Insere_Dados(object aux)
        {
            M_Marca m_Marca = new M_Marca();
            m_Marca = (M_Marca)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomemarca", m_Marca.nomemarca);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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
