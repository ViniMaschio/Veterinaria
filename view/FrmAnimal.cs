using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmAnimal : Form
    {
        public FrmAnimal()
        {
            InitializeComponent();
            CarregarTabelaTodos();
            CarregarComboBox();
        }

        Boolean novo = true;
        int posicao;
        List<M_Animal> listAnimal = new List<M_Animal>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtAnimal.Text = "";

            cBoxTipoAnimal.SelectedItem = null;
            cBoxCliente.SelectedItem = null;
            cBoxSexo.SelectedItem = null;
            cBoxRaca.SelectedItem = null;
        }

        public void CarregarComboBox()
        {
            CarregarRaca();
            CarregarSexo();
            CarregarTipoAnimal();
            CarregarCliente();
        }

        public void CarregarRaca()
        {
            C_Raca c_Raca = new C_Raca();
            List<M_Raca> listRaca = new List<M_Raca>();
            listRaca = (List<M_Raca>)c_Raca.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomeraca", typeof(string));
            dataTable.Columns.Add("codraca", typeof(int));

            foreach (M_Raca raca in listRaca)
            {
                dataTable.Rows.Add(raca.nomeraca, raca.codraca);
            }

            cBoxRaca.DataSource = dataTable;
            cBoxRaca.DisplayMember = "nomeraca";
            cBoxRaca.ValueMember = "codraca";
        }

        public void CarregarSexo()
        {
            C_Sexo c_Sexo = new C_Sexo();
            List<M_Sexo> listSexo = new List<M_Sexo>();
            listSexo = (List<M_Sexo>)c_Sexo.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomesexo", typeof(string));
            dataTable.Columns.Add("codsexo", typeof(int));

            foreach (M_Sexo sexo in listSexo)
            {
                dataTable.Rows.Add(sexo.nomesexo, sexo.codsexo);
            }

            cBoxSexo.DataSource = dataTable;
            cBoxSexo.DisplayMember = "nomesexo";
            cBoxSexo.ValueMember = "codsexo";
        }

        public void CarregarTipoAnimal()
        {
            C_TipoAnimal c_TipoAnimal = new C_TipoAnimal();
            List<M_TipoAnimal> listTipoAnimal = new List<M_TipoAnimal>();
            listTipoAnimal = (List<M_TipoAnimal>)c_TipoAnimal.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nometipoanimal", typeof(string));
            dataTable.Columns.Add("codtipoanimal", typeof(int));

            foreach (M_TipoAnimal tipoAnimal in listTipoAnimal)
            {
                dataTable.Rows.Add(tipoAnimal.nometipoanimal, tipoAnimal.codtipoanimal);
            }

            cBoxTipoAnimal.DataSource = dataTable;
            cBoxTipoAnimal.DisplayMember = "nometipoanimal";
            cBoxTipoAnimal.ValueMember = "codtipoanimal";
        }

        public void CarregarCliente()
        {
            C_Cliente c_Cliente = new C_Cliente();
            List<M_Cliente> listCliente = new List<M_Cliente>();
            listCliente = (List<M_Cliente>)c_Cliente.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomecliente", typeof(string));
            dataTable.Columns.Add("codcliente", typeof(int));

            foreach (M_Cliente cliente in listCliente)
            {
                dataTable.Rows.Add(cliente.nomecliente, cliente.codcliente);
            }


            cBoxCliente.DataSource = dataTable;
            cBoxCliente.DisplayMember = "nomecliente";
            cBoxCliente.ValueMember = "codcliente";

        }

        public void CarregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listAnimal.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGView);
                row.Cells[0].Value = listAnimal[i].codanimal;
                row.Cells[1].Value = listAnimal[i].nomeanimal;
                row.Cells[2].Value = listAnimal[i].sexo.nomesexo;
                row.Cells[3].Value = listAnimal[i].raca.nomeraca;
                row.Cells[4].Value = listAnimal[i].tipoanimal.nometipoanimal;
                row.Cells[5].Value = listAnimal[i].cliente.nomecliente;


                dGView.Rows.Add(row);
            }

            if (listAnimal.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        public void CarregarTabelaTodos()
        {
            C_Animal c_Animal = new C_Animal();
            listAnimal = (List<M_Animal>)c_Animal.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Animal c_Animal = new C_Animal();
            listAnimal = new List<M_Animal>();
            listAnimal = (List<M_Animal>)c_Animal.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listAnimal[posicao].codanimal.ToString();
            txtAnimal.Text = listAnimal[posicao].nomeanimal;
            cBoxRaca.SelectedValue = listAnimal[posicao].raca.codraca;
            cBoxTipoAnimal.SelectedValue = listAnimal[posicao].tipoanimal.codtipoanimal;
            cBoxCliente.SelectedValue = listAnimal[posicao].cliente.codcliente;
            cBoxSexo.SelectedValue = listAnimal[posicao].sexo.codsexo;

        }

        public void AtivarBotoes()
        {
            btnNovo.Enabled = false;
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        public void AtivarCampos()
        {
            txtAnimal.Enabled = true;
            cBoxTipoAnimal.Enabled = true;
            cBoxCliente.Enabled = true;
            cBoxSexo.Enabled = true;
            cBoxRaca.Enabled = true;
        }

        public void DesativarBotoes()
        {
            btnNovo.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public void DesativarCampos()
        {
            txtAnimal.Enabled = false;
            cBoxTipoAnimal.Enabled = false;
            cBoxCliente.Enabled = false;
            cBoxSexo.Enabled = false;
            cBoxRaca.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            AtivarBotoes();

            AtivarCampos();

            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            M_Raca m_Raca = new M_Raca();
            M_Sexo m_Sexo = new M_Sexo();
            M_TipoAnimal m_TipoAnimal = new M_TipoAnimal();
            M_Cliente m_Cliente = new M_Cliente();
            M_Animal m_Animal = new M_Animal();

            m_Raca.codraca = int.Parse(cBoxRaca.SelectedValue.ToString());
            m_TipoAnimal.codtipoanimal = int.Parse(cBoxTipoAnimal.SelectedValue.ToString());
            m_Cliente.codcliente = int.Parse(cBoxCliente.SelectedValue.ToString());
            m_Sexo.codsexo = int.Parse(cBoxSexo.SelectedValue.ToString());

            m_Animal.nomeanimal = txtAnimal.Text;
            m_Animal.cliente = m_Cliente;
            m_Animal.raca = m_Raca;
            m_Animal.sexo = m_Sexo;
            m_Animal.tipoanimal = m_TipoAnimal;

            C_Animal c_Animal = new C_Animal();

            if (novo)
            {
                c_Animal.Insere_Dados(m_Animal);
            }
            else
            {
                m_Animal.codanimal = Convert.ToInt32(txtCodigo.Text);
                c_Animal.Atualizar_Dados(m_Animal);
            }

            CarregarTabelaTodos();

            DesativarBotoes();

            DesativarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();

            DesativarBotoes();

            DesativarCampos();

            if (listAnimal.Count > 0)
            {
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_Animal c_Animal = new C_Animal();
                c_Animal.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

                CarregarTabelaTodos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                AtivarBotoes();
                AtivarCampos();

                novo = false;
            }
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            if (listAnimal.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = 0;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicao > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao--;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (posicao < listAnimal.Count - 1)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listAnimal.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listAnimal.Count - 1;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }

        private void dGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicao = e.RowIndex;
            if (posicao >= 0) { AtualizarCampos(); }
        }
    }
}
