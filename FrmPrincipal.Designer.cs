namespace Veterinaria
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.animalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.racaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoAnimalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cidAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.endereçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bairroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cEPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefoneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoFuncionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.servicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoServicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lojaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lojaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendaServicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animalToolStripMenuItem,
            this.endereçoToolStripMenuItem,
            this.telefoneToolStripMenuItem,
            this.funcionarioToolStripMenuItem,
            this.produtoToolStripMenuItem,
            this.servicoToolStripMenuItem,
            this.lojaToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.vendaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // animalToolStripMenuItem
            // 
            this.animalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.racaToolStripMenuItem1,
            this.tipoAnimalToolStripMenuItem1,
            this.cidAnimalToolStripMenuItem,
            this.animalToolStripMenuItem1});
            this.animalToolStripMenuItem.Name = "animalToolStripMenuItem";
            this.animalToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.animalToolStripMenuItem.Text = "Animal";
            // 
            // racaToolStripMenuItem1
            // 
            this.racaToolStripMenuItem1.Name = "racaToolStripMenuItem1";
            this.racaToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.racaToolStripMenuItem1.Text = "Raca";
            this.racaToolStripMenuItem1.Click += new System.EventHandler(this.racaToolStripMenuItem1_Click);
            // 
            // tipoAnimalToolStripMenuItem1
            // 
            this.tipoAnimalToolStripMenuItem1.Name = "tipoAnimalToolStripMenuItem1";
            this.tipoAnimalToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.tipoAnimalToolStripMenuItem1.Text = "Tipo Animal";
            this.tipoAnimalToolStripMenuItem1.Click += new System.EventHandler(this.tipoAnimalToolStripMenuItem1_Click);
            // 
            // cidAnimalToolStripMenuItem
            // 
            this.cidAnimalToolStripMenuItem.Name = "cidAnimalToolStripMenuItem";
            this.cidAnimalToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.cidAnimalToolStripMenuItem.Text = "Cid Animal";
            this.cidAnimalToolStripMenuItem.Click += new System.EventHandler(this.cidAnimalToolStripMenuItem_Click);
            // 
            // animalToolStripMenuItem1
            // 
            this.animalToolStripMenuItem1.Name = "animalToolStripMenuItem1";
            this.animalToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.animalToolStripMenuItem1.Text = "Animal";
            this.animalToolStripMenuItem1.Click += new System.EventHandler(this.animalToolStripMenuItem1_Click);
            // 
            // endereçoToolStripMenuItem
            // 
            this.endereçoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ruaToolStripMenuItem,
            this.bairroToolStripMenuItem,
            this.cEPToolStripMenuItem,
            this.paisToolStripMenuItem});
            this.endereçoToolStripMenuItem.Name = "endereçoToolStripMenuItem";
            this.endereçoToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.endereçoToolStripMenuItem.Text = "Endereço";
            // 
            // ruaToolStripMenuItem
            // 
            this.ruaToolStripMenuItem.Name = "ruaToolStripMenuItem";
            this.ruaToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.ruaToolStripMenuItem.Text = "Rua";
            this.ruaToolStripMenuItem.Click += new System.EventHandler(this.ruaToolStripMenuItem_Click);
            // 
            // bairroToolStripMenuItem
            // 
            this.bairroToolStripMenuItem.Name = "bairroToolStripMenuItem";
            this.bairroToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.bairroToolStripMenuItem.Text = "Bairro";
            this.bairroToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bairroToolStripMenuItem.Click += new System.EventHandler(this.bairroToolStripMenuItem_Click);
            // 
            // cEPToolStripMenuItem
            // 
            this.cEPToolStripMenuItem.Name = "cEPToolStripMenuItem";
            this.cEPToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.cEPToolStripMenuItem.Text = "CEP";
            this.cEPToolStripMenuItem.Click += new System.EventHandler(this.cEPToolStripMenuItem_Click);
            // 
            // paisToolStripMenuItem
            // 
            this.paisToolStripMenuItem.Name = "paisToolStripMenuItem";
            this.paisToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.paisToolStripMenuItem.Text = "Pais";
            this.paisToolStripMenuItem.Click += new System.EventHandler(this.paisToolStripMenuItem_Click);
            // 
            // telefoneToolStripMenuItem
            // 
            this.telefoneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.telefoneToolStripMenuItem1});
            this.telefoneToolStripMenuItem.Name = "telefoneToolStripMenuItem";
            this.telefoneToolStripMenuItem.Size = new System.Drawing.Size(75, 21);
            this.telefoneToolStripMenuItem.Text = "Telefones";
            // 
            // telefoneToolStripMenuItem1
            // 
            this.telefoneToolStripMenuItem1.Name = "telefoneToolStripMenuItem1";
            this.telefoneToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.telefoneToolStripMenuItem1.Text = "Telefone";
            this.telefoneToolStripMenuItem1.Click += new System.EventHandler(this.telefoneToolStripMenuItem1_Click);
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoFuncionarioToolStripMenuItem,
            this.funcionarioToolStripMenuItem1});
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(87, 21);
            this.funcionarioToolStripMenuItem.Text = "Funcionario";
            // 
            // tipoFuncionarioToolStripMenuItem
            // 
            this.tipoFuncionarioToolStripMenuItem.Name = "tipoFuncionarioToolStripMenuItem";
            this.tipoFuncionarioToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.tipoFuncionarioToolStripMenuItem.Text = "Tipo Funcionario";
            this.tipoFuncionarioToolStripMenuItem.Click += new System.EventHandler(this.tipoFuncionarioToolStripMenuItem_Click);
            // 
            // funcionarioToolStripMenuItem1
            // 
            this.funcionarioToolStripMenuItem1.Name = "funcionarioToolStripMenuItem1";
            this.funcionarioToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.funcionarioToolStripMenuItem1.Text = "Funcionario";
            this.funcionarioToolStripMenuItem1.Click += new System.EventHandler(this.funcionarioToolStripMenuItem1_Click);
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcaToolStripMenuItem,
            this.tipoProdutoToolStripMenuItem,
            this.produtoToolStripMenuItem1});
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.produtoToolStripMenuItem.Text = "Produto";
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // tipoProdutoToolStripMenuItem
            // 
            this.tipoProdutoToolStripMenuItem.Name = "tipoProdutoToolStripMenuItem";
            this.tipoProdutoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tipoProdutoToolStripMenuItem.Text = "Tipo Produto";
            this.tipoProdutoToolStripMenuItem.Click += new System.EventHandler(this.tipoProdutoToolStripMenuItem_Click);
            // 
            // produtoToolStripMenuItem1
            // 
            this.produtoToolStripMenuItem1.Name = "produtoToolStripMenuItem1";
            this.produtoToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.produtoToolStripMenuItem1.Text = "Produto";
            this.produtoToolStripMenuItem1.Click += new System.EventHandler(this.produtoToolStripMenuItem1_Click);
            // 
            // servicoToolStripMenuItem
            // 
            this.servicoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoServicoToolStripMenuItem});
            this.servicoToolStripMenuItem.Name = "servicoToolStripMenuItem";
            this.servicoToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.servicoToolStripMenuItem.Text = "Servico";
            // 
            // tipoServicoToolStripMenuItem
            // 
            this.tipoServicoToolStripMenuItem.Name = "tipoServicoToolStripMenuItem";
            this.tipoServicoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.tipoServicoToolStripMenuItem.Text = "Tipo Servico";
            this.tipoServicoToolStripMenuItem.Click += new System.EventHandler(this.tipoServicoToolStripMenuItem_Click);
            // 
            // lojaToolStripMenuItem
            // 
            this.lojaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lojaToolStripMenuItem1});
            this.lojaToolStripMenuItem.Name = "lojaToolStripMenuItem";
            this.lojaToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.lojaToolStripMenuItem.Text = "Loja";
            // 
            // lojaToolStripMenuItem1
            // 
            this.lojaToolStripMenuItem1.Name = "lojaToolStripMenuItem1";
            this.lojaToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.lojaToolStripMenuItem1.Text = "Loja";
            this.lojaToolStripMenuItem1.Click += new System.EventHandler(this.lojaToolStripMenuItem1_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem1});
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // clienteToolStripMenuItem1
            // 
            this.clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            this.clienteToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.clienteToolStripMenuItem1.Text = "Cliente";
            this.clienteToolStripMenuItem1.Click += new System.EventHandler(this.clienteToolStripMenuItem1_Click);
            // 
            // vendaToolStripMenuItem
            // 
            this.vendaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vendaProdutoToolStripMenuItem,
            this.vendaServicoToolStripMenuItem});
            this.vendaToolStripMenuItem.Name = "vendaToolStripMenuItem";
            this.vendaToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.vendaToolStripMenuItem.Text = "Venda";
            // 
            // vendaProdutoToolStripMenuItem
            // 
            this.vendaProdutoToolStripMenuItem.Name = "vendaProdutoToolStripMenuItem";
            this.vendaProdutoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vendaProdutoToolStripMenuItem.Text = "Venda Produto";
            this.vendaProdutoToolStripMenuItem.Click += new System.EventHandler(this.vendaProdutoToolStripMenuItem_Click);
            // 
            // vendaServicoToolStripMenuItem
            // 
            this.vendaServicoToolStripMenuItem.Name = "vendaServicoToolStripMenuItem";
            this.vendaServicoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vendaServicoToolStripMenuItem.Text = "Venda Servico";
            this.vendaServicoToolStripMenuItem.Click += new System.EventHandler(this.vendaServicoToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem animalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tipoAnimalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem endereçoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bairroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telefoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telefoneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoFuncionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cEPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoServicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lojaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lojaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem animalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaServicoToolStripMenuItem;
    }
}

