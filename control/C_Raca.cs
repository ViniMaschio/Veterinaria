using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Raca : I_Metodos_Comuns
    {
        //Variáveis Globais da Classe
        SqlConnection conn;
        SqlCommand cmd;

        String sqlApaga = "delete from raca where codraca = @pcod";
        public void Apaga_Dados(int aux)
        {
            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcod", aux);

            conn.Open();

            try
            {

              cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        String sqlBuscaId = "select * from raca where codraca = @pcodraca";
        public object Buscar_Id(int valor)
        {
             M_Raca aux = new M_Raca();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            
            cmd.Parameters.AddWithValue("@pcodraca", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codraca = Int32.Parse(reader["codraca"].ToString());
                    aux.nomeraca = reader["nomeraca"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Id");
            }

            conn.Close();

            return aux;
        }

        String sqlTodos = "select * from raca";
        public object Buscar_Todos()
        {
            List<M_Raca> lista_raca = new List<M_Raca>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader dr_raca;
            conn.Open();

            try
            {
                dr_raca = cmd.ExecuteReader();
                while (dr_raca.Read())
                {
                    M_Raca aux = new M_Raca();
                    aux.codraca = Int32.Parse(dr_raca["codraca"].ToString());
                    aux.nomeraca = dr_raca["nomeraca"].ToString();

                    lista_raca.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            conn.Close();

            return lista_raca;
        } 

        String sqlFiltro = "select * from raca where nomeraca like @pnomeraca";
        public object Buscar_Filtro(String raca)
        {
            List<M_Raca> lista_raca = new List<M_Raca>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("pnomeraca", raca + "%");

            SqlDataReader dr_raca;
            conn.Open();

            try
            {
                dr_raca = cmd.ExecuteReader();
                while (dr_raca.Read())
                {
                    M_Raca aux = new M_Raca();
                    aux.codraca = Int32.Parse(dr_raca["codraca"].ToString());
                    aux.nomeraca = dr_raca["nomeraca"].ToString();

                    lista_raca.Add(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();

            return lista_raca;
        } 

        String sqlInsere = "insert into raca(nomeraca) values (@pnome)";
        public void Insere_Dados(Object aux)
        {
            M_Raca raca = new M_Raca();
            raca = (M_Raca)aux; //casting

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", raca.nomeraca);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        String sqlAtualiza = "update raca set nomeraca = @pnome where codraca = @pcod";
        public void Atualizar_Dados(object aux)
        {
            M_Raca dados = new M_Raca();
            dados = (M_Raca)aux;


            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codraca);
            cmd.Parameters.AddWithValue("@pnome", dados.nomeraca);

            // cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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
