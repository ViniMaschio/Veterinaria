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
    public partial class FrmRua : Form
    {
        public FrmRua()
        {
            InitializeComponent();

            CarregarTabelaTodos();
        }

        Boolean novo = true;
        int posicao;
        List<M_Rua> listaRua = new List<M_Rua>();

        public void CarregarTabelaTodos()
        {

            C_Rua c_Rua = new C_Rua();
            listaRua = (List<M_Rua>)c_Rua.Buscar_Todos();

            LimparCampos();

            CarrregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Rua c_Rua = new C_Rua();
            listaRua = new List<M_Rua>();
            listaRua = (List<M_Rua>)c_Rua.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarrregarDataGrid();
        }

        public void CarrregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listaRua.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaRua[i].codrua;
                row.Cells[1].Value = listaRua[i].nomerua;
                dGView.Rows.Add(row);
            }

            if (listaRua.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void AtualizarCampos()
        {
            txtCodigo.Text = listaRua[posicao].codrua.ToString();
            txtRua.Text = listaRua[posicao].nomerua.ToString();
        }

        private void AtivarBotoes()
        {
            btnNovo.Enabled = false;
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void AtivarCampos()
        {
            txtRua.Enabled = true;
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtRua.Text = "";
        }

        private void DesativarCampos()
        {
            txtRua.Enabled = false;
        }

        private void DesativarBotoes()
        {
            btnNovo.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void dGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow dr = dGView.Rows[index];
            txtCodigo.Text = dr.Cells[0].Value.ToString();
            txtRua.Text = dr.Cells[1].Value.ToString();
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
            M_Rua m_Rua = new M_Rua();
            m_Rua.nomerua = txtRua.Text;

            C_Rua c_Rua = new C_Rua();

            if (novo)
            {
                c_Rua.Insere_Dados(m_Rua);
            }
            else
            {
                m_Rua.codrua = Int32.Parse(txtCodigo.Text);
                c_Rua.Atualizar_Dados(m_Rua);
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
                C_Rua c_Rua = new C_Rua();

                c_Rua.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if (listaRua.Count > 0)
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
            if (listaRua.Count - 1 > posicao)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listaRua.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listaRua.Count - 1;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }
    }
}
