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
    internal class C_Bairro : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        String SqlApaga = "DELETE FROM bairro WHERE codbairro = @pcod";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlApaga, conn);
            cmd.Parameters.AddWithValue("pcod", aux);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                conn.Close();
            }
        }

        String SqlAtualiza = "UPDATE bairro SET nomebairro = @pnomebairro WHERE codbairro = @pcodbairro";
        public void Atualizar_Dados(object aux)
        {
            M_Bairro m_Bairro = new M_Bairro();
            m_Bairro = (M_Bairro)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pnomebairro", m_Bairro.nomebairro);
            cmd.Parameters.AddWithValue("@pcodbairro", m_Bairro.codbairro);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                conn.Close();
            }
        }

        String SqlFiltro = "SELECT * FROM bairro WHERE nomebairro LIKE @pnomebairro";
        public object Buscar_Filtro(string dados)
        {
            List<M_Bairro> listBairro = new List<M_Bairro>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("@pnomebairro", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    M_Bairro aux = new M_Bairro();
                    aux.codbairro = Int32.Parse(reader["codbairro"].ToString());
                    aux.nomebairro = reader["nomebairro"].ToString();

                    listBairro.Add(aux);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            } finally
            {
                conn.Close();
            }

            return listBairro;
        }

        String SqlBuscaId = "SELECT * FROM bairro WHERE codbairro = @pcodbairro";
        public object Buscar_Id(int valor)
        {
            M_Bairro aux = new M_Bairro();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(SqlFiltro, conn);
            cmd.Parameters.AddWithValue("pcodbairro", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
            }
        }

        public object Buscar_Todos()
        {
            throw new NotImplementedException();
        }

        public void Insere_Dados(object aux)
        {
            throw new NotImplementedException();
        }
    }
}
