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
    public partial class FrmVendaServico : Form
    {
        public FrmVendaServico()
        {
            InitializeComponent();
            
            CarregarTabelaTodos();
            dGView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGView.MultiSelect = false;
        }

        private List<M_VendaServico> listaVendaServico = new List<M_VendaServico>();
        private int posicao = 0;

        private void CarregarTabelaTodos()
        {
            C_VendaServico c_VendaServico = new C_VendaServico();
            listaVendaServico = (List<M_VendaServico>)c_VendaServico.Buscar_Todos();
            
            CarregarDataGrid();
        }

        private void CarregarTabelaFiltro()
        {
            C_VendaServico c_VendaServico = new C_VendaServico();
            listaVendaServico = new List<M_VendaServico>();
            listaVendaServico = (List<M_VendaServico>)c_VendaServico.Buscar_Filtro(txtBuscar.Text.ToString());

            CarregarDataGrid();
        }

        private void CarregarDataGrid()
        {
            dGView.Rows.Clear();
            for (int i = 0; i < listaVendaServico.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaVendaServico[i].codvendaservico;
                row.Cells[1].Value = listaVendaServico[i].cliente.nomecliente;
                row.Cells[2].Value = listaVendaServico[i].animal.nomeanimal;
                row.Cells[3].Value = listaVendaServico[i].funcionario.nomefuncionario;
                row.Cells[4].Value = listaVendaServico[i].datavenda.ToShortDateString();
                

                dGView.Rows.Add(row);
            }
            

            if (listaVendaServico.Count > 0)
            {
                posicao = 0;
                dGView.Rows[posicao].Selected = true;
            }
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
                FrmItensVendaServico frmItensVendaServico = new FrmItensVendaServico(int.Parse(dGView.Rows[e.RowIndex].Cells[0].Value.ToString()));
                frmItensVendaServico.ShowDialog();
                CarregarTabelaTodos();
            }
        } 

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            FrmFazerVendaServico frmFazerVendaServico = new FrmFazerVendaServico(0);
            frmFazerVendaServico.ShowDialog();
            CarregarTabelaTodos();
        }

        private void btnApagar_Click_1(object sender, EventArgs e)
        {
            if (dGView.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dGView.SelectedRows[0];
                int valorCelula = int.Parse(linhaSelecionada.Cells[0].Value.ToString());

                C_VendaServico c_VendaServico = new C_VendaServico();
                c_VendaServico.Apaga_Dados(valorCelula);
                CarregarTabelaTodos();
            }
            else
            {
                MessageBox.Show("Nenhuma Venda foi selecionada");
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dGView.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dGView.SelectedRows[0];
                int valorCelula = int.Parse(linhaSelecionada.Cells[0].Value.ToString());

                FrmFazerVendaServico frmFazerVendaServico = new FrmFazerVendaServico(valorCelula);
                frmFazerVendaServico.ShowDialog();
                CarregarTabelaTodos();
            }
            else
            {
                MessageBox.Show("Nenhuma Venda foi selecionada");
            }
        }

        private void btnPrimeiro_Click_1(object sender, EventArgs e)
        {
            if (listaVendaServico.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = 0;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (posicao > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao--;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click_1(object sender, EventArgs e)
        {
            if (listaVendaServico.Count - 1 > posicao)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click_1(object sender, EventArgs e)
        {
            if (listaVendaServico.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listaVendaServico.Count - 1;
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }
    }
}
