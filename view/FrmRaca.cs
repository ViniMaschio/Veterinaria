using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmRaca : Form
    {
        Boolean novo = true;
        int posicao;
        List<M_Raca> lista_raca = new List<M_Raca>();

        public FrmRaca()
        {
            InitializeComponent();

            CarregaTabelaTodos();

        }

        private void atualizaCampos()
        {
            txtCodigo.Text = lista_raca[posicao].codraca.ToString();
            txtRaca.Text = lista_raca[posicao].nomeraca.ToString();
        }

        public void CarregaTabelaTodos()
        {
            C_Raca cr = new C_Raca();

            lista_raca = (List<M_Raca>)cr.Buscar_Todos();

            limparCampos();
            CarregarDataGrid();
            

        } 

        public void CarregarTabelaFiltro()
        {
            C_Raca cr = new C_Raca();

            lista_raca = (List<M_Raca>)cr.Buscar_Filtro(txtBuscar.Text);

            limparCampos();
            CarregarDataGrid();
        }

        public void CarregarDataGrid()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < lista_raca.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = lista_raca[i].codraca;
                row.Cells[1].Value = lista_raca[i].nomeraca;
                dataGridView1.Rows.Add(row);
            }

            if (lista_raca.Count > 0)
            {
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicao = e.RowIndex;
            if (posicao >= 0) { atualizaCampos(); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            limparCampos();

            ativarCampos();

            AtivaBotoes();

            novo = true;
        }

        private void AtivaBotoes()
        {
            btnNovo.Enabled = false;
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void ativarCampos()
        {
            txtRaca.Enabled = true;

        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtRaca.Text = "";
        }

        private void desativaCampos()
        {
            txtRaca.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            M_Raca raca = new M_Raca();

            raca.nomeraca = txtRaca.Text;

            C_Raca c_Raca = new C_Raca();

            if (novo == true)
            {
                c_Raca.Insere_Dados(raca);
            }
            else
            {
                raca.codraca = Int32.Parse(txtCodigo.Text);
                c_Raca.Atualizar_Dados(raca);
            }


            CarregaTabelaTodos();

            desativaCampos();

            desativaBotoes();
        }

        private void desativaBotoes()
        {
            btnNovo.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desativaBotoes();
            desativaCampos();

            if (lista_raca.Count > 0)
            {
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            
            if (txtCodigo.Text != "")
            {
                C_Raca raca = new C_Raca();
                int valor = Int32.Parse(txtCodigo.Text);
                raca.Apaga_Dados(valor);
                CarregaTabelaTodos();
                
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                AtivaBotoes();
                ativarCampos();

                novo = false;
            }
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            if (lista_raca.Count != 0)
            {
                dataGridView1.Rows[posicao].Selected = false;
                posicao = 0;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            int total = lista_raca.Count - 1;
            if (total > posicao)
            {
                dataGridView1.Rows[posicao].Selected = false;
                posicao++;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (lista_raca.Count != 0) 
            { 
            dataGridView1.Rows[posicao].Selected = false;
            posicao = lista_raca.Count - 1;
            atualizaCampos();
            dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {


            if (posicao > 0)
            {
                dataGridView1.Rows[posicao].Selected = false;
                posicao--;
                atualizaCampos();
                dataGridView1.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();

        }

    }
}
