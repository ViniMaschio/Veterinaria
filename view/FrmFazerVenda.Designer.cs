namespace Veterinaria.view
{
    partial class FrmFazerVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cBoxCliente = new System.Windows.Forms.ComboBox();
            this.cBoxLoja = new System.Windows.Forms.ComboBox();
            this.cBoxFuncionario = new System.Windows.Forms.ComboBox();
            this.DataVenda = new System.Windows.Forms.DateTimePicker();
            this.dataGridProdutosVenda = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cBoxProduto = new System.Windows.Forms.ComboBox();
            this.BntAdicionarProduto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bntCancelar = new System.Windows.Forms.Button();
            this.bntSalvar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProdutosVenda)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(520, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendas Produtos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(746, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data Venda:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Funcionario:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(495, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Itens Venda";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(61, 24);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(30, 20);
            this.txtCodigo.TabIndex = 7;
            // 
            // cBoxCliente
            // 
            this.cBoxCliente.FormattingEnabled = true;
            this.cBoxCliente.Location = new System.Drawing.Point(182, 20);
            this.cBoxCliente.Name = "cBoxCliente";
            this.cBoxCliente.Size = new System.Drawing.Size(408, 21);
            this.cBoxCliente.TabIndex = 8;
            // 
            // cBoxLoja
            // 
            this.cBoxLoja.FormattingEnabled = true;
            this.cBoxLoja.Location = new System.Drawing.Point(537, 102);
            this.cBoxLoja.Name = "cBoxLoja";
            this.cBoxLoja.Size = new System.Drawing.Size(393, 21);
            this.cBoxLoja.TabIndex = 9;
            // 
            // cBoxFuncionario
            // 
            this.cBoxFuncionario.FormattingEnabled = true;
            this.cBoxFuncionario.Location = new System.Drawing.Point(83, 107);
            this.cBoxFuncionario.Name = "cBoxFuncionario";
            this.cBoxFuncionario.Size = new System.Drawing.Size(345, 21);
            this.cBoxFuncionario.TabIndex = 10;
            // 
            // DataVenda
            // 
            this.DataVenda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataVenda.Location = new System.Drawing.Point(819, 21);
            this.DataVenda.Name = "DataVenda";
            this.DataVenda.Size = new System.Drawing.Size(111, 20);
            this.DataVenda.TabIndex = 11;
            // 
            // dataGridProdutosVenda
            // 
            this.dataGridProdutosVenda.AllowUserToAddRows = false;
            this.dataGridProdutosVenda.AllowUserToDeleteRows = false;
            this.dataGridProdutosVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProdutosVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NomeProduto,
            this.Quantidade,
            this.ValorUnitario,
            this.ValorTotal});
            this.dataGridProdutosVenda.Location = new System.Drawing.Point(12, 294);
            this.dataGridProdutosVenda.Name = "dataGridProdutosVenda";
            this.dataGridProdutosVenda.Size = new System.Drawing.Size(853, 254);
            this.dataGridProdutosVenda.TabIndex = 12;
            this.dataGridProdutosVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProdutosVenda_CellClick);
            this.dataGridProdutosVenda.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridProdutosVenda.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProdutosVenda_CellValueChanged);
            this.dataGridProdutosVenda.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            this.dataGridProdutosVenda.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // ID
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle5;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // NomeProduto
            // 
            this.NomeProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeProduto.HeaderText = "Produto";
            this.NomeProduto.Name = "NomeProduto";
            this.NomeProduto.ReadOnly = true;
            // 
            // Quantidade
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Quantidade.DefaultCellStyle = dataGridViewCellStyle6;
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            // 
            // ValorUnitario
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ValorUnitario.DefaultCellStyle = dataGridViewCellStyle7;
            this.ValorUnitario.HeaderText = "Valor Unit.";
            this.ValorUnitario.Name = "ValorUnitario";
            // 
            // ValorTotal
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ValorTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Produto:";
            // 
            // cBoxProduto
            // 
            this.cBoxProduto.FormattingEnabled = true;
            this.cBoxProduto.Location = new System.Drawing.Point(63, 24);
            this.cBoxProduto.Name = "cBoxProduto";
            this.cBoxProduto.Size = new System.Drawing.Size(254, 21);
            this.cBoxProduto.TabIndex = 14;
            // 
            // BntAdicionarProduto
            // 
            this.BntAdicionarProduto.Location = new System.Drawing.Point(93, 72);
            this.BntAdicionarProduto.Name = "BntAdicionarProduto";
            this.BntAdicionarProduto.Size = new System.Drawing.Size(122, 36);
            this.BntAdicionarProduto.TabIndex = 15;
            this.BntAdicionarProduto.Text = "Adicionar Produto";
            this.BntAdicionarProduto.UseVisualStyleBackColor = true;
            this.BntAdicionarProduto.Click += new System.EventHandler(this.BntAdicionarProduto_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cBoxCliente);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.DataVenda);
            this.panel1.Controls.Add(this.cBoxFuncionario);
            this.panel1.Controls.Add(this.cBoxLoja);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(107, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 174);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cBoxProduto);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.BntAdicionarProduto);
            this.panel2.Location = new System.Drawing.Point(871, 294);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 204);
            this.panel2.TabIndex = 17;
            // 
            // bntCancelar
            // 
            this.bntCancelar.Location = new System.Drawing.Point(516, 594);
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(75, 23);
            this.bntCancelar.TabIndex = 18;
            this.bntCancelar.Text = "Cancelar";
            this.bntCancelar.UseVisualStyleBackColor = true;
            this.bntCancelar.Click += new System.EventHandler(this.bntCancelar_Click);
            // 
            // bntSalvar
            // 
            this.bntSalvar.Location = new System.Drawing.Point(597, 594);
            this.bntSalvar.Name = "bntSalvar";
            this.bntSalvar.Size = new System.Drawing.Size(75, 23);
            this.bntSalvar.TabIndex = 19;
            this.bntSalvar.Text = "Salvar";
            this.bntSalvar.UseVisualStyleBackColor = true;
            this.bntSalvar.Click += new System.EventHandler(this.bntSalvar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(728, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Valor Total:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(795, 551);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(70, 20);
            this.txtValorTotal.TabIndex = 21;
            this.txtValorTotal.Text = "0,00";
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmFazerVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 629);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bntSalvar);
            this.Controls.Add(this.bntCancelar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridProdutosVenda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "FrmFazerVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVendaNova";
            this.Load += new System.EventHandler(this.FrmFazerVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProdutosVenda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cBoxCliente;
        private System.Windows.Forms.ComboBox cBoxLoja;
        private System.Windows.Forms.ComboBox cBoxFuncionario;
        private System.Windows.Forms.DateTimePicker DataVenda;
        private System.Windows.Forms.DataGridView dataGridProdutosVenda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cBoxProduto;
        private System.Windows.Forms.Button BntAdicionarProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bntCancelar;
        private System.Windows.Forms.Button bntSalvar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValorTotal;
    }
}