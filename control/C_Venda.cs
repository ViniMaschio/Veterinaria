using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_Venda : I_Metodos_Comuns
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private readonly String sqlApaga = "delete from vendas where codvenda = @pcodvenda";
        public void Apaga_Dados(int aux)
        {
             C_VendasProdutos c_VendasProdutos = new C_VendasProdutos();
            c_VendasProdutos.Apaga_Dados(aux);

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodvenda", aux);

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

        private readonly String sqlAtualiza = "update vendas set datavenda = @pdatavenda, codclientefk = @pcodclientefk, " +
            "codfuncionariofk = @pcodfuncionariofk, codlojafk = @codlojafk where codvenda = @pcodvenda";
        public void Atualizar_Dados(object aux) { }
        public void Atualizar_Dados(object aux, object listItens)
        {
            C_VendasProdutos c_VendasProdutos = new C_VendasProdutos();
            M_Venda m_Venda = new M_Venda();
            m_Venda = (M_Venda)aux;

            c_VendasProdutos.Atualizar_Dados(listItens);

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pdatavenda", m_Venda.datavenda);
            cmd.Parameters.AddWithValue("@pcodclientefk", m_Venda.cliente.codcliente);
            cmd.Parameters.AddWithValue("@pcodfuncionariofk", m_Venda.funcionario.codfuncionario);
            cmd.Parameters.AddWithValue("@codlojafk", m_Venda.loja.codloja);
            cmd.Parameters.AddWithValue("@pcodvenda", m_Venda.codvenda);


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

        private readonly String sqlBuscaFiltro = "select v.codvenda,v.datavenda,v.codclientefk,v.codfuncionariofk,v.codlojafk from vendas v join cliente c on v.codclientefk = c.codcliente where c.nomecliente like @nomecliente;";
        public object Buscar_Filtro(string dados)
        {
            List<M_Venda> listVenda = new List<M_Venda>();
            C_Cliente c_Cliente = new C_Cliente();
            C_Funcionario c_Funcionario = new C_Funcionario();
            C_Loja c_Loja = new C_Loja();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaFiltro, conn);
            cmd.Parameters.AddWithValue("@nomecliente", "%" + dados + "%");

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    M_Venda Venda = new M_Venda();
                    Venda.codvenda = Convert.ToInt32(reader["codvenda"]);
                    Venda.datavenda = Convert.ToDateTime(reader["datavenda"]);
                    Venda.cliente = (M_Cliente)c_Cliente.Buscar_Id(Convert.ToInt32(reader["codclientefk"]));
                    Venda.funcionario = (M_Funcionario)c_Funcionario.Buscar_Id(Convert.ToInt32(reader["codfuncionariofk"]));
                    Venda.loja = (M_Loja)c_Loja.Buscar_Id(Convert.ToInt32(reader["codlojafk"]));

                    listVenda.Add(Venda);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Filtro");
            }
            finally
            {
                conn.Close();
            }


            conn.Close();
            return listVenda;
        }

        private readonly String sqlBuscaId = "select * from vendas where codvenda = @pcodvenda";
        public object Buscar_Id(int valor)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            M_Venda Venda = new M_Venda();
            C_Cliente c_Cliente = new C_Cliente();
            C_Funcionario c_Funcionario = new C_Funcionario();
            C_Loja c_Loja = new C_Loja();

            cmd = new SqlCommand(sqlBuscaId, conn);
            cmd.Parameters.AddWithValue("@pcodvenda", valor);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Venda.codvenda = Convert.ToInt32(reader["codvenda"]);
                    Venda.datavenda = Convert.ToDateTime(reader["datavenda"]);
                    Venda.cliente = (M_Cliente)c_Cliente.Buscar_Id(Convert.ToInt32(reader["codclientefk"]));
                    Venda.funcionario = (M_Funcionario)c_Funcionario.Buscar_Id(Convert.ToInt32(reader["codfuncionariofk"]));
                    Venda.loja = (M_Loja)c_Loja.Buscar_Id(Convert.ToInt32(reader["codlojafk"]));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Id");
            }
            finally
            {
                conn.Close();
            }

            return Venda;

        }

        private readonly String sqlBuscaTodos = "select * from vendas";
        public object Buscar_Todos()
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();
            C_Cliente c_Cliente = new C_Cliente();
            C_Funcionario c_Funcionario = new C_Funcionario();
            C_Loja c_Loja = new C_Loja();
            List<M_Venda> listVenda = new List<M_Venda>();

            cmd = new SqlCommand(sqlBuscaTodos, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    M_Venda Venda = new M_Venda();
                    Venda.codvenda = Convert.ToInt32(reader["codvenda"]);
                    Venda.datavenda = Convert.ToDateTime(reader["datavenda"]);
                    Venda.cliente = (M_Cliente)c_Cliente.Buscar_Id(Convert.ToInt32(reader["codclientefk"]));
                    Venda.funcionario = (M_Funcionario)c_Funcionario.Buscar_Id(Convert.ToInt32(reader["codfuncionariofk"]));
                    Venda.loja = (M_Loja)c_Loja.Buscar_Id(Convert.ToInt32(reader["codlojafk"]));

                    listVenda.Add(Venda);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Buscar Todos");
            }
            finally
            {
                conn.Close();
            }

            return listVenda;

        }

        public void Insere_Dados(object aux)
        {
            throw new NotImplementedException();
        }

        private readonly String sqlInsere = "insert into vendas values (@pdatavenda, @pcodclientefk, @pcodfuncionariofk, @pcodlojafk) SELECT SCOPE_IDENTITY();";
        public void Insere_Dados(object aux, object listItens)
        {
            M_Venda m_Venda = new M_Venda();
            m_Venda = (M_Venda)aux;
            C_VendasProdutos c_VendasProdutos = new C_VendasProdutos();

            List<M_VendasProdutos> m_VendasProdutos = new List<M_VendasProdutos>();
            m_VendasProdutos = (List<M_VendasProdutos>)listItens;


            int codvenda = 0;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pdatavenda", m_Venda.datavenda);
            cmd.Parameters.AddWithValue("@pcodclientefk", m_Venda.cliente.codcliente);
            cmd.Parameters.AddWithValue("@pcodfuncionariofk", m_Venda.funcionario.codfuncionario);
            cmd.Parameters.AddWithValue("@pcodlojafk", m_Venda.loja.codloja);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                codvenda = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Insere Dados");
            }
            finally
            {
                conn.Close();
                foreach (M_VendasProdutos item in m_VendasProdutos)
                {
                    item.venda.codvenda = codvenda;
                }
                c_VendasProdutos.Insere_Dados(m_VendasProdutos);
                conn.Close();
            }
        }

    }
}
