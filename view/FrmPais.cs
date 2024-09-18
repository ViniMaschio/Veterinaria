using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmPais : Form
    {
        public FrmPais()
        {
            InitializeComponent();
            CarregarTabelaTodos();
        }

        Byte[] NovaFotoPais;
        Boolean novo = true;
        int posicao;
        List<M_Pais> listaPais = new List<M_Pais>();

        public void CarregarTabelaTodos()
        {

            C_Pais c_Pais = new C_Pais();
            listaPais = (List<M_Pais>)c_Pais.Buscar_Todos();

            LimparCampos();

            CarrregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Pais c_Pais = new C_Pais();
            listaPais = new List<M_Pais>();
            listaPais = (List<M_Pais>)c_Pais.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarrregarDataGrid();
        }

        public void CarrregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listaPais.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGView);
                row.Cells[0].Value = listaPais[i].codpais;
                row.Cells[1].Value = listaPais[i].nomepais;
                dGView.Rows.Add(row);
            }

            if (listaPais.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void AtualizarCampos()
        {
            txtCodigo.Text = listaPais[posicao].codpais.ToString();
            txtPais.Text = listaPais[posicao].nomepais.ToString();

            ByteParaImage(listaPais[posicao].bandeira);
            NovaFotoPais = listaPais[posicao].bandeira;
        }

        private void AtivarBotoes()
        {
            btnNovo.Enabled = false;
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            BntNovaFoto.Enabled = true;
        }

        private void AtivarCampos()
        {
            txtPais.Enabled = true;
        }

        private void LimparCampos()
        {
            txtCodigo.Text = "";
            txtPais.Text = "";
            pictureBoxPais.Image = null;
        }

        private void DesativarCampos()
        {
            txtPais.Enabled = false;
        }

        private void DesativarBotoes()
        {
            btnNovo.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            BntNovaFoto.Enabled = false;
        }

        private byte[] ImageParaByte()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBoxPais.Image.Save(ms, pictureBoxPais.Image.RawFormat);
                return ms.ToArray();
            }
        }

        private void ByteParaImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                pictureBoxPais.Image = Image.FromStream(ms);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();

            AtivarBotoes();

            AtivarCampos();

            novo = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            M_Pais m_Pais = new M_Pais();
            m_Pais.nomepais = txtPais.Text;
            m_Pais.bandeira = NovaFotoPais;

            C_Pais c_Pais = new C_Pais();

            if (novo)
            {
                c_Pais.Insere_Dados(m_Pais);
            }
            else
            {
                m_Pais.codpais = Int32.Parse(txtCodigo.Text);
                c_Pais.Atualizar_Dados(m_Pais);
            }

            CarregarTabelaTodos();

            DesativarBotoes();

            DesativarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();

            DesativarBotoes();

            DesativarCampos();

            if (listaPais.Count > 0)
            {
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_Pais c_Pais = new C_Pais();

                c_Pais.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

                CarregarTabelaTodos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                AtivarBotoes();
                AtivarCampos();

                novo = false;
            }
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            if (listaPais.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicao > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao--;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (listaPais.Count - 1 > posicao)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listaPais.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listaPais.Count - 1;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }

        private void BntNovaFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            //openFileDialog1.Title = "Selecione uma imagem";

            // Verifica se o usuário selecionou um arquivo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Carrega a imagem selecionada no PictureBox
                pictureBoxPais.Image = Image.FromFile(openFileDialog1.FileName);
                NovaFotoPais = ImageParaByte();
            }
        }

        private void dGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicao = e.RowIndex;
            if (posicao >= 0) { AtualizarCampos(); }
        }
    }
}
