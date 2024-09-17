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
            this.endereçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bairroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefoneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animalToolStripMenuItem,
            this.endereçoToolStripMenuItem,
            this.telefoneToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // animalToolStripMenuItem
            // 
            this.animalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.racaToolStripMenuItem1,
            this.tipoAnimalToolStripMenuItem1});
            this.animalToolStripMenuItem.Name = "animalToolStripMenuItem";
            this.animalToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.animalToolStripMenuItem.Text = "Animal";
            // 
            // racaToolStripMenuItem1
            // 
            this.racaToolStripMenuItem1.Name = "racaToolStripMenuItem1";
            this.racaToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.racaToolStripMenuItem1.Text = "Raca";
            this.racaToolStripMenuItem1.Click += new System.EventHandler(this.racaToolStripMenuItem1_Click);
            // 
            // tipoAnimalToolStripMenuItem1
            // 
            this.tipoAnimalToolStripMenuItem1.Name = "tipoAnimalToolStripMenuItem1";
            this.tipoAnimalToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.tipoAnimalToolStripMenuItem1.Text = "Tipo Animal";
            this.tipoAnimalToolStripMenuItem1.Click += new System.EventHandler(this.tipoAnimalToolStripMenuItem1_Click);
            // 
            // endereçoToolStripMenuItem
            // 
            this.endereçoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bairroToolStripMenuItem,
            this.ruaToolStripMenuItem,
            this.paisToolStripMenuItem});
            this.endereçoToolStripMenuItem.Name = "endereçoToolStripMenuItem";
            this.endereçoToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.endereçoToolStripMenuItem.Text = "Endereço";
            // 
            // bairroToolStripMenuItem
            // 
            this.bairroToolStripMenuItem.Name = "bairroToolStripMenuItem";
            this.bairroToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.bairroToolStripMenuItem.Text = "Bairro";
            this.bairroToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bairroToolStripMenuItem.Click += new System.EventHandler(this.bairroToolStripMenuItem_Click);
            // 
            // ruaToolStripMenuItem
            // 
            this.ruaToolStripMenuItem.Name = "ruaToolStripMenuItem";
            this.ruaToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.ruaToolStripMenuItem.Text = "Rua";
            this.ruaToolStripMenuItem.Click += new System.EventHandler(this.ruaToolStripMenuItem_Click);
            // 
            // paisToolStripMenuItem
            // 
            this.paisToolStripMenuItem.Name = "paisToolStripMenuItem";
            this.paisToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.paisToolStripMenuItem.Text = "Pais";
            this.paisToolStripMenuItem.Click += new System.EventHandler(this.paisToolStripMenuItem_Click);
            // 
            // telefoneToolStripMenuItem
            // 
            this.telefoneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.telefoneToolStripMenuItem1});
            this.telefoneToolStripMenuItem.Name = "telefoneToolStripMenuItem";
            this.telefoneToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.telefoneToolStripMenuItem.Text = "Telefones";
            // 
            // telefoneToolStripMenuItem1
            // 
            this.telefoneToolStripMenuItem1.Name = "telefoneToolStripMenuItem1";
            this.telefoneToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.telefoneToolStripMenuItem1.Text = "Telefone";
            this.telefoneToolStripMenuItem1.Click += new System.EventHandler(this.telefoneToolStripMenuItem1_Click);
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
    }
}

