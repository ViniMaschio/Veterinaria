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
    internal class C_VendaServico : I_Metodos_Comuns
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        private readonly String sqlApaga = "delete from vendaservico where codvendaservico = @pcodvendaservico";
        public void Apaga_Dados(int aux)
        {
            C_ItensVendaServico c_ItensVendaServico = new C_ItensVendaServico();
            c_ItensVendaServico.Apaga_Dados(aux);

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodvendaservico", aux);

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

        private readonly String sqlAtualiza = "update vendaservico set datavs = @pdatavenda, codclientefk = @pcodclientefk, " +
            "codfuncionariofk = @pcodfuncionariofk, codanimalfk = @pcodanimalfk where codvendaservico = @pcodvendaservico";
        public void Atualizar_Dados(object aux) { }
        public void Atualizar_Dados(object aux, object listItens)
        {
            C_ItensVendaServico c_ItensVendaServico = new C_ItensVendaServico();
            M_VendaServico m_VendaServico;
            m_VendaServico = (M_VendaServico)aux;

            c_ItensVendaServico.Atualizar_Dados(listItens);

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pdatavenda", m_VendaServico.datavenda);
            cmd.Parameters.AddWithValue("@pcodclientefk", m_VendaServico.cliente.codcliente);
            cmd.Parameters.AddWithValue("@pcodfuncionariofk", m_VendaServico.funcionario.codfuncionario);
            cmd.Parameters.AddWithValue("@pcodanimalfk", m_VendaServico.animal.codanimal);
            cmd.Parameters.AddWithValue("@pcodvendaservico", m_VendaServico.codvendaservico);

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

        private readonly String sqlBuscaFiltro = "select v.codvendaservico,v.datavs,v.codfuncionariofk,v.codclientefk,v.codanimalfk from vendaservico v join cliente c on v.codclientefk = c.codcliente where c.nomecliente like @nomecliente;";
        public object Buscar_Filtro(string dados)
        {
            List<M_VendaServico> listVendaServico = new List<M_VendaServico>();

            C_Cliente c_Cliente = new C_Cliente();
            C_Funcionario c_Funcionario = new C_Funcionario();
            C_Animal c_Animal = new C_Animal();

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
                    M_VendaServico Venda = new M_VendaServico();
                    Venda.codvendaservico = Convert.ToInt32(reader["codvendaservico"]);
                    Venda.datavenda = Convert.ToDateTime(reader["datavs"]);
                    Venda.cliente = (M_Cliente)c_Cliente.Buscar_Id(Convert.ToInt32(reader["codclientefk"]));
                    Venda.funcionario = (M_Funcionario)c_Funcionario.Buscar_Id(Convert.ToInt32(reader["codfuncionariofk"]));
                    Venda.animal = (M_Animal)c_Animal.Buscar_Id(Convert.ToInt32(reader["codanimalfk"]));

                    listVendaServico.Add(Venda);
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
            return listVendaServico;
        }

        private readonly String sqlBuscaId = "select * from vendaservico where codvendaservico = @pcodvendaservico";
        public object Buscar_Id(int valor)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            M_VendaServico VendaServico = new M_VendaServico();
            C_Cliente c_Cliente = new C_Cliente();
            C_Funcionario c_Funcionario = new C_Funcionario();
            C_Animal c_Animal = new C_Animal();

            cmd = new SqlCommand(sqlBuscaId, conn);
            cmd.Parameters.AddWithValue("@pcodvendaservico", valor);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {

                    VendaServico.codvendaservico = Convert.ToInt32(reader["codvendaservico"]);
                    VendaServico.datavenda = Convert.ToDateTime(reader["datavs"]);
                    VendaServico.cliente = (M_Cliente)c_Cliente.Buscar_Id(Convert.ToInt32(reader["codclientefk"]));
                    VendaServico.funcionario = (M_Funcionario)c_Funcionario.Buscar_Id(Convert.ToInt32(reader["codfuncionariofk"]));
                    VendaServico.animal = (M_Animal)c_Animal.Buscar_Id(Convert.ToInt32(reader["codanimalfk"]));
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

            return VendaServico;

        }

        private readonly String sqlBuscaTodos = "select * from vendaservico";
        public object Buscar_Todos()
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            List<M_VendaServico> listVendaServico = new List<M_VendaServico>();
            C_Cliente c_Cliente = new C_Cliente();
            C_Funcionario c_Funcionario = new C_Funcionario();
            C_Animal c_Animal = new C_Animal();

            cmd = new SqlCommand(sqlBuscaTodos, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    M_VendaServico VendaServico = new M_VendaServico();
                    VendaServico.codvendaservico = Convert.ToInt32(reader["codvendaservico"]);
                    VendaServico.datavenda = Convert.ToDateTime(reader["datavs"]);
                    VendaServico.cliente = (M_Cliente)c_Cliente.Buscar_Id(Convert.ToInt32(reader["codclientefk"]));
                    VendaServico.funcionario = (M_Funcionario)c_Funcionario.Buscar_Id(Convert.ToInt32(reader["codfuncionariofk"]));
                    VendaServico.animal = (M_Animal)c_Animal.Buscar_Id(Convert.ToInt32(reader["codanimalfk"]));

                    listVendaServico.Add(VendaServico);
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

            return listVendaServico;

        }

        public void Insere_Dados(object aux)
        {
            throw new NotImplementedException();
        }

        private readonly String sqlInsere = "insert into vendaservico(datavs,codclientefk,codfuncionariofk,codanimalfk) " +
            "values (@pdatavs, @pcodclientefk, @pcodfuncionariofk, @pcodanimalfk) SELECT SCOPE_IDENTITY();";
        public void Insere_Dados(object aux, object listItens)
        {
            M_VendaServico m_VendaServico;
            m_VendaServico = (M_VendaServico)aux;
            C_ItensVendaServico c_ItensVendaServico = new C_ItensVendaServico();

            List<M_ItensVendaServico> listItensVendaServico;
            listItensVendaServico = (List<M_ItensVendaServico>)listItens; 


            int codVendaServico = 0;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pdatavs", m_VendaServico.datavenda);
            cmd.Parameters.AddWithValue("@pcodclientefk", m_VendaServico.cliente.codcliente);
            cmd.Parameters.AddWithValue("@pcodfuncionariofk", m_VendaServico.funcionario.codfuncionario);
            cmd.Parameters.AddWithValue("@pcodanimalfk", m_VendaServico.animal.codanimal);

            cmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                codVendaServico = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Insere Dados");
            }
            finally
            {
                conn.Close();
                
                for (int i = 0; i < listItensVendaServico.Count; i++)
                {
                    listItensVendaServico[i].vendaservico.codvendaservico = codVendaServico;
                }
                
                c_ItensVendaServico.Insere_Dados(listItensVendaServico);
                conn.Close();
            }
        }


    }
    
  
}
