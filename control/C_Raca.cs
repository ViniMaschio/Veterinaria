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

        public List<Raca> DadosRaca()
        {
            //Cria uma Lista do tipo Raça - Array
            List<Raca> lista_raca = new List<Raca>();

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
                    Raca aux = new Raca();
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

        public List<Raca> DadosRacaFiltro(String parametro)
        {
            //Cria uma Lista do tipo Raça - Array
            List<Raca> lista_raca = new List<Raca>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("pnomeraca", parametro + "%");

            SqlDataReader dr_raca;
            conn.Open();

            try
            {
                dr_raca = cmd.ExecuteReader();
                while (dr_raca.Read())
                {
                    Raca aux = new Raca();
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
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Apaguei");
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

        } 

        public object Buscar_Id(int valor)
        {
            throw new NotImplementedException();
        }  //ainda nao feio

        String sqlTodos = "select * from raca";
        public object Buscar_Todos()
        {
            List<Raca> lista_raca = new List<Raca>();

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
                    Raca aux = new Raca();
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
            List<Raca> lista_raca = new List<Raca>();

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
                    Raca aux = new Raca();
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
            Raca raca = new Raca();
            raca = (Raca)aux; //casting

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnome", raca.nomeraca);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Inseriu");
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

        }

        String sqlAtualiza = "update raca set nomeraca = @pnome where" +
            " codraca = @pcod";
        public void Atualizar_Dados(object aux)
        {
            Raca dados = new Raca();
            dados = (Raca)aux;


            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pcod", dados.codraca);
            cmd.Parameters.AddWithValue("@pnome", dados.nomeraca);

            // cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Atualizei");
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

        } 
    }
}
