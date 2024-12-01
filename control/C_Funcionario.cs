using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Funcionario : I_Metodos_Comuns
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private readonly String sqlApagaFuncionario = "delete from funcionario where codfuncionario = @pcodfuncionario";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApagaFuncionario, conn);
            cmd.Parameters.AddWithValue("@pcodfuncionario", aux);

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

        private readonly String sqlAtualiza = "update funcionario set nomefuncionario = @pnomefuncionario, " +
            "codtipofuncionariofk = @pcodtipofuncionariofk, codlojafk = @pcodlojafk where codfuncionario = @pcodfuncionario";
        public void Atualizar_Dados(object aux)
        {
            M_Funcionario m_Funcionario = new M_Funcionario();
            m_Funcionario = (M_Funcionario)aux;


            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pnomefuncionario", m_Funcionario.nomefuncionario);
            cmd.Parameters.AddWithValue("@pcodtipofuncionariofk", m_Funcionario.tipofuncionario.codtipofuncionario);
            cmd.Parameters.AddWithValue("@pcodlojafk", m_Funcionario.loja.codloja);
            cmd.Parameters.AddWithValue("@pcodfuncionario", m_Funcionario.codfuncionario);


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

        private readonly String sqlFiltro = "select * from funcionario where nomefuncionario like @pnomefuncionario";
        public Object Buscar_Filtro(string dados)
        {
            List<M_Funcionario> listFuncionario = new List<M_Funcionario>();
            C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();
            C_Loja c_Loja = new C_Loja();
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);


            cmd.Parameters.AddWithValue("@pnomefuncionario", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Funcionario aux = new M_Funcionario
                    {
                        codfuncionario = Int32.Parse(reader["codfuncionario"].ToString()),
                        nomefuncionario = reader["nomefuncionario"].ToString(),
                        tipofuncionario = (M_Tipofuncionario)c_TipoFuncionario.Buscar_Id(Int32.Parse(reader["codtipofuncionariofk"].ToString())),
                        loja = (M_Loja)c_Loja.Buscar_Id(Int32.Parse(reader["codlojafk"].ToString()))
                    };

                    listFuncionario.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }


            return listFuncionario;
        }

        private readonly String sqlBuscaId = "select * from funcionario where codfuncionario = @pcodfuncionario";
        public object Buscar_Id(int valor)
        {
            M_Funcionario aux = new M_Funcionario();
            C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();
            C_Loja c_Loja = new C_Loja();
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);


            cmd.Parameters.AddWithValue("@pcodfuncionario", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codfuncionario = Int32.Parse(reader["codfuncionario"].ToString());
                    aux.nomefuncionario = reader["nomefuncionario"].ToString();
                    aux.tipofuncionario = (M_Tipofuncionario)c_TipoFuncionario.Buscar_Id(Int32.Parse(reader["codtipofuncionariofk"].ToString()));
                    aux.loja = (M_Loja)c_Loja.Buscar_Id(Int32.Parse(reader["codlojafk"].ToString()));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            conn.Close();

            return aux;

        }

        private readonly String sqlTodos = "select * from funcionario";
        public Object Buscar_Todos()
        {
            List<M_Funcionario> listFuncionario = new List<M_Funcionario>();
            C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();
            C_Loja c_Loja = new C_Loja();

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
                    M_Funcionario aux = new M_Funcionario
                    {
                        codfuncionario = Int32.Parse(reader["codfuncionario"].ToString()),
                        nomefuncionario = reader["nomefuncionario"].ToString(),
                        tipofuncionario = (M_Tipofuncionario)c_TipoFuncionario.Buscar_Id(Int32.Parse(reader["codtipofuncionariofk"].ToString())),
                        loja = (M_Loja)c_Loja.Buscar_Id(Int32.Parse(reader["codlojafk"].ToString()))
                    };

                    listFuncionario.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return listFuncionario;
        }

        private readonly String sqlInsere = "insert into funcionario(nomefuncionario,codtipofuncionariofk,codlojafk) " +
            "values (@pnomefuncionario,@pcodtipofuncionariofk,@pcodlojafk)";
        public void Insere_Dados(object aux)
        {
            M_Funcionario m_Funcionario = new M_Funcionario();
            m_Funcionario = (M_Funcionario)aux;


            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomefuncionario", m_Funcionario.nomefuncionario);
            cmd.Parameters.AddWithValue("@pcodtipofuncionariofk", m_Funcionario.tipofuncionario.codtipofuncionario);
            cmd.Parameters.AddWithValue("@pcodlojafk", m_Funcionario.loja.codloja);



            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
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
