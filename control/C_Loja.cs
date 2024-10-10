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
    internal class C_Loja : I_Metodos_Comuns
    {
        SqlConnection conn;
        SqlCommand cmd;

        private readonly String sqlApaga = "delete from loja where codloja = @pcodloja";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodloja", aux);

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

        private readonly String sqlAtualiza = "update loja set nomeloja = @nomeloja, codbairrofk = @pcodbairro, codruafk = @pcodrua, codcepfk = @pcodcep, codcidadefk = @pcodcidade ," +
            " codestadofk = @pcodestado, codpaisfk = @pcodpais, numeroloja = @pnumeroloja, cnpj = @pcnpj  where codloja = @pcodloja";
        public void Atualizar_Dados(object aux)
        {
            M_Loja m_Loja = new M_Loja();
            m_Loja = (M_Loja)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@nomeloja", m_Loja.nomeloja);
            cmd.Parameters.AddWithValue("@pcodbairro", m_Loja.bairro.codbairro);
            cmd.Parameters.AddWithValue("@pcodrua", m_Loja.rua.codrua);
            cmd.Parameters.AddWithValue("@pcodcep", m_Loja.cep.codcep);
            cmd.Parameters.AddWithValue("@pcodcidade", m_Loja.cidade.codcidade);
            cmd.Parameters.AddWithValue("@pcodestado", m_Loja.estado.codestado);
            cmd.Parameters.AddWithValue("@pcodpais", m_Loja.pais.codpais);
            cmd.Parameters.AddWithValue("@pnumeroloja", m_Loja.numeroloja);
            cmd.Parameters.AddWithValue("@pcnpj", m_Loja.cnpj);
            cmd.Parameters.AddWithValue("@pcodloja", m_Loja.codloja);
            

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

        private readonly String sqlFiltro = "select * from loja where nomeloja like @pnomeloja";
        public Object Buscar_Filtro(string dados)
        {
            List<M_Loja> listLoja = new List<M_Loja>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnomeloja", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {
                C_Cep c_cep = new C_Cep();
                C_Bairro c_bairro = new C_Bairro();
                C_Rua c_rua = new C_Rua();
                C_Cidade c_Cidade = new C_Cidade();
                C_Estado c_Estado = new C_Estado();
                C_Pais c_Pais = new C_Pais();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Loja aux = new M_Loja
                    {
                        codloja = Int32.Parse(reader["codloja"].ToString()),
                        nomeloja = reader["nomeloja"].ToString(),
                        bairro = (M_Bairro)c_bairro.Buscar_Id(Int32.Parse(reader["codbairrofk"].ToString())),
                        rua = (M_Rua)c_rua.Buscar_Id(Int32.Parse(reader["codruafk"].ToString())),
                        cep = (M_Cep)c_cep.Buscar_Id(Int32.Parse(reader["codcepfk"].ToString())),
                        cidade = (M_Cidade)c_Cidade.Buscar_Id(Int32.Parse(reader["codcidadefk"].ToString())),
                        estado = (M_Estado)c_Estado.Buscar_Id(Int32.Parse(reader["codestadofk"].ToString())),
                        pais = (M_Pais)c_Pais.Buscar_Id(Int32.Parse(reader["codpaisfk"].ToString())),
                        numeroloja = reader["numeroloja"].ToString(),
                        cnpj = reader["cnpj"].ToString()
                    };

                    listLoja.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            

            return listLoja;
        }

        private readonly String sqlBuscaId = "select * from loja where codloja = @pcodloja";
        public object Buscar_Id(int valor)
        {
            M_Loja aux = new M_Loja();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pcodloja", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {
                C_Cep c_cep = new C_Cep();
                C_Bairro c_bairro = new C_Bairro();
                C_Rua c_rua = new C_Rua();
                C_Cidade c_Cidade = new C_Cidade();
                C_Estado c_Estado = new C_Estado();
                C_Pais c_Pais = new C_Pais();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codloja = Int32.Parse(reader["codloja"].ToString());
                    aux.nomeloja = reader["nomeloja"].ToString();
                    aux.bairro = (M_Bairro)c_bairro.Buscar_Id(Int32.Parse(reader["codbairrofk"].ToString()));
                    aux.rua = (M_Rua)c_rua.Buscar_Id(Int32.Parse(reader["codruafk"].ToString()));
                    aux.cep = (M_Cep)c_cep.Buscar_Id(Int32.Parse(reader["codcepfk"].ToString()));
                    aux.cidade = (M_Cidade)c_Cidade.Buscar_Id(Int32.Parse(reader["codcidadefk"].ToString()));
                    aux.estado = (M_Estado)c_Estado.Buscar_Id(Int32.Parse(reader["codestadofk"].ToString()));
                    aux.pais = (M_Pais)c_Pais.Buscar_Id(Int32.Parse(reader["codpaisfk"].ToString()));
                    aux.numeroloja = reader["numeroloja"].ToString();
                    aux.cnpj = reader["cnpj"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            conn.Close();

            return aux;

        }

        private readonly String sqlTodos = "select * from loja";
        public Object Buscar_Todos()
        {
            List<M_Loja> listLoja = new List<M_Loja>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            cmd = new SqlCommand(sqlTodos, conn);

            SqlDataReader reader;
            conn.Open();

            try
            {
                C_Cep c_cep = new C_Cep();
                C_Bairro c_bairro = new C_Bairro();
                C_Rua c_rua = new C_Rua();
                C_Cidade c_Cidade = new C_Cidade();
                C_Estado c_Estado = new C_Estado();
                C_Pais c_Pais = new C_Pais();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Loja aux = new M_Loja
                    {
                        codloja = Int32.Parse(reader["codloja"].ToString()),
                        nomeloja = reader["nomeloja"].ToString(),
                        bairro = (M_Bairro)c_bairro.Buscar_Id(Int32.Parse(reader["codbairrofk"].ToString())),
                        rua = (M_Rua)c_rua.Buscar_Id(Int32.Parse(reader["codruafk"].ToString())),
                        cep = (M_Cep)c_cep.Buscar_Id(Int32.Parse(reader["codcepfk"].ToString())),
                        cidade = (M_Cidade)c_Cidade.Buscar_Id(Int32.Parse(reader["codcidadefk"].ToString())),
                        estado = (M_Estado)c_Estado.Buscar_Id(Int32.Parse(reader["codestadofk"].ToString())),
                        pais = (M_Pais)c_Pais.Buscar_Id(Int32.Parse(reader["codpaisfk"].ToString())),
                        numeroloja = reader["numeroloja"].ToString(),
                        cnpj = reader["cnpj"].ToString()
                    };

                    listLoja.Add(aux);
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

            return listLoja;
        }

        private readonly String sqlInsere = "insert into loja(nomeloja,codbairrofk,codruafk,codcepfk,codcidadefk,codestadofk,codpaisfk,numeroloja,cnpj) values" +
            " (@pnomeloja,@pcodbairrofk,@pcodruafk,@pcodcepfk,@pcodcidadefk,@pcodestadofk,@pcodpaisfk,@pnumeroloja,@pcnpj)";
        public void Insere_Dados(object aux)
        {
            M_Loja m_loja = new M_Loja();
            m_loja = (M_Loja)aux;

            //Criando a Conexao o banco de Dados
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomeloja", m_loja.nomeloja);
            cmd.Parameters.AddWithValue("@pcodbairrofk", m_loja.bairro.codbairro);
            cmd.Parameters.AddWithValue("@pcodruafk", m_loja.rua.codrua);
            cmd.Parameters.AddWithValue("@pcodcepfk", m_loja.cep.codcep);
            cmd.Parameters.AddWithValue("@pcodcidadefk", m_loja.cidade.codcidade);
            cmd.Parameters.AddWithValue("@pcodestadofk", m_loja.estado.codestado);
            cmd.Parameters.AddWithValue("@pcodpaisfk", m_loja.pais.codpais);
            cmd.Parameters.AddWithValue("@pnumeroloja", m_loja.numeroloja);
            cmd.Parameters.AddWithValue("@pcnpj", m_loja.cnpj);

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
