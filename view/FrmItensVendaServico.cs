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
    public partial class FrmItensVendaServico : Form
    {
        public FrmItensVendaServico(int id)
        {
            InitializeComponent();
            PreencherTabela(id);
        }

        private void PreencherTabela(int id)
        {
            C_ItensVendaServico c_ItensVendaServico = new C_ItensVendaServico();
            List<M_ItensVendaServico> listaVendasProdutos ;
            listaVendasProdutos = (List<M_ItensVendaServico>)c_ItensVendaServico.Buscar_Id(id);

            dGView.Rows.Clear();
            for (int i = 0; i < listaVendasProdutos.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaVendasProdutos[i].tiposervico.codtiposervico;
                row.Cells[1].Value = listaVendasProdutos[i].tiposervico.nometiposervico;
                row.Cells[2].Value = listaVendasProdutos[i].cidanimal.nomecidanimal;
                row.Cells[3].Value = listaVendasProdutos[i].quant;
                row.Cells[4].Value = listaVendasProdutos[i].valor;
                row.Cells[5].Value = listaVendasProdutos[i].valor * listaVendasProdutos[i].quant;

                dGView.Rows.Add(row);
            }
            AtualizarValorTotal();
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtualizarValorTotal()
        {
            float total = 0;

            foreach (DataGridViewRow row in dGView.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (float.TryParse(row.Cells["ValorTotal"].Value?.ToString(), out float valor))
                    {
                        total += valor;
                    }
                }
            }

            txtValorTotal.Text = total.ToString("F2");
        }
    }
}
