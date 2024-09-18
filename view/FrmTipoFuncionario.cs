using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmTipoFuncionario : Form
    {
        public FrmTipoFuncionario()
        {
            InitializeComponent();
            CarregarTabelaTodos();
        }

        Boolean novo = true;
        int posicao;
        List<M_Tipofuncionario> listTipoFuncionario = new List<M_Tipofuncionario>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtTipoFuncionario.Text = "";
        }

        public void CarregarDataGrid()
        {
            dGViews.Rows.Clear();

            for (int i = 0; i < listTipoFuncionario.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGViews);
                row.Cells[0].Value = listTipoFuncionario[i].codtipofuncionario;
                row.Cells[1].Value = listTipoFuncionario[i].nometipofuncionario;
                dGViews.Rows.Add(row);
            }
        }

        public void CarregarTabelaTodos()
        {
            C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();
            listTipoFuncionario = (List<M_Tipofuncionario>)c_TipoFuncionario.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();
            listTipoFuncionario = new List<M_Tipofuncionario>();
            listTipoFuncionario = (List<M_Tipofuncionario>)c_TipoFuncionario.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listTipoFuncionario[posicao].codtipofuncionario.ToString();
            txtTipoFuncionario.Text = listTipoFuncionario[posicao].nometipofuncionario;
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
            txtTipoFuncionario.Enabled = true;
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
            txtTipoFuncionario.Enabled = false;
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
            M_Tipofuncionario m_TipoFuncionario = new M_Tipofuncionario();
            m_TipoFuncionario.nometipofuncionario = txtTipoFuncionario.Text;

            C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();

            if (novo)
            {
                c_TipoFuncionario.Insere_Dados(m_TipoFuncionario);
            }
            else
            {
                m_TipoFuncionario.codtipofuncionario = Convert.ToInt32(txtCodigo.Text);
                c_TipoFuncionario.Atualizar_Dados(m_TipoFuncionario);
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
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();
                c_TipoFuncionario.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

                CarregarTabelaTodos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AtivarBotoes();
            AtivarCampos();

            novo = false;
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            if (listTipoFuncionario.Count > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao = 0;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicao > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao--;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (posicao < listTipoFuncionario.Count - 1)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listTipoFuncionario.Count > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao = listTipoFuncionario.Count - 1;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }

        private void dGViews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicao = e.RowIndex;
            if (posicao >= 0) { AtualizarCampos(); }
        }
    }
}
