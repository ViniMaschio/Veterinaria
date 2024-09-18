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
    public partial class FrmTelefone : Form
    {
        Boolean novo = true;
        int posicao;
        List<M_Telefone> listTelefone = new List<M_Telefone>();

        public FrmTelefone()
        {
            InitializeComponent();

            CarregarTabelaTodos();
        }
        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtTelefone.Text = "";
        }

        public void CarregarDataGrid()
        {
            dGViews.Rows.Clear();

            for (int i = 0; i < listTelefone.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();
                
                row.CreateCells(dGViews);
                row.Cells[0].Value = listTelefone[i].codtelefone;
                row.Cells[1].Value = Int64.Parse(listTelefone[i].numerotelefone).ToString(@"(00) 00000-0000");
                dGViews.Rows.Add(row);
            }
            if (listTelefone.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGViews.Rows[posicao].Selected = true;
            }
        }

        public void CarregarTabelaTodos()
        {
            C_Telefone c_Telefone = new C_Telefone();
            listTelefone = (List<M_Telefone>)c_Telefone.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Telefone c_Telefone = new C_Telefone();
            listTelefone = new List<M_Telefone>();
            listTelefone = (List<M_Telefone>)c_Telefone.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listTelefone[posicao].codtelefone.ToString();
            txtTelefone.Text = listTelefone[posicao].numerotelefone.ToString();
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
            txtTelefone.Enabled = true;
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
            txtTelefone.Enabled = false;
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
            M_Telefone m_Telefone = new M_Telefone();
            m_Telefone.numerotelefone = txtTelefone.Text;

            C_Telefone c_Telefone = new C_Telefone();

            if (novo)
            {
                c_Telefone.Insere_Dados(m_Telefone);
            }
            else
            {
                m_Telefone.codtelefone = Convert.ToInt32(txtCodigo.Text);
                c_Telefone.Atualizar_Dados(m_Telefone);
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

            if (listTelefone.Count > 0)
            {
                AtualizarCampos();
                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_Telefone c_Telefone = new C_Telefone();
                c_Telefone.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if (listTelefone.Count > 0)
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
            if (posicao < listTelefone.Count - 1)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGViews.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listTelefone.Count > 0)
            {
                dGViews.Rows[posicao].Selected = false;
                posicao = listTelefone.Count - 1;

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
