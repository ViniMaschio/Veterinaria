using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_TipoAnimal : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        DataTable dt_TipoAnimal;
        SqlDataAdapter da_TipoAnimal;

        String sqlApaga = "delete from tipoanimal where codtipoanimal = @pcodtipoanimal";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodtipoanimal", aux);

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

        String sqlAtualiza = "update tipoanimal set nometipoanimal = @pnometipoanimal where codtipoanimal = @pcodtipoanimnal";
        public void Atualizar_Dados(object aux)
        {
            M_TipoAnimal m_TipoAnimal = new M_TipoAnimal();
            m_TipoAnimal = (M_TipoAnimal)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcodtipoanimnal", m_TipoAnimal.codtipoanimal);
            cmd.Parameters.AddWithValue("@pnometipoanimal", m_TipoAnimal.nometipoanimal);

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

        String sqlFiltro = "select * from tipoanimal where nometipoanimal like @pnometipoanimal";
        public Object Buscar_Filtro(string dados)
        {
            List<M_TipoAnimal> listTipoAnimal = new List<M_TipoAnimal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnometipoanimal", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_TipoAnimal aux = new M_TipoAnimal();
                    aux.codtipoanimal = Int32.Parse(reader["codtipoanimal"].ToString());
                    aux.nometipoanimal = reader["nometipoanimal"].ToString();

                    listTipoAnimal.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            return listTipoAnimal;
        }

        String sqlBuscaId = "select * from tipoanimal where codtipoanimal = @pcodtipoanimal";
        public object Buscar_Id(int valor)
        {
            M_TipoAnimal aux = new M_TipoAnimal();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pcodtipoanimal", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codtipoanimal = Int32.Parse(reader["codtipoanimal"].ToString());
                    aux.nometipoanimal = reader["nometipoanimal"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            conn.Close();

            return aux;

        }

        String sqlTodos = "select * from tipoanimal";
        public Object Buscar_Todos()
        {
            List<M_TipoAnimal> listTipoAnimal = new List<M_TipoAnimal>();

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
                    M_TipoAnimal aux = new M_TipoAnimal();
                    aux.codtipoanimal = Int32.Parse(reader["codtipoanimal"].ToString());
                    aux.nometipoanimal = reader["nometipoanimal"].ToString();

                    listTipoAnimal.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            } finally
            {
                conn.Close();
            }

            return listTipoAnimal;
        }


        String sqlInsere = "insert into tipoanimal(nometipoanimal) values (@pnometipoanimal)";
        public void Insere_Dados(object aux)
        {
            M_TipoAnimal m_TipoAnimal = new M_TipoAnimal();
            m_TipoAnimal = (M_TipoAnimal)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnometipoanimal", m_TipoAnimal.nometipoanimal);

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
