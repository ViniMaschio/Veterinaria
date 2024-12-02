namespace Veterinaria.view
{
    partial class FrmFazerVendaServico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bntSalvar = new System.Windows.Forms.Button();
            this.bntCancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cBoxServico = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BntAdicionarServico = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxCliente = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DataVenda = new System.Windows.Forms.DateTimePicker();
            this.cBoxFuncionario = new System.Windows.Forms.ComboBox();
            this.cBoxAnimal = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DataGridProdutosVenda = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidanimal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutosVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(838, 554);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(70, 20);
            this.txtValorTotal.TabIndex = 30;
            this.txtValorTotal.Text = "0,00";
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(771, 561);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Valor Total:";
            // 
            // bntSalvar
            // 
            this.bntSalvar.Location = new System.Drawing.Point(594, 594);
            this.bntSalvar.Name = "bntSalvar";
            this.bntSalvar.Size = new System.Drawing.Size(75, 23);
            this.bntSalvar.TabIndex = 28;
            this.bntSalvar.Text = "Salvar";
            this.bntSalvar.UseVisualStyleBackColor = true;
            this.bntSalvar.Click += new System.EventHandler(this.bntSalvar_Click);
            // 
            // bntCancelar
            // 
            this.bntCancelar.Location = new System.Drawing.Point(513, 594);
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(75, 23);
            this.bntCancelar.TabIndex = 27;
            this.bntCancelar.Text = "Cancelar";
            this.bntCancelar.UseVisualStyleBackColor = true;
            this.bntCancelar.Click += new System.EventHandler(this.bntCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cBoxServico);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.BntAdicionarServico);
            this.panel2.Location = new System.Drawing.Point(914, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 204);
            this.panel2.TabIndex = 26;
            // 
            // cBoxServico
            // 
            this.cBoxServico.FormattingEnabled = true;
            this.cBoxServico.Location = new System.Drawing.Point(63, 24);
            this.cBoxServico.Name = "cBoxServico";
            this.cBoxServico.Size = new System.Drawing.Size(253, 21);
            this.cBoxServico.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Servico:";
            // 
            // BntAdicionarServico
            // 
            this.BntAdicionarServico.Location = new System.Drawing.Point(93, 72);
            this.BntAdicionarServico.Name = "BntAdicionarServico";
            this.BntAdicionarServico.Size = new System.Drawing.Size(122, 36);
            this.BntAdicionarServico.TabIndex = 15;
            this.BntAdicionarServico.Text = "Adicionar Servico";
            this.BntAdicionarServico.UseVisualStyleBackColor = true;
            this.BntAdicionarServico.Click += new System.EventHandler(this.BntAdicionarServico_Click);
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
            this.panel1.Controls.Add(this.cBoxAnimal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(104, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 174);
            this.panel1.TabIndex = 25;
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
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(61, 24);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(30, 20);
            this.txtCodigo.TabIndex = 7;
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
            // cBoxCliente
            // 
            this.cBoxCliente.FormattingEnabled = true;
            this.cBoxCliente.Location = new System.Drawing.Point(182, 20);
            this.cBoxCliente.Name = "cBoxCliente";
            this.cBoxCliente.Size = new System.Drawing.Size(408, 21);
            this.cBoxCliente.TabIndex = 8;
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
            // DataVenda
            // 
            this.DataVenda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataVenda.Location = new System.Drawing.Point(819, 21);
            this.DataVenda.Name = "DataVenda";
            this.DataVenda.Size = new System.Drawing.Size(111, 20);
            this.DataVenda.TabIndex = 11;
            // 
            // cBoxFuncionario
            // 
            this.cBoxFuncionario.FormattingEnabled = true;
            this.cBoxFuncionario.Location = new System.Drawing.Point(83, 107);
            this.cBoxFuncionario.Name = "cBoxFuncionario";
            this.cBoxFuncionario.Size = new System.Drawing.Size(345, 21);
            this.cBoxFuncionario.TabIndex = 10;
            // 
            // cBoxAnimal
            // 
            this.cBoxAnimal.FormattingEnabled = true;
            this.cBoxAnimal.Location = new System.Drawing.Point(537, 107);
            this.cBoxAnimal.Name = "cBoxAnimal";
            this.cBoxAnimal.Size = new System.Drawing.Size(393, 21);
            this.cBoxAnimal.TabIndex = 9;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Animal:";
            // 
            // DataGridProdutosVenda
            // 
            this.DataGridProdutosVenda.AllowUserToAddRows = false;
            this.DataGridProdutosVenda.AllowUserToDeleteRows = false;
            this.DataGridProdutosVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridProdutosVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NomeProduto,
            this.cidanimal,
            this.Quantidade,
            this.ValorUnitario,
            this.ValorTotal});
            this.DataGridProdutosVenda.Location = new System.Drawing.Point(9, 294);
            this.DataGridProdutosVenda.Name = "DataGridProdutosVenda";
            this.DataGridProdutosVenda.Size = new System.Drawing.Size(899, 254);
            this.DataGridProdutosVenda.TabIndex = 24;
            this.DataGridProdutosVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridProdutosVenda_CellClick);
            this.DataGridProdutosVenda.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridProdutosVenda_CellEndEdit);
            this.DataGridProdutosVenda.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridProdutosVenda_CellValueChanged);
            this.DataGridProdutosVenda.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridProdutosVenda_EditingControlShowing);
            this.DataGridProdutosVenda.Click += new System.EventHandler(this.DataGridProdutosVenda_Click);
            // 
            // ID
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // NomeProduto
            // 
            this.NomeProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeProduto.HeaderText = "Servico";
            this.NomeProduto.Name = "NomeProduto";
            this.NomeProduto.ReadOnly = true;
            // 
            // cidanimal
            // 
            this.cidanimal.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cidanimal.HeaderText = "Cid Animal";
            this.cidanimal.Name = "cidanimal";
            // 
            // Quantidade
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Quantidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            // 
            // ValorUnitario
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ValorUnitario.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValorUnitario.HeaderText = "Valor Unit.";
            this.ValorUnitario.Name = "ValorUnitario";
            this.ValorUnitario.ReadOnly = true;
            // 
            // ValorTotal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ValorTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(492, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Itens Servico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(517, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Vendas Servico";
            // 
            // FrmFazerVendaServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 660);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bntSalvar);
            this.Controls.Add(this.bntCancelar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DataGridProdutosVenda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "FrmFazerVendaServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFazerVendaServico";
            this.Load += new System.EventHandler(this.FrmFazerVendaServico_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutosVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bntSalvar;
        private System.Windows.Forms.Button bntCancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cBoxServico;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BntAdicionarServico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DataVenda;
        private System.Windows.Forms.ComboBox cBoxFuncionario;
        private System.Windows.Forms.ComboBox cBoxAnimal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DataGridProdutosVenda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProduto;
        private System.Windows.Forms.DataGridViewComboBoxColumn cidanimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
    }
}