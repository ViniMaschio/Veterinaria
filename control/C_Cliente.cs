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
    internal class C_Cliente : I_Metodos_Comuns
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private C_Cep c_cep = new C_Cep();
        private C_Bairro c_bairro = new C_Bairro();
        private C_Rua c_rua = new C_Rua();
        private C_Cidade c_Cidade = new C_Cidade();
        private C_Estado c_Estado = new C_Estado();
        private C_Pais c_Pais = new C_Pais();

        private readonly String sqlApaga = "delete from cliente where codcliente = @pcodcliente";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodcliente", aux);

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

        private readonly String sqlAtualiza = "update cliente set nomecliente = @nomecliente, codbairrofk = @pcodbairro, codruafk = @pcodrua, codcepfk = @pcodcep, codcidadefk = @pcodcidade ," +
            " codestadofk = @pcodestado, codpaisfk = @pcodpais, numerocasa = @pnumerocasa, cpf = @pcpf, fotocliente = @pfotocliente  where codcliente = @pcodcliente";
        public void Atualizar_Dados(object aux)
        {
            M_Cliente m_Cliente = new M_Cliente();
            m_Cliente = (M_Cliente)aux;

            
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@nomecliente", m_Cliente.nomecliente);
            cmd.Parameters.AddWithValue("@pcodbairro", m_Cliente.bairro.codbairro);
            cmd.Parameters.AddWithValue("@pcodrua", m_Cliente.rua.codrua);
            cmd.Parameters.AddWithValue("@pcodcep", m_Cliente.cep.codcep);
            cmd.Parameters.AddWithValue("@pcodcidade", m_Cliente.cidade.codcidade);
            cmd.Parameters.AddWithValue("@pcodestado", m_Cliente.estado.codestado);
            cmd.Parameters.AddWithValue("@pcodpais", m_Cliente.pais.codpais);
            cmd.Parameters.AddWithValue("@pnumeroloja", m_Cliente.numerocasa);
            cmd.Parameters.AddWithValue("@pcpf", m_Cliente.cpf);
            cmd.Parameters.AddWithValue("@pcodloja", m_Cliente.codcliente);
            cmd.Parameters.AddWithValue("@pfotocliente", m_Cliente.fotocliente);


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

        private readonly String sqlFiltro = "select * from cliente where nomecliente like @pnomecliente";
        public Object Buscar_Filtro(string dados)
        {
            List<M_Cliente> listCliente = new List<M_Cliente>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            //Adiciona o valor a ser pesquisado no parâmetro
            cmd.Parameters.AddWithValue("@pnomecliente", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Cliente aux = new M_Cliente
                    {
                        codcliente = Int32.Parse(reader["codcliente"].ToString()),
                        nomecliente = reader["nomecliente"].ToString(),
                        bairro = (M_Bairro)c_bairro.Buscar_Id(Int32.Parse(reader["codbairrofk"].ToString())),
                        rua = (M_Rua)c_rua.Buscar_Id(Int32.Parse(reader["codruafk"].ToString())),
                        cep = (M_Cep)c_cep.Buscar_Id(Int32.Parse(reader["codcepfk"].ToString())),
                        cidade = (M_Cidade)c_Cidade.Buscar_Id(Int32.Parse(reader["codcidadefk"].ToString())),
                        estado = (M_Estado)c_Estado.Buscar_Id(Int32.Parse(reader["codestadofk"].ToString())),
                        pais = (M_Pais)c_Pais.Buscar_Id(Int32.Parse(reader["codpaisfk"].ToString())),
                        numerocasa = reader["numerocasa"].ToString(),
                        cpf = reader["cpf"].ToString(),
                        fotocliente = (byte[])reader["fotocliente"]
                    };

                    listCliente.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }


            return listCliente;
        }

        private readonly String sqlBuscaId = "select * from cliente where codcliente = @pcodcliente";
        public object Buscar_Id(int valor)
        {
            M_Cliente aux = new M_Cliente();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);

            
            cmd.Parameters.AddWithValue("@pcodcliente", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codcliente = Int32.Parse(reader["codcliente"].ToString());
                    aux.nomecliente = reader["nomecliente"].ToString();
                    aux.bairro = (M_Bairro)c_bairro.Buscar_Id(Int32.Parse(reader["codbairrofk"].ToString()));
                    aux.rua = (M_Rua)c_rua.Buscar_Id(Int32.Parse(reader["codruafk"].ToString()));
                    aux.cep = (M_Cep)c_cep.Buscar_Id(Int32.Parse(reader["codcepfk"].ToString()));
                    aux.cidade = (M_Cidade)c_Cidade.Buscar_Id(Int32.Parse(reader["codcidadefk"].ToString()));
                    aux.estado = (M_Estado)c_Estado.Buscar_Id(Int32.Parse(reader["codestadofk"].ToString()));
                    aux.pais = (M_Pais)c_Pais.Buscar_Id(Int32.Parse(reader["codpaisfk"].ToString()));
                    aux.numerocasa = reader["numerocasa"].ToString();
                    aux.cpf = reader["cpf"].ToString();
                    aux.fotocliente = (byte[])reader["fotocliente"];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            conn.Close();

            return aux;

        }

        private readonly String sqlTodos = "select * from cliente";
        public Object Buscar_Todos()
        {
            List<M_Cliente> listaCliente = new List<M_Cliente>();

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
                    M_Cliente aux = new M_Cliente
                    {
                        codcliente = Int32.Parse(reader["codcliente"].ToString()),
                        nomecliente = reader["nomecliente"].ToString(),
                        bairro = (M_Bairro)c_bairro.Buscar_Id(Int32.Parse(reader["codbairrofk"].ToString())),
                        rua = (M_Rua)c_rua.Buscar_Id(Int32.Parse(reader["codruafk"].ToString())),
                        cep = (M_Cep)c_cep.Buscar_Id(Int32.Parse(reader["codcepfk"].ToString())),
                        cidade = (M_Cidade)c_Cidade.Buscar_Id(Int32.Parse(reader["codcidadefk"].ToString())),
                        estado = (M_Estado)c_Estado.Buscar_Id(Int32.Parse(reader["codestadofk"].ToString())),
                        pais = (M_Pais)c_Pais.Buscar_Id(Int32.Parse(reader["codpaisfk"].ToString())),
                        numerocasa = reader["numerocasa"].ToString(),
                        cpf = reader["cpf"].ToString(),
                        fotocliente = (byte[])reader["fotocliente"]
                    };

                    listaCliente.Add(aux);
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

            return listaCliente;
        }

        private readonly String sqlInsere = "insert into cliente(nomecliente,codbairrofk,codruafk,codcepfk,codcidadefk,codestadofk,codpaisfk,numerocasa,cpf,fotocliente) values" +
           " (@pnomeloja,@pcodbairrofk,@pcodruafk,@pcodcepfk,@pcodcidadefk,@pcodestadofk,@pcodpaisfk,@pnumerocasa,@pcpf,@pfotocliente)";
        public void Insere_Dados(object aux)
        {
            M_Cliente m_loja = new M_Cliente();
            m_loja = (M_Cliente)aux;

            
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomeloja", m_loja.nomecliente);
            cmd.Parameters.AddWithValue("@pcodbairrofk", m_loja.bairro.codbairro);
            cmd.Parameters.AddWithValue("@pcodruafk", m_loja.rua.codrua);
            cmd.Parameters.AddWithValue("@pcodcepfk", m_loja.cep.codcep);
            cmd.Parameters.AddWithValue("@pcodcidadefk", m_loja.cidade.codcidade);
            cmd.Parameters.AddWithValue("@pcodestadofk", m_loja.estado.codestado);
            cmd.Parameters.AddWithValue("@pcodpaisfk", m_loja.pais.codpais);
            cmd.Parameters.AddWithValue("@pnumerocasa", m_loja.numerocasa);
            cmd.Parameters.AddWithValue("@pcpf", m_loja.cpf);
            cmd.Parameters.AddWithValue("@pfotocliente", m_loja.fotocliente);

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
