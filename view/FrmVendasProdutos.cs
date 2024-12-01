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
    public partial class FrmVendasProdutos : Form
    {
        public FrmVendasProdutos(int id)
        {
            InitializeComponent();
            PreencherTabela(id);
        }

        private void PreencherTabela(int id)
        {
            C_VendasProdutos c_VendasProdutos = new C_VendasProdutos();
            List<M_VendasProdutos> listaVendasProdutos = new List<M_VendasProdutos>();
            listaVendasProdutos = (List<M_VendasProdutos>)c_VendasProdutos.Buscar_Id(id);

            dGView.Rows.Clear();
            for (int i = 0; i < listaVendasProdutos.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaVendasProdutos[i].produto.codproduto;
                row.Cells[1].Value = listaVendasProdutos[i].produto.nomeproduto;
                row.Cells[2].Value = listaVendasProdutos[i].quantv;
                row.Cells[3].Value = listaVendasProdutos[i].valorv;
                row.Cells[4].Value = listaVendasProdutos[i].valorv * listaVendasProdutos[i].quantv;

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
