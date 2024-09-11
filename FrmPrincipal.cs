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
    }
}
