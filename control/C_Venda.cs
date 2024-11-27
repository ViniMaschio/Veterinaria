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
    internal class C_Venda : I_Metodos_Comuns
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private C_Cliente c_Cliente = new C_Cliente();
        private C_Funcionario c_Funcionario = new C_Funcionario();
        private C_Loja c_Loja = new C_Loja();

        private readonly String sqlApaga = "delete from vendas where codvenda = @pcodvenda";
        public void Apaga_Dados(int aux)
        {
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
        public void Atualizar_Dados(object aux, object aux2)
        {
            M_Venda m_Venda = new M_Venda();
            m_Venda = (M_Venda)aux;
            
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

        public object Buscar_Filtro(string dados)
        {
            throw new NotImplementedException();
        }

        public object Buscar_Id(int valor)
        {
            throw new NotImplementedException();
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
