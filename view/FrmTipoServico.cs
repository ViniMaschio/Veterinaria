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
    public partial class FrmTipoServico : Form
    {
        public FrmTipoServico()
        {
            InitializeComponent();

            CarregarTabelaTodos();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }

        }

        Boolean novo = true;
        int posicao;
        List<M_TipoServico> listTipoServico = new List<M_TipoServico>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtTipoServico.Text = "";
            txtValorServico.Text = "";
        }

        public void CarregarDataGrid()
        {
            dGViews.Rows.Clear();

            for (int i = 0; i < listTipoServico.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGViews);
                row.Cells[0].Value = listTipoServico[i].codtiposervico;
                row.Cells[1].Value = listTipoServico[i].nometiposervico;
                row.Cells[2].Value = listTipoServico[i].valortiposervico;
                dGViews.Rows.Add(row);
            }

            if (listTipoServico.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGViews.Rows[posicao].Selected = true;
            }
        }

        public void CarregarTabelaTodos()
        {
            C_TipoServico c_TipoServico = new C_TipoServico();
            listTipoServico = (List<M_TipoServico>)c_TipoServico.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_TipoServico c_TipoServico = new C_TipoServico();
            listTipoServico = new List<M_TipoServico>();
            listTipoServico = (List<M_TipoServico>)c_TipoServico.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listTipoServico[posicao].codtiposervico.ToString();
            txtTipoServico.Text = listTipoServico[posicao].nometiposervico;
            txtValorServico.Text = listTipoServico[posicao].valortiposervico.ToString();
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
            txtTipoServico.Enabled = true;
            txtValorServico.Enabled = true;
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
            txtTipoServico.Enabled = false;
            txtValorServico.Enabled = false;
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
            M_TipoServico m_TipoServico = new M_TipoServico();
            m_TipoServico.nometiposervico = txtTipoServico.Text;
            m_TipoServico.valortiposervico = Double.Parse(txtValorServico.Text);

            C_TipoServico c_TipoServico = new C_TipoServico();

            if (novo)
            {
                c_TipoServico.Insere_Dados(m_TipoServico);
            }
            else
            {
                m_TipoServico.codtiposervico = Convert.ToInt32(txtCodigo.Text);
                c_TipoServico.Atualizar_Dados(m_TipoServico);
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

            if (listTipoServico.Count > 0)
            {
                AtualizarCampos();
                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_TipoServico c_TipoServico = new C_TipoServico();
                c_TipoServico.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

                CarregarTabelaTodos();
                posicao = 0;
                if(listTipoServico.Count > 0) { AtualizarCampos(); }
                
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
            if (listTipoServico.Count > 0)
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
            if (posicao < listTipoServico.Count - 1)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listTipoServico.Count > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao = listTipoServico.Count - 1;

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
