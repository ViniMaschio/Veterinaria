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
    internal class C_Animal : I_Metodos_Comuns
    {

        private SqlConnection conn;
        private SqlCommand cmd;

        private C_Sexo c_Sexo = new C_Sexo();
        private C_Raca c_Raca = new C_Raca();
        private C_Cliente c_Cliente = new C_Cliente();
        private C_TipoAnimal c_TipoAnimal = new C_TipoAnimal();


        private readonly String sqlApaga = "delete from animal where codanimal = @pcodanimal";
        public void Apaga_Dados(int aux)
        {
            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlApaga, conn);
            cmd.Parameters.AddWithValue("@pcodanimal", aux);

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

        private readonly String sqlAtualiza = "update animal set nomeanimal = @pnomeanimal, codsexofk = @pcodsexo, " +
            "codracafk = @pcodracafk, codtipoanimalfk = @pcodtipoanimal ,codclientefk = @pcodcliente where codanimal = @pcodanimal";
        public void Atualizar_Dados(object aux)
        {
            M_Animal m_Animal = new M_Animal();
            m_Animal = (M_Animal)aux;


            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlAtualiza, conn);
            cmd.Parameters.AddWithValue("@pnomeanimal", m_Animal.nomeanimal);
            cmd.Parameters.AddWithValue("@pcodsexo", m_Animal.sexo.codsexo);
            cmd.Parameters.AddWithValue("@pcodracafk", m_Animal.raca.codraca);
            cmd.Parameters.AddWithValue("@pcodtipoanimal", m_Animal.tipoanimal.codtipoanimal);
            cmd.Parameters.AddWithValue("@pcodcliente", m_Animal.cliente.codcliente);
            cmd.Parameters.AddWithValue("@pcodanimal", m_Animal.codanimal);
           

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

        private readonly String sqlFiltro = "select * from animal where nomeanimal like @pnomeanimal";
        public Object Buscar_Filtro(string dados)
        {
            List<M_Animal> listAnimal = new List<M_Animal>();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlFiltro, conn);

            
            cmd.Parameters.AddWithValue("@pnomeanimal", dados + "%");

            SqlDataReader reader;
            conn.Open();

            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    M_Animal aux = new M_Animal
                    {
                        codanimal = Int32.Parse(reader["codanimal"].ToString()),
                        nomeanimal = reader["nomeanimal"].ToString(),
                        sexo = (M_Sexo)c_Sexo.Buscar_Id(Int32.Parse(reader["codsexofk"].ToString())),
                        raca = (M_Raca)c_Raca.Buscar_Id(Int32.Parse(reader["codracafk"].ToString())),
                        tipoanimal = (M_TipoAnimal)c_TipoAnimal.Buscar_Id(Int32.Parse(reader["codtipoanimalfk"].ToString())),
                        cliente = (M_Cliente)c_Cliente.Buscar_Id(Int32.Parse(reader["codclientefk"].ToString()))
                    };

                    listAnimal.Add(aux);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }


            return listAnimal;
        }

        private readonly String sqlBuscaId = "select * from animal where codanimal = @pcodanimal";
        public object Buscar_Id(int valor)
        {
            M_Animal aux = new M_Animal();

            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlBuscaId, conn);


            cmd.Parameters.AddWithValue("@pcodanimal", valor);

            SqlDataReader reader;
            conn.Open();

            try
            {

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aux.codanimal = Int32.Parse(reader["codanimal"].ToString());
                    aux.nomeanimal = reader["nomeanimal"].ToString();
                    aux.sexo = (M_Sexo)c_Sexo.Buscar_Id(Int32.Parse(reader["codsexofk"].ToString()));
                    aux.raca = (M_Raca)c_Raca.Buscar_Id(Int32.Parse(reader["codracafk"].ToString()));
                    aux.tipoanimal = (M_TipoAnimal)c_TipoAnimal.Buscar_Id(Int32.Parse(reader["codtipoanimalfk"].ToString()));
                    aux.cliente = (M_Cliente)c_Cliente.Buscar_Id(Int32.Parse(reader["codclientefk"].ToString()));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            conn.Close();

            return aux;

        }

        private readonly String sqlTodos = "select * from animal";
        public Object Buscar_Todos()
        {
            List<M_Animal> listAnimal = new List<M_Animal>();

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
                    M_Animal aux = new M_Animal
                    {
                        codanimal = Int32.Parse(reader["codanimal"].ToString()),
                        nomeanimal = reader["nomeanimal"].ToString(),
                        sexo = (M_Sexo)c_Sexo.Buscar_Id(Int32.Parse(reader["codsexofk"].ToString())),
                        raca = (M_Raca)c_Raca.Buscar_Id(Int32.Parse(reader["codracafk"].ToString())),
                        tipoanimal = (M_TipoAnimal)c_TipoAnimal.Buscar_Id(Int32.Parse(reader["codtipoanimalfk"].ToString())),
                        cliente = (M_Cliente)c_Cliente.Buscar_Id(Int32.Parse(reader["codclientefk"].ToString()))
                    };

                    listAnimal.Add(aux);
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

            return listAnimal;
        }

        private readonly String sqlInsere = "insert into animal(nomeanimal,codsexofk,codracafk,codtipoanimalfk,codclientefk) values" +
            " (@pnomeanimal,@pcodsexofk,@pcodracafk,@pcodtipoanimalfk,@pcodclientefk)";
        public void Insere_Dados(object aux)
        {
            M_Animal m_loja = new M_Animal();
            m_loja = (M_Animal)aux;


            Conexao conexao = new Conexao();
            conn = conexao.ConectarBanco();

            cmd = new SqlCommand(sqlInsere, conn);
            cmd.Parameters.AddWithValue("@pnomeanimal", m_loja.nomeanimal);
            cmd.Parameters.AddWithValue("@pcodsexofk", m_loja.sexo.codsexo);
            cmd.Parameters.AddWithValue("@pcodracafk", m_loja.raca.codraca);
            cmd.Parameters.AddWithValue("@pcodtipoanimalfk", m_loja.tipoanimal.codtipoanimal);
            cmd.Parameters.AddWithValue("@pcodclientefk", m_loja.cliente.codcliente);
            

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
