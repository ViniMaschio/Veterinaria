using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmMarca : Form
    {
        public FrmMarca()
        {
            InitializeComponent();

            CarregarTabelaTodos();
        }
        
        Boolean novo = true;
        int posicao;
        List<M_Marca> listMarca = new List<M_Marca>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtMarca.Text = "";
        }

        public void CarregarDataGrid()
        {
            dGViews.Rows.Clear();

            for (int i = 0; i < listMarca.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGViews);
                row.Cells[0].Value = listMarca[i].codmarca;
                row.Cells[1].Value = listMarca[i].nomemarca;
                dGViews.Rows.Add(row);
            }
        }

        public void CarregarTabelaTodos()
        {
            C_Marca c_Marca = new C_Marca();
            listMarca = (List<M_Marca>)c_Marca.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Marca c_Marca = new C_Marca();
            listMarca = new List<M_Marca>();
            listMarca = (List<M_Marca>)c_Marca.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listMarca[posicao].codmarca.ToString();
            txtMarca.Text = listMarca[posicao].nomemarca;
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
            txtMarca.Enabled = true;
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
            txtMarca.Enabled = false;
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
            M_Marca m_Marca = new M_Marca();
            m_Marca.nomemarca = txtMarca.Text;

            C_Marca c_Marca = new C_Marca();

            if (novo)
            {
                c_Marca.Insere_Dados(m_Marca);
            }
            else
            {
                m_Marca.codmarca = Convert.ToInt32(txtCodigo.Text);
                c_Marca.Atualizar_Dados(m_Marca);
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
                C_Marca c_Marca = new C_Marca();
                c_Marca.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if (listMarca.Count > 0)
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
            if (posicao < listMarca.Count - 1)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listMarca.Count > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao = listMarca.Count - 1;

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
