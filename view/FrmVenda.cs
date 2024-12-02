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
    public partial class FrmVenda : Form
    {
        public FrmVenda()
        {
            InitializeComponent();
            CarregarTabelaTodos();
            dGView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGView.MultiSelect = false;
        }

        private List<M_Venda> listaVenda = new List<M_Venda>();
        private int posicao = 0;

        private void CarregarTabelaTodos()
        {
            C_Venda c_Venda = new C_Venda();
            listaVenda = (List<M_Venda>)c_Venda.Buscar_Todos();

            CarregarDataGrid();
        }

        private void CarregarTabelaFiltro()
        {
            C_Venda c_Venda = new C_Venda();
            listaVenda = new List<M_Venda>();
            listaVenda = (List<M_Venda>)c_Venda.Buscar_Filtro(txtBuscar.Text.ToString());

            CarregarDataGrid();
        }

        private void CarregarDataGrid()
        {
            dGView.Rows.Clear();
            for (int i = 0; i < listaVenda.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaVenda[i].codvenda; 
                row.Cells[1].Value = listaVenda[i].cliente.nomecliente;
                row.Cells[2].Value = listaVenda[i].funcionario.nomefuncionario;
                row.Cells[3].Value = listaVenda[i].datavenda.ToShortDateString();
                row.Cells[4].Value = listaVenda[i].loja.nomeloja;
                
                dGView.Rows.Add(row);
            }

            if (listaVenda.Count > 0)
            {
                posicao = 0;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmFazerVenda frmFazerVenda = new FrmFazerVenda(0);
            frmFazerVenda.ShowDialog();
            CarregarTabelaTodos();
        }


        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dGView.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dGView.SelectedRows[0];
                int valorCelula = int.Parse(linhaSelecionada.Cells[0].Value.ToString());

                C_Venda c_Venda = new C_Venda();
                c_Venda.Apaga_Dados(valorCelula);
                CarregarTabelaTodos();
            }
            else
            {
                MessageBox.Show("Nenhuma Venda foi selecionada");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dGView.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dGView.SelectedRows[0];
                int valorCelula = int.Parse(linhaSelecionada.Cells[0].Value.ToString());

                FrmFazerVenda frmFazerVenda = new FrmFazerVenda(valorCelula);
                frmFazerVenda.ShowDialog();
                CarregarTabelaTodos();
            }
            else
            {
                MessageBox.Show("Nenhuma Venda foi selecionada");
            }
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            if (listaVenda.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = 0;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicao > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao--;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (listaVenda.Count - 1 > posicao)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listaVenda.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listaVenda.Count - 1;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }

        private void dGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                dGView.Rows[e.RowIndex].Selected = true;

                
            }
        }

        private void dGView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FrmVendasProdutos frmVendasProdutos = new FrmVendasProdutos(int.Parse(dGView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                frmVendasProdutos.ShowDialog();
                CarregarTabelaTodos();
            }
        }
    }
}
