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
    public partial class FrmFuncionario : Form
    {
        public FrmFuncionario()
        {
            InitializeComponent();
            CarregarComboBox();
            CarregarTabelaTodos();
            
        }

        Boolean novo = true;
        int posicao;
        List<M_Funcionario> listFuncionario = new List<M_Funcionario>();

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtFuncionario.Text = "";

           
            cBoxTipoFuncionario.SelectedItem = null;
            cBoxLoja.SelectedItem = null;
        }

        public void CarregarComboBox()
        {
            CarregarLoja();
            CarregarTipoFuncionario();
            
        }

        public void CarregarLoja()
        {
            C_Loja c_Loja = new C_Loja();
            List<M_Loja> listLoja = new List<M_Loja>();
            listLoja = (List<M_Loja>)c_Loja.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomeloja", typeof(string));
            dataTable.Columns.Add("codloja", typeof(int));

            foreach (M_Loja loja in listLoja)
            {
                dataTable.Rows.Add(loja.nomeloja, loja.codloja);
            }

            cBoxLoja.DataSource = dataTable;
            cBoxLoja.DisplayMember = "nomeloja";
            cBoxLoja.ValueMember = "codloja";
        }

        public void CarregarTipoFuncionario()
        {
            C_TipoFuncionario c_TipoFuncionario = new C_TipoFuncionario();
            List<M_Tipofuncionario> listTipoFuncionario = new List<M_Tipofuncionario>();
            listTipoFuncionario = (List<M_Tipofuncionario>)c_TipoFuncionario.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nometipofuncionario", typeof(string));
            dataTable.Columns.Add("codtipofuncionario", typeof(int));

            foreach (M_Tipofuncionario tipofuncionario in listTipoFuncionario)
            {
                dataTable.Rows.Add(tipofuncionario.nometipofuncionario, tipofuncionario.codtipofuncionario);
            }

            cBoxTipoFuncionario.DataSource = dataTable;
            cBoxTipoFuncionario.DisplayMember = "nometipofuncionario";
            cBoxTipoFuncionario.ValueMember = "codtipofuncionario";
        }

        public void CarregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listFuncionario.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGView);
                row.Cells[0].Value = listFuncionario[i].codfuncionario;
                row.Cells[1].Value = listFuncionario[i].nomefuncionario;
                row.Cells[2].Value = listFuncionario[i].tipofuncionario.nometipofuncionario;
                row.Cells[3].Value = listFuncionario[i].loja.nomeloja;
                


                dGView.Rows.Add(row);
            }

            if (listFuncionario.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        public void CarregarTabelaTodos()
        {
            C_Funcionario c_Funcionario = new C_Funcionario();
            listFuncionario = (List<M_Funcionario>)c_Funcionario.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Funcionario c_Funcionario = new C_Funcionario();
            listFuncionario = new List<M_Funcionario>();
            listFuncionario = (List<M_Funcionario>)c_Funcionario.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listFuncionario[posicao].codfuncionario.ToString();
            txtFuncionario.Text = listFuncionario[posicao].nomefuncionario;
            cBoxLoja.SelectedValue = listFuncionario[posicao].loja.codloja;
            cBoxTipoFuncionario.SelectedValue = listFuncionario[posicao].tipofuncionario.codtipofuncionario;

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
            txtFuncionario.Enabled = true;
            cBoxTipoFuncionario.Enabled = true;
            cBoxLoja.Enabled = true;
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
            txtFuncionario.Enabled = false;
            cBoxTipoFuncionario.Enabled = false;
            cBoxLoja.Enabled = false;
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
            M_Loja m_Loja = new M_Loja();
            M_Tipofuncionario m_Tipofuncionario = new M_Tipofuncionario();
            M_Funcionario m_Funcionario = new M_Funcionario();

            m_Loja.codloja = int.Parse(cBoxLoja.SelectedValue.ToString());
            m_Tipofuncionario.codtipofuncionario = int.Parse(cBoxTipoFuncionario.SelectedValue.ToString());

            m_Funcionario.nomefuncionario = txtFuncionario.Text;
            m_Funcionario.loja = m_Loja;
            m_Funcionario.tipofuncionario = m_Tipofuncionario;
            

            C_Funcionario c_Funcionario = new C_Funcionario();

            if (novo)
            {
                c_Funcionario.Insere_Dados(m_Funcionario);
            }
            else
            {
                m_Funcionario.codfuncionario = Convert.ToInt32(txtCodigo.Text);
                c_Funcionario.Atualizar_Dados(m_Funcionario);
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

            if (listFuncionario.Count > 0)
            {
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_Funcionario c_Funcionario = new C_Funcionario();
                c_Funcionario.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if (listFuncionario.Count > 0)
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
            if (posicao < listFuncionario.Count - 1)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        { 
            if (listFuncionario.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listFuncionario.Count - 1;

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
