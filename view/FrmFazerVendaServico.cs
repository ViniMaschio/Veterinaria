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
    public partial class FrmFazerVendaServico : Form
    {
        public FrmFazerVendaServico(int id)
        {
            InitializeComponent();
            txtCodigo.Text = id.ToString();
            CarregarComboBox();
            this.idVenda = id;
            if (id > 0)
            {
                CarregarVendaServico();
            }
        }

        private readonly int idVenda;
        private C_VendaServico c_VendaServico = new C_VendaServico();

        private void CarregarVendaServico()
        {
            M_VendaServico vendaServico;

            vendaServico = (M_VendaServico)c_VendaServico.Buscar_Id(this.idVenda);

            cBoxAnimal.SelectedValue = vendaServico.animal.codanimal;
            cBoxCliente.SelectedValue = vendaServico.cliente.codcliente;
            cBoxFuncionario.SelectedValue = vendaServico.funcionario.codfuncionario;
            DataVenda.Value = vendaServico.datavenda;

            List<M_ItensVendaServico> listItensVendaServico;
            C_ItensVendaServico c_ItensVendaServico = new C_ItensVendaServico();
            listItensVendaServico = (List<M_ItensVendaServico>)c_ItensVendaServico.Buscar_Id(this.idVenda);

            foreach (M_ItensVendaServico itensVendaServico in listItensVendaServico)
            {
                int rowIndex = DataGridProdutosVenda.Rows.Add(
                    itensVendaServico.tiposervico.codtiposervico,
                    itensVendaServico.tiposervico.nometiposervico,
                    null,
                    itensVendaServico.quant,
                    itensVendaServico.valor,
                    itensVendaServico.quant * itensVendaServico.valor
                );

                var comboBoxCell = DataGridProdutosVenda.Rows[rowIndex].Cells[2] as DataGridViewComboBoxCell;

                if (comboBoxCell != null)
                {
                    
                    comboBoxCell.Value = itensVendaServico.cidanimal.codcidanimal;
                }
            }
            AtualizarValorTotal();
        }

        private void CarregarComboBox()
        {
            CarregarAnimal();
            CarregarCliente();
            CarregarFuncionario();
            CarregarServico();
        }

        private void CarregarAnimal()
        {
            C_Animal c_Animal = new C_Animal();
            List<M_Animal> animal;
            animal = (List<M_Animal>)c_Animal.Buscar_Todos();

            cBoxAnimal.DataSource = animal;
            cBoxAnimal.DisplayMember = "nomeanimal";
            cBoxAnimal.ValueMember = "codanimal";
        }

        private void CarregarCliente()
        {
            C_Cliente c_Cliente = new C_Cliente();
            List<M_Cliente> clientes;
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

        private void CarregarServico()
        {
            C_TipoServico c_TipoServico = new C_TipoServico();
            List<M_TipoServico> servico;
            servico = (List<M_TipoServico>)c_TipoServico.Buscar_Todos();

            cBoxServico.DataSource = servico;
            cBoxServico.DisplayMember = "nometiposervico";
            cBoxServico.ValueMember = "codtiposervico";
        }

        private void DataGridProdutosVenda_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colunaEditavel = 3;
            if (e.ColumnIndex == colunaEditavel)
            {
                DataGridViewRow linha = DataGridProdutosVenda.Rows[e.RowIndex];

                double valorEditado = double.Parse(linha.Cells[e.ColumnIndex].Value.ToString());
                double valorUnitario = double.Parse(linha.Cells[4].Value.ToString());
                valorEditado = double.Parse(valorEditado.ToString("F2"));
                linha.Cells[e.ColumnIndex].Value = valorEditado;

                int colunaDestino = 5;
                linha.Cells[colunaDestino].Value = (valorEditado * valorUnitario).ToString("F2");
            }
        }

        private void BntAdicionarServico_Click(object sender, EventArgs e)
        {
            int codServico = (int)cBoxServico.SelectedValue;
            if (codServico > 0)
            {
                M_TipoServico servico;
                C_TipoServico C_TipoServico = new C_TipoServico();
                servico = (M_TipoServico)C_TipoServico.Buscar_Id(codServico);

                bool ServicoExiste = false;
                foreach (DataGridViewRow row in DataGridProdutosVenda.Rows)
                {
                    if ((int)row.Cells[0].Value == codServico)
                    {
                        double quantidadeAtual = Convert.ToDouble(row.Cells[3].Value);
                        quantidadeAtual++;
                        row.Cells[3].Value = quantidadeAtual;

                        double valorUnitario = Convert.ToDouble(row.Cells[4].Value);
                        row.Cells[5].Value = (quantidadeAtual * valorUnitario).ToString("F2");

                        ServicoExiste = true;
                        break;
                    }
                }


                if (!ServicoExiste)
                {
                    DataGridProdutosVenda.Rows.Add(
                        servico.codtiposervico,
                        servico.nometiposervico,
                        null,
                        1,
                        servico.valortiposervico.ToString("F2"),
                        servico.valortiposervico.ToString("F2")
                    );
                }
                AtualizarValorTotal();
            }
        }

        private void DataGridProdutosVenda_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void DataGridProdutosVenda_Click(object sender, EventArgs e)
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

        private void CarregarCidAnimal()
        {
            
            if (DataGridProdutosVenda.Columns["cidanimal"] != null)
            {
                
                DataGridViewComboBoxColumn comboBoxColumn = DataGridProdutosVenda.Columns["cidanimal"] as DataGridViewComboBoxColumn;

                
                if (comboBoxColumn != null)
                {
                    C_CidAnimal c_CidAnimal = new C_CidAnimal();
                    List<M_CidAnimal> cidAnimal = (List<M_CidAnimal>)c_CidAnimal.Buscar_Todos();

                    
                    comboBoxColumn.DataSource = cidAnimal;
                    comboBoxColumn.ValueMember = "codcidanimal";
                    comboBoxColumn.DisplayMember = "nomecidanimal";
                }
            }
        }

        private void FrmFazerVendaServico_Load(object sender, EventArgs e) 
        {
            CarregarCidAnimal();
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
                MessageBox.Show("Venda Precisa de Servico!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                M_VendaServico venda = new M_VendaServico
                {
                    animal = new M_Animal 
                    { 
                        codanimal = (int)cBoxAnimal.SelectedValue
                    },
                    cliente = new M_Cliente
                    {
                        codcliente = (int)cBoxCliente.SelectedValue
                    },
                    funcionario = new M_Funcionario
                    {
                        codfuncionario = (int)cBoxFuncionario.SelectedValue
                    },
                    codvendaservico = this.idVenda,
                    datavenda = DataVenda.Value

                };
                List<M_ItensVendaServico> listItensServico = PreencherListaItensVendaServico();
                if (listItensServico == null)
                {
                    return;
                }
                if (this.idVenda > 0)
                {

                    c_VendaServico.Atualizar_Dados(venda, listItensServico);
                    this.Close();
                }
                else
                {
                    c_VendaServico.Insere_Dados(venda, listItensServico);
                    this.Close();
                }


            }

        }

        private List<M_ItensVendaServico> PreencherListaItensVendaServico()
        {
            List<M_ItensVendaServico> listItensVendaServico = new List<M_ItensVendaServico>();

            foreach (DataGridViewRow row in DataGridProdutosVenda.Rows)
            {
                var valor = row.Cells[2].Value;
                if (valor == null)
                {
                    MessageBox.Show("Selecione um CID para o animal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                M_ItensVendaServico itensVendaServico = new M_ItensVendaServico
                {
                    tiposervico = new M_TipoServico
                    {
                        codtiposervico = (int)row.Cells[0].Value
                    },
                    
                    quant = Convert.ToDouble(row.Cells[3].Value),
                    valor = Convert.ToDouble(row.Cells[4].Value),
                    vendaservico = new M_VendaServico
                    {
                        codvendaservico = Convert.ToInt32(txtCodigo.Text)
                    },
                    cidanimal = new M_CidAnimal
                    {
                        codcidanimal = (int)valor
                    }
                };

                listItensVendaServico.Add(itensVendaServico);
            }

            return listItensVendaServico;
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
