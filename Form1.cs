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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            FrmRaca frmraca = new FrmRaca();
            frmraca.ShowDialog();

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FmTipoAnimal fmTipoAnimal = new FmTipoAnimal();
            fmTipoAnimal.ShowDialog();
        }
    }
}
