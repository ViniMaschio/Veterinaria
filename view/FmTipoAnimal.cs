using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FmTipoAnimal : Form
    {

        
        Boolean novo = true;
        int posicao;
        List<M_TipoAnimal> listaTipoAnimal = new List<M_TipoAnimal>();

        public FmTipoAnimal()
        {
            InitializeComponent();

            CarregarTabelaTodos();

        }

        public void CarregarTabelaTodos()
        {

            C_TipoAnimal c_TipoAnimal = new C_TipoAnimal();
            listaTipoAnimal = (List <M_TipoAnimal>)c_TipoAnimal.Buscar_Todos();

            LimparCampos();

            CarrregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_TipoAnimal c_TipoAnimal = new C_TipoAnimal();
            listaTipoAnimal = new List<M_TipoAnimal>();
            listaTipoAnimal = (List<M_TipoAnimal>)c_TipoAnimal.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarrregarDataGrid();
        }

        public void CarrregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listaTipoAnimal.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaTipoAnimal[i].codtipoanimal;
                row.Cells[1].Value = listaTipoAnimal[i].nometipoanimal;
                dGView.Rows.Add(row);
            }

            if (listaTipoAnimal.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void AtualizarCampos()
        {
            txtCodigo.Text = listaTipoAnimal[posicao].codtipoanimal.ToString();
            txtTipoAnimal.Text = listaTipoAnimal[posicao].nometipoanimal.ToString();
        }


        private void dGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow dr = dGView.Rows[index];
            txtCodigo.Text = dr.Cells[0].Value.ToString();
            txtTipoAnimal.Text = dr.Cells[1].Value.ToString();
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
            txtTipoAnimal.Enabled = true;
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtTipoAnimal.Text = "";
        }

        private void DesativarCampos()
        {
            txtTipoAnimal.Enabled = false;
        }

        private void DesativarBotoes()
        {
            btnNovo.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
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
            M_TipoAnimal m_TipoAnimal = new M_TipoAnimal();
            m_TipoAnimal.nometipoanimal = txtTipoAnimal.Text;

            C_TipoAnimal c_TipoAnimal = new C_TipoAnimal();

            if (novo == true)
            {
                c_TipoAnimal.Insere_Dados(m_TipoAnimal);
            }
            else
            {
                m_TipoAnimal.codtipoanimal = Int32.Parse(txtCodigo.Text);
                c_TipoAnimal.Atualizar_Dados(m_TipoAnimal);
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
                C_TipoAnimal c_TipoAnimal = new C_TipoAnimal();

                int codigo = int.Parse(txtCodigo.Text);
                c_TipoAnimal.Apaga_Dados(codigo);

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
            dGView.Rows[posicao].Selected = false;
            posicao = 0;
            AtualizarCampos();
            dGView.Rows[posicao].Selected = true;
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
            int total = listaTipoAnimal.Count - 1;
            if (total > posicao)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            dGView.Rows[posicao].Selected = false;
            posicao = listaTipoAnimal.Count - 1;
            AtualizarCampos();
            dGView.Rows[posicao].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }

    }
}
