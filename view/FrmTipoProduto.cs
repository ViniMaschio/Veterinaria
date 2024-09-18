using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmTipoProduto : Form
    {
        public FrmTipoProduto()
        {
            InitializeComponent();
            CarregarTabelaTodos();
        }


        Boolean novo = true;
        int posicao;
        List<M_TipoProduto> listTipoProduto = new List<M_TipoProduto>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtTipoProduto.Text = "";
        }

        public void CarregarDataGrid()
        {
            dGViews.Rows.Clear();

            for (int i = 0; i < listTipoProduto.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGViews);
                row.Cells[0].Value = listTipoProduto[i].codtipoproduto;
                row.Cells[1].Value = listTipoProduto[i].nometipoproduto;
                dGViews.Rows.Add(row);
            }
        }

        public void CarregarTabelaTodos()
        {
            C_TipoProduto c_TipoProduto = new C_TipoProduto();
            listTipoProduto = (List<M_TipoProduto>)c_TipoProduto.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_TipoProduto c_TipoProduto = new C_TipoProduto();
            listTipoProduto = new List<M_TipoProduto>();
            listTipoProduto = (List<M_TipoProduto>)c_TipoProduto.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listTipoProduto[posicao].codtipoproduto.ToString();
            txtTipoProduto.Text = listTipoProduto[posicao].nometipoproduto;
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
            txtTipoProduto.Enabled = true;
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
            txtTipoProduto.Enabled = false;
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
            M_TipoProduto m_TipoProduto = new M_TipoProduto();
            m_TipoProduto.nometipoproduto = txtTipoProduto.Text;

            C_TipoProduto c_TipoProduto = new C_TipoProduto();

            if (novo)
            {
                c_TipoProduto.Insere_Dados(m_TipoProduto);
            }
            else
            {
                m_TipoProduto.codtipoproduto = Convert.ToInt32(txtCodigo.Text);
                c_TipoProduto.Atualizar_Dados(m_TipoProduto);
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
                C_TipoProduto c_TipoProduto = new C_TipoProduto();
                c_TipoProduto.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

                CarregarTabelaTodos();
                posicao = 0;
                AtualizarCampos();
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
            if (listTipoProduto.Count > 0)
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
            if (posicao < listTipoProduto.Count - 1)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listTipoProduto.Count > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao = listTipoProduto.Count - 1;

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
