using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.conection;
using Veterinaria.model;

namespace Veterinaria.control
{
    internal class C_VendasProdutos : I_Metodos_Comuns
    {

        private SqlConnection conn;
        private SqlCommand cmd;

        private C_Venda c_Venda = new C_Venda();
        private C_Produto c_Produto = new C_Produto();

        private readonly String sqlApaga = "delete from vendasprodutos where codvendafk = @pcodvendaproduto";
        public void Apaga_Dados(int aux)
        {
            List<M_VendasProdutos> vendasProdutos = (List<M_VendasProdutos>)Buscar_Id(aux);

            foreach (M_VendasProdutos item in vendasProdutos)
            {
                AjustarEstoque(item.produto.codproduto, item.quantv);
            }

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodvendaproduto", aux);

            cmd.CommandType = System.Data.CommandType.Text;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Atualizar_Dados(object aux)
        {
            List<M_VendasProdutos> listVendasProdutos;
            listVendasProdutos = (List<M_VendasProdutos>)aux;


            Apaga_Dados(listVendasProdutos[0].venda.codvenda);
            Insere_Dados(listVendasProdutos);
        }

        public object Buscar_Filtro(string dados)
        {
            throw new NotImplementedException();
        }

        private readonly String sqlBuscaId = "select * from vendasprodutos where codvendafk = @pcodvendafk";
        public object Buscar_Id(int valor)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            List<M_VendasProdutos> listVendaProdutos = new List<M_VendasProdutos>();

            cmd = new SqlCommand(sqlBuscaId, conn);
            cmd.Parameters.AddWithValue("@pcodvendafk", valor);

            conn.Open();

            SqlDataReader leitor = cmd.ExecuteReader();

            try
            {
                while (leitor.Read())
                {
                    M_VendasProdutos VendasProdutos = new M_VendasProdutos();
                    VendasProdutos.venda = (M_Venda)c_Venda.Buscar_Id(Convert.ToInt32(leitor["codvendafk"]));
                    VendasProdutos.produto = (M_Produto)c_Produto.Buscar_Id(Convert.ToInt32(leitor["codprodutofk"]));
                    VendasProdutos.quantv = Convert.ToDouble(leitor["quantv"]);
                    VendasProdutos.valorv = Convert.ToDouble(leitor["valorv"]);

                    listVendaProdutos.Add(VendasProdutos);
                }
            }
            catch (Exception)
            {

                throw;
            }


            conn.Close();
            return listVendaProdutos;
        }

        public object Buscar_Todos()
        {

            throw new NotImplementedException();

        }

        private readonly String sqlInsere = "insert into vendasprodutos (codvendafk, codprodutofk, quantv, valorv) values (@pcodvendafk, @pcodprodutofk, @pquantv, @pvalorv)";
        public void Insere_Dados(object aux)
        {
            List<M_VendasProdutos> m_VendasProdutos;
            m_VendasProdutos = (List<M_VendasProdutos>)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            foreach (M_VendasProdutos VendasProdutos in m_VendasProdutos)
            {
                cmd = new SqlCommand(sqlInsere, conn);
                cmd.Parameters.AddWithValue("@pcodvendafk", VendasProdutos.venda.codvenda);
                cmd.Parameters.AddWithValue("@pcodprodutofk", VendasProdutos.produto.codproduto);
                cmd.Parameters.AddWithValue("@pquantv", VendasProdutos.quantv);
                cmd.Parameters.AddWithValue("@pvalorv", VendasProdutos.valorv);

                
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    AjustarEstoque(VendasProdutos.produto.codproduto, -VendasProdutos.quantv);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        private void AjustarEstoque(int codProduto, double quantidade)
        {
            string sqlAtualizaEstoque = "update produtos set quantidade = quantidade + @quantidade where codproduto = @codproduto";

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualizaEstoque, conn);
            cmd.Parameters.AddWithValue("@quantidade", quantidade);
            cmd.Parameters.AddWithValue("@codproduto", codProduto);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro ao atualizar estoque: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }


}
