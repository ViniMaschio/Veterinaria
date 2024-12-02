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
using Veterinaria.view;

namespace Veterinaria
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void racaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRaca frmRaca = new FrmRaca();    
            frmRaca.ShowDialog();
        }

        private void tipoAnimalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmTipoAnimal frmTipoAnimal = new FrmTipoAnimal();
            frmTipoAnimal.ShowDialog();
        }

        private void bairroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBairro frmBairro = new FrmBairro();
            frmBairro.ShowDialog();
        }

        private void ruaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRua frmRua = new FrmRua();
            frmRua.ShowDialog();
        }

        private void paisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPais frmPais = new FrmPais();
            frmPais.ShowDialog();
        }

        private void telefoneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmTelefone frmTelefone = new FrmTelefone();
            frmTelefone.ShowDialog();
        }

        private void tipoFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoFuncionario frmTipoFuncionario = new FrmTipoFuncionario();
            frmTipoFuncionario.ShowDialog();
        }

        private void cEPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCep frmCep = new FrmCep();
            frmCep.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarca frmMarca = new FrmMarca();
            frmMarca.ShowDialog();
        }

        private void tipoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoProduto frmTipoProduto = new FrmTipoProduto();
            frmTipoProduto.ShowDialog();
        }

        private void tipoServicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoServico frmTipoServico = new FrmTipoServico();
            frmTipoServico.ShowDialog();
        }

        private void cidAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidAnimal frmCidAnimal = new FrmCidAnimal();
            frmCidAnimal.ShowDialog();
        }

        private void lojaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmLoja frmLoja = new FrmLoja();
            frmLoja.ShowDialog();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente();
            frmCliente.ShowDialog();
        }

        private void animalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAnimal frmAnimal = new FrmAnimal();
            frmAnimal.ShowDialog();
        }

        private void funcionarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmFuncionario frmFuncionario = new FrmFuncionario();
            frmFuncionario.ShowDialog();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto();
            frmProduto.ShowDialog();
        }

        private void vendaProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenda FrmVenda = new FrmVenda();
            FrmVenda.ShowDialog();
        }

        private void vendaServicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendaServico frmVendaServico = new FrmVendaServico();
            frmVendaServico.ShowDialog();
        }
    }
}
