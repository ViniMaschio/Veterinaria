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
    internal class C_ItensVendaServico : I_Metodos_Comuns
    {
        private SqlConnection conn;
        private SqlCommand cmd;


        private readonly String sqlApaga = "delete from itensvendaservico where codvendaservicofk = @pcodvendaservicofk";
        public void Apaga_Dados(int aux)
        {
            List<M_ItensVendaServico> vendasProdutos = (List<M_ItensVendaServico>)Buscar_Id(aux);

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodvendaservicofk", aux);

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
            List<M_ItensVendaServico> listItensVendaServico;
            listItensVendaServico = (List<M_ItensVendaServico>)aux;


            Apaga_Dados(listItensVendaServico[0].vendaservico.codvendaservico);


            Insere_Dados(listItensVendaServico);
        }

        public object Buscar_Filtro(string dados)
        {
            throw new NotImplementedException();
        }

        private readonly String sqlBuscaId = "select * from itensvendaservico where codvendaservicofk = @pcodvendaservicofk";
        public object Buscar_Id(int valor)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            C_VendaServico c_VendaServico = new C_VendaServico();
            C_TipoServico c_TipoServico = new C_TipoServico();
            C_CidAnimal c_CidAnimal = new C_CidAnimal();

            List<M_ItensVendaServico> listItensVendaServico = new List<M_ItensVendaServico>();

            cmd = new SqlCommand(sqlBuscaId, conn);
            cmd.Parameters.AddWithValue("@pcodvendaservicofk", valor);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    M_ItensVendaServico m_ItensVendaServico = new M_ItensVendaServico();
                    m_ItensVendaServico.vendaservico = (M_VendaServico)c_VendaServico.Buscar_Id(Convert.ToInt32(reader["codvendaservicofk"]));
                    m_ItensVendaServico.tiposervico = (M_TipoServico)c_TipoServico.Buscar_Id(Convert.ToInt32(reader["codtiposervicofk"]));
                    m_ItensVendaServico.quant = Convert.ToDouble(reader["quant"]);
                    m_ItensVendaServico.valor = Convert.ToDouble(reader["valor"]);
                    m_ItensVendaServico.cidanimal =(M_CidAnimal)c_CidAnimal.Buscar_Id(Convert.ToInt32(reader["codcidanimalfk"]));

                    listItensVendaServico.Add(m_ItensVendaServico);
                }
            }
            catch (Exception)
            {

                throw;
            }


            conn.Close();
            return listItensVendaServico;
        }

        public object Buscar_Todos()
        {

            throw new NotImplementedException();

        }

        private readonly String sqlInsere = "insert into itensvendaservico (codtiposervicofk, codvendaservicofk, quant, valor,codcidanimalfk) " +
            "values (@pcodtiposervicofk, @pcodvendaservicofk, @pquant, @pvalor, @pcodcidanimalfk)";
        public void Insere_Dados(object aux)
        {
            List<M_ItensVendaServico> m_ItensVendaServico;
            m_ItensVendaServico = (List<M_ItensVendaServico>)aux;

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            foreach (M_ItensVendaServico itensVendaServico in m_ItensVendaServico)
            {
                cmd = new SqlCommand(sqlInsere, conn);
                cmd.Parameters.AddWithValue("@pcodtiposervicofk", itensVendaServico.tiposervico.codtiposervico);
                cmd.Parameters.AddWithValue("@pcodvendaservicofk", itensVendaServico.vendaservico.codvendaservico);
                cmd.Parameters.AddWithValue("@pquant", itensVendaServico.quant);
                cmd.Parameters.AddWithValue("@pvalor", itensVendaServico.valor);
                cmd.Parameters.AddWithValue("@pcodcidanimalfk", itensVendaServico.cidanimal.codcidanimal);


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

        }

    }
}
