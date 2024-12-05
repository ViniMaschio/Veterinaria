using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;

namespace Veterinaria.view
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
            CarregarComboBox();
            CarregarTabelaTodos();
            
        }

        Boolean novo = true;
        int posicao;
        List<M_Cliente> listCliente = new List<M_Cliente>();
        Byte[] NovaFotoCliente;

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            txtNomeCliente.Text = "";
            txtCPF.Text = "";
            txtNumero.Text = "";
            cBoxCep.SelectedItem = null;
            cBoxCidade.SelectedItem = null;
            cBoxEstado.SelectedItem = null;
            cBoxPais.SelectedItem = null;
            cBoxRua.SelectedItem = null;
            cBoxBairro.SelectedItem = null;
            picFotoCliente.Image = null;

        }

        public void CarregarComboBox()
        {
            CarregarCidade();

            CarregarCep();

            CarregarEstado();

            CarregarPais();

            CarregarRua();

            CarregarBairro();

        }

        public void CarregarBairro()
        {
            C_Bairro c_Bairro = new C_Bairro();
            List<M_Bairro> listBairro = new List<M_Bairro>();
            listBairro = (List<M_Bairro>)c_Bairro.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomebairro", typeof(string));
            dataTable.Columns.Add("codbairro", typeof(int));

            foreach (M_Bairro bairro in listBairro)
            {
                dataTable.Rows.Add(bairro.nomebairro, bairro.codbairro);
            }

            cBoxBairro.DataSource = dataTable;
            cBoxBairro.DisplayMember = "nomebairro";
            cBoxBairro.ValueMember = "codbairro";
        }

        public void CarregarRua()
        {
            C_Rua c_Rua = new C_Rua();
            List<M_Rua> listRua = new List<M_Rua>();
            listRua = (List<M_Rua>)c_Rua.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomerua", typeof(string));
            dataTable.Columns.Add("codrua", typeof(int));

            foreach (M_Rua rua in listRua)
            {
                dataTable.Rows.Add(rua.nomerua, rua.codrua);
            }

            cBoxRua.DataSource = dataTable;
            cBoxRua.DisplayMember = "nomerua";
            cBoxRua.ValueMember = "codrua";
        }

        public void CarregarPais()
        {
            C_Pais c_Pais = new C_Pais();
            List<M_Pais> listPais = new List<M_Pais>();
            listPais = (List<M_Pais>)c_Pais.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomepais", typeof(string));
            dataTable.Columns.Add("codpais", typeof(int));

            foreach (M_Pais pais in listPais)
            {
                dataTable.Rows.Add(pais.nomepais, pais.codpais);
            }

            cBoxPais.DataSource = dataTable;
            cBoxPais.DisplayMember = "nomepais";
            cBoxPais.ValueMember = "codpais";
        }

        public void CarregarEstado()
        {
            C_Estado c_Estado = new C_Estado();
            List<M_Estado> listEstado = new List<M_Estado>();
            listEstado = (List<M_Estado>)c_Estado.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomeestado", typeof(string));
            dataTable.Columns.Add("codestado", typeof(int));

            foreach (M_Estado estado in listEstado)
            {
                dataTable.Rows.Add(estado.nomeestado, estado.codestado);
            }


            cBoxEstado.DataSource = dataTable;
            cBoxEstado.DisplayMember = "nomeestado";
            cBoxEstado.ValueMember = "codestado";

        }

        public void CarregarCidade()
        {
            C_Cidade c_Cidade = new C_Cidade();
            List<M_Cidade> listCidade = new List<M_Cidade>();
            listCidade = (List<M_Cidade>)c_Cidade.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("nomecidade", typeof(string));
            dataTable.Columns.Add("codcidade", typeof(int));

            foreach (M_Cidade cidade in listCidade)
            {
                dataTable.Rows.Add(cidade.nomecidade, cidade.codcidade);
            }

            cBoxCidade.DataSource = dataTable;
            cBoxCidade.DisplayMember = "nomecidade";
            cBoxCidade.ValueMember = "codcidade";
        }

        public void CarregarCep()
        {
            C_Cep c_Cep = new C_Cep();

            List<M_Cep> listCep = new List<M_Cep>();
            listCep = (List<M_Cep>)c_Cep.Buscar_Todos();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("numerocep", typeof(string));
            dataTable.Columns.Add("codcep", typeof(int));

            foreach (M_Cep cep in listCep)
            {
                dataTable.Rows.Add(cep.numerocep, cep.codcep);
            }

            cBoxCep.DataSource = dataTable;
            cBoxCep.DisplayMember = "numerocep";
            cBoxCep.ValueMember = "codcep";
        }

        public void CarregarDataGrid()
        {
            dGView.Rows.Clear();

            for (int i = 0; i < listCliente.Count; i++)
            {

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dGView);
                row.Cells[0].Value = listCliente[i].codcliente;
                row.Cells[1].Value = listCliente[i].nomecliente;
                row.Cells[2].Value = listCliente[i].cpf;
                row.Cells[3].Value = listCliente[i].rua.nomerua;
                row.Cells[4].Value = listCliente[i].numerocasa;
                row.Cells[5].Value = listCliente[i].bairro.nomebairro;
                row.Cells[6].Value = listCliente[i].cep.numerocep;
                row.Cells[7].Value = listCliente[i].cidade.nomecidade;
                row.Cells[8].Value = listCliente[i].estado.nomeestado;
                row.Cells[9].Value = listCliente[i].pais.nomepais;
                row.Cells[10].Value = listCliente[i].fotocliente;

                dGView.Rows.Add(row);
            }

            if (listCliente.Count > 0)
            {
                posicao = 0;
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        public void CarregarTabelaTodos()
        {
            C_Cliente c_Cliente = new C_Cliente();
            listCliente = (List<M_Cliente>)c_Cliente.Buscar_Todos();

            LimparCampos();

            CarregarDataGrid();
        }

        public void CarregarTabelaFiltro()
        {
            C_Cliente c_Cliente = new C_Cliente();
            listCliente = new List<M_Cliente>();
            listCliente = (List<M_Cliente>)c_Cliente.Buscar_Filtro(txtBuscar.Text.ToString());

            LimparCampos();

            CarregarDataGrid();
        }

        public void AtualizarCampos()
        {
            txtCodigo.Text = listCliente[posicao].codcliente.ToString();
            txtNomeCliente.Text = listCliente[posicao].nomecliente;
            txtCPF.Text = listCliente[posicao].cpf;
            txtNumero.Text = listCliente[posicao].numerocasa;
            cBoxCep.SelectedValue = listCliente[posicao].cep.codcep;
            cBoxCidade.SelectedValue = listCliente[posicao].cidade.codcidade;
            cBoxEstado.SelectedValue = listCliente[posicao].estado.codestado;
            cBoxPais.SelectedValue = listCliente[posicao].pais.codpais;
            cBoxRua.SelectedValue = listCliente[posicao].rua.codrua;
            cBoxBairro.SelectedValue = listCliente[posicao].bairro.codbairro;
            ByteParaImage(listCliente[posicao].fotocliente);
            NovaFotoCliente = listCliente[posicao].fotocliente;
        }

        public void AtivarBotoes()
        {
            btnNovo.Enabled = false;
            btnApagar.Enabled = false;
            btnEditar.Enabled = false;

            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            bntNovaFoto.Enabled = true;
        }

        public void AtivarCampos()
        {
            txtNomeCliente.Enabled = true;
            txtCPF.Enabled = true;
            txtNumero.Enabled = true;
            cBoxCep.Enabled = true;
            cBoxCidade.Enabled = true;
            cBoxEstado.Enabled = true;
            cBoxPais.Enabled = true;
            cBoxRua.Enabled = true;
            cBoxBairro.Enabled = true;

        }

        public void DesativarBotoes()
        {
            btnNovo.Enabled = true;
            btnApagar.Enabled = true;
            btnEditar.Enabled = true;

            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            bntNovaFoto.Enabled = false;
        }

        public void DesativarCampos()
        {
            txtNomeCliente.Enabled = false;
            txtCPF.Enabled = false;
            txtNumero.Enabled = false;
            cBoxCep.Enabled = false;
            cBoxCidade.Enabled = false;
            cBoxEstado.Enabled = false;
            cBoxPais.Enabled = false;
            cBoxRua.Enabled = false;
            cBoxBairro.Enabled = false;

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
            M_Cliente m_Cliente = new M_Cliente();
            M_Cep m_Cep = new M_Cep();
            M_Cidade m_Cidade = new M_Cidade();
            M_Estado m_Estado = new M_Estado();
            M_Pais m_Pais = new M_Pais();
            M_Rua m_Rua = new M_Rua();
            M_Bairro m_Bairro = new M_Bairro();

            m_Cep.codcep = int.Parse(cBoxCep.SelectedValue.ToString());
            m_Cidade.codcidade = int.Parse(cBoxCidade.SelectedValue.ToString());
            m_Estado.codestado = int.Parse(cBoxEstado.SelectedValue.ToString());
            m_Pais.codpais = int.Parse(cBoxPais.SelectedValue.ToString());
            m_Rua.codrua = int.Parse(cBoxRua.SelectedValue.ToString());
            m_Bairro.codbairro = int.Parse(cBoxBairro.SelectedValue.ToString());

            m_Cliente.nomecliente = txtNomeCliente.Text;
            m_Cliente.cpf = txtCPF.Text;
            m_Cliente.numerocasa = txtNumero.Text;
            m_Cliente.cep = m_Cep;
            m_Cliente.cidade = m_Cidade;
            m_Cliente.estado = m_Estado;
            m_Cliente.pais = m_Pais;
            m_Cliente.rua = m_Rua;
            m_Cliente.bairro = m_Bairro;
            m_Cliente.fotocliente = NovaFotoCliente;


            C_Cliente c_Cliente = new C_Cliente();

            if (novo)
            {
                c_Cliente.Insere_Dados(m_Cliente);
            }
            else
            {
                m_Cliente.codcliente = Convert.ToInt32(txtCodigo.Text);
                c_Cliente.Atualizar_Dados(m_Cliente);
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

            if (listCliente.Count > 0)
            {
                AtualizarCampos();
                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                C_Cliente c_Cliente = new C_Cliente();
                c_Cliente.Apaga_Dados(Convert.ToInt32(txtCodigo.Text));

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
            if (listCliente.Count > 0)
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
            if (posicao < listCliente.Count - 1)
            {
                dGView.Rows[posicao].Selected = false;
                posicao++;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (listCliente.Count > 0)
            {
                dGView.Rows[posicao].Selected = false;
                posicao = listCliente.Count - 1;

                AtualizarCampos();

                dGView.Rows[posicao].Selected = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CarregarTabelaFiltro();
        }

        private void dGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicao = e.RowIndex;
            if (posicao >= 0) { AtualizarCampos(); }
        }

        private void bntNovaFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagens|*.bmp;*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {  
                picFotoCliente.Image = Image.FromFile(openFileDialog1.FileName);
                NovaFotoCliente = ImageParaByte();
            }
        }

        private byte[] ImageParaByte()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                picFotoCliente.Image.Save(ms, picFotoCliente.Image.RawFormat);
                return ms.ToArray();
            }
        }

        private void ByteParaImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                picFotoCliente.Image = Image.FromStream(ms);
            }
        }
    }
}
