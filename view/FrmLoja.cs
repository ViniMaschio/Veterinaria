using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmLoja : Form
    {
        public FrmLoja()
        {
            InitializeComponent();
            CarregarComboBox();
            CarregarTabelaTodos();
            
        }

        Boolean novo = true;
        int posicao;
        List<M_Loja> listLoja = new List<M_Loja>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNomeLoja.Text = "";
            txtCnpj.Text = "";
            txtNumero.Text = "";
            cBoxCep.SelectedItem = null;
            cBoxCidade.SelectedItem = null;
            cBoxEstado.SelectedItem = null;
            cBoxPais.SelectedItem = null;
            cBoxRua.SelectedItem = null;
            cBoxBairro.SelectedItem = null;

        }

        public void CarregarComboBox()
        {
            CarregarCidade();

            CarregarCep();

            CarregarEstado();

            CarregarPais();

            CarregarRua();

            CarregarBairro();

        }

        public void CarregarBairro()
        {
            C_Bairro c_Bairro = new C_Bairro();
            List<M_Bairro> listBairro = new List<M_Bairro>();
            listBairro = (List<M_Bairro>)c_Bairro.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomebairro", typeof(string));
            dataTable.Columns.Add("codbairro", typeof(int));

            foreach (M_Bairro bairro in listBairro)
            {
                dataTable.Rows.Add(bairro.nomebairro, bairro.codbairro);
            }

            cBoxBairro.DataSource = dataTable;
            cBoxBairro.DisplayMember = "nomebairro";
            cBoxBairro.ValueMember = "codbairro";
        }

        public void CarregarRua()
        {
            C_Rua c_Rua = new C_Rua();
            List<M_Rua> listRua = new List<M_Rua>();
            listRua = (List<M_Rua>)c_Rua.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomerua", typeof(string));
            dataTable.Columns.Add("codrua", typeof(int));

            foreach (M_Rua rua in listRua)
            {
                dataTable.Rows.Add(rua.nomerua, rua.codrua);
            }

            cBoxRua.DataSource = dataTable;
            cBoxRua.DisplayMember = "nomerua";
            cBoxRua.ValueMember = "codrua";
        }

        public void CarregarPais()
        {
            C_Pais c_Pais = new C_Pais();
            List<M_Pais> listPais = new List<M_Pais>();
            listPais = (List<M_Pais>)c_Pais.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomepais", typeof(string));
            dataTable.Columns.Add("codpais", typeof(int));

            foreach (M_Pais pais in listPais)
            {
                dataTable.Rows.Add(pais.nomepais, pais.codpais);
            }

            cBoxPais.DataSource = dataTable;
            cBoxPais.DisplayMember = "nomepais";
            cBoxPais.ValueMember = "codpais";
        }

        public void CarregarEstado()
        {
            C_Estado c_Estado = new C_Estado();
            List<M_Estado> listEstado = new List<M_Estado>();
            listEstado = (List<M_Estado>)c_Estado.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomeestado", typeof(string));
            dataTable.Columns.Add("codestado", typeof(int));

            foreach (M_Estado estado in listEstado)
            {
                dataTable.Rows.Add(estado.nomeestado, estado.codestado);
            }


            cBoxEstado.DataSource = dataTable;
            cBoxEstado.DisplayMember = "nomeestado";
            cBoxEstado.ValueMember = "codestado";

        }

        public void CarregarCidade()
        {
            C_Cidade c_Cidade = new C_Cidade();
            List<M_Cidade> listCidade = new List<M_Cidade>();
            listCidade = (List<M_Cidade>)c_Cidade.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomecidade", typeof(string));
            dataTable.Columns.Add("codcidade", typeof(int));

            foreach (M_Cidade cidade in listCidade)
            {
                dataTable.Rows.Add(cidade.nomecidade, cidade.codcidade);
            }

            cBoxCidade.DataSource = dataTable;
            cBoxCidade.DisplayMember = "nomecidade";
            cBoxCidade.ValueMember = "codcidade";
        }

        public void CarregarCep()
        {
            C_Cep c_Cep = new C_Cep();

            List<M_Cep> listCep = new List<M_Cep>();
            listCep = (List<M_Cep>)c_Cep.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("numerocep", typeof(string));
            dataTable.Columns.Add("codcep", typeof(int));

            foreach (M_Cep cep in listCep)
            {
                dataTable.Rows.Add(cep.numerocep, cep.codcep);
            }

            cBoxCep.DataSource = dataTable;
            cBoxCep.DisplayMember = "numerocep";
            cBoxCep.ValueMember = "codcep";
        }

        public void CarregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listLoja.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGView);
                row.Cells[0].Value = listLoja[i].codloja;
                row.Cells[1].Value = listLoja[i].nomeloja;
                row.Cells[2].Value = listLoja[i].cnpj;
                row.Cells[3].Value = listLoja[i].rua.nomerua;
                row.Cells[4].Value = listLoja[i].numeroloja;
                row.Cells[5].Value = listLoja[i].bairro.nomebairro;
                row.Cells[6].Value = listLoja[i].cep.numerocep;
                row.Cells[7].Value = listLoja[i].cidade.nomecidade;
                row.Cells[8].Value = listLoja[i].estado.nomeestado;
                row.Cells[9].Value = listLoja[i].pais.nomepais;

                dGView.Rows.Add(row);
            }

            if (listLoja.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        public void CarregarTabelaTodos()
        {
            C_Loja c_Loja = new C_Loja();
            listLoja = (List<M_Loja>)c_Loja.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Loja c_Loja = new C_Loja();
            listLoja = new List<M_Loja>();
            listLoja = (List<M_Loja>)c_Loja.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listLoja[posicao].codloja.ToString();
            txtNomeLoja.Text = listLoja[posicao].nomeloja;
            txtCnpj.Text = listLoja[posicao].cnpj;
            txtNumero.Text = listLoja[posicao].numeroloja;
            cBoxCep.SelectedValue = listLoja[posicao].cep.codcep;
            cBoxCidade.SelectedValue = listLoja[posicao].cidade.codcidade;
            cBoxEstado.SelectedValue = listLoja[posicao].estado.codestado;
            cBoxPais.SelectedValue = listLoja[posicao].pais.codpais;
            cBoxRua.SelectedValue = listLoja[posicao].rua.codrua;
            cBoxBairro.SelectedValue = listLoja[posicao].bairro.codbairro;
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
            txtNomeLoja.Enabled = true;
            txtCnpj.Enabled = true;
            txtNumero.Enabled = true;
            cBoxCep.Enabled = true;
            cBoxCidade.Enabled = true;
            cBoxEstado.Enabled = true;
            cBoxPais.Enabled = true;
            cBoxRua.Enabled = true;
            cBoxBairro.Enabled = true;

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
            txtNomeLoja.Enabled = false;
            txtCnpj.Enabled = false;
            txtNumero.Enabled = false;
            cBoxCep.Enabled = false;
            cBoxCidade.Enabled = false;
            cBoxEstado.Enabled = false;
            cBoxPais.Enabled = false;
            cBoxRua.Enabled = false;
            cBoxBairro.Enabled = false;

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
            M_Loja m_Loja = new M_Loja();
            M_Cep m_Cep = new M_Cep();
            M_Cidade m_Cidade = new M_Cidade();
            M_Estado m_Estado = new M_Estado();
            M_Pais m_Pais = new M_Pais();
            M_Rua m_Rua = new M_Rua();
            M_Bairro m_Bairro = new M_Bairro();

            m_Cep.codcep = int.Parse(cBoxCep.SelectedValue.ToString());
            m_Cidade.codcidade = int.Parse(cBoxCidade.SelectedValue.ToString());
            m_Estado.codestado = int.Parse(cBoxEstado.SelectedValue.ToString());
            m_Pais.codpais = int.Parse(cBoxPais.SelectedValue.ToString());
            m_Rua.codrua = int.Parse(cBoxRua.SelectedValue.ToString());
            m_Bairro.codbairro = int.Parse(cBoxBairro.SelectedValue.ToString());

            m_Loja.nomeloja = txtNomeLoja.Text;
            m_Loja.cnpj = txtCnpj.Text;
            m_Loja.numeroloja = txtNumero.Text;
            m_Loja.cep = m_Cep;
            m_Loja.cidade = m_Cidade;
            m_Loja.estado = m_Estado;
            m_Loja.pais = m_Pais;
            m_Loja.rua = m_Rua;
            m_Loja.bairro = m_Bairro;


            C_Loja c_Loja = new C_Loja();

            if (novo)
            {
                c_Loja.Insere_Dados(m_Loja);
            }
            else
            {
                m_Loja.codloja = Convert.ToInt32(txtCodigo.Text);
                c_Loja.Atualizar_Dados(m_Loja);
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

            if (listLoja.Count > 0)
            {
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_Loja c_loja = new C_Loja();
                c_loja.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if (listLoja.Count > 0)
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
            if (posicao < listLoja.Count - 1)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listLoja.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listLoja.Count - 1;

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
