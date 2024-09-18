using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmCidAnimal : Form
    {
        public FrmCidAnimal()
        {
            InitializeComponent();

            CarregarTabelaTodos();
        }

        Boolean novo = true;
        int posicao;
        List<M_CidAnimal> lisCidAnimal = new List<M_CidAnimal>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtCidAnimal.Text = "";
            txtDescricao.Text = "";
        }

        public void CarregarDataGrid()
        {
            dGViews.Rows.Clear();

            for (int i = 0; i < lisCidAnimal.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGViews);
                row.Cells[0].Value = lisCidAnimal[i].codcidanimal;
                row.Cells[1].Value = lisCidAnimal[i].nomecidanimal;
                row.Cells[2].Value = lisCidAnimal[i].descricao;
                dGViews.Rows.Add(row);
            }
        }

        public void CarregarTabelaTodos()
        {
            C_CidAnimal c_CidAnimal = new C_CidAnimal();
            lisCidAnimal = (List<M_CidAnimal>)c_CidAnimal.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_CidAnimal c_CidAnimal = new C_CidAnimal();
            lisCidAnimal = new List<M_CidAnimal>();
            lisCidAnimal = (List<M_CidAnimal>)c_CidAnimal.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = lisCidAnimal[posicao].codcidanimal.ToString();
            txtCidAnimal.Text = lisCidAnimal[posicao].nomecidanimal;
            txtDescricao.Text = lisCidAnimal[posicao].descricao;
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
            txtCidAnimal.Enabled = true;
            txtDescricao.Enabled = true;
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
            txtCidAnimal.Enabled = false;
            txtDescricao.Enabled = false;
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
            M_CidAnimal m_CidAnimal = new M_CidAnimal();
            m_CidAnimal.nomecidanimal = txtCidAnimal.Text;
            m_CidAnimal.descricao = txtDescricao.Text;

            C_CidAnimal c_CidAnimal = new C_CidAnimal();

            if (novo)
            {
                c_CidAnimal.Insere_Dados(m_CidAnimal);
            }
            else
            {
                m_CidAnimal.codcidanimal = Convert.ToInt32(txtCodigo.Text);
                c_CidAnimal.Atualizar_Dados(m_CidAnimal);
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
                C_CidAnimal c_CidAnimal = new C_CidAnimal();
                c_CidAnimal.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if (lisCidAnimal.Count > 0)
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
            if (posicao < lisCidAnimal.Count - 1)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (lisCidAnimal.Count > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao = lisCidAnimal.Count - 1;

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
