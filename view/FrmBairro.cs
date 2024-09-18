using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmBairro : Form
    {
        Boolean novo = true;
        int posicao;
        List<M_Bairro> listaBairro = new List<M_Bairro>();


        public FrmBairro()
        {
            InitializeComponent();

            CarregarTabelaTodos();
        }

        public void LimparCampos()
        {
            TxtCodigo.Text = "";
            TxtBairro.Text = "";
        }

        public void CarregarDataGrid()
        {
            DataGridBairro.Rows.Clear();

            for(int i = 0; i < listaBairro.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DataGridBairro);
                row.Cells[0].Value = listaBairro[i].codbairro;
                row.Cells[1].Value = listaBairro[i].nomebairro;
                DataGridBairro.Rows.Add(row);
            }

            
            if (listaBairro.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                DataGridBairro.Rows[posicao].Selected = true;
            }
        }

        public void CarregarTabelaTodos()
        {
            C_Bairro c_Bairro = new C_Bairro();
            listaBairro = (List<M_Bairro>)c_Bairro.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Bairro c_Bairro = new C_Bairro();
            listaBairro = new List<M_Bairro>();
            listaBairro = (List<M_Bairro>)c_Bairro.Buscar_Filtro(TxtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            TxtCodigo.Text = listaBairro[posicao].codbairro.ToString();
            TxtBairro.Text = listaBairro[posicao].nomebairro.ToString();
        }

       public void AtivarBotoes()
        {
            BtnNovo.Enabled = false;
            BtnApagar.Enabled = false;
            BtnEditar.Enabled = false;

            BtnSalvar.Enabled = true;
            BtnCancelar.Enabled = true;
        }

        public void AtivarCampos()
        {
            TxtBairro.Enabled = true;
        }

        public void DesativarBotoes()
        {
            BtnNovo.Enabled = true;
            BtnApagar.Enabled = true;
            BtnEditar.Enabled = true;  

            BtnSalvar.Enabled = false;
            BtnCancelar.Enabled = false;
        }

        public void DesativarCampos()
        {
            TxtBairro.Enabled = false;
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            AtivarBotoes();

            AtivarCampos();

            novo = true;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            M_Bairro m_Bairro = new M_Bairro();
            m_Bairro.nomebairro = TxtBairro.Text;

            C_Bairro c_Bairro = new C_Bairro();

            if(novo)
            {
                c_Bairro.Insere_Dados(m_Bairro);
            } else
            {
                m_Bairro.codbairro = Convert.ToInt32(TxtCodigo.Text);
                c_Bairro.Atualizar_Dados(m_Bairro);
            }


            CarregarTabelaTodos();

            DesativarBotoes();

            DesativarCampos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();

            DesativarBotoes();

            DesativarCampos();
            if (listaBairro.Count > 0)
            {
                AtualizarCampos();
                DataGridBairro.Rows[posicao].Selected = true;
            }
        }

        private void BtnApagar_Click(object sender, EventArgs e)
        {
            if(TxtCodigo.Text != "")
            {
                C_Bairro c_Bairro = new C_Bairro();
                c_Bairro.Apaga_Dados(Convert.ToInt32(TxtCodigo.Text));

                CarregarTabelaTodos();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            AtivarBotoes();
            AtivarCampos();

            novo = false;
        }

        private void BtnPrimeiro_Click(object sender, EventArgs e)
        {
            if(listaBairro.Count > 0)
            {
                DataGridBairro.Rows[posicao].Selected = false;
                posicao = 0;

                AtualizarCampos();

                DataGridBairro.Rows[posicao].Selected = true;
            }
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if(posicao > 0)
            {
                DataGridBairro.Rows[posicao].Selected = false;
                posicao--;

                AtualizarCampos();

                DataGridBairro.Rows[posicao].Selected = true;
            }
        }

        private void BtnProximo_Click(object sender, EventArgs e)
        {
            if(posicao < listaBairro.Count - 1)
            {
                DataGridBairro.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                DataGridBairro.Rows[posicao].Selected = true;
            }
        }

        private void BtnUltimo_Click(object sender, EventArgs e)
        {
            if(listaBairro.Count > 0)
            {
                DataGridBairro.Rows[posicao].Selected = false;
                posicao = listaBairro.Count - 1;

                AtualizarCampos();

                DataGridBairro.Rows[posicao].Selected = true;
            }
        }

        private void DataGridBairro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicao = e.RowIndex;
            if (posicao >= 0) { AtualizarCampos(); }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }
    }
}
