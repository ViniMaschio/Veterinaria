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
    public partial class FrmFazerVenda : Form
    {
        public FrmFazerVenda(int id)
        {
            InitializeComponent();

            txtCodigo.Text = id.ToString();
            CarregarComboBox();
            this.idVenda = id;
            if (id > 0)
            {
                CarregarVenda();
            }
        }

        private readonly int idVenda ;
        private C_Venda c_Venda = new C_Venda();

        private void CarregarVenda()
        {
            M_Venda venda;

            venda = (M_Venda)c_Venda.Buscar_Id(this.idVenda);

            cBoxLoja.SelectedValue = venda.loja.codloja;
            cBoxCliente.SelectedValue = venda.cliente.codcliente;
            cBoxFuncionario.SelectedValue = venda.funcionario.codfuncionario;
            DataVenda.Value = venda.datavenda;

            List<M_VendasProdutos> vendasProdutos;
            C_VendasProdutos c_VendasProdutos = new C_VendasProdutos();
            vendasProdutos = (List<M_VendasProdutos>)c_VendasProdutos.Buscar_Id(this.idVenda);

            foreach (M_VendasProdutos vendasProduto in vendasProdutos)
            {
                DataGridProdutosVenda.Rows.Add(
                    vendasProduto.produto.codproduto,
                    vendasProduto.produto.nomeproduto,
                    vendasProduto.quantv,
                    vendasProduto.valorv,
                    vendasProduto.quantv * vendasProduto.valorv
                );
            }
            AtualizarValorTotal();
        }

        private void CarregarComboBox() {
            CarregarLoja();
            CarregarCliente();
            CarregarFuncionario();
            CarregarProduto();
        }

        private void CarregarLoja()
        {
            C_Loja c_Loja = new C_Loja();
            List<M_Loja> lojas; ;
            lojas = (List<M_Loja>)c_Loja.Buscar_Todos();

            cBoxLoja.DataSource = lojas;
            cBoxLoja.DisplayMember = "nomeloja";
            cBoxLoja.ValueMember = "codloja";
        }

        private void CarregarCliente()
        {
            C_Cliente c_Cliente = new C_Cliente();
            List<M_Cliente> clientes ;
            clientes = (List<M_Cliente>)c_Cliente.Buscar_Todos();

            cBoxCliente.DataSource = clientes;
            cBoxCliente.DisplayMember = "nomecliente";
            cBoxCliente.ValueMember = "codcliente";
        }

        private void CarregarFuncionario()
        {
            C_Funcionario c_Funcionario = new C_Funcionario();
            List<M_Funcionario> funcionarios;
            funcionarios = (List<M_Funcionario>)c_Funcionario.Buscar_Todos();

            cBoxFuncionario.DataSource = funcionarios;
            cBoxFuncionario.DisplayMember = "nomefuncionario";
            cBoxFuncionario.ValueMember = "codfuncionario";
        }

        private void CarregarProduto()
        {
            C_Produto c_Produto = new C_Produto();
            List<M_Produto> produtos ;
            produtos = (List<M_Produto>)c_Produto.Buscar_Todos();

            cBoxProduto.DataSource = produtos;
            cBoxProduto.DisplayMember = "nomeproduto";
            cBoxProduto.ValueMember = "codproduto";
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            int colunaEditavel = 2; 
            if (e.ColumnIndex == colunaEditavel)
            {
                DataGridViewRow linha = DataGridProdutosVenda.Rows[e.RowIndex];

                double valorEditado = double.Parse( linha.Cells[e.ColumnIndex].Value.ToString());
                double valorUnitario = double.Parse(linha.Cells[3].Value.ToString());
                valorEditado = double.Parse(valorEditado.ToString("F2"));
                linha.Cells[e.ColumnIndex].Value = valorEditado;
                
                int colunaDestino = 4;
                linha.Cells[colunaDestino].Value = (valorEditado * valorUnitario).ToString("F2");
            }
        }

        private void BntAdicionarProduto_Click_1(object sender, EventArgs e)
        {
            int codproduto = (int)cBoxProduto.SelectedValue;
            if (codproduto > 0)
            {
                M_Produto produto;
                C_Produto c_Produto = new C_Produto();
                produto = (M_Produto)c_Produto.Buscar_Id(codproduto);

                bool produtoExiste = false;
                foreach (DataGridViewRow row in DataGridProdutosVenda.Rows)
                {
                    if ((int)row.Cells[0].Value == codproduto)
                    {
                        double quantidadeAtual = Convert.ToDouble(row.Cells[2].Value);
                        quantidadeAtual++;
                        row.Cells[2].Value = quantidadeAtual;

                        double valorUnitario = Convert.ToDouble(row.Cells[3].Value);
                        row.Cells[4].Value = (quantidadeAtual * valorUnitario).ToString("F2");

                        produtoExiste = true;
                        break;
                    }
                }

                
                if (!produtoExiste)
                {
                    DataGridProdutosVenda.Rows.Add(
                        produto.codproduto,
                        produto.nomeproduto,
                        1, 
                        produto.valor.ToString("F2"), 
                        produto.valor.ToString("F2")  
                    );
                }
                AtualizarValorTotal();
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox textBox)
            {
                textBox.KeyPress -= ApenasNumeros_KeyPress;
                textBox.KeyPress += ApenasNumeros_KeyPress;
            }
        }

        private void ApenasNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; 
                return;
            }

            if (e.KeyChar == '.')
            {
                if (sender is TextBox textBox && textBox.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (DataGridProdutosVenda.IsCurrentCellInEditMode)
            {
                DataGridProdutosVenda.EndEdit();
            }
        }

        private void AdicionarBotaoExcluir()
        {
            DataGridViewButtonColumn btnExcluir = new DataGridViewButtonColumn
            {
                HeaderText = "Apagar",
                Text = "Excluir",
                Name = "btnExcluir",
                UseColumnTextForButtonValue = true 
            };

            DataGridProdutosVenda.Columns.Add(btnExcluir);
        }

        private void DataGridProdutosVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataGridProdutosVenda.Rows.Count &&
      e.ColumnIndex >= 0 && e.ColumnIndex < DataGridProdutosVenda.Columns.Count)
            {
                if (DataGridProdutosVenda.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DialogResult resultado = MessageBox.Show(
                        "Deseja Remover este item?",
                        "Confirmação",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        
                        DataGridProdutosVenda.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
          
        }

        private void FrmFazerVenda_Load(object sender, EventArgs e)
        {
            AdicionarBotaoExcluir();
        }
        private void AtualizarValorTotal()
        {
            float total = 0;

            foreach (DataGridViewRow row in DataGridProdutosVenda.Rows)
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

        private void DataGridProdutosVenda_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarValorTotal();
        }

        private void bntSalvar_Click(object sender, EventArgs e)
        {
            if (DataGridProdutosVenda.Rows.Count == 0 ||
        (DataGridProdutosVenda.Rows.Count == 1 && DataGridProdutosVenda.Rows[0].IsNewRow))
            {
                MessageBox.Show("Venda Precisa de itens!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                
                M_Venda venda = new M_Venda
                {
                    loja = new M_Loja
                    {
                        codloja = (int)cBoxLoja.SelectedValue
                    },
                    cliente = new M_Cliente
                    {
                        codcliente = (int)cBoxCliente.SelectedValue
                    },
                    funcionario = new M_Funcionario
                    {
                        codfuncionario = (int)cBoxFuncionario.SelectedValue
                    },
                    codvenda = this.idVenda,
                    datavenda = DataVenda.Value

                };
                List<M_VendasProdutos> listVendasProdutos = PreencherListaVendasProdutos();
                if( this.idVenda> 0)
                {
                    
                    c_Venda.Atualizar_Dados(venda, listVendasProdutos);
                    this.Close();
                }
                else
                {
                    c_Venda.Insere_Dados(venda, listVendasProdutos);
                    this.Close();
                }
                

            }


        }

        private List<M_VendasProdutos> PreencherListaVendasProdutos()
        {
            List<M_VendasProdutos> listVendasProdutos = new List<M_VendasProdutos>();

            foreach (DataGridViewRow row in DataGridProdutosVenda.Rows)
            {

                //if (row.IsNewRow)
                //    continue;

                M_VendasProdutos vendasProdutos = new M_VendasProdutos
                {
                    produto = new M_Produto
                    {
                        codproduto = (int)row.Cells[0].Value
                    },
                    quantv = Convert.ToDouble(row.Cells[2].Value),
                    valorv = Convert.ToDouble(row.Cells[3].Value),
                    venda = new M_Venda
                    {
                        codvenda = Convert.ToInt32(txtCodigo.Text)
                    }

                };

                listVendasProdutos.Add(vendasProdutos);
            }

            return listVendasProdutos;
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
