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
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
            CarregarComboBox();
            CarregarTabelaTodos();
        }

        Boolean novo = false;
        int posicao;
        List<M_Produto> listProduto = new List<M_Produto>();

        public void LimparCampos()
        {
            TxtCodigo.Text = "";
            TxtProduto.Text = "";
            TxtQuantidade.Text = "";
            TxtValor.Text = "";
            TxtTipoProduto.SelectedItem = null;
            TxtMarca.SelectedItem = null;
        }

        public void CarregarComboBox()
        {
            CarregarMarca();
            CarregarTipoProduto();
        }

        public void CarregarMarca()
        {
            C_Marca c_Marca = new C_Marca();
            List<M_Marca> listMarca = new List<M_Marca>();
            listMarca = (List<M_Marca>)c_Marca.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomemarca", typeof(string));
            dataTable.Columns.Add("codmarca", typeof(int));

            foreach (M_Marca marca in listMarca)
            {
                dataTable.Rows.Add(marca.nomemarca, marca.codmarca);
            }

            TxtMarca.DataSource = dataTable;
            TxtMarca.DisplayMember = "nomemarca";
            TxtMarca.ValueMember = "codmarca";
        }

        public void CarregarTipoProduto()
        {
            C_TipoProduto c_TipoProduto = new C_TipoProduto();
            List<M_TipoProduto> listTipoProduto = new List<M_TipoProduto>();
            listTipoProduto = (List<M_TipoProduto>)c_TipoProduto.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nometipoproduto", typeof(string));
            dataTable.Columns.Add("codtipoproduto", typeof(int));

            foreach (M_TipoProduto tipoproduto in listTipoProduto)
            {
                dataTable.Rows.Add(tipoproduto.nometipoproduto, tipoproduto.codtipoproduto);
            }

            TxtTipoProduto.DataSource = dataTable;
            TxtTipoProduto.DisplayMember = "nometipoproduto";
            TxtTipoProduto.ValueMember = "codtipoproduto";
        }

        public void CarregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listProduto.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGView);
                row.Cells[0].Value = listProduto[i].codproduto;
                row.Cells[1].Value = listProduto[i].nomeproduto;
                row.Cells[2].Value = listProduto[i].tipoproduto.nometipoproduto;
                row.Cells[3].Value = listProduto[i].marca.nomemarca;
                row.Cells[4].Value = listProduto[i].valor;
                row.Cells[5].Value = listProduto[i].quantidade;

                dGView.Rows.Add(row);
            }

            if (listProduto.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }
        
        public void CarregarTabelaTodos()
        {
            C_Produto c_Produto = new C_Produto();
            listProduto = (List<M_Produto>)c_Produto.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Produto c_Produto = new C_Produto();
            listProduto = new List<M_Produto>();
            listProduto = (List<M_Produto>)c_Produto.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            TxtCodigo.Text = listProduto[posicao].codproduto.ToString();
            TxtProduto.Text = listProduto[posicao].nomeproduto;
            TxtQuantidade.Text = listProduto[posicao].quantidade.ToString();
            TxtValor.Text = listProduto[posicao].valor.ToString();
            TxtTipoProduto.SelectedValue = listProduto[posicao].marca.codmarca;
            TxtTipoProduto.SelectedValue = listProduto[posicao].tipoproduto.codtipoproduto;
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
            TxtCodigo.Enabled = true;
            TxtProduto.Enabled = true;
            TxtQuantidade.Enabled = true;
            TxtValor.Enabled = true;
            TxtMarca.Enabled = true;
            TxtTipoProduto.Enabled = true;
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
            TxtCodigo.Enabled = false;
            TxtProduto.Enabled = false;
            TxtQuantidade.Enabled = false;
            TxtValor.Enabled = false;
            TxtMarca.Enabled = false;
            TxtTipoProduto.Enabled = false;

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
            M_Produto m_Produto = new M_Produto();
            M_Marca m_Marca = new M_Marca();
            M_TipoProduto m_TipoProduto = new M_TipoProduto();

            m_Marca.codmarca = int.Parse(TxtMarca.SelectedValue.ToString());
            m_TipoProduto.codtipoproduto = int.Parse(TxtTipoProduto.SelectedValue.ToString());

            m_Produto.nomeproduto = TxtProduto.Text;
            m_Produto.quantidade = int.Parse(TxtQuantidade.Text);
            m_Produto.valor = double.Parse(TxtValor.Text);
            m_Produto.marca = m_Marca;
            m_Produto.tipoproduto = m_TipoProduto;

            C_Produto c_Produto = new C_Produto();

            if (novo)
            {
                c_Produto.Insere_Dados(m_Produto);
            }
            else
            {
                m_Produto.codproduto = Convert.ToInt32(TxtCodigo.Text);
                c_Produto.Atualizar_Dados(m_Produto);
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

            if (listProduto.Count > 0)
            {
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != "")
            {
                C_Produto c_Produto = new C_Produto();
                c_Produto.Apaga_Dados(Convert.ToInt32(TxtCodigo.Text));

                CarregarTabelaTodos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != "")
            {
                AtivarBotoes();
                AtivarCampos();

                novo = false;
            }
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            if (listProduto.Count > 0)
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
            if (posicao < listProduto.Count - 1)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listProduto.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listProduto.Count - 1;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }

        private void dGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicao = e.RowIndex;
            if (posicao >= 0) { AtualizarCampos(); }
        }
    }
}
