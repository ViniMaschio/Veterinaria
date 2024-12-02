namespace Veterinaria.view
{
    partial class FrmItensVendaServico
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
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dGView = new System.Windows.Forms.DataGridView();
            this.bntSair = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CidAnimal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(714, 348);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(74, 20);
            this.txtValorTotal.TabIndex = 9;
            this.txtValorTotal.Text = "0,00";
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(647, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Valor Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Servico da Venda";
            // 
            // dGView
            // 
            this.dGView.AllowUserToAddRows = false;
            this.dGView.AllowUserToDeleteRows = false;
            this.dGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NomeProduto,
            this.CidAnimal,
            this.Quantidade,
            this.ValorUnitario,
            this.ValorTotal});
            this.dGView.Location = new System.Drawing.Point(12, 116);
            this.dGView.Name = "dGView";
            this.dGView.ReadOnly = true;
            this.dGView.Size = new System.Drawing.Size(776, 226);
            this.dGView.TabIndex = 6;
            // 
            // bntSair
            // 
            this.bntSair.Location = new System.Drawing.Point(363, 392);
            this.bntSair.Name = "bntSair";
            this.bntSair.Size = new System.Drawing.Size(75, 23);
            this.bntSair.TabIndex = 5;
            this.bntSair.Text = "Sair";
            this.bntSair.UseVisualStyleBackColor = true;
            this.bntSair.Click += new System.EventHandler(this.bntSair_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // NomeProduto
            // 
            this.NomeProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeProduto.HeaderText = "Produto";
            this.NomeProduto.Name = "NomeProduto";
            this.NomeProduto.ReadOnly = true;
            // 
            // CidAnimal
            // 
            this.CidAnimal.HeaderText = "CidAnimal";
            this.CidAnimal.Name = "CidAnimal";
            this.CidAnimal.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // ValorUnitario
            // 
            this.ValorUnitario.HeaderText = "Valor Unitario";
            this.ValorUnitario.Name = "ValorUnitario";
            this.ValorUnitario.ReadOnly = true;
            // 
            // ValorTotal
            // 
            this.ValorTotal.HeaderText = "Valor Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.ReadOnly = true;
            // 
            // FrmItensVendaServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGView);
            this.Controls.Add(this.bntSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItensVendaServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmItensVendaServico";
            ((System.ComponentModel.ISupportInitialize)(this.dGView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGView;
        private System.Windows.Forms.Button bntSair;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CidAnimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
    }
}