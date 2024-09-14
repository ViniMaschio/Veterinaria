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
    internal class C_Estado : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;
        public void Apaga_Dados(int aux)
        {
            throw new NotImplementedException();
        }

        public void Atualizar_Dados(object aux)
        {
            throw new NotImplementedException();
        }

        String sqlFiltro = "select * from estado where nomeestado like @pnomestado";
        public object Buscar_Filtro(string dados)
        {
            List<M_Estado> listEstado = new List<M_Estado>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnomestado", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Estado aux = new M_Estado();
                    aux.codestado = Int32.Parse(reader["codestado"].ToString());
                    aux.nomeestado = reader["nomeestado"].ToString();
                    aux.sigla = reader["sigla"].ToString();

                    listEstado.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Busca dados filtro");
            }

            return listEstado;
        }

        String sqlBuscaId = "select * from estado where codestado = @pcodestado";
        public object Buscar_Id(int valor)
        {
            M_Estado aux = new M_Estado();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pcodestado", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codestado = Int32.Parse(reader["codestado"].ToString());
                    aux.nomeestado = reader["nomeestado"].ToString();
                    aux.sigla = reader["sigla"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Id");
            }

            conn.Close();

            return aux;
        }

        String sqlTodos = "select * from rua";
        public object Buscar_Todos()
        {

            List<M_Estado> listEstado =  new List<M_Estado>();

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
                    M_Estado aux = new M_Estado();
                    aux.codestado = Int32.Parse(reader["codestado"].ToString());
                    aux.nomeestado = reader["nomeestado"].ToString();
                    aux.sigla = reader["sigla"].ToString();

                    listEstado.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message,"Erro Buscar Todos");
            }
            finally
            {
                conn.Close();
            }

            return listEstado;
        }

        public void Insere_Dados(object aux)
        {
            throw new NotImplementedException();
        }
    }
}
