namespace Veterinaria.view
{
    partial class FrmBairro
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnNovo = new System.Windows.Forms.ToolStripButton();
            this.BtnSalvar = new System.Windows.Forms.ToolStripButton();
            this.BtnCancelar = new System.Windows.Forms.ToolStripButton();
            this.BtnApagar = new System.Windows.Forms.ToolStripButton();
            this.BtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.BtnAnterior = new System.Windows.Forms.ToolStripButton();
            this.BtnProximo = new System.Windows.Forms.ToolStripButton();
            this.BtnUltimo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblBuscar = new System.Windows.Forms.ToolStripLabel();
            this.TxtBuscar = new System.Windows.Forms.ToolStripTextBox();
            this.BtnBuscar = new System.Windows.Forms.ToolStripButton();
            this.TxtBairro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridBairro = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBairro)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnNovo,
            this.BtnSalvar,
            this.BtnCancelar,
            this.BtnApagar,
            this.BtnEditar,
            this.toolStripSeparator1,
            this.BtnPrimeiro,
            this.BtnAnterior,
            this.BtnProximo,
            this.BtnUltimo,
            this.toolStripSeparator2,
            this.lblBuscar,
            this.TxtBuscar,
            this.BtnBuscar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(580, 39);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnNovo
            // 
            this.BtnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnNovo.Image = global::Veterinaria.Properties.Resources.botao_adicionar;
            this.BtnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(36, 36);
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSalvar.Enabled = false;
            this.BtnSalvar.Image = global::Veterinaria.Properties.Resources.salvar;
            this.BtnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(36, 36);
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCancelar.Enabled = false;
            this.BtnCancelar.Image = global::Veterinaria.Properties.Resources.cancelar;
            this.BtnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(36, 36);
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnApagar
            // 
            this.BtnApagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnApagar.Image = global::Veterinaria.Properties.Resources.apagar;
            this.BtnApagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnApagar.Name = "BtnApagar";
            this.BtnApagar.Size = new System.Drawing.Size(36, 36);
            this.BtnApagar.Text = "Apagar";
            this.BtnApagar.Click += new System.EventHandler(this.BtnApagar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEditar.Image = global::Veterinaria.Properties.Resources.editar;
            this.BtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(36, 36);
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // BtnPrimeiro
            // 
            this.BtnPrimeiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnPrimeiro.Image = global::Veterinaria.Properties.Resources.primeiro;
            this.BtnPrimeiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnPrimeiro.Name = "BtnPrimeiro";
            this.BtnPrimeiro.Size = new System.Drawing.Size(36, 36);
            this.BtnPrimeiro.Text = "Primeiro";
            this.BtnPrimeiro.Click += new System.EventHandler(this.BtnPrimeiro_Click);
            // 
            // BtnAnterior
            // 
            this.BtnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAnterior.Image = global::Veterinaria.Properties.Resources.seta_esquerda;
            this.BtnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAnterior.Name = "BtnAnterior";
            this.BtnAnterior.Size = new System.Drawing.Size(36, 36);
            this.BtnAnterior.Text = "Anterior";
            this.BtnAnterior.Click += new System.EventHandler(this.BtnAnterior_Click);
            // 
            // BtnProximo
            // 
            this.BtnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnProximo.Image = global::Veterinaria.Properties.Resources.seta_direita;
            this.BtnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnProximo.Name = "BtnProximo";
            this.BtnProximo.Size = new System.Drawing.Size(36, 36);
            this.BtnProximo.Text = "Proximo";
            this.BtnProximo.Click += new System.EventHandler(this.BtnProximo_Click);
            // 
            // BtnUltimo
            // 
            this.BtnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnUltimo.Image = global::Veterinaria.Properties.Resources.ultimo;
            this.BtnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUltimo.Name = "BtnUltimo";
            this.BtnUltimo.Size = new System.Drawing.Size(36, 36);
            this.BtnUltimo.Text = "Ultimo";
            this.BtnUltimo.Click += new System.EventHandler(this.BtnUltimo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(42, 36);
            this.lblBuscar.Text = "Buscar";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(140, 39);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnBuscar.Image = global::Veterinaria.Properties.Resources.ampliacao;
            this.BtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(36, 36);
            this.BtnBuscar.Text = "toolStripButton1";
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBairro
            // 
            this.TxtBairro.Enabled = false;
            this.TxtBairro.Location = new System.Drawing.Point(56, 86);
            this.TxtBairro.Name = "TxtBairro";
            this.TxtBairro.Size = new System.Drawing.Size(503, 20);
            this.TxtBairro.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bairro:";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Location = new System.Drawing.Point(56, 60);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(86, 20);
            this.TxtCodigo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código:";
            // 
            // DataGridBairro
            // 
            this.DataGridBairro.AllowUserToAddRows = false;
            this.DataGridBairro.AllowUserToDeleteRows = false;
            this.DataGridBairro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridBairro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NomeBairro});
            this.DataGridBairro.Location = new System.Drawing.Point(18, 129);
            this.DataGridBairro.Name = "DataGridBairro";
            this.DataGridBairro.ReadOnly = true;
            this.DataGridBairro.Size = new System.Drawing.Size(541, 223);
            this.DataGridBairro.TabIndex = 6;
            this.DataGridBairro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridBairro_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // NomeBairro
            // 
            this.NomeBairro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeBairro.HeaderText = "Bairro";
            this.NomeBairro.Name = "NomeBairro";
            this.NomeBairro.ReadOnly = true;
            // 
            // FrmBairro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 393);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TxtBairro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridBairro);
            this.Name = "FrmBairro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Bairro";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridBairro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnNovo;
        private System.Windows.Forms.ToolStripButton BtnSalvar;
        private System.Windows.Forms.ToolStripButton BtnCancelar;
        private System.Windows.Forms.ToolStripButton BtnApagar;
        private System.Windows.Forms.ToolStripButton BtnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnPrimeiro;
        private System.Windows.Forms.ToolStripButton BtnAnterior;
        private System.Windows.Forms.ToolStripButton BtnProximo;
        private System.Windows.Forms.ToolStripButton BtnUltimo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblBuscar;
        private System.Windows.Forms.ToolStripTextBox TxtBuscar;
        private System.Windows.Forms.ToolStripButton BtnBuscar;
        private System.Windows.Forms.TextBox TxtBairro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridBairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeBairro;
    }
}