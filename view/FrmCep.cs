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
    public partial class FrmCep : Form
    {
        public FrmCep()
        {
            InitializeComponent();

            CarregarTabelaTodos();
        }

        Boolean novo = true;
        int posicao;
        List<M_Cep> listaCep = new List<M_Cep>();

        public void CarregarTabelaTodos()
        {

            C_Cep c_Cep = new C_Cep();
            listaCep = (List<M_Cep>)c_Cep.Buscar_Todos();

            LimparCampos();
            CarregarDataGrid();    
        }

        public void CarregarTabelaFiltro()
        {
            C_Cep c_Cep = new C_Cep();
            listaCep = new List<M_Cep>();
            listaCep = (List<M_Cep>)c_Cep.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();
            CarregarDataGrid();
        }

        public void CarregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listaCep.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaCep[i].codcep;
                row.Cells[1].Value = listaCep[i].numerocep;
                dGView.Rows.Add(row);
            }
            
            if (listaCep.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            TxtCep.Text = "";
        }

        private void AtualizarCampos()
        {
            txtCodigo.Text = listaCep[posicao].codcep.ToString();
            TxtCep.Text = listaCep[posicao].numerocep;
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
            TxtCep.Enabled = true;
        }

        private void DesativarCampos()
        {
            TxtCep.Enabled = false;
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
            posicao = e.RowIndex;
            if(posicao >= 0) AtualizarCampos();
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
            M_Cep m_Cep = new M_Cep();
            m_Cep.numerocep = TxtCep.Text;

            C_Cep c_Cep = new C_Cep();

            if (novo)
            {
                c_Cep.Insere_Dados(m_Cep);
            }
            else
            {
                m_Cep.codcep = Convert.ToInt32(txtCodigo.Text);
                c_Cep.Atualizar_Dados(m_Cep);
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

            if (listaCep.Count > 0)
            {
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                C_Cep c_Cep = new C_Cep();

                c_Cep.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if(listaCep.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if(posicao > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao--;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (listaCep.Count - 1 > posicao)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if(listaCep.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listaCep.Count - 1;
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
